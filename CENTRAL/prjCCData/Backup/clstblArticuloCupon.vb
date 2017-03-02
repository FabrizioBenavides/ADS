
Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clstblArticuloCupon
' Title         : Grupo Benavides. Administrador POS y Backoffice. 
' Description   : Mantenimiento de Tablas.
' Copyright     : 2004 Todos los Derechos Reservados.
' Company       : Dirección de Tecnología
' Author        : Isocraft S.A. de C.V.
' Version       : 1.0
' Last Modified : Wednesday, November 24, 2005
'====================================================================
Public NotInheritable Class clstblArticuloCupon

    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblArticuloCupon"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()

    End Sub

    '====================================================================
    ' Name       : intActualizar
    ' Description: Actualización de registros.
    '                 - Tabla tblArticuloCupon
    ' Parameters : 
    '              ByVal intArticuloId As Double
    '                 - 
    '              ByVal intCuponId As Double
    '                 - 
    '              ByVal dtmArticuloCuponUltimaModificacion As Date
    '                 - 
    '              ByVal strArticuloCuponModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================
    'Public Shared Function intActualizar( _
    '            ByVal intArticuloId As Double, _
    '            ByVal intCuponId As Double, _
    '            ByVal dtmArticuloCuponUltimaModificacion As Date, _
    '            ByVal strArticuloCuponModificadoPor As String, _
    '            ByVal strConnectionString As String) As Integer

    '    ' Constantes locales
    '    Const strmThisMemberName As String = "intActualizar"

    '    ' Variables locales
    '    Dim strSQLStatement As StringBuilder = Nothing
    '    Dim intRowsAffected As Integer = 0, strRowsAffected As String(), strRegistros As Array

    '    Try
    '        ' Inicializamos las varialbes locales
    '        strSQLStatement = New StringBuilder

    '        ' Creamos es estatuto de SQL
    '        Call strSQLStatement.Append("EXECUTE spActualizartblArticuloCupon ")
    '        Call strSQLStatement.Append(intArticuloId)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(intCuponId)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(dtmArticuloCuponUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(strArticuloCuponModificadoPor)
    '        Call strSQLStatement.Append("'")

    '        ' Ejecutamos el comando
    '        strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
    '        For Each strRowsAffected In strRegistros
    '            intRowsAffected = CInt(strRowsAffected.GetValue(0))
    '        Next

    '        ' Regresamos la información
    '        strSQLStatement = Nothing
    '        intActualizar = intRowsAffected

    '    Catch objException As Exception

    '        ' Variables locales
    '        Dim strErrorString As StringBuilder : strErrorString = New StringBuilder
    '        Dim objApplicationEventLog As System.Diagnostics.EventLog : objApplicationEventLog = New System.Diagnostics.EventLog
    '        Dim strProductName As String : strProductName = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
    '        Dim strApplicationName As String : strApplicationName = System.Reflection.Assembly.GetExecutingAssembly.Location
    '        Dim strVersion As String : strVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
    '        Dim strSource As String : strSource = objException.Source
    '        Dim strMessage As String : strMessage = objException.Message
    '        Dim strStackTrace As String : strStackTrace = objException.StackTrace
    '        Dim intLineNumber As Integer : intLineNumber = Erl()
    '        Dim intErrorNumber As Integer : intErrorNumber = Err.Number
    '        Dim intCategoryNumber As Short : intCategoryNumber = 100

    '        ' Creamos el mensaje de error
    '        Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Application name:" & vbCrLf & vbTab & strApplicationName & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Version:" & vbCrLf & vbTab & strVersion & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Source:" & vbCrLf & vbTab & strSource & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(intErrorNumber) & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Line number:" & vbCrLf & vbTab & intLineNumber & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Message:" & vbCrLf & vbTab & strMessage & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("SQLStatement:" & vbCrLf & vbTab & strSQLStatement.ToString() & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("StackTrace:" & vbCrLf & strStackTrace & vbCrLf & vbCrLf)

    '        ' Creamos un evento para registrar el mensaje de error
    '        If Not EventLog.SourceExists(strProductName) Then
    '            Call EventLog.CreateEventSource(strProductName, "Application")
    '        End If

    '        ' Establecemos la fuente del evento
    '        objApplicationEventLog.Source = strProductName

    '        ' Escribimos el evento en el Visor de Eventos
    '        Call objApplicationEventLog.WriteEntry(strErrorString.ToString(), EventLogEntryType.Error, Err.Number, intCategoryNumber)

    '        ' Regresamos la información
    '        intActualizar = 0

    '        ' Notificamos el error
    '        Throw

    '    End Try

    'End Function

    '====================================================================
    ' Name       : intAgregar
    ' Description: Adición de registros.
    '                  - Tabla tblArticuloCupon
    ' Parameters : 
    '              ByVal intArticuloId As Double
    '                  - 
    '              ByVal intCuponId As Double
    '                  - 
    '              ByVal dtmArticuloCuponUltimaModificacion As Date
    '                  - 
    '              ByVal strArticuloCuponModificadoPor As String
    '                  -       
    '              ByVal strConnectionString As String
    '                  - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================        
    'Public Shared Function intAgregar( _
    '        ByVal intArticuloId As Double, _
    '        ByVal intCuponId As Double, _
    '        ByVal dtmArticuloCuponUltimaModificacion As Date, _
    '        ByVal strArticuloCuponModificadoPor As String, _
    '        ByVal strConnectionString As String) As Integer

    '    ' Constantes locales
    '    Const strmThisMemberName As String = "intAgregar"

    '    ' Variables locales
    '    Dim strSQLStatement As StringBuilder = Nothing
    '    Dim intRowsAffected As Integer = 0, strRowsAffected As String(), strRegistros As Array

    '    Try
    '        ' Inicializamos las varialbes locales
    '        strSQLStatement = New StringBuilder

    '        ' Creamos es estatuto de SQL
    '        Call strSQLStatement.Append("EXECUTE spAgregartblArticuloCupon ")
    '        Call strSQLStatement.Append(intArticuloId)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(intCuponId)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(dtmArticuloCuponUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(strArticuloCuponModificadoPor)
    '        Call strSQLStatement.Append("'")

    '        ' Ejecutamos el comando                
    '        strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
    '        For Each strRowsAffected In strRegistros
    '            intRowsAffected = CInt(strRowsAffected.GetValue(0))
    '        Next

    '        ' Regresamos la información
    '        strSQLStatement = Nothing
    '        intAgregar = intRowsAffected

    '    Catch objException As Exception

    '        ' Variables locales
    '        Dim strErrorString As StringBuilder : strErrorString = New StringBuilder
    '        Dim objApplicationEventLog As System.Diagnostics.EventLog : objApplicationEventLog = New System.Diagnostics.EventLog
    '        Dim strProductName As String : strProductName = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
    '        Dim strApplicationName As String : strApplicationName = System.Reflection.Assembly.GetExecutingAssembly.Location
    '        Dim strVersion As String : strVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
    '        Dim strSource As String : strSource = objException.Source
    '        Dim strMessage As String : strMessage = objException.Message
    '        Dim strStackTrace As String : strStackTrace = objException.StackTrace
    '        Dim intLineNumber As Integer : intLineNumber = Erl()
    '        Dim intErrorNumber As Integer : intErrorNumber = Err.Number
    '        Dim intCategoryNumber As Short : intCategoryNumber = 100

    '        ' Creamos el mensaje de error
    '        Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Application name:" & vbCrLf & vbTab & strApplicationName & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Version:" & vbCrLf & vbTab & strVersion & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Source:" & vbCrLf & vbTab & strSource & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(intErrorNumber) & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Line number:" & vbCrLf & vbTab & intLineNumber & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Message:" & vbCrLf & vbTab & strMessage & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("SQLStatement:" & vbCrLf & vbTab & strSQLStatement.ToString() & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("StackTrace:" & vbCrLf & strStackTrace & vbCrLf & vbCrLf)

    '        ' Creamos un evento para registrar el mensaje de error
    '        If Not EventLog.SourceExists(strProductName) Then
    '            Call EventLog.CreateEventSource(strProductName, "Application")
    '        End If

    '        ' Establecemos la fuente del evento
    '        objApplicationEventLog.Source = strProductName

    '        ' Escribimos el evento en el Visor de Eventos
    '        Call objApplicationEventLog.WriteEntry(strErrorString.ToString(), EventLogEntryType.Error, Err.Number, intCategoryNumber)

    '        ' Regresamos la información
    '        intAgregar = 0

    '        ' Notificamos el error
    '        Throw

    '    End Try

    'End Function

    '====================================================================
    ' Name       : strBuscar
    ' Description: Búsqueda de registros.
    '                 - Tabla tblArticuloCupon
    ' Parameters : 
    '              ByVal intArticuloId As Double
    '                 - 
    '              ByVal intCuponId As Double
    '                 - 
    '              ByVal dtmArticuloCuponUltimaModificacion As Date
    '                 - 
    '              ByVal strArticuloCuponModificadoPor As String
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
    'Public Shared Function strBuscar( _
    '        ByVal intArticuloId As Double, _
    '        ByVal intCuponId As Double, _
    '        ByVal dtmArticuloCuponUltimaModificacion As Date, _
    '        ByVal strArticuloCuponModificadoPor As String, _
    '        ByVal intPosicionInicial As Double, _
    '        ByVal intElementos As Double, _
    '        ByVal strConnectionString As String) As Array

    '    ' Constantes locales
    '    Const strmThisMemberName As String = "strBuscar"

    '    ' Variables locales
    '    Dim strSQLStatement As StringBuilder = Nothing

    '    Try
    '        ' Inicializamos las varialbes locales
    '        strSQLStatement = New StringBuilder

    '        ' Creamos es estatuto de SQL
    '        Call strSQLStatement.Append("EXECUTE spBuscartblArticuloCupon ")
    '        Call strSQLStatement.Append(intArticuloId)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(intCuponId)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(dtmArticuloCuponUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(strArticuloCuponModificadoPor)
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(intPosicionInicial)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(intElementos)

    '        ' Ejecutamos el comando
    '        strBuscar = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
    '        strSQLStatement = Nothing

    '    Catch objException As Exception
    '        ' Variables locales
    '        Dim strErrorString As StringBuilder : strErrorString = New StringBuilder
    '        Dim objApplicationEventLog As System.Diagnostics.EventLog : objApplicationEventLog = New System.Diagnostics.EventLog
    '        Dim strProductName As String : strProductName = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
    '        Dim strApplicationName As String : strApplicationName = System.Reflection.Assembly.GetExecutingAssembly.Location
    '        Dim strVersion As String : strVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
    '        Dim strSource As String : strSource = objException.Source
    '        Dim strMessage As String : strMessage = objException.Message
    '        Dim strStackTrace As String : strStackTrace = objException.StackTrace
    '        Dim intLineNumber As Integer : intLineNumber = Erl()
    '        Dim intErrorNumber As Integer : intErrorNumber = Err.Number
    '        Dim intCategoryNumber As Short : intCategoryNumber = 100

    '        ' Creamos el mensaje de error
    '        Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Application name:" & vbCrLf & vbTab & strApplicationName & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Version:" & vbCrLf & vbTab & strVersion & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Source:" & vbCrLf & vbTab & strSource & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(intErrorNumber) & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Line number:" & vbCrLf & vbTab & intLineNumber & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Message:" & vbCrLf & vbTab & strMessage & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("SQLStatement:" & vbCrLf & vbTab & strSQLStatement.ToString() & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("StackTrace:" & vbCrLf & strStackTrace & vbCrLf & vbCrLf)

    '        ' Creamos un evento para registrar el mensaje de error
    '        If Not EventLog.SourceExists(strProductName) Then
    '            Call EventLog.CreateEventSource(strProductName, "Application")
    '        End If

    '        ' Establecemos la fuente del evento
    '        objApplicationEventLog.Source = strProductName

    '        ' Escribimos el evento en el Visor de Eventos
    '        Call objApplicationEventLog.WriteEntry(strErrorString.ToString(), EventLogEntryType.Error, Err.Number, intCategoryNumber)

    '        ' Regresamos la información
    '        strBuscar = Nothing

    '        ' Notificamos el error
    '        Throw

    '    End Try

    'End Function

    '====================================================================
    ' Name       : intContar
    ' Description: Contar los registros.
    '                 - Tabla tblArticuloCupon
    ' Parameters : 
    '              ByVal intArticuloId As Double
    '                 - 
    '              ByVal intCuponId As Double
    '                 - 
    '              ByVal dtmArticuloCuponUltimaModificacion As Date
    '                 - 
    '              ByVal strArticuloCuponModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros en la tabla
    '====================================================================
    Public Shared Function intContar(ByVal intArticuloId As Double, _
                                     ByVal intCuponId As Double, _
                                     ByVal dtmArticuloCuponUltimaModificacion As Date, _
                                     ByVal strArticuloCuponModificadoPor As String, _
                                     ByVal strConnectionString As String) As Double

        ' Constantes locales
        Const strmThisMemberName As String = "intContar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Double = 0, strRowsAffected As String(), strRegistros As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spContartblArticuloCupon ")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloCuponUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloCuponModificadoPor)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

            For Each strRowsAffected In strRegistros
                intRowsAffected = CDbl(strRowsAffected.GetValue(0))

            Next

            ' Regresamos la información
            strSQLStatement = Nothing
            intContar = intRowsAffected

        Catch objException As Exception

            ' Variables locales
            Dim strErrorString As StringBuilder : strErrorString = New StringBuilder
            Dim objApplicationEventLog As System.Diagnostics.EventLog : objApplicationEventLog = New System.Diagnostics.EventLog
            Dim strProductName As String : strProductName = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
            Dim strApplicationName As String : strApplicationName = System.Reflection.Assembly.GetExecutingAssembly.Location
            Dim strVersion As String : strVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
            Dim strSource As String : strSource = objException.Source
            Dim strMessage As String : strMessage = objException.Message
            Dim strStackTrace As String : strStackTrace = objException.StackTrace
            Dim intLineNumber As Integer : intLineNumber = Erl()
            Dim intErrorNumber As Integer : intErrorNumber = Err.Number
            Dim intCategoryNumber As Short : intCategoryNumber = 100

            ' Creamos el mensaje de error
            Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
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
            intContar = 0

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : intEliminar
    ' Description: Eliminación de registros.
    '                 - Tabla tblArticuloCupon
    ' Parameters : 
    '              ByVal intArticuloId As Double
    '                 - 
    '              ByVal intCuponId As Double
    '                 - 
    '              ByVal dtmArticuloCuponUltimaModificacion As Date
    '                 - 
    '              ByVal strArticuloCuponModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================        
    'Public Shared Function intEliminar( _
    '    ByVal intArticuloId As Double, _
    '    ByVal intCuponId As Double, _
    '    ByVal dtmArticuloCuponUltimaModificacion As Date, _
    '    ByVal strArticuloCuponModificadoPor As String, _
    '    ByVal strConnectionString As String) As Integer

    '    ' Constantes locales
    '    Const strmThisMemberName As String = "intEliminar"

    '    ' Variables locales
    '    Dim strSQLStatement As StringBuilder = Nothing
    '    Dim intRowsAffected As Integer = 0, strRowsAffected As String(), strRegistros As Array

    '    Try
    '        ' Inicializamos las varialbes locales
    '        strSQLStatement = New StringBuilder

    '        ' Creamos es estatuto de SQL
    '        Call strSQLStatement.Append("EXECUTE spEliminartblArticuloCupon ")
    '        Call strSQLStatement.Append(intArticuloId)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(intCuponId)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(dtmArticuloCuponUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(strArticuloCuponModificadoPor)
    '        Call strSQLStatement.Append("'")

    '        ' Ejecutamos el comando
    '        strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
    '        For Each strRowsAffected In strRegistros
    '            intRowsAffected = CInt(strRowsAffected.GetValue(0))
    '        Next

    '        ' Regresamos la información
    '        strSQLStatement = Nothing
    '        intEliminar = intRowsAffected

    '    Catch objException As Exception

    '        ' Variables locales
    '        Dim strErrorString As StringBuilder : strErrorString = New StringBuilder
    '        Dim objApplicationEventLog As System.Diagnostics.EventLog : objApplicationEventLog = New System.Diagnostics.EventLog
    '        Dim strProductName As String : strProductName = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
    '        Dim strApplicationName As String : strApplicationName = System.Reflection.Assembly.GetExecutingAssembly.Location
    '        Dim strVersion As String : strVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
    '        Dim strSource As String : strSource = objException.Source
    '        Dim strMessage As String : strMessage = objException.Message
    '        Dim strStackTrace As String : strStackTrace = objException.StackTrace
    '        Dim intLineNumber As Integer : intLineNumber = Erl()
    '        Dim intErrorNumber As Integer : intErrorNumber = Err.Number
    '        Dim intCategoryNumber As Short : intCategoryNumber = 100

    '        ' Creamos el mensaje de error
    '        Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Application name:" & vbCrLf & vbTab & strApplicationName & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Version:" & vbCrLf & vbTab & strVersion & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Source:" & vbCrLf & vbTab & strSource & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(intErrorNumber) & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Line number:" & vbCrLf & vbTab & intLineNumber & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Message:" & vbCrLf & vbTab & strMessage & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("SQLStatement:" & vbCrLf & vbTab & strSQLStatement.ToString() & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("StackTrace:" & vbCrLf & strStackTrace & vbCrLf & vbCrLf)

    '        ' Creamos un evento para registrar el mensaje de error
    '        If Not EventLog.SourceExists(strProductName) Then
    '            Call EventLog.CreateEventSource(strProductName, "Application")
    '        End If

    '        ' Establecemos la fuente del evento
    '        objApplicationEventLog.Source = strProductName

    '        ' Escribimos el evento en el Visor de Eventos
    '        Call objApplicationEventLog.WriteEntry(strErrorString.ToString(), EventLogEntryType.Error, Err.Number, intCategoryNumber)

    '        ' Regresamos la información
    '        intEliminar = 0

    '        ' Notificamos el error
    '        Throw

    '    End Try

    'End Function

    '====================================================================
    ' Name       : strBuscar
    ' Description: Búsqueda de registros modificados y que
    '              necesitan ser reenviados.
    '                 - Tabla: tblArticuloCupon
    ' Parameters :
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
    Public Shared Function strBuscar(ByVal dtmUltimaModificacionInicial As Date, _
                                     ByVal dtmUltimaModificacionFinal As Date, _
                                     ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarCambiotblArticuloCupon ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmUltimaModificacionInicial.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmUltimaModificacionFinal.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strBuscar = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

        Catch objException As Exception

            ' Variables locales
            Dim strErrorString As StringBuilder : strErrorString = New StringBuilder
            Dim objApplicationEventLog As System.Diagnostics.EventLog : objApplicationEventLog = New System.Diagnostics.EventLog
            Dim strProductName As String : strProductName = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
            Dim strApplicationName As String : strApplicationName = System.Reflection.Assembly.GetExecutingAssembly.Location
            Dim strVersion As String : strVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
            Dim strSource As String : strSource = objException.Source
            Dim strMessage As String : strMessage = objException.Message
            Dim strStackTrace As String : strStackTrace = objException.StackTrace
            Dim intLineNumber As Integer : intLineNumber = Erl()
            Dim intErrorNumber As Integer : intErrorNumber = Err.Number
            Dim intCategoryNumber As Short : intCategoryNumber = 100

            ' Creamos el mensaje de error
            Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
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
            strBuscar = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strBuscar
    ' Description: Búsqueda de registros modificados y que
    '              necesitan ser reenviados.
    '                 - Tabla: tblArticuloCupon
    ' Parameters :
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
    Public Shared Function strBuscar(ByVal intSolicitudActualizacionId As Integer, _
                                     ByVal dtmUltimaModificacionInicial As Date, _
                                     ByVal dtmUltimaModificacionFinal As Date, _
                                     ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spReenvioCambiotblArticuloCupon ")
            Call strSQLStatement.Append(intSolicitudActualizacionId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmUltimaModificacionInicial.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmUltimaModificacionFinal.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strBuscar = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

        Catch objException As Exception

            ' Variables locales
            Dim strErrorString As StringBuilder : strErrorString = New StringBuilder
            Dim objApplicationEventLog As System.Diagnostics.EventLog : objApplicationEventLog = New System.Diagnostics.EventLog
            Dim strProductName As String : strProductName = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
            Dim strApplicationName As String : strApplicationName = System.Reflection.Assembly.GetExecutingAssembly.Location
            Dim strVersion As String : strVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
            Dim strSource As String : strSource = objException.Source
            Dim strMessage As String : strMessage = objException.Message
            Dim strStackTrace As String : strStackTrace = objException.StackTrace
            Dim intLineNumber As Integer : intLineNumber = Erl()
            Dim intErrorNumber As Integer : intErrorNumber = Err.Number
            Dim intCategoryNumber As Short : intCategoryNumber = 100

            ' Creamos el mensaje de error
            Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
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
            strBuscar = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '-----------------------------------------------------------------------------
    '--------------------------- NUEVOS PROCEDIMIENTOS ---------------------------
    '-----------------------------------------------------------------------------

    '====================================================================
    ' Name          : intAgregar
    ' Description   : Adds a new record and returns its integer identifier
    ' Table name    : tblArticuloCupon
    ' Parameters    : 
    '              ByVal intArticuloId As Int32
    '                  - 
    '              ByVal intCuponId As Int32
    '                  - 
    '              ByVal intArticuloCuponCantidad As Int32
    '                  - 
    '              ByVal intArticuloCuponArticuloBeneficiadoId As Int32
    '                  - 
    '              ByVal blnArticuloCuponDescuentoEfectivo As Boolean
    '                  - 
    '              ByVal fltArticuloCuponDescuento As Decimal
    '                  - 
    '              ByVal dtmArticuloCuponVigenciaFin As DateTime
    '                  - 
    '              ByVal dtmArticuloCuponVigenciaInicio As DateTime
    '                  - 
    '              ByVal dtmArticuloCuponUltimaModificacion As DateTime
    '                  - 
    '              ByVal strArticuloCuponModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intAgregar(ByVal intArticuloId As Int32, _
                                      ByVal intCuponId As Int32, _
                                      ByVal intArticuloCuponCantidad As Int32, _
                                      ByVal intArticuloCuponArticuloBeneficiadoId As Int32, _
                                      ByVal blnArticuloCuponDescuentoEfectivo As Boolean, _
                                      ByVal fltArticuloCuponDescuento As Decimal, _
                                      ByVal dtmArticuloCuponVigenciaFin As DateTime, _
                                      ByVal dtmArticuloCuponVigenciaInicio As DateTime, _
                                      ByVal dtmArticuloCuponUltimaModificacion As DateTime, _
                                      ByVal strArticuloCuponModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spAgregartblArticuloCupon ")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloCuponCantidad)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloCuponArticuloBeneficiadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnArticuloCuponDescuentoEfectivo))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloCuponDescuento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloCuponVigenciaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloCuponVigenciaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloCuponUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloCuponModificadoPor)
            Call strSQLStatement.Append("'")

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
    ' Table name    : tblArticuloCupon
    ' Parameters    : 
    '              ByVal intArticuloId As Int32
    '                  - 
    '              ByVal intCuponId As Int32
    '                  - 
    '              ByVal intArticuloCuponCantidad As Int32
    '                  - 
    '              ByVal intArticuloCuponArticuloBeneficiadoId As Int32
    '                  - 
    '              ByVal blnArticuloCuponDescuentoEfectivo As Boolean
    '                  - 
    '              ByVal fltArticuloCuponDescuento As Decimal
    '                  - 
    '              ByVal dtmArticuloCuponVigenciaFin As DateTime
    '                  - 
    '              ByVal dtmArticuloCuponVigenciaInicio As DateTime
    '                  - 
    '              ByVal dtmArticuloCuponUltimaModificacion As DateTime
    '                  - 
    '              ByVal strArticuloCuponModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intEliminar(ByVal intArticuloId As Int32, _
                                       ByVal intCuponId As Int32, _
                                       ByVal intArticuloCuponCantidad As Int32, _
                                       ByVal intArticuloCuponArticuloBeneficiadoId As Int32, _
                                       ByVal blnArticuloCuponDescuentoEfectivo As Boolean, _
                                       ByVal fltArticuloCuponDescuento As Decimal, _
                                       ByVal dtmArticuloCuponVigenciaFin As DateTime, _
                                       ByVal dtmArticuloCuponVigenciaInicio As DateTime, _
                                       ByVal dtmArticuloCuponUltimaModificacion As DateTime, _
                                       ByVal strArticuloCuponModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spEliminartblArticuloCupon ")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloCuponCantidad)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloCuponArticuloBeneficiadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnArticuloCuponDescuentoEfectivo))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloCuponDescuento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloCuponVigenciaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloCuponVigenciaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloCuponUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloCuponModificadoPor)
            Call strSQLStatement.Append("'")

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
    ' Table name    : tblArticuloCupon
    ' Parameters    : 
    '              ByVal intArticuloId As Int32
    '                  - 
    '              ByVal intCuponId As Int32
    '                  - 
    '              ByVal intArticuloCuponCantidad As Int32
    '                  - 
    '              ByVal intArticuloCuponArticuloBeneficiadoId As Int32
    '                  - 
    '              ByVal blnArticuloCuponDescuentoEfectivo As Boolean
    '                  - 
    '              ByVal fltArticuloCuponDescuento As Decimal
    '                  - 
    '              ByVal dtmArticuloCuponVigenciaFin As DateTime
    '                  - 
    '              ByVal dtmArticuloCuponVigenciaInicio As DateTime
    '                  - 
    '              ByVal dtmArticuloCuponUltimaModificacion As DateTime
    '                  - 
    '              ByVal strArticuloCuponModificadoPor As String
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
    Public Shared Function strBuscar(ByVal intArticuloId As Int32, _
                                     ByVal intCuponId As Int32, _
                                     ByVal intArticuloCuponCantidad As Int32, _
                                     ByVal intArticuloCuponArticuloBeneficiadoId As Int32, _
                                     ByVal blnArticuloCuponDescuentoEfectivo As Boolean, _
                                     ByVal fltArticuloCuponDescuento As Decimal, _
                                     ByVal dtmArticuloCuponVigenciaFin As DateTime, _
                                     ByVal dtmArticuloCuponVigenciaInicio As DateTime, _
                                     ByVal dtmArticuloCuponUltimaModificacion As DateTime, _
                                     ByVal strArticuloCuponModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spBuscartblArticuloCupon ")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloCuponCantidad)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloCuponArticuloBeneficiadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnArticuloCuponDescuentoEfectivo))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloCuponDescuento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloCuponVigenciaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloCuponVigenciaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloCuponUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloCuponModificadoPor)
            Call strSQLStatement.Append("'")
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

    '====================================================================
    ' Name          : intActualizar
    ' Description   : Updates records and returns the number of updated items
    ' Table name    : tblArticuloCupon
    ' Parameters    : 
    '              ByVal intArticuloId As Int32
    '                  - 
    '              ByVal intCuponId As Int32
    '                  - 
    '              ByVal intArticuloCuponCantidad As Int32
    '                  - 
    '              ByVal intArticuloCuponArticuloBeneficiadoId As Int32
    '                  - 
    '              ByVal blnArticuloCuponDescuentoEfectivo As Boolean
    '                  - 
    '              ByVal fltArticuloCuponDescuento As Decimal
    '                  - 
    '              ByVal dtmArticuloCuponVigenciaFin As DateTime
    '                  - 
    '              ByVal dtmArticuloCuponVigenciaInicio As DateTime
    '                  - 
    '              ByVal dtmArticuloCuponUltimaModificacion As DateTime
    '                  - 
    '              ByVal strArticuloCuponModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intActualizar(ByVal intArticuloId As Int32, _
                                         ByVal intCuponId As Int32, _
                                         ByVal intArticuloCuponCantidad As Int32, _
                                         ByVal intArticuloCuponArticuloBeneficiadoId As Int32, _
                                         ByVal blnArticuloCuponDescuentoEfectivo As Boolean, _
                                         ByVal fltArticuloCuponDescuento As Decimal, _
                                         ByVal dtmArticuloCuponVigenciaFin As DateTime, _
                                         ByVal dtmArticuloCuponVigenciaInicio As DateTime, _
                                         ByVal dtmArticuloCuponUltimaModificacion As DateTime, _
                                         ByVal strArticuloCuponModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spActualizartblArticuloCupon ")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloCuponCantidad)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloCuponArticuloBeneficiadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnArticuloCuponDescuentoEfectivo))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloCuponDescuento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloCuponVigenciaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloCuponVigenciaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloCuponUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloCuponModificadoPor)
            Call strSQLStatement.Append("'")

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
    ' Name       : strBuscar
    ' Description: Búsqueda de registros modificados y que
    '              necesitan ser reenviados.
    '                 - Tabla tblArticulo
    ' Parameters :
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

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL         
            Call strSQLStatement.Append("EXECUTE spBuscartblArticuloCuponCambios ")
            Call strSQLStatement.Append(intTiendaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmUltimaModificacionInicial.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmUltimaModificacionFinal.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strBuscarCambios = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

        Catch objException As Exception

            ' Variables locales
            Dim strErrorString As StringBuilder : strErrorString = New StringBuilder
            Dim objApplicationEventLog As System.Diagnostics.EventLog : objApplicationEventLog = New System.Diagnostics.EventLog
            Dim strProductName As String : strProductName = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
            Dim strApplicationName As String : strApplicationName = System.Reflection.Assembly.GetExecutingAssembly.Location
            Dim strVersion As String : strVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
            Dim strSource As String : strSource = objException.Source
            Dim strMessage As String : strMessage = objException.Message
            Dim strStackTrace As String : strStackTrace = objException.StackTrace
            Dim intLineNumber As Integer : intLineNumber = Erl()
            Dim intErrorNumber As Integer : intErrorNumber = Err.Number
            Dim intCategoryNumber As Short : intCategoryNumber = 100

            ' Creamos el mensaje de error
            Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
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
            strBuscarCambios = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function


End Class
