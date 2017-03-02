Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration


Public Class CompraDirectaMostrarOrdenSugerida
    Inherits System.Web.UI.Page


    Private intmArticulosListaOrdenSugerida As Integer = 0
    Public strListaOrdenSugerida As String = ""
    Public strImpresionOrdenSugerida As String = ""


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



    Public ReadOnly Property intRenglonesxPagina() As Integer
        Get
            Return 46
        End Get
    End Property

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
    ' Description: string de Comandos de control
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Not IsNothing(Request.QueryString("strCmd")) Then
                Return Request.QueryString("strCmd")
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
    ' Name       : intArticulosListaOrdenSugerida
    ' Description: Indica el numero de Articulos en la Orden Sugerida
    ' Accessor   : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intArticulosListaOrdenSugerida() As Integer
        Get
            Return intmArticulosListaOrdenSugerida
        End Get
        Set(ByVal Value As Integer)
            intmArticulosListaOrdenSugerida = Value

        End Set
    End Property

    '====================================================================
    ' Name       : strGeneraListaBultos
    ' Description: Genera el Record Browser con los Bultos capturados 
    '              en la transferencia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strGeneraListaOrdenSugerida(ByVal objArrayOrden As Array) As String

        Dim strRegistroOrden As String() = Nothing

        Dim strHTML As StringBuilder
        Dim strClass As String
        Dim strComilla As String = """"

        Dim intRenglon As Integer = 0

        strHTML = New StringBuilder


        If IsArray(objArrayOrden) AndAlso (objArrayOrden.Length > 0) Then
            strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strHTML.Append("<tr class='trtitulos'>")
            strHTML.Append("<th width='25' class='rayita'>No.</th>")
            strHTML.Append("<th width='25' class='rayita'>Código</th>")
            strHTML.Append("<th width='80' class='rayita'>Descripción</th>")
            strHTML.Append("<th align='right' width='60' class='rayita'>Inv. Teórico</th>")
            strHTML.Append("<th align='right' width='60' class='rayita'>Can. Sugerida</th>")
            strHTML.Append("</tr>")

            For Each strRegistroOrden In objArrayOrden

                intRenglon += 1

                If ((intRenglon Mod 2) = 0) Or (intRenglon = 0) Then
                    strClass = "tdceleste"
                Else
                    strClass = "tdblanco"
                End If

                strHTML.Append("<tr>")
                'No. de Renglon
                strHTML.Append("<td class='" & strClass & "'>" & intRenglon.ToString & "&nbsp;</td>")

                ' intArticuloId
                strHTML.Append("<td class='" & strClass & "'>" & clsCommons.strFormatearDescripcion(strRegistroOrden(0)).ToString & "</td>")

                ' strArticuloDescripcion
                strHTML.Append("<td class='" & strClass & "'>" & Mid(clsCommons.strFormatearDescripcion(strRegistroOrden(1)).ToString, 1, 32) & "</td>")

                ' Teorico
                strHTML.Append("<td align='right' class='" & strClass & "'>" & clsCommons.strFormatearDescripcion(strRegistroOrden(6)).ToString & "</td>")

                ' CantidadSugerida
                strHTML.Append("<td align='right' class='" & strClass & "'>" & clsCommons.strFormatearDescripcion(strRegistroOrden(8)).ToString & "</td>")


                strHTML.Append("</tr>")
            Next
            strHTML.Append("</table>")
            strHTML.Append("<br>")

        End If

        intArticulosListaOrdenSugerida = intRenglon
        strGeneraListaOrdenSugerida = clsCommons.strGenerateJavascriptString(strHTML.ToString)

    End Function

    Private Function strGeneraImpresionOrdenSugerida(ByVal objArrayOrdenesSugeridas As Array) As String
        Dim strImpresionOrdenesHTML As StringBuilder = New StringBuilder
        Dim strRegistroOrden As String()
        Dim strclase As String = ""

        If IsArray(objArrayOrdenesSugeridas) AndAlso (objArrayOrdenesSugeridas.Length > 0) Then

            Dim intTotalRenglones As Integer = objArrayOrdenesSugeridas.Length
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

            For Each strRegistroOrden In objArrayOrdenesSugeridas
                intRenglon += 1
                intContadorRenglon += 1

                If intRenglon = 1 Then
                    intPagina += 1

                    If intPagina > 1 Then
                        strImpresionOrdenesHTML.Append("<p class='breakhere'></p>")
                    End If

                    strImpresionOrdenesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    strImpresionOrdenesHTML.Append(strImprimeEncabezado(intPagina.ToString, intTotalPaginas.ToString, strProveedorNombreId, strProveedorRazonSocial))
                End If

                If ((intRenglon Mod 2) = 0) Then
                    strclase = "tdtxtImpresionNormal"
                Else
                    strclase = "tdtxtImpresionBold"
                End If


                strImpresionOrdenesHTML.Append("<tr>")

                'No. de Renglon
                strImpresionOrdenesHTML.Append("<td align='right' class='" & strclase & "' nowrap>" & clsCommons.strFormatearDescripcion(intContadorRenglon.ToString) & "</td>")

                ' intArticuloId
                strImpresionOrdenesHTML.Append("<td align='right' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroOrden(0)).ToString & "</td>")

                ' strArticuloDescripcion
                strImpresionOrdenesHTML.Append("<td class='" & strclase & "' nowrap >" & Mid(clsCommons.strFormatearDescripcion(strRegistroOrden(1)).ToString, 1, 32) & "</td>")

                ' Teorico
                strImpresionOrdenesHTML.Append("<td align='right' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroOrden(6)).ToString & "</td>")

                ' CantidadSugerida
                strImpresionOrdenesHTML.Append("<td align='right' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroOrden(8)).ToString & "</td>")

                'CantidadSurtida
                strImpresionOrdenesHTML.Append("<td align='right' class'" & strclase & "'>" & "____________</td>")

                strImpresionOrdenesHTML.Append("</tr>")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionOrdenesHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next

        End If

        Return strImpresionOrdenesHTML.ToString()

    End Function

    Private Function strImprimeEncabezado(ByVal strHojaActual As String, ByVal strHojaFinal As String, _
                                          ByVal strNumeroProveedor As String, _
                                          ByVal strNombreProveedor As String) As String

        Dim strHtmlEncabezado As StringBuilder

        strHtmlEncabezado = New StringBuilder



        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th align='left'   colspan='2'  class='tdblancoSinRaya'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th align='center' colspan='3'  class='tdblancoSinRaya' nowrap>" & strSucursalNombre & "</th>")
        strHtmlEncabezado.Append("<th align='right'  class='tdblancoSinRaya'>HOJA " & strHojaActual & " / " & strHojaFinal & "</th>")
        strHtmlEncabezado.Append("</tr>")

        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th align='center' colspan='6'  class='tdblancoSinRaya'>ORDEN DE COMPRA SUGERIDA</th>")
        strHtmlEncabezado.Append("</tr>")


        '3 Nombre Proveedor
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th align='left' colspan='6'  class='tdblancoSinRaya'>Proveedor: " & strNumeroProveedor & "&nbsp;&nbsp;" & strNombreProveedor & "</th>")
        strHtmlEncabezado.Append("</tr>")

        'Titulos
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th width='24'  class='tdblancoSinRaya'>" & "No." & "</th>")
        strHtmlEncabezado.Append("<th width='54'  class='tdblancoSinRaya'>" & "Código" & "</th>")
        strHtmlEncabezado.Append("<th width='300' class='tdblancoSinRaya'>" & "Descripción" & "</th>")
        strHtmlEncabezado.Append("<th width='72'  class='tdblancoSinRaya'>" & "Inventario Teórico" & "</th>")
        strHtmlEncabezado.Append("<th width='72'  class='tdblancoSinRaya'>" & "Cantidad Sugerida" & "</th>")
        strHtmlEncabezado.Append("<th width='96'  class='tdblancoSinRaya'>" & "Cantidad Surtida" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola

        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th width='24'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='54'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='300' class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='72'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='72'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='96'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")


        strImprimeEncabezado = strHtmlEncabezado.ToString

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin & strRedirectPage)
        End If

        Dim intResultado As Integer
        Dim strHTML As StringBuilder

        strHTML = New StringBuilder

        Dim objArrayOrdenSugerida As Array = Nothing
        Dim strRegistroOrdenSugerida As String()
        Dim strErrorOrdenSugerida As String = ""

        Dim strComitasDobles As String = """"


        'Consultamos los bultos de la transferencia
        objArrayOrdenSugerida = Nothing 'clsConcentrador.clsSucursal.clsMercancia.clsCompras.strBuscarOrdenSugerida(intCompaniaId, intSucursalId, intProveedorId, 0, 0, strCadenaConexion)

        If IsArray(objArrayOrdenSugerida) AndAlso (objArrayOrdenSugerida.Length > 0) Then
            strListaOrdenSugerida = strGeneraListaOrdenSugerida(objArrayOrdenSugerida)
            strImpresionOrdenSugerida = strGeneraImpresionOrdenSugerida(objArrayOrdenSugerida)
        End If

    End Sub


End Class
