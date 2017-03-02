
'====================================================================
' Class         : clstblFacturaElectronicaGlobalSucursal
' Title         : Benavides Enterprise Retail System
' Description   : Data maintenance
' Copyright     : (c) Isocraft 2007 - 2012. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Joaquin Hdz. G. (joaquin@isocraft.com)
' Last Modified : Friday, September 07, 2007
'====================================================================
Public NotInheritable Class clstblFacturaElectronicaGlobalSucursal

    ' Class identifier
    Private Const CLASS_NAME As String = "Benavides.CC.Data.clstblFacturaElectronicaGlobalSucursal"

    ' Class constructor
    Private Sub New()

        ' Empty constructor to avoid the creation of the default constructor

    End Sub

    '====================================================================
    ' Name          : intAgregar
    ' Description   : Adds a new record and returns its integer identifier
    ' Table name    : tblFacturaElectronicaGlobalSucursal
    ' Parameters    : 
    '              ByVal intCompaniaId As Int32
    '                  - 
    '              ByVal intSucursalId As Int32
    '                  - 
    '              ByVal dtmFacturaElectronicaGlobalSucursalCreacion As DateTime
    '                  - 
    '              ByVal fltFacturaElectronicaGlobalSucursalMonto As Double
    '                  - 
    '              ByVal dtmFacturaElectronicaGlobalSucursalUltimaModificacion As DateTime
    '                  - 
    '              ByVal strFacturaElectronicaGlobalSucursalModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intAgregar( _
       ByVal intCompaniaId As Int32, _
       ByVal intSucursalId As Int32, _
       ByVal dtmFacturaElectronicaGlobalSucursalFechaVenta As DateTime, _
       ByVal fltFacturaElectronicaGlobalSucursalImpuestoAplicado As Double, _
       ByVal fltFacturaElectronicaGlobalSucursalTotalExcento As Double, _
       ByVal fltFacturaElectronicaGlobalSucursalSubTotalGravado As Double, _
       ByVal fltFacturaElectronicaGlobalSucursalImporteImpuesto As Double, _
       ByVal fltFacturaElectronicaGlobalSucursalTotalGravado As Double, _
       ByVal dtmFacturaElectronicaGlobalSucursalUltimaModificacion As DateTime, _
       ByVal strFacturaElectronicaGlobalSucursalModificadoPor As String, _
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
            Call sqlStatementToBeExecuted.Append("EXECUTE spAgregartblFacturaElectronicaGlobalSucursal ")

            Call sqlStatementToBeExecuted.Append(intCompaniaId)
            Call sqlStatementToBeExecuted.Append(",")

            Call sqlStatementToBeExecuted.Append(intSucursalId)
            Call sqlStatementToBeExecuted.Append(",")

            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmFacturaElectronicaGlobalSucursalFechaVenta.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")

            Call sqlStatementToBeExecuted.Append(fltFacturaElectronicaGlobalSucursalImpuestoAplicado)
            Call sqlStatementToBeExecuted.Append(",")

            Call sqlStatementToBeExecuted.Append(fltFacturaElectronicaGlobalSucursalTotalExcento)
            Call sqlStatementToBeExecuted.Append(",")

            Call sqlStatementToBeExecuted.Append(fltFacturaElectronicaGlobalSucursalSubTotalGravado)
            Call sqlStatementToBeExecuted.Append(",")

            Call sqlStatementToBeExecuted.Append(fltFacturaElectronicaGlobalSucursalImporteImpuesto)
            Call sqlStatementToBeExecuted.Append(",")

            Call sqlStatementToBeExecuted.Append(fltFacturaElectronicaGlobalSucursalTotalGravado)
            Call sqlStatementToBeExecuted.Append(",")

            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmFacturaElectronicaGlobalSucursalUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")

            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalSucursalModificadoPor)
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
    ' Name          : intActualizar
    ' Description   : Updates records and returns the number of updated items
    ' Table name    : tblFacturaElectronicaGlobalSucursal
    ' Parameters    : 
    '              ByVal intCompaniaId As Int32
    '                  - 
    '              ByVal intSucursalId As Int32
    '                  - 
    '              ByVal dtmFacturaElectronicaGlobalSucursalCreacion As DateTime
    '                  - 
    '              ByVal fltFacturaElectronicaGlobalSucursalMonto As Double
    '                  - 
    '              ByVal dtmFacturaElectronicaGlobalSucursalUltimaModificacion As DateTime
    '                  - 
    '              ByVal strFacturaElectronicaGlobalSucursalModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================


    Public Shared Function intActualizar( _
       ByVal intCompaniaId As Int32, _
       ByVal intSucursalId As Int32, _
       ByVal dtmFacturaElectronicaGlobalSucursalFechaVenta As DateTime, _
       ByVal fltFacturaElectronicaGlobalSucursalImpuestoAplicado As Double, _
       ByVal fltFacturaElectronicaGlobalSucursalTotalExcento As Double, _
       ByVal fltFacturaElectronicaGlobalSucursalSubTotalGravado As Double, _
       ByVal fltFacturaElectronicaGlobalSucursalImporteImpuesto As Double, _
       ByVal fltFacturaElectronicaGlobalSucursalTotalGravado As Double, _
       ByVal dtmFacturaElectronicaGlobalSucursalUltimaModificacion As DateTime, _
       ByVal strFacturaElectronicaGlobalSucursalModificadoPor As String, _
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
            Call sqlStatementToBeExecuted.Append("EXECUTE spActualizartblFacturaElectronicaGlobalSucursal ")

            Call sqlStatementToBeExecuted.Append(intCompaniaId)
            Call sqlStatementToBeExecuted.Append(",")

            Call sqlStatementToBeExecuted.Append(intSucursalId)
            Call sqlStatementToBeExecuted.Append(",")

            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmFacturaElectronicaGlobalSucursalFechaVenta.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")

            Call sqlStatementToBeExecuted.Append(fltFacturaElectronicaGlobalSucursalImpuestoAplicado)
            Call sqlStatementToBeExecuted.Append(",")

            Call sqlStatementToBeExecuted.Append(fltFacturaElectronicaGlobalSucursalTotalExcento)
            Call sqlStatementToBeExecuted.Append(",")

            Call sqlStatementToBeExecuted.Append(fltFacturaElectronicaGlobalSucursalSubTotalGravado)
            Call sqlStatementToBeExecuted.Append(",")

            Call sqlStatementToBeExecuted.Append(fltFacturaElectronicaGlobalSucursalImporteImpuesto)
            Call sqlStatementToBeExecuted.Append(",")

            Call sqlStatementToBeExecuted.Append(fltFacturaElectronicaGlobalSucursalTotalGravado)
            Call sqlStatementToBeExecuted.Append(",")

            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmFacturaElectronicaGlobalSucursalUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")

            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalSucursalModificadoPor)
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

End Class
