Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Business.clsConcentrador.clsSucursal.clsMercancia
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class clsMercanciaRemisionCompraDirectaCapturar
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


#Region " Class Private Attributes"
    Const strComitasDobles As String = """"

    Private intmCapturaId As Long = 0
    Private intmCantidadArticulos As Integer
    Private strmParametros As String = ""

    Private strmRazonSocialProveedor As String = ""

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
    ' Name       : strFormActionParameters
    ' Description: Parametros utilizados
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormActionParameters() As String
        Get
            Return ""
        End Get
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Comando a ejecutar
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Not IsNothing(Request.QueryString("strCmd")) Then
                Return (Request.QueryString("strCmd"))
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaActual
    ' Description: Fecha actual utilizada para validar
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaActual() As String
        Get
            Return Date.Now.ToString("dd/MM/yyyy")
        End Get
    End Property

    '====================================================================
    ' Name       : strCapturaId
    ' Description: 
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCapturaId() As String
        Get
            If Len(Request("hdnCapturaId")) > 0 Then
                Return (Request("hdnCapturaId"))
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intCapturaId 
    ' Description: Id de la captura
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intCapturaId() As Long
        Get
            Return intmCapturaId
        End Get
        Set(ByVal dblValue As Long)
            intmCapturaId = dblValue
        End Set
    End Property

    '====================================================================
    ' Name       : intProveedorId
    ' Description: Toma la llave interna del proveedor
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intProveedorId() As Integer
        Get
            If Len(Request("hdnProveedorId")) > 0 Then
                Return CInt(Request("hdnProveedorId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strProveedorNombreId
    ' Description: Toma el numero sap del proveedor
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public ReadOnly Property strProveedorNombreId() As String
        Get
            If Len(Request("txtProveedorNombreId")) > 0 Then
                Return Request("txtProveedorNombreId")
            Else
                Return ""
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : strRazonSocialProveedor
    ' Description: Razon social del proveedor
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRazonSocialProveedor() As String
        Get
            Return strmRazonSocialProveedor
        End Get
        Set(ByVal strValue As String)
            strmRazonSocialProveedor = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strNumeroRemision
    ' Description:  
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public ReadOnly Property strNumeroRemision() As String
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("txtNumeroRemision"))

            If strTemporal.Equals("") Then
                Return ""
            Else
                Return strTemporal
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaRecepcionMDY
    ' Description: valor del control 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : date
    '====================================================================
    Public ReadOnly Property dtmFechaRecepcionMDY() As Date
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("txtFechaRecepcion"))

            If strTemporal.Equals("") Then
                Return CDate("01/01/1900")
            Else
                Return CDate(clsCommons.strDMYtoMDY(strTemporal))
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaRemisionMDY
    ' Description: valor del control 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaRemisionMDY() As Date
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("txtFechaRemision"))

            If strTemporal.Equals("") Then
                Return CDate("01/01/1900")
            Else
                Return CDate(clsCommons.strDMYtoMDY(strTemporal))
            End If
        End Get
    End Property


    '====================================================================
    ' Name       : intCantidadArticulos
    ' Description:  
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intCantidadArticulos() As Integer
        Get
            Return intmCantidadArticulos
        End Get
        Set(ByVal intValue As Integer)
            intmCantidadArticulos = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Genera Record Browser
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String

        Dim objRemisionCompraDirecta As Array = Nothing
        Dim objRegistroRemisionCompraDirecta As System.Collections.SortedList = Nothing

        Dim strHTML As StringBuilder
        Dim intConsecutivo As Integer = 0
        Dim strColorRegistro As String = ""
        Dim intCantidad As Integer = 0


        strHTML = New StringBuilder

        strHTML.Append("")

        objRemisionCompraDirecta = clsCompras.clsRemision.strBuscarDetalle(intCompaniaId, intSucursalId, intCapturaId, strCadenaConexion)

        If IsArray(objRemisionCompraDirecta) AndAlso objRemisionCompraDirecta.Length > 0 Then

            strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strHTML.Append("<tr class='trtitulos'>")
            strHTML.Append("<th width='06%' class='rayita' align='left'>No.</th>")
            strHTML.Append("<th width='04%' class='rayita' align='left'>&nbsp;</th>")
            strHTML.Append("<th width='15%' class='rayita' align='left'>C&oacute;digo</th>")
            strHTML.Append("<th width='55%' class='rayita' align='left'>Descripci&oacute;n</th>")
            strHTML.Append("<th width='10%' class='rayita' align='left'>Cantidad</th>")
            strHTML.Append("<th width='10%' class='rayita' align='center'>Acci&oacute;n</th>")
            strHTML.Append("</tr>")

            For Each objRegistroRemisionCompraDirecta In objRemisionCompraDirecta

                intConsecutivo += 1

                If (intConsecutivo Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If

                intCantidad += CInt(objRegistroRemisionCompraDirecta.Item("intArticuloRemisionCompraDirectaCantidad"))

                strHTML.Append("<tr>")
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & intConsecutivo.ToString & "</td>") ' No
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>&nbsp;</td>")
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & CStr(objRegistroRemisionCompraDirecta.Item("intArticuloId")) & "</td>") ' Articulo
                strHTML.Append("<td class=" & strColorRegistro & " align='left'> " & clsCommons.strFormatearDescripcion(CStr(objRegistroRemisionCompraDirecta.Item("strArticuloDescripcion"))) & "</td>") ' Descripción
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & CStr(objRegistroRemisionCompraDirecta.Item("intArticuloRemisionCompraDirectaCantidad")) & "</td>") ' Cantidad
                strHTML.Append("<td class=" & strColorRegistro & " align='center'>" & "<a href='javascript:cmdEliminar_onclick(" & CStr(objRegistroRemisionCompraDirecta.Item("intArticuloId")) & ");'><img src='../static/images/icono_borrar.gif' alt='Eliminar artículo' width='11' height='13' border='0' align='absmiddle'></a>&nbsp;&nbsp;</td>") ' accion
                strHTML.Append("</tr>")

            Next

            intCantidadArticulos = intCantidad

            strHTML.Append("</table>")


        End If

        strHTML.Append("<input type='hidden' name='txtArticulosLista' value = '" & intCantidadArticulos.ToString & "'>")

        Return strHTML.ToString


    End Function

    '====================================================================
    ' Name       : strArticuloCapturado
    ' Description: Cadena para buscar el numero de articulo
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strArticuloCapturado() As String
        Get
            If Not IsNothing(Request("txtArticuloId")) Then
                Return Request("txtArticuloId")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intArticuloEliminarId
    ' Description: Número de articulo a Eliminar
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intArticuloEliminarId() As Integer
        Get
            If Not IsNothing(Request("intArticuloEliminarId")) Then
                Return CInt(Request("intArticuloEliminarId"))
            Else
                Return 0
            End If
        End Get
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
            Call Response.Redirect(strURLPOSAdmin & strRedirectPage)
        End If

        ' Recuperar o Agregar el Folio de Captura
        '--------------------------------------------
        intCapturaId = CLng(strCapturaId)

        If intCapturaId = 0 Then
            intCapturaId = Now.Ticks
        End If
        '--------------------------------------------


        Dim strHTML As StringBuilder

        Select Case strCmd

            Case "BuscaProveedor" ' Realizamos la busqueda del proveedor

                strHTML = New StringBuilder

                Dim objArrayProveedor As Array = Nothing
                Dim objRegistroProveedor As System.Collections.SortedList = Nothing

                Dim strBusquedaProveedorId As String = ""
                Dim strBusquedaProveedorNombreId As String = ""
                Dim strBusquedaProveedorRazonSocial As String = ""
                Dim strBusquedaProveedorError As String = "-100"

                If IsNumeric(Mid(strProveedorNombreId, 1, 4)) Then

                    objArrayProveedor = clsCompras.clsRemision.strBuscarProveedor(intCompaniaId, intSucursalId, strProveedorNombreId, 0, 0, strCadenaConexion)

                    If IsArray(objArrayProveedor) AndAlso objArrayProveedor.Length > 0 Then

                        objRegistroProveedor = DirectCast(objArrayProveedor.GetValue(0), System.Collections.SortedList)

                        ' Asignamos los datos del proveedor
                        strBusquedaProveedorError = "0"

                        strBusquedaProveedorId = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("intProveedorId")))
                        strBusquedaProveedorNombreId = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorNombreId")))
                        strBusquedaProveedorRazonSocial = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorRazonSocial")))

                    End If

                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpBuscarProveedor( " & _
                               strComitasDobles & strBusquedaProveedorId & strComitasDobles & "," & _
                               strComitasDobles & strBusquedaProveedorNombreId & strComitasDobles & "," & _
                               strComitasDobles & strBusquedaProveedorRazonSocial & strComitasDobles & "," & _
                               strComitasDobles & strBusquedaProveedorError & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "BuscarRemision" ' Validamos que la Remision no este ya capturada

                strHTML = New StringBuilder

                Dim strErrorBuscarRemision As String = ""

                Dim objArrayRemision As Array = Nothing

                Dim strRemisionCapturada As String = Trim(Request("txtNumeroRemision")).ToString()

                'Busca la Remision para la sucursal
                objArrayRemision = clsCompras.clsRemision.strBuscar(intProveedorId, intCompaniaId, intSucursalId, strRemisionCapturada, strCadenaConexion)

                If IsArray(objArrayRemision) AndAlso objArrayRemision.Length > 0 Then
                    strErrorBuscarRemision = "-100"
                Else
                    strErrorBuscarRemision = "0"
                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpBuscarRemision( " & _
                              strComitasDobles & strRazonSocialProveedor.ToString & strComitasDobles & "," & _
                              strComitasDobles & strErrorBuscarRemision & strComitasDobles & _
                              "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "BuscarArticulo"
                strHTML = New StringBuilder

                Dim objArrayArticulo As Array = Nothing
                Dim objRegistroArticulo As System.Collections.SortedList = Nothing

                Dim strArticuloId As String = ""
                Dim strDescripcionArticuloId As String = ""
                Dim strErrorBuscarArticulo As String = ""
                Dim intArticuloscompletos As Integer = 1

                ' Obtenemos la información del Articulo 

                objArrayArticulo = clsCompras.clsRemision.strBuscarArticulo(intCompaniaId, intSucursalId, strArticuloCapturado, intProveedorId, intArticuloscompletos, 0, 0, strCadenaConexion)

                If IsArray(objArrayArticulo) AndAlso (objArrayArticulo.Length > 0) Then

                    objRegistroArticulo = DirectCast(objArrayArticulo.GetValue(0), System.Collections.SortedList)

                    strArticuloId = CStr(objRegistroArticulo.Item("intArticuloId"))
                    strDescripcionArticuloId = clsCommons.strFormatearDescripcion(CStr(objRegistroArticulo.Item("strArticuloDescripcion")))

                    strErrorBuscarArticulo = "0"
                Else
                    strErrorBuscarArticulo = "-100"
                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpdArticuloPorIframe( " & _
                                strComitasDobles & strArticuloId & strComitasDobles & "," & _
                                strComitasDobles & strDescripcionArticuloId & strComitasDobles & "," & _
                                strComitasDobles & strErrorBuscarArticulo & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "AgregarArticulo"

                strHTML = New StringBuilder

                Dim intAccionArticulo As Integer = 1 'Agregar

                Dim intArticuloCompraDirectaId As Integer = 0
                Dim intArticuloCompraDirectaCantidad As Integer = 0
                Dim fltArticuloCompraDirectaCostoCapturado As Double = 0

                Dim intDepartamentoCompraDirecta As Integer
                Dim intAgregaArticulo As Integer = 0
                Dim strErrorAgregarArticulo As String = ""

                'Revisamos el articulo a agregar
                If IsNumeric(strArticuloCapturado) AndAlso CInt(strArticuloCapturado) > 0 Then

                    intArticuloCompraDirectaCantidad = CInt(Request.Form("txtCantidad"))

                    intAgregaArticulo = clsCompras.clsRemision.intAgregarArticulo(intCapturaId, CInt(strArticuloCapturado), intArticuloCompraDirectaCantidad, strUsuarioNombre, strCadenaConexion)

                End If

                If intAgregaArticulo > 0 Then
                    strErrorAgregarArticulo = "0"

                Else
                    strErrorAgregarArticulo = "-100"
                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpAgregarEliminarArticulo( " & _
                                 strComitasDobles & intAccionArticulo.ToString & strComitasDobles & "," & _
                                 strComitasDobles & intCapturaId.ToString & strComitasDobles & "," & _
                                 strComitasDobles & strRecordBrowserHTML.ToString & strComitasDobles & "," & _
                                 strComitasDobles & intCantidadArticulos.ToString & strComitasDobles & "," & _
                                 strComitasDobles & strErrorAgregarArticulo & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "EliminarArticulo"

                strHTML = New StringBuilder

                Dim intAccionArticulo As Integer = 2 'Eliminar
                Dim intEliminarArticulo As Integer = 0
                Dim strErrorEliminarArticulo As String = ""

                intEliminarArticulo = clsCompras.clsRemision.intBorrarArticulo(intCapturaId, intArticuloEliminarId, strCadenaConexion)

                If intEliminarArticulo > 0 Then
                    strErrorEliminarArticulo = "0"

                Else
                    strErrorEliminarArticulo = "-100"
                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpAgregarEliminarArticulo( " & _
                                 strComitasDobles & intAccionArticulo.ToString & strComitasDobles & "," & _
                                 strComitasDobles & intCapturaId.ToString & strComitasDobles & "," & _
                                 strComitasDobles & strRecordBrowserHTML.ToString & strComitasDobles & "," & _
                                 strComitasDobles & intCantidadArticulos.ToString & strComitasDobles & "," & _
                                 strComitasDobles & strErrorEliminarArticulo & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "Registrar"

                strHTML = New StringBuilder

                Dim intRemisionCompraDirectaId As Integer = 0
                Dim strErrorRegistrarRemisionCompra As String = ""

                intRemisionCompraDirectaId = clsCompras.clsRemision.intRegistrar(intCapturaId, intCompaniaId, intSucursalId, intProveedorId, dtmFechaRecepcionMDY, dtmFechaRemisionMDY, strNumeroRemision, strUsuarioNombre, strCadenaConexion)

                If intRemisionCompraDirectaId > 0 Then
                    strErrorRegistrarRemisionCompra = "0"
                Else
                    strErrorRegistrarRemisionCompra = intRemisionCompraDirectaId.ToString
                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpRegistrarRemisionCompraDirecta( " & _
                                 strComitasDobles & intRemisionCompraDirectaId.ToString & strComitasDobles & "," & _
                                 strComitasDobles & strErrorRegistrarRemisionCompra & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

        End Select

    End Sub
End Class
