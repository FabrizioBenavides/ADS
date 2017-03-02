'====================================================================
' Class         : clsSucursalVerPoliticasDePosDeUnaSucursal
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Ver políticas de POS a una sucursal
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Joaquín Hernández García
' Version       : 1.0
' Last Modified : Tuesday, June 29, 2004
'====================================================================
Public Class clsSucursalVerPoliticasDePosDeUnaSucursal
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
    Private intmCompaniaId As Integer
    Private intmSucursalId As Integer
    Private intmCajaId As Integer
    Private intmTipoDatoPoliticaPosId As Integer
    Private strmPoliticas As String

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
                intmDireccionId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intDireccionId", "0"))
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
                intmZonaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intZonaId", "0"))
            End If
            Return intmZonaId
        End Get
    End Property

    '====================================================================
    ' Name       : intCompaniaId
    ' Description: Identificador de la Compania
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intCompaniaId() As Integer
        Get
            If intmCompaniaId = 0 Then
                intmCompaniaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intCompaniaId", "0"))
            End If
            Return intmCompaniaId
        End Get
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Identificador de la Sucursal
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intSucursalId() As Integer
        Get
            If intmSucursalId = 0 Then
                intmSucursalId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intSucursalId", "0"))
            End If
            Return intmSucursalId
        End Get
    End Property

    '====================================================================
    ' Name       : strDireccionOperativaNombre
    ' Description: Nombre de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strDireccionOperativaNombre() As String
        Get
            If intDireccionId > 0 Then
                Dim astrData As Array = Benavides.CC.Data.clstblDireccionOperativa.strBuscar(intDireccionId, "", "", Now, "", 0, 0, strConnectionString)
                If IsArray(astrData) = True AndAlso astrData.Length > 0 Then
                    Return CStr(DirectCast(astrData.GetValue(0), Array).GetValue(1))
                End If
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strZonaOperativaNombre
    ' Description: Nombre de la Zona
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strZonaOperativaNombre() As String
        Get
            If intDireccionId > 0 AndAlso intZonaId > 0 Then
                Dim astrData As Array = Benavides.CC.Data.clstblZonaOperativa.strBuscar(intDireccionId, intZonaId, "", "", Now, "", 0, 0, strConnectionString)
                If IsArray(astrData) = True AndAlso astrData.Length > 0 Then
                    Return CStr(DirectCast(astrData.GetValue(0), Array).GetValue(2))
                End If
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strSucursalNombre
    ' Description: Nombre de la Sucursal
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strSucursalNombre() As String
        Get
            If intCompaniaId > 0 AndAlso intSucursalId > 0 Then
                Dim astrData As Array = Benavides.CC.Data.clstblSucursal.strBuscar(intCompaniaId, intSucursalId, 0, 0, "", 0, 0, 0, Now, "", "", "", "", 0, 0, strConnectionString)
                If IsArray(astrData) = True AndAlso astrData.Length > 0 Then
                    Return CStr(DirectCast(astrData.GetValue(0), Array).GetValue(4))
                End If
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intCajaId
    ' Description: Identificador de la Caja
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intCajaId() As Integer
        Get
            If intmCajaId = 0 Then
                intmCajaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboCaja", isocraft.commons.clsWeb.strGetPageParameter("intCajaId", "0")))
            End If
            Return intmCajaId
        End Get
    End Property

    '====================================================================
    ' Name       : intTipoDatoPoliticaPosId
    ' Description: Identificador de la política
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intTipoDatoPoliticaPosId() As Integer
        Get
            If intmTipoDatoPoliticaPosId = 0 Then
                intmTipoDatoPoliticaPosId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboPoliticas", "0"))
            End If
            Return intmTipoDatoPoliticaPosId
        End Get
    End Property

    '====================================================================
    ' Name       : strLlenarPoliticasComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboPoliticas"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarPoliticasComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboPoliticas", intTipoDatoPoliticaPosId, Benavides.CC.Data.clstblTipoDatoPoliticaPos.strBuscar(0, "", "", 0, 0, Now, "", 0, 0, strConnectionString), 0, 1, 1)
    End Function

    '====================================================================
    ' Name       : strLlenarCajaComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboCaja"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarCajaComboBox() As String
        If intCompaniaId > 0 AndAlso intSucursalId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboCaja", intCajaId, Benavides.CC.Data.clstblCaja.strBuscar(intCompaniaId, intSucursalId, 0, 0, 0, "", "", "", "", Now, Now, "", 0, 0, strConnectionString), 2, 6, 1)
        End If
    End Function

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
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 10
        Const strRecordBrowserName As String = "SucursalVerPoliticasDePOSDeUnaSucursal"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1"))

        ' Buscamos las sucursales de esta dirección y zona
        Dim astrDataArray As Array = Benavides.CC.Data.clsPoliticaPOSSucursal.strBuscar(intCompaniaId, intSucursalId, intCajaId, 0, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId & "&intCompaniaId=" & intCompaniaId & "&intSucursalId=" & intSucursalId & "&")

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Enviamos al usuario actual a la página origen, si los identificadores de la dirección, zona, compañía y sucursal son inválidos
        If intDireccionId < 1 OrElse intZonaId < 1 OrElse intCompaniaId < 1 OrElse intSucursalId < 1 Then
            Call Response.Redirect("SucursalAdministrarPoliticasDePOS.aspx")
        End If

        ' Almacenamos el comando ejecutado
        Dim strCmd As String = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Editar", "Agregar", "Borrar"

                Call Response.Redirect("SucursalEditarPoliticaDePOSDeUnaSucursal.aspx?strCmd=" & strCmd & "&intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId & "&intCompaniaId=" & intCompaniaId & "&intSucursalId=" & intSucursalId & "&intTipoDatoPoliticaPOSId=" & isocraft.commons.clsWeb.strGetPageParameter("intTipoDatoPoliticaPOSId", "0") & "&intCajaId=" & isocraft.commons.clsWeb.strGetPageParameter("intCajaId", "0"))

        End Select

    End Sub

End Class
