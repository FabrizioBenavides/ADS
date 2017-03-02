Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class clsifrMercanciaConsultarPlanogramas
    Inherits System.Web.UI.Page
    Private intmFolio As Integer
    Private strmFechaDevolucion As String
    Private strmNombreProveedor As String
    Private strmMotivoDevolucion As String
    Private intmProveedor As Integer

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
    'Public ReadOnly Property strRedirectPage() As String
    '    Get
    '        ' Return "/Default.aspx?strURL=" & Server.UrlEncode(Request.ServerVariables("SCRIPT_NAME"))
    '        If intCompaniaId > 0 Then
    '            Return "/Default.aspx?strURL=/_ScriptLibrary/POSAdminRedirectorCC.aspx?strPageName=" & strThisPageName
    '        Else
    '            Return "/Default.aspx?strURL=" & Server.UrlEncode(Request.ServerVariables("SCRIPT_NAME"))
    '        End If
    '    End Get
    'End Property

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
    ' Name       : strRecordBrowserHTML
    ' Description: Valor que tomara la variable strmRecordBrowserHTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRecordBrowserHTML() As String
        Get
            Dim objPlanogramas As Array = Nothing
            Dim strbldRecordBrowser As StringBuilder
            Dim strPlanogramas As String() = Nothing
            Dim intContador As Integer = 0

            ' Creamos los string builders.
            strbldRecordBrowser = New StringBuilder

            'Response.Write("intCompaniaId =[" & intCompaniaId & "]<br>")
            'Response.Write("intSucursalId =[" & intSucursalId & "]<br>")

            'Hacemos la consulta de los planogramas
            objPlanogramas = clsConcentrador.clsPlanograma.strBuscar(intCompaniaId, intSucursalId, strCadenaConexion)

            ' Validamos si trae información para mostrarla
            If IsArray(objPlanogramas) AndAlso objPlanogramas.Length > 0 Then

                strbldRecordBrowser.Append("<div id='divPlanograma'><table width='100%' border='0' cellpadding='0' cellspacing='0'>")

                ' Barremos el arreglo para ir formando los campos a mostrar en la página HTML
                For intContador = 0 To objPlanogramas.Length - 1
                    strPlanogramas = Nothing
                    strPlanogramas = DirectCast(objPlanogramas.GetValue(intContador), String())

                    ' Formamos el renglón con la información traida de la base de datos.
                    strbldRecordBrowser.Append("    <tr> ")
                    strbldRecordBrowser.Append("        <td class='tdblanco' width='76'>" & strPlanogramas(0) & "</td>")
                    strbldRecordBrowser.Append("        <td class='tdblanco' width='514'>" & strPlanogramas(2) & "</td>")
                    strbldRecordBrowser.Append("        <td class='tdblanco' width='99'>" & clsCommons.strFormatearFechaPresentacion(strPlanogramas(3)) & "</td>")
                    strbldRecordBrowser.Append("        <td class='tdblanco' width='85'><a href='MercanciaConsultarPlanogramaTexto.aspx?intPlanoId=" & strPlanogramas(0) & "' target='_top'><img src='../static/images/icono_texto.gif' width='8' height='12' border='0' align='absmiddle'></a>&nbsp;&nbsp;<a href='MercanciaConsultarPlanogramaTexto.aspx?intPlanoId=" & strPlanogramas(0) & "' class='txaccion' target='_top'>Texto</a></td>")
                    strbldRecordBrowser.Append("        <td class='tdblanco' width='181'><a href='../static/PDF/Planos/Pa" & Right("000000" & strPlanogramas(0), 6) & ".PDF' target='_blank'><img src='../static/images/icono_grafico.gif' width='9' height='12' border='0' align='absmiddle'></a>&nbsp;&nbsp;<a href='../static/PDF/Planos/Pa" & Right("000000" & strPlanogramas(0), 6) & ".PDF' class='txaccion' target='_blank'>Gr&aacute;fico</a></td>")
                    strbldRecordBrowser.Append("    </tr>")

                Next

                'Cerramos la tabla
                strbldRecordBrowser.Append("</table></div>")

                strRecordBrowserHTML = strbldRecordBrowser.ToString
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

        '' Control de Acceso de la página
        'If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
        '    Call Response.Redirect(strRedirectPage)
        'End If

    End Sub

End Class
