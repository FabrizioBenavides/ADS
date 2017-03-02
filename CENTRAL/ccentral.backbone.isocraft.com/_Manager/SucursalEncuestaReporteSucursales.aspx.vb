Imports Benavides.POSAdmin.Commons
Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

Public Class SucursalEncuestaReporteSucursales
    Inherits System.Web.UI.Page

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

        'Inicializa Propiedades

        intEncuestaId = GetPageParameter("txtEncuestaId", GetPageParameter("intEncuestaId", 0))
        intPreguntaId = GetPageParameter("txtPreguntaId", GetPageParameter("intPreguntaId", 0))
        intRespuestaId = GetPageParameter("txtRespuestaId", GetPageParameter("intRespuestaId", 0))

        strPreguntaDescripcion = GetPageParameter("hdnPreguntaDescripcion", GetPageParameter("strPreguntaDescripcion", ""))
        strRespuestaDescripcion = GetPageParameter("hdnRespuestaDescripcion", GetPageParameter("strRespuestaDescripcion", ""))

        intDireccionId = GetPageParameter("cboDireccion", 0)
        intZonaId = GetPageParameter("cboZona", 0)
        strSucursalId = GetPageParameter("cboSucursal", "")

        strEncuestaInicio = GetPageParameter("txtEncuestaInicio", "")
        strEncuestaFin = GetPageParameter("txtEncuestaFin", "")

    End Sub

#End Region

