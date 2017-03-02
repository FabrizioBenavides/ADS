'====================================================================
' Page          : MercanciaConsultaDiasInventario.aspx
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


Public Class MercanciaConsultaDiasInventario
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
        intDivisionArticulosId = CInt(GetPageParameter("cboDivisionArticulos", "0"))

    End Sub

#End Region

    Public strRecordBrowserImpresion As String = ""

#Region " Class Private Attributes"

    Const strComitasDobles As String = """"

    Private strmJavascriptWindowOnLoadCommands As String

    Private strmRecordBrowserHTML As String = ""

    Private intmDivisionArticulosId As Integer

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
    ' Name       : strLlenarDivisionArticulosComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box cboDivisionArticulos
    ' Parameters : None
    ' Throws     : None
    ' Output     : String

    '====================================================================
    Public Function strLlenarDivisionArticulosComboBox() As String

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDivisionArticulos", intDivisionArticulosId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarDivisionArticulos(strCadenaConexion), 0, 2, 1)

    End Function

    '====================================================================
    ' Name       : intDivisionArticulosId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intDivisionArticulosId() As Integer
        Get
            Return intmDivisionArticulosId
        End Get
        Set(ByVal intValue As Integer)
            intmDivisionArticulosId = intValue
        End Set
    End Property



    '====================================================================
    ' Name       : strConsultarDiasInventario
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strConsultarDiasInventario() As String

        Dim htmlResult As String = ""

        ' Declaramos e inicializamos las constantes locales

        Dim strRecordBrowserName As String = "MercanciaConsultaDiasInventario"

        ' Declaramos e inicialziamos las variables locales
        Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))

        If intSelectedPage <= 0 Then
            intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
        End If

        Dim objDataArrayDiasInventario As Array = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarDiasInventario(intCompaniaId, intSucursalId, intDivisionArticulosId, 0, 0, strCadenaConexion)

        Dim maxPerPage As Integer = 25

        Dim headers As ArrayList = New ArrayList
        headers.Add("División")
        headers.Add("División Nombre")
        headers.Add("Dias")

        Dim columnOrder As Integer() = {0, 1, 2}

        htmlResult = Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objDataArrayDiasInventario.Length, intSelectedPage, maxPerPage, "MercanciaConsultaDiasInventario.aspx", Nothing)
        htmlResult += Benavides.CC.Commons.clsRecordBrowserNew.displayTable(headers, objDataArrayDiasInventario, columnOrder, Nothing, intSelectedPage, maxPerPage, -1)

        Return htmlResult

    End Function


    '====================================================================
    ' Name       : strImpresionDiasInventario
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImpresionDiasInventario(ByVal objDataArrayDiasInventario As Array) As String

        Dim strImpresionDiasInventarioHTML As StringBuilder = New StringBuilder
        Dim strRegistroDiasInventario As String()
        Dim strclase As String = ""
        Dim intRenglonesxPagina As Integer = 58


        If IsArray(objDataArrayDiasInventario) AndAlso (objDataArrayDiasInventario.Length > 0) Then

            Dim intTotalRenglones As Integer = objDataArrayDiasInventario.Length
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

            For Each strRegistroDiasInventario In objDataArrayDiasInventario

                intRenglon += 1
                intContadorRenglon += 1

                If intRenglon = 1 Then
                    intPagina += 1

                    If intPagina > 1 Then
                        strImpresionDiasInventarioHTML.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")

                    End If

                    strImpresionDiasInventarioHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    strImpresionDiasInventarioHTML.Append(strImprimeEncabezado(intPagina.ToString, intTotalPaginas.ToString))
                End If

                If ((intRenglon Mod 2) = 0) Then
                    strclase = "tdtxtImpresionNormal"
                Else
                    strclase = "tdtxtImpresionBold"
                End If


                strImpresionDiasInventarioHTML.Append("<tr>")

                ' strDivisionArticulosNombreId
                strImpresionDiasInventarioHTML.Append("<td width='10%' align='right' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroDiasInventario(0)).ToString & "</td>")

                ' strDivisionArticulosNombre
                strImpresionDiasInventarioHTML.Append("<td width='65%' class='" & strclase & "' nowrap >" & clsCommons.strFormatearDescripcion(strRegistroDiasInventario(1)).ToString & "</td>")

                ' intDiasInventario
                strImpresionDiasInventarioHTML.Append("<td width='25%' align='right' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroDiasInventario(2)).ToString & "</td>")

                strImpresionDiasInventarioHTML.Append("</tr>")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionDiasInventarioHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next

        End If

        Return strImpresionDiasInventarioHTML.ToString()

    End Function

    Private Function strImprimeEncabezado(ByVal strHojaActual As String, ByVal strHojaFinal As String) As String

        Dim strHtmlEncabezado As StringBuilder

        strHtmlEncabezado = New StringBuilder

        'Encabezado principal
        strHtmlEncabezado.Append("<tr>")
        strHtmlEncabezado.Append("<td colspan='3'>")

        strHtmlEncabezado.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='3'  class='tdtxtBold'>Reporte Dias de Inventario </th>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='20%' align='left'   class='tdtxtBold'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th width='60%' align='center' class='tdtxtBold' nowrap>" & strCentroLogisticoId & " - " & strSucursalNombre & " (" & intCompaniaId.ToString & intSucursalId.ToString("000") & ")" & "</th>")
        strHtmlEncabezado.Append("<th width='20%' align='right'  class='tdtxtBold'>HOJA " & strHojaActual & " / " & strHojaFinal & " </th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strHtmlEncabezado.Append("</td>")
        strHtmlEncabezado.Append("</tr>")

        'Encabezado titulos
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='left' nowrap>División</th>")
        strHtmlEncabezado.Append("<th width='65%' class='tdtxtBold' align='left' nowrap>División Nombre</th>")
        strHtmlEncabezado.Append("<th width='25%' class='tdtxtBold' align='left' nowrap>Dias</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' class='rayita' colspan='3'>" & "&nbsp;" & "</th>")
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

                Dim objDataArrayDiasInventario As Array = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarDiasInventario(intCompaniaId, intSucursalId, intDivisionArticulosId, 0, 0, strCadenaConexion)

                If IsArray(objDataArrayDiasInventario) AndAlso objDataArrayDiasInventario.Length > 0 Then

                    strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strImpresionDiasInventario(objDataArrayDiasInventario))

                    strHTML.Append("<script language='Javascript'>parent.fnImprimir( " & _
                    strComitasDobles & strRecordBrowserImpresion.ToString & strComitasDobles & _
                    "); </script>")
                    Response.Write(strHTML.ToString)
                    Response.End()

                End If

        End Select


    End Sub

End Class
