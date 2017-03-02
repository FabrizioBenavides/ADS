Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business
Imports System.Text
Imports System.Configuration

Public Class clsPopConceptoPrenomina
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
    ' Name       : strConceptoPrenomina
    ' Description: Fecha sobre la cual se consultará la bitácora
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strConceptoPrenomina() As String
        Get
            Return Request.QueryString("strConceptoPrenomina")
        End Get
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Genera el Record Browser para mostrar los Articulos
    '              de acuerdo a su descripcion.
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String

        Dim objConceptosPrenomina As Array = Nothing
        Dim strConceptosPrenomina As String()
        Dim strbldRecordBrowserHTML As StringBuilder
        Dim strColorRegistro As String
        Dim intConsecutivo As Integer : intConsecutivo = 1

        strbldRecordBrowserHTML = New StringBuilder

        ' Buscamos los conceptos de prenómina
        objConceptosPrenomina = clsConcentrador.clsPrenomina.strBuscarConcepto(strConceptoPrenomina, 0, 0, strCadenaConexion)

        If IsArray(objConceptosPrenomina) Then
            If objConceptosPrenomina.Length > 0 Then

                Call strbldRecordBrowserHTML.Append("<table width='96%' border='0' cellpadding='0' cellspacing='0'>")
                Call strbldRecordBrowserHTML.Append("<tr class='trtitulos'><th width='118' class='rayita'>Clave</th><th width='777' class='rayita'>Concepto</th></tr>")

                For Each strConceptosPrenomina In objConceptosPrenomina
                    If (intConsecutivo Mod 2) <> 0 Then
                        strColorRegistro = "'tdceleste'"
                    Else
                        strColorRegistro = "'tdblanco'"
                    End If

                    'Pintado de cada Registro
                    Call strbldRecordBrowserHTML.Append("<tr>")
                    Call strbldRecordBrowserHTML.Append("<td class=" & strColorRegistro & ">")
                    Call strbldRecordBrowserHTML.Append("<a class='txaccion' href=\""javascript:ClosePopup('" & clsCommons.strFormatearDescripcion(strConceptosPrenomina(0)).ToString & "','" & clsCommons.strFormatearDescripcion(strConceptosPrenomina(1)).ToString & "','" & clsCommons.strFormatearDescripcion(strConceptosPrenomina(3)).ToString & "','" & clsCommons.strFormatearDescripcion(strConceptosPrenomina(4)).ToString & "')\"">" & clsCommons.strFormatearDescripcion(strConceptosPrenomina(4)).ToString & " </a>")
                    Call strbldRecordBrowserHTML.Append("</td>")
                    Call strbldRecordBrowserHTML.Append("<td class=" & strColorRegistro & ">")
                    Call strbldRecordBrowserHTML.Append("<a class='txaccion' href=\""javascript:ClosePopup('" & clsCommons.strFormatearDescripcion(strConceptosPrenomina(0)).ToString & "','" & clsCommons.strFormatearDescripcion(strConceptosPrenomina(1)).ToString & "','" & clsCommons.strFormatearDescripcion(strConceptosPrenomina(3)).ToString & "','" & clsCommons.strFormatearDescripcion(strConceptosPrenomina(4)).ToString & "')\"">" & clsCommons.strFormatearDescripcion(strConceptosPrenomina(1)).ToString & " </a>")
                    Call strbldRecordBrowserHTML.Append("</td>")
                    Call strbldRecordBrowserHTML.Append("</tr>")

                    intConsecutivo += 1

                Next

                Call strbldRecordBrowserHTML.Append("</table>")

            End If
        End If

        Return strbldRecordBrowserHTML.ToString

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

    End Sub

End Class
