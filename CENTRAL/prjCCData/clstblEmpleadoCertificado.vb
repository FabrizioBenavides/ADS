Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clstblEmpleadoCertificado
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : 2003-2005 Todos los Derechos Reservados.
' Company       : Deintec
' Author        : Dirección de Tecnología
' Version       : 1.0.1311.33021
' Last Modified : Friday, July 28, 2017
'====================================================================
Public NotInheritable Class clstblEmpleadoCertificado
    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblEmpleadoCertificado"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()
    End Sub

    '====================================================================
    ' Name       : intActualizar
    ' Description: Actualización de registros.
    '                 - Tabla tblEmpleadoCertificado
    ' Parameters : 
    '              ByVal intEmpleadoCertificadoId As Integer
    '                 - 
    '              ByVal dtmEmpleadoCertificadoUltimaModificacion As Date
    '                 - 
    '              ByVal strEmpleadoCertificadoModificadoPor As String
    '                 - 
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================
    Public Shared Function intActualizar( _
      ByVal intEmpleadoCertificadoId As Integer, _
      ByVal dtmEmpleadoCertificadoUltimaModificacion As Date, _
      ByVal strEmpleadoCertificadoModificadoPor As String, _
      ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intActualizar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0
        Dim strRegistros As Array = Nothing
        Dim strRowsAffected As String() = Nothing

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spActualizartblEmpleadoCertificado ")
            Call strSQLStatement.Append(intEmpleadoCertificadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmEmpleadoCertificadoUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEmpleadoCertificadoModificadoPor)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            For Each strRowsAffected In strRegistros
                intRowsAffected = CInt(strRowsAffected.GetValue(0))
            Next

            ' Regresamos la información
            strSQLStatement = Nothing
            intActualizar = intRowsAffected

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
            intActualizar = 0

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : intAgregar
    ' Description: Adición de registros.
    '                  - Tabla tblEmpleadoCertificado
    ' Parameters : 
    '              ByVal intEmpleadoCerttificadoId As Integer
    '                  - 
    '              ByVal dtmEmpleadoCertificadoUltimaModificacion As Date
    '                  - 
    '              ByVal strEmpleadoCertificadoModificadoPor As String
    '                  -
    '              ByVal strConnectionString As String
    '                  - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================
    Public Shared Function intAgregar( _
      ByVal intEmpleadoCertificadoId As Integer, _
      ByVal dtmEmpleadoCertificadoUltimaModificacion As Date, _
      ByVal strEmpleadoCertificadoModificadoPor As String, _
      ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intAgregar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0
        Dim strRegistros As Array = Nothing
        Dim strRowsAffected As String() = Nothing

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spAgregartblEmpleadoCertificado ")
            Call strSQLStatement.Append(intEmpleadoCertificadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmEmpleadoCertificadoUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEmpleadoCertificadoModificadoPor)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            For Each strRowsAffected In strRegistros
                intRowsAffected = CInt(strRowsAffected.GetValue(0))
            Next

            ' Regresamos la información
            strSQLStatement = Nothing
            intAgregar = intRowsAffected

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
            intAgregar = 0

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strBuscar
    ' Description: Búsqueda de registros.
    '                 - Tabla tblEmpleadoCertificado
    ' Parameters : 
    '              ByVal intEmpleadoCertificadoId As Integer
    '                 - 
    '              ByVal dtmEmpleadoCertificadoUltimaModificacion As Date
    '                 - 
    '              ByVal strEmpleadoCertificadoModificadoPor As String
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
    Public Shared Function strBuscar( _
      ByVal intEmpleadoCertificadoId As Integer, _
      ByVal dtmEmpleadoCertificadoUltimaModificacion As Date, _
      ByVal strEmpleadoCertificadoModificadoPor As String, _
      ByVal intPosicionInicial As Double, _
      ByVal intElementos As Double, _
      ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscartblEmpleadoCertificado ")
            Call strSQLStatement.Append(intEmpleadoCertificadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmEmpleadoCertificadoUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEmpleadoCertificadoModificadoPor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intPosicionInicial)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intElementos)

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

    ''====================================================================
    '' Name       : strBuscar
    '' Description: Búsqueda de registros modificados y que
    ''              necesitan ser reenviados.
    ''                 - Tabla tblBINTarjeta
    '' Parameters :
    ''              ByVal dtmUltimaModificacionInicial As Date
    ''                 - Fecha inicial de búsqueda
    ''              ByVal dtmUltimaModificacionFinal As Date
    ''                 - Fecha final de búsqueda
    ''              ByVal strConnectionString As String
    ''                 - Cadena de conexión hacia el RDBMS
    '' Throws     : Exception
    '' Output     : Array
    ''                 - Arreglo bidimensional con los registros leídos
    ''                   Array = { (c1,c2..cn), (c1,c2..cn) ... (c1,c2..cn) }
    ''                   c = Campo
    ''====================================================================
    'Public Shared Function strBuscar( _
    '  ByVal dtmUltimaModificacionInicial As Date, _
    '  ByVal dtmUltimaModificacionFinal As Date, _
    '  ByVal strConnectionString As String) As Array

    '    ' Constantes locales
    '    Const strmThisMemberName As String = "strBuscar"

    '    ' Variables locales
    '    Dim strSQLStatement As StringBuilder = Nothing

    '    Try

    '        ' Inicializamos las varialbes locales
    '        strSQLStatement = New StringBuilder

    '        ' Creamos es estatuto de SQL
    '        Call strSQLStatement.Append("EXECUTE spBuscarCambiotblBINTarjeta ")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(dtmUltimaModificacionInicial.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(dtmUltimaModificacionFinal.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
    '        Call strSQLStatement.Append("'")

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

    ''====================================================================
    '' Name       : intContar
    '' Description: Contar los registros.
    ''                 - Tabla tblBINTarjeta
    '' Parameters : 
    ''              ByVal intBINTarjetaId As Integer
    ''                 - 
    ''              ByVal intEmisorFormaPagoId As Integer
    ''                 - 
    ''              ByVal blnBINTarjetaEsCredito As Byte
    ''                 - 
    ''              ByVal dtmBINTarjetaUltimaModificacion As Date
    ''                 - 
    ''              ByVal strBINTarjetaModificadoPor As String
    ''                 - 
    ''              ByVal strConnectionString As String
    ''                 - Cadena de conexión hacia el RDBMS
    '' Throws     : Exception
    '' Output     : Integer
    ''                 - Número de registros en la tabla
    ''====================================================================
    'Public Shared Function intContar( _
    '  ByVal intBINTarjetaId As Integer, _
    '  ByVal intEmisorFormaPagoId As Integer, _
    '  ByVal blnBINTarjetaEsCredito As Byte, _
    '  ByVal dtmBINTarjetaUltimaModificacion As Date, _
    '  ByVal strBINTarjetaModificadoPor As String, _
    '  ByVal strBINTarjetaDescripcion As String, _
    '  ByVal blnBINTarjetaPermiteVentaCuotas As Boolean, _
    '  ByVal strConnectionString As String) As Double

    '    ' Constantes locales
    '    Const strmThisMemberName As String = "intContar"

    '    ' Variables locales
    '    Dim strSQLStatement As StringBuilder = Nothing
    '    Dim intRowsAffected As Double = 0
    '    Dim strRegistros As Array = Nothing
    '    Dim strRowsAffected As String() = Nothing

    '    Try

    '        ' Inicializamos las varialbes locales
    '        strSQLStatement = New StringBuilder

    '        ' Creamos es estatuto de SQL
    '        Call strSQLStatement.Append("EXECUTE spContartblBINTarjeta ")
    '        Call strSQLStatement.Append(intBINTarjetaId)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(intEmisorFormaPagoId)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(blnBINTarjetaEsCredito)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(dtmBINTarjetaUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(strBINTarjetaModificadoPor)
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(strBINTarjetaDescripcion)
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(CByte(blnBINTarjetaPermiteVentaCuotas))

    '        ' Ejecutamos el comando
    '        strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
    '        For Each strRowsAffected In strRegistros
    '            intRowsAffected = CInt(strRowsAffected.GetValue(0))
    '        Next

    '        ' Regresamos la información
    '        strSQLStatement = Nothing
    '        intContar = intRowsAffected

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
    '        intContar = 0

    '        ' Notificamos el error
    '        Throw

    '    End Try

    'End Function

    '====================================================================
    ' Name       : intEliminar
    ' Description: Eliminación de registros.
    '                 - Tabla tblEmpleadoCertificado
    ' Parameters : 
    '              ByVal intEmpleadoCertificadoId As Integer
    '                 - 
    '              ByVal dtmEmpleadoCertificadoUltimaModificacion As Date
    '                 - 
    '              ByVal strEmpleadoCertificadoModificadoPor As String
    '                 - 
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================
    Public Shared Function intEliminar( _
      ByVal intEmpleadoCertificadoId As Integer, _
      ByVal dtmEmpleadoCertificadoUltimaModificacion As Date, _
      ByVal strEmpleadoCertificadoModificadoPor As String, _
      ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intEliminar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0
        Dim strRegistros As Array = Nothing
        Dim strRowsAffected As String() = Nothing

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spEliminartblEmpleadoCertificado ")
            Call strSQLStatement.Append(intEmpleadoCertificadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmEmpleadoCertificadoUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEmpleadoCertificadoModificadoPor)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            For Each strRowsAffected In strRegistros
                intRowsAffected = CInt(strRowsAffected.GetValue(0))
            Next

            ' Regresamos la información
            strSQLStatement = Nothing
            intEliminar = intRowsAffected

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
            intEliminar = 0

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : aobjObtenerEmpleadosCertificados
    ' Description: Búsqueda de registros.
    '                 - Tabla tblEmpleadoCertificado
    ' Parameters : 
    '              ByVal intEmpleadoCertificadoId As Integer
    '                 - 
    '              ByVal dtmEmpleadoCertificadoUltimaModificacion As Date
    '                 - 
    '              ByVal strEmpleadoCertificadoModificadoPor As String
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
    Public Shared Function aobjObtenerEmpleadosCertificados( _
        ByVal intEmpleadoCertificadoId As String, _
        ByVal intPosicionInicial As Double, _
        ByVal intElementos As Double, _
        ByVal strConnectionString As String) As Array

        'ByVal dtmEmpleadoCertificadoUltimaModificacion As Date, _
        'ByVal strEmpleadoCertificadoModificadoPor As String, _

        ' Member identifier
        Const strmThisMemberName As String = "aobjObtenerEmpleadosCertificados"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array

        Try

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spBuscarEmpleadoCertificado ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(intEmpleadoCertificadoId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intPosicionInicial)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intElementos)

            ' Execute the SQL statement
            aobjReturnedData = clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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

    Public Shared Function aobjExportarEmpleadosCertificados(ByVal strConnectionString As String) As Array
        ' Member identifier
        Const strmThisMemberName As String = "aobjExportarEmpleadosCertificados"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array

        Try

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spExportarEmpleadoCertificado ")

            ' Execute the SQL statement
            aobjReturnedData = clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
