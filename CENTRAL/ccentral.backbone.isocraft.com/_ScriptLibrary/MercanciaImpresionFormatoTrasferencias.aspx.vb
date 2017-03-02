Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text
Imports System.DateTime

Public Class MercanciaImpresionFormatoTrasferencias
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
    ' Name       : strCadenaImagen
    ' Description: Valor de la Compañia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCadenaImagen() As String
        Get
            Return (clsCommons.strReadCookie("strCadenaImagen", "", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strCentroLogisticoId
    ' Description: Valor de la Compañia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCentroLogisticoId() As String
        Get
            Return (clsCommons.strReadCookie("strCentroLogisticoId", "", Request, Server))
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
    ' Description: Valor que tomara la variable strmCadenaConexion
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
    ' Description: RecordBrowser de Recibos
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRecordBrowserHTML() As String
        Get
            Return strmRecordBrowserHTML
        End Get
        Set(ByVal Value As String)
            strmRecordBrowserHTML = Value
        End Set

    End Property

    '====================================================================
    ' Name       : strRegistrosRecordBrowser
    ' Description: Registros en el RecordBrowser
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public ReadOnly Property strRegistrosRecordBrowser() As String
        Get
            If strRecordBrowserHTML.Length > 0 Then
                Return strRecordBrowserHTML.Length.ToString
            Else
                Return ""
            End If
        End Get
    End Property
    '====================================================================
    ' Name       : intLineasReporte
    ' Description: Comando a ejecutar
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intLineasReporte() As Integer
        Get
            If Not IsNothing(Request.Form("txtLineasReporte")) Then
                Return CInt(Request.Form("txtLineasReporte"))
            Else
                Return 0
            End If
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


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        strRecordBrowserHTML = ""

        If strCmd = "ImprimeReporte" Then

            Dim strRecordBrowseComplemento As StringBuilder

            strRecordBrowseComplemento = New StringBuilder

            Dim strColorRegistro As String = ""

            Dim intNumeroRenglones As Integer = intLineasReporte

            Dim intRenglonesxPagina As Integer = 30
            Dim intContadorRenglones As Integer = 0
            Dim intRenglon As Integer = 0

            strRecordBrowseComplemento.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

            strRecordBrowseComplemento.Append("<tr>")
            strRecordBrowseComplemento.Append("<td width='52%' class='tdtittablasazul'>" & "" & "</td>")
            strRecordBrowseComplemento.Append("<td width='48%' align='right' class='tdtittablas'>Folio:______________&nbsp;&nbsp;&nbsp;&nbsp; Fecha: ___________</td>")
            strRecordBrowseComplemento.Append("<td></td>")
            strRecordBrowseComplemento.Append("<td></td>")
            strRecordBrowseComplemento.Append("</tr>")

            strRecordBrowseComplemento.Append("<tr>")
            strRecordBrowseComplemento.Append("<td colspan='4' width='100%' class='tdtittablas'>Sucursal que recibe:_________________________</td>")
            strRecordBrowseComplemento.Append("</tr>")

            strRecordBrowseComplemento.Append("</table>")

            strRecordBrowseComplemento.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

            strRecordBrowseComplemento.Append("<tr class='trtitulos'>")
            strRecordBrowseComplemento.Append("<th width='58' class='rayita'>&nbsp;</th>")
            strRecordBrowseComplemento.Append("<th width='338' class='rayita'>Articulo</th>")
            strRecordBrowseComplemento.Append("<th width='77' class='rayita'>Cantidad</th>")
            strRecordBrowseComplemento.Append("<th width='98' class='rayita'>Precio venta</th>")
            strRecordBrowseComplemento.Append("</tr>")

            For intContadorRenglones = 1 To intNumeroRenglones

                If (intContadorRenglones Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If
                intRenglon += 1

                strRecordBrowseComplemento.Append("<tr>")
                strRecordBrowseComplemento.Append("<td class=" & strColorRegistro & ">" & intContadorRenglones.ToString & "</td>")
                strRecordBrowseComplemento.Append("<td class=" & strColorRegistro & ">" & "&nbsp;</td>")
                strRecordBrowseComplemento.Append("<td class=" & strColorRegistro & ">" & "&nbsp;</td>")
                strRecordBrowseComplemento.Append("<td class=" & strColorRegistro & ">" & "&nbsp;</td>")
                strRecordBrowseComplemento.Append("</tr>")

                If intRenglon >= intRenglonesxPagina And intContadorRenglones < intLineasReporte Then

                    strRecordBrowseComplemento.Append("<tr>")
                    strRecordBrowseComplemento.Append("<td><P class='breakhere'></P></td>")
                    strRecordBrowseComplemento.Append("<td></td>")
                    strRecordBrowseComplemento.Append("<td></td>")
                    strRecordBrowseComplemento.Append("<td></td>")
                    strRecordBrowseComplemento.Append("</tr>")

                    strRecordBrowseComplemento.Append("<tr>")
                    strRecordBrowseComplemento.Append("<td colspan='4' width='100%' class='tdlogo'>")
                    strRecordBrowseComplemento.Append("<img src='../static/images/" & strCadenaImagen & "/logo.gif' width='125' height='25'><br>")
                    strRecordBrowseComplemento.Append("</td>")
                    strRecordBrowseComplemento.Append("</tr>")

                    strRecordBrowseComplemento.Append("<tr>")
                    strRecordBrowseComplemento.Append("<td colspan='4' width='100%'>")
                    strRecordBrowseComplemento.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
                    strRecordBrowseComplemento.Append("<tr>")
                    strRecordBrowseComplemento.Append("<td width='63'  class='tdtittablas'>Sucursal:</td>")
                    strRecordBrowseComplemento.Append("<td width='190' valign='middle' class='tdconttablas'>" & strCentroLogisticoId & " - " & strSucursalNombre & " (" & intCompaniaId.ToString & intSucursalId.ToString("000") & ")" & "</td>")
                    strRecordBrowseComplemento.Append("<td width='84'  valign='middle' class='tdtittablas'>Fecha y hora:</td>")
                    strRecordBrowseComplemento.Append("<td width='231' valign='middle' class='tdconttablas'>" & clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") & "</td><br>")
                    strRecordBrowseComplemento.Append("</tr>")
                    strRecordBrowseComplemento.Append("</table>")
                    strRecordBrowseComplemento.Append("</tr>")

                    strRecordBrowseComplemento.Append("<tr>")

                    strRecordBrowseComplemento.Append("<td colspan='4' width='100%'>")
                    strRecordBrowseComplemento.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

                    strRecordBrowseComplemento.Append("<tr>")
                    strRecordBrowseComplemento.Append("<td width='52%' class='tdtittablasazul'>" & "" & "</td>")
                    strRecordBrowseComplemento.Append("<td width='48%' align='right' class='tdtittablas'>Folio:______________&nbsp;&nbsp;&nbsp;&nbsp; Fecha: ___________</td>")
                    strRecordBrowseComplemento.Append("<td></td>")
                    strRecordBrowseComplemento.Append("<td></td>")
                    strRecordBrowseComplemento.Append("</tr>")

                    strRecordBrowseComplemento.Append("<tr>")
                    strRecordBrowseComplemento.Append("<td colspan='4' width='100%' class='tdtittablas'>Sucursal que recibe:_________________________</td>")
                    strRecordBrowseComplemento.Append("</tr>")

                    strRecordBrowseComplemento.Append("</table>")
                    strRecordBrowseComplemento.Append("</td>")

                    strRecordBrowseComplemento.Append("</tr>")

                    strRecordBrowseComplemento.Append("<tr class='trtitulos'>")
                    strRecordBrowseComplemento.Append("<th width='58' class='rayita'>&nbsp;</th>")
                    strRecordBrowseComplemento.Append("<th width='338' class='rayita'>Articulo</th>")
                    strRecordBrowseComplemento.Append("<th width='77' class='rayita'>Cantidad</th>")
                    strRecordBrowseComplemento.Append("<th width='98' class='rayita'>Precio venta</th>")
                    strRecordBrowseComplemento.Append("</tr>")

                    intRenglon = 0
                End If

            Next

            strRecordBrowseComplemento.Append("</table>")
            strRecordBrowseComplemento.Append("<br>")

            strRecordBrowserHTML = strRecordBrowseComplemento.ToString

        End If


    End Sub

End Class
