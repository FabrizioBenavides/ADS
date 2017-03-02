Imports System.Text
Imports System.Collections
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert

Public Class SucursalAdministrarRutaTransporte
    Inherits PaginaBase

    Private _strRutaTransportesClaveFiltro As String
    Private _intRutaTransportesTipoIdFiltro As Integer
    Private _intDestinoIdFiltro As Integer
    Private _intProveedorIdFiltro As Integer

    Private _intRutaTransportesId As Integer
    Private _strRutaTransportesClave As String
    Private _intRutaTransportesTipoId As Integer
    Private _intDestinoId As Integer
    Private _intProveedorId As Integer
    Private _intTolerancia As Integer

    Private _controlDestino As String
    Private _controlProveedor As String

    Public ReadOnly Property strCmd2() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd2", "")
        End Get
    End Property

    Public ReadOnly Property strRutaTransportesClaveFiltro() As String
        Get
            If Not Request.Form("txtRutaClaveFiltro") = "" Then
                _strRutaTransportesClaveFiltro = Request.Form("txtRutaClaveFiltro")
            Else
                _strRutaTransportesClaveFiltro = ""
            End If
            Return _strRutaTransportesClaveFiltro
        End Get
    End Property

    Public ReadOnly Property intRutaTransportesTipoIdFiltro() As Integer
        Get
            If Not Request.Form("cboRutaTransportesTipoIdFiltro") = "" Then
                _intRutaTransportesTipoIdFiltro = CInt(Request.Form("cboRutaTransportesTipoIdFiltro"))
            Else
                _intRutaTransportesTipoIdFiltro = -1
            End If
            Return _intRutaTransportesTipoIdFiltro
        End Get
    End Property

    Public ReadOnly Property intDestinoIdFiltro() As Integer
        Get
            If Not Request.Form("cboRutaTransportesDestinoFiltro") = "" Then
                _intDestinoIdFiltro = CInt(Request.Form("cboRutaTransportesDestinoFiltro"))
            Else
                _intDestinoIdFiltro = -1
            End If

            Return _intDestinoIdFiltro
        End Get
    End Property

    Public ReadOnly Property intProveedorIdFiltro() As Integer
        Get
            If Not Request.Form("cboRutaTransportesProveedorFiltro") = "" Then
                _intProveedorIdFiltro = CInt(Request.Form("cboRutaTransportesProveedorFiltro"))
            Else
                _intProveedorIdFiltro = -1
            End If

            Return _intProveedorIdFiltro
        End Get
    End Property

    Public ReadOnly Property intRutaTransportesId() As Integer
        Get
            Return CInt(GetPageParameter("intRutaTransportesId", "-1"))
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

    Public ReadOnly Property intTolerancia() As Integer
        Get
            Return CInt(GetPageParameter("intTolerancia", "0"))
        End Get
    End Property

    Public ReadOnly Property ControlDestino As String
        Get
            Return _controlDestino
        End Get
    End Property

    Protected ReadOnly Property ControlProveedor As String
        Get
            Return _controlProveedor
        End Get
    End Property

    ''' <summary>
    ''' This call is required by the Web Form Designer. 
    ''' </summary>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        InitializeComponent()

        _strmJavascriptWindowOnLoadCommands = ""
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Benavides.CC.Business.clsConcentrador.clsControlAcceso. _
                blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Try
            Select Case strCmd2
                Case "Nuevo"
                    Call GuardarTblRutaTransportes()
                Case "Editar"
                    Call ActualizarTblRutaTransportes()
                Case "Eliminar"
                    If Not ValidarEliminarTblRutaTransportes() Then
                        Call EliminarTblRutaTransportes()
                    Else
                        _strmJavascriptWindowOnLoadCommands = "alert('No se puede eliminar la ruta seleccionada por que tiene una Sucursal y/o Frecuencia relacionada');"
                    End If
            End Select

        Catch ex As Exception
            Response.Write("Error")
        End Try
    End Sub

    Protected Function strObtenerRutaTransportes() As String
        Dim resultadoRutaTransportes As New StringBuilder
        Dim objRutaTransportes As Array

        objRutaTransportes = Benavides.CC.Data.clsRutaTransportes.strConsultarTblRutaTransportes( _
                                                                        strRutaTransportesClaveFiltro, _
                                                                        intRutaTransportesTipoIdFiltro, _
                                                                        intDestinoIdFiltro, _
                                                                        intProveedorIdFiltro, _
                                                                        strConnectionString)

        If IsArray(objRutaTransportes) AndAlso objRutaTransportes.Length > 0 Then
            resultadoRutaTransportes.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            resultadoRutaTransportes.Append("<tr class='trtitulos'>")
            resultadoRutaTransportes.Append("<th class='rayita'>Ruta</th>")
            resultadoRutaTransportes.Append("<th class='rayita'>Distribución</th>")
            resultadoRutaTransportes.Append("<th class='rayita'>Destino</th>")
            resultadoRutaTransportes.Append("<th class='rayita'>Proveedor</th>")
            resultadoRutaTransportes.Append("<th class='rayita'>Tolerancia (minutos)</th>")
            resultadoRutaTransportes.Append("<th class='rayita' colspan='3'>Acción</th>")

            resultadoRutaTransportes.Append("</tr>")

            resultadoRutaTransportes.Append(CrearRegistrosRutaTransportes(objRutaTransportes))

            resultadoRutaTransportes.Append("</table>")
        End If

        Return resultadoRutaTransportes.ToString()
    End Function

    Private Function CrearRegistrosRutaTransportes(ByVal registrosRutaTransportes As Array) As String
        Dim contadorRegistros As Integer = 0
        Dim colorRegistro As String = String.Empty
        Dim resultadoRutaTransportes As New StringBuilder
        Dim imagenEditar As String = "<img src='../static/images/icono_editar.gif' width='11' height='13' border='0' align='center' alt='Haga clic aquí para editar' title='Haga clic aquí para editar'>"
        Dim imagenDetalle As String = "<img src='../static/images/icono_ver.gif' width='11' height='13' border='0' align='center' alt='Haga clic aquí para ver detalle' title='Haga clic aquí para ver detalle'>"
        Dim imagenEliminar As String = "<img src='../static/images/imgNREliminar.gif' width='11' height='13' border='0' align='center' alt='Haga clic aquí para eliminar' title='Haga clic aquí para eliminar'>"

        Dim intRutaTransportesIdRenglon As String = String.Empty
        Dim strRutaTransportesClaveRenglon As String = String.Empty
        Dim intRutaTransportesTipoIdRenglon As String = String.Empty
        Dim strRutaTransportesTipoNombreRenglon As String = String.Empty
        Dim intDestinoIdRenglon As String = String.Empty
        Dim strDestinoNombreRenglon As String = String.Empty
        Dim intProveedorIdRenglon As String = String.Empty
        Dim strProveedorNombreRenglon As String = String.Empty
        Dim intToleranciaRenglon As String = String.Empty

        For Each renglon As SortedList In registrosRutaTransportes
            contadorRegistros += 1

            intRutaTransportesIdRenglon = CStr(renglon.Item("intRutaTransportesId"))
            strRutaTransportesClaveRenglon = CStr(renglon.Item("strRutaTransportesClave"))
            intRutaTransportesTipoIdRenglon = CStr(renglon.Item("intRutaTransportesTipoId"))
            strRutaTransportesTipoNombreRenglon = CStr(renglon.Item("strRutaTransportesTipoNombre"))
            intDestinoIdRenglon = CStr(renglon.Item("intDestinoId"))
            strDestinoNombreRenglon = CStr(renglon.Item("strDestinoNombre"))

            intProveedorIdRenglon = CStr(renglon.Item("intProveedorId"))
            strProveedorNombreRenglon = CStr(renglon.Item("strProveedorNombre"))
            intToleranciaRenglon = CStr(renglon.Item("intTolerancia"))

            If (contadorRegistros Mod 2) <> 0 Then
                colorRegistro = "tdceleste"
            Else
                colorRegistro = "tdblanco"
            End If

            resultadoRutaTransportes.Append("<tr>")

            resultadoRutaTransportes.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, strRutaTransportesClaveRenglon)
            resultadoRutaTransportes.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, strRutaTransportesTipoNombreRenglon)
            resultadoRutaTransportes.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, strDestinoNombreRenglon)
            resultadoRutaTransportes.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, strProveedorNombreRenglon)
            resultadoRutaTransportes.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, intToleranciaRenglon)

            resultadoRutaTransportes.AppendFormat("<td align='center' style='width: 25px;' class='{0}'>" & _
                                                  "<a href='SucursalAdministrarRutaTransporte.aspx?strCmd2=Actualizar&intRutaTransportesId={1}" & _
                                                  "&strRutaTransportesClave={2}&intRutaTransportesTipoId={3}" & _
                                                  "&intDestinoId={4}&intProveedorId={5}&intTolerancia={6}" & _
                                                  "'>{7}</a></td>", _
                                                  colorRegistro, _
                                                  intRutaTransportesIdRenglon, _
                                                  strRutaTransportesClaveRenglon, _
                                                  intRutaTransportesTipoIdRenglon, _
                                                  intDestinoIdRenglon, _
                                                  intProveedorIdRenglon, _
                                                  intToleranciaRenglon, _
                                                  imagenEditar)

            resultadoRutaTransportes.AppendFormat("<td align='center' style='width: 25px;' class='{0}'>" & _
                                                  "<a href='SucursalAdministrarRutaTransporteDetalle.aspx?strCmd2=VerDetalle&intRutaTransportesId={1}" & _
                                                  "&strRutaTransportesClave={2}&strRutaTransportesTipoNombre={3}" & _
                                                  "&strDestinoNombre={4}&strProveedorNombre={5}&intTolerancia={6}" & _
                                                  "'>{7}</a></td>", _
                                                  colorRegistro, _
                                                  intRutaTransportesIdRenglon, _
                                                  strRutaTransportesClaveRenglon, _
                                                  strRutaTransportesTipoNombreRenglon, _
                                                  strDestinoNombreRenglon, _
                                                  strProveedorNombreRenglon, _
                                                  intToleranciaRenglon, _
                                                  imagenDetalle)

            resultadoRutaTransportes.AppendFormat("<td align='center' style='width: 25px;' class='{0}'>" & _
                                                   "<a href='SucursalAdministrarRutaTransporte.aspx?strCmd2=Borrar" & _
                                                   "&intRutaTransportesId={1}&strRutaTransportesClave={2}" & _
                                                   "'>{3}</a></td>", _
                                                   colorRegistro, _
                                                   intRutaTransportesIdRenglon, _
                                                   strRutaTransportesClaveRenglon, _
                                                   imagenEliminar)

            resultadoRutaTransportes.Append("</tr>")
        Next

        Return resultadoRutaTransportes.ToString()
    End Function

    Private Sub GuardarTblRutaTransportes()
        Dim resultado As Integer = 0

        resultado = Benavides.CC.Data.clsRutaTransportes.intGuardarTblRutaTransportes(strRutaTransportesClave, _
                                                                                      intRutaTransportesTipoId, _
                                                                                      intDestinoId, _
                                                                                      intProveedorId, _
                                                                                      intTolerancia, _
                                                                                      Date.Now, _
                                                                                      strUsuarioNombre, _
                                                                                      strConnectionString)

        If resultado = 1 Then
            _strmJavascriptWindowOnLoadCommands = "alert('Registro guardado correctamente.');"
        ElseIf resultado = -1 Then
            _strmJavascriptWindowOnLoadCommands = String.Format("alert('Ya existe una Ruta con el " & "nombre {0}');", strRutaTransportesClave)
        ElseIf resultado = 0 Then
            _strmJavascriptWindowOnLoadCommands = "alert('Error');"
        End If
    End Sub

    Private Sub ActualizarTblRutaTransportes()
        Dim resultado As Integer = 0

        resultado = Benavides.CC.Data.clsRutaTransportes.intActualizarTblRutaTransportes(intRutaTransportesId, _
                                                                                         strRutaTransportesClave, _
                                                                                         intRutaTransportesTipoId, _
                                                                                         intDestinoId, _
                                                                                         intProveedorId, _
                                                                                         intTolerancia, _
                                                                                         Date.Now, _
                                                                                         strUsuarioNombre, _
                                                                                         strConnectionString)

        If resultado = 1 Then
            _strmJavascriptWindowOnLoadCommands = "alert('Registro actualizado correctamente.');"
        ElseIf resultado = -1 Then
            _strmJavascriptWindowOnLoadCommands = String.Format("alert('Ya existe una Ruta con el " & "nombre {0}');", strRutaTransportesClave)
        ElseIf resultado = 0 Then
            _strmJavascriptWindowOnLoadCommands = "alert('Error');"
        End If

    End Sub

    Private Sub EliminarTblRutaTransportes()
        Dim resultado As Integer = 0

        resultado = Benavides.CC.Data.clsRutaTransportes.intEliminarTblRutaTransportes(intRutaTransportesId, strConnectionString)

        If resultado = 1 Then
            _strmJavascriptWindowOnLoadCommands = String.Format("alert('La Ruta {0} fué eliminada correctamente');" _
                                                                , strRutaTransportesClave)
        ElseIf resultado = -1 Then
            _strmJavascriptWindowOnLoadCommands = "alert('Hubo un error al eliminar el registro seleccionado');"
        End If
    End Sub

    Private Function ValidarEliminarTblRutaTransportes() As Boolean
        Dim ExisteRelacion As Boolean = False
        Dim resultado As Integer = 0

        resultado = Benavides.CC.Data.clsRutaTransportes.intValidarTblRutaTransportes(intRutaTransportesId, strConnectionString)

        If resultado = 1 Then
            ExisteRelacion = True
        End If

        Return ExisteRelacion
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

        _controlDestino = controlDestino.ToString()
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

        _controlProveedor = controlProveedor.ToString()
        Return controlProveedor.ToString()
    End Function

End Class