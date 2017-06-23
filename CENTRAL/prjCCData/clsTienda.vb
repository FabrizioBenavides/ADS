Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clsTienda
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Operaciones con Tiendas.
' Copyright     : 2003-2005 Todos los Derechos Reservados.
' Company       : Isocraft S.A. de C.V.
' Author        : Dirección de Tecnología
' Version       : 1.0.1311.33021
' Last Modified : Tuesday, June 1, 2004
'====================================================================
Public NotInheritable Class clsTienda

    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clsTienda"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()
    End Sub

    '====================================================================
    ' Name       : strEjecutarBuscarTiendasSinAsignar
    ' Description: Regresa las tiendas sin asignar a una sucursal
    '             
    ' Parameters :
    '               ByVal intInitialPosition As Integer
    '               ByVal intElemensPerPage As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                Array = { (Col0, Col1, ...,  Coln),
    '                          , ... ,
    '                          (Col0, Col1, ...,  Coln)}
    '====================================================================
    Public Shared Function strEjecutarBuscarTiendasSinAsignar( _
       ByVal intInitialPosition As Integer, _
       ByVal intElemensPerPage As Integer, _
       ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strEjecutarBuscarTiendasSinAsignar"

        ' Variables locales
        Dim strSQLStatement As System.Text.StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarTiendasSinAsignar ")
            Call strSQLStatement.Append(intInitialPosition)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intElemensPerPage)

            ' Ejecutamos el comando
            strEjecutarBuscarTiendasSinAsignar = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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

            ' Regresamos la información
            strSQLStatement = Nothing
            strEjecutarBuscarTiendasSinAsignar = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strBuscarDetalle
    ' Description: Regresa el detalle de una tienda
    '             
    ' Parameters :
    '               ByVal intTiendaId As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                Array = { (Col0, Col1, ...,  Coln),
    '                          , ... ,
    '                          (Col0, Col1, ...,  Coln)}
    '====================================================================
    Public Shared Function strBuscarDetalle( _
       ByVal intTiendaId As Integer, _
       ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarDetalle"

        ' Variables locales
        Dim strSQLStatement As System.Text.StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarDetalleTienda ")
            Call strSQLStatement.Append(intTiendaId)

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

            ' Regresamos la información
            strSQLStatement = Nothing
            strBuscarDetalle = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strBuscarDetalle
    ' Description: Regresa el detalle de una tienda
    '             
    ' Parameters :
    '               ByVal intTiendaId As Integer
    '               ByVal intDireccionId As Integer
    '               ByVal intZonaId As Integer
    '               ByVal intInitialPosition As Integer
    '               ByVal intElemensPerPage As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                Array = { (Col0, Col1, ...,  Coln),
    '                          , ... ,
    '                          (Col0, Col1, ...,  Coln)}
    '====================================================================
    Public Shared Function strBuscarSucursalVinculada( _
       ByVal intTiendaId As Integer, _
       ByVal intDireccionId As Integer, _
       ByVal intZonaId As Integer, _
       ByVal intInitialPosition As Integer, _
       ByVal intElemensPerPage As Integer, _
       ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarSucursalVinculada"

        ' Variables locales
        Dim strSQLStatement As System.Text.StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarSucursalVinculadaTienda ")
            Call strSQLStatement.Append(intTiendaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intDireccionId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intZonaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intInitialPosition)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intElemensPerPage)

            ' Ejecutamos el comando
            strBuscarSucursalVinculada = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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

            ' Regresamos la información
            strSQLStatement = Nothing
            strBuscarSucursalVinculada = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strBuscarTiendasConcentradorDeEnvio
    ' Description: Regresa las Tiendas que deben ser procesadas 
    '              por el concentrador de Envio indicado
    '             
    ' Parameters :
    '               ByVal strConcentradorDeEnvioIp As strinf
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '====================================================================
    Public Shared Function strBuscarTiendasConcentradorDeEnvio ( _
       ByVal strConcentradorDeEnvioIp As String, _
       ByVal strConnectionString As String) As Array


        ' Member identifier
        Const strmThisMemberName As String = "strBuscarTiendasConcentradorDeEnvio"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New System.Text.StringBuilder

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spBuscarTiendasConcentradorDeEnvio ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strConcentradorDeEnvioIp)
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
    ' Class         : clsSucursal
    ' Title         : Grupo Benavides. Administrador POS y Backoffice.
    ' Description   : Operaciones con Sucursales.
    ' Copyright     : 2003-2005 Todos los Derechos Reservados.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Dirección de Tecnología
    ' Version       : 1.0.1311.33021
    ' Last Modified : Tuesday, June 1, 2004
    '====================================================================
    Public NotInheritable Class clsSucursal

        ' Identificador de la clase
        Private Const strmThisClassName As String = "Benavides.CC.Data.clsTienda.clsSucursal"

        ' Constructor en blanco para prevenir la generación de un constructor por defecto
        Private Sub New()
        End Sub


        '====================================================================
        ' Name       : strBuscarMonedas
        ' Description: Regresa las monedas de una sucursal
        ' Parameters :
        '               ByVal intCompaniaId As Integer
        '                   - Identificador de la Compañía
        '               ByVal intSucursalId As String
        '                   - Identificador de la Sucursal
        '               ByVal intPosicionInicial As Integer
        '                   - Primer registro a leer
        '               ByVal intElementos As Integer
        '                   - Registros a leer a partir del primero
        '               ByVal strConnectionString As String
        '                   - Cadena de conexión hacia el RDBMS
        ' Throws     : Exception
        ' Output     : Array
        '              - Arreglo bidimensional con los registros leídos
        '====================================================================
        Public Shared Function strBuscarMonedas( _
           ByVal intCompaniaId As Integer, _
           ByVal intSucursalId As Integer, _
           ByVal intPosicionInicial As Integer, _
           ByVal intElementos As Integer, _
           ByVal strConnectionString As String) As Array

            ' Constantes locales
            Const strmThisMemberName As String = "strBuscarMonedas"

            ' Variables locales
            Dim strSQLStatement As System.Text.StringBuilder = Nothing

            Try
                ' Inicialización de las variables locales
                strSQLStatement = New System.Text.StringBuilder

                ' Creamos estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spBuscarSucursalMonedas ")
                Call strSQLStatement.Append(intCompaniaId)
                Call strSQLStatement.Append(", ")
                Call strSQLStatement.Append(intSucursalId)
                Call strSQLStatement.Append(", ")
                Call strSQLStatement.Append(intPosicionInicial)
                Call strSQLStatement.Append(", ")
                Call strSQLStatement.Append(intElementos)

                ' Ejecutamos el comando
                strBuscarMonedas = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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

                ' Regresamos la información
                strSQLStatement = Nothing
                strBuscarMonedas = Nothing

                ' Notificamos el error
                Throw

            End Try

        End Function

        '====================================================================
        ' Name       : strBuscarMonedasSinAsignar
        ' Description: Regresa las monedas sin asignar a una sucursal
        ' Parameters :
        '               ByVal intCompaniaId As Integer
        '                   - Identificador de la Compañía
        '               ByVal intSucursalId As String
        '                   - Identificador de la Sucursal
        '               ByVal strConnectionString As String
        '                   - Cadena de conexión hacia el RDBMS
        ' Throws     : Exception
        ' Output     : Array
        '              - Arreglo bidimensional con los registros leídos
        '====================================================================
        Public Shared Function strBuscarMonedasSinAsignar( _
           ByVal intCompaniaId As Integer, _
           ByVal intSucursalId As Integer, _
           ByVal strConnectionString As String) As Array

            ' Constantes locales
            Const strmThisMemberName As String = "strBuscarMonedasSinAsignar"

            ' Variables locales
            Dim strSQLStatement As System.Text.StringBuilder = Nothing

            Try
                ' Inicialización de las variables locales
                strSQLStatement = New System.Text.StringBuilder

                ' Creamos estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spBuscarSucursalMonedasSinAsignar ")
                Call strSQLStatement.Append(intCompaniaId)
                Call strSQLStatement.Append(", ")
                Call strSQLStatement.Append(intSucursalId)

                ' Ejecutamos el comando
                strBuscarMonedasSinAsignar = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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

                ' Regresamos la información
                strSQLStatement = Nothing
                strBuscarMonedasSinAsignar = Nothing

                ' Notificamos el error
                Throw

            End Try

        End Function

        '====================================================================
        ' Name       : strBuscarSucursalesConMonedasAsignadas
        ' Description: Regresa las sucursales con monedas asignadas
        ' Parameters :
        '               ByVal intMonedaId As Integer
        '                   - Identificador de la Moneda
        '               ByVal intDireccionOperativaId As String
        '                   - Identificador de la Direccion
        '               ByVal intZonaOperativaId As String
        '                   - Identificador de la Zona
        '               ByVal strConnectionString As String
        '                   - Cadena de conexión hacia el RDBMS
        ' Throws     : Exception
        ' Output     : Array
        '              - Arreglo bidimensional con los registros leídos
        '====================================================================
        Public Shared Function strBuscarSucursalesConMonedasAsignadas( _
           ByVal intMonedaId As Integer, _
           ByVal intDireccionOperativaId As Integer, _
           ByVal intZonaOperativaId As Integer, _
           ByVal strConnectionString As String) As Array

            ' Constantes locales
            Const strmThisMemberName As String = "strBuscarSucursalesConMonedasAsignadas"

            ' Variables locales
            Dim strSQLStatement As System.Text.StringBuilder = Nothing

            Try
                ' Inicialización de las variables locales
                strSQLStatement = New System.Text.StringBuilder

                ' Creamos estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spBuscarSucursalesConMonedasAsignadas ")
                Call strSQLStatement.Append(intMonedaId)
                Call strSQLStatement.Append(", ")
                Call strSQLStatement.Append(intDireccionOperativaId)
                Call strSQLStatement.Append(", ")
                Call strSQLStatement.Append(intZonaOperativaId)

                ' Ejecutamos el comando
                strBuscarSucursalesConMonedasAsignadas = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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

                ' Regresamos la información
                strSQLStatement = Nothing
                strBuscarSucursalesConMonedasAsignadas = Nothing

                ' Notificamos el error
                Throw

            End Try

        End Function

        '====================================================================
        ' Name       : strBuscarTipoDeCambioMonedaxUbicacion
        ' Description: Regresa las sucursales con monedas asignadas
        ' Parameters :
        '               ByVal intMonedaId As Integer
        '                   - Identificador de la Moneda
        '               ByVal intUbicacionSucursalIdAs As String
        '                   - Identificador de la Zona
        '               ByVal strConnectionString As String
        '                   - Cadena de conexión hacia el RDBMS
        ' Throws     : Exception
        ' Output     : Array
        '              - Arreglo bidimensional con los registros leídos
        '====================================================================
        Public Shared Function strBuscarTipoDeCambioMonedaxUbicacion( _
           ByVal intMonedaCambioId As Integer, _
           ByVal intMonedaBaseId As Integer, _
           ByVal intUbicacionSucursalId As Integer, _
           ByVal intPosicionInicial As Integer, _
           ByVal intElementos As Integer, _
           ByVal strConnectionString As String) As Array

            ' Constantes locales
            Const strmThisMemberName As String = "strBuscarTipoDeCambioMonedaxUbicacion"

            ' Variables locales
            Dim strSQLStatement As System.Text.StringBuilder = Nothing

            Try
                ' Inicialización de las variables locales
                strSQLStatement = New System.Text.StringBuilder

                ' Creamos estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spBuscarTipoDeCambioMonedaxUbicacion ")
                Call strSQLStatement.Append(intMonedaCambioId)
                Call strSQLStatement.Append(", ")
                Call strSQLStatement.Append(intMonedaBaseId)
                Call strSQLStatement.Append(", ")
                Call strSQLStatement.Append(intUbicacionSucursalId)
                Call strSQLStatement.Append(", ")
                Call strSQLStatement.Append(intPosicionInicial)
                Call strSQLStatement.Append(", ")
                Call strSQLStatement.Append(intElementos)


                ' Ejecutamos el comando
                strBuscarTipoDeCambioMonedaxUbicacion = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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

                ' Regresamos la información
                strSQLStatement = Nothing
                strBuscarTipoDeCambioMonedaxUbicacion = Nothing

                ' Notificamos el error
                Throw

            End Try

        End Function
        '====================================================================
        ' Name       : intActualizarTipoDeCambioMonedaxUbicacion
        ' Description: Actualiza el tipo de cambio segun la ubicacion de la sucursal
        ' Parameters :
        '               ByVal intCompaniaId As Integer
        '                   - Identificador de la Compañía
        '               ByVal intSucursalId As String
        '                   - Identificador de la Sucursal
        '               ByVal intTiendaId As Integer
        '                   - Identificador de la Tienda
        '               ByVal strSucursalModificadoPor As String
        '                   - Usuario que modifico el Registro
        '               ByVal strConnectionString As String
        '                   - Cadena de conexión hacia el RDBMS
        ' Throws     : Exception
        ' Output     : Integer
        '              - Resultado de la operación
        '====================================================================

        Public Shared Function intActualizarTipoDeCambioMonedaxUbicacion( _
           ByVal intMonedaCambioId As Integer, _
           ByVal intMonedaBaseId As Integer, _
           ByVal intUbicacionSucursalId As Integer, _
           ByVal fltTipoDeCambioMonedaValor As Double, _
           ByVal strTipoDeCambioMonedaModificadoPor As String, _
           ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intActualizarTipoDeCambioMonedaxUbicacion"

            ' Variables locales
            Dim strSQLStatement As System.Text.StringBuilder = Nothing
            Dim intRowsAffected As Integer = 0, strRowsAffected As String(), strRegistros As Array

            Try
                ' Inicialización de las variables locales
                strSQLStatement = New System.Text.StringBuilder

                ' Creamos estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spActualizarTipoDeCambioMonedaxUbicacion ")
                Call strSQLStatement.Append(intMonedaCambioId)
                Call strSQLStatement.Append(", ")
                Call strSQLStatement.Append(intMonedaBaseId)
                Call strSQLStatement.Append(", ")
                Call strSQLStatement.Append(intUbicacionSucursalId)
                Call strSQLStatement.Append(", ")
                Call strSQLStatement.Append(fltTipoDeCambioMonedaValor)
                Call strSQLStatement.Append(", '")
                Call strSQLStatement.Append(strTipoDeCambioMonedaModificadoPor)
                Call strSQLStatement.Append("'")

                ' Ejecutamos el comando
                strRegistros = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next

                intActualizarTipoDeCambioMonedaxUbicacion = intRowsAffected

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

                ' Regresamos la información
                strSQLStatement = Nothing

                intActualizarTipoDeCambioMonedaxUbicacion = Nothing

                ' Notificamos el error
                Throw

            End Try

        End Function


        '====================================================================
        ' Name       : intDesvincularTiendaSucursal
        ' Description: Elimina la tienda de una Sucursal
        ' Parameters :
        '               ByVal intCompaniaId As Integer
        '                   - Identificador de la Compañía
        '               ByVal intSucursalId As String
        '                   - Identificador de la Sucursal
        '               ByVal intTiendaId As Integer
        '                   - Identificador de la Tienda
        '               ByVal strSucursalModificadoPor As String
        '                   - Usuario que modifico el Registro
        '               ByVal strConnectionString As String
        '                   - Cadena de conexión hacia el RDBMS
        ' Throws     : Exception
        ' Output     : Integer
        '              - Resultado de la operación
        '====================================================================
        Public Shared Function intDesvincularTienda( _
           ByVal intCompaniaId As Integer, _
           ByVal intSucursalId As Integer, _
           ByVal intTiendaId As Integer, _
           ByVal strSucursalModificadoPor As String, _
           ByVal strConnectionString As String) As Integer

            ' Constantes locales
            Const strmThisMemberName As String = "intDesvincularTiendaSucursal"

            ' Variables locales
            Dim strSQLStatement As System.Text.StringBuilder = Nothing
            Dim intRowsAffected As Integer = 0, strRowsAffected As String(), strRegistros As Array

            Try
                ' Inicialización de las variables locales
                strSQLStatement = New System.Text.StringBuilder

                ' Creamos estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spDesvincularTiendaSucursal ")
                Call strSQLStatement.Append(intCompaniaId)
                Call strSQLStatement.Append(", ")
                Call strSQLStatement.Append(intSucursalId)
                Call strSQLStatement.Append(", ")
                Call strSQLStatement.Append(intTiendaId)
                Call strSQLStatement.Append(", '")
                Call strSQLStatement.Append(strSucursalModificadoPor)
                Call strSQLStatement.Append("'")

                ' Ejecutamos el comando
                strRegistros = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next

                intDesvincularTienda = intRowsAffected

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

                ' Regresamos la información
                strSQLStatement = Nothing
                intDesvincularTienda = Nothing

                ' Notificamos el error
                Throw

            End Try

        End Function

        '====================================================================
        ' Name       : strBuscarSinTiendaAsignada
        ' Description: Regresa las monedas sin asignar a una sucursal
        ' Parameters :
        '               ByVal intDireccionId As Integer
        '                   - Identificador de la Direccion Operativa
        '               ByVal intZonaId As String
        '                   - Identificador de la Zona Operativa
        '               ByVal strConnectionString As String
        '                   - Cadena de conexión hacia el RDBMS
        ' Throws     : Exception
        ' Output     : Array
        '              - Arreglo bidimensional con los registros leídos
        '====================================================================
        Public Shared Function strBuscarSinTiendaAsignada( _
           ByVal strNombreSucursal As String, _
           ByVal intDireccionId As Integer, _
           ByVal intZonaId As Integer, _
           ByVal strConnectionString As String) As Array

            ' Constantes locales
            Const strmThisMemberName As String = "strBuscarSinTiendaAsignada"

            ' Variables locales
            Dim strSQLStatement As System.Text.StringBuilder = Nothing

            Try
                ' Inicialización de las variables locales
                strSQLStatement = New System.Text.StringBuilder

                ' Creamos estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spBuscarSucursalSinTienda ")
                Call strSQLStatement.Append(" '")
                Call strSQLStatement.Append(strNombreSucursal)
                Call strSQLStatement.Append("' , ")
                Call strSQLStatement.Append(intDireccionId)
                Call strSQLStatement.Append(", ")
                Call strSQLStatement.Append(intZonaId)

                ' Ejecutamos el comando
                strBuscarSinTiendaAsignada = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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

                ' Regresamos la información
                strSQLStatement = Nothing
                strBuscarSinTiendaAsignada = Nothing

                ' Notificamos el error
                Throw

            End Try

        End Function

        '====================================================================
        ' Name       : strBuscarActivaPorNombre
        ' Description: Regresa las sucursales activas 
        ' Parameters :
        '               ByVal strSucursalNombre As String
        '                   - Nombre de la sucursal a buscar
        '               ByVal strConnectionString As String
        '                   - Cadena de conexión hacia el RDBMS
        ' Throws     : Exception
        ' Output     : Array
        '              - Arreglo bidimensional con los registros leídos
        '====================================================================
        Public Shared Function strBuscarActivaPorNombre( _
           ByVal strSucursalNombre As String, _
           ByVal strConnectionString As String) As Array

            ' Constantes locales
            Const strmThisMemberName As String = "strBuscarActivaPorNombre"

            ' Variables locales
            Dim strSQLStatement As System.Text.StringBuilder = Nothing

            Try
                ' Inicialización de las variables locales
                strSQLStatement = New System.Text.StringBuilder

                ' Creamos estatuto de SQL
                Call strSQLStatement.Append("EXECUTE spBuscarSucursalActiva ")
                Call strSQLStatement.Append("'")
                Call strSQLStatement.Append(strSucursalNombre)
                Call strSQLStatement.Append("'")

                ' Ejecutamos el comando
                strBuscarActivaPorNombre = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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

                ' Regresamos la información
                strSQLStatement = Nothing
                strBuscarActivaPorNombre = Nothing

                ' Notificamos el error
                Throw

            End Try

        End Function

        Public Shared Function aobjObtenerFondoFijoGastado(ByVal intDireccionOperativaId As Integer, _
                                                           ByVal intZonaOperativaId As Integer, _
                                                           ByVal intMes As Integer, _
                                                           ByVal intAnio As Integer, _
                                                           ByVal intPosicionInicial As Integer, _
                                                           ByVal intElementosPorPagina As Integer, _
                                                           ByVal strConnectionString As String) As Array

            ' Constantes locales 
            Const strmThisMemberName As String = "aobjObtenerFondoFijoGastado"

            ' Variables locales
            Dim strSQLStatement As System.Text.StringBuilder = Nothing

            Try

                ' Inicialización de las variables locales
                strSQLStatement = New System.Text.StringBuilder

                ' Creamos estatuto de SQL
                Call strSQLStatement.AppendFormat("EXECUTE spObtenerFondoFijoGastadoPorDireccionZona '{0}', '{1}', '{2}', '{3}', '{4}', '{5}'", intDireccionOperativaId, intZonaOperativaId, intMes, intAnio, intPosicionInicial, intElementosPorPagina)

                ' Ejecutamos el comando
                aobjObtenerFondoFijoGastado = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString, strConnectionString)
                strSQLStatement = Nothing

            Catch objException As Exception

                ' Variables locales
                Dim strErrorString As System.Text.StringBuilder = New System.Text.StringBuilder
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
                strSQLStatement = Nothing
                aobjObtenerFondoFijoGastado = Nothing

                ' Notificamos el error
                Throw

            End Try

        End Function


        '====================================================================
        ' Class         : clsPuntoVenta
        ' Title         : Grupo Benavides. Administrador POS y Backoffice.
        ' Description   : Clases para el mantenimiento de datos.
        ' Copyright     : 2003-2006 All rights reserved.
        ' Company       : Isocraft S.A. de C.V.
        ' Author        : Dirección de Tecnología
        ' Version       : 1.0
        ' Last Modified : Thursday, Ago 18, 2003
        '====================================================================
        Public NotInheritable Class clsPuntoVenta

            ' Identificador de la clase
            Private Const strmThisClassName As String = "Benavides.CC.Data.clsTienda.clsSucursal.clsPuntoVenta"

            ' Constructor en blanco para prevenir la generación de un constructor por defecto
            Private Sub New()
            End Sub

            '====================================================================
            ' Name       : strEjecutarBuscarCajasInhabilitadas
            ' Description: Consulta las cajas inhabilitadas de un punto de venta
            ' Parameters : 

            '              ByVal dtmFechaInicial As Date
            '                 - 
            '              ByVal dtmFechaFinal As Date
            '                 - 
            '              ByVal intPosicionInicial As Integer
            '                 - 
            '              ByVal intElementos As Integer
            '              ByVal strConnectionString As String
            '                 - Cadena de conexión hacia el RDBMS
            ' Throws     : Exception
            ' Output     : String
            '                 - Mensaje conteniendo el Ticket
            '====================================================================
            Public Shared Function strEjecutarBuscarCajasInhabilitadas( _
                ByVal dtmFechaInicial As Date, _
                ByVal dtmFechaFinal As Date, _
                ByVal intPosicionInicial As Integer, _
                ByVal intElementos As Double, _
                ByVal strConnectionString As String) As Array

                ' Constantes locales
                Const strmThisMemberName As String = "strEjecutarBuscarCajasInhabilitadas"

                ' Variables locales
                Dim strSQLStatement As System.Text.StringBuilder = Nothing

                Try

                    ' Inicializamos las varialbes locales
                    strSQLStatement = New System.Text.StringBuilder

                    ' Creamos es estatuto de SQL
                    Call strSQLStatement.Append("EXECUTE spBuscarCajasInhabilitadas ")
                    Call strSQLStatement.Append("'")
                    Call strSQLStatement.Append(dtmFechaInicial)
                    Call strSQLStatement.Append("'")
                    Call strSQLStatement.Append(",")
                    Call strSQLStatement.Append("'")
                    Call strSQLStatement.Append(dtmFechaFinal)
                    Call strSQLStatement.Append("'")
                    Call strSQLStatement.Append(",")
                    Call strSQLStatement.Append(intPosicionInicial)
                    Call strSQLStatement.Append(",")
                    Call strSQLStatement.Append(intElementos)

                    ' Ejecutamos el comando
                    strEjecutarBuscarCajasInhabilitadas = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

                    ' Eliminamos los objetos creados
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

                    ' Regresamos la información
                    strEjecutarBuscarCajasInhabilitadas = Nothing

                End Try

            End Function

        End Class

        
        

    End Class

End Class
