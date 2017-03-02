'====================================================================
' Class         : clsSucursalAsignarCuotasDeVenta
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Asignar cuotas de venta.
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Carlos E. Pérez Torres
' Version       : 1.0
' Last Modified : Monday, Jun 21, 2004
'====================================================================
Imports System.Collections

Public Class clsSucursalAsignarCuotasDeVenta
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
    Private intmCuotaVenta As Decimal = 0
    Private strmNombreCuota As String = ""
    Private strmAccion As String = ""
    Private strmSucursalNombre As String = ""

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
    ' Name       : strSucursalNombre 
    ' Description: Obtiene o establece la Sucursal seleccionada
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
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
    ' Name       : intCuotaVenta 
    ' Description: Obtiene o establece la cuota de venta.
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intCuotaVenta() As Decimal
        Get
            Return intmCuotaVenta
        End Get
        Set(ByVal intValue As Decimal)
            intmCuotaVenta = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strNombreCuota
    ' Description: Obtiene o establece el nombre de la cuota de venta
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strNombreCuota() As String
        Get
            Return strmNombreCuota
        End Get
        Set(ByVal strValue As String)
            strmNombreCuota = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strAccion
    ' Description: Obtiene la accion del submit
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property strAccion() As String
        Get
            Return strmAccion
        End Get
        Set(ByVal strValue As String)
            strmAccion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : GetNombreMes
    ' Description: Obtiene el nombre del mes a partir del numero de mes.
    ' Accessor   : Read, Write
    ' Throws     : String
    ' Output     : Integer
    '====================================================================
    Public Function GetNombreMes(ByVal strNumeroMes As String) As String

        Select Case CInt(strNumeroMes)
            Case 1
                GetNombreMes = "Enero"
            Case 2
                GetNombreMes = "Febrero"
            Case 3
                GetNombreMes = "Marzo"
            Case 4
                GetNombreMes = "Abril"
            Case 5
                GetNombreMes = "Mayo"
            Case 6
                GetNombreMes = "Junio"
            Case 7
                GetNombreMes = "Julio"
            Case 8
                GetNombreMes = "Agosto"
            Case 9
                GetNombreMes = "Septiembre"
            Case 10
                GetNombreMes = "Octubre"
            Case 11
                GetNombreMes = "Noviembre"
            Case 12
                GetNombreMes = "Diciembre"
        End Select

        Return GetNombreMes

    End Function

    '====================================================================
    ' Name       : Page_Load
    ' Description: Acciones a realizar al momento de cargar la página
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : 
    '====================================================================
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim objData As Array = Nothing

        '===========================================
        ' Variables para contruir dinámicamente el combo de meses.
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
        ' ====================================
        Dim strFechaFinal As String
        Dim intAgregarCuota As Integer

        Dim intCuotaVentaId As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intCuotaVentaId", "0", Request))

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "", Request)

        'Obtenemos la cuota de venta y el nombre de la cuota
        intCuotaVenta = CDec(isocraft.commons.clsWeb.strGetPageParameter("txtCuotaDeVenta", "0", Request))
        strNombreCuota = CStr(isocraft.commons.clsWeb.strGetPageParameter("txtNombreCuota", "", Request))

        'Creamos el combo de la susursal
        Dim strCompaniaSucursal As String = isocraft.commons.clsWeb.strGetPageParameter("cboSucursal", "0", Request)
        strCboSucursal = isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSucursal", strCompaniaSucursal, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionOperativaId, intZonaOperativaId, strConnectionString), New Integer() {0, 1}, 2, 1)

        'Buscamos el nombre de la Zona Operativa
        objData = Benavides.CC.Data.clstblZonaOperativa.strBuscar(intDireccionOperativaId, intZonaOperativaId, "", "", Now, "", 0, 0, strConnectionString)

        ' Asignamos el nombre de la Zona Operativa
        If IsArray(objData) = True AndAlso objData.Length > 0 Then
            strZonaOperativaNombre = CStr(DirectCast(objData.GetValue(0), Array).GetValue(2))
        End If

        Select Case strCmd

            Case "Agregar"

                ' Obtenemos el mes y el año actual.
                strMesActual = CStr(Month(Now()))
                intAnioActual = Year(Now())

                ' Completamos el mes a dos posiciones
                If Len(strMesActual) = 1 Then
                    strMesActual = "0" & strMesActual
                End If

                ' ===================================================
                ' Construimos dinámicamente el combo de meses. INICIO
                ' ===================================================
                Dim intcontador As Integer = 0
                Dim dtmMes As Date

                dtmMes = Now

                objDataArrayList = New ArrayList

                ' Creamos el arreglo de caracteres que almacenará a las columnas
                objDataRow = New String(1) {}

                objDataRow(0) = "0"
                objDataRow(1) = "Elija el mes"

                ' Agregamos el nuevo registro a la lista de registros
                Call objDataArrayList.Add(objDataRow)

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
                strCboMesConsultar = isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboMes", strMesConsultar, arrMeses, New Integer(0) {0}, 1, 0)

                'Asignamos la acción del boton
                strAccion = "strCmd=Asignar&intDireccionId=" & intDireccionOperativaId & "&intZonaId=" & intZonaOperativaId

            Case "Asignar"

                ' Calculamos la fecha final, sumando un mes y restamos un dia a la Fecha Inicial.
                strFechaFinal = CStr(DateAdd(DateInterval.Month, 1, CDate(strMesConsultar)))
                strFechaFinal = CStr(DateAdd(DateInterval.Day, -1, CDate(strFechaFinal)))

                'agregamos la cuota a la base de datos
                intAgregarCuota = Benavides.CC.Data.clstblCuotaVenta.intAgregar(0, intCompaniaId, intSucursalId, strNombreCuota, CDate(strMesConsultar), CDate(strFechaFinal), intCuotaVenta, Now, strUsuarioNombre, strConnectionString)

                'Si obtuvimos un resultado direccionamos a la pagina inicial
                If intAgregarCuota > 0 Then
                    Call Response.Redirect("SucursalAdministrarCuotasDeVenta.aspx?intDireccionId=" & intDireccionOperativaId & "&intZonaId=" & intZonaOperativaId & "&strCmd=Buscar&cboMes=01/01/2000&cboSucursal=" & Request.Form("cboSucursal"))
                End If

            Case "Editar"

                objDataArrayList = New ArrayList

                'Buscamos el nombre de la Zona Operativa
                objData = Benavides.CC.Data.clstblCuotaVenta.strBuscar(intCuotaVentaId, intCompaniaId, intSucursalId, "", Now, Now, 0, Now, "", 0, 0, strConnectionString)

                ' Asignamos el nombre de la Zona Operativa
                If IsArray(objData) = True AndAlso objData.Length > 0 Then
                    strFechaFinal = CStr(DirectCast(objData.GetValue(0), Array).GetValue(4))
                    intCuotaVenta = CDec(DirectCast(objData.GetValue(0), Array).GetValue(6))
                    strNombreCuota = CStr(DirectCast(objData.GetValue(0), Array).GetValue(3))

                    ' Construimos el combo del mes, con la opcion del mes de la base de datos solamente.
                    Dim arrMesActual As Array = Split(strFechaFinal, "/")
                    objDataRow = New String(1) {}

                    ' Obtenemos los valores de las columnas
                    objDataRow(0) = strFechaFinal
                    objDataRow(1) = GetNombreMes(CStr(arrMesActual.GetValue(0)))

                    ' Agregamos el nuevo registro a la lista de registros
                    Call objDataArrayList.Add(objDataRow)

                    ' Regresamos la información
                    arrMeses = objDataArrayList.ToArray()

                    ' Construimos el combo con javascript.
                    strCboMesConsultar = isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboMes", strMesConsultar, arrMeses, New Integer(0) {0}, 1, 0)

                    strAccion = "strCmd=Modificar&intDireccionId=" & intDireccionOperativaId & "&intZonaId=" & intZonaOperativaId & "&intCuotaVentaId=" & intCuotaVentaId
                End If

            Case "Modificar"

                ' Calculamos la fecha final, sumando un mes y restamos un dia a la Fecha Inicial.
                strFechaFinal = CStr(DateAdd(DateInterval.Month, 1, CDate(strMesConsultar)))
                strFechaFinal = CStr(DateAdd(DateInterval.Day, -1, CDate(strFechaFinal)))

                'Actualizamos la cuota con los nuevos valores
                intAgregarCuota = Benavides.CC.Data.clstblCuotaVenta.intActualizar(intCuotaVentaId, intCompaniaId, intSucursalId, strNombreCuota, CDate(strMesConsultar), CDate(strFechaFinal), intCuotaVenta, Now, strUsuarioNombre, strConnectionString)

                'Si el resultado es satisfactorio redireccionamos a la página inicial
                If intAgregarCuota > 0 Then
                    Call Response.Redirect("SucursalAdministrarCuotasDeVenta.aspx?intDireccionId=" & intDireccionOperativaId & "&intZonaId=" & intZonaOperativaId & "&strCmd=Buscar&cboMes=01/01/2000&cboSucursal=" & Request.Form("cboSucursal"))
                End If

        End Select

    End Sub

End Class
