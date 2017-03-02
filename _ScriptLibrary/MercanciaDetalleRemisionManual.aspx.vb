Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration

Public Class MercanciaDetalleRemisionManual
    Inherits System.Web.UI.Page
    Private intmRemisionManualPedido As Integer
    Private strmRemisionManualNumero As String
    Private dtmmRemisionManualEmisionDocumento As String
    Private fltmRemisionManualImporteTotal As String
    Private fltmRemisionManualImporteIVA As String
    Private fltmRemisionManualImporteIVADescuento As String
    Private fltmRemisionManualImporteDescuentoDespuesIVA As String
    Private fltmRemisionManualImporteNeto As String
    Private intmEstadoRemisionManualFolio As Integer


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

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
            If intCompaniaId > 0 AndAlso intSucursalId > 0 Then
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
    ' Accessor   : Read, Write
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
    ' Name       : strURLPOSAdmin
    ' Description: URL del POS Admin
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strURLPOSAdmin() As String
        Get
            Return clsConcentrador.strObtenerURLSucursal(intCompaniaId, intSucursalId, strCadenaConexion)
        End Get
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Comando a ejecutar
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Not IsNothing(Request.QueryString("strCmd")) Then
                Return (Request.QueryString("strCmd"))
            Else
                Return ""
            End If
        End Get
    End Property
    '====================================================================
    ' Name       : intProveedorId
    ' Description: Proveedor con Remisions Pendientes
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intProveedorId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intProveedorId")) Then
                Return CInt(Request.QueryString("intProveedorId"))
            Else
                Return 0
            End If
        End Get
    End Property
    '====================================================================
    ' Name       : intRemisionManualId
    ' Description: Número identificador de la Remision
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intRemisionManualId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intRemisionManualId")) Then
                Return CInt(Request.QueryString("intRemisionManualId"))
            Else
                Return 0
            End If
        End Get
    End Property
    '====================================================================
    ' Name       : strNombreProveedor
    ' Description: Razón social del proveedor
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strNombreProveedor() As String
        Get
            Dim objDataArray As Array = Nothing
            Dim objRegistro As String() = Nothing

            objDataArray = clstblProveedor.strBuscar(intProveedorId, 0, 0, 0, "", 0, "", 0, 0, CDate("01/01/1900"), "", "", 0, 0, strCadenaConexion)

            If IsArray(objDataArray) Then
                If objDataArray.Length > 0 Then
                    objRegistro = DirectCast(objDataArray.GetValue(0), String())

                    Return objRegistro(4)
                End If
            End If

            Return ""
        End Get
    End Property
    '====================================================================
    ' Name       : intRemisionManualPedido
    ' Description: Número de pedido de la Remision
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intRemisionManualPedido() As Integer
        Get
            Return intmRemisionManualPedido
        End Get
        Set(ByVal intValue As Integer)
            intmRemisionManualPedido = intValue
        End Set
    End Property
    '====================================================================
    ' Name       : strRemisionManualNumero
    ' Description: Número de Remision 
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRemisionManualNumero() As String
        Get
            Return strmRemisionManualNumero
        End Get
        Set(ByVal strValue As String)
            strmRemisionManualNumero = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : dtmRemisionManualEmisionDocumento
    ' Description: Fecha de Remision
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property dtmRemisionManualEmisionDocumento() As String
        Get
            Return dtmmRemisionManualEmisionDocumento
        End Get
        Set(ByVal strValue As String)
            dtmmRemisionManualEmisionDocumento = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : fltRemisionManualImporteTotal
    ' Description: Importe total de la Remision
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property fltRemisionManualImporteTotal() As String
        Get
            Return fltmRemisionManualImporteTotal
        End Get
        Set(ByVal strValue As String)
            fltmRemisionManualImporteTotal = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : fltRemisionManualImporteIVA
    ' Description: Importe del IVA
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property fltRemisionManualImporteIVA() As String
        Get
            Return fltmRemisionManualImporteIVA
        End Get
        Set(ByVal strValue As String)
            fltmRemisionManualImporteIVA = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : fltRemisionManualImporteIVADescuento
    ' Description: Importe del IVA del descuento
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property fltRemisionManualImporteIVADescuento() As String
        Get
            Return fltmRemisionManualImporteIVADescuento
        End Get
        Set(ByVal strValue As String)
            fltmRemisionManualImporteIVADescuento = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : fltRemisionManualImporteDescuentoDespuesIVA
    ' Description: Importe de descuento después del IVA
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property fltRemisionManualImporteDescuentoDespuesIVA() As String
        Get
            Return fltmRemisionManualImporteDescuentoDespuesIVA
        End Get
        Set(ByVal strValue As String)
            fltmRemisionManualImporteDescuentoDespuesIVA = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : fltRemisionManualImporteNeto
    ' Description: Importe neto
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property fltRemisionManualImporteNeto() As String
        Get
            Return fltmRemisionManualImporteNeto
        End Get
        Set(ByVal strValue As String)
            fltmRemisionManualImporteNeto = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : intEstadoRemisionManualFolio
    ' Description: Folio de la Remision
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intEstadoRemisionManualFolio() As Integer
        Get
            Return intmEstadoRemisionManualFolio
        End Get
        Set(ByVal intValue As Integer)
            intmEstadoRemisionManualFolio = intValue
        End Set
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
        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If


        ' Validamos que tenga los parametros necesarios para hacer la busqueda
        If intProveedorId > 0 AndAlso intRemisionManualId > 0 Then
            Dim objDataArray As Array = Nothing
            Dim objRegistro As String() = Nothing

            ' Traemos la información de detalle

            objDataArray = clsConcentrador.clsSucursal.clsMercancia.clsFacturaManual.strBuscarFacturaRemisionManual(intRemisionManualId, intCompaniaId, intSucursalId, intProveedorId, 0, 0, True, True, 0, 0, strCadenaConexion)

            ' Validamos que se un arreglo válido
            If IsArray(objDataArray) Then
                If objDataArray.Length > 0 Then

                    objRegistro = DirectCast(objDataArray.GetValue(0), String())

                    ' Asignamos los valores a las propiedades

                    ' Número de Remision
                    strRemisionManualNumero = CStr(objRegistro.GetValue(2))

                    ' Fecha de emisión de la Remision 
                    dtmRemisionManualEmisionDocumento = CDate(objRegistro.GetValue(3)).ToString("dd/MM/yyyy")

                    ' Número de Pedido
                    intRemisionManualPedido = 0 'objRegistro.GetValue(2)

                    ' Importe Total
                    fltRemisionManualImporteTotal = FormatCurrency(objRegistro.GetValue(7), 2)


                    ' Importe de iva
                    fltRemisionManualImporteIVA = FormatCurrency(CDbl(objRegistro.GetValue(6)), 2)

                    ' Importe de iva del descuento
                    fltRemisionManualImporteIVADescuento = FormatCurrency(CDbl(objRegistro.GetValue(9)), 2)

                    ' Descuento despues de IVA
                    fltRemisionManualImporteDescuentoDespuesIVA = FormatCurrency(objRegistro.GetValue(8), 2)

                    ' Importe Neto
                    fltRemisionManualImporteNeto = FormatCurrency(objRegistro.GetValue(5), 2)

                    ' Número de folio
                    intEstadoRemisionManualFolio = CInt(objRegistro.GetValue(10))

                End If
            End If


        Else
            Call Response.Redirect("MercanciaConsultarFacturaRemisionManual.aspx")
        End If

    End Sub


End Class
