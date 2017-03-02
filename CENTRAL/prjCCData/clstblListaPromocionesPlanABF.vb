'====================================================================
' Class         : clstblListaPromocionesPlanABF
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Table maintenance
' Copyright     : BENAVIDES 2005 - 2010. All rights reserved
' Company       : BENAVIDES
' Author        : J,ANTONIO HERNANDEZ
' Last Modified : MIERCOLES, MAYO 24 2006
'====================================================================
Public NotInheritable Class clstblListaPromocionesPlanABF

    ' Class identifier
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblListaPromocionesPlanABF"

    ' Class constructor
    Private Sub New()
        ' Empty constructor to avoid the creation of the default constructor
    End Sub

    '====================================================================
    ' Name          : intAgregar
    ' Description   : Adds a new record and returns its integer identifier
    ' Table name    : tblListaPromocionesPlanABF
    ' Parameters    : 
    '              ByVal intListaPromocionesPlanABFId As Int32
    '                  - 
    '              ByVal strListaPromocionesPlanABFNombre As String
    '                  - 
    '              ByVal strListaPromocionesPlanABFGlosa As String
    '                  -     
    '              ByVal dtmListaPromocionesPlanABFRegistro As DateTime
    '                  - 
    '              ByVal dtmListaPromocionesPlanABFInicioVigencia As DateTime
    '                  - 
    '              ByVal dtmListaPromocionesPlanABFTerminoVigencia As DateTime
    '                  -     
    
    '              ByVal dtmListaPromocionesPlanABFUltimaModificacion As DateTime
    '                  - 
    '              ByVal strListaPromocionesPlanABFModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intAgregar( _
      ByVal intListaPromocionesPlanABFId As Int32, _
      ByVal strListaPromocionesPlanABFNombre As String, _
      ByVal strListaPromocionesPlanABFGlosa As String, _
      ByVal dtmListaPromocionesPlanABFRegistro As DateTime, _
      ByVal dtmListaPromocionesPlanABFInicioVigencia As DateTime, _
      ByVal dtmListaPromocionesPlanABFTerminoVigencia As DateTime, _
      ByVal dtmListaPromocionesPlanABFUltimaModificacion As DateTime, _
      ByVal strListaPromocionesPlanABFModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spAgregartblListaPromocionesPlanABF ")

            Call strSQLStatement.Append(intListaPromocionesPlanABFId)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & strListaPromocionesPlanABFNombre & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & strListaPromocionesPlanABFGlosa & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & dtmListaPromocionesPlanABFRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & dtmListaPromocionesPlanABFInicioVigencia.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & dtmListaPromocionesPlanABFTerminoVigencia.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & dtmListaPromocionesPlanABFUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & strListaPromocionesPlanABFModificadoPor & "'")



            ' Execute the SQL statement
            aobjReturnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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

    '====================================================================
    ' Name          : intEliminar
    ' Description   : Deletes records and returns the number of deleted items
    ' Table name    : tblListaPromocionesPlanABF
    ' Parameters    : 
    '              ByVal intListaPromocionesPlanABFId As Int32
    '                  - 
    '              ByVal strListaPromocionesPlanABFNombre As String
    '                  - 
    '              ByVal strListaPromocionesPlanABFGlosa As String
    '                  -     
    '              ByVal dtmListaPromocionesPlanABFRegistro As DateTime
    '                  - 
    '              ByVal dtmListaPromocionesPlanABFInicioVigencia As DateTime
    '                  - 
    '              ByVal dtmListaPromocionesPlanABFTerminoVigencia As DateTime
    '                  -     

    '              ByVal dtmListaPromocionesPlanABFUltimaModificacion As DateTime
    '                  - 
    '              ByVal strListaPromocionesPlanABFModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intEliminar( _
      ByVal intListaPromocionesPlanABFId As Int32, _
      ByVal strListaPromocionesPlanABFNombre As String, _
      ByVal strListaPromocionesPlanABFGlosa As String, _
      ByVal dtmListaPromocionesPlanABFRegistro As DateTime, _
      ByVal dtmListaPromocionesPlanABFInicioVigencia As DateTime, _
      ByVal dtmListaPromocionesPlanABFTerminoVigencia As DateTime, _
      ByVal dtmListaPromocionesPlanABFUltimaModificacion As DateTime, _
      ByVal strListaPromocionesPlanABFModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spEliminartblListaPromocionesPlanABF ")

            Call strSQLStatement.Append(intListaPromocionesPlanABFId)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & strListaPromocionesPlanABFNombre & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & strListaPromocionesPlanABFGlosa & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & dtmListaPromocionesPlanABFRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & dtmListaPromocionesPlanABFInicioVigencia.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & dtmListaPromocionesPlanABFTerminoVigencia.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & dtmListaPromocionesPlanABFUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & strListaPromocionesPlanABFModificadoPor & "'")

            ' Execute the SQL statement
            aobjReturnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

            ' Return the results
            If IsNothing(aobjReturnedData) = False AndAlso aobjReturnedData.Length > 0 Then
                intRowsAffected = CInt(DirectCast(aobjReturnedData.GetValue(0), SortedList).GetByIndex(0))
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
    ' Table name    : tblListaPromocionesPlanABF
    ' Parameters    : 
    '              ByVal intListaPromocionesPlanABFId As Int32
    '                  - 
    '              ByVal strListaPromocionesPlanABFNombre As String
    '                  - 
    '              ByVal strListaPromocionesPlanABFGlosa As String
    '                  -     
    '              ByVal dtmListaPromocionesPlanABFRegistro As DateTime
    '                  - 
    '              ByVal dtmListaPromocionesPlanABFInicioVigencia As DateTime
    '                  - 
    '              ByVal dtmListaPromocionesPlanABFTerminoVigencia As DateTime
    '                  -     

    '              ByVal dtmListaPromocionesPlanABFUltimaModificacion As DateTime
    '                  - 
    '              ByVal strListaPromocionesPlanABFModificadoPor As String
    '                  - 
    '              ByVal intInitialPosition As  Double
    '                 - Initial position
    '              ByVal intElementsToRetrieve As Double
    '                 - Number of elements per page
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Array
    '====================================================================
    Public Shared Function strBuscar( _
      ByVal intListaPromocionesPlanABFId As Int32, _
      ByVal strListaPromocionesPlanABFNombre As String, _
      ByVal strListaPromocionesPlanABFGlosa As String, _
      ByVal dtmListaPromocionesPlanABFRegistro As DateTime, _
      ByVal dtmListaPromocionesPlanABFInicioVigencia As DateTime, _
      ByVal dtmListaPromocionesPlanABFTerminoVigencia As DateTime, _
      ByVal dtmListaPromocionesPlanABFUltimaModificacion As DateTime, _
      ByVal strListaPromocionesPlanABFModificadoPor As String, _
      ByVal intInitialPosition As Double, _
      ByVal intElementsToRetrieve As Double, _
      ByVal strConnectionString As String) As Array

        ' Member identifier
        Const strmThisMemberName As String = "strBuscar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array

        Try

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spBuscartblListaPromocionesPlanABF ")

            Call strSQLStatement.Append(intListaPromocionesPlanABFId)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & strListaPromocionesPlanABFNombre & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & strListaPromocionesPlanABFGlosa & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & dtmListaPromocionesPlanABFRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & dtmListaPromocionesPlanABFInicioVigencia.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & dtmListaPromocionesPlanABFTerminoVigencia.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & dtmListaPromocionesPlanABFUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & strListaPromocionesPlanABFModificadoPor & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append(intInitialPosition)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append(intElementsToRetrieve)

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

    '====================================================================
    ' Name          : strBuscar
    ' Description   : Returns an array of SortedList objects with the records found
    ' Table name    : tblListaPromocionesPlanABF
    ' Parameters    :
    '              ByVal dtmStart As Date
    '                 - Start date
    '              ByVal dtmEnd As Date
    '                 - End date
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Array
    '====================================================================
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
            Call strSQLStatement.Append("EXECUTE spBuscarCambiotblListaPromocionesPlanABF ")
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

    '====================================================================
    ' Name          : intActualizar
    ' Description   : Updates records and returns the number of updated items
    ' Table name    : tblListaPromocionesPlanABF
    ' Parameters    : 
    '              ByVal intListaPromocionesPlanABFId As Int32
    '                  - 
    '              ByVal strListaPromocionesPlanABFNombre As String
    '                  - 
    '              ByVal strListaPromocionesPlanABFGlosa As String
    '                  -     
    '              ByVal dtmListaPromocionesPlanABFRegistro As DateTime
    '                  - 
    '              ByVal dtmListaPromocionesPlanABFInicioVigencia As DateTime
    '                  - 
    '              ByVal dtmListaPromocionesPlanABFTerminoVigencia As DateTime
    '                  -     

    '              ByVal dtmListaPromocionesPlanABFUltimaModificacion As DateTime
    '                  - 
    '              ByVal strListaPromocionesPlanABFModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intActualizar( _
      ByVal intListaPromocionesPlanABFId As Int32, _
      ByVal strListaPromocionesPlanABFNombre As String, _
      ByVal strListaPromocionesPlanABFGlosa As String, _
      ByVal dtmListaPromocionesPlanABFRegistro As DateTime, _
      ByVal dtmListaPromocionesPlanABFInicioVigencia As DateTime, _
      ByVal dtmListaPromocionesPlanABFTerminoVigencia As DateTime, _
      ByVal dtmListaPromocionesPlanABFUltimaModificacion As DateTime, _
      ByVal strListaPromocionesPlanABFModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spActualizartblListaPromocionesPlanABF ")

            Call strSQLStatement.Append(intListaPromocionesPlanABFId)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & strListaPromocionesPlanABFNombre & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & strListaPromocionesPlanABFGlosa & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & dtmListaPromocionesPlanABFRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & dtmListaPromocionesPlanABFInicioVigencia.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & dtmListaPromocionesPlanABFTerminoVigencia.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & dtmListaPromocionesPlanABFUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) & "'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'" & strListaPromocionesPlanABFModificadoPor & "'")

            ' Execute the SQL statement
            aobjReturnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

            ' Return the results
            If IsNothing(aobjReturnedData) = False AndAlso aobjReturnedData.Length > 0 Then
                intRowsAffected = CInt(DirectCast(aobjReturnedData.GetValue(0), SortedList).GetByIndex(0))
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

End Class
