Imports System.Text
Imports Benavides.Data.SQL.MSSQL


Public Class clsCapturaInsumosMateriaPrima

    ' Class identifier
    Private Const strmThisClassName As String = "Benavides.CC.Data.clsProveedor"

    ' Class constructor
    Private Sub New()
        ' Empty constructor to avoid the creation of the default constructor
    End Sub

#Region "Pantalla Capturar Insumos"

#Region "Pop Up Proveedores"

    '====================================================================
    ' Name          : strBuscarProveedorInsumosMateriaPrima
    ' Description   : Returns an array of SortedList objects with the records found
    ' Table name    : 
    ' Parameters    : 
    '             
    ' Throws        : Exception
    ' Output        : Array
    '====================================================================
    Public Shared Function strBuscarProveedorInsumosMateriaPrima( _
      ByVal intCompaniaId As Double, _
      ByVal intSucursalId As Double, _
      ByVal strTipoProveedorNombreId As String, _
      ByVal strProveedorNombreId As String, _
      ByVal intTipoVigencia As Double, _
      ByVal intInitialPosition As Double, _
      ByVal intElementsToRetrieve As Double, _
      ByVal strConnectionString As String) As Array

        ' Member identifier
        Const strmThisMemberName As String = "strBuscarProveedorInsumosMateriaPrima"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array

        Try

            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder
            Call strSQLStatement.Append("EXECUTE spBuscarProveedorInsumosMateriaPrima ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strTipoProveedorNombreId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strProveedorNombreId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTipoVigencia)
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
#End Region

    '====================================================================
    ' Name       : strAgregarEditarInsumosMateriaPrima
    ' Description: Agregar o actualizar la compra directa
    '             
    ' Parameters :
    '              ByVal intFacturaId As Integer
    '                  - 
    '              ByVal intProveedorId As Integer
    '                  - 
    '              ByVal intCompaniaId As Integer
    '                  - 
    '              ByVal intSucursalId As Integer
    '                  - 
    '              ByVal intDepartamentoId As Integer
    '                  - 
    '              ByVal dtmFechaRecepcion As Date
    '                  - 
    '              ByVal strCompraDirectaNumeroFactura As String
    '                  - 
    '              ByVal dtmFechaRegistroFactura As Date
    '                  - 
    '              ByVal fltCompraDirectaImporteNetoFactura As Double
    '                  - 
    '              ByVal fltCompraDirectaImporteIvaFactura As Double
    '                  - 
    '              ByVal fltCompraDirectaImporteIvaDescuento As Double
    '                  - 
    '              ByVal fltCompraDirectaImporteDescuentoDespuesIVA As Double
    '                  - 
    '              ByVal fltImporteTotalFactura As Double
    '                  - 
    '              ByVal strUsuarioNombre As String
    '                  -
    '              ByVal fltCompraDirectaImporteIEPS As Double
    '                  - 
    '              ByVal fltImporteDescuentoAntesIVA As Double
    '                  - 
    '              ByVal fltCompraDirectaImporteSumaProductos As Double
    '                  - 
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '====================================================================
    Public Shared Function strAgregarEditarInsumosMateriaPrima( _
       ByVal intFacturaId As Integer, _
       ByVal intProveedorId As Integer, _
       ByVal intCompaniaId As Integer, _
       ByVal intSucursalId As Integer, _
       ByVal dtmFechaRecepcion As Date, _
       ByVal dtmFechaRegistroFactura As Date, _
       ByVal intImpuestoFactura As Integer, _
       ByVal strNumeroFactura As String, _
       ByVal fltImporteNetoFactura As Double, _
       ByVal fltImporteIvaFactura As Double, _
       ByVal fltImporteIvaDescuento As Double, _
       ByVal fltImporteDescuentoDespuesIva As Double, _
       ByVal fltImporteTotalFactura As Double, _
       ByVal fltImporteIEPS As Double, _
       ByVal fltImporteDescuentoAntesIVA As Double, _
       ByVal fltImporteSumaProductos As Double, _
       ByVal strUsuarioNombre As String, _
       ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "strAgregarEditarInsumosMateriaPrima"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Dim objDataArray As Array = Nothing
        Dim strDataRegistro As String() = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spAgregarEditarInsumosMateriaPrima ")

            Call strSQLStatement.Append(intFacturaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intProveedorId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaRecepcion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaRegistroFactura.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intImpuestoFactura)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strNumeroFactura)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltImporteNetoFactura)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltImporteIvaFactura)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltImporteIvaDescuento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltImporteDescuentoDespuesIva)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltImporteTotalFactura)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltImporteIEPS)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltImporteDescuentoAntesIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltImporteSumaProductos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strUsuarioNombre)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            objDataArray = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

            If IsArray(objDataArray) AndAlso objDataArray.Length > 0 Then

                strDataRegistro = DirectCast(objDataArray.GetValue(0), String())
                strAgregarEditarInsumosMateriaPrima = CInt(strDataRegistro(0))

            End If

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
            Dim intCategoryNumber As Short : intCategoryNumber = 0

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
            strSQLStatement = Nothing
            strAgregarEditarInsumosMateriaPrima = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strBuscarFactura
    ' Description: Busca si ya ha sido capturada la factura de Insumos de Materia Prima
    '             
    ' Parameters :
    '               Byval intCompaniaId as Integer   
    '               Byval intSucursalId as Integer 
    '               Byval intProveedorId as Integer 
    '               Byval strFacturaNumero as String         
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer           
    '====================================================================
    Public Shared Function strBuscarFactura(ByVal intCompaniaId As Integer, _
                                                    ByVal intSucursalId As Integer, _
                                                    ByVal intProveedorId As Integer, _
                                                    ByVal strFacturaNumero As String, _
                                                    ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarError"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarEstadoFacturaInsumosMateriaPrima ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(", ")
            Call strSQLStatement.Append(intProveedorId)
            Call strSQLStatement.Append(", '")
            Call strSQLStatement.Append(strFacturaNumero)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strBuscarFactura = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
            Dim intCategoryNumber As Short : intCategoryNumber = 0

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
            strSQLStatement = Nothing
            strBuscarFactura = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : intEliminar
    ' Description: Eliminación de registros.
    '                 - Tabla tblArticuloCompraDirecta
    ' Parameters : 
    '              ByVal intFacturaId As Integer
    '                 - 
    '              ByVal intArticuloId As Integer
    '                 - 
    '              ByVal intArticuloCantidad As Integer
    '                 - 
    '              ByVal fltArticuloCostoCapturado As Double
    '                 - 
    '              ByVal dtmArticuloUltimaModificacion As Date
    '                 - 
    '              ByVal strArticuloModificadoPor As String
    '                 - 
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================
    Public Shared Function intEliminar( _
      ByVal intFacturaId As Integer, _
      ByVal intArticuloId As Integer, _
      ByVal intArticuloCantidad As Integer, _
      ByVal fltArticuloCostoCapturado As Double, _
      ByVal dtmArticuloUltimaModificacion As Date, _
      ByVal strArticuloModificadoPor As String, _
      ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intEliminar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0
        Dim strRegistros As Array = Nothing
        Dim strRowsAffected As String() = Nothing

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spEliminarDetalleInsumosMateriaPrima ")
            Call strSQLStatement.Append(intFacturaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloCantidad)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloCostoCapturado)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloModificadoPor)
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

            ' Notificamos el error
            Throw

        End Try

    End Function

