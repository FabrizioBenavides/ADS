Imports System.Text
Imports System.Collections
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports System.IO
Imports Benavides.CC.Business.clsConcentrador.clsCapre

Public Class VentasCapreDescuentoRematadora
    Inherits PaginaBase

    Private Enum TipoEliminacion
        Singular = 1
        Completa = 2
    End Enum

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents txtArchivo As System.Web.UI.HtmlControls.HtmlInputFile

    Public ReadOnly Property strCmd2() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd2", "")
        End Get
    End Property

    Public ReadOnly Property strCentroLogisticoId() As String
        Get
            Return GetPageParameter("strCentroLogisticoId", "")
        End Get
    End Property

    Public ReadOnly Property strCentroLogisticoIdValorNuevo() As String
        Get
            Return GetPageParameter("strCentroLogisticoIdValorNuevo", "")
        End Get
    End Property

    Public ReadOnly Property fltCaprePorcentajeMaximo() As Decimal
        Get
            Return CDec(GetPageParameter("fltCaprePorcentajeMaximo", "0"))
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

            Case "Aplicar"
                Call AgregarRegistroSucursalRematadoraHistorial()
                Call AplicarRegistroSucursalRematadora()

            Case "Agregar"
                If Not EsArchivoInvalido() Then
                    renglonesArchivoCSV = CreateArrayFromCSVHttpPostedFile(txtArchivo.PostedFile)

                    If ValidarAgregarRegistroSucursal(renglonesArchivoCSV) Then

                        If ValidarSucursalesExistentes(renglonesArchivoCSV) Then
                            Call AgregarRegistroSucursalRematadoraHistorial()
                            Call AgregarRegistroSucursalRematadora(renglonesArchivoCSV)
                        Else
                            strJavascriptWindowOnLoadCommands = "window.alert(""Las sucursales del archivo no existen."");"
                        End If
                    Else
                        strJavascriptWindowOnLoadCommands = "window.alert(""El archivo a agregar contiene todos los registros invalidos."");"
                    End If
                End If

            Case "Reemplazar"
                If Not EsArchivoInvalido() Then
                    renglonesArchivoCSV = CreateArrayFromCSVHttpPostedFile(txtArchivo.PostedFile)

                    If ValidarAgregarRegistroSucursal(renglonesArchivoCSV) Then

                        If ValidarSucursalesExistentes(renglonesArchivoCSV) Then
                            Call AgregarRegistroSucursalRematadoraHistorial()
                            Call EliminarRegistroSucursalRematadora()
                            Call AgregarRegistroSucursalRematadora(renglonesArchivoCSV)
                        Else
                            strJavascriptWindowOnLoadCommands = "window.alert(""Las sucursales del archivo no existen."");"
                        End If
                    Else
                        strJavascriptWindowOnLoadCommands = "window.alert(""El archivo a reemplazar contiene todos registros invalidos."");"
                    End If
                End If

            Case "Eliminar"
                Call AgregarRegistroSucursalRematadoraHistorial()
                Call EliminarRegistroSucursalRematadora()

            Case "EditarRegistroSingularSucursalRematadora"
                Call EditarRegistroSingularSucursalRematadora()

            Case "EliminarRegistroSingularSucursalRematadora"
                Call EliminarRegistroSingularSucursalRematadora()

            Case "AgregarRegistroSingularSucursalRematadora"
                Call AgregarRegistroSingularSucursalRematadora()

        End Select
    End Sub

    Private Function ValidarSucursalesExistentes(ByVal arrSucursalesArchivo As Array) As Boolean
        Dim blnExisteSucursal As Boolean = False
        Dim renglonSucursales As Array
        Dim strCentroLogisticoId As String = String.Empty
        Dim strListaSucursales As New StringBuilder
        Dim sucursalesValidar As String
        Dim intCantidadSucursales As Integer

        If arrSucursalesArchivo.Length > 3 Then

            For indice As Integer = 1 To arrSucursalesArchivo.Length - 1
                renglonSucursales = DirectCast(arrSucursalesArchivo.GetValue(indice), Array)
                strCentroLogisticoId = renglonSucursales.GetValue(0).ToString().Trim()

                If strCentroLogisticoId.Length > 1 Then
                    strListaSucursales.AppendFormat(" ''{0}'',", strCentroLogisticoId)
                End If
            Next

            sucursalesValidar = String.Format("' {0} '", strListaSucursales.ToString().Substring(0, strListaSucursales.Length - 1))
        Else
            renglonSucursales = DirectCast(arrSucursalesArchivo.GetValue(1), Array)
            strCentroLogisticoId = renglonSucursales.GetValue(0).ToString().Trim()
            strListaSucursales.AppendFormat("'''{0}'''", strCentroLogisticoId)

            sucursalesValidar = strListaSucursales.ToString()
        End If

        intCantidadSucursales = clsCapreSucursalRematadora.strConsultarCantidadSucursalesExistentes(sucursalesValidar, strConnectionString)

        If intCantidadSucursales > 0 Then
            blnExisteSucursal = True
        End If

        Return blnExisteSucursal
    End Function

    Protected Function strObtenerSucursalesRematadoras() As String
        Dim strResultadoTablaSucursalRematadora As New StringBuilder
        Dim objSucursalesRematadoras As Array

        objSucursalesRematadoras = clsCapreSucursalRematadora.strBuscarCapreSucursalRematadora(strConnectionString)

        If IsArray(objSucursalesRematadoras) AndAlso objSucursalesRematadoras.Length > 0 Then
            strResultadoTablaSucursalRematadora.AppendFormat("<span class='campotablaresultado' style='margin-left:650px'>{0} Registro(s)</span>", objSucursalesRematadoras.Length)
            strResultadoTablaSucursalRematadora.Append("<table id='tablaSucursales' width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strResultadoTablaSucursalRematadora.Append("<tr class='trtitulos'>")
            strResultadoTablaSucursalRematadora.Append("<th class='rayita'>Local SAP</th>")
            strResultadoTablaSucursalRematadora.Append("<th class='rayita'>CIA SUC</th>")
            strResultadoTablaSucursalRematadora.Append("<th class='rayita'>Nombre Sucursal</th>")
            strResultadoTablaSucursalRematadora.Append("<th class='rayita'>Región</th>")
            strResultadoTablaSucursalRematadora.Append("<th class='rayita'>Zona</th>")
            strResultadoTablaSucursalRematadora.Append("<th class='rayita'>Descuento(%)</th>")
            strResultadoTablaSucursalRematadora.Append("<th class='rayita' colspan='2'>Acción</th>")
            strResultadoTablaSucursalRematadora.Append("</tr>")

            strResultadoTablaSucursalRematadora.Append(CrearRegistrosSucursalesRematadoras(objSucursalesRematadoras))

            strResultadoTablaSucursalRematadora.Append("</table>")
        End If

        Return strResultadoTablaSucursalRematadora.ToString()
    End Function

    Private Function CrearRegistrosSucursalesRematadoras(ByVal registrosSucursalRematadora As Array) As String
        Dim contadorRegistros As Integer = 0
        Dim colorRegistro As String = String.Empty
        Dim resultadoSucursal As New StringBuilder
        Dim imagenEditar As String = "<img src='../static/images/icono_editar.gif' width='11' height='13' border='0' align='center' alt='Haga clic aquí para editar' title='Haga clic aquí para editar'>"
        Dim imagenEliminar As String = "<img src='../static/images/imgNREliminar.gif' width='11' height='13' border='0' align='center' alt='Haga clic aquí para eliminar' title='Haga clic aquí para eliminar'>"
        Dim strCentroLogisticoId As String
        Dim intCaprePorcentajeMaximo As Integer

        For Each renglon As SortedList In registrosSucursalRematadora
            contadorRegistros += 1

            If (contadorRegistros Mod 2) <> 0 Then
                colorRegistro = "tdceleste"
            Else
                colorRegistro = "tdblanco"
            End If

            resultadoSucursal.Append("<tr>")

            strCentroLogisticoId = renglon.Item("strCentroLogisticoId").ToString()
            intCaprePorcentajeMaximo = CInt(renglon.Item("fltCaprePorcentajeMaximo"))

            resultadoSucursal.AppendFormat("<td class='{0}'>{1}</td>", colorRegistro, strCentroLogisticoId)
            resultadoSucursal.AppendFormat("<td class='{0}'>{1}</td>", colorRegistro, renglon.Item("CIA"))
            resultadoSucursal.AppendFormat("<td class='{0}'>{1}</td>", colorRegistro, renglon.Item("strSucursalNombre"))
            resultadoSucursal.AppendFormat("<td class='{0}'>{1}</td>", colorRegistro, renglon.Item("strDireccionOperativaNombre"))
            resultadoSucursal.AppendFormat("<td class='{0}'>{1}</td>", colorRegistro, renglon.Item("strZonaOperativaNombre"))
            resultadoSucursal.AppendFormat("<td class='{0}' style='text-align: center;'>{1}</td>", colorRegistro, intCaprePorcentajeMaximo)

            resultadoSucursal.AppendFormat("<td align='center' style='width: 25px;' class='{0}'>" & _
                                           "<a href='VentasCapreDescuentoRematadora.aspx?strCmd2=ActualizarSingular&strCentroLogisticoId={1}" & _
                                           "&fltCaprePorcentajeMaximo={2}" & _
                                           "'>{3}</a></td>", _
                                           colorRegistro, _
                                           strCentroLogisticoId, _
                                           intCaprePorcentajeMaximo, _
                                           imagenEditar)

            resultadoSucursal.AppendFormat("<td align='center' style='width: 25px;' class='{0}'>" & _
                                           "<a href='VentasCapreDescuentoRematadora.aspx?strCmd2=BorrarSingular&strCentroLogisticoId={1}" & _
                                           "'>{2}</a></td>", _
                                           colorRegistro, _
                                           strCentroLogisticoId, _
                                           imagenEliminar)

            resultadoSucursal.Append("</tr>")
        Next

        Return resultadoSucursal.ToString()
    End Function

    Private Sub AplicarRegistroSucursalRematadora()
        Dim intResultado As Integer = 0

        intResultado = clsCapreSucursalRematadora. _
                       intActualizarPorcentajeCapreSucursalRematadora(fltCaprePorcentajeMaximo, _
                                                                      strUsuarioNombre, _
                                                                      strConnectionString)

        If intResultado > 0 Then
            strJavascriptWindowOnLoadCommands = "window.alert(""Cambio de precio aplicado correctamente."");"
        End If
    End Sub

    Private Sub AgregarRegistroSucursalRematadora(ByVal renglonesArchivoCSV As Array)
        Dim renglonSucursal As Array
        Dim intValorRegreso As Integer = 0
        Dim intCantidadRegistrosExitosos As Integer = 0
        Dim strCentroLogisticoId As String = String.Empty
        Dim strPorcentajeMaximo As String = String.Empty
        Dim intCantidadRegistrosSinEncabezadoYSinEspacios As Integer = 0
        Dim arrSucursalesAcumuladas As New ArrayList

        intCantidadRegistrosSinEncabezadoYSinEspacios = renglonesArchivoCSV.Length - 2

        For indice As Integer = 1 To renglonesArchivoCSV.Length - 1

            renglonSucursal = DirectCast(renglonesArchivoCSV.GetValue(indice), Array)

            If renglonSucursal.Length > 1 Then

                strCentroLogisticoId = renglonSucursal.GetValue(0).ToString().Trim()
                strPorcentajeMaximo = renglonSucursal.GetValue(1).ToString().Trim()

                If ValidarRegistrosSucursalArchivo(strCentroLogisticoId, arrSucursalesAcumuladas) AndAlso ValidarRegistrosDescuentoArchivo(strPorcentajeMaximo) Then

                    intValorRegreso = clsCapreSucursalRematadora. _
                                      intActualizarAgregarCapreSucursalRematadora(strCentroLogisticoId, _
                                                                                  CDec(strPorcentajeMaximo), _
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
                                            "window.alert(""Total de líneas en el archivo: {0} \n\r\n\r" & _
                                                    "Total de registros importados: {1} \n\r\n\r" & _
                                                    "Total de registros sin importar: {2}\n\r"");" _
                                                    , intCantidadRegistrosSinEncabezadoYSinEspacios _
                                                    , intCantidadRegistrosExitosos, _
                                                    CStr(intCantidadRegistrosSinEncabezadoYSinEspacios - intCantidadRegistrosExitosos))

    End Sub

    Private Function ValidarAgregarRegistroSucursal(ByVal renglonesArchivoCSV As Array) As Boolean
        Dim esValido As Boolean = False
        Dim renglonCalendario As Array
        Dim strCentroLogisticoId As String = String.Empty
        Dim strPorcentajeMaximo As String = String.Empty
        Dim intCantidadRegistrosSinEncabezadoYSinEspacios As Integer = 0
        Dim arrSucursalesAcumuladas As New ArrayList

        intCantidadRegistrosSinEncabezadoYSinEspacios = renglonesArchivoCSV.Length - 2

        If IsNothing(renglonesArchivoCSV) = False AndAlso renglonesArchivoCSV.Length > 0 Then

            For indice As Integer = 1 To renglonesArchivoCSV.Length - 1

                renglonCalendario = DirectCast(renglonesArchivoCSV.GetValue(indice), Array)

                If renglonCalendario.Length > 1 Then
                    If Not renglonCalendario.GetValue(0) Is Nothing AndAlso Not renglonCalendario.GetValue(1) Is Nothing Then
                        strCentroLogisticoId = renglonCalendario.GetValue(0).ToString().Trim()
                        strPorcentajeMaximo = renglonCalendario.GetValue(1).ToString().Trim()
                    End If

                    If ValidarRegistrosSucursalArchivo(strCentroLogisticoId, arrSucursalesAcumuladas) AndAlso ValidarRegistrosDescuentoArchivo(strPorcentajeMaximo) Then

                        esValido = True
                        Exit For
                    End If
                End If
            Next
        End If

        Return esValido
    End Function

    Private Function ValidarRegistrosSucursalArchivo(ByVal strCentroLogisticoId As String, ByVal arrSucursalesAcumuladas As ArrayList) As Boolean
        Dim blnEsSucursalValida As Boolean = True

        If strCentroLogisticoId Is String.Empty Then
            blnEsSucursalValida = False

        ElseIf Not (String.Equals(strCentroLogisticoId.Chars(0), "M") Or String.Equals(strCentroLogisticoId.Chars(0), "m") Or _
                    String.Equals(strCentroLogisticoId.Chars(0), "N") Or String.Equals(strCentroLogisticoId.Chars(0), "n") Or _
                    String.Equals(strCentroLogisticoId.Chars(0), "X") Or String.Equals(strCentroLogisticoId.Chars(0), "X")) Then

            blnEsSucursalValida = False

        ElseIf Not arrSucursalesAcumuladas.Contains(strCentroLogisticoId) Then
            arrSucursalesAcumuladas.Add(strCentroLogisticoId)
        Else
            blnEsSucursalValida = False
        End If

        Return blnEsSucursalValida
    End Function

    Private Function ValidarRegistrosDescuentoArchivo(ByVal strPorcentajeMaximo As String) As Boolean
        Dim blnEsDescuentoValido As Boolean = True
        Dim intPorcentajeMaximo As Integer = 0

        If strPorcentajeMaximo Is String.Empty Then
            blnEsDescuentoValido = False

        ElseIf Not IsNumeric(strPorcentajeMaximo) Then
            blnEsDescuentoValido = False

        ElseIf InStr(strPorcentajeMaximo, ".") > 0 Then
            'strPorcentajeMaximo.Contains(".")
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

    Private Sub EditarRegistroSingularSucursalRematadora()
        Dim intResultado As Integer = 0

        intResultado = clsCapreSucursalRematadora. _
                       intActualizarSingularPorcentajeCapreSucursalRematadora(strCentroLogisticoId, _
                                                                             strCentroLogisticoIdValorNuevo, _
                                                                             fltCaprePorcentajeMaximo, _
                                                                             strUsuarioNombre, _
                                                                             strConnectionString)

        If intResultado > 0 Then
            strJavascriptWindowOnLoadCommands = "window.alert(""Sucursal actualizada correctamente."");"
        ElseIf intResultado = -2 Then
            strJavascriptWindowOnLoadCommands = String.Format("window.alert(""La sucursal {0} no existe."");", strCentroLogisticoIdValorNuevo)
        ElseIf intResultado = -3 Then
            strJavascriptWindowOnLoadCommands = String.Format("window.alert(""La sucursal {0} ya existe en la lista."");", strCentroLogisticoIdValorNuevo)
        Else
            strJavascriptWindowOnLoadCommands = "window.alert(""Error al actualizar."");"
        End If
    End Sub

    Private Sub EliminarRegistroSucursalRematadora()
        Dim intResultado As Integer = 0

        intResultado = clsCapreSucursalRematadora. _
                       intEliminarCapreSucursalRematadora("", TipoEliminacion.Completa, strConnectionString)

        If intResultado > 0 Then
            strJavascriptWindowOnLoadCommands = "window.alert(""Sucursales eliminadas correctamente."");"
        Else
            strJavascriptWindowOnLoadCommands = "window.alert(""Error al eliminar."");"
        End If
    End Sub

    Private Sub EliminarRegistroSingularSucursalRematadora()
        Dim intResultado As Integer = 0

        intResultado = clsCapreSucursalRematadora. _
                       intEliminarCapreSucursalRematadora(strCentroLogisticoId, TipoEliminacion.Singular, strConnectionString)

        If intResultado > 0 Then
            strJavascriptWindowOnLoadCommands = "window.alert(""Sucursal eliminada correctamente."");"
        Else
            strJavascriptWindowOnLoadCommands = "window.alert(""Error al eliminar."");"
        End If
    End Sub

    Private Sub AgregarRegistroSingularSucursalRematadora()
        Dim intResultado As Integer = 0

        intResultado = clsCapreSucursalRematadora.intAgregarSingularCapreSucursalRematadora(strCentroLogisticoId, _
                                                                                            fltCaprePorcentajeMaximo, _
                                                                                            strUsuarioNombre, _
                                                                                            strConnectionString)

        If intResultado > 0 Then
            strJavascriptWindowOnLoadCommands = "window.alert(""Sucursal guardada correctamente."");"
        ElseIf intResultado = -2 Then
            strJavascriptWindowOnLoadCommands = String.Format("window.alert(""La sucursal {0} no existe."");", strCentroLogisticoIdValorNuevo)
        ElseIf intResultado = -3 Then
            strJavascriptWindowOnLoadCommands = String.Format("window.alert(""La sucursal {0} ya es una sucursal rematadora."");", strCentroLogisticoIdValorNuevo)
        Else
            strJavascriptWindowOnLoadCommands = "window.alert(""Error al guardar."");"
        End If
    End Sub

    Private Sub AgregarRegistroSucursalRematadoraHistorial()
        Dim intResultado As Integer = 0

        intResultado = clsCapreSucursalRematadora.intAgregarCapreSucursalRematadoraHistorial(strConnectionString)
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


End Class