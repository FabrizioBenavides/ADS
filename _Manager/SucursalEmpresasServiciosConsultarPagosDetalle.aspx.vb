Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert

'====================================================================
' Class         : SucursalEmpresasServiciosConsultarPagosDetalle
' Description   : Drill Down de la consulta de pagos
' Copyright     : (c) Softtek 2008
' Company       : Softtek
' Author        : Oswaldo Laguna
' Last Modified : 7 de Mayo del 2008
'====================================================================

Public Class SucursalEmpresasServiciosConsultarPagosDetalle
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

        intEmpresaServicioId = GetPageParameter("intEmpresaServicioId", GetPageParameter("txtEmpresaServicioId", 0))

        strEmpresaServicioNombreId = GetPageParameter("strEmpresaServicioNombreId", GetPageParameter("txtEmpresaEncontrada", ""))

        strNivel = GetPageParameter("strNivel", GetPageParameter("txtNivel", ""))

        strFechaInicial = GetPageParameter("strFechaInicial", GetPageParameter("txtFechaInicial", ""))

        strFechaFinal = GetPageParameter("strFechaFinal", GetPageParameter("txtFechaFinal", ""))

        intFormaPagoId = GetPageParameter("intFormaPagoId", GetPageParameter("txtFormaPagoIndexOculto", 0))

        intDireccionOperativaId = GetPageParameter("intDireccionOperativaId", GetPageParameter("txtDireccionIdOculto", 0))

        intZonaOperativaId = GetPageParameter("intZonaOperativaId", GetPageParameter("txtZonaIdOculto", 0))

        intSucursalId = GetPageParameter("intSucursalId", GetPageParameter("txtSucursalIdOculto", 0))

        intCompaniaId = GetPageParameter("intCompaniaId", GetPageParameter("txtCompaniaIdOculto", 0))

        strEmpresaServicioNombreIdAnterior = GetPageParameter("txtEmpresaServicioNombreId", "")

    End Sub

#End Region

