'====================================================================
' Class         : clsPopupDocumento
' Title         : Grupo Benavides. Plantilla de PopUps
' Description  : Plantilla de Documento  de Fotolab 
' Copyright    : 2003-2006 All rights reserved.
' Company    : Neitek Solutions S.A. de C.V.
' Author        : Enrique Longoria
' Version       : 1.0
' Last Modified : Thu, Jan 27th, 2005
'====================================================================

#Region "Imports"
Imports System.Text
Imports System.Collections
Imports prjFotolabBusiness.Benavides.Fotolab.Utils
Imports prjFotolabBusiness.Benavides.Fotolab.Data
#End Region

Public MustInherit Class clsPopupDocumento
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

#Region "Properties"
    Protected Const _POPUP As String = "Popup"
    Protected Const _MAX_PER_PAGE As Integer = 10

    Protected _popUpHeader As String
    Protected strmJavascriptWindowOnLoadCommands As String
    Protected strmCommand As String
    Protected _clsServicesObj As prjFotolabBusiness.Benavides.Fotolab.Data.clsServices
    Protected _htmlResult As String
    Protected _filterValues As String
    Protected _idObj As String
    Protected _displayObj As String
    Protected _screenName As String
    Protected _PopupListHtml As String

    Protected aux As Integer
    Protected extraHtmlInicio As String
    Protected extraHtmlFinal As String
    Protected extraScript As String
    Protected extraScriptAfterLoadValues As String

#End Region

#Region "Accesors"

    '====================================================================
    ' Name       : screenName
    ' Description: Obtiene el header de el popup
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '==================================================================== 
    Protected Property screenName() As String
        Get
            Return _screenName
        End Get
        Set(ByVal strValue As String)
            _screenName = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : PopupListHtml
    ' Description: Obtiene el header de el popup
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '==================================================================== 
    Protected Property PopupListHtml() As String
        Get
            Return _PopupListHtml
        End Get
        Set(ByVal strValue As String)
            _PopupListHtml = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strSucursalNombre
    ' Description: Id de la sucursal y compania como string 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strNombreSucursal() As String
        Get
            Return CStr(Me.intCompaniaId) + "-" + CStr(Me.intSucursalId)
        End Get
    End Property

    '====================================================================
    ' Name       : strSucursalId
    ' Description: Id de la sucursal y compania como string 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalId() As String
        Get
            Return CStr(Me.intCompaniaId) + "-" + CStr(Me.intSucursalId)
        End Get
    End Property
    '====================================================================
    ' Name       : displayObj
    ' Description: Obtiene el header de el popup
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '==================================================================== 
    Protected Property displayObj() As String
        Get
            Return _displayObj
        End Get
        Set(ByVal strValue As String)
            _displayObj = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : idObj
    ' Description: Obtiene el header de el popup
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '==================================================================== 
    Protected Property idObj() As String
        Get
            Return _idObj
        End Get
        Set(ByVal strValue As String)
            _idObj = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : filterValues
    ' Description: Obtiene el header de el popup
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '==================================================================== 
    Protected Property filterValues() As String
        Get
            Return _filterValues
        End Get
        Set(ByVal strValue As String)
            _filterValues = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : popUpHeader
    ' Description: Obtiene el header de el popup
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '==================================================================== 
    Protected Property popUpHeader() As String
        Get
            Return _popUpHeader
        End Get
        Set(ByVal strValue As String)
            _popUpHeader = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : clsServicesObj
    ' Description: Obtiene el objeto de la clase
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : clsServices
    '==================================================================== 
    Public Property clsServicesObj() As prjFotolabBusiness.Benavides.Fotolab.Data.clsServices
        Get
            Return Me._clsServicesObj
        End Get
        Set(ByVal Value As prjFotolabBusiness.Benavides.Fotolab.Data.clsServices)
            Me._clsServicesObj = Value
        End Set
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
    ' Name       : intGrupoUsuarioId
    ' Description: Identificador del Grupo de Usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
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
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime(clsDateUtil.DATE_HOUR_FORMAT)
        End Get
    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: URL de esta página
    ' Accessor   : Read
    ' Throws     : Ninguna
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
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overridable ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorFotolab")
        End Get
    End Property

    '====================================================================
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: Establece los comandos Javascript del evento OnLoad
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overridable Property strJavascriptWindowOnLoadCommands() As String
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
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strCmd() As String
        Get
            Return strmCommand
        End Get
        Set(ByVal strValue As String)
            strmCommand = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Id de la sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intSucursalId() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intSucursalId", "", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : intCompaniaId
    ' Description: Id de la sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intCompaniaId() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intCompaniaId", "", Request, Server)
        End Get
    End Property
