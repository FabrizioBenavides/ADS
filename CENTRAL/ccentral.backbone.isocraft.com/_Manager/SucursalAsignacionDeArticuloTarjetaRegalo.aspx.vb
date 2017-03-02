Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports System.Text
Imports System.Collections
Imports Benavides.POSAdmin.Commons

'====================================================================
' Class         : SucursalAsignacionDeArticuloTarjetaRegalo
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Sucursal
' Copyright     : 2013 All rights reserved.
' Company       : Softtek
' Author        : Juan Pablo Martinez Bautista (JPMB)
' Version       : 1.0 
' Last Modified : 
' Modified by   : 
'====================================================================
Public Class SucursalAsignacionDeArticuloTarjetaRegalo
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

        'Inicializa(Propiedades)
        intSelectedPage = GetPageParameter("intNavegadorRegistrosPagina", GetPageParameter("txtRecordBrowserSelectedPage", 1))

        IntTarjetaRegaloId = GetPageParameter("IntTarjetaRegaloId", 0)

    End Sub

#End Region

#Region " Class Private Attributes"

    Private intmSelectedPage As Integer

    Private strmJavascriptWindowOnLoadCommands As String
    Private IntmTarjetaRegaloId As Integer
    Private intmEmpresaServicioIdAnterior As Integer


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
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)
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
    ' Name       : strHTMLFechaHora
    ' Description: Genera la fecha y hora de la página
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
        End Get
    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: URL de esta página
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request)
        End Get
    End Property

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Obtiene la cadena de conexión hacia la base de datos
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
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
    ' Name       : intSelectedPage
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intSelectedPage() As Integer
        Get
            Return intmSelectedPage
        End Get
        Set(ByVal intValue As Integer)
            intmSelectedPage = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : IntTarjetaRegaloId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property IntTarjetaRegaloId() As Integer
        Get
            Return IntmTarjetaRegaloId
        End Get
        Set(ByVal intValue As Integer)
            IntmTarjetaRegaloId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strGetRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read  intTipoOperacionDEXId
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 10
        Const strRecordBrowserName As String = "SucursalAsignacionDeArticuloTarjetaRegalo"

        ' Declaramos e inicializamos las variables locales

        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim astrDataArray As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsTarjetaRegalo.strBuscarTarjetaRegalo(IntTarjetaRegaloId, strConnectionString)

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?IntTarjetaRegalo=" & IntTarjetaRegaloId & "&")

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Select Case strCmd

            Case "Asignar"
                'Asignar sucursales
                If IntTarjetaRegaloId > 0 Then
                    Call Response.Redirect("SucursalAsignacionDeArticuloDPTarjetaRegalo.aspx?strCmd=" & strCmd & "&IntTarjetaRegaloId=" & IntTarjetaRegaloId)
                End If

            Case "AgregarTipo"

                Call Response.Redirect("SucursalTarjetaRegaloAgregarEditar.aspx?strCmd=" & strCmd)


            Case "Eliminar"

                Benavides.CC.Business.clsConcentrador.clsSucursal.clsTipoServicioVirtual.intEliminar(CInt(IntTarjetaRegaloId), strConnectionString)

            Case "Editar"

                Call Response.Redirect("SucursalTarjetaRegaloAgregarEditar.aspx?strCmd=" & strCmd & "&IntTarjetaRegaloId=" & IntTarjetaRegaloId)

        End Select
    End Sub

End Class
