Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Benavides.POSAdmin.Commons.clsCommons.clsMSMQ
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports Isocraft.Web.Javascript
Imports System.IO
Imports System.Web.Caching

Public Class ControlAsistencia
    Inherits System.Web.UI.Page

    Private intDireccionOperativaId As Integer
    Private intZonaOperativaId As Integer
    Private intSucursalesId As Integer
    Private intTipoMovimientosId As Integer
    Private intmTipoUsuarioId As Integer

    Dim strmTotalDePartidas As Integer
    Dim astrRecords As Array
    Dim strMovimientos As String = String.Empty

    Private Enum TipoUsuario
        Administrador = 1
        CoordinadorRH = 2
        SupervisorMedico = 3
    End Enum

    Private Enum TipoConsulta
        Resumen = 1
        Detalle = 2
    End Enum

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        intDireccionOperativaId = GetPageParameter("cboDireccionOperativa", 0)
        intZonaOperativaId = GetPageParameter("cboZonaOperativa", 0)
        intSucursalesId = GetPageParameter("cboSucursales", 0)
        intTipoMovimientosId = GetPageParameter("cboTipoMovimientos", 0)

    End Sub

#End Region

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", String.Empty, Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strHTMLFechaHora
    ' Description: Genera la fecha y hora de la página
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
        End Get
    End Property

    '====================================================================
    ' Name       : intGrupoUsuarioId
    ' Description: Identificador del Grupo de Usuario
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intGrupoUsuarioId() As Integer
        Get
            Return CInt(Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strFormAction
    ' Description: HTML form's action property value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormAction() As String
        Get
            Return strThisPageName
        End Get
    End Property

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Connection string
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Private ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: Name of this page
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request)
        End Get
    End Property

#Region "Combos"
    '====================================================================
    ' Name       : LlenarControlDireccion
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboDireccionOperativa
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlDireccion() As String

        'Consultamos las direcciones operativas
        astrRecords = Nothing

        astrRecords = Benavides.CC.Data.clsControlDeAsistencia.strBuscarDivisionControlAsistencia(strUsuarioNombre, strConnectionString)

        'Tipo de usuario
        If Not IsNothing(astrRecords) AndAlso astrRecords.Length > 0 Then
            intmTipoUsuarioId = CInt(DirectCast(DirectCast(astrRecords, Object())(0), String())(2))
        End If

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccionOperativa", intDireccionOperativaId, astrRecords, 0, 1, 1)

    End Function

    '====================================================================
    ' Name       : LlenarControlZona
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboZona
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlZona() As String

        ' Validamos si hay una Direccion Operativa seleccionada
        If intDireccionOperativaId > 0 Then

            ' Inicializamos el arreglo
            astrRecords = Nothing

            'Consultamos las direcciones operativas
            astrRecords = Benavides.CC.Data.clsControlDeAsistencia.strBuscarZonaControlAsistencia(strUsuarioNombre, intDireccionOperativaId, strConnectionString)

            ' Formamos el string con los valores
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZonaOperativa", intZonaOperativaId, astrRecords, 0, 1, 1)

        ElseIf (intDireccionOperativaId = -1) Then

            Return "document.forms[0].elements['cboZonaOperativa'].options[1] = new Option('Todas las zonas','-1');"

        End If
    End Function

    '====================================================================
    ' Name       : LlenarControlSucursales
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboSucursales
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlSucursales() As String

        Dim strSucursales As New StringBuilder

        If intDireccionOperativaId = -1 Then
            intZonaOperativaId = -1
        End If

        If Not intDireccionOperativaId = 0 AndAlso Not intZonaOperativaId = 0 Then

            Dim returnedData As Array = Nothing

            'strAlmacenId = 0001 para que NO traiga los Foto Labs
            Dim strAlmacenId As String = "0001"

            Dim objSucursalItem As String() = Nothing
            Dim i As Integer

            returnedData = Benavides.CC.Data.clsControlDeAsistencia.strObtenerSucursales(CInt(strUsuarioNombre), intDireccionOperativaId, intZonaOperativaId, strAlmacenId, strConnectionString)

            If Not returnedData Is Nothing AndAlso IsArray(returnedData) AndAlso returnedData.Length > 0 Then

                If returnedData.Length > 1 Then
                    strSucursales.AppendFormat("<option value=""{0}"">{1}</option>", -1, "Todas")
                End If

                For i = 0 To returnedData.Length - 1

                    objSucursalItem = CType(returnedData.GetValue(i), String())

                    strSucursales.AppendFormat("<option value=""{0}"">{1}</option>", objSucursalItem(2).ToString().Trim(), objSucursalItem(3).ToString().Trim())
                Next
            End If
        End If

        Return strSucursales.ToString()
    End Function

    '====================================================================
    ' Name       : LlenarControlTipoMovimientos
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboCategoriaArticulos
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlTipoMovimientos() As String

        ' Inicializamos el arreglo
        astrRecords = Nothing

        'Consultamos los movimientos de nomina
        astrRecords = Benavides.CC.Data.clsControlDeAsistencia.strObtenerMovimientosNomina(strConnectionString)

        ' Formamos el string con los valores
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboTipoMovimientos", intTipoMovimientosId, astrRecords, 0, 2, 2)
        'End If
    End Function

    Protected Function LlenarPerfilesEmpleados() As String
        Dim strPerfilesEmpleados As New StringBuilder
        Dim resultadoConsulta As Array = Nothing
        Dim objSucursalItem As String() = Nothing

        resultadoConsulta = Benavides.CC.Data.clsControlDeAsistencia.strObtenerPerfilesEmpleados(strConnectionString)

        For i As Integer = 0 To resultadoConsulta.Length - 1
            objSucursalItem = CType(resultadoConsulta.GetValue(i), String())
            strPerfilesEmpleados.AppendFormat("<option value=""{0}"">{1}</option>", _
                                              objSucursalItem(0).ToString(), objSucursalItem(1).ToString())
        Next

        Return strPerfilesEmpleados.ToString()
    End Function

    Protected Function LLenarControlObservaciones() As String
        Dim strObservaciones As New StringBuilder
        Dim resultadoConsulta As Array = Nothing
        Dim registro As New System.Collections.SortedList

        resultadoConsulta = Benavides.CC.Data.clsControlDeAsistencia. _
                                              clsControlAsistenciaObservaciones. _
                                              strConsultartblControlAsistenciaObservacionesPorActivo(strConnectionString)

        For i As Integer = 0 To resultadoConsulta.Length - 1
            registro = CType(resultadoConsulta.GetValue(i), Collections.SortedList)
            strObservaciones.AppendFormat("<option value=""{0}"">{1}</option>", _
                                              registro.Item("intControlAsistenciaObservacionesId").ToString(), _
                                              registro.Item("strControlAsistenciaObservacionesNombre").ToString())
        Next

        Return strObservaciones.ToString()
    End Function

