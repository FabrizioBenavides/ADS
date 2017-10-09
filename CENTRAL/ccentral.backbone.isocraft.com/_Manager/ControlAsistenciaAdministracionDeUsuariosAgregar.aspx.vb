Imports Benavides.CC.Data
Imports Benavides.POSAdmin.Commons
Imports Isocraft.Security
Imports Isocraft.Web.Http
Imports System.Collections
Imports System.Text

Public Class ControlAsistenciaAdministracionDeUsuariosAgregar
    Inherits PaginaBase

    Private _dtmFechaUsuarioExpiracion As Date
    Private _intUsuarioExistenteId As Integer

    Public Enum TipoUsuario
        CoordinadorRH = 2
        SupervisorMedico = 3
    End Enum

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

    Public ReadOnly Property intUsuarioId() As Integer
        Get
            Return CInt(GetPageParameter("intUsuarioId", "0"))
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
            Return CStr(GetPageParameter("strUsuarioContrasena", ""))
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioContrasena2
    ' Description: Obtiene o establece la contraseña del usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioContrasenaAnterior() As String
        Get
            Return CStr(GetPageParameter("strUsuarioContrasenaAnterior", ""))
        End Get
    End Property

    Public ReadOnly Property intTipoUsuarioIdParametro() As TipoUsuario
        Get
            Return CType(GetPageParameter("intTipoUsuarioIdParametro", "0"), TipoUsuario)
        End Get
    End Property

    '====================================================================
    ' Name       : blnUsuarioHabilitado
    ' Description: Obtiene o establece el estatus del usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Byte
    '====================================================================
    Public ReadOnly Property blnUsuarioHabilitado() As Boolean
        Get
            Return CBool(GetPageParameter("blnUsuarioHabilitado", "False"))
        End Get
    End Property

    '====================================================================
    ' Name       : blnUsuarioBloqueado
    ' Description: Obtiene o establece el estatus del usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Byte
    '====================================================================
    Public ReadOnly Property blnUsuarioBloqueado() As Boolean
        Get
            Return CBool(GetPageParameter("blnUsuarioBloqueado", "False"))
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

    'Public ReadOnly Property strCompaniasSucursalesSeleccionadas() As String
    '    Get
    '        Return CStr(GetPageParameter("strCompaniasSucursalesSeleccionadas", ""))

    '    End Get
    'End Property

    Public ReadOnly Property strCmd2() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd2", "")
        End Get
    End Property

    Public Function intResultadoGrupoControlAsistencia() As Integer
        Dim resultadoConsulta As Array
        Dim objConsulta As Array
        Dim controlAsistenciaGrupoId As Integer

        resultadoConsulta = clsControlDeAsistencia.strBuscarGrupoControlAsistencia(strConnectionString)

        For Each objConsulta In resultadoConsulta
            controlAsistenciaGrupoId = CInt(objConsulta.GetValue(0))
        Next

        Return controlAsistenciaGrupoId
    End Function

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        InitializeComponent()

        If strCmd2 = "Agregar" Then
            _dtmFechaUsuarioExpiracion = CDate(clsCommons.strDMYtoMDY(GetPageParameter("txtUsuarioExpiracion", DateAdd(DateInterval.Day, 30, Date.Now).ToString("dd/MM/yyyy"))))
        ElseIf strCmd2 = "Editar" Or strCmd2 = "Guardar" Or strCmd2 = "Modificar" Then
            _dtmFechaUsuarioExpiracion = CDate(clsCommons.strDMYtoMDY(GetPageParameter("dtmUsuarioExpiracion", "")))
        End If

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Or Not intTipoUsuarioId = 1 Then
            Call Response.Redirect("../Default.aspx")
        End If

        Select Case strCmd2

            Case "Guardar"
                Call GuardarUsuario()

            Case "Modificar"
                Call EditarUsuario()

        End Select

    End Sub

    Private Sub GuardarUsuario()
        Dim strContrasenaEncriptada As String = String.Empty
        Dim intUsuarioId As Integer
        Dim intMembresiaUsuario As Integer
        Dim fechaActual As Date
        Dim intExitoGuardarSucursales As Integer = 0
        Dim intAsignada As Integer = 0

        strContrasenaEncriptada = (New Hash.DataProtector).HashString(strUsuarioContrasena, Hash.DataProtector.CryptoServiceProvider.SHA1)

        fechaActual = Date.Now
        intUsuarioId = clsUsuario.intAgregarEnConcentrador(intEmpleadoId, _
                                                           0, _
                                                           intEmpleadoId.ToString(), _
                                                           strContrasenaEncriptada, _
                                                           CByte(blnUsuarioHabilitado), _
                                                           dtmFechaUsuarioExpiracion, _
                                                           fechaActual, _
                                                           fechaActual, _
                                                           strUsuarioNombre, _
                                                           0, _
                                                           0, _
                                                           CByte(blnUsuarioBloqueado), _
                                                           1, _
                                                           strConnectionString)

        If intUsuarioId > 0 Then
            _intUsuarioExistenteId = 1
            intMembresiaUsuario = clstblMembresiaUsuario.intAgregar(intEmpleadoId,
                                                                    intUsuarioId,
                                                                    intResultadoGrupoControlAsistencia,
                                                                    fechaActual,
                                                                    strUsuarioNombre,
                                                                    strConnectionString)
        End If

        ' Guardar sucursales.
        If intMembresiaUsuario > 0 Then
            AsignarSucursales(intExitoGuardarSucursales, intAsignada)
        End If

        If intMembresiaUsuario > 0 And intExitoGuardarSucursales > 0 Then
            strJavascriptWindowOnLoadCommands = "window.alert(""Usuario guardada correctamente."");"

            If intAsignada = 1 Then
                strJavascriptWindowOnLoadCommands = "window.alert(""Sucursal asignada a otro Coordinador ó Supervisor Médico, de cualquier forma se guardó correctamente."");"
            End If
        Else
            strJavascriptWindowOnLoadCommands = "window.alert(""Error al guardar usuario."");"
        End If
    End Sub

    Protected Function strObtenerSucursalesPorCoordinadorRH() As String
        Dim strResultadoTablaSucursales As New StringBuilder
        Dim objSucursales As Array

        If strCmd2 = "Editar" Or strCmd2 = "Modificar" Or strCmd2 = "Guardar" Then
            objSucursales = clsControlDeAsistencia.strObtenerSucursalesPorTipoUsuario(intEmpleadoId, strConnectionString)
        End If

        If IsArray(objSucursales) AndAlso objSucursales.Length > 0 Then
            strResultadoTablaSucursales.Append("<table id='tablaSucursalesAsignadas' width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strResultadoTablaSucursales.Append("<tr class='trtitulos'>")
            strResultadoTablaSucursales.Append("<th class='rayita' align='left' valign='top'>Compañia</th>")
            strResultadoTablaSucursales.Append("<th class='rayita' align='left' valign='top'>Sucursal</th>")
            strResultadoTablaSucursales.Append("<th class='rayita' align='left' valign='top'>Nombre</th>")
            strResultadoTablaSucursales.Append("<th class='rayita' align='left' valign='top'>Acción</th>")
            strResultadoTablaSucursales.Append("</tr>")

            strResultadoTablaSucursales.Append(CrearRegistrosSucursal(objSucursales))

            strResultadoTablaSucursales.Append("</table>")
        End If

        Return strResultadoTablaSucursales.ToString()
    End Function

    Private Function CrearRegistrosSucursal(ByVal registrosSucursal As Array) As String
        Dim contadorRegistros As Integer = 0
        Dim colorRegistro As String = String.Empty
        Dim resultadoUsuarios As New StringBuilder
        Dim imgDeshabilitarUsuario As String = "<img src='../static/images/imgNRDesasignar.gif' width='17' height='17' border='0' align='absMiddle' alt='Haga clic aquí para desasignar la sucursal' >"

        For Each renglon As SortedList In registrosSucursal
            contadorRegistros += 1

            If (contadorRegistros Mod 2) <> 0 Then
                colorRegistro = "tdceleste"
            Else
                colorRegistro = "tdblanco"
            End If

            resultadoUsuarios.Append("<tr>")
            resultadoUsuarios.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, renglon.Item("intCompaniaId").ToString())
            resultadoUsuarios.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, renglon.Item("intSucursalId").ToString())
            resultadoUsuarios.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, renglon.Item("Sucursal").ToString())

            resultadoUsuarios.AppendFormat("<td align='center' style='width: 50px;' class='{0}'>" & _
                                           "<a href='#' onClick='eliminarSucursal(this)'>" & _
                                           "{1}</a></td>", _
                                           colorRegistro, _
                                           imgDeshabilitarUsuario)

            resultadoUsuarios.Append("</tr>")
        Next

        Return resultadoUsuarios.ToString()
    End Function

    Private Sub EditarUsuario()
        Dim contrasenaGuardar As String = String.Empty
        Dim intResultadoActualizar As Integer = 0
        Dim intResultadoEliminarSucursales As Integer = 0
        Dim intExitoGuardarSucursales As Integer = 0
        Dim intAsignada As Integer = 0
        Dim blnUsuarioDebeCambiarContrasena As Boolean = False

        If strUsuarioContrasenaAnterior <> strUsuarioContrasena Then
            contrasenaGuardar = (New Hash.DataProtector).HashString(strUsuarioContrasena, Hash.DataProtector.CryptoServiceProvider.SHA1)
            blnUsuarioDebeCambiarContrasena = True
        Else
            contrasenaGuardar = strUsuarioContrasenaAnterior
        End If

        intResultadoActualizar = clstblUsuario.intActualizar2(intEmpleadoId, _
                                                              intUsuarioId, _
                                                              contrasenaGuardar, _
                                                              intTipoUsuarioIdParametro, _
                                                              CByte(blnUsuarioHabilitado), _
                                                              CByte(blnUsuarioBloqueado), _
                                                              CDate(Request.Form("txtUsuarioExpiracion").ToString()), _
                                                              strUsuarioNombre, _
                                                              CByte(blnUsuarioDebeCambiarContrasena),
                                                              strConnectionString)

        ' Eliminar sucursales para evitar repetidos.
        If intResultadoActualizar > -1 Then
            intResultadoEliminarSucursales = clsControlDeAsistencia.intEliminarSucursales(intEmpleadoId, strConnectionString)
        End If

        ' Guardar sucursales.
        If intResultadoEliminarSucursales = 0 Or intResultadoEliminarSucursales > 0 Then
            Call AsignarSucursales(intExitoGuardarSucursales, intAsignada)
        End If

        If intExitoGuardarSucursales > 0 Then

            If intAsignada = 1 Then
                strJavascriptWindowOnLoadCommands = "window.alert(""Sucursal asignada a otro Coordinador ó Supervisor Médico, de cualquier forma se modificó correctamente."");"
            Else
                strJavascriptWindowOnLoadCommands = "window.alert(""Usuario modificado correctamente."");"
            End If
        Else
            strJavascriptWindowOnLoadCommands = "window.alert(""Error al modificar usuario."");"
        End If
    End Sub

    Private Sub AsignarSucursales(ByRef intExitoGuardarSucursales As Integer, ByRef intAsignada As Integer)
        Dim companiaSucursalSeparadaPorPipe As String()
        Dim companiaSucursalSeparadaPorComa As String()
        Dim resultadoAsignarSucursales As Array = Nothing
        Dim intIndice As Integer = 0

        ' companiaSucursalSeparadaPorPipe = strCompaniasSucursalesSeleccionadas.Split(New Char() {"|"c})

        companiaSucursalSeparadaPorPipe = Request.Form("sucursalesExistentes").ToString().Split(New Char() {"|"c})


        For intIndice = 0 To companiaSucursalSeparadaPorPipe.Length - 1

            If companiaSucursalSeparadaPorPipe.GetValue(intIndice).ToString() <> String.Empty Then

                companiaSucursalSeparadaPorComa = companiaSucursalSeparadaPorPipe.GetValue(intIndice).ToString().Split(New Char() {","c})

                resultadoAsignarSucursales = clsControlDeAsistencia. _
                                             strAsignarSucursales2(intEmpleadoId, _
                                                                   CInt(companiaSucursalSeparadaPorComa.GetValue(0)), _
                                                                   CInt(companiaSucursalSeparadaPorComa.GetValue(1)), _
                                                                   intTipoUsuarioIdParametro, _
                                                                   strConnectionString)

                If resultadoAsignarSucursales.Length > 0 AndAlso IsArray(resultadoAsignarSucursales) Then

                    ' Recorremos los pares identificadores
                    Dim strResultadosAsignacionSucursal As Array

                    For Each strResultadosAsignacionSucursal In resultadoAsignarSucursales

                        If Not (strResultadosAsignacionSucursal.GetValue(0) Is Nothing) AndAlso _
                           Not (CInt(strResultadosAsignacionSucursal.GetValue(0)) = -1) Then
                            intExitoGuardarSucursales = CInt(strResultadosAsignacionSucursal.GetValue(0))
                        Else
                            intExitoGuardarSucursales = 0
                            Exit For
                        End If

                        If Not (strResultadosAsignacionSucursal.GetValue(1) Is Nothing) AndAlso _
                           Not CBool(strResultadosAsignacionSucursal.GetValue(1)) = False Then
                            intAsignada = 1
                        End If
                    Next

                End If
            End If
        Next
    End Sub

End Class
