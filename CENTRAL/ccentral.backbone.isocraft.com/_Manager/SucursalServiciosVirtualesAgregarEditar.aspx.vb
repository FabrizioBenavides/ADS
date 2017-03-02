Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert

Public Class SucursalServiciosVirtualesAgregarEditar
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

        'Inicializa Propiedades
        intTipoServicioVirtualId = GetPageParameter("intTipoServicioId", 0)
        intServicioVirtualId = GetPageParameter("intServicioID", 0)
        intServicioVirtualDatoAdicionalIdEliminar = GetPageParameter("intCampoId", 0)

        'CJBG
        intServicioVirtualCampoVariableIdEliminar = GetPageParameter("intServicioVirtualCampoVariableId", 0)

        'JPMB
        intServicioVirtualFormaPagoIdEliminar = GetPageParameter("intFormaPagoId", 0)

        'SOFTTEK-LFLJ-10/OCT/2013
        'ServicioVirtual-Tienda
        intServicioVirtualCompaniaIdEliminar = GetPageParameter("intCompaniaId", 0)
        intServicioVirtualSucursalIdEliminar = GetPageParameter("intSucursalId", 0)
        blnServicioVirtualTiendaEliminarTienda = CBool(GetPageParameter("blnEliminarTienda", 0))

    End Sub

#End Region

#Region " Class Private Attributes"

    Private intmTipoServicioVirtualId As Integer
    Private strmTipoServicioVirtualDescripcion As String
    Private intmServicioVirtualDatoAdicionalIdGuardar As Integer
    Private intmServicioVirtualDatoAdicionalIdEliminar As Integer
    Private intmServicioVirtualId As Integer
    Private strmServicioVirtualCodigoProducto As String
    Private strmJavascriptWindowOnLoadCommands As String
    Private fltmServicioVirtualMontoMaximo As Double
    Private strmServicioVirtualLeyendaOperacionExitosa As String
    Private blnmServicioVirtualConfirmarOperacionExitosa As Boolean
    Private intmServicioVirtualClaveImpresionCancelacion As Integer
    Private blnmServicioVirtualImprimirTicketCancelacion As Boolean
    Private blnmServicioVirtualReversa As Boolean
    Private strmServicioVirtualCamposNoAlmacenados As String
    Private strmServicioVirtualCampoCantidad As String
    Private strmServicioVirtualCampoImporte As String
    Private strmServicioVirtualCampoMonto As String
    Private strmServicioVirtualCampoAutorizacion As String
    Private strmServicioVirtualCampoReferencia As String
    Private blnmServicioVirtualDesgloseImpuesto As Boolean
    Private blnmServicioVirtualReImpresion As Boolean
    Private intmServicioVirtualClaveImpresion As Integer
    Private intmServicioVirtualTransaccionCTFComisionFPImpuestoFronteraId As Integer
    Private intmServicioVirtualTransaccionCTFComisionFPImpuestoInteriorId As Integer
    Private intmServicioVirtualTransaccionCTFComisionFPSinImpuesto As Integer
    Private intmServicioVirtualTransaccionCTFComisionId As Integer
    Private fltmServicioVirtualComision As Double

    ' stkIUSACFE 10/07/2013 CJBG - Agregando nueva variable local de comisión del integrador
    Private blnmServicioVirtualSeparaComisionIntegrador As Boolean
    Private intmServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoFronteraId As Integer
    Private intmServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoInteriorId As Integer
    Private intmServicioVirtualTransaccionCTFComisionIntegradorFPSinImpuesto As Integer
    Private intmServicioVirtualTransaccionCTFComisionIntegradorId As Integer
    Private fltmServicioVirtualComisionIntegrador As Double

    Private intmServicioVirtualTransaccionCTFCampoCompuestoLongitud As Integer
    Private intmServicioVirtualTransaccionCTFCampoCompuestoId As Integer
    Private intmServicioVirtualTransaccionCTFId As Integer
    Private intmArticuloId As Integer
    Private intmTipoTicketId As Integer
    Private intmTipoMovimientoServicioVirtualId As Integer
    Private strmServicioVirtualDescripcion As String
    Private strmServicioVirtualDatoAdicionalNombre As String

    'STKLDI 26/06/2012 CJBG - Agregando nuevas variables locales para manejar los nuevos campos de LDI
    Private blnmIntegradorServicioVirtualIdCambio As Boolean

    Private blnmServicioVirtualValidarSupervisor As Boolean
    Private intmIntegradorServicioVirtualId As Integer
    Private blnmServicioVirtualCampoVariableSolicitadoEnPOS As Boolean
    Private strmServicioVirtualCampoVariableDescripcion As String
    Private strmServicioVirtualCampoVariableValor As String
    Private intmServicioVirtualCampoVariableNumeroCaracteres As Integer
    Private intmServicioVirtualCampoVariableLDITipoId As Integer
    Private intmServicioVirtualCampoVariableLDISubtipoId As Integer
    Private strmServicioVirtualCampoVariableTipo As String
    Private strmServicioVirtualCampoVariablePropiedad As String
    Private intmServicioVirtualCampoVariableDiasVencimiento As Integer
    Private intmServicioVirtualCampoVariableIdEliminar As Integer

    ' STKTARJETASDEREGALO
    ' JPMB - Agregando las variables locales para el manejo de los campos De Tarjetas de Regalo.

    Private blnmServicioVirtualFacturaVenta As Boolean
    Private blnmServicioVirtualFacturaAplicaComision As Boolean
    Private blnmServicioVirtualTarjetaActiva As Boolean
    Private strmServicioVirtualTextoTicket As String
    Private intmFormaDePagoId As Integer
    Private strmFormaDePagoDescripcion As String
    Private intmServicioVirtualFormaPagoIdEliminar As Integer

    'SOFTTEK-LFLJ-10/OCT/2013
    'ServicioVirtual-Tienda
    Private intmServicioVirtualCompaniaIdEliminar As Integer
    Private intmServicioVirtualSucursalIdEliminar As Integer
    Private intmDireccionOperativaId As Integer
    Private intmZonaOperativaId As Integer
    Private blnmServicioVirtualTiendaEliminarTienda As Boolean

