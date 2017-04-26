Imports Benavides.CC.Data
Imports Benavides.POSAdmin.Commons
Imports System.Collections
Imports System.Text

Public Class ControlAsistenciaAdministracionDeSupervisoresMedico
    Inherits PaginaBase

    Private intmEmpleadoId As Integer
    Private strmCommand As String
    Private intmGrupoUsuarioSeleccionadoId As Integer
    Private intmCompaniaId As Integer
    Private intmSucursalId As Integer
    Private intmEmpleadoSeleccionadoId As Integer
    Private intmUsuarioId As Integer

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
    End Sub

    '====================================================================
    ' Name       : strCmd2 
    ' Description: Obtiene o establece el comando actual
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strCmd2() As String
        Get
            Return strmCommand
        End Get
        Set(ByVal strValue As String)
            strmCommand = strValue
        End Set
    End Property

    Public Property intEmpleadoId() As Integer
        Get
            Return intmEmpleadoId
        End Get
        Set(ByVal intValue As Integer)
            intmEmpleadoId = intValue
        End Set
    End Property

    Public ReadOnly Property intGrupoUsuarioSeleccionadoId() As Integer
        Get
            If Not (Request.Form("hdnGrupoControlAsistencia") = Nothing) Then
                Return CInt(Request.Form("hdnGrupoControlAsistencia"))
            Else
                Dim objArray As Array = Nothing
                Dim intGrupoId As String() = Nothing

                Dim intSeleccionadoId As Integer

                objArray = Benavides.CC.Data.clsControlDeAsistencia.strBuscarGrupoControlAsistencia(strConnectionString)

                If IsArray(objArray) AndAlso objArray.Length > 0 Then

                    intGrupoId = CType(objArray.GetValue(0), String())
                    intSeleccionadoId = CInt(intGrupoId(0))
                Else
                    intSeleccionadoId = 0
                End If

                Return intSeleccionadoId
            End If
        End Get
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

    Protected ReadOnly Property strRecordBrowserHTML() As String
        Get
            Dim astrDataArray As Array = Nothing

            If (Request.QueryString("pager") = "true") Then
                If Not Cache("cacheUsuarios") Is Nothing Then
                    astrDataArray = CType(Cache("cacheUsuarios"), System.Array)
                End If
            End If

            If astrDataArray Is Nothing Then
                Cache.Remove("cacheUsuarios")
                astrDataArray = clsControlDeAsistencia. _
                               strBuscarSupervisorMedico(intGrupoUsuarioSeleccionadoId, intEmpleadoId, strConnectionString)
            End If

            If Not astrDataArray Is Nothing AndAlso IsArray(astrDataArray) AndAlso astrDataArray.Length > 0 Then
                Cache.Add("cacheUsuarios", astrDataArray, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, Nothing)
                'Resultados en HTML
                Return strTablaConsultaUsuariosHTML(astrDataArray)
            End If

            Return String.Empty
        End Get
    End Property

    Private Function strTablaConsultaUsuariosHTML(ByVal objConsultaUsuarios As Array) As String
        Dim strTablaUsuariosHTML As New StringBuilder
        Dim strConsultaUsuariosDetalle As String()
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim imgDeshabilitarUsuario As String = Nothing
        Dim imgEditarUsuario As String = String.Empty

        strTablaUsuariosHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Encabezados de Tabla de Resultados
        strTablaUsuariosHTML.Append("<tr class='trtitulos'>")
        strTablaUsuariosHTML.Append("<th class='rayita' align='left' valign='top'>Usuario</th>")
        strTablaUsuariosHTML.Append("<th class='rayita' align='left' valign='top'>Supervisor Médico</th>")
        strTablaUsuariosHTML.Append("<th class='rayita' align='left' valign='top'>Estatus</th>")
        strTablaUsuariosHTML.Append("<th class='rayita' align='center' valign='top'>Acción</th>")
        strTablaUsuariosHTML.Append("</tr>")

        For intContador = 0 To objConsultaUsuarios.Length - 1
            strConsultaUsuariosDetalle = CType(objConsultaUsuarios.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            imgDeshabilitarUsuario = "<img id=" & strConsultaUsuariosDetalle(0) & _
                                     " height='17' src='../static/images/imgNRDesasignar.gif' width='17' align='absMiddle' border='0'" & _
                                     " style='cursor:pointer;margin:2px;' title='Haga clic aquí para cambiar el estatus del usuario' " & _
                                     "onClick='javascript:cmdDeshabilitarUsuario_onclick(" & strConsultaUsuariosDetalle(0) & "," & strConsultaUsuariosDetalle(2) & ")' alt='Haga clic aquí para cambiar el estatus del usuario'>"

            imgEditarUsuario = "<img id=" & strConsultaUsuariosDetalle(0) & _
                               " height='17' src='../static/images/imgNREditar.gif' width='17' align='absMiddle' border='0'" & _
                               " style='cursor:pointer;margin:2px;' title='Haga clic aquí para editar este usuario' " & _
                               "onClick='javascript:cmdEditarUsuario_onclick(" & strConsultaUsuariosDetalle(0) & "," & strConsultaUsuariosDetalle(2) & ")' alt='Haga clic aquí para editar este usuario'>"

            strTablaUsuariosHTML.Append("<tr>")
            strTablaUsuariosHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaUsuariosDetalle(0)) & "</td>")
            strTablaUsuariosHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaUsuariosDetalle(1)) & "</td>")
            strTablaUsuariosHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaUsuariosDetalle(4)) & "</td>")
            strTablaUsuariosHTML.Append("<td align=center class=" & strColorRegistro & ">" & imgDeshabilitarUsuario & " " & imgEditarUsuario & "</td>")
            strTablaUsuariosHTML.Append("</tr>")
        Next

        strTablaUsuariosHTML.Append("</table>")

        Return strTablaUsuariosHTML.ToString()
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        strCmd2 = isocraft.commons.clsWeb.strGetPageParameter("strCmd2", String.Empty, Request)

        Select Case strCmd2
            Case "Agregar"
                'Call Response.Redirect("SistemaAgregarUsuario.aspx?strCmd=Agregar")
                'Call Response.Redirect("ControlAsistenciaAdministracionDeUsuariosAgregar.aspx?strCmd=Agregar")
                'Call Response.End()

            Case "Editar"
                'Call Response.Redirect("ControlAsistenciaAdministracionDeUsuariosAgregar.aspx?strCmd=Editar&intEmpleadoId=" & intEmpleadoSeleccionadoId.ToString & "&intUsuarioId=" & intUsuarioId.ToString)
                'Call Response.End()

            Case "Desasignar" '(Deshabilita usuario)
                ' Verificamos que exista información
                If intEmpleadoSeleccionadoId > 0 AndAlso intUsuarioId > 0 Then
                    Call clsUsuario.intActualizarEstatus(intEmpleadoSeleccionadoId, intUsuarioId, strUsuarioNombre, strConnectionString)
                End If
        End Select
    End Sub



End Class