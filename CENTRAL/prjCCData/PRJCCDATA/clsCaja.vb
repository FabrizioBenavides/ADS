Imports System.Text
'====================================================================
' Class         : clsCaja
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Operaciones con Cajas.
' Copyright     : 2003-2005 Todos los Derechos Reservados.
' Company       : Isocraft S.A. de C.V.
' Author        : Direcci�n de Tecnolog�a
' Version       : 1.0.1311.33021
' Last Modified : Tuesday, June 1, 2004
'====================================================================
Public NotInheritable Class clsCaja

    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clsCaja"

    ' Constructor en blanco para prevenir la generaci�n de un constructor por defecto
    Private Sub New()
    End Sub

    '====================================================================
    ' Name       : strEjecutarBuscarCortesEnCeroPorCaja
    ' Description: Regresa los cortes en cero por caja
    '             
    ' Parameters :
    '               ByVal dtmFechaInicial As Date
    '               ByVal dtmFechaFinal As Date
    '               ByVal intInitialPosition As Integer
    '               ByVal intElementsPerPage As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros le�dos
    '                Array = { (Col0, Col1, ...,  Coln),
    '                          , ... ,
    '                          (Col0, Col1, ...,  Coln)}
    '====================================================================
    Public Shared Function strEjecutarBuscarCortesEnCeroPorCaja( _
       ByVal intDireccionOperativaId As Integer, _
       ByVal intZonaOperativaId As Integer, _
       ByVal intCompaniaId As Integer, _
       ByVal intSucursalId As Integer, _
       ByVal intCajaId As Integer, _
       ByVal dtmFechaInicial As Date, _
       ByVal dtmFechaFinal As Date, _
       ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strEjecutarBuscarCortesEnCeroPorCaja"

        ' Variables locales
        Dim strSQLStatement As System.Text.StringBuilder = Nothing

        Try
            ' Inicializaci�n de las variables locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarCortesEnCeroPorCaja ")
            Call strSQLStatement.Append(intDireccionOperativaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intZonaOperativaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intCajaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaInicial)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaFinal)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strEjecutarBuscarCortesEnCeroPorCaja = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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

            ' Regresamos la informaci�n
            strSQLStatement = Nothing
            strEjecutarBuscarCortesEnCeroPorCaja = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strEjecutarBuscarCortesEnCeroPorSucursal
    ' Description: Regresa los cortes en cero por sucursal
    '             
    ' Parameters :
    '               ByVal dtmFechaInicial As Date
    '               ByVal dtmFechaFinal As Date
    '               ByVal intInitialPosition As Integer
    '               ByVal intElementsPerPage As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros le�dos
    '                Array = { (Col0, Col1, ...,  Coln),
    '                          , ... ,
    '                          (Col0, Col1, ...,  Coln)}
    '====================================================================
    Public Shared Function strEjecutarBuscarCortesEnCeroPorSucursal( _
       ByVal intDireccionOperativaId As Integer, _
       ByVal intZonaOperativaId As Integer, _
       ByVal intCompaniaId As Integer, _
       ByVal intSucursalId As Integer, _
       ByVal dtmFechaInicial As Date, _
       ByVal dtmFechaFinal As Date, _
       ByVal intInitialPosition As Integer, _
       ByVal intElementsPerPage As Integer, _
       ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strEjecutarBuscarCortesEnCeroPorSucursal"

        ' Variables locales
        Dim strSQLStatement As System.Text.StringBuilder = Nothing

        Try
            ' Inicializaci�n de las variables locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarCortesEnCeroPorSucursal ")
            Call strSQLStatement.Append(intDireccionOperativaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intZonaOperativaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaInicial)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaFinal)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intInitialPosition)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intElementsPerPage)

            ' Ejecutamos el comando
            strEjecutarBuscarCortesEnCeroPorSucursal = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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

            ' Regresamos la informaci�n
            strSQLStatement = Nothing
            strEjecutarBuscarCortesEnCeroPorSucursal = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strEjecutarBuscarCortesEnCeroPorZona
    ' Description: Regresa los cortes en cero por zona
    '             
    ' Parameters :
    '               ByVal dtmFechaInicial As Date
    '               ByVal dtmFechaFinal As Date
    '               ByVal intInitialPosition As Integer
    '               ByVal intElementsPerPage As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros le�dos
    '                Array = { (Col0, Col1, ...,  Coln),
    '                          , ... ,
    '                          (Col0, Col1, ...,  Coln)}
    '====================================================================
    Public Shared Function strEjecutarBuscarCortesEnCeroPorZona( _
       ByVal intDireccionOperativaId As Integer, _
       ByVal intZonaOperativaId As Integer, _
       ByVal dtmFechaInicial As Date, _
       ByVal dtmFechaFinal As Date, _
       ByVal intInitialPosition As Integer, _
       ByVal intElementsPerPage As Integer, _
       ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strEjecutarBuscarCortesEnCeroPorZona"

        ' Variables locales
        Dim strSQLStatement As System.Text.StringBuilder = Nothing

        Try
            ' Inicializaci�n de las variables locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarCortesEnCeroPorZona ")
            Call strSQLStatement.Append(intDireccionOperativaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intZonaOperativaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaInicial)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaFinal)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intInitialPosition)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intElementsPerPage)

            ' Ejecutamos el comando
            strEjecutarBuscarCortesEnCeroPorZona = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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

            ' Regresamos la informaci�n
            strSQLStatement = Nothing
            strEjecutarBuscarCortesEnCeroPorZona = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strEjecutarBuscarCortesEnCeroPorDireccion
    ' Description: Regresa los cortes en cero por direcci�n
    '             
    ' Parameters :
    '               ByVal dtmFechaInicial As Date
    '               ByVal dtmFechaFinal As Date
    '               ByVal intInitialPosition As Integer
    '               ByVal intElementsPerPage As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros le�dos
    '                Array = { (Col0, Col1, ...,  Coln),
    '                          , ... ,
    '                          (Col0, Col1, ...,  Coln)}
    '====================================================================
    Public Shared Function strEjecutarBuscarCortesEnCeroPorDireccion( _
       ByVal intDireccionOperativaId As Integer, _
       ByVal dtmFechaInicial As Date, _
       ByVal dtmFechaFinal As Date, _
       ByVal intInitialPosition As Integer, _
       ByVal intElementsPerPage As Integer, _
       ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strEjecutarBuscarCortesEnCeroPorDireccion"

        ' Variables locales
        Dim strSQLStatement As System.Text.StringBuilder = Nothing

        Try
            ' Inicializaci�n de las variables locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarCortesEnCeroPorDireccion ")
            Call strSQLStatement.Append(intDireccionOperativaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaInicial)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaFinal)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intInitialPosition)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intElementsPerPage)

            ' Ejecutamos el comando
            strEjecutarBuscarCortesEnCeroPorDireccion = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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

            ' Regresamos la informaci�n
            strSQLStatement = Nothing
            strEjecutarBuscarCortesEnCeroPorDireccion = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strEjecutarBuscarCortesEnCeroDelGrupo
    ' Description: Regresa los cortes en cero por grupo
    '             
    ' Parameters :
    '               ByVal dtmFechaInicial As Date
    '               ByVal dtmFechaFinal As Date
    '               ByVal intInitialPosition As Integer
    '               ByVal intElementsPerPage As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros le�dos
    '                Array = { (Col0, Col1, ...,  Coln),
    '                          , ... ,
    '                          (Col0, Col1, ...,  Coln)}
    '====================================================================
    Public Shared Function strEjecutarBuscarCortesEnCeroDelGrupo( _
       ByVal dtmFechaInicial As Date, _
       ByVal dtmFechaFinal As Date, _
       ByVal intInitialPosition As Integer, _
       ByVal intElementsPerPage As Integer, _
       ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strEjecutarBuscarCortesEnCeroDelGrupo"

        ' Variables locales
        Dim strSQLStatement As System.Text.StringBuilder = Nothing

        Try
            ' Inicializaci�n de las variables locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarCortesEnCeroDelGrupo ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaInicial)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaFinal)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intInitialPosition)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intElementsPerPage)

            ' Ejecutamos el comando
            strEjecutarBuscarCortesEnCeroDelGrupo = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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

            ' Regresamos la informaci�n
            strSQLStatement = Nothing
            strEjecutarBuscarCortesEnCeroDelGrupo = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strBuscarDetalle
    ' Description: Regresa el detalle de las cajas de una sucursal
    '             
    ' Parameters :
    '               ByVal intCompaniaId As Integer
    '               ByVal intSucursalId As Integer
    '               ByVal intCajaId     As Integer
    '               ByVal intInitialPosition As Integer
    '               ByVal intElementsPerPage As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros le�dos
    '                Array = { (Col0, Col1, ...,  Coln),
    '                          , ... ,
    '                          (Col0, Col1, ...,  Coln)}
    '====================================================================
    Public Shared Function strBuscarDetalle( _
       ByVal intCompaniaId As Integer, _
       ByVal intSucursalId As Integer, _
       ByVal intCajaId As Integer, _
       ByVal intInitialPosition As Integer, _
       ByVal intElementsPerPage As Integer, _
       ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarDetalle"

        ' Variables locales
        Dim strSQLStatement As System.Text.StringBuilder = Nothing

        Try
            ' Inicializaci�n de las variables locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarDetalleCaja ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intCajaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intInitialPosition)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intElementsPerPage)


            ' Ejecutamos el comando
            strBuscarDetalle = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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

            ' Regresamos la informaci�n
            strSQLStatement = Nothing
            strBuscarDetalle = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strEjecutarBuscarCajasInhabilitadasPorDireccion
    ' Description: Regresa las cajas inhabilitadas de una direcci�n
    '             
    ' Parameters :
    '               ByVal intCompaniaId As Integer
    '               ByVal intSucursalId As Integer
    '               ByVal intCajaId     As Integer
    '               ByVal intInitialPosition As Integer
    '               ByVal intElementsPerPage As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros le�dos
    '                Array = { (Col0, Col1, ...,  Coln),
    '                          , ... ,
    '                          (Col0, Col1, ...,  Coln)}
    '====================================================================
    Public Shared Function strEjecutarBuscarCajasInhabilitadasPorDireccion( _
       ByVal intDireccionOperativaId As Integer, _
       ByVal dtmFechaInicial As Date, _
       ByVal dtmFechaFinal As Date, _
       ByVal intInitialPosition As Integer, _
       ByVal intElementsPerPage As Integer, _
       ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strEjecutarBuscarCajasInhabilitadasPorDireccion"

        ' Variables locales
        Dim strSQLStatement As System.Text.StringBuilder = Nothing

        Try
            ' Inicializaci�n de las variables locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarCajasInhabilitadasPorDireccion ")
            Call strSQLStatement.Append(intDireccionOperativaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaInicial)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaFinal)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intInitialPosition)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intElementsPerPage)

            ' Ejecutamos el comando
            strEjecutarBuscarCajasInhabilitadasPorDireccion = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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

            ' Regresamos la informaci�n
            strSQLStatement = Nothing
            strEjecutarBuscarCajasInhabilitadasPorDireccion = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strEjecutarBuscarCajasInhabilitadasPorZona
    ' Description: Regresa las cajas inhabilitadas de una zona
    '             
    ' Parameters :
    '               ByVal intDireccionOperativaId As Integer
    '               ByVal intZonaOperativaId As Integer
    '               ByVal dtmFechaInicial     As Integer
    '               ByVal dtmFechaFinal As Integer
    '               ByVal intInitialPosition As Integer
    '               ByVal intElementsPerPage As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros le�dos
    '                Array = { (Col0, Col1, ...,  Coln),
    '                          , ... ,
    '                          (Col0, Col1, ...,  Coln)}
    '====================================================================
    Public Shared Function strEjecutarBuscarCajasInhabilitadasPorZona( _
       ByVal intDireccionOperativaId As Integer, _
       ByVal intZonaOperativaId As Integer, _
       ByVal dtmFechaInicial As Date, _
       ByVal dtmFechaFinal As Date, _
       ByVal intInitialPosition As Integer, _
       ByVal intElementsPerPage As Integer, _
       ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strEjecutarBuscarCajasInhabilitadasPorZona"

        ' Variables locales
        Dim strSQLStatement As System.Text.StringBuilder = Nothing

        Try
            ' Inicializaci�n de las variables locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarCajasInhabilitadasPorZona ")
            Call strSQLStatement.Append(intDireccionOperativaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intZonaOperativaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaInicial)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaFinal)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intInitialPosition)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intElementsPerPage)

            ' Ejecutamos el comando
            strEjecutarBuscarCajasInhabilitadasPorZona = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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

            ' Regresamos la informaci�n
            strSQLStatement = Nothing
            strEjecutarBuscarCajasInhabilitadasPorZona = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

End Class

