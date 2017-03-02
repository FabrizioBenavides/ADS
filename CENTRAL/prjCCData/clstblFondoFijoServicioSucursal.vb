
Imports System.Text
Imports Benavides.Data.SQL.MSSQL

'====================================================================
' Class         : clstblFondoFijoServicioSucursal
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Datos
' Copyright     : 2010 Todos los Derechos Reservados.
' Company       : Softtek
' Author        : Cesar Ortiz
' Version       : 1.0
' Last Modified : Martes, 28 de Diciembre, 2010
'====================================================================
Public Class clstblFondoFijoServicioSucursal

    ' Identificador de la clase
    Private Const strmThisClassName As String = "Benavides.AdminPOS.Data.clstblFondoFijoServicioSucursal"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()

    End Sub

    '====================================================================
    ' Name       : intActualizar
    ' Description: Actualización de registros.
    '                 - Tabla tblFondoFijoServicioSucursal
    ' Parameters : 
    '              ByVal intCompaniaId As Integer
    '                 - 
    '              ByVal intSucursalId As Integer
    '                 - 
    '              ByVal intTipoTicketId As Integer
    '                 - 
    '              ByVal intCajaId As Integer
    '                 - 
    '              ByVal intEmpleadoId As Integer
    '                 - 
    '              ByVal intEstadoOperativoCajaId As Integer
    '                 - 
    '              ByVal intTurnoLaboralId As Integer
    '                 - 
    '              ByVal intAsignacionCajaId As Integer
    '
    '              ByVal intTicketId As Integer
    '                 - 
    '              ByVal intPagoServicioTicketId As Integer
    '                 - 
    '              ByVal intEmpresaServicioId As Integer
    '                 -
    '              ByVal strEmpresaServicioPagoAutorizacion As String
    '                 - 
    '              ByVal intFondoFijoServicioSucursalEmpleadoAutorizo As Integer
    '
    '              ByVal fltEmpresaServicioPagoImporte As Double
    '                 - 
    '              ByVal fltEmpresaServicioPagoImporte As Double
    '                 - 
    '              ByVal strEmpresaServicioPagoReferencia As String
    '                 -
    '              ByVal dtmFondoFijoServicioSucursalFechaPago As Date
    '                 - 
    '              ByVal dtmFondoFijoServicioSucursalUltimaModificacion As Date
    '                 - 
    '              ByVal strFondoFijoServicioSucursalModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================
    Shared Function intActualizar(ByVal intCompaniaId As Double, _
                                  ByVal intSucursalId As Double, _
                                  ByVal intTipoTicketId As Integer, _
                                  ByVal intCajaId As Integer, _
                                  ByVal intEmpleadoId As Integer, _
                                  ByVal intEstadoOperativoCajaId As Integer, _
                                  ByVal intTurnoLaboralId As Integer, _
                                  ByVal intAsignacionCajaId As Integer, _
                                  ByVal intTicketId As Integer, _
                                  ByVal intPagoServicioTicketId As Integer, _
                                  ByVal intEmpresaServicioId As Integer, _
                                  ByVal strEmpresaServicioPagoAutorizacion As String, _
                                  ByVal intFondoFijoServicioSucursalEmpleadoAutorizo As Integer, _
                                  ByVal fltEmpresaServicioPagoImporte As Double, _
                                  ByVal fltEmpresaServicioPagoComision As Double, _
                                  ByVal strEmpresaServicioPagoReferencia As String, _
                                  ByVal dtmFondoFijoServicioSucursalFechaPago As Date, _
                                  ByVal dtmFondoFijoServicioSucursalUltimaModificacion As Date, _
                                  ByVal strFondoFijoServicioSucursalModificadoPor As String, _
                                  ByVal strConnectionString As String) As Integer


        ' Constantes locales
        Const strmThisMemberName As String = "intActualizar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder
        Dim intRowsAffected As Integer, strRowsAffected As String(), strRegistros As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spActualizartblFondoFijoServicioSucursal ")
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
            Call strSQLStatement.Append(intPagoServicioTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpresaServicioId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEmpresaServicioPagoAutorizacion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intFondoFijoServicioSucursalEmpleadoAutorizo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltEmpresaServicioPagoImporte)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltEmpresaServicioPagoComision)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEmpresaServicioPagoReferencia)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFondoFijoServicioSucursalFechaPago.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFondoFijoServicioSucursalUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strFondoFijoServicioSucursalModificadoPor)
            Call strSQLStatement.Append("'")

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
            Dim strErrorString As StringBuilder = New StringBuilder
            Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
            Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
            Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
            Dim strSource As String = objException.Source
            Dim strMessage As String = objException.Message
            Dim strStackTrace As String = objException.StackTrace
            Dim intLineNumber As Integer = Erl()
            Dim intErrorNumber As Integer = Err.Number
            Dim intCategoryNumber As Short = 0

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

        End Try

    End Function

    '====================================================================
    ' Name       : intAgregar
    ' Description: Adición de registros.
    '                  - Tabla tblFondoFijoServicioSucursal
    ' Parameters : 
    '              ByVal intCompaniaId As Integer
    '                 - 
    '              ByVal intSucursalId As Integer
    '                 - 
    '              ByVal intTipoTicketId As Integer
    '                 - 
    '              ByVal intCajaId As Integer
    '                 - 
    '              ByVal intEmpleadoId As Integer
    '                 - 
    '              ByVal intEstadoOperativoCajaId As Integer
    '                 - 
    '              ByVal intTurnoLaboralId As Integer
    '                 - 
    '              ByVal intAsignacionCajaId As Integer
    '
    '              ByVal intTicketId As Integer
    '                 - 
    '              ByVal intPagoServicioTicketId As Integer
    '                 - 
    '              ByVal intEmpresaServicioId As Integer
    '                 -
    '              ByVal strEmpresaServicioPagoAutorizacion As String
    '                 - 
    '              ByVal intFondoFijoServicioSucursalEmpleadoAutorizo As Integer
    '
    '              ByVal fltEmpresaServicioPagoImporte As Double
    '                 - 
    '              ByVal fltEmpresaServicioPagoImporte As Double
    '                 - 
    '              ByVal strEmpresaServicioPagoReferencia As String
    '                 -
    '              ByVal dtmFondoFijoServicioSucursalFechaPago As Date
    '                 - 
    '              ByVal dtmFondoFijoServicioSucursalUltimaModificacion As Date
    '                 - 
    '              ByVal strFondoFijoServicioSucursalModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                  - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================        
    Shared Function intAgregar(ByVal intCompaniaId As Double, _
                                  ByVal intSucursalId As Double, _
                                  ByVal intTipoTicketId As Integer, _
                                  ByVal intCajaId As Integer, _
                                  ByVal intEmpleadoId As Integer, _
                                  ByVal intEstadoOperativoCajaId As Integer, _
                                  ByVal intTurnoLaboralId As Integer, _
                                  ByVal intAsignacionCajaId As Integer, _
                                  ByVal intTicketId As Integer, _
                                  ByVal intPagoServicioTicketId As Integer, _
                                  ByVal intEmpresaServicioId As Integer, _
                                  ByVal strEmpresaServicioPagoAutorizacion As String, _
                                  ByVal intFondoFijoServicioSucursalEmpleadoAutorizo As Integer, _
                                  ByVal fltEmpresaServicioPagoImporte As Double, _
                                  ByVal fltEmpresaServicioPagoComision As Double, _
                                  ByVal strEmpresaServicioPagoReferencia As String, _
                                  ByVal dtmFondoFijoServicioSucursalFechaPago As Date, _
                                  ByVal dtmFondoFijoServicioSucursalUltimaModificacion As Date, _
                                  ByVal strFondoFijoServicioSucursalModificadoPor As String, _
                                  ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intAgregar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder
        Dim intRowsAffected As Integer, strRowsAffected As String(), strRegistros As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spAgregartblFondoFijoServicioSucursal ")
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
            Call strSQLStatement.Append(intPagoServicioTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpresaServicioId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEmpresaServicioPagoAutorizacion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intFondoFijoServicioSucursalEmpleadoAutorizo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltEmpresaServicioPagoImporte)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltEmpresaServicioPagoComision)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEmpresaServicioPagoReferencia)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFondoFijoServicioSucursalFechaPago.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFondoFijoServicioSucursalUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strFondoFijoServicioSucursalModificadoPor)
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
            Dim strErrorString As StringBuilder = New StringBuilder
            Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
            Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
            Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
            Dim strSource As String = objException.Source
            Dim strMessage As String = objException.Message
            Dim strStackTrace As String = objException.StackTrace
            Dim intLineNumber As Integer = Erl()
            Dim intErrorNumber As Integer = Err.Number
            Dim intCategoryNumber As Short = 0

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

        End Try

    End Function

    '====================================================================
    ' Name       : intEliminar
    ' Description: Eliminación de registros.
    '                 - Tabla tblFondoFijoServicioSucursal
    ' Parameters : 
    '              ByVal intCompaniaId As Integer
    '                 - 
    '              ByVal intSucursalId As Integer
    '                 - 
    '              ByVal intTipoTicketId As Integer
    '                 - 
    '              ByVal intCajaId As Integer
    '                 - 
    '              ByVal intEmpleadoId As Integer
    '                 - 
    '              ByVal intEstadoOperativoCajaId As Integer
    '                 - 
    '              ByVal intTurnoLaboralId As Integer
    '                 - 
    '              ByVal intAsignacionCajaId As Integer
    '
    '              ByVal intTicketId As Integer
    '                 - 
    '              ByVal intPagoServicioTicketId As Integer
    '                 - 
    '              ByVal intEmpresaServicioId As Integer
    '                 -
    '              ByVal strEmpresaServicioPagoAutorizacion As String
    '                 - 
    '              ByVal intFondoFijoServicioSucursalEmpleadoAutorizo As Integer
    '
    '              ByVal fltEmpresaServicioPagoImporte As Double
    '                 - 
    '              ByVal fltEmpresaServicioPagoImporte As Double
    '                 - 
    '              ByVal strEmpresaServicioPagoReferencia As String
    '                 -
    '              ByVal dtmFondoFijoServicioSucursalFechaPago As Date
    '                 - 
    '              ByVal dtmFondoFijoServicioSucursalUltimaModificacion As Date
    '                 - 
    '              ByVal strFondoFijoServicioSucursalModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================        
    Shared Function intEliminar(ByVal intCompaniaId As Double, _
                                  ByVal intSucursalId As Double, _
                                  ByVal intTipoTicketId As Integer, _
                                  ByVal intCajaId As Integer, _
                                  ByVal intEmpleadoId As Integer, _
                                  ByVal intEstadoOperativoCajaId As Integer, _
                                  ByVal intTurnoLaboralId As Integer, _
                                  ByVal intAsignacionCajaId As Integer, _
                                  ByVal intTicketId As Integer, _
                                  ByVal intPagoServicioTicketId As Integer, _
                                  ByVal intEmpresaServicioId As Integer, _
                                  ByVal strEmpresaServicioPagoAutorizacion As String, _
                                  ByVal intFondoFijoServicioSucursalEmpleadoAutorizo As Integer, _
                                  ByVal fltEmpresaServicioPagoImporte As Double, _
                                  ByVal fltEmpresaServicioPagoComision As Double, _
                                  ByVal strEmpresaServicioPagoReferencia As String, _
                                  ByVal dtmFondoFijoServicioSucursalFechaPago As Date, _
                                  ByVal dtmFondoFijoServicioSucursalUltimaModificacion As Date, _
                                  ByVal strFondoFijoServicioSucursalModificadoPor As String, _
                                  ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const strmThisMemberName As String = "intEliminar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder
        Dim intRowsAffected As Integer, strRowsAffected As String(), strRegistros As Array

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spEliminartblFondoFijoServicioSucursal ")
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
            Call strSQLStatement.Append(intPagoServicioTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpresaServicioId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEmpresaServicioPagoAutorizacion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intFondoFijoServicioSucursalEmpleadoAutorizo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltEmpresaServicioPagoImporte)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltEmpresaServicioPagoComision)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEmpresaServicioPagoReferencia)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFondoFijoServicioSucursalFechaPago.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFondoFijoServicioSucursalUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strFondoFijoServicioSucursalModificadoPor)
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
            Dim strErrorString As StringBuilder = New StringBuilder
            Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
            Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
            Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
            Dim strSource As String = objException.Source
            Dim strMessage As String = objException.Message
            Dim strStackTrace As String = objException.StackTrace
            Dim intLineNumber As Integer = Erl()
            Dim intErrorNumber As Integer = Err.Number
            Dim intCategoryNumber As Short = 0

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

        End Try

    End Function

    '====================================================================
    ' Name       : strBuscar
    ' Description: Búsqueda de registros.
    '                 - Tabla tblFondoFijoServicioSucursal
    ' Parameters : 
    '              ByVal intCompaniaId As Integer
    '                 - 
    '              ByVal intSucursalId As Integer
    '                 - 
    '              ByVal intTipoTicketId As Integer
    '                 - 
    '              ByVal intCajaId As Integer
    '                 - 
    '              ByVal intEmpleadoId As Integer
    '                 - 
    '              ByVal intEstadoOperativoCajaId As Integer
    '                 - 
    '              ByVal intTurnoLaboralId As Integer
    '                 - 
    '              ByVal intAsignacionCajaId As Integer
    '
    '              ByVal intTicketId As Integer
    '                 - 
    '              ByVal intPagoServicioTicketId As Integer
    '                 - 
    '              ByVal intEmpresaServicioId As Integer
    '                 -
    '              ByVal strEmpresaServicioPagoAutorizacion As String
    '                 - 
    '              ByVal intFondoFijoServicioSucursalEmpleadoAutorizo As Integer
    '
    '              ByVal fltEmpresaServicioPagoImporte As Double
    '                 - 
    '              ByVal fltEmpresaServicioPagoImporte As Double
    '                 - 
    '              ByVal strEmpresaServicioPagoReferencia As String
    '                 -
    '              ByVal dtmFondoFijoServicioSucursalFechaPago As Date
    '                 - 
    '              ByVal dtmFondoFijoServicioSucursalUltimaModificacion As Date
    '                 - 
    '              ByVal strFondoFijoServicioSucursalModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '                 - Arreglo bidimensional con los registros leídos
    '                   Array = { (c1,c2..cn), (c1,c2..cn) ... (c1,c2..cn) }
    '                   c = Campo
    '====================================================================
    Shared Function strBuscar(ByVal intCompaniaId As Double, _
                                  ByVal intSucursalId As Double, _
                                  ByVal intTipoTicketId As Integer, _
                                  ByVal intCajaId As Integer, _
                                  ByVal intEmpleadoId As Integer, _
                                  ByVal intEstadoOperativoCajaId As Integer, _
                                  ByVal intTurnoLaboralId As Integer, _
                                  ByVal intAsignacionCajaId As Integer, _
                                  ByVal intTicketId As Integer, _
                                  ByVal intPagoServicioTicketId As Integer, _
                                  ByVal intEmpresaServicioId As Integer, _
                                  ByVal strEmpresaServicioPagoAutorizacion As String, _
                                  ByVal intFondoFijoServicioSucursalEmpleadoAutorizo As Integer, _
                                  ByVal fltEmpresaServicioPagoImporte As Double, _
                                  ByVal fltEmpresaServicioPagoComision As Double, _
                                  ByVal strEmpresaServicioPagoReferencia As String, _
                                  ByVal dtmFondoFijoServicioSucursalFechaPago As Date, _
                                  ByVal dtmFondoFijoServicioSucursalUltimaModificacion As Date, _
                                  ByVal strFondoFijoServicioSucursalModificadoPor As String, _
                                  ByVal strConnectionString As String) As Array

        ' Constantes locales
        Const strmThisMemberName As String = "strBuscar"

        ' Variables locales
        Dim strSQLStatement As StringBuilder

        Try
            ' Inicializamos las varialbes locales
            strSQLStatement = New StringBuilder

            ' Creamos es estatuto de SQL
            Call strSQLStatement.Append("EXECUTE spBuscartblFondoFijoServicioSucursal ")
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
            Call strSQLStatement.Append(intPagoServicioTicketId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intEmpresaServicioId)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEmpresaServicioPagoAutorizacion)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(intFondoFijoServicioSucursalEmpleadoAutorizo)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltEmpresaServicioPagoImporte)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append(fltEmpresaServicioPagoComision)
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strEmpresaServicioPagoReferencia)
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFondoFijoServicioSucursalFechaPago.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(dtmFondoFijoServicioSucursalUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(",")
            Call strSQLStatement.Append("'")
            Call strSQLStatement.Append(strFondoFijoServicioSucursalModificadoPor)
            Call strSQLStatement.Append("'")

            ' Ejecutamos el comando
            strBuscar = clsSQLOperation.strExecuteQuery(strSQLStatement.ToString(), strConnectionString)
            strSQLStatement = Nothing

        Catch objException As Exception

            ' Variables locales
            Dim strErrorString As StringBuilder = New StringBuilder
            Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
            Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
            Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
            Dim strSource As String = objException.Source
            Dim strMessage As String = objException.Message
            Dim strStackTrace As String = objException.StackTrace
            Dim intLineNumber As Integer = Erl()
            Dim intErrorNumber As Integer = Err.Number
            Dim intCategoryNumber As Short = 0

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

        End Try

    End Function

    '====================================================================
    ' Name       : strObtenerFondoFijoServicioPorDireccionZona
    ' Description: Búsqueda de registros.
    '                 - Tabla tblFondoFijoServicioSucursal
    ' Parameters : 
    '              ByVal intDireccionOperativaId As Integer
    '                 - 
    '              ByVal intZonaOperativaId As Integer
    '                 - 
    '              ByVal intMes As Integer
    '                 - 
    '              ByVal intAnio As Integer
    '                 - 
    '              ByVal intElementosPorPagina As Integer
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '                 - Arreglo bidimensional con los registros leídos
    '                   Array = { (c1,c2..cn), (c1,c2..cn) ... (c1,c2..cn) }
    '                   c = Campo
    '====================================================================
    Public Shared Function strObtenerFondoFijoServicioPorDireccionZona( _
                                                    ByVal intDireccionOperativaId As Integer, _
                                                    ByVal intZonaOperativaId As Integer, _
                                                    ByVal intMes As Integer, _
                                                    ByVal intAnio As Integer, _
                                                    ByVal intPosicionInicial As Integer, _
                                                    ByVal intElementosPorPagina As Integer, _
                                                    ByVal strConnectionString As String) As Array

        ' Constantes locales 
        Const strmThisMemberName As String = "strObtenerFondoFijoServicioPorDireccionZona"

        ' Variables locales
        Dim strSQLStatement As System.Text.StringBuilder = Nothing

        Try

            ' Inicialización de las variables locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.AppendFormat("EXECUTE spObtenerFondoFijoServicioPorDireccionZona '{0}', '{1}', '{2}', '{3}', '{4}', '{5}'", intDireccionOperativaId, intZonaOperativaId, intMes, intAnio, intPosicionInicial, intElementosPorPagina)

            ' Ejecutamos el comando
            strObtenerFondoFijoServicioPorDireccionZona = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString, strConnectionString)
            strSQLStatement = Nothing

        Catch objException As Exception

            ' Variables locales
            Dim strErrorString As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
            Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
            Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
            Dim strSource As String = objException.Source
            Dim strMessage As String = objException.Message
            Dim strStackTrace As String = objException.StackTrace
            Dim intLineNumber As Integer = Erl()
            Dim intErrorNumber As Integer = Err.Number
            Dim intCategoryNumber As Short = 0

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
            strObtenerFondoFijoServicioPorDireccionZona = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strObtenerDetalleFondoFijoServicioPorDireccionZona
    ' Description: Búsqueda de registros.
    '                 - Tabla tblFondoFijoServicioSucursal
    ' Parameters : 
    '              ByVal intDireccionOperativaId As Integer
    '                 - 
    '              ByVal intZonaOperativaId As Integer
    '                 - 
    '              ByVal intMes As Integer
    '                 - 
    '              ByVal intAnio As Integer
    '                 - 
    '              ByVal intElementosPorPagina As Integer
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '                 - Arreglo bidimensional con los registros leídos
    '                   Array = { (c1,c2..cn), (c1,c2..cn) ... (c1,c2..cn) }
    '                   c = Campo
    '====================================================================
    Public Shared Function strObtenerDetalleFondoFijoServicioPorDireccionZona( _
                                                    ByVal intDireccionOperativaId As Integer, _
                                                    ByVal intZonaOperativaId As Integer, _
                                                    ByVal intMes As Integer, _
                                                    ByVal intAnio As Integer, _
                                                    ByVal intPosicionInicial As Integer, _
                                                    ByVal intElementosPorPagina As Integer, _
                                                    ByVal strConnectionString As String) As Array

        ' Constantes locales 
        Const strmThisMemberName As String = "strObtenerDetalleFondoFijoServicioPorDireccionZona"

        ' Variables locales
        Dim strSQLStatement As System.Text.StringBuilder = Nothing

        Try

            ' Inicialización de las variables locales
            strSQLStatement = New System.Text.StringBuilder

            ' Creamos estatuto de SQL
            Call strSQLStatement.AppendFormat("EXECUTE spObtenerDetalleFondoFijoServicioPorDireccionZona '{0}', '{1}', '{2}', '{3}', '{4}', '{5}'", intDireccionOperativaId, intZonaOperativaId, intMes, intAnio, intPosicionInicial, intElementosPorPagina)

            ' Ejecutamos el comando
            strObtenerDetalleFondoFijoServicioPorDireccionZona = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(strSQLStatement.ToString, strConnectionString)
            strSQLStatement = Nothing

        Catch objException As Exception

            ' Variables locales
            Dim strErrorString As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim objApplicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim strProductName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
            Dim strApplicationName As String = System.Reflection.Assembly.GetExecutingAssembly.Location
            Dim strVersion As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
            Dim strSource As String = objException.Source
            Dim strMessage As String = objException.Message
            Dim strStackTrace As String = objException.StackTrace
            Dim intLineNumber As Integer = Erl()
            Dim intErrorNumber As Integer = Err.Number
            Dim intCategoryNumber As Short = 0

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
            strObtenerDetalleFondoFijoServicioPorDireccionZona = Nothing

            ' Notificamos el error
            Throw

        End Try

    End Function

End Class
