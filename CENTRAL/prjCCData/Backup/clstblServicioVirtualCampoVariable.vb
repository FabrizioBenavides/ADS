
Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clstblTipoServicioVirtualCampoVariable
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : 2012 Todos los Derechos Reservados.
' Company       : SOFTTEK
' Author        : Carlos Barberena (CJBG)
' Version       : 1.0
' Last Modified : Jueves, Junio 19, 2012
'====================================================================

Public Class clstblServicioVirtualCampoVariable
    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblServicioVirtualCampoVariable"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()
    End Sub

    '====================================================================
    ' Name       : strBuscar
    ' Description: Busca los campos variables relacionado a un servicio virtual
    '                 - Tabla clstblServicioVirtualCampoVariable
    ' Parameters :
    '              ByVal intServicioVirtualId As Integer
    '                 - Identificador del tipo de servicio
    '              ByVal intIntegradorServicioVirtualId As Integer
    '                 - Identificador del tipo de integrador del servicio virtual
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '                 - Arreglo bidimensional con los registros leídos
    '                   Array = { (c1,c2), (c1,c2) ... (c1,c2) }
    '                   c = Campo
    '====================================================================
    Public Shared Function strBuscar( _
      ByVal intServicioVirtualCampoVariableLDITipoId As Integer, _
      ByVal intServicioVirtualCampoVariableLDISubtipoId As Integer, _
      ByVal strServicioVirtualCampoVariablePropiedad As String, _
      ByVal intServicioVirtualId As Integer, _
      ByVal intIntegradorServicioVirtualId As Integer, _
      ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarServicioVirtualCampoVariable ")
            Call strSQLStatement.Append(intServicioVirtualCampoVariableLDITipoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualCampoVariableLDISubtipoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strServicioVirtualCampoVariablePropiedad)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intIntegradorServicioVirtualId)

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
    ' Name       : intAgregar
    ' Description: Agrega un campo variable relacionado a un servicio virtual
    '                 - Tabla tblServicioVirtualCampoVariable
    ' Parameters :
    '              ByVal intServicioVirtualCampoVariableId As Integer
    '                 - Identificador del campo variable
    '              ByVal blnServicioVirtualCampoVariableSolicitadoEnPOS As Boolean
    '                 - Validación del solicitud de supervisor en POS
    '              ByVal strServicioVirtualCampoVariableDescripcion As String
    '                 - Descripción del campo variable
    '              ByVal strServicioVirtualCampoVariableValor As String
    '                 - Valor del campo variable
    '              ByVal intServicioVirtualCampoVariableNumeroCaracteres As Integer
    '                 - Cantidad de caracteres permitidos en un campo variable
    '              ByVal intServicioVirtualCampoVariableLDITipoId As Integer
    '                 - Identificador del servicio 
    '              ByVal intServicioVirtualCampoVariableLDISubtipoId As Integer
    '                 - Identificador del tipo de campo 
    '              ByVal strServicioVirtualCampoVariableTipo As String
    '                 - Identificador del tipo de campo
    '              ByVal strServicioVirtualCampoVariablePropiedad As String
    '                 - Identificador de la propiedad del campo
    '              ByVal intServicioVirtualCampoVariableDiasVencimiento As Integer
    '                 - Cantidad de días de vencimiento agregados
    '              ByVal intIntegradorServicioVirtualId As Integer
    '                 - Identificador del integrador del servicio virtual.
    '              ByVal intTipoServicioVirtualId As Integer
    '                 - Identificador del tipo de servicio
    '              ByVal dtmServicioVirtualCampoVariableUltimaModificacion As Date
    '                 - Fecha de ultima modificación
    '              ByVal strServicioVirtualCampoVariableModificadoPor As String
    '                 - Registre de usuario que realizo la modificación
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    '
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================

    Public Shared Function intAgregar(ByVal intServicioVirtualCampoVariableId As Integer, _
      ByVal blnServicioVirtualCampoVariableSolicitadoEnPOS As Boolean, _
      ByVal strServicioVirtualCampoVariableDescripcion As String, _
      ByVal strServicioVirtualCampoVariableValor As String, _
      ByVal intServicioVirtualCampoVariableNumeroCaracteres As Integer, _
      ByVal intServicioVirtualCampoVariableLDITipoId As Integer, _
      ByVal intServicioVirtualCampoVariableLDISubtipoId As Integer, _
      ByVal strServicioVirtualCampoVariableTipo As String, _
      ByVal strServicioVirtualCampoVariablePropiedad As String, _
      ByVal intServicioVirtualCampoVariableDiasVencimiento As Integer, _
      ByVal intIntegradorServicioVirtualId As Integer, _
      ByVal intServicioVirtualId As Integer, _
      ByVal dtmServicioVirtualCampoVariableUltimaModificacion As Date, _
      ByVal strServicioVirtualCampoVariableModificadoPor As String, _
      ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intAgregar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0
        Dim strRegistros As Array = Nothing
        Dim strRowsAffected As String() = Nothing

        Try
            ' Inicializamos las variabes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spGuardarServicioVirtualCampoVariable ")
            Call strSQLStatement.Append(intServicioVirtualCampoVariableId)
            Call strSQLStatement.Append(",")
            If blnServicioVirtualCampoVariableSolicitadoEnPOS Then
                Call strSQLStatement.Append(1)
            Else
                Call strSQLStatement.Append(0)
            End If
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strServicioVirtualCampoVariableDescripcion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strServicioVirtualCampoVariableValor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualCampoVariableNumeroCaracteres)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualCampoVariableLDITipoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualCampoVariableLDISubtipoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strServicioVirtualCampoVariableTipo)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strServicioVirtualCampoVariablePropiedad)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualCampoVariableDiasVencimiento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intIntegradorServicioVirtualId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmServicioVirtualCampoVariableUltimaModificacion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strServicioVirtualCampoVariableModificadoPor)
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
    ' Name       : intEliminar
    ' Description: Elimina un campo variable relacionado con un servicio virtual
    '                 - Tabla tblServicioVirtualCampoVariable
    ' Parameters :
    '              ByVal intTipoServicioVirtualId As Integer
    '                 - Identificador del tipo de servicio
    '              ByVal intIntegradorServicioVirtualId As Integer
    '                 - Identificador del tipo de integrador del servicio virtual
    '              ByVal intServicioVirtualId As Integer
    '                 - Identificador del servicio
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================
    Public Shared Function intEliminar( _
      ByVal intServicioVirtualCampoVariableId As Integer, _
      ByVal intIntegradorServicioVirtualId As Integer, _
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
            Call strSQLStatement.Append("EXECUTE spEliminarServicioVirtualCampoVariable ")
            Call strSQLStatement.Append(intServicioVirtualCampoVariableId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intIntegradorServicioVirtualId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intServicioVirtualId)

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
