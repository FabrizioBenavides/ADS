Imports System.Text
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
