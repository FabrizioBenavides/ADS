Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration

Public Class clsMercanciaConsultarArchivoDeEnvios
    Inherits System.Web.UI.Page

    'Variables globales
    Private strmMensaje As String = ""
    Private dtmmFechaInicio As Date
    Private dtmmFechaFin As Date
    Private strmCriterioConsulta As String = ""
    Private strmRecordBrowserHTML As String = ""

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
    ' Name       : strFechaConsultaInicio
    ' Description: Fecha Inicial de la consulta
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFechaConsultaInicio() As String
        Get
            If Not IsNothing(Request.Form("txtFechaConsultaInicio")) Then
                Return Request.Form("txtFechaConsultaInicio")
            Else
                Return Now.ToString("dd/MM/yyyy")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strFechaConsultaFin
    ' Description: Fecha Fin de la consulta
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFechaConsultaFin() As String
        Get
            If Not IsNothing(Request.Form("txtFechaConsultaFin")) Then
                Return Request.Form("txtFechaConsultaFin")
            Else
                Return Now.ToString("dd/MM/yyyy")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : rdoCriterioConsulta
    ' Description: Criterio de Consulta : Cancelada | Enviada | Cancelada y Enviadas
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property rdoCriterioConsulta() As String
        Get
            Return Request.Form("rdoCriterioConsulta")
        End Get
    End Property

    '====================================================================
    ' Name       : strRangoConsulta
    ' Description: Rango de Consulta : Mes Actual | Mes anterior | Rango de Fechas
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRangoConsulta() As String
        Get
            Return Request.Form("rdoRangoConsulta")
        End Get
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        ' Declaración e inicialización de las variables locales
        Dim strCriterioConsulta As String
        Dim dtmFechaInicial As Date
        Dim dtmFechaFinal As Date
        Dim dtmFechaActual As Date

        'Variables para generar el record browser
        Dim strTargetURL As String = "MercanciaDetalleEnvioTransferencias.aspx?"
        Dim objTransferencias As Array = Nothing
        Dim intPosicionInicial As Integer = 0
        Dim intElementos As Integer = 0



        If Len(Request.Form("cmdConsultar")) > 0 Then

            'De acuerdo al boton seleccionado obtiene el criterio de consulta

            Select Case (Request.Form("rdoCriterioConsulta"))
                Case "1"
                    strCriterioConsulta = "CANCELADA"
                Case "2"
                    strCriterioConsulta = "ENVIADA"
                Case "3"
                    strCriterioConsulta = "CONFIRMADA"
                Case "4"
                    strCriterioConsulta = "TODAS"
            End Select

            'De acuerdo al boton seleccionado obtiene el rango de consulta
            Select Case (Request.Form("rdoRangoConsulta"))
                Case "1" 'Mes Actual
                    dtmFechaActual = Date.Now

                    dtmFechaInicial = CDate(dtmFechaActual.Month.ToString & "/" & "01" & "/" & dtmFechaActual.Year)
                    dtmFechaFinal = CDate(dtmFechaActual.Month.ToString & "/" & dtmFechaActual.DaysInMonth(dtmFechaActual.Year, dtmFechaActual.Month) & "/" & dtmFechaActual.Year)

                Case "2" 'Mes Anterior
                    dtmFechaActual = Date.Now.AddMonths(-1)

                    dtmFechaInicial = CDate(dtmFechaActual.Month & "/" & "01" & "/" & dtmFechaActual.Year)
                    dtmFechaFinal = CDate(dtmFechaActual.Month & "/" & dtmFechaActual.DaysInMonth(dtmFechaActual.Year, dtmFechaActual.Month) & "/" & dtmFechaActual.Year)

                Case "3" 'Rango de Fechas
                    dtmFechaInicial = CDate(clsCommons.strDMYtoMDY(strFechaConsultaInicio))
                    dtmFechaFinal = CDate(clsCommons.strDMYtoMDY(strFechaConsultaFin))
            End Select

            ' Consultamos las transferencias
            objTransferencias = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.strBuscarArchivo(intCompaniaId, intSucursalId, strCriterioConsulta, dtmFechaInicial, dtmFechaFinal, intPosicionInicial, intElementos, strCadenaConexion)

            ' Verificamos si se encontró información en la consulta.

            If IsArray(objTransferencias) AndAlso (objTransferencias.Length > 0) Then
                '     Generamos el Navegador de Registros
                strRecordBrowserHTML = clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaConsultarArchivoDeEnvios", objTransferencias, 1, objTransferencias.Length, strTargetURL))

            Else
                strMensaje = "No existen transferencias con el criterio elegido"
                strRecordBrowserHTML = ""
            End If

        End If

    End Sub

End Class
