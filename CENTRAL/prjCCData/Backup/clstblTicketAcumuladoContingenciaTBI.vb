Imports System.Text
Imports Benavides.Data.SQL.MSSQL
'====================================================================
' Class         : clstblTicketAcumuladoContingenciaTBI
' Title         : 
' Description   : Capa de datos 
' Copyright     : Softtek
' Company       : Softtek
' Author        : Luis Fernando Gonzalez Hernandez [LSGH]
' Version       : 1.0
' Last Modified : 11 de Septiembre del 2015
'====================================================================
Public NotInheritable Class clstblTicketAcumuladoContingenciaTBI

    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblTicketAcumuladoContingenciaTBI"

    ' Constructor de la clase
    Private Sub New()
        ' Previene la generación de un constructor por defecto
    End Sub

    '====================================================================
    ' Name          : strBuscartblTicketAcumuladoContingenciaTBI
    ' Description   : Regresa un arreglo con el ticket si fue acumulado PLB.
    ' Table name    : tblEstadoSorteo
    ' Parameters    : 
    '                   ByVal intCompaniaId - Id de la compania
    '                   ByVal intSucursalId - Id de la sucursal
    '                   ByVal intCajaId -  Id de la Caja
    '                   ByVal intTicketId - Id del TIcket
    '                   ByVal strConnectionString - Cadena de conexion
    ' Throws        : Exception
    ' Output        : Array
    '====================================================================
    Public Shared Function strBuscartblTicketAcumuladoContingenciaTBI(ByVal intCompaniaId As Integer, _
                                                                        ByVal intSucursalId As Integer, _
                                                                        ByVal intCajaOriginalId As Integer, _
                                                                        ByVal intTicketOriginalId As Integer, _
                                                                        ByVal intCajaId As Integer, _
                                                                        ByVal strConnectionString As String) As Array
        ' Member identifier
        Const strmThisMemberName As String = "strBuscartblTicketAcumuladoContingenciaTBI"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array

        Try

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spBuscartblTicketAcumuladoContingenciaTBI ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intCajaOriginalId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intTicketOriginalId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intCajaId)

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
    ' Name          : intActualizar
    ' Description   : Actualiza valores en Concentrador BD
    ' Table name    : tblTicketAcumuladoContingenciaTBI
    ' Parameters    : 
    '                   ByVal intCompaniaId - Id de la compania
    '                   ByVal intSucursalId - Id de la sucursal
    '                   ByVal intCajaId -  Id de la Caja
    '                   ByVal intTicketId - Id del TIcket
    '                   intTipoTicketAcumuladoPLBId - Id del tipo de acumulacion
    '                   dtmTicketAcumuladoPLBUltimaModificacion - fecha modificacion
    '                   strTicketAcumuladoPLBModificadoPor - Quien lo modificó
    '                   ByVal strConnectionString - Cadena de conexion
    ' Throws        : Exception
    ' Output        : Array
    '====================================================================
    Shared Function intActualizar( _
                ByVal intCompaniaId As Integer, _
                ByVal intSucursalId As Integer, _
                ByVal intCajaOriginalId As Integer, _
                ByVal intTicketOriginalId As Integer, _
                ByVal intCajaId As Integer, _
                ByVal fltTicketContingenciaTBIMontoAcumulado As Double, _
                ByVal intTipoTicketContingenciaTBIId As Integer, _
                ByVal dtmTicketContingenciaTBIUltimaModificacion As Date, _
                ByVal strTicketContingenciaTBIModificadoPor As String, _
                ByVal strConnectionString As String) As Integer

        ' Member identifier
        Const strmThisMemberName As String = "intActualizar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRowsAffected As Integer
        Dim aobjReturnedData As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spActualizartblTicketAcumuladoContingenciaTBI ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCajaOriginalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTicketOriginalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(fltTicketContingenciaTBIMontoAcumulado)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoTicketContingenciaTBIId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmTicketContingenciaTBIUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strTicketContingenciaTBIModificadoPor)
            Call strSQLStatement.Append("'")

            ' Execute the SQL statement
            aobjReturnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

            ' Return the results
            If IsNothing(aobjReturnedData) = False AndAlso aobjReturnedData.Length > 0 Then
                intRowsAffected = CInt(DirectCast(aobjReturnedData.GetValue(0), SortedList).GetByIndex(0))
            End If
            aobjReturnedData = Nothing
            Return intRowsAffected

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
    ' Name          : intAgregar
    ' Description   : Agrega registro en Concentrador BD
    ' Table name    : tblTicketAcumuladoContingenciaTBI
    ' Parameters    : 
    '                   ByVal intCompaniaId - Id de la compania
    '                   ByVal intSucursalId - Id de la sucursal
    '                   ByVal intCajaId -  Id de la Caja
    '                   ByVal intTicketId - Id del TIcket
    '                   intTipoTicketAcumuladoPLBId - Id del tipo de acumulacion
    '                   dtmTicketAcumuladoPLBUltimaModificacion - fecha modificacion
    '                   strTicketAcumuladoPLBModificadoPor - Quien lo modificó
    '                   ByVal strConnectionString - Cadena de conexion
    ' Throws        : Exception
    ' Output        : Array
    '====================================================================
    Shared Function intAgregar( _
                ByVal intCompaniaId As Integer, _
                ByVal intSucursalId As Integer, _
                ByVal intCajaOriginalId As Integer, _
                ByVal intTicketOriginalId As Integer, _
                ByVal intCajaId As Integer, _
                ByVal intEmpleadoId As Integer, _
                ByVal intAsignacionCajaId As Integer, _
                ByVal intTurnoLaboralId As Integer, _
                ByVal strTicketContingenciaTBINumeroTarjeta As String, _
                ByVal strTicketContingenciaTBINumeroCotizacion As String, _
                ByVal strTicketContingenciaTBITicketBeneficio As String, _
                ByVal fltTicketContingenciaTBIMontoAcumulado As Double, _
                ByVal intTipoTicketContingenciaTBIId As Integer, _
                ByVal intTicketCorteZ As Integer, _
                ByVal dtmTicketContingenciaTBIUltimaModificacion As Date, _
                ByVal strTicketContingenciaTBIModificadoPor As String, _
                ByVal strConnectionString As String) As Integer

        ' Member identifier
        Const strmThisMemberName As String = "intAgregar"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRecordId As Integer
        Dim aobjReturnedData As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spAgregartblTicketAcumuladoPLB ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCajaOriginalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTicketOriginalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intAsignacionCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTurnoLaboralId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strTicketContingenciaTBINumeroTarjeta)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strTicketContingenciaTBINumeroCotizacion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strTicketContingenciaTBITicketBeneficio)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltTicketContingenciaTBIMontoAcumulado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoTicketContingenciaTBIId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTicketCorteZ)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmTicketContingenciaTBIUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strTicketContingenciaTBIModificadoPor)
            Call strSQLStatement.Append("'")

            ' Execute the SQL statement
            aobjReturnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

            ' Return the results
            If IsNothing(aobjReturnedData) = False AndAlso aobjReturnedData.Length > 0 Then
                intRecordId = CInt(DirectCast(aobjReturnedData.GetValue(0), SortedList).GetByIndex(0))
            End If
            aobjReturnedData = Nothing
            Return intRecordId

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

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
