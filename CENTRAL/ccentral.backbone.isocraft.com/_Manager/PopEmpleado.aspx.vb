
Imports Benavides.POSAdmin.Commons
Imports Benavides.POSAdmin
Imports System.Text

Public Class PopEmpleado
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

#Region "Properties"
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
    ' Name       : strEmpleadoBuscar
    ' Description: Código de planograma o cadena de caracteres a Buscar.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strEmpleadoBuscar() As String
        Get
            Return Request.QueryString("strEmpleadoBuscar")
        End Get
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

#Region "Business Logic"

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Genera el Record Browser para mostrar los Empleados
    '              de acuerdo a su descripcion.
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String
        ' Declaracion de Variables
        Dim objEmpleados As Array
        Dim strResultHTML As StringBuilder
        Dim strEmpleado As String()
        Dim intConsecutivo As Integer
        Dim strColorRegistro As String

        'Inicializacion de Variables
        strResultHTML = New StringBuilder
        strEmpleado = Nothing
        intConsecutivo = 0

        ' Obtenemos los planogramas
        'objEmpleados = Business.clsSucursal.strBuscarPlanoCenefa(Trim(strEmpleadoBuscar), 100, 100, strCadenaConexion)
        'objEmpleados = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarPlanoCenefa(Trim(strEmpleadoBuscar), 100, 100, strCadenaConexion)
        objEmpleados = Benavides.CC.Data.clsControlDeAsistencia.strBuscarPopEmpleado(Trim(strEmpleadoBuscar), 100, 100, strCadenaConexion)

        If IsArray(objEmpleados) AndAlso (objEmpleados.Length > 0) Then
            If objEmpleados.Length = 1 Then
                For Each strEmpleado In objEmpleados
                    strResultHTML.Append("onlyReg*" & strEmpleado(0).ToString & "*" & strEmpleado(1).ToString)
                    Return strResultHTML.ToString
                Next
            Else
                'Pintado de la Tabla
                Call strResultHTML.Append("<table id='Table2' cellSpacing=0 cellPadding=0 width='96%' border=0>")
                Call strResultHTML.Append("<tr class='trtitulos'><th class='rayita' width=165>Descripción del Empleado</th></tr>")

                intConsecutivo += 1

                For Each strEmpleado In objEmpleados
                    If (intConsecutivo Mod 2) <> 0 Then
                        strColorRegistro = "'tdceleste'"
                    Else
                        strColorRegistro = "'tdblanco'"
                    End If

                    'Pintado de cada Registro
                    Call strResultHTML.Append("<tr>")
                    Call strResultHTML.Append("<td class=" & strColorRegistro & ">")
                    Call strResultHTML.Append("<a class='txaccion' href=\""javascript:ClosePopup('" & strEmpleado(0).ToString & "','" & clsCommons.strFormatearDescripcion(strEmpleado(1).ToString) & "','','','','')\"">" & clsCommons.strFormatearDescripcion(strEmpleado(0)) & " " & clsCommons.strFormatearDescripcion(strEmpleado(1)) & " </a>")
                    Call strResultHTML.Append("</td>")
                    Call strResultHTML.Append("</tr>")

                    intConsecutivo += 1
                Next
                Call strResultHTML.Append("</table>")
            End If
        End If

        If strResultHTML.Length > 0 Then
            strRecordBrowserHTML = strResultHTML.ToString 'clsCommons.strGenerateJavascriptString(strResultHTML.ToString)
        Else
            strRecordBrowserHTML = "<span class='txcontenido'>No se encontro el empleado</span>"
        End If
    End Function

#End Region
End Class