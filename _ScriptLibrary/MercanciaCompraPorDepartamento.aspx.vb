Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business
Imports System.Text
Imports System.Configuration

Public Class clsMercanciaCompraporDepartamento
    Inherits System.Web.UI.Page

    Private Const intElementos As Integer = 20

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
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalNombre() As String
        Get
            Return clsCommons.strReadCookie("strSucursalNombre", "", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del Usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)
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
    ' Description: Identificador del comando a realizar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Request.QueryString("strCmd") <> "" Then
                Return Request.QueryString("strCmd")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intMesBusqueda
    ' Description: Identificador del mes a consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intMesBusqueda() As Integer
        Get
            If Request.Form("cboMesConsulta") <> "" Then
                Return CType(Request.Form("cboMesConsulta"), Integer)
            Else
                If Request.QueryString("cboMesConsulta") <> "" Then
                    Return CType(Request.QueryString("cboMesConsulta"), Integer)
                Else
                    Return 0
                End If
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strGeneraListaMeses
    ' Description: Lista de los meses a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================

    Public Function strGeneraListaMeses(ByVal strElementName As String) As String
        Dim objListaFormaPago As Array = Nothing
        Dim strcboMeses As StringBuilder
        Dim dtmInicio As Date = Now
        Dim intMesInicial As Double = 0
        Dim intMesFinal As Double = 5
        Dim intMes As Double = 0
        Dim intAnio As Double = 0
        Dim strMesNuevo As String = ""
        Dim strFecha As String = ""
        Dim strFechaMes As String

        strcboMeses = New StringBuilder

        strcboMeses.Append("document.forms[0].elements['" & strElementName & "'].options[")
        strcboMeses.Append("0] = new Option(""" & "Seleccione un Mes" & """,""" & "0" & """);" & vbCrLf)

        ' Creamos un ciclo para formar la lista de los meses disponibles a consultar (6 meses hacia atrás)

        For intMesInicial = 0 To intMesFinal

            intMes = DateAdd(DateInterval.Month, -intMesInicial, dtmInicio).Month
            intAnio = DateAdd(DateInterval.Month, -intMesInicial, dtmInicio).Year

            If intMes < 10 Then
                strFechaMes = "0" + intMes.ToString + "/01/" + intAnio.ToString
            Else
                strFechaMes = intMes.ToString + "/01/" + intAnio.ToString
            End If


            strMesNuevo = clsCommons.strNombreMes(CDate(strFechaMes)) + " , " + intAnio.ToString

            strcboMeses.Append("document.forms[0].elements['" & strElementName & "'].options[")
            strcboMeses.Append(intMesInicial + 1 & "] = new Option(""" & strMesNuevo & """,""" & intMes.ToString & """);" & vbCrLf)

            If intMes = intMesBusqueda Then
                strcboMeses.Append("document.forms[0].elements['" & strElementName & "'].options[" & intMesInicial + 1 & "].selected = true;" & vbCrLf)
            End If



        Next

        Return strcboMeses.ToString

    End Function

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Record browser navegador de los empleados de la sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRecordBrowserHTML() As String
        Get
            ' Declaración e inicialización de las variables locales
            Dim strbldRecordBrowserHTML As StringBuilder
            Dim objCompraPorDepartamento As Array = Nothing
            Dim strCompraPorDepartamento As String()
            Dim strTargetURL As String = "MercanciaCompraporDepartamento.aspx?"

            ' Variables para los totales
            Dim fltTotalCompras As Double : fltTotalCompras = 0
            Dim fltTotalPorcentaje As Double : fltTotalPorcentaje = 0

            strbldRecordBrowserHTML = New StringBuilder

            ' Busco los empelados de la sucursal
            objCompraPorDepartamento = clsConcentrador.clsSucursal.clsMercancia.strBuscarCompraporDepartamento(intCompaniaId, intSucursalId, intMesBusqueda, 0, 0, strCadenaConexion)

            If IsArray(objCompraPorDepartamento) AndAlso objCompraPorDepartamento.Length > 0 Then
                ' Generamos el Navegador de Registros
                strbldRecordBrowserHTML.Append(clsRecordBrowser.strGetHTML("MercanciaCompraporDepartamento", objCompraPorDepartamento, 1, intElementos, strTargetURL))

                For Each strCompraPorDepartamento In objCompraPorDepartamento
                    fltTotalCompras += CDbl(strCompraPorDepartamento(2))
                    fltTotalPorcentaje += CDbl(strCompraPorDepartamento(4))
                Next

                ' Imprimimos los totales

                strbldRecordBrowserHTML.Append("<br><table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"">")
                strbldRecordBrowserHTML.Append("<tr class=""trtitulos"">")
                strbldRecordBrowserHTML.Append("<th width=""182"" class=""rayita"">&nbsp;</th>")
                strbldRecordBrowserHTML.Append("<th width=""63"" class=""rayita"">Total</th>")
                strbldRecordBrowserHTML.Append("<th width=""120"" class=""rayita"">$ " + Format(fltTotalCompras, "#,###,###.00") + "</th>")
                strbldRecordBrowserHTML.Append("<th width=""103"" class=""rayita"">&nbsp;</th>")
                strbldRecordBrowserHTML.Append("<th width=""100"" class=""rayita"">" + Format(fltTotalPorcentaje, "#,###,###.00") + "%</th>")
                strbldRecordBrowserHTML.Append("</tr></table>")

                ' Imprimimos los botones de funciones

                strbldRecordBrowserHTML.Append("<br><br><input name=""btnSalir"" type=""button"" class=""boton"" value=""Salir"" onclick=""return cmdRegresar_onClick();"">")
                strbldRecordBrowserHTML.Append("&nbsp;&nbsp;&nbsp; <input name=""btnImprimir"" type=""button"" class=""boton"" value=""Imprimir"" oncLick=""return cmdImprimir_onclick();"">")
                strbldRecordBrowserHTML.Append("&nbsp;&nbsp;&nbsp; <input name=""boton222"" type=""button"" class=""boton"" value=""Ver presupuesto de gastos"" onclick=""return cmdPresupuesto_onClick();""><br><br>")

            End If

            Return clsCommons.strGenerateJavascriptString(strbldRecordBrowserHTML.ToString)
        End Get

    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

    End Sub

End Class