#End Region


#Region "Detalle-Capturar Articulos"

    '====================================================================
    ' Name       : strBuscarArticuloInsumosMateriaPrimaProveedor
    ' Description: Buscar la información de los articulos de una sucursal para un proveedor
    '               para el periodo de cierre
    ' Parameters :
    '               ByVal intCompaniaId As Integer
    '               - Identificador de la compañía
    '               ByVal intSucursalId As Integer
    '               - Identificador de la sucursal
    '               ByVal strArticuloIdNombre As String
    '               - Identificador o descripción de artículos a buscar
    '		ByVal intProveedorId as integer
    '   		ByVal intImpuestoId  as integer
    '   		ByVal intDepartamentoId  as integer
    '   		ByVal intTipoProveedorId  as integer
    '               ByVal intPosicionInicial As Integer
    '               ByVal intElementos As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con el registro leído
    '                Array = { (), (), ..... () }
    '====================================================================
    Public Shared Function strBuscarArticuloInsumosMateriaPrima(ByVal intCompaniaId As Integer, _
                                             ByVal intSucursalId As Integer, _
                                             ByVal strArticuloIdNombre As String, _
                                             ByVal intProveedorId As Integer, _
                                             ByVal strTipoProveedorNombreId As String, _
                                             ByVal intArtiulosCompletos As Integer, _
                                             ByVal intPosicionInicial As Integer, _
                                             ByVal intElementos As Integer, _
                                             ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarArticuloInsumosMateriaPrima"

        ' Declare the local variables
        Dim strSQLStatement As System.Text.StringBuilder
        Dim aobjReturnedData As Array

        Try
            ' Create the SQL statement
            strSQLStatement = New System.Text.StringBuilder

            Call strSQLStatement.Append("EXECUTE spBuscarArticuloProveedorInsumosMateriaPrima ")

            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloIdNombre)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(", ")

            Call strSQLStatement.Append(intProveedorId)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strTipoProveedorNombreId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(", ")

            Call strSQLStatement.Append(intArtiulosCompletos)
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
    ' Name       : intAgregarArticulo
    ' Description: Agregar o actualizar un artículo de compra directa
    '             
    ' Parameters :
    '               ByVal intFacturaId As Integer
    '               ByVal intArticuloId As Integer
    '               ByVal intArticuloFacturaInsumosCantidad AS Integer,
    '               ByVal fltArticuloFacturaInsumosCostoCapturado AS Decimal,
    '               ByVal strUsuarioNombre AS String
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '====================================================================
    Public Shared Function intAgregarArticulo(ByVal intFacturaId As Integer, _
                                              ByVal intArticuloId As Integer, _
                                              ByVal intArticuloFacturaInsumosCantidad As Integer, _
                                              ByVal fltArticuloFacturaInsumosCostoCapturado As Decimal, _
                                              ByVal strUsuarioNombre As String, _
                                              ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intAgregarArticulo"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Dim objDataArray As Array = Nothing
        Dim strDataRegistro As String() = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spAgregarArticuloInsumosMateriaPrima ")

            Call strSQLStatement.Append(intFacturaId)

            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloId)

            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloFacturaInsumosCantidad)

            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltArticuloFacturaInsumosCostoCapturado)

            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(strUsuarioNombre)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            objDataArray = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

            If IsArray(objDataArray) AndAlso objDataArray.Length > 0 Then

                strDataRegistro = DirectCast(objDataArray.GetValue(0), String())
                intAgregarArticulo = CInt(strDataRegistro(0))

            End If

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
            Dim intCategoryNumber As Short : intCategoryNumber = 0

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
            strSQLStatement = Nothing
            intAgregarArticulo = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strBuscarDetalle
    ' Description: Consultar los datos de una insumos de materia prima
    '             
    ' Parameters :
    '               ByVal intCompaniaId As Integer
    '               ByVal intSucursalId As Integer
    '               ByVal intFacturaInsumosId As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                Array = { (intArticuloId, intArticuloCompraDirectaCantidad, fltArticuloCompraDirectaCostoCapturado, Importe, fltArticuloSucursalCostoReposicion, strArticuloDescripcion),
    '                          , ... ,
    '                          (intArticuloId, intArticuloCompraDirectaCantidad, fltArticuloCompraDirectaCostoCapturado, Importe, fltArticuloSucursalCostoReposicion, strArticuloDescripcion), }
    '====================================================================
    Public Shared Function strBuscarDetalle(ByVal intCompaniaId As Integer, _
                                            ByVal intSucursalId As Integer, _
                                            ByVal intFacturaInsumosId As Integer, _
                                            ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarDetalle"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarDetalleInsumosMateriaPrima ")

            Call strSQLStatement.Append(intCompaniaId)

            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)

            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intFacturaInsumosId)

            ' Ejecutamos el comando
            strBuscarDetalle = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
            Dim intCategoryNumber As Short : intCategoryNumber = 0

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
            strSQLStatement = Nothing
            strBuscarDetalle = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : intEliminarArticulo
    ' Description: Eliminar un artículo de compra directa
    '             
    ' Parameters :
    '               ByVal intFacturaId As Integer
    '               ByVal intArticuloId As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '====================================================================
    Public Shared Function intEliminarArticulo(ByVal intFacturaId As Integer, _
                                               ByVal intArticuloId As Integer, _
                                               ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intEliminarArticulo"

        Dim objDataArray As Array = Nothing
        Dim strDataRegistro As String() = Nothing

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spEliminarArticuloInsumosMateriaPrima ")

            Call strSQLStatement.Append(intFacturaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloId)

            ' Ejecutamos el comando
            objDataArray = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

            If IsArray(objDataArray) AndAlso objDataArray.Length > 0 Then

                strDataRegistro = DirectCast(objDataArray.GetValue(0), String())
                intEliminarArticulo = CInt(strDataRegistro(0))

            End If

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
            Dim intCategoryNumber As Short : intCategoryNumber = 0

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
            strSQLStatement = Nothing
            intEliminarArticulo = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : intValidaIVADetalle 
    ' Description: Verifica que el detalle de articulos corresponda al iva indicado
    '             
    ' Parameters :
    '               ByVal intCompaniaId As Integer
    '               ByVal intSucursalId As Integer
    '               ByVal intFacturaId As Integer
    '               ByVal fltIVA As double
    '               ByVal strUsuarioNombre As String
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '====================================================================
    Public Shared Function intValidaIVADetalle(ByVal intCompaniaId As Integer, _
                                               ByVal intSucursalId As Integer, _
                                               ByVal intFacturaId As Integer, _
                                               ByVal fltIVA As Double, _
                                               ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intValidaIVADetalle"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Dim objDataArray As Array = Nothing
        Dim strDataRegistro As String() = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spValidaIvaDetalleInsumosMateriaPrima ")

            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append(intFacturaId)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append(fltIVA)

            ' Ejecutamos el comando
            objDataArray = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

            If IsArray(objDataArray) AndAlso objDataArray.Length > 0 Then

                strDataRegistro = DirectCast(objDataArray.GetValue(0), String())
                intValidaIVADetalle = CInt(strDataRegistro(0))

            End If

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
            Dim intCategoryNumber As Short : intCategoryNumber = 0

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
            strSQLStatement = Nothing
            intValidaIVADetalle = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : intAfectar
    ' Description: Realizar el registro de factura de insumos
    '             
    ' Parameters :
    '               ByVal intCompaniaId As Integer
    '               ByVal intSucursalId As Integer
    '               ByVal intFacturaId As Integer
    '               ByVal intProveedorId As Integer
    '               ByVal strUsuarioNombre As String
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '====================================================================
    Public Shared Function intAfectar(ByVal intCompaniaId As Integer, _
                                        ByVal intSucursalId As Integer, _
                                        ByVal intFacturaId As Integer, _
                                        ByVal intProveedorId As Integer, _
                                        ByVal strUsuarioNombre As String, _
                                        ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intAfectar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Dim objDataArray As Array = Nothing
        Dim strDataRegistro As String() = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spAfectarFacturaInsumosMateriaPrima ")

            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append(intFacturaId)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append(intProveedorId)
            Call strSQLStatement.Append(",")

            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strUsuarioNombre)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            objDataArray = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

            If IsArray(objDataArray) AndAlso objDataArray.Length > 0 Then

                strDataRegistro = DirectCast(objDataArray.GetValue(0), String())
                intAfectar = CInt(strDataRegistro(0))

            End If

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
            Dim intCategoryNumber As Short : intCategoryNumber = 0

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
            strSQLStatement = Nothing
            intAfectar = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

#End Region


#Region "Pantalla de Confirmacion"

    '====================================================================
    ' Name       : strBuscarFacturaInsumos
    ' Description: Búsquedas de factura para confirmar
    '             
    ' Parameters :
    '              ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '====================================================================
    Public Shared Function strBuscarFacturaInsumos(ByVal intCompaniaId As Integer, _
                                                   ByVal intSucursalId As Integer, _
                                                   ByVal intFacturaId As Integer, _
                                                   ByVal intMesBusqueda As Integer, _
                                                   ByVal intOrdenBusqueda As Integer, _
                                                   ByVal strTipoCaptura As String, _
                                                   ByVal intPosicionInicial As Integer, _
                                                   ByVal intElementos As Integer, _
                                                   ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarFacturaInsumos"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarFacturaInsumos ")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intFacturaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMesBusqueda)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intOrdenBusqueda)
            Call strSQLStatement.Append(", '")
            Call strSQLStatement.Append(strTipoCaptura)
            Call strSQLStatement.Append("' ,")
            Call strSQLStatement.Append(intPosicionInicial)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intElementos)

            ' Ejecutamos el comando
            strBuscarFacturaInsumos = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
            Dim intCategoryNumber As Short : intCategoryNumber = 0

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
            strSQLStatement = Nothing
            strBuscarFacturaInsumos = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

