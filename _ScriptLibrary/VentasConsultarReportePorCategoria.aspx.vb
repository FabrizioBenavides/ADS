Imports Benavides.POSAdmin.Commons

Imports Benavides.CC.Business


Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Http

Public Class VentasConsultarReportePorCategoria
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


#Region " Class Private Attributes"

    Private intRenglonesxPagina As Integer = 46
    Private strmRecordBrowser As String = ""
    Private strmRecordBrowserImpresion As String = ""

    Const strComitasDobles As String = """"
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
    ' Name       : intCompaniaId
    ' Description: Valor de la Compañia 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCompaniaId() As Integer

        Get

            Return CInt(Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intCompaniaId", "0", Request, Server))
        End Get

    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Valor de la Sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intSucursalId() As Integer

        Get
            Return CInt(Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intSucursalId", "0", Request, Server))
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

            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strSucursalNombre", "0", Request, Server)
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
            Return CInt(Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))
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
    ' Name       : strCadenaImagen
    ' Description: Valor de la Compañia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCadenaImagen() As String
        Get
            Return (clsCommons.strReadCookie("strCadenaImagen", "", Request, Server))
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
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", "0", Request, Server)
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
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request)
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
    ' Description: URL del POS Admin
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
    ' Name       : LlenarControlDivisionArticulos
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboDivisionArticulos
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlDivision() As String

        Return CreateJavascriptComboBoxOptions("cboDivision", CStr(intDivisionArticulosId), Benavides.CC.Data.clstblDivisionArticulos.strBuscar(0, "", "", #1/1/2000#, "", 0, 0, strCadenaConexion), "intDivisionArticulosId", "strDivisionArticulosNombre", 1)

    End Function

    '====================================================================
    ' Name       : LlenarControlCategoriaArticulos
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboCategoriaArticulos
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlCategoria() As String

        Dim returnedJavascript As String = String.Empty

        If intDivisionArticulosId > 0 Then

            returnedJavascript = CreateJavascriptComboBoxOptions("cboCategoria", CStr(intCategoriaArticulosId), Benavides.CC.Data.clstblCategoriaArticulos.strBuscar(intDivisionArticulosId, 0, "", "", #1/1/2000#, "", 0, 0, strCadenaConexion), "intCategoriaArticulosId", "strCategoriaArticulosNombre", 1)

        End If

        Return returnedJavascript

    End Function

    '====================================================================
    ' Name       : strCmd
    ' Description: Valor del parámetro strCmd
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String

        Get
            Return Request.QueryString("strCmd")
        End Get

    End Property

    Public ReadOnly Property intDivisionArticulosId() As Integer

        Get
            Return CInt(GetPageParameter("cboDivision", "0"))
        End Get

    End Property

    Public ReadOnly Property intCategoriaArticulosId() As Integer

        Get
            Return CInt(GetPageParameter("cboCategoria", "0"))
        End Get

    End Property

    Public ReadOnly Property txtFechaInicial() As String

        Get
            If Len(Request("txtFechaInicial")) > 0 Then
                Return Request("txtFechaInicial")
            Else
                Return ""
            End If
        End Get

    End Property

    Public ReadOnly Property txtFechaFinal() As String

        Get
            If Len(Request("txtFechaFinal")) > 0 Then
                Return Request("txtFechaFinal")
            Else
                Return ""
            End If
        End Get

    End Property

    Public ReadOnly Property intAgruparId() As Integer

        Get
            Return CInt(GetPageParameter("cboAgrupar", "1"))
        End Get

    End Property


    '====================================================================
    ' Name       : strRecordBrowser
    ' Description: REcordBorwser
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRecordBrowser() As String
        Get
            Return strmRecordBrowser
        End Get
        Set(ByVal strValue As String)
            strmRecordBrowser = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowserImpresion
    ' Description: REcordBorwser
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRecordBrowserImpresion() As String
        Get
            Return strmRecordBrowserImpresion
        End Get
        Set(ByVal strValue As String)
            strmRecordBrowserImpresion = strValue
        End Set
    End Property

    Private Function strImprimeEncabezado(ByVal intPaginaActual As Integer, ByVal intTotalPaginas As Integer) As String


        Dim strHtmlEncabezado As New StringBuilder

        If intPaginaActual > 1 Then
            strHtmlEncabezado.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")
        End If

        strHtmlEncabezado.Append("<table width='770px' border='0' cellpadding='0' cellspacing='0'> ")

        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td width='100%'  colspan='3'>&nbsp;</td>")
        strHtmlEncabezado.Append("</tr>")

        'Logo
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='49%' align='left'  ><img src='../static/images/" & strCadenaImagen & "/logo.gif' width='125' height='25' border='0'></td>")
        strHtmlEncabezado.Append("<td width='49%' align='right' >REPORTE DE VENTAS</td>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='49%' align='left'  class='tdtxtImpresionBold'>" & clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</td>")
        strHtmlEncabezado.Append("<td width='49%' align='right' class='tdtxtImpresionBold'>HOJA " & intPaginaActual.ToString & " / " & intTotalPaginas & "</td>")
        strHtmlEncabezado.Append("</tr>")

        'Sucursal
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='98%' align='left' colspan='2' class='tdtxtImpresionBold' nowrap>" & strCentroLogisticoId & " - " & strSucursalNombre & " (" & intCompaniaId.ToString & intSucursalId.ToString("000") & ")" & "</td>")
        strHtmlEncabezado.Append("<tr class='trtitulos'>")

        strHtmlEncabezado.Append("</table>")

        'Titulos Detalle
        strHtmlEncabezado.Append("<table width='770px' border='0' cellpadding='0' cellspacing='0'> ")

        strHtmlEncabezado.Append("<tr class='trtitulos'>")

        strHtmlEncabezado.Append("<th width='02%'>&nbsp;</th>")
        strHtmlEncabezado.Append("<th width='05%' align='left' class='tdtxtImpresionBoldRayita' >No.</th>")


        If intAgruparId = 1 Then
            strHtmlEncabezado.Append("<th width='53%' class='tdtxtImpresionBoldRayita' align='left' nowrap>Division</th>")
        Else
            strHtmlEncabezado.Append("<th width='33%' class='tdtxtImpresionBoldRayita' align='left' nowrap>Division</th>")
            strHtmlEncabezado.Append("<th width='20%' class='tdtxtImpresionBoldRayita' align='left' nowrap>Categoria</th>")
        End If

        strHtmlEncabezado.Append("<th width='10%' class='tdtxtImpresionBoldRayita' align='left' nowrap>Año Anterior</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtImpresionBoldRayita' align='left' nowrap>Importe</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtImpresionBoldRayita' align='left' nowrap>Presupuesto</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtImpresionBoldRayita' align='left' nowrap>Porcentaje</th>")
        strHtmlEncabezado.Append("</tr>")

        strHtmlEncabezado.Append("</table>")

        strImprimeEncabezado = strHtmlEncabezado.ToString


    End Function


    Private Function strImprimeDetalle(ByVal intContadorRegistro As Integer, ByVal objRegistroDetalleReporteVentas As System.Collections.SortedList) As String

        Dim strColorRegistro As String = ""

        Dim strHtmlDetalle As New StringBuilder

        If ((intContadorRegistro Mod 2) = 0) Then
            strColorRegistro = "'tdtxtImpresionBold'"
        Else
            strColorRegistro = "'tdtxtImpresionNormal'"
        End If

        strHtmlDetalle.Append("<tr>")

        strHtmlDetalle.Append("<td width='02%'>&nbsp;</td>")

        ' 1 No. de Renglon
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='05%' align='right'>" & intContadorRegistro.ToString & "&nbsp;</td>")

        If intAgruparId = 1 Then
            strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='53%' align='left'>" & clsCommons.strFormatearDescripcion(CStr(objRegistroDetalleReporteVentas.Item("strDivisionArticulosNombreId")) & "-" & CStr(objRegistroDetalleReporteVentas.Item("strDivisionArticulosNombre"))) & "</td>")
        Else
            strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='23%' align='left'>" & clsCommons.strFormatearDescripcion(CStr(objRegistroDetalleReporteVentas.Item("strDivisionArticulosNombreId")) & "-" & CStr(objRegistroDetalleReporteVentas.Item("strDivisionArticulosNombre"))) & "</td>")
            strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='30%' align='left'>" & clsCommons.strFormatearDescripcion(CStr(objRegistroDetalleReporteVentas.Item("strCategoriaArticulosNombreId")) & "-" & CStr(objRegistroDetalleReporteVentas.Item("strCategoriaArticulosNombre"))) & "</td>")
        End If

        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='right'>" & clsCommons.strFormatearNumeroPresentacion(CStr(objRegistroDetalleReporteVentas.Item("fltVentaImporteAA")), False) & "</td>")

        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='right'>" & clsCommons.strFormatearNumeroPresentacion(CStr(objRegistroDetalleReporteVentas.Item("fltVentaImporte")), False) & "</td>")

        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='right'>" & clsCommons.strFormatearNumeroPresentacion(CStr(objRegistroDetalleReporteVentas.Item("fltVentaImportePresupuesto")), False) & "</td>")

        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='right'>" & clsCommons.strFormatearNumeroPresentacion(CStr(objRegistroDetalleReporteVentas.Item("fltVentaImportePorcentaje")), False) & "</td>")

        strHtmlDetalle.Append("</tr>")

        Return strHtmlDetalle.ToString

    End Function

    '====================================================================
    ' Name       : strImpresionReporteVentas
    ' Description: Genera el HTML para la impresion del reporte de ventas
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImpresionReporteVentas(ByVal objArrayVentas As Array) As String

        Dim objRegistroDetalleReporteVentas As System.Collections.SortedList = Nothing

        Dim strImpresionHTML As New StringBuilder

        If IsArray(objArrayVentas) AndAlso (objArrayVentas.Length > 0) Then

            Dim intContadorRegistro As Integer = 0

            Dim intTotalRenglones As Integer = objArrayVentas.Length
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

            For Each objRegistroDetalleReporteVentas In objArrayVentas

                intRenglon += 1
                intContadorRegistro += 1

                If intRenglon = 1 Then
                    intPagina += 1
                    strImpresionHTML.Append(strImprimeEncabezado(intPagina, intTotalPaginas))
                    strImpresionHTML.Append("<table width='770px' border='0' cellpadding='0' cellspacing='0'> ")
                End If

                strImpresionHTML.Append(strImprimeDetalle(intContadorRegistro, objRegistroDetalleReporteVentas))

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
            strImpresionHTML.Append("<td class='tdblanco' colspan='8'>No hay registros</td>")
            strImpresionHTML.Append("</tr>")
            strImpresionHTML.Append("</table>")

        End If

        Return strImpresionHTML.ToString

    End Function


    '====================================================================
    ' Name       : Page_Load
    ' Description: Evento "Load" de la página
    ' Parameters :
    '              ByVal objSender As System.Object
    '                 - Objeto que genera el Evento
    '              ByVal objEvent As System.EventArgs
    '                 - Argumentos del Evento
    ' Throws     : Ninguna
    ' Output     : Ninguna
    '====================================================================
    Private Sub Page_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Load


        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then

            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)

        End If

        Dim objArrayVentas As Array = Nothing

        Select Case strCmd

            Case "Consultar"

                Dim dtmFechaInicial As Date = CDate("01/01/2000")
                Dim dtmFechaFinal As Date = CDate("01/01/2000")

                If Len(txtFechaInicial) = 10 Then
                    dtmFechaInicial = CDate(clsCommons.strDMYtoMDY(txtFechaInicial))
                End If

                If Len(txtFechaFinal) = 10 Then
                    dtmFechaFinal = CDate(clsCommons.strDMYtoMDY(txtFechaFinal))
                End If


                Dim strRecordBrowserName As String = ""


                objArrayVentas = clsConcentrador.clsSucursal.strBuscarVentaDivisionCategoria(intCompaniaId, intSucursalId, intDivisionArticulosId, intCategoriaArticulosId, dtmFechaInicial, dtmFechaFinal, intAgruparId, strCadenaConexion)

                If IsArray(objArrayVentas) AndAlso objArrayVentas.Length > 0 Then
                    If intAgruparId = 1 Then
                        strRecordBrowserName = "VentasConsultarReporteDivision"
                    Else
                        strRecordBrowserName = "VentasConsultarReporteCategoria"
                    End If

                    strRecordBrowser = clsCommons.strGenerateJavascriptString(Replace(Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, objArrayVentas, 1, objArrayVentas.Length, ""), "onclick=""window.location='strCmd=Agregar'""", "onclick=""return cmdImprimir_onclick()"""))
                    strRecordBrowserImpresion = strImpresionReporteVentas(objArrayVentas)
                End If

        End Select



    End Sub

End Class
