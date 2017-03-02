Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration

Public Class clsMercanciaDetalleRemisionConfirmada
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

    Private strmRemisionElectronicaNumero As String
    Private dtmmRemisionElectronicaEmisionDocumento As String
    Private strmProveedorRazonSocial As String
    Private fltmRemisionElectronicaImporteTotal As String
    Private fltmRemisionElectronicaImporteIVA As String
    Private fltmRemisionElectronicaImporteIVADescuento As String
    Private fltmRemisionElectronicaImporteDescuentoDespuesIVA As String
    Private fltmRemisionElectronicaImporteNeto As String
    Private intmEstadoRemisionElectronicaFolio As Integer
    Private dtmmEstadoRemisionElectronicaUltimaModificacion As String


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
    ' Name       : intRemisionElectronicaId
    ' Description: Número identificador de la Remision
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intRemisionElectronicaId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intRemisionElectronicaId")) Then
                Return CInt(Request.QueryString("intRemisionElectronicaId"))
            Else
                Return 0
            End If
        End Get
    End Property
    '====================================================================
    ' Name       : strRemisionElectronicaNumero
    ' Description: Número de Remisión electronica
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRemisionElectronicaNumero() As String
        Get
            Return strmRemisionElectronicaNumero
        End Get
        Set(ByVal strValue As String)
            strmRemisionElectronicaNumero = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : dtmRemisionElectronicaEmisionDocumento
    ' Description: Fecha de remisión
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property dtmRemisionElectronicaEmisionDocumento() As String
        Get
            Return dtmmRemisionElectronicaEmisionDocumento
        End Get
        Set(ByVal strValue As String)
            dtmmRemisionElectronicaEmisionDocumento = strValue
        End Set
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
    ' Name       : fltRemisionElectronicaImporteTotal
    ' Description: Importe total de la remision
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property fltRemisionElectronicaImporteTotal() As String
        Get
            Return fltmRemisionElectronicaImporteTotal
        End Get
        Set(ByVal strValue As String)
            fltmRemisionElectronicaImporteTotal = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : fltRemisionElectronicaImporteIVA
    ' Description: Importe del IVA
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property fltRemisionElectronicaImporteIVA() As String
        Get
            Return fltmRemisionElectronicaImporteIVA
        End Get
        Set(ByVal strValue As String)
            fltmRemisionElectronicaImporteIVA = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : fltRemisionElectronicaImporteIVADescuento
    ' Description: Importe del IVA del descuento
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property fltRemisionElectronicaImporteIVADescuento() As String
        Get
            Return fltmRemisionElectronicaImporteIVADescuento
        End Get
        Set(ByVal strValue As String)
            fltmRemisionElectronicaImporteIVADescuento = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : fltRemisionElectronicaImporteDescuentoDespuesIVA
    ' Description: Importe de descuento después del IVA
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property fltRemisionElectronicaImporteDescuentoDespuesIVA() As String
        Get
            Return fltmRemisionElectronicaImporteDescuentoDespuesIVA
        End Get
        Set(ByVal strValue As String)
            fltmRemisionElectronicaImporteDescuentoDespuesIVA = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : fltRemisionElectronicaImporteNeto
    ' Description: Importe neto
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property fltRemisionElectronicaImporteNeto() As String
        Get
            Return fltmRemisionElectronicaImporteNeto
        End Get
        Set(ByVal strValue As String)
            fltmRemisionElectronicaImporteNeto = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : intEstadoRemisionElectronicaFolio
    ' Description: Folio de la remisión
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intEstadoRemisionElectronicaFolio() As Integer
        Get
            Return intmEstadoRemisionElectronicaFolio
        End Get
        Set(ByVal intValue As Integer)
            intmEstadoRemisionElectronicaFolio = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : dtmEstadoRemisionElectronicaUltimaModificacion
    ' Description: Fecha de captura de la confirmacion
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property dtmEstadoRemisionElectronicaUltimaModificacion() As String
        Get
            Return dtmmEstadoRemisionElectronicaUltimaModificacion
        End Get
        Set(ByVal strValue As String)
            dtmmEstadoRemisionElectronicaUltimaModificacion = strValue
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
        If intProveedorId > 0 AndAlso intRemisionElectronicaId > 0 Then
            Dim objDataArray As Array = Nothing
            Dim objRegistro As String() = Nothing

            ' Traemos la información de detalle
            objDataArray = clsConcentrador.clsSucursal.clsMercancia.clsRemisionElectronica.strBuscarConfirmacionRemision(intCompaniaId, intSucursalId, intProveedorId, intRemisionElectronicaId, "CONFIRMADA", strCadenaConexion)


            ' Validamos que se un arreglo válido
            If IsArray(objDataArray) Then
                If objDataArray.Length > 0 Then

                    objRegistro = DirectCast(objDataArray.GetValue(0), String())

                    ' Asignamos los valores a las propiedades

                    ' Número de Remision
                    strRemisionElectronicaNumero = CStr(objRegistro.GetValue(0))

                    ' Fecha de emisión de la factura 
                    dtmRemisionElectronicaEmisionDocumento = CDate(objRegistro.GetValue(1)).ToString("dd/MM/yyyy")

                    ' Razón social de proveedor
                    strProveedorRazonSocial = CStr(objRegistro.GetValue(2))

                    ' Importe Total
                    fltRemisionElectronicaImporteTotal = FormatCurrency(objRegistro.GetValue(3), 2)


                    ' Importe de iva
                    fltRemisionElectronicaImporteIVA = FormatCurrency(CDbl(objRegistro.GetValue(4)), 2)

                    ' Importe de iva del descuento
                    fltRemisionElectronicaImporteIVADescuento = FormatCurrency(CDbl(objRegistro.GetValue(5)), 2)

                    ' Descuento despues de IVA
                    fltRemisionElectronicaImporteDescuentoDespuesIVA = FormatCurrency(objRegistro.GetValue(6), 2)

                    ' Importe Neto
                    fltRemisionElectronicaImporteNeto = FormatCurrency(objRegistro.GetValue(7), 2)

                    ' Número de folio
                    intEstadoRemisionElectronicaFolio = CInt(objRegistro.GetValue(8))

                    ' Fecha y hora de la captura de la confirmación
                    dtmEstadoRemisionElectronicaUltimaModificacion = CDate(objRegistro.GetValue(9)).ToString("dd/MM/yyyy - hh:mm:ss")


                End If
            End If


        Else
            Call Response.Redirect("MercanciaConsultarFacturaRemision.aspx")
        End If

    End Sub

End Class
