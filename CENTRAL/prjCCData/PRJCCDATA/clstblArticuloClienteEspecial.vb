
'====================================================================
' Class         : clstblArticuloClienteEspecial
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : (c) Isocraft 2004 - 2009. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Joaquín Hdz. G. (joaquin@isocraft.com)
' Last Modified : Wednesday, December 15, 2004
'====================================================================
Imports System.Text
Imports Benavides.Data.SQL.MSSQL

Public NotInheritable Class clstblArticuloClienteEspecial

    ' Class identifier
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblArticuloClienteEspecial"

    ' Class constructor
    Private Sub New()
        ' Empty constructor to avoid the creation of the default constructor
    End Sub

    '====================================================================
    ' Name          : intAgregar
    ' Description   : Adds a new record and returns its integer identifier
    ' Table name    : tblArticuloClienteEspecial
    ' Parameters    : 
    '              ByVal intArticuloId As Int32
    '                  - 
    '              ByVal intClienteEspecialId As Decimal
    '                  - 
    '              ByVal fltArticuloClienteEspecialPrecio As Decimal
    '                  - 
    '              ByVal dtmArticuloClienteEspecialUltimaModificacion As DateTime
    '                  - 
    '              ByVal strArticuloClienteEspecialModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intAgregar( _
      ByVal intArticuloId As Int32, _
      ByVal intClienteEspecialId As Decimal, _
      ByVal fltArticuloClienteEspecialPrecio As Decimal, _
      ByVal dtmArticuloClienteEspecialUltimaModificacion As DateTime, _
      ByVal strArticuloClienteEspecialModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spAgregartblArticuloClienteEspecial ")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intClienteEspecialId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloClienteEspecialPrecio)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloClienteEspecialUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloClienteEspecialModificadoPor)
            Call strSQLStatement.Append("'")

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
    ' Table name    : tblArticuloClienteEspecial
    ' Parameters    : 
    '              ByVal intArticuloId As Int32
    '                  - 
    '              ByVal intClienteEspecialId As Decimal
    '                  - 
    '              ByVal fltArticuloClienteEspecialPrecio As Decimal
    '                  - 
    '              ByVal dtmArticuloClienteEspecialUltimaModificacion As DateTime
    '                  - 
    '              ByVal strArticuloClienteEspecialModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intEliminar( _
      ByVal intArticuloId As Int32, _
      ByVal intClienteEspecialId As Decimal, _
      ByVal fltArticuloClienteEspecialPrecio As Decimal, _
      ByVal dtmArticuloClienteEspecialUltimaModificacion As DateTime, _
      ByVal strArticuloClienteEspecialModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spEliminartblArticuloClienteEspecial ")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intClienteEspecialId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloClienteEspecialPrecio)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloClienteEspecialUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloClienteEspecialModificadoPor)
            Call strSQLStatement.Append("'")

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
    ' Table name    : tblArticuloClienteEspecial
    ' Parameters    : 
    '              ByVal intArticuloId As Int32
    '                  - 
    '              ByVal intClienteEspecialId As Decimal
    '                  - 
    '              ByVal fltArticuloClienteEspecialPrecio As Decimal
    '                  - 
    '              ByVal dtmArticuloClienteEspecialUltimaModificacion As DateTime
    '                  - 
    '              ByVal strArticuloClienteEspecialModificadoPor As String
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
      ByVal intArticuloId As Int32, _
      ByVal intClienteEspecialId As Decimal, _
      ByVal fltArticuloClienteEspecialPrecio As Decimal, _
      ByVal dtmArticuloClienteEspecialUltimaModificacion As DateTime, _
      ByVal strArticuloClienteEspecialModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spBuscartblArticuloClienteEspecial ")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intClienteEspecialId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloClienteEspecialPrecio)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloClienteEspecialUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloClienteEspecialModificadoPor)
            Call strSQLStatement.Append("'")
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
    ' Table name    : tblArticuloClienteEspecial
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
            Call strSQLStatement.Append("EXECUTE spBuscarCambiotblArticuloClienteEspecial ")
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
    ' Name       : strBuscarCambios
    ' Description: Búsqueda de registros modificados y que
    '              necesitan ser reenviados.
    '                 - Tabla tblArticuloClienteEspecial
    '
    ' Parameters :
    '              ByVal intTiendaId As Integer
    '                 - Tienda a Transmitir datos
    '              ByVal dtmUltimaModificacionInicial As Date
    '                 - Fecha inicial de búsqueda
    '              ByVal dtmUltimaModificacionFinal As Date
    '                 - Fecha final de búsqueda    
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '                 - Arreglo bidimensional con los registros leídos
    '                   Array = { (c1,c2..cn), (c1,c2..cn) ... (c1,c2..cn) }
    '                   c = Campo
    '====================================================================
    Public Shared Function strBuscarCambios( _
      ByVal intTiendaId As Integer, _
      ByVal dtmUltimaModificacionInicial As Date, _
      ByVal dtmUltimaModificacionFinal As Date, _
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
            ' Creamos es estatuto de SQL         
            Call strSQLStatement.Append("EXECUTE spBuscartblArticuloClienteEspecialCambios ")
            Call strSQLStatement.Append(intTiendaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmUltimaModificacionInicial.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmUltimaModificacionFinal.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
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
    ' Table name    : tblArticuloClienteEspecial
    ' Parameters    : 
    '              ByVal intArticuloId As Int32
    '                  - 
    '              ByVal intClienteEspecialId As Decimal
    '                  - 
    '              ByVal fltArticuloClienteEspecialPrecio As Decimal
    '                  - 
    '              ByVal dtmArticuloClienteEspecialUltimaModificacion As DateTime
    '                  - 
    '              ByVal strArticuloClienteEspecialModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intActualizar( _
      ByVal intArticuloId As Int32, _
      ByVal intClienteEspecialId As Decimal, _
      ByVal fltArticuloClienteEspecialPrecio As Decimal, _
      ByVal dtmArticuloClienteEspecialUltimaModificacion As DateTime, _
      ByVal strArticuloClienteEspecialModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spActualizartblArticuloClienteEspecial ")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intClienteEspecialId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloClienteEspecialPrecio)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloClienteEspecialUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloClienteEspecialModificadoPor)
            Call strSQLStatement.Append("'")

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
