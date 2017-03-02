Imports Benavides.CC.Business
Imports Benavides.POSAdmin.Commons
Imports System.Configuration

Public Class clsMercanciaDetalleProductosAgotados
    Inherits System.Web.UI.Page

    Private strmFechaConsulta As String = ""

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
    ' Description: URL del POS Admin
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
    ' Name       : intFolioInventarioAgotadoId
    ' Description: Folio Inventario agotado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intFolioInventarioAgotadoId() As Integer
        Get
            If Len(Request.QueryString("intFolioInventarioAgotadoId")) > 0 Then
                Return CInt(Request.QueryString("intFolioInventarioAgotadoId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strFechaConsulta
    ' Description: Fecha de captura
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strFechaConsulta() As String
        Get
            Return strmFechaConsulta
        End Get
        Set(ByVal strValue As String)
            strmFechaConsulta = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Generamos el record browser
    ' Accessor   : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String
        Dim objDataArray As Array = Nothing
        Dim strTargetURL As String = ""

        ' Traemos la información Detalle
        objDataArray = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarDetalleAgotado(intFolioInventarioAgotadoId, intCompaniaId, intSucursalId, 0, 0, strCadenaConexion)

        ' Verificamos que sea valido el arreglo
        If IsArray(objDataArray) Then
            If objDataArray.Length > 0 Then
                Return clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaDetalleProductosAgotados", objDataArray, 1, objDataArray.Length, strTargetURL))
            End If
        End If

        Return ""
    End Function

    '====================================================================
    ' Name       : Page_Load
    ' Description: Evento "Load" de la página
    ' Parameters :
    '              ByVal objSender As System.Object
    '                 - Objeto que genera el Evento
    '              ByVal objEvent As System.EventArgs
    '                 - Argumentos del Evento
    ' Throws     : Ninguna
    ' Output     : Ninguna
    '====================================================================
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objInventarioAgotado As Array = Nothing
        Dim objRegistroInventarioAgotado As String()
        Dim objDetalleAgotado As Array = Nothing

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        ' Si el folio es Cero se direcciona hacia la página padre
        If intFolioInventarioAgotadoId = 0 Then
            Call Response.Redirect("MercanciaArchivoProductosAgotados.aspx")
        End If


        ' Traemos la información del folio inventario agotado
        objInventarioAgotado = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarInventarioAgotado(intCompaniaId, intSucursalId, intFolioInventarioAgotadoId, CDate("01/01/1900"), CDate("01/01/1900"), 0, 0, strCadenaConexion)

        ' Traemos la fecha de captura
        If IsArray(objInventarioAgotado) Then
            If objInventarioAgotado.Length > 0 Then

                objRegistroInventarioAgotado = DirectCast(objInventarioAgotado.GetValue(0), String())

                strFechaConsulta = CDate(objRegistroInventarioAgotado.GetValue(1)).ToString("dd/MM/yyyy")
            End If
        End If
    End Sub

End Class
