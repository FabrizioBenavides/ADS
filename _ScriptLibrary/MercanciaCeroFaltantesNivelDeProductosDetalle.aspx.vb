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
Imports System.Collections


Public Class MercanciaCeroFaltantesNivelDeProductosDetalle
    Inherits System.Web.UI.Page

    Private strmCodigoId As String
    Private strmNombre As String
    Private strmCategoria As String
    Private strmAbasto As String
    Private strmZonaOperativaId As String
    Private strmDireccionOperativaId As String
    Private intZonaOperativaId As String
    Dim strmRecordBrowserHTML As String

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
    ' Name       : LlenarControlZonaOpertaiva
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboZonaOperativa
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlZonaOpertaiva() As String
        If strCmd.Length <> 0 Then
            Return String.Empty
        End If

        Dim objZonas As Array = Benavides.CC.Data.clsCeroFaltante.strObtenerZonaOperativa(intSucursalId, intCompaniaId, strCadenaConexion)
        Dim strZonas As New StringBuilder

        If Not objZonas Is Nothing Then
            Dim i As Integer

            Dim objZonaItem As SortedList = Nothing

            For i = 0 To objZonas.Length - 1
                objZonaItem = CType(objZonas.GetValue(i), SortedList)

                If strmDireccionOperativaId = objZonaItem("intDireccionOperativaId").ToString() AndAlso strmZonaOperativaId = objZonaItem("intZonaOperativaId").ToString() Then
                    strZonas.AppendFormat("<option value=""{0}"" SELECTED>{1}</option>", objZonaItem("ID"), objZonaItem("strZonaOperativaNombre"))
                Else
                    strZonas.AppendFormat("<option value=""{0}"">{1}</option>", objZonaItem("ID"), objZonaItem("strZonaOperativaNombre"))
                End If
            Next
        End If

        Return strZonas.ToString()
    End Function

    '====================================================================
    ' Name       : strCodigoId
    ' Description: Codigo del articulo
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCodigoId() As String
        Get
            If Not IsNothing(Request.QueryString("intArticuloId")) Then
                'Si es parametro de la pantalla anterior
                Return Request.QueryString("intArticuloId")
            Else
                Return Nothing
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strNombre
    ' Description: Nombre o descripcion del articulo.
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strNombre() As String
        Get
            Return strmNombre
        End Get
        Set(ByVal strValue As String)
            strmNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCategoria
    ' Description: Categoria
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strCategoria() As String
        Get
            Return strmCategoria
        End Get
        Set(ByVal strValue As String)
            strmCategoria = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strAbasto
    ' Description: Abasto
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strAbasto() As String
        Get
            Return strmAbasto
        End Get
        Set(ByVal strValue As String)
            strmAbasto = strValue
        End Set
    End Property

    Protected ReadOnly Property strZonaOperativa() As String
        Get
            Return intZonaOperativaId
        End Get
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim objArray As Array = Nothing

        If Not IsNothing(strCodigoId) AndAlso CInt(strCodigoId) > 0 Then
            objArray = Benavides.CC.Data.clsCeroFaltante.strFaltanteCeroDetalleArticulo(intCompaniaId, intSucursalId, CInt(strCodigoId), strCadenaConexion)

            If IsArray(objArray) AndAlso objArray.Length > 0 Then


                strmNombre = CStr(CType(objArray.GetValue(0), Array).GetValue(1))
                strmCategoria = CStr(CType(objArray.GetValue(0), Array).GetValue(2))
                strmAbasto = CStr(CType(objArray.GetValue(0), Array).GetValue(3))
                strmZonaOperativaId = CStr(CType(objArray.GetValue(0), Array).GetValue(4))
                strmDireccionOperativaId = CStr(CType(objArray.GetValue(0), Array).GetValue(5))
            End If
        End If

        'Combo Zona Operativa

        If Not Request.Form("cboZonaOperativa") Is Nothing Then
            Dim strZonaOperativa As String() = Request.Form("cboZonaOperativa").ToString().Split("|".ToCharArray())

            If strZonaOperativa.Length > 1 Then
                strmZonaOperativaId = strZonaOperativa(1)
                strmDireccionOperativaId = strZonaOperativa(0)
            End If
        End If

        Dim strRecordBrowserImpresion As String = ""
        Const strComitasDobles As String = """"

        Select Case strCmd

            Case "Imprimir"

                Dim strHTML As New StringBuilder

                'Resultados a mostrar en pantalla
                Dim objDataArrayCeroFaltantes As Array = Benavides.CC.Data.clsCeroFaltante.strFaltanteCeroZonaOperativa(intCompaniaId, intSucursalId, CInt(strmDireccionOperativaId), CInt(strmZonaOperativaId), CInt(strCodigoId), strCadenaConexion)

                If IsArray(objDataArrayCeroFaltantes) AndAlso objDataArrayCeroFaltantes.Length > 0 Then

                    'Se formatea la informacion.  
                    strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strImpresionCeroFaltantes(objDataArrayCeroFaltantes))

                    'Se ennvia a impresion.
                    strHTML.Append("<script language='Javascript'>parent.fnImprimir( " & _
                    strComitasDobles & strRecordBrowserImpresion.ToString & strComitasDobles & _
                    "); </script>")
                    Response.Write(strHTML.ToString)
                    Response.End()

                End If

            Case "Consultar"
                '
        End Select

    End Sub


    '====================================================================
    ' Name       : strImpresionCeroFaltantes
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImpresionCeroFaltantes(ByVal objDataArrayCeroFaltantes As Array) As String

        Dim strImpresionCeroFaltantesHTML As StringBuilder = New StringBuilder
        Dim strRegistroCeroFaltantes As String()
        Dim strclase As String = ""
        Dim intRenglonesxPagina As Integer = 58
        Dim stock As String = Nothing


        If IsArray(objDataArrayCeroFaltantes) AndAlso (objDataArrayCeroFaltantes.Length > 0) Then

            Dim intTotalRenglones As Integer = objDataArrayCeroFaltantes.Length
            Dim intTotalPaginas As Integer = 0

            Dim intPagina As Integer = 0
            Dim intRenglon As Integer = 0
            Dim intContadorRenglon As Integer = 0

            intTotalPaginas = CInt(intTotalRenglones \ intRenglonesxPagina)

            If intTotalRenglones Mod intRenglonesxPagina > 0 Then
                intTotalPaginas += 1
            End If

            intRenglon = 0
            intPagina = 0
            intContadorRenglon = 0

            For Each strRegistroCeroFaltantes In objDataArrayCeroFaltantes

                intRenglon += 1
                intContadorRenglon += 1

                If intRenglon = 1 Then
                    intPagina += 1

                    If intPagina > 1 Then
                        strImpresionCeroFaltantesHTML.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")

                    End If

                    strImpresionCeroFaltantesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    strImpresionCeroFaltantesHTML.Append(strImprimeEncabezado(intPagina.ToString, intTotalPaginas.ToString))
                End If

                If ((intRenglon Mod 2) = 0) Then
                    strclase = "tdtxtImpresionNormal"
                Else
                    strclase = "tdtxtImpresionBold"
                End If

                'Stock
                If strRegistroCeroFaltantes(3) = "0" Then
                    stock = "SP"
                ElseIf strRegistroCeroFaltantes(4) = "SM" Then
                    stock = "SM"
                Else
                    stock = strRegistroCeroFaltantes(2)
                End If


                strImpresionCeroFaltantesHTML.Append("<tr>")
                ' Sucursal
                strImpresionCeroFaltantesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroCeroFaltantes(0)).ToString & "</td>")
                ' Nombre
                strImpresionCeroFaltantesHTML.Append("<td width='65%' align='left' class='" & strclase & "' nowrap >" & clsCommons.strFormatearDescripcion(strRegistroCeroFaltantes(1)).ToString & "</td>")
                ' Stock
                strImpresionCeroFaltantesHTML.Append("<td width='25%' align='center' class='" & strclase & "'>" & stock & "</td>")

                strImpresionCeroFaltantesHTML.Append("</tr>")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionCeroFaltantesHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next

        End If

        Return strImpresionCeroFaltantesHTML.ToString()

    End Function

    Private Function strImprimeEncabezado(ByVal strHojaActual As String, ByVal strHojaFinal As String) As String

        Dim strHtmlEncabezado As StringBuilder

        strHtmlEncabezado = New StringBuilder

        'Encabezado principal
        strHtmlEncabezado.Append("<tr>")
        strHtmlEncabezado.Append("<td colspan='3'>")

        strHtmlEncabezado.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='3'  class='tdtxtBold'>Cero Faltantes Detalle </th>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='20%' align='left'   class='tdtxtBold'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th width='60%' align='center' class='tdtxtBold' nowrap>" & strCentroLogisticoId & " - " & strSucursalNombre & " (" & intCompaniaId.ToString & intSucursalId.ToString("000") & ")" & "</th>")
        strHtmlEncabezado.Append("<th width='20%' align='right'  class='tdtxtBold'>HOJA " & strHojaActual & " / " & strHojaFinal & " </th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strHtmlEncabezado.Append("</td>")
        strHtmlEncabezado.Append("</tr>")

        'Encabezado titulos
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Sucursal</th>")
        strHtmlEncabezado.Append("<th width='65%' class='tdtxtBold' align='center' nowrap>Nombre</th>")
        strHtmlEncabezado.Append("<th width='25%' class='tdtxtBold' align='center' nowrap>Stock</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' class='rayita' colspan='3'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        strImprimeEncabezado = strHtmlEncabezado.ToString

    End Function

    Public Function strTablaConsultaCeroFaltantes() As String
        Dim objArray As System.Array = Nothing
        Dim strResult As New StringBuilder()

        strmRecordBrowserHTML = String.Empty

        objArray = Benavides.CC.Data.clsCeroFaltante.strFaltanteCeroZonaOperativa(intCompaniaId, intSucursalId, CInt(strmDireccionOperativaId), CInt(strmZonaOperativaId), CInt(strCodigoId), strCadenaConexion)

        If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then
            strResult.Append(strTablaConsultaCeroFaltantesHTML(objArray))
        End If

        strResult.Append("<script language=""javascript"" type=""text/javascript"">")
        strResult.Append("parent.document.getElementById('tblCeroFaltantes').innerHTML = document.getElementById('divConsultaCeroFaltantes').innerHTML;")
        strResult.Append("</script>")

        Return strResult.ToString()
    End Function

    Public Function strTablaConsultaCeroFaltantesHTML(ByVal objConsultaCeroFaltantes As Array) As String
        Dim strTablaCeroFaltantesHTML As StringBuilder
        Dim strConsultaCeroFaltantes As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim intPage As Integer
        Dim intTotal As Integer = 10
        Dim stock As String = Nothing

        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If

        strTablaCeroFaltantesHTML = New StringBuilder

        strTablaCeroFaltantesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strTablaCeroFaltantesHTML.Append("<tr class='trtitulos'>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Sucursal</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Nombre</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Stock</th>")
        strTablaCeroFaltantesHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For Each strConsultaCeroFaltantes In objConsultaCeroFaltantes
            intContador += 1

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            'Stock
            If strConsultaCeroFaltantes(3) = "0" Then
                stock = "SP"
            ElseIf strConsultaCeroFaltantes(4) = "SM" Then
                stock = "SM"
            Else
                stock = strConsultaCeroFaltantes(2)
            End If

            strTablaCeroFaltantesHTML.Append("<tr>")
            ' Division
            strTablaCeroFaltantesHTML.Append("<td id=Division" & intContador & " align=center class=" & strColorRegistro & ">" & strConsultaCeroFaltantes(0) & "</td>")
            ' Descripcion
            strTablaCeroFaltantesHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaCeroFaltantes(1)) & "</td>")
            ' Stock
            strTablaCeroFaltantesHTML.Append("<td align=center class=" & strColorRegistro & ">" & stock & "</td>")
            strTablaCeroFaltantesHTML.Append("</tr>")

        Next

        strTablaCeroFaltantesHTML.Append("</tr>")
        strTablaCeroFaltantesHTML.Append("</table>")
        strTablaCeroFaltantesHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaCeroFaltantesHTML = strTablaCeroFaltantesHTML.ToString

    End Function


End Class