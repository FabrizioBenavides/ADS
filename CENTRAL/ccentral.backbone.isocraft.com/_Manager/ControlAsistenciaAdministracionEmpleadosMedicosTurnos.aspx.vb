Imports Benavides.CC.Data
Imports Benavides.POSAdmin.Commons
Imports Isocraft.Security
Imports Isocraft.Web.Http
Imports System.Collections
Imports System.Text
Imports System.Diagnostics

Public Class ControlAsistenciaAdministracionEmpleadosMedicosTurnos
    Inherits PaginaBase

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Private _blnTieneDiaDescanso As Boolean = False

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

        resultadoConsulta = clsControlDeAsistencia.clsRolMedico. _
                            strBuscarEmpleadosMedicos(CInt(strUsuarioNombre), strConnectionString)

        If resultadoConsulta IsNot Nothing AndAlso resultadoConsulta.Length > 0 Then

            For i As Integer = 0 To resultadoConsulta.Length - 1

                objMedicos = CType(resultadoConsulta.GetValue(i), Collections.SortedList)

                controlEmpleados.AppendFormat("<option value=""{0}"">{1}</option>", _
                                                  objMedicos.Item("intEmpleadoId").ToString(), _
                                                  objMedicos.Item("NombreEmpleado").ToString())
            Next
        End If

        Return controlEmpleados.ToString()
    End Function

    Public ReadOnly Property strCmd2() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd2", "")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Call ValidarExistenciaDiaDescanso()

        Try

            Select Case strCmd2

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
            Dim strmThisClassName As String = "com.isocraft.backbone.SucursalEmpleadosControlAsistenciasConfirmacionAsistencias.aspx"
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

        strResultadoTablaHorario.Append(strCrearRenglonesHorario())

        strResultadoTablaHorario.Append("</table>")

        Return strResultadoTablaHorario.ToString()
    End Function

    Private Function strCrearRenglonesHorario() As String
        Dim objHorarioLaboralEmpleado As Array
        Dim strRenglonesTablaHorario As New StringBuilder
        Dim intCantidadRenglonesTabla As Integer
        Dim intIndiceRenglones As Integer
        Dim renglonEmpleado As SortedList
        Dim idConsecutivoRadio As Integer = 1
        Dim intValorRadio As Integer = 1
        Dim intDiaSemanaHoy As Integer = Date.Today.DayOfWeek
        Dim objHorarioAsignadoEmpleado As Array

        objHorarioLaboralEmpleado = clsControlDeAsistencia.clsRolMedico.strBuscarHorarioLaboralPorEmpleadoId(intEmpleadoId, strConnectionString)

        objHorarioAsignadoEmpleado = clsControlDeAsistencia. _
                                     clsRolMedico. _
                                     strBuscarAsignacionHorarioLaboralPorEmpleadoId(intEmpleadoId, strConnectionString)

        intCantidadRenglonesTabla = objHorarioLaboralEmpleado.Length - 1

        For intIndiceRenglones = 0 To intCantidadRenglonesTabla

            renglonEmpleado = DirectCast(objHorarioLaboralEmpleado.GetValue(intIndiceRenglones), SortedList)

            strRenglonesTablaHorario.Append("<tr>")

            strRenglonesTablaHorario.Append(strGenerarDiasSemana(idConsecutivoRadio, _
                                                                 intValorRadio, _
                                                                 CInt(renglonEmpleado.Item("intHorarioLaboralId").ToString()), _
                                                                 renglonEmpleado.Item("strHorarioLaboralNombre").ToString(), _
                                                                 intDiaSemanaHoy, _
                                                                 objHorarioAsignadoEmpleado))

            strRenglonesTablaHorario.Append("</tr>")
        Next

        Return strRenglonesTablaHorario.ToString()
    End Function

    Private Function strGenerarDiasSemana(ByRef idConsecutivoRadio As Integer, _
                                          ByRef intValorRadio As Integer, _
                                          ByRef intHorarioLaboralId As Integer, _
                                          ByVal strHorarioLaboralNombre As String, _
                                          ByVal intDiaSemanaHoy As Integer, _
                                          ByVal objHorarioAsignadoEmpleado As Array) As String

        Const intCantidadDiasSemana As Integer = 7
        Dim intDomingo As Integer = 1
        Dim strRenglonesHorarioDiasAsignados As New StringBuilder
        Dim strBotonDeshabilitado As String = String.Empty
        Dim valorControl As String = String.Empty

        strRenglonesHorarioDiasAsignados.AppendFormat("<td height='21' class='tdtittablas3' colspan='2'>{0}&nbsp;</td>", strHorarioLaboralNombre)

        For intDomingo = 1 To intCantidadDiasSemana

            If (intDiaSemanaHoy + 1) = intDomingo Then
                strBotonDeshabilitado = "disabled=''"
            Else
                strBotonDeshabilitado = String.Empty
            End If

            strRenglonesHorarioDiasAsignados.Append("<td height='21' align='center' class='tdtittablas3'>")

            valorControl = strEstablecerValorControlDiaSemana(objHorarioAsignadoEmpleado) ' unchecked=''

            strRenglonesHorarioDiasAsignados. _
                AppendFormat("<input name='dia{0}' id='rb{1}' type='radio' value='{2}' {3}  {4} unchecked=''></td>", intDomingo, _
                                                                                                                     idConsecutivoRadio, _
                                                                                                                     intHorarioLaboralId, _
                                                                                                                     strBotonDeshabilitado, _
                                                                                                                      valorControl)
            idConsecutivoRadio = idConsecutivoRadio + 1
        Next

        intValorRadio = intValorRadio + 1

        Return strRenglonesHorarioDiasAsignados.ToString()
    End Function

    Private Function strEstablecerValorControlDiaSemana(ByVal objHorarioAsignadoEmpleado As Array) As String

    End Function


End Class