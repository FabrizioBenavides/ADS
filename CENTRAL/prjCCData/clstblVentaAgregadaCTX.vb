
Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clstblVentaAgregadaCtx
' Title         : Basicos
' Description   : Mantenimiento a tablas
' Company       : SErvicios Operacionales Benavides
' Author        : Desarrollo POS
' Version       : 1.0
' Last Modified : Miércoles, 31 de Mayo de 2006
'====================================================================
Public NotInheritable Class clstblVentaAgregadaCtx

    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblVentaAgregadaCtx"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()
    End Sub

    '====================================================================
    ' Name       : intActualizar
    ' Description: Actualización de registros.
    '                 - Tabla tblVentaAgregadaCtx
    ' Parameters : 
    '              ByVal intCompaniaId As Double
    '                 - Identificador de la compania
    '              ByVal intSucursalId As Double
    '                 -  Identificador de la sucursal
    '              ByVal dtmFechaTrasmision As Date
    '                 - Fecha en la que se recibió la Venta Agregada al CTX
    '              ByVal dtmFechaContable As Date
    '                 - Fecha Contable o fecha de la venta
    '              ByVal intTrasmitio As Integer
    '                 -   0:No transmitió   1: Si transmitió 2:Generó interfase  
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================
    Shared Function intActualizar( _
                ByVal intCompaniaId As Integer, _
                ByVal intSucursalId As Integer, _
                ByVal dtmFechaTrasmision As Date, _
                ByVal dtmFechaContable As Date, _
                ByVal intTrasmitio As Integer, _
                ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intActualizar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0, strRowsAffected As String(), strRegistros As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spActualizartblVentaAgregadaCtx ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaTrasmision.ToString("MM/dd/yyyy"))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaContable.ToString("MM/dd/yyyy"))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTrasmitio)

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

        End Try

    End Function

    '====================================================================
    ' Name       : intAgregar
    ' Description: Adición de registros.
    '                  - Tabla tblVentaAgregadaCtx
    ' Parameters : 
    '              ByVal intCompaniaId As Double
    '                 - Identificador de la compania
    '              ByVal intSucursalId As Double
    '                 -  Identificador de la sucursal
    '              ByVal dtmFechaTrasmision As Date
    '                 - Fecha en la que se recibió la Venta Agregada al CTX
    '              ByVal dtmFechaContable As Date
    '                 - Fecha Contable o fecha de la venta
    '              ByVal intTrasmitio As Integer
    '                 -  0:No transmitió   1: Si transmitió 2:Generó interfase     
    '              ByVal strConnectionString As String
    '                  - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================        
    Shared Function intAgregar( _
                ByVal intCompaniaId As Integer, _
                ByVal intSucursalId As Integer, _
                ByVal dtmFechaTrasmision As Date, _
                ByVal dtmFechaContable As Date, _
                ByVal intTrasmitio As Integer, _
                ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intAgregar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0, strRowsAffected As String(), strRegistros As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spAgregartblVentaAgregadaCtx ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaTrasmision.ToString("MM/dd/yyyy"))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaContable.ToString("MM/dd/yyyy"))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTrasmitio)

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

        End Try

    End Function

    '====================================================================
    ' Name       : strBuscar
    ' Description: Búsqueda de registros.
    '                 - Tabla tblVentaAgregadaCtx
    ' Parameters : 
    '              ByVal intCompaniaId As Double
    '                 - Identificador de la compania
    '              ByVal intSucursalId As Double
    '                 -  Identificador de la sucursal
    '              ByVal dtmFechaContable As Date
    '                 - Fecha Contable o fecha de la venta
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
            ByVal intCompaniaId As Integer, _
            ByVal intSucursalId As Integer, _
            ByVal dtmFechaContable As Date, _
            ByVal intPosicionInicial As Integer, _
            ByVal intElementos As Integer, _
            ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscartblVentaAgregadaCtx ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaContable.ToString("MM/dd/yyyy"))
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

        End Try

    End Function

    '====================================================================
    ' Name       : intContar
    ' Description: Contar los registros.
    '                 - Tabla tblVentaAgregadaCtx
    ' Parameters : 
    '              ByVal intCompaniaId As Double
    '                 - Identificador de la compania
    '              ByVal intSucursalId As Double
    '                 -  Identificador de la sucursal
    '              ByVal dtmFechaTrasmision As Date
    '                 - Fecha en la que se recibió la Venta Agregada al CTX
    '              ByVal dtmFechaContable As Date
    '                 - Fecha Contable o fecha de la venta
    '              ByVal intTrasmitio As Integer
    '                 -  0:No transmitió   1: Si transmitió 2:Generó interfase 
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros en la tabla
    '====================================================================
    Shared Function intContar( _
            ByVal intCompaniaId As Double, _
            ByVal intSucursalId As Double, _
            ByVal dtmFechaTrasmision As Date, _
            ByVal dtmFechaContable As Date, _
            ByVal intTrasmitio As Integer, _
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
            Call strSQLStatement.Append("EXECUTE spContartblVentaAgregadaCtx ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaTrasmision.ToString("MM/dd/yyyy"))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaContable.ToString("MM/dd/yyyy"))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTrasmitio)

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

        End Try

    End Function


    '====================================================================
    ' Name       : intEliminar
    ' Description: Eliminación de registros.
    '                 - Tabla tblVentaAgregadaCtx
    ' Parameters : 
    '              ByVal intCompaniaId As Double
    '                 - Identificador de la compania
    '              ByVal intSucursalId As Double
    '                 -  Identificador de la sucursal
    '              ByVal dtmFechaTrasmision As Date
    '                 - Fecha en la que se recibió la Venta Agregada al CTX
    '              ByVal dtmFechaContable As Date
    '                 - Fecha Contable o fecha de la venta
    '              ByVal intTrasmitio As Integer
    '                 -  0:No transmitió   1: Si transmitió 2:Generó interfase     
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================        
    Shared Function intEliminar( _
            ByVal intCompaniaId As Double, _
            ByVal intSucursalId As Double, _
            ByVal dtmFechaTrasmision As Date, _
            ByVal dtmFechaContable As Date, _
            ByVal intTrasmitio As Integer, _
            ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intEliminar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0, strRowsAffected As String(), strRegistros As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spEliminartblVentaAgregadaCtx ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaTrasmision.ToString("MM/dd/yyyy"))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaContable.ToString("MM/dd/yyyy"))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTrasmitio)

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

        End Try

    End Function

End Class



