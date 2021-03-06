﻿Imports Benavides.CC.Data
Imports Benavides.POSAdmin.Commons
Imports Isocraft.Web.Http
Imports System.Collections
Imports System.Text

Public Class ControlAsistenciaAdministracionDeUsuarios
    Inherits PaginaBase

    Private Enum TipoUsuario
        Administrador = 1
        CoordinadorRH = 2
        SupervisorMedico = 3
    End Enum

    Public ReadOnly Property intGrupoUsuarioSeleccionadoId() As Integer
        Get
            Dim objArray As Array = Nothing
            Dim intGrupoId As String() = Nothing
            Dim intSeleccionadoId As Integer

            objArray = Benavides.CC.Data.clsControlDeAsistencia.strBuscarGrupoControlAsistencia(strConnectionString)

            If IsArray(objArray) AndAlso objArray.Length > 0 Then
                intGrupoId = CType(objArray.GetValue(0), String())
                intSeleccionadoId = CInt(intGrupoId(0))
            Else
                intSeleccionadoId = 0
            End If

            Return intSeleccionadoId
        End Get
    End Property

    Public ReadOnly Property intTipoUsuarioIdParametro() As Integer
        Get
            Return CInt(GetPageParameter("intTipoUsuarioIdParametro", "0"))
        End Get
    End Property

    Public ReadOnly Property intEmpleadoId() As String
        Get
            Return GetPageParameter("intEmpleadoId", "0")
        End Get
    End Property

    Public ReadOnly Property intUsuarioId() As Integer
        Get
            Return CInt(GetPageParameter("intUsuarioId", "0"))
        End Get
    End Property

    Public ReadOnly Property txtNumeroEmpleado() As String
        Get
            Return CStr(ViewState("txtNumeroEmpleado"))
        End Get
    End Property

    Public ReadOnly Property cboTipoUsuario() As String
        Get
            Return CStr(ViewState("cboTipoUsuario"))
        End Get
    End Property

    Public ReadOnly Property strCmd2() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd2", "")
        End Get
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página

        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Or _
            Not intTipoUsuarioId = TipoUsuario.Administrador Then
            Call Response.Redirect("../Default.aspx")
        End If

        Select Case strCmd2
            Case "Buscar"
                Call GuardarValorControles()
                Call strConsultarUsuarios()
            Case "Deshabilitar"
                Call DeshabilitarUsuario()

        End Select

    End Sub

    Protected Function strConsultarUsuarios() As String
        Dim strResultadoTablaUsuarios As New StringBuilder
        Dim objUsuarios As Array
        Dim intEmpleadoIdParametro As Integer

        If intEmpleadoId Is "0" Then
            intEmpleadoIdParametro = 0
        Else
            intEmpleadoIdParametro = CInt(intEmpleadoId)
        End If

        objUsuarios = clsControlDeAsistencia. _
                      strBuscarUsuarioConcentrador(intGrupoUsuarioSeleccionadoId, _
                                                   intEmpleadoIdParametro, _
                                                   intTipoUsuarioIdParametro, _
                                                   strConnectionString)

        If IsArray(objUsuarios) AndAlso objUsuarios.Length > 0 Then
            strResultadoTablaUsuarios.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strResultadoTablaUsuarios.Append("<tr class='trtitulos'>")
            strResultadoTablaUsuarios.Append("<th class='rayita' style='text-align:left'>Usuario</th>")
            strResultadoTablaUsuarios.Append("<th class='rayita' style='text-align:left'>Supervisor</th>")
            strResultadoTablaUsuarios.Append("<th class='rayita' style='text-align:left'>Estatus</th>")
            strResultadoTablaUsuarios.Append("<th class='rayita' colspan='2'>Acción</th>")
            strResultadoTablaUsuarios.Append("</tr>")

            strResultadoTablaUsuarios.Append(CrearRegistrosUsuario(objUsuarios))

            strResultadoTablaUsuarios.Append("</table>")
        End If

        Return strResultadoTablaUsuarios.ToString()
    End Function

    Private Function CrearRegistrosUsuario(ByVal registrosUsuario As Array) As String
        Dim contadorRegistros As Integer = 0
        Dim colorRegistro As String = String.Empty
        Dim imgDeshabilitarUsuario As String = "<img src='../static/images/imgNRDesasignar.gif' width='17' height='17' border='0' align='absMiddle' alt='Haga clic aquí para cambiar el estatus del usuario' title='Haga clic aquí para cambiar el estatus del usuario'>"
        Dim imgEditarUsuario As String = "<img src='../static/images/imgNREditar.gif' width='17' height='17' border='0' align='absMiddle' alt='Haga clic aquí para cambiar el estatus del usuario' title='Haga clic aquí para editar este usuario'>"
        Dim resultadoUsuarios As New StringBuilder

        For Each renglon As SortedList In registrosUsuario
            contadorRegistros += 1

            If (contadorRegistros Mod 2) <> 0 Then
                colorRegistro = "tdceleste"
            Else
                colorRegistro = "tdblanco"
            End If

            resultadoUsuarios.Append("<tr>")

            resultadoUsuarios.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, renglon.Item("intEmpleadoId").ToString())
            resultadoUsuarios.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, renglon.Item("Nombre").ToString())
            resultadoUsuarios.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, renglon.Item("Estatus").ToString())

            resultadoUsuarios.AppendFormat("<td align='center' style='width: 50px;' class='{0}'>" & _
                                           "<a href='#' onClick='cmdDeshabilitarUsuario_onclick(""{1}"", ""{2}"");return false;'>" & _
                                           "{3}</a></td>", _
                                           colorRegistro, _
                                           renglon.Item("intEmpleadoId").ToString(), _
                                           renglon.Item("intUsuarioId").ToString(), _
                                           imgDeshabilitarUsuario)

            resultadoUsuarios.AppendFormat("<td align='center' style='width: 50px;' class='{0}'>" & _
                                           "<a href='#' " & _
                                           "onClick='cmdEditarUsuario_onclick(""{1}"",""{2}"",""{3}"",""{4}"",""{5}"",""{6}"",""{7}"")" & _
                                           ";return false;'>" & _
                                           "{8}</a></td>", _
                                            colorRegistro, _
                                            renglon.Item("intEmpleadoId").ToString(), _
                                            renglon.Item("intUsuarioId").ToString(), _
                                            renglon.Item("strUsuarioContrasena").ToString(), _
                                            CDate(renglon.Item("dtmUsuarioExpiracion")).ToString("dd/MM/yyyy"), _
                                            renglon.Item("blnUsuarioBloqueado").ToString(), _
                                            renglon.Item("intTipoUsuarioId").ToString(), _
                                            renglon.Item("blnUsuarioHabilitado").ToString(), _
                                            imgEditarUsuario)

            resultadoUsuarios.Append("</tr>")
        Next

        Return resultadoUsuarios.ToString()
    End Function

    Private Sub DeshabilitarUsuario()
        Dim intResultado As Integer = 0

        intResultado = clsUsuario.intActualizarEstatus(CInt(intEmpleadoId), intUsuarioId, strUsuarioNombre, strConnectionString)

        If intResultado > 0 Then
            strJavascriptWindowOnLoadCommands = "window.alert(""Estatus actualizado correctamente."");"
        End If
    End Sub

    Private Sub GuardarValorControles()
        ViewState("txtNumeroEmpleado") = intEmpleadoId
        ViewState("cboTipoUsuario") = intTipoUsuarioIdParametro
    End Sub

End Class

