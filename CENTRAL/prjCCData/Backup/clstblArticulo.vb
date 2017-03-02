
Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clstblArticulo
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : 2003-2005 Todos los Derechos Reservados.
' Company       : Isocraft S.A. de C.V.
' Author        : Dirección de Tecnología
' Version       : 1.0.1311.33021
' Last Modified : Monday, November 10, 2003
'               : Tuesday, May 04, 2009 - Softtek - VCSG
'====================================================================
Public NotInheritable Class clstblArticulo

    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblArticulo"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()
    End Sub

    '====================================================================
    ' Name       : intActualizar
    ' Description: Actualización de registros.
    '                 - Tabla tblArticulo
    ' Parameters : 
    '              ByVal intArticuloId As Integer
    '                 - 
    '              ByVal intCategoriaArticuloId As Integer
    '                 - 
    '              ByVal intTipoEntregaArticuloId As Integer
    '                 - 
    '              ByVal intClaveVigenciaArticuloId As Integer
    '                 - 
    '              ByVal intDepartamentoId As Integer
    '                 - 
    '              ByVal intMarcaArticuloId As Integer
    '                 - 
    '              ByVal intTipoArticuloId As Integer
    '                 - 
    '              ByVal strArticuloDescripcion As String
    '                 - 
    '              ByVal blnArticuloCaduca As Byte
    '                 - 
    '              ByVal intArticuloPiezasUnidad As Integer
    '                 - 
    '              ByVal fltArticuloMontoComision As Double
    '                 - 
    '              ByVal blnArticuloConsignado As Byte
    '                 - 
    '              ByVal fltArticuloPrecioOficial As Double
    '                 - 
    '              ByVal blnArticuloImportado As Byte
    '                 - 
    '              ByVal strArticuloSustanciaActiva As String
    '                 - 
    '              ByVal strArticuloContraindicaciones As String
    '                 - 
    '              ByVal strArticuloInstruccionesCaducidad As String
    '                 - 
    '              ByVal fltArticuloPorcentajeCastigo As Double
    '                 - 
    '              ByVal strArticuloPlazoDevolucion As String
    '                 - 
    '              ByVal strArticuloMedioDevolucion As String
    '                 - 
    '              ByVal strArticuloIndicacionesUso As String
    '                 - 
    '              ByVal strArticuloCodigoGPI As String
    '                  -
    '              ByVal fltArticuloPuntosComision As Double
    '                  -
    '              ByVal fltArticuloCantidadUnidades As Double
    '                  -
    '              ByVal blnArticuloControlado As Byte
    '                  -
    '              ByVal strProveedorNombreId As String
    '                  -
    '              ByVal blnArticuloAntibiotico As Byte
    '                  -
    '              ByVal strArticuloModificadoPor As String
    '                 - 
    '              ByVal dtmArticuloUltimaModificacion As Date
    '                 - 
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    'PATG 201303
    '====================================================================
    Public Shared Function intActualizar( _
      ByVal intArticuloId As Integer, _
      ByVal intCategoriaArticuloId As Integer, _
      ByVal intTipoEntregaArticuloId As Integer, _
      ByVal intClaveVigenciaArticuloId As Integer, _
      ByVal intDepartamentoId As Integer, _
      ByVal intMarcaArticuloId As Integer, _
      ByVal intTipoArticuloId As Integer, _
      ByVal strArticuloDescripcion As String, _
      ByVal blnArticuloCaduca As Byte, _
      ByVal intArticuloPiezasUnidad As Integer, _
      ByVal fltArticuloMontoComision As Double, _
      ByVal fltArticuloMontoComisionEspecial As Double, _
      ByVal blnArticuloConsignado As Byte, _
      ByVal fltArticuloPrecioOficial As Double, _
      ByVal blnArticuloImportado As Byte, _
      ByVal strArticuloSustanciaActiva As String, _
      ByVal strArticuloContraindicaciones As String, _
      ByVal strArticuloInstruccionesCaducidad As String, _
      ByVal fltArticuloPorcentajeCastigo As Double, _
      ByVal strArticuloPlazoDevolucion As String, _
      ByVal strArticuloMedioDevolucion As String, _
      ByVal strArticuloIndicacionesUso As String, _
      ByVal strArticuloCodigoGPI As String, _
      ByVal fltArticuloPuntosComision As Double, _
      ByVal fltArticuloCantidadUnidades As Double, _
      ByVal blnArticuloControlado As Byte, _
      ByVal strProveedorNombreId As String, _
      ByVal blnArticuloAntibiotico As Byte, _
      ByVal blnArticuloGenerico As Byte, _
      ByVal strArticuloModificadoPor As String, _
      ByVal dtmArticuloUltimaModificacion As Date, _
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
            Call strSQLStatement.Append("EXECUTE spActualizartblArticulo ")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCategoriaArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoEntregaArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intClaveVigenciaArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDepartamentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMarcaArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloCaduca)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloPiezasUnidad)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloMontoComision)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloMontoComisionEspecial)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloConsignado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloPrecioOficial)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloImportado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloSustanciaActiva)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloContraindicaciones)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloInstruccionesCaducidad)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloPorcentajeCastigo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloPlazoDevolucion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloMedioDevolucion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloIndicacionesUso)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloCodigoGPI)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloPuntosComision)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloCantidadUnidades)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloControlado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strProveedorNombreId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloAntibiotico)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloGenerico)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloModificadoPor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
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
    '                  - Tabla tblArticulo
    ' Parameters : 
    '              ByVal intArticuloId As Integer
    '                  - 
    '              ByVal intCategoriaArticuloId As Integer
    '                  - 
    '              ByVal intTipoEntregaArticuloId As Integer
    '                  - 
    '              ByVal intClaveVigenciaArticuloId As Integer
    '                  - 
    '              ByVal intDepartamentoId As Integer
    '                  - 
    '              ByVal intMarcaArticuloId As Integer
    '                  - 
    '              ByVal intTipoArticuloId As Integer
    '                  - 
    '              ByVal strArticuloDescripcion As String
    '                  - 
    '              ByVal blnArticuloCaduca As Byte
    '                  - 
    '              ByVal intArticuloPiezasUnidad As Integer
    '                  - 
    '              ByVal fltArticuloMontoComision As Double
    '                  - 
    '              ByVal blnArticuloConsignado As Byte
    '                  - 
    '              ByVal fltArticuloPrecioOficial As Double
    '                  - 
    '              ByVal blnArticuloImportado As Byte
    '                  - 
    '              ByVal strArticuloSustanciaActiva As String
    '                  - 
    '              ByVal strArticuloContraindicaciones As String
    '                  - 
    '              ByVal strArticuloInstruccionesCaducidad As String
    '                  - 
    '              ByVal fltArticuloPorcentajeCastigo As Double
    '                  - 
    '              ByVal strArticuloPlazoDevolucion As String
    '                  - 
    '              ByVal strArticuloMedioDevolucion As String
    '                  - 
    '              ByVal strArticuloIndicacionesUso As String
    '                  - 
    '              ByVal strArticuloCodigoGPI As String
    '                  -
    '              ByVal fltArticuloPuntosComision As Double
    '                  -
    '              ByVal fltArticuloCantidadUnidades As Double
    '                  -
    '              ByVal blnArticuloControlado As Byte
    '                  -
    '              ByVal strProveedorNombreId As String
    '                  -
    '              ByVal blnArticuloAntibiotico As Byte
    '                  -
    '              ByVal strArticuloModificadoPor As String
    '                  - 
    '              ByVal dtmArticuloUltimaModificacion As Date
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================
    Public Shared Function intAgregar( _
      ByVal intArticuloId As Integer, _
      ByVal intCategoriaArticuloId As Integer, _
      ByVal intTipoEntregaArticuloId As Integer, _
      ByVal intClaveVigenciaArticuloId As Integer, _
      ByVal intDepartamentoId As Integer, _
      ByVal intMarcaArticuloId As Integer, _
      ByVal intTipoArticuloId As Integer, _
      ByVal strArticuloDescripcion As String, _
      ByVal blnArticuloCaduca As Byte, _
      ByVal intArticuloPiezasUnidad As Integer, _
      ByVal fltArticuloMontoComision As Double, _
      ByVal blnArticuloConsignado As Byte, _
      ByVal fltArticuloPrecioOficial As Double, _
      ByVal blnArticuloImportado As Byte, _
      ByVal strArticuloSustanciaActiva As String, _
      ByVal strArticuloContraindicaciones As String, _
      ByVal strArticuloInstruccionesCaducidad As String, _
      ByVal fltArticuloPorcentajeCastigo As Double, _
      ByVal strArticuloPlazoDevolucion As String, _
      ByVal strArticuloMedioDevolucion As String, _
      ByVal strArticuloIndicacionesUso As String, _
      ByVal strArticuloCodigoGPI As String, _
      ByVal fltArticuloPuntosComision As Double, _
      ByVal fltArticuloCantidadUnidades As Double, _
      ByVal blnArticuloControlado As Byte, _
      ByVal strProveedorNombreId As String, _
      ByVal blnArticuloAntibiotico As Byte, _
      ByVal strArticuloModificadoPor As String, _
      ByVal dtmArticuloUltimaModificacion As Date, _
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
            Call strSQLStatement.Append("EXECUTE spAgregartblArticulo ")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCategoriaArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoEntregaArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intClaveVigenciaArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDepartamentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMarcaArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloCaduca)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloPiezasUnidad)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloMontoComision)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloConsignado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloPrecioOficial)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloImportado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloSustanciaActiva)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloContraindicaciones)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloInstruccionesCaducidad)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloPorcentajeCastigo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloPlazoDevolucion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloMedioDevolucion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloIndicacionesUso)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloCodigoGPI)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloPuntosComision)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloCantidadUnidades)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloControlado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strProveedorNombreId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloAntibiotico)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloModificadoPor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
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
    '                 - Tabla tblArticulo
    ' Parameters : 
    '              ByVal intArticuloId As Integer
    '                 - 
    '              ByVal intCategoriaArticuloId As Integer
    '                 - 
    '              ByVal intTipoEntregaArticuloId As Integer
    '                 - 
    '              ByVal intClaveVigenciaArticuloId As Integer
    '                 - 
    '              ByVal intDepartamentoId As Integer
    '                 - 
    '              ByVal intMarcaArticuloId As Integer
    '                 - 
    '              ByVal intTipoArticuloId As Integer
    '                 - 
    '              ByVal strArticuloDescripcion As String
    '                 - 
    '              ByVal blnArticuloCaduca As Byte
    '                 - 
    '              ByVal intArticuloPiezasUnidad As Integer
    '                 - 
    '              ByVal fltArticuloMontoComision As Double
    '                 - 
    '              ByVal blnArticuloConsignado As Byte
    '                 - 
    '              ByVal fltArticuloPrecioOficial As Double
    '                 - 
    '              ByVal blnArticuloImportado As Byte
    '                 - 
    '              ByVal strArticuloSustanciaActiva As String
    '                 - 
    '              ByVal strArticuloContraindicaciones As String
    '                 - 
    '              ByVal strArticuloInstruccionesCaducidad As String
    '                 - 
    '              ByVal fltArticuloPorcentajeCastigo As Double
    '                 - 
    '              ByVal strArticuloPlazoDevolucion As String
    '                 - 
    '              ByVal strArticuloMedioDevolucion As String
    '                 - 
    '              ByVal strArticuloIndicacionesUso As String
    '                 - 
    '              ByVal strArticuloCodigoGPI As String
    '                 -
    '              ByVal fltArticuloPuntosComision As Double
    '                 -
    '              ByVal fltArticuloCantidadUnidades As Double
    '                  -
    '              ByVal blnArticuloControlado As Byte
    '                  -
    '              ByVal strProveedorNombreId As String
    '                  -
    '              ByVal blnArticuloAntibiotico As Byte
    '                  -
    '              ByVal strArticuloModificadoPor As String
    '                 - 
    '              ByVal dtmArticuloUltimaModificacion As Date
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
    'PATG 201303
    '====================================================================
    Public Shared Function strBuscar( _
      ByVal intArticuloId As Integer, _
      ByVal intCategoriaArticuloId As Integer, _
      ByVal intTipoEntregaArticuloId As Integer, _
      ByVal intClaveVigenciaArticuloId As Integer, _
      ByVal intDepartamentoId As Integer, _
      ByVal intMarcaArticuloId As Integer, _
      ByVal intTipoArticuloId As Integer, _
      ByVal strArticuloDescripcion As String, _
      ByVal blnArticuloCaduca As Byte, _
      ByVal intArticuloPiezasUnidad As Integer, _
      ByVal fltArticuloMontoComision As Double, _
      ByVal fltArticuloMontoComisionEspecial As Double, _
      ByVal blnArticuloConsignado As Byte, _
      ByVal fltArticuloPrecioOficial As Double, _
      ByVal blnArticuloImportado As Byte, _
      ByVal strArticuloSustanciaActiva As String, _
      ByVal strArticuloContraindicaciones As String, _
      ByVal strArticuloInstruccionesCaducidad As String, _
      ByVal fltArticuloPorcentajeCastigo As Double, _
      ByVal strArticuloPlazoDevolucion As String, _
      ByVal strArticuloMedioDevolucion As String, _
      ByVal strArticuloIndicacionesUso As String, _
      ByVal strArticuloCodigoGPI As String, _
      ByVal fltArticuloPuntosComision As Double, _
      ByVal fltArticuloCantidadUnidades As Double, _
      ByVal blnArticuloControlado As Byte, _
      ByVal strProveedorNombreId As String, _
      ByVal blnArticuloAntibiotico As Byte, _
      ByVal blnArticuloGenerico As Byte, _
      ByVal strArticuloModificadoPor As String, _
      ByVal dtmArticuloUltimaModificacion As Date, _
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
            Call strSQLStatement.Append("EXECUTE spBuscartblArticulo ")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCategoriaArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoEntregaArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intClaveVigenciaArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDepartamentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMarcaArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloCaduca)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloPiezasUnidad)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloMontoComision)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloMontoComisionEspecial)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloConsignado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloPrecioOficial)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloImportado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloSustanciaActiva)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloContraindicaciones)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloInstruccionesCaducidad)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloPorcentajeCastigo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloPlazoDevolucion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloMedioDevolucion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloIndicacionesUso)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloCodigoGPI)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloPuntosComision)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloCantidadUnidades)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloControlado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strProveedorNombreId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloAntibiotico)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloGenerico)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloModificadoPor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
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
    '                 - Tabla tblArticulo
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
            Call strSQLStatement.Append("EXECUTE spBuscarCambiotblArticulo ")
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
    ' Name       : strBuscar
    ' Description: Búsqueda de registros modificados y que
    '              necesitan ser reenviados.
    '                 - Tabla tblArticulo
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
            Call strSQLStatement.Append("EXECUTE spReenvioCambiotblArticulo ")
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
    ' Name       : strBuscar
    ' Description: Búsqueda de registros modificados y que
    '              necesitan ser reenviados.
    '                 - Tabla tblArticulo
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
    Public Shared Function strBuscarCambios( _
      ByVal intTiendaId As Integer, _
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
            Call strSQLStatement.Append("EXECUTE spBuscartblArticuloCambios ")
            Call strSQLStatement.Append(intTiendaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmUltimaModificacionInicial.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmUltimaModificacionFinal.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strBuscarCambios = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
            strBuscarCambios = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function


    '====================================================================
    ' Name       : strBuscarAntibioticos
    ' Description: Búsqueda de registros.
    '                 - Tabla tblArticulo
    ' Parameters : 
    '              ByVal intArticuloId As Integer
    '                 - 
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '                 - Arreglo bidimensional con los registros leídos
    '                   Array = { (c1,c2..cn), (c1,c2..cn) ... (c1,c2..cn) }
    '                   c = Campo
    '====================================================================
    Public Shared Function strBuscarAntibioticos( _
      ByVal intArticuloId As Integer, _
      ByVal strArticuloDescripcion As String, _
      ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarAntibioticos"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscartblArticuloAntibiotico ")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloDescripcion)
            Call strSQLStatement.Append("'")


            ' Ejecutamos el comando
            strBuscarAntibioticos = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
            strBuscarAntibioticos = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function



    '====================================================================
    ' Name       : intContar
    ' Description: Contar los registros.
    '                 - Tabla tblArticulo
    ' Parameters : 
    '              ByVal intArticuloId As Integer
    '                 - 
    '              ByVal intCategoriaArticuloId As Integer
    '                 - 
    '              ByVal intTipoEntregaArticuloId As Integer
    '                 - 
    '              ByVal intClaveVigenciaArticuloId As Integer
    '                 - 
    '              ByVal intDepartamentoId As Integer
    '                 - 
    '              ByVal intMarcaArticuloId As Integer
    '                 - 
    '              ByVal intTipoArticuloId As Integer
    '                 - 
    '              ByVal strArticuloDescripcion As String
    '                 - 
    '              ByVal blnArticuloCaduca As Byte
    '                 - 
    '              ByVal intArticuloPiezasUnidad As Integer
    '                 - 
    '              ByVal fltArticuloMontoComision As Double
    '                 - 
    '              ByVal blnArticuloConsignado As Byte
    '                 - 
    '              ByVal fltArticuloPrecioOficial As Double
    '                 - 
    '              ByVal blnArticuloImportado As Byte
    '                 - 
    '              ByVal strArticuloSustanciaActiva As String
    '                 - 
    '              ByVal strArticuloContraindicaciones As String
    '                 - 
    '              ByVal strArticuloInstruccionesCaducidad As String
    '                 - 
    '              ByVal fltArticuloPorcentajeCastigo As Double
    '                 - 
    '              ByVal strArticuloPlazoDevolucion As String
    '                 - 
    '              ByVal strArticuloMedioDevolucion As String
    '                 - 
    '              ByVal strArticuloIndicacionesUso As String
    '                 - 
    '              ByVal strArticuloModificadoPor As String
    '                 - 
    '              ByVal dtmArticuloUltimaModificacion As Date
    '                 - 
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros en la tabla
    '====================================================================
    Public Shared Function intContar( _
      ByVal intArticuloId As Integer, _
      ByVal intCategoriaArticuloId As Integer, _
      ByVal intTipoEntregaArticuloId As Integer, _
      ByVal intClaveVigenciaArticuloId As Integer, _
      ByVal intDepartamentoId As Integer, _
      ByVal intMarcaArticuloId As Integer, _
      ByVal intTipoArticuloId As Integer, _
      ByVal strArticuloDescripcion As String, _
      ByVal blnArticuloCaduca As Byte, _
      ByVal intArticuloPiezasUnidad As Integer, _
      ByVal fltArticuloMontoComision As Double, _
      ByVal blnArticuloConsignado As Byte, _
      ByVal fltArticuloPrecioOficial As Double, _
      ByVal blnArticuloImportado As Byte, _
      ByVal strArticuloSustanciaActiva As String, _
      ByVal strArticuloContraindicaciones As String, _
      ByVal strArticuloInstruccionesCaducidad As String, _
      ByVal fltArticuloPorcentajeCastigo As Double, _
      ByVal strArticuloPlazoDevolucion As String, _
      ByVal strArticuloMedioDevolucion As String, _
      ByVal strArticuloIndicacionesUso As String, _
      ByVal strArticuloModificadoPor As String, _
      ByVal dtmArticuloUltimaModificacion As Date, _
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
            Call strSQLStatement.Append("EXECUTE spContartblArticulo ")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCategoriaArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoEntregaArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intClaveVigenciaArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDepartamentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMarcaArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloCaduca)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloPiezasUnidad)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloMontoComision)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloConsignado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloPrecioOficial)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloImportado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloSustanciaActiva)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloContraindicaciones)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloInstruccionesCaducidad)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloPorcentajeCastigo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloPlazoDevolucion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloMedioDevolucion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloIndicacionesUso)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloModificadoPor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
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

    '====================================================================
    ' Name       : intEliminar
    ' Description: Eliminación de registros.
    '                 - Tabla tblArticulo
    ' Parameters : 
    '              ByVal intArticuloId As Integer
    '                 - 
    '              ByVal intCategoriaArticuloId As Integer
    '                 - 
    '              ByVal intTipoEntregaArticuloId As Integer
    '                 - 
    '              ByVal intClaveVigenciaArticuloId As Integer
    '                 - 
    '              ByVal intDepartamentoId As Integer
    '                 - 
    '              ByVal intMarcaArticuloId As Integer
    '                 - 
    '              ByVal intTipoArticuloId As Integer
    '                 - 
    '              ByVal strArticuloDescripcion As String
    '                 - 
    '              ByVal blnArticuloCaduca As Byte
    '                 - 
    '              ByVal intArticuloPiezasUnidad As Integer
    '                 - 
    '              ByVal fltArticuloMontoComision As Double
    '                 - 
    '              ByVal blnArticuloConsignado As Byte
    '                 - 
    '              ByVal fltArticuloPrecioOficial As Double
    '                 - 
    '              ByVal blnArticuloImportado As Byte
    '                 - 
    '              ByVal strArticuloSustanciaActiva As String
    '                 - 
    '              ByVal strArticuloContraindicaciones As String
    '                 - 
    '              ByVal strArticuloInstruccionesCaducidad As String
    '                 - 
    '              ByVal fltArticuloPorcentajeCastigo As Double
    '                 - 
    '              ByVal strArticuloPlazoDevolucion As String
    '                 - 
    '              ByVal strArticuloMedioDevolucion As String
    '                 - 
    '              ByVal strArticuloIndicacionesUso As String
    '                 - 
    '              ByVal strArticuloModificadoPor As String
    '                 - 
    '              ByVal dtmArticuloUltimaModificacion As Date
    '                 - 
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================
    Public Shared Function intEliminar( _
      ByVal intArticuloId As Integer, _
      ByVal intCategoriaArticuloId As Integer, _
      ByVal intTipoEntregaArticuloId As Integer, _
      ByVal intClaveVigenciaArticuloId As Integer, _
      ByVal intDepartamentoId As Integer, _
      ByVal intMarcaArticuloId As Integer, _
      ByVal intTipoArticuloId As Integer, _
      ByVal strArticuloDescripcion As String, _
      ByVal blnArticuloCaduca As Byte, _
      ByVal intArticuloPiezasUnidad As Integer, _
      ByVal fltArticuloMontoComision As Double, _
      ByVal blnArticuloConsignado As Byte, _
      ByVal fltArticuloPrecioOficial As Double, _
      ByVal blnArticuloImportado As Byte, _
      ByVal strArticuloSustanciaActiva As String, _
      ByVal strArticuloContraindicaciones As String, _
      ByVal strArticuloInstruccionesCaducidad As String, _
      ByVal fltArticuloPorcentajeCastigo As Double, _
      ByVal strArticuloPlazoDevolucion As String, _
      ByVal strArticuloMedioDevolucion As String, _
      ByVal strArticuloIndicacionesUso As String, _
      ByVal strArticuloModificadoPor As String, _
      ByVal dtmArticuloUltimaModificacion As Date, _
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
            Call strSQLStatement.Append("EXECUTE spEliminartblArticulo ")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCategoriaArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoEntregaArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intClaveVigenciaArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDepartamentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMarcaArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloCaduca)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloPiezasUnidad)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloMontoComision)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloConsignado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloPrecioOficial)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnArticuloImportado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloSustanciaActiva)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloContraindicaciones)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloInstruccionesCaducidad)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloPorcentajeCastigo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloPlazoDevolucion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloMedioDevolucion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloIndicacionesUso)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloModificadoPor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")

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

            ' Notificamos el error
            Throw

        End Try

    End Function

End Class
