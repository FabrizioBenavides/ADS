'====================================================================
' Class         : clsCapturaInventarioRotativo
' Title         : Grupo Benavides. Inventarios Rotativos.
' Description   : Captura de Inventarios Rotativos
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

Public Class clsCapturaInventarioRotativo
    Inherits System.Web.UI.Page
    Implements PrintInterface

    'CONSTANTES
    Public Const CAPTURA_INICIAL As Integer = 1
    Public Const CAPTURA_CON_INVENTARIO As Integer = 2
    Public Const BRINCAR_SIGUIENTE_PAGINA As Integer = 3
    Public Const BRINCAR_ANTERIOR_PAGINA As Integer = 4
    Public Const IMPRESION_DIFERENCIAS As Integer = 5

    'Variables globales
    Dim strmMensaje As String = ""
    Dim strmRecordBrowserHTML As String = ""
    Dim strmbtnAceptar As String = ""
    Private selDate As Date
    Private strmCommand As String

    Private _sucursalNombre As String
    Private _fechaActual As String
    Private _listadoNombre As String
    Private _dtmSelectedDate As String

    Private _intListadoId As Integer
    Private _intOrdenamiento As Integer
    Private _status As Integer
    Private _listadoEstatus As String


    '====================================================================
    ' Name       : sucursalNombre
    ' Description: Guarda el nombre de la sucursal
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property sucursalNombre() As String
        Get
            Return _sucursalNombre
        End Get
        Set(ByVal aValue As String)
            Me._sucursalNombre = aValue
        End Set
    End Property

    '====================================================================
    ' Name       : fechaActual
    ' Description: 
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property fechaActual() As String
        Get
            Return _fechaActual
        End Get
        Set(ByVal aValue As String)
            Me._fechaActual = aValue
        End Set
    End Property

    '====================================================================
    ' Name       : listadoNombre
    ' Description: 
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property listadoNombre() As String
        Get
            Return _listadoNombre
        End Get
        Set(ByVal aValue As String)
            Me._listadoNombre = aValue
        End Set
    End Property

    '====================================================================
    ' Name       : dtmSelectedDate
    ' Description: 
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property dtmSelectedDate() As String
        Get
            Return _dtmSelectedDate
        End Get
        Set(ByVal aValue As String)
            Me._dtmSelectedDate = aValue
        End Set
    End Property

    '====================================================================
    ' Name       : intListadoId
    ' Description: 
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intListadoId() As Integer
        Get
            Return _intListadoId
        End Get
        Set(ByVal aValue As Integer)
            Me._intListadoId = aValue
        End Set
    End Property

    '====================================================================
    ' Name       : intOrdenamiento
    ' Description: 
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intOrdenamiento() As Integer
        Get
            Return _intOrdenamiento
        End Get
        Set(ByVal aValue As Integer)
            Me._intOrdenamiento = aValue
        End Set
    End Property

    '====================================================================
    ' Name       : status
    ' Description: 
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property status() As Integer
        Get
            Return _status
        End Get
        Set(ByVal aValue As Integer)
            Me._status = aValue
        End Set
    End Property

    '====================================================================
    ' Name       : listadoEstatus
    ' Description: 
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property listadoEstatus() As String
        Get
            Return _listadoEstatus
        End Get
        Set(ByVal aValue As String)
            Me._listadoEstatus = aValue
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
            Return CInt(clsCommons.strReadCookie("intGrupoUsuarioId", "0", Context.Request, Server))
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
            Return ""
        End If

        ' Declaramos e inicializamos las constantes locales
        Dim htmlResult As String = ""
        Dim dataArray As Array = Nothing
        Dim maxPerPage As Integer = 46

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))

        If Me.status = Me.BRINCAR_SIGUIENTE_PAGINA Then
            'avanzar de pagina
            intSelectedPage += 1
        ElseIf Me.status = Me.BRINCAR_ANTERIOR_PAGINA Then
            'retroceder de pagina
            intSelectedPage -= 1
            If intSelectedPage <= 0 Then
                intSelectedPage = 1
            End If
        Else
            'en el caso de que hubo diferencias en inventario teorico.
            'o en el caso de captura de paginas subsecuentes

            'do nothing
        End If

        ' Obtenemos los listados inventarios Rotativos para la sucursal
        dataArray = clsCapturaListado.strBuscarDetalleListadosPorSucursal(intCompaniaId, intSucursalId, Me.selDate, Me.intListadoId, Me.intOrdenamiento, intSelectedPage, maxPerPage, strConnectionString)

        'verificar si hay mas paginas
        If Me.status = Me.BRINCAR_SIGUIENTE_PAGINA Then
            Dim totalRows As Integer = dataArray.Length()
            Dim maxInPage As Integer = intSelectedPage * maxPerPage
            Dim minInPage As Integer = maxInPage - (maxPerPage - 1)

            If (totalRows >= minInPage) Then
                'todavia se despliega la pagina actual
                Me.status = Me.CAPTURA_INICIAL
            Else
                'ya no hay mas registros
                Me.status = Me.IMPRESION_DIFERENCIAS
            End If
        End If

        If Me.status = Me.BRINCAR_ANTERIOR_PAGINA Then
            'todavia se despliega la pagina actual
            Me.status = Me.CAPTURA_INICIAL
        End If

        If Me.status = Me.IMPRESION_DIFERENCIAS Then
            'se llego a la ultima pagina, 
            'mostrar la pagina con diferencias si es que existe, o
            'en caso de no haber, mostrar una pagina de captura exitosa.
            htmlResult = Me.desplegarCapturaCompletada()

            'guardar el inventario como cerrado
            Me.cerrarInventario()


        ElseIf Me.status = Me.CAPTURA_CON_INVENTARIO Then
            'desplegar la captura de inventario real junto con inventario teorico
            htmlResult = Me.desplegarCapturaConInventario(dataArray, intSelectedPage, maxPerPage, "intCifraControl")

        Else
            'desplegar la captura normal, solo inventario real
            htmlResult = Me.desplegarCapturaNormal(dataArray, intSelectedPage, maxPerPage, "intCifraControl")

        End If



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

        Me.listadoEstatus = Request("listadoEstatus")
        Dim selectedDate As Date = clsDateUtil.StringToDate(Request("dtmSelectedDate"), clsDateUtil.DATE_FORMAT)
        Dim esDeHoy As Integer = selectedDate.CompareTo(Today)
        Dim esDeAyer As Integer = selectedDate.CompareTo(Today.AddDays(-1))

        If Not (esDeHoy = 0 OrElse esDeAyer = 0) Then
            'SOLO CONSULTAR INFO
            Me.listadoEstatus = "CC"
        End If

    End Sub

