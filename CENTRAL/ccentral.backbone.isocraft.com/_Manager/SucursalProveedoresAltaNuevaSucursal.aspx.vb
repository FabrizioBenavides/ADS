Imports Benavides.CC.Data

Imports System.Text
Imports System.Collections

Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

Public Class SucursalProveedoresAltaNuevaSucursal
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtArticulosArchivo As System.Web.UI.HtmlControls.HtmlInputFile

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        'Put user code to initialize the page here
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

    End Sub

#End Region

#Region " Class Private Attributes"

    Const strComitasDobles As String = """"

    Private strmJavascriptWindowOnLoadCommands As String


    Private strmRecordBrowserHTML As String = ""


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
    ' Description: Genera la fecha y hora de la página
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
    ' Name       : strCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return GetPageParameter("strCmd", "")
        End Get
    End Property

    '====================================================================
    ' Name       : strSucursalEspejoId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalEspejoId() As String
        Get
            Return Request("hdnSucursalEspejoId")
        End Get

    End Property

    '====================================================================
    ' Name       : intCompaniaEspejoId
    ' Description: Value of a HTML form field
    ' Accessor   : Read 
    ' Output     : integer
    '====================================================================
    Public ReadOnly Property intCompaniaEspejoId() As Integer
        Get
            Dim intmCompaniaid As Integer = 0

            If Len(strSucursalEspejoId) > 3 Then

                Dim astrCompaniaSucursal As Array = Split(strSucursalEspejoId, "|")

                If astrCompaniaSucursal.Length > 0 Then
                    intmCompaniaid = CInt(astrCompaniaSucursal.GetValue(0))
                End If
            End If

            Return intmCompaniaid

        End Get

    End Property

    '====================================================================
    ' Name       : intSucursalEspejoId
    ' Description: Value of a HTML form field
    ' Accessor   : Read 
    ' Output     : integer
    '====================================================================
    Public ReadOnly Property intSucursalEspejoId() As Integer
        Get
            Dim intmSucursalid As Integer = 0

            If Len(strSucursalEspejoId) > 3 Then

                Dim astrCompaniaSucursal As Array = Split(strSucursalEspejoId, "|")
                If astrCompaniaSucursal.Length > 0 Then
                    intmSucursalid = CInt(astrCompaniaSucursal.GetValue(1))
                End If

            End If

            Return intmSucursalid

        End Get

    End Property


    '====================================================================
    ' Name       : strSucursalNuevaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalNuevaId() As String
        Get
            Return Request("hdnSucursalNuevaId")
        End Get

    End Property

    '====================================================================
    ' Name       : intCompaniaNuevaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : integer
    '====================================================================
    Public ReadOnly Property intCompaniaNuevaId() As Integer
        Get
            Dim intmCompaniaid As Integer = 0

            If Len(strSucursalNuevaId) > 3 Then
                Dim astrCompaniaSucursal As Array = Split(strSucursalNuevaId, "|")
                If astrCompaniaSucursal.Length > 0 Then
                    intmCompaniaid = CInt(astrCompaniaSucursal.GetValue(0))
                End If
            End If

            Return intmCompaniaid

        End Get

    End Property

    '====================================================================
    ' Name       : intSucursalNuevaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : integer
    '====================================================================
    Public ReadOnly Property intSucursalNuevaId() As Integer
        Get
            Dim intmSucursalid As Integer = 0

            If Len(strSucursalNuevaId) > 3 Then
                Dim astrCompaniaSucursal As Array = Split(strSucursalNuevaId, "|")
                If astrCompaniaSucursal.Length > 0 Then
                    intmSucursalid = CInt(astrCompaniaSucursal.GetValue(1))
                End If
            End If

            Return intmSucursalid

        End Get

    End Property


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        Select Case strCmd

            Case "AgregarProveedor"

                Dim intContadorAlta As Integer = 0
                Dim intErrorAgregar As Integer = 0

                Dim strHTML As New StringBuilder


                intContadorAlta = clsProveedor.intCopiarProveedorSucursalesAsignadas(intCompaniaEspejoId, intSucursalEspejoId, intCompaniaNuevaId, intSucursalNuevaId, 1, strUsuarioNombre, strConnectionString)

                If intContadorAlta < 0 Then

                    intErrorAgregar = -100 'Error al copiar los proveedores de la sucursal espejo

                End If


                strHTML.Append("<script language='Javascript'> parent.fnUpAgregarProveedores( " & _
                           strComitasDobles & intErrorAgregar.ToString & strComitasDobles & "," & _
                           strComitasDobles & intContadorAlta.ToString & strComitasDobles & _
                           "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

        End Select




    End Sub

End Class
