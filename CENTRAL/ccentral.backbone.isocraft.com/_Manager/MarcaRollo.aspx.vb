'====================================================================
' Class         : clsMarcaRollo
' Title         : Grupo Benavides. Catálogo de Marcas de Rollo
' Description   : Captura de Marcas de Rollo
' Copyright     : 2003-2006 All rights reserved.
' Company       : Neitek Solutions S.A. de C.V.
' Author        : Enrique Longoria
' Version       : 1.0
' Last Modified : Thu, Feb 1, 2005
'====================================================================

#Region "Imports"
Imports System.Text
Imports System.Collections
Imports prjFotolabBusiness.Benavides.Fotolab.Utils
Imports prjFotolabBusiness.Benavides.Fotolab.Data
#End Region

Public Class clsMarcaRollo
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
        clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Data.clstblMarcaRollo.SERVICIOS
    End Sub

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
            Dim boolValue As Integer
            Dim htmlResult As String
            Dim rowArray As Array
            rowArray = CType(arrValues.GetValue(0), Array)
            htmlResult += "parent.parent.document.forms[0].strMarcaRolloNombre.value=" + Chr(39) + CStr(rowArray.GetValue(1)) + Chr(39) + ";" + vbTab
            htmlResult += "	parent.parent.document.forms[0].intMarcaRolloId.value=" + Chr(39) + CStr(rowArray.GetValue(0)) + Chr(39) + ";" + vbTab
            htmlResult += "parent.parent.document.forms[0].chkActivo.checked=" + CStr(rowArray.GetValue(2)).ToLower + ";" + vbTab
            If CStr(rowArray.GetValue(2)).Equals(Boolean.TrueString) = True Then boolValue = 1
            htmlResult += "parent.parent.document.forms[0].blnMarcaRolloActivo.value=" + boolValue.ToString + ";" + vbTab
            Return htmlResult
        Else
            Return ""
        End If
    End Function




    '====================================================================
    ' Name       : strGenerarListado
    ' Description: Genera un listado y regresa el HTML de este Listado
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function strGenerarListado(ByVal strCmd As String) As String
        Dim htmlResult As String
        Dim intSelectedPage, totalRows As Integer
        Dim dataArray, elemArray As Array

        intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        If intSelectedPage <= 0 Then
            'intSelectedPage = 1
            intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
        End If

        ' Obtenemos los listados que ya se han capturado previamente.
        dataArray = clsServicesObj.strConsultarListado(Me._TRAER_LISTADO, Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, _MAX_PER_PAGE)

        Dim headers As ArrayList = New ArrayList()
        headers.Add("Identificador")
        headers.Add("Nombre")
        headers.Add("Activo")
        headers.Add("Acciones")

        Dim columnOrder As Integer() = {0, 1, 2}

        Dim actions As ArrayList = New ArrayList()
        Dim pkNames As String() = {"intMarcaRolloId"}
        Dim pkIndexes As Integer() = {0}
        actions.Add(New clsActionLink("Editar", pkNames, pkIndexes, "imgNREditar.gif", "Haga clic aquí para editar este listado"))


        If dataArray.Length > 0 Then
            elemArray = DirectCast(dataArray.GetValue(0), Array)
            totalRows = CInt(elemArray.GetValue(elemArray.Length - 1))
        End If
        htmlResult = clsHTMLUtils.displayScroll(totalRows, intSelectedPage, Me._MAX_PER_PAGE, Me.strThisPageName, Nothing, , "../static/images/")
        htmlResult += clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, intSelectedPage, Me._MAX_PER_PAGE, -1, , "../static/images/")

        Return htmlResult
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
        Dim widths As String() = {"20%", "60%", "20%"}
        Dim values As String() = {"Identificador", "Nombre", "Activo"}
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
        Dim values1 As String() = {"Reporte de Marcas de Rollos", "", "HOJA: " + currentPage.ToString + " / " + totalPages.ToString}
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
        Dim colsToShow As Integer() = {0, 1, 2}
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

