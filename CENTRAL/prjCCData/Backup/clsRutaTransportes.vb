Imports System.Text
Imports Benavides.Data.SQL.MSSQL

''' <summary>
''' Rutas de transporte para sucursales.
''' </summary>
''' <remarks></remarks>
Public Class clsRutaTransportes

    Private Const strmThisClassName As String = "Benavides.CC.Data.clsRutaTransportes"

    Public Shared Function strConsultarTblRutaTransportes(ByVal strRutaTransportesClave As String, _
                                                          ByVal intRutaTransportesTipoId As Integer, _
                                                          ByVal intDestinoId As Integer, _
                                                          ByVal intProveedorId As Integer, _
                                                          ByVal strConnectionString As String) As Array
        ' Member identifier
        Const strmThisMemberName As String = "strConsultarTblRutaTransportes"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array

        Try

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder

            strSQLStatement.AppendFormat("EXECUTE spConsultarTblRutaTransportes '{0}', {1}, {2}, {3}", _
                                                                                strRutaTransportesClave, _
                                                                                intRutaTransportesTipoId, _
                                                                                intDestinoId, _
                                                                                intProveedorId)

            ' Execute the SQL statement
            aobjReturnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

            ' Return the results
            Return aobjReturnedData

        Catch objException As Exception

            ' Declare the error variables
            Dim strErrorString As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName

            ' Create the error message
            Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
            Call strErrorString.Append("Application name:" & vbCrLf & vbTab & System.Reflection.Assembly.GetExecutingAssembly.Location & vbCrLf & vbCrLf)
            Call strErrorString.Append("Version:" & vbCrLf & vbTab & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & vbCrLf & vbCrLf)
            Call strErrorString.Append("Source:" & vbCrLf & vbTab & objException.Source & vbCrLf & vbCrLf)
            Call strErrorString.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(Err.Number) & vbCrLf & vbCrLf)
            Call strErrorString.Append("Line number:" & vbCrLf & vbTab & Erl() & vbCrLf & vbCrLf)
            Call strErrorString.Append("Message:" & vbCrLf & vbTab & objException.Message & vbCrLf & vbCrLf)
            Call strErrorString.Append("SQLStatement:" & vbCrLf & vbTab & strSQLStatement.ToString() & vbCrLf & vbCrLf)
            Call strErrorString.Append("StackTrace:" & vbCrLf & objException.StackTrace & vbCrLf & vbCrLf)

            ' Create the event source
            If Not EventLog.SourceExists(strProductName) Then
                Call EventLog.CreateEventSource(strProductName, "Application")
            End If

            ' Set the event source
            objApplicationEventLog.Source = strProductName

            ' Write the event. It can be read in the Event Viewer.
            Call objApplicationEventLog.WriteEntry(strErrorString.ToString(), EventLogEntryType.Error, Err.Number, 0)

            ' Clear the variables
            strSQLStatement = Nothing
            aobjReturnedData = Nothing

            ' Raise the error
            Throw
        End Try
    End Function

    Public Shared Function intGuardarTblRutaTransportes( _
                                              ByVal strRutaTransportesClave As String, _
                                              ByVal intRutaTransportesTipoId As Integer, _
                                              ByVal intDestinoId As Integer, _
                                              ByVal intProveedorId As Integer, _
                                              ByVal intTolerancia As Integer, _
                                              ByVal dtmUltimaModificacion As Date, _
                                              ByVal strModificadoPor As String, _
                                              ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intGuardarTblRutaTransportes"
        Dim strSQLStatement As StringBuilder
        Dim strRegistros As Array
        Dim intRowsAffected As Integer = 0
        Dim strRowsAffected As String() = Nothing

        Try

            strSQLStatement = New StringBuilder

            strSQLStatement.AppendFormat("EXECUTE spGuardarTblRutaTransportes '{0}', {1}, {2}, " & _
                                                                            "  {3},  {4}, '{5}', '{6}'", _
                                                        strRutaTransportesClave, _
                                                        intRutaTransportesTipoId, _
                                                        intDestinoId, _
                                                        intProveedorId, _
                                                        intTolerancia, _
                                                        dtmUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), _
                                                        strModificadoPor)

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

            For Each strRowsAffected In strRegistros
                intRowsAffected = CInt(strRowsAffected.GetValue(0))
            Next

            ' Regresamos la información
            strSQLStatement = Nothing
            intGuardarTblRutaTransportes = intRowsAffected

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
            Dim intRegistroRepetido As Integer = DirectCast(objException, System.Data.SqlClient.SqlException).Number

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

            ' Cuando se intenta insertar un registro repetido.
            If intRegistroRepetido = 2627 Then
                intGuardarTblRutaTransportes = -1
            End If

        End Try
    End Function

    Public Shared Function intActualizarTblRutaTransportes( _
                                              ByVal intRutaTransportesId As Integer, _
                                              ByVal strRutaTransportesClave As String, _
                                              ByVal intRutaTransportesTipoId As Integer, _
                                              ByVal intDestinoId As Integer, _
                                              ByVal intProveedorId As Integer, _
                                              ByVal intTolerancia As Integer, _
                                              ByVal dtmUltimaModificacion As Date, _
                                              ByVal strModificadoPor As String, _
                                              ByVal strConnectionString As String) As Integer


        ' Constantes locales
        Const strmThisMemberName As String = "intActualizarTblRutaTransportes"
        Dim strSQLStatement As StringBuilder
        Dim strRegistros As Array
        Dim intRowsAffected As Integer = 0
        Dim strRowsAffected As String() = Nothing

        Try

            strSQLStatement = New StringBuilder

            strSQLStatement.AppendFormat("EXECUTE spActualizarTblRutaTransportes {0}, '{1}', '{2}', {3}," & _
                                                                               "'{4}','{5}', '{6}', {7}", _
                                                        intRutaTransportesId, _
                                                        strRutaTransportesClave, _
                                                        intRutaTransportesTipoId, _
                                                        intDestinoId, _
                                                        intProveedorId, _
                                                        intTolerancia, _
                                                        dtmUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), _
                                                        strModificadoPor)

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

            For Each strRowsAffected In strRegistros
                intRowsAffected = CInt(strRowsAffected.GetValue(0))
            Next

            ' Regresamos la información
            strSQLStatement = Nothing
            intActualizarTblRutaTransportes = intRowsAffected

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
            Dim prueba As Integer = DirectCast(objException, System.Data.SqlClient.SqlException).Number

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

            ' Cuando se intenta insertar un registro repetido.
            If prueba = 2627 Then
                intActualizarTblRutaTransportes = -1
            End If

        End Try
    End Function

    Public Shared Function intEliminarTblRutaTransportes(ByVal intRutaTransportesId As Integer, ByVal strConnectionString As String) As Integer
        ' Constantes locales
        Const strmThisMemberName As String = "intEliminarTblRutaTransportes"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0
        Dim strRegistros As Array = Nothing
        Dim strRowsAffected As String() = Nothing

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spEliminarTblRutaTransportes ")
            Call strSQLStatement.Append(intRutaTransportesId)

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            For Each strRowsAffected In strRegistros
                intRowsAffected = CInt(strRowsAffected.GetValue(0))
            Next

            ' Regresamos la información
            strSQLStatement = Nothing
            intEliminarTblRutaTransportes = intRowsAffected

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
            intEliminarTblRutaTransportes = 0

            ' Notificamos el error
            Throw
        End Try
    End Function

    Public Shared Function intValidarTblRutaTransportes(ByVal intRutaTransportesId As Integer, ByVal strConnectionString As String) As Integer
        ' Constantes locales
        Const strmThisMemberName As String = "intValidarTblRutaTransportes"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0
        Dim strRegistros As Array = Nothing
        Dim strRowsAffected As String() = Nothing

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spValidarTblRutaTransportes ")
            Call strSQLStatement.Append(intRutaTransportesId)

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            For Each strRowsAffected In strRegistros
                intRowsAffected = CInt(strRowsAffected.GetValue(0))
            Next

            ' Regresamos la información
            strSQLStatement = Nothing
            intValidarTblRutaTransportes = intRowsAffected

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
            intValidarTblRutaTransportes = 0

            Throw
        End Try
    End Function

    Public Class clsRutaTransportesSucursal

        Public Shared Function strConsultarTblRutaTransportesSucursal(ByVal intRutaTransportesId As Integer, ByVal strConnectionString As String) As Array
            ' Member identifier
            Const strmThisMemberName As String = "strConsultarTblRutaTransportesSucursal"

            ' Declare the local variables
            Dim strSQLStatement As System.Text.StringBuilder
            Dim aobjReturnedData As Array

            Try

                ' Create the SQL statement
                strSQLStatement = New System.Text.StringBuilder

                strSQLStatement.AppendFormat("EXECUTE spConsultarTblRutaTransportesSucursal {0}", intRutaTransportesId)
                ' Execute the SQL statement
                aobjReturnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                strSQLStatement = Nothing

                ' Return the results
                Return aobjReturnedData

            Catch objException As Exception
                ' Declare the error variables
                Dim strErrorString As System.Text.StringBuilder = New System.Text.StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName

                ' Create the error message
                Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
                Call strErrorString.Append("Application name:" & vbCrLf & vbTab & System.Reflection.Assembly.GetExecutingAssembly.Location & vbCrLf & vbCrLf)
                Call strErrorString.Append("Version:" & vbCrLf & vbTab & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & vbCrLf & vbCrLf)
                Call strErrorString.Append("Source:" & vbCrLf & vbTab & objException.Source & vbCrLf & vbCrLf)
                Call strErrorString.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(Err.Number) & vbCrLf & vbCrLf)
                Call strErrorString.Append("Line number:" & vbCrLf & vbTab & Erl() & vbCrLf & vbCrLf)
                Call strErrorString.Append("Message:" & vbCrLf & vbTab & objException.Message & vbCrLf & vbCrLf)
                Call strErrorString.Append("SQLStatement:" & vbCrLf & vbTab & strSQLStatement.ToString() & vbCrLf & vbCrLf)
                Call strErrorString.Append("StackTrace:" & vbCrLf & objException.StackTrace & vbCrLf & vbCrLf)

                ' Create the event source
                If Not EventLog.SourceExists(strProductName) Then
                    Call EventLog.CreateEventSource(strProductName, "Application")
                End If

                ' Set the event source
                objApplicationEventLog.Source = strProductName

                ' Write the event. It can be read in the Event Viewer.
                Call objApplicationEventLog.WriteEntry(strErrorString.ToString(), EventLogEntryType.Error, Err.Number, 0)

                ' Clear the variables
                strSQLStatement = Nothing
                aobjReturnedData = Nothing

                ' Raise the error
                Throw
            End Try
        End Function

        Public Shared Function intGuardarTblRutaTransportesSucursal( _
                                              ByVal intRutaTransportesId As Integer, _
                                              ByVal strCentroLogisticoId As String, _
                                              ByVal strHoraEntrega As String, _
                                              ByVal dtmUltimaModificacion As Date, _
                                              ByVal strModificadoPor As String, _
                                              ByRef strRutaTransportesClaveOriginal As String, _
                                              ByRef intRutaTransportesSucursalIdResultado As Integer, _
                                              ByRef intRutaTransportesIdResultado As Integer, _
                                              ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intGuardarTblRutaTransportesSucursal"
            Dim strSQLStatement As StringBuilder
            Dim strRegistros As Array
            Dim intRowsAffected As Integer = 0
            Dim strRowsAffected As String() = Nothing

            Try

                strSQLStatement = New StringBuilder

                strSQLStatement.AppendFormat("EXECUTE spGuardarTblRutaTransportesSucursal {0}, '{1}', '{2}', '{3}'," & "'{4}'", _
                                                            intRutaTransportesId, _
                                                            strCentroLogisticoId, _
                                                            strHoraEntrega, _
                                                            dtmUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), _
                                                            strModificadoPor)


                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))

                    If Not strRowsAffected.GetValue(1) Is Nothing And Not strRowsAffected.GetValue(1).ToString = "" Then
                        strRutaTransportesClaveOriginal = CStr(strRowsAffected.GetValue(1))
                        intRutaTransportesSucursalIdResultado = CInt(strRowsAffected.GetValue(2))
                        intRutaTransportesIdResultado = CInt(strRowsAffected.GetValue(3))
                    End If
                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intGuardarTblRutaTransportesSucursal = intRowsAffected

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
                Dim intRegistroRepetido As Integer = DirectCast(objException, System.Data.SqlClient.SqlException).Number

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

                ' Cuando se intenta insertar un registro repetido.
                If intRegistroRepetido = 2627 Then
                    intGuardarTblRutaTransportesSucursal = -1
                End If
            End Try
        End Function

        Public Shared Function intActualizarTblRutaTransportesSucursal( _
                                              ByVal intRutaTransportesSucursalId As Integer, _
                                              ByVal strCentroLogisticoId As String, _
                                              ByVal strHoraEntrega As String, _
                                              ByVal intRutaTransportesIdOriginal As Integer, _
                                              ByRef strRutaTransportesClaveOriginal As String, _
                                              ByRef intRutaTransportesSucursalIdEliminar As Integer, _
                                              ByVal dtmUltimaModificacion As Date, _
                                              ByVal strModificadoPor As String, _
                                              ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intActualizarTblRutaTransportesSucursal"
            Dim strSQLStatement As StringBuilder
            Dim strRegistros As Array
            Dim intRowsAffected As Integer = 0
            Dim strRowsAffected As String() = Nothing

            Try

                strSQLStatement = New StringBuilder

                strSQLStatement.AppendFormat("EXECUTE spActualizarTblRutaTransportesSucursal {0}, '{1}', '{2}', {3}, '{4}', '{5}'", _
                                                            intRutaTransportesSucursalId, _
                                                            strCentroLogisticoId, _
                                                            strHoraEntrega, _
                                                            intRutaTransportesIdOriginal, _
                                                            dtmUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), _
                                                            strModificadoPor)

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))

                    If Not strRowsAffected.GetValue(1) Is Nothing And Not strRowsAffected.GetValue(1).ToString = "" Then
                        strRutaTransportesClaveOriginal = CStr(strRowsAffected.GetValue(1))
                        intRutaTransportesSucursalIdEliminar = CInt(strRowsAffected.GetValue(2))
                    End If

                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intActualizarTblRutaTransportesSucursal = intRowsAffected

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
                Dim intRegistroRepetido As Integer = DirectCast(objException, System.Data.SqlClient.SqlException).Number

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

                ' Cuando se intenta insertar un registro repetido.
                If intRegistroRepetido = 2627 Then
                    intActualizarTblRutaTransportesSucursal = -1
                End If
            End Try
        End Function

        Public Shared Function intEliminarTblRutaTransportesSucursal(ByVal intRutaTransportesSucursalId As Integer, ByVal strConnectionString As String) As Integer
            ' Constantes locales
            Const strmThisMemberName As String = "intEliminarTblRutaTransportes"

            ' Variables locales
            Dim strSQLStatement As StringBuilder = Nothing
            Dim intRowsAffected As Integer = 0
            Dim strRegistros As Array = Nothing
            Dim strRowsAffected As String() = Nothing

            Try

                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spEliminarTblRutaTransportesSucursal ")
                Call strSQLStatement.Append(intRutaTransportesSucursalId)

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intEliminarTblRutaTransportesSucursal = intRowsAffected

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
                intEliminarTblRutaTransportesSucursal = 0

                ' Notificamos el error
                Throw
            End Try
        End Function

        Public Shared Function intValidarExistenciaSucursalTblRutaTransportesSucursal(ByVal strCentroLogisticoId As String, _
                                                                                      ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intValidarExistenciaSucursalTblRutaTransportesSucursal"

            ' Variables locales
            Dim strSQLStatement As StringBuilder = Nothing
            Dim intRowsAffected As Integer = 0
            Dim strRegistros As Array = Nothing
            Dim strRowsAffected As String() = Nothing

            Try

                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos el estatuto de SQL
                Call strSQLStatement.AppendFormat("EXECUTE spValidarExistenciaSucursalTblRutaTransportesSucursal {0}", strCentroLogisticoId)

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intValidarExistenciaSucursalTblRutaTransportesSucursal = intRowsAffected

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
                intValidarExistenciaSucursalTblRutaTransportesSucursal = 0
            End Try

        End Function

        Public Shared Function intReasignarRutaASucursalAlGuardar( _
                                              ByVal intRutaTransportesSucursalId As Integer, _
                                              ByVal intRutaTransportesId As Integer, _
                                              ByVal strCentroLogisticoId As String, _
                                              ByVal strHoraEntrega As String, _
                                              ByVal dtmUltimaModificacion As Date, _
                                              ByVal strModificadoPor As String, _
                                              ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intReasignarRutaASucursalAlGuardar"
            Dim strSQLStatement As StringBuilder
            Dim strRegistros As Array
            Dim intRowsAffected As Integer = 0
            Dim strRowsAffected As String() = Nothing

            Try

                strSQLStatement = New StringBuilder

                strSQLStatement.AppendFormat("EXECUTE spReasignarRutaASucursalAlGuardar {0}, {1}, '{2}', " & "'{3}','{4}', '{5}'", _
                                                            intRutaTransportesSucursalId, _
                                                            intRutaTransportesId, _
                                                            strCentroLogisticoId, _
                                                            strHoraEntrega, _
                                                            dtmUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), _
                                                            strModificadoPor)

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intReasignarRutaASucursalAlGuardar = intRowsAffected

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
                Dim intRegistroRepetido As Integer = DirectCast(objException, System.Data.SqlClient.SqlException).Number

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
            End Try
        End Function

        Public Shared Function intReasignarRutaASucursalAlActualizar( _
                                              ByVal intRutaTransportesSucursalId As Integer, _
                                              ByVal intRutaTransportesId As Integer, _
                                              ByVal strCentroLogisticoId As String, _
                                              ByVal strHoraEntrega As String, _
                                              ByVal intRutaTransportesSucursalIdEliminar As Integer, _
                                              ByVal dtmUltimaModificacion As Date, _
                                              ByVal strModificadoPor As String, _
                                              ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intReasignarRutaASucursalAlActualizar"
            Dim strSQLStatement As StringBuilder
            Dim strRegistros As Array
            Dim intRowsAffected As Integer = 0
            Dim strRowsAffected As String() = Nothing

            Try
                strSQLStatement = New StringBuilder

                strSQLStatement.AppendFormat("EXECUTE spReasignarRutaASucursalAlActualizar {0}, '{1}', '{2}', '{3}'," & "{4}, '{5}', '{6}'", _
                                                      intRutaTransportesSucursalId, _
                                                      intRutaTransportesId, _
                                                      strCentroLogisticoId, _
                                                      strHoraEntrega, _
                                                      intRutaTransportesSucursalIdEliminar, _
                                                      dtmUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), _
                                                      strModificadoPor)

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intReasignarRutaASucursalAlActualizar = intRowsAffected

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
                Dim intRegistroRepetido As Integer = DirectCast(objException, System.Data.SqlClient.SqlException).Number

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

                ' Cuando se intenta insertar un registro repetido.
                If intRegistroRepetido = 2627 Then
                    intReasignarRutaASucursalAlActualizar = -1
                End If
            End Try
        End Function

    End Class

    Public Class clsRutaTransportesFrecuencia

        Public Shared Function strConsultarTblRutaTransportesFrecuencia(ByVal intRutaTransportesId As Integer, ByVal strConnectionString As String) As Array
            ' Member identifier
            Const strmThisMemberName As String = "strConsultarTblRutaTransportesFrecuencia"

            ' Declare the local variables
            Dim strSQLStatement As System.Text.StringBuilder
            Dim aobjReturnedData As Array

            Try

                ' Create the SQL statement
                strSQLStatement = New System.Text.StringBuilder

                strSQLStatement.AppendFormat("EXECUTE spConsultarTblRutaTransportesFrecuencia {0}", intRutaTransportesId)
                ' Execute the SQL statement
                aobjReturnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                strSQLStatement = Nothing

                ' Return the results
                Return aobjReturnedData

            Catch objException As Exception
                ' Declare the error variables
                Dim strErrorString As System.Text.StringBuilder = New System.Text.StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName

                ' Create the error message
                Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
                Call strErrorString.Append("Application name:" & vbCrLf & vbTab & System.Reflection.Assembly.GetExecutingAssembly.Location & vbCrLf & vbCrLf)
                Call strErrorString.Append("Version:" & vbCrLf & vbTab & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & vbCrLf & vbCrLf)
                Call strErrorString.Append("Source:" & vbCrLf & vbTab & objException.Source & vbCrLf & vbCrLf)
                Call strErrorString.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(Err.Number) & vbCrLf & vbCrLf)
                Call strErrorString.Append("Line number:" & vbCrLf & vbTab & Erl() & vbCrLf & vbCrLf)
                Call strErrorString.Append("Message:" & vbCrLf & vbTab & objException.Message & vbCrLf & vbCrLf)
                Call strErrorString.Append("SQLStatement:" & vbCrLf & vbTab & strSQLStatement.ToString() & vbCrLf & vbCrLf)
                Call strErrorString.Append("StackTrace:" & vbCrLf & objException.StackTrace & vbCrLf & vbCrLf)

                ' Create the event source
                If Not EventLog.SourceExists(strProductName) Then
                    Call EventLog.CreateEventSource(strProductName, "Application")
                End If

                ' Set the event source
                objApplicationEventLog.Source = strProductName

                ' Write the event. It can be read in the Event Viewer.
                Call objApplicationEventLog.WriteEntry(strErrorString.ToString(), EventLogEntryType.Error, Err.Number, 0)

                ' Clear the variables
                strSQLStatement = Nothing
                aobjReturnedData = Nothing

                ' Raise the error
                Throw
            End Try
        End Function

        Public Shared Function intGuardarTblRutaTransportesFrecuencia( _
                                      ByVal intRutaTransportesId As Integer, _
                                      ByVal intFrecuencia As Integer, _
                                      ByVal strRutaTransportesDiaSurtido As String, _
                                      ByVal strRutaTransportesDiaEntrega As String, _
                                      ByVal dtmUltimaModificacion As Date, _
                                      ByVal strModificadoPor As String, _
                                      ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intGuardarTblRutaTransportesFrecuencia"
            Dim strSQLStatement As StringBuilder
            Dim strRegistros As Array
            Dim intRowsAffected As Integer = 0
            Dim strRowsAffected As String() = Nothing

            Try

                strSQLStatement = New StringBuilder

                strSQLStatement.AppendFormat("EXECUTE spGuardarTblRutaTransportesFrecuencia {0}, {1}, '{2}'," & "'{3}', '{4}', {5}", _
                                                            intRutaTransportesId, _
                                                            intFrecuencia, _
                                                            strRutaTransportesDiaSurtido, _
                                                            strRutaTransportesDiaEntrega, _
                                                            dtmUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), _
                                                            strModificadoPor)

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intGuardarTblRutaTransportesFrecuencia = intRowsAffected

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
                Dim intRegistroRepetido As Integer = DirectCast(objException, System.Data.SqlClient.SqlException).Number

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

                ' Cuando se intenta insertar un registro repetido.
                If intRegistroRepetido = 2627 Then
                    intGuardarTblRutaTransportesFrecuencia = -1
                End If
            End Try
        End Function

        Public Shared Function intActualizarTblRutaTransportesFrecuencia( _
                                              ByVal intRutaTransportesFrecuenciaId As Integer, _
                                              ByVal intRutaTransportesId As Integer, _
                                              ByVal intFrecuencia As Integer, _
                                              ByVal strRutaTransportesDiaSurtido As String, _
                                              ByVal strRutaTransportesDiaEntrega As String, _
                                              ByVal dtmUltimaModificacion As Date, _
                                              ByVal strModificadoPor As String, _
                                              ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intActualizarTblRutaTransportesFrecuencia"
            Dim strSQLStatement As StringBuilder
            Dim strRegistros As Array
            Dim intRowsAffected As Integer = 0
            Dim strRowsAffected As String() = Nothing

            Try

                strSQLStatement = New StringBuilder

                strSQLStatement.AppendFormat("EXECUTE spActualizarTblRutaTransportesFrecuencia {0}, {1}, {2}, '{3}', '{4}', '{5}', '{6}'", _
                                                            intRutaTransportesFrecuenciaId, _
                                                            intRutaTransportesId, _
                                                            intFrecuencia, _
                                                            strRutaTransportesDiaSurtido, _
                                                            strRutaTransportesDiaEntrega, _
                                                            dtmUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), _
                                                            strModificadoPor)


                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intActualizarTblRutaTransportesFrecuencia = intRowsAffected

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
                Dim intRegistroRepetido As Integer = DirectCast(objException, System.Data.SqlClient.SqlException).Number

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

                ' Cuando se intenta insertar un registro repetido.
                If intRegistroRepetido = 2627 Then
                    intActualizarTblRutaTransportesFrecuencia = -1
                End If
            End Try
        End Function

        Public Shared Function intEliminarTblRutaTransportesFrecuencia(ByVal intRutaTransportesFrecuenciaId As Integer, ByVal strConnectionString As String) As Integer
            ' Constantes locales
            Const strmThisMemberName As String = "intEliminarTblRutaTransportes"

            ' Variables locales
            Dim strSQLStatement As StringBuilder = Nothing
            Dim intRowsAffected As Integer = 0
            Dim strRegistros As Array = Nothing
            Dim strRowsAffected As String() = Nothing

            Try

                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spEliminarTblRutaTransportesFrecuencia ")
                Call strSQLStatement.Append(intRutaTransportesFrecuenciaId)

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intEliminarTblRutaTransportesFrecuencia = intRowsAffected

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
                intEliminarTblRutaTransportesFrecuencia = 0

                ' Notificamos el error
                Throw
            End Try
        End Function

    End Class

    Public Class clsRutaTransportesDestino

        Public Shared Function strConsultarTblRutaTransportesDestino(ByVal strConnectionString As String) As Array
            ' Member identifier
            Const strmThisMemberName As String = "strConsultarTblRutaTransportesDestino"

            ' Declare the local variables
            Dim strSQLStatement As System.Text.StringBuilder
            Dim aobjReturnedData As Array

            Try

                ' Create the SQL statement
                strSQLStatement = New System.Text.StringBuilder

                strSQLStatement.Append("EXECUTE spConsultarTblRutaTransportesDestino ")
                ' Execute the SQL statement
                aobjReturnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                strSQLStatement = Nothing

                ' Return the results
                Return aobjReturnedData

            Catch objException As Exception
                ' Declare the error variables
                Dim strErrorString As System.Text.StringBuilder = New System.Text.StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName

                ' Create the error message
                Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
                Call strErrorString.Append("Application name:" & vbCrLf & vbTab & System.Reflection.Assembly.GetExecutingAssembly.Location & vbCrLf & vbCrLf)
                Call strErrorString.Append("Version:" & vbCrLf & vbTab & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & vbCrLf & vbCrLf)
                Call strErrorString.Append("Source:" & vbCrLf & vbTab & objException.Source & vbCrLf & vbCrLf)
                Call strErrorString.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(Err.Number) & vbCrLf & vbCrLf)
                Call strErrorString.Append("Line number:" & vbCrLf & vbTab & Erl() & vbCrLf & vbCrLf)
                Call strErrorString.Append("Message:" & vbCrLf & vbTab & objException.Message & vbCrLf & vbCrLf)
                Call strErrorString.Append("SQLStatement:" & vbCrLf & vbTab & strSQLStatement.ToString() & vbCrLf & vbCrLf)
                Call strErrorString.Append("StackTrace:" & vbCrLf & objException.StackTrace & vbCrLf & vbCrLf)

                ' Create the event source
                If Not EventLog.SourceExists(strProductName) Then
                    Call EventLog.CreateEventSource(strProductName, "Application")
                End If

                ' Set the event source
                objApplicationEventLog.Source = strProductName

                ' Write the event. It can be read in the Event Viewer.
                Call objApplicationEventLog.WriteEntry(strErrorString.ToString(), EventLogEntryType.Error, Err.Number, 0)

                ' Clear the variables
                strSQLStatement = Nothing
                aobjReturnedData = Nothing

                ' Raise the error
                Throw
            End Try
        End Function

    End Class

    Public Class clsRutaTransportesProveedor

        Public Shared Function strConsultarTblRutaTransportesProveedor(ByVal strConnectionString As String) As Array
            ' Member identifier
            Const strmThisMemberName As String = "strConsultarTblRutaTransportesProveedor"

            ' Declare the local variables
            Dim strSQLStatement As System.Text.StringBuilder
            Dim aobjReturnedData As Array

            Try

                ' Create the SQL statement
                strSQLStatement = New System.Text.StringBuilder

                strSQLStatement.Append("EXECUTE spConsultarTblRutaTransportesProveedor ")
                ' Execute the SQL statement
                aobjReturnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                strSQLStatement = Nothing

                ' Return the results
                Return aobjReturnedData

            Catch objException As Exception
                ' Declare the error variables
                Dim strErrorString As System.Text.StringBuilder = New System.Text.StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName

                ' Create the error message
                Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
                Call strErrorString.Append("Application name:" & vbCrLf & vbTab & System.Reflection.Assembly.GetExecutingAssembly.Location & vbCrLf & vbCrLf)
                Call strErrorString.Append("Version:" & vbCrLf & vbTab & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & vbCrLf & vbCrLf)
                Call strErrorString.Append("Source:" & vbCrLf & vbTab & objException.Source & vbCrLf & vbCrLf)
                Call strErrorString.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(Err.Number) & vbCrLf & vbCrLf)
                Call strErrorString.Append("Line number:" & vbCrLf & vbTab & Erl() & vbCrLf & vbCrLf)
                Call strErrorString.Append("Message:" & vbCrLf & vbTab & objException.Message & vbCrLf & vbCrLf)
                Call strErrorString.Append("SQLStatement:" & vbCrLf & vbTab & strSQLStatement.ToString() & vbCrLf & vbCrLf)
                Call strErrorString.Append("StackTrace:" & vbCrLf & objException.StackTrace & vbCrLf & vbCrLf)

                ' Create the event source
                If Not EventLog.SourceExists(strProductName) Then
                    Call EventLog.CreateEventSource(strProductName, "Application")
                End If

                ' Set the event source
                objApplicationEventLog.Source = strProductName

                ' Write the event. It can be read in the Event Viewer.
                Call objApplicationEventLog.WriteEntry(strErrorString.ToString(), EventLogEntryType.Error, Err.Number, 0)

                ' Clear the variables
                strSQLStatement = Nothing
                aobjReturnedData = Nothing

                ' Raise the error
                Throw
            End Try
        End Function

    End Class

    Public Class clsRutaTransportesSucursalCalendario

        Public Shared Function strConsultarTblRutaTransportesSucursalCalendario(ByVal strCentroLogisticoId As String, _
                                                                                ByVal dtmFechaEntregaProgramada As Date, _
                                                                                ByVal strConnectionString As String) As Array

            ' Member identifier
            Const strmThisMemberName As String = "strConsultarTblRutaTransportesSucursalCalendario"

            ' Declare the local variables
            Dim strSQLStatement As System.Text.StringBuilder
            Dim aobjReturnedData As Array

            Try

                ' Create the SQL statement
                strSQLStatement = New System.Text.StringBuilder

                strSQLStatement.AppendFormat("EXECUTE spConsultarTblRutaTransportesSucursalCalendario '{0}', '{1}'", strCentroLogisticoId, dtmFechaEntregaProgramada.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))

                ' Execute the SQL statement
                aobjReturnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                strSQLStatement = Nothing

                ' Return the results
                Return aobjReturnedData

            Catch objException As Exception
                ' Declare the error variables
                Dim strErrorString As System.Text.StringBuilder = New System.Text.StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName

                ' Create the error message
                Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
                Call strErrorString.Append("Application name:" & vbCrLf & vbTab & System.Reflection.Assembly.GetExecutingAssembly.Location & vbCrLf & vbCrLf)
                Call strErrorString.Append("Version:" & vbCrLf & vbTab & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & vbCrLf & vbCrLf)
                Call strErrorString.Append("Source:" & vbCrLf & vbTab & objException.Source & vbCrLf & vbCrLf)
                Call strErrorString.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(Err.Number) & vbCrLf & vbCrLf)
                Call strErrorString.Append("Line number:" & vbCrLf & vbTab & Erl() & vbCrLf & vbCrLf)
                Call strErrorString.Append("Message:" & vbCrLf & vbTab & objException.Message & vbCrLf & vbCrLf)
                Call strErrorString.Append("SQLStatement:" & vbCrLf & vbTab & strSQLStatement.ToString() & vbCrLf & vbCrLf)
                Call strErrorString.Append("StackTrace:" & vbCrLf & objException.StackTrace & vbCrLf & vbCrLf)

                ' Create the event source
                If Not EventLog.SourceExists(strProductName) Then
                    Call EventLog.CreateEventSource(strProductName, "Application")
                End If

                ' Set the event source
                objApplicationEventLog.Source = strProductName

                ' Write the event. It can be read in the Event Viewer.
                Call objApplicationEventLog.WriteEntry(strErrorString.ToString(), EventLogEntryType.Error, Err.Number, 0)

                ' Clear the variables
                strSQLStatement = Nothing
                aobjReturnedData = Nothing

                ' Raise the error
                Throw
            End Try
        End Function

        Public Shared Function intConfirmarTblRutaTransportesSucursalCalendario(ByVal intCalendarioId As Integer, _
                                                                                 ByVal dtmFechaHoraEntregaReal As Date, _
                                                                                 ByVal intMotivoRetrasoId As Integer, _
                                                                                 ByVal dtmUltimaModificacion As Date, _
                                                                                 ByVal strModificadoPor As String, _
                                                                                 ByVal strConnectionString As String) As Integer
            ' Constantes locales
            Const strmThisMemberName As String = "intConfirmarTblRutaTransportesSucursalCalendario"
            Dim strSQLStatement As StringBuilder
            Dim strRegistros As Array
            Dim intRowsAffected As Integer = 0
            Dim strRowsAffected As String() = Nothing

            Try

                strSQLStatement = New StringBuilder

                strSQLStatement.AppendFormat("EXECUTE spConfirmarTblRutaTransportesSucursalCalendario {0}, '{1}', {2}," & "'{3}', {4}", _
                                                            intCalendarioId, _
                                                            dtmFechaHoraEntregaReal.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), _
                                                            intMotivoRetrasoId, _
                                                            dtmUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), _
                                                            strModificadoPor)

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intConfirmarTblRutaTransportesSucursalCalendario = intRowsAffected

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
                Dim intRegistroRepetido As Integer = DirectCast(objException, System.Data.SqlClient.SqlException).Number

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
            End Try
        End Function

        Public Shared Function strConsultarTblRutaTransportesSucursalCalendarioReporte(ByVal strRutaTransportesClave As String, _
                                                                                       ByVal intRutaTransportesTipoId As Integer, _
                                                                                       ByVal intDestinoId As Integer, _
                                                                                       ByVal intProveedorId As Integer, _
                                                                                       ByVal strCentroLogisticoId As String, _
                                                                                       ByVal dtmFechaHoraEntregaProgramadaInicio As Date, _
                                                                                       ByVal dtmFechaHoraEntregaProgramadaFin As Date, _
                                                                                       ByVal intEntregaConfirmada As Integer, _
                                                                                       ByVal intMotivoRetrasoId As Integer, _
                                                                                       ByVal strConnectionString As String) As Array
            ' Member identifier
            Const strmThisMemberName As String = "strConsultarTblRutaTransportesSucursalCalendarioReporte"

            ' Declare the local variables
            Dim strSQLStatement As System.Text.StringBuilder
            Dim aobjReturnedData As Array


            Try

                ' Create the SQL statement
                strSQLStatement = New System.Text.StringBuilder

                strSQLStatement.AppendFormat("EXECUTE spConsultarReporteCalendario '{0}', {1}, {2}, {3}, '{4}', '{5}', '{6}', {7}, {8}", _
                                                                                        strRutaTransportesClave, _
                                                                                        intRutaTransportesTipoId, _
                                                                                        intDestinoId, _
                                                                                        intProveedorId, _
                                                                                        strCentroLogisticoId, _
                                                                                        dtmFechaHoraEntregaProgramadaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), _
                                                                                        dtmFechaHoraEntregaProgramadaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), _
                                                                                        intEntregaConfirmada, _
                                                                                        intMotivoRetrasoId)



                ' Execute the SQL statement
                aobjReturnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                strSQLStatement = Nothing

                ' Return the results
                Return aobjReturnedData

            Catch objException As Exception
                ' Declare the error variables
                Dim strErrorString As System.Text.StringBuilder = New System.Text.StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName

                ' Create the error message
                Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
                Call strErrorString.Append("Application name:" & vbCrLf & vbTab & System.Reflection.Assembly.GetExecutingAssembly.Location & vbCrLf & vbCrLf)
                Call strErrorString.Append("Version:" & vbCrLf & vbTab & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & vbCrLf & vbCrLf)
                Call strErrorString.Append("Source:" & vbCrLf & vbTab & objException.Source & vbCrLf & vbCrLf)
                Call strErrorString.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(Err.Number) & vbCrLf & vbCrLf)
                Call strErrorString.Append("Line number:" & vbCrLf & vbTab & Erl() & vbCrLf & vbCrLf)
                Call strErrorString.Append("Message:" & vbCrLf & vbTab & objException.Message & vbCrLf & vbCrLf)
                Call strErrorString.Append("SQLStatement:" & vbCrLf & vbTab & strSQLStatement.ToString() & vbCrLf & vbCrLf)
                Call strErrorString.Append("StackTrace:" & vbCrLf & objException.StackTrace & vbCrLf & vbCrLf)

                ' Create the event source
                If Not EventLog.SourceExists(strProductName) Then
                    Call EventLog.CreateEventSource(strProductName, "Application")
                End If

                ' Set the event source
                objApplicationEventLog.Source = strProductName

                ' Write the event. It can be read in the Event Viewer.
                Call objApplicationEventLog.WriteEntry(strErrorString.ToString(), EventLogEntryType.Error, Err.Number, 0)

                ' Clear the variables
                strSQLStatement = Nothing
                aobjReturnedData = Nothing

                ' Raise the error
                Throw
            End Try

        End Function


        Public Shared Function strBuscarSucursalSinConfirmacion(ByVal strCentroLogisticoId As String, ByVal strConnectionString As String) As Array
            ' Member identifier

            Const strmThisMemberName As String = "strBuscarSucursalSinConfirmacion"

            ' Declare the local variables
            Dim strSQLStatement As System.Text.StringBuilder
            Dim aobjReturnedData As Array


            Try

                ' Create the SQL statement
                strSQLStatement = New System.Text.StringBuilder

                strSQLStatement.AppendFormat("EXECUTE spConsultarCalendarioPorSucursalSinConfirmacion '{0}' ", strCentroLogisticoId)

                ' Execute the SQL statement
                aobjReturnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                strSQLStatement = Nothing

                ' Return the results
                Return aobjReturnedData

            Catch objException As Exception
                ' Declare the error variables
                Dim strErrorString As System.Text.StringBuilder = New System.Text.StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName

                ' Create the error message
                Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
                Call strErrorString.Append("Application name:" & vbCrLf & vbTab & System.Reflection.Assembly.GetExecutingAssembly.Location & vbCrLf & vbCrLf)
                Call strErrorString.Append("Version:" & vbCrLf & vbTab & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & vbCrLf & vbCrLf)
                Call strErrorString.Append("Source:" & vbCrLf & vbTab & objException.Source & vbCrLf & vbCrLf)
                Call strErrorString.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(Err.Number) & vbCrLf & vbCrLf)
                Call strErrorString.Append("Line number:" & vbCrLf & vbTab & Erl() & vbCrLf & vbCrLf)
                Call strErrorString.Append("Message:" & vbCrLf & vbTab & objException.Message & vbCrLf & vbCrLf)
                Call strErrorString.Append("SQLStatement:" & vbCrLf & vbTab & strSQLStatement.ToString() & vbCrLf & vbCrLf)
                Call strErrorString.Append("StackTrace:" & vbCrLf & objException.StackTrace & vbCrLf & vbCrLf)

                ' Create the event source
                If Not EventLog.SourceExists(strProductName) Then
                    Call EventLog.CreateEventSource(strProductName, "Application")
                End If

                ' Set the event source
                objApplicationEventLog.Source = strProductName

                ' Write the event. It can be read in the Event Viewer.
                Call objApplicationEventLog.WriteEntry(strErrorString.ToString(), EventLogEntryType.Error, Err.Number, 0)

                ' Clear the variables
                strSQLStatement = Nothing
                aobjReturnedData = Nothing

                ' Raise the error
                Throw
            End Try

        End Function

        Public Shared Function strBuscarSucursalVisitaVencida(ByVal strCentroLogisticoId As String, ByVal strConnectionString As String) As Array
            ' Member identifier

            Const strmThisMemberName As String = "strBuscarSucursalVisitaVencida"

            ' Declare the local variables
            Dim strSQLStatement As System.Text.StringBuilder
            Dim aobjReturnedData As Array


            Try

                ' Create the SQL statement
                strSQLStatement = New System.Text.StringBuilder

                strSQLStatement.AppendFormat("EXECUTE spBuscarRutaTransportesCalendarioSucursalVisitaVencida '{0}' ", strCentroLogisticoId)

                ' Execute the SQL statement
                aobjReturnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                strSQLStatement = Nothing

                ' Return the results
                Return aobjReturnedData

            Catch objException As Exception
                ' Declare the error variables
                Dim strErrorString As System.Text.StringBuilder = New System.Text.StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName

                ' Create the error message
                Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
                Call strErrorString.Append("Application name:" & vbCrLf & vbTab & System.Reflection.Assembly.GetExecutingAssembly.Location & vbCrLf & vbCrLf)
                Call strErrorString.Append("Version:" & vbCrLf & vbTab & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & vbCrLf & vbCrLf)
                Call strErrorString.Append("Source:" & vbCrLf & vbTab & objException.Source & vbCrLf & vbCrLf)
                Call strErrorString.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(Err.Number) & vbCrLf & vbCrLf)
                Call strErrorString.Append("Line number:" & vbCrLf & vbTab & Erl() & vbCrLf & vbCrLf)
                Call strErrorString.Append("Message:" & vbCrLf & vbTab & objException.Message & vbCrLf & vbCrLf)
                Call strErrorString.Append("SQLStatement:" & vbCrLf & vbTab & strSQLStatement.ToString() & vbCrLf & vbCrLf)
                Call strErrorString.Append("StackTrace:" & vbCrLf & objException.StackTrace & vbCrLf & vbCrLf)

                ' Create the event source
                If Not EventLog.SourceExists(strProductName) Then
                    Call EventLog.CreateEventSource(strProductName, "Application")
                End If

                ' Set the event source
                objApplicationEventLog.Source = strProductName

                ' Write the event. It can be read in the Event Viewer.
                Call objApplicationEventLog.WriteEntry(strErrorString.ToString(), EventLogEntryType.Error, Err.Number, 0)

                ' Clear the variables
                strSQLStatement = Nothing
                aobjReturnedData = Nothing

                ' Raise the error
                Throw
            End Try

        End Function

    End Class


    Public Class clsRutaTransportesMotivoRetraso

        Public Shared Function strConsultarTblRutaTransportesMotivoRetraso(ByVal strConnectionString As String) As Array
            ' Constantes locales
            Const strmThisMemberName As String = "strConsultarTblRutaTransportesMotivoRetraso"
            Dim strSQLStatement As StringBuilder
            Dim strRegistros As Array

            Try

                strSQLStatement = New StringBuilder

                strSQLStatement.AppendFormat("EXECUTE spConsultarTblRutaTransportesMotivoRetraso")

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                strSQLStatement = Nothing

                Return strRegistros

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
                Dim intRegistroRepetido As Integer = DirectCast(objException, System.Data.SqlClient.SqlException).Number

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
                strRegistros = Nothing
                ' Escribimos el evento en el Visor de Eventos
                Call objApplicationEventLog.WriteEntry(strErrorString.ToString(), EventLogEntryType.Error, Err.Number, intCategoryNumber)
                Throw
            End Try
        End Function


    End Class

End Class
