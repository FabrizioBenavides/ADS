Imports System.Text
Imports Benavides.CC.Data
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports System.Collections

Public Class SistemaAdministrarClienteOtrasIdentificaciones
    Inherits PaginaBase

    Public Enum TipoFiltroSucursal
        Todos = 1
        SinSucursalAsignadas = 2
        ConSucursalesAsignadas = 3
    End Enum

    Public ReadOnly Property strCmd2() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd2", "")
        End Get
    End Property

    Public ReadOnly Property strClienteABF() As String
        Get
            Return GetPageParameter("strClienteABF", "")
        End Get
    End Property

    Public ReadOnly Property intTipoFiltroSucursales() As TipoFiltroSucursal
        Get
            Return CType(CInt(GetPageParameter("intTipoFiltroSucursales", "1")), TipoFiltroSucursal)
        End Get
    End Property

    Public ReadOnly Property txtClienteAbf() As String
        Get
            Return CStr(ViewState("txtClienteAbf"))
        End Get
    End Property






    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Benavides.CC.Business.clsConcentrador.clsControlAcceso. _
        '        blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
        '    Call Response.Redirect("../Default.aspx")
        'End If

    End Sub

    Protected Function strConsultarClientes() As String
        Dim strResultadoTablaClientes As New StringBuilder
        Dim objClientes As Array

        objClientes = clsClientesABF. _
                      clsOtrasIdentificacionesABF. _
                      strBuscarTblOtrasIdentificacionesABF(strClienteABF, intTipoFiltroSucursales, strConnectionString)

        If IsArray(objClientes) AndAlso objClientes.Length > 0 Then
            strResultadoTablaClientes.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strResultadoTablaClientes.Append("<tr class='trtitulos'>")
            strResultadoTablaClientes.Append("<th class='rayita' style='text-align:left'>ABF</th>")
            strResultadoTablaClientes.Append("<th class='rayita' style='text-align:left'>Cliente</th>")
            strResultadoTablaClientes.Append("<th class='rayita' style='text-align:center'>Sucursales Asignadas</th>")
            strResultadoTablaClientes.Append("<th class='rayita' style='text-align:center'>Activo</th>")
            strResultadoTablaClientes.Append("<th class='rayita' style='text-align:center'>Límite de Credito Excedido</th>")
            strResultadoTablaClientes.Append("<th class='rayita' colspan='3'>Acción</th>")
            strResultadoTablaClientes.Append("</tr>")

            strResultadoTablaClientes.Append(CrearRegistrosClientes(objClientes))

            strResultadoTablaClientes.Append("</table>")
        End If

        Return strResultadoTablaClientes.ToString()
    End Function

    Private Function CrearRegistrosClientes(ByVal registrosProductos As Array) As String
        Dim contadorRegistros As Integer = 0
        Dim colorRegistro As String = String.Empty
        Dim imagenVerActualizar As String = "<img src='../static/images/imgNRTodo.gif' width='11' height='13' border='0' align='center' alt='Haga clic aquí para ver ó actualizar cliente' title='Haga clic aquí para ver ó actualizar cliente'>"
        Dim imagenAsignarSucursales As String = "<img src='../static/images/imgNRArchivo.gif' width='11' height='13' border='0' align='center' alt='Haga clic aquí para eliminar' title='Haga clic aquí para eliminar'>"
        Dim resultadoCliente As New StringBuilder
        Dim strClienteABFId As String = String.Empty
        Dim strCheck As String = String.Empty

        For Each renglon As SortedList In registrosProductos
            contadorRegistros += 1

            If (contadorRegistros Mod 2) <> 0 Then
                colorRegistro = "tdceleste"
            Else
                colorRegistro = "tdblanco"
            End If

            resultadoCliente.Append("<tr>")

            resultadoCliente.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, renglon.Item("strClienteABFId"))
            resultadoCliente.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, renglon.Item("strClienteABFNombre"))
            resultadoCliente.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, renglon.Item("SucursalesAsignadas"))

            If CBool(renglon.Item("blnClienteActivo")) = True Then
                strCheck = "checked"
            End If

            resultadoCliente.AppendFormat("<td class='{0}' style='text-align:center'>" & _
                                          "<input type='checkbox' {1} disabled='disabled'/></td>", colorRegistro, strCheck)
            strCheck = String.Empty

            If CBool(renglon.Item("blnClienteExcedidoEnLimiteCredito")) = True Then
                strCheck = "checked"
            End If

            resultadoCliente.AppendFormat("<td class='{0}' style='text-align:center'>" & _
                                          "<input type='checkbox' {1} disabled='disabled' /></td>", colorRegistro, strCheck)
            strCheck = String.Empty

            resultadoCliente.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, imagenVerActualizar)
            resultadoCliente.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, imagenAsignarSucursales)
        Next

        Return resultadoCliente.ToString()
    End Function

    Private Sub MantenerValorControles()

        ViewState("txtClienteAbf") = strClienteABF


    End Sub



End Class