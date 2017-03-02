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

Public Class MercanciaCeroFaltantesNivelDeProductos
    Inherits System.Web.UI.Page

    Private intDivisionArticulosId As Integer
    Private strCategoriaOperativaId As String

    Private intmArticuloInternoId As String = Nothing
    Private strmArticuloInternoDescripcion As String = Nothing
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

        intDivisionArticulosId = GetPageParameter("cboDivisionArticulos", 0)
        strCategoriaOperativaId = GetPageParameter("cboCategoriaArticulos", "")

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
    ' Name       : LlenarControlDivisionArticulos
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboDivisionArticulos
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlDivisionArticulos() As String
        Return CreateJavascriptComboBoxOptions("cboDivisionArticulos", CStr(intDivisionArticulosId), Benavides.CC.Data.clstblDivisionArticulos.strBuscar(0, "", "", #1/1/2000#, "", 0, 0, strCadenaConexion), "intDivisionArticulosId", "strDivisionArticulosNombre", 1)
    End Function

    '====================================================================
    ' Name       : LlenarControlCategoriaArticulos
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboCategoriaArticulos
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlCategoriaArticulos() As String

        Dim returnedJavascript As String = String.Empty

        returnedJavascript = CreateJavascriptComboBoxOptions("cboCategoriaArticulos", strCategoriaOperativaId, Benavides.CC.Data.clsCeroFaltante.strObtenerCategoriaOperativa(strCadenaConexion), "strCategoriaOperativaId", "strCategoriaOperativaNombre", 1)

        Return returnedJavascript

    End Function

    '====================================================================
    ' Name       : intArticuloCapturadoId
    ' Description: Articulo a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intArticuloCapturadoId() As String
        Get
            If Not Trim(Request.Form("txtArticuloId")) = Nothing Then
                Return Request.Form("txtArticuloId")
            Else
                Return Nothing
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intArticuloInternoId
    ' Description: Codigo de Articulo Interno
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intArticuloInternoId() As String
        Get
            Return intmArticuloInternoId
        End Get
        Set(ByVal Value As String)
            intmArticuloInternoId = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strArticuloInternoDescripcion
    ' Description: Codigo de Articulo Interno
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strArticuloInternoDescripcion() As String
        Get
            Return strmArticuloInternoDescripcion
        End Get
        Set(ByVal Value As String)
            strmArticuloInternoDescripcion = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strErrorArticuloId
    ' Description: Numero de Emisor Nuevo
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strErrorArticuloId() As String
        Get
            Dim strError As String = "0"

            If Len(intArticuloCapturadoId) > 0 Then
                If IsNumeric(intArticuloCapturadoId) Then
                    If CDbl(intArticuloCapturadoId) > 0 Then
                        If Len(strBuscarDescripcionArticuloId(intArticuloCapturadoId)) = 0 Then
                            strError = "1"
                        End If
                    End If
                End If
            End If
            Return strError
        End Get
    End Property

    '====================================================================
    ' Name       : strBuscarDescripcionArticuloId
    ' Description: Consulta la descripcion del Articulo
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Function strBuscarDescripcionArticuloId(ByVal intNumeroArticuloId As String) As String
        Dim objDescripcionArt As Array = Nothing
        Dim strDescripcionArt As String() = Nothing
        Dim strNombreArticulo As String = Nothing


        If CDbl(intNumeroArticuloId) > 0 Then

            objDescripcionArt = clsConcentrador.clsSucursal.strBuscarArticulo(intCompaniaId, intSucursalId, intNumeroArticuloId, 0, 0, strCadenaConexion)

            If IsArray(objDescripcionArt) AndAlso objDescripcionArt.Length > 0 Then
                ' Obtenemos la descripcion del Articulo 
                strDescripcionArt = DirectCast(objDescripcionArt.GetValue(0), String())
                intArticuloInternoId = strDescripcionArt(0)

                If strDescripcionArt(1).IndexOf("'") > 0 Then
                    strArticuloInternoDescripcion = clsCommons.strFormatearDescripcion(strDescripcionArt(5))
                    strNombreArticulo = clsCommons.strFormatearDescripcion(strDescripcionArt(5))
                Else
                    strArticuloInternoDescripcion = clsCommons.strGenerateJavascriptString(strDescripcionArt(5))
                    strNombreArticulo = clsCommons.strGenerateJavascriptString(strDescripcionArt(5))
                    strmArticuloInternoDescripcion = strNombreArticulo
                End If

            End If
        End If

        Return strNombreArticulo

    End Function

    Public Function strTablaConsultaCeroFaltantesHTML(ByVal objConsultaCeroFaltantes As Array) As String
        Dim strTablaCeroFaltantesHTML As StringBuilder
        Dim strConsultaCeroFaltantes As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim imgEditar As String = Nothing
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
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>División</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Articulo</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Descripción</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Cat</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Abasto</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Stock</th>")
        'strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Factor %</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Stock CEL</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Transito</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Acción</th>")
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

            imgEditar = "<img id=Edi" & strConsultaCeroFaltantes(1) & " height='17' src='../static/images/icono_lupa.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerificarAccion_onclick(this.id)'>"

            'Stock
            If strConsultaCeroFaltantes(10) = "0" Then
                stock = "SP"
            ElseIf strConsultaCeroFaltantes(9) = "SM" Then
                stock = "SM"
            Else
                stock = strConsultaCeroFaltantes(5)
            End If

            strTablaCeroFaltantesHTML.Append("<tr>")

            ' Division
            strTablaCeroFaltantesHTML.Append("<td id=Division" & intContador & " align=center class=" & strColorRegistro & ">" & strConsultaCeroFaltantes(0) & "</td>")
            ' Articulo
            strTablaCeroFaltantesHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaCeroFaltantes(1)) & "</td>")
            ' Descripcion
            strTablaCeroFaltantesHTML.Append("<td align=left class=" & strColorRegistro & ">" & strConsultaCeroFaltantes(2) & "</td>")
            ' Cat
            strTablaCeroFaltantesHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaCeroFaltantes(3) & "</td>")
            ' Abasto
            strTablaCeroFaltantesHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaCeroFaltantes(4) & "</td>")
            ' Stock
            strTablaCeroFaltantesHTML.Append("<td align=center class=" & strColorRegistro & ">" & stock & "</td>")
            ' Factor %
            'strTablaCeroFaltantesHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaCeroFaltantes(6) & "</td>")
            ' Stock CEL
            strTablaCeroFaltantesHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaCeroFaltantes(7) & "</td>")
            ' Transito
            strTablaCeroFaltantesHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaCeroFaltantes(8) & "</td>")
            ' Accion
            strTablaCeroFaltantesHTML.Append("<td align=center class=" & strColorRegistro & ">" & imgEditar & "</td>")
            strTablaCeroFaltantesHTML.Append("</tr>")

        Next

        strTablaCeroFaltantesHTML.Append("</tr>")
        strTablaCeroFaltantesHTML.Append("</table>")
        strTablaCeroFaltantesHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaCeroFaltantesHTML = strTablaCeroFaltantesHTML.ToString


    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)


        Dim strRecordBrowserImpresion As String = ""
        Const strComitasDobles As String = """"

        Select Case strCmd

            Case "Imprimir"

                Dim strHTML As New StringBuilder
                Dim intArticuloId As Integer
                Dim intStock As Integer
                Dim intStockFiltro As Integer


                'Articulo
                If Not intArticuloCapturadoId = Nothing Then
                    intArticuloId = CInt(intArticuloCapturadoId)
                Else
                    intArticuloId = 0
                End If

                intStockFiltro = CInt(Request.Form("cmdFiltroStock"))

                'Valor de parametro "intStockFiltro" que es el valor del filtro.
                If intStockFiltro = 1 And Not Request.Form("txtMayorA") = Nothing Then
                    intStock = CInt(Request.Form("txtMayorA"))
                ElseIf intStockFiltro = 2 And Not Request.Form("txtMenorA") = Nothing Then
                    intStock = CInt(Request.Form("txtMenorA"))
                ElseIf intStockFiltro = 3 And Not Request.Form("txtIgualA") = Nothing Then
                    intStock = CInt(Request.Form("txtIgualA"))
                Else
                    intStock = 0
                End If

                'Resultados a mostrar en pantalla
                Dim objDataArrayCeroFaltantes As Array = Benavides.CC.Data.clsCeroFaltante.strFaltanteCeroArticulos(intSucursalId, intCompaniaId, intArticuloId, intStockFiltro, intStock, intDivisionArticulosId, strCategoriaOperativaId, strCadenaConexion)

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
                If strRegistroCeroFaltantes(10) = "0" Then
                    stock = "SP"
                ElseIf strRegistroCeroFaltantes(9) = "SM" Then
                    stock = "SM"
                Else
                    stock = strRegistroCeroFaltantes(5)
                End If

                strImpresionCeroFaltantesHTML.Append("<tr>")
                ' Division
                strImpresionCeroFaltantesHTML.Append("<td width='15%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroCeroFaltantes(0)).ToString & "</td>")
                ' Articulo
                strImpresionCeroFaltantesHTML.Append("<td width='10%' align='center' class='" & strclase & "' nowrap >" & strRegistroCeroFaltantes(1) & "</td>")
                ' Descripcion
                strImpresionCeroFaltantesHTML.Append("<td width='25%' align='left' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroCeroFaltantes(2)).ToString & "</td>")
                ' Cat
                strImpresionCeroFaltantesHTML.Append("<td width='8%' align='center' class='" & strclase & "' >" & strRegistroCeroFaltantes(3) & "</td>")
                ' Abasto
                strImpresionCeroFaltantesHTML.Append("<td width='8%' align='center' class='" & strclase & "' >" & strRegistroCeroFaltantes(4) & "</td>")
                ' Stock
                strImpresionCeroFaltantesHTML.Append("<td width='8%' align='center' class='" & strclase & "' >" & stock & "</td>")
                ' Factor %
                'strImpresionCeroFaltantesHTML.Append("<td width='8%' align='center' class='" & strclase & "' >" & strRegistroCeroFaltantes(6) & "</td>")
                ' Stock CEL
                strImpresionCeroFaltantesHTML.Append("<td width='8%' align='center' class='" & strclase & "' >" & strRegistroCeroFaltantes(7) & "</td>")
                ' Transito
                strImpresionCeroFaltantesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & strRegistroCeroFaltantes(8) & "</td>")

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
        strHtmlEncabezado.Append("<td colspan='8'>")

        strHtmlEncabezado.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='9'  class='tdtxtBold'>Cero Faltantes Nivel Producto </th>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='15%' align='left'   class='tdtxtBold'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th width='67%' align='center' class='tdtxtBold' nowrap colspan='6'>" & strCentroLogisticoId & " - " & strSucursalNombre & " (" & intCompaniaId.ToString & intSucursalId.ToString("000") & ")" & "</th>")
        strHtmlEncabezado.Append("<th width='18%' align='right'  class='tdtxtBold' nowrap colspan='2'>HOJA " & strHojaActual & " / " & strHojaFinal & " </th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strHtmlEncabezado.Append("</td>")
        strHtmlEncabezado.Append("</tr>")

        'Encabezado titulos
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='15%' class='tdtxtBold' align='center' nowrap>Division</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Articulo</th>")
        strHtmlEncabezado.Append("<th width='25%' class='tdtxtBold' align='center' nowrap>Descripcion</th>")
        strHtmlEncabezado.Append("<th width='8%' class='tdtxtBold' align='center' nowrap>Cat</th>")
        strHtmlEncabezado.Append("<th width='8%' class='tdtxtBold' align='center' nowrap>Abasto</th>")
        strHtmlEncabezado.Append("<th width='8%' class='tdtxtBold' align='center' nowrap>Stock</th>")
        'strHtmlEncabezado.Append("<th width='8%' class='tdtxtBold' align='center' nowrap>Factor %</th>")
        strHtmlEncabezado.Append("<th width='8%' class='tdtxtBold' align='center' nowrap>Stock CEL</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Transito</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' class='rayita' colspan='9'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        strImprimeEncabezado = strHtmlEncabezado.ToString

    End Function

    Public Function strTablaConsultaCodigoArticulo() As String

        strmRecordBrowserHTML = String.Empty
        If (strCmd = "cmdConsultarPorCodigo") And (Not IsNothing(intArticuloCapturadoId)) Then

            'Variables
            Dim objArray As System.Array = Nothing


            'Datos de la consulta
            objArray = clsConcentrador.clsSucursal.strBuscarArticulo(intCompaniaId, intSucursalId, intArticuloCapturadoId, 0, 0, strCadenaConexion)


            If IsArray(objArray) AndAlso objArray.Length > 0 Then
                Dim strResult As New StringBuilder

                strResult.Append("<script language=""javascript"" type=""text/javascript"">")
                strResult.AppendFormat("parent.document.getElementById('txtArticuloDescripcion').value = '{0}';", CType(objArray.GetValue(0), Array).GetValue(5))
                strResult.Append("</script>")

                Return strResult.ToString()
            End If
        End If

        Return String.Empty
    End Function

    Public Function strTablaConsultaResumenCeroFaltantes() As String
        Dim objArray As System.Array = Nothing
        Dim intArticuloId As Integer
        Dim intStock As Integer
        Dim intStockFiltro As Integer
        Dim resultadoConsulta As String = String.Empty

        strmRecordBrowserHTML = String.Empty

        'Articulo
        If Not intArticuloCapturadoId = Nothing Then
            intArticuloId = CInt(intArticuloCapturadoId)
        Else
            intArticuloId = 0
        End If

        intStockFiltro = CInt(Request.Form("cmdFiltroStock"))

        'Valor de parametro "intStockFiltro" que es el valor del filtro.
        If intStockFiltro = 1 And Not Request.Form("txtMayorA") = Nothing Then
            intStock = CInt(Request.Form("txtMayorA"))
        ElseIf intStockFiltro = 2 And Not Request.Form("txtMenorA") = Nothing Then
            intStock = CInt(Request.Form("txtMenorA"))
        ElseIf intStockFiltro = 3 And Not Request.Form("txtIgualA") = Nothing Then
            intStock = CInt(Request.Form("txtIgualA"))
        Else
            intStock = 0
        End If

        If (strCmd = "cmdConsultar") Then

            objArray = Benavides.CC.Data.clsCeroFaltante.strFaltanteCeroArticulos(intSucursalId, intCompaniaId, intArticuloId, intStockFiltro, intStock, intDivisionArticulosId, strCategoriaOperativaId, strCadenaConexion)
            
            Dim strResult As New StringBuilder
            If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then

                'Genera la tabla a mostrar al usuario con resultados de consulta
                strResult.Append(strTablaConsultaCeroFaltantesHTML(objArray))

                'Tabla con contenido
                resultadoConsulta = "document.getElementById('divConsultaCeroFaltantes').innerHTML;"
            Else
                'Tabla vacia sin resultados de consulta
                resultadoConsulta = "'Consulta sin resultados';"
            End If

            strResult.Append("<script language=""javascript"" type=""text/javascript"">")
            strResult.Append("parent.document.getElementById('tblCeroFaltantes').innerHTML = " & resultadoConsulta)
            strResult.Append("</script>")

            Return strResult.ToString()
        End If

        Return String.Empty
    End Function



End Class