Imports System
Imports System.IO
Imports System.Configuration
Imports System.Text
Imports Benavides.POSAdmin.Commons
Imports Benavides.Data
Imports Benavides.Data.Xml

Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

Public Class VentasInterfaseSapVentaAgregada
    Inherits System.Web.UI.Page


#Region " Class Private Attributes"

    ' Variables locales privadas
    Const strComitasDobles As String = """"
    Private strmJavascriptWindowOnLoadCommands As String

    Private intmDireccionId As Integer
    Private intmZonaId As Integer
    Private strmCompaniaSucursalId As String

    Private strmCboDireccion As String
    Private strmCboZona As String
    Private strmCboSucursal As String

    Private strmtxtFechaInicial As String
    Private strmtxtFechaFinal As String

    Private strmRecordBrowserHTML As String = ""


#End Region


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

        intDireccionId = CInt(GetPageParameter("cboDireccion", GetPageParameter("intDireccionId", "0")))
        intZonaId = CInt(GetPageParameter("cboZona", GetPageParameter("intZonaId", "0")))
        strCompaniaSucursalId = CStr(GetPageParameter("cboSucursal", GetPageParameter("strCompaniaSucursalId", "-1|-1")))

        strFechaInicio = CStr(isocraft.commons.clsWeb.strGetPageParameter("txtFechaInicio", isocraft.commons.clsWeb.strGetPageParameter("strFechaInicio", "")))
        strFechaFinal = CStr(isocraft.commons.clsWeb.strGetPageParameter("txtFechaFin", isocraft.commons.clsWeb.strGetPageParameter("strFechaFinal", "")))

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

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
    ' Name       : strRBCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRBCmd() As String
        Get
            Return GetPageParameter("strRBCmd", "")
        End Get
    End Property

    '====================================================================
    ' Name       : strLlenarDireccionComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboDireccion"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarDireccionComboBox() As String
        Dim aobjDirecciones As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString)
        Dim strRegistrosDirecciones As String()

        Dim aobjDirFarmacias As New System.Collections.ArrayList

        For Each strRegistrosDirecciones In aobjDirecciones

            aobjDirFarmacias.Add(strRegistrosDirecciones)

        Next

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccion", intDireccionId, aobjDirFarmacias.ToArray, 0, 1, 2)

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
        If intDireccionId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZona", intZonaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, 0, strConnectionString), 0, 1, 2)
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
        If intDireccionId > 0 AndAlso intZonaId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSucursal", strCompaniaSucursalId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, intZonaId, strConnectionString), New Integer(1) {0, 1}, 2, 2)
        End If
    End Function

    '====================================================================
    ' Name       : intDireccionId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intDireccionId() As Integer
        Get
            Return intmDireccionId
        End Get
        Set(ByVal intValue As Integer)
            intmDireccionId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intZonaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intZonaId() As Integer
        Get
            Return intmZonaId
        End Get
        Set(ByVal intValue As Integer)
            intmZonaId = intValue
        End Set
    End Property
    '====================================================================
    ' Name       : strCompaniaSucursalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strCompaniaSucursalId() As String
        Get
            Return strmCompaniaSucursalId
        End Get
        Set(ByVal intValue As String)
            strmCompaniaSucursalId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaInicio
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strFechaInicio() As String
        Get
            Return strmtxtFechaInicial
        End Get
        Set(ByVal strValue As String)
            strmtxtFechaInicial = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaFinal
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strFechaFinal() As String
        Get
            Return strmtxtFechaFinal
        End Get
        Set(ByVal strValue As String)
            strmtxtFechaFinal = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intCompaniaid
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCompaniaid() As Integer
        Get
            Dim intmCompaniaid As Integer = 0

            If Len(strCompaniaSucursalId) > 3 Then
                Dim astrCompaniaSucursal As Array = Split(strCompaniaSucursalId, "|")
                If astrCompaniaSucursal.Length > 0 Then
                    intmCompaniaid = CInt(astrCompaniaSucursal.GetValue(0))
                End If
            End If

            Return intmCompaniaid

        End Get

    End Property

    '====================================================================
    ' Name       : intSucursalid
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intSucursalid() As Integer
        Get
            Dim intmSucursalid As Integer = 0

            If Len(strCompaniaSucursalId) > 3 Then
                Dim astrCompaniaSucursal As Array = Split(strCompaniaSucursalId, "|")
                If astrCompaniaSucursal.Length > 0 Then
                    intmSucursalid = CInt(astrCompaniaSucursal.GetValue(1))
                End If
            End If

            Return intmSucursalid

        End Get

    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: 
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
    ' Name       : strSolicitaVentaAgregada
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strSolicitaVentaAgregada() As String
        'Realiza la consulta de las sucursales que no se tiene la venta agregada
        Dim astrDataArray As Array = Benavides.CC.Data.clsVentaAgregada.strBuscarTransmisiones(intDireccionId, intZonaId, intCompaniaid, intSucursalid, CDate(clsCommons.strDMYtoMDY(strFechaInicio)), CDate(clsCommons.strDMYtoMDY(strFechaFinal)), 1, 0, 0, strConnectionString)
        Dim objRegistroTransmisionPendiente As String() = Nothing


        Dim regintCompaniaId As Integer = 0
        Dim regintSucursalId As Integer = 0
        Dim regdtmFechaInicial As String = ""
        Dim regdtmFechaFinal As String = ""
        Dim regstrTiendaConcentradorIP As String = ""
        Dim regstrTiendaIP As String = ""

        For Each objRegistroTransmisionPendiente In astrDataArray
            regintCompaniaId = CInt(objRegistroTransmisionPendiente(0))
            regintSucursalId = CInt(objRegistroTransmisionPendiente(1))

            regdtmFechaInicial = CStr(objRegistroTransmisionPendiente(6))
            regdtmFechaFinal = CStr(objRegistroTransmisionPendiente(7))

            regstrTiendaConcentradorIP = CStr(objRegistroTransmisionPendiente(9))
            regstrTiendaIP = CStr(objRegistroTransmisionPendiente(10))

            ' Creamos la etiqueta del mensaje
            Dim strMessageNameId As String = "tblVentaAgregada"
            Dim strMessageLabel As String = Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.strCreateMessageLabel(strMessageNameId, regstrTiendaConcentradorIP, regstrTiendaIP)

            ' Creamos la conexión hacia la cola destino
            Dim strQueueFormatName As String = Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.strCreateDirectFormatName("TCP", regstrTiendaIP, Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.strCPOSServerCCQueueName)

            ' Creamos la conexión hacia la cola de error
            Dim strResponseQueueFormatName As String = Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.strCreateDirectFormatName("TCP", regstrTiendaConcentradorIP, Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.strCCCErrorQueueName)

            ' Creamos el cuerpo del mensaje
            Dim strMessageBody As String = "" & _
            "<tblVentaAgregadaPendiente>" & _
            "<intVentaAgregadaPendienteCompaniaId>" & regintCompaniaId & "</intVentaAgregadaPendienteCompaniaId>" & _
            "<intVentaAgregadaPendienteSucursalId>" & regintSucursalId & "</intVentaAgregadaPendienteSucursalId>" & _
            "<dtmVentaAgregadaPendienteFechainicial>" & regdtmFechaInicial & "</dtmVentaAgregadaPendienteFechainicial>" & _
            "<dtmVentaAgregadaPendienteFechaFinal>" & regdtmFechaFinal & "</dtmVentaAgregadaPendienteFechaFinal>" & _
            "</tblVentaAgregadaPendiente>"

            ' Enviamos el mensaje
            Call Benavides.Data.MQ.MSMQ.clsMQOperation.strSendBinaryMessage(strQueueFormatName, strMessageLabel, strResponseQueueFormatName, Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.strCreateXMLMessage(strMessageNameId, Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.RETRANSMITIR, "CC", strMessageBody))

        Next

    End Function

    '====================================================================
    ' Name       : strGeneraVentaAgregada
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGeneraVentaAgregada() As String

        'Realiza la consulta de las sucursales que no se tiene la venta agregada

        Dim astrDataArray As Array = Benavides.CC.Data.clsVentaAgregada.strBuscarTransmisiones(intDireccionId, intZonaId, intCompaniaid, intSucursalid, CDate(clsCommons.strDMYtoMDY(strFechaInicio)), CDate(clsCommons.strDMYtoMDY(strFechaFinal)), 0, 0, 0, strConnectionString)
        Dim objRegistroTransmisionPendiente As String() = Nothing

        Dim regintCompaniaId As Integer = 0
        Dim regintSucursalId As Integer = 0
        Dim regdtmFechaInicial As DateTime
        Dim regdtmFechaFinal As DateTime
        Dim regintInterlocutorEdi As String = ""


        Dim strRuta As String = System.Configuration.ConfigurationSettings.AppSettings("VentaAgregada")
        Dim strNombreArchivo As String
        Dim strPath As String

        Dim File As System.IO.File
        Dim Archivo As System.IO.StreamWriter

        Dim objArrayDataArchivo As Array = Nothing
        Dim objRegistroArchivoInterfaz As String() = Nothing

        For Each objRegistroTransmisionPendiente In astrDataArray
            regintCompaniaId = CInt(objRegistroTransmisionPendiente(0))
            regintSucursalId = CInt(objRegistroTransmisionPendiente(1))

            regdtmFechaInicial = CDate(objRegistroTransmisionPendiente(6))
            regdtmFechaFinal = CDate(objRegistroTransmisionPendiente(7))

            regintInterlocutorEdi = CStr(objRegistroTransmisionPendiente(11))

            Try
                strNombreArchivo = "VTAAGREG_" & regintInterlocutorEdi & Format(Now(), "yyyyMMdd_HHmm") & ".DAT"
                strPath = strRuta & "\" & strNombreArchivo

                Archivo = File.CreateText(strPath)

                objArrayDataArchivo = Benavides.CC.Data.clsVentaAgregada.strBuscarInterfaz(regintCompaniaId, regintSucursalId, regdtmFechaInicial, regdtmFechaFinal, strConnectionString)

                For Each objRegistroArchivoInterfaz In objArrayDataArchivo
                    Archivo.Write(CStr(objRegistroArchivoInterfaz(0)))
                    Archivo.WriteLine()
                Next

                Archivo.Close()
                Response.Flush()

                strNombreArchivo = "VTAAGREG_" & regintInterlocutorEdi & Format(Now(), "yyyyMMdd_HHmm") & ".H"
                strPath = strRuta & "\" & strNombreArchivo

                Archivo = File.CreateText(strPath)
                Archivo.WriteLine()
                Archivo.Close()
                Response.Flush()

            Catch ex As Exception

            End Try

        Next

    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        strRecordBrowserHTML = ""


        If strCmd = "Generar" Then
            If intDireccionId = -1 Then
                intZonaId = -1
            End If

            If intZonaId = -1 Then
                strCompaniaSucursalId = "-1|-1"
            End If

            If intDireccionId <> 0 And intZonaId <> 0 And Len(strCompaniaSucursalId) > 0 And Len(strFechaInicio) > 0 And Len(strFechaFinal) > 0 Then
                strGeneraVentaAgregada()
            End If

        End If

        If strCmd = "Consultar" Then

            If intDireccionId = -1 Then
                intZonaId = -1
            End If

            If intZonaId = -1 Then
                strCompaniaSucursalId = "-1|-1"
            End If

            If intDireccionId <> 0 And intZonaId <> 0 And Len(strCompaniaSucursalId) > 0 And Len(strFechaInicio) > 0 And Len(strFechaFinal) > 0 Then
                If strRBCmd = "Solicitar" Then
                    Dim strPeticion As String = strSolicitaVentaAgregada()
                End If

                ' Declaramos e inicializamos las constantes locales
                Const intElementsPerPage As Integer = 50
                Const strRecordBrowserName As String = "VentasIntSAPVentaAgregada"

                ' Declaramos e inicializamos las variables locales
                Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)

                ' Buscamos
                ' Dim strNewJavascriptOnClickEvent As String = "onclick=" & strComitasDobles & "window.location='VentasInterfaseVentaAgregada.aspx?strRBCmd=Solicitar&" & "strCmd=" & strCmd & "&intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId & "&intCompaniaId=" & intCompaniaid & "&intSucursalId=" & intSucursalid & "&strFechaInicio=" & strFechaInicio & "&strFechaFinal=" & strFechaFinal & "&intNavegadorRegistrosPagina=" & intSelectedPage & "'" & strComitasDobles

                Dim astrDataArray As Array = Benavides.CC.Data.clsVentaAgregada.strBuscarTransmisiones(intDireccionId, intZonaId, intCompaniaid, intSucursalid, CDate(clsCommons.strDMYtoMDY(strFechaInicio)), CDate(clsCommons.strDMYtoMDY(strFechaFinal)), 1, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

                Dim strCurrentJavascriptOnClickEvent As String = "onclick=" & strComitasDobles & "window.location='VentasInterfaseVentaAgregada.aspx?strCmd=Consultar" & "&amp;intDireccionId=" & intDireccionId & "&amp;intZonaId=" & intZonaId & "&amp;intCompaniaId=" & intCompaniaid & "&amp;intSucursalId=" & intSucursalid & "&amp;strFechaInicio=" & strFechaInicio & "&amp;strFechaFinal=" & strFechaFinal & "&amp;strCmd=Agregar" & "'" & strComitasDobles
                Dim strNewJavascriptOnClickEvent As String = "onclick=""cmdSolicitar_onclick();"""

                ' Obtenemos el HTML
                Dim strReturn As String = Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?strCmd=Consultar" & "&intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId & "&intCompaniaId=" & intCompaniaid & "&intSucursalId=" & intSucursalid & "&strFechaInicio=" & strFechaInicio & "&strFechaFinal=" & strFechaFinal & "&")

                ' Generamos el navegador de registros
                strRecordBrowserHTML = Replace(strReturn, strCurrentJavascriptOnClickEvent, strNewJavascriptOnClickEvent)

            End If


        End If



    End Sub

End Class
