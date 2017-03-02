Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Business.clsConcentrador.clsSucursal.clsMercancia
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class MercanciaCapturarInsumosMateriaPrima
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

    Private strmRazonSocialProveedor As String = String.Empty
    Private intmEliminaDetalle As Integer = 0

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
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strGeneracboIvaAplicadoHTML
    ' Description: Genera las opciones del iva aplicado
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGeneracboIvaAplicadoHTML(ByVal strNombreComponente As String) As String

        Dim objIvaAplicado As Array = Nothing
        Dim objRegistroIvaAplicado As String() = Nothing
        Dim strcboIvaAplicadoHTML As StringBuilder
        Dim intContador As Integer = 0

        ' Traemos los impuestos actuales
        objIvaAplicado = clstblImpuesto.strBuscar(0, 0, String.Empty, 0, CDate("01/01/1900"), String.Empty, 0, 0, strCadenaConexion)

        ' Checamos si es arreglo válido
        If IsArray(objIvaAplicado) Then
            If objIvaAplicado.Length > 0 Then

                strcboIvaAplicadoHTML = New StringBuilder


                ' Barremos el arreglo para generar el HTML
                For Each objRegistroIvaAplicado In objIvaAplicado
                    strcboIvaAplicadoHTML.Append("document.forms[0].elements['" & strNombreComponente & "'].options[" & intContador & "] = new Option(""" & objRegistroIvaAplicado(2) & "  " & objRegistroIvaAplicado(3) & """,""" & objRegistroIvaAplicado(3) & """);" & vbCrLf)

                    If CInt(Request.Form("cboIvaAplicado")) = CInt(objRegistroIvaAplicado(3)) Then
                        strcboIvaAplicadoHTML.Append("document.forms[0].elements['" & strNombreComponente & "'].options[" & intContador & "].selected=true;" & vbCrLf)
                    End If
                    intContador += 1
                Next

            End If
        End If

        If strcboIvaAplicadoHTML.ToString.Length > 0 Then
            Return strcboIvaAplicadoHTML.ToString
        Else
            Return String.Empty
        End If

    End Function

    '====================================================================
    ' Name       : strGeneraDescuentoHTML
    ' Description: Genera las opciones del iva descuento
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGeneraDescuentoHTML(ByVal strNombreComponente As String) As String

        Dim strcboDescuentoHTML As StringBuilder
        Dim intContador As Integer = 0

        strcboDescuentoHTML = New StringBuilder

        strcboDescuentoHTML.Append("document.forms[0].elements['" & strNombreComponente & "'].options[" & "0" & "] = new Option(""" & "Elija una condición" & """,""" & "0" & """);" & vbCrLf)
        strcboDescuentoHTML.Append("document.forms[0].elements['" & strNombreComponente & "'].options[" & "1" & "] = new Option(""" & "Tiene Descuento" & """,""" & "1" & """);" & vbCrLf)
        strcboDescuentoHTML.Append("document.forms[0].elements['" & strNombreComponente & "'].options[" & "2" & "] = new Option(""" & "NO Tiene Descuento" & """,""" & "2" & """);" & vbCrLf)


        Select Case CInt(Request.Form("cboDescuento"))
            Case 0
                strcboDescuentoHTML.Append("document.forms[0].elements['" & strNombreComponente & "'].options[" & "0" & "].selected=true;" & vbCrLf)
            Case 1
                strcboDescuentoHTML.Append("document.forms[0].elements['" & strNombreComponente & "'].options[" & "1" & "].selected=true;" & vbCrLf)
            Case 2
                strcboDescuentoHTML.Append("document.forms[0].elements['" & strNombreComponente & "'].options[" & "2" & "].selected=true;" & vbCrLf)
        End Select

        If strcboDescuentoHTML.ToString.Length > 0 Then
            Return strcboDescuentoHTML.ToString
        Else
            Return String.Empty
        End If

    End Function

    '====================================================================
    ' Name       : dblTotalFacturado
    ' Description: TotalFacturado
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Double
    '====================================================================
    Public ReadOnly Property dblTotalFacturado() As Double
        Get
            ' Mandamos el total facturado cuando no tenga descuento 
            If Request.Form("cboDescuento").Trim.Equals("2") Then
                If CDbl(Request.Form("txtTotalFacturado")) > 0 Then
                    Return CDbl(Request.Form("txtTotalFacturado"))
                Else
                    Return 0
                End If
            End If

            ' Mandamos el total facturado cuando tenga descuento antes de iva
            If Request.Form("cboDescuento").Trim.Equals("1") Then
                If CInt(Request.Form("chkAntesdeIva")) = 1 Then

                    If dblDescuentoAntesdeIva = 0 Then
                        If CDbl(Request.Form("txtSumaProductos")) > 0 Then
                            Return CDbl(Request.Form("txtSumaProductos"))
                        Else
                            Return 0
                        End If

                    End If

                    If CDbl(Request.Form("txtSumaProductos")) > 0 Then
                        If dblDescuentoAntesdeIva > 0 Then
                            Return CDbl(Request.Form("txtSumaProductos")) - CDbl(Request.Form("txtDescuentoAntesdeIva"))
                        End If
                    End If
                End If
            End If

            ' Mandamos el total facturado cuando tenga descuento despues de iva
            If Request.Form("cboDescuento").Trim.Equals("1") Then
                If CInt(Request.Form("chkDespuesdeIva")) = 1 Then

                    If IsNumeric(Request.Form("txtTotalFacturado")) Then
                        Return CDbl(Request.Form("txtTotalFacturado"))
                    End If
                End If
            End If

            Return 0
        End Get
    End Property

    '====================================================================
    ' Name       : dblIvaAplicado
    ' Description: Iva aplicado
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Double
    '====================================================================
    Public ReadOnly Property dblIvaAplicado() As Double
        Get
            Return CDbl(Request.Form("cboIvaAplicado")) / 100
        End Get
    End Property

    '====================================================================
    ' Name       : dblIvaFacturado
    ' Description: Iva Facturado
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Double
    '====================================================================
    Public ReadOnly Property dblIvaFacturadoReal() As Double
        Get
            ' Tiene descuento y es Antes de iva
            If Request.Form("cboDescuento").Trim.Equals("1") Then
                If CInt(Request.Form("chkAntesdeIva")) = 1 Then

                    ' Se calcula el total facturado, sino se obtiene de la forma.
                    If CDbl(Request.Form("txtIvaFacturado")) = 0 Then
                        Return dblTotalFacturado * dblIvaAplicado
                    End If

                    If CInt(Request.Form("txtValidaIva")) = 0 Then
                        Return dblTotalFacturado * dblIvaAplicado
                    End If

                    ' Verificamos el rango de diferencia entre el Iva Facturado Calculado vs el capturado
                    ' diferencia de un peso +-
                    If Math.Abs((CDbl(Request.Form("txtIvaFacturado")) - (dblTotalFacturado * dblIvaAplicado))) > 1 Then
                        'Return dblTotalFacturado * dblIvaAplicado
                        Return CDbl(Request.Form("txtIvaFacturado"))
                    Else
                        Return CDbl(Request.Form("txtIvaFacturado"))
                    End If

                End If
            End If

            ' Mandamos el total facturado cuando tenga descuento despues de iva
            If Request.Form("cboDescuento").Trim.Equals("1") Then
                If CInt(Request.Form("chkDespuesdeIva")) = 1 Then

                    If CInt(Request.Form("txtValidaIva")) = 0 Then
                        Return dblTotalFacturado * dblIvaAplicado
                    End If

                    If Math.Abs((CDbl(Request.Form("txtIvaFacturado")) - (dblTotalFacturado * dblIvaAplicado))) > 1 Then
                        'Return dblTotalFacturado * dblIvaAplicado
                        Return CDbl(Request.Form("txtIvaFacturado"))
                    Else
                        Return CDbl(Request.Form("txtIvaFacturado"))
                    End If
                End If
            End If


            ' NO tiene descuento
            If Request.Form("cboDescuento").Trim.Equals("2") Then

                If CDbl(Request.Form("txtIvaFacturado")) = 0 Then
                    Return dblTotalFacturado * dblIvaAplicado
                End If

                If CInt(Request.Form("txtValidaIva")) = 0 Then
                    Return dblTotalFacturado * dblIvaAplicado
                End If

                If CDbl(Request.Form("txtIvaFacturado")) > 0 Then
                    If Math.Abs((CDbl(Request.Form("txtIvaFacturado")) - (dblTotalFacturado * dblIvaAplicado))) > 1 Then
                        'Return dblTotalFacturado * dblIvaAplicado
                        Return CDbl(Request.Form("txtIvaFacturado"))
                    Else
                        Return CDbl(Request.Form("txtIvaFacturado"))
                    End If
                End If
            End If

            Return 0
        End Get
    End Property

    '====================================================================
    ' Name       : dblImporteIeps
    ' Description: Importe IEPS
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Double
    '====================================================================
    Public ReadOnly Property dblImporteIeps() As Double
        Get
            If CDbl(Request.Form("txtImporteIEPS")) > 0 Then
                Return CDbl(Request.Form("txtImporteIEPS"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dblIvaDescuento
    ' Description: Iva Descuento
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Double
    '====================================================================
    Public ReadOnly Property dblIvaDescuento() As Double
        Get
            ' Mandamos el iva del descuento despues de iva
            If Request.Form("cboDescuento").Trim.Equals("1") Then
                If CInt(Request.Form("chkDespuesdeIva")) = 1 Then

                    If CInt(Request.Form("txtIvaDescuento")) = 0 Then
                        Return dblDescuentoDespuesdeIva * dblIvaAplicado
                    End If

                    If Math.Abs((CDbl(Request.Form("txtIvaDescuento")) - (dblDescuentoDespuesdeIva * dblIvaAplicado))) > 1 Then
                        Return CDbl(Request.Form("txtIvaDescuento"))
                    Else
                        Return CDbl(Request.Form("txtIvaDescuento"))
                    End If

                End If
            End If

            Return 0
        End Get
    End Property

    '====================================================================
    ' Name       : dblDescuentoAntesdeIva
    ' Description: Descuento antes de iva
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Double
    '====================================================================
    Public ReadOnly Property dblDescuentoAntesdeIva() As Double
        Get
            If CDbl(Request.Form("txtDescuentoAntesdeIva")) > 0 Then
                Return CDbl(Request.Form("txtDescuentoAntesdeIva"))
            End If

            Return 0

        End Get
    End Property

    '====================================================================
    ' Name       : dblDescuentoAntesdeIva
    ' Description: Descuento antes de iva
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Double
    '====================================================================
    Public ReadOnly Property dblDescuentoDespuesdeIva() As Double
        Get
            If CDbl(Request.Form("txtDescuentoDespuesdeIva")) > 0 Then
                Return CDbl(Request.Form("txtDescuentoDespuesdeIva"))
            End If

            Return 0
        End Get
    End Property

    '====================================================================
    ' Name       : dblSumaProductos
    ' Description: Suma de Productos
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Double
    '====================================================================
    Public ReadOnly Property dblSumaProductos() As Double
        Get
            If CDbl(Request.Form("txtSumaProductos")) > 0 Then
                Return CDbl(Request.Form("txtSumaProductos"))
            End If

            Return 0
        End Get
    End Property

    '====================================================================
    ' Name       : dblTotalNetoFacturado
    ' Description: Total NEto Facturado
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Double
    '====================================================================
    Public ReadOnly Property dblTotalNetoFacturado() As Double
        Get
            Return dblTotalFacturado + dblIvaFacturadoReal - dblIvaDescuento - dblDescuentoDespuesdeIva + dblImporteIeps
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaActual
    ' Description: Fecha actual utilizada para validar
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaActual() As String
        Get
            Return Date.Now.ToString("dd/MM/yyyy")
        End Get
    End Property

    '====================================================================
    ' Name       : intProveedorId
    ' Description: Toma la llave interna del proveedor
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intProveedorId() As Integer
        Get
            If Len(Request("hdnProveedorId")) > 0 Then
                Return CInt(Request("hdnProveedorId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strProveedorNombreId
    ' Description: Toma el numero sap del proveedor
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public ReadOnly Property strProveedorNombreId() As String
        Get
            If Len(Request("txtProveedorNombreId")) > 0 Then
                Return Request("txtProveedorNombreId")
            Else
                Return String.Empty
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : strRazonSocialProveedor
    ' Description: Razon social del proveedor
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRazonSocialProveedor() As String
        Get
            Return strmRazonSocialProveedor
        End Get
        Set(ByVal strValue As String)
            strmRazonSocialProveedor = strValue
        End Set
    End Property
    
    '====================================================================
    ' Name       : intFacturaId
    ' Description: Toma el identificador de la factuar de insumos de materia prima
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intFacturaId() As Integer
        Get
            If Len(Request("txtFacturaId")) > 0 Then
                Return CInt(Request("txtFacturaId"))
            Else
                Return 0
            End If
        End Get
    End Property

    Public Property intEliminaDetalle() As Integer
        Get
            Return intmEliminaDetalle
        End Get
        Set(ByVal Value As Integer)
            intmEliminaDetalle = Value

        End Set
    End Property

    '====================================================================
    ' Name       : blnReinicio
    ' Description: Comando a ejecutar
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property blnReinicio() As Integer
        Get
            If Not IsNothing(Request.QueryString("blnReinicio")) Then
                Return CInt((Request.QueryString("blnReinicio")))
            Else
                Return 0
            End If
        End Get
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

        Dim objDataArrayUsuario As Array = Nothing
        Dim objRegistroUsuario As String() = Nothing

        ' Verificamos que no sea un grupo de Usuario de FotoLab
        objDataArrayUsuario = clstblGrupoUsuario.strBuscar(intGrupoUsuarioId, String.Empty, String.Empty, String.Empty, 0, 0, CDate("01/01/1900"), "", 0, 0, strCadenaConexion)

        ' Validamos arreglo valido
        If IsArray(objDataArrayUsuario) AndAlso objDataArrayUsuario.Length > 0 Then

            ' Traemos información de usuario
            objRegistroUsuario = DirectCast(objDataArrayUsuario.GetValue(0), String())

            ' Si es Grupo de FotoLab y tiene permiso de acceso a la página se redirecciona hacia esta
            If Trim(objRegistroUsuario(1).ToString.ToUpper).Equals("FOTOLAB") Then
                If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
                    Call Response.Redirect("/Default.aspx?strURL=/_ScriptLibrary/" & strThisPageName)
                End If
            End If
        End If

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If


        Dim intTipoVigencia As Integer = 1 ' Solo vigentes
        Dim strHTML As StringBuilder

        ' -----------------------------------------------------------------
        ' ALTA O MODIFICACION DEL HEADER SE CONSULTAN
        ' -----------------------------------------------------------------
        If strCmd = "AltaFactura" Or strCmd = "ActualizarFactura" Then

            Dim objArrayMargenCompra As Array = Nothing
            Dim strRegistroMargenCompra As String() = Nothing
            Dim fltMargenInferiorCompra As Double = 0
            Dim fltMargenSuperiorCompra As Double = 0

            strHTML = New StringBuilder

            ' Obtenemos los Margenes Superiores e Inferiores  
            objArrayMargenCompra = clstblSucursal.strBuscar(intCompaniaId, intSucursalId, 0, 0, String.Empty, 0, 0, 0, CDate("01/01/1900"), String.Empty, String.Empty, String.Empty, String.Empty, 0, 0, strCadenaConexion)

            If IsArray(objArrayMargenCompra) AndAlso (objArrayMargenCompra.Length > 0) Then

                strRegistroMargenCompra = DirectCast(objArrayMargenCompra.GetValue(0), String())

                fltMargenInferiorCompra = (CDbl(strRegistroMargenCompra(7)) / 100)
                fltMargenSuperiorCompra = (CDbl(strRegistroMargenCompra(6)) / 100)

            End If

            Dim strErrorActualizarAgregar As String = String.Empty
            Dim intNumeroDeFactura As Integer = 0
            Dim dtmFechaRecepcion As Date
            Dim dtmFechaRegistroFactura As Date
            Dim intImpuestoFactura As Integer
            Dim strNumeroFactura As String
            Dim fltImporteNetoFactura As Double
            Dim fltImporteIvaFactura As Double
            Dim fltImporteIvaDescuento As Double
            Dim fltImporteDescuentoDespuesIva As Double
            Dim fltTotalFactura As Double
            Dim fltImporteIEPS As Double
            Dim fltDescuentoAntesIva As Double
            Dim fltImporteSumaProductos As Double

            dtmFechaRecepcion = CDate(clsCommons.strDMYtoMDY(Request.Form("txtFechaRecepcion").ToString))
            dtmFechaRegistroFactura = CDate(clsCommons.strDMYtoMDY(Request.Form("txtFechaFactura").ToString))

            intImpuestoFactura = CInt(Request.Form("cboIvaAplicado"))
            strNumeroFactura = Trim(Request.Form("txtNumeroFactura")).ToString() & Trim(Request.Form("txtNumeroFacturaRuta")).ToString()
            fltImporteNetoFactura = CDbl(Request.Form("txtTotalNetoFacturado"))
            fltImporteIvaFactura = CDbl(Request.Form("txtIvaFacturado"))
            fltImporteIvaDescuento = CDbl(Request.Form("txtIvaDescuento"))
            fltImporteDescuentoDespuesIva = CDbl(Request.Form("txtDescuentoDespuesdeIva"))
            fltTotalFactura = CDbl(Request.Form("txtTotalFacturado"))
            fltImporteIEPS = CDbl(Request.Form("txtImporteIEPS"))
            fltDescuentoAntesIva = CDbl(Request.Form("txtDescuentoAntesdeIva"))
            fltImporteSumaProductos = CDbl(Request.Form("txtSumaProductos"))

            Select Case strCmd

                Case "AltaFactura"

                    ' Agregamos la factura (sin Folio este se asigna al afectarla)
                    intNumeroDeFactura = clsCapturaInsumosMateriaPrima.strAgregarEditarInsumosMateriaPrima(intFacturaId, intProveedorId, intCompaniaId, intSucursalId, dtmFechaRecepcion, dtmFechaRegistroFactura, intImpuestoFactura, strNumeroFactura, fltImporteNetoFactura, fltImporteIvaFactura, fltImporteIvaDescuento, fltImporteDescuentoDespuesIva, fltTotalFactura, fltImporteIEPS, fltDescuentoAntesIva, fltImporteSumaProductos, strUsuarioNombre, strCadenaConexion)


                    If intNumeroDeFactura < 0 Then
                        strErrorActualizarAgregar = "-100"
                    Else
                        strErrorActualizarAgregar = "0"
                    End If

                    strHTML.Append("<script language='Javascript'> parent.fnUpInsumosMateriaPrima( " & _
                                strComitasDobles & intNumeroDeFactura.ToString & strComitasDobles & "," & _
                                strComitasDobles & fltMargenInferiorCompra.ToString & strComitasDobles & "," & _
                                strComitasDobles & fltMargenSuperiorCompra.ToString & strComitasDobles & "," & _
                                strComitasDobles & strErrorActualizarAgregar & strComitasDobles & _
                                "); </script>")

                    Response.Write(strHTML.ToString)
                    Response.End()

                Case "ActualizarFactura"

                    ' Se Actualiza el Registro de Factura
                    intNumeroDeFactura = clsCapturaInsumosMateriaPrima.strAgregarEditarInsumosMateriaPrima(intFacturaId, intProveedorId, intCompaniaId, intSucursalId, dtmFechaRecepcion, dtmFechaRegistroFactura, intImpuestoFactura, strNumeroFactura, fltImporteNetoFactura, fltImporteIvaFactura, fltImporteIvaDescuento, fltImporteDescuentoDespuesIva, fltTotalFactura, fltImporteIEPS, fltDescuentoAntesIva, fltImporteSumaProductos, strUsuarioNombre, strCadenaConexion)

                    If intNumeroDeFactura < 0 Then
                        strErrorActualizarAgregar = "-100"
                    Else
                        strErrorActualizarAgregar = "0"
                    End If

                    strHTML.Append("<script language='Javascript'> parent.fnUpInsumosMateriaPrima( " & _
                                    strComitasDobles & intNumeroDeFactura.ToString & strComitasDobles & "," & _
                                    strComitasDobles & fltMargenInferiorCompra.ToString & strComitasDobles & "," & _
                                    strComitasDobles & fltMargenSuperiorCompra.ToString & strComitasDobles & "," & _
                                    strComitasDobles & strErrorActualizarAgregar & strComitasDobles & _
                                   "); </script>")

                    Response.Write(strHTML.ToString)
                    Response.End()
            End Select

        Else

            Select Case strCmd

                Case "BuscaProveedor" ' Realizamos la busqueda del proveedor

                    strHTML = New StringBuilder

                    Dim objArrayProveedor As Array = Nothing
                    Dim objRegistroProveedor As System.Collections.SortedList = Nothing

                    Dim strBusquedaProveedorId As String = String.Empty
                    Dim strBusquedaProveedorNombreId As String = String.Empty
                    Dim strBusquedaProveedorRazonSocial As String = String.Empty
                    Dim strBusquedaProveedorRFC As String = String.Empty
                    Dim strBusquedaCapturaCosto As String = String.Empty
                    Dim strBusquedaMargenFactura As String = String.Empty

                    Dim strBusquedaProveedorError As String = "-100"

                    If IsNumeric(Mid(strProveedorNombreId, 1, 4)) Then

                        objArrayProveedor = clsCapturaInsumosMateriaPrima.strBuscarProveedorInsumosMateriaPrima(intCompaniaId, intSucursalId, String.Empty, strProveedorNombreId, intTipoVigencia, 0, 0, strCadenaConexion)

                        If IsArray(objArrayProveedor) AndAlso objArrayProveedor.Length > 0 Then

                            objRegistroProveedor = DirectCast(objArrayProveedor.GetValue(0), System.Collections.SortedList)

                            ' Asignamos los datos del proveedor
                            strBusquedaProveedorError = "0"

                            strBusquedaProveedorId = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("intProveedorId")))
                            strBusquedaProveedorNombreId = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorNombreId")))
                            strBusquedaProveedorRazonSocial = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorRazonSocial")))
                            strBusquedaProveedorRFC = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorRFC")))
                            strBusquedaMargenFactura = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("fltMargenFactura")))

                            Select Case CByte(objRegistroProveedor.Item("blnCapturaCosto"))
                                Case 255
                                    strBusquedaCapturaCosto = "1"
                                Case Else
                                    strBusquedaCapturaCosto = "0"
                            End Select

                        End If

                    End If

                    strHTML.Append("<script language='Javascript'> parent.fnUpBuscarProveedor( " & _
                                   strComitasDobles & strBusquedaProveedorId & strComitasDobles & "," & _
                                   strComitasDobles & strBusquedaProveedorNombreId & strComitasDobles & "," & _
                                   strComitasDobles & strBusquedaProveedorRazonSocial & strComitasDobles & "," & _
                                   strComitasDobles & strBusquedaProveedorRFC & strComitasDobles & "," & _
                                   strComitasDobles & strBusquedaCapturaCosto & strComitasDobles & "," & _
                                   strComitasDobles & strBusquedaMargenFactura & strComitasDobles & "," & _
                                   strComitasDobles & strBusquedaProveedorError & strComitasDobles & _
                                   "); </script>")

                    Response.Write(strHTML.ToString)
                    Response.End()

                Case "BuscarFactura" ' Validamos que la factura NO este ya capturada

                    strHTML = New StringBuilder
                    Dim strErrorBuscarFactura As String = String.Empty

                    Dim objArrayFactura As Array = Nothing
                    Dim strRegistroFactura As String() = Nothing

                    Dim objArrayEstadoFactura As Array = Nothing
                    Dim strRegistroEstadoFactura() As String = Nothing

                    Dim strFacturaCapturada As String = Trim(Request.Form("txtNumeroFactura")).ToString() & Trim(Request.Form("txtNumeroFacturaRuta")).ToString()

                    objArrayEstadoFactura = clsCapturaInsumosMateriaPrima.strBuscarFactura(Me.intCompaniaId, Me.intSucursalId, Me.intProveedorId, strFacturaCapturada, strCadenaConexion)

                    If IsArray(objArrayEstadoFactura) AndAlso objArrayEstadoFactura.Length > 0 Then

                        If objArrayEstadoFactura.Length > 0 Then
                            strErrorBuscarFactura = "-103"
                        End If

                        strHTML.Append("<script language='Javascript'> parent.fnUpBuscarFactura( " & _
                                    strComitasDobles & strRazonSocialProveedor.ToString & strComitasDobles & "," & _
                                    strComitasDobles & strErrorBuscarFactura & strComitasDobles & _
                                    "); </script>")

                        Response.Write(strHTML.ToString)
                        Response.End()

                    End If

                Case "Calculo" ' Realizamos los calculos 

                    strHTML = New StringBuilder

                    strHTML.Append("<script language='Javascript'> parent.fnUpCalculoImportes(" & _
                                  strComitasDobles & FormatNumber(dblSumaProductos, 2) & strComitasDobles & "," & _
                                  strComitasDobles & FormatNumber(dblDescuentoAntesdeIva, 2) & strComitasDobles & "," & _
                                  strComitasDobles & FormatNumber(dblTotalFacturado, 2) & strComitasDobles & "," & _
                                  strComitasDobles & FormatNumber(dblImporteIeps, 2) & strComitasDobles & "," & _
                                  strComitasDobles & FormatNumber(dblIvaFacturadoReal, 2) & strComitasDobles & "," & _
                                  strComitasDobles & FormatNumber(dblIvaDescuento, 2) & strComitasDobles & "," & _
                                  strComitasDobles & FormatNumber(dblDescuentoDespuesdeIva, 2) & strComitasDobles & "," & _
                                  strComitasDobles & FormatNumber(dblTotalNetoFacturado, 2) & strComitasDobles & _
                                  "); </script>")

                    Response.Write(strHTML.ToString)
                    Response.End()


                    'ELIMINA EL DETALLE CUANDO NO SE CONFIRMA Y SE PRESIONA EL BOTON REGRESAR
                Case "ModificarDatos"

                    intEliminaDetalle = clsCapturaInsumosMateriaPrima.intEliminar(intFacturaId, 0, 0, 0, CDate("01/01/1900"), strUsuarioNombre, strCadenaConexion)

            End Select
        End If
    End Sub

End Class
