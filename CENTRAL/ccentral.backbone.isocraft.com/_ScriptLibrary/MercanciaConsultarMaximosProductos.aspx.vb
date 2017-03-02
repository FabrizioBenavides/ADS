Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class clsMercanciaConsultarMaximosProductos
    Inherits System.Web.UI.Page
    Private intmFolio As Integer
    Private strmFechaDevolucion As String
    Private strmNombreProveedor As String
    Private strmMotivoDevolucion As String
    Private intmProveedor As Integer

    Private strmArticuloNombreId As String = ""
    Private strmArticulo As String = ""
    Private strmMensaje As String = ""
    Private strmRecordBrowserHTML As String = ""


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

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
            ' Return "/Default.aspx?strURL=" & Server.UrlEncode(Request.ServerVariables("SCRIPT_NAME"))
            If intCompaniaId > 0 Then
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
    ' Name       : intDevolucionId
    ' Description: Valor de la transferencia.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDevolucionId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intDevolucionId")) Then
                Return CInt(Request.QueryString("intDevolucionId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intFolio
    ' Description: Valor del folio.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intFolio() As Integer
        Get
            Return intmFolio
        End Get
        Set(ByVal strValue As Integer)
            intmFolio = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaDevolucion
    ' Description: Valor de la orden.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strFechaDevolucion() As String
        Get
            Return strmFechaDevolucion
        End Get
        Set(ByVal strValue As String)
            strmFechaDevolucion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intProveedor
    ' Description: Valor de la orden.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intProveedor() As Integer
        Get
            Return intmProveedor
        End Get
        Set(ByVal strValue As Integer)
            intmProveedor = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaOrden
    ' Description: Valor de la orden.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strNombreProveedor() As String
        Get
            Return strmNombreProveedor
        End Get
        Set(ByVal strValue As String)
            strmNombreProveedor = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strMotivoDevolucion
    ' Description: Valor de la orden.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strMotivoDevolucion() As String
        Get
            Return strmMotivoDevolucion
        End Get
        Set(ByVal strValue As String)
            strmMotivoDevolucion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: URL de esta página
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Len(Request.QueryString("strCmd")) > 0 Then
                Return Request.QueryString("strCmd")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strArticulo
    ' Description: Numero del artículo Consultado
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
    ' Name       : strBuscarArticuloId
    ' Description: Numero de artículo a consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strBuscarArticuloId() As String
        Get
            If Not (Request.Form("txtArticuloId") = "") Then
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
                    strArticuloInternoId = strArticulos(0)
                    strArticuloNombreId = strArticulos(5)
                    Return "1"
                Else
                    Return "0"
                End If
            End If
        Else
            Return "0"
        End If

    End Function

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: RecordBrowser
    ' Accessor   : Read,Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRecordBrowserHTML() As String
        Get
            Return strmRecordBrowserHTML
        End Get
        Set(ByVal strValue As String)
            strmRecordBrowserHTML = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strGeneraBotonesHTML
    ' Description: Genera Botones
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGeneraBotonesHTML() As String
        Dim strBotonesHTML As StringBuilder

        If strRecordBrowserHTML.Length > 0 Then
            strBotonesHTML = New StringBuilder

            ' Botones 
            strBotonesHTML.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0'>")
            strBotonesHTML.Append("<tr><td width='62%'><input name='cmdRegresar' type='button' class='boton' id='cmdRegresar' value='Regresar' onClick='return cmdRegresar_onClick()'>")
            strBotonesHTML.Append("&nbsp;&nbsp;&nbsp;")
            strBotonesHTML.Append("<input name='cmdLimpiar' type='button' class='boton' id='cmdLimpiar' value='Limpiar' onClick='return cmdLimpiar_onClick()'>")
            strBotonesHTML.Append("&nbsp;&nbsp;&nbsp;")
            strBotonesHTML.Append("<input name='cmdImprimir' type='button' class='boton' id='cmdImprimir' value='Imprimir' onClick='return cmdImprimir_onClick()'>")
            strBotonesHTML.Append("&nbsp;&nbsp;&nbsp;&nbsp;</td>")
            strBotonesHTML.Append("<td width='38%' align='right'><input name='cmdSugerir' type='button' class='boton' id='cmdSugerir' value='Sugerir m&aacute;ximo' onClick='return cmdSugerir_onClick()'></td>")
            strBotonesHTML.Append("</tr></table>")

            Return strBotonesHTML.ToString
        End If
        Return ""
    End Function
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

        Dim objDataArray As Array = Nothing
        Dim objRegistro As String() = Nothing
        Dim strHTML As StringBuilder
        Dim intArticuloId As Integer
        Dim intArticuloSucursalExistenciaIdeal As Integer
        Dim intArticuloSucursalExistenciaTeorica As Integer
        Dim fltArticuloSucursalVentaTrimestralRegistrada As Double
        Dim fltArticuloSucursalVentaMensualRegistrada As Double
        Dim fltArticuloSucursalVentaSemanalRegistrada As Double
        Dim intArticuloSucursalDiasInventario As Double

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strRedirectPage)
        End If

        Select Case strCmd
            Case "Consultar"

                If IsNumeric(Request.Form("txtArticuloId")) Then
                    intArticuloId = CInt(Request.Form("txtArticuloId"))
                Else
                    intArticuloId = 0
                End If


                strHTML = New StringBuilder

                ' Traemos los datos del articulo
                objDataArray = clsConcentrador.clsSucursal.strBuscarMaximosArticulo(intCompaniaId, intSucursalId, intArticuloId, strCadenaConexion)

                ' Validamos que sea un artículo válido
                If IsArray(objDataArray) Then
                    If objDataArray.Length > 0 Then

                        objRegistro = DirectCast(objDataArray.GetValue(0), String())

                        intArticuloSucursalExistenciaIdeal = CInt(objRegistro.GetValue(0))
                        intArticuloSucursalExistenciaTeorica = CInt(objRegistro.GetValue(1))
                        fltArticuloSucursalVentaTrimestralRegistrada = CInt(objRegistro.GetValue(2))
                        fltArticuloSucursalVentaMensualRegistrada = CInt(objRegistro.GetValue(3))
                        fltArticuloSucursalVentaSemanalRegistrada = CInt(objRegistro.GetValue(4))
                        intArticuloSucursalDiasInventario = CDbl(objRegistro.GetValue(5))

                        strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'><tr>")
                        strHTML.Append("<td width='44%'><table width='100%' border='0' cellpadding='0' cellspacing='0'>")
                        strHTML.Append("<tr class='trtitulos'>")
                        strHTML.Append("<th width='109' class='rayita'>Inventario</th>")
                        strHTML.Append("<th width='110' class='rayita'>&nbsp;</th>")
                        strHTML.Append("</tr><tr>")
                        strHTML.Append("<td class='tdceleste'><span class='txtitintabla'>Stock Maximo</span></td>")
                        strHTML.Append("<td class='tdceleste'>" & intArticuloSucursalExistenciaIdeal.ToString & "</td></tr><tr>")
                        strHTML.Append("<td class='tdblanco'><span class='txtitintabla'>Stock te&oacute;rico</span></td>")
                        strHTML.Append("<td class='tdblanco'>" & intArticuloSucursalExistenciaTeorica.ToString & "</td></tr><tr>")
                        strHTML.Append("<td class='tdceleste'><span class='txtitintabla'>Dias de Inventario</span></td>")
                        strHTML.Append("<td class='tdceleste'>" & intArticuloSucursalDiasInventario.ToString & "</td>")
                        strHTML.Append("</tr></table></td>")
                        strHTML.Append("<td width='3%'>&nbsp;</td>")
                        strHTML.Append("<td width='53%'><table width='100%' border='0' cellpadding='0' cellspacing='0'>")
                        strHTML.Append("<tr class='trtitulos'>")
                        strHTML.Append("<th width='154' class='rayita'>Ventas</th>")
                        strHTML.Append("<th width='74' class='rayita'>&nbsp;</th>")
                        strHTML.Append("</tr>")
                        strHTML.Append("<tr>")
                        strHTML.Append("<td class='tdceleste'><span class='txtitintabla'>&Uacute;ltimos 3 meses</span></td>")
                        strHTML.Append("<td class='tdceleste'>" & clsCommons.strFormatearDescripcion(fltArticuloSucursalVentaTrimestralRegistrada.ToString) & "</td>")
                        strHTML.Append("</tr><tr>")
                        strHTML.Append("<td class='tdblanco'><span class='txtitintabla'>&Uacute;ltimo mes </span></td>")
                        strHTML.Append("<td class='tdblanco'>" & clsCommons.strFormatearDescripcion(fltArticuloSucursalVentaMensualRegistrada.ToString) & "</td></tr><tr>")
                        strHTML.Append("<td class='tdceleste'><span class='txtitintabla'>&Uacute;ltima semana </span></td>")
                        strHTML.Append("<td class='tdceleste'>" & clsCommons.strFormatearDescripcion(fltArticuloSucursalVentaSemanalRegistrada.ToString) & "</td>")
                        strHTML.Append("</tr></table></td></tr></table><br>")

                    End If
                End If


                ' Le asignamos el valor a la propiedad del RecordBrowser
                strRecordBrowserHTML = strHTML.ToString

            Case "Ver"
                Dim strBuscaHTML As StringBuilder
                Dim strResultado As String

                strBuscaHTML = New StringBuilder

                strResultado = strArticuloDescripcion(strBuscarArticuloId)


                If strResultado = "1" Then
                    strBuscaHTML.Append("<script language='javascript'>")
                    strBuscaHTML.Append("parent.document.forms[0].elements['txtArticuloId'].value='" & strArticuloInternoId.ToString & "';")
                    strBuscaHTML.Append("parent.document.forms[0].elements['txtArticuloDescripcion'].value='" & strArticuloNombreId.ToString & "';")
                    strBuscaHTML.Append("parent.document.forms[0].elements['hdnArticuloId'].value='" & strArticuloInternoId.ToString & "';")
                    strBuscaHTML.Append("parent.document.forms[0].elements['cmdConsultar'].focus();")
                    strBuscaHTML.Append("</script>")
                Else
                    strBuscaHTML.Append("<script language='javascript'>")
                    strBuscaHTML.Append("parent.document.forms[0].elements['txtArticuloId'].value='';")
                    strBuscaHTML.Append("parent.document.forms[0].elements['txtArticuloDescripcion'].value='';")
                    strBuscaHTML.Append("parent.document.forms[0].elements['hdnArticuloId'].value='';")
                    strBuscaHTML.Append("alert('No existe el artículo');")
                    strBuscaHTML.Append("</script>")
                End If

                Call Response.Write(strBuscaHTML.ToString)
                Call Response.End()

        End Select

    End Sub

End Class
