'====================================================================
' Page          : MercanciaGuiaDevolucion.aspx
' Title         : Administracion POS y BackOffice
' Description   : 
' Copyright     : 2011 All rights reserved.
' Company       :  
' Author        : J.Antonio Hernández Dávila
' Version       : 1.0
' Last Modified : 20 Abril 2011
'====================================================================

Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text
Imports System.DateTime
Imports System.IO
Imports System.Collections


Public Class MercanciaGuiaDevolucion
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
    ' Name       : strCentroLogisticoId
    ' Description: Centro logistico de la Sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCentroLogisticoId() As String
        Get
            Return clsCommons.strReadCookie("strCentroLogisticoId", "", Request, Server)
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
    ' Name       : strPATHGuias
    ' Description: Valor que tomara la variable strPATHGuias
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strPATHGuias() As String
        Get

            Return ConfigurationSettings.AppSettings("strPATHGuias")

        End Get
    End Property

    '====================================================================
    ' Name       : strPatternGuias
    ' Description: Valor que tomara la variable strPatternGuias
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strPatternGuias() As String
        Get

            Return ConfigurationSettings.AppSettings("strPatternGuias")

        End Get
    End Property

    Public ReadOnly Property strArchivo() As String
        Get
            If Not IsNothing(Request.QueryString("strArchivo")) Then
                Return (Request.QueryString("strArchivo"))
            Else
                Return ""
            End If
        End Get
    End Property


    '====================================================================
    ' Name       : strGuiasDevolucionHTML
    ' Description: Genera Listado de guias
    '              
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGuiasDevolucionHTML() As String

        Dim objArchivos() As String
        Dim strArchivo As String
        Dim archivoInfo As FileInfo

        Dim objGuiaRegistro() As String
        Dim objGuiaLista As New ArrayList
        Dim objGuia As Array

        Dim strHTML As New StringBuilder
        Dim intConsecutivo As Integer = 0
        Dim strColorRegistro As String = ""

        Try
            objArchivos = Directory.GetFiles(strPATHGuias, strPatternGuias & strCentroLogisticoId & "_*")

            For Each strArchivo In objArchivos

                archivoInfo = New FileInfo(strArchivo)

                objGuiaRegistro = New String(0) {}

                objGuiaRegistro(0) = archivoInfo.Name()

                objGuiaLista.Add(objGuiaRegistro)
            Next

            ' Convertimos la lista de Archivos a un arreglo
            objGuia = objGuiaLista.ToArray

        Catch e As Exception
            objGuia = Nothing
        End Try

        strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        strHTML.Append("<tr class='trtitulos'>")
        strHTML.Append("<th width='05%' class='rayita' align='right' >No.</th>")
        strHTML.Append("<th width='65%' class='rayita' align='left'  >Guia</th>")
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
                strHTML.Append("<td class=" & strColorRegistro & " align='left'  >" & clsCommons.strFormatearDescripcion(objGuiaRegistro(0)).ToString & "</td>")
                strHTML.Append("<td class=" & strColorRegistro & " align='center'>" & "<a href='javascript:strImprimeGuia(" & strComitasDobles & objGuiaRegistro(0).ToString & strComitasDobles & ");'><img src='../static/images/icono_imprimir.gif' alt='Imprimir Guia' width='18' height='13' border='0' align='absmiddle'></a></td>")
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        strListaArchivosGuias = strGuiasDevolucionHTML()

    End Sub

End Class
