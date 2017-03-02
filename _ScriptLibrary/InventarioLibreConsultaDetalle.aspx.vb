'====================================================================
' Class         : clsInventarioLibreConsultaDetalle
' Title         : Grupo Benavides. Inventarios Rotativos.
' Description   : Consulta de detalle de Inventarios Libres
' Copyright     : 2003-2006 All rights reserved.
' Company       : Neitek Solutions S.A. de C.V.
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

Public Class clsInventarioLibreConsultaDetalle
    Inherits System.Web.UI.Page
    Implements PrintInterface


    'Variables globales
    Dim strmMensaje As String = ""
    Dim strmRecordBrowserHTML As String = ""
    Dim strmbtnAceptar As String = ""
    Private selDate As Date
    Private strmCommand As String
    Private imprimirSoloDiferencias As Boolean = False

    Protected WithEvents sucursalNombre As System.Web.UI.WebControls.TextBox
    Protected WithEvents fechaActual As System.Web.UI.WebControls.TextBox
    Protected WithEvents intFolioId As System.Web.UI.WebControls.TextBox
    Protected WithEvents intTimestamp As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents pickupArticulos As System.Web.UI.WebControls.ImageButton
    Protected WithEvents dtmFechaInicial As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents dtmFechaFinal As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnImprimir As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnImprimirDiferencias As System.Web.UI.HtmlControls.HtmlInputButton


    Public Sub setImprimirSoloDiferencias(ByVal aValue As Boolean)
        Me.imprimirSoloDiferencias = aValue
    End Sub


    Public Sub setFolioValue(ByVal aValue As String)
        Me.intFolioId = New System.Web.UI.WebControls.TextBox
        Me.intFolioId.Text = aValue
    End Sub

    Public Sub setTimeStampValue(ByVal aValue As String)
        Me.intTimestamp = New System.Web.UI.HtmlControls.HtmlInputHidden
        Me.intTimestamp.Value = aValue
    End Sub


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
    ' Name       : strCentroLogisticoId
    ' Description: Valor de la Sucursal
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCentroLogisticoId() As String
        Get
            Return clsCommons.strReadCookie("strCentroLogisticoId", "", Context.Request, Server)
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
        Dim htmlResult As String = ""



        ' Declaramos e inicialziamos las variables locales
        Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        If intSelectedPage <= 0 Then
            'intSelectedPage = 1
            intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
        End If
        Dim dataArray As Array = Nothing

        ' Obtenemos los listados que ya se han capturado previamente.
        dataArray = clstblInventarioLibre.strBuscarRegistros(CLng(Me.intTimestamp.Value), False, strConnectionString)

        Dim headers As ArrayList = New ArrayList
        headers.Add("Código")
        headers.Add("Descripción")
        headers.Add("Existencia")


        Dim columnOrder As Integer() = {1, 2, 3}

        Dim actions As ArrayList = New ArrayList

        'despliega todos los registros
        Dim maxPerPage As Integer = dataArray.Length
        'htmlResult = clsHTMLUtils.displayScroll(dataArray.Length, intSelectedPage, maxPerPage, "SucursalHabilitarInventarioRotativo.aspx", Nothing)
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
        Me.intFolioId.Text = Request("intFolioId")
        Dim fechaToma As DateTime = clsDateUtil.StringToDate(Request("dtmFechaTomaInventario"), "yyyy-MM-dd")

        Me.fechaActual.Text = Today.ToString(clsDateUtil.DATE_FORMAT)
        Me.intTimestamp.Value = Request("intTimestamp")
        Me.dtmFechaInicial.Value = Request("dtmFechaInicial")
        Me.dtmFechaFinal.Value = Request("dtmFechaFinal")

    End Sub

#End Region


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, Me.strConnectionString) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        'Calcular fecha actual:
        Me.sucursalNombre.Text = Me.strCentroLogisticoId & " - " & Trim(Me.strSucursalNombre) & " (" & Me.intCompaniaId.ToString & Me.intSucursalId.ToString("000") & ")"

    End Sub

    Public Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.ServerClick
        Me.imprimirSoloDiferencias = False
        Session.Add("printDocument", Me)
        Dim script As String = "<script for=window event=onload>printDocument()</script>"
        Page.RegisterClientScriptBlock("openWindowScript", script)
    End Sub


    Public Sub btnImprimirDiferencias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirDiferencias.ServerClick
        Me.imprimirSoloDiferencias = True
        Session.Add("printDocument", Me)
        Dim script As String = "<script for=window event=onload>printDocument()</script>"
        Page.RegisterClientScriptBlock("openWindowScript", script)
    End Sub

