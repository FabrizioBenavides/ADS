Imports System.Text
Imports Benavides.Data.SQL.MSSQL

Public Class clsReporteDeTarjetas
    ' Class identifier
    Private Const strmThisClassName As String = "Benavides.CC.Data.clsReporteDeTarjetas"

    ' Class constructor
    Private Sub New()
        ' Empty constructor to avoid the creation of the default constructor
    End Sub

#Region "Sucursal"
    '====================================================================
    ' Name       : strObtenerReporteVisitas
    ' Description: Consultar el Reporte de las visitas en sucursal.
    '             
    ' Parameters :
    '               ByVal intSucursalId As Integer
    '               ByVal intCompaniaId As As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                '====================================================================
    Public Shared Function strObtenerReporteTarjetas(ByVal intCompaniaId As Integer, _
                                                     ByVal intSucursalId As Integer, _
                                                     ByVal intTipoTarjeta As Integer, _
                                                     ByVal intEmpleadoId As Integer, _
                                                     ByVal dtmFechaInicio As Date, _
                                                     ByVal dtmFechaFin As Date, _
                                                     ByVal strConnectionString As String) As Array


        ' Constantes locales
        Const strmThisMemberName As String = "strObtenerReporteTarjetas"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spObtenerReporteDeTarjetas ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoTarjeta)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(dtmFechaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFechaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strObtenerReporteTarjetas = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
            strSQLStatement = Nothing

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
            Dim intCategoryNumber As Short : intCategoryNumber = 100

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

            ' Regresamos la información
            strSQLStatement = Nothing
            strObtenerReporteTarjetas = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try



    End Function
#End Region

End Class
