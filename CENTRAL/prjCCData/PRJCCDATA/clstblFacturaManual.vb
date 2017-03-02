Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clstblFacturaManual
' Title         : Facturacion Manual
' Description   : Facturacion Manual
' Copyright     : 2004 Todos los Derechos Reservados.
' Company       : Isocraft S.A. de C.V.
' Author        : Dirección de Tecnología
' Version       : 1.0
' Last Modified : Martes, 09 de Marzo de 2004
'====================================================================
Public NotInheritable Class clstblFacturaManual

    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblFacturaManual"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()
    End Sub

    '====================================================================
    ' Name       : intActualizar
    ' Description: Actualización de registros.
    '                 - Tabla tblFacturaManual
    ' Parameters : 
    '              ByVal intFacturaManualId As Integer
    '                 - 
    '              ByVal intProveedorId As Integer
    '                 - 
    '              ByVal intCompaniaId As Integer
    '                 - 
    '              ByVal intSucursalId As Integer
    '                 - 
    '              ByVal strFacturaManualNumero As String
    '                 - 
    '              ByVal dtmFacturaManualEmisionDocumento As Date
    '                 - 
    '              ByVal dtmFacturaManualRegistro As Date
    '                 - 
    '              ByVal fltFacturaManualImporteNeto As Double
    '                 - 
    '              ByVal fltFacturaManualImporteIVA As Double
    '                 - 
    '              ByVal fltFacturaManualImporteTotal As Double
    '                 - 
    '              ByVal fltFacturaManualImporteDescuentoDespuesIVA As Double
    '                 - 
    '              ByVal fltFacturaManualImporteIVADescuento As Double
    '                 - 
    '              ByVal intFacturaManualFolioContrarecibo As Integer
    '                 - 
    '              ByVal blnFacturaManualEstaConfirmada As Byte
    '                 - 
    '              ByVal blnFacturaManualEsRemision As Byte
    '                 - 
    '              ByVal dtmFacturaManualUltimaModificacion As Date
    '                 - 
    '              ByVal strFacturaManualModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================
    Shared Function intActualizar( _
                ByVal intFacturaManualId As Integer, _
                ByVal intProveedorId As Integer, _
                ByVal intCompaniaId As Integer, _
                ByVal intSucursalId As Integer, _
                ByVal strFacturaManualNumero As String, _
                ByVal dtmFacturaManualEmisionDocumento As Date, _
                ByVal dtmFacturaManualRegistro As Date, _
                ByVal fltFacturaManualImporteNeto As Double, _
                ByVal fltFacturaManualImporteIVA As Double, _
                ByVal fltFacturaManualImporteTotal As Double, _
                ByVal fltFacturaManualImporteDescuentoDespuesIVA As Double, _
                ByVal fltFacturaManualImporteIVADescuento As Double, _
                ByVal intFacturaManualFolioContrarecibo As Integer, _
                ByVal blnFacturaManualEstaConfirmada As Byte, _
                ByVal blnFacturaManualEsRemision As Byte, _
                ByVal dtmFacturaManualUltimaModificacion As Date, _
                ByVal strFacturaManualModificadoPor As String, _
                ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intActualizar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0, strRowsAffected As String(), strRegistros As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spActualizartblFacturaManual ")
            Call strSQLStatement.Append(intFacturaManualId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intProveedorId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(strFacturaManualNumero)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFacturaManualEmisionDocumento.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFacturaManualRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("',")
            Call strSQLStatement.Append(fltFacturaManualImporteNeto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltFacturaManualImporteIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltFacturaManualImporteTotal)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltFacturaManualImporteDescuentoDespuesIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltFacturaManualImporteIVADescuento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intFacturaManualFolioContrarecibo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnFacturaManualEstaConfirmada)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnFacturaManualEsRemision)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(dtmFacturaManualUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strFacturaManualModificadoPor)
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

        End Try

    End Function

    '====================================================================
    ' Name       : intAgregar
    ' Description: Adición de registros.
    '                  - Tabla tblFacturaManual
    ' Parameters : 
    '              ByVal intFacturaManualId As Integer
    '                  - 
    '              ByVal intProveedorId As Integer
    '                  - 
    '              ByVal intCompaniaId As Integer
    '                  - 
    '              ByVal intSucursalId As Integer
    '                  - 
    '              ByVal strFacturaManualNumero As String
    '                  - 
    '              ByVal dtmFacturaManualEmisionDocumento As Date
    '                  - 
    '              ByVal dtmFacturaManualRegistro As Date
    '                 - 
    '              ByVal fltFacturaManualImporteNeto As Double
    '                  - 
    '              ByVal fltFacturaManualImporteIVA As Double
    '                  - 
    '              ByVal fltFacturaManualImporteTotal As Double
    '                  - 
    '              ByVal fltFacturaManualImporteDescuentoDespuesIVA As Double
    '                  - 
    '              ByVal fltFacturaManualImporteIVADescuento As Double
    '                  - 
    '              ByVal intFacturaManualFolioContrarecibo As Integer
    '                  - 
    '              ByVal blnFacturaManualEstaConfirmada As Byte
    '                  - 
    '              ByVal blnFacturaManualEsRemision As Byte
    '                 - 
    '              ByVal dtmFacturaManualUltimaModificacion As Date
    '                  - 
    '              ByVal strFacturaManualModificadoPor As String
    '                  -       
    '              ByVal strConnectionString As String
    '                  - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================        
    Shared Function intAgregar( _
                ByVal intFacturaManualId As Integer, _
                ByVal intProveedorId As Integer, _
                ByVal intCompaniaId As Integer, _
                ByVal intSucursalId As Integer, _
                ByVal strFacturaManualNumero As String, _
                ByVal dtmFacturaManualEmisionDocumento As Date, _
                ByVal dtmFacturaManualRegistro As Date, _
                ByVal fltFacturaManualImporteNeto As Double, _
                ByVal fltFacturaManualImporteIVA As Double, _
                ByVal fltFacturaManualImporteTotal As Double, _
                ByVal fltFacturaManualImporteDescuentoDespuesIVA As Double, _
                ByVal fltFacturaManualImporteIVADescuento As Double, _
                ByVal intFacturaManualFolioContrarecibo As Integer, _
                ByVal blnFacturaManualEstaConfirmada As Byte, _
                ByVal blnFacturaManualEsRemision As Byte, _
                ByVal dtmFacturaManualUltimaModificacion As Date, _
                ByVal strFacturaManualModificadoPor As String, _
                ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intAgregar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0, strRowsAffected As String(), strRegistros As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spAgregartblFacturaManual ")
            Call strSQLStatement.Append(intFacturaManualId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intProveedorId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(strFacturaManualNumero)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFacturaManualEmisionDocumento.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFacturaManualRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("',")
            Call strSQLStatement.Append(fltFacturaManualImporteNeto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltFacturaManualImporteIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltFacturaManualImporteTotal)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltFacturaManualImporteDescuentoDespuesIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltFacturaManualImporteIVADescuento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intFacturaManualFolioContrarecibo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnFacturaManualEstaConfirmada)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnFacturaManualEsRemision)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(dtmFacturaManualUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strFacturaManualModificadoPor)
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

        End Try

    End Function

    '====================================================================
    ' Name       : strBuscar
    ' Description: Búsqueda de registros.
    '                 - Tabla tblFacturaManual
    ' Parameters : 
    '              ByVal intFacturaManualId As Integer
    '                 - 
    '              ByVal intProveedorId As Integer
    '                 - 
    '              ByVal intCompaniaId As Integer
    '                 - 
    '              ByVal intSucursalId As Integer
    '                 - 
    '              ByVal strFacturaManualNumero As String
    '                 - 
    '              ByVal dtmFacturaManualEmisionDocumento As Date
    '                 - 
    '              ByVal dtmFacturaManualRegistro As Date
    '                 - 
    '              ByVal fltFacturaManualImporteNeto As Double
    '                 - 
    '              ByVal fltFacturaManualImporteIVA As Double
    '                 - 
    '              ByVal fltFacturaManualImporteTotal As Double
    '                 - 
    '              ByVal fltFacturaManualImporteDescuentoDespuesIVA As Double
    '                 - 
    '              ByVal fltFacturaManualImporteIVADescuento As Double
    '                 - 
    '              ByVal intFacturaManualFolioContrarecibo As Integer
    '                 - 
    '              ByVal blnFacturaManualEstaConfirmada As Byte
    '                 - 
    '              ByVal blnFacturaManualEsRemision As Byte
    '                 - 
    '              ByVal dtmFacturaManualUltimaModificacion As Date
    '                 - 
    '              ByVal strFacturaManualModificadoPor As String
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
    Shared Function strBuscar( _
            ByVal intFacturaManualId As Integer, _
            ByVal intProveedorId As Integer, _
            ByVal intCompaniaId As Integer, _
            ByVal intSucursalId As Integer, _
            ByVal strFacturaManualNumero As String, _
            ByVal dtmFacturaManualEmisionDocumento As Date, _
            ByVal dtmFacturaManualRegistro As Date, _
            ByVal fltFacturaManualImporteNeto As Double, _
            ByVal fltFacturaManualImporteIVA As Double, _
            ByVal fltFacturaManualImporteTotal As Double, _
            ByVal fltFacturaManualImporteDescuentoDespuesIVA As Double, _
            ByVal fltFacturaManualImporteIVADescuento As Double, _
            ByVal intFacturaManualFolioContrarecibo As Integer, _
            ByVal blnFacturaManualEstaConfirmada As Byte, _
            ByVal blnFacturaManualEsRemision As Byte, _
            ByVal dtmFacturaManualUltimaModificacion As Date, _
            ByVal strFacturaManualModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spBuscartblFacturaManual ")
            Call strSQLStatement.Append(intFacturaManualId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intProveedorId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(strFacturaManualNumero)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFacturaManualEmisionDocumento.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFacturaManualRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("',")
            Call strSQLStatement.Append(fltFacturaManualImporteNeto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltFacturaManualImporteIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltFacturaManualImporteTotal)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltFacturaManualImporteDescuentoDespuesIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltFacturaManualImporteIVADescuento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intFacturaManualFolioContrarecibo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnFacturaManualEstaConfirmada)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnFacturaManualEsRemision)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(dtmFacturaManualUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strFacturaManualModificadoPor)
            Call strSQLStatement.Append("',")
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

        End Try

    End Function

    '====================================================================
    ' Name       : intContar
    ' Description: Contar los registros.
    '                 - Tabla tblFacturaManual
    ' Parameters : 
    '              ByVal intFacturaManualId As Integer
    '                 - 
    '              ByVal intProveedorId As Integer
    '                 - 
    '              ByVal intCompaniaId As Integer
    '                 - 
    '              ByVal intSucursalId As Integer
    '                 - 
    '              ByVal strFacturaManualNumero As String
    '                 - 
    '              ByVal dtmFacturaManualEmisionDocumento As Date
    '                 - 
    '              ByVal dtmFacturaManualRegistro As Date
    '                 - 
    '              ByVal fltFacturaManualImporteNeto As Double
    '                 - 
    '              ByVal fltFacturaManualImporteIVA As Double
    '                 - 
    '              ByVal fltFacturaManualImporteTotal As Double
    '                 - 
    '              ByVal fltFacturaManualImporteDescuentoDespuesIVA As Double
    '                 - 
    '              ByVal fltFacturaManualImporteIVADescuento As Double
    '                 - 
    '              ByVal intFacturaManualFolioContrarecibo As Integer
    '                 - 
    '              ByVal blnFacturaManualEstaConfirmada As Byte
    '                 - 
    '              ByVal blnFacturaManualEsRemision As Byte
    '                 - 
    '              ByVal dtmFacturaManualUltimaModificacion As Date
    '                 - 
    '              ByVal strFacturaManualModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros en la tabla
    '====================================================================
    Shared Function intContar( _
            ByVal intFacturaManualId As Integer, _
            ByVal intProveedorId As Integer, _
            ByVal intCompaniaId As Integer, _
            ByVal intSucursalId As Integer, _
            ByVal strFacturaManualNumero As String, _
            ByVal dtmFacturaManualEmisionDocumento As Date, _
            ByVal dtmFacturaManualRegistro As Date, _
            ByVal fltFacturaManualImporteNeto As Double, _
            ByVal fltFacturaManualImporteIVA As Double, _
            ByVal fltFacturaManualImporteTotal As Double, _
            ByVal fltFacturaManualImporteDescuentoDespuesIVA As Double, _
            ByVal fltFacturaManualImporteIVADescuento As Double, _
            ByVal intFacturaManualFolioContrarecibo As Integer, _
            ByVal blnFacturaManualEstaConfirmada As Byte, _
            ByVal blnFacturaManualEsRemision As Byte, _
            ByVal dtmFacturaManualUltimaModificacion As Date, _
            ByVal strFacturaManualModificadoPor As String, _
            ByVal strConnectionString As String) As Double

        ' Constantes locales
        Const strmThisMemberName As String = "intContar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Double = 0, strRowsAffected As String(), strRegistros As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spContartblFacturaManual ")
            Call strSQLStatement.Append(intFacturaManualId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intProveedorId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(strFacturaManualNumero)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFacturaManualEmisionDocumento.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFacturaManualRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("',")
            Call strSQLStatement.Append(fltFacturaManualImporteNeto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltFacturaManualImporteIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltFacturaManualImporteTotal)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltFacturaManualImporteDescuentoDespuesIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltFacturaManualImporteIVADescuento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intFacturaManualFolioContrarecibo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnFacturaManualEstaConfirmada)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnFacturaManualEsRemision)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(dtmFacturaManualUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strFacturaManualModificadoPor)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            For Each strRowsAffected In strRegistros
                intRowsAffected = CDbl(strRowsAffected.GetValue(0))
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

        End Try

    End Function


    '====================================================================
    ' Name       : intEliminar
    ' Description: Eliminación de registros.
    '                 - Tabla tblFacturaManual
    ' Parameters : 
    '              ByVal intFacturaManualId As Integer
    '                 - 
    '              ByVal intProveedorId As Integer
    '                 - 
    '              ByVal intCompaniaId As Integer
    '                 - 
    '              ByVal intSucursalId As Integer
    '                 - 
    '              ByVal strFacturaManualNumero As String
    '                 - 
    '              ByVal dtmFacturaManualEmisionDocumento As Date
    '                 - 
    '              ByVal dtmFacturaManualRegistro As Date
    '                 - 
    '              ByVal fltFacturaManualImporteNeto As Double
    '                 - 
    '              ByVal fltFacturaManualImporteIVA As Double
    '                 - 
    '              ByVal fltFacturaManualImporteTotal As Double
    '                 - 
    '              ByVal fltFacturaManualImporteDescuentoDespuesIVA As Double
    '                 - 
    '              ByVal fltFacturaManualImporteIVADescuento As Double
    '                 - 
    '              ByVal intFacturaManualFolioContrarecibo As Integer
    '                 - 
    '              ByVal blnFacturaManualEstaConfirmada As Byte
    '                 - 
    '              ByVal blnFacturaManualEsRemision As Byte
    '                 - 
    '              ByVal dtmFacturaManualUltimaModificacion As Date
    '                 - 
    '              ByVal strFacturaManualModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================        
    Shared Function intEliminar( _
            ByVal intFacturaManualId As Integer, _
            ByVal intProveedorId As Integer, _
            ByVal intCompaniaId As Integer, _
            ByVal intSucursalId As Integer, _
            ByVal strFacturaManualNumero As String, _
            ByVal dtmFacturaManualEmisionDocumento As Date, _
            ByVal dtmFacturaManualRegistro As Date, _
            ByVal fltFacturaManualImporteNeto As Double, _
            ByVal fltFacturaManualImporteIVA As Double, _
            ByVal fltFacturaManualImporteTotal As Double, _
            ByVal fltFacturaManualImporteDescuentoDespuesIVA As Double, _
            ByVal fltFacturaManualImporteIVADescuento As Double, _
            ByVal intFacturaManualFolioContrarecibo As Integer, _
            ByVal blnFacturaManualEstaConfirmada As Byte, _
            ByVal blnFacturaManualEsRemision As Byte, _
            ByVal dtmFacturaManualUltimaModificacion As Date, _
            ByVal strFacturaManualModificadoPor As String, _
            ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intEliminar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0, strRowsAffected As String(), strRegistros As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spEliminartblFacturaManual ")
            Call strSQLStatement.Append(intFacturaManualId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intProveedorId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(strFacturaManualNumero)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFacturaManualEmisionDocumento.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmFacturaManualRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("',")
            Call strSQLStatement.Append(fltFacturaManualImporteNeto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltFacturaManualImporteIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltFacturaManualImporteTotal)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltFacturaManualImporteDescuentoDespuesIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltFacturaManualImporteIVADescuento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intFacturaManualFolioContrarecibo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnFacturaManualEstaConfirmada)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnFacturaManualEsRemision)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(dtmFacturaManualUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strFacturaManualModificadoPor)
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

        End Try

    End Function

End Class
