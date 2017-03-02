'====================================================================
' Class         : clsSistemaAdministrarTiendas
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Administrar tiendas
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Javier Ramos
' Version       : 1.0
' Last Modified : Monday, May 24, 2004
'====================================================================
Public Class clsSistemaAdministrarTiendas
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
    Private intmDireccionOperativaId As Integer
    Private intmZonaOperativaId As Integer
    Private strmCboDireccion As String = ""
    Private strmCboZona As String = ""
    Private intmTiendaId As Integer
    'Private blnmCanDisableAddButton As Boolean = False

    '====================================================================
    ' Name       : strBooleanoSucursalesDisponibles
    ' Description: Indica si hay sucursales diponibles para la
    '              dirección y zona especificada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strBooleanoSucursalesDisponibles() As String
        Get
            'If blnmCanDisableAddButton = True Then
            Dim blnReturn As Boolean = True
            If intDireccionOperativaId > 0 AndAlso intZonaOperativaId > 0 Then
                Dim astrData As Array = Benavides.CC.Data.clsTienda.clsSucursal.strBuscarSinTiendaAsignada("", intDireccionOperativaId, intZonaOperativaId, strConnectionString)
                If astrData.Length > 0 Then
                    blnReturn = False
                End If
            End If
            Return CStr(blnReturn).ToLower()

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
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
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
    ' Name       : intDireccionOperativaId 
    ' Description: Obtiene o establece la direccion operativa seleccionada
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intDireccionOperativaId() As Integer
        Get
            Return intmDireccionOperativaId
        End Get
        Set(ByVal strValue As Integer)
            intmDireccionOperativaId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intZonaOperativaId 
    ' Description: Obtiene o establece la zona operativa seleccionada
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intZonaOperativaId() As Integer
        Get
            Return intmZonaOperativaId
        End Get
        Set(ByVal strValue As Integer)
            intmZonaOperativaId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCboDireccion 
    ' Description: Obtiene o establece el conjunto de Direcciones Operativas
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strCboDireccion() As String
        Get
            Return strmCboDireccion
        End Get
        Set(ByVal strValue As String)
            strmCboDireccion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCboZona 
    ' Description: Obtiene o establece el conjunto de Zonas Operativas
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strCboZona() As String
        Get
            Return strmCboZona
        End Get
        Set(ByVal strValue As String)
            strmCboZona = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intTiendaId 
    ' Description: Obtiene o establece el id de la tienda seleccionada
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intTiendaId() As Integer
        Get
            Return intmTiendaId
        End Get
        Set(ByVal intValue As Integer)
            intmTiendaId = intValue
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
        Dim strRecordBrowserName As String = "SistemaAdministrarTiendas"

        ' Declaramos e inicialziamos las variables locales
        Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1", Request))
        Dim astrDataArray As Array = Nothing

        ' Si la dirección y la zona son válidas
        If intDireccionOperativaId > 0 AndAlso intZonaOperativaId > 0 Then

            ' Obtenemos las tiendas que forman parte de la zona seleccionada
            astrDataArray = Benavides.CC.Business.clsConcentrador.clsTienda.strBuscarPorDireccion(intDireccionOperativaId, intZonaOperativaId, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

            ' Establecemos los eventos onClick actual y futuro
            Dim strCurrentJavascriptOnClickEvent As String = "onclick=""window.location='SistemaAdministrarTiendas.aspx?strCmd=Agregar'"""
            Dim strNewJavascriptOnClickEvent As String = "onclick=""cmdNavegadorRegistrosAgregar_onclick(" & intDireccionOperativaId & ", " & intZonaOperativaId & ");"""

            ' Regresamos el resultado
            Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?intDireccionId=" & intDireccionOperativaId & "&intZonaId=" & intZonaOperativaId & "&").Replace(strCurrentJavascriptOnClickEvent, strNewJavascriptOnClickEvent)

        Else

            If intDireccionOperativaId = 0 Then

                ' De lo contrario buscamos las tiendas que no están vinculadas con sucursal alguna
                strRecordBrowserName = "SistemaAdministrarTiendasSinAsignar"

                ' Obtenemos las tiendas que no forman parte sucursal alguna
                astrDataArray = Benavides.CC.Data.clsTienda.strEjecutarBuscarTiendasSinAsignar(CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)
                'blnmCanDisableAddButton = True

                ' Regresamos el resultado
                Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?").Replace("Tiendas que forman parte de la zona seleccionada", "Tiendas sin vincular a sucursal alguna")

            End If

        End If

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", isocraft.commons.clsWeb.strGetPageParameter("cmdConsultar", ""), Request)

        ' Almacenamos la Dirección Operativa Recibida
        intDireccionOperativaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboDireccionOperativa", CStr(isocraft.commons.clsWeb.strGetPageParameter("intDireccionId", "0", Request)), Request))

        ' Almacenamos la Zona Operativa Recibida
        intZonaOperativaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboZonaOperativa", CStr(isocraft.commons.clsWeb.strGetPageParameter("intZonaId", "0", Request)), Request))

        ' Almacenamos el id de la tienda seleccionada
        intTiendaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intTiendaId", "0", Request))


        'Consultamos las direcciones operativas
        Dim astrRecords As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString)

        'Creamos el javascript para llenar el combo de direcciones operativas
        strCboDireccion = isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccionOperativa", intDireccionOperativaId, astrRecords, 0, 1, 1)

        ' Si la dirección operativa es mayor a uno significa que se ha seleccionado alguna
        If intDireccionOperativaId <> 0 Then

            'Consultamos las zonas operativas
            Dim astrZoneRecords As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionOperativaId, 0, strConnectionString)
            strCboZona = isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZonaOperativa", intZonaOperativaId, astrZoneRecords, 0, 1, 1)

        End If

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Agregar"

                Call Response.Redirect("SistemaEditarTienda.aspx?strCmd=Agregar&intDireccionId=" & intDireccionOperativaId & "&intZonaId=" & intZonaOperativaId)
                Call Response.End()

            Case "Ver"

                Call Response.Redirect("SistemaVerTienda.aspx?strCmd=Ver&intTiendaId=" & intTiendaId & "&intDireccionId=" & intDireccionOperativaId & "&intZonaId=" & intZonaOperativaId)
                Call Response.End()

            Case "Editar"

                Call Response.Redirect("SistemaEditarTienda.aspx?strCmd=Editar&intTiendaId=" & intTiendaId & "&intDireccionId=" & intDireccionOperativaId & "&intZonaId=" & intZonaOperativaId)
                Call Response.End()

            Case "Borrar"

                ' Eliminamos las tiendas no asignadas a sucursal alguna
                If intTiendaId > 0 Then
                    Call Benavides.CC.Data.clstblTienda.intEliminar(intTiendaId, 0, 0, "", "", 0, "", 0, "", "", Now, "", strConnectionString)
                End If

        End Select

    End Sub


End Class

