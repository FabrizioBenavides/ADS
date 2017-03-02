'====================================================================
' Class         : clsSucursalHabilitarInventarioRotativo
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Habilitar o Deshabilitar sucursales para captura de Inventarios Rotativos
' Copyright     : 2003-2006 All rights reserved.
' Company       : Neitek S.A. de C.V.
' Author        : Carolina Caballero
' Version       : 1.0
' Last Modified : Friday, Oct 01, 2004
'====================================================================

Imports System.Text
Imports System.Collections
Imports System.Web.UI.WebControls

Imports prjCCInventarioBusiness.Benavides.InvRot.Utils
Imports prjCCInventarioBusiness.Benavides.InvRot.Data

Public Class clsSucursalSinCierreInventario
    Inherits System.Web.UI.Page
    Implements PrintInterface

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dateSelection1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents selectedDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents dateSelection2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    Protected WithEvents btnAceptar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents currentDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents intDireccionId As System.Web.UI.WebControls.ListBox
    Protected WithEvents btnImprimir As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnExportar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents selectedDirectionId As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    ' Variables locales privadas
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private selDate As Date
    Private selectedDireccion As Integer
    Private selectedDireccionNombre As String
    Private toExport As Boolean


    'ccl
    Private Const intArticulosXPagina As Integer = 32

    'ccl
    '====================================================================
    ' Name       : intPaginaId
    ' Description: Página a desplegar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intPaginaId() As String
        Get
            If Len(Request.Form("txtNumeroPagina")) > 0 Then
                Return Request.Form("txtNumeroPagina")
            Else
                Return "1"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)
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
            Return CInt(Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strHTMLFechaHora
    ' Description: Genera la fecha y hora de la página
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime(clsDateUtil.DATE_HOUR_FORMAT)
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
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request)
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
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: Establece los comandos Javascript del evento OnLoad
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strJavascriptWindowOnLoadCommands() As String
        Get
            Return strmJavascriptWindowOnLoadCommands
        End Get
        Set(ByVal strValue As String)
            strmJavascriptWindowOnLoadCommands = strValue
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
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String
        Dim htmlResult As String = ""

        If Me.selDate = Nothing OrElse Me.selectedDireccion <= 0 Then
            Return ""
        End If

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 1

        ' Declaramos e inicialziamos las variables locales
        Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        If intSelectedPage <= 0 Then
            'intSelectedPage = 1
            intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
        End If
        Dim dataArray As Array = Nothing

        ' Obtenemos los listados que ya se han capturado previamente.
        dataArray = clstblSucursalSinCierre.strBuscar(selDate, Me.selectedDireccion, 1, intElementsPerPage, strConnectionString)

        Dim headers As ArrayList = New ArrayList()
        headers.Add("Compañía")
        headers.Add("# Sucursal")
        headers.Add("Sucursal")
        headers.Add("Inventarios Pendientes")


        Dim columnOrder As Integer() = {0, 1, 2, 3}
        Dim actions As ArrayList = New ArrayList()

        Dim maxPerPage As Integer = 10
        htmlResult = clsHTMLUtils.displayScroll(dataArray.Length, intSelectedPage, maxPerPage, "", Nothing)
        htmlResult += clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, intSelectedPage, maxPerPage, -1)

        Return htmlResult
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Me.btnExportar.Disabled = True
        Me.btnImprimir.Disabled = True

        ' Almacenamos el comando ejecutado
        strCmd = com.isocraft.commons.clsWeb.strGetPageParameter("strCmd", com.isocraft.commons.clsWeb.strGetPageParameter("cmdConsultar", ""), Request)

        'Calcular fecha actual:
        Me.currentDate.Text = Today.ToString(clsDateUtil.DATE_FORMAT)

        ' Ejecutamos el comando indicado
        Select Case strCmd
            Case "skipPage"
                Me.setVariables()

        End Select

        If Request("currentDate") = Nothing Then
            Me.fillChoice(0)
        End If

    End Sub

    Public Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.ServerClick
        'determinar que se selecciono, si por fecha de hoy o alguna otra fecha
        Me.setVariables()
    End Sub

    Public Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.ServerClick

        Me.setVariables()

        Me.toExport = False
        Session.Add("printDocument", Me)
        Dim script As String = "<script for=window event=onload>printDocument()</script>"
        Page.RegisterClientScriptBlock("openWindowScript", script)

    End Sub


    Public Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.ServerClick
        Me.setVariables()

        Me.toExport = True
        Session.Add("printDocument", Me)
        Dim script As String = "<script for=window event=onload>exportDocument()</script>"
        Page.RegisterClientScriptBlock("openWindowScript", script)
    End Sub


    Private Sub setSelectedDate()
        If Me.dateSelection1.Checked Then
            selDate = Today
        Else
            selDate = clsDateUtil.StringToDate(Me.selectedDate.Text, clsDateUtil.DATE_FORMAT)
        End If

        If clsDateUtil.IsNull(selDate) Then
            Me.btnExportar.Disabled = True
            Me.btnImprimir.Disabled = True
        Else
            Me.btnExportar.Disabled = False
            Me.btnImprimir.Disabled = False
        End If
    End Sub

    Public Sub cambioDireccion(ByVal selDireccion As Integer)
        'actualizar la lista
        'preseleccionar
        Me.setVariables()

    End Sub

    Private Sub fillChoice(ByVal selectedDireccionId As Integer)

        If Me.intDireccionId.Items.Count > 0 Then

            Return
        End If

        Dim dataArray As Array = clstblSucursalSinCierre.strBuscarDirecciones(1, -1, Me.strConnectionString)

        Dim item As ListItem = New ListItem("-Seleccione una opción-", "0")
        Me.intDireccionId.Items.Add(item)

        Dim row As Array
        Dim i As Integer = 1
        Dim selectedIndex As Integer
        For Each row In dataArray
            Dim id As Integer = CInt(row.GetValue(0)) 'id
            Dim name As String = row.GetValue(1).ToString 'nombre

            item = New ListItem(name, id.ToString)
            Me.intDireccionId.Items.Add(item)
            If (id = selectedDireccionId) Then
                Me.selectedDireccionNombre = name
                selectedIndex = i
            End If

            i += 1
        Next

        Me.intDireccionId.SelectedIndex = selectedIndex

    End Sub

    Private Sub setVariables()
        Me.setSelectedDate()
        selectedDireccion = CInt(Me.selectedDirectionId.Value())
        Me.fillChoice(selectedDireccion)
    End Sub

