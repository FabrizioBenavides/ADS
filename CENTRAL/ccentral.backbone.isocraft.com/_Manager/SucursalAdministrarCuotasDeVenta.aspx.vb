'====================================================================
' Class         : clsSucursalAdministrarCuotasDeVenta
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Administrar cuotas de venta.
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Carlos E. Pérez Torres
' Version       : 1.0
' Last Modified : Monday, May 24, 2004
'====================================================================
Imports System.Collections

Public Class clsSucursalAdministrarCuotasDeVenta
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
    Private strmCommand As String
    Private intmDireccionOperativaId As Integer
    Private intmZonaOperativaId As Integer
    Private strmCboDireccion As String
    Private strmCboZona As String
    Private strmCboSucursal As String
    Private strmCboMes As String
    Private mRecordBrowserHTML As String
    Private strmCompaniaSucursalId As String
    Private strmMesConsultar As String
    Private strmCboMesConsultar As String
    Private blnmConsultarTodos As Integer = 0
    Private intmCuotaVentaId As Integer

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
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
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
    Public ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strCmd 
    ' Description: Obtiene o establece el comando actual
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
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
    ' Name       : intCuotaVentaId 
    ' Description: Obtiene o establece la direccion operativa seleccionada
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intCuotaVentaId() As Integer
        Get
            If Len(Request.QueryString("intCuotaVentaId")) > 0 Then
                Return CInt(isocraft.commons.clsWeb.strGetPageParameter("intCuotaVentaId", "0"))
            Else
                Return intmCuotaVentaId
            End If
        End Get
        Set(ByVal strValue As Integer)
            intmCuotaVentaId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intDireccionOperativaId 
    ' Description: Obtiene o establece la direccion operativa seleccionada
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intDireccionOperativaId() As Integer
        Get
            If Len(Request.QueryString("intDireccionId")) > 0 Then
                Return CInt(isocraft.commons.clsWeb.strGetPageParameter("intDireccionId", "0"))
            Else
                Return intmDireccionOperativaId
            End If
        End Get
        Set(ByVal strValue As Integer)
            intmDireccionOperativaId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intZonaOperativaId 
    ' Description: Obtiene o establece la zona operativa seleccionada
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intZonaOperativaId() As Integer
        Get
            If Len(Request.QueryString("intZonaId")) > 0 Then
                Return CInt(isocraft.commons.clsWeb.strGetPageParameter("intZonaId", "0")) 'intmZonaOperativaId
            Else
                Return intmZonaOperativaId
            End If
        End Get
        Set(ByVal strValue As Integer)
            intmZonaOperativaId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCboDireccion 
    ' Description: Obtiene o establece el conjunto de Direcciones Operativas
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strCboDireccion() As String
        Get
            Return strmCboDireccion
        End Get
        Set(ByVal strValue As String)
            strmCboDireccion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCboZona 
    ' Description: Obtiene o establece el conjunto de Zonas Operativas
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strCboZona() As String
        Get
            Return strmCboZona
        End Get
        Set(ByVal strValue As String)
            strmCboZona = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCboSucursal 
    ' Description: Obtiene o establece el conjunto de Zonas Operativas
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strCboSucursal() As String
        Get
            Return strmCboSucursal
        End Get
        Set(ByVal strValue As String)
            strmCboSucursal = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCboMesConsultar 
    ' Description: Obtiene o establece el conjunto de meses
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strCboMesConsultar() As String
        Get
            Return strmCboMesConsultar
        End Get
        Set(ByVal strValue As String)
            strmCboMesConsultar = strValue
        End Set
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
            If Len(strmCompaniaSucursalId) = 0 Then
                strmCompaniaSucursalId = isocraft.commons.clsWeb.strGetPageParameter("cboSucursal", "0")
            End If
            Dim astrCompaniaId As Array = Split(strmCompaniaSucursalId, "|")
            Return CInt(astrCompaniaId.GetValue(0))
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
            If Len(strmCompaniaSucursalId) = 0 Then
                strmCompaniaSucursalId = isocraft.commons.clsWeb.strGetPageParameter("cboSucursal", "0")
            End If
            Dim astrSucursalId As Array = Split(strmCompaniaSucursalId, "|")
            Return CInt(astrSucursalId.GetValue(1))
        End Get
    End Property

    '====================================================================
    ' Name       : strMesConsultar
    ' Description: Identificador del mes a consultar
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strMesConsultar() As String
        Get
            strmMesConsultar = CStr(isocraft.commons.clsWeb.strGetPageParameter("cboMes", "-1"))
            Return strmMesConsultar
        End Get
    End Property

    '====================================================================
    ' Name       : blnConsultarTodos 
    ' Description: Obtiene o establece la bandera para consultar
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property blnConsultarTodos() As Integer
        Get
            Return blnmConsultarTodos
        End Get
        Set(ByVal intValue As Integer)
            blnmConsultarTodos = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML 
    ' Description: Obtiene o establece el conjunto de Zonas Operativas
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property RecordBrowserHTML() As String
        Get
            Return mRecordBrowserHTML
        End Get
        Set(ByVal strValue As String)
            mRecordBrowserHTML = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : Page_Load
    ' Description: Acciones a realizar al momento de cargar la página
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : 
    '====================================================================
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strCompaniaSucursal As String = isocraft.commons.clsWeb.strGetPageParameter("cboSucursal", isocraft.commons.clsWeb.strGetPageParameter("strSucursal", "0"))
        Dim objRecord As Array = Nothing
        '===========================================
        ' Variables para contruir dinamincamente el combo de meses.
        Dim objDataArrayList As ArrayList
        Dim arrMeses As Array
        Dim intTotalColumns As Integer
        Dim intCounter As Integer
        Dim objDataRow As String()
        Dim intTotalMeses As Integer = 1
        Dim arrNombreMes As String()
        Dim arrFechaConsulta As String()
        Dim strMesActual As String
        Dim intAnioActual As Integer
        Dim pstrMesConsultar As String = strMesConsultar

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "", Request)

        ' Almacenamos la Dirección Operativa Recibida
        intDireccionOperativaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboDireccionOperativa", "0", Request))
        'Consultamos las direcciones operativas
        Dim astrRecords As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString)
        strCboDireccion = isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccionOperativa", intDireccionOperativaId, astrRecords, 0, 1, 1)



        ' ===================================================
        ' Construimos dinámicamente el combo de meses. INICIO
        ' ===================================================
        Dim intcontador As Integer = 0
        Dim dtmMes As Date

        dtmMes = Now

        ' Inicializamos la bandera de consultar todos los meses.
        If strMesConsultar = "01/01/2000" Then
            blnConsultarTodos = 1
            pstrMesConsultar = CStr(dtmMes.Month.ToString("00") & "/01/" & dtmMes.Year.ToString("0000"))
        End If

        objDataArrayList = New ArrayList

        For intcontador = 1 To 12
            ' Creamos el arreglo de caracteres que almacenará a las columnas
            objDataRow = New String(1) {}

            objDataRow(0) = dtmMes.Month.ToString("00") & "/01/" & dtmMes.Year.ToString("0000")
            objDataRow(1) = Benavides.POSAdmin.Commons.clsCommons.strNombreMes(dtmMes)

            ' Agregamos el nuevo registro a la lista de registros
            Call objDataArrayList.Add(objDataRow)

            dtmMes = dtmMes.AddMonths(1)

        Next

        ' Regresamos la información
        arrMeses = objDataArrayList.ToArray()

        ' Construimos el combo con javascript.
        strCboMesConsultar = isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboMes", strMesConsultar, arrMeses, New Integer(0) {0}, 1, 2)

        ' ================================================
        ' Construimos dinámicamente el combo de meses. FIN

        ' Validamos si hay una Direccion Operativa seleccionada
        If intDireccionOperativaId > 0 Then
            ' Almacenamos la Zona Operativa Recibida
            intZonaOperativaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboZonaOperativa", "0", Request))

            ' Inicializamos el arreglo
            astrRecords = Nothing

            'Consultamos las direcciones operativas
            astrRecords = Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionOperativaId, 0, strConnectionString)

            ' Formamos el string con los valores
            strCboZona = isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZonaOperativa", intZonaOperativaId, astrRecords, 0, 1, 1)
        End If

        ' Validamos si hay una Direccion Operativa y Zona Operativa seleccionadas
        If intDireccionOperativaId > 0 AndAlso intZonaOperativaId > 0 Then
            strCboSucursal = isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSucursal", strCompaniaSucursal, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionOperativaId, intZonaOperativaId, strConnectionString), New Integer(1) {0, 1}, 2, 1)
        End If

        Select Case strCmd
            Case "Buscar"
                ' Declaramos e inicializamos las constantes locales
                Const intElementsPerPage As Integer = 13
                Const strRecordBrowserName As String = "SistemaAdministrarCuotasVenta"

                ' Declaramos e inicialziamos las variables locales
                Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1", Request))
                Dim astrDataArray As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsCuotaVenta.strBuscar(intCompaniaId, intSucursalId, CDate(pstrMesConsultar), blnConsultarTodos, strConnectionString)

                ' Formateamos el valor de la cuota para que se muestre en formato de pesos.
                If IsArray(astrDataArray) Then
                    For Each objRecord In astrDataArray
                        objRecord.SetValue(Benavides.POSAdmin.Commons.clsCommons.strFormatearNumeroPresentacion(CStr(objRecord.GetValue(2)), True), 2)
                    Next
                End If

                ' Establecemos los eventos onClick actual y futuro
                Dim strCurrentJavascriptOnClickEvent As String = "window.location='SucursalAdministrarCuotasDeVenta.aspx?intDireccionId=" & intDireccionOperativaId & "&amp;intZonaId=" & intZonaOperativaId & "&amp;strSucursal=" & strCompaniaSucursal & "&amp;strCmd=Agregar'"
                Dim strNewJavascriptOnClickEvent As String = "cmdNavegadorRegistrosAgregar_onclick(" & intDireccionOperativaId & ", " & intZonaOperativaId & ")"

                ' Obtenemos el record browser
                RecordBrowserHTML = Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?intDireccionId=" & intDireccionOperativaId & "&intZonaId=" & intZonaOperativaId & "&strSucursal=" & strCompaniaSucursal & "&")

                ' Regresamos el resultado
                RecordBrowserHTML = Replace(RecordBrowserHTML, strCurrentJavascriptOnClickEvent, strNewJavascriptOnClickEvent)

            Case "Editar"
                Call Response.Redirect("SucursalAsignarCuotasDeVenta.aspx?intDireccionId=" & intDireccionOperativaId & "&intZonaId=" & intZonaOperativaId & "&intCuotaVentaId=" & intCuotaVentaId & "&cboSucursal=" & strCompaniaSucursal & "&strCmd=Editar")

        End Select

    End Sub

End Class
