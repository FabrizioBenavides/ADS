'====================================================================
' Class         : clspopAsignarCuotaDeVenta
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Asignar cuotas de venta.
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Carlos E. Pérez Torres
' Version       : 1.0
' Last Modified : Monday, Jun 21, 2004
'====================================================================
Imports System.Collections

Public Class clspopAsignarCuotaDeVenta
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
    Private strmCompaniaSucursalId As String
    Private strmMesConsultar As String
    Private strmCboMesConsultar As String
    Private blnmConsultarTodos As Integer = 0
    Private strmZonaOperativaNombre As String

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
    ' Name       : intDireccionOperativaId 
    ' Description: Obtiene o establece la direccion operativa seleccionada
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intDireccionOperativaId() As Integer
        Get
            Return CInt(isocraft.commons.clsWeb.strGetPageParameter("intDireccionId", "0"))
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
            Return CInt(isocraft.commons.clsWeb.strGetPageParameter("intZonaId", "0"))
        End Get
        Set(ByVal strValue As Integer)
            intmZonaOperativaId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strZonaOperativaNombre 
    ' Description: Obtiene o establece la zona operativa seleccionada
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
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
    ' Name       : Page_Load
    ' Description: Acciones a realizar al momento de cargar la página
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : 
    '====================================================================
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        'Response.Write("intDireccionOperativaId=[" & intDireccionOperativaId & "]<br>")
        'Response.Write("intZonaOperativaId=[" & intZonaOperativaId & "]<br>")
        'Response.End()
        Dim objData As Array = Nothing

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

        ' ====================================
        ' Construimos dinámicamente el combo de meses.

        ' Obtenemos el mes y el año actual.
        strMesActual = CStr(Month(Now()))
        intAnioActual = Year(Now())

        ' Completamos el mes a dos posiciones
        If Len(strMesActual) = 1 Then
            strMesActual = "0" & strMesActual
        End If

        ' Inicializamos la bandera de consultar todos los meses.
        If strMesConsultar = "01/01/2000" Then
            blnConsultarTodos = 1
            pstrMesConsultar = CStr(strMesActual & "/01/" & intAnioActual)
        End If

        ' Construimos y ordenamos dependiendo del mes actual el arreglo para llenar el combo de meses.
        Select Case CInt(strMesActual)
            Case 1
                arrNombreMes = New String(11) {"Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre", "Enero"}
                arrFechaConsulta = New String(11) {"02/01/" & intAnioActual, "03/01/" & intAnioActual, "04/01/" & intAnioActual, "05/01/" & intAnioActual, "06/01/" & intAnioActual, "07/01/" & intAnioActual, "08/01/" & intAnioActual, "09/01/" & intAnioActual, "10/01/" & intAnioActual, "11/01/" & intAnioActual, "12/01/" & intAnioActual, "01/01/" & intAnioActual + 1}
            Case 2
                arrNombreMes = New String(11) {"Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre", "Enero", "Febrero"}
                arrFechaConsulta = New String(11) {"03/01/" & intAnioActual, "04/01/" & intAnioActual, "05/01/" & intAnioActual, "06/01/" & intAnioActual, "07/01/" & intAnioActual, "08/01/" & intAnioActual, "09/01/" & intAnioActual, "10/01/" & intAnioActual, "11/01/" & intAnioActual, "12/01/" & intAnioActual, "01/01/" & intAnioActual + 1, "02/01/" & intAnioActual + 1}
            Case 3
                arrNombreMes = New String(11) {"Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre", "Enero", "Febrero", "Marzo"}
                arrFechaConsulta = New String(11) {"04/01/" & intAnioActual, "05/01/" & intAnioActual, "06/01/" & intAnioActual, "07/01/" & intAnioActual, "08/01/" & intAnioActual, "09/01/" & intAnioActual, "10/01/" & intAnioActual, "11/01/" & intAnioActual, "12/01/" & intAnioActual, "01/01/" & intAnioActual + 1, "02/01/" & intAnioActual + 1, "03/01/" & intAnioActual + 1}
            Case 4
                arrNombreMes = New String(11) {"Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre", "Enero", "Febrero", "Marzo", "Abril"}
                arrFechaConsulta = New String(11) {"05/01/" & intAnioActual, "06/01/" & intAnioActual, "07/01/" & intAnioActual, "08/01/" & intAnioActual, "09/01/" & intAnioActual, "10/01/" & intAnioActual, "11/01/" & intAnioActual, "12/01/" & intAnioActual, "01/01/" & intAnioActual + 1, "02/01/" & intAnioActual + 1, "03/01/" & intAnioActual + 1, "04/01/" & intAnioActual + 1}
            Case 5
                arrNombreMes = New String(11) {"Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre", "Enero", "Febrero", "Marzo", "Abril", "Mayo"}
                arrFechaConsulta = New String(11) {"06/01/" & intAnioActual, "07/01/" & intAnioActual, "08/01/" & intAnioActual, "09/01/" & intAnioActual, "10/01/" & intAnioActual, "11/01/" & intAnioActual, "12/01/" & intAnioActual, "01/01/" & intAnioActual + 1, "02/01/" & intAnioActual + 1, "03/01/" & intAnioActual + 1, "04/01/" & intAnioActual + 1, "05/01/" & intAnioActual + 1}
            Case 6
                arrNombreMes = New String(11) {"Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio"}
                arrFechaConsulta = New String(11) {"07/01/" & intAnioActual, "08/01/" & intAnioActual, "09/01/" & intAnioActual, "10/01/" & intAnioActual, "11/01/" & intAnioActual, "12/01/" & intAnioActual, "01/01/" & intAnioActual + 1, "02/01/" & intAnioActual + 1, "03/01/" & intAnioActual + 1, "04/01/" & intAnioActual + 1, "05/01/" & intAnioActual + 1, "06/01/" & intAnioActual + 1}
            Case 7
                arrNombreMes = New String(11) {"Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio"}
                arrFechaConsulta = New String(11) {"08/01/" & intAnioActual, "09/01/" & intAnioActual, "10/01/" & intAnioActual, "11/01/" & intAnioActual, "12/01/" & intAnioActual, "01/01/" & intAnioActual + 1, "02/01/" & intAnioActual + 1, "03/01/" & intAnioActual + 1, "04/01/" & intAnioActual + 1, "05/01/" & intAnioActual + 1, "06/01/" & intAnioActual + 1, "07/01/" & intAnioActual + 1}
            Case 8
                arrNombreMes = New String(11) {"Septiembre", "Octubre", "Noviembre", "Diciembre", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto"}
                arrFechaConsulta = New String(11) {"09/01/" & intAnioActual, "10/01/" & intAnioActual, "11/01/" & intAnioActual, "12/01/" & intAnioActual, "01/01/" & intAnioActual + 1, "02/01/" & intAnioActual + 1, "03/01/" & intAnioActual + 1, "04/01/" & intAnioActual + 1, "05/01/" & intAnioActual + 1, "06/01/" & intAnioActual + 1, "07/01/" & intAnioActual + 1, "08/01/" & intAnioActual + 1}
            Case 9
                arrNombreMes = New String(11) {"Octubre", "Noviembre", "Diciembre", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre"}
                arrFechaConsulta = New String(11) {"10/01/" & intAnioActual, "11/01/" & intAnioActual, "12/01/" & intAnioActual, "01/01/" & intAnioActual + 1, "02/01/" & intAnioActual + 1, "03/01/" & intAnioActual + 1, "04/01/" & intAnioActual + 1, "05/01/" & intAnioActual + 1, "06/01/" & intAnioActual + 1, "07/01/" & intAnioActual + 1, "08/01/" & intAnioActual + 1, "09/01/" & intAnioActual + 1}
            Case 10
                arrNombreMes = New String(11) {"Noviembre", "Diciembre", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre"}
                arrFechaConsulta = New String(11) {"11/01/" & intAnioActual, "12/01/" & intAnioActual, "01/01/" & intAnioActual + 1, "02/01/" & intAnioActual + 1, "03/01/" & intAnioActual + 1, "04/01/" & intAnioActual + 1, "05/01/" & intAnioActual + 1, "06/01/" & intAnioActual + 1, "07/01/" & intAnioActual + 1, "08/01/" & intAnioActual + 1, "09/01/" & intAnioActual + 1, "10/01/" & intAnioActual + 1}
            Case 11
                arrNombreMes = New String(11) {"Diciembre", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre"}
                arrFechaConsulta = New String(11) {"12/01/" & intAnioActual, "01/01/" & intAnioActual + 1, "02/01/" & intAnioActual + 1, "03/01/" & intAnioActual + 1, "04/01/" & intAnioActual + 1, "05/01/" & intAnioActual + 1, "06/01/" & intAnioActual + 1, "07/01/" & intAnioActual + 1, "08/01/" & intAnioActual + 1, "09/01/" & intAnioActual + 1, "10/01/" & intAnioActual + 1, "11/01/" & intAnioActual + 1}
            Case 12
                arrNombreMes = New String(11) {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"}
                arrFechaConsulta = New String(11) {"01/01/" & intAnioActual + 1, "02/01/" & intAnioActual + 1, "03/01/" & intAnioActual + 1, "04/01/" & intAnioActual + 1, "05/01/" & intAnioActual + 1, "06/01/" & intAnioActual + 1, "07/01/" & intAnioActual + 1, "08/01/" & intAnioActual + 1, "09/01/" & intAnioActual + 1, "10/01/" & intAnioActual + 1, "11/01/" & intAnioActual + 1, "12/01/" & intAnioActual + 1}
        End Select

        '==============================================================
        ' Construimos el arreglo adecuado para llenar el combo - INICIO
        ' Instanciamos el arreglo de datos resultante

        objDataArrayList = New ArrayList
        intTotalColumns = 1

        ' Iteramos hasta haber leído todos los registros
        While intTotalMeses <= 12

            ' Creamos el arreglo de caracteres que almacenará a las columnas
            objDataRow = New String(intTotalColumns) {}

            ' Obtenemos los valores de las columnas
            For intCounter = 0 To intTotalColumns
                objDataRow(0) = arrFechaConsulta(intTotalMeses - 1)
                objDataRow(1) = arrNombreMes(intTotalMeses - 1)
            Next

            ' Agregamos el nuevo registro a la lista de registros
            Call objDataArrayList.Add(objDataRow)

            intTotalMeses += 1

        End While

        ' Regresamos la información
        arrMeses = objDataArrayList.ToArray()
        ' Construimos el combo con javascript.
        strCboMesConsultar = isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboMes", strMesConsultar, arrMeses, New Integer(0) {0}, 1, 1)

        Dim strCompaniaSucursal As String = isocraft.commons.clsWeb.strGetPageParameter("cboSucursal", "0")
        strCboSucursal = isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSucursal", strCompaniaSucursal, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionOperativaId, intZonaOperativaId, strConnectionString), New Integer(1) {0, 1}, 2, 1)

        'Buscamos el nombre de la Zona Operativa
        objData = Benavides.CC.Data.clstblZonaOperativa.strBuscar(intDireccionOperativaId, intZonaOperativaId, "", "", Now, "", 0, 0, strConnectionString)

        ' Asignamos el nombre de la Zona Operativa
        If IsArray(objData) = True AndAlso objData.Length > 0 Then
            strZonaOperativaNombre = CStr(DirectCast(objData.GetValue(0), Array).GetValue(2))
        End If

    End Sub

End Class
