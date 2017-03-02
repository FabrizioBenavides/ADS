Imports Isocraft.Web.Http

'====================================================================
' Class         : clsSistemaAdministrarClientes
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Joaquín Hdz. G. (joaquin@isocraft.com)
' Last Modified : Monday, January 10, 2005
'====================================================================

Public Class clsSistemaAdministrarClientes
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

        ' Initialize class properties
        strClienteEspecialNombreId = GetPageParameter("txtClienteEspecialNombreId", GetPageParameter("strClienteEspecialNombreId", ""))
        strClienteEspecialNombre = GetPageParameter("txtClienteEspecialNombre", GetPageParameter("strClienteEspecialNombre", ""))
        intGrupoClienteEspecialId = GetPageParameter("cboGrupoClienteEspecial", GetPageParameter("intGrupoClienteEspecialId", 0))
    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private strmtxtClienteEspecialNombreId As String
    Private strmtxtClienteEspecialNombre As String
    Private intmtxtGrupoClienteEspecialId As Integer

#End Region

    '====================================================================
    ' Name       : strFormAction
    ' Description: HTML form's action property value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormAction() As String
        Get
            Return strThisPageName
        End Get
    End Property

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Connection string
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Private ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: Name of this page
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return Server.UrlEncode(GetPageName())
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
    ' Name       : strCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return GetPageParameter("strCmd", "")
        End Get
    End Property

    '====================================================================
    ' Name       : strClienteEspecialNombreId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strClienteEspecialNombreId() As String
        Get
            Return strmtxtClienteEspecialNombreId
        End Get
        Set(ByVal strValue As String)
            strmtxtClienteEspecialNombreId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strClienteEspecialNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strClienteEspecialNombre() As String
        Get
            Return strmtxtClienteEspecialNombre
        End Get
        Set(ByVal strValue As String)
            strmtxtClienteEspecialNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intGrupoClienteEspecialId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intGrupoClienteEspecialId() As Integer
        Get
            Return intmtxtGrupoClienteEspecialId
        End Get
        Set(ByVal intValue As Integer)
            intmtxtGrupoClienteEspecialId = intValue
        End Set
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
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strHTMLFechaHora
    ' Description: Genera la fecha y hora de la página
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
        End Get
    End Property

    '====================================================================
    ' Name       : strLlenarGrupoClienteEspecialComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboGrupoClienteEspecial"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarGrupoClienteEspecialComboBox() As String
        Dim aobjData As Array = Benavides.CC.Data.clstblGrupoClienteEspecial.strBuscar(0, "", "", Now(), "", 0, 0, strConnectionString)
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboGrupoClienteEspecial", intGrupoClienteEspecialId, aobjData, 0, 1, 1)
    End Function

    '====================================================================
    ' Name       : strGetRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 50
        Const strRecordBrowserName As String = "SistemaAdministrarClientes"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim astrDataArray As Array = Benavides.CC.Data.clsClienteEspecial.strBuscar(0, intGrupoClienteEspecialId, strClienteEspecialNombreId, strClienteEspecialNombre, False, 0, Now(), 0, 0, Now(), "", 0, 0, False, False, False, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)
        Dim astrDataRow As Array

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?intGrupoClienteEspecialId=" & intGrupoClienteEspecialId & "&strClienteEspecialNombreId=" & strClienteEspecialNombreId & "&strClienteEspecialNombre=" & strClienteEspecialNombre & "&")

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Check if the current user can access this page
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Execute the selected command
        Select Case strCmd

            Case "Editar"

                Dim intClienteEspecialId As Integer = GetPageParameter("intClienteEspecialId", 0)

                ' Si el identificador del elemento es válido
                If intClienteEspecialId > 0 Then
                    Call Response.Redirect("SistemaEditarCliente.aspx?strCmd=Editar&intClienteEspecialId=" & intClienteEspecialId)
                End If

        End Select

    End Sub

End Class
