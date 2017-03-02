Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Business.clsConcentrador.clsSucursal.clsMercancia
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class clsPopPedidoDirectoMayoristaProveedor
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
    ' Name       : strProveedorId
    ' Description: Cadena de caracteres a buscar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strProveedorId() As String
        Get
            If Not IsNothing(Request.QueryString("strProveedorId")) Then
                Return Request.QueryString("strProveedorId")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Genera el Record Browser para mostrar los proveedores
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String

        Dim objProveedor As Array = Nothing
        Dim objRegistroProveedor As System.Collections.SortedList = Nothing

        Dim strProveedorHTML As New StringBuilder
        Dim intConsecutivo As Integer = 0
        Dim strColorRegistro As String = ""
        Dim strBusquedaSoloOrden As String = ""
        Dim strBusquedaOrdenDisponible As String = ""

        Call strProveedorHTML.Append("")


        objProveedor = clsCompras.clsPedido.strBuscarProveedor(intCompaniaId, intSucursalId, strProveedorId, 0, 0, strCadenaConexion)

        If IsArray(objProveedor) AndAlso objProveedor.Length > 0 Then

            'Pintado de la Tabla
            Call strProveedorHTML.Append("<table id='table2' cellSpacing='0' cellPadding='0' width='96%' border='0'>")
            Call strProveedorHTML.Append("<tr class='trtitulos'><th class='rayita' width='165'>Razón Social de Proveedor</th></tr>")

            intConsecutivo += 1

            For Each objRegistroProveedor In objProveedor

                If (intConsecutivo Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If


                'Pintado de cada Registro
                Call strProveedorHTML.Append("<tr>")
                Call strProveedorHTML.Append("<td class=" & strColorRegistro & ">")
                Call strProveedorHTML.Append("<a class='txaccion' href=\""javascript:ClosePopup('")
                Call strProveedorHTML.Append(clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("intProveedorId"))).ToString & "','")
                Call strProveedorHTML.Append(clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorNombreId"))).ToString & "','")
                Call strProveedorHTML.Append(clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorRazonSocial"))).ToString & "')\"">")
                Call strProveedorHTML.Append(clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorNombreId"))).ToString & Space(2) & clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorRazonSocial"))).ToString)
                Call strProveedorHTML.Append("</a>")
                Call strProveedorHTML.Append("</td>")
                Call strProveedorHTML.Append("</tr>")

                intConsecutivo += 1
            Next

            Call strProveedorHTML.Append("</table>")

        End If

        strRecordBrowserHTML = strProveedorHTML.ToString


    End Function


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

    End Sub

End Class

