﻿Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clsClientesABF
' Title         : Grupo Benavides. 
' Description   : Mantenimiento de Tablas.
' Copyright     : 
' Company       : 
' Author        : Deintec
' Version       : 1.0
' Last Modified : Viernes, 03 de Marzo de 2017
'====================================================================
Public Class clsClientesABF

    Public Class clsClienteRecetaEnLineaABF

        Private Const strmThisClassName As String = "Benavides.CC.Data.clsClientesABF.clsClienteRecetaEnLineaABF"

        Public Shared Function strBuscarTblClienteRecetaEnLineaABF(ByVal strClienteABF As String, _
                                                                   ByVal intTipoFiltroSucursales As Integer, _
                                                                   ByVal strConnectionString As String) As Array

            ' Member identifier
            Const strmThisMemberName As String = "strBuscarTblClienteRecetaEnLineaABF"

            ' Declare the local variables
            Dim strSQLStatement As StringBuilder
            Dim aobjReturnedData As Array

            Try

                ' Create the SQL statement
                strSQLStatement = New StringBuilder

                strSQLStatement.AppendFormat("EXECUTE spBuscarTblClienteRecetaEnLineaABF '{0}', {1}", _
                                                                                                    strClienteABF, _
                                                                                                    intTipoFiltroSucursales)

                ' Execute the SQL statement
                aobjReturnedData = clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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

        Public Shared Function strBuscarTblClienteRecetaEnLineaSucursalPorClienteId(ByVal strClienteABFId As String, _
                                                                                    ByVal strConnectionString As String) As Array
            ' Member identifier
            Const strmThisMemberName As String = "strBuscarTblClienteRecetaEnLineaSucursalPorClienteId"

            ' Declare the local variables
            Dim strSQLStatement As StringBuilder
            Dim aobjReturnedData As Array

            Try

                ' Create the SQL statement
                strSQLStatement = New StringBuilder

                strSQLStatement.AppendFormat("EXECUTE spBuscarTblClienteRecetaEnLineaSucursalPorClienteId '{0}'", strClienteABFId)

                ' Execute the SQL statement
                aobjReturnedData = clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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

        Public Shared Function intEliminarTblClienteRecetaEnLineaSucursal(ByVal strClienteABFId As String, _
                                                                          ByVal intCompaniaId As Integer, _
                                                                          ByVal intSucursalId As Integer, _
                                                                          ByVal strConnectionString As String) As Integer
            ' Constantes locales
            Const strmThisMemberName As String = "intEliminarTblClienteRecetaEnLineaSucursal"

            ' Variables locales
            Dim strSQLStatement As StringBuilder = Nothing
            Dim intRowsAffected As Integer = 0
            Dim strRegistros As Array = Nothing
            Dim strRowsAffected As String() = Nothing

            Try

                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement. _
                    AppendFormat("EXECUTE spEliminarTblClienteRecetaEnLineaSucursal '{0}', {1}, {2} ", strClienteABFId, _
                                                                                                       intCompaniaId, _
                                                                                                       intSucursalId)

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intEliminarTblClienteRecetaEnLineaSucursal = intRowsAffected

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
                intEliminarTblClienteRecetaEnLineaSucursal = 0

                ' Notificamos el error
                Throw
            End Try
        End Function

        Public Shared Function intGuardarTblClienteRecetaEnLineaSucursal(ByVal strCadenaId As String, _
                                                                         ByVal intEstadoId As Integer, _
                                                                         ByVal intCiudadId As Integer, _
                                                                         ByVal intCompaniaId As Integer, _
                                                                         ByVal intSucursalId As Integer, _
                                                                         ByVal strClienteABFId As String, _
                                                                         ByVal strClienteRecetaEnLineaSucursalModificadoPor As String, _
                                                                         ByVal strConnectionString As String) As Integer
            ' Member identifier
            Const strmThisMemberName As String = "intGuardarTblClienteRecetaEnLineaSucursal"

            ' Declare the local variables
            Dim strSQLStatement As StringBuilder
            Dim intRecordId As Integer
            Dim aobjReturnedData As Array

            strSQLStatement = New StringBuilder

            Try
                Call strSQLStatement.AppendFormat("EXECUTE spAgregarTblClienteRecetaEnLineaSucursal " & _
                                                  "'{0}', {1}, {2}, {3}," & _
                                                  " {4}, '{5}',{6}", strCadenaId, _
                                                                     intEstadoId, _
                                                                     intCiudadId, _
                                                                     intCompaniaId, _
                                                                     intSucursalId, _
                                                                     strClienteABFId, _
                                                                     strClienteRecetaEnLineaSucursalModificadoPor)

                ' Execute the SQL statement
                aobjReturnedData = clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                strSQLStatement = Nothing

                ' Return the results
                If IsNothing(aobjReturnedData) = False AndAlso aobjReturnedData.Length > 0 Then
                    intRecordId = CInt(DirectCast(aobjReturnedData.GetValue(0), SortedList).GetByIndex(0))
                End If
                aobjReturnedData = Nothing
                Return intRecordId

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

        Public Shared Function intCopiarClienteSucursalesAsignadas(ByVal intCompaniaOrigenId As Integer, _
                                                                   ByVal intSucursalOrigenId As Integer, _
                                                                   ByVal intCompaniaDestinoId As Integer, _
                                                                   ByVal intSucursalDestinoId As Integer, _
                                                                   ByVal strOtrasIdentificacionesSucursalModificadoPor As String, _
                                                                   ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intCopiarClienteSucursalesAsignadas"

            ' Variables locales
            Dim strSQLStatement As StringBuilder = Nothing
            Dim intRowsAffected As Integer = 0
            Dim strRegistros As Array = Nothing
            Dim strRowsAffected As String() = Nothing

            Try

                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.AppendFormat("EXECUTE spCopiarClienteRecetaEnLineaSucursalesAsignadas {0}, {1}, {2}, {3}, '{4}'", _
                                                                                                                    intCompaniaOrigenId, _
                                                                                                                    intSucursalOrigenId, _
                                                                                                                    intCompaniaDestinoId, _
                                                                                                                    intSucursalDestinoId, _
                                                                                                                    strOtrasIdentificacionesSucursalModificadoPor)

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intCopiarClienteSucursalesAsignadas = intRowsAffected

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
                intCopiarClienteSucursalesAsignadas = 0

                ' Notificamos el error
                Throw
            End Try
        End Function

        Public Shared Function strBuscarTblClienteRecetaEnLineaSucursalPorCompaniaSucursal(ByVal intCompaniaId As Integer, _
                                                                                           ByVal intSucursalId As Integer, _
                                                                                           ByVal strConnectionString As String) As Array

            ' Member identifier
            Const strmThisMemberName As String = "strBuscarTblClienteRecetaEnLineaSucursalPorCompaniaSucursal"

            ' Declare the local variables
            Dim strSQLStatement As System.Text.StringBuilder
            Dim aobjReturnedData As Array

            Try

                ' Create the SQL statement
                strSQLStatement = New System.Text.StringBuilder

                Call strSQLStatement. _
                    AppendFormat("EXECUTE spBuscarTblClienteRecetaEnLineaSucursalPorCompaniaSucursal {0}, {1}", intCompaniaId, _
                                                                                                                intSucursalId)

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

    Public Class clsOtrasIdentificacionesABF

        Private Const strmThisClassName As String = "Benavides.CC.Data.clsClientesABF.clsOtrasIdentificacionesABF"

        Public Shared Function strBuscarTblOtrasIdentificacionesABF(ByVal strClienteABF As String, _
                                                                    ByVal intTipoFiltroSucursales As Integer, _
                                                                    ByVal strConnectionString As String) As Array

            ' Member identifier
            Const strmThisMemberName As String = "strBuscarTblOtrasIdentificacionesABF"

            ' Declare the local variables
            Dim strSQLStatement As StringBuilder
            Dim aobjReturnedData As Array

            Try

                ' Create the SQL statement
                strSQLStatement = New StringBuilder

                strSQLStatement.AppendFormat("EXECUTE spBuscarTblOtrasIdentificacionesABF '{0}', {1}", _
                                                                                                    strClienteABF, _
                                                                                                    intTipoFiltroSucursales)

                ' Execute the SQL statement
                aobjReturnedData = clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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

        Public Shared Function intGuardarTblOtrasIdentificacionesABF(ByVal objOtrasIdentificacionesABF As tblOtrasIdentificacionesABF, _
                                                                     ByVal strConnectionString As String) As Integer
            ' Member identifier
            Const strmThisMemberName As String = "intGuardarTblOtrasIdentificacionesABF"

            ' Declare the local variables
            Dim strSQLStatement As StringBuilder
            Dim intRecordId As Integer
            Dim aobjReturnedData As Array

            strSQLStatement = New StringBuilder

            Try
            
                Call strSQLStatement.AppendFormat("EXECUTE spAgregarTblOtrasIdentificacionesABF " & _
                                                  "'{0}', '{1}', '{2}', '{3}', " & _
                                                  "'{4}', '{5}', '{6}', '{7}', " & _
                                                  "'{8}', '{9}', '{10}', '{11}'," & _
                                                  "{12},   {13}, '{14}', '{15}'," & _
                                                  "{16},  '{17}', '{18}', '{19}'," & _
                                                  "'{20}', '{21}', '{22}', '{23}'," & _
                                                  "'{24}', '{25}'", _
                                                  objOtrasIdentificacionesABF.strClienteABFId, _
                                                  objOtrasIdentificacionesABF.strClienteABFNombre, _
                                                  objOtrasIdentificacionesABF.strMensajePOS, _
                                                  objOtrasIdentificacionesABF.strCredencialUnica, _
                                                  objOtrasIdentificacionesABF.strLlaveOnline, _
                                                  objOtrasIdentificacionesABF.blnConsHostExterno, _
                                                  objOtrasIdentificacionesABF.strCodigoStatus, _
                                                  objOtrasIdentificacionesABF.strCodigoConfirmaVenta, _
                                                  objOtrasIdentificacionesABF.strCodigoReversaVenta, _
                                                  objOtrasIdentificacionesABF.strTieneDVPHJ, _
                                                  objOtrasIdentificacionesABF.strAdjudicaSinStatus, _
                                                  objOtrasIdentificacionesABF.strMensajeSinStatus, _
                                                  objOtrasIdentificacionesABF.fltBonificacionSinStatus, _
                                                  objOtrasIdentificacionesABF.fltCreditoSinStatus, _
                                                  objOtrasIdentificacionesABF.strUsaOrdenDeCompra, _
                                                  objOtrasIdentificacionesABF.strValidaLimiteOC, _
                                                  objOtrasIdentificacionesABF.intLimiteOC, _
                                                  objOtrasIdentificacionesABF.strClavePadecimiento, _
                                                  objOtrasIdentificacionesABF.strClaveFamiliar, _
                                                  objOtrasIdentificacionesABF.strClaveUnica, _
                                                  objOtrasIdentificacionesABF.strClaveAutorizacion, _
                                                  objOtrasIdentificacionesABF.strDiasTratamiento, _
                                                  objOtrasIdentificacionesABF.strMensajeCredencial, _
                                                  objOtrasIdentificacionesABF.strSinDespliegueBeneficiarios, _
                                                  objOtrasIdentificacionesABF.strDuplicaIdTransaccion, _
                                                  objOtrasIdentificacionesABF.strOtrasIdentificacionesABFModificadoPor)

            ' Execute the SQL statement
                aobjReturnedData = clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

            ' Return the results
            If IsNothing(aobjReturnedData) = False AndAlso aobjReturnedData.Length > 0 Then
                intRecordId = CInt(DirectCast(aobjReturnedData.GetValue(0), SortedList).GetByIndex(0))
            End If
            aobjReturnedData = Nothing
            Return intRecordId

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

        Public Shared Function intBuscarTblOtrasIdentificacionesABFPorId(ByVal strClienteABFId As String, ByVal strConnectionString As String) As Array
            ' Member identifier
            Const strmThisMemberName As String = "strConsultarTblRutaTransportesFrecuencia"

            ' Declare the local variables
            Dim strSQLStatement As StringBuilder
            Dim aobjReturnedData As Array

            Try

                ' Create the SQL statement
                strSQLStatement = New StringBuilder

                strSQLStatement.AppendFormat("EXECUTE spBuscarTblOtrasIdentificacionesABFPorId '{0}'", strClienteABFId)
                ' Execute the SQL statement
                aobjReturnedData = clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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

        Public Shared Function intActualizarTblOtrasIdentificacionesABF(ByVal objOtrasIdentificacionesABF As tblOtrasIdentificacionesABF, _
                                                                        ByVal strConnectionString As String) As Integer
            ' Member identifier
            Const strmThisMemberName As String = "intActualizarTblOtrasIdentificacionesABF"

            ' Declare the local variables
            Dim strSQLStatement As StringBuilder
            Dim intRecordId As Integer
            Dim aobjReturnedData As Array

            strSQLStatement = New StringBuilder

            Try

                Call strSQLStatement.AppendFormat("EXECUTE spActualizarTblOtrasIdentificacionesABF " & _
                                                  "'{0}', '{1}', '{2}', '{3}', " & _
                                                  "'{4}', '{5}', '{6}', '{7}', " & _
                                                  "'{8}', '{9}', '{10}', '{11}'," & _
                                                  "{12},   {13}, '{14}', '{15}'," & _
                                                  "{16},  '{17}', '{18}', '{19}'," & _
                                                  "'{20}', '{21}', '{22}', '{23}'," & _
                                                  "'{24}', '{25}'", _
                                                  objOtrasIdentificacionesABF.strClienteABFId, _
                                                  objOtrasIdentificacionesABF.strClienteABFNombre, _
                                                  objOtrasIdentificacionesABF.strMensajePOS, _
                                                  objOtrasIdentificacionesABF.strCredencialUnica, _
                                                  objOtrasIdentificacionesABF.strLlaveOnline, _
                                                  objOtrasIdentificacionesABF.blnConsHostExterno, _
                                                  objOtrasIdentificacionesABF.strCodigoStatus, _
                                                  objOtrasIdentificacionesABF.strCodigoConfirmaVenta, _
                                                  objOtrasIdentificacionesABF.strCodigoReversaVenta, _
                                                  objOtrasIdentificacionesABF.strTieneDVPHJ, _
                                                  objOtrasIdentificacionesABF.strAdjudicaSinStatus, _
                                                  objOtrasIdentificacionesABF.strMensajeSinStatus, _
                                                  objOtrasIdentificacionesABF.fltBonificacionSinStatus, _
                                                  objOtrasIdentificacionesABF.fltCreditoSinStatus, _
                                                  objOtrasIdentificacionesABF.strUsaOrdenDeCompra, _
                                                  objOtrasIdentificacionesABF.strValidaLimiteOC, _
                                                  objOtrasIdentificacionesABF.intLimiteOC, _
                                                  objOtrasIdentificacionesABF.strClavePadecimiento, _
                                                  objOtrasIdentificacionesABF.strClaveFamiliar, _
                                                  objOtrasIdentificacionesABF.strClaveUnica, _
                                                  objOtrasIdentificacionesABF.strClaveAutorizacion, _
                                                  objOtrasIdentificacionesABF.strDiasTratamiento, _
                                                  objOtrasIdentificacionesABF.strMensajeCredencial, _
                                                  objOtrasIdentificacionesABF.strSinDespliegueBeneficiarios, _
                                                  objOtrasIdentificacionesABF.strDuplicaIdTransaccion, _
                                                  objOtrasIdentificacionesABF.strOtrasIdentificacionesABFModificadoPor)

                ' Execute the SQL statement
                aobjReturnedData = clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                strSQLStatement = Nothing

                ' Return the results
                If IsNothing(aobjReturnedData) = False AndAlso aobjReturnedData.Length > 0 Then
                    intRecordId = CInt(DirectCast(aobjReturnedData.GetValue(0), SortedList).GetByIndex(0))
                End If

                aobjReturnedData = Nothing
                Return intRecordId

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

    Public Class clsOtrasIdentificacionesSucursal

        Private Const strmThisClassName As String = "Benavides.CC.Data.clsClientesABF.clsOtrasIdentificacionesSucursal"

        Public Shared Function strBuscarTblOtrasIdentificacionesSucursalPorClienteId(ByVal strClienteABFId As String, _
                                                                                     ByVal strConnectionString As String) As Array
            ' Member identifier
            Const strmThisMemberName As String = "strBuscarTblOtrasIdentificacionesSucursalPorClienteId"

            ' Declare the local variables
            Dim strSQLStatement As StringBuilder
            Dim aobjReturnedData As Array

            Try

                ' Create the SQL statement
                strSQLStatement = New StringBuilder

                strSQLStatement.AppendFormat("EXECUTE spBuscarTblOtrasIdentificacionesSucursalPorClienteId '{0}'", strClienteABFId)

                ' Execute the SQL statement
                aobjReturnedData = clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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

        Public Shared Function intEliminarTblOtrasIdentificacionesSucursal(ByVal strClienteABFId As String, _
                                                                           ByVal intCompaniaId As Integer, _
                                                                           ByVal intSucursalId As Integer, _
                                                                           ByVal strConnectionString As String) As Integer
            ' Constantes locales
            Const strmThisMemberName As String = "intEliminarTblOtrasIdentificacionesSucursal"

            ' Variables locales
            Dim strSQLStatement As StringBuilder = Nothing
            Dim intRowsAffected As Integer = 0
            Dim strRegistros As Array = Nothing
            Dim strRowsAffected As String() = Nothing

            Try

                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement. _
                    AppendFormat("EXECUTE spEliminarTblOtrasIdentificacionesSucursal '{0}', {1}, {2} ", strClienteABFId, _
                                                                                                        intCompaniaId, _
                                                                                                        intSucursalId)

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intEliminarTblOtrasIdentificacionesSucursal = intRowsAffected

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
                intEliminarTblOtrasIdentificacionesSucursal = 0

                ' Notificamos el error
                Throw
            End Try
        End Function

        Public Shared Function intGuardarTblOtrasIdentificacionesSucursal(ByVal strCadenaId As String, _
                                                                          ByVal intEstadoId As Integer, _
                                                                          ByVal intCiudadId As Integer, _
                                                                          ByVal intCompaniaId As Integer, _
                                                                          ByVal intSucursalId As Integer, _
                                                                          ByVal strClienteABFId As String, _
                                                                          ByVal strOtrasIdentificacionesSucursalModificadoPor As String, _
                                                                          ByVal strConnectionString As String) As Integer
            ' Member identifier
            Const strmThisMemberName As String = "intGuardarTblOtrasIdentificacionesSucursal"

            ' Declare the local variables
            Dim strSQLStatement As StringBuilder
            Dim intRecordId As Integer
            Dim aobjReturnedData As Array

            strSQLStatement = New StringBuilder

            Try
                Call strSQLStatement.AppendFormat("EXECUTE spAgregarTblOtrasIdentificacionesSucursal " & _
                                                  "'{0}', {1}, {2}, {3}," & _
                                                  " {4}, '{5}',{6}", strCadenaId, _
                                                                     intEstadoId, _
                                                                     intCiudadId, _
                                                                     intCompaniaId, _
                                                                     intSucursalId, _
                                                                     strClienteABFId, _
                                                                     strOtrasIdentificacionesSucursalModificadoPor)

                ' Execute the SQL statement
                aobjReturnedData = clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                strSQLStatement = Nothing

                ' Return the results
                If IsNothing(aobjReturnedData) = False AndAlso aobjReturnedData.Length > 0 Then
                    intRecordId = CInt(DirectCast(aobjReturnedData.GetValue(0), SortedList).GetByIndex(0))
                End If
                aobjReturnedData = Nothing
                Return intRecordId

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

        Public Shared Function intCopiarClienteSucursalesAsignadas(ByVal intCompaniaOrigenId As Integer, _
                                                                   ByVal intSucursalOrigenId As Integer, _
                                                                   ByVal intCompaniaDestinoId As Integer, _
                                                                   ByVal intSucursalDestinoId As Integer, _
                                                                   ByVal strOtrasIdentificacionesSucursalModificadoPor As String, _
                                                                   ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intCopiarClienteSucursalesAsignadas"

            ' Variables locales
            Dim strSQLStatement As StringBuilder = Nothing
            Dim intRowsAffected As Integer = 0
            Dim strRegistros As Array = Nothing
            Dim strRowsAffected As String() = Nothing

            Try

                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.AppendFormat("EXECUTE spCopiarClienteSucursalesAsignadas {0}, {1}, {2}, {3}, '{4}'", _
                                                                                                                    intCompaniaOrigenId, _
                                                                                                                    intSucursalOrigenId, _
                                                                                                                    intCompaniaDestinoId, _
                                                                                                                    intSucursalDestinoId, _
                                                                                                                    strOtrasIdentificacionesSucursalModificadoPor)

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intCopiarClienteSucursalesAsignadas = intRowsAffected

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
                intCopiarClienteSucursalesAsignadas = 0

                ' Notificamos el error
                Throw
            End Try
        End Function

        Public Shared Function strBuscarTblOtrasIdentificacionesSucursalPorCompaniaSucursal(ByVal intCompaniaId As Integer, _
                                                                                            ByVal intSucursalId As Integer, _
                                                                                            ByVal strConnectionString As String) As Array

            ' Member identifier
            Const strmThisMemberName As String = "strBuscarTblOtrasIdentificacionesSucursalPorCompaniaSucursal"

            ' Declare the local variables
            Dim strSQLStatement As System.Text.StringBuilder
            Dim aobjReturnedData As Array

            Try

                ' Create the SQL statement
                strSQLStatement = New System.Text.StringBuilder

                Call strSQLStatement. _
                    AppendFormat("EXECUTE spBuscarTblOtrasIdentificacionesSucursalPorCompaniaSucursal {0}, {1}", intCompaniaId, _
                                                                                                                 intSucursalId)

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

End Class

Public Class tblOtrasIdentificacionesABF

    Private _strClienteABFId As String
    Private _strClienteABFNombre As String
    Private _strMensajePOS As String
    Private _strCredencialUnica As String
    Private _strLlaveOnline As String
    Private _blnConsHostExterno As Boolean
    Private _strCodigoStatus As String
    Private _strCodigoConfirmaVenta As String
    Private _strCodigoReversaVenta As String
    Private _strTieneDVPHJ As String
    Private _strAdjudicaSinStatus As String
    Private _strMensajeSinStatus As String
    Private _fltBonificacionSinStatus As Decimal
    Private _fltCreditoSinStatus As Decimal
    Private _strUsaOrdenDeCompra As String
    Private _strValidaLimiteOC As String
    Private _intLimiteOC As Integer
    Private _strClavePadecimiento As String
    Private _strClaveFamiliar As String
    Private _strClaveUnica As String
    Private _strClaveAutorizacion As String
    Private _strDiasTratamiento As String
    Private _strMensajeCredencial As String
    Private _strSinDespliegueBeneficiarios As String
    Private _strDuplicaIdTransaccion As String
    Private _strOtrasIdentificacionesABFModificadoPor As String

    Public Property strClienteABFId() As String
        Get
            Return _strClienteABFId
        End Get
        Set(ByVal value As String)
            _strClienteABFId = value
        End Set
    End Property

    Public Property strClienteABFNombre() As String
        Get
            Return _strClienteABFNombre
        End Get
        Set(ByVal value As String)
            _strClienteABFNombre = value
        End Set
    End Property

    Public Property strMensajePOS() As String
        Get
            Return _strMensajePOS
        End Get
        Set(ByVal value As String)
            _strMensajePOS = value
        End Set
    End Property

    Public Property strCredencialUnica() As String
        Get
            Return _strCredencialUnica
        End Get
        Set(ByVal value As String)
            _strCredencialUnica = value
        End Set
    End Property

    Public Property strLlaveOnline() As String
        Get
            Return _strLlaveOnline
        End Get
        Set(ByVal value As String)
            _strLlaveOnline = value
        End Set
    End Property

    Public Property blnConsHostExterno() As Boolean
        Get
            Return _blnConsHostExterno
        End Get
        Set(ByVal value As Boolean)
            _blnConsHostExterno = value
        End Set
    End Property

    Public Property strCodigoStatus() As String
        Get
            Return _strCodigoStatus
        End Get
        Set(ByVal value As String)
            _strCodigoStatus = value
        End Set
    End Property

    Public Property strCodigoConfirmaVenta() As String
        Get
            Return _strCodigoConfirmaVenta
        End Get
        Set(ByVal value As String)
            _strCodigoConfirmaVenta = value
        End Set
    End Property

    Public Property strCodigoReversaVenta() As String
        Get
            Return _strCodigoReversaVenta
        End Get
        Set(ByVal value As String)
            _strCodigoReversaVenta = value
        End Set
    End Property

    Public Property strTieneDVPHJ() As String
        Get
            Return _strTieneDVPHJ
        End Get
        Set(ByVal value As String)
            _strTieneDVPHJ = value
        End Set
    End Property

    Public Property strAdjudicaSinStatus() As String
        Get
            Return _strAdjudicaSinStatus
        End Get
        Set(ByVal value As String)
            _strAdjudicaSinStatus = value
        End Set
    End Property

    Public Property strMensajeSinStatus() As String
        Get
            Return _strMensajeSinStatus
        End Get
        Set(ByVal value As String)
            _strMensajeSinStatus = value
        End Set
    End Property

    Public Property fltBonificacionSinStatus() As Decimal
        Get
            Return _fltBonificacionSinStatus
        End Get
        Set(ByVal value As Decimal)
            _fltBonificacionSinStatus = value
        End Set
    End Property

    Public Property fltCreditoSinStatus() As Decimal
        Get
            Return _fltCreditoSinStatus
        End Get
        Set(ByVal value As Decimal)
            _fltCreditoSinStatus = value
        End Set
    End Property

    Public Property strUsaOrdenDeCompra() As String
        Get
            Return _strUsaOrdenDeCompra
        End Get
        Set(ByVal value As String)
            _strUsaOrdenDeCompra = value
        End Set
    End Property

    Public Property strValidaLimiteOC() As String
        Get
            Return _strValidaLimiteOC
        End Get
        Set(ByVal value As String)
            _strValidaLimiteOC = value
        End Set
    End Property

    Public Property intLimiteOC() As Integer
        Get
            Return _intLimiteOC
        End Get
        Set(ByVal value As Integer)
            _intLimiteOC = value
        End Set
    End Property

    Public Property strClavePadecimiento() As String
        Get
            Return _strClavePadecimiento
        End Get
        Set(ByVal value As String)
            _strClavePadecimiento = value
        End Set
    End Property

    Public Property strClaveFamiliar() As String
        Get
            Return _strClaveFamiliar
        End Get
        Set(ByVal value As String)
            _strClaveFamiliar = value
        End Set
    End Property

    Public Property strClaveUnica() As String
        Get
            Return _strClaveUnica
        End Get
        Set(ByVal value As String)
            _strClaveUnica = value
        End Set
    End Property

    Public Property strClaveAutorizacion() As String
        Get
            Return _strClaveAutorizacion
        End Get
        Set(ByVal value As String)
            _strClaveAutorizacion = value
        End Set
    End Property

    Public Property strDiasTratamiento() As String
        Get
            Return _strDiasTratamiento
        End Get
        Set(ByVal value As String)
            _strDiasTratamiento = value
        End Set
    End Property

    Public Property strMensajeCredencial() As String
        Get
            Return _strMensajeCredencial
        End Get
        Set(ByVal value As String)
            _strMensajeCredencial = value
        End Set
    End Property

    Public Property strSinDespliegueBeneficiarios() As String
        Get
            Return _strSinDespliegueBeneficiarios
        End Get
        Set(ByVal value As String)
            _strSinDespliegueBeneficiarios = value
        End Set
    End Property

    Public Property strDuplicaIdTransaccion() As String
        Get
            Return _strDuplicaIdTransaccion
        End Get
        Set(ByVal value As String)
            _strDuplicaIdTransaccion = value
        End Set
    End Property

    Public Property strOtrasIdentificacionesABFModificadoPor() As String
        Get
            Return _strOtrasIdentificacionesABFModificadoPor
        End Get
        Set(ByVal value As String)
            _strOtrasIdentificacionesABFModificadoPor = value
        End Set
    End Property

    Public Sub New(ByVal strClienteABFId As String, ByVal strClienteABFNombre As String, _
                   ByVal strMensajePOS As String, ByVal strCredencialUnica As String, _
                   ByVal strLlaveOnline As String, ByVal blnConsHostExterno As Boolean, _
                   ByVal strCodigoStatus As String, ByVal strCodigoConfirmaVenta As String, _
                   ByVal strCodigoReversaVenta As String, ByVal strTieneDVPHJ As String, _
                   ByVal strAdjudicaSinStatus As String, ByVal strMensajeSinStatus As String, _
                   ByVal fltBonificacionSinStatus As Decimal, ByVal fltCreditoSinStatus As Decimal, _
                   ByVal strUsaOrdenDeCompra As String, ByVal strValidaLimiteOC As String, _
                   ByVal intLimiteOC As Integer, ByVal strClavePadecimiento As String, _
                   ByVal strClaveFamiliar As String, ByVal strClaveUnica As String, _
                   ByVal strClaveAutorizacion As String, ByVal strDiasTratamiento As String, _
                   ByVal strMensajeCredencial As String, ByVal strSinDespliegueBeneficiarios As String, _
                   ByVal strDuplicaIdTransaccion As String, ByVal strOtrasIdentificacionesABFModificadoPor As String)

        _strClienteABFId = strClienteABFId
        _strClienteABFNombre = strClienteABFNombre
        _strMensajePOS = strMensajePOS
        _strCredencialUnica = strCredencialUnica
        _strLlaveOnline = strLlaveOnline
        _blnConsHostExterno = blnConsHostExterno
        _strCodigoStatus = strCodigoStatus
        _strCodigoConfirmaVenta = strCodigoConfirmaVenta
        _strCodigoReversaVenta = strCodigoReversaVenta
        _strTieneDVPHJ = strTieneDVPHJ
        _strAdjudicaSinStatus = strAdjudicaSinStatus
        _strMensajeSinStatus = strMensajeSinStatus
        _fltBonificacionSinStatus = fltBonificacionSinStatus
        _fltCreditoSinStatus = fltCreditoSinStatus
        _strUsaOrdenDeCompra = strUsaOrdenDeCompra
        _strValidaLimiteOC = strValidaLimiteOC
        _intLimiteOC = intLimiteOC
        _strClavePadecimiento = strClavePadecimiento
        _strClaveFamiliar = strClaveFamiliar
        _strClaveUnica = strClaveUnica
        _strClaveAutorizacion = strClaveAutorizacion
        _strDiasTratamiento = strDiasTratamiento
        _strMensajeCredencial = strMensajeCredencial
        _strSinDespliegueBeneficiarios = strSinDespliegueBeneficiarios
        _strDuplicaIdTransaccion = strDuplicaIdTransaccion
        _strOtrasIdentificacionesABFModificadoPor = strOtrasIdentificacionesABFModificadoPor
    End Sub

End Class