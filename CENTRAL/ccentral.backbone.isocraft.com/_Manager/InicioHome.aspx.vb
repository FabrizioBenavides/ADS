'====================================================================
' Class         : clsInicioHome
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Inicio
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Joaqu�n Hern�ndez Garc�a
' Version       : 1.0
' Last Modified : Thursday, June 24, 2004
'====================================================================
Public Class clsInicioHome
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
    ' Description: Genera la fecha y hora de la p�gina
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
    ' Description: URL de esta p�gina
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
    ' Name       : strFirstRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strFirstRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 3
        Const strRecordBrowserName As String = "SistemaConsultarActualizacionesPendientes"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1"))

        ' Buscamos las sucursales de esta direcci�n y zona
        Dim astrDataArray As Array = Benavides.CC.Data.clsTransmision.strEjecutarBuscarActualizacionesPendientesPorDireccion(0, 1, 100, strConnectionString)

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, "SistemaConsultarActualizacionesPendientes.aspx?").Replace("Reporte de cortes en cero", "Actualizaciones pendientes").Replace("<br>", "")

    End Function

    '====================================================================
    ' Name       : strSecondRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strSecondRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 3
        Const strRecordBrowserName As String = "SistemaTransmisionesPendientes"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1"))

        ' Buscamos las sucursales de esta direcci�n y zona
        Dim astrDataArray As Array = Benavides.CC.Data.clsTransmision.strEjecutarBuscarTransmisionesPendientes(0, 0, 0, 0, strConnectionString)

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, "SistemaConsultarTransmisionesPendientes.aspx?").Replace("<br>", "")

    End Function

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Obtiene la cadena de conexi�n hacia la base de datos
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la p�gina de acceso, si no tiene privilegios de acceder a esta p�gina
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

    End Sub

End Class
