
Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Benavides.POSAdmin.Commons.clsCommons.clsMSMQ
Imports Benavides.CC.Data.clsPromociones
Imports System.Text
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports System.IO
Imports System.Web.Caching

Public Class SistemaConsultarPromocionesDetalleSucursales
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
    ' Name       : strCentroLogisticoId
    ' Description: Promocion a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCentroLogisticoId() As String
        Get
            'NOTA: Esta pantalla la invoca SistemaConsultarPromociones.aspx
            'no envia este parametro pero deja preparada en caso de necesitarlo.

            Return String.Empty
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

    Public Function strTablaConsultaSucursales() As String

        Dim objArray As System.Array = Nothing

        If (Request.QueryString("pager") = "true") Then
            If Not Cache("cacheSucursales") Is Nothing Then
                objArray = CType(Cache("cacheSucursales"), System.Array)
            End If
        End If

        If objArray Is Nothing Then
            Cache.Remove("cacheSucursales")

            If intTipoPromocionId = 1 Then

                'Ofertas
                objArray = Benavides.CC.Data.clsConsultarPromociones.strConsultarSucursalesOfertas(intPromocionId, strCentroLogisticoId, strConnectionString)
            ElseIf intTipoPromocionId = 2 Then

                'Promociones
                objArray = Benavides.CC.Data.clsConsultarPromociones.strConsultarSucursalesPromociones(intPromocionId, strCentroLogisticoId, strConnectionString)
            ElseIf intTipoPromocionId = 3 Then

                'Cupones
                objArray = Benavides.CC.Data.clsConsultarPromociones.strConsultarSucursalesCupones(intPromocionId, strCentroLogisticoId, strConnectionString)
            Else
                'Todas
            End If
        End If

        Dim strResult As New StringBuilder
        If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then
            Cache.Add("cacheSucursales", objArray, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, Nothing)

            strResult.Append(strTablaConsultaSucursalesHTML(objArray))
        End If

        strResult.Append("<script language=""javascript"" type=""text/javascript"">")
        strResult.Append("parent.document.getElementById('tblSucursales').innerHTML = document.getElementById('divConsultaSucursales').innerHTML;")
        strResult.Append("</script>")

        Return strResult.ToString()
        'End If

        Return String.Empty
    End Function

    Public Function strTablaConsultaSucursalesHTML(ByVal objConsultaSucursales As Array) As String

        'Variables
        Dim strTablaSucursalesHTML As StringBuilder
        Dim strConsultaSucursales As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer

        Dim intPage As Integer
        Dim intTotal As Integer = 200

        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If


        strTablaSucursalesHTML = New StringBuilder
        'strTablaSucursalesHTML.Append("<span class='txsubtitulo'> </span> ")
        strTablaSucursalesHTML.Append(Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objConsultaSucursales.Length, intPage, intTotal, String.Empty, Nothing))

        strTablaSucursalesHTML.Append("<table style='width:100%;' border='0' cellpadding='0' cellspacing='0'>")
        strTablaSucursalesHTML.Append("<tr class='trtitulos'>")
        strTablaSucursalesHTML.Append("<th width='20%' align=center class='rayita' align='left' valign='top'>Código</th>")
        strTablaSucursalesHTML.Append("<th width='60%' align=center class='rayita' align='left' valign='top'>Nombre</th>")
        strTablaSucursalesHTML.Append("<th width='20%' align=center class='rayita' align='left' valign='top'>CIA/SUC</th>")
        strTablaSucursalesHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaSucursales.Length) Then
                Exit For
            End If

            strConsultaSucursales = CType(objConsultaSucursales.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strTablaSucursalesHTML.Append("<tr>")

            ' intSucursalId
            strTablaSucursalesHTML.Append("<td width='08%' id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & " align='center'>" & strConsultaSucursales(1) & "</td>")
            ' strSucursalNombre
            strTablaSucursalesHTML.Append("<td width='20%' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaSucursales(2)) & "</td>")
            ' Tipo de Promocion
            strTablaSucursalesHTML.Append("<td width='08%' class=" & strColorRegistro & " align='center'>" & clsCommons.strFormatearDescripcion(strConsultaSucursales(4)) & "</td>")

            strTablaSucursalesHTML.Append("</tr>")

        Next
        strTablaSucursalesHTML.Append("</tr>")
        strTablaSucursalesHTML.Append("</table>")
        strTablaSucursalesHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaSucursalesHTML = strTablaSucursalesHTML.ToString 'clsCommons.strGenerateJavascriptString(strTablaSucursalesHTML.ToString)
    End Function
End Class
