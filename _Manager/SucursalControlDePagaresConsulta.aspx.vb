
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

Public Class SucursalControlDePagaresConsulta
    Inherits System.Web.UI.Page

    Private intDireccionOperativaId As Integer
    Private intZonaOperativaId As Integer
    Private intAutorizacionId As Integer
    Private intEstatusId As Integer
    Private intmTipoUsuarioId As Integer
    Dim strmTotalDePartidas As Integer
    Dim astrRecords As Array
    Dim strMovimientos As String = String.Empty
    Private intRenglonesxPagina As Integer = 42

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

        intDireccionOperativaId = GetPageParameter("cboDireccionOperativa", 0)
        intZonaOperativaId = GetPageParameter("cboZonaOperativa", 0)
        intAutorizacionId = GetPageParameter("txtAutorizacion", 0)
        intEstatusId = GetPageParameter("cboEstatusPagare", 0)

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

#Region "Combos"
    '====================================================================
    ' Name       : LlenarControlDireccion
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboDireccionOperativa
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlDireccion() As String

        'Consultamos las direcciones operativas
        astrRecords = Nothing

        astrRecords = Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString)

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccionOperativa", intDireccionOperativaId, astrRecords, 0, 1, 1)

    End Function

    '====================================================================
    ' Name       : LlenarControlZona
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboZona
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlZona() As String

        ' Validamos si hay una Direccion Operativa seleccionada
        If intDireccionOperativaId > 0 Then

            ' Inicializamos el arreglo
            astrRecords = Nothing

            'Consultamos las direcciones operativas
            astrRecords = Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionOperativaId, 0, strConnectionString)

            ' Formamos el string con los valores
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZonaOperativa", intZonaOperativaId, astrRecords, 0, 1, 1)
        End If
    End Function

    '====================================================================
    ' Name       : LlenarControlSucursales
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboSucursales
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlSucursales() As String

        If intDireccionId > 0 AndAlso intZonaId > 0 Then

            Dim strSucursales As New StringBuilder
            Dim arraySucursales As Array
            Dim objSucursalItem As String() = Nothing

            arraySucursales = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarSucursalesPorAsignar(intDireccionId, intZonaId, strConnectionString)

            If Not arraySucursales Is Nothing AndAlso IsArray(arraySucursales) AndAlso arraySucursales.Length > 0 Then

                Dim i As Integer
                For i = 0 To arraySucursales.Length - 1

                    objSucursalItem = CType(arraySucursales.GetValue(i), String())

                    strSucursales.AppendFormat("<option value=""{0}"">{1}</option>", objSucursalItem(0).ToString().Trim() & "|" & objSucursalItem(1).ToString().Trim(), objSucursalItem(2).ToString().Trim() & " - " & objSucursalItem(3).ToString().Trim())
                Next
            End If

            Return strSucursales.ToString

        End If

        Return String.Empty
    End Function

