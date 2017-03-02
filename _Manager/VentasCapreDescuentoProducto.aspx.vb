Imports System.Text
Imports System.Collections
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports System.IO
Imports Benavides.CC.Business.clsConcentrador

Public Class VentasCapreDescuentoProducto
    Inherits PaginaBase

    Protected WithEvents txtArchivo As System.Web.UI.HtmlControls.HtmlInputFile

    Private Enum TipoDescuento
        Categoria = 1
        Producto = 2
    End Enum

    Private Enum TipoEliminacion
        Singular = 1
        Completa = 2
    End Enum

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Public ReadOnly Property strCmd2() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd2", "")
        End Get
    End Property

    Public ReadOnly Property strArticuloId() As String
        Get
            Return GetPageParameter("strArticuloId", "")
        End Get
    End Property

    Public ReadOnly Property intCaprePorcentajeMaximo() As Integer
        Get
            Return CInt(GetPageParameter("intCaprePorcentajeMaximo", "0"))
        End Get
    End Property

    Public ReadOnly Property strNombreProducto() As String
        Get
            Return Request.Form("txtNombreProducto")
        End Get
    End Property

    Public ReadOnly Property EsConsulta() As String
        Get
            Return GetPageParameter("EsConsulta", "")
        End Get
    End Property

    Protected Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim renglonesArchivoCSV As Array

        If Benavides.CC.Business.clsConcentrador.clsControlAcceso. _
               blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Select Case strCmd2

            Case "Agregar"
                If Not EsArchivoInvalido() Then

                    renglonesArchivoCSV = CreateArrayFromCSVHttpPostedFile(txtArchivo.PostedFile)
                    If ValidarAgregarRegistroCapreMaximoArticulo(renglonesArchivoCSV) Then

                        If ValidarProductosExistentes(renglonesArchivoCSV) Then
                            Session("IdArticulosRecienAgregado") = Nothing
                            Call AgregarRegistroCapreMaximoArticuloHistorial()
                            Call AgregarRegistroCapreMaximoArticulo(renglonesArchivoCSV)
                        Else
                            strJavascriptWindowOnLoadCommands = "window.alert(""Los productos del archivo no existen."");"
                        End If
                    Else
                        strJavascriptWindowOnLoadCommands = "window.alert(""El archivo a agregar contiene registros invalidos."");"
                    End If
                End If

            Case "Reemplazar"
                If Not EsArchivoInvalido() Then

                    renglonesArchivoCSV = CreateArrayFromCSVHttpPostedFile(txtArchivo.PostedFile)
                    If ValidarAgregarRegistroCapreMaximoArticulo(renglonesArchivoCSV) Then

                        If ValidarProductosExistentes(renglonesArchivoCSV) Then
                            Session("IdArticulosRecienAgregado") = Nothing
                            Call AgregarRegistroCapreMaximoArticuloHistorial()
                            Call EliminarRegistroCapreMaximoArticulo()
                            Call AgregarRegistroCapreMaximoArticulo(renglonesArchivoCSV)
                        Else
                            strJavascriptWindowOnLoadCommands = "window.alert(""Los productos del archivo no existen."");"
                        End If
                    Else
                        strJavascriptWindowOnLoadCommands = "window.alert(""El archivo a reemplazar contiene registros invalidos."");"
                    End If
                End If

            Case "Eliminar"
                Call AgregarRegistroCapreMaximoArticuloHistorial()
                Call EliminarRegistroCapreMaximoArticulo()

            Case "EditarRegistroSingularCapreMaximoArticulo"
                Call EditarRegistroSingularCapreMaximoArticulo()

            Case "EliminarRegistroSingularCapreMaximoArticulo"
                Call EliminarRegistroSingularCapreMaximoArticulo()

            Case "AgregarRegistroSingularCapreMaximoArticulo"
                Call AgregarRegistroSingularCapreMaximoArticulo()

        End Select
    End Sub

    Protected Function strObtenerProductos() As String
        Dim strResultadoTablaProducto As New StringBuilder
        Dim objProductos As Array
        Dim IdArticulosRecienAgregado As String

        If strCmd2 = "EsConsulta" Then
            Session("IdArticulosRecienAgregado") = Nothing
        End If

        If Not Session("IdArticulosRecienAgregado") Is Nothing Then
            IdArticulosRecienAgregado = Session("IdArticulosRecienAgregado").ToString()
            IdArticulosRecienAgregado = IdArticulosRecienAgregado.Trim().Substring(0, IdArticulosRecienAgregado.Length - 1)

            objProductos = clsCapre.clsCapreMaximoArticulo. _
                           strBuscarCapreMaximoArticuloPorProducto2(IdArticulosRecienAgregado, strConnectionString)
        Else

            If Not strNombreProducto = "" Then
                objProductos = clsCapre.clsCapreMaximoArticulo. _
                               strBuscarCapreMaximoArticuloPorProducto(strNombreProducto, strConnectionString)
            End If
        End If

        If IsArray(objProductos) AndAlso objProductos.Length > 0 Then
            strResultadoTablaProducto.AppendFormat("<span class='campotablaresultado' style='margin-left:650px'>{0} Registro(s)</span>", objProductos.Length)

            strResultadoTablaProducto.Append("<table id='tablaProducto' width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strResultadoTablaProducto.Append("<tr class='trtitulos'>")
            strResultadoTablaProducto.Append("<th class='rayita' style='text-align:left'>Código</th>")
            strResultadoTablaProducto.Append("<th class='rayita' style='text-align:left'>Nombre Producto</th>")
            strResultadoTablaProducto.Append("<th class='rayita' style='text-align:center'>Descuento(%)</th>")
            strResultadoTablaProducto.Append("<th class='rayita' colspan='2'>Acción</th>")
            strResultadoTablaProducto.Append("</tr>")

            strResultadoTablaProducto.Append(CrearRegistrosSucursalesRematadoras(objProductos))

            strResultadoTablaProducto.Append("</table>")
        End If

        Return strResultadoTablaProducto.ToString()
    End Function

    Private Function CrearRegistrosSucursalesRematadoras(ByVal registrosProductos As Array) As String
        Dim contadorRegistros As Integer = 0
        Dim colorRegistro As String = String.Empty
        Dim resultadoProducto As New StringBuilder
        Dim imagenEditar As String = "<img src='../static/images/icono_editar.gif' width='11' height='13' border='0' align='center' alt='Haga clic aquí para editar' title='Haga clic aquí para editar'>"
        Dim imagenEliminar As String = "<img src='../static/images/imgNREliminar.gif' width='11' height='13' border='0' align='center' alt='Haga clic aquí para eliminar' title='Haga clic aquí para eliminar'>"
        Dim strArticuloId As String
        Dim intCaprePorcentajeMaximo As Integer

        For Each renglon As SortedList In registrosProductos
            contadorRegistros += 1

            If (contadorRegistros Mod 2) <> 0 Then
                colorRegistro = "tdceleste"
            Else
                colorRegistro = "tdblanco"
            End If

            resultadoProducto.Append("<tr>")

            strArticuloId = renglon.Item("intArticuloId").ToString()
            intCaprePorcentajeMaximo = CInt(renglon.Item("fltCaprePorcentajeMaximo"))

            resultadoProducto.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, strArticuloId)
            resultadoProducto.AppendFormat("<td class='{0}' style='text-align:left'>{1}</td>", colorRegistro, renglon.Item("strArticuloDescripcion"))
            resultadoProducto.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, intCaprePorcentajeMaximo)

            resultadoProducto.AppendFormat("<td align='center' style='width: 25px;' class='{0}'>" & _
                                           "<a href='VentasCapreDescuentoProducto.aspx?strCmd2=ActualizarSingular&strArticuloId={1}" & _
                                           "&intCaprePorcentajeMaximo={2}" & _
                                           "'>{3}</a></td>", _
                                           colorRegistro, _
                                           strArticuloId, _
                                           intCaprePorcentajeMaximo, _
                                           imagenEditar)

            resultadoProducto.AppendFormat("<td align='center' style='width: 25px;' class='{0}'>" & _
                                           "<a href='VentasCapreDescuentoProducto.aspx?strCmd2=BorrarSingular&strArticuloId={1}" & _
                                           "'>{2}</a></td>", _
                                           colorRegistro, _
                                           strArticuloId, _
                                           imagenEliminar)

            resultadoProducto.Append("</tr>")
        Next

        Return resultadoProducto.ToString()
    End Function

    Private Sub AgregarRegistroCapreMaximoArticulo(ByVal renglonesArchivoCSV As Array)
        Dim renglonCalendario As Array
        Dim intValorRegreso As Integer = 0
        Dim intCantidadRegistrosExitosos As Integer = 0
        Dim strArticuloId As String = String.Empty
        Dim strPorcentajeMaximo As String = String.Empty
        Dim intCantidadRegistrosSinEncabezadoYSinEspacios As Integer = 0
        Dim arrProductosAcumulados As New ArrayList

        intCantidadRegistrosSinEncabezadoYSinEspacios = renglonesArchivoCSV.Length - 2

        If IsNothing(renglonesArchivoCSV) = False AndAlso renglonesArchivoCSV.Length > 0 Then

            For indice As Integer = 1 To renglonesArchivoCSV.Length - 1

                renglonCalendario = DirectCast(renglonesArchivoCSV.GetValue(indice), Array)

                If renglonCalendario.Length > 1 Then

                    strArticuloId = renglonCalendario.GetValue(0).ToString().Trim()
                    strPorcentajeMaximo = renglonCalendario.GetValue(1).ToString().Trim()

                    If ValidarRegistrosProductoArchivo(strArticuloId, arrProductosAcumulados) AndAlso _
                        ValidarRegistrosDescuentoArchivo(strPorcentajeMaximo) Then

                        intValorRegreso = clsCapre.clsCapreMaximoArticulo. _
                                          intActualizarAgregarCapreMaximoArticuloPorProducto _
                                                                            (CInt(strArticuloId), _
                                                                             CDec(strPorcentajeMaximo), _
                                                                             strUsuarioNombre, _
                                                                             strConnectionString)

                        Call GuardarProductoIdEnSesion(strArticuloId)
                    End If

                    ' Si el registro logró ser agregado
                    If intValorRegreso > 0 Then
                        ' Incrementamos el contador de registros procesados exitósamente
                        intCantidadRegistrosExitosos += intValorRegreso
                    End If
                End If

                intValorRegreso = 0
            Next

            strJavascriptWindowOnLoadCommands = String.Format( _
                                                "alert(""Total de líneas en el archivo: {0} \n\r\n\r" & _
                                                        "Total de registros importados: {1} \n\r\n\r" & _
                                                        "Total de registros sin importar: {2}\n\r"");" _
                                                        , intCantidadRegistrosSinEncabezadoYSinEspacios _
                                                        , intCantidadRegistrosExitosos _
                                                        , CStr(intCantidadRegistrosSinEncabezadoYSinEspacios - intCantidadRegistrosExitosos))
        End If
    End Sub

    Private Function ValidarAgregarRegistroCapreMaximoArticulo(ByVal renglonesArchivoCSV As Array) As Boolean
        Dim esValido As Boolean = False
        Dim renglonCalendario As Array
        Dim strArticuloId As String = String.Empty
        Dim strPorcentajeMaximo As String = String.Empty
        Dim intCantidadRegistrosSinEncabezadoYSinEspacios As Integer = 0
        Dim arrProductosAcumulados As New ArrayList

        intCantidadRegistrosSinEncabezadoYSinEspacios = renglonesArchivoCSV.Length - 2

        If IsNothing(renglonesArchivoCSV) = False AndAlso renglonesArchivoCSV.Length > 0 Then

            For indice As Integer = 1 To renglonesArchivoCSV.Length - 1

                renglonCalendario = DirectCast(renglonesArchivoCSV.GetValue(indice), Array)

                If renglonCalendario.Length > 1 Then

                    If Not renglonCalendario.GetValue(0) Is Nothing AndAlso _
                       Not renglonCalendario.GetValue(1) Is Nothing Then
                        strArticuloId = renglonCalendario.GetValue(0).ToString().Trim()
                        strPorcentajeMaximo = renglonCalendario.GetValue(1).ToString().Trim()
                    End If

                    If ValidarRegistrosProductoArchivo(strArticuloId, arrProductosAcumulados) AndAlso ValidarRegistrosDescuentoArchivo(strPorcentajeMaximo) Then

                        esValido = True
                        Exit For
                    End If

                End If
            Next
        End If

        Return esValido
    End Function

    Private Function ValidarRegistrosProductoArchivo(ByVal strArticuloId As String, ByVal arrProductosAcumulados As ArrayList) As Boolean
        Dim blnEsProductoValido As Boolean = True

        If strArticuloId Is String.Empty Then
            blnEsProductoValido = False

        ElseIf Not IsNumeric(strArticuloId) Then
            blnEsProductoValido = False

        ElseIf Not arrProductosAcumulados.Contains(strArticuloId) Then
            arrProductosAcumulados.Add(strArticuloId)
        Else
        blnEsProductoValido = False
        End If

        Return blnEsProductoValido
    End Function

    Private Function ValidarRegistrosDescuentoArchivo(ByVal strPorcentajeMaximo As String) As Boolean
        Dim blnEsDescuentoValido As Boolean = True
        Dim intPorcentajeMaximo As Integer = 0

        If strPorcentajeMaximo Is String.Empty Then
            blnEsDescuentoValido = False

        ElseIf Not IsNumeric(strPorcentajeMaximo) Then
            blnEsDescuentoValido = False

        ElseIf InStr(strPorcentajeMaximo, ".") > 0 Then
            blnEsDescuentoValido = False

        ElseIf strPorcentajeMaximo.Length > 3 Then
            blnEsDescuentoValido = False

        End If

        If IsNumeric(strPorcentajeMaximo) Then
            intPorcentajeMaximo = CInt(strPorcentajeMaximo)

            If intPorcentajeMaximo < 0 Or intPorcentajeMaximo > 100 Then
                blnEsDescuentoValido = False
            End If
        End If

        Return blnEsDescuentoValido
    End Function

    Private Sub AgregarRegistroCapreMaximoArticuloHistorial()
        Dim intResultado As Integer = 0

        intResultado = clsCapre.clsCapreMaximoArticulo. _
                       intAgregarCapreMaximoArticuloHistorial(TipoDescuento.Producto, strConnectionString)
    End Sub

    Private Sub EliminarRegistroCapreMaximoArticulo()
        Dim intResultado As Integer = 0

        intResultado = clsCapre.clsCapreMaximoArticulo. _
                      intEliminarCapreMaximoArticuloPorProducto(0, _
                                                                TipoEliminacion.Completa, _
                                                                strConnectionString)

        If intResultado > 0 Then
            strJavascriptWindowOnLoadCommands = "alert(""Productos eliminados correctamente."");"
        End If
    End Sub

    Private Sub EliminarRegistroSingularCapreMaximoArticulo()
        Dim intResultado As Integer = 0

        intResultado = clsCapre.clsCapreMaximoArticulo. _
                       intEliminarCapreMaximoArticuloPorProducto(CInt(strArticuloId), _
                                                                 TipoEliminacion.Singular, _
                                                                 strConnectionString)

        If intResultado > 0 Then
            strJavascriptWindowOnLoadCommands = "window.alert(""Producto eliminados correctamente."");"
        Else
            strJavascriptWindowOnLoadCommands = "window.alert(""Error al eliminar."");"
        End If
    End Sub

    Private Sub EditarRegistroSingularCapreMaximoArticulo()
        Dim intResultado As Integer = 0

        intResultado = clsCapre.clsCapreMaximoArticulo. _
                       intActualizarAgregarCapreMaximoArticuloPorProducto(CInt(strArticuloId), _
                                                                          CDec(intCaprePorcentajeMaximo), _
                                                                          strUsuarioNombre, _
                                                                          strConnectionString)

        If intResultado > 0 Then
            strJavascriptWindowOnLoadCommands = "window.alert(""Producto actualizado correctamente."");"
            Session("IdArticulosRecienAgregado") = Nothing
            Session("IdArticulosRecienAgregado") = strArticuloId & ","
        ElseIf intResultado = -2 Then
            strJavascriptWindowOnLoadCommands = String.Format("window.alert(""El producto {0} no existe."");", strArticuloId)
        Else
            strJavascriptWindowOnLoadCommands = "window.alert(""Error al actualizar."");"
        End If
    End Sub

    Private Sub AgregarRegistroSingularCapreMaximoArticulo()
        Dim intResultado As Integer = 0

        intResultado = clsCapre.clsCapreMaximoArticulo. _
                       intActualizarAgregarCapreMaximoArticuloPorProducto(CInt(strArticuloId), _
                                                                          CDec(intCaprePorcentajeMaximo), _
                                                                          strUsuarioNombre, _
                                                                          strConnectionString)

        If intResultado > 0 Then
            strJavascriptWindowOnLoadCommands = "window.alert(""Producto guardado correctamente."");"
            Session("IdArticulosRecienAgregado") = Nothing
            Session("IdArticulosRecienAgregado") = strArticuloId & ","
        ElseIf intResultado = -2 Then
            strJavascriptWindowOnLoadCommands = String.Format("window.alert(""El producto {0} no existe."");", strArticuloId)
        Else
            strJavascriptWindowOnLoadCommands = "window.alert(""Error al guardar."");"
        End If
    End Sub

    Private Function EsArchivoInvalido() As Boolean
        Dim esInvalido As Boolean = False
        Dim extensionArchivoPermitida As String = ".csv"

        If txtArchivo.PostedFile.FileName.Length < 1 Then
            esInvalido = True
            strJavascriptWindowOnLoadCommands = "window.alert(""Por favor especifique un valor para el campo 'Archivo'."");"
        ElseIf Not Path.HasExtension(txtArchivo.PostedFile.FileName) Then
            esInvalido = True
            strJavascriptWindowOnLoadCommands = "window.alert(""El archivo no contiene una extensión."");"
        ElseIf Not String.Equals(Path.GetExtension(txtArchivo.PostedFile.FileName).ToLower(), extensionArchivoPermitida) Then
            esInvalido = True
            strJavascriptWindowOnLoadCommands = "window.alert(""El archivo no contiene la extensión correcta. La extensión debe ser .csv."");"
        End If

        Return esInvalido
    End Function

    Private Sub GuardarProductoIdEnSesion(ByVal strArticuloId As String)

        If Not Session("IdArticulosRecienAgregado") Is Nothing Then
            Session("IdArticulosRecienAgregado") = String.Format("{0},{1}", strArticuloId, Session("IdArticulosRecienAgregado").ToString())
        Else
            Session("IdArticulosRecienAgregado") = strArticuloId & ","
        End If
    End Sub

    Private Function ValidarProductosExistentes(ByVal arrProductosArchivo As Array) As Boolean
        Dim blnExisteProducto As Boolean = False
        Dim renglonProductos As Array
        Dim strProductoId As String = String.Empty
        Dim strListaProductos As New StringBuilder
        Dim productoValidar As String
        Dim intCantidadProductos As Integer

        If arrProductosArchivo.Length > 3 Then

            For indice As Integer = 1 To arrProductosArchivo.Length - 2
                renglonProductos = DirectCast(arrProductosArchivo.GetValue(indice), Array)
                strProductoId = renglonProductos.GetValue(0).ToString().Trim()

                strListaProductos.AppendFormat(" ''{0}'',", strProductoId)
            Next

            productoValidar = String.Format("' {0} '", strListaProductos.ToString().Substring(0, strListaProductos.Length - 1))
        Else
            renglonProductos = DirectCast(arrProductosArchivo.GetValue(1), Array)
            strProductoId = renglonProductos.GetValue(0).ToString().Trim()
            strListaProductos.AppendFormat("'''{0}'''", strProductoId)

            productoValidar = strListaProductos.ToString()
        End If

        intCantidadProductos = clsCapre. _
                               clsCapreMaximoArticulo. _
                               strConsultarCantidadProductosExistentes(productoValidar, strConnectionString)

        If intCantidadProductos > 0 Then
            blnExisteProducto = True
        End If

        Return blnExisteProducto
    End Function

End Class