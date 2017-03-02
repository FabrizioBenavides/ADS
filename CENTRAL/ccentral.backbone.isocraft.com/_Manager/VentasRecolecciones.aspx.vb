Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

'====================================================================
' Class         : clsVentasRecolecciones
' Title         : VentasRecolecciones
' Description   : Consulta de recolecciones de tipo normal y DEX 
'                 realizadas en las sucursales
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Juan Colunga (juan@isocraft.com)
' Last Modified : Thursday, April 21, 2005
'====================================================================

Public Class clsVentasRecolecciones
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
        intFechaId = GetPageParameter("optFecha", 0)
        strTipoRecoleccion = GetPageParameter("cboTipo", "RecoleccionDEX")
        intEstatus = GetPageParameter("cboEstatus", 2)
        intDireccionOperativaId = GetPageParameter("cboDireccion", 0)
        intZonaOperativaId = GetPageParameter("cboZona", 0)
    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private intmFechaId As Integer
    Private strmTipoRecoleccion As String
    Private intmEstatus As Integer
    Private intmDireccionOperativaId As Integer
    Private intmZonaOperativaId As Integer
    Private strmTipoNombreId As String
    Private strmTipoNombre As String


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
    ' Name       : intFechaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intFechaId() As Integer
        Get
            Return intmFechaId
        End Get
        Set(ByVal intValue As Integer)
            intmFechaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoRecoleccion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTipoRecoleccion() As String
        Get
            Return strmTipoRecoleccion
        End Get
        Set(ByVal strValue As String)
            strmTipoRecoleccion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intEstatus
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intEstatus() As Integer
        Get
            Return intmEstatus
        End Get
        Set(ByVal intValue As Integer)
            intmEstatus = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intDireccionOperativaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intDireccionOperativaId() As Integer
        Get
            Return intmDireccionOperativaId
        End Get
        Set(ByVal intValue As Integer)
            intmDireccionOperativaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intZonaOperativaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intZonaOperativaId() As Integer
        Get
            Return intmZonaOperativaId
        End Get
        Set(ByVal intValue As Integer)
            intmZonaOperativaId = intValue
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
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccion", intDireccionOperativaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString), 0, 1, 1)
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
        If intDireccionOperativaId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZona", intZonaOperativaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionOperativaId, 0, strConnectionString), 0, 1, 1)
        End If
    End Function

    '====================================================================
    ' Name       : strTipoTicketNombreId 
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTipoTicketNombreId() As String
        Get
            Return strmTipoNombreId
        End Get
        Set(ByVal strValue As String)
            strmTipoNombreId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoTicketNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTipoTicketNombre() As String
        Get
            Return strmTipoNombre
        End Get
        Set(ByVal strValue As String)
            strmTipoNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strLlenarControlTipoReporte
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboTipo"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarTipoRecoleccionComboBox() As String
        Dim aobjRecords As System.Collections.ArrayList = New System.Collections.ArrayList

        Dim aobjRow As System.Collections.SortedList = New System.Collections.SortedList
        Call aobjRow.Add("strTipoTicketNombreId ", "RecoleccionDEX")
        Call aobjRow.Add("strTipoTicketNombre", "DEX")
        Call aobjRecords.Add(aobjRow)
        aobjRow = Nothing

        aobjRow = New System.Collections.SortedList
        Call aobjRow.Add("strTipoTicketNombreId ", "Recoleccion")
        Call aobjRow.Add("strTipoTicketNombre", "Normal")
        Call aobjRecords.Add(aobjRow)
        aobjRow = Nothing

        Return CreateJavascriptComboBoxOptions("cboTipo", strTipoRecoleccion, aobjRecords.ToArray(), "strTipoTicketNombreId ", "strTipoTicketNombre", 1)
    End Function

    '====================================================================
    ' Name       : strLlenarControlEstatusReporte
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboTipo"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarEstatusRecoleccionComboBox() As String
        Dim aobjRecords As System.Collections.ArrayList = New System.Collections.ArrayList

        Dim aobjRow As System.Collections.SortedList = New System.Collections.SortedList
        Call aobjRow.Add("strTipoTicketNombreId ", "1")
        Call aobjRow.Add("strTipoTicketNombre", "Realizados")
        Call aobjRecords.Add(aobjRow)
        aobjRow = Nothing

        aobjRow = New System.Collections.SortedList
        Call aobjRow.Add("strTipoTicketNombreId ", "2")
        Call aobjRow.Add("strTipoTicketNombre", "Pendientes")
        Call aobjRecords.Add(aobjRow)
        aobjRow = Nothing

        Return CreateJavascriptComboBoxOptions("cboEstatus", CStr(intEstatus), aobjRecords.ToArray(), "strTipoTicketNombreId ", "strTipoTicketNombre", 1)
    End Function

    '====================================================================
    ' Name       : strObtenerSucursalesPorZonaElegida
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strBuscarRecoleccionesPorSucursalElegida() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 50
        Const strRecordBrowserName As String = "VentasRecolecciones"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim astrDataArray As Array
        Dim astrDataRow As Array

        If Len(strTipoRecoleccion) > 1 Or intEstatus > 0 Or intDireccionOperativaId > 0 Or intZonaOperativaId > 0 Then
            astrDataArray = Benavides.CC.Data.clsRecoleccion.aobjBuscarRecoleccionesPorSucursal(intDireccionOperativaId, intZonaOperativaId, strTipoRecoleccion, intEstatus, intFechaId, 0, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)
        End If

        ' Generamos el URL destino de las páginas

        Dim strTargetURL As String = strThisPageName & _
                                     "?cboDireccion=" & intDireccionOperativaId & _
                                     "&cboZona=" & intZonaOperativaId & _
                                     "&cboTipo=" & strTipoRecoleccion & _
                                     "&cboEstatus=" & intEstatus & _
                                     "&optFecha=" & intFechaId & _
                                     "&intPagina=" & GetPageParameter("intNavegadorRegistrosPagina", 1) & _
                                     "&"

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strTargetURL)

    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Execute the selected command
        Select Case strCmd

            Case "Ver"
                ' Vemos el detalle de las Recolecciones
                Call Response.Redirect("VentasRecoleccionesDetalleSucursal.aspx?strCmd=Ver&intCompaniaId=" & GetPageParameter("intCompaniaId", 0) & "&intSucursalId=" & GetPageParameter("intSucursalId", 0) & "&cboEstatus=" & intEstatus & "&cboTipo=" & strTipoRecoleccion & "&optFecha=" & intFechaId & "&cboDireccion=" & intDireccionOperativaId & "&cboZona=" & intZonaOperativaId & "&intPagina=" & GetPageParameter("intPagina", 1))

            Case Else

        End Select

    End Sub


End Class
