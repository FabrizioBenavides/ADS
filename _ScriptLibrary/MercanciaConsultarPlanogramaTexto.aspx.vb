'====================================================================
' Page          : MercanciaConsultarPlanogramaTexto.aspx
' Title         : Administracion POS y BackOffice
' Description   : Página para consultar los planos de ubicación de los productos (texto).
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Armando Calzada Mezura
' Version       : 1.0
' Last Modified : October 31, 2003
'====================================================================
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business
Imports System.Text
Imports System.Configuration

Public Class clsMercanciaConsultarPlanogramaTexto
    Inherits System.Web.UI.Page

    Private strmPlanoNombre As String

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

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
    ' Name       : intPlanoId
    ' Description: Identificador del planograma
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intPlanoId() As Integer
        Get
            If Request.QueryString("intPlanoId") <> "" Then
                Return CType(Request.QueryString("intPlanoId"), Integer)
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strPlanoGraficoId
    ' Description: Identificador del planograma
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strPlanoGraficoId() As String
        Get
            If Request.QueryString("intPlanoId") <> "" Then
                Return Right("000000" & Request.QueryString("intPlanoId"), 6)
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strPlanoNombre
    ' Description: Valor que tomara la información del planograma
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strPlanoNombre() As String
        Get
            Dim objPlanograma As Array = Nothing
            Dim strPlanograma As String() = Nothing

            objPlanograma = clstblPlano.strBuscar(intPlanoId, 0, "", CDate(Now), 0, CByte(0), CDate(Now), strUsuarioNombre, 0, 0, strCadenaConexion)

            ' Validamos si trae información para mostrarla
            If IsArray(objPlanograma) AndAlso objPlanograma.Length > 0 Then
                strPlanograma = DirectCast(objPlanograma.GetValue(0), String())
                Return strPlanograma(2)
            Else
                Return ""
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : strIFrameHTML
    ' Description: Valor que tomara la información del planograma
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strIFrameHTML() As String
        Get
            Return clsCommons.strGenerateJavascriptString("<iframe name=""iframe1"" id=""iframe1"" src=""ifrMercanciaConsultarPlanogramaTexto.aspx?intPlanoId=" & intPlanoId.ToString & """ frameborder=""0"" width=""100%"" scroll=""no"" height=""0"" marginwidth=""0"" marginheight=""0""> </iframe>")
        End Get
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Record browser navegador de los empleados de la sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRecordBrowserHTML() As String
        Get
            ' Declaración e inicialización de las variables locales
            Dim strbldRecordBrowserHTML As StringBuilder
            Dim objArticuloPlanograma As Array = Nothing
            Dim strTargetURL As String = "MercanciaConsultarPlanogramaTexto.aspx?"
            Dim intElementos As Integer

            ' Variables para los totales
            Dim fltTotalCompras As Double : fltTotalCompras = 0
            Dim fltTotalPorcentaje As Double : fltTotalPorcentaje = 0

            strbldRecordBrowserHTML = New StringBuilder

            ' Busco los empelados de la sucursal
            ' Anterior objArticuloPlanograma = clstblArticuloPlano.strBuscar(intPlanoId, 0, "", 0, 0, 0, 0, 0, CDate(Now), "", "", "", CDate(Now), strUsuarioNombre, 0, 0, strCadenaConexion)
            objArticuloPlanograma = clsConcentrador.clsPlanograma.strBuscarDetalle(intCompaniaId, intSucursalId, intPlanoId, 0, 0, 0, strCadenaConexion)

            If IsArray(objArticuloPlanograma) AndAlso objArticuloPlanograma.Length > 0 Then
                intElementos = objArticuloPlanograma.Length

                ' Generamos el Navegador de Registros
                strbldRecordBrowserHTML.Append(clsRecordBrowser.strGetHTML("MercanciaConsultarPlanogramaTexto", objArticuloPlanograma, 1, intElementos, strTargetURL))

            End If

            Return clsCommons.strGenerateJavascriptString(strbldRecordBrowserHTML.ToString)
        End Get

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

        Dim objReciboTransferencias As Array = Nothing
        Dim strReciboTransferencias As String() = Nothing

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strRedirectPage)
        End If

    End Sub

End Class
