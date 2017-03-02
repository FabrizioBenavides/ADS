Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration

Public Class MercanciaDetalleEnvioTransferencias
    Inherits System.Web.UI.Page

    'Variables globales
    Private strmMensaje As String = ""
    Private strmCriterioConsulta As String = ""
    Private strmRecordBrowserHTML As String = ""
    Private intmEstadoTransferenciaFolio As String = "0"
    Private intmTransferenciaNumeroOrden As String = "0"
    Private dtmmTransferenciaRegistro As String
    Private dtmmEstadoTransferenciaRegistro As String
    Private strmMotivoTransferencia As String
    Private strmSucursalDestino As String

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
    ' Description: Valor que tomara la variable strmCadenaConexion
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
    ' Description: Fecha de Emision de la Factura Electronica Consultada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '====================================================================  
    Public Property strMensaje() As String
        Get
            Return strmMensaje
        End Get
        Set(ByVal Value As String)
            strmMensaje = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Identificador del comando
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Not IsNothing(Request.QueryString("strCmd")) Then
                Return Request.QueryString("strCmd")
            Else
                Return ""
            End If
        End Get
    End Property
    '====================================================================
    ' Name       : intTransferenciaId
    ' Description: Identificador de la Transferencia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTransferenciaId() As String
        Get
            If Not IsNothing(Request.QueryString("intTransferenciaId")) Then
                Return Request.QueryString("intTransferenciaId")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strEstadoTransferencia
    ' Description: Identificador de la Transferencia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strEstadoTransferencia() As String
        Get
            If Not IsNothing(Request.QueryString("strEstadoTransferencia")) Then
                Return Request.QueryString("strEstadoTransferencia")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intEstadoTransferenciaFolio
    ' Description: Fecha de Emision de la Factura Electronica Consultada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================  
    Public Property intEstadoTransferenciaFolio() As String
        Get
            Return intmEstadoTransferenciaFolio
        End Get
        Set(ByVal intValue As String)
            intmEstadoTransferenciaFolio = intValue
        End Set
    End Property
    '====================================================================
    ' Name       : intTransferenciaNumeroOrden
    ' Description: Numero de orden de la transferencia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================  
    Public Property intTransferenciaNumeroOrden() As String
        Get
            Return intmTransferenciaNumeroOrden
        End Get
        Set(ByVal intValue As String)
            intmTransferenciaNumeroOrden = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : dtmTransferenciaRegistro
    ' Description: Fecha de Emision de la transferencia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '====================================================================  
    Public Property dtmTransferenciaRegistro() As String
        Get
            Return dtmmTransferenciaRegistro
        End Get
        Set(ByVal dtmValue As String)
            dtmmTransferenciaRegistro = dtmValue
        End Set
    End Property

    '====================================================================
    ' Name       : dtmEstadoTransferenciaRegistro
    ' Description: Fecha de confirmacion de la transferencia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '====================================================================  
    Public Property dtmEstadoTransferenciaRegistro() As String
        Get
            Return dtmmEstadoTransferenciaRegistro
        End Get
        Set(ByVal dtmValue As String)
            dtmmEstadoTransferenciaRegistro = dtmValue
        End Set
    End Property

    '====================================================================
    ' Name       : strMotivoTransferencia
    ' Description: identificador y Descripcion del motivo de la transferencia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
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
    ' Name       : strSucursalDestino
    ' Description: Numero y Nombre de la sucursal destino
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================  
    Public Property strSucursalDestino() As String
        Get
            Return strmSucursalDestino
        End Get
        Set(ByVal strValue As String)
            strmSucursalDestino = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: RecordBrowser de Recibos
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRecordBrowserHTML() As String
        Get
            Return strmRecordBrowserHTML
        End Get
        Set(ByVal Value As String)
            strmRecordBrowserHTML = Value
        End Set

    End Property

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        If strCmd = "Ver" Then

            'Generamos el HTML para la presentacion del detalle de la transferencia

            'Variables para el record Browser
            Dim objDetalleTransferencia As Array = Nothing
            Dim objDetalleOrden As Array = Nothing
            Dim intPosicionInicial As Integer = 0
            Dim intElementos As Integer = 0
            Dim strTargetURL As String = ""
            Dim strDetalleTransferencia As String()
            Dim strPad As Char = "0"c

            'Consultamos el Detalle de Transferencia

            objDetalleTransferencia = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.strBuscar(intCompaniaId, intSucursalId, CInt(intTransferenciaId), strEstadoTransferencia, True, intPosicionInicial, intElementos, strCadenaConexion)

            If IsArray(objDetalleTransferencia) AndAlso objDetalleTransferencia.Length > 0 Then

                'Obtenemos el detalle de la transferencia
                strDetalleTransferencia = DirectCast(objDetalleTransferencia.GetValue(0), String())

                intEstadoTransferenciaFolio = strDetalleTransferencia(3).ToString
                intTransferenciaNumeroOrden = strDetalleTransferencia(1).ToString
                dtmTransferenciaRegistro = clsCommons.strFormatearFechaPresentacion(strDetalleTransferencia(2).ToString)
                dtmEstadoTransferenciaRegistro = clsCommons.strFormatearFechaPresentacion(strDetalleTransferencia(4).ToString)
                strMotivoTransferencia = strDetalleTransferencia(5).ToString.PadLeft(2, strPad) + " " + strDetalleTransferencia(6)
                strSucursalDestino = CStr(strDetalleTransferencia(10)) & "-" & CStr(strDetalleTransferencia(11)) & " " & clsCommons.strFormatearDescripcion(CStr(strDetalleTransferencia(12)))

            End If


            'Consultamos el detalle de la orden para generar el Record Browser
            objDetalleOrden = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.strBuscarDetalle(intCompaniaId, intSucursalId, CInt(intTransferenciaId), strEstadoTransferencia, intPosicionInicial, intElementos, strCadenaConexion)

            If IsArray(objDetalleOrden) AndAlso objDetalleOrden.Length > 0 Then
                'Generamos el record browser
                strRecordBrowserHTML = clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaDetalleEnvioTransferencias", objDetalleOrden, 1, objDetalleOrden.Length, strTargetURL))
            Else
                strMensaje = "No existe detalle de la transferencia"
                strRecordBrowserHTML = ""

            End If

        Else

            'Redireccionamos a la página padre
            Call Response.Redirect("MercanciaConsultarArchivoDeEnvios.aspx")

        End If

    End Sub

End Class
