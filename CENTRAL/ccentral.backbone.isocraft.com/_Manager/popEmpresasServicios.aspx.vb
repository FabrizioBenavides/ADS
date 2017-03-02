'====================================================================
' Page          : PopEmpresasServicios.aspx
' Title         : Administracion POS y BackOffice
' Description   : Popup para selecionar la Empresa
' Copyright     : 2008 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Javier Augusto Pérez González
' Version       : 1.0
' Last Modified : Junio, 2008
'====================================================================
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration
Imports Isocraft.Web.Http
Public Class popEmpresasServicio
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

            Return "strPageName=" & strThisPageName

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
    ' Name       : strEmpresaServicioIdNombre
    ' Description: Id de empresa o nombre de empresa a Buscar.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strEmpresaServicioIdNombre() As String
        Get
            Return Request.QueryString("strEmpresaServicioIdNombre")
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
        Dim objEmpresaServicioNombre As Array
        Dim strEmpresaServicioHTML As StringBuilder
        Dim strEmpresaServicio As String()
        Dim intConsecutivo As Integer
        Dim strColorRegistro As String
        Dim blnUnSoloRegistro As Boolean = False
        Dim blnPopEmpresaRegresa As Boolean = False

        'Inicializacion de Variables
        strEmpresaServicioHTML = New StringBuilder
        strEmpresaServicio = Nothing
        intConsecutivo = 0
        strJavascriptWindowOnLoadCommands = ""


        ' Obtenemos la información de las empresas de servicio
        objEmpresaServicioNombre = clsConcentrador.clsSucursal.clsEmpresaServicio.strBuscarEmpresas(strEmpresaServicioIdNombre, 1000, 1000, strCadenaConexion)

        ' Indicamos si el resultado solo arrojó 1 registro
        If IsArray(objEmpresaServicioNombre) = True Then
            blnUnSoloRegistro = (objEmpresaServicioNombre.Length = 1)
        End If

        If IsArray(objEmpresaServicioNombre) Then

            If objEmpresaServicioNombre.Length > 0 Then

                'Pintado de la Tabla
                Call strEmpresaServicioHTML.Append("<table id='Table2' cellSpacing='0' cellPadding='0' width='96%' border='0'>")
                Call strEmpresaServicioHTML.Append("<tr class='trtitulos'><th class='rayita' width='165'>Descripcion de la Empresa</th></tr>")

                intConsecutivo += 1

                For Each strEmpresaServicio In objEmpresaServicioNombre

                    If (intConsecutivo Mod 2) <> 0 Then

                        strColorRegistro = "'tdceleste'"

                    Else

                        strColorRegistro = "'tdblanco'"

                    End If

                    'Pintado de cada Registro
                    Call strEmpresaServicioHTML.Append("<tr>")
                    Call strEmpresaServicioHTML.Append("<td class=" & strColorRegistro & ">")
                    Call strEmpresaServicioHTML.Append("<a class='txaccion' href=\""javascript:ClosePopup('" & clsCommons.strFormatearDescripcion(strEmpresaServicio(0)).ToString & "','" & clsCommons.strFormatearDescripcion(strEmpresaServicio(2)) & "')\"">" & clsCommons.strFormatearDescripcion(strEmpresaServicio(0)) & Space(2) & clsCommons.strFormatearDescripcion(strEmpresaServicio(2)) & " </a>")
                    Call strEmpresaServicioHTML.Append("</td>")
                    Call strEmpresaServicioHTML.Append("</tr>")

                    If blnUnSoloRegistro = True Then

                        strJavascriptWindowOnLoadCommands = "<script language=""javascript"">ClosePopup('" & clsCommons.strFormatearDescripcion(strEmpresaServicio(0)) & "','" & clsCommons.strFormatearDescripcion(strEmpresaServicio(2)) & "')</script>"

                    End If

                    intConsecutivo += 1

                Next

                Call strEmpresaServicioHTML.Append("</table>")

            End If

        End If

        If strEmpresaServicioHTML.Length > 0 Then

            strRecordBrowserHTML = strEmpresaServicioHTML.ToString()

        Else

            strRecordBrowserHTML = ""

        End If

    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

End Class
