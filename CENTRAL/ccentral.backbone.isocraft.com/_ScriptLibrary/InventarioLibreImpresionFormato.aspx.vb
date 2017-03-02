'====================================================================
' Class         : clsInventarioLibreImpresionFormato
' Title         : Grupo Benavides. Inventarios Rotativos.
' Description   : Inventarios Libres Impresion de Formato
' Copyright     : 2003-2006 All rights reserved.
' Company       : Neitek Solutions S.A. de C.V.
' Author        : Carolina Caballero
' Version       : 1.0
' Last Modified : Monday, Nov 1st, 2004
'====================================================================

Imports System.Configuration
Imports System.Text

Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports prjCCInventarioBusiness.Benavides.InvRot.Utils

Public Class clsInventarioLibreImpresionFormato
    Inherits System.Web.UI.Page
    Implements PrintInterface

    'Variables globales
    Dim strmMensaje As String = ""
    Dim strmRecordBrowserHTML As String = ""
    Dim strmbtnAceptar As String = ""
    Private selDate As Date
    Private strmCommand As String

    Protected WithEvents sucursalNombre As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnCancel As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnImprimirFormato As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents intTotalLineas As System.Web.UI.WebControls.TextBox
    Protected WithEvents fechaActual As System.Web.UI.WebControls.TextBox

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
            Return CInt(clsCommons.strReadCookie("intGrupoUsuarioId", "0", Context.Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strCentroLogisticoId
    ' Description: Valor de la Sucursal
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCentroLogisticoId() As String
        Get
            Return clsCommons.strReadCookie("strCentroLogisticoId", "", Context.Request, Server)
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
            Return CInt(clsCommons.strReadCookie("intCompaniaId", "0", Context.Request, Server))
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
            Return CInt(clsCommons.strReadCookie("intSucursalId", "0", Context.Request, Server))
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
            Return clsCommons.strReadCookie("strSucursalNombre", "0", Context.Request, Server)
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
            Return clsCommons.strReadCookie("strUsuarioNombre", "0", Context.Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Obtiene la cadena de conexión hacia la base de datos
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
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
            Return clsConcentrador.strObtenerURLSucursal(intCompaniaId, intSucursalId, Me.strConnectionString)
        End Get
    End Property

    '====================================================================
    ' Name       : strbtnAceptar
    ' Description: Pinta el boton de aceptar y cancelar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strbtnAceptar() As String
        Get
            Return strmbtnAceptar
        End Get
        Set(ByVal strValue As String)
            strmbtnAceptar = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCmd 
    ' Description: Obtiene o establece el comando actual
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strCmd() As String
        Get
            Return strmCommand
        End Get
        Set(ByVal strValue As String)
            strmCommand = strValue
        End Set
    End Property


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


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, Me.strConnectionString) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        'Calcular fecha actual:
        Me.fechaActual.Text = Now.ToString(clsDateUtil.DATE_FORMAT)
        Me.sucursalNombre.Text = Me.strCentroLogisticoId & " - " & Trim(Me.strSucursalNombre) & " (" & Me.intCompaniaId.ToString & Me.intSucursalId.ToString("000") & ")"

        '' Almacenamos el comando ejecutado
        'strCmd = com.isocraft.commons.clsWeb.strGetPageParameter("strCmd", com.isocraft.commons.clsWeb.strGetPageParameter("cmdConsultar", ""), Request)

        'Select Case strCmd
        '    Case "Imprimir"

        '    Case "Capturar"
        '        Response.Redirect("InventarioLibreImpresionFormato.aspx?intCompaniaId=&intSucursalId=&intListadoId=&dtmFecha=")

        'End Select

    End Sub


    Public Sub btnImprimirFormato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirFormato.ServerClick
        Session.Add("printDocument", Me)
        Dim script As String = "<script for=window event=onload>printDocument()</script>"
        Page.RegisterClientScriptBlock("openWindowScript", script)
    End Sub


#Region "metodos privados"

    Private Function sucursalNombreCompleto() As String
        Return Me.strCentroLogisticoId & " - " & Trim(Me.strSucursalNombre) & " (" & Me.intCompaniaId.ToString & Me.intSucursalId.ToString("000") & ")"
    End Function

#End Region

#Region "metodos de la interface PrintInterface"

    Function addPagination() As Boolean Implements PrintInterface.addPagination
        Return True
    End Function

    Function getHeaders() As String Implements PrintInterface.getHeaders
        Dim code As StringBuilder = New StringBuilder

        Dim widths As String() = {"20%", "20%", "20%"}
        Dim values As String() = {"#", "Código del Producto", "Cantidad"}

        code.Append(clsHTMLUtils.getTagTR("th", 4, "rayita", "txcont", widths, values))

        Return code.ToString
    End Function

    Function getTitle(ByVal currentPage As Integer, ByVal totalPages As Integer) As String Implements PrintInterface.getTitle
        Dim code As StringBuilder = New StringBuilder
        Dim widths As String() = {"20%", "50%", "10%", "20%"}
        Dim styles As String() = {"txtitulo", "txcontenidobold", "txcontenidobold"}
        Dim values2 As String() = {"Sucursal:", Me.sucursalNombreCompleto(), "", "Fecha: " + Today.ToString(clsDateUtil.DATE_FORMAT)}

        Dim title1 As String = " <tr><td class='txtitulo' colspan='3' width='80%'>Listado para Toma de Inventarios Libres</td>"
        title1 += "<td class='txcontenidobold' width='20%'>HOJA: " + currentPage.ToString + " / " + totalPages.ToString + "</td></tr>"

        code.Append(clsHTMLUtils.BEGIN_TABLE)
        code.Append(title1)
        code.Append(clsHTMLUtils.getTagTR("td", 4, "txcontenidobold", widths, values2))
        code.Append(clsHTMLUtils.END_TABLE)

        Return code.ToString
    End Function

    Function getRow(ByVal aRow As Array, ByVal globalRowCounter As Integer) As String Implements PrintInterface.getRow

        Dim code As StringBuilder = New StringBuilder
        code.Append("<tr>")
        code.Append(clsPrintUtil.getCell(globalRowCounter.ToString, "tdblancoSinRaya"))
        code.Append(clsPrintUtil.getCell("___________", "tdblancoSinRaya"))
        code.Append(clsPrintUtil.getCell("___________", "tdblancoSinRaya"))
        code.Append("</tr>")
        Return code.ToString

    End Function

    Function getFooter() As String Implements PrintInterface.getFooter
        'regresar Captura de Cifra de control
        Dim code As StringBuilder = New StringBuilder

        code.Append("<tr>")
        code.Append(" <td colspan='2' class='tdblancoSinRaya9px' align='right'>Cifra de Control:</td>")
        code.Append(" <td class='tdblancoSinRaya9px'>___________</td>")
        code.Append("</tr>")

        Return code.ToString
    End Function

    Function getData() As Array Implements PrintInterface.getData

        'crear un array de intTotalLineas
        Dim i As Integer = 1
        Dim total As Integer = CInt(intTotalLineas.Text)
        Dim dimensions As Integer() = {total}
        Dim stringArray As String()
        Dim dataArray As Array = Array.CreateInstance(Type.GetType("System.String"), dimensions)

        'For i = 1 To total
        '    Dim newArray As String() = {i.ToString, "", ""}
        '    dataArray.SetValue(newArray, i - 1)
        '    'dataArray(i - 1, 0) = i
        '    'dataArray(i - 1, 1) = ""
        '    'dataArray(i - 1, 2) = ""
        'Next

        Return dataArray
    End Function

    Function getColumnNumber() As Integer Implements PrintInterface.getColumnNumber
        Return 3
    End Function

#End Region


End Class
