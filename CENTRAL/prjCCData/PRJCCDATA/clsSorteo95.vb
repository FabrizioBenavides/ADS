Imports System.Text
Imports Benavides.Data.SQL.MSSQL
'====================================================================
' Class         : clsSorteo95
' Title         : 
' Description   : Capa de datos web srevice wsSorteo95
' Copyright     : Softtek
' Company       : Softtek
' Author        : Patricio Torres
' Version       : 1.0
' Last Modified : 20120720
'====================================================================
Public NotInheritable Class clsSorteo95
    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clsSorteo95"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()
    End Sub


    '====================================================================
    ' Name          : strConsultarSorteo95
    ' Description   : Regresa un arreglo con los folios del sorteo de 95 aniversario y su estado.
    ' Table name    : tblEstadoSorteo
    ' Parameters    : 
    '                   ByVal strFolios - La lista de folios separada por Pipes, ej '123000|456000|789000'
    '                   ByVal strCompania - Id de la compania
    '                   ByVal strSucursal - Id de la sucursal
    '                   ByVal strCaja - Id de la Caja
    '                   ByVal strTicket - Id del ticket de compra
    '                   ByVal strCajero - Id Usuario
    '                   ByVal strConnectionString - Cadena de conexion
    ' Throws        : Exception
    ' Output        : Array
    '====================================================================
    Public Shared Function strConsultarSorteo95(ByVal strFolios As String, ByVal strCompania As String, ByVal strSucursal As String, ByVal strCaja As String, ByVal strTicket As String, ByVal strCajero As String, ByVal strConnectionString As String) As Array
        ' Member identifier
        Const strmThisMemberName As String = "strConsultarSorteo95"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array

        Try

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spControlFoliosPromocion95Aniversario ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strFolios)
            Call strSQLStatement.Append("', ")
            Call strSQLStatement.Append(strCompania)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(strSucursal)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(strCaja)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(strTicket)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(strCajero)

            ' Execute the SQL statement
            aobjReturnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
