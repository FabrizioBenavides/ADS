Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration
Imports System.DateTime


Public Class clsMercanciaDetalleFacturaElectronicaPD
    Inherits System.Web.UI.Page

    'Variables Globales
    Private strmMensaje As String = ""
    Private strmProveedorRazonSocial As String = ""
    Private strmFacturaElectronicaNumero As String = ""
    Private intmFacturaElectronicaPedido As Integer = 0
    Private dtmmFacturaElectronicaEmisionDocumento As Date
    Private intmRemisionCompraDirectaFolio As Integer = 0
    Private strmRemisionCompraDirectaNumeroDocumento As String = ""


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
    ' Name       : strMensaje
    ' Description: Mensajes enviados al usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strMensaje() As String
        Get
            Return strmMensaje
        End Get
        Set(ByVal strValue As String)
            strmMensaje = strValue
        End Set
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
    ' Description: Proveedor con Facturas Pendientes
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
    ' Name       : intRemisionCompraDirectaFolio
    ' Description:  
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intRemisionCompraDirectaFolio() As Integer
        Get
            Return intmRemisionCompraDirectaFolio
        End Get
        Set(ByVal strValue As Integer)
            intmRemisionCompraDirectaFolio = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strRemisionCompraDirectaNumeroDocumento
    ' Description:  
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRemisionCompraDirectaNumeroDocumento() As String
        Get
            Return strmRemisionCompraDirectaNumeroDocumento
        End Get
        Set(ByVal strValue As String)
            strmRemisionCompraDirectaNumeroDocumento = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intFacturaElectronicaPedido
    ' Description: Numero de pedido de la Factura
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intFacturaElectronicaPedido() As Integer
        Get
            Return intmFacturaElectronicaPedido
        End Get
        Set(ByVal strValue As Integer)
            intmFacturaElectronicaPedido = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFacturaElectronicaNumero
    ' Description: Nombre del Proveedor con Facturas Pendientes
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strFacturaElectronicaNumero() As String
        Get
            Return strmFacturaElectronicaNumero
        End Get
        Set(ByVal strValue As String)
            strmFacturaElectronicaNumero = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : dtmFacturaElectronicaEmisionDocumento
    ' Description: Fecha de la Factura
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property dtmFacturaElectronicaEmisionDocumento() As String
        Get
            Return dtmmFacturaElectronicaEmisionDocumento.ToString("dd/MM/yyyy")
        End Get
        Set(ByVal strValue As String)
            dtmmFacturaElectronicaEmisionDocumento = CDate(strValue)
        End Set
    End Property

    '====================================================================
    ' Name       : strProveedorRazonSocial
    ' Description: Nombre del Proveedor con Facturas Pendientes
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strProveedorRazonSocial() As String
        Get
            Return strmProveedorRazonSocial
        End Get
        Set(ByVal strValue As String)
            strmProveedorRazonSocial = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intFacturaElectronicaId
    ' Description: Identificador de la Factura Electronica
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intFacturaElectronicaId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intFacturaElectronicaId")) Then
                Return CInt(Request.QueryString("intFacturaElectronicaId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Genera el Record Browser con los articulos de la 
    '              Factura pendiente por confirmar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRecordBrowserHTML() As String
        Get
            ' Declaración e inicialización de las variables locales
            Dim strTargetURL As String = ""
            Dim objArticulos As Array = Nothing
            Dim strRegistroArticulo As String() = Nothing
            Dim strTipoEstadoFacturaElectronicaCompraDirectaNombreId_1 As String = "POR CONFIRMAR"
            Dim strTipoEstadoFacturaElectronicaCompraDirectaNombreId_2 As String = "GENERADA CON ERROR"

            Dim intPosicionInicial As Integer = 0
            Dim intElementos As Integer = 0

            ' Consultamos los articulos de la factura pendiente por Confirmar

            If (intProveedorId > 0) AndAlso (intFacturaElectronicaId > 0) Then

                objArticulos = clsConcentrador.clsSucursal.clsMercancia.clsCompras.clsFacturaElectronica.strBuscarDetalleFacturaElectronica(intCompaniaId, intSucursalId, intFacturaElectronicaId, intProveedorId, CDate("01/01/1900"), strTipoEstadoFacturaElectronicaCompraDirectaNombreId_1, strTipoEstadoFacturaElectronicaCompraDirectaNombreId_2, intPosicionInicial, intElementos, strCadenaConexion)

                ' Verificamos si se encontró información en la consulta
                If IsArray(objArticulos) AndAlso (objArticulos.Length > 0) Then

                    '0btenemos el primer registro de la consulta para los siguientes campos
                    strRegistroArticulo = DirectCast(objArticulos.GetValue(0), String())

                    ' Obtenemos el nombre del proveedor
                    strProveedorRazonSocial = strRegistroArticulo(8)

                    intRemisionCompraDirectaFolio = CInt(strRegistroArticulo(3))
                    strRemisionCompraDirectaNumeroDocumento = CStr(strRegistroArticulo(4))

                    ' Obtenemos el numero de factura
                    strFacturaElectronicaNumero = strRegistroArticulo(5)

                    ' Obtenemos el numero de Pedido
                    intFacturaElectronicaPedido = CInt(strRegistroArticulo(6))

                    ' Obtenemos la fecha de la factura
                    dtmFacturaElectronicaEmisionDocumento = strRegistroArticulo(7)



                    ' Generamos el Navegador de Registros
                    Return clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaDetalleFacturaElectronica", objArticulos, 1, objArticulos.Length, strTargetURL))

                Else
                    Return ""
                End If
            Else
                Return ""
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : Page_Load
    ' Description: Evento Page_Load
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    '====================================================================
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If
    End Sub

End Class
