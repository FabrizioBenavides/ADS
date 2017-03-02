'====================================================================
' Page          : MercanciaCapturarTransferenciaInterna.aspx
' Title         : Administracion POS y BackOffice
' Description   : Página de Transferencias Internas.
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : J.Antonio Hernández Dávila
' Version       : 1.0
' Last Modified : Miercoles, Noviembre  12, 2003
'====================================================================

Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business
Imports System.Text
Imports System.Configuration

Public Class MercanciaCapturarTransferenciaInterna
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

    Private strmMensaje As String = ""
    Private strmRecordBrowserHTML As String = ""
    Private intmArticuloInternoId As String = ""
    Private strmArticuloInternoDescripcion As String = ""
    Private intmDepartamentoArticuloInterno As Integer = 0
    Private intmTransferenciaInternaFolioId As Integer = 0
    Private intmTotalCantidad As Integer = 0


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
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalNombre() As String
        Get
            Return clsCommons.strReadCookie("strSucursalNombre", "", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del Usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)
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
    ' Name       : strGeneraComboDepartamentoSurtidor
    ' Description: Lista de departamentos
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGeneraComboDepartamentoSurtidor() As String
        Dim objDepartamentos As Array = Nothing
        Dim strRegistroDepartamento As String()
        Dim strcboDepartamento As StringBuilder
        Dim intIndiceCombo As Integer

        ' Creamos la cadena en donde se formará el combo con los departamentos
        strcboDepartamento = New StringBuilder

        'Consultamos los departamentos 
        objDepartamentos = clstblDepartamento.strBuscar(0, 0, "", CDate("01/01/1900"), "", 0, 0, strCadenaConexion)

        'Inicializamos el Combo de Departamentos

        strcboDepartamento.Append("document.forms[0].cboDepartamentoSurtidor.options[0] =")
        strcboDepartamento.Append("new Option(""" & "Seleccione un departamento" & """,""" & "0" & """);" & vbCrLf)

        ' Recorremos el arreglo con todos los departamentos para crear el combo list

        If IsArray(objDepartamentos) AndAlso objDepartamentos.Length > 0 Then
            intIndiceCombo = 1

            For Each strRegistroDepartamento In objDepartamentos
                strcboDepartamento.Append("document.forms[0].cboDepartamentoSurtidor.options[" & intIndiceCombo & "] = ")
                strcboDepartamento.Append("new Option(""" & clsCommons.strFormatearDescripcion(strRegistroDepartamento(2)).ToString & """,""" & clsCommons.strFormatearDescripcion(strRegistroDepartamento(0)).ToString & """);" & vbCrLf)

                ' Verificamos el departamento seleccionado

                If (intDepartamentoSurtidorId > 0) AndAlso (intDepartamentoSurtidorId = CInt(strRegistroDepartamento(0))) Then
                    strcboDepartamento.Append("document.forms[0].cboDepartamentoSurtidor.options[" & intIndiceCombo & "].selected = true;" & vbCrLf)
                End If

                intIndiceCombo += 1

            Next

        End If

        Return strcboDepartamento.ToString

    End Function

    '====================================================================
    ' Name       : strGeneraComboDepartamentoReceptor
    ' Description: Lista de departamentos Receptores
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGeneraComboDepartamentoReceptor() As String
        Dim objDepartamentos As Array = Nothing
        Dim strRegistroDepartamento As String()
        Dim strcboDepartamento As StringBuilder
        Dim intIndiceCombo As Integer

        ' Creamos la cadena en donde se formará el combo con los departamentos
        strcboDepartamento = New StringBuilder

        'Consultamos los departamentos 
        objDepartamentos = clstblDepartamento.strBuscar(0, 0, "", CDate("01/01/1900"), "", 0, 0, strCadenaConexion)

        'Inicializamos el Combo de Departamentos

        strcboDepartamento.Append("document.forms[0].cboDepartamentoReceptor.options[0] =")
        strcboDepartamento.Append("new Option(""" & "Seleccione un departamento" & """,""" & "0" & """);" & vbCrLf)

        ' Recorremos el arreglo con todos los departamentos para crear el combo list

        If IsArray(objDepartamentos) AndAlso objDepartamentos.Length > 0 Then
            intIndiceCombo = 1

            For Each strRegistroDepartamento In objDepartamentos
                strcboDepartamento.Append("document.forms[0].cboDepartamentoReceptor.options[" & intIndiceCombo & "] = ")
                strcboDepartamento.Append("new Option(""" & clsCommons.strFormatearDescripcion(strRegistroDepartamento(2)).ToString & """,""" & clsCommons.strFormatearDescripcion(strRegistroDepartamento(0)).ToString & """);" & vbCrLf)

                ' Verificamos el departamento seleccionado

                If (intDepartamentoReceptorId > 0) AndAlso (intDepartamentoReceptorId = CInt(strRegistroDepartamento(0))) Then
                    strcboDepartamento.Append("document.forms[0].cboDepartamentoReceptor.options[" & intIndiceCombo & "].selected = true;" & vbCrLf)
                End If

                intIndiceCombo += 1

            Next

        End If

        Return strcboDepartamento.ToString

    End Function

    '====================================================================
    ' Name       : strGeneraComboCuentaGasto
    ' Description: Lista de departamentos Receptores
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGeneraComboCuentaGasto() As String
        Dim objArrayCuentaGasto As Array = Nothing
        Dim strRegistroCuentaGasto As String()
        Dim strcboCuentaGasto As StringBuilder
        Dim intIndiceCombo As Integer

        ' Creamos la cadena en donde se formará el combo con los departamentos
        strcboCuentaGasto = New StringBuilder

        'Consultamos los departamentos 
        objArrayCuentaGasto = clstblCuentaGasto.strBuscar(0, "", "", CDate("01/01/1900"), "", 0, 0, strCadenaConexion)

        'Inicializamos el Combo de Departamentos

        strcboCuentaGasto.Append("document.forms[0].cboCuentaGasto.options[0] =")
        strcboCuentaGasto.Append("new Option(""" & "Seleccione la Cuenta de Gasto" & """,""" & "0" & """);" & vbCrLf)

        ' Recorremos el arreglo con todos los departamentos para crear el combo list

        If IsArray(objArrayCuentaGasto) AndAlso objArrayCuentaGasto.Length > 0 Then
            intIndiceCombo = 1

            For Each strRegistroCuentaGasto In objArrayCuentaGasto
                strcboCuentaGasto.Append("document.forms[0].cboCuentaGasto.options[" & intIndiceCombo & "] = ")
                strcboCuentaGasto.Append("new Option(""" & clsCommons.strFormatearDescripcion(strRegistroCuentaGasto(1)).ToString & " - " & clsCommons.strFormatearDescripcion(strRegistroCuentaGasto(2)).ToString & """,""" & clsCommons.strFormatearDescripcion(strRegistroCuentaGasto(0)).ToString & """);" & vbCrLf)

                ' Verificamos el departamento seleccionado

                If (intCuentaGastoId > 0) AndAlso (intCuentaGastoId = CInt(strRegistroCuentaGasto(0))) Then
                    strcboCuentaGasto.Append("document.forms[0].cboCuentaGasto.options[" & intIndiceCombo & "].selected = true;" & vbCrLf)
                End If

                intIndiceCombo += 1

            Next

        End If

        Return strcboCuentaGasto.ToString

    End Function

    '====================================================================
    ' Name       : strRecordBrowserTrasferenciaInternaHTML
    ' Description: Genera el Record Browser con los articulo de la Transferencia
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserTrasferenciaInternaHTML() As String

        ' Declaracion de Variables
        Dim objArrayTransferenciaInterna As Array
        Dim strRegistroTransferenciaInterna As String()

        Dim strTransferenciaInternaHTML As StringBuilder
        Dim intConsecutivo As Integer
        Dim strColorRegistro As String

        'Inicializamos variables
        objArrayTransferenciaInterna = Nothing
        strRegistroTransferenciaInterna = Nothing

        strTransferenciaInternaHTML = New StringBuilder
        intConsecutivo = 0

        'Obtenemos los Articulos Capturados en la transferencia
        objArrayTransferenciaInterna = clsConcentrador.clsSucursal.clsTransferencia.strBuscarDetalle(intTransferenciaInternaFolioId, 0, 0, strCadenaConexion)

        If IsArray(objArrayTransferenciaInterna) AndAlso objArrayTransferenciaInterna.Length > 0 Then
            Call strTransferenciaInternaHTML.Append("<div id='ToPrintHtmContenido'>")
            Call strTransferenciaInternaHTML.Append("<table cellspacing='0' cellpadding='0' width='583' border='0'>")
            Call strTransferenciaInternaHTML.Append("<tr class='trtitulos'>")
            Call strTransferenciaInternaHTML.Append("<th width='78'  class='rayita'>C&oacute;digo</th>")
            Call strTransferenciaInternaHTML.Append("<th width='202' class='rayita'>Descripci&oacute;n</th>")
            Call strTransferenciaInternaHTML.Append("<th width='80'  class='rayita'>Cantidad</th>")
            Call strTransferenciaInternaHTML.Append("<th width='98'  class='rayita'>P. unitario</th>")
            Call strTransferenciaInternaHTML.Append("<th class='rayita' width='129' align='center'>Acción</th></tr>")

            intConsecutivo += 1
            intTotalCantidad = 0
            For Each strRegistroTransferenciaInterna In objArrayTransferenciaInterna
                If (intConsecutivo Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If

                intTotalCantidad += CInt(strRegistroTransferenciaInterna(1))

                'Pintado de cada Registro
                Call strTransferenciaInternaHTML.Append("<tr>")
                Call strTransferenciaInternaHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroTransferenciaInterna(0)).ToString & "</td>")           'intArticuloId
                Call strTransferenciaInternaHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroTransferenciaInterna(3)).ToString & "</td>")           'strDescripcion
                Call strTransferenciaInternaHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroTransferenciaInterna(1)).ToString & "</td>")           'intCantidadId
                Call strTransferenciaInternaHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroTransferenciaInterna(2)).ToString & "</td>")           'fltPrecioUnitario

                Call strTransferenciaInternaHTML.Append("<td class=" & strColorRegistro & " align='center'>")
                Call strTransferenciaInternaHTML.Append("<a href='MercanciaCapturarTransferenciaInterna.aspx?strCmd=Borrar&intTipoTransferenciaInterna=" & intTipoTransferenciaInterna.ToString & "&dtmTransferencia=" & dtmFechaTransferencia.ToString & "&intDeptoSurtidorId=" & intDepartamentoSurtidorId.ToString & "&intDeptoReceptorId=" & intDepartamentoReceptorId.ToString & "&intCuentaGastoId=" & intCuentaGastoId.ToString & "&txtArticuloId=" & clsCommons.strFormatearDescripcion(strRegistroTransferenciaInterna(0)).ToString & "&txtTransferenciaInternaFolioId=" & intTransferenciaInternaFolioId.ToString & " '>")
                Call strTransferenciaInternaHTML.Append("<img src='../static/images/imgNRborrar.gif' border='0' align='absmiddle'></a></td>")
                Call strTransferenciaInternaHTML.Append("</tr>")
                intConsecutivo += 1
            Next

            Call strTransferenciaInternaHTML.Append("</table>")
            Call strTransferenciaInternaHTML.Append("</div>")

            Call strTransferenciaInternaHTML.Append("<br>")
            Call strTransferenciaInternaHTML.Append("<table width='98%' border='0' cellpadding='0' cellspacing='0'>")
            Call strTransferenciaInternaHTML.Append("<tr>")
            Call strTransferenciaInternaHTML.Append("<td width='276'><input name='cmdCancelar' type='button' class='boton' value='Cancelar' onclick='return cmdCancelar_onclick()'>&nbsp;&nbsp;</td>")
            Call strTransferenciaInternaHTML.Append("<td width='281' align='center' bgcolor='#f4f6f8' class='tdenvolventeazul'>")
            Call strTransferenciaInternaHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            Call strTransferenciaInternaHTML.Append("<tr>")
            Call strTransferenciaInternaHTML.Append("<td width='170' class='tdtittablas'>Cifra de control</td>")
            Call strTransferenciaInternaHTML.Append("<td width='144' rowspan='2' align='right'><input name='cmdRegistrar' type='button' class='boton' value='Registrar' onclick='return cmdRegistrar_onclick()'></td>")
            Call strTransferenciaInternaHTML.Append("</tr>")
            Call strTransferenciaInternaHTML.Append("<tr>")
            Call strTransferenciaInternaHTML.Append("<td height='30' valign='top'><input name='txtCifra' type='text' class='campotabla' size='16' maxlength='4'>")
            Call strTransferenciaInternaHTML.Append("</td>")
            Call strTransferenciaInternaHTML.Append("</tr>")
            Call strTransferenciaInternaHTML.Append("</table>")
            Call strTransferenciaInternaHTML.Append("</td>")
            Call strTransferenciaInternaHTML.Append("</tr>")
            Call strTransferenciaInternaHTML.Append("</table>")
            Call strTransferenciaInternaHTML.Append("<input type=hidden name='hdnTotalCantidad' value=" & intTotalCantidad.ToString & ">")

            Call strTransferenciaInternaHTML.Append("<script language='javascript'>document.forms[0].txtArticuloId.focus();" & "</script>")

            strRecordBrowserTrasferenciaInternaHTML = strTransferenciaInternaHTML.ToString

        End If

    End Function

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
    ' Name       : strRecordBrowserHTML
    ' Description: RecordBrowser de Recibos
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRecordBrowserHTML() As String
        Get
            Return strmRecordBrowserHTML
        End Get
        Set(ByVal Value As String)
            strmRecordBrowserHTML = Value
        End Set

    End Property

    '====================================================================
    ' Name       : strRegistrosRecordBrowser
    ' Description: Registros en el RecordBrowser
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public ReadOnly Property strRegistrosRecordBrowser() As String
        Get
            If Len(strRecordBrowserHTML) > 0 Then
                Return strRecordBrowserHTML.Length.ToString
            Else
                Return ""
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
    ' Name       : strArticuloInternoDescripcion
    ' Description: Codigo de Articulo Interno
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strArticuloInternoDescripcion() As String
        Get
            Return strmArticuloInternoDescripcion
        End Get
        Set(ByVal Value As String)
            strmArticuloInternoDescripcion = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strErrorArticuloId
    ' Description: Numero de Emisor Nuevo
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strErrorArticuloId() As String
        Get
            Dim strError As String = "0"

            If Len(intArticuloCapturadoId) > 0 Then
                If IsNumeric(intArticuloCapturadoId) Then
                    If CDbl(intArticuloCapturadoId) > 0 Then
                        If Len(strBuscarDescripcionArticuloId(intArticuloCapturadoId)) = 0 Then
                            strError = "1"
                        End If
                    End If
                End If
            End If
            Return strError
        End Get
    End Property

    '====================================================================
    ' Name       : strBuscarDescripcionArticuloId
    ' Description: Consulta la descripcion del Articulo
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Function strBuscarDescripcionArticuloId(ByVal intNumeroArticuloId As String) As String
        Dim objDescripcionArt As Array = Nothing
        Dim strDescripcionArt As String() = Nothing
        Dim strNombreArticulo As String = ""

        If CDbl(intNumeroArticuloId) > 0 Then

            objDescripcionArt = clsConcentrador.clsSucursal.strBuscarArticulo(intCompaniaId, intSucursalId, intNumeroArticuloId, 0, 0, strCadenaConexion)

            If IsArray(objDescripcionArt) AndAlso objDescripcionArt.Length > 0 Then
                ' Obtenemos la descripcion del Articulo 
                strDescripcionArt = DirectCast(objDescripcionArt.GetValue(0), String())
                intArticuloInternoId = strDescripcionArt(0)
                strArticuloInternoDescripcion = clsCommons.strFormatearDescripcion(strDescripcionArt(5)).ToString
                strNombreArticulo = clsCommons.strFormatearDescripcion(strDescripcionArt(5)).ToString
                intDepartamentoArticuloInterno = CInt(strDescripcionArt(6).ToString)
            End If
        End If

        Return strNombreArticulo

    End Function

    '====================================================================
    ' Name       : intTransferenciaInternaFolioId
    ' Description: Folio de la Transferencia Interna Capturada
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intTransferenciaInternaFolioId() As Integer
        Get
            Return intmTransferenciaInternaFolioId
        End Get

        Set(ByVal Value As Integer)
            intmTransferenciaInternaFolioId = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strCantidad
    ' Description: Cantidad del Articulo
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCantidad() As String
        Get
            If Request.Form("txtCantidad") <> "" Then
                Return Trim(Request.Form("txtCantidad"))
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intTotalCantidad
    ' Description: Total de  articulos
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intTotalCantidad() As Integer
        Get
            Return intmTotalCantidad
        End Get
        Set(ByVal Value As Integer)
            intmTotalCantidad = Value
        End Set
    End Property


    '====================================================================
    ' Name       : strCmd
    ' Description: Identificador del comando a realizar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Request.QueryString("strCmd") <> "" Then
                Return Request.QueryString("strCmd")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intTipoTransferenciaInterna
    ' Description: Tipo de Transferencia Interna
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intTipoTransferenciaInterna() As String
        Get
            If Not IsNothing(Request.QueryString("intTipoTransferenciaInterna")) Then
                Return Request.QueryString("intTipoTransferenciaInterna")
            Else
                Return "1"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaTransferencia
    ' Description: Tipo de Señalizacion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property dtmFechaTransferencia() As String
        Get
            If Not IsNothing(Request.QueryString("dtmTransferencia")) Then
                Return Request.QueryString("dtmTransferencia")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intDepartamentoSurtidorId
    ' Description: Departamento Surtidor de la Transferencia
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDepartamentoSurtidorId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intDeptoSurtidorId")) Then
                Return CInt(Request.QueryString("intDeptoSurtidorId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intDepartamentoSurtidorId
    ' Description: Departamento Receptor de la Transferencia
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDepartamentoReceptorId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intDeptoReceptorId")) Then
                Return CInt(Request.QueryString("intDeptoReceptorId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intCuentaGastoId
    ' Description: Departamento Surtidor de la Transferencia
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCuentaGastoId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intCuentaGastoId")) Then
                Return CInt(Request.QueryString("intCuentaGastoId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intArticuloCapturadoId
    ' Description: Articulo a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intArticuloCapturadoId() As String
        Get
            If Not IsNothing(Request.QueryString("txtArticuloId")) Then
                Return Request.QueryString("txtArticuloId")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : txtTransferenciaInternaFolioId
    ' Description: Folio de la transferencia Interna
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property txtTransferenciaInternaFolioId() As String
        Get
            If Not IsNothing(Request.QueryString("txtTransferenciaInternaFolioId")) Then
                Return (Request.QueryString("txtTransferenciaInternaFolioId"))
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intDepartamentoArticuloInterno
    ' Description: Departamento del articulo Capturado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intDepartamentoArticuloInterno() As Integer
        Get
            Return intmDepartamentoArticuloInterno
        End Get
        Set(ByVal Value As Integer)
            intmDepartamentoArticuloInterno = Value
        End Set
    End Property


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        ' inicializamos el Record Browser 
        strRecordBrowserHTML = ""

        If intTransferenciaInternaFolioId < 1 Then
            intTransferenciaInternaFolioId = CInt(txtTransferenciaInternaFolioId)
        End If

        If strErrorArticuloId = "1" Then
            strMensaje = "Articulo no encontrado"
        End If

        If strCmd = "Consultar" Then
            Dim strResponde As String = ""
            Dim strCodigoError As Integer = 0

            If strErrorArticuloId = "0" Then
                If intDepartamentoArticuloInterno <> intDepartamentoSurtidorId Then
                    strCodigoError = -100
                End If
                strResponde = " <script language=Javascript>" & _
                               "parent.fnUpdArticuloPorIframe('" & intArticuloInternoId.ToString & "','" & _
                                                                strArticuloInternoDescripcion & "','" & _
                                                                strCodigoError & "')" & _
                                                                "</script>"
            Else
                strCodigoError = -1
                strResponde = " <script language=Javascript>" & _
                "parent.fnUpdArticuloPorIframe('" & intArticuloInternoId.ToString & "','" & _
                                                                strArticuloInternoDescripcion & "','" & _
                                                                strCodigoError & "')" & _
                                                                "</script>"
            End If

            Response.Write(strResponde)
            Response.End()

        End If

        If strErrorArticuloId = "0" AndAlso strCmd = "Agregar" Then

            If intTransferenciaInternaFolioId = 0 Then
                Dim intEsConsumo As Integer = 0

                If intTipoTransferenciaInterna = "1" Then
                    intEsConsumo = 1
                End If

                intTransferenciaInternaFolioId = clstblTransferenciaInterna.intAgregar(0, intDepartamentoSurtidorId, intCompaniaId, intSucursalId, intDepartamentoReceptorId, intCuentaGastoId, 0, CByte(intEsConsumo), CDate(clsCommons.strDMYtoMDY(dtmFechaTransferencia)), CDate("01/01/1900"), strUsuarioNombre, strCadenaConexion)

                If intTransferenciaInternaFolioId = 0 Then
                    strMensaje = "Error al agregar Folio de Transferencia Interna"
                End If

            End If

            If intTransferenciaInternaFolioId > 0 Then

                Dim intRegistroTransferenciaInterna As Integer = 0

                intRegistroTransferenciaInterna = clsConcentrador.clsSucursal.clsTransferencia.intAgregarArticulo(intCompaniaId, intSucursalId, intTransferenciaInternaFolioId, CInt(intArticuloInternoId), CInt(strCantidad), strUsuarioNombre, strCadenaConexion)

                If intRegistroTransferenciaInterna = 0 Then
                    strMensaje = "No pudo registrarse codigo en la lista"
                Else
                    intArticuloInternoId = ""
                    strArticuloInternoDescripcion = ""
                End If

            End If

        End If

        If strErrorArticuloId = "0" AndAlso strCmd = "Borrar" Then

            Dim intRegistroTransferenciaInterna As Integer = 0

            intRegistroTransferenciaInterna = clstblArticuloTransferenciaInterna.intEliminar(intTransferenciaInternaFolioId, CInt(intArticuloInternoId), 0, 0, CDate("01/01/1900"), "", strCadenaConexion)

            If intRegistroTransferenciaInterna = 0 Then
                strMensaje = "No pudo borrarse código de la lista " & intTransferenciaInternaFolioId.ToString & " " & intArticuloInternoId
            End If

        End If


        If strCmd = "Cancelar" Then

            Dim intRegistroTransferenciaInterna As Integer = 0

            intRegistroTransferenciaInterna = clsConcentrador.clsSucursal.clsTransferencia.intEliminar(intCompaniaId, intSucursalId, intTransferenciaInternaFolioId, strCadenaConexion)

            If intRegistroTransferenciaInterna < 0 Then
                strMensaje = "Error al cancelar lista"
            End If

            intRegistroTransferenciaInterna = 0
            intTransferenciaInternaFolioId = 0
        End If

        If strCmd = "Registrar" AndAlso intTransferenciaInternaFolioId > 0 Then
            Dim intRegistroTransferenciaInterna As Integer = 0
            Dim objArrayTransferenciaInterna As Array = Nothing

            'Obtenemos los Articulos capturados para verificar si realmente hay detalle

            objArrayTransferenciaInterna = clsConcentrador.clsSucursal.clsTransferencia.strBuscarDetalle(intTransferenciaInternaFolioId, 0, 0, strCadenaConexion)

            If IsArray(objArrayTransferenciaInterna) AndAlso objArrayTransferenciaInterna.Length > 0 Then

                intRegistroTransferenciaInterna = clsConcentrador.clsSucursal.clsTransferencia.intRegistrar(intCompaniaId, intSucursalId, intTransferenciaInternaFolioId, strUsuarioNombre, strCadenaConexion)

                If intRegistroTransferenciaInterna < 0 Then
                    strMensaje = "Error al Registrar Transferencia Interna"
                Else
                    intTransferenciaInternaFolioId = 0
                    strMensaje = "Transferencia Registrado Folio: " & intRegistroTransferenciaInterna.ToString
                End If

            End If

        End If

        ' inicializamos el Record Browser 
        strRecordBrowserHTML = ""

        strRecordBrowserHTML = strRecordBrowserTrasferenciaInternaHTML()


    End Sub

End Class
