Option Strict Off
Option Explicit On 

Imports System
Imports System.IO
Imports System.Configuration
Imports System.Text
Imports Benavides.POSAdmin.Commons
Imports Benavides.Data
Imports Benavides.Data.Xml

Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

Public Class VentasInterfaseSapTrasladoStock
    Inherits System.Web.UI.Page

    ' Variables locales privadas
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private strmDireccionId As String
    Private strmCompaniaSucursalId As String
    Private strmZonaId As String

    '====================================================================
    ' Name       : intDireccionId
    ' Description: Identificador de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intDireccionId() As Integer
        Get

            If Len(strmDireccionId) = 0 Then
                strmDireccionId = isocraft.commons.clsWeb.strGetPageParameter("cboDireccion", "0")
            End If
            If strmDireccionId.Equals("0") = True Then
                strmDireccionId = isocraft.commons.clsWeb.strGetPageParameter("intDireccionId", "0")
            End If
            Return CInt(strmDireccionId)
        End Get
    End Property

    '====================================================================
    ' Name       : intZonaId
    ' Description: Identificador de la Sucursal
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intZonaId() As Integer
        Get
            If Len(strmZonaId) = 0 Then
                strmZonaId = isocraft.commons.clsWeb.strGetPageParameter("cboZona", "0")
            End If
            If strmZonaId.Equals("0") = True Then
                strmZonaId = isocraft.commons.clsWeb.strGetPageParameter("intZonaId", "0")
            End If
            Return CInt(strmZonaId)
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
                intValue = CInt(isocraft.commons.clsWeb.strGetPageParameter("intCompaniaId", "0"))
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
                intValue = CInt(isocraft.commons.clsWeb.strGetPageParameter("intSucursalId", "0"))
            End If
            Return intValue
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
    ' Name       : intMonedaId
    ' Description: Identificador de la Moneda
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intMonedaId() As Integer
        Get
            REM Return CInt(isocraft.commons.clsWeb.strGetPageParameter("intMonedaId", "0"))
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
    ' Description: Nombre de esta página
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
    ' Name       : strCmd 
    ' Description: Obtiene o establece el comando actual
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strCmd() As String
        Get
            Return strmCommand
        End Get
        Set(ByVal strValue As String)
            strmCommand = strValue
        End Set
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
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccion", intDireccionId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString), 0, 1, 1)
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
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZona", intZonaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, 0, strConnectionString), 0, 1, 1)
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
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSucursal", strCompaniaSucursalId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, intZonaId, strConnectionString), New Integer(1) {0, 1}, 2, 1)
        End If
    End Function

    '====================================================================
    ' Name       : strObtenerHTMLNavegadorDeRegistros
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================

    Public Function strObtenerHTMLNavegadorDeRegistros() As String




        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 13
        Const strRecordBrowserName As String = "SistemaTransmisionesPendientesDetalleRed"

        ' Declaración e inicialización de las variables locales
        Dim astrDataArray As Array
        Dim strbldRecordBrowserHTML As StringBuilder


        Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1"))

        REM strbldRecordBrowserHTML = New StringBuilder

        ' De acuerdo al tipo de reporte
        ' Si es 1, buscar las ventas diariras pendientes de transmitir
        REM         astrDataArray = Benavides.CC.Data.clsTransmision.strEjecutarBuscarTransmisionesVentaDiariaPendientesPorDireccion(0, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

        ' Almacenamos el resultado
        REM strbldRecordBrowserHTML.Append(Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strTargetURL))
        REM Response.Write(strbldRecordBrowserHTML)

        REM Return clsCommons.strGenerateJavascriptString(strbldRecordBrowserHTML.ToString)




        ' Declaramos e inicializamos las constantes locales
        Dim j As Integer
        Dim intCompaniaId2 As Integer = 0
        Dim intSucursalId2 As Integer = 0
        Dim intTotalElementos As Integer = 0
        Dim intContador As Integer = 0
        Dim intElementosPorPagina As Integer = 0
        Dim strMessageNameId As String


        Try
            Dim MyPos As Integer = InStr(strCompaniaSucursalId, "|")
            Dim Intsuc As String = Mid(strmCompaniaSucursalId, MyPos + 1, 10)

            REM Const intElementsPerPage As Integer = 10
            REM Const strRecordBrowserName As String = "VentasIntSAPVentaAgregada"

            ' Obtenemos la página actual
            REM Dim intSelectedPage As Integer
            intSelectedPage = 1
            REM = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1"))

            ' Establecemos los eventos onClick actual y futuro
            REM Dim strCurrentJavascriptOnClickEvent As String = "window.location='VentasInterfaseSapVentaAgregada.aspx?intDireccionId=" & intDireccionId & "&amp;intZonaId=" & intZonaId & "&amp;intCompaniaId=" & intCompaniaId & "&amp;intSucursalId=" & intSucursalId & "&amp;strCmd=Agregar'"
            Dim strNewJavascriptOnClickEvent As String = "cmdNavegadorRegistrosAgregar_onclick(" & intDireccionId & ", " & intZonaId & ", " & intCompaniaId & ", " & Intsuc & ")"

            ' Obtenemos el HTML
            Dim strTargetURL As String = strThisPageName & "?intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId & "&intCompaniaId=" & intCompaniaId & "&intSucursalId=" & CInt(Intsuc) & "&"
            Dim strReturn As String = Benavides.CC.Commons.clsRecordBrowser.strGetHTML("VentasIntSAPVentaAgregada", astrDataArray, intSelectedPage, intElementsPerPage, strTargetURL)
            Response.Write(strReturn)


        Catch objException As Exception
            Response.Write("Error...")
            ' Variables locales
            Dim strErrorString As StringBuilder : strErrorString = New StringBuilder
            Dim objApplicationEventLog As System.Diagnostics.EventLog : objApplicationEventLog = New System.Diagnostics.EventLog
            Dim strProductName As String : strProductName = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
            Dim strApplicationName As String : strApplicationName = System.Reflection.Assembly.GetExecutingAssembly.Location
            Dim strVersion As String : strVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
            Dim strSource As String : strSource = objException.Source
            Dim strMessage As String : strMessage = objException.Message
            Dim strStackTrace As String : strStackTrace = objException.StackTrace
            Dim intLineNumber As Integer : intLineNumber = Erl()
            Dim intErrorNumber As Integer : intErrorNumber = Err.Number
            Dim intCategoryNumber As Short : intCategoryNumber = 100

            ' Creamos el mensaje de error
            REM Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
            Call strErrorString.Append("Application name:" & vbCrLf & vbTab & strApplicationName & vbCrLf & vbCrLf)
            Call strErrorString.Append("Version:" & vbCrLf & vbTab & strVersion & vbCrLf & vbCrLf)
            Call strErrorString.Append("Source:" & vbCrLf & vbTab & strSource & vbCrLf & vbCrLf)
            Call strErrorString.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(intErrorNumber) & vbCrLf & vbCrLf)
            Call strErrorString.Append("Line number:" & vbCrLf & vbTab & intLineNumber & vbCrLf & vbCrLf)
            Call strErrorString.Append("Message:" & vbCrLf & vbTab & strMessage & vbCrLf & vbCrLf)
            Call strErrorString.Append("StackTrace:" & vbCrLf & strStackTrace & vbCrLf & vbCrLf)

            Response.Write("Application name:" & vbCrLf & vbTab & strApplicationName & vbCrLf & vbCrLf)
            Response.Write("Version:" & vbCrLf & vbTab & strVersion & vbCrLf & vbCrLf)
            Response.Write("Source:" & vbCrLf & vbTab & strSource & vbCrLf & vbCrLf)
            Response.Write("Error number:" & vbCrLf & vbTab & "0x" & Hex(intErrorNumber) & vbCrLf & vbCrLf)
            Response.Write("Line number:" & vbCrLf & vbTab & intLineNumber & vbCrLf & vbCrLf)
            Response.Write("Message:" & vbCrLf & vbTab & strMessage & vbCrLf & vbCrLf)
            Response.Write("StackTrace:" & vbCrLf & strStackTrace & vbCrLf & vbCrLf)

            ' Creamos un evento para registrar el mensaje de error
            'If Not EventLog.SourceExists(strProductName) Then
            '    Call EventLog.CreateEventSource(strProductName, "Application")
            'End If

            ' Establecemos la fuente del evento
            objApplicationEventLog.Source = strProductName

            ' Escribimos el evento en el Visor de Eventos
            REM Call objApplicationEventLog.WriteEntry(strErrorString.ToString(), EventLogEntryType.Error, Err.Number, intCategoryNumber)

            ' Notificamos el error
            REM Call Err.Raise(intErrorNumber + 1001, "Product name: " & strProductName & "." & strmThisClassName & "." & strmThisMemberName, strMessage)

        End Try

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        REM Response.Write(Request.QueryString("strCmd"))
        If Request.QueryString("strCmd") = "Agregar" Then
        End If
        If Request.QueryString("strCmd") = "Consultar" Then
            REM  strObtenerHTMLNavegadorDeRegistros()
        End If

        If Request.QueryString("strCmd") = "Interfaz" Then
            Dim fdoc As String = ""
            Dim fcont As String = ""
            Dim guia As String = ""
            Dim cmov As String = ""
            Dim compo As String = ""
            Dim compd As String = ""
            Dim art As String = ""
            Dim cant As String = ""

            If Request.QueryString("strCmd") = "Consultar" Then
                If Len(Request.Form("txtFFinal")) = 0 Or Len(Request.Form("txtFInicio")) = 0 Then
                    Response.Write("Captura las fechas para generar la peticion a las tiendas")
                End If
            End If
            Dim str As String 'String variable
            Dim FILE_NAME As String 'Output file name
            Dim FILE_NAMEH As String 'Output file name
            Dim cnt As Integer 'Count of records to be written
            Dim hbuf As String 'Header buffer
            Dim objRegistroTransmisionPendiente As String() = Nothing
            Dim astrDataArray As Array
            Dim intCompaniaId2 As String
            Dim intSucursalId2 As String
            Dim MyPos As Integer = InStr(strCompaniaSucursalId, "|")
            Dim Intsuc As String = Mid(strmCompaniaSucursalId, MyPos + 1, 10)

            REM Dim hora As String = Format(Now(), "yyyyMMdd_HHmm")
            Dim sSiteSettingsPath As String = System.Configuration.ConfigurationSettings.AppSettings("trasladostock")
            FILE_NAME = sSiteSettingsPath & "STOCK_" & Format(Now(), "yyyyMMdd_HHmm") & ".DAT"
            FILE_NAMEH = sSiteSettingsPath & "STOCK_" & Format(Now(), "yyyyMMdd_HHmm") & ".H"
            If File.Exists(FILE_NAME) Then
                Kill(FILE_NAME)
            End If
            Dim sr As StreamWriter = File.CreateText(FILE_NAME)
            cnt = 0

            REM  sr.WriteLine("Traslado de Stock")
            astrDataArray = Benavides.CC.Data.clsTransmision.strEjecutarBuscarTrasladoStock(intDireccionId, intZonaId, intCompaniaId, CInt(Intsuc), CDate(clsCommons.strDMYtoMDY(Request.Form("txtFInicio"))), CDate(clsCommons.strDMYtoMDY(Request.Form("txtFFinal"))), 1, 15, strConnectionString)
            For Each objRegistroTransmisionPendiente In astrDataArray

                fdoc = (objRegistroTransmisionPendiente(3))
                fcont = (objRegistroTransmisionPendiente(3))
                guia = objRegistroTransmisionPendiente(5)
                cmov = objRegistroTransmisionPendiente(6)
                compo = objRegistroTransmisionPendiente(7)
                compd = objRegistroTransmisionPendiente(8)
                art = (objRegistroTransmisionPendiente(10))
                cant = System.Convert.ToString(objRegistroTransmisionPendiente(11))

                hbuf = ""
                hbuf = hbuf & (fdoc)
                hbuf = hbuf & (fcont)
                hbuf = hbuf & Right(Space(16) + (guia), 16)
                hbuf = hbuf & Right(Space(3) + (cmov), 3)
                hbuf = hbuf & Right(Space(4) + (compo), 4)
                hbuf = hbuf & "    "
                hbuf = hbuf & Right(Space(4) + (compd), 4)
                hbuf = hbuf & "    "
                hbuf = hbuf & Right(Space(18) + (art), 18)
                hbuf = hbuf & Right(Space(10) + (cant), 10)

                sr.WriteLine(hbuf)
            Next

            sr.Close()
            Dim srh As StreamWriter = File.CreateText(FILE_NAMEH)
            srh.WriteLine("Header")
            srh.Close()

        End If


    End Sub


    Private Sub InitializeComponent()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub


    Private Sub cmdConsultar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
