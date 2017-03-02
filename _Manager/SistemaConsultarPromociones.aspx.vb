
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

Public Class SucursalConsultarPromociones
    Inherits System.Web.UI.Page


    Private intmCategoriaPromocionId As Integer
    Private astrRecords As Array
    Dim strmRecordBrowserHTML As String
    Dim strmTotalDePartidas As Integer

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

        intmCategoriaPromocionId = GetPageParameter("cboCategoriaPromocion", 0)
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
    ' Name       : LlenarControlCategoria
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboCategoriaPromocion
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlCategoria() As String

        'Consultamos las direcciones operativas
        astrRecords = Nothing

        astrRecords = Benavides.CC.Data.clsConsultarPromociones.strObtenerCategoriaPromocion(strConnectionString)

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboCategoriaPromocion", intmCategoriaPromocionId, astrRecords, 0, 1, 0)

    End Function
    
#End Region

    '====================================================================
    ' Name       : intTipoBusquedaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTipoBusquedaId() As Integer
        Get
            If Not (Request.Form("cmdTipoBusqueda") = Nothing) Then
                Return CInt(Request.Form("cmdTipoBusqueda"))
            Else
                Return -1
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intVigenciaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intVigenciaId() As Integer
        Get
            If Not (Request.Form("cmdVigencia") = Nothing) Then
                Return CInt(Request.Form("cmdVigencia"))
            Else
                Return -1
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intTipoPromocionId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTipoPromocionId() As Integer
        Get
            If Not (Request.Form("cmdTipoPromocion") = Nothing) Then
                Return CInt(Request.Form("cmdTipoPromocion"))
            Else
                Return -1
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strArticuloId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strArticuloId() As String
        Get
            If Not IsNothing(Request("txtArticuloId")) Then
                Return Request("txtArticuloId")
            Else
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strPromocionId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strPromocionId() As String
        Get
            If Not IsNothing(Request("txtPromocion")) Then
                Return Request("txtPromocion")
            Else
                Return String.Empty
            End If
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
            If Not IsNothing(Request("txtSucursalId")) Then
                Return Request("txtSucursalId")
            Else
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strCategoriaPromocionId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCategoriaPromocionId() As String
        Get
            Return intmCategoriaPromocionId.ToString()
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
    ' Name       : dtmParamFechaInicio
    ' Description: Fecha de inicio a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmParamFechaInicio() As Date
        Get
            If intVigenciaId = 1 Or intVigenciaId = 3 Then

                Dim dtmFechaActual As Date
                dtmFechaActual = New Date(Date.Today.Year, Date.Today.Month, Date.Today.Day)

                Return dtmFechaActual

            Else
                Return dtmFechaInicio
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmParamFechaFin
    ' Description: Fecha de fin  a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmParamFechaFin() As Date
        Get
            If intVigenciaId = 2 Then

                Dim dtmFechaActual As Date
                dtmFechaActual = New Date(Date.Today.Year, Date.Today.Month, Date.Today.Day)

                Return dtmFechaActual

            Else
                Return dtmFechaFin
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

        Dim strRecordBrowserImpresion As String = String.Empty
        Const strComitasDobles As String = """"
        Dim strHTML As New StringBuilder
        Dim objDataArrayPromociones As Array = Nothing

        If (strCmd = "cmdImprimir") Then

            'CONSULTA DE REGISTROS
            objDataArrayPromociones = strTipoPromocion()

            'FORMATO A TABLA CON RESULTADOS
            If IsArray(objDataArrayPromociones) AndAlso objDataArrayPromociones.Length > 0 Then

                'Generacion de Tabla
                If intTipoBusquedaId = 1 Then
                    strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strImpresionPromocionesDetalleArticulo(objDataArrayPromociones))
                Else
                    strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strImpresionPromocionesDetalle(objDataArrayPromociones))
                End If



                'Se ennvia a impresion.
                strHTML.Append("<script language='Javascript'>parent.fnImprimir( " & _
                strComitasDobles & strRecordBrowserImpresion.ToString & strComitasDobles & _
                "); </script>")
                Response.Write(strHTML.ToString)
                Response.End()

            End If

        ElseIf (strCmd = "cmdExportar") Then

            Dim objArrayExportar As System.Array = Nothing

            'Rutina que consulta las promosiones'
            objArrayExportar = strTipoPromocion()

            'FORMATO A TABLA CON RESULTADOS
            If IsArray(objArrayExportar) AndAlso objArrayExportar.Length > 0 Then

                ' Establecemos en la respuesta los parámetros de configuración del archivo
                Response.ContentType = "application/vnd.ms-excel"
                Call Response.AddHeader("Content-Disposition", "attachment; filename=""Consulta de Promociones.xls""")
                Call Response.Write(strTablaConsultaPromocionesExportar(objArrayExportar))
                Call Response.End()

            End If
        End If
    End Sub

    Private Function strTipoBusquedaValor() As String

        If ((intTipoBusquedaId = 1) AndAlso Not (strArticuloId = String.Empty)) Then

            'Articulo
            Return strArticuloId

        ElseIf ((intTipoBusquedaId = 2) AndAlso Not (strPromocionId = String.Empty)) Then

            'Promocion
            Return strPromocionId

        ElseIf ((intTipoBusquedaId = 3) AndAlso Not (strSucursalId = String.Empty)) Then

            'Sucursal
            Return strSucursalId

        ElseIf ((intTipoBusquedaId = 4) AndAlso Not (strCategoriaPromocionId = String.Empty)) Then

            'Categoria
            Return strCategoriaPromocionId

        Else

            'Sin seleccionar Tipo de Busqueda
            Return "0"
        End If

    End Function

    Private Function strTipoPromocion() As Array

        Dim objArray As System.Array = Nothing

        If (intTipoPromocionId = 0) Then

            'Todos
            objArray = Benavides.CC.Data.clsConsultarPromociones.strConsultarTodosCupones(intTipoPromocionId, intTipoBusquedaId, strTipoBusquedaValor(), intVigenciaId, dtmParamFechaInicio, dtmParamFechaFin, strUsuarioNombre, strConnectionString)

        ElseIf (intTipoPromocionId = 1) Then

            'Ofertas
            objArray = Benavides.CC.Data.clsConsultarPromociones.strConsultarOfertasCupones(intTipoPromocionId, intTipoBusquedaId, strTipoBusquedaValor(), intVigenciaId, dtmParamFechaInicio, dtmParamFechaFin, strUsuarioNombre, strConnectionString)

        ElseIf (intTipoPromocionId = 2) Then

            'Promociones
            objArray = Benavides.CC.Data.clsConsultarPromociones.strConsultarPromocionesCupones(intTipoPromocionId, intTipoBusquedaId, strTipoBusquedaValor(), intVigenciaId, dtmParamFechaInicio, dtmParamFechaFin, strUsuarioNombre, strConnectionString)

        ElseIf (intTipoPromocionId = 3) Then

            'Cupones
            objArray = Benavides.CC.Data.clsConsultarPromociones.strConsultarCupones(intTipoPromocionId, intTipoBusquedaId, strTipoBusquedaValor(), intVigenciaId, dtmParamFechaInicio, dtmParamFechaFin, strUsuarioNombre, strConnectionString)

        Else

            'Sin seleccion
            Return objArray
        End If

        Return objArray

    End Function

    Public Function strTablaConsultaPromociones() As String

        Dim objArray As System.Array = Nothing
        Dim resultadoConsulta As String = String.Empty
        Dim strmRecordBrowserHTML As String = String.Empty

        strmTotalDePartidas = 0

        If (strCmd = "cmdConsultar") Then

            If (Request.QueryString("pager") = "true") Then
                If Not Cache("cachePromociones") Is Nothing Then
                    objArray = CType(Cache("cachePromociones"), System.Array)
                End If
            End If

            If objArray Is Nothing Then

                Cache.Remove("cachePromociones")

                'Promociones
                objArray = strTipoPromocion()
            End If

            Dim strResult As New StringBuilder()
            If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then

                'Cantidad de registros
                strmTotalDePartidas = objArray.Length

                Cache.Add("cachePromociones", objArray, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, Nothing)

                'Tabla de Resultados
                strResult.Append(strTablaConsultaPromocionesHTML(objArray))

            Else
                'Tabla vacia sin resultados de consulta
                Call Response.Write("<script language='Javascript'>alert('Consulta sin resultados');</script>")
            End If

            strResult.Append("<script language=""javascript"" type=""text/javascript"">")
            strResult.Append("parent.document.getElementById('tblResultados').innerHTML = document.getElementById('divConsultaPromociones').innerHTML;")
            strResult.Append("</script>")

            Return strResult.ToString()
        End If

        Return String.Empty
    End Function

    Public Function strTablaConsultaPromocionesHTML(ByVal objConsultaRegistros As Array) As String

        Dim strTablaDetalleHTML As StringBuilder
        Dim strConsultaRegistroDetalle As String()
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim imgDetalleArticulos As String = Nothing
        Dim imgDetalleSucursales As String = String.Empty

        Dim intPage As Integer
        Dim intTotal As Integer = 50

        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If

        strTablaDetalleHTML = New StringBuilder
        strTablaDetalleHTML.Append(Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objConsultaRegistros.Length, intPage, intTotal, String.Empty, Nothing))

        strTablaDetalleHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Encabezados de Tabla de Resultados
        strTablaDetalleHTML.Append("<tr class='trtitulos'>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Promo <br> ID</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Descripción</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Tipo <br> Promo</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Tipo <br> Estrategia</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Vigencia <br> Inicio</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Vigencia <br> Fin</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Campaña</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Usuario</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Acción</th>")
        strTablaDetalleHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        'For Each strConsultaRegistroDetalle In objConsultaRegistros
        '    intContador += 1

        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaRegistros.Length) Then
                Exit For
            End If

            strConsultaRegistroDetalle = CType(objConsultaRegistros.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            'Botones "Ver Detalle" (Articulos/Sucursal).
            imgDetalleArticulos = "<img id=" & strConsultaRegistroDetalle(0) & " height='17' src='../static/images/icono_detalle.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerDetalle_onclick(" & strConsultaRegistroDetalle(1) & ", this.id, 1)' alt='Ver articulos involucrados'>"
            imgDetalleSucursales = "<img id=" & strConsultaRegistroDetalle(0) & " height='17' src='../static/images/imgNRCopiar.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerDetalle_onclick(" & strConsultaRegistroDetalle(1) & ", this.id, 2)' alt='Ver sucursales asignadas'>"

            strTablaDetalleHTML.Append("<tr>")
            ' Promo ID
            strTablaDetalleHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroDetalle(1)) & "</td>")
            ' Descripción
            strTablaDetalleHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroDetalle(2)) & "</td>")
            ' Tipo Promo
            strTablaDetalleHTML.Append("<td id=Division" & intContador & " align=center class=" & strColorRegistro & ">" & strConsultaRegistroDetalle(3) & "</td>")
            ' Tipo Estrategia
            strTablaDetalleHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroDetalle(4)) & "</td>")
            ' Vigencia Inicio
            strTablaDetalleHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaRegistroDetalle(5)) & "</td>")
            ' Vigencia  Fin
            strTablaDetalleHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaRegistroDetalle(6)) & "</td>")
            ' Campaña
            strTablaDetalleHTML.Append("<td align=center class=" & strColorRegistro & " title='" & strConsultaRegistroDetalle(8) & "'>" & clsCommons.strFormatearDescripcion(strConsultaRegistroDetalle(7)) & "</td>")
            ' Usuario
            strTablaDetalleHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroDetalle(11)) & "</td>")
            'Accion 
            strTablaDetalleHTML.Append("<td align=center class=" & strColorRegistro & ">" & imgDetalleArticulos & " " & imgDetalleSucursales & "</td>")
            strTablaDetalleHTML.Append("</tr>")
        Next

        strTablaDetalleHTML.Append("</tr>")
        strTablaDetalleHTML.Append("</table>")
        strTablaDetalleHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaPromocionesHTML = strTablaDetalleHTML.ToString

    End Function

