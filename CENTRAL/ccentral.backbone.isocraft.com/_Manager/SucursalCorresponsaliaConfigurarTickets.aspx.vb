Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert

'====================================================================
' Class         : SucursalCorresponsaliaConfigurarTickets
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Configurar la informacion de los tickets
' Copyright     : 2009 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Cesar Ortiz
' Version       : 1.0
' Last Modified : Saturday, October 3, 2009
'====================================================================

Public Class SucursalCorresponsaliaConfigurarTickets
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
    End Sub

#End Region

    Private strmJavascriptWindowOnLoadCommands As String
    Private strmServiciosCorresponsaliaDescripcionId As String
    Private strmInformacionTicket As String
    Private intmTipoServicioId As Integer

    '====================================================================
    ' Name       : intTipoServicioId
    ' Description: Identificador del tipo de servicio
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intTipoServicioId() As Integer
        Get
            Return CInt(Request.Form("cboTipoServicio"))
        End Get

    End Property

    '====================================================================
    ' Name       : strServiciosCorresponsaliaDescripcionId
    ' Description: Identificador de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strServiciosCorresponsaliaDescripcionId() As String
        Get
            strmServiciosCorresponsaliaDescripcionId = Request.Form("strServicioDescripcion")
            Return strmServiciosCorresponsaliaDescripcionId
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
            If Request.QueryString("strCmd") <> "" Then
                Return Request.QueryString("strCmd")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strInformacionTicket
    ' Description: Identificador de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strInformacionTicket() As String
        Get
            strmInformacionTicket = Request.Form("txtTicket")
            Return strmInformacionTicket
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
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
        End Get
    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: URL de esta página
    ' Accessor   : Read
    ' Throws     : None
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
    ' Throws     : None
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
    ' Throws     : None
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
    ' Name       : strLlenarTipoServicioComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboTipoServicio"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarTipoServicioComboBox() As String

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboTipoServicio", intTipoServicioId, Benavides.CC.Business.clsConcentrador.clsSucursal.clsCorresponsalia.strObtenerTipoServicio(strConnectionString), 0, 1, 1)

    End Function

    '====================================================================
    ' Name       : strLlenarInformacionTicket
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboTipoServicio"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarInformacionTicket() As String
        Dim strAuxiliar As String
        strAuxiliar = "document.forms[0].elements[""" & "txtTicket" & """ ].value = """
        strAuxiliar = strAuxiliar & Benavides.CC.Business.clsConcentrador.clsSucursal.clsCorresponsalia.strObtenerInformacionTicket(intTipoServicioId, strServiciosCorresponsaliaDescripcionId, strConnectionString)
        strAuxiliar = strAuxiliar & """"
        strAuxiliar = Replace(strAuxiliar, vbCrLf, "\n")
        Return strAuxiliar
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        Dim strCmd As String = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")
        Dim intResultado As Integer

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Salvar"

                intResultado = Benavides.CC.Business.clsConcentrador.clsSucursal.clsCorresponsalia.intGuardarInformacionTicket(intTipoServicioId, strServiciosCorresponsaliaDescripcionId, strInformacionTicket, strUsuarioNombre, strConnectionString)

                If intResultado = 0 Then
                    strJavascriptWindowOnLoadCommands &= "  alert(""ERROR: La información no pudo ser agregada a la base de datos.\n\r\n\rPor favor informe este error a su administrador o personal a cargo."");" & vbCrLf
                End If

                'Cargamos nuevamente la pagina
                Call Response.Redirect("SucursalCorresponsaliaConfigurarTickets.aspx")
        End Select
    End Sub

End Class
