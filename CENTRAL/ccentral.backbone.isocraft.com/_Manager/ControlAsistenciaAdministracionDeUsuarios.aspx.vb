Imports Benavides.POSAdmin.Commons
Imports System.Text

Public Class ControlAsistenciaAdministracionDeUsuarios
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

        intmEmpleadoId = CInt(isocraft.commons.clsWeb.strGetPageParameter("txtEmpleadoId", "0", Request))
        intmCompaniaId = 0
        intmSucursalId = 0
        intmUsuarioId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intUsuarioId", "0", Request))
        intmEmpleadoSeleccionadoId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intEmpleadoId", "0", Request))
        'intmEmpleadoSeleccionadoId = CInt(Request.QueryString("intEmpleadoId"))
        'intmUsuarioId = CInt(Request.QueryString("intUsuarioId"))

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
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", String.Empty, Request, Server)
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
    ' Name       : intGrupoUsuarioSeleccionadoID
    ' Description: Obtiene o establece el grupo de usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intGrupoUsuarioSeleccionadoId() As Integer
        'Get
        '    Return intmGrupoUsuarioSeleccionadoId
        'End Get
        'Set(ByVal intValue As Integer)
        '    intmGrupoUsuarioSeleccionadoId = intValue
        'End Set

        Get
            If Not (Request.Form("hdnGrupoControlAsistencia") = Nothing) Then
                Return CInt(Request.Form("hdnGrupoControlAsistencia"))
            Else
                Dim objArray As Array = Nothing
                Dim intGrupoId As String() = Nothing

                Dim intSeleccionadoId As Integer

                objArray = Benavides.CC.Data.clsControlDeAsistencia.strBuscarGrupoControlAsistencia(strConnectionString)

                'For Each intGrupoId In objArray
                '    intGrupoId = objArray(0)
                'Next




                'Return CInt(intGrupoId(0))


                If IsArray(objArray) AndAlso objArray.Length > 0 Then
                    'intSeleccionadoId = DirectCast(DirectCast(objArray, Array).GetValue(0), Integer)

                    'intSeleccionadoId = CType(objArray.GetValue(0), Integer)
                    intGrupoId = CType(objArray.GetValue(0), String())
                    intSeleccionadoId = CInt(intGrupoId(0))
                Else
                    intSeleccionadoId = 0
                End If

                Return intSeleccionadoId


                'Else
                'Return 0
            End If
        End Get
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
    'Public Function strLlenarGrupoComboBox() As String
    '    Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboGrupoUsuario", intGrupoUsuarioSeleccionadoId, Benavides.CC.Data.clstblGrupoUsuario.strBuscar(0, "", "", "", 0, 1, Now(), "", 0, 0, strConnectionString), 0, 2, 1)
    'End Function

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRecordBrowserHTML() As String
        Get
            '' Declaramos e inicializamos las constantes locales
            'Const intElementsPerPage As Integer = 10
            'Const strRecordBrowserName As String = "SistemaAdministrarUsuarios"

            '' Declaramos e inicialziamos las variables locales
            'Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1", Request))
            'Dim astrDataArray As Array = Benavides.CC.Data.clsUsuario.strBuscarEnConcentrador(intGrupoUsuarioSeleccionadoId, intCompaniaId, intSucursalId, intEmpleadoId, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

            '' Obtenemos el HTML
            'Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?")

            ' Declaramos e inicializamos las constantes locales
            'Const intElementsPerPage As Integer = 10
            'Const strRecordBrowserName As String = "SistemaAdministrarUsuarios"

            ' Declaramos e inicialziamos las variables locales
            'Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1", Request))
            Dim astrDataArray As Array = Nothing

            If (Request.QueryString("pager") = "true") Then
                If Not Cache("cacheUsuarios") Is Nothing Then
                    astrDataArray = CType(Cache("cacheUsuarios"), System.Array)
                End If
            End If

            If astrDataArray Is Nothing Then
                Cache.Remove("cacheUsuarios")

                'astrDataArray = Benavides.CC.Data.clsUsuario.strBuscarEnConcentrador(intGrupoUsuarioSeleccionadoId, intCompaniaId, intSucursalId, intEmpleadoId, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)
                astrDataArray = Benavides.CC.Data.clsControlDeAsistencia.strBuscarUsuarioConcentrador(intGrupoUsuarioSeleccionadoId, intEmpleadoId, strConnectionString)

            End If

            If Not astrDataArray Is Nothing AndAlso IsArray(astrDataArray) AndAlso astrDataArray.Length > 0 Then

                Cache.Add("cacheUsuarios", astrDataArray, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, Nothing)

                'Resultados en HTML
                Return strTablaConsultaUsuariosHTML(astrDataArray)

            End If

            ' Obtenemos el HTML
            Return String.Empty
            'Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?")

        End Get
    End Property

    Public Function strTablaConsultaUsuariosHTML(ByVal objConsultaUsuarios As Array) As String

        Dim strTablaUsuariosHTML As StringBuilder
        Dim strConsultaUsuariosDetalle As String()
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim imgDeshabilitarUsuario As String = Nothing
        Dim imgEditarUsuario As String = String.Empty

        Dim intPage As Integer
        Dim intTotal As Integer = 10

        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If

        strTablaUsuariosHTML = New StringBuilder
        strTablaUsuariosHTML.Append(Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objConsultaUsuarios.Length, intPage, intTotal, String.Empty, Nothing))

        strTablaUsuariosHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Encabezados de Tabla de Resultados
        strTablaUsuariosHTML.Append("<tr class='trtitulos'>")
        strTablaUsuariosHTML.Append("<th class='rayita' align='center' valign='top'>Usuario</th>")
        strTablaUsuariosHTML.Append("<th class='rayita' align='center' valign='top'>Nombre de Coordinador</th>")
        strTablaUsuariosHTML.Append("<th class='rayita' align='center' valign='top'>Estatus</th>")
        strTablaUsuariosHTML.Append("<th class='rayita' align='center' valign='top'>Acción</th>")
        strTablaUsuariosHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        'For Each strConsultaUsuariosDetalle In objConsultaUsuarios
        '    intContador += 1

        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaUsuarios.Length) Then
                Exit For
            End If

            strConsultaUsuariosDetalle = CType(objConsultaUsuarios.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            'Botones "Ver Detalle" (Articulos/Sucursal).
            imgDeshabilitarUsuario = "<img id=" & strConsultaUsuariosDetalle(0) & " height='17' src='../static/images/imgNRDesasignar.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdDeshabilitarUsuario_onclick(" & strConsultaUsuariosDetalle(0) & "," & strConsultaUsuariosDetalle(2) & ")' alt='Haga clic aquí para cambiar el estatus del usuario'>"
            imgEditarUsuario = "<img id=" & strConsultaUsuariosDetalle(0) & " height='17' src='../static/images/imgNREditar.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdEditarUsuario_onclick(" & strConsultaUsuariosDetalle(0) & "," & strConsultaUsuariosDetalle(2) & ")' alt='Haga clic aquí para editar este usuario'>"

            strTablaUsuariosHTML.Append("<tr>")
            ' Usuario
            strTablaUsuariosHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaUsuariosDetalle(0)) & "</td>")
            ' Nombre de Empleado
            strTablaUsuariosHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaUsuariosDetalle(1)) & "</td>")
            ' Estatus
            strTablaUsuariosHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaUsuariosDetalle(4)) & "</td>")
            'Accion 
            strTablaUsuariosHTML.Append("<td align=center class=" & strColorRegistro & ">" & imgDeshabilitarUsuario & " " & imgEditarUsuario & "</td>")
            strTablaUsuariosHTML.Append("</tr>")
        Next

        strTablaUsuariosHTML.Append("</tr>")
        strTablaUsuariosHTML.Append("</table>")
        strTablaUsuariosHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaUsuariosHTML = strTablaUsuariosHTML.ToString

    End Function



    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        'If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Or Not intTipoUsuarioId = 1 Or CInt(strUsuarioNombre) = 40014547 Then
        '    Call Response.Redirect("../Default.aspx")
        'End If

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", String.Empty, Request)

        Select Case strCmd
            Case "Agregar"
                'Call Response.Redirect("SistemaAgregarUsuario.aspx?strCmd=Agregar")
                Call Response.Redirect("ControlAsistenciaAdministracionDeUsuariosAgregar.aspx?strCmd=Agregar")
                Call Response.End()

            Case "Editar"
                Call Response.Redirect("ControlAsistenciaAdministracionDeUsuariosAgregar.aspx?strCmd=Editar&intEmpleadoId=" & intEmpleadoSeleccionadoId.ToString & "&intUsuarioId=" & intUsuarioId.ToString)
                Call Response.End()

            Case "Desasignar" '(Deshabilita usuario)

                ' Verificamos que exista información
                If intEmpleadoSeleccionadoId > 0 AndAlso intUsuarioId > 0 Then
                    Call Benavides.CC.Data.clsUsuario.intActualizarEstatus(intEmpleadoSeleccionadoId, intUsuarioId, strUsuarioNombre, strConnectionString)
                End If

        End Select


    End Sub


End Class

