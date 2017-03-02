
Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clstblCupon
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : 2004 Todos los Derechos Reservados.
' Company       : Dirección de Tecnología
' Author        : Isocraft S.A. de C.V.
' Version       : 1.0
' Last Modified : Thursday, November 23, 2005
'====================================================================
Public NotInheritable Class clstblCupon

    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblCupon"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()

    End Sub

    '====================================================================
    ' Name       : intActualizar
    ' Description: Actualización de registros.
    '                 - Tabla tblCupon
    ' Parameters : 
    '              ByVal intCuponId As Double
    '                 - 
    '              ByVal intAlcanceDescuentoId As Double
    '                 - 
    '              ByVal intTipoDescuentoId As Double
    '                 - 
    '              ByVal intTipoCuponId As Double
    '                 - 
    '              ByVal intCuponCodigo As Double
    '                 - 
    '              ByVal intCuponCodigoSAP As Double
    '                 - 
    '              ByVal strCuponCodigoBarra As String
    '                 - 
    '              ByVal strCuponDescripcion As String
    '                 - 
    '              ByVal strCuponPatrocinador As String
    '                 - 
    '              ByVal blnCuponReutilizable As Byte
    '                 - 
    '              ByVal blnCuponAutomatico As Byte
    '                 - 
    '              ByVal blnCuponFranqueable As Byte
    '                 - 
    '              ByVal blnCuponRecolectable As Byte
    '                 - 
    '              ByVal blnCuponImprimible As Byte
    '                 - 
    '              ByVal blnCuponScanner As Byte
    '                 - 
    '              ByVal blnCuponVigenciaContinua As Byte
    '                 - 
    '              ByVal dtmCuponVigenciaFechaInicio As Date
    '                 - 
    '              ByVal dtmCuponVigenciaFechaFin As Date
    '                 - 
    '              ByVal blnCuponConDesglose As Byte
    '                 - 
    '              ByVal blnCuponDescuentoEnPesos As Byte
    '                 - 
    '              ByVal intCuponPiso As Double
    '                 - 
    '              ByVal fltCuponDescuento As Double
    '                 - 
    '              ByVal intCuponCantidadProducto As Double
    '                 - 
    '              ByVal intCuponLleve As Double
    '                 - 
    '              ByVal intCuponPague As Double
    '                 - 
    '              ByVal intCuponFolioInicial As Double
    '                 - 
    '              ByVal intCuponFolioFinal As Double
    '                 - 
    '              ByVal blnCuponDescuentoAdicional As Byte
    '                 - 
    '              ByVal dtmCuponUltimaModificacion As Date
    '                 - 
    '              ByVal strCuponModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================
    Public Shared Function intActualizar(ByVal intCuponId As Double, _
                                         ByVal intAlcanceDescuentoId As Double, _
                                         ByVal intTipoDescuentoId As Double, _
                                         ByVal intTipoCuponId As Double, _
                                         ByVal intCuponCodigo As Double, _
                                         ByVal intCuponCodigoSAP As Double, _
                                         ByVal strCuponCodigoBarra As String, _
                                         ByVal strCuponDescripcion As String, _
                                         ByVal strCuponPatrocinador As String, _
                                         ByVal blnCuponReutilizable As Byte, _
                                         ByVal blnCuponAutomatico As Byte, _
                                         ByVal blnCuponFranqueable As Byte, _
                                         ByVal blnCuponRecolectable As Byte, _
                                         ByVal blnCuponImprimible As Byte, _
                                         ByVal blnCuponScanner As Byte, _
                                         ByVal blnCuponVigenciaContinua As Byte, _
                                         ByVal dtmCuponVigenciaFechaInicio As Date, _
                                         ByVal dtmCuponVigenciaFechaFin As Date, _
                                         ByVal blnCuponConDesglose As Byte, _
                                         ByVal blnCuponDescuentoEnPesos As Byte, _
                                         ByVal intCuponPiso As Double, _
                                         ByVal fltCuponDescuento As Double, _
                                         ByVal intCuponCantidadProducto As Double, _
                                         ByVal intCuponLleve As Double, _
                                         ByVal intCuponPague As Double, _
                                         ByVal intCuponFolioInicial As Double, _
                                         ByVal intCuponFolioFinal As Double, _
                                         ByVal blnCuponDescuentoAdicional As Byte, _
                                         ByVal fltCuponPrecioVenta As Decimal, _
                                         ByVal strCuponImprimibleCodigoBarra As String, _
                                         ByVal strCuponImprimibleDescripcion As String, _
                                         ByVal dtmCuponUltimaModificacion As Date, _
                                         ByVal strCuponModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spActualizartblCupon ")

            Call strSQLStatement.Append(intCuponId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intAlcanceDescuentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoDescuentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoCuponId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponCodigo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponCodigoSAP)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponCodigoBarra)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponPatrocinador)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponReutilizable)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponAutomatico)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponFranqueable)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponRecolectable)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponImprimible)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponScanner)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponVigenciaContinua)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmCuponVigenciaFechaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmCuponVigenciaFechaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponConDesglose)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponDescuentoEnPesos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponPiso)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltCuponDescuento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponCantidadProducto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponLleve)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponPague)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponFolioInicial)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponFolioFinal)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponDescuentoAdicional)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltCuponPrecioVenta)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponImprimibleCodigoBarra)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponImprimibleDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmCuponUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponModificadoPor)
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
    '                  - Tabla tblCupon
    ' Parameters : 
    '              ByVal intCuponId As Double
    '                  - 
    '              ByVal intAlcanceDescuentoId As Double
    '                  - 
    '              ByVal intTipoDescuentoId As Double
    '                  - 
    '              ByVal intTipoCuponId As Double
    '                  - 
    '              ByVal intCuponCodigo As Double
    '                  - 
    '              ByVal intCuponCodigoSAP As Double
    '                  - 
    '              ByVal strCuponCodigoBarra As String
    '                  - 
    '              ByVal strCuponDescripcion As String
    '                  - 
    '              ByVal strCuponPatrocinador As String
    '                  - 
    '              ByVal blnCuponReutilizable As Byte
    '                  - 
    '              ByVal blnCuponAutomatico As Byte
    '                  - 
    '              ByVal blnCuponFranqueable As Byte
    '                  - 
    '              ByVal blnCuponRecolectable As Byte
    '                  - 
    '              ByVal blnCuponImprimible As Byte
    '                  - 
    '              ByVal blnCuponScanner As Byte
    '                  - 
    '              ByVal blnCuponVigenciaContinua As Byte
    '                  - 
    '              ByVal dtmCuponVigenciaFechaInicio As Date
    '                  - 
    '              ByVal dtmCuponVigenciaFechaFin As Date
    '                  - 
    '              ByVal blnCuponConDesglose As Byte
    '                  - 
    '              ByVal blnCuponDescuentoEnPesos As Byte
    '                  - 
    '              ByVal intCuponPiso As Double
    '                  - 
    '              ByVal fltCuponDescuento As Double
    '                  - 
    '              ByVal intCuponCantidadProducto As Double
    '                  - 
    '              ByVal intCuponLleve As Double
    '                  - 
    '              ByVal intCuponPague As Double
    '                  -     
    '              ByVal intCuponFolioInicial As Double
    '                  - 
    '              ByVal intCuponFolioFinal As Double
    '                  - 
    '              ByVal blnCuponDescuentoAdicional As Byte
    '                  - 
    '              ByVal dtmCuponUltimaModificacion As Date
    '                  - 
    '              ByVal strCuponModificadoPor As String
    '                  -       
    '              ByVal strConnectionString As String
    '                  - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================        
    Public Shared Function intAgregar(ByVal intCuponId As Double, _
                                      ByVal intAlcanceDescuentoId As Double, _
                                      ByVal intTipoDescuentoId As Double, _
                                      ByVal intTipoCuponId As Double, _
                                      ByVal intCuponCodigo As Double, _
                                      ByVal intCuponCodigoSAP As Double, _
                                      ByVal strCuponCodigoBarra As String, _
                                      ByVal strCuponDescripcion As String, _
                                      ByVal strCuponPatrocinador As String, _
                                      ByVal blnCuponReutilizable As Byte, _
                                      ByVal blnCuponAutomatico As Byte, _
                                      ByVal blnCuponFranqueable As Byte, _
                                      ByVal blnCuponRecolectable As Byte, _
                                      ByVal blnCuponImprimible As Byte, _
                                      ByVal blnCuponScanner As Byte, _
                                      ByVal blnCuponVigenciaContinua As Byte, _
                                      ByVal dtmCuponVigenciaFechaInicio As Date, _
                                      ByVal dtmCuponVigenciaFechaFin As Date, _
                                      ByVal blnCuponConDesglose As Byte, _
                                      ByVal blnCuponDescuentoEnPesos As Byte, _
                                      ByVal intCuponPiso As Double, _
                                      ByVal fltCuponDescuento As Double, _
                                      ByVal intCuponCantidadProducto As Double, _
                                      ByVal intCuponLleve As Double, _
                                      ByVal intCuponPague As Double, _
                                      ByVal intCuponFolioInicial As Double, _
                                      ByVal intCuponFolioFinal As Double, _
                                      ByVal blnCuponDescuentoAdicional As Byte, _
                                      ByVal fltCuponPrecioVenta As Decimal, _
                                      ByVal strCuponImprimibleCodigoBarra As String, _
                                      ByVal strCuponImprimibleDescripcion As String, _
                                      ByVal dtmCuponUltimaModificacion As Date, _
                                      ByVal strCuponModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spAgregartblCupon ")

            Call strSQLStatement.Append(intCuponId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intAlcanceDescuentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoDescuentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoCuponId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponCodigo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponCodigoSAP)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponCodigoBarra)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponPatrocinador)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponReutilizable)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponAutomatico)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponFranqueable)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponRecolectable)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponImprimible)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponScanner)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponVigenciaContinua)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmCuponVigenciaFechaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmCuponVigenciaFechaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponConDesglose)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponDescuentoEnPesos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponPiso)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltCuponDescuento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponCantidadProducto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponLleve)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponPague)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponFolioInicial)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponFolioFinal)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponDescuentoAdicional)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltCuponPrecioVenta)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponImprimibleCodigoBarra)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponImprimibleDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmCuponUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponModificadoPor)
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
    '                 - Tabla tblCupon
    ' Parameters : 
    '              ByVal intCuponId As Double
    '                 - 
    '              ByVal intAlcanceDescuentoId As Double
    '                 - 
    '              ByVal intTipoDescuentoId As Double
    '                 - 
    '              ByVal intTipoCuponId As Double
    '                 - 
    '              ByVal intCuponCodigo As Double
    '                 - 
    '              ByVal intCuponCodigoSAP As Double
    '                 - 
    '              ByVal strCuponCodigoBarra As String
    '                 - 
    '              ByVal strCuponDescripcion As String
    '                 - 
    '              ByVal strCuponPatrocinador As String
    '                 - 
    '              ByVal blnCuponReutilizable As Byte
    '                 - 
    '              ByVal blnCuponAutomatico As Byte
    '                 - 
    '              ByVal blnCuponFranqueable As Byte
    '                 - 
    '              ByVal blnCuponRecolectable As Byte
    '                 - 
    '              ByVal blnCuponImprimible As Byte
    '                 - 
    '              ByVal blnCuponScanner As Byte
    '                 - 
    '              ByVal blnCuponVigenciaContinua As Byte
    '                 - 
    '              ByVal dtmCuponVigenciaFechaInicio As Date
    '                 - 
    '              ByVal dtmCuponVigenciaFechaFin As Date
    '                 - 
    '              ByVal blnCuponConDesglose As Byte
    '                 - 
    '              ByVal blnCuponDescuentoEnPesos As Byte
    '                 - 
    '              ByVal intCuponPiso As Double
    '                 - 
    '              ByVal fltCuponDescuento As Double
    '                 - 
    '              ByVal intCuponCantidadProducto As Double
    '                 - 
    '              ByVal intCuponLleve As Double
    '                 - 
    '              ByVal intCuponPague As Double
    '                 -     
    '              ByVal intCuponFolioInicial As Double
    '                 - 
    '              ByVal intCuponFolioFinal As Double
    '                 - 
    '              ByVal blnCuponDescuentoAdicional As Byte
    '                 - 
    '              ByVal dtmCuponUltimaModificacion As Date
    '                 - 
    '              ByVal strCuponModificadoPor As String
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
    Public Shared Function strBuscar(ByVal intCuponId As Double, _
                                     ByVal intAlcanceDescuentoId As Double, _
                                     ByVal intTipoDescuentoId As Double, _
                                     ByVal intTipoCuponId As Double, _
                                     ByVal intCuponCodigo As Double, _
                                     ByVal intCuponCodigoSAP As Double, _
                                     ByVal strCuponCodigoBarra As String, _
                                     ByVal strCuponDescripcion As String, _
                                     ByVal strCuponPatrocinador As String, _
                                     ByVal blnCuponReutilizable As Byte, _
                                     ByVal blnCuponAutomatico As Byte, _
                                     ByVal blnCuponFranqueable As Byte, _
                                     ByVal blnCuponRecolectable As Byte, _
                                     ByVal blnCuponImprimible As Byte, _
                                     ByVal blnCuponScanner As Byte, _
                                     ByVal blnCuponVigenciaContinua As Byte, _
                                     ByVal dtmCuponVigenciaFechaInicio As Date, _
                                     ByVal dtmCuponVigenciaFechaFin As Date, _
                                     ByVal blnCuponConDesglose As Byte, _
                                     ByVal blnCuponDescuentoEnPesos As Byte, _
                                     ByVal intCuponPiso As Double, _
                                     ByVal fltCuponDescuento As Double, _
                                     ByVal intCuponCantidadProducto As Double, _
                                     ByVal intCuponLleve As Double, _
                                     ByVal intCuponPague As Double, _
                                     ByVal intCuponFolioInicial As Double, _
                                     ByVal intCuponFolioFinal As Double, _
                                     ByVal blnCuponDescuentoAdicional As Byte, _
                                     ByVal fltCuponPrecioVenta As Decimal, _
                                     ByVal strCuponImprimibleCodigoBarra As String, _
                                     ByVal strCuponImprimibleDescripcion As String, _
                                     ByVal dtmCuponUltimaModificacion As Date, _
                                     ByVal strCuponModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spBuscartblCupon ")

            Call strSQLStatement.Append(intCuponId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intAlcanceDescuentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoDescuentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoCuponId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponCodigo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponCodigoSAP)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponCodigoBarra)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponPatrocinador)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponReutilizable)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponAutomatico)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponFranqueable)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponRecolectable)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponImprimible)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponScanner)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponVigenciaContinua)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmCuponVigenciaFechaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmCuponVigenciaFechaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponConDesglose)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponDescuentoEnPesos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponPiso)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltCuponDescuento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponCantidadProducto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponLleve)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponPague)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponFolioInicial)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponFolioFinal)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponDescuentoAdicional)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltCuponPrecioVenta)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponImprimibleCodigoBarra)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponImprimibleDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmCuponUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponModificadoPor)
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
    ' Name       : intContar
    ' Description: Contar los registros.
    '                 - Tabla tblCupon
    ' Parameters : 
    '              ByVal intCuponId As Double
    '                 - 
    '              ByVal intAlcanceDescuentoId As Double
    '                 - 
    '              ByVal intTipoDescuentoId As Double
    '                 - 
    '              ByVal intTipoCuponId As Double
    '                 - 
    '              ByVal intCuponCodigo As Double
    '                 - 
    '              ByVal intCuponCodigoSAP As Double
    '                 - 
    '              ByVal strCuponCodigoBarra As String
    '                 - 
    '              ByVal strCuponDescripcion As String
    '                 - 
    '              ByVal strCuponPatrocinador As String
    '                 - 
    '              ByVal blnCuponReutilizable As Byte
    '                 - 
    '              ByVal blnCuponAutomatico As Byte
    '                 - 
    '              ByVal blnCuponFranqueable As Byte
    '                 - 
    '              ByVal blnCuponRecolectable As Byte
    '                 - 
    '              ByVal blnCuponImprimible As Byte
    '                 - 
    '              ByVal blnCuponScanner As Byte
    '                 - 
    '              ByVal blnCuponVigenciaContinua As Byte
    '                 - 
    '              ByVal dtmCuponVigenciaFechaInicio As Date
    '                 - 
    '              ByVal dtmCuponVigenciaFechaFin As Date
    '                 - 
    '              ByVal blnCuponConDesglose As Byte
    '                 - 
    '              ByVal blnCuponDescuentoEnPesos As Byte
    '                 - 
    '              ByVal intCuponPiso As Double
    '                 - 
    '              ByVal fltCuponDescuento As Double
    '                 - 
    '              ByVal intCuponCantidadProducto As Double
    '                 - 
    '              ByVal intCuponLleve As Double
    '                 - 
    '              ByVal intCuponPague As Double
    '                 -     
    '              ByVal intCuponFolioInicial As Double
    '                 - 
    '              ByVal intCuponFolioFinal As Double
    '                 - 
    '              ByVal blnCuponDescuentoAdicional As Byte
    '                 - 
    '              ByVal dtmCuponUltimaModificacion As Date
    '                 - 
    '              ByVal strCuponModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros en la tabla
    '====================================================================
    Public Shared Function intContar(ByVal intCuponId As Double, _
                                     ByVal intAlcanceDescuentoId As Double, _
                                     ByVal intTipoDescuentoId As Double, _
                                     ByVal intTipoCuponId As Double, _
                                     ByVal intCuponCodigo As Double, _
                                     ByVal intCuponCodigoSAP As Double, _
                                     ByVal strCuponCodigoBarra As String, _
                                     ByVal strCuponDescripcion As String, _
                                     ByVal strCuponPatrocinador As String, _
                                     ByVal blnCuponReutilizable As Byte, _
                                     ByVal blnCuponAutomatico As Byte, _
                                     ByVal blnCuponFranqueable As Byte, _
                                     ByVal blnCuponRecolectable As Byte, _
                                     ByVal blnCuponImprimible As Byte, _
                                     ByVal blnCuponScanner As Byte, _
                                     ByVal blnCuponVigenciaContinua As Byte, _
                                     ByVal dtmCuponVigenciaFechaInicio As Date, _
                                     ByVal dtmCuponVigenciaFechaFin As Date, _
                                     ByVal blnCuponConDesglose As Byte, _
                                     ByVal blnCuponDescuentoEnPesos As Byte, _
                                     ByVal intCuponPiso As Double, _
                                     ByVal fltCuponDescuento As Double, _
                                     ByVal intCuponCantidadProducto As Double, _
                                     ByVal intCuponLleve As Double, _
                                     ByVal intCuponPague As Double, _
                                     ByVal intCuponFolioInicial As Double, _
                                     ByVal intCuponFolioFinal As Double, _
                                     ByVal blnCuponDescuentoAdicional As Byte, _
                                     ByVal fltCuponPrecioVenta As Decimal, _
                                     ByVal strCuponImprimibleCodigoBarra As String, _
                                     ByVal strCuponImprimibleDescripcion As String, _
                                     ByVal dtmCuponUltimaModificacion As Date, _
                                     ByVal strCuponModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spContartblCupon ")

            Call strSQLStatement.Append(intCuponId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intAlcanceDescuentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoDescuentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoCuponId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponCodigo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponCodigoSAP)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponCodigoBarra)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponPatrocinador)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponReutilizable)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponAutomatico)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponFranqueable)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponRecolectable)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponImprimible)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponScanner)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponVigenciaContinua)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmCuponVigenciaFechaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmCuponVigenciaFechaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponConDesglose)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponDescuentoEnPesos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponPiso)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltCuponDescuento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponCantidadProducto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponLleve)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponPague)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponFolioInicial)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponFolioFinal)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponDescuentoAdicional)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltCuponPrecioVenta)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponImprimibleCodigoBarra)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponImprimibleDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmCuponUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponModificadoPor)
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

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : intEliminar
    ' Description: Eliminación de registros.
    '                 - Tabla tblCupon
    ' Parameters : 
    '              ByVal intCuponId As Double
    '                 - 
    '              ByVal intAlcanceDescuentoId As Double
    '                 - 
    '              ByVal intTipoDescuentoId As Double
    '                 - 
    '              ByVal intTipoCuponId As Double
    '                 - 
    '              ByVal intCuponCodigo As Double
    '                 - 
    '              ByVal intCuponCodigoSAP As Double
    '                 - 
    '              ByVal strCuponCodigoBarra As String
    '                 - 
    '              ByVal strCuponDescripcion As String
    '                 - 
    '              ByVal strCuponPatrocinador As String
    '                 - 
    '              ByVal blnCuponReutilizable As Byte
    '                 - 
    '              ByVal blnCuponAutomatico As Byte
    '                 - 
    '              ByVal blnCuponFranqueable As Byte
    '                 - 
    '              ByVal blnCuponRecolectable As Byte
    '                 - 
    '              ByVal blnCuponImprimible As Byte
    '                 - 
    '              ByVal blnCuponScanner As Byte
    '                 - 
    '              ByVal blnCuponVigenciaContinua As Byte
    '                 - 
    '              ByVal dtmCuponVigenciaFechaInicio As Date
    '                 - 
    '              ByVal dtmCuponVigenciaFechaFin As Date
    '                 - 
    '              ByVal blnCuponConDesglose As Byte
    '                 - 
    '              ByVal blnCuponDescuentoEnPesos As Byte
    '                 - 
    '              ByVal intCuponPiso As Double
    '                 - 
    '              ByVal fltCuponDescuento As Double
    '                 - 
    '              ByVal intCuponCantidadProducto As Double
    '                 - 
    '              ByVal intCuponLleve As Double
    '                 - 
    '              ByVal intCuponPague As Double
    '                 -     
    '              ByVal intCuponFolioInicial As Double
    '                 - 
    '              ByVal intCuponFolioFinal As Double
    '                 - 
    '              ByVal blnCuponDescuentoAdicional As Byte
    '                 - 
    '              ByVal dtmCuponUltimaModificacion As Date
    '                 - 
    '              ByVal strCuponModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================        
    Public Shared Function intEliminar(ByVal intCuponId As Double, _
                                       ByVal intAlcanceDescuentoId As Double, _
                                       ByVal intTipoDescuentoId As Double, _
                                       ByVal intTipoCuponId As Double, _
                                       ByVal intCuponCodigo As Double, _
                                       ByVal intCuponCodigoSAP As Double, _
                                       ByVal strCuponCodigoBarra As String, _
                                       ByVal strCuponDescripcion As String, _
                                       ByVal strCuponPatrocinador As String, _
                                       ByVal blnCuponReutilizable As Byte, _
                                       ByVal blnCuponAutomatico As Byte, _
                                       ByVal blnCuponFranqueable As Byte, _
                                       ByVal blnCuponRecolectable As Byte, _
                                       ByVal blnCuponImprimible As Byte, _
                                       ByVal blnCuponScanner As Byte, _
                                       ByVal blnCuponVigenciaContinua As Byte, _
                                       ByVal dtmCuponVigenciaFechaInicio As Date, _
                                       ByVal dtmCuponVigenciaFechaFin As Date, _
                                       ByVal blnCuponConDesglose As Byte, _
                                       ByVal blnCuponDescuentoEnPesos As Byte, _
                                       ByVal intCuponPiso As Double, _
                                       ByVal fltCuponDescuento As Double, _
                                       ByVal intCuponCantidadProducto As Double, _
                                       ByVal intCuponLleve As Double, _
                                       ByVal intCuponPague As Double, _
                                       ByVal intCuponFolioInicial As Double, _
                                       ByVal intCuponFolioFinal As Double, _
                                       ByVal blnCuponDescuentoAdicional As Byte, _
                                       ByVal fltCuponPrecioVenta As Decimal, _
                                       ByVal strCuponImprimibleCodigoBarra As String, _
                                       ByVal strCuponImprimibleDescripcion As String, _
                                       ByVal dtmCuponUltimaModificacion As Date, _
                                       ByVal strCuponModificadoPor As String, _
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
            Call strSQLStatement.Append("EXECUTE spEliminartblCupon ")

            Call strSQLStatement.Append(intCuponId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intAlcanceDescuentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoDescuentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoCuponId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponCodigo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponCodigoSAP)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponCodigoBarra)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponPatrocinador)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponReutilizable)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponAutomatico)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponFranqueable)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponRecolectable)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponImprimible)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponScanner)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponVigenciaContinua)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmCuponVigenciaFechaInicio.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmCuponVigenciaFechaFin.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponConDesglose)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponDescuentoEnPesos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponPiso)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltCuponDescuento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponCantidadProducto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponLleve)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponPague)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponFolioInicial)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCuponFolioFinal)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(blnCuponDescuentoAdicional)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltCuponPrecioVenta)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponImprimibleCodigoBarra)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponImprimibleDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmCuponUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strCuponModificadoPor)
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

    '====================================================================
    ' Name       : strBuscar
    ' Description: Búsqueda de registros modificados y que
    '              necesitan ser reenviados.
    '                 - Tabla: tblCupon
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
            Call strSQLStatement.Append("EXECUTE spBuscarCambiotblCupon ")
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
    '                 - Tabla: tblCupon
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
    Public Shared Function strBuscar(ByVal intSolicitudActualizacionId As Integer, _
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
            Call strSQLStatement.Append("EXECUTE spReenvioCambiotblCupon ")
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

End Class
