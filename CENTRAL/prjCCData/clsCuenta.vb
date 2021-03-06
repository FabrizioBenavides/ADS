Imports System.Text
'====================================================================
' Class         : clsCuenta
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Operaciones con Cuentas.
' Copyright     : 2003-2005 Todos los Derechos Reservados.
' Company       : Isocraft S.A. de C.V.
' Author        : Direcci�n de Tecnolog�a
' Version       : 1.0.1311.33021
' Last Modified : Tuesday, June 1, 2004
'====================================================================
Public NotInheritable Class clsCuenta

    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clsCuenta"

    ' Constructor en blanco para prevenir la generaci�n de un constructor por defecto
    Private Sub New()
    End Sub


    '====================================================================
    ' Name       : strBuscarPorTipo
    ' Description: Regresa la lista de usuarios del concentrador
    '             
    ' Parameters :
    '               ByVal intEmpleadoId As Integer
    '               ByVal intUsuarioId As Integer
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
    Public Shared Function strBuscarPorTipo( _
       ByVal intTipoCuentaId As Integer, _
       ByVal intTipoReferenciaId As Integer, _
       ByVal intInitialPosition As Integer, _
       ByVal intElementsPerPage As Integer, _
       ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarPorTipo"

        ' Variables locales
        Dim strSQLStatement As System.Text.StringBuilder = Nothing

        Try
            ' Inicializaci�n de las variables locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarCuentaPorTipo ")
            Call strSQLStatement.Append(intTipoCuentaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intTipoReferenciaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intInitialPosition)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intElementsPerPage)


            ' Ejecutamos el comando
            strBuscarPorTipo = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strBuscarPorTipo = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strBuscarPorSucursal
    ' Description: Regresa la lista de cuentas de una sucursal
    '             
    ' Parameters :
    '               ByVal intCompaniaId As Integer
    '               ByVal intSucursalId As Integer
    '               ByVal intTipoCuentaId As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros le�dos
    '                Array = { (Col0, Col1, ...,  Coln),
    '                          , ... ,
    '                          (Col0, Col1, ...,  Coln)}
    '====================================================================
    Public Shared Function strBuscarPorSucursal( _
       ByVal intCompaniaId As Integer, _
       ByVal intSucursalId As Integer, _
       ByVal intTipoCuentaId As Integer, _
       ByVal intInitialPosition As Integer, _
       ByVal intElementsPerPage As Integer, _
       ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarPorSucursal"

        ' Variables locales
        Dim strSQLStatement As System.Text.StringBuilder = Nothing

        Try
            ' Inicializaci�n de las variables locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarCuentaSucursal ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intTipoCuentaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intInitialPosition)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intElementsPerPage)

            ' Ejecutamos el comando
            strBuscarPorSucursal = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString, strConnectionString)
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
            strBuscarPorSucursal = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

End Class
