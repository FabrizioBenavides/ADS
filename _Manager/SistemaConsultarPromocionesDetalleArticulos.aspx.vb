
Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Benavides.POSAdmin.Commons.clsCommons.clsMSMQ
Imports Benavides.CC.Data.clsPromociones
Imports System.Text
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports System.IO
Imports System.Web.Caching

Public Class SistemaConsultarPromocionesDetalleArticulos
    Inherits System.Web.UI.Page

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
    End Sub

#End Region


    'Dim strmRecordBrowserHTML As String

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
    ' Name       : intPromocionId
    ' Description: Leer el id de la promocion relacionada. 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intPromocionId() As Integer
        Get
            If Not IsNothing(Request.QueryString("strPromocionId")) AndAlso IsNumeric(Request.QueryString("strPromocionId")) Then
                Return CInt(Request.QueryString("strPromocionId"))
            ElseIf Not IsNothing(Request.Form("hdnPromocionId")) AndAlso IsNumeric(Request.Form("hdnPromocionId")) Then
                Return CInt(Request.Form("hdnPromocionId").Trim())
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intTipoPromocionId
    ' Description: Leer el tipo de promocion a buscar
    ' Valores    : 1 = Ofertas, 2 = Promociones, 3 = Cupones
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTipoPromocionId() As Integer
        Get
            If Not IsNothing(Request.QueryString("strTipoPromocionId")) AndAlso IsNumeric(Request.QueryString("strTipoPromocionId")) Then
                Return CInt(Request.QueryString("strTipoPromocionId"))
            ElseIf Not IsNothing(Request.Form("hdnTipoPromocionId")) AndAlso IsNumeric(Request.Form("hdnTipoPromocionId")) Then
                Return CInt(Request.Form("hdnTipoPromocionId").Trim())
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intTipoDetalleId
    ' Description: Leer el tipo de detalle a buscar
    ' Valores     : 1 = Articulos, 2 = Sucursales
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTipoDetalleId() As Integer
        Get
            If Not IsNothing(Request.QueryString("strTipoDetalleId")) AndAlso IsNumeric(Request.QueryString("strTipoDetalleId")) Then
                Return CInt(Request.QueryString("strTipoDetalleId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intArticuloId
    ' Description: Promocion a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intArticuloId() As String
        Get
            'NOTA: Esta pantalla la invoca SistemaConsultarPromociones.aspx
            'no envia este parametro pero deja preparada en caso de necesitarlo.

            Return "0"
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If
    End Sub

    Public Function strTablaConsultaArticulos() As String

        Dim objArray As System.Array = Nothing

        If (Request.QueryString("pager") = "true") Then
            If Not Cache("cacheArticulos") Is Nothing Then
                objArray = CType(Cache("cacheArticulos"), System.Array)
            End If
        End If

        If objArray Is Nothing Then
            Cache.Remove("cacheArticulos")

            If intTipoPromocionId = 1 Then

                'Ofertas
                objArray = Benavides.CC.Data.clsConsultarPromociones.strConsultarArticulosOfertas(intPromocionId, CInt(intArticuloId), strConnectionString)
            ElseIf intTipoPromocionId = 2 Then

                'Promociones
                objArray = Benavides.CC.Data.clsConsultarPromociones.strConsultarArticulosPromociones(intPromocionId, CInt(intArticuloId), strConnectionString)
            ElseIf intTipoPromocionId = 3 Then

                'Cupones
                objArray = Benavides.CC.Data.clsConsultarPromociones.strConsultarArticulosCupones(intPromocionId, CInt(intArticuloId), strConnectionString)
            Else
                'Todas
            End If
        End If

        Dim strResult As New StringBuilder
        If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then
            Cache.Add("cacheArticulos", objArray, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, Nothing)

            strResult.Append(strTablaConsultaArticulosHTML(objArray))
        End If

        strResult.Append("<script language=""javascript"" type=""text/javascript"">")
        strResult.Append("parent.document.getElementById('tblArticulos').innerHTML = document.getElementById('divConsultaArticulos').innerHTML;")
        strResult.Append("</script>")

        Return strResult.ToString()

    End Function

    Public Function strTablaConsultaArticulosHTML(ByVal objConsultaArticulos As Array) As String

        'Variables
        Dim strTablaArticulosHTML As StringBuilder
        Dim strConsultaArticulos As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim intPage As Integer
        Dim intTotal As Integer = 50

        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If


        strTablaArticulosHTML = New StringBuilder
        'strTablaArticulosHTML.Append("<span class='txsubtitulo'> </span> ")
        strTablaArticulosHTML.Append(Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objConsultaArticulos.Length, intPage, intTotal, String.Empty, Nothing))

        strTablaArticulosHTML.Append("<table style='width:100%;' border='0' cellpadding='0' cellspacing='0'>")
        strTablaArticulosHTML.Append("<tr class='trtitulos'>")
        strTablaArticulosHTML.Append("<th width='20%' align=center class='rayita' align='left' valign='top'>Código</th>")
        strTablaArticulosHTML.Append("<th width='60%' align=center class='rayita' align='left' valign='top'>Descripción</th>")
        'strTablaArticulosHTML.Append("<th width='20%' align=center class='rayita' align='left' valign='top'>Tipo de Promocion</th>")
        strTablaArticulosHTML.Append("<th width='20%' align=center class='rayita' align='left' valign='top'>Función Producto</th>")
        strTablaArticulosHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaArticulos.Length) Then
                Exit For
            End If

            strConsultaArticulos = CType(objConsultaArticulos.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strTablaArticulosHTML.Append("<tr>")

            ' intArticuloId
            strTablaArticulosHTML.Append("<td width='08%' id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & " align='center'>" & strConsultaArticulos(0) & "</td>")
            ' strArticuloDescripcion
            strTablaArticulosHTML.Append("<td width='20%' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaArticulos(1)) & "</td>")
            ' Tipo de Promocion
            strTablaArticulosHTML.Append("<td width='08%' class=" & strColorRegistro & " align='center'>" & clsCommons.strFormatearDescripcion(strConsultaArticulos(3)) & "</td>")
            strTablaArticulosHTML.Append("</tr>")

        Next
        strTablaArticulosHTML.Append("</tr>")
        strTablaArticulosHTML.Append("</table>")
        strTablaArticulosHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaArticulosHTML = strTablaArticulosHTML.ToString 'clsCommons.strGenerateJavascriptString(strTablaArticulosHTML.ToString)
    End Function
End Class
