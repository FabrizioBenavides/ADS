Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert

Public Class SucursalDineroExpressAgregarEditar
    Inherits System.Web.UI.Page

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
        'Inicializa Propiedades

        intTipoOperacionDEXId = GetPageParameter("txtTipoOperacionDEXId", GetPageParameter("intTipoOperacionDEXId", 0))

        strTipoOperacionDEXNombreId = GetPageParameter("txtTipoOperacionDEXNombreId", "")

        strTipoOperacionDEXNombre = GetPageParameter("txtTipoOperacionDEXNombre", "")

    End Sub

#End Region

#Region " Class Private Attributes"

    Private intmTipoOperacionDEXId As Integer
    Private strmTipoOperacionDEXNombreId As String
    Private strmTipoOperacionDEXNombre As String
    Private strmJavascriptWindowOnLoadCommands As String
    Private intTipoOperacionDEXIdAnterior As Integer

#End Region

    Public Sub New()

    End Sub


    '====================================================================
    ' Name       : strFormAction
    ' Description: HTML form's action property value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormAction() As String
        Get
            Return strThisPageName
        End Get
    End Property

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Connection string
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Private ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: Name of this page
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return Server.UrlEncode(GetPageName())
        End Get
    End Property
    '====================================================================
    ' Name       : intGrupoUsuarioId
    ' Description: Identificador del Grupo de Usuario
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intGrupoUsuarioId() As Integer
        Get
            Return CInt(Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))
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
    ' Name       : strHTMLFechaHora
    ' Description: Genera la fecha y hora de la página
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
        End Get
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return GetPageParameter("strCmd", "Editar")
        End Get
    End Property

    '====================================================================
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
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
    ' Name       : intTipoOperacionDEXId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intTipoOperacionDEXId() As Integer
        Get
            Return intmTipoOperacionDEXId
        End Get
        Set(ByVal intValue As Integer)
            intmTipoOperacionDEXId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoOperacionDEXNombreId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTipoOperacionDEXNombreId() As String
        Get
            Return strmTipoOperacionDEXNombreId
        End Get
        Set(ByVal strValue As String)
            strmTipoOperacionDEXNombreId = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : strTipoOperacionDEXNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTipoOperacionDEXNombre() As String
        Get
            Return strmTipoOperacionDEXNombre
        End Get
        Set(ByVal strValue As String)
            strmTipoOperacionDEXNombre = strValue
        End Set
    End Property
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Execute the selected command
        Select Case strCmd

            Case "Salvar"

                Dim blnRedirectToParentPage As Boolean

                'Guardamos la informacion
                Benavides.CC.Business.clsConcentrador.clsSucursal.clsTipoOperacionDEX.IntActualizarTblTipoOperacionDEX(intTipoOperacionDEXId, strTipoOperacionDEXNombreId, strTipoOperacionDEXNombre, strUsuarioNombre, 0, strConnectionString)

                ' Regresamos al usuario al listado de elementos
                If blnRedirectToParentPage = True Then
                    strJavascriptWindowOnLoadCommands &= " window.location.href = ""SucursalAsignacionDeArticuloDineroExpress.aspx"";"
                Else
                    Response.Redirect("SucursalAsignacionDeArticuloDineroExpress.aspx", True)
                End If

            Case "Editar"

                ' Si el identificador del elemento es válido
                If intTipoOperacionDEXId > 0 Then

                    ' Obtenemos el elemento
                    Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsTipoOperacionDEX.strBuscarTipoOperacionDEX(intTipoOperacionDEXId, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        'Dim aobjRow As System.Collections.SortedList = DirectCast(aobjData.GetValue(0), System.Collections.SortedList)
                        Dim aobjRow As System.Array = DirectCast(aobjData.GetValue(0), System.Array)

                        ' Recuperamos sus datos
                        intTipoOperacionDEXId = CInt(aobjRow.GetValue(0))
                        strTipoOperacionDEXNombreId = CStr(aobjRow.GetValue(1))
                        strTipoOperacionDEXNombre = CStr(aobjRow.GetValue(3))

                    End If

                End If

        End Select
    End Sub

End Class


