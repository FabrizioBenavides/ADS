Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration

Public Class MercanciaCapturarDevolucionesDeInsumos
    Inherits System.Web.UI.Page

    Const strComitasDobles As String = """"

    Private strmListaHTML As String
    Private intmRegistrosLista As Integer
    Private intmDevolucionId As Integer


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
    ' Name       : strGeneraListaMotivosDeDevolucion
    ' Description: Lista con los motivos de devolucion para objeto combo
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGeneraListaMotivosDeDevolucion(ByVal strObjeto As String) As String

        Dim intContador As Integer, intConsecutivo As Integer
        Dim strLista As String

        Dim objMotivosDevolucion As Array = Nothing
        Dim strRegistro As String()
        strRegistro = Nothing

        objMotivosDevolucion = clstblMotivoDevolucion.strBuscar(0, String.Empty, String.Empty, CDate("01/01/1900"), String.Empty, 0, 0, strCadenaConexion)

        '------------------------
        strLista = "document.forms[0].elements('" & strObjeto & "').options[0] = new Option(""Seleccione un motivo"",-1 );" & vbCrLf
        intConsecutivo = 0
        If IsArray(objMotivosDevolucion) AndAlso (objMotivosDevolucion.Length > 0) Then
            For Each strRegistro In objMotivosDevolucion
                intConsecutivo += 1
                strLista += "document.forms[0].elements('" & strObjeto & "')" & _
                                 ".options[" & intConsecutivo.ToString & "] " & _
                                 "= new Option(""" & clsCommons.strFormatearDescripcion(strRegistro(1)).ToString & """,""" & _
                                 strRegistro(0).ToString & """);" & vbCrLf

            Next
        End If
        '------------------------
        Return strLista

    End Function

    '====================================================================
    ' Name       : strCmd
    ' Description: string de Comandos de control
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Not IsNothing(Request.QueryString("strCmd")) Then
                Return Request.QueryString("strCmd")
            Else
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strTxtFechaDeDevolucionMDY
    ' Description: valor del control 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTxtFechaDeDevolucionMDY() As String
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("txtFechaDeDevolucion"))

            If strTemporal.Equals(String.Empty) Then
                Return String.Empty
            Else
                Return clsCommons.strDMYtoMDY(strTemporal)
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strCmbMotivo
    ' Description: valor del control 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmbMotivo() As String
        Get

            Dim strTemporal As String

            strTemporal = Trim(Request("cmbMotivo"))

            If strTemporal.Equals(String.Empty) Then
                Return String.Empty
            Else
                Return strTemporal
            End If

        End Get
    End Property


    '====================================================================
    ' Name       : strTipoProveedorNombreId
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strTipoProveedorNombreId() As String
        Get
            Dim strTemporal As String

            Return strTemporal

        End Get
    End Property

    '====================================================================
    ' Name       : intProveedorId
    ' Description: Identificador interno del proveedor
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intProveedorId() As Integer
        Get
            If Len(Request("hdnProveedorId")) > 0 AndAlso IsNumeric(Request("hdnProveedorId")) Then
                Return CInt(Request("hdnProveedorId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strProveedorNombreId
    ' Description: valor del control txtProveedor
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strProveedorNombreId() As String
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("txtProveedorNombreId"))

            If strTemporal.Equals(String.Empty) Then
                Return String.Empty
            Else
                Return strTemporal
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : strTxtFactura
    ' Description: valor del control 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTxtFactura() As String
        Get
            Dim strTemporal As String
            strTemporal = Trim(Request("txtNumeroFactura"))
            If strTemporal.Equals(String.Empty) Then
                Return String.Empty
            Else
                Return strTemporal
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strTxtNoDeDocumento
    ' Description: valor del control 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTxtNoDeDocumento() As String
        Get
            Dim strTemporal As String
            strTemporal = Trim(Request("txtNoDeDocumento"))
            If strTemporal.Equals(String.Empty) Then
                Return String.Empty
            Else
                Return strTemporal
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strTxtintArticuloId
    ' Description: valor del control TxtintArticuloId
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTxtintArticuloId() As String
        Get
            Dim strTemporal As String
            strTemporal = Trim(Request("txtintArticuloId"))
            If strTemporal.Equals(String.Empty) Then
                Return String.Empty
            Else
                Return strTemporal
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strTxtCantidad
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strTxtCantidad() As String
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("txtCantidad"))

            If strTemporal.Equals(String.Empty) Then
                Return String.Empty
            Else
                Return strTemporal
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strTxtCifraDeControl
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTxtCifraDeControl() As String
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("txtCifraDeControl"))

            If strTemporal.Equals(String.Empty) Then
                Return String.Empty
            Else
                Return strTemporal
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strListaHTML
    ' Description: 
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public Property strListaHTML() As String
        Get
            Return strmListaHTML
        End Get
        Set(ByVal intValue As String)
            strmListaHTML = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intRegistrosLista
    ' Description: 
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intRegistrosLista() As Integer
        Get
            Return intmRegistrosLista
        End Get
        Set(ByVal intValue As Integer)
            intmRegistrosLista = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : hdnDevolucionId
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property hdnDevolucionId() As String
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("hdnDevolucionId"))

            If strTemporal.Equals(String.Empty) Then
                Return "0"
            Else
                Return strTemporal
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : txtDevolucionFolio
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property txtDevolucionFolio() As String
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("txtDevolucionFolio"))

            If strTemporal.Equals(String.Empty) Then
                Return "0"
            Else
                Return strTemporal
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : intDevolucionId
    ' Description: 
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intDevolucionId() As Integer
        Get
            Return intmDevolucionId
        End Get
        Set(ByVal intValue As Integer)
            intmDevolucionId = intValue
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
        'If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
        '    Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        'End If


        Dim objArrayConsulta As Array = Nothing
        Dim strRegistroConsulta As String() = Nothing
        Dim intResultado As Integer

        Dim strHTML As StringBuilder

        intDevolucionId = CInt(hdnDevolucionId)


        strHTML = New StringBuilder

        Select Case strCmd

            Case "BuscarProveedor"

                Dim objArrayProveedor As Array = Nothing
                Dim objRegistroProveedor As System.Collections.SortedList = Nothing

                Dim strBusquedaProveedorId As String = String.Empty
                Dim strBusquedaProveedorNombreId As String = String.Empty
                Dim strBusquedaProveedorRazonSocial As String = String.Empty
                Dim strBusquedaProveedorRFC As String = String.Empty
                Dim strBusquedaProveedorError As String = "-100"
                Dim intTipoVigencia As Integer = 2 ' Consulta todos los proveedores

                If IsNumeric(Mid(strProveedorNombreId, 1, 4)) Then

                    objArrayProveedor = clsCapturaInsumosMateriaPrima.strBuscarProveedorInsumosMateriaPrima(intCompaniaId, intSucursalId, String.Empty, strProveedorNombreId, intTipoVigencia, 0, 0, strCadenaConexion)


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

            Case "BuscarFactura"

                Dim objArrayFactura As Array = Nothing
                Dim strRegistroFactura As String()

                Dim intFacturaId As Integer = 0
                Dim strErrorFactura As String = String.Empty

                'Buscamos la Factura Asociada a la devolucion
                objArrayFactura = clsCapturaInsumosMateriaPrima.strBuscarFactura(intCompaniaId, intSucursalId, intProveedorId, strTxtFactura, strCadenaConexion)

                If IsArray(objArrayFactura) AndAlso (objArrayFactura.Length > 0) Then

                    strRegistroFactura = DirectCast(objArrayFactura.GetValue(0), String())
                    intFacturaId = CInt(strRegistroFactura(0))
                    strErrorFactura = "0"

                Else
                    strErrorFactura = "-100"
                End If

                strHTML.Append("<script language='javascript'> parent.fnUpdFacturaPorIframe( " & _
                              "'" & intFacturaId.ToString & "', " & _
                              "'" & strErrorFactura & "'  " & _
                               ") </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "BuscarArticulo"

                Dim strAccion As String = "BUSCAR"
                Dim strErrorBuscaArticulo As String = "0"

                Dim objArrayArticulo As Array = Nothing
                Dim objRegistroArticulo As System.Collections.SortedList = Nothing

                Dim intArticuloBuscadoId As Integer
                Dim strArticuloBuscadoDescripcion As String

                ' Obtenemos la información de los Articulos
                objArrayArticulo = clsCapturaInsumosMateriaPrima.strBuscarArticuloInsumosMateriaPrima(intCompaniaId, intSucursalId, strTxtintArticuloId, intProveedorId, "INSUMOSMATERIAPRIMA", 0, 0, 0, strCadenaConexion)

                If IsArray(objArrayArticulo) AndAlso (objArrayArticulo.Length > 0) Then

                    objRegistroArticulo = DirectCast(objArrayArticulo.GetValue(0), System.Collections.SortedList)

                    intArticuloBuscadoId = CInt(objRegistroArticulo.Item("intArticuloId"))
                    strArticuloBuscadoDescripcion = clsCommons.strFormatearDescripcion(CStr(objRegistroArticulo.Item("strArticuloDescripcion")))
                    strErrorBuscaArticulo = "0"

                Else
                    intArticuloBuscadoId = 0
                    strArticuloBuscadoDescripcion = String.Empty
                    strErrorBuscaArticulo = "-1"

                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpdArticuloPorIframe( " & _
                strComitasDobles & strAccion & strComitasDobles & "," & _
                strComitasDobles & strListaHTML & strComitasDobles & "," & _
                strComitasDobles & intRegistrosLista & strComitasDobles & "," & _
                strComitasDobles & intDevolucionId & strComitasDobles & "," & _
                strComitasDobles & intArticuloBuscadoId.ToString & strComitasDobles & "," & _
                strComitasDobles & strArticuloBuscadoDescripcion & strComitasDobles & "," & _
                strComitasDobles & strErrorBuscaArticulo & strComitasDobles & _
                "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()


            Case "AgregarArticulo"

                Dim strAccion As String = "AGREGAR"
                Dim strErrorAgregarArticulo As String = "0"

                Dim objArrayArticulo As Array = Nothing
                Dim objRegistroArticulo As System.Collections.SortedList = Nothing

                Dim intArticuloAgregarId As Integer
                Dim intFacturaAgregarId As Integer


                'Validar en el momento antes de insertar que el articulo exista
                '----------------------------------------------------------------
                objArrayArticulo = clsCapturaInsumosMateriaPrima.strBuscarArticuloInsumosMateriaPrima(intCompaniaId, intSucursalId, strTxtintArticuloId, intProveedorId, "INSUMOSMATERIAPRIMA", 0, 0, 0, strCadenaConexion)

                If IsArray(objArrayArticulo) AndAlso (objArrayArticulo.Length > 0) Then
                    objRegistroArticulo = DirectCast(objArrayArticulo.GetValue(0), System.Collections.SortedList)

                    intArticuloAgregarId = CInt(objRegistroArticulo.Item("intArticuloId"))

                End If
                '----------------------------------------------------------------


                If (intArticuloAgregarId > 0) Then


                    'Registrar la devolucion si aun no esta registrada
                    If intDevolucionId.Equals(0) Then

                        If LCase(Trim(strTipoProveedorNombreId)) = "proveedormayorista" Then 'Si el Proveedor es Mayorista  


                            ' Validar que la Factura asociada a la devolucion exista 
                            ' si el motivo es 3 4 5
                            If CInt(strCmbMotivo) = 3 Or CInt(strCmbMotivo) = 4 Or CInt(strCmbMotivo) = 5 Then

                                Dim objArrayFactura As Array = Nothing
                                Dim strRegistroFactura As String()

                                'Buscamos la Factura Asociada a la devolucion
                                objArrayFactura = clsCapturaInsumosMateriaPrima.strBuscarFactura(intCompaniaId, intSucursalId, intProveedorId, strTxtFactura, strCadenaConexion)

                                If IsArray(objArrayFactura) AndAlso (objArrayFactura.Length > 0) Then
                                    strRegistroFactura = DirectCast(objArrayFactura.GetValue(0), String())
                                    intFacturaAgregarId = CInt(strRegistroFactura(0))
                                Else
                                    intFacturaAgregarId = 0
                                End If

                                If intFacturaAgregarId = 0 Then

                                    strErrorAgregarArticulo = "-90"

                                    strHTML.Append("<script language='Javascript'> parent.fnUpdArticuloPorIframe( " & _
                                    strComitasDobles & strAccion & strComitasDobles & "," & _
                                    strComitasDobles & strListaHTML & strComitasDobles & "," & _
                                    strComitasDobles & intRegistrosLista & strComitasDobles & "," & _
                                    strComitasDobles & intDevolucionId & strComitasDobles & "," & _
                                    strComitasDobles & String.Empty & strComitasDobles & "," & _
                                    strComitasDobles & String.Empty & strComitasDobles & "," & _
                                    strComitasDobles & strErrorAgregarArticulo & strComitasDobles & _
                                    "); </script>")

                                    Response.Write(strHTML.ToString)
                                    Response.End()

                                End If

                            End If

                        End If

                        'Registrar Devolucion 
                        intDevolucionId = clsCapturaInsumosMateriaPrima.intAgregarDevolucion(0, intCompaniaId, intSucursalId, intProveedorId, CInt(strCmbMotivo), 0, 0, CInt(strTxtNoDeDocumento), strTxtFactura, CDate(strTxtFechaDeDevolucionMDY), CDate("01/01/1900"), strUsuarioNombre, strCadenaConexion)

                    End If

                    ' Agregar el articulo al detalle
                    If intDevolucionId > 0 Then

                        intResultado = clsCapturaInsumosMateriaPrima.intAgregarArticuloDevolucionInsumosMateriaPrima(intDevolucionId, intArticuloAgregarId, CInt(strTxtCantidad), Date.Now(), strUsuarioNombre, strCadenaConexion)

                        If intResultado < 1 Then
                            strErrorAgregarArticulo = "-110" ' Articulo no puedo agregarse a la devolucion
                        Else
                            strErrorAgregarArticulo = "0"
                        End If

                        objArrayConsulta = Nothing
                        objArrayConsulta = clsCapturaInsumosMateriaPrima.strBuscarDetalleDevolucion(intCompaniaId, intSucursalId, intDevolucionId, strCadenaConexion)

                        strListaHTML = strGeneraTabla(objArrayConsulta, "Detalles de producto", "No.", 0, "Código", "Descripción", "Cantidad", "Acción")

                    Else

                        strErrorAgregarArticulo = "-100" 'No se pudo comenzar registro de la devolucion

                    End If

                Else

                    strErrorAgregarArticulo = "-120"

                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpdArticuloPorIframe( " & _
                strComitasDobles & strAccion & strComitasDobles & "," & _
                strComitasDobles & strListaHTML & strComitasDobles & "," & _
                strComitasDobles & intRegistrosLista & strComitasDobles & "," & _
                strComitasDobles & intDevolucionId & strComitasDobles & "," & _
                strComitasDobles & String.Empty & strComitasDobles & "," & _
                strComitasDobles & String.Empty & strComitasDobles & "," & _
                strComitasDobles & strErrorAgregarArticulo & strComitasDobles & _
                "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "EliminarArticulo"

                Dim strAccion As String = "ELIMINAR"
                Dim strErrorEliminarArticulo As String = "0"

                Dim intDevolucionEliminarId As Integer = CInt(Request.QueryString("intDevolucionIdEliminar"))
                Dim intArticuloEliminarId As Integer = CInt(Request.QueryString("intArticuloIdEliminar"))

                intResultado = clsCapturaInsumosMateriaPrima.intEliminarArticuloDevolucion(intDevolucionEliminarId, intArticuloEliminarId, 0, CDate("01/01/1900"), "", strCadenaConexion)

                If intResultado > 0 Then
                    strErrorEliminarArticulo = "0"
                Else
                    strErrorEliminarArticulo = "-100"
                End If

                'Buscar Detalle de laDevolucion
                If intDevolucionId > 0 Then

                    objArrayConsulta = Nothing
                    objArrayConsulta = clsCapturaInsumosMateriaPrima.strBuscarDetalleDevolucion(intCompaniaId, intSucursalId, intDevolucionId, strCadenaConexion)

                    strListaHTML = strGeneraTabla(objArrayConsulta, "Detalles de producto", "No.", 0, "Código", "Descripción", "Cantidad", "Acción")

                    If IsArray(objArrayConsulta) AndAlso (objArrayConsulta.Length < 1) Then
                        intDevolucionId = 0 'Con esto indicamos que la captura vuelve a comezar
                    End If

                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpdArticuloPorIframe( " & _
                strComitasDobles & strAccion & strComitasDobles & "," & _
                strComitasDobles & strListaHTML & strComitasDobles & "," & _
                strComitasDobles & intRegistrosLista & strComitasDobles & "," & _
                strComitasDobles & intDevolucionId & strComitasDobles & "," & _
                strComitasDobles & String.Empty & strComitasDobles & "," & _
                strComitasDobles & String.Empty & strComitasDobles & "," & _
                strComitasDobles & strErrorEliminarArticulo & strComitasDobles & _
                "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "Registrar"

                Dim strAccion As String = "REGISTRAR"
                Dim strErrorRegistro As String = "0"

                If Trim(Request("txtDevolucionFolio")).Equals("") Then

                    intResultado = clsCapturaInsumosMateriaPrima.intRegistrarDevolucion(intCompaniaId, intSucursalId, intDevolucionId, strUsuarioNombre, strCadenaConexion)

                    If (intResultado > 0) Then
                        strErrorRegistro = "0"
                    Else
                        strErrorRegistro = "-100" ' No fue posible registrar la devolución
                    End If

                End If

                'Buscar Detalle Devolucion
                If intDevolucionId > 0 Then

                    objArrayConsulta = Nothing
                    objArrayConsulta = clsCapturaInsumosMateriaPrima.strBuscarDetalleDevolucion(intCompaniaId, intSucursalId, intDevolucionId, strCadenaConexion)

                    strListaHTML = strGeneraTabla(objArrayConsulta, "Detalles de producto", "No.", 0, "Código", "Descripción", "Cantidad", "Acción")
                End If

                strHTML.Append("<script language='Javascript'> parent.fnRegistrarDevolucionPorIframe( " & _
                strComitasDobles & strListaHTML & strComitasDobles & "," & _
                strComitasDobles & intRegistrosLista & strComitasDobles & "," & _
                strComitasDobles & intDevolucionId & strComitasDobles & "," & _
                strComitasDobles & intResultado & strComitasDobles & "," & _
                strComitasDobles & strErrorRegistro & strComitasDobles & _
                "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

        End Select

    End Sub

    Private Function strGeneraTabla(ByVal objArray As Array, _
                                  ByVal strTitulo As String, _
                                  ByVal strEncaCol0 As String, _
                                  ByRef intConsecutivo As Integer, _
                                  ByVal strEncaCol1 As String, _
                                  ByVal strEncaCol2 As String, _
                                  ByVal strEncaCol3 As String, _
                                  ByVal strEncaCol4 As String _
                                  ) As String

        Dim strHTML As StringBuilder = Nothing
        Dim strRegistro As String() = Nothing
        Dim intRenglon As Integer
        Dim dblTotal As Double
        Dim strClass As String
        Dim strComilla As String
        Dim strReadonly As String

        strComilla = """"

        strHTML = New StringBuilder

        strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        strHTML.Append("<tr class='trtitulos'>")
        strHTML.Append("<th width='25'  class='rayita'>" & strEncaCol0 & "</th>")
        strHTML.Append("<th width='61'  class='rayita'>" & strEncaCol1 & "</th>")
        strHTML.Append("<th width='175' class='rayita'>" & strEncaCol2 & "</th>")
        strHTML.Append("<th width='54'  class='rayita'>" & strEncaCol3 & "</th>")
        strHTML.Append("<th width='72'  class='rayita'>" & strEncaCol4 & "</th>")
        strHTML.Append("</tr>")

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

                strHTML.Append("<td class='" & strClass & "'>" & intConsecutivo.ToString & "&nbsp;</td>")

                strHTML.Append("<td class='" & strClass & "'>" & clsCommons.strFormatearDescripcion(strRegistro(0)).ToString & "&nbsp;</td>")
                strHTML.Append("<td class='" & strClass & "'>" & clsCommons.strFormatearDescripcion(strRegistro(2)).ToString & "&nbsp;</td>")
                strHTML.Append("<td class='" & strClass & "'>" & clsCommons.strFormatearDescripcion(strRegistro(1)).ToString & "&nbsp;</td>")
                strHTML.Append("<input type=hidden name=txtCantidad_" & Trim(CStr(intRenglon)) & " value=" & strComilla & clsCommons.strFormatearDescripcion(strRegistro(1)).ToString & strComilla & ">")
                strHTML.Append("<td class='" & strClass & "'><a style=" & strComilla & "text-decoration: none" & strComilla & " href=" & strComilla & "javascript:intEliminarArticulo(" & CStr(intDevolucionId) & "," & clsCommons.strFormatearDescripcion(strRegistro(0)) & ")" & strComilla & ">" & "<img src=../static/images/icono_borrar.gif width=11 height=13 border=0 align=absmiddle><font color=#575757> Borrar</font>" & "</a></td>")

                strHTML.Append("</tr>")
            Next
        End If
        '------------------------

        strHTML.Append("</table>")

        intRegistrosLista = intRenglon

        If intRenglon > 0 Then
            strGeneraTabla = clsCommons.strGenerateJavascriptString(strHTML.ToString)
        Else
            strGeneraTabla = String.Empty
        End If

    End Function


End Class

