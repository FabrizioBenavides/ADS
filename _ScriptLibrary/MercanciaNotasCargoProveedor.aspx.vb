Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class clsMercanciaNotasCargoProveedor
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

    Private strmProveedorId As String = ""
    Private strmRazonSocialProveedor As String = ""
    Private strmRecordBrowserHTML As String = ""
    Private strmTipoNota As String = ""

    '====================================================================
    ' Name       : strRedirectPage
    ' Description: Página hacia la cual se debe redireccionar al usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRedirectPage() As String
        Get
            ' Return "/Default.aspx?strURL=" & Server.UrlEncode(Request.ServerVariables("SCRIPT_NAME"))
            If intCompaniaId > 0 Then
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
    ' Accessor   : Read
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
    ' Name       : strProveedorId
    ' Description: Número de proveedor
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strProveedorId() As String
        Get
            Return strmProveedorId
        End Get
        Set(ByVal strValue As String)
            strmProveedorId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRazonSocialProveedor
    ' Description: Razón social del proveedor
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRazonSocialProveedor() As String
        Get
            Return strmRazonSocialProveedor
        End Get
        Set(ByVal strValue As String)
            strmRazonSocialProveedor = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Genera el RecordBrowser
    ' Accessor   : Read, Write
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
    ' Name       : strTipoFiltro
    ' Description: Tipo de Filtro
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTipoFiltro() As String
        Get
            If Len(Request("rdoFiltro")) > 0 Then

                Select Case CInt(Request("rdoFiltro"))
                    Case 1
                        Return "Del mes actual"
                    Case 2
                        If Len(Request("txtFechaInicial")) > 0 AndAlso Len(Request("txtFechaFinal")) > 0 Then
                            Return "De:  " & Request("txtFechaInicial") & "  Hasta:  " & Request("txtFechaFinal")
                        End If
                End Select
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strTipoNota
    ' Description: Tipo de Nota de Cargo
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strTipoNota() As String
        Get
            Return strmTipoNota
        End Get
        Set(ByVal strValue As String)
            strmTipoNota = strValue
        End Set
    End Property

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

        Dim intNotaCargoProveedorId As Integer = 0
        Dim strTipoNotaCargoNombreId As String = ""
        Dim objDataArray As Array = Nothing
        Dim objRegistro As String() = Nothing
        Dim dtmFechaInicial As String
        Dim dtmFechaFinal As String
        Dim intTipoFiltro As Integer
        Dim intPosicionInicial As Integer = 0
        Dim intElementos As Integer = 0
        Dim intSelectedPage As Integer = 1
        Dim intElementsPerPage As Integer = 0
        Dim strTargetURL As String = ""


        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strRedirectPage)
        End If

        If Len(Request("txtProveedor")) > 0 Then
            intNotaCargoProveedorId = CInt(Request("txtProveedor"))
            strProveedorId = CStr(intNotaCargoProveedorId)
        End If

        ' Tipo de Nota de Cargo
        strTipoNotaCargoNombreId = Request("rdoTipoNota")

        If Len(Request("rdoFiltro")) > 0 Then
            ' Tipo de Filtro por Fechas en mes actual o rango de fechas
            intTipoFiltro = CInt(Request("rdoFiltro"))
        End If

        If Len(Request("txtRazonSocialProveedor")) > 0 Then
            strRazonSocialProveedor = Request("txtRazonSocialProveedor")
        End If


        If intNotaCargoProveedorId <= 0 Then
            Call Response.Redirect("MercanciaConsultarNotasCargo.aspx")
        End If

        dtmFechaInicial = "01/01/1900"
        dtmFechaFinal = "01/01/1900"

        Select Case intTipoFiltro
            Case 1 ' Consulta sera por mes actual, las fechas se obtienen en el sp
                dtmFechaInicial = "01/01/1900"
                dtmFechaFinal = "01/01/1900"

                objDataArray = clsConcentrador.clsSucursal.clsMercancia.clsNotasCargo.strBuscaNotasCargo(intCompaniaId, intSucursalId, strTipoNotaCargoNombreId, 0, intNotaCargoProveedorId, CDate(dtmFechaInicial), CDate(dtmFechaFinal), 0, intTipoFiltro, intPosicionInicial, intElementos, strCadenaConexion)
            Case 2 ' Rango de Fechas establecidas
                If Len(Request("txtFechaInicial")) > 0 Then
                    dtmFechaInicial = Request("txtFechaInicial")
                End If

                If Len(Request("txtFechaFinal")) > 0 Then
                    dtmFechaFinal = Request("txtFechaFinal")
                End If

                objDataArray = clsConcentrador.clsSucursal.clsMercancia.clsNotasCargo.strBuscaNotasCargo(intCompaniaId, intSucursalId, strTipoNotaCargoNombreId, 0, intNotaCargoProveedorId, CDate(clsCommons.strDMYtoMDY(dtmFechaInicial)), CDate(clsCommons.strDMYtoMDY(dtmFechaFinal)), 0, intTipoFiltro, intPosicionInicial, intElementos, strCadenaConexion)
        End Select

        ' Verificamos el arreglo
        If IsArray(objDataArray) Then
            If objDataArray.Length > 0 Then

                objRegistro = DirectCast(objDataArray.GetValue(0), String())

                strTipoNota = objRegistro(4).ToString

                intElementsPerPage = objDataArray.Length
                strTargetURL = "MercanciaNotasCargoDetalle.aspx?intNotaCargoProveedorId=" & intNotaCargoProveedorId.ToString & "&strTipoNotaCargoNombreId=" & strTipoNotaCargoNombreId.ToString & "&dtmFechaInicial=" & dtmFechaInicial & "&dtmFechaFinal=" & dtmFechaFinal & "&intTipoFiltro=" & intTipoFiltro.ToString & "&"

                strRecordBrowserHTML = clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaNotasCargoProveedor", objDataArray, intSelectedPage, intElementsPerPage, strTargetURL))

            End If
        End If



    End Sub

End Class
