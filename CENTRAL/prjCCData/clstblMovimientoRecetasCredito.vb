
Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clstblMovimientoRecetasCredito
' Title         : SP
' Description   : Store Procedure Mantenimiento Datos
' Copyright     : 2004 Todos los Derechos Reservados.
' Company       : Benavides
' Author        : Dirección de Tecnología
' Version       : 1.0
' Last Modified : Martes, 10 de Agosto de 2004
'====================================================================
Public NotInheritable Class clstblMovimientoRecetasCredito

    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.CC.Data.clstblMovimientoRecetasCredito"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()
    End Sub

    '====================================================================
    ' Name       : intActualizar
    ' Description: Actualización de registros.
    '                 - Tabla tblMovimientoRecetasCredito
    ' Parameters : 
    '              ByVal intMovimientoRecetasCreditoId As Double
    '                 - 
    '              ByVal intCompaniaId As Double
    '                 - 
    '              ByVal intSucursalId As Double
    '                 - 
    '              ByVal intCajaId As Double
    '                 - 
    '              ByVal intEmpleadoId As Double
    '                 - 
    '              ByVal intTurnoLaboralId As Double
    '                 - 
    '              ByVal intAsignacionCajaId As Double
    '                 - 
    '              ByVal intTicketId As Double
    '                 - 
    '              ByVal dtmHoraRegistro As Date
    '                 - 
    '              ByVal dtmFechaRegistro As Date
    '                 - 
    '              ByVal intMovimientoRecetasCreditoTipoClienteId As Double
    '                 - 
    '              ByVal dtmMovimientoRecetasCreditoOperacion As Date
    '                 - 
    '              ByVal strMovimientoRecetasCreditoClienteId As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoReceta As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoDoctor As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoEmpleado As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoFamilia As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoClinica As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoClaveAutorizacion As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoClavePadecimiento As String
    '                 - 
    '              ByVal intDepartamentoId As Double
    '                 - 
    '              ByVal intArticuloId As Double
    '                 - 
    '              ByVal intMovimientoRecetasCreditoCantidadArticulos As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoPrecioNormalSINImpuesto As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteDelDescuentoSINImpuesto As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoPorcentajeIVA As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteDelIVA As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteCopago As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoPorcentajeIEPS As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteIEPS As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoPrecioNormalConImpuesto As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteDelDescuentoConImpuesto As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteVentaConImpuesto As Double
    '                 - 
    '              ByVal dtmMovimientoRecetasCreditoUltimaModificacion As Date
    '                 - 
    '              ByVal strMovimientoRecetasCreditoModificadoPor As String
    '                 - Stk Winston Data - 29/10/2008 vcsg  - Nuevo campo Id Empleado Supervisor      
    '              ByVal intMovimientoRecetasCreditoEmpleadoAutorizaId As Double
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================
    Shared Function intActualizar( _
                ByVal intMovimientoRecetasCreditoId As Double, _
                ByVal intCompaniaId As Double, _
                ByVal intSucursalId As Double, _
                ByVal intCajaId As Double, _
                ByVal intEmpleadoId As Double, _
                ByVal intTurnoLaboralId As Double, _
                ByVal intAsignacionCajaId As Double, _
                ByVal intTicketId As Double, _
                ByVal dtmHoraRegistro As Date, _
                ByVal dtmFechaRegistro As Date, _
                ByVal intMovimientoRecetasCreditoTipoClienteId As Double, _
                ByVal dtmMovimientoRecetasCreditoOperacion As Date, _
                ByVal strMovimientoRecetasCreditoClienteId As String, _
                ByVal strMovimientoRecetasCreditoReceta As String, _
                ByVal strMovimientoRecetasCreditoDoctor As String, _
                ByVal strMovimientoRecetasCreditoEmpleado As String, _
                ByVal strMovimientoRecetasCreditoFamilia As String, _
                ByVal strMovimientoRecetasCreditoClinica As String, _
                ByVal strMovimientoRecetasCreditoClaveAutorizacion As String, _
                ByVal strMovimientoRecetasCreditoClavePadecimiento As String, _
                ByVal intDepartamentoId As Double, _
                ByVal intArticuloId As Double, _
                ByVal intMovimientoRecetasCreditoCantidadArticulos As Double, _
                ByVal fltMovimientoRecetasCreditoPrecioNormalSINImpuesto As Double, _
                ByVal fltMovimientoRecetasCreditoImporteDelDescuentoSINImpuesto As Double, _
                ByVal fltMovimientoRecetasCreditoPorcentajeIVA As Double, _
                ByVal fltMovimientoRecetasCreditoImporteDelIVA As Double, _
                ByVal fltMovimientoRecetasCreditoImporteCopago As Double, _
                ByVal fltMovimientoRecetasCreditoPorcentajeIEPS As Double, _
                ByVal fltMovimientoRecetasCreditoImporteIEPS As Double, _
                ByVal fltMovimientoRecetasCreditoPrecioNormalConImpuesto As Double, _
                ByVal fltMovimientoRecetasCreditoImporteDelDescuentoConImpuesto As Double, _
                ByVal fltMovimientoRecetasCreditoImporteVentaConImpuesto As Double, _
                ByVal dtmMovimientoRecetasCreditoUltimaModificacion As Date, _
                ByVal strMovimientoRecetasCreditoModificadoPor As String, _
                ByVal intMovimientoRecetasCreditoEmpleadoAutorizaId As Double, _
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
            Call strSQLStatement.Append("EXECUTE spActualizartblMovimientoRecetasCredito ")
            Call strSQLStatement.Append(intMovimientoRecetasCreditoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTurnoLaboralId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intAsignacionCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmHoraRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoRecetasCreditoTipoClienteId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoRecetasCreditoOperacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoClienteId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoReceta)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoDoctor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoEmpleado)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoFamilia)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoClinica)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoClaveAutorizacion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoClavePadecimiento)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDepartamentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoRecetasCreditoCantidadArticulos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoPrecioNormalSINImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteDelDescuentoSINImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoPorcentajeIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteDelIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoPorcentajeIEPS)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteIEPS)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoPrecioNormalConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteDelDescuentoConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteVentaConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoRecetasCreditoUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoModificadoPor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoRecetasCreditoEmpleadoAutorizaId)

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

            ' Notificamos el error
            Throw


        End Try

    End Function

    '====================================================================
    ' Name       : intAgregar
    ' Description: Adición de registros.
    '                  - Tabla tblMovimientoRecetasCredito
    ' Parameters : 
    '              ByVal intMovimientoRecetasCreditoId As Double
    '                  - 
    '              ByVal intCompaniaId As Double
    '                  - 
    '              ByVal intSucursalId As Double
    '                  - 
    '              ByVal intCajaId As Double
    '                  - 
    '              ByVal intEmpleadoId As Double
    '                  - 
    '              ByVal intTurnoLaboralId As Double
    '                  - 
    '              ByVal intAsignacionCajaId As Double
    '                  - 
    '              ByVal intTicketId As Double
    '                  - 
    '              ByVal dtmHoraRegistro As Date
    '                  - 
    '              ByVal dtmFechaRegistro As Date
    '                  - 
    '              ByVal intMovimientoRecetasCreditoTipoClienteId As Double
    '                  - 
    '              ByVal dtmMovimientoRecetasCreditoOperacion As Date
    '                  - 
    '              ByVal strMovimientoRecetasCreditoClienteId As String
    '                  - 
    '              ByVal strMovimientoRecetasCreditoReceta As String
    '                  - 
    '              ByVal strMovimientoRecetasCreditoDoctor As String
    '                  - 
    '              ByVal strMovimientoRecetasCreditoEmpleado As String
    '                  - 
    '              ByVal strMovimientoRecetasCreditoFamilia As String
    '                  - 
    '              ByVal strMovimientoRecetasCreditoClinica As String
    '                  - 
    '              ByVal strMovimientoRecetasCreditoClaveAutorizacion As String
    '                  - 
    '              ByVal strMovimientoRecetasCreditoClavePadecimiento As String
    '                  - 
    '              ByVal intDepartamentoId As Double
    '                  - 
    '              ByVal intArticuloId As Double
    '                  - 
    '              ByVal intMovimientoRecetasCreditoCantidadArticulos As Double
    '                  - 
    '              ByVal fltMovimientoRecetasCreditoPrecioNormalSINImpuesto As Double
    '                  - 
    '              ByVal fltMovimientoRecetasCreditoImporteDelDescuentoSINImpuesto As Double
    '                  - 
    '              ByVal fltMovimientoRecetasCreditoPorcentajeIVA As Double
    '                  - 
    '              ByVal fltMovimientoRecetasCreditoImporteDelIVA As Double
    '                  - 
    '              ByVal fltMovimientoRecetasCreditoImporteCopago As Double
    '                  - 
    '              ByVal fltMovimientoRecetasCreditoPorcentajeIEPS As Double
    '                  - 
    '              ByVal fltMovimientoRecetasCreditoImporteIEPS As Double
    '                  - 
    '              ByVal fltMovimientoRecetasCreditoPrecioNormalConImpuesto As Double
    '                  - 
    '              ByVal fltMovimientoRecetasCreditoImporteDelDescuentoConImpuesto As Double
    '                  - 
    '              ByVal fltMovimientoRecetasCreditoImporteVentaConImpuesto As Double
    '                  - 
    '              ByVal dtmMovimientoRecetasCreditoUltimaModificacion As Date
    '                  - 
    '              ByVal strMovimientoRecetasCreditoModificadoPor As String
    '                 - Stk Winston Data - 29/10/2008 vcsg  - Nuevo campo Id Empleado Supervisor      
    '              ByVal intMovimientoRecetasCreditoEmpleadoAutorizaId As Double
    '                  -       
    '              ByVal strConnectionString As String
    '                  - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================        
    Shared Function intAgregar( _
                ByVal intMovimientoRecetasCreditoId As Double, _
                ByVal intCompaniaId As Double, _
                ByVal intSucursalId As Double, _
                ByVal intCajaId As Double, _
                ByVal intEmpleadoId As Double, _
                ByVal intTurnoLaboralId As Double, _
                ByVal intAsignacionCajaId As Double, _
                ByVal intTicketId As Double, _
                ByVal dtmHoraRegistro As Date, _
                ByVal dtmFechaRegistro As Date, _
                ByVal intMovimientoRecetasCreditoTipoClienteId As Double, _
                ByVal dtmMovimientoRecetasCreditoOperacion As Date, _
                ByVal strMovimientoRecetasCreditoClienteId As String, _
                ByVal strMovimientoRecetasCreditoReceta As String, _
                ByVal strMovimientoRecetasCreditoDoctor As String, _
                ByVal strMovimientoRecetasCreditoEmpleado As String, _
                ByVal strMovimientoRecetasCreditoFamilia As String, _
                ByVal strMovimientoRecetasCreditoClinica As String, _
                ByVal strMovimientoRecetasCreditoClaveAutorizacion As String, _
                ByVal strMovimientoRecetasCreditoClavePadecimiento As String, _
                ByVal intDepartamentoId As Double, _
                ByVal intArticuloId As Double, _
                ByVal intMovimientoRecetasCreditoCantidadArticulos As Double, _
                ByVal fltMovimientoRecetasCreditoPrecioNormalSINImpuesto As Double, _
                ByVal fltMovimientoRecetasCreditoImporteDelDescuentoSINImpuesto As Double, _
                ByVal fltMovimientoRecetasCreditoPorcentajeIVA As Double, _
                ByVal fltMovimientoRecetasCreditoImporteDelIVA As Double, _
                ByVal fltMovimientoRecetasCreditoImporteCopago As Double, _
                ByVal fltMovimientoRecetasCreditoPorcentajeIEPS As Double, _
                ByVal fltMovimientoRecetasCreditoImporteIEPS As Double, _
                ByVal fltMovimientoRecetasCreditoPrecioNormalConImpuesto As Double, _
                ByVal fltMovimientoRecetasCreditoImporteDelDescuentoConImpuesto As Double, _
                ByVal fltMovimientoRecetasCreditoImporteVentaConImpuesto As Double, _
                ByVal dtmMovimientoRecetasCreditoUltimaModificacion As Date, _
                ByVal strMovimientoRecetasCreditoModificadoPor As String, _
                ByVal intMovimientoRecetasCreditoEmpleadoAutorizaId As Double, _
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
            Call strSQLStatement.Append("EXECUTE spAgregartblMovimientoRecetasCredito ")
            Call strSQLStatement.Append(intMovimientoRecetasCreditoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTurnoLaboralId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intAsignacionCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmHoraRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoRecetasCreditoTipoClienteId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoRecetasCreditoOperacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoClienteId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoReceta)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoDoctor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoEmpleado)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoFamilia)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoClinica)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoClaveAutorizacion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoClavePadecimiento)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDepartamentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoRecetasCreditoCantidadArticulos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoPrecioNormalSINImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteDelDescuentoSINImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoPorcentajeIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteDelIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoPorcentajeIEPS)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteIEPS)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoPrecioNormalConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteDelDescuentoConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteVentaConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoRecetasCreditoUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoModificadoPor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoRecetasCreditoEmpleadoAutorizaId)

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
    ' Name       : strBuscar
    ' Description: Búsqueda de registros.
    '                 - Tabla tblMovimientoRecetasCredito
    ' Parameters : 
    '              ByVal intMovimientoRecetasCreditoId As Double
    '                 - 
    '              ByVal intCompaniaId As Double
    '                 - 
    '              ByVal intSucursalId As Double
    '                 - 
    '              ByVal intCajaId As Double
    '                 - 
    '              ByVal intEmpleadoId As Double
    '                 - 
    '              ByVal intTurnoLaboralId As Double
    '                 - 
    '              ByVal intAsignacionCajaId As Double
    '                 - 
    '              ByVal intTicketId As Double
    '                 - 
    '              ByVal dtmHoraRegistro As Date
    '                 - 
    '              ByVal dtmFechaRegistro As Date
    '                 - 
    '              ByVal intMovimientoRecetasCreditoTipoClienteId As Double
    '                 - 
    '              ByVal dtmMovimientoRecetasCreditoOperacion As Date
    '                 - 
    '              ByVal strMovimientoRecetasCreditoClienteId As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoReceta As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoDoctor As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoEmpleado As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoFamilia As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoClinica As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoClaveAutorizacion As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoClavePadecimiento As String
    '                 - 
    '              ByVal intDepartamentoId As Double
    '                 - 
    '              ByVal intArticuloId As Double
    '                 - 
    '              ByVal intMovimientoRecetasCreditoCantidadArticulos As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoPrecioNormalSINImpuesto As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteDelDescuentoSINImpuesto As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoPorcentajeIVA As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteDelIVA As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteCopago As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoPorcentajeIEPS As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteIEPS As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoPrecioNormalConImpuesto As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteDelDescuentoConImpuesto As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteVentaConImpuesto As Double
    '                 - 
    '              ByVal dtmMovimientoRecetasCreditoUltimaModificacion As Date
    '                 - 
    '              ByVal strMovimientoRecetasCreditoModificadoPor As String
    '                 - Stk Winston Data - 29/10/2008 vcsg  - Nuevo campo Id Empleado Supervisor      
    '              ByVal intMovimientoRecetasCreditoEmpleadoAutorizaId As Double
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
            ByVal intMovimientoRecetasCreditoId As Double, _
            ByVal intCompaniaId As Double, _
            ByVal intSucursalId As Double, _
            ByVal intCajaId As Double, _
            ByVal intEmpleadoId As Double, _
            ByVal intTurnoLaboralId As Double, _
            ByVal intAsignacionCajaId As Double, _
            ByVal intTicketId As Double, _
            ByVal dtmHoraRegistro As Date, _
            ByVal dtmFechaRegistro As Date, _
            ByVal intMovimientoRecetasCreditoTipoClienteId As Double, _
            ByVal dtmMovimientoRecetasCreditoOperacion As Date, _
            ByVal strMovimientoRecetasCreditoClienteId As String, _
            ByVal strMovimientoRecetasCreditoReceta As String, _
            ByVal strMovimientoRecetasCreditoDoctor As String, _
            ByVal strMovimientoRecetasCreditoEmpleado As String, _
            ByVal strMovimientoRecetasCreditoFamilia As String, _
            ByVal strMovimientoRecetasCreditoClinica As String, _
            ByVal strMovimientoRecetasCreditoClaveAutorizacion As String, _
            ByVal strMovimientoRecetasCreditoClavePadecimiento As String, _
            ByVal intDepartamentoId As Double, _
            ByVal intArticuloId As Double, _
            ByVal intMovimientoRecetasCreditoCantidadArticulos As Double, _
            ByVal fltMovimientoRecetasCreditoPrecioNormalSINImpuesto As Double, _
            ByVal fltMovimientoRecetasCreditoImporteDelDescuentoSINImpuesto As Double, _
            ByVal fltMovimientoRecetasCreditoPorcentajeIVA As Double, _
            ByVal fltMovimientoRecetasCreditoImporteDelIVA As Double, _
            ByVal fltMovimientoRecetasCreditoImporteCopago As Double, _
            ByVal fltMovimientoRecetasCreditoPorcentajeIEPS As Double, _
            ByVal fltMovimientoRecetasCreditoImporteIEPS As Double, _
            ByVal fltMovimientoRecetasCreditoPrecioNormalConImpuesto As Double, _
            ByVal fltMovimientoRecetasCreditoImporteDelDescuentoConImpuesto As Double, _
            ByVal fltMovimientoRecetasCreditoImporteVentaConImpuesto As Double, _
            ByVal dtmMovimientoRecetasCreditoUltimaModificacion As Date, _
            ByVal strMovimientoRecetasCreditoModificadoPor As String, _
            ByVal intMovimientoRecetasCreditoEmpleadoAutorizaId As Double, _
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
            Call strSQLStatement.Append("EXECUTE spBuscartblMovimientoRecetasCredito ")
            Call strSQLStatement.Append(intMovimientoRecetasCreditoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTurnoLaboralId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intAsignacionCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmHoraRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoRecetasCreditoTipoClienteId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoRecetasCreditoOperacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoClienteId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoReceta)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoDoctor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoEmpleado)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoFamilia)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoClinica)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoClaveAutorizacion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoClavePadecimiento)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDepartamentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoRecetasCreditoCantidadArticulos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoPrecioNormalSINImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteDelDescuentoSINImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoPorcentajeIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteDelIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoPorcentajeIEPS)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteIEPS)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoPrecioNormalConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteDelDescuentoConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteVentaConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoRecetasCreditoUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoModificadoPor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoRecetasCreditoEmpleadoAutorizaId)
            Call strSQLStatement.Append(",")
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

            ' Notificamos el error
            Throw


        End Try

    End Function

    '====================================================================
    ' Name       : intContar
    ' Description: Contar los registros.
    '                 - Tabla tblMovimientoRecetasCredito
    ' Parameters : 
    '              ByVal intMovimientoRecetasCreditoId As Double
    '                 - 
    '              ByVal intCompaniaId As Double
    '                 - 
    '              ByVal intSucursalId As Double
    '                 - 
    '              ByVal intCajaId As Double
    '                 - 
    '              ByVal intEmpleadoId As Double
    '                 - 
    '              ByVal intTurnoLaboralId As Double
    '                 - 
    '              ByVal intAsignacionCajaId As Double
    '                 - 
    '              ByVal intTicketId As Double
    '                 - 
    '              ByVal dtmHoraRegistro As Date
    '                 - 
    '              ByVal dtmFechaRegistro As Date
    '                 - 
    '              ByVal intMovimientoRecetasCreditoTipoClienteId As Double
    '                 - 
    '              ByVal dtmMovimientoRecetasCreditoOperacion As Date
    '                 - 
    '              ByVal strMovimientoRecetasCreditoClienteId As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoReceta As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoDoctor As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoEmpleado As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoFamilia As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoClinica As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoClaveAutorizacion As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoClavePadecimiento As String
    '                 - 
    '              ByVal intDepartamentoId As Double
    '                 - 
    '              ByVal intArticuloId As Double
    '                 - 
    '              ByVal intMovimientoRecetasCreditoCantidadArticulos As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoPrecioNormalSINImpuesto As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteDelDescuentoSINImpuesto As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoPorcentajeIVA As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteDelIVA As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteCopago As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoPorcentajeIEPS As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteIEPS As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoPrecioNormalConImpuesto As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteDelDescuentoConImpuesto As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteVentaConImpuesto As Double
    '                 - 
    '              ByVal dtmMovimientoRecetasCreditoUltimaModificacion As Date
    '                 - 
    '              ByVal strMovimientoRecetasCreditoModificadoPor As String
    '                 - Stk Winston Data - 29/10/2008 vcsg  - Nuevo campo Id Empleado Supervisor      
    '              ByVal intMovimientoRecetasCreditoEmpleadoAutorizaId As Double
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros en la tabla
    '====================================================================
    Shared Function intContar( _
            ByVal intMovimientoRecetasCreditoId As Double, _
            ByVal intCompaniaId As Double, _
            ByVal intSucursalId As Double, _
            ByVal intCajaId As Double, _
            ByVal intEmpleadoId As Double, _
            ByVal intTurnoLaboralId As Double, _
            ByVal intAsignacionCajaId As Double, _
            ByVal intTicketId As Double, _
            ByVal dtmHoraRegistro As Date, _
            ByVal dtmFechaRegistro As Date, _
            ByVal intMovimientoRecetasCreditoTipoClienteId As Double, _
            ByVal dtmMovimientoRecetasCreditoOperacion As Date, _
            ByVal strMovimientoRecetasCreditoClienteId As String, _
            ByVal strMovimientoRecetasCreditoReceta As String, _
            ByVal strMovimientoRecetasCreditoDoctor As String, _
            ByVal strMovimientoRecetasCreditoEmpleado As String, _
            ByVal strMovimientoRecetasCreditoFamilia As String, _
            ByVal strMovimientoRecetasCreditoClinica As String, _
            ByVal strMovimientoRecetasCreditoClaveAutorizacion As String, _
            ByVal strMovimientoRecetasCreditoClavePadecimiento As String, _
            ByVal intDepartamentoId As Double, _
            ByVal intArticuloId As Double, _
            ByVal intMovimientoRecetasCreditoCantidadArticulos As Double, _
            ByVal fltMovimientoRecetasCreditoPrecioNormalSINImpuesto As Double, _
            ByVal fltMovimientoRecetasCreditoImporteDelDescuentoSINImpuesto As Double, _
            ByVal fltMovimientoRecetasCreditoPorcentajeIVA As Double, _
            ByVal fltMovimientoRecetasCreditoImporteDelIVA As Double, _
            ByVal fltMovimientoRecetasCreditoImporteCopago As Double, _
            ByVal fltMovimientoRecetasCreditoPorcentajeIEPS As Double, _
            ByVal fltMovimientoRecetasCreditoImporteIEPS As Double, _
            ByVal fltMovimientoRecetasCreditoPrecioNormalConImpuesto As Double, _
            ByVal fltMovimientoRecetasCreditoImporteDelDescuentoConImpuesto As Double, _
            ByVal fltMovimientoRecetasCreditoImporteVentaConImpuesto As Double, _
            ByVal dtmMovimientoRecetasCreditoUltimaModificacion As Date, _
            ByVal strMovimientoRecetasCreditoModificadoPor As String, _
            ByVal intMovimientoRecetasCreditoEmpleadoAutorizaId As Double, _
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
            Call strSQLStatement.Append("EXECUTE spContartblMovimientoRecetasCredito ")
            Call strSQLStatement.Append(intMovimientoRecetasCreditoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTurnoLaboralId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intAsignacionCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmHoraRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoRecetasCreditoTipoClienteId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoRecetasCreditoOperacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoClienteId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoReceta)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoDoctor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoEmpleado)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoFamilia)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoClinica)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoClaveAutorizacion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoClavePadecimiento)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDepartamentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoRecetasCreditoCantidadArticulos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoPrecioNormalSINImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteDelDescuentoSINImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoPorcentajeIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteDelIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoPorcentajeIEPS)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteIEPS)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoPrecioNormalConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteDelDescuentoConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteVentaConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoRecetasCreditoUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoModificadoPor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoRecetasCreditoEmpleadoAutorizaId)

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

            ' Notificamos el error
            Throw


        End Try

    End Function


    '====================================================================
    ' Name       : intEliminar
    ' Description: Eliminación de registros.
    '                 - Tabla tblMovimientoRecetasCredito
    ' Parameters : 
    '              ByVal intMovimientoRecetasCreditoId As Double
    '                 - 
    '              ByVal intCompaniaId As Double
    '                 - 
    '              ByVal intSucursalId As Double
    '                 - 
    '              ByVal intCajaId As Double
    '                 - 
    '              ByVal intEmpleadoId As Double
    '                 - 
    '              ByVal intTurnoLaboralId As Double
    '                 - 
    '              ByVal intAsignacionCajaId As Double
    '                 - 
    '              ByVal intTicketId As Double
    '                 - 
    '              ByVal dtmHoraRegistro As Date
    '                 - 
    '              ByVal dtmFechaRegistro As Date
    '                 - 
    '              ByVal intMovimientoRecetasCreditoTipoClienteId As Double
    '                 - 
    '              ByVal dtmMovimientoRecetasCreditoOperacion As Date
    '                 - 
    '              ByVal strMovimientoRecetasCreditoClienteId As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoReceta As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoDoctor As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoEmpleado As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoFamilia As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoClinica As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoClaveAutorizacion As String
    '                 - 
    '              ByVal strMovimientoRecetasCreditoClavePadecimiento As String
    '                 - 
    '              ByVal intDepartamentoId As Double
    '                 - 
    '              ByVal intArticuloId As Double
    '                 - 
    '              ByVal intMovimientoRecetasCreditoCantidadArticulos As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoPrecioNormalSINImpuesto As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteDelDescuentoSINImpuesto As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoPorcentajeIVA As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteDelIVA As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteCopago As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoPorcentajeIEPS As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteIEPS As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoPrecioNormalConImpuesto As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteDelDescuentoConImpuesto As Double
    '                 - 
    '              ByVal fltMovimientoRecetasCreditoImporteVentaConImpuesto As Double
    '                 - 
    '              ByVal dtmMovimientoRecetasCreditoUltimaModificacion As Date
    '                 - 
    '              ByVal strMovimientoRecetasCreditoModificadoPor As String
    '                 - Stk Winston Data - 29/10/2008 vcsg  - Nuevo campo Id Empleado Supervisor      
    '              ByVal intMovimientoRecetasCreditoEmpleadoAutorizaId As Double
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================        
    Shared Function intEliminar( _
            ByVal intMovimientoRecetasCreditoId As Double, _
            ByVal intCompaniaId As Double, _
            ByVal intSucursalId As Double, _
            ByVal intCajaId As Double, _
            ByVal intEmpleadoId As Double, _
            ByVal intTurnoLaboralId As Double, _
            ByVal intAsignacionCajaId As Double, _
            ByVal intTicketId As Double, _
            ByVal dtmHoraRegistro As Date, _
            ByVal dtmFechaRegistro As Date, _
            ByVal intMovimientoRecetasCreditoTipoClienteId As Double, _
            ByVal dtmMovimientoRecetasCreditoOperacion As Date, _
            ByVal strMovimientoRecetasCreditoClienteId As String, _
            ByVal strMovimientoRecetasCreditoReceta As String, _
            ByVal strMovimientoRecetasCreditoDoctor As String, _
            ByVal strMovimientoRecetasCreditoEmpleado As String, _
            ByVal strMovimientoRecetasCreditoFamilia As String, _
            ByVal strMovimientoRecetasCreditoClinica As String, _
            ByVal strMovimientoRecetasCreditoClaveAutorizacion As String, _
            ByVal strMovimientoRecetasCreditoClavePadecimiento As String, _
            ByVal intDepartamentoId As Double, _
            ByVal intArticuloId As Double, _
            ByVal intMovimientoRecetasCreditoCantidadArticulos As Double, _
            ByVal fltMovimientoRecetasCreditoPrecioNormalSINImpuesto As Double, _
            ByVal fltMovimientoRecetasCreditoImporteDelDescuentoSINImpuesto As Double, _
            ByVal fltMovimientoRecetasCreditoPorcentajeIVA As Double, _
            ByVal fltMovimientoRecetasCreditoImporteDelIVA As Double, _
            ByVal fltMovimientoRecetasCreditoImporteCopago As Double, _
            ByVal fltMovimientoRecetasCreditoPorcentajeIEPS As Double, _
            ByVal fltMovimientoRecetasCreditoImporteIEPS As Double, _
            ByVal fltMovimientoRecetasCreditoPrecioNormalConImpuesto As Double, _
            ByVal fltMovimientoRecetasCreditoImporteDelDescuentoConImpuesto As Double, _
            ByVal fltMovimientoRecetasCreditoImporteVentaConImpuesto As Double, _
            ByVal dtmMovimientoRecetasCreditoUltimaModificacion As Date, _
            ByVal strMovimientoRecetasCreditoModificadoPor As String, _
            ByVal intMovimientoRecetasCreditoEmpleadoAutorizaId As Double, _
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
            Call strSQLStatement.Append("EXECUTE spEliminartblMovimientoRecetasCredito ")
            Call strSQLStatement.Append(intMovimientoRecetasCreditoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCompaniaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intSucursalId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpleadoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTurnoLaboralId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intAsignacionCajaId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmHoraRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFechaRegistro.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoRecetasCreditoTipoClienteId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoRecetasCreditoOperacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoClienteId)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoReceta)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoDoctor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoEmpleado)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoFamilia)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoClinica)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoClaveAutorizacion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoClavePadecimiento)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intDepartamentoId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intArticuloId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoRecetasCreditoCantidadArticulos)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoPrecioNormalSINImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteDelDescuentoSINImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoPorcentajeIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteDelIVA)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteCopago)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoPorcentajeIEPS)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteIEPS)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoPrecioNormalConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteDelDescuentoConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltMovimientoRecetasCreditoImporteVentaConImpuesto)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmMovimientoRecetasCreditoUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strMovimientoRecetasCreditoModificadoPor)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intMovimientoRecetasCreditoEmpleadoAutorizaId)

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
