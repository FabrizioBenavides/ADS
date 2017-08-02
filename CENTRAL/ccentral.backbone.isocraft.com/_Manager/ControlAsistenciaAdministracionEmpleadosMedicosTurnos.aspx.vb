Imports Benavides.CC.Data
Imports Benavides.POSAdmin.Commons
Imports Isocraft.Security
Imports Isocraft.Web.Http
Imports System.Collections
Imports System.Diagnostics
Imports System.Text

Public Class ControlAsistenciaAdministracionEmpleadosMedicosTurnos
    Inherits PaginaBase

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Private _blnTieneDiaDescanso As Boolean = False
    Private Const VALOR_DIA_DESCANSO As Integer = 0
    Private Const CANTIDAD_DIAS_SEMANA As Integer = 7
    Private Const SABADO_Y_DOMINGO_ID As Integer = 8

    Public ReadOnly Property intEmpleadoId() As Integer
        Get
            Return CInt(Request.QueryString("intEmpleadoId"))
        End Get
    End Property

    Public ReadOnly Property strTieneDiaDescanso() As String
        Get
            Return _blnTieneDiaDescanso.ToString()
        End Get
    End Property

    Protected Function LLenarComboEmpleados() As String
        Dim controlEmpleados As New StringBuilder
        Dim resultadoConsulta As Array = Nothing
        Dim objMedicos As New Collections.SortedList
        Dim strSeleccionado As String = String.Empty

        resultadoConsulta = clsControlDeAsistencia.clsRolMedico. _
                            strBuscarEmpleadosMedicos(CInt(strUsuarioNombre), strConnectionString)

        If resultadoConsulta IsNot Nothing AndAlso resultadoConsulta.Length > 0 Then

            For i As Integer = 0 To resultadoConsulta.Length - 1

                objMedicos = CType(resultadoConsulta.GetValue(i), Collections.SortedList)

                If CInt(objMedicos.Item("intEmpleadoId")) = intEmpleadoId Then
                    strSeleccionado = "selected"
                End If

                controlEmpleados.AppendFormat("<option value=""{0}"" {1} >{2}</option>", _
                                                  objMedicos.Item("intEmpleadoId").ToString(), _
                                                  strSeleccionado, _
                                                  objMedicos.Item("NombreEmpleado").ToString())

                strSeleccionado = String.Empty
            Next
        End If

        Return controlEmpleados.ToString()
    End Function

    Public ReadOnly Property strCmd2() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd2", "")
        End Get
    End Property

    Public ReadOnly Property intDomingo() As Integer
        Get
            Return CInt(Request.QueryString("intDomingo"))
        End Get
    End Property

    Public ReadOnly Property intLunes() As Integer
        Get
            Return CInt(Request.QueryString("intLunes"))
        End Get
    End Property

    Public ReadOnly Property intMartes() As Integer
        Get
            Return CInt(Request.QueryString("intMartes"))
        End Get
    End Property

    Public ReadOnly Property intMiercoles() As Integer
        Get
            Return CInt(Request.QueryString("intMiercoles"))
        End Get
    End Property

    Public ReadOnly Property intJueves() As Integer
        Get
            Return CInt(Request.QueryString("intJueves"))
        End Get
    End Property

    Public ReadOnly Property intViernes() As Integer
        Get
            Return CInt(Request.QueryString("intViernes"))
        End Get
    End Property

    Public ReadOnly Property intSabado() As Integer
        Get
            Return CInt(Request.QueryString("intSabado"))
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Call ValidarExistenciaDiaDescanso()

        Try

            Select Case strCmd2

                Case "Aplicar"
                    Call AplicarHorarioAMedico()

            End Select

        Catch objException As Exception
            ' Variables locales
            Dim strErrorString As StringBuilder : strErrorString = New StringBuilder
            Dim objApplicationEventLog As System.Diagnostics.EventLog : objApplicationEventLog = New System.Diagnostics.EventLog
            Dim strProductName As String : strProductName = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
            Dim strApplicationName As String : strApplicationName = System.Reflection.Assembly.GetExecutingAssembly.Location
            Dim strVersion As String : strVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
            Dim strSource As String : strSource = objException.Source
            Dim strMessage As String : strMessage = objException.Message
            Dim strStackTrace As String : strStackTrace = objException.StackTrace
            Dim intLineNumber As Integer : intLineNumber = Erl()
            Dim intErrorNumber As Integer : intErrorNumber = Err.Number
            Dim intCategoryNumber As Short : intCategoryNumber = 0

            ' Identificador de la clase
            Dim strmThisClassName As String = "com.isocraft.backbone.central.ControlAsistenciaAdministracionEmpleadosMedicosTurnos.aspx"
            Dim strmThisMemberName As String = "Load"

            ' Creamos el mensaje de error
            Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
            Call strErrorString.Append("Application name:" & vbCrLf & vbTab & strApplicationName & vbCrLf & vbCrLf)
            Call strErrorString.Append("Version:" & vbCrLf & vbTab & strVersion & vbCrLf & vbCrLf)
            Call strErrorString.Append("Source:" & vbCrLf & vbTab & strSource & vbCrLf & vbCrLf)
            Call strErrorString.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(intErrorNumber) & vbCrLf & vbCrLf)
            Call strErrorString.Append("Line number:" & vbCrLf & vbTab & intLineNumber & vbCrLf & vbCrLf)
            Call strErrorString.Append("Message:" & vbCrLf & vbTab & strMessage & vbCrLf & vbCrLf)
            Call strErrorString.Append("StackTrace:" & vbCrLf & strStackTrace & vbCrLf & vbCrLf)

            ' Creamos un evento para registrar el mensaje de error
            If Not EventLog.SourceExists(strProductName) Then
                Call EventLog.CreateEventSource(strProductName, "Application")
            End If

            ' Establecemos la fuente del evento
            objApplicationEventLog.Source = strProductName

            ' Escribimos el evento en el Visor de Eventos
            Call objApplicationEventLog.WriteEntry(strErrorString.ToString(), EventLogEntryType.Error, Err.Number, intCategoryNumber)

            ' Notificamos el error
            Throw
        End Try
    End Sub

    Private Sub ValidarExistenciaDiaDescanso()
        Dim resultadoDiaDescanso As Array = Nothing

        resultadoDiaDescanso = clsControlDeAsistencia.clsRolMedico.strObtenerDiaDescanso(intEmpleadoId, strConnectionString)

        If Not resultadoDiaDescanso Is Nothing AndAlso resultadoDiaDescanso.Length > 0 Then
            _blnTieneDiaDescanso = True
        End If
    End Sub

    Public Function strGeneraTablaHorarioHTML() As String
        Dim strResultadoTablaHorario As New StringBuilder
        Dim objHorarioLaboralEmpleado As Array
        Dim objHorarioAsignadoEmpleado As Array

        objHorarioLaboralEmpleado = clsControlDeAsistencia.clsRolMedico.strBuscarHorarioLaboralPorEmpleadoId(intEmpleadoId, strConnectionString)

        objHorarioAsignadoEmpleado = clsControlDeAsistencia. _
                                     clsRolMedico. _
                                     strBuscarAsignacionHorarioLaboralPorEmpleadoId(intEmpleadoId, strConnectionString)

        strResultadoTablaHorario.Append("<table id='Table2' class='tdenvolventetablas' cellspacing='0' cellpadding='0' valign='top'>")
        strResultadoTablaHorario.Append("<tr>")
        strResultadoTablaHorario.Append("<th height='25' align='center' class='txsubtitulo' colspan='2'>Horario</th>")
        strResultadoTablaHorario.Append("<th height='25' align='center' class='txsubtitulo'>&nbsp;Domingo&nbsp;</th>")
        strResultadoTablaHorario.Append("<th height='25' align='center' class='txsubtitulo'>&nbsp;Lunes&nbsp;</th>")
        strResultadoTablaHorario.Append("<th height='25' align='center' class='txsubtitulo'>&nbsp;Martes&nbsp;</th>")
        strResultadoTablaHorario.Append("<th height='25' align='center' class='txsubtitulo'>&nbsp;Miércoles&nbsp;</th>")
        strResultadoTablaHorario.Append("<th height='25' align='center' class='txsubtitulo'>&nbsp;Jueves&nbsp;</th>")
        strResultadoTablaHorario.Append("<th height='25' align='center' class='txsubtitulo'>&nbsp;Viernes&nbsp;</th>")
        strResultadoTablaHorario.Append("<th height='25' align='center' class='txsubtitulo'>&nbsp;Sábado&nbsp;</th>")
        strResultadoTablaHorario.Append("</tr>")

        If (Not objHorarioLaboralEmpleado Is Nothing AndAlso objHorarioLaboralEmpleado.Length > 0) AndAlso _
           (Not objHorarioAsignadoEmpleado Is Nothing AndAlso objHorarioAsignadoEmpleado.Length > 0) Then

            strResultadoTablaHorario.Append(strCrearRenglonesHorarioConHorarioAsignadoEmpleado(objHorarioLaboralEmpleado, objHorarioAsignadoEmpleado))
        Else

            strResultadoTablaHorario.Append(strCrearRenglonesHorarioSinHorarioAsignadoEmpleado(objHorarioLaboralEmpleado))
        End If

        strResultadoTablaHorario.Append("</table>")

        Return strResultadoTablaHorario.ToString()
    End Function

    Private Function strCrearRenglonesHorarioConHorarioAsignadoEmpleado(ByVal objHorarioLaboralEmpleado As Array, ByVal objHorarioAsignadoEmpleado As Array) As String
        Dim strRenglonesTablaHorario As New StringBuilder
        Dim intCantidadRenglonesTabla As Integer
        Dim intIndiceRenglones As Integer
        Dim renglonEmpleado As SortedList
        Dim intIdConsecutivoBoton As Integer = 1
        Dim intValorBoton As Integer = 1
        Dim intDiaSemanaHoy As Integer = Date.Today.DayOfWeek
        Dim intDiaDescanso As Integer

        intDiaDescanso = intObtenerDiaSemanaDescanso()

        intCantidadRenglonesTabla = objHorarioLaboralEmpleado.Length - 1

        For intIndiceRenglones = 0 To intCantidadRenglonesTabla

            renglonEmpleado = DirectCast(objHorarioLaboralEmpleado.GetValue(intIndiceRenglones), SortedList)

            strRenglonesTablaHorario.Append("<tr>")
            strRenglonesTablaHorario.Append(strGenerarDiasSemana(intIdConsecutivoBoton, _
                                                                 intValorBoton, _
                                                                 CInt(renglonEmpleado.Item("intHorarioLaboralId").ToString()), _
                                                                 renglonEmpleado.Item("strHorarioLaboralNombre").ToString(), _
                                                                 intDiaSemanaHoy, _
                                                                 objHorarioAsignadoEmpleado, _
                                                                 intDiaDescanso))
            strRenglonesTablaHorario.Append("</tr>")
        Next

        Return strRenglonesTablaHorario.ToString()
    End Function

    Private Function strGenerarDiasSemana(ByRef intIdConsecutivoBoton As Integer, _
                                          ByRef intValorBoton As Integer, _
                                          ByRef intHorarioLaboralId As Integer, _
                                          ByVal strHorarioLaboralNombre As String, _
                                          ByVal intDiaSemanaHoy As Integer, _
                                          ByVal objHorarioAsignadoEmpleado As Array, _
                                          ByVal intDiaDescanso As Integer) As String

        Dim intContadorDiaSemana As Integer = 1
        Dim strRenglonesHorarioDiasAsignados As New StringBuilder
        Dim strBotonDeshabilitado As String = String.Empty
        Dim strEstadoBoton As String = String.Empty

        strRenglonesHorarioDiasAsignados.AppendFormat("<td height='21' class='tdtittablas3' colspan='2'>{0}&nbsp;</td>", strHorarioLaboralNombre)

        For intContadorDiaSemana = 1 To CANTIDAD_DIAS_SEMANA

            strBotonDeshabilitado = strValidarDeshabilitarBoton(intDiaSemanaHoy, intContadorDiaSemana, intDiaDescanso)

            strRenglonesHorarioDiasAsignados.Append("<td height='21' align='center' class='tdtittablas3'>")

            strEstadoBoton = strEstablecerEstadoControlDiaSemana(intHorarioLaboralId, intContadorDiaSemana, objHorarioAsignadoEmpleado)

            strRenglonesHorarioDiasAsignados. _
                AppendFormat("<input name='dia{0}' id='rb{1}' type='radio' value='{2}' {3} {4} ></td>", intContadorDiaSemana, _
                                                                                                        intIdConsecutivoBoton, _
                                                                                                        intHorarioLaboralId, _
                                                                                                        strBotonDeshabilitado, _
                                                                                                        strEstadoBoton)
            intIdConsecutivoBoton = intIdConsecutivoBoton + 1
            strEstadoBoton = String.Empty
        Next

        intValorBoton = intValorBoton + 1

        Return strRenglonesHorarioDiasAsignados.ToString()
    End Function

    Private Function strEstablecerEstadoControlDiaSemana(ByVal intHorarioLaboralId As Integer, _
                                                         ByVal intContadorDiaSemana As Integer, _
                                                         ByVal objHorarioAsignadoEmpleado As Array) As String
        Dim strEstadoBoton As String = "UNCHECKED"
        Dim intHorarioLaboralIdEmpleadoConsultado As Integer
        Dim intDiaSemanaId As Integer
        Dim blnTieneHorarioLaboralAsignado As Boolean = False
        Dim blnEsMismoDiaSemana As Boolean = False
        Dim blnEsMismoHorarioLaboral As Boolean = False

        For Each renglon As SortedList In objHorarioAsignadoEmpleado

            intDiaSemanaId = CInt(renglon.Item("intDiaSemanaId"))
            intHorarioLaboralIdEmpleadoConsultado = CInt(renglon.Item("intHorarioLaboralId"))

            blnEsMismoDiaSemana = (intContadorDiaSemana = intDiaSemanaId)
            blnEsMismoHorarioLaboral = (intHorarioLaboralIdEmpleadoConsultado = intHorarioLaboralId)

            If blnEsMismoDiaSemana And blnEsMismoHorarioLaboral Then

                blnTieneHorarioLaboralAsignado = True
                Exit For
            End If
        Next

        If blnTieneHorarioLaboralAsignado = True Then
            strEstadoBoton = "CHECKED"
        End If

        Return strEstadoBoton
    End Function

    Private Function strValidarDeshabilitarBoton(ByVal intDiaSemanaHoy As Integer, _
                                                 ByVal intContadorDiaSemana As Integer, _
                                                 ByVal intDiaDescanso As Integer) As String

        Dim strBotonDeshabilitado As String = String.Empty
        Dim blnEsDiaDescanso As Boolean = False
        Dim blnEsDiaActual As Boolean = False
        Dim blnDescansaSabadoYDomingo As Boolean = False
        Dim blnEsFinDeSemana As Boolean = False

        blnDescansaSabadoYDomingo = (intDiaDescanso = SABADO_Y_DOMINGO_ID)
        blnEsFinDeSemana = (intContadorDiaSemana = 1 Or intContadorDiaSemana = 7)

        blnEsDiaDescanso = (intDiaDescanso = intContadorDiaSemana)
        blnEsDiaActual = ((intDiaSemanaHoy + 1) = intContadorDiaSemana)

        If (blnDescansaSabadoYDomingo And blnEsFinDeSemana) Or blnEsDiaDescanso Or blnEsDiaActual Then

            strBotonDeshabilitado = "DISABLED"
        End If

        Return strBotonDeshabilitado
    End Function

    'ByVal objHorarioAsignadoEmpleado As Array
    'Private Function intEncontrarDiaSemanaDescanso() As Integer
    '    Dim intDiaSemanaDescanso As Integer
    '    'Dim objDiaSemanaDescanso As Array
    '    'Dim renglonDiaDescanso As SortedList

    '    'If Not objHorarioAsignadoEmpleado Is Nothing AndAlso objHorarioAsignadoEmpleado.Length > 0 Then

    '    '    For Each renglon As SortedList In objHorarioAsignadoEmpleado

    '    '        If CInt(renglon.Item("intHorarioLaboralId")) = VALOR_DIA_DESCANSO Then
    '    '            intDiaSemanaDescanso = CInt(renglon.Item("intDiaSemanaId"))
    '    '        End If
    '    '    Next
    '    'End If
    '    'objDiaSemanaDescanso = clsControlDeAsistencia.clsRolMedico.strObtenerDiaDescanso(intEmpleadoId, strConnectionString)

    '    'renglonDiaDescanso = DirectCast(objDiaSemanaDescanso.GetValue(0), SortedList)

    '    'intDiaSemanaDescanso = CInt(renglonDiaDescanso.Item("intDiaSemanaId").ToString())

    '    Return intDiaSemanaDescanso
    'End Function

    Private Sub AplicarHorarioAMedico()
        Dim intResultado As Integer

        intResultado = clsControlDeAsistencia.clsRolMedico.intGuardarAsignacionTurnos(intEmpleadoId, _
                                                                                      intDomingo, _
                                                                                      intLunes, _
                                                                                      intMartes, _
                                                                                      intMiercoles, _
                                                                                      intJueves, _
                                                                                      intViernes, _
                                                                                      intSabado, _
                                                                                      strUsuarioNombre, _
                                                                                      strConnectionString)
        If intResultado > -1 Then
            strJavascriptWindowOnLoadCommands = "window.alert(""Turnos asignados correctamente."");"
        Else
            strJavascriptWindowOnLoadCommands = "window.alert(""Error al asignar turnos."");"
        End If
    End Sub

    Private Function strCrearRenglonesHorarioSinHorarioAsignadoEmpleado(ByVal objHorarioLaboralEmpleado As Array) As String
        Dim intCantidadRenglonesTabla As Integer
        Dim intIndiceRenglones As Integer
        Dim strRenglonesTablaHorario As New StringBuilder
        Dim intContadorDiaSemana As Integer = 1
        Dim renglonEmpleado As SortedList
        Dim intIdConsecutivoBoton As Integer = 0
        Dim intHorarioLaboralId As String
        Dim resultadoDiaDescanso As Array = Nothing
        Dim intDiaSemanaDescanso As Integer
        Dim strBotonDeshabilitado As String = String.Empty
        Dim blnEsFinDeSemana As Boolean = False

        intCantidadRenglonesTabla = objHorarioLaboralEmpleado.Length - 1

        intDiaSemanaDescanso = intObtenerDiaSemanaDescanso()

        For intIndiceRenglones = 0 To intCantidadRenglonesTabla

            renglonEmpleado = DirectCast(objHorarioLaboralEmpleado.GetValue(intIndiceRenglones), SortedList)

            strRenglonesTablaHorario.Append("<tr>")
            strRenglonesTablaHorario.AppendFormat("<td height='21' class='tdtittablas3' colspan='2'>{0}&nbsp;</td>", _
                                                  renglonEmpleado.Item("strHorarioLaboralNombre").ToString())


            intHorarioLaboralId = renglonEmpleado.Item("intHorarioLaboralId").ToString()

            For intContadorDiaSemana = 1 To CANTIDAD_DIAS_SEMANA

                intIdConsecutivoBoton = intIdConsecutivoBoton + 1

                strRenglonesTablaHorario.Append("<td height='21' align='center' class='tdtittablas3'>")

                blnEsFinDeSemana = (intContadorDiaSemana = 1 Or intContadorDiaSemana = 7)

                If (intContadorDiaSemana = intDiaSemanaDescanso) Or _
                   ((blnEsFinDeSemana) And intDiaSemanaDescanso = SABADO_Y_DOMINGO_ID) Then
                    strBotonDeshabilitado = "DISABLED"
                End If

                strRenglonesTablaHorario.AppendFormat("<input name='dia{0}' id='rb{1}' type='radio' value='{2}' {3} ></td>", intContadorDiaSemana, _
                                                                                                                             intIdConsecutivoBoton, _
                                                                                                                             intHorarioLaboralId, _
                                                                                                                             strBotonDeshabilitado)
                strBotonDeshabilitado = String.Empty
            Next

            strRenglonesTablaHorario.Append("</tr>")
        Next

        Return strRenglonesTablaHorario.ToString()
    End Function

    Protected Function intObtenerDiaSemanaDescanso() As Integer
        Dim intDiaSemanaDescanso As Integer
        Dim objResultado As Array
        Dim renglonEmpleado As SortedList

        objResultado = clsControlDeAsistencia.clsRolMedico.strObtenerDiaDescanso(intEmpleadoId, strConnectionString)

        renglonEmpleado = DirectCast(objResultado.GetValue(0), SortedList)

        intDiaSemanaDescanso = CInt(renglonEmpleado.Item("intDiaSemanaId"))

        Return intDiaSemanaDescanso
    End Function

End Class