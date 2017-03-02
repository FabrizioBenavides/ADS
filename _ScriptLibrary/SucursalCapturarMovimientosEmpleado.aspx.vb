Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business
Imports System.Text
Imports System.Configuration

Public Class clsSucursalCapturarMovimientosEmpleado
    Inherits System.Web.UI.Page

    Private Const intElementos As Integer = 20

    ' Variables para el uso de las fechas del periodo de pernómina
    Private dtmmInicioPeriodo As Date
    Private dtmmFinPeriodo As Date
    Private intmDiasRestantes As Integer

    ' Variables para los datos del empleado
    Private intmPuestoEmpleadoBusquedaId As Integer
    Private strmEmpleadoBusquedaNombre As String

    ' Variables para los conceptos
    Private intmConceptoId As Integer
    Private strmCantidadMaxima As String
    Private strmConceptoNombre As String

    ' Manejo de errores
    Private intmError As Integer

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
            Return Request.ServerVariables("SCRIPT_NAME") + "?intEmpleadoId=" + intEmpleadoBusquedaId.ToString
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
    ' Name       : strPeriodoPrenomina
    ' Description: Obtiene el letrero del periodo de prenómina actual
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strPeriodoPrenomina() As String
        Get
            Dim strFechaInicioPeriodo As String() : strFechaInicioPeriodo = dtmInicioPeriodo.ToString.Split("/"c)
            Dim strFechaFinPeriodo As String() : strFechaFinPeriodo = dtmFinPeriodo.ToString.Split("/"c)
            Dim strDesplegadoPeriodo As StringBuilder

            strDesplegadoPeriodo = New StringBuilder

            Call strDesplegadoPeriodo.Append(strFechaInicioPeriodo(1) + " de " + strNombreMes(CType(strFechaInicioPeriodo(0), Integer)) + " de " + strFechaInicioPeriodo(2).Split(" "c)(0) + " al ")
            Call strDesplegadoPeriodo.Append(strFechaFinPeriodo(1) + " de " + strNombreMes(CType(strFechaFinPeriodo(0), Integer)) + " de " + strFechaFinPeriodo(2).Split(" "c)(0))

            Return strDesplegadoPeriodo.ToString
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
            dtmmFinPeriodo = CType(dtmValue, Date)
        End Set
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
    ' Name       : strNombreMes
    ' Description: Nombre del mes enviado como parámetro
    ' Accessor   : Read / Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strNombreMes(ByVal intMes As Integer) As String
        Select Case intMes
            Case 1
                Return "Ene"
            Case 2
                Return "Feb"
            Case 3
                Return "Mar"
            Case 4
                Return "Abr"
            Case 5
                Return "May"
            Case 6
                Return "Jun"
            Case 7
                Return "Jul"
            Case 8
                Return "Ago"
            Case 9
                Return "Sep"
            Case 10
                Return "Oct"
            Case 11
                Return "Nov"
            Case 12
                Return "Dic"
        End Select
    End Function

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
    ' Description: Identificador del empleado al que se le registran movimientos
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
    ' Name       : intPuestoEmpleadoBusquedaId
    ' Description: Identificador del puesto del empleado al que se 
    '               le registran movimientos
    ' Accessor   : Read / Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intPuestoEmpleadoBusquedaId() As Integer
        Get
            Return intmPuestoEmpleadoBusquedaId
        End Get
        Set(ByVal intValue As Integer)
            intmPuestoEmpleadoBusquedaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpleadoBusquedaNombre
    ' Description: Nombre del empleado al que se le registran movimientos
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

    '====================================================================
    ' Name       : BuscarInformacionEmpleado
    ' Description: Generar la información del empleado
    ' Parameters : Ninguno
    ' Throws     : Ninguna
    ' Output     : Ninguna
    '====================================================================
    Private Sub BuscarInformacionEmpleado()
        Dim objBuscarInformacionEmpleado As Array = Nothing
        Dim strBuscarInformacionEmpleado As String()

        ' Busco la información del cierre de prenómina
        objBuscarInformacionEmpleado = clsConcentrador.clsPrenomina.strBuscarEmpleado(intCompaniaId, intSucursalId, intEmpleadoBusquedaId, 0, 0, strCadenaConexion)

        If IsArray(objBuscarInformacionEmpleado) Then
            If objBuscarInformacionEmpleado.Length > 0 Then
                strBuscarInformacionEmpleado = DirectCast(objBuscarInformacionEmpleado.GetValue(0), String())

                ' Asigno los valores del empleado
                intPuestoEmpleadoBusquedaId = CType(strBuscarInformacionEmpleado(5), Integer)
                strEmpleadoBusquedaNombre = strBuscarInformacionEmpleado(4)
            End If
        End If
    End Sub

    '====================================================================
    ' Name       : strFechaRegistro
    ' Description: Fecha sobre la cual se consultará la bitácora
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFechaRegistro() As String
        Get
            If strCmd.Equals("Agregar") OrElse strCmd.Equals("Borrar") Then
                Return Format(Date.Now, "dd/MM/yyyy")
            Else
                If Trim(Request.Form("txtFechaRegistro")) <> "" Then
                    Return Trim(Request.Form("txtFechaRegistro"))
                Else
                    If Request.QueryString("txtFechaRegistro") <> "" Then
                        Return Request.QueryString("txtFechaRegistro")
                    Else
                        Return Format(Date.Now, "dd/MM/yyyy")
                    End If
                End If
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
    ' Name       : intConceptoPrenominaId
    ' Description: Identificador del Concepto
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intConceptoPrenominaId() As Integer
        Get
            If strCmd.Equals("Agregar") Then
                If Trim(Request.Form("txtConceptoId")) <> "" Then
                    Return CType(Trim(Request.Form("txtConceptoId")), Integer)
                Else
                    Return 0
                End If
            ElseIf strCmd.Equals("Borrar") Then
                If Request.QueryString("intConceptoPrenominaId") <> "" Then
                    Return CType(Request.QueryString("intConceptoPrenominaId"), Integer)
                Else
                    Return 0
                End If
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intMovimientoPrenominaId
    ' Description: Identificador del Movimiento
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intMovimientoPrenominaId() As Integer
        Get
            If strCmd.Equals("Borrar") AndAlso Request.QueryString("intMovimientoPrenominaId") <> "" Then
                Return CType(Request.QueryString("intMovimientoPrenominaId"), Integer)
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strConceptoId
    ' Description: Identificador del Concepto
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strConceptoId() As String
        Get
            If strCmd.Equals("Consultar") Then
                If Trim(Request.Form("txtConcepto")) <> "" Then
                    Return Trim(Request.Form("txtConcepto"))
                Else
                    Return ""
                End If
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intConceptoId
    ' Description: Identificador del Concepto
    ' Accessor   : Read / Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intConceptoId() As Integer
        Get
            Return intmConceptoId
        End Get
        Set(ByVal intValue As Integer)
            intmConceptoId = intValue
        End Set
    End Property
    '====================================================================
    ' Name       : strConceptoNombre
    ' Description: Nombre del Concepto
    ' Accessor   : Read / Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strConceptoNombre() As String
        Get
            Return strmConceptoNombre
        End Get
        Set(ByVal strValue As String)
            strmConceptoNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltCantidad
    ' Description: Identificador del Concepto
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Double
    '====================================================================
    Public ReadOnly Property fltCantidad() As Double
        Get
            If Trim(Request.Form("txtCantidad")) <> "" Then
                Return CType(Trim(Request.Form("txtCantidad")), Double)
            Else
                Return 0.0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strCantidad
    ' Description: Identificador del Concepto
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCantidad() As String
        Get
            If strCmd.Equals("Consultar") Then
                Return Trim(Request.Form("txtCantidad").ToString)
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strCantidadMaxima
    ' Description: Nombre del Concepto
    ' Accessor   : Read / Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strCantidadMaxima() As String
        Get
            Return strmCantidadMaxima
        End Get
        Set(ByVal strValue As String)
            strmCantidadMaxima = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intError
    ' Description: Nombre del Concepto
    ' Accessor   : Read / Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intError() As Integer
        Get
            Return intmError
        End Get
        Set(ByVal intValue As Integer)
            intmError = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strBuscarInformacionConcepto
    ' Description: Genera el Record Browser para mostrar los Articulos
    '              de acuerdo a su descripcion.
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Sub strBuscarInformacionConcepto()

        Dim objConceptosPrenomina As Array = Nothing
        Dim strConceptosPrenomina As String()
        Dim strbldRecordBrowserHTML As StringBuilder

        ' Buscamos el concepto especificado
        objConceptosPrenomina = clsConcentrador.clsPrenomina.strBuscarConcepto(strConceptoId, 0, 0, strCadenaConexion)

        If IsArray(objConceptosPrenomina) AndAlso objConceptosPrenomina.Length > 0 Then
            strConceptosPrenomina = DirectCast(objConceptosPrenomina.GetValue(0), String())

            strConceptoNombre = strConceptosPrenomina(1)
            strCantidadMaxima = strConceptosPrenomina(3)
            intConceptoId = CInt(strConceptosPrenomina(0))
            intError = 0
        Else
            strConceptoNombre = ""
            strCantidadMaxima = ""
            intConceptoId = 0
            intError = -100
        End If

    End Sub

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Record browser navegador de los movimientos según 
    '              del empleado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRecordBrowserHTML() As String
        Get
            ' Declaración e inicialización de las variables locales
            Dim strbldRecordBrowserHTML As StringBuilder
            Dim objMovimientosEmpleadoPrenomina As Array = Nothing
            Dim strTargetURL As String = "SucursalCapturarMovimientosEmpleado.aspx?intEmpleadoId=" + intEmpleadoBusquedaId.ToString + "&"

            strbldRecordBrowserHTML = New StringBuilder

            ' Busco los empelados de la sucursal
            objMovimientosEmpleadoPrenomina = clsConcentrador.clsPrenomina.strBuscarMovimientosEmpleado(intCompaniaId, intSucursalId, intEmpleadoBusquedaId, dtmInicioPeriodo, dtmFinPeriodo, 0, 0, strCadenaConexion)

            If IsArray(objMovimientosEmpleadoPrenomina) Then
                If objMovimientosEmpleadoPrenomina.Length > 0 Then

                    ' Generamos el Navegador de Registros
                    strbldRecordBrowserHTML.Append(clsRecordBrowser.strGetHTML("SucursalCapturarMovimientosEmpleado", objMovimientosEmpleadoPrenomina, 1, intElementos, strTargetURL))
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
            Call Response.Redirect("SucursalCapturarPrenomina.aspx")
        End If

        ' Inicializo los valores del periodo
        Call BuscarInformacionPeriodo()

        ' Inicializo los valores del empleado
        Call BuscarInformacionEmpleado()

        If strCmd.Equals("Consultar") Then

            ' Consultamos un artículo
            Call strBuscarInformacionConcepto()

        ElseIf strCmd.Equals("Agregar") Then

            ' Validamos el concepto 

            Dim objConceptosPrenomina As Array = Nothing
            Dim strConceptosPrenomina As String()
            Dim strbldRecordBrowserHTML As StringBuilder

            ' Buscamos el concepto especificado
            objConceptosPrenomina = clsConcentrador.clsPrenomina.strBuscarConcepto(Trim(Request.Form("txtConcepto")), 0, 0, strCadenaConexion)

            If IsArray(objConceptosPrenomina) AndAlso objConceptosPrenomina.Length > 0 Then
                strConceptosPrenomina = DirectCast(objConceptosPrenomina.GetValue(0), String())

                strConceptoNombre = strConceptosPrenomina(1)
                strCantidadMaxima = strConceptosPrenomina(3)
                intConceptoId = CInt(strConceptosPrenomina(0))
                intError = 0
            Else
                strConceptoNombre = ""
                strCantidadMaxima = ""
                intConceptoId = 0
                intError = -100
            End If

            If intConceptoId > 0 Then
                ' Agregamos un movimiento al empleado
                Call clsConcentrador.clsPrenomina.intAgregarMovimiento(intCompaniaId, intSucursalId, 0, intConceptoId, intEmpleadoBusquedaId, fltCantidad, CDate(dtmInicioPeriodo), CDate(dtmFinPeriodo), strUsuarioNombre, strCadenaConexion)
            End If

            ElseIf strCmd.Equals("Borrar") Then

                ' Eliminamos un movimiento al empleado
                Call clsConcentrador.clsPrenomina.intBorrarMovimiento(intCompaniaId, intSucursalId, intMovimientoPrenominaId, intConceptoPrenominaId, intEmpleadoBusquedaId, strCadenaConexion)

            End If
    End Sub

End Class
