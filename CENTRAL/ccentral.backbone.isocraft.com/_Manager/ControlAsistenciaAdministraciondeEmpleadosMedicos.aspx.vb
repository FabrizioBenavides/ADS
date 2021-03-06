﻿Imports Benavides.CC.Data
Imports Benavides.POSAdmin.Commons
Imports Isocraft.Security
Imports Isocraft.Web.Http
Imports System.Collections
Imports System.Text

Public Class ControlAsistenciaAdministraciondeEmpleadosMedicos
    Inherits PaginaBase

    Private Enum TipoUsuario
        Administrador = 1
        CoordinadorRH = 2
        SupervisorMedico = 3
    End Enum

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Or _
            Not intTipoUsuarioId = TipoUsuario.SupervisorMedico Then
            Call Response.Redirect("../Default.aspx")
        End If
    End Sub

    Protected Function strConsultarEmpleadosMedicos() As String
        Dim strResultadoTablaMedicos As New StringBuilder
        Dim objMedicos As Array

        objMedicos = clsControlDeAsistencia.clsRolMedico. _
                     strBuscarEmpleadosMedicos(CInt(strUsuarioNombre), strConnectionString)
                                                        
        If IsArray(objMedicos) AndAlso objMedicos.Length > 0 Then
            strResultadoTablaMedicos.Append("<table id='tblAdminEmpleados' width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strResultadoTablaMedicos.Append("<tr class='trtitulos'>")
            strResultadoTablaMedicos.Append("<th class='rayita' style='text-align:left'>No. Empleado</th>")
            strResultadoTablaMedicos.Append("<th class='rayita' style='text-align:left'>Nombre</th>")
            strResultadoTablaMedicos.Append("<th class='rayita' style='text-align:left'>Sucursal</th>")
            strResultadoTablaMedicos.Append("<th class='rayita' colspan='3'>Acciónes</th>")
            strResultadoTablaMedicos.Append("</tr>")

            strResultadoTablaMedicos.Append(strCrearRegistrosMedico(objMedicos))

            strResultadoTablaMedicos.Append("</table>")
        End If

        Return strResultadoTablaMedicos.ToString()
    End Function

    Private Function strCrearRegistrosMedico(ByVal registrosMedicos As Array) As String
        Dim contadorRegistros As Integer = 0
        Dim colorRegistro As String = String.Empty
        Dim imgAsignacionDiasEspeciales As String = "<img src='../static/images/imgNREditar.gif' width='17' height='17' border='0' align='absMiddle' alt='Ver asignaciones días especiales' title='Ver asignaciones días especiales'>"
        Dim imgAsignacionHorario As String = "<img src='../static/images/imgNRVerB.gif' width='17' height='17' border='0' align='absMiddle' alt='Ver asignación horario' title='Ver asignación horario'>"
        Dim resultadoMedicos As New StringBuilder

        For Each renglon As SortedList In registrosMedicos
            contadorRegistros += 1

            If (contadorRegistros Mod 2) <> 0 Then
                colorRegistro = "tdceleste"
            Else
                colorRegistro = "tdblanco"
            End If

            resultadoMedicos.Append("<tr>")

            resultadoMedicos.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, renglon.Item("intEmpleadoId").ToString())
            resultadoMedicos.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, renglon.Item("NombreEmpleado").ToString())
            resultadoMedicos.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, renglon.Item("Sucursal").ToString())

            resultadoMedicos.AppendFormat("<td align='center' style='width: 50px;' class='{0}'>" & _
                                          "<a href='#' onClick='mostrarPaginaAdministracionEmpleados_onclick(""{1}"");return false;'>" & _
                                          "{2}</a></td>", _
                                          colorRegistro, _
                                          renglon.Item("intEmpleadoId").ToString(), _
                                          imgAsignacionDiasEspeciales)

            resultadoMedicos.AppendFormat("<td align='center' style='width: 50px;' class='{0}'>" & _
                                          "<a href='#' onClick='mostrarPaginaAsignacionHorario_onclick(""{1}"");return false;'>" & _
                                          "{2}</a></td>", _
                                          colorRegistro, _
                                          renglon.Item("intEmpleadoId").ToString(), _
                                          imgAsignacionHorario)

            resultadoMedicos.Append("</tr>")
        Next

        Return resultadoMedicos.ToString()
    End Function

End Class