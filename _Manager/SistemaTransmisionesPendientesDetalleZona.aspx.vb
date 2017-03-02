Imports Benavides.POSAdmin.Commons
Imports System.Text
'====================================================================
' Class         : clsSistemaTransmisionesPendientesDetalleZona
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Consultar detalle las transmisiones pendientes por zona.
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Carlos E. Pérez Torres
' Version       : 1.0
' Last Modified : Monday, July 26, 2004
'====================================================================
Public Class clsSistemaTransmisionesPendientesDetalleZona
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

    ' Variables locales privadas
    Private intmReporteId As Integer
    Private intmCompaniaId As Integer
    Private intmSucursalId As Integer

    Private intmTotalElementos As Integer
    Private intmElementosPorPagina As Integer
    Private strmMessageNameId As String
    Private strmNombreObjectoId As String

    Private strmCmd As String
    Private strmJavascriptWindowOnLoadCommands As String

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
    ' Name       : strCmd
    ' Description: Comando a ejecutar
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If strmCmd = "" Then
                strmCmd = CStr(isocraft.commons.clsWeb.strGetPageParameter("strCmd", "Consultar"))
            End If
            Return strmCmd
        End Get
    End Property

    '====================================================================
    ' Name       : intDireccionOperativaId
    ' Description: Identificador de la compañía
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intDireccionOperativaId() As Integer
        Get
            intDireccionOperativaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intDireccionOperativaId", "0"))
            Return intDireccionOperativaId
        End Get
    End Property

    '====================================================================
    ' Name       : intZonaOperativaId
    ' Description: Identificador de la sucursal
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intZonaOperativaId() As Integer
        Get
            intZonaOperativaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboZona", isocraft.commons.clsWeb.strGetPageParameter("intZonaOperativaId", "0")))
            Return intZonaOperativaId
        End Get
    End Property

    '====================================================================
    ' Name       : intCompaniaId
    ' Description: Identificador de la compañía
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intCompaniaId() As Integer
        Get
            intmCompaniaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intCompaniaId", "0"))
            Return intmCompaniaId
        End Get
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Identificador de la sucursal
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intSucursalId() As Integer
        Get
            intmSucursalId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intSucursalId", "0"))
            Return intmSucursalId
        End Get
    End Property

    '====================================================================
    ' Name       : intReporteId
    ' Description: Identificador del tipo de reporte
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intReporteId() As Integer
        Get
            If intmReporteId = 0 Then

                ' Si no encuentra el parámetro
                intmReporteId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboReporteId", "0"))

                ' Busco el valor del combo
                If intmReporteId = 0 Then
                    intmReporteId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intReporteId", "1"))
                End If

            End If
            Return intmReporteId
        End Get
    End Property

    '====================================================================
    ' Name       : intTotalElementos
    ' Description: Total de registros a enviar
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intTotalElementos() As Integer
        Get
            Select Case intReporteId

                Case 1
                    intmTotalElementos = CInt(Benavides.CC.Data.clstblPolizaPendiente.intContar(intCompaniaId, intSucursalId, Now, strConnectionString))
                Case 2
                    intmTotalElementos = CInt(Benavides.CC.Data.clstblVentaDiariaPendiente.intContar(intCompaniaId, intSucursalId, Now, strConnectionString))
                Case 3
                    intmTotalElementos = CInt(Benavides.CC.Data.clstblTicketPendiente.intContar(intCompaniaId, intSucursalId, 0, 0, 0, 0, strConnectionString))
            End Select

            Return intmTotalElementos
        End Get
    End Property

    '====================================================================
    ' Name       : intElementosPorPagina
    ' Description: Total de registros a enviar
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intElementosPorPagina() As Integer
        Get

            ' Si es reporte de ticket
            If intReporteId = 3 Then

                ' Establecemos el total de registros por mensaje con base en el siguiente cálculo:
                '   + Número de bytes en 1 registro "tblArticuloOferta" incluyendo tags XML = 600
                '   + Número máximo de bytes que puede enviar MSMQ por mensaje (4 MB) = 4,194,304
                '   + Número máximo de registros por mensaje MSMQ = (4,194,304/600) = 6990.506667 = 6900
                intmElementosPorPagina = 6900
            Else
                ' De lo contrario
                ' Establecemos el total de registros por mensaje con base en el siguiente cálculo:
                '   + Número de bytes en 1 registro "tblArticuloOferta" incluyendo tags XML = 300
                '   + Número máximo de bytes que puede enviar MSMQ por mensaje (4 MB) = 4,194,304
                '   + Número máximo de registros por mensaje MSMQ = (4,194,304/300) = 13981.01333 = 13900
                intmElementosPorPagina = 13900
            End If

            Return intmElementosPorPagina
        End Get
    End Property

    '====================================================================
    ' Name       : strMessageNameId
    ' Description: Nombre de la etiqueta del mensaje
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strMessageNameId() As String
        Get
            Select Case intReporteId

                Case 1
                    strmMessageNameId = "tblPoliza"

                Case 2
                    strmMessageNameId = "tblVentaDiaria"
                Case 3

                    strmMessageNameId = "Ticket"
            End Select

            Return strmMessageNameId
        End Get
    End Property

    '====================================================================
    ' Name       : strNombreObjectoId
    ' Description: Nombre de la etiqueta del mensaje
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strNombreObjectoId() As String
        Get
            Select Case intReporteId

                Case 1
                    strmNombreObjectoId = "Pólizas"

                Case 2
                    strmNombreObjectoId = "Ventas diarias"
                Case 3

                    strmNombreObjectoId = "Tickets"
            End Select

            Return strmNombreObjectoId
        End Get
    End Property


    '====================================================================
    ' Name       : strLlenarZonaComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboZona"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarZonaComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZona", intZonaOperativaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionOperativaId, 0, strConnectionString), 0, 1, 0)
    End Function

    '====================================================================
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: Establece los comandos Javascript del evento OnLoad
    ' Accessor   : Read
    ' Throws     : Ninguna
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
    ' Name       : strEncabezadoHTML
    ' Description: Encabezado del reporte
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strEncabezadoHTML() As String
        Get

            ' Declaramos las variables
            Dim astrTransmisionPendiente As Array
            Dim objData As Array
            Dim strNombreZonaOperativa As String
            Dim strbldEncabezadoHTML As StringBuilder

            ' Buscamos el nombre de la zona
            objData = Benavides.CC.Data.clstblZonaOperativa.strBuscar(intDireccionOperativaId, intZonaOperativaId, "", "", Now(), "", 0, 0, strConnectionString)

            If IsArray(objData) AndAlso objData.Length > 0 Then
                strNombreZonaOperativa = CStr(DirectCast(objData.GetValue(0), Array).GetValue(2))
            End If

            ' Nombre del objeto pendiente de transmitir
            Dim strNombreTipoTransmision As String

            ' Total de elementos pendientes de transmitir
            Dim intTransmisionesPendientes As Integer = 0

            ' Inicializamos el texto de salida
            strbldEncabezadoHTML = New StringBuilder

            ' De acuerdo al tipo de reporte
            Select Case intReporteId
                Case 1
                    ' Si es 1, buscar las pólizas pendientes de transmitir
                    astrTransmisionPendiente = Benavides.CC.Data.clsTransmision.strEjecutarBuscarTransmisionesPolizaPendientes(intDireccionOperativaId, intZonaOperativaId, 0, 0, strConnectionString)

                Case 2
                    ' Si es 1, buscar las ventas diariras pendientes de transmitir
                    astrTransmisionPendiente = Benavides.CC.Data.clsTransmision.strEjecutarBuscarTransmisionesVentaDiariaPendientes(intDireccionOperativaId, intZonaOperativaId, 0, 0, strConnectionString)

                Case 3
                    ' Si es 1, buscar los tickets pendientes de transmitir
                    astrTransmisionPendiente = Benavides.CC.Data.clsTransmision.strEjecutarBuscarTransmisionesTicketPendientes(intDireccionOperativaId, intZonaOperativaId, 0, 0, strConnectionString)

            End Select

            ' Si encontró resultados
            If IsArray(astrTransmisionPendiente) AndAlso astrTransmisionPendiente.Length > 0 Then

                ' Obtenemos el nombre completo del reporte
                Dim strReporte As String = CStr(DirectCast(astrTransmisionPendiente.GetValue(0), Array).GetValue(0))

                ' Obtenemos la cantidad de elementos pendientes de transmitir
                intTransmisionesPendientes = CInt(DirectCast(astrTransmisionPendiente.GetValue(0), Array).GetValue(1))

                ' Separamos por espacios
                Dim astrReporteNombre As String() = strReporte.Split(" "c)

                ' Asigamos el nombre del reporte a la variable
                strNombreTipoTransmision = CStr(astrReporteNombre.GetValue(0))

                ' Creamos el encabezado del reporte
                strbldEncabezadoHTML.Append("<h2>" & strNombreTipoTransmision & " pendientes de transmitir </h2>")
                strbldEncabezadoHTML.Append("<table width=""60%""  border=""0"" cellspacing=""0"" cellpadding=""0"">")
                strbldEncabezadoHTML.Append("<tr><td width=""16%"" class=""tdtexttablebold"">Mostrando:</td>")
                strbldEncabezadoHTML.Append("<td width=""84%"" class=""tdcontentableblue"">Zona " & strNombreZonaOperativa & "</td></tr>")
                strbldEncabezadoHTML.Append("<tr><td class=""tdtexttablebold"">Total:</td>")
                strbldEncabezadoHTML.Append("<td class=""tdcontentableblue"">" & intTransmisionesPendientes.ToString & " " & strNombreTipoTransmision.ToLower & "</td></tr></table>")

            End If

            ' Regresamos el resultado 
            Return clsCommons.strGenerateJavascriptString(strbldEncabezadoHTML.ToString)

        End Get
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRecordBrowserHTML() As String
        Get
            ' Declaramos e inicializamos las constantes locales
            Const intElementsPerPage As Integer = 13
            Const strRecordBrowserName As String = "SistemaTransmisionesPendientesDetalleZona"

            ' Declaración e inicialización de las variables locales
            Dim astrDataArray As Array
            Dim strbldRecordBrowserHTML As StringBuilder
            Dim strTargetURL As String = "SistemaTransmisionesPendientesDetalleZona.aspx?intReporteId=" & intReporteId & "&intDireccionOperativaId=" & intDireccionOperativaId & "&intZonaOperativaId=" & intZonaOperativaId & "&"

            Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1"))

            strbldRecordBrowserHTML = New StringBuilder

            ' De acuerdo al tipo de reporte
            Select Case intReporteId
                Case 1
                    ' Si es 1, buscar las pólizas pendientes de transmitir
                    astrDataArray = Benavides.CC.Data.clsTransmision.strEjecutarBuscarTransmisionesPolizaPendientesPorSucursal(intDireccionOperativaId, intZonaOperativaId, 0, 0, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

                Case 2
                    ' Si es 1, buscar las ventas diariras pendientes de transmitir
                    astrDataArray = Benavides.CC.Data.clsTransmision.strEjecutarBuscarTransmisionesVentaDiariaPendientesPorSucursal(intDireccionOperativaId, intZonaOperativaId, 0, 0, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

                Case 3
                    ' Si es 1, buscar los tickets pendientes de transmitir
                    astrDataArray = Benavides.CC.Data.clsTransmision.strEjecutarBuscarTransmisionesTicketPendientesPorSucursal(intDireccionOperativaId, intZonaOperativaId, 0, 0, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

            End Select

            ' Almacenamos el resultado
            strbldRecordBrowserHTML.Append(Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strTargetURL))

            Return clsCommons.strGenerateJavascriptString(strbldRecordBrowserHTML.ToString)

        End Get

    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Si el comando es retransmitir
        'If strCmd = "Retransmitir" Then
        Select Case strCmd

            Case "Retransmitir"

                ' Buscamos la tienda a donde se enviará el mensaje
                Dim astrBranchOffice As Array = Benavides.CC.Data.clstblSucursal.strBuscar(intCompaniaId, intSucursalId, 0, 0, "", 0, 0, 0, Now, "", "", "", "", 0, 0, strConnectionString)

                ' Si la sucursal existe
                If astrBranchOffice.Length > 0 Then

                    ' Obtenemos el identificador de la tienda
                    Dim intTiendaId As Integer = CInt(DirectCast(astrBranchOffice.GetValue(0), Array).GetValue(2))

                    ' Si el identificador de la tienda es válido
                    If intTiendaId > 0 Then

                        ' Buscamos la tienda
                        Dim astrStore As Array = Benavides.CC.Data.clstblTienda.strBuscar(intTiendaId, 0, 0, "", "", 0, "", 0, "", "", Now, "", 0, 0, strConnectionString)

                        ' Si la tienda existe
                        If astrStore.Length > 0 Then

                            ' Si existen registros a ser transmitidos
                            If intTotalElementos > 0 Then

                                ' Obtenemos las direcciones IP de la Tienda y su Concentrador
                                Dim intFirstPage As Integer = 0

                                ' Obtenemos el total de mensajes a enviar
                                Dim intTotalPages As Integer = Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateTotalPages(intElementosPorPagina, intTotalElementos)

                                Dim strTiendaConcentradorIP As String = CStr(DirectCast(astrStore.GetValue(0), Array).GetValue(4))
                                Dim strTiendaIP As String = CStr(DirectCast(astrStore.GetValue(0), Array).GetValue(6))

                                ' Creamos la cadena de conexión de la cola destino
                                Dim strQueueFormatName As String = Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.strCreateDirectFormatName("TCP", strTiendaIP, Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.strCPOSServerCCQueueName)

                                ' Creamos la cadena de conexión de la cola de error
                                Dim strResponseQueueFormatName As String = Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.strCreateDirectFormatName("TCP", strTiendaConcentradorIP, Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.strCCCErrorQueueName)

                                ' Creamos la etiqueta del mensaje
                                Dim strMessageLabel As String = Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.strCreateMessageLabel(strMessageNameId, strTiendaConcentradorIP, strTiendaIP)

                                ' Enviamos los mensajes
                                Dim dtmStart As Date = Now()

                                ' Dependiendo del tipo de reporte
                                Select Case intReporteId
                                    Case 1
                                        For intFirstPage = 1 To intTotalPages
                                            Call Benavides.Data.MQ.MSMQ.clsMQOperation.strSendBinaryMessage(strQueueFormatName, strMessageLabel, strResponseQueueFormatName, Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.strCreateXMLMessage(strMessageNameId, Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.RETRANSMITIR, "CC", Benavides.CC.Data.Xml.clstblPolizaPendiente.strBuscar(intCompaniaId, intSucursalId, Now, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intFirstPage, intElementosPorPagina)), intElementosPorPagina, strConnectionString)))
                                        Next
                                    Case 2
                                        For intFirstPage = 1 To intTotalPages
                                            Call Benavides.Data.MQ.MSMQ.clsMQOperation.strSendBinaryMessage(strQueueFormatName, strMessageLabel, strResponseQueueFormatName, Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.strCreateXMLMessage(strMessageNameId, Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.RETRANSMITIR, "CC", Benavides.CC.Data.Xml.clstblVentaDiariaPendiente.strBuscar(intCompaniaId, intSucursalId, Now, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intFirstPage, intElementosPorPagina)), intElementosPorPagina, strConnectionString)))
                                        Next
                                    Case 3
                                        For intFirstPage = 1 To intTotalPages
                                            Call Benavides.Data.MQ.MSMQ.clsMQOperation.strSendBinaryMessage(strQueueFormatName, strMessageLabel, strResponseQueueFormatName, Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.strCreateXMLMessage(strMessageNameId, Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.RETRANSMITIR, "CC", Benavides.CC.Data.Xml.clstblTicketPendiente.strBuscar(intCompaniaId, intSucursalId, 0, 0, 0, 0, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intFirstPage, intElementosPorPagina)), intElementosPorPagina, strConnectionString)))
                                        Next

                                End Select
                                Dim dtmEnd As Date = Now()

                                ' Notificamos al usuario
                                strJavascriptWindowOnLoadCommands &= "  alert(""La información ha sido enviada.\n\r\n\rTotal de " & strNombreObjectoId & ": " & intTotalElementos & "\n\r\n\r" & "Tiempo de procesamiento (segundos) : " & DateDiff(DateInterval.Second, dtmStart, dtmEnd) & """);"

                            End If

                        End If

                    End If

                End If
            Case "Ver"
                If intReporteId = 3 Then
                    Response.Redirect("SistemaTransmisionesPendientesDetalleZona.aspx?strCmd=Detalle&intZonaOperativaId=" & intZonaOperativaId & "&intDireccionOperativaId=" & intDireccionOperativaId & "&intReporteId=3")
                Else
                    Response.Redirect("SistemaTransmisionesPendientesDetalleSucursal.aspx?intReporteId=" & intReporteId & "&intDireccionOperativaId=" & intDireccionOperativaId & "&intZonaOperativaId=" & intZonaOperativaId & "&strCmd=Ver&intCompaniaId=" & intCompaniaId & "&intSucursalId=" & intSucursalId)
                End If

        End Select

        'End If


    End Sub


End Class
