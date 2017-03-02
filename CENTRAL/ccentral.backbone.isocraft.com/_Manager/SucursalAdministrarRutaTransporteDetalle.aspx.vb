Imports System.Text
Imports System.Collections
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert

Public Class SucursalAdministrarRutaTransporteDetalle
    Inherits PaginaBase

    Private _intRutaTransportesId As Integer
    Private _strRutaTransportesClave As String
    Private _strRutaTransportesTipoNombre As String
    Private _strDestinoNombre As String
    Private _strProveedorNombre As String
    Private _intTolerancia As Integer

    Private _blnCambiarSucursalDeRutaAlGuardar As Boolean = False
    Private _blnCambiarSucursalDeRutaAlActualizar As Boolean = False

    Private _intRutaTransportesSucursalIdReasignar As Integer
    Private _intRutaTransportesIdReasignar As Integer
    Private _intRutaTransportesSucursalIdEliminar As Integer

    Public ReadOnly Property strCmd2() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd2", "")
        End Get
    End Property

    Public ReadOnly Property intRutaTransportesId() As Integer
        Get
            If Not Request.QueryString("intRutaTransportesId") Is Nothing Then
                _intRutaTransportesId = CInt(Request.QueryString("intRutaTransportesId"))
            ElseIf Not Request.Form("hdnRutaTransportesId") Is Nothing Then
                _intRutaTransportesId = CInt(Request.Form("hdnRutaTransportesId"))
            End If
            Return _intRutaTransportesId
        End Get
    End Property

    Public ReadOnly Property strRutaTransportesClave() As String
        Get
            If Not Request.QueryString("strRutaTransportesClave") Is Nothing Then
                _strRutaTransportesClave = Request.QueryString("strRutaTransportesClave")
            ElseIf Not Request.Form("hdnRutaTransportesClave") Is Nothing Then
                _strRutaTransportesClave = Request.Form("hdnRutaTransportesClave")
            End If
            Return _strRutaTransportesClave
        End Get
    End Property

    Public ReadOnly Property strRutaTransportesTipoNombre() As String
        Get
            If Not Request.QueryString("strRutaTransportesTipoNombre") Is Nothing Then
                _strRutaTransportesTipoNombre = Request.QueryString("strRutaTransportesTipoNombre")
            ElseIf Not Request.Form("hdnRutaTransportesTipoNombre") Is Nothing Then
                _strRutaTransportesTipoNombre = Request.Form("hdnRutaTransportesTipoNombre")
            End If
            Return _strRutaTransportesTipoNombre
        End Get
    End Property

    Public ReadOnly Property strDestinoNombre() As String
        Get
            If Not Request.QueryString("strDestinoNombre") Is Nothing Then
                _strDestinoNombre = Request.QueryString("strDestinoNombre")
            ElseIf Not Request.Form("hdnDestinoNombre") Is Nothing Then
                _strDestinoNombre = Request.Form("hdnDestinoNombre")
            End If
            Return _strDestinoNombre
        End Get
    End Property

    Public ReadOnly Property strProveedorNombre() As String
        Get
            If Not IsNothing(Request.QueryString("strProveedorNombre")) Then
                _strProveedorNombre = Request.QueryString("strProveedorNombre")
            ElseIf Not IsNothing(Request.Form("hdnProveedorNombre")) Then
                _strProveedorNombre = Request.Form("hdnProveedorNombre")
            End If
            Return _strProveedorNombre
        End Get
    End Property

    Public ReadOnly Property intTolerancia() As Integer
        Get
            If Not Request.QueryString("intTolerancia") Is Nothing Then
                _intTolerancia = CInt(Request.QueryString("intTolerancia"))
            ElseIf Not Request.Form("hdnTolerancia") Is Nothing Then
                _intTolerancia = CInt(Request.Form("hdnTolerancia"))
            End If
            Return _intTolerancia
        End Get
    End Property

    Public ReadOnly Property intRutaTransportesSucursalId() As Integer
        Get
            If Not GetPageParameter("intRutaTransportesSucursalId", "") = "" Then
                Return CInt(GetPageParameter("intRutaTransportesSucursalId", "0"))
            End If
        End Get
    End Property

    Public ReadOnly Property strCentroLogisticoId() As String
        Get
            Return GetPageParameter("strCentroLogisticoId", "")
        End Get
    End Property

    Public ReadOnly Property strHoraEntrega() As String
        Get
            Return GetPageParameter("strHoraEntrega", "")
        End Get
    End Property

    Public ReadOnly Property intRutaTransportesFrecuenciaId() As Integer
        Get
            Return CInt(GetPageParameter("intRutaTransportesFrecuenciaId", "0"))
        End Get
    End Property

    Public ReadOnly Property intFrecuencia() As Integer
        Get
            If Not GetPageParameter("intFrecuencia", "") = "" Then
                Return CInt(GetPageParameter("intFrecuencia", "0"))
            End If
        End Get
    End Property

    Public ReadOnly Property strRutaTransportesDiaSurtido() As String
        Get
            Return GetPageParameter("strRutaTransportesDiaSurtido", "")
        End Get
    End Property

    Public ReadOnly Property strRutaTransportesDiaEntrega() As String
        Get
            Return GetPageParameter("strRutaTransportesDiaEntrega", "")
        End Get
    End Property

    Public ReadOnly Property blnCambiarSucursalDeRutaAlGuardar() As Boolean
        Get
            Return _blnCambiarSucursalDeRutaAlGuardar
        End Get
    End Property

    Public ReadOnly Property blnCambiarSucursalDeRutaAlActualizar() As Boolean
        Get
            Return _blnCambiarSucursalDeRutaAlActualizar
        End Get
    End Property

    Public ReadOnly Property intRutaTransportesSucursalIdReasignar() As Integer
        Get
            If Not Request.QueryString("intRutaTransportesSucursalIdReasignar") Is Nothing Then
                _intRutaTransportesSucursalIdReasignar = CInt(GetPageParameter("intRutaTransportesSucursalIdReasignar", "0"))
            End If
            Return _intRutaTransportesSucursalIdReasignar
        End Get
    End Property

    Public ReadOnly Property intRutaTransportesIdReasignar() As Integer
        Get
            If Not Request.QueryString("intRutaTransportesIdReasignar") Is Nothing Then
                _intRutaTransportesIdReasignar = CInt(GetPageParameter("intRutaTransportesIdReasignar", "0"))
            End If
            Return _intRutaTransportesIdReasignar
        End Get
    End Property

    Public ReadOnly Property intRutaTransportesSucursalIdEliminar() As Integer
        Get
            If Not Request.QueryString("intRutaTransportesSucursalIdEliminar") Is Nothing Then
                _intRutaTransportesSucursalIdEliminar = CInt(GetPageParameter("intRutaTransportesSucursalIdEliminar", "0"))
            End If
            Return _intRutaTransportesSucursalIdEliminar
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Select Case strCmd2
                Case "NuevoSucursal"
                    If ValidarExistenciaSucursalTblRutaTransportesSucursal() Then
                        Call GuardarTblRutaTransportesSucursal()
                    End If
                Case "EditarSucursal"
                    If ValidarExistenciaSucursalTblRutaTransportesSucursal() Then
                        Call ActualizarTblRutaTransportesSucursal()
                    End If
                Case "EliminarSucursal"
                    Call EliminarTblRutaTransportesSucursal()
                Case "ReasignarRutaASucursalAlGuardar"
                    Call ReasignarRutaASucursalAlGuardar()
                Case "ReasignarRutaASucursalAlActualizar"
                    Call ReasignarRutaASucursalAlActualizar()
                Case "NuevoFrecuencia"
                    Call GuardarTblRutaTransportesFrecuencia()
                Case "EditarFrecuencia"
                    Call ActualizarTblRutaTransportesFrecuencia()
                Case "EliminarFrecuencia"
                    Call EliminarTblRutaTransportesFrecuencia()
            End Select

        Catch ex As Exception
            Response.Write("Error")
        End Try
    End Sub

    Public Function strObtenerSucursales() As String
        Dim resultadoRutaTransportesSucursal As New StringBuilder
        Dim objRutaTransportesSucursal As Array

        objRutaTransportesSucursal = Benavides.CC.Data.clsRutaTransportes.clsRutaTransportesSucursal.strConsultarTblRutaTransportesSucursal(intRutaTransportesId, strConnectionString)

        If IsArray(objRutaTransportesSucursal) AndAlso objRutaTransportesSucursal.Length > 0 Then
            resultadoRutaTransportesSucursal.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            resultadoRutaTransportesSucursal.Append("<tr class='trtitulos'>")
            resultadoRutaTransportesSucursal.Append("<th class='rayita'>Sucursal</th>")
            resultadoRutaTransportesSucursal.Append("<th class='rayita'>Nombre</th>")
            resultadoRutaTransportesSucursal.Append("<th class='rayita'>Hora</th>")
            resultadoRutaTransportesSucursal.Append("<th class='rayita' colspan='2'>Acción</th>")
            resultadoRutaTransportesSucursal.Append("</tr>")

            resultadoRutaTransportesSucursal.Append(CrearRegistrosSucursal(objRutaTransportesSucursal))

            resultadoRutaTransportesSucursal.Append("</table>")
        End If

        Return resultadoRutaTransportesSucursal.ToString()
    End Function

    Private Function CrearRegistrosSucursal(ByVal registrosRutaTransportesSucursal As Array) As String
        Dim contadorRegistros As Integer = 0
        Dim colorRegistro As String = String.Empty
        Dim resultadoRutaTransportesSucursal As New StringBuilder
        Dim intRutaTransportesSucursalIdRenglon As Integer
        Dim strCentroLogisticoIdRenglon As String = String.Empty
        Dim strSucursalNombreRenglon As String = String.Empty

        Dim strHoraEntregaRenglon As String = String.Empty
        Dim imagenEditar As String = "<img src='../static/images/icono_editar.gif' width='11' height='13' border='0' align='center' alt='Haga clic aquí para editar' title='Haga clic aquí para editar'>"
        Dim imagenEliminar As String = "<img src='../static/images/imgNREliminar.gif' width='11' height='13' border='0' align='center' alt='Haga clic aquí para ver detalle' title='Haga clic aquí para eliminar'>"

        For Each renglon As SortedList In registrosRutaTransportesSucursal
            contadorRegistros += 1

            intRutaTransportesSucursalIdRenglon = CInt(renglon.Item("intRutaTransportesSucursalId"))
            strCentroLogisticoIdRenglon = CStr(renglon.Item("strCentroLogisticoId"))
            strSucursalNombreRenglon = CStr(renglon.Item("strSucursalNombre"))
            strHoraEntregaRenglon = CStr(renglon.Item("strHoraEntrega"))

            If (contadorRegistros Mod 2) <> 0 Then
                colorRegistro = "tdceleste"
            Else
                colorRegistro = "tdblanco"
            End If

            resultadoRutaTransportesSucursal.Append("<tr>")

            resultadoRutaTransportesSucursal.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, strCentroLogisticoIdRenglon)
            resultadoRutaTransportesSucursal.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, strSucursalNombreRenglon)
            resultadoRutaTransportesSucursal.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, strHoraEntregaRenglon)
            resultadoRutaTransportesSucursal.AppendFormat("<td align='center' style='width: 50px;' class='{0}'>" & _
                                                  "<a href='SucursalAdministrarRutaTransporteDetalle.aspx?strCmd2=ActualizarSucursal" & _
                                                  "&intRutaTransportesSucursalId={1}&strCentroLogisticoId={2}" & _
                                                  "&strHoraEntrega={3}" & _
                                                  "&intRutaTransportesId={4}&strRutaTransportesClave={5}" & _
                                                  "&strRutaTransportesTipoNombre={6}" & _
                                                  "&strDestinoNombre={7}&strProveedorNombre={8}&intTolerancia={9}" & _
                                                  "'>{10}</a></td>", _
                                                  colorRegistro, _
                                                  intRutaTransportesSucursalIdRenglon, _
                                                  strCentroLogisticoIdRenglon, _
                                                  strHoraEntregaRenglon, _
                                                  intRutaTransportesId, _
                                                  strRutaTransportesClave, _
                                                  strRutaTransportesTipoNombre, _
                                                  strDestinoNombre, _
                                                  strProveedorNombre, _
                                                  intTolerancia, _
                                                  imagenEditar)

            resultadoRutaTransportesSucursal.AppendFormat("<td align='left' style='width: 50px;' class='{0}'>" & _
                                                  "<a href='SucursalAdministrarRutaTransporteDetalle.aspx?strCmd2=BorrarSucursal" & _
                                                  "&intRutaTransportesSucursalId={1}&strCentroLogisticoId={2}" & _
                                                  "&intRutaTransportesId={3}&strRutaTransportesClave={4}" & _
                                                  "&strRutaTransportesTipoNombre={5}" & _
                                                  "&strDestinoNombre={6}&strProveedorNombre={7}&intTolerancia={8}" & _
                                                  "'>{9}</a></td>", _
                                                  colorRegistro, _
                                                  intRutaTransportesSucursalIdRenglon, _
                                                  strCentroLogisticoIdRenglon, _
                                                  intRutaTransportesId, _
                                                  strRutaTransportesClave, _
                                                  strRutaTransportesTipoNombre, _
                                                  strDestinoNombre, _
                                                  strProveedorNombre, _
                                                  intTolerancia, _
                                                  imagenEliminar)

            resultadoRutaTransportesSucursal.Append("</tr>")
        Next

        Return resultadoRutaTransportesSucursal.ToString()
    End Function

    Private Sub GuardarTblRutaTransportesSucursal()
        Dim resultado As Integer = 0
        Dim strRutaTransportesClaveOriginal As String = String.Empty
        Dim intRutaTransportesSucursalIdResultado As Integer
        Dim intRutaTransportesIdResultado As Integer

        resultado = Benavides.CC.Data.clsRutaTransportes.clsRutaTransportesSucursal.intGuardarTblRutaTransportesSucursal(intRutaTransportesId, _
                                                         strCentroLogisticoId, _
                                                         strHoraEntrega, _
                                                         Date.Now, _
                                                         strUsuarioNombre, _
                                                         strRutaTransportesClaveOriginal, _
                                                         intRutaTransportesSucursalIdResultado, _
                                                         intRutaTransportesIdResultado, _
                                                         strConnectionString)

        If resultado = 1 Then
            _strmJavascriptWindowOnLoadCommands = "Registro guardado correctamente"
        ElseIf resultado = -1 Then
            _strmJavascriptWindowOnLoadCommands = String.Format("La Sucursal {0} ya está asignada. Se encuentra en la Ruta {1}" _
                                                                , strCentroLogisticoId, strRutaTransportesClaveOriginal)
            _blnCambiarSucursalDeRutaAlGuardar = True
            _intRutaTransportesSucursalIdReasignar = intRutaTransportesSucursalIdResultado
            _intRutaTransportesIdReasignar = intRutaTransportesIdResultado
        ElseIf resultado = 0 Then
            _strmJavascriptWindowOnLoadCommands = "Error"
        End If
    End Sub

    Private Sub ActualizarTblRutaTransportesSucursal()
        Dim resultado As Integer = 0
        Dim strRutaTransportesClaveOriginal As String = String.Empty
        Dim intRutaTransportesSucursalIdEliminar As Integer

        resultado = Benavides.CC.Data.clsRutaTransportes.clsRutaTransportesSucursal.intActualizarTblRutaTransportesSucursal(intRutaTransportesSucursalId, _
                                                                                         strCentroLogisticoId, _
                                                                                         strHoraEntrega, _
                                                                                         intRutaTransportesId, _
                                                                                         strRutaTransportesClaveOriginal, _
                                                                                         intRutaTransportesSucursalIdEliminar, _
                                                                                         Date.Now, _
                                                                                         strUsuarioNombre, _
                                                                                         strConnectionString)

        If resultado = 1 Then
            _strmJavascriptWindowOnLoadCommands = "Registro editado correctamente"
        ElseIf resultado = -1 Then
            _strmJavascriptWindowOnLoadCommands = String.Format("La Sucursal {0} ya está asignada. Se encuentra en la Ruta {1}" _
                                                                , strCentroLogisticoId, strRutaTransportesClaveOriginal)
            _blnCambiarSucursalDeRutaAlActualizar = True
            _intRutaTransportesSucursalIdReasignar = intRutaTransportesSucursalId
            _intRutaTransportesIdReasignar = intRutaTransportesId
            _intRutaTransportesSucursalIdEliminar = intRutaTransportesSucursalIdEliminar
        ElseIf resultado = -2 Then
            _strmJavascriptWindowOnLoadCommands = "No se puede reasignar una Sucursal de una misma Ruta"
        ElseIf resultado = 0 Then
            _strmJavascriptWindowOnLoadCommands = "Error"
        End If
    End Sub

    Private Sub EliminarTblRutaTransportesSucursal()
        Dim resultado As Integer = 0

        resultado = Benavides.CC.Data.clsRutaTransportes.clsRutaTransportesSucursal.intEliminarTblRutaTransportesSucursal(intRutaTransportesSucursalId, strConnectionString)

        If resultado = 1 Then
            _strmJavascriptWindowOnLoadCommands = String.Format("La Sucursal {0} fué eliminada correctamente" _
                                                                , strCentroLogisticoId)
        ElseIf resultado = -1 Then
            _strmJavascriptWindowOnLoadCommands = "Hubo un error al eliminar el registro seleccionado"
        End If
    End Sub

    Private Function ValidarExistenciaSucursalTblRutaTransportesSucursal() As Boolean
        Dim blnExisteSucursal As Boolean = True
        Dim resultado As Integer = 0

        resultado = Benavides.CC.Data.clsRutaTransportes.clsRutaTransportesSucursal.intValidarExistenciaSucursalTblRutaTransportesSucursal(strCentroLogisticoId, strConnectionString)

        If resultado = 0 Then
            blnExisteSucursal = False
            _strmJavascriptWindowOnLoadCommands = "La sucursal escrita no existe"
        End If

        Return blnExisteSucursal
    End Function

    Private Sub ReasignarRutaASucursalAlGuardar()
        Dim resultado As Integer = 0

        resultado = Benavides.CC.Data.clsRutaTransportes.clsRutaTransportesSucursal.intReasignarRutaASucursalAlGuardar(intRutaTransportesSucursalIdReasignar, _
                                                                         intRutaTransportesIdReasignar, _
                                                                         strCentroLogisticoId, _
                                                                         strHoraEntrega, _
                                                                         Date.Now, _
                                                                         strUsuarioNombre, _
                                                                         strConnectionString)

        If resultado = 1 Then
            _strmJavascriptWindowOnLoadCommands = "Registro editado correctamente"
        ElseIf resultado = 0 Or resultado = -1 Then
            _strmJavascriptWindowOnLoadCommands = "Error"
        End If
    End Sub

    Private Sub ReasignarRutaASucursalAlActualizar()
        Dim resultado As Integer = 0

        resultado = Benavides.CC.Data.clsRutaTransportes.clsRutaTransportesSucursal.intReasignarRutaASucursalAlActualizar(intRutaTransportesSucursalId, _
                                                                              intRutaTransportesId, _
                                                                              strCentroLogisticoId, _
                                                                              strHoraEntrega, _
                                                                              intRutaTransportesSucursalIdEliminar, _
                                                                              Date.Now, _
                                                                              strUsuarioNombre, _
                                                                              strConnectionString)

        If resultado = 1 Then
            _strmJavascriptWindowOnLoadCommands = "Registro guardado correctamente"
        ElseIf resultado = -1 Then
            _strmJavascriptWindowOnLoadCommands = "Error"
        End If
    End Sub

    Public Function strObtenerFrecuencias() As String
        Dim resultadoRutaTransportesFrecuencia As New StringBuilder
        Dim objRutaTransportesFrecuencia As Array

        objRutaTransportesFrecuencia = Benavides.CC.Data.clsRutaTransportes. _
                                        clsRutaTransportesFrecuencia.strConsultarTblRutaTransportesFrecuencia(intRutaTransportesId, strConnectionString)

        If IsArray(objRutaTransportesFrecuencia) AndAlso objRutaTransportesFrecuencia.Length > 0 Then
            resultadoRutaTransportesFrecuencia.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            resultadoRutaTransportesFrecuencia.Append("<tr class='trtitulos'>")
            resultadoRutaTransportesFrecuencia.Append("<th class='rayita'>Frecuencia</th>")
            resultadoRutaTransportesFrecuencia.Append("<th class='rayita'>Surtido</th>")
            resultadoRutaTransportesFrecuencia.Append("<th class='rayita'>Entrega</th>")
            resultadoRutaTransportesFrecuencia.Append("<th class='rayita' colspan='2'>Acción</th>")
            resultadoRutaTransportesFrecuencia.Append("</tr>")

            resultadoRutaTransportesFrecuencia.Append(CrearRegistrosFrecuencia(objRutaTransportesFrecuencia))

            resultadoRutaTransportesFrecuencia.Append("</table>")
        End If

        Return resultadoRutaTransportesFrecuencia.ToString()
    End Function

    Private Function CrearRegistrosFrecuencia(ByVal registrosRutaTransportesFrecuencia As Array) As String
        Dim contadorRegistros As Integer = 0
        Dim colorRegistro As String = String.Empty
        Dim resultadoRutaTransportesFrecuencia As New StringBuilder
        Dim intRutaTransportesFrecuenciaIdRenglon As Integer
        Dim intFrecuenciaRenglon As Integer
        Dim strRutaTransportesDiaSurtidoRenglon As String = String.Empty
        Dim strRutaTransportesDiaEntregaRenglon As String = String.Empty
        Dim imagenEditar As String = "<img src='../static/images/icono_editar.gif' width='11' height='13' border='0' align='center' alt='Haga clic aquí para editar' title='Haga clic aquí para editar'>"
        Dim imagenEliminar As String = "<img src='../static/images/imgNREliminar.gif' width='11' height='13' border='0' align='center' alt='Haga clic aquí para eliminar' title='Haga clic aquí para eliminar'>"

        For Each renglon As SortedList In registrosRutaTransportesFrecuencia
            contadorRegistros += 1

            intRutaTransportesFrecuenciaIdRenglon = CInt(renglon.Item("intRutaTransportesFrecuenciaId"))
            intFrecuenciaRenglon = CInt(renglon.Item("intFrecuencia"))
            strRutaTransportesDiaSurtidoRenglon = CStr(renglon.Item("strRutaTransportesDiaSurtido"))
            strRutaTransportesDiaEntregaRenglon = CStr(renglon.Item("strRutaTransportesDiaEntrega"))

            If (contadorRegistros Mod 2) <> 0 Then
                colorRegistro = "tdceleste"
            Else
                colorRegistro = "tdblanco"
            End If

            resultadoRutaTransportesFrecuencia.Append("<tr>")

            resultadoRutaTransportesFrecuencia.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, intFrecuenciaRenglon)
            resultadoRutaTransportesFrecuencia.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, strRutaTransportesDiaSurtidoRenglon)
            resultadoRutaTransportesFrecuencia.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, strRutaTransportesDiaEntregaRenglon)

            resultadoRutaTransportesFrecuencia.AppendFormat("<td align='center' style='width: 50px;' class='{0}'>" & _
                                                  "<a href='SucursalAdministrarRutaTransporteDetalle.aspx?strCmd2=ActualizarFrecuencia" & _
                                                  "&intRutaTransportesFrecuenciaId={1}&intFrecuencia={2}" & _
                                                  "&strRutaTransportesDiaSurtido={3}&strRutaTransportesDiaEntrega={4}" & _
                                                  "&intRutaTransportesId={5}&strRutaTransportesClave={6}" & _
                                                  "&strRutaTransportesTipoNombre={7}" & _
                                                  "&strDestinoNombre={8}&strProveedorNombre={9}&intTolerancia={10}" & _
                                                  "'>{11}</a></td>", _
                                                  colorRegistro, _
                                                  intRutaTransportesFrecuenciaIdRenglon, _
                                                  intFrecuenciaRenglon, _
                                                  strRutaTransportesDiaSurtidoRenglon, _
                                                  strRutaTransportesDiaEntregaRenglon, _
                                                  intRutaTransportesId, _
                                                  strRutaTransportesClave, _
                                                  strRutaTransportesTipoNombre, _
                                                  strDestinoNombre, _
                                                  strProveedorNombre, _
                                                  intTolerancia, _
                                                  imagenEditar)

            resultadoRutaTransportesFrecuencia.AppendFormat("<td align='left' style='width: 50px;' class='{0}'>" & _
                                                  "<a href='SucursalAdministrarRutaTransporteDetalle.aspx?strCmd2=BorrarFrecuencia" & _
                                                  "&intRutaTransportesFrecuenciaId={1}&intFrecuencia={2}" & _
                                                  "&intRutaTransportesId={3}&strRutaTransportesClave={4}" & _
                                                  "&strRutaTransportesTipoNombre={5}" & _
                                                  "&strDestinoNombre={6}&strProveedorNombre={7}&intTolerancia={8}" & _
                                                  "'>{9}</a></td>", _
                                                  colorRegistro, _
                                                  intRutaTransportesFrecuenciaIdRenglon, _
                                                  intFrecuenciaRenglon, _
                                                  intRutaTransportesId, _
                                                  strRutaTransportesClave, _
                                                  strRutaTransportesTipoNombre, _
                                                  strDestinoNombre, _
                                                  strProveedorNombre, _
                                                  intTolerancia, _
                                                  imagenEliminar)

            resultadoRutaTransportesFrecuencia.Append("</tr>")
        Next

        Return resultadoRutaTransportesFrecuencia.ToString()
    End Function

    Private Sub GuardarTblRutaTransportesFrecuencia()
        Dim resultado As Integer = 0

        resultado = Benavides.CC.Data.clsRutaTransportes.clsRutaTransportesFrecuencia.intGuardarTblRutaTransportesFrecuencia(intRutaTransportesId, _
                                                                                               intFrecuencia, _
                                                                                               strRutaTransportesDiaSurtido, _
                                                                                               strRutaTransportesDiaEntrega, _
                                                                                               Date.Now, _
                                                                                               strUsuarioNombre, _
                                                                                               strConnectionString)

        If resultado = 1 Then
            _strmJavascriptWindowOnLoadCommands = "Registro guardado correctamente"
        ElseIf resultado = -1 Then
            _strmJavascriptWindowOnLoadCommands = String.Format("Ya existe la Frecuencia {0}", intFrecuencia)
        ElseIf resultado = 0 Then
            _strmJavascriptWindowOnLoadCommands = "Error"
        End If
    End Sub

    Private Sub ActualizarTblRutaTransportesFrecuencia()
        Dim resultado As Integer = 0

        resultado = Benavides.CC.Data.clsRutaTransportes.clsRutaTransportesFrecuencia.intActualizarTblRutaTransportesFrecuencia(intRutaTransportesFrecuenciaId, _
                                                                                                  intRutaTransportesId, _
                                                                                                  intFrecuencia, _
                                                                                                  strRutaTransportesDiaSurtido, _
                                                                                                  strRutaTransportesDiaEntrega, _
                                                                                                  Date.Now, _
                                                                                                  strUsuarioNombre, _
                                                                                                  strConnectionString)

        If resultado = 1 Then
            _strmJavascriptWindowOnLoadCommands = "Registro actualizado correctamente"
        ElseIf resultado = -1 Then
            _strmJavascriptWindowOnLoadCommands = String.Format("Ya existe la Frecuencia {0}", intFrecuencia)
        ElseIf resultado = 0 Then
            _strmJavascriptWindowOnLoadCommands = "Error"
        End If
    End Sub

    Private Sub EliminarTblRutaTransportesFrecuencia()
        Dim resultado As Integer = 0

        resultado = Benavides.CC.Data.clsRutaTransportes.clsRutaTransportesFrecuencia.intEliminarTblRutaTransportesFrecuencia(intRutaTransportesFrecuenciaId, strConnectionString)

        If resultado = 1 Then
            _strmJavascriptWindowOnLoadCommands = String.Format("La Frecuencia {0} " & _
                                                                "fué eliminada correctamente" _
                                                                , intFrecuencia)
        ElseIf resultado = -1 Then
            _strmJavascriptWindowOnLoadCommands = "Hubo un error al eliminar el registro seleccionado"
        End If
    End Sub

End Class