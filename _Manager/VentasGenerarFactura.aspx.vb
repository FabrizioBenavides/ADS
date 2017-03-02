Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

Imports System.Text
Imports System.Collections
Imports prjRemoteXmlWriter

Imports Benavides.CC.Data
Imports Benavides.POSAdmin.Commons

Public Class VentasGenerarFactura

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


    End Sub

#End Region

#Region " Class Private Attributes"

    Const strComitasDobles As String = """"
    Private strmJavascriptWindowOnLoadCommands As String

    Private strmClienteFiscalRFC As String
    Private strmClienteFiscalRazonSocial As String
    Private strmClienteFiscalCalle As String
    Private strmClienteFiscalNoExterior As String
    Private strmClienteFiscalNoInterior As String
    Private strmClienteFiscalColonia As String
    Private strmClienteFiscalCiudad As String
    Private strmClienteFiscalEstado As String
    Private strmClienteFiscalPais As String
    Private strmClienteFiscalCodigoPostal As String
    Private strmClienteFiscalTelefono As String

    Private strmRutaXml As String
    Private strmExpedicionCalle As String
    Private strmExpedicionNoExterior As String
    Private strmExpedicionNoInterior As String
    Private strmExpedicionColonia As String
    Private strmExpedicionCiudad As String
    Private strmExpedicionEstado As String
    Private strmExpedicionPais As String
    Private strmExpedicionCodigoPostal As String

    Private strmMesConsulta As String
    Private intmSucursalesIncluidas As String
    Private fltmTotalSucursales As String
    Private fltmTotalExcento As String
    Private fltmSubTotalTasa10 As String
    Private fltmImporteImpuestoTasa10 As String
    Private fltmTotalTasa10 As String
    Private fltmSubTotalTasa15 As String
    Private fltmImporteImpuestoTasa15 As String
    Private fltmTotalTasa15 As String

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
    ' Name       : intMesVenta 
    ' Description: 
    ' Accessor   : Read
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intMesVenta() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intMesVenta"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property

    Public ReadOnly Property strFechaExpedicion() As String
        Get
            If intMesVenta < 1 Or intMesVenta > 12 Then
                Return ""
            Else
                Dim strAA As String
                If intMesVenta = 12 Then
                    strAA = Year(Now).ToString
                Else
                    strAA = Year(Now.AddYears(-1)).ToString
                End If

                Return "01" & "-" & intMesVenta.ToString("00") & "-" & strAA

            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strClienteFiscalRFC 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strClienteFiscalRFC() As String
        Get
            Return strmClienteFiscalRFC
        End Get
        Set(ByVal strValue As String)
            strmClienteFiscalRFC = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strClienteFiscalRazonSocial 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strClienteFiscalRazonSocial() As String
        Get
            Return strmClienteFiscalRazonSocial
        End Get
        Set(ByVal strValue As String)
            strmClienteFiscalRazonSocial = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strClienteFiscalCalle 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strClienteFiscalCalle() As String
        Get
            Return strmClienteFiscalCalle
        End Get
        Set(ByVal strValue As String)
            strmClienteFiscalCalle = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strClienteFiscalNoExterior 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strClienteFiscalNoExterior() As String
        Get
            Return strmClienteFiscalNoExterior
        End Get
        Set(ByVal strValue As String)
            strmClienteFiscalNoExterior = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strClienteFiscalNoInterior 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strClienteFiscalNoInterior() As String
        Get
            Return strmClienteFiscalNoInterior
        End Get
        Set(ByVal strValue As String)
            strmClienteFiscalNoInterior = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strClienteFiscalColonia 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strClienteFiscalColonia() As String
        Get
            Return strmClienteFiscalColonia
        End Get
        Set(ByVal strValue As String)
            strmClienteFiscalColonia = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strClienteFiscalCiudad 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strClienteFiscalCiudad() As String
        Get
            Return strmClienteFiscalCiudad
        End Get
        Set(ByVal strValue As String)
            strmClienteFiscalCiudad = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strClienteFiscalEstado 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strClienteFiscalEstado() As String
        Get
            Return strmClienteFiscalEstado
        End Get
        Set(ByVal strValue As String)
            strmClienteFiscalEstado = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strClienteFiscalPais 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strClienteFiscalPais() As String
        Get
            Return strmClienteFiscalPais
        End Get
        Set(ByVal strValue As String)
            strmClienteFiscalPais = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strClienteFiscalCodigoPostal 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strClienteFiscalCodigoPostal() As String
        Get
            Return strmClienteFiscalCodigoPostal
        End Get
        Set(ByVal strValue As String)
            strmClienteFiscalCodigoPostal = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strClienteFiscalTelefono 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strClienteFiscalTelefono() As String
        Get
            Return strmClienteFiscalTelefono
        End Get
        Set(ByVal strValue As String)
            strmClienteFiscalTelefono = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strRutaXml 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strRutaXml() As String
        Get
            Return strmRutaXml
        End Get
        Set(ByVal strValue As String)
            strmRutaXml = strValue
        End Set
    End Property

    '===================================================================
    ' Name       : strExpedicionCalle 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strExpedicionCalle() As String
        Get
            Return strmExpedicionCalle
        End Get
        Set(ByVal strValue As String)
            strmExpedicionCalle = strValue
        End Set
    End Property

    '===================================================================
    ' Name       : strExpedicionNoExterior 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strExpedicionNoExterior() As String
        Get
            Return strmExpedicionNoExterior
        End Get
        Set(ByVal strValue As String)
            strmExpedicionNoExterior = strValue
        End Set
    End Property

    '===================================================================
    ' Name       : strExpedicionNoInterior 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strExpedicionNoInterior() As String
        Get
            Return strmExpedicionNoInterior
        End Get
        Set(ByVal strValue As String)
            strmExpedicionNoInterior = strValue
        End Set
    End Property

    '===================================================================
    ' Name       : strmxpedicionColonia 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strExpedicionColonia() As String
        Get
            Return strmExpedicionColonia
        End Get
        Set(ByVal strValue As String)
            strmExpedicionColonia = strValue
        End Set
    End Property

    '===================================================================
    ' Name       : strExpedicionCiudad 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strExpedicionCiudad() As String
        Get
            Return strmExpedicionCiudad
        End Get
        Set(ByVal strValue As String)
            strmExpedicionCiudad = strValue
        End Set
    End Property

    '===================================================================
    ' Name       : strExpedicionEstado 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strExpedicionEstado() As String
        Get
            Return strmExpedicionEstado
        End Get
        Set(ByVal strValue As String)
            strmExpedicionEstado = strValue
        End Set
    End Property

    '===================================================================
    ' Name       : strExpedicionPais 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strExpedicionPais() As String
        Get
            Return strmExpedicionPais
        End Get
        Set(ByVal strValue As String)
            strmExpedicionPais = strValue
        End Set
    End Property

    '===================================================================
    ' Name       : strExpedicionCodigoPostal 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strExpedicionCodigoPostal() As String
        Get
            Return strmExpedicionCodigoPostal
        End Get
        Set(ByVal strValue As String)
            strmExpedicionCodigoPostal = strValue
        End Set
    End Property

    '===================================================================
    ' Name       : strMesConsulta 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strMesConsulta() As String
        Get
            Return strmMesConsulta
        End Get
        Set(ByVal strValue As String)
            strmMesConsulta = strValue
        End Set
    End Property

    '===================================================================
    ' Name       : intSucursalesIncluidas 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property intSucursalesIncluidas() As String
        Get
            Return intmSucursalesIncluidas
        End Get
        Set(ByVal strValue As String)
            intmSucursalesIncluidas = strValue
        End Set
    End Property

    '===================================================================
    ' Name       : fltTotalSucursales
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property fltTotalSucursales() As String
        Get
            Return fltmTotalSucursales
        End Get
        Set(ByVal strValue As String)
            fltmTotalSucursales = strValue
        End Set
    End Property

    '===================================================================
    ' Name       : fltTotalExcento
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property fltTotalExcento() As String
        Get
            Return fltmTotalExcento
        End Get
        Set(ByVal strValue As String)
            fltmTotalExcento = strValue
        End Set
    End Property

    '===================================================================
    ' Name       : fltSubTotalTasa10
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property fltSubTotalTasa10() As String
        Get
            Return fltmSubTotalTasa10
        End Get
        Set(ByVal strValue As String)
            fltmSubTotalTasa10 = strValue
        End Set
    End Property

    '===================================================================
    ' Name       : fltImporteImpuestoTasa10
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property fltImporteImpuestoTasa10() As String
        Get
            Return fltmImporteImpuestoTasa10
        End Get
        Set(ByVal strValue As String)
            fltmImporteImpuestoTasa10 = strValue
        End Set
    End Property

    '===================================================================
    ' Name       : fltTotalTasa10
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property fltTotalTasa10() As String
        Get
            Return fltmTotalTasa10
        End Get
        Set(ByVal strValue As String)
            fltmTotalTasa10 = strValue
        End Set
    End Property

    '===================================================================
    ' Name       : fltSubTotalTasa15
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property fltSubTotalTasa15() As String
        Get
            Return fltmSubTotalTasa15
        End Get
        Set(ByVal strValue As String)
            fltmSubTotalTasa15 = strValue
        End Set
    End Property

    '===================================================================
    ' Name       : fltImporteImpuestoTasa15
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property fltImporteImpuestoTasa15() As String
        Get
            Return fltmImporteImpuestoTasa15
        End Get
        Set(ByVal strValue As String)
            fltmImporteImpuestoTasa15 = strValue
        End Set
    End Property

    '===================================================================
    ' Name       : fltTotalTasa15
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property fltTotalTasa15() As String
        Get
            Return fltmTotalTasa15
        End Get
        Set(ByVal strValue As String)
            fltmTotalTasa15 = strValue
        End Set
    End Property

    Function blnDatosFacturacion() As Boolean

        Dim blnRegreso As Boolean = False

        Dim strDatosFacturacion As Array = clsFacturaElectronicaGlobal.strBuscarDatosFacturacion(strConnectionString)

        If IsArray(strDatosFacturacion) AndAlso strDatosFacturacion.Length > 0 Then

            Dim strRegistroDatosFacturacion As System.Collections.SortedList = DirectCast(strDatosFacturacion.GetValue(0), System.Collections.SortedList)

            With strRegistroDatosFacturacion

                strmRutaXml = .Item("strFacturaElectronicaGlobalDatosFacturacionRutaXml").ToString
                strExpedicionCalle = .Item("strFacturaElectronicaGlobalDatosFacturacionExpedicionCalle").ToString
                strExpedicionNoExterior = .Item("strFacturaElectronicaGlobalDatosFacturacionExpedicionNoExterior").ToString
                strExpedicionNoInterior = .Item("strFacturaElectronicaGlobalDatosFacturacionExpedicionNoInterior").ToString
                strExpedicionColonia = .Item("strFacturaElectronicaGlobalDatosFacturacionExpedicionColonia").ToString
                strExpedicionCiudad = .Item("strFacturaElectronicaGlobalDatosFacturacionExpedicionCiudad").ToString
                strExpedicionEstado = .Item("strFacturaElectronicaGlobalDatosFacturacionExpedicionEstado").ToString
                strExpedicionPais = .Item("strFacturaElectronicaGlobalDatosFacturacionExpedicionPais").ToString
                strExpedicionCodigoPostal = .Item("strFacturaElectronicaGlobalDatosFacturacionExpedicionCodigoPostal").ToString


                strClienteFiscalRFC = .Item("strFacturaElectronicaGlobalDatosFacturacionClienteFiscalRFC").ToString()
                strClienteFiscalRazonSocial = .Item("strFacturaElectronicaGlobalDatosFacturacionClienteFiscalRazonSocial").ToString()
                strClienteFiscalCalle = .Item("strFacturaElectronicaGlobalDatosFacturacionClienteFiscalCalle").ToString
                strClienteFiscalNoExterior = .Item("strFacturaElectronicaGlobalDatosFacturacionClienteFiscalNoExterior").ToString()
                strClienteFiscalNoInterior = .Item("strFacturaElectronicaGlobalDatosFacturacionClienteFiscalNoInterior").ToString()
                strClienteFiscalColonia = .Item("strFacturaElectronicaGlobalDatosFacturacionClienteFiscalColonia").ToString()
                strClienteFiscalCiudad = .Item("strFacturaElectronicaGlobalDatosFacturacionClienteFiscalCiudad").ToString()
                strClienteFiscalEstado = .Item("strFacturaElectronicaGlobalDatosFacturacionClienteFiscalEstado").ToString()
                strClienteFiscalPais = .Item("strFacturaElectronicaGlobalDatosFacturacionClienteFiscalPais").ToString()
                strClienteFiscalCodigoPostal = .Item("strFacturaElectronicaGlobalDatosFacturacionClienteFiscalCodigoPostal").ToString()
                strClienteFiscalTelefono = .Item("strFacturaElectronicaGlobalDatosFacturacionClienteFiscalTelefono").ToString()

            End With

            blnRegreso = True

        End If

        Return blnRegreso

    End Function

    Function blnTotales() As Boolean

        Dim blnRegreso As Boolean = False

        Dim intDireccionOperativaId As Integer = -1
        Dim intZonaOperativaId As Integer = -1
        Dim strSucursalId As String = "-1|-1"
        Dim intDiasFaltantes As Integer = 0  ' Para indicar todas las sucursales sin importar que este compleata la trasmision del mes
        Dim blnMesdetallado As Byte = 0 ' Para indicar que es el total del mes

        Dim objDataArrayTotales As Array = clsFacturaElectronicaGlobal.strBuscarTotales(intDireccionOperativaId, intZonaOperativaId, 0, 0, intMesVenta, intDiasFaltantes, blnMesdetallado, 0, 0, strConnectionString)

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

            blnRegreso = True

        End If

        Return blnRegreso

    End Function

    Function blnGenerarFacturas() As Boolean

        Dim blRegreso As Boolean = False

        Dim objArrayFacturasDelMes As Array = clsFacturaElectronicaGlobal.strGenerarFactura(intMesVenta, strConnectionString)
        Dim objRegistroFacturasDelMes As SortedList = Nothing
        Dim intFacturaElectronicaGlobalId As Integer
        Dim intNoArchivo As Integer

        If IsArray(objArrayFacturasDelMes) AndAlso objArrayFacturasDelMes.Length > 0 Then
            intNoArchivo = 0

            For Each objRegistroFacturasDelMes In objArrayFacturasDelMes

                intFacturaElectronicaGlobalId = CInt(objRegistroFacturasDelMes.Item("intFacturaElectronicaGlobalId"))

                Dim objArrayFacturaXml As Array = clsFacturaElectronicaGlobal.strObtenerFacturaXML(intFacturaElectronicaGlobalId, strConnectionString)
                Dim objRegistroFacturaXml As SortedList = Nothing
                Dim strFacturaXml As New StringBuilder

                For Each objRegistroFacturaXml In objArrayFacturaXml

                    strFacturaXml.Append(objRegistroFacturaXml.Item("strDataXML"))

                Next

                intNoArchivo += 1

                Dim strFullpathname As String = String.Format("{0}\Fac" & intMesVenta.ToString("00") & intNoArchivo.ToString("00") & ".Xml", strRutaXml)

                Dim objRemoteWritter As New clsRemoteXmlWriter

                Call objRemoteWritter.blnFileWasWritten(strFullpathname, strFacturaXml.ToString)
                Call objRemoteWritter.Dispose()

                objRemoteWritter = Nothing

                System.Threading.Thread.Sleep(6000)
            Next

            blRegreso = True

        End If

        Return blRegreso

    End Function

    Function blnMesGenerado() As Boolean

        Dim blRegreso As Boolean = False

        Dim objDataArrayFacturasMes As Array = clsFacturaElectronicaGlobal.strBuscarMesGenerado(intMesVenta, 0, 0, strConnectionString)

        If IsArray(objDataArrayFacturasMes) AndAlso objDataArrayFacturasMes.Length > 0 Then
            blRegreso = True
        End If

        Return blRegreso

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If intMesVenta < 1 Or intMesVenta > 12 Then
            Call Response.Redirect("VentasFacturacionGlobal.aspx")
        End If

        If blnDatosFacturacion() Then

            If blnTotales() Then

                If strCmd = "Generar" Then

                    If blnMesGenerado() Then
                        strJavascriptWindowOnLoadCommands = "document.frmVentasGenerarFactura.cmdCerrar.disabled=false;alert('Facturas para el mes indicado generadas');cmdCerrar_onclick();"
                    Else

                        If blnGenerarFacturas() Then
                            strJavascriptWindowOnLoadCommands = "document.frmVentasGenerarFactura.cmdCerrar.disabled=false;alert('Se genero el Mes correctamente.\n\r\n\r');cmdCerrar_onclick();"
                        Else
                            strJavascriptWindowOnLoadCommands = "document.frmVentasGenerarFactura.cmdCerrar.disabled=false;alert('Se produjo algun error al generar las facturas del mes.\n\r\n\rPor favor notifique a Mesa de Ayuda.\n\r\n\rSin estos datos la factura no puede generarse.\n\r\t');cmdCerrar_onclick()"
                        End If

                    End If

                End If

            Else

                strJavascriptWindowOnLoadCommands = "document.frmVentasGenerarFactura.cmdCerrar.disabled=false;alert('No fue posible obtener los totales para la facturacion.\n\r\n\rPor favor notifique a Mesa de Ayuda.\n\r\n\r\t');cmdCerrar_onclick()"

            End If

        Else

            strJavascriptWindowOnLoadCommands = "document.frmVentasGenerarFactura.cmdCerrar.disabled=false;alert('No fue posible leer los datos de facturación.\n\r\n\rPor favor notifique a Mesa de Ayuda.\n\r\n\rSin estos datos la factura no puede generarse.\n\r\t');cmdCerrar_onclick()"

        End If


    End Sub


End Class