#End Region

#Region "Captura Devoluciones"

    '====================================================================
    ' Name       : intAgregarDevolucion
    ' Description: Adición de registros.
    '                  - Tabla tblDevolucion
    ' Parameters : 
    '              ByVal intDevolucionId As Integer
    '                  - 
    '              ByVal intCompaniaId As Integer
    '                  - 
    '              ByVal intSucursalId As Integer
    '                  - 
    '              ByVal intProveedorId As Integer
    '                  - 
    '              ByVal intMotivoDevolucionId As Integer
    '                  - 
    '              ByVal intDepartamentoId As Integer
    '                  - 
    '              ByVal intDevolucionFolio As Integer
    '                  - 
    '              ByVal intDevolucionNumeroDocumento As Integer
    '                  - 
    '              ByVal strDevolucionNumeroFactura As String
    '                  - 
    '              ByVal dtmDevolucionRegistro As Date
    '                  - 
    '              ByVal dtmDevolucionUltimaModificacion As Date
    '                  - 
    '              ByVal strDevolucionModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================
    Public Shared Function intAgregarDevolucion( _
      ByVal intDevolucionId As Integer, _
      ByVal intCompaniaId As Integer, _
      ByVal intSucursalId As Integer, _
      ByVal intProveedorId As Integer, _
      ByVal intMotivoDevolucionId As Integer, _
      ByVal intDepartamentoId As Integer, _
      ByVal intDevolucionFolio As Integer, _
      ByVal intDevolucionNumeroDocumento As Integer, _
      ByVal strDevolucionNumeroFactura As String, _
      ByVal dtmDevolucionRegistro As Date, _
      ByVal dtmDevolucionUltimaModificacion As Date, _
      ByVal strDevolucionModificadoPor As String, _
      ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intAgregarDevolucion"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0
        Dim strRegistros As Array = Nothing
        Dim strRowsAffected As String() = Nothing

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spAgregarDevolucionInsumosMateriaPrima ")
            Call strSQLStatement.Append(intDevolucionId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intProveedorId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMotivoDevolucionId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDepartamentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDevolucionFolio)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDevolucionNumeroDocumento)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strDevolucionNumeroFactura)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmDevolucionRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmDevolucionUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strDevolucionModificadoPor)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            For Each strRowsAffected In strRegistros
                intRowsAffected = CInt(strRowsAffected.GetValue(0))
            Next

            ' Regresamos la información
            strSQLStatement = Nothing
            intAgregarDevolucion = intRowsAffected

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
            intAgregarDevolucion = 0

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : intAgregarArticuloDevolucionInsumosMateriaPrima
    ' Description: Adición de registros.
    '                  - Tabla tblArticuloDevolucionInsumosMateriaPrima
    ' Parameters : 
    '              ByVal intDevolucionId As Integer
    '                  - 
    '              ByVal intArticuloId As Integer
    '                  - 
    '              ByVal intArticuloDevolucionCantidad As Integer
    '                  - 
    '              ByVal dtmArticuloDevolucionUltimaModificacion As Date
    '                  - 
    '              ByVal strArticuloDevolucionModificadoPor As String
    '                  - 
    '              ByVal strConnectionString As String
    '                  - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================
    Public Shared Function intAgregarArticuloDevolucionInsumosMateriaPrima( _
      ByVal intDevolucionId As Integer, _
      ByVal intArticuloId As Integer, _
      ByVal intArticuloDevolucionCantidad As Integer, _
      ByVal dtmArticuloDevolucionUltimaModificacion As Date, _
      ByVal strArticuloDevolucionModificadoPor As String, _
      ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intAgregarArticuloDevolucionInsumosMateriaPrima"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0
        Dim strRegistros As Array = Nothing
        Dim strRowsAffected As String() = Nothing

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spAgregarArticuloDevolucionInsumosMateriaPrima ")
            Call strSQLStatement.Append(intDevolucionId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloDevolucionCantidad)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloDevolucionUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloDevolucionModificadoPor)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            For Each strRowsAffected In strRegistros
                intRowsAffected = CInt(strRowsAffected.GetValue(0))
            Next

            ' Regresamos la información
            strSQLStatement = Nothing
            intAgregarArticuloDevolucionInsumosMateriaPrima = intRowsAffected

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
            intAgregarArticuloDevolucionInsumosMateriaPrima = 0

            ' Notificamos el error
            Throw

        End Try

    End Function


    '====================================================================
    ' Name       : strBuscarDetalleDevolucion
    ' Description: Consultar los datos de una devolución
    '             
    ' Parameters :
    '               ByVal intCompaniaId As Integer
    '               ByVal intSucursalId As Integer
    '               ByVal intDevolucionId As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                Array = { (intArticuloId, intArticuloDevolucionCantidad, strArticuloDescripcion),
    '                          , ... ,
    '                          (intArticuloId, intArticuloDevolucionCantidad, strArticuloDescripcion), }
    '====================================================================
    Public Shared Function strBuscarDetalleDevolucion(ByVal intCompaniaId As Integer, _
                                            ByVal intSucursalId As Integer, _
                                            ByVal intDevolucionId As Integer, _
                                            ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscarDetalleDevolucion"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscarDetalleDevolucionInsumosMateriaPrima ")

            Call strSQLStatement.Append(intCompaniaId)

            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)

            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDevolucionId)

            ' Ejecutamos el comando
            strBuscarDetalleDevolucion = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
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
            Dim intCategoryNumber As Short : intCategoryNumber = 0

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
            strSQLStatement = Nothing
            strBuscarDetalleDevolucion = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : intEliminarArticuloDevolucion
    ' Description: Eliminación de registros.
    '                 - Tabla tblArticuloDevolucion
    ' Parameters : 
    '              ByVal intDevolucionId As Integer
    '                 - 
    '              ByVal intArticuloId As Integer
    '                 - 
    '              ByVal intArticuloDevolucionCantidad As Integer
    '                 - 
    '              ByVal dtmArticuloDevolucionUltimaModificacion As Date
    '                 - 
    '              ByVal strArticuloDevolucionModificadoPor As String
    '                 - 
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================
    Public Shared Function intEliminarArticuloDevolucion( _
      ByVal intDevolucionId As Integer, _
      ByVal intArticuloId As Integer, _
      ByVal intArticuloDevolucionCantidad As Integer, _
      ByVal dtmArticuloDevolucionUltimaModificacion As Date, _
      ByVal strArticuloDevolucionModificadoPor As String, _
      ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intEliminarArticuloDevolucion"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim intRowsAffected As Integer = 0
        Dim strRegistros As Array = Nothing
        Dim strRowsAffected As String() = Nothing

        Try

            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spEliminarArticuloDevolucionInsumosMateriaPrimaInsumos ")
            Call strSQLStatement.Append(intDevolucionId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloDevolucionCantidad)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmArticuloDevolucionUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strArticuloDevolucionModificadoPor)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strRegistros = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            For Each strRowsAffected In strRegistros
                intRowsAffected = CInt(strRowsAffected.GetValue(0))
            Next

            ' Regresamos la información
            strSQLStatement = Nothing
            intEliminarArticuloDevolucion = intRowsAffected

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
            intEliminarArticuloDevolucion = 0

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : intRegistrarDevolucion
    ' Description: Realizar el registro de una devolución
    '             
    ' Parameters :
    '               ByVal intCompaniaId As Integer
    '               ByVal intSucursalId As Integer
    '               ByVal intDevolucionId As Integer
    '               ByVal strUsuarioNombre As String
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                Array = { (),
    '                          , ... ,
    '                          (), }
    '====================================================================
    Public Shared Function intRegistrarDevolucion(ByVal intCompaniaId As Integer, _
                                        ByVal intSucursalId As Integer, _
                                        ByVal intDevolucionId As Integer, _
                                        ByVal strUsuarioNombre As String, _
                                        ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intRegistrarDevolucion"

        ' Variables locales
        Dim strSQLStatement As StringBuilder = Nothing
        Dim objArray As System.Array = Nothing
        Dim strRow As String() = Nothing

        Try
            ' Inicialización de las variables locales
            strSQLStatement = New StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spRegistrarDevolucionInsumosMateriaPrima ")

            Call strSQLStatement.Append(intCompaniaId)

            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)

            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDevolucionId)

            Call strSQLStatement.Append(",'")
            Call strSQLStatement.Append(strUsuarioNombre)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando 
            objArray = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)

            If IsArray(objArray) AndAlso (objArray.Length > 0) Then

                strRow = DirectCast(objArray.GetValue(0), String())
                intRegistrarDevolucion = CInt(strRow(0))

            End If

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
            Dim intCategoryNumber As Short : intCategoryNumber = 0

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
            strSQLStatement = Nothing
            intRegistrarDevolucion = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

