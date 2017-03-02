'====================================================================
' Class         : clsConsultaRemisionesAdmin
' Title         : Grupo Benavides. clsConsultaRemisionesAdmin
' Description   : consulta de Remisiones
' Copyright     : 2003-2006 All rights reserved.
' Company       : Neitek Solutions S.A. de C.V.
' Author        : Enrique Longoria
' Version       : 1.0
' Last Modified : Monday, Mar 17th  2005
'====================================================================

#Region "Imports"
Imports System.Text
Imports System.Collections
Imports prjFotolabBusiness.Benavides.Fotolab.Utils
Imports prjFotolabBusiness.Benavides.Fotolab.Data
#End Region

Public Class clsConsultaRemisionesAdmin
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
    Protected _intOrdenId As String

    '====================================================================
    ' Name       : intOrdenId 
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intOrdenId() As String
        Get
            Return _intOrdenId
        End Get
        Set(ByVal strValue As String)
            _intOrdenId = strValue
        End Set
    End Property


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
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsConsultaRemisiones.SERVICIOS
    End Sub

   
    '====================================================================
    ' Name       : strDesplegarValores
    ' Description: despliega los valores de la forma
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Nothing
    '====================================================================
    Protected Overrides Function strDesplegarValores(ByVal arrValues As Array) As String
        If arrValues.Length > 0 Then
            Dim htmlResult As StringBuilder = New StringBuilder()
            Dim rowArray As Array
            rowArray = CType(arrValues.GetValue(0), Array)

            htmlResult.Append("parent.parent.document.getElementById('divRemisionSecuencia').innerHTML=")
            htmlResult.Append(Chr(39))
            htmlResult.Append(rowArray.GetValue(8))
            htmlResult.Append(Chr(39))
            htmlResult.Append("; ")

            htmlResult.Append("parent.parent.document.getElementById('divRemisionLaboratorio').innerHTML=")
            htmlResult.Append(Chr(39))
            htmlResult.Append(rowArray.GetValue(1))
            htmlResult.Append(Chr(39))
            htmlResult.Append("; ")

            htmlResult.Append("parent.parent.document.getElementById('divRemisionFarmacia').innerHTML=")
            htmlResult.Append(Chr(39))
            htmlResult.Append(rowArray.GetValue(2))
            htmlResult.Append(Chr(39))
            htmlResult.Append("; ")

            htmlResult.Append("parent.parent.document.getElementById('divRemisionFecha').innerHTML=")
            htmlResult.Append(Chr(39))
            htmlResult.Append(rowArray.GetValue(7))
            htmlResult.Append(Chr(39))
            htmlResult.Append("; ")

            htmlResult.Append("parent.parent.document.getElementById('divRemisionNoOrdenes').innerHTML=")
            htmlResult.Append(Chr(39))
            htmlResult.Append(rowArray.GetValue(9))
            htmlResult.Append(Chr(39))
            htmlResult.Append("; ")

            htmlResult.Append("parent.parent.document.getElementById('divRemisionNoFotos').innerHTML=")
            htmlResult.Append(Chr(39))
            htmlResult.Append(rowArray.GetValue(10))
            htmlResult.Append(Chr(39))
            htmlResult.Append("; ")

            htmlResult.Append("parent.parent.document.getElementById('divRemisionImporteBruto').innerHTML=")
            htmlResult.Append(Chr(39))
            htmlResult.Append("$")
            htmlResult.Append(Format(CDec(rowArray.GetValue(11)), "###,##0.00"))
            htmlResult.Append(Chr(39))
            htmlResult.Append("; ")

            htmlResult.Append("parent.parent.document.getElementById('divRemisionPorcentajeIva').innerHTML=")
            htmlResult.Append(Chr(39))
            htmlResult.Append(CInt(rowArray.GetValue(12)))
            htmlResult.Append("%")
            htmlResult.Append(Chr(39))
            htmlResult.Append("; ")

            htmlResult.Append("parent.parent.document.getElementById('divRemisionImporteIva').innerHTML=")
            htmlResult.Append(Chr(39))
            htmlResult.Append("$")
            htmlResult.Append(Format(CDec(rowArray.GetValue(13)), "###,##0.00"))
            htmlResult.Append(Chr(39))
            htmlResult.Append("; ")

            Return htmlResult.ToString
        Else
            Return ""
        End If
    End Function


    '====================================================================
    ' Name       : strDesplegarValoresOrden
    ' Description: despliega los valores de la forma
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Nothing
    '====================================================================
    Protected Function strDesplegarValoresOrden(ByVal arrValues As Array) As String
        If arrValues.Length > 0 Then
            Dim htmlResult As StringBuilder = New StringBuilder()
            Dim rowArray As Array
            rowArray = CType(arrValues.GetValue(0), Array)

            htmlResult.Append("parent.parent.document.getElementById('divCodigoOrden').innerHTML=")
            htmlResult.Append(Chr(39))
            htmlResult.Append(rowArray.GetValue(0))
            htmlResult.Append(Chr(39))
            htmlResult.Append("; ")

            htmlResult.Append("parent.parent.document.getElementById('divOrdenNoTrabajos').innerHTML=")
            htmlResult.Append(Chr(39))
            htmlResult.Append(rowArray.GetValue(3))
            htmlResult.Append(Chr(39))
            htmlResult.Append("; ")

            htmlResult.Append("parent.parent.document.getElementById('divOrdenNoFotos').innerHTML=")
            htmlResult.Append(Chr(39))
            htmlResult.Append(rowArray.GetValue(4))
            htmlResult.Append(Chr(39))
            htmlResult.Append("; ")

            htmlResult.Append("parent.parent.document.getElementById('divOrdenImporte').innerHTML=")
            htmlResult.Append(Chr(39))
            htmlResult.Append("$")
            htmlResult.Append(Format(CDec(rowArray.GetValue(5)), "###,##0.00"))
            htmlResult.Append(Chr(39))
            htmlResult.Append("; ")

            htmlResult.Append("parent.parent.document.getElementById('divOrdenPorcentajeIva').innerHTML=")
            htmlResult.Append(Chr(39))
            htmlResult.Append(CInt(rowArray.GetValue(6)))
            htmlResult.Append("%")
            htmlResult.Append(Chr(39))
            htmlResult.Append("; ")

            htmlResult.Append("parent.parent.document.getElementById('divOrdenImporteIva').innerHTML=")
            htmlResult.Append(Chr(39))
            htmlResult.Append("$")
            htmlResult.Append(Format(CDec(rowArray.GetValue(7)), "###,##0.00"))
            htmlResult.Append(Chr(39))
            htmlResult.Append("; ")

            htmlResult.Append("parent.parent.document.getElementById('divOrdenFecha').innerHTML=")
            htmlResult.Append(Chr(39))
            htmlResult.Append(rowArray.GetValue(10))
            htmlResult.Append(Chr(39))
            htmlResult.Append("; ")


            Return htmlResult.ToString
        Else
            Return ""
        End If
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
            Case "VerOrden"
                strHtmlResult = Me.strVerOrden(strCmd)
        End Select

        Return strHtmlResult
    End Function



    '====================================================================
    ' Name       : strVerOrden
    ' Description: Acción efectuda cuando se consula un solo registro para ser desplegado y posteriormente editado (SELECT)
    ' Parameters : 
    '              ByVal strCmd As  String
    '                 - Nombre del  comando a efectuar  
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function strVerOrden(ByVal strCmd As String) As String
        Dim htmlResult As String
        Dim values As Array
        values = clsServicesObj.strConsultarListado(strCmd, Request, Me.strConnectionString, strUsuarioNombre, -1, -1)
        htmlResult = Me.strDesplegarValoresOrden(values)
        Return htmlResult
    End Function


    '====================================================================
    ' Name       : strListadoDeOrdenes
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function strListadoDeOrdenes() As String
        ' Declaramos e inicializamos las constantes locales
        Dim dataArray As Array
        Dim htmlResult As StringBuilder = New StringBuilder()
        Dim columnOrder As Integer() = {0, 3, 4, 5, 8}
        Dim headers As ArrayList = New ArrayList()
        headers.Add("No. Orden")
        headers.Add("No. Trabajos")
        headers.Add("No. Fotos")
        headers.Add("Importe de Producción")
        headers.Add("Importe de Venta")
        headers.Add("Acciones")
        Dim actions As ArrayList = New ArrayList()
        Dim pkNames As String() = {"intOrdenId"}
        Dim pkIndexes As Integer() = {1}
        actions.Add(New clsActionLink("VerOrden", pkNames, pkIndexes, Me._IMG_DETALLE, "Ver detalle de Orden"))

        htmlResult.Append("<br>")
        htmlResult.Append("<span class='txsubtitulo' align=left>")
        htmlResult.Append("<img src='../static/images/bullet_subtitulos.gif' width=17 height=11 align=absMiddle>")
        htmlResult.Append("Listado de Ordenes")
        htmlResult.Append("</span>")
        dataArray = clsServicesObj.strConsultarListado("ListadoOrdenes", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
        htmlResult.Append(clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, 1, -1, -1, , "../static/images/"))
        htmlResult.Append("<br>")

        Return htmlResult.ToString
    End Function



    '====================================================================
    ' Name       : strListadoDeTrabajos
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function strListadoDeTrabajos() As String
        ' Declaramos e inicializamos las constantes locales
        Dim dataArray As Array
        Dim htmlResult As StringBuilder = New StringBuilder()
        Dim columnOrder As Integer() = {12, 2, 6, 7, 8, 9}
        Dim headers As ArrayList = New ArrayList
        headers.Add("Id Trabajo")
        headers.Add("Trabajo")
        headers.Add("Cant.<br>Fotos")
        headers.Add("Precio<br>Foto")
        headers.Add("Precio<br>Revelado")
        headers.Add("Importe")
        Dim actions As ArrayList = New ArrayList()
        Dim pkNames As String() = {"intTrabajoOrdenId"}
        Dim pkIndexes As Integer() = {0}
        htmlResult.Append("<br>")
        htmlResult.Append("<span class='txsubtitulo' align=left>")
        htmlResult.Append("<img src='../static/images/bullet_subtitulos.gif' width=17 height=11 align=absMiddle>")
        htmlResult.Append("Listado de Trabajos")
        htmlResult.Append("</span>")
        dataArray = clsServicesObj.strConsultarListado("ListadoTrabajos", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
        htmlResult.Append(clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, 1, -1, -1, , "../static/images/"))
        htmlResult.Append("<br>")

        Return htmlResult.ToString
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

        intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        If intSelectedPage <= 0 Then
            If IsNumeric(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request)) = True Then
                intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
                If intSelectedPage = -1 Then intSelectedPage = 1
            Else
                intSelectedPage = 1
            End If
        End If

        ' Obtenemos los listados que ya se han capturado previamente.
        dataArray = clsServicesObj.strConsultarListado(Me._TRAER_LISTADO, Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, _MAX_PER_PAGE)

        Dim headers As ArrayList = New ArrayList
        headers.Add("Remisión")
        headers.Add("Laboratorio")
        headers.Add("Farmacia")
        headers.Add("Fecha")
        headers.Add("No.<br>Ordenes")
        headers.Add("No.<br>Fotos")
        headers.Add("Importe")
        headers.Add("Acciones")

        Dim columnOrder As Integer() = {8, 1, 2, 7, 9, 10, 11}

        Dim actions As ArrayList = New ArrayList
        Dim pkNames As String() = {"intRemisionId"}
        Dim pkIndexes As Integer() = {0}
        actions.Add(New clsActionLink(Me._EDITAR, pkNames, pkIndexes, Me._IMG_DETALLE, "Ver detalle de Remisión"))

        If dataArray.Length > 0 Then
            elemArray = DirectCast(dataArray.GetValue(0), Array)
            totalRows = CInt(elemArray.GetValue(elemArray.Length - 1))
        End If
        htmlResult.Append("<br>")
        htmlResult.Append("<span class='txsubtitulo' align=left>")
        htmlResult.Append("<img src='../static/images/bullet_subtitulos.gif' width=17 height=11 align=absMiddle>")
        htmlResult.Append("Listado de Remisiones")
        htmlResult.Append("</span>")
        htmlResult.Append(clsHTMLUtils.displayScroll(totalRows, intSelectedPage, Me._MAX_PER_PAGE, Me.strThisPageName, Nothing, , "../static/images/"))
        htmlResult.Append(clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, intSelectedPage, Me._MAX_PER_PAGE, -1, , "../static/images/", False, 30))
        htmlResult.Append("<br>")
        ' htmlResult.Append("<input class=boton onclick=javascript:regresarFiltros() type=button value=Regresar name=btnRegresarFiltros>")
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
        dataArray = clsServicesObj.strConsultarListado(Me._TRAER_LISTADO, Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
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
        Dim widths As String() = {"10%", "25%", "25%", "10%", "10%", "10%", "10%"}
        Dim values As String() = {"Remisión", "Laboratorio", "Farmacia", "Fecha", "No. Ordenes", "No. Fotos", "Importe"}
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
        Dim colsToShow As Integer() = {8, 1, 2, 7, 9, 10, 11}
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
        Dim values1 As String() = {"Reporte de Remisiones", "", "HOJA: " + currentPage.ToString + " / " + totalPages.ToString}
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


