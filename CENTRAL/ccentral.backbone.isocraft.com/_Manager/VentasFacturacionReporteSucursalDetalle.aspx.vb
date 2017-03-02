Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

Imports System.Text
Imports System.Collections

Imports Benavides.CC.Data
Imports Benavides.CC.Business.clsConcentrador.clsSucursal

Imports Benavides.POSAdmin.Commons

Public Class VentasFacturacionReporteSucursalDetalle
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

    '====================================================================
    ' Name       : strFormAction
    ' Description: HTML form's action property value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormAction() As String
        Get
            Return strThisPageName
        End Get
    End Property

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Connection string
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Private ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: Name of this page
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return Server.UrlEncode(GetPageName())
        End Get
    End Property

    '====================================================================
    ' Name       : intGrupoUsuarioId
    ' Description: Identificador del Grupo de Usuario
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intGrupoUsuarioId() As Integer
        Get
            Return CInt(Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strHTMLFechaHora
    ' Description: Genera la fecha y hora de la página
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
        End Get
    End Property


    '====================================================================
    ' Name       : intDetaFacturaId
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intDetaFacturaId() As Integer
        Get
            Dim strRegreso As String = Request("intDetaFacturaId")

            If Len(strRegreso) < 1 Then
                strRegreso = "0"
            End If

            Return CInt(strRegreso)
        End Get
    End Property

    '====================================================================
    ' Name       : intDetaCompaniaid
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intDetaCompaniaId() As Integer
        Get
            Dim strRegreso As String = Request("intDetaCompaniaId")

            If Len(strRegreso) < 1 Then
                strRegreso = "0"
            End If

            Return CInt(strRegreso)
        End Get
    End Property

    '====================================================================
    ' Name       : intDetaSucursalid
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intDetaSucursalId() As Integer
        Get
            Dim strRegreso As String = Request("intDetaSucursalId")

            If Len(strRegreso) < 1 Then
                strRegreso = "0"
            End If

            Return CInt(strRegreso)
        End Get
    End Property

    '====================================================================
    ' Name       : strFacSucursal
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFacSucursal() As String
        Get
            Dim strPasoNombre As String = UCase(Request("strFacSucursal"))

            strPasoNombre = Replace(strPasoNombre, "Á", "A")
            strPasoNombre = Replace(strPasoNombre, "É", "E")
            strPasoNombre = Replace(strPasoNombre, "Í", "I")
            strPasoNombre = Replace(strPasoNombre, "Ó", "O")
            strPasoNombre = Replace(strPasoNombre, "Ú", "U")

            Return strPasoNombre
        End Get
    End Property

    '====================================================================
    ' Name       : strFacSucEmision
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFacSucEmision() As String
        Get
            Dim strRegreso As String = Request("strFacSucEmision")

            If Len(strRegreso) < 1 Then
                strRegreso = ""
            End If

            Return strRegreso
        End Get
    End Property

    '====================================================================
    ' Name       : strFacSucClienteRFC
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFacSucClienteRFC() As String
        Get
            Dim strRegreso As String = Request("strFacSucClienteRFC")

            If Len(strRegreso) < 1 Then
                strRegreso = ""
            End If

            Return strRegreso
        End Get
    End Property

    '====================================================================
    ' Name       : strFacSucImporte
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFacSucImporte() As String
        Get
            Dim strRegreso As String = Request("strFacSucImporte")

            If Len(strRegreso) < 1 Then
                strRegreso = ""
            End If

            Return strRegreso
        End Get
    End Property

    '====================================================================
    ' Name       : strFacSucEstado
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFacSucEstado() As String
        Get
            Dim strRegreso As String = Request("strFacSucEstado")

            If Len(strRegreso) < 1 Then
                strRegreso = ""
            End If

            Return strRegreso
        End Get
    End Property

    '====================================================================
    ' Name       : strFacSucCanceladaFecha
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFacSucCanceladaFecha() As String
        Get
            Dim strRegreso As String = Request("strFacSucCanceladaFecha")

            If Len(strRegreso) < 1 Then
                strRegreso = ""
            End If

            Return strRegreso
        End Get
    End Property


    '====================================================================
    ' Name       : strFacSucCanceladaPrefijo
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFacSucCanceladaPrefijo() As String
        Get
            Dim strRegreso As String = Request("strFacSucCanceladaPrefijo")

            If Len(strRegreso) < 1 Then
                strRegreso = ""
            End If

            Return strRegreso
        End Get
    End Property

    '====================================================================
    ' Name       : strFacSucCanceladaFolio
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFacSucCanceladaFolio() As String
        Get
            Dim strRegreso As String = Request("strFacSucCanceladaFolio")

            If Len(strRegreso) < 1 Then
                strRegreso = ""
            End If

            Return strRegreso
        End Get
    End Property

    '====================================================================
    ' Name       : strFacSucCanceladaMotivo
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFacSucCanceladaMotivo() As String
        Get
            Dim strRegreso As String = Request("strFacSucCanceladaMotivo")

            If Len(strRegreso) < 1 Then
                strRegreso = ""
            End If

            Return strRegreso
        End Get
    End Property
    '====================================================================
    ' Name       : strFacSucCanceladaPor
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFacSucCanceladaPor() As String
        Get
            Dim strRegreso As String = Request("strFacSucCanceladaPor")

            If Len(strRegreso) < 1 Then
                strRegreso = ""
            End If

            Return strRegreso
        End Get
    End Property

    '====================================================================
    ' Name       : strEncabezadoFactura
    ' Description: Genera el Record Browser con el detalle de la Factura
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Function strEncabezadoFactura() As String

        Dim strFacturaSucursalHTML As New StringBuilder

        If intDetaFacturaId > 0 Then

            Call strFacturaSucursalHTML.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0' class='tdenvolventetablas'>")

            Call strFacturaSucursalHTML.Append("<tr class='trtitulos'>")
            Call strFacturaSucursalHTML.Append("<th width='40%' class='rayita'>SUCURSAL</th>")
            Call strFacturaSucursalHTML.Append("<th width='10%' class='rayita'>FECHA</th>")
            Call strFacturaSucursalHTML.Append("<th width='20%' class='rayita'>R.F.C.</th>")
            Call strFacturaSucursalHTML.Append("<th width='30%' class='rayita'>TOTAL</th>")
            Call strFacturaSucursalHTML.Append("</tr>")

            Call strFacturaSucursalHTML.Append("<tr>")
            'strFacSucursal
            Call strFacturaSucursalHTML.Append("<td class='campotablaresultadoenvolventeazul'>" & clsCommons.strFormatearDescripcion(strFacSucursal) & "</td>")
            'strFacSucEmision
            Call strFacturaSucursalHTML.Append("<td class='campotablaresultadoenvolventeazul'>" & clsCommons.strFormatearFechaPresentacion(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFacSucEmision)) & "</td>")
            'strFacSucClienteRFC
            Call strFacturaSucursalHTML.Append("<td class='campotablaresultadoenvolventeazul'>" & clsCommons.strFormatearDescripcion(strFacSucClienteRFC) & "</td>")
            'strFacSucImporte
            Call strFacturaSucursalHTML.Append("<td class='campotablaresultadoenvolventeazul'>" & clsCommons.strFormatearNumeroPresentacion(strFacSucImporte, True) & "</td>")

            Call strFacturaSucursalHTML.Append("</tr>")

            Call strFacturaSucursalHTML.Append("</table>")
            Call strFacturaSucursalHTML.Append("<br>")

            If UCase(strFacSucEstado) = "CANCELADA" Then

                Call strFacturaSucursalHTML.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0' class='tdenvolventetablas'>")

                Call strFacturaSucursalHTML.Append("<tr class='trtitulos'>")
                Call strFacturaSucursalHTML.Append("<th width='100%' class='rayita' colspan='2'>DATOS CANCELACION</th>")
                Call strFacturaSucursalHTML.Append("</tr>")


                'dtmFacturaSucursalCanceladaFecha
                Call strFacturaSucursalHTML.Append("<tr>")
                Call strFacturaSucursalHTML.Append("<td width='20%' class='tdtittablas'>FECHA:</td>")
                Call strFacturaSucursalHTML.Append("<td width='80%' class='campotablaresultadoenvolventeazul'>" & clsCommons.strFormatearFechaPresentacion(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFacSucCanceladaFecha)) & "</td>")
                Call strFacturaSucursalHTML.Append("</tr>")

                'strFacturaSucursalCanceladaPrefijo -intFacturaSucursalCanceladaFolio
                Call strFacturaSucursalHTML.Append("<tr>")
                Call strFacturaSucursalHTML.Append("<td width='20%' class='tdtittablas'>FOLIO DOCUMENTO:</td>")
                Call strFacturaSucursalHTML.Append("<td width='80%' class='campotablaresultadoenvolventeazul'>" & clsCommons.strFormatearDescripcion(strFacSucCanceladaPrefijo) & " " & clsCommons.strFormatearDescripcion(strFacSucCanceladaFolio) & "</td>")
                Call strFacturaSucursalHTML.Append("</tr>")

                'strFacturaSucursalCanceladaPor
                Call strFacturaSucursalHTML.Append("<tr>")
                Call strFacturaSucursalHTML.Append("<td width='20%' class='tdtittablas'>AUTORIZO:</td>")
                Call strFacturaSucursalHTML.Append("<td width='80%' class='campotablaresultadoenvolventeazul'>" & clsCommons.strFormatearDescripcion(strFacSucCanceladaPor) & "</td>")
                Call strFacturaSucursalHTML.Append("</tr>")

                'strFacturaSucursalCanceladaMotivo
                Call strFacturaSucursalHTML.Append("<tr>")
                Call strFacturaSucursalHTML.Append("<td width='20%' class='tdtittablas'>MOTIVO:</td>")
                Call strFacturaSucursalHTML.Append("<td width='80%' class='campotablaresultadoenvolventeazul'>" & clsCommons.strFormatearDescripcion(strFacSucCanceladaMotivo) & "</td>")
                Call strFacturaSucursalHTML.Append("</tr>")

                Call strFacturaSucursalHTML.Append("</table>")
                Call strFacturaSucursalHTML.Append("<br>")

            End If

        End If

        Return clsCommons.strGenerateJavascriptString(strFacturaSucursalHTML.ToString)

    End Function

    Function strDesgloseImportes(ByVal intCajaImporteId As Integer, ByVal intTicketImporteId As Integer, ByVal strColorDetalle As String) As String

        Dim objArrayFacturaSucursalTicketImportes As Array = Nothing
        Dim objRegistroFacturaSucursalTicketImportes As System.Collections.SortedList = Nothing

        Dim strDesgloseImportesHTML As New StringBuilder

        Dim strImporteImpuestoEtiqueta As String
        Dim strImporteImpuestoMonto As String


        objArrayFacturaSucursalTicketImportes = clsFactura.strBuscarDetalleImportes(intDetaFacturaId, intDetaCompaniaId, intDetaSucursalId, intCajaImporteId, intTicketImporteId, 0, 0, strConnectionString)

        If IsArray(objArrayFacturaSucursalTicketImportes) AndAlso objArrayFacturaSucursalTicketImportes.Length > 0 Then

            Call strDesgloseImportesHTML.Append("<table width='100%' cellspacing='0' cellpadding='0'  border='0'>")

            For Each objRegistroFacturaSucursalTicketImportes In objArrayFacturaSucursalTicketImportes

                If CInt(objRegistroFacturaSucursalTicketImportes.Item("fltFacturaSucursalTicketImportesImpuestoMonto")) > 0 Then
                    strImporteImpuestoEtiqueta = "impuesto:"
                    strImporteImpuestoMonto = clsCommons.strFormatearNumeroPresentacion(CStr(objRegistroFacturaSucursalTicketImportes.Item("fltFacturaSucursalTicketImportesImpuestoMonto")), True)
                Else
                    strImporteImpuestoEtiqueta = "&nbsp;"
                    strImporteImpuestoMonto = "&nbsp;"
                End If

                Call strDesgloseImportesHTML.Append("<tr>")
                Call strDesgloseImportesHTML.Append("<td width='10%' align='left'  class=" & strColorDetalle & ">TASA</td>")
                Call strDesgloseImportesHTML.Append("<td width='05%' align='right' class=" & strColorDetalle & ">" & clsCommons.strFormatearDescripcion(CInt(objRegistroFacturaSucursalTicketImportes.Item("fltFacturaSucursalTicketImportesImpuestoValor")).ToString) & "</td>")

                Call strDesgloseImportesHTML.Append("<td width='15%' align='right' class=" & strColorDetalle & ">subtotal:</td>")
                Call strDesgloseImportesHTML.Append("<td width='30%' align='right' class=" & strColorDetalle & ">" & clsCommons.strFormatearNumeroPresentacion(CStr(objRegistroFacturaSucursalTicketImportes.Item("fltFacturaSucursalTicketImportesSubTotal")), True) & "</td>")

                Call strDesgloseImportesHTML.Append("<td width='15%' align='right' class=" & strColorDetalle & ">" & strImporteImpuestoEtiqueta & "</td>")
                Call strDesgloseImportesHTML.Append("<td width='25%' align='right' class=" & strColorDetalle & ">" & strImporteImpuestoMonto & "</td>")

                Call strDesgloseImportesHTML.Append("</tr>")

            Next

            Call strDesgloseImportesHTML.Append("</table>")

        End If

        Return strDesgloseImportesHTML.ToString


    End Function

    '====================================================================
    ' Name       : strGeneraRecordBrowserHTML
    ' Description: Genera el Record Browser con el detalle de la Factura
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Function strGeneraRecordBrowserHTML() As String

        ' Declaracion de Variables
        Dim objArrayFacturaSucursalTicket As Array = Nothing
        Dim objRegistroFacturaSucursalTicket As System.Collections.SortedList = Nothing

        Dim strFacturaSucursalTicketHTML As New StringBuilder

        Dim intConsecutivo As Integer = 0
        Dim strColorRegistro As String = ""
        Dim strColorRegistro2 As String = ""
        Dim intCajaImporteId As Integer
        Dim intTicketImporteId As Integer

        'Obtenemos el detalle de la Factura

        objArrayFacturaSucursalTicket = clsFactura.strBuscarDetalle(intDetaFacturaId, intDetaCompaniaId, intDetaSucursalId, 0, 0, strConnectionString)

        If IsArray(objArrayFacturaSucursalTicket) AndAlso objArrayFacturaSucursalTicket.Length > 0 Then

            Call strFacturaSucursalTicketHTML.Append("<table width='100%' cellspacing='0' cellpadding='0' border='0'>")

            Call strFacturaSucursalTicketHTML.Append("<tr class='trtitulos'>")
            Call strFacturaSucursalTicketHTML.Append("<th width='05%' class='rayita'>No.Caja</th>")
            Call strFacturaSucursalTicketHTML.Append("<th width='10%' class='rayita'>No.Ticket</th>")
            Call strFacturaSucursalTicketHTML.Append("<th width='15%' class='rayita'>Fec.Ticket</th>")
            Call strFacturaSucursalTicketHTML.Append("<th width='15%' class='rayita'>Monto Ticket</th>")
            Call strFacturaSucursalTicketHTML.Append("<th width='40%' class='rayita'>&nbsp;</th>")
            Call strFacturaSucursalTicketHTML.Append("</tr>")

            intConsecutivo += 1

            For Each objRegistroFacturaSucursalTicket In objArrayFacturaSucursalTicket

                If (intConsecutivo Mod 2) <> 0 Then
                    strColorRegistro = "'tdblanco'"
                    strColorRegistro2 = "'tdblanco2'"
                Else
                    strColorRegistro = "'tdceleste'"
                    strColorRegistro2 = "'tdceleste2'"
                End If

                intCajaImporteId = CInt(objRegistroFacturaSucursalTicket.Item("intCajaId"))
                intTicketImporteId = CInt(objRegistroFacturaSucursalTicket.Item("intTicketId"))

                'Pintado de cada Registro

                Call strFacturaSucursalTicketHTML.Append("<tr>")

                'intCajaId
                Call strFacturaSucursalTicketHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(CStr(objRegistroFacturaSucursalTicket.Item("intCajaId"))) & "</td>")

                'intTicketId
                Call strFacturaSucursalTicketHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(CStr(objRegistroFacturaSucursalTicket.Item("intTicketId"))) & "</td>")

                'dtmTicketFechaCreacion
                Call strFacturaSucursalTicketHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(CStr(objRegistroFacturaSucursalTicket.Item("dtmTicketFechaCreacion"))) & "</td>")

                'fltFacturaSucursalTicketImporteTotal
                Call strFacturaSucursalTicketHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearNumeroPresentacion(CStr(objRegistroFacturaSucursalTicket.Item("fltFacturaSucursalTicketImporteTotal")), True) & "</td>")

                'Desglose Importes
                Call strFacturaSucursalTicketHTML.Append("<td class=" & strColorRegistro & ">")
                Call strFacturaSucursalTicketHTML.Append(strDesgloseImportes(intCajaImporteId, intTicketImporteId, strColorRegistro2))
                Call strFacturaSucursalTicketHTML.Append("</td>")


                Call strFacturaSucursalTicketHTML.Append("</tr>")

                intConsecutivo += 1
            Next

            Call strFacturaSucursalTicketHTML.Append("</table>")
            Call strFacturaSucursalTicketHTML.Append("<br>")

        End If

        Return clsCommons.strGenerateJavascriptString(strFacturaSucursalTicketHTML.ToString)


    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

End Class