#Region "metodos de la interface PrintInterface"

    Function addPagination() As Boolean Implements PrintInterface.addPagination
        If Me.toExport Then
            Return False
        Else
            Return True
        End If
    End Function

    Function getHeaders() As String Implements PrintInterface.getHeaders
        Dim code As StringBuilder = New StringBuilder()
        Dim widths As String() = {"20%", "20%", "40%", "20%"}
        Dim values As String() = {"Compañía", "# Sucursal", "Sucursal", "Inventarios Pendientes"}

        code.Append(clsHTMLUtils.getTagTR("th", 3, "rayita", "txcont", widths, values))

        Return code.ToString
    End Function

    Function getTitle(ByVal currentPage As Integer, ByVal totalPages As Integer) As String Implements PrintInterface.getTitle
        Dim code As StringBuilder = New StringBuilder()
        Dim widths As String() = {"20%", "50%", "10%", "20%"}
        Dim styles As String() = {"txtitulo", "txcontenidobold", "txcontenidobold"}
        Dim values2 As String() = {"Fecha de Inventario:", selDate.ToString(clsDateUtil.DATE_FORMAT), "", "Fecha: " + Today.ToString(clsDateUtil.DATE_FORMAT)}
        Dim values3 As String() = {"Dirección:", Me.selectedDireccionNombre, "", ""}

        Dim title1 As String = " <tr><td class='txtitulo' colspan='3' width='80%'>Reporte de Sucursales Sin Cierre de Inventario</td>"

        If Me.toExport Then
            title1 += "<td></td>"
        Else
            title1 += "<td class='txcontenidobold' width='20%'>HOJA: " + currentPage.ToString + " / " + totalPages.ToString + "</td></tr>"
        End If




        code.Append(clsHTMLUtils.BEGIN_TABLE)
        code.Append(title1)
        code.Append(clsHTMLUtils.getTagTR("td", 4, "txcontenidobold", widths, values2))
        code.Append(clsHTMLUtils.getTagTR("td", 4, "txcontenidobold", widths, values3))
        code.Append(clsHTMLUtils.END_TABLE)

        Return code.ToString
    End Function

    Function getRow(ByVal aRow As Array, ByVal globalRowCounter As Integer) As String Implements PrintInterface.getRow
        Dim colsToShow As Integer() = {0, 1, 2, 3}
        Return clsPrintUtil.getSimpleRow(aRow, colsToShow)
    End Function

    Function getFooter() As String Implements PrintInterface.getFooter
        Return ""
    End Function

    Function getData() As Array Implements PrintInterface.getData
        Dim dataArray As Array = Nothing

        ' Obtenemos los listados que ya se han capturado previamente.
        dataArray = clstblSucursalSinCierre.strBuscar(selDate, Me.selectedDireccion, 1, 32, strConnectionString)

        Return dataArray
    End Function

    Function getColumnNumber() As Integer Implements PrintInterface.getColumnNumber
        Return 4
    End Function

#End Region

End Class

