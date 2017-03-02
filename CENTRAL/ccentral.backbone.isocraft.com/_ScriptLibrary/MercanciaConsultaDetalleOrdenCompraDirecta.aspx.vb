Imports Isocraft.Web.Http
Imports System.Text
Imports System.Configuration

Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business

Public Class MercanciaConsultaDetalleOrdenCompraDirecta
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

        'Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strRedirectPage)
        End If

    End Sub

#End Region

#Region " Class Private Attributes"

    Const strComitasDobles As String = """"
    Private strmJavascriptWindowOnLoadCommands As String
    Private intmArticulosListaOrdenSugerida As Integer = 0

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


    '====================================================================
    ' Name       : intFolioOrdenId
    ' Description: numero de orden a Buscar
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intFolioOrdenId() As Integer
        Get
            If Not IsNothing(Request("intFolioOrdenId")) Then
                If IsNumeric(Request("intFolioOrdenId")) Then
                    Return CInt(Request("intFolioOrdenId"))
                Else
                    Return 0
                End If

            Else
                Return 0
            End If
        End Get
    End Property

    Public Function strTituloConsulta() As String

        Return clsCommons.strGenerateJavascriptString("Proveedor: " & strProveedorNombreId & " - " & strProveedorRazonSocial & "<BR>" & "Orden: " & intFolioOrdenId.ToString)

    End Function



    '====================================================================
    ' Name       : strGeneraDetalleOrdenCompra
    ' Description: Genera el Record Browser a desplegar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strGeneraDetalleOrdenCompra(ByVal objDetalleOrdenCompra As Array) As String

        Dim strRegistroOrdenes As System.Collections.SortedList = Nothing

        Dim strColorRegistro As String = ""
        Dim intRenglon As Integer = 0
        Dim strHTML As New StringBuilder

        strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        strHTML.Append("<tr class='trtitulos'>")
        strHTML.Append("<th align='left'  width='15%' class='rayita'>No.</th>")
        strHTML.Append("<th align='left'  width='15%' class='rayita'>Código</th>")
        strHTML.Append("<th align='left'  width='55%' class='rayita'>Descripción</th>")
        strHTML.Append("<th align='right' width='15%' class='rayita'>Cantidad</th>")
        strHTML.Append("</tr>")

        If IsArray(objDetalleOrdenCompra) AndAlso (objDetalleOrdenCompra.Length > 0) Then

            For Each strRegistroOrdenes In objDetalleOrdenCompra

                intRenglon += 1

                If ((intRenglon Mod 2) = 0) Or (intRenglon = 0) Then
                    strColorRegistro = "tdceleste"
                Else
                    strColorRegistro = "tdblanco"
                End If

                strHTML.Append("<tr>")

                'No. de Renglon
                strHTML.Append("<td align='left' class='" & strColorRegistro & "'>" & intRenglon.ToString & "&nbsp;</td>")

                ' intArticuloId
                strHTML.Append("<td align='left' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(strRegistroOrdenes.Item("intArticuloId"))) & "</td>")

                ' strArticuloDescripcion
                strHTML.Append("<td align='left' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(strRegistroOrdenes.Item("strArticuloDescripcion"))) & "</td>")

                ' intArticuloCantidad
                strHTML.Append("<td align='right' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(strRegistroOrdenes.Item("intArticuloCantidad"))) & "</td>")

                strHTML.Append("</tr>")
            Next

        Else
            strHTML.Append("<tr>")
            strHTML.Append("<td class='tdblanco' colspan='4'>No hay registros</td>")
            strHTML.Append("</tr>")
        End If

        strHTML.Append("</table>")
        strHTML.Append("<br>")

        Return strHTML.ToString

    End Function

    Public ReadOnly Property intRenglonesxPagina() As Integer
        Get
            Return 46
        End Get
    End Property

    Private Function strImprimeEncabezado(ByVal strHojaActual As String, ByVal strHojaFinal As String, _
                                      ByVal strNumeroProveedor As String, _
                                      ByVal strNombreProveedor As String) As String

        Dim strHtmlEncabezado As StringBuilder

        strHtmlEncabezado = New StringBuilder


        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th align='left'   colspan='2'  class='tdblancoSinRaya'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th align='center' colspan='2'  class='tdblancoSinRaya' nowrap>" & strSucursalNombre & "</th>")
        strHtmlEncabezado.Append("<th align='right'  class='tdblancoSinRaya'>HOJA " & strHojaActual & " / " & strHojaFinal & "</th>")
        strHtmlEncabezado.Append("</tr>")

        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th align='center' colspan='6'  class='tdblancoSinRaya'>ORDEN DE COMPRA SUGERIDA</th>")
        strHtmlEncabezado.Append("</tr>")


        '3 Nombre Proveedor
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th align='left' colspan='5'  class='tdblancoSinRaya'>Proveedor: " & strNumeroProveedor & "&nbsp;&nbsp;" & strNombreProveedor & "</th>")
        strHtmlEncabezado.Append("</tr>")

        'Titulos
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th width='24'  class='tdblancoSinRaya'>" & "No." & "</th>")
        strHtmlEncabezado.Append("<th width='54'  class='tdblancoSinRaya'>" & "Código" & "</th>")
        strHtmlEncabezado.Append("<th width='300' class='tdblancoSinRaya'>" & "Descripción" & "</th>")
        strHtmlEncabezado.Append("<th width='72'  class='tdblancoSinRaya'>" & "Cantidad Sugerida" & "</th>")
        strHtmlEncabezado.Append("<th width='96'  class='tdblancoSinRaya'>" & "Cantidad Surtida" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola

        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th width='24'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='54'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='300' class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='72'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='96'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")


        strImprimeEncabezado = strHtmlEncabezado.ToString

    End Function

    '====================================================================
    ' Name       : strGeneraImpresionOrdenCompra
    ' Description: Genera el Record Browser a desplegar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strGeneraImpresionOrdenCompra(ByVal objDetalleOrdenCompra As Array) As String

        Dim strRegistroOrdenes As System.Collections.SortedList = Nothing
        Dim strImpresionOrdenesHTML As New StringBuilder
        Dim strColorRegistro As String = ""

        If IsArray(objDetalleOrdenCompra) AndAlso (objDetalleOrdenCompra.Length > 0) Then

            Dim intTotalRenglones As Integer = objDetalleOrdenCompra.Length
            Dim intTotalPaginas As Integer = 0

            Dim intPagina As Integer = 0
            Dim intRenglon As Integer = 0
            Dim intContadorRenglon As Integer = 0

            intTotalPaginas = intTotalRenglones \ intRenglonesxPagina

            If intTotalRenglones Mod intRenglonesxPagina > 0 Then
                intTotalPaginas += 1
            Else
                intTotalPaginas = 1
            End If


            intRenglon = 0
            intPagina = 0
            intContadorRenglon = 0

            For Each strRegistroOrdenes In objDetalleOrdenCompra

                intRenglon += 1
                intContadorRenglon += 1

                If intRenglon = 1 Then

                    intPagina += 1

                    If intPagina > 1 Then
                        strImpresionOrdenesHTML.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")
                    End If

                    strImpresionOrdenesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    strImpresionOrdenesHTML.Append(strImprimeEncabezado(intPagina.ToString, intTotalPaginas.ToString, strProveedorNombreId, strProveedorRazonSocial))
                End If

                If ((intRenglon Mod 2) = 0) Then
                    strColorRegistro = "tdtxtImpresionNormal"
                Else
                    strColorRegistro = "tdtxtImpresionBold"
                End If

                strImpresionOrdenesHTML.Append("<tr>")

                'No. de Renglon
                strImpresionOrdenesHTML.Append("<td align='left' class='" & strColorRegistro & "'>" & intRenglon.ToString & "&nbsp;</td>")

                ' intArticuloId
                strImpresionOrdenesHTML.Append("<td align='left' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(strRegistroOrdenes.Item("intArticuloId"))) & "</td>")

                ' strArticuloDescripcion
                strImpresionOrdenesHTML.Append("<td align='left' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(strRegistroOrdenes.Item("strArticuloDescripcion"))) & "</td>")

                ' intArticuloCantidad
                strImpresionOrdenesHTML.Append("<td align='right' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(strRegistroOrdenes.Item("intArticuloCantidad"))) & "</td>")

                'a Surtir
                strImpresionOrdenesHTML.Append("<td align='right' class'" & strColorRegistro & "'>" & "____________</td>")


                strImpresionOrdenesHTML.Append("</tr>")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionOrdenesHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next

        Else
            strImpresionOrdenesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")
            strImpresionOrdenesHTML.Append(strImprimeEncabezado("1", "1", strProveedorNombreId, strProveedorRazonSocial))
            strImpresionOrdenesHTML.Append("<tr>")
            strImpresionOrdenesHTML.Append("<td class='tdblanco' colspan='5'>No hay registros</td>")
            strImpresionOrdenesHTML.Append("</tr>")
            strImpresionOrdenesHTML.Append("</table>")
        End If

        Return strImpresionOrdenesHTML.ToString

    End Function

    Public strDetalleOrdenCompra As String
    Public strImpresionOrdenCompra As String


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objDetalleOrdenCompra As Array = clsConcentrador.clsSucursal.clsMercancia.clsCompras.strBuscarOrdenDetalle(intCompaniaId, intSucursalId, intProveedorId, intFolioOrdenId, strCadenaConexion)

        strDetalleOrdenCompra = strGeneraDetalleOrdenCompra(objDetalleOrdenCompra)
        strImpresionOrdenCompra = strGeneraImpresionOrdenCompra(objDetalleOrdenCompra)


    End Sub

End Class
