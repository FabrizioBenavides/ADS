Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports System.Text
Imports System.Collections
Imports Benavides.POSAdmin.Commons

'====================================================================
' Class         : AsignacionDeArticuloServiciosVirtuales
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Sucursal
' Copyright     : 2013 All rights reserved.
' Company       : Softtek
' Author        : Eloy Barreras
' Version       : 1.0
' Last Modified : 
' Modified by   :  
'====================================================================

Public Class AsignacionDeArticuloServiciosVirtuales
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

        intTipoServicioVirtualId = GetPageParameter("intTipoServicioId", 0)
        intServicioVirtualId = GetPageParameter("intServicioVirtualId", 0)

        strTipoServicioVirtualDescripcion = GetPageParameter("txtTipoServicioVirtualDescripcion", "")

    End Sub

#End Region

#Region " Class Private Attributes"

    Private intmTipoServicioVirtualId As Integer
    Private intmServicioVirtualId As Integer
    Private strmTipoServicioVirtualDescripcion As String
    Private intmSelectedPage As Integer
    Private strmJavascriptWindowOnLoadCommands As String


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
    ' Name       : intTipoServicioVirtualId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intTipoServicioVirtualId() As Integer
        Get
            Return intmTipoServicioVirtualId
        End Get
        Set(ByVal intValue As Integer)
            intmTipoServicioVirtualId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intServicioVirtualId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualId() As Integer
        Get
            Return intmServicioVirtualId
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoServicioVirtualDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTipoServicioVirtualDescripcion() As String
        Get
            Return strmTipoServicioVirtualDescripcion
        End Get
        Set(ByVal strValue As String)
            strmTipoServicioVirtualDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strGetRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 10
        Const strRecordBrowserName As String = "SucursalServiciosVirtualesAsignacionArticulo" '

        ' Declaramos e inicializamos las variables locales

        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim astrDataArray As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtual.strBuscar(intTipoServicioVirtualId, 0, strConnectionString)

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?intTipoServicioId=" & intTipoServicioVirtualId & "&")

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Select Case strCmd

            Case "Asignar"

                ' Si el identificador del elemento es válido
                If intTipoServicioVirtualId > 0 Then

                    ' Obtenemos el elemento
                    Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsTipoServicioVirtual.strBuscar(intTipoServicioVirtualId, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        Dim aobjRow As System.Array = DirectCast(aobjData.GetValue(0), System.Array)

                        ' Recuperamos sus datos
                        intTipoServicioVirtualId = CInt(aobjRow.GetValue(0))
                        strTipoServicioVirtualDescripcion = CStr(aobjRow.GetValue(1))

                    End If

                End If

            Case "Editar"

                ' Si el identificador del elemento es válido
                If intTipoServicioVirtualId > 0 Then

                    ' Obtenemos el elemento
                    Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsTipoServicioVirtual.strBuscar(intTipoServicioVirtualId, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        'Mandamos llamar a la pagina de servicios virtuales
                        Response.Redirect("SucursalAsignacionDeArticuloDPServiciosVirtuales.aspx?strCmd=Editar&intTipoServicioId=" & CStr(intTipoServicioVirtualId) & "&intServicioID=" & CStr(intServicioVirtualId))

                    End If

                End If

        End Select
    End Sub

End Class
