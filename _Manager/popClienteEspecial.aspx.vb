Imports Benavides.POSAdmin.Commons
Imports Benavides.POSAdmin
Imports System.Text

Public Class PopClienteEspecial
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
            Return "/Default.aspx?strURL=" & Server.UrlEncode(Request.ServerVariables("SCRIPT_NAME"))
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
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strClienteBuscar
    ' Description: Código de Cliente o cadena de caracteres a Buscar.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intClienteContado() As Byte
        Get
            If Not IsNothing(Request.QueryString("intClienteContado")) Then
                Return CByte(Request.QueryString("intClienteContado"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strClienteBuscar
    ' Description: Código de Cliente o cadena de caracteres a Buscar.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strClienteBuscar() As String
        Get
            Return Request.QueryString("strClienteBuscar")
        End Get
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Genera el Record Browser para mostrar los Clientes
    '              de acuerdo a su descripcion.
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String
        ' Declaracion de Variables
        Dim objClienteDescripcion As Array
        Dim strClienteHTML As StringBuilder
        Dim strCliente As String()
        Dim intConsecutivo As Integer
        Dim strColorRegistro As String
        Dim intClienteEncontrado As Byte

        'Inicializacion de Variables
        strClienteHTML = New StringBuilder
        strCliente = Nothing
        intConsecutivo = 0
        intClienteEncontrado = 0

        ' Obtenemos la información de los clienteEspeciales

        objClienteDescripcion = Benavides.CC.Data.clsClienteEspecial.strBuscar(strClienteBuscar, "", 0, 0, strCadenaConexion)

        If IsArray(objClienteDescripcion) AndAlso objClienteDescripcion.Length > 0 Then
            intClienteEncontrado = 1
        Else
            'Buscamso por strClienteEspecialNombreId
            objClienteDescripcion = Nothing

            objClienteDescripcion = Benavides.CC.Data.clsClienteEspecial.strBuscar("", strClienteBuscar, 0, 0, strCadenaConexion)
            If IsArray(objClienteDescripcion) AndAlso objClienteDescripcion.Length > 0 Then
                intClienteEncontrado = 1
            End If

        End If

        If intClienteEncontrado = 1 Then
            'Pintado de la Tabla
            Call strClienteHTML.Append("<table id='Table2' cellSpacing='0' cellPadding='0' width='96%' border='0'>")
            Call strClienteHTML.Append("<tr class='trtitulos'><th class='rayita' width='165'>Descripcion del Cliente</th></tr>")

            intConsecutivo += 1

            For Each strCliente In objClienteDescripcion
                If (intConsecutivo Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If

                'Pintado de cada Registro
                Call strClienteHTML.Append("<tr>")
                Call strClienteHTML.Append("<td class=" & strColorRegistro & ">")
                Call strClienteHTML.Append("<a class='txaccion' href=\""javascript:ClosePopup('" & strCliente(2).ToString & "','" & clsCommons.strFormatearDescripcion(strCliente(3).ToString) & "','" & strCliente(0).ToString & "')\"">" & clsCommons.strFormatearDescripcion(strCliente(2)) & " " & clsCommons.strFormatearDescripcion(strCliente(3)) & " </a>")
                Call strClienteHTML.Append("</td>")
                Call strClienteHTML.Append("</tr>")

                intConsecutivo += 1
            Next
            Call strClienteHTML.Append("</table>")

        End If

        If strClienteHTML.Length > 0 Then
            strRecordBrowserHTML = strClienteHTML.ToString
        Else
            strRecordBrowserHTML = ""
        End If

    End Function

    '====================================================================
    ' Name       : Page_Load
    ' Description: Actividades al cargar la página
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        'If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
        '    Call Response.Redirect("../Default.aspx")
        'End If

    End Sub


End Class
