
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration
Imports Benavides.POSAdmin.Commons.clsCommons.clsMSMQ
Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

Public Class SucursalReporteDeVisitas
    Inherits System.Web.UI.Page

    Const strComitasDobles As String = """"

    Private intCboTipoEmpleadoId As Integer
    Private intCboEmpleadosId As Integer
    Public strImpresionReporte As String
    Private intRenglonesxPagina As Integer = 42

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

        intCboTipoEmpleadoId = GetPageParameter("TipoEmpleado", 0)
        intCboEmpleadosId = GetPageParameter("cmbEmpleados", 0)

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
    ' Name       : boolActivos
    ' Description: Empleados Activos
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property boolActivos() As Boolean
        Get
            If Len(Trim(Request("chkActivos"))) > 0 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strEmpleadoNombreId
    ' Description: Toma el id del empleado a buscar
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public ReadOnly Property strEmpleadoNombreId() As String
        Get
            If Not IsNothing(Request.Form("txtEmpleadoNombreId").Trim()) Then
                Return Request("txtEmpleadoNombreId")
            Else
                Return String.Empty
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
        Dim intResultado As Integer

        Dim strHTML As StringBuilder
        strHTML = New StringBuilder

        Select Case strCmd

            Case "BuscarEmpleado"

                Dim objArrayEmpleado As Array = Nothing
                Dim objRegistroEmpleado As System.Collections.SortedList = Nothing

                Dim strBusquedaEmpleadoId As String = String.Empty
                Dim strBusquedaEmpleadoNombreId As String = String.Empty
                Dim strBusquedaEmpleadoNombre As String = String.Empty
                Dim strBusquedaProveedorError As String = "-100"


                objArrayEmpleado = Benavides.CC.Data.clsReporteDeVisitas.strBuscarEmpleadoVisitas(intCompaniaId, intSucursalId, intCboTipoEmpleadoId, boolActivos, strEmpleadoNombreId, strCadenaConexion)

                If IsArray(objArrayEmpleado) AndAlso objArrayEmpleado.Length > 0 Then

                    objRegistroEmpleado = DirectCast(objArrayEmpleado.GetValue(0), System.Collections.SortedList)

                    ' Asignamos los datos del empleado
                    strBusquedaEmpleadoId = clsCommons.strFormatearDescripcion(CStr(objRegistroEmpleado.Item("intEmpleadoId")))
                    strBusquedaEmpleadoNombre = clsCommons.strFormatearDescripcion(CStr(objRegistroEmpleado.Item("Nombre")))
                    strBusquedaProveedorError = "0"

                End If

                'End If

                strHTML.Append("<script language='Javascript'> parent.fnUpBuscarEmpleado( " & _
                               strComitasDobles & strBusquedaEmpleadoId & strComitasDobles & "," & _
                               strComitasDobles & strBusquedaEmpleadoNombre & strComitasDobles & "," & _
                               strComitasDobles & strBusquedaProveedorError & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "cmdImprimir"

                Dim objArray As System.Array = Nothing
                Dim strmRecordBrowserHTML As String = String.Empty
                Dim intEmpleadoId As Integer
                Dim strRecordBrowserImpresion As String = String.Empty

                If Not strEmpleadoNombreId = String.Empty Then
                    intEmpleadoId = CInt(strEmpleadoNombreId)
                Else
                    intEmpleadoId = 0
                End If

                'Reporte de Visitas
                objArray = Benavides.CC.Data.clsReporteDeVisitas.strObtenerReporteVisitas(intCompaniaId, intSucursalId, intCboTipoEmpleadoId, boolActivos, intEmpleadoId, dtmFechaInicio, dtmFechaFin, strCadenaConexion)

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
        End Select

    End Sub

    Public Function strTablaConsultaVisita() As String

        Dim objArray As System.Array = Nothing
        Dim strmRecordBrowserHTML As String = String.Empty
        Dim intEmpleadoId As Integer

        If (strCmd = "cmdConsultar") Then

            If Not strEmpleadoNombreId = String.Empty Then
                intEmpleadoId = CInt(strEmpleadoNombreId)
            Else
                intEmpleadoId = 0
            End If

            'Reporte de Visitas
            objArray = Benavides.CC.Data.clsReporteDeVisitas.strObtenerReporteVisitas(intCompaniaId, intSucursalId, intCboTipoEmpleadoId, boolActivos, intEmpleadoId, dtmFechaInicio, dtmFechaFin, strCadenaConexion)

            Dim strResult As New StringBuilder()
            If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then

                'Reporte
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

        strTablaReporteHTML = New StringBuilder

        strTablaReporteHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Encabezados de Tabla de Reporte
        strTablaReporteHTML.Append("<tr class='trtitulos'>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Fecha</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>No. Empleado</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Empleado</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Caja</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Tipo Empleado</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Activo</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Hora Entrada</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Hora Salida</th>")

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

            strTablaReporteHTML.Append("<tr>")
            ' Fecha
            strTablaReporteHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaRegistroReporte(0)) & "</td>")
            ' No. Empleado
            strTablaReporteHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaRegistroReporte(1) & "</td>")
            'Empleado
            strTablaReporteHTML.Append("<td " & intContador & " align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroReporte(2)) & "</td>")
            ' Caja
            strTablaReporteHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaRegistroReporte(3) & "</td>")
            ' Tipo Empleado
            strTablaReporteHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroReporte(4)) & "</td>")
            ' Activo
            strTablaReporteHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroReporte(5)) & "</td>")
            ' Hora Entrada
            strTablaReporteHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaRegistroReporte(6) & "</td>")
            ' Hora Salida 
            strTablaReporteHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaRegistroReporte(7) & "</td>")
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
        strHtmlEncabezado.Append("<td width='100%'  colspan='8'>&nbsp;</td>")
        strHtmlEncabezado.Append("</tr>")

        'Logo
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='49%' align='left'  colspan='4'><img src='../static/images/" & strCadenaImagen & "/logo.gif' width='125' height='25' border='0'></td>")
        strHtmlEncabezado.Append("<td width='49%' align='right' colspan='4'>Reporte de Visitas</td>")
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

        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td align='left' colspan='9'>Tipo de Empleado: " & clsCommons.strFormatearDescripcion(Request.Form("hdnTipoEmpleado").Trim()) & "</td>")
        strHtmlEncabezado.Append("</tr>")

        Dim strEmpleado As String
        strEmpleado = String.Empty

        If ((Request.Form("txtEmpleadoNombre").Trim() = String.Empty)) Then

            strEmpleado = "Todos"
        Else
            strEmpleado = clsCommons.strFormatearDescripcion(Request.Form("txtEmpleadoNombre").Trim())
        End If




        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td align='left' colspan='9'>Empleado: " & strEmpleado & "</td>")
        strHtmlEncabezado.Append("</tr>")

        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td align='left' colspan='9'>Activos: " & CStr(IIf(boolActivos, "Si", "Todos")) & "</td>")
        strHtmlEncabezado.Append("</tr>")

        'Titulos Detalle
        strHtmlEncabezado.Append("<table width='770px' border='0' cellpadding='0' cellspacing='0'> ")
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th width='02%'>&nbsp;</th>")
        strHtmlEncabezado.Append("<th width='08%' align='center' class='tdtxtImpresionBoldRayita'>Fecha" & "</th>")
        strHtmlEncabezado.Append("<th width='14%' align='center' class='tdtxtImpresionBoldRayita'>No.</th>")
        strHtmlEncabezado.Append("<th width='30%' align='left'  class='tdtxtImpresionBoldRayita'>Nombre</th>")
        strHtmlEncabezado.Append("<th width='06%' align='center' class='tdtxtImpresionBoldRayita'>Caja</th>")
        strHtmlEncabezado.Append("<th width='14%' align='center' class='tdtxtImpresionBoldRayita'>Tipo Empleado</th>")
        strHtmlEncabezado.Append("<th width='06%' align='center' class='tdtxtImpresionBoldRayita'>Activo</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtImpresionBoldRayita'>Hora <br> Entrada</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtImpresionBoldRayita'>Hora <br> Salida</th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strImprimeEncabezado = strHtmlEncabezado.ToString

    End Function

    Private Function strImprimeDetalle(ByVal intContadorRegistro As Integer, ByVal objReporte As String()) As String

        Dim strColorRegistro As String = String.Empty
        Dim strHtmlDetalle As New StringBuilder

        If ((intContadorRegistro Mod 2) = 0) Then
            strColorRegistro = "'tdtxtImpresionBold'"
        Else
            strColorRegistro = "'tdtxtImpresionNormal'"
        End If

        strHtmlDetalle.Append("<tr>")

        strHtmlDetalle.Append("<td width='02%'>&nbsp;</td>")
        ' 1 No. de Renglon
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='02%' align='right'>" & intContadorRegistro.ToString & "&nbsp;</td>")
        ' 2 Fecha
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='08%' align='center'>" & clsCommons.strFormatearFechaPresentacion(objReporte(0).ToString) & "</td>")
        ' 3 No.
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='14%' align='center'>" & objReporte(1).ToString() & "</td>")
        ' 4 Empleado
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='30%' align='left'>" & clsCommons.strFormatearDescripcion(objReporte(2).ToString) & "</td>")
        ' 5 Caja
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='06%' align='center'>" & objReporte(3).ToString() & "</td>")
        ' 6 Tipo Empleado
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='14%' align='left'>" & clsCommons.strFormatearDescripcion(objReporte(4).ToString()) & "</td>")
        ' 7 Activo
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='06%' align='center'>" & objReporte(5).ToString() & "</td>")
        ' 8 Hora Entrada
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='center'>" & objReporte(6).ToString() & "</td>")
        ' 9 Hora Entrada
        strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='10%' align='center'>" & objReporte(7).ToString() & "</td>")

        strHtmlDetalle.Append("</tr>")

        Return strHtmlDetalle.ToString

    End Function

End Class