#End Region


#Region "Consulta de Devoluciones"

    '====================================================================
    ' Name       : strBuscarDevoluciones
    ' Description: Consultar los datos de una devolución
    '             
    ' Parameters :
    '               ByVal intCompaniaId As Integer
    '               ByVal intSucursalId As Integer
    '               ByVal intDevolucionId As Integer
    '               ByVal intTipoBusqueda As Integer
    '               ByVal intProveedorId As Integer
    '               ByVal dtmFechaInicial As Date
    '               ByVal dtmFechaFinal As Date
    '               ByVal intPosicionInicial As Integer
    '               ByVal intElementos As Integer
    '               ByVal strConnectionString As String
    '              - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '              - Arreglo bidimensional con los registros leídos
    '                Array = { (intDevolucionId, intProveedorId, dtmDevolucionRegistro, intDevolucionFolio, strProveedorRazonSocial, intTotalRegistros),
    '                          , ... ,
    '                          (intDevolucionId, intProveedorId, dtmDevolucionRegistro, intDevolucionFolio, strProveedorRazonSocial, intTotalRegistros), }
    '====================================================================
    'Public Shared Function strBuscarDevoluciones(ByVal intCompaniaId As Integer, _
    '                                 ByVal intSucursalId As Integer, _
    '                                 ByVal intDevolucionId As Integer, _
    '                                 ByVal intTipoBusqueda As Integer, _
    '                                 ByVal intProveedorId As Integer, _
    '                                 ByVal dtmFechaInicial As Date, _
    '                                 ByVal dtmFechaFinal As Date, _
    '                                 ByVal intPosicionInicial As Integer, _
    '                                 ByVal intElementos As Integer, _
    '                                 ByVal strConnectionString As String) As Array

    '    ' Constantes locales
    '    Const strmThisMemberName As String = "strBuscarDevoluciones"

    '    ' Variables locales
    '    Dim strSQLStatement As StringBuilder = Nothing

    '    Try
    '        ' Inicialización de las variables locales
    '        strSQLStatement = New StringBuilder

    '        ' Creamos estatuto de SQL
    '        Call strSQLStatement.Append("EXECUTE spBuscarDevolucionInsumosMateriaPrima ")

    '        Call strSQLStatement.Append(intCompaniaId)

    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(intSucursalId)

    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(intDevolucionId)

    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(intTipoBusqueda)

    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(intProveedorId)

    '        Call strSQLStatement.Append(",'")
    '        Call strSQLStatement.Append(dtmFechaInicial.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
    '        Call strSQLStatement.Append("'")

    '        Call strSQLStatement.Append(",'")
    '        Call strSQLStatement.Append(dtmFechaFinal.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
    '        Call strSQLStatement.Append("'")

    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(intPosicionInicial)

    '        Call strSQLStatement.Append(",")
    '        Call strSQLStatement.Append(intElementos)

    '        ' Ejecutamos el comando
    '        strBuscarDevoluciones = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
    '        strSQLStatement = Nothing

    '    Catch objException As Exception

    '        ' Variables locales
    '        Dim strErrorString As StringBuilder : strErrorString = New StringBuilder
    '        Dim objApplicationEventLog As System.Diagnostics.EventLog : objApplicationEventLog = New System.Diagnostics.EventLog
    '        Dim strProductName As String : strProductName = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
    '        Dim strApplicationName As String : strApplicationName = System.Reflection.Assembly.GetExecutingAssembly.Location
    '        Dim strVersion As String : strVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
    '        Dim strSource As String : strSource = objException.Source
    '        Dim strMessage As String : strMessage = objException.Message
    '        Dim strStackTrace As String : strStackTrace = objException.StackTrace
    '        Dim intLineNumber As Integer : intLineNumber = Erl()
    '        Dim intErrorNumber As Integer : intErrorNumber = Err.Number
    '        Dim intCategoryNumber As Short : intCategoryNumber = 0

    '        ' Creamos el mensaje de error
    '        Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Application name:" & vbCrLf & vbTab & strApplicationName & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Version:" & vbCrLf & vbTab & strVersion & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Source:" & vbCrLf & vbTab & strSource & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(intErrorNumber) & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Line number:" & vbCrLf & vbTab & intLineNumber & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("Message:" & vbCrLf & vbTab & strMessage & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("SQLStatement:" & vbCrLf & vbTab & strSQLStatement.ToString() & vbCrLf & vbCrLf)
    '        Call strErrorString.Append("StackTrace:" & vbCrLf & strStackTrace & vbCrLf & vbCrLf)

    '        ' Creamos un evento para registrar el mensaje de error
    '        If Not EventLog.SourceExists(strProductName) Then

    '            Call EventLog.CreateEventSource(strProductName, "Application")

    '        End If

    '        ' Establecemos la fuente del evento
    '        objApplicationEventLog.Source = strProductName

    '        ' Escribimos el evento en el Visor de Eventos
    '        Call objApplicationEventLog.WriteEntry(strErrorString.ToString(), EventLogEntryType.Error, Err.Number, intCategoryNumber)

    '        ' Regresamos la información
    '        strSQLStatement = Nothing
    '        strBuscarDevoluciones = Nothing

    '        ' Notificamos el error
    '        Throw

    '    End Try

    'End Function

#End Region


End Class
