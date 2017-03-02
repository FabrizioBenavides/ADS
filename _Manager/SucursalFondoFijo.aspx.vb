Imports Isocraft.Web.Http

''' <summary>
'''     Consulta de fondo fijo
''' </summary>
''' <remarks>
'''     
''' </remarks>
Public Class SucursalFondoFijo
    Inherits System.Web.UI.Page

#Region "Private variables"

    Private intmAnio As Integer
    Private intmDireccionId As Integer
    Private intmMes As Integer
    Private intmZonaId As Integer
    Private strmCommand As String = String.Empty
    Private strmJavascriptWindowOnLoadCommands As String = String.Empty
    Private strmRecordBrowserHtml As String = String.Empty

#End Region

#Region " Web Form Designer Generated Code "

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

    End Sub

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

        ' Get the page parameters
        intmDireccionId = GetPageParameter("cboDireccion", GetPageParameter("intDireccionId", 0))
        intmZonaId = GetPageParameter("cboZona", GetPageParameter("intZonaId", 0))
        intmMes = GetPageParameter("cboMes", GetPageParameter("intMes", 0))
        intmAnio = GetPageParameter("cboAnio", GetPageParameter("intAnio", 0))
        strmCommand = GetPageParameter("strCmd", "")

    End Sub

#End Region

    '====================================================================
    ' Name       : strLlenarDireccionComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboDireccion"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Protected Function strLlenarDireccionComboBox() As String

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
    Protected Function strLlenarZonaComboBox() As String

        If intDireccionId > 0 Then

            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZona", intZonaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, 0, strConnectionString), 0, 1, 1)

        End If

    End Function

    ''' <summary>
    '''     Regresa el año seleccionado
    ''' </summary>
    ''' <value>
    '''     <para>
    '''         
    '''     </para>
    ''' </value>
    ''' <remarks>
    '''     
    ''' </remarks>
    Protected ReadOnly Property intAnio() As Integer

        Get

            Return intmAnio

        End Get

    End Property

    '====================================================================
    ' Name       : intDireccionId
    ' Description: Identificador de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Protected ReadOnly Property intDireccionId() As Integer

        Get

            Return intmDireccionId

        End Get

    End Property

    '====================================================================
    ' Name       : intGrupoUsuarioId
    ' Description: Identificador del Grupo de Usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Protected ReadOnly Property intGrupoUsuarioId() As Integer

        Get

            Return CInt(Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))

        End Get

    End Property

    ''' <summary>
    '''     Regresa el mes del año seleccionado
    ''' </summary>
    ''' <value>
    '''     <para>
    '''         
    '''     </para>
    ''' </value>
    ''' <remarks>
    '''     
    ''' </remarks>
    Protected ReadOnly Property intMes() As Integer

        Get

            Return intmMes

        End Get

    End Property

    '====================================================================
    ' Name       : intZonaId
    ' Description: Identificador de la Zona
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Protected ReadOnly Property intZonaId() As Integer

        Get

            Return intmZonaId

        End Get

    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Protected ReadOnly Property strCmd() As String

        Get

            Return strmCommand

        End Get

    End Property

    '====================================================================
    ' Name       : strFormAction
    ' Description: HTML form's action property value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Protected ReadOnly Property strFormAction() As String

        Get

            Return strThisPageName

        End Get

    End Property

    '====================================================================
    ' Name       : strHTMLFechaHora
    ' Description: Genera la fecha y hora de la página
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Protected ReadOnly Property strHTMLFechaHora() As String

        Get

            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")

        End Get

    End Property

    '====================================================================
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Protected Property strJavascriptWindowOnLoadCommands() As String

        Get

            Return strmJavascriptWindowOnLoadCommands

        End Get

        Set(ByVal strValue As String)

            strmJavascriptWindowOnLoadCommands = strValue

        End Set

    End Property

    ''' <summary>
    '''     Regresa el Html del Record Browser
    ''' </summary>
    ''' <value>
    '''     <para>
    '''         
    '''     </para>
    ''' </value>
    ''' <remarks>
    '''     
    ''' </remarks>
    Protected ReadOnly Property strRecordBrowserHtml() As String

        Get

            Return strmRecordBrowserHtml

        End Get

    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: Name of this page
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Protected ReadOnly Property strThisPageName() As String

        Get

            Return Server.UrlEncode(GetPageName())

        End Get

    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Protected ReadOnly Property strUsuarioNombre() As String

        Get

            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)

        End Get

    End Property

    ''' <summary>
    '''     Edita el monto extra de fondo fijo de una sucursal
    ''' </summary>
    Private Sub Editar()

        Dim intCompaniaId As Integer = GetPageParameter("intCompaniaId", 0)
        Dim intSucursalId As Integer = GetPageParameter("intSucursalId", 0)
        Dim intFondoFijoPresupuestadoId As Integer = GetPageParameter("intFondoFijoPresupuestadoId", 0)

        If intCompaniaId > 0 AndAlso intSucursalId > 0 AndAlso intFondoFijoPresupuestadoId > 0 AndAlso intmDireccionId > 0 AndAlso intmZonaId > 0 AndAlso intmMes > 0 AndAlso intmAnio > 0 Then

            Call Response.Redirect(String.Format("SucursalEditarGastosDeSucursal.aspx?intCompaniaId={0}&intSucursalId={1}&intDireccionId={2}&intZonaId={3}&intMes={4}&intAnio={5}&intFondoFijoPresupuestadoId={6}&strCmd={7}", intCompaniaId, intSucursalId, intmDireccionId, intmZonaId, intmMes, intmAnio, intFondoFijoPresupuestadoId, strmCommand))

        End If

    End Sub

    ''' <summary>
    '''     Obtiene los registros de gasto de los fondos fijos
    ''' </summary>
    Private Sub ObtenerRegistrosGastoFondoFijo()

        Dim fondosFijosGastados As Array

        If intmDireccionId > 0 AndAlso intmZonaId > 0 AndAlso intmMes > 0 AndAlso intmAnio > 0 Then

            fondosFijosGastados = Benavides.CC.Data.clsTienda.clsSucursal.aobjObtenerFondoFijoGastado(intmDireccionId, intmZonaId, intmMes, intmAnio, 0, 0, strConnectionString)

        End If

        strmRecordBrowserHtml = Benavides.CC.Commons.clsRecordBrowser.strGetHTML("SucursalFondoFijo", fondosFijosGastados, 1, 1000, strThisPageName & "?intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId & "&intMes=" & intMes & "&intAnio=" & intAnio & "&")

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Load

        'Put user code to initialize the page here

        Select Case strmCommand

            Case "Agregar"

                Call Response.Redirect("SucursalAltaDeFondoFijo.aspx")

            Case "Editar"

                Call Editar()

            Case Else

                Call ObtenerRegistrosGastoFondoFijo()

        End Select

    End Sub

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

End Class
