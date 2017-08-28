Imports Benavides.CC.Data
Imports Benavides.POSAdmin.Commons
Imports Isocraft.Security
Imports Isocraft.Web.Http
Imports System.Collections
Imports System.Text

Public Class ControlAsistenciaMovimientosEmpleadosMedicos
    Inherits PaginaBase

    Public ReadOnly Property intEmpleadoId() As Integer
        Get
            Return CInt(GetPageParameter("intEmpleadoId", "0"))
        End Get
    End Property

    Public ReadOnly Property NombreEmpleado() As String
        Get
            Return GetPageParameter("NombreEmpleado", "")
        End Get
    End Property

    Public ReadOnly Property dtmFechaActualPrimerDiaMes() As String
        Get
            Dim fechaHoy As Date

            fechaHoy = New Date(Today.Year, Today.Month, 1)

            Return fechaHoy.ToString("dd/MM/yyyy")
        End Get
    End Property

    Public ReadOnly Property dtmFechaHoy() As String
        Get
            Return Date.Now.ToString("dd/MM/yyyy")
        End Get
    End Property

    Public ReadOnly Property dtmFechaInicio() As Date
        Get
            Dim fechaInicio As String = GetPageParameter("dtmFechaInicio", "")

            If Not IsNothing(fechaInicio) AndAlso Not fechaInicio Is String.Empty Then
                Dim fechaSeparada As String() = fechaInicio.Split("/".ToCharArray())

                Return New Date(CInt(fechaSeparada(2)), CInt(fechaSeparada(1)), CInt(fechaSeparada(0)))

            End If
        End Get
    End Property

    Public ReadOnly Property dtmFechaFin() As Date
        Get
            Dim fechaFin As String = GetPageParameter("dtmFechaFin", "")

            If Not IsNothing(fechaFin) AndAlso Not fechaFin Is String.Empty Then
                Dim fechaSeparada As String() = fechaFin.Split("/".ToCharArray())

                Return New Date(CInt(fechaSeparada(2)), CInt(fechaSeparada(1)), CInt(fechaSeparada(0)))

            End If
        End Get
    End Property

    Public ReadOnly Property dtmFechaInicioValorBusqueda() As String
        Get
            Return dtmFechaInicio.ToString("dd/MM/yyyy")
        End Get
    End Property

    Public ReadOnly Property dtmFechaFinValorBusqueda() As String
        Get
            Return dtmFechaFin.ToString("dd/MM/yyyy")
        End Get
    End Property

    Public ReadOnly Property strCmd2() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd2", "")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Function strConsultarMovimientosEmpleadosMedicos() As String
        Dim strResultadoTablaMovimientosMedicos As New StringBuilder
        Dim objMovimientosMedicos As Array

        If strCmd2 = "Buscar" Then
            ' Ya no existe porque pagina ya no es necesaria.

            'objMovimientosMedicos = clsControlDeAsistencia.clsRolMedico _
            '                        .strConsultarMovimientosEmpleadosMedicos(intEmpleadoId, _
            '                                                                 dtmFechaInicio, _
            '                                                                 dtmFechaFin, _
            '                                                                 strConnectionString)

            If IsArray(objMovimientosMedicos) AndAlso objMovimientosMedicos.Length > 0 Then
                strResultadoTablaMovimientosMedicos.Append("<table id='tblMovimientos' width='100%' border='0' cellpadding='0' cellspacing='0'>")
                strResultadoTablaMovimientosMedicos.Append("<tr class='trtitulos'>")
                strResultadoTablaMovimientosMedicos.Append("<th class='rayita' style='text-align:left'>Fec. Mov.</th>")
                strResultadoTablaMovimientosMedicos.Append("<th class='rayita' style='text-align:left'>Empleado</th>")
                strResultadoTablaMovimientosMedicos.Append("<th class='rayita' style='text-align:left'>Nombre</th>")
                strResultadoTablaMovimientosMedicos.Append("<th class='rayita' style='text-align:left'>Entrada</th>")
                strResultadoTablaMovimientosMedicos.Append("<th class='rayita' style='text-align:left'>Salida</th>")
                strResultadoTablaMovimientosMedicos.Append("<th class='rayita' style='text-align:left'>Movimiento</th>")
                strResultadoTablaMovimientosMedicos.Append("</tr>")

                strResultadoTablaMovimientosMedicos.Append(strCrearRegistrosMovimientosMedico(objMovimientosMedicos))

                strResultadoTablaMovimientosMedicos.Append("</table>")
            End If
        End If

        Return strResultadoTablaMovimientosMedicos.ToString()
    End Function

    Private Function strCrearRegistrosMovimientosMedico(ByVal registrosMovimientosMedicos As Array) As String
        Dim contadorRegistros As Integer = 0
        Dim colorRegistro As String = String.Empty
        Dim resultadoTabla As New StringBuilder

        For Each renglon As SortedList In registrosMovimientosMedicos
            contadorRegistros += 1

            If (contadorRegistros Mod 2) <> 0 Then
                colorRegistro = "tdceleste"
            Else
                colorRegistro = "tdblanco"
            End If

            resultadoTabla.Append("<tr>")

            resultadoTabla.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, renglon.Item("fechaMovimiento").ToString())
            resultadoTabla.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, renglon.Item("intEmpleadoId").ToString())
            resultadoTabla.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, renglon.Item("NombreEmpleado").ToString())
            resultadoTabla.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, renglon.Item("dtmHoraEntrada").ToString())
            resultadoTabla.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, renglon.Item("dtmHoraSalida").ToString())
            resultadoTabla.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, renglon.Item("strMovimientoNombre").ToString())

            resultadoTabla.Append("</tr>")
        Next

        Return resultadoTabla.ToString()
    End Function

End Class