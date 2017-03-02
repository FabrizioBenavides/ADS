Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration


Public Class PopEmpleadoVisitasCentral
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
    ' Name       : strCentroLogisticoId
    ' Description: Código del Centro Logistico a Buscar.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCentroLogisticoId() As String
        Get
            If Not IsNothing(Request.QueryString("strCentroLogisticoId")) Then
                Return Request.QueryString("strCentroLogisticoId")
            Else
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : blnActivos
    ' Description: Código de articulo o cadena de caracteres a Buscar.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property blnActivos() As Boolean
        Get
            If Not IsNothing(Request.QueryString("blnActivos")) Then
                Return CBool(Request.QueryString("blnActivos"))
            Else
                Return False
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intEmpleadoId
    ' Description: Código de articulo o cadena de caracteres a Buscar.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strEmpleadoId() As String
        Get
            If Not IsNothing(Request.QueryString("strEmpleadoId")) Then
                Return Request.QueryString("strEmpleadoId")
            Else
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intTipoEmpleadoId
    ' Description: Código del tipo de empleado a Buscar.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTipoEmpleadoId() As Integer
        Get
            If Not IsNothing(Request.QueryString("strTipoEmpleadoId")) Then
                Return CInt(Request.QueryString("strTipoEmpleadoId"))
            Else
                Return 0
            End If
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

        Dim objArticuloProveedor As Array = Nothing
        Dim objRegistroArticuloProveedor As System.Collections.SortedList = Nothing

        Dim strArticuloProveedorHTML As New StringBuilder
        Dim intConsecutivo As Integer = 0
        Dim strColorRegistro As String = String.Empty


        Call strArticuloProveedorHTML.Append(String.Empty)

        objArticuloProveedor = Benavides.CC.Data.clsReporteDeVisitas.strBuscarEmpleadoVisitasCentral(strCentroLogisticoId, intTipoEmpleadoId, blnActivos, strEmpleadoId, strCadenaConexion)

        If IsArray(objArticuloProveedor) AndAlso objArticuloProveedor.Length > 0 Then

            'Pintado de la Tabla
            Call strArticuloProveedorHTML.Append("<table id='Table2' cellSpacing='0' cellPadding='0' width='96%' border='0'>")
            Call strArticuloProveedorHTML.Append("<tr class='trtitulos'><th class='rayita' width='165'>Empleados</th></tr>")

            intConsecutivo += 1

            For Each objRegistroArticuloProveedor In objArticuloProveedor

                If (intConsecutivo Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If

                Call strArticuloProveedorHTML.Append("<tr>")
                Call strArticuloProveedorHTML.Append("<td class=" & strColorRegistro & ">")
                Call strArticuloProveedorHTML.Append("<a class='txaccion' href=\""javascript:ClosePopup('")
                Call strArticuloProveedorHTML.Append(CStr(objRegistroArticuloProveedor.Item("intEmpleadoId")) & "','")
                Call strArticuloProveedorHTML.Append(clsCommons.strFormatearDescripcion(CStr(objRegistroArticuloProveedor.Item("Nombre"))) & "')\"">")
                Call strArticuloProveedorHTML.Append(CStr(objRegistroArticuloProveedor.Item("intEmpleadoId")) & " - " & clsCommons.strFormatearDescripcion(CStr(objRegistroArticuloProveedor.Item("Nombre"))))
                Call strArticuloProveedorHTML.Append("</a>")
                Call strArticuloProveedorHTML.Append("</td>")
                Call strArticuloProveedorHTML.Append("</tr>")

                intConsecutivo += 1
            Next

            Call strArticuloProveedorHTML.Append("</table>")

        End If

        strRecordBrowserHTML = strArticuloProveedorHTML.ToString


    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

    End Sub

End Class
