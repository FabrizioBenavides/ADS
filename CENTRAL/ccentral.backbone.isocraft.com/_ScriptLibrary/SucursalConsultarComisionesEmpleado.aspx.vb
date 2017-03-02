Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business
Imports System.Text
Imports System.Configuration

Public Class clsSucursalConsultarComisionesEmpleado
    Inherits System.Web.UI.Page

    Private Const intElementos As Integer = 20

    Private dtmmInicioPeriodo As Date
    Private dtmmFinPeriodo As Date
    Private intmDiasRestantes As Integer

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
    ' Description: Valor que tomara la fecha de inicio de pren�mina
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
    ' Description: Valor que tomara la fecha de t�rmino de pren�mina
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
    ' Description: Valor que tomara la fecha de inicio de pren�mina (String)
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
    ' Description: Valor que tomara la fecha de t�rmino de pren�mina (String)
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
    ' Description: Valor que tomara los d�as que faltan para terminar el
    '               periodo de pren�mina actual
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
    '               as� como los d�as que faltan para el fin del mismo
    ' Parameters : Ninguno
    ' Throws     : Ninguna
    ' Output     : Ninguna
    '====================================================================
    Private Sub BuscarInformacionPeriodo()
        Dim objBuscarProximoCierre As Array = Nothing
        Dim strBuscarProximoCierre As String()

        ' Busco la informaci�n del cierre de pren�mina
        objBuscarProximoCierre = clsConcentrador.clsPrenomina.strBuscarProximoCierre(intCompaniaId, Now.ToShortDateString, strCadenaConexion)

        If IsArray(objBuscarProximoCierre) Then
            If objBuscarProximoCierre.Length > 0 Then
                strBuscarProximoCierre = DirectCast(objBuscarProximoCierre.GetValue(0), String())

                ' Asigno los valores de la pren�mina
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
            If Trim(Request.QueryString("intEmpleadoId")) <> "" Then
                Return CType(Trim(Request.QueryString("intEmpleadoId").ToString), Integer)
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strGrupoUsuarioNombreId
    ' Description: Identificador del Grupo al que pertenece el empleado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strGrupoUsuarioNombreId() As String
        Get
            If Trim(Request.QueryString("strGrupoUsuarioNombreId")) <> "" Then
                Return Trim(Request.QueryString("strGrupoUsuarioNombreId"))
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Identificador del comando a realizar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Trim(Request.QueryString("strCmd")) <> "" Then
                Return Trim(Request.QueryString("strCmd"))
            Else
                Return ""
            End If
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
            ' Declaraci�n e inicializaci�n de las variables locales
            Dim strbldRecordBrowserHTML As StringBuilder
            Dim objEmpleadoPrenomina As Array = Nothing
            Dim strTargetURL As String = "SucursalConsultarComisionesEmpleado.aspx?"

            strbldRecordBrowserHTML = New StringBuilder

            ' Busco los empelados de la sucursal
            objEmpleadoPrenomina = clsConcentrador.clsPrenomina.strBuscarComisionEmpleadoPrenomina(intCompaniaId, intSucursalId, 0, dtmInicioPeriodo, dtmFinPeriodo, 0, 0, strCadenaConexion)

            If IsArray(objEmpleadoPrenomina) Then
                If objEmpleadoPrenomina.Length > 0 Then

                    ' Generamos el Navegador de Registros
                    strbldRecordBrowserHTML.Append(clsRecordBrowser.strGetHTML("SucursalConsultarComisionesEmpleado", objEmpleadoPrenomina, 1, intElementos, strTargetURL))
                End If
            End If

            Return clsCommons.strGenerateJavascriptString(strbldRecordBrowserHTML.ToString)
        End Get

    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strURLEmpleadoVendedor As String : strURLEmpleadoVendedor = "SucursalConsultarComisionesEmpleadoVendedor.aspx?intEmpleadoId=" + intEmpleadoBusquedaId.ToString
        Dim strURLEmpleadoGerente As String : strURLEmpleadoGerente = "SucursalConsultarComisionesEmpleadoGerente.aspx?intEmpleadoId=" + intEmpleadoBusquedaId.ToString

        ' Control de Acceso de la p�gina
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        ' Verifico que se est� consultando el detalle de un empleado
        If strCmd.Equals("Ver") Then
            ' Verifico el tipo de usuario
            If strGrupoUsuarioNombreId.Equals("GERENTE") OrElse strGrupoUsuarioNombreId.Equals("ASISTENTE") OrElse strGrupoUsuarioNombreId.Equals("ASISTENTESECUNDARIO") Then
                ' Vamos a la p�gina de consultar comisiones de un empleado GERENTE o ASISTENTE
                Response.Redirect(strURLEmpleadoGerente)
            Else
                ' Vamos a la p�gina de consultar comisiones de un empleado CAJERO
                Response.Redirect(strURLEmpleadoVendedor)
            End If
        End If


        ' Inicializo los valores del periodo
        Call BuscarInformacionPeriodo()

    End Sub

End Class
