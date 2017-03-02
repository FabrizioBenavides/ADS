'====================================================================
' Class         : clstblDatoAdicionalDetalleTicket
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Store Procedure Mantenimiento Datos
' Copyright     : 2005 Todos los Derechos Reservados.
' Company       : Benavides
' Author        : Sistemas Benavides
' Version       : 1.0
' Last Modified : Martes, Octubre 18, 2005
'====================================================================
Public NotInheritable Class clstblDatoAdicionalDetalleTicket

    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblDatoAdicionalDetalleTicket"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()
    End Sub

    '====================================================================
    ' Name       : intActualizar
    ' Description: Actualización de registros.
    '                 - Tabla tblDatoAdicionalDetalleTicket
    ' Parameters : 
    '	ByVal intCompaniaId   As Integer  
    '	ByVal intSucursalId   As Integer  
    '	ByVal intTipoTicketId As Integer  
    '	ByVal intCajaId       As Integer  
    '	ByVal intEmpleadoId   As Integer  
    '	ByVal intEstadoOperativoCajaId As Integer 
    '	ByVal intTurnoLaboralId   As Integer  
    '	ByVal intAsignacionCajaId As Integer  
    '	ByVal intTicketId         As Integer  
    '	ByVal intArticuloId       As Integer  
    '	ByVal intDetalleTicketId  As Integer  
    '	ByVal strDatoAdicionalDetalleTicketNombreId As String
    '	ByVal strDatoAdicionalDetalleTicketValor    As String
    '	ByVal dtmDatoAdicionalDetalleTicketUltimaModificacion As Date
    '	ByVal strDatoAdicionalDetalleTicketModificadoPor As String       
    '   ByVal strConnectionString As String
    '
    '   - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================
    Public Shared Function intActualizar( _
    ByVal intCompaniaId As Integer, _
    ByVal intSucursalId As Integer, _
    ByVal intTipoTicketId As Integer, _
    ByVal intCajaId As Integer, _
    ByVal intEmpleadoId As Integer, _
    ByVal intEstadoOperativoCajaId As Integer, _
    ByVal intTurnoLaboralId As Integer, _
    ByVal intAsignacionCajaId As Integer, _
    ByVal intTicketId As Integer, _
    ByVal intArticuloId As Integer, _
    ByVal intDetalleTicketId As Integer, _
    ByVal strDatoAdicionalDetalleTicketNombreId As String, _
    ByVal strDatoAdicionalDetalleTicketValor As String, _
    ByVal dtmDatoAdicionalDetalleTicketUltimaModificacion As Date, _
    ByVal strDatoAdicionalDetalleTicketModificadoPor As String, _
    ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intActualizar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRowsAffected As Integer
        Dim aobjReturnedData As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spActualizartblDatoAdicionalDetalleTicket ")
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
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDetalleTicketId)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strDatoAdicionalDetalleTicketNombreId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strDatoAdicionalDetalleTicketValor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")


            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmDatoAdicionalDetalleTicketUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strDatoAdicionalDetalleTicketModificadoPor)
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
    ' Name       : intAgregar
    ' Description: Adición de registros.
    '                  - Tabla tblDatoAdicionalDetalleTicket
    ' Parameters : 
    '	ByVal intCompaniaId   As Integer  
    '	ByVal intSucursalId   As Integer  
    '	ByVal intTipoTicketId As Integer  
    '	ByVal intCajaId       As Integer  
    '	ByVal intEmpleadoId   As Integer  
    '	ByVal intEstadoOperativoCajaId As Integer 
    '	ByVal intTurnoLaboralId   As Integer  
    '	ByVal intAsignacionCajaId As Integer  
    '	ByVal intTicketId         As Integer  
    '	ByVal intArticuloId       As Integer  
    '	ByVal intDetalleTicketId  As Integer  
    '	ByVal strDatoAdicionalDetalleTicketNombreId As String
    '	ByVal strDatoAdicionalDetalleTicketValor    As String
    '	ByVal dtmDatoAdicionalDetalleTicketUltimaModificacion As Date
    '	ByVal strDatoAdicionalDetalleTicketModificadoPor As String       
    '   ByVal strConnectionString As String
    '   - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================        
    Shared Function intAgregar( _
    ByVal intCompaniaId As Integer, _
    ByVal intSucursalId As Integer, _
    ByVal intTipoTicketId As Integer, _
    ByVal intCajaId As Integer, _
    ByVal intEmpleadoId As Integer, _
    ByVal intEstadoOperativoCajaId As Integer, _
    ByVal intTurnoLaboralId As Integer, _
    ByVal intAsignacionCajaId As Integer, _
    ByVal intTicketId As Integer, _
    ByVal intArticuloId As Integer, _
    ByVal intDetalleTicketId As Integer, _
    ByVal strDatoAdicionalDetalleTicketNombreId As String, _
    ByVal strDatoAdicionalDetalleTicketValor As String, _
    ByVal dtmDatoAdicionalDetalleTicketUltimaModificacion As Date, _
    ByVal strDatoAdicionalDetalleTicketModificadoPor As String, _
        ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intAgregar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRecordId As Integer
        Dim aobjReturnedData As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spAgregartblDatoAdicionalDetalleTicket ")
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
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDetalleTicketId)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strDatoAdicionalDetalleTicketNombreId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strDatoAdicionalDetalleTicketValor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")


            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmDatoAdicionalDetalleTicketUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strDatoAdicionalDetalleTicketModificadoPor)
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
    ' Name       : strBuscar
    ' Description: Búsqueda de registros.
    '                 - Tabla tblDatoAdicionalDetalleTicket
    ' Parameters : 
    '	ByVal intCompaniaId   As Integer  
    '	ByVal intSucursalId   As Integer  
    '	ByVal intTipoTicketId As Integer  
    '	ByVal intCajaId       As Integer  
    '	ByVal intEmpleadoId   As Integer  
    '	ByVal intEstadoOperativoCajaId As Integer 
    '	ByVal intTurnoLaboralId   As Integer  
    '	ByVal intAsignacionCajaId As Integer  
    '	ByVal intTicketId         As Integer  
    '	ByVal intArticuloId       As Integer  
    '	ByVal intDetalleTicketId  As Integer  
    '	ByVal strDatoAdicionalDetalleTicketNombreId As String
    '	ByVal strDatoAdicionalDetalleTicketValor    As String
    '	ByVal dtmDatoAdicionalDetalleTicketUltimaModificacion As Date
    '	ByVal strDatoAdicionalDetalleTicketModificadoPor As String       
    '   ByVal strConnectionString As String
    '   - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '                 - Arreglo bidimensional con los registros leídos
    '                   Array = { (c1,c2..cn), (c1,c2..cn) ... (c1,c2..cn) }
    '                   c = Campo
    '====================================================================
    Shared Function strBuscar( _
    ByVal intCompaniaId As Integer, _
    ByVal intSucursalId As Integer, _
    ByVal intTipoTicketId As Integer, _
    ByVal intCajaId As Integer, _
    ByVal intEmpleadoId As Integer, _
    ByVal intEstadoOperativoCajaId As Integer, _
    ByVal intTurnoLaboralId As Integer, _
    ByVal intAsignacionCajaId As Integer, _
    ByVal intTicketId As Integer, _
    ByVal intArticuloId As Integer, _
    ByVal intDetalleTicketId As Integer, _
    ByVal strDatoAdicionalDetalleTicketNombreId As String, _
    ByVal strDatoAdicionalDetalleTicketValor As String, _
    ByVal dtmDatoAdicionalDetalleTicketUltimaModificacion As Date, _
    ByVal strDatoAdicionalDetalleTicketModificadoPor As String, _
    ByVal intPosicionInicial As Integer, _
    ByVal intElementos As Integer, _
    ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array


        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscartblDatoAdicionalDetalleTicket ")
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
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDetalleTicketId)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strDatoAdicionalDetalleTicketNombreId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strDatoAdicionalDetalleTicketValor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")


            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmDatoAdicionalDetalleTicketUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strDatoAdicionalDetalleTicketModificadoPor)
            Call strSQLStatement.Append("'")

            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intPosicionInicial)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intElementos)

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
    ' Name       : intEliminar
    ' Description: Eliminación de registros.
    '                 - Tabla tblDatoAdicionalDetalleTicket
    ' Parameters : 
    '	ByVal intCompaniaId   As Integer  
    '	ByVal intSucursalId   As Integer  
    '	ByVal intTipoTicketId As Integer  
    '	ByVal intCajaId       As Integer  
    '	ByVal intEmpleadoId   As Integer  
    '	ByVal intEstadoOperativoCajaId As Integer 
    '	ByVal intTurnoLaboralId   As Integer  
    '	ByVal intAsignacionCajaId As Integer  
    '	ByVal intTicketId         As Integer  
    '	ByVal intArticuloId       As Integer  
    '	ByVal intDetalleTicketId  As Integer  
    '	ByVal strDatoAdicionalDetalleTicketNombreId As String
    '	ByVal strDatoAdicionalDetalleTicketValor    As String
    '	ByVal dtmDatoAdicionalDetalleTicketUltimaModificacion As Date
    '	ByVal strDatoAdicionalDetalleTicketModificadoPor As String       
    '   ByVal strConnectionString As String
    '   - Cadena de conexión hacia el RDBMS
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================        
    Shared Function intEliminar( _
    ByVal intCompaniaId As Integer, _
    ByVal intSucursalId As Integer, _
    ByVal intTipoTicketId As Integer, _
    ByVal intCajaId As Integer, _
    ByVal intEmpleadoId As Integer, _
    ByVal intEstadoOperativoCajaId As Integer, _
    ByVal intTurnoLaboralId As Integer, _
    ByVal intAsignacionCajaId As Integer, _
    ByVal intTicketId As Integer, _
    ByVal intArticuloId As Integer, _
    ByVal intDetalleTicketId As Integer, _
    ByVal strDatoAdicionalDetalleTicketNombreId As String, _
    ByVal strDatoAdicionalDetalleTicketValor As String, _
    ByVal dtmDatoAdicionalDetalleTicketUltimaModificacion As Date, _
    ByVal strDatoAdicionalDetalleTicketModificadoPor As String, _
    ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intEliminar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRowsAffected As Integer
        Dim aobjReturnedData As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spEliminartblDatoAdicionalDetalleTicket ")
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
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDetalleTicketId)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strDatoAdicionalDetalleTicketNombreId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strDatoAdicionalDetalleTicketValor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")


            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmDatoAdicionalDetalleTicketUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strDatoAdicionalDetalleTicketModificadoPor)
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

