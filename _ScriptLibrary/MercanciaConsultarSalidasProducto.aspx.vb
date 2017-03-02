Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration

'====================================================================
' Page          : MercanciaConsultarSalidasProducto
' Title         : Administracion POS y BackOffice
' Description   : Consulta las salidas de los productos por transferencias.
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Griselda Gómez Ponce
' Version       : 1.0
' Last Modified : Martes, 18 de noviembre, 2003   
'====================================================================

Public Class MercanciaConsultarSalidasProducto
    Inherits System.Web.UI.Page

    'Declaracion de variables

    Private strmMensaje As String = ""
    Private strmintArticuloId As String = ""
    Private strmArticuloDescripcion As String = ""
    Private intmCantidadEnviada As Integer = 0
    Private intmCantidadRecibida As Integer = 0
    Private intmCantidadTotal As Integer = 0
    Private strmRecordBrowserHTML As String = ""
    Private strmbtnConsultar As String


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
    ' Name       : strMensaje
    ' Description: Mensajes enviados al usuario
    ' Accessor   : Read and Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strMensaje() As String
        Get
            Return strmMensaje
        End Get
        Set(ByVal strValue As String)
            strmMensaje = strValue
        End Set
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
    ' Name       : strArticuloId
    ' Description: Numero de artículo consultado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strArticuloId() As String
        Get
            If Request("txtArticuloId") <> "" Then
                Return Request("txtArticuloId")
            Else
                Return ""
            End If
        End Get
    End Property
    '====================================================================
    ' Name       : strBuscarInformacionArticulo
    ' Description: Consulta la descripción del Artículo
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Sub strBuscarInformacionArticulo()
        Dim objArticulos As Array = Nothing
        Dim strArticulos As String() = Nothing

        If strArticuloId.Length > 0 Then
            'Buscamos la descripcion del articulo
            objArticulos = clsConcentrador.clsSucursal.strBuscarArticulo(intCompaniaId, intSucursalId, strArticuloId, 100, 100, strCadenaConexion)

            If IsArray(objArticulos) AndAlso (objArticulos.Length > 0) Then
                ' Obtenemos el código y la descripcion del articulo
                strArticulos = DirectCast(objArticulos.GetValue(0), String())
                intArticuloId = strArticulos(0).ToString
                strArticuloDescripcion = strArticulos(5)
            Else
                intArticuloId = ""
                strArticuloDescripcion = ""
                strMensaje = "Articulo no valido"
            End If
        Else
            intArticuloId = ""
            strArticuloDescripcion = ""
            strMensaje = "Articulo no valido"
        End If

    End Sub

    '====================================================================
    ' Name       : intArticuloId
    ' Description: Numero de artículo a consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intArticuloId() As String
        Get
            Return strmintArticuloId
        End Get
        Set(ByVal strValue As String)
            strmintArticuloId = strValue
        End Set
    End Property


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
    ' Name       : rdoMesConsulta
    ' Description: Criterio de Consulta : Actual | Anteior
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property rdoMesConsulta() As String
        Get
            Return Request.Form("rdoMesConsulta")
        End Get
    End Property

    '====================================================================
    ' Name       : intCantidadEnviada
    ' Description: Numero de artículo a consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intCantidadEnviada() As Integer
        Get
            Return intmCantidadEnviada
        End Get
        Set(ByVal intValue As Integer)
            intmCantidadEnviada = intValue
        End Set
    End Property
    '====================================================================
    ' Name       : intCantidadRecibida
    ' Description: Numero de artículo a consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intCantidadRecibida() As Integer
        Get
            Return intmCantidadRecibida
        End Get
        Set(ByVal intValue As Integer)
            intmCantidadRecibida = intValue
        End Set
    End Property
    '====================================================================
    ' Name       : intCantidadTotal
    ' Description: Numero de artículo a consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intCantidadTotal() As Integer
        Get
            Return intmCantidadTotal
        End Get
        Set(ByVal intValue As Integer)
            intmCantidadTotal = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Almacena el HTML generado para desplegar el record browser
    ' Parameters : strValue.- String con el HTML Generado
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
    ' Name       : strbtnConsultar
    ' Description: Boton de consultar
    ' Parameters : strValue.- String con el HTML Generado
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strbtnConsultar() As String
        Get
            Return strmbtnConsultar
        End Get
        Set(ByVal strValue As String)
            strmbtnConsultar = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowserTransferenciasHTML
    ' Description: Genera el Record Browser con los articulo trasnferidos a otra sucursal.
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserTransferenciasHTML() As String

        ' Declaracion de Variables
        Dim intMes As Integer
        Dim strNombreMes As String
        Dim objConsolidado As Array
        Dim strRegistroConsolidado As String()
        Dim objTransferencias As Array
        Dim strRegistroTransferencia As String()
        Dim strTipoEstadoTransferenciaNombreId As String
        Dim strTransferenciasHTML As StringBuilder
        Dim strTargetURL As String

        strTransferenciasHTML = New StringBuilder

        'Inicializacion de variables
        objConsolidado = Nothing
        objTransferencias = Nothing
        strTipoEstadoTransferenciaNombreId = "ENVIADA"
        '   strTransferenciasHTML = Nothing
        strTargetURL = ""


        'Obtenemos el mes de consulta
        Select Case Request.Form("rdoMesConsulta")
            Case "1"
                intMes = Now.Month
                strNombreMes = clsCommons.strNombreMes(Now)
            Case "2"
                intMes = DateAdd(DateInterval.Month, -1, Now).Month
                strNombreMes = clsCommons.strNombreMes(DateAdd(DateInterval.Month, -1, Now))
        End Select

        'Consultamos totales de transferencias a otra sucursal
        objConsolidado = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.strBuscarConsolidado(intCompaniaId, intSucursalId, intMes, CInt(intArticuloId), strCadenaConexion)

        If IsArray(objConsolidado) AndAlso objConsolidado.Length > 0 Then
            strRegistroConsolidado = DirectCast(objConsolidado.GetValue(0), String())

            'Salidas
            intCantidadEnviada = CInt(strRegistroConsolidado(0).ToString)
            'Entradas
            intCantidadRecibida = CInt(strRegistroConsolidado(1).ToString)
            'Total
            intCantidadTotal = intCantidadRecibida - intCantidadEnviada

        End If

        'Buscamos las trasnferencias del Articulo en el mes indicado

        objTransferencias = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.strBuscarArticulo(intCompaniaId, intSucursalId, intMes, CInt(intArticuloId), strTipoEstadoTransferenciaNombreId, 0, 0, strCadenaConexion)
        If IsArray(objTransferencias) AndAlso objTransferencias.Length > 0 Then
            'Pintamos el record browser

            Call strTransferenciasHTML.Append("<tr>")
            Call strTransferenciasHTML.Append("<td colSpan='3'><div id='HtmContenido1'><span class='txsubtitulo'>Movimientos del producto <span class='txsubtituloresalta'> " + intArticuloId + " </span> en el mes de <span class='txsubtituloresalta'>" + strNombreMes + "</span></span></div>")
            Call strTransferenciasHTML.Append("</td></tr>")
            Call strTransferenciasHTML.Append("<tr>")
            Call strTransferenciasHTML.Append("<td class='tdenvolventeazul' vAlign='top' width='22%' bgColor='#f4f6f8' rowSpan='2'><div id='HtmContenido2'>")
            Call strTransferenciasHTML.Append("<table cellSpacing='0' cellPadding='0' width='100%' border='0'>")
            Call strTransferenciasHTML.Append("<tr>")
            Call strTransferenciasHTML.Append("<td class='tdtittablas2'>Resumen</td></tr>")
            Call strTransferenciasHTML.Append("<tr>")
            Call strTransferenciasHTML.Append("<td class='tdtittablas2' height='30'>Entradas:</td></tr>")
            Call strTransferenciasHTML.Append("<tr>")
            Call strTransferenciasHTML.Append("<td height='30'><input class='campotabla' type='text' size='16' value='" + intCantidadRecibida.ToString + "' name='txtEntradas' readonly></td></tr>")
            Call strTransferenciasHTML.Append("<tr>")
            Call strTransferenciasHTML.Append("<td class='tdtittablas2'>Salidas:</td></tr>")
            Call strTransferenciasHTML.Append("<tr>")
            Call strTransferenciasHTML.Append("<td height='30'><input class='campotabla' type='text' size='16' value='" + intCantidadEnviada.ToString + "' name='txtSalidas' readonly></td></tr>")
            Call strTransferenciasHTML.Append("<tr>")
            Call strTransferenciasHTML.Append("<td class='tdtittablas2'>Total:</td></tr>")
            Call strTransferenciasHTML.Append("<tr>")
            Call strTransferenciasHTML.Append("<td height='30'><input class='campotabla' type='text' size='16' value='" + intCantidadTotal.ToString + "' name='txtTotal' readonly></td></tr>")
            Call strTransferenciasHTML.Append("</table></div></td>")
            Call strTransferenciasHTML.Append("<td width='3%' rowspan='2' valign='top'>&nbsp;</td>")
            Call strTransferenciasHTML.Append("<td valign='top'><div id='HtmContenido3'>")
            Call strTransferenciasHTML.Append(clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("MercanciaConsultarSalidasProducto", objTransferencias, 1, objTransferencias.Length, strTargetURL)))
            Call strTransferenciasHTML.Append("</div>")
            Call strTransferenciasHTML.Append("</td></tr>")
            Call strTransferenciasHTML.Append("<tr>")
            Call strTransferenciasHTML.Append("<td vAlign='top' width='75%'><table cellSpacing='0' cellPadding='0' width='98%' border='0'>")
            Call strTransferenciasHTML.Append("<tr>")
            Call strTransferenciasHTML.Append("<td colSpan='2'>&nbsp;</td></tr>")
            Call strTransferenciasHTML.Append("<tr>")
            Call strTransferenciasHTML.Append("<td width='429' colSpan='2'><input class='boton' type='button' value='Regresar' name='cmdRegresar' onclick='return cmdRegresar_onclick()'>")
            Call strTransferenciasHTML.Append("&nbsp;&nbsp; <input class='boton' type='button' value='Ver entradas' name='cmdVerEntradas' onclick='return cmdVerEntradas_onclick()'>")
            Call strTransferenciasHTML.Append("&nbsp;&nbsp; <input class='boton' type='button' value='Imprimir reporte' name='cmdImprimir' onclick='return cmdImprimir_onclick()' >")
            Call strTransferenciasHTML.Append("</td></tr>")
            Call strTransferenciasHTML.Append("</table>")
            Call strTransferenciasHTML.Append("</td></tr>")

            strRecordBrowserTransferenciasHTML = strTransferenciasHTML.ToString
        Else
            strRecordBrowserTransferenciasHTML = ""

        End If

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        Select Case strCmd
            Case "Consultar"

                'Variables

                'Buscamos información del articulo
                Call strBuscarInformacionArticulo()

                If CInt(intArticuloId) > 0 Then

                    'Pintamos el record Browser

                    strRecordBrowserHTML = strRecordBrowserTransferenciasHTML()

                    If strRecordBrowserHTML.Length = 0 Then
                        strMensaje = "No hay información "
                        strRecordBrowserHTML = ""
                    End If


                End If
            Case "BuscarArticulo"
                'Obtenemos la descripcion del articulo
                Call strBuscarInformacionArticulo()
        End Select

        If strRecordBrowserHTML.Length > 0 Then
            strbtnConsultar = "<input class='boton' type='button' value='Consultar' name='cmdConsultar' onclick='return cmdConsultar_onclick()'>"
        Else
            strbtnConsultar = "<input class='boton' type='button' value='Consultar' name='cmdConsultar' onclick='return cmdConsultar_onclick()'>&nbsp;&nbsp;<input class='boton' type='button' value='Regresar' name='cmdRegresar' onclick='return cmdRegresar_onclick()'>"
        End If

    End Sub

End Class
