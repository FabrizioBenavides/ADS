Imports Benavides.CC.Business
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class clsMercanciaConsultarEntradasProducto
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

    Private strmRecordBrowserHTML As String = ""
    Private strmMensaje As String = ""
    Private strmintArticuloId As String = ""
    Private strmArticuloDescripcion As String = ""

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
    ' Name       : strRecordBrowserHTML
    ' Description: RecordBrowser
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRecordBrowserHTML() As String
        Get
            Return strmRecordBrowserHTML
        End Get
        Set(ByVal strValue As String)
            strmRecordBrowserHTML = strValue
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
            If Not IsNothing(Request.QueryString("strCmd")) Then
                Return Request.QueryString("strCmd")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strArticuloId
    ' Description: Numero de artículo consultado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strArticuloId() As String
        Get
            If Len(Request("txtArticuloId")) > 0 Then
                Return Request("txtArticuloId")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strMensaje
    ' Description: Mensaje
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strMensaje() As String
        Get
            Return strmMensaje
        End Get
        Set(ByVal strValue As String)
            strmMensaje = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : strBuscarInformacionArticulo
    ' Description: Consulta la descripción del Artículo
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Sub strBuscarInformacionArticulo()
        Dim objArticulos As Array = Nothing
        Dim strArticulos As String() = Nothing

        If strArticuloId.Length > 0 Then

            'Buscamos la descripcion del articulo
            objArticulos = clsConcentrador.clsSucursal.strBuscarArticulo(intCompaniaId, intSucursalId, strArticuloId, 100, 100, strCadenaConexion)

            If IsArray(objArticulos) AndAlso (objArticulos.Length > 0) Then
                ' Obtenemos el código y la descripcion del articulo
                strArticulos = DirectCast(objArticulos.GetValue(0), String())
                intArticuloId = strArticulos(0).ToString
                strArticuloDescripcion = strArticulos(5)
            Else
                intArticuloId = "0"
                strArticuloDescripcion = ""
                strMensaje = "Articulo no valido"
            End If
        Else
            intArticuloId = ""
            strArticuloDescripcion = ""
            strMensaje = "Articulo no valido"
        End If

    End Sub

    '====================================================================
    ' Name       : intArticuloId
    ' Description: Numero de artículo a consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intArticuloId() As String
        Get
            Return strmintArticuloId
        End Get
        Set(ByVal strValue As String)
            strmintArticuloId = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strArticuloDescripcion
    ' Description: Descripcion del artículo a agregar
    ' Accessor   : Read / Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strArticuloDescripcion() As String
        Get
            Return strmArticuloDescripcion
        End Get
        Set(ByVal strValue As String)
            strmArticuloDescripcion = strValue
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

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        Select Case strCmd
            Case "Consultar"
                Dim objDataArray As Array = Nothing
                Dim objRegistro As String() = Nothing
                Dim intMesConsulta As Integer = 0
                Dim strHTML As StringBuilder
                Dim strTargetURL As String
                Dim objDataEntradas As Array = Nothing
                Dim objRegistroEntradas As String() = Nothing
                Dim strTipoEstadoTransferenciaNombreId As String = "Recibida"
                Dim intContador As Integer = 0
                Dim strColortd As String = ""
                Dim intDiferencia As Integer = 0
                Dim intEntradas As Integer = 0
                Dim intSalidas As Integer = 0
                Dim strMes As String


                ' Buscamos el número de artículo
                Call strBuscarInformacionArticulo()

                If CInt(intArticuloId) > 0 Then

                    Select Case CInt(Request.Form("rdoMesConsulta"))
                        Case 1 ' Mes Actual
                            intMesConsulta = Date.Now.Month
                            strMes = clsCommons.strNombreMes(CDate(Date.Now.ToString("MM/dd/yyyy")))
                        Case 2 ' Mes anterior
                            intMesConsulta = Date.Now.AddMonths(-1).Month
                            strMes = clsCommons.strNombreMes(CDate(Date.Now.AddMonths(-1).ToString("MM/dd/yyyy")))
                    End Select

                    ' Traemos información consolidada
                    objDataArray = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.strBuscarConsolidado(intCompaniaId, intSucursalId, intMesConsulta, CInt(intArticuloId), strCadenaConexion)

                    If IsArray(objDataArray) Then
                        If objDataArray.Length > 0 Then
                            strHTML = New StringBuilder


                            ' Traemos información de Entradas 
                            objDataEntradas = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.strBuscarArticulo(intCompaniaId, intSucursalId, intMesConsulta, CInt(intArticuloId), strTipoEstadoTransferenciaNombreId, 0, 0, strCadenaConexion)

                            ' Obtenemos los valores consolidados 
                            objRegistro = DirectCast(objDataArray.GetValue(0), String())

                            intEntradas = CInt(objRegistro(1))
                            intSalidas = CInt(objRegistro(0))
                            intDiferencia = intEntradas - intSalidas

                            ' Verificamos que exista información
                            If IsArray(objDataEntradas) Then
                                If objDataEntradas.Length > 0 Then

                                    strHTML.Append("<div id='ToPrintHtmContenido'><img src='../static/images/bullet_subtitulos.gif' width='17' height='11' align='absmiddle'>Entradas del producto <span class='txsubtituloresalta'> " & intArticuloId.ToString & " </span> en el mes de <span class='txsubtituloresalta'>" & strMes & "</span></span>")
                                    strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
                                    strHTML.Append("<tr>")
                                    strHTML.Append("<td width='34%' valign='top'>")
                                    strHTML.Append("<table width='98%' border='0' cellpadding='0' cellspacing='0'>")
                                    strHTML.Append("<tr>")
                                    strHTML.Append("<td bgcolor='F4F6F8' class='tdenvolventeazul'>")
                                    strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
                                    strHTML.Append("<tr>")
                                    strHTML.Append("<td width='73' class='tdtittablas'>Entradas:</td>")
                                    strHTML.Append("<td width='233' class='tdpadleft5'><input name='txtEntradas' type='text' readOnly=true class='campotablaresultado' id='txtEntradas' value='" & intEntradas.ToString & " ' size='16' maxlength='16'>")
                                    strHTML.Append("</td>")
                                    strHTML.Append("</tr>")
                                    strHTML.Append("<tr>")
                                    strHTML.Append("<td class='tdtittablas'>Salidas:</td>")
                                    strHTML.Append("<td class='tdpadleft5'><input name='txtSalidas' type='text' class='campotablaresultado' readOnly=true  id='txtSalidas' value='" & intSalidas.ToString & "' size='16' maxlength='16'>")
                                    strHTML.Append("</td>")
                                    strHTML.Append("</tr>")
                                    strHTML.Append("<tr>")
                                    strHTML.Append("<td height='27' class='tdtittablas'>Total:</td>")
                                    strHTML.Append("<td height='27' class='tdpadleft5'>")
                                    strHTML.Append("<input name='txtTotal' type='text' class='campotablaresultado' readOnly=true id='txtTotal' value='" & intDiferencia.ToString & "' size='16' maxlength='16'>")
                                    strHTML.Append("</td>")
                                    strHTML.Append("</tr>")
                                    strHTML.Append("</table>")
                                    strHTML.Append("</td>")
                                    strHTML.Append("</tr>")
                                    strHTML.Append("</table>")
                                    strHTML.Append("</td>")
                                    strHTML.Append("<td width='2%'>&nbsp;</td>")
                                    strHTML.Append("<td width='64%' valign='top'><table width='100%' border='0' cellpadding='0' cellspacing='0'>")
                                    strHTML.Append("<tr class='trtitulos'>")
                                    strHTML.Append("<th width='34' class='rayita'>No.</th>")
                                    strHTML.Append("<th width='98' class='rayita'>Fecha entrada</th>")
                                    strHTML.Append("<th width='73' class='rayita'>Folio</th>")
                                    strHTML.Append("<th width='159' class='rayita'>Unidades</th>")

                                    ' Se elige el color del tag td
                                    If (intContador Mod 2) = 0 Then
                                        strColortd = "'tdceleste'"
                                    Else
                                        strColortd = "'tdblanco'"

                                    End If

                                    For Each objRegistroEntradas In objDataEntradas
                                        strHTML.Append("<tr>")
                                        strHTML.Append("<td class=" & strColortd & ">" & objRegistroEntradas(0).ToString & "</td>")
                                        strHTML.Append("<td class=" & strColortd & ">" & clsCommons.strFormatearFechaPresentacion(CDate(objRegistroEntradas(2)).ToString("MM/dd/yyyy")) & "</td>")
                                        strHTML.Append("<td class=" & strColortd & ">" & objRegistroEntradas(1).ToString & "</td>")
                                        strHTML.Append("<td class=" & strColortd & ">" & objRegistroEntradas(3).ToString & "</td>")
                                        strHTML.Append("</tr>")
                                    Next

                                    strHTML.Append("</table>")
                                    strHTML.Append("</td>")
                                    strHTML.Append("</tr>")
                                    strHTML.Append("<tr>")
                                    strHTML.Append("<td colspan='3' valign='top'>&nbsp;</td>")
                                    strHTML.Append("</tr>")
                                    strHTML.Append("<tr>")
                                    strHTML.Append("<td valign='top'>&nbsp;</td>")
                                    strHTML.Append("<td>&nbsp;</td>")
                                    strHTML.Append("<td valign='top'>")
                                    strHTML.Append("<input name='cmdLimpiar' type='button' class='boton' id='cmdLimpiar' value='Limpiar' onClick='return cmdLimpiar_onClick()'>")
                                    strHTML.Append("&nbsp;&nbsp;&nbsp;")
                                    strHTML.Append("<input name='cmdVerSalidas' type='button' class='boton' id='cmdVerSalidas' value='Ver salidas' onClick='return cmdVerSalidas_onClick()'>")
                                    strHTML.Append("&nbsp;&nbsp;&nbsp;")
                                    strHTML.Append("<input name='cmdImprimir' type='button' class='boton' id='cmdImprimir' value='Imprimir reporte' onClick='return cmdImprimir_onClick()'>")
                                    strHTML.Append("</td>")
                                    strHTML.Append("</tr>")
                                    strHTML.Append("</table></div>")

                                    strRecordBrowserHTML = strHTML.ToString
                                    Return
                                End If
                            End If
                        End If
                    End If
                    strMensaje = "No existen Mercancias de entrada de ese producto."

                End If


            Case "BuscarArticulo"

                Dim strHTML As StringBuilder

                strHTML = New StringBuilder

                'Obtenemos la descripcion del articulo
                Call strBuscarInformacionArticulo()

                strHTML.Append("<script language='javascript'>")
                strHTML.Append("parent.document.forms[0].elements['txtArticuloId'].value='" & intArticuloId.ToString & "';")
                strHTML.Append("parent.document.forms[0].elements['txtArticuloDescripcion'].value='" & strArticuloDescripcion.ToString & "';")
                strHTML.Append("parent.document.forms[0].elements['hdnArticuloId'].value='" & intArticuloId.ToString & "';")
                strHTML.Append("</script>")


                Call Response.Write(strHTML.ToString)
                Call Response.End()


        End Select

    End Sub

End Class
