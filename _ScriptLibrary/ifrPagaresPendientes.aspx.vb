Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports System.Configuration
Imports System.Text

Public Class ifrPagaresPendientes
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

    '#Region " Web Form Designer Generated Code "

    ''This call is required by the Web Form Designer.
    '<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    'End Sub

    'Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    '    'CODEGEN: This method call is required by the Web Form Designer
    '    'Do not modify it using the code editor.
    '    InitializeComponent()
    'End Sub

    '#End Region

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
    ' Name       : strPagaresHTML
    ' Description: Valor que tomara la variable strPagaresHTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strPagaresHTML() As String
        Get

            Dim strbldRecibos As StringBuilder
            Dim objPagares As Array = Nothing
            Dim strRecibos As String() = Nothing
            Dim intContador As Integer = 0
            Dim intMod As Integer = 0
            Dim strColortd As String = "tdceleste"

            strbldRecibos = New StringBuilder

            ' Hacemos la consulta de la información del cliene especial.
            objPagares = Benavides.CC.Data.clsControlPagares.strConsultaSolicitudesPorConfirmar(intCompaniaId, intSucursalId, strCadenaConexion)

            strbldRecibos.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strbldRecibos.Append("  <tr class='trtitulos'>")
            strbldRecibos.Append("    <th width='59' class='rayita'>Autorizacion</th>")
            strbldRecibos.Append("    <th width='56' class='rayita'>Importe</th>")
            strbldRecibos.Append("    <th width='74' class='rayita'>Fecha Pagare</th>")
            strbldRecibos.Append("  </tr>")

            ' Validamos si trae información para mostrarla
            If IsArray(objPagares) AndAlso objPagares.Length > 0 Then
                strRecibos = DirectCast(objPagares.GetValue(0), String())

                ' Barremos el arreglo para ir formando los campos a mostrar en la página HTML
                For intContador = 0 To objPagares.Length - 1
                    strRecibos = Nothing
                    strRecibos = DirectCast(objPagares.GetValue(intContador), String())

                    intMod = intContador Mod 2
                    If intMod = 0 Then
                        strColortd = "tdceleste"
                    Else
                        strColortd = "tdblanco"
                    End If

                    strbldRecibos.Append("  <tr>")
                    'strbldRecibos.Append("    <td class='" & strColortd & "'><a href='" & strURLSucursal & "MercanciaConfirmarReciboDeProductos.aspx&strUseRedirector=True&intTransferenciaId=" & strRecibos(0) & "&intCompaniaEnvioId=" & strRecibos(4) & "&intSucursalEnvioId=" & strRecibos(5) & "' class='txaccion' target='_top'>" & strRecibos(1) & "</a></td>")
                    strbldRecibos.Append("    <td class='" & strColortd & "'>" & strRecibos(3) & "</td>")
                    strbldRecibos.Append("    <td class='" & strColortd & "'>" & strRecibos(4) & "</td>")
                    strbldRecibos.Append("    <td class='" & strColortd & "'>" & clsCommons.strDMYtoMDY(strRecibos(5)) & "</td>")
                    strbldRecibos.Append("  </tr>")

                Next

            End If

            strbldRecibos.Append("</table>")

            strPagaresHTML = strbldRecibos.ToString

            Return strPagaresHTML
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

            'If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            '    Call Response.Redirect(strRedirectPage)
            'End If

        End If

    End Sub

End Class