#End Region

    '====================================================================
    ' Name       : intSolicitudPagareId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intSolicitudPagareId() As Integer
        Get
            If Not (Request.QueryString("intSolicitudPagareId") = Nothing) Then
                Return CInt(Request.QueryString("intSolicitudPagareId"))
                'ElseIf Not (intmSolicitudPagareId = 0) Then
            Else
                'Return intmSolicitudPagareId
                Return 0
                'Else
                '    Return -1
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intDireccionId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intDireccionId() As Integer
        Get
            Return intDireccionOperativaId
        End Get
    End Property

    '====================================================================
    ' Name       : intZonaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intZonaId() As Integer
        Get
            Return intZonaOperativaId
        End Get
    End Property

    '====================================================================
    ' Name       : strSucursalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalId() As String
        Get
            Return Request.Form("cboSucursales")
        End Get
    End Property

    '====================================================================
    ' Name       : intCompaniaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intCompaniaId() As Integer
        Get
            If Not IsNothing(strSucursalId) AndAlso strSucursalId <> "0" AndAlso strSucursalId <> "-1" AndAlso strSucursalId <> String.Empty Then

                Dim strSucursalSplitId As String() = strSucursalId.Split("|".ToCharArray())

                If strSucursalSplitId(0) <> String.Empty AndAlso IsNumeric(strSucursalSplitId(0)) Then
                    Return CInt(strSucursalSplitId(0))
                End If

                Return -1
            Else
                Return -1
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intSucursalId() As Integer
        Get
            If Not IsNothing(strSucursalId) AndAlso strSucursalId <> "0" AndAlso strSucursalId <> "-1" AndAlso strSucursalId <> String.Empty Then

                Dim strSucursalSplitId As String() = strSucursalId.Split("|".ToCharArray())

                If strSucursalSplitId(1) <> String.Empty AndAlso IsNumeric(strSucursalSplitId(1)) Then
                    Return CInt(strSucursalSplitId(1))
                End If

                Return -1
            Else
                Return -1
            End If
        End Get
    End Property

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
    ' Name       : strFechaActual
    ' Description: Regresa la fecha actual
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFechaActual() As String
        Get
            If IsNothing(Request.Form("dtmFechaFin")) Then
                Dim dtmFechaActual As Date

                dtmFechaActual = New Date(Date.Today.Year, Date.Today.Month, Date.Today.Day)

                Return dtmFechaActual.ToString("dd/MM/yyyy")
            Else
                Return Request.Form("dtmFechaFin")
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

    '====================================================================
    ' Name       : strTotalDePartidas
    ' Description: Numero de sucursales por "Asignar".
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strTotalDePartidas() As Integer
        Get
            Return strmTotalDePartidas
        End Get
        Set(ByVal strValue As Integer)
            strmTotalDePartidas = strValue
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        If (strCmd = "cmdEliminar") Then

            'Rutina ELIMINAR
            fnEliminarSolicitudPagare()

        ElseIf (strCmd = "cmdImprimir") Then

            'RUTINA EDITAR
            fnImprimirConsulta()

        ElseIf (strCmd = "cmdExportar") Then

            fnExportar()
        End If
        
    End Sub

    Private Sub fnEliminarSolicitudPagare()

        Dim intResultadoEliminar As Integer

        intResultadoEliminar = Benavides.CC.Data.clsControlPagares.intEliminarSolicitudPagare(intSolicitudPagareId, strConnectionString)

        If intResultadoEliminar > 0 Then
            'intmSolicitudPagareId = intResultadoEliminar
        End If
    End Sub

    Public Function strTablaConsultaSolicitudPagare() As String

        Dim objArray As System.Array = Nothing
        Dim resultadoConsulta As String = String.Empty
        Dim strmRecordBrowserHTML As String = String.Empty

        strmTotalDePartidas = 0

        If (strCmd = "cmdConsultar") Or (strCmd = "cmdEliminar") Then


            If (Request.QueryString("pager") = "true") Then
                If Not Cache("cacheSolicitud") Is Nothing Then
                    objArray = CType(Cache("cacheSolicitud"), System.Array)
                End If
            End If

            If objArray Is Nothing Then

                Cache.Remove("cacheSolicitud")


                'Solicitudes
                objArray = Benavides.CC.Data.clsControlPagares.strConsultaSolicitudesPagare(intDireccionOperativaId, intZonaOperativaId, intCompaniaId, intSucursalId, intAutorizacionId, intEstatusId, dtmFechaInicio, dtmFechaFin, strConnectionString)

            End If

            Dim strResult As New StringBuilder()
            If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then

                'Cantidad de registros
                strmTotalDePartidas = objArray.Length

                Cache.Add("cacheSolicitud", objArray, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, Nothing)

                'Detalle
                strResult.Append(strTablaConsultaSolicitudHTML(objArray))

            Else
                'Tabla vacia sin resultados de consulta
                Call Response.Write("<script language='Javascript'>alert('Busqueda sin resultados');</script>")
            End If

            strResult.Append("<script language=""javascript"" type=""text/javascript"">")
            strResult.Append("parent.document.getElementById('tblResultados').innerHTML = document.getElementById('divConsultaSolicitudesPagare').innerHTML;")
            strResult.Append("</script>")

            Return strResult.ToString()
        End If

        Return String.Empty
    End Function

    Public Function strTablaConsultaSolicitudHTML(ByVal objConsultaDetalle As Array) As String

        Dim strTablaDetalleHTML As StringBuilder
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim strConfirmado As String
        Dim strConsultaRegistroDetalle As String()
        Dim imgEliminar As String = Nothing
        Dim imgEditar As String = String.Empty


        strTablaDetalleHTML = New StringBuilder

        strTablaDetalleHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Encabezados de Tabla de Resultados
        strTablaDetalleHTML.Append("<tr class='trtitulos'>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Sucursal</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Afiliación</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Autorización</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Importe</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Fecha Pagare</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Fecha Solicitud</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Fecha <br> Confirmación <br> Envio</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Acción</th>")

        strTablaDetalleHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For Each strConsultaRegistroDetalle In objConsultaDetalle
            intContador += 1


            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If


            imgEliminar = "<img id=" & strConsultaRegistroDetalle(0) & " height='17' src='../static/images/icono_borrar.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdEliminar_onclick(this.id," & strConsultaRegistroDetalle(3) & ")' alt='Eliminar'>"
            imgEditar = "<img id=" & strConsultaRegistroDetalle(0) & " height='17' src='../static/images/imgNREditar.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdEditar_onclick(this.id," & strConsultaRegistroDetalle(3) & ")' alt='Editar'>"


            'CheckBox 
            If (CStr(strConsultaRegistroDetalle(7)) = String.Empty) Then

                'Registro Sin confirmar
                strConfirmado = "&nbsp;"
            Else
                strConfirmado = clsCommons.strFormatearFechaPresentacion(strConsultaRegistroDetalle(7))
            End If

            strTablaDetalleHTML.Append("<tr>")
            ' Sucursal
            strTablaDetalleHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaRegistroDetalle(1) & "</td>")
            ' Afiliación
            strTablaDetalleHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroDetalle(2)) & "</td>")
            ' Autorización
            strTablaDetalleHTML.Append("<td id=Division" & intContador & " align=center class=" & strColorRegistro & ">" & strConsultaRegistroDetalle(3) & "</td>")
            ' Importe
            strTablaDetalleHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroDetalle(4)) & "</td>")
            ' Fecha Pagare
            strTablaDetalleHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaRegistroDetalle(5)) & "</td>")
            ' Fecha Solicitud
            strTablaDetalleHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaRegistroDetalle(8)) & "</td>")
            ' Fecha Confirmación Envio
            strTablaDetalleHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConfirmado & "</td>")
            ' Acción
            strTablaDetalleHTML.Append("<td align=center class=" & strColorRegistro & ">" & imgEliminar & " " & imgEditar & "</td>")
            strTablaDetalleHTML.Append("</tr>")
        Next

        strTablaDetalleHTML.Append("</tr>")
        strTablaDetalleHTML.Append("</table>")
        strTablaConsultaSolicitudHTML = strTablaDetalleHTML.ToString

    End Function

