'====================================================================
' Page          : MercanciaConfirmacionFacturaes.aspx
' Title         : Administracion POS y BackOffice
' Description   : Página donde confirma las Facturaes
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : J.Antonio Hernández Dávila
' Version       : 1.0
' Last Modified : Miercoles, Octubre 22, 2003
'====================================================================

Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class MercanciaConfirmacionFactura
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

    Private strmMensaje As String = ""

    Private strmProveedorRazonSocial As String = ""
    Private strmFacturaElectronicaNumero As String = ""
    Private dtmmFacturaElectronicaEmision As String = ""
    Private intmFacturaElectronicaPedido As Integer = 0
    Private fltmFacturaElectronicaImporteTotal As Double = 0
    Private fltmFacturaElectronicaImporteIVA As Double = 0
    Private fltmFacturaElectronicaImporteIVADescuento As Double = 0
    Private fltmFacturaElectronicaImporteDescuentoDespuesIVA As Double = 0
    Private fltmFacturaElectronicaImporteNeto As Double = 0
    Private strmConfirmada As String = ""
    Public intConfirmacion As Integer = 0


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
                Return ""
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


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        'Valor de entrada si no se reciben se regresa a la pagina padre
        If intProveedorId = 0 Or Len(intFacturaElectronicaId) = 0 Then
            Call Response.Redirect("MercanciaFacturasporConfirmar.aspx")
        End If


        Dim objArrayFactura As Array = Nothing
        Dim strRegistroFactura() As String = Nothing

        objArrayFactura = clsConcentrador.clsSucursal.clsMercancia.clsFacturaElectronica.strBuscarConfirmacionFactura(intCompaniaId, intSucursalId, intProveedorId, CInt(intFacturaElectronicaId), "GENERADA", strCadenaConexion)

        'Validamos la Respuesta
        If IsArray(objArrayFactura) AndAlso objArrayFactura.Length > 0 Then

            strRegistroFactura = DirectCast(objArrayFactura.GetValue(0), String())

            strFacturaElectronicaNumero = [String].Copy(clsCommons.strFormatearDescripcion(strRegistroFactura(0)).ToString)
            dtmFacturaElectronicaEmision = CDate([String].Copy(strRegistroFactura(1))).ToString("MM/dd/yyyy")
            intFacturaElectronicaPedido = CInt(strRegistroFactura(2))

            fltFacturaElectronicaImporteTotal = CDbl(strRegistroFactura(3))
            fltFacturaElectronicaImporteIVA = CDbl(strRegistroFactura(4))
            fltFacturaElectronicaImporteIVADescuento = CDbl(strRegistroFactura(5))
            fltFacturaElectronicaImporteDescuentoDespuesIVA = CDbl(strRegistroFactura(6))
            fltFacturaElectronicaImporteNeto = CDbl(strRegistroFactura(7))

            strProveedorRazonSocial = [String].Copy(clsCommons.strFormatearDescripcion(strRegistroFactura(10)).ToString)

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
                intConfirmacion = clsConcentrador.clsSucursal.clsMercancia.clsFacturaElectronica.intConfirmarFactura(intCompaniaId, intSucursalId, CInt(intFacturaElectronicaId), CDate(clsCommons.strDMYtoMDY(dtmRecepcionFacturaCapturada)), strUsuarioNombre, strCadenaConexion)

                If intConfirmacion > 0 Then
                    strMensaje = "Folio Confirmación Factura: " & intConfirmacion.ToString
                    strConfirmada = "1"
                Else
                    strMensaje = "Confirmación no puede realizarse"
                End If
            End If

        End If

    End Sub

End Class
