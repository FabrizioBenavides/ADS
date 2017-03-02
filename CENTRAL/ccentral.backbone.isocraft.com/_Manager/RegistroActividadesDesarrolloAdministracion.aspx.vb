
Imports Benavides.POSAdmin.Commons
Imports System.Text
Imports Isocraft.Web.Http

Public Class RegistroActividadesDesarrolloAdministracion
    Inherits System.Web.UI.Page

    ' Variables locales privadas
    Private intmActividadId As Integer
    Private intClasificacionId As Integer
    Private intActivaId As Integer


    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private intmGrupoUsuarioSeleccionadoId As Integer
    Private intmCompaniaId As Integer
    Private intmSucursalId As Integer
    Private intmEmpleadoId As Integer
    Private intmEmpleadoSeleccionadoId As Integer
    Private intmUsuarioId As Integer
    Private strmJefatura As String


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

        intmActividadId = GetPageParameter("hdnActividadId", -1)
        intClasificacionId = GetPageParameter("cboClasificacion", -1)
        intActivaId = GetPageParameter("cboActiva", -1)

        intmCompaniaId = 0
        intmSucursalId = 0

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
    ' Name       : intActividadId
    ' Description: Id de actividad.
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intActividadId() As Integer
        Get
            If Request.QueryString("intActividadId") <> Nothing Then

                Return CInt(Request.QueryString("intActividadId"))

            Else

                Return intmActividadId

            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strJefatura 
    ' Description: Obtiene o establece el comando actual
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strJefatura() As String
        Get
            Return strmJefatura
        End Get
        Set(ByVal strValue As String)
            strmJefatura = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : LlenarComboClasificacion
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboDireccionOperativa
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarComboClasificacion() As String

        Dim astrRecords As Array
        'Consultamos las direcciones operativas
        astrRecords = Nothing

        astrRecords = Benavides.CC.Data.clsRegistroActividadesSistemas.strObtenerClasificacionActividades(strConnectionString)

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboClasificacion", intClasificacionId, astrRecords, 0, 1, 1)
        'Return Nothing
    End Function

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
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRecordBrowserHTML() As String
        Get

            ' Declaramos e inicialziamos las variables locales
            Dim astrDataArray As Array = Nothing

            If (Request.QueryString("pager") = "true") Then
                If Not Cache("cacheUsuarios") Is Nothing Then
                    astrDataArray = CType(Cache("cacheUsuarios"), System.Array)
                End If
            End If

            If astrDataArray Is Nothing Then
                Cache.Remove("cacheUsuarios")

                astrDataArray = Benavides.CC.Data.clsRegistroActividadesSistemas.strObtenerActividadesSistemasPorRecurso(intActivaId, -1, intClasificacionId, strUsuarioNombre, strConnectionString)
            End If

            If Not astrDataArray Is Nothing AndAlso IsArray(astrDataArray) AndAlso astrDataArray.Length > 0 Then

                Cache.Add("cacheUsuarios", astrDataArray, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, Nothing)

                'Resultados en HTML
                Return strTablaConsultaUsuariosHTML(astrDataArray)

            End If

            ' Obtenemos el HTML
            Return String.Empty

        End Get
    End Property

    Public Function strTablaConsultaUsuariosHTML(ByVal objConsultaUsuarios As Array) As String

        Dim strTablaUsuariosHTML As StringBuilder
        Dim strConsultaUsuariosDetalle As String()
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim strActiva As String
        Dim strCompartida As String
        Dim strActivaId As String

        Dim imgDeshabilitarActividad As String = Nothing
        Dim imgEditarUsuario As String = String.Empty

        Dim intPage As Integer
        Dim intTotal As Integer = 50

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
        strTablaUsuariosHTML.Append("<th class='rayita' align='center' valign='top'>Actividad</th>")
        strTablaUsuariosHTML.Append("<th class='rayita' align='center' valign='top'>Clasificación</th>")
        strTablaUsuariosHTML.Append("<th class='rayita' align='center' valign='top'>Jefatura</th>")
        strTablaUsuariosHTML.Append("<th class='rayita' align='center' valign='top'>Activa</th>")
        'strTablaUsuariosHTML.Append("<th class='rayita' align='center' valign='top'>Estatus</th>")
        strTablaUsuariosHTML.Append("<th class='rayita' align='center' valign='top'>Compartida</th>")
        strTablaUsuariosHTML.Append("<th class='rayita' align='center' valign='top'>Acción</th>")
        strTablaUsuariosHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
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

            strmJefatura = strConsultaUsuariosDetalle(5).ToString()

            'Validacion del campo Activa
            If CBool(Trim(strConsultaUsuariosDetalle(7))) = False Then
                strActiva = "No"
                strActivaId = "0"
            Else
                strActiva = "Si"
                strActivaId = "1"
            End If

            'Validacion del campo Compartida
            If CBool(Trim(strConsultaUsuariosDetalle(8))) = False Then
                strCompartida = "No"
            Else
                strCompartida = "Si"
            End If

            'Botones "Ver Detalle" (Articulos/Sucursal).
            'imgDeshabilitarActividad = "<img id=" & strConsultaUsuariosDetalle(0) & " height='17' src='../static/images/imgNRDesasignar.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdDeshabilitarActividad_onclick(" & strConsultaUsuariosDetalle(0) & "," & strConsultaUsuariosDetalle(2) & ")' alt='Haga clic aquí para cambiar el estatus de la actividad'>"
            imgEditarUsuario = _
                "<img id=" & strConsultaUsuariosDetalle(0) & " height='12' src='../static/images/imgNREditar.gif' " & _
                "width='12' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' " & _
                "onClick='javascript:cmdEditarActividad_onclick(" & strConsultaUsuariosDetalle(0) & "," & strConsultaUsuariosDetalle(2) & ")' " & _
                "alt='Haga clic aquí para editar esta actividad' title='Haga clic aquí para editar esta actividad'>"

            'Si es Jefe
            If CInt(strConsultaUsuariosDetalle(10)) = 1 Then
                imgDeshabilitarActividad = _
                "<img id=" & strConsultaUsuariosDetalle(0) & " height='12' src='../static/images/imgNRDesasignar.gif' " & _
                "width='12' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' " & _
                "onClick='javascript:cmdCambiarEstatus_onclick(" & strConsultaUsuariosDetalle(0) & "," & strActivaId & ")' " & _
                "alt='Haga clic aquí para cambiar el estatus de la actividad' title='Haga clic aquí para cambiar el estatus de la actividad' >"

            Else
                imgDeshabilitarActividad = "&nbsp"
            End If


            strTablaUsuariosHTML.Append("<tr>")
            ' Actividad
            strTablaUsuariosHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaUsuariosDetalle(1)) & "</td>")
            ' Clasificación
            strTablaUsuariosHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaUsuariosDetalle(3)) & "</td>")
            ' Jefatura
            strTablaUsuariosHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaUsuariosDetalle(5)) & "</td>")
            'Activa
            strTablaUsuariosHTML.Append("<td align=center class=" & strColorRegistro & ">" & strActiva & "</td>")
            'Compartida
            strTablaUsuariosHTML.Append("<td align=center class=" & strColorRegistro & ">" & strCompartida & "</td>")
            'Accion 
            strTablaUsuariosHTML.Append("<td align=center class=" & strColorRegistro & ">" & imgDeshabilitarActividad & " " & imgEditarUsuario & "</td>")
            strTablaUsuariosHTML.Append("</tr>")
        Next

        strTablaUsuariosHTML.Append("</tr>")
        strTablaUsuariosHTML.Append("</table>")
        strTablaUsuariosHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaUsuariosHTML = strTablaUsuariosHTML.ToString

    End Function



    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", String.Empty, Request)

        Select Case strCmd
            Case "cmdActivar"

                'Metodo que guarda los cambios
                If intActivarActividad() > 0 Then
                    Call Response.Write("<script language='Javascript'>alert('La actividad se activo correctamente.');</script>")
                Else
                    Call Response.Write("<script language='Javascript'>alert('La actividad no ha podido ser activada.');</script>")
                End If

            Case "cmdDesActivar"

                'Resultado de la DesAsignacion
                If intDesActivarActividad() > 0 Then

                    Call Response.Write("<script language='Javascript'>alert('La actividad fue correctamentese desactivada.');</script>")
                Else
                    Call Response.Write("<script language='Javascript'>alert('La actividad no se pudo desactivar.');</script>")
                End If

        End Select
    End Sub

    Private Function intActivarActividad() As Integer


        Return Benavides.CC.Data.clsRegistroActividadesSistemas.intActivarActividadSistemas(intActividadId, strUsuarioNombre, strConnectionString)

        'Return Benavides.CC.Data.clsRegistroActividadesSistemas.intActivarActividadSistemas(intActividadId, "11060293", strConnectionString)


    End Function

    Private Function intDesActivarActividad() As Integer


        Return Benavides.CC.Data.clsRegistroActividadesSistemas.intDesActivarActividadSistemas(intActividadId, strUsuarioNombre, strConnectionString)
        'Return Benavides.CC.Data.clsRegistroActividadesSistemas.intDesActivarActividadSistemas(intActividadId, "11060293", strConnectionString)
    End Function


End Class

