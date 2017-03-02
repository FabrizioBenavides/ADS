Imports Isocraft.Web.Http

'====================================================================
' Class         : clsSistemaBinesConsultar
' Title         : SistemaBinesConsultar
' Description   : En esta parte usted puede consultar los BINes que han sido dados de alta en el sistema. 
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Rogelio Torres (rogelio@isocraft.com)
' Last Modified : Monday, October 17, 2005
'====================================================================

Public Class clsSistemaBinesConsultar
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then

            Call Response.Redirect("../Default.aspx")

        End If

        ' Initialize class properties
        strtxtIDBin = GetPageParameter("txtIDBin", "")

    End Sub

#End Region

#Region " Class Private Attributes"

    Private intmEmisorId As Integer
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmtxtIDBin As String

#End Region

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
    ' Name       : strtxtIDBin
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtIDBin() As String
        Get
            Return strmtxtIDBin
        End Get
        Set(ByVal strValue As String)
            strmtxtIDBin = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intEmisorId
    ' Description: Identificador de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intEmisorId() As Integer
        Get

            If intmEmisorId = 0 Then

                intmEmisorId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboEmisor", isocraft.commons.clsWeb.strGetPageParameter("intEmisorId", "0")))

            End If

            Return intmEmisorId
        End Get
        Set(ByVal intValue As Integer)
            intmEmisorId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strLlenarEmisorComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboDireccion"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarEmisorComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboEmisor", intEmisorId, Benavides.CC.Data.clstblEmisorFormaPago.strBuscar(0, "", "", Today(), Today(), "", 0, 0, strConnectionString), 0, 2, 1)
    End Function

    '====================================================================
    ' Name       : strObtenerBINes
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strObtenerBINes() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 10
        Const strRecordBrowserName As String = "SistemaBinesConsultar"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim aobjDataArray As Array = Benavides.CC.Data.clsBINTarjeta.aobjObtenerBINes(strtxtIDBin, intEmisorId, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

        ' Generamos el URL destino de las páginas
        Dim strTargetURL As String = strThisPageName & "?intEmisorId=" & intEmisorId & "&txtIDBin=" & strtxtIDBin & "&"

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, aobjDataArray, intSelectedPage, intElementsPerPage, strTargetURL)

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Load

        ' Declaramos las variables locales
        Dim aobjData As Array = Nothing
        Dim intBinId As Integer = 0

        ' Execute the selected command
        Select Case strCmd

            Case "Editar"

                Call Response.Redirect("SistemaBinesEditar.aspx?intBinTarjetaId=" & isocraft.commons.clsWeb.strGetPageParameter("intBinTarjetaId", "0"))

            Case "Eliminar"

                Call Response.Redirect("SistemaBinesEditar.aspx?intBinTarjetaId=" & isocraft.commons.clsWeb.strGetPageParameter("intBinTarjetaId", "0") & "&strCmd=Eliminar")

            Case Else

        End Select

    End Sub

End Class
