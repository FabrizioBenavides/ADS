Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

Imports System.Text
Imports System.Collections

Imports Benavides.CC.Data
Imports Benavides.CC.Business.clsConcentrador.clsSucursal

Imports Benavides.POSAdmin.Commons

Public Class VentasFacturacionReporteSucursal
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
        'Put user code to initialize the page here
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        'Inicializa Propiedades

        intDireccionOperativaId = GetPageParameter("cboDireccion", 0)
        intZonaOperativaId = GetPageParameter("cboZona", 0)
        strSucursalId = GetPageParameter("cboSucursal", "")

        intEstadoId = GetPageParameter("cboEstado", 0)

        strEmisionInicio = GetPageParameter("strEmisionInicio", GetPageParameter("txtEmisionInicio", ""))
        strEmisionFin = GetPageParameter("strEmisionFin", GetPageParameter("txtEmisionFin", ""))

        strCanceladaInicio = GetPageParameter("strCanceladaInicio", GetPageParameter("txtCanceladaInicio", ""))
        strCanceladaFin = GetPageParameter("strCanceladaFin", GetPageParameter("txtCanceladaFin", ""))

        strClienteRFC = GetPageParameter("strClienteRFC", GetPageParameter("txtClienteRFC", ""))

    End Sub

#End Region

