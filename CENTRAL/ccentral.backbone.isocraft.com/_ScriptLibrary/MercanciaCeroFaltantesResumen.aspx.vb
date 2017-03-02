Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration
Imports Benavides.CC.Data.clsPromociones
Imports Isocraft.Web.Http

Public Class MercanciaCeroFaltantesResumen
    Inherits System.Web.UI.Page

    Dim strmRecordBrowserHTML As String

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
    ' Name       : strCentroLogisticoId
    ' Description: Valor de la Compañia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCentroLogisticoId() As String
        Get
            Return (clsCommons.strReadCookie("strCentroLogisticoId", "", Request, Server))
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
    ' Description: Valor que tomara la variable strmCadenaConexion
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
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return GetPageParameter("strCmd", "")
        End Get
    End Property

    '====================================================================
    ' Name       : strImprimirTablaId
    ' Description: Tabla a imprimir o tipo de consulta (Resumen, Ceros, Factor)
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strImprimirTablaId() As String
        Get
            Return GetPageParameter("strImprimirTablaId", "0")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim strRecordBrowserImpresion As String = ""
        Const strComitasDobles As String = """"

        Select Case strCmd

            'Rutina para imprimir
            Case "Imprimir"

                Dim strHTML As New StringBuilder
                Dim objDataArrayCeroFaltantes As Array = Nothing

                'Resultados a mostrar en pantalla para Resumen
                objDataArrayCeroFaltantes = Benavides.CC.Data.clsCeroFaltante.strFaltanteCeroResumen(intSucursalId, intCompaniaId, CInt(strImprimirTablaId), strCadenaConexion)

                If IsArray(objDataArrayCeroFaltantes) AndAlso objDataArrayCeroFaltantes.Length > 0 Then

                    'Se envia la informacion a imprimir para darle formato de acuerdo a la tabla seleccionada por el usuario.  
                    Select Case strImprimirTablaId

                        Case "0" 'Resumen
                            strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strImpresionCeroFaltantes(objDataArrayCeroFaltantes))

                        Case "1" 'Ceros
                            strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strImpresionCeroFaltantesCeros(objDataArrayCeroFaltantes))

                        Case "2" 'Factor
                            strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strImpresionCeroFaltantesFactor(objDataArrayCeroFaltantes))

                    End Select

                    'Se ennvia a impresion.
                    strHTML.Append("<script language='Javascript'>parent.fnImprimir( " & _
                    strComitasDobles & strRecordBrowserImpresion.ToString & strComitasDobles & _
                    "); </script>")
                    Response.Write(strHTML.ToString)
                    Response.End()

                End If

        End Select

    End Sub

#Region "Resumen"
    Public Function strTablaConsultaCeroFaltantes() As String
        Dim objArray As System.Array = Nothing

        strmRecordBrowserHTML = String.Empty

        
        objArray = Benavides.CC.Data.clsCeroFaltante.strFaltanteCeroResumen(intSucursalId, intCompaniaId, 0, strCadenaConexion)

        Dim strResult As New StringBuilder()
        If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then

            'Se genera la tabla que contendra la informacion en forma de grid.
            strResult.Append(strTablaConsultaCeroFaltantesHTML(objArray))
        End If

        strResult.Append("<script language=""javascript"" type=""text/javascript"">")
        strResult.Append("parent.document.getElementById('tblCeroFaltantes').innerHTML = document.getElementById('divConsultaCeroFaltantes').innerHTML;")
        strResult.Append("</script>")

        Return strResult.ToString()

    End Function

    Public Function strTablaConsultaCeroFaltantesHTML(ByVal objConsultaCeroFaltantes As Array) As String
        Dim strTablaCeroFaltantesHTML As StringBuilder
        Dim strConsultaCeroFaltantes As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim intPage As Integer
        Dim intTotal As Integer = 10


        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If

        strTablaCeroFaltantesHTML = New StringBuilder

        'Titulo
        strTablaCeroFaltantesHTML.Append("<span class='txtitulo'>")
        strTablaCeroFaltantesHTML.Append("<img src='../static/images/bullet_subtitulos.gif' width='17' height='11' align='absmiddle'>")
        strTablaCeroFaltantesHTML.Append("Cero Faltantes - Resumen </span>")

        'Encabezados
        strTablaCeroFaltantesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strTablaCeroFaltantesHTML.Append("<tr class='trtitulos'>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Sucursal</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Nombre</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Ceros</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Unos</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Total</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Factor %</th>")
        strTablaCeroFaltantesHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el resultado de la busqueda en la tabla.
        For Each strConsultaCeroFaltantes In objConsultaCeroFaltantes
            intContador += 1

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strTablaCeroFaltantesHTML.Append("<tr>")

            ' Sucursal
            strTablaCeroFaltantesHTML.Append("<td id=Sucursal align=center class=" & strColorRegistro & ">" & strConsultaCeroFaltantes(0) & "</td>")
            ' Nombre
            strTablaCeroFaltantesHTML.Append("<td align='left' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaCeroFaltantes(1)) & "</td>")
            ' Ceros
            strTablaCeroFaltantesHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaCeroFaltantes(2) & "</td>")
            ' Unos
            strTablaCeroFaltantesHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaCeroFaltantes(3) & "</td>")
            ' Total
            strTablaCeroFaltantesHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaCeroFaltantes(4) & "</td>")
            ' Factor %
            strTablaCeroFaltantesHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaCeroFaltantes(5) & "</td>")

            strTablaCeroFaltantesHTML.Append("</tr>")

        Next

        strTablaCeroFaltantesHTML.Append("</tr>")
        strTablaCeroFaltantesHTML.Append("</table>")
        strTablaCeroFaltantesHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaCeroFaltantesHTML = strTablaCeroFaltantesHTML.ToString


    End Function

    '====================================================================
    ' Name       : strImpresionCeroFaltantes
    ' Description: Generacion de tabla HTML con formato para imprimir resultados de la consulta.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImpresionCeroFaltantes(ByVal objDataArrayCeroFaltantes As Array) As String

        'Variables
        Dim strImpresionCeroFaltantesHTML As StringBuilder = New StringBuilder
        Dim strRegistroCeroFaltantes As String()
        Dim strclase As String = ""
        Dim intRenglonesxPagina As Integer = 58

        'Rutina que solo se ejecuta al contener informacion de la consulta.
        If IsArray(objDataArrayCeroFaltantes) AndAlso (objDataArrayCeroFaltantes.Length > 0) Then

            Dim intTotalRenglones As Integer = objDataArrayCeroFaltantes.Length
            Dim intTotalPaginas As Integer = 0
            Dim intPagina As Integer = 0
            Dim intRenglon As Integer = 0
            Dim intContadorRenglon As Integer = 0

            'Total de paginas a imprimir.
            intTotalPaginas = CInt(intTotalRenglones \ intRenglonesxPagina)

            'Si se necesita una pagina mas se agrega.
            If intTotalRenglones Mod intRenglonesxPagina > 0 Then
                intTotalPaginas += 1
            End If

            'Inicio de ciclo que da formato a la informacion a imprimir.
            For Each strRegistroCeroFaltantes In objDataArrayCeroFaltantes

                intRenglon += 1
                intContadorRenglon += 1

                If intRenglon = 1 Then
                    intPagina += 1

                    'Salto de hoja
                    If intPagina > 1 Then
                        strImpresionCeroFaltantesHTML.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")
                    End If

                    strImpresionCeroFaltantesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    'Metodo que genera y da formato al encabezado.
                    strImpresionCeroFaltantesHTML.Append(strImprimeEncabezado(intPagina.ToString, intTotalPaginas.ToString))
                End If

                'Clases para renglones.
                If ((intRenglon Mod 2) = 0) Then
                    strclase = "tdtxtImpresionNormal"
                Else
                    strclase = "tdtxtImpresionBold"
                End If


                strImpresionCeroFaltantesHTML.Append("<tr>")
                ' Sucursal
                strImpresionCeroFaltantesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroCeroFaltantes(0)).ToString & "</td>")
                ' Nombre
                strImpresionCeroFaltantesHTML.Append("<td width='50%' align='left' class='" & strclase & "' nowrap >" & clsCommons.strFormatearDescripcion(strRegistroCeroFaltantes(1)).ToString & "</td>")
                ' Ceros
                strImpresionCeroFaltantesHTML.Append("<td width='10%' align='center' class='" & strclase & "'>" & strRegistroCeroFaltantes(2) & "</td>")
                ' Unos
                strImpresionCeroFaltantesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & strRegistroCeroFaltantes(3) & "</td>")
                ' Total
                strImpresionCeroFaltantesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & strRegistroCeroFaltantes(4) & "</td>")
                ' Factor %
                strImpresionCeroFaltantesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & strRegistroCeroFaltantes(5) & "</td>")
                strImpresionCeroFaltantesHTML.Append("</tr>")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionCeroFaltantesHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next

        End If

        Return strImpresionCeroFaltantesHTML.ToString()

    End Function

    Private Function strImprimeEncabezado(ByVal strHojaActual As String, ByVal strHojaFinal As String) As String

        Dim strHtmlEncabezado As StringBuilder

        strHtmlEncabezado = New StringBuilder

        'Encabezado principal
        strHtmlEncabezado.Append("<tr>")
        strHtmlEncabezado.Append("<td colspan='6'>")
        strHtmlEncabezado.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='6'  class='tdtxtBold'>Cero Faltantes: Resumen </th>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='10%' align='left'   class='tdtxtBold'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th width='50%' align='center' class='tdtxtBold' nowrap>" & strCentroLogisticoId & " - " & strSucursalNombre & " (" & intCompaniaId.ToString & intSucursalId.ToString("000") & ")" & "</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='10%' align='right'  class='tdtxtBold'>HOJA " & strHojaActual & " / " & strHojaFinal & " </th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strHtmlEncabezado.Append("</td>")
        strHtmlEncabezado.Append("</tr>")

        'Encabezado titulos
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Sucursal</th>")
        strHtmlEncabezado.Append("<th width='50%' class='tdtxtBold' align='center' nowrap>Nombre</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Ceros</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Unos</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Total</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Factor %</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' class='rayita' colspan='6'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        strImprimeEncabezado = strHtmlEncabezado.ToString

    End Function
#End Region

#Region "Ceros"

    Public Function strTablaConsultaCeroFaltantesCero() As String
        Dim objArray As System.Array = Nothing
        strmRecordBrowserHTML = String.Empty

        objArray = Benavides.CC.Data.clsCeroFaltante.strFaltanteCeroResumen(intSucursalId, intCompaniaId, 1, strCadenaConexion)

        Dim strResult As New StringBuilder()
        If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then

            'Se genera la tabla que contendra la informacion en forma de grid
            strResult.Append(strTablaConsultaCeroFaltantesCeroHTML(objArray))
        End If

        strResult.Append("<script language=""javascript"" type=""text/javascript"">")
        strResult.Append("parent.document.getElementById('tblCeroFaltantesCero').innerHTML = document.getElementById('divConsultaCeroFaltantesCero').innerHTML;")
        strResult.Append("</script>")

        Return strResult.ToString()

    End Function

    Public Function strTablaConsultaCeroFaltantesCeroHTML(ByVal objConsultaCeroFaltantes As Array) As String
        Dim strTablaCeroFaltantesHTML As StringBuilder
        Dim strConsultaCeroFaltantes As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim intPage As Integer
        Dim intTotal As Integer = 10


        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If

        strTablaCeroFaltantesHTML = New StringBuilder

        'Titulo
        strTablaCeroFaltantesHTML.Append("<span class='txtitulo'>")
        strTablaCeroFaltantesHTML.Append("<img src='../static/images/bullet_subtitulos.gif' width='17' height='11' align='absmiddle'>")
        strTablaCeroFaltantesHTML.Append("Cero Faltantes - Ceros </span>")

        'Encabezados
        strTablaCeroFaltantesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strTablaCeroFaltantesHTML.Append("<tr class='trtitulos'>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Sucursal</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Nombre</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Categoría</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Ceros</th>")
        strTablaCeroFaltantesHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el resultado de la busqueda en la tabla.
        For Each strConsultaCeroFaltantes In objConsultaCeroFaltantes
            intContador += 1


            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strTablaCeroFaltantesHTML.Append("<tr>")

            ' Sucursal
            strTablaCeroFaltantesHTML.Append("<td id=Sucursal align=center class=" & strColorRegistro & ">" & strConsultaCeroFaltantes(0) & "</td>")
            ' Nombre
            strTablaCeroFaltantesHTML.Append("<td align='left' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaCeroFaltantes(1)) & "</td>")
            ' Categoria Operativa
            strTablaCeroFaltantesHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaCeroFaltantes(2) & "</td>")
            ' Ceros
            strTablaCeroFaltantesHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaCeroFaltantes(3) & "</td>")

            strTablaCeroFaltantesHTML.Append("</tr>")

        Next

        strTablaCeroFaltantesHTML.Append("</tr>")
        strTablaCeroFaltantesHTML.Append("</table>")
        strTablaCeroFaltantesHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPageCero"" name=""txtCurrentPageCero"" value=""{0}"">", intPage)
        strTablaConsultaCeroFaltantesCeroHTML = strTablaCeroFaltantesHTML.ToString


    End Function

    '====================================================================
    ' Name       : strImpresionCeroFaltantesCeros
    ' Description: Generacion de tabla HTML con formato para imprimir resultados de la consulta.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImpresionCeroFaltantesCeros(ByVal objDataArrayCeroFaltantes As Array) As String

        'Variables
        Dim strImpresionCeroFaltantesCerosHTML As StringBuilder = New StringBuilder
        Dim strRegistroCeroFaltantes As String()
        Dim strclase As String = ""
        Dim intRenglonesxPagina As Integer = 58

        'Rutina que solo se ejecuta al contener informacion de la consulta.
        If IsArray(objDataArrayCeroFaltantes) AndAlso (objDataArrayCeroFaltantes.Length > 0) Then

            Dim intTotalRenglones As Integer = objDataArrayCeroFaltantes.Length
            Dim intTotalPaginas As Integer = 0
            Dim intPagina As Integer = 0
            Dim intRenglon As Integer = 0
            Dim intContadorRenglon As Integer = 0

            'Total de paginas a imprimir.
            intTotalPaginas = CInt(intTotalRenglones \ intRenglonesxPagina)

            'Si se necesita una pagina mas se agrega.
            If intTotalRenglones Mod intRenglonesxPagina > 0 Then
                intTotalPaginas += 1
            End If

            'Inicio de ciclo que da formato a la informacion a imprimir.
            For Each strRegistroCeroFaltantes In objDataArrayCeroFaltantes

                intRenglon += 1
                intContadorRenglon += 1

                If intRenglon = 1 Then
                    intPagina += 1

                    'Salto de hoja
                    If intPagina > 1 Then
                        strImpresionCeroFaltantesCerosHTML.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")
                    End If

                    strImpresionCeroFaltantesCerosHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    'Metodo que genera y da formato al encabezado.
                    strImpresionCeroFaltantesCerosHTML.Append(strImprimeEncabezadoCeros(intPagina.ToString, intTotalPaginas.ToString))
                End If

                'Clases para renglones.
                If ((intRenglon Mod 2) = 0) Then
                    strclase = "tdtxtImpresionNormal"
                Else
                    strclase = "tdtxtImpresionBold"
                End If


                strImpresionCeroFaltantesCerosHTML.Append("<tr>")
                ' Sucursal
                strImpresionCeroFaltantesCerosHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroCeroFaltantes(0)).ToString & "</td>")
                ' Nombre
                strImpresionCeroFaltantesCerosHTML.Append("<td width='45%' align='left' class='" & strclase & "' nowrap >" & clsCommons.strFormatearDescripcion(strRegistroCeroFaltantes(1)).ToString & "</td>")
                ' Categoria Operativa
                strImpresionCeroFaltantesCerosHTML.Append("<td width='25%' align='center' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroCeroFaltantes(2)) & "</td>")
                ' Ceros
                strImpresionCeroFaltantesCerosHTML.Append("<td width='20%' align='center' class='" & strclase & "'>" & strRegistroCeroFaltantes(3) & "</td>")

                strImpresionCeroFaltantesCerosHTML.Append("</tr>")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionCeroFaltantesCerosHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next

        End If

        Return strImpresionCeroFaltantesCerosHTML.ToString()

    End Function

    Private Function strImprimeEncabezadoCeros(ByVal strHojaActual As String, ByVal strHojaFinal As String) As String

        Dim strHtmlEncabezado As StringBuilder

        strHtmlEncabezado = New StringBuilder

        'Encabezado principal
        strHtmlEncabezado.Append("<tr>")
        strHtmlEncabezado.Append("<td colspan='4'>")
        strHtmlEncabezado.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='4'  class='tdtxtBold'>Cero Faltantes: Ceros </th>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='10%' align='left'   class='tdtxtBold'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th width='45%' align='center' class='tdtxtBold' nowrap>" & strCentroLogisticoId & " - " & strSucursalNombre & " (" & intCompaniaId.ToString & intSucursalId.ToString("000") & ")" & "</th>")
        strHtmlEncabezado.Append("<th width='25%' align='center'  class='tdtxtBold'></th>")
        strHtmlEncabezado.Append("<th width='20%' align='right'  class='tdtxtBold'>HOJA " & strHojaActual & " / " & strHojaFinal & " </th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strHtmlEncabezado.Append("</td>")
        strHtmlEncabezado.Append("</tr>")

        'Encabezado titulos
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Sucursal</th>")
        strHtmlEncabezado.Append("<th width='45%' class='tdtxtBold' align='center' nowrap>Nombre</th>")
        strHtmlEncabezado.Append("<th width='25%' class='tdtxtBold' align='center' nowrap>Categoría</th>")
        strHtmlEncabezado.Append("<th width='20%' class='tdtxtBold' align='center' nowrap>Ceros</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' class='rayita' colspan='4'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        strImprimeEncabezadoCeros = strHtmlEncabezado.ToString

    End Function
#End Region

#Region "Factor"

    Public Function strTablaConsultaCeroFaltantesFactor() As String
        Dim objArray As System.Array = Nothing
        strmRecordBrowserHTML = String.Empty


        objArray = Benavides.CC.Data.clsCeroFaltante.strFaltanteCeroResumen(intSucursalId, intCompaniaId, 2, strCadenaConexion)

        Dim strResult As New StringBuilder()
        If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then

            'Se genera la tabla que contendra la informacion en forma de grid
            strResult.Append(strTablaConsultaCeroFaltantesFactorHTML(objArray))
        End If

        strResult.Append("<script language=""javascript"" type=""text/javascript"">")
        strResult.Append("parent.document.getElementById('tblCeroFaltantesFactor').innerHTML = document.getElementById('divConsultaCeroFaltantesFactor').innerHTML;")
        strResult.Append("</script>")

        Return strResult.ToString()

    End Function

    Public Function strTablaConsultaCeroFaltantesFactorHTML(ByVal objConsultaCeroFaltantes As Array) As String
        Dim strTablaCeroFaltantesHTML As StringBuilder
        Dim strConsultaCeroFaltantes As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim intPage As Integer
        Dim intTotal As Integer = 10


        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If

        strTablaCeroFaltantesHTML = New StringBuilder

        'Se agrega paginacion.
        strTablaCeroFaltantesHTML.Append("<span class='txtitulo'>")
        strTablaCeroFaltantesHTML.Append("<img src='../static/images/bullet_subtitulos.gif' width='17' height='11' align='absmiddle'>")
        strTablaCeroFaltantesHTML.Append("Cero Faltantes - Factor </span>")

        'Encabezados
        strTablaCeroFaltantesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strTablaCeroFaltantesHTML.Append("<tr class='trtitulos'>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Sucursal</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Nombre</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Categoría</th>")
        strTablaCeroFaltantesHTML.Append("<th class='rayita' align='center' valign='top'>Factor %</th>")
        strTablaCeroFaltantesHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el resultado de la busqueda en la tabla.
        For Each strConsultaCeroFaltantes In objConsultaCeroFaltantes
            intContador += 1

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strTablaCeroFaltantesHTML.Append("<tr>")

            ' Sucursal
            strTablaCeroFaltantesHTML.Append("<td id=Sucursal align=center class=" & strColorRegistro & ">" & strConsultaCeroFaltantes(0) & "</td>")
            ' Nombre
            strTablaCeroFaltantesHTML.Append("<td align='left' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaCeroFaltantes(1)) & "</td>")
            ' Categoria Operativa
            strTablaCeroFaltantesHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaCeroFaltantes(2) & "</td>")
            ' Factor %
            strTablaCeroFaltantesHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaCeroFaltantes(3) & "</td>")

            strTablaCeroFaltantesHTML.Append("</tr>")

        Next

        strTablaCeroFaltantesHTML.Append("</tr>")
        strTablaCeroFaltantesHTML.Append("</table>")
        strTablaCeroFaltantesHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPageFactor"" name=""txtCurrentPageFactor"" value=""{0}"">", intPage)
        strTablaConsultaCeroFaltantesFactorHTML = strTablaCeroFaltantesHTML.ToString


    End Function

    '====================================================================
    ' Name       : strImpresionCeroFaltantesFactor
    ' Description: Generacion de tabla HTML con formato para imprimir resultados de la consulta.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImpresionCeroFaltantesFactor(ByVal objDataArrayCeroFaltantes As Array) As String

        'Variables
        Dim strImpresionCeroFaltantesFactorHTML As StringBuilder = New StringBuilder
        Dim strRegistroCeroFaltantes As String()
        Dim strclase As String = ""
        Dim intRenglonesxPagina As Integer = 58

        'Rutina que solo se ejecuta al contener informacion de la consulta.
        If IsArray(objDataArrayCeroFaltantes) AndAlso (objDataArrayCeroFaltantes.Length > 0) Then

            Dim intTotalRenglones As Integer = objDataArrayCeroFaltantes.Length
            Dim intTotalPaginas As Integer = 0
            Dim intPagina As Integer = 0
            Dim intRenglon As Integer = 0
            Dim intContadorRenglon As Integer = 0

            'Total de paginas a imprimir.
            intTotalPaginas = CInt(intTotalRenglones \ intRenglonesxPagina)

            'Si se necesita una pagina mas se agrega.
            If intTotalRenglones Mod intRenglonesxPagina > 0 Then
                intTotalPaginas += 1
            End If

            'Inicio de ciclo que da formato a la informacion a imprimir.
            For Each strRegistroCeroFaltantes In objDataArrayCeroFaltantes

                intRenglon += 1
                intContadorRenglon += 1

                If intRenglon = 1 Then
                    intPagina += 1

                    'Salto de hoja
                    If intPagina > 1 Then
                        strImpresionCeroFaltantesFactorHTML.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")
                    End If

                    strImpresionCeroFaltantesFactorHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    'Metodo que genera y da formato al encabezado.
                    strImpresionCeroFaltantesFactorHTML.Append(strImprimeEncabezadoFactor(intPagina.ToString, intTotalPaginas.ToString))
                End If

                'Clases para renglones.
                If ((intRenglon Mod 2) = 0) Then
                    strclase = "tdtxtImpresionNormal"
                Else
                    strclase = "tdtxtImpresionBold"
                End If


                strImpresionCeroFaltantesFactorHTML.Append("<tr>")
                ' Sucursal
                strImpresionCeroFaltantesFactorHTML.Append("<td width='20%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroCeroFaltantes(0)).ToString & "</td>")
                ' Nombre
                strImpresionCeroFaltantesFactorHTML.Append("<td width='45%' align='left' class='" & strclase & "' nowrap >" & clsCommons.strFormatearDescripcion(strRegistroCeroFaltantes(1)).ToString & "</td>")
                ' Categoria Operativa
                strImpresionCeroFaltantesFactorHTML.Append("<td width='25%' align='center' class='" & strclase & "' >" & strRegistroCeroFaltantes(2) & "</td>")
                ' Factor %
                strImpresionCeroFaltantesFactorHTML.Append("<td width='20%' align='center' class='" & strclase & "' >" & strRegistroCeroFaltantes(3) & "</td>")
                strImpresionCeroFaltantesFactorHTML.Append("</tr>")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionCeroFaltantesFactorHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next

        End If

        Return strImpresionCeroFaltantesFactorHTML.ToString()

    End Function

    Private Function strImprimeEncabezadoFactor(ByVal strHojaActual As String, ByVal strHojaFinal As String) As String

        Dim strHtmlEncabezado As StringBuilder

        strHtmlEncabezado = New StringBuilder

        'Encabezado principal
        strHtmlEncabezado.Append("<tr>")
        strHtmlEncabezado.Append("<td colspan='4'>")
        strHtmlEncabezado.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='4'  class='tdtxtBold'>Cero Faltantes: Factor </th>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='10%' align='left'   class='tdtxtBold'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th width='45%' align='center' class='tdtxtBold' nowrap>" & strCentroLogisticoId & " - " & strSucursalNombre & " (" & intCompaniaId.ToString & intSucursalId.ToString("000") & ")" & "</th>")
        strHtmlEncabezado.Append("<th width='25%' align='center'  class='tdtxtBold'></th>")
        strHtmlEncabezado.Append("<th width='20%' align='right'  class='tdtxtBold'>HOJA " & strHojaActual & " / " & strHojaFinal & " </th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strHtmlEncabezado.Append("</td>")
        strHtmlEncabezado.Append("</tr>")

        'Encabezado titulos
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Sucursal</th>")
        strHtmlEncabezado.Append("<th width='45%' class='tdtxtBold' align='center' nowrap>Nombre</th>")
        strHtmlEncabezado.Append("<th width='25%' class='tdtxtBold' align='center' nowrap>Categoría</th>")
        strHtmlEncabezado.Append("<th width='20%' class='tdtxtBold' align='center' nowrap>Factor %</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' class='rayita' colspan='4'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        strImprimeEncabezadoFactor = strHtmlEncabezado.ToString

    End Function
#End Region






End Class

