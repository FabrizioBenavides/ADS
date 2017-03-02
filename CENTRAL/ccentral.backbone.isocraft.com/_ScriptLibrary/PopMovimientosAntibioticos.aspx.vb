'====================================================================
' Page          : PopMovimientosAntibioticos.aspx
' Title         : Administracion POS y BackOffice
' Description   : Popup para selecionar Articulos
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Juan C. Alanis
' Version       : 1.0
' Last Modified : Tuesday, November 15, 2005
'====================================================================

Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration
Imports Isocraft.Web.Http
Imports System.Xml


Public Class PopMovimientosAntibioticos
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

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String

#End Region


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
    ' Name       : strCadenaImagen
    ' Description: Valor de la Compañia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCadenaImagen() As String
        Get
            Return (clsCommons.strReadCookie("strCadenaImagen", "", Request, Server))
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
    ' Name       : strConnectionString
    ' Description: Valor que tomara la variable strmCadenaConexion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strConnectionString() As String
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
            Return clsConcentrador.strObtenerURLSucursal(intCompaniaId, intSucursalId, strConnectionString)
        End Get
    End Property


    '====================================================================
    ' Name       : strSelected
    ' Description: ARTICULO (S) A CONSULTAR
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strSelected() As String
        Get
            Return Request("strSelected")
        End Get
    End Property


    '====================================================================
    ' Name       : strTipoMovimientoAntibioticoId
    ' Description:  
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strTipoMovimientoAntibioticoId() As String
        Get
            If Len(Request("strTipoMovimientoAntibioticoId")) > 0 Then
                Return Request("strTipoMovimientoAntibioticoId")
            Else
                Return ""
            End If
        End Get
    End Property
    '
    '====================================================================
    ' Name       : strIndicadorMovimiento
    ' Description:  
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strIndicadorMovimiento() As String
        Get
            If Len(Request("strIndicadorMovimiento")) > 0 Then
                Return Request("strIndicadorMovimiento")
            Else
                Return ""
            End If
        End Get
    End Property


    '====================================================================
    ' Name       : strFechaInicial
    ' Description:  
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strFechaInicial() As String
        Get
            If Len(Request("strFechaInicial")) > 0 Then
                Return Request("strFechaInicial")
            Else
                Return ""
            End If
        End Get
    End Property


    '====================================================================
    ' Name       : strFechaFinal
    ' Description:  
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strFechaFinal() As String
        Get
            If Len(Request("strFechaFinal")) > 0 Then
                Return Request("strFechaFinal")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strOrdenId
    ' Description:  
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strOrdenId() As String
        Get
            If Len(Request("strOrdenId")) > 0 Then
                Return Request("strOrdenId")
            Else
                Return ""
            End If
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


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Ejecutamos el comando indicado
        Select Case strCmd
            Case "Cerrar"

                Call Response.Write("<html>" & vbCrLf)
                Call Response.Write("<head>" & vbCrLf)
                Call Response.Write("<script language=""javascript"">" & vbCrLf)
                Call Response.Write("window.close();" & vbCrLf)
                Call Response.Write("</script>" & vbCrLf)
                Call Response.Write("</head>" & vbCrLf)
                Call Response.Write("</html>" & vbCrLf)
                Call Response.End()

        End Select

    End Sub

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Genera el Record Browser para mostrar los movimientos
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String
        ' Declaramos e inicializamos las variables locales
        Dim objArrayArticulosSeleccionados As Array = Nothing

        ' Si hay articulos seleccionados
        If Len(strSelected) > 0 Then
            objArrayArticulosSeleccionados = strSelected.Split(","c)

            ' Generamos el navegador de registros
            Dim strReturn As String = strRecordBrowser(objArrayArticulosSeleccionados)

            Return strReturn
        End If
    End Function

    Private Function strRecordBrowser(ByVal objArrayArticulos As Array) As String


        Dim strRecordBrowserHtml As New StringBuilder

        Dim strColorRegistro As String = ""

        Dim strImpresion8 As String = ""
        Dim strImpresion9 As String = ""


        Dim intContadorRegistro As Integer = 0

        If IsArray(objArrayArticulos) AndAlso objArrayArticulos.Length > 0 Then

            Dim objRecordList As System.Collections.SortedList

            Dim objRecord As Array = Benavides.CC.Business.clsConcentrador.clsAntibioticos.strBuscarImpresion(intCompaniaId, intSucursalId, strSelected, strTipoMovimientoAntibioticoId, strIndicadorMovimiento, CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaInicial)), CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaFinal)), strOrdenId, strConnectionString)

            If IsArray(objRecord) AndAlso objRecord.Length > 0 Then

                Dim intTotalRenglones As Integer = objRecord.Length
                Dim intRenglon As Integer = 0

                Dim intRenglonesxPagina As Integer = 24
                Dim intTotalPaginas As Integer = 0
                Dim intPagina As Integer = 0

                intTotalPaginas = intTotalRenglones \ intRenglonesxPagina

                If intTotalRenglones Mod intRenglonesxPagina > 0 Then
                    intTotalPaginas += 1
                Else
                    intTotalPaginas = 1
                End If

                For Each objRecordList In objRecord

                    intRenglon += 1
                    intContadorRegistro += 1

                    If ((intContadorRegistro Mod 2) = 0) Then
                        strImpresion8 = "'tdtxtImpresionBold8'"
                        strImpresion9 = "'tdtxtImpresionBold9'"
                    Else
                        strImpresion8 = "'tdtxtImpresionNormal8'"
                        strImpresion9 = "'tdtxtImpresionNormal9'"
                    End If

                    If intRenglon = 1 Then

                        intPagina += 1

                        If intPagina > 1 Then
                            strRecordBrowserHtml.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")
                        End If

                        strRecordBrowserHtml.Append("<table width='1024px' border='0' cellpadding='0' cellspacing='0'> ")

                        strRecordBrowserHtml.Append("<tr>")
                        strRecordBrowserHtml.Append("<td width='40px'>&nbsp;</td>")
                        strRecordBrowserHtml.Append("<td width='984px'>")
                        'Inicia Titulo Reporte
                        strRecordBrowserHtml.Append("<table width='984px' border='0' cellpadding='0' cellspacing='0'> ")
                        strRecordBrowserHtml.Append("<tr class='trtitulos'>")
                        strRecordBrowserHtml.Append("<td width='50%' align='left'  class='tdtxtImpresionBold8'>MOVIMIENTO DE ANTIBIOTICOS  / TOTAL: " & intTotalRenglones.ToString & "</td>")
                        strRecordBrowserHtml.Append("<td width='50%' align='right' class='tdtxtImpresionBold8'>HOJA: " & intPagina.ToString & " / " & intTotalPaginas & "</td>")
                        strRecordBrowserHtml.Append("</tr>")
                        strRecordBrowserHtml.Append("</table>")
                        'Termina Titulo Reporte
                        strRecordBrowserHtml.Append("</td>")
                        strRecordBrowserHtml.Append("</tr>")

                        strRecordBrowserHtml.Append("<tr>")
                        strRecordBrowserHtml.Append("<td width='40px'>&nbsp;</td>")
                        strRecordBrowserHtml.Append("<td width='984px'>")
                        'Incia Reporte 
                        strRecordBrowserHtml.Append("<table width='984px' border='1' cellpadding='0' cellspacing='0' bordercolor='#000000' style='border-collapse:collapse;'> ")
                        strRecordBrowserHtml.Append("<tr class='trtitulos'>")
                        strRecordBrowserHtml.Append("<th width='020px' align='left' class='tdtxtImpresionBold8' >No</th>")
                        strRecordBrowserHtml.Append("<th width='020px' align='left' class='tdtxtImpresionBold8' >Art." & "</th>")
                        strRecordBrowserHtml.Append("<th width='120px' align='left' class='tdtxtImpresionBold8' >Descripción" & "</th>")
                        strRecordBrowserHtml.Append("<th width='110px' align='left' class='tdtxtImpresionBold8' >Sustancia Activa" & "</th>")
                        strRecordBrowserHtml.Append("<th width='040px' align='left' class='tdtxtImpresionBold8' >Fecha</th>")
                        strRecordBrowserHtml.Append("<th width='030px' align='left' class='tdtxtImpresionBold8' >Mov.</th>")
                        strRecordBrowserHtml.Append("<th width='060px' align='left' class='tdtxtImpresionBold8' >Documento</th>")
                        strRecordBrowserHtml.Append("<th width='100px' align='left' class='tdtxtImpresionBold8' >Tipo</th>")
                        strRecordBrowserHtml.Append("<th width='040px' align='left' class='tdtxtImpresionBold8' >Cantidad</th>")
                        strRecordBrowserHtml.Append("<th width='050px' align='left' class='tdtxtImpresionBold8' >Cedula</th>")
                        strRecordBrowserHtml.Append("<th width='090px' align='left' class='tdtxtImpresionBold8' >Medico</th>")
                        strRecordBrowserHtml.Append("<th width='070px' align='left' class='tdtxtImpresionBold8' >Direccion</th>")
                        strRecordBrowserHtml.Append("<th width='040px' align='left' class='tdtxtImpresionBold8' >Estado</th>")
                        strRecordBrowserHtml.Append("<th width='040px' align='left' class='tdtxtImpresionBold8' >Ciudad</th>")
                        strRecordBrowserHtml.Append("<th width='040px' align='left' class='tdtxtImpresionBold8' >Folio</th>")
                        strRecordBrowserHtml.Append("<th width='100px' align='left' class='tdtxtImpresionBold8' >Proveedor</th>")
                        strRecordBrowserHtml.Append("</tr>")

                    End If

                    strRecordBrowserHtml.Append("<tr>")
                    ' 1 No. de Renglon
                    strRecordBrowserHtml.Append("<td class=" & strImpresion8 & " width='020px' align='right'>" & intContadorRegistro.ToString & "&nbsp;</td>")
                    ' 2 intArticuloId
                    strRecordBrowserHtml.Append("<td class=" & strImpresion9 & " width='020px' align='right'>" & CStr(objRecordList.Item("intArticuloId")) & "</td>")
                    ' 3 strArticuloDescripcion
                    strRecordBrowserHtml.Append("<td class=" & strImpresion9 & " width='120px' align='left'>" & clsCommons.strFormatearDescripcion(CStr(objRecordList.Item("strArticuloDescripcion"))) & "</td>")
                    ' 4 strArticuloSustanciaActiva
                    strRecordBrowserHtml.Append("<td class=" & strImpresion9 & " width='110px' align='left'>" & clsCommons.strFormatearDescripcion(CStr(objRecordList.Item("strArticuloSustanciaActiva"))) & "</td>")
                    ' 5 dtmFechaContabilizacionMovimientoAntibiotico
                    strRecordBrowserHtml.Append("<td class=" & strImpresion9 & " width='040px' align='left'>" & CStr(CDate(objRecordList.Item("dtmFechaContabilizacionMovimientoAntibiotico")).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)) & "</td>")
                    ' 6 strIndicadorMovimientoAntibiotico
                    strRecordBrowserHtml.Append("<td class=" & strImpresion9 & " width='030px' align='left'>" & clsCommons.strFormatearDescripcion(CStr(objRecordList.Item("strIndicadorMovimientoAntibiotico"))) & "</td>")
                    ' 7 strDocumentoMovimientoAntibiotico
                    strRecordBrowserHtml.Append("<td class=" & strImpresion9 & " width='060px' align='right'>" & clsCommons.strFormatearDescripcion(CStr(objRecordList.Item("strDocumentoMovimientoAntibiotico"))) & "</td>")
                    ' 8 strDescripcionTipoMovimientoAntibiotico
                    strRecordBrowserHtml.Append("<td class=" & strImpresion8 & " width='100px' align='left'>" & clsCommons.strFormatearDescripcion(CStr(objRecordList.Item("strDescripcionTipoMovimientoAntibiotico"))) & "</td>")
                    ' 9 intCantidadMovimientoAntibiotico
                    strRecordBrowserHtml.Append("<td class=" & strImpresion9 & " width='040px' align='right'>" & clsCommons.strFormatearDescripcion(CStr(objRecordList.Item("intCantidadMovimientoAntibiotico"))) & "</td>")
                    ' 10 intDoctorCedulaId
                    strRecordBrowserHtml.Append("<td class=" & strImpresion9 & " width='050px' align='right'>" & clsCommons.strFormatearDescripcion(CStr(objRecordList.Item("intDoctorCedulaId"))) & "</td>")
                    ' 11 strDoctorNombreCompleto
                    strRecordBrowserHtml.Append("<td class=" & strImpresion8 & " width='090px' align='left'>" & clsCommons.strFormatearDescripcion(CStr(objRecordList.Item("strDoctorNombreCompleto"))) & "</td>")
                    ' 12 CStr(objRecordList.Item("strDoctorDireccion"))
                    strRecordBrowserHtml.Append("<td class=" & strImpresion8 & " width='070px' align='left'>" & clsCommons.strFormatearDescripcion(CStr(objRecordList.Item("strDoctorDireccion"))) & "</td>")
                    ' 13 strEstadoNombre
                    strRecordBrowserHtml.Append("<td class=" & strImpresion8 & " width='040px' align='left'>" & clsCommons.strFormatearDescripcion(CStr(objRecordList.Item("strEstadoNombre"))) & "</td>")
                    ' 14 strCiudadNombre
                    strRecordBrowserHtml.Append("<td class=" & strImpresion8 & " width='040px' align='left'>" & clsCommons.strFormatearDescripcion(CStr(objRecordList.Item("strCiudadNombre"))) & "</td>")
                    ' 15 intRecetaAntibioticoFolio
                    strRecordBrowserHtml.Append("<td class=" & strImpresion9 & " width='040px' align='right'>" & clsCommons.strFormatearDescripcion(CStr(objRecordList.Item("intRecetaAntibioticoFolio"))) & "</td>")
                    ' 16 strProveedor
                    strRecordBrowserHtml.Append("<td class=" & strImpresion8 & " width='100px' align='left'>" & clsCommons.strFormatearDescripcion(CStr(objRecordList.Item("strProveedor"))) & "</td>")

                    strRecordBrowserHtml.Append("</tr>")

                    If intContadorRegistro = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                        strRecordBrowserHtml.Append("</table>")
                        strRecordBrowserHtml.Append("</td>")
                        strRecordBrowserHtml.Append("</tr>")
                        strRecordBrowserHtml.Append("</table>")
                        intRenglon = 0
                    End If
                Next

               
            Else
                strRecordBrowserHtml.Append("<table width='1024px' border='0' cellpadding='0' cellspacing='0'> ")
                strRecordBrowserHtml.Append("<tr>")
                strRecordBrowserHtml.Append("<td width='40px'>&nbsp;</td>")
                strRecordBrowserHtml.Append("<td width='984px'>class='tdblanco'>No hay registros</td>")
                strRecordBrowserHtml.Append("</tr>")
                strRecordBrowserHtml.Append("</table>")
            End If

        End If


        Return strRecordBrowserHtml.ToString

    End Function



    '====================================================================
    ' Name       : strRecordBrowser
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowser1(ByVal objArrayArticulos As Array) As String
        Const strRecordBrowserName As String = "VentasMovimientosAntibioticosImpresion"

        If IsArray(objArrayArticulos) AndAlso objArrayArticulos.Length > 0 Then
            Dim aobjDataArray As Array = Benavides.CC.Business.clsConcentrador.clsAntibioticos.strBuscarImpresion(intCompaniaId, intSucursalId, strSelected, strTipoMovimientoAntibioticoId, strIndicadorMovimiento, CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaInicial)), CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaFinal)), strOrdenId, strConnectionString)
            Dim strTargetURL As String = strThisPageName & "?"
            Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, aobjDataArray, 0, 0, strTargetURL)
        End If


    End Function

End Class
