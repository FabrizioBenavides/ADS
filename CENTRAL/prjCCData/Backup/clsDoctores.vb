Imports System.Text
Imports Benavides.Data.SQL.MSSQL


'====================================================================
' Class         : clstblArticulo
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : 2003-2005 Todos los Derechos Reservados.
' Company       : 
' Author        : Dirección de Tecnología
' Version       : 
' Last Modified : 
'====================================================================
Public NotInheritable Class clsDoctores
    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clsDoctores"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()
    End Sub


    '====================================================================
    ' Name          : aobjObtenerArticulosComplementariosDeUnArticulo
    ' Description   : Returns an array of SortedList objects with the records found
    ' Table name    : tblDoctores
    ' Parameters    : 
    '              ByVal cedula As Int32
    '                  - La Cedula Profesional del doctor a buscar
    ' Throws        : Exception
    ' Output        : Array
    '====================================================================
    Public Shared Function strConsultarDoctores(ByVal cedula As Integer, ByVal strConnectionString As String) As Array
        ' Member identifier
        Const strmThisMemberName As String = "strConsultarDoctores"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array

        Try

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spBuscarDoctores ")
            Call strSQLStatement.Append(cedula)

            ' Execute the SQL statement
            aobjReturnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
    ' Name       : intActualizarAgregarDoctor
    ' Description: Actualiza y Agrega los registros de doctores.
    '                 - Tabla tblDoctor
    ' Parameters : 
    '
    '              ByVal cedula As Integer
    '                 - 
    '              ByVal nombre As String
    '                 - 
    '              ByVal apellidopaterno As String
    '                 - 
    '              ByVal apellidomaterno As String
    '                 - 
    '              ByVal calle As String
    '                 - 
    '              ByVal interior As String
    '                 - 
    '              ByVal exterior As String
    '                 - 
    '              ByVal colonia As String
    '                 - 
    '              ByVal estado As String
    '                 - 
    '              ByVal ciudad As String
    '                 - 
    '              ByVal codigopostal As String
    '                 - 
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    '
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================

    Public Shared Function intActualizarAgregarDoctor( _
      ByVal cedula As Integer, _
      ByVal nombre As String, _
      ByVal apellidopaterno As String, _
      ByVal apellidomaterno As String, _
      ByVal calle As String, _
      ByVal interior As String, _
      ByVal exterior As String, _
      ByVal colonia As String, _
      ByVal estado As Integer, _
      ByVal ciudad As Integer, _
      ByVal codigopostal As String, _
      ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intActualizarAgregarDoctor"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0
        Dim strRegistros As Array = Nothing
        Dim strRowsAffected As String() = Nothing

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spActualizarAgregarDoctor ")
            Call strSQLStatement.Append(cedula)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(nombre)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(apellidopaterno)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(apellidomaterno)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(calle)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(interior)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(exterior)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(colonia)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append(estado)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append(ciudad)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(codigopostal)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append("'")


            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            If Not IsNothing(strRegistros) Then
                For Each strRowsAffected In strRegistros
                    intRowsAffected = CInt(strRowsAffected.GetValue(0))
                Next
            End If

            ' Regresamos la información
            strSQLStatement = Nothing
            intActualizarAgregarDoctor = intRowsAffected

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
            intActualizarAgregarDoctor = 0

            ' Notificamos el error
            Throw

        End Try

    End Function


End Class
