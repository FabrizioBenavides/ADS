Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration

Public Class clsMercanciaReporteTomaFisica
    Inherits System.Web.UI.Page
    Public strGeneraTablaHTML As String

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
    Public ReadOnly Property strCmdConsultar() As String
        Get
            If Not IsNothing(Trim(Request.Form("cmdConsultar"))) Then
                Return Trim(Request.Form("cmdConsultar"))
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
    ' Name       : strAyer
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strAyer() As String
        Get
            Dim dtmTemporal As Date
            dtmTemporal = CDate(clsCommons.strGetCustomDateTime("MM/dd/yyyy"))
            dtmTemporal = dtmTemporal.AddDays(-1)
            Return dtmTemporal.ToString("dd/MM/yyyy")
        End Get
    End Property

    '====================================================================
    ' Name       : strAyerNombreDia
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strAyerNombreDia() As String
        Get
            Dim dtmTemporal As Date
            dtmTemporal = CDate(clsCommons.strGetCustomDateTime("MM/dd/yyyy"))
            dtmTemporal = dtmTemporal.AddDays(-1)
            Return clsCommons.strNombreDia(dtmTemporal)
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaConsulta
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaConsulta() As Date
        Get
            Select Case strChkDtmFechaConsulta
                Case "1" 'Hoy
                    Return CDate(clsCommons.strDMYtoMDY(Trim(Request.Form("hdnDtmFechaConsulta1"))))
                Case "2" 'Ayer
                    Return CDate(clsCommons.strDMYtoMDY(Trim(Request.Form("hdnDtmFechaConsulta2"))))
            End Select
        End Get
    End Property

    '====================================================================
    ' Name       : strChkDtmFechaConsulta
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strChkDtmFechaConsulta() As String
        Get
            strChkDtmFechaConsulta = Trim(Request.Form("chkDtmFechaConsulta"))
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

        Dim objArray As Array = Nothing
        Dim intInicio As Integer = 0

        If strCmdConsultar <> "" Then
            objArray = Nothing
            objArray = clsConcentrador.clsPlanograma.strBuscar(intCompaniaId, intSucursalId, dtmFechaConsulta, 0, 0, strCadenaConexion)
            strGeneraTablaHTML = strGeneraTabla(objArray, "Planogramas para inventariar el día elegido", "", intInicio, "No.", "", "", "", "", "Acción", "")
        End If

    End Sub

    Private Function strGeneraTabla(ByVal objArray As Array, _
                                  ByVal strTitulo As String, _
                                  ByVal strEncaCol0 As String, _
                                  ByRef intConsecutivo As Integer, _
                                  ByVal strEncaCol1 As String, _
                                  ByVal strEncaCol2 As String, _
                                  ByVal strEncaCol3 As String, _
                                  ByVal strEncaCol4 As String, _
                                  ByVal strEncaCol5 As String, _
                                  ByVal strEncaCol6 As String, _
                                  ByVal strEncaCol7 As String _
                                  ) As String
        Dim strHTML As StringBuilder
        Dim strRegistro As String()
        strRegistro = Nothing
        Dim intRenglon As Integer
        Dim dblTotal As Double
        Dim strClass As String
        Dim strComilla As String
        Dim strReadonly As String

        Dim fltPrecioVenta As Double, fltImporte As Double
        Dim intCantidad As Integer

        strComilla = """"

        strHTML = New StringBuilder
        strHTML.Append("")

        strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strHTML.Append("<tr class='trtitulos'>")
        strHTML.Append("<th colspan='3'><span class='txsubtitulo'>")
        strHTML.Append("<img src='../static/images/bullet_subtitulos.gif' width='17' height='11' ")
        strHTML.Append("align='absmiddle'>" & strTitulo & "</span>")
        strHTML.Append("</th>")

        strHTML.Append("</tr>")
        strHTML.Append("<tr class='trtitulos'>")
        strHTML.Append("<th width='0'  class='rayita'>" & strEncaCol0 & "&nbsp;</th>")
        strHTML.Append("<th width='61'  class='rayita'>" & strEncaCol1 & "&nbsp;</th>")
        strHTML.Append("<th width='200' class='rayita'>" & strEncaCol2 & "&nbsp;</th>")
        strHTML.Append("<th class='rayita'>" & strEncaCol3 & "&nbsp;</th>")
        strHTML.Append("<th class='rayita'>" & strEncaCol4 & "&nbsp;</th>")
        strHTML.Append("<th class='rayita'>" & strEncaCol5 & "&nbsp;</th>")
        strHTML.Append("<th class='rayita'>" & strEncaCol6 & "&nbsp;</th>")
        strHTML.Append("<th class='rayita'>" & strEncaCol7 & "&nbsp;</th>")
        strHTML.Append("</tr>")

        '------------------------
        intRenglon = 0
        If IsArray(objArray) AndAlso (objArray.Length > 0) Then
            For Each strRegistro In objArray

                intConsecutivo += 1
                intRenglon += 1
                If ((intRenglon Mod 2) = 0) Or (intRenglon = 0) Then
                    strClass = "tdceleste"
                Else
                    strClass = "tdblanco"
                End If
                strHTML.Append("<tr>")

                'Columna 0
                If Len(strEncaCol0) > 0 Then
                    strHTML.Append("<td class='" & strClass & "'>" & intConsecutivo.ToString & "&nbsp;</td>")
                Else
                    strHTML.Append("<td class='" & strClass & "'>" & "" & "&nbsp;</td>")
                End If

                '0 intPlanoId  
                '1 blnPlanoSucursalCapturado
                '2 strPlanoNombre
                '3 dtmPlanoRegistro

                'Columna 1
                strHTML.Append("<td class='" & strClass & "'>" & strRegistro(0) & "&nbsp;</td>")
                strHTML.Append("<input type='hidden' name='intPlanoId_" & intRenglon.ToString & "' value='" & strRegistro(0) & "'>")

                'Columna 2
                strHTML.Append("<td class='" & strClass & "'>" & clsCommons.strFormatearDescripcion(strRegistro(2).ToString) & "&nbsp;</td>")

                'Columna 3
                strHTML.Append("<td align='right' class='" & strClass & "'>" & "&nbsp;</td>")

                'Columna 4
                strHTML.Append("<td align='right' class='" & strClass & "'>" & "&nbsp;</td>")

                'Columna 5
                strHTML.Append("<td align='right' class='" & strClass & "'><a style=" & strComilla & "text-decoration: none" & strComilla & " href=" & strComilla & "javascript:fnImprimirPartida(" & "" & "" & "'" & strRegistro(0) & "'," & LCase(strRegistro(1)) & ",'" & clsCommons.strFormatearFechaPresentacion(CStr(dtmFechaConsulta)) & "')" & strComilla & ">" & "<img src=../static/images/icono_imprimir.gif width=16 height=14 border=0 align=absmiddle><font color=#575757> Imprimir reporte&nbsp;</font>" & "</a></td>")

                'Columna 6
                strHTML.Append("<td align='right' class='" & strClass & "'><a style=" & strComilla & "text-decoration: none" & strComilla & " href=" & strComilla & "javascript:fnGraficoPartida(" & "" & "" & "'" & Right("000000" & strRegistro(0), 6) & "'," & LCase(strRegistro(1)) & ",'" & clsCommons.strFormatearFechaPresentacion(CStr(dtmFechaConsulta)) & "')" & strComilla & ">" & "<img src=../static/images/icono_grafico.gif width=9 height=12 border=0 align=absmiddle><font color=#575757> Gráfico&nbsp;</font>" & "</a></td>")

                'Columna 7
                strHTML.Append("<td align='right' class='" & strClass & "'><a style=" & strComilla & "text-decoration: none" & strComilla & " href=" & strComilla & "javascript:fnTextoPartida(" & "" & "" & "'" & strRegistro(0) & "'," & LCase(strRegistro(1)) & ",'" & clsCommons.strFormatearFechaPresentacion(CStr(dtmFechaConsulta)) & "')" & strComilla & ">" & "<img src=../static/images/icono_texto.gif width=8 height=12 border=0 align=absmiddle><font color=#575757> Texto&nbsp;</font>" & "</a></td>")

                strHTML.Append("</tr>")
            Next
        End If
        '------------------------

        strHTML.Append("</table>")
        strHTML.Append("<input type=hidden name=hdnTotalDePartidas value=" & intRenglon.ToString & ">")
        strHTML.Append("<input type=hidden name=dtmFechaConsultaElegida value=" & clsCommons.strFormatearFechaPresentacion(CStr(dtmFechaConsulta)) & ">")

        strGeneraTabla = clsCommons.strGenerateJavascriptString(strHTML.ToString)
    End Function

End Class
