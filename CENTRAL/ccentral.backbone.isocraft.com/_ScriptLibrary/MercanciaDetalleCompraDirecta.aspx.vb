'====================================================================
' Page          : MercanciaDetalleCompraDirecta.aspx
' Title         : Administracion POS y BackOffice
' Description   : Página de Detalle de productos Reclamados.
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : J.Antonio Hernández Dávila
' Version       : 1.0
' Last Modified : Lunes, Noviembre 10, 2003
'               :Carlos Vazquez 
'               : Viernes 29 de Agosto del 2014 (Control de Cafe)
'====================================================================

Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class MercanciaDetalleCompraDirecta
    Inherits System.Web.UI.Page

    Public strDetalleCompra As String
    Public strImpresionCompra As String

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

    Private intRenglonesxPagina As Integer = 42

    Private intmCompraDirectaFolio As Integer
    Private strmProveedorNombreId As String
    Private strmProveedorRazonSocial As String
    Private intmFolioOrdenId As Integer
    Private strmCompraDirectaFechaRecepcion As String
    Private strmCompraDirectaFechaFactura As String
    Private strmCompraDirectaNumeroFactura As String
    Private fltmCompraDirectaImporteTotalFactura As String

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
    ' Name       : strCentroLogisticoId
    ' Description: Valor de la Compañia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCentroLogisticoId() As String
        Get
            Return (clsCommons.strReadCookie("strCentroLogisticoId", String.Empty, Request, Server))
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
            Return (clsCommons.strReadCookie("strCadenaImagen", String.Empty, Request, Server))
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
    ' Name       : strConsulta
    ' Description: Comando a ejecutar
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strConsulta() As String
        Get
            If Not IsNothing(Request.QueryString("strConsulta")) Then
                Return (Request.QueryString("strConsulta"))
            Else
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Comando a ejecutar
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Not IsNothing(Request.QueryString("strCmd")) Then
                Return (Request.QueryString("strCmd"))
            Else
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : rdoFiltroConsulta
    ' Description: Valor del radio boton
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property rdoFiltroConsulta() As String
        Get
            If Not IsNothing(Request.QueryString("rdoFiltroConsulta")) Then
                Return Request.QueryString("rdoFiltroConsulta")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intMesBusqueda
    ' Description: Mes de Busqueda
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intMesBusqueda() As String
        Get
            If Not IsNothing(Request.QueryString("intMesBusqueda")) Then
                Return Request.QueryString("intMesBusqueda")
            Else
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : rdoOrdenConsulta
    ' Description: Mes de Busqueda
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property rdoOrdenConsulta() As String
        Get
            If Not IsNothing(Request.QueryString("rdoOrdenConsulta")) Then
                Return Request.QueryString("rdoOrdenConsulta")
            Else
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intCompraDirectaId
    ' Description: Número de Compra directa
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCompraDirectaId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intCompraDirectaId")) Then
                Return CInt(Request.QueryString("intCompraDirectaId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intCompraDirectaFolio
    ' Description: Número de folio asignado a la compra directa
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intCompraDirectaFolio() As Integer
        Get
            Return intmCompraDirectaFolio
        End Get
        Set(ByVal intValue As Integer)
            intmCompraDirectaFolio = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strProveedorNombreId
    ' Description: Número de Proveedor
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public Property strProveedorNombreId() As String
        Get
            Return strmProveedorNombreId
        End Get
        Set(ByVal intValue As String)
            strmProveedorNombreId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strProveedorRazonSocial
    ' Description: Razon Socialde Proveedor
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public Property strProveedorRazonSocial() As String
        Get
            Return strmProveedorRazonSocial
        End Get
        Set(ByVal intValue As String)
            strmProveedorRazonSocial = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intFolioOrdenId
    ' Description: Folio de Orden
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intFolioOrdenId() As Integer
        Get
            Return intmFolioOrdenId
        End Get
        Set(ByVal intValue As Integer)
            intmFolioOrdenId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCompraDirectaFechaRecepcion
    ' Description: Fecha de Recepcion
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public Property strCompraDirectaFechaRecepcion() As String
        Get
            Return strmCompraDirectaFechaRecepcion
        End Get
        Set(ByVal intValue As String)
            strmCompraDirectaFechaRecepcion = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strmCompraDirectaFechaFactura
    ' Description: Fecha de Factura
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public Property strCompraDirectaFechaFactura() As String
        Get
            Return strmCompraDirectaFechaFactura
        End Get
        Set(ByVal intValue As String)
            strmCompraDirectaFechaFactura = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCompraDirectaNumeroFactura
    ' Description: Fecha de Factura
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public Property strCompraDirectaNumeroFactura() As String
        Get
            Return strmCompraDirectaNumeroFactura
        End Get
        Set(ByVal intValue As String)
            strmCompraDirectaNumeroFactura = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltCompraDirectaImporteTotalFactura
    ' Description: Total de la Factura
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public Property fltCompraDirectaImporteTotalFactura() As String
        Get
            Return fltmCompraDirectaImporteTotalFactura
        End Get
        Set(ByVal intValue As String)
            fltmCompraDirectaImporteTotalFactura = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strGeneraDetalleCompra
    ' Description: Genera Record Browser
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGeneraDetalleCompra(ByVal objDetalleCompra As Array) As String

        Dim strHTML As StringBuilder
        Dim intConsecutivo As Integer = 0
        Dim strColorRegistro As String = String.Empty
        Dim fltImporteTotal As Double = 0
        Dim strImporteTotal As String = String.Empty

        strHTML = New StringBuilder

        strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strHTML.Append("<tr class='trtitulos'>")
        strHTML.Append("<th width='05%' class='rayita' align='right'>No.</th>")
        strHTML.Append("<th width='10%' class='rayita' align='right'>C&oacute;digo</th>")
        strHTML.Append("<th width='45%' class='rayita' align='left'>Descripci&oacute;n</th>")
        strHTML.Append("<th width='10%' class='rayita' align='right'>Cantidad</th>")
        strHTML.Append("<th width='10%' class='rayita' align='right'>C.Rep</th>")
        strHTML.Append("<th width='10%' class='rayita' align='right'>C.Cap</th>")
        strHTML.Append("<th width='10%' class='rayita' align='right'>Importe</th>")
        strHTML.Append("</tr>")

        If IsArray(objDetalleCompra) AndAlso objDetalleCompra.Length > 0 Then

            Dim objRegistro As String() = Nothing

            For Each objRegistro In objDetalleCompra

                intConsecutivo += 1

                If (intConsecutivo Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If

                fltImporteTotal += CDbl(objRegistro(5))

                strHTML.Append("<tr>")
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & intConsecutivo.ToString & "</td>") ' No
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & objRegistro(0).ToString & "</td>") 'Código
                strHTML.Append("<td class=" & strColorRegistro & " align='left'>" & clsCommons.strFormatearDescripcion(objRegistro(1)).ToString & "</td>") ' Descripción
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & objRegistro(2).ToString & "</td>") ' Cantidad
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & clsCommons.strFormatearNumeroPresentacion(objRegistro(3).ToString, True) & "</td>") ' CostoReposición
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & clsCommons.strFormatearNumeroPresentacion(objRegistro(4).ToString, True) & "</td>") ' CostoCapturado
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & clsCommons.strFormatearNumeroPresentacion(objRegistro(5).ToString, True) & "</td>") ' Importe
                strHTML.Append("</tr>")
            Next

            strImporteTotal = clsCommons.strFormatearNumeroPresentacion(fltImporteTotal.ToString, True)

            strHTML.Append("<tr>")
            strHTML.Append("<td class='campotablaresultado' colspan='7' align='right'>Total:" & "<input name='txtImporteTotal' type='text' class='campotablahabilitadoderechasinborde' readonly='true' size='20' maxlength='20' value=" & strImporteTotal & "></td>")
            strHTML.Append("</tr>")
        Else
            strHTML.Append("<tr>")
            strHTML.Append("<td class='tdblanco' colspan='7'>No hay registros</td>")
            strHTML.Append("</tr>")
        End If

        strHTML.Append("</table>")

        Return strHTML.ToString

    End Function

    Private Function strImprimeEncabezado(ByVal intPaginaActual As Integer, _
                                          ByVal intTotalPaginas As Integer) As String

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
        strHtmlEncabezado.Append("<td width='49%' align='left'  colspan='2'><img src='../static/images/" & strCadenaImagen & "/logo.gif' width='125' height='25' border='0'></td>")
        strHtmlEncabezado.Append("<td width='49%' align='right' colspan='2'>COMPRA DIRECTA</td>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='49%' align='left'  colspan='2' class='tdtxtImpresionBold'>" & clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</td>")
        strHtmlEncabezado.Append("<td width='49%' align='right' colspan='2' class='tdtxtImpresionBold'>HOJA " & intPaginaActual.ToString & " / " & intTotalPaginas & "</td>")
        strHtmlEncabezado.Append("</tr>")

        'Sucursal
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='98%' align='left' colspan='4' class='tdtxtImpresionBold' nowrap>" & strCentroLogisticoId & " - " & strSucursalNombre & " (" & intCompaniaId.ToString & intSucursalId.ToString("000") & ")" & "</td>")
        strHtmlEncabezado.Append("<tr class='trtitulos'>")

        'Datos Compra Directa        
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='98%' align='left' colspan='4' class='tdtxtImpresionBold'>Folio: " & intCompraDirectaFolio.ToString & "</td>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='49%' align='left'  colspan='2' class='tdtxtImpresionBold'>Proveedor: " & strProveedorNombreId & " - " & strProveedorRazonSocial & "</td>")
        strHtmlEncabezado.Append("<td width='49%' align='right' colspan='2' class='tdtxtImpresionBold'>Orden: " & intFolioOrdenId.ToString & "</td>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='26%' align='left' class='tdtxtImpresionBold'>Factura: " & strCompraDirectaNumeroFactura & "</td>")
        strHtmlEncabezado.Append("<td width='24%' align='left' class='tdtxtImpresionBold'>Fecha Factura: " & strCompraDirectaFechaFactura & "</td>")
        strHtmlEncabezado.Append("<td width='24%' align='left' class='tdtxtImpresionBold'>Fecha Recepción: " & strCompraDirectaFechaRecepcion & "</td>")
        strHtmlEncabezado.Append("<td width='24%' align='left' class='tdtxtImpresionBold'>Total Facturado: " & fltCompraDirectaImporteTotalFactura & "</td>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        'Titulos Detalle
        strHtmlEncabezado.Append("<table width='770px' border='0' cellpadding='0' cellspacing='0'> ")
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th width='02%'>&nbsp;</th>")
        strHtmlEncabezado.Append("<th width='02%' align='right' class='tdtxtImpresionBoldRayita' >No.</th>")
        strHtmlEncabezado.Append("<th width='06%' align='right' class='tdtxtImpresionBoldRayita' >Código" & "</th>")
        strHtmlEncabezado.Append("<th width='42%' align='left'  class='tdtxtImpresionBoldRayita' >Descripción" & "</th>")
        strHtmlEncabezado.Append("<th width='06%' align='right' class='tdtxtImpresionBoldRayita' >Cantidad</th>")
        strHtmlEncabezado.Append("<th width='14%' align='right' class='tdtxtImpresionBoldRayita' >Costo Reposición</th>")
        strHtmlEncabezado.Append("<th width='14%' align='right' class='tdtxtImpresionBoldRayita' >Costo Capturado</th>")
        strHtmlEncabezado.Append("<th width='14%' align='right' class='tdtxtImpresionBoldRayita' >Importe</th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strImprimeEncabezado = strHtmlEncabezado.ToString

    End Function

    Private Function strImprimeDetalle(ByVal intContadorRegistro As Integer, ByVal objRegistro As String()) As String

        Dim strColorRegistro As String = String.Empty
        Dim strHtmlDetalle As New StringBuilder

        If ((intContadorRegistro Mod 2) = 0) Then
            strColorRegistro = "'tdtxtImpresionBold'"
        Else
            strColorRegistro = "'tdtxtImpresionNormal'"
        End If

        strHtmlDetalle.Append("<tr>")

        strHtmlDetalle.Append("<td width='02%'>&nbsp;</td>")
        ' 1 No. de Renglon
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='02%' align='right'>" & intContadorRegistro.ToString & "&nbsp;</td>")
        ' 2 intArticuloId
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='06%' align='right'>" & clsCommons.strFormatearDescripcion(objRegistro(0).ToString) & "</td>")
        ' 3 strArticuloDescripcion
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='42%' align='left'>" & clsCommons.strFormatearDescripcion(objRegistro(1).ToString) & "</td>")
        ' 4 intArticuloCantidad
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='06%' align='right'>" & clsCommons.strFormatearDescripcion(objRegistro(2).ToString) & "</td>")
        ' 5 CostoReposición
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='14%' align='right'>" & clsCommons.strFormatearNumeroPresentacion(objRegistro(3).ToString, True) & "</td>")
        ' 6 CostoCapturado
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='14%' align='right'>" & clsCommons.strFormatearNumeroPresentacion(objRegistro(4).ToString, True) & "</td>")
        ' 7 Importe
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='14%' align='right'>" & clsCommons.strFormatearNumeroPresentacion(objRegistro(5).ToString, True) & "</td>")

        strHtmlDetalle.Append("</tr>")

        Return strHtmlDetalle.ToString

    End Function

    '====================================================================
    ' Name       : strGeneraImpresionCompra
    ' Description: Genera el Record Browser a desplegar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strGeneraImpresionCompra(ByVal objDetalleCompra As Array) As String

        Dim strImpresionHTML As New StringBuilder


        If IsArray(objDetalleCompra) AndAlso (objDetalleCompra.Length > 0) Then
            Dim objRegistro As String() = Nothing
            Dim intContadorRegistro As Integer = 0

            Dim intTotalRenglones As Integer = objDetalleCompra.Length
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

            For Each objRegistro In objDetalleCompra

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        Dim objArrayComprasDirectas As Array = clsConcentrador.clsSucursal.clsMercancia.clsCompras.strBuscar(intCompaniaId, intSucursalId, intCompraDirectaId, 0, 0, "Todas", 0, 0, strCadenaConexion)

        If IsArray(objArrayComprasDirectas) AndAlso objArrayComprasDirectas.Length > 0 Then

            Dim strRegistroComprasDirecta As String() = Nothing
            Dim objDetalleCompra As Array

            strRegistroComprasDirecta = DirectCast(objArrayComprasDirectas.GetValue(0), String())

            intCompraDirectaFolio = CInt(strRegistroComprasDirecta(2))
            strProveedorNombreId = strRegistroComprasDirecta(1)
            strProveedorRazonSocial = clsCommons.strFormatearDescripcion(strRegistroComprasDirecta(8).ToString)
            intFolioOrdenId = CInt(strRegistroComprasDirecta(10))

            strCompraDirectaNumeroFactura = strRegistroComprasDirecta(4)
            strCompraDirectaFechaFactura = clsCommons.strFormatearFechaPresentacion(strRegistroComprasDirecta(5))
            strCompraDirectaFechaRecepcion = clsCommons.strFormatearFechaPresentacion(strRegistroComprasDirecta(3))
            fltCompraDirectaImporteTotalFactura = clsCommons.strFormatearNumeroPresentacion(strRegistroComprasDirecta(6), True)

            'Esta columna indica si es "Compra Directa" (true) o "Factura de Insumos" (false).
            If CBool(Trim(strRegistroComprasDirecta(12))) = False Then

                objDetalleCompra = clsCapturaInsumosMateriaPrima.strBuscarDetalle(intCompaniaId, intSucursalId, intCompraDirectaId, strCadenaConexion)
            Else
                objDetalleCompra = clsConcentrador.clsSucursal.clsMercancia.clsCompras.strBuscarDetalle(intCompaniaId, intSucursalId, intCompraDirectaId, strCadenaConexion)
            End If

            strDetalleCompra = strGeneraDetalleCompra(objDetalleCompra)
            strImpresionCompra = strGeneraImpresionCompra(objDetalleCompra)

        End If
    End Sub

End Class
