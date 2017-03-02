Imports System.Configuration
Imports System.Text
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data

Public Class clsMercanciaCapturarInventarioRotativo
    Inherits System.Web.UI.Page

    'Variables globales
    Dim strmMensaje As String = ""
    Dim strmRecordBrowserHTML As String = ""
    Dim strmbtnAceptar As String = ""
    Dim blnmPlanogramasCompletos As Boolean = True

    '====================================================================
    ' Name       : strRedirectPage
    ' Description: Página hacia la cual se debe redireccionar al usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRedirectPage() As String
        Get
            If intCompaniaId > 0 AndAlso intSucursalId > 0 Then
                Return "/Default.aspx?strURL=/_ScriptLibrary/POSAdminRedirectorCC.aspx?strPageName=" & strThisPageName
            Else
                Return "/Default.aspx?strURL=" & Server.UrlEncode(Request.ServerVariables("SCRIPT_NAME"))
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strFormAction
    ' Description: Valor de la acción de la forma HTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormAction() As String
        Get
            Return Request.ServerVariables("SCRIPT_NAME")
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
            Return clsCommons.strGetPageName(Request)
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
            Return CInt(clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : intCompaniaId
    ' Description: Valor de la Compañia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCompaniaId() As Integer
        Get
            Return CInt(clsCommons.strReadCookie("intCompaniaId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Valor de la Sucursal
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intSucursalId() As Integer
        Get
            Return CInt(clsCommons.strReadCookie("intSucursalId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strSucursalNombre
    ' Description: Nombre de la Sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalNombre() As String
        Get
            Return clsCommons.strReadCookie("strSucursalNombre", "0", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del Usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return clsCommons.strReadCookie("strUsuarioNombre", "0", Request, Server)
        End Get
    End Property
    '====================================================================
    ' Name       : strCadenaConexion
    ' Description: Valor que tomara la variable strmCadenaConexion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCadenaConexion() As String
        Get
            Return ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property
    '====================================================================
    ' Name       : strURLPOSAdmin
    ' Description: URL del POS Admin
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strURLPOSAdmin() As String
        Get
            Return clsConcentrador.strObtenerURLSucursal(intCompaniaId, intSucursalId, strCadenaConexion)
        End Get
    End Property

    '====================================================================
    ' Name       : strMensaje
    ' Description: Mensajes enviados al usuario
    ' Accessor   : Read and Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strMensaje() As String
        Get
            Return strmMensaje
        End Get
        Set(ByVal strValue As String)
            strmMensaje = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strDiaDeHoy
    ' Description: Dia y fecha del dia de hoy
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strDiaDeHoy() As String
        Get

            Dim dtmDiaDeHoy As String
            Dim strDiaSemanaHoy As String

            dtmDiaDeHoy = Now.ToString("dd/MM/yyyy")
            strDiaSemanaHoy = clsCommons.strNombreDia(Now)

            Return strDiaSemanaHoy & " " & dtmDiaDeHoy

        End Get
    End Property

    '====================================================================
    ' Name       : strDiaDeAyer
    ' Description: Dia y fecha del dia de ayer
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strDiaDeAyer() As String
        Get

            Dim dtmDiaDeAyer As String
            Dim strDiaSemanaAyer As String

            dtmDiaDeAyer = DateAdd(DateInterval.Day, -1, Now).ToString("dd/MM/yyyy")
            strDiaSemanaAyer = clsCommons.strNombreDia(DateAdd(DateInterval.Day, -1, Now))

            Return strDiaSemanaAyer & " " & dtmDiaDeAyer

        End Get
    End Property

    '====================================================================
    ' Name       : rdoFechaCaptura
    ' Description: Dia seleccionado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================

    Public ReadOnly Property rdoFechaCaptura() As String
        Get
            If dtmFechaCaptura <> "01/01/1900" Then
                Dim dtmDia As Date
                Dim strHoy As String, strAyer As String

                dtmDia = Date.Now
                strHoy = dtmDia.Day.ToString("00") & "/" & dtmDia.Month.ToString("00") & "/" & dtmDia.Year.ToString("0000")

                dtmDia = DateAdd(DateInterval.Day, -1, Date.Now)
                strAyer = dtmDia.Day.ToString("00") & "/" & dtmDia.Month.ToString("00") & "/" & dtmDia.Year.ToString("0000")

                If dtmFechaCaptura = strHoy Then
                    Return "1"
                Else
                    If dtmFechaCaptura = strAyer Then
                        Return "2"
                    End If
                End If
            Else
                Return Request.Form("rdoFechaCaptura")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strbtnAceptar
    ' Description: Pinta el boton de aceptar y cancelar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strbtnAceptar() As String
        Get
            Return strmbtnAceptar
        End Get
        Set(ByVal strValue As String)
            strmbtnAceptar = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Record browser con los planogramas
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================

    Public Property strRecordBrowserHTML() As String
        Get
            Return strmRecordBrowserHTML
        End Get
        Set(ByVal strValue As String)
            strmRecordBrowserHTML = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strGeneraRecordBrowserHTML
    ' Description: Genera el HTML para el record browser con los planogramas
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================

    Public Function strGeneraRecordBrowserHTML() As String

        ' Declaracion de Variables
        Dim objPlanogramas As Array
        Dim strHTML As StringBuilder
        Dim strPlanograma As String()
        Dim intConsecutivo As Integer
        Dim strColorRegistro As String
        Dim dtmFechaCapturaPlano As Date
        Dim strFechaCaptura As String
        Dim strEstatus As String

        'Inicializamos variables
        strHTML = New StringBuilder
        objPlanogramas = Nothing
        strPlanograma = Nothing
        intConsecutivo = 0

        'Verificamos el dia de captura seleccionado

        If dtmFechaCaptura <> "01/01/1900" Then
            dtmFechaCapturaPlano = CDate(clsCommons.strDMYtoMDY(dtmFechaCaptura))
        Else
            Select Case rdoFechaCaptura
                Case "1"    'Dia de Hoy
                    dtmFechaCapturaPlano = Date.Now
                Case "2"    'Dia de ayer
                    dtmFechaCapturaPlano = DateAdd(DateInterval.Day, -1, Date.Now)
            End Select
        End If

        strFechaCaptura = dtmFechaCapturaPlano.Day.ToString("00") & "/" & dtmFechaCapturaPlano.Month.ToString("00") & "/" & dtmFechaCapturaPlano.Year.ToString("0000")

        'Consultamos los planogramas programados para su captura
        objPlanogramas = clsConcentrador.clsPlanograma.strBuscar(intCompaniaId, intSucursalId, CDate(clsCommons.strDMYtoMDY(strFechaCaptura)), 0, 0, strCadenaConexion)

        'Verificamos que haya información de planogramas
        If IsArray(objPlanogramas) AndAlso objPlanogramas.Length > 0 Then

            'Inicio de la generacion del HTML

            Call strHTML.Append("<span class='txsubtitulo'><br>")
            Call strHTML.Append("<img src='../static/images/bullet_subtitulos.gif' width='17' height='11' align='absMiddle'>")
            Call strHTML.Append("Planogramas del día elegido")
            Call strHTML.Append("</span>")
            Call strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            Call strHTML.Append("<tr class='trtitulos'>")
            Call strHTML.Append("<th width='202' class='rayita'>Planograma</th>")
            Call strHTML.Append("<th width='200' class='rayita'>Estatus</th>")
            Call strHTML.Append("<th width='129' class='rayita' align='center'>Accion</th>")
            Call strHTML.Append("</tr>")

            intConsecutivo += 1

            blnPlanogramasCompletos = True

            'Vamos pintando cada renglon

            For Each strPlanograma In objPlanogramas
                'Definimos el color del renglón
                If (intConsecutivo Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If

                'Obtenemos el estatus del planograma
                If strPlanograma(1).ToString = "0" Then
                    strEstatus = "CI"
                    blnPlanogramasCompletos = False
                Else
                    strEstatus = "CC"
                End If


                Call strHTML.Append("<tr>")
                Call strHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strPlanograma(2)).ToString & "</td>")   'strPlanoNombre
                Call strHTML.Append("<td class=" & strColorRegistro & ">" & strEstatus & "</td>")             'blnPlanoSucursalCapturado
                Call strHTML.Append("<td class=" & strColorRegistro & " align='center'><a href='MercanciaCapturarExistenciasPlanograma.aspx?intPlanogramaId=" & clsCommons.strFormatearDescripcion(strPlanograma(0)).ToString & "&dtmFechaCaptura=" & strFechaCaptura & "' class='txaccion'><img src='../static/images/icono_capturar.gif' border='0' align='absmiddle' alt='Capturar plano'></a></td>")        'Accion
                Call strHTML.Append("</tr>")
                intConsecutivo += 1
            Next

            Call strHTML.Append("</table>")
            Call strHTML.Append("<br>")
            Call strHTML.Append("<input name='cmdRegresar' type='button' class='boton' value='Regresar' onclick='return cmdRegresar_onclick()'>")
            Call strHTML.Append("&nbsp;&nbsp; <input name='cmdRegistrar' type='button' class='boton' value='Registrar planogramas' onclick='return cmdRegistrar_onclick()'>")

            strGeneraRecordBrowserHTML = strHTML.ToString
        Else
            strGeneraRecordBrowserHTML = ""
            strMensaje = "No hay planogramas para el dia seleccionado."
        End If

    End Function

    '====================================================================
    ' Name       : blnPlanogramasCompletos
    ' Description: Pinta el boton de aceptar y cancelar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property blnPlanogramasCompletos() As Boolean
        Get
            Return blnmPlanogramasCompletos
        End Get
        Set(ByVal blnValue As Boolean)
            blnmPlanogramasCompletos = blnValue
        End Set
    End Property


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
    ' Name       : dtmFechaCaptura
    ' Description: Fecha de la Captura del planograma a capturar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaCaptura() As String
        Get
            If Request.QueryString("dtmFechaCaptura") <> "" Then
                Return Request.QueryString("dtmFechaCaptura")
            Else
                If Request.Form("txtFechaCaptura") <> "" Then
                    Return Request.Form("txtFechaCaptura")
                Else
                    Return "01/01/1900"
                End If
            End If
        End Get
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        If Len(Request.Form("cmdAceptar")) > 0 Or dtmFechaCaptura <> "01/01/1900" Then

            'Generamos el HTML para que se pinte el record browser de los planogramas por capturar

            strRecordBrowserHTML = strGeneraRecordBrowserHTML()

        End If


        If strRecordBrowserHTML.Length > 0 Then
            strbtnAceptar = "<input name='cmdAceptar' type='submit' class='boton' value='Aceptar'>"
        Else
            strbtnAceptar = "<input name='cmdAceptar' type='submit' class='boton' value='Aceptar'>&nbsp;&nbsp<input name='cmdRegresar' type='button' class='boton' value='Regresar' onclick='return cmdRegresar_onclick()'>"
        End If


    End Sub

End Class
