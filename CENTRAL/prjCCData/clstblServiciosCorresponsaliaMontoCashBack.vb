Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clstblServiciosCorresponsaliaMontoCashBack
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : 2009 Todos los Derechos Reservados.
' Company       : SOFTTEK
' Author        : César Ortiz (OCOT)
' Version       : 1.0
' Last Modified : Wednesday, September 30, 2009
'====================================================================

Public Class clstblServiciosCorresponsaliaMontoCashBack
    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblServiciosCorresponsaliaMontoCashBack"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()
    End Sub

    '====================================================================
    ' Name       : intActualizar
    ' Description: Actualización de registros.
    '                 - Tabla tblServiciosCorresponsaliaMontoCashBack
    ' Parameters : 
    '              ByVal intServiciosCorresponsaliaMontoCashBackId As String
    '                 - 
    '              ByVal fltServiciosCorresponsaliaMontoCashBack1 As Double
    '                 - 
    '              ByVal fltServiciosCorresponsaliaMontoCashBack2 As Double
    '                 - 
    '              ByVal fltServiciosCorresponsaliaMontoCashBack3 As Double
    '                 -
    '              ByVal fltServiciosCorresponsaliaMontoCashBackNivelMaximoEfectivo As Double
    '                 - 
    '              ByVal dtmServiciosCorresponsaliaMontoCashBackUltimaModificacion As Date
    '                 - 
    '              ByVal strServiciosCorresponsaliaMontoCashBackModificadoPor As String
    '                 - 
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================
    Public Shared Function intActualizar( _
      ByVal intServiciosCorresponsaliaMontoCashBackId As Integer, _
      ByVal fltServiciosCorresponsaliaMontoCashBack1 As Double, _
      ByVal fltServiciosCorresponsaliaMontoCashBack2 As Double, _
      ByVal fltServiciosCorresponsaliaMontoCashBack3 As Double, _
      ByVal fltServiciosCorresponsaliaMontoCashBackNivelMaximoEfectivo As Double, _
      ByVal dtmServiciosCorresponsaliaMontoCashBackUltimaModificacion As Date, _
      ByVal strServiciosCorresponsaliaMontoCashBackModificadoPor As String, _
      ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intActualizar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0
        Dim strRegistros As Array = Nothing
        Dim strRowsAffected As String() = Nothing

        Try

            ' Inicializamos las variabes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spActualizartblServiciosCorresponsaliaMontoCashBack ")
            Call strSQLStatement.Append(intServiciosCorresponsaliaMontoCashBackId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltServiciosCorresponsaliaMontoCashBack1)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltServiciosCorresponsaliaMontoCashBack2)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltServiciosCorresponsaliaMontoCashBack3)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltServiciosCorresponsaliaMontoCashBackNivelMaximoEfectivo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmServiciosCorresponsaliaMontoCashBackUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strServiciosCorresponsaliaMontoCashBackModificadoPor)
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
    '                  - Tabla tblServiciosCorresponsalia
    ' Parameters : 
    '              ByVal intServiciosCorresponsaliaMontoCashBackId As String
    '                 - 
    '              ByVal fltServiciosCorresponsaliaMontoCashBack1 As Double
    '                 - 
    '              ByVal fltServiciosCorresponsaliaMontoCashBack2 As Double
    '                 - 
    '              ByVal fltServiciosCorresponsaliaMontoCashBack3 As Double
    '                 -
    '              ByVal fltServiciosCorresponsaliaMontoCashBackNivelMaximoEfectivo As Double
    '                 - 
    '              ByVal dtmServiciosCorresponsaliaMontoCashBackUltimaModificacion As Date
    '                 - 
    '              ByVal strServiciosCorresponsaliaMontoCashBackModificadoPor As String
    '                 - 
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================
    Public Shared Function intAgregar( _
      ByVal intServiciosCorresponsaliaMontoCashBackId As Integer, _
      ByVal fltServiciosCorresponsaliaMontoCashBack1 As Double, _
      ByVal fltServiciosCorresponsaliaMontoCashBack2 As Double, _
      ByVal fltServiciosCorresponsaliaMontoCashBack3 As Double, _
      ByVal fltServiciosCorresponsaliaMontoCashBackNivelMaximoEfectivo As Double, _
      ByVal dtmServiciosCorresponsaliaMontoCashBackUltimaModificacion As Date, _
      ByVal strServiciosCorresponsaliaMontoCashBackModificadoPor As String, _
      ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intAgregar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0
        Dim strRegistros As Array = Nothing
        Dim strRowsAffected As String() = Nothing

        Try
            ' Inicializamos las variabes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spAgregartblServiciosCorresponsaliaMontoCashBack ")
            Call strSQLStatement.Append(intServiciosCorresponsaliaMontoCashBackId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltServiciosCorresponsaliaMontoCashBack1)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltServiciosCorresponsaliaMontoCashBack2)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltServiciosCorresponsaliaMontoCashBack3)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltServiciosCorresponsaliaMontoCashBackNivelMaximoEfectivo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmServiciosCorresponsaliaMontoCashBackUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strServiciosCorresponsaliaMontoCashBackModificadoPor)
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
    '                 - Tabla tblServiciosCorresponsalia
    ' Parameters : 
    '              ByVal intServiciosCorresponsaliaMontoCashBackId As String
    '                 - 
    '              ByVal fltServiciosCorresponsaliaMontoCashBack1 As Double
    '                 - 
    '              ByVal fltServiciosCorresponsaliaMontoCashBack2 As Double
    '                 - 
    '              ByVal fltServiciosCorresponsaliaMontoCashBack3 As Double
    '                 -
    '              ByVal fltServiciosCorresponsaliaMontoCashBackNivelMaximoEfectivo As Double
    '                 - 
    '              ByVal dtmServiciosCorresponsaliaMontoCashBackUltimaModificacion As Date
    '                 - 
    '              ByVal strServiciosCorresponsaliaMontoCashBackModificadoPor As String
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
      ByVal intServiciosCorresponsaliaMontoCashBackId As Integer, _
      ByVal fltServiciosCorresponsaliaMontoCashBack1 As Double, _
      ByVal fltServiciosCorresponsaliaMontoCashBack2 As Double, _
      ByVal fltServiciosCorresponsaliaMontoCashBack3 As Double, _
      ByVal fltServiciosCorresponsaliaMontoCashBackNivelMaximoEfectivo As Double, _
      ByVal dtmServiciosCorresponsaliaMontoCashBackUltimaModificacion As Date, _
      ByVal strServiciosCorresponsaliaMontoCashBackModificadoPor As String, _
      ByVal intPosicionInicial As Double, _
      ByVal intElementos As Double, _
      ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try

            ' Inicializamos las variabes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscartblServiciosCorresponsaliaMontoCashBack ")
            Call strSQLStatement.Append(intServiciosCorresponsaliaMontoCashBackId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltServiciosCorresponsaliaMontoCashBack1)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltServiciosCorresponsaliaMontoCashBack2)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltServiciosCorresponsaliaMontoCashBack3)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltServiciosCorresponsaliaMontoCashBackNivelMaximoEfectivo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmServiciosCorresponsaliaMontoCashBackUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strServiciosCorresponsaliaMontoCashBackModificadoPor)
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

    '====================================================================
    ' Name       : strBuscar
    ' Description: Búsqueda de registros modificados y que
    '              necesitan ser reenviados.
    '                 - Tabla tblServiciosCorresponsaliaMontoCashBack
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
    Public Shared Function strBuscar( _
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
            Call strSQLStatement.Append("EXECUTE spBuscarCambiotblServiciosCorresponsaliaMontoCashBack ")
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
    ' Name       : strObtenerMontosCashBack
    ' Description: Buscar los montos de cashback
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con el registro leído
    '                Array = { (), (), ..... () }
    '====================================================================
    Public Shared Function strObtenerMontosCashBack(ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strObtenerMontosCashBack"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spObtenerMontosCashBack ")

            ' Ejecutamos el comando
            strObtenerMontosCashBack = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
            strObtenerMontosCashBack = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : intGuardarMontosCashBack
    ' Description: Guarda la informacion de los montos
    ' Input      :
    '               ByVal fltMontoUno As Double
    '               -
    '               ByVal fltMontoUno As Double
    '               -
    '               ByVal fltMontoUno As Double
    '               -
    '               ByVal fltNivelMaximoEfectivo As Double
    '               -
    '               ByVal strModificadoPor As String
    '               -
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer (menor a 0, no se pudo guardar. 0 o mayor se guardo la informacion)
    '====================================================================
    Public Shared Function intGuardarMontosCashBack(ByVal fltMontoUno As Double, _
                                                    ByVal fltMontoDos As Double, _
                                                    ByVal fltMontoTres As Double, _
                                                    ByVal fltNivelMaximoEfectivo As Double, _
                                                    ByVal strModificadoPor As String, _
                                                    ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intGuardarMontosCashBack"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim objArray As Array = Nothing
        Dim strRow As String() = Nothing
        Dim intReturnValue As Integer = 0

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spGuardarMontosCashBack ")
            Call strSQLStatement.Append(fltMontoUno)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMontoDos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMontoTres)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltNivelMaximoEfectivo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strModificadoPor)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            objArray = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

            If IsArray(objArray) AndAlso objArray.Length > 0 Then

                strRow = DirectCast(objArray.GetValue(0), String())
                intReturnValue = CInt(strRow(0))

            End If

            strSQLStatement = Nothing

            ' Regresamos el resultado
            intGuardarMontosCashBack = intReturnValue

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

            ' Regresamos el resultado
            intGuardarMontosCashBack = 0

            ' Notificamos el error
            Throw

        End Try

    End Function
End Class
