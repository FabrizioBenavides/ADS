﻿'====================================================================
' Class         : clstblOperacionDEX
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Operaciones con datos
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Joaquín Hdz. G. (joaquin@isocraft.com)
' Last Modified : Friday, May 06, 2005
'====================================================================
Public NotInheritable Class clstblOperacionDEX

    ' Class identifier
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblOperacionDEX"

    ' Class constructor
    Private Sub New()
        ' Empty constructor to avoid the creation of the default constructor
    End Sub

    '====================================================================
    ' Name          : intAgregar
    ' Description   : Adds a new record and returns its integer identifier
    ' Table name    : tblOperacionDEX
    ' Parameters    : 
    '              ByVal intCompaniaId As Int32
    '                  - 
    '              ByVal intSucursalId As Int32
    '                  - 
    '              ByVal intTipoTicketId As Int32
    '                  - 
    '              ByVal intCajaId As Int32
    '                  - 
    '              ByVal intEmpleadoId As Int32
    '                  - 
    '              ByVal intEstadoOperativoCajaId As Int32
    '                  - 
    '              ByVal intTurnoLaboralId As Int32
    '                  - 
    '              ByVal intAsignacionCajaId As Int32
    '                  - 
    '              ByVal intTicketId As Int32
    '                  - 
    '              ByVal intTipoOperacionDEXId As Decimal
    '                  - 
    '              ByVal intOperacionDEXId As Int32
    '                  - 
    '              ByVal strOperacionDEXClave As String
    '                  - 
    '              ByVal fltOperacionDEXImporte As Double
    '                  - 
    '              ByVal fltOperacionDEXComision As Double
    '                  - 
    '              ByVal fltOperacionDEXComisionImpuesto As Double
    '                  - 
    '              ByVal dtmOperacionDEXUltimaModificacion As DateTime
    '                  - 
    '              ByVal strOperacionDEXModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intAgregar( _
      ByVal intCompaniaId As Int32, _
      ByVal intSucursalId As Int32, _
      ByVal intTipoTicketId As Int32, _
      ByVal intCajaId As Int32, _
      ByVal intEmpleadoId As Int32, _
      ByVal intEstadoOperativoCajaId As Int32, _
      ByVal intTurnoLaboralId As Int32, _
      ByVal intAsignacionCajaId As Int32, _
      ByVal intTicketId As Int32, _
      ByVal intTipoOperacionDEXId As Decimal, _
      ByVal intOperacionDEXId As Int32, _
      ByVal strOperacionDEXClave As String, _
      ByVal fltOperacionDEXImporte As Double, _
      ByVal fltOperacionDEXComision As Double, _
      ByVal fltOperacionDEXComisionImpuesto As Double, _
      ByVal dtmOperacionDEXUltimaModificacion As DateTime, _
      ByVal strOperacionDEXModificadoPor As String, _
      ByVal strConnectionString As String) As integer

        ' Member identifier
        Const strmThisMemberName As String = "intAgregar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRecordId As Integer
        Dim aobjReturnedData As Array

        Try

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spAgregartblOperacionDEX ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEstadoOperativoCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTurnoLaboralId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intAsignacionCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoOperacionDEXId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intOperacionDEXId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strOperacionDEXClave)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOperacionDEXImporte)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOperacionDEXComision)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOperacionDEXComisionImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmOperacionDEXUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strOperacionDEXModificadoPor)
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
    ' Table name    : tblOperacionDEX
    ' Parameters    : 
    '              ByVal intCompaniaId As Int32
    '                  - 
    '              ByVal intSucursalId As Int32
    '                  - 
    '              ByVal intTipoTicketId As Int32
    '                  - 
    '              ByVal intCajaId As Int32
    '                  - 
    '              ByVal intEmpleadoId As Int32
    '                  - 
    '              ByVal intEstadoOperativoCajaId As Int32
    '                  - 
    '              ByVal intTurnoLaboralId As Int32
    '                  - 
    '              ByVal intAsignacionCajaId As Int32
    '                  - 
    '              ByVal intTicketId As Int32
    '                  - 
    '              ByVal intTipoOperacionDEXId As Decimal
    '                  - 
    '              ByVal intOperacionDEXId As Int32
    '                  - 
    '              ByVal strOperacionDEXClave As String
    '                  - 
    '              ByVal fltOperacionDEXImporte As Double
    '                  - 
    '              ByVal fltOperacionDEXComision As Double
    '                  - 
    '              ByVal fltOperacionDEXComisionImpuesto As Double
    '                  - 
    '              ByVal dtmOperacionDEXUltimaModificacion As DateTime
    '                  - 
    '              ByVal strOperacionDEXModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intEliminar( _
      ByVal intCompaniaId As Int32, _
      ByVal intSucursalId As Int32, _
      ByVal intTipoTicketId As Int32, _
      ByVal intCajaId As Int32, _
      ByVal intEmpleadoId As Int32, _
      ByVal intEstadoOperativoCajaId As Int32, _
      ByVal intTurnoLaboralId As Int32, _
      ByVal intAsignacionCajaId As Int32, _
      ByVal intTicketId As Int32, _
      ByVal intTipoOperacionDEXId As Decimal, _
      ByVal intOperacionDEXId As Int32, _
      ByVal strOperacionDEXClave As String, _
      ByVal fltOperacionDEXImporte As Double, _
      ByVal fltOperacionDEXComision As Double, _
      ByVal fltOperacionDEXComisionImpuesto As Double, _
      ByVal dtmOperacionDEXUltimaModificacion As DateTime, _
      ByVal strOperacionDEXModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spEliminartblOperacionDEX ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEstadoOperativoCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTurnoLaboralId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intAsignacionCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoOperacionDEXId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intOperacionDEXId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strOperacionDEXClave)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOperacionDEXImporte)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOperacionDEXComision)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOperacionDEXComisionImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmOperacionDEXUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strOperacionDEXModificadoPor)
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
    ' Table name    : tblOperacionDEX
    ' Parameters    : 
    '              ByVal intCompaniaId As Int32
    '                  - 
    '              ByVal intSucursalId As Int32
    '                  - 
    '              ByVal intTipoTicketId As Int32
    '                  - 
    '              ByVal intCajaId As Int32
    '                  - 
    '              ByVal intEmpleadoId As Int32
    '                  - 
    '              ByVal intEstadoOperativoCajaId As Int32
    '                  - 
    '              ByVal intTurnoLaboralId As Int32
    '                  - 
    '              ByVal intAsignacionCajaId As Int32
    '                  - 
    '              ByVal intTicketId As Int32
    '                  - 
    '              ByVal intTipoOperacionDEXId As Decimal
    '                  - 
    '              ByVal intOperacionDEXId As Int32
    '                  - 
    '              ByVal strOperacionDEXClave As String
    '                  - 
    '              ByVal fltOperacionDEXImporte As Double
    '                  - 
    '              ByVal fltOperacionDEXComision As Double
    '                  - 
    '              ByVal fltOperacionDEXComisionImpuesto As Double
    '                  - 
    '              ByVal dtmOperacionDEXUltimaModificacion As DateTime
    '                  - 
    '              ByVal strOperacionDEXModificadoPor As String
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
      ByVal intCompaniaId As Int32, _
      ByVal intSucursalId As Int32, _
      ByVal intTipoTicketId As Int32, _
      ByVal intCajaId As Int32, _
      ByVal intEmpleadoId As Int32, _
      ByVal intEstadoOperativoCajaId As Int32, _
      ByVal intTurnoLaboralId As Int32, _
      ByVal intAsignacionCajaId As Int32, _
      ByVal intTicketId As Int32, _
      ByVal intTipoOperacionDEXId As Decimal, _
      ByVal intOperacionDEXId As Int32, _
      ByVal strOperacionDEXClave As String, _
      ByVal fltOperacionDEXImporte As Double, _
      ByVal fltOperacionDEXComision As Double, _
      ByVal fltOperacionDEXComisionImpuesto As Double, _
      ByVal dtmOperacionDEXUltimaModificacion As DateTime, _
      ByVal strOperacionDEXModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spBuscartblOperacionDEX ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEstadoOperativoCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTurnoLaboralId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intAsignacionCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoOperacionDEXId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intOperacionDEXId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strOperacionDEXClave)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOperacionDEXImporte)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOperacionDEXComision)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOperacionDEXComisionImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmOperacionDEXUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strOperacionDEXModificadoPor)
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
    ' Table name    : tblOperacionDEX
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
            Call strSQLStatement.Append("EXECUTE spBuscarCambiotblOperacionDEX ")
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
    ' Table name    : tblOperacionDEX
    ' Parameters    : 
    '              ByVal intCompaniaId As Int32
    '                  - 
    '              ByVal intSucursalId As Int32
    '                  - 
    '              ByVal intTipoTicketId As Int32
    '                  - 
    '              ByVal intCajaId As Int32
    '                  - 
    '              ByVal intEmpleadoId As Int32
    '                  - 
    '              ByVal intEstadoOperativoCajaId As Int32
    '                  - 
    '              ByVal intTurnoLaboralId As Int32
    '                  - 
    '              ByVal intAsignacionCajaId As Int32
    '                  - 
    '              ByVal intTicketId As Int32
    '                  - 
    '              ByVal intTipoOperacionDEXId As Decimal
    '                  - 
    '              ByVal intOperacionDEXId As Int32
    '                  - 
    '              ByVal strOperacionDEXClave As String
    '                  - 
    '              ByVal fltOperacionDEXImporte As Double
    '                  - 
    '              ByVal fltOperacionDEXComision As Double
    '                  - 
    '              ByVal fltOperacionDEXComisionImpuesto As Double
    '                  - 
    '              ByVal dtmOperacionDEXUltimaModificacion As DateTime
    '                  - 
    '              ByVal strOperacionDEXModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intActualizar( _
      ByVal intCompaniaId As Int32, _
      ByVal intSucursalId As Int32, _
      ByVal intTipoTicketId As Int32, _
      ByVal intCajaId As Int32, _
      ByVal intEmpleadoId As Int32, _
      ByVal intEstadoOperativoCajaId As Int32, _
      ByVal intTurnoLaboralId As Int32, _
      ByVal intAsignacionCajaId As Int32, _
      ByVal intTicketId As Int32, _
      ByVal intTipoOperacionDEXId As Decimal, _
      ByVal intOperacionDEXId As Int32, _
      ByVal strOperacionDEXClave As String, _
      ByVal fltOperacionDEXImporte As Double, _
      ByVal fltOperacionDEXComision As Double, _
      ByVal fltOperacionDEXComisionImpuesto As Double, _
      ByVal dtmOperacionDEXUltimaModificacion As DateTime, _
      ByVal strOperacionDEXModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spActualizartblOperacionDEX ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEstadoOperativoCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTurnoLaboralId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intAsignacionCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoOperacionDEXId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intOperacionDEXId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strOperacionDEXClave)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOperacionDEXImporte)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOperacionDEXComision)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOperacionDEXComisionImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmOperacionDEXUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strOperacionDEXModificadoPor)
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
