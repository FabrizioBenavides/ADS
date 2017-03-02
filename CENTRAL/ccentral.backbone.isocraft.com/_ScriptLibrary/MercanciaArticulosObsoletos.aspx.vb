'====================================================================
' Page          : MercanciaArticulosObsoletos.aspx
' Title         : Administracion POS y BackOffice
' Description   : Página Consulta 
' Copyright     : 2007 All rights reserved.
' Company       : 
' Author        : J.Antonio Hernández Dávila
' Version       : 1.0
' Last Modified : Viernes, Septiembre 07, 2007
'====================================================================

Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports System.Configuration
Imports System.Collections
Imports System.DateTime
Imports System.Text


Public Class MercanciaArticulosObsoletos
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

        strSucursalId = GetPageParameter("cboSucursal", "")
        strArticulo = GetPageParameter("strArticulo", GetPageParameter("txtArticulo", ""))
        intClaveVigenciaArticuloId = CInt(GetPageParameter("cboVigencia", "0"))

    End Sub

#End Region

    Public strRecordBrowserImpresion As String = ""

#Region " Class Private Attributes"

    Const strComitasDobles As String = """"

    Private strmJavascriptWindowOnLoadCommands As String

    Private strmSucursalId As String

    Private strmCboSucursal As String
    Private strmArticulo As String

    Private strmRecordBrowserHTML As String = ""

    Private intmClaveVigenciaArticuloId As Integer

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
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strJavascriptWindowOnLoadCommands() As String
        Get
            Return strmJavascriptWindowOnLoadCommands
        End Get
        Set(ByVal strValue As String)
            strmJavascriptWindowOnLoadCommands = strValue
        End Set
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
    ' Name       : strLlenarSucursalComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboSucursal"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String

    '====================================================================
    Public Function strLlenarSucursalComboBox() As String

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSucursal", strSucursalId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacionZona(intCompaniaId, intSucursalId, strCadenaConexion), New Integer(1) {0, 1}, 2, 1)

    End Function

    '====================================================================
    ' Name       : strSucursalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strSucursalId() As String
        Get
            Return strmSucursalId
        End Get
        Set(ByVal intValue As String)
            strmSucursalId = intValue
        End Set
    End Property

    Public ReadOnly Property intCiaConsultaid() As Integer
        Get
            Dim intmCiaConsultaid As Integer = 0

            If Len(strSucursalId) > 3 Then

                Dim astrCompaniaSucursal As Array = Split(strSucursalId, "|")

                If astrCompaniaSucursal.Length > 0 Then
                    intmCiaConsultaid = CInt(astrCompaniaSucursal.GetValue(0))
                End If

            End If

            Return intmCiaConsultaid

        End Get

    End Property

    Public ReadOnly Property intSucConsultaid() As Integer
        Get
            Dim intmSucConsultaid As Integer = 0

            If Len(strSucursalId) > 3 Then

                Dim astrCompaniaSucursal As Array = Split(strSucursalId, "|")

                If astrCompaniaSucursal.Length > 0 Then
                    intmSucConsultaid = CInt(astrCompaniaSucursal.GetValue(1))
                End If

            End If

            Return intmSucConsultaid

        End Get

    End Property

    '====================================================================
    ' Name       : strLlenarVigenciaArticuloComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box cboVigencia
    ' Parameters : None
    ' Throws     : None
    ' Output     : String

    '====================================================================
    Public Function strLlenarVigenciaArticuloComboBox() As String

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboVigencia", intClaveVigenciaArticuloId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarVigenciaArticuloObsoleto(strCadenaConexion), 0, 1, 1)

    End Function

    '====================================================================
    ' Name       : intClaveVigenciaArticuloId 
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intClaveVigenciaArticuloId() As Integer
        Get
            Return intmClaveVigenciaArticuloId
        End Get
        Set(ByVal intValue As Integer)
            intmClaveVigenciaArticuloId = intValue
        End Set
    End Property


    '====================================================================
    ' Name       : strArticulo
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : string
    '====================================================================
    Public Property strArticulo() As String
        Get
            Return strmArticulo
        End Get
        Set(ByVal strValue As String)
            strmArticulo = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strConsultarObsoletos
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strConsultarObsoletos() As String

        Dim htmlResult As String = ""

        If Len(strSucursalId) > 0 Then

            ' Declaramos e inicializamos las constantes locales

            Dim strRecordBrowserName As String = "MercanciaArticulosObsoletos"

            ' Declaramos e inicialziamos las variables locales
            Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))

            If intSelectedPage <= 0 Then
                intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
            End If

            Dim objDataArrayObsoletos As Array = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarArticulosObsoletos(intCiaConsultaid, intSucConsultaid, strArticulo, intClaveVigenciaArticuloId, 0, 0, strCadenaConexion)

            Dim maxPerPage As Integer = 25

            Dim headers As ArrayList = New ArrayList
            headers.Add("No Articulo")
            headers.Add("Descripción")
            headers.Add("Vigencia")
            headers.Add("Teorico")
            headers.Add("Precio")
            headers.Add("Oferta")
            headers.Add("Costo")
            headers.Add("Planograma")

            Dim columnOrder As Integer() = {2, 3, 4, 5, 6, 7, 8, 9}

            htmlResult = Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objDataArrayObsoletos.Length, intSelectedPage, maxPerPage, "MercanciaArticulosObsoletos.aspx", Nothing)
            htmlResult += Benavides.CC.Commons.clsRecordBrowserNew.displayTable(headers, objDataArrayObsoletos, columnOrder, Nothing, intSelectedPage, maxPerPage, -1)

        End If


        Return htmlResult




    End Function


    '====================================================================
    ' Name       : strImpresionObsoletos
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImpresionObsoletos(ByVal objArrayObsoletos As Array) As String

        Dim strImpresionObsoletosHTML As StringBuilder = New StringBuilder
        Dim strRegistroObsoletos As String()
        Dim strclase As String = ""
        Dim intRenglonesxPagina As Integer = 58


        If IsArray(objArrayObsoletos) AndAlso (objArrayObsoletos.Length > 0) Then

            Dim intTotalRenglones As Integer = objArrayObsoletos.Length
            Dim intTotalPaginas As Integer = 0

            Dim intPagina As Integer = 0
            Dim intRenglon As Integer = 0
            Dim intContadorRenglon As Integer = 0

            intTotalPaginas = CInt(intTotalRenglones \ intRenglonesxPagina)

            If intTotalRenglones Mod intRenglonesxPagina > 0 Then
                intTotalPaginas += 1
            End If

            intRenglon = 0
            intPagina = 0
            intContadorRenglon = 0

            For Each strRegistroObsoletos In objArrayObsoletos

                intRenglon += 1
                intContadorRenglon += 1

                If intRenglon = 1 Then
                    intPagina += 1

                    If intPagina > 1 Then
                        'strImpresionObsoletosHTML.Append("<p class='breakhere'></p>")
                        strImpresionObsoletosHTML.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")

                    End If

                    strImpresionObsoletosHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    strImpresionObsoletosHTML.Append(strImprimeEncabezado(intPagina.ToString, intTotalPaginas.ToString))
                End If

                If ((intRenglon Mod 2) = 0) Then
                    strclase = "tdtxtImpresionNormal9"
                Else
                    strclase = "tdtxtImpresionBold9" ' "tdtxtImpresionBold9" '"tdtxtBold"
                End If


                strImpresionObsoletosHTML.Append("<tr>")

                'No. de Renglon
                strImpresionObsoletosHTML.Append("<td width='02%' align='right' class='" & strclase & "' nowrap>" & clsCommons.strFormatearDescripcion(intContadorRenglon.ToString) & "</td>")

                ' intArticuloId
                strImpresionObsoletosHTML.Append("<td width='03%' align='right' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroObsoletos(2)).ToString & "</td>")

                ' strArticuloDescripcion
                strImpresionObsoletosHTML.Append("<td width='25%' class='" & strclase & "' nowrap >" & Mid(clsCommons.strFormatearDescripcion(strRegistroObsoletos(3)).ToString, 1, 38) & "</td>")

                ' strArticuloClaveVigencia
                strImpresionObsoletosHTML.Append("<td width='15%' class='" & strclase & "' nowrap >" & Mid(clsCommons.strFormatearDescripcion(strRegistroObsoletos(4)).ToString, 1, 38) & "</td>")

                ' intArticuloSucursalExistenciaTeorica
                strImpresionObsoletosHTML.Append("<td width='05%' align='right' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroObsoletos(5)).ToString & "</td>")

                ' fltArticuloSucursalPrecioNormalConImpuesto
                strImpresionObsoletosHTML.Append("<td width='05%' align='right' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroObsoletos(6)).ToString & "</td>")

                'fltArticuloOfertaPrecioConImpuesto
                strImpresionObsoletosHTML.Append("<td width='05%' align='right' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroObsoletos(7)).ToString & "</td>")

                'fltArticuloCostoReposicion
                strImpresionObsoletosHTML.Append("<td width='05%' align='right' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroObsoletos(8)).ToString & "</td>")

                ' strPlano
                strImpresionObsoletosHTML.Append("<td width='35%' align='left' class='" & strclase & "'>" & Mid(clsCommons.strFormatearDescripcion(strRegistroObsoletos(9)).ToString, 1, 42) & "</td>")


                strImpresionObsoletosHTML.Append("</tr>")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionObsoletosHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next

        End If

        Return strImpresionObsoletosHTML.ToString()

    End Function

    Private Function strImprimeEncabezado(ByVal strHojaActual As String, ByVal strHojaFinal As String) As String

        Dim strHtmlEncabezado As StringBuilder

        strHtmlEncabezado = New StringBuilder

        'Encabezado principal

        strHtmlEncabezado.Append("<tr>")
        strHtmlEncabezado.Append("<td colspan='9'>")

        strHtmlEncabezado.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='3'  class='tdtxtBold'>Reporte Articulos Obsoletos </th>")
        strHtmlEncabezado.Append("</tr>")
        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='20%' align='left'   class='tdtxtBold'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th width='60%' align='center' class='tdtxtBold' nowrap>" & Request("strNombre") & "</th>")
        strHtmlEncabezado.Append("<th width='20%' align='right'  class='tdtxtBold'>HOJA " & strHojaActual & " / " & strHojaFinal & " </th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strHtmlEncabezado.Append("</td>")
        strHtmlEncabezado.Append("</tr>")

        'Encabezado titulos
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='02%' class='tdtxtBold' align='right' nowrap>No.</th>")
        strHtmlEncabezado.Append("<th width='03%' class='tdtxtBold' align='right' nowrap>Código</th>")
        strHtmlEncabezado.Append("<th width='25%' class='tdtxtBold' nowrap>Descripción</th>")
        strHtmlEncabezado.Append("<th width='15%' class='tdtxtBold' nowrap>Vigencia</th>")
        strHtmlEncabezado.Append("<th width='05%' class='tdtxtBold' align='right' nowrap>Teórico</th>")
        strHtmlEncabezado.Append("<th width='05%' class='tdtxtBold' align='right' nowrap>Precio</th>")
        strHtmlEncabezado.Append("<th width='05%' class='tdtxtBold' align='right' nowrap>Oferta</th>")
        strHtmlEncabezado.Append("<th width='05%' class='tdtxtBold' align='right' nowrap>Costo</th>")
        strHtmlEncabezado.Append("<th width='35%' class='tdtxtBold' align='left'  nowrap>Planograma</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola

        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' class='rayita' colspan='9'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        strImprimeEncabezado = strHtmlEncabezado.ToString

    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Control de Acceso de la página

        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        Select Case strCmd

            Case "Imprimir"

                Dim strHTML As New StringBuilder

                Dim objDataArrayImpresionObsoletos As Array = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarArticulosObsoletos(intCiaConsultaid, intSucConsultaid, strArticulo, intClaveVigenciaArticuloId, 0, 0, strCadenaConexion)

                If IsArray(objDataArrayImpresionObsoletos) AndAlso objDataArrayImpresionObsoletos.Length > 0 Then

                    strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strImpresionObsoletos(objDataArrayImpresionObsoletos))

                    strHTML.Append("<script language='Javascript'>parent.fnImprimir( " & _
                    strComitasDobles & strRecordBrowserImpresion.ToString & strComitasDobles & _
                    "); </script>")
                    Response.Write(strHTML.ToString)
                    Response.End()

                End If


        End Select






    End Sub

End Class