#Region "Pop's"

    'Funcion que busca la Promocion por Codigo y muestra su descripcion para realizar una busqueda.
    Public Function strTablaConsultaCodigoArticulo() As String

        strmRecordBrowserHTML = String.Empty

        If (Request.QueryString("strCmd") = "BuscarArticulo") Then
            Dim objArray As System.Array = clsConcentrador.clsSucursal.strBuscarArticulo(0, 0, strArticuloId, 1, 1, strConnectionString)

            If IsArray(objArray) AndAlso objArray.Length > 0 Then
                Dim strResult As StringBuilder
                strResult = New StringBuilder

                strResult.Append("<script language=""javascript"" type=""text/javascript"">")
                strResult.AppendFormat("parent.document.getElementById('txtDescripcionArticulo').value = '{0}';", CType(objArray.GetValue(0), Array).GetValue(5))
                strResult.Append("</script>")

                Return strResult.ToString()
            End If
        End If

        Return String.Empty
    End Function

    'Funcion que busca la Promocion por Codigo y muestra su descripcion para realizar una busqueda.
    Public Function strTablaConsultaCodigoPromocion() As String

        strmRecordBrowserHTML = String.Empty
        Dim objArray As System.Array = Nothing
        Dim strResult As New StringBuilder()

        If (Request.QueryString("strCmd") = "cmdConsultarPorCodigo") Then

            'Valida que tipo de Promocion es
            If intTipoPromocionId = 1 Then

                'Ofertas
                objArray = Benavides.CC.Data.clsConsultarPromociones.strBuscarPopOfertasCupones(strPromocionId, strConnectionString)
            ElseIf intTipoPromocionId = 2 Then

                'Promociones
                objArray = Benavides.CC.Data.clsConsultarPromociones.strBuscarPopPromocionesCupones(strPromocionId, strConnectionString)

            ElseIf intTipoPromocionId = 3 Then

                'Cupones
                objArray = Benavides.CC.Data.clsConsultarPromociones.strBuscarPopCupones(strPromocionId, strConnectionString)
            End If

            strResult.Append("<script language=""javascript"" type=""text/javascript"">")

            If IsArray(objArray) AndAlso objArray.Length > 0 Then
                strResult.AppendFormat("parent.document.getElementById('txtPromocionDescripcion').value = '{0}';", CType(objArray.GetValue(0), Array).GetValue(1))
            Else
                strResult.AppendFormat("parent.document.getElementById('txtPromocionDescripcion').value = '{0}';", String.Empty)
            End If

            strResult.Append("</script>")

            Return strResult.ToString()
        End If

        Return String.Empty

    End Function

    'Funcion que busca la Sucursal por Centro Logistico y muestra su descripcion para realizar una busqueda.
    Public Function strTablaConsultaCodigoSucursal() As String

        strmRecordBrowserHTML = String.Empty

        If (Request.QueryString("strCmd") = "cmdConsultarPorSucursal") Then

            Dim objArray As System.Array = Benavides.CC.Data.clsConsultarPromociones.strBuscarPopSucursalCupones(strSucursalId, strConnectionString)

            If IsArray(objArray) AndAlso objArray.Length > 0 Then
                Dim strResult As New StringBuilder()

                strResult.Append("<script language=""javascript"" type=""text/javascript"">")
                strResult.AppendFormat("parent.document.getElementById('txtSucursalDescripcion').value = '{0}';", CType(objArray.GetValue(0), Array).GetValue(3))
                strResult.Append("</script>")

                Return strResult.ToString()
            End If
        End If

        Return String.Empty
    End Function


