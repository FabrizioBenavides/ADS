'====================================================================
' Class         : clsReporteTrabajosAdmin
' Title         : Grupo Benavides. clsReporteTrabajosAdmin
' Description   :  Reporte Trabajos Admin
' Copyright     : 2003-2006 All rights reserved.
' Company       : Neitek Solutions S.A. de C.V.
' Author        : Enrique Longoria
' Version       : 1.0
' Last Modified : Monday, Mar 28th  2005
'====================================================================

#Region "Imports"
Imports System.Text
Imports System.Collections
Imports prjFotolabBusiness.Benavides.Fotolab.Utils
Imports prjFotolabBusiness.Benavides.Fotolab.Data
#End Region

Public Class clsReporteTrabajosAdmin
    Inherits clsTemplatePage

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

#Region "Properties and Accesors"



#End Region

#Region "Document Business"

    '====================================================================
    ' Name       : initialize
    ' Description: inicializa el valor de la clase de servicios
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Nothing
    '====================================================================
    Protected Overrides Sub initialize()
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsReporteTrabajos.SERVICIOS
    End Sub

    '====================================================================
    ' Name       : obtenerComboSucursal
    ' Description: construye el combo Sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : html del Combo
    '====================================================================
    Protected Function obtenerComboSucursal() As String
        Dim dataArray As Array = Nothing
        Dim htmlCombo As String
        dataArray = clsServicesObj.strConsultarListado("SUCURSALES", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
        htmlCombo = prjFotolabBusiness.Benavides.Fotolab.Utils.clsHTMLUtils.buildCombo(dataArray, "cmbSucursal", 5, "comboTabla", "", True, "-Todos-")
        htmlCombo = " parent.parent.document.getElementById('divSucursal').innerHTML=" + Chr(34) + htmlCombo + Chr(34) + ";"
        Return htmlCombo
    End Function

    '====================================================================
    ' Name       : strOtraAccion
    ' Description: funcion  que realiza la accion para cada comando 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String 
    '====================================================================
    Protected Overrides Function strOtraAccion(ByVal strCmd As String) As String
        Dim strHtmlResult As String

        'Ejecutamos el comando indicado
        Select Case strCmd
            Case "SUCURSALES"
                strHtmlResult = Me.obtenerComboSucursal()
        End Select

        Return strHtmlResult
    End Function




    '====================================================================
    ' Name       : strGenerarListado
    ' Description: Genera un listado y regresa el HTML de este Listado
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function strGenerarListado(ByVal strCmd As String) As String
        Dim htmlResult As StringBuilder = New StringBuilder()
        Dim intSelectedPage, totalRows As Integer
        Dim dataArray, elemArray As Array
        Dim isMultiple As Boolean

        intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        If intSelectedPage <= 0 Then
            intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
        End If

        'Defino los headers de la Tabla
        Dim headers As ArrayList = New ArrayList()
        If Request("IntUENId").Equals("2") Then
            headers.Add("Farmacia")
        Else
            headers.Add("Laboratorio")
        End If
        headers.Add("Articulo")
        headers.Add("Cantidad<br>Trabajos")
        headers.Add("Fotos")
        headers.Add("Rollos")
        headers.Add("Importe")
        Dim columnOrder As Integer() = {0, 1, 2, 3, 4, 5}
        Dim actions As ArrayList = New ArrayList()
        Dim pkNames As String() = {""}
        Dim pkIndexes As Integer() = {0}

        If Request("intSucursalCcsss").ToString.Length > 5 Then isMultiple = True
        If isMultiple = True Then
            Dim intSucursales() As String
            Dim sqlStatementInicio As StringBuilder = New StringBuilder()
            Dim sqlStatementFin As StringBuilder = New StringBuilder()
            Dim auxArray(0) As Array
            Dim arrayItem As Array
            Dim j, x As Integer
            intSucursales = Split(Request("intSucursalCcsss"), ",")


            Dim arrFecha() As String
            Dim fechaInicio As String
            Dim fechaFin As String
            arrFecha = Request("dtmOrdenFechaEntregaIngresadaInicio").ToString.Split(Chr(47))
            fechaInicio = arrFecha(1) + "/" + arrFecha(0) + "/" + arrFecha(2)

            arrFecha = Request("dtmOrdenFechaEntregaIngresadaFin").ToString.Split(Chr(47))
            fechaFin = arrFecha(1) + "/" + arrFecha(0) + "/" + arrFecha(2)

            sqlStatementInicio.Append("'")
            sqlStatementInicio.Append(fechaInicio)
            sqlStatementInicio.Append("','")
            sqlStatementInicio.Append(fechaFin)
            sqlStatementInicio.Append("',")
            sqlStatementInicio.Append(Request("intDireccionOperativaId"))
            sqlStatementInicio.Append(",")
            sqlStatementInicio.Append(Request("intZonaOperativaId"))
            sqlStatementInicio.Append(",")
            '''
            '' Aqui va la Sucursal
            '''
            sqlStatementFin.Append(",")
            sqlStatementFin.Append(Request("intUENId"))
            sqlStatementFin.Append(",")
            sqlStatementFin.Append(Request("intClasificacionArticuloId"))
            sqlStatementFin.Append(",")
            sqlStatementFin.Append(Request("intMarcaRolloId"))
            sqlStatementFin.Append(",")
            sqlStatementFin.Append(Request("intExposicionesRolloId"))
            sqlStatementFin.Append(",")
            sqlStatementFin.Append(Request("intFormatoRolloId"))
            sqlStatementFin.Append(",")
            sqlStatementFin.Append(Request("intISOId"))
            sqlStatementFin.Append(",")
            sqlStatementFin.Append(Request("intServicioId"))
            sqlStatementFin.Append(",")
            sqlStatementFin.Append(Request("intTamanoFotoId"))

            For j = 0 To intSucursales.Length - 1
                arrayItem = clsServicesObj.strConsultarListado(Me._TRAER_LISTADO, Nothing, strConnectionString, Me.strUsuarioNombre, intSelectedPage, _MAX_PER_PAGE, sqlStatementInicio.ToString + intSucursales(j) + sqlStatementFin.ToString)
                If Not arrayItem Is Nothing AndAlso arrayItem.Length > 0 Then
                    Dim prevLen As Integer
                    If auxArray.GetValue(0) Is Nothing Then
                        prevLen = 0
                    Else
                        prevLen = auxArray.Length
                    End If
                    ReDim Preserve auxArray(prevLen + arrayItem.Length - 1)
                    For x = 0 To arrayItem.Length - 1
                        auxArray.SetValue(arrayItem.GetValue(x), prevLen + x)
                    Next x
                End If
            Next j
            If Not auxArray.GetValue(0) Is Nothing Then
                dataArray = auxArray
                If Not dataArray Is Nothing AndAlso dataArray.Length > 0 Then
                    arrayItem = CType(dataArray.GetValue(0), Array)
                    arrayItem.SetValue(CStr(dataArray.Length), arrayItem.Length - 1)
                    dataArray.SetValue(arrayItem, 0)
                End If
            End If

        Else
            dataArray = clsServicesObj.strConsultarListado(Me._TRAER_LISTADO, Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, _MAX_PER_PAGE)
        End If


        If Not dataArray Is Nothing AndAlso dataArray.Length > 0 Then
            elemArray = DirectCast(dataArray.GetValue(0), Array)
            totalRows = CInt(elemArray.GetValue(elemArray.Length - 1))
        End If

        'Agrego los headers del Listado
        htmlResult.Append("<br>")
        htmlResult.Append("<span class='txsubtitulo' align=left>")
        htmlResult.Append("<img src='../static/images/bullet_subtitulos.gif' width=17 height=11 align=absMiddle>")
        htmlResult.Append("Reporte de Trabajos")
        htmlResult.Append("</span>")
        htmlResult.Append(clsHTMLUtils.displayScroll(totalRows, intSelectedPage, Me._MAX_PER_PAGE, Me.strThisPageName, Nothing, , "../static/images/"))

        'Eligo el tipo de tabla a desplegar
        If isMultiple = True Then
            htmlResult.Append(clsHTMLUtils.displayArrayTable(headers, dataArray, columnOrder, actions, intSelectedPage, Me._MAX_PER_PAGE, -1, , "../static/images/"))
        Else
            htmlResult.Append(clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, intSelectedPage, Me._MAX_PER_PAGE, -1, , "../static/images/", False, 30))
        End If
        htmlResult.Append("<br>")
        htmlResult.Append("<input class=boton onclick=javascript:doSubmit('Imprimir') type=button value=Impresión name=btnImprimir>")
        htmlResult.Append("<input class=boton onclick=javascript:doSubmit('Exportar') type=button value=Exportar name=btnExportar>")
        Return htmlResult.ToString

    End Function

