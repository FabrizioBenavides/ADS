'====================================================================
' Class         : clsSistemaAdministrarUsuarios
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Administrar tiendas
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Javier Ramos
' Version       : 1.0
' Last Modified : Monday, May 24, 2004
'====================================================================
Public Class clsSistemaAdministrarUsuarios
    Inherits System.Web.UI.Page

    ' Variables locales privadas
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private intmGrupoUsuarioSeleccionadoId As Integer
    Private intmCompaniaId As Integer
    Private intmSucursalId As Integer
    Private intmEmpleadoId As Integer
    Private intmEmpleadoSeleccionadoId As Integer
    Private intmUsuarioId As Integer

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

    '====================================================================
    ' Name       : intGrupoUsuarioSeleccionadoID
    ' Description: Obtiene o establece el grupo de usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intGrupoUsuarioSeleccionadoId() As Integer
        Get
            Return intmGrupoUsuarioSeleccionadoId
        End Get
        Set(ByVal intValue As Integer)
            intmGrupoUsuarioSeleccionadoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intCompaniaId
    ' Description: Obtiene o establece la compañia Id
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intCompaniaId() As Integer
        Get
            Return intmCompaniaId
        End Get
        Set(ByVal intValue As Integer)
            intmCompaniaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Obtiene o establece la sucursal Id
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intSucursalId() As Integer
        Get
            Return intmSucursalId
        End Get
        Set(ByVal intValue As Integer)
            intmSucursalId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intEmpleadoId
    ' Description: Obtiene o establece el empleado Id
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intEmpleadoId() As Integer
        Get
            Return intmEmpleadoId
        End Get
        Set(ByVal intValue As Integer)
            intmEmpleadoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intEmpleadoSeleccionadoId
    ' Description: Obtiene o establece el empleado Id
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intEmpleadoSeleccionadoId() As Integer
        Get
            Return intmEmpleadoSeleccionadoId
        End Get
        Set(ByVal intValue As Integer)
            intmEmpleadoSeleccionadoId = intValue
        End Set
    End Property



    '====================================================================
    ' Name       : intUsuarioId
    ' Description: Obtiene o establece el usuario Id
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intUsuarioId() As Integer
        Get
            Return intmUsuarioId
        End Get
        Set(ByVal intValue As Integer)
            intmUsuarioId = intValue
        End Set
    End Property



    '====================================================================
    ' Name       : strLlenarGrupoComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboGrupo"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarGrupoComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboGrupoUsuario", intGrupoUsuarioSeleccionadoId, Benavides.CC.Data.clstblGrupoUsuario.strBuscar(0, "", "", "", 0, 1, Now(), "", 0, 0, strConnectionString), 0, 2, 1)
    End Function

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRecordBrowserHTML() As String
        Get
            ' Declaramos e inicializamos las constantes locales
            Const intElementsPerPage As Integer = 10
            Const strRecordBrowserName As String = "SistemaAdministrarUsuarios"

            ' Declaramos e inicialziamos las variables locales
            Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1", Request))
            Dim astrDataArray As Array = Benavides.CC.Data.clsUsuario.strBuscarEnConcentrador(intGrupoUsuarioSeleccionadoId, intCompaniaId, intSucursalId, intEmpleadoId, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

            ' Obtenemos el HTML
            Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?")

        End Get
    End Property


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "", Request)

        ' Almacenamos el Grupo Seleccionado
        intGrupoUsuarioSeleccionadoId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboGrupoUsuario", "0", Request))

        ' Almacenamos la compañia seleccionada
        intCompaniaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("txtCompaniaId", "0", Request))

        ' Almacenamos la sucursal seleccionada
        intSucursalId = CInt(isocraft.commons.clsWeb.strGetPageParameter("txtSucursalId", "0", Request))

        ' Almacenamos el empleado capturado para la búsqueda
        intEmpleadoId = CInt(isocraft.commons.clsWeb.strGetPageParameter("txtEmpleadoId", "0", Request))

        ' Almacenamos el empleado seleccionado
        intEmpleadoSeleccionadoId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intEmpleadoId", "0", Request))

        ' Almacenamos el usuario seleccionado
        intUsuarioId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intUsuarioId", "0", Request))

        Select Case strCmd
            Case "Agregar"
                Call Response.Redirect("SistemaAgregarUsuario.aspx?strCmd=Agregar")
                Call Response.End()

            Case "Editar"
                Call Response.Redirect("SistemaAgregarUsuario.aspx?strCmd=Editar&intEmpleadoId=" & intEmpleadoSeleccionadoId.ToString & "&intUsuarioId=" & intUsuarioId.ToString)
                Call Response.End()

            Case "Desasignar"

                ' Verificamos que exista información
                If intEmpleadoSeleccionadoId > 0 AndAlso intUsuarioId > 0 Then
                    Call Benavides.CC.Data.clsUsuario.intActualizarEstatus(intEmpleadoSeleccionadoId, intUsuarioId, strUsuarioNombre, strConnectionString)
                End If

        End Select


    End Sub


End Class

