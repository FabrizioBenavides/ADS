Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports System.Configuration
Imports System.Text

Public Class clsifrRemisiones
    Inherits System.Web.UI.Page

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
    Public ReadOnly Property strRedirectPage() As String
        Get
            ' Return "/Default.aspx?strURL=" & Server.UrlEncode(Request.ServerVariables("SCRIPT_NAME"))
            If intCompaniaId > 0 Then
                Return "/Default.aspx?strURL=/_ScriptLibrary/POSAdminRedirectorCC.aspx?strPageName=" & strThisPageName
            Else
                Return "/Default.aspx?strURL=" & Server.UrlEncode(Request.ServerVariables("SCRIPT_NAME"))
            End If
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
    ' Name       : strURLSucursal
    ' Description: URL de la Sucursal del usuario actual
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private strmURLSucursal As String
    Public ReadOnly Property strURLSucursal() As String
        Get
            If Len(strmURLSucursal) = 0 Then
                strmURLSucursal = "http://" & Request.QueryString("strServerName") & ":" & Request.QueryString("strServerPort") & "/_ScriptLibrary/POSAdminRedirectorCC.aspx?strPageName="
            End If
            Return strmURLSucursal
        End Get
    End Property

    '====================================================================
    ' Name       : strRemisionesHTML
    ' Description: Valor que tomara la variable strRemisionesHTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRemisionesHTML() As String
        Get

            Dim intContador As Integer = 0
            Dim strColorRegistro As String = ""

            Dim objArrayRemisionesElectronicas As Array = Nothing
            Dim objRegistroRemisionesElectronicas As System.Collections.SortedList = Nothing

            Dim strbldRemisiones As New StringBuilder

            ' Hacemos la consulta de la información del cliene especial.
            objArrayRemisionesElectronicas = clsConcentrador.clsSucursal.clsMercancia.clsRemisionElectronica.strBuscarRemisionProveedor(intCompaniaId, intSucursalId, 0, 0, 0, strCadenaConexion)

            strbldRemisiones.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strbldRemisiones.Append("<tr class='trtitulos'>")
            strbldRemisiones.Append("<th width='55' class='rayita'>C&oacute;digo</th>")
            strbldRemisiones.Append("<th width='128' class='rayita'>Proveedor</th>")
            strbldRemisiones.Append("</tr>")

            ' Validamos si trae información para mostrarla
            If IsArray(objArrayRemisionesElectronicas) AndAlso objArrayRemisionesElectronicas.Length > 0 Then

                For Each objRegistroRemisionesElectronicas In objArrayRemisionesElectronicas

                    intContador += 1
                    If (intContador Mod 2) <> 0 Then
                        strColorRegistro = "'tdceleste'"
                    Else
                        strColorRegistro = "'tdblanco'"
                    End If

                    strbldRemisiones.Append("<tr>")
                    strbldRemisiones.Append("<td class=" & strColorRegistro & ">")
                    strbldRemisiones.Append("<a href='" & strURLSucursal & "MercanciaRemisionPorConfirmar.aspx&strUseRedirector=True&strCmd=VerTodo&intProveedorId=")
                    strbldRemisiones.Append(CStr(objRegistroRemisionesElectronicas.Item("intProveedorId")))
                    strbldRemisiones.Append("' class='txaccion' target='_top'>")
                    strbldRemisiones.Append(CStr(objRegistroRemisionesElectronicas.Item("strProveedorNombreId")))
                    strbldRemisiones.Append("</a>")
                    strbldRemisiones.Append("</td>")
                    strbldRemisiones.Append("<td class=" & strColorRegistro & ">")
                    strbldRemisiones.Append(CStr(objRegistroRemisionesElectronicas.Item("strProveedorRazonSocial")))
                    strbldRemisiones.Append("</td>")
                    strbldRemisiones.Append("</tr>")

                Next


            End If

            strbldRemisiones.Append("</table>")

            strRemisionesHTML = strbldRemisiones.ToString

            Return strRemisionesHTML

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

        Dim strUsuarioNombre As String = Request.Form("txtUsuarioNombre")
        Dim strUsuarioContrasena As String = Request.Form("txtUsuarioContrasena")
        Dim intResultado As Integer = 0

        If Len(strUsuarioNombre) > 0 AndAlso Len(strUsuarioContrasena) > 0 Then

            ' Ejecutamos la validación de la cuenta del usuario
            intResultado = clsConcentrador.clsControlAcceso.intValidarCuentaUsuario(strUsuarioNombre, strUsuarioContrasena, Response, Server, strCadenaConexion)

        Else

            If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
                Call Response.Redirect(strRedirectPage)
            End If

        End If

    End Sub

End Class
