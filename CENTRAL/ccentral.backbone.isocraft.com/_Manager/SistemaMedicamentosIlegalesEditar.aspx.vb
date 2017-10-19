Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert

'====================================================================
' Class         : clsSistemaMedicamentosIlegalesEditar
' Title         : Isocraft. Grupo Benavides.
' Description   : Data maintenance classes
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Deintec
' Author        : Deintec
' Last Modified : Tuesday, August 08, 2017
'====================================================================

Public Class clsSistemaMedicamentosIlegalesEditar
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

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Initialize class properties
        intArticuloId = GetPageParameter("intArticuloId", 0)
        strArticuloDescripcion = GetPageParameter("strDescripcion", "")
        strArticuloLote = GetPageParameter("strLote", "")


    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private intmArticuloId As Integer
    Private strmArticuloDescripcion As String
    Private strmArticuloLote As String
    Private blnmArticuloVigente As Boolean

#End Region

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
    ' Throws     : None
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
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
        End Get
    End Property

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
    ' Name       : strAgre
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strOrigen() As String
        Get
            Return GetPageParameter("strOrigen", "")
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
            Return GetPageParameter("strCmd", "")
        End Get
    End Property

    '====================================================================
    ' Name       : intArticuloId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intArticuloId() As Integer
        Get
            Return intmArticuloId
        End Get
        Set(ByVal intValue As Integer)
            intmArticuloId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strArticuloDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strArticuloDescripcion() As String
        Get
            Return strmArticuloDescripcion
        End Get
        Set(ByVal strValue As String)
            strmArticuloDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strArticuloLote
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strArticuloLote() As String
        Get
            Return strmArticuloLote
        End Get
        Set(ByVal strValue As String)
            strmArticuloLote = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnArticuloVigente
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property blnArticuloVigente() As Boolean
        Get
            Return blnmArticuloVigente
        End Get
        Set(ByVal strValue As Boolean)
            blnmArticuloVigente = strValue
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim intArticuloIlegalId As Integer = GetPageParameter("intArticuloId", 0)
        Dim blnArtVigente As String = GetPageParameter("blnArtHabilitado", "True")
        Dim intCounter As Integer
        Dim dtmInicio As DateTime = Now()
        ' Agregamos los nuevos registros, si los valores de las columnas son válidos
        If intArticuloIlegalId > 0 Then

            ' Buscamos el registro
            Dim aobjDataToSearch As Array = Benavides.CC.Data.clstblArticuloIlegal.strBuscar(intArticuloIlegalId, Now(), "", 0, 1, strConnectionString)

            ' Si el registro existe
            If IsArray(aobjDataToSearch) = True AndAlso aobjDataToSearch.Length > 0 Then
                ' Actualizamos el registro
                intCounter = intCounter + 1

                strArticuloDescripcion = CStr(DirectCast(aobjDataToSearch.GetValue(0), Array).GetValue(6))
                'lote
                strArticuloLote = CStr(DirectCast(aobjDataToSearch.GetValue(0), Array).GetValue(1))
                'vigente
                blnArticuloVigente = CBool(DirectCast(aobjDataToSearch.GetValue(0), Array).GetValue(2))

            Else
                ' No se encontró el registro
            End If

        End If

        Select Case strCmd
            Case "Salvar"

                Call Benavides.CC.Data.clstblArticuloIlegal.intActualizar(intArticuloIlegalId, strArticuloLote, CBool(blnArtVigente), Now(), strUsuarioNombre, strConnectionString)
                Call Response.Redirect("SistemaMedicamentosIlegalesAdministrar.aspx")
        End Select

    End Sub

End Class