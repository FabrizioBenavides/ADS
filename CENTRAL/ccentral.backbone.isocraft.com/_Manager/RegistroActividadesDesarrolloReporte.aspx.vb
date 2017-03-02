
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

Public Class RegistroActividadesDesarrolloReporte
    Inherits System.Web.UI.Page

    Dim strmTotalDePartidas As Integer

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
    ' Name       : dtmFechaInicio
    ' Description: Fecha de inicio a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaInicio() As Date
        Get

            Dim dtmFechaConsulta As Date
            Dim strFechaRegresar As String
            Dim fp As String()
            Dim intDayDiff As Integer

            If strCmd = "cmdConsultar" Then

                '---------------------------------------------------------------------------------------------
                'Fecha de calendario (ingresada por usuario en control) (se ejecuta con el boton "Consultar".)
                '---------------------------------------------------------------------------------------------

                Dim strFechaCalendario As String = Request.Form("dtmFechaIni")
                fp = strFechaCalendario.Split("/".ToCharArray())

                dtmFechaConsulta = New Date(CInt(fp(2)), CInt(fp(1)), CInt(fp(0)))

            ElseIf strCmd = "cmdRegresar" Or strCmd = "cmdAvanzar" Or strCmd = "cmdGuardar" Or strCmd = "cmdConsultarComentarios" Then

                If Not IsNothing(Request.Form("hdnFechaInicio")) Then

                    '----------------------------
                    '01. Ultima fecha de consulta
                    '----------------------------

                    strFechaRegresar = Request.Form("hdnFechaInicio")
                    fp = strFechaRegresar.Split("/".ToCharArray())

                    dtmFechaConsulta = New Date(CInt(fp(2)), CInt(fp(1)), CInt(fp(0)))

                    '-------------------------------------
                    '02. (se le suma o se le resta 7 dias)
                    '-------------------------------------

                    If strCmd = "cmdRegresar" Then
                        dtmFechaConsulta = dtmFechaConsulta.AddDays(-7)
                    ElseIf strCmd = "cmdAvanzar" Then
                        dtmFechaConsulta = dtmFechaConsulta.AddDays(7)
                    End If

                End If

            Else

                '01. Cuando carga por primera vez.
                '02. Si no hay fecha debe de buscarse en variable.
                '03. Si no hay fecha en calendario la fecha es la de hoy

                dtmFechaConsulta = Date.Today

            End If


            '-----------------------------------------------------------------------
            'Se obtiene la fecha de inicio (si no es lunes busca el lunes anterior)
            '-----------------------------------------------------------------------

            If dtmFechaConsulta.DayOfWeek <> 1 Then

                If dtmFechaConsulta.DayOfWeek = 0 Then
                    dtmFechaConsulta = dtmFechaConsulta.AddDays(-6)
                Else
                    intDayDiff = dtmFechaConsulta.DayOfWeek - DayOfWeek.Monday
                    dtmFechaConsulta = dtmFechaConsulta.AddDays(-intDayDiff)
                End If
            End If

                Return dtmFechaConsulta
        End Get
    End Property

    Public ReadOnly Property dtmFechaPrueba() As String
        Get

            Return (Today.DayOfWeek - DayOfWeek.Monday).ToString
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
            Return dtmFechaInicio.AddDays(6)
        End Get
    End Property

    '====================================================================
    ' Name       : strTotalDePartidas
    ' Description: Numero de sucursales por "Asignar".
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strTotalDePartidas() As Integer
        Get
            Return strmTotalDePartidas
        End Get
        Set(ByVal strValue As Integer)
            strmTotalDePartidas = strValue
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
            intGuardarActividadesSistemas()

            Call Response.Write("<script language='Javascript'>alert('Se han guardado los cambios.');</script>")

        End If


        ''' ''''''''''''    ''''''''''''''
        ''' NOTA()
        ''' SE ELIMINA EL METODO DE GUARDAR COMENTARIOS POR SEPARADO PARA DEJAR SOLO UN BOTON YA QUE SISTEMAS SE CONFUNDE CON 2 BOTONES!!
        ''' EL SISTEMA EN PRD ES LENTO Y NO ESPERAN A QUE "PROCESE" LA INFORMACION, LE PICAN VARIAS VECES A LOS BOTONES SIN ESPERAR RESULTADOS DEL SERVIDOR!!
        ''' 

        'If (strCmd = "cmdGuardarComentarios") Then

        '    'Metodo que guarda los comentarios por actividad
        '    strGuardarcomentarios()
        'End If

    End Sub

    Public Function strTablaConsultaReporte() As String

        Dim objArray As System.Array = Nothing
        Dim resultadoConsulta As String = String.Empty
        Dim strmRecordBrowserHTML As String = String.Empty

        If Not (strCmd = "cmdGuardar") AndAlso Not (strCmd = "cmdConsultarComentarios") Then

            'Registro de Actividades de Sistemas
            If Not (dtmFechaInicio.Year < 2010) Or Not (dtmFechaFin.Year < 2010) Then



                If objArray Is Nothing Then
                    Cache.Remove("cacheReporte")
                    objArray = Benavides.CC.Data.clsRegistroActividadesSistemas.strObtenerRegistroActividadesSistemas(CInt(strUsuarioNombre), -1, dtmFechaInicio, dtmFechaFin, strConnectionString)

                End If

                Dim strResult As New StringBuilder()
                If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then

                    'Detalle
                    strResult.Append(strTablaConsultaActividadesHTML(objArray))

                Else
                    'Tabla vacia sin resultados de consulta
                    Call Response.Write("<script language='Javascript'>alert('Busqueda sin resultados');</script>")
                End If

                strResult.Append("<script language=""javascript"" type=""text/javascript"">")
                strResult.Append("parent.document.getElementById('tblReporte').innerHTML = document.getElementById('divConsultaReporte').innerHTML;")
                strResult.Append("</script>")

                Return strResult.ToString()
            End If
        End If

        Return String.Empty
    End Function

    Public Function strConsultarComentarios() As String

        If strCmd = "cmdConsultarComentarios" Then

            Dim intRegistroActividadId As Integer
            Dim intActividadId As Integer
            Dim intDiaId As Integer

            Dim intResultado As Integer
            Dim strComentarios As String = String.Empty

            If Not IsNothing(Request.Form("hdnComentarioId")) Then

                intRegistroActividadId = CInt(Request.Form("hdnComentarioId"))

                intActividadId = CInt(Request.Form("hdnActividadComentarioId"))
                intDiaId = CInt(Request.Form("hdnIntDiaId"))

                'document.getElementById('txtComentarios').value = '';
                'document.getElementById('hdnComentarioId').value = intRegistroActividadId;
                'document.getElementById('hdnIntDiaId').value = intDiaId;


                strComentarios = Benavides.CC.Data.clsRegistroActividadesSistemas.strObtenerComentarioActividadesSistemas(intRegistroActividadId, intActividadId, CInt(strUsuarioNombre), intDiaId, fnFechaDiaria(intDiaId), strConnectionString)

                Dim strResult As New StringBuilder()

                strResult.Append("<script language=""javascript"" type=""text/javascript"">")
                strResult.Append("parent.document.getElementById('txtComentarios').value = '" & strComentarios & "';")
                strResult.Append("parent.document.getElementById('hdnComentarioId').value = " & intRegistroActividadId.ToString & ";")
                strResult.Append("parent.document.getElementById('hdnIntDiaId').value = " & Request.Form("hdnIntDiaId") & ";")
                strResult.Append("parent.document.getElementById('hdnActividadComentarioId').value = " & Request.Form("hdnActividadComentarioId") & ";")

                'strResult.Append("parent.parent.document.getElementById('txtComentarios').value = '" & strComentarios & "';")
                'strResult.Append("parent.parent.document.getElementById('hdnComentarioId').value = " & intRegistroActividadId.ToString & ";")
                'strResult.Append("parent.parent.document.getElementById('hdnIntDiaId').value = " & Request.Form("hdnIntDiaId") & ";")
                'strResult.Append("parent.parent.document.getElementById('hdnActividadComentarioId').value = " & Request.Form("hdnActividadComentarioId") & ";")

                strResult.Append("</script>")

                Return strResult.ToString()
            End If
        End If

        Return String.Empty

    End Function

    Public Sub intGuardarActividadesSistemas()

        Dim i, total As Integer
        total = CInt(Request.Form("hdnTotalDeActividades")) - 1

        'Id de Actividad
        Dim hdnActividad As String

        'Variables de valor original
        Dim hdnLunes As String
        Dim hdnMartes As String
        Dim hdnMiercoles As String
        Dim hdnJueves As String
        Dim hdnViernes As String
        Dim hdnSabado As String
        Dim hdnDomingo As String

        'Variables de valor actual
        Dim txtLunes As String
        Dim txtMartes As String
        Dim txtMiercoles As String
        Dim txtJueves As String
        Dim txtViernes As String
        Dim txtSabado As String
        Dim txtDomingo As String

        'Variables con valor de Id's
        Dim hdnLunesId As String
        Dim hdnMartesId As String
        Dim hdnMiercolesId As String
        Dim hdnJuevesID As String
        Dim hdnViernesId As String
        Dim hdnSabadoId As String
        Dim hdnDomingoId As String


        'Datos de Comentarios
        Dim strComentarios As String = String.Empty

        For i = 0 To total

            'Id Actividad
            hdnActividad = (Request.Form("hdnActividad" & i.ToString))

            hdnLunes = (Request.Form("hdnLunes" & i.ToString))
            hdnMartes = Request.Form("hdnMartes" & i.ToString)
            hdnMiercoles = Request.Form("hdnMiercoles" & i.ToString)
            hdnJueves = Request.Form("hdnJueves" & i.ToString)
            hdnViernes = Request.Form("hdnViernes" & i.ToString)
            hdnSabado = Request.Form("hdnSabado" & i.ToString)
            hdnDomingo = Request.Form("hdnDomingo" & i.ToString)

            'Variables de valor actual
            txtLunes = Request.Form("txtLunes" & i.ToString)
            txtMartes = Request.Form("txtMartes" & i.ToString)
            txtMiercoles = Request.Form("txtMiercoles" & i.ToString)
            txtJueves = Request.Form("txtJueves" & i.ToString)
            txtViernes = Request.Form("txtViernes" & i.ToString)
            txtSabado = Request.Form("txtSabado" & i.ToString)
            txtDomingo = Request.Form("txtDomingo" & i.ToString)

            'Variables con valor de Id's
            hdnLunesId = Request.Form("hdnLunesId" & i.ToString)
            hdnMartesId = Request.Form("hdnMartesId" & i.ToString)
            hdnMiercolesId = Request.Form("hdnMiercolesId" & i.ToString)
            hdnJuevesID = Request.Form("hdnJuevesID" & i.ToString)
            hdnViernesId = Request.Form("hdnViernesId" & i.ToString)
            hdnSabadoId = Request.Form("hdnSabadoId" & i.ToString)
            hdnDomingoId = Request.Form("hdnDomingoId" & i.ToString)

            If hdnLunes <> txtLunes Or String.Empty <> fnValidaComentarios(CInt(hdnLunesId), CInt(hdnActividad), 1) Then

                strComentarios = fnValidaComentarios(CInt(hdnLunesId), CInt(hdnActividad), 1)
                Benavides.CC.Data.clsRegistroActividadesSistemas.strGuardarRegistroActividadesSistemas(CInt(hdnLunesId), CInt(hdnActividad), CInt(strUsuarioNombre), 1, CDec(txtLunes), strComentarios, fnFechaDiaria(1), strConnectionString)
            End If

            If hdnMartes <> txtMartes Or String.Empty <> fnValidaComentarios(CInt(hdnMartesId), CInt(hdnActividad), 2) Then
                strComentarios = fnValidaComentarios(CInt(hdnMartesId), CInt(hdnActividad), 2)
                Benavides.CC.Data.clsRegistroActividadesSistemas.strGuardarRegistroActividadesSistemas(CInt(hdnMartesId), CInt(hdnActividad), CInt(strUsuarioNombre), 2, CDec(txtMartes), strComentarios, fnFechaDiaria(2), strConnectionString)
            End If

            If hdnMiercoles <> txtMiercoles Or String.Empty <> fnValidaComentarios(CInt(hdnMiercolesId), CInt(hdnActividad), 3) Then
                strComentarios = fnValidaComentarios(CInt(hdnMiercolesId), CInt(hdnActividad), 3)
                Benavides.CC.Data.clsRegistroActividadesSistemas.strGuardarRegistroActividadesSistemas(CInt(hdnMiercolesId), CInt(hdnActividad), CInt(strUsuarioNombre), 3, CDec(txtMiercoles), strComentarios, fnFechaDiaria(3), strConnectionString)
            End If

            If hdnJueves <> txtJueves Or String.Empty <> fnValidaComentarios(CInt(hdnJuevesID), CInt(hdnActividad), 4) Then
                strComentarios = fnValidaComentarios(CInt(hdnJuevesID), CInt(hdnActividad), 4)
                Benavides.CC.Data.clsRegistroActividadesSistemas.strGuardarRegistroActividadesSistemas(CInt(hdnJuevesID), CInt(hdnActividad), CInt(strUsuarioNombre), 4, CDec(txtJueves), strComentarios, fnFechaDiaria(4), strConnectionString)
            End If

            If hdnViernes <> txtViernes Or String.Empty <> fnValidaComentarios(CInt(hdnViernesId), CInt(hdnActividad), 5) Then
                strComentarios = fnValidaComentarios(CInt(hdnViernesId), CInt(hdnActividad), 5)
                Benavides.CC.Data.clsRegistroActividadesSistemas.strGuardarRegistroActividadesSistemas(CInt(hdnViernesId), CInt(hdnActividad), CInt(strUsuarioNombre), 5, CDec(txtViernes), strComentarios, fnFechaDiaria(5), strConnectionString)
            End If

            If hdnSabado <> txtSabado Or String.Empty <> fnValidaComentarios(CInt(hdnSabadoId), CInt(hdnActividad), 6) Then
                strComentarios = fnValidaComentarios(CInt(hdnSabadoId), CInt(hdnActividad), 6)
                Benavides.CC.Data.clsRegistroActividadesSistemas.strGuardarRegistroActividadesSistemas(CInt(hdnSabadoId), CInt(hdnActividad), CInt(strUsuarioNombre), 6, CDec(txtSabado), strComentarios, fnFechaDiaria(6), strConnectionString)
            End If

            If hdnDomingo <> txtDomingo Or String.Empty <> fnValidaComentarios(CInt(hdnDomingoId), CInt(hdnActividad), 7) Then
                strComentarios = fnValidaComentarios(CInt(hdnDomingoId), CInt(hdnActividad), 7)
                Benavides.CC.Data.clsRegistroActividadesSistemas.strGuardarRegistroActividadesSistemas(CInt(hdnDomingoId), CInt(hdnActividad), CInt(strUsuarioNombre), 7, CDec(txtDomingo), strComentarios, fnFechaDiaria(7), strConnectionString)
            End If
        Next
    End Sub


    Private Function fnValidaComentarios(ByVal intRegistroActividadId As Integer, ByVal intActividadId As Integer, ByVal intDiaId As Integer) As String


        Dim strComentarios As String = String.Empty
        Dim strComentarioId As Integer = 0
        Dim intComentarioActividadId As Integer = 0
        Dim intComentarioDiaId As Integer = 0

        'Valida si existen comentarios para guardar
        If Not Request.Form("txtComentarios").Trim() = String.Empty Then

            If (CStr(intRegistroActividadId) = Request.Form("hdnComentarioId").Trim()) AndAlso (CStr(intActividadId) = Request.Form("hdnActividadComentarioId").Trim()) AndAlso (CStr(intDiaId) = Request.Form("hdnIntDiaId").Trim()) Then

                strComentarios = Request.Form("txtComentarios").Trim()
            End If
        End If

        Return strComentarios
    End Function


    Public Function fnFechaDiaria(ByVal intDiaId As Integer) As Date


        If intDiaId = 1 Then

            'Lunes
            Return dtmFechaInicio
        ElseIf intDiaId = 2 Then

            'Martes
            Return dtmFechaInicio.AddDays(1)
        ElseIf intDiaId = 3 Then

            'Miercoles
            Return dtmFechaInicio.AddDays(2)
        ElseIf intDiaId = 4 Then

            'Jueves
            Return dtmFechaInicio.AddDays(3)
        ElseIf intDiaId = 5 Then

            'Viernes
            Return dtmFechaInicio.AddDays(4)
        ElseIf intDiaId = 6 Then

            'Sabado
            Return dtmFechaInicio.AddDays(5)
        ElseIf intDiaId = 7 Then

            'Domingo
            Return dtmFechaInicio.AddDays(6)
        End If

    End Function

    Public Function strTablaConsultaActividadesHTML(ByVal objConsultaReporte As Array) As String

        Dim strTablaReporteHTML As StringBuilder
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim intPage As Integer
        Dim intTotal As Integer = 50
        Dim strConsultaReporte As String() = Nothing

        Dim txtLunes As String = String.Empty
        Dim txtMartes As String = String.Empty
        Dim txtMiercoles As String = String.Empty
        Dim txtJueves As String = String.Empty
        Dim txtViernes As String = String.Empty
        Dim txtSabado As String = String.Empty
        Dim txtDomingo As String = String.Empty
        Dim txtHrsTotal As String = String.Empty
        Dim dectxtTotal As Decimal

        Dim txtTotalLunes As String = String.Empty
        Dim txtTotalMartes As String = String.Empty
        Dim txtTotalMiercoles As String = String.Empty
        Dim txtTotalJueves As String = String.Empty
        Dim txtTotalViernes As String = String.Empty
        Dim txtTotalSabado As String = String.Empty
        Dim txtTotalDomingo As String = String.Empty
        Dim txtTotalGeneral As String = String.Empty

        Dim decTotalLunes As Decimal = 0
        Dim decTotalMartes As Decimal = 0
        Dim decTotalMiercoles As Decimal = 0
        Dim decTotalJueves As Decimal = 0
        Dim decTotalViernes As Decimal = 0
        Dim decTotalSabado As Decimal = 0
        Dim decTotalDomingo As Decimal = 0
        Dim decTotalGeneral As Decimal = 0

        Dim strImgComentariosLunes As String = String.Empty
        Dim strImgComentariosMartes As String = String.Empty
        Dim strImgComentariosMiercoles As String = String.Empty
        Dim strImgComentariosJueves As String = String.Empty
        Dim strImgComentariosViernes As String = String.Empty
        Dim strImgComentariosSabado As String = String.Empty
        Dim strImgComentariosDomingo As String = String.Empty

        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If

        strTablaReporteHTML = New StringBuilder

        strTablaReporteHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        strTablaReporteHTML.Append("<tr>")
        strTablaReporteHTML.Append("<td align='left' width='100%' class='tdtexttablebold' colspan='2'>")
        strTablaReporteHTML.Append("Informacion del empleado " & strUsuarioNombre & " del lunes " & fnFechaDiaria(1).ToString("dd/MM/yyyy") & " al domingo " & fnFechaDiaria(7).ToString("dd/MM/yyyy"))
        strTablaReporteHTML.Append("</td>")
        strTablaReporteHTML.Append("</tr>")

        strTablaReporteHTML.Append("<tr>")
        strTablaReporteHTML.Append("<td align='left' width='50%'>")
        strTablaReporteHTML.Append("<img src='../static/images/icono_back.gif' width='25' height='17' align='absmiddle' border='0' alt='Regresar' onClick='javascript:cmdRegresar_onclick()'>")
        strTablaReporteHTML.Append("</td>")

        strTablaReporteHTML.Append("<td align='right' width='50%'>")
        strTablaReporteHTML.Append("<img src='../static/images/icono_fwd.gif' width='25' height='17' align='absmiddle' border='0' alt='Avanzar' onClick='javascript:cmdAvanzar_onclick()'>")
        strTablaReporteHTML.Append("</td>")

        strTablaReporteHTML.Append("</tr>")
        strTablaReporteHTML.Append("</table>")

        strTablaReporteHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        strTablaReporteHTML.Append("<tr class='trtitulos'>")
        strTablaReporteHTML.Append("<th width='25%' class='rayita' align='center' valign='top'>Actividades</th>")
        strTablaReporteHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Lunes</th>")
        strTablaReporteHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Martes</th>")
        strTablaReporteHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Miercoles</th>")
        strTablaReporteHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Jueves</th>")
        strTablaReporteHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Viernes</th>")
        strTablaReporteHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Sabado</th>")
        strTablaReporteHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Domingo</th>")
        strTablaReporteHTML.Append("<th width='5%' class='rayita' align='center' valign='top'>Total</th>")

        strTablaReporteHTML.Append("</tr>")

        strTablaReporteHTML.Append("<tr>")
        ' Fechas por dia
        strTablaReporteHTML.Append("<td class=" & "tdblanco" & ">" & "&nbsp" & "</td>")
        ' Lunes
        strTablaReporteHTML.Append("<td align=center class=" & "tdblanco" & ">" & fnFechaDiaria(1).ToString("dd/MM/yyyy") & "</td>")
        ' Martes
        strTablaReporteHTML.Append("<td align=center class=" & "tdblanco" & ">" & fnFechaDiaria(2).ToString("dd/MM/yyyy") & "</td>")
        ' Miercoles
        strTablaReporteHTML.Append("<td align=center class=" & "tdblanco" & ">" & fnFechaDiaria(3).ToString("dd/MM/yyyy") & "</td>")
        ' Jueves
        strTablaReporteHTML.Append("<td align=center class=" & "tdblanco" & ">" & fnFechaDiaria(4).ToString("dd/MM/yyyy") & "</td>")
        ' Viernes
        strTablaReporteHTML.Append("<td align=center class=" & "tdblanco" & ">" & fnFechaDiaria(5).ToString("dd/MM/yyyy") & "</td>")
        ' Sabado
        strTablaReporteHTML.Append("<td align=center class=" & "tdblanco" & ">" & fnFechaDiaria(6).ToString("dd/MM/yyyy") & "</td>")
        ' Domingo
        strTablaReporteHTML.Append("<td align=center class=" & "tdblanco" & ">" & fnFechaDiaria(7).ToString("dd/MM/yyyy") & "</td>")
        ' 
        strTablaReporteHTML.Append("<td align=center class=" & "tdblanco" & ">" & "&nbsp" & "</td>")
        strTablaReporteHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaReporte.Length) Then
                Exit For
            End If

            strConsultaReporte = CType(objConsultaReporte.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            'Se crean los texbox's con el registro de las horas
            txtLunes = "<input id='txtLunes" & intContador.ToString() & "' name='txtLunes" & intContador.ToString() & "' class='campotabla' size='4' maxLength='10' type='text' value='" & strConsultaReporte(3).ToString() & "' onblur='txtTotal_onblur(1," & intContador.ToString() & ")' onKeyPress=' return validaNumerico_onKeyPress(event);'>"
            txtMartes = "<INPUT class='campotabla' type='text' maxLength='10' size='4' id='txtMartes" & intContador.ToString & "' value='" & strConsultaReporte(5).ToString() & "' onblur='txtTotal_onblur(2," & intContador.ToString() & ")' onKeyPress='return validaNumerico_onKeyPress(event);' name='txtMartes" & intContador.ToString() & "'>"
            txtMiercoles = "<input id='txtMiercoles" & intContador.ToString() & "' name='txtMiercoles" & intContador.ToString() & "' class='campotabla' size='4' maxLength='10' type='text' value='" & strConsultaReporte(7).ToString() & "' onblur='txtTotal_onblur(3," & intContador.ToString() & ")' onKeyPress=' return validaNumerico_onKeyPress(event);'>" 'onKeyPress=' return dtmFecha_onKeyPress(event);'
            txtJueves = "<input id='txtJueves" & intContador.ToString() & "' name='txtJueves" & intContador.ToString() & "' class='campotabla' size='4' maxLength='10' type='text' value='" & strConsultaReporte(9).ToString() & "' onblur='txtTotal_onblur(4," & intContador.ToString() & ")' onKeyPress=' return validaNumerico_onKeyPress(event);'>" 'onKeyPress=' return dtmFecha_onKeyPress(event);'
            txtViernes = "<input id='txtViernes" & intContador.ToString() & "' name='txtViernes" & intContador.ToString() & "' class='campotabla' size='4' maxLength='10' type='text' value='" & strConsultaReporte(11).ToString() & "' onblur='txtTotal_onblur(5," & intContador.ToString() & ")' onKeyPress=' return validaNumerico_onKeyPress(event);'>" 'onKeyPress=' return dtmFecha_onKeyPress(event);'
            txtSabado = "<input id='txtSabado" & intContador.ToString() & "' name='txtSabado" & intContador.ToString() & "' class='campotabla' size='4' maxLength='10' type='text' value='" & strConsultaReporte(13).ToString() & "' onblur='txtTotal_onblur(6," & intContador.ToString() & ")' onKeyPress=' return validaNumerico_onKeyPress(event);'>" 'onKeyPress=' return dtmFecha_onKeyPress(event);'
            txtDomingo = "<input id='txtDomingo" & intContador.ToString() & "' name='txtDomingo" & intContador.ToString() & "' class='campotabla' size='4' maxLength='10' type='text' value='" & strConsultaReporte(15).ToString() & "' onblur='txtTotal_onblur(7," & intContador.ToString() & ")' onKeyPress=' return validaNumerico_onKeyPress(event);'>" 'onKeyPress=' return dtmFecha_onKeyPress(event);'
            dectxtTotal = CDec(strConsultaReporte(3)) + CDec(strConsultaReporte(5)) + CDec(strConsultaReporte(7)) + CDec(strConsultaReporte(9)) + CDec(strConsultaReporte(11)) + CDec(strConsultaReporte(13)) + CDec(strConsultaReporte(15))
            txtHrsTotal = "<input id='txtHrsTotal" & intContador.ToString() & "' name='txtHrsTotal" & intContador.ToString() & "' class='campotabla' size='5' maxLength='10' type='text' disabled value='" & dectxtTotal.ToString() & "' >" 'onKeyPress=' return dtmFecha_onKeyPress(event);'

            strImgComentariosLunes = "<img id=ImgLunes" & strConsultaReporte(0) & " height='17' src='../static/images/icono_lupa.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:fnComentarios_onclick(" & strConsultaReporte(0) & "," & strConsultaReporte(2) & ",1)' alt='Ver Comentarios'>"
            strImgComentariosMartes = "<img id=ImgMartes" & strConsultaReporte(0) & " height='17' src='../static/images/icono_lupa.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:fnComentarios_onclick(" & strConsultaReporte(0) & "," & strConsultaReporte(4) & ",2)' alt='Ver Comentarios'>"
            strImgComentariosMiercoles = "<img id=ImgMiercoles" & strConsultaReporte(0) & " height='17' src='../static/images/icono_lupa.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:fnComentarios_onclick(" & strConsultaReporte(0) & "," & strConsultaReporte(6) & ",3)' alt='Ver Comentarios'>"
            strImgComentariosJueves = "<img id=ImgJueves" & strConsultaReporte(0) & " height='17' src='../static/images/icono_lupa.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:fnComentarios_onclick(" & strConsultaReporte(0) & "," & strConsultaReporte(8) & ",4)' alt='Ver Comentarios'>"
            strImgComentariosViernes = "<img id=ImgViernes" & strConsultaReporte(0) & " height='17' src='../static/images/icono_lupa.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:fnComentarios_onclick(" & strConsultaReporte(0) & "," & strConsultaReporte(10) & ",5)' alt='Ver Comentarios'>"
            strImgComentariosSabado = "<img id=ImgSabado" & strConsultaReporte(0) & " height='17' src='../static/images/icono_lupa.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:fnComentarios_onclick(" & strConsultaReporte(0) & "," & strConsultaReporte(12) & ",6)' alt='Ver Comentarios'>"
            strImgComentariosDomingo = "<img id=ImgDomingo" & strConsultaReporte(0) & " height='17' src='../static/images/icono_lupa.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:fnComentarios_onclick(" & strConsultaReporte(0) & "," & strConsultaReporte(14) & ",7)' alt='Ver Comentarios'>"

            strTablaReporteHTML.Append("<tr>")

            ' Actividades
            strTablaReporteHTML.Append("<td id='" & strConsultaReporte(0) & "' align=left class=" & "tdceleste" & ">" & strConsultaReporte(1) & "</td>")
            ' Lunes
            strTablaReporteHTML.Append("<td align=center class=" & "tdceleste" & ">" & txtLunes & " " & strImgComentariosLunes & "</td>")
            ' Martes
            strTablaReporteHTML.Append("<td align=center class=" & "tdceleste" & ">" & txtMartes & " " & strImgComentariosMartes & "</td>")
            ' Miercoles
            strTablaReporteHTML.Append("<td align=center class=" & "tdceleste" & ">" & txtMiercoles & " " & strImgComentariosMiercoles & "</td>")
            ' Jueves
            strTablaReporteHTML.Append("<td align=center class=" & "tdceleste" & ">" & txtJueves & " " & strImgComentariosJueves & "</td>")
            ' Viernes
            strTablaReporteHTML.Append("<td align=center class=" & "tdceleste" & ">" & txtViernes & " " & strImgComentariosViernes & "</td>")
            ' Sabado
            strTablaReporteHTML.Append("<td align=center class=" & "tdceleste" & ">" & txtSabado & " " & strImgComentariosSabado & "</td>")
            ' Domingo
            strTablaReporteHTML.Append("<td align=center class=" & "tdceleste" & ">" & txtDomingo & " " & strImgComentariosDomingo & "</td>")
            ' Total
            strTablaReporteHTML.Append("<td align=center class=" & "tdceleste" & ">" & txtHrsTotal & "</td>")

            strTablaReporteHTML.Append("</tr>")

            'Actividad Id (Hidden)
            strTablaReporteHTML.Append("<input type='hidden' id='hdnActividad" & intContador.ToString() & "'  name='hdnActividad" & intContador.ToString() & "' value='" & strConsultaReporte(0).ToString() & "' />")

            'Hidden que guardan el valor ORIGINAL de cada uno de los registros
            strTablaReporteHTML.Append("<input type='hidden' id='hdnLunes" & intContador.ToString() & "'  name='hdnLunes" & intContador.ToString() & "' value='" & strConsultaReporte(3).ToString() & "' />")
            strTablaReporteHTML.Append("<input type='hidden' id='hdnMartes" & intContador.ToString() & "'  name='hdnMartes" & intContador.ToString() & "' value='" & strConsultaReporte(5).ToString() & "' />")
            strTablaReporteHTML.Append("<input type='hidden' id='hdnMiercoles" & intContador.ToString() & "'  name='hdnMiercoles" & intContador.ToString() & "' value='" & strConsultaReporte(7).ToString() & "' />")
            strTablaReporteHTML.Append("<input type='hidden' id='hdnJueves" & intContador.ToString() & "'  name='hdnJueves" & intContador.ToString() & "' value='" & strConsultaReporte(9).ToString() & "' />")
            strTablaReporteHTML.Append("<input type='hidden' id='hdnViernes" & intContador.ToString() & "'  name='hdnViernes" & intContador.ToString() & "' value='" & strConsultaReporte(11).ToString() & "' />")
            strTablaReporteHTML.Append("<input type='hidden' id='hdnSabado" & intContador.ToString() & "'  name='hdnSabado" & intContador.ToString() & "' value='" & strConsultaReporte(13).ToString() & "' />")
            strTablaReporteHTML.Append("<input type='hidden' id='hdnDomingo" & intContador.ToString() & "'  name='hdnDomingo" & intContador.ToString() & "' value='" & strConsultaReporte(15).ToString() & "' />")

            'Hidden que guardan el id de cada uno de los registros
            strTablaReporteHTML.Append("<input type='hidden' id='hdnLunesId" & intContador.ToString() & "'  name='hdnLunesId" & intContador.ToString() & "' value='" & strConsultaReporte(2).ToString() & "' />")
            strTablaReporteHTML.Append("<input type='hidden' id='hdnMartesId" & intContador.ToString() & "'  name='hdnMartesId" & intContador.ToString() & "' value='" & strConsultaReporte(4).ToString() & "' />")
            strTablaReporteHTML.Append("<input type='hidden' id='hdnMiercolesId" & intContador.ToString() & "'  name='hdnMiercolesId" & intContador.ToString() & "' value='" & strConsultaReporte(6).ToString() & "' />")
            strTablaReporteHTML.Append("<input type='hidden' id='hdnJuevesID" & intContador.ToString() & "'  name='hdnJuevesID" & intContador.ToString() & "' value='" & strConsultaReporte(8).ToString() & "' />")
            strTablaReporteHTML.Append("<input type='hidden' id='hdnViernesId" & intContador.ToString() & "'  name='hdnViernesId" & intContador.ToString() & "' value='" & strConsultaReporte(10).ToString() & "' />")
            strTablaReporteHTML.Append("<input type='hidden' id='hdnSabadoId" & intContador.ToString() & "'  name='hdnSabadoId" & intContador.ToString() & "' value='" & strConsultaReporte(12).ToString() & "' />")
            strTablaReporteHTML.Append("<input type='hidden' id='hdnDomingoId" & intContador.ToString() & "'  name='hdnDomingoId" & intContador.ToString() & "' value='" & strConsultaReporte(14).ToString() & "' />")

            'Suma total por dia
            decTotalLunes = decTotalLunes + CDec(strConsultaReporte(3))
            decTotalMartes = decTotalMartes + CDec(strConsultaReporte(5))
            decTotalMiercoles = decTotalMiercoles + CDec(strConsultaReporte(7))
            decTotalJueves = decTotalJueves + CDec(strConsultaReporte(9))
            decTotalViernes = decTotalViernes + CDec(strConsultaReporte(11))
            decTotalSabado = decTotalSabado + CDec(strConsultaReporte(13))
            decTotalDomingo = decTotalDomingo + CDec(strConsultaReporte(15))
            decTotalGeneral = decTotalGeneral + dectxtTotal
        Next

        'Fecha de ultima consulta que sirve para navegar adelante y atras (1 semana)
        Dim dtmFechaUltimaConsulta As Date
        dtmFechaUltimaConsulta = New Date(dtmFechaInicio.Year, dtmFechaInicio.Month, dtmFechaInicio.Day)

        strTablaReporteHTML.Append("<input type='hidden' id='hdnIntDiaId'  name='hdnIntDiaId'/>")
        strTablaReporteHTML.Append("<input type='hidden' id='hdnTotalDeActividades'  name='hdnTotalDeActividades' value='" & objConsultaReporte.Length.ToString() & "' />")
        strTablaReporteHTML.Append("<input type='hidden' id='hdnFechaInicio'  name='hdnFechaInicio' value='" & dtmFechaUltimaConsulta.ToString("dd/MM/yyyy") & "' />")
        strTablaReporteHTML.Append("<input type='hidden' id='hdnActividadComentarioId'  name='hdnActividadComentarioId'  />")

        'Totales (suma de horas)
        txtTotalLunes = "<input id='txtHrsTotalLunes' name='txtHrsTotalLunes' class='campotabla' size='5' maxLength='10' type='text' disabled value='" & decTotalLunes.ToString() & "' >"
        txtTotalMartes = "<INPUT class='campotabla' type='text' maxLength='10' size='5' name='txtHrsTotalMartes' disabled value='" & decTotalMartes.ToString() & "' >" 'onBlur='CheckTime(this)'
        txtTotalMiercoles = "<input id='txtHrsTotalMiercoles' name='txtHrsTotalMiercoles' class='campotabla' size='5' maxLength='10' type='text' disabled value='" & decTotalMiercoles.ToString() & "' >" 'onKeyPress=' return dtmFecha_onKeyPress(event);'
        txtTotalJueves = "<input id='txtHrsTotalJueves' name='txtHrsTotalJueves' class='campotabla' size='5' maxLength='10' type='text' disabled value='" & decTotalJueves.ToString() & "' >" 'onKeyPress=' return dtmFecha_onKeyPress(event);'
        txtTotalViernes = "<input id='txtHrsTotalViernes' name='txtHrsTotalViernes' class='campotabla' size='5' maxLength='10' type='text' disabled value='" & decTotalViernes.ToString() & "' >" 'onKeyPress=' return dtmFecha_onKeyPress(event);'
        txtTotalSabado = "<input id='txtHrsTotalSabado' name='txtHrsTotalSabado' class='campotabla' size='5' maxLength='10' type='text' disabled value='" & decTotalSabado.ToString() & "' >" 'onKeyPress=' return dtmFecha_onKeyPress(event);'
        txtTotalDomingo = "<input id='txtHrsTotalDomingo' name='txtHrsTotalDomingo' class='campotabla' size='5' maxLength='10' type='text' disabled value='" & decTotalDomingo.ToString() & "' >" 'onKeyPress=' return dtmFecha_onKeyPress(event);'
        'inttxtTotalTotal = (CInt(strConsultaReporte(2)) + CInt(strConsultaReporte(3)) + CInt(strConsultaReporte(4)) + CInt(strConsultaReporte(5)) + CInt(strConsultaReporte(6)) + CInt(strConsultaReporte(7)) + CInt(strConsultaReporte(8))).ToString()
        'strtxtTotalTotal = "<input id='txtHrsTotal' name='txtHrsTotal" & intContador.ToString() & "' class='campotabla' size='10' maxLength='10' type='text' value='" & dectxtTotal.ToString() & "' >" 'onKeyPress=' return dtmFecha_onKeyPress(event);'
        txtTotalGeneral = "<input id='txtHrsTotalGeneral' name='txtHrsTotalGeneral' class='campotabla' size='5' maxLength='10' type='text' disabled value='" & decTotalGeneral.ToString() & "' >" 'onKeyPress=' return dtmFecha_onKeyPress(event);'

        strTablaReporteHTML.Append("<tr>")
        strTablaReporteHTML.Append("<td> &nbsp;</td>")
        ' Lunes
        strTablaReporteHTML.Append("<td align=left class=" & "tdceleste" & ">" & txtTotalLunes & "</td>")
        ' Martes
        strTablaReporteHTML.Append("<td align=left class=" & "tdceleste" & ">" & txtTotalMartes & "</td>")
        ' Miercoles
        strTablaReporteHTML.Append("<td align=left class=" & "tdceleste" & ">" & txtTotalMiercoles & "</td>")
        ' Jueves
        strTablaReporteHTML.Append("<td align=left class=" & "tdceleste" & ">" & txtTotalJueves & "</td>")
        ' Viernes
        strTablaReporteHTML.Append("<td align=left class=" & "tdceleste" & ">" & txtTotalViernes & "</td>")
        ' Sabado
        strTablaReporteHTML.Append("<td align=left class=" & "tdceleste" & ">" & txtTotalSabado & "</td>")
        ' Domingo
        strTablaReporteHTML.Append("<td align=left class=" & "tdceleste" & ">" & txtTotalDomingo & "</td>")
        ' Total
        strTablaReporteHTML.Append("<td align=center class=" & "tdceleste" & ">" & txtTotalGeneral & "</td>")

        strTablaReporteHTML.Append("</tr>")

        strTablaReporteHTML.Append("</tr>")
        strTablaReporteHTML.Append("</table>")
        strTablaReporteHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaActividadesHTML = strTablaReporteHTML.ToString


    End Function

End Class