#End Region


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, Me.strConnectionString) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        'Me.btnImprimirDiferencias.Visible = False

        'Calcular fecha actual:
        Me.fechaActual = Now.ToString(clsDateUtil.DATE_HOUR_NO_SECONDS_FORMAT)
        Me.sucursalNombre = Me.intCompaniaId.ToString + " - " + Me.intSucursalId.ToString + " " + Me.strSucursalNombre.ToString
        Me.dtmSelectedDate = Request("dtmSelectedDate")
        Me.intListadoId = CInt(Request("intListadoId"))
        Me.selDate = clsDateUtil.StringToDate(Me.dtmSelectedDate, clsDateUtil.DATE_FORMAT)
        Me.listadoNombre = Request("listadoNombre")
        Me.intOrdenamiento = CInt(Request("intOrdenamiento"))

        Me.status = CInt(Request("status"))
        'If Me.status Is Nothing OrElse Me.status = "" Then
        If Me.status = 0 Then
            Me.status = CAPTURA_INICIAL
        End If

        ' Almacenamos el comando ejecutado
        strCmd = com.isocraft.commons.clsWeb.strGetPageParameter("strCmd", com.isocraft.commons.clsWeb.strGetPageParameter("cmdConsultar", ""), Request)

        Select Case strCmd
            Case "paginaAnterior"
                Me.btnPrevious_Click()
            Case "grabar"
                Me.btnSave_Click()
            Case "ImprimirDiferencias"
                Me.btnImprimirDiferencias_Click()
        End Select


    End Sub

    Public Sub btnSave_Click()
        Me.saveInfo()
    End Sub

    Public Sub btnImprimirDiferencias_Click()
        Session.Add("printDocument", Me)
        Dim script As String = "<script for=window event=onload>printDocument()</script>"
        Page.RegisterClientScriptBlock("openWindowScript", script)
    End Sub

    Public Sub btnPrevious_Click()
        Me.saveInfo()

        'cambia el estatus, brinca pagina anterior
        Me.status = Me.BRINCAR_ANTERIOR_PAGINA
    End Sub


