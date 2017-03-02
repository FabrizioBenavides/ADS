Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration

Public Class clsMercanciaDocumentosRecuperados
    Inherits System.Web.UI.Page
    Public strmTipoDocumentosRecuperados As String
    Public strmRangoDeConsulta As String

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.diagnostics.debuggerstepthrough()> Private Sub InitializeComponent()

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
    ' Name       : strCmd
    ' Description: string de Comandos de control
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
    ' Name       : strRdoRangoDeConsulta
    ' Description: string 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRdoRangoDeConsulta() As String
        Get
            If Not IsNothing(Request.Form("rdoRangoDeConsulta")) Then
                Return Request.Form("rdoRangoDeConsulta")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strRdoQueDeseaRecuperar
    ' Description: string 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRdoQueDeseaRecuperar() As String
        Get
            If Not IsNothing(Request.Form("RdoQueDeseaRecuperar")) Then
                Return Request.Form("RdoQueDeseaRecuperar")
            Else
                Return ""
            End If
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
    ' Name       : strRdoOrdenarPor
    ' Description: valor del campo RdoOrdenarPor
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRdoOrdenarPor() As String
        Get
            Dim strTemporal As String
            strTemporal = Trim(Request.Form("rdoOrdenarPor"))
            If strTemporal.Equals("") Then
                Return ""
            Else
                Return strTemporal
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

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

    End Sub
    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Generamos Recordbrowser
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String
        Dim strTemp As String

        Select Case Trim(Request.Form("rdoQueDeseaRecuperar"))
            Case "1" 'Remisiones
                strRecordBrowserHTML = strRecordBrowserHTMLRemision()
                strmTipoDocumentosRecuperados = "Remisiones"
            Case "2" 'Facturas
                strRecordBrowserHTML = strRecordBrowserHTMLFactura()
                strmTipoDocumentosRecuperados = "Facturas"
            Case Else
                strRecordBrowserHTML = ""
                strmTipoDocumentosRecuperados = ""
        End Select

        If strRecordBrowserHTML <> "" Then
            strTemp = "<br><span class=\|txsubtitulo\|><img src=\|../static/images/bullet_subtitulos.gif\| width=\|17\| height=\|11\| align=\|absmiddle\|></span><br>"
            strTemp = Replace(strTemp, "|", """")
            strRecordBrowserHTML = Replace(strRecordBrowserHTML, strTemp, "")
        End If
        Return strRecordBrowserHTML
    End Function
    '====================================================================
    ' Name       : strRecordBrowserHTMLRemision
    ' Description: Generamos Recordbrowser
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTMLRemision() As String
        Dim objDataArray As Array = Nothing
        Dim objRegistro As String() = Nothing
        Dim strTargetURL As String
        Dim intTotalElementos As Integer

        Dim intMes, intOrden, intTipoEstadoId As Integer
        Dim dtmTemporal As Date

        If Trim(Request.Form("rdoRangoDeConsulta")) = "1" Then
            '1 Mes Actual
            strmRangoDeConsulta = "Mes Actual"
            dtmTemporal = CDate(clsCommons.strGetCustomDateTime("MM/dd/yyyy"))
            intMes = dtmTemporal.Month
        ElseIf Trim(Request.Form("rdoRangoDeConsulta")) = "2" Then
            '2 Mes Anterior
            strmRangoDeConsulta = "Mes Anterior"
            dtmTemporal = CDate(clsCommons.strGetCustomDateTime("MM/dd/yyyy"))
            dtmTemporal = dtmTemporal.AddMonths(-1)
            intMes = dtmTemporal.Month
        End If

        Select Case Trim(Request.Form("rdoOrdenarPor"))
            Case "1" 'Numero del proveedor
                intOrden = 1
            Case "2" 'Numero de factura/remision
                intOrden = 2
            Case "3" 'Nota (folio de confirmacion)
                intOrden = 3
            Case "4" 'Fecha de confirmacion
                intOrden = 4
        End Select

        intTipoEstadoId = 2 '2 Valor fijo, para ver las confirmadas

        ' Redireccionamos hacia la página destino
        strTargetURL = "MercanciaDetalleRemisionConfirmada.aspx?"

        objDataArray = clsConcentrador.clsSucursal.clsMercancia.clsRemisionElectronica.strBuscar(intCompaniaId, intSucursalId, intMes, intOrden, intTipoEstadoId, 0, 0, strCadenaConexion)

        ' Verificamos que sea un arreglo valido 
        If IsArray(objDataArray) AndAlso (objDataArray.Length > 0) Then

            strRecordBrowserHTMLRemision = clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaDocumentosRecuperadosR", objDataArray, 1, objDataArray.Length, strTargetURL))
            Return strRecordBrowserHTMLRemision
        End If

    End Function



    '====================================================================
    ' Name       : strRecordBrowserHTMLFactura
    ' Description: Generamos Recordbrowser
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTMLFactura() As String
        Dim objDataArray As Array = Nothing
        Dim strTargetURL As String
        Dim intTotalElementos As Integer

        Dim intMes, intOrden, intTipoEstadoId As Integer
        Dim dtmTemporal As Date

        If Trim(Request.Form("rdoRangoDeConsulta")) = "1" Then
            '1 Mes Actual
            strmRangoDeConsulta = "Mes Actual"
            dtmTemporal = CDate(clsCommons.strGetCustomDateTime("MM/dd/yyyy"))
            intMes = dtmTemporal.Month
        ElseIf Trim(Request.Form("rdoRangoDeConsulta")) = "2" Then
            '2 Mes Anterior
            strmRangoDeConsulta = "Mes Anterior"
            dtmTemporal = CDate(clsCommons.strGetCustomDateTime("MM/dd/yyyy"))
            dtmTemporal = dtmTemporal.AddMonths(-1)
            intMes = dtmTemporal.Month
        End If

        Select Case Trim(Request.Form("rdoOrdenarPor"))
            Case "1" 'Numero del proveedor
                intOrden = 1
            Case "2" 'Numero de factura/remision
                intOrden = 2
            Case "3" 'Nota (folio de confirmacion)
                intOrden = 3
            Case "4" 'Fecha de confirmacion
                intOrden = 4
        End Select

        intTipoEstadoId = 2 '2 Valor fijo, para ver las confirmadas

        ' Redireccionamos hacia la página destino
        strTargetURL = "MercanciaDetalleFacturaConfirmada.aspx?"

        objDataArray = clsConcentrador.clsSucursal.clsMercancia.clsFacturaElectronica.strBuscar(intCompaniaId, intSucursalId, intMes, intOrden, intTipoEstadoId, 0, 0, strCadenaConexion)

        ' Verificamos que sea un arreglo valido 
        If IsArray(objDataArray) AndAlso (objDataArray.Length > 0) Then

            strRecordBrowserHTMLFactura = clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaDocumentosRecuperadosF", objDataArray, 1, objDataArray.Length, strTargetURL))
            Return strRecordBrowserHTMLFactura

        End If

    End Function
End Class
