
Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clstblTipoServicioVirtual
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : 2009 Todos los Derechos Reservados.
' Company       : SOFTTEK
' Author        : C�sar Ortiz (OCOT)
' Version       : 1.0
' Last Modified : Jueves, Julio 11, 2013 - Softtek - CJBG
'====================================================================

Public Class clstblServicioVirtual

    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblServicioVirtual"

    ' Constructor en blanco para prevenir la generaci�n de un constructor por defecto
    Private Sub New()
    End Sub

    '====================================================================
    ' Name       : strBuscar
    ' Description: Busca los tipos de servicios virtuales
    '                 - Tabla tblTipoServicioVirtual
    ' Parameters :
    '              ByVal intServicioVirtualId As Integer
    '                 - Identificador del tipo de servicio
    '              ByVal strConnectionString As String
    '                 - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '                 - Arreglo bidimensional con los registros le�dos
    '                   Array = { (c1,c2), (c1,c2) ... (c1,c2) }
    '                   c = Campo
    '====================================================================
    Public Shared Function strBuscar( _
      ByVal intTipoServicioVirtualId As Integer, _
      ByVal intServicioVirtualId As Integer, _
      ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarServicioVirtual ")
            Call strSQLStatement.Append(intTipoServicioVirtualId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualId)

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
    ' Name       : intEliminar
    ' Description: Elimina un servicio virtual y sus hijos. Realiza una copia en el historico
    '                 - Tabla tblServicioVirtual
    '                 -       tblServicioVirtualDatoAdicional
    '                 -       tblServicioVirtualHistorico
    ' Parameters :
    '              ByVal intTipoServicioVirtualId As Integer
    '                 - Identificador del tipo de servicio
    '              ByVal strConnectionString As String
    '                 - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - N�mero de registros afectados por el comando
    '====================================================================
    Public Shared Function intEliminar( _
      ByVal intServicioVirtualId As Integer, _
      ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intEliminar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0
        Dim strRegistros As Array = Nothing
        Dim strRowsAffected As String() = Nothing

        Try
            ' Inicializamos las variabes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spEliminarServicioVirtual ")
            Call strSQLStatement.Append(intServicioVirtualId)

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

    '====================================================================
    ' Name       : intBuscarCodigoProducto
    ' Description: Busca un codigo de producto en especifico
    '                 - Tabla tblServicioVirtual
    ' Parameters :
    '              ByVal intServicioVirtualId As Integer
    '                 - Identificador del Dato adicional
    '              ByVal strConnectionString As String
    '                 - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - N�mero de registros afectados por el comando
    '====================================================================
    Public Shared Function strBuscarCodigosProductos(ByVal intServicioVirtualId As Integer, _
                                                     ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarCodigosProductos"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing



        Try
            ' Inicializamos las variabes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarCodigosProductos ")
            Call strSQLStatement.Append(intServicioVirtualId)

            ' Ejecutamos el comando
            strBuscarCodigosProductos = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
            strBuscarCodigosProductos = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : intGuardar
    ' Description: Guarda un tipo de servicio virtual
    '                 - Tabla tblTipoServicioVirtual
    ' Parameters :
    '              ByVal intTipoServicioVirtualId As Integer
    '                 - Identificador del tipo de servicio
    '              ByVal strConnectionString As String
    '                 - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - N�mero de registros afectados por el comando
    '====================================================================
    'STKCPOS 26/06/2012 CJBG - Agregando intIntegradorServicioVirtualId
    'STKIUSACFE 11/07/2013 CJBG - Agregando fltServicioVirtualComisionIntegrador
    Public Shared Function intGuardar( _
      ByVal intTipoServicioId As Integer, _
      ByVal intServicioVirtualId As Integer, _
      ByVal strServicioVirtualCodigoProducto As String, _
      ByVal strServicioVirtualDescripcion As String, _
      ByVal intTipoMovimientoServiciovirtualId As Integer, _
      ByVal blnServicioVirtualValidarSupervisor As Boolean, _
      ByVal intTipoTicketId As Integer, _
      ByVal intIntegradorServicioVirtualId As Integer, _
      ByVal intArticuloId As Integer, _
      ByVal intServicioVirtualTransaccionCTFId As Integer, _
      ByVal intServicioVirtualTransaccionCTFCampoCompuestoId As Integer, _
      ByVal intServicioVirtualTransaccionCTFCampoCompuestoLongitud As Integer, _
      ByVal fltServicioVirtualComision As Double, _
      ByVal intServicioVirtualTransaccionCTFComisionId As Integer, _
      ByVal intServicioVirtualTransaccionCTFComisionFPSinImpuestoId As Integer, _
      ByVal intServicioVirtualTransaccionCTFComisionFPImpuestoInteriorId As Integer, _
      ByVal intServicioVirtualTransaccionCTFComisionFPImpuestoFronteraId As Integer, _
      ByVal fltServicioVirtualComisionIntegrador As Double, _
      ByVal intServicioVirtualTransaccionCTFComisionIntegradorId As Integer, _
      ByVal intServicioVirtualTransaccionCTFComisionIntegradorFPSinImpuestoId As Integer, _
      ByVal intServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoInteriorId As Integer, _
      ByVal intServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoFronteraId As Integer, _
      ByVal blnServicioVirtualSeparaComisionIntegrador As Boolean, _
      ByVal blnServicioVirtualDesgloseImpuesto As Boolean, _
      ByVal intServicioVirtualClaveImpresion As Integer, _
      ByVal blnServicioVirtualReImpresion As Boolean, _
      ByVal strServicioVirtualCampoReferencia As String, _
      ByVal strServicioVirtualCampoAutorizacion As String, _
      ByVal strServicioVirtualCampoImporte As String, _
      ByVal strServicioVirtualCampoMonto As String, _
      ByVal strServicioVirtualCampoCantidad As String, _
      ByVal strServicioVirtualCamposNoAlmacenados As String, _
      ByVal blnServicioVirtualReversa As Boolean, _
      ByVal blnServicioVirtualImprimirTicketCancelacion As Boolean, _
      ByVal intServicioVirtualClaveImpresionCancelacion As Integer, _
      ByVal blnServicioVirtualConfirmarOperacionExitosa As Boolean, _
      ByVal strServicioVirtualLeyendaOperacionExitosa As String, _
      ByVal fltServicioVirtualMontoMaximo As Double, _
      ByVal strUsuarioNombre As String, _
      ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intGuardar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0
        Dim strRegistros As Array = Nothing
        Dim strRowsAffected As String() = Nothing

        Try
            ' Inicializamos las variabes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spGuardarServicioVirtual ")
            Call strSQLStatement.Append(intTipoServicioId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strServicioVirtualCodigoProducto)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strServicioVirtualDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoMovimientoServiciovirtualId)
            Call strSQLStatement.Append(",")
            If blnServicioVirtualValidarSupervisor Then
                Call strSQLStatement.Append("1")
            Else
                Call strSQLStatement.Append("0")
            End If
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intIntegradorServicioVirtualId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualTransaccionCTFId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualTransaccionCTFCampoCompuestoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualTransaccionCTFCampoCompuestoLongitud)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltServicioVirtualComision)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualTransaccionCTFComisionId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualTransaccionCTFComisionFPSinImpuestoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualTransaccionCTFComisionFPImpuestoInteriorId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualTransaccionCTFComisionFPImpuestoFronteraId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltServicioVirtualComisionIntegrador)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualTransaccionCTFComisionIntegradorId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualTransaccionCTFComisionIntegradorFPSinImpuestoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoInteriorId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoFronteraId)
            Call strSQLStatement.Append(",")
            If blnServicioVirtualSeparaComisionIntegrador Then
                Call strSQLStatement.Append("1")
            Else
                Call strSQLStatement.Append("0")
            End If
            Call strSQLStatement.Append(",")
            If blnServicioVirtualDesgloseImpuesto Then
                Call strSQLStatement.Append("1")
            Else
                Call strSQLStatement.Append("0")
            End If
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualClaveImpresion)
            Call strSQLStatement.Append(",")
            If blnServicioVirtualReImpresion Then
                Call strSQLStatement.Append("1")
            Else
                Call strSQLStatement.Append("0")
            End If
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strServicioVirtualCampoReferencia)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strServicioVirtualCampoAutorizacion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strServicioVirtualCampoImporte)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strServicioVirtualCampoMonto)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strServicioVirtualCampoCantidad)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strServicioVirtualCamposNoAlmacenados)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            If blnServicioVirtualReversa Then
                Call strSQLStatement.Append("1")
            Else
                Call strSQLStatement.Append("0")
            End If
            Call strSQLStatement.Append(",")
            If blnServicioVirtualImprimirTicketCancelacion Then
                Call strSQLStatement.Append("1")
            Else
                Call strSQLStatement.Append("0")
            End If
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualClaveImpresionCancelacion)
            Call strSQLStatement.Append(",")
            If blnServicioVirtualConfirmarOperacionExitosa Then
                Call strSQLStatement.Append("1")
            Else
                Call strSQLStatement.Append("0")
            End If
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strServicioVirtualLeyendaOperacionExitosa)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltServicioVirtualMontoMaximo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strUsuarioNombre)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            For Each strRowsAffected In strRegistros
                intRowsAffected = CInt(strRowsAffected.GetValue(0))
            Next

            ' Regresamos la informaci�n
            strSQLStatement = Nothing
            intGuardar = intRowsAffected

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
            intGuardar = 0

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strBuscarTipoTicket
    ' Description: Busca los tipos de ticket para servicios virtuales
    '                 - Tabla tblTipoTicket
    ' Parameters :
    '              ByVal strConnectionString As String
    '                 - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '                 - Arreglo bidimensional con los registros le�dos
    '                   Array = { (c1,c2), (c1,c2) ... (c1,c2) }
    '                   c = Campo
    '====================================================================
    Public Shared Function strBuscarTipoTicket(ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarTipoTicket"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarTipoTicketServicioVirtual ")

            ' Ejecutamos el comando
            strBuscarTipoTicket = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
            strBuscarTipoTicket = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strBuscarTipoMovimiento
    ' Description: Busca los tipos de ticket para servicios virtuales
    '                 - Tabla tblTipoMovimientoServicioVirtual
    ' Parameters :
    '              ByVal strConnectionString As String
    '                 - Cadena de conexi�n hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '                 - Arreglo bidimensional con los registros le�dos
    '                   Array = { (c1,c2), (c1,c2) ... (c1,c2) }
    '                   c = Campo
    '====================================================================
    Public Shared Function strBuscarTipoMovimiento(ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarTipoMovimiento"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarTipoMovimientoServicioVirtual ")

            ' Ejecutamos el comando
            strBuscarTipoMovimiento = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
            strBuscarTipoMovimiento = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

End Class
