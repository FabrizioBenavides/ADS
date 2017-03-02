Public NotInheritable Class clsConfiguracionSucursal
    '====================================================================
    ' Class         : clsConfiguracionSucursal
    ' Title         : Grupo Benavides. Administrador POS y Backoffice.
    ' Description   : Operaciones con datos
    ' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
    ' Company       : Isocraft. (http://www.isocraft.com/)
    ' Author        : Sergio Leal Garza (sergio@isocraft.com)
    ' Last Modified : Wednesday, May 18, 2005
    '====================================================================

    ' Class identifier
    Private Const strmThisClassName As String = "Benavides.CC.Data.clsConfiguracionSucursal"

    ' Class constructor
    Private Sub New()
        ' Empty constructor to avoid the creation of the default constructor
    End Sub


    '====================================================================
    ' Name          : aobjAgregarConfiguracionSucursal
    ' Description   : Regresa las sucursales con Operaciones de Dinero Express
    ' Parameters    :   
    '              ByVal intCompaniaId As Integer
    '                  - Identificador de la compañía
    '              ByVal intSucursalId As Integer
    '                  - Identificador de la sucursal
    '              ByVal strConfiguracionSucursalNombreId As String
    '                  - Nombre del parametro de configuración
    '              ByVal strConfiguracionSucursalModificadoPor As String
    '                  - Modificado Por
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Array
    '====================================================================

    Public Shared Function aobjAgregarConfiguracionSucursal( _
          ByVal intCompaniaId As Integer, _
          ByVal intSucursalId As Integer, _
          ByVal strConfiguracionSucursalNombreId As String, _
          ByVal strConfiguracionSucursalValor As String, _
          ByVal strConfiguracionSucursalModificadoPor As String, _
          ByVal strConnectionString As String) As Array

        ' Member identifier
        Const strmThisMemberName As String = "aobjBuscarDetalleSucursal"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array

        Try

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spAgregarConfiguracionSucursal ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strConfiguracionSucursalNombreId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strConfiguracionSucursalValor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strConfiguracionSucursalModificadoPor)
            Call strSQLStatement.Append("'")

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

            ' Raise the error
            Throw

        End Try

    End Function
End Class
