Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class clsMercanciaCapturarFacturaManual
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
    ' Description: Comando a utilizar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return Request("strCmd")
        End Get
    End Property

    '====================================================================
    ' Name       : strMensaje
    ' Description: Mensaje
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strMensaje() As String
        Get
            Return strmMensaje
        End Get
        Set(ByVal strValue As String)
            strmMensaje = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : dtmValidaFechaFactura
    ' Description: Fecha mínima para capturar una factura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmValidaFechaFactura() As String
        Get
            Dim intMeses As Integer = -2

            Return Date.Now.AddMonths(intMeses).ToString("MM/dd/yyyy")
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaActual
    ' Description: Fecha Actual
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaActual() As String
        Get
            Return Date.Now.ToString("MM/dd/yyyy")
        End Get
    End Property

    '====================================================================
    ' Name       : intProveedorId
    ' Description: Número de proveedor Capturado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intProveedorId() As Integer
        Get
            Return CInt(Request("txtProveedor"))
        End Get
    End Property

    '====================================================================
    ' Name       : strNumero
    ' Description: NUmero de Documento
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strNumero() As String
        Get
            Return Trim(Request("txtNumeroFactura")).ToUpper
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
        Dim strHTML As StringBuilder

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        Select Case strCmd
            Case "BuscaProveedor"
                Dim objDataArray As Array = Nothing
                Dim objRegistro As String() = Nothing
                Dim intTipoProveedorId As Integer
                Dim strProveedorIdNombre As String = ""

                strProveedorIdNombre = Trim(Request.Form("txtProveedor"))

                ' Obtenemos el tipo de Proveedor
                objDataArray = clstblTipoProveedor.strBuscar(0, "PROVEEDORMAYORISTA", "", CDate("01/01/1900"), "", 0, 0, strCadenaConexion)

                If IsArray(objDataArray) AndAlso objDataArray.Length > 0 Then
                    objRegistro = DirectCast(objDataArray.GetValue(0), String())
                    intTipoProveedorId = CInt(objRegistro(0).ToString)
                End If

                ' Verificamos el número de proveedor
                objDataArray = Nothing ' Se elimino clsConcentrador.clsSucursal.clsMercancia.clsCompras.strBuscarProveedor(intCompaniaId, intSucursalId, intTipoProveedorId, strProveedorIdNombre, 0, 0, strCadenaConexion)

                strHTML = New StringBuilder

                If IsArray(objDataArray) AndAlso objDataArray.Length > 0 Then


                    objRegistro = DirectCast(objDataArray.GetValue(0), String())


                    'fncActualizaProveedor
                    strHTML.Append("<script language='javascript'>parent.fncActualizaProveedor(1,'" & objRegistro(0).ToString & "','" & clsCommons.strFormatearDescripcion(objRegistro(1).ToString) & "');</script>")
                Else
                    ' No se encontro el proveedor 
                    strHTML.Append("<script language='javascript'>parent.fncActualizaProveedor(0,'','');</script>")
                End If
                ' Mandamos ejecutar la acción de javascript
                Call Response.Write(strHTML.ToString)
                Call Response.End()

            Case "ValidaDocumento"
                Dim objDataArray As Array = Nothing
                Dim objRegistro As String() = Nothing
                Dim intResultado As Integer = 0
                Dim dtmFacturaManualEmisionDocumento As Date
                Dim dtmFacturaManualRegistro As Date
                Dim fltFacturaManualImporteNeto As Double
                Dim fltFacturaManualImporteIva As Double
                Dim fltFacturaManualImporteTotal As Double
                Dim fltFacturaManualImporteDescuentoDespuesIva As Double
                Dim fltFacturaManualImporteIvaDescuento As Double
                Dim intFacturaManualFolioContraRecibo As Integer = 0
                Dim blnFacturaManualEstaConfirmada As Byte = CByte(0)
                Dim dtmFacturaManualUltimaModificacion As Date = CDate(Date.Now.ToString("MM/dd/yyyy"))
                Dim strFacturaManualModificadoPor As String = strUsuarioNombre
                Dim intTipoProveedorId As Integer
                Dim strProveedorIdNombre As String = ""
                Dim blnFacturaManualEsRemision As Byte

                strProveedorIdNombre = Trim(Request.Form("txtProveedor"))
                blnFacturaManualEsRemision = CByte(Request("rdoTipoDocumento"))

                ' Obtenemos el tipo de Proveedor
                objDataArray = clstblTipoProveedor.strBuscar(0, "PROVEEDORMAYORISTA", "", CDate("01/01/1900"), "", 0, 0, strCadenaConexion)

                If IsArray(objDataArray) AndAlso objDataArray.Length > 0 Then
                    objRegistro = DirectCast(objDataArray.GetValue(0), String())
                    intTipoProveedorId = CInt(objRegistro(0).ToString)
                End If

                ' Verificamos el número de proveedor
                objDataArray = Nothing 'Se elimino clsConcentrador.clsSucursal.clsMercancia.clsCompras.strBuscarProveedor(intCompaniaId, intSucursalId, intTipoProveedorId, strProveedorIdNombre, 0, 0, strCadenaConexion)

                strHTML = New StringBuilder

                If IsArray(objDataArray) AndAlso objDataArray.Length > 0 Then


                    objRegistro = DirectCast(objDataArray.GetValue(0), String())

                    dtmFacturaManualEmisionDocumento = CDate(clsCommons.strDMYtoMDY(Trim(Request("dtmEmisionFactura"))))
                    dtmFacturaManualRegistro = CDate(clsCommons.strDMYtoMDY(Trim(Request("dtmRecepcionFactura"))))
                    fltFacturaManualImporteNeto = CDbl(Request("txtMontoNetoFactura"))
                    fltFacturaManualImporteIva = CDbl(Request("txtIVAFacturado"))
                    fltFacturaManualImporteTotal = CDbl(Request("txtTotalFacturado"))
                    fltFacturaManualImporteDescuentoDespuesIva = CDbl(Request("txtDescuentoDespuesIVA"))
                    fltFacturaManualImporteIvaDescuento = CDbl(Request("txtIVADescuento"))


                    objDataArray = clsConcentrador.clsSucursal.clsMercancia.clsFacturaManual.strBuscarFacturaRemisionElectronica(intCompaniaId, intSucursalId, intProveedorId, blnFacturaManualEsRemision, strNumero, strCadenaConexion)

                    strHTML = New StringBuilder
                    If IsArray(objDataArray) AndAlso objDataArray.Length > 0 Then
                        ' Se encontró un documento
                        objRegistro = DirectCast(objDataArray.GetValue(0), String())

                        strHTML.Append("<script language='javascript'>parent.fncValidaDocumento(1,0,'" & objRegistro(9).ToString & "','" & objRegistro(10).ToString & "');</script>")
                    Else
                        ' No se encontró ningún documento, se dará de alta
                        intResultado = clstblFacturaManual.intAgregar(0, intProveedorId, intCompaniaId, intSucursalId, strNumero, dtmFacturaManualEmisionDocumento, dtmFacturaManualRegistro, fltFacturaManualImporteNeto, fltFacturaManualImporteIva, fltFacturaManualImporteTotal, fltFacturaManualImporteDescuentoDespuesIva, fltFacturaManualImporteIvaDescuento, intFacturaManualFolioContraRecibo, blnFacturaManualEstaConfirmada, blnFacturaManualEsRemision, dtmFacturaManualUltimaModificacion, strFacturaManualModificadoPor, strCadenaConexion)


                        strHTML.Append("<script language='javascript'>parent.fncValidaDocumento(0," & intResultado.ToString & ",'','');</script>")
                    End If
                Else
                    ' No se encontro el proveedor 
                    strHTML.Append("<script language='javascript'>parent.fncActualizaProveedor(0,'','');</script>")
                End If

                ' Mandamos ejecutar la acción de javascript
                Call Response.Write(strHTML.ToString)
                Call Response.End()

        End Select

    End Sub


End Class
