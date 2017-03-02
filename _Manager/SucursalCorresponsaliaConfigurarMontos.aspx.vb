Imports Benavides.Data.SQL.MSSQL
Imports System.Text
Imports System.Xml.XPath
Imports System.Collections
Imports Benavides.POSAdmin.Commons
Imports Isocraft.Web.Http

Public Class SucursalCorresponsaliaConfigurarMontos
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
        intBancoIntegradorId = GetPageParameter("cboBancoIntegrador", 0)
    End Sub

#End Region

    Private intmBancoIntegradorId As Integer
    Private intmTipoServicioId As Integer
    Private intmFormaPagoId As Integer
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmRecordBrowserHTML As String = ""
    Private fltmMontoMinimo As Double
    Private fltmMontoMaximo As Double
    Private fltmMonto1 As Double
    Private fltmMonto2 As Double
    Private fltmMonto3 As Double
    Private fltmNivelEfectivo As Double
    Private fltmMontoComision As Double

    '====================================================================
    ' Name       : intBancoIntegradorId
    ' Description: Identificador del Banco Integrador
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intBancoIntegradorId() As Integer
        Get

            If intmBancoIntegradorId = 0 Then

                intmBancoIntegradorId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboBancoIntegrador", isocraft.commons.clsWeb.strGetPageParameter("intBancoIntegradorId", "0")))

            End If

            Return intmBancoIntegradorId
        End Get
        Set(ByVal intValue As Integer)
            intmBancoIntegradorId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intTipoServicioId
    ' Description: Identificador del tipo de servicio
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intTipoServicioId() As Integer
        Get
            If intmTipoServicioId = 0 Then
                intmTipoServicioId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboTipoServicio", isocraft.commons.clsWeb.strGetPageParameter("intTipoServicioId", "0")))
            End If
            Return intmTipoServicioId
        End Get
    End Property

    '====================================================================
    ' Name       : intFormaPagoId
    ' Description: Identificador de la forma de pago
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intFormaPagoId() As Integer
        Get
            If intmFormaPagoId = 0 Then
                intmFormaPagoId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboFormaPago", isocraft.commons.clsWeb.strGetPageParameter("intFormaPagoId", "0")))
            End If
            Return intmFormaPagoId
        End Get
    End Property

    '====================================================================
    ' Name       : fltMontoMinimo
    ' Description: Identificador del monto minimo
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property fltMontoMinimo() As Double
        Get
            fltmMontoMinimo = CDbl(Request.Form("txtMontoMinimo"))
            Return fltmMontoMinimo
        End Get
    End Property

    '====================================================================
    ' Name       : fltMontoMaximo
    ' Description: Identificador del monto maximo
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property fltMontoMaximo() As Double
        Get
            fltmMontoMaximo = CDbl(Request.Form("txtMontoMaximo"))
            Return fltmMontoMaximo
        End Get
    End Property

    '====================================================================
    ' Name       : fltMonto1
    ' Description: Identificador del monto a ofrecer en POS1
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property fltMonto1() As Double
        Get
            fltmMonto1 = CDbl(Request.Form("txtMontoPOS1"))
            Return fltmMonto1
        End Get
    End Property

    '====================================================================
    ' Name       : fltMonto2
    ' Description: Identificador del monto a ofrecer en POS2
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property fltMonto2() As Double
        Get
            fltmMonto2 = CDbl(Request.Form("txtMontoPOS2"))
            Return fltmMonto2
        End Get
    End Property

    '====================================================================
    ' Name       : fltMonto3
    ' Description: Identificador del monto a ofrecer en POS1
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property fltMonto3() As Double
        Get
            fltmMonto3 = CDbl(Request.Form("txtMontoPOS3"))
            Return fltmMonto3
        End Get
    End Property

    '====================================================================
    ' Name       : fltNivelEfectivo
    ' Description: Identificador del monto a ofrecer en POS1
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property fltNivelEfectivo() As Double
        Get
            fltmNivelEfectivo = CDbl(Request.Form("txtNivelEfectivo"))
            Return fltmNivelEfectivo
        End Get
    End Property
    '====================================================================
    ' Name       : fltMontoComision
    ' Description: Identificador del monto maximo
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property fltMontoComision() As Double
        Get
            fltmMontoComision = CDbl(Request.Form("txtMontoComision"))
            Return fltmMontoComision
        End Get
    End Property
    '====================================================================
    ' Name       : strHTMLFechaHora
    ' Description: Genera la fecha y hora de la página
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)
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
    ' Name       : strThisPageName
    ' Description: URL de esta página
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request)
        End Get
    End Property

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Obtiene la cadena de conexión hacia la base de datos
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: Establece los comandos Javascript del evento OnLoad
    ' Accessor   : Read
    ' Throws     : None
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
    ' Name       : strLlenarBancoIntegradorComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboBancoIntegrador"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarBancoIntegradorComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboBancoIntegrador", intBancoIntegradorId, Benavides.CC.Data.clstblBancoIntegradorCorresponsalia.strObtenerBancoIntegrador(strConnectionString), 0, 1, 1)
    End Function
    '====================================================================
    ' Name       : strLlenarTipoServicioComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboTipoServicio"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarTipoServicioComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboTipoServicio", intTipoServicioId, Benavides.CC.Business.clsConcentrador.clsSucursal.clsCorresponsalia.strObtenerTipoServicio(strConnectionString), 0, 1, 1)
    End Function

    '====================================================================
    ' Name       : strLlenarFormaPagoComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboFormaPago"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarFormaPagoComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboFormaPago", intFormaPagoId, Benavides.CC.Business.clsConcentrador.clsSucursal.clsCorresponsaliaMonto.strObtenerFormaPago(strConnectionString), 0, 1, 1)
    End Function

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: RecordBrowser de Productos Beneficiados
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRecordBrowserHTML() As String
        Get
            Return strmRecordBrowserHTML
        End Get
        Set(ByVal Value As String)
            strmRecordBrowserHTML = Value
        End Set

    End Property

    '====================================================================
    ' Name       : RemoverEncabezado
    ' Description: Quita el encabezado que viene en un record Browser elaborado por el sistema
    ' Throws     : Ninguna
    ' Input      : Cadena html con un encabezado
    ' Output     : Cadena html sin encabezado
    '====================================================================
    Private Function RemoverEncabezado(ByVal strCadena As String) As String

        Dim strAuxiliar As String
        Dim strTitulos As String
        Dim intLastIndex As Integer
        Dim intIndex As Integer

        'La cadena del browser tiene dos tablas. Hay que quitar la primera tabla que es 
        '   la que tiene el encabezado, pero antes de el encabezado debemos mantener 
        '   los títulos.

        ' Primero extraemos los titulos que estan antes de la primera tabla y quitamos un salto de linea
        intIndex = strCadena.IndexOf("<table")
        strTitulos = strCadena.Substring(0, intIndex - 4)

        ' Quitamos de la cadena el ultimo cierre de tabla
        intLastIndex = strCadena.LastIndexOf("</table>")
        strAuxiliar = strCadena.Substring(0, strCadena.Length - (strCadena.Length - intLastIndex))

        ' Ahora ubicamos el fin de la primera tabla para quedarnos con el resto de la cadena
        intLastIndex = strAuxiliar.LastIndexOf("</table>")
        strAuxiliar = strAuxiliar.Substring(intLastIndex + 8)

        ' Finalmente juntamos los titulos, la segunda tabla y el cierre que extraimos al principio
        RemoverEncabezado = strTitulos + strAuxiliar + "</table>"

    End Function

    '====================================================================
    ' Name       : ArmarRecordBrowsers
    ' Description: Arma los record browser necesarios segun el numero de
    '               tipos de servicios configurados en la BD.
    ' Throws     : Ninguna
    ' Output     : Cadena html
    '====================================================================
    Public Function ArmarRecordBrowsers() As String

        Dim i As Integer
        Dim aobjLlavesPrimarias As Array = Nothing
        Dim intLlaveActualTipoServicio As Integer
        Dim aobjMontos As Array = Nothing
        Dim strTituloBrowser As String
        Dim strTituloBrowserEntrante As String
        Dim strRecordBrowserHTMLTest As String
        Dim strHTML As String
        Dim strTablaMontos As New StringBuilder
        Dim strColorfila As String
        strRecordBrowserHTMLTest = ""
        intLlaveActualTipoServicio = 999999
        strHTML = ""

        'Obtenemos las llaves primarias de los registros en la BD intBancoIntegradorId
        aobjLlavesPrimarias = Benavides.CC.Business.clsConcentrador.clsSucursal.clsCorresponsaliaMonto.strObtenerServiciosCorresponsaliaMontoIds(intBancoIntegradorId, strConnectionString)

        For i = 0 To (aobjLlavesPrimarias.Length - 1)

            If Not intLlaveActualTipoServicio = CInt(DirectCast(aobjLlavesPrimarias.GetValue(i), Array).GetValue(0)) Then

                'Obtenemos la llave actual
                intLlaveActualTipoServicio = CInt(DirectCast(aobjLlavesPrimarias.GetValue(i), Array).GetValue(0))

                If Not intLlaveActualTipoServicio = 0 Then

                    'Obtenemos la informacion de cada uno de los tipos de servicio configurados intBancoIntegradorId
                    aobjMontos = Benavides.CC.Business.clsConcentrador.clsSucursal.clsCorresponsaliaMonto.strObtenerMinMax(intLlaveActualTipoServicio, intBancoIntegradorId, strConnectionString)

                    'Obtenemos el nombre del tipo de servicio 
                    strTituloBrowser = CStr(DirectCast(aobjMontos.GetValue(0), Array).GetValue(0))

                    'Los servicios configurados en la librería del Recordbrowser son los únicos que deben ser armados
                    If strTituloBrowser = "PagoTarjetaDeCredito" Or strTituloBrowser = "DepositoCuentaDebito" Or strTituloBrowser = "CorresponsaliaHSBC" Then

                        'strRecordBrowserHTMLTest = Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strTituloBrowser, aobjMontos, 1, aobjMontos.Length, "")
                        'strRecordBrowserHTMLTest = RemoverEncabezado(strRecordBrowserHTMLTest)
                        'strHTML &= "<BR>"
                        'strHTML &= strRecordBrowserHTMLTest
                        'strHTML &= "<BR>"
                        Dim j As Integer
                        strTablaMontos.Append("<BR>")
                        strTablaMontos.Append("<span class='txsubtitulo'>")
                        strTablaMontos.Append("<img src='../static/images/bullet_subtitulos.gif' width='17' height='11' align='absmiddle'>" & CStr(DirectCast(aobjMontos.GetValue(0), Array).GetValue(5)))
                        strTablaMontos.Append("</span>")
                        strTablaMontos.Append("<br>")
                        strTablaMontos.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
                        strTablaMontos.Append("<tr class='trtitulos'>")
                        strTablaMontos.Append("<th class='rayita' align='left' valign='top'>Forma de Pago</th>")
                        strTablaMontos.Append("<th class='rayita' align='left' valign='top'>Mínimo</th>")
                        strTablaMontos.Append("<th class='rayita' align='left' valign='top'>Máximo</th>")
                        strTablaMontos.Append("<th align='left' valign='top'>&nbsp;</th>")
                        strTablaMontos.Append("<th class='rayita' align='left' valign='top'>Comisión</th>")
                        strTablaMontos.Append("</tr>")
                        strColorfila = ""
                        For j = 0 To aobjMontos.Length - 1
                            strTablaMontos.Append("<tr>")
                            If j Mod 2 = 0 Then
                                strColorfila = "tdceleste"
                            Else
                                strColorfila = "tdblanco"
                            End If
                            strTablaMontos.Append("<td class='" & strColorfila & "' align='default' valign='top'>" & CStr(DirectCast(aobjMontos.GetValue(j), Array).GetValue(1)) & "</td>")
                            strTablaMontos.Append("<td class='" & strColorfila & "' align='default' valign='top'>" & CStr(DirectCast(aobjMontos.GetValue(j), Array).GetValue(2)) & "</td>")
                            strTablaMontos.Append("<td class='" & strColorfila & "' align='default' valign='top'>" & CStr(DirectCast(aobjMontos.GetValue(j), Array).GetValue(3)) & "</td>")
                            If j = 0 Then
                                strTablaMontos.Append("<td rowspan='" & aobjMontos.Length & "' align='center' valign='middle'>&nbsp;</td>")
                                strTablaMontos.Append("<td   font-family= 'Verdana, Arial, Helvetica, sans-serif' style='font-size:10px; padding-left=5px; padding-top= 5px; font-weight=normal;  font-family=Verdana, Arial, Helvetica, sans-serif; border-bottom: #525698 1px solid'   align='center' valign='middle' rowspan='" & aobjMontos.Length & "'>" & CStr(DirectCast(aobjMontos.GetValue(j), Array).GetValue(4)) & "</td>")
                            End If

                            'If j = aobjMontos.Length - 1 Then
                            '    strTablaMontos.Append("<td class='tdblanco' rowspan='" & j & "' align='center' valign='middle'>&nbsp;</td>")                                
                            'End If
                            strTablaMontos.Append("</tr>")

                        Next
                        strTablaMontos.Append("</table>")
                        strTablaMontos.Append("<BR>")

                    End If

                    'Limpiamos la memoria para la siguiente iteracion
                    'strRecordBrowserHTMLTest = ""
                    strRecordBrowserHTMLTest = clsCommons.strGenerateJavascriptString(strTablaMontos.ToString)


                End If


            End If

        Next

        'Return strHTML
        Return strRecordBrowserHTMLTest

    End Function

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strCashBackRecordBrowserHTML() As String


        Dim strMontosCashBack As Array = Nothing
        Dim strTablaCashBack As New StringBuilder
        Dim fltMonto1 As Double
        Dim fltMonto2 As Double
        Dim fltMonto3 As Double
        Dim fltNivelEfectivo As Double

        strTablaCashBack.Append(" ")

        'Obtenemos los valores de la tabla de CashBack
        strMontosCashBack = Benavides.CC.Business.clsConcentrador.clsSucursal.clsCorresponsaliaMontoCashBack.strObtenerMontosCashBack(strConnectionString)

        If (strMontosCashBack.Length = 0) Then

            fltMonto1 = 0.0
            fltMonto2 = 0.0
            fltMonto3 = 0.0
            fltNivelEfectivo = 0.0

        Else

            fltMonto1 = CDbl(DirectCast(strMontosCashBack.GetValue(0), Array).GetValue(0))
            fltMonto2 = CDbl(DirectCast(strMontosCashBack.GetValue(0), Array).GetValue(1))
            fltMonto3 = CDbl(DirectCast(strMontosCashBack.GetValue(0), Array).GetValue(2))
            fltNivelEfectivo = CDbl(DirectCast(strMontosCashBack.GetValue(0), Array).GetValue(3))

        End If

        strTablaCashBack.Append("<span class='txsubtitulo'>")
        strTablaCashBack.Append("<img src='../static/images/bullet_subtitulos.gif' width='17' height='11' align='absmiddle'>" & "Asignar valores para CashBack.")
        strTablaCashBack.Append("<p>" & "Capture los valores que se manejaran en las sucursales para CashBack" & "</p>")
        strTablaCashBack.Append("<table width='80%'  border='0' cellspacing='0' cellpadding='0'>")
        strTablaCashBack.Append("<tr class='trtitulos'>")
        strTablaCashBack.Append("<th width='450'  class='rayita'>&nbsp;</td>")
        strTablaCashBack.Append("<th width='10' class='rayita'>Monto</td>")
        strTablaCashBack.Append("</tr>")

        strTablaCashBack.Append("<tr>")
        strTablaCashBack.Append("<td width='450'  class='tdceleste'>" & "Monto a Ofrecer en POS 1" & "</td>")
        strTablaCashBack.Append("<td width='10'  class='tdceleste'>")
        strTablaCashBack.Append("<input type='text' class='field' maxLength='10' size='10' name='txtMontoPOS1' id='txtMontoPOS1' value='" & CStr(fltMonto1) & "'>")
        strTablaCashBack.Append("</td>")
        strTablaCashBack.Append("</tr>")

        strTablaCashBack.Append("<tr>")
        strTablaCashBack.Append("<td width='450'  class='tdblanco'>" & "Monto a Ofrecer en POS 2" & "</td>")
        strTablaCashBack.Append("<td width='10'  class='tdblanco'>")
        strTablaCashBack.Append("<input type='text' class='field' maxLength='10' size='10' name='txtMontoPOS2' id='txtMontoPOS2' value='" & CStr(fltMonto2) & "'>")
        strTablaCashBack.Append("</td>")
        strTablaCashBack.Append("</tr>")

        strTablaCashBack.Append("<tr>")
        strTablaCashBack.Append("<td width='450'  class='tdceleste'>" & "Monto a Ofrecer en POS 3" & "</td>")
        strTablaCashBack.Append("<td width='10'  class='tdceleste'>")
        strTablaCashBack.Append("<input type='text' class='field' maxLength='10' size='10' name='txtMontoPOS3' id='txtMontoPOS3' value='" & CStr(fltMonto3) & "'>")
        strTablaCashBack.Append("</td>")
        strTablaCashBack.Append("</tr>")

        strTablaCashBack.Append("<tr>")
        strTablaCashBack.Append("<td width='450'  class='tdblanco'>" & "Nivel de Efectvio para CashBack en POS" & "</td>")
        strTablaCashBack.Append("<td width='10'  class='tdblanco'>")
        strTablaCashBack.Append("<input type='text' class='field' maxLength='10' size='10' name='txtNivelEfectivo' id='txtNivelEfectivo' value='" & CStr(fltNivelEfectivo) & "'>")
        strTablaCashBack.Append("</td>")
        strTablaCashBack.Append("</tr>")
        strTablaCashBack.Append("</table>")
        If intBancoIntegradorId <> 0 Then
            strCashBackRecordBrowserHTML = clsCommons.strGenerateJavascriptString(strTablaCashBack.ToString)
        End If
    End Function
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        Dim strCmd As String = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")
        Dim intResultado As Integer


        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Salvar"

                intResultado = Benavides.CC.Business.clsConcentrador.clsSucursal.clsCorresponsaliaMonto.intGuardarMinMax(intTipoServicioId, intFormaPagoId, fltMontoMinimo, fltMontoMaximo, strUsuarioNombre, intBancoIntegradorId, fltMontoComision, strConnectionString)

                If intResultado = 0 Then
                    strJavascriptWindowOnLoadCommands &= "  alert(""ERROR: La información no pudo ser agregada a la base de datos.\n\r\n\rPor favor informe este error a su administrador o personal a cargo."");" & vbCrLf
                End If


            Case "SalvarCash"

                intResultado = Benavides.CC.Business.clsConcentrador.clsSucursal.clsCorresponsaliaMontoCashBack.intGuardarMontosCashBack(fltMonto1, fltMonto2, fltMonto3, fltNivelEfectivo, strUsuarioNombre, strConnectionString)

                If intResultado = 0 Then
                    strJavascriptWindowOnLoadCommands &= "  alert(""ERROR: La información no pudo ser agregada a la base de datos.\n\r\n\rPor favor informe este error a su administrador o personal a cargo."");" & vbCrLf
                End If
        End Select

    End Sub



End Class
