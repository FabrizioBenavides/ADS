'====================================================================
' Class         : clsVentaAgregada
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Operaciones con Venta Agregada
' Copyright     : 2006  Todos los Derechos Reservados.
' Company       : Isocraft S.A. de C.V.
' Author        : Dirección de Tecnología
' Version       : 1.0.1311.33021
' Last Modified : Tuesday, June 1, 2004
'====================================================================
Public NotInheritable Class clsVentaAgregada

    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clsVentaAgregada"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()
    End Sub

    '====================================================================
    ' Name       : strEjecutarBuscarTransmisionesVentaAgregada
    ' Description: Regresa las transmisiones pendientes por sucursal
    '             
    ' Parameters :
    '               ByVal intDireccionOperativaId As Integer
    '               ByVal intZonaOperativaId As Integer
    '               ByVal intCompaniaId As Integer
    '               ByVal intSucursalId As Integer
    '               ByVal dtmFechaInicio As Integer
    '               ByVal dtmFechaFinal As Integer
    '               ByVal intTransmitio As String
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
    Public Shared Function strBuscarTransmisiones( _
       ByVal intDireccionOperativaId As Integer, _
       ByVal intZonaOperativaId As Integer, _
       ByVal intCompaniaId As Integer, _
       ByVal intSucursalId As Integer, _
       ByVal dtmFechaInicio As Date, _
       ByVal dtmFechaFinal As Date, _
       ByVal intVentaAgregadaPendiente As Integer, _
       ByVal intInitialPosition As Integer, _
       ByVal intElemensPerPage As Integer, _
       ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarTransmisiones"

        ' Variables locales
        Dim strSQLStatement As System.Text.StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarTransmisionesVentaAgregadaSucursales ")
            Call strSQLStatement.Append(intDireccionOperativaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intZonaOperativaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaInicio)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaFinal)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intVentaAgregadaPendiente)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intInitialPosition)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intElemensPerPage)

            ' Ejecutamos el comando
            strBuscarTransmisiones = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strBuscarTransmisiones = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strEjecutarBuscarTransmisionesVentaAgregada
    ' Description: Regresa las transmisiones pendientes por sucursal
    '             
    ' Parameters :
    '               ByVal intDireccionOperativaId As Integer
    '               ByVal intZonaOperativaId As Integer
    '               ByVal intCompaniaId As Integer
    '               ByVal intSucursalId As Integer
    '               ByVal dtmFechaInicio As Integer
    '               ByVal dtmFechaFinal As Integer
    '               ByVal intTransmitio As String
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
    Public Shared Function strBuscarInterfaz( _
       ByVal intCompaniaId As Integer, _
       ByVal intSucursalId As Integer, _
       ByVal dtmFechaInicio As Date, _
       ByVal dtmFechaFinal As Date, _
       ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarInterfaz"

        ' Variables locales
        Dim strSQLStatement As System.Text.StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarInterfazVentaAgregadaSucursales ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaInicio)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaFinal)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strBuscarInterfaz = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strBuscarInterfaz = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function


End Class
