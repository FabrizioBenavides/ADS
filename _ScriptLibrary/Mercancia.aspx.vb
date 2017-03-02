Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class clsMercancia
    Inherits System.Web.UI.Page

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
    ' Name       : intDevolucionId
    ' Description: Valor de la transferencia.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDevolucionId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intDevolucionId")) Then
                Return CInt(Request.QueryString("intDevolucionId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intFolio
    ' Description: Valor del folio.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intFolioId() As Integer
        Get
            If Len(Request.QueryString("intFolioId")) > 0 Then
                Return CInt(Request.QueryString("intFolioId"))
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intFolio
    ' Description: Valor del folio.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property dtmFecha() As String
        Get
            Return Request.QueryString("dtmFecha")
        End Get
    End Property

    '====================================================================
    ' Name       : strRemisionesHTML
    ' Description: Valor que tomara la variable strRemisionesHTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRemisionesHTML() As String
        Get

            Dim intContador As Integer = 0
            Dim strColorRegistro As String = ""

            Dim objArrayRemisionesElectronicas As Array = Nothing
            Dim objRegistroRemisionesElectronicas As System.Collections.SortedList = Nothing

            Dim strbldRemisiones As New StringBuilder

            ' Hacemos la consulta de la información del cliene especial.
            objArrayRemisionesElectronicas = clsConcentrador.clsSucursal.clsMercancia.clsRemisionElectronica.strBuscarRemisionProveedor(intCompaniaId, intSucursalId, 0, 0, 0, strCadenaConexion)


            strbldRemisiones.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strbldRemisiones.Append("<tr class='trtitulos'>")
            strbldRemisiones.Append("<th width='55' class='rayita'>C&oacute;digo</th>")
            strbldRemisiones.Append("<th width='128' class='rayita'>Proveedor</th>")
            strbldRemisiones.Append("</tr>")

            ' Validamos si trae información para mostrarla
            If IsArray(objArrayRemisionesElectronicas) AndAlso objArrayRemisionesElectronicas.Length > 0 Then

                For Each objRegistroRemisionesElectronicas In objArrayRemisionesElectronicas

                    intContador += 1

                    If (intContador Mod 2) <> 0 Then
                        strColorRegistro = "'tdceleste'"
                    Else
                        strColorRegistro = "'tdblanco'"
                    End If

                    strbldRemisiones.Append("<tr>")
                    strbldRemisiones.Append("<td class=" & strColorRegistro & ">")
                    strbldRemisiones.Append("<a href='MercanciaRemisionPorConfirmar.aspx?strCmd=VerTodo&intProveedorId=")
                    strbldRemisiones.Append(CStr(objRegistroRemisionesElectronicas.Item("intProveedorId")))
                    strbldRemisiones.Append("' class='txaccion' target='_top'>")
                    strbldRemisiones.Append(CStr(objRegistroRemisionesElectronicas.Item("strProveedorNombreId")))
                    strbldRemisiones.Append("</a>")
                    strbldRemisiones.Append("</td>")
                    strbldRemisiones.Append("<td class=" & strColorRegistro & ">")
                    strbldRemisiones.Append(CStr(objRegistroRemisionesElectronicas.Item("strProveedorRazonSocial")))
                    strbldRemisiones.Append("</td>")
                    strbldRemisiones.Append("</tr>")

                Next

            End If

            strbldRemisiones.Append("</table>")


            Return strbldRemisiones.ToString
        End Get
    End Property

    '====================================================================
    ' Name       : strFacturasHTML
    ' Description: Valor que tomara la variable strFacturasHTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFacturasHTML() As String
        Get

            Dim intContador As Integer = 0
            Dim strColorRegistro As String = ""

            Dim objArrayFacturasElectronicas As Array = Nothing
            Dim objRegistroFacturasElectronicas As System.Collections.SortedList = Nothing

            Dim strbldFacturas As New StringBuilder

            ' Hacemos la consulta de la información del cliene especial.
            objArrayFacturasElectronicas = clsConcentrador.clsSucursal.clsMercancia.clsFacturaElectronica.strBuscarProveedor(intCompaniaId, intSucursalId, 0, 0, 0, strCadenaConexion)

            strbldFacturas.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strbldFacturas.Append("<tr class='trtitulos'>")
            strbldFacturas.Append("<th width='55' class='rayita'>C&oacute;digo</th>")
            strbldFacturas.Append("<th width='128' class='rayita'>Proveedor</th>")
            strbldFacturas.Append("</tr>")

            ' Validamos si trae información para mostrarla
            If IsArray(objArrayFacturasElectronicas) AndAlso objArrayFacturasElectronicas.Length > 0 Then

                For Each objRegistroFacturasElectronicas In objArrayFacturasElectronicas

                    intContador += 1

                    If (intContador Mod 2) <> 0 Then
                        strColorRegistro = "'tdceleste'"
                    Else
                        strColorRegistro = "'tdblanco'"
                    End If

                    strbldFacturas.Append("<tr>")
                    strbldFacturas.Append("<td class=" & strColorRegistro & ">")
                    strbldFacturas.Append("<a href='MercanciaFacturasPorConfirmar.aspx?strCmd=VerTodo&intProveedorId=")
                    strbldFacturas.Append(CStr(objRegistroFacturasElectronicas.Item("intProveedorId")))
                    strbldFacturas.Append("' class='txaccion' target='_top'>")
                    strbldFacturas.Append(CStr(objRegistroFacturasElectronicas.Item("strProveedorNombreId")))
                    strbldFacturas.Append("</a>")
                    strbldFacturas.Append("</td>")
                    strbldFacturas.Append("<td class=" & strColorRegistro & ">")
                    strbldFacturas.Append(CStr(objRegistroFacturasElectronicas.Item("strProveedorRazonSocial")))
                    strbldFacturas.Append("</td>")
                    strbldFacturas.Append("</tr>")

                Next

            End If

            strbldFacturas.Append("</table>")


            Return strbldFacturas.ToString


        End Get

    End Property

    '====================================================================
    ' Name       : strEnviosHTML
    ' Description: Valor que tomara la variable strEnviosHTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strEnviosHTML() As String
        Get

            Dim strbldEnvios As StringBuilder
            Dim objEnvios As Array = Nothing
            Dim strEnvios As String() = Nothing
            Dim intContador As Integer = 0
            Dim intMod As Integer = 0
            Dim strColortd As String = "tdceleste"

            strbldEnvios = New StringBuilder

            ' Hacemos la consulta de la información del cliene especial.
            objEnvios = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.strBuscar(intCompaniaId, intSucursalId, 0, "GENERADA", True, 0, 0, strCadenaConexion)

            strbldEnvios.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strbldEnvios.Append("  <tr class='trtitulos'>")
            strbldEnvios.Append("    <th width='59' class='rayita'>No. Orden</th>")
            strbldEnvios.Append("    <th width='56' class='rayita'>Destino</th>")
            strbldEnvios.Append("    <th width='74' class='rayita'>Fecha</th>")
            strbldEnvios.Append("  </tr>")

            ' Validamos si trae información para mostrarla
            If IsArray(objEnvios) AndAlso objEnvios.Length > 0 Then

                strEnvios = DirectCast(objEnvios.GetValue(0), String())

                ' Barremos el arreglo para ir formando los campos a mostrar en la página HTML
                For intContador = 0 To objEnvios.Length - 1

                    strEnvios = Nothing
                    strEnvios = DirectCast(objEnvios.GetValue(intContador), String())

                    intMod = intContador Mod 2
                    If intMod = 0 Then
                        strColortd = "tdceleste"
                    Else
                        strColortd = "tdblanco"
                    End If

                    strbldEnvios.Append("  <tr>")
                    strbldEnvios.Append("    <td class='" & strColortd & "'><a href='MercanciaConfirmarEnvioProductos.aspx?intTransferenciaId=" & strEnvios(0) & "&intCompaniaEnvioId=" & strEnvios(7) & "&intSucursalEnvioId=" & strEnvios(8) & "' class='txaccion'>" & strEnvios(1) & "</a></td>")
                    strbldEnvios.Append("    <td class='" & strColortd & "'>" & strEnvios(7) & "-" & strEnvios(8) & "</td>")
                    strbldEnvios.Append("    <td class='" & strColortd & "'>" & clsCommons.strDMYtoMDY(strEnvios(2)) & "</td>")
                    strbldEnvios.Append("  </tr>")

                Next

            End If

            strbldEnvios.Append("</table>")

            strEnviosHTML = strbldEnvios.ToString

            Return strEnviosHTML
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
            Call Response.Redirect(strRedirectPage)
        End If

    End Sub

End Class
