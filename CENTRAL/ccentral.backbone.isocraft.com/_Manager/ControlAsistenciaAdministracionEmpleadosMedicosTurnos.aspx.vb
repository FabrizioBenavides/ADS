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




End Class