'====================================================================
' Class         : clsTest
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Administrar tiendas
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Javier Ramos
' Version       : 1.0
' Last Modified : Monday, May 24, 2004
'====================================================================

Imports System.Text
Imports System.Collections

Public Class clsTest
    Inherits System.Web.UI.Page
    'Implements InvRot.Utils.PrintInterface

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
    Private _intListadoId As Integer
    'Private _strNombre As String
    Private _intOrdenamiento As Integer
    Private _txtListadoNombre As String


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

    ''====================================================================
    '' Name       : txtListadoNombre
    '' Description: Nombre del listado
    '' Accessor   : Read
    '' Throws     : Ninguna
    '' Output     : String
    ''====================================================================
    'Public ReadOnly Property txtListadoNombre() As String
    '    Get
    '        Return CStr(com.isocraft.commons.clsWeb.strGetPageParameter("txtListadoNombre", ""))
    '    End Get
    'End Property

    '====================================================================
    ' Name       : txtOrdenamiento
    ' Description: Nombre del listado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property txtOrdenamiento() As String
        Get
            Return ""
        End Get
    End Property

    '====================================================================
    ' Name       : intListadoId 
    ' Description: Obtiene o establece el listado id
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intListadoId() As Integer
        Get
            Return _intListadoId
        End Get
        Set(ByVal strValue As Integer)
            _intListadoId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : _txtListadoNombre
    ' Description: Obtiene o establece el nombre del listado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property txtListadoNombre() As String
        Get
            Return _txtListadoNombre
        End Get
        Set(ByVal strValue As String)
            _txtListadoNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intOrdenamiento
    ' Description: Obtiene o establece el ordenamiento del listado seleccionado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intOrdenamiento() As Integer
        Get
            Return _intOrdenamiento
        End Get
        Set(ByVal strValue As Integer)
            _intOrdenamiento = strValue
        End Set
    End Property


    Public Function rbOrdenamientoChecked(ByVal sel As Integer) As String
      
        Return ""

    End Function


    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String
        Return ""

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        'If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
        '    Call Response.Redirect("../Default.aspx")
        'End If

        ' Almacenamos el comando ejecutado
        'strCmd = com.isocraft.commons.clsWeb.strGetPageParameter("strCmd", com.isocraft.commons.clsWeb.strGetPageParameter("cmdConsultar", ""), Request)

        ' Almacenamos el id del listado seleccionado
        'intListadoId = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intListadoId", "0", Request))

        'Consultamos los listados
        '  Dim astrRecords As Array = InvRot.Data.clstblListado.strBuscar(0, 10, strConnectionString)





    End Sub


End Class