#End Region

#Region "popup Template"
    '====================================================================
    ' Name       : displayPopupList
    ' Description: Regresa el HTML del navegador de registros de acuerdo al popup que se este llamado (screenName)
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function displayPopupList() As String
        Dim popupHtml As String
        'leo el comando que me indica qu popup voy a desplegar
        If screenName = "" Then
            screenName = com.isocraft.commons.clsWeb.strGetPageParameter("screenName", com.isocraft.commons.clsWeb.strGetPageParameter("cmdConsultar", ""), Request)
        End If
        'Ejecutamos el popUp indicado
        Select Case screenName
            Case "tblConsumidorFotolab"
                popupHtml = Me.popuptblConsumidorFotolab()
            Case "tblDireccionOperativa"
                popupHtml = Me.popuptblDireccionOperativa()
            Case "tblZonaOperativa"
                popupHtml = Me.popuptblZonaOperativa()
            Case "tblDireccionOperativaSucursal"
                popupHtml = Me.popuptblDireccionOperativaSucursal()
            Case "tblZonaOperativaSucursal"
                popupHtml = Me.popuptblZonaOperativaSucursal()
            Case "popupFarmaciaLaboratorio"
                popupHtml = Me.popupFarmaciaLaboratorio()
            Case "tblLaboratorio"
                popupHtml = Me.popuptblLaboratorio()
            Case "popupFotolabLaboratorio"
                popupHtml = Me.popupFotolabLaboratorio()
            Case "popupLabIngOrd"
                popupHtml = Me.popupLabIngOrd()
            Case "popupArticuloFotolab"
                popupHtml = Me.popupArticuloFotolab()
            Case "popupClasificacion"
                popupHtml = Me.popupClasificacion()
            Case "popupMarcaRollo"
                popupHtml = Me.popupMarcaRollo()
            Case "popupClientesPorLaboratorio"
                popupHtml = Me.popupClientesPorLaboratorio()
            Case "popupArticuloEspecialFotolab"
                popupHtml = Me.popupArticuloEspecialFotolab()
            Case "popupFarmacias"
                popupHtml = Me.popupFarmacias()
            Case "popupSucursalesRemisiones"
                popupHtml = Me.popupSucursalesRemisiones()
            Case "popupClientesPorLaboratorioR"
                popupHtml = Me.popupClientesPorLaboratorioR()
            Case "popupExposiciones"
                popupHtml = Me.popupExposiciones()
            Case "popupFormatoRollo"
                popupHtml = Me.popupFormatoRollo()
            Case "popupISO"
                popupHtml = Me.popupISO()
            Case "popupServicios"
                popupHtml = Me.popupServicios()
            Case "popupTamanio"
                popupHtml = Me.popupTamanio()
            Case "popupClasificacion2"
                popupHtml = Me.popupClasificacion2()
            Case "popupMarcaRollo2"
                popupHtml = Me.popupMarcaRollo2()
            Case "popupClasificacionArticulo2"
                popupHtml = Me.popupClasificacionArticulo2()
            Case Else
        End Select

        Return popupHtml
    End Function

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function strRecordBrowserHTML( _
    ByVal headers As ArrayList, _
    ByVal displayIndex As Integer, _
    ByVal pkNames As String(), _
    ByVal pkIndexes As Integer(), _
    ByVal columnOrder As Integer(), _
    ByVal maxPerPage As Integer, _
    ByVal strCmd As String _
    ) As String
        Dim dispIndex(0) As Integer
        dispIndex(0) = displayIndex

        Return strRecordBrowserHTML(headers, dispIndex, pkNames, pkIndexes, columnOrder, maxPerPage, strCmd)
    End Function
    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function strRecordBrowserHTML( _
    ByVal headers As ArrayList, _
    ByVal displayIndex As Integer(), _
    ByVal pkNames As String(), _
    ByVal pkIndexes As Integer(), _
    ByVal columnOrder As Integer(), _
    ByVal maxPerPage As Integer, _
    ByVal strCmd As String _
    ) As String
        Dim totalRows As Integer
        Dim dataArray, elemArray As Array
        Const intElementsPerPage As Integer = 1
        Dim intSelectedPage As Integer

        Dim htmlresult As StringBuilder = New StringBuilder
        ' Declaramos e inicializamos las variables locales
        intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        If intSelectedPage <= 0 Then
            'intSelectedPage = 1
            intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
        End If

        ' Obtenemos los listados que ya se han capturado previamente.
        dataArray = clsServicesObj.strConsultarListado(strCmd, Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, _MAX_PER_PAGE)
        If dataArray.Length > 0 Then
            elemArray = DirectCast(dataArray.GetValue(0), Array)
            totalRows = CInt(elemArray.GetValue(elemArray.Length - 1))
        End If
        Dim actions As ArrayList = New ArrayList
        actions.Add(New clsActionLink("Añadir", pkNames, pkIndexes, "icono_asignar.gif", "Haga clic aquí para seleccionar este elemento"))

        'displayPopupScroll

        If totalRows = 1 And intSelectedPage = 1 Then
            htmlresult.Append("loadElement('Añadir','intCcsssId','")
            htmlresult.Append(CStr(elemArray.GetValue(pkIndexes(0))))
            Dim x As Integer

            For x = 0 To displayIndex.Length - 1
                htmlresult.Append("','")
                htmlresult.Append(CStr(elemArray.GetValue(displayIndex(x))))
            Next x
            htmlresult.Append("');")

            Return htmlresult.ToString
        Else
            htmlresult.Append(clsHTMLUtils.displayScroll(totalRows, intSelectedPage, _MAX_PER_PAGE, "PopupDocumento.aspx", Nothing, "intNavegadorRegistrosPagina", "../static/images/"))
            htmlresult.Append(clsHTMLUtils.displayPopUpTable(headers, dataArray, columnOrder, displayIndex, actions, intSelectedPage, _MAX_PER_PAGE, -1))
            PopupListHtml = htmlresult.ToString
            Return ""
        End If

    End Function

    '====================================================================
    ' Name       : desplegarExtraHtmlInicio
    ' Description: Despliega html extra que se desee agregar al  inicio de la tabla
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Nothing
    '====================================================================
    Public Function desplegarExtraHtmlInicio() As String
        Return Me.extraHtmlInicio
    End Function

    '====================================================================
    ' Name       : desplegarExtraScript
    ' Description: Despliega js extra que se desee agregar el loadElement()
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Nothing
    '====================================================================
    Public Function desplegarExtraScript() As String
        Return Me.extraScript
    End Function

    '====================================================================
    ' Name       : desplegarScriptAfterLoadValues
    ' Description: Despliega js extra que se desee agregar el loadElement() despues de bajar los valores
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Nothing
    '====================================================================
    Public Function desplegarScriptAfterLoadValues() As String
        Return Me.extraScriptAfterLoadValues
    End Function

    '====================================================================
    ' Name       : desplegarExtraHtmlFinal
    ' Description: Despliega html extra que se desee agregar al  inicio de la tabla
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Nothing
    '====================================================================
    Public Function desplegarExtraHtmlFinal() As String
        Return Me.extraHtmlFinal
    End Function

    '====================================================================
    ' Name       : checkPermission
    ' Description: Verifica si se cuenta con los permisos necesarios para ver esta pantalla
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Nothing
    '====================================================================
    Protected Overridable Sub checkPermission()
        'Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If
    End Sub

    '====================================================================
    ' Name       : Page_Load
    ' Description: Evento de la carga de la página
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Nothing
    '====================================================================
    Protected Overridable Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        checkPermission()
    End Sub
