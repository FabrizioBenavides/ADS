
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class MercanciaConfirmacionFacturaPD
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

    Private strmMensaje As String = String.Empty

    Private strmProveedorRazonSocial As String = String.Empty

    Private strmFacturaElectronicaNumero As String = String.Empty
    Private dtmmFacturaElectronicaEmision As String = String.Empty
    Private intmFacturaElectronicaPedido As Integer = 0
    Private intmFacturaElectronicaCompraDirectaRemision As Integer = 0

    Private intmRemisionCompraDirectaFolio As Integer = 0
    Private strmRemisionCompraDirectaNumeroDocumento As String = String.Empty

    Private fltmFacturaElectronicaImporteTotal As Double = 0
    Private fltmFacturaElectronicaImporteIVA As Double = 0
    Private fltmFacturaElectronicaImporteIVADescuento As Double = 0
    Private fltmFacturaElectronicaImporteDescuentoDespuesIVA As Double = 0
    Private fltmFacturaElectronicaImporteNeto As Double = 0
    Private fltmFacturaElectronicaImporteIEPS As Double = 0

    Private strmError As String = String.Empty
    Private strmConfirmada As String = String.Empty

    Private intRenglonesxPagina As Integer = 42
    Private intmCompraDirectaFolio As Integer
    'Private strmProveedorNombreId As String
    Private intmFolioOrdenId As Integer
    Private strmCompraDirectaNumeroFactura As String
    Private strmCompraDirectaFechaFactura As String
    Private strmCompraDirectaFechaRecepcion As String
    Private fltmCompraDirectaImporteTotalFactura As String

    Public intConfirmacion As Integer = 0

    Public strImpresionCompra As String

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
            Return Request.ServerVariables("SCRIPT_NAME") & "?intProveedorId=" & intProveedorId.ToString & "&intFacturaElectronicaId=" & intFacturaElectronicaId
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
    ' Name       : intProveedorId
    ' Description: Id del Proveedor de la Factura a Confirmar
    ' Accessor   : Read
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
    ' Description: Id de la Factura a Confirmar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intFacturaElectronicaId() As String
        Get
            If Not IsNothing(Request.QueryString("intFacturaElectronicaId")) Then
                Return Trim(Request.QueryString("intFacturaElectronicaId"))
            Else
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmRecepcionFactura
    ' Description: Fecha de Recepcion Capturada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================  
    Public ReadOnly Property dtmRecepcionFacturaCapturada() As String
        Get
            Return Request.Form("dtmRecepcionFactura")
        End Get
    End Property

    '====================================================================
    ' Name       : strNumeroFacturaCapturada
    ' Description: Numero de Factura Capturada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================  
    Public ReadOnly Property strNumeroFacturaCapturada() As String
        Get
            Return Trim(Request.Form("txtNumeroFactura"))
        End Get
    End Property

    '====================================================================
    ' Name       : dtmEmisionFacturaCapturada
    ' Description: Fecha de Emison Factura Capturada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================  
    Public ReadOnly Property dtmEmisionFacturaCapturada() As String
        Get
            Return Request.Form("dtmEmisionFactura")
        End Get
    End Property

    '====================================================================
    ' Name       : dblMontoNetoCapturado
    ' Description: Neto Facturado Capturada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================  
    Public ReadOnly Property dblMontoNetoCapturado() As String
        Get
            Return Trim(Request.Form("txtMontoNetoFactura"))
        End Get
    End Property

	'====================================================================
    ' Name       : intNotaEntradaCapturada
    ' Description: Neto Facturado Capturada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================  
    Public ReadOnly Property intNotaEntradaCapturada() As String
        Get
            Return Trim(Request.Form("txtNotaEntrada"))
        End Get
    End Property


    '====================================================================
    ' Name       : strProveedorRazonSocial
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================  
    Public Property strProveedorRazonSocial() As String
        Get
            Return strmProveedorRazonSocial
        End Get
        Set(ByVal Value As String)
            strmProveedorRazonSocial = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strFacturaElectronicaNumero
    ' Description: Numero de Factura Electronica Consultada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================  
    Public Property strFacturaElectronicaNumero() As String
        Get
            Return strmFacturaElectronicaNumero
        End Get
        Set(ByVal Value As String)
            strmFacturaElectronicaNumero = Value
        End Set
    End Property

    '====================================================================
    ' Name       : dtmFacturaElectronicaEmision
    ' Description: Fecha de Emision de la Factura Electronica Consultada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '====================================================================  
    Public Property dtmFacturaElectronicaEmision() As String
        Get
            Return dtmmFacturaElectronicaEmision
        End Get
        Set(ByVal Value As String)
            dtmmFacturaElectronicaEmision = Value
        End Set
    End Property


    '====================================================================
    ' Name       : intFacturaElectronicaPedido
    ' Description: Numero de Pedido de la Factura Electronica Consultada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '==================================================================== 
    Public Property intFacturaElectronicaPedido() As Integer
        Get
            Return intmFacturaElectronicaPedido
        End Get
        Set(ByVal Value As Integer)
            intmFacturaElectronicaPedido = Value
        End Set
    End Property

    '====================================================================
    ' Name       : intRemisionCompraDirectaFolio
    ' Description:  
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intRemisionCompraDirectaFolio() As Integer
        Get
            Return intmRemisionCompraDirectaFolio
        End Get
        Set(ByVal strValue As Integer)
            intmRemisionCompraDirectaFolio = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRemisionCompraDirectaNumeroDocumento
    ' Description:  
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRemisionCompraDirectaNumeroDocumento() As String
        Get
            Return strmRemisionCompraDirectaNumeroDocumento
        End Get
        Set(ByVal strValue As String)
            strmRemisionCompraDirectaNumeroDocumento = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltFacturaElectronicaImporteTotal
    ' Description: Importe Total de la Factura Electronica Consultada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '==================================================================== 
    Public Property fltFacturaElectronicaImporteTotal() As Double
        Get
            Return fltmFacturaElectronicaImporteTotal
        End Get
        Set(ByVal Value As Double)
            fltmFacturaElectronicaImporteTotal = Value
        End Set
    End Property

    '====================================================================
    ' Name       : fltFacturaElectronicaImporteIVA
    ' Description: Importe IVA de la Factura Electronica Consultada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '==================================================================== 
    Public Property fltFacturaElectronicaImporteIVA() As Double
        Get
            Return fltmFacturaElectronicaImporteIVA
        End Get
        Set(ByVal Value As Double)
            fltmFacturaElectronicaImporteIVA = Value
        End Set
    End Property

    '====================================================================
    ' Name       : fltFacturaElectronicaImporteIVADescuento
    ' Description: Importe IVADESCUENTO de la Factura Electronica Consultada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '==================================================================== 
    Public Property fltFacturaElectronicaImporteIVADescuento() As Double
        Get
            Return fltmFacturaElectronicaImporteIVADescuento
        End Get
        Set(ByVal Value As Double)
            fltmFacturaElectronicaImporteIVADescuento = Value
        End Set
    End Property

    '====================================================================
    ' Name       : fltFacturaElectronicaImporteDescuentoDespuesIVA
    ' Description: Descuento Despues de  IVA de la Factura Electronica Consultada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '==================================================================== 
    Public Property fltFacturaElectronicaImporteDescuentoDespuesIVA() As Double
        Get
            Return fltmFacturaElectronicaImporteDescuentoDespuesIVA
        End Get
        Set(ByVal Value As Double)
            fltmFacturaElectronicaImporteDescuentoDespuesIVA = Value
        End Set
    End Property

    '====================================================================
    ' Name       : fltFacturaElectronicaImporteIEPS
    ' Description: IEPS faturado de la Factura Electronica Consultada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '==================================================================== 
    Public Property fltFacturaElectronicaImporteIEPS() As Double
        Get
            Return fltmFacturaElectronicaImporteIEPS
        End Get
        Set(ByVal Value As Double)
            fltmFacturaElectronicaImporteIEPS = Value
        End Set
    End Property

    '====================================================================
    ' Name       : fltFacturaElectronicaImporteNeto
    ' Description: Importe Neto de la Factura Electronica Consultada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '==================================================================== 
    Public Property fltFacturaElectronicaImporteNeto() As Double
        Get
            Return fltmFacturaElectronicaImporteNeto
        End Get
        Set(ByVal Value As Double)
            fltmFacturaElectronicaImporteNeto = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strMensaje
    ' Description: Fecha de Emision de la Factura Electronica Consultada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '====================================================================  
    Public Property strMensaje() As String
        Get
            Return strmMensaje
        End Get
        Set(ByVal Value As String)
            strmMensaje = Value
        End Set
    End Property


    '====================================================================
    ' Name       : strConfirmada
    ' Description: Para validar en la pagina si ya se hizo confirmación
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '====================================================================  
    Public Property strConfirmada() As String
        Get
            Return strmConfirmada
        End Get
        Set(ByVal Value As String)
            strmConfirmada = Value
        End Set
    End Property


    '====================================================================
    ' Name       : strConfirmada
    ' Description: Para validar en la pagina si ya se hizo confirmación
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '====================================================================  
    Public Property strError() As String
        Get
            Return strmError
        End Get
        Set(ByVal Value As String)
            strmError = Value
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        'Valor de entrada si no se reciben se regresa a la pagina padre
        If intProveedorId = 0 Or Len(intFacturaElectronicaId) = 0 Then
            Call Response.Redirect("MercanciaFacturasporConfirmarPD.aspx")
        End If


        Dim objArrayFactura As Array = Nothing
        Dim strRegistroFactura() As String = Nothing

        objArrayFactura = clsConcentrador.clsSucursal.clsMercancia.clsCompras.clsFacturaElectronica.strBuscarConfirmacionFactura(intCompaniaId, intSucursalId, intProveedorId, CInt(intFacturaElectronicaId), "POR CONFIRMAR", "GENERADA CON ERROR", strCadenaConexion)

        'Validamos la Respuesta
        If IsArray(objArrayFactura) AndAlso objArrayFactura.Length > 0 Then

            strRegistroFactura = DirectCast(objArrayFactura.GetValue(0), String())

            If CInt(strRegistroFactura(13)) > 0 Then ' Columna de error

                Dim objArrayError As Array = Nothing
                Dim strRegistroError() As String = Nothing

                objArrayError = clsConcentrador.clsSucursal.clsMercancia.clsCompras.clsFacturaElectronica.strBuscarError(CInt(strRegistroFactura(13)), strCadenaConexion)
                strRegistroError = DirectCast(objArrayError.GetValue(0), String())

                strError = strRegistroError(1)

            End If

            strFacturaElectronicaNumero = [String].Copy(clsCommons.strFormatearDescripcion(strRegistroFactura(0)).ToString)
            dtmFacturaElectronicaEmision = CDate([String].Copy(strRegistroFactura(1))).ToString("MM/dd/yyyy")
            intFacturaElectronicaPedido = CInt(strRegistroFactura(2))

            fltFacturaElectronicaImporteTotal = CDbl(strRegistroFactura(3))
            fltFacturaElectronicaImporteIVA = CDbl(strRegistroFactura(4))
            fltFacturaElectronicaImporteIVADescuento = CDbl(strRegistroFactura(5))
            fltFacturaElectronicaImporteDescuentoDespuesIVA = CDbl(strRegistroFactura(6))
            fltFacturaElectronicaImporteNeto = CDbl(strRegistroFactura(7))

            strProveedorRazonSocial = [String].Copy(clsCommons.strFormatearDescripcion(strRegistroFactura(10)).ToString)
            intRemisionCompraDirectaFolio = CInt(strRegistroFactura(11))
            strRemisionCompraDirectaNumeroDocumento = CStr(strRegistroFactura(12))

            fltmFacturaElectronicaImporteIEPS = CDbl(strRegistroFactura(14))

        End If

        If Len(Request("cmdConfirmar")) > 0 Then
            Dim blnConfirma As Boolean = True

            If CDate(clsCommons.strDMYtoMDY(dtmRecepcionFacturaCapturada)) > CDate(Date.Now.ToString("MM/dd/yyyy")) Then
                strMensaje = "Fecha de Recepción no Puede ser mayor al día de Hoy"
                blnConfirma = False
            End If

            If CDate(clsCommons.strDMYtoMDY(dtmEmisionFacturaCapturada)) > CDate(clsCommons.strDMYtoMDY(dtmRecepcionFacturaCapturada)) Then
                strMensaje = "Fecha de Factura no puede ser mayor a la Fecha de Recepción"
                blnConfirma = False
            End If

            If blnConfirma Then

                objArrayFactura = clsConcentrador.clsSucursal.clsMercancia.clsCompras.clsFacturaElectronica.strBuscarFactura(intCompaniaId, intSucursalId, intProveedorId, strFacturaElectronicaNumero, strCadenaConexion)

                If IsArray(objArrayFactura) AndAlso objArrayFactura.Length = 0 Then

                    intConfirmacion = clsConcentrador.clsSucursal.clsMercancia.clsCompras.clsFacturaElectronica.intConfirmarFactura(intCompaniaId, intSucursalId, CInt(intFacturaElectronicaId), CDate(clsCommons.strDMYtoMDY(dtmRecepcionFacturaCapturada)), strUsuarioNombre, strCadenaConexion)

                    If intConfirmacion > 0 Then

                        strMensaje = "Folio Confirmación Factura: " & intConfirmacion.ToString
                        strConfirmada = "1"


                        '-------------------------------------------------------------------------------------------------------------------
                        objArrayFactura = clsConcentrador.clsSucursal.clsMercancia.clsCompras.clsFacturaElectronica.strBuscarFactura(intCompaniaId, intSucursalId, intProveedorId, strFacturaElectronicaNumero, strCadenaConexion)
                        strRegistroFactura = DirectCast(objArrayFactura.GetValue(0), String())

                        Dim objArrayComprasDirectas As Array = clsConcentrador.clsSucursal.clsMercancia.clsCompras.strBuscar(intCompaniaId, intSucursalId, CInt(strRegistroFactura(0)), 0, 0, "Todas", 0, 0, strCadenaConexion)

                        If IsArray(objArrayComprasDirectas) AndAlso objArrayComprasDirectas.Length > 0 Then

                            Dim strRegistroComprasDirecta As String() = DirectCast(objArrayComprasDirectas.GetValue(0), String())


                            intCompraDirectaFolio = CInt(strRegistroComprasDirecta(2))
                            intCompraDirectaFolio = intConfirmacion
                            intFolioOrdenId = CInt(strRegistroComprasDirecta(10))

                            strCompraDirectaNumeroFactura = strRegistroComprasDirecta(4)
                            strCompraDirectaFechaFactura = clsCommons.strFormatearFechaPresentacion(strRegistroComprasDirecta(5))
                            strCompraDirectaFechaRecepcion = clsCommons.strFormatearFechaPresentacion(strRegistroComprasDirecta(3))
                            fltCompraDirectaImporteTotalFactura = clsCommons.strFormatearNumeroPresentacion(strRegistroComprasDirecta(6), True)

                            'strRegistroFactura = DirectCast(objArrayFactura.GetValue(0), String())
                            Dim objDetalleCompra As Array = clsConcentrador.clsSucursal.clsMercancia.clsCompras.strBuscarDetalle(intCompaniaId, intSucursalId, CInt(strRegistroFactura(0)), strCadenaConexion)

                            strImpresionCompra = strGeneraImpresionCompra(objDetalleCompra)

                        End If
                        '-------------------------------------------------------------------------------------------------------------------


                    Else
                        strMensaje = "Confirmación no puede realizarse"
                    End If

                Else
                    strMensaje = "La factura ya había sido confirmada con anterioridad."

                End If

            End If

        End If

    End Sub






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
        strHtmlEncabezado.Append("<td width='49%' align='left'  colspan='2' class='tdtxtImpresionBold'>Proveedor: " & strProveedorRazonSocial & "</td>") 'strProveedorNombreId & " - " & strProveedorRazonSocial
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







End Class
