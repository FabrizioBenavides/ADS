Imports System.Text
Imports System.Collections
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports Benavides.CC.Business.clsConcentrador.clsCapre
Imports System.IO
Imports System.Text.RegularExpressions

Public Class VentasCapreDescuentoCategoria
    Inherits PaginaBase

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents txtArchivo As System.Web.UI.HtmlControls.HtmlInputFile

    Private Enum TipoDescuento
        Categoria = 1
        Producto = 2
    End Enum

    Private Enum TipoEliminacion
        Singular = 1
        Completa = 2
    End Enum

    Public ReadOnly Property intDivisionArticulosIdFiltro() As Integer
        Get
            Return CInt(GetPageParameter("intDivisionArticulosIdFiltro", "-1"))
        End Get
    End Property

    Public ReadOnly Property strCategoriaArticulosNombreFiltro() As String
        Get
            Return GetPageParameter("strCategoriaArticulosNombreFiltro", "")
        End Get
    End Property

    Public ReadOnly Property intDivisionArticulosId() As Integer
        Get
            Return CInt(GetPageParameter("intDivisionArticulosId", "-1"))
        End Get
    End Property

    Public ReadOnly Property intCategoriaArticulosId() As Integer
        Get
            Return CInt(GetPageParameter("intCategoriaArticulosId", "-1"))
        End Get
    End Property

    Public ReadOnly Property strDivisionArticulosNombreId() As String
        Get
            Return GetPageParameter("strDivisionArticulosNombreId", "-1")
        End Get
    End Property

    Public ReadOnly Property strCategoriaArticulosNombreId() As String
        Get
            Return GetPageParameter("strCategoriaArticulosNombreId", "-1")
        End Get
    End Property

    Public ReadOnly Property strClave() As String
        Get
            Return GetPageParameter("strClave", "")
        End Get
    End Property

    Public ReadOnly Property strCategoriaArticulosNombre() As String
        Get
            Return GetPageParameter("strCategoriaArticulosNombre", "")
        End Get
    End Property

    Public ReadOnly Property intCaprePorcentajeMaximo() As Integer
        Get
            Return CInt(GetPageParameter("intCaprePorcentajeMaximo", "0"))
        End Get
    End Property

    Public ReadOnly Property strCmd2() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd2", "")
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

                    If ValidarAgregarRegistroDivisionCategoria(renglonesArchivoCSV) Then

                        If ValidarDivisionesCategoriasExistentes(renglonesArchivoCSV) Then
                            Call AgregarRegistroCapreMaximoArticuloHistorial()
                            Call AgregarRegistroCapreMaximoArticulo(renglonesArchivoCSV)
                        Else
                            strJavascriptWindowOnLoadCommands = "window.alert(""Las divisiones y/ó categorías del archivo no existen."");"
                        End If
                    Else
                        strJavascriptWindowOnLoadCommands = "window.alert(""Las divisiones y/ó categorías del archivo no existen."");"
                    End If
                End If

            Case "Reemplazar"
                If Not EsArchivoInvalido() Then
                    renglonesArchivoCSV = CreateArrayFromCSVHttpPostedFile(txtArchivo.PostedFile)

                    If ValidarAgregarRegistroDivisionCategoria(renglonesArchivoCSV) Then

                        If ValidarDivisionesCategoriasExistentes(renglonesArchivoCSV) Then
                            Call AgregarRegistroCapreMaximoArticuloHistorial()
                            Call EliminarRegistroCapreMaximoArticulo()
                            Call AgregarRegistroCapreMaximoArticulo(renglonesArchivoCSV)
                        Else
                            strJavascriptWindowOnLoadCommands = "window.alert(""Las divisiones y/ó categorías del archivo no existen."");"
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

    Protected Function strObtenerCategorias() As String
        Dim strResultadoTablaCategoria As New StringBuilder
        Dim objCategorias As Array

        objCategorias = clsCapreMaximoArticulo.strBuscarCapreMaximoArticuloPorCategoria(intDivisionArticulosIdFiltro, _
                                                                                        strCategoriaArticulosNombreFiltro, _
                                                                                        strConnectionString)

        If IsArray(objCategorias) AndAlso objCategorias.Length > 0 Then
            strResultadoTablaCategoria.AppendFormat("<span class='campotablaresultado' style='margin-left:650px'>{0} Registro(s)</span>", objCategorias.Length)
            strResultadoTablaCategoria.Append("<table id='tablaCategoria' width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strResultadoTablaCategoria.Append("<tr class='trtitulos'>")
            strResultadoTablaCategoria.Append("<th class='rayita'>Clave</th>")
            strResultadoTablaCategoria.Append("<th class='rayita' style='text-align:left'>Nombre Categoría</th>")
            strResultadoTablaCategoria.Append("<th class='rayita'>Descuento(%)</th>")
            strResultadoTablaCategoria.Append("<th class='rayita' colspan='2'>Acción</th>")
            strResultadoTablaCategoria.Append("</tr>")

            strResultadoTablaCategoria.Append(CrearRegistrosSucursalesRematadoras(objCategorias))

            strResultadoTablaCategoria.Append("</table>")
        End If

        Return strResultadoTablaCategoria.ToString()
    End Function

    Private Function CrearRegistrosSucursalesRematadoras(ByVal registrosSucursalRematadora As Array) As String
        Dim contadorRegistros As Integer = 0
        Dim colorRegistro As String = String.Empty
        Dim resultadoCategoria As New StringBuilder
        Dim imagenEditar As String = "<img src='../static/images/icono_editar.gif' width='11' height='13' border='0' align='center' alt='Haga clic aquí para editar' title='Haga clic aquí para editar'>"
        Dim imagenEliminar As String = "<img src='../static/images/imgNREliminar.gif' width='11' height='13' border='0' align='center' alt='Haga clic aquí para eliminar' title='Haga clic aquí para eliminar'>"
        Dim strDivisionArticulosIdParametro As String = String.Empty
        Dim strCategoriaArticulosIdParametro As String = String.Empty
        Dim strDivisionArticulosNombreIdParametro As String = String.Empty
        Dim strCategoriaArticulosNombreIdParametro As String = String.Empty
        Dim strClaveParametro As String = String.Empty
        Dim strCategoriaArticulosNombreParametro As String = String.Empty
        Dim intCaprePorcentajeMaximoParametro As Integer

        For Each renglon As SortedList In registrosSucursalRematadora
            contadorRegistros += 1

            If (contadorRegistros Mod 2) <> 0 Then
                colorRegistro = "tdceleste"
            Else
                colorRegistro = "tdblanco"
            End If

            resultadoCategoria.Append("<tr>")

            strDivisionArticulosIdParametro = renglon.Item("intDivisionArticulosId").ToString()
            strCategoriaArticulosIdParametro = renglon.Item("intCategoriaArticulosId").ToString()
            strDivisionArticulosNombreIdParametro = renglon.Item("strDivisionArticulosNombreId").ToString()
            strCategoriaArticulosNombreIdParametro = renglon.Item("strCategoriaArticulosNombreId").ToString()
            strClaveParametro = renglon.Item("Clave").ToString()
            strCategoriaArticulosNombreParametro = renglon.Item("strCategoriaArticulosNombre").ToString()
            intCaprePorcentajeMaximoParametro = CInt(renglon.Item("fltCaprePorcentajeMaximo"))

            resultadoCategoria.AppendFormat("<td class='{0}' style='display:none;'>{1}</td>", colorRegistro, strDivisionArticulosIdParametro)
            resultadoCategoria.AppendFormat("<td class='{0}' style='display:none;'>{1}</td>", colorRegistro, strCategoriaArticulosIdParametro)
            resultadoCategoria.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, strClaveParametro)
            resultadoCategoria.AppendFormat("<td class='{0}'>{1}</td>", colorRegistro, strCategoriaArticulosNombreParametro)
            resultadoCategoria.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>", colorRegistro, intCaprePorcentajeMaximoParametro)

            resultadoCategoria.AppendFormat("<td align='center' style='width: 25px;' class='{0}'>" & _
                                           "<a href='VentasCapreDescuentoCategoria.aspx?strCmd2=ActualizarSingular&strDivisionArticulosNombreId={1}" & _
                                           "&strCategoriaArticulosNombreId={2}&intCaprePorcentajeMaximo={3}" & _
                                           "&strCategoriaArticulosNombre={4}" & _
                                           "'>{5}</a></td>", _
                                           colorRegistro, _
                                           strDivisionArticulosNombreIdParametro, _
                                           strCategoriaArticulosNombreIdParametro, _
                                           intCaprePorcentajeMaximoParametro, _
                                           strCategoriaArticulosNombreParametro, _
                                           imagenEditar)

            resultadoCategoria.AppendFormat("<td align='center' style='width: 25px;' class='{0}'>" & _
                                           "<a href='VentasCapreDescuentoCategoria.aspx?strCmd2=BorrarSingular&strClave={1}" & _
                                           "&intDivisionArticulosId={2}&intCategoriaArticulosId={3}" & _
                                           "'>{4}</a></td>", _
                                           colorRegistro, _
                                           strClaveParametro, _
                                           strDivisionArticulosIdParametro, _
                                           strCategoriaArticulosIdParametro, _
                                           imagenEliminar)

            resultadoCategoria.Append("</tr>")
        Next

        Return resultadoCategoria.ToString()
    End Function

    Private Sub AgregarRegistroSingularCapreMaximoArticulo()
        Dim intResultado As Integer = 0

        intResultado = clsCapreMaximoArticulo. _
                       intActualizarAgregarCapreMaximoArticuloPorCategoria(strDivisionArticulosNombreId, _
                                                                           strCategoriaArticulosNombreId, _
                                                                           CDec(intCaprePorcentajeMaximo), _
                                                                           strUsuarioNombre, _
                                                                           strConnectionString)

        If intResultado > 0 Then
            strJavascriptWindowOnLoadCommands = "window.alert(""Categoría guardada correctamente."");"
        ElseIf intResultado = -2 Then
            strJavascriptWindowOnLoadCommands = String.Format("window.alert(""La categoría {0} no existe."");")
        Else
            strJavascriptWindowOnLoadCommands = "window.alert(""Error al guardar."");"
        End If
    End Sub

    Protected Function LLenarControlDivisionFiltro() As String
        Dim controlDestino As New StringBuilder
        Dim resultadoConsulta As Array = Nothing
        Dim objDivision As New System.Collections.SortedList

        resultadoConsulta = clsDivisionArticulos.strBuscarDivisonArticulos(strConnectionString)

        If Not resultadoConsulta Is Nothing AndAlso resultadoConsulta.Length > 0 Then
            For i As Integer = 0 To resultadoConsulta.Length - 1
                objDivision = CType(resultadoConsulta.GetValue(i), Collections.SortedList)
                controlDestino.AppendFormat("<option value=""{0}"">{1}-{2}</option>", _
                                                  objDivision.Item("intDivisionArticulosId").ToString(), _
                                                  objDivision.Item("strDivisionArticulosNombreId").ToString(), _
                                                  objDivision.Item("strDivisionArticulosNombre").ToString())
            Next
        End If

        Return controlDestino.ToString()
    End Function

    Protected Function LLenarControlDivision() As String
        Dim controlDestino As New StringBuilder
        Dim resultadoConsulta As Array = Nothing
        Dim objDivision As New System.Collections.SortedList

        resultadoConsulta = clsDivisionArticulos.strBuscarDivisonArticulos(strConnectionString)

        If Not resultadoConsulta Is Nothing AndAlso resultadoConsulta.Length > 0 Then
            For i As Integer = 0 To resultadoConsulta.Length - 1
                objDivision = CType(resultadoConsulta.GetValue(i), Collections.SortedList)
                controlDestino.AppendFormat("<option id='{0}' value=""{1}"" >{2}-{3}</option>", _
                                                  objDivision.Item("intDivisionArticulosId").ToString(), _
                                                  objDivision.Item("strDivisionArticulosNombreId").ToString(), _
                                                  objDivision.Item("strDivisionArticulosNombreId").ToString(), _
                                                  objDivision.Item("strDivisionArticulosNombre").ToString())
            Next
        End If

        Return controlDestino.ToString()
    End Function

    Protected Function LLenarControlCategoria() As String
        Dim controlCategoria As New StringBuilder
        Dim resultadoConsulta As Array = Nothing
        Dim objCategoria As New System.Collections.SortedList
        Dim intDivisionArticulosId As Integer

        If Not Request.Form("hdnIntDivisionArticulosId") Is Nothing AndAlso _
           Not Request.Form("hdnIntDivisionArticulosId") = "" Then
            intDivisionArticulosId = CInt(Request.Form("hdnIntDivisionArticulosId"))

            resultadoConsulta = clsCategoriaArticulos.strBuscarCategoriaArticulos(intDivisionArticulosId, strConnectionString)

            If Not resultadoConsulta Is Nothing AndAlso resultadoConsulta.Length > 0 Then

                For i As Integer = 0 To resultadoConsulta.Length - 1
                    objCategoria = CType(resultadoConsulta.GetValue(i), Collections.SortedList)
                    controlCategoria.AppendFormat("<option value=""{0}"">{1}-{2}</option>", _
                                                      objCategoria.Item("strCategoriaArticulosNombreId").ToString(), _
                                                      objCategoria.Item("strCategoriaArticulosNombreId").ToString(), _
                                                      objCategoria.Item("strCategoriaArticulosNombre").ToString())
                Next
            End If
        End If

        Return controlCategoria.ToString()
    End Function

    Private Sub AgregarRegistroCapreMaximoArticuloHistorial()
        Dim intResultado As Integer = 0

        intResultado = clsCapreMaximoArticulo.intAgregarCapreMaximoArticuloHistorial(TipoDescuento.Categoria, strConnectionString)
    End Sub

    Private Sub AgregarRegistroCapreMaximoArticulo(ByVal renglonesArchivoCSV As Array)
        Dim renglonCalendario As Array
        Dim intValorRegreso As Integer = 0
        Dim intCantidadRegistrosExitosos As Integer = 0
        Dim strDivisionArticulosNombreIdArchivo As String
        Dim strCategoriaArticulosNombreIdArchivo As String
        Dim strPorcentajeMaximoArchivo As String = String.Empty
        Dim intCantidadRegistrosSinEncabezadoYSinEspacios As Integer = 0
        Dim arrCategoriasDivisionesAcumuladas As New ArrayList

        intCantidadRegistrosSinEncabezadoYSinEspacios = renglonesArchivoCSV.Length - 2

        If IsNothing(renglonesArchivoCSV) = False AndAlso renglonesArchivoCSV.Length > 0 Then

            For indice As Integer = 1 To renglonesArchivoCSV.Length - 1

                renglonCalendario = DirectCast(renglonesArchivoCSV.GetValue(indice), Array)

                If renglonCalendario.Length > 1 Then

                    strDivisionArticulosNombreIdArchivo = renglonCalendario.GetValue(0).ToString().Trim()
                    strCategoriaArticulosNombreIdArchivo = renglonCalendario.GetValue(1).ToString().Trim()
                    strPorcentajeMaximoArchivo = renglonCalendario.GetValue(2).ToString().Trim()

                    If ValidarRegistrosDivisionCategoriaArchivo(strDivisionArticulosNombreIdArchivo, _
                                                                    strCategoriaArticulosNombreIdArchivo, _
                                                                    arrCategoriasDivisionesAcumuladas) AndAlso _
                       ValidarRegistrosDescuentoArchivo(strPorcentajeMaximoArchivo) Then

                        intValorRegreso = clsCapreMaximoArticulo.intActualizarAgregarCapreMaximoArticuloPorCategoria(strDivisionArticulosNombreIdArchivo, _
                                                                                              strCategoriaArticulosNombreIdArchivo, _
                                                                                              CDec(strPorcentajeMaximoArchivo), _
                                                                                              strUsuarioNombre, _
                                                                                              strConnectionString)
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
                                                        , intCantidadRegistrosExitosos, _
                                                        CStr(intCantidadRegistrosSinEncabezadoYSinEspacios - intCantidadRegistrosExitosos))
        End If

    End Sub

    Private Function ValidarAgregarRegistroDivisionCategoria(ByVal renglonesArchivoCSV As Array) As Boolean
        Dim esValido As Boolean = False
        Dim renglonCalendario As Array
        Dim strDivisionArticulosNombreIdArchivo As String
        Dim strCategoriaArticulosNombreIdArchivo As String
        Dim strPorcentajeMaximoArchivo As String = String.Empty
        Dim intCantidadRegistrosSinEncabezadoYSinEspacios As Integer = 0
        Dim arrCategoriasDivisionesAcumuladas As New ArrayList

        intCantidadRegistrosSinEncabezadoYSinEspacios = renglonesArchivoCSV.Length - 2

        If IsNothing(renglonesArchivoCSV) = False AndAlso renglonesArchivoCSV.Length > 0 Then

            For indice As Integer = 1 To renglonesArchivoCSV.Length - 1

                renglonCalendario = DirectCast(renglonesArchivoCSV.GetValue(indice), Array)

                If renglonCalendario.Length = 3 Then

                    If Not renglonCalendario.GetValue(0) Is Nothing AndAlso _
                       Not renglonCalendario.GetValue(1) Is Nothing AndAlso _
                       Not renglonCalendario.GetValue(2) Is Nothing Then
                        strDivisionArticulosNombreIdArchivo = renglonCalendario.GetValue(0).ToString().Trim()
                        strCategoriaArticulosNombreIdArchivo = renglonCalendario.GetValue(1).ToString().Trim()
                        strPorcentajeMaximoArchivo = renglonCalendario.GetValue(2).ToString().Trim()
                    End If

                    If ValidarRegistrosDivisionCategoriaArchivo(strDivisionArticulosNombreIdArchivo, _
                                                                strCategoriaArticulosNombreIdArchivo, _
                                                                arrCategoriasDivisionesAcumuladas) AndAlso _
                       ValidarRegistrosDescuentoArchivo(strPorcentajeMaximoArchivo) Then

                        esValido = True
                        Exit For
                    End If
                End If
            Next
        End If

        Return esValido
    End Function

    Private Function ValidarRegistrosDivisionCategoriaArchivo(ByVal strDivisionArticulosId As String, _
                                                              ByVal strCategoriaArticulosId As String, _
                                                              ByVal arrCategoriasDivisionesAcumuladas As ArrayList) As Boolean
        Dim blnEsDivisionCategoriaValida As Boolean = True

        If strDivisionArticulosId Is String.Empty Or strCategoriaArticulosId Is String.Empty Then
            blnEsDivisionCategoriaValida = False

        ElseIf Not IsNumeric(strDivisionArticulosId) Then
            blnEsDivisionCategoriaValida = False

        ElseIf Not Regex.IsMatch(strCategoriaArticulosId, "^[A-Za-z]+$") Then
            blnEsDivisionCategoriaValida = False

        ElseIf Not arrCategoriasDivisionesAcumuladas.Contains(strDivisionArticulosId & strCategoriaArticulosId) Then
            arrCategoriasDivisionesAcumuladas.Add(strDivisionArticulosId & strCategoriaArticulosId)
        Else
            blnEsDivisionCategoriaValida = False
        End If

        Return blnEsDivisionCategoriaValida
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

    Private Sub EliminarRegistroCapreMaximoArticulo()
        Dim intResultado As Integer = 0

        intResultado = clsCapreMaximoArticulo. _
                       intEliminarCapreMaximoArticuloPorCategoria(0, _
                                                                  0, _
                                                                  TipoEliminacion.Completa, _
                                                                  strConnectionString)
        If intResultado > 0 Then
            strJavascriptWindowOnLoadCommands = "alert(""Registros eliminados correctamente."");"
        Else
            strJavascriptWindowOnLoadCommands = "window.alert(""Error al eliminar."");"
        End If
    End Sub

    Private Sub EliminarRegistroSingularCapreMaximoArticulo()
        Dim intResultado As Integer = 0

        intResultado = clsCapreMaximoArticulo. _
                       intEliminarCapreMaximoArticuloPorCategoria(intDivisionArticulosId, _
                                                                  intCategoriaArticulosId, _
                                                                  TipoEliminacion.Singular, _
                                                                  strConnectionString)

        If intResultado > 0 Then
            strJavascriptWindowOnLoadCommands = "window.alert(""Categoría eliminada correctamente."");"
        Else
            strJavascriptWindowOnLoadCommands = "window.alert(""Error al eliminar."");"
        End If
    End Sub

    Private Sub EditarRegistroSingularCapreMaximoArticulo()
        Dim intResultado As Integer = 0

        intResultado = clsCapreMaximoArticulo.intActualizarAgregarCapreMaximoArticuloPorCategoria(strDivisionArticulosNombreId, _
                                                                           strCategoriaArticulosNombreId, _
                                                                           CDec(intCaprePorcentajeMaximo), _
                                                                           strUsuarioNombre, _
                                                                           strConnectionString)
        If intResultado > 0 Then
            strJavascriptWindowOnLoadCommands = "window.alert(""Categoría actualizada correctamente."");"
        Else
            strJavascriptWindowOnLoadCommands = "window.alert(""Error al actualizar."");"
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

    Private Function ValidarDivisionesCategoriasExistentes(ByVal arrDivisionesCategoriasArchivo As Array) As Boolean
        Dim blnExisteDivisionesCategorias As Boolean = False
        Dim renglonDivisionCategoria As Array
        Dim divisionesValidar As String
        Dim categoriasValidar As String
        Dim strDivisionArticulosNombreId As String = String.Empty
        Dim strCategoriaArticulosNombreId As String = String.Empty
        Dim strListaDivisiones As New StringBuilder
        Dim strListaCategorias As New StringBuilder
        Dim intCantidadDivisionesCategorias As Integer

        If arrDivisionesCategoriasArchivo.Length > 3 Then

            For indice As Integer = 1 To arrDivisionesCategoriasArchivo.Length - 2

                renglonDivisionCategoria = DirectCast(arrDivisionesCategoriasArchivo.GetValue(indice), Array)

                If renglonDivisionCategoria.Length = 3 Then
                    strDivisionArticulosNombreId = renglonDivisionCategoria.GetValue(0).ToString().Trim()
                    strCategoriaArticulosNombreId = renglonDivisionCategoria.GetValue(1).ToString().Trim()

                    strListaDivisiones.AppendFormat(" ''{0}'',", strDivisionArticulosNombreId)
                    strListaCategorias.AppendFormat(" ''{0}'',", strCategoriaArticulosNombreId)

                    divisionesValidar = String.Format("' {0} '", strListaDivisiones.ToString().Substring(0, strListaDivisiones.Length - 1))
                    categoriasValidar = String.Format("' {0} '", strListaCategorias.ToString().Substring(0, strListaCategorias.Length - 1))
                End If
            Next
        Else
            renglonDivisionCategoria = DirectCast(arrDivisionesCategoriasArchivo.GetValue(1), Array)

            strDivisionArticulosNombreId = renglonDivisionCategoria.GetValue(0).ToString().Trim()
            strCategoriaArticulosNombreId = renglonDivisionCategoria.GetValue(1).ToString().Trim()

            strListaDivisiones.AppendFormat("'''{0}'''", strDivisionArticulosNombreId)
            strListaCategorias.AppendFormat("'''{0}'''", strCategoriaArticulosNombreId)

            divisionesValidar = strListaDivisiones.ToString()
            categoriasValidar = strListaCategorias.ToString()
        End If

        intCantidadDivisionesCategorias = clsCapreMaximoArticulo. _
                                         strConsultarCantidadDivisionesCategoriasExistentes(divisionesValidar, _
                                                                                            categoriasValidar, _
                                                                                            strConnectionString)
        If intCantidadDivisionesCategorias > 0 Then
            blnExisteDivisionesCategorias = True
        End If

        Return blnExisteDivisionesCategorias
    End Function


End Class