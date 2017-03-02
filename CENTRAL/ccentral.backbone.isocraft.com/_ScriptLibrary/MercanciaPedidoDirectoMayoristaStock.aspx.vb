Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Business.clsConcentrador.clsSucursal.clsMercancia
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class clsMercanciaPedidoDirectoMayoristaStock
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


#Region " Class Private Attributes"

    Const strComitasDobles As String = """"

    Private strmParametros As String = ""
    Private strmErrorBuscarArticulo As String = ""


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
    ' Name       : strFormActionParameters
    ' Description: Parametros utilizados
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormActionParameters() As String
        Get
            Return ""
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

    Public Property strErrorBuscarArticulo() As String
        Get
            Return strmErrorBuscarArticulo
        End Get
        Set(ByVal Value As String)
            strmErrorBuscarArticulo = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowseStockArticuloHTML
    ' Description: Genera Record Browser
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowseStockArticuloHTML() As String

        Dim objStockArticuloPedidoCompraDirecta As Array = Nothing
        Dim objRegistroStockArticuloPedidoCompraDirecta As System.Collections.SortedList = Nothing

        Dim strHTML As StringBuilder
        Dim intConsecutivo As Integer = 0
        Dim strColorRegistro As String = ""
        Dim strColorTabla As String = ""

        Dim intArticuloAnterior As Integer = 0
        Dim intArticuloNuevo As Integer = 0

        strHTML = New StringBuilder

        strHTML.Append("")

        objStockArticuloPedidoCompraDirecta = clsCompras.clsPedido.strBuscarStock(intCompaniaId, intSucursalId, strArticuloCapturado, strCadenaConexion)

        If IsArray(objStockArticuloPedidoCompraDirecta) AndAlso objStockArticuloPedidoCompraDirecta.Length > 0 Then

            strErrorBuscarArticulo = "0"

            For Each objRegistroStockArticuloPedidoCompraDirecta In objStockArticuloPedidoCompraDirecta

                intArticuloNuevo = CInt(objRegistroStockArticuloPedidoCompraDirecta.Item("intArticuloId"))

                If intArticuloAnterior <> intArticuloNuevo Then

                    If intArticuloAnterior <> 0 Then
                        strHTML.Append("</table>")
                        strHTML.Append("<br>")
                        strHTML.Append("<br>")
                    End If

                    strColorRegistro = "'tdblanco'"
                    strColorTabla = "'tdenvolventetablablanco'"

                    intArticuloAnterior = intArticuloNuevo

                    strHTML.Append("<table class=" & strColorTabla & " width='100%' border='0' cellpadding='0' cellspacing='0'>")
                    strHTML.Append("<tr>")
                    strHTML.Append("<td class='tdtittablasazul' align='left' width='10%' colspan='6'>" & CStr(objRegistroStockArticuloPedidoCompraDirecta.Item("intArticuloId")) & " - " & CStr(objRegistroStockArticuloPedidoCompraDirecta.Item("strArticuloDescripcion")) & "</td>")
                    strHTML.Append("</tr>")
                    strHTML.Append("<tr>")
                    strHTML.Append("<td class='tdtittablas3' align='left' width='10%'>Estado</td>")
                    strHTML.Append("<td class='tdtittablasazul' vAlign='middle' width='30%'>" & CStr(objRegistroStockArticuloPedidoCompraDirecta.Item("strClaveVigenciaArticuloNombre")) & "</td>")
                    strHTML.Append("<td class='tdtittablas3' align='left' width='10%'>Estacionalidad</td>")
                    strHTML.Append("<td class='tdtittablasazul' vAlign='middle' width='30%'>" & CStr(objRegistroStockArticuloPedidoCompraDirecta.Item("strEstacionalidadArticuloDescripcion")) & "</td>")
                    strHTML.Append("<td class='tdtittablas3' align='left' width='10%' valign='top'>Abastos</td>")
                    strHTML.Append("<td class='tdtittablasazul' vAlign='top' width='30%' >" & CStr(objRegistroStockArticuloPedidoCompraDirecta.Item("strTipoAbastoArticuloDescripcion")) & "</td>")
                    strHTML.Append("</tr>")
                    strHTML.Append("</table>")

                    strHTML.Append("<table class=" & strColorTabla & " width='100%' border='0' cellpadding='0' cellspacing='0'>")
                    strHTML.Append("<tr class='trtitulos'>")
                    strHTML.Append("<th width='20%' class='rayita' align='left'>Proveedor</th>")
                    strHTML.Append("<th width='60%' class='rayita' align='left'>Razon Social</th>")
                    strHTML.Append("<th width='20%' class='rayita' align='left'>Stock</th>")
                    strHTML.Append("</tr>")
                End If

                strHTML.Append("<tr>")
                strHTML.Append("<td class=" & strColorRegistro & " align='left'>" & CStr(objRegistroStockArticuloPedidoCompraDirecta.Item("strProveedorId")) & "</td>") ' strProveedorId
                strHTML.Append("<td class=" & strColorRegistro & " align='left'>" & CStr(objRegistroStockArticuloPedidoCompraDirecta.Item("strProveedorRazonSocial")) & "</td>") ' strProveedorRazonSocial
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & CStr(objRegistroStockArticuloPedidoCompraDirecta.Item("strStockCantidad")) & "</td>") ' strStockCantidad
                strHTML.Append("</tr>")

            Next

            strHTML.Append("</table>")

        Else
            strErrorBuscarArticulo = "-100"
        End If

        Return strHTML.ToString

    End Function

    '====================================================================
    ' Name       : strArticuloCapturado
    ' Description: Cadena para buscar el numero de articulo
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strArticuloCapturado() As String
        Get
            If Not IsNothing(Request("txtArticuloId")) Then
                Return Request("txtArticuloId")
            Else
                Return ""
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

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin & strRedirectPage)
        End If


        Dim strHTML As StringBuilder

        Select Case strCmd


            Case "BuscarArticulo"

                strHTML = New StringBuilder

                strHTML.Append("<script language='Javascript'> parent.fnUpdArticuloPorIframe( " & _
                                strComitasDobles & strRecordBrowseStockArticuloHTML.ToString & strComitasDobles & "," & _
                                strComitasDobles & strErrorBuscarArticulo & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

        End Select

    End Sub

End Class
