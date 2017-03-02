Imports Isocraft.Web.Http
Imports System.Text
Imports System.Configuration
Imports Benavides.CC.Data

'====================================================================
' Class         : SucursalProveedoresConsultar
' Title         :
' Description   :
' Copyright     : Sistemas Benavides 
' Company       : Farmacias Benavides
' Author        : J.Antonio Hernandez
' Last Modified : 01 Junio 2007
'====================================================================

Public Class SucursalProveedoresConsultar
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



        ' Initialize class properties
        intOpcArticulo = GetPageParameter("intOpcArticulo", GetPageParameter("optArticulo", 0))
        intOpcSucursal = GetPageParameter("intOpcSucursal", GetPageParameter("optSucursal", 0))
        strOpcProveedor = GetPageParameter("strOpcProveedor", GetPageParameter("optProveedor", ""))

        intProveedorId = GetPageParameter("intProveedorId", GetPageParameter("intProveedorId", 0))

    End Sub

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


#Region " Class Private Attributes"

    Const strComitasDobles As String = """"
    Private strmJavascriptWindowOnLoadCommands As String

    Private intmOpcArticulo As Integer
    Private intmOpcSucursal As Integer
    Private intmProveedorId As Integer
    Private strmOpcProveedor As String


#End Region


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
    ' Name       : intOpcArticulo
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intOpcArticulo() As Integer
        Get
            Return intmOpcArticulo
        End Get
        Set(ByVal strValue As Integer)
            intmOpcArticulo = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intOpcSucursal
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intOpcSucursal() As Integer
        Get
            Return intmOpcSucursal
        End Get
        Set(ByVal strValue As Integer)
            intmOpcSucursal = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strOpcProveedor
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : string
    '====================================================================
    Public Property strOpcProveedor() As String
        Get
            Return strmOpcProveedor
        End Get
        Set(ByVal strValue As String)
            strmOpcProveedor = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intProveedorId
    ' Description: id del proveedor
    ' Accessor   : Read/Write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intProveedorId() As Integer
        Get
            Return intmProveedorId
        End Get
        Set(ByVal intValue As Integer)
            intmProveedorId = intValue
        End Set
    End Property

    Public ReadOnly Property strProveedorNombreId() As String
        Get
            Return Request("strProveedorNombreId")
        End Get
    End Property

    Public ReadOnly Property strProveedorRazonSocial() As String
        Get
            Return Request("strProveedorRazonSocial")
        End Get
    End Property

    '====================================================================
    ' Name       : strConsultarProveedores
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strConsultarProveedores() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 100
        Const strRecordBrowserName As String = "SucursalProveedoresConsultar"

        ' Generamos el URL destino de las páginas
        Dim strTargetURL As String = strThisPageName & "?intOpcArticulo=" & intOpcArticulo.ToString & "&intOpcSucursal=" & intOpcSucursal.ToString & "&strOpcProveedor=" & strOpcProveedor & "&"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)

        Dim objDataArrayProveedores As Array = clsProveedor.strBuscarProveedorConfiguracion(strOpcProveedor, intOpcArticulo, intOpcSucursal, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

        Dim strSuprime As String = "<span class=""txsubtitulo""><img src=""../static/images/bullet_subtitulos.gif"" width=""17"" height=""11"" align=""absmiddle""></span><br>"

        ' Generamos el navegador de registros
        Return Replace(Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, objDataArrayProveedores, intSelectedPage, intElementsPerPage, strTargetURL), strSuprime, " ")

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaramos las variables locales
        Dim aobjData As Array = Nothing
        Dim objRow As System.Collections.SortedList = Nothing

        ' Execute the selected command
        Select Case strCmd

            Case "VerA", "VerS"

                strJavascriptWindowOnLoadCommands = "popVerConsulta( " & _
                strComitasDobles & strCmd & strComitasDobles & "," & _
                strComitasDobles & intProveedorId & strComitasDobles & "," & _
                strComitasDobles & strProveedorNombreId & strComitasDobles & "," & _
                strComitasDobles & strProveedorRazonSocial & strComitasDobles & ");"

            Case "EdiA"
                Call Response.Redirect("SucursalProveedoresEditarArticulosAutorizados.aspx?intproveedorDestinoId=" & intProveedorId.ToString & "&strProveedorDestinoNombreId=" & strProveedorNombreId & "&strProveedorDestinoRazonSocial=" & strProveedorRazonSocial)

            Case "DelS"
                Dim intContador As Integer = 0
                Dim intError As Integer = 0
                Dim strHTML As New StringBuilder


                intContador = clsProveedor.intEliminarSucursales(intProveedorId, strUsuarioNombre, strConnectionString)

                If intContador < 0 Then

                    intError = intContador 'No se pudo eliminar
                    intContador = 0

                End If

                strJavascriptWindowOnLoadCommands = "fnEliminarSucursales( " & _
                           strComitasDobles & intError.ToString & strComitasDobles & "," & _
                           strComitasDobles & intContador.ToString & strComitasDobles & "); "

        End Select

    End Sub

End Class
