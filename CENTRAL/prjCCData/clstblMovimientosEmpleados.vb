
Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clstblMovimientosEmpleados
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : 2008 Todos los Derechos Reservados.
' Company       : Isocraft S.A. de C.V.
' Author        : Dirección de Tecnología
' Version       : 1.0.0
' Last Modified : Saturday, May 17, 2008
'====================================================================
Public NotInheritable Class clstblMovimientosEmpleados


    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblMovimientosEmpleados"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()
    End Sub

    '====================================================================
    ' Name       : intActualizar
    ' Description: Actualización de registros.
    '                 - Tabla tblMovimientosEmpleados
    ' Parameters : 
    '               ByVal intMovimientoEmpleadoId As Integer
    '                   -
    '               ByVal intCompaniaId As Integer
    '                   -
    '               ByVal intSucursalId As Integer
    '                   -
    '               ByVal intMovimientoId As Integer
    '                   -
    '               ByVal dtmMovimientoEmpleadoRegistro As Date
    '                   -
    '               ByVal strFolio As String
    '                   -
    '               ByVal dtmCierreSucursal As Date
    '                   -
    '               ByVal dtmHoraEntrada As Date
    '                   -
    '               ByVal dtmHoraSalida As Date
    '                   -
    '               ByVal fltDiasHoras As Double
    '                   -
    '               ByVal intEmpleadoId As Integer
    '                   -
    '               ByVal intTurnoLaboralId As Integer
    '                   -
    '               ByVal strObservaciones As String
    '                   -
    '               ByVal strMovimientoEmpleadoModificadoPor As String
    '                   -
    '               ByVal dtmMovimientoEmpleadoUltimaModificacion As Date
    '                   -
    '               ByVal strConnectionString As String
    '                   - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================
    Public Shared Function intActualizar(ByVal intMovimientoEmpleadoId As Integer, _
                            ByVal intCompaniaId As Integer, _
                            ByVal intSucursalId As Integer, _
                            ByVal intMovimientoId As Integer, _
                            ByVal dtmMovimientoEmpleadoRegistro As Date, _
                            ByVal strFolio As String, _
                            ByVal dtmCierreSucursal As Date, _
                            ByVal dtmHoraEntrada As Date, _
                            ByVal dtmHoraSalida As Date, _
                            ByVal fltDiasHoras As Double, _
                            ByVal intEmpleadoId As Integer, _
                            ByVal intTurnoLaboralId As Integer, _
                            ByVal strObservaciones As String, _
                            ByVal strMovimientoEmpleadoModificadoPor As String, _
                            ByVal dtmMovimientoEmpleadoUltimaModificacion As Date, _
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
            Call strSQLStatement.Append("EXECUTE spActualizartblMovimientosEmpleados ")
            Call strSQLStatement.Append(intMovimientoEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoEmpleadoRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strFolio)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmCierreSucursal.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmHoraEntrada.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmHoraSalida.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltDiasHoras)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTurnoLaboralId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strObservaciones)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoEmpleadoModificadoPor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoEmpleadoUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
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
    '                 - Tabla tblMovimientosEmpleados
    ' Parameters : 
    '               ByVal intMovimientoEmpleadoId As Integer
    '                   -
    '               ByVal intCompaniaId As Integer
    '                   -
    '               ByVal intSucursalId As Integer
    '                   -
    '               ByVal intMovimientoId As Integer
    '                   -
    '               ByVal dtmMovimientoEmpleadoRegistro As Date
    '                   -
    '               ByVal strFolio As String
    '                   -
    '               ByVal dtmCierreSucursal As Date
    '                   -
    '               ByVal dtmHoraEntrada As Date
    '                   -
    '               ByVal dtmHoraSalida As Date
    '                   -
    '               ByVal fltDiasHoras As Double
    '                   -
    '               ByVal intEmpleadoId As Integer
    '                   -
    '               ByVal intTurnoLaboralId As Integer
    '                   -
    '               ByVal strObservaciones As String
    '                   -
    '               ByVal strMovimientoEmpleadoModificadoPor As String
    '                   -
    '               ByVal dtmMovimientoEmpleadoUltimaModificacion As Date
    '                   -
    '               ByVal strConnectionString As String
    '                   - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================
    Public Shared Function intAgregar(ByVal intMovimientoEmpleadoId As Integer, _
                            ByVal intCompaniaId As Integer, _
                            ByVal intSucursalId As Integer, _
                            ByVal intMovimientoId As Integer, _
                            ByVal dtmMovimientoEmpleadoRegistro As Date, _
                            ByVal strFolio As String, _
                            ByVal dtmCierreSucursal As Date, _
                            ByVal dtmHoraEntrada As Date, _
                            ByVal dtmHoraSalida As Date, _
                            ByVal fltDiasHoras As Double, _
                            ByVal intEmpleadoId As Integer, _
                            ByVal intTurnoLaboralId As Integer, _
                            ByVal strObservaciones As String, _
                            ByVal strMovimientoEmpleadoModificadoPor As String, _
                            ByVal dtmMovimientoEmpleadoUltimaModificacion As Date, _
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
            Call strSQLStatement.Append("EXECUTE spAgregartblMovimientosEmpleados ")
            Call strSQLStatement.Append(intMovimientoEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoEmpleadoRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strFolio)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmCierreSucursal.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmHoraEntrada.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmHoraSalida.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltDiasHoras)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTurnoLaboralId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strObservaciones)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoEmpleadoModificadoPor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoEmpleadoUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
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
    '                 - Tabla tblMovimientosEmpleados
    ' Parameters : 
    '               ByVal intMovimientoEmpleadoId As Integer
    '                   -
    '               ByVal intCompaniaId As Integer
    '                   -
    '               ByVal intSucursalId As Integer
    '                   -
    '               ByVal intMovimientoId As Integer
    '                   -
    '               ByVal dtmMovimientoEmpleadoRegistro As Date
    '                   -
    '               ByVal strFolio As String
    '                   -
    '               ByVal dtmCierreSucursal As Date
    '                   -
    '               ByVal dtmHoraEntrada As Date
    '                   -
    '               ByVal dtmHoraSalida As Date
    '                   -
    '               ByVal fltDiasHoras As Double
    '                   -
    '               ByVal intEmpleadoId As Integer
    '                   -
    '               ByVal intTurnoLaboralId As Integer
    '                   -
    '               ByVal strObservaciones As String
    '                   -
    '               ByVal strMovimientoEmpleadoModificadoPor As String
    '                   -
    '               ByVal dtmMovimientoEmpleadoUltimaModificacion As Date
    '                   -
    '               ByVal strConnectionString As String
    '                   - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '                 - Arreglo bidimensional con los registros leídos
    '                   Array = { (c1,c2..cn), (c1,c2..cn) ... (c1,c2..cn) }
    '                   c = Campo
    '====================================================================
    Shared Function strBuscar(ByVal intMovimientoEmpleadoId As Integer, _
                            ByVal intCompaniaId As Integer, _
                            ByVal intSucursalId As Integer, _
                            ByVal intMovimientoId As Integer, _
                            ByVal dtmMovimientoEmpleadoRegistro As Date, _
                            ByVal strFolio As String, _
                            ByVal dtmCierreSucursal As Date, _
                            ByVal dtmHoraEntrada As Date, _
                            ByVal dtmHoraSalida As Date, _
                            ByVal fltDiasHoras As Double, _
                            ByVal intEmpleadoId As Integer, _
                            ByVal intTurnoLaboralId As Integer, _
                            ByVal strObservaciones As String, _
                            ByVal strMovimientoEmpleadoModificadoPor As String, _
                            ByVal dtmMovimientoEmpleadoUltimaModificacion As Date, _
                            ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscartblMovimientosEmpleados ")
            Call strSQLStatement.Append(intMovimientoEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoEmpleadoRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strFolio)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmCierreSucursal.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmHoraEntrada.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmHoraSalida.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltDiasHoras)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTurnoLaboralId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strObservaciones)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoEmpleadoModificadoPor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoEmpleadoUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")



            ' Ejecutamos el comando
            strBuscar = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
            strBuscar = Nothing

        End Try

    End Function

End Class
