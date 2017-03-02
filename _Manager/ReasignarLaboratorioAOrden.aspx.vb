'====================================================================
' Class         : clsReasignarLaboratorioAOrden
' Title         : Grupo Benavides. Catálogo de Artículos (trabajos)
' Description   : Captura de Artículos
' Copyright     : 2003-2006 All rights reserved.
' Company       : Neitek Solutions S.A. de C.V.
' Author        : Carolina Caballero
' Version       : 1.0
' Last Modified :21/oct/2005
'====================================================================

#Region "Imports"
Imports System.Text
Imports System.Collections
Imports prjFotolabBusiness.Benavides.Fotolab.Utils
Imports prjFotolabBusiness.Benavides.Fotolab.Data
#End Region

Public Class clsReasignarLaboratorioAOrden
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
    Protected _strNumeroLaboratorio As String
    Protected _strOrdenSeleccionada As String    
    Protected _strbotones As Integer

    '====================================================================
    ' Name       : strbotones
    ' Description: Saber cual es el boton oprimido
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strbotones() As Integer
        Get
            Return _strbotones
        End Get
        Set(ByVal strValue As Integer)
            _strbotones = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strNumeroLaboratorio
    ' Description: Obtiene o establece el valor de numeroLaboratorio
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strNumeroLaboratorio() As String
        Get
            Return _strNumeroLaboratorio
        End Get
        Set(ByVal strValue As String)
            _strNumeroLaboratorio = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strOrdenSeleccionada
    ' Description: Obtiene o establece el valor de OrdenSeleccionada
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strOrdenSeleccionada() As String
        Get
            Return _strOrdenSeleccionada
        End Get
        Set(ByVal strValue As String)
            _strOrdenSeleccionada = strValue
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
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsReasignarLaboratorioAOrden.SERVICIOS
    End Sub

    '====================================================================
    ' Name       : strBuscarLaboratorio 
    ' Description: Busca un laboratorio por numero de laboratorio y regresa el html de la tabla que lo contiene
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : html de la tabla que contiene el laboratorio
    '====================================================================
    Protected Function strBuscarLaboratorio() As String
        Dim dataArray As Array = Nothing
        Dim html As String

        Dim headers As ArrayList = New ArrayList
        headers.Add("Laboratorio")
        headers.Add("Razón Social")
        
        Dim columnOrder As Integer() = {1, 2}
        Dim actions As ArrayList = New ArrayList

        dataArray = clsServicesObj.strConsultarListado("BuscarLaboratorio", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)

        If dataArray.Length = 0 Then
            html = ""
        Else
            html = prjFotolabBusiness.Benavides.Fotolab.Utils.clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, 1, Me._MAX_PER_PAGE, -1, , "../static/images/")
        End If

        Return html
    End Function



    '====================================================================
    ' Name       : strBuscarOrden 
    ' Description: Busca una orden por numero de orden y regresa el html de la tabla que lo contiene
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : html de la tabla que contiene la orden buscada
    '====================================================================
    Protected Function strBuscarOrden() As String
        Dim dataArray As Array = Nothing
        Dim html As String

        Dim headers As ArrayList = New ArrayList
        headers.Add("Estatus")
        headers.Add("Orden")
        headers.Add("Farmacia")
        headers.Add("Laboratorio")
        headers.Add("Fecha y hora Ingreso")
        headers.Add("Fecha y hora Compromiso")
        headers.Add("Acciones")

        Dim columnOrder As Integer() = {0, 1, 3, 2, 4, 5}
        Dim pkNames As String() = {"intOrdenId"}
        Dim pkIndexes As Integer() = {7}
        Dim actions As ArrayList = New ArrayList
        actions.Add(New clsActionLink("ReasignarOrdenIndividual", pkNames, pkIndexes, Me._IMG_ASIGNAR, "Haga clic aquí para Reasignar Individualmente"))

        dataArray = clsServicesObj.strConsultarListado("BuscarOrden", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
        html = prjFotolabBusiness.Benavides.Fotolab.Utils.clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, 1, Me._MAX_PER_PAGE, -1, , "../static/images/")
        'html = " parent.parent.document.getElementById('divLaboratorio').innerHTML=" + Chr(34) + htmlCombo + Chr(34) + ";"
        Return html
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
        Dim strRecordBrowserName As String = "Asignacion de Farmacias a Fotolabs"

        ' Declaramos e inicializamos las variables locales
        If strCmd = "" Then
            intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        Else
            intSelectedPage = CInt(strCmd)
        End If
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
        If (Request("strLaboratoriosId") <> "-1") And Request("strLaboratoriosId") <> "" Then
            Dim LabsIds() As String
            Dim auxArray(0) As Array
            Dim arrayItem As Array
            Dim j As Integer
            LabsIds = Split(Request("strLaboratoriosId"), ",")
            For j = 0 To LabsIds.Length - 1
                ReDim Preserve auxArray(j)
                arrayItem = clsServicesObj.strConsultarListado("TRAERLISTADOPORIDS", Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, Me._MAX_PER_PAGE, LabsIds(j) + " ,12")
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

        Dim headers As ArrayList = New ArrayList
        headers.Add("Laboratorio")
        headers.Add("Razón Social")
        'If Request("strCmd") = "Consultar" And Request("strbotones") = "3" Then
        headers.Add("Acciones")
        'End If
        'headers.Add("Acciones")

        Dim columnOrder As Integer() = {0, 1}

        Dim actions As ArrayList = New ArrayList
        Dim pkNames As String() = {"intSucursalId"}
        Dim pkIndexes As Integer() = {0}
        'If Request("strCmd") = "Consultar" Then
        actions.Add(New clsActionLink(Me._EDITAR, pkNames, pkIndexes, "imgNRVer.gif", "Haga clic aquí para ver el Detalle de este Cliente"))
        'End If
        ' por medio de estas validaciones obtengo el número total de registros  que  regreso la búsqueda
        ' no necesariamente es la longitud de mi Array (debido a la paginación), este dato del total por búsqueda esta contenido en la utlima columna
        ' de cada uno de mis registros, cuando no tengo este dato, el númerototal de registros el el total de elementos del arreglo
        If dataArray.Length > 0 Then
            elemArray = DirectCast(dataArray.GetValue(0), Array)
            If IsNumeric(elemArray.GetValue(elemArray.Length - 1)) Then '<- verifico si tiene un númeroel la ultima columna
                totalRows = CInt(elemArray.GetValue(elemArray.Length - 1)) ' lo asigno este valor a mi var de total de registros
            Else
                totalRows = dataArray.Length ' si no  tengo el valor de total de reg en mi ultima columna asigno el total de elementos del arreglo como el total
            End If
        End If
        htmlResult = clsHTMLUtils.displayScroll(totalRows, intSelectedPage, Me._MAX_PER_PAGE, "ReasignarLaboratorioAOrden.aspx", Nothing, , "../static/images/")
        If (Request("strLaboratoriosId") <> "-1") Then
            htmlResult += clsHTMLUtils.displayArrayTable(headers, dataArray, columnOrder, actions, intSelectedPage, Me._MAX_PER_PAGE, -1, , "../static/images/")
        Else
            htmlResult += clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, intSelectedPage, Me._MAX_PER_PAGE, -1, , "../static/images/")
        End If
        'htmlResult += "<br>"
        'htmlResult += "<input class=boton type=button value='Buscar Clientes' name=btnBuscarClientes>"
        'htmlResult += "<input class=boton type=button value='Regresar' name=btnRegresar>"

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
            Case "ReasignarOrdenIndividual"
                Me.strOrdenSeleccionada = Request("intOrdenId")
                Me.strNumeroLaboratorio = Request("strNumeroLaboratorio")
                Dim numLaboratorio As Integer = Integer.Parse(strNumeroLaboratorio)
                Dim labCompania As String = CStr(CInt(numLaboratorio / 1000))
                Dim labSucursal As String = CStr(CInt(numLaboratorio Mod 1000))
                clsServicesObj.strAfectarListado("ReasignarOrdenIndividual", Request, strConnectionString, Me.strUsuarioNombre, Me.strOrdenSeleccionada() + ", " + labCompania + "," + labSucursal + ", '" + Date.Now.ToString("MM/dd/yyyy HH:mm:ss") + "', '" + Me.strUsuarioNombre + "'")
            Case "ReasignarTodos"
                Me.strOrdenSeleccionada = "'" + Request("strOrdenesIds") + "'"
                Me.strNumeroLaboratorio = Request("strNumeroLaboratorio")
                Dim numLaboratorio As Integer = Integer.Parse(strNumeroLaboratorio)
                Dim labCompania As String = CStr(CInt(numLaboratorio / 1000))
                Dim labSucursal As String = CStr(CInt(numLaboratorio Mod 1000))
                clsServicesObj.strAfectarListado("ReasignarOrdenMultiple", Request, strConnectionString, Me.strUsuarioNombre, Me.strOrdenSeleccionada() + ", " + labCompania + "," + labSucursal + ", '" + Date.Now.ToString("MM/dd/yyyy HH:mm:ss") + "', '" + Me.strUsuarioNombre + "'")

        End Select

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
        Dim code As StringBuilder = New StringBuilder
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

    '====================================================================
    ' Name       : getData
    ' Description: Obtiene el arreglo de datos que se requiren para el listado.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Array
    '====================================================================
    Protected Overrides Function getData() As Array
        Dim dataArray As Array = Nothing
        dataArray = clsServicesObj.strConsultarListado(Me._TRAER_LISTADO, Nothing, strConnectionString, "", -1, -1)

        Return dataArray
    End Function

#End Region



End Class


