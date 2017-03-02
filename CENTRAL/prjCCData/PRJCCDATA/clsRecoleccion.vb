Public NotInheritable Class clsRecoleccion
     '====================================================================
    ' Class         : clsRecoleccion
    ' Title         : Grupo Benavides. Administrador POS y Backoffice.
    ' Description   : Recolecciones DEX y Recoleccion Normales
    ' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
    ' Company       : Isocraft. (http://www.isocraft.com/)
    ' Author        : Sergio Leal Garza (sergio@isocraft.com)
    ' Last Modified : Friday, May 30, 2005
    '====================================================================

    ' Class identifier
    Private Const strmThisClassName As String = "Benavides.CC.Data.clsOperacionDEX"

    ' Class constructor
    Private Sub New()
        ' Empty constructor to avoid the creation of the default constructor
    End Sub

    '====================================================================
    ' Name          : aobjBuscarRecoleccionesPorSucursal
    ' Description   : Regresa las sucursales con Operaciones de Dinero Express
    ' Parameters    :   
    '              ByVal intDireccionOperativaId As Int32
    '                  - Identificador de la dirección
    '              ByVal intZonaOperativaId As Int32
    '                  - Identificador de la zona
    '              ByVal strTipoTicketNombreId As  String
    '                 - Initial position
    '              ByVal intInitialPosition As  Double
    '                 - Initial position
    '              ByVal intEstatus As  Int32
    '                 - Estatus de la recoleccion
    '              ByVal intFechaId As  Int32
    '                 - Estatus de la recoleccion
    '              ByVal fltEfectivoMaximoPorCaja As  Double
    '                 - Initial position
    '              ByVal intElementsToRetrieve As Double
    '                 - Number of elements per page
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Array
    '====================================================================



    Public Shared Function aobjBuscarRecoleccionesPorSucursal( _
          ByVal intDireccionOperativaId As Integer, _
          ByVal intZonaOperativaId As Integer, _
          ByVal strTipoTicketNombreId As String, _
          ByVal intEstatus As Integer, _
          ByVal intFechaId As Integer, _
          ByVal fltEfectivoMaximoPorCaja As Double, _
          ByVal intInitialPosition As Double, _
          ByVal intElementsToRetrieve As Double, _
          ByVal strConnectionString As String) As Array


        ' Member identifier
        Const strmThisMemberName As String = "aobjBuscarRecoleccionesPorSucursal"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array

        Try

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spBuscarRecoleccionesPorSucursal ")
            Call strSQLStatement.Append(intDireccionOperativaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intZonaOperativaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strTipoTicketNombreId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEstatus)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intFechaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltEfectivoMaximoPorCaja)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intInitialPosition)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intElementsToRetrieve)

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

    '====================================================================
    ' Name          : aobjObtenerRecolecciones
    ' Description   : Regresa el Detalle de las Recolecciones de una Sucursal
    ' Parameters    :   
    '              ByVal intCompaniaId As Int32
    '                  - Identificador de la dirección
    '              ByVal intSucursalId As Int32
    '                  - Identificador de la zona
    '              ByVal strTipoTicketNombreId As  String
    '                 - Initial position
    '              ByVal intInitialPosition As  Double
    '                 - Initial position
    '              ByVal intEstatus As  Int32
    '                 - Estatus de la recoleccion
    '              ByVal intFechaId As  Int32
    '                 - Estatus de la recoleccion
    '              ByVal fltEfectivoMaximoPorCaja As  Double
    '                 - Initial position
    '              ByVal intElementsToRetrieve As Double
    '                 - Number of elements per page
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Array
    '====================================================================



    Public Shared Function aobjObtenerRecolecciones( _
          ByVal intCompaniaId As Integer, _
          ByVal intSucursalId As Integer, _
          ByVal strTipoTicketNombreId As String, _
          ByVal intEstatus As Integer, _
          ByVal intFechaId As Integer, _
          ByVal fltEfectivoMaximoPorCaja As Double, _
          ByVal intInitialPosition As Double, _
          ByVal intElementsToRetrieve As Double, _
          ByVal strConnectionString As String) As Array


        ' Member identifier
        Const strmThisMemberName As String = "aobjObtenerRecolecciones"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array

        Try

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spObtenerRecolecciones ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strTipoTicketNombreId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEstatus)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intFechaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltEfectivoMaximoPorCaja)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intInitialPosition)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intElementsToRetrieve)

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
