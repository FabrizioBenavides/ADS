'====================================================================
' Class         : clsArticulo
' Title         : Grupo Benavides. Catálogo de Artículos (trabajos)
' Description   : Captura de Artículos
' Copyright     : 2003-2006 All rights reserved.
' Company       : Neitek Solutions S.A. de C.V.
' Author        : Enrique Longoria
' Version       : 1.0
' Last Modified : Thu, Jan 27th, 2005
'====================================================================

#Region "Imports"
Imports System.Text
Imports System.Collections
Imports prjFotolabBusiness.Benavides.Fotolab.Utils
Imports prjFotolabBusiness.Benavides.Fotolab.Data
#End Region

Public Class ArticuloFotolab
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

#Region "Properties"
    Protected _intArticuloFotolabId As String
    Protected _intArticuloFotolabExistenciaActual As String
    Protected _strArticuloDescripcion As String
    Protected _fltArticuloPrecioOficial As String
    Protected _intClasificacionId As String
    Protected _intClasificacionArticuloId As Integer
    Protected _strArticuloClasificacionNombre As String
    Protected _strCodigoBarraArticuloValor As String
    Protected _strArticulos As String


    '====================================================================
    ' Name       : strCodigoBarraArticuloValor
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strCodigoBarraArticuloValor() As String
        Get
            Return _strCodigoBarraArticuloValor
        End Get
        Set(ByVal strValue As String)
            _strCodigoBarraArticuloValor = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strArticulosDes 
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strArticulos() As String
        Get
            Return _strArticulos
        End Get
        Set(ByVal strValue As String)
            _strArticulos = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intClasificacionid
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intClasificacionid() As String
        Get
            Return _intClasificacionId
        End Get
        Set(ByVal strValue As String)
            _intClasificacionId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strArticuloClasificacionNombre 
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strArticuloClasificacionNombre() As String
        Get
            Return _strArticuloClasificacionNombre
        End Get
        Set(ByVal strValue As String)
            _strArticuloClasificacionNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltArticuloPrecioOficial 
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property fltArticuloPrecioOficial() As String
        Get
            Return _fltArticuloPrecioOficial
        End Get
        Set(ByVal strValue As String)
            _fltArticuloPrecioOficial = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : intArticuloFotolabExistenciaActual 
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intArticuloFotolabExistenciaActual() As String
        Get
            Return _intArticuloFotolabExistenciaActual
        End Get
        Set(ByVal strValue As String)
            _intArticuloFotolabExistenciaActual = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intArticuloFotolabId
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intArticuloFotolabId() As String
        Get
            Return _intArticuloFotolabId
        End Get
        Set(ByVal strValue As String)
            _intArticuloFotolabId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intClasificacionArticuloId 
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intClasificacionArticuloId() As Integer
        Get
            Return _intClasificacionArticuloId
        End Get
        Set(ByVal strValue As Integer)
            _intClasificacionArticuloId = strValue
        End Set
    End Property



    '====================================================================
    ' Name       : strArticuloDescripcion 
    ' Description: Obtiene o establece el valor
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strArticuloDescripcion() As String
        Get
            Return _strArticuloDescripcion
        End Get
        Set(ByVal strValue As String)
            _strArticuloDescripcion = strValue
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
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsArticuloFotolab.SERVICIOS
    End Sub


    '====================================================================
    ' Name       : strGenerarListado
    ' Description: Genera un listado y regresa el HTML de este Listado
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function strGenerarListado(ByVal strCmd As String) As String

        Dim htmlResult As String
        Dim intSelectedPage, totalRows As Integer
        Dim dataArray As Array
        Dim elemArray As Array

        intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        If intSelectedPage <= 0 Then
            'intSelectedPage = 1
            If IsNumeric(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request)) = True Then
                intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
            Else
                intSelectedPage = 1
            End If
        End If

        ' Obtenemos los listados que ya se han capturado previamente.
        If (Request("strArticulos") = "") Then
            dataArray = clsServicesObj.strConsultarListado(Me._TRAER_LISTADO, Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, _MAX_PER_PAGE)
        Else
            dataArray = clsServicesObj.strConsultarListado(Me._TRAER_LISTADO_FILTRADO, Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, _MAX_PER_PAGE)
        End If

        Dim headers As ArrayList = New ArrayList
        headers.Add("Número")
        headers.Add("Código de Barras")
        headers.Add("Descripción")
        headers.Add("Acciones")

        Dim columnOrder As Integer() = {0, 2, 3}

        Dim actions As ArrayList = New ArrayList
        Dim pkNames As String() = {"intArticuloFotolabId"}
        Dim pkIndexes As Integer() = {0}
        actions.Add(New clsActionLink("Editar", pkNames, pkIndexes, "imgNREditar.gif", "Haga clic aquí para editar este listado"))


        If dataArray.Length > 0 Then
            elemArray = DirectCast(dataArray.GetValue(0), Array)
            totalRows = CInt(elemArray.GetValue(elemArray.Length - 1))
        End If
        htmlResult = clsHTMLUtils.displayScroll(totalRows, intSelectedPage, Me._MAX_PER_PAGE, Me.strThisPageName, Nothing, , "../static/images/")
        htmlResult += clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, intSelectedPage, Me._MAX_PER_PAGE, -1, , "../static/images/")
        htmlResult += "<br>"
        htmlResult += "<input class=boton onclick=javascript:doSubmit('" + Me._IMPRIMIR + "') type=button value=Impresión name=btnImprimir>"
        htmlResult += "<input class=boton onclick=javascript:doSubmit('" + Me._EXPORTAR + "') type=button value=Exportar name=btnExportar>"
        Return htmlResult
    End Function

    '====================================================================
    ' Name       : strDesplegarValores
    ' Description: despliega los valores encontrados y los manipula a que fueron leidos, se ejecuta siempre despues del editarRegistro
    ' Parameters : 
    '              ByVal values As  String
    '                 - Arreglo  de valores encontrados en  editarRegistro 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Protected Overrides Function strDesplegarValores(ByVal arrValues As Array) As String

        If arrValues.Length > 0 Then
            Dim htmlResult As String
            Dim rowArray As Array
            Dim boolValue As Integer
            rowArray = CType(arrValues.GetValue(0), Array)
            htmlResult += "parent.parent.document.getElementById('divArticuloFotolabId').innerHTML=" + Chr(39) + CStr(rowArray.GetValue(0)) + Chr(39) + ";" + vbTab
            htmlResult += "parent.parent.document.forms[0].intArticuloFotolabId.value=" + Chr(39) + CStr(rowArray.GetValue(0)) + Chr(39) + ";" + vbTab
            htmlResult += "parent.parent.document.getElementById('divCodigoBarraArticuloValor').innerHTML=" + Chr(39) + CStr(rowArray.GetValue(2)) + Chr(39) + ";" + vbTab
            htmlResult += "parent.parent.document.getElementById('divArticuloDescripcion').innerHTML=" + Chr(39) + CStr(rowArray.GetValue(4)).TrimEnd + Chr(39) + ";" + vbTab
            htmlResult += "parent.parent.document.forms[0].fltArticuloFotolabPrecioFoto.value=" + Chr(39) + Format(CDec(rowArray.GetValue(5)), "###,##0.000") + Chr(39) + ";" + vbTab
            htmlResult += "parent.parent.document.forms[0].fltArticuloFotolabPrecioRevelado.value=" + Chr(39) + Format(CDec(rowArray.GetValue(6)), "###,##0.000") + Chr(39) + ";" + vbTab
            htmlResult += "parent.parent.document.forms[0].strArticuloClasificacionNombre.value=" + Chr(39) + CStr(rowArray.GetValue(3)) + Chr(39) + ";" + vbTab
            htmlResult += "parent.parent.document.forms[0].intClasificacionArticuloId.value=" + Chr(39) + CStr(rowArray.GetValue(1)) + Chr(39) + ";" + vbTab

            htmlResult += "parent.parent.document.forms[0].chkPermitidoOrden.checked=" + CStr(rowArray.GetValue(7)).ToLower + ";" + vbTab
            If CStr(rowArray.GetValue(7)).Equals(Boolean.TrueString) = True Then boolValue = 1
            htmlResult += "parent.parent.document.forms[0].blnArticuloFotolabPermitidoOrden.value=" + boolValue.ToString + ";" + vbTab

            '0 - tblArticuloFotolab.intArticuloId,
            '1 - tblClasificacionarticulo.intClasificacionArticuloId,
            '2 - tblCodigoBarraArticulo.strCodigoBarraArticuloValor,
            '3 - tblClasificacionarticulo.strClasificacionArticuloNombre, 
            '4 - tblArticulo.strArticuloDescripcion,
            '5 - tblArticuloFotolab.fltArticuloFotolabPrecioFoto,
            '6 - tblArticuloFotolab.fltArticuloFotolabPrecioRevelado,
            '7 - tblArticuloFotolab.blnArticuloFotolabPermitidoOrden

            Return htmlResult
        Else
            Return ""
        End If
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
        If (Request("strArticulos") = "") Then
            dataArray = clsServicesObj.strConsultarListado(Me._TRAER_LISTADO, Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
        Else
            dataArray = clsServicesObj.strConsultarListado(Me._TRAER_LISTADO_FILTRADO, Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
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
        Dim code As StringBuilder = New StringBuilder
        Dim widths As String() = {"30%", "20%", "50%"}
        Dim values As String() = {"Número", "Número de Barras", "Descripción"}
        code.Append(clsHTMLUtils.getTagTR("th", 3, "rayita", "txcont", widths, values))
        Return code.ToString
    End Function

    '====================================================================
    ' Name       : getTitle
    ' Description: Forma HTML con el titulo para el listado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function getTitle(ByVal currentPage As Integer, ByVal totalPages As Integer) As String
        Dim code As StringBuilder = New StringBuilder
        Dim widths As String() = {"70%", "10%", "20%"}
        Dim styles As String() = {"txtitulo", "txcontenidobold", "txcontenidobold"}
        Dim values1 As String() = {"Reporte de Articulos", "", "HOJA: " + currentPage.ToString + " / " + totalPages.ToString}
        Dim values2 As String() = {"", "", "Fecha: " + Today.ToString(clsDateUtil.DATE_FORMAT)}

        code.Append(clsHTMLUtils.BEGIN_TABLE)
        code.Append(clsHTMLUtils.getTagTR("td", 3, styles, widths, values1))
        code.Append(clsHTMLUtils.getTagTR("td", 3, "txcontenidobold", widths, values2))
        code.Append(clsHTMLUtils.END_TABLE)

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
        Dim colsToShow As Integer() = {0, 2, 3}
        Return clsPrintUtil.getSimpleRow(aRow, colsToShow)
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

    '====================================================================
    ' Name       : getColumnNumber
    ' Description: Regresa el numero de columnas
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Protected Overrides Function getColumnNumber() As Integer
        Return 3
    End Function



#End Region



End Class
