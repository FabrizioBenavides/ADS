Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration

Public Class CompraDirectaModificarOrdenSugerida
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
    Private intmTotalCampos As Integer = 0
#End Region

#Region " Class Public Attributes"
    Const intRenglonesxPagina As Integer = 46
    Public strVerOrdenCompra As String = ""
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
    ' Name       : intCompraDirectaId
    ' Description: Identificador de la Compra Directa Capturada
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCompraDirectaId() As Integer
        Get
            If Not IsNothing(Request.Form("txtCompraDirectaId")) Then
                If IsNumeric(Request.Form("txtCompraDirectaId")) Then
                    Return CInt(Request.Form("txtCompraDirectaId"))
                Else
                    Return 0
                End If

            Else
                Return 0
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
            If Not IsNothing(Request.Form("hdnProveedorId")) Then
                If IsNumeric(Request.Form("hdnProveedorId")) Then
                    Return CInt(Request.Form("hdnProveedorId"))
                Else
                    Return 0
                End If

            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strroveedorNombreId
    ' Description: Nombre del Proveedor de la Orden Sugerida
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strroveedorNombreId() As String
        Get
            If Not IsNothing(Request.Form("txtProveedorNombreId")) Then
                Return Request.Form("txtProveedorNombreId")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strRazonSocialProveedor
    ' Description: Nombre del Proveedor de la Orden Sugerida
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strRazonSocialProveedor() As String
        Get
            If Not IsNothing(Request.Form("txtRazonSocialProveedor")) Then
                Return Request.Form("txtRazonSocialProveedor")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : hdnSoloOrden
    ' Description: solo captura Orden
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property blnSoloOrden() As Boolean
        Get
            Dim blnRegreso As Boolean = False

            If Not IsNothing(Request.Form("hdnSoloOrden")) Then
                If IsNumeric(Request.Form("hdnSoloOrden")) Then
                    If CInt(Request.Form("hdnSoloOrden")) = 1 Then
                        blnRegreso = True
                    End If
                End If
            End If
            Return blnRegreso
        End Get
    End Property

    '====================================================================
    ' Name       : intFolioOrdenId
    ' Description: Folio de orden a Confirmar
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intFolioOrdenId() As Integer
        Get
            Dim intRegreso As Integer = 0

            If Not IsNothing(Request.Form("txtFolioOrdenId")) Then
                If IsNumeric(Request.Form("txtFolioOrdenId")) Then
                    intRegreso = CInt(Request.Form("txtFolioOrdenId"))
                End If
            End If

            Return intRegreso

        End Get
    End Property

    '====================================================================
    ' Name       : intArticulosListaOrdenSugerida
    ' Description: Indica el numero de Articulos en la Orden Sugerida
    ' Accessor   : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intArticulosListaOrdenSugerida() As Integer
        Get
            If Not IsNothing(Request.Form("txtArticulosLista")) Then
                If IsNumeric(Request.Form("txtArticulosLista")) Then
                    Return CInt(Request.Form("txtArticulosLista"))
                Else
                    Return 0
                End If

            Else
                Return 0
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : intTotalCampos
    ' Description: Total de campos en la pagina
    ' Accessor   : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intTotalCampos() As Integer
        Get
            Return intmTotalCampos
        End Get
        Set(ByVal Value As Integer)
            intmTotalCampos = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strGeneraOrdenDeCompra
    ' Description: Genera el Record Browser 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strGeneraOrdenDeCompra(ByVal objOrdenDeCompra As Array) As String

        Dim strRegistroOrden As System.Collections.SortedList = Nothing

        Dim strHTML As StringBuilder
        Dim strClass As String = ""
        Dim strClassReadOnly As String = ""
        Dim strComilla As String = """"

        Dim intRenglon As Integer = 0
        Dim intNumeroCampo As Integer = 0

        Dim fltImporteRenglon As Double = 0

        strHTML = New StringBuilder

        strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strHTML.Append("<tr class='trtitulos'>")

        strHTML.Append("<th width='25'  class='rayita'><input tabIndex='-1' type='checkbox' title='Desmarcar Todos' onclick='javascript:fnMarcarTodos()' id='chkMarcarTodos' checked></th>")
        strHTML.Append("<th width='25'  class='rayita'>Código</th>")
        strHTML.Append("<th width='60'  class='rayita'>Descripción</th>")
        strHTML.Append("<th width='100' class='rayita'>Cantidad</th>")
        strHTML.Append("<th align='right' width='25'  class='rayita'>Costo</th>")
        strHTML.Append("<th align='right' width='25'  class='rayita'>Importe</th>")

        strHTML.Append("</tr>")


        If IsArray(objOrdenDeCompra) AndAlso (objOrdenDeCompra.Length > 0) Then

            For Each strRegistroOrden In objOrdenDeCompra

                intRenglon += 1

                If ((intRenglon Mod 2) = 0) Or (intRenglon = 0) Then
                    strClass = "tdceleste"
                    strClassReadOnly = "campotablaresultadoenvolventeazul"
                Else
                    strClass = "tdblanco"
                    strClassReadOnly = "campotablaresultadoblanco"
                End If

                strHTML.Append("<tr>")

                'No. de Renglon
                strHTML.Append("<td align='right' class='" & strClass & "'>" & intRenglon.ToString & "&nbsp;</td>")

                ' intArticuloId
                intNumeroCampo += 1
                strHTML.Append("<td class='" & strClass & "'><input tabIndex='-1' type='checkbox' name='chkart_" & intRenglon.ToString & "' value='" & CStr(strRegistroOrden.Item("intArticuloId")) & "' checked >" & CStr(strRegistroOrden.Item("intArticuloId")) & "&nbsp;</td>")

                ' strArticuloDescripcion
                strHTML.Append("<td class='" & strClass & "'>" & Mid(clsCommons.strFormatearDescripcion(CStr(strRegistroOrden.Item("strArticuloDescripcion"))).ToString, 1, 32) & "</td>")

                ' CantidadSugerida  
                intNumeroCampo += 1
                strHTML.Append("<td class='" & strClass & "'>" & Format(CInt(strRegistroOrden.Item("intArticuloCantidad")), "000") & "&nbsp;&nbsp; <input class='campotabla' type='text' name='txtCan_" & intRenglon.ToString & "' value='" & CInt(strRegistroOrden.Item("intArticuloCantidad")) & "' size='6' onfocus='cmdCampo_onfocus(" & intNumeroCampo.ToString & ");' " & " onblur='intValidaCantidadRenglon(" & intRenglon.ToString & "," & intNumeroCampo.ToString & "," & CInt(strRegistroOrden.Item("intArticuloCantidad")) & ");'></td>")

                ' Costo Reposicion 
                intNumeroCampo += 1
                strHTML.Append("<td class='" & strClass & "'><input class='campotabla' type='text' name='txtCos_" & intRenglon.ToString & "' value='" & CDbl(strRegistroOrden.Item("fltArticuloSucursalCostoReposicion")) & "' size='6' onfocus='cmdCampo_onfocus(" & intNumeroCampo.ToString & ");'" & " onblur='intValidaCostoRenglon(" & intRenglon.ToString & "," & intNumeroCampo.ToString & "," & CStr(strRegistroOrden.Item("fltArticuloSucursalCostoReposicion")) & ");'></td>")

                'Importe
                intNumeroCampo += 1
                fltImporteRenglon = CInt(strRegistroOrden.Item("intArticuloCantidad")) * CDbl(strRegistroOrden.Item("fltArticuloSucursalCostoReposicion"))
                strHTML.Append("<td align='right' class='" & strClass & "'><input class='" & strClassReadOnly & "' readOnly tabIndex='-1' type='text' name='txtImp_" & intRenglon.ToString & "' value='" & fltImporteRenglon.ToString & "' size='6' ></td>")

                strHTML.Append("</tr>")

            Next
        Else
            strHTML.Append("<tr>")
            strHTML.Append("<td class='tdblanco' colspan='6'>No hay registros</td>")
            strHTML.Append("</tr>")

        End If
        strHTML.Append("<tr>")
        strHTML.Append("<td colspan='6'><input type='hidden' name='txtArticulosLista' value = '" & intRenglon.ToString & "'> </td>")
        strHTML.Append("</tr>")

        strHTML.Append("</table>")
        strHTML.Append("<br>")

        intTotalCampos = intNumeroCampo

        Return (clsCommons.strGenerateJavascriptString(strHTML.ToString))


    End Function

    Function intAgregarArticulo(ByVal intCompraAgregar As Integer, ByVal intDepartamentoAgregar As Integer, ByVal intArticuloAgregar As Integer, ByVal intCantidadAgregar As Integer, ByVal dblCostoAgregar As Double) As Integer

        Dim intAgregaArticulo As Integer = 0

        intAgregaArticulo = clsConcentrador.clsSucursal.clsMercancia.clsCompras.intAgregarArticulo(intCompraAgregar, intArticuloAgregar, intCantidadAgregar, CDec(dblCostoAgregar), strUsuarioNombre, strCadenaConexion)

        If intAgregaArticulo < 1 Then
            Return -1
        Else
            Return 1
        End If


    End Function



    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim intResultado As Integer
        Dim strHTML As StringBuilder

        strHTML = New StringBuilder

        Dim objArrayOrdenSugerida As Array = Nothing
        Dim strRegistroOrdenSugerida As String()
        Dim strErrorOrdenSugerida As String = ""

        Dim strComitasDobles As String = """"
        Dim intCampoPagina As Integer = 0

        Select Case strCmd

            Case "Consultar"

                strVerOrdenCompra = strGeneraOrdenDeCompra(clsConcentrador.clsSucursal.clsMercancia.clsCompras.strBuscarOrdenDetalle(intCompaniaId, intSucursalId, intProveedorId, intFolioOrdenId, strCadenaConexion))

            Case "Importar"

                Dim intResultadoImportar As Integer = 0

                Dim strNombreCampo As String
                Dim intArticuloImportar As Integer = 0
                Dim intDepartamentoImportar As Integer = 0
                Dim intCantidadImportar As Integer = 0
                Dim dblCostoImportar As Double = 0

                strErrorOrdenSugerida = "0"

                For intCampoPagina = 1 To intArticulosListaOrdenSugerida

                    strNombreCampo = Trim("chkart_" & intCampoPagina.ToString)

                    If Len(Trim(Request.Form(strNombreCampo))) > 0 Then

                        strNombreCampo = Trim("chkart_" & intCampoPagina.ToString)
                        intArticuloImportar = CInt(Request.Form(strNombreCampo))

                        strNombreCampo = Trim("txtCan_" & intCampoPagina.ToString)
                        intCantidadImportar = CInt(Request.Form(strNombreCampo))

                        strNombreCampo = Trim("txtCos_" & intCampoPagina.ToString)
                        dblCostoImportar = CDbl(Request.Form(strNombreCampo))

                        strNombreCampo = Trim("txtDep_" & intCampoPagina.ToString)
                        intDepartamentoImportar = CInt(Request.Form(strNombreCampo))

                        If (intCantidadImportar > 0 And dblCostoImportar > 0) Then

                            intResultadoImportar = intAgregarArticulo(intCompraDirectaId, intDepartamentoImportar, intArticuloImportar, intCantidadImportar, dblCostoImportar)
                            If intResultadoImportar < 0 Then
                                strErrorOrdenSugerida = "-100"
                                Exit For
                            End If

                        End If

                    End If

                Next

                strHTML.Append("<script language='Javascript'> parent.fnUpImportaArticulos( " & _
                                strComitasDobles & strErrorOrdenSugerida & strComitasDobles & "," & _
                                strComitasDobles & intDepartamentoImportar & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()


        End Select

    End Sub

End Class
