Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class clsMercanciaConsultarNotasCargo
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
    ' Name       : rdoTipoNotaCargo
    ' Description: Valor del radio boton seleccionado de tipo de nota entrada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property rdoTipoNotaCargo() As String
        Get
            If Len(Request("rdoTipoNota")) > 0 Then
                Return Request("rdoTipoNota")
            Else
                Return ""
            End If
        End Get
    End Property
    '====================================================================
    ' Name       : strGeneraTipoNotaCargoHTML
    ' Description: Genera radio botones en HTML
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGeneraTipoNotaCargoHTML() As String
        Dim strHTML As StringBuilder
        Dim objDataArray As Array = Nothing
        Dim objRegistro As String() = Nothing
        Dim intTipoNotaCargoId As Integer = 0
        Dim strTipoNotaCargoNombreId As String = ""
        Dim strTipoNotaCargoNombre As String = ""
        Dim dtmTipoNotaCargoUltimaModificacion As Date = CDate("01/01/1900")
        Dim strTipoNotaCargoModificadoPor As String = ""
        Dim intPosicionInicial As Integer = 0
        Dim intElementos As Integer = 0
        Dim intContador As Integer = 0

        objDataArray = clstblTipoNotaCargo.strBuscar(intTipoNotaCargoId, strTipoNotaCargoNombreId, strTipoNotaCargoNombre, dtmTipoNotaCargoUltimaModificacion, strTipoNotaCargoModificadoPor, intPosicionInicial, intElementos, strCadenaConexion)

        If IsArray(objDataArray) Then
            If objDataArray.Length > 0 Then

                strHTML = New StringBuilder

                strHTML.Append("<table>")
                strHTML.Append("<tr><td width='120' class='tdtittablas'>&iquest;Qu&eacute; tipo de nota desea recuperar?:</td><td></td></tr>")

                ' Generamos los radio botones dinamicamente
                For Each objRegistro In objDataArray
                    intContador += 1

                    strTipoNotaCargoNombreId = objRegistro(1).ToString
                    strTipoNotaCargoNombre = objRegistro(2).ToString

                    If rdoTipoNotaCargo.Length > 0 Then
                        If strTipoNotaCargoNombreId = rdoTipoNotaCargo Then
                            strHTML.Append("<tr><td></td><td colspan='4' class='tdconttablas'><input name='rdoTipoNota' type='radio' id='rdoTipoNota" & intContador.ToString & "' value='" & strTipoNotaCargoNombreId & "' checked>" & "Por " & strTipoNotaCargoNombre & " </td></tr>")
                        Else
                            strHTML.Append("<tr><td></td><td colspan='4' class='tdconttablas'><input name='rdoTipoNota' type='radio' id='rdoTipoNota" & intContador.ToString & "' value='" & strTipoNotaCargoNombreId & "'>" & "Por " & strTipoNotaCargoNombre & " </td></tr>")
                        End If
                    Else
                        If intContador = 1 Then
                            strHTML.Append("<tr><td></td><td colspan='4' class='tdconttablas'><input name='rdoTipoNota' type='radio' id='rdoTipoNota" & intContador.ToString & "' value='" & strTipoNotaCargoNombreId & "' checked>" & "Por " & strTipoNotaCargoNombre & " </td></tr>")
                        Else
                            strHTML.Append("<tr><td></td><td colspan='4' class='tdconttablas'><input name='rdoTipoNota' type='radio' id='rdoTipoNota" & intContador.ToString & "' value='" & strTipoNotaCargoNombreId & "'>" & "Por " & strTipoNotaCargoNombre & " </td></tr>")
                        End If

                    End If

                Next

                strHTML.Append("</table>")


                Return clsCommons.strGenerateJavascriptString(strHTML.ToString)
            End If
        End If

        Return clsCommons.strGenerateJavascriptString("<table><tr><td class='tdtittablas'>No se encuentran dados de alto los diferentes tipos de notas de cargo</td></tr></table><br><br>")

    End Function

    '====================================================================
    ' Name       : strCmd
    ' Description: Comando a ejecutar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return Trim(Request.QueryString("strCmd"))
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


        Select Case strCmd
            Case "BuscarProveedor"
                Dim objDataArray As Array = Nothing
                Dim objRegistro As String() = Nothing
                Dim intProveedorId As Integer = CInt(Trim(Request.Form("txtProveedor")))
                Dim intEstadoId As Integer = 0
                Dim intCiudadId As Integer = 0
                Dim intTipoProveedorId As Integer = 0
                Dim strProveedorRazonSocial As String = ""
                Dim blnProveedorNacional As Byte = 0
                Dim strProveedorRFC As String = ""
                Dim blnProveedorAplicaComision As Byte = 0
                Dim blnProveedorVigente As Byte = 0
                Dim dtmProveedorUltimaModificacion As Date = CDate("01/01/1900")
                Dim strProveedorModificadoPor As String = ""
                Dim intPosicionInicial As Integer = 0
                Dim intElementos As Integer = 0
                Dim strHTML As String = ""
                Dim strNombreProveedor As String = ""

                ' Buscamos el proveedor
                objDataArray = clstblProveedor.strBuscar(intProveedorId, intEstadoId, intCiudadId, intTipoProveedorId, strProveedorRazonSocial, blnProveedorNacional, strProveedorRFC, blnProveedorAplicaComision, blnProveedorVigente, dtmProveedorUltimaModificacion, strProveedorModificadoPor, "", intPosicionInicial, intElementos, strCadenaConexion)

                If IsArray(objDataArray) Then
                    If objDataArray.Length > 0 Then
                        objRegistro = DirectCast(objDataArray.GetValue(0), String())

                        strNombreProveedor = clsCommons.strFormatearDescripcion(objRegistro(4)).ToString

                        strHTML = "<script language='javascript'>parent.document.frmMercanciaConsultarNotasCargo.txtRazonSocialProveedor.value='" & strNombreProveedor & "';parent.blnConsultaProveedor=false;</script>"

                    Else
                        strHTML = "<script language='javascript'>alert('Número de proveedor no existe.');parent.document.frmMercanciaConsultarNotasCargo.txtProveedor.focus();parent.document.frmMercanciaConsultarNotasCargo.txtRazonSocialProveedor.value='';parent.document.frmMercanciaConsultarNotasCargo.txtProveedor.value='';parent.blnConsultaProveedor=true;</script>"
                    End If
                End If
                Call Response.Write(strHTML)
                Call Response.End()


        End Select

    End Sub

End Class
