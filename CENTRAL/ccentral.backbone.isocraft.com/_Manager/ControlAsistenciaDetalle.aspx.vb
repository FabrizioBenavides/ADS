Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Benavides.POSAdmin.Commons.clsCommons.clsMSMQ
Imports System.Text
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports System.IO
Imports System.Web.Caching

Public Class ControlAsistenciaDetalle
    Inherits System.Web.UI.Page

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strHTMLFechaHora
    ' Description: Genera la fecha y hora de la página
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
        End Get
    End Property

    '====================================================================
    ' Name       : intGrupoUsuarioId
    ' Description: Identificador del Grupo de Usuario
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intGrupoUsuarioId() As Integer
        Get
            Return CInt(Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strFormAction
    ' Description: HTML form's action property value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormAction() As String
        Get
            Return strThisPageName
        End Get
    End Property

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Connection string
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Private ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: Name of this page
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request)
        End Get
    End Property

    '====================================================================
    ' Name       : strEmpleadoId
    ' Description: Codigo del empleado
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strEmpleadoId() As String
        Get
            If Not IsNothing(Request.QueryString("strEmpleadoId")) Then

                'Si es parametro de la pantalla anterior
                Return Request.QueryString("strEmpleadoId")

            ElseIf Not IsNothing(Request.Form("hdnEmpleadoId")) Then

                'Parametro en campo oculto.
                Return Request.Form("hdnEmpleadoId")

            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strMovimientoId
    ' Description: Codigo del movimiento
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strMovimientoId() As String
        Get
            If Not IsNothing(Request.QueryString("strMovimientoId")) Then

                'Si es parametro de la pantalla anterior
                Return Request.QueryString("strMovimientoId")

            ElseIf Not IsNothing(Request.Form("hdnMovimientoId")) Then

                'Parametro en campo oculto.
                Return Request.Form("hdnMovimientoId")

            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaInicio
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaInicio() As Date
        Get
            Dim f As String = Request.QueryString("dtmFechaInicio")
            If Not IsNothing(f) Then
                Dim fp As String() = f.Split("/".ToCharArray())

                Return New Date(CInt(fp(2)), CInt(fp(1)), CInt(fp(0)))
            ElseIf Not IsNothing(Request.Form("hdnFechaInicio")) Then
                Return CDate(Request.Form("hdnFechaInicio"))
            Else
                Return CDate("01/01/1900")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaFin
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaFin() As Date
        Get
            Dim f As String = Request.QueryString("dtmFechaFin")
            If Not IsNothing(f) Then
                Dim fp As String() = f.Split("/".ToCharArray())

                Return New Date(CInt(fp(2)), CInt(fp(1)), CInt(fp(0)))
            ElseIf Not IsNothing(Request.Form("hdnFechaFin")) Then
                Return CDate(Request.Form("hdnFechaFin"))
            Else
                Return CDate("01/01/1900")
            End If
        End Get
    End Property

    Public ReadOnly Property strControlAsistenciaObservacionesId As String
        Get
            If Not IsNothing(Request.QueryString("strControlAsistenciaObservacionesId")) Then
                ' Si es parametro de la pantalla anterior.
                Return Request.QueryString("strControlAsistenciaObservacionesId")
            ElseIf Not IsNothing(Request.Form("hdnControlAsistenciaObservacionesId")) Then

                ' Parámetro en campo oculto.
                Return Request.Form("hdnControlAsistenciaObservacionesId")
            Else
                Return "-1"
            End If
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objArrayDetalle As Array = Nothing

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        If IsNothing(strEmpleadoId) Or (CInt(strEmpleadoId) <= 0) Then
            Response.Redirect("ControlAsistencia.aspx")
        End If

        'Imprimir
        If Request.QueryString("strCmd") = "cmdImprimir" Then

            Dim strHTML As New StringBuilder
            Dim strRecordBrowserImpresion As String = String.Empty
            Const strComitasDobles As String = """"

            objArrayDetalle = strObtenerDetalleMovimientos()

            If IsArray(objArrayDetalle) AndAlso objArrayDetalle.Length > 0 Then

                'Se envia la informacion a imprimir para darle formato de acuerdo a la tabla seleccionada por el usuario.  
                strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strImpresionDetalle(objArrayDetalle))

                'Se ennvia a impresion.
                strHTML.Append("<script language='Javascript'>parent.fnImprimir( " & _
                strComitasDobles & strRecordBrowserImpresion.ToString & strComitasDobles & _
                "); </script>")
                Response.Write(strHTML.ToString)
                Response.End()

            End If
        End If

        If Request.QueryString("strCmd") = "cmdExportar" Then

            objArrayDetalle = strObtenerDetalleMovimientos()

            ' Establecemos en la respuesta los parámetros de configuración del archivo
            Response.ContentType = "application/vnd.ms-excel"
            Call Response.AddHeader("Content-Disposition", "attachment; filename=""Control de Asistencia : Detalle.xls""")
            Call Response.Write(strTablaConsultaVerDetalleExportar(objArrayDetalle))
            Call Response.End()
        End If

    End Sub

