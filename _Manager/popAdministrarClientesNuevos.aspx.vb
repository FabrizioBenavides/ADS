Imports Isocraft.Web.Http

Public Class popAdministrarClientesNuevos
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
        intGrupoClienteEspecialId = GetPageParameter("cboGrupoClienteEspecial", GetPageParameter("intGrupoClienteEspecialId", 0))

    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private intmtxtGrupoClienteEspecialId As Integer

#End Region
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
    ' Name       : strCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return GetPageParameter("strCmd", "")
        End Get
    End Property

    '====================================================================
    ' Name       : intGrupoClienteEspecialId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intGrupoClienteEspecialId() As Integer
        Get
            Return intmtxtGrupoClienteEspecialId
        End Get
        Set(ByVal intValue As Integer)
            intmtxtGrupoClienteEspecialId = intValue
        End Set
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
    ' Name       : strLlenarGrupoClienteEspecialComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboGrupoClienteEspecial"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarGrupoClienteEspecialComboBox() As String

        Dim aobjData As Array = Benavides.CC.Data.clstblGrupoClienteEspecial.strBuscar(0, "", "", Now(), "", 0, 0, strConnectionString)

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboGrupoClienteEspecial", intGrupoClienteEspecialId, aobjData, 0, 1, 1)

    End Function

    Public ReadOnly Property intClienteEspecialId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intClienteEspecialId")) Then
                Return CInt(Request.QueryString("intClienteEspecialId"))
            Else
                Return 0
            End If
        End Get
    End Property

    Public ReadOnly Property strClienteEspecialNombreId() As String
        Get
            If Not IsNothing(Request("strClienteEspecialNombreId")) Then
                Return CStr(Request("strClienteEspecialNombreId"))
            Else
                Return ""
            End If
        End Get
    End Property

    Public ReadOnly Property strClienteEspecialNombre() As String
        Get
            If Not IsNothing(Request.QueryString("strClienteEspecialNombre")) Then
                Return CStr(Request.QueryString("strClienteEspecialNombre"))
            Else
                Return ""
            End If
        End Get
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
 
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Select Case strCmd

            Case "Asignar"
                Dim intAsignarGrupo As Integer = Benavides.CC.Data.clsClienteEspecial.intActualizarGrupo(strClienteEspecialNombreId, intGrupoClienteEspecialId, strUsuarioNombre, strConnectionString)

                ' Cerramos la ventana
                strJavascriptWindowOnLoadCommands &= "  window.opener.location.href = ""SistemaAdministrarClientesNuevos.aspx" & """;" & vbCrLf
                strJavascriptWindowOnLoadCommands &= "  window.close();" & vbCrLf

        End Select
    End Sub

End Class
