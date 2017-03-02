Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business
Imports System.Text
Imports System.Configuration

Public Class clsMercanciaArchivoProductosNegados
    Inherits System.Web.UI.Page
    Private strmArticuloNombreId As String = ""
    Private strmArticulo As String = ""
    Private strmRecordBrowser As String = ""

    Private Const intElementos As Integer = 20

    ' Variables para el control del reporte y agregar artículos
    Private intmInventarioNegadoFolioId As Integer
    Private strmArticuloDescripcion As String

    ' Manejo de errores
    Private intmError As Integer

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
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalNombre() As String
        Get
            Return clsCommons.strReadCookie("strSucursalNombre", "", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del Usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)
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
    ' Name       : strCmd
    ' Description: Identificador del comando a realizar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Request.QueryString("strCmd") <> "" Then
                Return Request.QueryString("strCmd")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intEmpleadoAutorizadoId
    ' Description: Identificador del empleado autorizado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intEmpleadoAutorizadoId() As Integer
        Get
            If Request.Form("cboEmpleadoAutorizado") <> "" Then
                Return CType(Request.Form("cboEmpleadoAutorizado").ToString, Integer)
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strcboEmpleadoAutorizado
    ' Description: Genera el código requerido para crear los valores
    '              del combo de EmpleadoAutorizados
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strcboEmpleadoAutorizado() As String
        Get
            ' Declaración e inicialización de las variables locales
            Dim strbldcboEmpleadoAutorizado As StringBuilder
            Dim objEmpleadoAutorizado As Array = Nothing
            Dim strEmpleadoAutorizado As String()
            Dim intOption As Integer = 1

            strbldcboEmpleadoAutorizado = New StringBuilder

            ' Busqueda de los EmpleadoAutorizados registrados
            objEmpleadoAutorizado = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarEmpleadoAutorizaNegados(intCompaniaId, intSucursalId, 0, 0, strCadenaConexion)

            If IsArray(objEmpleadoAutorizado) Then
                If (objEmpleadoAutorizado.Length > 0) Then

                    ' Generación del combo de EmpleadoAutorizados
                    intOption = 1
                    For Each strEmpleadoAutorizado In objEmpleadoAutorizado
                        strbldcboEmpleadoAutorizado.Append("document.forms[0].elements['cboEmpleadoAutorizado'].options[" & intOption & "] = new Option(""" & clsCommons.strFormatearDescripcion(strEmpleadoAutorizado(7)) & """, """ & clsCommons.strFormatearDescripcion(strEmpleadoAutorizado(0)) & """); ")

                        ' Verifico si es el valor pasado como parámetro
                        If CType(clsCommons.strFormatearDescripcion(strEmpleadoAutorizado(0)), Integer) = intEmpleadoAutorizadoId Then
                            strbldcboEmpleadoAutorizado.Append("document.forms[0].elements['cboEmpleadoAutorizado'].options[" & intOption & "].selected = true;")
                        End If

                        intOption += 1
                    Next
                End If
            End If

            Return strbldcboEmpleadoAutorizado.ToString

        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaInicial
    ' Description: Numero de artículo a consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaInicial() As Date
        Get
            Return CDate(clsCommons.strDMYtoMDY(Request.Form("txtFechaInicio")))
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaFinal
    ' Description: Numero de artículo a consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaFinal() As Date
        Get
            Return CDate(clsCommons.strDMYtoMDY(Request.Form("txtFechaFin")))
        End Get
    End Property

    '====================================================================
    ' Name       : intArticuloInternoId
    ' Description: Numero del artículo Interno
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================

    Public Property strArticuloInternoId() As String
        Get
            Return strmArticulo
        End Get
        Set(ByVal strValue As String)
            strmArticulo = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strBuscarArticuloId
    ' Description: Numero de artículo a consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strBuscarArticuloId() As String
        Get
            If Len(Trim(Request.Form("txtArticuloId"))) > 0 Then
                Return Request.Form("txtArticuloId")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strBuscarArticuloDescripcion
    ' Description: Descripcion de artículo a consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================

    Public ReadOnly Property strBuscarArticuloDescripcion() As String
        Get
            Return strArticuloDescripcion(strBuscarArticuloId)
        End Get
    End Property

    '====================================================================
    ' Name       : strArticuloDescripcion
    ' Description: Consulta la descripción del Artículo
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Function strArticuloDescripcion(ByVal strArticuloBuscar As String) As String
        Dim objArticulos As Array = Nothing
        Dim strArticulos As String() = Nothing

        ' Consulta el código o la descripción capturada 
        If strArticuloBuscar.Length > 0 Then

            objArticulos = clsConcentrador.clsSucursal.strBuscarArticulo(intCompaniaId, intSucursalId, strArticuloBuscar, 100, 100, strCadenaConexion)

            If IsArray(objArticulos) Then
                If objArticulos.Length > 0 Then

                    ' Obtenemos el código y la descripcion del articulo
                    strArticulos = DirectCast(objArticulos.GetValue(0), String())
                    strArticuloInternoId = clsCommons.strFormatearDescripcion(strArticulos(0))
                    strArticuloNombreId = clsCommons.strFormatearDescripcion(strArticulos(5))
                    Return "1"
                Else
                    If strArticuloBuscar = "0" Then
                        strArticuloInternoId = "0"
                        Return "1"
                    End If
                    Return "0"
                End If
            End If
        Else
            Return "0"
        End If

    End Function

    '====================================================================
    ' Name       : strArticuloNombreId
    ' Description: Numero del artículo Consultado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================

    Public Property strArticuloNombreId() As String
        Get
            Return strmArticuloNombreId
        End Get
        Set(ByVal strValue As String)
            strmArticuloNombreId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowser
    ' Description: REcordBorwser
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRecordBrowser() As String
        Get
            Return strmRecordBrowser
        End Get
        Set(ByVal strValue As String)
            strmRecordBrowser = strValue
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaración e inicialización de las variables locales
        Dim objProductosNegados As Array = Nothing
        Dim strTargetURL As String = "MercanciaDetalleProductosNegados.aspx?"

        strRecordBrowser = ""

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        Select Case strCmd
            Case "Consultar"
                If strArticuloDescripcion(strBuscarArticuloId) = "1" Then

                    objProductosNegados = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarInventarioNegado(intCompaniaId, intSucursalId, 0, intEmpleadoAutorizadoId, CInt(strArticuloInternoId), dtmFechaInicial, dtmFechaFinal, 0, 0, strCadenaConexion)

                    If IsArray(objProductosNegados) AndAlso objProductosNegados.Length > 0 Then
                        ' Generamos el Navegador de Registros
                        strRecordBrowser = clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaArchivoProductosNegados", objProductosNegados, 1, objProductosNegados.Length, strTargetURL))
                    End If
                End If

        End Select
    End Sub

End Class