#Region "metodos privados"

    Private Sub cerrarInventario()
        If (Me.listadoEstatus = "CI") Then
            'si la captura esta incompleta:
            clsCapturaListado.intCerrarInventario(Me.intCompaniaId, Me.intSucursalId, Me.intListadoId, Me.selDate, Now, Me.strUsuarioNombre, Me.strConnectionString)
        End If

    End Sub

    Private Sub leerCantidades(ByRef values As ArrayList, ByRef cifraControl As Integer)
        Dim index As Integer = 0
        For index = 0 To 45
            Dim key As Integer = CInt(Request("id_" + index.ToString))
            Dim value As Integer = CInt(Request("amount" + index.ToString))

            values.Add(New DictionaryEntry(key, value))
            cifraControl += value
        Next
    End Sub

    Private Sub guardarExistenciaReal(ByVal values As ArrayList)

        If (Me.listadoEstatus = "CI") Then
            'si la captura esta incompleta:

            Dim index As Integer = 0
            Dim totalItems As Integer = values.Count
            Dim currentDate As DateTime = Now

            For index = 0 To totalItems - 1
                Dim item As DictionaryEntry = CType(values.Item(index), DictionaryEntry)
                Dim articuloId As Integer = CInt(item.Key())
                Dim existencia As Integer = CInt(item.Value())

                clsCapturaListado.intActualizar(Me.intCompaniaId, Me.intSucursalId, Me.intListadoId, articuloId, Me.selDate, existencia, 0, currentDate, Me.strUsuarioNombre, Me.strConnectionString)
            Next
        End If

    End Sub

    Private Function getNumeroArticulosAsString(ByVal values As ArrayList) As String
        Dim result As String = ""

        Dim index As Integer = 0
        Dim totalItems As Integer = values.Count

        For index = 0 To totalItems - 1
            Dim item As DictionaryEntry = CType(values.Item(index), DictionaryEntry)
            Dim articuloId As Integer = CInt(item.Key())
            result += articuloId.ToString + ","
        Next

        result = clsStringUtil.Chop(result, ",")

        Return result
    End Function

    'regresa el numero de diferencias
    Private Function compararInventarios(ByVal numArticulos As String, ByVal values As ArrayList) As Integer
        Dim result As Integer = 0
        Dim diferenciasArray As Array = clsCapturaListado.strCompararInventarios(Me.intCompaniaId, Me.intSucursalId, Me.intListadoId, Me.selDate, numArticulos, Me.strConnectionString)

        'recorrer registros y comparar inventario real con el teorico
        Dim item As Array
        For Each item In diferenciasArray
            Dim articuloId As Integer = CInt(item.GetValue(0))  'articuloId
            Dim existenciaReal As Integer = CInt(item.GetValue(1))  'existencia Real
            Dim existenciaTeorica As Object = item.GetValue(2)    'existencia teorica

            If existenciaTeorica Is Nothing OrElse existenciaTeorica.ToString() = "" Then
                'si es null, es que no se encontro informacion de su existencia teorica
                'marcar como diferencia
                result += 1
            ElseIf existenciaReal <> CInt(existenciaTeorica) Then
                result += 1
            End If
        Next

        'regresa el numero de diferencias en el bloque de registros actual
        Return result

    End Function


    Private Sub guardarFueCapturado(ByVal numArticulos As String)

        If (Me.listadoEstatus = "CI") Then
            'si la captura esta incompleta:

            Dim currentDate As DateTime = Now
            clsCapturaListado.intActualizarCapturaCorrecta(Me.intCompaniaId, Me.intSucursalId, Me.intListadoId, Me.selDate, numArticulos, currentDate, Me.strUsuarioNombre, Me.strConnectionString)

            'cambia el estatus, brinca de pagina
            Me.status = Me.BRINCAR_SIGUIENTE_PAGINA
        End If

    End Sub

    Private Function desplegarCapturaNormal(ByVal dataArray As Array, ByVal intSelectedPage As Integer, ByVal maxPerPage As Integer, ByVal cifraControlName As String) As String
        Dim htmlResult As String = ""

        Dim headers As ArrayList = New ArrayList()
        headers.Add("Código")
        headers.Add("Descripción")
        headers.Add("Existencia")

        Dim columnOrder As Integer() = {0, 1, 2}
        Dim editableColumns As String() = {"", "", "amount"}
        Dim fieldsEnabled As Boolean = True

        If Me.listadoEstatus = "CC" Then
            fieldsEnabled = False
        End If

        htmlResult = clsHTMLUtils.displayEditableTable(headers, dataArray, columnOrder, editableColumns, True, cifraControlName, 0, fieldsEnabled, intSelectedPage, maxPerPage)
        htmlResult += clsHTMLUtils.displayPagination(dataArray.Length, intSelectedPage, maxPerPage)

        Return htmlResult
    End Function


    Private Function desplegarCapturaConInventario(ByVal dataArray As Array, ByVal intSelectedPage As Integer, ByVal maxPerPage As Integer, ByVal cifraControlName As String) As String
        Dim htmlResult As String = ""

        Dim headers As ArrayList = New ArrayList()
        headers.Add("Código")
        headers.Add("Descripción")
        headers.Add("Existencia")
        headers.Add("Inv. Teórico")

        Dim columnOrder As Integer() = {0, 1, 2, 3}
        Dim editableColumns As String() = {"", "", "amount", ""}
        Dim columnsToCompare As Integer() = {2, 3}
        Dim fieldsEnabled As Boolean = True

        If Me.listadoEstatus = "CC" Then
            'campos deshabilitados, no mostrar inventario teorico
            fieldsEnabled = False
            htmlResult = clsHTMLUtils.displayEditableTable(headers, dataArray, columnOrder, editableColumns, True, cifraControlName, 0, fieldsEnabled, intSelectedPage, maxPerPage)

        Else
            'campos habilitados y desplegar comparacion con inventario teorico
            'Dim row As Array = CType(dataArray.GetValue(0), Array)
            'Dim valueA As String = row.GetValue(columnsToCompare(0)).ToString
            'Dim valueB As String = row.GetValue(columnsToCompare(1)).ToString

            'If (valueA <> valueB) Then
            '    Dim textFieldStyleSheet As String = "campoRojo"
            'End If

            htmlResult = clsHTMLUtils.displayEditableTableAndCompare(headers, dataArray, columnOrder, editableColumns, columnsToCompare, True, cifraControlName, 0, intSelectedPage, maxPerPage)
        End If


        htmlResult += clsHTMLUtils.displayPagination(dataArray.Length, intSelectedPage, maxPerPage)

        Return htmlResult
    End Function

    Private Function desplegarCapturaCompletada() As String
        Dim htmlResult As String = ""

        If (Me.listadoEstatus = "CI") Then
            'si la captura esta incompleta:
            htmlResult = "Captura Completa"
        Else
            htmlResult = "Final de Consulta de Inventario Rotativo"
        End If

        Return htmlResult

    End Function

    Private Function sucursalNombreCompleto() As String
        Return Me.intCompaniaId.ToString + " - " + Me.intSucursalId.ToString + " " + Me.strSucursalNombre
    End Function

    Private Sub saveInfo()
        Try
            If Me.listadoEstatus = "CC" Then

                Me.status = Me.BRINCAR_SIGUIENTE_PAGINA
                Return
            End If

            Dim values As ArrayList = New ArrayList
            Dim cifraControlCalculated As Integer = 0
            Dim cifraControlRequest As Integer = 0


            'leer todos los valores del request
            Me.leerCantidades(values, cifraControlCalculated)

            'la cifra de control, ya viene validada desde javascript

            'guardar existenciaReal en tblArticuloPlano
            guardarExistenciaReal(values)

            Dim numArticulos As String = getNumeroArticulosAsString(values)

            If Me.status = Me.CAPTURA_CON_INVENTARIO Then
                'guardar cambios en db solamente
                'ya no se realiza comparacion con inventario teorico
                Me.guardarFueCapturado(numArticulos)
            Else
                'Comparacion con inventario teorico
                Dim diferenciasEnInventarios As Integer = Me.compararInventarios(numArticulos, values)

                'si todo es correcto, guardar los registros del bloque actual como FueCapturado = 1
                If diferenciasEnInventarios = 0 Then
                    'si todo es correcto, pasar a la siguiente pagina.
                    ' si ya no hay mas paginas, desplegar el boton "Imprimir Diferencias" 
                    ' y quitar el de "Salvar Captura"

                    Me.guardarFueCapturado(numArticulos)

                Else
                    'desplegar las diferencias de los inventarios teorico y real
                    Me.status = CAPTURA_CON_INVENTARIO

                End If  'ends If diferencias = 0 Then
            End If

        Catch ex As Exception
            Dim msg As String = ex.Message()
            Dim stackTrace As String = ex.StackTrace.ToString()
        End Try

    End Sub

