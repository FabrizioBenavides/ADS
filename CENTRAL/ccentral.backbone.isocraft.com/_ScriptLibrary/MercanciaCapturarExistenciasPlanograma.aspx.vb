Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business
Imports System.Text
Imports System.Configuration

'====================================================================
' Page          : MercanciaCapturarExistenciasPlanograma.aspx
' Title         : Administracion POS y BackOffice
' Description   : Página para capturar la existencia real de un planograma
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Armando Calzada Mezura
'                 J.Antonio Hernández Dávila
' Version       : 1.0
' Last Modified : Viernes, Noviembre 8, 2003
'                 Lunes, Dicembre 29, 2003
'====================================================================

Public Class clsMercanciaCapturarExistenciasPlanograma
    Inherits System.Web.UI.Page

    ' Constantes
    Private Const intArticulosXPagina As Integer = 32
    Private Const intRenglones As Integer = 8
    Private Const intColumnas As Integer = CInt(intArticulosXPagina / intRenglones)

    ' Variables
    Private intmTotalInput As Integer

    Private strmPlanoNombre As String

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
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalNombre() As String
        Get
            Return clsCommons.strReadCookie("strSucursalNombre", "", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del Usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)
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
    ' Name       : strCmd
    ' Description: Identificador del comando a realizar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Request.QueryString("strCmd") <> "" Then
                Return Request.QueryString("strCmd")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intPlanogramaId
    ' Description: Identificador del planograma a capturar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intPlanogramaId() As String
        Get
            If Len(Request.QueryString("intPlanogramaId")) > 0 Then
                Return Request.QueryString("intPlanogramaId")
            Else
                If Len(Request.Form("txtPlanogramaId")) > 0 Then
                    Return Request.Form("txtPlanogramaId")
                Else
                    Return "0"
                End If
            End If
        End Get
    End Property

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

    '====================================================================
    ' Name       : intPaginaId
    ' Description: Página a desplegar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intPaginaId() As String
        Get
            If Len(Request.Form("txtNumeroPagina")) > 0 Then
                Return Request.Form("txtNumeroPagina")
            Else
                Return "1"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strCifraControl
    ' Description: Valor de la cifra de control
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCifraControl() As String
        Get
            If Request.QueryString("strCifraControl") <> "" Then
                Return Request.QueryString("strCifraControl")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strHora
    ' Description: Valor de la Hora de la toma Fisica
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strHora() As String
        Get
            If Request.QueryString("strHora") <> "" Then
                Return Request.QueryString("strHora")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strMinutos
    ' Description: Valor de la Minutos de la toma Fisica
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strMinutos() As String
        Get
            If Request.QueryString("strMinutos") <> "" Then
                Return Request.QueryString("strMinutos")
            Else
                Return ""
            End If
        End Get
    End Property


    '====================================================================
    ' Name       : dtmHora
    ' Description: Hora de captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmHora() As String
        Get
            Dim strHoraToma As String = ""

            If Request.Form("cboHora") <> "" Then
                strHoraToma = Trim(Request.Form("cboHora"))
            End If
            If Request.Form("cboMinutos") <> "" Then
                strHoraToma = strHoraToma & ":" & Trim(Request.Form("cboMinutos"))
            End If

            Return strHoraToma

        End Get
    End Property

    '====================================================================
    ' Name       : strPlanoNombre
    ' Description: Nombre del planograma a capturar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strPlanoNombre() As String
        Get
            Return strmPlanoNombre
        End Get
        Set(ByVal Value As String)
            strmPlanoNombre = Value
        End Set
    End Property


    '====================================================================
    ' Name       : intTotalInput
    ' Description: Número de inputs en la página
    ' Accessor   : Read / Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intTotalInput() As Integer
        Get
            Return intmTotalInput
        End Get
        Set(ByVal intValue As Integer)
            intmTotalInput = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : CalculaTotalesdeCaptura
    ' Description: Calcula cantidad de artículos capturados en RegistroEtiben
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Sub CalculaTotalesdeCaptura()
        Dim objRegistroEtiben As Array = Nothing
        Dim strRegistroEtiben As String()

        Dim intArticuloInicial As Integer
        Dim intArticuloFinal As Integer
        Dim intTotalRegistros As Integer
        Dim intTotalPaginas As Integer

        objRegistroEtiben = clsConcentrador.clsPlanograma.strBuscarDetalleTomaFisica(intCompaniaId, intSucursalId, CInt(intPlanogramaId), CDate(clsCommons.strDMYtoMDY(dtmFechaCaptura)), 0, 0, strCadenaConexion)

        If IsArray(objRegistroEtiben) AndAlso objRegistroEtiben.Length > 0 Then

            'Para Mostrar el nombre del Planograma Capturado
            strRegistroEtiben = DirectCast(objRegistroEtiben.GetValue(0), String())
            strPlanoNombre = strRegistroEtiben(3)

            ' Contamos únicamente los totales de las demás páginas

            intTotalRegistros = objRegistroEtiben.Length
            intTotalPaginas = CInt(Math.Ceiling(intTotalRegistros / intArticulosXPagina))
            intArticuloInicial = CInt(((CInt(intPaginaId) - 1) * intArticulosXPagina))

            If CInt(intPaginaId) = intTotalPaginas Then
                intArticuloFinal = intTotalRegistros - 1
            Else
                intArticuloFinal = intArticuloInicial + intArticulosXPagina - 1
            End If


        End If

        intTotalInput = intArticuloFinal - intArticuloInicial + 2

    End Sub

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Record browser navegador de los articulos del planograma
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRecordBrowserHTML() As String
        Get
            ' Variables para el manejo de registros
            Dim objArticulosPlanograma As Array = Nothing
            Dim strArticulosPlanograma As String()

            ' Variables de control
            Dim strbldArticulosPlanograma As StringBuilder

            Dim intTotalRegistros As Integer
            Dim intTotalPaginas As Integer
            Dim intColumnasAImprimir As Integer
            Dim intArticulosaImprimir As Integer
            Dim intArticuloInicial As Integer
            Dim intArticuloFinal As Integer
            Dim intInputGenerales As Integer : intInputGenerales = 2

            Dim intContador As Integer
            Dim intObjeto As Integer
            Dim blnTablaAbierta As Boolean
            Dim strClass As String
            Dim intRenglon As Integer

            strbldArticulosPlanograma = New StringBuilder

            ' Busco los artículos del planograma
            objArticulosPlanograma = clsConcentrador.clsPlanograma.strBuscarDetalleTomaFisica(intCompaniaId, intSucursalId, CInt(intPlanogramaId), CDate(clsCommons.strDMYtoMDY(dtmFechaCaptura)), 0, 0, strCadenaConexion)

            If IsArray(objArticulosPlanograma) AndAlso objArticulosPlanograma.Length > 0 Then

                ' Asignamos valores a las variables
                intTotalRegistros = objArticulosPlanograma.Length
                intTotalPaginas = CInt(Math.Ceiling(intTotalRegistros / intArticulosXPagina))
                intArticuloInicial = CInt(((CInt(intPaginaId) - 1) * intArticulosXPagina))

                If CInt(intPaginaId) = intTotalPaginas Then
                    intArticulosaImprimir = intTotalRegistros - ((CInt(intPaginaId) - 1) * intArticulosXPagina)
                    intArticuloFinal = intTotalRegistros - 1
                Else
                    intArticulosaImprimir = intArticulosXPagina
                    intArticuloFinal = intArticuloInicial + intArticulosXPagina - 1
                End If

                ' Construimos el encabezado
                strbldArticulosPlanograma.Append("<table width='583' border='0' cellpadding='0' cellspacing='0'>")

                strbldArticulosPlanograma.Append("<tr class='trtitulos'>")

                strbldArticulosPlanograma.Append("<th width='5%' class='rayita'>&nbsp;</th>")
                strbldArticulosPlanograma.Append("<th width='15%' class='rayita'>C&oacute;digo</th>")
                strbldArticulosPlanograma.Append("<th width='55%' class='rayita'>Descripci&oacute;n</th>")
                strbldArticulosPlanograma.Append("<th width='25%' class='rayita'>Existencia</th>")

                strbldArticulosPlanograma.Append("</tr>")


                ' Generamos la tabla de los artículos del planograma                

                strClass = "tdceleste"
                intRenglon = intArticuloInicial + 1

                For intObjeto = intArticuloInicial To intArticuloFinal

                    strArticulosPlanograma = DirectCast(objArticulosPlanograma.GetValue(intObjeto), String())

                    strbldArticulosPlanograma.Append("<tr>")
                    strbldArticulosPlanograma.Append("<td width='5%'  class='" & strClass & "'>" & intRenglon.ToString & "</td>")
                    strbldArticulosPlanograma.Append("<td width='15%' class='" & strClass & "'>" & strArticulosPlanograma(5) & "</td>")
                    strbldArticulosPlanograma.Append("<td width='55%' class='" & strClass & "'>" & strArticulosPlanograma(6) & "</td>")

                    If strArticulosPlanograma(18) = "1" Then
                        strbldArticulosPlanograma.Append("<td width='25%' class='" & strClass & "'> <input name='" & "intArticuloId" & strArticulosPlanograma(17) & "' readOnly type='text' class='campotabla' value='0' size='4' maxlength='4' onfocus='cmdCampo_onfocus(" & intInputGenerales.ToString & ")'></td>")
                    Else
                        strbldArticulosPlanograma.Append("<td width='25%' class='" & strClass & "'> <input name='" & "intArticuloId" & strArticulosPlanograma(17) & "' type='text' class='campotabla' value='" & strArticulosPlanograma(16) & "' size='4' maxlength='4' onfocus='cmdCampo_onfocus(" & intInputGenerales.ToString & ")'></td>")
                    End If

                    strbldArticulosPlanograma.Append("</tr>")

                    If strClass.Equals("tdceleste") Then
                        strClass = "tdblanco"
                    Else
                        strClass = "tdceleste"
                    End If

                    intInputGenerales += 1
                    intRenglon += 1
                Next

                strbldArticulosPlanograma.Append("<tr>")
                strbldArticulosPlanograma.Append("<td width='5%'  class='tdpadleft5'>&nbsp;</td>")
                strbldArticulosPlanograma.Append("<td width='15%' class='tdpadleft5'>&nbsp;</td>")
                strbldArticulosPlanograma.Append("<td width='55%' valign='middle' align='right' class='tdtittablas'>Cifra de control:</td>")
                strbldArticulosPlanograma.Append("<td width='25%' valign='middle' class='tdtittablas'><input name='txtCifraControl' type='text' class='campotabla' size='18' value = '" & strCifraControl & "' onfocus='cmdCampo_onfocus(" & intInputGenerales.ToString & ")'>") 'onFocus='cmdCampo_onfocus(0);'>")
                strbldArticulosPlanograma.Append("</td>")
                strbldArticulosPlanograma.Append("</tr>")

                strbldArticulosPlanograma.Append("</table>")

                ' Construimos la navegacion

                strbldArticulosPlanograma.Append("<br>")

                strbldArticulosPlanograma.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

                strbldArticulosPlanograma.Append("<tr>")

                If (CInt(intPaginaId) = 1) Then
                    strbldArticulosPlanograma.Append("<td width='39%'>&nbsp;</td>")
                Else
                    strbldArticulosPlanograma.Append("<td width='39%'><a href="" javascript:cmdCambioPagina_onClick(" & (CInt(intPaginaId) - 1).ToString & ")"" class='txliganormal'>P&aacute;gina anterior</a></td>")
                End If

                strbldArticulosPlanograma.Append("<td width='16%' align='center' class='txcont'>P&aacute;gina " & intPaginaId.ToString & " de " & intTotalPaginas.ToString & "</td>")

                If (CInt(intPaginaId) = intTotalPaginas) Then
                    strbldArticulosPlanograma.Append("<td width='45%' align='right'>&nbsp;</td>")
                Else
                    strbldArticulosPlanograma.Append("<td width='45%' align='right'><a href="" javascript:cmdCambioPagina_onClick(" & (CInt(intPaginaId) + 1).ToString & ")"" class='txliganormal'>P&aacute;gina siguiente</a></td>")
                End If

                strbldArticulosPlanograma.Append("</tr>")

                strbldArticulosPlanograma.Append("</table>")

            End If

            Return clsCommons.strGenerateJavascriptString(strbldArticulosPlanograma.ToString)
        End Get
    End Property

    '====================================================================
    ' Name       : ActualizarRegistroEtiben
    ' Description: Grabar los registros de artículos
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Ninguno
    '====================================================================
    Private Sub ActualizarRegistroEtiben()

        Dim strPrefijoCampo As String = "intArticuloId"
        Dim strNombreParametro As String
        Dim strValorParametro As String

        Dim intLongitudPrefijoCampo As Integer : intLongitudPrefijoCampo = strPrefijoCampo.Length
        Dim intTotalElementosForma As Integer
        Dim intArticuloId As Integer

        ' Actualizamos el registro etiben de los artículos
        For intTotalElementosForma = 0 To Request.Form.Count - 1
            ' Busco el nombre y el valor del parámetro
            strNombreParametro = Request.Form.GetKey(intTotalElementosForma)
            strValorParametro = Trim(Request.Form(strNombreParametro))

            If strNombreParametro.StartsWith(strPrefijoCampo) Then
                ' Validamos que tenga un valor el parámetro
                If strValorParametro <> "" Then
                    intArticuloId = CInt(strNombreParametro.Substring(intLongitudPrefijoCampo, strNombreParametro.Length - intLongitudPrefijoCampo))

                    ' Guardamos el valor en tblRegistroEtiben
                    Call clsConcentrador.clsPlanograma.intActualizarRegistroEtiben(intCompaniaId, intSucursalId, CInt(intPlanogramaId), 0, intArticuloId, CDate(dtmHora), Now, CInt(strValorParametro), strUsuarioNombre, strCadenaConexion)
                End If
            End If
        Next

    End Sub

    '====================================================================
    ' Name       : strGeneracboHora
    ' Description: Genera la lista de las horas
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGeneracboHora() As String
        Dim strcboHoraHTML As StringBuilder
        Dim intContador As Integer = 0
        Dim strHoraSeleccionada As String = ""

        If strHora.Length > 0 Then
            strHoraSeleccionada = (CInt(strHora) + 1).ToString("00")
        End If

        strcboHoraHTML = New StringBuilder

        strcboHoraHTML.Append("document.forms[0].elements['cboHora'].options[0] =")
        strcboHoraHTML.Append("new Option(""" & "Hra" & """,""" & "-1" & """);" & vbCrLf)


        ' generamos el arreglo HTML

        For intContador = 1 To 24
            strcboHoraHTML.Append("document.forms[0].elements['cboHora'].options[" & intContador & "] = ")
            strcboHoraHTML.Append("new Option(""" & (intContador - 1).ToString("00") & """,""" & (intContador - 1).ToString("00") & """);" & vbCrLf)

            ' Marcar la hora seleccionada
            If intContador.ToString("00") = strHoraSeleccionada Then
                strcboHoraHTML.Append("document.forms[0].elements['cboHora'].options[" & intContador & "].selected = true;" & vbCrLf)
            End If
        Next

        If strcboHoraHTML.ToString.Length > 0 Then
            Return strcboHoraHTML.ToString
        Else
            Return ""
        End If

    End Function

    '====================================================================
    ' Name       : strGeneracboMinutos
    ' Description: Genera la lista de los Minutos
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGeneracboMinutos() As String
        Dim strcboMinutosHTML As StringBuilder
        Dim intContador As Integer = 0
        Dim strMinutoSeleccionado As String = ""

        If strMinutos.Length > 0 Then
            strMinutoSeleccionado = (CInt(strMinutos) + 1).ToString("00")
        End If

        strcboMinutosHTML = New StringBuilder

        strcboMinutosHTML.Append("document.forms[0].elements['cboMinutos'].options[0] =")
        strcboMinutosHTML.Append("new Option(""" & "Min" & """,""" & "-1" & """);" & vbCrLf)


        ' generamos el arreglo HTML

        For intContador = 1 To 60
            strcboMinutosHTML.Append("document.forms[0].elements['cboMinutos'].options[" & intContador & "] = ")
            strcboMinutosHTML.Append("new Option(""" & (intContador - 1).ToString("00") & """,""" & (intContador - 1).ToString("00") & """);" & vbCrLf)

            ' Marcar la minutos seleccionada
            If intContador.ToString("00") = strMinutoSeleccionado Then
                strcboMinutosHTML.Append("document.forms[0].elements['cboMinutos'].options[" & intContador & "].selected = true;" & vbCrLf)
            End If
        Next

        If strcboMinutosHTML.ToString.Length > 0 Then
            Return strcboMinutosHTML.ToString
        Else
            Return ""
        End If

    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        If StrComp(intPlanogramaId, "0") = 0 Then
            Response.Redirect("MercanciaCapturarInventarioRotativo.aspx")
        End If

        If strCmd.Length > 0 Then
            Call ActualizarRegistroEtiben()

            If strCmd.Equals("SalvarCaptura") Then
                ' Validamos la captura del planograma
                'Call clsConcentrador.clsPlanograma.intEstablecerCaptura(intCompaniaId, intSucursalId, intPlanogramaId, strUsuarioNombre, strCadenaConexion)
            End If
        End If

        ' Inicializa totales de artículos del planograma
        Call CalculaTotalesdeCaptura()

    End Sub

End Class
