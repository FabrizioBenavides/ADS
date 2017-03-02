'====================================================================
' Class         : clsConsultaInventarioRotativo
' Title         : Grupo Benavides. Inventarios Rotativos.
' Description   : Consulta de Inventarios Rotativos
' Copyright     : 2003-2006 All rights reserved.
' Company       : Neitek S.A. de C.V.
' Author        : Carolina Caballero
' Version       : 1.0
' Last Modified : Monday, October 25th, 2004
'====================================================================


Imports System.Configuration
Imports System.Text
Imports System.Collections

Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports prjCCInventarioBusiness.Benavides.InvRot.Utils
Imports prjCCInventarioBusiness.Benavides.InvRot.Data

Public Class clsConsultaInventarioRotativo
    Inherits System.Web.UI.Page
    Implements PrintInterface

    'Constantes
    Public Const PLANOGRAMA As Integer = 1
    Public Const ALFABETICO As Integer = 2

    'Variables globales
    Dim strmMensaje As String = ""
    Dim strmRecordBrowserHTML As String = ""
    Dim strmbtnAceptar As String = ""
    'Protected WithEvents dateSelection1 As System.Web.UI.WebControls.RadioButton
    'Protected WithEvents currentDate As System.Web.UI.WebControls.TextBox
    'Protected WithEvents dateSelection2 As System.Web.UI.WebControls.RadioButton
    'Protected WithEvents selectedDate As System.Web.UI.WebControls.TextBox
    'Protected WithEvents btnAceptar As System.Web.UI.HtmlControls.HtmlInputButton
    'Protected WithEvents btnX As System.Web.UI.HtmlControls.HtmlInputButton

    Public _dateSelection As String
    Public _currentDate As String
    Public _selectedDate As String


    Protected selDate As Date
    Private strmCommand As String
    Protected selectedListadoId As Integer
    Protected selectedOrdenamiento As Integer
    Protected selectedNombreListado As String

    Public Function isChecked(ByVal radioBtn As String) As String
        If (dateSelection = radioBtn) Then
            Return "checked"
        Else
            Return ""
        End If
    End Function

    '====================================================================
    ' Name       : _selectedDate
    ' Description: Obtiene o establece 
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property selectedDate() As String
        Get
            Return _selectedDate
        End Get
        Set(ByVal strValue As String)
            _selectedDate = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : currentDate
    ' Description: Obtiene o establece 
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property currentDate() As String
        Get
            Return _currentDate
        End Get
        Set(ByVal strValue As String)
            _currentDate = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : dateSelection
    ' Description: Obtiene o establece 
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property dateSelection() As String
        Get
            Return Request("radioSelDate")
        End Get
        Set(ByVal strValue As String)
            _dateSelection = strValue
        End Set
    End Property


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
    ' Name       : strCentroLogisticoId
    ' Description: Valor de la Compañia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCentroLogisticoId() As String
        Get
            Return (clsCommons.strReadCookie("strCentroLogisticoId", "", Context.Request, Server))
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
            Return CInt(clsCommons.strReadCookie("intCompaniaId", "0", Context.Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Valor de la Sucursal
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intSucursalId() As Integer
        Get
            Return CInt(clsCommons.strReadCookie("intSucursalId", "0", Context.Request, Server))
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
            Return clsCommons.strReadCookie("strSucursalNombre", "0", Context.Request, Server)
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
            Return clsCommons.strReadCookie("strUsuarioNombre", "0", Context.Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Obtiene la cadena de conexión hacia la base de datos
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
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
            Return clsConcentrador.strObtenerURLSucursal(intCompaniaId, intSucursalId, Me.strConnectionString)
        End Get
    End Property

    '====================================================================
    ' Name       : strbtnAceptar
    ' Description: Pinta el boton de aceptar y cancelar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strbtnAceptar() As String
        Get
            Return strmbtnAceptar
        End Get
        Set(ByVal strValue As String)
            strmbtnAceptar = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCmd 
    ' Description: Obtiene o establece el comando actual
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strCmd() As String
        Get
            Return strmCommand
        End Get
        Set(ByVal strValue As String)
            strmCommand = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Genera el HTML para el record browser con los listados
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================

    Public Function strRecordBrowserHTML() As String

        If Me.selDate = Nothing Then
            Return "<!-- CCL: FUNCION  strRecordBrowserHTML, no tiene nada que mostrar -->"
        End If

        ' Declaramos e inicializamos las constantes locales
        Dim htmlResult As String = "<!-- CCL: FUNCION  strRecordBrowserHTML, sacar listado --> "
        Const intElementsPerPage As Integer = 1
        Dim dataArray As Array = Nothing

        ' Declaramos e inicialziamos las variables locales
        Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        If intSelectedPage <= 0 Then
            intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
        End If

        ' Obtenemos los listados inventarios Rotativos para la sucursal
        dataArray = clsCapturaListado.strBuscarListadosPorSucursal(intCompaniaId, intSucursalId, Me.selDate, 1, intElementsPerPage, strConnectionString)

        Dim headers As ArrayList = New ArrayList
        headers.Add("Identificador")
        headers.Add("Nombre")
        headers.Add("Ordenamiento")
        headers.Add("Estatus")
        headers.Add("Acciones")

        Dim columnOrder As Integer() = {0, 1, 3, 5}

        Dim actions As ArrayList = New ArrayList
        Dim pkNames As String() = {"intListadoId", "dtmSelectedDate", "listadoNombre", "intOrdenamiento", "listadoEstatus"}
        Dim pkIndexes As Integer() = {0, 2, 1, 4, 5}
        actions.Add(New clsActionLink("Imprimir", pkNames, pkIndexes, "icono_imprimir.gif", "Haga clic aquí para Imprimir este listado"))
        'actions.Add(New clsActionLink("Capturar", pkNames, pkIndexes, "icono_capturar.gif", "Haga clic aquí para Capturar este listado"))

        Dim maxPerPage As Integer = 10
        htmlResult += clsHTMLUtils.displayScroll(dataArray.Length, intSelectedPage, maxPerPage, "ListadoParaInventariosRotativos.aspx", Nothing)
        htmlResult += clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, intSelectedPage, maxPerPage, -1)

        Return htmlResult


    End Function


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


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, Me.strConnectionString) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        'Calcular fecha actual:
        Me.currentDate = Today.ToString("dd/MM/yyyy")

        ' Almacenamos el comando ejecutado
        strCmd = com.isocraft.commons.clsWeb.strGetPageParameter("strCmd", com.isocraft.commons.clsWeb.strGetPageParameter("cmdConsultar", ""), Request)
        setSelectedValues()

        Dim script1 As String = "<!-- CCL: PASO POR LA FUNCION Page_Load strCmd?" + strCmd + "-->"
        Page.RegisterClientScriptBlock("x1", script1)

        Select Case strCmd
            Case "Imprimir"
                Session.Add("printDocument", Me)

                Dim script As String = "<script for=window event=onload>printDocument()</script>"
                Page.RegisterClientScriptBlock("openWindowScript", script)
        End Select

    End Sub




    Private Sub setSelectedDate()

        Dim radioValue As String = Request("radioSelDate")

        If radioValue = "1" Then
            selDate = Today
        ElseIf radioValue = "2" Then
            Me.selectedDate = Request("selectedDate")
            If selectedDate <> "" Then
                selDate = clsDateUtil.StringToDate(Me.selectedDate, "dd/MM/yyyy")
            End If
        End If

    End Sub

    Private Sub setSelectedValues()
        Me.setSelectedDate()

        If (Request("intListadoId") <> "") Then
            Me.selectedListadoId = CInt(Request("intListadoId"))
        End If

        If (Request("intOrdenamiento") <> "") Then
            Me.selectedOrdenamiento = CInt(Request("intOrdenamiento"))
        End If

        If (Request("listadoNombre") <> "") Then
            Me.selectedNombreListado = Request("listadoNombre")
        End If

    End Sub

    Private Function sucursalNombreCompleto() As String
        Return Me.strCentroLogisticoId & " - " & Trim(Me.strSucursalNombre) & " (" & Me.intCompaniaId.ToString & Me.intSucursalId.ToString("000") & ")"
    End Function

#Region "metodos de la interface PrintInterface"

    Function addPagination() As Boolean Implements PrintInterface.addPagination
        Return True
    End Function



    Function getTitle(ByVal currentPage As Integer, ByVal totalPages As Integer) As String Implements PrintInterface.getTitle
        Dim code As StringBuilder = New StringBuilder
        Dim widths As String() = {"20%", "50%", "10%", "20%"}
        Dim styles As String() = {"txtitulo", "txcontenidobold", "txcontenidobold"}
        Dim values2 As String() = {"Sucursal:", sucursalNombreCompleto(), "", "Fecha: " + Today.ToString("dd/MM/yyyy")}
        Dim values3 As String() = {"Fecha de Inventario:", selDate.ToString("dd/MM/yyyy"), "", ""}


        Dim title1 As String = " <tr><td class='txtitulo' colspan='3' width='80%'>Listado para Toma Física </td>"
        title1 += "<td class='txcontenidobold' width='20%'>HOJA: " + currentPage.ToString + " / " + totalPages.ToString + "</td></tr>"

        Dim title2 As String = "<tr><td class='txtitulo' colspan='4' width='100%' align='center'>" & Me.selectedNombreListado & "</td></tr>"

        code.Append(clsHTMLUtils.BEGIN_TABLE)
        code.Append(title1)
        code.Append(title2)
        code.Append(clsHTMLUtils.getTagTR("td", 4, "txcontenidobold", widths, values2))
        code.Append(clsHTMLUtils.getTagTR("td", 4, "txcontenidobold", widths, values3))
        code.Append(clsHTMLUtils.END_TABLE)

        Return code.ToString
    End Function

    Function getHeaders() As String Implements PrintInterface.getHeaders
        Dim code As StringBuilder = New StringBuilder

        If Me.selectedOrdenamiento = PLANOGRAMA Then
            'Por planograma

            Dim widths As String() = {"5%", "7%", "7%", "51%", "10%", "10%", "10%", "10%"}
            Dim values As String() = {"#", "#Plano", "Código Prod.", "Descripción", "Teorico", "Cant. Bodega", "Cant. Piso", "Total"}

            code.Append(clsHTMLUtils.getTagTR("th", 9, "rayita", "txcont", widths, values))

        Else
            'Alfabeticamente
            Dim widths As String() = {"5%", "10%", "25%", "10%", "10%", "10%", "10%"}
            Dim values As String() = {"#", "Código Prod.", "Descripción", "Teorico", "Cant. Bodega", "Cant. Piso", "Total"}

            code.Append(clsHTMLUtils.getTagTR("th", 7, "rayita", "txcont", widths, values))

        End If

        Return code.ToString

    End Function


    Function getRow(ByVal aRow As Array, ByVal globalRowCounter As Integer) As String Implements PrintInterface.getRow
        Dim code As StringBuilder = New StringBuilder

        code.Append("<tr>")
        'columna de indice
        code.Append(clsPrintUtil.getCell(globalRowCounter.ToString))

        If Me.selectedOrdenamiento = planograma Then
            'columna de #Planograma
            code.Append(clsPrintUtil.getCell(aRow.GetValue(5).ToString))

            'columna de Planograma
            Dim planograma As String = aRow.GetValue(6).ToString

        End If

        'columna de Codigo de Articulo
        code.Append(clsPrintUtil.getCell(aRow.GetValue(0).ToString))

        'columna de Descripcion
        Dim descr As String = aRow.GetValue(1).ToString
        code.Append(clsPrintUtil.getCell(clsStringUtil.TruncString(descr, 46)))

        'columna de Teorico
        code.Append(clsPrintUtil.getCell(aRow.GetValue(3).ToString))

        'columna de Cantidad Bodega
        code.Append(clsPrintUtil.getCell("________"))

        'columna de Cantidad Piso
        code.Append(clsPrintUtil.getCell("________"))

        'columna de Cantidad Total
        code.Append(clsPrintUtil.getCell("________"))

        code.Append("</tr>")
        Return code.ToString

    End Function

    Function getFooter() As String Implements PrintInterface.getFooter
        'regresar Captura de Cifra de control
        Dim code As StringBuilder = New StringBuilder
        Dim colspan As Integer

        If Me.selectedOrdenamiento = PLANOGRAMA Then
            colspan = 7
        Else
            colspan = 6
        End If

        code.Append("<tr>")
        code.Append(" <td colspan='")
        code.Append(colspan)
        code.Append("' class='tdblancoSinRaya9px' align='right'>Cifra de Control:</td>")
        code.Append(" <td class='tdblancoSinRaya9px'>________</td>")
        code.Append("</tr>")

        Return code.ToString
    End Function

    Function getData() As Array Implements PrintInterface.getData
        Dim dataArray As Array = Nothing

        ' Obtenemos los articulos a inventariar

        dataArray = clsCapturaListado.strBuscarDetalleListadosPorSucursal(Me.intCompaniaId, Me.intSucursalId, Me.selDate, Me.selectedListadoId, Me.selectedOrdenamiento, 1, 1, strConnectionString)


        Return dataArray
    End Function

    Function getColumnNumber() As Integer Implements PrintInterface.getColumnNumber
        Return 9
    End Function

#End Region
End Class
