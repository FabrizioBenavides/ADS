Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business
Imports System.Text
Imports System.Configuration

Public Class clsSucursalConsultarCierrePrenomina
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

            Call strDesplegadoPeriodo.Append("Abarca período del ")
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
            dtmmFinPeriodo = dtmValue
        End Set
    End Property

    '====================================================================
    ' Name       : intDiaCierre
    ' Description: Valor que tomara los días que faltan para terminar el
    '               periodo de prenómina actual
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDiaCierre() As Integer
        Get
            Return CType(dtmFinPeriodo.ToString.Split("/"c)(1), Integer)
        End Get
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
        Dim strFechaBusqueda As String : strFechaBusqueda = ""

        ' Busco la información del cierre de prenómina
        objBuscarProximoCierre = clsConcentrador.clsPrenomina.strBuscarProximoCierre(intCompaniaId, strFechaBusqueda, strCadenaConexion)

        If IsArray(objBuscarProximoCierre) Then
            If objBuscarProximoCierre.Length > 0 Then
                strBuscarProximoCierre = DirectCast(objBuscarProximoCierre.GetValue(0), String())

                ' Asigno los valores de la prenómina
                dtmInicioPeriodo = CDate(strBuscarProximoCierre(0))
                dtmFinPeriodo = CDate(strBuscarProximoCierre(1))
            End If
        End If
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        ' Inicializo los valores del periodo
        Call BuscarInformacionPeriodo()
    End Sub

End Class
