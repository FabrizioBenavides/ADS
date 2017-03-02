Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration
Imports Isocraft.Web.Http


Public Class PopPromocionesCupones
    Inherits System.Web.UI.Page

    Private strmJavascriptWindowOnLoadCommands As String
    Private blnmSucursal As Boolean

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
    ' Name       : blnSucursal
    ' Description: Bandera para buscar articulos en todas las sucursales
    ' Accessor   : Read/Write
    ' Throws     : Ninguna
    ' Output     : Boolean
    '====================================================================
    Public Property blnSucursal() As Boolean
        Get
            Return blnmSucursal
        End Get
        Set(ByVal blnValue As Boolean)
            blnmSucursal = blnValue
        End Set
    End Property


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
    ' Name       : strPromocionIdNombre
    ' Description: Código de la promocion o cadena de caracteres a Buscar.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strPromocionIdNombre() As String
        Get
            Return Request.QueryString("strPromocionIdNombre")
        End Get
    End Property

    '====================================================================
    ' Name       : intTipoPromocionId
    ' Description: Código de la promocion o cadena de caracteres a Buscar.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTipoPromocionId() As Integer
        Get
            '0 = Todas
            '1 = Ofertas
            '2 = Promociones
            '3 = Cupones

            If Not IsNothing(Request.QueryString("intTipoPromocionId")) Then
                Return CInt(Request.QueryString("intTipoPromocionId"))
            Else
                Return 0
            End If

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
    ' Name       : strRecordBrowserHTML
    ' Description: Genera el Record Browser para mostrar las promociones
    '              de acuerdo a su descripcion.
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String

        ' Declaracion de Variables
        Dim objPromocionDescripcion As Array
        Dim strPromocionHTML As StringBuilder
        Dim strPromocion As String()
        Dim intConsecutivo As Integer
        Dim strColorRegistro As String
        Dim blnUnSoloRegistro As Boolean = False

        'Inicializacion de Variables
        strPromocionHTML = New StringBuilder
        strPromocion = Nothing
        intConsecutivo = 0
        strJavascriptWindowOnLoadCommands = String.Empty

        If intTipoPromocionId = 1 Then

            'Ofertas
            objPromocionDescripcion = Benavides.CC.Data.clsConsultarPromociones.strBuscarPopOfertasCupones(strPromocionIdNombre, strCadenaConexion)

        ElseIf intTipoPromocionId = 2 Then

            'Promociones
            objPromocionDescripcion = Benavides.CC.Data.clsConsultarPromociones.strBuscarPopPromocionesCupones(strPromocionIdNombre, strCadenaConexion)

        ElseIf intTipoPromocionId = 3 Then

            'Cupones
            objPromocionDescripcion = Benavides.CC.Data.clsConsultarPromociones.strBuscarPopCupones(strPromocionIdNombre, strCadenaConexion)

        End If
        If blnSucursal = True Then

            ' Obtenemos la información de las Promociones
            'objPromocionDescripcion = clsConcentrador.clsSucursal.strBuscarArticulo(intCompaniaId, intSucursalId, strPromocionIdNombre, 100, 100, strCadenaConexion)
            'objPromocionDescripcion = Benavides.CC.Data.clsPromociones.strBuscarPromociones(strPromocionIdNombre, strCadenaConexion)
            'objPromocionDescripcion = Benavides.CC.Data.clsConsultarPromociones.strBuscarPopPromocionesCupones(strPromocionIdNombre, strCadenaConexion)
        Else

            ' Obtenemos la información de las Promociones
            'objPromocionDescripcion = clsConcentrador.clsSucursal.strBuscarArticulo(0, 0, strPromocionIdNombre, 100, 100, strCadenaConexion)
            'objPromocionDescripcion = Benavides.CC.Data.clsConsultarPromociones.strBuscarPopPromocionesCupones(strPromocionIdNombre, strCadenaConexion)

            ' Indicamos si el resultado solo arrojó 1 registro
            If IsArray(objPromocionDescripcion) = True Then

                blnUnSoloRegistro = (objPromocionDescripcion.Length = 1)

            End If

        End If

        If IsArray(objPromocionDescripcion) Then

            If objPromocionDescripcion.Length > 0 Then

                'Pintado de la Tabla
                Call strPromocionHTML.Append("<table id='Table2' cellSpacing='0' cellPadding='0' width='96%' border='0'>")
                Call strPromocionHTML.Append("<tr class='trtitulos'><th class='rayita' width='165'>Descripcion de las Promociones</th></tr>")

                intConsecutivo += 1

                For Each strPromocion In objPromocionDescripcion

                    If (intConsecutivo Mod 2) <> 0 Then

                        strColorRegistro = "'tdceleste'"

                    Else

                        strColorRegistro = "'tdblanco'"

                    End If

                    'Pintado de cada Registro
                    Call strPromocionHTML.Append("<tr>")
                    Call strPromocionHTML.Append("<td class=" & strColorRegistro & ">")
                    Call strPromocionHTML.Append("<a class='txaccion' href=\""javascript:ClosePopup('" & clsCommons.strFormatearDescripcion(strPromocion(0)).ToString & "','" & clsCommons.strFormatearDescripcion(strPromocion(1)) & "')\"">" & clsCommons.strFormatearDescripcion(strPromocion(0)) & Space(2) & clsCommons.strFormatearDescripcion(strPromocion(1)) & " </a>")
                    Call strPromocionHTML.Append("</td>")
                    Call strPromocionHTML.Append("</tr>")

                    If blnUnSoloRegistro = True Then

                        strJavascriptWindowOnLoadCommands = "<script language=""javascript"">ClosePopup('" & clsCommons.strFormatearDescripcion(strPromocion(0)) & "','" & clsCommons.strFormatearDescripcion(strPromocion(1)) & "')</script>"
                        'strJavascriptWindowOnLoadCommands = "<script language=""javascript"">ClosePopup('" & clsCommons.strFormatearDescripcion(strArticulo(0)) & "','" & clsCommons.strFormatearDescripcion(strArticulo(5)) & "','" & clsCommons.strFormatearDescripcion(strArticulo(6)) & "')</script>"

                    End If

                    intConsecutivo += 1

                Next

                Call strPromocionHTML.Append("</table>")

            End If

        End If

        If strPromocionHTML.Length > 0 Then

            strRecordBrowserHTML = strPromocionHTML.ToString()

        Else

            strRecordBrowserHTML = String.Empty

        End If

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

End Class
