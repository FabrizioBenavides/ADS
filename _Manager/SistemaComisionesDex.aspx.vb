Imports Isocraft.Web.Http

'====================================================================
' Class         : clsSistemaComisionesDex
' Title         : SistemaComisionesDex
' Description   : Consulta y actualiza las comisiones relacionadas 
'                 con las operaciones dex
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Sergio Leal Garza (sergio@isocraft.com)
' Last Modified : Thursday, May 19, 2005
'====================================================================

Public Class clsSistemaComisionesDex
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

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Initialize class properties
        strtxtComisionesDex = GetPageParameter("txtComisionesDex", "")
        strtxtCuotaComision = GetPageParameter("txtCuotaFijaComisionDEX", "")
        strtxtCuotaAdministracion = GetPageParameter("txtCuotaFijaAdministracionEmpleadosDEX", "")
    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private strmtxtComisionesDex As String
    Private strmtxtCuotaComision As String
    Private strmtxtCuotaAdministracion As String

#End Region

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : None
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
    ' Throws     : None
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
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
        End Get
    End Property

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
    ' Name       : strCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return GetPageParameter("strCmd", "")
        End Get
    End Property

    '====================================================================
    ' Name       : strtxtComisionesDex
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtComisionesDex() As String
        Get
            Return strmtxtComisionesDex
        End Get
        Set(ByVal strValue As String)
            strmtxtComisionesDex = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strtxtCuotaComision
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtCuotaComision() As String
        Get
            Return strmtxtCuotaComision
        End Get
        Set(ByVal strValue As String)
            strmtxtCuotaComision = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : strtxtCuotaAdministracion  
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtCuotaAdministracion() As String
        Get
            Return strmtxtCuotaAdministracion
        End Get
        Set(ByVal strValue As String)
            strmtxtCuotaAdministracion = strValue
        End Set
    End Property


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Execute the selected command
        Select Case strCmd

            Case "Salvar"
                Dim aobjData As System.Array = Benavides.CC.Data.clstblSucursal.strBuscar(0, 0, 0, 0, "", 0, 0, 0, #1/1/2000#, "", "", "", "", 0, 0, strConnectionString)
                Dim intCompaniaId As Integer
                Dim intSucursalId As Integer
                For Each objRow As Array In aobjData
                    intCompaniaId = CInt(objRow.GetValue(0))
                    intSucursalId = CInt(objRow.GetValue(1))
                    Call Benavides.CC.Data.clsConfiguracionSucursal.aobjAgregarConfiguracionSucursal(intCompaniaId, intSucursalId, "fltComisionDEX", strtxtComisionesDex, strUsuarioNombre, strConnectionString)
                    Call Benavides.CC.Data.clsConfiguracionSucursal.aobjAgregarConfiguracionSucursal(intCompaniaId, intSucursalId, "fltCuotaFijaComisionDEX", strtxtCuotaComision, strUsuarioNombre, strConnectionString)
                    Call Benavides.CC.Data.clsConfiguracionSucursal.aobjAgregarConfiguracionSucursal(intCompaniaId, intSucursalId, "fltCuotaFijaAdministracionEmpleadosDEX", strtxtCuotaAdministracion, strUsuarioNombre, strConnectionString)
                Next

        End Select

    End Sub

End Class
