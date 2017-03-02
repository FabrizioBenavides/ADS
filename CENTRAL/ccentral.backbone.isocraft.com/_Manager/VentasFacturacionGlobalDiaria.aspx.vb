Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

Imports System.Text
Imports System.Collections

Imports Benavides.CC.Data
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business.clsConcentrador.clsSucursal
Imports prjRemoteXmlWriter



Public Class VentasFacturacionGlobalDiaria

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

        intCadenaId = GetPageParameter("cboCadena", 0)
        intMes = GetPageParameter("cboMes", 0)
        intAnio = GetPageParameter("cboAnio", 0)


    End Sub

#End Region

#Region " Class Private Attributes"

    Const strComitasDobles As String = """"
    Private strmJavascriptWindowOnLoadCommands As String

    Private intmCadenaId As Integer
    Private intmMes As Integer
    Private intmAnio As Integer

    Private strmcboMes As String
    Private strmcboAnio As String

    Private strRutaXml As String
    Private strFolioPrefijo As String

    Private dtmFechaVenta As Date
    Private intSucursalesVigentes As Integer
    Private intSucursalesTrasmitidas As Integer

    Private fltTotalTasaCero As Double

    Private fltSubTotalTasaFrontera As Double
    Private fltImporteImpuestoTasaFrontera As Double
    Private fltTotalTasaFrontera As Double

    Private fltSubTotalTasaInterior As Double
    Private fltImporteImpuestoTasaInterior As Double
    Private fltTotalTasaInterior As Double
    Private blnGenerado As Boolean

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
    ' Name       : strLlenarComboBoxAnio
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboAnio
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarComboBoxAnio() As String

        Dim dtmMes As DateTime
        Dim strComboBoxAnio As New StringBuilder
        Dim intComboBoxAnio As Integer = 0


        For intAnioCbo As Integer = Year(Now) - 5 To Year(Now)
            intComboBoxAnio += 1

            strComboBoxAnio.Append("document.forms[0].elements[" & strComitasDobles & "cboAnio" & strComitasDobles & "].options[" & intComboBoxAnio.ToString & "] = new Option(" & strComitasDobles & intAnioCbo.ToString & strComitasDobles & " , " & intAnioCbo.ToString & ");")

            If intAnioCbo = intAnio Then
                strComboBoxAnio.Append("document.forms[0].elements[" & strComitasDobles & "cboAnio" & strComitasDobles & "].options[" & intComboBoxAnio.ToString & "].selected=true;")
            End If

        Next

        Return strComboBoxAnio.ToString


    End Function

    '====================================================================
    ' Name       : strLlenarComboBoxMes
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboMes"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarComboBoxMes() As String

        Dim dtmMes As DateTime
        Dim strComboBoxMes As New StringBuilder

        For intMesCbo As Integer = 1 To 12
            dtmMes = CDate(intMesCbo.ToString("00") & "/01/" & Year(Now).ToString("0000"))

            strComboBoxMes.Append("document.forms[0].elements[" & strComitasDobles & "cboMes" & strComitasDobles & "].options[" & intMesCbo.ToString & "] = new Option(" & strComitasDobles & clsCommons.strNombreMes(dtmMes) & strComitasDobles & " , " & intMesCbo.ToString & ");")

            If intMes = intMesCbo Then
                strComboBoxMes.Append("document.forms[0].elements[" & strComitasDobles & "cboMes" & strComitasDobles & "].options[" & intMesCbo.ToString & "].selected=true;")
            End If

        Next

        Return strComboBoxMes.ToString

    End Function

    '====================================================================
    ' Name       : intCadenaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intCadenaId() As Integer
        Get
            Return intmCadenaId
        End Get
        Set(ByVal intValue As Integer)
            intmCadenaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intAnio
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intAnio() As Integer
        Get
            Return intmAnio
        End Get
        Set(ByVal intValue As Integer)
            intmAnio = intValue
        End Set
    End Property


    '====================================================================
    ' Name       : intMes
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intMes() As Integer
        Get
            Return intmMes
        End Get
        Set(ByVal intValue As Integer)
            intmMes = intValue
        End Set
    End Property


    '====================================================================
    ' Name       : strConsultarFacturas
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strConsultarFacturas() As String


        Dim strHTML As New StringBuilder

        Dim intConsecutivo As Integer = 0
        Dim strColorRegistro As String = ""
        Dim intCantidad As Integer = 0
        Dim strDiaVenta As String = ""

        Dim objFacturaSucursalGlobal As Array = Nothing
        Dim objRegistroFacturaSucursalGlobal As System.Collections.SortedList = Nothing


        If intAnio <> 0 And intMes <> 0 Then

            objFacturaSucursalGlobal = clsFacturaSucursalGlobal.strBuscar(intCadenaId, 0, intMes, intAnio, True, strConnectionString)

            If IsArray(objFacturaSucursalGlobal) AndAlso objFacturaSucursalGlobal.Length > 0 Then

                strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

                strHTML.Append("<tr class='trtitulos2'>")
                strHTML.Append("<th width='04%' class='rayita' style='background-color:#F4F6F8;' align='left'>No.</th>")
                strHTML.Append("<th width='06%' class='rayita' style='background-color:#FFFFFF;' align='left'>Fecha Venta</th>")
                strHTML.Append("<th width='05%' class='rayita' style='background-color:#F4F6F8;' align='left'>Suc Vig</th>")
                strHTML.Append("<th width='05%' class='rayita' style='background-color:#FFFFFF;' align='left'>Suc Reg</th>")

                strHTML.Append("<th width='10%' class='rayita' style='background-color:#F4F6F8;' align='left'>T.Cero Total </th>")

                strHTML.Append("<th width='10%' class='rayita' style='background-color:#FFFFFF;' align='left'>T.Frontera SubTotal</th>")
                strHTML.Append("<th width='10%' class='rayita' style='background-color:#F4F6F8;' align='left'>T.Frontera Impuesto</th>")
                strHTML.Append("<th width='10%' class='rayita' style='background-color:#FFFFFF;' align='left'>T.Frontera Total</th>")

                strHTML.Append("<th width='10%' class='rayita' style='background-color:#F4F6F8;' align='left'>T.Interior SubTotal</th>")
                strHTML.Append("<th width='10%' class='rayita' style='background-color:#FFFFFF;' align='left'>T.Interior Impuesto</th>")
                strHTML.Append("<th width='10%' class='rayita' style='background-color:#F4F6F8;' align='left'>T.Interior Total</th>")
                strHTML.Append("<th width='10%' class='rayita' style='background-color:#FFFFFF;' align='center'>Acci&oacute;n</th>")
                strHTML.Append("</tr>")

                For Each objRegistroFacturaSucursalGlobal In objFacturaSucursalGlobal

                    intConsecutivo += 1

                    If (intConsecutivo Mod 2) <> 0 Then
                        strColorRegistro = "'tddetalle'"
                    Else
                        strColorRegistro = "'tddetalle'"
                    End If

                    strDiaVenta = clsCommons.strFormatearFechaPresentacion(CStr(objRegistroFacturaSucursalGlobal.Item("dtmFechaVenta")))

                    strHTML.Append("<tr>")

                    strHTML.Append("<td class=" & strColorRegistro & " style='background-color:#F4F6F8;' align='right'>" & intConsecutivo.ToString & "</td>")
                    strHTML.Append("<td class=" & strColorRegistro & " style='background-color:#FFFFFF;' align='right'>" & clsCommons.strFormatearFechaPresentacion(CStr(objRegistroFacturaSucursalGlobal.Item("dtmFechaVenta"))) & "</td>")
                    strHTML.Append("<td class=" & strColorRegistro & " style='background-color:#F4F6F8;' align='right'>" & CStr(objRegistroFacturaSucursalGlobal.Item("intSucursalesVigentes")) & "</td>")
                    strHTML.Append("<td class=" & strColorRegistro & " style='background-color:#FFFFFF;' align='right'>" & CStr(objRegistroFacturaSucursalGlobal.Item("intSucursalesTrasmitidas")) & "</td>")
                    strHTML.Append("<td class=" & strColorRegistro & " style='background-color:#F4F6F8;' align='right'>" & clsCommons.strFormatearNumeroPresentacion(CStr(objRegistroFacturaSucursalGlobal.Item("fltTotalTasaCero")), False) & "</td>")
                    strHTML.Append("<td class=" & strColorRegistro & " style='background-color:#FFFFFF;' align='right'>" & clsCommons.strFormatearNumeroPresentacion(CStr(objRegistroFacturaSucursalGlobal.Item("fltSubTotalTasaFrontera")), False) & "</td>")
                    strHTML.Append("<td class=" & strColorRegistro & " style='background-color:#F4F6F8;' align='right'>" & clsCommons.strFormatearNumeroPresentacion(CStr(objRegistroFacturaSucursalGlobal.Item("fltImporteImpuestoTasaFrontera")), False) & "</td>")
                    strHTML.Append("<td class=" & strColorRegistro & " style='background-color:#FFFFFF;' align='right'>" & clsCommons.strFormatearNumeroPresentacion(CStr(objRegistroFacturaSucursalGlobal.Item("fltTotalTasaFrontera")), False) & "</td>")
                    strHTML.Append("<td class=" & strColorRegistro & " style='background-color:#F4F6F8;' align='right'>" & clsCommons.strFormatearNumeroPresentacion(CStr(objRegistroFacturaSucursalGlobal.Item("fltSubTotalTasaInterior")), False) & "</td>")
                    strHTML.Append("<td class=" & strColorRegistro & " style='background-color:#FFFFFF;' align='right'>" & clsCommons.strFormatearNumeroPresentacion(CStr(objRegistroFacturaSucursalGlobal.Item("fltImporteImpuestoTasaInterior")), False) & "</td>")
                    strHTML.Append("<td class=" & strColorRegistro & " style='background-color:#F4F6F8;' align='right'>" & clsCommons.strFormatearNumeroPresentacion(CStr(objRegistroFacturaSucursalGlobal.Item("fltTotalTasaInterior")), False) & "</td>")
                    strHTML.Append("<td class=" & strColorRegistro & " style='background-color:#FFFFFF;' align='center'>")
                    strHTML.Append("<a href=javascript:cmdVerSucursales_onclick(" & intCadenaId.ToString & ",'" & strDiaVenta & "',0);><img src='../static/images/imgNRTodo.gif'       alt='Ver Sucursales'  width='11' height='13' border='0' align='absmiddle'></a>&nbsp;")
                    strHTML.Append("<a href=javascript:cmdVerSucursales_onclick(" & intCadenaId.ToString & ",'" & strDiaVenta & "',1);><img src='../static/images/imgNRFaltante.gif'   alt='Ver Faltantes'   width='11' height='13' border='0' align='absmiddle'></a>&nbsp;")
                    strHTML.Append("<a href=javascript:cmdVerSucursales_onclick(" & intCadenaId.ToString & ",'" & strDiaVenta & "',2);><img src='../static/images/imgNRTrasmitido.gif' alt='Ver Trasmitidos' width='11' height='13' border='0' align='absmiddle'></a>&nbsp;")
                    strHTML.Append("<a href=javascript:cmdGeneraFactura_onclick('" & strDiaVenta & "');><img src='../static/images/imgNRArchivo.gif'    alt='Generar Factura' width='11' height='13' border='0' align='absmiddle'></a>")
                    strHTML.Append("</td>") ' acciones
                    strHTML.Append("</tr>")

                Next

                strHTML.Append("</table>")

            End If

        End If

        Return strHTML.ToString

    End Function

    '====================================================================
    ' Name       : strFechaVenta
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFechaVenta() As String
        Get
            Return Request("strFechaVenta")
        End Get
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strHTML As New StringBuilder

        Select Case strCmd

            Case "buscar"

                strHTML.Append("<script language='Javascript'> parent.fnUpConsultar( " & _
                         strComitasDobles & strConsultarFacturas() & strComitasDobles & _
                       "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "Generar"

                Dim strRegreso As String = ""

                Dim objDatosFiscales As Array = clsFacturaSucursalGlobal.strDatosFiscales(intCadenaId, strConnectionString)

                If IsArray(objDatosFiscales) AndAlso objDatosFiscales.Length > 0 Then

                    Dim strRegistroDatosFacturacion As System.Collections.SortedList = DirectCast(objDatosFiscales.GetValue(0), System.Collections.SortedList)

                    With strRegistroDatosFacturacion
                        strRutaXml = .Item("strFacturaSucursalGlobalDatosFiscalesRutaXml").ToString
                        strFolioPrefijo = .Item("strFacturaSucursalGlobalDatosFiscalesPrefijo").ToString
                    End With

                    'se debe poner true blnMesDetallado para que pueda regresar valor de blnGenerado
                    Dim objFacturaSucursalGlobalDia As Array = clsFacturaSucursalGlobal.strBuscar(intCadenaId, CInt(Mid(strFechaVenta, 1, 2)), CInt(Mid(strFechaVenta, 4, 2)), CInt(Mid(strFechaVenta, 7, 4)), True, strConnectionString)

                    If IsArray(objFacturaSucursalGlobalDia) AndAlso objFacturaSucursalGlobalDia.Length > 0 Then

                        Dim strRegistroFacturaSucursalGlobalDia As System.Collections.SortedList = DirectCast(objFacturaSucursalGlobalDia.GetValue(0), System.Collections.SortedList)

                        With strRegistroFacturaSucursalGlobalDia

                            dtmFechaVenta = CDate(.Item("dtmFechaVenta"))
                            intSucursalesVigentes = CInt(.Item("intSucursalesVigentes"))
                            intSucursalesTrasmitidas = CInt(.Item("intSucursalesTrasmitidas"))
                            fltTotalTasaCero = CDbl(.Item("fltTotalTasaCero"))
                            fltSubTotalTasaFrontera = CDbl(.Item("fltSubTotalTasaFrontera"))
                            fltImporteImpuestoTasaFrontera = CDbl(.Item("fltImporteImpuestoTasaFrontera"))
                            fltTotalTasaFrontera = CDbl(.Item("fltTotalTasaFrontera"))
                            fltSubTotalTasaInterior = CDbl(.Item("fltSubTotalTasaInterior"))
                            fltImporteImpuestoTasaInterior = CDbl(.Item("fltImporteImpuestoTasaInterior"))
                            fltTotalTasaInterior = CDbl(.Item("fltTotalTasaInterior"))
                            blnGenerado = CBool(.Item("blnGenerado"))

                        End With

                        If Not blnGenerado Then

                            Dim intRegistraFacturaSucursalGlobal As Integer

                            intRegistraFacturaSucursalGlobal = clsFacturaSucursalGlobal.intRegistrar(intCadenaId, dtmFechaVenta, intSucursalesVigentes, intSucursalesTrasmitidas, fltTotalTasaCero, fltSubTotalTasaFrontera, fltImporteImpuestoTasaFrontera, fltTotalTasaFrontera, fltSubTotalTasaInterior, fltImporteImpuestoTasaInterior, fltTotalTasaInterior, strUsuarioNombre, strConnectionString)

                            If intRegistraFacturaSucursalGlobal > 0 Then

                                Dim objArrayFacturaXml As Array = clsFacturaSucursalGlobal.strObtenerXML(intCadenaId, dtmFechaVenta, strConnectionString)
                                Dim objRegistroFacturaXml As SortedList = Nothing
                                Dim strFacturaXml As New StringBuilder

                                For Each objRegistroFacturaXml In objArrayFacturaXml
                                    strFacturaXml.Append(objRegistroFacturaXml.Item("strDataXML"))
                                Next

                                Dim strFullpathname As String = String.Format("{0}\Fac" & Replace(strFechaVenta, "/", "") & ".Xml", strRutaXml)

                                Dim objRemoteWritter As New clsRemoteXmlWriter

                                Call objRemoteWritter.blnFileWasWritten(strFullpathname, strFacturaXml.ToString)
                                Call objRemoteWritter.Dispose()

                                objRemoteWritter = Nothing

                                System.Threading.Thread.Sleep(2000)

                                strRegreso = CStr(intRegistraFacturaSucursalGlobal) 'FOLIO REGISTRADO

                            Else
                                strRegreso = CStr(intRegistraFacturaSucursalGlobal)  'ERROR AL GENERAR DIA
                                ' -100 No existen Folios
                                ' -110 Dia anterior no generado
                            End If
                        Else
                            strRegreso = "-120" 'DIA YA GENERADO
                        End If
                    Else
                        strRegreso = "-130" 'NO HAY INFORMACION PARA EL DIA
                    End If
                Else
                    strRegreso = "-140" 'NO HAY DATOS FISCALES
                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpGenerar( " & _
                strComitasDobles & strRegreso & strComitasDobles & "," & _
                strComitasDobles & strConsultarFacturas() & strComitasDobles & "," & _
                strComitasDobles & strFolioPrefijo & strComitasDobles & "," & _
                strComitasDobles & strFechaVenta & strComitasDobles & _
                "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

        End Select

    End Sub

End Class