#End Region

#Region "Imprimir"

    '====================================================================
    ' Name       : strImpresionPromocionesDetalle
    ' Description: Generacion de tabla HTML con formato para imprimir resultados de la consulta.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImpresionPromocionesDetalle(ByVal objDataArrayPromociones As Array) As String

        'Variables
        Dim strImpresionPromocionesHTML As StringBuilder = New StringBuilder
        Dim strRegistroPromociones As String()
        Dim strclase As String = String.Empty
        Dim intRenglonesxPagina As Integer = 58

        'Rutina que solo se ejecuta al contener informacion de la consulta.
        If IsArray(objDataArrayPromociones) AndAlso (objDataArrayPromociones.Length > 0) Then

            Dim intTotalRenglones As Integer = objDataArrayPromociones.Length
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
            For Each strRegistroPromociones In objDataArrayPromociones

                intRenglon += 1
                intContadorRenglon += 1

                If intRenglon = 1 Then
                    intPagina += 1

                    'Salto de hoja
                    If intPagina > 1 Then
                        strImpresionPromocionesHTML.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")
                    End If

                    strImpresionPromocionesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    'Metodo que genera y da formato al encabezado.
                    strImpresionPromocionesHTML.Append(strImprimeEncabezadoPromociones(intPagina.ToString, intTotalPaginas.ToString))
                End If

                'Clases para renglones.
                If ((intRenglon Mod 2) = 0) Then
                    strclase = "tdtxtImpresionNormal"
                Else
                    strclase = "tdtxtImpresionBold"
                End If

                strImpresionPromocionesHTML.Append("<tr>")
                ' No
                strImpresionPromocionesHTML.Append("<td width='6%' align='center' class='" & strclase & "' nowrap >" & strRegistroPromociones(1).ToString & "</td>")
                ' Descripción
                strImpresionPromocionesHTML.Append("<td width='16%' align='left' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroPromociones(2)).ToString & "</td>")
                ' Tipo Promo
                strImpresionPromocionesHTML.Append("<td width='7%' align='center' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroPromociones(3)) & "</td>")
                ' Tipo <br> Estrategia
                strImpresionPromocionesHTML.Append("<td width='13%' align='left' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroPromociones(4)) & "</td>")
                ' Vigencia <br> Inicio
                strImpresionPromocionesHTML.Append("<td width='15%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearFechaPresentacion(strRegistroPromociones(5)) & "</td>")
                'Vigencia <br> Fin
                strImpresionPromocionesHTML.Append("<td width='6%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearFechaPresentacion(strRegistroPromociones(6)) & "</td>")
                'Campaña
                strImpresionPromocionesHTML.Append("<td width='16%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroPromociones(7)) & "</td>")
                'Usuario
                strImpresionPromocionesHTML.Append("<td width='16%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroPromociones(11)) & "</td>")
                strImpresionPromocionesHTML.Append("</tr>")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionPromocionesHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next
        End If

        Return strImpresionPromocionesHTML.ToString()

    End Function

    Private Function strImprimeEncabezadoPromociones(ByVal strHojaActual As String, ByVal strHojaFinal As String) As String

        Dim strHtmlEncabezado As StringBuilder
        strHtmlEncabezado = New StringBuilder

        'Encabezado principal
        strHtmlEncabezado.Append("<tr>")
        strHtmlEncabezado.Append("<td colspan='8'>")
        strHtmlEncabezado.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='8' class='tdtxtBold'>Consulta de Promociones</th>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='7%' align='left'   class='tdtxtBold'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th width='50%' align='center' class='tdtxtBold' nowrap> ADS Central </th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='23%' align='left'  class='tdtxtBold'>HOJA " & strHojaActual & " / " & strHojaFinal & " </th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strHtmlEncabezado.Append("</td>")

        'Encabezado titulos
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='6%' class='tdtxtBold' align='center' nowrap>Promo ID</th>")
        strHtmlEncabezado.Append("<th width='16%' class='tdtxtBold' align='center' nowrap>Descripción</th>")
        strHtmlEncabezado.Append("<th width='16%' class='tdtxtBold' align='center' nowrap>Tipo <br> Promo</th>")
        strHtmlEncabezado.Append("<th width='7%' class='tdtxtBold' align='center' nowrap>Tipo <br> Estrategia</th>")
        strHtmlEncabezado.Append("<th width='15%' class='tdtxtBold' align='center' nowrap>Vigencia <br> Inicio</th>")
        strHtmlEncabezado.Append("<th width='6%' class='tdtxtBold' align='center' nowrap>Vigencia <br> Fin</th>")
        strHtmlEncabezado.Append("<th width='7%' class='tdtxtBold' align='center' nowrap>Campaña</th>")
        strHtmlEncabezado.Append("<th width='6%' class='tdtxtBold' align='center' nowrap>Usuario</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' class='rayita' colspan='8'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        strImprimeEncabezadoPromociones = strHtmlEncabezado.ToString

    End Function

    '====================================================================
    ' Name       : strImpresionPromocionesDetalleArticulo
    ' Description: Generacion de tabla HTML con formato para imprimir resultados de la consulta.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImpresionPromocionesDetalleArticulo(ByVal objDataArrayPromociones As Array) As String

        'Variables
        Dim strImpresionPromocionesHTML As StringBuilder = New StringBuilder
        Dim strRegistroPromociones As String()
        Dim strclase As String = String.Empty
        Dim intRenglonesxPagina As Integer = 58

        'Rutina que solo se ejecuta al contener informacion de la consulta.
        If IsArray(objDataArrayPromociones) AndAlso (objDataArrayPromociones.Length > 0) Then

            Dim intTotalRenglones As Integer = objDataArrayPromociones.Length
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
            For Each strRegistroPromociones In objDataArrayPromociones

                intRenglon += 1
                intContadorRenglon += 1

                If intRenglon = 1 Then
                    intPagina += 1

                    'Salto de hoja
                    If intPagina > 1 Then
                        strImpresionPromocionesHTML.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")
                    End If

                    strImpresionPromocionesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    'Metodo que genera y da formato al encabezado.
                    strImpresionPromocionesHTML.Append(strImprimeEncabezadoPromocionesArticulo(intPagina.ToString, intTotalPaginas.ToString))
                End If

                'Clases para renglones.
                If ((intRenglon Mod 2) = 0) Then
                    strclase = "tdtxtImpresionNormal"
                Else
                    strclase = "tdtxtImpresionBold"
                End If

                strImpresionPromocionesHTML.Append("<tr>")
                ' No
                strImpresionPromocionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' nowrap >" & strRegistroPromociones(1).ToString & "</td>")
                ' SKU
                strImpresionPromocionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' nowrap >" & strArticuloId & "</td>")
                ' Descripción
                strImpresionPromocionesHTML.Append("<td width='20%' align='left' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroPromociones(2)).ToString & "</td>")
                ' Tipo Promo
                strImpresionPromocionesHTML.Append("<td width='16%' align='center' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroPromociones(3)) & "</td>")
                ' Tipo <br> Estrategia
                strImpresionPromocionesHTML.Append("<td width='8%' align='left' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroPromociones(4)) & "</td>")
                ' Vigencia <br> Inicio
                strImpresionPromocionesHTML.Append("<td width='9%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearFechaPresentacion(strRegistroPromociones(5)) & "</td>")
                'Vigencia <br> Fin
                strImpresionPromocionesHTML.Append("<td width='9%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearFechaPresentacion(strRegistroPromociones(6)) & "</td>")
                'Campaña
                strImpresionPromocionesHTML.Append("<td width='8%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroPromociones(7)) & "</td>")
                'Usuario
                strImpresionPromocionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroPromociones(11)) & "</td>")
                strImpresionPromocionesHTML.Append("</tr>")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionPromocionesHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next
        End If

        Return strImpresionPromocionesHTML.ToString()

    End Function

    Private Function strImprimeEncabezadoPromocionesArticulo(ByVal strHojaActual As String, ByVal strHojaFinal As String) As String

        Dim strHtmlEncabezado As StringBuilder
        strHtmlEncabezado = New StringBuilder

        'Encabezado principal
        strHtmlEncabezado.Append("<tr>")
        strHtmlEncabezado.Append("<td colspan='9'>")
        strHtmlEncabezado.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='9' class='tdtxtBold'>Consulta de Promociones</th>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='7%' align='left'   class='tdtxtBold'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th width='50%' align='center' class='tdtxtBold' nowrap> ADS Central </th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='23%' align='left'  class='tdtxtBold'>HOJA " & strHojaActual & " / " & strHojaFinal & " </th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strHtmlEncabezado.Append("</td>")

        'Encabezado titulos
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Promo ID</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>SKU</th>")
        strHtmlEncabezado.Append("<th width='20%' class='tdtxtBold' align='center' nowrap>Descripción</th>")
        strHtmlEncabezado.Append("<th width='16%' class='tdtxtBold' align='center' nowrap>Tipo <br> Promo</th>")
        strHtmlEncabezado.Append("<th width='8%' class='tdtxtBold' align='center' nowrap>Tipo <br> Estrategia</th>")
        strHtmlEncabezado.Append("<th width='9%' class='tdtxtBold' align='center' nowrap>Vigencia <br> Inicio</th>")
        strHtmlEncabezado.Append("<th width='9%' class='tdtxtBold' align='center' nowrap>Vigencia <br> Fin</th>")
        strHtmlEncabezado.Append("<th width='8%' class='tdtxtBold' align='center' nowrap>Campaña</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Usuario</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' class='rayita' colspan='9'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        strImprimeEncabezadoPromocionesArticulo = strHtmlEncabezado.ToString

    End Function

#End Region

#Region "Exportar"

    Public Function strTablaConsultaPromocionesExportar(ByVal objConsultaPromociones As Array) As String

        Dim strTablaPromocionesHTML As StringBuilder
        Dim strConsultaPromociones As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer

        strTablaPromocionesHTML = New StringBuilder
        strTablaPromocionesHTML.Append("<span class='txsubtitulo'> </span> ")
        strTablaPromocionesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Encabezados de Tabla de Resultados
        strTablaPromocionesHTML.Append("<tr class='trtitulos'>")
        strTablaPromocionesHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>No. Promo</th>")

        If intTipoBusquedaId = 1 Then
            strTablaPromocionesHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>SKU</th>")
        End If

        strTablaPromocionesHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Descripción</th>")
        strTablaPromocionesHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Tipo Promo</th>")
        strTablaPromocionesHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Tipo Estrategia</th>")
        strTablaPromocionesHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Vigencia Inicio</th>")
        strTablaPromocionesHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Vigencia Fin</th>")
        strTablaPromocionesHTML.Append("<th width='8%' align=center class='rayita' align='left' valign='top'>No. Campaña</th>")
        strTablaPromocionesHTML.Append("<th width='15%' align=center class='rayita' align='left' valign='top'>Campaña</th>")
        strTablaPromocionesHTML.Append("<th width='15%' align=center class='rayita' align='left' valign='top'>Total de Articulos</th>")
        strTablaPromocionesHTML.Append("<th width='15%' align=center class='rayita' align='left' valign='top'>Total de Sucursales</th>")
        strTablaPromocionesHTML.Append("<th width='8%' align=center class='rayita' align='left' valign='top'>Usuario</th>")
        strTablaPromocionesHTML.Append("</tr>")
        
        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For Each strConsultaPromociones In objConsultaPromociones
            intContador = intContador + 1

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strTablaPromocionesHTML.Append("<tr>")

            'No. Promocion               
            strTablaPromocionesHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaPromociones(1).ToString() & "</td>")

            If intTipoBusquedaId = 1 Then

                'SKU
                strTablaPromocionesHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strArticuloId) & "</td>")
            End If

            'Descripción
            strTablaPromocionesHTML.Append("<td align=left id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaPromociones(2)) & "</td>")
            'Tipo Promo
            strTablaPromocionesHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaPromociones(3)) & "</td>")
            'Tipo Estrategia
            strTablaPromocionesHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaPromociones(4)) & "</td>")
            'Vigencia Inicio
            strTablaPromocionesHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaPromociones(5)) & "</td>")
            'Vigencia Fin
            strTablaPromocionesHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaPromociones(6)) & "</td>")
            'Id Campaña
            strTablaPromocionesHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaPromociones(7)) & "</td>")
            'Campaña Descripcion
            strTablaPromocionesHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaPromociones(8)) & "</td>")
            'Total de Articulos
            strTablaPromocionesHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaPromociones(9) & "</td>")
            'Total de Sucursales
            strTablaPromocionesHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaPromociones(10) & "</td>")
            'Usuario
            strTablaPromocionesHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaPromociones(11) & "</td>")
            strTablaPromocionesHTML.Append("</tr>")

        Next
        strTablaPromocionesHTML.Append("</tr>")
        strTablaPromocionesHTML.Append("</table>")
        strTablaConsultaPromocionesExportar = strTablaPromocionesHTML.ToString
    End Function
#End Region

End Class