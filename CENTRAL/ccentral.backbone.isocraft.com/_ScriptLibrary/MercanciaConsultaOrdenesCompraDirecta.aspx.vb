Imports Isocraft.Web.Http
Imports System.Text
Imports System.Configuration

Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business

Public Class MercanciaConsultaOrdenesCompraDirecta
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
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strRedirectPage)
        End If

    End Sub

#End Region
#Region " Class Private Attributes"

    Const strComitasDobles As String = """"
    Private strmJavascriptWindowOnLoadCommands As String


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
    ' Name       : intProveedorId
    ' Description: Proveedor a Buscar
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intProveedorId() As Integer
        Get
            If Not IsNothing(Request("intProveedorId")) Then
                If IsNumeric(Request("intProveedorId")) Then
                    Return CInt(Request("intProveedorId"))
                Else
                    Return 0
                End If

            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strProveedorNombreId
    ' Description: Nombre iD del Proveedor de la Orden Sugerida
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strProveedorNombreId() As String
        Get
            If Not IsNothing(Request("strProveedorNombreId")) Then
                Return Request("strProveedorNombreId")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strProveedorRazonSocial
    ' Description: Nombre del Proveedor de la Orden Sugerida
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strProveedorRazonSocial() As String
        Get
            If Not IsNothing(Request("strProveedorRazonSocial")) Then
                Return Request("strProveedorRazonSocial")
            Else
                Return ""
            End If
        End Get
    End Property

    Public Function strTituloConsulta() As String

        Return clsCommons.strGenerateJavascriptString("Proveedor: " & strProveedorNombreId & " - " & strProveedorRazonSocial)

    End Function

    Public strOrdenesCompra As String


    '====================================================================
    ' Name       : strVistaOrdenCompra
    ' Description: Genera el Record Browser a desplegar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strGeneraOrdenesCompra(ByVal objOrdenesCompra As Array) As String

        Dim strRegistroOrdenes As System.Collections.SortedList = Nothing

        Dim strColorRegistro As String = ""
        Dim intRenglon As Integer = 0
        Dim strHTML As New StringBuilder

        strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strHTML.Append("<tr class='trtitulos'>")
        strHTML.Append("<th align='left' width='15%' class='rayita'>No.</th>")
        strHTML.Append("<th align='left' width='30%' class='rayita'>Orden</th>")
        strHTML.Append("<th align='left' width='30%' class='rayita'>Fecha</th>")
        strHTML.Append("<th align='left' width='15%' class='rayita'>Piezas</th>")
        strHTML.Append("<th align='left' width='10%' class='rayita'>Ver</th>")
        strHTML.Append("</tr>")

        If IsArray(objOrdenesCompra) AndAlso (objOrdenesCompra.Length > 0) Then

            For Each strRegistroOrdenes In objOrdenesCompra

                intRenglon += 1

                If ((intRenglon Mod 2) = 0) Or (intRenglon = 0) Then
                    strColorRegistro = "tdceleste"
                Else
                    strColorRegistro = "tdblanco"
                End If

                strHTML.Append("<tr>")
                'No. de Renglon
                strHTML.Append("<td align='left' class='" & strColorRegistro & "'>" & intRenglon.ToString & "&nbsp;</td>")

                strHTML.Append("<td align='left' class=" & strColorRegistro & ">")
                strHTML.Append("<a class='txaccion' href=\""javascript:ClosePopup('")
                strHTML.Append(CStr(strRegistroOrdenes.Item("intFolioOrdenId")) & "')\"">")
                strHTML.Append(CStr(strRegistroOrdenes.Item("intFolioOrdenId")))
                strHTML.Append("</a>")
                strHTML.Append("</td>")

                strHTML.Append("<td align='left' class='" & strColorRegistro & "'>" & clsCommons.strFormatearFechaPresentacion(CStr(strRegistroOrdenes.Item("dtmFechaOrden"))).ToString & "</td>")
                strHTML.Append("<td align='left' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(strRegistroOrdenes.Item("intCantidadArticulos"))).ToString & "</td>")

                strHTML.Append("<td align='left' class=" & strColorRegistro & ">")
                strHTML.Append("<a class='txaccion' href=\""javascript:cmdVerDetalleOrden('")
                strHTML.Append(CStr(strRegistroOrdenes.Item("intFolioOrdenId")) & "')\"">")
                strHTML.Append("<img src='../static/images/icono_detalle.gif' width='13' height='13' align='absmiddle' alt='Haga clic aquí para ver el detalle de la orden' border='0'>")
                strHTML.Append("</a>")
                strHTML.Append("</td>")

                strHTML.Append("</tr>")
            Next

        Else
            strHTML.Append("<tr>")
            strHTML.Append("<td class='tdblanco' colspan='5'>No hay registros</td>")
            strHTML.Append("</tr>")
        End If

        strHTML.Append("</table>")
        strHTML.Append("<br>")

        Return strHTML.ToString

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here


        strOrdenesCompra = strGeneraOrdenesCompra(clsConcentrador.clsSucursal.clsMercancia.clsCompras.strBuscarOrdenes(intCompaniaId, intSucursalId, intProveedorId, strCadenaConexion))



    End Sub

End Class
