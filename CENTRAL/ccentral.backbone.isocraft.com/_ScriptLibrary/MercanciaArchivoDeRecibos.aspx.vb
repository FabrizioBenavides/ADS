'====================================================================
' Page          : MercanciaArchivodeRecibos.aspx
' Title         : Administracion POS y BackOffice
' Description   : Página Consulta las Transferencias Recibidas
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : J.Antonio Hernández Dávila
' Version       : 1.0
' Last Modified : Viernes, Octubre 24, 2003   
'====================================================================

Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text
Imports System.DateTime


Public Class clsMercanciaArchivoDeRecibos

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

    Private strmMensaje As String = ""
    Private strmRecordBrowserHTML As String


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
    ' Description: Valor que tomara la variable strmCadenaConexion
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
    ' Name       : strMensaje
    ' Description: Fecha de Emision de la Factura Electronica Consultada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '====================================================================  
    Public Property strMensaje() As String
        Get
            Return strmMensaje
        End Get
        Set(ByVal Value As String)
            strmMensaje = Value
        End Set
    End Property

    '====================================================================
    ' Name       : rdoFiltroConsulta
    ' Description: Valor del radio boton
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property rdoFiltroConsulta() As String
        Get
            If Not IsNothing(Request.Form("rdoFiltroConsulta")) Then
                Return Request.Form("rdoFiltroConsulta")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmInicio
    ' Description: Fecha Inicial de la consulta
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmInicio() As String
        Get
            If Not IsNothing(Request.Form("dtmInicio")) Then
                Return Request.Form("dtmInicio")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFin
    ' Description: Fecha final de la consulta
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFin() As String
        Get
            If Not IsNothing(Request.Form("dtmFin")) Then
                Return Request.Form("dtmFin")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: RecordBrowser de Recibos
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRecordBrowserHTML() As String
        Get
            Return strmRecordBrowserHTML
        End Get
        Set(ByVal Value As String)
            strmRecordBrowserHTML = Value
        End Set

    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        strRecordBrowserHTML = ""

        If Len(Request("cmdConsultar")) > 0 Then

            ' Declaración e inicialización de las variables locales
            Dim strTargetURL As String = "MercanciaDetalleReciboTransferencia.aspx?"

            Dim dtmFechaActual As Date
            Dim dtmFechaInicial As Date
            Dim dtmFechaFinal As Date

            Select Case rdoFiltroConsulta
                Case "1" 'Mes Actual
                    dtmFechaActual = Date.Now

                    dtmFechaInicial = CDate(dtmFechaActual.Month.ToString & "/" & "01" & "/" & dtmFechaActual.Year)
                    dtmFechaFinal = CDate(dtmFechaActual.Month.ToString & "/" & dtmFechaActual.DaysInMonth(dtmFechaActual.Year, dtmFechaActual.Month) & "/" & dtmFechaActual.Year)

                Case "2" 'Mes Anterior
                    dtmFechaActual = Date.Now.AddMonths(-1)

                    dtmFechaInicial = CDate(dtmFechaActual.Month & "/" & "01" & "/" & dtmFechaActual.Year)
                    dtmFechaFinal = CDate(dtmFechaActual.Month & "/" & dtmFechaActual.DaysInMonth(dtmFechaActual.Year, dtmFechaActual.Month) & "/" & dtmFechaActual.Year)

                Case "3" 'Rango de Fechas
                    dtmFechaInicial = CDate(clsCommons.strDMYtoMDY(dtmInicio))
                    dtmFechaFinal = CDate(clsCommons.strDMYtoMDY(dtmFin))
            End Select

            Dim objArrayRecibos As Array = Nothing

            objArrayRecibos = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.strBuscarArchivoRecibos(intCompaniaId, intSucursalId, "RECIBIDA", dtmFechaInicial, dtmFechaFinal, 0, 0, strCadenaConexion)

            ' Validamos que sea un arreglo valido
            If IsArray(objArrayRecibos) AndAlso objArrayRecibos.Length > 0 Then
                ' Generamos el Navegador de Registros
                strRecordBrowserHTML = clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaArchivodeRecibos", objArrayRecibos, 1, objArrayRecibos.Length, strTargetURL))
            Else
                strMensaje = "No hay inofrmación para la consulta seleccionada "
            End If

        End If


    End Sub

End Class