#Region " Class Private Attributes"

    Private intmEmpresaServicioId As Integer
    Private strmEmpresaServicioNombreId As String
    Private strmNivel As String
    Private strmEmpresaServicioNombreIdAnterior As String
    Private intmFormaPagoId As Integer
    Private intmDireccionId As Integer
    Private intmZonaId As Integer
    Private strmFechaInicial As String
    Private strmFechaFinal As String
    Private strmtxtEmpresaServicioNombreId As String
    Private strmtxtEmpresaEncontrada As String
    Private intmEmpresaIdOculto As Integer
    Private intmCompaniaId As Integer
    Private intmSucursalId As Integer

    Private intmSelectedPage As Integer
    Private strmJavascriptWindowOnLoadCommands As String

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
    ' Name       : strCmdConsulta
    ' Description: Comando que indica cuando hay que buscar la empresa en base al ID
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmdConsulta() As String
        Get
            If Not IsNothing(Request.QueryString("strCmdConsulta")) Then
                Return Request.QueryString("strCmdConsulta")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intSelectedPage
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intSelectedPage() As Integer
        Get
            Return intmSelectedPage
        End Get
        Set(ByVal intValue As Integer)
            intmSelectedPage = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intEmpresaServicioId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intEmpresaServicioId() As Integer
        Get
            Return intmEmpresaServicioId
        End Get
        Set(ByVal intValue As Integer)
            intmEmpresaServicioId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intDireccionOperativaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intDireccionOperativaId() As Integer
        Get
            Return intmDireccionId
        End Get
        Set(ByVal intValue As Integer)
            intmDireccionId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intZonaOperativaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intZonaOperativaId() As Integer
        Get
            Return intmZonaId
        End Get
        Set(ByVal intValue As Integer)
            intmZonaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpresaServicioNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strEmpresaServicioNombreId() As String
        Get
            Return strmEmpresaServicioNombreId
        End Get
        Set(ByVal strValue As String)
            strmEmpresaServicioNombreId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strNivel
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strNivel() As String
        Get
            Return strmNivel
        End Get
        Set(ByVal strValue As String)
            strmNivel = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strEmpresaServicioNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strEmpresaServicioNombreIdAnterior() As String
        Get
            Return strmEmpresaServicioNombreIdAnterior
        End Get
        Set(ByVal strValue As String)
            strmEmpresaServicioNombreIdAnterior = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intFormaPagoId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intFormaPagoId() As Integer
        Get
            Return intmFormaPagoId
        End Get
        Set(ByVal intValue As Integer)
            intmFormaPagoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intCompaniaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intCompaniaId() As Integer
        Get
            Return intmCompaniaId
        End Get
        Set(ByVal intValue As Integer)
            intmCompaniaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intSucursalId() As Integer
        Get
            Return intmSucursalId
        End Get
        Set(ByVal intValue As Integer)
            intmSucursalId = intValue
        End Set
    End Property
    '====================================================================
    ' Name       : strFechaInicial
    ' Description: Fecha inicial
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================

    Public Property strFechaInicial() As String
        Get
            strmFechaInicial = isocraft.commons.clsWeb.strGetPageParameter("txtFechaInicial", isocraft.commons.clsWeb.strGetPageParameter("strFechaInicial", ""))
            If Len(strmFechaInicial) = 0 Then
                Dim dtmYesterday As Date = DateAdd(DateInterval.Day, -1, Now)
                strmFechaInicial = strComplete2Digit(CStr(Day(dtmYesterday))) & "/" & strComplete2Digit(CStr(Month(dtmYesterday))) & "/" & Year(dtmYesterday)
            Else
                Dim astrData As Array = strmFechaInicial.Split("/"c)
                If astrData.Length = 3 Then
                    strmFechaInicial = strComplete2Digit(CStr(astrData.GetValue(0))) & "/" & strComplete2Digit(CStr(astrData.GetValue(1))) & "/" & CStr(astrData.GetValue(2))
                End If
            End If
            Return strmFechaInicial
        End Get
        Set(ByVal strValue As String)
            strmFechaInicial = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strFechaFinal
    ' Description: Fecha final
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strFechaFinal() As String
        Get
            strmFechaFinal = isocraft.commons.clsWeb.strGetPageParameter("txtFechaFinal", isocraft.commons.clsWeb.strGetPageParameter("strFechaFinal", ""))
            If Len(strmFechaFinal) = 0 Then
                strmFechaFinal = strComplete2Digit(CStr(Day(Now))) & "/" & strComplete2Digit(CStr(Month(Now))) & "/" & Year(Now)
            Else
                Dim astrData As Array = strmFechaFinal.Split("/"c)
                If astrData.Length = 3 Then
                    strmFechaFinal = strComplete2Digit(CStr(astrData.GetValue(0))) & "/" & strComplete2Digit(CStr(astrData.GetValue(1))) & "/" & CStr(astrData.GetValue(2))
                End If
            End If
            Return strmFechaFinal
        End Get
        Set(ByVal strValue As String)
            strmFechaFinal = strValue
        End Set
    End Property

    Private Function strComplete2Digit(ByVal strValue As String) As String
        If Len(strValue) = 1 Then
            Return "0" & strValue
        Else
            Return strValue
        End If
    End Function

    '====================================================================
    ' Name       : strtxtEmpresaServicioNombreId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtEmpresaServicioNombreId() As String
        Get
            Return strmtxtEmpresaServicioNombreId
        End Get
        Set(ByVal strValue As String)
            strmtxtEmpresaServicioNombreId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strtxtEmpresaEncontrada
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtEmpresaEncontrada() As String
        Get
            Return strmtxtEmpresaEncontrada
        End Get
        Set(ByVal strValue As String)
            strmtxtEmpresaEncontrada = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intEmpresaIdOculto
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intEmpresaIdOculto() As Integer
        Get
            Return intmEmpresaIdOculto
        End Get
        Set(ByVal intValue As Integer)
            intmEmpresaIdOculto = intValue
        End Set
    End Property
    '====================================================================
    ' Name       : strGetCSVData
    ' Description: Regresa el contenido CSV de la consulta
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetCSVData() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 200
        ' Obtenemos el rango de fechas
        Dim dtmFechaInicial As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaInicial))
        Dim dtmFechaFinal As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaFinal))

        Dim intValueRadioButtons As Integer = CInt(Request.Form("optEmpresa"))
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim aobjDataArray As Array
        Dim aobjDataArrayEmpresas As Array

        Select Case strNivel

            Case "Direccion"

                aobjDataArray = Benavides.CC.Data.clstblEmpresaServicioPago.strExportarDireccion(intEmpresaServicioId, intDireccionOperativaId, intFormaPagoId, dtmFechaInicial, dtmFechaFinal, strConnectionString)

            Case "Zona"

                aobjDataArray = Benavides.CC.Data.clstblEmpresaServicioPago.strExportarZona(intEmpresaServicioId, intDireccionOperativaId, intZonaOperativaId, intFormaPagoId, dtmFechaInicial, dtmFechaFinal, strConnectionString)

            Case "Tienda"

                aobjDataArray = Benavides.CC.Data.clstblEmpresaServicioPago.strExportarTienda(intEmpresaServicioId, intCompaniaId, intSucursalId, intFormaPagoId, dtmFechaInicial, dtmFechaFinal, strConnectionString)

        End Select

        ' Declaramos e inicializamos las variables locales
        Dim astrCSVData As System.Text.StringBuilder = New System.Text.StringBuilder

        ' Si encontramos información
        If IsNothing(aobjDataArray) = False AndAlso aobjDataArray.Length > 0 Then

            Dim blnPrintedHeaders As Boolean

            ' Por cada renglón existente
            For Each objRow As System.Collections.SortedList In aobjDataArray

                If blnPrintedHeaders = False Then

                    ' Por cada columna existente
                    For intCounter As Integer = 0 To objRow.Count - 1

                        ' Agregamos el encabezado
                        Call astrCSVData.Append(objRow.GetKey(intCounter))
                        Call astrCSVData.Append(",")

                    Next

                    ' Agregamos el separador de línea
                    Call astrCSVData.Append(vbCrLf)
                    blnPrintedHeaders = True

                End If

                ' Por cada columna existente
                For intCounter As Integer = 0 To objRow.Count - 1

                    ' Agregamos la columna
                    Call astrCSVData.Append(objRow.GetByIndex(intCounter))
                    Call astrCSVData.Append(",")

                Next

                ' Agregamos el separador de línea
                Call astrCSVData.Append(vbCrLf)

            Next

        End If

        Return astrCSVData.ToString()

    End Function
    '====================================================================
    ' Name       : strGetRecordBrowserHTML()
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String

        Select Case strNivel

            Case "Direccion"

                ' Declaramos e inicializamos las constantes locales
                Const intElementsPerPage As Integer = 50
                Const strRecordBrowserName As String = "SucursalEmpresasServiciosConsultarPagosDireccion"

                ' Obtenemos el rango de fechas
                Dim dtmFechaInicial As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaInicial))
                Dim dtmFechaFinal As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaFinal))

                ' Declaramos e inicializamos las variables locales
                Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
                Dim aobjDataArray As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.clsEmpresaServicioPago.strBuscarPagosDireccion(intEmpresaServicioId, intFormaPagoId, dtmFechaInicial, dtmFechaFinal, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

                ' Generamos el URL destino de las páginas
                Dim strQueryString As String = "txtEmpresaServicioNombreId=" & strEmpresaServicioNombreId & _
                                             "&txtEmpresaServicioId=" & intEmpresaServicioId & _
                                             "&txtDireccionIdOculto=" & intDireccionOperativaId & _
                                             "&txtFechainicial=" & strFechaInicial & _
                                             "&txtFechaFinal=" & strFechaFinal & _
                                             "&txtNivel=" & strNivel & _
                                             "&txtFormaPagoIndexOculto=" & intFormaPagoId & _
                                             "&?"

                ' Generamos el navegador de registros
                Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, aobjDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?" & strQueryString & "&")

            Case "Zona"

                ' Declaramos e inicializamos las constantes locales
                Const intElementsPerPage As Integer = 50
                Const strRecordBrowserName As String = "SucursalEmpresasServiciosConsultarPagosZona"

                ' Obtenemos el rango de fechas
                Dim dtmFechaInicial As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaInicial))
                Dim dtmFechaFinal As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaFinal))

                ' Declaramos e inicializamos las variables locales
                Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
                Dim aobjDataArray As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.clsEmpresaServicioPago.strBuscarPagosZona(intEmpresaServicioId, intDireccionOperativaId, intFormaPagoId, dtmFechaInicial, dtmFechaFinal, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

                ' Generamos el URL destino de las páginas
                Dim strQueryString As String = "txtEmpresaServicioNombreId=" & strEmpresaServicioNombreId & _
                                             "&txtEmpresaServicioId=" & intEmpresaServicioId & _
                                             "&txtEmpresaServicioIdOculto=" & intEmpresaIdOculto & _
                                             "&txtDireccionIdOculto=" & intDireccionOperativaId & _
                                             "&txtZonaIdOculto=" & intZonaOperativaId & _
                                             "&txtFechaInicial=" & strFechaInicial & _
                                             "&txtFechaFinal=" & strFechaFinal & _
                                             "&txtNivel=" & strNivel & _
                                             "&txtFormaPagoIndexOculto=" & intFormaPagoId & _
                                             "&?"

                ' Generamos el navegador de registros
                Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, aobjDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?" & strQueryString & "&")

            Case "Tienda"

                ' Declaramos e inicializamos las constantes locales
                Const intElementsPerPage As Integer = 50
                Const strRecordBrowserName As String = "SucursalEmpresasServiciosConsultarPagosTienda"

                ' Obtenemos el rango de fechas
                Dim dtmFechaInicial As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaInicial))
                Dim dtmFechaFinal As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaFinal))

                ' Declaramos e inicializamos las variables locales
                Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
                Dim aobjDataArray As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.clsEmpresaServicioPago.strBuscarPagosTienda(intEmpresaServicioId, intDireccionOperativaId, intZonaOperativaId, intFormaPagoId, dtmFechaInicial, dtmFechaFinal, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

                ' Generamos el URL destino de las páginas
                Dim strQueryString As String = "txtEmpresaServicioNombreId=" & strEmpresaServicioNombreId & _
                                             "&txtEmpresaServicioId=" & intEmpresaServicioId & _
                                             "&txtEmpresaServicioIdOculto=" & intEmpresaIdOculto & _
                                             "&txtDireccionIdOculto=" & intDireccionOperativaId & _
                                             "&txtZonaIdOculto=" & intZonaOperativaId & _
                                             "&txtFechaInicial=" & strFechaInicial & _
                                             "&txtFechaFinal=" & strFechaFinal & _
                                             "&txtNivel=" & strNivel & _
                                             "&txtFormaPagoIndexOculto=" & intFormaPagoId & _
                                             "&?"

                ' Generamos el navegador de registros
                Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, aobjDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?" & strQueryString & "&")


            Case "Sucursal"

                ' Declaramos e inicializamos las constantes locales
                Const intElementsPerPage As Integer = 50
                Const strRecordBrowserName As String = "SucursalEmpresasServiciosConsultarPagosSucursal"

                ' Obtenemos el rango de fechas
                Dim dtmFechaInicial As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaInicial))
                Dim dtmFechaFinal As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaFinal))

                ' Declaramos e inicializamos las variables locales
                Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
                Dim aobjDataArray As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.clsEmpresaServicioPago.strBuscarPagosSucursal(intEmpresaServicioId, intCompaniaId, intSucursalId, intFormaPagoId, dtmFechaInicial, dtmFechaFinal, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

                ' Generamos el URL destino de las páginas
                Dim strQueryString As String = "txtEmpresaServicioNombreId=" & strEmpresaServicioNombreId & _
                                             "&txtEmpresaServicioId=" & intEmpresaServicioId & _
                                             "&txtEmpresaServicioIdOculto=" & intEmpresaIdOculto & _
                                             "&txtDireccionIdOculto=" & intDireccionOperativaId & _
                                             "&txtZonaIdOculto=" & intZonaOperativaId & _
                                             "&txtCompaniaIdOculto=" & intCompaniaId & _
                                             "&txtSucursalIdOculto=" & intSucursalId & _
                                             "&txtFechaInicial=" & strFechaInicial & _
                                             "&txtFechaFinal=" & strFechaFinal & _
                                             "&txtNivel=" & strNivel & _
                                             "&txtFormaPagoIndexOculto=" & intFormaPagoId & _
                                             "&?"

                ' Generamos el navegador de registros
                Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, aobjDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?" & strQueryString & "&")

        End Select

    End Function
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Si el identificador del elemento es válido
        If intEmpresaServicioId > 0 Then

            ' Obtenemos el elemento
            Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.strBuscarEmpresas(intEmpresaServicioId, strConnectionString)

            ' Si el elemento fue encontrado
            If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                Dim aobjRow As System.Collections.SortedList = DirectCast(aobjData.GetValue(0), System.Collections.SortedList)

                ' Recuperamos sus datos
                strEmpresaServicioNombreId = CStr(aobjRow.Item("strEmpresaServicioNombre"))

            End If

        End If

        Select Case strCmd

            Case "Asignar"

                ' Establecemos en la respuesta los parámetros de configuración del archivo
                Response.ContentType = "application/octet-stream"
                Call Response.AddHeader("Content-Disposition", "attachment; filename=""PagosDeServicios.csv""")
                Call Response.Write(strGetCSVData())
                Call Response.End()

            Case "Ver"

                Dim strValue As String

                Select Case strNivel

                    Case "Direccion"

                        strValue = "Zona"

                    Case "Zona"

                        strValue = "Tienda"

                    Case "Tienda"

                        strValue = "Sucursal"

                End Select

                Call Response.Redirect("SucursalEmpresasServiciosConsultarPagosDetalle.aspx?" & "&intEmpresaServicioId=" & intEmpresaServicioId & "&intEmpresaIdOculto=" & intEmpresaIdOculto & "&intDireccionOperativaId=" & intDireccionOperativaId & "&intZonaOperativaId=" & intZonaOperativaId & "&intCompaniaId=" & intCompaniaId & "&intSucursalId=" & intSucursalId & "&strEmpresaServicioNombreId=" & strEmpresaServicioNombreId & "&strFechaInicial=" & strFechaInicial & "&strFechaFinal=" & strFechaFinal & "&intFormaPagoId=" & intFormaPagoId & "&strNivel=" & strValue)

        End Select

        If strCmdConsulta = "obtenerEmpresa" Then
            'Obtener el nombre de la empresa
            ' Si el identificador del elemento es válido
            If strEmpresaServicioNombreIdAnterior.Length > 0 Then

                ' Obtenemos el elemento
                Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.strBuscarEmpresas(CInt(strEmpresaServicioNombreIdAnterior), strConnectionString)

                ' Si el elemento fue encontrado
                If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                    Dim aobjRow As System.Collections.SortedList = DirectCast(aobjData.GetValue(0), System.Collections.SortedList)

                    ' Recuperamos sus datos
                    strEmpresaServicioNombreId = CStr(aobjRow.Item("strEmpresaServicioNombre"))
                    intEmpresaServicioId = CInt(strEmpresaServicioNombreIdAnterior)

                Else

                    strEmpresaServicioNombreId = ""
                    intEmpresaServicioId = 0

                End If

            End If

        End If

    End Sub

End Class
