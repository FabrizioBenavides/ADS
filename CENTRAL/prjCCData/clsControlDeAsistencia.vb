Imports System.Text
Imports Benavides.Data.SQL.MSSQL



Public Class clsControlDeAsistencia

    ' Class identifier
    Private Const strmThisClassName As String = "Benavides.CC.Data.clsControlDeAsistencia"

    '====================================================================
    ' Name       : intConfirmarAsistenciacon
    ' Description: Confirmacion de registros.
    ' Parameters : 
    '              ByVal intRegistroId As Integer
    '                  - 
    '              ByVal intMovimientoAjusteId As Integer
    '                  - 
    '              ByVal strUsuario As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================
    Public Shared Function intObtenerTipoUsuarioId(ByVal strUsuarioNombre As String, _
                                                  ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intObtenerTipoUsuarioId"

        ' Variables locales
        Dim strSQLStatement As StringBuilder
        Dim intRowsAffected As Integer
        Dim strRegistros As Array
        Dim strRowsAffected As String()

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spObtenerTipoUsuarioId ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strUsuarioNombre)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

            For Each strRowsAffected In strRegistros

                intRowsAffected = CInt(strRowsAffected.GetValue(0))

            Next

            ' Regresamos la información
            strSQLStatement = Nothing
            intObtenerTipoUsuarioId = intRowsAffected

        Catch objException As Exception

            ' Variables locales
            Dim strErrorString As StringBuilder = New StringBuilder
            Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
            Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
            Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
            Dim strSource As String = objException.Source
            Dim strMessage As String = objException.Message
            Dim strStackTrace As String = objException.StackTrace
            Dim intLineNumber As Integer = Erl()
            Dim intErrorNumber As Integer = Err.Number
            Dim intCategoryNumber As Short = 0

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
            intObtenerTipoUsuarioId = 0

        End Try

    End Function

    

#Region "Combos"

    '====================================================================
    ' Name       : strBuscarDivisionControlAsistencia
    ' Description: Buscar la información de la división 
    '               
    ' Parameters :
    '               ByVal strUsuario As Integer
    '               - Usuario de RH
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con el registro leído
    '                Array = { (), (), ..... () }
    '====================================================================
    Public Shared Function strBuscarDivisionControlAsistencia(ByVal strUsuario As String, _
                                                              ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarDivisionControlAsistencia"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarDivisionControlAsistencia ")
            Call strSQLStatement.Append(strUsuario)

            ' Ejecutamos el comando
            strBuscarDivisionControlAsistencia = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
            Dim intCategoryNumber As Short : intCategoryNumber = 0

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
            strSQLStatement = Nothing
            strBuscarDivisionControlAsistencia = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strBuscarZonaControlAsistencia
    ' Description: Buscar la información de la división 
    '               
    ' Parameters :
    '               ByVal strUsuario As Integer
    '               - Usuario de RH
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con el registro leído
    '                Array = { (), (), ..... () }
    '====================================================================
    Public Shared Function strBuscarZonaControlAsistencia(ByVal strUsuario As String, _
                                                          ByVal intDireccionId As Integer, _
                                                          ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarZonaControlAsistencia"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarZonaControlAsistencia ")

            Call strSQLStatement.Append(strUsuario)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDireccionId)

            ' Ejecutamos el comando
            strBuscarZonaControlAsistencia = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
            Dim intCategoryNumber As Short : intCategoryNumber = 0

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
            strSQLStatement = Nothing
            strBuscarZonaControlAsistencia = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strObtenerSucursales
    ' Description: Consultar las Sursales.
    '             
    ' Parameters :
    '               ByVal intSucursalId As Integer
    '               ByVal intCompaniaId As As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                '====================================================================
    Public Shared Function strObtenerSucursales(ByVal intEmpleadoId As Integer, _
                                                ByVal intDireccionId As Integer, _
                                                ByVal intZonaId As Integer, _
                                                ByVal strAlmacenId As String, _
                                                ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strObtenerSucursales"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spObtenerSucursales ")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDireccionId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intZonaId)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(strAlmacenId)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strObtenerSucursales = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strObtenerSucursales = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try

    End Function

    '====================================================================
    ' Name       : strObtenerMovimientosNomina
    ' Description: Consultar los Tipos de Movimientos para el control de asistencia.
    '             
    ' Parameters :
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                '====================================================================
    Public Shared Function strObtenerMovimientosNomina(ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strObtenerMovimientosNomina"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarMovimientosControlAsistencia")


            ' Ejecutamos el comando
            strObtenerMovimientosNomina = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strObtenerMovimientosNomina = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try

    End Function

    '====================================================================
    ' Name       : strObtenerMovimientosAConfirmar
    ' Description: Obtiene los movimientos a cofirmar.
    '             
    ' Parameters :
    '               ByVal intMovimientoId As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                '====================================================================
    Public Shared Function strObtenerMovimientosAConfirmar(ByVal intMovimientoId As Integer, _
                                                           ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strObtenerMovimientosAConfirmar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spConfigurarMovimientosControlAsistencia ")
            Call strSQLStatement.Append(intMovimientoId)


            ' Ejecutamos el comando
            strObtenerMovimientosAConfirmar = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strObtenerMovimientosAConfirmar = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try

    End Function

    '====================================================================
    ' Name       : strBuscarCoordinadoresRH
    ' Description: Obtiene los coordinadors RH. 
    '               
    ' Parameters :
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con el registro leído
    '                Array = { (), (), ..... () }
    '====================================================================
    Public Shared Function strBuscarCoordinadoresRH(ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarCoordinadoresRH"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim returnedData As Array

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarCoordinadoresRHAsistencia")

            ' Ejecutamos el comando
            returnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

            ' Return the results
            Return returnedData

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
            Dim intCategoryNumber As Short : intCategoryNumber = 0

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
            strSQLStatement = Nothing
            strBuscarCoordinadoresRH = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    Public Shared Function strObtenerPerfilesEmpleados(ByVal strConnectionString As String) As Array
        ' Constantes locales
        Const strmThisMemberName As String = "strObtenerPerfilesEmpleados"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spObtenerPerfilesEmpleados")


            ' Ejecutamos el comando
            strObtenerPerfilesEmpleados = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strObtenerPerfilesEmpleados = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try
    End Function



#End Region

#Region "Pop Empleado"
    '====================================================================
    ' Name       : strBuscarPopEmpleado
    ' Description: Obtiene los empleados y los muestra en popup.
    ' Parameters :    
    '               ByVal strEmpleado As String
    '               ByVal intPosicionInicial As Integer
    '               ByVal intElementos As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos    
    '====================================================================
    Public Shared Function strBuscarPopEmpleado(ByVal strEmpleado As String, _
                                                ByVal intPosicionInicial As Integer, _
                                                ByVal intElementos As Integer, _
                                                ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarPopEmpleado"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarPopEmpleado ")
            Call strSQLStatement.Append(" '")
            Call strSQLStatement.Append(strEmpleado)
            Call strSQLStatement.Append("', ")
            Call strSQLStatement.Append(intPosicionInicial)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intElementos)

            ' Ejecutamos el comando
            strBuscarPopEmpleado = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strBuscarPopEmpleado = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)

        End Try

    End Function
#End Region

