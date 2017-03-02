
Imports System.Text
Imports Benavides.Data.SQL.MSSQL


  '====================================================================
  ' Class         : clstblDetalleSucursalEncuesta
  ' Title         : Grupo Benavides. Administrador POS y Backoffice.
  ' Description   : Store Procedure Mantenimiento Datos
  ' Copyright     : 2005 Todos los Derechos Reservados.
  ' Company       : Benavides
  ' Author        : Sistemas Benavides
  ' Version       : 1.0
  ' Last Modified : Monday, May 09, 2005
  '====================================================================
  Public NotInheritable Class clstblDetalleSucursalEncuesta
  
    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblDetalleSucursalEncuesta"
    
    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()
    End Sub
    	
    '====================================================================
    ' Name       : intActualizar
    ' Description: Actualización de registros.
    '                 - Tabla tblDetalleSucursalEncuesta
    ' Parameters : 
    '              ByVal intRespuestaId As Double
    '                 - 
    '              ByVal intPreguntaId As Double
    '                 - 
    '              ByVal intEncuestaId As Double
    '                 - 
    '              ByVal intCompaniaId As Double
    '                 - 
    '              ByVal intSucursalId As Double
    '                 - 
    '              ByVal intCajaId As Double
    '                 - 
    '              ByVal intEmpleadoId As Double
    '                 - 
    '              ByVal intEstadoOperativoCajaId As Double
    '                 - 
    '              ByVal intTurnoLaboralId As Double
    '                 - 
    '              ByVal intAsignacionCajaId As Double
    '                 - 
    '              ByVal intTicketId As Double
    '                 - 
    '              ByVal dtmRegistroEncuesta As Date
    '                 - 
    '              ByVal dtmDetalleSucursalEncuestaUltimaModificacion As Date
    '                 - 
    '              ByVal strDetalleSucursalEncuestaModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================
    Shared Function intActualizar( _ 
                ByVal intRespuestaId As Double, _
                ByVal intPreguntaId As Double, _
                ByVal intEncuestaId As Double, _
                ByVal intCompaniaId As Double, _
                ByVal intSucursalId As Double, _
                ByVal intCajaId As Double, _
                ByVal intEmpleadoId As Double, _
                ByVal intEstadoOperativoCajaId As Double, _
                ByVal intTurnoLaboralId As Double, _
                ByVal intAsignacionCajaId As Double, _
                ByVal intTicketId As Double, _
                ByVal dtmRegistroEncuesta As Date, _
                ByVal dtmDetalleSucursalEncuestaUltimaModificacion As Date, _
                ByVal strDetalleSucursalEncuestaModificadoPor As String, _
                ByVal strConnectionString As String) As Integer
                	
        ' Member identifier
        Const strmThisMemberName As String = "intActualizar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRowsAffected As Integer
        Dim aobjReturnedData As Array
            
            Try            
                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder()

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spActualizartblDetalleSucursalEncuesta ")
                Call strSQLStatement.Append(intRespuestaId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intPreguntaId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intEncuestaId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intCompaniaId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intSucursalId)
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
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmRegistroEncuesta.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmDetalleSucursalEncuestaUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strDetalleSucursalEncuestaModificadoPor)
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
    '                  - Tabla tblDetalleSucursalEncuesta
    ' Parameters : 
    '              ByVal intRespuestaId As Double
    '                  - 
    '              ByVal intPreguntaId As Double
    '                  - 
    '              ByVal intEncuestaId As Double
    '                  - 
    '              ByVal intCompaniaId As Double
    '                  - 
    '              ByVal intSucursalId As Double
    '                  - 
    '              ByVal intCajaId As Double
    '                  - 
    '              ByVal intEmpleadoId As Double
    '                  - 
    '              ByVal intEstadoOperativoCajaId As Double
    '                  - 
    '              ByVal intTurnoLaboralId As Double
    '                  - 
    '              ByVal intAsignacionCajaId As Double
    '                  - 
    '              ByVal intTicketId As Double
    '                  - 
    '              ByVal dtmRegistroEncuesta As Date
    '                  - 
    '              ByVal dtmDetalleSucursalEncuestaUltimaModificacion As Date
    '                  - 
    '              ByVal strDetalleSucursalEncuestaModificadoPor As String
    '                  -       
    '              ByVal strConnectionString As String
    '                  - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================        
    Shared Function intAgregar( _
                ByVal intRespuestaId AS Double, _
                ByVal intPreguntaId AS Double, _
                ByVal intEncuestaId AS Double, _
                ByVal intCompaniaId AS Double, _
                ByVal intSucursalId AS Double, _
                ByVal intCajaId AS Double, _
                ByVal intEmpleadoId AS Double, _
                ByVal intEstadoOperativoCajaId AS Double, _
                ByVal intTurnoLaboralId AS Double, _
                ByVal intAsignacionCajaId AS Double, _
                ByVal intTicketId AS Double, _
                ByVal dtmRegistroEncuesta AS Date, _
                ByVal dtmDetalleSucursalEncuestaUltimaModificacion AS Date, _
                ByVal strDetalleSucursalEncuestaModificadoPor AS String, _
                ByVal strConnectionString As String) as integer
            
        ' Member identifier
        Const strmThisMemberName As String = "intAgregar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRecordId As Integer
        Dim aobjReturnedData As Array
            
            Try
                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder()

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spAgregartblDetalleSucursalEncuesta ")
                Call strSQLStatement.Append(intRespuestaId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intPreguntaId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intEncuestaId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intCompaniaId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intSucursalId)
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
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmRegistroEncuesta.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmDetalleSucursalEncuestaUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strDetalleSucursalEncuestaModificadoPor)
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
    '                 - Tabla tblDetalleSucursalEncuesta
    ' Parameters : 
    '              ByVal intRespuestaId As Double
    '                 - 
    '              ByVal intPreguntaId As Double
    '                 - 
    '              ByVal intEncuestaId As Double
    '                 - 
    '              ByVal intCompaniaId As Double
    '                 - 
    '              ByVal intSucursalId As Double
    '                 - 
    '              ByVal intCajaId As Double
    '                 - 
    '              ByVal intEmpleadoId As Double
    '                 - 
    '              ByVal intEstadoOperativoCajaId As Double
    '                 - 
    '              ByVal intTurnoLaboralId As Double
    '                 - 
    '              ByVal intAsignacionCajaId As Double
    '                 - 
    '              ByVal intTicketId As Double
    '                 - 
    '              ByVal dtmRegistroEncuesta As Date
    '                 - 
    '              ByVal dtmDetalleSucursalEncuestaUltimaModificacion As Date
    '                 - 
    '              ByVal strDetalleSucursalEncuestaModificadoPor As String
    '                 -       
    '              ByVal intPosicionInicial As  Double
    '                 - Inicio de registros
    '              ByVal intElementos As Double
    '                 - Numero de elementos por bloque  
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '                 - Arreglo bidimensional con los registros leídos
    '                   Array = { (c1,c2..cn), (c1,c2..cn) ... (c1,c2..cn) }
    '                   c = Campo
    '====================================================================
    Shared Function strBuscar( _
            ByVal intRespuestaId AS Double, _
            ByVal intPreguntaId AS Double, _
            ByVal intEncuestaId AS Double, _
            ByVal intCompaniaId AS Double, _
            ByVal intSucursalId AS Double, _
            ByVal intCajaId AS Double, _
            ByVal intEmpleadoId AS Double, _
            ByVal intEstadoOperativoCajaId AS Double, _
            ByVal intTurnoLaboralId AS Double, _
            ByVal intAsignacionCajaId AS Double, _
            ByVal intTicketId AS Double, _
            ByVal dtmRegistroEncuesta AS Date, _
            ByVal dtmDetalleSucursalEncuestaUltimaModificacion AS Date, _
            ByVal strDetalleSucursalEncuestaModificadoPor AS String, _
            ByVal intPosicionInicial As  Double, _
            ByVal intElementos As Double, _
            ByVal strConnectionString As String) As Array
            
        ' Member identifier
        Const strmThisMemberName As String = "strBuscar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array
            
            Try
                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder()

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spBuscartblDetalleSucursalEncuesta ")
                Call strSQLStatement.Append(intRespuestaId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intPreguntaId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intEncuestaId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intCompaniaId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intSucursalId)
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
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmRegistroEncuesta.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmDetalleSucursalEncuestaUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strDetalleSucursalEncuestaModificadoPor)
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
    '                 - Tabla tblDetalleSucursalEncuesta
    ' Parameters : 
    '              ByVal intRespuestaId As Double
    '                 - 
    '              ByVal intPreguntaId As Double
    '                 - 
    '              ByVal intEncuestaId As Double
    '                 - 
    '              ByVal intCompaniaId As Double
    '                 - 
    '              ByVal intSucursalId As Double
    '                 - 
    '              ByVal intCajaId As Double
    '                 - 
    '              ByVal intEmpleadoId As Double
    '                 - 
    '              ByVal intEstadoOperativoCajaId As Double
    '                 - 
    '              ByVal intTurnoLaboralId As Double
    '                 - 
    '              ByVal intAsignacionCajaId As Double
    '                 - 
    '              ByVal intTicketId As Double
    '                 - 
    '              ByVal dtmRegistroEncuesta As Date
    '                 - 
    '              ByVal dtmDetalleSucursalEncuestaUltimaModificacion As Date
    '                 - 
    '              ByVal strDetalleSucursalEncuestaModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================        
    Shared Function intEliminar( _ 
            ByVal intRespuestaId As Double, _ 
            ByVal intPreguntaId As Double, _ 
            ByVal intEncuestaId As Double, _ 
            ByVal intCompaniaId As Double, _ 
            ByVal intSucursalId As Double, _ 
            ByVal intCajaId As Double, _ 
            ByVal intEmpleadoId As Double, _ 
            ByVal intEstadoOperativoCajaId As Double, _ 
            ByVal intTurnoLaboralId As Double, _ 
            ByVal intAsignacionCajaId As Double, _ 
            ByVal intTicketId As Double, _ 
            ByVal dtmRegistroEncuesta As Date, _ 
            ByVal dtmDetalleSucursalEncuestaUltimaModificacion As Date, _ 
            ByVal strDetalleSucursalEncuestaModificadoPor As String, _ 
            ByVal strConnectionString As String) As Integer

        ' Member identifier
        Const strmThisMemberName As String = "intEliminar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRowsAffected As Integer
        Dim aobjReturnedData As Array

            Try
                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder()

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spEliminartblDetalleSucursalEncuesta ")
                Call strSQLStatement.Append(intRespuestaId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intPreguntaId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intEncuestaId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intCompaniaId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intSucursalId)
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
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmRegistroEncuesta.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmDetalleSucursalEncuestaUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strDetalleSucursalEncuestaModificadoPor)
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
    
