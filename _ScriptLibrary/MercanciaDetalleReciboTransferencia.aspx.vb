Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration

Public Class clsMercanciaDetalleReciboTransferencias
    Inherits System.Web.UI.Page
    Private intmFolio As Integer
    Private strmNumeroOrden As String
    Private strmFechaOrden As String
    Private strmFechaConfirmacion As String
    Private strmMotivoTransferencia As String
    Private intmMotivoTransferencia As Integer
    Private strmCompaniaSucursalEnvia As String
    Private intmCompaniaSucursalEnvia As String


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
            ' Return "/Default.aspx?strURL=" & Server.UrlEncode(Request.ServerVariables("SCRIPT_NAME"))
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
    ' Name       : intTransferenciaId
    ' Description: Valor de la transferencia.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intTransferenciaId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intTransferenciaId")) Then
                Return CInt(Request.QueryString("intTransferenciaId"))
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
    ' Name       : strNumeroOrden
    ' Description: Valor de la orden.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strNumeroOrden() As String
        Get
            Return strmNumeroOrden
        End Get
        Set(ByVal strValue As String)
            strmNumeroOrden = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaOrden
    ' Description: Valor de la orden.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strFechaOrden() As String
        Get
            Return strmFechaOrden
        End Get
        Set(ByVal strValue As String)
            strmFechaOrden = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaOrden
    ' Description: Valor de la orden.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strFechaConfirmacion() As String
        Get
            Return strmFechaConfirmacion
        End Get
        Set(ByVal strValue As String)
            strmFechaConfirmacion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strMotivoTransferencia
    ' Description: Valor de la orden.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strMotivoTransferencia() As String
        Get
            Return strmMotivoTransferencia
        End Get
        Set(ByVal strValue As String)
            strmMotivoTransferencia = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intMotivoTransferencia
    ' Description: Valor de la orden.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intMotivoTransferencia() As Integer
        Get
            Return intmMotivoTransferencia
        End Get
        Set(ByVal strValue As Integer)
            intmMotivoTransferencia = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCompaniaSucursalEnvia
    ' Description: Valor de la orden.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strCompaniaSucursalEnvia() As String
        Get
            Return strmCompaniaSucursalEnvia
        End Get
        Set(ByVal strValue As String)
            strmCompaniaSucursalEnvia = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intSucursalEnvia
    ' Description: Valor de la orden.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intCompaniaSucursalEnvia() As String
        Get
            Return intmCompaniaSucursalEnvia
        End Get
        Set(ByVal strValue As String)
            intmCompaniaSucursalEnvia = strValue
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
            Dim objArrayDetalleTransferencia As Array = Nothing

            objArrayDetalleTransferencia = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.strBuscarDetalle(intCompaniaId, intSucursalId, intTransferenciaId, "RECIBIDA", 0, 0, strCadenaConexion)

            If IsArray(objArrayDetalleTransferencia) AndAlso objArrayDetalleTransferencia.Length > 0 Then

                ' Generamos el Navegador de Registros
                Return clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaDetalleReciboTransferencia", objArrayDetalleTransferencia, 1, objArrayDetalleTransferencia.Length, strTargetURL))
            Else
                Return ""
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

        'Response.Write("intTransferenciaId=[" & intTransferenciaId & "]<br>")
        'Response.Write("intCompaniaId=[" & intCompaniaId & "]<br>")
        'Response.Write("intSucursalId=[" & intSucursalId & "]<br>")

        If intTransferenciaId > 0 Then

            ' Hacemos la consulta de la información del cliene especial.
            objReciboTransferencias = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.strBuscar(intCompaniaId, intSucursalId, intTransferenciaId, "RECIBIDA", False, 0, 0, strCadenaConexion)

            If IsArray(objReciboTransferencias) AndAlso objReciboTransferencias.Length > 0 Then
                strReciboTransferencias = Nothing
                strReciboTransferencias = DirectCast(objReciboTransferencias.GetValue(objReciboTransferencias.Length - 1), String())

                'Response.Write("Si es arreglo<br>")

                'Regresamos todos los valores a la página.
                strNumeroOrden = strReciboTransferencias(1)
                strFechaOrden = clsCommons.strFormatearFechaPresentacion(strReciboTransferencias(2).ToString)
                intFolio = CInt(strReciboTransferencias(3))
                strFechaConfirmacion = clsCommons.strFormatearFechaPresentacion(strReciboTransferencias(4).ToString)
                intMotivoTransferencia = CInt(strReciboTransferencias(5))
                strMotivoTransferencia = strReciboTransferencias(6)
                intCompaniaSucursalEnvia = CStr(strReciboTransferencias(7)) & "-" & CStr(strReciboTransferencias(8))
                strCompaniaSucursalEnvia = clsCommons.strFormatearDescripcion(CStr(strReciboTransferencias(9)))
            End If
        End If

    End Sub

End Class
