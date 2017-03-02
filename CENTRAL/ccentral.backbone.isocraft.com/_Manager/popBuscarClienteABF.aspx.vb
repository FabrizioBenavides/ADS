
'====================================================================
' Page          : PopArticulo.aspx
' Title         : Administracion POS y BackOffice
' Description   : Popup para selecionar el Cliente
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Rocio Esquivel
' Version       : 1.0
' Last Modified : Miercoles, Mayo 07, 2014
'====================================================================
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration
Imports Isocraft.Web.Http

Public Class popBuscarClienteABF
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        blnSucursal = GetPageParameter("blnSucursal", True)

    End Sub

#End Region

#Region " Class Private Attributes"

    Private blnmSucursal As Boolean
    Private strmJavascriptWindowOnLoadCommands As String

#End Region
    '====================================================================
    ' Name       : blnSucursal
    ' Description: Bandera para buscar articulos en todas las sucursales
    ' Accessor   : Read/Write
    ' Throws     : Ninguna
    ' Output     : Boolean
    '====================================================================
    Public Property blnSucursal() As Boolean
        Get
            Return blnmSucursal
        End Get
        Set(ByVal blnValue As Boolean)
            blnmSucursal = blnValue
        End Set
    End Property

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
    ' Name       : strClienteABF
    ' Description: Código de articulo o cadena de caracteres a Buscar.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strClienteABF() As String
        Get
            Return Request.QueryString("strClienteABF")
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
    ' Name       : strRecordBrowserHTML
    ' Description: Genera el Record Browser para mostrar los Articulos
    '              de acuerdo a su descripcion.
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String

        ' Declaracion de Variables
        Dim objClienteDescripcion As Array
        Dim strClienteHTML As StringBuilder
        Dim strClienteABFDesc As String()
        Dim intConsecutivo As Integer
        Dim strColorRegistro As String
        Dim blnUnSoloRegistro As Boolean = False

        'Inicializacion de Variables
        strClienteHTML = New StringBuilder
        strClienteABFDesc = Nothing
        intConsecutivo = 0
        strJavascriptWindowOnLoadCommands = ""

        If blnSucursal = True Then

            ' Obtenemos la información de los Articulos
            objClienteDescripcion = clsConcentrador.clsSucursal.clstblMensajeInformativoABF.strBuscarClienteABF(strClienteABF, strCadenaConexion)

        Else

            ' Obtenemos la información de los Articulos
            objClienteDescripcion = clsConcentrador.clsSucursal.clstblMensajeInformativoABF.strBuscarClienteABF(strClienteABF, strCadenaConexion)

            ' Indicamos si el resultado solo arrojó 1 registro
            If IsArray(objClienteDescripcion) = True Then

                blnUnSoloRegistro = (objClienteDescripcion.Length = 1)

            End If

        End If

        If IsArray(objClienteDescripcion) Then

            If objClienteDescripcion.Length > 0 Then

                'Pintado de la Tabla
                Call strClienteHTML.Append("<table id='Table2' cellSpacing='0' cellPadding='0' width='96%' border='0'>")
                Call strClienteHTML.Append("<tr class='trtitulos'><th class='rayita' width='165'>Cliente ABF</th></tr>")

                intConsecutivo += 1

                For Each strClienteABFDesc In objClienteDescripcion

                    If (intConsecutivo Mod 2) <> 0 Then

                        strColorRegistro = "'tdceleste'"

                    Else

                        strColorRegistro = "'tdblanco'"

                    End If

                    'Pintado de cada Registro
                    Call strClienteHTML.Append("<tr>")
                    Call strClienteHTML.Append("<td class=" & strColorRegistro & ">")
                    Call strClienteHTML.Append("<a class='txaccion' href=\""javascript:ClosePopup('" & clsCommons.strFormatearDescripcion(strClienteABFDesc(0)).ToString & "','" & clsCommons.strFormatearDescripcion(strClienteABFDesc(1)) & "','" & clsCommons.strFormatearDescripcion(strClienteABFDesc(2)) & "')\"">" & clsCommons.strFormatearDescripcion(strClienteABFDesc(0)) & Space(1) & " - " & clsCommons.strFormatearDescripcion(strClienteABFDesc(1)) & " </a>")
                    Call strClienteHTML.Append("</td>")
                    Call strClienteHTML.Append("</tr>")

                    If blnUnSoloRegistro = True Then

                        strJavascriptWindowOnLoadCommands = "<script language=""javascript"">ClosePopup('" & clsCommons.strFormatearDescripcion(strClienteABFDesc(0)) & "','" & clsCommons.strFormatearDescripcion(strClienteABFDesc(1)) & "','" & clsCommons.strFormatearDescripcion(strClienteABFDesc(2)) & "')</script>"

                    End If

                    intConsecutivo += 1

                Next

                Call strClienteHTML.Append("</table>")

            End If

        End If

        If strClienteHTML.Length > 0 Then

            strRecordBrowserHTML = strClienteHTML.ToString()

        Else

            strRecordBrowserHTML = ""

        End If

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then

            Call Response.Redirect(strURLPOSAdmin & strRedirectPage)

        End If

    End Sub

End Class
