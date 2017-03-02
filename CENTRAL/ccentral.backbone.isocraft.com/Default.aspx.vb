'==================================================================== 
' Class         : clsLogin
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Acceso al Sistema
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Dirección de Tecnología
' Version       : 1.0
' Last Modified : Tuesday, July 4, 2006
'====================================================================
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration
Imports System.Web
Imports Isocraft.Web.Http
Imports Isocraft.Security

Public Class clsLogin
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

    End Sub

#End Region

    ' Declaración de atributos privados
    Private intmMensajeError As Integer

    '====================================================================
    ' Name       : strRedirectPage
    ' Description: Página hacia la cual se debe redireccionar al usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRedirectPage() As String

        Get

            If Len(strURL) > 0 Then

                ' URL enviado como parámetro
                Return strURL

            Else

                ' URL por defecto
                Return "/_ScriptLibrary/SucursalConfiguracionDescripcion.aspx"

            End If

        End Get

    End Property

    '====================================================================
    ' Name       : strFormAction
    ' Description: Valor de la acción de la forma HTML
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormAction() As String

        Get

            Dim strmFormAction As String = Request.ServerVariables("SCRIPT_NAME")

            If Len(strURL) > 0 Then

                strmFormAction += "?strURL=" & strURL

            End If

            Return strmFormAction

        End Get

    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Valor del parámetro strCmd
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String

        Get

            Return Request.QueryString("strCmd")

        End Get

    End Property

    '====================================================================
    ' Name       : strURL
    ' Description: Valor del parámetro strURL
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strURL() As String

        Get

            Return Request.QueryString("strURL")

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

            Return Request.Form("txtUsuarioNombre")

        End Get

    End Property

    '====================================================================
    ' Name       : strUsuarioContrasena
    ' Description: Contraseña del Usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioContrasena() As String

        Get

            Return Request.Form("txtUsuarioContrasena")

        End Get

    End Property

    '====================================================================
    ' Name       : strMensajeError
    ' Description: Mensaje de error recibido
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intMensajeError() As Integer

        Get

            Return intmMensajeError

        End Get

        Set(ByVal strValue As Integer)

            intmMensajeError = strValue

        End Set

    End Property

    '====================================================================
    ' Name       : strCadenaConexion
    ' Description: Valor de la Cadena de Conexion
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
    Private Sub Page_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Load

        ' Declaración e inicialización de las variables locales
        Dim intResultado As Integer = 0
        Dim strURLSucursal As String
        Dim strGrupoUsuarioNombreId As String = ""
        Dim blnContrasenaEncriptada As Boolean = GetPageParameter("txtContrasenaEncriptada", False)
        Dim strContrasena As String = strUsuarioContrasena

        ' Controlador de comandos
        Select Case strCmd

            Case "Salir"

                ' Salir del Sistema
                Call clsConcentrador.clsControlAcceso.EliminarSesionCuentaUsuario(Response, Server)

            Case Else

                ' Acceso al Sistema
                ' Si el usuario y la contraseña contienen valores

                If Len(strUsuarioNombre) > 0 AndAlso Len(strContrasena) > 0 Then

                    If Len(strURL) = 0 Then
                        'Es usuario central hay que encriptar lo que se captura

                        strContrasena = (New Hash.DataProtector).HashString(strContrasena, Hash.DataProtector.CryptoServiceProvider.SHA1)

                    End If

                    ' Ejecutamos la validación de la cuenta del usuario
                    intResultado = clsConcentrador.clsControlAcceso.intValidarCuentaUsuario(strUsuarioNombre, strContrasena, Response, Server, strCadenaConexion)

                    ' Si la cuenta de usuario es válida
                    If intResultado = 1 Then

                        ' Declaramos e inicializamos los atributos de la cuenta
                        Dim intCompaniaId As Integer = 0
                        Dim intSucursalId As Integer = 0
                        Dim strCentroLogisticoId As String = ""

                        Dim objDataArray As Array = Nothing
                        Dim objRegistro As String() = Nothing
                        Dim objDataArrayGrupoUsuario As Array = Nothing
                        Dim objRegistroGrupoUsuario As String() = Nothing
                        Dim intGrupoUsuarioId As Integer = 0

                        ' Obtenemos el identificador de la compañía, si no viene en blanco
                        If Len(clsCommons.strReadCookie("intCompaniaId", "0", Request, Server)) > 0 Then

                            intCompaniaId = CInt(clsCommons.strReadCookie("intCompaniaId", "0", Request, Server))

                        End If

                        ' Obtenemos el identificador de la sucursal, si no viene en blanco
                        If Len(clsCommons.strReadCookie("intSucursalId", "0", Request, Server)) > 0 Then

                            intSucursalId = CInt(clsCommons.strReadCookie("intSucursalId", "0", Request, Server))

                        End If

                        ' Obtenemos el centro logistico de la sucursal
                        If Len(clsCommons.strReadCookie("strCentroLogisticoId", "", Request, Server)) > 0 Then

                            strCentroLogisticoId = CStr(clsCommons.strReadCookie("strCentroLogisticoId", "", Request, Server))

                        End If

                        ' Obtenemos el identificador del grupo de usuario, si no viene en blanco
                        If Len(clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server)) > 0 Then

                            intGrupoUsuarioId = CInt(clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))

                        Else

                            ' El identificador del grupo de usuario no existe, buscamos con el usuario y contraseña sus datos
                            objDataArrayGrupoUsuario = clsConcentrador.clsControlAcceso.strBuscarGrupoUsuario(strUsuarioNombre, strContrasena, strCadenaConexion)

                            ' Obtenemos los datos de la cuenta, si el usuario existe
                            If IsArray(objDataArrayGrupoUsuario) AndAlso objDataArrayGrupoUsuario.Length > 0 Then

                                objRegistroGrupoUsuario = DirectCast(objDataArrayGrupoUsuario.GetValue(0), String())

                                intCompaniaId = CInt(objRegistroGrupoUsuario(2).ToString)
                                intSucursalId = CInt(objRegistroGrupoUsuario(3).ToString)

                                intGrupoUsuarioId = CInt(objRegistroGrupoUsuario(4).ToString)
                                strCentroLogisticoId = CStr(objRegistroGrupoUsuario(6).ToString)

                            End If

                        End If

                        ' Buscamos la información del grupo de usuario
                        objDataArray = clstblGrupoUsuario.strBuscar(intGrupoUsuarioId, "", "", "", 0, 0, CDate("01/01/1900"), "", 0, 0, strCadenaConexion)

                        ' Si el grupo de usuario existe
                        If IsArray(objDataArray) AndAlso objDataArray.Length > 0 Then

                            ' Obtenemos su información
                            objRegistro = DirectCast(objDataArray.GetValue(0), String())

                            ' Redireccionamos al usuario a la página inicial de Fotolab, si el grupo de usuario es Fotolab
                            strGrupoUsuarioNombreId = Trim(objRegistro(1).ToString.ToUpper)

                            If strGrupoUsuarioNombreId.Equals("FOTOLAB") = True Then

                                Call Response.Redirect("/_ScriptLibrary/FotoLab.aspx")

                            End If

                            ' Redireccionamos al usuario a la página inicial de Mercancias Centrales, si el grupo de usuario es MErcanciasCentrales
                            strGrupoUsuarioNombreId = Trim(objRegistro(1).ToString.ToUpper)

                            If strGrupoUsuarioNombreId.Equals("MERCANCIACONSIGNACION") = True Then

                                Call Response.Redirect("/_ScriptLibrary/MercanciaUsuarioCentral.aspx")

                            End If

                        End If

                        ' Si esta página se ha mandado a ejecutar desde el IFRAME "ifrInicio" de la página principal del Servido de la Sucursal
                        If Len(Request.QueryString("strUseRedirector")) > 0 Then

                            ' Identificamos la opción ejecutada y reconstruimos el URL final
                            Select Case strRedirectPage.ToLower()

                                Case "/_scriptlibrary/mercanciaconsultarplanogramatexto.aspx"

                                    strURLSucursal = strRedirectPage & "?intPlanoId=" & Request.QueryString("intPlanoId")

                                Case "/_scriptlibrary/mercanciafacturasporconfirmar.aspx", _
                                      "/_scriptlibrary/mercanciafacturasporconfirmarpd.aspx"

                                    strURLSucursal = strRedirectPage & "?strCmd=" & Request.QueryString("strCmd") & "&intProveedorId=" & Request.QueryString("intProveedorId")

                                Case "/_scriptlibrary/mercanciaconfirmarenvioproductos.aspx"

                                    strURLSucursal = strRedirectPage & "?intTransferenciaId=" & Request.QueryString("intTransferenciaId") & "&intCompaniaEnvioId=" & Request.QueryString("intCompaniaEnvioId") & "&intSucursalEnvioId=" & Request.QueryString("intSucursalEnvioId")

                                Case "/_scriptlibrary/mercanciaconfirmarrecibodeproductos.aspx"

                                    strURLSucursal = strRedirectPage & "?intTransferenciaId=" & Request.QueryString("intTransferenciaId")

                                Case "/_scriptlibrary/mercanciaremisionporconfirmar.aspx"

                                    strURLSucursal = strRedirectPage & "?strCmd=" & Request.QueryString("strCmd") & "&intProveedorId=" & Request.QueryString("intProveedorId")

                            End Select

                            ' Redireccionamos al usuario hacia la página ejecutada
                            Call Response.Redirect(strURLSucursal)

                        End If

                        ' Verificamos si esta página es ejecutada desde el Redirector del Servidor de la Sucursal
                        If Len(strURL) = 0 Then

                            ' Si un usuario administrador accede directamente a la página de login del Concentrador
                            If strGrupoUsuarioNombreId.Equals("ADMINISTRADOR") = True Then

                                ' Lo enviamos hacia la página inicial del administrador del concentrador

                                ' ORIGINAL LINE
                                Call Response.Redirect("/_Manager/InicioHome.aspx")

                                ' by Ollerbytes... to test in localhost
                                'Call Response.Redirect("~/_Manager/InicioHome.aspx")

                            Else

                                ' Establecemos el URL de la sucursal que corresponde a este usuario
                                strURLSucursal = clsConcentrador.strObtenerURLSucursal(intCompaniaId, intSucursalId, strCadenaConexion)

                            End If

                        End If

                        ' Redireccionamos al usuario hacia su página inicial o específica
                        Call Response.Redirect(strURLSucursal & strRedirectPage)

                    Else

                        ' Usuario inválido
                        intMensajeError = intResultado

                    End If

                End If

        End Select

    End Sub

End Class
