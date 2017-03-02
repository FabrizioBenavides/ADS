
Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clstblSucursalCTF
' Title         : tblSucursalCTF
' Description   : Cupones
' Copyright     : 2004 Todos los Derechos Reservados.
' Company       : Dirección de Tecnología
' Author        : Isocraft S.A. de C.V.
' Version       : 1.0
' Last Modified : Viernes, 14 de Mayo de 2004
'====================================================================
Public NotInheritable Class clstblSucursalCTF

    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblSucursalCTF"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()

    End Sub

    '====================================================================
    ' Name          : intActualizar
    ' Description   : Updates records and returns the number of updated items
    ' Table name    : tblSucursalCTF
    ' Parameters    : 
    '              ByVal intCompaniaId As Int32
    '                  - 
    '              ByVal intSucursalId As Int32
    '                  - 
    '              ByVal dtmFechaLiberacion As DateTime
    '                  - 
    '              ByVal dtmSucursalCTFUltimaModificacion As DateTime
    '                  - 
    '              ByVal strSucursalCTFModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - 
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intActualizar( _
    ByVal intCompaniaId As Int32, _
    ByVal intSucursalId As Int32, _
    ByVal blnSucursalCTFTransmiteTickets As Boolean, _
    ByVal blnSucursalCTFTransmitePoliza As Boolean, _
    ByVal blnSucursalCTFTransmiteVentas As Boolean, _
    ByVal blnSucursalCTFTransmiteCreditos As Boolean, _
    ByVal blnSucursalCTFLiberada As Boolean, _
    ByVal dtmSucursalCTFFechaLiberacion As DateTime, _
    ByVal dtmSucursalCTFUltimaModificacion As DateTime, _
    ByVal strSucursalCTFModificadoPor As String, _
    ByVal strConnectionString As String) As Integer

        ' Member identifier
        Const strmThisMemberName As String = "intActualizar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRowsAffected As Integer
        Dim aobjReturnedData As Array

        Try

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spActualizartblSucursalCTF ")

            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & CByte(blnSucursalCTFTransmiteTickets) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & CByte(blnSucursalCTFTransmitePoliza) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & CByte(blnSucursalCTFTransmiteVentas) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & CByte(blnSucursalCTFTransmiteCreditos) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & CByte(blnSucursalCTFLiberada) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & dtmSucursalCTFFechaLiberacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & dtmSucursalCTFUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & strSucursalCTFModificadoPor & "'")

            ' Execute the SQL statement
            aobjReturnedData = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

            ' Return the results
            If IsNothing(aobjReturnedData) = False AndAlso aobjReturnedData.Length > 0 Then

                intRowsAffected = CInt(DirectCast(aobjReturnedData.GetValue(0), Array).GetValue(0))

            End If

            aobjReturnedData = Nothing
            Return intRowsAffected

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

    '====================================================================
    ' Name          : intAgregar
    ' Description   : Adds a new record and returns its integer identifier
    ' Table name    : tblSucursalCTF
    ' Parameters    : 
    '              ByVal intCompaniaId As Int32
    '                  - 
    '              ByVal intSucursalId As Int32
    '                  - 
    '              ByVal dtmFechaLiberacion As DateTime
    '                  - 
    '              ByVal dtmSucursalCTFUltimaModificacion As DateTime
    '                  - 
    '              ByVal strSucursalCTFModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - 
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intAgregar( _
    ByVal intCompaniaId As Int32, _
    ByVal intSucursalId As Int32, _
    ByVal blnSucursalCTFTransmiteTickets As Boolean, _
    ByVal blnSucursalCTFTransmitePoliza As Boolean, _
    ByVal blnSucursalCTFTransmiteVentas As Boolean, _
    ByVal blnSucursalCTFTransmiteCreditos As Boolean, _
    ByVal blnSucursalCTFLiberada As Boolean, _
    ByVal dtmSucursalCTFFechaLiberacion As DateTime, _
    ByVal dtmSucursalCTFUltimaModificacion As DateTime, _
    ByVal strSucursalCTFModificadoPor As String, _
    ByVal strConnectionString As String) As Integer

        ' Member identifier
        Const strmThisMemberName As String = "intAgregar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRecordId As Integer
        Dim aobjReturnedData As Array

        Try

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spAgregartblSucursalCTF ")

            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & CByte(blnSucursalCTFTransmiteTickets) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & CByte(blnSucursalCTFTransmitePoliza) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & CByte(blnSucursalCTFTransmiteVentas) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & CByte(blnSucursalCTFTransmiteCreditos) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & CByte(blnSucursalCTFLiberada) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & dtmSucursalCTFFechaLiberacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & dtmSucursalCTFUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & strSucursalCTFModificadoPor & "'")

            ' Execute the SQL statement
            aobjReturnedData = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

            ' Return the results
            If IsNothing(aobjReturnedData) = False AndAlso aobjReturnedData.Length > 0 Then

                intRecordId = CInt(DirectCast(aobjReturnedData.GetValue(0), Array).GetValue(0))

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


    '====================================================================
    ' Name          : intEliminar
    ' Description   : Deletes records and returns the number of deleted items
    ' Table name    : tblSucursalCTF
    ' Parameters    : 
    '              ByVal intCompaniaId As Int32
    '                  - 
    '              ByVal intSucursalId As Int32
    '                  - 
    '              ByVal dtmFechaLiberacion As DateTime
    '                  - 
    '              ByVal dtmSucursalCTFUltimaModificacion As DateTime
    '                  - 
    '              ByVal strSucursalCTFModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - 
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intEliminar( _
    ByVal intCompaniaId As Int32, _
    ByVal intSucursalId As Int32, _
    ByVal blnSucursalCTFTransmiteTickets As Boolean, _
    ByVal blnSucursalCTFTransmitePoliza As Boolean, _
    ByVal blnSucursalCTFTransmiteVentas As Boolean, _
    ByVal blnSucursalCTFTransmiteCreditos As Boolean, _
    ByVal blnSucursalCTFLiberada As Boolean, _
    ByVal dtmSucursalCTFFechaLiberacion As DateTime, _
    ByVal dtmSucursalCTFUltimaModificacion As DateTime, _
    ByVal strSucursalCTFModificadoPor As String, _
    ByVal strConnectionString As String) As Integer

        ' Member identifier 
        Const strmThisMemberName As String = "intEliminar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRowsAffected As Integer
        Dim aobjReturnedData As Array

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spEliminartblSucursalCTF ")

            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & CByte(blnSucursalCTFTransmiteTickets) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & CByte(blnSucursalCTFTransmitePoliza) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & CByte(blnSucursalCTFTransmiteVentas) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & CByte(blnSucursalCTFTransmiteCreditos) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & CByte(blnSucursalCTFLiberada) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & dtmSucursalCTFFechaLiberacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & dtmSucursalCTFUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & strSucursalCTFModificadoPor & "'")

            ' Execute the SQL statement
            aobjReturnedData = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

            ' Return the results
            If IsNothing(aobjReturnedData) = False AndAlso aobjReturnedData.Length > 0 Then

                intRowsAffected = CInt(DirectCast(aobjReturnedData.GetValue(0), Array).GetValue(0))

            End If

            aobjReturnedData = Nothing
            Return intRowsAffected

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

    '====================================================================
    ' Name          : strBuscar
    ' Description   : Returns an array of SortedList objects with the records found
    ' Table name    : tblSucursalCTF
    ' Parameters    : 
    '              ByVal intCompaniaId As Int32
    '                  - 
    '              ByVal intSucursalId As Int32
    '                  - 
    '              ByVal dtmFechaLiberacion As DateTime
    '                  - 
    '              ByVal dtmSucursalCTFUltimaModificacion As DateTime
    '                  - 
    '              ByVal strSucursalCTFModificadoPor As String
    '                  -     
    '              ByVal intInitialPosition As  Double
    '                 - 
    '              ByVal intElementsToRetrieve As Double
    '                 _
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Array
    '====================================================================
    Public Shared Function strBuscar( _
    ByVal intCompaniaId As Int32, _
    ByVal intSucursalId As Int32, _
    ByVal blnSucursalCTFTransmiteTickets As Boolean, _
    ByVal blnSucursalCTFTransmitePoliza As Boolean, _
    ByVal blnSucursalCTFTransmiteVentas As Boolean, _
    ByVal blnSucursalCTFTransmiteCreditos As Boolean, _
    ByVal blnSucursalCTFLiberada As Boolean, _
    ByVal dtmSucursalCTFFechaLiberacion As DateTime, _
    ByVal dtmSucursalCTFUltimaModificacion As DateTime, _
    ByVal strSucursalCTFModificadoPor As String, _
    ByVal intInitialPosition As Int32, _
    ByVal intElementsToRetrieve As Int32, _
    ByVal strConnectionString As String) As Array

        ' Member identifier
        Const strmThisMemberName As String = "strBuscar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array

        Try

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spBuscartblSucursalCTF ")

            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & CByte(blnSucursalCTFTransmiteTickets) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & CByte(blnSucursalCTFTransmitePoliza) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & CByte(blnSucursalCTFTransmiteVentas) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & CByte(blnSucursalCTFTransmiteCreditos) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & CByte(blnSucursalCTFLiberada) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & dtmSucursalCTFFechaLiberacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & dtmSucursalCTFUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'" & strSucursalCTFModificadoPor & "'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intInitialPosition)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intElementsToRetrieve)

            ' Execute the SQL statement
            aobjReturnedData = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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

    Public Shared Function strBuscar( _
      ByVal dtmStart As DateTime, _
      ByVal dtmEnd As DateTime, _
      ByVal strConnectionString As String) As Array

        ' Member identifier
        Const strmThisMemberName As String = "strBuscar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New System.Text.StringBuilder

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spBuscarCambiotblSucursalCTF ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmStart.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmEnd.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")

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

    Public Shared Function strBuscarSucursalCTFLiberada( _
        ByVal intCompaniaId As Integer, _
        ByVal intSucursalId As Integer, _
        ByVal strConnectionString As String) As Array

        ' Member identifier
        Const strmThisMemberName As String = "strBuscarSucursalCTFLiberada"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New System.Text.StringBuilder

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spBuscarSucursalCTFLiberada ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intSucursalId)

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
