
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
Imports System.IO
Imports System.Web.Caching

Public Class ControlDePagaresConfirmacion

    Inherits System.Web.UI.Page

    Const strComitasDobles As String = """"

    Public strImpresionReporte As String
    Private intRenglonesxPagina As Integer = 42
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
    ' Accessor   : Read
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
    ' Name       : strCentroLogisticoId
    ' Description: Valor de la Compañia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCentroLogisticoId() As String
        Get
            Return (clsCommons.strReadCookie("strCentroLogisticoId", String.Empty, Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: string de Comandos de control
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Not IsNothing(Request.QueryString("strCmd")) Then
                Return Request.QueryString("strCmd")
            Else
                Return String.Empty
            End If
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
            If IsNothing(Request.Form("dtmFechaFin")) Then
                Dim dtmFechaActual As Date

                dtmFechaActual = New Date(Date.Today.Year, Date.Today.Month, Date.Today.Day)

                Return dtmFechaActual.ToString("dd/MM/yyyy")
            Else
                Return Request.Form("dtmFechaFin")
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
    
    '====================================================================
    ' Name       : strCadenaImagen
    ' Description: Valor de la Compañia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCadenaImagen() As String
        Get
            Return (clsCommons.strReadCookie("strCadenaImagen", String.Empty, Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : Page_Load
    ' Description: Evento "Load" de la página
    ' Parameters :
    '              ByVal objSender As System.Object
    '                 - Objeto que genera el Evento
    '              ByVal objEvent As System.EventArgs
    '                 - Argumentos del Evento
    ' Throws     : Ninguna
    ' Output     : Ninguna
    '====================================================================
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If


        Dim objArrayConsulta As Array = Nothing
        Dim strRegistroConsulta As String() = Nothing

        Dim strHTML As StringBuilder
        strHTML = New StringBuilder

        Select Case strCmd
            
            Case "cmdImprimir"

                Dim objArray As System.Array = Nothing
                Dim strmRecordBrowserHTML As String = String.Empty
                Dim strRecordBrowserImpresion As String = String.Empty

                'Reporte de Visitas
                objArray = Benavides.CC.Data.clsControlPagares.strConsultaSolicitudesPagarePorFecha(intCompaniaId, intSucursalId, dtmFechaInicio, dtmFechaFin, strCadenaConexion)

                Dim strResult As New StringBuilder()
                If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then

                    'Impresion
                    strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strGeneraImpresionReporte(objArray))

                    'Se ennvia a impresion.
                    strHTML.Append("<script language='Javascript'>parent.fnImprimir( " & _
                    strComitasDobles & strRecordBrowserImpresion.ToString & strComitasDobles & _
                    "); </script>")
                    Response.Write(strHTML.ToString)
                    Response.End()

                End If

            Case "cmdConfirmar"

                fnConfirmar()

            Case "cmdExportar"

                fnExportar()
        End Select

    End Sub

    Private Sub fnConfirmar()

        Try

            Dim intTotalDePartidas As Integer
            Dim intPartida As Integer
            Dim objArray As System.Array = Nothing
            Dim boolSeleccion As Boolean = False
            Dim boolSinPermiso As Boolean = False
            Dim intTotalConfirmar As Integer = 0
            Dim intConfirmados As Integer = 0
            Dim intRechazados As Integer = 0
            Dim intResultado As Integer = 0

            ' Agregar Cenefa Manual Articulo
            intTotalDePartidas = CInt(Request("hdnTotalDePartidas"))

            For intPartida = 1 To intTotalDePartidas

                If (Len(Trim(Request("chkCodigo" & intPartida.ToString))) > 0) AndAlso (Request.Form("hdnConfirmado" & intPartida.ToString) = "0") Then

                    boolSeleccion = True

                    'Se confirma la asistencia...
                    intResultado = Benavides.CC.Data.clsControlPagares.intConfirmarSolicitudPagare(CInt(Request("hdnRegistro" & intPartida.ToString)), strUsuarioNombre, strCadenaConexion)

                    'Total de registros por confirmar
                    intTotalConfirmar += 1

                    If (intResultado > 0) Then

                        'Registros confirmados con exito 
                        intConfirmados += 1

                    ElseIf (intResultado = 0) Then

                        'Registros rechazados
                        intRechazados += 1

                    End If
                End If
            Next

            If boolSinPermiso AndAlso boolSeleccion = False Then
                Call Response.Write("<script language='Javascript'>alert('No cuenta con permiso para confirmar');</script>")
            ElseIf boolSinPermiso = False AndAlso boolSeleccion = False Then
                Call Response.Write("<script language='Javascript'>alert('Seleccione una registro para confirmar');</script>")
            Else
                Call Response.Write("<script language='Javascript'>alert('De un total de " & CStr(intTotalConfirmar) & " registros por confirmar: Se confirmaron " & CStr(intConfirmados) & " y se rechazaron " & CStr(intRechazados) & "');</script>")
            End If

        Catch ex As Exception
            Call Response.Write("<script language='Javascript'>alert('Ocurrio un error durante la confirmacion');</script>")
        End Try
    End Sub

    Private Sub fnExportar()

        Dim objArrayExportar As System.Array = Nothing
        objArrayExportar = Benavides.CC.Data.clsControlPagares.strConsultaSolicitudesPagarePorFecha(intCompaniaId, intSucursalId, dtmFechaInicio, dtmFechaFin, strCadenaConexion)


        'FORMATO A TABLA CON RESULTADOS
        If Not objArrayExportar Is Nothing AndAlso IsArray(objArrayExportar) AndAlso objArrayExportar.Length > 0 Then

            ' Establecemos en la respuesta los parámetros de configuración del archivo
            Response.ContentType = "application/vnd.ms-excel"
            Call Response.AddHeader("Content-Disposition", "attachment; filename=""Control de Pagares.xls""")
            Call Response.Write(strTablaPagaresExportar(objArrayExportar))
            Call Response.End()

        End If

    End Sub

    Public Function strTablaPagaresExportar(ByVal objConsultaExportar As Array) As String

        Dim strTablaSolicitudPagaresHTML As StringBuilder
        Dim strRegistroSolicitudExportar As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim strConfirmado As String
        Dim imgDetalle As String = Nothing
        Dim strFechaConfirmacion As String

        strTablaSolicitudPagaresHTML = New StringBuilder
        strTablaSolicitudPagaresHTML.Append("<span class='txsubtitulo'></span> ")
        strTablaSolicitudPagaresHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        strTablaSolicitudPagaresHTML.Append("<tr class='trtitulos'>")
        strTablaSolicitudPagaresHTML.Append("<th width='30%' class='rayita' align='center' valign='top'>Sucursal</th>")
        strTablaSolicitudPagaresHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Afiliación</th>")
        strTablaSolicitudPagaresHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Autorización</th>")
        strTablaSolicitudPagaresHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Importe</th>")
        strTablaSolicitudPagaresHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Fecha de Pagare</th>")
        strTablaSolicitudPagaresHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Fecha <br>  Solicitud</th>")
        strTablaSolicitudPagaresHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Fecha <br> Confirmación <br> Envio</th>")
        strTablaSolicitudPagaresHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Confirmación</th>")

        strTablaSolicitudPagaresHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For Each strRegistroSolicitudExportar In objConsultaExportar
            intContador = intContador + 1

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strConfirmado = "No"
            strFechaConfirmacion = "&nbsp;"

            If (CBool(strRegistroSolicitudExportar(6)) = True) Then
                strConfirmado = "Si"
                strFechaConfirmacion = clsCommons.strFormatearFechaPresentacion(strRegistroSolicitudExportar(7))
            End If

            strTablaSolicitudPagaresHTML.Append("<tr>")

            'Sucursal                
            strTablaSolicitudPagaresHTML.Append("<td align='left' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroSolicitudExportar(1)) & "</td>")
            'Afiliación
            strTablaSolicitudPagaresHTML.Append("<td align='left' id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroSolicitudExportar(2)) & "</td>")
            'Autorización
            strTablaSolicitudPagaresHTML.Append("<td align='center' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroSolicitudExportar(3)) & "</td>")
            'Importe                
            strTablaSolicitudPagaresHTML.Append("<td align='center' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroSolicitudExportar(4)) & "</td>")
            'Fecha de Pagare
            strTablaSolicitudPagaresHTML.Append("<td align='center' class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strRegistroSolicitudExportar(5)) & "</td>")
            'Fecha <br>  Solicitud
            strTablaSolicitudPagaresHTML.Append("<td align='center' class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strRegistroSolicitudExportar(9)) & "</td>")
            'Fecha <br> Confirmación <br> Envio
            strTablaSolicitudPagaresHTML.Append("<td align='center' class=" & strColorRegistro & ">" & strFechaConfirmacion & "</td>")
            'Confirmación 
            strTablaSolicitudPagaresHTML.Append("<td align='center' class=" & strColorRegistro & ">" & strConfirmado & "</td>")
            strTablaSolicitudPagaresHTML.Append("</tr>")

        Next
        strTablaSolicitudPagaresHTML.Append("</tr>")
        strTablaSolicitudPagaresHTML.Append("</table>")
        strTablaPagaresExportar = strTablaSolicitudPagaresHTML.ToString
    End Function




    Public Function strTablaConsultaSolicitudPagares() As String

        Dim objArray As System.Array = Nothing
        Dim strmRecordBrowserHTML As String = String.Empty
        'Dim intEmpleadoId As Integer

        strmTotalDePartidas = 0

        If (strCmd = "cmdConsultar") Or (strCmd = "cmdConfirmar") Then

            'Reporte de Visitas
            objArray = Benavides.CC.Data.clsControlPagares.strConsultaSolicitudesPagarePorFecha(intCompaniaId, intSucursalId, dtmFechaInicio, dtmFechaFin, strCadenaConexion)

            Dim strResult As New StringBuilder()
            If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then

                'Reporte
                strmTotalDePartidas = objArray.Length
                strResult.Append(strTablaConsultaReporteHTML(objArray))

            Else
                'Tabla vacia sin resultados de consulta
                Call Response.Write("<script language='Javascript'>alert('Busqueda sin resultados');</script>")
            End If

            strResult.Append("<script language=""javascript"" type=""text/javascript"">")
            strResult.Append("parent.document.getElementById('tblResultados').innerHTML = document.getElementById('divConsultaVisita').innerHTML;")
            strResult.Append("</script>")

            Return strResult.ToString()
        End If

        Return String.Empty
    End Function

    Public Function strTablaConsultaReporteHTML(ByVal objConsultaReporte As Array) As String

        Dim strTablaReporteHTML As StringBuilder
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim strConsultaRegistroReporte As String()
        Dim chkbox As String = Nothing
        Dim idName As String = Nothing
        Dim strConfirmado As String
        Dim strFechaConfirmacion As String

        idName = "id=chkCodigo name=chkCodigo"
        chkbox = "<input type='checkbox' " & idName & " >"

        strTablaReporteHTML = New StringBuilder

        strTablaReporteHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Encabezados de Tabla de Reporte
        strTablaReporteHTML.Append("<tr class='trtitulos'>")
        strTablaReporteHTML.Append("<th width='30%' class='rayita' align='center' valign='top'>Sucursal</th>")
        strTablaReporteHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Afiliación</th>")
        strTablaReporteHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Autorización</th>")
        strTablaReporteHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Importe</th>")
        strTablaReporteHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Fecha de Pagare</th>")
        strTablaReporteHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Fecha <br>  Solicitud</th>")
        strTablaReporteHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Fecha <br> Confirmación <br> Envio</th>")
        strTablaReporteHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Confirmación</th>")

        strTablaReporteHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For Each strConsultaRegistroReporte In objConsultaReporte
            intContador += 1


            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            idName = "id=chkCodigo" & intContador.ToString() & " " & "name=chkCodigo" & intContador.ToString()


            'CheckBox 
            If (CBool(strConsultaRegistroReporte(6)) = False) Then

                'Registro Sin confirmar
                chkbox = "<input type='checkbox'" & idName & ">"
                strConfirmado = "0"
                strFechaConfirmacion = "&nbsp;"

            ElseIf (CBool(strConsultaRegistroReporte(6)) = True) Then

                'Registro Confirmado
                chkbox = "<input type='checkbox'" & idName & " checked disabled='disabled'>"
                strConfirmado = "1"
                strFechaConfirmacion = clsCommons.strFormatearFechaPresentacion(strConsultaRegistroReporte(7))

            End If

            strTablaReporteHTML.Append("<tr>")
            ' Sucursal
            strTablaReporteHTML.Append("<td width='30%' align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroReporte(1)) & " <input type='hidden' id='hdnRegistro" & intContador.ToString() & "' name='hdnRegistro" & intContador.ToString() & "' value='" & strConsultaRegistroReporte(0) & "'></td>")
            ' Afiliación
            strTablaReporteHTML.Append("<td width='10%' align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroReporte(2)) & "</td>")
            ' Autorización
            strTablaReporteHTML.Append("<td width='10%' " & intContador & " align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroReporte(3)) & "</td>")
            ' Importe
            strTablaReporteHTML.Append("<td width='10%' align=right class=" & strColorRegistro & ">" & strConsultaRegistroReporte(4).ToString & "</td>")
            ' Fecha de Pagare
            strTablaReporteHTML.Append("<td width='10%' align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaRegistroReporte(5)) & "</td>")
            ' Fecha <br>  Solicitud
            strTablaReporteHTML.Append("<td width='10%' align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaRegistroReporte(9)) & "</td>")
            ' Fecha <br> Confirmación <br> Envio
            strTablaReporteHTML.Append("<td width='10%' align=center class=" & strColorRegistro & ">" & strFechaConfirmacion & "</td>")
            ' Confirmación
            strTablaReporteHTML.Append("<td width='10%' align=center class=" & strColorRegistro & ">" & chkbox & " <input type='hidden' id='hdnConfirmado" & intContador.ToString() & "' name='hdnConfirmado" & intContador.ToString() & "' value='" & strConfirmado & "'></td>")
            strTablaReporteHTML.Append("</tr>")
        Next

        strTablaReporteHTML.Append("</tr>")
        strTablaReporteHTML.Append("</table>")
        strTablaConsultaReporteHTML = strTablaReporteHTML.ToString

    End Function

    '====================================================================
    ' Name       : strGeneraImpresionReporte
    ' Description: Genera el Record Browser a desplegar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strGeneraImpresionReporte(ByVal objReporte As Array) As String

        Dim strImpresionHTML As New StringBuilder

        If IsArray(objReporte) AndAlso (objReporte.Length > 0) Then

            Dim objRegistro As String() = Nothing
            Dim intContadorRegistro As Integer = 0

            Dim intTotalRenglones As Integer = objReporte.Length
            Dim intRenglon As Integer = 0

            Dim intTotalPaginas As Integer = 0
            Dim intPagina As Integer = 0

            intTotalPaginas = intTotalRenglones \ intRenglonesxPagina

            If intTotalRenglones Mod intRenglonesxPagina > 0 Then
                intTotalPaginas += 1
            Else
                intTotalPaginas = 1
            End If

            intRenglon = 0
            intPagina = 0
            intContadorRegistro = 0

            For Each objRegistro In objReporte

                intRenglon += 1
                intContadorRegistro += 1

                If intRenglon = 1 Then
                    intPagina += 1
                    strImpresionHTML.Append(strImprimeEncabezado(intPagina, intTotalPaginas))
                    strImpresionHTML.Append("<table width='770px' border='0' cellpadding='0' cellspacing='0'> ")
                End If

                strImpresionHTML.Append(strImprimeDetalle(intContadorRegistro, objRegistro))

                If intContadorRegistro = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next

        Else

            strImpresionHTML.Append(strImprimeEncabezado(1, 1))
            strImpresionHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")
            strImpresionHTML.Append("<tr>")
            strImpresionHTML.Append("<td width='02%'>&nbsp;</td>")
            strImpresionHTML.Append("<td class='tdblanco' colspan='7'>No hay registros</td>")
            strImpresionHTML.Append("</tr>")
            strImpresionHTML.Append("</table>")
        End If

        Return strImpresionHTML.ToString

    End Function

    Private Function strImprimeEncabezado(ByVal intPaginaActual As Integer, _
                                          ByVal intTotalPaginas As Integer) As String

        Dim strHtmlEncabezado As New StringBuilder

        If intPaginaActual > 1 Then
            strHtmlEncabezado.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")
        End If

        strHtmlEncabezado.Append("<table width='770px' border='0' cellpadding='0' cellspacing='0'> ")

        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td width='100%'  colspan='10'>&nbsp;</td>")
        strHtmlEncabezado.Append("</tr>")

        'Logo
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='49%' align='left'  colspan='4'><img src='../static/images/" & strCadenaImagen & "/logo.gif' width='125' height='25' border='0'></td>")
        strHtmlEncabezado.Append("<td width='49%' align='right' colspan='4'>Control de Pagares</td>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='49%' align='left'  colspan='4' class='tdtxtImpresionBold'>" & clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</td>")
        strHtmlEncabezado.Append("<td width='49%' align='right' colspan='4' class='tdtxtImpresionBold'>HOJA " & intPaginaActual.ToString & " / " & intTotalPaginas & "</td>")
        strHtmlEncabezado.Append("</tr>")

        'Sucursal
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='98%' align='left' colspan='8' class='tdtxtImpresionBold' nowrap>" & strCentroLogisticoId & " - " & strSucursalNombre & " (" & intCompaniaId.ToString & intSucursalId.ToString("000") & ")" & "</td>")
        strHtmlEncabezado.Append("<tr class='trtitulos'>")

        'Reporte de Visitas      
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='98%' colspan='8'>&nbsp;</td>")
        strHtmlEncabezado.Append("</tr>")

        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td align='left' colspan='9'>Consulta generada por: " & strUsuarioNombre & "</td>")
        strHtmlEncabezado.Append("</tr>")

        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td align='left' colspan='9'>Fecha de Inicio: " & clsCommons.strFormatearFechaPresentacion(CStr(dtmFechaInicio)) & "</td>")
        strHtmlEncabezado.Append("</tr>")

        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td align='left' colspan='9'>Fecha de Fin: " & clsCommons.strFormatearFechaPresentacion(CStr(dtmFechaFin)) & "</td>")
        strHtmlEncabezado.Append("</tr>")

        'Titulos Detalle
        strHtmlEncabezado.Append("<table width='770px' border='0' cellpadding='0' cellspacing='0'> ")
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th width='02%'>&nbsp;</th>")
        strHtmlEncabezado.Append("<th width='28%' align='center' class='tdtxtImpresionBoldRayita'>Sucursal</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtImpresionBoldRayita'>Afiliación</th>")
        strHtmlEncabezado.Append("<th width='10%' align='left'  class='tdtxtImpresionBoldRayita'>Autorización</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtImpresionBoldRayita'>Importe</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtImpresionBoldRayita'>Fecha de Pagare</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtImpresionBoldRayita'>Fecha <br>  Solicitud</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtImpresionBoldRayita'>Fecha <br> Confirmación Envio</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtImpresionBoldRayita'>Confirmación</th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strImprimeEncabezado = strHtmlEncabezado.ToString

    End Function

    Private Function strImprimeDetalle(ByVal intContadorRegistro As Integer, ByVal objReporte As String()) As String

        Dim strColorRegistro As String = String.Empty
        Dim strHtmlDetalle As New StringBuilder
        Dim strFechaConfirmacion As String
        Dim strConfirmacion As String

        If ((intContadorRegistro Mod 2) = 0) Then
            strColorRegistro = "'tdtxtImpresionBold'"
        Else
            strColorRegistro = "'tdtxtImpresionNormal'"
        End If

        'Registro Sin confirmar
        strFechaConfirmacion = "&nbsp;"
        strConfirmacion = "No"

        'Solicitudes confirmadas
        If (CBool(objReporte(6)) = True) Then

            'Registro Confirmado
            strFechaConfirmacion = clsCommons.strFormatearFechaPresentacion(objReporte(7))
            strConfirmacion = "Si"

        End If

        strHtmlDetalle.Append("<tr>")

        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='02%' align='right'>" & intContadorRegistro.ToString & "&nbsp;</td>")
        'strHtmlDetalle.Append("<td width='02%'>&nbsp;</td>")
        'Sucursal
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='28%' align='left'>" & clsCommons.strFormatearDescripcion(objReporte(1).ToString) & "&nbsp;</td>")
        ' Afiliación
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='center'>" & clsCommons.strFormatearDescripcion(objReporte(2).ToString) & "</td>")
        ' Autorización
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='center'>" & clsCommons.strFormatearDescripcion(objReporte(3)) & "</td>")
        'Importe  
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='left'>" & clsCommons.strFormatearDescripcion(objReporte(4).ToString) & "</td>")
        'Fecha de Pagare
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='center'>" & clsCommons.strFormatearFechaPresentacion(objReporte(5)) & "</td>")
        'Fecha <br>  Solicitud
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='left'>" & clsCommons.strFormatearFechaPresentacion(objReporte(9).ToString()) & "</td>")
        'Fecha <br> Confirmación <br> Envio
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='center'>" & strFechaConfirmacion & "</td>")
        ' Confirmación 
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='center'>" & strConfirmacion & "</td>")
        'If(CBool(objReporte(6)) = True, "Si", "No")

        strHtmlDetalle.Append("</tr>")

        Return strHtmlDetalle.ToString

    End Function

End Class