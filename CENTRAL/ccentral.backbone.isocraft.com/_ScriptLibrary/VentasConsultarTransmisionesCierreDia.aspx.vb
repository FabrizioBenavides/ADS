Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration

Public Class VentasConsultarTransmisionesCierreDia
    Inherits System.Web.UI.Page

    'Declaracion de variables globales
    Private strmRecordBrowserHTML As String = Nothing
    Private strmMensaje As String

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
    ' Description: Fecha Final de la consulta
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

    Public Property strMensaje() As String
        Get
            Return strmMensaje
        End Get
        Set(ByVal Value As String)
            strmMensaje = Value
        End Set
    End Property
    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: RecordBrowser de transmisiones
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


        'Declaración de variables locales

        'Consulta
        Dim dtmFechaInicial As Date
        Dim dtmFechaFinal As Date
        Dim objTransmisiones As Array = Nothing

        'Record Browser
        Dim objRegistroDiaCierre As String()
        Dim strDiaCierreHTML As StringBuilder
        Dim intConsecutivo As Integer
        Dim strColorRegistro As String
        Dim dtmTransmsionPoliza As String
        Dim dtmTransmisionVentaDiaria As String
        Dim dtmTransmisionBonos As String
        Dim dtmTransmisionRecetas As String

        'Inicializamos variables
        strDiaCierreHTML = New StringBuilder
        objRegistroDiaCierre = Nothing
        intConsecutivo = 0
        dtmTransmsionPoliza = Nothing
        dtmTransmisionVentaDiaria = Nothing
        dtmTransmisionBonos = Nothing
        dtmTransmisionRecetas = Nothing

        If Len(Request.Form("cmdConsultar")) > 0 Then

            'Obtengo rango de consulta seleccionado
            Select Case strRangoConsulta
                Case "1"  'Día de hoy
                    dtmFechaInicial = CDate(clsCommons.strDMYtoMDY(Date.Now.ToString("dd/MM/yyyy")))
                    dtmFechaFinal = CDate(clsCommons.strDMYtoMDY(Date.Now.ToString("dd/MM/yyyy")))
                Case "2"  'Día de ayer
                    dtmFechaInicial = CDate(clsCommons.strDMYtoMDY(Date.Now.AddDays(-1).ToString("dd/MM/yyyy")))
                    dtmFechaFinal = CDate(clsCommons.strDMYtoMDY(Date.Now.AddDays(-1).ToString("dd/MM/yyyy")))

                Case "3" 'Rango de fechas
                    dtmFechaInicial = CDate(clsCommons.strDMYtoMDY(strFechaConsultaInicio))
                    dtmFechaFinal = CDate(clsCommons.strDMYtoMDY(strFechaConsultaFin))
            End Select

            'Realizo consulta para cada una de las transmisiones
            objTransmisiones = clsTransmision.strEjecutarBuscarTransmisionesCierreDia(intCompaniaId, intSucursalId, dtmFechaInicial, dtmFechaFinal, 0, 0, strCadenaConexion)

            'Valido si encontró información
            If IsArray(objTransmisiones) AndAlso (objTransmisiones.Length > 0) Then

                ' Pintamos de los titulos de la tabla
                Call strDiaCierreHTML.Append("<table width='98%' height='33' border=0 cellpadding=0 cellspacing=0>")
                Call strDiaCierreHTML.Append("<td><span class=txsubtitulo><img src='../static/images/bullet_subtitulos.gif' width='17' height='11' align='absMiddle'>Transmisiones de Cierre de Dia</span></td>")
                Call strDiaCierreHTML.Append("</Table>")
                Call strDiaCierreHTML.Append("<table cellspacing='0' cellpadding='0' width='583' border='0'>")
                Call strDiaCierreHTML.Append("<tr class='trtitulos'>")
                Call strDiaCierreHTML.Append("<th class='rayita' width='150'>Polizas</th>")
                Call strDiaCierreHTML.Append("<th class='rayita' width='150'>VentaDiaria</th>")
                Call strDiaCierreHTML.Append("<th class='rayita' width='150'>Bonos</th>")
                Call strDiaCierreHTML.Append("<th class='rayita' width='150'>RecetasCredito</th></tr>")

                intConsecutivo += 1
                For Each objRegistroDiaCierre In objTransmisiones
                    If (intConsecutivo Mod 2) <> 0 Then
                        strColorRegistro = "'tdceleste'"
                    Else
                        strColorRegistro = "'tdblanco'"
                    End If


                    If objRegistroDiaCierre(1).ToString = "1/1/1900" Then
                        dtmTransmsionPoliza = " -----  "
                    Else
                        dtmTransmsionPoliza = objRegistroDiaCierre(1).ToString
                    End If

                    If objRegistroDiaCierre(2).ToString = "1/1/1900" Then
                        dtmTransmisionVentaDiaria = " -----  "
                    Else
                        dtmTransmisionVentaDiaria = objRegistroDiaCierre(2).ToString
                    End If

                    If objRegistroDiaCierre(3).ToString = "1/1/1900" Then
                        dtmTransmisionBonos = " -----  "
                    Else
                        dtmTransmisionBonos = objRegistroDiaCierre(3).ToString
                    End If

                    If objRegistroDiaCierre(4).ToString = "1/1/1900" Then
                        dtmTransmisionRecetas = " -----  "
                    Else
                        dtmTransmisionRecetas = objRegistroDiaCierre(4).ToString
                    End If

                    'Pintado de cada Registro
                    Call strDiaCierreHTML.Append("<tr>")
                    Call strDiaCierreHTML.Append("<td class=" & strColorRegistro & ">" & dtmTransmsionPoliza & "</td>") 'Poliza
                    Call strDiaCierreHTML.Append("<td class=" & strColorRegistro & ">" & dtmTransmisionVentaDiaria & "</td>")   'Venta Diaria
                    Call strDiaCierreHTML.Append("<td class=" & strColorRegistro & ">" & dtmTransmisionBonos & "</td>")   'Bonos
                    Call strDiaCierreHTML.Append("<td class=" & strColorRegistro & ">" & dtmTransmisionRecetas & "</td>")   'Credito Empresa
                    Call strDiaCierreHTML.Append("</tr>")
                    intConsecutivo += 1
                Next

                Call strDiaCierreHTML.Append("</table>")

                '     Generamos el Navegador de Registros
                strRecordBrowserHTML = clsCommons.strGenerateJavascriptString(strDiaCierreHTML.ToString)
            Else
                strMensaje = "No existen transmisiones en el concentrador"
                strRecordBrowserHTML = ""
            End If

        End If

    End Sub

End Class
