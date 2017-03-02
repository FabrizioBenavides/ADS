
  '====================================================================
  ' Class         : clstblOrdenFotoLabDetalleTicket
  ' Title         : Grupo Benavides. Administrador POS y Backoffice.
  ' Description   : Store Procedure Mantenimiento Datos
  ' Copyright     : 2005 Todos los Derechos Reservados.
  ' Company       : Benavides
  ' Author        : Sistemas Benavides
  ' Version       : 1.0
  ' Last Modified : Thursday, April 21, 2005
  '====================================================================
  Public NotInheritable Class clstblOrdenFotoLabDetalleTicket
  
    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblOrdenFotoLabDetalleTicket"
    
    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()
    End Sub
    	
    '====================================================================
    ' Name       : intActualizar
    ' Description: Actualización de registros.
    '                 - Tabla tblOrdenFotoLabDetalleTicket
    ' Parameters : 
    '              ByVal intOrdenFotoLabTicketOrdenId As Double
    '                 - 
    '              ByVal intCompaniaId As Double
    '                 - 
    '              ByVal intSucursalId As Double
    '                 - 
    '              ByVal intTipoTicketId As Double
    '                 - 
    '              ByVal intCajaId As Double
    '                 - 
    '              ByVal intEmpleadoId As Double
    '                 - 
    '              ByVal intEstadoOperativoCajaId As Double
    '                 - 
    '              ByVal intTurnoLaboralId As Double
    '                 - 
    '              ByVal intAsignacionCajaId As Double
    '                 - 
    '              ByVal intTicketId As Double
    '                 - 
    '              ByVal intArticuloId As Double
    '                 - 
    '              ByVal intOrdenFotolabDetalleTicketId As Double
    '                 - 
    '              ByVal intOrdenFotolabDetalleTicketCantidadArticulos As Double
    '                 - 
    '              ByVal fltOrdenFotolabDetalleTicketPrecioNormalConImpuesto As Double
    '                 - 
    '              ByVal fltOrdenFotolabDetalleTicketPrecioVentaConImpuesto As Double
    '                 - 
    '              ByVal fltOrdenFotolabDetalleTicketImporteDelDescuentoConImpuesto As Double
    '                 - 
    '              ByVal fltOrdenFotolabDetalleTicketImporteVentaConImpuesto As Double
    '                 - 
    '              ByVal fltOrdenFotolabDetalleTicketImporteNormalConImpuesto As Double
    '                 - 
    '              ByVal blnOrdenFotolabDetalleTicketArticuloVendidoConCodigo As Byte
    '                 - 
    '              ByVal blnOrdenFotolabDetalleTicketCancelado As Byte
    '                 - 
    '              ByVal blnOrdenFotolabDetalleTicketExcentoImpuesto As Byte
    '                 - 
    '              ByVal dtmOrdenFotoLabDetalleTicketUltimaModificacion As Date
    '                 - 
    '              ByVal strOrdenFotoLabDetalleTicketModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================
    Shared Function intActualizar( _
        ByVal intOrdenFotoLabTicketOrdenId As Double, _
        ByVal intCompaniaId As Double, _
        ByVal intSucursalId As Double, _
        ByVal intTipoTicketId As Double, _
        ByVal intCajaId As Double, _
        ByVal intEmpleadoId As Double, _
        ByVal intEstadoOperativoCajaId As Double, _
        ByVal intTurnoLaboralId As Double, _
        ByVal intAsignacionCajaId As Double, _
        ByVal intTicketId As Double, _
        ByVal intArticuloId As Double, _
        ByVal intOrdenFotolabDetalleTicketId As Double, _
        ByVal intOrdenFotolabDetalleTicketCantidadArticulos As Double, _
        ByVal fltOrdenFotolabDetalleTicketPrecioNormalConImpuesto As Double, _
        ByVal fltOrdenFotolabDetalleTicketPrecioVentaConImpuesto As Double, _
        ByVal fltOrdenFotolabDetalleTicketImporteDelDescuentoConImpuesto As Double, _
        ByVal fltOrdenFotolabDetalleTicketImporteVentaConImpuesto As Double, _
        ByVal fltOrdenFotolabDetalleTicketImporteNormalConImpuesto As Double, _
        ByVal blnOrdenFotolabDetalleTicketArticuloVendidoConCodigo As Boolean, _
        ByVal blnOrdenFotolabDetalleTicketCancelado As Boolean, _
        ByVal blnOrdenFotolabDetalleTicketExcentoImpuesto As Boolean, _
        ByVal dtmOrdenFotoLabDetalleTicketUltimaModificacion As Date, _
        ByVal strOrdenFotoLabDetalleTicketModificadoPor As String, _
        ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intActualizar"

        ' Declare variables locales
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRecordId As Integer
        Dim aobjReturnedData As Array

        Try

            ' Creamos estatuto de SQL
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spActualizartblOrdenFotoLabDetalleTicket ")
            Call strSQLStatement.Append(intOrdenFotoLabTicketOrdenId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEstadoOperativoCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTurnoLaboralId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intAsignacionCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intOrdenFotolabDetalleTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intOrdenFotolabDetalleTicketCantidadArticulos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketPrecioNormalConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketPrecioVentaConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketImporteDelDescuentoConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketImporteVentaConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketImporteNormalConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnOrdenFotolabDetalleTicketArticuloVendidoConCodigo))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnOrdenFotolabDetalleTicketCancelado))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnOrdenFotolabDetalleTicketExcentoImpuesto))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmOrdenFotoLabDetalleTicketUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strOrdenFotoLabDetalleTicketModificadoPor)
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

    '====================================================================
    ' Name       : intAgregar
    ' Description: Adición de registros.
    '                  - Tabla tblOrdenFotoLabDetalleTicket
    ' Parameters : 
    '              ByVal intOrdenFotoLabTicketOrdenId As Double
    '                  - 
    '              ByVal intCompaniaId As Double
    '                  - 
    '              ByVal intSucursalId As Double
    '                  - 
    '              ByVal intTipoTicketId As Double
    '                  - 
    '              ByVal intCajaId As Double
    '                  - 
    '              ByVal intEmpleadoId As Double
    '                  - 
    '              ByVal intEstadoOperativoCajaId As Double
    '                  - 
    '              ByVal intTurnoLaboralId As Double
    '                  - 
    '              ByVal intAsignacionCajaId As Double
    '                  - 
    '              ByVal intTicketId As Double
    '                  - 
    '              ByVal intArticuloId As Double
    '                  - 
    '              ByVal intOrdenFotolabDetalleTicketId As Double
    '                  - 
    '              ByVal intOrdenFotolabDetalleTicketCantidadArticulos As Double
    '                  - 
    '              ByVal fltOrdenFotolabDetalleTicketPrecioNormalConImpuesto As Double
    '                  - 
    '              ByVal fltOrdenFotolabDetalleTicketPrecioVentaConImpuesto As Double
    '                  - 
    '              ByVal fltOrdenFotolabDetalleTicketImporteDelDescuentoConImpuesto As Double
    '                  - 
    '              ByVal fltOrdenFotolabDetalleTicketImporteVentaConImpuesto As Double
    '                  - 
    '              ByVal fltOrdenFotolabDetalleTicketImporteNormalConImpuesto As Double
    '                  - 
    '              ByVal blnOrdenFotolabDetalleTicketArticuloVendidoConCodigo As Byte
    '                  - 
    '              ByVal blnOrdenFotolabDetalleTicketCancelado As Byte
    '                  - 
    '              ByVal blnOrdenFotolabDetalleTicketExcentoImpuesto As Byte
    '                  - 
    '              ByVal dtmOrdenFotoLabDetalleTicketUltimaModificacion As Date
    '                  - 
    '              ByVal strOrdenFotoLabDetalleTicketModificadoPor As String
    '                  -       
    '              ByVal strConnectionString As String
    '                  - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================        
    Shared Function intAgregar( _
                ByVal intOrdenFotoLabTicketOrdenId As Double, _
                ByVal intCompaniaId As Double, _
                ByVal intSucursalId As Double, _
                ByVal intTipoTicketId As Double, _
                ByVal intCajaId As Double, _
                ByVal intEmpleadoId As Double, _
                ByVal intEstadoOperativoCajaId As Double, _
                ByVal intTurnoLaboralId As Double, _
                ByVal intAsignacionCajaId As Double, _
                ByVal intTicketId As Double, _
                ByVal intArticuloId As Double, _
                ByVal intOrdenFotolabDetalleTicketId As Double, _
                ByVal intOrdenFotolabDetalleTicketCantidadArticulos As Double, _
                ByVal fltOrdenFotolabDetalleTicketPrecioNormalConImpuesto As Double, _
                ByVal fltOrdenFotolabDetalleTicketPrecioVentaConImpuesto As Double, _
                ByVal fltOrdenFotolabDetalleTicketImporteDelDescuentoConImpuesto As Double, _
                ByVal fltOrdenFotolabDetalleTicketImporteVentaConImpuesto As Double, _
                ByVal fltOrdenFotolabDetalleTicketImporteNormalConImpuesto As Double, _
                ByVal blnOrdenFotolabDetalleTicketArticuloVendidoConCodigo As Boolean, _
                ByVal blnOrdenFotolabDetalleTicketCancelado As Boolean, _
                ByVal blnOrdenFotolabDetalleTicketExcentoImpuesto As Boolean, _
                ByVal dtmOrdenFotoLabDetalleTicketUltimaModificacion As Date, _
                ByVal strOrdenFotoLabDetalleTicketModificadoPor As String, _
                ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intAgregar"

        ' Declare variables locales
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRecordId As Integer
        Dim aobjReturnedData As Array

        Try
            ' Creamos es estatuto de SQL
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spAgregartblOrdenFotoLabDetalleTicket ")
            Call strSQLStatement.Append(intOrdenFotoLabTicketOrdenId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEstadoOperativoCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTurnoLaboralId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intAsignacionCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intOrdenFotolabDetalleTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intOrdenFotolabDetalleTicketCantidadArticulos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketPrecioNormalConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketPrecioVentaConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketImporteDelDescuentoConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketImporteVentaConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketImporteNormalConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnOrdenFotolabDetalleTicketArticuloVendidoConCodigo))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnOrdenFotolabDetalleTicketCancelado))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnOrdenFotolabDetalleTicketExcentoImpuesto))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmOrdenFotoLabDetalleTicketUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strOrdenFotoLabDetalleTicketModificadoPor)
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

    '====================================================================
    ' Name       : strBuscar
    ' Description: Búsqueda de registros.
    '                 - Tabla tblOrdenFotoLabDetalleTicket
    ' Parameters : 
    '              ByVal intOrdenFotoLabTicketOrdenId As Double
    '                 - 
    '              ByVal intCompaniaId As Double
    '                 - 
    '              ByVal intSucursalId As Double
    '                 - 
    '              ByVal intTipoTicketId As Double
    '                 - 
    '              ByVal intCajaId As Double
    '                 - 
    '              ByVal intEmpleadoId As Double
    '                 - 
    '              ByVal intEstadoOperativoCajaId As Double
    '                 - 
    '              ByVal intTurnoLaboralId As Double
    '                 - 
    '              ByVal intAsignacionCajaId As Double
    '                 - 
    '              ByVal intTicketId As Double
    '                 - 
    '              ByVal intArticuloId As Double
    '                 - 
    '              ByVal intOrdenFotolabDetalleTicketId As Double
    '                 - 
    '              ByVal intOrdenFotolabDetalleTicketCantidadArticulos As Double
    '                 - 
    '              ByVal fltOrdenFotolabDetalleTicketPrecioNormalConImpuesto As Double
    '                 - 
    '              ByVal fltOrdenFotolabDetalleTicketPrecioVentaConImpuesto As Double
    '                 - 
    '              ByVal fltOrdenFotolabDetalleTicketImporteDelDescuentoConImpuesto As Double
    '                 - 
    '              ByVal fltOrdenFotolabDetalleTicketImporteVentaConImpuesto As Double
    '                 - 
    '              ByVal fltOrdenFotolabDetalleTicketImporteNormalConImpuesto As Double
    '                 - 
    '              ByVal blnOrdenFotolabDetalleTicketArticuloVendidoConCodigo As Byte
    '                 - 
    '              ByVal blnOrdenFotolabDetalleTicketCancelado As Byte
    '                 - 
    '              ByVal blnOrdenFotolabDetalleTicketExcentoImpuesto As Byte
    '                 - 
    '              ByVal dtmOrdenFotoLabDetalleTicketUltimaModificacion As Date
    '                 - 
    '              ByVal strOrdenFotoLabDetalleTicketModificadoPor As String
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
         ByVal intOrdenFotoLabTicketOrdenId As Double, _
         ByVal intCompaniaId As Double, _
         ByVal intSucursalId As Double, _
         ByVal intTipoTicketId As Double, _
         ByVal intCajaId As Double, _
         ByVal intEmpleadoId As Double, _
         ByVal intEstadoOperativoCajaId As Double, _
         ByVal intTurnoLaboralId As Double, _
         ByVal intAsignacionCajaId As Double, _
         ByVal intTicketId As Double, _
         ByVal intArticuloId As Double, _
         ByVal intOrdenFotolabDetalleTicketId As Double, _
         ByVal intOrdenFotolabDetalleTicketCantidadArticulos As Double, _
         ByVal fltOrdenFotolabDetalleTicketPrecioNormalConImpuesto As Double, _
         ByVal fltOrdenFotolabDetalleTicketPrecioVentaConImpuesto As Double, _
         ByVal fltOrdenFotolabDetalleTicketImporteDelDescuentoConImpuesto As Double, _
         ByVal fltOrdenFotolabDetalleTicketImporteVentaConImpuesto As Double, _
         ByVal fltOrdenFotolabDetalleTicketImporteNormalConImpuesto As Double, _
         ByVal blnOrdenFotolabDetalleTicketArticuloVendidoConCodigo As Boolean, _
         ByVal blnOrdenFotolabDetalleTicketCancelado As Boolean, _
         ByVal blnOrdenFotolabDetalleTicketExcentoImpuesto As Boolean, _
         ByVal dtmOrdenFotoLabDetalleTicketUltimaModificacion As DateTime, _
         ByVal strOrdenFotoLabDetalleTicketModificadoPor As String, _
         ByVal intPosicionInicial As Double, _
         ByVal intElementos As Double, _
         ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscar"

        ' Declare variables locales
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRecordId As Integer
        Dim aobjReturnedData As Array

        Try
            ' Creamos es estatuto de SQL
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscartblOrdenFotoLabDetalleTicket ")
            Call strSQLStatement.Append(intOrdenFotoLabTicketOrdenId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEstadoOperativoCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTurnoLaboralId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intAsignacionCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intOrdenFotolabDetalleTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intOrdenFotolabDetalleTicketCantidadArticulos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketPrecioNormalConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketPrecioVentaConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketImporteDelDescuentoConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketImporteVentaConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketImporteNormalConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnOrdenFotolabDetalleTicketArticuloVendidoConCodigo))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnOrdenFotolabDetalleTicketCancelado))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnOrdenFotolabDetalleTicketExcentoImpuesto))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmOrdenFotoLabDetalleTicketUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strOrdenFotoLabDetalleTicketModificadoPor)
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

            ' Raise the error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : intContar
    ' Description: Contar los registros.
    '                 - Tabla tblOrdenFotoLabDetalleTicket
    ' Parameters : 
    '              ByVal intOrdenFotoLabTicketOrdenId As Double
    '                 - 
    '              ByVal intCompaniaId As Double
    '                 - 
    '              ByVal intSucursalId As Double
    '                 - 
    '              ByVal intTipoTicketId As Double
    '                 - 
    '              ByVal intCajaId As Double
    '                 - 
    '              ByVal intEmpleadoId As Double
    '                 - 
    '              ByVal intEstadoOperativoCajaId As Double
    '                 - 
    '              ByVal intTurnoLaboralId As Double
    '                 - 
    '              ByVal intAsignacionCajaId As Double
    '                 - 
    '              ByVal intTicketId As Double
    '                 - 
    '              ByVal intArticuloId As Double
    '                 - 
    '              ByVal intOrdenFotolabDetalleTicketId As Double
    '                 - 
    '              ByVal intOrdenFotolabDetalleTicketCantidadArticulos As Double
    '                 - 
    '              ByVal fltOrdenFotolabDetalleTicketPrecioNormalConImpuesto As Double
    '                 - 
    '              ByVal fltOrdenFotolabDetalleTicketPrecioVentaConImpuesto As Double
    '                 - 
    '              ByVal fltOrdenFotolabDetalleTicketImporteDelDescuentoConImpuesto As Double
    '                 - 
    '              ByVal fltOrdenFotolabDetalleTicketImporteVentaConImpuesto As Double
    '                 - 
    '              ByVal fltOrdenFotolabDetalleTicketImporteNormalConImpuesto As Double
    '                 - 
    '              ByVal blnOrdenFotolabDetalleTicketArticuloVendidoConCodigo As Byte
    '                 - 
    '              ByVal blnOrdenFotolabDetalleTicketCancelado As Byte
    '                 - 
    '              ByVal blnOrdenFotolabDetalleTicketExcentoImpuesto As Byte
    '                 - 
    '              ByVal dtmOrdenFotoLabDetalleTicketUltimaModificacion As Date
    '                 - 
    '              ByVal strOrdenFotoLabDetalleTicketModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros en la tabla
    '====================================================================
    Shared Function intContar( _
            ByVal intOrdenFotoLabTicketOrdenId As Double, _
            ByVal intCompaniaId As Double, _
            ByVal intSucursalId As Double, _
            ByVal intTipoTicketId As Double, _
            ByVal intCajaId As Double, _
            ByVal intEmpleadoId As Double, _
            ByVal intEstadoOperativoCajaId As Double, _
            ByVal intTurnoLaboralId As Double, _
            ByVal intAsignacionCajaId As Double, _
            ByVal intTicketId As Double, _
            ByVal intArticuloId As Double, _
            ByVal intOrdenFotolabDetalleTicketId As Double, _
            ByVal intOrdenFotolabDetalleTicketCantidadArticulos As Double, _
            ByVal fltOrdenFotolabDetalleTicketPrecioNormalConImpuesto As Double, _
            ByVal fltOrdenFotolabDetalleTicketPrecioVentaConImpuesto As Double, _
            ByVal fltOrdenFotolabDetalleTicketImporteDelDescuentoConImpuesto As Double, _
            ByVal fltOrdenFotolabDetalleTicketImporteVentaConImpuesto As Double, _
            ByVal fltOrdenFotolabDetalleTicketImporteNormalConImpuesto As Double, _
            ByVal blnOrdenFotolabDetalleTicketArticuloVendidoConCodigo As Boolean, _
            ByVal blnOrdenFotolabDetalleTicketCancelado As Boolean, _
            ByVal blnOrdenFotolabDetalleTicketExcentoImpuesto As Boolean, _
            ByVal dtmOrdenFotoLabDetalleTicketUltimaModificacion As Date, _
            ByVal strOrdenFotoLabDetalleTicketModificadoPor As String, _
            ByVal strConnectionString As String) As Double

        ' Constantes locales
        Const strmThisMemberName As String = "intContar"

        ' Declare variables locales
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRecordId As Integer
        Dim aobjReturnedData As Array

        Try
            ' Creamos es estatuto de SQL
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spContartblOrdenFotoLabDetalleTicket ")
            Call strSQLStatement.Append(intOrdenFotoLabTicketOrdenId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEstadoOperativoCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTurnoLaboralId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intAsignacionCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intOrdenFotolabDetalleTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intOrdenFotolabDetalleTicketCantidadArticulos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketPrecioNormalConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketPrecioVentaConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketImporteDelDescuentoConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketImporteVentaConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketImporteNormalConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnOrdenFotolabDetalleTicketArticuloVendidoConCodigo))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnOrdenFotolabDetalleTicketCancelado))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnOrdenFotolabDetalleTicketExcentoImpuesto))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmOrdenFotoLabDetalleTicketUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strOrdenFotoLabDetalleTicketModificadoPor)
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


    '====================================================================
    ' Name       : intEliminar
    ' Description: Eliminación de registros.
    '                 - Tabla tblOrdenFotoLabDetalleTicket
    ' Parameters : 
    '              ByVal intOrdenFotoLabTicketOrdenId As Double
    '                 - 
    '              ByVal intCompaniaId As Double
    '                 - 
    '              ByVal intSucursalId As Double
    '                 - 
    '              ByVal intTipoTicketId As Double
    '                 - 
    '              ByVal intCajaId As Double
    '                 - 
    '              ByVal intEmpleadoId As Double
    '                 - 
    '              ByVal intEstadoOperativoCajaId As Double
    '                 - 
    '              ByVal intTurnoLaboralId As Double
    '                 - 
    '              ByVal intAsignacionCajaId As Double
    '                 - 
    '              ByVal intTicketId As Double
    '                 - 
    '              ByVal intArticuloId As Double
    '                 - 
    '              ByVal intOrdenFotolabDetalleTicketId As Double
    '                 - 
    '              ByVal intOrdenFotolabDetalleTicketCantidadArticulos As Double
    '                 - 
    '              ByVal fltOrdenFotolabDetalleTicketPrecioNormalConImpuesto As Double
    '                 - 
    '              ByVal fltOrdenFotolabDetalleTicketPrecioVentaConImpuesto As Double
    '                 - 
    '              ByVal fltOrdenFotolabDetalleTicketImporteDelDescuentoConImpuesto As Double
    '                 - 
    '              ByVal fltOrdenFotolabDetalleTicketImporteVentaConImpuesto As Double
    '                 - 
    '              ByVal fltOrdenFotolabDetalleTicketImporteNormalConImpuesto As Double
    '                 - 
    '              ByVal blnOrdenFotolabDetalleTicketArticuloVendidoConCodigo As Byte
    '                 - 
    '              ByVal blnOrdenFotolabDetalleTicketCancelado As Byte
    '                 - 
    '              ByVal blnOrdenFotolabDetalleTicketExcentoImpuesto As Byte
    '                 - 
    '              ByVal dtmOrdenFotoLabDetalleTicketUltimaModificacion As Date
    '                 - 
    '              ByVal strOrdenFotoLabDetalleTicketModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================        
    Shared Function intEliminar( _
            ByVal intOrdenFotoLabTicketOrdenId As Double, _
            ByVal intCompaniaId As Double, _
            ByVal intSucursalId As Double, _
            ByVal intTipoTicketId As Double, _
            ByVal intCajaId As Double, _
            ByVal intEmpleadoId As Double, _
            ByVal intEstadoOperativoCajaId As Double, _
            ByVal intTurnoLaboralId As Double, _
            ByVal intAsignacionCajaId As Double, _
            ByVal intTicketId As Double, _
            ByVal intArticuloId As Double, _
            ByVal intOrdenFotolabDetalleTicketId As Double, _
            ByVal intOrdenFotolabDetalleTicketCantidadArticulos As Double, _
            ByVal fltOrdenFotolabDetalleTicketPrecioNormalConImpuesto As Double, _
            ByVal fltOrdenFotolabDetalleTicketPrecioVentaConImpuesto As Double, _
            ByVal fltOrdenFotolabDetalleTicketImporteDelDescuentoConImpuesto As Double, _
            ByVal fltOrdenFotolabDetalleTicketImporteVentaConImpuesto As Double, _
            ByVal fltOrdenFotolabDetalleTicketImporteNormalConImpuesto As Double, _
            ByVal blnOrdenFotolabDetalleTicketArticuloVendidoConCodigo As Boolean, _
            ByVal blnOrdenFotolabDetalleTicketCancelado As Boolean, _
            ByVal blnOrdenFotolabDetalleTicketExcentoImpuesto As Boolean, _
            ByVal dtmOrdenFotoLabDetalleTicketUltimaModificacion As DateTime, _
            ByVal strOrdenFotoLabDetalleTicketModificadoPor As String, _
            ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intEliminar"

        ' Declare variables locales
        Dim strSQLStatement As System.Text.StringBuilder
        Dim intRecordId As Integer
        Dim aobjReturnedData As Array

        Try
            ' Creamos es estatuto de SQL
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spEliminartblOrdenFotoLabDetalleTicket ")
            Call strSQLStatement.Append(intOrdenFotoLabTicketOrdenId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEstadoOperativoCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTurnoLaboralId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intAsignacionCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intOrdenFotolabDetalleTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intOrdenFotolabDetalleTicketCantidadArticulos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketPrecioNormalConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketPrecioVentaConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketImporteDelDescuentoConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketImporteVentaConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltOrdenFotolabDetalleTicketImporteNormalConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnOrdenFotolabDetalleTicketArticuloVendidoConCodigo))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnOrdenFotolabDetalleTicketCancelado))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(CByte(blnOrdenFotolabDetalleTicketExcentoImpuesto))
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmOrdenFotoLabDetalleTicketUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strOrdenFotoLabDetalleTicketModificadoPor)
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

End Class
