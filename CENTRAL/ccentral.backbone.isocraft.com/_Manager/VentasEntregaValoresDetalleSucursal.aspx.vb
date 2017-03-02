Imports Isocraft.Web.Http

'====================================================================
' Class         : clsVentasEntregaValoresDetalleSucursal
' Title         : VentasEntregaValoresDetalleSucursal
' Description   : Consulta el detalle de las entregas de valores a 
'                 nivel sucursal
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Juan Colunga (juan@isocraft.com)
' Last Modified : Friday, April 22, 2005
'====================================================================

Public Class clsVentasEntregaValoresDetalleSucursal
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

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Initialize class properties
        intCompaniaId = GetPageParameter("intCompaniaId", GetPageParameter("cboCompaniaId", 0))
        intSucursalId = GetPageParameter("intSucursalId", GetPageParameter("cboSucursalId", 0))
        intEmpresaValoresId = GetPageParameter("intEmpresaValoresId", 0)
        intOperacionEntregaValoresId = GetPageParameter("intOperacionEntregaValoresId", 0)
        intConceptoEntregaValoresId = GetPageParameter("intConceptoEntregaValoresId", 0)
        intEmpleadoId = GetPageParameter("intEmpleadoId", 0)

        strFechaInicial = isocraft.commons.clsWeb.strGetPageParameter("txtFechaInicial", "01/01/1900")
        strFechaFinal = isocraft.commons.clsWeb.strGetPageParameter("txtFechaFinal", "01/01/1900")

        intcboOperacion = GetPageParameter("cboOperacion", 0)
        intcboRecolectora = GetPageParameter("cboRecolectora", 0)
        intcboDireccion = GetPageParameter("cboDireccion", 0)
        intcboZona = GetPageParameter("cboZona", 0)
        intNavegadorRegistrosPaginaEntregaValores = GetPageParameter("intNavegadorRegistrosPaginaEntregaValores", 1)

        ' Obtenemos los datos de la sucursal
        Dim aobjData As System.Array = Benavides.CC.Data.clsOperacionDEX.aobjBuscarDetalleSucursal(intCompaniaId, intSucursalId, strConnectionString)

        ' Si existen atributos
        If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

            ' Obtenemos sus campos
            strDireccionOperativaNombre = CStr(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("strDireccionOperativaNombre"))
            strZonaOperativaNombre = CStr(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("strZonaOperativaNombre"))
            strSucursalNombre = CStr(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("strSucursalNombre"))

        End If

    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private intmCompaniaId As Integer
    Private intmSucursalId As Integer
    Private intmcboDireccion As Integer
    Private intmcboZona As Integer
    Private strmDireccionOperativaNombre As String
    Private strmZonaOperativaNombre As String
    Private strmSucursalNombre As String

    Private strmFecImporteInicial As String
    Private strmFecImporteFinal As String

    Private strmTotalEnvio As String
    Private strmTotalRecepcion As String

    Private strmFechaInicial As String
    Private strmFechaFinal As String

    Private intmcboOperacion As Integer
    Private intmcboRecolectora As Integer
    Private intmEmpresaValoresId As Integer
    Private intmOperacionEntregaValoresId As Integer
    Private intmConceptoEntregaValoresId As Integer
    Private intmEmpleadoId As Integer
    Private intmNavegadorRegistrosPaginaEntregaValores As Integer

    Private strmTotalEnvioMonedaNacional As String
    Private strmTotalEnvioDolares As String
    Private strmTotalEnvioDocumentos As String
    Private strmTotalRecepcionMonedaNacional As String
    Private strmTotalRecepcionDolares As String
    Private strmTotalRecepcionDocumentos As String


