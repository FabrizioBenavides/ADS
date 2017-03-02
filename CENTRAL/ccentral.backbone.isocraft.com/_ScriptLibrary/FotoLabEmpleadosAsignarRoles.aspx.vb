Imports System.Configuration
Imports Benavides.CC.Data
Imports Benavides.CC.Business
Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Isocraft.Web.Http
Imports Isocraft.Security

Public Class FotoLabEmpleadosAsignarRoles
    Inherits System.Web.UI.Page

    'Definición de Variables 
    Private Const DIAS_EXPIRACION As Integer = 1

    Private dtmUsuarioUltimoAcceso As Date = Date.Now


    Private intmEmpleadoId As Integer
    Private intmUsuarioId As Integer

    Private strmUsuarioNombreEmpleado As String
    Private strmUsuarioContrasenaEmpleado As String
    Private blnmUsuarioHabilitado As Byte
    Private dtmmUsuarioAsignacion As Date
    Private dtmmUsuarioExpiracion As Date
    Private blnmUsuarioBloqueado As Byte

    Private intmPuestoEmpleadoId As Integer


    Private strmEmpleadoNombre As String
    Private strmEmpleadoApellidoPaterno As String
    Private strmEmpleadoApellidoMaterno As String
    Private intmGrupoUsuarioIdEmpleado As Integer

    Private strmWindowOnLoadEvent As String = ""


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

        ' Control de Acceso de la página

        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then

            Call Response.Redirect(strRedirectPage)

        End If

        ' Lectura de los campos de la forma
        intUsuarioId = GetPageParameter("intUsuarioId", 0)
        intEmpleadoId = GetPageParameter("intEmpleadoId", GetPageParameter("txtEmpleadoId", 0))
        strUsuarioNombreEmpleado = GetPageParameter("txtUsuarioNombre", "")
        strUsuarioContrasenaEmpleado = Trim(GetPageParameter("txtUsuarioContrasena", ""))

        blnUsuarioHabilitado = CByte(GetPageParameter("optHabilitado", GetPageParameter("blnUsuarioHabilitado", CByte(0))))

        dtmUsuarioAsignacion = Now()
        blnUsuarioBloqueado = CByte(GetPageParameter("optCuentaBloqueada", GetPageParameter("blnUsuarioBloqueado", CByte(0))))


        dtmUsuarioExpiracion = dtmUsuarioAsignacion.AddDays(DIAS_EXPIRACION)

        intmGrupoUsuarioIdEmpleado = GetPageParameter("cboGrupoUsuario", 0)


    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        ' Leemos los campos de la forma
        blnmUsuarioBloqueado = GetPageParameter("optCuentaBloqueada", CByte(0))

    End Sub

