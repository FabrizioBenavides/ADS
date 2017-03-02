Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class clsMercanciaNotasCargoDetalle
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

    Private dtmmFechaNotaCargo As String = ""
    Private intmProveedorId As Integer = 0
    Private strmRazonSocialProveedor As String = ""
    Private strmNumeroFactura As String = ""
    Private strmFolioEntrada As String = ""
    Private intmDepartamentoNotaCargo As Integer = 0
    Private strmNombreDepartamento As String = ""
    Private strmImporteNeto As String = ""
    Private strmTipoNotaCargo As String = ""


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
    ' Name       : strFormActionParameters
    ' Description: Parametros de regreso
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormActionParameters() As String
        Get
            Return "txtProveedor=" & intProveedorId.ToString & "&rdoTipoNota=" & strTipoNotaCargoNombreId & "&rdoFiltro=" & intTipoFiltro & "&txtFechaInicial=" & dtmFechaInicial & "&txtFechaFinal=" & dtmFechaFinal & "&txtRazonSocialProveedor=" & strRazonSocialProveedor
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
    ' Name       : dtmFechaNotaCargo
    ' Description: Fecha de Nota de Cargo
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property dtmFechaNotaCargo() As String
        Get
            Return dtmmFechaNotaCargo
        End Get
        Set(ByVal strValue As String)
            dtmmFechaNotaCargo = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intProveedorId
    ' Description: Número de proveedor
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intProveedorId() As Integer
        Get
            Return intmProveedorId
        End Get
        Set(ByVal intValue As Integer)
            intmProveedorId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRazonSocialProveedor
    ' Description: Razón Social de proveedor
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRazonSocialProveedor() As String
        Get
            Return strmRazonSocialProveedor
        End Get
        Set(ByVal strValue As String)
            strmRazonSocialProveedor = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strNumeroFactura
    ' Description: Número de Factura
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strNumeroFactura() As String
        Get
            Return strmNumeroFactura
        End Get
        Set(ByVal strValue As String)
            strmNumeroFactura = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strNumeroFactura
    ' Description: Número de Factura
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strFolioEntrada() As String
        Get
            Return strmFolioEntrada
        End Get
        Set(ByVal strValue As String)
            strmFolioEntrada = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intDepartamentoNotaCargo
    ' Description: Número de Departamento
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intDepartamentoNotaCargo() As Integer
        Get
            Return intmDepartamentoNotaCargo
        End Get
        Set(ByVal intValue As Integer)
            intmDepartamentoNotaCargo = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strNombreDepartamento
    ' Description: Nombre de Departamento
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strNombreDepartamento() As String
        Get
            Return strmNombreDepartamento
        End Get
        Set(ByVal strValue As String)
            strmNombreDepartamento = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strImporteNeto
    ' Description: Importe Neto de Nota de Cargo
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strImporteNeto() As String
        Get
            Return strmImporteNeto
        End Get
        Set(ByVal strValue As String)
            strmImporteNeto = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoNotaCargo
    ' Description: Tipo de Nota de Cargo
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strTipoNotaCargo() As String
        Get
            Return strmTipoNotaCargo
        End Get
        Set(ByVal strValue As String)
            strmTipoNotaCargo = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Comando
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Len(Request.QueryString("strCmd")) > 0 Then
                Return Request.QueryString("strCmd")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intDepartamentoId
    ' Description: número de Departamento
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDepartamentoId() As Integer
        Get
            If Len(Request("intDepartamentoId")) > 0 Then
                Return CInt(Request("intDepartamentoId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intNotaCargoProveedorId
    ' Description: número de Proveedor
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intNotaCargoProveedorId() As Integer
        Get
            If Len(Request("intNotaCargoProveedorId")) > 0 Then
                Return CInt(Request("intNotaCargoProveedorId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intNotaCargoId
    ' Description: Nota de cargo
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intNotaCargoId() As Integer
        Get
            If Len(Request("intNotaCargoId")) > 0 Then
                Return CInt(Request("intNotaCargoId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strTipoNotaCargoNombreId
    ' Description: Tipo de Nota de Cargo
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTipoNotaCargoNombreId() As String
        Get
            If Len(Request("strTipoNotaCargoNombreId")) > 0 Then
                Return Request("strTipoNotaCargoNombreId")
            Else
                Return " "
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaInicial
    ' Description: Fecha inicial
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaInicial() As String
        Get
            If Len(Trim(Request("dtmFechaInicial"))) > 0 Then
                Return Trim(Request("dtmFechaInicial"))
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaFinal
    ' Description: Fecha final
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaFinal() As String
        Get
            If Len(Trim(Request("dtmFechaFinal"))) > 0 Then
                Return Trim(Request("dtmFechaFinal"))
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intTipoFiltro
    ' Description: Tipo de Filtro
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTipoFiltro() As Integer
        Get
            If Len(Trim(Request("intTipoFiltro"))) > 0 Then
                Return CInt(Trim(Request("intTipoFiltro")))
            Else
                Return 0
            End If
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

        Dim intPosicionInicial As Integer = 0
        Dim intTipoFiltro As Integer = 0
        Dim intElementos As Integer = 0
        Dim dtmFechaInicial As Date = CDate("01/01/1900")
        Dim dtmFechaFinal As Date = CDate("01/01/1900")


        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strRedirectPage)
        End If

        Select Case strCmd
            Case "Ver"
                Dim objDataArray As Array = Nothing
                Dim objRegistro As String() = Nothing

                ' Traemos informacion de la nota de cargo
                objDataArray = clsConcentrador.clsSucursal.clsMercancia.clsNotasCargo.strBuscaNotasCargo(intCompaniaId, intSucursalId, strTipoNotaCargoNombreId, intNotaCargoId, intNotaCargoProveedorId, dtmFechaInicial, dtmFechaFinal, intDepartamentoId, intTipoFiltro, intPosicionInicial, intElementos, strCadenaConexion)

                If IsArray(objDataArray) Then
                    If objDataArray.Length > 0 Then
                        objRegistro = DirectCast(objDataArray.GetValue(0), String())

                        intProveedorId = CInt(objRegistro(7))
                        strRazonSocialProveedor = objRegistro(8).ToString
                        strNumeroFactura = objRegistro(10).ToString
                        strFolioEntrada = objRegistro(9).ToString
                        intDepartamentoNotaCargo = CInt(objRegistro(5))
                        strNombreDepartamento = objRegistro(6).ToString
                        strImporteNeto = clsCommons.strFormatearNumeroPresentacion(objRegistro(11), True)
                        strTipoNotaCargo = objRegistro(4).ToString

                    End If
                End If


        End Select
    End Sub

End Class
