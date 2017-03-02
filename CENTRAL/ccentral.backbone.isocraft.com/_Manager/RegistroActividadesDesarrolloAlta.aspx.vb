
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

Public Class RegistroActividadesDesarrolloAlta
    Inherits System.Web.UI.Page


    Private intmActividadId As Integer
    Private intmClasificacionId As Integer
    Private decmTiempoEstimado As Decimal
    Private strmDescripcionActividad As String
    Private intmActivo As Integer

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

        intmActividadId = GetPageParameter("hdnActividadId", 0)
        intmClasificacionId = GetPageParameter("cboClasificacion", 0)
        strmDescripcionActividad = GetPageParameter("txtActividad", String.Empty)

        If Request.Form("txtTiempoEstimado") <> String.Empty Then
            decmTiempoEstimado = CDec(Request.Form("txtTiempoEstimado"))
        Else
            decmTiempoEstimado = 0
        End If


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
    ' Name       : intClasificacionId
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intClasificacionId() As Integer
        Get
            Return intmClasificacionId
        End Get
    End Property

    '====================================================================
    ' Name       : strDescripcionActividad
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strDescripcionActividad() As String
        Get
            Return strmDescripcionActividad
        End Get
    End Property

    '====================================================================
    ' Name       : decTiempoEstimado
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property decTiempoEstimado() As Decimal
        Get
            Return decmTiempoEstimado
        End Get
    End Property

    '====================================================================
    ' Name       : intActivo
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intActivo() As Integer
        Get
            Return intmActivo
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


        If (strCmd = "cmdGuardar") Then

            'Metodo que guarda los cambios
            If intGuardarActividadesSistemas() > 0 Then
                Call Response.Write("<script language='Javascript'>alert('Se han guardado los cambios.');</script>")
            Else
                Call Response.Write("<script language='Javascript'>alert('Los cambios no se han podido guardar.');</script>")
            End If
        ElseIf (strCmd = "cmdEditar") Then

            'Funcion que edita la actividad.
            fnEditarActividad()
        End If

    End Sub

    Private Function intGuardarActividadesSistemas() As Integer

        Dim intResultado As Integer

        Dim blnActiva As Boolean
        blnActiva = False

        'If (Len(Trim(Request("chkActiva"))) = False) Then
        If (Len(Trim(Request("chkActiva"))) > 0) Then
            blnActiva = True
        End If

        Dim blnCompartida As Boolean
        blnCompartida = False

        intResultado = Benavides.CC.Data.clsRegistroActividadesSistemas.intGuardarActividadSistemas(intActividadId, strDescripcionActividad, intClasificacionId, blnActiva, decTiempoEstimado, blnCompartida, strUsuarioNombre, strConnectionString)

        'Si se guardo la actividad correctamente se asigna el id
        If intActividadId = 0 AndAlso intResultado > 0 Then
            intmActividadId = intResultado
        End If

        Return intResultado
    End Function

    Private Sub fnEditarActividad()

        If intActividadId > 0 Then

            Dim astrDataArray As Array = Nothing
            'astrDataArray = Benavides.CC.Data.clsRegistroActividadesSistemas.strObtenerActividadesSistemasPorRecurso(-1, intActividadId, intClasificacionId, strUsuarioNombre, strConnectionString)
            astrDataArray = Benavides.CC.Data.clsRegistroActividadesSistemas.strObtenerActividadesSistemasPorRecurso(-1, intActividadId, -1, strUsuarioNombre, strConnectionString)

            If IsArray(astrDataArray) AndAlso astrDataArray.Length > 0 Then

                intmClasificacionId = CInt(CType(astrDataArray.GetValue(0), Array).GetValue(2))
                strmDescripcionActividad = CStr(CType(astrDataArray.GetValue(0), Array).GetValue(1))
                decmTiempoEstimado = CDec(CType(astrDataArray.GetValue(0), Array).GetValue(6))

                If CBool(CType(astrDataArray.GetValue(0), Array).GetValue(7)) = True Then
                    intmActivo = 1
                Else
                    intmActivo = 0
                End If
            End If
        End If
    End Sub

    Public Function strTablaConsultaRecursoSistemasHTML(ByVal objConsultaDetalle As Array) As String

        Dim strTablaDetalleHTML As StringBuilder
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim imgDetalle As String = Nothing
        Dim chkbox As String = Nothing
        Dim idName As String = Nothing
        Dim strConfirmado As String
        Dim strConsultaRegistroDetalle As String()
        Dim cboMovimientoAjuste As String = String.Empty

        idName = "id=chkCodigo name=chkCodigo"
        chkbox = "<input type='checkbox' " & idName & " onclick='javascript:fnMarcarTodos()'>"

        strTablaDetalleHTML = New StringBuilder

        strTablaDetalleHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Encabezados de Tabla de Resultados
        strTablaDetalleHTML.Append("<tr class='trtitulos'>")
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

            strTablaDetalleHTML.Append("<tr>")
            ' Confirma
            strTablaDetalleHTML.Append("<td align=center class=" & strColorRegistro & ">" & chkbox & " <input type='hidden' id='hdnConfirmado" & intContador.ToString() & "' name='hdnConfirmado" & intContador.ToString() & "' value='" & strConfirmado & "'></td>")
            ' No. Empleado
            ' Empleado
            strTablaDetalleHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroDetalle(2)) & "</td>")
            strTablaDetalleHTML.Append("</tr>")
        Next

        strTablaDetalleHTML.Append("</tr>")
        strTablaDetalleHTML.Append("</table>")
        strTablaConsultaRecursoSistemasHTML = strTablaDetalleHTML.ToString



    End Function

End Class