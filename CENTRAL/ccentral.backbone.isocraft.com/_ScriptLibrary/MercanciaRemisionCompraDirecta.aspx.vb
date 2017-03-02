Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text
Imports System.IO
Imports System.Collections

Public Class clsMercanciaRemisionCompraDirecta
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


    Const strComitasDobles As String = """"
    Public strListaArchivosGuias As String

    '====================================================================
    ' Name       : strRedirectPage
    ' Description: Página hacia la cual se debe redireccionar al usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRedirectPage() As String
        Get
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
    ' Name       : strPATHFactura
    ' Description: Valor que tomara la variable strPATHFactura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strPATHFactura() As String
        Get

            Return ConfigurationSettings.AppSettings("strPATHFactura")

        End Get
    End Property


    '====================================================================
    ' Name       : strSerieRemision
    ' Description: Valor que tomara la variable strSerieRemision
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSerieRemision() As String
        Get
            If Not IsNothing(Request("txtSerieRemision")) Then
                Return (Request("txtSerieRemision"))
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strNumeroRemisionn
    ' Description: Valor que tomara la variable strNumeroRemisionn
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strNumeroRemision() As String
        Get
            If Not IsNothing(Request("txtNumeroRemision")) Then
                Return (Request("txtNumeroRemision"))
            Else
                Return ""
            End If
        End Get
    End Property


    '====================================================================
    ' Name       : strListaFacturasHTML
    ' Description: Genera Listado de facturas
    '              
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strListaFacturasHTML() As String

        Dim objArchivos() As String
        Dim strArchivo As String
        Dim archivoInfo As FileInfo

        Dim objGuiaRegistro() As String
        Dim objGuiaLista As New ArrayList
        Dim objGuia As Array

        Dim strHTML As New StringBuilder
        Dim intConsecutivo As Integer = 0
        Dim strColorRegistro As String = ""
        Dim intPosicionSerie As Integer = 0


        Try
            objArchivos = Directory.GetFiles(strPATHFactura, "*.PDF")

            For Each strArchivo In objArchivos

                archivoInfo = New FileInfo(strArchivo)

                If (Len(strSerieRemision) > 1 Or Len(strNumeroRemision) > 1) And InStr(archivoInfo.Name(), strSerieRemision, CompareMethod.Text) > 0 And InStr(archivoInfo.Name(), strNumeroRemision, CompareMethod.Text) > 0 Then

                    intPosicionSerie = InStr(archivoInfo.Name(), strSerieRemision, CompareMethod.Text)


                    objGuiaRegistro = New String(2) {}

                    objGuiaRegistro(0) = archivoInfo.Name()
                    objGuiaRegistro(1) = Right(archivoInfo.Name(), 40)

                    objGuiaLista.Add(objGuiaRegistro)

                End If

            Next

            ' Convertimos la lista de Archivos a un arreglo
            objGuia = objGuiaLista.ToArray

        Catch e As Exception
            objGuia = Nothing
        End Try

        strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        strHTML.Append("<tr class='trtitulos'>")
        strHTML.Append("<th width='05%' class='rayita' align='right' >No.</th>")
        strHTML.Append("<th width='65%' class='rayita' align='left'  >FACTURA</th>")
        strHTML.Append("<th width='30%' class='rayita' align='center'>Accion</th>")
        strHTML.Append("</tr>")

        If IsArray(objGuia) AndAlso objGuia.Length > 0 Then

            For Each objGuiaRegistro In objGuia

                intConsecutivo += 1

                If (intConsecutivo Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If

                strHTML.Append("<tr>")
                strHTML.Append("<td class=" & strColorRegistro & " align='right' >" & intConsecutivo.ToString & "</td>")
                strHTML.Append("<td class=" & strColorRegistro & " align='left'  >" & clsCommons.strFormatearDescripcion(objGuiaRegistro(1)).ToString & "</td>")
                strHTML.Append("<td class=" & strColorRegistro & " align='center'>" & "<a href='javascript:strImprimeFactura(" & strComitasDobles & objGuiaRegistro(0).ToString & strComitasDobles & ");'><img src='../static/images/icono_imprimir.gif' alt='Imprimir Guia' width='18' height='13' border='0' align='absmiddle'></a></td>")
                strHTML.Append("</tr>")

            Next

        Else

            strHTML.Append("<tr>")
            strHTML.Append("<td class='tdblanco' colspan='3'>No hay registros</td>")
            strHTML.Append("</tr>")

        End If

        strHTML.Append("</table>")

        Return strHTML.ToString

    End Function


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
