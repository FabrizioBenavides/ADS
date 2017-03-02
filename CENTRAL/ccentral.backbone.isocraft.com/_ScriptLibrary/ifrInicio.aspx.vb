Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text
Imports System.Web
Imports System.Collections.Specialized

Public Class clsifrInicio
    Inherits System.Web.UI.Page

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
    ' Name       : strURLSucursal
    ' Description: URL de la Sucursal del usuario actual
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private strmURLSucursal As String
    Public ReadOnly Property strURLSucursal() As String
        Get
            If Len(strmURLSucursal) = 0 Then
                strmURLSucursal = "http://" & Request.QueryString("strServerName") & ":" & Request.QueryString("strServerPort") & "/_ScriptLibrary/POSAdminRedirectorCC.aspx?strPageName="
            End If
            Return strmURLSucursal
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
    Public ReadOnly Property intFolioId() As Integer
        Get
            If Len(Request.QueryString("intFolioId")) > 0 Then
                Return CInt(Request.QueryString("intFolioId"))
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
    Public ReadOnly Property dtmFecha() As String
        Get
            Return Request.QueryString("dtmFecha")
        End Get
    End Property

    '====================================================================
    ' Name       : strRemisionesHTML
    ' Description: Valor que tomara la variable strRemisionesHTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRemisionesHTML() As String
        Get

            Dim strbldRemisiones As StringBuilder
            Dim objRemisiones As Array = Nothing
            Dim strRemisiones As String() = Nothing
            Dim intContador As Integer = 0
            Dim intMod As Integer = 0
            Dim strColortd As String = "tdceleste"

            strbldRemisiones = New StringBuilder

            ' Hacemos la consulta de la información del cliene especial.
            objRemisiones = clsConcentrador.clsSucursal.clsMercancia.clsRemisionElectronica.strBuscarRemisionProveedor(intCompaniaId, intSucursalId, 0, 0, 0, strCadenaConexion)

            strbldRemisiones.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strbldRemisiones.Append("  <tr class='trtitulos'>")
            strbldRemisiones.Append("    <th width='55' class='rayita'>C&oacute;digo</th>")
            strbldRemisiones.Append("    <th width='128' class='rayita'>Proveedor</th>")
            strbldRemisiones.Append("  </tr>")

            ' Validamos si trae información para mostrarla
            If IsArray(objRemisiones) AndAlso objRemisiones.Length > 0 Then
                strRemisiones = DirectCast(objRemisiones.GetValue(0), String())

                ' Barremos el arreglo para ir formando los campos a mostrar en la página HTML
                For intContador = 0 To objRemisiones.Length - 1
                    strRemisiones = Nothing
                    strRemisiones = DirectCast(objRemisiones.GetValue(intContador), String())

                    intMod = intContador Mod 2
                    If intMod = 0 Then
                        strColortd = "tdceleste"
                    Else
                        strColortd = "tdblanco"
                    End If

                    strbldRemisiones.Append("  <tr>")
                    strbldRemisiones.Append("    <td class='" & strColortd & "'><a href='" & strURLSucursal & "MercanciaRemisionPorConfirmar.aspx&strUseRedirector=True&strCmd=VerTodo&intProveedorId=" & strRemisiones(0) & "' class='txaccion' target='_top'>" & strRemisiones(0) & "</a></td>")
                    strbldRemisiones.Append("    <td class='" & strColortd & "'>" & clsCommons.strFormatearDescripcion(strRemisiones(1).ToString) & "</td>")
                    strbldRemisiones.Append("  </tr>")

                Next

            End If

            strbldRemisiones.Append("</table>")

            strRemisionesHTML = strbldRemisiones.ToString

            Return strRemisionesHTML
        End Get
    End Property

    '====================================================================
    ' Name       : strFacturasHTML
    ' Description: Valor que tomara la variable strFacturasHTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFacturasHTML() As String
        Get

            Dim strbldFacturas As StringBuilder
            Dim intContador As Integer = 0
            Dim intMod As Integer = 0
            Dim strColorRegistro As String = "tdceleste"

            Dim objArrayFacturasElectronicas As Array = Nothing
            Dim objRegistroFacturasElectronicas As System.Collections.SortedList = Nothing

            ' Hacemos la consulta de la información del cliene especial.
            objArrayFacturasElectronicas = clsConcentrador.clsSucursal.clsMercancia.clsFacturaElectronica.strBuscarProveedor(intCompaniaId, intSucursalId, 0, 0, 0, strCadenaConexion)

            strbldFacturas = New StringBuilder

            strbldFacturas.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strbldFacturas.Append("  <tr class='trtitulos'>")
            strbldFacturas.Append("    <th width='55' class='rayita'>C&oacute;digo</th>")
            strbldFacturas.Append("    <th width='128' class='rayita'>Proveedor</th>")
            strbldFacturas.Append("  </tr>")

            ' Validamos si trae información para mostrarla
            If IsArray(objArrayFacturasElectronicas) AndAlso objArrayFacturasElectronicas.Length > 0 Then


                ' Barremos el arreglo para ir formando los campos a mostrar en la página HTML
                For Each objRegistroFacturasElectronicas In objArrayFacturasElectronicas

                    intMod = intContador Mod 2
                    If intMod = 0 Then
                        strColorRegistro = "tdceleste"
                    Else
                        strColorRegistro = "tdblanco"
                    End If

                    strbldFacturas.Append("<tr>")
                    strbldFacturas.Append("<td class=" & strColorRegistro & ">")
                    strbldFacturas.Append("<a href='" & strURLSucursal & "MercanciaFacturasPorConfirmar.aspx&strUseRedirector=True&strCmd=VerTodo&intProveedorId=")
                    strbldFacturas.Append(CStr(objRegistroFacturasElectronicas.Item("intProveedorId")))
                    strbldFacturas.Append("' class='txaccion' target='_top'>")
                    strbldFacturas.Append(CStr(objRegistroFacturasElectronicas.Item("strProveedorNombreId")))
                    strbldFacturas.Append("</a>")
                    strbldFacturas.Append("</td>")
                    strbldFacturas.Append("<td class=" & strColorRegistro & ">")
                    strbldFacturas.Append(CStr(objRegistroFacturasElectronicas.Item("strProveedorRazonSocial")))
                    strbldFacturas.Append("</td>")
                    strbldFacturas.Append("</tr>")

                Next

            End If

            strbldFacturas.Append("</table>")

            strFacturasHTML = strbldFacturas.ToString

            Return strFacturasHTML
        End Get
    End Property

    '====================================================================
    ' Name       : strEnviosHTML
    ' Description: Valor que tomara la variable strEnviosHTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strEnviosHTML() As String
        Get

            Dim strbldEnvios As StringBuilder
            Dim objEnvios As Array = Nothing
            Dim strEnvios As String() = Nothing
            Dim intContador As Integer = 0
            Dim intMod As Integer = 0
            Dim strColortd As String = "tdceleste"

            strbldEnvios = New StringBuilder

            ' Hacemos la consulta de la información del cliene especial.
            objEnvios = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.strBuscar(intCompaniaId, intSucursalId, 0, "GENERADA", True, 0, 0, strCadenaConexion)


            strbldEnvios.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strbldEnvios.Append("  <tr class='trtitulos'>")
            strbldEnvios.Append("    <th width='59' class='rayita'>No. Orden</th>")
            strbldEnvios.Append("    <th width='56' class='rayita'>Destino</th>")
            strbldEnvios.Append("    <th width='74' class='rayita'>Fecha</th>")
            strbldEnvios.Append("  </tr>")

            ' Validamos si trae información para mostrarla
            If IsArray(objEnvios) AndAlso objEnvios.Length > 0 Then
                strEnvios = DirectCast(objEnvios.GetValue(0), String())

                ' Barremos el arreglo para ir formando los campos a mostrar en la página HTML
                For intContador = 0 To objEnvios.Length - 1
                    strEnvios = Nothing
                    strEnvios = DirectCast(objEnvios.GetValue(intContador), String())

                    intMod = intContador Mod 2
                    If intMod = 0 Then
                        strColortd = "tdceleste"
                    Else
                        strColortd = "tdblanco"
                    End If

                    strbldEnvios.Append("  <tr>")
                    strbldEnvios.Append("    <td class='" & strColortd & "'><a href='" & strURLSucursal & "MercanciaConfirmarEnvioProductos.aspx&strUseRedirector=True&intTransferenciaId=" & strEnvios(0) & "&intCompaniaEnvioId=" & strEnvios(7) & "&intSucursalEnvioId=" & strEnvios(8) & "' class='txaccion' target='_top'>" & strEnvios(1) & "</a></td>")
                    strbldEnvios.Append("    <td class='" & strColortd & "'>" & strEnvios(4) & "-" & strEnvios(5) & "</td>")
                    strbldEnvios.Append("    <td class='" & strColortd & "'>" & clsCommons.strDMYtoMDY(strEnvios(2)) & "</td>")
                    strbldEnvios.Append("  </tr>")

                Next

            End If

            strbldEnvios.Append("</table>")

            strEnviosHTML = strbldEnvios.ToString

            Return strEnviosHTML
        End Get
    End Property

    '====================================================================
    ' Name       : strRecibosHTML
    ' Description: Valor que tomara la variable strRecibosHTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRecibosHTML() As String
        Get

            Dim strbldRecibos As StringBuilder
            Dim objRecibos As Array = Nothing
            Dim strRecibos As String() = Nothing
            Dim intContador As Integer = 0
            Dim intMod As Integer = 0
            Dim strColortd As String = "tdceleste"

            strbldRecibos = New StringBuilder

            ' Hacemos la consulta de la información del cliene especial.
            objRecibos = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.strBuscar(intCompaniaId, intSucursalId, 0, "ENVIADA", False, 0, 0, strCadenaConexion)

            strbldRecibos.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strbldRecibos.Append("  <tr class='trtitulos'>")
            strbldRecibos.Append("    <th width='59' class='rayita'>No. Orden</th>")
            strbldRecibos.Append("    <th width='56' class='rayita'>Origen</th>")
            strbldRecibos.Append("    <th width='74' class='rayita'>Fecha</th>")
            strbldRecibos.Append("  </tr>")

            ' Validamos si trae información para mostrarla
            If IsArray(objRecibos) AndAlso objRecibos.Length > 0 Then
                strRecibos = DirectCast(objRecibos.GetValue(0), String())

                ' Barremos el arreglo para ir formando los campos a mostrar en la página HTML
                For intContador = 0 To objRecibos.Length - 1
                    strRecibos = Nothing
                    strRecibos = DirectCast(objRecibos.GetValue(intContador), String())

                    intMod = intContador Mod 2
                    If intMod = 0 Then
                        strColortd = "tdceleste"
                    Else
                        strColortd = "tdblanco"
                    End If

                    strbldRecibos.Append("  <tr>")
                    strbldRecibos.Append("    <td class='" & strColortd & "'><a href='" & strURLSucursal & "MercanciaConfirmarReciboDeProductos.aspx&strUseRedirector=True&intTransferenciaId=" & strRecibos(0) & "&intCompaniaEnvioId=" & strRecibos(7) & "&intSucursalEnvioId=" & strRecibos(8) & "' class='txaccion' target='_top'>" & strRecibos(1) & "</a></td>")
                    strbldRecibos.Append("    <td class='" & strColortd & "'>" & strRecibos(4) & "-" & strRecibos(5) & "</td>")
                    strbldRecibos.Append("    <td class='" & strColortd & "'>" & clsCommons.strDMYtoMDY(strRecibos(2)) & "</td>")
                    strbldRecibos.Append("  </tr>")

                Next

            End If

            strbldRecibos.Append("</table>")

            strRecibosHTML = strbldRecibos.ToString

            Return strRecibosHTML
        End Get
    End Property

    '====================================================================
    ' Name       : strPlanogramaHTML
    ' Description: Valor que tomara la variable strmPlanogramaHTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strPlanogramaHTML() As String
        Get
            Dim objPlanogramas As Array = Nothing
            Dim strbldPlanograma As StringBuilder
            Dim strPlanogramas As String() = Nothing
            Dim intContador As Integer = 0
            Dim strFechaHoy As String
            Dim intMod As Integer = 0
            Dim strColortd As String = "tdceleste"

            ' Creamos los string builders.
            strbldPlanograma = New StringBuilder

            'Determinamos la fecha de hoy para la consulta
            strFechaHoy = Month(Now()) & "/" & Day(Now()) & "/" & Year(Now())

            'Hacemos la consulta de los planogramas
            objPlanogramas = clsConcentrador.clsPlanograma.strBuscar(intCompaniaId, intSucursalId, CDate(strFechaHoy), 0, 0, strCadenaConexion)

            ' Validamos si trae información para mostrarla
            If IsArray(objPlanogramas) AndAlso objPlanogramas.Length > 0 Then

                strbldPlanograma.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

                ' Barremos el arreglo para ir formando los campos a mostrar en la página HTML
                For intContador = 0 To objPlanogramas.Length - 1
                    strPlanogramas = Nothing
                    strPlanogramas = DirectCast(objPlanogramas.GetValue(intContador), String())

                    intMod = intContador Mod 2
                    If intMod = 0 Then
                        strColortd = "tdceleste"
                    Else
                        strColortd = "tdblanco"
                    End If

                    ' Formamos el renglón con la información traida de la base de datos.
                    strbldPlanograma.Append("    <tr> ")
                    strbldPlanograma.Append("        <td class='" & strColortd & "' width='76'>" & strPlanogramas(0) & "</td>")
                    strbldPlanograma.Append("        <td class='" & strColortd & "' width='514'>" & strPlanogramas(2) & "</td>")
                    strbldPlanograma.Append("        <td class='" & strColortd & "' width='85'><a href='" & strURLSucursal & "MercanciaConsultarPlanogramaTexto.aspx&strUseRedirector=True&intPlanoId=" & strPlanogramas(0) & "' target='_top'><img src='../static/images/icono_texto.gif' width='8' height='12' border='0' align='absmiddle'></a>&nbsp;&nbsp;<a href='" & strURLSucursal & "MercanciaConsultarPlanogramaTexto.aspx&strUseRedirector=True&intPlanoId=" & strPlanogramas(0) & "' class='txaccion' target='_top'>Texto</a></td>")
                    strbldPlanograma.Append("        <td class='" & strColortd & "' width='279'><a href='../static/PDF/Planos/Pa" & Right("000000" & strPlanogramas(0), 6) & ".PDF' target='_top'><img src='../static/images/icono_grafico.gif' width='9' height='12' border='0' align='absmiddle'></a>&nbsp;&nbsp;<a href='../static/PDF/Planos/Pa" & Right("000000" & strPlanogramas(0), 6) & ".PDF' class='txaccion' target='_top'>Gr&aacute;fico</a></td>")
                    strbldPlanograma.Append("    </tr>")

                Next

                'Cerramos la tabla
                strbldPlanograma.Append("</table>")

                'Convertimos a string
                strPlanogramaHTML = strbldPlanograma.ToString

                'Regresamos el reultado
                Return strPlanogramaHTML

            End If


        End Get
    End Property

    '====================================================================
    ' Name       : strListadoInventariosHTML
    ' Description: Genera la lista con los listados de inventarios del día
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strListadoInventariosHTML() As String
        Get
            Dim strHTML As StringBuilder

            Dim objArrayListado As Array = Nothing
            Dim strRegistroListado As String() = Nothing

            Dim intContador As Integer = 0
            Dim strclass As String = "tdceleste"


            strHTML = New StringBuilder


            'Hacemos la consulta de los Listados
            objArrayListado = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarListado(intCompaniaId, intSucursalId, 0, 0, strCadenaConexion)

            ' Validamos si trae información para mostrarla
            If IsArray(objArrayListado) AndAlso objArrayListado.Length > 0 Then
                intContador = 0

                strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

                For Each strRegistroListado In objArrayListado

                    If (intContador Mod 2) = 0 Then
                        strclass = "tdceleste"
                    Else
                        strclass = "tdblanco"
                    End If

                    strHTML.Append("<tr> ")
                    strHTML.Append("<td class='" & strclass & "' width='480'>" & strRegistroListado(1) & "</td>")
                    strHTML.Append("<td class='" & strclass & "' width='40'>" & strRegistroListado(2) & "</td>")
                    strHTML.Append("<td class='" & strclass & "' width='40'>" & strRegistroListado(3) & "</td>")
                    strHTML.Append("</tr>")
                    intContador += 1
                Next
                'Cerramos la tabla
                strHTML.Append("</table>")

            End If

            'Regresamos el reultado
            Return strHTML.ToString


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

        Dim strUsuarioNombre As String = Request.Form("txtUsuarioNombre")
        Dim strUsuarioContrasena As String = Request.Form("txtUsuarioContrasena")
        Dim intResultado As Integer = 0

        If Len(strUsuarioNombre) > 0 AndAlso Len(strUsuarioContrasena) > 0 Then

            ' Ejecutamos la validación de la cuenta del usuario
            intResultado = clsConcentrador.clsControlAcceso.intValidarCuentaUsuario(strUsuarioNombre, strUsuarioContrasena, Response, Server, strCadenaConexion)

        Else

            If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
                Call Response.Redirect(strRedirectPage)
            End If

        End If

    End Sub

End Class
