Imports Isocraft.Web.Http
Imports Isocraft.Security
Imports Benavides.POSAdmin.Commons
Imports System.Text

Public Class ControlAsistenciaAdministracionDeUsuariosAgregar
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
    Private intDireccionOperativaId As Integer
    Private intmUsuarioId As Integer
    Private blnmUsuarioBloqueado As Byte
    Private intmUsuarioExistenteId As Integer

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
        'If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then

        '    Call Response.Redirect("../Default.aspx")

        'End If

        ' Almacenamos el comando ejecutado
        strmCommand = GetPageParameter("strCmd", GetPageParameter("txtCmd", ""))
        intmCompaniaId = GetPageParameter("intCompaniaId", 0)
        intmSucursalId = GetPageParameter("intSucursalId", 0)
        intDireccionOperativaId = GetPageParameter("intDireccionOperativaId", 0)
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
    ' Name       : strTipoUsuarioId
    ' Description: Tipo de usuario actual
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTipoUsuarioId() As Integer
        Get
            Return Benavides.CC.Data.clsControlDeAsistencia.intObtenerTipoUsuarioId(strUsuarioNombre, strConnectionString)
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
    ' Name       : strFechaActual
    ' Description: Regresa la fecha actual
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFechaActual() As String
        Get

            Dim dtmFechaActual As Date

            dtmFechaActual = New Date(Date.Today.Year, Date.Today.Month, Date.Today.Day)

            Return dtmFechaActual.ToString("dd/MM/yyyy")
        End Get
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
        'Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboGrupoUsuario", intGrupoUsuarioSeleccionadoId, Benavides.CC.Data.clstblGrupoUsuario.strBuscar(0, "", "", "", 0, 1, Now(), "", 0, 0, strConnectionString), 0, 2, 1)
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboGrupoUsuario", intGrupoUsuarioSeleccionadoId, Benavides.CC.Data.clsControlDeAsistencia.strBuscarGrupoControlAsistencia(strConnectionString), 0, 1, 0)

    End Function

    '====================================================================
    ' Name       : intUsuarioExistenteId
    ' Description: Indica si el usuario existe
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intUsuarioExistenteId() As Integer

        Get

            Return intmUsuarioExistenteId

        End Get

        Set(ByVal intValue As Integer)

            intmUsuarioExistenteId = intValue

        End Set

    End Property

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
            'Const intElementsPerPage As Integer = 10
            'Const strRecordBrowserName As String = "SistemaAgregarUsuario"

            '' Declaramos e inicialziamos las variables locales
            'Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
            ''Dim astrDataArray As Array = Benavides.CC.Data.clsUsuario.strBuscarRangoOperacion(intEmpleadoId, intUsuarioId, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

            'Dim astrDataArray As Array = Benavides.CC.Data.clsControlDeAsistencia.strObtenerSucursalesPorCoordinadorRH(intEmpleadoId, 0, 0, intUsuarioId, strConnectionString)


            '' Establecemos los eventos onClick actual y futuro
            ''Dim strCurrentJavascriptOnClickEvent As String = "onclick=""window.location='SistemaAgregarUsuario.aspx?strCmd=Agregar'"""
            'Dim strCurrentJavascriptOnClickEvent As String = "onclick=""window.location='ControlAsistenciaAdministracionDeUsuariosAgregar.aspx?strCmd=Agregar'"""
            'Dim strNewJavascriptOnClickEvent As String = "onclick=""cmdNavegadorRegistrosAgregar_onclick(" & intEmpleadoId & ",'" & Replace(Replace(Benavides.POSAdmin.Commons.clsCommons.strGenerateJavascriptString(strEmpleadoNombre), "/", " "), "-", " ") & "', " & intGrupoUsuarioSeleccionadoId & ");"""

            ''If StrComp(strCmd, "SalvarAgregar") <> 0 AndAlso StrComp(strCmd, "Agregar") <> 0 AndAlso strCmd.Length > 0 AndAlso blnUsuarioAlcance = 0 Then

            ''    ' Obtenemos el HTML
            'Dim strReturn As String = Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?")

            ''    ' Regresamos el resultado
            'Return Replace(strReturn, strCurrentJavascriptOnClickEvent, strNewJavascriptOnClickEvent)

            'Else

            '    Return ""

            'End If


            '''''''''''''''''''''
            Dim astrDataArray As Array = Nothing



            If (Request.QueryString("pager") = "true") Then
                If Not Cache("cacheSucursales") Is Nothing Then
                    astrDataArray = CType(Cache("cacheSucursales"), System.Array)
                End If
            End If

            If astrDataArray Is Nothing Then
                Cache.Remove("cacheSucursales")

                'astrDataArray = Benavides.CC.Data.clsUsuario.strBuscarEnConcentrador(intGrupoUsuarioSeleccionadoId, intCompaniaId, intSucursalId, intEmpleadoId, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)
                astrDataArray = Benavides.CC.Data.clsControlDeAsistencia.strObtenerSucursalesPorCoordinadorRH(intEmpleadoId, 0, 0, intUsuarioId, strConnectionString)

            End If

            If Not astrDataArray Is Nothing AndAlso IsArray(astrDataArray) AndAlso astrDataArray.Length > 0 Then

                Cache.Add("cacheSucursales", astrDataArray, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, Nothing)

                'Resultados en HTML
                Return strTablaConsultaSucursalesHTML(astrDataArray)

            End If

            ' Obtenemos el HTML
            Return String.Empty
        End Get

    End Property

    Public Function strTablaConsultaSucursalesHTML(ByVal objConsultaSucursales As Array) As String

        Dim strTablaSucursalesHTML As StringBuilder
        Dim strConsultaSucursalDetalle As String()
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim imgDesasignarSucursal As String = Nothing
        Dim intCompaniaId As Integer = -1
        Dim intSucursalId As Integer = -1

        Dim intPage As Integer
        Dim intTotal As Integer = 10

        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If

        strTablaSucursalesHTML = New StringBuilder
        strTablaSucursalesHTML.Append(Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objConsultaSucursales.Length, intPage, intTotal, String.Empty, Nothing))

        strTablaSucursalesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Encabezados de Tabla de Resultados
        strTablaSucursalesHTML.Append("<tr class='trtitulos'>")
        strTablaSucursalesHTML.Append("<th class='rayita' align='center' valign='top'>Compañia</th>")
        strTablaSucursalesHTML.Append("<th class='rayita' align='center' valign='top'>Sucursal</th>")
        strTablaSucursalesHTML.Append("<th class='rayita' align='center' valign='top'>Nombre</th>")
        strTablaSucursalesHTML.Append("<th class='rayita' align='center' valign='top'>Acción</th>")
        strTablaSucursalesHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        'For Each strConsultaSucursalDetalle In objConsultaSucursales
        '    intContador += 1

        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaSucursales.Length) Then
                Exit For
            End If

            strConsultaSucursalDetalle = CType(objConsultaSucursales.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            If Not strConsultaSucursalDetalle(0).ToString = "NA" Then
                intCompaniaId = CInt(strConsultaSucursalDetalle(0))
            End If

            If Not strConsultaSucursalDetalle(1).ToString = "NA" Then
                intSucursalId = CInt(strConsultaSucursalDetalle(1))
            End If

            'Botones "Ver Detalle" (Articulos/Sucursal).
            'imgDesasignarSucursal = "<img height='17' src='../static/images/imgNRDesasignar.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdDesasignarSucursal_onclick(" & strConsultaSucursalDetalle(0).ToString & "," & strConsultaSucursalDetalle(1).ToString & "," & strConsultaSucursalDetalle(2) & "," & strConsultaSucursalDetalle(7) & ")' alt='Haga clic aquí para cambiar el estatus del usuario'>"
            imgDesasignarSucursal = "<img height='17' src='../static/images/imgNRDesasignar.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdDesasignarSucursal_onclick(" & intCompaniaId.ToString & "," & intSucursalId.ToString & "," & strConsultaSucursalDetalle(7) & "," & strConsultaSucursalDetalle(2) & "," & strConsultaSucursalDetalle(8) & ")' alt='Haga clic aquí para cambiar el estatus del usuario'>"
            'imgEditarUsuario = "<img id=" & strConsultaSucursalDetalle(0) & " height='17' src='../static/images/imgNREditar.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdEditarUsuario_onclick(" & strConsultaSucursalDetalle(0) & "," & strConsultaSucursalDetalle(2) & ")' alt='Haga clic aquí para editar este usuario'>"

            strTablaSucursalesHTML.Append("<tr>")
            ' Compania
            strTablaSucursalesHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaSucursalDetalle(0)) & "</td>")
            ' Sucursal
            strTablaSucursalesHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaSucursalDetalle(1)) & "</td>")
            ' Nombre
            strTablaSucursalesHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaSucursalDetalle(6)) & "</td>")
            'Accion 
            strTablaSucursalesHTML.Append("<td align=center class=" & strColorRegistro & ">" & imgDesasignarSucursal & "</td>")
            strTablaSucursalesHTML.Append("</tr>")
        Next

        strTablaSucursalesHTML.Append("</tr>")
        strTablaSucursalesHTML.Append("</table>")
        strTablaSucursalesHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaSucursalesHTML = strTablaSucursalesHTML.ToString

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        'If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Or Not intTipoUsuarioId = 1 Or CInt(strUsuarioNombre) = 40014547 Then
        '    Call Response.Redirect("../Default.aspx")
        'End If

        If Not strCmd = "Agregar" AndAlso intEmpleadoId = 0 Then
            Call Response.Redirect("ControlAsistenciaAsignarSucursales.aspx")
        End If


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
                intUsuarioId = Benavides.CC.Data.clsUsuario.intAgregarEnConcentrador(intmEmpleadoId, 0, intmEmpleadoId.ToString, strmUsuarioContrasena, blnmUsuarioEstatus, dtmmUsuarioExpiracion, Now(), Now(), strUsuarioNombre, 0, 0, blnmUsuarioBloqueado, 0, strConnectionString)

                strmUsuarioContrasena = "********"

                If intUsuarioId > 0 Then

                    intmUsuarioExistenteId = 1
                    intRetorno = Benavides.CC.Data.clstblMembresiaUsuario.intAgregar(intmEmpleadoId, intmUsuarioId, intmGrupoUsuarioSeleccionadoId, Now(), strUsuarioNombre, strConnectionString)

                End If

                ' Establecemos el siguiente comando
                strCmd = "Actualizar"

            Case "Actualizar"

                ' Si los identificadores del usuario son válidos
                If intmEmpleadoId > 0 AndAlso intmUsuarioId > 0 Then

                    ' Obtenemos los datos del usuario
                    Dim aobjUsuarios As Array = Benavides.CC.Data.clstblUsuario.strBuscar(intmEmpleadoId, intmUsuarioId, String.Empty, String.Empty, 0, #1/1/1900#, #1/1/1900#, #1/1/1900#, String.Empty, 0, 0, 0, 0, 0, 0, strConnectionString)
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
                        intRetorno = Benavides.CC.Data.clstblUsuario.intActualizar(intmEmpleadoId, intmUsuarioId, CStr(intmEmpleadoId), strmUsuarioContrasena, blnmUsuarioEstatus, dtmmUsuarioExpiracion, dtmUsuarioUltimoAcceso, Now(), strUsuarioNombre, blnUsuarioLocal, 0, blnmUsuarioBloqueado, 0, strConnectionString)

                        strmUsuarioContrasena = "********"

                        If intRetorno > 0 Then

                            Dim astrDataArray As Array = Benavides.CC.Data.clstblMembresiaUsuario.strBuscar(intmEmpleadoId, intmUsuarioId, intmGrupoUsuarioSeleccionadoId, Now(), String.Empty, 0, 0, strConnectionString)

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

                        intmUsuarioExistenteId = 1
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

                    If Not intmCompaniaId = 0 AndAlso Not intmSucursalId = 0 AndAlso intmEmpleadoId > 0 Then

                        'Elimina la sucursal de la tabla tblRelacionRHSucursales
                        intRetorno = Benavides.CC.Data.clsControlDeAsistencia.strDesasignarSucursales(intmEmpleadoId, intmCompaniaId, intmSucursalId, intDireccionOperativaId, strConnectionString)
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
                    Dim intExito As Integer
                    Dim intAsignada As Integer

                    intExito = 0
                    intAsignada = 0

                    For Each strCompaniaIdentificadorSucursal In astrIdentificadoresCompaniaSucursal

                        ' Separamos los pares identificadores y los almacenamos en un arreglo
                        Dim astrCompaniaSucursal As Array = strCompaniaIdentificadorSucursal.Split("|"c)


                        ' Si existen identificadores
                        If astrCompaniaSucursal.Length > 0 Then

                            ' Obtenemos la compañía, la sucursal y el nuevo tipo de cambio
                            Dim intCompaniaRecibidaId As Integer = CInt(astrCompaniaSucursal.GetValue(0))
                            Dim intSucursalRecibidaId As Integer = CInt(astrCompaniaSucursal.GetValue(1))

                            Dim arrayRespuesta As Array = Nothing
                            arrayRespuesta = Benavides.CC.Data.clsControlDeAsistencia.strAsignarSucursales(intmEmpleadoId, intCompaniaRecibidaId, intSucursalRecibidaId, strConnectionString)

                            intmUsuarioExistenteId = 1
                            If arrayRespuesta.Length > 0 AndAlso IsArray(arrayRespuesta) Then

                                ' Recorremos los pares identificadores
                                Dim strResultadosAsignacionSucursal As Array


                                For Each strResultadosAsignacionSucursal In arrayRespuesta

                                    If Not (strResultadosAsignacionSucursal.GetValue(0) Is Nothing) AndAlso Not (CInt(strResultadosAsignacionSucursal.GetValue(0)) = -1) Then
                                        intExito = CInt(strResultadosAsignacionSucursal.GetValue(0))
                                    End If

                                    If Not (strResultadosAsignacionSucursal.GetValue(1) Is Nothing) AndAlso Not CBool(strResultadosAsignacionSucursal.GetValue(1)) = False Then
                                        intAsignada = 1 'CInt(strResultadosAsignacionSucursal.GetValue(1))
                                    End If
                                Next
                            End If
                        End If
                    Next

                    strJavascriptWindowOnLoadCommands &= "fnRespuestaAsignacionSucursal( " & intExito.ToString & "," & intAsignada.ToString & ");" & vbCrLf

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
