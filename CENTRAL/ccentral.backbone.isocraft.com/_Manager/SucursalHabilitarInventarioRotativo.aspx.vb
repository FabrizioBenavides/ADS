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

Imports prjCCInventarioBusiness.Benavides.InvRot.Data
Imports prjCCInventarioBusiness.Benavides.InvRot.Utils

Public Class clsSucursalHabilitarInventarioRotativo
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dateSelection1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents selectedDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents dateSelection2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    Protected WithEvents btnAceptar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents intCompania As System.Web.UI.WebControls.TextBox
    Protected WithEvents intSucursal As System.Web.UI.WebControls.TextBox
    Protected WithEvents currentDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.HtmlControls.HtmlInputButton

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

        If Me.selDate = Nothing Then
            Return ""
        End If


        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 1
        Dim strRecordBrowserName As String = "SucursalHabilitarInventarioRotativo"

        ' Declaramos e inicialziamos las variables locales
        Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        If intSelectedPage <= 0 Then
            'intSelectedPage = 1
            intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
        End If
        Dim dataArray As Array = Nothing

        ' Obtenemos los listados que ya se han capturado previamente.
        dataArray = clstblDeshabilitarSucursal.strBuscar(selDate, 1, intElementsPerPage, strConnectionString)

        Dim headers As ArrayList = New ArrayList()
        headers.Add("Compañía")
        headers.Add("# Sucursal")
        headers.Add("Sucursal")
        headers.Add("Acciones")

        Dim columnOrder As Integer() = {0, 1, 2}

        Dim actions As ArrayList = New ArrayList()
        Dim pkNames As String() = {"intCompaniaId", "intSucursalId", "dtmDeshabilitarSucursalFecha"}
        Dim pkIndexes As Integer() = {0, 1, 3}
        actions.Add(New clsActionLink("Borrar", pkNames, pkIndexes, "imgNRborrar.gif", "Haga clic aquí para habilitar la sucursal para la Captura de Inventarios Rotativos"))


        Dim maxPerPage As Integer = 10
        htmlResult = clsHTMLUtils.displayScroll(dataArray.Length, intSelectedPage, maxPerPage, "SucursalHabilitarInventarioRotativo.aspx", Nothing)
        htmlResult += clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, intSelectedPage, maxPerPage, -1)


        Return htmlResult
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        strCmd = com.isocraft.commons.clsWeb.strGetPageParameter("strCmd", com.isocraft.commons.clsWeb.strGetPageParameter("cmdConsultar", ""), Request)

        'Calcular fecha actual:
        Me.currentDate.Text = Today.ToString(clsDateUtil.DATE_FORMAT)

        ' Ejecutamos el comando indicado
        Select Case strCmd
            Case "Borrar"
                Me.deleteRecord()
            Case "skipPage"
                Me.setSelectedDate()

        End Select

    End Sub


    Private Sub deleteRecord()
        Dim compania As Integer = CInt(Request("intCompaniaId"))
        Dim sucursal As Integer = CInt(Request("intSucursalId"))
        Dim fecha As Date = clsDateUtil.StringToDate(Request("dtmDeshabilitarSucursalFecha"), clsDateUtil.DATE_FORMAT)

        Dim numRec As Integer = clstblDeshabilitarSucursal.intEliminar(compania, sucursal, fecha, strConnectionString)

        Me.setSelectedDate()

    End Sub

    Public Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.ServerClick
        'determinar que se selecciono, si por fecha de hoy o alguna otra fecha

        Me.setSelectedDate()
        Me.intCompania.Text = ""
        Me.intSucursal.Text = ""
    End Sub

    Public Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.ServerClick
        Dim fecha As Date = Today
        Dim sucursal As Integer
        Dim compania As Integer

        Try
            compania = CInt(intCompania.Text)
        Catch ex As Exception
            clsHTMLUtils.displayMessage(Me, "El valor de la Compañía, debe ser un número válido.")
            Return
        End Try

        Try
            sucursal = CInt(intSucursal.Text)
        Catch ex As Exception
            clsHTMLUtils.displayMessage(Me, "El valor de Sucursal, debe ser un número válido.")
            Return
        End Try


        Me.setSelectedDate()

        'validar que exista la compania y sucursal
        Dim blnExisteSucursal As Boolean = clstblDeshabilitarSucursal.blnExisteSucursal(compania, sucursal, Me.strConnectionString)

        If blnExisteSucursal = False Then
            ' no existe la compania ni sucursal.... 

            clsHTMLUtils.displayMessage(Me, "La Compañía o la Sucursal no existe, favor de verificar la información.")

            Exit Sub
        End If

        'validar que no se haya grabado previamente ese mismo registro para ese dia.
        Dim blnExisteRegistro As Boolean = clstblDeshabilitarSucursal.blnExisteRegistro(compania, sucursal, fecha, Me.strConnectionString)

        If blnExisteRegistro = True Then
            ' el registro ya existe en la tabla de deshabilitar sucursal...

            clsHTMLUtils.displayMessage(Me, "Este registro ya fue grabado previamente, favor de verificar la información.")

            Exit Sub
        End If

        'grabar el nuevo registro
        Dim numRec As Integer = clstblDeshabilitarSucursal.intAgregar(compania, sucursal, fecha, Now, Me.strUsuarioNombre, strConnectionString)

        'especificar valores del listado
        Me.dateSelection1.Checked = True
        Me.dateSelection2.Checked = False
        Me.selectedDate.Text = ""
        Me.selDate = Today
        Me.intCompania.Text = ""
        Me.intSucursal.Text = ""
    End Sub

    Private Sub setSelectedDate()
        If Me.dateSelection1.Checked Then
            selDate = Today
        Else
            If Not Me.selectedDate.Text = "" Then
                selDate = clsDateUtil.StringToDate(Me.selectedDate.Text, clsDateUtil.DATE_FORMAT)
            End If

        End If
    End Sub


End Class

