'====================================================================
' Class         : clsSucursalConsultarCajas
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : AConsultar cajas en sucursales
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Javier Ramos
' Version       : 1.0
' Last Modified : Thursday, June 17, 2004
'====================================================================
Public Class clsSucursalConsultarCajas
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

    ' Variables locales privadas
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private intmDireccionId As Integer
    Private intmZonaId As Integer

    '====================================================================
    ' Name       : intDireccionId
    ' Description: Identificador de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDireccionId() As Integer
        Get
            If intmDireccionId = 0 Then
                intmDireccionId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboDireccion", isocraft.commons.clsWeb.strGetPageParameter("intDireccionId", "0")))
            End If
            Return intmDireccionId
        End Get
    End Property

    '====================================================================
    ' Name       : intZonaId
    ' Description: Identificador de la Zona
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intZonaId() As Integer
        Get
            If intmZonaId = 0 Then
                intmZonaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboZona", isocraft.commons.clsWeb.strGetPageParameter("intZonaId", "0")))
            End If
            Return intmZonaId
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
    ' Name       : strLlenarDireccionComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboDireccion"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarDireccionComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccion", intDireccionId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString), 0, 1, 1)
    End Function

    '====================================================================
    ' Name       : strLlenarZonaComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboZona"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarZonaComboBox() As String
        If intDireccionId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZona", intZonaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, 0, strConnectionString), 0, 1, 1)
        End If
    End Function

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 10
        Const strRecordBrowserName As String = "SucursalConsultarCajas"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1"))

        ' Si los identificadores de la moneda, direccion y zona son válidos
        If intDireccionId > 0 AndAlso intZonaId > 0 Then

            ' Buscamos las sucursales de esta dirección y zona
            Dim astrDataArray As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, intZonaId, strConnectionString)

            ' Generamos el navegador de registros
            Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId & "&")
            'Return strReturn.Replace("Sucursales en la zona elegida", "Sucursales en la zona elegida<p>&nbsp;<br>Para asignar cuentas a nivel individual, elija una sucursal de la zona y haga clic en su liga &quot;Asignar&quot;. Para asignar en grupo, oprima el bot&oacute;n &quot;Importar lote&quot;, que le permitir&aacute; elegir varias sucursales de la zona para asignarles cuentas.</p><input name=""cmdImportar"" type=""button"" class=""button"" id=""cmdImportar"" value=""Importar lote"" onclick=""return cmdImportar_onclick()""><br>")

        End If

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        Dim strCmd As String = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Ver"

                Call Response.Redirect("SucursalVerDetalleCaja.aspx?intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId & "&intCompaniaId=" & isocraft.commons.clsWeb.strGetPageParameter("intCompaniaId", "0") & "&intSucursalId=" & isocraft.commons.clsWeb.strGetPageParameter("intSucursalId", "0"))

        End Select

    End Sub

End Class