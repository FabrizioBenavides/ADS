Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports System.Text



Public Class SistemaControlCteABFACtivaBloquea
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    'Protected WithEvents lblClienteSAPId As System.Web.UI.WebControls.Label
    'Protected WithEvents lblClienteABFId As System.Web.UI.WebControls.Label
    'Protected WithEvents lblClienteInstEdit As System.Web.UI.WebControls.Label
    'Protected WithEvents chkActivo As System.Web.UI.WebControls.CheckBox
    'Protected WithEvents chkCredDisp As System.Web.UI.WebControls.CheckBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        strbuscaCliente = GetPageParameter("strbuscaCliente", GetPageParameter("txtbuscaCliente", ""))


    End Sub

#End Region

#Region " Class Private Attributes"

    Private blnmClienteActivo As Boolean
    Private blnmClienteExcedidoEnLimiteCredito As Boolean
    Private strmJavascriptWindowOnLoadCommands As String
    Private intmtxtGrupoClienteEspecialId As Integer

    Private strmbuscaCliente As String


#End Region

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
    ' Name       : strCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strHTMLFechaHora
    ' Description: Genera la fecha y hora de la p�gina
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
        End Get
    End Property

    '====================================================================
    ' Name       : strbuscaCliente
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : string
    '====================================================================
    Public Property strbuscaCliente() As String
        Get
            Return strmbuscaCliente
        End Get
        Set(ByVal strValue As String)
            strmbuscaCliente = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strClienteSAPId
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strClienteSAPId() As String
        Get
            Return GetPageParameter("strClienteSAPId", "")
        End Get
    End Property

    '====================================================================
    ' Name       : strClienteSAPId
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strClienteABFId() As String
        Get
            Return GetPageParameter("strClienteABFId", "")
        End Get
    End Property

    '====================================================================
    ' Name       : strClienteSAPId
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strClienteNombre() As String
        Get
            Return GetPageParameter("strClienteNombre", "")
        End Get
    End Property

    '====================================================================
    ' Name       : blnClienteActivo
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : Boolean
    '====================================================================
    Public Property blnClienteActivo() As Boolean
        Get
            If blnmClienteActivo = Nothing Then
                blnmClienteActivo = CBool(isocraft.commons.clsWeb.strGetPageParameter("blnClienteActivo", "0"))
            End If
            Return blnmClienteActivo
        End Get
        Set(ByVal blnValue As Boolean)
            blnmClienteActivo = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnClienteActivo
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : Boolean
    '====================================================================
    Public Property blnClienteExcedidoEnLimiteCredito() As Boolean
        Get
            If blnmClienteExcedidoEnLimiteCredito = Nothing Then
                blnmClienteExcedidoEnLimiteCredito = CBool(isocraft.commons.clsWeb.strGetPageParameter("blnClienteExcedidoEnLimiteCredito", "0"))
            End If
            Return blnmClienteExcedidoEnLimiteCredito
        End Get
        Set(ByVal blnValue As Boolean)
            blnmClienteExcedidoEnLimiteCredito = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : strGetRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String
        Dim strc As String = """"


        ' Declaramos e inicializamos las variables locales

        Dim objDataArray As Array = Benavides.CC.Data.clstblClienteVentasInstitucionales.strBuscar(strbuscaCliente, strConnectionString)

        Dim objRegistroDataArray As New System.Collections.SortedList
        Dim strRecordBrowserHTML As New System.Text.StringBuilder

        If IsArray(objDataArray) AndAlso objDataArray.Length > 0 Then

            Dim intContadorRegistros As Integer = 0
            Dim strColorRegistro As String = ""
            Dim strSAPId As String
            Dim strABFId As String
            Dim strNombre As String

            strRecordBrowserHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

            strRecordBrowserHTML.Append("<tr class='trtitulos'>")
            strRecordBrowserHTML.Append("<th  class='rayita'>&nbsp;</th>")
            strRecordBrowserHTML.Append("<th  class='rayita'>SAP</th>")
            strRecordBrowserHTML.Append("<th  class='rayita'>ABF</th>")
            strRecordBrowserHTML.Append("<th  class='rayita'>Nombre</th>")
            strRecordBrowserHTML.Append("<th  class='rayita'>Activo</th>")
            strRecordBrowserHTML.Append("<th  class='rayita' align='center'>Excedido Limite de Credito</th>")
            strRecordBrowserHTML.Append("<th  class='rayita'>Acciones</th>")
            strRecordBrowserHTML.Append("</tr>")


            For Each objRegistroDataArray In objDataArray
                intContadorRegistros += 1

                If (intContadorRegistros Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If

                strSAPId = "&nbsp;"
                strABFId = "&nbsp;"
                strNombre = "&nbsp;"


                If Len(Trim(CStr(objRegistroDataArray.Item("strClienteSAPId")))) > 0 Then
                    strSAPId = Benavides.POSAdmin.Commons.clsCommons.strFormatearDescripcion(CStr(objRegistroDataArray.Item("strClienteSAPId")))
                End If

                If Len(Trim(CStr(objRegistroDataArray.Item("strClienteABFId")))) > 0 Then
                    strABFId = Benavides.POSAdmin.Commons.clsCommons.strFormatearDescripcion(CStr(objRegistroDataArray.Item("strClienteABFId")))
                End If

                If Len(Trim(CStr(objRegistroDataArray.Item("strClienteNombre")))) > 0 Then
                    strNombre = Benavides.POSAdmin.Commons.clsCommons.strFormatearDescripcion(CStr(objRegistroDataArray.Item("strClienteNombre")))
                End If

                strRecordBrowserHTML.Append("<tr>")
                strRecordBrowserHTML.Append("<td class=" & strColorRegistro & ">" & intContadorRegistros.ToString & "</td>")
                strRecordBrowserHTML.Append("<td class=" & strColorRegistro & ">" & strSAPId & "</td>")
                strRecordBrowserHTML.Append("<td class=" & strColorRegistro & ">" & strABFId & "</td>")
                strRecordBrowserHTML.Append("<td class=" & strColorRegistro & ">" & strNombre & "</td>")
                'strRecordBrowserHTML.Append("<td class=" & strColorRegistro & ">" & Benavides.POSAdmin.Commons.clsCommons.strFormatearDescripcion(CStr(objRegistroDataArray.Item("blnClienteActivo"))).Replace("True", "S�").Replace("False", "No") & "</td>")
                strRecordBrowserHTML.Append("<td class=" & strColorRegistro & " align=center>" & "<input class=fieldborderless id=chkClienteActivo" & intContadorRegistros.ToString & " type=checkbox name=chkClienteActivo" & intContadorRegistros.ToString & " disabled=true " & CStr(objRegistroDataArray.Item("blnClienteActivo")).Replace("True", "checked").Replace("False", "") & "></td>")
                strRecordBrowserHTML.Append("<td class=" & strColorRegistro & " align=center>" & "<input class=fieldborderless id=chkClienteExcedidoEnLimiteCredito" & intContadorRegistros.ToString & " type=checkbox name=chkClienteExcedidoEnLimiteCredito" & intContadorRegistros.ToString & " disabled=true " & CStr(objRegistroDataArray.Item("blnClienteExcedidoEnLimiteCredito")).Replace("True", "checked").Replace("False", "") & "></td>")
                strRecordBrowserHTML.Append("<td class=" & strColorRegistro & " align=center>" & "<a href='SistemaControlCteABFACtivaBloquea.aspx?strCmd=Editar" & _
                "&strbuscaCliente=" & strbuscaCliente & _
                "&strClienteSAPId=" & strSAPId & _
                "&strClienteABFId=" & strABFId & _
                "&strClienteNombre=" & strNombre & _
                "&blnClienteActivo=" & CStr(objRegistroDataArray.Item("blnClienteActivo")).Replace("True", "1").Replace("False", "0") & _
                "&blnClienteExcedidoEnLimiteCredito=" & CStr(objRegistroDataArray.Item("blnClienteExcedidoEnLimiteCredito")).Replace("True", "1").Replace("False", "0") & _
                 "'><img src='../static/images/icono_editar.gif' width='11' height='13' border='0' align='absMiddle' alt = 'Haga clic aqu� para editar la disponibilidad del cliente'></a></td>")
                strRecordBrowserHTML.Append("</tr>")

            Next

            strRecordBrowserHTML.Append("</table>")

        End If

        Return strRecordBrowserHTML.ToString

    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Declarar variables
        Dim intResultado As Integer
        Dim strResultado As Array

        ' Enviamos al usuario actual a la p�gina de acceso, si no tiene privilegios de acceder a esta p�gina
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Execute the selected command
        Select Case strCmd

            Case "Guardar"

                intResultado = Benavides.CC.Data.clstblClienteVentasInstitucionales.intActualizar(strClienteSAPId, strClienteABFId, strClienteNombre, blnClienteActivo, blnClienteExcedidoEnLimiteCredito, strConnectionString)

                Response.Redirect("SistemaControlCteABFACtivaBloquea.aspx?" & "strbuscaCliente=" & strbuscaCliente)

        End Select

    End Sub

End Class
