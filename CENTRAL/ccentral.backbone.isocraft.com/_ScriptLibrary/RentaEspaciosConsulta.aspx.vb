Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration
Imports Benavides.CC.Data.clsPromociones
Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports System.IO
Imports System.Web.Caching

Public Class RentaEspaciosConsulta1
    Inherits System.Web.UI.Page

    Private strmDivision As String
    Private strmFechaFin As String
    Private strmImplementado As String
    Private strmMotivo As String
    Private strmComentarios As String
    Private strmPlanSalida As String
    Private strmRutaImagen As String = String.Empty
    Dim strmRecordBrowserHTML As String
    Private intMotivoNoImplementacionId As Integer

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

        intMotivoNoImplementacionId = GetPageParameter("cboMotivo", 0)

    End Sub

#End Region

    '====================================================================
    ' Name       : LlenarControlMotivo
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboMotivo
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlMotivo() As String
        Return CreateJavascriptComboBoxOptions("cboMotivo", CStr(intMotivoNoImplementacionId), Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarMotivoNoImplementacion(strCadenaConexion), "intMotivoNoImplementacionId", "strMotivoNoImplementacionDescripcion", 1)
    End Function

    '====================================================================
    ' Name       : strRedirectPage
    ' Description: Página hacia la cual se debe redireccionar al usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRedirectPage() As String
        Get
            If intCompaniaId > 0 AndAlso intSucursalId > 0 Then
                Return "/Default.aspx?strURL=/_ScriptLibrary/POSAdminRedirectorCC.aspx?strPageName=" & strThisPageName
            Else
                Return "/Default.aspx?strURL=" & Server.UrlEncode(Request.ServerVariables("SCRIPT_NAME"))
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strFormAction
    ' Description: Valor de la acción de la forma HTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormAction() As String
        Get
            Return Request.ServerVariables("SCRIPT_NAME")
        End Get
    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: URL de esta página
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return clsCommons.strGetPageName(Request)
        End Get
    End Property

    '====================================================================
    ' Name       : intGrupoUsuarioId
    ' Description: Identificador del Grupo de Usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intGrupoUsuarioId() As Integer
        Get
            Return CInt(clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : intCompaniaId
    ' Description: Valor de la Compañia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCompaniaId() As Integer
        Get
            Return CInt(clsCommons.strReadCookie("intCompaniaId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Valor de la Sucursal
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intSucursalId() As Integer
        Get
            Return CInt(clsCommons.strReadCookie("intSucursalId", "0", Request, Server))
        End Get
    End Property
    '====================================================================
    ' Name       : strSucursalNombre
    ' Description: Nombre de la Sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalNombre() As String
        Get
            Return clsCommons.strReadCookie("strSucursalNombre", "0", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strCentroLogisticoId
    ' Description: Valor de la Compañia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCentroLogisticoId() As String
        Get
            Return (clsCommons.strReadCookie("strCentroLogisticoId", "", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del Usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return clsCommons.strReadCookie("strUsuarioNombre", "0", Request, Server)
        End Get
    End Property
    '====================================================================
    ' Name       : strCadenaConexion
    ' Description: Valor que tomara la variable strmCadenaConexion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCadenaConexion() As String
        Get
            Return ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strURLPOSAdmin
    ' Description: Valor que tomara la variable strmCadenaConexion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strURLPOSAdmin() As String
        Get
            Return clsConcentrador.strObtenerURLSucursal(intCompaniaId, intSucursalId, strCadenaConexion)
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
            Return GetPageParameter("strCmd", "")
        End Get
    End Property

    '====================================================================
    ' Name       : strDivision
    ' Description: Nombre o descripcion del articulo.
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strDivision() As String
        Get
            Return strmDivision
        End Get
        Set(ByVal strValue As String)
            strmDivision = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaFin
    ' Description: Nombre o descripcion del articulo.
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strFechaFin() As String
        Get
            Return strmFechaFin
        End Get
        Set(ByVal strValue As String)
            strmFechaFin = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : strImplementado
    ' Description: Nombre o descripcion del articulo.
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strImplementado() As String
        Get
            Return strmImplementado
        End Get
        Set(ByVal strValue As String)
            strmImplementado = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strMotivo
    ' Description: Nombre o descripcion del articulo.
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strMotivo() As String
        Get
            Return strmMotivo
        End Get
        Set(ByVal strValue As String)
            strmMotivo = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strComentarios
    ' Description: Nombre o descripcion del articulo.
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strComentarios() As String
        Get
            Return strmComentarios
        End Get
        Set(ByVal strValue As String)
            strmComentarios = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strPlanSalida
    ' Description: Nombre o descripcion del articulo.
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strPlanSalida() As String
        Get
            Return strmPlanSalida
        End Get
        Set(ByVal strValue As String)
            strmPlanSalida = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCodigoExhibicionId
    ' Description: Codigo de la exhibicion
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCodigoExhibicionId() As String
        Get
            If Not IsNothing(Request.QueryString("intExhibicionCodigo")) Then
                'Si es parametro de la pantalla anterior
                Return Request.QueryString("intExhibicionCodigo")
            Else
                Return Nothing
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strRutaImagen
    ' Description: Ruta de la imagen
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRutaImagen() As String
        Get
            Return strmRutaImagen
        End Get
        Set(ByVal Value As String)
            strmRutaImagen = Value

        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load 'Me.Load

        'Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If


        'Guarda el "Motivo" por el cual NO se implemento
        If Request.QueryString("strCmd") = "cmdGuardar" Then
            Dim intResultado As Integer = 0
            Dim boolImplementada As Boolean = False

            If Len(Trim(Request("chkImplementado"))) > 0 Then
                boolImplementada = True
            End If

            intResultado = Benavides.CC.Data.clsExhibicionesAdicionales.intEditarRazonNoImplementacion(CInt(strCodigoExhibicionId), intCompaniaId, intSucursalId, boolImplementada, intMotivoNoImplementacionId, Request.Form("txtRazon").ToUpper(), strCadenaConexion)

            If (intResultado = 1) Then
                Call Response.Write("<script language='Javascript'>alert('La informacion se ha guardado con exito');</script>")
            Else
                Call Response.Write("<script language='Javascript'>alert('NO se pudo guardar la informacion');</script>")
            End If
        End If

        'Mostrar Detalle de Exhibicion
        If Request.QueryString("strCmd") = "cmdDetalleExhibicion" Or Request.QueryString("strCmd") = "cmdGuardar" Then
            Dim objArrayDetalleExhibiciones As Array = Nothing
            Dim rutaImagenes As String = System.Configuration.ConfigurationSettings.AppSettings("strImagenesExhibiciones")

            If Not IsNothing(strCodigoExhibicionId) AndAlso CInt(strCodigoExhibicionId) > 0 Then

                objArrayDetalleExhibiciones = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarDetalleExhibicionSucursal(CInt(strCodigoExhibicionId), intCompaniaId, intSucursalId, strCadenaConexion)

                If Not objArrayDetalleExhibiciones Is Nothing AndAlso IsArray(objArrayDetalleExhibiciones) AndAlso objArrayDetalleExhibiciones.Length > 0 Then

                    strmPlanSalida = CStr(CType(objArrayDetalleExhibiciones.GetValue(0), Array).GetValue(19)) 'strPlanSalida
                    strmFechaFin = (CDate(CType(objArrayDetalleExhibiciones.GetValue(0), Array).GetValue(34))).ToString("dd/MM/yyyy") 'strFechaFin
                    strmImplementado = CStr(CType(objArrayDetalleExhibiciones.GetValue(0), Array).GetValue(35)) 'chkImplementado()
                    strmMotivo = CStr(CType(objArrayDetalleExhibiciones.GetValue(0), Array).GetValue(36)) 'Motivo()
                    strmComentarios = CStr(CType(objArrayDetalleExhibiciones.GetValue(0), Array).GetValue(38)) 'txtRazon()
                    strmRutaImagen = Trim(CStr(CType(objArrayDetalleExhibiciones.GetValue(0), Array).GetValue(32)))

                    If Not strmRutaImagen = String.Empty Then
                        strmRutaImagen = String.Format("{0}?id={1}", rutaImagenes, strmRutaImagen)
                    End If
                End If
            End If
        End If

        If Request.QueryString("strCmd") = "cmdImprimir" Then

            Dim strHTML As New StringBuilder
            Dim objDataArrayExhibiciones As Array = Nothing
            Dim strRecordBrowserImpresion As String = ""
            Const strComitasDobles As String = """"

            'Resultados a mostrar en pantalla para Resumen
            objDataArrayExhibiciones = Benavides.CC.Data.clsExhibicionesAdicionales.strExhibicionesAdicionalesSucursal(intCompaniaId, intSucursalId, strCadenaConexion)

            If IsArray(objDataArrayExhibiciones) AndAlso objDataArrayExhibiciones.Length > 0 Then

                'Se envia la informacion a imprimir para darle formato de acuerdo a la tabla seleccionada por el usuario.  
                strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strImpresionExhibiciones(objDataArrayExhibiciones))

                'Se ennvia a impresion.
                strHTML.Append("<script language='Javascript'>parent.fnImprimir( " & _
                strComitasDobles & strRecordBrowserImpresion.ToString & strComitasDobles & _
                "); </script>")
                Response.Write(strHTML.ToString)
                Response.End()

            End If
        End If
    End Sub

#Region "Imprimir"

    '====================================================================
    ' Name       : strImpresionExhibiciones
    ' Description: Generacion de tabla HTML con formato para imprimir resultados de la consulta.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImpresionExhibiciones(ByVal objDataArrayExhibiciones As Array) As String

        'Variables
        Dim strImpresionExhibicionesHTML As StringBuilder = New StringBuilder
        Dim strRegistroExhibiciones As String()
        Dim strclase As String = ""
        Dim intRenglonesxPagina As Integer = 58

        'Rutina que solo se ejecuta al contener informacion de la consulta.
        If IsArray(objDataArrayExhibiciones) AndAlso (objDataArrayExhibiciones.Length > 0) Then

            Dim intTotalRenglones As Integer = objDataArrayExhibiciones.Length
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
            For Each strRegistroExhibiciones In objDataArrayExhibiciones

                intRenglon += 1
                intContadorRenglon += 1

                If intRenglon = 1 Then
                    intPagina += 1

                    'Salto de hoja
                    If intPagina > 1 Then
                        strImpresionExhibicionesHTML.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")
                    End If

                    strImpresionExhibicionesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    'Metodo que genera y da formato al encabezado.
                    strImpresionExhibicionesHTML.Append(strImprimeEncabezado(intPagina.ToString, intTotalPaginas.ToString))
                End If

                'Clases para renglones.
                If ((intRenglon Mod 2) = 0) Then
                    strclase = "tdtxtImpresionNormal"
                Else
                    strclase = "tdtxtImpresionBold"
                End If

                strImpresionExhibicionesHTML.Append("<tr>")
                ' Nombre de Exhibicion
                strImpresionExhibicionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(1)).ToString & "</td>")
                ' Tipo de Renta
                strImpresionExhibicionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(2)) & "</td>")
                ' Proveedor
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' nowrap >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(4)).ToString & "</td>")
                ' Categoría
                strImpresionExhibicionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(5)) & "</td>")
                ' Planograma
                strImpresionExhibicionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(6)) & "</td>")
                'CatMan
                strImpresionExhibicionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(7)) & "</td>")
                'Fecha Ini
                strImpresionExhibicionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearFechaPresentacion(strRegistroExhibiciones(8)) & "</td>")
                'Fecha Fin
                strImpresionExhibicionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearFechaPresentacion(strRegistroExhibiciones(9)) & "</td>")
                'Estatus
                strImpresionExhibicionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(10)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionExhibicionesHTML.Append("</table>")
                    intRenglon = 0
                End If
            Next
        End If

        Return strImpresionExhibicionesHTML.ToString()

    End Function

    Private Function strImprimeEncabezado(ByVal strHojaActual As String, ByVal strHojaFinal As String) As String

        Dim strHtmlEncabezado As StringBuilder
        strHtmlEncabezado = New StringBuilder

        'Encabezado principal
        strHtmlEncabezado.Append("<tr>")
        strHtmlEncabezado.Append("<td colspan='9'>")
        strHtmlEncabezado.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='8' class='tdtxtBold'>Exhibiciones Adicionales - Consulta</th>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='10%' align='left'   class='tdtxtBold'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th width='50%' align='center' class='tdtxtBold' nowrap>" & strCentroLogisticoId & " - " & strSucursalNombre & " (" & intCompaniaId.ToString & intSucursalId.ToString("000") & ")" & "</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='10%' align='right'  class='tdtxtBold'>HOJA " & strHojaActual & " / " & strHojaFinal & " </th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strHtmlEncabezado.Append("</td>")
        strHtmlEncabezado.Append("</tr>")

        'Encabezado titulos
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='15%' class='tdtxtBold' align='center' nowrap>Nombre de Exhibición</th>")
        strHtmlEncabezado.Append("<th width='15%' class='tdtxtBold' align='center' nowrap>Tipo de Renta</th>")
        strHtmlEncabezado.Append("<th width='15%' class='tdtxtBold' align='center' nowrap>Proveedor</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Categoría</th>")
        strHtmlEncabezado.Append("<th width='15%' class='tdtxtBold' align='center' nowrap>Planograma</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>CatMan</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Fecha Ini</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Fecha Fin</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Estatus</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' class='rayita' colspan='9'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        strImprimeEncabezado = strHtmlEncabezado.ToString

    End Function

#End Region

    'la que no se usa
    Public Function strTablaConsultaExhibiciones() As String
        Dim objArray As System.Array = Nothing
        strmRecordBrowserHTML = String.Empty

        If (Request.QueryString("strCmd") = "cmdConsultar") Then
            If (Request.QueryString("pager") = "true") Then
                If Not Cache("cacheExhibiciones") Is Nothing Then
                    objArray = CType(Cache("cacheExhibiciones"), System.Array)
                End If
            End If

            If objArray Is Nothing Then
                Cache.Remove("cacheExhibiciones")
                objArray = Benavides.CC.Data.clsExhibicionesAdicionales.strExhibicionesAdicionalesSucursal(intCompaniaId, intSucursalId, strCadenaConexion)
            End If

            Dim strResult As New StringBuilder()
            If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then
                Cache.Add("cacheExhibiciones", objArray, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, Nothing)

                strResult.Append(strTablaConsultaExhibicionesAdicionalesHTML(objArray))
            End If

            strResult.Append("<script language=""javascript"" type=""text/javascript"">")
            strResult.Append("parent.document.getElementById('tblResultados').innerHTML = document.getElementById('divConsultaExhibiciones').innerHTML;")
            strResult.Append("</script>")

            Return strResult.ToString()
        End If

        Return String.Empty
    End Function

    Public Function strTablaConsultaExhibicionesAdicionalesHTML(ByVal objConsultaExhibiciones As Array) As String
        Dim strTablaEspaciosHTML As StringBuilder
        Dim strConsultaExhibiciones As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer

        Dim imgDetalle As String = Nothing

        Dim Imagen As String = Nothing
        Dim intPage As Integer
        Dim intTotal As Integer = 50
        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If

        strTablaEspaciosHTML = New StringBuilder
        strTablaEspaciosHTML.Append("<span class='txsubtitulo'> </span> ")
        strTablaEspaciosHTML.Append(Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objConsultaExhibiciones.Length, intPage, intTotal, String.Empty, Nothing))

        strTablaEspaciosHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strTablaEspaciosHTML.Append("<tr class='trtitulos'>")
        strTablaEspaciosHTML.Append("<th width='15%' align=center class='rayita' align='left' valign='top'>Tipo de Exhibicion</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Proveedor</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Categoría</th>")
        strTablaEspaciosHTML.Append("<th width='15%' align=center class='rayita' align='left' valign='top'>Planograma</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>CatMan</th>")
        strTablaEspaciosHTML.Append("<th width='15%' align=center class='rayita' align='left' valign='top'>Tipo de Mueble</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Fecha Ini</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Fecha Fin</th>")
        strTablaEspaciosHTML.Append("<th width='5%'  align=center class='rayita' align='left' valign='top'>&nbsp;</th>")
        strTablaEspaciosHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaExhibiciones.Length) Then
                Exit For
            End If

            strConsultaExhibiciones = CType(objConsultaExhibiciones.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            'Imagenes de la accion 
            imgDetalle = "<img id=Ver" & strConsultaExhibiciones(0) & " height='17' src='../static/images/icono_lupa.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerificarAccion_onclick(this.id, 1)'>"

            'Tipo de Renta       
            strTablaEspaciosHTML.Append("<td id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & strConsultaExhibiciones(1) & "</td>")
            'Proveedor                
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(2)) & "</td>")
            'Categoría                 
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(3)) & "</td>")
            'Planograma
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(4)) & "</td>")
            'CatMan
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(5)) & "</td>")
            'Tipo de Mueble
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(6)) & "</td>")

            'Fecha Ini
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaExhibiciones(7)) & "</td>")
            'Fecha Fin
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaExhibiciones(8)) & "</td>")
            'Acción                        strFormato 1x1
            strTablaEspaciosHTML.Append("<td align=right class=" & strColorRegistro & ">" & imgDetalle & "</td>")
            strTablaEspaciosHTML.Append("</tr>")

        Next
        strTablaEspaciosHTML.Append("</tr>")
        strTablaEspaciosHTML.Append("</table>")
        strTablaEspaciosHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaExhibicionesAdicionalesHTML = strTablaEspaciosHTML.ToString 'clsCommons.strGenerateJavascriptString(strTablaEspaciosHTML.ToString)
    End Function

    Public Function strTablaConsultaDetalle() As String
        Dim resultadoConsulta As String = String.Empty
        Dim strResult As New StringBuilder()

        'Mostrar Detalle de Exhibicion
        If Request.QueryString("strCmd") = "cmdDetalleExhibicion" Then
            Dim objArrayDetalleExhibiciones As Array = Nothing
            Dim ocultarEstatus As String = "block"
            Dim rutaImagenes As String = System.Configuration.ConfigurationSettings.AppSettings("strImagenesExhibiciones")

            If Not IsNothing(strCodigoExhibicionId) AndAlso CInt(strCodigoExhibicionId) > 0 Then
                objArrayDetalleExhibiciones = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarDetalleExhibicionSucursal(CInt(strCodigoExhibicionId), intCompaniaId, intSucursalId, strCadenaConexion)

                If Not objArrayDetalleExhibiciones Is Nothing AndAlso IsArray(objArrayDetalleExhibiciones) AndAlso objArrayDetalleExhibiciones.Length > 0 Then
                    strmPlanSalida = CStr(CType(objArrayDetalleExhibiciones.GetValue(0), Array).GetValue(19)) 'strPlanSalida
                    strmFechaFin = (CDate(CType(objArrayDetalleExhibiciones.GetValue(0), Array).GetValue(34))).ToString("dd/MM/yyyy") 'strFechaFin
                    strmImplementado = CStr(CType(objArrayDetalleExhibiciones.GetValue(0), Array).GetValue(35)) 'chkImplementado()
                    strmMotivo = CStr(CType(objArrayDetalleExhibiciones.GetValue(0), Array).GetValue(36)) 'Motivo()
                    strmComentarios = CStr(CType(objArrayDetalleExhibiciones.GetValue(0), Array).GetValue(38)) 'txtRazon()
                    strmRutaImagen = Trim(CStr(CType(objArrayDetalleExhibiciones.GetValue(0), Array).GetValue(32)))

                    If Not strmRutaImagen = String.Empty Then
                        strmRutaImagen = String.Format("{0}?id={1}", rutaImagenes, strmRutaImagen)
                    End If

                    If True = CBool(strmImplementado) Then
                        ocultarEstatus = "none"
                        strmImplementado = "true"
                    Else
                        strmImplementado = "false"
                    End If

                    strResult.Append("<script language=""javascript"" type=""text/javascript"">")
                    strResult.Append("parent.document.getElementById('tdPlanSalida').innerHTML = '" & strmPlanSalida & "';")
                    strResult.Append("parent.document.getElementById('tdFechaFin').innerHTML = '" & strmFechaFin & "';")
                    strResult.Append("parent.document.getElementById('chkImplementado').checked = " & strmImplementado & ";")
                    strResult.Append("parent.document.getElementById('txtRazon').value = '" & strmComentarios & "';")
                    strResult.Append("</script>")
                    Return strResult.ToString()
                End If
            End If
        End If

        Return String.Empty
    End Function

    'Muestra el regitro de la "Exhibicion Adicional" en la parte superior de la pantalla.
    Public Function strTablaConsultaExhibicionesAdicionales() As String
        Dim objArray As System.Array = Nothing
        Dim resultadoConsulta As String = String.Empty

        If (Request.QueryString("pager") = "true") Then
            If Not Cache("cacheExhibiciones") Is Nothing Then
                objArray = CType(Cache("cacheExhibiciones"), System.Array)
            End If
        End If

        If objArray Is Nothing Then
            Cache.Remove("cacheExhibiciones")
            objArray = Benavides.CC.Data.clsExhibicionesAdicionales.strExhibicionesAdicionalesSucursal(intCompaniaId, intSucursalId, strCadenaConexion)
        End If

        Dim strResult As New StringBuilder()
        If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then
            Cache.Add("cacheExhibiciones", objArray, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, Nothing)

            'Genera la tabla a mostrar al usuario con resultados de consulta
            strResult.Append(strTablaConsultaExhibicionesHTML(objArray))

            'Tabla con contenido
            resultadoConsulta = "document.getElementById('divConsultaExhibicionesAdicionales').innerHTML;"
        Else
            'Tabla vacia sin resultados de consulta
            resultadoConsulta = "'Consulta sin resultados';"
        End If

        strResult.Append("<script language=""javascript"" type=""text/javascript"">")
        strResult.Append("parent.document.getElementById('tblResultados').innerHTML = " & resultadoConsulta)
        strResult.Append("</script>")

        Return strResult.ToString()

        Return String.Empty
    End Function

    Public Function strTablaConsultaExhibicionesHTML(ByVal objConsultaExhibiciones As Array) As String
        Dim strTablaExhibicionesHTML As StringBuilder
        Dim strConsultaExhibiciones As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim imgDetalle As String = Nothing
        Dim intPage As Integer

        Dim intTotal As Integer = objConsultaExhibiciones.Length '20

        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If

        strTablaExhibicionesHTML = New StringBuilder
        strTablaExhibicionesHTML.Append(Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objConsultaExhibiciones.Length, intPage, intTotal, String.Empty, Nothing))
        strTablaExhibicionesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        strTablaExhibicionesHTML.Append("<tr class='trtitulos'>")
        strTablaExhibicionesHTML.Append("<th class='rayita' align='center' valign='top'>Nombre de Exhibición</th>")
        strTablaExhibicionesHTML.Append("<th class='rayita' align='center' valign='top'>Tipo de Renta</th>")
        strTablaExhibicionesHTML.Append("<th class='rayita' align='center' valign='top'>Proveedor</th>")
        strTablaExhibicionesHTML.Append("<th class='rayita' align='center' valign='top'>Categoría</th>")
        strTablaExhibicionesHTML.Append("<th class='rayita' align='center' valign='top'>Planograma</th>")
        strTablaExhibicionesHTML.Append("<th class='rayita' align='center' valign='top'>CatMan</th>")
        strTablaExhibicionesHTML.Append("<th class='rayita' align='center' valign='top'>Fecha Inicio</th>")
        strTablaExhibicionesHTML.Append("<th class='rayita' align='center' valign='top'>Fecha Fin</th>")
        strTablaExhibicionesHTML.Append("<th class='rayita' align='center' valign='top'>Estatus</th>")
        strTablaExhibicionesHTML.Append("<th class='rayita' align='center' valign='top'>&nbsp;</th>")
        strTablaExhibicionesHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaExhibiciones.Length) Then
                Exit For
            End If

            strConsultaExhibiciones = CType(objConsultaExhibiciones.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            imgDetalle = "<img id=Edi" & strConsultaExhibiciones(0) & " height='17' src='../static/images/icono_lupa.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerificarAccion_onclick(this.id)' alt='Ver Detalle'>"

            strTablaExhibicionesHTML.Append("<tr id=" & strConsultaExhibiciones(0) & " onclick='javascript: fnDetalle_onclick(this.id)'>")

            ' Nombre de la exhibicion
            strTablaExhibicionesHTML.Append("<td id=NombreExhibicion" & strConsultaExhibiciones(0) & " align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(1)) & "</td>")
            ' Tipo de Renta
            strTablaExhibicionesHTML.Append("<td id=TipoRenta" & strConsultaExhibiciones(0) & " align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(2)) & "</td>")
            ' Proveedor
            strTablaExhibicionesHTML.Append("<td id=Proveedor" & strConsultaExhibiciones(0) & " align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(4)) & "</td>")
            ' Categoría
            strTablaExhibicionesHTML.Append("<td id=Categoria" & strConsultaExhibiciones(0) & " align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(5)) & "</td>")
            ' Planograma
            strTablaExhibicionesHTML.Append("<td id=Planograma" & strConsultaExhibiciones(0) & " align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(6)) & "</td>")
            ' CatMan
            strTablaExhibicionesHTML.Append("<td id=CatMan" & strConsultaExhibiciones(0) & " align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(7)) & "</td>")
            ' Fecha Inicio
            strTablaExhibicionesHTML.Append("<td id=FechaInicio" & strConsultaExhibiciones(0) & " align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaExhibiciones(8)) & "</td>")
            ' Fecha Fin
            strTablaExhibicionesHTML.Append("<td id=FechaFin" & strConsultaExhibiciones(0) & " align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaExhibiciones(9)) & "</td>")
            ' Estatus
            strTablaExhibicionesHTML.Append("<td id=Estatus" & strConsultaExhibiciones(0) & " align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(10)) & "</td>")
            ' Accion
            strTablaExhibicionesHTML.Append("<td id=Accion" & strConsultaExhibiciones(0) & " align=center class=" & strColorRegistro & ">" & imgDetalle & "</td>")
            strTablaExhibicionesHTML.Append("</tr>")

        Next

        strTablaExhibicionesHTML.Append("</tr>")
        strTablaExhibicionesHTML.Append("</table>")
        strTablaExhibicionesHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaExhibicionesHTML = strTablaExhibicionesHTML.ToString

    End Function
End Class