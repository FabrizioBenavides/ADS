
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
Imports Microsoft
'Imports Microsoft.VisualBasic.FileIO
'Imports Microsoft.Office.Interop.Excel
'Imports Excel = Microsoft.Office.Interop.Excel

Public Class ControlAsistenciaArchivoAdam
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
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)
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
    ' Name       : strToday
    ' Description: Regresa la fecha del dia de hoy
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strToday() As String
        Get
            If IsNothing(Request.Form("dtmFechaPago")) Then
                Return New Date(Date.Today.Year, Date.Today.Month, Date.Today.Day).ToString("dd/MM/yyyy")
            Else
                Return Request.Form("dtmFechaPago")
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
    ' Name       : intTipoNomina
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTipoNomina() As Integer
        Get
            If Not IsNothing(Request.Form("cmdTipoNomina")) Then
                Return CInt(Request.Form("cmdTipoNomina"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaPago
    ' Description: Fecha de fin  a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaPago() As Date
        Get
            Dim f As String = Request.Form("dtmFechaPago")
            If Not IsNothing(f) Then
                Dim fp As String() = f.Split("/".ToCharArray())

                Return New Date(CInt(fp(2)), CInt(fp(1)), CInt(fp(0)))
            Else
                Return CDate("01/01/1900")
            End If
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
            Return GetPageParameter("strCmd", "")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Or Not intTipoUsuarioId = 1 Or CInt(strUsuarioNombre) = 40014547 Then
            Call Response.Redirect("../Default.aspx")
        End If

        If (strCmd = "cmdInformacionGenerarArchivo") Then


            Dim intRegistrosConfirmados As Integer
            Dim intTotalDeRegistros As Integer
            Dim strHTML As New StringBuilder
            Const strComitasDobles As String = """"
            Dim objDataArrayInfoArchivoAdam As Array = Nothing

            objDataArrayInfoArchivoAdam = Benavides.CC.Data.clsControlDeAsistencia.strInformacionArchivoAdamPorGenerar(intTipoNomina, dtmFechaInicio, dtmFechaFin, strConnectionString)

            If IsArray(objDataArrayInfoArchivoAdam) AndAlso objDataArrayInfoArchivoAdam.Length > 0 Then


                Dim strRegistrosArchivoAdam As String() = Nothing

                For Each strRegistrosArchivoAdam In objDataArrayInfoArchivoAdam

                    intTotalDeRegistros = CInt(strRegistrosArchivoAdam(0))
                    intRegistrosConfirmados = CInt(strRegistrosArchivoAdam(1))
                Next
            End If


            'Se ennvia a usuario para que confirme.
            strHTML.Append("<script language='Javascript'>parent.fnGenerarArchivoAdam( " & _
            CStr(intTotalDeRegistros) & " , " & CStr(intRegistrosConfirmados) & _
            "); </script>")
            Response.Write(strHTML.ToString)
            Response.End()

        End If


        If (strCmd = "cmdGenerarArchivo") Then
            Try

                Dim objDataArrayArchivoAdam As Array = Nothing
                Dim resultadoConsulta As String = String.Empty
                Dim strNombreArchivo As String
                Dim strRutaRelativaArchivo As String


                Dim i As Integer
                'intRegistrosConfirmados = 0

                'ExportToExcelWhitoutOffice()
                'ExportToExcel()

                'REVISAR COMO REGRESAR DEL SP LOS VALORES DE TOTAL Y GENERADOS
                objDataArrayArchivoAdam = Benavides.CC.Data.clsControlDeAsistencia.strGenerarArchivoAdam(intTipoNomina, dtmFechaPago, dtmFechaInicio, dtmFechaFin, strUsuarioNombre, strConnectionString)

                If IsArray(objDataArrayArchivoAdam) AndAlso objDataArrayArchivoAdam.Length > 0 Then

                    ' Establecemos en la respuesta los parámetros de configuración del archivo
                    Response.ContentType = "application/vnd.ms-excel"
                    Call Response.AddHeader("Content-Disposition", "attachment; filename=" & strGetFileName() & "")

                    Call Response.Write(strTablaExcel(objDataArrayArchivoAdam))

                    'If intTotalDeRegistros > 0 Then
                    '    Call Response.Write("<script languaje='Javascript'>alert('Se generaron " & intRegistrosConfirmados.ToString() & " registros confirmados de un total de " & intTotalDeRegistros.ToString() & ".');</script>")
                    'End If
                    Call Response.End()

                Else
                    'Call Response.Write("<script languaje='Javascript'>alert('Generación de Archivo Adam si resultados.');</script>")
                End If


                'If intTotalDeRegistros > 0 Then
                '    Call Response.Write("<script languaje='Javascript'>alert('Se generaron " & intRegistrosConfirmados.ToString() & " registros confirmados de un total de " & intTotalDeRegistros.ToString() & ".');</script>")
                'End If
            Catch ex As Exception
                'Call Response.Write("<script languaje='Javascript'>alert('Ocurrió un error al intentar generar el archivo');</script>")
                'Call Response.Write("<script languaje='Javascript'>alert('Se generaron " & intRegistrosConfirmados.ToString() & " registros confirmados de un total de " & intTotalDeRegistros.ToString() & ".');</script>")

            End Try

        End If
    End Sub

    Private Function strGetFileName() As String

        'Nomenclatura para Nombre de archivo
        If intTipoNomina = 1 Then
            strGetFileName = "Adam_Q" & CStr(dtmFechaPago.Year()) & dtmFechaPago.Month().ToString("00") & dtmFechaPago.Day().ToString("00") & "(Piloto).xls"
        Else
            strGetFileName = "Adam_S" & CStr(dtmFechaPago.Year()) & dtmFechaPago.Month().ToString("00") & dtmFechaPago.Day().ToString("00") & "(Piloto).xls"
        End If

        Return strGetFileName

    End Function

    Private Sub ExportToExcelWhitoutOffice()

        Dim strFilename As String
        Dim strRutaRelativaArchivo As String

        'Se obtiene el nombre del archivo
        strFilename = strGetFileName()

        'Ruta donde se guarda el archivo
        strRutaRelativaArchivo = Response.ApplyAppPathModifier(ConfigurationSettings.AppSettings("strArchivoAdam") & strFilename)


        If File.Exists(strRutaRelativaArchivo) Then

            'Call Response.Write("<script languaje='Javascript'>alert('El archivo ya existe, desea sobreescribirl el archivo?');</script>")

            'ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('You clicked YES!')", True)

        End If


        Dim fs As FileStream = New FileStream(strRutaRelativaArchivo, FileMode.Create, FileAccess.ReadWrite)

        Dim w As StreamWriter = New StreamWriter(fs)

        'Dim _table As New Table()
        'Dim _row As New TableRow()

        '_table.ID = "ArchivoAdam"
        '_row.Attributes.Add("bgcolor", "#374f60")

        'Encabezados
        'GenerarEncabezadosExcel(_table, _row)

        'Registros
        'GenerarRegistrosExcel(_table, _row)

        Dim objDataArrayArchivoAdam As Array = Nothing
        objDataArrayArchivoAdam = Benavides.CC.Data.clsControlDeAsistencia.strGenerarArchivoAdam(intTipoNomina, dtmFechaPago, dtmFechaInicio, dtmFechaFin, strUsuarioNombre, strConnectionString)

        w.Write(strTablaExcel(objDataArrayArchivoAdam))
        w.Flush()
        fs.Close()


    End Sub

    Private Sub ExportToExcel()

        'Dim _table As New Table()
        'Dim _row As New TableRow()

        '_table.ID = "ArchivoAdam"
        '_row.Attributes.Add("bgcolor", "#374f60")

        'Encabezados
        'GenerarEncabezadosExcel(_table, _row)

        'Registros
        'GenerarRegistrosExcel(_table, _row)

        'DescargarRptEnLinea(_table, IdReporte);
        'Descargar(_table)

        '''''''''''''''''''''''''
        'Protected WithEvents txtArchivo As System.Web.UI.HtmlControls.HtmlInputFile
        Dim txtArchivo As System.Web.UI.HtmlControls.HtmlInputFile
        Dim wkb As System.IO.File

        'System.IO.File.Create("")

        Dim Excel As Object
        Dim intRow As Integer = 0
        Dim intColumnValue As Integer = 0
        Dim strDir As String = ""
        Dim strFilename As String = "Adam.xls"
        Dim strRutaRelativaArchivo As String
        strRutaRelativaArchivo = Response.ApplyAppPathModifier(ConfigurationSettings.AppSettings("strArchivoAdam") & strFilename)

        'Dim ds As DataSet
        'Dim dt As DataTable = idt_final_report

        Dim objDataArrayArchivoAdam As Array = Nothing
        Dim strConsultaReporteExportar As String() = Nothing

        objDataArrayArchivoAdam = Benavides.CC.Data.clsControlDeAsistencia.strGenerarArchivoAdam(intTipoNomina, dtmFechaPago, dtmFechaInicio, dtmFechaFin, strUsuarioNombre, strConnectionString)


        Excel = CreateObject("Excel.application")

        'With Excel
        '    .SheetsInNewWorkbook = 1
        '    .Workbooks.Add()
        '    .Worksheets(1).Select()


        '    .cells(1, 1).value = "Compañía"
        '    .cells(1, 1).Font.Bold = True
        '    .cells(1, 2).value = "Num. Empleado"
        '    .cells(1, 3).value = "Nombre"
        '    .cells(1, 4).value = "Clave Adam"
        '    .cells(1, 5).value = "Descripción"
        '    .cells(1, 6).value = "Tiempo"
        '    .cells(1, 7).value = "Importe"
        '    .cells(1, 8).value = "Fecha Incidencia"
        '    .cells(1, 9).value = "Ref"

            ''''
            'If IsArray(objDataArrayArchivoAdam) AndAlso objDataArrayArchivoAdam.Length > 0 Then
            Dim intContador As Integer = 1

            For Each strConsultaReporteExportar In objDataArrayArchivoAdam
                intContador += 1

            '.cells(intContador, 1).value = strConsultaReporteExportar(0)
            '.cells(intContador, 2).value = strConsultaReporteExportar(1)
            '.cells(intContador, 3).value = strConsultaReporteExportar(2)
            '.cells(intContador, 4).value = strConsultaReporteExportar(3)
            '.cells(intContador, 5).value = strConsultaReporteExportar(4)
            '.cells(intContador, 6).value = strConsultaReporteExportar(5)
            '.cells(intContador, 7).value = strConsultaReporteExportar(6)
            '.cells(intContador, 8).value = strConsultaReporteExportar(7)
            '.cells(intContador, 9).value = strConsultaReporteExportar(8)

            Next

            ''''
            'End With
            'To display the column value row-by-row in the excel file
            'For intRow = 0 To ds.Tables(0).Rows.Count - 1

            '    For intColumnValue = 0 To ds.Tables(0).Columns.Count - 1

            '        .cells(intRow + 1, intColumnValue + 1).value.ToString()
            '        'ds.Tables(0).Rows(intRow).ItemArray(intColumnValue).ToString()


            '    Next

            'Next

            '.activeWorkbook().SaveAs(strDir & strFilename)
        '.activeWorkbook().SaveAs(strRutaRelativaArchivo)
        '.activeWorkbook.close()
        'End With

        'Excel.Quit()
        Excel = Nothing
        GC.Collect()

    End Sub

    'Private Function Descargar(_table As Table)

    '    Dim sb As StringBuilder = New StringBuilder
    '    Dim sw As System.IO.StringWriter = New System.IO.StringWriter(sb)
        'Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)

        'Dim _page1 As Page = New Page
        'Dim form1 As HtmlForm = New HtmlForm()

        'htw.WriteLine("<b><u><font size='5'>" & "Excel Archivo Adam" & "</font></u></b>")
        'htw.WriteLine("<br>")

        '_page1.DesignerInitialize()
        '_page1.Controls.Add(form1)
        'form1.Controls.Add(_table)

        '_page1.RenderControl(htw)

    '    Dim FileName As StringBuilder = New System.Text.StringBuilder()

    '    FileName.Append("attachment;filename=")
    '    FileName.Append("Adam.xls")

    '    Response.Clear()
    '    ViewState.Clear()
    '    Response.Buffer = True
    '    Response.ContentType = "application/vnd.ms-excel"
    '    Response.AddHeader("Content-Disposition", FileName.ToString())
    '    Response.Charset = "UTF-8"
    '    Response.ContentEncoding = System.Text.Encoding.Default
    '    Response.Write(sb.ToString())
    '    Response.End()

    'End Function

    'Private Function _NewCell(Value As String) As TableCell

    '    Dim _cell = New TableCell

    '    _cell.Text = Value
    '    Return _cell

    'End Function

    'Private Function _NewCell(Value As String, aling As HorizontalAlign) As TableCell

    '    Dim _cell = New TableCell

    '    _cell.Text = Value
    '    _cell.HorizontalAlign = aling

    '    Return _cell

    'End Function

    'Private Function _NewHeaderCell(ByVal Value As String, ByVal Width As Integer) As TableCell

    '    Dim _cell As New TableCell

    '    _cell.Text = "<b><font size=\'3\' color=\'#FFFFFF\'>" & Value & "</font></b>"
    '    _cell.Width = Width
    '    _cell.Attributes.Add("align", "center")

    '    Return _cell

    'End Function

    'Private Sub GenerarRegistrosExcel(ByRef _table As Table, ByRef _row As TableRow)

    '    Dim objDataArrayArchivoAdam As Array = Nothing
    '    Dim strConsultaReporteExportar As String() = Nothing
    '    Dim intContador As Integer

    '    objDataArrayArchivoAdam = Benavides.CC.Data.clsControlDeAsistencia.strGenerarArchivoAdam(intTipoNomina, dtmFechaPago, dtmFechaInicio, dtmFechaFin, strUsuarioNombre, strConnectionString)

    '    If IsArray(objDataArrayArchivoAdam) AndAlso objDataArrayArchivoAdam.Length > 0 Then

    '        For Each strConsultaReporteExportar In objDataArrayArchivoAdam
    '            intContador += 1

    '            '_row = New TableRow

    '            '_row.Cells.Add(_NewCell(CStr(strConsultaReporteExportar(0))))
    '            '_row.Cells.Add(_NewCell(CStr(strConsultaReporteExportar(1))))
    '            '_row.Cells.Add(_NewCell(CStr(strConsultaReporteExportar(2))))
    '            '_row.Cells.Add(_NewCell(CStr(strConsultaReporteExportar(3))))
    '            '_row.Cells.Add(_NewCell(CStr(strConsultaReporteExportar(4))))
    '            '_row.Cells.Add(_NewCell(CStr(strConsultaReporteExportar(5))))
    '            '_row.Cells.Add(_NewCell(CStr(strConsultaReporteExportar(6))))
    '            '_row.Cells.Add(_NewCell(CStr(strConsultaReporteExportar(7))))
    '            '_row.Cells.Add(_NewCell(CStr(strConsultaReporteExportar(8))))

    '            _table.Rows.Add(_row)

    '        Next

    '    End If
    'End Sub

    'Private Sub GenerarEncabezadosExcel(ByRef _table As Table, ByRef _row As TableRow)

    '    _row.Cells.Add(_NewHeaderCell("Compañía", 100))
    '    _row.Cells.Add(_NewHeaderCell("Num. Empleado", 100))
    '    _row.Cells.Add(_NewHeaderCell("Nombre", 120))
    '    _row.Cells.Add(_NewHeaderCell("Clave Adam", 70))
    '    _row.Cells.Add(_NewHeaderCell("Descripción", 150))
    '    _row.Cells.Add(_NewHeaderCell("Tiempo", 70))
    '    _row.Cells.Add(_NewHeaderCell("Importe", 70))
    '    _row.Cells.Add(_NewHeaderCell("Fecha Incidencia", 85))
    '    _row.Cells.Add(_NewHeaderCell("Ref", 85))

    '    _table.Rows.Add(_row)

    'End Sub

#Region "Excel"
    Public Function strTablaExcel(ByVal objDataArrayArchivoAdam As Array) As String
        Dim strTablaExcelAdamHTML As StringBuilder
        Dim strConsultaReporteExportar As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer

        strTablaExcelAdamHTML = New StringBuilder
        strTablaExcelAdamHTML.Append("<span class='txsubtitulo'> </span> ")
        strTablaExcelAdamHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strTablaExcelAdamHTML.Append("<tr class='trtitulos'>")
        strTablaExcelAdamHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Compa&ntilde;&iacute;a</th>")
        strTablaExcelAdamHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Num Empleado</th>")
        strTablaExcelAdamHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Nombre</th>")
        strTablaExcelAdamHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Clave Adam</th>")
        strTablaExcelAdamHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Descripci&oacute;n</th>")
        strTablaExcelAdamHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Tiempo</th>")
        strTablaExcelAdamHTML.Append("<th width='8%' align=center class='rayita' align='left' valign='top'>Importe</th>")
        strTablaExcelAdamHTML.Append("<th width='8%' align=center class='rayita' align='left' valign='top'>Fecha Incidencia</th>")
        strTablaExcelAdamHTML.Append("<th width='8%' align=center class='rayita' align='left' valign='top'>Ref</th>")
        strTablaExcelAdamHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For Each strConsultaReporteExportar In objDataArrayArchivoAdam
            intContador += 1

            'intTotalDeRegistros = objDataArrayArchivoAdam.Length

            'If (CBool(strConsultaReporteExportar(9)) = True) Then
            '    intRegistrosConfirmados = intRegistrosConfirmados + 1
            'End If

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strTablaExcelAdamHTML.Append("<tr>")

            'Compañía
            strTablaExcelAdamHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaReporteExportar(0)) & "</td>")
            'Num Empleado
            strTablaExcelAdamHTML.Append("<td id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & strConsultaReporteExportar(1) & "</td>")
            'Nombre
            strTablaExcelAdamHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaReporteExportar(2)) & "</td>")
            'Clave Adam
            strTablaExcelAdamHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaReporteExportar(3) & "</td>")
            'DESCRIPCION
            strTablaExcelAdamHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaReporteExportar(4)).ToString() & "</td>")
            'Tiempo
            strTablaExcelAdamHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearNumeroPresentacion(strConsultaReporteExportar(5), False) & "</td>")
            'Importe
            strTablaExcelAdamHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaReporteExportar(6).ToString() & "</td>")
            'Fecha Incidencia
            strTablaExcelAdamHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaReporteExportar(7).ToString() & "</td>")
            'Ref
            strTablaExcelAdamHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaReporteExportar(8).ToString() & "</td>")
            strTablaExcelAdamHTML.Append("</tr>")

        Next
        strTablaExcelAdamHTML.Append("</tr>")
        strTablaExcelAdamHTML.Append("</table>")
        strTablaExcel = strTablaExcelAdamHTML.ToString

    End Function

    'Public Function strTablaConsultaMensaje() As String

    '    Dim strResult As New StringBuilder()
    '    Dim resultadoConsulta As String = String.Empty

    '    'Call Response.Write("<script languaje='Javascript'>alert('Se generaron " & intRegistrosConfirmados.ToString() & " registros confirmados de un total de " & intTotalDeRegistros.ToString() & ".');</script>")

    '    If (strCmd = "cmdConsultar") AndAlso (intTotalDeRegistros > 0) Then

    '        'AndAlso (intRegistrosConfirmados > 0)

    '        'strResult.Append("<script languaje='Javascript'>alert('Se generaron " & intRegistrosConfirmados.ToString() & " registros confirmados de un total de " & intTotalDeRegistros.ToString() & ".');</script>")
    '        strResult.Append("<h1>'Se generaron " & intRegistrosConfirmados.ToString() & " registros confirmados de un total de " & intTotalDeRegistros.ToString() & ".</h1>")
    '        resultadoConsulta = "document.getElementById('divConsultaMensaje').innerHTML;"

    '    Else
    '        resultadoConsulta = String.Empty
    '    End If

    '    strResult.Append("<script language=""javascript"" type=""text/javascript"">")
    '    strResult.Append("parent.document.getElementById('tblResultados').innerHTML = " & resultadoConsulta)
    '    strResult.Append("</script>")

    '    Return strResult.ToString()

    'End Function
#End Region
End Class