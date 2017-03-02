Imports System.Text
Imports Benavides.Data.SQL.MSSQL


'====================================================================
' Class         : clstblEmpresaServicioTipoDatoAdicionalFormato
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Store Procedure Mantenimiento Datos
' Copyright     : 2008 Todos los Derechos Reservados.
' Company       : Benavides
' Author        : Softtek
' Version       : 1.0
' Last Modified : Lunes, 2 de Junio, 2008
'====================================================================
Public NotInheritable Class clstblEmpresaServicioTipoDatoAdicionalFormato

    'Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblEmpresaServicioTipoDatoAdicionalFormato"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()

    End Sub

    '====================================================================
    ' Name       : strBuscar
    ' Description: Búsqueda de registros.
    '                 - Tabla tblEmpresaServicioTipoDatoAdicionalFormato
    ' Parameters : 
    '              ByVal intEmpresaServicioTipoDatoAdicionalFormatoId As Integer
    '                 - 
    '              ByVal intEmpresaServicioTipoDatoFormatoId As Integer
    '                 - 
    '              ByVal strEmpresaServicioTipoDatoAdicionalFormatoNombre As String
    '                 - 
    '              ByVal strEmpresaServicioTipoDatoAdicionalFormatoComponente As String
    '                 - 
    '              ByVal dtmEmpresaServicioTipoDatoAdicionalFormatoUltimaModificacion As Date
    '                 - 
    '              ByVal strEmpresaServicioTipoDatoAdicionalFormatoModificadoPor As String
    '                 -
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '                 - Arreglo bidimensional con los registros leídos
    '                   Array = { (c1,c2..cn), (c1,c2..cn) ... (c1,c2..cn) }
    '                   c = Campo
    '====================================================================
    Shared Function strBuscar( _
            ByVal intEmpresaServicioTipoDatoAdicionalFormatoId As Integer, _
            ByVal intEmpresaServicioTipoDatoFormatoId As Integer, _
            ByVal strEmpresaServicioTipoDatoAdicionalFormatoNombre As String, _
            ByVal strEmpresaServicioTipoDatoAdicionalFormatoComponente As String, _
            ByVal dtmEmpresaServicioTipoDatoAdicionalFormatoUltimaModificacion As Date, _
            ByVal strEmpresaServicioTipoDatoAdicionalFormatoModificadoPor As String, _
            ByVal intPosicionInicial As Double, _
            ByVal intElementos As Double, _
            ByVal strConnectionString As String) As Array

        ' Member identifier
        Const strmThisMemberName As String = "strBuscar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscartblEmpresaServicioTipoDatoAdicionalFormato ")
            Call strSQLStatement.Append(intEmpresaServicioTipoDatoAdicionalFormatoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpresaServicioTipoDatoFormatoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEmpresaServicioTipoDatoAdicionalFormatoNombre)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEmpresaServicioTipoDatoAdicionalFormatoComponente)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmEmpresaServicioTipoDatoAdicionalFormatoUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEmpresaServicioTipoDatoAdicionalFormatoModificadoPor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intPosicionInicial)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intElementos)

            ' Execute the SQL statement
            aobjReturnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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

            Return aobjReturnedData
            ' Raise the error
            Throw

        End Try

    End Function

End Class
