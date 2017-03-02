'====================================================================
' Class         : clsInventarioLibreConsulta
' Title         : Grupo Benavides. Inventarios Rotativos.
' Description   : Consulta de Inventarios Libres
' Copyright     : 2003-2006 All rights reserved.
' Company       : Neitek Solutions S.A. de C.V.
' Author        : Carolina Caballero
' Version       : 1.0
' Last Modified : Monday, October 25th, 2004
'====================================================================


Imports System.Configuration
Imports System.Text
Imports System.Collections

Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports prjCCInventarioBusiness.Benavides.InvRot.Utils
Imports prjCCInventarioBusiness.Benavides.InvRot.Data

Public Class clsInventarioLibreConsulta
    Inherits System.Web.UI.Page

    'Variables globales
    Dim strmbtnAceptar As String = ""
    Private strmCommand As String
    Protected WithEvents btnAceptar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents dtmFechaFinal As System.Web.UI.WebControls.TextBox
    Protected WithEvents dtmFechaInicial As System.Web.UI.WebControls.TextBox



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

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Genera el HTML para el record browser con los listados
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================

    Public Function strRecordBrowserHTML() As String

        If Me.dtmFechaFinal.Text = "" AndAlso Me.dtmFechaInicial.Text = "" Then
            Return ""
        End If

        ' Declaramos e inicializamos las constantes locales
        Dim htmlResult As String = ""
        Const intElementsPerPage As Integer = 1
        Dim dataArray As Array = Nothing

        ' Declaramos e inicialziamos las variables locales
        Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        If intSelectedPage <= 0 Then
            'intSelectedPage = 1
            intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
        End If

        ' Obtenemos los listados inventarios Rotativos para la sucursal
        Dim fechaInicial As DateTime = clsDateUtil.StringToDate(Me.dtmFechaInicial.Text, clsDateUtil.DATE_FORMAT)
        Dim fechaFinal As DateTime = clsDateUtil.StringToDate(Me.dtmFechaFinal.Text, clsDateUtil.DATE_FORMAT)

        dataArray = clstblInventarioLibre.strBuscarInventariosLibres(intCompaniaId, intSucursalId, fechaInicial, fechaFinal, strConnectionString)

        Dim headers As ArrayList = New ArrayList()
        headers.Add("Folio")
        headers.Add("Fecha")
        headers.Add("Acciones")

        Dim columnOrder As Integer() = {1, 2}

        Dim actions As ArrayList = New ArrayList()
        Dim pkNames As String() = {"intTimestamp", "intFolioId", "dtmFechaTomaInventario"}
        Dim pkIndexes As Integer() = {0, 1, 2}
        actions.Add(New clsActionLink("Seleccionar", pkNames, pkIndexes, "icono_editar.gif", "Haga clic aquí para seleccionar este Inventario Libre"))


        Dim maxPerPage As Integer = 10
        htmlResult = clsHTMLUtils.displayScroll(dataArray.Length, intSelectedPage, maxPerPage, "ListadoParaInventariosRotativos.aspx", Nothing)
        htmlResult += clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, intSelectedPage, maxPerPage, -1)

        Return htmlResult


    End Function


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
        Me.dtmFechaInicial.Text = Request("dtmFechaInicial")
        Me.dtmFechaFinal.Text = Request("dtmFechaFinal")

    End Sub

#End Region


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, Me.strConnectionString) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

    End Sub

    Public Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.ServerClick


    End Sub

    Private Function sucursalNombreCompleto() As String
        Return Me.intCompaniaId.ToString + " - " + Me.intSucursalId.ToString + " " + Me.strSucursalNombre
    End Function


End Class
