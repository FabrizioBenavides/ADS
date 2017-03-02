Imports System.Configuration
Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business

Public Class FotoLabEmpleadosAdministrar
    Inherits System.Web.UI.Page

    Private intmEmpleadoId As Integer = 0
    Private strmCmd As String = ""


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
    ' Accessor   : Read
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
    ' Name       : strRecordBrowserHTML
    ' Description: Valor que tomara la variable strmRecordBrowserHTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRecordBrowserHTML() As String
        Get
            ' Declaración e inicialización de las variables locales
            Dim strTargetURL As String = Request.ServerVariables("SCRIPT_NAME") & "?"
            Dim blnConsultaAdministrativa As Boolean = False
            Dim objGrupoUsuario As Array = Nothing
            Dim strGrupoUsuarioRegistro As String() = Nothing
            Dim objDataArray As Array = Nothing

            ' Traemos informacion del rol que tiene el empleado firmado actualmente
            objGrupoUsuario = clstblGrupoUsuario.strBuscar(intGrupoUsuarioId, "", "", "", 0, 0, Date.Now, "", 0, 0, strCadenaConexion)

            If IsArray(objGrupoUsuario) Then

                If objGrupoUsuario.Length > 0 Then

                    strGrupoUsuarioRegistro = DirectCast(objGrupoUsuario.GetValue(0), String())

                    ' Validamos si el usuario firmado es un Administrador
                    blnConsultaAdministrativa = LTrim(RTrim(strGrupoUsuarioRegistro(1))).ToUpper.Equals("ADMINISTRADOR")

                End If

            End If

            objDataArray = clsEmpleado.strBuscar(intCompaniaId, intSucursalId, intEmpleadoId, blnConsultaAdministrativa, strCadenaConexion)

            If IsArray(objDataArray) Then
                If objDataArray.Length > 0 Then

                    ' Generamos el Navegador de Registros
                    Return clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("SucursalEmpleadosAdministrar", objDataArray, 1, objDataArray.Length, strTargetURL))

                End If
            End If


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
    ' Name       : intEmpleadoId
    ' Description: Valor del Numero de Empleado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intEmpleadoId() As Integer
        Get
            Return intmEmpleadoId

        End Get
        Set(ByVal Value As Integer)
            intmEmpleadoId = Value

        End Set
    End Property



    '====================================================================
    ' Name       : strCmd
    ' Description: Valor del parámetro strCmd
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strCmd() As String
        Get
            Return strmCmd
        End Get
        Set(ByVal Value As String)
            strmCmd = Value
        End Set
    End Property



    '====================================================================
    ' Name       : intMensajeError
    ' Description: Valor que controla el mensaje de error
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intMensajeError() As Integer
        Get
            Return CInt(Request.QueryString("intMensajeError"))
        End Get
        Set(ByVal intValue As Integer)
            intMensajeError = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEstadoOperativo
    ' Description: Muestra el estado operativo del empleado actualmente
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEstadoOperativo() As String
        Get
            Return Request.QueryString("strEstadoOperativo")
        End Get
        Set(ByVal strValue As String)
            strEstadoOperativo = strValue
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        intEmpleadoId = CInt(Request.QueryString("intEmpleadoId"))

        strCmd = Request.QueryString("strCmd")


        Select Case strCmd

            Case "Ver"
                Call Response.Redirect("FotoLabEmpleadosVerFicha.aspx?strCmd=" & strCmd & "&intEmpleadoId=" & intEmpleadoId)

            Case "Editar"
                Call Response.Redirect("FotoLabEmpleadosAsignarRoles.aspx?strCmd=" & strCmd & "&intEmpleadoId=" & intEmpleadoId)

            Case "Desasignar"
                Dim objArrayEmpleado As Array = Nothing
                Dim strRegistroEmpleado As String() = Nothing

                Dim intResultado As Integer = 0
                Dim strEstadoOperativo As String

                Dim objtblMembresia As Array = Nothing
                Dim strtblMembresia As String() = Nothing

                Dim intUsuarioEmpleadoId As Integer = 0
                Dim intGrupoUsuarioEmpleadoId As Integer = 0

                ' Buscamos los Datos del empleado
                objArrayEmpleado = clsEmpleado.strBuscar(intCompaniaId, intSucursalId, intEmpleadoId, False, strCadenaConexion)

                ' Nos aseguramos que hayamos obtenido algún resultado
                If IsArray(objArrayEmpleado) AndAlso objArrayEmpleado.Length > 0 Then

                    strRegistroEmpleado = DirectCast(objArrayEmpleado.GetValue(0), String())


                    ' Obtenemos el Usuario del Empleado
                    If Len(strRegistroEmpleado(6)) > 0 Then
                        intUsuarioEmpleadoId = CInt(strRegistroEmpleado(6))
                    Else
                        intUsuarioEmpleadoId = 0
                    End If

                    ' Obtenemos el grupo de usuarios de asignacion de rol
                    If Len(strRegistroEmpleado(10)) > 0 Then
                        intGrupoUsuarioEmpleadoId = CInt(strRegistroEmpleado(10))
                    Else
                        intGrupoUsuarioEmpleadoId = 0
                    End If

                End If

                ' Mandamos eliminar la membresia del usuario
                intResultado = clstblMembresiaUsuario.intEliminar(intEmpleadoId, intUsuarioEmpleadoId, intGrupoUsuarioEmpleadoId, Date.Now, strUsuarioNombre, strCadenaConexion)

                intEmpleadoId = 0
                strCmd = ""


        End Select

    End Sub

End Class
