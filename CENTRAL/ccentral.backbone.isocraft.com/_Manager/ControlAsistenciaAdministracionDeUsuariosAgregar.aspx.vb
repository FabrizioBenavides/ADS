Imports Benavides.POSAdmin.Commons
Imports Isocraft.Security
Imports Isocraft.Web.Http
Imports System.Text
Imports Benavides.CC.Data

Public Class ControlAsistenciaAdministracionDeUsuariosAgregar
    Inherits PaginaBase

    Private _dtmFechaUsuarioExpiracion As Date
    Private _intUsuarioExistenteId As Integer
    Private Const GRUPO_USUARIO_ID As Integer = 28

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    '====================================================================
    ' Name       : strFechaActual
    ' Description: Regresa la fecha actual
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFechaActual() As String
        Get

            Dim dtmFechaActual As Date

            dtmFechaActual = New Date(Date.Today.Year, Date.Today.Month, Date.Today.Day)

            Return dtmFechaActual.ToString("dd/MM/yyyy")
        End Get
    End Property

    Public ReadOnly Property intEmpleadoId() As Integer
        Get
            Return CInt(GetPageParameter("intEmpleadoId", "0"))
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaUsuarioExpiracion
    ' Description: Obtiene o establece la fecha de expiracion del usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Date
    '====================================================================
    Public Property dtmFechaUsuarioExpiracion() As Date
        Get
            Return _dtmFechaUsuarioExpiracion
        End Get
        Set(ByVal dtmValue As Date)
            _dtmFechaUsuarioExpiracion = dtmValue
        End Set
    End Property

    '====================================================================
    ' Name       : strUsuarioContrasena
    ' Description: Obtiene o establece la contraseña del usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioContrasena() As String
        Get
            Return CStr(GetPageParameter("strUsuarioContrasena", "0"))
        End Get
    End Property

    '====================================================================
    ' Name       : blnUsuarioHabilitado
    ' Description: Obtiene o establece el estatus del usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Byte
    '====================================================================
    Public ReadOnly Property blnUsuarioHabilitado() As Byte
        Get
            Return CByte(GetPageParameter("blnUsuarioHabilitado", "0"))
        End Get
    End Property

    '====================================================================
    ' Name       : blnUsuarioBloqueado
    ' Description: Obtiene o establece el estatus del usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Byte
    '====================================================================
    Public ReadOnly Property blnUsuarioBloqueado() As Byte
        Get
            Return CByte(GetPageParameter("blnUsuarioBloqueado", "0"))
        End Get
    End Property

    Public ReadOnly Property strCmd2() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd2", "")
        End Get
    End Property

    '====================================================================
    ' Name       : intUsuarioExistenteId
    ' Description: Indica si el usuario existe
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intUsuarioExistenteId() As Integer
        Get
            Return _intUsuarioExistenteId
        End Get
    End Property

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        InitializeComponent()

        _dtmFechaUsuarioExpiracion = CDate(clsCommons.strDMYtoMDY(GetPageParameter("txtUsuarioExpiracion", DateAdd(DateInterval.Day, 30, Date.Now).ToString("dd/MM/yyyy"))))
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        'If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Or Not intTipoUsuarioId = 1 Or CInt(strUsuarioNombre) = 40014547 Then
        '    Call Response.Redirect("../Default.aspx")
        'End If

        Select Case strCmd2

            Case "Guardar"
                Call GuardarUsuario()


        End Select

    End Sub

    Private Sub GuardarUsuario()
        Dim strContrasenaEncriptada As String = String.Empty
        Dim intUsuario As Integer
        Dim fechaActual As Date

        strContrasenaEncriptada = (New Hash.DataProtector).HashString(strUsuarioContrasena, Hash.DataProtector.CryptoServiceProvider.SHA1)
        fechaActual = Date.Now

        intUsuario = clsUsuario.intAgregarEnConcentrador(intEmpleadoId, _
                                                         0, _
                                                         intEmpleadoId.ToString(), _
                                                         strContrasenaEncriptada, _
                                                         blnUsuarioHabilitado, _
                                                         dtmFechaUsuarioExpiracion, _
                                                         fechaActual, _
                                                         fechaActual, _
                                                         strUsuarioNombre, _
                                                         0, _
                                                         0, _
                                                         blnUsuarioBloqueado, _
                                                         0, _
                                                         strConnectionString)

        If intUsuario > 0 Then
            _intUsuarioExistenteId = 1
            clstblMembresiaUsuario.intAgregar(intEmpleadoId,
                                              intUsuario,
                                              GRUPO_USUARIO_ID,
                                              fechaActual,
                                              strUsuarioNombre,
                                              strConnectionString)
        End If

        If intUsuario > 0 Then
            strJavascriptWindowOnLoadCommands = "window.alert(""Usuario guardada correctamente."");"
        Else
            strJavascriptWindowOnLoadCommands = "window.alert(""Error al guardar usuario."");"
        End If
    End Sub

    Protected Function strObtenerSucursalesPorCoordinadorRH() As String
        Dim strResultadoTablaSucursales As New StringBuilder



        Return strResultadoTablaSucursales.ToString()
    End Function



End Class