#Region "metodos privados"

    Private Function sucursalNombreCompleto() As String
        Return Me.strCentroLogisticoId & " - " & Trim(Me.strSucursalNombre) & " (" & Me.intCompaniaId.ToString & Me.intSucursalId.ToString("000") & ")"
    End Function

#End Region

#Region "metodos de la interface PrintInterface"

    Function addPagination() As Boolean Implements PrintInterface.addPagination
        Return True
    End Function

    Function getHeaders() As String Implements PrintInterface.getHeaders
        Dim code As StringBuilder = New StringBuilder

        If imprimirSoloDiferencias Then
            Dim widths As String() = {"15%", "40%", "15%", "15%", "15%"}
            Dim values As String() = {"Código", "Descripción", "Existencia", "Inv. Teórico", "Diferencia"}
            code.Append(clsHTMLUtils.getTagTR("th", 5, "rayita", "txcont", widths, values))

        Else
            Dim widths As String() = {"25%", "50%", "25%"}
            Dim values As String() = {"Código", "Descripción", "Existencia"}
            code.Append(clsHTMLUtils.getTagTR("th", 3, "rayita", "txcont", widths, values))
        End If


        Return code.ToString
    End Function

    Function getTitle(ByVal currentPage As Integer, ByVal totalPages As Integer) As String Implements PrintInterface.getTitle
        Dim code As StringBuilder = New StringBuilder
        Dim widths As String() = {"20%", "50%", "10%", "20%"}
        Dim styles As String() = {"txtitulo", "txcontenidobold", "txcontenidobold"}
        Dim values2 As String() = {"Sucursal:", Me.sucursalNombreCompleto(), "", "Fecha: " + Today.ToString(clsDateUtil.DATE_FORMAT)}
        Dim values3 As String() = {"Folio:", Me.intFolioId.Text, "", ""}

        Dim title1 As String = " <tr><td class='txtitulo' colspan='3' width='80%'>Detalle de Inventario Libre</td>"
        If Me.imprimirSoloDiferencias Then
            title1 = " <tr><td class='txtitulo' colspan='3' width='80%'>Reporte de Diferencias entre Existencia Real y Teórica ( Merma )</td>"
        End If

        title1 += "<td class='txcontenidobold' width='20%'>HOJA: " + currentPage.ToString + " / " + totalPages.ToString + "</td></tr>"

        code.Append(clsHTMLUtils.BEGIN_TABLE)
        code.Append(title1)
        code.Append(clsHTMLUtils.getTagTR("td", 4, "txcontenidobold", widths, values2))
        code.Append(clsHTMLUtils.getTagTR("td", 4, "txcontenidobold", widths, values3))

        code.Append(clsHTMLUtils.END_TABLE)

        Return code.ToString
    End Function

    Function getRow(ByVal aRow As Array, ByVal globalRowCounter As Integer) As String Implements PrintInterface.getRow
        Dim code As StringBuilder = New StringBuilder

        'Dim colsToShow As Integer() = {1, 2, 3}
        Dim existencia As Integer = CInt(aRow.GetValue(3))
        Dim invTeorico As Object = aRow.GetValue(4)
        Dim diferencia As String = "0"

        code.Append("<tr>")

        code.Append(clsPrintUtil.getCell(aRow.GetValue(1).ToString))        'codigo
        code.Append(clsPrintUtil.getCell(aRow.GetValue(2).ToString))        'descripcion
        code.Append(clsPrintUtil.getCell(existencia.ToString))              'existencia

        If Me.imprimirSoloDiferencias Then
            Try
                Dim invTeoricoAsInteger As Integer = CInt(invTeorico)
                diferencia = (existencia - invTeoricoAsInteger).ToString()
            Catch ex As Exception
                diferencia = existencia.ToString
            End Try

            code.Append(clsPrintUtil.getCell(invTeorico.ToString))              'inv. teorico
            code.Append(clsPrintUtil.getCell(diferencia))                       'diferencia
        End If

        code.Append("</tr>")

        Return code.ToString

    End Function

    Function getFooter() As String Implements PrintInterface.getFooter
        Return ""
    End Function

    Function getData() As Array Implements PrintInterface.getData
        Dim dataArray As Array = Nothing

        ' Obtenemos los listados que ya se han capturado previamente.
        dataArray = clstblInventarioLibre.strBuscarRegistros(CLng(Me.intTimestamp.Value), Me.imprimirSoloDiferencias, strConnectionString)

        Return dataArray
    End Function

    Function getColumnNumber() As Integer Implements PrintInterface.getColumnNumber
        Return 3
    End Function

#End Region


End Class
