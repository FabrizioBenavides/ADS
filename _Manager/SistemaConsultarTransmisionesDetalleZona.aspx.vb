'====================================================================
' Class         : clsSistemaConsultarTransmisionesDetalleZona
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Transmisiones
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Joaquín Hernández García
' Version       : 1.0
' Last Modified : Thursday, June 24, 2004
'====================================================================
Public Class clsSistemaConsultarTransmisionesDetalleZona
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

    ' Variables privadas
    Private strmFechaInicial As String
    Private strmFechaFinal As String
    Private intmDireccionId As Integer

    '====================================================================
    ' Name       : strFechaInicial
    ' Description: Fecha inicial
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strFechaInicial() As String
        Get
            strmFechaInicial = isocraft.commons.clsWeb.strGetPageParameter("txtFechaInicial", isocraft.commons.clsWeb.strGetPageParameter("strFechaInicial", ""))
            Return strmFechaInicial
        End Get
        Set(ByVal strValue As String)
            strmFechaInicial = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaFinal
    ' Description: Fecha final
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strFechaFinal() As String
        Get
            strmFechaFinal = isocraft.commons.clsWeb.strGetPageParameter("txtFechaFinal", isocraft.commons.clsWeb.strGetPageParameter("strFechaFinal", ""))
            Return strmFechaFinal
        End Get
        Set(ByVal strValue As String)
            strmFechaFinal = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intDireccionId
    ' Description: Identificador de la dirección operativa
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDireccionId() As Integer
        Get
            Return CInt(isocraft.commons.clsWeb.strGetPageParameter("intDireccionOperativaId", isocraft.commons.clsWeb.strGetPageParameter("txtDireccionId", "0")))
        End Get
    End Property

    '====================================================================
    ' Name       : intZonaId
    ' Description: Identificador de la zona operativa
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intZonaId() As Integer
        Get
            Return CInt(isocraft.commons.clsWeb.strGetPageParameter("intZonaOperativaId", isocraft.commons.clsWeb.strGetPageParameter("cboZona", "0")))
        End Get
    End Property

    '====================================================================
    ' Name       : intCategoriaRegistroEventoId
    ' Description: Identificador del tipo de evento
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCategoriaRegistroEventoId() As Integer
        Get
            Return CInt(isocraft.commons.clsWeb.strGetPageParameter("intCategoriaRegistroEventoId", isocraft.commons.clsWeb.strGetPageParameter("cboCategoriaRegistroEvento", "0")))
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
    ' Name       : strCategoriaRegistroEventoNombre
    ' Description: Nombre de la categoría del evento
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCategoriaRegistroEventoNombre() As String
        Get
            If intCategoriaRegistroEventoId > 0 Then
                Dim astrData As Array = Benavides.CC.Data.clstblCategoriaRegistroEvento.strBuscar(intCategoriaRegistroEventoId, "", "", "", Now, 0, 0, strConnectionString)
                If IsArray(astrData) = True AndAlso astrData.Length > 0 Then
                    Return CStr(DirectCast(astrData.GetValue(0), Array).GetValue(1))
                End If
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strRangoDeFechas
    ' Description: Leyenda con el rango de fechas
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRangoDeFechas() As String
        Get
            Dim dtmFechaInicial As Date = CDate(strFechaInicial)
            Dim dtmFechaFinal As Date = CDate(strFechaFinal)
            Dim astrMonths() As String = {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"}
            Return "Del " & Day(dtmFechaInicial) & " de " & CStr(astrMonths.GetValue(Month(dtmFechaInicial) - 1)) & " de " & Year(dtmFechaInicial) & " al " & Day(dtmFechaFinal) & " de " & CStr(astrMonths.GetValue(Month(dtmFechaFinal) - 1)) & " de " & Year(dtmFechaFinal)
        End Get
    End Property

    '====================================================================
    ' Name       : strLlenarCategoriaRegistroEventoComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboCategoriaRegistroEvento"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarCategoriaRegistroEventoComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboCategoriaRegistroEvento", intCategoriaRegistroEventoId, Benavides.CC.Data.clsTransmision.strEjecutarBuscarNivelServicioTransmision(intDireccionId, CDate(strFechaInicial), CDate(strFechaFinal), 1, 100, strConnectionString), 1, 3, 1)
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
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZona", intZonaId, Benavides.CC.Data.clsTransmision.strEjecutarBuscarNivelServicioTransmisionesPorDireccion(intDireccionId, CDate(strFechaInicial), CDate(strFechaFinal), intCategoriaRegistroEventoId, 1, 100, strConnectionString), 1, 2, 1)
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
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 10
        Const strRecordBrowserName As String = "VentasCortesEnCeroDetalleZona"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1"))

        ' Obtenemos el rango de fechas
        Dim dtmFechaInicial As Date = CDate(strFechaInicial)
        Dim dtmFechaFinal As Date = CDate(strFechaFinal)

        ' Buscamos las sucursales de esta dirección y zona
        Dim astrDataArray As Array = Benavides.CC.Data.clsTransmision.strEjecutarBuscarNivelServicioTransmisionesPorZona(intDireccionId, intZonaId, dtmFechaInicial, dtmFechaFinal, intCategoriaRegistroEventoId, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?intCategoriaRegistroEventoId=" & intCategoriaRegistroEventoId & "&strFechaInicial=" & CStr(dtmFechaInicial) & "&strFechaFinal=" & CStr(dtmFechaFinal) & "&").Replace("Cortes en cero", "<script language=""javascript"">strCategoriaRegistroEventoNombre()</script>")

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        Dim strCmd As String = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Validamos que tengamos los parámetros requeridos
        If intDireccionId < 1 OrElse intZonaId < 1 OrElse Len(strFechaInicial) = 0 OrElse Len(strFechaFinal) = 0 Then
            Call Response.Redirect("SistemaConsultarNivelDeServicioEnTransmisiones.aspx")
        End If

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Ver"

                Call Response.Redirect("SistemaConsultarTransmisionesDetalleSucursal.aspx?intDireccionOperativaId=" & intDireccionId & "&intZonaOperativaId=" & intZonaId & "&intCompaniaId=" & isocraft.commons.clsWeb.strGetPageParameter("intCompaniaId", "0") & "&intSucursalId=" & isocraft.commons.clsWeb.strGetPageParameter("intSucursalId", "0") & "&intCategoriaRegistroEventoId=" & intCategoriaRegistroEventoId & "&strFechaInicial=" & strFechaInicial & "&strFechaFinal=" & strFechaFinal)

        End Select

    End Sub

End Class