#End Region

#Region "metodos de la interface PrintInterface"

    Function addPagination() As Boolean Implements PrintInterface.addPagination
        Return True
    End Function

    Function getHeaders() As String Implements PrintInterface.getHeaders
        Dim code As StringBuilder = New StringBuilder()

        If Me.intOrdenamiento = clsConsultaInventarioRotativo.PLANOGRAMA Then
            Dim widths As String() = {"7%", "30%", "7%", "30%", "10%", "10%", "6"}
            Dim values As String() = {"#Plano", "Planograma", "Código", "Descripción", "Existencia", "Inv. Teórico", "Diferencia"}

            code.Append(clsHTMLUtils.getTagTR("th", 7, "rayita", "txcont", widths, values))
        Else
            Dim widths As String() = {"20%", "50%", "10%", "10%", "10%"}
            Dim values As String() = {"Código", "Descripción", "Existencia", "Inv. Teórico", "Diferencia"}

            code.Append(clsHTMLUtils.getTagTR("th", 5, "rayita", "txcont", widths, values))
        End If

        Return code.ToString
    End Function

    Function getTitle(ByVal currentPage As Integer, ByVal totalPages As Integer) As String Implements PrintInterface.getTitle
        Dim code As StringBuilder = New StringBuilder()
        Dim widths As String() = {"20%", "50%", "10%", "20%"}
        Dim styles As String() = {"txtitulo", "txcontenidobold", "txcontenidobold"}
        Dim values2 As String() = {"Sucursal:", Me.sucursalNombreCompleto(), "", "Fecha: " + Today.ToString(clsDateUtil.DATE_FORMAT)}
        Dim values3 As String() = {"Listado:", Me.listadoNombre, "", ""}
        Dim values4 As String() = {"Fecha de Inventario:", selDate.ToString(clsDateUtil.DATE_FORMAT), "", ""}


        Dim title1 As String = " <tr><td class='txtitulo' colspan='3' width='80%'>Diferencia entre Existencia Real e Inventario Teórico ( MERMA )</td>"
        title1 += "<td class='txcontenidobold' width='20%'>HOJA: " + currentPage.ToString + " / " + totalPages.ToString + "</td></tr>"

        code.Append(clsHTMLUtils.BEGIN_TABLE)
        code.Append(title1)
        code.Append(clsHTMLUtils.getTagTR("td", 4, "txcontenidobold", widths, values2))
        code.Append(clsHTMLUtils.getTagTR("td", 4, "txcontenidobold", widths, values3))
        code.Append(clsHTMLUtils.getTagTR("td", 4, "txcontenidobold", widths, values4))
        code.Append(clsHTMLUtils.END_TABLE)

        Return code.ToString
    End Function

    Function getRow(ByVal aRow As Array, ByVal globalRowCounter As Integer) As String Implements PrintInterface.getRow
        Dim code As StringBuilder = New StringBuilder()
        Dim existenciaReal As Integer = CInt(aRow.GetValue(2))
        Dim invTeorico As Object = aRow.GetValue(3)
        Dim diferencia As String = "0"

        Try
            Dim invTeoricoAsInteger As Integer = CInt(invTeorico)
            diferencia = (existenciaReal - invTeoricoAsInteger).ToString()
        Catch ex As Exception
            diferencia = existenciaReal.ToString
        End Try


        code.Append("<tr>")
        If Me.intOrdenamiento = clsConsultaInventarioRotativo.PLANOGRAMA Then
            code.Append(clsPrintUtil.getCell(aRow.GetValue(5).ToString))    '#Plano
            code.Append(clsPrintUtil.getCell(Mid(aRow.GetValue(6).ToString, 1, 32)))  'Planograma 
        End If

        code.Append(clsPrintUtil.getCell(aRow.GetValue(0).ToString))        'Codigo
        code.Append(clsPrintUtil.getCell(Mid(aRow.GetValue(1).ToString, 1, 32)))      'Descripcion
        code.Append(clsPrintUtil.getCell(existenciaReal.ToString))          'Existencia Real
        code.Append(clsPrintUtil.getCell(invTeorico.ToString))              'Inv. Teorico
        code.Append(clsPrintUtil.getCell(diferencia))                       'Diferencia

        code.Append("</tr>")

        Return code.ToString
    End Function

    Function getFooter() As String Implements PrintInterface.getFooter
        Return ""
    End Function

    Function getData() As Array Implements PrintInterface.getData
        Dim dataArray As Array = Nothing

        ' Obtenemos los listados que ya se han capturado previamente.
        dataArray = clsCapturaListado.strBuscarDetalleListadosPorSucursalSoloDiferencias(intCompaniaId, intSucursalId, Me.selDate, Me.intListadoId, Me.intOrdenamiento, 1, 46, strConnectionString)

        Return dataArray
    End Function

    Function getColumnNumber() As Integer Implements PrintInterface.getColumnNumber
        Return 5
    End Function

#End Region


End Class
