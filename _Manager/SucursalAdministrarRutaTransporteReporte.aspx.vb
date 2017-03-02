Imports System.Text
Imports System.Collections
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert

Public Class SucursalAdministrarRutaTransporteReporte
    Inherits PaginaBase
    Protected WithEvents ReporteCalendario As System.Web.UI.HtmlControls.HtmlGenericControl

    ''' <summary>
    ''' This call is required by the Web Form Designer. 
    ''' </summary>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Public ReadOnly Property strCmd2() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd2", "")
        End Get
    End Property

    Public ReadOnly Property strRutaTransportesClave() As String
        Get
            Return GetPageParameter("strRutaTransportesClave", "")
        End Get
    End Property

    Public ReadOnly Property intRutaTransportesTipoId() As Integer
        Get
            Return CInt(GetPageParameter("intRutaTransportesTipoId", "-1"))
        End Get
    End Property

    Public ReadOnly Property intDestinoId() As Integer
        Get
            Return CInt(GetPageParameter("intDestinoId", "-1"))
        End Get
    End Property

    Public ReadOnly Property intProveedorId() As Integer
        Get
            Return CInt(GetPageParameter("intProveedorId", "-1"))
        End Get
    End Property

    Public ReadOnly Property strCentroLogisticoId() As String
        Get
            Return GetPageParameter("strCentroLogisticoId", "")
        End Get
    End Property

    Public ReadOnly Property dtmFechaHoraEntregaProgramadaInicio() As Date
        Get
            Dim dtmFecha As Date = CDate(GetPageParameter("dtmFechaHoraEntregaProgramadaInicio", "01/01/2000"))
            Return dtmFecha
        End Get
    End Property

    Public ReadOnly Property dtmFechaHoraEntregaProgramadaFin() As Date
        Get
            Dim dtmFecha As Date = CDate(GetPageParameter("dtmFechaHoraEntregaProgramadaFin", "01/01/2100"))
            Return dtmFecha
        End Get
    End Property

    Public ReadOnly Property intEntregaConfirmada() As Integer
        Get
            Return CInt(GetPageParameter("intEntregaConfirmada", "-1"))
        End Get
    End Property

    Public ReadOnly Property ConRetraso() As String
        Get
            Return GetPageParameter("ConRetraso", "No")
        End Get
    End Property

    Public ReadOnly Property intMotivoRetrasoId() As Integer
        Get
            Dim valorRegreso As Integer
            Dim intMotivoRetrasoIdParametro As Integer = CInt(GetPageParameter("intMotivoRetrasoId", "-1"))

            If ConRetraso = "Si" Then
                valorRegreso = intMotivoRetrasoIdParametro
            ElseIf ConRetraso = "No" Then
                valorRegreso = -2
            ElseIf ConRetraso = "Ambos" Then
                valorRegreso = -1
            End If

            Return valorRegreso
        End Get
    End Property

    Public ReadOnly Property txtRutaTransportesClave() As String
        Get
            Return CStr(ViewState("txtRutaTransportesClave"))
        End Get
    End Property

    Public ReadOnly Property cboRutaTransportesTipoIdFiltro() As Integer
        Get
            Return CInt(ViewState("cboRutaTransportesTipoIdFiltro"))
        End Get
    End Property

    Public ReadOnly Property cboRutaTransportesDestinoFiltro() As Integer
        Get
            Return CInt(ViewState("cboRutaTransportesDestinoFiltro"))
        End Get
    End Property

    Public ReadOnly Property cboRutaTransportesProveedorFiltro() As Integer
        Get
            Return CInt(ViewState("cboRutaTransportesProveedorFiltro"))
        End Get
    End Property

    Public ReadOnly Property txtCentroLogisticoId() As String
        Get
            Return CStr(ViewState("txtCentroLogisticoId"))
        End Get
    End Property

    Public ReadOnly Property dtmFechaInicioEntrega() As String
        Get
            Return CStr(ViewState("dtmFechaInicioEntrega"))
        End Get
    End Property

    Public ReadOnly Property dtmFechaFinEntrega() As String
        Get
            Return CStr(ViewState("dtmFechaFinEntrega"))
        End Get
    End Property

    Public ReadOnly Property cboEntregaConfirmada() As Integer
        Get
            Return CInt(ViewState("cboEntregaConfirmada"))
        End Get
    End Property

    Public ReadOnly Property cboMotivoRetraso() As Integer
        Get
            Dim valorRegreso As Integer

            If ViewState("cboMotivoRetraso") Is Nothing Then
                valorRegreso = -1
            Else
                valorRegreso = CInt(ViewState("cboMotivoRetraso"))
            End If

            Return valorRegreso
        End Get
    End Property

    Public ReadOnly Property rbtRetraso() As String
        Get
            Return CStr(ViewState("rbtRetraso"))
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        InitializeComponent()

        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Select Case strCmd2
            Case "Consultar"

                ReporteCalendario.InnerHtml = strConsultarReporteCalendario()

        End Select
        'Try


        'Catch ex As Exception
        '    Response.Write("Error")
        'End Try
    End Sub

    Protected Function strConsultarReporteCalendario() As String
        Dim resultadoReporteCalendario As New StringBuilder
        Dim objReporteCalendario As Array

        Call MantenerValorControles()

        objReporteCalendario = Benavides.CC.Data.clsRutaTransportes.clsRutaTransportesSucursalCalendario.strConsultarTblRutaTransportesSucursalCalendarioReporte( _
            strRutaTransportesClave, _
            intRutaTransportesTipoId, _
            intDestinoId, _
            intProveedorId, _
            strCentroLogisticoId, _
            dtmFechaHoraEntregaProgramadaInicio, _
            dtmFechaHoraEntregaProgramadaFin, _
            intEntregaConfirmada, _
            intMotivoRetrasoId, _
            strConnectionString)



        If IsArray(objReporteCalendario) AndAlso objReporteCalendario.Length > 0 Then
            resultadoReporteCalendario.Append("<table id='tablaReporte' width='100%' border='0' cellpadding='0' cellspacing='0'>")
            resultadoReporteCalendario.Append("<tr class='trtitulos'>")
            resultadoReporteCalendario.Append("<th class='rayita'>Ruta</th>")
            resultadoReporteCalendario.Append("<th class='rayita'>Distribución</th>")
            resultadoReporteCalendario.Append("<th class='rayita'>Destino</th>")
            resultadoReporteCalendario.Append("<th class='rayita'>Proveedor</th>")
            resultadoReporteCalendario.Append("<th class='rayita'>Sucursal</th>")
            resultadoReporteCalendario.Append("<th class='rayita'>Fecha Entrega</th>")
            resultadoReporteCalendario.Append("<th class='rayita'>Fecha Confirmada</th>")
            resultadoReporteCalendario.Append("<th class='rayita'>Motivo</th>")

            resultadoReporteCalendario.Append("</tr>")

            resultadoReporteCalendario.Append(CrearRegistrosReporteCalendario(objReporteCalendario))

            resultadoReporteCalendario.Append("</table>")
        End If

        Return resultadoReporteCalendario.ToString()
    End Function

    Private Function CrearRegistrosReporteCalendario(ByVal registrosReporteCalendario As Array) As String
        Dim contadorRegistros As Integer = 0
        Dim resultadoReporteCalendario As New StringBuilder
        Dim colorRegistro As String = String.Empty
        Dim strRutaTransportesClaveRenglon As String = String.Empty
        Dim strRutaTransportesTipoNombreRenglon As String = String.Empty
        Dim strDestinoNombreRenglon As String = String.Empty
        Dim strProveedorNombreRenglon As String = String.Empty
        Dim strCentroLogisticoIdRenglon As String = String.Empty
        Dim strCiaRenglon As String = String.Empty
        Dim strDireccionOperativaNombreRenglon As String = String.Empty
        Dim strSucursalNombreRenglon As String = String.Empty
        Dim dtmFechaHoraEntregaProgramadaRenglon As Date
        Dim strFechaHoraEntregaProgramadaRenglon As String
        Dim dtmFechaHoraEntregaRealRenglon As Date
        Dim strFechaHoraEntregaRealRenglon As String = String.Empty
        Dim strEstatusEntregaRenglon As String = String.Empty
        Dim strMotivoNombreRenglon As String = String.Empty

        For Each renglon As SortedList In registrosReporteCalendario
            strFechaHoraEntregaRealRenglon = String.Empty
            strMotivoNombreRenglon = String.Empty

            If (contadorRegistros Mod 2) <> 0 Then
                colorRegistro = "tdceleste"
            Else
                colorRegistro = "tdblanco"
            End If

            strRutaTransportesClaveRenglon = CStr(renglon.Item("strRutaTransportesClave"))
            strRutaTransportesTipoNombreRenglon = CStr(renglon.Item("strRutaTransportesTipoNombre"))
            strDestinoNombreRenglon = CStr(renglon.Item("strDestinoNombre"))
            strProveedorNombreRenglon = CStr(renglon.Item("strProveedorNombre"))
            strCentroLogisticoIdRenglon = CStr(renglon.Item("strCentroLogisticoId"))
            strCiaRenglon = CStr(renglon.Item("CIA"))
            strDireccionOperativaNombreRenglon = CStr(renglon.Item("strDireccionOperativaNombre"))
            strSucursalNombreRenglon = CStr(renglon.Item("strSucursalNombre"))
            dtmFechaHoraEntregaProgramadaRenglon = CDate(renglon.Item("dtmFechaHoraEntregaProgramada"))
            strFechaHoraEntregaProgramadaRenglon = dtmFechaHoraEntregaProgramadaRenglon.ToString("dd/MM/yyyy HH:mm")

            If Not (renglon.Item("dtmFechaHoraEntregaReal") Is Nothing) And Not IsDBNull(renglon.Item("dtmFechaHoraEntregaReal")) Then
                dtmFechaHoraEntregaRealRenglon = CDate(renglon.Item("dtmFechaHoraEntregaReal"))
                strFechaHoraEntregaRealRenglon = dtmFechaHoraEntregaRealRenglon.ToString("dd/MM/yyyy HH:mm:ss")
            End If

            strEstatusEntregaRenglon = CStr(renglon.Item("EstatusEntrega"))

            If Not (renglon.Item("strMotivoNombre") Is Nothing) And Not IsDBNull(renglon.Item("strMotivoNombre")) Then
                strMotivoNombreRenglon = CStr(renglon.Item("strMotivoNombre"))
            End If

            resultadoReporteCalendario.Append("<tr>")
            resultadoReporteCalendario.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, strRutaTransportesClaveRenglon)
            resultadoReporteCalendario.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, strRutaTransportesTipoNombreRenglon)
            resultadoReporteCalendario.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, strDestinoNombreRenglon)
            resultadoReporteCalendario.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, strProveedorNombreRenglon)
            resultadoReporteCalendario.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, strCentroLogisticoIdRenglon)
            resultadoReporteCalendario.AppendFormat("<td class='{0}' style='display:none'>{1}</td>", colorRegistro, strCiaRenglon)
            resultadoReporteCalendario.AppendFormat("<td class='{0}' style='display:none'>{1}</td>", colorRegistro, strSucursalNombreRenglon)
            resultadoReporteCalendario.AppendFormat("<td class='{0}' style='display:none'>{1}</td>", colorRegistro, strDireccionOperativaNombreRenglon)
            resultadoReporteCalendario.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, strFechaHoraEntregaProgramadaRenglon)
            resultadoReporteCalendario.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, strFechaHoraEntregaRealRenglon)
            resultadoReporteCalendario.AppendFormat("<td class='{0}' style='display:none'>{1}</td>", colorRegistro, strEstatusEntregaRenglon)
            resultadoReporteCalendario.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, strMotivoNombreRenglon)

            resultadoReporteCalendario.Append("</tr>")
        Next

        Return resultadoReporteCalendario.ToString()
    End Function

    Protected Function CrearOpcionesMotivoRetraso() As String

        Dim strOpcionesMotivoRetraso As New StringBuilder
        Dim resultadoConsulta As Array = Nothing
        Dim objMotivo As New System.Collections.SortedList

        resultadoConsulta = Benavides.CC.Data.clsRutaTransportes.clsRutaTransportesMotivoRetraso.strConsultarTblRutaTransportesMotivoRetraso(strConnectionString)

        For i As Integer = 0 To resultadoConsulta.Length - 1

            objMotivo = CType(resultadoConsulta.GetValue(i), Collections.SortedList)
            strOpcionesMotivoRetraso.AppendFormat("<option value='{0}'>{1}</option>", _
                                              objMotivo.Item("intMotivoRetrasoId").ToString(), _
                                              objMotivo.Item("strMotivoNombre").ToString())
        Next

        Return strOpcionesMotivoRetraso.ToString()

    End Function

    Protected Function LLenarControlDestino() As String
        Dim controlDestino As New StringBuilder
        Dim resultadoConsulta As Array = Nothing
        Dim objDestino As New System.Collections.SortedList

        resultadoConsulta = Benavides.CC.Data.clsRutaTransportes.clsRutaTransportesDestino.strConsultarTblRutaTransportesDestino(strConnectionString)

        For i As Integer = 0 To resultadoConsulta.Length - 1
            objDestino = CType(resultadoConsulta.GetValue(i), Collections.SortedList)
            controlDestino.AppendFormat("<option value=""{0}"">{1}</option>", _
                                              objDestino.Item("intDestinoId").ToString(), objDestino.Item("strDestinoNombre").ToString())
        Next

        Return controlDestino.ToString()
    End Function

    Protected Function LLenarControlProveedor() As String
        Dim controlProveedor As New StringBuilder
        Dim resultadoConsulta As Array = Nothing
        Dim objProveedor As New System.Collections.SortedList

        resultadoConsulta = Benavides.CC.Data.clsRutaTransportes.clsRutaTransportesProveedor.strConsultarTblRutaTransportesProveedor(strConnectionString)

        For i As Integer = 0 To resultadoConsulta.Length - 1
            objProveedor = CType(resultadoConsulta.GetValue(i), Collections.SortedList)
            controlProveedor.AppendFormat("<option value=""{0}"">{1}</option>", _
                                              objProveedor.Item("intProveedorId").ToString(), objProveedor.Item("strProveedorNombre").ToString())
        Next

        Return controlProveedor.ToString()
    End Function

    Private Sub MantenerValorControles()

        ViewState("txtRutaTransportesClave") = strRutaTransportesClave
        ViewState("cboRutaTransportesTipoIdFiltro") = intRutaTransportesTipoId
        ViewState("cboRutaTransportesDestinoFiltro") = intDestinoId
        ViewState("cboRutaTransportesProveedorFiltro") = intProveedorId
        ViewState("txtCentroLogisticoId") = strCentroLogisticoId
        ViewState("dtmFechaInicioEntrega") = dtmFechaHoraEntregaProgramadaInicio
        ViewState("dtmFechaFinEntrega") = dtmFechaHoraEntregaProgramadaFin
        ViewState("cboEntregaConfirmada") = intEntregaConfirmada
        ViewState("rbtRetraso") = ConRetraso
        ViewState("cboMotivoRetraso") = intMotivoRetrasoId

    End Sub

End Class