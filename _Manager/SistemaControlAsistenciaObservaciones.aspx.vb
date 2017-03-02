Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports System.Text

Public Class SistemaControlAsistenciaObservaciones
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        strBuscaControlAsistenciaObservaciones = GetPageParameter("strBuscaControlAsistenciaObservaciones", GetPageParameter("txtBuscaControlAsistenciaObs", ""))

    End Sub

#End Region

#Region " Class Private Attributes"

    Private _strBuscaControlAsistenciaObservaciones As String
    Private _blnVisible As Boolean
    Private strmJavascriptWindowOnLoadCommands As String

#End Region

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
            Return Server.UrlEncode(GetPageName())
        End Get
    End Property

    '====================================================================
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
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
    ' Name       : strbuscaCliente
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : string
    '====================================================================
    Public Property strBuscaControlAsistenciaObservaciones() As String
        Get
            Return _strBuscaControlAsistenciaObservaciones
        End Get
        Set(ByVal strValue As String)
            _strBuscaControlAsistenciaObservaciones = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")
        End Get
    End Property

    '====================================================================
    ' Name       : strMovimientoId
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intControlAsistenciaObservacionesId() As String
        Get
            Return GetPageParameter("intControlAsistenciaObservacionesId", "")
        End Get
    End Property

    '====================================================================
    ' Name       : strMovimientoNombre
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strControlAsistenciaObservacionesNombre() As String
        Get
            Return GetPageParameter("strControlAsistenciaObservacionesNombre", "")
        End Get
    End Property

    '====================================================================
    ' Name       : blnVisible
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public Property blnVisible() As Boolean
        Get
            If _blnVisible = Nothing Then
                _blnVisible = CBool(isocraft.commons.clsWeb.strGetPageParameter("blnVisible", "0"))
            End If
            Return _blnVisible
        End Get
        Set(ByVal blnValue As Boolean)
            _blnVisible = blnValue
        End Set
    End Property

    Protected Function strObtenerControlAsistenciaObs() As String
        Dim strResultadoControlAsistenciaObs As New StringBuilder
        Dim objResultadoControlAsistenciaObs As Array
        Dim renglon As New System.Collections.SortedList
        Dim intContadorRegistros As Integer = 0
        Dim strColorRegistro As String = String.Empty
        Dim strControlAsistenciaObservacionesId As String = String.Empty
        Dim strControlAsistenciaObservacionesNombre As String = String.Empty
        Dim blnVisible As Boolean
        Dim strImagenEditar As String = "<img src='../static/images/icono_editar.gif' width='11' height='13' border='0' align='center' alt='Haga clic aquí para editar' >"

        objResultadoControlAsistenciaObs = Benavides.CC.Data.clsControlDeAsistencia. _
                                          clsControlAsistenciaObservaciones.strConsultartblControlAsistenciaObservaciones _
                                          (strBuscaControlAsistenciaObservaciones, strConnectionString)

        If IsArray(objResultadoControlAsistenciaObs) AndAlso objResultadoControlAsistenciaObs.Length > 0 Then
            strResultadoControlAsistenciaObs.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strResultadoControlAsistenciaObs.Append("<tr class='trtitulos'>")
            strResultadoControlAsistenciaObs.Append("<th class='rayita'>Id</th>")
            strResultadoControlAsistenciaObs.Append("<th class='rayita' style='text-align:left'>Nombre</th>")
            strResultadoControlAsistenciaObs.Append("<th class='rayita'>Activo</th>")
            strResultadoControlAsistenciaObs.Append("<th class='rayita'>Acciones</th>")
            strResultadoControlAsistenciaObs.Append("</tr>")

            For Each renglon In objResultadoControlAsistenciaObs
                intContadorRegistros += 1
                strControlAsistenciaObservacionesId = CStr(renglon.Item("intControlAsistenciaObservacionesId"))
                strControlAsistenciaObservacionesNombre = CStr(renglon.Item("strControlAsistenciaObservacionesNombre"))
                blnVisible = CBool(renglon.Item("blnVisible"))


                If (intContadorRegistros Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If

                strResultadoControlAsistenciaObs.Append("<tr>")

                strResultadoControlAsistenciaObs.Append("<td align=center class=" & strColorRegistro & ">" & strControlAsistenciaObservacionesId & "</td>")
                strResultadoControlAsistenciaObs.Append("<td class=" & strColorRegistro & ">" & strControlAsistenciaObservacionesNombre & "</td>")
                strResultadoControlAsistenciaObs.Append("<td class=" & strColorRegistro & " align=center>" & "<input class=fieldborderless id=chkActivo" & _
                                            intContadorRegistros.ToString() & " type=checkbox name=chkActivo" & intContadorRegistros.ToString() & " disabled=true " & _
                                             CStr(blnVisible).Replace("True", "checked").Replace("False", "") & "></td>")

                strResultadoControlAsistenciaObs.Append("<td align=center class=" & strColorRegistro & "" & ">" & _
                                                       "<a href='SistemaControlAsistenciaObservaciones.aspx?strCmd=Actualizar" & _
                                                       "&intControlAsistenciaObservacionesId=" & strControlAsistenciaObservacionesId & _
                                                       "&strControlAsistenciaObservacionesNombre=" & strControlAsistenciaObservacionesNombre & _
                                                       "&blnVisible=" & blnVisible & "'>" & _
                                                        strImagenEditar & "</a></td>")

                strResultadoControlAsistenciaObs.Append("</tr>")
            Next

            strResultadoControlAsistenciaObs.Append("</table>")

        End If

        Return strResultadoControlAsistenciaObs.ToString()
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso. _
            blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Or _
             Not intTipoUsuarioId = 1 Then
            Call Response.Redirect("../Default.aspx")
        End If

        Try
            Select Case strCmd
                Case "Nuevo"
                    GuardarAsistenciaObservaciones()
                Case "Editar"
                    ActualizarAsistenciaObservaciones()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GuardarAsistenciaObservaciones()
        Dim intResultado As Integer
        intResultado = Benavides.CC.Data.clsControlDeAsistencia.clsControlAsistenciaObservaciones. _
                                   intGuardartblControlAsistenciaObservaciones(strControlAsistenciaObservacionesNombre, _
                                                                               blnVisible, _
                                                                               strUsuarioNombre, _
                                                                               strConnectionString)

        Response.Redirect("SistemaControlAsistenciaObservaciones.aspx")
    End Sub

    Private Sub ActualizarAsistenciaObservaciones()
        Dim intResultado As Integer
        intResultado = Benavides.CC.Data.clsControlDeAsistencia.clsControlAsistenciaObservaciones. _
                        intActualizartblControlAsistenciaObservaciones(CInt(intControlAsistenciaObservacionesId), _
                                                                        strControlAsistenciaObservacionesNombre, _
                                                                        blnVisible, _
                                                                        strUsuarioNombre, _
                                                                        strConnectionString)

        Response.Redirect("SistemaControlAsistenciaObservaciones.aspx")
    End Sub

End Class