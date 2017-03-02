Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business
Imports Benavides.CC.Business.clsConcentrador.clsSucursal.clsMercancia
Imports System.Configuration
Imports System.Text

Public Class clsMercanciaPedidoVentaCatalogoDetalle
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

    Private intmPedidoVentaCatalogoFolio As Integer
    Private strmPedidoVentaCatalogoRegistro As String

    Private strmClienteRFC As String
    Private strmPedidoVentaCatalogoClienteRazonSocial As String

    Private strmPedidoVentaCatalogoDatoEntregaCalle As String
    Private strmPedidoVentaCatalogoDatoEntregaNoExterior As String
    Private strmPedidoVentaCatalogoDatoEntregaNoInterior As String
    Private strmPedidoVentaCatalogoDatoEntregaEntreCalles As String
    Private strmPedidoVentaCatalogoDatoEntregaColonia As String
    Private strmPedidoVentaCatalogoDatoEntregaCiudad As String
    Private strmPedidoVentaCatalogoDatoEntregaEstado As String
    Private strmPedidoVentaCatalogoDatoEntregaCodigoPostal As String
    Private strmPedidoVentaCatalogoDatoEntregaTelefono As String
    Private strmPedidoVentaCatalogoDatoEntregaMovil As String
    Private strmPedidoVentaCatalogoDatoEntregaEMail As String
    Private strmPedidoVentaCatalogoDatoEntregaObservaciones As String

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
    ' Description: Número Id Pedido
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
    ' Name       : intPedidoVentaCatalogoId
    ' Description: Número Id Pedido
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Long
    '====================================================================
    Public ReadOnly Property intPedidoVentaCatalogoId() As Long
        Get
            If Not IsNothing(Request("intPedidoVentaCatalogoId")) Then
                Return CLng(Request("intPedidoVentaCatalogoId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intPedidoVentaCatalogoFolio 
    ' Description: Id de la captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intPedidoVentaCatalogoFolio() As Integer
        Get
            Return intmPedidoVentaCatalogoFolio
        End Get
        Set(ByVal dblValue As Integer)
            intmPedidoVentaCatalogoFolio = dblValue
        End Set
    End Property

    '====================================================================
    ' Name       : strPedidoVentaCatalogoRegistro
    ' Description: Id de la captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strPedidoVentaCatalogoRegistro() As String
        Get
            Return strmPedidoVentaCatalogoRegistro
        End Get
        Set(ByVal strValue As String)
            strmPedidoVentaCatalogoRegistro = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strClienteRFC 
    ' Description: Id de la captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strClienteRFC() As String
        Get
            Return strmClienteRFC
        End Get
        Set(ByVal strValue As String)
            strmClienteRFC = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strPedidoVentaCatalogoClienteRazonSocial 
    ' Description: Id de la captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strPedidoVentaCatalogoClienteRazonSocial() As String
        Get
            Return strmPedidoVentaCatalogoClienteRazonSocial
        End Get
        Set(ByVal strValue As String)
            strmPedidoVentaCatalogoClienteRazonSocial = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strPedidoVentaCatalogoDatoEntregaCalle 
    ' Description: Id de la captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strPedidoVentaCatalogoDatoEntregaCalle() As String
        Get
            Return strmPedidoVentaCatalogoDatoEntregaCalle
        End Get
        Set(ByVal strValue As String)
            strmPedidoVentaCatalogoDatoEntregaCalle = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strPedidoVentaCatalogoDatoEntregaNoExterior 
    ' Description: Id de la captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strPedidoVentaCatalogoDatoEntregaNoExterior() As String
        Get
            Return strmPedidoVentaCatalogoDatoEntregaNoExterior
        End Get
        Set(ByVal strValue As String)
            strmPedidoVentaCatalogoDatoEntregaNoExterior = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strPedidoVentaCatalogoDatoEntregaNoInterior 
    ' Description: Id de la captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strPedidoVentaCatalogoDatoEntregaNoInterior() As String
        Get
            Return strmPedidoVentaCatalogoDatoEntregaNoInterior
        End Get
        Set(ByVal strValue As String)
            strmPedidoVentaCatalogoDatoEntregaNoInterior = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strPedidoVentaCatalogoDatoEntregaEntreCalles
    ' Description: Id de la captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strPedidoVentaCatalogoDatoEntregaEntreCalles() As String
        Get
            Return strmPedidoVentaCatalogoDatoEntregaEntreCalles
        End Get
        Set(ByVal strValue As String)
            strmPedidoVentaCatalogoDatoEntregaEntreCalles = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strPedidoVentaCatalogoDatoEntregaColonia 
    ' Description: Id de la captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strPedidoVentaCatalogoDatoEntregaColonia() As String
        Get
            Return strmPedidoVentaCatalogoDatoEntregaColonia
        End Get
        Set(ByVal strValue As String)
            strmPedidoVentaCatalogoDatoEntregaColonia = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strPedidoVentaCatalogoDatoEntregaCiudad 
    ' Description: Id de la captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strPedidoVentaCatalogoDatoEntregaCiudad() As String
        Get
            Return strmPedidoVentaCatalogoDatoEntregaCiudad
        End Get
        Set(ByVal strValue As String)
            strmPedidoVentaCatalogoDatoEntregaCiudad = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strPedidoVentaCatalogoDatoEntregaEstado 
    ' Description: Id de la captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strPedidoVentaCatalogoDatoEntregaEstado() As String
        Get
            Return strmPedidoVentaCatalogoDatoEntregaEstado
        End Get
        Set(ByVal strValue As String)
            strmPedidoVentaCatalogoDatoEntregaEstado = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strPedidoVentaCatalogoDatoEntregaCodigoPostal 
    ' Description: Id de la captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strPedidoVentaCatalogoDatoEntregaCodigoPostal() As String
        Get
            Return strmPedidoVentaCatalogoDatoEntregaCodigoPostal
        End Get
        Set(ByVal strValue As String)
            strmPedidoVentaCatalogoDatoEntregaCodigoPostal = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strPedidoVentaCatalogoDatoEntregaTelefono 
    ' Description: Id de la captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strPedidoVentaCatalogoDatoEntregaTelefono() As String
        Get
            Return strmPedidoVentaCatalogoDatoEntregaTelefono
        End Get
        Set(ByVal strValue As String)
            strmPedidoVentaCatalogoDatoEntregaTelefono = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strPedidoVentaCatalogoDatoEntregaMovil 
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strPedidoVentaCatalogoDatoEntregaMovil() As String
        Get
            Return strmPedidoVentaCatalogoDatoEntregaMovil
        End Get
        Set(ByVal strValue As String)
            strmPedidoVentaCatalogoDatoEntregaMovil = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strPedidoVentaCatalogoDatoEntregaEMail 
    ' Description: Id de la captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strPedidoVentaCatalogoDatoEntregaEMail() As String
        Get
            Return strmPedidoVentaCatalogoDatoEntregaEMail
        End Get
        Set(ByVal strValue As String)
            strmPedidoVentaCatalogoDatoEntregaEMail = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strPedidoVentaCatalogoDatoEntregaObservaciones 
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strPedidoVentaCatalogoDatoEntregaObservaciones() As String
        Get
            Return strmPedidoVentaCatalogoDatoEntregaObservaciones
        End Get
        Set(ByVal strValue As String)
            strmPedidoVentaCatalogoDatoEntregaObservaciones = strValue
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

        strHtmlEncabezado.Append("<table width='770px' border='0' cellpadding='0' cellspacing='0'> ")

        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td width='100%'  colspan='7'>&nbsp;</td>")
        strHtmlEncabezado.Append("</tr>")

        'Logo
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='49%' align='left'  colspan='3'><img src='../static/images/" & strCadenaImagen & "/logo.gif' width='125' height='25' border='0'></td>")
        strHtmlEncabezado.Append("<td width='49%' align='right' colspan='3'>PEDIDO VENTA CATALOGO</td>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='49%' align='left'  colspan='3' class='tdtxtImpresionBold'>" & clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</td>")
        strHtmlEncabezado.Append("<td width='49%' align='right' colspan='3' class='tdtxtImpresionBold'>HOJA " & intPaginaActual.ToString & " / " & intTotalPaginas & "</td>")
        strHtmlEncabezado.Append("</tr>")

        'Sucursal
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='98%' align='left' colspan='6' class='tdtxtImpresionBold' nowrap>" & strCentroLogisticoId & " - " & strSucursalNombre & " (" & intCompaniaId.ToString & intSucursalId.ToString("000") & ")" & "</td>")
        strHtmlEncabezado.Append("<tr class='trtitulos'>")

        'Datos Pedido  
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='98%' align='left' colspan='6' class='tdtxtImpresionBold'>Folio: " & intPedidoVentaCatalogoFolio.ToString & "</td>")
        strHtmlEncabezado.Append("</tr>")

        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='46%' align='left' class='tdtxtImpresionBold'>FECHA REGISTRO: " & strPedidoVentaCatalogoRegistro & "</td>")
        strHtmlEncabezado.Append("<td width='52%' align='left'  colspan='5' class='tdtxtImpresionBold'>CLIENTE: " & strClienteRFC & " - " & strPedidoVentaCatalogoClienteRazonSocial & "</td>")
        strHtmlEncabezado.Append("</tr>")

        'Direccion entrega
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='98%' align='left' colspan='6' class='tdtxtImpresionBold'>DIRECCION ENTREGA: " & strPedidoVentaCatalogoDatoEntregaCalle & " " & strPedidoVentaCatalogoDatoEntregaNoExterior & " " & strPedidoVentaCatalogoDatoEntregaNoInterior & " " & strPedidoVentaCatalogoDatoEntregaEntreCalles & " " & strPedidoVentaCatalogoDatoEntregaColonia & "</td>")
        strHtmlEncabezado.Append("</tr>")

        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='98%' align='left' colspan='6' class='tdtxtImpresionBold'>CIUDAD: " & strPedidoVentaCatalogoDatoEntregaCiudad & "  ESTADO: " & strPedidoVentaCatalogoDatoEntregaEstado & "  C.P.: " & strPedidoVentaCatalogoDatoEntregaCodigoPostal & "</td>")
        strHtmlEncabezado.Append("</tr>")

        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='98%' align='left' colspan='6' class='tdtxtImpresionBold'>TELEFONO: " & strPedidoVentaCatalogoDatoEntregaTelefono & "   CEL/TEL ADICIONAL: " & strPedidoVentaCatalogoDatoEntregaMovil & "    E-MAIL: " & strPedidoVentaCatalogoDatoEntregaEMail & "</td>")
        strHtmlEncabezado.Append("</tr>")

        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='98%' align='left' colspan='6' class='tdtxtImpresionBold'>OBSERVACIONES: " & strPedidoVentaCatalogoDatoEntregaObservaciones & "</td>")
        strHtmlEncabezado.Append("</tr>")

        strHtmlEncabezado.Append("</table>")

        'Titulos Detalle
        strHtmlEncabezado.Append("<table width='770px' border='0' cellpadding='0' cellspacing='0'> ")

        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th width='02%'>&nbsp;</th>")
        strHtmlEncabezado.Append("<th width='05%' align='left' class='tdtxtImpresionBoldRayita' >No.</th>")
        strHtmlEncabezado.Append("<th width='05%' align='left' class='tdtxtImpresionBoldRayita' >Caja</th>")
        strHtmlEncabezado.Append("<th width='05%' align='left' class='tdtxtImpresionBoldRayita' >Ticket</th>")
        strHtmlEncabezado.Append("<th width='05%' align='left' class='tdtxtImpresionBoldRayita' >C&oacute;digo</th>")
        strHtmlEncabezado.Append("<th width='60%' align='left' class='tdtxtImpresionBoldRayita' >Descripci&oacute;n</th>")
        strHtmlEncabezado.Append("<th width='18%' align='left' class='tdtxtImpresionBoldRayita' >Cantidad</th>")
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
    Private Function strImprimeDetalle(ByVal intContadorRegistro As Integer, ByVal objRegistroDetallePedidoVentaCatalogo As System.Collections.SortedList) As String

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
        ' 2 Caja
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='05%' align='right'>" & CStr(objRegistroDetallePedidoVentaCatalogo.Item("intCajaId")) & "</td>")
        ' 3 Ticket
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='05%' align='right'>" & CStr(objRegistroDetallePedidoVentaCatalogo.Item("intTicketId")) & "</td>")
        ' 4 Articulo
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='05%' align='right'>" & CStr(objRegistroDetallePedidoVentaCatalogo.Item("intArticuloId")) & "</td>")
        ' 5 Descripción
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='60%' align='left'>" & clsCommons.strFormatearDescripcion(CStr(objRegistroDetallePedidoVentaCatalogo.Item("strArticuloDescripcion"))) & "</td>")
        ' 6 Cantidad
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='18%' align='right'>" & CStr(objRegistroDetallePedidoVentaCatalogo.Item("intArticuloPedidoVentaCatalogoCantidad")) & "</td>")

        strHtmlDetalle.Append("</tr>")

        Return strHtmlDetalle.ToString

    End Function

    '====================================================================
    ' Name       : strGeneraImpresionPedidoVentaCatalogo
    ' Description: Genera el HTML para la impresion de los pedidos
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strGeneraImpresionPedidoVentaCatalogo(ByVal objDetallePedidoVentaCatalogo As Array) As String

        Dim objRegistroDetallePedidoVentaCatalogo As System.Collections.SortedList = Nothing

        Dim strImpresionHTML As New StringBuilder


        If IsArray(objDetallePedidoVentaCatalogo) AndAlso (objDetallePedidoVentaCatalogo.Length > 0) Then

            Dim intContadorRegistro As Integer = 0

            Dim intTotalRenglones As Integer = objDetallePedidoVentaCatalogo.Length
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

            For Each objRegistroDetallePedidoVentaCatalogo In objDetallePedidoVentaCatalogo

                intRenglon += 1
                intContadorRegistro += 1

                If intRenglon = 1 Then
                    intPagina += 1
                    strImpresionHTML.Append(strImprimeEncabezado(intPagina, intTotalPaginas))
                    strImpresionHTML.Append("<table width='770px' border='0' cellpadding='0' cellspacing='0'> ")
                End If

                strImpresionHTML.Append(strImprimeDetalle(intContadorRegistro, objRegistroDetallePedidoVentaCatalogo))

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

    '====================================================================
    ' Name       : strGeneraPedidoVentaCatalogo
    ' Description: Genera Record Browser
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGeneraPedidoVentaCatalogo(ByVal objDetallePedidoVentaCatalogo As Array) As String

        Dim objRegistroDetallePedidoVentaCatalogo As System.Collections.SortedList = Nothing

        Dim strHTML As StringBuilder
        Dim intConsecutivo As Integer = 0
        Dim strColorRegistro As String = ""
        Dim fltImporteTotal As Double = 0
        Dim strImporteTotal As String = ""

        strHTML = New StringBuilder


        strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strHTML.Append("<tr class='trtitulos'>")
        strHTML.Append("<th width='05%' class='rayita' align='left'>No.</th>")
        strHTML.Append("<th width='10%' class='rayita' align='left'>Caja</th>")
        strHTML.Append("<th width='15%' class='rayita' align='left'>Ticket</th>")
        strHTML.Append("<th width='15%' class='rayita' align='left'>C&oacute;digo</th>")
        strHTML.Append("<th width='40%' class='rayita' align='left'>Descripci&oacute;n</th>")
        strHTML.Append("<th width='15%' class='rayita' align='left'>Cantidad</th>")
        strHTML.Append("</tr>")

        If IsArray(objDetallePedidoVentaCatalogo) AndAlso objDetallePedidoVentaCatalogo.Length > 0 Then

            For Each objRegistroDetallePedidoVentaCatalogo In objDetallePedidoVentaCatalogo

                intConsecutivo += 1

                If (intConsecutivo Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If

                strHTML.Append("<tr>")
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & intConsecutivo.ToString & "</td>") ' No
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & CStr(objRegistroDetallePedidoVentaCatalogo.Item("intCajaId")) & "</td>") ' intCajaId
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & CStr(objRegistroDetallePedidoVentaCatalogo.Item("intTicketId")) & "</td>") ' intTicketId
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & CStr(objRegistroDetallePedidoVentaCatalogo.Item("intArticuloId")) & "</td>") ' Articulo
                strHTML.Append("<td class=" & strColorRegistro & " align='left'> " & clsCommons.strFormatearDescripcion(CStr(objRegistroDetallePedidoVentaCatalogo.Item("strArticuloDescripcion"))) & "</td>") ' Descripción
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & CStr(objRegistroDetallePedidoVentaCatalogo.Item("intArticuloPedidoVentaCatalogoCantidad")) & "</td>") ' Cantidad
                strHTML.Append("</tr>")
            Next
        Else
            strHTML.Append("<tr>")
            strHTML.Append("<td class='tdblanco' colspan='6'>No hay registros</td>")
            strHTML.Append("</tr>")
        End If

        strHTML.Append("</table>")
        strHTML.Append("<br>")

        Return strHTML.ToString

    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        Dim objArrayPedido As Array = clsCompras.clsPedidoVentaCatalogo.strBuscar(intCompaniaId, intSucursalId, intPedidoVentaCatalogoId, CDate("01/01/1900"), CDate("01/01/1900"), 0, 0, strCadenaConexion)
        Dim objRegistroPedido As System.Collections.SortedList = Nothing

        If IsArray(objArrayPedido) AndAlso objArrayPedido.Length > 0 Then

            objRegistroPedido = DirectCast(objArrayPedido.GetValue(0), System.Collections.SortedList)

            intPedidoVentaCatalogoFolio = CInt(objRegistroPedido.Item("intPedidoVentaCatalogoFolio"))
            strPedidoVentaCatalogoRegistro = CStr(CDate(objRegistroPedido.Item("dtmPedidoVentaCatalogoRegistro")).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture))

            strClienteRFC = clsCommons.strFormatearDescripcion(CStr(objRegistroPedido.Item("strClienteRFC")))
            strPedidoVentaCatalogoClienteRazonSocial = clsCommons.strFormatearDescripcion(CStr(objRegistroPedido.Item("strPedidoVentaCatalogoClienteRazonSocial")))

            strPedidoVentaCatalogoDatoEntregaCalle = clsCommons.strFormatearDescripcion(CStr(objRegistroPedido.Item("strPedidoVentaCatalogoDatoEntregaCalle")))
            strPedidoVentaCatalogoDatoEntregaNoExterior = clsCommons.strFormatearDescripcion(CStr(objRegistroPedido.Item("strPedidoVentaCatalogoDatoEntregaNoExterior")))
            strPedidoVentaCatalogoDatoEntregaNoInterior = clsCommons.strFormatearDescripcion(CStr(objRegistroPedido.Item("strPedidoVentaCatalogoDatoEntregaNoInterior")))
            strPedidoVentaCatalogoDatoEntregaEntreCalles = clsCommons.strFormatearDescripcion(CStr(objRegistroPedido.Item("strPedidoVentaCatalogoDatoEntregaEntreCalles")))
            strPedidoVentaCatalogoDatoEntregaColonia = clsCommons.strFormatearDescripcion(CStr(objRegistroPedido.Item("strPedidoVentaCatalogoDatoEntregaColonia")))
            strPedidoVentaCatalogoDatoEntregaCiudad = clsCommons.strFormatearDescripcion(CStr(objRegistroPedido.Item("strPedidoVentaCatalogoDatoEntregaCiudad")))
            strPedidoVentaCatalogoDatoEntregaEstado = clsCommons.strFormatearDescripcion(CStr(objRegistroPedido.Item("strPedidoVentaCatalogoDatoEntregaEstado")))
            strPedidoVentaCatalogoDatoEntregaCodigoPostal = clsCommons.strFormatearDescripcion(CStr(objRegistroPedido.Item("strPedidoVentaCatalogoDatoEntregaCodigoPostal")))
            strPedidoVentaCatalogoDatoEntregaTelefono = clsCommons.strFormatearDescripcion(CStr(objRegistroPedido.Item("strPedidoVentaCatalogoDatoEntregaTelefono")))
            strPedidoVentaCatalogoDatoEntregaMovil = clsCommons.strFormatearDescripcion(CStr(objRegistroPedido.Item("strPedidoVentaCatalogoDatoEntregaMovil")))
            strPedidoVentaCatalogoDatoEntregaEMail = clsCommons.strFormatearDescripcion(CStr(objRegistroPedido.Item("strPedidoVentaCatalogoDatoEntregaEMail")))
            strPedidoVentaCatalogoDatoEntregaObservaciones = clsCommons.strFormatearDescripcion(CStr(objRegistroPedido.Item("strPedidoVentaCatalogoDatoEntregaObservaciones")))

            Dim PedidoVentaCatalogo As Array = clsCompras.clsPedidoVentaCatalogo.strBuscarDetalle(intCompaniaId, intSucursalId, intPedidoVentaCatalogoId, strCadenaConexion)

            strDetalleCompra = strGeneraPedidoVentaCatalogo(PedidoVentaCatalogo)
            strImpresionCompra = strGeneraImpresionPedidoVentaCatalogo(PedidoVentaCatalogo)

        End If

    End Sub


End Class
