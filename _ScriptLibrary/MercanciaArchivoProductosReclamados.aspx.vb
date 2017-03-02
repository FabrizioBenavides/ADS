'====================================================================
' Page          : MercanciaArchivoProductosReclamados.aspx
' Title         : Administracion POS y BackOffice
' Description   : Página de productos Reclamados.
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : J.Antonio Hernández Dávila
' Version       : 1.0
' Last Modified : Martes, Octubre 28, 2003
'====================================================================

Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text
Imports System.DateTime

Public Class MercanciaArchivoProductosReclamados
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

    Private strmMensaje As String = ""
    Private strmRecordBrowserHTML As String

    Private strmRazonSocialProveedor As String = ""
    Private strmErrorProveedor As String = "0"
    Const strComitasDobles As String = """"

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
    ' Name       : strMensaje
    ' Description: Fecha de Emision de la Factura Electronica Consultada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '====================================================================  
    Public Property strMensaje() As String
        Get
            Return strmMensaje
        End Get
        Set(ByVal Value As String)
            strmMensaje = Value
        End Set
    End Property

    '====================================================================
    ' Name       : rdoFiltroConsulta
    ' Description: Valor del radio boton
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property rdoFiltroConsulta() As String
        Get
            If Not IsNothing(Request.QueryString("rdoFiltroConsulta")) Then
                Return Request.QueryString("rdoFiltroConsulta")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strProveedor
    ' Description: Numero de Proveedor
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strProveedor() As String
        Get
            If Not IsNothing(Request.QueryString("intProveedor")) Then
                Return Request.QueryString("intProveedor")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmInicio
    ' Description: Fecha Inicial de la consulta
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmInicio() As String
        Get
            If Not IsNothing(Request.QueryString("dtmInicio")) Then
                Return Request.QueryString("dtmInicio")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFin
    ' Description: Fecha final de la consulta
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFin() As String
        Get
            If Not IsNothing(Request.QueryString("dtmFin")) Then
                Return Request.QueryString("dtmFin")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strConsulta
    ' Description: Comando a ejecutar
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strConsulta() As String
        Get
            If Not IsNothing(Request.QueryString("strConsulta")) Then
                Return (Request.QueryString("strConsulta"))
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strRazonSocialProveedor
    ' Description: Razon Social del proveedor
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRazonSocialProveedor() As String
        Get
            Return strmRazonSocialProveedor
        End Get
        Set(ByVal Value As String)
            strmRazonSocialProveedor = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strErrorProveedor
    ' Description: Para validacion en PAgina
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strErrorProveedor() As String
        Get
            Return strmErrorProveedor
        End Get
        Set(ByVal Value As String)
            strmErrorProveedor = Value
        End Set
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


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If


        strErrorProveedor = "0"
        strRecordBrowserHTML = ""

        Dim strHTML As StringBuilder

        If strConsulta = "ConsultaProveedor" Then

            strHTML = New StringBuilder

            Dim objArrayProveedor As Array = Nothing
            Dim objRegistroProveedor As System.Collections.SortedList = Nothing

            Dim strBusquedaProveedorId As String = ""
            Dim strBusquedaProveedorNombreId As String = ""
            Dim strBusquedaProveedorRazonSocial As String = ""
            Dim strBusquedaProveedorRFC As String = ""
            Dim strBusquedaProveedorError As String = "-100"

            If IsNumeric(Mid(Request.Form("txtProveedor"), 1, 4)) Then

                objArrayProveedor = clsProveedor.strBuscar("", Request.Form("txtProveedor"), 0, 0, strCadenaConexion)

                If IsArray(objArrayProveedor) AndAlso objArrayProveedor.Length > 0 Then

                    objRegistroProveedor = DirectCast(objArrayProveedor.GetValue(0), System.Collections.SortedList)

                    ' Asignamos los datos del proveedor

                    strBusquedaProveedorId = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("intProveedorId")))
                    strBusquedaProveedorNombreId = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorNombreId")))
                    strBusquedaProveedorRazonSocial = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorRazonSocial")))
                    strBusquedaProveedorRFC = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorRFC")))
                    strBusquedaProveedorError = "0"

                End If

            End If

            strHTML.Append("<script language='Javascript'> parent.fnUpBuscarProveedor( " & _
                           strComitasDobles & strBusquedaProveedorId & strComitasDobles & "," & _
                           strComitasDobles & strBusquedaProveedorNombreId & strComitasDobles & "," & _
                           strComitasDobles & strBusquedaProveedorRazonSocial & strComitasDobles & "," & _
                           strComitasDobles & strBusquedaProveedorRFC & strComitasDobles & "," & _
                           strComitasDobles & strBusquedaProveedorError & strComitasDobles & _
                           "); </script>")

            Response.Write(strHTML.ToString)
            Response.End()


        End If

        If strConsulta = "ConsultaReclamados" Then

            Dim objArrayReclamaciones As Array = Nothing
            Dim strTargetURL As String = "MercanciaDetalleProductosReclamados.aspx?strConsulta=ConsultaReclamados&rdoFiltroConsulta=" & rdoFiltroConsulta & "&intProveedor=" & strProveedor & "&dtmInicio=" & dtmInicio & "&dtmFin=" & dtmFin & "&"


            If rdoFiltroConsulta = "1" AndAlso strProveedor.Length > 0 AndAlso IsNumeric(strProveedor) Then


                If strRazonSocialProveedor.Length = 0 Then
                    strMensaje = "Proveedor no encotrado"
                    strErrorProveedor = "1"
                Else
                    objArrayReclamaciones = clsConcentrador.clsSucursal.clsMercancia.clsReclamacion.strBuscar(intCompaniaId, intSucursalId, 0, 1, CInt(strProveedor), CDate("01/01/1900"), CDate("01/01/1900"), 0, 0, strCadenaConexion)

                End If
            End If

            If rdoFiltroConsulta = "2" Then

                objArrayReclamaciones = clsConcentrador.clsSucursal.clsMercancia.clsReclamacion.strBuscar(intCompaniaId, intSucursalId, 0, 2, 0, CDate(clsCommons.strDMYtoMDY(dtmInicio)), CDate(clsCommons.strDMYtoMDY(dtmFin)), 0, 0, strCadenaConexion)

            End If

            If rdoFiltroConsulta = "3" Then

                objArrayReclamaciones = clsConcentrador.clsSucursal.clsMercancia.clsReclamacion.strBuscar(intCompaniaId, intSucursalId, 0, 3, 0, CDate("01/01/1900"), CDate("01/01/1900"), 0, 0, strCadenaConexion)

            End If

            If IsArray(objArrayReclamaciones) AndAlso objArrayReclamaciones.Length > 0 Then
                Dim strRecordBrowseComplemento As StringBuilder
                Dim strRecordBrowserConsulta As String = ""
                Dim strpaso() As String

                strRecordBrowseComplemento = New StringBuilder
                ' Generamos el Navegador de Registros                
                strRecordBrowserConsulta = clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaArchivoProductosReclamados", objArrayReclamaciones, 1, objArrayReclamaciones.Length, strTargetURL))

                If strRecordBrowserConsulta.Length > 0 Then
                    strRecordBrowseComplemento.Append("<div id='ToPrintHtmContenido'>")
                    strRecordBrowseComplemento.Append("<table	width='100%' border='0' cellpadding='0' cellspacing='0'>")
                    strRecordBrowseComplemento.Append(strRecordBrowserConsulta)
                    strRecordBrowseComplemento.Append("</div>")
                    strRecordBrowseComplemento.Append("<br>")
                    strRecordBrowseComplemento.Append("<input name='cmdOtra' type='button' class='boton' value='Otra Consulta' onclick='return cmdOtra_onclick()'> &nbsp;&nbsp;&nbsp;")
                    strRecordBrowserHTML = strRecordBrowseComplemento.ToString
                End If
            Else
                strMensaje = "No hay inofrmación para la consulta seleccionada "
            End If


        End If


    End Sub


End Class
