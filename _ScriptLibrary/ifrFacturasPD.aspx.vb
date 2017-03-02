Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text
Imports System.Web
Imports System.Collections.Specialized

Public Class ifrFacturasPD
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
    ' Name       : strFacturasHTML
    ' Description: Valor que tomara la variable strFacturasHTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFacturasHTML() As String
        Get

            Dim objArrayFacturasElectronicas As Array = Nothing
            Dim objRegistroFacturasElectronicas As System.Collections.SortedList = Nothing

            Dim strbldFacturas As StringBuilder
            Dim intContador As Integer = 0
            Dim intMod As Integer = 0
            Dim strColorRegistro As String = "tdceleste"

            strbldFacturas = New StringBuilder

            ' Hacemos la consulta de la información del cliene especial.
            objArrayFacturasElectronicas = clsConcentrador.clsSucursal.clsMercancia.clsCompras.clsFacturaElectronica.strBuscarProveedor(intCompaniaId, intSucursalId, 0, 0, 0, strCadenaConexion)


            strbldFacturas.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strbldFacturas.Append("  <tr class='trtitulos'>")
            strbldFacturas.Append("    <th width='55' class='rayita'>C&oacute;digo</th>")
            strbldFacturas.Append("    <th width='128' class='rayita'>Proveedor</th>")
            strbldFacturas.Append("  </tr>")

            ' Validamos si trae información para mostrarla
            If IsArray(objArrayFacturasElectronicas) AndAlso objArrayFacturasElectronicas.Length > 0 Then


                ' Barremos el arreglo para ir formando los campos a mostrar en la página HTML
                For Each objRegistroFacturasElectronicas In objArrayFacturasElectronicas

                    intMod = intContador Mod 2
                    If intMod = 0 Then
                        strColorRegistro = "tdceleste"
                    Else
                        strColorRegistro = "tdblanco"
                    End If


                    strbldFacturas.Append("<tr>")
                    strbldFacturas.Append("<td class=" & strColorRegistro & ">")
                    strbldFacturas.Append("<a href='" & strURLSucursal & "MercanciaFacturasPorConfirmarPD.aspx&strUseRedirector=True&strCmd=VerTodo&intProveedorId=")  '<a href='MercanciaFacturasPorConfirmar.aspx?strCmd=VerTodo&intProveedorId=")
                    strbldFacturas.Append(CStr(objRegistroFacturasElectronicas.Item("intProveedorId")))
                    strbldFacturas.Append("' class='txaccion' target='_top'>")
                    strbldFacturas.Append(CStr(objRegistroFacturasElectronicas.Item("strProveedorNombreId")))
                    strbldFacturas.Append("</a>")
                    strbldFacturas.Append("</td>")
                    strbldFacturas.Append("<td class=" & strColorRegistro & ">")
                    strbldFacturas.Append(CStr(objRegistroFacturasElectronicas.Item("strProveedorRazonSocial")))
                    strbldFacturas.Append("</td>")
                    strbldFacturas.Append("</tr>")

                Next

            End If

            strbldFacturas.Append("</table>")

            strFacturasHTML = strbldFacturas.ToString

            Return strFacturasHTML
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
