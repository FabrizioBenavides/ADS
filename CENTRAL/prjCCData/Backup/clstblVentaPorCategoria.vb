
'====================================================================
' Class         : clstblVentaPorCategoria
' Title         : Grupo Benavides Enterprise Retail System
' Description   : Table Maintenance
' Copyright     : (c) Isocraft 2006 - 2011. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Joaquin Hdz. G. (joaquin@isocraft.com)
' Last Modified : Wednesday, November 29, 2006
'====================================================================
Public NotInheritable Class clstblVentaPorCategoria

    ' Class identifier
    Private Const CLASS_NAME As String = "Benavides.CC.Data.clstblVentaPorCategoria"

    ' Class constructor
    Private Sub New()
        ' Empty constructor to avoid the creation of the default constructor
    End Sub

    '====================================================================
    ' Name          : intAgregar
    ' Description   : Adds a new record and returns its integer identifier
    ' Table name    : tblVentaPorCategoria
    ' Parameters    : 
    '              ByVal intDivisionArticulosId As Integer
    '                  - 
    '              ByVal intCategoriaArticulosId As Integer
    '                  - 
    '              ByVal intVentaPorCategoriaId As Integer
    '                  - 
    '              ByVal intCompaniaId As Int32
    '                  - 
    '              ByVal intSucursalId As Int32
    '                  - 
    '              ByVal fltVentaPorCategoriaImporte As Double
    '                  - 
    '              ByVal fltVentaPorCategoriaImportePresupuesto As Double
    '                  - 
    '              ByVal dtmVentaPorCategoriaRegistro As DateTime
    '                  - 
    '              ByVal dtmVentaPorCategoriaUltimaModificacion As DateTime
    '                  - 
    '              ByVal strVentaPorCategoriaModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intAgregar(ByVal intDivisionArticulosId As Integer, _
                                      ByVal intCategoriaArticulosId As Integer, _
                                      ByVal intVentaPorCategoriaId As Integer, _
                                      ByVal intCompaniaId As Int32, _
                                      ByVal intSucursalId As Int32, _
                                      ByVal fltVentaPorCategoriaImporte As Double, _
                                      ByVal fltVentaPorCategoriaImportePresupuesto As Double, _
                                      ByVal dtmVentaPorCategoriaRegistro As DateTime, _
                                      ByVal dtmVentaPorCategoriaUltimaModificacion As DateTime, _
                                      ByVal strVentaPorCategoriaModificadoPor As String, _
                                      ByVal strConnectionString As String) As Integer

        ' Member identifier
        Const MEMBER_NAME As String = "intAgregar"

        ' Declare the local variables
        Dim sqlStatementToBeExecuted As System.Text.StringBuilder
        Dim newRecordId As Integer
        Dim returnedData As Array

        Try

            ' Create the SQL statement
            sqlStatementToBeExecuted = New System.Text.StringBuilder
            Call sqlStatementToBeExecuted.Append("EXECUTE spAgregartblVentaPorCategoria ")
            Call sqlStatementToBeExecuted.Append(intDivisionArticulosId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intCategoriaArticulosId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intVentaPorCategoriaId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intCompaniaId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intSucursalId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(fltVentaPorCategoriaImporte)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(fltVentaPorCategoriaImportePresupuesto)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmVentaPorCategoriaRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmVentaPorCategoriaUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strVentaPorCategoriaModificadoPor)
            Call sqlStatementToBeExecuted.Append("'")

            ' Execute the SQL statement
            returnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(sqlStatementToBeExecuted.ToString(), strConnectionString)
            sqlStatementToBeExecuted = Nothing

            ' Return the results
            If Not IsNothing(returnedData) AndAlso returnedData.Length > 0 Then
                newRecordId = CInt(DirectCast(returnedData.GetValue(0), SortedList).GetByIndex(0))
            End If

            returnedData = Nothing
            Return newRecordId

        Catch myException As Exception

            ' Declare the error variables
            Dim errorMessage As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim applicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim productName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName

            ' Create the error message
            Call errorMessage.Append("Product name:" & vbCrLf & vbTab & productName & "." & CLASS_NAME & "." & MEMBER_NAME & vbCrLf & vbCrLf)
            Call errorMessage.Append("Application name:" & vbCrLf & vbTab & System.Reflection.Assembly.GetExecutingAssembly.Location & vbCrLf & vbCrLf)
            Call errorMessage.Append("Version:" & vbCrLf & vbTab & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & vbCrLf & vbCrLf)
            Call errorMessage.Append("Source:" & vbCrLf & vbTab & myException.Source & vbCrLf & vbCrLf)
            Call errorMessage.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(Err.Number) & vbCrLf & vbCrLf)
            Call errorMessage.Append("Line number:" & vbCrLf & vbTab & Erl() & vbCrLf & vbCrLf)
            Call errorMessage.Append("Message:" & vbCrLf & vbTab & myException.Message & vbCrLf & vbCrLf)
            Call errorMessage.Append("SQLStatement:" & vbCrLf & vbTab & sqlStatementToBeExecuted.ToString() & vbCrLf & vbCrLf)
            Call errorMessage.Append("StackTrace:" & vbCrLf & myException.StackTrace & vbCrLf & vbCrLf)

            ' Create the event source
            If Not EventLog.SourceExists(productName) Then
                Call EventLog.CreateEventSource(productName, "Application")
            End If

            ' Set the event source
            applicationEventLog.Source = productName

            ' Write the event. It can be read in the Event Viewer.
            Call applicationEventLog.WriteEntry(errorMessage.ToString(), EventLogEntryType.Error, Err.Number, 0)

            ' Clear the variables
            sqlStatementToBeExecuted = Nothing
            returnedData = Nothing

            ' Raise the error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name          : intEliminar
    ' Description   : Deletes records and returns the number of deleted items
    ' Table name    : tblVentaPorCategoria
    ' Parameters    : 
    '              ByVal intDivisionArticulosId As Integer
    '                  - 
    '              ByVal intCategoriaArticulosId As Integer
    '                  - 
    '              ByVal intVentaPorCategoriaId As Integer
    '                  - 
    '              ByVal intCompaniaId As Int32
    '                  - 
    '              ByVal intSucursalId As Int32
    '                  - 
    '              ByVal fltVentaPorCategoriaImporte As Double
    '                  - 
    '              ByVal fltVentaPorCategoriaImportePresupuesto As Double
    '                  - 
    '              ByVal dtmVentaPorCategoriaRegistro As DateTime
    '                  - 
    '              ByVal dtmVentaPorCategoriaUltimaModificacion As DateTime
    '                  - 
    '              ByVal strVentaPorCategoriaModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intEliminar(ByVal intDivisionArticulosId As Integer, _
                                       ByVal intCategoriaArticulosId As Integer, _
                                       ByVal intVentaPorCategoriaId As Integer, _
                                       ByVal intCompaniaId As Int32, _
                                       ByVal intSucursalId As Int32, _
                                       ByVal fltVentaPorCategoriaImporte As Double, _
                                       ByVal fltVentaPorCategoriaImportePresupuesto As Double, _
                                       ByVal dtmVentaPorCategoriaRegistro As DateTime, _
                                       ByVal dtmVentaPorCategoriaUltimaModificacion As DateTime, _
                                       ByVal strVentaPorCategoriaModificadoPor As String, _
                                       ByVal strConnectionString As String) As Integer

        ' Member identifier
        Const MEMBER_NAME As String = "intEliminar"

        ' Declare the local variables
        Dim sqlStatementToBeExecuted As System.Text.StringBuilder
        Dim numberOfRowsDeleted As Integer
        Dim returnedData As Array

        Try

            ' Inicializamos las varialbes locales
            sqlStatementToBeExecuted = New System.Text.StringBuilder
            Call sqlStatementToBeExecuted.Append("EXECUTE spEliminartblVentaPorCategoria ")
            Call sqlStatementToBeExecuted.Append(intDivisionArticulosId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intCategoriaArticulosId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intVentaPorCategoriaId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intCompaniaId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intSucursalId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(fltVentaPorCategoriaImporte)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(fltVentaPorCategoriaImportePresupuesto)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmVentaPorCategoriaRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmVentaPorCategoriaUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strVentaPorCategoriaModificadoPor)
            Call sqlStatementToBeExecuted.Append("'")

            ' Execute the SQL statement
            returnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(sqlStatementToBeExecuted.ToString(), strConnectionString)
            sqlStatementToBeExecuted = Nothing

            ' Return the results
            If Not IsNothing(returnedData) AndAlso returnedData.Length > 0 Then
                numberOfRowsDeleted = CInt(DirectCast(returnedData.GetValue(0), SortedList).GetByIndex(0))
            End If

            returnedData = Nothing
            Return numberOfRowsDeleted

        Catch myException As Exception

            ' Declare the error variables
            Dim errorMessage As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim applicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim productName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName

            ' Create the error message
            Call errorMessage.Append("Product name:" & vbCrLf & vbTab & productName & "." & CLASS_NAME & "." & MEMBER_NAME & vbCrLf & vbCrLf)
            Call errorMessage.Append("Application name:" & vbCrLf & vbTab & System.Reflection.Assembly.GetExecutingAssembly.Location & vbCrLf & vbCrLf)
            Call errorMessage.Append("Version:" & vbCrLf & vbTab & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & vbCrLf & vbCrLf)
            Call errorMessage.Append("Source:" & vbCrLf & vbTab & myException.Source & vbCrLf & vbCrLf)
            Call errorMessage.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(Err.Number) & vbCrLf & vbCrLf)
            Call errorMessage.Append("Line number:" & vbCrLf & vbTab & Erl() & vbCrLf & vbCrLf)
            Call errorMessage.Append("Message:" & vbCrLf & vbTab & myException.Message & vbCrLf & vbCrLf)
            Call errorMessage.Append("SQLStatement:" & vbCrLf & vbTab & sqlStatementToBeExecuted.ToString() & vbCrLf & vbCrLf)
            Call errorMessage.Append("StackTrace:" & vbCrLf & myException.StackTrace & vbCrLf & vbCrLf)

            ' Create the event source
            If Not EventLog.SourceExists(productName) Then
                Call EventLog.CreateEventSource(productName, "Application")
            End If

            ' Set the event source
            applicationEventLog.Source = productName

            ' Write the event. It can be read in the Event Viewer.
            Call applicationEventLog.WriteEntry(errorMessage.ToString(), EventLogEntryType.Error, Err.Number, 0)

            ' Clear the variables
            sqlStatementToBeExecuted = Nothing
            returnedData = Nothing

            ' Raise the error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name          : strBuscar
    ' Description   : Returns an array of SortedList objects with the records found
    ' Table name    : tblVentaPorCategoria
    ' Parameters    : 
    '              ByVal intDivisionArticulosId As Integer
    '                  - 
    '              ByVal intCategoriaArticulosId As Integer
    '                  - 
    '              ByVal intVentaPorCategoriaId As Integer
    '                  - 
    '              ByVal intCompaniaId As Int32
    '                  - 
    '              ByVal intSucursalId As Int32
    '                  - 
    '              ByVal fltVentaPorCategoriaImporte As Double
    '                  - 
    '              ByVal fltVentaPorCategoriaImportePresupuesto As Double
    '                  - 
    '              ByVal dtmVentaPorCategoriaRegistro As DateTime
    '                  - 
    '              ByVal dtmVentaPorCategoriaUltimaModificacion As DateTime
    '                  - 
    '              ByVal strVentaPorCategoriaModificadoPor As String
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
    Public Shared Function strBuscar(ByVal intDivisionArticulosId As Integer, _
                                     ByVal intCategoriaArticulosId As Integer, _
                                     ByVal intVentaPorCategoriaId As Integer, _
                                     ByVal intCompaniaId As Int32, _
                                     ByVal intSucursalId As Int32, _
                                     ByVal fltVentaPorCategoriaImporte As Double, _
                                     ByVal fltVentaPorCategoriaImportePresupuesto As Double, _
                                     ByVal dtmVentaPorCategoriaRegistro As DateTime, _
                                     ByVal dtmVentaPorCategoriaUltimaModificacion As DateTime, _
                                     ByVal strVentaPorCategoriaModificadoPor As String, _
                                     ByVal intInitialPosition As Double, _
                                     ByVal intElementsToRetrieve As Double, _
                                     ByVal strConnectionString As String) As Array

        ' Member identifier
        Const MEMBER_NAME As String = "strBuscar"

        ' Declare the local variables
        Dim sqlStatementToBeExecuted As System.Text.StringBuilder
        Dim returnedData As Array

        Try

            ' Create the SQL statement
            sqlStatementToBeExecuted = New System.Text.StringBuilder
            Call sqlStatementToBeExecuted.Append("EXECUTE spBuscartblVentaPorCategoria ")
            Call sqlStatementToBeExecuted.Append(intDivisionArticulosId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intCategoriaArticulosId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intVentaPorCategoriaId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intCompaniaId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intSucursalId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(fltVentaPorCategoriaImporte)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(fltVentaPorCategoriaImportePresupuesto)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmVentaPorCategoriaRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmVentaPorCategoriaUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strVentaPorCategoriaModificadoPor)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intInitialPosition)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intElementsToRetrieve)

            ' Execute the SQL statement
            returnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(sqlStatementToBeExecuted.ToString(), strConnectionString)
            sqlStatementToBeExecuted = Nothing

            ' Return the results
            Return returnedData

        Catch myException As Exception

            ' Declare the error variables
            Dim errorMessage As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim applicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim productName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName

            ' Create the error message
            Call errorMessage.Append("Product name:" & vbCrLf & vbTab & productName & "." & CLASS_NAME & "." & MEMBER_NAME & vbCrLf & vbCrLf)
            Call errorMessage.Append("Application name:" & vbCrLf & vbTab & System.Reflection.Assembly.GetExecutingAssembly.Location & vbCrLf & vbCrLf)
            Call errorMessage.Append("Version:" & vbCrLf & vbTab & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & vbCrLf & vbCrLf)
            Call errorMessage.Append("Source:" & vbCrLf & vbTab & myException.Source & vbCrLf & vbCrLf)
            Call errorMessage.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(Err.Number) & vbCrLf & vbCrLf)
            Call errorMessage.Append("Line number:" & vbCrLf & vbTab & Erl() & vbCrLf & vbCrLf)
            Call errorMessage.Append("Message:" & vbCrLf & vbTab & myException.Message & vbCrLf & vbCrLf)
            Call errorMessage.Append("SQLStatement:" & vbCrLf & vbTab & sqlStatementToBeExecuted.ToString() & vbCrLf & vbCrLf)
            Call errorMessage.Append("StackTrace:" & vbCrLf & myException.StackTrace & vbCrLf & vbCrLf)

            ' Create the event source
            If Not EventLog.SourceExists(productName) Then
                Call EventLog.CreateEventSource(productName, "Application")
            End If

            ' Set the event source
            applicationEventLog.Source = productName

            ' Write the event. It can be read in the Event Viewer.
            Call applicationEventLog.WriteEntry(errorMessage.ToString(), EventLogEntryType.Error, Err.Number, 0)

            ' Clear the variables
            sqlStatementToBeExecuted = Nothing
            returnedData = Nothing

            ' Raise the error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name          : strBuscar
    ' Description   : Returns an array of SortedList objects with the records found
    ' Table name    : tblVentaPorCategoria
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
    Public Shared Function strBuscar(ByVal dtmStart As DateTime, _
                                     ByVal dtmEnd As DateTime, _
                                     ByVal strConnectionString As String) As Array

        ' Member identifier
        Const MEMBER_NAME As String = "strBuscar"

        ' Declare the local variables
        Dim sqlStatementToBeExecuted As System.Text.StringBuilder
        Dim returnedData As Array

        Try

            ' Inicializamos las varialbes locales
            sqlStatementToBeExecuted = New System.Text.StringBuilder

            ' Create the SQL statement
            sqlStatementToBeExecuted = New System.Text.StringBuilder
            Call sqlStatementToBeExecuted.Append("EXECUTE spBuscarCambiotblVentaPorCategoria ")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmStart.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmEnd.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call sqlStatementToBeExecuted.Append("'")

            ' Execute the SQL statement
            returnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(sqlStatementToBeExecuted.ToString(), strConnectionString)
            sqlStatementToBeExecuted = Nothing

            ' Return the results
            Return returnedData

        Catch myException As Exception

            ' Declare the error variables
            Dim errorMessage As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim applicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim productName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName

            ' Create the error message
            Call errorMessage.Append("Product name:" & vbCrLf & vbTab & productName & "." & CLASS_NAME & "." & MEMBER_NAME & vbCrLf & vbCrLf)
            Call errorMessage.Append("Application name:" & vbCrLf & vbTab & System.Reflection.Assembly.GetExecutingAssembly.Location & vbCrLf & vbCrLf)
            Call errorMessage.Append("Version:" & vbCrLf & vbTab & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & vbCrLf & vbCrLf)
            Call errorMessage.Append("Source:" & vbCrLf & vbTab & myException.Source & vbCrLf & vbCrLf)
            Call errorMessage.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(Err.Number) & vbCrLf & vbCrLf)
            Call errorMessage.Append("Line number:" & vbCrLf & vbTab & Erl() & vbCrLf & vbCrLf)
            Call errorMessage.Append("Message:" & vbCrLf & vbTab & myException.Message & vbCrLf & vbCrLf)
            Call errorMessage.Append("SQLStatement:" & vbCrLf & vbTab & sqlStatementToBeExecuted.ToString() & vbCrLf & vbCrLf)
            Call errorMessage.Append("StackTrace:" & vbCrLf & myException.StackTrace & vbCrLf & vbCrLf)

            ' Create the event source
            If Not EventLog.SourceExists(productName) Then
                Call EventLog.CreateEventSource(productName, "Application")
            End If

            ' Set the event source
            applicationEventLog.Source = productName

            ' Write the event. It can be read in the Event Viewer.
            Call applicationEventLog.WriteEntry(errorMessage.ToString(), EventLogEntryType.Error, Err.Number, 0)

            ' Clear the variables
            sqlStatementToBeExecuted = Nothing
            returnedData = Nothing

            ' Raise the error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name          : intActualizar
    ' Description   : Updates records and returns the number of updated items
    ' Table name    : tblVentaPorCategoria
    ' Parameters    : 
    '              ByVal intDivisionArticulosId As Integer
    '                  - 
    '              ByVal intCategoriaArticulosId As Integer
    '                  - 
    '              ByVal intVentaPorCategoriaId As Integer
    '                  - 
    '              ByVal intCompaniaId As Int32
    '                  - 
    '              ByVal intSucursalId As Int32
    '                  - 
    '              ByVal fltVentaPorCategoriaImporte As Double
    '                  - 
    '              ByVal fltVentaPorCategoriaImportePresupuesto As Double
    '                  - 
    '              ByVal dtmVentaPorCategoriaRegistro As DateTime
    '                  - 
    '              ByVal dtmVentaPorCategoriaUltimaModificacion As DateTime
    '                  - 
    '              ByVal strVentaPorCategoriaModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intActualizar(ByVal intDivisionArticulosId As Integer, _
                                         ByVal intCategoriaArticulosId As Integer, _
                                         ByVal intVentaPorCategoriaId As Integer, _
                                         ByVal intCompaniaId As Int32, _
                                         ByVal intSucursalId As Int32, _
                                         ByVal fltVentaPorCategoriaImporte As Double, _
                                         ByVal fltVentaPorCategoriaImportePresupuesto As Double, _
                                         ByVal dtmVentaPorCategoriaRegistro As DateTime, _
                                         ByVal dtmVentaPorCategoriaUltimaModificacion As DateTime, _
                                         ByVal strVentaPorCategoriaModificadoPor As String, _
                                         ByVal strConnectionString As String) As Integer

        ' Member identifier
        Const MEMBER_NAME As String = "intActualizar"

        ' Declare the local variables
        Dim sqlStatementToBeExecuted As System.Text.StringBuilder
        Dim numberOfRowsUpdated As Integer
        Dim returnedData As Array

        Try

            ' Create the SQL statement
            sqlStatementToBeExecuted = New System.Text.StringBuilder
            Call sqlStatementToBeExecuted.Append("EXECUTE spActualizartblVentaPorCategoria ")
            Call sqlStatementToBeExecuted.Append(intDivisionArticulosId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intCategoriaArticulosId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intVentaPorCategoriaId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intCompaniaId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intSucursalId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(fltVentaPorCategoriaImporte)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(fltVentaPorCategoriaImportePresupuesto)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmVentaPorCategoriaRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmVentaPorCategoriaUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strVentaPorCategoriaModificadoPor)
            Call sqlStatementToBeExecuted.Append("'")

            ' Execute the SQL statement
            returnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(sqlStatementToBeExecuted.ToString(), strConnectionString)
            sqlStatementToBeExecuted = Nothing

            ' Return the results
            If Not IsNothing(returnedData) AndAlso returnedData.Length > 0 Then
                numberOfRowsUpdated = CInt(DirectCast(returnedData.GetValue(0), SortedList).GetByIndex(0))
            End If

            returnedData = Nothing
            Return numberOfRowsUpdated

        Catch myException As Exception

            ' Declare the error variables
            Dim errorMessage As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim applicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim productName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName

            ' Create the error message
            Call errorMessage.Append("Product name:" & vbCrLf & vbTab & productName & "." & CLASS_NAME & "." & MEMBER_NAME & vbCrLf & vbCrLf)
            Call errorMessage.Append("Application name:" & vbCrLf & vbTab & System.Reflection.Assembly.GetExecutingAssembly.Location & vbCrLf & vbCrLf)
            Call errorMessage.Append("Version:" & vbCrLf & vbTab & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & vbCrLf & vbCrLf)
            Call errorMessage.Append("Source:" & vbCrLf & vbTab & myException.Source & vbCrLf & vbCrLf)
            Call errorMessage.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(Err.Number) & vbCrLf & vbCrLf)
            Call errorMessage.Append("Line number:" & vbCrLf & vbTab & Erl() & vbCrLf & vbCrLf)
            Call errorMessage.Append("Message:" & vbCrLf & vbTab & myException.Message & vbCrLf & vbCrLf)
            Call errorMessage.Append("SQLStatement:" & vbCrLf & vbTab & sqlStatementToBeExecuted.ToString() & vbCrLf & vbCrLf)
            Call errorMessage.Append("StackTrace:" & vbCrLf & myException.StackTrace & vbCrLf & vbCrLf)

            ' Create the event source
            If Not EventLog.SourceExists(productName) Then
                Call EventLog.CreateEventSource(productName, "Application")
            End If

            ' Set the event source
            applicationEventLog.Source = productName

            ' Write the event. It can be read in the Event Viewer.
            Call applicationEventLog.WriteEntry(errorMessage.ToString(), EventLogEntryType.Error, Err.Number, 0)

            ' Clear the variables
            sqlStatementToBeExecuted = Nothing
            returnedData = Nothing

            ' Raise the error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name          : strBuscarRango
    ' Description   : Returns an array of SortedList objects with the records found
    ' Table name    : tblVentaPorCategoria
    ' Parameters    : 
    '              ByVal intDivisionArticulosId As Integer
    '                  - 
    '              ByVal intCategoriaArticulosId As Integer
    '                  - 
    '              ByVal intVentaPorCategoriaId As Integer
    '                  - 
    '              ByVal intCompaniaId As Int32
    '                  - 
    '              ByVal intSucursalId As Int32
    '                  - 
    '              ByVal fltVentaPorCategoriaImporte As Double
    '                  - 
    '              ByVal fltVentaPorCategoriaImportePresupuesto As Double
    '                  - 
    '              ByVal dtmInicio As DateTime
    '                  - 
    '              ByVal dtmFin As DateTime
    '                  - 
    '              ByVal strVentaPorCategoriaModificadoPor As String
    '                  - 
    '              ByVal intInitialPosition As  Double
    '                 - Initial position
    '              ByVal intElementsToRetrieve As Double
    '                 - Number of elements per page
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Array

    Public Shared Function strBuscarRango(ByVal intDivisionArticulosId As Integer, _
                                                    ByVal intCategoriaArticulosId As Integer, _
                                                    ByVal intVentaPorCategoriaId As Integer, _
                                                    ByVal intCompaniaId As Int32, _
                                                    ByVal intSucursalId As Int32, _
                                                    ByVal fltVentaPorCategoriaImporte As Double, _
                                                    ByVal fltVentaPorCategoriaImportePresupuesto As Double, _
                                                    ByVal dtmInicio As DateTime, _
                                                    ByVal dtmFin As DateTime, _
                                                    ByVal strVentaPorCategoriaModificadoPor As String, _
                                                    ByVal intInitialPosition As Double, _
                                                    ByVal intElementsToRetrieve As Double, _
                                                    ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarRango"

        ' Variables locales
        Dim strSQLStatement As System.Text.StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarRangotblVentaPorCategoria ")
            Call strSQLStatement.Append(intDivisionArticulosId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCategoriaArticulosId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intVentaPorCategoriaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltVentaPorCategoriaImporte)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltVentaPorCategoriaImportePresupuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strVentaPorCategoriaModificadoPor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intInitialPosition)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intElementsToRetrieve)

            ' Ejecutamos el comando
            strBuscarRango = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

        Catch objException As Exception

            ' Variables locales
            Dim strErrorString As System.Text.StringBuilder : strErrorString = New System.Text.StringBuilder
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

            ' Creamos el mensaje de error
            Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & CLASS_NAME & "." & strmThisMemberName & vbCrLf & vbCrLf)
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
            strBuscarRango = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function


End Class
