
Imports System.Text
Imports Benavides.Data.SQL.MSSQL

Public NotInheritable Class clstblHistoricoActaFaltanteCaja
    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblAsignacionCaja"

    ' Constructor en blanco para prevenir la generaci�n de un constructor por defecto
    Private Sub New()
    End Sub

    Public Shared Function intAgregar(ByVal intCompaniaId As Integer, _
                                      ByVal intSucursalId As Integer, _
                                      ByVal intEmpleadoId As Integer, _
                                      ByVal intTipoActa As Integer, _
                                      ByVal dtmFechaAsignacion As Date, _
                                      ByVal strConnectionString As String) As Integer
        ' Constantes locales
        Const strmThisMemberName As String = "intAgregar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder
        Dim intRowsAffected As Integer
        Dim strRegistros As Array
        Dim strRowsAffected As String()

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spAgregartblHistoricoActa ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoActa)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaAsignacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

            For Each strRowsAffected In strRegistros

                intRowsAffected = CInt(strRowsAffected.GetValue(0))

            Next

            ' Regresamos la informaci�n
            strSQLStatement = Nothing
            intAgregar = intRowsAffected

        Catch objException As Exception
            ' Variables locales
            Dim strErrorString As StringBuilder = New StringBuilder
            Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
            Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
            Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
            Dim strSource As String = objException.Source
            Dim strMessage As String = objException.Message
            Dim strStackTrace As String = objException.StackTrace
            Dim intLineNumber As Integer = Erl()
            Dim intErrorNumber As Integer = Err.Number
            Dim intCategoryNumber As Short = 0

            ' Creamos el mensaje de error
            Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
            Call strErrorString.Append("Application name:" & vbCrLf & vbTab & strApplicationName & vbCrLf & vbCrLf)
            Call strErrorString.Append("Version:" & vbCrLf & vbTab & strVersion & vbCrLf & vbCrLf)
            Call strErrorString.Append("Source:" & vbCrLf & vbTab & strSource & vbCrLf & vbCrLf)
            Call strErrorString.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(intErrorNumber) & vbCrLf & vbCrLf)
            Call strErrorString.Append("Line number:" & vbCrLf & vbTab & intLineNumber & vbCrLf & vbCrLf)
            Call strErrorString.Append("Message:" & vbCrLf & vbTab & strMessage & vbCrLf & vbCrLf)
            Call strErrorString.Append("SQLStatement:" & vbCrLf & vbTab & strSQLStatement.ToString() & vbCrLf & vbCrLf)
            Call strErrorString.Append("StackTrace:" & vbCrLf & strStackTrace & vbCrLf & vbCrLf)

            ' Creamos un evento para registrar el mensaje de error
            If Not EventLog.SourceExists(strProductName) Then

                Call EventLog.CreateEventSource(strProductName, "Application")

            End If

            ' Establecemos la fuente del evento
            objApplicationEventLog.Source = strProductName

            ' Escribimos el evento en el Visor de Eventos
            Call objApplicationEventLog.WriteEntry(strErrorString.ToString(), EventLogEntryType.Error, Err.Number, intCategoryNumber)

            ' Regresamos la informaci�n
            intAgregar = 0

        End Try

    End Function


End Class
