Imports Isocraft.Web.Http
Imports System.Text
Imports System.Configuration

Imports Benavides.CC.Data
Imports Benavides.POSAdmin.Commons

Public Class popVentasPromocionesMonederoAgregar
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
    ' Name       : blnAgregarPromocion 
    ' Description: blnAgregarPromocion
    ' Accessor   : Read
    ' Output     : byte
    '====================================================================
    Public ReadOnly Property blnAgregarPromocion() As Byte
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("blnAgregarPromocion"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CByte(strTemporal)
            End If

        End Get

    End Property

    Public ReadOnly Property txtPromocionNombre() As String
        Get
            Return Request("txtPromocionNombre")
        End Get
    End Property

    Public ReadOnly Property blnPromocionEsPorArticulo() As Byte
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("txtTipoPromocion"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CByte(strTemporal)
            End If

        End Get
    End Property

    Public ReadOnly Property txtPromocionInicio() As String
        Get
            Return Request("txtPromocionInicio")
        End Get
    End Property

    Public ReadOnly Property txtPromocionFin() As String
        Get
            Return Request("txtPromocionFin")
        End Get
    End Property


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Select Case strCmd

            Case "AgregarPromocion"

                Dim strHTML As New StringBuilder

                Dim intError As Integer = 0
                Dim intResultado As Integer = 0

                Dim strTipoPromocion As String = ""
                Dim strEstadoPromocion As String = "ACTIVA"
                Dim blnPromocionActiva As Byte = 1
                
                If blnPromocionEsPorArticulo = 1 Then
                    strTipoPromocion = "ARTICULO"
                Else
                    strTipoPromocion = "CATEGORIA"
                End If

                intResultado = clsPromocionMonedero.intActualizarAgregarPromocionMonedero(0, txtPromocionNombre, CDate(clsCommons.strDMYtoMDY(txtPromocionInicio)), CDate(clsCommons.strDMYtoMDY(txtPromocionFin)), blnPromocionActiva, blnPromocionEsPorArticulo, blnAgregarPromocion, strUsuarioNombre, strConnectionString)

                If intResultado < 1 Then
                    intError = intResultado
                    intResultado = 0
                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpdPromocionPorIframe( " & _
                strComitasDobles & intError.ToString & strComitasDobles & "," & _
                strComitasDobles & intResultado.ToString & strComitasDobles & "," & _
                strComitasDobles & txtPromocionNombre & strComitasDobles & "," & _
                strComitasDobles & txtPromocionInicio & strComitasDobles & "," & _
                strComitasDobles & txtPromocionFin & strComitasDobles & "," & _
                strComitasDobles & strTipoPromocion & strComitasDobles & "," & _
                strComitasDobles & strEstadoPromocion & strComitasDobles & _
                "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()
        End Select

    End Sub

End Class