#End Region

    '====================================================================
    ' Name       : intTipoUsuarioId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTipoUsuarioId() As Integer
        Get
            If Not IsNothing(Request("hdnTipoUsuario")) AndAlso Not Trim(Request("hdnTipoUsuario")) = String.Empty AndAlso IsNumeric(Request("hdnTipoUsuario")) Then
                Return CInt(Request("hdnTipoUsuario"))
            Else
                Return intmTipoUsuarioId
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intDireccionId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intDireccionId() As Integer
        Get
            Return intDireccionOperativaId
        End Get
    End Property

    '====================================================================
    ' Name       : intZonaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intZonaId() As Integer
        Get
            Return intZonaOperativaId
        End Get
    End Property

    '====================================================================
    ' Name       : strSucursalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalId() As String
        Get
            Return Request.Form("cboSucursales")
        End Get
    End Property

    '====================================================================
    ' Name       : intMovimientoId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intMovimientoId() As Integer
        Get
            Return intTipoMovimientosId
        End Get
    End Property

    '====================================================================
    ' Name       : strFirstDayOfMonth
    ' Description: Regresa el primer dia del mes actual
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFirstDayOfMonth() As String
        Get
            If IsNothing(Request.Form("dtmFechaIni")) Then
                Return New Date(Date.Today.Year, Date.Today.Month, 1).ToString("dd/MM/yyyy")
            Else
                Return Request.Form("dtmFechaIni")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strFechaActual
    ' Description: Regresa la fecha actual
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFechaActual() As String
        Get
            If IsNothing(Request.Form("dtmFechaFin")) Then
                Dim dtmFechaActual As Date

                dtmFechaActual = New Date(Date.Today.Year, Date.Today.Month, Date.Today.Day)

                Return dtmFechaActual.ToString("dd/MM/yyyy")
            Else
                Return Request.Form("dtmFechaFin")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intEmpleadoId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intEmpleadoId() As Integer
        Get
            If Not IsNothing(Request.Form("txtEmpleadoId")) AndAlso Not (Trim(Request.Form("txtEmpleadoId")) = String.Empty) Then
                Return CInt(Request.Form("txtEmpleadoId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intTipoNomina
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTipoNomina() As Integer
        Get
            If Not IsNothing(Request.Form("cmdTipoNomina")) Then
                Return CInt(Request.Form("cmdTipoNomina"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intTipoConsulta
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTipoConsulta() As Integer
        Get
            If Not IsNothing(Request.Form("cmdTipoConsulta")) Then
                Return CInt(Request.Form("cmdTipoConsulta"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaInicio
    ' Description: Fecha de inicio a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaInicio() As Date
        Get
            Dim f As String = Request.Form("dtmFechaIni")
            If Not IsNothing(f) Then
                Dim fp As String() = f.Split("/".ToCharArray())

                Return New Date(CInt(fp(2)), CInt(fp(1)), CInt(fp(0)))
            Else
                Return CDate("01/01/1900")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaFin
    ' Description: Fecha de fin  a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaFin() As Date
        Get
            Dim f As String = Request.Form("dtmFechaFin")
            If Not IsNothing(f) Then
                Dim fp As String() = f.Split("/".ToCharArray())

                Return New Date(CInt(fp(2)), CInt(fp(1)), CInt(fp(0)))
            Else
                Return CDate("01/01/1900")
            End If
        End Get
    End Property

    Public ReadOnly Property intPuestoEmpleadoId() As Integer
        Get
            If Not IsNothing(Request.Form("cboPerfiles")) Then
                Return CInt(Request.Form("cboPerfiles"))
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property intControlAsistenciaObservacionesId As Integer
        Get
            If Not IsNothing(Request.Form("cboObservaciones")) Then
                Return CInt(Request.Form("cboObservaciones"))
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return GetPageParameter("strCmd", String.Empty)
        End Get
    End Property

    '====================================================================
    ' Name       : strTotalDePartidas
    ' Description: Numero de sucursales por "Asignar".
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strTotalDePartidas() As Integer
        Get
            Return strmTotalDePartidas
        End Get
        Set(ByVal strValue As Integer)
            strmTotalDePartidas = strValue
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Dim strRecordBrowserImpresion As String = String.Empty
        Const strComitasDobles As String = """"
        Dim strHTML As New StringBuilder
        Dim objDataArrayMovimientos As Array = Nothing

        If (strCmd = "cmdImprimir") Then

            'CONSULTA DE REGISTROS
            If (intTipoConsulta = TipoConsulta.Resumen) Then
                objDataArrayMovimientos = ConsultarResumenControlAsistencia()

            ElseIf (intTipoConsulta = TipoConsulta.Detalle) Then
                objDataArrayMovimientos = ConsultarDetalleControlAsistencia()
            Else
                objDataArrayMovimientos = Nothing
            End If

            'FORMATO A TABLA CON RESULTADOS
            If IsArray(objDataArrayMovimientos) AndAlso objDataArrayMovimientos.Length > 0 Then

                If (intTipoConsulta = TipoConsulta.Resumen) Then

                    'Resumen
                    strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strImpresionMovimientosResumen(objDataArrayMovimientos))

                ElseIf (intTipoConsulta = TipoConsulta.Detalle) Then

                    'Se formatea la informacion.  
                    strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strImpresionMovimientosDetalle(objDataArrayMovimientos))
                End If

                'Se envia a impresion.
                strHTML.Append("<script language='Javascript'>parent.fnImprimir( " & _
                strComitasDobles & strRecordBrowserImpresion.ToString & strComitasDobles & _
                "); </script>")
                Response.Write(strHTML.ToString)
                Response.End()

            End If

        ElseIf (strCmd = "cmdExportar") Then

            Dim objArrayExportar As System.Array = Nothing

            'CONSULTA DE REGISTROS
            If (intTipoConsulta = TipoConsulta.Resumen) Then

                objArrayExportar = ConsultarResumenControlAsistencia()

            ElseIf (intTipoConsulta = TipoConsulta.Detalle) Then

                objArrayExportar = ConsultarDetalleControlAsistencia()
            Else
                objArrayExportar = Nothing
            End If

            ' Establecemos en la respuesta los parámetros de configuración del archivo
            Response.ContentType = "application/vnd.ms-excel"
            Call Response.AddHeader("Content-Disposition", "attachment; filename=""Control de Asistencia - Detalle de Movimientos.xls""")

            'FORMATO A TABLA CON RESULTADOS
            If IsArray(objArrayExportar) AndAlso objArrayExportar.Length > 0 Then

                If (intTipoConsulta = TipoConsulta.Resumen) Then
                    Call Response.Write(strTablaConsultaResumenExportar(objArrayExportar))
                ElseIf (intTipoConsulta = TipoConsulta.Detalle) Then
                    Call Response.Write(strTablaConsultaDetalleExportar(objArrayExportar))
                End If

                Call Response.End()

            End If
        ElseIf (strCmd = "cmdConfirmar") Then
            Try

                Dim intTotalDePartidas As Integer
                Dim intPartida As Integer
                Dim objArray As System.Array = Nothing
                Dim boolSeleccion As Boolean = False
                Dim boolSinPermiso As Boolean = False
                Dim intTotalConfirmar As Integer = 0
                Dim intConfirmados As Integer = 0
                Dim intRechazados As Integer = 0
                Dim intResultado As Integer = 0
                Dim boolSinSeleccionObs As Boolean = False
                Dim cambioMovimiento As Boolean = False

                ' Agregar Cenefa Manual Articulo
                intTotalDePartidas = CInt(Request("hdnTotalDePartidas"))

                For intPartida = 1 To intTotalDePartidas

                    cambioMovimiento = CBool(Request("hdnCambioMovimiento" & intPartida.ToString()))

                    ' Si cambió el combo de Movimientos, entonces valida si esta 
                    ' vacío el combo de asistencia (observaciones) al hacer click para confirmar 
                    If Request("hdnCambioMovimiento" & intPartida.ToString()).ToString().Equals("true") Then
                        If Request("cboAsistencia" & intPartida.ToString()).ToString().Equals("0") Then
                            boolSinSeleccionObs = True
                            Exit For
                        End If
                    End If

                    If (intTipoUsuarioId = TipoUsuario.CoordinadorRH Or intTipoUsuarioId = TipoUsuario.SupervisorMedico) AndAlso (Len(Trim(Request("chkCodigo" & intPartida.ToString))) > 0) AndAlso (Request.Form("hdnConfirmado" & intPartida.ToString) = "1") Then
                        boolSinPermiso = True
                    End If

                    If (Len(Trim(Request("chkCodigo" & intPartida.ToString))) > 0) AndAlso ((intTipoUsuarioId = TipoUsuario.Administrador) Or ((intTipoUsuarioId = TipoUsuario.CoordinadorRH Or intTipoUsuarioId = TipoUsuario.SupervisorMedico) AndAlso (Request.Form("hdnConfirmado" & intPartida.ToString) = "0"))) Then

                        boolSeleccion = True

                        If Not cambioMovimiento Then

                            'Se confirma la asistencia...
                            intResultado = Benavides.CC.Data.clsControlDeAsistencia.intConfirmarAsistencia( _
                                                                CInt(Request("hdnRegistro" & intPartida.ToString)), _
                                                                CInt(Request("cbo" & intPartida.ToString())), _
                                                                strUsuarioNombre, _
                                                                dtmFechaInicio, _
                                                                dtmFechaFin, _
                                                                -1, _
                                                                strConnectionString)
                        Else
                            'Se confirma la asistencia...
                            intResultado = Benavides.CC.Data.clsControlDeAsistencia.intConfirmarAsistencia( _
                                                                CInt(Request("hdnRegistro" & intPartida.ToString)), _
                                                                CInt(Request("cbo" & intPartida.ToString())), _
                                                                strUsuarioNombre, _
                                                                dtmFechaInicio, _
                                                                dtmFechaFin, _
                                                                CInt(Request("cboAsistencia" & intPartida.ToString())), _
                                                                strConnectionString)
                        End If

                        'Total de registros por confirmar
                        intTotalConfirmar += 1

                        If (intResultado > 0) Then

                            'Registros confirmados con exito 
                            intConfirmados += 1
                        ElseIf (intResultado = 0) Then

                            'Registros rechazados
                            intRechazados += 1
                        End If
                    End If
                Next

                If boolSinSeleccionObs Then
                    Call Response.Write("<script language='Javascript'>alert('Favor de seleccionar la observación correspondiente.');</script>")
                    Return
                End If

                If boolSinPermiso AndAlso boolSeleccion = False Then
                    Call Response.Write("<script language='Javascript'>alert('No cuenta con permiso para confirmar');</script>")
                ElseIf boolSinPermiso = False AndAlso boolSeleccion = False Then
                    Call Response.Write("<script language='Javascript'>alert('Seleccione una registro para confirmar');</script>")
                Else
                    Call Response.Write("<script language='Javascript'>alert('De un total de " & CStr(intTotalConfirmar) & " registros por confirmar: Se confirmaron " & CStr(intConfirmados) & " y se rechazaron " & CStr(intRechazados) & "');</script>")
                End If

            Catch ex As Exception
                Call Response.Write("<script language='Javascript'>alert('Ocurrio un error durante la confirmación');</script>")
            End Try

        End If
    End Sub

    Public Function strTablaConsultaAsistencia() As String
        Dim objArray As System.Array = Nothing
        Dim resultadoConsulta As String = String.Empty
        Dim strmRecordBrowserHTML As String = String.Empty

        strmTotalDePartidas = 0

        If (strCmd = "cmdConsultar") Or (strCmd = "cmdConfirmar") Then

            If (intTipoConsulta = TipoConsulta.Resumen) Then

                If (Request.QueryString("pager") = "true") Then
                    If Not Cache("cacheResumen") Is Nothing Then
                        objArray = CType(Cache("cacheResumen"), System.Array)
                    End If
                End If

                If objArray Is Nothing Then

                    Cache.Remove("cacheResumen")
                    'Resumen de Movimientos
                    objArray = ConsultarResumenControlAsistencia()
                End If

            ElseIf (intTipoConsulta = TipoConsulta.Detalle) Then

                'Detalle de Movimientos
                objArray = ConsultarDetalleControlAsistencia()
            Else
                objArray = Nothing
            End If

            Dim strResult As New StringBuilder
            If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then

                'Cantidad de registros
                strmTotalDePartidas = objArray.Length

                If (intTipoConsulta = TipoConsulta.Resumen) Then

                    Cache.Add("cacheResumen", objArray, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, Nothing)
                    strResult.Append(strTablaConsultaResumenHTML(objArray))
                Else
                    strResult.Append(strTablaConsultaDetalleHTML(objArray))
                End If

            Else
                'Tabla vacia sin resultados de consulta
                Call Response.Write("<script language='Javascript'>alert('Busqueda sin resultados');</script>")
            End If

            strResult.Append("<script language=""javascript"" type=""text/javascript"">")
            strResult.Append("parent.document.getElementById('tblResultados').innerHTML = document.getElementById('divConsultaMovimientos').innerHTML;")
            strResult.Append("</script>")

            Return strResult.ToString()
        End If

        Return String.Empty
    End Function

    Private Function ConsultarResumenControlAsistencia() As Array
        Dim consultaEmpleados As System.Array = Nothing

        If intTipoUsuarioId = TipoUsuario.Administrador Then

            consultaEmpleados = clsControlDeAsistencia. _
                                strConsultaResumenControlAsistenciaPorAdministrador(intEmpleadoId, _
                                                                                    strSucursalId, _
                                                                                    intZonaId, _
                                                                                    intTipoMovimientosId, _
                                                                                    intTipoNomina, _
                                                                                    dtmFechaInicio, _
                                                                                    dtmFechaFin, _
                                                                                    intPuestoEmpleadoId, _
                                                                                    intControlAsistenciaObservacionesId, _
                                                                                    strConnectionString)

        ElseIf intTipoUsuarioId = TipoUsuario.CoordinadorRH Or intTipoUsuarioId = TipoUsuario.SupervisorMedico Then

            consultaEmpleados = clsControlDeAsistencia. _
                                strConsultaResumenControlAsistenciaPorCoordinador(intEmpleadoId, _
                                                                                  strSucursalId, _
                                                                                  intZonaId, _
                                                                                  intTipoMovimientosId, _
                                                                                  intTipoNomina, _
                                                                                  dtmFechaInicio, _
                                                                                  dtmFechaFin, _
                                                                                  intControlAsistenciaObservacionesId, _
                                                                                  intTipoUsuarioId, _
                                                                                  strConnectionString)
        End If

        Return consultaEmpleados
    End Function

    Private Function ConsultarDetalleControlAsistencia() As Array
        Dim consultaEmpleados As System.Array = Nothing

        If intTipoUsuarioId = TipoUsuario.Administrador Then

            consultaEmpleados = clsControlDeAsistencia. _
                                strConsultaDetalleControlAsistenciaPorAdministrador(intEmpleadoId, _
                                                                                    strSucursalId, _
                                                                                    intZonaId, _
                                                                                    intTipoMovimientosId, _
                                                                                    intTipoNomina, _
                                                                                    dtmFechaInicio, _
                                                                                    dtmFechaFin, _
                                                                                    intPuestoEmpleadoId, _
                                                                                    intControlAsistenciaObservacionesId, _
                                                                                    strConnectionString)

        ElseIf intTipoUsuarioId = TipoUsuario.CoordinadorRH Or intTipoUsuarioId = TipoUsuario.SupervisorMedico Then

            consultaEmpleados = clsControlDeAsistencia. _
                                strConsultaDetalleControlAsistenciaPorCoordinador(intEmpleadoId, _
                                                                                  strSucursalId, _
                                                                                  intZonaId, _
                                                                                  intTipoMovimientosId, _
                                                                                  intTipoNomina, _
                                                                                  dtmFechaInicio, _
                                                                                  dtmFechaFin, _
                                                                                  intControlAsistenciaObservacionesId, _
                                                                                  intTipoUsuarioId, _
                                                                                  strConnectionString)
        End If

        Return consultaEmpleados
    End Function

    Public Function strTablaConsultaDetalleHTML(ByVal objConsultaDetalle As Array) As String
        Dim strTablaDetalleHTML As StringBuilder
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim imgDetalle As String = Nothing
        Dim chkbox As String = Nothing
        Dim idName As String = Nothing
        Dim strConfirmado As String
        Dim strConsultaRegistroDetalle As String()
        Dim cboMovimientoAjuste As String = String.Empty
        Dim cboAsistenciaObs As String = String.Empty
        Dim lblObservacion As String = String.Empty
        Dim asistenciaObservaciones As String(,)
        Dim strOpciones As String = String.Empty
        Dim strControlAsistenciaObservacionesId As String
        Dim mostrarCboMovimientoAjuste As Boolean = False
        Dim hdnCambioMovimiento As String = "<input type='hidden' id='hdnCambioMovimiento{0}' name='hdnCambioMovimiento{0}' value='false' >"

        asistenciaObservaciones = ConsultarAsistenciaObservaciones()

        idName = "id=chkCodigo name=chkCodigo"
        chkbox = "<input type='checkbox' " & idName & " onclick='javascript:fnMarcarTodos()'>"

        strTablaDetalleHTML = New StringBuilder

        strTablaDetalleHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        strTablaDetalleHTML.Append("<tr class='trtitulos'>")
        strTablaDetalleHTML.Append("<td colspan='6' align='left'></td>")
        strTablaDetalleHTML.Append("<td class='rayita' align='right' valign='top' colspan='4'>")
        strTablaDetalleHTML.Append("Confirmación")
        strTablaDetalleHTML.Append("</td>")
        strTablaDetalleHTML.Append("<td class='rayita'></td>")
        strTablaDetalleHTML.Append("</tr>")

        'Encabezados de Tabla de Resultados
        strTablaDetalleHTML.Append("<tr class='trtitulos'>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>No.</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Empleado</th>")

        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Hora Entrada</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Hora Salida</th>")

        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Centro Logistico</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Sucursal</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Movimiento</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Fecha</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Movimiento</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Todos" & chkbox & "</th>")

        strTablaDetalleHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For Each strConsultaRegistroDetalle In objConsultaDetalle
            intContador += 1
            lblObservacion = "<br/><label {0} id='lblObservacion{1}' style='color:blue'>Observaciones</label>"
            strControlAsistenciaObservacionesId = strConsultaRegistroDetalle(13)

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            idName = "id=chkCodigo" & intContador.ToString() & " " & "name=chkCodigo" & intContador.ToString()
            strConfirmado = "1"

            ' cbo AsistenciaObservaciones
            If Not (strConsultaRegistroDetalle(13) = "-1" Or strConsultaRegistroDetalle(13) = "") Then
                strOpciones = FormarOpcionesSelectConSeleccion(asistenciaObservaciones, CInt(strControlAsistenciaObservacionesId))
                mostrarCboMovimientoAjuste = True
                lblObservacion = String.Format(lblObservacion, " ", intContador)
            Else
                strOpciones = FormarOpcionesSelectSinSeleccion(asistenciaObservaciones)
                mostrarCboMovimientoAjuste = False
                lblObservacion = String.Format(lblObservacion, "style='display:none'", intContador)
            End If

            cboAsistenciaObs = ObtenerAsistenciaObservaciones(strOpciones, intContador, mostrarCboMovimientoAjuste)

            'Combos con informacion de los ajustes
            If intTipoUsuarioId = TipoUsuario.Administrador Then
                'El administrador por Regla de Negocio tendra todas las opciones
                cboMovimientoAjuste = ObtenerMovimientosAdmin(strConsultaRegistroDetalle, intContador)
            Else
                'El coordinador RH dependera del Movimiento Original ver "tblConfiguracionMovimientosAsistencia" y "tblRelacionMovimientosAsistencia".
                cboMovimientoAjuste = LlenarControlConfirmacionMov(strConsultaRegistroDetalle, intContador)
            End If

            'CheckBox 
            If (CBool(strConsultaRegistroDetalle(12)) = False) Then

                'Registro Sin confirmar
                chkbox = "<input type='checkbox'" & idName & " onclick='javascript:fnMarcarUno()'/>"
                strConfirmado = "0"
            ElseIf ((CBool(strConsultaRegistroDetalle(12)) = True) AndAlso (intTipoUsuarioId = TipoUsuario.Administrador)) Then

                'Registro Confirmado, usuario = Administrador
                chkbox = "<input type='checkbox'" & idName & " checked onclick='javascript:fnMarcarUno()'/>"
            ElseIf (CBool(strConsultaRegistroDetalle(12)) = True) AndAlso (intTipoUsuarioId = TipoUsuario.CoordinadorRH Or intTipoUsuarioId = TipoUsuario.SupervisorMedico) Then

                'Registro Confirmado, usuario = Coordinador RH
                chkbox = "<input type='checkbox'" & idName & " checked disabled='disabled' onclick='javascript:fnMarcarUno()'/>"
            End If

            strTablaDetalleHTML.Append("<tr>")
            ' No. Empleado
            strTablaDetalleHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaRegistroDetalle(1) & " <input type='hidden' id='hdnRegistro" & intContador.ToString() & "' name='hdnRegistro" & intContador.ToString() & "' value='" & strConsultaRegistroDetalle(0) & "'></td>")
            ' Empleado
            strTablaDetalleHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroDetalle(2)) & "</td>")
            ' Hora Entrada
            strTablaDetalleHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaRegistroDetalle(15) & "</td>")
            ' Hora Salida
            strTablaDetalleHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaRegistroDetalle(16) & "</td>")
            ' Centro Logistico 
            strTablaDetalleHTML.Append("<td id=Division" & intContador & " align=center class=" & strColorRegistro & ">" & strConsultaRegistroDetalle(3) & "</td>")
            ' Sucursal
            strTablaDetalleHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroDetalle(6)) & "</td>")
            ' Movimiento
            strTablaDetalleHTML.Append("<td align=left class=" & strColorRegistro & ">" & CStr(strConsultaRegistroDetalle(7)) & "-" & CStr(strConsultaRegistroDetalle(8)) & "</td>")
            ' Fecha
            strTablaDetalleHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaRegistroDetalle(9)) & "</td>")
            ' Movimiento
            strTablaDetalleHTML.Append("<td align=center class=" & strColorRegistro & ">" & cboMovimientoAjuste & String.Format(lblObservacion, intContador) & cboAsistenciaObs & String.Format(hdnCambioMovimiento, intContador) & "</td>")
            ' Confirma
            strTablaDetalleHTML.Append("<td align=center class=" & strColorRegistro & ">" & chkbox & " <input type='hidden' id='hdnConfirmado" & intContador.ToString() & "' name='hdnConfirmado" & intContador.ToString() & "' value='" & strConfirmado & "'></td>")
            strTablaDetalleHTML.Append("</tr>")
        Next

        strTablaDetalleHTML.Append("</tr>")
        strTablaDetalleHTML.Append("</table>")
        strTablaConsultaDetalleHTML = strTablaDetalleHTML.ToString
    End Function

    Protected Function ObtenerMovimientosAdmin(ByVal strConsultaRegistroDetalle As String(), ByVal intContador As Integer) As String
        Dim arrMovimientos As Array = Nothing
        Dim cboMovimientos As String = String.Empty

        cboMovimientos = "<select onchange='mostrarCboAsistencia(this);' id='cbo" & intContador.ToString() & "' name='cbo" & intContador.ToString() & "' class='campotabla' style='width:85px'>" & vbCrLf

        If strMovimientos = "" Then

            'Consultamos los movimientos de nomina
            arrMovimientos = Nothing
            arrMovimientos = Benavides.CC.Data.clsControlDeAsistencia.strObtenerMovimientosNomina(strConnectionString)

            Dim objMovimientoItem As String() = Nothing
            Dim i As Integer
            i = 0

            If Not arrMovimientos Is Nothing AndAlso IsArray(arrMovimientos) AndAlso arrMovimientos.Length > 0 Then

                'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
                For Each objMovimientoItem In arrMovimientos
                    i += 1

                    If CInt(objMovimientoItem(0)) = CInt(strConsultaRegistroDetalle(10)) Then
                        strMovimientos = strMovimientos & "<option selected='selected' value='" & CStr(objMovimientoItem(0)) & "'>" & CStr(objMovimientoItem(2)) & "</option>" & vbCrLf
                    Else
                        strMovimientos = strMovimientos & "<option value='" & CStr(objMovimientoItem(0)) & "'>" & CStr(objMovimientoItem(2)) & "</option>" & vbCrLf
                    End If
                Next

            End If
        End If

        cboMovimientos = cboMovimientos & strMovimientos & "</select>"

        Dim strViejo As String
        Dim strNuevo As String

        'Se cambian las opciones seleccionadas para cada registro (combo).
        strViejo = "<option selected='selected'"
        strNuevo = "<option"
        cboMovimientos = cboMovimientos.Replace(strViejo, strNuevo)

        strViejo = "<option value='" & CStr(strConsultaRegistroDetalle(10)) & "'"
        strNuevo = "<option selected='selected' value='" & CStr(strConsultaRegistroDetalle(10)) & "'"
        cboMovimientos = cboMovimientos.Replace(strViejo, strNuevo)

        Return cboMovimientos

    End Function

    '====================================================================
    ' Name       : LlenarControlConfirmacionMov
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control de ajustes
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlConfirmacionMov(ByVal strConsultaRegistroDetalle As String(), ByVal intContador As Integer) As String
        Dim strRegistroDetalle As String()
        Dim cbo As String = String.Empty

        astrRecords = Nothing

        If (intTipoUsuarioId = TipoUsuario.CoordinadorRH Or intTipoUsuarioId = TipoUsuario.SupervisorMedico) AndAlso (CBool(strConsultaRegistroDetalle(12)) = True) Then

            'Combo para Usuario = Coordinador RH con movimiento confirmado.
            cbo = "<select onchange='mostrarCboAsistencia(this);' disabled id='cbo" & intContador.ToString() & "' name='cbo" & intContador.ToString() & "' class='campotabla' style='width:85px'>"
        Else

            'Combo para Usuario = Aministrador o Usuario = Coordinador RH sin confirmar movimiento.
            cbo = "<select onchange='mostrarCboAsistencia(this);' id='cbo" & intContador.ToString() & "' name='cbo" & intContador.ToString() & "' class='campotabla' style='width:85px'>"
        End If

        'Como primera opcion seleccionada = Movimiento del registro.
        cbo = cbo & "<option selected='selected' value='" & CStr(strConsultaRegistroDetalle(10)) & "'>" & CStr(strConsultaRegistroDetalle(10)) & " " & CStr(strConsultaRegistroDetalle(11)) & "</option>"

        'Si el registro ha sido ajustado se carga el movimiento original por si existio error se pueda regresar al movimiento original.
        If Not (CInt(strConsultaRegistroDetalle(7)) = CInt(strConsultaRegistroDetalle(10))) Then
            cbo = cbo & "<option value='" & CStr(strConsultaRegistroDetalle(7)) & "'>" & CStr(strConsultaRegistroDetalle(7)) & " " & CStr(strConsultaRegistroDetalle(8)) & "</option>"
        End If

        'Consulta de movimientos para ajuste.
        astrRecords = Benavides.CC.Data.clsControlDeAsistencia.strObtenerMovimientosAConfirmar(CInt(strConsultaRegistroDetalle(7)), strConnectionString)

        If IsArray(astrRecords) AndAlso (astrRecords.Length > 0) Then

            Dim i As Integer
            i = 0

            'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
            For Each strRegistroDetalle In astrRecords
                i += 1

                If Not CInt(strRegistroDetalle(0)) = CInt(strConsultaRegistroDetalle(10)) AndAlso Not CInt(strRegistroDetalle(0)) = CInt(strConsultaRegistroDetalle(7)) Then
                    cbo = cbo & "<option value='" & CStr(strRegistroDetalle(0)) & "'>" & CStr(strRegistroDetalle(2)) & "</option>"
                End If
            Next
        End If

        cbo = cbo & "</select>"

        Return cbo
    End Function

    Public Function strTablaConsultaResumenHTML(ByVal objConsultaResumen As Array) As String
        Dim strTablaResumenHTML As StringBuilder
        Dim strConsultaMovimientosResumen As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim imgDetalle As String = String.Empty
        Dim intPage As Integer
        Dim intTotal As Integer = 50
        Dim observacion As String = String.Empty
        Dim strControlAsistenciaObservacionesId As String = String.Empty

        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If

        strTablaResumenHTML = New StringBuilder
        strTablaResumenHTML.Append(Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objConsultaResumen.Length, intPage, intTotal, String.Empty, Nothing))

        strTablaResumenHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strTablaResumenHTML.Append("<tr class='trtitulos'>")
        strTablaResumenHTML.Append("<th class='rayita' align='center' valign='top'>No.</th>")
        strTablaResumenHTML.Append("<th class='rayita' align='center' valign='top'>Empleado</th>")
        strTablaResumenHTML.Append("<th class='rayita' align='center' valign='top'>Centro Logístico</th>")
        strTablaResumenHTML.Append("<th class='rayita' align='center' valign='top'>Sucursal</th>")
        strTablaResumenHTML.Append("<th class='rayita' align='center' valign='top'>Movimiento</th>")
        strTablaResumenHTML.Append("<th class='rayita' align='center' valign='top'>Descripcion</th>")
        strTablaResumenHTML.Append("<th class='rayita' align='center' valign='top'>Obs.</th>")
        strTablaResumenHTML.Append("<th class='rayita' align='center' valign='top'>Cantidad</th>")
        strTablaResumenHTML.Append("<th class='rayita' align='center' valign='top'>&nbsp;</th>")
        strTablaResumenHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaResumen.Length) Then
                Exit For
            End If

            strConsultaMovimientosResumen = CType(objConsultaResumen.GetValue(intContador), String())

            If Not (strConsultaMovimientosResumen(9) Is "") Then
                observacion = strConsultaMovimientosResumen(9)
            End If

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            If strConsultaMovimientosResumen(10) Is "" Then
                strControlAsistenciaObservacionesId = "-1"
            Else
                strControlAsistenciaObservacionesId = strConsultaMovimientosResumen(10).ToString()
            End If

            'Boton "Ver Detalle".
            imgDetalle = "<img id=" & strConsultaMovimientosResumen(1) & " height='17' src='../static/images/icono_lupa.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerDetalle_onclick(" & strConsultaMovimientosResumen(0) & "," & strConsultaMovimientosResumen(6) & "," & strControlAsistenciaObservacionesId & ")' alt='Ver Detalle'>"

            strTablaResumenHTML.Append("<tr>")

            ' No.
            strTablaResumenHTML.Append("<td id=Division" & intContador & " align=center class=" & strColorRegistro & ">" & strConsultaMovimientosResumen(0) & "</td>")
            ' Empleado
            strTablaResumenHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaMovimientosResumen(1)) & "</td>")
            ' Centro Logistico
            strTablaResumenHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaMovimientosResumen(2)) & "</td>")
            ' Sucursal
            strTablaResumenHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaMovimientosResumen(5)) & "</td>")
            ' Movimiento
            strTablaResumenHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaMovimientosResumen(6) & "</td>")
            ' Descripcion
            strTablaResumenHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaMovimientosResumen(7)) & "</td>")
            ' Observacion
            strTablaResumenHTML.Append("<td align=center class=" & strColorRegistro & ">" & observacion & "</td>")
            ' Cantidad
            strTablaResumenHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaMovimientosResumen(8) & "</td>")
            ' Detalle
            strTablaResumenHTML.Append("<td align=center class=" & strColorRegistro & ">" & imgDetalle & "</td>")
            strTablaResumenHTML.Append("</tr>")
            observacion = ""
        Next

        strTablaResumenHTML.Append("</tr>")
        strTablaResumenHTML.Append("</table>")
        strTablaResumenHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaResumenHTML = strTablaResumenHTML.ToString()
    End Function

    Private Function ObtenerAsistenciaObservaciones(ByVal strAsistenciaObs As String, ByVal intContador As Integer, ByVal mostrarCboMovimientoAjuste As Boolean) As String
        Dim resultado As String = String.Empty
        Dim strDesplegar As String = String.Empty

        If Not mostrarCboMovimientoAjuste Then
            strDesplegar = "style='display:none'"
        End If

        resultado = String.Format("<select {0} id='cboAsistencia{1}' name='cboAsistencia{1}' class='campotabla' style='width:85px'>{2}</ select>" _
                      , strDesplegar, intContador.ToString(), strAsistenciaObs)

        Return resultado
    End Function

    Private Function ConsultarAsistenciaObservaciones() As String(,)
        Dim strResultadoConsulta As Array
        Dim registro As New System.Collections.SortedList
        Dim contador As Integer = 0

        strResultadoConsulta = clsControlDeAsistencia.clsControlAsistenciaObservaciones.strConsultartblControlAsistenciaObservacionesPorActivo(strConnectionString)

        Dim arrIdNombre(strResultadoConsulta.Length - 1, 1) As String

        For renglon As Integer = 0 To strResultadoConsulta.Length - 1
            If contador <= strResultadoConsulta.Length - 1 Then
                registro = CType(strResultadoConsulta.GetValue(contador), Collections.SortedList)
                arrIdNombre(renglon, 0) = registro.Item("intControlAsistenciaObservacionesId").ToString()
                arrIdNombre(renglon, 0 + 1) = registro.Item("strControlAsistenciaObservacionesNombre").ToString()
                contador = contador + 1
            End If
        Next

        Return arrIdNombre
    End Function

    Private Function FormarOpcionesSelectConSeleccion(ByVal arrResultado As String(,), ByVal intControlAsistenciaObservacionesId As Integer) As String
        Dim cboResultado As New StringBuilder
        Dim cantidadRegistros As Integer = CInt(arrResultado.Length / 2.0) - 1

        For renglon As Integer = 0 To cantidadRegistros

            If intControlAsistenciaObservacionesId = CInt(arrResultado(renglon, 0)) Then
                cboResultado.AppendFormat("<option selected='selected' value=""{0}"">{1}</option>", _
                                             arrResultado(renglon, 0), _
                                             arrResultado(renglon, 1))
            Else
                cboResultado.AppendFormat("<option value=""{0}"">{1}</option>", _
                                             arrResultado(renglon, 0), _
                                             arrResultado(renglon, 1))
            End If
        Next

        Return cboResultado.ToString()
    End Function

    Private Function FormarOpcionesSelectSinSeleccion(ByVal arrResultado As String(,)) As String
        Dim cboResultado As New StringBuilder
        Dim cantidadRegistros As Integer = CInt(arrResultado.Length / 2.0) - 1

        cboResultado.AppendFormat("<option value=""0""></option>")

        For renglon As Integer = 0 To cantidadRegistros

            cboResultado.AppendFormat("<option value=""{0}"">{1}</option>", _
                                             arrResultado(renglon, 0), _
                                             arrResultado(renglon, 1))
        Next

        Return cboResultado.ToString()
    End Function

