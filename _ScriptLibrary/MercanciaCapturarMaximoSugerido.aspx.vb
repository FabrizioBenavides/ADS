Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration

Public Class clsMercanciaCapturarMaximoSugerido
    Inherits System.Web.UI.Page

    Public strGeneraTablaHTML As String
    Public strmMensaje As String
    Private intmInventarioSugeridoId As Integer
    Private strmHdnActual As String
    Private strmHdnTresMeses As String
    Private strmHdnTeorico As String
    Private strmHdnUnMes As String
    Private strmHdnVigencia As String
    Private strmHdnUnaSemana As String
    Private strmHdnClaveVigencia As String
    Private strmTxtStrArticuloDescripcion As String
    Private intmArticuloInternoId As String = ""

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.diagnostics.debuggerstepthrough()> Private Sub InitializeComponent()

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
    ' Accessor   : Read
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
    ' Name       : strCmd
    ' Description: string de Comandos de control
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Not IsNothing(Request("strCmd")) Then
                Return Request("strCmd")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intInventarioSugeridoId
    ' Description: string de Comandos de control
    ' Accessor   : Read and Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intInventarioSugeridoId() As Integer
        Get
            Return intmInventarioSugeridoId
        End Get
        Set(ByVal intValue As Integer)
            intmInventarioSugeridoId = intValue
        End Set
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
    ' Name       : strMensaje
    ' Description: valor para mensaje
    ' Accessor   : Read and Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strMensaje() As String
        Get
            Return strmMensaje
        End Get
        Set(ByVal strValue As String)
            If IsNothing(strValue) Then
                strmMensaje = ""
            Else
                strmMensaje = Trim(strValue)
            End If
        End Set
    End Property

    '====================================================================
    ' Name       : strTxtStrArticuloDescripcion
    ' Description: valor del control txtStrArticuloDescripcion
    ' Accessor   : Read and Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strTxtStrArticuloDescripcion() As String
        Get
            Return strmTxtStrArticuloDescripcion
        End Get
        Set(ByVal strValue As String)
            strmTxtStrArticuloDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strtxtIntArticuloId
    ' Description: valor del control txtIntArticuloId
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strtxtIntArticuloId() As String
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("txtIntArticuloId"))

            If strTemporal.Equals("") Then
                Return ""
            Else
                Dim objArray As Array
                Dim strRegistro As String()

                objArray = Nothing
                objArray = clsConcentrador.clsSucursal.strBuscarArticulo(intCompaniaId, intSucursalId, strTemporal, 1, 1, strCadenaConexion)
                If IsArray(objArray) AndAlso (objArray.Length > 0) Then
                    strRegistro = DirectCast(objArray.GetValue(0), String())
                    strTemporal = clsCommons.strFormatearDescripcion(strRegistro(0)).ToString
                    strTxtStrArticuloDescripcion = clsCommons.strFormatearDescripcion(strRegistro(5)).ToString
                End If

                If Len(strTemporal) > 8 Then
                    strTemporal = Mid(strTemporal, 1, 8)
                End If

                Return strTemporal
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intArticuloInternoId
    ' Description: Codigo de Articulo Interno
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intArticuloInternoId() As String
        Get
            Return intmArticuloInternoId
        End Get
        Set(ByVal Value As String)
            intmArticuloInternoId = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strTxtMaximoSugerido
    ' Description: valor del control txtMaximoSugerido
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTxtMaximoSugerido() As String
        Get
            Dim strTemporal As String
            strTemporal = Trim(Request("txtMaximoSugerido"))
            If strTemporal.Equals("") Then
                Return ""
            Else
                Return strTemporal
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strHdnActual
    ' Description: Campo Oculto
    ' Accessor   : Read and Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strHdnActual() As String
        Get
            Return strmHdnActual
        End Get
        Set(ByVal strValue As String)
            strmHdnActual = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : strHdnTresMeses
    ' Description: Campo Oculto
    ' Accessor   : Read and Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strHdnTresMeses() As String
        Get
            Return strmHdnTresMeses
        End Get
        Set(ByVal strValue As String)
            strmHdnTresMeses = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : strHdnTeorico
    ' Description: Campo Oculto
    ' Accessor   : Read and Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strHdnTeorico() As String
        Get
            Return strmHdnTeorico
        End Get
        Set(ByVal strValue As String)
            strmHdnTeorico = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : strHdnUnMes
    ' Description: Campo Oculto
    ' Accessor   : Read and Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strHdnUnMes() As String
        Get
            Return strmHdnUnMes
        End Get
        Set(ByVal strValue As String)
            strmHdnUnMes = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : strHdnVigencia
    ' Description: Campo Oculto
    ' Accessor   : Read and Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strHdnVigencia() As String
        Get
            Return strmHdnVigencia
        End Get
        Set(ByVal strValue As String)
            strmHdnVigencia = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : strHdnUnaSemana
    ' Description: Campo Oculto
    ' Accessor   : Read and Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strHdnUnaSemana() As String
        Get
            Return strmHdnUnaSemana
        End Get
        Set(ByVal strValue As String)
            strmHdnUnaSemana = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strHdnClaveVigencia
    ' Description: Campo Oculto
    ' Accessor   : Read and Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strHdnClaveVigencia() As String
        Get
            Return strmHdnClaveVigencia
        End Get
        Set(ByVal strValue As String)
            strmHdnClaveVigencia = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : Page_Load
    ' Description: Evento "Load" de la página
    ' Parameters :
    '              ByVal objSender As System.Object
    '                 - Objeto que genera el Evento
    '              ByVal objEvent As System.EventArgs
    '                 - Argumentos del Evento
    ' Throws     : Ninguna
    ' Output     : Ninguna
    '====================================================================
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        Dim objArray As Array = Nothing
        Dim intInicio As Integer = 0
        Dim intResultado As Integer
        Dim strRegistro As String()

        'Request Variables
        Call RequestVariables()

        Select Case UCase(Trim(strCmd))
            Case ""
                'Generar Tabla de informacion
                objArray = Nothing
                objArray = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarDetalleSugerido(intInventarioSugeridoId, intCompaniaId, intSucursalId, 0, 0, strCadenaConexion)
                If IsArray(objArray) AndAlso (objArray.Length > 0) Then
                    strGeneraTablaHTML = strGeneraTabla(objArray, "Lista de máximos a sugerir", "Código", intInicio, "", "Descripción", "Máximo actual", "Máximo sugerido", "", "", "Acción")
                Else
                    strGeneraTablaHTML = ""
                End If

            Case UCase("ConsultarMaximos")
                'Dim strHTML As StringBuilder
                'Buscando Maximos

                'Generar Tabla de informacion
                objArray = Nothing
                objArray = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarDetalleSugerido(intInventarioSugeridoId, intCompaniaId, intSucursalId, 0, 0, strCadenaConexion)

                If IsArray(objArray) AndAlso (objArray.Length > 0) Then
                    strGeneraTablaHTML = strGeneraTabla(objArray, "Lista de máximos a sugerir", "Código", intInicio, "", "Descripción", "Máximo actual", "Máximo sugerido", "", "", "Acción")
                Else
                    strGeneraTablaHTML = ""
                End If

                objArray = Nothing
                objArray = clsConcentrador.clsSucursal.strBuscarMaximosArticulo(intCompaniaId, intSucursalId, CInt(strtxtIntArticuloId), strCadenaConexion)

                '0 intArticuloSucursalExistenciaIdeal 
                '1 intArticuloSucursalExistenciaTeorica 
                '2 fltArticuloSucursalVentaTrimestralRegistrada 
                '3 fltArticuloSucursalVentaMensualRegistrada 
                '4 fltArticuloSucursalVentaSemanalRegistrada 
                '5 intArticuloSucursalDiasInventario


                If IsArray(objArray) AndAlso (objArray.Length > 0) Then
                    strRegistro = DirectCast(objArray.GetValue(0), String())

                    'strHTML = New StringBuilder

                    strHdnActual = clsCommons.strFormatearDescripcion(strRegistro(0)).ToString
                    strHdnTeorico = clsCommons.strFormatearDescripcion(strRegistro(1)).ToString
                    strHdnTresMeses = clsCommons.strFormatearNumeroPresentacion(clsCommons.strFormatearDescripcion(strRegistro(2)).ToString, True)
                    strHdnUnaSemana = clsCommons.strFormatearNumeroPresentacion(clsCommons.strFormatearDescripcion(strRegistro(4)).ToString, True)
                    strHdnUnMes = clsCommons.strFormatearNumeroPresentacion(clsCommons.strFormatearDescripcion(strRegistro(3)).ToString, True)
                    strHdnVigencia = clsCommons.strFormatearDescripcion(strRegistro(5)).ToString
                    strHdnClaveVigencia = clsCommons.strFormatearDescripcion(strRegistro(6)).ToString

                    'Si la Descripcion esta vacia
                    'If Trim(strTxtStrArticuloDescripcion).Equals("") Then
                    objArray = Nothing
                    objArray = clsConcentrador.clsSucursal.strBuscarArticulo(intCompaniaId, intSucursalId, strtxtIntArticuloId, 1, 1, strCadenaConexion)
                    If IsArray(objArray) AndAlso (objArray.Length > 0) Then
                        strRegistro = DirectCast(objArray.GetValue(0), String())

                        strTxtStrArticuloDescripcion = clsCommons.strFormatearDescripcion(strRegistro(5)).ToString
                    End If
                    'End If

                End If

                ''Generar Tabla de informacion
                'objArray = Nothing
                'objArray = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarDetalleSugerido(intInventarioSugeridoId, 0, 0, strCadenaConexion)
                'If IsArray(objArray) AndAlso (objArray.Length > 0) Then
                '    strGeneraTablaHTML = strGeneraTabla(objArray, "Lista de máximos a sugerir", "Código", intInicio, "", "Descripción", "Máximo actual", "Máximo sugerido", "", "", "Acción")
                'Else
                '    strGeneraTablaHTML = ""
                'End If

            Case UCase("BuscarArticulo")
                Dim strHTML As StringBuilder

                strHTML = New StringBuilder
                strMensaje = "Artículo no encontrado."


                'Generar Tabla de informacion
                objArray = Nothing
                objArray = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarDetalleSugerido(intInventarioSugeridoId, intCompaniaId, intSucursalId, 0, 0, strCadenaConexion)

                If IsArray(objArray) AndAlso (objArray.Length > 0) Then
                    strGeneraTablaHTML = strGeneraTabla(objArray, "Lista de máximos a sugerir", "Código", intInicio, "", "Descripción", "Máximo actual", "Máximo sugerido", "", "", "Acción")
                Else
                    strGeneraTablaHTML = ""
                End If

                objArray = Nothing
                objArray = clsConcentrador.clsSucursal.strBuscarMaximosArticulo(intCompaniaId, intSucursalId, CInt(strtxtIntArticuloId), strCadenaConexion)

                '0 intArticuloSucursalExistenciaIdeal 
                '1 intArticuloSucursalExistenciaTeorica 
                '2 fltArticuloSucursalVentaTrimestralRegistrada 
                '3 fltArticuloSucursalVentaMensualRegistrada 
                '4 fltArticuloSucursalVentaSemanalRegistrada 
                '5 intArticuloSucursalDiasInventario


                If IsArray(objArray) AndAlso (objArray.Length > 0) Then
                    strRegistro = DirectCast(objArray.GetValue(0), String())

                    'strHTML = New StringBuilder

                    strHdnActual = clsCommons.strFormatearDescripcion(strRegistro(0)).ToString
                    strHdnTeorico = clsCommons.strFormatearDescripcion(strRegistro(1)).ToString
                    strHdnTresMeses = clsCommons.strFormatearDescripcion(CInt(strRegistro(2)).ToString)
                    strHdnUnaSemana = clsCommons.strFormatearDescripcion(CInt(strRegistro(4)).ToString)
                    strHdnUnMes = clsCommons.strFormatearDescripcion(CInt(strRegistro(3)).ToString)
                    strHdnVigencia = clsCommons.strFormatearDescripcion(strRegistro(5)).ToString
                    strHdnClaveVigencia = clsCommons.strFormatearDescripcion(strRegistro(6)).ToString

                End If

                'Si la Descripcion esta vacia
                If Trim(strTxtStrArticuloDescripcion).Equals("") Then
                    objArray = Nothing
                    objArray = clsConcentrador.clsSucursal.strBuscarArticulo(intCompaniaId, intSucursalId, strtxtIntArticuloId, 1, 1, strCadenaConexion)
                    If IsArray(objArray) AndAlso (objArray.Length > 0) Then
                        strRegistro = DirectCast(objArray.GetValue(0), String())

                        strTxtStrArticuloDescripcion = clsCommons.strFormatearDescripcion(strRegistro(5)).ToString
                    End If
                End If


                ' Obtenemos la información de los Articulos
                objArray = Nothing
                objArray = clsConcentrador.clsSucursal.strBuscarArticulo(intCompaniaId, intSucursalId, strtxtIntArticuloId, 1, 1, strCadenaConexion)
                '0 intArticuloId                                1 fltArticuloSucursalCostoReposicion 
                '2 fltArticuloSucursalPrecioTransferencia
                '3 fltArticuloSucursalPrecioNormalConImpuesto   4 intArticuloSucursalExistenciaIdeal 
                '5 strArticuloDescripcion                                                                                                                                                                                                                                          intDepartamentoId blnArticuloCaduca fltArticuloSucursalPrecioNormalSinImpuesto fltArticuloSucursalVentaTrimestralRegistrada fltArticuloSucursalVentaMensualRegistrada fltArticuloSucursalVentaSemanalRegistrada
                If IsArray(objArray) AndAlso (objArray.Length > 0) Then
                    For Each strRegistro In objArray
                        strTxtStrArticuloDescripcion = clsCommons.strFormatearDescripcion(strRegistro(5)).ToString
                        strHTML.Append("<script language='javascript'>")

                        strHTML.Append("parent.document.forms(0).elements('txtIntArticuloId')")
                        strHTML.Append(".value='" & clsCommons.strFormatearDescripcion(strRegistro(0)).ToString & "';")

                        strHTML.Append("parent.document.forms(0).elements('txtStrArticuloDescripcion')")
                        strHTML.Append(".value='" & clsCommons.strFormatearDescripcion(strRegistro(5)).ToString & "';")

                        strHTML.Append("parent.fnLimpiaInventarioVentas();")

                        strHTML.Append("parent.document.all.divActual.innerText='" & strHdnActual & "';")
                        strHTML.Append("parent.document.all.divTeorico.innerText='" & strHdnTeorico & "';")
                        strHTML.Append("parent.document.all.divTresMeses.innerText='" & strHdnTresMeses & "';")
                        strHTML.Append("parent.document.all.divUnMes.innerText='" & strHdnUnMes & "';")
                        strHTML.Append("parent.document.all.divVigencia.innerText='" & strHdnVigencia & "';")
                        strHTML.Append("parent.document.all.divUnaSemana.innerText='" & strHdnUnaSemana & "';")
                        strHTML.Append("parent.document.all.divClaveVigencia.innerText='" & strHdnClaveVigencia & "';")

                        strHTML.Append("parent.document.forms[0].elements['txtStrArticuloDescripcion'].value='" & strTxtStrArticuloDescripcion & "';")

                        strHTML.Append("parent.document.forms[0].elements['txtMaximoSugerido'].focus();")

                        strHTML.Append("</script>")
                        strMensaje = ""
                        Exit For
                    Next
                End If
                If Trim(strMensaje).Equals("") Then
                    'Articulo si encontrado
                    Response.Write(strHTML.ToString)
                    Response.End()
                Else
                    'Articulo no encontrado
                    strHTML.Append("<script language='javascript'>")

                    strHTML.Append("parent.document.forms(0).elements('txtIntArticuloId')")
                    strHTML.Append(".value='';")

                    strHTML.Append("parent.document.forms(0).elements('txtStrArticuloDescripcion')")
                    strHTML.Append(".value='';")

                    strHTML.Append("parent.fnLimpiaInventarioVentas();")

                    strHTML.Append("parent.document.forms(0).elements('txtIntArticuloId').focus();")

                    strHTML.Append("alert('" & strMensaje & "');")

                    strHTML.Append("</script>")
                    Response.Write(strHTML.ToString)
                    Response.End()
                End If

            Case UCase("AgregarArticulo")
                If intInventarioSugeridoId.Equals(0) Then
                    intInventarioSugeridoId = clsConcentrador.clsSucursal.clsMercancia.clsInventario.intAgregarSugerido(intCompaniaId, intSucursalId, strUsuarioNombre, strCadenaConexion)
                End If
                intResultado = clsConcentrador.clsSucursal.clsMercancia.clsInventario.intAgregarArticuloSugerido(intInventarioSugeridoId, intCompaniaId, intSucursalId, CInt(strtxtIntArticuloId), CInt(strTxtMaximoSugerido), strUsuarioNombre, strCadenaConexion)

                'Generar Tabla de informacion
                objArray = Nothing
                objArray = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarDetalleSugerido(intInventarioSugeridoId, intCompaniaId, intSucursalId, 0, 0, strCadenaConexion)

                If IsArray(objArray) AndAlso (objArray.Length > 0) Then
                    strGeneraTablaHTML = strGeneraTabla(objArray, "Lista de máximos a sugerir", "Código", intInicio, "", "Descripción", "Máximo actual", "Máximo sugerido", "", "", "Acción")
                Else
                    strGeneraTablaHTML = ""
                End If

            Case UCase("BorrarArticulo")
                intResultado = clsConcentrador.clsSucursal.clsMercancia.clsInventario.intBorrarArticuloSugerido(intInventarioSugeridoId, intCompaniaId, intSucursalId, CInt(strtxtIntArticuloId), strCadenaConexion)

                'Generar Tabla de informacion
                objArray = Nothing
                objArray = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarDetalleSugerido(intInventarioSugeridoId, intCompaniaId, intSucursalId, 0, 0, strCadenaConexion)
                If IsArray(objArray) AndAlso (objArray.Length > 0) Then
                    strGeneraTablaHTML = strGeneraTabla(objArray, "Lista de máximos a sugerir", "Código", intInicio, "", "Descripción", "Máximo actual", "Máximo sugerido", "", "", "Acción")
                Else
                    strGeneraTablaHTML = ""
                End If
        End Select
    End Sub

    Private Sub RequestVariables()
        Dim strTemporal As String

        strTemporal = Trim(Request("txtStrArticuloDescripcion"))

        If strTemporal.Equals("") Then
            strTxtStrArticuloDescripcion = ""
        Else
            strTxtStrArticuloDescripcion = strTemporal
        End If

        If Not IsNothing(Request("intInventarioSugeridoId")) Then
            intInventarioSugeridoId = CInt(Request("intInventarioSugeridoId"))
        Else
            intInventarioSugeridoId = 0
        End If

        If Not IsNothing(Request("HdnActual")) Then
            strHdnActual = (Request("HdnActual"))
        Else
            strHdnActual = ""
        End If

        If Not IsNothing(Request("HdnTresMeses")) Then
            strHdnTresMeses = (Request("HdnTresMeses"))
        Else
            strHdnTresMeses = ""
        End If

        If Not IsNothing(Request("HdnTeorico")) Then
            strHdnTeorico = (Request("HdnTeorico"))
        Else
            strHdnTeorico = ""
        End If

        If Not IsNothing(Request("HdnUnMes")) Then
            strHdnUnMes = (Request("HdnUnMes"))
        Else
            strHdnUnMes = ""
        End If

        If Not IsNothing(Request("HdnVigencia")) Then
            strHdnVigencia = (Request("HdnVigencia"))
        Else
            strHdnVigencia = ""
        End If

        If Not IsNothing(Request("HdnUnaSemana")) Then
            strHdnUnaSemana = (Request("HdnUnaSemana"))
        Else
            strHdnUnaSemana = ""
        End If

        If Not IsNothing(Request("HdnClaveVigencia")) Then
            strHdnClaveVigencia = (Request("HdnClaveVigencia"))
        Else
            strHdnClaveVigencia = ""
        End If
    End Sub

    Private Function strGeneraTabla(ByVal objArray As Array, _
                                  ByVal strTitulo As String, _
                                  ByVal strEncaCol0 As String, _
                                  ByRef intConsecutivo As Integer, _
                                  ByVal strEncaCol1 As String, _
                                  ByVal strEncaCol2 As String, _
                                  ByVal strEncaCol3 As String, _
                                  ByVal strEncaCol4 As String, _
                                  ByVal strEncaCol5 As String, _
                                  ByVal strEncaCol6 As String, _
                                  ByVal strEncaCol7 As String _
                                  ) As String
        Dim strHTML As StringBuilder
        Dim strRegistro As String()
        strRegistro = Nothing
        Dim intRenglon As Integer
        Dim strClass As String
        Dim strComilla As String
        Dim strReadonly As String

        strComilla = """"

        strHTML = New StringBuilder
        strHTML.Append("")

        strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strHTML.Append("<tr class='trtitulos'>")
        strHTML.Append("<th colspan='3'><span class='txsubtitulo'>")
        strHTML.Append("<img src='../static/images/bullet_subtitulos.gif' width='17' height='11' ")
        strHTML.Append("align='absmiddle'>" & strTitulo & "</span>")
        strHTML.Append("</th>")
        strHTML.Append("</tr>")

        strHTML.Append("<tr class='trtitulos'>")
        strHTML.Append("<th width='0'   class='rayita'>" & strEncaCol0 & "&nbsp;</th>")
        strHTML.Append("<th width='61'  class='rayita'>" & strEncaCol1 & "&nbsp;</th>")
        strHTML.Append("<th width='200' class='rayita'>" & strEncaCol2 & "&nbsp;</th>")
        strHTML.Append("<th class='rayita' nowrap>" & strEncaCol3 & "&nbsp;</th>")
        strHTML.Append("<th class='rayita' nowrap>" & strEncaCol4 & "&nbsp;</th>")
        strHTML.Append("<th class='rayita'>" & strEncaCol5 & "&nbsp;</th>")
        strHTML.Append("<th class='rayita'>" & strEncaCol6 & "&nbsp;</th>")
        strHTML.Append("<th class='rayita' align='right'>" & strEncaCol7 & "&nbsp;</th>")
        strHTML.Append("</tr>")

        '------------------------
        intRenglon = 0
        If IsArray(objArray) AndAlso (objArray.Length > 0) Then
            For Each strRegistro In objArray

                intConsecutivo += 1
                intRenglon += 1
                If ((intRenglon Mod 2) = 0) Or (intRenglon = 0) Then
                    strClass = "tdceleste"
                Else
                    strClass = "tdblanco"
                End If
                strHTML.Append("<tr>")

                '0 intArticuloId 
                '1 intArticuloInventarioSugeridoCantidad 
                '2 strArticuloDescripcion   
                '3 intArticuloSucursalExistenciaIdeal                                                                                                                                                                                                                                       
                '4 intTotalRegistros

                'Columna 0
                strHTML.Append("<td class='" & strClass & "'>" & clsCommons.strFormatearDescripcion(strRegistro(0)) & "&nbsp;</td>")

                'Columna 1
                strHTML.Append("<td class='" & strClass & "'>" & "" & "&nbsp;</td>")

                'Columna 2
                strHTML.Append("<td class='" & strClass & "'>" & clsCommons.strFormatearDescripcion(strRegistro(2)) & "&nbsp;</td>")

                'Columna 3
                strHTML.Append("<td align='right' class='" & strClass & "'>" & clsCommons.strFormatearDescripcion(strRegistro(3)) & "&nbsp;</td>")

                'Columna 4
                strHTML.Append("<td align='right' class='" & strClass & "'>" & clsCommons.strFormatearDescripcion(strRegistro(1)) & "&nbsp;</td>")

                'Columna 5
                strHTML.Append("<td align='right' class='" & strClass & "'>" & "&nbsp;</td>")

                'Columna 6
                strHTML.Append("<td align='right' class='" & strClass & "'>" & "&nbsp;</td>")

                'Columna 7
                strHTML.Append("<td align='right' class='" & strClass & "' nowrap><a style=" & strComilla & "text-decoration: none" & strComilla & " href=" & strComilla & "javascript:fnBorrarPartida(" & "" & "" & strRegistro(0) & ")" & strComilla & ">" & "<img src=../static/images/icono_borrar.gif width=11 height=13 border=0 align=absmiddle><font color=#575757> Borrar&nbsp;</font>" & "</a></td>")

                strHTML.Append("</tr>")
            Next
        End If
        '------------------------

        strHTML.Append("</table>")
        strHTML.Append("<input type=hidden name=hdnTotalDePartidas value=" & intRenglon.ToString & ">")
        strGeneraTabla = clsCommons.strGenerateJavascriptString(strHTML.ToString)
    End Function

End Class