#End Region

    Public Sub New()

    End Sub

    '====================================================================
    ' Name       : strFormAction
    ' Description: HTML form's action property value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormAction() As String
        Get
            Return strThisPageName
        End Get
    End Property

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Connection string
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Private ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: Name of this page
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return Server.UrlEncode(GetPageName())
        End Get
    End Property
    '====================================================================
    ' Name       : intGrupoUsuarioId
    ' Description: Identificador del Grupo de Usuario
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intGrupoUsuarioId() As Integer
        Get
            Return CInt(Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strHTMLFechaHora
    ' Description: Genera la fecha y hora de la página
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
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
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd", "Editar")
            'Return GetPageParameter("strCmd", "Editar")
        End Get
    End Property

    '====================================================================
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strJavascriptWindowOnLoadCommands() As String
        Get
            Return strmJavascriptWindowOnLoadCommands
        End Get
        Set(ByVal strValue As String)
            strmJavascriptWindowOnLoadCommands = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strBuscarCodigosProductos
    ' Description: Busca un codigo de producto
    ' Accessor   : Read / Write
    ' Output     : cadena formateada codigo|codigo|codigo|...codigo
    '====================================================================
    Public ReadOnly Property strBuscarCodigosProductos() As String
        Get
            Dim arrCodigos As Array
            Dim strCadena As String
            Dim i As Integer

            If strCmd = "Editar" Then
                'Se buscan todos los codigos excepto el codigo que ya tiene este servicio virtual
                arrCodigos = Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtual.strBuscarCodigosProductos(intServicioVirtualId, strConnectionString)
            Else
                'Se buscan todos los codigos
                arrCodigos = Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtual.strBuscarCodigosProductos(0, strConnectionString)
            End If

            If IsNothing(arrCodigos) = False AndAlso arrCodigos.Length > 0 Then
                'Formamos la cadena con los valores de los codigos separados con un |
                For i = 0 To arrCodigos.Length - 1
                    If CStr(CType(arrCodigos.GetValue(i), String()).GetValue(0)) <> "" Then
                        If i = 0 Then
                            strCadena = CStr(CType(arrCodigos.GetValue(i), String()).GetValue(0))
                        Else
                            strCadena = strCadena & "|" & CStr(CType(arrCodigos.GetValue(i), String()).GetValue(0))
                        End If
                    End If
                Next
            End If

            Return strCadena
        End Get
    End Property

    '====================================================================
    ' Name       : strBuscarIdsDatosAdicionales
    ' Description: Busca los ids de los datos adicionales
    ' Accessor   : Read / Write
    ' Output     : Cadena formateada id|id|id|...id
    '====================================================================
    Public ReadOnly Property strBuscarIdsDatosAdicionales() As String
        Get
            Dim arrIds As Array
            Dim strCadena As String
            Dim i As Integer

            arrIds = Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtualDatoAdicional.intBuscarIdsDatosAdicionales(intServicioVirtualId, strConnectionString)

            If IsNothing(arrIds) = False AndAlso arrIds.Length > 0 Then
                'Formamos la cadena con los valores de los ids separados con un |
                For i = 0 To arrIds.Length - 1
                    If CStr(CType(arrIds.GetValue(i), String()).GetValue(0)) <> "" Then
                        If i = 0 Then
                            strCadena = CStr(CType(arrIds.GetValue(i), String()).GetValue(0))
                        Else
                            strCadena = strCadena & "|" & CStr(CType(arrIds.GetValue(i), String()).GetValue(0))
                        End If
                    End If
                Next
            End If

            Return strCadena

        End Get
    End Property

    '====================================================================
    ' Name       : intTipoServicioVirtualId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intTipoServicioVirtualId() As Integer
        Get
            If intmTipoServicioVirtualId = 0 Then
                intmTipoServicioVirtualId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intTipoServicioId", "0"))
            End If
            Return intmTipoServicioVirtualId
        End Get
        Set(ByVal intValue As Integer)
            intmTipoServicioVirtualId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intServicioVirtualDatoAdicionalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualDatoAdicionalIdGuardar() As Integer
        Get
            If intmServicioVirtualDatoAdicionalIdGuardar = 0 Then
                If Request.Form("txtCampoId") = "" Then
                    'No hacer nada
                Else
                    intmServicioVirtualDatoAdicionalIdGuardar = CInt(Request.Form("txtCampoId"))
                End If

            End If
            Return intmServicioVirtualDatoAdicionalIdGuardar
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualDatoAdicionalIdGuardar = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intServicioVirtualDatoAdicionalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualDatoAdicionalIdEliminar() As Integer
        Get
            If intmServicioVirtualDatoAdicionalIdEliminar = 0 Then
                intmServicioVirtualDatoAdicionalIdEliminar = CInt(isocraft.commons.clsWeb.strGetPageParameter("intCampoId", "0"))
            End If
            Return intmServicioVirtualDatoAdicionalIdEliminar
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualDatoAdicionalIdEliminar = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoServicioVirtualDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTipoServicioVirtualDescripcion() As String
        Get
            If strmTipoServicioVirtualDescripcion = Nothing Then
                strmTipoServicioVirtualDescripcion = Request.Form("txtTipoServicioVirtualDescripcion")
            End If
            Return strmTipoServicioVirtualDescripcion
        End Get
        Set(ByVal strValue As String)
            strmTipoServicioVirtualDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoServicioVirtualDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strServicioVirtualDatoAdicionalNombre() As String
        Get
            If strmServicioVirtualDatoAdicionalNombre = Nothing Then
                strmServicioVirtualDatoAdicionalNombre = Request.Form("txtNombreCampo")
            End If
            Return strmServicioVirtualDatoAdicionalNombre
        End Get
        Set(ByVal strValue As String)
            strmServicioVirtualDatoAdicionalNombre = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strServicioVirtualCodigoProducto
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strServicioVirtualCodigoProducto() As String
        Get
            If strmServicioVirtualCodigoProducto = Nothing Then
                strmServicioVirtualCodigoProducto = Request.Form("txtCodigoProducto")
            End If
            Return strmServicioVirtualCodigoProducto
        End Get
        Set(ByVal strValue As String)
            strmServicioVirtualCodigoProducto = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intServicioVirtualId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualId() As Integer
        Get
            If intmServicioVirtualId = 0 Then
                intmServicioVirtualId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intServicioID", "0"))
            End If
            Return intmServicioVirtualId
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strServicioVirtualDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strServicioVirtualDescripcion() As String
        Get
            If strmServicioVirtualDescripcion = Nothing Then
                strmServicioVirtualDescripcion = Request.Form("txtDescripcion")
            End If
            Return strmServicioVirtualDescripcion
        End Get
        Set(ByVal strValue As String)
            strmServicioVirtualDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intTipoMovimientoServicioVirtualId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intTipoMovimientoServicioVirtualId() As Integer
        Get
            If intmTipoMovimientoServicioVirtualId = 0 Then
                intmTipoMovimientoServicioVirtualId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboTipo", "0"))
            End If
            Return intmTipoMovimientoServicioVirtualId
        End Get
        Set(ByVal intValue As Integer)
            intmTipoMovimientoServicioVirtualId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intTipoTicketId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intTipoTicketId() As Integer
        Get
            If intmTipoTicketId = 0 Then
                intmTipoTicketId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboTipoTicket", "0"))
            End If
            Return intmTipoTicketId
        End Get
        Set(ByVal intValue As Integer)
            intmTipoTicketId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intArticuloId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intArticuloId() As Integer
        Get
            ' Devolvemos 0 ya que de momento no sera implementada esta funcionalidad.
            Return 0
        End Get
        Set(ByVal intValue As Integer)
            intmArticuloId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intServicioVirtualTransaccionCTFId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualTransaccionCTFId() As Integer
        Get
            If intmServicioVirtualTransaccionCTFId = 0 Then
                If Request.Form("txtTransaccionCTF") = "" Then
                    'No hacer nada
                Else
                    intmServicioVirtualTransaccionCTFId = CInt(Request.Form("txtTransaccionCTF"))
                End If
            End If
            Return intmServicioVirtualTransaccionCTFId
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualTransaccionCTFId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intServicioVirtualTransaccionCTFCampoCompuestoId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualTransaccionCTFCampoCompuestoId() As Integer
        Get
            If intmServicioVirtualTransaccionCTFCampoCompuestoId = 0 Then
                If Request.Form("txtCTFCampoCompuestoId") = "" Then
                    ' No hacer nada
                Else
                    intmServicioVirtualTransaccionCTFCampoCompuestoId = CInt(Request.Form("txtCTFCampoCompuestoId"))
                End If
            End If
            Return intmServicioVirtualTransaccionCTFCampoCompuestoId
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualTransaccionCTFCampoCompuestoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intServicioVirtualTransaccionCTFCampoCompuestoLongitud
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualTransaccionCTFCampoCompuestoLongitud() As Integer
        Get
            If intmServicioVirtualTransaccionCTFCampoCompuestoLongitud = 0 Then
                If Request.Form("txtCTFLongitudCampoCompuesto") = "" Then
                    'No hacer nada
                Else
                    intmServicioVirtualTransaccionCTFCampoCompuestoLongitud = CInt(Request.Form("txtCTFLongitudCampoCompuesto"))
                End If
            End If
            Return intmServicioVirtualTransaccionCTFCampoCompuestoLongitud
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualTransaccionCTFCampoCompuestoLongitud = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltServicioVirtualComision
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property fltServicioVirtualComision() As Double
        Get
            If fltmServicioVirtualComision = 0 Then
                If Request.Form("txtComision") = "" Then
                    'no hacer nada
                Else
                    fltmServicioVirtualComision = CDbl(Request.Form("txtComision"))
                End If
            End If
            Return fltmServicioVirtualComision
        End Get
        Set(ByVal dblValue As Double)
            fltmServicioVirtualComision = dblValue
        End Set
    End Property

    '====================================================================
    ' Name       : intServicioVirtualTransaccionCTFComisionId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualTransaccionCTFComisionId() As Integer
        Get
            If intmServicioVirtualTransaccionCTFComisionId = 0 Then
                If Request.Form("txtComisionCTF") = "" Then
                    'No hacer nada
                Else
                    intmServicioVirtualTransaccionCTFComisionId = CInt(Request.Form("txtComisionCTF"))
                End If
            End If
            Return intmServicioVirtualTransaccionCTFComisionId
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualTransaccionCTFComisionId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intServicioVirtualTransaccionCTFComisionFPSinImpuesto
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualTransaccionCTFComisionFPSinImpuesto() As Integer
        Get
            If intmServicioVirtualTransaccionCTFComisionFPSinImpuesto = 0 Then
                If Request.Form("txtComisionCTFsinImpuesto") = "" Then
                    'No hacer nada
                Else
                    intmServicioVirtualTransaccionCTFComisionFPSinImpuesto = CInt(Request.Form("txtComisionCTFsinImpuesto"))
                End If
            End If
            Return intmServicioVirtualTransaccionCTFComisionFPSinImpuesto
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualTransaccionCTFComisionFPSinImpuesto = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intServicioVirtualTransaccionCTFComisionFPImpuestoInteriorId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualTransaccionCTFComisionFPImpuestoInteriorId() As Integer
        Get
            If intmServicioVirtualTransaccionCTFComisionFPImpuestoInteriorId = 0 Then
                If Request.Form("txtComisionCTFinterior") = "" Then
                    'No hacer nada
                Else
                    intmServicioVirtualTransaccionCTFComisionFPImpuestoInteriorId = CInt(Request.Form("txtComisionCTFinterior"))
                End If
            End If
            Return intmServicioVirtualTransaccionCTFComisionFPImpuestoInteriorId
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualTransaccionCTFComisionFPImpuestoInteriorId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intServicioVirtualTransaccionCTFComisionFPImpuestoFronteraId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualTransaccionCTFComisionFPImpuestoFronteraId() As Integer
        Get
            If intmServicioVirtualTransaccionCTFComisionFPImpuestoFronteraId = 0 Then
                If Request.Form("txtComisionCTFfrontera") = "" Then
                    'No hacer nada
                Else
                    intmServicioVirtualTransaccionCTFComisionFPImpuestoFronteraId = CInt(Request.Form("txtComisionCTFfrontera"))
                End If
            End If
            Return intmServicioVirtualTransaccionCTFComisionFPImpuestoFronteraId
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualTransaccionCTFComisionFPImpuestoFronteraId = intValue
        End Set
    End Property

    ' stkIUSACFE CJBG 10/07/2013
    '====================================================================
    ' Name       : fltServicioVirtualComisionIntegrador
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Double
    '====================================================================
    Public Property fltServicioVirtualComisionIntegrador() As Double
        Get
            If fltmServicioVirtualComisionIntegrador = 0 Then
                If Request.Form("txtComisionIntegrador") = "" Then
                    'no hacer nada
                Else
                    fltmServicioVirtualComisionIntegrador = CDbl(Request.Form("txtComisionIntegrador"))
                End If
            End If
            Return fltmServicioVirtualComisionIntegrador
        End Get
        Set(ByVal dblValue As Double)
            fltmServicioVirtualComisionIntegrador = dblValue
        End Set
    End Property

    ' stkIUSACFE CJBG 07/08/2013
    '====================================================================
    ' Name       : intServicioVirtualTransaccionCTFComisionIntegradorId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualTransaccionCTFComisionIntegradorId() As Integer
        Get
            If intmServicioVirtualTransaccionCTFComisionIntegradorId = 0 Then
                If Request.Form("txtComisionIntegradorCTF") = "" Then
                    'No hacer nada
                Else
                    intmServicioVirtualTransaccionCTFComisionIntegradorId = CInt(Request.Form("txtComisionIntegradorCTF"))
                End If
            End If
            Return intmServicioVirtualTransaccionCTFComisionIntegradorId
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualTransaccionCTFComisionIntegradorId = intValue
        End Set
    End Property

    ' stkIUSACFE CJBG 07/08/2013
    '====================================================================
    ' Name       : intServicioVirtualTransaccionCTFComisionIntegradorFPSinImpuesto
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualTransaccionCTFComisionIntegradorFPSinImpuesto() As Integer
        Get
            If intmServicioVirtualTransaccionCTFComisionIntegradorFPSinImpuesto = 0 Then
                If Request.Form("txtComisionIntegradorCTFsinImpuesto") = "" Then
                    'No hacer nada
                Else
                    intmServicioVirtualTransaccionCTFComisionIntegradorFPSinImpuesto = CInt(Request.Form("txtComisionIntegradorCTFsinImpuesto"))
                End If
            End If
            Return intmServicioVirtualTransaccionCTFComisionIntegradorFPSinImpuesto
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualTransaccionCTFComisionIntegradorFPSinImpuesto = intValue
        End Set
    End Property

    ' stkIUSACFE CJBG 07/08/2013
    '====================================================================
    ' Name       : intServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoInteriorId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoInteriorId() As Integer
        Get
            If intmServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoInteriorId = 0 Then
                If Request.Form("txtComisionIntegradorCTFinterior") = "" Then
                    'No hacer nada
                Else
                    intmServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoInteriorId = CInt(Request.Form("txtComisionIntegradorCTFinterior"))
                End If
            End If
            Return intmServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoInteriorId
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoInteriorId = intValue
        End Set
    End Property

    ' stkIUSACFE CJBG 07/08/2013
    '====================================================================
    ' Name       : intServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoFronteraId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoFronteraId() As Integer
        Get
            If intmServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoFronteraId = 0 Then
                If Request.Form("txtComisionIntegradorCTFfrontera") = "" Then
                    'No hacer nada
                Else
                    intmServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoFronteraId = CInt(Request.Form("txtComisionIntegradorCTFfrontera"))
                End If
            End If
            Return intmServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoFronteraId
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoFronteraId = intValue
        End Set
    End Property

    ' stkIUSACFE CJBG 07/08/2013
    '====================================================================
    ' Name       : blnServicioVirtualSeparaComisionIntegradir
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property blnServicioVirtualSeparaComisionIntegrador() As Boolean
        Get
            If blnmServicioVirtualSeparaComisionIntegrador = Nothing Then
                blnmServicioVirtualSeparaComisionIntegrador = CBool(isocraft.commons.clsWeb.strGetPageParameter("chkSeparaComisionIntegrador", "0"))
            End If
            Return blnmServicioVirtualSeparaComisionIntegrador
        End Get
        Set(ByVal blnValue As Boolean)
            blnmServicioVirtualSeparaComisionIntegrador = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : intServicioVirtualClaveImpresion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualClaveImpresion() As Integer
        Get
            If intmServicioVirtualClaveImpresion = 0 Then
                If Request.Form("txtClaveImpresion") = "" Then
                    'No hacer nada
                Else
                    intmServicioVirtualClaveImpresion = CInt(Request.Form("txtClaveImpresion"))
                End If
            End If
            Return intmServicioVirtualClaveImpresion
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualClaveImpresion = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnServicioVirtualReImpresion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property blnServicioVirtualReImpresion() As Boolean
        Get
            If blnmServicioVirtualReImpresion = Nothing Then
                blnmServicioVirtualReImpresion = CBool(isocraft.commons.clsWeb.strGetPageParameter("chkReImpresion", "0"))
            End If
            Return blnmServicioVirtualReImpresion
        End Get
        Set(ByVal blnValue As Boolean)
            blnmServicioVirtualReImpresion = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnServicioVirtualDesgloseImpuesto
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property blnServicioVirtualDesgloseImpuesto() As Boolean
        Get
            If blnmServicioVirtualDesgloseImpuesto = Nothing Then
                blnmServicioVirtualDesgloseImpuesto = CBool(isocraft.commons.clsWeb.strGetPageParameter("chkDesglose", "0"))
            End If
            Return blnmServicioVirtualDesgloseImpuesto
        End Get
        Set(ByVal blnValue As Boolean)
            blnmServicioVirtualDesgloseImpuesto = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : strServicioVirtualLeyendaReferencia
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property strServicioVirtualLeyendaReferencia() As String
        Get
            If strmServicioVirtualCampoReferencia = Nothing Then
                strmServicioVirtualCampoReferencia = Request.Form("txtReferencia")
            End If
            Return strmServicioVirtualCampoReferencia
        End Get
        Set(ByVal strValue As String)
            strmServicioVirtualCampoReferencia = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strServicioVirtualCampoAutorizacion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property strServicioVirtualCampoAutorizacion() As String
        Get
            If strmServicioVirtualCampoAutorizacion = Nothing Then
                strmServicioVirtualCampoAutorizacion = Request.Form("txtAutorizacion")
            End If
            Return strmServicioVirtualCampoAutorizacion
        End Get
        Set(ByVal strValue As String)
            strmServicioVirtualCampoAutorizacion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strServicioVirtualCampoImporte
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property strServicioVirtualCampoImporte() As String
        Get
            If strmServicioVirtualCampoImporte = Nothing Then
                strmServicioVirtualCampoImporte = Request.Form("txtImporte")
            End If
            Return strmServicioVirtualCampoImporte
        End Get
        Set(ByVal strValue As String)
            strmServicioVirtualCampoImporte = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strServicioVirtualCampoMonto
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property strServicioVirtualCampoMonto() As String
        Get
            If strmServicioVirtualCampoMonto = Nothing Then
                strmServicioVirtualCampoMonto = Request.Form("txtMonto")
            End If
            Return strmServicioVirtualCampoMonto
        End Get
        Set(ByVal strValue As String)
            strmServicioVirtualCampoMonto = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strServicioVirtualCampoCantidad
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property strServicioVirtualCampoCantidad() As String
        Get
            If strmServicioVirtualCampoCantidad = Nothing Then
                strmServicioVirtualCampoCantidad = Request.Form("txtCantidad")
            End If
            Return strmServicioVirtualCampoCantidad
        End Get
        Set(ByVal strValue As String)
            strmServicioVirtualCampoCantidad = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strServicioVirtualCamposNoAlmacenados
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property strServicioVirtualCamposNoAlmacenados() As String
        Get
            If strmServicioVirtualCamposNoAlmacenados = Nothing Then
                strmServicioVirtualCamposNoAlmacenados = Request.Form("txtCamposNoAlmacenados")
            End If
            Return strmServicioVirtualCamposNoAlmacenados
        End Get
        Set(ByVal strValue As String)
            strmServicioVirtualCamposNoAlmacenados = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnServicioVirtualReversa
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property blnServicioVirtualReversa() As Boolean
        Get
            If blnmServicioVirtualReversa = Nothing Then
                blnmServicioVirtualReversa = CBool(isocraft.commons.clsWeb.strGetPageParameter("chkReversa", "0"))
            End If
            Return blnmServicioVirtualReversa
        End Get
        Set(ByVal blnValue As Boolean)
            blnmServicioVirtualReversa = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnServicioVirtualImprimirTicketCancelacion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property blnServicioVirtualImprimirTicketCancelacion() As Boolean
        Get
            If blnmServicioVirtualImprimirTicketCancelacion = Nothing Then
                blnmServicioVirtualImprimirTicketCancelacion = CBool(isocraft.commons.clsWeb.strGetPageParameter("chkImprimirCancelacion", "0"))
            End If
            Return blnmServicioVirtualImprimirTicketCancelacion
        End Get
        Set(ByVal blnValue As Boolean)
            blnmServicioVirtualImprimirTicketCancelacion = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : intServicioVirtualClaveImpresionCancelacion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualClaveImpresionCancelacion() As Integer
        Get
            If intmServicioVirtualClaveImpresionCancelacion = 0 Then
                If Request.Form("txtClaveCancelacion") = "" Then
                    'No hacer nada
                Else
                    intmServicioVirtualClaveImpresionCancelacion = CInt(Request.Form("txtClaveCancelacion"))
                End If
            End If
            Return intmServicioVirtualClaveImpresionCancelacion
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualClaveImpresionCancelacion = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnServicioVirtualConfirmarOperacionExitosa
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property blnServicioVirtualConfirmarOperacionExitosa() As Boolean
        Get
            If blnmServicioVirtualConfirmarOperacionExitosa = Nothing Then
                blnmServicioVirtualConfirmarOperacionExitosa = CBool(isocraft.commons.clsWeb.strGetPageParameter("chkOperacionExitosa", "0"))
            End If
            Return blnmServicioVirtualConfirmarOperacionExitosa
        End Get
        Set(ByVal blnValue As Boolean)
            blnmServicioVirtualConfirmarOperacionExitosa = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : strServicioVirtualLeyendaOperacionExitosa
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property strServicioVirtualLeyendaOperacionExitosa() As String
        Get
            If strmServicioVirtualLeyendaOperacionExitosa = Nothing Then
                strmServicioVirtualLeyendaOperacionExitosa = Request.Form("txtLeyendaExitosa")
            End If
            Return strmServicioVirtualLeyendaOperacionExitosa
        End Get
        Set(ByVal strValue As String)
            strmServicioVirtualLeyendaOperacionExitosa = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltServicioVirtualMontoMaximo
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property fltServicioVirtualMontoMaximo() As Double
        Get
            If fltmServicioVirtualMontoMaximo = 0 Then
                If Request.Form("txtMontoMaximoEgreso") = "" Then
                    'No hacer nada
                Else
                    fltmServicioVirtualMontoMaximo = CDbl(Request.Form("txtMontoMaximoEgreso"))
                End If
            End If
            Return fltmServicioVirtualMontoMaximo
        End Get
        Set(ByVal dblValue As Double)
            fltmServicioVirtualMontoMaximo = dblValue
        End Set
    End Property

    ' STKLDI CJBG 26/06/2012 Agregando valores de nuevos campos html en la forma
    '====================================================================
    ' Name       : blnIntegradorServicioVirtualIdCambio
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnIntegradorServicioVirtualIdCambio() As Boolean
        Get
            If blnmIntegradorServicioVirtualIdCambio = Nothing Then
                blnmIntegradorServicioVirtualIdCambio = CBool(isocraft.commons.clsWeb.strGetPageParameter("blnIntegradorServicioVirtualIdCambio", "0"))
            End If
            Return blnmIntegradorServicioVirtualIdCambio
        End Get
        Set(ByVal blnValue As Boolean)
            blnmIntegradorServicioVirtualIdCambio = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnServicioVirtualValidarSupervisor
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnServicioVirtualValidarSupervisor() As Boolean
        Get
            If blnmServicioVirtualValidarSupervisor = Nothing Then
                blnmServicioVirtualValidarSupervisor = CBool(isocraft.commons.clsWeb.strGetPageParameter("chkValidarSupervisor", "0"))
            End If
            Return blnmServicioVirtualValidarSupervisor
        End Get
        Set(ByVal blnValue As Boolean)
            blnmServicioVirtualValidarSupervisor = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : intIntegradorServicioVirtualId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intIntegradorServicioVirtualId() As Integer
        Get
            If intmIntegradorServicioVirtualId = 0 Then
                intmIntegradorServicioVirtualId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboIntegrador", "0"))
            End If
            Return intmIntegradorServicioVirtualId
        End Get
        Set(ByVal intValue As Integer)
            intmIntegradorServicioVirtualId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnServicioVirtualCampoVariableSolicitadoEnPOS
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnServicioVirtualCampoVariableSolicitadoEnPOS() As Boolean
        Get
            If blnmServicioVirtualCampoVariableSolicitadoEnPOS = False Then
                If Request.Form("CheckBoxPOS") = "" Then
                    'No hacer nada
                Else
                    blnmServicioVirtualCampoVariableSolicitadoEnPOS = CBool(Request.Form("CheckBoxPOS"))
                End If
                Return blnmServicioVirtualCampoVariableSolicitadoEnPOS
            End If
        End Get
        Set(ByVal blnValue As Boolean)
            blnmServicioVirtualCampoVariableSolicitadoEnPOS = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : strServicioVirtualCampoVariableDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strServicioVirtualCampoVariableDescripcion() As String
        Get
            If strmServicioVirtualCampoVariableDescripcion = Nothing Then
                strmServicioVirtualCampoVariableDescripcion = Request.Form("txtDescripcionCampo")
            End If
            Return strmServicioVirtualCampoVariableDescripcion
        End Get
        Set(ByVal strValue As String)
            strmServicioVirtualCampoVariableDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strServicioVirtualCampoVariableValor
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strServicioVirtualCampoVariableValor() As String
        Get
            If strmServicioVirtualCampoVariableValor = Nothing Then
                strmServicioVirtualCampoVariableValor = Request.Form("txtValorCampo")
            End If
            Return strmServicioVirtualCampoVariableValor
        End Get
        Set(ByVal strValue As String)
            strmServicioVirtualCampoVariableValor = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intServicioVirtualCampoVariableNumeroCaracteres
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualCampoVariableNumeroCaracteres() As Integer
        Get
            If intmServicioVirtualCampoVariableNumeroCaracteres = 0 Then
                If Request.Form("txtCtdCaracteresCampo") = "" Then
                    intmServicioVirtualCampoVariableNumeroCaracteres = 30
                Else
                    intmServicioVirtualCampoVariableNumeroCaracteres = CInt(Request.Form("txtCtdCaracteresCampo"))
                End If
            End If
            Return intmServicioVirtualCampoVariableNumeroCaracteres
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualCampoVariableNumeroCaracteres = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intServicioVirtualCampoVariableLDITipoId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualCampoVariableLDITipoId() As Integer
        Get
            If intmServicioVirtualCampoVariableLDITipoId = 0 Then
                If Request.Form("txtLDITipoIdCampo") = "" Then
                    'No hacer nada
                Else
                    intmServicioVirtualCampoVariableLDITipoId = CInt(Request.Form("txtLDITipoIdCampo"))
                End If
            End If
            Return intmServicioVirtualCampoVariableLDITipoId
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualCampoVariableLDITipoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intServicioVirtualCampoVariableLDISubtipoId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualCampoVariableLDISubtipoId() As Integer
        Get
            If intmServicioVirtualCampoVariableLDISubtipoId = 0 Then
                If Request.Form("txtLDISubtipoIdCampo") = "" Then
                    'No hacer nada
                Else
                    intmServicioVirtualCampoVariableLDISubtipoId = CInt(Request.Form("txtLDISubtipoIdCampo"))
                End If
            End If
            Return intmServicioVirtualCampoVariableLDISubtipoId
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualCampoVariableLDISubtipoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strServicioVirtualCampoVariableTipo
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strServicioVirtualCampoVariableTipo() As String
        Get
            If strmServicioVirtualCampoVariableTipo = Nothing Then
                strmServicioVirtualCampoVariableTipo = Request.Form("cboTipoCampo")
            End If
            Return strmServicioVirtualCampoVariableTipo
        End Get
        Set(ByVal strValue As String)
            strmServicioVirtualCampoVariableTipo = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strServicioVirtualCampoVariablePropiedad
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strServicioVirtualCampoVariablePropiedad() As String
        Get
            If strmServicioVirtualCampoVariablePropiedad = Nothing Then
                strmServicioVirtualCampoVariablePropiedad = Request.Form("cboPropiedadCampo")
            End If
            Return strmServicioVirtualCampoVariablePropiedad
        End Get
        Set(ByVal strValue As String)
            strmServicioVirtualCampoVariablePropiedad = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : intServicioVirtualCampoVariableDiasVencimiento
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualCampoVariableDiasVencimiento() As Integer
        Get
            If intmServicioVirtualCampoVariableDiasVencimiento = 0 Then
                If Request.Form("txtDiasVencimientoCampo") = "" Then
                    'No hacer nada
                Else
                    intmServicioVirtualCampoVariableDiasVencimiento = CInt(Request.Form("txtDiasVencimientoCampo"))
                End If
            End If
            Return intmServicioVirtualCampoVariableDiasVencimiento
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualCampoVariableDiasVencimiento = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intServicioVirtualDatoAdicionalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualCampoVariableIdEliminar() As Integer
        Get
            If intmServicioVirtualCampoVariableIdEliminar = 0 Then
                intmServicioVirtualCampoVariableIdEliminar = CInt(isocraft.commons.clsWeb.strGetPageParameter("intServicioVirtualCampoVariableId", "0"))
            End If
            Return intmServicioVirtualCampoVariableIdEliminar
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualCampoVariableIdEliminar = intValue
        End Set
    End Property

    'SOFTTEK-LFLJ-11/OCT/2013.T1.1.
    'ServicioVirtual-Tienda
    '====================================================================
    ' Name       : intServicioVirtualCompaniaIdIdEliminar
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualCompaniaIdEliminar() As Integer
        Get
            If intmServicioVirtualCompaniaIdEliminar = 0 Then
                intmServicioVirtualCompaniaIdEliminar = CInt(isocraft.commons.clsWeb.strGetPageParameter("intCompaniaId", "0"))
            End If
            Return intmServicioVirtualCompaniaIdEliminar
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualCompaniaIdEliminar = intValue
        End Set
    End Property
    'SOFTTEK-LFLJ-11/OCT/2013.T1.1.
    'ServicioVirtual-Tienda
    '====================================================================
    ' Name       : intServicioVirtualSucursalIdIdEliminar
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualSucursalIdEliminar() As Integer
        Get
            If intmServicioVirtualSucursalIdEliminar = 0 Then
                intmServicioVirtualSucursalIdEliminar = CInt(isocraft.commons.clsWeb.strGetPageParameter("intSucursalId", "0"))
            End If
            Return intmServicioVirtualSucursalIdEliminar
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualSucursalIdEliminar = intValue
        End Set
    End Property

    'SOFTTEK-LFLJ-10/OCT/2013.T1.1.
    'ServicioVirtual-Tienda
    '====================================================================
    ' Name       : blnServicioVirtualTiendaEliminarTienda
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnServicioVirtualTiendaEliminarTienda() As Boolean
        Get
            If blnmServicioVirtualTiendaEliminarTienda = Nothing Then
                blnmServicioVirtualTiendaEliminarTienda = CBool(isocraft.commons.clsWeb.strGetPageParameter("blnEliminarTienda", "0"))
            End If
            Return blnmServicioVirtualTiendaEliminarTienda
        End Get
        Set(ByVal blnValue As Boolean)
            blnmServicioVirtualTiendaEliminarTienda = blnValue
        End Set
    End Property

    ' ==================================================================
    ' Name        : blnServicioVirtualFacturaVenta
    ' Descripcion : Evalue el Valor del Check Que esta en Html
    ' Parametros  : None 
    ' Acceso      : De Lectura \ Escritura
    ' Regresa     : Boolean 
    ' Autor       : sftk (JPMB)
    ' ==================================================================
    Public Property blnServicioVirtualFacturaVenta() As Boolean
        Get
            If blnmServicioVirtualFacturaVenta = Nothing Then
                blnmServicioVirtualFacturaVenta = CBool(isocraft.commons.clsWeb.strGetPageParameter("chkFacturaVenta", "0"))
            End If
            Return blnmServicioVirtualFacturaVenta
        End Get
        Set(ByVal blnValue As Boolean)
            blnmServicioVirtualFacturaVenta = blnValue
        End Set
    End Property

    ' ===================================================================
    ' Name        : blnServicioVirtualFacturaComision 
    ' Descripcion : Evalua si Aplica la Comision Para La Factura
    ' Parametros  : Check De Factura 
    ' Acceso      : Lectura \ Escritura 
    ' Regresa     : Boolean
    ' Autor       : sftk (JPMB)
    ' ===================================================================
    Public Property blnServicioVirtualFacturaAplicaComision() As Boolean
        Get
            If blnmServicioVirtualFacturaAplicaComision = Nothing Then
                blnmServicioVirtualFacturaAplicaComision = CBool(isocraft.commons.clsWeb.strGetPageParameter("chkFacturaAplicaComision", "0"))
            End If
            Return blnmServicioVirtualFacturaAplicaComision
        End Get
        Set(ByVal blnValue As Boolean)
            blnmServicioVirtualFacturaAplicaComision = blnValue
        End Set
    End Property

    ' ==================================================================
    ' Name        : blnServicioVirtualTarjetaActiva
    ' Descripcion : Evalue el Valor del Check Que esta en Html
    ' Parametros  : None 
    ' Acceso      : De Lectura \ Escritura
    ' Regresa     : Boolean 
    ' Autor       : sftk (JPMB)
    ' ==================================================================
    Public Property blnServicioVirtualTarjetaActiva() As Boolean
        Get
            If blnmServicioVirtualTarjetaActiva = Nothing Then
                blnmServicioVirtualTarjetaActiva = CBool(isocraft.commons.clsWeb.strGetPageParameter("chkTarjetaActiva", "0"))
            End If
            Return blnmServicioVirtualTarjetaActiva
        End Get
        Set(ByVal blnValue As Boolean)
            blnmServicioVirtualTarjetaActiva = blnValue
        End Set
    End Property

    ' ==================================================================
    ' Name        : strServicioVirtualTextoTicket
    ' Descripcion : Evalue el Valor del contenido del Texbox de html
    ' Parametros  : None 
    ' Acceso      : De Lectura \ Escritura
    ' Regresa     : Boolean 
    ' Autor       : sftk (JPMB)
    ' ==================================================================
    Public Property strServicioVirtualTextoTicket() As String
        Get
            If strmServicioVirtualTextoTicket = Nothing Then
                strmServicioVirtualTextoTicket = Request.Form("txtTextoTicket")
            End If
            Return strmServicioVirtualTextoTicket
        End Get
        Set(ByVal strValue As String)
            strmServicioVirtualTextoTicket = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : intFormaDePagoId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer   (JPMB)
    '====================================================================
    Public Property intFormaDePagoId() As Integer
        Get
            If intmFormaDePagoId = 0 Then
                intmFormaDePagoId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboFormaDePago", "0"))
            End If
            Return intmFormaDePagoId
        End Get
        Set(ByVal intValue As Integer)
            intmFormaDePagoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFormaDePagoDescripcion 
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String (JPMB)
    '====================================================================
    Public Property strFormaDePagoDescripcion() As String
        Get
            If strmFormaDePagoDescripcion = Nothing Then
                strmFormaDePagoDescripcion = Request.Form("cboFormaDePago")
            End If
            Return strmFormaDePagoDescripcion
        End Get
        Set(ByVal strValue As String)
            strmFormaDePagoDescripcion = strValue
        End Set
    End Property

    'SOFTTEK-LFLJ-10/OCT/2013.T1.1.
    'ServicioVirtual-Tienda
    '====================================================================
    ' Name       : intDireccionOperativaId 
    ' Description: Obtiene o establece la direccion operativa seleccionada
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intDireccionOperativaId() As Integer
        Get
            If intmDireccionOperativaId = 0 Then
                intmDireccionOperativaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboDireccionOperativa", "0"))
            End If
            Return intmDireccionOperativaId
        End Get
        Set(ByVal intValue As Integer)
            intmDireccionOperativaId = intValue
        End Set
    End Property
    'SOFTTEK-LFLJ-10/OCT/2013.T1.1.
    'ServicioVirtual-Tienda
    '====================================================================
    ' Name       : intZonaOperativaId 
    ' Description: Obtiene o establece la zona operativa seleccionada
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intZonaOperativaId() As Integer
        Get
            If intmZonaOperativaId = 0 Then
                intmZonaOperativaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboZonaOperativa", "0"))
            End If
            Return intmZonaOperativaId
        End Get
        Set(ByVal intValue As Integer)
            intmZonaOperativaId = intValue
        End Set

    End Property

    '====================================================================
    ' Name       : strLlenarTipoMovimientoComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboAutorizador"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarTipoMovimientoComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboTipo", 0, Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtual.strBuscarTipoMovimiento(strConnectionString), 0, 1, 1)
    End Function

    '====================================================================
    ' Name       : strLlenarTipoTicketComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboAutorizador"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarTipoTicketComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboTipoTicket", 0, Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtual.strBuscarTipoTicket(strConnectionString), 0, 1, 1)
    End Function

    '====================================================================
    ' Name       : strGetRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 10
        Const strRecordBrowserName As String = "SucursalServiciosVirtualesAgregarEditar"

        ' Declaramos e inicializamos las variables locales

        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim astrDataArray As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtualDatoAdicional.strBuscar(intServicioVirtualId, strConnectionString)

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?intTipoServicioId=" & intTipoServicioVirtualId & "&intServicioId=" & intServicioVirtualId & "&")

    End Function

    ' STKLDI CJBG 26/06/2012
    '====================================================================
    ' Name       : strGetRecordBrowserHTMLCamposConfigurables
    ' Description: Regresa el HTML del navegador de registros de campos variables
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTMLCamposConfigurables() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 10
        Const strRecordBrowserName As String = "SucursalServiciosVirtualesCampoVariableAgregarEditar"

        ' Declaramos e inicializamos las variables locales

        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim astrDataArray As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtualCampoVariable.strBuscar(0, _
                0, "", intServicioVirtualId, intIntegradorServicioVirtualId, strConnectionString)

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?intTipoServicioId=" & intTipoServicioVirtualId & "&intServicioId=" & intServicioVirtualId & "&")

    End Function

    'SOFTTEK-LFLJ-10/OCT/2013.T1.1.
    'ServicioVirtual-Tienda
    '====================================================================
    ' Name       : strGetRecordBrowserHTMLTiendas
    ' Description: Regresa el HTML del navegador de registros de Tiendas
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTMLTiendas() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 10
        Const strRecordBrowserName As String = "SucursalServiciosVirtualesTiendaAgregarEditar"

        ' Declaramos e inicializamos las variables locales

        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim astrDataArray As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtualTienda.strBuscar(0, 0, intServicioVirtualId, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

        ' Generamos el navegador de registros 
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?intTipoServicioId=" & intTipoServicioVirtualId & "&intServicioId=" & intServicioVirtualId & "&blnEliminarTienda=1&")

    End Function

    ' ===================================================================
    ' Nombre       : strGetRecordBrowserHTMLFormaDePago
    ' Descripcion  : Regresa el HTML De Las Formas De Pago Agregadas
    ' Acceso       : Read 
    ' Limites      : None 
    ' Salida       : String 
    ' STKPPSV Tarjetas De Regalo (JPMB)
    ' ===================================================================
    Public Function strGetRecordBrowserHTMLFormaDePago() As String

        'Declaramos E Inicializamos Las Constantes Locales 
        Const intElementosPage As Integer = 10
        Const strRecordBrowserName As String = "SucursalServiciosVirtualesAgregarFormaDePago"

        ' Declaramos e inicializamoz las Variables Locales 
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)

        Dim astrDataArray As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsSucursalTarjetasDeRegalo.strBuscarserviciovirtualFormaPagoHTML(intServicioVirtualId, strConnectionString)

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementosPage, strThisPageName & "?intTipoServicioId=" & intTipoServicioVirtualId & "&intServicioId=" & intServicioVirtualId & "&")

    End Function

    '====================================================================
    ' Name       : intServicioVirtualFormaPagoEliminar
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer JPMB
    '====================================================================
    Public Property intServicioVirtualFormaPagoIdEliminar() As Integer
        Get
            If intmServicioVirtualFormaPagoIdEliminar = 0 Then
                intmServicioVirtualFormaPagoIdEliminar = CInt(isocraft.commons.clsWeb.strGetPageParameter("intFormaPagoId", "0"))
            End If
            Return intmServicioVirtualFormaPagoIdEliminar
        End Get
        Set(ByVal intValue As Integer)
            intmServicioVirtualFormaPagoIdEliminar = intValue
        End Set
    End Property
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Dim intResultado As Integer

        Dim strResultado As Array

        'JPMB Tarjetas De Regalo. 31/05/213

        Dim intResultadoTarjetasDeRegalo As Integer
        Dim strResultadoTarjetasDeRegalo As Array

        'SOFTTEK-LFLJ-10/OCT/2013.T1.1.
        'ServicioVirtual-Tienda. Almacenamos la Dirección Operativa Recibida
        intDireccionOperativaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboDireccionOperativa", "0", Request))

        'SOFTTEK-LFLJ-10/OCT/2013.T1.1.
        'ServicioVirtual-Tienda. Almacenamos la Zona Operativa Recibida
        intZonaOperativaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboZonaOperativa", "0", Request))

        ' Execute the selected command
        Select Case strCmd

            Case "Salvar"

                'intResultado = Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtual.intGuardar(intTipoServicioVirtualId, intServicioVirtualId, strServicioVirtualCodigoProducto, _
                '      strServicioVirtualDescripcion, intTipoMovimientoServicioVirtualId, intTipoTicketId, intArticuloId, intServicioVirtualTransaccionCTFId, _
                '      intServicioVirtualTransaccionCTFCampoCompuestoId, intServicioVirtualTransaccionCTFCampoCompuestoLongitud, fltServicioVirtualComision, _
                '      intServicioVirtualTransaccionCTFComisionId, intServicioVirtualTransaccionCTFComisionFPSinImpuesto, _
                '      intServicioVirtualTransaccionCTFComisionFPImpuestoInteriorId, intServicioVirtualTransaccionCTFComisionFPImpuestoFronteraId, blnServicioVirtualDesgloseImpuesto, _
                '      intServicioVirtualClaveImpresion, blnServicioVirtualReImpresion, strServicioVirtualLeyendaReferencia, strServicioVirtualCampoAutorizacion, _
                '      strServicioVirtualCampoImporte, strServicioVirtualCampoMonto, strServicioVirtualCampoCantidad, strServicioVirtualCamposNoAlmacenados, blnServicioVirtualReversa, _
                '      blnServicioVirtualImprimirTicketCancelacion, intServicioVirtualClaveImpresionCancelacion, blnServicioVirtualConfirmarOperacionExitosa, _
                '      strServicioVirtualLeyendaOperacionExitosa, fltServicioVirtualMontoMaximo, strUsuarioNombre, strConnectionString)

                'STKLDI 26/06/2012 CJBG - Cargando datos a intIntegradorServicioVirtualId 
                'intResultado = Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtual.intGuardar(intTipoServicioVirtualId, intServicioVirtualId, strServicioVirtualCodigoProducto, _
                '      strServicioVirtualDescripcion, intTipoMovimientoServicioVirtualId, intTipoTicketId, intArticuloId, intServicioVirtualTransaccionCTFId, _
                '      intServicioVirtualTransaccionCTFCampoCompuestoId, intServicioVirtualTransaccionCTFCampoCompuestoLongitud, fltServicioVirtualComision, _
                '      intServicioVirtualTransaccionCTFComisionId, intServicioVirtualTransaccionCTFComisionFPSinImpuesto, _
                '      intServicioVirtualTransaccionCTFComisionFPImpuestoInteriorId, intServicioVirtualTransaccionCTFComisionFPImpuestoFronteraId, blnServicioVirtualDesgloseImpuesto, _
                '      intServicioVirtualClaveImpresion, blnServicioVirtualReImpresion, strServicioVirtualLeyendaReferencia, strServicioVirtualCampoAutorizacion, _
                '      strServicioVirtualCampoImporte, strServicioVirtualCampoMonto, strServicioVirtualCampoCantidad, strServicioVirtualCamposNoAlmacenados, blnServicioVirtualReversa, _
                '      blnServicioVirtualImprimirTicketCancelacion, intServicioVirtualClaveImpresionCancelacion, blnServicioVirtualConfirmarOperacionExitosa, _
                '      strServicioVirtualLeyendaOperacionExitosa, fltServicioVirtualMontoMaximo, strUsuarioNombre, blnServicioVirtualValidarSupervisor, intIntegradorServicioVirtualId, strConnectionString)

                'STKIUSACFE 11/07/2013 CJBG - Salvando datos de fltServicioVirtualComision 
                intResultado = Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtual.intGuardar(intTipoServicioVirtualId, intServicioVirtualId, strServicioVirtualCodigoProducto, _
                      strServicioVirtualDescripcion, intTipoMovimientoServicioVirtualId, blnServicioVirtualValidarSupervisor, intTipoTicketId, intIntegradorServicioVirtualId, intArticuloId, _
                      intServicioVirtualTransaccionCTFId, intServicioVirtualTransaccionCTFCampoCompuestoId, intServicioVirtualTransaccionCTFCampoCompuestoLongitud, fltServicioVirtualComision, _
                      intServicioVirtualTransaccionCTFComisionId, intServicioVirtualTransaccionCTFComisionFPSinImpuesto, intServicioVirtualTransaccionCTFComisionFPImpuestoInteriorId, _
                      intServicioVirtualTransaccionCTFComisionFPImpuestoFronteraId, fltServicioVirtualComisionIntegrador, intServicioVirtualTransaccionCTFComisionIntegradorId, _
                      intServicioVirtualTransaccionCTFComisionIntegradorFPSinImpuesto, intServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoInteriorId, _
                      intServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoFronteraId, blnServicioVirtualSeparaComisionIntegrador, blnServicioVirtualDesgloseImpuesto, _
                      intServicioVirtualClaveImpresion, blnServicioVirtualReImpresion, strServicioVirtualLeyendaReferencia, strServicioVirtualCampoAutorizacion, _
                      strServicioVirtualCampoImporte, strServicioVirtualCampoMonto, strServicioVirtualCampoCantidad, strServicioVirtualCamposNoAlmacenados, blnServicioVirtualReversa, _
                      blnServicioVirtualImprimirTicketCancelacion, intServicioVirtualClaveImpresionCancelacion, blnServicioVirtualConfirmarOperacionExitosa, _
                      strServicioVirtualLeyendaOperacionExitosa, fltServicioVirtualMontoMaximo, strUsuarioNombre, strConnectionString)

                'STKTARJETASDEREGALO 17/06/2013 Validación si es tarjeta de regalo guardar EBCV
                If strTipoServicioVirtualDescripcion = "TARJETAS DE REGALO" Then
                    'STKTARJETASDEREGALO 31/05/2013 JPMB
                    'Guarda las Configuraciones De Tarjeta de Regalo, para las nuevas version del Proyecto PPSV
                    intResultadoTarjetasDeRegalo = Benavides.CC.Business.clsConcentrador.clsSucursal.clsSucursalTarjetasDeRegalo.intGuardarDatoAdicionalTarjetaRegalo(intServicioVirtualId, strServicioVirtualCodigoProducto, blnServicioVirtualFacturaVenta, _
                                                     blnServicioVirtualFacturaAplicaComision, blnServicioVirtualTarjetaActiva, strServicioVirtualTextoTicket, strUsuarioNombre, strConnectionString)
                    'STKLDI 26/06/2012 CJBG - Borrando Campos Configurados si el integrador cambio. 
                    If (blnIntegradorServicioVirtualIdCambio = True) Then
                        Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtualCampoVariable.intEliminar(intServicioVirtualCampoVariableIdEliminar, intIntegradorServicioVirtualId, intServicioVirtualId, strConnectionString)
                    End If
                End If

                Response.Redirect("SucursalServiciosVirtualesAgregarEditar.aspx?strCmd=Editar&intTipoServicioId=" & CStr(intTipoServicioVirtualId) & "&intServicioID=" & CStr(intResultado))

            Case "Editar"

                ' Si el identificador del elemento es válido
                If intTipoServicioVirtualId > 0 Then

                    ' Obtenemos el Tipo de servicio
                    Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsTipoServicioVirtual.strBuscar(intTipoServicioVirtualId, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        Dim aobjRow As System.Array = DirectCast(aobjData.GetValue(0), System.Array)

                        ' Recuperamos sus datos
                        intTipoServicioVirtualId = CInt(aobjRow.GetValue(0))
                        strTipoServicioVirtualDescripcion = CStr(aobjRow.GetValue(1))

                        ' Obtenemos los datos del Servicio Virtual a editar
                        Dim objData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtual.strBuscar(intTipoServicioVirtualId, intServicioVirtualId, strConnectionString)
                        'Si el Servicio Virtual fue encontrado
                        If IsNothing(objData) = False AndAlso objData.Length > 0 Then
                            Dim objRow As System.Array = DirectCast(objData.GetValue(0), System.Array)

                            'Recuperamos sus datos
                            intTipoServicioVirtualId = CInt(objRow.GetValue(0))
                            strServicioVirtualCodigoProducto = CStr(objRow.GetValue(1))
                            strServicioVirtualDescripcion = CStr(objRow.GetValue(2))
                            intTipoMovimientoServicioVirtualId = CInt(objRow.GetValue(3))
                            'STKLDI 26/06/2012 CJBG - Cargando datos a blnServicioVirtualValidarSupervisor
                            blnServicioVirtualValidarSupervisor = CBool(objRow.GetValue(4))
                            intTipoTicketId = CInt(objRow.GetValue(5))
                            'STKLDI 26/06/2012 CJBG - Cargando datos a intIntegradorServicioVirtualId
                            intIntegradorServicioVirtualId = CInt(objRow.GetValue(6))
                            intArticuloId = CInt(objRow.GetValue(7))
                            intServicioVirtualTransaccionCTFId = CInt(objRow.GetValue(8))
                            intServicioVirtualTransaccionCTFCampoCompuestoId = CInt(objRow.GetValue(9))
                            intServicioVirtualTransaccionCTFCampoCompuestoLongitud = CInt(objRow.GetValue(10))
                            fltServicioVirtualComision = CDbl(objRow.GetValue(11))
                            intServicioVirtualTransaccionCTFComisionId = CInt(objRow.GetValue(12))
                            intServicioVirtualTransaccionCTFComisionFPSinImpuesto = CInt(objRow.GetValue(13))
                            intServicioVirtualTransaccionCTFComisionFPImpuestoInteriorId = CInt(objRow.GetValue(14))
                            intServicioVirtualTransaccionCTFComisionFPImpuestoFronteraId = CInt(objRow.GetValue(15))

                            'STKIUSACFE 11/07/2013 CJBG - Cargando datos de Comisión Integrador
                            fltServicioVirtualComisionIntegrador = CDbl(objRow.GetValue(16))
                            intServicioVirtualTransaccionCTFComisionIntegradorId = CInt(objRow.GetValue(17))
                            intServicioVirtualTransaccionCTFComisionIntegradorFPSinImpuesto = CInt(objRow.GetValue(18))
                            intServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoInteriorId = CInt(objRow.GetValue(19))
                            intServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoFronteraId = CInt(objRow.GetValue(20))
                            blnServicioVirtualSeparaComisionIntegrador = CBool(objRow.GetValue(21))

                            blnServicioVirtualDesgloseImpuesto = CBool(objRow.GetValue(22))
                            intServicioVirtualClaveImpresion = CInt(objRow.GetValue(23))
                            blnServicioVirtualReImpresion = CBool(objRow.GetValue(24))
                            strServicioVirtualLeyendaReferencia = CStr(objRow.GetValue(25))
                            strServicioVirtualCampoAutorizacion = CStr(objRow.GetValue(26))
                            strServicioVirtualCampoImporte = CStr(objRow.GetValue(27))
                            strServicioVirtualCampoMonto = CStr(objRow.GetValue(28))
                            strServicioVirtualCampoCantidad = CStr(objRow.GetValue(29))
                            strServicioVirtualCamposNoAlmacenados = CStr(objRow.GetValue(30))
                            blnServicioVirtualReversa = CBool(objRow.GetValue(31))
                            blnServicioVirtualImprimirTicketCancelacion = CBool(objRow.GetValue(32))
                            intServicioVirtualClaveImpresionCancelacion = CInt(objRow.GetValue(33))
                            blnServicioVirtualConfirmarOperacionExitosa = CBool(objRow.GetValue(34))
                            strServicioVirtualLeyendaOperacionExitosa = CStr(objRow.GetValue(35))
                            fltServicioVirtualMontoMaximo = CDbl(objRow.GetValue(36))

                            'STKTARJETASDEREGALO 15/06/2013 Validacion si es tarjeta de regalo o no lo es EBCV
                            If strTipoServicioVirtualDescripcion = "TARJETAS DE REGALO" Then
                                'STKTARJETASDEREGALO 31/05/213 JPMB
                                'Busca las Configuraciones De Tarjeta de Regalo, par las nuevas version del Proyecto PPSV
                                Dim objeData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsSucursalTarjetasDeRegalo.strBuscarDatoAdicionalTarjetaRegalo(intServicioVirtualId, strConnectionString)

                                'Checamos si el Arreglo trae Datos 
                                If IsNothing(objeData) = False AndAlso objeData.Length > 0 Then
                                    Dim objeRow As System.Array = DirectCast(objeData.GetValue(0), System.Array)

                                    'Recupereamos los datos Que Trae el Arreglo de la Base para su Asignacion 
                                    'intTipoServicioVirtualId = CInt(objeRow.GetValue(0))
                                    'strServicioVirtualCodigoProducto = CStr(objeRow.GetValue(1))
                                    strServicioVirtualTextoTicket = CStr(objeRow.GetValue(2))
                                    blnServicioVirtualFacturaVenta = CBool(objeRow.GetValue(3))
                                    blnServicioVirtualFacturaAplicaComision = CBool(objeRow.GetValue(4))
                                    blnServicioVirtualTarjetaActiva = CBool(objeRow.GetValue(5))
                                End If

                            End If

                        End If

                    End If

                End If

            Case "Agregar"

                ' Si el identificador del elemento es válido
                If intTipoServicioVirtualId > 0 Then

                    ' Obtenemos el elemento
                    Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsTipoServicioVirtual.strBuscar(intTipoServicioVirtualId, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        Dim aobjRow As System.Array = DirectCast(aobjData.GetValue(0), System.Array)

                        ' Recuperamos sus datos
                        intTipoServicioVirtualId = CInt(aobjRow.GetValue(0))
                        strTipoServicioVirtualDescripcion = CStr(aobjRow.GetValue(1))

                    End If

                End If

            Case "AgregarDato"

                intResultado = Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtualDatoAdicional.intAgregar(intServicioVirtualId, intServicioVirtualDatoAdicionalIdGuardar, strServicioVirtualDatoAdicionalNombre, strUsuarioNombre, strConnectionString)

                Response.Redirect("SucursalServiciosVirtualesAgregarEditar.aspx?strCmd=Editar&intTipoServicioId=" & CStr(intTipoServicioVirtualId) & "&intServicioID=" & CStr(intServicioVirtualId))

            Case "Eliminar"

                intResultado = Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtualDatoAdicional.intEliminar(intServicioVirtualId, intServicioVirtualDatoAdicionalIdEliminar, strConnectionString)

                Response.Redirect("SucursalServiciosVirtualesAgregarEditar.aspx?strCmd=Editar&intTipoServicioId=" & CStr(intTipoServicioVirtualId) & "&intServicioID=" & CStr(intServicioVirtualId))

                ' STKLDI CJBG 07/07/2012 Agregamos un campo variable
            Case "AgregarCampoVariable"

                strResultado = Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtualCampoVariable.strBuscar(0, _
                intServicioVirtualCampoVariableLDISubtipoId, strServicioVirtualCampoVariablePropiedad, _
                intServicioVirtualId, intIntegradorServicioVirtualId, strConnectionString)

                ' Si el elemento fue encontrado
                If IsNothing(strResultado) = False AndAlso strResultado.Length > 0 Then

                    'Response.Write("<script language='javascript'>alert('No se puede dar de alta un tipo de campo duplicado para una propiedad.');</script>")
                    Response.Redirect("SucursalServiciosVirtualesAgregarEditar.aspx?strCmd=Editar&intTipoServicioId=" & CStr(intTipoServicioVirtualId) & "&intServicioID=" & CStr(intServicioVirtualId) & "&strServicioVirtualCampoVariableDuplicado=true")

                Else

                    intResultado = Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtualCampoVariable.intAgregar(0, _
                    blnServicioVirtualCampoVariableSolicitadoEnPOS, strServicioVirtualCampoVariableDescripcion, _
                    strServicioVirtualCampoVariableValor, intServicioVirtualCampoVariableNumeroCaracteres, _
                    intServicioVirtualCampoVariableLDITipoId, intServicioVirtualCampoVariableLDISubtipoId, strServicioVirtualCampoVariableTipo, strServicioVirtualCampoVariablePropiedad, _
                    intServicioVirtualCampoVariableDiasVencimiento, intIntegradorServicioVirtualId, intServicioVirtualId, Now(), strUsuarioNombre, strConnectionString)

                    Response.Redirect("SucursalServiciosVirtualesAgregarEditar.aspx?strCmd=Editar&intTipoServicioId=" & CStr(intTipoServicioVirtualId) & "&intServicioID=" & CStr(intServicioVirtualId))

                End If

                'SOFTTEK-LFLJ-10/OCT/2013.T1.1.
                'ServicioVirtual-Tienda. Agregar una o varias Tiendas a un Servicio Virtual
            Case "AgregarTiendas"
                'Almacenamos los ids de la Tiendas seleccionadas
                Dim strCompaniaSucursalIds As String
                strCompaniaSucursalIds = isocraft.commons.clsWeb.strGetPageParameter("cboTienda", "0", Request)

                ' Vinculamos las sucursales al Servicio Virtual, si los identificadores son válidos
                If Len(strCompaniaSucursalIds) > 0 Then
                    ' Almacenamos en un arreglo la lista de Tiendas (Compania-Sucursal)
                    ' La lista tiene el siguiente formato:
                    '   intCompaniaId | intSucursalId , intCompaniaId | intSucursalId, ..., intCompaniaId | intSucursalId
                    Dim astrIdentificadoresCompaniaSucursal As Array = strCompaniaSucursalIds.Split(","c)

                    ' Si obtuvimos pares de identificadores "intCompaniaId | intSucursalId"
                    If astrIdentificadoresCompaniaSucursal.Length > 0 Then

                        ' Recorremos los pares identificadores
                        Dim strCompaniaIdentificadorSucursal As String
                        For Each strCompaniaIdentificadorSucursal In astrIdentificadoresCompaniaSucursal

                            ' Separamos los pares identificadores y los almacenamos en un arreglo
                            Dim astrCompaniaSucursal As Array = strCompaniaIdentificadorSucursal.Split("|"c)

                            ' Si existen identificadores
                            If astrCompaniaSucursal.Length > 0 Then

                                ' Obtenemos la compañía, la sucursal y el nuevo tipo de cambio
                                Dim intCompaniaId As Integer = CInt(astrCompaniaSucursal.GetValue(0))
                                Dim intSucursalId As Integer = CInt(astrCompaniaSucursal.GetValue(1))

                                ' Agregamos el registro a la tblServicioVirtualTienda
                                If intCompaniaId > 0 AndAlso intSucursalId > 0 Then
                                    intResultado = Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtualTienda.intAgregar(intCompaniaId, intSucursalId, intServicioVirtualId, Now(), strUsuarioNombre, strConnectionString)
                                End If

                            End If

                        Next

                    End If

                End If

                Response.Redirect("SucursalServiciosVirtualesAgregarEditar.aspx?strCmd=Editar&intTipoServicioId=" & CStr(intTipoServicioVirtualId) & "&intServicioID=" & CStr(intServicioVirtualId))

            Case "Borrar"

                'SOFTTEK-LFLJ-10/OCT/2013.T1.1. (inicio)
                'ServicioVirtual-Tienda. Borrar Tienda de un Servicio Virtual
                If blnServicioVirtualTiendaEliminarTienda Then

                    intResultado = Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtualTienda.intEliminar(intServicioVirtualCompaniaIdEliminar, intServicioVirtualSucursalIdEliminar, intServicioVirtualId, strConnectionString)

                    Response.Redirect("SucursalServiciosVirtualesAgregarEditar.aspx?strCmd=Editar&intTipoServicioId=" & CStr(intTipoServicioVirtualId) & "&intServicioID=" & CStr(intServicioVirtualId))

                Else
                    'SOFTTEK-LFLJ-10/OCT/2013.T1.1. (fin), de aqui en delante se borra un Campo Variable de un Servicio Virtual (código original)
                    intResultado = Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtualCampoVariable.intEliminar(intServicioVirtualCampoVariableIdEliminar, 0, intServicioVirtualId, strConnectionString)

                    Response.Redirect("SucursalServiciosVirtualesAgregarEditar.aspx?strCmd=Editar&intTipoServicioId=" & CStr(intTipoServicioVirtualId) & "&intServicioID=" & CStr(intServicioVirtualId))

                End If  'SOFTTEK-LFLJ-10/OCT/2013.T1.1. Se agregó ésta linea.

                ' STKPPSV JPMB 07/07/2012 Agregamos Para las Formas De Pago
            Case "AgregarFormaDePago"

                If intServicioVirtualId > 0 Then
                    intResultado = Benavides.CC.Business.clsConcentrador.clsSucursal.clsSucursalTarjetasDeRegalo.intGuardarserviciovirtualFormaPago(intServicioVirtualId, intFormaDePagoId, strUsuarioNombre, strConnectionString)

                Else

                    Response.Write("<script language='javascript'>alert('Articulo no existente, por favor intente de nuevo.');</script>")


                End If
                ' STKPPSV JPMB 07/07/2012 Eliminar  Para las Formas De Pago
            Case "Eliminarformadepago"
                If intServicioVirtualFormaPagoIdEliminar > 0 Then

                    intResultado = Benavides.CC.Business.clsConcentrador.clsSucursal.clsSucursalTarjetasDeRegalo.intEliminarserviciovirtualFormaPago(intServicioVirtualId, intServicioVirtualFormaPagoIdEliminar, strConnectionString)
                    Response.Redirect("SucursalServiciosVirtualesAgregarEditar.aspx?strCmd=Editar&intTipoServicioId=" & CStr(intTipoServicioVirtualId) & "&intServicioID=" & CStr(intServicioVirtualId))


                Else

                    Response.Write("<script language='javascript'>alert('Articulo no existente, por favor intente de nuevo.');</script>")

                End If
        End Select
    End Sub

    ' STKLDI CJBG 07/07/2012 Metodo que se encarga de llenar las opciones de cboIntegrador
    Public Function strLlenarIntegradorComboBox() As String

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboIntegrador", 0, Benavides.CC.Business.clsConcentrador.clsSucursal.clsIntegradorServicioVirtual.strBuscar(0, "", "", Now, "", 0, 0, strConnectionString), 0, 1, 1)

    End Function

    ' STKTARJETAS DE REGALO 03/06/2013 Metodo que se encarga de llenar el cblFormadePago  JPMB
    Public Function strLLenarFormaDePago() As String

        'STKTARJETASDEREGALO 16/06/2013 Validación si es tarjeta de o no lo es EBCV
        If strTipoServicioVirtualDescripcion = "TARJETAS DE REGALO" Then

            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboFormaDePago", 0, Benavides.CC.Business.clsConcentrador.clsSucursal.clsSucursalTarjetasDeRegalo.strBuscarFormaDePago(0, strConnectionString), 0, 1, 1)

        End If

    End Function

    'SOFTTEK-LFLJ-10/OCT/2013.T1.1.
    'ServicioVirtual-Tienda. Carga el combobox cboDireccionOperativa
    Public Function strLlenarcboDireccionOperativa() As String

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccionOperativa", intDireccionOperativaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString), 0, 1, 1)

    End Function

    'SOFTTEK-LFLJ-10/OCT/2013.T1.1.
    'ServicioVirtual-Tienda. Carga el combobox cboZonaOperativa
    Public Function strLlenarcboZonaOperativa() As String
        ' Si la dirección operativa es mayor a uno significa que se ha seleccionado alguna de ellas
        If intDireccionOperativaId <> 0 Then

            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZonaOperativa", intZonaOperativaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionOperativaId, 0, strConnectionString), 0, 1, 1)

        Else

            Return ""

        End If

    End Function

    'SOFTTEK-LFLJ-10/OCT/2013.T1.1.
    'ServicioVirtual-Tienda. Carga el combobox cboTienda
    Public Function strLlenarcboTienda() As String
        ' Si la dirección y la zona operativas son diferentes a cero significa que se ha seleccionado alguna direccion y alguna zona
        If intDireccionOperativaId <> 0 AndAlso intZonaOperativaId <> 0 Then

            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboTienda", "", Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtualTienda.strBuscarServicioVirtualTiendaPorDireccion(intDireccionOperativaId, intZonaOperativaId, intServicioVirtualId, strConnectionString), New Integer(1) {0, 1}, 2, 0)

        Else

            Return ""

        End If

    End Function

End Class