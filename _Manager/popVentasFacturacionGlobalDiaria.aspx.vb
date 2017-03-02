Imports Isocraft.Web.Http
Imports System.Text
Imports System.Configuration
Imports Benavides.CC.Data
Imports Benavides.CC.Commons
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business.clsConcentrador.clsSucursal

Public Class popVentasFacturacionGlobalDiaria
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
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

    End Sub

#End Region

#Region " Class Private Attributes"

    Const strComitasDobles As String = """"
    Private strmJavascriptWindowOnLoadCommands As String


#End Region

    '====================================================================
    ' Name       : intGrupoUsuarioId
    ' Description: Identificador del Grupo de Usuario
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intGrupoUsuarioId() As Integer
        Get
            Return CInt(Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strHTMLFechaHora
    ' Description: Genera la fecha y hora de la página
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
        End Get
    End Property

    '====================================================================
    ' Name       : strFormAction
    ' Description: HTML form's action property value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormAction() As String
        Get
            Return strThisPageName
        End Get
    End Property

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Connection string
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Private ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: Name of this page
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return Server.UrlEncode(GetPageName())
        End Get
    End Property

    '====================================================================
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strJavascriptWindowOnLoadCommands() As String
        Get
            Return strmJavascriptWindowOnLoadCommands
        End Get
        Set(ByVal strValue As String)
            strmJavascriptWindowOnLoadCommands = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strAccion
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strAccion() As String
        Get
            Return Request("strAccion")
        End Get
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return Request("strCmd")
        End Get
    End Property


    '====================================================================
    ' Name       : intCadenaId
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : integer
    '====================================================================
    Public ReadOnly Property intCadenaId() As Integer
        Get
            Dim intValor As Integer

            If Len(Request("intCadenaId")) > 0 Then
                intValor = CInt(Request("intCadenaId"))
            Else
                intValor = 0
            End If

            Return intValor

        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaVenta
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaVentaMDY() As Date
        Get

            Dim strTemporal As String
            Dim dtmValor As Date

            strTemporal = Trim(Request("strFechaVenta"))

            If strTemporal.Equals("") Then
                dtmValor = CDate("01/01/1900")
            Else
                dtmValor = CDate(clsCommons.strDMYtoMDY(strTemporal))
            End If

            Return dtmValor

        End Get

    End Property

    '====================================================================
    ' Name       : intTipoDetalle
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : integer
    '====================================================================
    Public ReadOnly Property intTipoDetalle() As Integer
        Get
            Dim intValor As Integer

            If Len(Request("intTipoDetalle")) > 0 Then
                intValor = CInt(Request("intTipoDetalle"))
            Else
                intValor = 0
            End If

            Return intValor

        End Get
    End Property

    Public ReadOnly Property strTituloConsulta() As String
        Get
            Select Case intTipoDetalle
                Case 0
                    Return "Sucursales"
                Case 1
                    Return "Sucursales sin Trasmitir"
                Case 2
                    Return "Sucursales Trasmitidas"
            End Select

        End Get

    End Property


    '====================================================================
    ' Name       : strConsultar
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strConsultar() As String

        Dim objFacturaSucursalGlobalDetalle As Array = clsFacturaSucursalGlobal.strBuscarDetalle(intCadenaId, dtmFechaVentaMDY, intTipoDetalle, strConnectionString)
        Dim objRegistroFacturaSucursalGlobalDetalle As System.Collections.SortedList = Nothing

        Dim strHTML As New StringBuilder
        Dim intConsecutivo As Integer = 0
        Dim strColorRegistro As String = ""

        If IsArray(objFacturaSucursalGlobalDetalle) AndAlso objFacturaSucursalGlobalDetalle.Length > 0 Then

            strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strHTML.Append("<tr class='trtitulos'>")
            strHTML.Append("<th width='05%' class='rayita' align='left'>No.</th>")
            strHTML.Append("<th width='15%' class='rayita' align='left'>Sucursal</th>")
            strHTML.Append("<th width='30%' class='rayita' align='left'>Nombre</th>")
            strHTML.Append("<th width='20%' class='rayita' align='left'>Apertura</th>")
            strHTML.Append("<th width='20%' class='rayita' align='left'>Cierre</th>")
            strHTML.Append("<th width='10%' class='rayita' align='left'>Trasmision</th>")
            strHTML.Append("</tr>")

            For Each objRegistroFacturaSucursalGlobalDetalle In objFacturaSucursalGlobalDetalle

                intConsecutivo += 1

                If (intConsecutivo Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If

                strHTML.Append("<tr>")
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & intConsecutivo.ToString & "</td>") ' No

                With objRegistroFacturaSucursalGlobalDetalle
                    strHTML.Append("<td class=" & strColorRegistro & " align='left'> " & clsCommons.strFormatearDescripcion(CStr(.Item("strCentroLogisticoId"))) & "</td>")
                    strHTML.Append("<td class=" & strColorRegistro & " align='left'> " & clsCommons.strFormatearDescripcion(CStr(.Item("strSucursalNombre"))) & "</td>")
                    strHTML.Append("<td class=" & strColorRegistro & " align='left'> " & clsCommons.strFormatearFechaPresentacion(CStr(.Item("dtmSucursalFechaApertura"))) & "</td>")

                    If CStr(.Item("dtmSucursalFechaCierreLocal")) = "1/1/1900" Then
                        strHTML.Append("<td class=" & strColorRegistro & " align='left'>&nbsp;</td>")
                    Else
                        strHTML.Append("<td class=" & strColorRegistro & " align='left'> " & clsCommons.strFormatearFechaPresentacion(CStr(.Item("dtmSucursalFechaCierreLocal"))) & "</td>")
                    End If

                    If CBool(.Item("blnFaltante")) Then
                        strHTML.Append("<td class=" & strColorRegistro & " align='left'>NO</td>")
                    Else
                        strHTML.Append("<td class=" & strColorRegistro & " align='left'>SI</td>")
                    End If
                End With

                strHTML.Append("</tr>")

            Next

            strHTML.Append("</table>")


        End If

        Return strHTML.ToString

    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

End Class

