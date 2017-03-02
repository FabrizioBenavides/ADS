Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class MercanciaCapturarDetalleInsumosMateriaPrima
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
            Return String.Empty
        End Get
    End Property

    '====================================================================
    ' Name       : fltTotalFacturado
    ' Description: Total facturado
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property fltTotalFacturado() As String
        Get
            ' Verificamos si se capturo descuento antes de iva
            ' si ese es el caso se tomara la suma de productos como 
            ' el total facturado.

            ' Tiene descuento antes de iva
            If Len(Request.Form("chkAntesdeIva")) > 0 Then
                If StrComp(Request.Form("chkAntesdeIva"), "1") = 0 Then
                    If Len(Request.Form("txtSumaProductos")) > 0 Then
                        Return clsCommons.strFormatearNumeroPresentacion(Request.Form("txtSumaProductos"), True)
                    End If
                End If
            End If

            ' Tiene descuento despues de iva
            If Len(Request.Form("chkDespuesdeIva")) > 0 Then
                If StrComp(Request.Form("chkDespuesdeIva"), "1") = 0 Then
                    If Len(Request.Form("txtTotalFacturado")) > 0 Then
                        Return clsCommons.strFormatearNumeroPresentacion(Request.Form("txtTotalFacturado"), True)
                    End If
                End If
            End If

            'No tiene descuento
            If Len(Request.Form("chkAntesdeIva")) = 0 AndAlso Len(Request.Form("chkDespuesdeIva")) = 0 Then
                If Len(Request.Form("txtTotalFacturado")) > 0 Then
                    Return clsCommons.strFormatearNumeroPresentacion(Request.Form("txtTotalFacturado"), True)
                End If
            End If
            Return "0"
        End Get
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Genera Record Browser
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String

        Dim objDataArray As Array = Nothing
        Dim objRegistro As String() = Nothing
        Dim strHTML As StringBuilder
        Dim intConsecutivo As Integer = 0
        Dim strColorRegistro As String = String.Empty
        Dim fltImporteTotal As Double = 0
        Dim strImporteTotal As String = String.Empty
        Dim intCantidadTotal As Double = 0

        strHTML = New StringBuilder

        strHTML.Append(String.Empty)

        objDataArray = clsCapturaInsumosMateriaPrima.strBuscarDetalle(intCompaniaId, intSucursalId, intFacturaId, strCadenaConexion)

        If IsArray(objDataArray) AndAlso objDataArray.Length > 0 Then

            strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strHTML.Append("<tr class='trtitulos'>")
            strHTML.Append("<th width='05%' class='rayita' align='right'>No.</th>")
            strHTML.Append("<th width='10%' class='rayita' align='right'>C&oacute;digo</th>")
            strHTML.Append("<th width='45%' class='rayita' align='left'>Descripci&oacute;n</th>")
            strHTML.Append("<th width='06%' class='rayita' align='right'>Cantidad</th>")

            If blnCapturaCosto = 1 Then
                strHTML.Append("<th width='08%' class='rayita' align='right'>C.Rep</th>")
                strHTML.Append("<th width='08%' class='rayita' align='right'>C.Cap</th>")
            Else
                strHTML.Append("<th width='08%' class='rayita' align='right'>C.Rep</th>")
                strHTML.Append("<th width='08%' class='rayita' align='right'>&nbsp;</th>")
            End If

            strHTML.Append("<th width='08%' class='rayita' align='right'>Importe</th>")
            strHTML.Append("<th width='10%' class='rayita' align='center'>Acci&oacute;n</th>")
            strHTML.Append("</tr>")

            For Each objRegistro In objDataArray

                intConsecutivo += 1

                If (intConsecutivo Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If

                fltImporteTotal += CDbl(objRegistro(5))
                intCantidadTotal += CDbl(objRegistro(2))

                strHTML.Append("<tr>")
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & intConsecutivo.ToString & "</td>") ' No
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & objRegistro(0).ToString & "</td>") ' Articulo
                strHTML.Append("<td class=" & strColorRegistro & " align='left'> " & clsCommons.strFormatearDescripcion(objRegistro(1)).ToString & "</td>") ' Descripción
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & clsCommons.strFormatearDescripcion(objRegistro(2)).ToString & "</td>") ' Cantidad 

                If blnCapturaCosto = 1 Then
                    strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & clsCommons.strFormatearNumeroPresentacion(objRegistro(3).ToString, True) & "</td>") ' CostoReposición 
                    strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & clsCommons.strFormatearNumeroPresentacion(objRegistro(4).ToString, True) & "</td>") ' CostoCapturado 
                Else
                    strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & clsCommons.strFormatearNumeroPresentacion(objRegistro(3).ToString, True) & "</td>") ' CostoReposición
                    strHTML.Append("<td class=" & strColorRegistro & " align='right'>&nbsp;</td>")
                End If

                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & clsCommons.strFormatearNumeroPresentacion(objRegistro(5).ToString, True) & "</td>") ' Importe
                strHTML.Append("<td class=" & strColorRegistro & " align='center'>" & "<a href='javascript:intEliminaRegistro(" & objRegistro(0).ToString & ");'><img src='../static/images/icono_borrar.gif' alt='Eliminar artículo' width='11' height='13' border='0' align='absmiddle'></a>&nbsp;&nbsp;</td>") ' accion
                strHTML.Append("</tr>")

            Next

            strImporteTotal = clsCommons.strFormatearNumeroPresentacion(fltImporteTotal.ToString, True)


            If ((intConsecutivo + 1) Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strHTML.Append("<tr>")
            strHTML.Append("<td class=" & strColorRegistro & " align='right'>&nbsp;</td>") ' No
            strHTML.Append("<td class=" & strColorRegistro & " align='right'>&nbsp;</td>") ' Articulo
            strHTML.Append("<td class=" & strColorRegistro & " align='left'>Total</td>")   ' Descripción
            strHTML.Append("<td class=" & strColorRegistro & " align='right'>&nbsp;</td>") ' Cantidad 
            strHTML.Append("<td class=" & strColorRegistro & " align='right'>&nbsp;</td>") ' CostoReposición
            strHTML.Append("<td class=" & strColorRegistro & " align='right'>&nbsp;</td>")
            strHTML.Append("<td class=" & strColorRegistro & " align='right'><input name='txtImporteTotal' type='text' class='campotablahabilitadoderechasinborde' readonly='true' value=" & strImporteTotal & "></td>")  ' Importe
            strHTML.Append("<td class=" & strColorRegistro & " align='center'>&nbsp;</td>") ' accion
            strHTML.Append("</tr>")

            strHTML.Append("</table>")

        End If

        strHTML.Append("<input type='hidden' name='txtArticulosLista' value = '" & intConsecutivo.ToString & "'>")
        strHTML.Append("<input type='hidden' name='txtCantidadTotal'  value = '" & intCantidadTotal.ToString & "'>")

        Return strHTML.ToString

    End Function

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
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intFacturaId
    ' Description: Numero de compra directa
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intFacturaId() As Integer
        Get
            If Len(Request("txtFacturaId")) > 0 Then
                Return CInt(Request("txtFacturaId"))
            Else
                Return 0
            End If
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
                Return String.Empty
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : intImpuestoFactura
    ' Description: Iva aplicado
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Double
    '====================================================================
    Public ReadOnly Property intImpuestoFactura() As Double
        Get
            Return CDbl(Request.Form("cboIvaAplicado"))
        End Get
    End Property

    '====================================================================
    ' Name       : strArticuloCapturado
    ' Description: Cadena para buscar el numero de articulo
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strArticuloCapturado() As String
        Get
            If Not IsNothing(Request.Form("txtArticuloId")) Then
                Return Request.Form("txtArticuloId")
            Else
                Return String.Empty
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
            If Not IsNothing(Request.QueryString("intArticuloEliminarId")) Then
                Return CInt(Request.QueryString("intArticuloEliminarId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : blnCapturaCosto
    ' Description: Capturar costo del Articulo
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property blnCapturaCosto() As Integer
        Get
            If Len(Request("hdnCapturaCosto")) > 0 Then
                Return CInt(Request("hdnCapturaCosto"))
            Else
                Return 1
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

        Dim strHTML As StringBuilder

        If Not (intFacturaId > 0) Then
            Response.Redirect("MercanciaCapturarInsumosMateriaPrima.aspx")
        End If

        Select Case strCmd

            Case "BuscarArticulo"
                strHTML = New StringBuilder

                Dim objArrayArticuloProveedor As Array = Nothing
                Dim objRegistroArticuloProveedor As System.Collections.SortedList = Nothing


                Dim strArticuloId As String = String.Empty
                Dim strDescripcionArticuloId As String = String.Empty
                Dim strCostoReposicion As String = String.Empty
                Dim strErrorBuscarArticulo As String = String.Empty

                ' Obtenemos la información del Articulo-Proveedor
                objArrayArticuloProveedor = clsCapturaInsumosMateriaPrima.strBuscarArticuloInsumosMateriaPrima(intCompaniaId, intSucursalId, strArticuloCapturado, intProveedorId, "INSUMOSMATERIAPRIMA", 0, 0, 0, strCadenaConexion)

                If IsArray(objArrayArticuloProveedor) AndAlso (objArrayArticuloProveedor.Length > 0) Then

                    objRegistroArticuloProveedor = DirectCast(objArrayArticuloProveedor.GetValue(0), System.Collections.SortedList)

                    strArticuloId = CStr(objRegistroArticuloProveedor.Item("intArticuloId"))
                    strDescripcionArticuloId = clsCommons.strFormatearDescripcion(CStr(objRegistroArticuloProveedor.Item("strArticuloDescripcion")))
                    strCostoReposicion = CStr(objRegistroArticuloProveedor.Item("fltArticuloSucursalCostoReposicion"))

                    strErrorBuscarArticulo = "0"
                Else
                    strErrorBuscarArticulo = "-100"
                End If


                strHTML.Append("<script language='Javascript'> parent.fnUpdArticuloPorIframe( " & _
                                strComitasDobles & strArticuloId & strComitasDobles & "," & _
                                strComitasDobles & strDescripcionArticuloId & strComitasDobles & "," & _
                                strComitasDobles & strCostoReposicion & strComitasDobles & "," & _
                                strComitasDobles & strErrorBuscarArticulo & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "AgregarArticulo"

                Try

                    strHTML = New StringBuilder

                    Dim intAccionArticulo As Integer = 1 'Agregar

                    Dim intArticuloFacturaInsumosCantidad As Integer = 0
                    Dim fltArticuloFacturaInsumosCostoCapturado As Double = 0
                    Dim intAgregaArticulo As Integer = 0
                    Dim strErrorAgregarArticulo As String = String.Empty

                    'Revisamos el articulo a agregar
                    If IsNumeric(strArticuloCapturado) AndAlso CInt(strArticuloCapturado) > 0 Then

                        intArticuloFacturaInsumosCantidad = CInt(Request.Form("txtCantidad"))
                        fltArticuloFacturaInsumosCostoCapturado = CDbl(Request.Form("txtCostoUnitario"))

                        intAgregaArticulo = clsCapturaInsumosMateriaPrima.intAgregarArticulo(intFacturaId, CInt(strArticuloCapturado), intArticuloFacturaInsumosCantidad, CDec(fltArticuloFacturaInsumosCostoCapturado), strUsuarioNombre, strCadenaConexion)

                    End If

                    If intAgregaArticulo > 0 Then
                        strErrorAgregarArticulo = "0"

                    Else
                        strErrorAgregarArticulo = "-100"
                    End If

                    strHTML.Append("<script language='Javascript'> parent.fnUpAgregarEliminarArticulo( " & _
                                     strComitasDobles & intAccionArticulo.ToString & strComitasDobles & "," & _
                                     strComitasDobles & strRecordBrowserHTML.ToString & strComitasDobles & "," & _
                                     strComitasDobles & strErrorAgregarArticulo & strComitasDobles & _
                                   "); </script>")

                    Response.Write(strHTML.ToString)
                    Response.End()

                Catch ex As Exception

                End Try

            Case "EliminarArticulo"

                strHTML = New StringBuilder

                Dim intAccionArticulo As Integer = 2 'Eliminar
                Dim intEliminarArticulo As Integer = 0
                Dim strErrorEliminarArticulo As String = String.Empty

                intEliminarArticulo = clsCapturaInsumosMateriaPrima.intEliminarArticulo(intFacturaId, intArticuloEliminarId, strCadenaConexion)

                If intEliminarArticulo > 0 Then
                    strErrorEliminarArticulo = "0"

                Else
                    strErrorEliminarArticulo = "-100"
                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpAgregarEliminarArticulo( " & _
                                 strComitasDobles & intAccionArticulo.ToString & strComitasDobles & "," & _
                                 strComitasDobles & strRecordBrowserHTML.ToString & strComitasDobles & "," & _
                                 strComitasDobles & strErrorEliminarArticulo & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "RegistrarCompra"

                strHTML = New StringBuilder

                Dim intFolioFactura As Integer = 0
                Dim strErrorRegistrarFactura As String = String.Empty
                Dim intIVADetalle As Integer

                intIVADetalle = clsCapturaInsumosMateriaPrima.intValidaIVADetalle(intCompaniaId, intSucursalId, intFacturaId, intImpuestoFactura, strCadenaConexion)

                If intIVADetalle > 0 Then

                    intFolioFactura = clsCapturaInsumosMateriaPrima.intAfectar(intCompaniaId, intSucursalId, intFacturaId, intProveedorId, strUsuarioNombre, strCadenaConexion)

                    If intFolioFactura > 0 Then
                        strErrorRegistrarFactura = "0"
                    Else
                        strErrorRegistrarFactura = intFolioFactura.ToString
                    End If

                Else
                    'intFolioFactura = 0
                    strErrorRegistrarFactura = intIVADetalle.ToString
                End If


                strHTML.Append("<script language='Javascript'> parent.fnUpRegistrarFacturaInsumos( " & _
                                 strComitasDobles & intFolioFactura.ToString & strComitasDobles & "," & _
                                 strComitasDobles & strErrorRegistrarFactura & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

        End Select
    End Sub
End Class
