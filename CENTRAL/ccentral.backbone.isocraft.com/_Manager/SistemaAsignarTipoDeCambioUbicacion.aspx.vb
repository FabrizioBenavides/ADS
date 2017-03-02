Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

Public Class SistemaAsignarTipoDeCambioUbicacion
    Inherits System.Web.UI.Page

    ' Variables locales privadas

#Region " Class Private Attributes"
    Private strmJavascriptWindowOnLoadCommands As String

    Private intmMonedaCambioId As Integer
    Private intmUbicacionSucursalId As Integer
    Private dblmTipoDeCambioMonedaValor As Double
    Private strmCommand As String

#End Region

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


        ' Almacenamos el comando ejecutado
        strCmd = GetPageParameter("strCmd", "")
        intMonedaCambioId = CInt(GetPageParameter("cboMoneda", GetPageParameter("intMonedaCambioId", "0")))
        intUbicacionSucursalId = CInt(GetPageParameter("optUbicacion", GetPageParameter("intUbicacionSucursalId", "0")))
        dblTipoDeCambioMonedaValor = CDbl(isocraft.commons.clsWeb.strGetPageParameter("txtTipoDeCambioMonedaValor", isocraft.commons.clsWeb.strGetPageParameter("dblTipoDeCambioMonedaValor", "0")))


    End Sub

#End Region

    '====================================================================
    ' Name       : intMonedaBaseId
    ' Description: Identificador de la Moneda Base
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intMonedaBaseId() As Integer
        Get
            Dim astrMonedaBase As Array = Benavides.CC.Data.clstblMoneda.strBuscar(0, "PESOS", "", Now, "", 0, 0, strConnectionString)

            If IsArray(astrMonedaBase) AndAlso astrMonedaBase.Length > 0 Then
                Return CInt(DirectCast(astrMonedaBase.GetValue(0), Array).GetValue(0))
            Else
                Return 0
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : intMonedaCambioId
    ' Description: Identificador de la Moneda
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intMonedaCambioId() As Integer
        Get
            Return intmMonedaCambioId
        End Get
        Set(ByVal intValue As Integer)
            intmMonedaCambioId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intUbicacionSucursalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intUbicacionSucursalId() As Integer
        Get
            Return intmUbicacionSucursalId
        End Get
        Set(ByVal intValue As Integer)
            intmUbicacionSucursalId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : dblTipoDeCambioMonedaValor
    ' Description: Tipo de cambio
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property dblTipoDeCambioMonedaValor() As Double
        Get
            Return dblmTipoDeCambioMonedaValor
        End Get
        Set(ByVal intValue As Double)
            dblmTipoDeCambioMonedaValor = intValue
        End Set

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
    ' Name       : strCmd 
    ' Description: Obtiene o establece el comando actual
    ' Accessor   : Read, Write
    ' Throws     : None
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
    ' Name       : strLlenarMonedaComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboMoneda"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarMonedaComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboMoneda", intMonedaCambioId, Benavides.CC.Data.clstblMoneda.strBuscar(0, "", "", Now, "", 0, 0, strConnectionString), 0, 2, 1)
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
        Const intElementsPerPage As Integer = 50
        Const strRecordBrowserName As String = "SucursalAsignarTipoDeCambio"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)

        Dim astrSucursalesSeleccionadas As Array = Nothing

        ' Si los identificadores de la moneda y ubicacion son válidos

        If intMonedaCambioId > 0 Then

            ' Buscamos las sucursales de esta dirección y zona que tienen asignadas a la moneda especificada
            Dim astrDataArray As Array = Benavides.CC.Data.clsTienda.clsSucursal.strBuscarTipoDeCambioMonedaxUbicacion(intMonedaCambioId, intMonedaBaseId, intUbicacionSucursalId + 1, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

            ' Generamos el navegador de registros
            Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?intMonedaCambioId=" & intMonedaCambioId & "&intUbicacionSucursalId=" & intUbicacionSucursalId & "&dblTipoDeCambioMonedaValor=" & dblTipoDeCambioMonedaValor & "&")

        End If

    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Aplicar"

                ' Asignamos la moneda de la sucusal, si los identificadores son válidos
                If intMonedaCambioId > 0 And intMonedaBaseId > 0 Then

                    Dim strUbicacion As String

                    Select Case intUbicacionSucursalId
                        Case 0
                            strUbicacion = "INTERIOR"
                        Case Else
                            strUbicacion = "FRONTERA"
                    End Select

                    Dim intSucursalesActualizadas As Integer = Benavides.CC.Data.clsTienda.clsSucursal.intActualizarTipoDeCambioMonedaxUbicacion(intMonedaCambioId, intMonedaBaseId, intUbicacionSucursalId + 1, dblTipoDeCambioMonedaValor, strUsuarioNombre, strConnectionString)

                    strJavascriptWindowOnLoadCommands &= "  alert(""Se Aplico Tipo de Cambio: [" & CStr(dblTipoDeCambioMonedaValor) & "]\n\r\n\rA [" & CStr(intSucursalesActualizadas) & "] sucursales de " & strUbicacion & """);" & vbCrLf

                End If

        End Select

    End Sub

End Class
