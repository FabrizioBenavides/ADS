Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports Isocraft.Web.Http
Imports System.Text
Imports System.Collections


Public Class clsMercanciaConsultarPlanogramas
    Inherits System.Web.UI.Page


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        strPlanograma = GetPageParameter("strPlanograma", GetPageParameter("txtPlanograma", ""))
        intOrdenId = GetPageParameter("cboOrden", 0)

    End Sub

#End Region

#Region " Class Private Attributes"

    Const strComitasDobles As String = """"

    Private strmPlanograma As String
    Private strRecordBrowserImpresion As String = ""
    Private intmOrdenId As Integer

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
    ' Name       : strPlanograma 
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : string
    '====================================================================
    Public Property strPlanograma() As String
        Get
            Return strmPlanograma
        End Get
        Set(ByVal strValue As String)
            strmPlanograma = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intOrdenId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intOrdenId() As Integer
        Get
            Return intmOrdenId
        End Get
        Set(ByVal intValue As Integer)
            intmOrdenId = intValue
        End Set
    End Property


    Public ReadOnly Property intTotalPlanogramas() As Integer
        Get
            Dim intTotalRenglones As Integer = 0
            Dim objDataArrayPlanogramas As Array = clsConcentrador.clsPlanograma.strBuscar(intCompaniaId, intSucursalId, "", intOrdenId, strCadenaConexion)

            If IsArray(objDataArrayPlanogramas) AndAlso (objDataArrayPlanogramas.Length > 0) Then
                intTotalRenglones = objDataArrayPlanogramas.Length
            End If

            Return intTotalRenglones

        End Get

    End Property

    '====================================================================
    ' Name       : strConsultarPlanogramas
    ' Description: Valor que tomara la variable strmRecordBrowserHTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================

    Public Function strConsultarPlanogramas() As String

        Dim htmlResult As String = ""

        Dim strRecordBrowserName As String = "MercanciaConsultarPlanogramas"

        ' Declaramos e inicialziamos las variables locales
        Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))

        If intSelectedPage <= 0 Then
            intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
        End If

        Dim maxPerPage As Integer = 50

        Dim objPlanogramas As Array = clsConcentrador.clsPlanograma.strBuscar(intCompaniaId, intSucursalId, strPlanograma, intOrdenId, strCadenaConexion)


        Dim headers As ArrayList = New ArrayList
        headers.Add("Plano")
        headers.Add("Descripción")
        headers.Add("Tipo Plano")
        headers.Add("Tipo Mueble")
        headers.Add("Actualización")
        headers.Add("Asignación")
        headers.Add("Acciones")

        Dim columnOrder As Integer() = {0, 1, 2, 3, 4, 5}

        Dim actions As ArrayList = New ArrayList
        Dim pkNames As String() = {"intPlanoId"}
        Dim pkIndexes As Integer() = {0}

        actions.Add(New Benavides.CC.Commons.clsActionLink("VerTexto", pkNames, pkIndexes, "icono_texto.gif", "Haga clic aquí para ver el detalle del plano"))
        actions.Add(New Benavides.CC.Commons.clsActionLink("VerGrafico", pkNames, pkIndexes, "icono_grafico.gif", "Haga clic aquí para ver el grafico del plano"))

        htmlResult = Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objPlanogramas.Length, intSelectedPage, maxPerPage, "MercanciaConsultarPlanogramas.aspx", Nothing)
        htmlResult += Benavides.CC.Commons.clsRecordBrowserNew.displayTable(headers, objPlanogramas, columnOrder, actions, intSelectedPage, maxPerPage, -1)

        Return htmlResult

    End Function

    '====================================================================
    ' Name       : strImpresionPlanogramas
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImpresionPlanogramas(ByVal objDataArrayPlanogramas As Array) As String

        Dim strImpresionPlanogramasHTML As StringBuilder = New StringBuilder
        Dim strRegistroPlanogramas As String()
        Dim strclase As String = ""
        Dim intRenglonesxPagina As Integer = 60

        If IsArray(objDataArrayPlanogramas) AndAlso (objDataArrayPlanogramas.Length > 0) Then

            Dim intTotalRenglones As Integer = objDataArrayPlanogramas.Length
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

            For Each strRegistroPlanogramas In objDataArrayPlanogramas

                intRenglon += 1
                intContadorRenglon += 1

                If intRenglon = 1 Then
                    intPagina += 1

                    If intPagina > 1 Then
                        strImpresionPlanogramasHTML.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")

                    End If

                    strImpresionPlanogramasHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    strImpresionPlanogramasHTML.Append(strImprimeEncabezado(intPagina.ToString, intTotalPaginas.ToString))
                End If

                If ((intRenglon Mod 2) = 0) Then
                    strclase = "tdtxtImpresionNormal"
                Else
                    strclase = "tdtxtImpresionBold"
                End If


                strImpresionPlanogramasHTML.Append("<tr>")

                ' Planograma
                strImpresionPlanogramasHTML.Append("<td width='10%' align='right' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroPlanogramas(0)).ToString & "</td>")

                ' Nombre
                strImpresionPlanogramasHTML.Append("<td width='40%' align='left' class='" & strclase & "' nowrap >" & clsCommons.strFormatearDescripcion(strRegistroPlanogramas(1)).ToString & "</td>")

                ' Tipo Plano
                strImpresionPlanogramasHTML.Append("<td width='15%' align='left' class='" & strclase & "' nowrap >" & clsCommons.strFormatearDescripcion(strRegistroPlanogramas(2)).ToString & "</td>")

                ' Tipo Mueble
                strImpresionPlanogramasHTML.Append("<td width='15%' align='left' class='" & strclase & "' nowrap >" & clsCommons.strFormatearDescripcion(strRegistroPlanogramas(3)).ToString & "</td>")

                ' Actualizacion
                strImpresionPlanogramasHTML.Append("<td width='10%' align='right' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroPlanogramas(4)).ToString & "</td>")

                ' Asignación
                strImpresionPlanogramasHTML.Append("<td width='10%' align='right' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroPlanogramas(5)).ToString & "</td>")

                strImpresionPlanogramasHTML.Append("</tr>")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionPlanogramasHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next

        End If

        Return strImpresionPlanogramasHTML.ToString()

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
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='3'  class='tdtxtBold'>Planogramas de Sucursal</th>")
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
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='left' nowrap>Plano</th>")
        strHtmlEncabezado.Append("<th width='40%' class='tdtxtBold' align='left' nowrap>Descripción</th>")
        strHtmlEncabezado.Append("<th width='15%' class='tdtxtBold' align='left' nowrap>Tipo Plano</th>")
        strHtmlEncabezado.Append("<th width='15%' class='tdtxtBold' align='left' nowrap>Tipo Mueble</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='left' nowrap>Actualización</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='left' nowrap>Asignación</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' class='rayita' colspan='6'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        strImprimeEncabezado = strHtmlEncabezado.ToString

    End Function



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
            Call Response.Redirect(strRedirectPage)
        End If

        Select Case strCmd

            Case "Imprimir"

                Dim strHTML As New StringBuilder

                Dim objDataArrayPlanogramas As Array = clsConcentrador.clsPlanograma.strBuscar(intCompaniaId, intSucursalId, strPlanograma, intOrdenId, strCadenaConexion)

                If IsArray(objDataArrayPlanogramas) AndAlso objDataArrayPlanogramas.Length > 0 Then

                    strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strImpresionPlanogramas(objDataArrayPlanogramas))

                    strHTML.Append("<script language='Javascript'>parent.fnImprimir( " & _
                    strComitasDobles & strRecordBrowserImpresion.ToString & strComitasDobles & _
                    "); </script>")
                    Response.Write(strHTML.ToString)
                    Response.End()

                End If

        End Select

    End Sub

    
End Class
