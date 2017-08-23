Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Benavides.POSAdmin.Commons.clsCommons.clsMSMQ
Imports Isocraft.Web.Convert
Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports System.Configuration
Imports System.IO
Imports System.Text
Imports System.Web.Caching

Public Class ControlAsistenciaReporte
    Inherits System.Web.UI.Page

    Private Enum TipoUsuario
        Administrador = 1
        CoordinadorRH = 2
        SupervisorMedico = 3
    End Enum

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
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
    Public ReadOnly Property intTipoUsuarioIdParametro() As Integer
        Get
            Return CInt(Request.Form("cboTipoUsuario"))
        End Get
    End Property

    Public ReadOnly Property intTipoUsuarioId() As Integer
        Get
            Return Benavides.CC.Data.clsControlDeAsistencia.intObtenerTipoUsuarioId(strUsuarioNombre, strConnectionString)
        End Get
    End Property

    '====================================================================
    ' Name       : LlenarControlCoordinadoresRH
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboCoordinadoresRH
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function LlenarControlCoordinadoresRH() As String
        Dim strResultado As String = String.Empty
        Dim opcionTodos As String = String.Empty
        Dim strEmpleados As String = String.Empty
        Dim intEmpleadoId As Integer

        If intTipoUsuarioId > 0 Then
            opcionTodos = "document.forms[0].elements['cboCoordinadoresRH'].options[1] = new Option('» Todos «', '-1');"

            strEmpleados = (CreateJavascriptComboBoxOptions("cboCoordinadoresRH", _
                                                            CStr(intEmpleadoId), _
                                                            Benavides.CC.Data.clsControlDeAsistencia.strBuscarCoordinadoresRH(intTipoUsuarioIdParametro, strConnectionString), _
                                                           "intEmpleadoId", _
                                                           "strCoordinadorNombre", _
                                                            2))

            strResultado = String.Format("{0}{1}", opcionTodos, strEmpleados)
        End If

        Return strResultado
    End Function

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
    ' Name       : strFirstDayOfMonth
    ' Description: Regresa el primer dia del mes actual
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFirstDayOfMonth() As String
        Get
            If IsNothing(Request.Form("dtmFechaIni")) Then
                Return New Date(Date.Today.Year, Date.Today.Month, 1).ToString("dd/MM/yyyy")
            Else
                Return Request.Form("dtmFechaIni")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intCoordinadorRHId
    ' Description:
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intCoordinadorRHId() As Integer
        Get
            If Not IsNothing(Request.Form("cboCoordinadoresRH")) Then
                Return CInt(Request.Form("cboCoordinadoresRH"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intEstatusId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intEstatusId() As Integer
        Get
            If Not IsNothing(Request.Form("cboEstatus")) Then
                Return CInt(Request.Form("cboEstatus"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intTipoNominaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTipoNominaId() As Integer
        Get
            If Not IsNothing(Request.Form("cboTipoNomina")) Then
                Return CInt(Request.Form("cboTipoNomina"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaInicio
    ' Description: Fecha de inicio a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaInicio() As Date
        Get
            Dim f As String = Request.Form("dtmFechaIni")
            If Not IsNothing(f) Then
                Dim fp As String() = f.Split("/".ToCharArray())

                Return New Date(CInt(fp(2)), CInt(fp(1)), CInt(fp(0)))
            Else
                Return CDate("01/01/1900")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaFin
    ' Description: Fecha de fin  a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaFin() As Date
        Get
            Dim f As String = Request.Form("dtmFechaFin")
            If Not IsNothing(f) Then
                Dim fp As String() = f.Split("/".ToCharArray())

                Return New Date(CInt(fp(2)), CInt(fp(1)), CInt(fp(0)))
            Else
                Return CDate("01/01/1900")
            End If
        End Get
    End Property

    Public ReadOnly Property strFechaInicio() As String
        Get
            Return dtmFechaInicio.ToString("dd/MM/yyyy")
        End Get
    End Property

    Public ReadOnly Property strFechaFin() As String
        Get
            Return dtmFechaFin.ToString("dd/MM/yyyy")
        End Get
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

        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Or _
            Not intTipoUsuarioId = TipoUsuario.Administrador Then
            Call Response.Redirect("../Default.aspx")
        End If
    End Sub

    Public Function strTablaConsultaReporte() As String
        Dim objResultadoConsulta As System.Array = Nothing
        Dim resultadoConsulta As String = String.Empty
        Dim strmRecordBrowserHTML As String = String.Empty
        Dim strResultado As New StringBuilder()

        If (strCmd = "cmdConsultar") Then

            If objResultadoConsulta Is Nothing Then

                objResultadoConsulta = clsControlDeAsistencia.strObtenerReporteControlAsistencia(intCoordinadorRHId, _
                                                                                                 intEstatusId, _
                                                                                                 intTipoNominaId, _
                                                                                                 dtmFechaInicio, _
                                                                                                 dtmFechaFin, _
                                                                                                 intTipoUsuarioIdParametro, _
                                                                                                 strConnectionString)
            End If

            If Not objResultadoConsulta Is Nothing AndAlso IsArray(objResultadoConsulta) AndAlso objResultadoConsulta.Length > 0 Then
                'Detalle
                strResultado.Append(strTablaConsultaReporteHTML(objResultadoConsulta))
            Else
                'Tabla vacia sin resultados de consulta
                Call Response.Write("<script language='Javascript'>alert('Busqueda sin resultados');</script>")
            End If

            strResultado.Append("<script language=""javascript"" type=""text/javascript"">")
            strResultado.Append("parent.document.getElementById('tblReporte').innerHTML = document.getElementById('divConsultaReporte').innerHTML;")
            strResultado.Append("</script>")

            Return strResultado.ToString()
        End If

        Return String.Empty
    End Function

    Public Function strTablaConsultaReporteHTML(ByVal objConsultaReporte As Array) As String
        Dim strTablaReporteHTML As StringBuilder
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim strConsultaReporte As String() = Nothing
        Dim intValorTipoUsuario As String = String.Empty

        strTablaReporteHTML = New StringBuilder

        If intTipoUsuarioIdParametro = TipoUsuario.CoordinadorRH Then
            intValorTipoUsuario = "Coordinador RH"
        ElseIf intTipoUsuarioIdParametro = TipoUsuario.SupervisorMedico Then
            intValorTipoUsuario = "Supervisor Médico"
        End If

        strTablaReporteHTML.Append("<table id='tblReporteAsistencia' width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strTablaReporteHTML.Append("<tr class='trtitulos'>")
        strTablaReporteHTML.AppendFormat("<th class='rayita' align='center' valign='top'>{0}</th>", intValorTipoUsuario)
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Centro Logístico</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Sucursal</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Movimiento</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Descripción</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Movimientos</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Ajustes</th>")

        strTablaReporteHTML.Append("</tr>")

        For intContador = 0 To objConsultaReporte.Length - 1

            strConsultaReporte = CType(objConsultaReporte.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strTablaReporteHTML.Append("<tr>")
            ' Coordinador RH
            strTablaReporteHTML.Append("<td align=center class=" & "tdceleste" & ">" & clsCommons.strFormatearDescripcion(strConsultaReporte(1)) & "</td>")
            ' Centro Logistico 1
            strTablaReporteHTML.Append("<td id=Division" & intContador & " align=center class=" & "tdceleste" & ">" & strConsultaReporte(2) & "</td>")
            ' Sucursal
            strTablaReporteHTML.Append("<td align=left class=" & "tdceleste" & ">" & clsCommons.strFormatearDescripcion(strConsultaReporte(3)) & "</td>")
            ' Movimiento
            strTablaReporteHTML.Append("<td align=center class=" & "tdceleste" & ">" & strConsultaReporte(4).ToString() & "</td>")
            ' Descripcion
            strTablaReporteHTML.Append("<td align=center class=" & "tdceleste" & ">" & clsCommons.strFormatearDescripcion(strConsultaReporte(5)) & "</td>")
            ' Movimientos Originales
            strTablaReporteHTML.Append("<td align=center class=" & "tdceleste" & ">" & strConsultaReporte(6).ToString() & "</td>")
            ' Ajustes
            strTablaReporteHTML.Append("<td align=center class=" & "tdceleste" & ">" & strConsultaReporte(7).ToString() & "</td>")

            strTablaReporteHTML.Append("</tr>")
        Next

        strTablaReporteHTML.Append("</tr>")
        strTablaReporteHTML.Append("</table>")
        strTablaConsultaReporteHTML = strTablaReporteHTML.ToString()
    End Function

End Class