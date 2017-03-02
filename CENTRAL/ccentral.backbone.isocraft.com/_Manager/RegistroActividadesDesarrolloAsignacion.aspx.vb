
Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Benavides.POSAdmin.Commons.clsCommons.clsMSMQ
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports Isocraft.Web.Javascript
Imports System.Web.Caching

Public Class RegistroActividadesDesarrolloAsignacionAdmin
    Inherits System.Web.UI.Page

    Private intmActividadId As Integer
    Private intClasificacionId As Integer

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

    End Sub

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
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", String.Empty, Request, Server)
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
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request)
        End Get
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

        'Consultamos las direcciones operativas
        Dim astrRecords As Array
        astrRecords = Nothing

        astrRecords = Benavides.CC.Data.clsRegistroActividadesSistemas.strObtenerClasificacionActividades(strConnectionString)

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboClasificacion", intClasificacionId, astrRecords, 0, 1, 1)
        'Return Nothing
    End Function

    '====================================================================
    ' Name       : LlenarComboActividad
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboDireccionOperativa
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarComboActividad() As String

        If strCmd = "cmdConsultarActividad" Then


            'Consultamos las direcciones operativas
            Dim astrRecords As Array
            astrRecords = Nothing

            astrRecords = Benavides.CC.Data.clsRegistroActividadesSistemas.strObtenerActividadesSistemasParaAsignacion(1, -1, intClasificacionId, strUsuarioNombre, strConnectionString)

            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboActividad", intActividadId, astrRecords, 0, 1, 1)

        Else
            Return String.Empty
        End If
    End Function

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
    ' Name       : strCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return GetPageParameter("strCmd", String.Empty)
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Const strComitasDobles As String = """"

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If


        If (strCmd = "cmdAsignar") Then

            'Metodo que guarda los cambios
            If intAsignarActividad() > 0 Then
                Call Response.Write("<script language='Javascript'>alert('La actividad se asigno correctamente.');</script>")
            Else
                Call Response.Write("<script language='Javascript'>alert('No se pudo asignar la actividad.');</script>")
            End If


        ElseIf (strCmd = "cmdDesAsignar") Then

            'Resultado de la DesAsignacion
            If intDesAsignarActividad() > 0 Then

                Call Response.Write("<script language='Javascript'>alert('La actividad se desasigno correctamente.');</script>")
            Else
                Call Response.Write("<script language='Javascript'>alert('No se pudo desasignar la actividad.');</script>")
            End If
        End If

    End Sub

    Private Function intAsignarActividad() As Integer


        Return Benavides.CC.Data.clsRegistroActividadesSistemas.intAsignarActividadSistemas(intActividadId, CInt(strUsuarioNombre), strUsuarioNombre, strConnectionString)

    End Function

    Private Function intDesAsignarActividad() As Integer


        Return Benavides.CC.Data.clsRegistroActividadesSistemas.intDesAsignarActividadSistemas(intActividadId, CInt(strUsuarioNombre), strUsuarioNombre, strConnectionString)
    End Function

    Public Function strTablaConsultaRecursoSistemasHTML(ByVal objConsultaDetalle As Array) As String

        Dim strTablaDetalleHTML As StringBuilder
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim imgDetalle As String = Nothing
        Dim chkbox As String = Nothing
        Dim idName As String = Nothing
        Dim strConfirmado As String
        Dim strConsultaRegistroDetalle As String()
        Dim hdnAsignado As String = Nothing
        Dim hdnEmpleadoId As String = Nothing

        idName = "id=chkCodigo name=chkCodigo"
        chkbox = "<input type='checkbox' " & idName & " onclick='javascript:fnMarcarTodos()'>"

        strTablaDetalleHTML = New StringBuilder

        strTablaDetalleHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Encabezados de Tabla de Resultados
        strTablaDetalleHTML.Append("<tr class='trtitulos'>")
        'strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'> Seleccionar <br>" & chkbox & "Todos</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'> Seleccionar</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Empleado</th>")

        strTablaDetalleHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For Each strConsultaRegistroDetalle In objConsultaDetalle
            intContador += 1


            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            idName = "id=chkCodigo" & intContador.ToString() & " " & "name=chkCodigo" & intContador.ToString()
            chkbox = "<input type='checkbox'" & idName & "/>"

            hdnAsignado = "<input type='hidden' id='hdnAsignado" & intContador.ToString() & "' name='hdnAsignado" & intContador.ToString() & "' value='" & strConfirmado & "'>"

            strTablaDetalleHTML.Append("<tr>")
            ' Confirma
            strTablaDetalleHTML.Append("<td align=center class=" & strColorRegistro & ">" & chkbox & " </td>")
            ' Empleado
            strTablaDetalleHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroDetalle(2)) & "</td>")
            strTablaDetalleHTML.Append("</tr>")
        Next

        strTablaDetalleHTML.Append("</tr>")
        strTablaDetalleHTML.Append("</table>")
        strTablaConsultaRecursoSistemasHTML = strTablaDetalleHTML.ToString

    End Function

    '====================================================================
    ' Name       : strTablaConsultaActividadesRecursos
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strTablaConsultaActividadesRecursos() As String

        Dim astrDataArray As Array = Nothing

        If (Request.QueryString("pager") = "true") Then
            If Not Cache("cacheActividadesRecurso") Is Nothing Then
                astrDataArray = CType(Cache("cacheActividadesRecurso"), System.Array)
            End If
        End If

        If astrDataArray Is Nothing Then
            Cache.Remove("cacheActividadesRecurso")

            astrDataArray = Benavides.CC.Data.clsRegistroActividadesSistemas.strObtenerActividadesSistemasParaAsignarRecurso(1, -1, intClasificacionId, strUsuarioNombre, strConnectionString)

        End If


        Dim strResult As New StringBuilder()
        If Not astrDataArray Is Nothing AndAlso IsArray(astrDataArray) AndAlso astrDataArray.Length > 0 Then

            Cache.Add("cacheActividadesRecurso", astrDataArray, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, Nothing)

            'Resultados en HTML
            strResult.Append(strTablaConsultaUsuariosHTML(astrDataArray))

        Else
            'Tabla vacia sin resultados de consulta
            Call Response.Write("<script language='Javascript'>alert('No hay actividades');</script>")
        End If

        strResult.Append("<script language=""javascript"" type=""text/javascript"">")
        strResult.Append("parent.document.getElementById('tblReporte').innerHTML = document.getElementById('divConsultaActividadesRecurso').innerHTML;")
        strResult.Append("</script>")

        Return strResult.ToString()

    End Function

    Public Function strTablaConsultaUsuariosHTML(ByVal objConsultaUsuarios As Array) As String
        Dim strTablaUsuariosHTML As StringBuilder
        Dim strConsultaUsuariosDetalle As String()
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim strActiva As String
        Dim strCompartida As String
        Dim strAsignada As String
        Dim strCmdEstatus As String
        Dim strmJefatura As String

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
        strTablaUsuariosHTML.Append("<th class='rayita' align='center' valign='top'>Asignada</th>")
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
            Else
                strActiva = "Si"
            End If

            'Validacion del campo Compartida
            If CBool(Trim(strConsultaUsuariosDetalle(8))) = False Then
                strCompartida = "No"
            Else
                strCompartida = "Si"
            End If



            'Validacion del campo Asignada
            If CBool(Trim(strConsultaUsuariosDetalle(11))) = False Then
                strAsignada = "No"
                'strCmdEstatus = "cmdAsignar"
                strCmdEstatus = "0"
            Else
                strAsignada = "Si"
                'strCmdEstatus = "cmdDesAsignar"
                strCmdEstatus = "1"
            End If

            imgDeshabilitarActividad = _
                "<img id=" & strConsultaUsuariosDetalle(0) & " height='12' " & _
                "src='../static/images/imgNRDesasignar.gif' width='12' align='absMiddle' border='0' " & _
                "style='cursor:pointer;margin:2px;' onClick='javascript:cmdCambiarAsignacion_onclick(" & strConsultaUsuariosDetalle(0) & ", " & strCmdEstatus & ")' " & _
                "alt='Haga clic aquí para cambiar el estatus de la asignación' title='Haga clic aquí para cambiar el estatus de la asignación'>"


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
            'Asignada
            strTablaUsuariosHTML.Append("<td align=center class=" & strColorRegistro & ">" & strAsignada & "</td>")
            'Accion 
            strTablaUsuariosHTML.Append("<td align=center class=" & strColorRegistro & ">" & imgDeshabilitarActividad & " " & imgEditarUsuario & "</td>")
            strTablaUsuariosHTML.Append("</tr>")
        Next

        strTablaUsuariosHTML.Append("</tr>")
        strTablaUsuariosHTML.Append("</table>")
        strTablaUsuariosHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaUsuariosHTML = strTablaUsuariosHTML.ToString

    End Function

End Class