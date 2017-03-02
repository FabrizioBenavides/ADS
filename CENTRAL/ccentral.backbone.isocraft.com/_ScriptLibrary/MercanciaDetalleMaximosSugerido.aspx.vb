'====================================================================
' Page          : MercanciaArchivoMaximoSugerido.aspx
' Title         : Administracion POS y BackOffice
' Description   : Página Consulta 
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : J.Antonio Hernández Dávila
' Version       : 1.0
' Last Modified : Martes, Noviembre 18, 2003   
'====================================================================

Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text
Imports System.DateTime

Public Class MercanciaDetalleMaximosSugerido
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
    Private strmRecordBrowserHTML As String = ""

    Private intmFolioMaximo As Integer
    Private strmFechaMaximo As String

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
    ' Name       : rdoFiltroConsulta
    ' Description: Valor del radio boton
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property rdoFiltroConsulta() As String
        Get
            If Not IsNothing(Request.QueryString("rdoFiltroConsulta")) Then
                Return Request.QueryString("rdoFiltroConsulta")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : rdoOrdenConsulta
    ' Description: Valor del radio boton
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property rdoOrdenConsulta() As String
        Get
            If Not IsNothing(Request.QueryString("rdoOrdenConsulta")) Then
                Return Request.QueryString("rdoOrdenConsulta")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intFolioMaximoId
    ' Description: Llave Reclamación
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intInventarioSugeridoFolioId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intInventarioSugeridoFolioId")) Then
                Return CInt(Request.QueryString("intInventarioSugeridoFolioId"))
            Else
                Return 0
            End If
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

    '====================================================================
    ' Name       : strRegistrosRecordBrowser
    ' Description: Registros en el RecordBrowser
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public ReadOnly Property strRegistrosRecordBrowser() As String
        Get
            If strRecordBrowserHTML.Length > 0 Then
                Return strRecordBrowserHTML.Length.ToString
            Else
                Return ""
            End If
        End Get
    End Property


    Public Property intFolioMaximo() As Integer
        Get
            Return intmFolioMaximo
        End Get
        Set(ByVal Value As Integer)
            intmFolioMaximo = Value
        End Set
    End Property

    Public Property strFechaMaximo() As String
        Get
            Return strmFechaMaximo
        End Get
        Set(ByVal Value As String)
            strmFechaMaximo = Value
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If intInventarioSugeridoFolioId = 0 Then
            Call Response.Redirect("MercanciaArchivoMaximoSugerido.aspx")
        End If

        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        Dim objArrayMaximo As Array = Nothing
        Dim strRegistroMaximo As String() = Nothing

        'Buscamos la Reclamación para datso generales
        objArrayMaximo = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarInventarioSugerido(intCompaniaId, intSucursalId, intInventarioSugeridoFolioId, 0, 0, 0, 0, strCadenaConexion)

        If IsArray(objArrayMaximo) AndAlso objArrayMaximo.Length > 0 Then
            strRegistroMaximo = DirectCast(objArrayMaximo.GetValue(0), String())

            intFolioMaximo = CInt(strRegistroMaximo(0))

            strFechaMaximo = clsCommons.strFormatearFechaPresentacion(strRegistroMaximo(1))

            Dim objArrayDetalleMaximo As Array = Nothing

            ' Buscamos el detalle de la reclamación
            objArrayDetalleMaximo = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarDetalleSugerido(intFolioMaximo, intCompaniaId, intSucursalId, 0, 0, strCadenaConexion)

            If IsArray(objArrayDetalleMaximo) AndAlso objArrayDetalleMaximo.Length > 0 Then
                ' Generamos el Navegador de Registros                
                strRecordBrowserHTML = clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaDetalleArchivoMaximoSugerido", objArrayDetalleMaximo, 1, objArrayDetalleMaximo.Length, ""))
            Else
                strMensaje = "No se encontro el Detalle " & intFolioMaximo.ToString

            End If
        Else
            strMensaje = "No se Encontro el Folio"
        End If

    End Sub

End Class
