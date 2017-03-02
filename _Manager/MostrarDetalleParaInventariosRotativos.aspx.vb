'====================================================================
' Class         : clsMostrarDetalleParaInventariosRotativos
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Detalle de Importacion de datos
' Copyright     : 2003-2006 All rights reserved.
' Company       : Neitek Solutions S.A. de C.V.
' Author        : Carolina Caballero
' Version       : 1.0
' Last Modified : Monday, Oct 18, 2004
'====================================================================

Imports System.Text
Imports System.Collections

Imports prjCCInventarioBusiness.Benavides.InvRot.Utils
Imports prjCCInventarioBusiness.Benavides.InvRot.Data


Public Class clsMostrarDetalleParaInventariosRotativos
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

    ' Variables locales privadas
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private _intListadoId As Integer
    Private _strNombre As String
    Private _intCompaniaId As Integer
    Private _intSucursalId As Integer
    Private _dtmFechaTomaInventario As DateTime
    Private _dtmUltimaModificacion As DateTime

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
    ' Name       : intGrupoUsuarioId
    ' Description: Identificador del Grupo de Usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
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
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime(clsDateUtil.DATE_HOUR_FORMAT)
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
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request)
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
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: Establece los comandos Javascript del evento OnLoad
    ' Accessor   : Read
    ' Throws     : Ninguna
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
    ' Name       : intListadoId 
    ' Description: Obtiene o establece el listado id
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intListadoId() As Integer
        Get
            Return _intListadoId
        End Get
        Set(ByVal strValue As Integer)
            _intListadoId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intCompaniaId 
    ' Description: Obtiene o establece el compania id
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intCompaniaId() As Integer
        Get
            Return _intCompaniaId
        End Get
        Set(ByVal strValue As Integer)
            _intCompaniaId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intSucursalId 
    ' Description: Obtiene o establece el sucursal id
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intSucursalId() As Integer
        Get
            Return _intSucursalId
        End Get
        Set(ByVal strValue As Integer)
            _intSucursalId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : dtmFechaTomaInventario 
    ' Description: Obtiene o establece la fecha de toma de inventario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : DateTime
    '====================================================================
    Public Property dtmFechaTomaInventario() As DateTime
        Get
            Return _dtmFechaTomaInventario
        End Get
        Set(ByVal strValue As DateTime)
            _dtmFechaTomaInventario = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : dtmUltimaModificacion 
    ' Description: Obtiene o establece la fecha ultima modificacion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : DateTime
    '====================================================================
    Public Property dtmUltimaModificacion() As DateTime
        Get
            Return _dtmUltimaModificacion
        End Get
        Set(ByVal strValue As DateTime)
            _dtmUltimaModificacion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strNombre
    ' Description: Obtiene o establece el nombre del listado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strNombre() As String
        Get
            Return _strNombre
        End Get
        Set(ByVal strValue As String)
            _strNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 1
        Dim strRecordBrowserName As String = "MostrarDetalleParaInventariosRotativos"

        ' Declaramos e inicialziamos las variables locales
        Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        If intSelectedPage <= 0 Then
            'intSelectedPage = 1
            intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
        End If
        Dim dataArray As Array = Nothing



        ' Obtenemos los listados que ya se han capturado previamente.
        dataArray = clsImportar.strBuscarDetalle(intListadoId, intCompaniaId, intSucursalId, dtmFechaTomaInventario, dtmUltimaModificacion, Me.strUsuarioNombre, Me.strConnectionString)

        Dim headers As ArrayList = New ArrayList()
        headers.Add("Compañía")
        headers.Add("Sucursal")
        headers.Add("Fecha Toma de Inventario")
        headers.Add("# Artículo")
        headers.Add("Artículo Descripción")

        Dim columnOrder As Integer() = {0, 1, 3, 5, 6}

        Dim actions As ArrayList = New ArrayList()
        Dim pkNames As String() = {}
        Dim pkIndexes As Integer() = {}

        Dim htmlResult As String = ""
        Dim maxPerPage As Integer = 20  'paginacion de 20 en 20
        htmlResult = clsHTMLUtils.displayScroll(dataArray.Length, intSelectedPage, maxPerPage, "MostrarDetalleParaInventariosRotativos.aspx", Nothing)
        htmlResult += clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, intSelectedPage, maxPerPage, -1)

        Return htmlResult
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        strCmd = com.isocraft.commons.clsWeb.strGetPageParameter("strCmd", com.isocraft.commons.clsWeb.strGetPageParameter("cmdConsultar", ""), Request)

        ' Almacenamos el id del listado seleccionado

        intListadoId = CInt(Request("intListadoId"))
        intCompaniaId = CInt(Request("intCompaniaId"))
        intSucursalId = CInt(Request("intSucursalId"))

        dtmFechaTomaInventario = clsDateUtil.StringToDate(Request("dtmArticuloListadoFechaTomaInventario"), "dd/MM/yyyy")
        dtmUltimaModificacion = CDate(Request("dtmArticuloListadoUltimaModificacion"))
    End Sub

End Class

