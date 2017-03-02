Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Business.clsConcentrador
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class popPedidoVentaCatalogoClienteAlta
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

    Dim strComitasDobles As String = """"

    Private strmSucursalCalle As String
    Private strmSucursalNoExterior As String
    Private strmSucursalNoInterior As String
    Private strmSucursalColonia As String
    Private strmSucursalCiudad As String
    Private strmSucursalEstado As String
    Private strmSucursalCodigoPostal As String

    Private intmClienteEncontrado As Integer


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
    ' Name       : strCboEstado
    ' Description: Generamos combo de los estados
    ' Parameters : strNombreObjeto 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strCboEstado(ByVal strNombreObjeto As String) As String

        Dim objDataArray As Array
        Dim objRegistro As String()
        Dim intPaisId As Integer = 1
        Dim strHTML As StringBuilder
        Dim intContador As Integer = 0

        ' Buscamos los Estados
        objDataArray = clstblEstado.strBuscar(0, intPaisId, "", CDate("01/01/1900"), "", 0, 0, strCadenaConexion)

        ' Validamos que sea un arreglo
        If IsArray(objDataArray) AndAlso objDataArray.Length > 0 Then

            strHTML = New StringBuilder
            strHTML.Append("")

            strHTML.Append("document.forms[0].elements['" & strNombreObjeto & "'].options[" & intContador & "] = new Option(""" & "Seleccione un Estado" & """,""" & "-1" & """);" & vbCrLf)

            intContador += 1

            For Each objRegistro In objDataArray

                strHTML.Append("document.forms[0].elements['" & strNombreObjeto & "'].options[" & intContador & "] = new Option(""" & clsCommons.strFormatearDescripcion(objRegistro(2)) & """,""" & objRegistro(0) & """);" & vbCrLf)

                If CInt(Request.Form(strNombreObjeto)) = CInt(objRegistro(0)) Then
                    strHTML.Append("document.forms[0].elements['" & strNombreObjeto & "'].options[" & intContador & "].selected=true;" & vbCrLf)
                End If

                intContador += 1

            Next

        End If

        Return strHTML.ToString

    End Function

    '====================================================================
    ' Name       : strRFCCapturado
    ' Description: Obtenemos el RFC Capturado
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRFCCapturado() As String
        Get
            Return Request("txtRFC")
        End Get
    End Property

    '====================================================================
    ' Name       : strRazonSocialCapturada
    ' Description: Obtenemos la RazonSocial Capturada
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRazonSocialCapturada() As String
        Get
            Return Request("txtRazonSocial")
        End Get
    End Property

    Public Property intClienteEncontrado() As Integer
        Get
            Return (intmClienteEncontrado)
        End Get
        Set(ByVal Value As Integer)
            intmClienteEncontrado = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowserClienteFiscal
    ' Description:  
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Function strRecordBrowserClienteFiscal() As String
        Dim objDataArray As Array = Nothing
        Dim objRegistro As String() = Nothing

        Dim strHTML As StringBuilder
        Dim intConsecutivo As Integer = 0
        Dim strColorRegistro As String

        Dim intBuscarRazonSocial As Integer = 0
        Dim strBuscarCliente As String = ""

        Dim strColumnaValor As String = ""

        If Len(strRFCCapturado) > 0 Then
            ' Buscar por RFC
            intBuscarRazonSocial = 0
            strBuscarCliente = strRFCCapturado
        Else
            If Len(strRazonSocialCapturada) > 0 Then
                'Buscar por Razon social
                intBuscarRazonSocial = 1
                strBuscarCliente = strRazonSocialCapturada
            End If
        End If

        intClienteEncontrado = 0
        strHTML = New StringBuilder
        strHTML.Append("")

        objDataArray = clsClienteFiscal.strBuscar(intBuscarRazonSocial, strBuscarCliente, strCadenaConexion)

        If IsArray(objDataArray) AndAlso objDataArray.Length > 0 Then

            strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

            Call strHTML.Append("<tr class='trtitulos'>")
            Call strHTML.Append("<th width='05%' class='rayita'>RFC</th>")
            Call strHTML.Append("<th width='25%' class='rayita'>RAZON SOCIAL</th>")
            Call strHTML.Append("<th width='55%' class='rayita'>DIRECCION</th>")
            Call strHTML.Append("<th width='05%' class='rayita'>CP</th>")
            Call strHTML.Append("<th width='05%' class='rayita'>TELEFONO</th>")
            Call strHTML.Append("<th width='05%' class='rayita'>EMAIL</th>")
            Call strHTML.Append("</tr>")

            For Each objRegistro In objDataArray
                intConsecutivo += 1
                intClienteEncontrado += 1

                If (intConsecutivo Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If

                strHTML.Append("<tr>")
                strHTML.Append("<td class=" & strColorRegistro & ">")
                strHTML.Append("<a class='txaccion' href=\""javascript:cmdSeleccionarCliente('")
                strHTML.Append(objRegistro(0).ToString & "','")
                '1 strRFC
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(1).ToString).ToString & "','")
                '2 strRazonSocial
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(2).ToString).ToString & "','")
                '3 strCalle
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(3).ToString).ToString & "','")
                '4 strNoExterior
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(4).ToString).ToString & "','")
                '5 strNoInterior
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(5).ToString).ToString & "','")
                '6 strColonia
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(6).ToString).ToString & "','")
                '7 strCiudad
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(7).ToString).ToString & "','")
                '8 strEstado
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(8).ToString).ToString & "','")
                '9 strCodigoPostal
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(9).ToString).ToString & "','")
                '10 strTelefono
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(10).ToString).ToString & "','")
                '11 strEmail
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(11).ToString).ToString & "','")

                '12 strClienteFiscalDatoEntregaCalle
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(12).ToString).ToString & "','")
                '13 strClienteFiscalDatoEntregaNoExterior
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(13).ToString).ToString & "','")
                '14 strClienteFiscalDatoEntregaNoInterior
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(14).ToString).ToString & "','")
                '15 strClienteFiscalDatoEntregaEntreCalles
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(15).ToString).ToString & "','")
                '16 strClienteFiscalDatoEntregaColonia
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(16).ToString).ToString & "','")
                '17 intEntregaCiudadId
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(17).ToString).ToString & "','")
                '18 intEntregaEstadoId
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(18).ToString).ToString & "','")
                '19 strClienteFiscalDatoEntregaCodigoPostal
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(19).ToString).ToString & "','")
                '20 strClienteFiscalDatoEntregaTelefono
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(20).ToString).ToString & "','")
                '25 strClienteFiscalDatoEntregaMovil
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(25).ToString).ToString & "')\"">")

                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(1).ToString).ToString & " </a>")
                strHTML.Append("</td>")

                'strRazonSocial
                strHTML.Append("<td class=" & strColorRegistro & ">")
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(2)).ToString)
                strHTML.Append("</td>")

                'Direccion
                '  3 strClienteFiscalCalle, 
                '  4 strClienteFiscalNoExterior, 
                '  5 strClienteFiscalNoInterior, 
                '  6 strClienteFiscalColonia, 
                ' 22 strCiudadNombre
                ' 21 strEstadoNombre
                strHTML.Append("<td class=" & strColorRegistro & ">")
                strHTML.Append(clsCommons.strFormatearDescripcion(objRegistro(3)).ToString & "|" & _
                               clsCommons.strFormatearDescripcion(objRegistro(4)).ToString & "|" & _
                               clsCommons.strFormatearDescripcion(objRegistro(5)).ToString & "|" & _
                               clsCommons.strFormatearDescripcion(objRegistro(6)).ToString & "|" & _
                               clsCommons.strFormatearDescripcion(objRegistro(22)).ToString & "|" & _
                               clsCommons.strFormatearDescripcion(objRegistro(21)).ToString & " ")
                strHTML.Append("</td>")

                'CP
                If Len(clsCommons.strFormatearDescripcion(objRegistro(9)).ToString) > 0 Then
                    strColumnaValor = clsCommons.strFormatearDescripcion(objRegistro(9)).ToString
                Else
                    strColumnaValor = "&nbsp;"
                End If
                strHTML.Append("<td class=" & strColorRegistro & ">" & strColumnaValor & "</td>")

                'TELEFONO
                If Len(clsCommons.strFormatearDescripcion(objRegistro(10)).ToString) > 0 Then
                    strColumnaValor = clsCommons.strFormatearDescripcion(objRegistro(10)).ToString
                Else
                    strColumnaValor = "&nbsp;"
                End If
                strHTML.Append("<td class=" & strColorRegistro & ">" & strColumnaValor & "</td>")

                'EMAIL
                If Len(clsCommons.strFormatearDescripcion(objRegistro(11)).ToString) > 0 Then
                    strColumnaValor = clsCommons.strFormatearDescripcion(objRegistro(11)).ToString
                Else
                    strColumnaValor = "&nbsp;"
                End If
                strHTML.Append("<td class=" & strColorRegistro & ">" & strColumnaValor & "</td>")


                strHTML.Append("</tr>")
            Next

            strHTML.Append("</table>")

        End If

        Return strHTML.ToString

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here


        Dim objDataArray As Array = Nothing
        Dim objRegistro As String() = Nothing

        Dim strHTML As StringBuilder
        Dim strResponde As String = ""

        Select Case strCmd

            Case "BuscarCliente"

                strHTML = New StringBuilder
                Dim strRecordBrowser As String = strRecordBrowserClienteFiscal()

                strHTML.Append("<script language='Javascript'> parent.fnRecordBrowserCliente( " & _
                            strComitasDobles & intClienteEncontrado.ToString & strComitasDobles & "," & _
                            strComitasDobles & strRecordBrowser.ToString & strComitasDobles & _
                            "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "BuscarCiudad"

                Dim intEstadoId As Integer = 0
                Dim intContador As Integer = 0
                Dim strNombreComboEdo As String = ""
                Dim strNombreComboCd As String = ""
                Dim strNombretxtCd As String = ""

                strNombreComboEdo = Request("strNombreComboEdo")
                strNombreComboCd = Request("strNombreComboCd")
                strNombretxtCd = Request("strNombretxtCd")

                intEstadoId = CInt(Request("intEstadoId"))

                strHTML = New StringBuilder

                ' Buscamos las ciudades
                objDataArray = clstblCiudad.strBuscar(intEstadoId, 0, "", CDate("01/01/1900"), "", 0, 0, strCadenaConexion)

                If IsArray(objDataArray) AndAlso objDataArray.Length > 0 Then

                    strHTML.Append("parent.document.forms[0].elements[" & """" & strNombreComboCd & """" & "].options[" & intContador & "] = new Option(""" & "Seleccione una Ciudad" & """,""" & "-1" & """);" & vbCrLf)

                    intContador += 1
                    For Each objRegistro In objDataArray

                        strHTML.Append("parent.document.forms[0].elements[" & """" & strNombreComboCd & """" & "].options[" & intContador & "] = new Option(""" & clsCommons.strFormatearDescripcion(objRegistro(2)) & """,""" & objRegistro(1) & """);" & vbCrLf)

                        If IsNumeric(Request(strNombretxtCd)) Then

                            If CInt(Request(strNombretxtCd)) = CInt(objRegistro(1).ToString) Then
                                strHTML.Append("parent.document.forms[0].elements[" & """" & strNombreComboCd & """" & "].options[" & intContador & "].selected=true;" & vbCrLf)
                            End If

                        End If

                        intContador += 1
                    Next

                Else
                    strHTML.Append("parent.document.forms[0].elements[" & """" & strNombreComboCd & """" & "].options[" & intContador & "] = new Option(""" & "Seleccione una Ciudad" & """,""" & "-1" & """);" & vbCrLf)
                End If

                Call Response.Write("<script language='javascript'>parent.fnEliminaElementos('" & strNombreComboCd & "');" & strHTML.ToString & "</script>")
                Call Response.End()

            Case "ActualizarCliente"

                Dim intResultado As Integer = 0
                Dim intClienteFiscalId As Integer = 0
                Dim strlClienteFiscalRazonSocial As String = Trim(Request.Form("txtRazonSocial"))

                Dim strlClienteFiscalCalle As String = Trim(Request.Form("txtCalle"))
                Dim strlClienteFiscalNoExterior As String = Trim(Request.Form("txtNoExterior"))
                Dim strlClienteFiscalNoInterior As String = Trim(Request.Form("txtNoInterior"))
                Dim strlClienteFiscalColonia As String = Trim(Request.Form("txtColonia"))
                Dim strlCiudad As String = Trim(Request.Form("cboCiudad"))
                Dim strlEstado As String = Trim(Request.Form("cboEstado"))
                Dim strlClienteFiscalCodigoPostal As String = Trim(Request.Form("txtCodigoPostal"))
                Dim strlClienteFiscalTelefono As String = Trim(Request.Form("txtTelefono"))
                Dim strlClienteFiscalEMail As String = Trim(Request.Form("txtEMail"))
                Dim strlClienteFiscalDireccion As String = ""

                Dim strlClienteFiscalEntregaCalle As String = Trim(Request.Form("txtEntregaCalle"))
                Dim strlClienteFiscalEntregaNoExterior As String = Trim(Request.Form("txtEntregaNoExterior"))
                Dim strlClienteFiscalEntregaNoInterior As String = Trim(Request.Form("txtEntregaNoInterior"))
                Dim strlClienteFiscalEntregaEntreCalles As String = Trim(Request.Form("txtEntregaEntreCalles"))
                Dim strlClienteFiscalEntregaColonia As String = Trim(Request.Form("txtEntregaColonia"))
                Dim strlEntregaCiudad As String = Trim(Request.Form("cboEntregaCiudad"))
                Dim strlEntregaEstado As String = Trim(Request.Form("cboEntregaEstado"))
                Dim strlClienteFiscalEntregaCodigoPostal As String = Trim(Request.Form("txtEntregaCodigoPostal"))
                Dim strlClienteFiscalEntregaTelefono As String = Trim(Request.Form("txtEntregaTelefono"))
                Dim strlClienteFiscalEntregaMovil As String = Trim(Request.Form("txtEntregaMovil"))

                ' Se actualizara/agregar el registro
                intResultado = clsClienteFiscal.intActualizarAgregarClienteFiscal(strRFCCapturado, strlClienteFiscalRazonSocial, strlClienteFiscalCalle, strlClienteFiscalNoExterior, strlClienteFiscalNoInterior, strlClienteFiscalColonia, strlCiudad, strlEstado, strlClienteFiscalCodigoPostal, strlClienteFiscalTelefono, strlClienteFiscalEMail, strlClienteFiscalEntregaCalle, strlClienteFiscalEntregaNoExterior, strlClienteFiscalEntregaNoInterior, strlClienteFiscalEntregaEntreCalles, strlClienteFiscalEntregaColonia, CInt(strlEntregaCiudad), CInt(strlEntregaEstado), strlClienteFiscalEntregaCodigoPostal, strlClienteFiscalEntregaTelefono, strlClienteFiscalEntregaMovil, strUsuarioNombre, strCadenaConexion)

                If intResultado < 0 Then
                    intResultado = -100 ' Indica que hubo un error
                    intClienteFiscalId = 0
                Else
                    intClienteFiscalId = intResultado
                    intResultado = 1
                End If

                strResponde = "<script language=Javascript>" & _
                              "parent.fnAceptarClientePorIframe('" & intResultado.ToString & "', '" & intClienteFiscalId.ToString & "','" & strRFCCapturado & "','" & strlClienteFiscalRazonSocial & "');" & _
                              "</script>"
                Response.Write(strResponde)
                Response.End()

        End Select



    End Sub

End Class
