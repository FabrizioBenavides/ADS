Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration


Public Class clsMercanciaDetalleFacturaConfirmada
    Inherits System.Web.UI.Page

    Private intmFacturaElectronicaPedido As Integer
    Private strmFacturaElectronicaNumero As String
    Private dtmmFacturaElectronicaEmisionDocumento As String
    Private fltmFacturaElectronicaImporteTotal As String
    Private fltmFacturaElectronicaImporteIVA As String
    Private fltmFacturaElectronicaImporteIVADescuento As String
    Private fltmFacturaElectronicaImporteDescuentoDespuesIVA As String
    Private fltmFacturaElectronicaImporteNeto As String
    Private intmEstadoFacturaElectronicaFolio As Integer
    Private dtmmEstadoFacturaElectronicaUltimaModificacion As String
    Private strmProveedorRazonSocial As String

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
    ' Name       : intProveedorId
    ' Description: Proveedor con Facturas Pendientes
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intProveedorId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intProveedorId")) Then
                Return CInt(Request.QueryString("intProveedorId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intFacturaElectronicaId
    ' Description: Número identificador de la factura
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intFacturaElectronicaId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intFacturaElectronicaId")) Then
                Return CInt(Request.QueryString("intFacturaElectronicaId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strProveedorRazonSocial 
    ' Description: Razon social del proveedor
    ' Accessor   : Read, write
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
    ' Name       : intFacturaElectronicaPedido
    ' Description: Número de pedido de la factura
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intFacturaElectronicaPedido() As Integer
        Get
            Return intmFacturaElectronicaPedido
        End Get
        Set(ByVal intValue As Integer)
            intmFacturaElectronicaPedido = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFacturaElectronicaNumero
    ' Description: Número de factura 
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strFacturaElectronicaNumero() As String
        Get
            Return strmFacturaElectronicaNumero
        End Get
        Set(ByVal strValue As String)
            strmFacturaElectronicaNumero = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : dtmFacturaElectronicaEmisionDocumento
    ' Description: Fecha de factura
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property dtmFacturaElectronicaEmisionDocumento() As String
        Get
            Return dtmmFacturaElectronicaEmisionDocumento
        End Get
        Set(ByVal strValue As String)
            dtmmFacturaElectronicaEmisionDocumento = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltFacturaElectronicaImporteTotal
    ' Description: Importe total de la factura
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property fltFacturaElectronicaImporteTotal() As String
        Get
            Return fltmFacturaElectronicaImporteTotal
        End Get
        Set(ByVal strValue As String)
            fltmFacturaElectronicaImporteTotal = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltFacturaElectronicaImporteIVA
    ' Description: Importe del IVA
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property fltFacturaElectronicaImporteIVA() As String
        Get
            Return fltmFacturaElectronicaImporteIVA
        End Get
        Set(ByVal strValue As String)
            fltmFacturaElectronicaImporteIVA = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltFacturaElectronicaImporteIVADescuento
    ' Description: Importe del IVA del descuento
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property fltFacturaElectronicaImporteIVADescuento() As String
        Get
            Return fltmFacturaElectronicaImporteIVADescuento
        End Get
        Set(ByVal strValue As String)
            fltmFacturaElectronicaImporteIVADescuento = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltFacturaElectronicaImporteDescuentoDespuesIVA
    ' Description: Importe de descuento después del IVA
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property fltFacturaElectronicaImporteDescuentoDespuesIVA() As String
        Get
            Return fltmFacturaElectronicaImporteDescuentoDespuesIVA
        End Get
        Set(ByVal strValue As String)
            fltmFacturaElectronicaImporteDescuentoDespuesIVA = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltFacturaElectronicaImporteNeto
    ' Description: Importe neto
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property fltFacturaElectronicaImporteNeto() As String
        Get
            Return fltmFacturaElectronicaImporteNeto
        End Get
        Set(ByVal strValue As String)
            fltmFacturaElectronicaImporteNeto = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intEstadoFacturaElectronicaFolio
    ' Description: Folio de la factura
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intEstadoFacturaElectronicaFolio() As Integer
        Get
            Return intmEstadoFacturaElectronicaFolio
        End Get
        Set(ByVal intValue As Integer)
            intmEstadoFacturaElectronicaFolio = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : dtmEstadoFacturaElectronicaUltimaModificacion
    ' Description: Fecha de captura de la confirmacion
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property dtmEstadoFacturaElectronicaUltimaModificacion() As String
        Get
            Return dtmmEstadoFacturaElectronicaUltimaModificacion
        End Get
        Set(ByVal strValue As String)
            dtmmEstadoFacturaElectronicaUltimaModificacion = strValue
        End Set
    End Property

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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If


        ' Validamos que tenga los parametros necesarios para hacer la busqueda
        If intProveedorId > 0 AndAlso intFacturaElectronicaId > 0 Then

            Dim objDataArray As Array = Nothing
            Dim objRegistro As String() = Nothing

            ' Traemos la información de detalle
            objDataArray = clsConcentrador.clsSucursal.clsMercancia.clsFacturaElectronica.strBuscarConfirmacionFactura(intCompaniaId, intSucursalId, intProveedorId, intFacturaElectronicaId, "CONFIRMADA", strCadenaConexion)


            ' Validamos que se un arreglo válido
            If IsArray(objDataArray) Then
                If objDataArray.Length > 0 Then

                    objRegistro = DirectCast(objDataArray.GetValue(0), String())

                    ' Asignamos los valores a las propiedades

                    ' Número de Factura
                    strFacturaElectronicaNumero = CStr(objRegistro.GetValue(0))

                    ' Fecha de emisión de la factura 
                    dtmFacturaElectronicaEmisionDocumento = CDate(objRegistro.GetValue(1)).ToString("dd/MM/yyyy")

                    ' Número de Pedido
                    intFacturaElectronicaPedido = CInt(objRegistro.GetValue(2))

                    ' Importe Total
                    fltFacturaElectronicaImporteTotal = FormatCurrency(objRegistro.GetValue(3), 2)


                    ' Importe de iva
                    fltFacturaElectronicaImporteIVA = FormatCurrency(CDbl(objRegistro.GetValue(4)), 2)

                    ' Importe de iva del descuento
                    fltFacturaElectronicaImporteIVADescuento = FormatCurrency(CDbl(objRegistro.GetValue(5)), 2)

                    ' Descuento despues de IVA
                    fltFacturaElectronicaImporteDescuentoDespuesIVA = FormatCurrency(objRegistro.GetValue(6), 2)

                    ' Importe Neto
                    fltFacturaElectronicaImporteNeto = FormatCurrency(objRegistro.GetValue(7), 2)

                    ' Número de folio
                    intEstadoFacturaElectronicaFolio = CInt(objRegistro.GetValue(8))

                    ' Fecha y hora de la captura de la confirmación
                    dtmEstadoFacturaElectronicaUltimaModificacion = CDate(objRegistro.GetValue(9)).ToString("dd/MM/yyyy - hh:mm:ss  ")

                    ' Razón social de proveedor
                    strProveedorRazonSocial = CStr(objRegistro.GetValue(10))


                End If
            End If


        Else
            Call Response.Redirect("MercanciaConsultarFacturaRemision.aspx")
        End If

    End Sub

End Class
