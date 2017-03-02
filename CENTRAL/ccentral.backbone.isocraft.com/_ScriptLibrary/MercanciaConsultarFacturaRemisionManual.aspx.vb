Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration

Public Class MercanciaConsultarFacturaRemisionManual
    Inherits System.Web.UI.Page

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

    Dim strmMensaje As String
    Dim strmRecordBrowserHTML As String = ""

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
    ' Name       : rdoFiltroConsulta
    ' Description: Valor del radio boton
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property rdoFiltroConsulta() As String
        Get
            If Len(Request.QueryString("rdoFiltroConsulta")) > 0 Then
                Return Request.QueryString("rdoFiltroConsulta")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : rdoRangoConsulta
    ' Description: Valor del radio boton
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property rdoRangoConsulta() As String
        Get
            If Not IsNothing(Request.QueryString("rdoRangoConsulta")) Then
                Return Request.QueryString("rdoRangoConsulta")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : rdoRangoConsulta
    ' Description: Valor del radio boton
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property rdoEdoConsulta() As String
        Get
            If Not IsNothing(Request.QueryString("rdoEdoConsulta")) Then
                Return Request.QueryString("rdoEdoConsulta")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : rdoOrdenConsulta
    ' Description: Valor del radio boton
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property rdoOrdenConsulta() As String
        Get
            If Not IsNothing(Request.QueryString("rdoOrdenConsulta")) Then
                Return Request.QueryString("rdoOrdenConsulta")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strConsultar
    ' Description: Valor del parámetro strCmd
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strConsultar() As String
        Get
            Return Request.QueryString("strConsultar")
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
    ' Description: Valor del parámetro strCmd
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return Request.QueryString("strCmd")
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

    '====================================================================
    ' Name       : strRegistrosRecordBrowser
    ' Description: Registros en el RecordBrowser
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public ReadOnly Property strRegistrosRecordBrowser() As String
        Get
            If Len(strRecordBrowserHTML) > 0 Then
                Return strRecordBrowserHTML.Length.ToString
            Else
                Return ""
            End If
        End Get
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        strRecordBrowserHTML = ""

        If strConsultar = "1" Then

            Select Case rdoFiltroConsulta
                Case "1"

                    'Remisiones
                    strRecordBrowserHTML = strRecordBrowserHTMLRemisiones()

                Case "2"

                    'Facturas
                    strRecordBrowserHTML = strRecordBrowserHTMLFacturas()
            End Select

        End If

    End Sub

    Private Function strRecordBrowserHTMLFacturas() As String

        Dim objArrayFacturasManuales As Array = Nothing

        Dim strRecordBrowseComplemento As StringBuilder
        Dim strRecordBrowserConsulta As String = ""
        Dim strTargetURL As String = "MercanciaDetalleFacturaManual.aspx?cmdConsultar=Consultar&rdoFiltroConsulta=" & rdoFiltroConsulta.ToString & "&rdoRangoConsulta=" & rdoRangoConsulta.ToString & "&rdoOrdenConsulta=" & rdoOrdenConsulta.ToString & "&"

        Dim intMesBusqueda As Integer = 0
        Dim intOrdenBusqueda As Integer = 0
        Dim blnEdoConsulta As Boolean = False


        If CInt(rdoRangoConsulta) = 1 Then
            intMesBusqueda = Date.Now.Month
        Else
            intMesBusqueda = Date.Now.AddMonths(-1).Month
        End If

        intOrdenBusqueda = CInt(rdoOrdenConsulta)

        strRecordBrowseComplemento = New StringBuilder
        strRecordBrowserConsulta = ""

        If rdoEdoConsulta = "1" Then
            blnEdoConsulta = True
        Else
            blnEdoConsulta = False
        End If

        'Consulta las Facturas Manuales
        objArrayFacturasManuales = clsConcentrador.clsSucursal.clsMercancia.clsFacturaManual.strBuscarFacturaRemisionManual(0, intCompaniaId, intSucursalId, 0, intMesBusqueda, intOrdenBusqueda, False, blnEdoConsulta, 0, 0, strCadenaConexion)

        ' Validamos que la respuesta sea un Arreglo Valido
        If IsArray(objArrayFacturasManuales) AndAlso objArrayFacturasManuales.Length > 0 Then
            ' Generamos el Navegador de Registros                
            strRecordBrowserConsulta = clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaConsultarFacturaManual", objArrayFacturasManuales, 1, objArrayFacturasManuales.Length, strTargetURL))
        Else
            strMensaje = "No hay información para la consulta seleccionada "
        End If

        If strRecordBrowserConsulta.Length > 0 Then

            Dim strTemp As String = ""
            strTemp = "<br><span class=\|txsubtitulo\|><img src=\|../static/images/bullet_subtitulos.gif\| width=\|17\| height=\|11\| align=\|absmiddle\|></span><br>"
            strTemp = Replace(strTemp, "|", """")

            strRecordBrowserConsulta = Replace(strRecordBrowserConsulta, strTemp, "")

            strRecordBrowseComplemento.Append("<div id='ToPrintHtmContenido'>")
            strRecordBrowseComplemento.Append(strRecordBrowserConsulta)
            strRecordBrowseComplemento.Append("</div>")
            strRecordBrowseComplemento.Append("<br>")
            strRecordBrowseComplemento.Append("<input name='cmdOtra'     type='button' class='boton' value='OtraConsulta' onclick='return cmdOtra_onclick()'> &nbsp;&nbsp;&nbsp;")
            strRecordBrowseComplemento.Append("<input name='cmdImprimir' type='button' class='boton' value='ImprimirConsulta' onclick='return cmdImprimir_onclick()'> ")
        End If

        Return strRecordBrowseComplemento.ToString


    End Function

    Private Function strRecordBrowserHTMLRemisiones() As String

        Dim objArrayRemisionesManuales As Array = Nothing

        Dim strRecordBrowseComplemento As StringBuilder
        Dim strRecordBrowserConsulta As String = ""
        Dim strTargetURL As String = "MercanciaDetalleRemisionManual.aspx?cmdConsultar=Consultar&rdoFiltroConsulta=" & rdoFiltroConsulta.ToString & "&rdoRangoConsulta=" & rdoRangoConsulta.ToString & "&rdoOrdenConsulta=" & rdoOrdenConsulta.ToString & "&"

        Dim intMesBusqueda As Integer = 0
        Dim intOrdenBusqueda As Integer = 0
        Dim blnEdoConsulta As Boolean = False


        If CInt(rdoRangoConsulta) = 1 Then
            intMesBusqueda = Date.Now.Month
        Else
            intMesBusqueda = Date.Now.AddMonths(-1).Month
        End If

        intOrdenBusqueda = CInt(rdoOrdenConsulta)

        strRecordBrowseComplemento = New StringBuilder
        strRecordBrowserConsulta = ""

        If rdoEdoConsulta = "1" Then
            blnEdoConsulta = True
        Else
            blnEdoConsulta = False
        End If

        'Consulta las Facturas Manuales
        objArrayRemisionesManuales = clsConcentrador.clsSucursal.clsMercancia.clsFacturaManual.strBuscarFacturaRemisionManual(0, intCompaniaId, intSucursalId, 0, intMesBusqueda, intOrdenBusqueda, True, blnEdoConsulta, 0, 0, strCadenaConexion)

        ' Validamos que la respuesta sea un Arreglo Valido
        If IsArray(objArrayRemisionesManuales) AndAlso objArrayRemisionesManuales.Length > 0 Then
            ' Generamos el Navegador de Registros                
            strRecordBrowserConsulta = clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaConsultarRemisionManual", objArrayRemisionesManuales, 1, objArrayRemisionesManuales.Length, strTargetURL))
        Else
            strMensaje = "No hay información para la consulta seleccionada "
        End If

        If strRecordBrowserConsulta.Length > 0 Then

            Dim strTemp As String = ""
            strTemp = "<br><span class=\|txsubtitulo\|><img src=\|../static/images/bullet_subtitulos.gif\| width=\|17\| height=\|11\| align=\|absmiddle\|></span><br>"
            strTemp = Replace(strTemp, "|", """")

            strRecordBrowserConsulta = Replace(strRecordBrowserConsulta, strTemp, "")

            strRecordBrowseComplemento.Append("<div id='ToPrintHtmContenido'>")
            strRecordBrowseComplemento.Append(strRecordBrowserConsulta)
            strRecordBrowseComplemento.Append("</div>")
            strRecordBrowseComplemento.Append("<br>")
            strRecordBrowseComplemento.Append("<input name='cmdOtra'     type='button' class='boton' value='OtraConsulta' onclick='return cmdOtra_onclick()'> &nbsp;&nbsp;&nbsp;")
            strRecordBrowseComplemento.Append("<input name='cmdImprimir' type='button' class='boton' value='ImprimirConsulta' onclick='return cmdImprimir_onclick()'> ")
        End If

        Return strRecordBrowseComplemento.ToString

    End Function

End Class
