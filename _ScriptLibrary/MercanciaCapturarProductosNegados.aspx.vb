Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business
Imports System.Text
Imports System.Configuration

Public Class clsMercanciaCapturarProductosNegados
    Inherits System.Web.UI.Page

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
    ' Name       : intError
    ' Description: Nombre del Concepto
    ' Accessor   : Read / Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intError() As Integer
        Get
            Return intmError
        End Get
        Set(ByVal intValue As Integer)
            intmError = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strArticuloId
    ' Description: Valor del artículo a agregar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strArticuloId() As String
        Get
            If Trim(Request.Form("txtArticuloId")) <> "" Then
                Return clsCommons.strFormatearDescripcion(Trim(Request.Form("txtArticuloId")))
            Else
                If Trim(Request.QueryString("txtArticuloId")) <> "" Then
                    Return Trim(Request.QueryString("txtArticuloId"))
                Else
                    Return ""
                End If
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intArticuloId
    ' Description: Valor del artículo a borrar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intArticuloId() As Integer
        Get
            If Request.QueryString("intArticuloId") <> "" Then
                Return CType(Request.QueryString("intArticuloId"), Integer)
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intInventarioNegadoFolioId
    ' Description: Valor del reporte de artículos negados
    ' Accessor   : Read / Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intInventarioNegadoFolioId() As Integer
        Get
            Return intmInventarioNegadoFolioId
        End Get
        Set(ByVal intValue As Integer)
            intmInventarioNegadoFolioId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : AsigarInventarioFolioNegado
    ' Description: Valor de la forma del id inventario negado
    ' Accessor   : Read / Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Sub AsigarInventarioFolioNegado()
        Dim strlInventarioFolioId As String

        If Request.Form("txtInventarioNegadoFolioId") <> "" Then
            strlInventarioFolioId = Request.Form("txtInventarioNegadoFolioId")
        Else
            If Request.QueryString("txtInventarioNegadoFolioId") <> "" Then
                strlInventarioFolioId = Request.QueryString("txtInventarioNegadoFolioId")
            Else
                strlInventarioFolioId = "0"
            End If
        End If

        ' Asigno el valor a la variable interna de control
        intInventarioNegadoFolioId = CType(strlInventarioFolioId, Integer)
    End Sub

    '====================================================================
    ' Name       : strArticuloDescripcion
    ' Description: Descripcion del artículo a agregar
    ' Accessor   : Read / Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strArticuloDescripcion() As String
        Get
            Return strmArticuloDescripcion
        End Get
        Set(ByVal strValue As String)
            strmArticuloDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCantidadVeces
    ' Description: Cantidad de veces que se negó el artículo
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCantidadVeces() As String
        Get
            If Request.Form("txtCantidadVeces") <> "" Then
                Return Trim(Request.Form("txtCantidadVeces"))
            Else
                If Request.QueryString("txtCantidadVeces") <> "" Then
                    Return Request.QueryString("txtCantidadVeces")
                Else
                    Return ""
                End If
            End If
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
                        strbldcboEmpleadoAutorizado.Append("document.forms[0].cboEmpleadoAutorizado.options[" & intOption & "] = new Option(""" & clsCommons.strFormatearDescripcion(strEmpleadoAutorizado(7)).ToString & """, """ & clsCommons.strFormatearDescripcion(strEmpleadoAutorizado(0)).ToString & """); ")

                        ' Verifico si es el valor pasado como parámetro
                        If CType(strEmpleadoAutorizado(0), Integer) = intEmpleadoAutorizadoId Then
                            strbldcboEmpleadoAutorizado.Append("document.forms[0].cboEmpleadoAutorizado.options[" & intOption & "].selected = true;")
                        End If

                        intOption += 1
                    Next
                End If
            End If

            Return strbldcboEmpleadoAutorizado.ToString

        End Get
    End Property

    ''====================================================================
    '' Name       : strBuscarInformacionArticulo
    '' Description: Genera el Record Browser para mostrar los Articulos
    ''              de acuerdo a su descripcion.
    '' Parameters : 
    '' Throws     : Ninguna
    '' Output     : String
    ''====================================================================
    'Public Sub strBuscarInformacionArticulo()

    '    Dim objArticuloSucursal As Array = Nothing
    '    Dim strArticuloSucursal As String()
    '    Dim strbldRecordBrowserHTML As StringBuilder

    '    ' Buscamos el concepto especificado
    '    objArticuloSucursal = clsConcentrador.clsSucursal.strBuscarArticulo(intCompaniaId, intSucursalId, strArticuloId, 0, 0, strCadenaConexion)

    '    If IsArray(objArticuloSucursal) AndAlso objArticuloSucursal.Length > 0 Then
    '        strArticuloSucursal = objArticuloSucursal(0)

    '        strArticuloDescripcion = clsCommons.strFormatearDescripcion(strArticuloSucursal(5)).ToString
    '        intError = 0
    '    Else
    '        strArticuloDescripcion = ""
    '        intError = -100
    '    End If

    'End Sub

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Record browser navegador de los movimientos según 
    '              del empleado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRecordBrowserHTML() As String
        Get
            ' Declaración e inicialización de las variables locales
            Dim strbldRecordBrowserHTML As StringBuilder
            Dim objReporteProductosNegados As Array = Nothing
            Dim strTargetURL As String = "MercanciaCapturarProductosNegados.aspx?txtInventarioNegadoFolioId=" + intInventarioNegadoFolioId.ToString + "&"

            strbldRecordBrowserHTML = New StringBuilder

            ' Busco los empelados de la sucursal
            objReporteProductosNegados = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarDetalleNegado(intInventarioNegadoFolioId, intCompaniaId, intSucursalId, 0, 0, strCadenaConexion)

            If IsArray(objReporteProductosNegados) Then

                If objReporteProductosNegados.Length > 0 Then

                    ' Generamos el Navegador de Registros
                    Dim intElementos As Integer

                    intElementos = objReporteProductosNegados.Length

                    strbldRecordBrowserHTML.Append(clsRecordBrowser.strGetHTML("MercanciaCapturarProductosNegados", objReporteProductosNegados, 1, intElementos, strTargetURL))
                End If
            End If

            Return clsCommons.strGenerateJavascriptString(strbldRecordBrowserHTML.ToString)
        End Get

    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strHTML As StringBuilder

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        ' Busco el folio del reporte y lo asigno a la variable correspondiente
        Call AsigarInventarioFolioNegado()

        Select Case strCmd
            Case "Consultar"
                ' Consultamos un artículo
                'Call strBuscarInformacionArticulo()
                Dim objArticuloSucursal As Array = Nothing
                Dim strArticuloSucursal As String()
                Dim strDescripcionArticulo As String
                Dim intArticuloEncontrado As Integer

                ' Buscamos el concepto especificado
                objArticuloSucursal = clsConcentrador.clsSucursal.strBuscarArticulo(intCompaniaId, intSucursalId, strArticuloId, 0, 0, strCadenaConexion)

                strHTML = New StringBuilder

                If IsArray(objArticuloSucursal) AndAlso objArticuloSucursal.Length > 0 Then
                    strArticuloSucursal = DirectCast(objArticuloSucursal.GetValue(0), String())

                    intArticuloEncontrado = CInt(strArticuloSucursal(0))
                    strDescripcionArticulo = clsCommons.strFormatearDescripcion(strArticuloSucursal(5).ToString)

                    strHTML.Append("<script language='javascript'>parent.fnBuscaArticulo('" & intArticuloEncontrado.ToString & "','" & strDescripcionArticulo & "',1);</script>")
                Else
                    strHTML.Append("<script language='javascript'>parent.fnBuscaArticulo('','',0);</script>")
                End If

                Call Response.Write(strHTML.ToString)
                Call Response.End()

            Case "Agregar"

                ' Verifico que existe un reporte
                If intInventarioNegadoFolioId = 0 Then

                    ' Asigno un nuevo reporte
                    intInventarioNegadoFolioId = clsConcentrador.clsSucursal.clsMercancia.clsInventario.intAgregarNegado(intCompaniaId, intSucursalId, intEmpleadoAutorizadoId, strUsuarioNombre, strCadenaConexion)
                End If

                ' Agrego el artículo al reporte
                Call clsConcentrador.clsSucursal.clsMercancia.clsInventario.intAgregarArticuloNegado(intInventarioNegadoFolioId, intCompaniaId, intSucursalId, CType(strArticuloId, Integer), CType(strCantidadVeces, Integer), strUsuarioNombre, strCadenaConexion)

                ' Exito en el alta del artículo
                intError = 100

            Case "Borrar"

                ' Eliminamos el artículo
                Call clsConcentrador.clsSucursal.clsMercancia.clsInventario.intBorrarArticuloNegado(intInventarioNegadoFolioId, intCompaniaId, intSucursalId, intArticuloId, strCadenaConexion)


        End Select

    End Sub

End Class
