Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration

Public Class PopSucursal
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
    ' Name       : strCompaniaIdNombre
    ' Description: Compañia o cadena de caracteres a Buscar.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCompaniaIdNombre() As String
        Get
            Return Request.QueryString("strCompaniaIdNombre")
        End Get
    End Property
    '====================================================================
    ' Name       : strSucursalIdNombre
    ' Description: Código de articulo o cadena de caracteres a Buscar.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalIdNombre() As String
        Get
            Return Request.QueryString("strSucursalIdNombre")
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
        ' Declaracion de Variables
        Dim objSucursalDescripcion As Array
        Dim strSucursalHTML As StringBuilder
        Dim strSucursal As String()
        Dim intConsecutivo As Integer
        Dim strColorRegistro As String


        'Inicializacion de Variables
        strSucursalHTML = New StringBuilder
        strSucursal = Nothing
        intConsecutivo = 0

        ' Obtenemos la información de los Articulos
        objSucursalDescripcion = clsConcentrador.clsSucursal.strBuscar(strCompaniaIdNombre, strSucursalIdNombre, 100, 100, strCadenaConexion)

        If IsArray(objSucursalDescripcion) Then
            If objSucursalDescripcion.Length > 0 Then

                'Pintado de la Tabla
                Call strSucursalHTML.Append("<table id='Table2' cellSpacing='0' cellPadding='0' width='96%' border='0'>")
                Call strSucursalHTML.Append("<tr class='trtitulos'><th class='rayita' width='165'>Descripcion de la sucursal</th></tr>")

                intConsecutivo += 1

                For Each strSucursal In objSucursalDescripcion
                    If (intConsecutivo Mod 2) <> 0 Then
                        strColorRegistro = "'tdceleste'"
                    Else
                        strColorRegistro = "'tdblanco'"
                    End If

                    'Pintado de cada Registro
                    Call strSucursalHTML.Append("<tr>")
                    Call strSucursalHTML.Append("<td class=" & strColorRegistro & ">")

                    Call strSucursalHTML.Append("<a class='txaccion' href=\""javascript:ClosePopup('" & clsCommons.strFormatearDescripcion(strSucursal(0)).ToString & "','" & clsCommons.strFormatearDescripcion(strSucursal(1)).ToString & "','" & clsCommons.strFormatearDescripcion(strSucursal(2)).ToString & "')\"">" & clsCommons.strFormatearDescripcion(strSucursal(2)).ToString & " </a>")

                    Call strSucursalHTML.Append("</td>")
                    Call strSucursalHTML.Append("</tr>")

                    intConsecutivo += 1
                Next
                Call strSucursalHTML.Append("</table>")
            End If
        End If

        If strSucursalHTML.Length > 0 Then
            strRecordBrowserHTML = strSucursalHTML.ToString
        Else
            strRecordBrowserHTML = ""
        End If
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

    End Sub

End Class
