'====================================================================
' Class         : clsConsultaClientes
' Title         : Grupo Benavides. Catálogo de Artículos (trabajos)
' Description   : Captura de Artículos
' Copyright     : 2003-2006 All rights reserved.
' Company       : Neitek Solutions S.A. de C.V.
' Author        : Jorge Ventura Cantu Campos
' Version       : 1.0
' Last Modified : Wednesday, February 9Th, 2005
'====================================================================

#Region "Imports"
Imports System.Text
Imports System.Collections
Imports prjFotolabBusiness.Benavides.Fotolab.Utils
Imports prjFotolabBusiness.Benavides.Fotolab.Data
#End Region

Public Class clsConsultaClientesAdmin
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
    Protected _strSucursalNombre As String
    Protected _strSearch As String

    Protected _intSucursalIdDetalle As String
    Protected _intCompaniaIdDetalle As String
    Protected _strSucursalccsss As String
    Protected _strSucursalRazonSocial As String
    Protected _strSucursalZonaOperativa As String


    Protected _intDireccionOperativaId As Integer
    '====================================================================
    ' Name       : intDireccionOperativaId
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intDireccionOperativaId() As Integer
        Get
            Return _intDireccionOperativaId
        End Get
        Set(ByVal strValue As Integer)
            _intDireccionOperativaId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : _strSucursalRazonSocial
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strSucursalRazonSocial() As String
        Get
            Return _strSucursalRazonSocial
        End Get
        Set(ByVal strValue As String)
            _strSucursalRazonSocial = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strSucursalccsss
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strSucursalccsss() As String
        Get
            Return _strSucursalccsss
        End Get
        Set(ByVal strValue As String)
            _strSucursalccsss = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intSucursalIdDetalle
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intSucursalIdDetalle() As String
        Get
            Return _intSucursalIdDetalle
        End Get
        Set(ByVal strValue As String)
            _intSucursalIdDetalle = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intCompaniaIdDetalle
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intCompaniaIdDetalle() As String
        Get
            Return _intCompaniaIdDetalle
        End Get
        Set(ByVal strValue As String)
            _intCompaniaIdDetalle = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strSucursalZonaOperativa
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strSucursalZonaOperativa() As String
        Get
            Return _strSucursalZonaOperativa
        End Get
        Set(ByVal strValue As String)
            _strSucursalZonaOperativa = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strSearch 
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strSearch() As String
        Get
            Return _strSearch
        End Get
        Set(ByVal strValue As String)
            _strSearch = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strSucursalNombre
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strSucursalNombre() As String
        Get
            Return _strSucursalNombre
        End Get
        Set(ByVal strValue As String)
            _strSucursalNombre = strValue
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
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsConsultaClientes.SERVICIOS
    End Sub

    '====================================================================
    ' Name       : obtenerCombo Laboratorio
    ' Description: construye el combo de Laboratorios
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : html del Combo
    '====================================================================
    Protected Function obtenerComboLaboratorio() As String
        Dim dataArray As Array = Nothing
        Dim htmlCombo As String
        dataArray = clsServicesObj.strConsultarListado("LABORATORIO", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
        htmlCombo = prjFotolabBusiness.Benavides.Fotolab.Utils.clsHTMLUtils.buildCombo(dataArray, "cmbLaboratorio", 5, "comboTabla", "", True, "- Todos -", "javascript:selectRadio()")
        htmlCombo = " parent.parent.document.getElementById('divLaboratorio').innerHTML=" + Chr(34) + htmlCombo + Chr(34) + ";"
        Return htmlCombo
    End Function

    '====================================================================
    ' Name       : strGenerarlistado
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function strGenerarlistado(ByVal strCmd As String) As String

        Dim htmlResult As String
        Dim intSelectedPage, totalRows As Integer
        Dim dataArray, elemArray As Array
        Const intElementsPerPage As Integer = 1
        Dim strRecordBrowserName As String = "Clientes"

        ' Declaramos e inicializamos las variables locales
        intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        If intSelectedPage <= 0 Then
            'intSelectedPage = 1
            If IsNumeric(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request)) = True Then
                intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
                If intSelectedPage = -1 Then intSelectedPage = 1
            Else
                intSelectedPage = 1
            End If
        End If
        ' Obtenemos los listados que ya se han capturado previamente.
        If (Request("strCliente") = "") Then
            If (Request("strLaboratoriosId") <> "-1") And Request("strLaboratoriosId") <> "" Then
                Dim LabsIds() As String
                Dim auxArray(0) As Array
                Dim arrayItem As Array
                Dim j As Integer
                LabsIds = Split(Request("strLaboratoriosId"), ",")
                For j = 0 To LabsIds.Length - 1
                    ReDim Preserve auxArray(j)
                    arrayItem = clsServicesObj.strConsultarListado("TRAERLISTADOPORIDS", Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, Me._MAX_PER_PAGE, LabsIds(j) + " ,2")
                    auxArray.SetValue(arrayItem.GetValue(0), j)
                Next j
                dataArray = auxArray

                arrayItem = CType(dataArray.GetValue(0), Array)
                arrayItem.SetValue(CStr(dataArray.Length), arrayItem.Length - 1)
                dataArray.SetValue(arrayItem, 0)

            ElseIf (Request("intZonaOperativaId") <> "-1") And (Request("intZonaOperativaId") <> "") Then
                dataArray = clsServicesObj.strConsultarListado("TRAERLISTADOPORZONA", Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, Me._MAX_PER_PAGE)
            ElseIf (Request("intDireccionOperativaId") <> "-1") And (Request("intDireccionOperativaId") <> "") Then
                dataArray = clsServicesObj.strConsultarListado("TRAERLISTADOPORDIR", Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, Me._MAX_PER_PAGE)
            Else
                dataArray = clsServicesObj.strConsultarListado("TRAERLISTADOADMIN", Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, Me._MAX_PER_PAGE)
            End If

        Else
            dataArray = clsServicesObj.strConsultarListado("TRAERLISTADOCRITERIOADMIN", Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, Me._MAX_PER_PAGE)

        End If

        Dim headers As ArrayList = New ArrayList()
        headers.Add("Farmacia")
        headers.Add("Razón Social")
        headers.Add("Acciones")

        Dim columnOrder As Integer() = {0, 1}

        Dim actions As ArrayList = New ArrayList()
        Dim pkNames As String() = {"intSucursalId"}
        Dim pkIndexes As Integer() = {0}
        actions.Add(New clsActionLink(Me._EDITAR, pkNames, pkIndexes, "imgNRVer.gif", "Haga clic aquí para ver el Detalle de este Cliente"))

        ' por medio de estas validaciones obtengo el Número total de registros  que  regreso la búsqueda
        ' no necesariamente es la longitud de mi Array (debido a la paginación), este dato del total por búsqueda esta contenido en la utlima columna
        ' de cada uno de mis registros, cuando no tengo este dato, el Númerototal de registros el el total de elementos del arreglo
        If dataArray.Length > 0 Then
            elemArray = DirectCast(dataArray.GetValue(0), Array)
            If IsNumeric(elemArray.GetValue(elemArray.Length - 1)) Then '<- verifico si tiene un Númeroel la ultima columna
                totalRows = CInt(elemArray.GetValue(elemArray.Length - 1)) ' lo asigno este valor a mi var de total de registros
            Else
                totalRows = dataArray.Length ' si no  tengo el valor de total de reg en mi ultima columna asigno el total de elementos del arreglo como el total
            End If
        End If

        htmlResult = clsHTMLUtils.displayScroll(totalRows, intSelectedPage, Me._MAX_PER_PAGE, "ConsultaClientesAdmin.aspx", Nothing, , "../static/images/")
        htmlResult += clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, intSelectedPage, Me._MAX_PER_PAGE, -1, , "../static/images/")
        htmlResult += "<br>"
        htmlResult += "<input class=boton onclick=javascript:doSubmit('" + Me._IMPRIMIR + "') type=button value=Impresión name=btnImprimir>"
        htmlResult += "<input class=boton onclick=javascript:doSubmit('" + Me._EXPORTAR + "') type=button value=Exportar name=btnExportar>"
        Return htmlResult
    End Function

    '====================================================================
    ' Name       : strRecordBrowserHTMLSuc
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function strRecordBrowserHTMLSuc() As String
        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 1
        Dim strRecordBrowserName As String = "Clientes"

        Dim dataArray As Array = Nothing

        ' Obtenemos los listados que ya se han capturado previamente.
        dataArray = clsServicesObj.strConsultarListado("SUCURSALLISTADODETALLE", Request, strConnectionString, strUsuarioNombre, -1, -1)


        Dim headers As ArrayList = New ArrayList()
        headers.Add("Laboratorio")
        headers.Add("Razón Social")
        '        headers.Add("Acciones")

        Dim columnOrder As Integer() = {0, 1}

        Dim actions As ArrayList = New ArrayList()
        Dim pkNames As String() = {"intSucursalId"}
        Dim pkIndexes As Integer() = {0}
        '       actions.Add(New clsActionLink(Me._EDITAR, pkNames, pkIndexes, "imgNRVer.gif", "Haga clic aquí para ver el Detalle de este Cliente"))


        Dim htmlResult As String = ""
        htmlResult += clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, -1, -1, -1, , "../static/images/")

        Return htmlResult
    End Function


    '====================================================================
    ' Name       : strOtraAccion
    ' Description: Metodo llamado cuando  el strCmd es una accion nueva (esta libre a implementar en cada clase para metodos especiales)
    ' Parameters : 
    '              ByVal strCmd As  String
    '                 - Nombre del  comando a efectuar  
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function strOtraAccion(ByVal strCmd As String) As String
        Dim htmlResult As String
        Select Case strCmd
            Case "LABORATORIO"
                htmlResult = Me.obtenerComboLaboratorio()
        End Select

        Return htmlResult
    End Function


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
            htmlResult.Append("parent.parent.document.forms[0].intSucursalIdDetalle.value='")
            htmlResult.Append(rowArray.GetValue(2))
            htmlResult.Append("'; ")
            htmlResult.Append("parent.parent.document.forms[0].intCompaniaIdDetalle.value='")
            htmlResult.Append(rowArray.GetValue(1))
            htmlResult.Append("'; ")
            htmlResult.Append("parent.parent.document.getElementById('divSucursalccsss').innerHTML='")
            htmlResult.Append(rowArray.GetValue(2))
            htmlResult.Append("'; ")
            htmlResult.Append("parent.parent.document.getElementById('divSucursalRazonSocial').innerHTML='")
            htmlResult.Append(rowArray.GetValue(3))
            htmlResult.Append("'; ")
            htmlResult.Append("parent.parent.document.getElementById('divSucursalDireccionOperativa').innerHTML='")
            htmlResult.Append(rowArray.GetValue(5))
            htmlResult.Append("'; ")
            htmlResult.Append("parent.parent.document.getElementById('divSucursalZonaOperativa').innerHTML='")
            htmlResult.Append(rowArray.GetValue(4))
            htmlResult.Append("'; ")
            htmlResult.Append("parent.parent.document.getElementById('divRecordBrowserHTMLSuc').innerHTML=" + Chr(34) + Me.strRecordBrowserHTMLSuc() + Chr(34) + ";" + vbTab)
            Return htmlResult.ToString
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
        'Obtenemos los listados que ya se han capturado previamente.
        If (Request("strCliente") = "") Then
            If (Request("strLaboratoriosId") <> "-1") And Request("strLaboratoriosId") <> "" Then
                Dim LabsIds() As String
                Dim auxArray(0) As Array
                Dim arrayItem As Array
                Dim j As Integer
                LabsIds = Split(Request("strLaboratoriosId"), ",")
                For j = 0 To LabsIds.Length - 1
                    ReDim Preserve auxArray(j)
                    arrayItem = clsServicesObj.strConsultarListado("TRAERLISTADOPORIDS", Request, strConnectionString, Me.strUsuarioNombre, -1, -1, LabsIds(j) + " ,2")
                    auxArray.SetValue(arrayItem.GetValue(0), j)
                Next j
                dataArray = auxArray
                'arrayItem = CType(dataArray.GetValue(0), Array)
                'arrayItem.SetValue(CStr(dataArray.Length), arrayItem.Length - 1)
                'dataArray.SetValue(arrayItem, 0)
            ElseIf (Request("intZonaOperativaId") <> "-1") And (Request("intZonaOperativaId") <> "") Then
                dataArray = clsServicesObj.strConsultarListado("TRAERLISTADOPORZONA", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
            ElseIf (Request("intDireccionOperativaId") <> "-1") And (Request("intDireccionOperativaId") <> "") Then
                dataArray = clsServicesObj.strConsultarListado("TRAERLISTADOPORDIR", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
            Else
                dataArray = clsServicesObj.strConsultarListado("TRAERLISTADOADMIN", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
            End If
        Else
            dataArray = clsServicesObj.strConsultarListado("TRAERLISTADOCRITERIOADMIN", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
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
        Dim widths As String() = {"30%", "70%"}
        Dim values As String() = {"Farmacia", "Razón Social"}
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
        Dim colsToShow As Integer() = {0, 1}
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
    ' Description: Regresa el Número de columnas
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Protected Overrides Function getColumnNumber() As Integer
        Return 3
    End Function



#End Region



End Class


