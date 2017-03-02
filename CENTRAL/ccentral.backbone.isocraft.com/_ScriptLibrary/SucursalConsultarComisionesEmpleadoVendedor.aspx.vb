Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business
Imports System.Text
Imports System.Configuration

Public Class clsSucursalConsultarComisionesEmpleadoVendedor
    Inherits System.Web.UI.Page

    Private Const intElementos As Integer = 20

    ' Variables para almacenar 'nformción del periodo de prenómina
    Private dtmmInicioPeriodo As Date
    Private dtmmFinPeriodo As Date
    Private intmDiasRestantes As Integer

    ' Variables para almacenar información del empleado consultado
    Private strmEmpleadoBusquedaNombre As String
    Private strmEmpleadoBusquedaRol As String
    Private strmEmpleadoBusquedaComision As String


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
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalNombre() As String
        Get
            Return clsCommons.strReadCookie("strSucursalNombre", "", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del Usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)
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
    ' Name       : dtmInicioPeriodo
    ' Description: Valor que tomara la fecha de inicio de prenómina
    ' Accessor   : Read / Write
    ' Throws     : Ninguna
    ' Output     : Date
    '====================================================================
    Public Property dtmInicioPeriodo() As Date
        Get
            Return dtmmInicioPeriodo
        End Get
        Set(ByVal dtmValue As Date)
            dtmmInicioPeriodo = CType(dtmValue, Date)
        End Set
    End Property

    '====================================================================
    ' Name       : dtmFinPeriodo
    ' Description: Valor que tomara la fecha de término de prenómina
    ' Accessor   : Read / Write
    ' Throws     : Ninguna
    ' Output     : Date
    '====================================================================
    Public Property dtmFinPeriodo() As Date
        Get
            Return dtmmFinPeriodo
        End Get
        Set(ByVal dtmValue As Date)
            dtmmFinPeriodo = dtmValue
        End Set
    End Property

    '====================================================================
    ' Name       : strInicioPeriodo
    ' Description: Valor que tomara la fecha de inicio de prenómina (String)
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strInicioPeriodo() As String
        Get
            Dim strFechaInicio As String() : strFechaInicio = dtmmInicioPeriodo.ToString.Split(" "c)(0).Split("/"c)
            Return strFechaInicio(1) + "/" + strFechaInicio(0) + "/" + strFechaInicio(2)
        End Get
    End Property

    '====================================================================
    ' Name       : strFinPeriodo
    ' Description: Valor que tomara la fecha de término de prenómina (String)
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFinPeriodo() As String
        Get
            Dim strFechaFin As String() : strFechaFin = dtmmFinPeriodo.ToString.Split(" "c)(0).Split("/"c)
            Return strFechaFin(1) + "/" + strFechaFin(0) + "/" + strFechaFin(2)
        End Get
    End Property

    '====================================================================
    ' Name       : intDiasRestantes
    ' Description: Valor que tomara los días que faltan para terminar el
    '               periodo de prenómina actual
    ' Accessor   : Read / Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intDiasRestantes() As Integer
        Get
            Return intmDiasRestantes
        End Get
        Set(ByVal intValue As Integer)
            intmDiasRestantes = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : BuscarInformacionPeriodo
    ' Description: Generar los valores de fechas de inicio y fin de periodo,
    '               así como los días que faltan para el fin del mismo
    ' Parameters : Ninguno
    ' Throws     : Ninguna
    ' Output     : Ninguna
    '====================================================================
    Private Sub BuscarInformacionPeriodo()
        Dim objBuscarProximoCierre As Array = Nothing
        Dim strBuscarProximoCierre As String()
        Dim strFechaBusqueda As String : strFechaBusqueda = ""

        ' Busco la información del cierre de prenómina
        objBuscarProximoCierre = clsConcentrador.clsPrenomina.strBuscarProximoCierre(intCompaniaId, Now.ToShortDateString, strCadenaConexion)

        If IsArray(objBuscarProximoCierre) Then
            If objBuscarProximoCierre.Length > 0 Then
                strBuscarProximoCierre = DirectCast(objBuscarProximoCierre.GetValue(0), String())

                ' Asigno los valores de la prenómina
                dtmInicioPeriodo = CDate(strBuscarProximoCierre(0))
                dtmFinPeriodo = CDate(strBuscarProximoCierre(1))
                intDiasRestantes = CType(strBuscarProximoCierre(2), Integer)
            End If
        End If
    End Sub

    '====================================================================
    ' Name       : intEmpleadoBusquedaId
    ' Description: Identificador del empleado al que se le consultan las comisiones
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intEmpleadoBusquedaId() As Integer
        Get
            If Request.QueryString("intEmpleadoId") <> "" Then
                Return CType(Request.QueryString("intEmpleadoId").ToString, Integer)
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strEmpleadoBusquedaNombre
    ' Description: Valor que almacena el nombre del empleado
    ' Accessor   : Read / Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEmpleadoBusquedaNombre() As String
        Get
            Return strmEmpleadoBusquedaNombre
        End Get
        Set(ByVal strValue As String)
            strmEmpleadoBusquedaNombre = strValue
        End Set
    End Property

    '   Private strmEmpleadoBusquedaComision As String

    '====================================================================
    ' Name       : strEmpleadoBusquedaRol
    ' Description: Valor que almacena el rol del empleado
    ' Accessor   : Read / Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEmpleadoBusquedaRol() As String
        Get
            Return strmEmpleadoBusquedaRol
        End Get
        Set(ByVal strValue As String)
            strmEmpleadoBusquedaRol = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpleadoBusquedaComision
    ' Description: Valor que almacena la comisión del empleado
    ' Accessor   : Read / Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEmpleadoBusquedaComision() As String
        Get
            Return "$ " + strmEmpleadoBusquedaComision
        End Get
        Set(ByVal strValue As String)
            strmEmpleadoBusquedaComision = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : BuscarInformacionEmpleado
    ' Description: Generar los valores de fechas de inicio y fin de periodo,
    '               así como los días que faltan para el fin del mismo
    ' Parameters : Ninguno
    ' Throws     : Ninguna
    ' Output     : Ninguna
    '====================================================================
    Private Sub BuscarInformacionEmpleado()
        Dim objBuscarInformacionEmpleado As Array = Nothing
        Dim strBuscarInformacionEmpleado As String()

        ' Busco la información del cierre de prenómina
        objBuscarInformacionEmpleado = clsConcentrador.clsPrenomina.strBuscarComisionEmpleadoPrenomina(intCompaniaId, intSucursalId, intEmpleadoBusquedaId, dtmInicioPeriodo, dtmFinPeriodo, 0, 0, strCadenaConexion)

        If IsArray(objBuscarInformacionEmpleado) Then
            If objBuscarInformacionEmpleado.Length > 0 Then
                strBuscarInformacionEmpleado = DirectCast(objBuscarInformacionEmpleado.GetValue(0), String())

                ' Asigno los valores de los datos del empleado
                strmEmpleadoBusquedaNombre = strBuscarInformacionEmpleado(2)
                strmEmpleadoBusquedaRol = strBuscarInformacionEmpleado(3)
                strmEmpleadoBusquedaComision = strBuscarInformacionEmpleado(1)
            End If
        End If
    End Sub

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
            Dim objEmpleadoPrenomina As Array = Nothing
            Dim strTargetURL As String = "SucursalConsultarComisionesEmpleadoVendedor.aspx?"

            strbldRecordBrowserHTML = New StringBuilder

            ' Busco los empelados de la sucursal
            objEmpleadoPrenomina = clsConcentrador.clsPrenomina.strBuscarComisionEmpleadoVendedor(intCompaniaId, intSucursalId, intEmpleadoBusquedaId, dtmInicioPeriodo, dtmFinPeriodo, 0, 0, strCadenaConexion)

            If IsArray(objEmpleadoPrenomina) Then
                If objEmpleadoPrenomina.Length > 0 Then

                    ' Generamos el Navegador de Registros
                    strbldRecordBrowserHTML.Append(clsRecordBrowser.strGetHTML("SucursalConsultarComisionesEmpleadoVendedor", objEmpleadoPrenomina, 1, intElementos, strTargetURL))
                End If
            End If

            Return clsCommons.strGenerateJavascriptString(strbldRecordBrowserHTML.ToString)
        End Get

    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        If CType(intEmpleadoBusquedaId, Integer) = 0 Then
            Call Response.Redirect("SucursalConsultarComisionesEmpleado.aspx")
        End If

        ' Inicializo los valores del periodo
        Call BuscarInformacionPeriodo()

        ' Inicializo los valores de la información del empleado
        Call BuscarInformacionEmpleado()

    End Sub

End Class
