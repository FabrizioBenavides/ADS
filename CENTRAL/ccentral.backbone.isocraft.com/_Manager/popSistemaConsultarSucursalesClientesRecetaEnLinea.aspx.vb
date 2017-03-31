Imports Benavides.CC.Data
Imports Isocraft.Web.Convert
Imports Isocraft.Web.Http
Imports System.Collections
Imports System.Text

Public Class popSistemaConsultarSucursalesClientesRecetaEnLinea
    Inherits PaginaBase

    ''' <summary>
    ''' This call is required by the Web Form Designer. 
    ''' </summary>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Public ReadOnly Property strClienteABFId() As String
        Get
            Return GetPageParameter("strClienteABFId", "")
        End Get
    End Property

    Public ReadOnly Property strClienteRecetaEnLineaNombre() As String
        Get
            Return GetPageParameter("strClienteRecetaEnLineaNombre", "")
        End Get
    End Property

    Public ReadOnly Property intCompaniaId() As Integer
        Get
            Return CInt(GetPageParameter("intCompaniaId", "0"))
        End Get
    End Property

    Public ReadOnly Property intSucursalId() As Integer
        Get
            Return CInt(GetPageParameter("intSucursalId", "0"))
        End Get
    End Property

    Public ReadOnly Property strCmd2() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd2", "")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Select Case strCmd2

            Case "Eliminar"
                Call EliminarTblClienteRecetaEnLineaSucursal()

        End Select

    End Sub

    Public Function strConsultarSucursalesClientes() As String
        Dim strResultadoTablaSucursales As New StringBuilder
        Dim objSucursales As Array

        objSucursales = clsClientesABF. _
                        clsClienteRecetaEnLineaABF. _
                        strBuscarTblClienteRecetaEnLineaSucursalPorClienteId(strClienteABFId, strConnectionString)

        If IsArray(objSucursales) AndAlso objSucursales.Length > 0 Then
            strResultadoTablaSucursales.Append("<table id='tablaSucursales' width='95%' border='0' cellpadding='0' cellspacing='0'>")
            strResultadoTablaSucursales.Append("<tr class='trtitulos'>")
            strResultadoTablaSucursales.Append("<th class='rayita' style='text-align:left'>Centro Logístico</th>")
            strResultadoTablaSucursales.Append("<th class='rayita' style='text-align:left'>Nombre</th>")
            strResultadoTablaSucursales.Append("<th class='rayita' colspan='3'>Acción</th>")
            strResultadoTablaSucursales.Append("</tr>")

            strResultadoTablaSucursales.Append(CrearRegistrosSucursales(objSucursales))

            strResultadoTablaSucursales.Append("</table>")
        End If

        Return strResultadoTablaSucursales.ToString()
    End Function

    Private Function CrearRegistrosSucursales(ByVal registrosSucursales As Array) As String
        Dim contadorRegistros As Integer = 0
        Dim colorRegistro As String = String.Empty
        Dim imagenEliminar As String = "<img src='../static/images/imgNREliminar.gif' width='11' height='13' border='0' align='center' alt='Haga clic aquí para eliminar' title='Haga clic aquí para eliminar'>"
        Dim resultadoSucursales As New StringBuilder
        Dim strCentroLogisticoId As String = String.Empty

        For Each renglon As SortedList In registrosSucursales
            contadorRegistros += 1

            If (contadorRegistros Mod 2) <> 0 Then
                colorRegistro = "tdceleste"
            Else
                colorRegistro = "tdblanco"
            End If

            resultadoSucursales.Append("<tr>")

            strCentroLogisticoId = CStr(renglon.Item("strCentroLogisticoId"))

            resultadoSucursales.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, strCentroLogisticoId)
            resultadoSucursales.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, renglon.Item("strSucursalNombre"))

            resultadoSucursales.AppendFormat("<td align='center' style='width: 25px;' class='{0}'>" & _
                                             "<a a href='#' onClick='borrarSucursal(""{1}"", ""{2}"", ""{3}"");return false;'" & _
                                             "'>{4}</a></td>", _
                                              colorRegistro, _
                                              strCentroLogisticoId, _
                                              renglon.Item("intCompaniaId"), _
                                              renglon.Item("intSucursalId"), _
                                              imagenEliminar)

            resultadoSucursales.Append("</tr>")
        Next

        Return resultadoSucursales.ToString()
    End Function

    Private Sub EliminarTblClienteRecetaEnLineaSucursal()
        Dim intResultado As Integer = 0

        intResultado = clsClientesABF. _
                       clsClienteRecetaEnLineaABF. _
                       intEliminarTblClienteRecetaEnLineaSucursal(strClienteABFId, _
                                                                  intCompaniaId, _
                                                                  intSucursalId, _
                                                                  strConnectionString)

        If intResultado > 0 Then
            strJavascriptWindowOnLoadCommands = "alert(""Sucursal(es) eliminada(s) correctamente."");"
        ElseIf intResultado < 0 Then
            strJavascriptWindowOnLoadCommands = "alert(""Error al eliminar las sucursales."");"
        End If
    End Sub

End Class