#Region "Imprimir"

    '====================================================================
    ' Name       : strImpresionMovimientosDetalle
    ' Description: Generacion de tabla HTML con formato para imprimir resultados de la consulta.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImpresionMovimientosDetalle(ByVal objDataArrayMovimientos As Array) As String
        'Variables
        Dim strImpresionMovimientosHTML As StringBuilder = New StringBuilder
        Dim strRegistroMovimientos As String()
        Dim strclase As String = String.Empty
        Dim intRenglonesxPagina As Integer = 58
        Dim strConfirmado As String

        'Rutina que solo se ejecuta al contener informacion de la consulta.
        If IsArray(objDataArrayMovimientos) AndAlso (objDataArrayMovimientos.Length > 0) Then

            Dim intTotalRenglones As Integer = objDataArrayMovimientos.Length
            Dim intTotalPaginas As Integer = 0
            Dim intPagina As Integer = 0
            Dim intRenglon As Integer = 0
            Dim intContadorRenglon As Integer = 0

            'Total de paginas a imprimir.
            intTotalPaginas = CInt(intTotalRenglones \ intRenglonesxPagina)

            'Si se necesita una pagina mas se agrega.
            If intTotalRenglones Mod intRenglonesxPagina > 0 Then
                intTotalPaginas += 1
            End If

            'Inicio de ciclo que da formato a la informacion a imprimir.
            For Each strRegistroMovimientos In objDataArrayMovimientos

                intRenglon += 1
                intContadorRenglon += 1

                If intRenglon = 1 Then
                    intPagina += 1

                    'Salto de hoja
                    If intPagina > 1 Then
                        strImpresionMovimientosHTML.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")
                    End If

                    strImpresionMovimientosHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    'Metodo que genera y da formato al encabezado.
                    strImpresionMovimientosHTML.Append(strImprimeEncabezadoDetalle(intPagina.ToString, intTotalPaginas.ToString))
                End If

                'Clases para renglones.
                If ((intRenglon Mod 2) = 0) Then
                    strclase = "tdtxtImpresionNormal"
                Else
                    strclase = "tdtxtImpresionBold"
                End If

                strConfirmado = "No"

                If (CBool(strRegistroMovimientos(12)) = True) Then
                    strConfirmado = "Si"
                End If

                strImpresionMovimientosHTML.Append("<tr>")
                ' No
                strImpresionMovimientosHTML.Append("<td width='6%' align='left' class='" & strclase & "' nowrap >" & clsCommons.strFormatearDescripcion(strRegistroMovimientos(1)).ToString & "</td>")
                ' Empleado
                strImpresionMovimientosHTML.Append("<td width='16%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroMovimientos(2)).ToString & "</td>")
                ' Hora Entrada
                strImpresionMovimientosHTML.Append("<td width='16%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroMovimientos(15)).ToString & "</td>")
                ' Hora Salida
                strImpresionMovimientosHTML.Append("<td width='16%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroMovimientos(16)).ToString & "</td>")
                ' Centro Logistico
                strImpresionMovimientosHTML.Append("<td width='7%' align='center' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroMovimientos(3)) & "</td>")
                ' Sucursal
                strImpresionMovimientosHTML.Append("<td width='15%' align='left' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroMovimientos(6)) & "</td>")
                'Movimiento
                strImpresionMovimientosHTML.Append("<td width='6%' align='center' class='" & strclase & "' >" & strRegistroMovimientos(7) & "</td>")
                'Descripcion
                strImpresionMovimientosHTML.Append("<td width='16%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroMovimientos(8)) & "</td>")
                'Fecha Fin
                strImpresionMovimientosHTML.Append("<td width='7%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearFechaPresentacion(strRegistroMovimientos(9)) & "</td>")
                'Movimiento
                strImpresionMovimientosHTML.Append("<td width='6%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroMovimientos(10)) & "</td>")
                'Descripcion
                strImpresionMovimientosHTML.Append("<td width='12%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroMovimientos(11)) & "</td>")
                'Observación
                strImpresionMovimientosHTML.Append("<td width='16%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroMovimientos(14)) & "</td>")
                'Confirmacion
                strImpresionMovimientosHTML.Append("<td width='5%' align='center' class='" & strclase & "' >" & strConfirmado & "</td>")
                strImpresionMovimientosHTML.Append("</tr>")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionMovimientosHTML.Append("</table>")
                    intRenglon = 0
                End If
            Next
        End If

        Return strImpresionMovimientosHTML.ToString()
    End Function

    Private Function strImprimeEncabezadoDetalle(ByVal strHojaActual As String, ByVal strHojaFinal As String) As String
        Dim strHtmlEncabezado As StringBuilder
        strHtmlEncabezado = New StringBuilder

        'Encabezado principal
        strHtmlEncabezado.Append("<tr>")
        strHtmlEncabezado.Append("<td colspan='11'>")
        strHtmlEncabezado.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='10' class='tdtxtBold'>Control de Asistencia</th>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='7%' align='left' class='tdtxtBold'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th width='50%' align='center' class='tdtxtBold' nowrap> ADS Central </th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='23%' align='left'  class='tdtxtBold'>HOJA " & strHojaActual & " / " & strHojaFinal & " </th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strHtmlEncabezado.Append("</td>")

        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th class='tdtxtBold' colspan='11'></th>")
        strHtmlEncabezado.Append("<th class='tdtxtBold' align='center' colspan='5' nowrap>Confirmación</th>")
        strHtmlEncabezado.Append("<th class='tdtxtBold'></th>")
        strHtmlEncabezado.Append("</tr>")

        'Encabezado titulos
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='6%' class='tdtxtBold' align='center' nowrap>No.</th>")
        strHtmlEncabezado.Append("<th width='16%' class='tdtxtBold' align='center' nowrap>Empleado</th>")
        strHtmlEncabezado.Append("<th width='16%' class='tdtxtBold' align='center' nowrap>Hora Entrada</th>")
        strHtmlEncabezado.Append("<th width='16%' class='tdtxtBold' align='center' nowrap>Hora Salida</th>")
        strHtmlEncabezado.Append("<th width='7%' class='tdtxtBold' align='center' nowrap>Centro Logístico</th>")
        strHtmlEncabezado.Append("<th width='15%' class='tdtxtBold' align='center' nowrap>Sucursal</th>")
        strHtmlEncabezado.Append("<th width='6%' class='tdtxtBold' align='center' nowrap>Movimiento</th>")
        strHtmlEncabezado.Append("<th width='16%' class='tdtxtBold' align='center' nowrap>Descripción</th>")
        strHtmlEncabezado.Append("<th width='7%' class='tdtxtBold' align='center' nowrap>Fecha</th>")
        strHtmlEncabezado.Append("<th width='6%' class='tdtxtBold' align='center' nowrap>Movimiento</th>")
        strHtmlEncabezado.Append("<th width='16%' class='tdtxtBold' align='center' nowrap>Descripción</th>")
        strHtmlEncabezado.Append("<th width='12%' class='tdtxtBold' align='center' nowrap>Obs.</th>")
        ' strHtmlEncabezado.Append("<th width='16%' class='tdtxtBold' align='center' nowrap>Obs.</th>")
        strHtmlEncabezado.Append("<th width='5%' class='tdtxtBold' align='center' nowrap>Confirmación</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' class='rayita' colspan='13'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        strImprimeEncabezadoDetalle = strHtmlEncabezado.ToString()
    End Function

    'Resumen
    '====================================================================
    ' Name       : strImpresionMovimientosResumen
    ' Description: Generacion de tabla HTML con formato para imprimir resultados de la consulta.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImpresionMovimientosResumen(ByVal objDataArrayMovimientos As Array) As String

        'Variables
        Dim strImpresionMovimientosHTML As StringBuilder = New StringBuilder
        Dim strRegistroMovimientos As String()
        Dim strclase As String = String.Empty
        Dim intRenglonesxPagina As Integer = 58

        'Rutina que solo se ejecuta al contener informacion de la consulta.
        If IsArray(objDataArrayMovimientos) AndAlso (objDataArrayMovimientos.Length > 0) Then

            Dim intTotalRenglones As Integer = objDataArrayMovimientos.Length
            Dim intTotalPaginas As Integer = 0
            Dim intPagina As Integer = 0
            Dim intRenglon As Integer = 0
            Dim intContadorRenglon As Integer = 0

            'Total de paginas a imprimir.
            intTotalPaginas = CInt(intTotalRenglones \ intRenglonesxPagina)

            'Si se necesita una pagina mas se agrega.
            If intTotalRenglones Mod intRenglonesxPagina > 0 Then
                intTotalPaginas += 1
            End If

            'Inicio de ciclo que da formato a la informacion a imprimir.
            For Each strRegistroMovimientos In objDataArrayMovimientos

                intRenglon += 1
                intContadorRenglon += 1

                If intRenglon = 1 Then
                    intPagina += 1

                    'Salto de hoja
                    If intPagina > 1 Then
                        strImpresionMovimientosHTML.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")
                    End If

                    strImpresionMovimientosHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    'Metodo que genera y da formato al encabezado.
                    strImpresionMovimientosHTML.Append(strImprimeEncabezadoResumen(intPagina.ToString, intTotalPaginas.ToString))
                End If

                'Clases para renglones.
                If ((intRenglon Mod 2) = 0) Then
                    strclase = "tdtxtImpresionNormal"
                Else
                    strclase = "tdtxtImpresionBold"
                End If

                strImpresionMovimientosHTML.Append("<tr>")
                ' No
                strImpresionMovimientosHTML.Append("<td width='10%' align='left' class='" & strclase & "' nowrap >" & strRegistroMovimientos(0).ToString & "</td>")
                ' Empleado
                strImpresionMovimientosHTML.Append("<td width='25%' align='left' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroMovimientos(1)).ToString & "</td>")
                ' Centro Logistico
                strImpresionMovimientosHTML.Append("<td width='10%' align='center' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroMovimientos(2)) & "</td>")
                ' Sucursal
                strImpresionMovimientosHTML.Append("<td width='20%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroMovimientos(5)) & "</td>")
                'Movimiento
                strImpresionMovimientosHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & strRegistroMovimientos(6).ToString() & "</td>")
                'Descripcion
                strImpresionMovimientosHTML.Append("<td width='20%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroMovimientos(7)) & "</td>")
                'Obs.
                strImpresionMovimientosHTML.Append("<td width='20%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroMovimientos(9)) & "</td>")
                'Cantidad
                strImpresionMovimientosHTML.Append("<td width='5%' align='center' class='" & strclase & "' >" & strRegistroMovimientos(8).ToString() & "</td>")
                strImpresionMovimientosHTML.Append("</tr>")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionMovimientosHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next

        End If

        Return strImpresionMovimientosHTML.ToString()

    End Function

    Private Function strImprimeEncabezadoResumen(ByVal strHojaActual As String, ByVal strHojaFinal As String) As String

        Dim strHtmlEncabezado As StringBuilder
        strHtmlEncabezado = New StringBuilder

        'Encabezado principal
        strHtmlEncabezado.Append("<tr>")
        strHtmlEncabezado.Append("<td colspan='7'>")
        strHtmlEncabezado.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='7' class='tdtxtBold'>Control de Asistencia</th>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='10%' align='left'   class='tdtxtBold'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th width='50%' align='center' class='tdtxtBold' nowrap> ADS Central </th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='20%' align='left'  class='tdtxtBold'>HOJA " & strHojaActual & " / " & strHojaFinal & " </th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strHtmlEncabezado.Append("</td>")
        strHtmlEncabezado.Append("</tr>")

        'Encabezado titulos
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>No.</th>")
        strHtmlEncabezado.Append("<th width='25%' class='tdtxtBold' align='center' nowrap>Empleado</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Centro Logístico</th>")
        strHtmlEncabezado.Append("<th width='20%' class='tdtxtBold' align='center' nowrap>Sucursal</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Movimiento</th>")
        strHtmlEncabezado.Append("<th width='20%' class='tdtxtBold' align='center' nowrap>Descripción</th>")
        strHtmlEncabezado.Append("<th width='20%' class='tdtxtBold' align='center' nowrap>Obs.</th>")
        strHtmlEncabezado.Append("<th width='5%' class='tdtxtBold' align='center' nowrap>Cantidad</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' class='rayita' colspan='8'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        strImprimeEncabezadoResumen = strHtmlEncabezado.ToString
    End Function

#End Region

#Region "Exportar"

    Public Function strTablaConsultaResumenExportar(ByVal objConsultaResumen As Array) As String

        Dim strTablaMovimientosHTML As StringBuilder
        Dim strConsultaResumen As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer

        strTablaMovimientosHTML = New StringBuilder
        strTablaMovimientosHTML.Append("<span class='txsubtitulo'> </span> ")
        strTablaMovimientosHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strTablaMovimientosHTML.Append("<tr class='trtitulos'>")
        strTablaMovimientosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>No.</th>")
        strTablaMovimientosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Empleado</th>")
        strTablaMovimientosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Centro Logistico</th>")
        strTablaMovimientosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Sucursal</th>")
        strTablaMovimientosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Movimiento</th>")
        strTablaMovimientosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Descripcion</th>")
        strTablaMovimientosHTML.Append("<th class='rayita' align='center' valign='top'>Obs.</th>")
        strTablaMovimientosHTML.Append("<th width='8%' align=center class='rayita' align='left' valign='top'>Cantidad</th>")
        strTablaMovimientosHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For Each strConsultaResumen In objConsultaResumen
            intContador = intContador + 1

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strTablaMovimientosHTML.Append("<tr>")

            'No.               
            strTablaMovimientosHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaResumen(0).ToString() & "</td>")
            'Empleado
            strTablaMovimientosHTML.Append("<td align=left id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaResumen(1)) & "</td>")
            'Centro Logistico                  
            strTablaMovimientosHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaResumen(2)) & "</td>")
            'Sucursal
            strTablaMovimientosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaResumen(5)) & "</td>")
            'Movimiento
            strTablaMovimientosHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaResumen(6) & "</td>")
            'Descripcion
            strTablaMovimientosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaResumen(7)) & "</td>")
            ' Observación
            strTablaMovimientosHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaResumen(9) & "</td>")
            'Cantidad
            strTablaMovimientosHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaResumen(8) & "</td>")
            strTablaMovimientosHTML.Append("</tr>")
        Next
        strTablaMovimientosHTML.Append("</tr>")
        strTablaMovimientosHTML.Append("</table>")
        strTablaConsultaResumenExportar = strTablaMovimientosHTML.ToString
    End Function

    Public Function strTablaConsultaDetalleExportar(ByVal objConsultaExportaDetalle As Array) As String
        Dim strTablaEspaciosHTML As StringBuilder
        Dim strConsultaExportaDetalle As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim strConfirmado As String
        Dim imgDetalle As String = Nothing

        strTablaEspaciosHTML = New StringBuilder
        strTablaEspaciosHTML.Append("<span class='txsubtitulo'></span> ")
        strTablaEspaciosHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        strTablaEspaciosHTML.Append("<tr class='trtitulos'>")
        strTablaEspaciosHTML.Append("<th class='rayita' colspan='7'></th>")
        strTablaEspaciosHTML.Append("<th class='rayita' align='center' valign='top' colspan='4'>Confirmación</th>")
        strTablaEspaciosHTML.Append("<th class='rayita'></th>")
        strTablaEspaciosHTML.Append("</tr>")

        strTablaEspaciosHTML.Append("<tr class='trtitulos'>")
        strTablaEspaciosHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>No</th>")
        strTablaEspaciosHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Empleado</th>")
        strTablaEspaciosHTML.Append("<th width='16%' class='tdtxtBold' align='center' nowrap>Hora Entrada</th>")
        strTablaEspaciosHTML.Append("<th width='16%' class='tdtxtBold' align='center' nowrap>Hora Salida</th>")
        strTablaEspaciosHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Centro Logistico</th>")
        strTablaEspaciosHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Sucursal</th>")
        strTablaEspaciosHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Movimiento</th>")
        strTablaEspaciosHTML.Append("<th width='8%' class='rayita' align='center' valign='top'>Descripción</th>")
        strTablaEspaciosHTML.Append("<th width='8%' class='rayita' align='center' valign='top'>Fecha</th>")
        strTablaEspaciosHTML.Append("<th width='4%' class='rayita' align='center' valign='top'>Movimiento</th>")
        strTablaEspaciosHTML.Append("<th width='4%' class='rayita' align='center' valign='top'>Descripción</th>")
        strTablaEspaciosHTML.Append("<th width='4%' class='rayita' align='center' valign='top'>Obs.</th>")
        strTablaEspaciosHTML.Append("<th width='4%' class='rayita' align='center' valign='top'>Confirmado</th>")

        strTablaEspaciosHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For Each strConsultaExportaDetalle In objConsultaExportaDetalle
            intContador = intContador + 1

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strConfirmado = "No"

            If (CBool(strConsultaExportaDetalle(12)) = True) Then
                strConfirmado = "Si"
            End If

            strTablaEspaciosHTML.Append("<tr>")

            'No.                
            strTablaEspaciosHTML.Append("<td align='left' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExportaDetalle(1)) & "</td>")
            'Empleado
            strTablaEspaciosHTML.Append("<td align='left' id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExportaDetalle(2)) & "</td>")

            strTablaEspaciosHTML.Append("<td align='center' class=" & strColorRegistro & ">" & strConsultaExportaDetalle(15) & "</td>")
            strTablaEspaciosHTML.Append("<td align='center' class=" & strColorRegistro & ">" & strConsultaExportaDetalle(16) & "</td>")

            'Centro Logistico                  
            strTablaEspaciosHTML.Append("<td align='center' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExportaDetalle(3)) & "</td>")
            'Sucursal
            strTablaEspaciosHTML.Append("<td align='left' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExportaDetalle(6)) & "</td>")
            'Movimiento
            strTablaEspaciosHTML.Append("<td align='center' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExportaDetalle(7)) & "</td>")
            'Descripcion
            strTablaEspaciosHTML.Append("<td align='left' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExportaDetalle(8)) & "</td>")
            'Fecha 
            strTablaEspaciosHTML.Append("<td align='center' class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaExportaDetalle(9)) & "</td>")
            'Movimiento
            strTablaEspaciosHTML.Append("<td align='center' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExportaDetalle(10)) & "</td>")
            'Descripcion
            strTablaEspaciosHTML.Append("<td align='left' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExportaDetalle(11)) & "</td>")
            'Obs
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaExportaDetalle(14) & "</td>")
            'Confirmado
            strTablaEspaciosHTML.Append("<td align='center' class=" & strColorRegistro & ">" & strConfirmado & "</td>")
            strTablaEspaciosHTML.Append("</tr>")

        Next
        strTablaEspaciosHTML.Append("</tr>")
        strTablaEspaciosHTML.Append("</table>")
        strTablaConsultaDetalleExportar = strTablaEspaciosHTML.ToString
    End Function

#End Region

End Class