'====================================================================
' Class         : clsSistemaActualizacionesPendientesDetalleSucursal
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Actualizaciones pendientes
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Joaquín Hernández García
' Version       : 1.0
' Last Modified : Thursday, June 24, 2004
'====================================================================
Public Class clsSistemaActualizacionesPendientesDetalleSucursal
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

    ' Variables privadas
    Private strmCompaniaSucursalId As String
    Private strmJavascriptWindowOnLoadCommands As String

    '====================================================================
    ' Name       : intDireccionId
    ' Description: Identificador de la dirección operativa
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDireccionId() As Integer
        Get
            Return CInt(isocraft.commons.clsWeb.strGetPageParameter("intDireccionOperativaId", isocraft.commons.clsWeb.strGetPageParameter("txtDireccionId", "0")))
        End Get
    End Property

    '====================================================================
    ' Name       : intZonaId
    ' Description: Identificador de la zona operativa
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intZonaId() As Integer
        Get
            Return CInt(isocraft.commons.clsWeb.strGetPageParameter("intZonaOperativaId", isocraft.commons.clsWeb.strGetPageParameter("txtZonaId", "0")))
        End Get
    End Property

    '====================================================================
    ' Name       : intCompaniaId
    ' Description: Identificador de la Compania
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intCompaniaId() As Integer
        Get
            Dim astrCompaniaId As Array = Split(strCompaniaSucursalId, "|")
            Dim intValue As Integer = CInt(astrCompaniaId.GetValue(0))
            If intValue = 0 Then
                intValue = CInt(isocraft.commons.clsWeb.strGetPageParameter("intCompaniaId", isocraft.commons.clsWeb.strGetPageParameter("txtCompaniaId", "0")))
            End If
            Return intValue
        End Get
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Identificador de la Sucursal
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intSucursalId() As Integer
        Get
            Dim astrSucursalId As Array = Split(strCompaniaSucursalId, "|")
            Dim intValue As Integer = CInt(astrSucursalId.GetValue(1))
            If intValue = 0 Then
                intValue = CInt(isocraft.commons.clsWeb.strGetPageParameter("intSucursalId", isocraft.commons.clsWeb.strGetPageParameter("txtSucursalId", "0")))
            End If
            Return intValue
        End Get
    End Property

    '====================================================================
    ' Name       : strDireccionOperativaNombre
    ' Description: Nombre de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strDireccionOperativaNombre() As String
        Get
            If intDireccionId > 0 Then
                Dim astrData As Array = Benavides.CC.Data.clstblDireccionOperativa.strBuscar(intDireccionId, "", "", Now, "", 0, 0, strConnectionString)
                If IsArray(astrData) = True AndAlso astrData.Length > 0 Then
                    Return CStr(DirectCast(astrData.GetValue(0), Array).GetValue(1))
                End If
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strZonaOperativaNombre
    ' Description: Nombre de la Zona
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strZonaOperativaNombre() As String
        Get
            If intDireccionId > 0 AndAlso intZonaId > 0 Then
                Dim astrData As Array = Benavides.CC.Data.clstblZonaOperativa.strBuscar(intDireccionId, intZonaId, "", "", Now, "", 0, 0, strConnectionString)
                If IsArray(astrData) = True AndAlso astrData.Length > 0 Then
                    Return CStr(DirectCast(astrData.GetValue(0), Array).GetValue(2))
                End If
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strSucursalNombre
    ' Description: Nombre de la Sucursal
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strSucursalNombre() As String
        Get
            If intCompaniaId > 0 AndAlso intSucursalId > 0 Then
                Dim astrData As Array = Benavides.CC.Data.clstblSucursal.strBuscar(intCompaniaId, intSucursalId, 0, 0, "", 0, 0, 0, Now, "", "", "", "", 0, 0, strConnectionString)

                If IsArray(astrData) = True AndAlso astrData.Length > 0 Then
                    Return CStr(DirectCast(astrData.GetValue(0), Array).GetValue(4))
                End If
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strCompaniaSucursalId
    ' Description: Identificador de la Compania y la Sucursal
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCompaniaSucursalId() As String
        Get
            If Len(strmCompaniaSucursalId) = 0 Then
                strmCompaniaSucursalId = isocraft.commons.clsWeb.strGetPageParameter("cboSucursal", "0|0")
            End If
            If strmCompaniaSucursalId.Equals("0|0") = True Then
                strmCompaniaSucursalId = isocraft.commons.clsWeb.strGetPageParameter("intCompaniaId", "0") & "|" & isocraft.commons.clsWeb.strGetPageParameter("intSucursalId", "0")
            End If
            Return strmCompaniaSucursalId
        End Get
    End Property

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
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSucursal", strCompaniaSucursalId, Benavides.CC.Data.clsTransmision.strEjecutarBuscarActualizacionesPendientesPorSucursal(intDireccionId, intZonaId, 0, 0, 1, 100, strConnectionString), New Integer(1) {0, 1}, 2, 1)
        End If
    End Function

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
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 10
        Const strRecordBrowserName As String = "SistemaActualizacionesPendientesDetalleSucursal"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1"))

        ' Buscamos las sucursales de esta dirección y zona
        Dim astrDataArray As Array = Benavides.CC.Data.clsTransmision.strEjecutarBuscarActualizacionesPendientesPorCaja(intDireccionId, intZonaId, intCompaniaId, intSucursalId, 0, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

        ' Generamos el navegador de registros
        Return strImprimirFuncionTotalElementos(astrDataArray) & Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "&").Replace("<input name=""cmdNavegadorRegistrosAgregar"" type=""button"" class=""boton"" id=""cmdNavegadorRegistrosAgregar"" value="""" onclick=""window.location='SistemaActualizacionesPendientesDetalleSucursal.aspx&amp;strCmd=Agregar'"">", "").Replace("Cortes en cero", "Total de actualizaciones")

    End Function

    Private Function strImprimirFuncionTotalElementos(ByVal astrDataArray As Array) As String
        Dim intValue As Integer = 0
        If astrDataArray.Length > 0 Then
            Dim astrRow As Array
            For Each astrRow In astrDataArray
                intValue += CInt(astrRow.GetValue(4))
            Next
        End If
        Return "<script language=""Javascript"">document.all.intTotalElementos.innerHTML = """ & intValue & """;</script>"
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        Dim strCmd As String = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Validamos que tengamos los parámetros requeridos
        If intDireccionId < 1 OrElse intZonaId < 1 OrElse intCompaniaId < 1 OrElse intSucursalId < 0 Then
            Call Response.Redirect("SistemaConsultarActualizacionesPendientes.aspx")
        End If

        Select Case strCmd

            Case "Retransmitir"

                ' Buscamos la sucursal
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

                            ' -------------------
                            ' Envío de precios
                            ' -------------------

                            ' Total de registros a ser transmitidos
                            Dim intPriceTotalElements As Integer = Benavides.CC.Data.clsTransmision.intEjecutarContarActualizacionesPendientesPreciosPorTransmitirXML(intCompaniaId, intSucursalId, strConnectionString)

                            ' Si existen registros a ser transmitidos
                            If intPriceTotalElements > 0 Then

                                ' Identificador del mensaje a enviar
                                Dim strMessageNameId As String = "tblArticuloSucursal"

                                ' Establecemos el total de registros por mensaje con base en el siguiente cálculo:
                                '   + Número de bytes en 1 registro "tblArticuloSucursal" incluyendo tags XML = 1,200
                                '   + Número máximo de bytes que puede enviar MSMQ por mensaje (4 MB) = 4,194,304
                                '   + Número máximo de registros por mensaje MSMQ = (4,194,304/1,200) = 3495.253 = 3400
                                Dim intElementsPerPage As Integer = 3400
                                Dim intFirstPage As Integer = 0

                                ' Obtenemos el total de mensajes a enviar
                                Dim intTotalPages As Integer = Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateTotalPages(intElementsPerPage, intPriceTotalElements)

                                ' Obtenemos las direcciones IP de la Tienda y su Concentrador
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
                                For intFirstPage = 1 To intTotalPages
                                    Call Benavides.Data.MQ.MSMQ.clsMQOperation.strSendBinaryMessage(strQueueFormatName, strMessageLabel, strResponseQueueFormatName, Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.strCreateXMLMessage(strMessageNameId, Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ACTUALIZAR_AGREGAR, "POS", Benavides.CC.Data.clsTransmision.strEjecutarBuscarActualizacionesPendientesPreciosPorTransmitirXML(intCompaniaId, intSucursalId, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intFirstPage, intElementsPerPage)), intElementsPerPage, strConnectionString)))
                                Next
                                Dim dtmEnd As Date = Now()

                                ' Notificamos al usuario
                                strJavascriptWindowOnLoadCommands &= "  alert(""La información ha sido enviada.\n\r\n\rTotal de artículos: " & intPriceTotalElements & "\n\r\n\r" & "Tiempo de procesamiento (segundos) : " & DateDiff(DateInterval.Second, dtmStart, dtmEnd) & """);"

                            End If

                            ' -------------------
                            ' Envío de ofertas
                            ' -------------------

                            ' Total de registros a ser transmitidos
                            Dim intTotalElements As Integer = Benavides.CC.Data.clsTransmision.intEjecutarContarActualizacionesPendientesOfertasPorTransmitirXML(intCompaniaId, intSucursalId, strConnectionString)

                            ' Si existen registros a ser transmitidos
                            If intTotalElements > 0 Then

                                ' Identificador del mensaje a enviar
                                Dim strMessageNameId As String = "tblArticuloOferta"

                                ' Establecemos el total de registros por mensaje con base en el siguiente cálculo:
                                '   + Número de bytes en 1 registro "tblArticuloOferta" incluyendo tags XML = 1,200
                                '   + Número máximo de bytes que puede enviar MSMQ por mensaje (4 MB) = 4,194,304
                                '   + Número máximo de registros por mensaje MSMQ = (4,194,304/1,200) = 3495.253 = 3400
                                Dim intElementsPerPage As Integer = 3400
                                Dim intFirstPage As Integer = 0

                                ' Obtenemos el total de mensajes a enviar
                                Dim intTotalPages As Integer = Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateTotalPages(intElementsPerPage, intTotalElements)

                                ' Obtenemos las direcciones IP de la Tienda y su Concentrador
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
                                For intFirstPage = 1 To intTotalPages
                                    Call Benavides.Data.MQ.MSMQ.clsMQOperation.strSendBinaryMessage(strQueueFormatName, strMessageLabel, strResponseQueueFormatName, Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.strCreateXMLMessage(strMessageNameId, Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ACTUALIZAR_AGREGAR, "POS", Benavides.CC.Data.clsTransmision.strEjecutarBuscarActualizacionesPendientesOfertasPorTransmitirXML(intCompaniaId, intSucursalId, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intFirstPage, intElementsPerPage)), intElementsPerPage, strConnectionString)))
                                Next
                                Dim dtmEnd As Date = Now()

                                ' Notificamos al usuario
                                strJavascriptWindowOnLoadCommands &= "  alert(""La información ha sido enviada.\n\r\n\rTotal de ofertas: " & intTotalElements & "\n\r\n\r" & "Tiempo de procesamiento (segundos) : " & DateDiff(DateInterval.Second, dtmStart, dtmEnd) & """);"

                            End If

                        End If

                    End If

                End If

        End Select

    End Sub

End Class