#End Region

#Region "Each popup Implementation"

    '====================================================================
    ' Name       : popuptblConsumidorFotolab
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popuptblConsumidorFotolab() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Clientes"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Data.clstblConsumidorFotolab.SERVICIOS
        'headers.Add("Identificador")
        headers.Add("Razón Social")
        headers.Add("Teléfono")
        headers.Add("Email")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intConsumidorFotolabId"}
        Dim pkIndexes As Integer() = {0}
        Dim dispIndexes As Integer() = {1, 2, 3}
        Dim columnOrder As Integer() = {1, 2, 3}
        Dim extraS As StringBuilder = New StringBuilder

        extraS.Append("if (opener.document.forms[0].strConsumidorFotolabNombreA != null) {")
        extraS.Append(" opener.document.forms[0].strConsumidorFotolabNombreA.value=args[3];")
        extraS.Append(" opener.document.forms[0].strConsumidorFotolabTelefono.value=args[4];")
        '   extraS.Append("opener.document.forms[0].strConsumidorFotolabCorreo.value=args[5];")
        extraS.Append(" opener.setClienteView(true,'fieldborderlessBlue','hidden'); ")
        extraS.Append("opener.document.forms[0].dtmOrdenFechaPrometidaDia.focus();  }")
        Me.extraScript = extraS.ToString
        popupHtml = Me.strRecordBrowserHTML(headers, dispIndexes, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, Me._POPUP)
        Return popupHtml
    End Function

    '====================================================================
    ' Name       : popuptblDireccionOperativaSucrusal
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popuptblDireccionOperativaSucursal() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Dirección Operativa Sucursal"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsAsignacionFotolabAFarmacia.SERVICIOS
        headers.Add("Identificador")
        headers.Add("Nombre")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intDireccionOperativaIdSucursal"}
        Dim pkIndexes As Integer() = {0}
        Dim columnOrder As Integer() = {0, 1}
        popupHtml = Me.strRecordBrowserHTML(headers, 1, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "DIRECCIONOPERATIVASUCURSAL")
        Me.extraHtmlFinal += "<input name='btnTodos' type='button' class='boton' onClick=javascript:loadElement('','','-Todos-','-1') value='Todos'>" + vbNewLine
        Return popupHtml
    End Function


    '====================================================================
    ' Name       : popuptblZonaOperativaSucursal
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popuptblZonaOperativaSucursal() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Zona Operativa Sucursal"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsAsignacionFotolabAFarmacia.SERVICIOS
        headers.Add("Identificador")
        headers.Add("Nombre")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intZonaOperativaIdSucursal"}
        Dim pkIndexes As Integer() = {0}
        Dim columnOrder As Integer() = {0, 1}
        popupHtml = Me.strRecordBrowserHTML(headers, 1, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "ZONAOPERATIVASUCURSAL")
        Me.extraHtmlFinal += "<input name='btnTodos' type='button' class='boton' onClick=javascript:loadElement('','','-Todos-','-1') value='Todos'>" + vbNewLine
        Return popupHtml
    End Function

    '====================================================================
    ' Name       : popuptblDireccionOperativa
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popuptblDireccionOperativa() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Dirección Operativa"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsConsultaClientes.SERVICIOS
        headers.Add("Identificador")
        headers.Add("Nombre")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intDireccionOperativaId"}
        Dim pkIndexes As Integer() = {0}
        Dim columnOrder As Integer() = {0, 1}
        popupHtml = Me.strRecordBrowserHTML(headers, 1, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "DIRECCIONOPERATIVA")
        Me.extraHtmlFinal += "<input name='btnTodos' type='button' class='boton' onClick=javascript:loadElement('','','-Todos-','-1') value='Todos'>" + vbNewLine
        Return popupHtml
    End Function


    '====================================================================
    ' Name       : popuptblZonaOperativa
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popuptblZonaOperativa() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Zona Operativa"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsConsultaClientes.SERVICIOS
        headers.Add("Identificador")
        headers.Add("Nombre")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intZonaOperativaId"}
        Dim pkIndexes As Integer() = {0}
        Dim columnOrder As Integer() = {0, 1}
        popupHtml = Me.strRecordBrowserHTML(headers, 1, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "ZONAOPERATIVA")
        Me.extraHtmlFinal += "<input name='btnTodos' type='button' class='boton' onClick=javascript:loadElement('','','-Todos-','-1') value='Todos'>" + vbNewLine
        Return popupHtml
    End Function


    '====================================================================
    ' Name       : popupLabIngOrd
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popupLabIngOrd() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Laboratorios"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsCapturaOrdenes.SERVICIOS
        headers.Add("No. Laboratorio")
        headers.Add("Nombre")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intCcsssId"}
        Dim pkIndexes As Integer() = {0}
        Dim columnOrder As Integer() = {1, 2}
        popupHtml = Me.strRecordBrowserHTML(headers, 2, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "LABORATORIOS")
        Me.extraScriptAfterLoadValues = " opener.obtenerLaboratorio(); "
        Return popupHtml
    End Function



    '====================================================================
    ' Name       : tblLaboratorio
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popuptblLaboratorio() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Farmacias"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsConsultaOrdenes.SERVICIOS
        headers.Add("No. Farmacia")
        headers.Add("Nombre")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intCcsssId"}
        Dim pkIndexes As Integer() = {0}
        Dim columnOrder As Integer() = {0, 1}
        popupHtml = Me.strRecordBrowserHTML(headers, 1, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "LABORATORIO")
        Return popupHtml
    End Function


    '====================================================================
    ' Name       : popupFarmaciaLaboratorio
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popupFotolabLaboratorio() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Farmacias"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.ClsConsultaOrdenesFotolab.SERVICIOS
        headers.Add("No. Farmacia")
        headers.Add("Nombre")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intCcsssId"}
        Dim pkIndexes As Integer() = {0}
        Dim columnOrder As Integer() = {0, 1}
        popupHtml = Me.strRecordBrowserHTML(headers, 1, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "FARMACIALABORATORIO")
        Return popupHtml
    End Function

    '====================================================================
    ' Name       : popupFarmaciaLaboratorio
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popupFarmaciaLaboratorio() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Laboratorios"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsConsultaOrdenesFarmacia.SERVICIOS
        headers.Add("No. Laboratorio")
        headers.Add("Nombre")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intCcsssId"}
        Dim pkIndexes As Integer() = {0}
        Dim columnOrder As Integer() = {0, 1}
        popupHtml = Me.strRecordBrowserHTML(headers, 1, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "FARMACIALABORATORIO")
        Return popupHtml
    End Function

    '====================================================================
    ' Name       : popupFarmacias
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popupFarmacias() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Farmacias"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Data.clstblSucursal.SERVICIOS
        headers.Add("No. Laboratorio")
        headers.Add("Nombre")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intCcsssId"}
        Dim pkIndexes As Integer() = {0}
        Dim columnOrder As Integer() = {1, 2}
        popupHtml = Me.strRecordBrowserHTML(headers, 2, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "TraerListado")
        Return popupHtml
    End Function

    '====================================================================
    ' Name       : popupSucursalesRemisiones
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popupSucursalesRemisiones() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Farmacias"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Data.clstblSucursal.SERVICIOS
        headers.Add("No. Laboratorio")
        headers.Add("Nombre")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intCcsssId"}
        Dim pkIndexes As Integer() = {1}
        Dim columnOrder As Integer() = {1, 2}
        popupHtml = Me.strRecordBrowserHTML(headers, 2, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "TraerListado")
        Return popupHtml
    End Function

    '====================================================================
    ' Name       : popupArticuloFotolab
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popupArticuloFotolab() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Trabajos"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsCapturaOrdenes.SERVICIOS
        headers.Add("Código")
        'headers.Add("id Articulo Fotolab")
        headers.Add("Nombre")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intCcsssId"}
        Dim pkIndexes As Integer() = {1}
        Dim columnOrder As Integer() = {0, 2}
        popupHtml = Me.strRecordBrowserHTML(headers, 2, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "ARTICULOFOTOLAB")
        Return popupHtml
    End Function


    '====================================================================
    ' Name       : popupArticuloFotolabEspecial
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popupArticuloFotolabEspecial() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Trabajos"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsCapturaOrdenesDigitales.SERVICIOS
        headers.Add("Código")
        'headers.Add("id Articulo Fotolab")
        headers.Add("Nombre")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intCcsssId"}
        Dim pkIndexes As Integer() = {1}
        Dim columnOrder As Integer() = {0, 2}
        popupHtml = Me.strRecordBrowserHTML(headers, 2, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "ARTICULOFOTOLAB")
        Return popupHtml
    End Function

    '====================================================================
    ' Name       : popupClasificacionArticulo2
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popupClasificacionArticulo2() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Clasificacion"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Data.clstblClasificacion2.SERVICIOS
        headers.Add("Identificador")
        headers.Add("Clasificacion")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intClasificacionArticulo2Id"}
        Dim pkIndexes As Integer() = {0}
        Dim columnOrder As Integer() = {0, 1}
        popupHtml = Me.strRecordBrowserHTML(headers, 1, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "TraerListado")
        Return popupHtml
    End Function

    '====================================================================
    ' Name       : popupClasificacion
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popupClasificacion() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Clasificacion"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsArticuloFotolab.SERVICIOS
        headers.Add("Identificador")
        headers.Add("Clasificacion")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intClasificacionArticuloId"}
        Dim pkIndexes As Integer() = {0}
        Dim columnOrder As Integer() = {0, 1}
        popupHtml = Me.strRecordBrowserHTML(headers, 1, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "CLASIFICACIONCOMBO")
        Return popupHtml
    End Function

    '====================================================================
    ' Name       : popupMarcaRollo
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popupMarcaRollo() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Marcas de Rollo"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Data.clstblMarcaRollo.SERVICIOS
        headers.Add("Identificador")
        headers.Add("Clasificacion")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intMarcaRolloId"}
        Dim pkIndexes As Integer() = {0}
        Dim columnOrder As Integer() = {0, 1}
        popupHtml = Me.strRecordBrowserHTML(headers, 1, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "MARCASROLLO")
        Return popupHtml
    End Function

    '====================================================================
    ' Name       : popupMarcaRollo
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popupMarcaRollo2() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Marcas de Rollo"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsReporteTrabajos.SERVICIOS
        headers.Add("Identificador")
        headers.Add("Clasificacion")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intMarcaRolloId"}
        Dim pkIndexes As Integer() = {0}
        Dim columnOrder As Integer() = {0, 1}
        popupHtml = Me.strRecordBrowserHTML(headers, 1, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "MARCASROLLO")
        Return popupHtml
    End Function

    '====================================================================
    ' Name       : popupClientesPorLaboratorio
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popupClientesPorLaboratorio() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Farmacias"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsProcesoOrdenes.SERVICIOS
        headers.Add("Identificador")
        headers.Add("Nombre")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intCcsssId"}
        Dim pkIndexes As Integer() = {0}
        Dim columnOrder As Integer() = {1, 2}
        popupHtml = Me.strRecordBrowserHTML(headers, 2, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "CLIENTES")
        Return popupHtml
    End Function

    '====================================================================
    ' Name       : popupClientesPorLaboratorioR
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popupClientesPorLaboratorioR() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Farmacias"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsProcesoOrdenes.SERVICIOS
        headers.Add("Identificador")
        headers.Add("Nombre")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intCcsssId"}
        Dim pkIndexes As Integer() = {1}
        Dim columnOrder As Integer() = {1, 2}
        popupHtml = Me.strRecordBrowserHTML(headers, 2, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "CLIENTES")
        Return popupHtml
    End Function

    '====================================================================
    ' Name       : popupArticuloEspecialFotolab
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popupArticuloEspecialFotolab() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Trabajos"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsTerminoOrdenes.SERVICIOS
        headers.Add("Código")
        headers.Add("Nombre")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intCcsssId"}
        Dim pkIndexes As Integer() = {1}
        Dim columnOrder As Integer() = {0, 2}
        popupHtml = Me.strRecordBrowserHTML(headers, 2, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "ARTICULOFOTOLAB")
        Return popupHtml
    End Function


    '====================================================================
    ' Name       : popupExposiciones
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popupExposiciones() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Exposiciones"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Data.clstblExposiciones.SERVICIOS
        headers.Add("Id")
        headers.Add("Valor")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intExposicionesRolloId"}
        Dim pkIndexes As Integer() = {0}
        Dim columnOrder As Integer() = {0, 1}
        popupHtml = Me.strRecordBrowserHTML(headers, 1, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "EXPOSICIONES")
        Me.extraHtmlFinal += "<input name='btnTodos' type='button' class='boton' onClick=javascript:loadElement('','','-Todos-','-1') value='Todos'>" + vbNewLine
        Return popupHtml
    End Function


    '====================================================================
    ' Name       : popupFormatoRollo
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popupFormatoRollo() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Data.clstblFormatoRollo.SERVICIOS
        headers.Add("Id")
        headers.Add("Valor")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intFormatoRolloId"}
        Dim pkIndexes As Integer() = {0}
        Dim columnOrder As Integer() = {0, 1}
        popupHtml = Me.strRecordBrowserHTML(headers, 1, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "FORMATOROLLO")
        Me.extraHtmlFinal += "<input name='btnTodos' type='button' class='boton' onClick=javascript:loadElement('','','-Todos-','-1') value='Todos'>" + vbNewLine
        Return popupHtml
    End Function

    '====================================================================
    ' Name       : popupISO
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popupISO() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Data.clstblISO.SERVICIOS
        headers.Add("Id")
        headers.Add("Valor")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intISOId"}
        Dim pkIndexes As Integer() = {0}
        Dim columnOrder As Integer() = {0, 1}
        popupHtml = Me.strRecordBrowserHTML(headers, 1, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "ISO")
        Me.extraHtmlFinal += "<input name='btnTodos' type='button' class='boton' onClick=javascript:loadElement('','','-Todos-','-1') value='Todos'>" + vbNewLine

        Return popupHtml
    End Function

    '====================================================================
    ' Name       : popupServicios
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popupServicios() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Data.clstblServicios.SERVICIOS
        headers.Add("Id")
        headers.Add("Valor")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intServicioId"}
        Dim pkIndexes As Integer() = {0}
        Dim columnOrder As Integer() = {0, 1}
        popupHtml = Me.strRecordBrowserHTML(headers, 1, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "SERVICIOS")
        Me.extraHtmlFinal += "<input name='btnTodos' type='button' class='boton' onClick=javascript:loadElement('','','-Todos-','-1') value='Todos'>" + vbNewLine
        Return popupHtml
    End Function

    '====================================================================
    ' Name       : popupClasificacion
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popupClasificacion2() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.popUpHeader = "Clasificacion"
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsReporteProduccion.SERVICIOS
        headers.Add("Identificador")
        headers.Add("Clasificacion")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intClasificacionArticuloId"}
        Dim pkIndexes As Integer() = {0}
        Dim columnOrder As Integer() = {0, 1}
        popupHtml = Me.strRecordBrowserHTML(headers, 1, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "CLASIFICACION")
        Return popupHtml
    End Function

    '====================================================================
    ' Name       : popupTamanio
    ' Description: Define para el popup las propiedades tales como columnas, nombres  de las columna, servicios a utilizar,
    '                    y html al inicio y final  con comportamiento particular
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String (html del popup)
    '====================================================================
    Public Function popupTamanio() As String
        Dim headers As ArrayList = New ArrayList
        Dim popupHtml As String

        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Data.clstblTamanioFoto.SERVICIOS
        headers.Add("Id")
        headers.Add("Valor")
        headers.Add("Acciones")
        Dim pkNames As String() = {"intTamanoFotoId"}
        Dim pkIndexes As Integer() = {0}
        Dim columnOrder As Integer() = {0, 1}
        popupHtml = Me.strRecordBrowserHTML(headers, 1, pkNames, pkIndexes, columnOrder, Me._MAX_PER_PAGE, "TAMANIOFOTO")
        Me.extraHtmlFinal += "<input name='btnTodos' type='button' class='boton' onClick=javascript:loadElement('','','-Todos-','-1') value='Todos'>" + vbNewLine
        Return popupHtml
    End Function
#End Region

End Class

