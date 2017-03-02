Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration

Public Class clsMercanciaCapturarMermaControlada
    Inherits System.Web.UI.Page

    'Variables globales
    Private intmMermaId As Integer
    Private strmArticuloDescripcion As String = ""
    Private strmRecordBrowserHTML As String = ""
    Private intmCifraControl As Integer = 0
    Private intmError As Integer = 0
    Private dblmPrecioUnitario As Double = 0.0
    Private strmMensaje As String = ""
    Private intmFolioMerma As Integer = 0
    Private strmintArticuloId As String = ""
    Private strmbtnAgregar As String = ""



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
    ' Name       : intFolioMerma
    ' Description: Numero de folio de Merma generado
    ' Accessor   : Read and Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intFolioMerma() As Integer
        Get
            Return intmFolioMerma
        End Get
        Set(ByVal intValue As Integer)
            If IsNothing(intmFolioMerma) Then
                intmFolioMerma = 0
            Else
                intmFolioMerma = intValue
            End If
        End Set
    End Property


    '====================================================================
    ' Name       : dtmFechaCaptura
    ' Description: Fecha de captura de la merma
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaCaptura() As String
        Get
            If Request("txtFechaCaptura") = "" Then
                Return Format(Date.Now, "dd/MM/yyyy")
            Else
                Return Trim(Request("txtFechaCaptura"))
            End If
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
    ' Name       : intCantidadArticulo
    ' Description: Cantidad del artículo mermado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCantidadArticulo() As Integer
        Get
            If Not IsNothing(Request.Form("txtCantidadArticulo")) Then
                Return CInt(Request.Form("txtCantidadArticulo"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intMotivoMermaId
    ' Description: Motivo de la Merma
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intMotivoMermaId() As Integer
        Get
            If Not IsNothing(Request.Form("cboMotivoMerma")) Then
                Return CInt(Request.Form("cboMotivoMerma"))
            Else
                Return 0
            End If
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
    ' Name       : intMermaId
    ' Description: Motivo de la Merma
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intMermaId() As Integer
        Get

            If CInt(Request.Form("txtMermaId")) > 0 Then
                Return CInt(Request.Form("txtMermaId"))

            ElseIf Not IsNothing(Request.QueryString("intMermaId")) Then
                Return CInt(Request.QueryString("intMermaId"))

            Else
                Return intMermaCalculada
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : intMermaCalculada
    ' Description: Motivo de la Merma
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intMermaCalculada() As Integer
        Get
            Return intmMermaId
        End Get
        Set(ByVal intValue As Integer)
            intmMermaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strGeneraComboMotivoMerma
    ' Description: Lista los motivos de Merma
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================

    Public Function strGeneraComboMotivoMerma() As String
        Dim objMotivosMerma As Array = Nothing
        Dim strRegistroMotivoMerma As String()
        Dim strcboMotivoMerma As StringBuilder
        Dim intIndiceCombo As Integer

        ' Creamos la cadena en donde se formará el combo con los motivos de merma
        strcboMotivoMerma = New StringBuilder

        'Consultamos los motivos de merma
        objMotivosMerma = clstblMotivoMerma.strBuscar(0, "", "", CDate("01/01/1900"), "", 0, 0, strCadenaConexion)

        'Inicializamos el Combo de los motivos de merma

        strcboMotivoMerma.Append("document.forms[0].cboMotivoMerma.options[")
        strcboMotivoMerma.Append("0] = new Option(""" & "Seleccione un Motivo" & """,""" & "0" & """);" & vbCrLf)

        ' Recorremos el arreglo con todos los motivos para crear el combo list

        If IsArray(objMotivosMerma) AndAlso objMotivosMerma.Length > 0 Then
            intIndiceCombo = 1

            For Each strRegistroMotivoMerma In objMotivosMerma
                strcboMotivoMerma.Append("document.forms[0].cboMotivoMerma.options[" & intIndiceCombo & "] = ")
                strcboMotivoMerma.Append("new Option(""" & clsCommons.strFormatearDescripcion(strRegistroMotivoMerma(2)).ToString & """,""" & strRegistroMotivoMerma(0) & """);" & vbCrLf)

                ' Verificamos el Motivo Merma seleccionado

                If (intMotivoMermaId > 0) AndAlso (intMotivoMermaId = CInt(strRegistroMotivoMerma(0))) Then
                    strcboMotivoMerma.Append("document.forms[0].cboMotivoMerma.options[" & intIndiceCombo & "].selected = true;" & vbCrLf)
                End If

                intIndiceCombo += 1

            Next

        End If


        Return strcboMotivoMerma.ToString

    End Function

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
                Return clsCommons.strFormatearDescripcion(Request("txtArticuloId"))
            ElseIf intArticuloId <> "" Then
                '  Return intArticuloId
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strMotivoMermaId
    ' Description: Identificador de la merma del articulo a borrar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strMotivoMermaId() As String
        Get
            If Not IsNothing(Request.QueryString("intMotivoMermaId")) Then
                Return Request.QueryString("intMotivoMermaId")
            Else
                Return "0"
            End If

        End Get
    End Property

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
    ' Name       : strArticuloDescripcion
    ' Description: Consulta la descripción del Artículo
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Sub strBuscarInformacionArticulo()
        Dim objArticulos As Array = Nothing
        Dim strArticulos As String() = Nothing


        ' Consulta el código o la descripción capturada 
        objArticulos = clsConcentrador.clsSucursal.strBuscarArticulo(intCompaniaId, intSucursalId, strArticuloId, 100, 100, strCadenaConexion)

        If IsArray(objArticulos) AndAlso (objArticulos.Length > 0) Then
            ' Obtenemos el código y la descripcion del articulo
            strArticulos = DirectCast(objArticulos.GetValue(0), String())

            intArticuloId = clsCommons.strFormatearDescripcion(strArticulos(0))
            strArticuloDescripcion = clsCommons.strFormatearDescripcion(strArticulos(5)).ToString
            dblPrecioUnitario = CDbl(clsCommons.strFormatearDescripcion(strArticulos(1)).ToString)
            intError = 0
        Else
            strArticuloDescripcion = ""
            intArticuloId = "0"
            intError = -100
        End If


    End Sub

    '====================================================================
    ' Name       : dblPrecioUnitario
    ' Description: Precio Unitario del artículo a agregar
    ' Accessor   : Read / Write
    ' Throws     : Ninguna
    ' Output     : Double
    '====================================================================
    Public Property dblPrecioUnitario() As Double
        Get
            Return dblmPrecioUnitario
        End Get
        Set(ByVal dblValue As Double)
            dblmPrecioUnitario = dblValue
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
    ' Name       : intCifraControl
    ' Description: Sumatoria de las cantidad de articulos mermados
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intCifraControl() As Integer
        Get
            Return intmCifraControl
        End Get
        Set(ByVal intValue As Integer)
            intmCifraControl = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowserMermasHTML
    ' Description: Genera el Record Browser con los articulo mermados.
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserMermasHTML() As String

        ' Declaracion de Variables
        Dim objMermas As Array
        Dim strMermasHTML As StringBuilder
        Dim strRegistroMerma As String()
        Dim intConsecutivo As Integer
        Dim strColorRegistro As String
        Dim intSumatoria As Integer

        'Inicializamos variables
        strMermasHTML = New StringBuilder
        objMermas = Nothing
        strRegistroMerma = Nothing
        intConsecutivo = 0
        intSumatoria = 0

        ' Obtenemos los artículos Mermados
        objMermas = clsConcentrador.clsSucursal.clsMercancia.clsMerma.strBuscarDetalleMermaControlada(intMermaId, 0, 0, strCadenaConexion)

        If IsArray(objMermas) AndAlso (objMermas.Length > 0) Then

            ' Pintamos los titulos de la tabla
            Call strMermasHTML.Append("<table cellspacing='0' cellpadding='0' width='583' border='0'>")
            Call strMermasHTML.Append("<tr class='trtitulos'>")
            Call strMermasHTML.Append("<th class='rayita' width='55'>Código</th>")
            Call strMermasHTML.Append("<th class='rayita' width='126'>Descripcion</th>")
            Call strMermasHTML.Append("<th class='rayita' width='50'>Motivo</th>")
            Call strMermasHTML.Append("<th class='rayita' width='71'>Cantidad</th>")
            Call strMermasHTML.Append("<th class='rayita' width='72'>p.Unitario</th>")
            Call strMermasHTML.Append("<th class='rayita' width='55'>Importe</th>")
            Call strMermasHTML.Append("<th class='rayita' width='129' align='center'>Acción</th></tr>")

            intConsecutivo += 1
            For Each strRegistroMerma In objMermas
                If (intConsecutivo Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If

                'Pintado de cada Registro
                Call strMermasHTML.Append("<tr>")
                Call strMermasHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroMerma(0)).ToString & "</td>")           'intArticuloId
                Call strMermasHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroMerma(1)).ToString & "</td>")           'strDescripcion
                Call strMermasHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroMerma(3)).ToString & "</td>")           'strMotivoMermaNombreId
                Call strMermasHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroMerma(4)).ToString & "</td>")           'intCantidad
                Call strMermasHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroMerma(5)).ToString & "</td>")           'Precio Unitario
                Call strMermasHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroMerma(6)).ToString & "</td>")           'Importe
                Call strMermasHTML.Append("<td class=" & strColorRegistro & " align='center'><a href='MercanciaCapturarMermaControlada.aspx?txtArticuloId=" & clsCommons.strFormatearDescripcion(strRegistroMerma(0)).ToString & "&intMermaId=" & intMermaId.ToString & "&intMotivoMermaId=" & clsCommons.strFormatearDescripcion(strRegistroMerma(2)).ToString & "&txtFechaCaptura=" & dtmFechaCaptura.ToString & "&strCmd=BorrarArticulo'><img src='../static/images/imgNRborrar.gif' border='0' align='absmiddle' type='submit'></a></td>")
                Call strMermasHTML.Append("</tr>")
                intConsecutivo += 1
                intSumatoria += CInt(strRegistroMerma(4))
            Next


            Call strMermasHTML.Append("</table>")

            Call strMermasHTML.Append("<br>")
            Call strMermasHTML.Append("<table width='98%' border='0' cellpadding='0' cellspacing='0'>")
            Call strMermasHTML.Append("<tr>")
            Call strMermasHTML.Append("<td width='317'><input name='cmdRegresar' type='button' class='boton' value='Regresar' onclick='return cmdRegresar_onclick()'>")
            Call strMermasHTML.Append("&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;")
            Call strMermasHTML.Append("<input name='cmdCancelar' type='button' class='boton' value='Cancelar' onclick='return cmdCancelar_onclick()'>")
            Call strMermasHTML.Append("</td>")
            Call strMermasHTML.Append("<td width='200' align='center' bgcolor='#f4f6f8' class='tdenvolventeazul'>")
            Call strMermasHTML.Append("<table width='230' border='0' cellpadding='0' cellspacing='0'>")
            Call strMermasHTML.Append("<tr>")
            Call strMermasHTML.Append("<td width='156' class='tdtittablas'>Cifra de control</td>")
            Call strMermasHTML.Append("<td width='91' rowspan='2'><input name='cmdRegistrar' type='button' class='boton' value='Registrar Merma' onclick='return cmdRegistrar_onclick()'></td>")
            Call strMermasHTML.Append("</tr>")
            Call strMermasHTML.Append("<tr>")
            Call strMermasHTML.Append("<td height='30' valign='top'> <input name='txtCifraControl' type='text' class='campotabla' size='16' maxlength='4'></td>")
            Call strMermasHTML.Append("</tr>")
            Call strMermasHTML.Append("</table>")
            Call strMermasHTML.Append("</td>")
            Call strMermasHTML.Append("</tr>")
            Call strMermasHTML.Append("</table>")

            Call strMermasHTML.Append("<script language='javascript'>document.forms[0].txtArticuloId.focus();" & "</script>")

        End If

        intCifraControl = intSumatoria
        strRecordBrowserMermasHTML = strMermasHTML.ToString

    End Function

    '====================================================================
    ' Name       : strbtnAgregar
    ' Description: Pinta el boton de Agregar y Regresar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strbtnAgregar() As String
        Get
            Return strmbtnAgregar
        End Get
        Set(ByVal strValue As String)
            strmbtnAgregar = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : Page_Load
    ' Description: Page Load de la página
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        ' inicializamos el record browser 
        strRecordBrowserHTML = ""

        ' Verificamos el comando recibido en la página

        Select Case strCmd

            Case "BuscarArticulo"

                ' Busqueda de la descripcion del articulo
                Call strBuscarInformacionArticulo()
                If intError = 0 Then
                    Response.Write("<script language='javascript'>" & _
                                   "parent.fnUpdArticuloPorIframe('" & intArticuloId.ToString & _
                                   "','" & strArticuloDescripcion & _
                                   "','" & dblPrecioUnitario.ToString & _
                                   "',0)" & _
                                   "</script>")
                Else
                    Response.Write("<script language='javascript'>" & _
                                   "parent.fnUpdArticuloPorIframe('','',''," & intError.ToString & ")" & _
                                   "</script>")
                End If
                Response.End()

                strRecordBrowserHTML = strRecordBrowserMermasHTML()

            Case "AgregarArticulo"

                    Dim intArticuloAgregado As Integer


                    'Agregamos un registro en la tabla tblMerma

                    If intMermaId = 0 Then
                        intMermaCalculada = clstblMerma.intAgregar(0, 0, intCompaniaId, intSucursalId, 0, CDate(clsCommons.strDMYtoMDY(dtmFechaCaptura)), CDate("01/01/1900"), strUsuarioNombre, strCadenaConexion)
                    End If

                    ' Obtenemos la informacion complementaria del articulo

                    Call strBuscarInformacionArticulo()

                    'Buscamos el articulo para identificar si es una actualización de cantidad o es un nuevo registro

                    If IsArray(clstblArticuloMerma.strBuscar(intMermaId, CInt(intArticuloId), intMotivoMermaId, 0, 0, CDate("01/01/1900"), "", 0, 0, strCadenaConexion)) AndAlso clstblArticuloMerma.strBuscar(intMermaId, CInt(intArticuloId), intMotivoMermaId, 0, 0, CDate("01/01/1900"), "", 0, 0, strCadenaConexion).Length > 0 Then
                        strMensaje = "Articulo ya existe."
                    End If


                    'Agregamos el articulo

                If CInt(intArticuloId) > 0 Then
                    intArticuloAgregado = clsConcentrador.clsSucursal.clsMercancia.clsMerma.intAgregarArticulo(intMermaId, CInt(intArticuloId), intMotivoMermaId, intCantidadArticulo, CDec(dblPrecioUnitario), strUsuarioNombre, strCadenaConexion)
                Else
                    intError = -100   'Codigo no existe
                End If

                'Pintamos el Record Browser

                strRecordBrowserHTML = strRecordBrowserMermasHTML()

            Case "Registrar"

                    'Generamos el folio de la Merma

                    Dim intFolioMerma As Integer = 0

                    intFolioMerma = clsConcentrador.clsSucursal.clsMercancia.clsMerma.intRegistrar(intCompaniaId, intSucursalId, intMermaId, 0, strUsuarioNombre, strCadenaConexion)

                    strMensaje = "Folio de Merma generado: " + intFolioMerma.ToString

                    'Response.Write("<script language='javascript'>alert('Folio de Merma Generado: " & intFolioMerma.ToString & "');</script>")


            Case "ErrorCifraControl"

                    'Pintamos nuevamente el RecordBrowse

                    strRecordBrowserHTML = strRecordBrowserMermasHTML()

            Case "BorrarArticulo"

                    'Eliminamos el artículo en la tabla tblArticuloMerma considerando
                    'el intArticuloId y intMermaId

                    Dim intResultadoBorrar As Integer

                    intResultadoBorrar = clsConcentrador.clsSucursal.clsMercancia.clsMerma.intBorrarArticulo(intMermaId, CInt(strArticuloId), CInt(strMotivoMermaId), strCadenaConexion)

                    strRecordBrowserHTML = strRecordBrowserMermasHTML()

            Case "Cancelar"

                    'Eliminamos los registros que se crearon en las tablas tblMerma 
                    '  y tblArticuloMerma en base a intMermaId

                    Dim intResultadoEliminartblMerma As Integer
                    Dim intResultadoEliminartblArticuloMerma As Integer

                    intResultadoEliminartblMerma = clstblMerma.intEliminar(intMermaId, 0, intCompaniaId, intSucursalId, 0, CDate("01/01/1900"), CDate("01/01/1900"), strUsuarioNombre, strCadenaConexion)

                    If intResultadoEliminartblMerma > 0 Then
                        intResultadoEliminartblArticuloMerma = clstblArticuloMerma.intEliminar(intMermaId, 0, 0, 0, 0, CDate("01/01/1900"), strUsuarioNombre, strCadenaConexion)
                    End If

                    'Redireccionamos nuevamente la página sin valores

                    Call Response.Redirect("MercanciaCapturarMermaControlada.aspx")

        End Select

        'Pinta el boton de Agregar y Regresar segun sea al caso

        If strRecordBrowserHTML.Length > 0 Then
            strbtnAgregar = "<input name='cmdAgregar'  type='button' class='boton' value='Agregar'  onclick='return cmdAgregar_onclick()'>"
        Else
            strbtnAgregar = "<input name='cmdAgregar'  type='button' class='boton' value='Agregar'  onclick='return cmdAgregar_onclick()'>&nbsp;&nbsp" & _
                            "<input name='cmdRegresar' type='button' class='boton' value='Regresar' onclick='return cmdRegresar_onclick()'>"
        End If


    End Sub

End Class

