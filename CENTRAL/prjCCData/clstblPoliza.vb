
Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clstblPoliza
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : 2003-2005 Todos los Derechos Reservados.
' Company       : Isocraft S.A. de C.V.
' Author        : Direcci�n de Tecnolog�a
' Version       : 1.0.1311.33021
' Last Modified : Monday, November 10, 2003
'====================================================================
Public NotInheritable Class clstblPoliza

    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblPoliza"

    ' Constructor en blanco para prevenir la generaci�n de un constructor por defecto
    Private Sub New()
    End Sub

    '====================================================================
    ' Name       : intActualizar
    ' Description: Actualizaci�n de registros.
    '                 - Tabla tblPoliza
    ' Parameters : 
    '              ByVal intPolizaId As Integer
    '                 - 
    '              ByVal intPolizaCompaniaId As Integer
    '                 - 
    '              ByVal intPolizaSucursalId As Integer
    '                 - 
    '              ByVal intPolizaCuentaId As Integer
    '                 - 
    '              ByVal fltPolizaImporteContado As Double
    '                 - 
    '              ByVal fltPolizaImporteCredito As Double
    '                 - 
    '              ByVal fltPolizaCantidadDocumentos As Double
    '                 - 
    '              ByVal dtmPolizaRegistro As Date
    '                 - 
    '              ByVal dtmPolizaSiguienteDeposito As Date
    '                 - 
    '              ByVal blnPolizaDesbalanceada As Byte
    '                 - 
    '              ByVal dtmPolizaUltimaModificacion As Date
    '                 - 
    '              ByVal strPolizaModificadoPor As String
    '                 - 
    '              ByVal strConnectionString As String
    '                 - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - N�mero de registros afectados por el comando
    '====================================================================
    Public Shared Function intActualizar( _
      ByVal intPolizaId As Integer, _
      ByVal intPolizaCompaniaId As Integer, _
      ByVal intPolizaSucursalId As Integer, _
      ByVal intPolizaCuentaId As Integer, _
      ByVal fltPolizaImporteContado As Double, _
      ByVal fltPolizaImporteCredito As Double, _
      ByVal fltPolizaCantidadDocumentos As Double, _
      ByVal dtmPolizaRegistro As Date, _
      ByVal dtmPolizaSiguienteDeposito As Date, _
      ByVal blnPolizaDesbalanceada As Byte, _
      ByVal dtmPolizaUltimaModificacion As Date, _
      ByVal strPolizaModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spActualizartblPoliza ")
            Call strSQLStatement.Append(intPolizaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intPolizaCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intPolizaSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intPolizaCuentaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltPolizaImporteContado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltPolizaImporteCredito)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltPolizaCantidadDocumentos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmPolizaRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmPolizaSiguienteDeposito.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnPolizaDesbalanceada)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmPolizaUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strPolizaModificadoPor)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            For Each strRowsAffected In strRegistros
                intRowsAffected = CInt(strRowsAffected.GetValue(0))
            Next

            ' Regresamos la informaci�n
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

            ' Regresamos la informaci�n
            intActualizar = 0

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : intAgregar
    ' Description: Adici�n de registros.
    '                  - Tabla tblPoliza
    ' Parameters : 
    '              ByVal intPolizaId As Integer
    '                  - 
    '              ByVal intPolizaCompaniaId As Integer
    '                  - 
    '              ByVal intPolizaSucursalId As Integer
    '                  - 
    '              ByVal intPolizaCuentaId As Integer
    '                  - 
    '              ByVal fltPolizaImporteContado As Double
    '                  - 
    '              ByVal fltPolizaImporteCredito As Double
    '                  - 
    '              ByVal fltPolizaCantidadDocumentos As Double
    '                  - 
    '              ByVal dtmPolizaRegistro As Date
    '                  - 
    '              ByVal dtmPolizaSiguienteDeposito As Date
    '                  - 
    '              ByVal blnPolizaDesbalanceada As Byte
    '                  - 
    '              ByVal dtmPolizaUltimaModificacion As Date
    '                  - 
    '              ByVal strPolizaModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - N�mero de registros afectados por el comando
    '====================================================================
    Public Shared Function intAgregar( _
      ByVal intPolizaId As Integer, _
      ByVal intPolizaCompaniaId As Integer, _
      ByVal intPolizaSucursalId As Integer, _
      ByVal intPolizaCuentaId As Integer, _
      ByVal fltPolizaImporteContado As Double, _
      ByVal fltPolizaImporteCredito As Double, _
      ByVal fltPolizaCantidadDocumentos As Double, _
      ByVal dtmPolizaRegistro As Date, _
      ByVal dtmPolizaSiguienteDeposito As Date, _
      ByVal blnPolizaDesbalanceada As Byte, _
      ByVal dtmPolizaUltimaModificacion As Date, _
      ByVal strPolizaModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spAgregartblPoliza ")
            Call strSQLStatement.Append(intPolizaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intPolizaCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intPolizaSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intPolizaCuentaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltPolizaImporteContado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltPolizaImporteCredito)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltPolizaCantidadDocumentos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmPolizaRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmPolizaSiguienteDeposito.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnPolizaDesbalanceada)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmPolizaUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strPolizaModificadoPor)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            For Each strRowsAffected In strRegistros
                intRowsAffected = CInt(strRowsAffected.GetValue(0))
            Next

            ' Regresamos la informaci�n
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

            ' Regresamos la informaci�n
            intAgregar = 0

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strBuscar
    ' Description: B�squeda de registros.
    '                 - Tabla tblPoliza
    ' Parameters : 
    '              ByVal intPolizaId As Integer
    '                 - 
    '              ByVal intPolizaCompaniaId As Integer
    '                 - 
    '              ByVal intPolizaSucursalId As Integer
    '                 - 
    '              ByVal intPolizaCuentaId As Integer
    '                 - 
    '              ByVal fltPolizaImporteContado As Double
    '                 - 
    '              ByVal fltPolizaImporteCredito As Double
    '                 - 
    '              ByVal fltPolizaCantidadDocumentos As Double
    '                 - 
    '              ByVal dtmPolizaRegistro As Date
    '                 - 
    '              ByVal dtmPolizaSiguienteDeposito As Date
    '                 - 
    '              ByVal blnPolizaDesbalanceada As Byte
    '                 - 
    '              ByVal dtmPolizaUltimaModificacion As Date
    '                 - 
    '              ByVal strPolizaModificadoPor As String
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
    Public Shared Function strBuscar( _
      ByVal intPolizaId As Integer, _
      ByVal intPolizaCompaniaId As Integer, _
      ByVal intPolizaSucursalId As Integer, _
      ByVal intPolizaCuentaId As Integer, _
      ByVal fltPolizaImporteContado As Double, _
      ByVal fltPolizaImporteCredito As Double, _
      ByVal fltPolizaCantidadDocumentos As Double, _
      ByVal dtmPolizaRegistro As Date, _
      ByVal dtmPolizaSiguienteDeposito As Date, _
      ByVal blnPolizaDesbalanceada As Byte, _
      ByVal dtmPolizaUltimaModificacion As Date, _
      ByVal strPolizaModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spBuscartblPoliza ")
            Call strSQLStatement.Append(intPolizaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intPolizaCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intPolizaSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intPolizaCuentaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltPolizaImporteContado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltPolizaImporteCredito)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltPolizaCantidadDocumentos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmPolizaRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmPolizaSiguienteDeposito.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnPolizaDesbalanceada)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmPolizaUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strPolizaModificadoPor)
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

            ' Regresamos la informaci�n
            strBuscar = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strBuscar
    ' Description: B�squeda de registros modificados y que
    '              necesitan ser reenviados.
    '                 - Tabla tblPoliza
    ' Parameters :
    '              ByVal dtmUltimaModificacionInicial As Date
    '                 - Fecha inicial de b�squeda
    '              ByVal dtmUltimaModificacionFinal As Date
    '                 - Fecha final de b�squeda
    '              ByVal strConnectionString As String
    '                 - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '                 - Arreglo bidimensional con los registros le�dos
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
            Call strSQLStatement.Append("EXECUTE spBuscarCambiotblPoliza ")
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

            ' Regresamos la informaci�n
            strBuscar = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : intContar
    ' Description: Contar los registros.
    '                 - Tabla tblPoliza
    ' Parameters : 
    '              ByVal intPolizaId As Integer
    '                 - 
    '              ByVal intPolizaCompaniaId As Integer
    '                 - 
    '              ByVal intPolizaSucursalId As Integer
    '                 - 
    '              ByVal intPolizaCuentaId As Integer
    '                 - 
    '              ByVal fltPolizaImporteContado As Double
    '                 - 
    '              ByVal fltPolizaImporteCredito As Double
    '                 - 
    '              ByVal fltPolizaCantidadDocumentos As Double
    '                 - 
    '              ByVal dtmPolizaRegistro As Date
    '                 - 
    '              ByVal dtmPolizaSiguienteDeposito As Date
    '                 - 
    '              ByVal blnPolizaDesbalanceada As Byte
    '                 - 
    '              ByVal dtmPolizaUltimaModificacion As Date
    '                 - 
    '              ByVal strPolizaModificadoPor As String
    '                 - 
    '              ByVal strConnectionString As String
    '                 - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - N�mero de registros en la tabla
    '====================================================================
    Public Shared Function intContar( _
      ByVal intPolizaId As Integer, _
      ByVal intPolizaCompaniaId As Integer, _
      ByVal intPolizaSucursalId As Integer, _
      ByVal intPolizaCuentaId As Integer, _
      ByVal fltPolizaImporteContado As Double, _
      ByVal fltPolizaImporteCredito As Double, _
      ByVal fltPolizaCantidadDocumentos As Double, _
      ByVal dtmPolizaRegistro As Date, _
      ByVal dtmPolizaSiguienteDeposito As Date, _
      ByVal blnPolizaDesbalanceada As Byte, _
      ByVal dtmPolizaUltimaModificacion As Date, _
      ByVal strPolizaModificadoPor As String, _
      ByVal strConnectionString As String) As Double

        ' Constantes locales
        Const strmThisMemberName As String = "intContar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Double = 0
        Dim strRegistros As Array = Nothing
        Dim strRowsAffected As String() = Nothing

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spContartblPoliza ")
            Call strSQLStatement.Append(intPolizaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intPolizaCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intPolizaSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intPolizaCuentaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltPolizaImporteContado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltPolizaImporteCredito)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltPolizaCantidadDocumentos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmPolizaRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmPolizaSiguienteDeposito.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnPolizaDesbalanceada)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmPolizaUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strPolizaModificadoPor)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            For Each strRowsAffected In strRegistros
                intRowsAffected = CInt(strRowsAffected.GetValue(0))
            Next

            ' Regresamos la informaci�n
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

            ' Regresamos la informaci�n
            intContar = 0

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : intEliminar
    ' Description: Eliminaci�n de registros.
    '                 - Tabla tblPoliza
    ' Parameters : 
    '              ByVal intPolizaId As Integer
    '                 - 
    '              ByVal intPolizaCompaniaId As Integer
    '                 - 
    '              ByVal intPolizaSucursalId As Integer
    '                 - 
    '              ByVal intPolizaCuentaId As Integer
    '                 - 
    '              ByVal fltPolizaImporteContado As Double
    '                 - 
    '              ByVal fltPolizaImporteCredito As Double
    '                 - 
    '              ByVal fltPolizaCantidadDocumentos As Double
    '                 - 
    '              ByVal dtmPolizaRegistro As Date
    '                 - 
    '              ByVal dtmPolizaSiguienteDeposito As Date
    '                 - 
    '              ByVal blnPolizaDesbalanceada As Byte
    '                 - 
    '              ByVal dtmPolizaUltimaModificacion As Date
    '                 - 
    '              ByVal strPolizaModificadoPor As String
    '                 - 
    '              ByVal strConnectionString As String
    '                 - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - N�mero de registros afectados por el comando
    '====================================================================
    Public Shared Function intEliminar( _
      ByVal intPolizaId As Integer, _
      ByVal intPolizaCompaniaId As Integer, _
      ByVal intPolizaSucursalId As Integer, _
      ByVal intPolizaCuentaId As Integer, _
      ByVal fltPolizaImporteContado As Double, _
      ByVal fltPolizaImporteCredito As Double, _
      ByVal fltPolizaCantidadDocumentos As Double, _
      ByVal dtmPolizaRegistro As Date, _
      ByVal dtmPolizaSiguienteDeposito As Date, _
      ByVal blnPolizaDesbalanceada As Byte, _
      ByVal dtmPolizaUltimaModificacion As Date, _
      ByVal strPolizaModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spEliminartblPoliza ")
            Call strSQLStatement.Append(intPolizaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intPolizaCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intPolizaSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intPolizaCuentaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltPolizaImporteContado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltPolizaImporteCredito)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltPolizaCantidadDocumentos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmPolizaRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmPolizaSiguienteDeposito.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnPolizaDesbalanceada)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmPolizaUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strPolizaModificadoPor)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            For Each strRowsAffected In strRegistros
                intRowsAffected = CInt(strRowsAffected.GetValue(0))
            Next

            ' Regresamos la informaci�n
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

            ' Regresamos la informaci�n
            intEliminar = 0

            ' Notificamos el error
            Throw

        End Try

    End Function

End Class
