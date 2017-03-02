
Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clstblClienteEspecial
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : 2003-2005 Todos los Derechos Reservados.
' Company       : Isocraft S.A. de C.V.
' Author        : Dirección de Tecnología
' Version       : 1.0.1311.33021
' Last Modified : Monday, November 10, 2003
'====================================================================
Public NotInheritable Class clstblClienteEspecial

    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblClienteEspecial"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()
    End Sub

    ''====================================================================
    '' Name       : intActualizar
    '' Description: Actualización de registros.
    ''                 - Tabla tblClienteEspecial
    '' Parameters : 
    ''              ByVal intClienteEspecialId As Integer
    ''                 - 
    ''              ByVal intGrupoClienteEspecialId As Integer
    ''                 - 
    ''              ByVal strClienteEspecialNombreId As String
    ''                 - 
    ''              ByVal strClienteEspecialNombre As String
    ''                 - 
    ''              ByVal blnClienteEspecialPagoDeContado As Byte
    ''                 - 
    ''              ByVal fltClienteEspecialDescuento As Double
    ''                 - 
    ''              ByVal dtmClienteEspecialVigencia As Date
    ''                 - 
    ''              ByVal fltClienteEspecialMaximoPorcentajeCopago As Double
    ''                 - 
    ''              ByVal fltClienteEspecialMaximoImporteCopago As Double
    ''                 - 
    ''              ByVal dtmClienteEspecialUltimaModificacion As Date
    ''                 - 
    ''              ByVal strClienteEspecialModificadoPor As String
    ''                 - 
    ''              ByVal strConnectionString As String
    ''                 - Cadena de conexión hacia el RDBMS
    '' Throws     : Exception
    '' Output     : Integer
    ''                 - Número de registros afectados por el comando
    ''====================================================================
    'Public Shared Function intActualizar( _
    '  ByVal intClienteEspecialId As Integer, _
    '  ByVal intGrupoClienteEspecialId As Integer, _
    '  ByVal strClienteEspecialNombreId As String, _
    '  ByVal strClienteEspecialNombre As String, _
    '  ByVal blnClienteEspecialPagoDeContado As Byte, _
    '  ByVal fltClienteEspecialDescuento As Double, _
    '  ByVal dtmClienteEspecialVigencia As Date, _
    '  ByVal fltClienteEspecialMaximoPorcentajeCopago As Double, _
    '  ByVal fltClienteEspecialMaximoImporteCopago As Double, _
    '  ByVal dtmClienteEspecialUltimaModificacion As Date, _
    '  ByVal strClienteEspecialModificadoPor As String, _
    '  ByVal strConnectionString As String) As Integer

    '    ' Constantes locales
    '    Const strmThisMemberName As String = "intActualizar"

    '    ' Variables locales
    '    Dim strSQLStatement As StringBuilder = Nothing
    '    Dim intRowsAffected As Integer = 0
    '    Dim strRegistros As Array = Nothing
    '    Dim strRowsAffected As String() = Nothing

    '    Try

    '        ' Inicializamos las varialbes locales
    '        strSQLStatement = New StringBuilder

    '        ' Creamos es estatuto de SQL
    '        Call strSQLStatement.Append("EXECUTE spActualizartblClienteEspecial ")
    '        Call strSQLStatement.Append(intClienteEspecialId)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(intGrupoClienteEspecialId)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(strClienteEspecialNombreId)
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(strClienteEspecialNombre)
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(blnClienteEspecialPagoDeContado)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(fltClienteEspecialDescuento)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(dtmClienteEspecialVigencia.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(fltClienteEspecialMaximoPorcentajeCopago)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(fltClienteEspecialMaximoImporteCopago)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(dtmClienteEspecialUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(strClienteEspecialModificadoPor)
    '        Call strSQLStatement.Append("'")

    '        ' Ejecutamos el comando
    '        strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
    '        For Each strRowsAffected In strRegistros
    '            intRowsAffected = CInt(strRowsAffected.GetValue(0))
    '        Next

    '        ' Regresamos la información
    '        strSQLStatement = Nothing
    '        intActualizar = intRowsAffected

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
    '        intActualizar = 0

    '        ' Notificamos el error
    '        Throw

    '    End Try

    'End Function

    ''====================================================================
    '' Name       : intAgregar
    '' Description: Adición de registros.
    ''                  - Tabla tblClienteEspecial
    '' Parameters : 
    ''              ByVal intClienteEspecialId As Integer
    ''                  - 
    ''              ByVal intGrupoClienteEspecialId As Integer
    ''                  - 
    ''              ByVal strClienteEspecialNombreId As String
    ''                  - 
    ''              ByVal strClienteEspecialNombre As String
    ''                  - 
    ''              ByVal blnClienteEspecialPagoDeContado As Byte
    ''                  - 
    ''              ByVal fltClienteEspecialDescuento As Double
    ''                  - 
    ''              ByVal dtmClienteEspecialVigencia As Date
    ''                  - 
    ''              ByVal fltClienteEspecialMaximoPorcentajeCopago As Double
    ''                  - 
    ''              ByVal fltClienteEspecialMaximoImporteCopago As Double
    ''                  - 
    ''              ByVal dtmClienteEspecialUltimaModificacion As Date
    ''                  - 
    ''              ByVal strClienteEspecialModificadoPor As String
    ''                  - 
    ''              ByVal strConnectionString As String
    ''                  - Cadena de conexión hacia el RDBMS
    '' Throws     : Exception
    '' Output     : Integer
    ''                  - Número de registros afectados por el comando
    ''====================================================================
    'Public Shared Function intAgregar( _
    '  ByVal intClienteEspecialId As Integer, _
    '  ByVal intGrupoClienteEspecialId As Integer, _
    '  ByVal strClienteEspecialNombreId As String, _
    '  ByVal strClienteEspecialNombre As String, _
    '  ByVal blnClienteEspecialPagoDeContado As Byte, _
    '  ByVal fltClienteEspecialDescuento As Double, _
    '  ByVal dtmClienteEspecialVigencia As Date, _
    '  ByVal fltClienteEspecialMaximoPorcentajeCopago As Double, _
    '  ByVal fltClienteEspecialMaximoImporteCopago As Double, _
    '  ByVal dtmClienteEspecialUltimaModificacion As Date, _
    '  ByVal strClienteEspecialModificadoPor As String, _
    '  ByVal strConnectionString As String) As Integer

    '    ' Constantes locales
    '    Const strmThisMemberName As String = "intAgregar"

    '    ' Variables locales
    '    Dim strSQLStatement As StringBuilder = Nothing
    '    Dim intRowsAffected As Integer = 0
    '    Dim strRegistros As Array = Nothing
    '    Dim strRowsAffected As String() = Nothing

    '    Try
    '        ' Inicializamos las varialbes locales
    '        strSQLStatement = New StringBuilder

    '        ' Creamos es estatuto de SQL
    '        Call strSQLStatement.Append("EXECUTE spAgregartblClienteEspecial ")
    '        Call strSQLStatement.Append(intClienteEspecialId)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(intGrupoClienteEspecialId)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(strClienteEspecialNombreId)
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(strClienteEspecialNombre)
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(blnClienteEspecialPagoDeContado)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(fltClienteEspecialDescuento)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(dtmClienteEspecialVigencia.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(fltClienteEspecialMaximoPorcentajeCopago)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(fltClienteEspecialMaximoImporteCopago)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(dtmClienteEspecialUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(strClienteEspecialModificadoPor)
    '        Call strSQLStatement.Append("'")

    '        ' Ejecutamos el comando
    '        strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
    '        For Each strRowsAffected In strRegistros
    '            intRowsAffected = CInt(strRowsAffected.GetValue(0))
    '        Next

    '        ' Regresamos la información
    '        strSQLStatement = Nothing
    '        intAgregar = intRowsAffected

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
    '        intAgregar = 0

    '        ' Notificamos el error
    '        Throw

    '    End Try

    'End Function

    ''====================================================================
    '' Name       : strBuscar
    '' Description: Búsqueda de registros.
    ''                 - Tabla tblClienteEspecial
    '' Parameters : 
    ''              ByVal intClienteEspecialId As Integer
    ''                 - 
    ''              ByVal intGrupoClienteEspecialId As Integer
    ''                 - 
    ''              ByVal strClienteEspecialNombreId As String
    ''                 - 
    ''              ByVal strClienteEspecialNombre As String
    ''                 - 
    ''              ByVal blnClienteEspecialPagoDeContado As Byte
    ''                 - 
    ''              ByVal fltClienteEspecialDescuento As Double
    ''                 - 
    ''              ByVal dtmClienteEspecialVigencia As Date
    ''                 - 
    ''              ByVal fltClienteEspecialMaximoPorcentajeCopago As Double
    ''                 - 
    ''              ByVal fltClienteEspecialMaximoImporteCopago As Double
    ''                 - 
    ''              ByVal dtmClienteEspecialUltimaModificacion As Date
    ''                 - 
    ''              ByVal strClienteEspecialModificadoPor As String
    ''                 - 
    ''              ByVal intPosicionInicial As  Double
    ''                 - Inicio de registros
    ''              ByVal intElementos As Double
    ''                 - Numero de elementos por bloque
    ''              ByVal strConnectionString As String
    ''                 - Cadena de conexión hacia el RDBMS
    '' Throws     : Exception
    '' Output     : Array
    ''                 - Arreglo bidimensional con los registros leídos
    ''                   Array = { (c1,c2..cn), (c1,c2..cn) ... (c1,c2..cn) }
    ''                   c = Campo
    ''====================================================================
    'Public Shared Function strBuscar( _
    '  ByVal intClienteEspecialId As Integer, _
    '  ByVal intGrupoClienteEspecialId As Integer, _
    '  ByVal strClienteEspecialNombreId As String, _
    '  ByVal strClienteEspecialNombre As String, _
    '  ByVal blnClienteEspecialPagoDeContado As Byte, _
    '  ByVal fltClienteEspecialDescuento As Double, _
    '  ByVal dtmClienteEspecialVigencia As Date, _
    '  ByVal fltClienteEspecialMaximoPorcentajeCopago As Double, _
    '  ByVal fltClienteEspecialMaximoImporteCopago As Double, _
    '  ByVal dtmClienteEspecialUltimaModificacion As Date, _
    '  ByVal strClienteEspecialModificadoPor As String, _
    '  ByVal intPosicionInicial As Double, _
    '  ByVal intElementos As Double, _
    '  ByVal strConnectionString As String) As Array

    '    ' Constantes locales
    '    Const strmThisMemberName As String = "strBuscar"

    '    ' Variables locales
    '    Dim strSQLStatement As StringBuilder = Nothing

    '    Try

    '        ' Inicializamos las varialbes locales
    '        strSQLStatement = New StringBuilder

    '        ' Creamos es estatuto de SQL
    '        Call strSQLStatement.Append("EXECUTE spBuscartblClienteEspecial ")
    '        Call strSQLStatement.Append(intClienteEspecialId)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(intGrupoClienteEspecialId)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(strClienteEspecialNombreId)
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(strClienteEspecialNombre)
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(blnClienteEspecialPagoDeContado)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(fltClienteEspecialDescuento)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(dtmClienteEspecialVigencia.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(fltClienteEspecialMaximoPorcentajeCopago)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(fltClienteEspecialMaximoImporteCopago)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(dtmClienteEspecialUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(strClienteEspecialModificadoPor)
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(intPosicionInicial)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(intElementos)

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

    '====================================================================
    ' Name       : strBuscar
    ' Description: Búsqueda de registros modificados y que
    '              necesitan ser reenviados.
    '                 - Tabla tblClienteEspecial
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
      ByVal strConcentradorDeEnvioIp As String, _
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
            Call strSQLStatement.Append("EXECUTE spBuscarCambiotblClienteEspecial ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strConcentradorDeEnvioIp)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmUltimaModificacionInicial.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmUltimaModificacionFinal.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strBuscar = clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
    ' Name       : intContar
    ' Description: Contar los registros.
    '                 - Tabla tblClienteEspecial
    ' Parameters : 
    '              ByVal intClienteEspecialId As Integer
    '                 - 
    '              ByVal intGrupoClienteEspecialId As Integer
    '                 - 
    '              ByVal strClienteEspecialNombreId As String
    '                 - 
    '              ByVal strClienteEspecialNombre As String
    '                 - 
    '              ByVal blnClienteEspecialPagoDeContado As Byte
    '                 - 
    '              ByVal fltClienteEspecialDescuento As Double
    '                 - 
    '              ByVal dtmClienteEspecialVigencia As Date
    '                 - 
    '              ByVal fltClienteEspecialMaximoPorcentajeCopago As Double
    '                 - 
    '              ByVal fltClienteEspecialMaximoImporteCopago As Double
    '                 - 
    '              ByVal dtmClienteEspecialUltimaModificacion As Date
    '                 - 
    '              ByVal strClienteEspecialModificadoPor As String
    '                 - 
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros en la tabla
    '====================================================================
    Public Shared Function intContar( _
      ByVal intClienteEspecialId As Integer, _
      ByVal intGrupoClienteEspecialId As Integer, _
      ByVal strClienteEspecialNombreId As String, _
      ByVal strClienteEspecialNombre As String, _
      ByVal blnClienteEspecialPagoDeContado As Byte, _
      ByVal fltClienteEspecialDescuento As Double, _
      ByVal dtmClienteEspecialVigencia As Date, _
      ByVal fltClienteEspecialMaximoPorcentajeCopago As Double, _
      ByVal fltClienteEspecialMaximoImporteCopago As Double, _
      ByVal dtmClienteEspecialUltimaModificacion As Date, _
      ByVal strClienteEspecialModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spContartblClienteEspecial ")
            Call strSQLStatement.Append(intClienteEspecialId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intGrupoClienteEspecialId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strClienteEspecialNombreId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strClienteEspecialNombre)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnClienteEspecialPagoDeContado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialDescuento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmClienteEspecialVigencia.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialMaximoPorcentajeCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialMaximoImporteCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmClienteEspecialUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strClienteEspecialModificadoPor)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            For Each strRowsAffected In strRegistros
                intRowsAffected = CInt(strRowsAffected.GetValue(0))
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

            ' Notificamos el error
            Throw

        End Try

    End Function

    ''====================================================================
    '' Name       : intEliminar
    '' Description: Eliminación de registros.
    ''                 - Tabla tblClienteEspecial
    '' Parameters : 
    ''              ByVal intClienteEspecialId As Integer
    ''                 - 
    ''              ByVal intGrupoClienteEspecialId As Integer
    ''                 - 
    ''              ByVal strClienteEspecialNombreId As String
    ''                 - 
    ''              ByVal strClienteEspecialNombre As String
    ''                 - 
    ''              ByVal blnClienteEspecialPagoDeContado As Byte
    ''                 - 
    ''              ByVal fltClienteEspecialDescuento As Double
    ''                 - 
    ''              ByVal dtmClienteEspecialVigencia As Date
    ''                 - 
    ''              ByVal fltClienteEspecialMaximoPorcentajeCopago As Double
    ''                 - 
    ''              ByVal fltClienteEspecialMaximoImporteCopago As Double
    ''                 - 
    ''              ByVal dtmClienteEspecialUltimaModificacion As Date
    ''                 - 
    ''              ByVal strClienteEspecialModificadoPor As String
    ''                 - 
    ''              ByVal strConnectionString As String
    ''                 - Cadena de conexión hacia el RDBMS
    '' Throws     : Exception
    '' Output     : Integer
    ''                 - Número de registros afectados por el comando
    ''====================================================================
    'Public Shared Function intEliminar( _
    '  ByVal intClienteEspecialId As Integer, _
    '  ByVal intGrupoClienteEspecialId As Integer, _
    '  ByVal strClienteEspecialNombreId As String, _
    '  ByVal strClienteEspecialNombre As String, _
    '  ByVal blnClienteEspecialPagoDeContado As Byte, _
    '  ByVal fltClienteEspecialDescuento As Double, _
    '  ByVal dtmClienteEspecialVigencia As Date, _
    '  ByVal fltClienteEspecialMaximoPorcentajeCopago As Double, _
    '  ByVal fltClienteEspecialMaximoImporteCopago As Double, _
    '  ByVal dtmClienteEspecialUltimaModificacion As Date, _
    '  ByVal strClienteEspecialModificadoPor As String, _
    '  ByVal strConnectionString As String) As Integer

    '    ' Constantes locales
    '    Const strmThisMemberName As String = "intEliminar"

    '    ' Variables locales
    '    Dim strSQLStatement As StringBuilder = Nothing
    '    Dim intRowsAffected As Integer = 0
    '    Dim strRegistros As Array = Nothing
    '    Dim strRowsAffected As String() = Nothing

    '    Try

    '        ' Inicializamos las varialbes locales
    '        strSQLStatement = New StringBuilder

    '        ' Creamos es estatuto de SQL
    '        Call strSQLStatement.Append("EXECUTE spEliminartblClienteEspecial ")
    '        Call strSQLStatement.Append(intClienteEspecialId)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(intGrupoClienteEspecialId)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(strClienteEspecialNombreId)
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(strClienteEspecialNombre)
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(blnClienteEspecialPagoDeContado)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(fltClienteEspecialDescuento)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(dtmClienteEspecialVigencia.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(fltClienteEspecialMaximoPorcentajeCopago)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(fltClienteEspecialMaximoImporteCopago)
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(dtmClienteEspecialUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append("'")
    '        Call strSQLStatement.Append(strClienteEspecialModificadoPor)
    '        Call strSQLStatement.Append("'")

    '        ' Ejecutamos el comando
    '        strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
    '        For Each strRowsAffected In strRegistros
    '            intRowsAffected = CInt(strRowsAffected.GetValue(0))
    '        Next

    '        ' Regresamos la información
    '        strSQLStatement = Nothing
    '        intEliminar = intRowsAffected

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
    '        intEliminar = 0

    '        ' Notificamos el error
    '        Throw

    '    End Try

    'End Function

    '====================================================================
    ' Name       : strBuscar
    ' Description: Búsqueda de registros modificados y que
    '              necesitan ser reenviados.
    '                 - Tabla: tblClienteEspecial
    ' Parameters :
    '              ByVal intSolicitudActualizacionId As Integer
    '
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
      ByVal intSolicitudActualizacionId As Integer, _
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
            Call strSQLStatement.Append("EXECUTE spReenvioCambiotblClienteEspecial ")
            Call strSQLStatement.Append(intSolicitudActualizacionId)
            Call strSQLStatement.Append(",")
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
    ' Name          : intAgregar
    ' Description   : Adds a new record and returns its integer identifier
    ' Table name    : tblClienteEspecial
    ' Parameters    : 
    '              ByVal intClienteEspecialId As Decimal
    '                  - 
    '              ByVal intGrupoClienteEspecialId As Int32
    '                  - 
    '              ByVal strClienteEspecialNombreId As String
    '                  - 
    '              ByVal strClienteEspecialNombre As String
    '                  - 
    '              ByVal blnClienteEspecialPagoDeContado As Boolean
    '                  - 
    '              ByVal fltClienteEspecialDescuento As Decimal
    '                  - 
    '              ByVal dtmClienteEspecialVigencia As DateTime
    '                  - 
    '              ByVal fltClienteEspecialMaximoPorcentajeCopago As Decimal
    '                  - 
    '              ByVal fltClienteEspecialMaximoImporteCopago As Decimal
    '                  - 
    '              ByVal dtmClienteEspecialUltimaModificacion As DateTime
    '                  - 
    '              ByVal strClienteEspecialModificadoPor As String
    '                  - 
    '              ByVal fltClienteEspecialMinimoPorcentajeCopago As Decimal
    '                  - 
    '              ByVal fltClienteEspecialMinimoImporteCopago As Decimal
    '                  - 
    '              ByVal blnClienteEspecialActivo As Boolean
    '                  - 
    '              ByVal blnClienteEspecialRespetarOfertas As Boolean
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intAgregar( _
      ByVal intClienteEspecialId As Decimal, _
      ByVal intGrupoClienteEspecialId As Int32, _
      ByVal strClienteEspecialNombreId As String, _
      ByVal strClienteEspecialNombre As String, _
      ByVal blnClienteEspecialPagoDeContado As Boolean, _
      ByVal fltClienteEspecialDescuento As Decimal, _
      ByVal dtmClienteEspecialVigencia As DateTime, _
      ByVal fltClienteEspecialMaximoPorcentajeCopago As Decimal, _
      ByVal fltClienteEspecialMaximoImporteCopago As Decimal, _
      ByVal dtmClienteEspecialUltimaModificacion As DateTime, _
      ByVal strClienteEspecialModificadoPor As String, _
      ByVal fltClienteEspecialMinimoPorcentajeCopago As Decimal, _
      ByVal fltClienteEspecialMinimoImporteCopago As Decimal, _
      ByVal blnClienteEspecialActivo As Boolean, _
      ByVal blnClienteEspecialRespetarOfertas As Boolean, _
      ByVal blnClienteEspecialExcedidoEnLimiteCredito As Boolean, _
      ByVal strConnectionString As String) As Integer

        ' Member identifier
        Const strmThisMemberName As String = "intAgregar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRecordId As Integer
        Dim aobjReturnedData As Array

        Try

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spAgregartblClienteEspecial ")
            Call strSQLStatement.Append(intClienteEspecialId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intGrupoClienteEspecialId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strClienteEspecialNombreId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strClienteEspecialNombre)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnClienteEspecialPagoDeContado))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialDescuento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmClienteEspecialVigencia.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialMaximoPorcentajeCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialMaximoImporteCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmClienteEspecialUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strClienteEspecialModificadoPor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialMinimoPorcentajeCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialMinimoImporteCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnClienteEspecialActivo))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnClienteEspecialRespetarOfertas))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnClienteEspecialExcedidoEnLimiteCredito))

            ' Execute the SQL statement
            aobjReturnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

            ' Return the results
            If IsNothing(aobjReturnedData) = False AndAlso aobjReturnedData.Length > 0 Then
                intRecordId = CInt(DirectCast(aobjReturnedData.GetValue(0), SortedList).GetByIndex(0))
            End If
            aobjReturnedData = Nothing
            Return intRecordId

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
    ' Name          : intEliminar
    ' Description   : Deletes records and returns the number of deleted items
    ' Table name    : tblClienteEspecial
    ' Parameters    : 
    '              ByVal intClienteEspecialId As Decimal
    '                  - 
    '              ByVal intGrupoClienteEspecialId As Int32
    '                  - 
    '              ByVal strClienteEspecialNombreId As String
    '                  - 
    '              ByVal strClienteEspecialNombre As String
    '                  - 
    '              ByVal blnClienteEspecialPagoDeContado As Boolean
    '                  - 
    '              ByVal fltClienteEspecialDescuento As Decimal
    '                  - 
    '              ByVal dtmClienteEspecialVigencia As DateTime
    '                  - 
    '              ByVal fltClienteEspecialMaximoPorcentajeCopago As Decimal
    '                  - 
    '              ByVal fltClienteEspecialMaximoImporteCopago As Decimal
    '                  - 
    '              ByVal dtmClienteEspecialUltimaModificacion As DateTime
    '                  - 
    '              ByVal strClienteEspecialModificadoPor As String
    '                  - 
    '              ByVal fltClienteEspecialMinimoPorcentajeCopago As Decimal
    '                  - 
    '              ByVal fltClienteEspecialMinimoImporteCopago As Decimal
    '                  - 
    '              ByVal blnClienteEspecialActivo As Boolean
    '                  - 
    '              ByVal blnClienteEspecialRespetarOfertas As Boolean
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intEliminar( _
      ByVal intClienteEspecialId As Decimal, _
      ByVal intGrupoClienteEspecialId As Int32, _
      ByVal strClienteEspecialNombreId As String, _
      ByVal strClienteEspecialNombre As String, _
      ByVal blnClienteEspecialPagoDeContado As Boolean, _
      ByVal fltClienteEspecialDescuento As Decimal, _
      ByVal dtmClienteEspecialVigencia As DateTime, _
      ByVal fltClienteEspecialMaximoPorcentajeCopago As Decimal, _
      ByVal fltClienteEspecialMaximoImporteCopago As Decimal, _
      ByVal dtmClienteEspecialUltimaModificacion As DateTime, _
      ByVal strClienteEspecialModificadoPor As String, _
      ByVal fltClienteEspecialMinimoPorcentajeCopago As Decimal, _
      ByVal fltClienteEspecialMinimoImporteCopago As Decimal, _
      ByVal blnClienteEspecialActivo As Boolean, _
      ByVal blnClienteEspecialRespetarOfertas As Boolean, _
      ByVal blnClienteEspecialExcedidoEnLimiteCredito As Boolean, _
      ByVal strConnectionString As String) As Integer

        ' Member identifier
        Const strmThisMemberName As String = "intEliminar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRowsAffected As Integer
        Dim aobjReturnedData As Array

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spEliminartblClienteEspecial ")
            Call strSQLStatement.Append(intClienteEspecialId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intGrupoClienteEspecialId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strClienteEspecialNombreId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strClienteEspecialNombre)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnClienteEspecialPagoDeContado))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialDescuento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmClienteEspecialVigencia.ToString("MM/dd/yyyy HH:mm:ss"))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialMaximoPorcentajeCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialMaximoImporteCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmClienteEspecialUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss"))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strClienteEspecialModificadoPor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialMinimoPorcentajeCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialMinimoImporteCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnClienteEspecialActivo))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnClienteEspecialRespetarOfertas))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnClienteEspecialExcedidoEnLimiteCredito))

            ' Execute the SQL statement
            aobjReturnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

            ' Return the results
            If IsNothing(aobjReturnedData) = False AndAlso aobjReturnedData.Length > 0 Then
                intRowsAffected = CInt(DirectCast(aobjReturnedData.GetValue(0), SortedList).GetByIndex(0))
            End If
            aobjReturnedData = Nothing
            Return intRowsAffected

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
    ' Name          : strBuscar
    ' Description   : Returns an array of SortedList objects with the records found
    ' Table name    : tblClienteEspecial
    ' Parameters    : 
    '              ByVal intClienteEspecialId As Decimal
    '                  - 
    '              ByVal intGrupoClienteEspecialId As Int32
    '                  - 
    '              ByVal strClienteEspecialNombreId As String
    '                  - 
    '              ByVal strClienteEspecialNombre As String
    '                  - 
    '              ByVal blnClienteEspecialPagoDeContado As Boolean
    '                  - 
    '              ByVal fltClienteEspecialDescuento As Decimal
    '                  - 
    '              ByVal dtmClienteEspecialVigencia As DateTime
    '                  - 
    '              ByVal fltClienteEspecialMaximoPorcentajeCopago As Decimal
    '                  - 
    '              ByVal fltClienteEspecialMaximoImporteCopago As Decimal
    '                  - 
    '              ByVal dtmClienteEspecialUltimaModificacion As DateTime
    '                  - 
    '              ByVal strClienteEspecialModificadoPor As String
    '                  - 
    '              ByVal fltClienteEspecialMinimoPorcentajeCopago As Decimal
    '                  - 
    '              ByVal fltClienteEspecialMinimoImporteCopago As Decimal
    '                  - 
    '              ByVal blnClienteEspecialActivo As Boolean
    '                  - 
    '              ByVal blnClienteEspecialRespetarOfertas As Boolean
    '                  - 
    '              ByVal intInitialPosition As  Double
    '                 - Initial position
    '              ByVal intElementsToRetrieve As Double
    '                 - Number of elements per page
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Array
    '====================================================================
    Public Shared Function strBuscar( _
      ByVal intClienteEspecialId As Decimal, _
      ByVal intGrupoClienteEspecialId As Int32, _
      ByVal strClienteEspecialNombreId As String, _
      ByVal strClienteEspecialNombre As String, _
      ByVal blnClienteEspecialPagoDeContado As Boolean, _
      ByVal fltClienteEspecialDescuento As Decimal, _
      ByVal dtmClienteEspecialVigencia As DateTime, _
      ByVal fltClienteEspecialMaximoPorcentajeCopago As Decimal, _
      ByVal fltClienteEspecialMaximoImporteCopago As Decimal, _
      ByVal dtmClienteEspecialUltimaModificacion As DateTime, _
      ByVal strClienteEspecialModificadoPor As String, _
      ByVal fltClienteEspecialMinimoPorcentajeCopago As Decimal, _
      ByVal fltClienteEspecialMinimoImporteCopago As Decimal, _
      ByVal blnClienteEspecialActivo As Boolean, _
      ByVal blnClienteEspecialRespetarOfertas As Boolean, _
      ByVal blnClienteEspecialExcedidoEnLimiteCredito As Boolean, _
      ByVal intInitialPosition As Double, _
      ByVal intElementsToRetrieve As Double, _
      ByVal strConnectionString As String) As Array

        ' Member identifier
        Const strmThisMemberName As String = "strBuscar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array

        Try

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spBuscartblClienteEspecial ")
            Call strSQLStatement.Append(intClienteEspecialId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intGrupoClienteEspecialId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strClienteEspecialNombreId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strClienteEspecialNombre)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnClienteEspecialPagoDeContado))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialDescuento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmClienteEspecialVigencia.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialMaximoPorcentajeCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialMaximoImporteCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmClienteEspecialUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strClienteEspecialModificadoPor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialMinimoPorcentajeCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialMinimoImporteCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnClienteEspecialActivo))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnClienteEspecialRespetarOfertas))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnClienteEspecialExcedidoEnLimiteCredito))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intInitialPosition)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intElementsToRetrieve)

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
    ' Name          : intActualizar
    ' Description   : Updates records and returns the number of updated items
    ' Table name    : tblClienteEspecial
    ' Parameters    : 
    '              ByVal intClienteEspecialId As Decimal
    '                  - 
    '              ByVal intGrupoClienteEspecialId As Int32
    '                  - 
    '              ByVal strClienteEspecialNombreId As String
    '                  - 
    '              ByVal strClienteEspecialNombre As String
    '                  - 
    '              ByVal blnClienteEspecialPagoDeContado As Boolean
    '                  - 
    '              ByVal fltClienteEspecialDescuento As Decimal
    '                  - 
    '              ByVal dtmClienteEspecialVigencia As DateTime
    '                  - 
    '              ByVal fltClienteEspecialMaximoPorcentajeCopago As Decimal
    '                  - 
    '              ByVal fltClienteEspecialMaximoImporteCopago As Decimal
    '                  - 
    '              ByVal dtmClienteEspecialUltimaModificacion As DateTime
    '                  - 
    '              ByVal strClienteEspecialModificadoPor As String
    '                  - 
    '              ByVal fltClienteEspecialMinimoPorcentajeCopago As Decimal
    '                  - 
    '              ByVal fltClienteEspecialMinimoImporteCopago As Decimal
    '                  - 
    '              ByVal blnClienteEspecialActivo As Boolean
    '                  - 
    '              ByVal blnClienteEspecialRespetarOfertas As Boolean
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Integer
    '====================================================================
    Public Shared Function intActualizar( _
      ByVal intClienteEspecialId As Decimal, _
      ByVal intGrupoClienteEspecialId As Int32, _
      ByVal strClienteEspecialNombreId As String, _
      ByVal strClienteEspecialNombre As String, _
      ByVal blnClienteEspecialPagoDeContado As Boolean, _
      ByVal fltClienteEspecialDescuento As Decimal, _
      ByVal dtmClienteEspecialVigencia As DateTime, _
      ByVal fltClienteEspecialMaximoPorcentajeCopago As Decimal, _
      ByVal fltClienteEspecialMaximoImporteCopago As Decimal, _
      ByVal dtmClienteEspecialUltimaModificacion As DateTime, _
      ByVal strClienteEspecialModificadoPor As String, _
      ByVal fltClienteEspecialMinimoPorcentajeCopago As Decimal, _
      ByVal fltClienteEspecialMinimoImporteCopago As Decimal, _
      ByVal blnClienteEspecialActivo As Boolean, _
      ByVal blnClienteEspecialRespetarOfertas As Boolean, _
      ByVal blnClienteEspecialExcedidoEnLimiteCredito As Boolean, _
      ByVal strConnectionString As String) As Integer

        ' Member identifier
        Const strmThisMemberName As String = "intActualizar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRowsAffected As Integer
        Dim aobjReturnedData As Array

        Try

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spActualizartblClienteEspecial ")
            Call strSQLStatement.Append(intClienteEspecialId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intGrupoClienteEspecialId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strClienteEspecialNombreId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strClienteEspecialNombre)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnClienteEspecialPagoDeContado))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialDescuento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmClienteEspecialVigencia.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialMaximoPorcentajeCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialMaximoImporteCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmClienteEspecialUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strClienteEspecialModificadoPor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialMinimoPorcentajeCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltClienteEspecialMinimoImporteCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnClienteEspecialActivo))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnClienteEspecialRespetarOfertas))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnClienteEspecialExcedidoEnLimiteCredito))

            ' Execute the SQL statement
            aobjReturnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

            ' Return the results
            If IsNothing(aobjReturnedData) = False AndAlso aobjReturnedData.Length > 0 Then
                intRowsAffected = CInt(DirectCast(aobjReturnedData.GetValue(0), SortedList).GetByIndex(0))
            End If
            aobjReturnedData = Nothing
            Return intRowsAffected

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
