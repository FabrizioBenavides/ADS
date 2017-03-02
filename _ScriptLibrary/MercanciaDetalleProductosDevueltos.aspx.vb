Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration

Public Class clsMercanciaDetalleProductosDevueltos
    Inherits System.Web.UI.Page
    Private intmFolio As Integer
    Private strmFechaDevolucion As String
    Private strmNombreProveedor As String
    Private strmMotivoDevolucion As String
    Private intmProveedor As Integer

    Private intmDevolucionNumeroDocumento As Integer
    Private strmDevolucionNumeroFactura As String
    Private strmDepartamentoNombre As String
    Private blnmEsCompraDirecta As Boolean


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    '====================================================================
    ' Name       : strRedirectPage
    ' Description: Página hacia la cual se debe redireccionar al usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRedirectPage() As String
        Get
            If intCompaniaId > 0 Then
                Return "/Default.aspx?strURL=/_ScriptLibrary/POSAdminRedirectorCC.aspx?strPageName=" & strThisPageName
            Else
                Return "/Default.aspx?strURL=" & Server.UrlEncode(Request.ServerVariables("SCRIPT_NAME"))
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strFormAction
    ' Description: Valor de la acción de la forma HTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormAction() As String
        Get
            Return Request.ServerVariables("SCRIPT_NAME")
        End Get
    End Property

    '====================================================================
    ' Name       : intCompaniaId
    ' Description: Valor de la Compañia 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCompaniaId() As Integer
        Get
            Return CInt(clsCommons.strReadCookie("intCompaniaId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Valor de la Sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intSucursalId() As Integer
        Get
            Return CInt(clsCommons.strReadCookie("intSucursalId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strSucursalNombre
    ' Description: Nombre de la Sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalNombre() As String
        Get
            Return clsCommons.strReadCookie("strSucursalNombre", "0", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : intGrupoUsuarioId
    ' Description: Identificador del Grupo de Usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intGrupoUsuarioId() As Integer
        Get
            Return CInt(clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del Usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return clsCommons.strReadCookie("strUsuarioNombre", "0", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: URL de esta página
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return clsCommons.strGetPageName(Request)
        End Get
    End Property

    '====================================================================
    ' Name       : strCadenaConexion
    ' Description: Valor que tomara la variable strmCadenaConexion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCadenaConexion() As String
        Get
            Return ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : intDevolucionId
    ' Description: Valor de la transferencia.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDevolucionId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intDevolucionId")) Then
                Return CInt(Request.QueryString("intDevolucionId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intFolio
    ' Description: Valor del folio.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intFolio() As Integer
        Get
            Return intmFolio
        End Get
        Set(ByVal strValue As Integer)
            intmFolio = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaDevolucion
    ' Description: Valor de la orden.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strFechaDevolucion() As String
        Get
            Return strmFechaDevolucion
        End Get
        Set(ByVal strValue As String)
            strmFechaDevolucion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intProveedor
    ' Description: Valor de la orden.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intProveedor() As Integer
        Get
            Return intmProveedor
        End Get
        Set(ByVal strValue As Integer)
            intmProveedor = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaOrden
    ' Description: Valor de la orden.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strNombreProveedor() As String
        Get
            Return strmNombreProveedor
        End Get
        Set(ByVal strValue As String)
            strmNombreProveedor = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strMotivoDevolucion
    ' Description: Valor de la orden.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strMotivoDevolucion() As String
        Get
            Return strmMotivoDevolucion
        End Get
        Set(ByVal strValue As String)
            strmMotivoDevolucion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intDevolucionNumeroDocumento
    ' Description: Valor 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intDevolucionNumeroDocumento() As Integer
        Get
            Return intmDevolucionNumeroDocumento
        End Get
        Set(ByVal strValue As Integer)
            intmDevolucionNumeroDocumento = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strDevolucionNumeroFactura
    ' Description: Valor
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strDevolucionNumeroFactura() As String
        Get
            Return strmDevolucionNumeroFactura
        End Get
        Set(ByVal strValue As String)
            strmDevolucionNumeroFactura = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strDepartamentoNombre
    ' Description: Valor
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strDepartamentoNombre() As String
        Get
            Return strmDepartamentoNombre
        End Get
        Set(ByVal strValue As String)
            strmDepartamentoNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnEsCompraDirecta
    ' Description: Valor
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property blnEsCompraDirecta() As Boolean
        Get
            Return blnmEsCompraDirecta
        End Get
        Set(ByVal strValue As Boolean)
            blnmEsCompraDirecta = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Valor que tomara la variable strmRecordBrowserHTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRecordBrowserHTML() As String
        Get

            ' Declaración e inicialización de las variables locales
            Dim strTargetURL As String = Request.ServerVariables("SCRIPT_NAME") & "?"
            Dim objArrayDetalleDevueltos As Array = Nothing


            If blnEsCompraDirecta = True Then

                'Devolucion de Compras Directas
                objArrayDetalleDevueltos = clsConcentrador.clsSucursal.clsMercancia.clsDevolucion.strBuscarDetalle(intCompaniaId, intSucursalId, intDevolucionId, strCadenaConexion)
            Else
                'Devolucion de Insumos de Materia Prima (Control de Cafe)
                objArrayDetalleDevueltos = clsCapturaInsumosMateriaPrima.strBuscarDetalleDevolucion(intCompaniaId, intSucursalId, intDevolucionId, strCadenaConexion)
            End If

            If IsArray(objArrayDetalleDevueltos) AndAlso objArrayDetalleDevueltos.Length > 0 Then

                ' Generamos el Navegador de Registros
                Return clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaDetalleProductosDevueltos", objArrayDetalleDevueltos, 1, objArrayDetalleDevueltos.Length, strTargetURL))
            Else
                Return String.Empty
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : Page_Load
    ' Description: Evento "Load" de la página
    ' Parameters :
    '              ByVal objSender As System.Object
    '                 - Objeto que genera el Evento
    '              ByVal objEvent As System.EventArgs
    '                 - Argumentos del Evento
    ' Throws     : Ninguna
    ' Output     : Ninguna
    '====================================================================
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim objReciboTransferencias As Array = Nothing
        Dim strReciboTransferencias As String() = Nothing

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strRedirectPage)
        End If

        ' Hacemos la consulta de la información del cliene especial.
        objReciboTransferencias = clsConcentrador.clsSucursal.clsMercancia.clsDevolucion.strBuscar(intCompaniaId, intSucursalId, intDevolucionId, 0, 0, CDate("01/01/2003"), CDate("01/01/2003"), 0, 0, strCadenaConexion)

        If IsArray(objReciboTransferencias) AndAlso objReciboTransferencias.Length > 0 Then
            strReciboTransferencias = Nothing
            strReciboTransferencias = DirectCast(objReciboTransferencias.GetValue(objReciboTransferencias.Length - 1), String())

            'Regresamos todos los valores a la página.
            intProveedor = CInt(strReciboTransferencias(1))
            strFechaDevolucion = Benavides.POSAdmin.Commons.clsCommons.strFormatearFechaPresentacion(strReciboTransferencias(2))
            intFolio = CInt(strReciboTransferencias(3))
            strNombreProveedor = strReciboTransferencias(4)
            strMotivoDevolucion = strReciboTransferencias(5)
            intDevolucionNumeroDocumento = CInt(strReciboTransferencias(6))
            strDevolucionNumeroFactura = strReciboTransferencias(7)
            strDepartamentoNombre = strReciboTransferencias(8)
            blnEsCompraDirecta = CBool(strReciboTransferencias(9))
        End If

    End Sub

End Class
