Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
'Imports Benavides.POSAdmin.Data
Imports Benavides.POSAdmin.Commons.clsCommons.clsMSMQ
Imports Benavides.CC.Data.clsPromociones
Imports System.Text
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert

Public Class SucursalSenalizacionBusquedaPromocionesTextoPromocion
    Inherits System.Web.UI.Page

    Private strmPromocion As String = String.Empty
    Private strmRutaImagen As String = String.Empty
    Private strmNombre As String = String.Empty

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

    Private strmJavascriptWindowOnLoadCommands As String


    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", String.Empty, Request, Server)
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
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request)
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
    ' Name       : strPromocion
    ' Description: Descripcion de la promocion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strPromocion() As String
        Get
            Return strmPromocion
        End Get
        Set(ByVal Value As String)
            strmPromocion = Value

        End Set
    End Property


    '====================================================================
    ' Name       : strFormato
    ' Description: Formato de la promocion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormato() As String
        Get
            If idFormato = "1" Then
                Return "1x1"
            ElseIf idFormato = "2" Then
                Return "1x3"
            ElseIf idFormato = "3" Then
                Return "1x4"
            ElseIf idFormato = "4" Then
                Return "1x6"
            End If
        End Get
    End Property


    '====================================================================
    ' Name       : strRutaImagen
    ' Description: Ruta de la imagen
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRutaImagen() As String
        Get
            Return strmRutaImagen
        End Get
        Set(ByVal Value As String)
            strmRutaImagen = Value

        End Set
    End Property

    '====================================================================
    ' Name       : strNombreImagen
    ' Description: Nombre de la imagen ligada a la promocion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strNombreImagen() As String
        Get
            Return strmNombre
        End Get
        Set(ByVal Value As String)
            strmNombre = Value

        End Set
    End Property

    '====================================================================
    ' Name       : intPromocionCodigo
    ' Description: Numero identificador de la promocion a mostrar.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intPromocionCodigo() As String
        Get
            If Not IsNothing(Request.QueryString("intPromocionCodigo")) Then 'And IsNumeric(Request.QueryString("intPromocionCodigo")) Then
                Return Request.QueryString("intPromocionCodigo")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : idFormato
    ' Description: Id del Formato de la promocion.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property idFormato() As String
        Get
            If Not IsNothing(Request.QueryString("idFormato")) Then
                Return Request.QueryString("idFormato")
            End If
        End Get
    End Property


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaracion de Variables
        Dim objArrayPromociones As Array
        Dim strRegistroPromocion As String()
        Dim intConsecutivo As Integer

        objArrayPromociones = Nothing

        'Obtenemos el detalle de la promocion
        objArrayPromociones = Benavides.CC.Data.clsPromociones.strBuscarDetallePromocionSenalizacion(CInt(intPromocionCodigo), CInt(idFormato), strConnectionString)

        If IsArray(objArrayPromociones) AndAlso objArrayPromociones.Length > 0 Then

            intConsecutivo += 1
            Dim rutaImagenes As String = System.Configuration.ConfigurationSettings.AppSettings("strImagenesPromociones")

            For Each strRegistroPromocion In objArrayPromociones

                'Detalle de la Promocion
                strmPromocion = Trim(CStr(strRegistroPromocion(1)))
                strmNombre = Trim(CStr(strRegistroPromocion(5)))

                If strmNombre = String.Empty Then
                    strmNombre = "(Sin imagen)"
                Else
                    strRutaImagen = String.Format("{0}?id={1}&IdFormato={2}", rutaImagenes, strRegistroPromocion(0), idFormato)
                End If
            Next
        End If
    End Sub

End Class
