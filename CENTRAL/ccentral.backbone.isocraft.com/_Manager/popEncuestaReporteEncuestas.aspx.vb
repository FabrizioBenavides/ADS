Imports Benavides.POSAdmin.Commons
Imports Benavides.POSAdmin
Imports System.Text

Public Class popEncuestaReporteEncuestas
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

    Private ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property
    '====================================================================
    ' Name       : intGrupoUsuarioId
    ' Description: Identificador del Grupo de Usuario
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intGrupoUsuarioId() As Integer
        Get
            Return CInt(Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))
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
    Public ReadOnly Property strEncuestaBuscar() As String
        Get
            Return Request.QueryString("strEncuestaBuscar")
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

        ' Obtenemos las Encuestas

        Dim objArrayEncuestas As Array = Benavides.CC.Data.clstblEncuesta.strBuscar(0, strEncuestaBuscar, "", CDate("01/01/1900"), CDate("01/01/1900"), True, True, CDate("01/01/1900"), "", 0, 0, strCadenaConexion)
        Dim RegistroEncuesta As System.Collections.SortedList

        If IsArray(objArrayEncuestas) AndAlso objArrayEncuestas.Length > 0 Then

            'Pintado de la Tabla
            Call strClienteHTML.Append("<table id='Table2' cellSpacing='0' cellPadding='0' width='96%' border='0'>")
            Call strClienteHTML.Append("<tr class='trtitulos'><th class='rayita' width='165'>Descripcion de la Encuesta</th></tr>")

            intConsecutivo += 1
            For Each RegistroEncuesta In objArrayEncuestas
                If (intConsecutivo Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If

                'Pintado de cada Registro
                Call strClienteHTML.Append("<tr>")
                Call strClienteHTML.Append("<td class=" & strColorRegistro & ">")
                Call strClienteHTML.Append("<a class='txaccion' href=\""javascript:ClosePopup('" & RegistroEncuesta.Item("intEncuestaId").ToString & "','" & clsCommons.strFormatearDescripcion(RegistroEncuesta.Item("strEncuestaNombre").ToString) & "','" & RegistroEncuesta.Item("strEncuestaDescripcion").ToString & "')\"">" & clsCommons.strFormatearDescripcion(RegistroEncuesta.Item("strEncuestaNombre").ToString) & " </a>")
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

    End Sub

End Class