#Region " Class Private Attributes"

    Const strComitasDobles As String = """"

    Private strmJavascriptWindowOnLoadCommands As String

    Private intmEncuestaId As Integer
    Private intmPreguntaId As Integer
    Private intmRespuestaId As Integer

    Private strmPreguntaDescripcion As String
    Private strmRespuestaDescripcion As String

    Private intmDireccionId As Integer
    Private intmZonaId As Integer
    Private strmSucursalId As String

    Private strmCboDireccion As String
    Private strmCboZona As String
    Private strmCboSucursal As String

    Private strmtxtFechaInicial As String
    Private strmtxtFechaFinal As String

    Private strmRecordBrowserHTML As String = ""
    Private strmRecordBrowserArchivo As String = ""
    Private strmRecordBrowserImpresion As String = ""


#End Region

    Public ReadOnly Property intRenglonesxPagina() As Integer
        Get
            Return 46
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
            Return Server.UrlEncode(GetPageName())
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
    ' Name       : strCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return GetPageParameter("strCmd", "")
        End Get
    End Property

    '====================================================================
    ' Name       : intEncuestaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intEncuestaId() As Integer
        Get
            Return intmEncuestaId
        End Get
        Set(ByVal intValue As Integer)
            intmEncuestaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intPreguntaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intPreguntaId() As Integer
        Get
            Return intmPreguntaId
        End Get
        Set(ByVal intValue As Integer)
            intmPreguntaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intRespuestaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intRespuestaId() As Integer
        Get
            Return intmRespuestaId
        End Get
        Set(ByVal intValue As Integer)
            intmRespuestaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strPreguntaDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : string
    '====================================================================
    Public Property strPreguntaDescripcion() As String
        Get
            Return (strmPreguntaDescripcion)
        End Get
        Set(ByVal Value As String)
            strmPreguntaDescripcion = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strRecorBrowserPreguntas
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strRecorBrowserPreguntas() As String

        If intEncuestaId < 1 Then
            Return ""
        End If

        ' Declaramos e inicializamos las variables locales
        Dim strColorRegistro As String

        Dim ArrayPregunta As Array = Benavides.CC.Data.clsEncuesta.strBuscarPreguntaEncuesta(0, intEncuestaId, True, 0, 0, strConnectionString)
        Dim RegistroPregunta As System.Collections.SortedList

        Dim strHTML As New System.Text.StringBuilder

        strHTML.Append("")

        ' Si el elemento fue encontrado
        If IsNothing(ArrayPregunta) = False AndAlso ArrayPregunta.Length > 0 Then

            Dim rptPreguntaId As Integer
            Dim rptPreguntaEncuestaAsociada As String
            Dim rptPreguntaDescripcion As String

            Dim intContadorPregunta As Integer

            strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")


            strHTML.Append("<tr class='trtitulos'>")
            strHTML.Append("<th width='10%' class='rayita' align='left'>No.</th>")
            strHTML.Append("<th width='40%' class='rayita' align='left'>Encuesta Asociada</th>")
            strHTML.Append("<th width='40%' class='rayita' align='left'>Pregunta en POS</th>")
            strHTML.Append("<th width='10%' class='rayita' align='left'>Acci&oacute;n</th>")
            strHTML.Append("</tr>")


            intContadorPregunta = 0

            For Each RegistroPregunta In ArrayPregunta
                intContadorPregunta += 1

                If (intContadorPregunta Mod 2) <> 0 Then
                    strColorRegistro = "'tdblanco'"
                Else
                    strColorRegistro = "'tdceleste'"

                End If

                rptPreguntaId = CInt(RegistroPregunta.Item("intPreguntaId"))
                rptPreguntaEncuestaAsociada = clsCommons.strFormatearDescripcion(CStr(RegistroPregunta.Item("strPreguntaEncuestaAsociada")))
                rptPreguntaDescripcion = clsCommons.strFormatearDescripcion(CStr(RegistroPregunta.Item("strPreguntaDescripcion")))

                strHTML.Append("<tr>")
                strHTML.Append("<td width='10%' class=" & strColorRegistro & " align='left'>" & intContadorPregunta.ToString & "</td>") ' No
                strHTML.Append("<td width='40%' class=" & strColorRegistro & " align='left'>" & rptPreguntaEncuestaAsociada.ToString & "</td>") 'Encuesta Asociada
                strHTML.Append("<td width='40%' class=" & strColorRegistro & " align='left'>" & rptPreguntaDescripcion.ToString & "</td>") ' Pregunta Descripción
                strHTML.Append("<td width='10%' class=" & strColorRegistro & " align='center'>" & "<a href='javascript:fnVerReporte(" & rptPreguntaId.ToString & "," & strComitasDobles & rptPreguntaDescripcion & strComitasDobles & ");'><img src='../static/images/icono_ver.gif' alt='Ver Respuestas' width='11' height='13' border='0' align='absmiddle'></a>&nbsp;&nbsp;</td>")   ' accion
                strHTML.Append("</tr>")

            Next
            strHTML.Append("</table><br>")

            strHTML.Append("<table class='tdenvolventetablas' width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strHTML.Append("<tr>")
            strHTML.Append("<td align='left'> <input class='campotablaresultadoenvolventerojo' readOnly type='text' name='txtPreguntaDescripcion' size='100%'></td>") ' Pregunta Seleccionada
            strHTML.Append("</tr>")
            strHTML.Append("</table>")


        End If

        Return strHTML.ToString

    End Function

    '====================================================================
    ' Name       : strRespuestaDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : string
    '====================================================================
    Public Property strRespuestaDescripcion() As String
        Get
            Return (strmRespuestaDescripcion)
        End Get
        Set(ByVal Value As String)
            strmRespuestaDescripcion = Value
        End Set
    End Property

    
    '====================================================================
    ' Name       : strLlenarDireccionComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboDireccion"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarDireccionComboBox() As String
        Dim aobjDirecciones As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString)
        Dim strRegistrosDirecciones As String()

        Dim aobjDirFarmacias As New System.Collections.ArrayList

        For Each strRegistrosDirecciones In aobjDirecciones

            aobjDirFarmacias.Add(strRegistrosDirecciones)

        Next

        'Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString)

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccion", intDireccionId, aobjDirFarmacias.ToArray, 0, 1, 2)


    End Function

    '====================================================================
    ' Name       : strLlenarZonaComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboZona"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarZonaComboBox() As String
        If intDireccionId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZona", intZonaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, 0, strConnectionString), 0, 1, 2)
        End If
    End Function

    '====================================================================
    ' Name       : strLlenarSucursalComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboSucursal"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarSucursalComboBox() As String
        If intDireccionId > 0 AndAlso intZonaId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSucursal", strSucursalId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, intZonaId, strConnectionString), New Integer(1) {0, 1}, 2, 2)
        End If
    End Function


    '====================================================================
    ' Name       : intDireccionId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intDireccionId() As Integer
        Get
            Return intmDireccionId
        End Get
        Set(ByVal intValue As Integer)
            intmDireccionId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intZonaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intZonaId() As Integer
        Get
            Return intmZonaId
        End Get
        Set(ByVal intValue As Integer)
            intmZonaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strSucursalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strSucursalId() As String
        Get
            Return strmSucursalId
        End Get
        Set(ByVal intValue As String)
            strmSucursalId = intValue
        End Set
    End Property

    Public ReadOnly Property intCompaniaid() As Integer
        Get
            Dim intmCompaniaid As Integer = 0

            If Len(strSucursalId) > 3 Then
                Dim astrCompaniaSucursal As Array = Split(strSucursalId, "|")
                If astrCompaniaSucursal.Length > 0 Then
                    intmCompaniaid = CInt(astrCompaniaSucursal.GetValue(0))
                End If
            End If

            Return intmCompaniaid

        End Get

    End Property

    Public ReadOnly Property intSucursalid() As Integer
        Get
            Dim intmSucursalid As Integer = 0

            If Len(strSucursalId) > 3 Then
                Dim astrCompaniaSucursal As Array = Split(strSucursalId, "|")
                If astrCompaniaSucursal.Length > 0 Then
                    intmSucursalid = CInt(astrCompaniaSucursal.GetValue(1))
                End If
            End If

            Return intmSucursalid

        End Get

    End Property

    '====================================================================
    ' Name       : strEncuestaInicio
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strEncuestaInicio() As String
        Get
            Return strmtxtFechaInicial
        End Get
        Set(ByVal strValue As String)
            strmtxtFechaInicial = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strtxtFechaFinal
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strEncuestaFin() As String
        Get
            Return strmtxtFechaFinal
        End Get
        Set(ByVal strValue As String)
            strmtxtFechaFinal = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRecordBrowserHTML() As String
        Get
            Return strmRecordBrowserHTML
        End Get
        Set(ByVal Value As String)
            strmRecordBrowserHTML = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowserImpresion
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRecordBrowserImpresion() As String
        Get
            Return strmRecordBrowserImpresion
        End Get
        Set(ByVal Value As String)
            strmRecordBrowserImpresion = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowserArchivo
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRecordBrowserArchivo() As String
        Get
            Return strmRecordBrowserArchivo
        End Get
        Set(ByVal Value As String)
            strmRecordBrowserArchivo = Value
        End Set
    End Property

    

    Function fnReportePregunta() As Boolean

        Dim ArrayReporteEncuesta As Array = Benavides.CC.Data.clsEncuesta.strBuscarReportePregunta(intDireccionId, intZonaId, intCompaniaid, intSucursalid, intEncuestaId, intPreguntaId, CDate(clsCommons.strDMYtoMDY(strEncuestaInicio)), CDate(clsCommons.strDMYtoMDY(strEncuestaFin)), strConnectionString)

        ' Si se encontraron resultados para el reporte solicitado segun criterios de busqueda
        If IsNothing(ArrayReporteEncuesta) = False AndAlso ArrayReporteEncuesta.Length > 0 Then

            ' Declaramos e inicializamos las variables locales
            Dim RegistroEncuesta As System.Collections.SortedList
            Dim intContadorRegistroEncuesta As Integer = 0

            Dim strHTMLPagina As New System.Text.StringBuilder
            Dim strHTMLImpresion As New System.Text.StringBuilder
            Dim strArchivoExcel As New System.Text.StringBuilder

            Dim strColorRegistro As String

            Dim intPagina As Integer = 0
            Dim intRenglon As Integer = 0
            Dim intTotalRenglones As Integer = 0
            Dim intTotalPaginas As Integer = 0

            Dim strNombre As String
            Dim strEncabezado1 As String
            Dim strEncabezado2 As String
            Dim strEncabezado3 As String
            Dim strEncabezado4 As String
            Dim strEncabezado5 As String
            Dim strEncabezadoDir As String
            Dim strEncabezadoZon As String
            Dim strEncabezadoCia As String
            Dim strEncabezadoSuc As String

            intTotalRenglones = ArrayReporteEncuesta.Length - 2
            intTotalPaginas = intTotalRenglones \ intRenglonesxPagina

            If intTotalRenglones Mod intRenglonesxPagina > 0 Then
                intTotalPaginas += 1
            Else
                intTotalPaginas = 1
            End If

            intRenglon = 0
            intPagina = 0
            intContadorRegistroEncuesta = 0

            strHTMLPagina = New System.Text.StringBuilder
            strHTMLImpresion = New System.Text.StringBuilder
            strArchivoExcel = New System.Text.StringBuilder

            For Each RegistroEncuesta In ArrayReporteEncuesta

                strNombre = clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strNombre")))

                If strNombre <> "ENCABEZADO" And strNombre <> "TOTALES" Then
                    intContadorRegistroEncuesta += 1
                End If


                ' INICIA GENERACION DE CONSULTA EN PANTALLA
                '----------------------------------------------------------------------------

                If strNombre = "ENCABEZADO" Then

                    strEncabezado1 = clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_1")))
                    strEncabezado2 = clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_2")))
                    strEncabezado3 = clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_3")))
                    strEncabezado4 = clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_4")))
                    strEncabezado5 = clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_5")))

                    strHTMLPagina.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

                    strHTMLPagina.Append("<tr class='trtitulos'>")

                    strHTMLPagina.Append("<th width='02%' class='rayita' align='left'>No.</th>")
                    strHTMLPagina.Append("<th width='25%' class='rayita' align='left'>Nombre</th>")

                    If Len(strEncabezado1) > 0 Then
                        strHTMLPagina.Append("<th width='13%' class='rayita' align='right' colspan='2' style='color:#0033cc;font-weight: bold;'>" & strEncabezado1 & "</th>")
                    End If
                    If Len(strEncabezado2) > 0 Then
                        strHTMLPagina.Append("<th width='13%' class='rayita' align='right' colspan='2'>" & strEncabezado2 & "</th>")
                    End If
                    If Len(strEncabezado3) > 0 Then
                        strHTMLPagina.Append("<th width='13%' class='rayita' align='right' colspan='2' style='color:#0033cc;font-weight: bold;'>" & strEncabezado3 & "</th>")
                    End If
                    If Len(strEncabezado4) > 0 Then
                        strHTMLPagina.Append("<th width='13%' class='rayita' align='right' colspan='2'>" & strEncabezado4 & "</th>")
                    End If
                    If Len(strEncabezado5) > 0 Then
                        strHTMLPagina.Append("<th width='13%' class='rayita' align='right' colspan='2' style='color:#0033cc;font-weight: bold;'>" & strEncabezado5 & "</th>")
                    End If

                    strHTMLPagina.Append("<th width='08%' class='rayita' align='right' style='color:#C00000;font-weight:bold;'>TOTAL&nbsp;</th>")

                    strHTMLPagina.Append("</tr>")


                ElseIf strNombre = "TOTALES" Then

                    strHTMLPagina.Append("<tr class='trtitulos'>")

                    strHTMLPagina.Append("<th width='02%' class='rayita3' align='left'>&nbsp;</th>")
                    strHTMLPagina.Append("<th width='25%' class='rayita3' align='right'>TOTALES:</th>")

                    If Len(strEncabezado1) > 0 Then
                        strHTMLPagina.Append("<th width='05%' class='rayita3' align='right' style='color:#0033cc;font-weight: bold;'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_1"))) & "</th>")
                        strHTMLPagina.Append("<th width='08%' class='rayita3' align='right' >&nbsp;</th>")
                    End If
                    If Len(strEncabezado2) > 0 Then
                        strHTMLPagina.Append("<th width='05%' class='rayita3' align='right' >" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_2"))) & "</th>")
                        strHTMLPagina.Append("<th width='08%' class='rayita3' align='right' >&nbsp;</th>")
                    End If
                    If Len(strEncabezado3) > 0 Then
                        strHTMLPagina.Append("<th width='05%' class='rayita3' align='right' style='color:#0033cc;font-weight: bold;'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_3"))) & "</th>")
                        strHTMLPagina.Append("<th width='08%' class='rayita3' align='right' >&nbsp;</th>")
                    End If
                    If Len(strEncabezado4) > 0 Then
                        strHTMLPagina.Append("<th width='05%' class='rayita3' align='right' >" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_4"))) & "</th>")
                        strHTMLPagina.Append("<th width='08%' class='rayita3' align='right' >&nbsp;</th>")
                    End If
                    If Len(strEncabezado5) > 0 Then
                        strHTMLPagina.Append("<th width='05%' class='rayita3' align='right' style='color:#0033cc;font-weight: bold;'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_5"))) & "</th>")
                        strHTMLPagina.Append("<th width='08%' class='rayita3' align='right' >&nbsp;</th>")
                    End If

                    strHTMLPagina.Append("<th width='08%' class='rayita3' align='right' colspan='2' style='color:#C00000;font-weight:bold;'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_T"))) & "&nbsp;</th>")

                    strHTMLPagina.Append("</tr>")

                    strHTMLPagina.Append("</table>")

                Else
                    If (intContadorRegistroEncuesta Mod 2) <> 0 Then
                        strColorRegistro = "'tdceleste'"
                    Else
                        strColorRegistro = "'tdblanco'"
                    End If

                    strHTMLPagina.Append("<tr>")

                    strHTMLPagina.Append("<td width='02%' class=" & strColorRegistro & " align='right'>" & intContadorRegistroEncuesta.ToString & "</td>") ' No
                    strHTMLPagina.Append("<td width='25%' class=" & strColorRegistro & " align='left'>" & strNombre.ToString & "</td>") ' strNombre

                    If Len(strEncabezado1) > 0 Then
                        strHTMLPagina.Append("<td width='08%' class=" & strColorRegistro & " align='right' style='color:#0033cc;font-weight: bold;'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_1"))) & "</td>")
                        strHTMLPagina.Append("<td width='05%' class=" & strColorRegistro & " align='right' style='color:#0033cc;'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strPorcentaje_1"))) & "%</td>")
                    End If
                    If Len(strEncabezado2) > 0 Then
                        strHTMLPagina.Append("<td width='08%' class=" & strColorRegistro & " align='right' style='font-weight: bold;'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_2"))) & "</td>")
                        strHTMLPagina.Append("<td width='05%' class=" & strColorRegistro & " align='right'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strPorcentaje_2"))) & "%&nbsp;&nbsp;</td>")
                    End If
                    If Len(strEncabezado3) > 0 Then
                        strHTMLPagina.Append("<td width='08%' class=" & strColorRegistro & " align='right' style='color:#0033cc;font-weight: bold;'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_3"))) & "</td>")
                        strHTMLPagina.Append("<td width='05%' class=" & strColorRegistro & " align='right' style='color:#0033cc'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strPorcentaje_3"))) & "%</td>")
                    End If
                    If Len(strEncabezado4) > 0 Then
                        strHTMLPagina.Append("<td width='08%' class=" & strColorRegistro & " align='right' style='font-weight: bold;'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_4"))) & "</td>")
                        strHTMLPagina.Append("<td width='05%' class=" & strColorRegistro & " align='right'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strPorcentaje_4"))) & "%&nbsp;&nbsp;</td>")
                    End If
                    If Len(strEncabezado5) > 0 Then
                        strHTMLPagina.Append("<td width='08%' class=" & strColorRegistro & " align='right' style='color:#0033cc;font-weight: bold;'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_5"))) & "</td>")
                        strHTMLPagina.Append("<td width='05%' class=" & strColorRegistro & " align='right' style='color:#0033cc'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strPorcentaje_5"))) & "%</td>")
                    End If

                    strHTMLPagina.Append("<td width='08%' class=" & strColorRegistro & " align='right' style='color:#C00000;'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_T"))) & "&nbsp;</td>")

                    strHTMLPagina.Append("</tr>")

                End If
                ' TERMINA GENERACION DE CONSULTA EN PANTALLA
                '----------------------------------------------------------------------------




                ' INICIA GENERACION PARA IMPRESION Y EXPORTACION A ARCHIVO EXCEL
                '----------------------------------------------------------------------------

                If CStr(RegistroEncuesta.Item("strNombre")) = "ENCABEZADO" Then

                    strEncabezado1 = clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_1")))
                    strEncabezado2 = clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_2")))
                    strEncabezado3 = clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_3")))
                    strEncabezado4 = clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_4")))
                    strEncabezado5 = clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_5")))

                    strEncabezadoDir = clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("intDireccionOperativaId")))
                    strEncabezadoZon = clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("intZonaOperativaId")))
                    strEncabezadoCia = clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("intCompaniaId")))
                    strEncabezadoSuc = clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("intSucursalId")))

                ElseIf CStr(RegistroEncuesta.Item("strNombre")) = "TOTALES" Then

                    strHTMLImpresion.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
                    strHTMLImpresion.Append("<tr class='trtitulos'>")

                    strHTMLImpresion.Append("<th width='08%' class='rayita3' align='left'>&nbsp;</th>")
                    strHTMLImpresion.Append("<th width='22%' class='rayita3' align='left'>Totales:</th>")

                    Call strArchivoExcel.Append(vbCrLf)

                    Call strArchivoExcel.Append(" ")
                    Call strArchivoExcel.Append(",")

                    If CInt(strEncabezadoDir) > 0 Then
                        Call strArchivoExcel.Append(" ")
                        Call strArchivoExcel.Append(",")
                    End If
                    If CInt(strEncabezadoZon) > 0 Then
                        Call strArchivoExcel.Append(" ")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append(" ")
                        Call strArchivoExcel.Append(",")
                    End If
                    If CInt(strEncabezadoCia) > 0 Or CInt(strEncabezadoSuc) > 0 Then
                        Call strArchivoExcel.Append(" ")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append(" ")
                        Call strArchivoExcel.Append(",")
                    End If

                    Call strArchivoExcel.Append("Totales")
                    Call strArchivoExcel.Append(",")

                    If Len(strEncabezado1) > 0 Then
                        strHTMLImpresion.Append("<th width='05%' class='rayita3' align='right'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_1"))) & "</th>")
                        strHTMLImpresion.Append("<th width='08%' class='rayita3' align='right' >&nbsp;</th>")

                        Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_1"))))
                        Call strArchivoExcel.Append(",,")

                    End If
                    If Len(strEncabezado2) > 0 Then
                        strHTMLImpresion.Append("<th width='05%' class='rayita3' align='right'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_2"))) & "</th>")
                        strHTMLImpresion.Append("<th width='08%' class='rayita3' align='right' >&nbsp;</th>")

                        Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_2"))))
                        Call strArchivoExcel.Append(",,")

                    End If
                    If Len(strEncabezado3) > 0 Then
                        strHTMLImpresion.Append("<th width='05%' class='rayita3' align='right'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_3"))) & "</th>")
                        strHTMLImpresion.Append("<th width='08%' class='rayita3' align='right' >&nbsp;</th>")

                        Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_3"))))
                        Call strArchivoExcel.Append(",,")
                    End If
                    If Len(strEncabezado4) > 0 Then
                        strHTMLImpresion.Append("<th width='05%' class='rayita3' align='right'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_4"))) & "</th>")
                        strHTMLImpresion.Append("<th width='08%' class='rayita3' align='right' >&nbsp;</th>")

                        Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_4"))))
                        Call strArchivoExcel.Append(",,")
                    End If
                    If Len(strEncabezado5) > 0 Then
                        strHTMLImpresion.Append("<th width='05%' class='rayita3' align='right'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_5"))) & "</th>")
                        strHTMLImpresion.Append("<th width='08%' class='rayita3' align='right' >&nbsp;</th>")

                        Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_5"))))
                        Call strArchivoExcel.Append(",,")
                    End If

                    strHTMLImpresion.Append("<th width='08%' class='rayita3' align='right'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_T"))) & "</th>")

                    strHTMLImpresion.Append("</tr>")
                    strHTMLImpresion.Append("</table>")

                    Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_T"))))
                    Call strArchivoExcel.Append(vbCrLf)

                Else 'REGISTRO DETALLE

                    intRenglon += 1

                    If intRenglon = 1 Then 'IMPRIME HEDER DE PAGINA

                        intPagina += 1

                        If intPagina > 1 Then
                            strHTMLImpresion.Append("<p class='breakhere'></p>")
                            Call strArchivoExcel.Append(vbCrLf)
                        End If

                        strHTMLImpresion.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                        'Inicio 
                        strHTMLImpresion.Append("<tr class='trtitulos'>")
                        strHTMLImpresion.Append("<th align='left'   colspan='6'  class='tdblancoSinRaya'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
                        strHTMLImpresion.Append("<th align='right'  colspan='7'  class='tdblancoSinRaya'>HOJA " & intPagina.ToString & " / " & intTotalPaginas.ToString & "</th>")
                        strHTMLImpresion.Append("</tr>")

                        'Titulo 
                        strHTMLImpresion.Append("<tr class='trtitulos'>")
                        strHTMLImpresion.Append("<th align='center' colspan='13'  class='tdblancoSinRaya'>REPORTE ENCUESTAS DE SUCURSALES</th>")
                        strHTMLImpresion.Append("</tr>")

                        Call strArchivoExcel.Append("REPORTE ENCUESTAS DE SUCURSALES")
                        Call strArchivoExcel.Append(vbCrLf)
                        Call strArchivoExcel.Append(vbCrLf)

                        'Encuesta
                        strHTMLImpresion.Append("<tr class='trtitulos'>")
                        strHTMLImpresion.Append("<th align='left' colspan='13'  class='tdblancoSinRaya'>Encuesta: " & Request("txtEncuestaNombre") & "</th>")
                        strHTMLImpresion.Append("</tr>")

                        Call strArchivoExcel.Append("Encuesta: ")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append(Request("txtEncuestaNombre"))
                        Call strArchivoExcel.Append(vbCrLf)

                        'Pregunta
                        strHTMLImpresion.Append("<tr class='trtitulos'>")
                        strHTMLImpresion.Append("<th align='left' colspan='13'  class='tdblancoSinRaya'>Pregunta: " & Request("hdnPreguntaDescripcion") & "</th>")
                        strHTMLImpresion.Append("</tr>")

                        Call strArchivoExcel.Append("Pregunta: ")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append(Request("hdnPreguntaDescripcion"))
                        Call strArchivoExcel.Append(vbCrLf)

                        'Titulos
                        strHTMLImpresion.Append("<tr class='trtitulos'>")

                        strHTMLImpresion.Append("<th width='02%' align='right' class='tdblancoSinRaya'>" & "No." & "</th>")
                        strHTMLImpresion.Append("<th width='25%' align='left'  class='tdblancoSinRaya'>" & "Nombre" & "</th>")

                        Call strArchivoExcel.Append(vbCrLf)
                        Call strArchivoExcel.Append("No.")
                        Call strArchivoExcel.Append(",")
                        If CInt(strEncabezadoDir) > 0 Then
                            Call strArchivoExcel.Append("Direccion Operativa")
                            Call strArchivoExcel.Append(",")
                        End If
                        If CInt(strEncabezadoZon) > 0 Then
                            Call strArchivoExcel.Append("Direccion Operativa")
                            Call strArchivoExcel.Append(",")
                            Call strArchivoExcel.Append("Zona Operativa")
                            Call strArchivoExcel.Append(",")
                        End If
                        If CInt(strEncabezadoCia) > 0 Or CInt(strEncabezadoSuc) > 0 Then
                            Call strArchivoExcel.Append("Compania")
                            Call strArchivoExcel.Append(",")
                            Call strArchivoExcel.Append("Sucursal")
                            Call strArchivoExcel.Append(",")
                        End If

                        Call strArchivoExcel.Append("Nombre")
                        Call strArchivoExcel.Append(",")

                        If Len(strEncabezado1) > 0 Then
                            strHTMLImpresion.Append("<th width='13%' class='tdblancoSinRaya' align='right' colspan='2'>" & strEncabezado1 & "</th>")

                            Call strArchivoExcel.Append(strEncabezado1)
                            Call strArchivoExcel.Append(",,")
                        End If
                        If Len(strEncabezado2) > 0 Then
                            strHTMLImpresion.Append("<th width='13%' class='tdblancoSinRaya' align='right' colspan='2'>" & strEncabezado2 & "</th>")

                            Call strArchivoExcel.Append(strEncabezado2)
                            Call strArchivoExcel.Append(",,")
                        End If
                        If Len(strEncabezado3) > 0 Then
                            strHTMLImpresion.Append("<th width='13%' class='tdblancoSinRaya' align='right' colspan='2'>" & strEncabezado3 & "</th>")

                            Call strArchivoExcel.Append(strEncabezado3)
                            Call strArchivoExcel.Append(",,")
                        End If
                        If Len(strEncabezado4) > 0 Then
                            strHTMLImpresion.Append("<th width='13%' class='tdblancoSinRaya' align='right' colspan='2'>" & strEncabezado4 & "</th>")

                            Call strArchivoExcel.Append(strEncabezado4)
                            Call strArchivoExcel.Append(",,")
                        End If
                        If Len(strEncabezado5) > 0 Then
                            strHTMLImpresion.Append("<th width='13%' class='tdblancoSinRaya' align='right' colspan='2'>" & strEncabezado5 & "</th>")

                            Call strArchivoExcel.Append(strEncabezado5)
                            Call strArchivoExcel.Append(",,")
                        End If

                        strHTMLImpresion.Append("<th width='08%' class='tdblancoSinRaya' align='right'>TOTAL&nbsp;</th>")

                        Call strArchivoExcel.Append("TOTAL")
                        Call strArchivoExcel.Append(vbCrLf)

                        strHTMLImpresion.Append("</tr>")

                        'Raya Sola
                        strHTMLImpresion.Append("<tr class='trtitulos'>")
                        strHTMLImpresion.Append("<th colspan= '13' width='100%'  class='rayita'>" & "&nbsp;" & "</th>")
                        strHTMLImpresion.Append("</tr>")

                    End If 'TERMINA HEADER DE PAGINA

                    Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(intContadorRegistroEncuesta.ToString))
                    Call strArchivoExcel.Append(",")

                    If CInt(strEncabezadoDir) > 0 Then
                        Call strArchivoExcel.Append(RegistroEncuesta.Item("intDireccionOperativaId"))
                        Call strArchivoExcel.Append(",")
                    End If
                    If CInt(strEncabezadoZon) > 0 Then
                        Call strArchivoExcel.Append(RegistroEncuesta.Item("intDireccionOperativaId"))
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append(RegistroEncuesta.Item("intZonaOperativaId"))
                        Call strArchivoExcel.Append(",")
                    End If
                    If CInt(strEncabezadoCia) > 0 Or CInt(strEncabezadoSuc) > 0 Then
                        Call strArchivoExcel.Append(RegistroEncuesta.Item("intCompaniaId"))
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append(RegistroEncuesta.Item("intSucursalId"))
                        Call strArchivoExcel.Append(",")
                    End If

                    Call strArchivoExcel.Append(strNombre)
                    Call strArchivoExcel.Append(",")

                    If ((intRenglon Mod 2) = 0) Then
                        strColorRegistro = "tdtxtImpresionNormal"
                    Else
                        strColorRegistro = "tdtxtImpresionBold"
                    End If

                    strHTMLImpresion.Append("<tr>")
                    strHTMLImpresion.Append("<td width='02%' align='right' class='" & strColorRegistro & "' nowrap>" & clsCommons.strFormatearDescripcion(intContadorRegistroEncuesta.ToString) & "</td>") 'No. de Renglon
                    strHTMLImpresion.Append("<td width='05%' align='left'  class='" & strColorRegistro & "' nowrap >" & strNombre & "</td>")

                    If Len(strEncabezado1) > 0 Then
                        strHTMLImpresion.Append("<td width='05%' align='right' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_1"))) & "</td>")
                        strHTMLImpresion.Append("<td width='08%' align='right' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strPorcentaje_1"))) & "</td>")

                        Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_1"))))
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strPorcentaje_1"))))
                        Call strArchivoExcel.Append(",")

                    End If

                    If Len(strEncabezado2) > 0 Then
                        strHTMLImpresion.Append("<td width='05%' align='right' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_2"))) & "</td>")
                        strHTMLImpresion.Append("<td width='08%' align='right' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strPorcentaje_2"))) & "</td>")

                        Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_2"))))
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strPorcentaje_2"))))
                        Call strArchivoExcel.Append(",")
                    End If

                    If Len(strEncabezado3) > 0 Then
                        strHTMLImpresion.Append("<td width='05%' align='right' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_3"))) & "</td>")
                        strHTMLImpresion.Append("<td width='08%' align='right' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strPorcentaje_3"))) & "</td>")

                        Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_3"))))
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strPorcentaje_3"))))
                        Call strArchivoExcel.Append(",")
                    End If

                    If Len(strEncabezado4) > 0 Then
                        strHTMLImpresion.Append("<td width='05%' align='right' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_4"))) & "</td>")
                        strHTMLImpresion.Append("<td width='08%' align='right' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strPorcentaje_4"))) & "</td>")

                        Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_4"))))
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strPorcentaje_4"))))
                        Call strArchivoExcel.Append(",")
                    End If

                    If Len(strEncabezado5) > 0 Then
                        strHTMLImpresion.Append("<td width='05%' align='right' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_5"))) & "</td>")
                        strHTMLImpresion.Append("<td width='08%' align='right' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strPorcentaje_5"))) & "</td>")

                        Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_5"))))
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strPorcentaje_5"))))
                        Call strArchivoExcel.Append(",")

                    End If
                    strHTMLImpresion.Append("<td width='08%' align='right' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_T"))) & "</td>")

                    strHTMLImpresion.Append("</tr>")

                    Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(CStr(RegistroEncuesta.Item("strCantidad_T"))))
                    Call strArchivoExcel.Append(vbCrLf)

                    If intContadorRegistroEncuesta = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                        strHTMLImpresion.Append("</table>")
                        intRenglon = 0
                    End If

                End If
                ' TERMINA GENERACION PARA IMPRESION Y EXPORTACION A ARCHIVO EXCEL
                '----------------------------------------------------------------------------


            Next

            strRecordBrowserHTML = strHTMLPagina.ToString
            strRecordBrowserImpresion = strHTMLImpresion.ToString
            strRecordBrowserArchivo = strArchivoExcel.ToString

        End If

    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        strRecordBrowserHTML = ""
        strRecordBrowserArchivo = ""
        strRecordBrowserImpresion = ""

        If strCmd = "Consultar" Or strCmd = "Exportar" Then

            If intDireccionId = -1 Then
                intZonaId = -1
            End If

            If intZonaId = -1 Then
                strSucursalId = "-1|-1"
            End If

            If intDireccionId <> 0 And intZonaId <> 0 And Len(strSucursalId) > 0 And intEncuestaId > 0 And intPreguntaId > 0 Then
                fnReportePregunta()
            End If

            If Len(strRecordBrowserArchivo) > 1 And strCmd = "Exportar" Then
                ' Establecemos en la respuesta los parámetros de configuración del archivo
                Response.ContentType = "application/octet-stream"
                Call Response.AddHeader("Content-Disposition", "attachment;filename=""SucursalReporteEncuestas.csv""")
                Call Response.Write(strRecordBrowserArchivo)
                Call Response.End()
            End If


        End If

    End Sub

End Class
