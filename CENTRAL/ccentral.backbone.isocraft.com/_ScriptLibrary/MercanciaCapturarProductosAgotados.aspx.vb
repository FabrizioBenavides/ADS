Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration

Public Class clsMercanciaCapturarProductosAgotados
    Inherits System.Web.UI.Page
    Public strGeneraTablaHTML As String
    Public strmMensaje As String
    Private intmInventarioAgotadoId As Integer

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.diagnostics.debuggerstepthrough()> Private Sub InitializeComponent()

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
    ' Name       : strCmd
    ' Description: string de Comandos de control
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Not IsNothing(Request("strCmd")) Then
                Return Request("strCmd")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: string de Comandos de control
    ' Accessor   : Read and Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intInventarioAgotadoId() As Integer
        Get
            Return intmInventarioAgotadoId
        End Get
        Set(ByVal intValue As Integer)
            intmInventarioAgotadoId = intValue
        End Set
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
    ' Name       : strMensaje
    ' Description: valor para mensaje
    ' Accessor   : Read and Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strMensaje() As String
        Get
            Return strmMensaje
        End Get
        Set(ByVal strValue As String)
            If IsNothing(strValue) Then
                strmMensaje = ""
            Else
                strmMensaje = Trim(strValue)
            End If
        End Set
    End Property
    '====================================================================
    ' Name       : strtxtIntArticuloId
    ' Description: valor del control txtIntArticuloId
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strtxtIntArticuloId() As String
        Get
            Dim strTemporal As String
            strTemporal = Trim(Request("txtIntArticuloId"))
            If strTemporal.Equals("") Then
                Return ""
            Else
                Return strTemporal
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
        Dim strRecordBrowser As String = ""


        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        Dim objArray As Array = Nothing
        Dim intInicio As Integer = 0
        Dim intResultado As Integer

        'Request Variables
        If Len(Request("intInventarioAgotadoId")) > 0 Then
            intInventarioAgotadoId = CInt(Request("intInventarioAgotadoId"))
        Else
            intInventarioAgotadoId = 0
        End If


        Select Case UCase(Trim(strCmd))
            Case ""
                'Generar Tabla de informacion
                objArray = Nothing
                objArray = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarDetalleAgotado(intInventarioAgotadoId, intCompaniaId, intSucursalId, 0, 0, strCadenaConexion)
                If IsArray(objArray) AndAlso (objArray.Length > 0) Then
                    strGeneraTablaHTML = strGeneraTabla(objArray, "Reporte de artículos agotados", "Código", intInicio, "", "Descripción", "", "", "", "", "Acción")
                Else
                    strGeneraTablaHTML = ""
                End If

            Case UCase("BuscarArticulo")
                Dim strHTML As StringBuilder
                Dim strRegistro As String()

                strHTML = New StringBuilder
                strMensaje = "Artículo no encontrado."
                ' Obtenemos la información de los Articulos
                objArray = Nothing
                objArray = clsConcentrador.clsSucursal.strBuscarArticulo(intCompaniaId, intSucursalId, strtxtIntArticuloId, 1, 1, strCadenaConexion)
                '0 intArticuloId                                1 fltArticuloSucursalCostoReposicion 
                '2 fltArticuloSucursalPrecioTransferencia
                '3 fltArticuloSucursalPrecioNormalConImpuesto   4 intArticuloSucursalExistenciaIdeal 
                '5 strArticuloDescripcion                                                                                                                                                                                                                                          intDepartamentoId blnArticuloCaduca fltArticuloSucursalPrecioNormalSinImpuesto fltArticuloSucursalVentaTrimestralRegistrada fltArticuloSucursalVentaMensualRegistrada fltArticuloSucursalVentaSemanalRegistrada
                If IsArray(objArray) AndAlso (objArray.Length > 0) Then
                    For Each strRegistro In objArray
                        strHTML.Append("<script language='javascript'>")

                        strHTML.Append("parent.document.forms(0).elements('txtIntArticuloId')")
                        strHTML.Append(".value='" & clsCommons.strFormatearDescripcion(strRegistro(0)).ToString & "';")

                        'Articulo anterior
                        strHTML.Append("parent.document.forms(0).elements('hdnArticuloAnteriorId')")
                        strHTML.Append(".value='" & clsCommons.strFormatearDescripcion(strRegistro(0)).ToString & "';")

                        strHTML.Append("parent.document.forms(0).elements('txtStrArticuloDescripcion')")
                        strHTML.Append(".value='" & clsCommons.strFormatearDescripcion(strRegistro(5)).ToString & "';")

                        strHTML.Append("parent.document.forms(0).elements('cmdAgregarArticulo').focus();")

                        strHTML.Append("</script>")
                        strMensaje = ""
                        Exit For
                    Next
                End If
                If Trim(strMensaje).Equals("") Then
                    'Articulo si encontrado
                    Response.Write(strHTML.ToString)
                    Response.End()
                Else
                    'Articulo no encontrado
                    strHTML.Append("<script language='javascript'>")

                    strHTML.Append("parent.document.forms(0).elements('txtIntArticuloId')")
                    strHTML.Append(".value='';")

                    strHTML.Append("parent.document.forms(0).elements('txtStrArticuloDescripcion')")
                    strHTML.Append(".value='';")

                    strHTML.Append("parent.document.forms(0).elements('txtIntArticuloId')")
                    strHTML.Append(".focus();")

                    strHTML.Append("alert('" & strMensaje & "');")
                    strHTML.Append("</script>")


                    Response.Write(strHTML.ToString)
                    Response.End()
                End If

            Case UCase("AgregarArticulo")
                Dim strHTML As StringBuilder

                If intInventarioAgotadoId.Equals(0) Then
                    intInventarioAgotadoId = clsConcentrador.clsSucursal.clsMercancia.clsInventario.intAgregarAgotado(intCompaniaId, intSucursalId, strUsuarioNombre, strCadenaConexion)
                End If
                intResultado = clsConcentrador.clsSucursal.clsMercancia.clsInventario.intAgregarArticuloAgotado(intInventarioAgotadoId, intCompaniaId, intSucursalId, CInt(strtxtIntArticuloId), strUsuarioNombre, strCadenaConexion)


                'Generar Tabla de informacion
                objArray = Nothing
                objArray = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarDetalleAgotado(intInventarioAgotadoId, intCompaniaId, intSucursalId, 0, 0, strCadenaConexion)

                strHTML = New StringBuilder

                If IsArray(objArray) AndAlso (objArray.Length > 0) Then

                    strRecordBrowser = """" & strGeneraTabla(objArray, "Reporte de artículos agotados", "Código", intInicio, "", "Descripción", "", "", "", "", "Acción") & """"

                    strHTML.Append("<script language='javascript'>parent.strRecordBrowserHTML(" & strRecordBrowser & "," & intInventarioAgotadoId.ToString & ")</script>")
                Else
                    strHTML.Append("<script language='javascript'>parent.strRecordBrowserHTML('',0);</script>")
                End If


                Call Response.Write(strHTML.ToString)
                Call Response.End()

            Case UCase("BorrarArticulo")
                Dim strHTML As StringBuilder
                intResultado = clsConcentrador.clsSucursal.clsMercancia.clsInventario.intBorrarArticuloAgotado(intInventarioAgotadoId, intCompaniaId, intSucursalId, CInt(strtxtIntArticuloId), strCadenaConexion)

                'Generar Tabla de informacion
                objArray = Nothing
                objArray = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarDetalleAgotado(intInventarioAgotadoId, intCompaniaId, intSucursalId, 0, 0, strCadenaConexion)


                strHTML = New StringBuilder

                If IsArray(objArray) AndAlso (objArray.Length > 0) Then

                    strRecordBrowser = """" & strGeneraTabla(objArray, "Reporte de artículos agotados", "Código", intInicio, "", "Descripción", "", "", "", "", "Acción") & """"

                    strHTML.Append("<script language='javascript'>parent.strRecordBrowserHTML(" & strRecordBrowser & "," & intInventarioAgotadoId.ToString & ")</script>")
                Else
                    strHTML.Append("<script language='javascript'>parent.strRecordBrowserHTML('',0);</script>")
                End If

                Call Response.Write(strHTML.ToString)
                Call Response.End()

        End Select
    End Sub
    Private Function strGeneraTabla(ByVal objArray As Array, _
                                  ByVal strTitulo As String, _
                                  ByVal strEncaCol0 As String, _
                                  ByRef intConsecutivo As Integer, _
                                  ByVal strEncaCol1 As String, _
                                  ByVal strEncaCol2 As String, _
                                  ByVal strEncaCol3 As String, _
                                  ByVal strEncaCol4 As String, _
                                  ByVal strEncaCol5 As String, _
                                  ByVal strEncaCol6 As String, _
                                  ByVal strEncaCol7 As String _
                                  ) As String
        Dim strHTML As StringBuilder
        Dim strRegistro As String()
        strRegistro = Nothing
        Dim intRenglon As Integer
        Dim strClass As String
        Dim strComilla As String
        Dim strReadonly As String

        strComilla = """"

        strHTML = New StringBuilder
        strHTML.Append("")

        strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strHTML.Append("<tr class='trtitulos'>")
        strHTML.Append("<th colspan='3'><span class='txsubtitulo'>")
        strHTML.Append("<img src='../static/images/bullet_subtitulos.gif' width='17' height='11' ")
        strHTML.Append("align='absmiddle'>" & strTitulo & "</span>")
        strHTML.Append("</th>")

        strHTML.Append("</tr>")
        strHTML.Append("<tr class='trtitulos'>")
        strHTML.Append("<th width='0'   class='rayita'>" & strEncaCol0 & "&nbsp;</th>")
        strHTML.Append("<th width='61'  class='rayita'>" & strEncaCol1 & "&nbsp;</th>")
        strHTML.Append("<th width='200' class='rayita'>" & strEncaCol2 & "&nbsp;</th>")
        strHTML.Append("<th class='rayita'>" & strEncaCol3 & "&nbsp;</th>")
        strHTML.Append("<th class='rayita'>" & strEncaCol4 & "&nbsp;</th>")
        strHTML.Append("<th class='rayita'>" & strEncaCol5 & "&nbsp;</th>")
        strHTML.Append("<th class='rayita'>" & strEncaCol6 & "&nbsp;</th>")
        strHTML.Append("<th class='rayita' align='right'>" & strEncaCol7 & "&nbsp;</th>")
        strHTML.Append("</tr>")

        '------------------------
        intRenglon = 0
        If IsArray(objArray) AndAlso (objArray.Length > 0) Then
            For Each strRegistro In objArray

                intConsecutivo += 1
                intRenglon += 1
                If ((intRenglon Mod 2) = 0) Or (intRenglon = 0) Then
                    strClass = "tdceleste"
                Else
                    strClass = "tdblanco"
                End If
                strHTML.Append("<tr>")

                '0 intArticuloId 
                '1 strArticuloDescripcion                                                                                                                                                                                                                                          
                '2 intTotalRegistros

                'Columna 0
                strHTML.Append("<td class='" & strClass & "'>" & strRegistro(0) & "&nbsp;</td>")

                'Columna 1
                strHTML.Append("<td class='" & strClass & "'>" & "" & "&nbsp;</td>")

                'Columna 2
                strHTML.Append("<td class='" & strClass & "'>" & clsCommons.strFormatearDescripcion(strRegistro(1)) & "&nbsp;</td>")

                'Columna 3
                strHTML.Append("<td align='right' class='" & strClass & "'>" & "&nbsp;</td>")

                'Columna 4
                strHTML.Append("<td align='right' class='" & strClass & "'>" & "&nbsp;</td>")

                'Columna 5
                strHTML.Append("<td align='right' class='" & strClass & "'>" & "&nbsp;</td>")

                'Columna 6
                strHTML.Append("<td align='right' class='" & strClass & "'>" & "&nbsp;</td>")

                'Columna 7
                'strHTML.Append("<td align='right' class='" & strClass & "'><a style=" & strComilla & "text-decoration: none" & strComilla & " href=" & strComilla & "javascript:fnBorrarPartida(" & "" & "" & strRegistro(0) & ")" & strComilla & ">" & "<img src=../static/images/icono_borrar.gif width=11 height=13 border=0 align=absmiddle><font color=#575757> Borrar&nbsp;</font>" & "</a></td>")
                strHTML.Append("<td align='right' class='" & strClass & "'><a style='text-decoration: none' href='javascript:fnBorrarPartida(" & strRegistro(0).ToString & ")'" & ">" & "<img src=../static/images/icono_borrar.gif width=11 height=13 border=0 align=absmiddle><font color=#575757> Borrar&nbsp;</font>" & "</a></td>")

                strHTML.Append("</tr>")
            Next
        End If
        '------------------------

        strHTML.Append("</table>")
        strHTML.Append("<input type=hidden name=hdnTotalDePartidas value=" & intRenglon.ToString & ">")
        strGeneraTabla = clsCommons.strGenerateJavascriptString(strHTML.ToString)
    End Function

End Class