#Region "Imprimir"

    Private Sub fnImprimirConsulta()

        Const strComitasDobles As String = """"
        Dim strHTML As New StringBuilder
        Dim objArray As System.Array = Nothing
        Dim strmRecordBrowserHTML As String = String.Empty
        Dim strRecordBrowserImpresion As String = String.Empty

        'Consulta
        objArray = Benavides.CC.Data.clsControlPagares.strConsultaSolicitudesPagare(intDireccionOperativaId, intZonaOperativaId, intCompaniaId, intSucursalId, intAutorizacionId, intEstatusId, dtmFechaInicio, dtmFechaFin, strConnectionString)

        Dim strResult As New StringBuilder()
        If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then

            'Impresion
            strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strGeneraImpresionReporte(objArray))

            'Se ennvia a impresion.
            strHTML.Append("<script language='Javascript'>parent.fnImprimir( " & _
            strComitasDobles & strRecordBrowserImpresion.ToString & strComitasDobles & _
            "); </script>")
            Response.Write(strHTML.ToString)
            Response.End()

        End If
    End Sub

    '====================================================================
    ' Name       : strGeneraImpresionReporte
    ' Description: Genera el Record Browser a desplegar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strGeneraImpresionReporte(ByVal objReporte As Array) As String

        Dim strImpresionHTML As New StringBuilder

        If IsArray(objReporte) AndAlso (objReporte.Length > 0) Then

            Dim objRegistro As String() = Nothing
            Dim intContadorRegistro As Integer = 0

            Dim intTotalRenglones As Integer = objReporte.Length
            Dim intRenglon As Integer = 0

            Dim intTotalPaginas As Integer = 0
            Dim intPagina As Integer = 0

            intTotalPaginas = intTotalRenglones \ intRenglonesxPagina

            If intTotalRenglones Mod intRenglonesxPagina > 0 Then
                intTotalPaginas += 1
            Else
                intTotalPaginas = 1
            End If

            intRenglon = 0
            intPagina = 0
            intContadorRegistro = 0

            For Each objRegistro In objReporte

                intRenglon += 1
                intContadorRegistro += 1

                If intRenglon = 1 Then
                    intPagina += 1
                    strImpresionHTML.Append(strImprimeEncabezado(intPagina, intTotalPaginas))
                    strImpresionHTML.Append("<table width='770px' border='0' cellpadding='0' cellspacing='0'> ")
                End If

                strImpresionHTML.Append(strImprimeDetalle(intContadorRegistro, objRegistro))

                If intContadorRegistro = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next

        Else

            strImpresionHTML.Append(strImprimeEncabezado(1, 1))
            strImpresionHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")
            strImpresionHTML.Append("<tr>")
            strImpresionHTML.Append("<td width='02%'>&nbsp;</td>")
            strImpresionHTML.Append("<td class='tdblanco' colspan='7'>No hay registros</td>")
            strImpresionHTML.Append("</tr>")
            strImpresionHTML.Append("</table>")
        End If

        Return strImpresionHTML.ToString

    End Function

    Private Function strImprimeEncabezado(ByVal intPaginaActual As Integer, _
                                          ByVal intTotalPaginas As Integer) As String

        Dim strHtmlEncabezado As New StringBuilder

        If intPaginaActual > 1 Then
            strHtmlEncabezado.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")
        End If

        strHtmlEncabezado.Append("<table width='770px' border='0' cellpadding='0' cellspacing='0'> ")

        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td width='100%'  colspan='10'>&nbsp;</td>")
        strHtmlEncabezado.Append("</tr>")

        'Logo
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        'strHtmlEncabezado.Append("<td width='49%' align='left'  colspan='4'><img src='../static/images/" & strCadenaImagen & "/logo.gif' width='125' height='25' border='0'></td>")
        strHtmlEncabezado.Append("<td width='49%' align='left'  colspan='4'><img src='../static/images/" & "/logo.gif' width='125' height='25' border='0'></td>")
        strHtmlEncabezado.Append("<td width='49%' align='right' colspan='4'>Control de Pagares</td>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='49%' align='left'  colspan='4' class='tdtxtImpresionBold'>" & clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</td>")
        strHtmlEncabezado.Append("<td width='49%' align='right' colspan='4' class='tdtxtImpresionBold'>HOJA " & intPaginaActual.ToString & " / " & intTotalPaginas & "</td>")
        strHtmlEncabezado.Append("</tr>")

        'Consulta      
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='98%' colspan='8'>&nbsp;</td>")
        strHtmlEncabezado.Append("</tr>")

        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td align='left' colspan='9'>Consulta generada por: " & strUsuarioNombre & "</td>")
        strHtmlEncabezado.Append("</tr>")

        'Titulos Pagares
        strHtmlEncabezado.Append("<table width='770px' border='0' cellpadding='0' cellspacing='0'> ")
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th width='02%'>&nbsp;</th>")
        strHtmlEncabezado.Append("<th width='28%' align='center' class='tdtxtImpresionBoldRayita'>Sucursal</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtImpresionBoldRayita'>Afiliación</th>")
        strHtmlEncabezado.Append("<th width='10%' align='left'  class='tdtxtImpresionBoldRayita'>Autorización</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtImpresionBoldRayita'>Importe</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtImpresionBoldRayita'>Fecha de Pagare</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtImpresionBoldRayita'>Fecha <br>  Solicitud</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtImpresionBoldRayita'>Fecha <br> Confirmación Envio</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtImpresionBoldRayita'>Confirmación</th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strImprimeEncabezado = strHtmlEncabezado.ToString

    End Function

    Private Function strImprimeDetalle(ByVal intContadorRegistro As Integer, ByVal objReporte As String()) As String

        Dim strColorRegistro As String = String.Empty
        Dim strHtmlDetalle As New StringBuilder
        Dim strFechaConfirmacion As String
        Dim strConfitrmacion As String

        If ((intContadorRegistro Mod 2) = 0) Then
            strColorRegistro = "'tdtxtImpresionBold'"
        Else
            strColorRegistro = "'tdtxtImpresionNormal'"
        End If

        If (CBool(objReporte(6)) = False) Then

            'Registro Sin confirmar
            strFechaConfirmacion = "&nbsp;"
            strConfitrmacion = "No"

        ElseIf (CBool(objReporte(6)) = True) Then

            'Registro Confirmado
            strFechaConfirmacion = clsCommons.strFormatearFechaPresentacion(objReporte(7))
            strConfitrmacion = "Si"

        End If

        strHtmlDetalle.Append("<tr>")

        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='02%' align='left'>" & intContadorRegistro.ToString & "&nbsp;</td>")
        'Sucursal
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='28%' align='left'>" & clsCommons.strFormatearDescripcion(objReporte(1).ToString) & "&nbsp;</td>")
        ' Afiliación
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='center'>" & clsCommons.strFormatearDescripcion(objReporte(2).ToString) & "</td>")
        ' Autorización
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='center'>" & clsCommons.strFormatearDescripcion(objReporte(3)) & "</td>")
        'Importe  
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='left'>" & clsCommons.strFormatearDescripcion(objReporte(4).ToString) & "</td>")
        'Fecha de Pagare
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='center'>" & clsCommons.strFormatearFechaPresentacion(objReporte(5)) & "</td>")
        'Fecha <br>  Solicitud
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='left'>" & clsCommons.strFormatearFechaPresentacion(objReporte(8)) & "</td>")
        'Fecha <br> Confirmación <br> Envio
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='center'>" & strFechaConfirmacion & "</td>")
        ' Confirmación 
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='center'>" & strConfitrmacion & "</td>")

        strHtmlDetalle.Append("</tr>")

        Return strHtmlDetalle.ToString

    End Function

#End Region

#Region "Exportar"


    Private Sub fnExportar()

        Dim objArrayExportar As System.Array = Nothing
        objArrayExportar = Benavides.CC.Data.clsControlPagares.strConsultaSolicitudesPagare(intDireccionOperativaId, intZonaOperativaId, intCompaniaId, intSucursalId, intAutorizacionId, intEstatusId, dtmFechaInicio, dtmFechaFin, strConnectionString)

        'FORMATO A TABLA CON RESULTADOS
        If Not objArrayExportar Is Nothing AndAlso IsArray(objArrayExportar) AndAlso objArrayExportar.Length > 0 Then

            ' Establecemos en la respuesta los parámetros de configuración del archivo
            Response.ContentType = "application/vnd.ms-excel"
            Call Response.AddHeader("Content-Disposition", "attachment; filename=""Control de Pagares.xls""")
            Call Response.Write(strTablaPagaresExportar(objArrayExportar))
            Call Response.End()

        End If

    End Sub

    Public Function strTablaPagaresExportar(ByVal objConsultaExportar As Array) As String

        Dim strTablaSolicitudPagaresHTML As StringBuilder
        Dim strRegistroSolicitudExportar As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim strConfirmado As String
        Dim imgDetalle As String = Nothing
        Dim strFechaConfirmacion As String

        strTablaSolicitudPagaresHTML = New StringBuilder
        strTablaSolicitudPagaresHTML.Append("<span class='txsubtitulo'></span> ")
        strTablaSolicitudPagaresHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        strTablaSolicitudPagaresHTML.Append("<tr class='trtitulos'>")
        strTablaSolicitudPagaresHTML.Append("<th width='30%' class='rayita' align='center' valign='top'>Sucursal</th>")
        strTablaSolicitudPagaresHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Afiliación</th>")
        strTablaSolicitudPagaresHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Autorización</th>")
        strTablaSolicitudPagaresHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Importe</th>")
        strTablaSolicitudPagaresHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Fecha de Pagare</th>")
        strTablaSolicitudPagaresHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Fecha <br>  Solicitud</th>")
        strTablaSolicitudPagaresHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Fecha <br> Confirmación <br> Envio</th>")
        strTablaSolicitudPagaresHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Confirmación</th>")

        strTablaSolicitudPagaresHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For Each strRegistroSolicitudExportar In objConsultaExportar
            intContador = intContador + 1

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strConfirmado = "No"
            strFechaConfirmacion = "&nbsp;"

            If (CBool(strRegistroSolicitudExportar(6)) = True) Then
                strConfirmado = "Si"
                strFechaConfirmacion = clsCommons.strFormatearFechaPresentacion(strRegistroSolicitudExportar(7))
            End If

            strTablaSolicitudPagaresHTML.Append("<tr>")

            'Sucursal                
            strTablaSolicitudPagaresHTML.Append("<td align='left' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroSolicitudExportar(1)) & "</td>")
            'Afiliación
            strTablaSolicitudPagaresHTML.Append("<td align='left' id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroSolicitudExportar(2)) & "</td>")
            'Autorización
            strTablaSolicitudPagaresHTML.Append("<td align='center' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroSolicitudExportar(3)) & "</td>")
            'Importe                
            strTablaSolicitudPagaresHTML.Append("<td align='center' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroSolicitudExportar(4)) & "</td>")
            'Fecha de Pagare
            strTablaSolicitudPagaresHTML.Append("<td align='center' class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strRegistroSolicitudExportar(5)) & "</td>")
            'Fecha <br>  Solicitud
            strTablaSolicitudPagaresHTML.Append("<td align='center' class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strRegistroSolicitudExportar(8)) & "</td>")
            'Fecha <br> Confirmación <br> Envio
            strTablaSolicitudPagaresHTML.Append("<td align='center' class=" & strColorRegistro & ">" & strFechaConfirmacion & "</td>")
            'Confirmación 
            strTablaSolicitudPagaresHTML.Append("<td align='center' class=" & strColorRegistro & ">" & strConfirmado & "</td>")
            strTablaSolicitudPagaresHTML.Append("</tr>")

        Next
        strTablaSolicitudPagaresHTML.Append("</tr>")
        strTablaSolicitudPagaresHTML.Append("</table>")
        strTablaPagaresExportar = strTablaSolicitudPagaresHTML.ToString
    End Function
    
#End Region
End Class