Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration

Public Class clsMercanciaConfirmarReciboDeProductos
    Inherits System.Web.UI.Page
    Private strTipoEstadoTransferenciaNombreId As String
    Public strGeneraTablaHTML As String
    Public strHdnFolioEnvio As String
    Public strHdnFolioRecepcion As String
    Public strHdnNumeroDeOrden As String
    Public strHdnFechaDeOrden As String
    Public strTxtFechaDeConfirmacion As String
    Public strHdnMotivoDeTransferencia As String
    Public strHdnSucursalQueEnvia As String
    Public strmMensaje As String
    Public intAccionOnLoad As Integer = 0
    Public strHdnCompaniaSucursalOrigen As String


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
            If Not IsNothing(Request.QueryString("strCmd")) Then
                Return Request.QueryString("strCmd")
            Else
                Return ""
            End If
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
    ' Name       : intTransferenciaId
    ' Description: valor del querystring
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTransferenciaId() As Integer
        Get
            Dim strTemporal As String
            strTemporal = Trim(Request.QueryString("intTransferenciaId"))
            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If
        End Get
    End Property
    '====================================================================
    ' Name       : cmdConfirmar
    ' Description: valor del campo cmdConfirmar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property cmdConfirmar() As String
        Get
            Dim strTemporal As String
            strTemporal = Trim(Request.Form("cmdConfirmar"))
            If strTemporal.Equals("") Then
                Return ""
            Else
                Return strTemporal
            End If
        End Get
    End Property
    '====================================================================
    ' Name       : cmdConfirmar
    ' Description: valor del campo cmdConfirmar
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

    Public ReadOnly Property strFechaDeConfirmacion() As String
        Get
            Return Now.Day.ToString("00") & "/" + Now.Month.ToString("00") & "/" & Now.Year.ToString("0000")
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
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        strGeneraTablaHTML = "<input type=hidden name=hdnTotalDePartidas value=0>"
        Dim objArray As Array
        Dim intInicio As Integer = 0

        If cmdConfirmar.Equals("") Then
            strTipoEstadoTransferenciaNombreId = "ENVIADA"
            If intTransferenciaId > 0 Then
                Dim objRegistro As String() = Nothing

                objArray = Nothing
                objArray = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.strBuscar(intCompaniaId, intSucursalId, intTransferenciaId, strTipoEstadoTransferenciaNombreId, False, 0, 0, strCadenaConexion)

                If IsArray(objArray) AndAlso (objArray.Length > 0) Then
                    objRegistro = DirectCast(objArray.GetValue(0), String())

                    '0 intTransferenciaId   
                    '1 intTransferenciaNumeroOrden 
                    '2 dtmTransferenciaRegistro  
                    '3 intEstadoTransferenciaFolio 
                    '4 dtmEstadoTransferenciaRegistro  
                    '5 intMotivoTransferenciaId 
                    '6 strMotivoTransferenciaNombre   
                    '7 intCompaniaOrigenId 
                    '8 intSucursalOrigenId 
                    '9 strSucursalOrigenNombre   
                    '10 intCompaniaDestinoId 
                    '11 intSucursalDestinoId 
                    '12 strSucursalDestinoNombre                           

                    strHdnFolioEnvio = CStr(objRegistro.GetValue(3)) '0 intEstadoTransferenciaFolio  y Cuando se grabe mostrar el de recepcion pero buscando las recibida 
                    strHdnNumeroDeOrden = CStr(objRegistro.GetValue(1)) '1 intTransferenciaNumeroOrden 
                    strHdnFechaDeOrden = clsCommons.strFormatearFechaPresentacion(CStr(objRegistro.GetValue(2))) '2 dtmTransferenciaRegistro 

                    ' la primera vez no se muestra
                    strTxtFechaDeConfirmacion = "" 'clsCommons.strFormatearFechaPresentacion(objRegistro.GetValue(4)) '4 dtmEstadoTransferenciaRegistro  

                    strHdnMotivoDeTransferencia = CStr(objRegistro.GetValue(6)) '6 strMotivoTransferenciaNombre
                    strHdnSucursalQueEnvia = clsCommons.strFormatearDescripcion(CStr(objRegistro.GetValue(9))) '9 strSucursalOrigenNombre
                    strHdnCompaniaSucursalOrigen = CStr(objRegistro.GetValue(7)) & " - " & CStr(objRegistro.GetValue(8))

                    'strHdnFolioRecepcion 
                End If

                'Generar RecordBrowser Detalle   
                objArray = Nothing
                objArray = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.strBuscarDetalle(intCompaniaId, intSucursalId, intTransferenciaId, strTipoEstadoTransferenciaNombreId, 0, 0, strCadenaConexion)
                strGeneraTablaHTML = strGeneraTabla(objArray, intInicio, "Detalle Transferencia", "No.", "&nbsp;", "Código", "Descripción", "P. unitario", "Sugerida", "Confirmada", "Recibida")

            End If
        ElseIf cmdConfirmar.Equals("Confirmar") Then
            Dim i As Integer
            Dim intOrdenReg As Integer
            Dim strEnvoltura As String

            Dim intArticuloId As Integer
            Dim intArticuloEstadoTransferenciaCantidad As Integer
            Dim fltArticuloEstadoTransferenciaPrecioVenta As Double
            Dim dtmArticuloEstadoTransferenciaRegistro As Date
            Dim intResultado As Integer

            strTipoEstadoTransferenciaNombreId = "RECIBIDA"
            dtmArticuloEstadoTransferenciaRegistro = CDate(clsCommons.strDMYtoMDY(Request.Form("txtFechaDeConfirmacion")))

            'Con todos los articulos
            For i = 1 To CInt(Request.Form("hdnTotalDePartidas"))

                intOrdenReg = CInt(Request.Form("hdnOrden_" & CStr(i)))
                strEnvoltura = CStr(Request.Form("hdnColumna0_" & CStr(i)))
                intArticuloId = CInt(Request.Form("hdnColumna1_" & CStr(i)))
                fltArticuloEstadoTransferenciaPrecioVenta = CDbl(Request.Form("hdnColumna2_" & CStr(i)))
                intArticuloEstadoTransferenciaCantidad = CInt(Request.Form("txtRecibida_" & CStr(i)))


                intResultado = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.intAgregarArticulo(intTransferenciaId _
                            , strTipoEstadoTransferenciaNombreId _
                            , intOrdenReg _
                            , strEnvoltura _
                            , intArticuloId _
                            , intArticuloEstadoTransferenciaCantidad _
                            , fltArticuloEstadoTransferenciaPrecioVenta _
                            , dtmArticuloEstadoTransferenciaRegistro _
                            , strUsuarioNombre _
                            , strCadenaConexion)
                If intResultado < 0 Then
                    strMensaje = "Error al grabar detalle de confirmación."
                    Exit For
                End If
            Next

            Dim strEstadoTransferenciaComentarios As String = ""
            '0 intEstadoTransferenciaFolio
            'dtmArticuloEstadoTransferenciaRegistro  txtFechaDeConfirmacion 'dtmEstadoTransferenciaRegistro

            If intResultado >= 0 Then
                intResultado = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.intCambiarEstado(intCompaniaId _
                    , intSucursalId, intTransferenciaId, strTipoEstadoTransferenciaNombreId _
                    , 0, dtmArticuloEstadoTransferenciaRegistro _
                    , strEstadoTransferenciaComentarios, strUsuarioNombre, strCadenaConexion)
                If intResultado < 0 Then
                    strMensaje = "Error al grabar confirmación."
                End If
            End If

            strHdnFolioRecepcion = intResultado.ToString
            'Mostrar nuevamente los datos en la pantalla
            strHdnFolioEnvio = Request.Form("hdnFolioEnvio")
            strHdnNumeroDeOrden = Request.Form("hdnNumeroDeOrden")
            strHdnFechaDeOrden = Request.Form("hdnFechaDeOrden")
            strTxtFechaDeConfirmacion = Request.Form("txtFechaDeConfirmacion")
            strHdnMotivoDeTransferencia = Request.Form("hdnMotivoDeTransferencia")
            strHdnSucursalQueEnvia = Request.Form("hdnSucursalQueEnvia")
            strHdnCompaniaSucursalOrigen = Request.Form("hdnCompaniaSucursalOrigen")

            'Mostrar Nuevamente el record browser
            'Generar RecordBrowser Detalle   
            objArray = Nothing
            objArray = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.strBuscarDetalle(intCompaniaId, intSucursalId, intTransferenciaId, strTipoEstadoTransferenciaNombreId, 0, 0, strCadenaConexion)
            strGeneraTablaHTML = strGeneraTabla(objArray, intInicio, "Detalle Transferencia", "No.", "&nbsp;", "Código", "Descripción", "P. unitario", "Sugerida", "Confirmada", "Recibida", True)

            If intResultado < 0 Then
                intAccionOnLoad = 0
            Else
                strMensaje = "Confirmación de productos recibidos con éxito."
                intAccionOnLoad = 1
            End If
        End If

    End Sub

    Private Function strGeneraTabla(ByVal objArray As Array, _
                                  ByRef intConsecutivo As Integer, _
                                  ByVal strTitulo As String, _
                                  ByVal strEncaCol0 As String, _
                                  ByVal strEncaCol1 As String, _
                                  ByVal strEncaCol2 As String, _
                                  ByVal strEncaCol3 As String, _
                                  ByVal strEncaCol4 As String, _
                                  ByVal strEncaCol5 As String, _
                                  ByVal strEncaCol6 As String, _
                                  ByVal strEncaCol7 As String, _
                                  Optional ByVal blnReadOnly As Boolean = False _
                                  ) As String

        Dim strHTML As StringBuilder
        Dim strRegistro As String()
        strRegistro = Nothing
        Dim intRenglon As Integer
        Dim dblTotal As Double
        Dim strClass As String
        Dim strComilla As String
        Dim strReadonly As String

        If blnReadOnly Then
            strReadonly = " readonly "
        Else
            strReadonly = ""
        End If

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
        strHTML.Append("<th width='06%'  class='rayita'>" & strEncaCol0 & "</th>") '"No."
        strHTML.Append("<th width='05%'  class='rayita'>" & strEncaCol1 & "</th>")
        strHTML.Append("<th width='10%'  class='rayita'>" & strEncaCol2 & "</th>") '"Código"
        strHTML.Append("<th width='35%'  class='rayita'>" & strEncaCol3 & "</th>") '"Descripción"
        strHTML.Append("<th width='14%'  class='rayita'>" & strEncaCol4 & "</th>") '"P. unitario"
        strHTML.Append("<th width='10%'  class='rayita'>" & strEncaCol5 & "</th>") '"Sugerida"
        strHTML.Append("<th width='10%'  class='rayita'>" & strEncaCol6 & "</th>") '"Confirmada"
        If blnReadOnly Then
            strHTML.Append("<th width='10%'  class='rayita'>" & "&nbsp;" & "</th>")
        Else
            strHTML.Append("<th width='10%'  class='rayita'>" & strEncaCol7 & "</th>")
        End If
        strHTML.Append("</tr>")

        '------------------------
        intRenglon = 0
        If IsArray(objArray) AndAlso (objArray.Length > 0) Then
            For Each strRegistro In objArray

                '0 strArticuloEstadoTransferenciaEnvoltura 
                '1 intArticuloId 
                '2 strArticuloDescripcion
                '3 fltArticuloPrecioActual 
                '4 fltArticuloEstadoTransferenciaPrecioVenta
                '5 intCantidadSugerida 
                '6 intArticuloEstadoTransferenciaCantidad 
                '7 blnTransferenciaEsManual  
                '8 intArticuloEstadoTransferenciaOrden
                '9 intTotalRegistros 

                intConsecutivo += 1
                intRenglon += 1
                If ((intRenglon Mod 2) = 0) Or (intRenglon = 0) Then
                    strClass = "tdceleste"
                Else
                    strClass = "tdblanco"
                End If

                strHTML.Append("<tr>")


                '8 intArticuloEstadoTransferenciaOrden
                strHTML.Append("<td class='" & strClass & "'>" & intConsecutivo.ToString & "&nbsp;</td>")
                strHTML.Append("<input type=hidden name=hdnOrden_" & Trim(CStr(intRenglon)) & " value=" & strComilla & strRegistro(8) & strComilla & ">")

                '0 strArticuloEstadoTransferenciaEnvoltura
                strHTML.Append("<td class='" & strClass & "'>" & strRegistro(0) & "&nbsp;</td>")
                strHTML.Append("<input type=hidden name=hdnColumna0_" & Trim(CStr(intRenglon)) & " value=" & strComilla & strRegistro(0) & strComilla & ">")

                '1 intArticuloId 
                strHTML.Append("<td class='" & strClass & "'>" & strRegistro(1) & "&nbsp;</td>")
                strHTML.Append("<input type=hidden name=hdnColumna1_" & Trim(CStr(intRenglon)) & " value=" & strComilla & strRegistro(1) & strComilla & ">")
                '2 strArticuloDescripcion
                strHTML.Append("<td class='" & strClass & "'>" & strRegistro(2) & "&nbsp;</td>")
                '3 fltArticuloPrecioActual 
                strHTML.Append("<td class='" & strClass & "'>" & FormatNumber(strRegistro(3), 2) & "&nbsp;</td>")
                strHTML.Append("<input type=hidden name=hdnColumna2_" & Trim(CStr(intRenglon)) & " value=" & strComilla & strRegistro(3) & strComilla & ">")
                '5 intCantidadSugerida 
                strHTML.Append("<td class='" & strClass & "'>" & strRegistro(5) & "&nbsp;</td>")
                strHTML.Append("<input type=hidden name=hdnColumna3_" & Trim(CStr(intRenglon)) & " value=" & strComilla & strRegistro(5) & strComilla & ">")

                '6 intArticuloEstadoTransferenciaCantidad 
                strHTML.Append("<td class='" & strClass & "'>" & strRegistro(6) & "&nbsp;</td>")
                strHTML.Append("<input type=hidden name=hdnColumna4_" & Trim(CStr(intRenglon)) & " value=" & strComilla & strRegistro(6) & strComilla & ">")

                If blnReadOnly Then
                    strHTML.Append("<td class='" & strClass & "'>&nbsp;</td>")
                Else
                    strHTML.Append("<td class='" & strClass & "'>" & "<input name=txtRecibida_" & Trim(CStr(intRenglon)) & " type=text class=campotabla size=4 " & strReadonly)
                    strHTML.Append("onblur=" & strComilla & "javascript:return ValidarDetalle(this);" & strComilla & "></td>")
                End If

                strHTML.Append("</tr>")
            Next
        End If
        '------------------------

        strHTML.Append("</table>")
        strHTML.Append("<input type=hidden name=hdnTotalDePartidas value=" & intRenglon.ToString & ">")
        strGeneraTabla = clsCommons.strGenerateJavascriptString(strHTML.ToString)
    End Function

End Class
