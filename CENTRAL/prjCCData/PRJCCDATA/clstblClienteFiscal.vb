Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clstblClienteFiscal
' Title         : Facturacion
' Description   : Facturacion
' Copyright     : 2004 Todos los Derechos Reservados.
' Company       : Isocraft S.A. de C.V.
' Author        : Dirección de Tecnología
' Version       : 1.0
' Last Modified : Martes, 02 de Marzo de 2004
'====================================================================
'Modificado por: Neitek Solutions -Enrique Longoria 
'Fecha de Modificacion: 09/May/2006
'====================================================================
Public NotInheritable Class clstblClienteFiscal

    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblClienteFiscal"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()
    End Sub

    '====================================================================
    ' Name       : intActualizar
    ' Description: Actualización de registros.
    '                 - Tabla tblClienteFiscal
    ' Parameters : 
    '              ByVal intClienteFiscalId As Integer
    '                 - 
    '              ByVal strClienteFiscalRFC As String
    '                 - 
    '              ByVal strClienteFiscalRazonSocial As String
    '                 - 
    '              ByVal strClienteFiscalDireccion As String
    '                 - 
    '              ByVal strClienteFiscalColonia As String
    '                 - 
    '              ByVal strClienteFiscalCodigoPostal As String
    '                 - 
    '              ByVal strClienteFiscalTelefono As String
    '                 - 
    '              ByVal strCiudad As String
    '                 -
    '              ByVal strEstado As String
    '                 -
    '              ByVal strClienteFiscalCalle As String
    '                 -
    '              ByVal strClienteFiscalNoExterior As String
    '                 -
    '              ByVal strClienteFiscalNoInterior As String
    '                 -
    '              ByVal strClienteFiscalEMail As String
    '                 -
    '              ByVal dtmClienteFiscalUltimaModificacion As Date
    '                 - 
    '              ByVal strClienteFiscalModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================
    Shared Function intActualizar( _
                ByVal intClienteFiscalId As Integer, _
                ByVal strClienteFiscalRFC As String, _
                ByVal strClienteFiscalRazonSocial As String, _
                ByVal strClienteFiscalCalle As String, _
                ByVal strClienteFiscalNoExterior As String, _
                ByVal strClienteFiscalNoInterior As String, _
                ByVal strClienteFiscalColonia As String, _
                ByVal strClienteFiscalCodigoPostal As String, _
                ByVal strClienteFiscalTelefono As String, _
                ByVal strClienteFiscalEMail As String, _
                ByVal strCiudad As String, _
                ByVal strEstado As String, _
                ByVal dtmClienteFiscalUltimaModificacion As Date, _
                ByVal strClienteFiscalModificadoPor As String, _
                ByVal strClienteFiscalDireccion As String, _
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
            Call strSQLStatement.Append("EXECUTE spActualizartblClienteFiscal ")
            Call strSQLStatement.Append(intClienteFiscalId)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(strClienteFiscalRFC)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalRazonSocial)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalCalle)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalNoExterior)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalNoInterior)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalColonia)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalCodigoPostal)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalTelefono)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalEMail)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strCiudad)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strEstado)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmClienteFiscalUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalModificadoPor)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalDireccion)
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
    '                  - Tabla tblClienteFiscal
    ' Parameters : 
    '              ByVal intClienteFiscalId As Integer
    '                  - 
    '              ByVal strClienteFiscalRFC As String
    '                  - 
    '              ByVal strClienteFiscalRazonSocial As String
    '                  - 
    '              ByVal strClienteFiscalDireccion As String
    '                  - 
    '              ByVal strClienteFiscalColonia As String
    '                  - 
    '              ByVal strClienteFiscalCodigoPostal As String
    '                  - 
    '              ByVal strClienteFiscalTelefono As String
    '                  - 
    '              ByVal strCiudad As String
    '                 -
    '              ByVal strEstado As String
    '                 -
    '              ByVal strClienteFiscalCalle As String
    '                 -
    '              ByVal strClienteFiscalNoExterior As String
    '                 -
    '              ByVal strClienteFiscalNoInterior As String
    '                 -
    '              ByVal strClienteFiscalEMail As String
    '                 -
    '              ByVal dtmClienteFiscalUltimaModificacion As Date
    '                  - 
    '              ByVal strClienteFiscalModificadoPor As String
    '                  -       
    '              ByVal strConnectionString As String
    '                  - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================        
    Shared Function intAgregar( _
                ByVal intClienteFiscalId As Integer, _
                ByVal strClienteFiscalRFC As String, _
                ByVal strClienteFiscalRazonSocial As String, _
                ByVal strClienteFiscalCalle As String, _
                ByVal strClienteFiscalNoExterior As String, _
                ByVal strClienteFiscalNoInterior As String, _
                ByVal strClienteFiscalColonia As String, _
                ByVal strClienteFiscalCodigoPostal As String, _
                ByVal strClienteFiscalTelefono As String, _
                ByVal strClienteFiscalEMail As String, _
                ByVal strCiudad As String, _
                ByVal strEstado As String, _
                ByVal dtmClienteFiscalUltimaModificacion As Date, _
                ByVal strClienteFiscalModificadoPor As String, _
                ByVal strClienteFiscalDireccion As String, _
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
            Call strSQLStatement.Append("EXECUTE spAgregartblClienteFiscal ")
            Call strSQLStatement.Append(intClienteFiscalId)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(strClienteFiscalRFC)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalRazonSocial)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalCalle)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalNoExterior)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalNoInterior)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalColonia)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalCodigoPostal)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalTelefono)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalEMail)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strCiudad)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strEstado)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmClienteFiscalUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalModificadoPor)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalDireccion)
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
    '                 - Tabla tblClienteFiscal
    ' Parameters : 
    '              ByVal intClienteFiscalId As Integer
    '                 - 
    '              ByVal strClienteFiscalRFC As String
    '                 - 
    '              ByVal strClienteFiscalRazonSocial As String
    '                 - 
    '              ByVal strClienteFiscalDireccion As String
    '                 - 
    '              ByVal strClienteFiscalColonia As String
    '                 - 
    '              ByVal strClienteFiscalCodigoPostal As String
    '                 - 
    '              ByVal strClienteFiscalTelefono As String
    '                 - 
    '              ByVal strCiudad As String
    '                 -
    '              ByVal strEstado As String
    '                 -
    '              ByVal strClienteFiscalCalle As String
    '                 -
    '              ByVal strClienteFiscalNoExterior As String
    '                 -
    '              ByVal strClienteFiscalNoInterior As String
    '                 -
    '              ByVal strClienteFiscalEMail As String
    '                 -
    '              ByVal dtmClienteFiscalUltimaModificacion As Date
    '                 - 
    '              ByVal strClienteFiscalModificadoPor As String
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
                ByVal intClienteFiscalId As Integer, _
                ByVal strClienteFiscalRFC As String, _
                ByVal strClienteFiscalRazonSocial As String, _
                ByVal strClienteFiscalCalle As String, _
                ByVal strClienteFiscalNoExterior As String, _
                ByVal strClienteFiscalNoInterior As String, _
                ByVal strClienteFiscalColonia As String, _
                ByVal strClienteFiscalCodigoPostal As String, _
                ByVal strClienteFiscalTelefono As String, _
                ByVal strClienteFiscalEMail As String, _
                ByVal strCiudad As String, _
                ByVal strEstado As String, _
                ByVal dtmClienteFiscalUltimaModificacion As Date, _
                ByVal strClienteFiscalModificadoPor As String, _
                ByVal strClienteFiscalDireccion As String, _
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
            Call strSQLStatement.Append("EXECUTE spBuscartblClienteFiscal ")
            Call strSQLStatement.Append(intClienteFiscalId)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(strClienteFiscalRFC)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalRazonSocial)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalCalle)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalNoExterior)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalNoInterior)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalColonia)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalCodigoPostal)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalTelefono)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalEMail)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strCiudad)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strEstado)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmClienteFiscalUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalModificadoPor)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalDireccion)
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
    ' Name       : strBuscar
    ' Description: Búsqueda de registros modificados y que
    '              necesitan ser reenviados.
    '                 - Tabla tblClienteFiscal
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
            Call strSQLStatement.Append("EXECUTE spBuscarCambiotblClienteFiscal ")
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
    ' Name       : intContar
    ' Description: Contar los registros.
    '                 - Tabla tblClienteFiscal
    ' Parameters : 
    '              ByVal intClienteFiscalId As Integer
    '                 - 
    '              ByVal strClienteFiscalRFC As String
    '                 - 
    '              ByVal strClienteFiscalRazonSocial As String
    '                 - 
    '              ByVal strClienteFiscalDireccion As String
    '                 - 
    '              ByVal strClienteFiscalColonia As String
    '                 - 
    '              ByVal strClienteFiscalCodigoPostal As String
    '                 - 
    '              ByVal strClienteFiscalTelefono As String
    '                 - 
    '              ByVal strCiudad As String
    '                 -
    '              ByVal strEstado As String
    '                 -
    '              ByVal strClienteFiscalCalle As String
    '                 -
    '              ByVal strClienteFiscalNoExterior As String
    '                 -
    '              ByVal strClienteFiscalNoInterior As String
    '                 -
    '              ByVal strClienteFiscalEMail As String
    '                 -
    '              ByVal dtmClienteFiscalUltimaModificacion As Date
    '                 - 
    '              ByVal strClienteFiscalModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros en la tabla
    '====================================================================
    Shared Function intContar( _
                ByVal intClienteFiscalId As Integer, _
                ByVal strClienteFiscalRFC As String, _
                ByVal strClienteFiscalRazonSocial As String, _
                ByVal strClienteFiscalCalle As String, _
                ByVal strClienteFiscalNoExterior As String, _
                ByVal strClienteFiscalNoInterior As String, _
                ByVal strClienteFiscalColonia As String, _
                ByVal strClienteFiscalCodigoPostal As String, _
                ByVal strClienteFiscalTelefono As String, _
                ByVal strClienteFiscalEMail As String, _
                ByVal strCiudad As String, _
                ByVal strEstado As String, _
                ByVal dtmClienteFiscalUltimaModificacion As Date, _
                ByVal strClienteFiscalModificadoPor As String, _
                ByVal strClienteFiscalDireccion As String, _
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
            Call strSQLStatement.Append("EXECUTE spContartblClienteFiscal ")
            Call strSQLStatement.Append(intClienteFiscalId)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(strClienteFiscalRFC)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalRazonSocial)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalCalle)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalNoExterior)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalNoInterior)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalColonia)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalCodigoPostal)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalTelefono)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalEMail)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strCiudad)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strEstado)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmClienteFiscalUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalModificadoPor)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalDireccion)
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
    '                 - Tabla tblClienteFiscal
    ' Parameters : 
    '              ByVal intClienteFiscalId As Integer
    '                 - 
    '              ByVal strClienteFiscalRFC As String
    '                 - 
    '              ByVal strClienteFiscalRazonSocial As String
    '                 - 
    '              ByVal strClienteFiscalDireccion As String
    '                 - 
    '              ByVal strClienteFiscalColonia As String
    '                 - 
    '              ByVal strClienteFiscalCodigoPostal As String
    '                 - 
    '              ByVal strClienteFiscalTelefono As String
    '                 - 
    '              ByVal strCiudad As String
    '                 -
    '              ByVal strEstado As String
    '                 -
    '              ByVal strClienteFiscalCalle As String
    '                 -
    '              ByVal strClienteFiscalNoExterior As String
    '                 -
    '              ByVal strClienteFiscalNoInterior As String
    '                 -
    '              ByVal strClienteFiscalEMail As String
    '                 -
    '              ByVal dtmClienteFiscalUltimaModificacion As Date
    '                 - 
    '              ByVal strClienteFiscalModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================        
    Shared Function intEliminar( _
                ByVal intClienteFiscalId As Integer, _
                ByVal strClienteFiscalRFC As String, _
                ByVal strClienteFiscalRazonSocial As String, _
                ByVal strClienteFiscalCalle As String, _
                ByVal strClienteFiscalNoExterior As String, _
                ByVal strClienteFiscalNoInterior As String, _
                ByVal strClienteFiscalColonia As String, _
                ByVal strClienteFiscalCodigoPostal As String, _
                ByVal strClienteFiscalTelefono As String, _
                ByVal strClienteFiscalEMail As String, _
                ByVal strCiudad As String, _
                ByVal strEstado As String, _
                ByVal dtmClienteFiscalUltimaModificacion As Date, _
                ByVal strClienteFiscalModificadoPor As String, _
                ByVal strClienteFiscalDireccion As String, _
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
            Call strSQLStatement.Append("EXECUTE spEliminartblClienteFiscal ")
            Call strSQLStatement.Append(intClienteFiscalId)
            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(strClienteFiscalRFC)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalRazonSocial)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalCalle)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalNoExterior)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalNoInterior)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalColonia)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalCodigoPostal)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalTelefono)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalEMail)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strCiudad)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strEstado)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(dtmClienteFiscalUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalModificadoPor)
            Call strSQLStatement.Append("','")
            Call strSQLStatement.Append(strClienteFiscalDireccion)
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
