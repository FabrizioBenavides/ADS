Imports Isocraft.Web.Http
Imports System.Text
Imports System.Configuration
Imports Benavides.CC.Data
Imports Benavides.CC.Commons


Public Class popVentasFacturacionGlobalVer
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

    End Sub

#End Region

#Region " Class Private Attributes"

    Const strComitasDobles As String = """"
    Private strmJavascriptWindowOnLoadCommands As String


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
    ' Name       : strAccion
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strAccion() As String
        Get
            Return Request("strAccion")
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
            Return Request("strCmd")
        End Get
    End Property

    '====================================================================
    ' Name       : intDireccionOperativaId 
    ' Description: 
    ' Accessor   : Read
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDireccionOperativaId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intDireccionOperativaId"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : intZonaOperativaId 
    ' Description: 
    ' Accessor   : Read
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intZonaOperativaId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intZonaOperativaId"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property

    Public ReadOnly Property strSucursalId() As String
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("strSucursalId"))

            If strTemporal.Equals("") Then
                Return ""
            Else
                Return strTemporal
            End If

        End Get
    End Property

    Public ReadOnly Property intCompaniaid() As Integer
        Get
            Dim intmCompaniaid As Integer = 0

            If Len(strSucursalId) > 3 Then
                Dim astrCompaniaSucursal As Array = Split(strSucursalId, "|")
                If astrCompaniaSucursal.Length > 0 Then
                    intmCompaniaid = CInt(astrCompaniaSucursal.GetValue(0))
                End If
            End If

            Return intmCompaniaid

        End Get

    End Property

    Public ReadOnly Property intSucursalid() As Integer
        Get
            Dim intmSucursalid As Integer = 0

            If Len(strSucursalId) > 3 Then
                Dim astrCompaniaSucursal As Array = Split(strSucursalId, "|")
                If astrCompaniaSucursal.Length > 0 Then
                    intmSucursalid = CInt(astrCompaniaSucursal.GetValue(1))
                End If
            End If

            Return intmSucursalid

        End Get

    End Property


    Public ReadOnly Property intCompaniaVerId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intCompaniaVerId"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get

    End Property

    Public ReadOnly Property intSucursalVerId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intSucursalVerId"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get

    End Property

    '====================================================================
    ' Name       : intMesVenta 
    ' Description: 
    ' Accessor   : Read
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intMesVenta() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intMesVenta"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : intDiasFaltantes 
    ' Description: 
    ' Accessor   : Read
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDiasFaltantes() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intDiasFaltantes"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : blnMesDetallado 
    ' Description: 
    ' Accessor   : Read
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property blnMesDetallado() As Byte
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("blnMesDetallado"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CByte(strTemporal)
            End If

        End Get
    End Property

    Public ReadOnly Property strTituloConsulta() As String
        Get
            Select Case strCmd

                Case "VerDetalleMes"
                    Return "Detalle por día del mes seleccionado"
                Case "VerDetalleSucursal"
                    Return "Detalle por día de la sucursal seleccionada"
            End Select

        End Get
    End Property

    '====================================================================
    ' Name       : strConsultar
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strConsultar() As String

        Dim strRecordBrowserName As String = ""
        Dim intElementsPerPage As Integer = 31
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim intInitialPosition As Double = clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)

        Dim objDataArrayConsulta As Array

        Dim strTargetURL As String = strThisPageName & "?strCmd=" & strCmd

        Select Case strCmd

            Case "VerDetalleMes"

                strRecordBrowserName = "VentasFacturacionGlobalVerMes"
                strTargetURL &= "&intMesVenta=" & intMesVenta.ToString & _
                                "&intDireccionOperativaId=" & intDireccionOperativaId.ToString & _
                                "&intZonaOperativaId=" & intZonaOperativaId.ToString & _
                                "&strSucursalId=" & strSucursalId & _
                                "&intDiasFaltantes=" & intDiasFaltantes.ToString & _
                                "&blnMesDetallado=" & blnMesDetallado & "&"

                objDataArrayConsulta = clsFacturaElectronicaGlobal.strBuscarTotales(intDireccionOperativaId, intZonaOperativaId, intCompaniaid, intSucursalid, intMesVenta, intDiasFaltantes, blnMesDetallado, intInitialPosition, intElementsPerPage, strConnectionString)

            Case "VerDetalleSucursal"

                strRecordBrowserName = "VentasFacturacionGlobalVerSucursal"
                strTargetURL &= "&intCompaniaVerId=" & intCompaniaVerId.ToString & _
                                "&intSucursaVerlId=" & intSucursalVerId.ToString & _
                                "&intMesVenta=" & intMesVenta.ToString & "&"

                objDataArrayConsulta = clsFacturaElectronicaGlobal.strBuscarDetalle(intCompaniaVerId, intSucursalVerId, intMesVenta, intInitialPosition, intElementsPerPage, strConnectionString)

        End Select

        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, objDataArrayConsulta, intSelectedPage, intElementsPerPage, strTargetURL)

    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

End Class
