Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class clsMercanciaArchivoProductosDevueltos
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

    Const strComitasDobles As String = """"

    Private strmRazonSocialProveedor As String = ""
    Private strmRecordBrowser As String = ""

    '====================================================================
    ' Name       : strRedirectPage
    ' Description: Página hacia la cual se debe redireccionar al usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRedirectPage() As String
        Get
            If intCompaniaId > 0 AndAlso intSucursalId > 0 Then
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
    ' Accessor   : Read, Write
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
    ' Name       : strURLPOSAdmin
    ' Description: URL del POS Admin
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strURLPOSAdmin() As String
        Get
            Return clsConcentrador.strObtenerURLSucursal(intCompaniaId, intSucursalId, strCadenaConexion)
        End Get
    End Property
    '====================================================================
    ' Name       : strCmd
    ' Description: Comando a ejecutar
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Not IsNothing(Request.QueryString("strCmd")) Then
                Return (Request.QueryString("strCmd"))
            Else
                Return ""
            End If
        End Get
    End Property
    '====================================================================
    ' Name       : strRazonSocialProveedor
    ' Description: Razon social del proveedor
    ' Parameters : 
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
    ' Name       : strRecordBrowser
    ' Description: REcordBorwser
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRecordBrowser() As String
        Get
            Return strmRecordBrowser
        End Get
        Set(ByVal strValue As String)
            strmRecordBrowser = strValue
        End Set
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
        Dim strHTML As StringBuilder
        Dim objTipoProveedor As Array = Nothing
        Dim objRegistroTipoProveedor As String() = Nothing
        Dim objProveedor As Array = Nothing

        Dim intProveedorId As Integer = 0
        Dim dtmFechaInicio As Date = CDate("01/01/2000")
        Dim dtmFechaFin As Date = CDate("01/01/2000")
        Dim intTipoBusqueda As Integer = 3

        Dim objProductosDevueltos As Array = Nothing

        ' Declaración e inicialización de las variables locales
        Dim strTargetURL As String = "MercanciaDetalleProductosDevueltos.aspx?"

        strRecordBrowser = ""

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        Select Case strCmd

            Case "BuscaProveedor"

                strHTML = New StringBuilder

                Dim objArrayProveedor As Array = Nothing
                Dim objRegistroProveedor As System.Collections.SortedList = Nothing

                Dim strBusquedaProveedorId As String = ""
                Dim strBusquedaProveedorNombreId As String = ""
                Dim strBusquedaProveedorRazonSocial As String = ""
                Dim strBusquedaProveedorRFC As String = ""
                Dim strBusquedaProveedorError As String = "-100"

                If IsNumeric(Mid(Request.Form("txtProveedor"), 4, 4)) Then

                    objArrayProveedor = clsProveedor.strBuscar("", Request.Form("txtProveedor"), 0, 0, strCadenaConexion)

                    If IsArray(objArrayProveedor) AndAlso objArrayProveedor.Length > 0 Then

                        objRegistroProveedor = DirectCast(objArrayProveedor.GetValue(0), System.Collections.SortedList)

                        ' Asignamos los datos del proveedor

                        strBusquedaProveedorId = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("intProveedorId")))
                        strBusquedaProveedorNombreId = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorNombreId")))
                        strBusquedaProveedorRazonSocial = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorRazonSocial")))
                        strBusquedaProveedorRFC = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorRFC")))
                        strBusquedaProveedorError = "0"

                    End If

                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpBuscarProveedor( " & _
                               strComitasDobles & strBusquedaProveedorId & strComitasDobles & "," & _
                               strComitasDobles & strBusquedaProveedorNombreId & strComitasDobles & "," & _
                               strComitasDobles & strBusquedaProveedorRazonSocial & strComitasDobles & "," & _
                               strComitasDobles & strBusquedaProveedorRFC & strComitasDobles & "," & _
                               strComitasDobles & strBusquedaProveedorError & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "Consultar"

                If Request.Form("rdoConsulta") = "1" Then
                    intProveedorId = CInt(Request.Form("hdnProveedorId"))
                    intTipoBusqueda = 1
                End If

                If Request.Form("rdoConsulta") = "2" Then
                    dtmFechaInicio = CDate(clsCommons.strDMYtoMDY(Trim(Request.Form("txtFechaInicio"))))
                    dtmFechaFin = CDate(clsCommons.strDMYtoMDY(Trim(Request.Form("txtFechaFin"))))
                    intTipoBusqueda = 2
                End If

                objProductosDevueltos = clsConcentrador.clsSucursal.clsMercancia.clsDevolucion.strBuscar(intCompaniaId, intSucursalId, 0, intTipoBusqueda, intProveedorId, dtmFechaInicio, dtmFechaFin, 0, 0, strCadenaConexion)

                If IsArray(objProductosDevueltos) AndAlso objProductosDevueltos.Length > 0 Then
                    ' Generamos el Navegador de Registros
                    strRecordBrowser = clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaArchivoProductosDevueltos", objProductosDevueltos, 1, objProductosDevueltos.Length, strTargetURL))
                End If

        End Select

    End Sub

End Class
