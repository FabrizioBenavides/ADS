Imports Benavides.CC.Business
Imports Benavides.POSAdmin.Commons
Imports System.Configuration
Imports System.Text

Public Class clsMercanciaArchivoProductosAgotados
    Inherits System.Web.UI.Page

    Private strmRecordBrowserHTML As String = ""

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
    ' Name       : strRecordBrowserHTML
    ' Description: RecordBrowser
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRecordBrowserHTML() As String
        Get
            Return strmRecordBrowserHTML
        End Get
        Set(ByVal strValue As String)
            strmRecordBrowserHTML = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Comando
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Not IsNothing(Request.QueryString("strCmd")) Then
                Return Request.QueryString("strCmd")
            Else
                Return ""
            End If
        End Get
    End Property
    '====================================================================
    ' Name       : strGeneraBotonesHTML
    ' Description: Genera Botones en HTML
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGeneraBotonesHTML() As String
        Dim strHTML As StringBuilder

        If strRecordBrowserHTML.Length > 0 Then
            strHTML = New StringBuilder

            strHTML.Append("<input name='cmdRegresar' type='button' class='boton' value='Regresar' onClick='return cmdRegresar_onClick()'>&nbsp;&nbsp;")
            strHTML.Append("<input name='cmdLimpiar' type='button' class='boton' value='Limpiar' onClick='return cmdLimpiar_onClick()'>")
            Return strHTML.ToString
        Else
            Return ""
        End If
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
        Dim objDataArray As Array = Nothing
        Dim dtmFechaInicial As Date
        Dim dtmFechaFinal As Date
        Dim strTargetURL As String


        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        ' Validamos si se hizo click en el botón de consulta
        If Not IsNothing(Request.Form("cmdConsultar")) OrElse strCmd.Equals("Consultar") Then
            If Len(Request.Form("cmdConsultar")) > 0 OrElse strCmd.Equals("Consultar") Then

                ' Asignamos los valores a las variables

                If Len(Request.Form("dtmFechaInicial")) > 0 Then
                    dtmFechaInicial = CDate(clsCommons.strDMYtoMDY(Request.Form("dtmFechaInicial")))
                    dtmFechaFinal = CDate(clsCommons.strDMYtoMDY(Request.Form("dtmFechaFinal")))

                    strTargetURL = "MercanciaDetalleProductosAgotados.aspx?dtmFechaInicial=" & Request.Form("dtmFechaInicial") & "&dtmFechaFinal=" & Request.Form("dtmFechaFinal") & "&"

                    ' Traemos información de los productos agotados
                    objDataArray = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarInventarioAgotado(intCompaniaId, intSucursalId, 0, dtmFechaInicial, dtmFechaFinal, 0, 0, strCadenaConexion)

                    ' Validamos que sea un arreglo valido 
                    If IsArray(objDataArray) Then
                        If objDataArray.Length > 0 Then

                            strmRecordBrowserHTML = clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaArchivoProductosAgotados", objDataArray, 1, objDataArray.Length, strTargetURL))
                        End If
                    End If

                End If
            End If
        End If

    End Sub

End Class
