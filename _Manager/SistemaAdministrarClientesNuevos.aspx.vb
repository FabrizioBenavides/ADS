Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert


Public Class SistemaAdministrarClientesNuevos
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

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private intmtxtGrupoClienteEspecialId As Integer

#End Region
    '====================================================================
    ' Name       : strFormAction
    ' Description: HTML form's action property value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormAction() As String
        Get
            Return strThisPageName
        End Get
    End Property

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Connection string
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Private ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: Name of this page
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return Server.UrlEncode(GetPageName())
        End Get
    End Property

    '====================================================================
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strJavascriptWindowOnLoadCommands() As String
        Get
            Return strmJavascriptWindowOnLoadCommands
        End Get
        Set(ByVal strValue As String)
            strmJavascriptWindowOnLoadCommands = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return GetPageParameter("strCmd", "")
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strHTMLFechaHora
    ' Description: Genera la fecha y hora de la página
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
        End Get
    End Property

    '====================================================================
    ' Name       : strGetRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String
        Dim strc As String = """"


        ' Declaramos e inicializamos las variables locales

        Dim objDataArray As Array = Benavides.CC.Data.clsClienteEspecial.strBuscar(0, 99, "", "", False, 0, Now(), 0, 0, Now(), "", 0, 0, False, False, False, 0, 0, strConnectionString)

        Dim objRegistroDataArray As New System.Collections.SortedList
        Dim strRecordBrowserHTML As New System.Text.StringBuilder

        If IsArray(objDataArray) AndAlso objDataArray.Length > 0 Then

            Dim intContadorRegistros As Integer = 0
            Dim strColorRegistro As String = ""

            strRecordBrowserHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

            strRecordBrowserHTML.Append("<tr class='trtitulos'>")
            strRecordBrowserHTML.Append("<th  class='rayita'>&nbsp;</th>")
            strRecordBrowserHTML.Append("<th  class='rayita'>Cliente</th>")
            strRecordBrowserHTML.Append("<th  class='rayita'>Nombre</th>")
            strRecordBrowserHTML.Append("<th  class='rayita'>Fecha de Modificación</th>")
            strRecordBrowserHTML.Append("<th  class='rayita'>Acciones</th>")
            strRecordBrowserHTML.Append("</tr>")


            For Each objRegistroDataArray In objDataArray
                intContadorRegistros += 1

                If (intContadorRegistros Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If


                strRecordBrowserHTML.Append("<tr>")
                strRecordBrowserHTML.Append("<td class=" & strColorRegistro & ">" & intContadorRegistros.ToString & "</td>")
                strRecordBrowserHTML.Append("<td class=" & strColorRegistro & ">" & Benavides.POSAdmin.Commons.clsCommons.strFormatearDescripcion(CStr(objRegistroDataArray.Item("strClienteEspecialNombreId"))) & "</td>")
                strRecordBrowserHTML.Append("<td class=" & strColorRegistro & ">" & Benavides.POSAdmin.Commons.clsCommons.strFormatearDescripcion(CStr(objRegistroDataArray.Item("strClienteEspecialNombre"))) & "</td>")
                strRecordBrowserHTML.Append("<td class=" & strColorRegistro & ">" & (CDate(ConvertObject(objRegistroDataArray.Item("dtmClienteEspecialUltimaModificacion"), TypeCode.DateTime))).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) & "</td>")
                strRecordBrowserHTML.Append("<td class=" & strColorRegistro & "><a href='javascript:popEditarCliente(" & CStr(objRegistroDataArray.Item("intClienteEspecialId")) & "," & strc & Benavides.POSAdmin.Commons.clsCommons.strFormatearDescripcion(CStr(objRegistroDataArray.Item("strClienteEspecialNombreId"))) & strc & "," & strc & Benavides.POSAdmin.Commons.clsCommons.strFormatearDescripcion(CStr(objRegistroDataArray.Item("strClienteEspecialNombre"))) & strc & ");'><img src='../static/images/imgNRAsignar.gif' width='9' height='9' border='0' align='absMiddle' alt = 'Haga clic aquí para asignarle el grupo al cliente'></a></td>")
                strRecordBrowserHTML.Append("</tr>")

            Next

            strRecordBrowserHTML.Append("</table>")

        End If

        Return strRecordBrowserHTML.ToString

    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

    End Sub

End Class