#End Region

#Region "metodos de la interface PrintInterface"

    '====================================================================
    ' Name       : strGenerarImpresion
    ' Description: Obtiene el html de la imrpesion.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Array
    '====================================================================
    Public Function strGenerarImpresion() As String
        Dim htmlResult As String = clsPrintUtil.printProcess(Me.getData(), Me)
        Return htmlResult
    End Function

    '====================================================================
    ' Name       : getData
    ' Description: Obtiene el arreglo de datos que se requiren para el listado.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Array
    '====================================================================
    Protected Overrides Function getData() As Array
        Dim dataArray As Array = Nothing
        Dim isMultiple As Boolean
        If Request("intSucursalCcsss").ToString.Length > 5 Then isMultiple = True
        If isMultiple = True Then
            Dim intSucursales() As String
            Dim sqlStatementInicio As StringBuilder = New StringBuilder()
            Dim sqlStatementFin As StringBuilder = New StringBuilder()
            Dim auxArray(0) As Array
            Dim arrayItem As Array
            Dim j, x As Integer
            intSucursales = Split(Request("intSucursalCcsss"), ",")

            sqlStatementInicio.Append("'")
            sqlStatementInicio.Append(Request("dtmOrdenFechaEntregaIngresadaInicio"))
            sqlStatementInicio.Append("','")
            sqlStatementInicio.Append(Request("dtmOrdenFechaEntregaIngresadaFin"))
            sqlStatementInicio.Append("',")
            sqlStatementInicio.Append(Request("intDireccionOperativaId"))
            sqlStatementInicio.Append(",")
            sqlStatementInicio.Append(Request("intZonaOperativaId"))
            sqlStatementInicio.Append(",")
            '''
            '' Aqui va la Sucursal
            '''
            sqlStatementFin.Append(",")
            sqlStatementFin.Append(Request("intUENId"))
            sqlStatementFin.Append(",")
            sqlStatementFin.Append(Request("intClasificacionArticuloId"))
            sqlStatementFin.Append(",")
            sqlStatementFin.Append(Request("intMarcaRolloId"))
            sqlStatementFin.Append(",")
            sqlStatementFin.Append(Request("intExposicionesRolloId"))
            sqlStatementFin.Append(",")
            sqlStatementFin.Append(Request("intFormatoRolloId"))
            sqlStatementFin.Append(",")
            sqlStatementFin.Append(Request("intISOId"))
            sqlStatementFin.Append(",")
            sqlStatementFin.Append(Request("intServicioId"))
            sqlStatementFin.Append(",")
            sqlStatementFin.Append(Request("intTamanoFotoId"))

            For j = 0 To intSucursales.Length - 1
                arrayItem = clsServicesObj.strConsultarListado(Me._TRAER_LISTADO, Nothing, strConnectionString, Me.strUsuarioNombre, -1, -1, sqlStatementInicio.ToString + intSucursales(j) + sqlStatementFin.ToString)
                If Not arrayItem Is Nothing AndAlso arrayItem.Length > 0 Then
                    Dim prevLen As Integer
                    If auxArray.GetValue(0) Is Nothing Then
                        prevLen = 0
                    Else
                        prevLen = auxArray.Length
                    End If
                    ReDim Preserve auxArray(prevLen + arrayItem.Length - 1)
                    For x = 0 To arrayItem.Length - 1
                        auxArray.SetValue(arrayItem.GetValue(x), prevLen + x)
                    Next x
                End If
            Next j

            dataArray = auxArray
            arrayItem = CType(dataArray.GetValue(0), Array)
            If Not arrayItem Is Nothing AndAlso arrayItem.Length > 0 Then
                arrayItem.SetValue(CStr(dataArray.Length), arrayItem.Length - 1)
                dataArray.SetValue(arrayItem, 0)
            End If
        Else
            dataArray = clsServicesObj.strConsultarListado(Me._TRAER_LISTADO, Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
        End If
        Return dataArray
    End Function

    '====================================================================
    ' Name       : getHeaders
    ' Description: Forma HTML con el header para el listado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function getHeaders() As String
        Dim code As StringBuilder = New StringBuilder()
        Dim widths As String() = {"30%", "30%", "10%", "10%", "10%", "10%"}
        Dim values As String()
        If Request("IntUENId").Equals("2") Then
            Dim valuesAux As String() = {"Farmacia", "Articulo", "Cantidad<br>Trabajos", "Rollos", "Fotos", "Importe"}
            values = valuesAux
        Else
            Dim valuesAux As String() = {"Laboratorio", "Articulo", "Cantidad<br>Trabajos", "Rollos", "Fotos", "Importe"}
            values = valuesAux
        End If

        code.Append(clsHTMLUtils.getTagTR("th", 4, "rayita", "txcont", widths, values))
        Return code.ToString
    End Function

    '====================================================================
    ' Name       : getRow
    ' Description: Forma HTML para desplegar un renglon del listado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function getRow(ByVal aRow As Array, ByVal globalRowCounter As Integer) As String
        Dim colsToShow As Integer() = {0, 1, 2, 3, 4, 5}
        Return clsPrintUtil.getSimpleRow(aRow, colsToShow)
    End Function

    '====================================================================
    ' Name       : getColumnNumber
    ' Description: Regresa el número de columnas
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Protected Overrides Function getColumnNumber() As Integer
        Return 4
    End Function


    '====================================================================
    ' Name       : getTitle
    ' Description: Forma HTML con el titulo para el listado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function getTitle(ByVal currentPage As Integer, ByVal totalPages As Integer) As String
        Dim code As StringBuilder = New StringBuilder()
        Dim widths As String() = {"70%", "10%", "20%"}
        Dim styles As String() = {"txtitulo", "txcontenidobold", "txcontenidobold"}
        Dim values1 As String() = {"Reporte de Trabajos", "", "HOJA: " + currentPage.ToString + " / " + totalPages.ToString}
        Dim values2 As String() = {"", "", "Fecha: " + Today.ToString(clsDateUtil.DATE_FORMAT)}

        code.Append(clsHTMLUtils.BEGIN_TABLE)
        code.Append(clsHTMLUtils.getTagTR("td", 3, styles, widths, values1))
        code.Append(clsHTMLUtils.getTagTR("td", 3, "txcontenidobold", widths, values2))
        code.Append(clsHTMLUtils.END_TABLE)

        Return code.ToString
    End Function

    '====================================================================
    ' Name       : getFooter
    ' Description: Forma HTML con el pie de listado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function getFooter() As String
        Return ""
    End Function

#End Region


End Class


