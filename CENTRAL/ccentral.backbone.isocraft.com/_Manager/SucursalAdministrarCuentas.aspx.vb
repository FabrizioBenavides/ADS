'====================================================================
' Class         : clsSucursalAdministrarCuentas
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Administrar tiendas : Ver Tienda
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Javier Ramos
' Version       : 1.0
' Last Modified : Monday, May 24, 2004
'====================================================================

Imports System.Text

Public Class clsSucursalAdministrarCuentas
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

    ' Variables locales privadas
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private intmTipoCuentaId As Integer
    Private intmCuentaId As Integer
    Private intmTipoReferenciaId As Integer

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
    ' Name       : intGrupoUsuarioId
    ' Description: Identificador del Grupo de Usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intGrupoUsuarioId() As Integer
        Get
            Return CInt(Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))
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
    ' Name       : strThisPageName
    ' Description: URL de esta página
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request)
        End Get
    End Property

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Obtiene la cadena de conexión hacia la base de datos
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: Establece los comandos Javascript del evento OnLoad
    ' Accessor   : Read
    ' Throws     : Ninguna
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
    ' Name       : intTipoCuentaId
    ' Description: Identificador de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intTipoCuentaId() As Integer
        Get
            intmTipoCuentaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboTipoCuenta", isocraft.commons.clsWeb.strGetPageParameter("intTipoCuentaId", "0")))
            Return intmTipoCuentaId
        End Get
    End Property

    '====================================================================
    ' Name       : intTipoReferenciaId
    ' Description: Identificador de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intTipoReferenciaId() As Integer
        Get
            intmTipoReferenciaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboTipoReferencia", isocraft.commons.clsWeb.strGetPageParameter("intTipoReferenciaId", "0")))
            Return intmTipoReferenciaId
        End Get
    End Property

    '====================================================================
    ' Name       : strCmd 
    ' Description: Obtiene o establece el comando actual
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strCmd() As String
        Get
            Return strmCommand
        End Get
        Set(ByVal strValue As String)
            strmCommand = strValue
        End Set
    End Property



    '====================================================================
    ' Name       : intCuentaId 
    ' Description: Obtiene o establece el id del tipo de cuenta
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intCuentaId() As Integer
        Get
            Return intmCuentaId
        End Get
        Set(ByVal intValue As Integer)
            intmCuentaId = intValue
        End Set
    End Property


    '====================================================================
    ' Name       : strLlenarTipoCuentaComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboTipoCuenta"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarTipoCuentaComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboTipoCuenta", intTipoCuentaId, Benavides.CC.Data.clstblTipoCuenta.strBuscar(0, "", "", Now(), "", 0, 0, strConnectionString), 0, 2, 1)
    End Function

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String
        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 10
        Const strRecordBrowserName As String = "SucursalAdministrarCuentas"

        ' Declaramos e inicialziamos las variables locales
        Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1"))
        Dim astrDataArray As Array = Benavides.CC.Data.clsCuenta.strBuscarPorTipo(intTipoCuentaId, intTipoReferenciaId, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

        ' Regresamos el resultado
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?intTipoCuentaId=" & intTipoCuentaId.ToString & "&intTipoReferenciaId=" & intTipoReferenciaId.ToString & "&")
    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", isocraft.commons.clsWeb.strGetPageParameter("cmdConsultar", ""), Request)

        ' Almacenamos el comando ejecutado
        intCuentaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intCuentaId", "0", Request))

        Select Case strCmd
            Case "Agregar"
                Call Response.Redirect("SucursalCrearCuenta.aspx?strCmd=Agregar")

            Case "Editar"
                Call Response.Redirect("SucursalCrearCuenta.aspx?strCmd=Editar&intCuentaId=" & intCuentaId.ToString)


        End Select

    End Sub


End Class


