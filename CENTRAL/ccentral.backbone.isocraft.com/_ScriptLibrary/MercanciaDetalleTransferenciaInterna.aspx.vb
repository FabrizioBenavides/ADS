'====================================================================
' Page          : MercanciaDetalleTransferenciaInterna.aspx
' Title         : Administracion POS y BackOffice
' Description   : Página para 
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : J.Antonio Hernández Dávila
' Version       : 1.0
' Last Modified : Sabado, Noviembre 01, 2003
'====================================================================

Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class MercanciaDetalleTransferenciaInterna
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

    Private intmFolioTrasferenciaInterna As Integer
    Private strmTipoTrasferenciaInterna As String
    Private dtmmFechaTrasferenciaInterna As String
    Private strmDepartamentoSurtidor As String
    Private strmDepartamentoReceptor As String
    Private strmCuentadeGasto As String

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
    ' Name       : intTrasferenciaInternaId
    ' Description: Llave Reclamación
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intTrasferenciaInternaId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intTrasferenciaInternaId")) Then
                Return CInt(Request.QueryString("intTrasferenciaInternaId"))
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
    ' Name       : intFolioTrasferenciaInterna
    ' Description: Folio de la trasferencia Interna
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intFolioTrasferenciaInterna() As Integer
        Get
            Return intmFolioTrasferenciaInterna
        End Get
        Set(ByVal Value As Integer)
            intmFolioTrasferenciaInterna = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoTrasferenciaInterna
    ' Description: Tipo de Trasferencia Interna
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public Property strTipoTrasferenciaInterna() As String
        Get
            Return strmTipoTrasferenciaInterna
        End Get
        Set(ByVal Value As String)
            strmTipoTrasferenciaInterna = Value
        End Set
    End Property

    '====================================================================
    ' Name       : dtmFechaTrasferenciaInterna
    ' Description: Fecha Trasferencia Interna
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public Property dtmFechaTrasferenciaInterna() As String
        Get
            Return dtmmFechaTrasferenciaInterna
        End Get
        Set(ByVal Value As String)
            dtmmFechaTrasferenciaInterna = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strDepartamentoSurtidor
    ' Description: Departamento Origen de la Trasferencia Interna
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public Property strDepartamentoSurtidor() As String
        Get
            Return strmDepartamentoSurtidor
        End Get
        Set(ByVal Value As String)
            strmDepartamentoSurtidor = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strDepartamentoReceptor
    ' Description: Departamento Destino de la Trasferencia Interna
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public Property strDepartamentoReceptor() As String
        Get
            Return strmDepartamentoReceptor
        End Get
        Set(ByVal Value As String)
            strmDepartamentoReceptor = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strCuentadeGasto
    ' Description: Cuenta de Gasto de la Trasferencia Interna
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public Property strCuentadeGasto() As String
        Get
            Return strmCuentadeGasto
        End Get
        Set(ByVal Value As String)
            strmCuentadeGasto = Value
        End Set
    End Property


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        If intTrasferenciaInternaId = 0 Then
            Call Response.Redirect("MercanciaConsultarArchivoTransferenciaInterna.aspx")
        End If

        Dim objArrayTrasferenciaInterna As Array = Nothing
        Dim strRegistroTrasferenciaInterna As String() = Nothing

        'Buscamos la Trasferencia para sacar los Datos Generales
        objArrayTrasferenciaInterna = clsConcentrador.clsSucursal.clsTransferencia.strBuscar(intCompaniaId, intSucursalId, intTrasferenciaInternaId, CDate("01/01/1900"), CDate("01/01/1900"), 0, 0, strCadenaConexion)

        If IsArray(objArrayTrasferenciaInterna) AndAlso objArrayTrasferenciaInterna.Length > 0 Then

            strRegistroTrasferenciaInterna = DirectCast(objArrayTrasferenciaInterna.GetValue(0), String())

            intFolioTrasferenciaInterna = CInt(strRegistroTrasferenciaInterna(1))
            strDepartamentoSurtidor = strRegistroTrasferenciaInterna(3)
            strDepartamentoReceptor = strRegistroTrasferenciaInterna(5)
            strTipoTrasferenciaInterna = strRegistroTrasferenciaInterna(9)
            strCuentadeGasto = strRegistroTrasferenciaInterna(8)
            dtmFechaTrasferenciaInterna = clsCommons.strFormatearFechaPresentacion(strRegistroTrasferenciaInterna(10))


            Dim objArrayDetalleTrasferenciaInterna As Array = Nothing

            'Buscamos el Detalle de la Trasferencia
            objArrayDetalleTrasferenciaInterna = clsConcentrador.clsSucursal.clsTransferencia.strBuscarDetalle(intTrasferenciaInternaId, 0, 0, strCadenaConexion)

            If IsArray(objArrayDetalleTrasferenciaInterna) AndAlso objArrayDetalleTrasferenciaInterna.Length > 0 Then
                ' Generamos el Navegador de Registros                
                strRecordBrowserHTML = clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaDetalleTrasferenciaInterna", objArrayDetalleTrasferenciaInterna, 1, objArrayDetalleTrasferenciaInterna.Length, ""))

            End If

        End If


    End Sub

End Class
