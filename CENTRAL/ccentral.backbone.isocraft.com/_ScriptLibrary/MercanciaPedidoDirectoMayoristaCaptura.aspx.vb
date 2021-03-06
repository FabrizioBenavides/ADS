Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Business.clsConcentrador.clsSucursal.clsMercancia
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class clsMercanciaPedidoDirectoMayoristaCaptura
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

    Private strmParametros As String = ""

    Private strmRazonSocialProveedor As String = ""

    Private strmFechaRecepcion As String = ""

    Private intmCantidadArticulos As Integer

    Private intmArticuloStock As Integer

#End Region


    '====================================================================
    ' Name       : strRedirectPage
    ' Description: P�gina hacia la cual se debe redireccionar al usuario
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
    ' Description: Valor de la acci�n de la forma HTML
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
    ' Description: URL de esta p�gina
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
    ' Description: Valor de la Compa�ia
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
    ' Name       : intSucursalCTFId
    ' Description: Valor de la Sucursal CTF
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intSucursalCTFId() As Integer
        Get
            Dim objSucursalCTF As Array = Nothing
            Dim objRegistroSucursalCTF As System.Collections.SortedList = Nothing
            Dim strLocalCTF As String = ""

            objSucursalCTF = clsConcentrador.clsSucursal.strBuscarCTFId(intCompaniaId, intSucursalId, strCadenaConexion)

            If IsArray(objSucursalCTF) AndAlso objSucursalCTF.Length > 0 Then

                objRegistroSucursalCTF = DirectCast(objSucursalCTF.GetValue(0), System.Collections.SortedList)

                strLocalCTF = CStr(objRegistroSucursalCTF.Item("strLocalCTF"))

                If Len(strLocalCTF) = 4 Then
                    Return CInt(strLocalCTF)
                Else
                    Return 0
                End If

            Else
                Return 0
            End If

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
    ' Name       : strCadenaConexionCTF
    ' Description: Valor que tomara la variable strmCadenaConexion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCadenaConexionCTF() As String
        Get
            Return ConfigurationSettings.AppSettings("strConexionCTF")
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
    ' Name       : strtxtFechaRegistroMDY
    ' Description: valor del control 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strtxtFechaRegistroMDY() As String
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("txtFechaRegistro"))

            If strTemporal.Equals("") Then
                Return ""
            Else
                Return clsCommons.strDMYtoMDY(strTemporal)
            End If

        End Get
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
    ' Name       : strArticuloStock
    ' Description:  
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strArticuloStock() As String
        Get
            If Len(Request("strArticuloStock")) > 0 Then
                Return Request("strArticuloStock")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intArticuloStock
    ' Description:  
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intArticuloStock() As Integer
        Get
            Return intmArticuloStock
        End Get
        Set(ByVal intValue As Integer)
            intmArticuloStock = intValue
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

        Dim objPedidoCompraDirecta As Array = Nothing
        Dim objRegistroPedidoCompraDirecta As System.Collections.SortedList = Nothing

        Dim strHTML As StringBuilder
        Dim intConsecutivo As Integer = 0
        Dim strColorRegistro As String = ""
        Dim intCantidad As Integer = 0


        strHTML = New StringBuilder

        strHTML.Append("")

        objPedidoCompraDirecta = clsCompras.clsPedido.strBuscarDetalle(intCompaniaId, intSucursalId, intCapturaId, strCadenaConexion)

        If IsArray(objPedidoCompraDirecta) AndAlso objPedidoCompraDirecta.Length > 0 Then

            strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strHTML.Append("<tr class='trtitulos'>")
            strHTML.Append("<th width='04%' class='rayita' align='left'>No.</th>")
            strHTML.Append("<th width='26%' class='rayita' align='left'>Motivo</th>")
            strHTML.Append("<th width='05%' class='rayita' align='left'>Caja</th>")
            strHTML.Append("<th width='05%' class='rayita' align='left'>Ticket</th>")
            strHTML.Append("<th width='10%' class='rayita' align='left'>C&oacute;digo</th>")
            strHTML.Append("<th width='40%' class='rayita' align='left'>Descripci&oacute;n</th>")
            strHTML.Append("<th width='05%' class='rayita' align='left'>Cantidad</th>")
            strHTML.Append("<th width='06%' class='rayita' align='center'>Acci&oacute;n</th>")
            strHTML.Append("</tr>")

            For Each objRegistroPedidoCompraDirecta In objPedidoCompraDirecta

                intConsecutivo += 1

                If (intConsecutivo Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If

                intCantidad += CInt(objRegistroPedidoCompraDirecta.Item("intArticuloPedidoCompraDirectaCantidad"))

                strHTML.Append("<tr>")
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & intConsecutivo.ToString & "</td>") ' No
                strHTML.Append("<td class=" & strColorRegistro & " align='left'>" & CStr(objRegistroPedidoCompraDirecta.Item("intMotivoPedidoCompraDirectaId")) & " - " & clsCommons.strFormatearDescripcion(CStr(objRegistroPedidoCompraDirecta.Item("strMotivoPedidoCompraDirectaNombre"))) & "</td>") ' Motivo 
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & CStr(objRegistroPedidoCompraDirecta.Item("intCajaId")) & "</td>") ' Caja
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & CStr(objRegistroPedidoCompraDirecta.Item("intTicketId")) & "</td>") ' Ticket
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & CStr(objRegistroPedidoCompraDirecta.Item("intArticuloId")) & "</td>") ' Articulo
                strHTML.Append("<td class=" & strColorRegistro & " align='left'> " & clsCommons.strFormatearDescripcion(CStr(objRegistroPedidoCompraDirecta.Item("strArticuloDescripcion"))) & "</td>") ' Descripci�n
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & CStr(objRegistroPedidoCompraDirecta.Item("intArticuloPedidoCompraDirectaCantidad")) & "</td>") ' Cantidad
                strHTML.Append("<td class=" & strColorRegistro & " align='center'>" & "<a href='javascript:cmdEliminar_onclick(" & CStr(objRegistroPedidoCompraDirecta.Item("intMotivoPedidoCompraDirectaId")) & "," & CStr(objRegistroPedidoCompraDirecta.Item("intCajaId")) & "," & CStr(objRegistroPedidoCompraDirecta.Item("intTicketId")) & "," & CStr(objRegistroPedidoCompraDirecta.Item("intArticuloId")) & ");'><img src='../static/images/icono_borrar.gif' alt='Eliminar art�culo' width='11' height='13' border='0' align='absmiddle'></a>&nbsp;&nbsp;</td>") ' accion
                strHTML.Append("</tr>")

            Next

            intCantidadArticulos = intCantidad

            strHTML.Append("</table>")

        End If

        strHTML.Append("<input type='hidden' name='txtArticulosLista' value = '" & intCantidadArticulos.ToString & "'>")

        Return strHTML.ToString


    End Function

    Public Function strRecordBrowserProveedorAutorizadoHTML() As String

        Dim objProveedorAutorizadoCompraDirecta As Array = Nothing
        Dim objRegistroProveedorAutorizadoCompraDirecta As System.Collections.SortedList = Nothing

        Dim strHTML As StringBuilder
        Dim intConsecutivo As Integer = 0
        Dim strColorRegistro As String = ""
        Dim intCantidad As Integer = 0


        strHTML = New StringBuilder

        strHTML.Append("")

        objProveedorAutorizadoCompraDirecta = clsCompras.clsPedido.strBuscarStockArticulo(intCompaniaId, intSucursalId, intArticuloStock, strCadenaConexion)

        If IsArray(objProveedorAutorizadoCompraDirecta) AndAlso objProveedorAutorizadoCompraDirecta.Length > 0 Then

            strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strHTML.Append("<tr class='trtitulos'>")
            strHTML.Append("<th width='20%' class='tdtittablas3' align='left'>Proveedor</th>")
            strHTML.Append("<th width='65%' class='tdtittablas3' align='left'>Razon Social</th>")
            strHTML.Append("<th width='15%' class='tdtittablas3' align='left'>Stock</th>")
            strHTML.Append("</tr>")

            For Each objRegistroProveedorAutorizadoCompraDirecta In objProveedorAutorizadoCompraDirecta

                intConsecutivo += 1

                If (intConsecutivo Mod 2) <> 0 Then
                    strColorRegistro = "'txcontazul'"
                Else
                    strColorRegistro = "'txcontazul'"
                End If

                intCantidad += CInt(objRegistroProveedorAutorizadoCompraDirecta.Item("intArticuloProveedorAutorizadoCompraDirectaCantidad"))

                strHTML.Append("<tr>")
                strHTML.Append("<td class=" & strColorRegistro & " align='left'>" & CStr(objRegistroProveedorAutorizadoCompraDirecta.Item("strProveedorId")) & "</td>") ' strProveedorId
                strHTML.Append("<td class=" & strColorRegistro & " align='left'>" & CStr(objRegistroProveedorAutorizadoCompraDirecta.Item("strProveedorRazonSocial")) & "</td>") ' strProveedorRazonSocial
                strHTML.Append("<td class=" & strColorRegistro & " align='right'>" & CStr(objRegistroProveedorAutorizadoCompraDirecta.Item("strStockCantidad")) & "</td>") ' strStockCantidad
                strHTML.Append("</tr>")

            Next

            intCantidadArticulos = intCantidad

            strHTML.Append("</table>")

        End If

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
    ' Name       : intMotivoPedidoCompraDirectaEliminarId
    ' Description:  
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intMotivoPedidoCompraDirectaEliminarId() As Integer
        Get
            If Not IsNothing(Request("intMotivoPedidoCompraDirectaEliminarId")) Then
                Return CInt(Request("intMotivoPedidoCompraDirectaEliminarId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intCajaEliminarId
    ' Description:  
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCajaEliminarId() As Integer
        Get
            If Not IsNothing(Request("intCajaEliminarId")) Then
                Return CInt(Request("intCajaEliminarId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intTicketEliminarId
    ' Description:  
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intTicketEliminarId() As Integer
        Get
            If Not IsNothing(Request("intTicketEliminarId")) Then
                Return CInt(Request("intTicketEliminarId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intArticuloEliminarId
    ' Description: N�mero de articulo a Eliminar
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
    ' Name       : strLlenarMotivoPedidoCompraDirecta
    ' Description: Regresa una cadena de texto con el c�digo Javascript
    '              que llena al combo box cboMotivoPedidoCompraDirecta
    ' Parameters : None
    ' Throws     : None
    ' Output     : String

    '====================================================================
    Public Function strLlenarMotivoPedidoCompraDirectaComboBox() As String

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboMotivoPedidoCompraDirecta", CInt(Request("cboMotivoPedidoCompraDirecta")), clsCompras.clsPedido.strBuscarMotivo(strCadenaConexion), 0, 1, 1)

    End Function

    '====================================================================
    ' Name       : cboMotivoPedidoCompraDirecta
    ' Description: valor del control 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property cboMotivoPedidoCompraDirecta() As Integer
        Get

            Dim strTemporal As String

            strTemporal = Trim(Request("cboMotivoPedidoCompraDirecta"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

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
    ' Name       : blnValidaCTF
    ' Description:
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property blnValidaCTF() As Integer
        Get
            If Not IsNothing(Request("hdnValidaCTF")) Then
                Return CInt(Request("hdnValidaCTF"))
            Else
                Return 0
            End If
        End Get
    End Property


    '====================================================================
    ' Name       : blnValidaMotivo
    ' Description:
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property blnValidaMotivo() As Integer
        Get
            If Not IsNothing(Request("hdnValidaMotivo")) Then
                Return CInt(Request("hdnValidaMotivo"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intCajaId
    ' Description:
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCajaId() As Integer
        Get
            If Not IsNothing(Request("txtCajaId")) Then
                Return CInt(Request("txtCajaId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intTicketId
    ' Description:
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intTicketId() As Integer
        Get
            If Not IsNothing(Request("txtTicketId")) Then
                Return CInt(Request("txtTicketId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : Page_Load
    ' Description: Evento "Load" de la p�gina
    ' Parameters :
    '              ByVal objSender As System.Object
    '                 - Objeto que genera el Evento
    '              ByVal objEvent As System.EventArgs
    '                 - Argumentos del Evento
    ' Throws     : Ninguna
    ' Output     : Ninguna
    '====================================================================
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Control de Acceso de la p�gina
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

                    objArrayProveedor = clsCompras.clsPedido.strBuscarProveedor(intCompaniaId, intSucursalId, strProveedorNombreId, 0, 0, strCadenaConexion)

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

            Case "BuscarArticulo"
                strHTML = New StringBuilder

                Dim objArrayArticulo As Array = Nothing
                Dim objRegistroArticulo As System.Collections.SortedList = Nothing

                Dim strArticuloId As String = ""
                Dim strDescripcionArticuloId As String = ""

                Dim strClaveVigenciaArticuloId As String = ""
                Dim strClaveVigenciaArticuloNombre As String = ""

                Dim strEstacionalidadArticuloId As String = ""
                Dim strEstacionalidadArticuloDescripcion As String = ""

                Dim strTipoAbastoArticuloId As String = ""
                Dim strTipoAbastoArticuloDescripcion As String = ""

                Dim strProveedoresAutorizadosNo As String = ""
                Dim strProveedoresAutorizadosDescripcion As String = ""

                Dim strArticuloAutorizado As String = ""

                Dim strErrorBuscarArticulo As String = ""

                ' Obtenemos la informaci�n del Articulo 

                objArrayArticulo = clsCompras.clsPedido.strBuscarArticulo(intCompaniaId, intSucursalId, strArticuloCapturado, intProveedorId, 0, 0, strCadenaConexion)

                If IsArray(objArrayArticulo) AndAlso (objArrayArticulo.Length > 0) Then

                    objRegistroArticulo = DirectCast(objArrayArticulo.GetValue(0), System.Collections.SortedList)

                    strArticuloId = CStr(objRegistroArticulo.Item("intArticuloId"))
                    intArticuloStock = CInt(strArticuloId)
                    strDescripcionArticuloId = clsCommons.strFormatearDescripcion(CStr(objRegistroArticulo.Item("strArticuloDescripcion")))

                    strClaveVigenciaArticuloId = CStr(objRegistroArticulo.Item("intClaveVigenciaArticuloId"))
                    strClaveVigenciaArticuloNombre = clsCommons.strFormatearDescripcion(CStr(objRegistroArticulo.Item("strClaveVigenciaArticuloNombre")))

                    strEstacionalidadArticuloId = CStr(objRegistroArticulo.Item("intEstacionalidadArticuloId"))
                    strEstacionalidadArticuloDescripcion = clsCommons.strFormatearDescripcion(CStr(objRegistroArticulo.Item("strEstacionalidadArticuloDescripcion")))

                    strTipoAbastoArticuloId = CStr(objRegistroArticulo.Item("intTipoAbastoArticuloId"))
                    strTipoAbastoArticuloDescripcion = clsCommons.strFormatearDescripcion(CStr(objRegistroArticulo.Item("strTipoAbastoArticuloDescripcion")))

                    strProveedoresAutorizadosNo = CStr(objRegistroArticulo.Item("intProveedoresAutorizadosNo"))
                    strProveedoresAutorizadosDescripcion = clsCommons.strFormatearDescripcion(CStr(objRegistroArticulo.Item("strProveedoresAutorizadosDescripcion")))

                    strArticuloAutorizado = CStr(objRegistroArticulo.Item("blnArticuloAutorizado"))

                    strErrorBuscarArticulo = "0"

                Else
                    strErrorBuscarArticulo = "-100"
                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpdArticuloPorIframe( " & _
                                strComitasDobles & strArticuloId & strComitasDobles & "," & _
                                strComitasDobles & strDescripcionArticuloId & strComitasDobles & "," & _
                                strComitasDobles & strClaveVigenciaArticuloId & strComitasDobles & "," & _
                                strComitasDobles & strClaveVigenciaArticuloNombre & strComitasDobles & "," & _
                                strComitasDobles & strEstacionalidadArticuloId & strComitasDobles & "," & _
                                strComitasDobles & strEstacionalidadArticuloDescripcion & strComitasDobles & "," & _
                                strComitasDobles & strTipoAbastoArticuloId & strComitasDobles & "," & _
                                strComitasDobles & strTipoAbastoArticuloDescripcion & strComitasDobles & "," & _
                                strComitasDobles & strProveedoresAutorizadosNo & strComitasDobles & "," & _
                                strComitasDobles & strRecordBrowserProveedorAutorizadoHTML.ToString & strComitasDobles & "," & _
                                strComitasDobles & strArticuloAutorizado & strComitasDobles & "," & _
                                strComitasDobles & strErrorBuscarArticulo & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "BuscarProveedorAutorizado"

                strHTML = New StringBuilder

                intArticuloStock = CInt(strArticuloStock)

                strHTML.Append("<script language='Javascript'> parent.fnUpdProveedorAutorizadoPorIframe( " & _
                                                strComitasDobles & strRecordBrowserProveedorAutorizadoHTML.ToString & strComitasDobles & _
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

                Dim objArrayArticuloCobrado As Array = Nothing
                Dim objRegistroArticuloCobrado As System.Collections.SortedList = Nothing

                Dim blnArticuloCobrado As Boolean = False
                Dim intArticuloCantidadCobrada As Integer = 0

                'Revisamos el articulo a agregar
                If IsNumeric(strArticuloCapturado) AndAlso CInt(strArticuloCapturado) > 0 Then

                    intArticuloCompraDirectaCantidad = CInt(Request.Form("txtCantidad"))

                    If blnValidaCTF = 1 And blnValidaMotivo = 1 Then

                        ' Validamos que el articulo este registrado en el CTF 

                        objArrayArticuloCobrado = clsCompras.clsPedidoVentaCatalogo.strBuscarArticuloCobrado(intSucursalCTFId, intCajaId, intTicketId, strArticuloCapturado, strCadenaConexionCTF)

                        If IsArray(objArrayArticuloCobrado) AndAlso (objArrayArticuloCobrado.Length > 0) Then

                            objRegistroArticuloCobrado = DirectCast(objArrayArticuloCobrado.GetValue(0), System.Collections.SortedList)

                            blnArticuloCobrado = True
                            intArticuloCantidadCobrada = CInt(objRegistroArticuloCobrado.Item("PRD_CANTIDAD"))

                        Else
                            blnArticuloCobrado = False
                            intArticuloCantidadCobrada = 0

                        End If

                    Else
                        blnArticuloCobrado = True
                        intArticuloCantidadCobrada = intArticuloCompraDirectaCantidad
                    End If

                End If

                If blnArticuloCobrado = False Then
                    strErrorAgregarArticulo = "-200"
                Else

                    If intArticuloCompraDirectaCantidad > intArticuloCantidadCobrada Then
                        strErrorAgregarArticulo = "-210"
                    Else

                        intAgregaArticulo = clsCompras.clsPedido.intAgregarArticulo(intCapturaId, cboMotivoPedidoCompraDirecta, intCajaId, intTicketId, CInt(strArticuloCapturado), intArticuloCompraDirectaCantidad, strUsuarioNombre, strCadenaConexion)

                        If intAgregaArticulo > 0 Then
                            strErrorAgregarArticulo = "0"

                        Else
                            strErrorAgregarArticulo = "-100"
                        End If

                    End If

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

                intEliminarArticulo = clsCompras.clsPedido.intBorrarArticulo(intCapturaId, intMotivoPedidoCompraDirectaEliminarId, intCajaEliminarId, intTicketEliminarId, intArticuloEliminarId, strCadenaConexion)

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

                Dim intPedidoCompraDirectaId As Integer = 0
                Dim strErrorRegistrarPedidoCompra As String = ""

                intPedidoCompraDirectaId = clsCompras.clsPedido.intRegistrar(intCapturaId, intCompaniaId, intSucursalId, intProveedorId, CDate(strtxtFechaRegistroMDY), strUsuarioNombre, strCadenaConexion)

                If intPedidoCompraDirectaId > 0 Then
                    strErrorRegistrarPedidoCompra = "0"
                Else
                    strErrorRegistrarPedidoCompra = intPedidoCompraDirectaId.ToString
                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpRegistrarPedidoCompraDirecta( " & _
                                 strComitasDobles & intPedidoCompraDirectaId.ToString & strComitasDobles & "," & _
                                 strComitasDobles & strErrorRegistrarPedidoCompra & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

        End Select

    End Sub
End Class
