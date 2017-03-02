
Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clstblMovimientoArticulo
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : 2003-2005 Todos los Derechos Reservados.
' Company       : Isocraft S.A. de C.V.
' Author        : Direcci�n de Tecnolog�a
' Version       : 1.0.1311.33021
' Last Modified : Monday, November 10, 2003
'====================================================================
Public NotInheritable Class clstblMovimientoArticulo

    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblMovimientoArticulo"

    ' Constructor en blanco para prevenir la generaci�n de un constructor por defecto
    Private Sub New()
    End Sub

    '====================================================================
    ' Name       : intActualizar
    ' Description: Actualizaci�n de registros.
    '                 - Tabla tblMovimientoArticulo
    ' Parameters : 
    '              ByVal intMovimientoArticuloId As Integer
    '                 - 
    '              ByVal intMovimientoArticuloCompaniaId As Integer
    '                 - 
    '              ByVal intMovimientoArticuloSucursalId As Integer
    '                 - 
    '              ByVal intMovimientoArticuloArticuloId As Integer
    '                 - 
    '              ByVal intMovimientoArticuloCajaId As Integer
    '                 - 
    '              ByVal intMovimientoArticuloTurnoId As Integer
    '                 - 
    '              ByVal dtmMovimientoArticuloRegistro As Date
    '                 - 
    '              ByVal fltMovimientoArticuloImporteVendido As Double
    '                 - 
    '              ByVal fltMovimientoArticuloImporteDevuelto As Double
    '                 - 
    '              ByVal intMovimientoArticuloCantidadVendida As Integer
    '                 - 
    '              ByVal intMovimientoArticuloCantidadDevuelta As Integer
    '                 - 
    '              ByVal dtmMovimientoArticuloUltimaModificacion As Date
    '                 - 
    '              ByVal strMovimientoArticuloModificadoPor As String
    '                 - 
    '              ByVal strConnectionString As String
    '                 - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - N�mero de registros afectados por el comando
    '====================================================================
    Public Shared Function intActualizar( _
      ByVal intMovimientoArticuloId As Integer, _
      ByVal intMovimientoArticuloCompaniaId As Integer, _
      ByVal intMovimientoArticuloSucursalId As Integer, _
      ByVal intMovimientoArticuloArticuloId As Integer, _
      ByVal intMovimientoArticuloCajaId As Integer, _
      ByVal intMovimientoArticuloTurnoId As Integer, _
      ByVal dtmMovimientoArticuloRegistro As Date, _
      ByVal fltMovimientoArticuloImporteVendido As Double, _
      ByVal fltMovimientoArticuloImporteDevuelto As Double, _
      ByVal intMovimientoArticuloCantidadVendida As Integer, _
      ByVal intMovimientoArticuloCantidadDevuelta As Integer, _
      ByVal dtmMovimientoArticuloUltimaModificacion As Date, _
      ByVal strMovimientoArticuloModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spActualizartblMovimientoArticulo ")
            Call strSQLStatement.Append(intMovimientoArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloTurnoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoArticuloRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoArticuloImporteVendido)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoArticuloImporteDevuelto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloCantidadVendida)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloCantidadDevuelta)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoArticuloUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoArticuloModificadoPor)
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
    '                  - Tabla tblMovimientoArticulo
    ' Parameters : 
    '              ByVal intMovimientoArticuloId As Integer
    '                  - 
    '              ByVal intMovimientoArticuloCompaniaId As Integer
    '                  - 
    '              ByVal intMovimientoArticuloSucursalId As Integer
    '                  - 
    '              ByVal intMovimientoArticuloArticuloId As Integer
    '                  - 
    '              ByVal intMovimientoArticuloCajaId As Integer
    '                  - 
    '              ByVal intMovimientoArticuloTurnoId As Integer
    '                  - 
    '              ByVal dtmMovimientoArticuloRegistro As Date
    '                  - 
    '              ByVal fltMovimientoArticuloImporteVendido As Double
    '                  - 
    '              ByVal fltMovimientoArticuloImporteDevuelto As Double
    '                  - 
    '              ByVal intMovimientoArticuloCantidadVendida As Integer
    '                  - 
    '              ByVal intMovimientoArticuloCantidadDevuelta As Integer
    '                  - 
    '              ByVal dtmMovimientoArticuloUltimaModificacion As Date
    '                  - 
    '              ByVal strMovimientoArticuloModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - N�mero de registros afectados por el comando
    '====================================================================
    Public Shared Function intAgregar( _
      ByVal intMovimientoArticuloId As Integer, _
      ByVal intMovimientoArticuloCompaniaId As Integer, _
      ByVal intMovimientoArticuloSucursalId As Integer, _
      ByVal intMovimientoArticuloArticuloId As Integer, _
      ByVal intMovimientoArticuloCajaId As Integer, _
      ByVal intMovimientoArticuloTurnoId As Integer, _
      ByVal dtmMovimientoArticuloRegistro As Date, _
      ByVal fltMovimientoArticuloImporteVendido As Double, _
      ByVal fltMovimientoArticuloImporteDevuelto As Double, _
      ByVal intMovimientoArticuloCantidadVendida As Integer, _
      ByVal intMovimientoArticuloCantidadDevuelta As Integer, _
      ByVal dtmMovimientoArticuloUltimaModificacion As Date, _
      ByVal strMovimientoArticuloModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spAgregartblMovimientoArticulo ")
            Call strSQLStatement.Append(intMovimientoArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloTurnoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoArticuloRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoArticuloImporteVendido)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoArticuloImporteDevuelto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloCantidadVendida)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloCantidadDevuelta)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoArticuloUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoArticuloModificadoPor)
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
    '                 - Tabla tblMovimientoArticulo
    ' Parameters : 
    '              ByVal intMovimientoArticuloId As Integer
    '                 - 
    '              ByVal intMovimientoArticuloCompaniaId As Integer
    '                 - 
    '              ByVal intMovimientoArticuloSucursalId As Integer
    '                 - 
    '              ByVal intMovimientoArticuloArticuloId As Integer
    '                 - 
    '              ByVal intMovimientoArticuloCajaId As Integer
    '                 - 
    '              ByVal intMovimientoArticuloTurnoId As Integer
    '                 - 
    '              ByVal dtmMovimientoArticuloRegistro As Date
    '                 - 
    '              ByVal fltMovimientoArticuloImporteVendido As Double
    '                 - 
    '              ByVal fltMovimientoArticuloImporteDevuelto As Double
    '                 - 
    '              ByVal intMovimientoArticuloCantidadVendida As Integer
    '                 - 
    '              ByVal intMovimientoArticuloCantidadDevuelta As Integer
    '                 - 
    '              ByVal dtmMovimientoArticuloUltimaModificacion As Date
    '                 - 
    '              ByVal strMovimientoArticuloModificadoPor As String
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
      ByVal intMovimientoArticuloId As Integer, _
      ByVal intMovimientoArticuloCompaniaId As Integer, _
      ByVal intMovimientoArticuloSucursalId As Integer, _
      ByVal intMovimientoArticuloArticuloId As Integer, _
      ByVal intMovimientoArticuloCajaId As Integer, _
      ByVal intMovimientoArticuloTurnoId As Integer, _
      ByVal dtmMovimientoArticuloRegistro As Date, _
      ByVal fltMovimientoArticuloImporteVendido As Double, _
      ByVal fltMovimientoArticuloImporteDevuelto As Double, _
      ByVal intMovimientoArticuloCantidadVendida As Integer, _
      ByVal intMovimientoArticuloCantidadDevuelta As Integer, _
      ByVal dtmMovimientoArticuloUltimaModificacion As Date, _
      ByVal strMovimientoArticuloModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spBuscartblMovimientoArticulo ")
            Call strSQLStatement.Append(intMovimientoArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloTurnoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoArticuloRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoArticuloImporteVendido)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoArticuloImporteDevuelto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloCantidadVendida)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloCantidadDevuelta)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoArticuloUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoArticuloModificadoPor)
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
    '                 - Tabla tblMovimientoArticulo
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
            Call strSQLStatement.Append("EXECUTE spBuscarCambiotblMovimientoArticulo ")
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
    '                 - Tabla tblMovimientoArticulo
    ' Parameters : 
    '              ByVal intMovimientoArticuloId As Integer
    '                 - 
    '              ByVal intMovimientoArticuloCompaniaId As Integer
    '                 - 
    '              ByVal intMovimientoArticuloSucursalId As Integer
    '                 - 
    '              ByVal intMovimientoArticuloArticuloId As Integer
    '                 - 
    '              ByVal intMovimientoArticuloCajaId As Integer
    '                 - 
    '              ByVal intMovimientoArticuloTurnoId As Integer
    '                 - 
    '              ByVal dtmMovimientoArticuloRegistro As Date
    '                 - 
    '              ByVal fltMovimientoArticuloImporteVendido As Double
    '                 - 
    '              ByVal fltMovimientoArticuloImporteDevuelto As Double
    '                 - 
    '              ByVal intMovimientoArticuloCantidadVendida As Integer
    '                 - 
    '              ByVal intMovimientoArticuloCantidadDevuelta As Integer
    '                 - 
    '              ByVal dtmMovimientoArticuloUltimaModificacion As Date
    '                 - 
    '              ByVal strMovimientoArticuloModificadoPor As String
    '                 - 
    '              ByVal strConnectionString As String
    '                 - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - N�mero de registros en la tabla
    '====================================================================
    Public Shared Function intContar( _
      ByVal intMovimientoArticuloId As Integer, _
      ByVal intMovimientoArticuloCompaniaId As Integer, _
      ByVal intMovimientoArticuloSucursalId As Integer, _
      ByVal intMovimientoArticuloArticuloId As Integer, _
      ByVal intMovimientoArticuloCajaId As Integer, _
      ByVal intMovimientoArticuloTurnoId As Integer, _
      ByVal dtmMovimientoArticuloRegistro As Date, _
      ByVal fltMovimientoArticuloImporteVendido As Double, _
      ByVal fltMovimientoArticuloImporteDevuelto As Double, _
      ByVal intMovimientoArticuloCantidadVendida As Integer, _
      ByVal intMovimientoArticuloCantidadDevuelta As Integer, _
      ByVal dtmMovimientoArticuloUltimaModificacion As Date, _
      ByVal strMovimientoArticuloModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spContartblMovimientoArticulo ")
            Call strSQLStatement.Append(intMovimientoArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloTurnoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoArticuloRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoArticuloImporteVendido)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoArticuloImporteDevuelto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloCantidadVendida)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloCantidadDevuelta)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoArticuloUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoArticuloModificadoPor)
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
    '                 - Tabla tblMovimientoArticulo
    ' Parameters : 
    '              ByVal intMovimientoArticuloId As Integer
    '                 - 
    '              ByVal intMovimientoArticuloCompaniaId As Integer
    '                 - 
    '              ByVal intMovimientoArticuloSucursalId As Integer
    '                 - 
    '              ByVal intMovimientoArticuloArticuloId As Integer
    '                 - 
    '              ByVal intMovimientoArticuloCajaId As Integer
    '                 - 
    '              ByVal intMovimientoArticuloTurnoId As Integer
    '                 - 
    '              ByVal dtmMovimientoArticuloRegistro As Date
    '                 - 
    '              ByVal fltMovimientoArticuloImporteVendido As Double
    '                 - 
    '              ByVal fltMovimientoArticuloImporteDevuelto As Double
    '                 - 
    '              ByVal intMovimientoArticuloCantidadVendida As Integer
    '                 - 
    '              ByVal intMovimientoArticuloCantidadDevuelta As Integer
    '                 - 
    '              ByVal dtmMovimientoArticuloUltimaModificacion As Date
    '                 - 
    '              ByVal strMovimientoArticuloModificadoPor As String
    '                 - 
    '              ByVal strConnectionString As String
    '                 - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - N�mero de registros afectados por el comando
    '====================================================================
    Public Shared Function intEliminar( _
      ByVal intMovimientoArticuloId As Integer, _
      ByVal intMovimientoArticuloCompaniaId As Integer, _
      ByVal intMovimientoArticuloSucursalId As Integer, _
      ByVal intMovimientoArticuloArticuloId As Integer, _
      ByVal intMovimientoArticuloCajaId As Integer, _
      ByVal intMovimientoArticuloTurnoId As Integer, _
      ByVal dtmMovimientoArticuloRegistro As Date, _
      ByVal fltMovimientoArticuloImporteVendido As Double, _
      ByVal fltMovimientoArticuloImporteDevuelto As Double, _
      ByVal intMovimientoArticuloCantidadVendida As Integer, _
      ByVal intMovimientoArticuloCantidadDevuelta As Integer, _
      ByVal dtmMovimientoArticuloUltimaModificacion As Date, _
      ByVal strMovimientoArticuloModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spEliminartblMovimientoArticulo ")
            Call strSQLStatement.Append(intMovimientoArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloTurnoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoArticuloRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoArticuloImporteVendido)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoArticuloImporteDevuelto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloCantidadVendida)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoArticuloCantidadDevuelta)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoArticuloUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoArticuloModificadoPor)
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
