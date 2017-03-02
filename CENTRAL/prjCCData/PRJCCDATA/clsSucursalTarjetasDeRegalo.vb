Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clsSucursalTarjetasDeRegalo
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : 2013 Junio 10
' Company       : Softtek 
' Author        : Dirección de Tecnología
' Version       : 1.0
' Last Modified : Lunes, Junio 10, 2013 JPMB
'====================================================================
Public Class clsSucursalTarjetasDeRegalo
    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clsSucursalTarjetasDeRegalo"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()
    End Sub

    '====================================================================
    ' Name       : intGuardarDatoAdicionalTarjetaRegalo
    ' Description: Guarda un Configuraciones De Tarjeta de Regalo.
    '                 - Tabla tblDatosAdicionalesTarjetaRegalo
    ' Parameters :
    '               -ByVal blnmServicioVirtualFacturaVenta As Boolean
    '               -ByVal blnmServicioVirtualFacturaAplicaComision As Boolean
    '               -ByVal blnmServicioVirtualTarjetaActiva As Boolean
    '               -ByVal strmServicioVirtualTextoTicket As String
    '               -ByVal strConnectionString As String
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================
    'STKCPOS 29/05/2013 JPMB - Agregando Configuraciones Tarjetas De Regalo

    Public Shared Function intGuardarDatoAdicionalTarjetaRegalo( _
    ByVal intServicioVirtualId As Integer, _
    ByVal strServicioVirtualCodigoProducto As String, _
      ByVal blnmServicioVirtualFacturaVenta As Boolean, _
      ByVal blnmServicioVirtualFacturaAplicaComision As Boolean, _
      ByVal blnmServicioVirtualTarjetaActiva As Boolean, _
      ByVal strmServicioVirtualTextoTicket As String, _
      ByVal strUsuarioNombre As String, _
      ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intGuardarDatoAdicionalTarjetaRegalo"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0
        Dim strRegistros As Array = Nothing
        Dim strRowsAffected As String() = Nothing

        Try
            ' Inicializamos las variabes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spGuardarDatoAdicionalTarjetaRegalo ")
            Call strSQLStatement.Append(intServicioVirtualId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strServicioVirtualCodigoProducto)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            'Validamos el Valor que Trae el Campo 1,0
            If blnmServicioVirtualFacturaVenta Then
                Call strSQLStatement.Append("1")
            Else
                Call strSQLStatement.Append("0")
            End If
            'Validamos el Valor que Trae el Campo 1,0
            Call strSQLStatement.Append(",")
            If blnmServicioVirtualFacturaAplicaComision Then
                Call strSQLStatement.Append("1")
            Else
                Call strSQLStatement.Append("0")
            End If
            'Validamos el Valor que Trae el Campo 1,0
            Call strSQLStatement.Append(",")
            If blnmServicioVirtualTarjetaActiva Then
                Call strSQLStatement.Append("1")
            Else
                Call strSQLStatement.Append("0")
            End If
            'Agregamos el contenido Del ticket Descripcion 
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strmServicioVirtualTextoTicket)
            Call strSQLStatement.Append("'")
            'Se Agrega el parameto del nombre del Usuario
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strUsuarioNombre)
            Call strSQLStatement.Append("'")


            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            For Each strRowsAffected In strRegistros
                intRowsAffected = CInt(strRowsAffected.GetValue(0))
            Next

            ' Regresamos la información
            strSQLStatement = Nothing
            intGuardarDatoAdicionalTarjetaRegalo = intRowsAffected

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
            intGuardarDatoAdicionalTarjetaRegalo = 0

            ' Notificamos el error
            Throw

        End Try
    End Function
    '====================================================================
    ' Name       : strBuscarDatoAdicionalTarjetaRegalo
    ' Description: Busca un Configuraciones De Tarjeta de Regalo.
    '                 - Tabla tblDatosAdicionalesTarjetaRegalo
    ' Parameters :
    '               -ByVal intServicioVirtualId As Integer
    '               -ByVal strConnectionString As String
    ' Throws     : Exception
    ' Output     : Array
    '                  - Número de registros afectados por el comando
    '====================================================================
    'STKCPOS 03/06/2013 JPMB - Agregando Configuraciones Tarjetas De Regalo

    Public Shared Function strBuscarDatoAdicionalTarjetaRegalo( _
    ByVal intServicioVirtualId As String, _
      ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarDatoAdicionalTarjetaRegalo"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarDatoAdicionalTarjetaRegalo ")
            Call strSQLStatement.Append(intServicioVirtualId)


            ' Ejecutamos el comando
            strBuscarDatoAdicionalTarjetaRegalo = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
            strBuscarDatoAdicionalTarjetaRegalo = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strBuscarFormaDePago
    ' Description: Búsqueda de registros.
    '                 - Tabla intServicioVirtualId
    ' Parameters : 
    '              ByVal intIntegradorServicioVirtualId As Double
    '                 - 
    ' Throws     : Exception
    ' Output     : Array
    '                 - Arreglo bidimensional con los registros leídos
    '                   Array = { (c1,c2..cn), (c1,c2..cn) ... (c1,c2..cn) }
    '                   c = Campo JPMB
    '====================================================================
    Public Shared Function strBuscarFormaDePago( _
            ByVal intServicioVirtualId As Integer, _
            ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarFormaDePago"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarFormaDePago ")
            Call strSQLStatement.Append(intServicioVirtualId)


            ' Ejecutamos el comando
            strBuscarFormaDePago = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
            strBuscarFormaDePago = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : intGuardarserviciovirtualFormaPago
    ' Description: Guarda un Configuraciones De Tarjeta de Regalo.
    '                 - Tabla tblDatosAdicionalesTarjetaRegalo
    ' Parameters :
    '               -ByVal blnmServicioVirtualFacturaVenta As Boolean
    '               -ByVal blnmServicioVirtualFacturaAplicaComision As Boolean
    '               -ByVal blnmServicioVirtualTarjetaActiva As Boolean
    '               -ByVal strmServicioVirtualTextoTicket As String
    '               -ByVal strConnectionString As String
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================
    'STKCPOS 05/06/2013 JPMB - Agregando Configuraciones Tarjetas De Regalo Forma De Pago

    Public Shared Function intGuardarserviciovirtualFormaPago( _
    ByVal intServicioVirtualId As Integer, _
    ByVal intFormaDePagoId As String, _
    ByVal strUsuarioNombre As String, _
    ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intGuardarserviciovirtualFormaPago"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0
        Dim strRegistros As Array = Nothing
        Dim strRowsAffected As String() = Nothing

        Try
            ' Inicializamos las variabes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spGuardarserviciovirtualFormaPago ")
            Call strSQLStatement.Append(intServicioVirtualId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intFormaDePagoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strUsuarioNombre)
            Call strSQLStatement.Append("'")


            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            For Each strRowsAffected In strRegistros
                intRowsAffected = CInt(strRowsAffected.GetValue(0))
            Next

            ' Regresamos la información
            strSQLStatement = Nothing
            intGuardarserviciovirtualFormaPago = intRowsAffected

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
            intGuardarserviciovirtualFormaPago = 0

            ' Notificamos el error
            Throw

        End Try
    End Function
    '====================================================================
    ' Name       : strBuscarFormaDePago Para le HTML
    ' Description: Búsqueda de registros.
    '                 - Tabla intServicioVirtualId
    ' Parameters : 
    '              ByVal intIntegradorServicioVirtualId As Double
    '                 - 
    ' Throws     : Exception
    ' Output     : Array
    '                 - Arreglo bidimensional con los registros leídos
    '                   Array = { (c1,c2..cn), (c1,c2..cn) ... (c1,c2..cn) }
    '                   c = Campo JPMB 10 Junio 2013
    '====================================================================
    Public Shared Function strBuscarserviciovirtualFormaPagoHTML( _
            ByVal intServicioVirtualId As Integer, _
            ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarserviciovirtualFormaPagoHTML"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarserviciovirtualFormaPagoHTML ")
            Call strSQLStatement.Append(intServicioVirtualId)


            ' Ejecutamos el comando
            strBuscarserviciovirtualFormaPagoHTML = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
            strBuscarserviciovirtualFormaPagoHTML = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : intEliminarserviciovirtualFormaPago 
    ' Description: Búsqueda de registros.
    '                 - Tabla intServicioVirtualId
    ' Parameters : 
    '              ByVal intIntegradorServicioVirtualId As Double
    '                 - 
    ' Throws     : Exception
    ' Output     : Array
    '                 - Arreglo bidimensional con los registros leídos
    '                   Array = { (c1,c2..cn), (c1,c2..cn) ... (c1,c2..cn) }
    '                   c = Campo
    'JPMB 10 Junio 2013
    '====================================================================

    Public Shared Function intEliminarserviciovirtualFormaPago(ByVal intServicioVirtualId As Integer, _
                                                  ByVal intFormaDePagoId As Integer, _
                                                  ByVal strConnectionString As String) As Integer


        ' Constantes locales
        Const strmThisMemberName As String = "intEliminarserviciovirtualFormaPago"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0
        Dim strRegistros As Array = Nothing
        Dim strRowsAffected As String() = Nothing

        Try
            ' Inicializamos las variabes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spEliminarserviciovirtualFormaPago ")
            Call strSQLStatement.Append(intServicioVirtualId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intFormaDePagoId)


            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            For Each strRowsAffected In strRegistros
                intRowsAffected = CInt(strRowsAffected.GetValue(0))
            Next

            ' Regresamos la información
            strSQLStatement = Nothing
            intEliminarserviciovirtualFormaPago = intRowsAffected

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
            intEliminarserviciovirtualFormaPago = 0

            ' Notificamos el error
            Throw

        End Try

    End Function
End Class