#End Region

    '====================================================================
    ' Name       : strRedirectParentPage
    ' Description: Página padre hacia la cual se debe redireccionar al
    '              usuario en caso de querer acceder directamente a esta
    '              página
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRedirectParentPage() As String

        Get

            Return "FotoLabEmpleadosAdministrar.aspx"

        End Get

    End Property

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

            Return Request.ServerVariables("SCRIPT_NAME") & "?intEmpleadoId=" & intEmpleadoId

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
    ' Name       : strChangePassword
    ' Description: Valor del parámetro strChangePassword
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strChangePassword() As String

        Get

            Dim strValue As String = Request.QueryString("strChangePassword")

            If StrComp(strValue, "True") = 0 Then

                strValue = "true"

            Else

                strValue = "false"

            End If

            Return strValue

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
    ' Name       : strEmpleadoNombre
    ' Description: Nombre del Empleado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEmpleadoNombre() As String

        Get

            Return strmEmpleadoNombre

        End Get

        Set(ByVal strValue As String)

            strmEmpleadoNombre = strValue

        End Set

    End Property

    '====================================================================
    ' Name       : strEmpleadoApellidoPaterno
    ' Description: Apellido Paterno del Empleado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEmpleadoApellidoPaterno() As String

        Get

            Return strmEmpleadoApellidoPaterno

        End Get

        Set(ByVal strValue As String)

            strmEmpleadoApellidoPaterno = strValue

        End Set

    End Property

    '====================================================================
    ' Name       : strEmpleadoApellidoMaterno
    ' Description: Apellido Materno del Empleado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEmpleadoApellidoMaterno() As String

        Get

            Return strmEmpleadoApellidoMaterno

        End Get

        Set(ByVal strValue As String)

            strmEmpleadoApellidoMaterno = strValue

        End Set

    End Property


    '====================================================================
    ' Name       : intEmpleadoId
    ' Description: Valor del Numero de Empleado
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
    ' Name       : intUsuarioId
    ' Description: Obtenemos el valor del número de Usuario
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
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
    ' Name       : strUsuarioNombreEmpleado
    ' Description: Nombre del Usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strUsuarioNombreEmpleado() As String

        Get

            Return strmUsuarioNombreEmpleado

        End Get

        Set(ByVal strValue As String)

            strmUsuarioNombreEmpleado = strValue

        End Set

    End Property

    '====================================================================
    ' Name       : strUsuarioContrasenaEmpleado
    ' Description: Almacena la contraseña del Usuario que sera modificado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strUsuarioContrasenaEmpleado() As String

        Get

            Return strmUsuarioContrasenaEmpleado

        End Get

        Set(ByVal strValue As String)

            If Len(strValue) > 0 Then

                strmUsuarioContrasenaEmpleado = strValue

            End If

        End Set

    End Property

    '====================================================================
    ' Name       : blnUsuarioHabilitado
    ' Description: 
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : byte
    '====================================================================
    Public Property blnUsuarioHabilitado() As Byte
        Get
            Return blnmUsuarioHabilitado
        End Get
        Set(ByVal Value As Byte)
            blnmUsuarioHabilitado = Value
        End Set
    End Property


    '====================================================================
    ' Name       : dtmUsuarioAsignacion
    ' Description: Muestra la Fecha que Expira la cuenta de Usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property dtmUsuarioAsignacion() As Date

        Get

            Return dtmmUsuarioAsignacion

        End Get

        Set(ByVal dtmValue As Date)

            dtmmUsuarioAsignacion = dtmValue

        End Set

    End Property

    '====================================================================
    ' Name       : dtmUsuarioExpiracion
    ' Description: Muestra la Fecha que Expira la cuenta de Usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property dtmUsuarioExpiracion() As Date

        Get

            Return dtmmUsuarioExpiracion

        End Get

        Set(ByVal dtmValue As Date)

            dtmmUsuarioExpiracion = dtmValue

        End Set

    End Property

    '====================================================================
    ' Name       : blnUsuarioBloqueado
    ' Description: Muestra la Fecha que Expira la cuenta de Usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : byte
    '====================================================================
    Public Property blnUsuarioBloqueado() As Byte
        Get
            Return blnmUsuarioBloqueado
        End Get
        Set(ByVal Value As Byte)
            blnmUsuarioBloqueado = Value
        End Set
    End Property


    '====================================================================
    ' Name       : intPuestoEmpleadoId
    ' Description: Puesto del Empleado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intPuestoEmpleadoId() As Integer

        Get

            Return intmPuestoEmpleadoId

        End Get

        Set(ByVal intValue As Integer)

            intmPuestoEmpleadoId = intValue

        End Set

    End Property


    '====================================================================
    ' Name       : intGrupoUsuarioEmpleadoId
    ' Description: Obtenemos el valor del numero del grupo de empleado
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intGrupoUsuarioEmpleadoId() As Integer

        Get

            Return intmGrupoUsuarioIdEmpleado

        End Get

        Set(ByVal intValue As Integer)

            intmGrupoUsuarioIdEmpleado = intValue

        End Set

    End Property


    '====================================================================
    ' Name       : intGrupoFotoLabId
    ' Description: 
    ' Parameters :
    '              
    '              
    ' Throws     : Ninguna
    ' Output     : Ninguna
    '====================================================================
    Public Function intGrupoFotoLabId() As Integer

        Dim objArrayGrupoUsuario As Array = Nothing
        Dim strRegistroGrupoUsuario As String() = Nothing
        Dim strcborol As String = ""
        Dim intContador As Integer = 0
        Dim intGrupoUsuarioId As Integer = 0

        ' Buscamos el Id del Rol FotoLab
        objArrayGrupoUsuario = clstblGrupoUsuario.strBuscar(0, "FOTOLAB", "", "", 0, 0, CDate("1/1/1900"), "", 0, 0, strCadenaConexion)

        ' Verificamos que contenga informacion
        If IsArray(objArrayGrupoUsuario) AndAlso objArrayGrupoUsuario.Length > 0 Then

            strRegistroGrupoUsuario = DirectCast(objArrayGrupoUsuario.GetValue(0), String())
            intGrupoUsuarioId = CInt(strRegistroGrupoUsuario(0))

        End If

        intGrupoFotoLabId = intGrupoUsuarioId

    End Function

    Public ReadOnly Property strWindowOnLoadEvent() As String

        Get

            Return strmWindowOnLoadEvent

        End Get

    End Property

    Private Sub Page_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Load



        ' Nos aseguramos que tengamos algún número de Empleado
        If Not intEmpleadoId > 0 Then

            Call Response.Redirect(strRedirectParentPage)

        End If

        ' Declaración e inicialización de las variables locales
        Dim objrSucursalEmpleadosAsignarRoles As Array = Nothing
        Dim strSucursalEmpleadosAsignarRoles As String()

        Select Case strCmd

            Case "Editar"   ' Edición de un Empleado existente

                ' Buscamos los Datos del empleado
                objrSucursalEmpleadosAsignarRoles = clsEmpleado.strBuscar(intCompaniaId, intSucursalId, intEmpleadoId, False, strCadenaConexion)

                ' Nos aseguramos que hayamos obtenido algún resultado
                If IsArray(objrSucursalEmpleadosAsignarRoles) AndAlso objrSucursalEmpleadosAsignarRoles.Length > 0 Then

                    ' Obtenemos la información
                    strSucursalEmpleadosAsignarRoles = DirectCast(objrSucursalEmpleadosAsignarRoles.GetValue(0), String())

                    ' Obtenemos el Nombre del empleado
                    If Len(strSucursalEmpleadosAsignarRoles(1)) > 0 Then

                        strEmpleadoNombre = clsCommons.strFormatearDescripcion(strSucursalEmpleadosAsignarRoles(1))

                    Else

                        strEmpleadoNombre = ""

                    End If

                    ' Obtenemos el apellido paterno
                    If Len(strSucursalEmpleadosAsignarRoles(2)) > 0 Then

                        strEmpleadoApellidoPaterno = clsCommons.strFormatearDescripcion(strSucursalEmpleadosAsignarRoles(2))

                    Else

                        strEmpleadoApellidoPaterno = ""

                    End If

                    ' Obtenemos el apellido materno
                    If Len(strSucursalEmpleadosAsignarRoles(3)) > 0 Then

                        strEmpleadoApellidoMaterno = clsCommons.strFormatearDescripcion(strSucursalEmpleadosAsignarRoles(3))

                    Else

                        strEmpleadoApellidoMaterno = ""

                    End If

                    ' Obtenemos el puesto del empleado
                    If Len(strSucursalEmpleadosAsignarRoles(4)) > 0 Then

                        intPuestoEmpleadoId = CInt(strSucursalEmpleadosAsignarRoles(4))

                    Else

                        intPuestoEmpleadoId = 0

                    End If

                    ' Obtenemos el numero de usuario
                    If Len(strSucursalEmpleadosAsignarRoles(6)) > 0 Then

                        intUsuarioId = CInt(strSucursalEmpleadosAsignarRoles(6))

                    Else

                        intUsuarioId = 0

                    End If

                    ' Obtenemos el nombre de usuario del empleado 
                    If Len(strSucursalEmpleadosAsignarRoles(7)) > 0 Then

                        strUsuarioNombreEmpleado = strSucursalEmpleadosAsignarRoles(7)

                    Else

                        strUsuarioNombreEmpleado = CStr(intEmpleadoId)

                    End If

                    ' Obtenemos la contrasena del Usuario del empleado 
                    If Len(strSucursalEmpleadosAsignarRoles(8)) > 0 Then

                        strUsuarioContrasenaEmpleado = "*******" 'clsCommons.strFormatearDescripcion(strSucursalEmpleadosAsignarRoles(8))

                    Else

                        strUsuarioContrasenaEmpleado = ""

                    End If

                    ' Obtenemos la fecha de expiracion de la cuenta de Usuario 
                    If Len(strSucursalEmpleadosAsignarRoles(9)) > 0 Then

                        dtmUsuarioExpiracion = CDate(strSucursalEmpleadosAsignarRoles(9))

                    Else

                        dtmUsuarioExpiracion = #1/1/1900#

                    End If

                    ' Obtenemos el grupo de usuarios de asignacion de rol
                    If Len(strSucursalEmpleadosAsignarRoles(10)) > 0 Then

                        intGrupoUsuarioEmpleadoId = CInt(strSucursalEmpleadosAsignarRoles(10))

                    Else

                        intGrupoUsuarioEmpleadoId = 0

                    End If

                    ' Obtenemos la fecha de asignacion del Rol
                    If Len(strSucursalEmpleadosAsignarRoles(12)) > 0 Then

                        dtmUsuarioAsignacion = CDate(strSucursalEmpleadosAsignarRoles(12))

                    Else

                        dtmUsuarioAsignacion = #1/1/1900#

                    End If

                    If Len(strSucursalEmpleadosAsignarRoles(15)) > 0 Then

                        blnUsuarioBloqueado = CByte(strSucursalEmpleadosAsignarRoles(15).Replace("True", "1").Replace("False", "0"))

                    Else

                        blnUsuarioBloqueado = 0

                    End If


                    If Len(strSucursalEmpleadosAsignarRoles(18)) > 0 Then

                        blnUsuarioHabilitado = CByte(strSucursalEmpleadosAsignarRoles(18).Replace("True", "1").Replace("False", "0"))

                    Else

                        blnUsuarioHabilitado = 0

                    End If

                    ' Si se especificó la misma contraseña
                    If StrComp(strCmd, "ReEditar") = 0 Then

                        ' Inicializamos los campos de contraseña de la forma e informamos el error al usuario
                        strmWindowOnLoadEvent &= "    document.forms[0].elements[""txtUsuarioContrasena""].value = """";" & vbCrLf
                        strmWindowOnLoadEvent &= "    document.forms[0].elements[""txtConfirmaUsuarioContrasena""].value = """";" & vbCrLf
                        strmWindowOnLoadEvent &= "    alert(""Por favor establezca una nueva contraseña diferente a la actual."");" & vbCrLf
                        strmWindowOnLoadEvent &= "    blnContrasenaModificada = true;" & vbCrLf

                    End If

                    strmWindowOnLoadEvent &= "    document.forms[0].elements[""txtUsuarioContrasena""].focus();" & vbCrLf

                End If


            Case "Salvar"   ' Actualización de la información de un Empleado existente

                Dim intResultado As Integer = 0

                If intUsuarioId > 0 Then

                    If intEmpleadoId > 0 Then

                        Dim objUsuario As Array = Nothing
                        Dim objRegistroUsuario As String() = Nothing

                        Dim strUsuarioNombreEmpleado As String = ""
                        Dim strUsuarioContrasenaEmpleado As String = ""

                       

                        ' Buscamos la información del usuario
                        objUsuario = clstblUsuario.strBuscar(intEmpleadoId, intUsuarioId, "", "", CByte(0), CDate("01/01/1900"), CDate("01/01/1900"), CDate("01/01/1900"), "", 0, 0, 0, 0, 0, 0, strCadenaConexion)

                        ' Validamos que sea un arreglo
                        If IsArray(objUsuario) AndAlso objUsuario.Length > 0 Then

                            ' El usuario existe y se reemplazara su contraseña
                            objRegistroUsuario = DirectCast(objUsuario.GetValue(0), String())

                            strUsuarioNombreEmpleado = objRegistroUsuario(2)

                            ' Si la contraseña ha sido modificada
                            If GetPageParameter("blnContrasenaModificada", False) Then

                                ' Encriptamos la contraseña
                                strUsuarioContrasenaEmpleado = (New Hash.DataProtector).HashString(Trim(Request.Form("txtUsuarioContrasena")), Hash.DataProtector.CryptoServiceProvider.SHA1)

                                ' Si la nueva contraseña es la misma que la actual
                                If StrComp(strUsuarioContrasenaEmpleado, objRegistroUsuario(3)) = 0 Then

                                    ' Terminamos la ejecución e indicamos el error
                                    Call Response.Redirect(strFormAction & "&strCmd=ReEditar")

                                End If

                            Else

                                ' Si no ha sido alterada, la dejamos tal cual está
                                strUsuarioContrasenaEmpleado = objRegistroUsuario(3)

                            End If

                            ' Actualizamos la fecha de expiracion
                            dtmUsuarioExpiracion = CDate(Date.Now.AddMonths(3).ToString("MM/dd/yyyy"))

                            ' Actualizamos el valor de la contraseña y datos actuales del empleado
                            intResultado = clstblUsuario.intActualizar(intEmpleadoId, intUsuarioId, strUsuarioNombreEmpleado, strUsuarioContrasenaEmpleado, blnUsuarioHabilitado, dtmUsuarioExpiracion, dtmUsuarioUltimoAcceso, dtmUsuarioUltimoAcceso, strUsuarioNombre, 0, 0, blnUsuarioBloqueado, 0, strCadenaConexion)

                            ' Actualizamos el valor del Rol Asignado
                            intResultado = clstblMembresiaUsuario.intActualizar(intEmpleadoId, intUsuarioId, intGrupoFotoLabId, CDate("01/01/1900"), strUsuarioNombre, strCadenaConexion)


                        End If

                    End If

                Else
                    ' Encriptamos la contraseña
                    strUsuarioContrasenaEmpleado = (New Hash.DataProtector).HashString(Trim(Request.Form("txtUsuarioContrasena")), Hash.DataProtector.CryptoServiceProvider.SHA1)

                    ' Actualizamos la fecha de expiracion
                    dtmUsuarioExpiracion = CDate(Date.Now.AddMonths(3).ToString("MM/dd/yyyy"))
               
                    ' No se encontro el Usuario  lo Agregamos
                    intUsuarioId = Benavides.CC.Data.clsUsuario.intAgregarEnConcentrador(intEmpleadoId, 0, intEmpleadoId.ToString, strUsuarioContrasenaEmpleado, blnUsuarioHabilitado, dtmUsuarioExpiracion, dtmUsuarioUltimoAcceso, dtmUsuarioUltimoAcceso, strUsuarioNombre, 0, 0, blnUsuarioBloqueado, 0, strCadenaConexion)

                    If intUsuarioId > 0 Then

                        intResultado = Benavides.CC.Data.clstblMembresiaUsuario.intAgregar(intEmpleadoId, intUsuarioId, intGrupoFotoLabId, dtmUsuarioUltimoAcceso, strUsuarioNombre, strCadenaConexion)

                    End If

                End If

        End Select

    End Sub

End Class
