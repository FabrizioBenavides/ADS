'====================================================================
' Page          : MercanciaConsultaComprasDirectas.aspx
' Title         : Administracion POS y BackOffice
' Description   : P�gina para hacer consulta de las Compras Directas
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : J.Antonio Hern�ndez D�vila
' Version       : 1.0
' Last Modified : Sabado 25, 2003   
'====================================================================

Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text
Imports System.DateTime

Public Class clsMercanciaConsultaComprasDirectas
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

    Dim strmMensaje As String
    Dim strmRecordBrowserHTML As String

    '====================================================================
    ' Name       : strRedirectPage
    ' Description: P�gina hacia la cual se debe redireccionar al usuario
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
    ' Description: Valor de la acci�n de la forma HTML
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
    ' Description: URL de esta p�gina
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
    ' Description: Valor de la Compa�ia
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
    ' Name       : cmbTipoCaptura
    ' Description: Valor del radio boton
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property cmbTipoCaptura() As String
        Get
            If Not IsNothing(Request.QueryString("cmbTipoCaptura")) Then
                Return Request.QueryString("cmbTipoCaptura")
            Else
                Return "0"
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
    ' Name       : strCmd
    ' Description: Valor del par�metro strCmd
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return Request.QueryString("strCmd")
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Control de Acceso de la p�gina
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        Dim intMesBusqueda As Integer = 0
        Dim intOrdenBusqueda As Integer = 0
        Dim strTipoCaptura As String = ""

        intMesBusqueda = CInt(rdoFiltroConsulta)
        intOrdenBusqueda = CInt(rdoOrdenConsulta)
        strTipoCaptura = cmbTipoCaptura

        strRecordBrowserHTML = ""

        If Len(Request("cmdConsultar")) > 0 Then
            Dim objArrayComprasDirectas As Array = Nothing

            Dim strRecordBrowseComplemento As StringBuilder
            Dim strRecordBrowserConsulta As String = ""
            Dim strTargetURL As String = "MercanciaDetalleCompraDirecta.aspx?cmdConsultar=Consultar&rdoFiltroConsulta=" & rdoFiltroConsulta.ToString & "&rdoOrdenConsulta=" & rdoOrdenConsulta.ToString & "&"

            strRecordBrowseComplemento = New StringBuilder

            'Consulta las Notas de compras Directas
            objArrayComprasDirectas = clsConcentrador.clsSucursal.clsMercancia.clsCompras.strBuscar(intCompaniaId, intSucursalId, 0, intMesBusqueda, intOrdenBusqueda, strTipoCaptura, 0, 0, strCadenaConexion)

            ' Validamos que sea la respuesta sea un arreglo valido
            If IsArray(objArrayComprasDirectas) AndAlso objArrayComprasDirectas.Length > 0 Then
                ' Generamos el Navegador de Registros                
                strRecordBrowserConsulta = clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaConsultaComprasDirectas", objArrayComprasDirectas, 1, objArrayComprasDirectas.Length, strTargetURL))
            Else
                strMensaje = "No hay inofrmaci�n para la consulta seleccionada "
            End If

            If strRecordBrowserConsulta.Length > 0 Then
                strRecordBrowseComplemento.Append("<div id='ToPrintHtmContenido'>")
                strRecordBrowseComplemento.Append("<table	width='100%' border='0' cellpadding='0' cellspacing='0'>")
                strRecordBrowseComplemento.Append(strRecordBrowserConsulta)
                strRecordBrowseComplemento.Append("</div>")
                strRecordBrowseComplemento.Append("<br>")
                strRecordBrowseComplemento.Append("<input name='cmdOtra'     type='button' class='boton' value='OtraConsulta' onclick='return cmdOtra_onclick()'> &nbsp;&nbsp;&nbsp;")
                strRecordBrowseComplemento.Append("<input name='cmdImprimir' type='button' class='boton' value='ImprimirConsulta' onclick='return cmdImprimir_onclick()'> ")
                strRecordBrowserHTML = strRecordBrowseComplemento.ToString
            End If

        End If

    End Sub

End Class
