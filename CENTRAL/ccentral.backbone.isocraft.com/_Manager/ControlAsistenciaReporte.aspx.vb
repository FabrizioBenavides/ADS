Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Benavides.POSAdmin.Commons.clsCommons.clsMSMQ
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports Isocraft.Web.Javascript
Imports System.IO
Imports System.Web.Caching

Public Class ControlAsistenciaReporte
    Inherits System.Web.UI.Page

    Private intEmpleadoId As Integer

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        intEmpleadoId = GetPageParameter("cboCoordinadoresRH", 0)
    End Sub

#End Region

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", String.Empty, Request, Server)
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
    ' Name       : strTipoUsuarioId
    ' Description: Tipo de usuario actual
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTipoUsuarioId() As Integer
        Get
            Return Benavides.CC.Data.clsControlDeAsistencia.intObtenerTipoUsuarioId(strUsuarioNombre, strConnectionString)
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
    ' Name       : LlenarControlCoordinadoresRH
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboCoordinadoresRH
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlCoordinadoresRH() As String


        'Dim returnedData As Array = Nothing
        'Dim objResultados As Array = Nothing

        'returnedData = Benavides.CC.Data.clsControlDeAsistencia.strBuscarCoordinadoresRH(strConnectionString)

        'If IsArray(returnedData) AndAlso returnedData.Length > 0 Then

        '    objResultados = DirectCast(returnedData, Object())

        'End If

        Return CreateJavascriptComboBoxOptions("cboCoordinadoresRH", CStr(intEmpleadoId), Benavides.CC.Data.clsControlDeAsistencia.strBuscarCoordinadoresRH(strConnectionString), "intEmpleadoId", "strCoordinadorNombre", 2)

    End Function

    '====================================================================
    ' Name       : strFirstDayOfMonth
    ' Description: Regresa el primer dia del mes actual
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFirstDayOfMonth() As String
        Get
            If IsNothing(Request.Form("dtmFechaIni")) Then
                Return New Date(Date.Today.Year, Date.Today.Month, 1).ToString("dd/MM/yyyy")
            Else
                Return Request.Form("dtmFechaIni")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intCoordinadorRHId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intCoordinadorRHId() As Integer
        Get
            If Not IsNothing(Request.Form("cboCoordinadoresRH")) Then
                Return CInt(Request.Form("cboCoordinadoresRH"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intEstatusId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intEstatusId() As Integer
        Get
            If Not IsNothing(Request.Form("cboEstatus")) Then
                Return CInt(Request.Form("cboEstatus"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intTipoNominaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTipoNominaId() As Integer
        Get
            If Not IsNothing(Request.Form("cboTipoNomina")) Then
                Return CInt(Request.Form("cboTipoNomina"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaInicio
    ' Description: Fecha de inicio a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaInicio() As Date
        Get
            Dim f As String = Request.Form("dtmFechaIni")
            If Not IsNothing(f) Then
                Dim fp As String() = f.Split("/".ToCharArray())

                Return New Date(CInt(fp(2)), CInt(fp(1)), CInt(fp(0)))
            Else
                Return CDate("01/01/1900")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaFin
    ' Description: Fecha de fin  a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaFin() As Date
        Get
            Dim f As String = Request.Form("dtmFechaFin")
            If Not IsNothing(f) Then
                Dim fp As String() = f.Split("/".ToCharArray())

                Return New Date(CInt(fp(2)), CInt(fp(1)), CInt(fp(0)))
            Else
                Return CDate("01/01/1900")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strFechaActual
    ' Description: Regresa la fecha actual
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFechaActual() As String
        Get

            Dim dtmFechaActual As Date

            dtmFechaActual = New Date(Date.Today.Year, Date.Today.Month, Date.Today.Day)

            Return dtmFechaActual.ToString("dd/MM/yyyy")
        End Get
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return GetPageParameter("strCmd", String.Empty)
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Const strComitasDobles As String = """"

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        'If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Or _
        '    Not intTipoUsuarioId = 1 Or CInt(strUsuarioNombre) = 40014547 Then
        '    Call Response.Redirect("../Default.aspx")
        'End If

        


        If (strCmd = "cmdImprimir") Then

            Dim strHTML As New StringBuilder
            Dim objDataArrayReporte As Array = Nothing
            Dim strRecordBrowserImpresion As String = String.Empty

            'Resultados a mostrar en pantalla
            objDataArrayReporte = Benavides.CC.Data.clsControlDeAsistencia.strObtenerReporteControlAsistencia(intCoordinadorRHId, intEstatusId, intTipoNominaId, dtmFechaInicio, dtmFechaFin, strConnectionString)

            If IsArray(objDataArrayReporte) AndAlso objDataArrayReporte.Length > 0 Then

                'Se envia la informacion a imprimir para darle formato de acuerdo a la tabla seleccionada por el usuario.  
                strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strImpresionReporte(objDataArrayReporte))

                'Se ennvia a impresion.
                strHTML.Append("<script language='Javascript'>parent.fnImprimir( " & _
                strComitasDobles & strRecordBrowserImpresion.ToString & strComitasDobles & _
                "); </script>")
                Response.Write(strHTML.ToString)
                Response.End()

            End If
        End If

        If (strCmd = "cmdExportar") Then

            Dim objArray As System.Array = Nothing
            objArray = Benavides.CC.Data.clsControlDeAsistencia.strObtenerReporteControlAsistencia(intCoordinadorRHId, intEstatusId, intTipoNominaId, dtmFechaInicio, dtmFechaFin, strConnectionString)

            ' Establecemos en la respuesta los parámetros de configuración del archivo
            Response.ContentType = "application/vnd.ms-excel"
            Call Response.AddHeader("Content-Disposition", "attachment; filename=""Reporte de Coordinadores RH.xls""")
            Call Response.Write(strTablaConsultaReporteExportar(objArray))
            Call Response.End()
        End If
    End Sub

    Public Function strTablaConsultaReporte() As String

        Dim objArray As System.Array = Nothing
        Dim resultadoConsulta As String = String.Empty
        Dim strmRecordBrowserHTML As String = String.Empty

        If (strCmd = "cmdConsultar") Then

            If (Request.QueryString("pager") = "true") Then
                If Not Cache("cacheReporte") Is Nothing Then
                    objArray = CType(Cache("cacheReporte"), System.Array)
                End If
            End If


            'Reporte de Movimientos por Coordinador RH

            If objArray Is Nothing Then
                Cache.Remove("cacheReporte")
                objArray = Benavides.CC.Data.clsControlDeAsistencia.strObtenerReporteControlAsistencia(intCoordinadorRHId, intEstatusId, intTipoNominaId, dtmFechaInicio, dtmFechaFin, strConnectionString)
            End If

            Dim strResult As New StringBuilder()
            If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then

                Cache.Add("cacheReporte", objArray, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, Nothing)

                'Detalle
                strResult.Append(strTablaConsultaReporteHTML(objArray))

            Else
                'Tabla vacia sin resultados de consulta
                Call Response.Write("<script language='Javascript'>alert('Busqueda sin resultados');</script>")
            End If

            strResult.Append("<script language=""javascript"" type=""text/javascript"">")
            strResult.Append("parent.document.getElementById('tblReporte').innerHTML = document.getElementById('divConsultaReporte').innerHTML;")
            strResult.Append("</script>")

            Return strResult.ToString()
        End If

        Return String.Empty
    End Function

    Public Function strTablaConsultaReporteHTML(ByVal objConsultaReporte As Array) As String
        Dim strTablaReporteHTML As StringBuilder
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim intPage As Integer
        Dim intTotal As Integer = 50
        Dim strConsultaReporte As String() = Nothing

        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If

        strTablaReporteHTML = New StringBuilder
        strTablaReporteHTML.Append(Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objConsultaReporte.Length, intPage, intTotal, String.Empty, Nothing))

        strTablaReporteHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        strTablaReporteHTML.Append("<tr class='trtitulos'>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Coordinador RH</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Centro Logistico</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Sucursal</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Movimiento</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Descripción</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Movimientos</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Ajustes</th>")

        'strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Sin Confirmar</th>")

        strTablaReporteHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaReporte.Length) Then
                Exit For
            End If

            strConsultaReporte = CType(objConsultaReporte.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strTablaReporteHTML.Append("<tr>")
            ' Coordinador RH
            strTablaReporteHTML.Append("<td align=center class=" & "tdceleste" & ">" & clsCommons.strFormatearDescripcion(strConsultaReporte(1)) & "</td>")
            ' Centro Logistico 1
            strTablaReporteHTML.Append("<td id=Division" & intContador & " align=center class=" & "tdceleste" & ">" & strConsultaReporte(2) & "</td>")
            ' Sucursal
            strTablaReporteHTML.Append("<td align=left class=" & "tdceleste" & ">" & clsCommons.strFormatearDescripcion(strConsultaReporte(3)) & "</td>")
            ' Movimiento
            strTablaReporteHTML.Append("<td align=center class=" & "tdceleste" & ">" & strConsultaReporte(4).ToString() & "</td>")
            ' Descripcion
            strTablaReporteHTML.Append("<td align=center class=" & "tdceleste" & ">" & clsCommons.strFormatearDescripcion(strConsultaReporte(5)) & "</td>")
            ' Movimientos Originales
            strTablaReporteHTML.Append("<td align=center class=" & "tdceleste" & ">" & strConsultaReporte(6).ToString() & "</td>")
            ' Ajustes
            strTablaReporteHTML.Append("<td align=center class=" & "tdceleste" & ">" & strConsultaReporte(7).ToString() & "</td>")

            ' Sin Confirmar
            'strTablaReporteHTML.Append("<td align=center class=" & "tdceleste" & ">" & intContador.ToString() & "</td>")
            strTablaReporteHTML.Append("</tr>")

        Next

        strTablaReporteHTML.Append("</tr>")
        strTablaReporteHTML.Append("</table>")
        strTablaReporteHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaReporteHTML = strTablaReporteHTML.ToString


    End Function

#Region "Imprimir"

    '====================================================================
    ' Name       : strImpresionReporte
    ' Description: Generacion de tabla HTML con formato para imprimir resultados de la consulta.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImpresionReporte(ByVal objDataArrayReporte As Array) As String

        'Variables
        Dim strImpresionReporteHTML As StringBuilder = New StringBuilder
        Dim strRegistrosReporte As String()
        Dim strclase As String = String.Empty
        Dim intRenglonesxPagina As Integer = 58

        'Rutina que solo se ejecuta al contener informacion de la consulta.
        If IsArray(objDataArrayReporte) AndAlso (objDataArrayReporte.Length > 0) Then

            Dim intTotalRenglones As Integer = objDataArrayReporte.Length
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
            For Each strRegistrosReporte In objDataArrayReporte

                intRenglon += 1
                intContadorRenglon += 1

                If intRenglon = 1 Then
                    intPagina += 1

                    'Salto de hoja
                    If intPagina > 1 Then
                        strImpresionReporteHTML.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")
                    End If

                    strImpresionReporteHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    'Metodo que genera y da formato al encabezado.
                    strImpresionReporteHTML.Append(strImprimeEncabezado(intPagina.ToString, intTotalPaginas.ToString))
                End If

                'Clases para renglones.
                If ((intRenglon Mod 2) = 0) Then
                    strclase = "tdtxtImpresionNormal"
                Else
                    strclase = "tdtxtImpresionBold"
                End If

                strImpresionReporteHTML.Append("<tr>")
                ' Nombre Coordinador
                strImpresionReporteHTML.Append("<td width='15%' align='left' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistrosReporte(1)).ToString & "</td>")
                ' Centro Logistico
                strImpresionReporteHTML.Append("<td width='12%' align='left' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistrosReporte(2)) & "</td>")
                ' Sucursal
                strImpresionReporteHTML.Append("<td width='13%' align='left' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistrosReporte(3)) & "</td>")
                ' Movimiento
                strImpresionReporteHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & strRegistrosReporte(4).ToString() & "</td>")
                'Descripcion
                strImpresionReporteHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistrosReporte(5)) & "</td>")
                'Movimientos Originales
                strImpresionReporteHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & strRegistrosReporte(6).ToString() & "</td>")
                'Cantidad de Ajustes
                strImpresionReporteHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & strRegistrosReporte(7).ToString() & "</td>")
                strImpresionReporteHTML.Append("</tr>")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionReporteHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next

        End If

        Return strImpresionReporteHTML.ToString()

    End Function

    Private Function strImprimeEncabezado(ByVal strHojaActual As String, ByVal strHojaFinal As String) As String

        Dim strHtmlEncabezado As StringBuilder
        strHtmlEncabezado = New StringBuilder

        'Encabezado principal
        strHtmlEncabezado.Append("<tr>")
        strHtmlEncabezado.Append("<td colspan='7'>")
        strHtmlEncabezado.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='7' class='tdtxtBold'>Control de Asistencia - Reporte</th>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='10%' align='left'   class='tdtxtBold'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th width='50%' align='center' class='tdtxtBold' nowrap> ADS Central </th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='20%' align='left'  class='tdtxtBold'>HOJA " & strHojaActual & " / " & strHojaFinal & " </th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strHtmlEncabezado.Append("</td>")
        strHtmlEncabezado.Append("</tr>")

        'Encabezado titulos
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='30%' class='tdtxtBold' align='center' nowrap>Coordinador RH</th>")
        strHtmlEncabezado.Append("<th width='15%' class='tdtxtBold' align='center' nowrap>Centro Logistico</th>")
        strHtmlEncabezado.Append("<th width='12%' class='tdtxtBold' align='center' nowrap>Sucursal</th>")
        strHtmlEncabezado.Append("<th width='20%' class='tdtxtBold' align='center' nowrap>Movimiento</th>")
        strHtmlEncabezado.Append("<th width='30%' class='tdtxtBold' align='center' nowrap>Descripción</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Movimientos Originales</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Cantidad de Ajustes</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' class='rayita' colspan='7'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        strImprimeEncabezado = strHtmlEncabezado.ToString

    End Function

#End Region

#Region "Exportar"

    Public Function strTablaConsultaReporteExportar(ByVal objReporteExportar As Array) As String
        Dim strTablaExportarReporteHTML As StringBuilder
        Dim strConsultaReporteExportar As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer

        strTablaExportarReporteHTML = New StringBuilder
        strTablaExportarReporteHTML.Append("<span class='txsubtitulo'> </span> ")
        strTablaExportarReporteHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strTablaExportarReporteHTML.Append("<tr class='trtitulos'>")
        strTablaExportarReporteHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Coordinador RH</th>")
        strTablaExportarReporteHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Centro Logistico</th>")
        strTablaExportarReporteHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Sucursal</th>")
        strTablaExportarReporteHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Movimiento</th>")
        strTablaExportarReporteHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Descripción</th>")
        strTablaExportarReporteHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Movimientos Originales</th>")
        strTablaExportarReporteHTML.Append("<th width='8%' align=center class='rayita' align='left' valign='top'>Cantidad de Ajustes</th>")
        strTablaExportarReporteHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For Each strConsultaReporteExportar In objReporteExportar
            intContador = intContador + 1

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strTablaExportarReporteHTML.Append("<tr>")

            'CoordinadorRH
            strTablaExportarReporteHTML.Append("<td id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaReporteExportar(1)) & "</td>")
            'Centro Logistico
            strTablaExportarReporteHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaReporteExportar(2)) & "</td>")
            'Sucursal
            strTablaExportarReporteHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaReporteExportar(3)) & "</td>")
            'Movimiento
            strTablaExportarReporteHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaReporteExportar(4).ToString() & "</td>")
            'Descripcion
            strTablaExportarReporteHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaReporteExportar(5)) & "</td>")
            'Movimientos Originalesload
            strTablaExportarReporteHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaReporteExportar(6).ToString() & "</td>")
            'Cantidad de Ajustes
            strTablaExportarReporteHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaReporteExportar(7).ToString() & "</td>")
            strTablaExportarReporteHTML.Append("</tr>")

        Next
        strTablaExportarReporteHTML.Append("</tr>")
        strTablaExportarReporteHTML.Append("</table>")
        strTablaConsultaReporteExportar = strTablaExportarReporteHTML.ToString
    End Function
#End Region
End Class