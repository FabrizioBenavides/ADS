Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Business.clsConcentrador.clsSucursal.clsMercancia
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text


Public Class clsMercanciaCapturarCompraDirecta
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

    Const CapturaConRemision As Integer = 1
    Const CapturaSinRemision As Integer = 2

    Const CapturaConOrden As Integer = 1
    Const CapturaSinOrden As Integer = 2

    Private strmParametros As String = ""

    Private strmRazonSocialProveedor As String = ""
    Private strmRFCProveedor As String = ""

    Private strmNumFactura As String = ""
    Private strmFechaRecepcion As String = ""
    Private strmFechaFactura As String = ""
    Private intmIvaFactura As Integer = 0
    Private strmTotalFacturado As String = ""
    Private strmIvaFacturado As String = ""
    Private strmIvaDescuento As String = ""
    Private strmDescuentoDespuesIva As String = ""
    Private strmTotalNetoFacturado As String = ""
    Private strmImporteIeps As String = ""
    Private strmDescuentoAntesIva As String = ""
    Private strmImporteSumaProductos As String = ""
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
                Return ""
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
        objIvaAplicado = clstblImpuesto.strBuscar(0, 0, "", 0, CDate("01/01/1900"), "", 0, 0, strCadenaConexion)

        ' Checamos si es arreglo válido
        If IsArray(objIvaAplicado) Then
            If objIvaAplicado.Length > 0 Then

                strcboIvaAplicadoHTML = New StringBuilder

                'strcboIvaAplicadoHTML.Append("document.forms[0].elements['" & strNombreComponente & "'].options[" & intContador & "] = new Option(""" & "Elije un valor" & """,""" & "-1" & """);" & vbCrLf)

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
            Return ""
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
            Return ""
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
            'Return dblTotalFacturado - dblDescuentoAntesdeIva + dblIvaFacturadoReal - dblIvaDescuento - dblDescuentoDespuesdeIva
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
    ' Name       : strParametros
    ' Description: Parámetros
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strParametros() As String
        Get
            Return strmParametros
        End Get
        Set(ByVal strValue As String)
            strmParametros = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnCapturaRemision
    ' Description: Inidca que el proveedor solo permite cpturas con remision
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property blnCapturaRemision() As Boolean
        Get
            Dim blnRegreso As Boolean = False

            If Len(Request("blnCapturaRemision")) > 0 AndAlso CInt(Request("blnCapturaRemision")) = 1 Then
                blnRegreso = True
            End If

            Return blnRegreso

        End Get
    End Property

    '====================================================================
    ' Name       : blnRemisionDisponible
    ' Description: Inidca que hay remisiones disponibles para el proveedor
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property blnRemisionDisponible() As Boolean
        Get
            Dim blnRegreso As Boolean = False

            If Len(Request("hdnRemisionDisponible")) > 0 AndAlso CInt(Request("hdnRemisionDisponible")) = 1 Then
                blnRegreso = True
            End If

            Return blnRegreso

        End Get
    End Property

    '====================================================================
    ' Name       : blnSoloOrden
    ' Description: Inidca que el proveedor solo permite cpturas con ordenes
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property blnSoloOrden() As Boolean
        Get
            Dim blnRegreso As Boolean = False

            If Len(Request("hdnSoloOrden")) > 0 AndAlso CInt(Request("hdnSoloOrden")) = 1 Then
                blnRegreso = True
            End If

            Return blnRegreso

        End Get
    End Property

    '====================================================================
    ' Name       : blnOrdenDisponible
    ' Description: Inidca que hay ordenes disponibles para el proveedor
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property blnOrdenDisponible() As Boolean
        Get
            Dim blnRegreso As Boolean = False

            If Len(Request("hdnOrdenDisponible")) > 0 AndAlso CInt(Request("hdnOrdenDisponible")) = 1 Then
                blnRegreso = True
            End If

            Return blnRegreso

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
    ' Name       : intRemisionId
    ' Description: Id de la remision
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : integer
    '====================================================================
    Public ReadOnly Property intRemisionId() As Long
        Get
            Dim intRegreso As Long = 0

            If Len(Request("hdnRemisionId")) > 0 Then
                intRegreso = CLng(Request("hdnRemisionId"))
            End If

            Return intRegreso

        End Get

    End Property

    '====================================================================
    ' Name       : intRemisionFolio
    ' Description: Folio de la remision
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : integer
    '====================================================================
    Public ReadOnly Property intRemisionFolio() As Integer
        Get
            Dim intRegreso As Integer = 0

            If Len(Request("txtRemisionFolio")) > 0 Then
                intRegreso = CInt(Request("txtRemisionFolio"))
            End If

            Return intRegreso

        End Get

    End Property

    '====================================================================
    ' Name       : intFolioOrdenId
    ' Description: Toma el numero sap del proveedor
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : integer
    '====================================================================
    Public ReadOnly Property intFolioOrdenId() As Integer
        Get
            Dim intRegreso As Integer = 0

            If Len(Request("txtFolioOrdenId")) > 0 Then
                intRegreso = CInt(Request("txtFolioOrdenId"))
            End If

            Return intRegreso

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
                Return ""
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
    ' Name       : strRFCProveedor
    ' Description: Nombre del proveedor
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strRFCProveedor() As String
        Get
            Return strmRFCProveedor
        End Get
        Set(ByVal strValue As String)
            strmRFCProveedor = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strNumFactura
    ' Description: Num factura
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strNumFactura() As String
        Get
            Return strmNumFactura
        End Get
        Set(ByVal strValue As String)
            strmNumFactura = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaRecepcion
    ' Description: Fecha recepcion factura
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
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
    ' Name       : strFechaFactura
    ' Description: fecha factura
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strFechaFactura() As String
        Get
            Return strmFechaFactura
        End Get
        Set(ByVal strValue As String)
            strmFechaFactura = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intIvaFactura
    ' Description: IVA Modificado
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intIvaFactura() As Integer
        Get
            Return intmIvaFactura
        End Get
        Set(ByVal intValue As Integer)
            intmIvaFactura = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTotalFacturado
    ' Description: Total facturado
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strTotalFacturado() As String
        Get
            Return strmTotalFacturado
        End Get
        Set(ByVal strValue As String)
            strmTotalFacturado = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strIvaFacturado
    ' Description: IVA facturado
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strIvaFacturado() As String
        Get
            Return strmIvaFacturado
        End Get
        Set(ByVal strValue As String)
            strmIvaFacturado = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strIvaDescuento
    ' Description: IVA Descuento
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strIvaDescuento() As String
        Get
            Return strmIvaDescuento
        End Get
        Set(ByVal strValue As String)
            strmIvaDescuento = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strIDescuentoDespuesIva
    ' Description: IVA Descuento
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strDescuentoDespuesIva() As String
        Get
            Return strmDescuentoDespuesIva
        End Get
        Set(ByVal strValue As String)
            strmDescuentoDespuesIva = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strImporteIeps
    ' Description: IVA Descuento
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strImporteIeps() As String
        Get
            Return strmImporteIeps
        End Get
        Set(ByVal strValue As String)
            strmImporteIeps = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strDescuentoAntesIva
    ' Description: Descuento antes de IVA
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strDescuentoAntesIva() As String
        Get
            Return strmDescuentoAntesIva
        End Get
        Set(ByVal strValue As String)
            strmDescuentoAntesIva = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strImporteSumaProductos
    ' Description: Suma del importe de productos antes de descuentos y aplicar IVA
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strImporteSumaProductos() As String
        Get
            Return strmImporteSumaProductos
        End Get
        Set(ByVal strValue As String)
            strmImporteSumaProductos = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : strTotalNetoFacturado
    ' Description: IVA Descuento
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strTotalNetoFacturado() As String
        Get
            Return strmTotalNetoFacturado
        End Get
        Set(ByVal strValue As String)
            strmTotalNetoFacturado = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intCompraDirectaId
    ' Description: Toma el identificador de la compra directa 
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCompraDirectaId() As Integer
        Get
            If Len(Request("txtCompraDirectaId")) > 0 Then
                Return CInt(Request("txtCompraDirectaId"))
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
        objDataArrayUsuario = clstblGrupoUsuario.strBuscar(intGrupoUsuarioId, "", "", "", 0, 0, CDate("01/01/1900"), "", 0, 0, strCadenaConexion)

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
        ' EN EL ALTA O MODIFICACION DEL HEADER DE LA COMPRA SE CONSULTAN
        ' LOS MARGENES DE COMPRA Y SE VALIDA EL TIPO DE CAPTURA PERMITIDA
        ' -----------------------------------------------------------------
        If strCmd = "AltaCompra" Or strCmd = "ActualizarCompra" Then

            Dim objArrayMargenCompra As Array = Nothing
            Dim strRegistroMargenCompra As String() = Nothing

            Dim blnRemisionDisponible As Boolean = False
            Dim blnOrdenDisponible As Boolean = False

            Dim intCapturaDetalle As Integer
            Dim fltMargenInferiorCompra As Double = 0
            Dim fltMargenSuperiorCompra As Double = 0

            strHTML = New StringBuilder

            ' Obtenemos los Margenes Superiores e Inferiores  
            objArrayMargenCompra = clstblSucursal.strBuscar(intCompaniaId, intSucursalId, 0, 0, "", 0, 0, 0, CDate("01/01/1900"), "", "", "", "", 0, 0, strCadenaConexion)

            If IsArray(objArrayMargenCompra) AndAlso (objArrayMargenCompra.Length > 0) Then
                strRegistroMargenCompra = DirectCast(objArrayMargenCompra.GetValue(0), String())

                fltMargenInferiorCompra = (CDbl(strRegistroMargenCompra(7)) / 100)
                fltMargenSuperiorCompra = (CDbl(strRegistroMargenCompra(6)) / 100)

            End If

            ' Captura con remision
            If blnCapturaRemision Then

                ' Obtenemos si hay remisiones para el proveedor
                Dim objArrayRemisiones As Array = clsCompras.clsRemision.strBuscar(intCompaniaId, intSucursalId, 0, CDate("01/01/1900"), CDate("01/01/1900"), intProveedorId, 1, 0, 0, strCadenaConexion)

                If IsArray(objArrayRemisiones) AndAlso objArrayRemisiones.Length > 0 Then
                    blnRemisionDisponible = True
                End If

                If Not blnRemisionDisponible Then
                    ' ERROR captura solo es con remision y no hay disponibles 

                    strHTML.Append("<script language='Javascript'> parent.fnUpCompraDirecta( " & _
                    strComitasDobles & intCapturaDetalle.ToString & strComitasDobles & "," & _
                    strComitasDobles & "0" & strComitasDobles & "," & _
                    strComitasDobles & fltMargenInferiorCompra.ToString & strComitasDobles & "," & _
                    strComitasDobles & fltMargenSuperiorCompra.ToString & strComitasDobles & "," & _
                    strComitasDobles & "-80" & strComitasDobles & _
                    "); </script>")

                    Response.Write(strHTML.ToString)
                    Response.End()

                End If

            End If

            ' Obtenemos si hay ordenes para el proveedor
            Dim objArrayOrdenes As Array = clsConcentrador.clsSucursal.clsMercancia.clsCompras.strBuscarOrdenes(intCompaniaId, intSucursalId, intProveedorId, strCadenaConexion)

            If IsArray(objArrayOrdenes) AndAlso (objArrayOrdenes.Length > 0) Then
                blnOrdenDisponible = True
            End If

            If blnSoloOrden Then

                intCapturaDetalle = CapturaConOrden

                If Not blnOrdenDisponible Then
                    ' ERROR captura solo es con ordenes y no hay disponibles 

                    strHTML.Append("<script language='Javascript'> parent.fnUpCompraDirecta( " & _
                    strComitasDobles & intCapturaDetalle.ToString & strComitasDobles & "," & _
                    strComitasDobles & "0" & strComitasDobles & "," & _
                    strComitasDobles & fltMargenInferiorCompra.ToString & strComitasDobles & "," & _
                    strComitasDobles & fltMargenSuperiorCompra.ToString & strComitasDobles & "," & _
                    strComitasDobles & "-90" & strComitasDobles & _
                    "); </script>")

                    Response.Write(strHTML.ToString)
                    Response.End()

                End If
            Else
                If blnOrdenDisponible Then
                    intCapturaDetalle = CapturaConOrden
                Else
                    intCapturaDetalle = CapturaSinOrden
                End If
            End If

            If blnOrdenDisponible And intFolioOrdenId < 1 Then
                ' ERROR Hay ordenes disponibles y no se ha seleccionado una

                strHTML.Append("<script language='Javascript'> parent.fnUpCompraDirecta( " & _
                strComitasDobles & intCapturaDetalle.ToString & strComitasDobles & "," & _
                strComitasDobles & "0" & strComitasDobles & "," & _
                strComitasDobles & fltMargenInferiorCompra.ToString & strComitasDobles & "," & _
                strComitasDobles & fltMargenSuperiorCompra.ToString & strComitasDobles & "," & _
                strComitasDobles & "-95" & strComitasDobles & _
                "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            End If


            Dim strErrorActualizarAgregarCompraDirecta As String = ""

            Dim objArrayCompraDirecta As Array = Nothing
            Dim strRegistroCompraDirecta As String()

            Dim intNumeroDeCompra As Integer = 0

            Dim dtmCompraDirectaRecepcion As Date
            Dim dtmCompraDirectaRegistroFactura As Date

            Dim intImpuestoFactura As Integer
            Dim strCompraDirectaNumeroFactura As String
            Dim fltCompraDirectaImporteNetoFactura As Double
            Dim fltCompraDirectaImporteIvaFactura As Double
            Dim fltCompraDirectaImporteIvaDescuento As Double
            Dim fltCompraDirectaImporteDescuentoDespuesIva As Double
            Dim fltCompraDirectaTotalFactura As Double
            Dim fltCompraDirectaImporteIEPS As Double
            Dim fltCompraDirectaDescuentoAntesIva As Double
            Dim fltCompraDirectaImporteSumaProductos As Double

            dtmCompraDirectaRecepcion = CDate(clsCommons.strDMYtoMDY(Request.Form("txtFechaRecepcion").ToString))
            dtmCompraDirectaRegistroFactura = CDate(clsCommons.strDMYtoMDY(Request.Form("txtFechaFactura").ToString))

            intImpuestoFactura = CInt(Request.Form("cboIvaAplicado"))
            strCompraDirectaNumeroFactura = Trim(Request.Form("txtNumeroFactura")).ToString() & Trim(Request.Form("txtNumeroFacturaRuta")).ToString()
            fltCompraDirectaImporteNetoFactura = CDbl(Request.Form("txtTotalNetoFacturado"))
            fltCompraDirectaImporteIvaFactura = CDbl(Request.Form("txtIvaFacturado"))
            fltCompraDirectaImporteIvaDescuento = CDbl(Request.Form("txtIvaDescuento"))
            fltCompraDirectaImporteDescuentoDespuesIva = CDbl(Request.Form("txtDescuentoDespuesdeIva"))
            fltCompraDirectaTotalFactura = CDbl(Request.Form("txtTotalFacturado"))
            fltCompraDirectaImporteIEPS = CDbl(Request.Form("txtImporteIEPS"))
            fltCompraDirectaDescuentoAntesIva = CDbl(Request.Form("txtDescuentoAntesdeIva"))
            fltCompraDirectaImporteSumaProductos = CDbl(Request.Form("txtSumaProductos"))

            Select Case strCmd

                Case "AltaCompra"

                    ' Agregamos la compra directa (sin Folio este se asigna al afectarla)
                    intNumeroDeCompra = clsConcentrador.clsSucursal.clsMercancia.clsCompras.intActualizarAgregar(intCompraDirectaId, intProveedorId, intCompaniaId, intSucursalId, dtmCompraDirectaRecepcion, dtmCompraDirectaRegistroFactura, intImpuestoFactura, strCompraDirectaNumeroFactura, fltCompraDirectaImporteNetoFactura, fltCompraDirectaImporteIvaFactura, fltCompraDirectaImporteIvaDescuento, fltCompraDirectaImporteDescuentoDespuesIva, fltCompraDirectaTotalFactura, fltCompraDirectaImporteIEPS, fltCompraDirectaDescuentoAntesIva, fltCompraDirectaImporteSumaProductos, strUsuarioNombre, strCadenaConexion)

                    If intNumeroDeCompra < 0 Then
                        strErrorActualizarAgregarCompraDirecta = "-100"
                    Else
                        strErrorActualizarAgregarCompraDirecta = "0"
                    End If

                    strHTML.Append("<script language='Javascript'> parent.fnUpCompraDirecta( " & _
                                strComitasDobles & intCapturaDetalle.ToString & strComitasDobles & "," & _
                                strComitasDobles & intNumeroDeCompra.ToString & strComitasDobles & "," & _
                                strComitasDobles & fltMargenInferiorCompra.ToString & strComitasDobles & "," & _
                                strComitasDobles & fltMargenSuperiorCompra.ToString & strComitasDobles & "," & _
                                strComitasDobles & strErrorActualizarAgregarCompraDirecta & strComitasDobles & _
                                "); </script>")

                    Response.Write(strHTML.ToString)
                    Response.End()

                Case "ActualizarCompra"

                    ' Se Actualiza el Registro de Compra Directa
                    intNumeroDeCompra = clsConcentrador.clsSucursal.clsMercancia.clsCompras.intActualizarAgregar(intCompraDirectaId, intProveedorId, intCompaniaId, intSucursalId, dtmCompraDirectaRecepcion, dtmCompraDirectaRegistroFactura, intImpuestoFactura, strCompraDirectaNumeroFactura, fltCompraDirectaImporteNetoFactura, fltCompraDirectaImporteIvaFactura, fltCompraDirectaImporteIvaDescuento, fltCompraDirectaImporteDescuentoDespuesIva, fltCompraDirectaTotalFactura, fltCompraDirectaImporteIEPS, fltCompraDirectaDescuentoAntesIva, fltCompraDirectaImporteSumaProductos, strUsuarioNombre, strCadenaConexion)

                    If intNumeroDeCompra < 0 Then
                        strErrorActualizarAgregarCompraDirecta = "-100"
                    Else
                        strErrorActualizarAgregarCompraDirecta = "0"
                    End If

                    If blnReinicio = 0 Then
                        intCapturaDetalle = 3
                    End If

                    strHTML.Append("<script language='Javascript'> parent.fnUpCompraDirecta( " & _
                                    strComitasDobles & intCapturaDetalle.ToString & strComitasDobles & "," & _
                                    strComitasDobles & intNumeroDeCompra.ToString & strComitasDobles & "," & _
                                    strComitasDobles & fltMargenInferiorCompra.ToString & strComitasDobles & "," & _
                                    strComitasDobles & fltMargenSuperiorCompra.ToString & strComitasDobles & "," & _
                                    strComitasDobles & strErrorActualizarAgregarCompraDirecta & strComitasDobles & _
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

                    Dim strBusquedaProveedorId As String = ""
                    Dim strBusquedaProveedorNombreId As String = ""
                    Dim strBusquedaProveedorRazonSocial As String = ""
                    Dim strBusquedaProveedorRFC As String = ""

                    Dim strBusquedaCapturaRemision As String = ""
                    Dim strBusquedaRemisionDisponible As String = ""

                    Dim strBusquedaSoloOrden As String = ""
                    Dim strBusquedaOrdenDisponible As String = ""

                    Dim strBusquedaCapturaCosto As String = ""
                    Dim strBusquedaMargenFactura As String = ""

                    Dim strBusquedaProveedorError As String = "-100"

                    If IsNumeric(Mid(strProveedorNombreId, 1, 4)) Then

                        objArrayProveedor = clsProveedor.strBuscarPorSucursal(intCompaniaId, intSucursalId, "", strProveedorNombreId, intTipoVigencia, 0, 0, strCadenaConexion)

                        If IsArray(objArrayProveedor) AndAlso objArrayProveedor.Length > 0 Then

                            objRegistroProveedor = DirectCast(objArrayProveedor.GetValue(0), System.Collections.SortedList)

                            ' Asignamos los datos del proveedor
                            strBusquedaProveedorError = "0"

                            strBusquedaProveedorId = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("intProveedorId")))
                            strBusquedaProveedorNombreId = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorNombreId")))
                            strBusquedaProveedorRazonSocial = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorRazonSocial")))
                            strBusquedaProveedorRFC = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorRFC")))
                            strBusquedaMargenFactura = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("fltMargenFactura")))

                            Select Case CByte(objRegistroProveedor.Item("blnSoloOrden"))
                                Case 255
                                    strBusquedaSoloOrden = "1"
                                Case Else
                                    strBusquedaSoloOrden = "0"
                            End Select
                            Select Case CByte(objRegistroProveedor.Item("blnOrdenDisponible"))
                                Case 255
                                    strBusquedaOrdenDisponible = "1"
                                Case Else
                                    strBusquedaOrdenDisponible = "0"
                            End Select

                            Select Case CByte(objRegistroProveedor.Item("blnCapturaRemision"))
                                Case 255
                                    strBusquedaCapturaRemision = "1"
                                Case Else
                                    strBusquedaCapturaRemision = "0"
                            End Select
                            Select Case CByte(objRegistroProveedor.Item("blnRemisionDisponible"))
                                Case 255
                                    strBusquedaRemisionDisponible = "1"
                                Case Else
                                    strBusquedaRemisionDisponible = "0"
                            End Select
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
                                   strComitasDobles & strBusquedaSoloOrden & strComitasDobles & "," & _
                                   strComitasDobles & strBusquedaOrdenDisponible & strComitasDobles & "," & _
                                   strComitasDobles & strBusquedaCapturaRemision & strComitasDobles & "," & _
                                   strComitasDobles & strBusquedaRemisionDisponible & strComitasDobles & "," & _
                                   strComitasDobles & strBusquedaCapturaCosto & strComitasDobles & "," & _
                                   strComitasDobles & strBusquedaMargenFactura & strComitasDobles & "," & _
                                   strComitasDobles & strBusquedaProveedorError & strComitasDobles & _
                                   "); </script>")

                    Response.Write(strHTML.ToString)
                    Response.End()

                Case "BuscarFactura" ' Validamos que la factura no este ya capturada

                    strHTML = New StringBuilder
                    Dim strErrorBuscarFactura As String = ""

                    Dim objArrayFactura As Array = Nothing
                    Dim strRegistroFactura As String() = Nothing

	                Dim objArrayEstadoFactura As Array = Nothing
	                Dim strRegistroEstadoFactura() As String = Nothing

                    Dim strFacturaCapturada As String = Trim(Request.Form("txtNumeroFactura")).ToString() & Trim(Request.Form("txtNumeroFacturaRuta")).ToString()

	                objArrayEstadoFactura = clsConcentrador.clsSucursal.clsMercancia.clsCompras.clsFacturaElectronica.strBuscarEstadoFactura( Me.intCompaniaId, Me.intSucursalId, Me.intProveedorId, strFacturaCapturada, strCadenaConexion )
                	
	                If IsArray(objArrayEstadoFactura) AndAlso objArrayEstadoFactura.Length > 0 Then
                	
		                If objArrayEstadoFactura.Length = 1 Then
			                strErrorBuscarFactura = "-101"

		                Else If objArrayEstadoFactura.Length = 2 Then
			                strErrorBuscarFactura = "-102"

		                Else
			                strErrorBuscarFactura = "-103"

		                End If

                        strHTML.Append("<script language='Javascript'> parent.fnUpBuscarFactura( " & _
                                    strComitasDobles & strRazonSocialProveedor.ToString & strComitasDobles & "," & _
                                    strComitasDobles & strErrorBuscarFactura & strComitasDobles & _
                                    "); </script>")

                        Response.Write(strHTML.ToString)
                        Response.End()                  

	                Else

                        'Busca la Factura para la sucursal
                        objArrayFactura = clstblCompraDirecta.strBuscar(0, intProveedorId, intCompaniaId, intSucursalId, 0, 0, CDate("01/01/1900"), strFacturaCapturada, CDate("01/01/1900"), 0, 0, 0, 0, 0, CDate("01/01/1900"), strUsuarioNombre, 0, 0, strCadenaConexion, 0)

                        If IsArray(objArrayFactura) AndAlso objArrayFactura.Length > 0 Then
                            strRegistroFactura = DirectCast(objArrayFactura.GetValue(0), String())

                            strErrorBuscarFactura = "-100"
                        Else
                            strErrorBuscarFactura = "0"
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

                Case "ModificarDatos"

                    intEliminaDetalle = clstblArticuloCompraDirecta.intEliminar(intCompraDirectaId, 0, 0, 0, CDate("01/01/1900"), strUsuarioNombre, strCadenaConexion)

            End Select

        End If


    End Sub


End Class
