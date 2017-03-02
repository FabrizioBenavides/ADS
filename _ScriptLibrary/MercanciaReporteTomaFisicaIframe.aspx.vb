Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration

Public Class clsMercanciaReporteTomaFisicaIframe
    Inherits System.Web.UI.Page
    Public strGeneraTablaHTML As String
    Public intmNoHoja As Integer = 0

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
            If Not IsNothing(Trim(Request("strCmd"))) Then
                Return Trim(Request("strCmd"))
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
    ' Name       : strAyer
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strAyer() As String
        Get
            Dim dtmTemporal As Date
            dtmTemporal = CDate(clsCommons.strGetCustomDateTime("MM/dd/yyyy"))
            dtmTemporal = dtmTemporal.AddDays(-1)
            Return dtmTemporal.ToString("dd/MM/yyyy")
        End Get
    End Property
    '====================================================================
    ' Name       : strAyerNombreDia
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strAyerNombreDia() As String
        Get
            Dim dtmTemporal As Date
            dtmTemporal = CDate(clsCommons.strGetCustomDateTime("MM/dd/yyyy"))
            dtmTemporal = dtmTemporal.AddDays(-1)
            Return clsCommons.strNombreDia(dtmTemporal)
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

        Dim intPlanoId As Integer
        Dim objArray As Array = Nothing
        Dim intInicio As Integer = 0
        Dim arrIntPlanoId As Array = Nothing
        Dim strFechaConsulta As String = ""

        Dim i As Integer

        If LCase(strCmd).Equals("imprimir") Then
            arrIntPlanoId = Split(Request.QueryString("intPlanoId"), ",")
            strFechaConsulta = Request.QueryString("dtmFechaConsulta")

            strGeneraTablaHTML = ""
            For i = 0 To (arrIntPlanoId.Length - 1)
                intPlanoId = CInt(arrIntPlanoId.GetValue(i))
                intInicio = 0
                objArray = Nothing


                objArray = clsConcentrador.clsPlanograma.strBuscarDetalleTomaFisica(intCompaniaId, intSucursalId, intPlanoId, CDate(clsCommons.strDMYtoMDY(strFechaConsulta)), 0, 0, strCadenaConexion)

                strGeneraTablaHTML += strGeneraTabla(objArray, intInicio)
            Next
        End If

    End Sub
    Private Function strGeneraTabla(ByVal objArray As Array, _
                                  ByRef intConsecutivo As Integer _
                                  ) As String
        Dim strHTML As StringBuilder
        Dim strRegistro As String()
        strRegistro = Nothing
        Dim intRenglon As Integer
        Dim dblTotal As Double
        Dim strClass As String
        Dim strComilla As String
        Dim strReadonly As String
        Dim strDia As String
        Dim strFecha As String
        Dim strHoy As String
        Dim intRegistros As Integer

        strComilla = """"

        strHTML = New StringBuilder
        strHTML.Append("")

        strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        '------------------------
        intRenglon = 0
        intRegistros = objArray.Length
        If IsArray(objArray) AndAlso (objArray.Length > 0) Then
            For Each strRegistro In objArray

                If intRenglon = 0 OrElse (intRenglon Mod 32 = 0) Then '32 NumeroPermitido de renglones
                    intmNoHoja = intmNoHoja + 1
                    strHoy = clsCommons.strGetCustomDateTime("dd/MM/yyyy")
                    strFecha = clsCommons.strFormatearFechaPresentacion(strRegistro(0))
                    strDia = clsCommons.strNombreDia(CDate(clsCommons.strDMYtoMDY(clsCommons.strFormatearFechaPresentacion(strRegistro(0)))))
                    If intRenglon > 0 Then
                        'Cifra de Control
                        strHTML.Append("</tr>")
                        strHTML.Append("<td class='" & strClass & "' nowrap>" & "&nbsp;</td>")
                        strHTML.Append("<td class='" & strClass & "'>" & "&nbsp;</td>")
                        strHTML.Append("<td nowrap class='" & strClass & "'>" & "&nbsp;</td>")
                        strHTML.Append("<td class='" & strClass & "'>" & "&nbsp;</td>")
                        strHTML.Append("<td class='" & strClass & "'>" & "&nbsp;</td>")
                        strHTML.Append("<td class='" & strClass & "'>" & "&nbsp;</td>")
                        strHTML.Append("<td class='" & strClass & "'>" & "&nbsp;</td>")
                        strHTML.Append("<td colspan=3 align='right' class='" & strClass & "'>" & "Cifra de Control&nbsp;</td>")
                        strHTML.Append("<td class='" & strClass & "'>" & "" & "_______</td>")
                        strHTML.Append("<td class='" & strClass & "'>" & "" & "&nbsp;</td>")
                        strHTML.Append("<td class='" & strClass & "'>" & "&nbsp;</td>")
                        strHTML.Append("</tr>")
                    End If
                    strHTML.Append(subImprimeEncabezado(clsCommons.strFormatearDescripcion(strRegistro(3).ToString), strRegistro(2), strDia, "Listado para Toma Fisica", strFecha, strHoy, "Organización Benavides", CStr(intmNoHoja), clsCommons.strFormatearDescripcion(strRegistro(4).ToString)))
                End If

                intConsecutivo += 1
                intRenglon += 1
                If ((intRenglon Mod 2) = 0) Or (intRenglon = 0) Then
                    strClass = "tdblancoSinRaya" 'tdceleste
                Else
                    strClass = "tdblancoSinRaya" 'tdblanco
                End If
                strHTML.Append("<tr>")

                '0 dtmPlanoSucursalSiguienteCaptura                       
                '1 intPlanoSucursalDiaSiguienteCaptura 
                '2 intPlanoId  
                '3 strPlanoNombre                                     
                '4 strArticuloPlanoCharolaId                          
                '5 intArticuloId 
                '6 strArticuloDescripcion                                                                                                                                                                                                                                          
                '7 strClaveVigenciaArticuloNombre                                                                                                                                                                                                                                   
                '8 intArticuloSucursalExistenciaIdeal 
                '9 intArticuloSucursalExistenciaTeorica 
                '10 fltArticuloSucursalPrecioTransferencia 
                '11 fltArticuloSucursalPrecioNormalSinImpuesto 
                '12 fltArticuloSucursalVentaTrimestralRegistrada 
                '13 fltArticuloSucursalVentaMensualRegistrada 
                '14 fltArticuloSucursalVentaSemanalRegistrada 
                '15 intArticuloSucursalDiasInventario

                'Columna 1  
                strHTML.Append("<td class='" & strClass & "' nowrap>" & intConsecutivo.ToString & "&nbsp;</td>")

                'Columna 2  intArticuloId
                strHTML.Append("<td class='" & strClass & "'>" & strRegistro(5) & "&nbsp;</td>")

                'Columna 3  strArticuloDescripcion
                strHTML.Append("<td nowrap class='" & strClass & "'>" & clsCommons.strFormatearDescripcion(strRegistro(6).ToString) & "&nbsp;</td>")

                'Columna 4  strClaveVigenciaArticuloNombre
                strHTML.Append("<td class='" & strClass & "'>" & clsCommons.strFormatearDescripcion(strRegistro(7).ToString) & "&nbsp;</td>")

                'Columna 5  intArticuloSucursalDiasInventario
                strHTML.Append("<td class='" & strClass & "'>" & strRegistro(15) & "&nbsp;</td>")

                'Columna 6  fltArticuloSucursalVentaTrimestralRegistrada
                strHTML.Append("<td class='" & strClass & "'>" & strRegistro(12) & "&nbsp;</td>")

                'Columna 7  fltArticuloSucursalVentaMensualRegistrada
                strHTML.Append("<td class='" & strClass & "'>" & strRegistro(13) & "&nbsp;</td>")

                'Columna 8  fltArticuloSucursalVentaSemanalRegistrada
                strHTML.Append("<td class='" & strClass & "'>" & strRegistro(14) & "&nbsp;</td>")

                'Columna 9  intArticuloSucursalExistenciaTeorica
                strHTML.Append("<td class='" & strClass & "'>" & strRegistro(9) & "&nbsp;</td>")

                'Columna 10  intArticuloSucursalExistenciaIdeal
                strHTML.Append("<td class='" & strClass & "'>" & strRegistro(8) & "</td>")

                If strRegistro(18) = "1" Then
                    'Columna 11
                    strHTML.Append("<td class='" & strClass & "'>" & "" & "*******</td>")

                    'Columna 12
                    strHTML.Append("<td class='" & strClass & "'>" & "" & "*******</td>")
                Else
                    'Columna 11
                    strHTML.Append("<td class='" & strClass & "'>" & "" & "_______</td>")

                    'Columna 12
                    strHTML.Append("<td class='" & strClass & "'>" & "" & "_______</td>")
                End If


                'Columna 13
                strHTML.Append("<td class='" & strClass & "'>" & "&nbsp;</td>")


                strHTML.Append("</tr>")
            Next

        End If
        '------------------------

        If intRenglon > 0 AndAlso (intRegistros = intRenglon) Then
            'Cifra de Control
            strHTML.Append("</tr>")
            strHTML.Append("<td class='" & strClass & "' nowrap>" & "&nbsp;</td>")
            strHTML.Append("<td class='" & strClass & "'>" & "&nbsp;</td>")
            strHTML.Append("<td nowrap class='" & strClass & "'>" & "&nbsp;</td>")
            strHTML.Append("<td class='" & strClass & "'>" & "&nbsp;</td>")
            strHTML.Append("<td class='" & strClass & "'>" & "&nbsp;</td>")
            strHTML.Append("<td class='" & strClass & "'>" & "&nbsp;</td>")
            strHTML.Append("<td class='" & strClass & "'>" & "&nbsp;</td>")
            strHTML.Append("<td colspan=3 align='right' class='" & strClass & "'>" & "Cifra de Control&nbsp;</td>")
            strHTML.Append("<td class='" & strClass & "'>" & "" & "_______</td>")
            strHTML.Append("<td class='" & strClass & "'>" & "" & "&nbsp;</td>")
            strHTML.Append("<td class='" & strClass & "'>" & "&nbsp;</td>")
            strHTML.Append("</tr>")
        End If

        strHTML.Append("</table>")
        strHTML.Append("<input type=hidden name=hdnTotalDePartidas value=" & intRenglon.ToString & ">")
        strGeneraTabla = clsCommons.strGenerateJavascriptString(strHTML.ToString)
    End Function
    Function subImprimeEncabezado(ByVal strPlanoNombre As String, _
                                  ByVal strPlanoId As String, _
                                  ByVal strDia As String, _
                                  ByVal strTitulo2 As String, _
                                  ByVal strFecha As String, _
                                  ByVal strHoy As String, _
                                  ByVal strTitulo1 As String, _
                                  ByVal strNoHoja As String, _
                                  ByVal strCharolaId As String _
                                  ) As String
        Dim strHtmlEncabezado As StringBuilder

        strHtmlEncabezado = New StringBuilder

        If (Trim(strNoHoja)).Equals("1") Then
            strHtmlEncabezado.Append("")
        Else
            strHtmlEncabezado.Append("<tr><td><P class='breakhere'></P></td></tr>")
        End If




        ' strHoy   strTitulo1 strNoHoja
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th width='41'  class='tdblancoSinRaya'>" & " " & "</th>")
        strHtmlEncabezado.Append("<th align=left colspan=4  class='tdblancoSinRaya'>" & strHoy & " Modificado</th>")

        strHtmlEncabezado.Append("<th align=center colspan=3  class='tdblancoSinRaya' nowrap>" & strTitulo1 & "</th>")

        strHtmlEncabezado.Append("<th align=right colspan=4  class='tdblancoSinRaya'>HOJA " & strNoHoja & "</th>")
        strHtmlEncabezado.Append("<th width='31'  class='tdblancoSinRaya'>" & " " & "</th>")
        strHtmlEncabezado.Append("</tr>")


        'Titulo y Fecha
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th align=center colspan=13  class='tdblancoSinRaya'>" & strTitulo2 & "&nbsp;&nbsp;&nbsp;&nbsp;" & strFecha & "</th>")
        strHtmlEncabezado.Append("</tr>")

        ' strPlanoId    strDia    strHora
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th width='41'  class='tdblancoSinRaya'>" & " " & "</th>")
        strHtmlEncabezado.Append("<th align=left colspan=4  class='tdblancoSinRaya'>Plano " & strPlanoId & "</th>")

        strHtmlEncabezado.Append("<th align=center colspan=3  class='tdblancoSinRaya'>Dia : " & strDia & "</th>")

        strHtmlEncabezado.Append("<th align=right colspan=4  class='tdblancoSinRaya'>Hora : ___ : ___ </th>")
        strHtmlEncabezado.Append("<th width='31'  class='tdblancoSinRaya'>" & " " & "</th>")
        strHtmlEncabezado.Append("</tr>")

        '3 strPlanoNombre
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th width='41'  class='tdblancoSinRaya'>" & " " & "</th>")
        strHtmlEncabezado.Append("<th align=left colspan=12  class='tdblancoSinRaya'>" & strPlanoNombre & "</th>")
        strHtmlEncabezado.Append("</tr>")

        'Ventas
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th align=center colspan=5  class='tdblancoSinRaya'>" & "" & "</th>")
        strHtmlEncabezado.Append("<th align=center colspan=3  class='tdblancoSinRaya'>" & "Ventas" & "</th>")
        strHtmlEncabezado.Append("<th align=center colspan=5  class='tdblancoSinRaya'>" & "" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        'Titulos
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th width='41'  class='tdblancoSinRaya'>" & "" & "&nbsp;</th>")
        strHtmlEncabezado.Append("<th width='61'  class='tdblancoSinRaya'>" & "Código" & "</th>")
        strHtmlEncabezado.Append("<th width='61'  class='tdblancoSinRaya'>" & "Descripción" & "</th>")
        strHtmlEncabezado.Append("<th width='61'  class='tdblancoSinRaya'>" & "Vig" & "</th>")
        strHtmlEncabezado.Append("<th width='61'  class='tdblancoSinRaya'>" & "DInv" & "</th>")
        strHtmlEncabezado.Append("<th width='61'  class='tdblancoSinRaya'>" & "3Mes" & "</th>")
        strHtmlEncabezado.Append("<th width='61'  class='tdblancoSinRaya'>" & "1Mes" & "</th>")
        strHtmlEncabezado.Append("<th width='61'  class='tdblancoSinRaya'>" & "1Sem" & "</th>")
        strHtmlEncabezado.Append("<th width='61'  class='tdblancoSinRaya'>" & "Teo" & "</th>")
        strHtmlEncabezado.Append("<th width='61'  class='tdblancoSinRaya'>" & "Stock" & "</th>")
        strHtmlEncabezado.Append("<th width='61'  class='tdblancoSinRaya'>" & "E.Fisica" & "</th>")
        strHtmlEncabezado.Append("<th width='61'  class='tdblancoSinRaya'>" & "Pedido" & "</th>")
        strHtmlEncabezado.Append("<th width='31'  class='tdblancoSinRaya'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th width='41'  class='rayita'>" & "" & "&nbsp;</th>")
        strHtmlEncabezado.Append("<th width='61'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='61'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='61'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='61'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='61'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='61'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='61'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='61'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='61'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='61'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='61'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='31'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        'Charola Sola
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th colspan='13' class='tdblancoSinRaya' nowrap>" & "Charola  " & Trim(strCharolaId) & "</th>")
        strHtmlEncabezado.Append("</tr>")

        subImprimeEncabezado = strHtmlEncabezado.ToString
    End Function
End Class
