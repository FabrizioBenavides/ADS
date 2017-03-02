Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration

Public Class clsMercanciaCancelarTransferencia
    Inherits System.Web.UI.Page
    Private intmPrintCambiarEstado As Integer
    Private strmFechaActual As String

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    '====================================================================
    ' Name       : strRedirectPage
    ' Description: Página hacia la cual se debe redireccionar al usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRedirectPage() As String
        Get
            ' Return "/Default.aspx?strURL=" & Server.UrlEncode(Request.ServerVariables("SCRIPT_NAME"))
            If intCompaniaId > 0 Then
                Return "/Default.aspx?strURL=/_ScriptLibrary/POSAdminRedirectorCC.aspx?strPageName=" & strThisPageName
            Else
                Return "/Default.aspx?strURL=" & Server.UrlEncode(Request.ServerVariables("SCRIPT_NAME"))
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strFormAction
    ' Description: Valor de la acción de la forma HTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormAction() As String
        Get
            Return Request.ServerVariables("SCRIPT_NAME")
        End Get
    End Property

    '====================================================================
    ' Name       : intCompaniaId
    ' Description: Valor de la Compañia 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCompaniaId() As Integer
        Get
            Return CInt(clsCommons.strReadCookie("intCompaniaId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Valor de la Sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intSucursalId() As Integer
        Get
            Return CInt(clsCommons.strReadCookie("intSucursalId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strSucursalNombre
    ' Description: Nombre de la Sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalNombre() As String
        Get
            Return clsCommons.strReadCookie("strSucursalNombre", "0", Request, Server)
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
            Return CInt(clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del Usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return clsCommons.strReadCookie("strUsuarioNombre", "0", Request, Server)
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
            Return clsCommons.strGetPageName(Request)
        End Get
    End Property

    '====================================================================
    ' Name       : strCadenaConexion
    ' Description: Valor que tomara la variable strmCadenaConexion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCadenaConexion() As String
        Get
            Return ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : intTransferenciaId
    ' Description: Valor de la transferencia.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intTransferenciaId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intTransferenciaId")) Then
                Return CInt(Request.QueryString("intTransferenciaId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intNumeroOrden
    ' Description: Valor de la orden.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intNumeroOrden() As Integer
        Get
            If Not IsNothing(Request.QueryString("intNumeroOrden")) Then
                Return CInt(Request.QueryString("intNumeroOrden"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strFechaOrden
    ' Description: Valor de la fecha.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strFechaOrden() As String
        Get
            If Not IsNothing(Request.QueryString("strFechaOrden")) Then
                Return (Request.QueryString("strFechaOrden"))
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intSucursalEsperaEnvio
    ' Description: Valor de la sucursal que espera el envío.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intSucursalEsperaEnvio() As String
        Get
            If Len(Request.QueryString("intSucursalEsperaEnvio")) > 0 Then
                Return Request.QueryString("intSucursalEsperaEnvio")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strSucursalEsperaEnvio
    ' Description: Nombre de la sucursal que espera el envío.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strSucursalEsperaEnvio() As String
        Get
            If Not IsNothing(Request.QueryString("strSucursalEsperaEnvio")) Then
                Return Request.QueryString("strSucursalEsperaEnvio")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intPrintCambiarEstado
    ' Description: Valor del retorno de cambiar estado.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intPrintCambiarEstado() As Integer
        Get
            Return intmPrintCambiarEstado
        End Get
        Set(ByVal strValue As Integer)
            intmPrintCambiarEstado = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaActual
    ' Description: Valor del retorno de cambiar estado.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strFechaActual() As String
        Get
            Return strmFechaActual
        End Get
        Set(ByVal strValue As String)
            strmFechaActual = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Valor del parámetro strCmd
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return Request.QueryString("strCmd")
        End Get
    End Property

    '====================================================================
    ' Name       : Page_Load
    ' Description: Evento "Load" de la página
    ' Parameters :
    '              ByVal objSender As System.Object
    '                 - Objeto que genera el Evento
    '              ByVal objEvent As System.EventArgs
    '                 - Argumentos del Evento
    ' Throws     : Ninguna
    ' Output     : Ninguna
    '====================================================================
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim objCancelarTransferencia As Array = Nothing
        Dim strCancelarTransferencias As String() = Nothing
        Dim intAgregarArticulo As Integer
        Dim intCambiarEstado As Integer

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strRedirectPage)
        End If

        strFechaActual = Day(Now()).ToString & "/" & Month(Now()).ToString & "/" & Year(Now()).ToString

        Select Case strCmd
            Case "Consultar"

                If (clsCommons.strFormatearDescripcion(Request.Form("txtFecha")) <> strFechaActual) Then
                    strFechaActual = clsCommons.strFormatearDescripcion(Request.Form("txtFecha"))
                End If

                ' Agregamos el artículo.
                intAgregarArticulo = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.intAgregarArticulo(intTransferenciaId, "CANCELADA", 0, "", 0, 0, 0, CDate(clsCommons.strDMYtoMDY(strFechaOrden)), strUsuarioNombre, strCadenaConexion)

                ' Si el agregar artículo no regresa error continuamos
                If intAgregarArticulo > 0 Then
                    intCambiarEstado = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.intCambiarEstado(intCompaniaId, intSucursalId, intTransferenciaId, "CANCELADA", 0, CDate(clsCommons.strDMYtoMDY(clsCommons.strFormatearDescripcion(Request.Form("txtFecha")))), clsCommons.strFormatearDescripcion(clsCommons.strFormatearDescripcion(Request.Form("txtComentarios"))), strUsuarioNombre, strCadenaConexion)
                End If

                If intCambiarEstado > 0 Then
                    intPrintCambiarEstado = intCambiarEstado
                End If
        End Select

    End Sub

End Class