#Region " Class Private Attributes"

    Const strComitasDobles As String = """"
    Private strmJavascriptWindowOnLoadCommands As String

    Private strmcboDireccion As String
    Private strmcboZona As String
    Private strmCboSucursal As String

    Private intmDireccionOperativaId As Integer
    Private intmZonaOperativaId As Integer
    Private strmSucursalId As String

    Private intmEstadoId As Integer
    Private strmEmisionInicio As String
    Private strmEmisionFin As String
    Private strmCanceladaInicio As String
    Private strmCanceladaFin As String
    Private strmClienteRFC As String


    Private dtmDefa As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY("01/01/1900"))
    Private dtmmEmisionInicio As Date
    Private dtmmEmisionFin As Date
    Private dtmmCanceladaInicio As Date
    Private dtmmCanceladaFin As Date

    Private maxPerPage As Integer = 50

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
    ' Name       : strAccion
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strAccion() As String
        Get
            Return Request("strAccion")
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
    ' Name       : intEstadoId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intEstadoId() As Integer
        Get
            Return intmEstadoId
        End Get
        Set(ByVal strValue As Integer)
            intmEstadoId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strClienteRFC
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : string
    '====================================================================
    Public Property strClienteRFC() As String
        Get
            Return strmClienteRFC
        End Get
        Set(ByVal strValue As String)
            strmClienteRFC = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmisionInicio
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : string
    '====================================================================
    Public Property strEmisionInicio() As String
        Get
            Return strmEmisionInicio
        End Get
        Set(ByVal strValue As String)
            strmEmisionInicio = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmisionFin
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : string
    '====================================================================
    Public Property strEmisionFin() As String
        Get
            Return strmEmisionFin
        End Get
        Set(ByVal strValue As String)
            strmEmisionFin = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strCanceladaInicio
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : string
    '====================================================================
    Public Property strCanceladaInicio() As String
        Get
            Return strmCanceladaInicio
        End Get
        Set(ByVal strValue As String)
            strmCanceladaInicio = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCanceladaFin
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : string
    '====================================================================
    Public Property strCanceladaFin() As String
        Get
            Return strmCanceladaFin
        End Get
        Set(ByVal strValue As String)
            strmCanceladaFin = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : dtmEmisionInicio
    ' Description: 
    ' Accessor   : Read 
    ' Output     : date
    '====================================================================
    Public ReadOnly Property dtmEmisionInicio() As Date
        Get
            Dim dtmRegereso As Date = dtmDefa

            If (Len(strEmisionInicio) > 1 AndAlso IsDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strEmisionInicio))) Then
                dtmRegereso = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strEmisionInicio))
            End If

            Return dtmRegereso

        End Get
    End Property

    '====================================================================
    ' Name       : dtmEmisionFin 
    ' Description: 
    ' Accessor   : Read 
    ' Output     : date
    '====================================================================
    Public ReadOnly Property dtmEmisionFin() As Date
        Get
            Dim dtmRegereso As Date = dtmDefa

            If (Len(strEmisionFin) > 1 AndAlso IsDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strEmisionFin))) Then
                dtmRegereso = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strEmisionFin))
            End If

            Return dtmRegereso

        End Get
    End Property

    '====================================================================
    ' Name       : dtmCanceladaInicio
    ' Description: 
    ' Accessor   : Read 
    ' Output     : date
    '====================================================================
    Public ReadOnly Property dtmCanceladaInicio() As Date
        Get
            Dim dtmRegereso As Date = dtmDefa

            If (Len(strCanceladaInicio) > 1 AndAlso IsDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strCanceladaInicio))) Then
                dtmRegereso = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strCanceladaInicio))
            End If

            Return dtmRegereso

        End Get
    End Property

    '====================================================================
    ' Name       : dtmCanceladaFin 
    ' Description: 
    ' Accessor   : Read 
    ' Output     : date
    '====================================================================
    Public ReadOnly Property dtmCanceladaFin() As Date
        Get
            Dim dtmRegereso As Date = dtmDefa

            If (Len(strCanceladaFin) > 1 AndAlso IsDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strCanceladaFin))) Then
                dtmRegereso = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strCanceladaFin))
            End If

            Return dtmRegereso

        End Get
    End Property

    '====================================================================
    ' Name       : strVer
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strVer() As String
        Get
            Return Request("strVer")
        End Get
    End Property

    '====================================================================
    ' Name       : intAgrupado
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intAgrupado() As Integer
        Get
            Dim intRegreso As Integer = -1

            If Len(strVer) > 0 AndAlso CInt(strVer) = 1 Then
                intRegreso = 0
            End If

            If Len(strVer) > 0 AndAlso CInt(strVer) = 2 Then
                intRegreso = 1
            End If

            Return intRegreso
        End Get
    End Property

    '====================================================================
    ' Name       : strConsultarFacturas
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strConsultarFacturas() As String

        Dim htmlResult As String = ""
        Dim strRecordBrowserName As String = "VentasFacturacionReporteSucursal"

        If intDireccionOperativaId = -1 Then
            intZonaOperativaId = -1
        End If

        If intZonaOperativaId = -1 Then
            strSucursalId = "-1|-1"
        End If

        If intAgrupado >= 0 And intDireccionOperativaId <> 0 And intZonaOperativaId <> 0 And Len(strSucursalId) > 0 Then

            ' Declaramos e inicialziamos las variables locales
            Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))

            If intSelectedPage <= 0 Then
                intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
            End If

            Dim objDataArrayFacturas As Array = clsFactura.strBuscar(intDireccionOperativaId, intZonaOperativaId, intCompaniaid, intSucursalid, strClienteRFC, dtmEmisionInicio, dtmEmisionFin, dtmCanceladaInicio, dtmCanceladaFin, intEstadoId, intAgrupado, 0, 0, strConnectionString)

            Dim headers As ArrayList = New ArrayList
            Dim actions As ArrayList = New ArrayList

            Dim columnOrder As Integer()
            Dim pkNames As String()
            Dim pkIndexes As Integer()

            If intAgrupado = 1 Then
                ReDim columnOrder(2)

                headers.Add("SUCURSAL") : columnOrder(0) = 0
                headers.Add("ARCHIVADAS") : columnOrder(1) = 1
                headers.Add("CANCELADAS") : columnOrder(2) = 2

            Else
                ReDim columnOrder(9)

                ReDim pkNames(12)
                ReDim pkIndexes(12)

                headers.Add("SUCURSAL") : columnOrder(0) = 0
                headers.Add("SERIE") : columnOrder(1) = 1
                headers.Add("FOLIO") : columnOrder(2) = 2
                headers.Add("FECHA") : columnOrder(3) = 3
                headers.Add("RFC") : columnOrder(4) = 4
                headers.Add("IMPORTE") : columnOrder(5) = 5
                headers.Add("ESTADO") : columnOrder(6) = 6
                headers.Add("FECHA CANCELACION") : columnOrder(7) = 7
                headers.Add("SERIE A CANCELAR Sign@ture") : columnOrder(8) = 8
                headers.Add("FOLIO A CANCELAR Sign@ture") : columnOrder(9) = 9
                headers.Add("ACCION")

                pkNames(0) = "intDetaFacturaId" : pkIndexes(0) = 10
                pkNames(1) = "intDetaCompaniaId" : pkIndexes(1) = 11
                pkNames(2) = "intDetaSucursalId" : pkIndexes(2) = 12

                pkNames(3) = "strFacSucursal" : pkIndexes(3) = 0
                pkNames(4) = "strFacSucEmision" : pkIndexes(4) = 3
                pkNames(5) = "strFacSucClienteRFC" : pkIndexes(5) = 4
                pkNames(6) = "strFacSucImporte" : pkIndexes(6) = 5
                pkNames(7) = "strFacSucEstado" : pkIndexes(7) = 6

                pkNames(8) = "strFacSucCanceladaFecha" : pkIndexes(8) = 7
                pkNames(9) = "strFacSucCanceladaPrefijo" : pkIndexes(9) = 8
                pkNames(10) = "strFacSucCanceladaFolio" : pkIndexes(10) = 9

                pkNames(11) = "strFacSucCanceladaMotivo" : pkIndexes(11) = 17
                pkNames(12) = "strFacSucCanceladaPor" : pkIndexes(12) = 18

                actions.Add(New Benavides.CC.Commons.clsActionLink("VerDetalle", pkNames, pkIndexes, "imgNRVer.gif", "Haga clic aquí para ver el detalle de la Factura"))

            End If

            htmlResult = "<table width='100%' cellSpacing='0' cellPadding='0' border='0'><tr><td align='right'><input name='cmdExportar' type='button' class='boton' value='Exportar Datos' language='javascript' onclick='return cmdExportar_onclick()'</td></tr></table>"
            htmlResult &= Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objDataArrayFacturas.Length, intSelectedPage, maxPerPage, "VentasFacturacionReporteSucursal.aspx", Nothing)
            htmlResult &= Benavides.CC.Commons.clsRecordBrowserNew.displayTable(headers, objDataArrayFacturas, columnOrder, actions, intSelectedPage, maxPerPage, -1)

        End If

        Return htmlResult

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If strAccion = "Exportar" Then

            Dim strNombreArchivoExcel As String = ""
            Dim strArchivoExcel As New System.Text.StringBuilder
            Dim strRegistroExportar As String() = Nothing

            Dim objDataArrayFacturas As Array = clsFactura.strBuscar(intDireccionOperativaId, intZonaOperativaId, intCompaniaid, intSucursalid, strClienteRFC, dtmEmisionInicio, dtmEmisionFin, dtmCanceladaInicio, dtmCanceladaFin, intEstadoId, intAgrupado, 0, 0, strConnectionString)

            If IsArray(objDataArrayFacturas) AndAlso objDataArrayFacturas.Length > 0 Then

                strArchivoExcel = New System.Text.StringBuilder

                Select Case strVer
                    Case "1"
                        Call strArchivoExcel.Append("COMPANIA")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append("SUCURSAL")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append("SUCURSAL SAP")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append("SUCURSAL NOMBRE")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append("SERIE SISTEMA")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append("FOLIO SISTEMA")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append("FECHA FACTURA")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append("RFC CLIENTE")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append("IMPORTE FACTURA")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append("ESTADO")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append("FECHA CANCELACION")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append("SERIE A CANCELAR Sign@ture")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append("FOLIO A CANCELAR Sign@ture")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append("MOTIVO CANCELACION")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append("CANCELADA POR")
                        Call strArchivoExcel.Append(vbCrLf)

                    Case "2"
                        Call strArchivoExcel.Append("COMPANIA")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append("SUCURSAL")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append("SUCURSAL SAP")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append("SUCURSAL NOMBRE")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append("ARCHIVADAS")
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append("CANCELADAS")
                        Call strArchivoExcel.Append(vbCrLf)
                End Select

                For Each strRegistroExportar In objDataArrayFacturas

                    Select Case strVer
                        Case "1" 'Detalle
                            strNombreArchivoExcel = "FacSucursalDetalle_" & dtmDefa.ToString("yyyymmdd") & ".csv"

                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(11).ToString), ",", " "))
                            Call strArchivoExcel.Append(",")
                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(12).ToString), ",", " "))
                            Call strArchivoExcel.Append(",")
                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(13).ToString), ",", " "))
                            Call strArchivoExcel.Append(",")
                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(14).ToString), ",", " "))
                            Call strArchivoExcel.Append(",")

                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(1).ToString), ",", " "))
                            Call strArchivoExcel.Append(",")
                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(2).ToString), ",", " "))
                            Call strArchivoExcel.Append(",")
                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(3).ToString), ",", " "))
                            Call strArchivoExcel.Append(",")
                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(4).ToString), ",", " "))
                            Call strArchivoExcel.Append(",")
                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(5).ToString), ",", " "))
                            Call strArchivoExcel.Append(",")
                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(6).ToString), ",", " "))
                            Call strArchivoExcel.Append(",")
                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(7).ToString), ",", " "))
                            Call strArchivoExcel.Append(",")
                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(8).ToString), ",", " "))
                            Call strArchivoExcel.Append(",")
                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(9).ToString), ",", " "))
                            Call strArchivoExcel.Append(",")

                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(17).ToString), ",", " "))
                            Call strArchivoExcel.Append(",")
                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(18).ToString), ",", " "))
                            Call strArchivoExcel.Append(",")
                            Call strArchivoExcel.Append(vbCrLf)

                        Case "2" 'Agrupado
                            strNombreArchivoExcel = "FacSucursalAgrupado_" & dtmDefa.ToString("yyyymmdd") & ".csv"

                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(3).ToString), ",", " "))
                            Call strArchivoExcel.Append(",")
                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(4).ToString), ",", " "))
                            Call strArchivoExcel.Append(",")
                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(5).ToString), ",", " "))
                            Call strArchivoExcel.Append(",")
                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(6).ToString), ",", " "))
                            Call strArchivoExcel.Append(",")

                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(1).ToString), ",", " "))
                            Call strArchivoExcel.Append(",")
                            Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(strRegistroExportar(2).ToString), ",", " "))
                            Call strArchivoExcel.Append(vbCrLf)

                    End Select

                Next

                Dim strArchivoDestino As String = "attachment;filename=" & strComitasDobles & strNombreArchivoExcel & strComitasDobles

                Response.ContentType = "application/octet-stream"
                Call Response.AddHeader("Content-Disposition", "attachment;filename=" & strComitasDobles & strNombreArchivoExcel & strComitasDobles)

                Call Response.Write(strArchivoExcel.ToString)
                Call Response.End()


            End If


        End If


    End Sub

End Class
