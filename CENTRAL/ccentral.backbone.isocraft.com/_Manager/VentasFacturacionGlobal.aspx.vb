Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

Imports System.Text
Imports System.Collections

Imports Benavides.CC.Data
Imports Benavides.POSAdmin.Commons


Public Class VentasFacturacionGlobal

    Inherits System.Web.UI.Page


#Region " Web Form Designer Generated Code "

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Init

        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        'Put user code to initialize the page here
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        'Inicializa Propiedades

        intMesId = GetPageParameter("cboMes", 0)
        intDireccionOperativaId = GetPageParameter("cboDireccion", 0)
        intZonaOperativaId = GetPageParameter("cboZona", 0)
        strSucursalId = GetPageParameter("cboSucursal", "")
        intoptDiasFaltantes = GetPageParameter("intoptDiasFaltantes", GetPageParameter("optDiasFaltantes", 0))

    End Sub

#End Region

#Region " Class Private Attributes"

    Const strComitasDobles As String = """"
    Private strmJavascriptWindowOnLoadCommands As String

    Private intmMesId As Integer
    Private intmDireccionOperativaId As Integer
    Private intmZonaOperativaId As Integer
    Private strmSucursalId As String
    Private intmoptDiasFaltantes As Integer

    Private strmcboMes As String
    Private strmcboDireccion As String
    Private strmcboZona As String
    Private strmCboSucursal As String


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
            Return Request("strCmd")
        End Get
    End Property

    '====================================================================
    ' Name       : strLlenarMesComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboDireccion"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarMesComboBox() As String

        Dim dtmMes1 As DateTime = Now.AddMonths(-5)
        Dim dtmMes2 As DateTime = Now.AddMonths(-4)
        Dim dtmMes3 As DateTime = Now.AddMonths(-3)
        Dim dtmMes4 As DateTime = Now.AddMonths(-2)
        Dim dtmMes5 As DateTime = Now.AddMonths(-1)
        Dim dtmMes6 As DateTime = Now

        Dim strRetorno As New StringBuilder
        Dim strSel As String = "0"

        If intMesId = Month(dtmMes1) Then
            strSel = "1"
        End If
        If intMesId = Month(dtmMes2) Then
            strSel = "2"
        End If
        If intMesId = Month(dtmMes3) Then
            strSel = "3"
        End If
        If intMesId = Month(dtmMes4) Then
            strSel = "4"
        End If
        If intMesId = Month(dtmMes5) Then
            strSel = "5"
        End If
        If intMesId = Month(dtmMes6) Then
            strSel = "6"
        End If

        strRetorno.Append("document.forms[0].elements[" & strComitasDobles & "cboMes" & strComitasDobles & "].options[1] = new Option(" & strComitasDobles & clsCommons.strNombreMes(dtmMes1) & strComitasDobles & " , " & Month(dtmMes1).ToString & ");")
        strRetorno.Append("document.forms[0].elements[" & strComitasDobles & "cboMes" & strComitasDobles & "].options[2] = new Option(" & strComitasDobles & clsCommons.strNombreMes(dtmMes2) & strComitasDobles & " , " & Month(dtmMes2).ToString & ");")
        strRetorno.Append("document.forms[0].elements[" & strComitasDobles & "cboMes" & strComitasDobles & "].options[3] = new Option(" & strComitasDobles & clsCommons.strNombreMes(dtmMes3) & strComitasDobles & " , " & Month(dtmMes3).ToString & ");")
        strRetorno.Append("document.forms[0].elements[" & strComitasDobles & "cboMes" & strComitasDobles & "].options[4] = new Option(" & strComitasDobles & clsCommons.strNombreMes(dtmMes4) & strComitasDobles & " , " & Month(dtmMes4).ToString & ");")
        strRetorno.Append("document.forms[0].elements[" & strComitasDobles & "cboMes" & strComitasDobles & "].options[5] = new Option(" & strComitasDobles & clsCommons.strNombreMes(dtmMes5) & strComitasDobles & " , " & Month(dtmMes5).ToString & ");")
        strRetorno.Append("document.forms[0].elements[" & strComitasDobles & "cboMes" & strComitasDobles & "].options[6] = new Option(" & strComitasDobles & clsCommons.strNombreMes(dtmMes6) & strComitasDobles & " , " & Month(dtmMes6).ToString & ");")

        strRetorno.Append("document.forms[0].elements[" & strComitasDobles & "cboMes" & strComitasDobles & "].options[" & strSel & "].selected=true;")


        Return strRetorno.ToString


    End Function

    '====================================================================
    ' Name       : strLlenarDireccionComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboDireccion"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarDireccionComboBox() As String

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccion", intDireccionOperativaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString), 0, 1, 2)

    End Function

    '====================================================================
    ' Name       : strLlenarZonaComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboZona"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarZonaComboBox() As String
        If intDireccionOperativaId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZona", intZonaOperativaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionOperativaId, 0, strConnectionString), 0, 1, 2)
        End If
    End Function

    '====================================================================
    ' Name       : strLlenarSucursalComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboSucursal"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String

    '====================================================================
    Public Function strLlenarSucursalComboBox() As String

        If intDireccionOperativaId > 0 AndAlso intZonaOperativaId > 0 Then

            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSucursal", strSucursalId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionOperativaId, intZonaOperativaId, strConnectionString), New Integer(1) {0, 1}, 2, 2)

        End If

    End Function

    '====================================================================
    ' Name       : intMesId 
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intMesId() As Integer
        Get
            Return intmMesId
        End Get
        Set(ByVal intValue As Integer)
            intmMesId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intDireccionOperativaId 
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intDireccionOperativaId() As Integer
        Get
            Return intmDireccionOperativaId
        End Get
        Set(ByVal intValue As Integer)
            intmDireccionOperativaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intZonaOperativaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intZonaOperativaId() As Integer
        Get
            Return intmZonaOperativaId
        End Get
        Set(ByVal intValue As Integer)
            intmZonaOperativaId = intValue
        End Set
    End Property

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

    Public ReadOnly Property intCompaniaid() As Integer
        Get
            Dim intmCompaniaid As Integer = 0

            If Len(strSucursalId) > 3 Then
                Dim astrCompaniaSucursal As Array = Split(strSucursalId, "|")
                If astrCompaniaSucursal.Length > 0 Then
                    intmCompaniaid = CInt(astrCompaniaSucursal.GetValue(0))
                End If
            End If

            Return intmCompaniaid

        End Get

    End Property

    Public ReadOnly Property intSucursalid() As Integer
        Get
            Dim intmSucursalid As Integer = 0

            If Len(strSucursalId) > 3 Then
                Dim astrCompaniaSucursal As Array = Split(strSucursalId, "|")
                If astrCompaniaSucursal.Length > 0 Then
                    intmSucursalid = CInt(astrCompaniaSucursal.GetValue(1))
                End If
            End If

            Return intmSucursalid

        End Get

    End Property

    '====================================================================
    ' Name       : intoptDiasFaltantes
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intoptDiasFaltantes() As Integer
        Get
            Return intmoptDiasFaltantes
        End Get
        Set(ByVal strValue As Integer)
            intmoptDiasFaltantes = strValue
        End Set
    End Property

    Public ReadOnly Property strRecordBrowser() As String
        Get
            If Len(strConsultarFacturas) > 0 Then
                Return strConsultarFacturas()
            Else
                Return strConsultarSucursales()
            End If

        End Get

    End Property
    
    '====================================================================
    ' Name       : strConsultarSucursales
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strConsultarSucursales() As String

        Dim strMesConsulta As String = "---"
        Dim intSucursalesIncluidas As String = "---"
        Dim fltTotalSucursales As String = "---"
        Dim fltTotalExcento As String = "---"
        Dim fltSubTotalTasa10 As String = "---"
        Dim fltImporteImpuestoTasa10 As String = "---"
        Dim fltTotalTasa10 As String = "---"
        Dim fltSubTotalTasa15 As String = "---"
        Dim fltImporteImpuestoTasa15 As String = "---"
        Dim fltTotalTasa15 As String = "---"

        Dim htmlResult As String = ""
        Dim strHTMLRetorno As New StringBuilder

        If intDireccionOperativaId = -1 Then
            intZonaOperativaId = -1
        End If

        If intZonaOperativaId = -1 Then
            strSucursalId = "-1|-1"
        End If

        If intMesId <> 0 And intDireccionOperativaId <> 0 And intZonaOperativaId <> 0 And Len(strSucursalId) > 0 Then

            Dim objDataArrayTotales As Array = clsFacturaElectronicaGlobal.strBuscarTotales(intDireccionOperativaId, intZonaOperativaId, intCompaniaid, intSucursalid, intMesId, intoptDiasFaltantes, 0, 0, 0, strConnectionString)

            If IsArray(objDataArrayTotales) = True AndAlso objDataArrayTotales.Length > 0 Then

                Dim strDataRowTotales As String() = Nothing

                strDataRowTotales = DirectCast(objDataArrayTotales.GetValue(0), String())

                strMesConsulta = clsCommons.strNombreMes(CDate(Mid(CStr(strDataRowTotales(0)), 4, 2) & "/01/" & Now.Year.ToString))

                intSucursalesIncluidas = CStr(strDataRowTotales(1))

                fltTotalExcento = clsCommons.strFormatearNumeroPresentacion(CStr(strDataRowTotales(2)), True)

                fltSubTotalTasa10 = clsCommons.strFormatearNumeroPresentacion(CStr(strDataRowTotales(3)), True)
                fltImporteImpuestoTasa10 = clsCommons.strFormatearNumeroPresentacion(CStr(strDataRowTotales(4)), True)
                fltTotalTasa10 = clsCommons.strFormatearNumeroPresentacion(CStr(strDataRowTotales(5)), True)

                fltSubTotalTasa15 = clsCommons.strFormatearNumeroPresentacion(CStr(strDataRowTotales(6)), True)
                fltImporteImpuestoTasa15 = clsCommons.strFormatearNumeroPresentacion(CStr(strDataRowTotales(7)), True)
                fltTotalTasa15 = clsCommons.strFormatearNumeroPresentacion(CStr(strDataRowTotales(8)), True)

                fltTotalSucursales = clsCommons.strFormatearNumeroPresentacion(CStr(CDbl(strDataRowTotales(2)) + CDbl(strDataRowTotales(5)) + CDbl(strDataRowTotales(8))), True)

                strHTMLRetorno.Append("<span class='txsubtitulo'><img src='../static/images/bullet_subtitulos.gif' width='17' height='11' align='absMiddle'>Totales</span>")

                strHTMLRetorno.Append("<table width='100%' class='tdEnvolventeTablaGris' cellspacing='0' cellpadding='0' border='0'>")
                strHTMLRetorno.Append("<tr class='RBTitulos'>")
                strHTMLRetorno.Append("<td width='05%' class='rayita' valign='middle'>Mes:</td>")
                strHTMLRetorno.Append("<td width='25%' class='rayita' valign='middle' align='left' style='font-weight: bold;color: #525698;'>" & strMesConsulta & "</td>")
                strHTMLRetorno.Append("<td width='10%' class='rayita' valign='middle'>Sucursales:</td>")
                strHTMLRetorno.Append("<td width='10%' class='rayita' valign='middle' align='left' style='font-weight: bold;color: #525698;'>" & intSucursalesIncluidas & "</td>")
                strHTMLRetorno.Append("<td width='25%' class='rayita' valign='middle'><a onclick='doSubmit(""VerDetalleMes"")' class='txaccion'><img src='../static/images/icono_lupa.gif' width='17' height='17' alt='Haga clic aquí para ver el mes detallado' border='0' ></a>&nbsp;Ver Detalle</td>")
                strHTMLRetorno.Append("<td width='25%' class='rayita' valign='middle'><a onclick='doSubmit(""GenerarMes"")' class='txaccion'><img src='../static/images/icono_capturar.gif' width='17' height='17' alt='Haga clic aquí para generar las facturas del mes seleccionado' border='0' ></a>&nbsp;Generar</td>")
                strHTMLRetorno.Append("</tr>")

                strHTMLRetorno.Append("</table>")
                strHTMLRetorno.Append("<br>")

                strHTMLRetorno.Append("<table width='100%' class='tdEnvolventeTablaGris' cellspacing='0' cellpadding='0' border='0'>")

                strHTMLRetorno.Append("<tr class='RBTitulos'>")
                strHTMLRetorno.Append("<th class='rayita' align='left'  valign='top'>&nbsp;</th>")
                strHTMLRetorno.Append("<th class='rayita' align='right' valign='top'>SubTotal</th>")
                strHTMLRetorno.Append("<th class='rayita' align='right' valign='top'>Importe Impuesto</th>")
                strHTMLRetorno.Append("<th class='rayita' align='right' valign='top'>Total</th>")
                strHTMLRetorno.Append("</tr>")

                strHTMLRetorno.Append("<tr>")
                strHTMLRetorno.Append("<td class='RBTdBlanco' align='right' valign='top' style='font-weight: bold'>Tasa 0</td>")
                strHTMLRetorno.Append("<td class='RBTdBlanco' align='right' valign='top'>---</td>")
                strHTMLRetorno.Append("<td class='RBTdBlanco' align='right' valign='top'>---</td>")
                strHTMLRetorno.Append("<td class='RBTdBlanco' align='right' valign='top'>" & fltTotalExcento & "</td>")
                strHTMLRetorno.Append("</tr>")

                strHTMLRetorno.Append("<tr>")
                strHTMLRetorno.Append("<td class='RBTdAzul' align='right' valign='top' style='font-weight: bold'>Tasa 11</td>")
                strHTMLRetorno.Append("<td class='RBTdAzul' align='right' valign='top'>" & fltSubTotalTasa10 & "</td>")
                strHTMLRetorno.Append("<td class='RBTdAzul' align='right' valign='top'>" & fltImporteImpuestoTasa10 & "</td>")
                strHTMLRetorno.Append("<td class='RBTdAzul' align='right' valign='top'>" & fltTotalTasa10 & "</td>")
                strHTMLRetorno.Append("</tr>")

                strHTMLRetorno.Append("<tr>")
                strHTMLRetorno.Append("<td class='RBTdBlanco' align='right' valign='top' style='font-weight: bold'>Tasa 16</td>")
                strHTMLRetorno.Append("<td class='RBTdBlanco' align='right' valign='top'>" & fltSubTotalTasa15 & "</td>")
                strHTMLRetorno.Append("<td class='RBTdBlanco' align='right' valign='top'>" & fltImporteImpuestoTasa15 & "</td>")
                strHTMLRetorno.Append("<td class='RBTdBlanco' align='right' valign='top'>" & fltTotalTasa15 & "</td>")
                strHTMLRetorno.Append("</tr>")

                strHTMLRetorno.Append("<tr>")
                strHTMLRetorno.Append("<td class='RBTdAzul' align='right' colspan='4' style='font-weight: bold'>" & fltTotalSucursales & "</td>")
                strHTMLRetorno.Append("</tr>")

                strHTMLRetorno.Append("</table><br>")

            End If

            ' Declaramos e inicializamos las constantes locales

            Dim strRecordBrowserName As String = "VentasFacturacionGlobal"

            ' Declaramos e inicialziamos las variables locales
            Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))

            If intSelectedPage <= 0 Then
                intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
            End If

            Dim objDataArraySucursales As Array = clsFacturaElectronicaGlobal.strBuscar(intDireccionOperativaId, intZonaOperativaId, intCompaniaid, intSucursalid, intMesId, intoptDiasFaltantes, 0, 0, strConnectionString)

            Dim maxPerPage As Integer = 15

            Dim headers As ArrayList = New ArrayList
            headers.Add("Sucursal")
            headers.Add("Nombre")
            headers.Add("Dias Registrados")
            headers.Add("Dias Faltantes")
            headers.Add("Total")
            headers.Add("Acciones")
            Dim columnOrder As Integer() = {3, 4, 5, 6, 7}

            Dim pkNames As String() = {"intCompaniaVerId", "intSucursalVerId", "intMesVenta"}
            Dim pkIndexes As Integer() = {0, 1, 2}

            Dim actions As ArrayList = New ArrayList
            actions.Add(New Benavides.CC.Commons.clsActionLink("VerDetallaSucursal", pkNames, pkIndexes, "imgNRVer.gif", "Haga clic aquí para ver el detalle de la sucursal"))

            htmlResult = strHTMLRetorno.ToString
            htmlResult &= "<span class='txsubtitulo'><img src='../static/images/bullet_subtitulos.gif' width='17' height='11' align='absMiddle'>Sucursales</span> "
            htmlResult &= Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objDataArraySucursales.Length, intSelectedPage, maxPerPage, "VentasFacturacionGlobal.aspx", Nothing)
            htmlResult &= Benavides.CC.Commons.clsRecordBrowserNew.displayTable(headers, objDataArraySucursales, columnOrder, actions, intSelectedPage, maxPerPage, -1)

        End If

        Return htmlResult

    End Function

    '====================================================================
    ' Name       : strConsultarFacturas
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strConsultarFacturas() As String

        Dim htmlResult As String = ""

        If intDireccionOperativaId = -1 Then
            intZonaOperativaId = -1
        End If

        If intZonaOperativaId = -1 Then
            strSucursalId = "-1|-1"
        End If

        If intMesId <> 0 And intDireccionOperativaId <> 0 And intZonaOperativaId <> 0 And Len(strSucursalId) > 0 Then
            ' Declaramos e inicializamos las constantes locales

            Dim strRecordBrowserName As String = "VentasFacturacionGlobal"

            ' Declaramos e inicialziamos las variables locales
            Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))

            If intSelectedPage <= 0 Then
                intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
            End If

            Dim objDataArrayFacturasMes As Array = clsFacturaElectronicaGlobal.strBuscarMesGenerado(intMesId, 0, 0, strConnectionString)

            If IsArray(objDataArrayFacturasMes) AndAlso objDataArrayFacturasMes.Length > 0 Then

                Dim maxPerPage As Integer = 32

                Dim headers As ArrayList = New ArrayList
                headers.Add("Fecha Factura")
                headers.Add("Sucursales")
                headers.Add("Total Facturado")
                headers.Add("Total Tasa 0")
                headers.Add("SubTotal Tasa 11 ")
                headers.Add("Impuesto Tasa 11 ")
                headers.Add("Total Tasa 11 ")
                headers.Add("SubTotal Tasa 16 ")
                headers.Add("Impuesto Tasa 16 ")
                headers.Add("Total Tasa 16 ")

                Dim columnOrder As Integer() = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}

                htmlResult = "<span class='txsubtitulo'><img src='../static/images/bullet_subtitulos.gif' width='17' height='11' align='absMiddle'>Facuras del mes ya generadas</span> "
                htmlResult &= Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objDataArrayFacturasMes.Length, intSelectedPage, maxPerPage, "VentasFacturacionGlobal.aspx", Nothing)
                htmlResult &= Benavides.CC.Commons.clsRecordBrowserNew.displayTable(headers, objDataArrayFacturasMes, columnOrder, Nothing, intSelectedPage, maxPerPage, -1)

            End If

        End If

        Return htmlResult

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

End Class
