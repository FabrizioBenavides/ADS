'==================================================================== 
' Class         : clsSistemaAgregarUsuario
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Administrar tiendas
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Javier Ramos
' Version       : 1.0
' Last Modified : Wednesday, July 5, 2006
'====================================================================
Imports Isocraft.Web.Http
Imports Isocraft.Security

Public Class clsSistemaAgregarUsuario
    Inherits System.Web.UI.Page

    ' Variables locales privadas
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private intmEmpleadoId As Integer
    Private intmGrupoUsuarioSeleccionadoId As Integer
    Private strmUsuarioContrasena As String
    Private dtmmUsuarioExpiracion As Date
    Private blnmUsuarioEstatus As Byte
    Private blnmUsuarioAlcance As Byte
    Private strmEmpleadoNombre As String
    Private strmSucursales As String
    Private intmCompaniaId As Integer
    Private intmSucursalId As Integer
    Private intmUsuarioId As Integer
    Private blnmUsuarioBloqueado As Byte

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then

            Call Response.Redirect("../Default.aspx")

        End If

        ' Almacenamos el comando ejecutado
        strmCommand = GetPageParameter("strCmd", GetPageParameter("txtCmd", ""))
        intmCompaniaId = GetPageParameter("intCompaniaId", 0)
        intmSucursalId = GetPageParameter("intSucursalId", 0)

        ' Almacenamos el empleado capturado para la búsqueda
        intmEmpleadoId = GetPageParameter("txtUsuarioNombre", GetPageParameter("intEmpleadoId", 0))

        ' Almacenamos el usuario Id
        intmUsuarioId = GetPageParameter("txtUsuarioId", GetPageParameter("intUsuarioId", 0))

        ' Almacenamos el nombre del empleado
        strmEmpleadoNombre = GetPageParameter("txtEmpleadoNombre", "")

        ' Almacenamos el grupo de usuario capturado para la búsqueda
        intmGrupoUsuarioSeleccionadoId = GetPageParameter("cboGrupoUsuario", 0)

        ' Almacenamos la contraseña capturada
        strmUsuarioContrasena = GetPageParameter("txtUsuarioContrasena", "")

        ' Almacenamos la fecha de expiración del usuario
        dtmmUsuarioExpiracion = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(GetPageParameter("txtUsuarioExpiracion", DateAdd(DateInterval.Day, 30, Date.Now).ToString("dd/MM/yyyy"))))

        ' Almacenamos el estatus del usuario
        blnmUsuarioEstatus = GetPageParameter("chkUsuarioHabilitado", CByte(2))

        ' Almacenamos el alcance del usuario
        blnmUsuarioAlcance = GetPageParameter("chkUsuarioAlcance", CByte(0))

        ' Almacenamos la lista de sucursales seleccionadas
        strmSucursales = GetPageParameter("txtSucursales", GetPageParameter("strSucursales", ""))

        ' Obtenemos el indicador de bloqueo del usuario
        blnmUsuarioBloqueado = GetPageParameter("optCuentaBloqueada", CByte(0))

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
    ' Name       : strEmpleadoNombre
    ' Description: Obtiene o establece el nombre del empleado
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
    ' Name       : intGrupoUsuarioSeleccionadoId
    ' Description: Obtiene o establece el grupo usuario Id
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
    ' Name       : strUsuarioContrasena
    ' Description: Obtiene o establece la contraseña del usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strUsuarioContrasena() As String

        Get

            Return strmUsuarioContrasena

        End Get

        Set(ByVal strValue As String)

            strmUsuarioContrasena = strValue

        End Set

    End Property

    '====================================================================
    ' Name       : dtmUsuarioExpiracion
    ' Description: Obtiene o establece la fecha de expiracion del usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Date
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
    ' Name       : blnUsuarioEstatus
    ' Description: Obtiene o establece el estatus del usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Byte
    '====================================================================
    Public Property blnUsuarioEstatus() As Byte

        Get

            Return blnmUsuarioEstatus

        End Get

        Set(ByVal blnValue As Byte)

            blnmUsuarioEstatus = blnValue

        End Set

    End Property

    '====================================================================
    ' Name       : blnUsuarioAlcance
    ' Description: Obtiene o establece el alcance del usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Byte
    '====================================================================
    Public Property blnUsuarioAlcance() As Byte

        Get

            Return blnmUsuarioAlcance

        End Get

        Set(ByVal blnValue As Byte)

            blnmUsuarioAlcance = blnValue

        End Set

    End Property

    '====================================================================
    ' Name       : strSucursales
    ' Description: Listado de sucursales seleccionadas
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strSucursales() As String

        Get

            Return strmSucursales

        End Get

        Set(ByVal stValue As String)

            strmSucursales = stValue

        End Set

    End Property

    '====================================================================
    ' Name       : intCompaniaId 
    ' Description: Obtiene o establece el id de la Compañia
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
    ' Description: Obtiene o establece el id de la Sucursal
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

    ''' <summary>
    '''     Indica si el usuario está bloqueado
    ''' </summary>
    ''' <value>
    '''     <para>
    '''         0 Bloqueado, 1 No bloqueado
    '''     </para>
    ''' </value>
    ''' <remarks>
    '''     
    ''' </remarks>
    Public ReadOnly Property blnUsuarioBloqueado() As Byte

        Get

            Return blnmUsuarioBloqueado

        End Get

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
            Const strRecordBrowserName As String = "SistemaAgregarUsuario"

            ' Declaramos e inicialziamos las variables locales
            Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
            Dim astrDataArray As Array = Benavides.CC.Data.clsUsuario.strBuscarRangoOperacion(intEmpleadoId, intUsuarioId, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

            ' Establecemos los eventos onClick actual y futuro
            Dim strCurrentJavascriptOnClickEvent As String = "onclick=""window.location='SistemaAgregarUsuario.aspx?strCmd=Agregar'"""
            Dim strNewJavascriptOnClickEvent As String = "onclick=""cmdNavegadorRegistrosAgregar_onclick(" & intEmpleadoId & ",'" & Replace(Replace(Benavides.POSAdmin.Commons.clsCommons.strGenerateJavascriptString(strEmpleadoNombre), "/", " "), "-", " ") & "', " & intGrupoUsuarioSeleccionadoId & ");"""

            If StrComp(strCmd, "SalvarAgregar") <> 0 AndAlso StrComp(strCmd, "Agregar") <> 0 AndAlso strCmd.Length > 0 AndAlso blnUsuarioAlcance = 0 Then

                ' Obtenemos el HTML
                Dim strReturn As String = Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?")

                ' Regresamos el resultado
                Return Replace(strReturn, strCurrentJavascriptOnClickEvent, strNewJavascriptOnClickEvent)

            Else

                Return ""

            End If

        End Get

    End Property

    Private Sub Page_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Load

        ' Variable para asignar los resultados de las operaciones
        Dim intRetorno As Integer = 0
        Dim blnActualizarContrasena As Boolean = GetPageParameter("txtActualizarContrasena", False)

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Agregar"

                ' Establecemos el siguiente comando
                strCmd = "SalvarAgregar"

            Case "SalvarAgregar"

                strmUsuarioContrasena = (New Hash.DataProtector).HashString(strmUsuarioContrasena, Hash.DataProtector.CryptoServiceProvider.SHA1)

                ' Agregamos el usuario
                intUsuarioId = Benavides.CC.Data.clsUsuario.intAgregarEnConcentrador(intmEmpleadoId, 0, intmEmpleadoId.ToString, strmUsuarioContrasena, blnmUsuarioEstatus, dtmmUsuarioExpiracion, Now(), Now(), strUsuarioNombre, 0, 0, blnmUsuarioBloqueado, 1, strConnectionString)

                strmUsuarioContrasena = "********"

                If intUsuarioId > 0 Then

                    intRetorno = Benavides.CC.Data.clstblMembresiaUsuario.intAgregar(intmEmpleadoId, intmUsuarioId, intmGrupoUsuarioSeleccionadoId, Now(), strUsuarioNombre, strConnectionString)

                End If

                ' Establecemos el siguiente comando
                strCmd = "Actualizar"

            Case "Actualizar"

                ' Si los identificadores del usuario son válidos
                If intmEmpleadoId > 0 AndAlso intmUsuarioId > 0 Then

                    ' Obtenemos los datos del usuario
                    Dim aobjUsuarios As Array = Benavides.CC.Data.clstblUsuario.strBuscar(intmEmpleadoId, intmUsuarioId, "", "", 0, #1/1/1900#, #1/1/1900#, #1/1/1900#, "", 0, 0, 0, 0, 0, 0, strConnectionString)
                    Dim blnUsuarioLocal As Byte
                    Dim blnUsuarioDebeCambiarContrasena As Byte
                    Dim dtmUsuarioUltimoAcceso As DateTime

                    ' Si encontramos los datos del usuario
                    If IsArray(aobjUsuarios) AndAlso aobjUsuarios.Length > 0 Then

                        ' Si la contraseña ha sido modificada
                        If blnActualizarContrasena Then

                            ' Encriptamos la contraseña
                            strmUsuarioContrasena = (New Hash.DataProtector).HashString(strmUsuarioContrasena, Hash.DataProtector.CryptoServiceProvider.SHA1)

                        Else

                            ' Si no ha sido modificada recuperamos la contraseña actual
                            strmUsuarioContrasena = DirectCast(aobjUsuarios.GetValue(0), String())(3)

                        End If

                        ' Obtenemos los datos adicionales del usuario
                        dtmUsuarioUltimoAcceso = CDate(DirectCast(aobjUsuarios.GetValue(0), String())(6))
                        blnUsuarioLocal = CByte(DirectCast(aobjUsuarios.GetValue(0), String())(9).Replace("True", "1").Replace("False", "0"))

                        ' Actualizamos los datos del usuario
                        intRetorno = Benavides.CC.Data.clstblUsuario.intActualizar(intmEmpleadoId, intmUsuarioId, CStr(intmEmpleadoId), strmUsuarioContrasena, blnmUsuarioEstatus, dtmmUsuarioExpiracion, dtmUsuarioUltimoAcceso, Now(), strUsuarioNombre, blnUsuarioLocal, 0, blnmUsuarioBloqueado, 1, strConnectionString)

                        strmUsuarioContrasena = "********"

                        If intRetorno > 0 Then

                            Dim astrDataArray As Array = Benavides.CC.Data.clstblMembresiaUsuario.strBuscar(intmEmpleadoId, intmUsuarioId, intmGrupoUsuarioSeleccionadoId, Now(), "", 0, 0, strConnectionString)

                            If astrDataArray.Length <= 0 Then

                                intRetorno = Benavides.CC.Data.clstblMembresiaUsuario.intAgregar(intmEmpleadoId, intmUsuarioId, intmGrupoUsuarioSeleccionadoId, Now(), strUsuarioNombre, strConnectionString)

                            End If

                        End If

                    Else

                    End If

                End If

                ' Establecemos el siguiente comando
                strCmd = "Actualizar"

            Case "Editar", "Desasignar"

                Dim avntRow As Array = Nothing
                Dim intAlcanceUsuario As Integer = 0
                Dim astrDataArray As Array = Benavides.CC.Data.clsUsuario.strBuscarDetalleUsuario(intmEmpleadoId, intmUsuarioId, strConnectionString)

                If IsArray(astrDataArray) AndAlso astrDataArray.Length > 0 Then

                    For Each avntRow In astrDataArray

                        strmEmpleadoNombre = CStr(avntRow.GetValue(2))
                        intmGrupoUsuarioSeleccionadoId = CInt(avntRow.GetValue(3))
                        strmUsuarioContrasena = "********"

                        If CStr(avntRow.GetValue(6)).Equals("False") Then

                            blnmUsuarioEstatus = 0

                        Else

                            blnmUsuarioEstatus = 1

                        End If

                        dtmmUsuarioExpiracion = CDate(avntRow.GetValue(7))

                        intAlcanceUsuario = CInt(avntRow.GetValue(11))

                        If intAlcanceUsuario > 0 Then

                            blnmUsuarioAlcance = 0

                        Else

                            blnmUsuarioAlcance = 1

                        End If

                        ' Obtenemos el indicador de bloqueo de la cuenta de usuario
                        blnmUsuarioBloqueado = CByte(CStr(avntRow.GetValue(14)).Replace("True", "1").Replace("False", "0"))

                    Next

                End If

                If strCmd.Equals("Desasignar") Then

                    If intmCompaniaId > 0 AndAlso intmSucursalId > 0 AndAlso intmEmpleadoId > 0 Then

                        intRetorno = Benavides.CC.Data.clstblEmpleadoSucursal.intActualizar(intmCompaniaId, intmSucursalId, intmEmpleadoId, 0, Now(), strUsuarioNombre, strConnectionString)

                    End If

                End If

                ' Establecemos el siguiente comando
                strCmd = "Actualizar"

            Case "Vincular"

                ' Almacenamos en un arreglo la lista de compañías y sucursales
                ' La lista tiene el siguiente formato:
                '   intCompaniaId | intSucursalId , intCompaniaId | intSucursalId, ..., intCompaniaId | intSucursalId
                Dim astrIdentificadoresCompaniaSucursal As Array = strSucursales.Split(","c)

                ' Si obtuvimos pares de identificadores "intCompaniaId | intSucursalId"
                If astrIdentificadoresCompaniaSucursal.Length > 0 Then

                    ' Recorremos los pares identificadores
                    Dim strCompaniaIdentificadorSucursal As String

                    For Each strCompaniaIdentificadorSucursal In astrIdentificadoresCompaniaSucursal

                        ' Separamos los pares identificadores y los almacenamos en un arreglo
                        Dim astrCompaniaSucursal As Array = strCompaniaIdentificadorSucursal.Split("|"c)

                        ' Si existen identificadores
                        If astrCompaniaSucursal.Length > 0 Then

                            ' Obtenemos la compañía, la sucursal y el nuevo tipo de cambio
                            Dim intCompaniaRecibidaId As Integer = CInt(astrCompaniaSucursal.GetValue(0))
                            Dim intSucursalRecibidaId As Integer = CInt(astrCompaniaSucursal.GetValue(1))

                            If intCompaniaRecibidaId > 0 AndAlso intSucursalRecibidaId > 0 AndAlso intmEmpleadoId > 0 Then

                                Dim astrDataArray As Array = Benavides.CC.Data.clstblEmpleadoSucursal.strBuscar(intCompaniaRecibidaId, intSucursalRecibidaId, intmEmpleadoId, 0, Now(), "Admin", 0, 0, strConnectionString)

                                If IsArray(astrDataArray) AndAlso astrDataArray.Length > 0 Then

                                    intRetorno = Benavides.CC.Data.clstblEmpleadoSucursal.intActualizar(intCompaniaRecibidaId, intSucursalRecibidaId, intmEmpleadoId, 1, Now(), strUsuarioNombre, strConnectionString)

                                Else

                                    intRetorno = Benavides.CC.Data.clstblEmpleadoSucursal.intAgregar(intCompaniaRecibidaId, intSucursalRecibidaId, intmEmpleadoId, 1, Now(), strUsuarioNombre, strConnectionString)

                                End If

                            End If

                        End If

                    Next

                End If

                ' Establecemos el siguiente comando
                strCmd = "Actualizar"

        End Select

        If blnUsuarioEstatus = 0 Then

            strJavascriptWindowOnLoadCommands &= "document.forms[0].elements[""chkUsuarioHabilitado""][1].checked=""true"";" & vbCrLf

        ElseIf blnUsuarioEstatus = 1 OrElse blnUsuarioEstatus = 2 Then

            strJavascriptWindowOnLoadCommands &= "document.forms[0].elements[""chkUsuarioHabilitado""][0].checked=""true"";" & vbCrLf

        End If

    End Sub

End Class
