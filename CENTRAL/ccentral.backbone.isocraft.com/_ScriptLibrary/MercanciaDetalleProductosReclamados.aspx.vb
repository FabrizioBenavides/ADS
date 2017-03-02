'====================================================================
' Page          : MercanciaDetalleProductosReclamados.aspx
' Title         : Administracion POS y BackOffice
' Description   : Página de Detalle de productos Reclamados.
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : J.Antonio Hernández Dávila
' Version       : 1.0
' Last Modified : Jueves, Octubre 30, 2003
'====================================================================

Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class MercanciaDetalleProductosReclamados
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
    Private strmRecordBrowserHTML As String

    Private strmErrorProveedor As String = "0"

    Private intmFolioReclamacion As Integer
    Private strmFechaReclamacion As String
    Private strmProveedorReclamacion As String
    Private strmMotivoReclamacion As String

    Private intmReclamacionNumeroDocumento As Integer
    Private strmReclamacionNumeroFactura As String
    Private strmDepartamentoNombre As String

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
    ' Name       : intReclamacionId
    ' Description: Llave Reclamación
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intReclamacionId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intReclamacionId")) Then
                Return CInt(Request.QueryString("intReclamacionId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strConsulta
    ' Description: Comando a ejecutar
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strConsulta() As String
        Get
            If Not IsNothing(Request.QueryString("strConsulta")) Then
                Return (Request.QueryString("strConsulta"))
            Else
                Return ""
            End If
        End Get
    End Property
    '====================================================================
    ' Name       : rdoFiltroConsulta
    ' Description: Valor del radio boton
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property rdoFiltroConsulta() As String
        Get
            If Not IsNothing(Request.QueryString("rdoFiltroConsulta")) Then
                Return Request.QueryString("rdoFiltroConsulta")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strProveedor
    ' Description: Numero de Proveedor
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strProveedor() As String
        Get
            If Not IsNothing(Request.QueryString("intProveedor")) Then
                Return Request.QueryString("intProveedor")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmInicio
    ' Description: Fecha Inicial de la consulta
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmInicio() As String
        Get
            If Not IsNothing(Request.QueryString("dtmInicio")) Then
                Return Request.QueryString("dtmInicio")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFin
    ' Description: Fecha final de la consulta
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFin() As String
        Get
            If Not IsNothing(Request.QueryString("dtmFin")) Then
                Return Request.QueryString("dtmFin")
            Else
                Return ""
            End If
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
    ' Name       : strMensaje
    ' Description: Mensaje para pagina
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
    ' Name       : strRecordBrowserHTML
    ' Description: RecordBrowser de Recibos
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRecordBrowserHTML() As String
        Get
            Return strmRecordBrowserHTML
        End Get
        Set(ByVal Value As String)
            strmRecordBrowserHTML = Value
        End Set

    End Property


    '====================================================================
    ' Name       : strRegistrosRecordBrowser
    ' Description: Registros en el RecordBrowser
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public ReadOnly Property strRegistrosRecordBrowser() As String
        Get
            If strRecordBrowserHTML.Length > 0 Then
                Return strRecordBrowserHTML.Length.ToString
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intFolioReclamacion
    ' Description: Folio de la Reclamación
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public Property intFolioReclamacion() As Integer
        Get
            Return intmFolioReclamacion
        End Get
        Set(ByVal Value As Integer)
            intmFolioReclamacion = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaReclamacion
    ' Description: Fecha de la Reclamación
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public Property strFechaReclamacion() As String
        Get
            Return strmFechaReclamacion
        End Get
        Set(ByVal Value As String)
            strmFechaReclamacion = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strProveedorReclamacion
    ' Description: numero y razon social del proveedor
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public Property strProveedorReclamacion() As String
        Get
            Return strmProveedorReclamacion
        End Get
        Set(ByVal Value As String)
            strmProveedorReclamacion = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strMotivoReclamacion
    ' Description: Numero de la Reclamacion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public Property strMotivoReclamacion() As String
        Get
            Return strmMotivoReclamacion
        End Get
        Set(ByVal Value As String)
            strmMotivoReclamacion = Value
        End Set
    End Property

    '====================================================================
    ' Name       : intReclamacionNumeroDocumento
    ' Description: Valor 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intReclamacionNumeroDocumento() As Integer
        Get
            Return intmReclamacionNumeroDocumento
        End Get
        Set(ByVal strValue As Integer)
            intmReclamacionNumeroDocumento = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strReclamacionNumeroFactura
    ' Description: Valor
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strReclamacionNumeroFactura() As String
        Get
            Return strmReclamacionNumeroFactura
        End Get
        Set(ByVal strValue As String)
            strmReclamacionNumeroFactura = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strDepartamentoNombre
    ' Description: Valor
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strDepartamentoNombre() As String
        Get
            Return strmDepartamentoNombre
        End Get
        Set(ByVal strValue As String)
            strmDepartamentoNombre = strValue
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        ' Control de Acceso de la página

        If intReclamacionId = 0 Then
            Call Response.Redirect("MercanciaArchivoProductosReclamados.aspx")
        End If

        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If


        Dim objArrayReclamacion As Array = Nothing
        Dim strRegistroReclamacion As String() = Nothing

        'Buscamos la Reclamación para datso generales
        objArrayReclamacion = clsConcentrador.clsSucursal.clsMercancia.clsReclamacion.strBuscar(intCompaniaId, intSucursalId, intReclamacionId, 0, 0, CDate("01/01/1900"), CDate("01/01/1900"), 0, 0, strCadenaConexion)

        If IsArray(objArrayReclamacion) AndAlso objArrayReclamacion.Length > 0 Then
            strRegistroReclamacion = DirectCast(objArrayReclamacion.GetValue(0), String())

            intFolioReclamacion = CInt(strRegistroReclamacion(3))

            strFechaReclamacion = clsCommons.strFormatearFechaPresentacion(strRegistroReclamacion(2))

            strProveedorReclamacion = strRegistroReclamacion(1) & " - " & strRegistroReclamacion(4)

            strMotivoReclamacion = strRegistroReclamacion(5)

            intReclamacionNumeroDocumento = CInt(strRegistroReclamacion(6))
            strReclamacionNumeroFactura = strRegistroReclamacion(7)
            strDepartamentoNombre = strRegistroReclamacion(8)

            Dim objArrayDetalleReclamaciones As Array = Nothing

            ' Buscamos el detalle de la reclamación
            objArrayDetalleReclamaciones = clsConcentrador.clsSucursal.clsMercancia.clsReclamacion.strBuscarDetalle(intCompaniaId, intSucursalId, intReclamacionId, 0, 0, strCadenaConexion)

            If IsArray(objArrayDetalleReclamaciones) AndAlso objArrayDetalleReclamaciones.Length > 0 Then
                ' Generamos el Navegador de Registros                
                strRecordBrowserHTML = clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaDetalleProductosReclamados", objArrayDetalleReclamaciones, 1, objArrayDetalleReclamaciones.Length, ""))

            End If

        End If

    End Sub

End Class
