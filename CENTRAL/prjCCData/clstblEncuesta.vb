
Imports System.Text
Imports Benavides.Data.SQL.MSSQL

  '====================================================================
  ' Class         : clstblEncuesta
  ' Title         : Grupo Benavides. Administrador POS y Backoffice.
  ' Description   : Store Procedure Mantenimiento Datos
  ' Copyright     : 2005 Todos los Derechos Reservados.
  ' Company       : Benavides
  ' Author        : Sistemas Benavides
  ' Version       : 1.0
  ' Last Modified : Monday, May 09, 2005
  '====================================================================
  Public NotInheritable Class clstblEncuesta
  
    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblEncuesta"
    
    ' Constructor en blanco para prevenir la generaci�n de un constructor por defecto
    Private Sub New()
    End Sub
    	
    '====================================================================
    ' Name       : intActualizar
    ' Description: Actualizaci�n de registros.
    '                 - Tabla tblEncuesta
    ' Parameters : 
    '              ByVal intEncuestaId As Double
    '                 - 
    '              ByVal strEncuestaNombre As String
    '                 - 
    '              ByVal strEncuestaDescripcion As String
    '                 - 
    '              ByVal dtmEncuestaInicio As Date
    '                 - 
    '              ByVal dtmEncuestaFin As Date
    '                 - 
    '              ByVal blnEncuestaObligatoria As boolean
    '                 - 
    '              ByVal blnEncuestaActivo As boolean
    '                 - 
    '              ByVal dtmEncuestaUltimaModificacion As Date
    '                 - 
    '              ByVal strEncuestaModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - N�mero de registros afectados por el comando
    '====================================================================
    Shared Function intActualizar( _
                ByVal intEncuestaId As Double, _
                ByVal strEncuestaNombre As String, _
                ByVal strEncuestaDescripcion As String, _
                ByVal dtmEncuestaInicio As Date, _
                ByVal dtmEncuestaFin As Date, _
                ByVal blnEncuestaObligatoria As Boolean, _
                ByVal blnEncuestaActivo As Boolean, _
                ByVal dtmEncuestaUltimaModificacion As Date, _
                ByVal strEncuestaModificadoPor As String, _
                ByVal strConnectionString As String) As Integer

        ' Member identifier
        Const strmThisMemberName As String = "intActualizar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRowsAffected As Integer
        Dim aobjReturnedData As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spActualizartblEncuesta ")
            Call strSQLStatement.Append(intEncuestaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEncuestaNombre)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEncuestaDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmEncuestaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmEncuestaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnEncuestaObligatoria))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnEncuestaActivo))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmEncuestaUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEncuestaModificadoPor)
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
    ' Description: Adici�n de registros.
    '                  - Tabla tblEncuesta
    ' Parameters : 
    '              ByVal intEncuestaId As Double
    '                  - 
    '              ByVal strEncuestaNombre As String
    '                  - 
    '              ByVal strEncuestaDescripcion As String
    '                  - 
    '              ByVal dtmEncuestaInicio As Date
    '                  - 
    '              ByVal dtmEncuestaFin As Date
    '                  - 
    '              ByVal blnEncuestaObligatoria As boolean
    '                  - 
    '              ByVal blnEncuestaActivo As boolean
    '                  - 
    '              ByVal dtmEncuestaUltimaModificacion As Date
    '                  - 
    '              ByVal strEncuestaModificadoPor As String
    '                  -       
    '              ByVal strConnectionString As String
    '                  - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - N�mero de registros afectados por el comando
    '====================================================================        
    Shared Function intAgregar( _
                ByVal intEncuestaId As Double, _
                ByVal strEncuestaNombre As String, _
                ByVal strEncuestaDescripcion As String, _
                ByVal dtmEncuestaInicio As Date, _
                ByVal dtmEncuestaFin As Date, _
                ByVal blnEncuestaObligatoria As Boolean, _
                ByVal blnEncuestaActivo As Boolean, _
                ByVal dtmEncuestaUltimaModificacion As Date, _
                ByVal strEncuestaModificadoPor As String, _
                ByVal strConnectionString As String) As Integer

        ' Member identifier
        Const strmThisMemberName As String = "intAgregar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRecordId As Integer
        Dim aobjReturnedData As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spAgregartblEncuesta ")
            Call strSQLStatement.Append(intEncuestaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEncuestaNombre)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEncuestaDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmEncuestaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmEncuestaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnEncuestaObligatoria))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnEncuestaActivo))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmEncuestaUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEncuestaModificadoPor)
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
    ' Description: B�squeda de registros.
    '                 - Tabla tblEncuesta
    ' Parameters : 
    '              ByVal intEncuestaId As Double
    '                 - 
    '              ByVal strEncuestaNombre As String
    '                 - 
    '              ByVal strEncuestaDescripcion As String
    '                 - 
    '              ByVal dtmEncuestaInicio As Date
    '                 - 
    '              ByVal dtmEncuestaFin As Date
    '                 - 
    '              ByVal blnEncuestaObligatoria As boolean
    '                 - 
    '              ByVal blnEncuestaActivo As boolean
    '                 - 
    '              ByVal dtmEncuestaUltimaModificacion As Date
    '                 - 
    '              ByVal strEncuestaModificadoPor As String
    '                 -       
    '              ByVal intPosicionInicial As  Double
    '                 - Inicio de registros
    '              ByVal intElementos As Double
    '                 - Numero de elementos por bloque  
    '              ByVal strConnectionString As String
    '                 - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '                 - Arreglo bidimensional con los registros le�dos
    '                   Array = { (c1,c2..cn), (c1,c2..cn) ... (c1,c2..cn) }
    '                   c = Campo
    '====================================================================
    Shared Function strBuscar( _
            ByVal intEncuestaId As Double, _
            ByVal strEncuestaNombre As String, _
            ByVal strEncuestaDescripcion As String, _
            ByVal dtmEncuestaInicio As Date, _
            ByVal dtmEncuestaFin As Date, _
            ByVal blnEncuestaObligatoria As Boolean, _
            ByVal blnEncuestaActivo As Boolean, _
            ByVal dtmEncuestaUltimaModificacion As Date, _
            ByVal strEncuestaModificadoPor As String, _
            ByVal intPosicionInicial As Double, _
            ByVal intElementos As Double, _
            ByVal strConnectionString As String) As Array

        ' Member identifier
        Const strmThisMemberName As String = "strBuscar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscartblEncuesta ")
            Call strSQLStatement.Append(intEncuestaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEncuestaNombre)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEncuestaDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmEncuestaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmEncuestaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnEncuestaObligatoria))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnEncuestaActivo))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmEncuestaUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEncuestaModificadoPor)
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
    ' Description: Eliminaci�n de registros.
    '                 - Tabla tblEncuesta
    ' Parameters : 
    '              ByVal intEncuestaId As Double
    '                 - 
    '              ByVal strEncuestaNombre As String
    '                 - 
    '              ByVal strEncuestaDescripcion As String
    '                 - 
    '              ByVal dtmEncuestaInicio As Date
    '                 - 
    '              ByVal dtmEncuestaFin As Date
    '                 - 
    '              ByVal blnEncuestaObligatoria As boolean
    '                 - 
    '              ByVal blnEncuestaActivo As boolean
    '                 - 
    '              ByVal dtmEncuestaUltimaModificacion As Date
    '                 - 
    '              ByVal strEncuestaModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - N�mero de registros afectados por el comando
    '====================================================================        
    Shared Function intEliminar( _
            ByVal intEncuestaId As Double, _
            ByVal strEncuestaNombre As String, _
            ByVal strEncuestaDescripcion As String, _
            ByVal dtmEncuestaInicio As Date, _
            ByVal dtmEncuestaFin As Date, _
            ByVal blnEncuestaObligatoria As Boolean, _
            ByVal blnEncuestaActivo As Boolean, _
            ByVal dtmEncuestaUltimaModificacion As Date, _
            ByVal strEncuestaModificadoPor As String, _
            ByVal strConnectionString As String) As Integer

        ' Member identifier
        Const strmThisMemberName As String = "intEliminar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRowsAffected As Integer
        Dim aobjReturnedData As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spEliminartblEncuesta ")
            Call strSQLStatement.Append(intEncuestaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEncuestaNombre)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEncuestaDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmEncuestaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmEncuestaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnEncuestaObligatoria))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnEncuestaActivo))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmEncuestaUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEncuestaModificadoPor)
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
    ' Table name    : tblEncuesta
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
            Call strSQLStatement.Append("EXECUTE spBuscarCambiotblEncuesta ")
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

End Class
    
