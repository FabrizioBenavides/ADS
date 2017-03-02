Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business
Imports Benavides.CC.Business.clsConcentrador.clsSucursal.clsMercancia
Imports System.Configuration
Imports System.Text

Public Class clsMercanciaRemisionCompraDirectaDetalle
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

    Const strComitasDobles As String = """"

    Private intRenglonesxPagina As Integer = 42
    Public strDetalleCompra As String
    Public strImpresionCompra As String

    Private intmRemisionCompraDirectaFolio As Integer
    Private strmProveedorNombreId As String
    Private strmProveedorRazonSocial As String
    
    Private strmFechaRecepcion As String
    Private strmFechaRemision As String
    Private strmRemision As String

    Private intmRemisionCompraDirectaEstado As Integer
    Private strmRemisionCompraDirectaEstado As string

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
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strPaginapadre
    ' Description: Número Id Remision
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public ReadOnly Property strPaginapadre() As String
        Get
            If Not IsNothing(Request("strPaginapadre")) Then
                Return Request("strPaginapadre")
            Else
                Return "Consulta"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intRemisionCompraDirectaId
    ' Description: Número Id Remision
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Long
    '====================================================================
    Public ReadOnly Property intRemisionCompraDirectaId() As Long
        Get
            If Not IsNothing(Request("intRemisionCompraDirectaId")) Then
                Return CLng(Request("intRemisionCompraDirectaId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intRemisionCompraDirectaFolio 
    ' Description: Id de la captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intRemisionCompraDirectaFolio() As Integer
        Get
            Return intmRemisionCompraDirectaFolio
        End Get
        Set(ByVal dblValue As Integer)
            intmRemisionCompraDirectaFolio = dblValue
        End Set
    End Property

    '====================================================================
    ' Name       : strProveedorNombreId 
    ' Description: Id de la captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strProveedorNombreId() As String
        Get
            Return strmProveedorNombreId
        End Get
        Set(ByVal strValue As String)
            strmProveedorNombreId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strProveedorRazonSocial 
    ' Description: Id de la captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strProveedorRazonSocial() As String
        Get
            Return strmProveedorRazonSocial
        End Get
        Set(ByVal strValue As String)
            strmProveedorRazonSocial = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaRecepcion
    ' Description:  
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strFechaRecepcion() As String
        Get
            Return strmFechaRecepcion
        End Get
        Set(ByVal strValue As String)
            strmFechaRecepcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaRemision
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strFechaRemision() As String
        Get
            Return strmFechaRemision
        End Get
        Set(ByVal strValue As String)
            strmFechaRemision = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRemision
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRemision() As String
        Get
            Return strmRemision
        End Get
        Set(ByVal strValue As String)
            strmRemision = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intRemisionCompraDirectaEstado 
    ' Description: Id de la captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intRemisionCompraDirectaEstado() As Integer
        Get
            Return intmRemisionCompraDirectaEstado
        End Get
        Set(ByVal dblValue As Integer)
            intmRemisionCompraDirectaEstado = dblValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRemisionCompraDirectaEstado
    ' Description: Id de la captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRemisionCompraDirectaEstado() As String
        Get
            Return strmRemisionCompraDirectaEstado
        End Get
        Set(ByVal strValue As String)
            strmRemisionCompraDirectaEstado = strValue
        End Set
    End Property



    '====================================================================
    ' Name       : strImprimeEncabezado
    ' Description: Genera el encabezado para las impresiones
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImprimeEncabezado(ByVal intPaginaActual As Integer, ByVal intTotalPaginas As Integer) As String

        Dim strHtmlEncabezado As New StringBuilder

        If intPaginaActual > 1 Then
            strHtmlEncabezado.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")
        End If

        strHtmlEncabezado.Append("<table width='750px' border='0' cellpadding='0' cellspacing='0'> ")

        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td width='100%'  colspan='5'>&nbsp;</td>")
        strHtmlEncabezado.Append("</tr>")

        'Logo
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='39%' align='left'  colspan='2'><img src='../static/images/" & strCadenaImagen & "/logo.gif' width='125' height='25' border='0'></td>")
        strHtmlEncabezado.Append("<td width='39%' align='right' colspan='3'>REMISION COMPRA DIRECTA</td>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='39%' align='left'  class='tdtxtImpresionBold' colspan='2'>" & clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</td>")
        strHtmlEncabezado.Append("<td width='39%' align='right' class='tdtxtImpresionBold' colspan='3'>HOJA " & intPaginaActual.ToString & " / " & intTotalPaginas & "</td>")
        strHtmlEncabezado.Append("</tr>")

        'Sucursal
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='78%' align='left' class='tdtxtImpresionBold' nowrap colspan='5'>" & strCentroLogisticoId & " - " & strSucursalNombre & " (" & intCompaniaId.ToString & intSucursalId.ToString("000") & ")" & "</td>")
        strHtmlEncabezado.Append("<tr class='trtitulos'>")

        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='53%' align='left' class='tdtxtImpresionBold' colspan='3'>Folio: " & intRemisionCompraDirectaFolio.ToString & "</td>")
        strHtmlEncabezado.Append("<td width='15%' align='left' class='tdtxtImpresionBold' colspan='2'>Fecha Recepción: " & strFechaRecepcion & "</td>")
        strHtmlEncabezado.Append("</tr>")

        'Datos Remision  
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='53%' align='left' class='tdtxtImpresionBold' colspan='3'>Proveedor: " & strProveedorNombreId & " - " & strProveedorRazonSocial & "</td>")
        strHtmlEncabezado.Append("<td width='15%' align='left' class='tdtxtImpresionBold' colspan='2'>Estado Remisión: " & strRemisionCompraDirectaEstado & "</td>")
        strHtmlEncabezado.Append("</tr>")

        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='53%' align='left' class='tdtxtImpresionBold' colspan='3' >No. Remisión: " & strRemision & "</td>")
        strHtmlEncabezado.Append("<td width='15%' align='left' class='tdtxtImpresionBold' colspan='2' >Fecha Remisión: " & strFechaRemision & "</td>")
        strHtmlEncabezado.Append("</tr>")

        strHtmlEncabezado.Append("</table>")

        'Titulos Detalle
        strHtmlEncabezado.Append("<table width='750px' border='0' cellpadding='0' cellspacing='0'> ")

        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th width='02%'>&nbsp;</th>")
        strHtmlEncabezado.Append("<th width='04%' align='left' class='tdtxtImpresionBoldRayita' >No.</th>")
        strHtmlEncabezado.Append("<th width='9%' align='right' class='tdtxtImpresionBoldRayita' >C&oacute;digo" & "</th>")
        strHtmlEncabezado.Append("<th width='50%' align='left' class='tdtxtImpresionBoldRayita' >Descripci&oacute;n" & "</th>")
        strHtmlEncabezado.Append("<th width='10%' align='right' class='tdtxtImpresionBoldRayita' >Cantidad</th>")
        strHtmlEncabezado.Append("<th width='05%' align='left' class='tdtxtImpresionBoldRayita' >&nbsp;</th>")
        strHtmlEncabezado.Append("</tr>")

        strHtmlEncabezado.Append("</table>")

        strImprimeEncabezado = strHtmlEncabezado.ToString

    End Function

    '====================================================================
    ' Name       : strImprimeDetalle
    ' Description: Genera el detalle para las impresiones
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImprimeDetalle(ByVal intContadorRegistro As Integer, ByVal objRegistroDetalleRemisionCompraDirecta As System.Collections.SortedList) As String

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
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='04%' align='right'>" & intContadorRegistro.ToString & "&nbsp;</td>")
        ' 2 Articulo
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='9%' align='right'>" & CStr(objRegistroDetalleRemisionCompraDirecta.Item("intArticuloId")) & "</td>")
        ' 5 Descripción
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='50%' align='left'>" & clsCommons.strFormatearDescripcion(CStr(objRegistroDetalleRemisionCompraDirecta.Item("strArticuloDescripcion"))) & "</td>")
        ' 6 Cantidad
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='right'>" & CStr(objRegistroDetalleRemisionCompraDirecta.Item("intArticuloRemisionCompraDirectaCantidad")) & "</td>")

        ' 3 Espacio
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='05%' align='right'>&nbsp;</td>")
        strHtmlDetalle.Append("</tr>")

        Return strHtmlDetalle.ToString

    End Function

    '====================================================================
    ' Name       : strGeneraImpresionRemisionCompraDirecta
    ' Description: Genera el HTML para la impresion de los pedidos
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strGeneraImpresionRemisionCompraDirecta(ByVal objDetalleRemisionCompraDirecta As Array) As String

        Dim objRegistroDetalleRemisionCompraDirecta As System.Collections.SortedList = Nothing

        Dim strImpresionHTML As New StringBuilder


        If IsArray(objDetalleRemisionCompraDirecta) AndAlso (objDetalleRemisionCompraDirecta.Length > 0) Then

            Dim intContadorRegistro As Integer = 0

            Dim intTotalRenglones As Integer = objDetalleRemisionCompraDirecta.Length
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

            For Each objRegistroDetalleRemisionCompraDirecta In objDetalleRemisionCompraDirecta

                intRenglon += 1
                intContadorRegistro += 1

                If intRenglon = 1 Then
                    intPagina += 1
                    strImpresionHTML.Append(strImprimeEncabezado(intPagina, intTotalPaginas))
                    strImpresionHTML.Append("<table width='750px' border='0' cellpadding='0' cellspacing='0'> ")
                End If

                strImpresionHTML.Append(strImprimeDetalle(intContadorRegistro, objRegistroDetalleRemisionCompraDirecta))

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
            strImpresionHTML.Append("<td class='tdblanco' colspan='5'>No hay registros</td>")
            strImpresionHTML.Append("</tr>")
            strImpresionHTML.Append("</table>")

        End If

        Return strImpresionHTML.ToString

    End Function

    '====================================================================
    ' Name       : strGeneraRemisionCompraDirecta
    ' Description: Genera Record Browser
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGeneraRemisionCompraDirecta(ByVal objDetalleRemisionCompraDirecta As Array) As String

        Dim objRegistroDetalleRemisionCompraDirecta As System.Collections.SortedList = Nothing

        Dim strHTML As StringBuilder
        Dim intConsecutivo As Integer = 0
        Dim strColorRegistro As String = ""
        Dim fltImporteTotal As Double = 0
        Dim strImporteTotal As String = ""

        strHTML = New StringBuilder


        strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strHTML.Append("<tr class='trtitulos'>")
        strHTML.Append("<th width='06%' class='rayita' align='left'>No.</th>")
        strHTML.Append("<th width='16%' class='rayita' align='left'>C&oacute;digo</th>")
        strHTML.Append("<th width='04%' class='rayita'>&nbsp;</th>")
        strHTML.Append("<th width='55%' class='rayita' align='left'>Descripci&oacute;n</th>")
        strHTML.Append("<th width='10%' class='rayita' align='left'>Cantidad</th>")
        strHTML.Append("<th width='10%' class='rayita'>&nbsp;</th>")
        strHTML.Append("</tr>")

        If IsArray(objDetalleRemisionCompraDirecta) AndAlso objDetalleRemisionCompraDirecta.Length > 0 Then

            For Each objRegistroDetalleRemisionCompraDirecta In objDetalleRemisionCompraDirecta

                intConsecutivo += 1

                If (intConsecutivo Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If

                strHTML.Append("<tr>")
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & intConsecutivo.ToString & "</td>") ' No
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & CStr(objRegistroDetalleRemisionCompraDirecta.Item("intArticuloId")) & "</td>") ' Articulo
                strHTML.Append("<td class=" & strColorRegistro & " align='left'>&nbsp;</td>")
                strHTML.Append("<td class=" & strColorRegistro & " align='left'> " & clsCommons.strFormatearDescripcion(CStr(objRegistroDetalleRemisionCompraDirecta.Item("strArticuloDescripcion"))) & "</td>") ' Descripción
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & CStr(objRegistroDetalleRemisionCompraDirecta.Item("intArticuloRemisionCompraDirectaCantidad")) & "</td>") ' Cantidad
                strHTML.Append("<td class=" & strColorRegistro & " align='left'>&nbsp;</td>")
                strHTML.Append("</tr>")
            Next
        Else
            strHTML.Append("<tr>")
            strHTML.Append("<td class='tdblanco' colspan='6'>No hay registros</td>")
            strHTML.Append("</tr>")
        End If

        strHTML.Append("</table>")

        Return strHTML.ToString

    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        Dim objArrayRemision As Array = clsCompras.clsRemision.strBuscar(intCompaniaId, intSucursalId, intRemisionCompraDirectaId, CDate("01/01/1900"), CDate("01/01/1900"), 0, 0, 0, 0, strCadenaConexion)

        Dim objRegistroRemision As System.Collections.SortedList = Nothing

        If IsArray(objArrayRemision) AndAlso objArrayRemision.Length > 0 Then

            objRegistroRemision = DirectCast(objArrayRemision.GetValue(0), System.Collections.SortedList)

            intRemisionCompraDirectaFolio = CInt(objRegistroRemision.Item("intRemisionCompraDirectaFolio"))

            strProveedorNombreId = clsCommons.strFormatearDescripcion(CStr(objRegistroRemision.Item("strProveedorNombreId")))
            strProveedorRazonSocial = clsCommons.strFormatearDescripcion(CStr(objRegistroRemision.Item("strProveedorRazonSocial")))

            strFechaRecepcion = CStr(CDate(objRegistroRemision.Item("dtmRemisionCompraDirectaFechaRecepcion")).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture))
            strFechaRemision = CStr(CDate(objRegistroRemision.Item("dtmRemisionCompraDirectaFechaDocumento")).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture))

            strRemision = clsCommons.strFormatearDescripcion(CStr(objRegistroRemision.Item("strRemisionCompraDirectaNumeroDocumento")))
            intRemisionCompraDirectaEstado = CInt(objRegistroRemision.Item("intRemisionCompraDirectaEstado"))
            strRemisionCompraDirectaEstado = clsCommons.strFormatearDescripcion(CStr(objRegistroRemision.Item("strRemisionCompraDirectaEstado")))

            Dim RemisionCompraDirecta As Array = clsCompras.clsRemision.strBuscarDetalle(intCompaniaId, intSucursalId, intRemisionCompraDirectaId, strCadenaConexion)

            strDetalleCompra = strGeneraRemisionCompraDirecta(RemisionCompraDirecta)
            strImpresionCompra = strGeneraImpresionRemisionCompraDirecta(RemisionCompraDirecta)

        End If

    End Sub


End Class
