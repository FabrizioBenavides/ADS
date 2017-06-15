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
        'Get
        '    Return CDate(GetPageParameter("dtmFechaInicio", ""))
        'End Get
        Get
            Dim fechaInicio As String = GetPageParameter("dtmFechaInicio", "")

            If Not IsNothing(fechaInicio) Then
                Dim fechaSeparada As String() = fechaInicio.Split("/".ToCharArray())

                Return New Date(CInt(fechaSeparada(2)), CInt(fechaSeparada(1)), CInt(fechaSeparada(0)))

            End If
        End Get
    End Property

    Public ReadOnly Property dtmFechaFin() As Date
        'Get
        '    Return CDate(GetPageParameter("dtmFechaFin", ""))
        'End Get
        Get
            Dim fechaInicio As String = GetPageParameter("dtmFechaFin", "")

            If Not IsNothing(fechaInicio) Then
                Dim fechaSeparada As String() = fechaInicio.Split("/".ToCharArray())

                Return New Date(CInt(fechaSeparada(2)), CInt(fechaSeparada(1)), CInt(fechaSeparada(0)))

            End If
        End Get
    End Property

    Public ReadOnly Property strCmd2() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd2", "")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Select Case strCmd2

        '    Case "Buscar"


        'End Select

    End Sub

    Protected Function strConsultarMovimientosEmpleadosMedicos() As String
        Dim strResultadoTablaMovimientosMedicos As New StringBuilder
        Dim objMovimientosMedicos As Array

        If strCmd2 = "Buscar" Then

            objMovimientosMedicos = clsControlDeAsistencia.clsRolMedico _
                                    .strConsultarMovimientosEmpleadosMedicos(intEmpleadoId, _
                                                                             dtmFechaInicio, _
                                                                             dtmFechaFin, _
                                                                             strConnectionString)

            If IsArray(objMovimientosMedicos) AndAlso objMovimientosMedicos.Length > 0 Then
                strResultadoTablaMovimientosMedicos.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
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
        Dim resultadoMovimientosMedicos As New StringBuilder

        For Each renglon As SortedList In registrosMovimientosMedicos
            contadorRegistros += 1

            If (contadorRegistros Mod 2) <> 0 Then
                colorRegistro = "tdceleste"
            Else
                colorRegistro = "tdblanco"
            End If

            resultadoMovimientosMedicos.Append("<tr>")



        Next

        Return resultadoMovimientosMedicos.ToString()
    End Function

End Class