#Region "Detalle"

    Public Function strTablaDetalleMovimientos() As String
        Dim objArray As Array = Nothing

        'Paginacion
        If Not (Request.QueryString("strCmd") = "cmdImprimir") AndAlso Not (Request.QueryString("strCmd") = "cmdExportar") Then

            If (Request.QueryString("pager") = "true") Then
                If Not Cache("cacheDetalle") Is Nothing Then
                    objArray = CType(Cache("cacheDetalle"), System.Array)
                End If
            End If

            If objArray Is Nothing Then
                Cache.Remove("cacheDetalle")
                objArray = strObtenerDetalleMovimientos()
            End If

            Dim strResult As New StringBuilder()
            If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then
                Cache.Add("cacheDetalle", objArray, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, Nothing)

                strResult.Append(strTablaConsultaDetalleMovimientosHTML(objArray))
            Else
                strResult.Append(String.Empty)
                strResult.Append("<script language=""javascript"" type=""text/javascript"">")
                strResult.Append("</script>")
                Call Response.Write("<script language='Javascript'>alert('Detalle sin resultados');</script>")

            End If

            strResult.Append("<script language=""javascript"" type=""text/javascript"">")
            strResult.Append("parent.document.getElementById('tblResultados').innerHTML = document.getElementById('divConsultaMovimientos').innerHTML;")
            strResult.Append("</script>")

            Return strResult.ToString()
        End If

        Return String.Empty
    End Function

    Public Function strTablaConsultaDetalleMovimientosHTML(ByVal objConsultaDetalleMovimientos As Array) As String
        'Variables
        Dim strTablaDetalleHTML As StringBuilder
        Dim strConsultaMovimientos As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim strConfirmado As String

        Dim intPage As Integer
        Dim intTotal As Integer = 50
        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If

        strTablaDetalleHTML = New StringBuilder
        strTablaDetalleHTML.Append(Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objConsultaDetalleMovimientos.Length, intPage, intTotal, String.Empty, Nothing))

        strTablaDetalleHTML.Append("<table border='0' cellpadding='0' cellspacing='0' style='width:100%;'>")

        strTablaDetalleHTML.Append("<tr class='trtitulos'>")
        strTablaDetalleHTML.Append("<th align=center class='rayita' valign='top'>No.</th>")
        strTablaDetalleHTML.Append("<th align=center class='rayita' valign='top'>Empleado</th>")
        strTablaDetalleHTML.Append("<th align=center class='rayita' valign='top'>Centro Logistico</th>")
        strTablaDetalleHTML.Append("<th align=center class='rayita' valign='top'>Sucursal</th>")
        strTablaDetalleHTML.Append("<th align=center class='rayita' valign='top'>Movimiento</th>")
        strTablaDetalleHTML.Append("<th align=center class='rayita' valign='top'>Descripción</th>")
        strTablaDetalleHTML.Append("<th align=center class='rayita' valign='top'>Obs.</th>")
        strTablaDetalleHTML.Append("<th align=center class='rayita' valign='top'>Fecha</th>")
        strTablaDetalleHTML.Append("<th align=center class='rayita' valign='top'>Confirmado</th>")
        strTablaDetalleHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaDetalleMovimientos.Length) Then
                Exit For
            End If

            strConsultaMovimientos = CType(objConsultaDetalleMovimientos.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strConfirmado = "No"
            If (CBool(strConsultaMovimientos(10)) = True) Then
                strConfirmado = "Si"
            End If

            strTablaDetalleHTML.Append("<tr>")

            'No
            strTablaDetalleHTML.Append("<td width='7%' class=" & strColorRegistro & " align='center'>" & strConsultaMovimientos(1).ToString() & "</td>")
            'Empleado.
            strTablaDetalleHTML.Append("<td width='23%' class=" & strColorRegistro & " align='left'>" & clsCommons.strFormatearDescripcion(strConsultaMovimientos(2)) & "</td>")
            'Centro Logistico               
            strTablaDetalleHTML.Append("<td width='8%' class=" & strColorRegistro & " align='center'>" & clsCommons.strFormatearDescripcion(strConsultaMovimientos(3)) & "</td>")
            'Sucursal
            strTablaDetalleHTML.Append("<td width='20%' class=" & strColorRegistro & " align='left'>" & clsCommons.strFormatearDescripcion(strConsultaMovimientos(6)) & "</td>")
            'Movimiento
            strTablaDetalleHTML.Append("<td width='7%' class=" & strColorRegistro & " align='center'>" & strConsultaMovimientos(7) & "</td>")
            'Descripcion
            strTablaDetalleHTML.Append("<td width='18%' class=" & strColorRegistro & " align='center'>" & clsCommons.strFormatearDescripcion(strConsultaMovimientos(8)) & "</td>")
            ' Obs.
            strTablaDetalleHTML.Append("<td width='7%' class=" & strColorRegistro & " align='center'>" & strConsultaMovimientos(12) & "</td>")
            'Fecha                  
            strTablaDetalleHTML.Append("<td width='10%' class=" & strColorRegistro & " align='center'>" & clsCommons.strFormatearFechaPresentacion(strConsultaMovimientos(9)) & "</td>")
            'Confirmado
            strTablaDetalleHTML.Append("<td width='7%' class=" & strColorRegistro & " align='center'>" & strConfirmado & "</td>")
            strTablaDetalleHTML.Append("</tr>")

        Next
        strTablaDetalleHTML.Append("</tr>")
        strTablaDetalleHTML.Append("</table>")
        strTablaDetalleHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaDetalleMovimientosHTML = strTablaDetalleHTML.ToString
    End Function

    Private Function strObtenerDetalleMovimientos() As Array
        Dim resultado As Array

        resultado = Benavides.CC.Data.clsControlDeAsistencia.strObtenerDetalleMovimientos( _
                              CInt(strEmpleadoId), CInt(strMovimientoId), dtmFechaInicio, _
                              dtmFechaFin, CInt(strControlAsistenciaObservacionesId), strConnectionString)

        Return resultado
    End Function

#End Region

#Region "Imprimir"

    '====================================================================
    ' Name       : strImpresionDetalle
    ' Description: Generacion de tabla HTML con formato para imprimir resultados de la consulta.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImpresionDetalle(ByVal objDetalleMovimientos As Array) As String

        'Variables
        Dim strImpresionDetalleHTML As StringBuilder = New StringBuilder
        Dim strConsultaDetalleMovimientos As String()
        Dim strclase As String = String.Empty
        Dim intRenglonesxPagina As Integer = 58
        Dim imgImplementado As String = String.Empty
        Dim strConfirmado As String


        'Rutina que solo se ejecuta al contener informacion de la consulta.
        If IsArray(objDetalleMovimientos) AndAlso (objDetalleMovimientos.Length > 0) Then

            Dim intTotalRenglones As Integer = objDetalleMovimientos.Length
            Dim intTotalPaginas As Integer = 0
            Dim intPagina As Integer = 0
            Dim intRenglon As Integer = 0
            Dim intContadorRenglon As Integer = 0

            'Total de paginas a imprimir.
            intTotalPaginas = CInt(intTotalRenglones \ intRenglonesxPagina)

            'Si se necesita una pagina mas se agrega.
            If intTotalRenglones Mod intRenglonesxPagina > 0 Then
                intTotalPaginas += 1
            End If

            'Inicio de ciclo que da formato a la informacion a imprimir.
            For Each strConsultaDetalleMovimientos In objDetalleMovimientos

                intRenglon += 1
                intContadorRenglon += 1

                If intRenglon = 1 Then
                    intPagina += 1

                    'Salto de hoja
                    If intPagina > 1 Then
                        strImpresionDetalleHTML.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")
                    End If

                    strImpresionDetalleHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    'Metodo que genera y da formato al encabezado.
                    strImpresionDetalleHTML.Append(strImprimeEncabezadoDetalleMovimientos(intPagina.ToString, intTotalPaginas.ToString))
                End If

                'Clases para renglones.
                If ((intRenglon Mod 2) = 0) Then
                    strclase = "tdtxtImpresionNormal"
                Else
                    strclase = "tdtxtImpresionBold"
                End If


                strConfirmado = "No"
                If (CBool(strConsultaDetalleMovimientos(10)) = True) Then
                    strConfirmado = "Si"
                End If

                strImpresionDetalleHTML.Append("<tr>")
                'No.
                strImpresionDetalleHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & strConsultaDetalleMovimientos(1).ToString() & "</td>")
                'Empleado
                strImpresionDetalleHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strConsultaDetalleMovimientos(2)) & "</td>")
                'Centro Logistico
                strImpresionDetalleHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strConsultaDetalleMovimientos(3)) & "</td>")
                'Sucursal
                strImpresionDetalleHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strConsultaDetalleMovimientos(6)) & "</td>")
                'Movimiento
                strImpresionDetalleHTML.Append("<td width='20%' align='center' class='" & strclase & "' nowrap >" & strConsultaDetalleMovimientos(7).ToString() & "</td>")
                'Descripcion
                strImpresionDetalleHTML.Append("<td width='10%' align='center' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strConsultaDetalleMovimientos(8)).ToString() & "</td>")
                'Obs.
                strImpresionDetalleHTML.Append("<td width='10%' align='center' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strConsultaDetalleMovimientos(12)).ToString() & "</td>")
                'Fecha
                strImpresionDetalleHTML.Append("<td width='10%' align='center' class='" & strclase & "'>" & clsCommons.strFormatearFechaPresentacion(strConsultaDetalleMovimientos(9)) & "</td>")
                'Confirmado
                strImpresionDetalleHTML.Append("<td width='10%' align='center' class='" & strclase & "'>" & strConfirmado & "</td>")

                strImpresionDetalleHTML.Append("</tr>")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionDetalleHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next

        End If

        Return strImpresionDetalleHTML.ToString()

    End Function

    Private Function strImprimeEncabezadoDetalleMovimientos(ByVal strHojaActual As String, ByVal strHojaFinal As String) As String

        Dim strHtmlEncabezado As StringBuilder
        strHtmlEncabezado = New StringBuilder

        'Encabezado principal
        strHtmlEncabezado.Append("<tr>")
        strHtmlEncabezado.Append("<td colspan='8'>")
        strHtmlEncabezado.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='8' class='tdtxtBold'>Asistencia - Detalle de Movimientos</th>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='40%' align='left'   class='tdtxtBold' colspan='3' nowrap>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th width='50%' align='right' class='tdtxtBold' colspan='3' nowrap>ADS Central</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' colspan='2' nowrap></th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strHtmlEncabezado.Append("</td>")
        strHtmlEncabezado.Append("</tr>")

        'Encabezado titulos
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>No.</th>")
        strHtmlEncabezado.Append("<th width='20%' class='tdtxtBold' align='center' nowrap>Empleado</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Centro Logistico</th>")
        strHtmlEncabezado.Append("<th width='15%' class='tdtxtBold' align='center' nowrap>Sucursal</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Movimiento</th>")
        strHtmlEncabezado.Append("<th width='15%' class='tdtxtBold' align='center' nowrap>Descripción</th>")
        strHtmlEncabezado.Append("<th width='15%' class='tdtxtBold' align='center' nowrap>Obs.</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Fecha</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Confirmado</th>")
        strHtmlEncabezado.Append("</tr>")


        'Raya Sola
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' class='rayita' colspan='9'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        strImprimeEncabezadoDetalleMovimientos = strHtmlEncabezado.ToString

    End Function

#End Region

#Region "Exportar"

    Public Function strTablaConsultaVerDetalleExportar(ByVal objConsultaDetalle As Array) As String
        Dim strTablaEspaciosHTML As StringBuilder
        Dim strConsultaDetalle As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim strConfirmado As String

        strTablaEspaciosHTML = New StringBuilder
        strTablaEspaciosHTML.Append("<span class='txsubtitulo'> </span> ")
        strTablaEspaciosHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strTablaEspaciosHTML.Append("<tr class='trtitulos'>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>No.</th>")
        strTablaEspaciosHTML.Append("<th width='20%' align=center class='rayita' align='left' valign='top'>Empleado</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Centro Logistico</th>")
        strTablaEspaciosHTML.Append("<th width='20%' align=center class='rayita' align='left' valign='top'>Sucursal</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Movimiento</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Descripcion</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Observación</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Fecha</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Confirmado</th>")
        strTablaEspaciosHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For Each strConsultaDetalle In objConsultaDetalle
            intContador = intContador + 1

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strConfirmado = "No"

            If (CBool(strConsultaDetalle(10)) = True) Then
                strConfirmado = "Si"
            End If
            strTablaEspaciosHTML.Append("<tr>")

            'No. Empleado
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaDetalle(1) & "</td>")
            'Empleado
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaDetalle(2)) & "</td>")
            'Centro Logistico
            strTablaEspaciosHTML.Append("<td id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & strConsultaDetalle(3) & "</td>")
            'Sucursal          
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaDetalle(6)) & "</td>")
            'Movimiento
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaDetalle(7)) & "</td>")
            'Descripcion
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaDetalle(8)) & "</td>")
            'Observación
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaDetalle(12)) & "</td>")
            'Fecha
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaDetalle(9)) & "</td>")
            'Confirmado
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & strConfirmado & "</td>")
            strTablaEspaciosHTML.Append("</tr>")

        Next
        strTablaEspaciosHTML.Append("</tr>")
        strTablaEspaciosHTML.Append("</table>")
        strTablaConsultaVerDetalleExportar = strTablaEspaciosHTML.ToString
    End Function
#End Region

End Class