#End Region

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
    ' Name       : intCompaniaId
    ' Description: Identificador de la Compañia
    ' Accessor   : Read, write
    ' Throws     : None
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
    ' Description: Identificador de la Sucursal
    ' Accessor   : Read, write
    ' Throws     : None
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
    ' Name       : intNavegadorRegistrosPaginaEntregaValores
    ' Description: Identificador de la Direccion
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intNavegadorRegistrosPaginaEntregaValores() As Integer
        Get
            Return intmNavegadorRegistrosPaginaEntregaValores
        End Get
        Set(ByVal intValue As Integer)
            intmNavegadorRegistrosPaginaEntregaValores = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intEmpleadoId
    ' Description: Identificador de la Direccion
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intEmpleadoId() As Integer
        Get
            Return intmEmpleadoId
        End Get
        Set(ByVal intValue As Integer)
            intmEmpleadoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intConceptoEntregaValoresId
    ' Description: Identificador de la Direccion
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intConceptoEntregaValoresId() As Integer
        Get
            Return intmConceptoEntregaValoresId
        End Get
        Set(ByVal intValue As Integer)
            intmConceptoEntregaValoresId = intValue
        End Set
    End Property
    '====================================================================
    ' Name       : intOperacionEntregaValoresId
    ' Description: Identificador de la Direccion
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intOperacionEntregaValoresId() As Integer
        Get
            Return intmOperacionEntregaValoresId
        End Get
        Set(ByVal intValue As Integer)
            intmOperacionEntregaValoresId = intValue
        End Set
    End Property
    '====================================================================
    ' Name       : intEmpresaValoresId
    ' Description: Identificador de la Direccion
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intEmpresaValoresId() As Integer
        Get
            Return intmEmpresaValoresId
        End Get
        Set(ByVal intValue As Integer)
            intmEmpresaValoresId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intcboDireccionId
    ' Description: Identificador de la Direccion
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intcboDireccion() As Integer
        Get
            Return intmcboDireccion
        End Get
        Set(ByVal intValue As Integer)
            intmcboDireccion = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intcboZona
    ' Description: Identificador de la Zona
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intcboZona() As Integer
        Get
            Return intmcboZona
        End Get
        Set(ByVal intValue As Integer)
            intmcboZona = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strDireccionOperativaNombre
    ' Description: Nombre de la Direccion
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property strDireccionOperativaNombre() As String
        Get
            Return strmDireccionOperativaNombre
        End Get
        Set(ByVal strValue As String)
            strmDireccionOperativaNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strZonaOperativaNombre
    ' Description: Nombre de la Zona
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property strZonaOperativaNombre() As String
        Get
            Return strmZonaOperativaNombre
        End Get
        Set(ByVal strValue As String)
            strmZonaOperativaNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strSucursalNombre
    ' Description: Nombre de la Zona
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property strSucursalNombre() As String
        Get
            Return strmSucursalNombre
        End Get
        Set(ByVal strValue As String)
            strmSucursalNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFecImporteInicial
    ' Description: strmFecImporteInicial inicial
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strFecImporteInicial() As String
        Get
            Return strmFecImporteInicial
        End Get
        Set(ByVal strValue As String)
            strmFecImporteInicial = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFecImporteFinal
    ' Description: strFecImporteFinal final
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strFecImporteFinal() As String
        Get
            Return strmFecImporteFinal
        End Get
        Set(ByVal strValue As String)
            strmFecImporteFinal = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTotalEnvio
    ' Description: Total de envio
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strTotalEnvio() As String
        Get
            Return strmTotalEnvio
        End Get
        Set(ByVal strValue As String)
            strmTotalEnvio = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTotalRecepcion
    ' Description: Total de recepcion
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strTotalRecepcion() As String
        Get
            Return strmTotalRecepcion
        End Get
        Set(ByVal strValue As String)
            strmTotalRecepcion = strValue
        End Set
    End Property

    Public Property strTotalEnvioMonedaNacional() As String
        Get
            Return strmTotalEnvioMonedaNacional
        End Get
        Set(ByVal strValue As String)
            strmTotalEnvioMonedaNacional = strValue
        End Set
    End Property

    Public Property strTotalEnvioDolares() As String
        Get
            Return strmTotalEnvioDolares
        End Get
        Set(ByVal strValue As String)
            strmTotalEnvioDolares = strValue
        End Set
    End Property

    Public Property strTotalEnvioDocumentos() As String
        Get
            Return strmTotalEnvioDocumentos
        End Get
        Set(ByVal strValue As String)
            strmTotalEnvioDocumentos = strValue
        End Set
    End Property

    Public Property strTotalRecepcionMonedaNacional() As String
        Get
            Return strmTotalRecepcionMonedaNacional
        End Get
        Set(ByVal strValue As String)
            strmTotalRecepcionMonedaNacional = strValue
        End Set
    End Property

    Public Property strTotalRecepcionDolares() As String
        Get
            Return strmTotalRecepcionDolares
        End Get
        Set(ByVal strValue As String)
            strmTotalRecepcionDolares = strValue
        End Set
    End Property

    Public Property strTotalRecepcionDocumentos() As String
        Get
            Return strmTotalRecepcionDocumentos
        End Get
        Set(ByVal strValue As String)
            strmTotalRecepcionDocumentos = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaInicial
    ' Description: 
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strFechaInicial() As String
        Get
            Return strmFechaInicial
        End Get
        Set(ByVal intValue As String)
            strmFechaInicial = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaFinal
    ' Description: 
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strFechaFinal() As String
        Get
            Return strmFechaFinal
        End Get
        Set(ByVal intValue As String)
            strmFechaFinal = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intcboOperacion
    ' Description: Identificador del tipo de Cuenta
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intcboOperacion() As Integer
        Get
            Return intmcboOperacion
        End Get
        Set(ByVal intValue As Integer)
            intmcboOperacion = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intcboRecolectora
    ' Description: Identificador del tipo de Cuenta
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intcboRecolectora() As Integer
        Get
            Return intmcboRecolectora
        End Get
        Set(ByVal intValue As Integer)
            intmcboRecolectora = intValue
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
    ' Name       : strObtenerEntregaValores
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strObtenerEntregaValores() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 50
        Const strRecordBrowserName As String = "VentasEntregaValoresDetalleSucursal"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)

        Dim dtmFechaInicial As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaInicial))
        Dim dtmFechaFinal As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaFinal))

        Dim astrDataArray As Array = Benavides.CC.Data.clsEntregaValores.aobjBuscarEntregaValoresDeSucursal(intcboOperacion, intcboRecolectora, dtmFechaInicial, dtmFechaFinal, intCompaniaId, intSucursalId, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)
        Dim astrDataRow As Array

        ' Generamos el URL destino de las páginas
        Dim strTargetURL As String = strThisPageName & _
                                    "?cboOperacion=" & intcboOperacion & _
                                    "&cboCompaniaId=" & intCompaniaId & _
                                    "&cboSucursalId=" & intSucursalId & _
                                    "&cboRecolectora=" & intcboRecolectora & _
                                    "&txtFechaInicial=" & strFechaInicial & _
                                    "&txtFechaFinal=" & strFechaFinal & _
                                    "&cboDireccion=" & intcboDireccion & _
                                    "&cboZona=" & intcboZona & _
                                    "&intNavegadorRegistrosPaginaDetalleSucursal=" & intSelectedPage & _
                                    "&intNavegadorRegistrosPaginaEntregaValores=" & intmNavegadorRegistrosPaginaEntregaValores & _
                                    "&"

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strTargetURL)

    End Function

    '====================================================================
    ' Name       : strGetCSVData
    ' Description: Regresa el contenido CSV de la consulta
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetCSVData() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 50

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim dtmFechaInicial As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaInicial))
        Dim dtmFechaFinal As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaFinal))


        Dim astrDataArray As Array = Benavides.CC.Data.clsEntregaValores.aobjBuscarEntregaValoresDeSucursal(intcboOperacion, intcboRecolectora, dtmFechaInicial, dtmFechaFinal, intCompaniaId, intSucursalId, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)
        Dim astrCSVData As System.Text.StringBuilder = New System.Text.StringBuilder

        ' Si encontramos información
        If IsNothing(astrDataArray) = False AndAlso astrDataArray.Length > 0 Then

            Dim blnPrintedHeaders As Boolean

            ' Por cada renglón existente
            For Each objRow As System.Collections.SortedList In astrDataArray

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Validamos las precondiciones necesarias para acceder a esta página

        If intCompaniaId = 0 OrElse intSucursalId = 0 Then
            Call Response.Redirect("VentasHome.aspx")
        End If

        Dim intEntregaValoresId As Integer = GetPageParameter("intEntregaValoresId", 0)
        Dim dtmFechaInicial As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaInicial))
        Dim dtmFechaFinal As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaFinal))


        ' Obtenemos los datos de los importes consolidados
        Dim aobjData As System.Array = Benavides.CC.Data.clsEntregaValores.aobjObtenerImportesConsolidados(intcboOperacion, intcboRecolectora, dtmFechaInicial, dtmFechaFinal, intCompaniaId, intSucursalId, strConnectionString)

        ' Si existen atributos
        If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

            ' Por cada renglón existente
            Dim posicionArreglo As Integer = 0
            For Each objRow As System.Collections.SortedList In aobjData

                strFecImporteInicial = CStr(CDate(DirectCast(aobjData.GetValue(posicionArreglo), System.Collections.SortedList).Item("dtmFechaInicial")).ToString("dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
                strFecImporteFinal = CStr(CDate(DirectCast(aobjData.GetValue(posicionArreglo), System.Collections.SortedList).Item("dtmFechaFinal")).ToString("dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))

                If CStr(DirectCast(aobjData.GetValue(posicionArreglo), System.Collections.SortedList).Item("strOperacionEntregaValoresNombreId")) = "ENVIO" Then

                    strTotalEnvioMonedaNacional = FormatCurrency(CStr(DirectCast(aobjData.GetValue(posicionArreglo), System.Collections.SortedList).Item("fltEntregaValoresImporteMonedaNacional")), 2, TriState.False, TriState.False, TriState.True)
                    strTotalEnvioDolares = FormatCurrency(CStr(DirectCast(aobjData.GetValue(posicionArreglo), System.Collections.SortedList).Item("fltEntregaValoresImporteDolares")), 2, TriState.False, TriState.False, TriState.True)
                    strTotalEnvioDocumentos = FormatCurrency(CStr(DirectCast(aobjData.GetValue(posicionArreglo), System.Collections.SortedList).Item("fltEntregaValoresImporteDocumentos")), 2, TriState.False, TriState.False, TriState.True)

                End If

                If CStr(DirectCast(aobjData.GetValue(posicionArreglo), System.Collections.SortedList).Item("strOperacionEntregaValoresNombreId")) = "RECEPCION" Then

                    strTotalRecepcionMonedaNacional = FormatCurrency(CStr(DirectCast(aobjData.GetValue(posicionArreglo), System.Collections.SortedList).Item("fltEntregaValoresImporteMonedaNacional")), 2, TriState.False, TriState.False, TriState.True)
                    strTotalRecepcionDolares = FormatCurrency(CStr(DirectCast(aobjData.GetValue(posicionArreglo), System.Collections.SortedList).Item("fltEntregaValoresImporteDolares")), 2, TriState.False, TriState.False, TriState.True)
                    strTotalRecepcionDocumentos = FormatCurrency(CStr(DirectCast(aobjData.GetValue(posicionArreglo), System.Collections.SortedList).Item("fltEntregaValoresImporteDocumentos")), 2, TriState.False, TriState.False, TriState.True)

                End If
                posicionArreglo = posicionArreglo + 1
            Next
        End If

        ' Execute the selected command
        Select Case strCmd

            Case "Ver"

                ' Dirigimos al usuario hacia el detalle de una operación
                If intEntregaValoresId > 0 Then
                    Call Response.Redirect("VentasEntregaValoresDetalleOperacion.aspx?strCmd=Ver&intCompaniaId=" & intCompaniaId & "&intSucursalId=" & intSucursalId & "&intEntregaValoresId=" & intEntregaValoresId & "&intEmpresaValoresId=" & intEmpresaValoresId & "&intOperacionEntregaValoresId=" & intOperacionEntregaValoresId & "&intConceptoEntregaValoresId=" & intConceptoEntregaValoresId & "&intEmpleadoId=" & intEmpleadoId & "&cboOperacion=" & intcboOperacion & "&cboRecolectora=" & intcboRecolectora & "&txtFechaInicial=" & strFechaInicial & "&txtFechaFinal=" & strFechaFinal & "&cboDireccion=" & intcboDireccion & "&cboZona=" & intcboZona & "&intNavegadorRegistrosPaginaDetalleSucursal=" & GetPageParameter("intNavegadorRegistrosPaginaDetalleSucursal", 1) & "&intNavegadorRegistrosPaginaEntregaValores=" & GetPageParameter("intNavegadorRegistrosPaginaEntregaValores", 1))
                End If

            Case "Exportar"

                ' Establecemos en la respuesta los parámetros de configuración del archivo

                Response.ContentType = "application/octet-stream"
                Call Response.AddHeader("Content-Disposition", "attachment; filename=""EntregasValoresDeSucursal.csv""")
                Call Response.Write(strGetCSVData())
                Call Response.End()

        End Select

    End Sub

End Class
