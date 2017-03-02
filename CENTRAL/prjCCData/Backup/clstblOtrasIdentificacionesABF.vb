Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clstblOtrasIdentificacionesABF
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : 2015 Todos los Derechos Reservados.
' Company       : Softtek
' Author        : Jesus Colunga
' Version       : 1.0
' Last Modified : October 7, 2015
'====================================================================
Public NotInheritable Class clstblOtrasIdentificacionesABF

    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblOtrasIdentificacionesABF"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()
        ' Empty constructor to avoid the creation of the default constructor
    End Sub
    '====================================================================
    ' Name       : strXMLObtieneClientesOtrasIdentificaciones
    ' Description: Obtiene el listado de clientes de otras identifiaciones
    '				en formato XML
    '                 - Tabla: tblOtrasIdentifiacionesAbf
    ' Parameters : 
    '              ByVal strClienteABFNombre As String
    '                 - Nombre del Cliente
    '              ByVal strCompaniaCteABF As String
    '                 - Compañía del Cliente
    '              ByVal strSucursalCteAbf As String
    '                 - Sucursal del Cliente
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    ' Creado     : Jesus Adrian Colunga Almaguer
    ' Fecha      : 07/Octubre/2015
    ' Descrip    : Consulta la tabla tblOtrasIdentifiacionesAbf para extraer 
    '              el listado de clientes activos
    '====================================================================
    Public Shared Function strXMLObtieneClientesOtrasIdentificaciones(ByVal strClienteABFNombre As String, _
                                                                     ByVal strCompaniaCteABF As String, _
                                                                     ByVal strSucursalCteABF As String, _
                                                                     ByVal strConnectionString As String) As Array
        ' Constantes Locales
        Const strmThisMemberName As String = "strXMLObtieneClientesOtrasIdentificaciones"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try

            ' Crear el comando
            strSQLStatement = New StringBuilder

            Call strSQLStatement.Append("EXECUTE spBuscaOtrasIdentificacionesActivo ")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strClienteABFNombre)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(strCompaniaCteABF)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(strSucursalCteABF)

            ' Ejecutar el comando SQL
            strXMLObtieneClientesOtrasIdentificaciones = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

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
            strXMLObtieneClientesOtrasIdentificaciones = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

End Class