#Region "Pantalla - Consulta"

    '====================================================================
    ' Name       : strConfigurarMovimientosControlAsistencia
    ' Description: Consultar el detalle de los movimientos para el control de asistencia.
    '             
    ' Parameters :
    '               ByVal intSucursalId As Integer
    '               ByVal intCompaniaId As As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                '====================================================================
    Public Shared Function strConfigurarMovimientosControlAsistencia(ByVal intMovimientoId As Integer, ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strConfigurarMovimientosControlAsistencia"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spConfigurarMovimientosControlAsistencia ")
            Call strSQLStatement.Append(intMovimientoId)

            ' Ejecutamos el comando
            strConfigurarMovimientosControlAsistencia = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strConfigurarMovimientosControlAsistencia = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try

    End Function

    '====================================================================
    ' Name       : strConsultaDetalleControlAsistencia
    ' Description: Consultar el detalle de los movimientos para el control de asistencia.
    '             
    ' Parameters :
    '               ByVal intSucursalId As Integer
    '               ByVal intCompaniaId As As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                '====================================================================
    Public Shared Function strConsultaDetalleControlAsistencia(ByVal intEmpleadoId As Integer, _
                                                        ByVal strCentroLogisticoId As String, _
                                                        ByVal intZonaId As Integer, _
                                                        ByVal intMovimientoId As Integer, _
                                                        ByVal intTipoNomina As Integer, _
                                                        ByVal dtmFechaInicio As Date, _
                                                        ByVal dtmFechaFin As Date, _
                                                        ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strConsultaDetalleControlAsistencia"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spConsultaDetalleControlAsistencia ")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(strCentroLogisticoId)
            Call strSQLStatement.Append("',")
            Call strSQLStatement.Append(intZonaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoNomina)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(dtmFechaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFechaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strConsultaDetalleControlAsistencia = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strConsultaDetalleControlAsistencia = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try

    End Function

    Public Shared Function strConsultaDetalleControlAsistenciaPorAdministrador(ByVal intEmpleadoId As Integer, _
                                                        ByVal strCentroLogisticoId As String, _
                                                        ByVal intZonaId As Integer, _
                                                        ByVal intMovimientoId As Integer, _
                                                        ByVal intTipoNomina As Integer, _
                                                        ByVal dtmFechaInicio As Date, _
                                                        ByVal dtmFechaFin As Date, _
                                                        ByVal intTipoUsuarioId As Integer, _
                                                        ByVal intControlAsistenciaObservacionesId As Integer, _
                                                        ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strConsultaDetalleControlAsistenciaPorAdministrador"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spConsultaDetalleControlAsistenciaPorAdministrador ")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(strCentroLogisticoId)
            Call strSQLStatement.Append("',")
            Call strSQLStatement.Append(intZonaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoNomina)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(dtmFechaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFechaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoUsuarioId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intControlAsistenciaObservacionesId)

            ' Ejecutamos el comando
            strConsultaDetalleControlAsistenciaPorAdministrador = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strConsultaDetalleControlAsistenciaPorAdministrador = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try
    End Function

    Public Shared Function strConsultaDetalleControlAsistenciaPorCoordinador(ByVal intEmpleadoId As Integer, _
                                                        ByVal strCentroLogisticoId As String, _
                                                        ByVal intZonaId As Integer, _
                                                        ByVal intMovimientoId As Integer, _
                                                        ByVal intTipoNomina As Integer, _
                                                        ByVal dtmFechaInicio As Date, _
                                                        ByVal dtmFechaFin As Date, _
                                                        ByVal intControlAsistenciaObservacionesId As Integer, _
                                                        ByVal strConnectionString As String) As Array
        ' Constantes locales
        Const strmThisMemberName As String = "strConsultaDetalleControlAsistenciaPorCoordinador"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spConsultaDetalleControlAsistenciaPorCoordinador ")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(strCentroLogisticoId)
            Call strSQLStatement.Append("',")
            Call strSQLStatement.Append(intZonaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoNomina)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(dtmFechaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFechaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intControlAsistenciaObservacionesId)

            ' Ejecutamos el comando
            strConsultaDetalleControlAsistenciaPorCoordinador = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strConsultaDetalleControlAsistenciaPorCoordinador = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try
    End Function


    '====================================================================
    ' Name       : strConsultaResumenControlAsistencia
    ' Description: Consultar el Resumen de los movimientos para el control de asistencia.
    '             
    ' Parameters :
    '               ByVal intSucursalId As Integer
    '               ByVal intCompaniaId As As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                '====================================================================
    Public Shared Function strConsultaResumenControlAsistencia(ByVal intEmpleadoId As Integer, _
                                                        ByVal strCentroLogisticoId As String, _
                                                        ByVal intZonaId As Integer, _
                                                        ByVal intMovimientoId As Integer, _
                                                        ByVal intTipoNomina As Integer, _
                                                        ByVal dtmFechaInicio As Date, _
                                                        ByVal dtmFechaFin As Date, _
                                                        ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strConsultaResumenControlAsistencia"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spConsultaResumenControlAsistencia ")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(strCentroLogisticoId)
            Call strSQLStatement.Append("',")
            Call strSQLStatement.Append(intZonaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoNomina)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(dtmFechaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFechaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strConsultaResumenControlAsistencia = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strConsultaResumenControlAsistencia = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try

    End Function

    Public Shared Function strConsultaResumenControlAsistenciaPorAdministrador(ByVal intEmpleadoId As Integer, _
                                                        ByVal strCentroLogisticoId As String, _
                                                        ByVal intZonaId As Integer, _
                                                        ByVal intMovimientoId As Integer, _
                                                        ByVal intTipoNomina As Integer, _
                                                        ByVal dtmFechaInicio As Date, _
                                                        ByVal dtmFechaFin As Date, _
                                                        ByVal intTipoUsuarioId As Integer, _
                                                        ByVal intControlAsistenciaObservacionesId As Integer, _
                                                        ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strConsultaResumenControlAsistenciaPorAdministrador"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spConsultaResumenControlAsistenciaPorAdministrador ")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(strCentroLogisticoId)
            Call strSQLStatement.Append("',")
            Call strSQLStatement.Append(intZonaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoNomina)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(dtmFechaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFechaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoUsuarioId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intControlAsistenciaObservacionesId)

            ' Ejecutamos el comando
            strConsultaResumenControlAsistenciaPorAdministrador = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strConsultaResumenControlAsistenciaPorAdministrador = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try
    End Function

    Public Shared Function strConsultaResumenControlAsistenciaPorCoordinador(ByVal intEmpleadoId As Integer, _
                                                        ByVal strCentroLogisticoId As String, _
                                                        ByVal intZonaId As Integer, _
                                                        ByVal intMovimientoId As Integer, _
                                                        ByVal intTipoNomina As Integer, _
                                                        ByVal dtmFechaInicio As Date, _
                                                        ByVal dtmFechaFin As Date, _
                                                        ByVal intControlAsistenciaObservacionesId As Integer, _
                                                        ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strConsultaResumenControlAsistenciaPorCoordinador"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spConsultaResumenControlAsistenciaPorCoordinador ")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(strCentroLogisticoId)
            Call strSQLStatement.Append("',")
            Call strSQLStatement.Append(intZonaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoNomina)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(dtmFechaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFechaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intControlAsistenciaObservacionesId)

            ' Ejecutamos el comando
            strConsultaResumenControlAsistenciaPorCoordinador = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strConsultaResumenControlAsistenciaPorCoordinador = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try
    End Function

    '====================================================================
    ' Name       : intConfirmarAsistencia
    ' Description: Confirmacion de registros.
    ' Parameters : 
    '              ByVal intRegistroId As Integer
    '                  - 
    '              ByVal intMovimientoAjusteId As Integer
    '                  - 
    '              ByVal strUsuario As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================
    Public Shared Function intConfirmarAsistencia(ByVal intRegistroId As Integer, _
                                                  ByVal intMovimientoAjusteId As Integer, _
                                                  ByVal strUsuario As String, _
                                                  ByVal dtmFechaInicio As Date, _
                                                  ByVal dtmFechaFin As Date, _
                                                  ByVal intControlAsistenciaObservacionesId As Integer, _
                                                  ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intConfirmarAsistencia"

        ' Variables locales
        Dim strSQLStatement As StringBuilder
        Dim intRowsAffected As Integer
        Dim strRegistros As Array
        Dim strRowsAffected As String()

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spConfirmarAsistencia ")
            Call strSQLStatement.Append(intRegistroId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoAjusteId)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(strUsuario)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFechaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFechaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intControlAsistenciaObservacionesId)

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

            For Each strRowsAffected In strRegistros

                intRowsAffected = CInt(strRowsAffected.GetValue(0))

            Next

            ' Regresamos la información
            strSQLStatement = Nothing
            intConfirmarAsistencia = intRowsAffected

        Catch objException As Exception

            ' Variables locales
            Dim strErrorString As StringBuilder = New StringBuilder
            Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
            Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
            Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
            Dim strSource As String = objException.Source
            Dim strMessage As String = objException.Message
            Dim strStackTrace As String = objException.StackTrace
            Dim intLineNumber As Integer = Erl()
            Dim intErrorNumber As Integer = Err.Number
            Dim intCategoryNumber As Short = 0

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
            intConfirmarAsistencia = 0

        End Try

    End Function

#End Region

#Region "Ver Detalle"

    '====================================================================
    ' Name       : strObtenerDetalleMovimientos
    ' Description: Consultar el detalle de los movimientos de un empleado.
    '             
    ' Parameters :
    '               ByVal intSucursalId As Integer
    '               ByVal intCompaniaId As As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                '====================================================================
    Public Shared Function strObtenerDetalleMovimientos(ByVal intEmpleadoId As Integer, _
                                                        ByVal intMovimientoId As Integer, _
                                                        ByVal dtmFechaInicio As Date, _
                                                        ByVal dtmFechaFin As Date, _
                                                        ByVal intControlAsistenciaObservacionesId As Integer, _
                                                        ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strObtenerDetalleMovimientos"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarDetalleMovimientos ")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoId)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(dtmFechaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFechaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intControlAsistenciaObservacionesId)

            ' Ejecutamos el comando
            strObtenerDetalleMovimientos = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strObtenerDetalleMovimientos = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try

    End Function
#End Region

#Region "Reporte por Coordinador RH"

    '====================================================================
    ' Name       : strObtenerReporteControlAsistencia
    ' Description: Consultar el detalle de los movimientos para el control de asistencia.
    '             
    ' Parameters :
    '               ByVal intSucursalId As Integer
    '               ByVal intCompaniaId As As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                '====================================================================
    Public Shared Function strObtenerReporteControlAsistencia(ByVal intCoordinadorRHId As Integer, _
                                                              ByVal intEstatusId As Integer, _
                                                              ByVal intTipoNominaId As Integer, _
                                                              ByVal dtmFechaInicio As Date, _
                                                              ByVal dtmFechaFin As Date, _
                                                              ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strObtenerReporteControlAsistencia"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spObtenerReporteControlAsistencia ")
            Call strSQLStatement.Append(intCoordinadorRHId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEstatusId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoNominaId)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(dtmFechaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFechaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strObtenerReporteControlAsistencia = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strObtenerReporteControlAsistencia = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try

    End Function
#End Region

#Region "Archivo Adam"

    '====================================================================
    ' Name       : strInformacionArchivoAdamPorGenerar
    ' Description: Informacio que genera el Archivo Adam 
    '             
    ' Parameters :
    '               ByVal dtmFechaPeriodoPago As Date
    '               ByVal dtmFechaInicio As Date
    '               ByVal dtmFechaFin As Date
    '               ByVal strUsuario As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                '====================================================================
    Public Shared Function strInformacionArchivoAdamPorGenerar(ByVal intTipoNomina As Integer, _
                                                               ByVal dtmFechaInicio As Date, _
                                                               ByVal dtmFechaFin As Date, _
                                                               ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strInformacionArchivoAdamPorGenerar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spInformacionArchivoAdamPorGenerar ")
            Call strSQLStatement.Append(intTipoNomina)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(dtmFechaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFechaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strInformacionArchivoAdamPorGenerar = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strInformacionArchivoAdamPorGenerar = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try

    End Function

    '====================================================================
    ' Name       : strGenerarArchivoAdam
    ' Description: Genera el Archivo Adam que se carga
    '             
    ' Parameters :
    '               ByVal dtmFechaPeriodoPago As Date
    '               ByVal dtmFechaInicio As Date
    '               ByVal dtmFechaFin As Date
    '               ByVal strUsuario As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                '====================================================================
    Public Shared Function strGenerarArchivoAdam(ByVal intTipoNomina As Integer, _
                                                 ByVal dtmFechaPeriodoPago As Date, _
                                                 ByVal dtmFechaInicio As Date, _
                                                 ByVal dtmFechaFin As Date, _
                                                 ByVal strUsuario As String, _
                                                 ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strGenerarArchivoAdam"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spGenerarArchivoAdam ")
            Call strSQLStatement.Append(intTipoNomina)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(dtmFechaPeriodoPago.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFechaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFechaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("',")
            Call strSQLStatement.Append(strUsuario)

            ' Ejecutamos el comando
            strGenerarArchivoAdam = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strGenerarArchivoAdam = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try

    End Function
#End Region

#Region "Administracion de Usuarios"

    '====================================================================
    ' Name       : strBuscarGrupoControlAsistencia
    ' Description: Consultar la informacion del grupo Control de Asistencia.
    '             
    ' Parameters :
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                '====================================================================
    Public Shared Function strBuscarGrupoControlAsistencia(ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarGrupoControlAsistencia"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarGrupoControlAsistencia ")

            ' Ejecutamos el comando
            strBuscarGrupoControlAsistencia = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strBuscarGrupoControlAsistencia = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try

    End Function

#End Region

#Region "Agregar Usuarios"

    '====================================================================
    ' Name       : strAsignarSucursales
    ' Description: Consultar el detalle de los movimientos para el control de asistencia.
    '             
    ' Parameters :
    '               ByVal intCoordinadorRHId As Integer, _
    '               ByVal intDireccionOperativaId As Integer, _
    '               ByVal intZonaOperativaId As Integer, _
    '               ByVal intCompaniaId As Integer, _
    '               ByVal intSucursalId As Integer, _
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                '====================================================================
    Public Shared Function strAsignarSucursales(ByVal intCoordinadorRHId As Integer, _
                                                ByVal intCompaniaId As Integer, _
                                                ByVal intSucursalId As Integer, _
                                                ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strAsignarSucursales"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spControlAsistenciaAsignarSucursalRH ")
            Call strSQLStatement.Append(intCoordinadorRHId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)

            ' Ejecutamos el comando
            strAsignarSucursales = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strAsignarSucursales = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try

    End Function

    Public Shared Function strAsignarSucursales2(ByVal intUsuarioId As Integer, _
                                                 ByVal intCompaniaId As Integer, _
                                                 ByVal intSucursalId As Integer, _
                                                 ByVal intTipoUsuarioId As Integer, _
                                                 ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strAsignarSucursales2"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spControlAsistenciaAsignarSucursalRH2 ")
            Call strSQLStatement.Append(intUsuarioId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoUsuarioId)

            ' Ejecutamos el comando
            strAsignarSucursales2 = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
            strSQLStatement = Nothing
            strAsignarSucursales2 = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try

    End Function

    Public Shared Function intEliminarSucursales(ByVal intEmpleadoId As Integer, ByVal strConnectionString As String) As Integer
        ' Constantes locales
        Const strmThisMemberName As String = "intEliminarSucursales"

        ' Variables locales
        Dim strSQLStatement As StringBuilder
        Dim intRowsAffected As Integer
        Dim strRegistros As Array
        Dim strRowsAffected As String()

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spEliminarTblSucursales ")
            Call strSQLStatement.Append(intEmpleadoId)

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

            For Each strRowsAffected In strRegistros
                intRowsAffected = CInt(strRowsAffected.GetValue(0))
            Next

            ' Regresamos la información
            strSQLStatement = Nothing
            intEliminarSucursales = intRowsAffected

        Catch objException As Exception

            ' Variables locales
            Dim strErrorString As StringBuilder = New StringBuilder
            Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
            Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
            Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
            Dim strSource As String = objException.Source
            Dim strMessage As String = objException.Message
            Dim strStackTrace As String = objException.StackTrace
            Dim intLineNumber As Integer = Erl()
            Dim intErrorNumber As Integer = Err.Number
            Dim intCategoryNumber As Short = 0

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
            intEliminarSucursales = 0

        End Try
    End Function

    '====================================================================
    ' Name       : strDesasignarSucursales
    ' Description: Confirmacion de registros.
    ' Parameters : 
    '              ByVal intRegistroId As Integer
    '                  - 
    '              ByVal intMovimientoAjusteId As Integer
    '                  - 
    '              ByVal strUsuario As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================
    Public Shared Function intDesasignarSucursales(ByVal intCoordinadorRHId As Integer, _
                                                   ByVal intCompaniaId As Integer, _
                                                   ByVal intSucursalId As Integer, _
                                                   ByVal intDireccionOperativaId As Integer, _
                                                   ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intDesasignarSucursales"

        ' Variables locales
        Dim strSQLStatement As StringBuilder
        Dim intRowsAffected As Integer
        Dim strRegistros As Array
        Dim strRowsAffected As String()

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spControlAsistenciaDesasignarSucursalRH ")
            Call strSQLStatement.Append(intCoordinadorRHId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDireccionOperativaId)

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

            For Each strRowsAffected In strRegistros

                intRowsAffected = CInt(strRowsAffected.GetValue(0))

            Next

            ' Regresamos la información
            strSQLStatement = Nothing
            intDesasignarSucursales = intRowsAffected

        Catch objException As Exception

            ' Variables locales
            Dim strErrorString As StringBuilder = New StringBuilder
            Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
            Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
            Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
            Dim strSource As String = objException.Source
            Dim strMessage As String = objException.Message
            Dim strStackTrace As String = objException.StackTrace
            Dim intLineNumber As Integer = Erl()
            Dim intErrorNumber As Integer = Err.Number
            Dim intCategoryNumber As Short = 0

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
            intDesasignarSucursales = 0

        End Try

    End Function

    '====================================================================
    ' Name       : strObtenerSucursalesPorCoordinadorRH
    ' Description: Consultar el detalle de los movimientos para el control de asistencia.
    '             
    ' Parameters :
    '               ByVal intCoordinadorRHId As Integer, _
    '               ByVal intDireccionOperativaId As Integer, _
    '               ByVal intZonaOperativaId As Integer, _
    '               ByVal intCompaniaId As Integer, _
    '               ByVal intSucursalId As Integer, _
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                '====================================================================
    Public Shared Function strObtenerSucursalesPorCoordinadorRH(ByVal intCoordinadorRHId As Integer, _
                                                                ByVal intCompaniaId As Integer, _
                                                                ByVal intSucursalId As Integer, _
                                                                ByVal intUsuarioId As Integer, _
                                                                ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strObtenerSucursalesPorCoordinadorRH"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spObtenerSucursalesPorCoordinadorRH ")
            Call strSQLStatement.Append(intCoordinadorRHId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intUsuarioId)

            ' Ejecutamos el comando
            strObtenerSucursalesPorCoordinadorRH = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strObtenerSucursalesPorCoordinadorRH = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try

    End Function

    Public Shared Function strObtenerSucursalesPorTipoUsuario(ByVal intEmpleadoId As Integer, _
                                                              ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strObtenerSucursalesPorTipoUsuario"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spObtenerSucursalesPorTipoUsuario ")
            Call strSQLStatement.Append(intEmpleadoId)

            ' Ejecutamos el comando
            strObtenerSucursalesPorTipoUsuario = clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strObtenerSucursalesPorTipoUsuario = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try
    End Function

    '====================================================================
    ' Name       : strBuscarUsuarioConcentrador
    ' Description: Consultar el detalle de los movimientos para el control de asistencia.
    '             
    ' Parameters :
    '               ByVal intCoordinadorRHId As Integer, _
    '               ByVal intDireccionOperativaId As Integer, _
    '               ByVal intZonaOperativaId As Integer, _
    '               ByVal intCompaniaId As Integer, _
    '               ByVal intSucursalId As Integer, _
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                '====================================================================
    Public Shared Function strBuscarUsuarioConcentrador(ByVal intGrupoUsuarioId As Integer, _
                                                        ByVal intEmpleadoId As Integer, _
                                                        ByVal intTipoUsuarioId As Integer, _
                                                        ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarUsuarioConcentrador"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spControlAsistenciaBuscarUsuarioConcentrador ")
            Call strSQLStatement.Append(intGrupoUsuarioId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoUsuarioId)

            ' Ejecutamos el comando
            strBuscarUsuarioConcentrador = clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strBuscarUsuarioConcentrador = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try

    End Function

    Public Shared Function strBuscarSupervisorMedico(ByVal intGrupoUsuarioId As Integer, _
                                                     ByVal intEmpleadoId As Integer, _
                                                     ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarSupervisorMedico"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spControlAsistenciaBuscarSupervisorMedico ")
            Call strSQLStatement.Append(intGrupoUsuarioId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)

            ' Ejecutamos el comando
            strBuscarSupervisorMedico = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strSQLStatement = Nothing
            strBuscarSupervisorMedico = Nothing

            ' Notificamos el error
            Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
        End Try

    End Function

#End Region

#Region "Empleados de Oficina"

#End Region

    Public Class clsControlAsistenciaObservaciones

        Public Shared Function strConsultartblControlAsistenciaObservaciones(ByVal strControlAsistenciaObservacionesNombre As String, _
           ByVal strConnectionString As String) As Array

            ' Member identifier
            Const strmThisMemberName As String = "strConsultartblControlAsistenciaObservaciones"

            ' Declare the local variables
            Dim strSQLStatement As System.Text.StringBuilder
            Dim aobjReturnedData As Array

            Try

                ' Create the SQL statement
                strSQLStatement = New System.Text.StringBuilder
                Call strSQLStatement.Append("EXECUTE spConsultartblControlAsistenciaObservaciones ")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strControlAsistenciaObservacionesNombre)
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

        Public Shared Function intGuardartblControlAsistenciaObservaciones( _
                                               ByVal strControlAsistenciaObservacionesNombre As String, _
                                               ByVal blnActivo As Boolean, _
                                               ByVal strControlAsistenciaObservacionesModificadoPor As String, _
                                               ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intGuardartblControlAsistenciaObservaciones"

            ' Variables locales
            Dim strSQLStatement As StringBuilder
            Dim intRowsAffected As Integer = 1
            Dim strRegistros As Array
            Dim strRowsAffected As String()

            Try
                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spGuardartblControlAsistenciaObservaciones ")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strControlAsistenciaObservacionesNombre)
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(CByte(blnActivo))
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strControlAsistenciaObservacionesModificadoPor)
                Call strSQLStatement.Append("'")

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                'For Each strRowsAffected In strRegistros

                '    intRowsAffected = CInt(strRowsAffected.GetValue(0))

                'Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intGuardartblControlAsistenciaObservaciones = intRowsAffected

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                intGuardartblControlAsistenciaObservaciones = 0

            End Try

        End Function

        Public Shared Function intActualizartblControlAsistenciaObservaciones( _
                                               ByVal intControlAsistenciaObservacionesId As Integer, _
                                               ByVal strControlAsistenciaObservacionesNombre As String, _
                                               ByVal blnVisible As Boolean, _
                                               ByVal strControlAsistenciaObservacionesModificadoPor As String, _
                                               ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intActualizartblControlAsistenciaObservaciones"

            ' Variables locales
            Dim strSQLStatement As StringBuilder
            Dim intRowsAffected As Integer
            Dim strRegistros As Array
            Dim strRowsAffected As String()

            Try
                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spActualizartblControlAsistenciaObservaciones ")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(intControlAsistenciaObservacionesId)
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strControlAsistenciaObservacionesNombre)
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(CByte(blnVisible))
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strControlAsistenciaObservacionesModificadoPor)
                Call strSQLStatement.Append("'")

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                For Each strRowsAffected In strRegistros

                    intRowsAffected = CInt(strRowsAffected.GetValue(0))

                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intActualizartblControlAsistenciaObservaciones = intRowsAffected

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                intActualizartblControlAsistenciaObservaciones = 0
            End Try
        End Function

        Public Shared Function strConsultartblControlAsistenciaObservacionesPorActivo(ByVal strConnectionString As String) As Array
            ' Member identifier
            Const strmThisMemberName As String = "strConsultartblControlAsistenciaObservacionesPorActivo"

            ' Declare the local variables
            Dim strSQLStatement As System.Text.StringBuilder
            Dim aobjReturnedData As Array

            Try

                ' Create the SQL statement
                strSQLStatement = New System.Text.StringBuilder
                Call strSQLStatement.Append("EXECUTE spConsultartblControlAsistenciaObservacionesPorActivo ")

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

    Public Class clsCalendarioNomina

        Public Shared Function intGuardarTblCalendarioNomina( _
                                              ByVal intTipoNomina As Short, _
                                              ByVal intAnio As Short, _
                                              ByVal intPeriodo As Short, _
                                              ByVal dtmFechaInicio As Date, _
                                              ByVal dtmFechaFin As Date, _
                                              ByVal dtmFechaEjecucion As Date, _
                                              ByVal dtmFechaPago As Date, _
                                              ByVal intMesAcumulado As Short, _
                                              ByVal intAnioAcumulado As Short, _
                                              ByVal intCalendarioId As Integer, _
                                              ByVal intEstatusEnviado As Short, _
                                              ByVal dtmUltimaModificacion As Date, _
                                              ByVal strModificadoPor As String, _
                                              ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intGuardarTblCalendarioNomina"
            Dim strSQLStatement As StringBuilder
            Dim strRegistros As Array
            Dim intRowsAffected As Integer = 1

            Try

                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spGuardarTblCalendarioNomina ")
                Call strSQLStatement.Append(intTipoNomina)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intAnio)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intPeriodo)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmFechaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmFechaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmFechaEjecucion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmFechaPago.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intMesAcumulado)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intAnioAcumulado)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intCalendarioId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intEstatusEnviado)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strModificadoPor)
                Call strSQLStatement.Append("'")

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                ' Regresamos la información
                strSQLStatement = Nothing
                intGuardarTblCalendarioNomina = intRowsAffected

            Catch objException As Exception
                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                intGuardarTblCalendarioNomina = 0
            End Try
        End Function

        Public Shared Function strConsultarCalendarioNomina(ByVal strConnectionString As String) As Array
            ' Constantes locales
            Const strmThisMemberName As String = "strConsultarCalendarioNomina"
            Dim strSQLStatement As StringBuilder
            Dim intRowsAffected As Integer = 1

            Try
                ' Inicialización de las variables locales
                strSQLStatement = New StringBuilder

                ' Creamos estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spConsultarCalendarioNomina ")

                ' Ejecutamos el comando
                strConsultarCalendarioNomina = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
                strSQLStatement = Nothing
                strConsultarCalendarioNomina = Nothing

                ' Notificamos el error
                Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
            End Try
        End Function

    End Class

    Public Class clsRolMedico

        Private Const strFechaDefaultInicial As String = "1900/01/01"

        Public Shared Function strBuscarEmpleadosMedicos(ByVal intUsuarioId As Integer, _
                                                         ByVal strConnectionString As String) As Array

            Dim aobjReturnedData As Array
            ' Constantes locales
            Const strmThisMemberName As String = "strBuscarEmpleadosMedicos"

            ' Variables locales
            Dim strSQLStatement As StringBuilder = Nothing

            Try
                ' Inicialización de las variables locales
                strSQLStatement = New StringBuilder

                ' Creamos estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spBuscarEmpleadosMedicos ")
                Call strSQLStatement.Append(intUsuarioId)

                ' Ejecutamos el comando
                aobjReturnedData = clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString, strConnectionString)
                strSQLStatement = Nothing

                Return aobjReturnedData
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
                strSQLStatement = Nothing
                strBuscarEmpleadosMedicos = Nothing

                ' Notificamos el error
                Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
            End Try
        End Function

        ''' <summary>
        ''' Cambiar Nombre metodo
        ''' </summary>
        ''' <param name="intUsuarioId"></param>
        ''' <param name="strConnectionString"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function strBuscarEmpleadosMedicos2(ByVal intUsuarioId As Integer, _
                                                          ByVal strConnectionString As String) As Array

            Dim aobjReturnedData As Array
            ' Constantes locales
            Const strmThisMemberName As String = "strBuscarEmpleadosMedicos"

            ' Variables locales
            Dim strSQLStatement As StringBuilder = Nothing

            Try
                ' Inicialización de las variables locales
                strSQLStatement = New StringBuilder

                ' Creamos estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spBuscarEmpleadosMedicos ")
                Call strSQLStatement.Append(intUsuarioId)

                ' Ejecutamos el comando
                aobjReturnedData = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
                strSQLStatement = Nothing

                Return aobjReturnedData
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
                strSQLStatement = Nothing
                strBuscarEmpleadosMedicos2 = Nothing

                ' Notificamos el error
                Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
            End Try
        End Function



        Public Shared Function strConsultarMovimientosEmpleadosMedicos(ByVal intEmpleadoId As Integer, _
                                                                       ByVal dtmFechaInicio As Date, _
                                                                       ByVal dtmFechaFin As Date, _
                                                                       ByVal strConnectionString As String) As Array

            ' Constantes locales
            Const strmThisMemberName As String = "strConsultarMovimientosEmpleadosMedicos"

            ' Variables locales
            Dim strSQLStatement As StringBuilder = Nothing

            Try
                ' Inicialización de las variables locales
                strSQLStatement = New StringBuilder

                ' Creamos estatuto de SQL
                Call strSQLStatement.AppendFormat("EXECUTE spConsultarMovimientosEmpleadosMedicos {0}, '{1}', '{2}'", _
                                                  intEmpleadoId, _
                                                  dtmFechaInicio.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture), _
                                                  dtmFechaFin.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
     
                ' Ejecutamos el comando
                strConsultarMovimientosEmpleadosMedicos = clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
                strSQLStatement = Nothing
                strConsultarMovimientosEmpleadosMedicos = Nothing

                ' Notificamos el error
                Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
            End Try

        End Function

        Public Shared Function strBuscarMotivosIncapacidad(ByVal strConnectionString As String) As Array
            ' Constantes locales
            Const strmThisMemberName As String = "strBuscarMotivosIncapacidad"

            ' Variables locales
            Dim strSQLStatement As StringBuilder

            Try

                ' Create the SQL statement
                strBuscarMotivosIncapacidad = clsSQLOperation.strExecuteQuery(String.Format("EXECUTE spBuscarMotivosDeIncapacidad"), strConnectionString)

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                strBuscarMotivosIncapacidad = Nothing
            End Try
        End Function

        Public Shared Function strBuscarDiasFestivos(ByVal strConnectionString As String) As Array
            ' Constantes locales
            Const strmThisMemberName As String = "strBuscarDiasFestivos"

            ' Variables locales
            Dim strSQLStatement As StringBuilder

            Try
                ' Create the SQL statement
                strBuscarDiasFestivos = clsSQLOperation.strExecuteQuery(String.Format("EXECUTE spBuscarDiasFestivos"), strConnectionString)

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                strBuscarDiasFestivos = Nothing

            End Try
        End Function

        Public Shared Function strObtenerConfiguracionControlAsistencia(ByVal intEmpleadoId As Integer, _
                                                                        ByVal strConnectionString As String) As Array

            ' Constantes locales
            Const strmThisMemberName As String = "strObtenerInformacionControlAsistencia"

            ' Variables locales
            Dim strSQLStatement As StringBuilder = Nothing
            Dim objEmpleadoArray, objVacacionesArray, objIncapacidadMedicaArray, objPermisoEspecialArray, objCapacitacionArray As Array
            Dim objResultArray(24) As String
            Dim intDiaDescanso As Integer = 0

            Try
                
                ' EMPLEADO                   
                objEmpleadoArray = strObtenerInformacionControlAsistencia(intEmpleadoId, strConnectionString)

                ' Regresa la informacion sobre VACACIONES
                objVacacionesArray = strBuscarVacaciones(intEmpleadoId, strConnectionString)

                ' Regresa la informacion sobre PERMISO
                objPermisoEspecialArray = strBuscarPermisoEspecial(intEmpleadoId, strConnectionString)

                ' Regresa la informacion sobre INCAPACIDAD
                objIncapacidadMedicaArray = strBuscarIncapacidad(intEmpleadoId, strConnectionString)

                ' Capacitacion
                objCapacitacionArray = strBuscarCapacitacion(intEmpleadoId, strConnectionString)

                ' Todo lo almaceno en un solo array y lo regreso a vista     
                Dim strCamposEmpleado As String() = DirectCast(objEmpleadoArray.GetValue(0), String())

                objResultArray(0) = strCamposEmpleado(0) 'dias de Vacaciones Disponibles
                objResultArray(1) = strCamposEmpleado(1) 'Dia de Descanso
                objResultArray(2) = strCamposEmpleado(2) 'baja temporal
                objResultArray(16) = strCamposEmpleado(3) 'Apellido Paterno de Empleado
                objResultArray(17) = strCamposEmpleado(4) 'Apellido Materno de Empleado
                objResultArray(18) = strCamposEmpleado(5) 'Nombre Empleado

                Dim strCamposVacaciones As String() = DirectCast(objVacacionesArray.GetValue(0), String())

                objResultArray(3) = strCamposVacaciones(0) 'Vacaciones Id
                objResultArray(4) = strCamposVacaciones(1) 'Fecha Inicio Vacaciones
                objResultArray(5) = strCamposVacaciones(2) 'Fecha fin Vacaciones

                Dim strCamposPermisoEspecial As String() = DirectCast(objPermisoEspecialArray.GetValue(0), String())

                objResultArray(6) = strCamposPermisoEspecial(0)  'Permiso Especial Id
                objResultArray(7) = strCamposPermisoEspecial(1)  'Fecha Inicio Permiso
                objResultArray(8) = strCamposPermisoEspecial(2)  'Fecha fin Permiso
                objResultArray(9) = strCamposPermisoEspecial(3)  'blnSueldo
                objResultArray(10) = strCamposPermisoEspecial(4) 'Dias
                objResultArray(19) = strCamposPermisoEspecial(5) 'Observaciones

                Dim strCamposIncapacidadMedica As String() = DirectCast(objIncapacidadMedicaArray.GetValue(0), String())

                objResultArray(11) = strCamposIncapacidadMedica(0)  'intIncapacidadId
                objResultArray(12) = strCamposIncapacidadMedica(1)  'dtmIncapacidadInicio
                objResultArray(13) = strCamposIncapacidadMedica(2)  'dtmIncapacidadFin 
                objResultArray(14) = strCamposIncapacidadMedica(3)  'intMotivoIncapacidadId
                objResultArray(15) = strCamposIncapacidadMedica(4)  'strFolio
                objResultArray(20) = strCamposIncapacidadMedica(5)    'Observaciones

                Dim strCamposCapacitacion As String() = DirectCast(objCapacitacionArray.GetValue(0), String())

                objResultArray(21) = strCamposCapacitacion(0) 'Capacitacion Id
                objResultArray(22) = strCamposCapacitacion(1) 'Fecha Inicio Capacitacion
                objResultArray(23) = strCamposCapacitacion(2) 'Fecha fin Capacitacion
                objResultArray(24) = strCamposCapacitacion(3) 'Observaciones

                strObtenerConfiguracionControlAsistencia = objResultArray

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
                strSQLStatement = Nothing
                strObtenerConfiguracionControlAsistencia = Nothing

                ' Notificamos el error
                Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
            End Try
        End Function

        Private Shared Function strObtenerInformacionControlAsistencia(ByVal intEmpleadoId As Integer, _
                                                                      ByVal strConnectionString As String) As Array
            ' Constantes locales
            Const strmThisMemberName As String = "strObtenerInformacionControlAsistencia"

            ' Variables locales
            Dim strSQLStatement As StringBuilder

            Try

                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spObtenerInformacionControlAsistencia ")
                Call strSQLStatement.Append(intEmpleadoId)

                ' Ejecutamos el comando
                strObtenerInformacionControlAsistencia = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                strSQLStatement = Nothing

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                strObtenerInformacionControlAsistencia = Nothing
            End Try
        End Function

        Private Shared Function strBuscarVacaciones(ByVal intEmpleadoId As Integer, ByVal strConnectionString As String) As Array
            ' Constantes locales
            Const strmThisMemberName As String = "strBuscarVacaciones"
            Const strmThisClassName As String = "clsRolMedico"
            ' Variables locales
            Dim strSQLStatement As StringBuilder

            Try

                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spBuscartblVacaciones ")

                Call strSQLStatement.Append(intEmpleadoId)

                ' Ejecutamos el comando
                strBuscarVacaciones = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                strSQLStatement = Nothing

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                strBuscarVacaciones = Nothing

            End Try
        End Function

        Private Shared Function strBuscarPermisoEspecial(ByVal intEmpleadoId As Integer, ByVal strConnectionString As String) As Array

            ' Constantes locales
            Const strmThisMemberName As String = "strBuscarPermisoEspecial"
            Const strmThisClassName As String = "clsRolMedico"
            ' Variables locales
            Dim strSQLStatement As StringBuilder

            Try

                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spBuscartblPermisoEspecial ")

                Call strSQLStatement.Append(intEmpleadoId)

                ' Ejecutamos el comando
                strBuscarPermisoEspecial = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                strSQLStatement = Nothing

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                strBuscarPermisoEspecial = Nothing
            End Try
        End Function

        Private Shared Function strBuscarIncapacidad(ByVal intEmpleadoId As Integer, ByVal strConnectionString As String) As Array
            ' Constantes locales
            Const strmThisMemberName As String = "strBuscarIncapacidad"
            Const strmThisClassName As String = "clsRolMedico"

            ' Variables locales
            Dim strSQLStatement As StringBuilder

            Try

                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spBuscartblIncapacidad ")
                Call strSQLStatement.Append(intEmpleadoId)

                ' Ejecutamos el comando
                strBuscarIncapacidad = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                strSQLStatement = Nothing

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                strBuscarIncapacidad = Nothing

            End Try
        End Function

        Private Shared Function strBuscarCapacitacion(ByVal intEmpleadoId As Integer, ByVal strConnectionString As String) As Array

            ' Constantes locales
            Const strmThisMemberName As String = "strBuscarCapacitacion"
            Const strmThisClassName As String = "clsRolMedico"

            ' Variables locales
            Dim strSQLStatement As StringBuilder

            Try

                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spBuscartblCapacitacion ")
                Call strSQLStatement.Append(intEmpleadoId)

                ' Ejecutamos el comando
                strBuscarCapacitacion = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                strSQLStatement = Nothing

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                strBuscarCapacitacion = Nothing

            End Try
        End Function




        Public Shared Function strBuscarAsignacionHorarioLaboralPorEmpleadoId(ByVal intEmpleadoId As Integer, ByVal strConnectionString As String) As Array
            ' Constantes locales
            Const strmThisMemberName As String = "strBuscarAsignacionHorarioLaboralPorEmpleadoId"
            Const strmThisClassName As String = "clsRolMedico"

            ' Variables locales
            Dim strSQLStatement As StringBuilder

            Try

                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spBuscarAsignacionHorarioLaboralPorEmpleadoId ")
                Call strSQLStatement.Append(intEmpleadoId)

                ' Ejecutamos el comando
                strBuscarAsignacionHorarioLaboralPorEmpleadoId = clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                strSQLStatement = Nothing

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                strBuscarAsignacionHorarioLaboralPorEmpleadoId = Nothing
            End Try
        End Function

        Public Shared Function strBuscarHorarioLaboralPorEmpleadoId(ByVal intEmpleadoId As Integer, ByVal strConnectionString As String) As Array
            ' Constantes locales
            Const strmThisMemberName As String = "strBuscarHorarioLaboralPorEmpleadoId"
            Const strmThisClassName As String = "clsRolMedico"

            ' Variables locales
            Dim strSQLStatement As StringBuilder

            Try
                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spBuscarHorarioLaboralPorEmpleadoId ")
                Call strSQLStatement.Append(intEmpleadoId)

                ' Ejecutamos el comando
                strBuscarHorarioLaboralPorEmpleadoId = clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                strSQLStatement = Nothing

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                strBuscarHorarioLaboralPorEmpleadoId = Nothing
            End Try
        End Function

        Public Shared Function strObtenerDiaDescanso(ByVal intEmpleadoId As Integer, ByVal strConnectionString As String) As Array
            ' Constantes locales
            Const strmThisMemberName As String = "strObtenerDiaDescanso"
            Const strmThisClassName As String = "clsRolMedico"

            ' Variables locales
            Dim strSQLStatement As StringBuilder

            Try
                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.AppendFormat("EXECUTE spObtenerDiaDescanso {0}", intEmpleadoId)

                ' Ejecutamos el comando
                strObtenerDiaDescanso = clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
                strSQLStatement = Nothing

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                strObtenerDiaDescanso = Nothing
            End Try
        End Function

        Public Shared Function intGuardarAsignacionTurnos(ByVal intEmpleadoId As Integer, _
                                                          ByVal intDomingo As Integer, _
                                                          ByVal intLunes As Integer, _
                                                          ByVal intMartes As Integer, _
                                                          ByVal intMiercoles As Integer, _
                                                          ByVal intJueves As Integer, _
                                                          ByVal intViernes As Integer, _
                                                          ByVal intSabado As Integer, _
                                                          ByVal strAsignacionTurnoModificadoPor As String, _
                                                          ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intGuardarAsignacionTurnos"

            ' Variables locales
            Dim strSQLStatement As StringBuilder = Nothing
            Dim intRowsAffected As Integer
            Dim strRegistros As Array
            Dim strRowsAffected As String()

            Try

                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spActualizartblAsignacionTurno ")
                Call strSQLStatement.Append(intEmpleadoId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intDomingo)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intLunes)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intMartes)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intMiercoles)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intJueves)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intViernes)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intSabado)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strAsignacionTurnoModificadoPor)
                Call strSQLStatement.Append("'")

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intGuardarAsignacionTurnos = intRowsAffected

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                intGuardarAsignacionTurnos = 0
            End Try
        End Function







        Public Shared Function strGuardarConfiguracionControlAsistencia(ByVal intEmpleadoId As Double, _
                                                                        ByVal strModificadoPor As String, _
                                                                        ByVal strVacacionId As String, _
                                                                        ByVal strPermisoEspecialId As String, _
                                                                        ByVal strIncapacidadId As String, _
                                                                        ByVal strCapacitacionId As String, _
                                                                        ByVal blnBajaTemporal As Boolean, _
                                                                        ByVal dtmFechaVacacionesFin As Date, _
                                                                        ByVal dtmVacacionesInicio As Date, _
                                                                        ByVal dtmFechaIncapacidadInicio As Date, _
                                                                        ByVal dtmFechaIncapacidadFin As Date, _
                                                                        ByVal intMotivoIncapacidad As Int32, _
                                                                        ByVal strFolioIncapacidad As String, _
                                                                        ByVal strObservacionesIncapacidad As String, _
                                                                        ByVal strObservacionesPermiso As String, _
                                                                        ByVal blnPermisoConsueldo As Boolean, _
                                                                        ByVal dtmFechaPermisoInicio As Date, _
                                                                        ByVal dtmFechaPermisoFin As Date, _
                                                                        ByVal intDiaDescanso As Int16, _
                                                                        ByVal dtmCapacitacionInicio As Date, _
                                                                        ByVal dtmFechaCapacitacionFin As Date, _
                                                                        ByVal strObservacionesCapacitacion As String, _
                                                                        ByVal strCadenaConexion As String) As String


            ' Constantes locales
            Const strmThisMemberName As String = "strGuardarConfiguracionControlAsistencia"

            ' Variables locales
            Dim strSQLStatement As StringBuilder = Nothing
            Dim intVacaciones, intIncapacidad, intPermiso, intDiaDesc, intBajaTemporal, intCapacitacion As Integer
            Dim resultValidacion As Array
            Dim strMensajeError As String

            Try
                'Validar Informacion
                resultValidacion = strValidarConfiguracionAsistenciasEmpleado(intEmpleadoId, _
                                                                              Convert.ToInt32(strVacacionId), _
                                                                              dtmVacacionesInicio, _
                                                                              dtmFechaVacacionesFin, _
                                                                              intDiaDescanso, _
                                                                              blnBajaTemporal, _
                                                                              Convert.ToInt32(strIncapacidadId), _
                                                                              intMotivoIncapacidad, _
                                                                              dtmFechaIncapacidadInicio, _
                                                                              dtmFechaIncapacidadFin, _
                                                                              Convert.ToInt32(strPermisoEspecialId), _
                                                                              dtmFechaPermisoInicio, _
                                                                              dtmFechaPermisoFin, _
                                                                              strCadenaConexion)

                If IsArray(resultValidacion) AndAlso resultValidacion.Length > 0 Then
                    ' Obtenemos la descripcion del error de validacion
                    Dim mensajeError As String() = DirectCast(resultValidacion.GetValue(0), String())
                    strMensajeError = mensajeError(0).ToString
                    strGuardarConfiguracionControlAsistencia = strMensajeError
                Else
                    'paso la validacion'
                    'strGuardarConfiguracionControlAsistencia = "paso la validacion"

                    'Guardar Informacion
                    intBajaTemporal = intGuardarBajaTemporal(CInt(intEmpleadoId), blnBajaTemporal, strModificadoPor, strCadenaConexion)
                    If blnBajaTemporal = False Then

                        'Vacaciones
                        If dtmFechaVacacionesFin <> Convert.ToDateTime(strDMYtoMDY(strFechaDefaultInicial)) And _
                           dtmVacacionesInicio <> Convert.ToDateTime(strDMYtoMDY(strFechaDefaultInicial)) Then

                            intVacaciones = intGuardarInformacionVacaciones(CInt(intEmpleadoId), _
                                                                            strModificadoPor, _
                                                                            Convert.ToInt32(strVacacionId), _
                                                                            dtmVacacionesInicio, _
                                                                            dtmFechaVacacionesFin, _
                                                                            strCadenaConexion)
                        End If

                        'Incapacidad
                        If dtmFechaIncapacidadFin <> Convert.ToDateTime(strDMYtoMDY(strFechaDefaultInicial)) And _
                            dtmFechaIncapacidadInicio <> Convert.ToDateTime(strDMYtoMDY(strFechaDefaultInicial)) Then

                            intIncapacidad = intGuardarInformacionIncapacidad(Convert.ToInt32(strIncapacidadId), _
                                                                              CInt(intEmpleadoId), _
                                                                              intMotivoIncapacidad, _
                                                                              dtmFechaIncapacidadInicio, _
                                                                              dtmFechaIncapacidadFin, _
                                                                              strFolioIncapacidad, _
                                                                              strObservacionesIncapacidad, _
                                                                              strModificadoPor, _
                                                                              strCadenaConexion)
                        End If

                        'Permiso
                        If dtmFechaPermisoFin <> Convert.ToDateTime(strDMYtoMDY(strFechaDefaultInicial)) And _
                            dtmFechaPermisoInicio <> Convert.ToDateTime(strDMYtoMDY(strFechaDefaultInicial)) Then

                            intPermiso = intGuardarInformacionPermisos(Convert.ToInt32(strPermisoEspecialId), _
                                                                       CInt(intEmpleadoId), _
                                                                       dtmFechaPermisoInicio, _
                                                                       dtmFechaPermisoFin, _
                                                                       blnPermisoConsueldo, _
                                                                       strModificadoPor, _
                                                                       strObservacionesPermiso, _
                                                                       strCadenaConexion)
                        End If

                        'DiaDescanso
                        If intDiaDescanso <> 0 Then
                            intDiaDesc = intGuardarDiaDescanso(CInt(intEmpleadoId), intDiaDescanso, strModificadoPor, strCadenaConexion)
                        End If

                        'Capacitacion
                        If dtmFechaCapacitacionFin <> Convert.ToDateTime(strDMYtoMDY(strFechaDefaultInicial)) And _
                            dtmCapacitacionInicio <> Convert.ToDateTime(strDMYtoMDY(strFechaDefaultInicial)) Then

                            intCapacitacion = intGuardarInformacionCapacitacion(Convert.ToInt32(strCapacitacionId), _
                                                                                CInt(intEmpleadoId), _
                                                                                dtmCapacitacionInicio, _
                                                                                dtmFechaCapacitacionFin, _
                                                                                strObservacionesCapacitacion, _
                                                                                strModificadoPor, _
                                                                                strCadenaConexion)
                        End If
                    End If
                End If

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
                strSQLStatement = Nothing
                strGuardarConfiguracionControlAsistencia = Nothing

                ' Notificamos el error
                Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)
            End Try
        End Function

        Private Shared Function strValidarConfiguracionAsistenciasEmpleado(ByVal intEmpleadoId As Double, _
                                                                           ByVal intVacacionesId As Integer, _
                                                                           ByVal dtmVacacionesInicio As Date, _
                                                                           ByVal dtmVacacionesFin As Date, _
                                                                           ByVal intDiaSemanaId As Integer, _
                                                                           ByVal blnEstatusTemporal As Boolean, _
                                                                           ByVal intIncapacidadId As Integer, _
                                                                           ByVal intMotivoIncapacidadId As Integer, _
                                                                           ByVal dtmIncapacidadInicio As Date, _
                                                                           ByVal dtmIncapacidadFin As Date, _
                                                                           ByVal intPermisoEspecialId As Integer, _
                                                                           ByVal dtmPermisoInicio As Date, _
                                                                           ByVal dtmPermisoFin As Date, _
                                                                           ByVal strConnectionString As String) As Array

            ' Constantes locales
            Const strmThisMemberName As String = "strValidarConfiguracionAsistenciasEmpleado"
            Dim bajaTemporal As Byte = 0

            If blnEstatusTemporal = True Then
                bajaTemporal = 1
            End If
            ' Variables locales
            Dim strSQLStatement As StringBuilder
            Dim intRowsAffected As Integer

            Dim strRowsAffected As String()

            Try
                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spValidarConfiguracionAsistenciasEmpleado ")
                Call strSQLStatement.Append(intEmpleadoId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intVacacionesId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmVacacionesInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmVacacionesFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intDiaSemanaId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(bajaTemporal)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intIncapacidadId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intMotivoIncapacidadId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmIncapacidadInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmIncapacidadFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intPermisoEspecialId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmPermisoInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmPermisoFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")

                ' Ejecutamos el comando
                strValidarConfiguracionAsistenciasEmpleado = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                strValidarConfiguracionAsistenciasEmpleado = Nothing
            End Try
        End Function

        Private Shared Function intGuardarBajaTemporal(ByVal intEmpleadoId As Integer, _
                                                       ByVal blnEstatusTemporal As Boolean, _
                                                       ByVal strBajaTemporalModificadoPor As String, _
                                                       ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intGuardarBajaTemporal"

            ' Variables locales
            Dim strSQLStatement As StringBuilder
            Dim intRowsAffected As Integer
            Dim strRegistros As Array

            Dim strRowsAffected As String()

            Dim bajaTemporal As Int16 = 0

            If blnEstatusTemporal = True Then
                bajaTemporal = 1
            End If

            Try
                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spGuardarBajaTemporal ")
                Call strSQLStatement.Append(intEmpleadoId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(bajaTemporal)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strBajaTemporalModificadoPor)
                Call strSQLStatement.Append("'")

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intGuardarBajaTemporal = intRowsAffected

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                intGuardarBajaTemporal = 0
            End Try
        End Function

        Private Shared Function intGuardarInformacionVacaciones(ByVal intEmpleadoId As Integer, _
                                                               ByVal strModificadoPor As String, _
                                                               ByVal intVacacionesId As Integer, _
                                                               ByVal dtmVacacionesInicio As Date, _
                                                               ByVal dtmVacacionesFin As Date, _
                                                               ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intGuardarInformacionVacaciones"

            ' Variables locales
            Dim strSQLStatement As StringBuilder
            Dim intRowsAffected As Integer
            Dim strRegistros As Array
            Dim strRowsAffected As String()

            Try
                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spGuardarInformacionVacaciones ")
                Call strSQLStatement.Append(intEmpleadoId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strModificadoPor)
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intVacacionesId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmVacacionesInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmVacacionesFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")


                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intGuardarInformacionVacaciones = intRowsAffected

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                intGuardarInformacionVacaciones = 0

            End Try

        End Function

        Private Shared Function intGuardarInformacionIncapacidad(ByVal intIncapacidadId As Integer, _
                                                                 ByVal intEmpleadoId As Integer, _
                                                                 ByVal intMotivoIncapacidadId As Integer, _
                                                                 ByVal dtmIncapacidadInicio As Date, _
                                                                 ByVal dtmIncapacidadFin As Date, _
                                                                 ByVal strFolio As String, _
                                                                 ByVal strObservacionesIncapacidad As String, _
                                                                 ByVal strModificadoPor As String, _
                                                                 ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intGuardarInformacionIncapacidad"

            ' Variables locales
            Dim strSQLStatement As StringBuilder
            Dim intRowsAffected As Integer
            Dim strRegistros As Array
            Dim strRowsAffected As String()

            Try
                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL   
                Call strSQLStatement.Append("EXECUTE spGuardarInformacionIncapacidad ")
                Call strSQLStatement.Append(intIncapacidadId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intEmpleadoId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intMotivoIncapacidadId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmIncapacidadInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmIncapacidadFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strFolio)
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strObservacionesIncapacidad)
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strModificadoPor)
                Call strSQLStatement.Append("'")


                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                For Each strRowsAffected In strRegistros

                    intRowsAffected = CInt(strRowsAffected.GetValue(0))

                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intGuardarInformacionIncapacidad = intRowsAffected

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                intGuardarInformacionIncapacidad = 0

            End Try

        End Function

        Private Shared Function intGuardarInformacionPermisos(ByVal intPermisoEspecialId As Integer, _
                                                              ByVal intEmpleadoId As Integer, _
                                                              ByVal dtmPermisoInicio As Date, _
                                                              ByVal dtmPermisoFin As Date, _
                                                              ByVal blnSueldo As Boolean, _
                                                              ByVal strModificadoPor As String, _
                                                              ByVal strObservacionesPermiso As String, _
                                                              ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intGuardarInformacionPermisos"

            ' Variables locales
            Dim strSQLStatement As StringBuilder
            Dim intRowsAffected As Integer
            Dim strRegistros As Array
            Dim strRowsAffected As String()

            Dim sueldo As Byte = 0
            If blnSueldo Then
                sueldo = 1
            End If
            Try
                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spGuardarInformacionPermisos ")
                Call strSQLStatement.Append(intPermisoEspecialId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intEmpleadoId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmPermisoInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmPermisoFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(sueldo)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strModificadoPor)
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strObservacionesPermiso)
                Call strSQLStatement.Append("'")

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intGuardarInformacionPermisos = intRowsAffected

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                intGuardarInformacionPermisos = 0
            End Try
        End Function

        Private Shared Function intGuardarDiaDescanso(ByVal intEmpleadoId As Integer, _
                                                      ByVal intDiaSemanaId As Integer, _
                                                      ByVal strDiaDescansoModificadoPor As String, _
                                                      ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intGuardarDiaDescanso"

            ' Variables locales
            Dim strSQLStatement As StringBuilder
            Dim intRowsAffected As Integer
            Dim strRegistros As Array
            Dim strRowsAffected As String()

            Try
                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spGuardarDiaDescanso ")
                Call strSQLStatement.Append(intEmpleadoId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intDiaSemanaId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strDiaDescansoModificadoPor)
                Call strSQLStatement.Append("'")

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intGuardarDiaDescanso = intRowsAffected

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                intGuardarDiaDescanso = 0
            End Try
        End Function

        Private Shared Function intGuardarInformacionCapacitacion(ByVal intCapacitacionId As Integer, _
                                                                  ByVal intEmpleadoId As Integer, _
                                                                  ByVal dtmCapacitacionInicio As Date, _
                                                                  ByVal dtmCapacitacionFin As Date, _
                                                                  ByVal strObservacionesCapacitacion As String, _
                                                                  ByVal strModificadoPor As String, _
                                                                  ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intGuardarInformacionCapacitacion"

            ' Variables locales
            Dim strSQLStatement As StringBuilder
            Dim intRowsAffected As Integer
            Dim strRegistros As Array
            Dim strRowsAffected As String()

            Try
                ' Inicializamos las varialbes locales
                strSQLStatement = New StringBuilder

                ' Creamos es estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spGuardarInformacionCapacitacion ")
                Call strSQLStatement.Append(intCapacitacionId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append(intEmpleadoId)
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmCapacitacionInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(dtmCapacitacionFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strObservacionesCapacitacion)
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(",")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strModificadoPor)
                Call strSQLStatement.Append("'")

                ' Ejecutamos el comando
                strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next

                ' Regresamos la información
                strSQLStatement = Nothing
                intGuardarInformacionCapacitacion = intRowsAffected

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As StringBuilder = New StringBuilder
                Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
                Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
                Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
                Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
                Dim strSource As String = objException.Source
                Dim strMessage As String = objException.Message
                Dim strStackTrace As String = objException.StackTrace
                Dim intLineNumber As Integer = Erl()
                Dim intErrorNumber As Integer = Err.Number
                Dim intCategoryNumber As Short = 0

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
                intGuardarInformacionCapacitacion = 0
            End Try
        End Function

        Private Shared Function strDMYtoMDY(ByVal strDDMMYYYY As String) As String
            Dim vntValidDate As Array = Nothing
            Dim strDD, strMM, strYYYY, strAuxiliar As String
            Dim dtmTemporal As Date

            Try
                vntValidDate = Split(Trim(strDDMMYYYY), "/", -1)
                strDD = Trim(CStr(vntValidDate.GetValue(0)))
                strMM = Trim(CStr(vntValidDate.GetValue(1)))
                strYYYY = Trim(CStr(vntValidDate.GetValue(2)))

                If CInt(strMM) > 12 AndAlso CInt(strMM) < 32 AndAlso _
                   CInt(strDD) < 13 AndAlso CInt(strDD) > 0 Then
                    'Mandaron los datos alreves Corregirlos de forma automatica
                    strAuxiliar = strDD
                    strDD = strMM
                    strMM = strAuxiliar
                End If

                dtmTemporal = CDate(strMM & "/" & strDD & "/" & strYYYY)
                Return strMM & "/" & strDD & "/" & strYYYY

            Catch ex As Exception
                dtmTemporal = Date.Now
                Return dtmTemporal.ToString("MM/dd/yyyy")
            End Try

        End Function

    End Class

End Class

