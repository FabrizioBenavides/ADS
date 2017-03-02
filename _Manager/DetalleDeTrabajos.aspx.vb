'====================================================================
' Class         :  clsDetalleDeTrabajos
' Title         : Grupo Benavides
' Description   : Pantalla de Detalle de Laboratorio
' Copyright     : 2003-2006 All rights reserved.
' Company       : Neitek Solutions S.A. de C.V.
' Author        : Enrique Longoria
' Version       : 1.0
' Last Modified : Thu, Feb 16th, 2005
'====================================================================

#Region "Imports"
Imports System.Text
Imports System.Collections
Imports prjFotolabBusiness.Benavides.Fotolab.Utils
Imports prjFotolabBusiness.Benavides.Fotolab.Data
#End Region

Public Class clsDetalleDeTrabajos
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

    Protected _intConsumidorFotolabId As Integer
    Protected _strConsumidorFotolabTelefono As String
    Protected _strConsumidorFotolabNombre As String
    Protected _strConsumidorFotolabCorreo As String


    '====================================================================
    ' Name       : intConsumidorFotolabId 
    ' Description: Obtiene o establece el valor
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intConsumidorFotolabId() As Integer
        Get
            Return _intConsumidorFotolabId
        End Get
        Set(ByVal strValue As Integer)
            _intConsumidorFotolabId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : _strConsumidorFotolabTelefono 
    ' Description: Obtiene o establece el valor
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strConsumidorFotolabTelefono() As String
        Get
            Return _strConsumidorFotolabTelefono
        End Get
        Set(ByVal strValue As String)
            _strConsumidorFotolabTelefono = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strConsumidorFotolabNombre 
    ' Description: Obtiene o establece el valor
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strConsumidorFotolabNombre() As String
        Get
            Return _strConsumidorFotolabNombre
        End Get
        Set(ByVal strValue As String)
            _strConsumidorFotolabNombre = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : _strConsumidorFotolabCorreo 
    ' Description: Obtiene o establece el valor
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strConsumidorFotolabCorreo() As String
        Get
            Return _strConsumidorFotolabCorreo
        End Get
        Set(ByVal strValue As String)
            _strConsumidorFotolabCorreo = strValue
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
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsDetalleDeTrabajos.SERVICIOS
    End Sub


    '====================================================================
    ' Name       : strDesplegarValores
    ' Description: despliega los valores de la forma
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Nothing
    '====================================================================
    '====================================================================
    ' Name       : strDesplegarValoresLab
    ' Description: despliega los valores de la forma
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Nothing
    '====================================================================
    Protected Overrides Function strDesplegarValores(ByVal arrValues As Array) As String
        If arrValues.Length > 0 Then
            Dim htmlResult As String
            Dim rowArray As Array
            rowArray = CType(arrValues.GetValue(0), Array)
            htmlResult += "document.all.divSucursalccsss.innerHTML=" + Chr(39) + CStr(rowArray.GetValue(2)) + Chr(39) + ";" + vbTab
            htmlResult += "	document.all.divSucursalRazonSocial.innerHTML=" + Chr(39) + CStr(rowArray.GetValue(3)) + Chr(39) + ";" + vbTab
            htmlResult += "	document.all.divSucursalZonaOperativa.innerHTML=" + Chr(39) + CStr(rowArray.GetValue(4)) + Chr(39) + ";" + vbTab
            Return htmlResult
        Else
            Return ""
        End If

    End Function




    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function strGenerarListado(ByVal strcmd As String) As String
        ' Declaramos e inicializamos las constantes locales
        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 1
        Dim strRecordBrowserName As String = "Laboratorios"
        Dim intSelectedPage, totalRows As Integer
        Dim dataArray, elemArray As Array
        Dim htmlResult As String = ""

        intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        If intSelectedPage <= 0 Then
            'intSelectedPage = 1
            intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
        End If

        ' Obtenemos los listados que ya se han capturado previamente.
        dataArray = clsServicesObj.strConsultarListado(Me._TRAER_LISTADO, Request, strConnectionString, strUsuarioNombre, intSelectedPage, 5)

        Dim headers As ArrayList = New ArrayList()
        headers.Add("Código")
        headers.Add("Código de Barras")
        headers.Add("Descripción")
        headers.Add("Clasificación")
        headers.Add("Acciones")

        Dim columnOrder As Integer() = {1, 2, 3, 4}
        Dim actions As ArrayList = New ArrayList()
        Dim pkNames As String() = {"intArticuloId"}
        Dim pkIndexes As Integer() = {1}

        actions.Add(New clsActionLink(Me._GUARDAR, pkNames, pkIndexes, "imgNRAsignar.gif", "Buscar por  este Trabajo"))

        If dataArray.Length > 0 Then
            elemArray = DirectCast(dataArray.GetValue(0), Array)
            totalRows = CInt(elemArray.GetValue(elemArray.Length - 1))
        End If
        Dim Index3(0) As Integer
        Index3(0) = 3
        htmlResult = clsHTMLUtils.displayScroll(totalRows, intSelectedPage, 5, Me.strThisPageName, Nothing, , "../static/images/")
        htmlResult += clsHTMLUtils.displayPopUpTable(headers, dataArray, columnOrder, Index3, actions, intSelectedPage, 5, -1, , "../static/images/")


        Return htmlResult
    End Function


#End Region

#Region "metodos de la interface PrintInterface"

   

    '====================================================================
    ' Name       : getHeaders
    ' Description: Forma HTML con el header para el listado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function getHeaders() As String
        Dim code As StringBuilder = New StringBuilder()
        Dim widths As String() = {"30%", "70%"}
        Dim values As String() = {"Identificador", "Descripción"}
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
        Dim code As StringBuilder = New StringBuilder()
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
        Dim colsToShow As Integer() = {0, 2}
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
    ' Description: Regresa el número de columnas
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Protected Overrides Function getColumnNumber() As Integer
        Return 3
    End Function

#End Region


End Class

