
Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Benavides.POSAdmin.Commons.clsCommons.clsMSMQ
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports Isocraft.Web.Javascript
Imports System.IO
Imports System.Web.Caching

Public Class SucursalReporteTarjetas
    Inherits System.Web.UI.Page
    Private intDireccionOperativaId As Integer
    Private intZonaOperativaId As Integer
    Private intSucursalesId As String

    Private intmEstadoId As Integer
    Private intmCiudadId As Integer
    Private strmSucursalId As String

    Private strmcboEstado As String
    Private strmcboCiudad As String
    Private strmCboSucursal As String

    Private intCboTipoEmpleadoId As Integer
    Private intCboEmpleadosId As Integer

    Dim astrRecords As Array
    Public strImpresionReporte As String
    Private intRenglonesxPagina As Integer = 42
    Dim blnMasDeMilRegistro As Boolean = False



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

        'Combos Sucursal por Zona
        intDireccionOperativaId = GetPageParameter("cboDireccionOperativa", 0)
        intZonaOperativaId = GetPageParameter("cboZonaOperativa", 0)
        intSucursalesId = GetPageParameter("cboSucursales", String.Empty)

        'Combos Sucursal por Estado
        intEstadoId = GetPageParameter("cboEstado", 0)
        intCiudadId = GetPageParameter("cboCiudad", 0)
        strSucursalId = GetPageParameter("cboSucursalEstado", String.Empty)

        intCboTipoEmpleadoId = GetPageParameter("TipoEmpleado", 0)

    End Sub

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
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", String.Empty, Request, Server)
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
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request)
        End Get
    End Property

#Region "Combos"
    '====================================================================
    ' Name       : LlenarControlDireccion
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboDireccionOperativa
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlDireccion() As String

        'Consultamos las direcciones operativas
        astrRecords = Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString)

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccionOperativa", intDireccionOperativaId, astrRecords, 0, 1, 2)

    End Function

    '====================================================================
    ' Name       : LlenarControlZona
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboZona
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlZona() As String

        ' Validamos si hay una Direccion Operativa seleccionada
        If intDireccionOperativaId > 0 Then

            ' Inicializamos el arreglo
            astrRecords = Nothing

            'Consultamos las direcciones operativas
            astrRecords = Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionOperativaId, 0, strConnectionString)

            ' Formamos el string con los valores
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZonaOperativa", intZonaOperativaId, astrRecords, 0, 1, 2)
        End If
    End Function

    '====================================================================
    ' Name       : LlenarControlSucursales
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboSucursales
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlSucursales() As String

        Dim strSucursales As New StringBuilder

        If intDireccionOperativaId = -1 Then
            intZonaOperativaId = -1
        End If

        If Not intDireccionOperativaId = 0 AndAlso Not intZonaOperativaId = 0 Then

            Dim returnedData As Array = Nothing

            'strAlmacenId = 0001 para que NO traiga los Foto Labs
            Dim strAlmacenId As String = "0001"

            Dim objSucursalItem As String() = Nothing
            Dim strSucursalNombreCombo As String
            Dim i As Integer

            returnedData = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarSucursalesPorAsignar(intDireccionOperativaId, intZonaOperativaId, strConnectionString)

            If Not returnedData Is Nothing AndAlso IsArray(returnedData) AndAlso returnedData.Length > 0 Then

                For i = 0 To returnedData.Length - 1

                    objSucursalItem = CType(returnedData.GetValue(i), String())

                    strSucursalNombreCombo = String.Empty
                    strSucursalNombreCombo = objSucursalItem(2).ToString().Trim() & " - " & objSucursalItem(3).ToString().Trim()

                    strSucursales.AppendFormat("<option value=""{0}"">{1}</option>", objSucursalItem(2).ToString().Trim(), strSucursalNombreCombo)
                Next
            End If
        End If

        Return strSucursales.ToString()
    End Function

    '====================================================================
    ' Name       : strLlenarEstadoComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboEstado"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarEstadoComboBox() As String

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboEstado", intEstadoId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacionEdo(0, 0, 0, strConnectionString), 0, 1, 2)

    End Function

    '====================================================================
    ' Name       : strLlenarCiudadComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboCiudad"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarCiudadComboBox() As String
        If intEstadoId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboCiudad", intCiudadId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacionEdo(intEstadoId, 0, 0, strConnectionString), 0, 1, 2)
        End If
    End Function

    '====================================================================
    ' Name       : strLlenarSucursalComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboSucursalEstado"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String

    '====================================================================
    Public Function strLlenarSucursalComboBox() As String

        Dim strSucursales As New StringBuilder
        If intEstadoId > 0 AndAlso Not intCiudadId = 0 Then

            Dim returnedData As Array = Nothing

            Dim objSucursalItem As String() = Nothing
            Dim intSucursalId As String
            Dim strSucursalNombreCombo As String
            Dim i As Integer

            returnedData = Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacionEdo(intEstadoId, intCiudadId, 0, strConnectionString)


            If Not returnedData Is Nothing AndAlso IsArray(returnedData) AndAlso returnedData.Length > 0 Then

                For i = 0 To returnedData.Length - 1

                    objSucursalItem = CType(returnedData.GetValue(i), String())

                    intSucursalId = String.Empty
                    intSucursalId = objSucursalItem(2).ToString().Substring(0, 4)
                    strSucursalNombreCombo = String.Empty
                    strSucursalNombreCombo = objSucursalItem(2).ToString().Trim()

                    strSucursales.AppendFormat("<option value=""{0}"">{1}</option>", objSucursalItem(2).ToString().Trim(), strSucursalNombreCombo)
                Next
            End If

        End If
        Return strSucursales.ToString()
    End Function
#End Region

    '====================================================================
    ' Name       : intTipoUsuarioId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCentroLogisticoId() As String
        Get
            If Request.Form("cmdBusquedaSucursal") = "1" Then

                'If intSucursalesId = "-1" Then
                Return intSucursalId
                'Else
                '    Return intSucursalesId
                'End If


            ElseIf Request.Form("cmdBusquedaSucursal") = "2" Then

                If strSucursalId = "-1" Then
                    Return strSucursalId
                Else
                    Return strSucursalId.Substring(0, 4)
                End If


            Else
                Return String.Empty

            End If

        End Get
    End Property

    '====================================================================
    ' Name       : strTipoEmpleadoId
    ' Description: Tipo de Empleado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTipoEmpleadoId() As String
        Get
            Return intCboTipoEmpleadoId.ToString()
        End Get
    End Property

    '====================================================================
    ' Name       : boolActivos
    ' Description: Empleados Activos
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property boolActivos() As Boolean
        Get
            If Len(Trim(Request("chkActivos"))) > 0 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intDireccionId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intDireccionId() As Integer
        Get
            Return intDireccionOperativaId
        End Get
    End Property

    '====================================================================
    ' Name       : intZonaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intZonaId() As Integer
        Get
            Return intZonaOperativaId
        End Get
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intSucursalId() As String
        Get
            Return intSucursalesId
        End Get
    End Property

    '====================================================================
    ' Name       : intEstadoId 
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intEstadoId() As Integer
        Get
            Return intmEstadoId
        End Get
        Set(ByVal intValue As Integer)
            intmEstadoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intCiudadId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intCiudadId() As Integer
        Get
            Return intmCiudadId
        End Get
        Set(ByVal intValue As Integer)
            intmCiudadId = intValue
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

    '====================================================================
    ' Name       : strFiltroSucursalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFiltroSucursalId() As String
        Get
            If Request.Form("cmdBusquedaSucursal") = "1" Or Request.Form("cmdBusquedaSucursal") = "2" Then
                Return Request.Form("cmdBusquedaSucursal")
            Else
                Return "1"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strFirstDayOfMonth
    ' Description: Regresa el primer dia del mes actual
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFirstDayOfMonth() As String
        Get
            If IsNothing(Request.Form("dtmFechaIni")) Then
                Return New Date(Date.Today.Year, Date.Today.Month, 1).ToString("dd/MM/yyyy")
            Else
                Return Request.Form("dtmFechaIni")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strFechaActual
    ' Description: Regresa la fecha actual
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFechaActual() As String
        Get
            If IsNothing(Request.Form("dtmFechaFin")) Then
                Dim dtmFechaActual As Date

                dtmFechaActual = New Date(Date.Today.Year, Date.Today.Month, Date.Today.Day)

                Return dtmFechaActual.ToString("dd/MM/yyyy")
            Else
                Return Request.Form("dtmFechaFin")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intEmpleadoId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intEmpleadoId() As Integer
        Get
            If Not IsNothing(Request.Form("txtEmpleadoId")) AndAlso Not (Trim(Request.Form("txtEmpleadoId")) = String.Empty) Then
                Return CInt(Request.Form("txtEmpleadoId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaInicio
    ' Description: Fecha de inicio a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaInicio() As Date
        Get
            Dim f As String = Request.Form("dtmFechaIni")
            If Not IsNothing(f) Then
                Dim fp As String() = f.Split("/".ToCharArray())

                Return New Date(CInt(fp(2)), CInt(fp(1)), CInt(fp(0)))
            Else
                Return CDate("01/01/1900")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaFin
    ' Description: Fecha de fin  a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaFin() As Date
        Get
            Dim f As String = Request.Form("dtmFechaFin")
            If Not IsNothing(f) Then
                Dim fp As String() = f.Split("/".ToCharArray())

                Return New Date(CInt(fp(2)), CInt(fp(1)), CInt(fp(0)))
            Else
                Return CDate("01/01/1900")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strEmpleadoNombreId
    ' Description: Toma el id del empleado a buscar
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public ReadOnly Property strEmpleadoNombreId() As String
        Get
            If Not IsNothing(Request.Form("txtEmpleadoNombreId").Trim()) Then
                Return Request("txtEmpleadoNombreId")
            Else
                Return String.Empty
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : strCadenaImagen
    ' Description: Valor de la Compañia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCadenaImagen() As String
        Get
            Return (clsCommons.strReadCookie("strCadenaImagen", String.Empty, Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return GetPageParameter("strCmd", String.Empty)
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        'If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
        '    Call Response.Redirect("../Default.aspx")
        'End If

        'Dim strRecordBrowserImpresion As String = String.Empty
        Const strComitasDobles As String = """"
        Dim objDataArrayMovimientos As Array = Nothing
        Dim strHTML As New StringBuilder

        strHTML = New StringBuilder

        Select Case strCmd

            Case "BuscarEmpleado"

                Dim objArrayEmpleado As Array = Nothing
                Dim objRegistroEmpleado As System.Collections.SortedList = Nothing

                Dim strBusquedaEmpleadoId As String = String.Empty
                Dim strBusquedaEmpleadoNombreId As String = String.Empty
                Dim strBusquedaEmpleadoNombre As String = String.Empty
                Dim strBusquedaProveedorError As String = "-100"

                objArrayEmpleado = Benavides.CC.Data.clsReporteDeVisitas.strBuscarEmpleadoVisitasCentral(strCentroLogisticoId, intCboTipoEmpleadoId, boolActivos, strEmpleadoNombreId, strConnectionString)

                If IsArray(objArrayEmpleado) AndAlso objArrayEmpleado.Length > 0 Then

                    objRegistroEmpleado = DirectCast(objArrayEmpleado.GetValue(0), System.Collections.SortedList)

                    ' Asignamos los datos del empleado
                    strBusquedaEmpleadoId = clsCommons.strFormatearDescripcion(CStr(objRegistroEmpleado.Item("intEmpleadoId")))
                    strBusquedaEmpleadoNombre = clsCommons.strFormatearDescripcion(CStr(objRegistroEmpleado.Item("Nombre")))
                    strBusquedaProveedorError = "0"

                End If

                'End If

                strHTML.Append("<script language='Javascript'> parent.fnUpBuscarEmpleado( " & _
                               strComitasDobles & strBusquedaEmpleadoId & strComitasDobles & "," & _
                               strComitasDobles & strBusquedaEmpleadoNombre & strComitasDobles & "," & _
                               strComitasDobles & strBusquedaProveedorError & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "cmdExportar"

                strExportar()

                'Dim objArray As System.Array = Nothing
                'Dim intEmpleadoId As Integer

                'If Not strEmpleadoNombreId = String.Empty Then
                '    intEmpleadoId = CInt(strEmpleadoNombreId)
                'Else
                '    intEmpleadoId = 0
                'End If

                ''Reporte de Visitas
                'objArray = Benavides.CC.Data.clsReporteDeVisitas.strObtenerReporteVisitasCentral(strCentroLogisticoId, intCboTipoEmpleadoId, boolActivos, intEmpleadoId, dtmFechaInicio, dtmFechaFin, strConnectionString)

                '' Establecemos en la respuesta los parámetros de configuración del archivo
                'Response.ContentType = "application/octet-stream"
                'Call Response.AddHeader("Content-Disposition", "attachment; filename=""Reporte de Visitas.csv""")
                'Call Response.Write(strTablaReporteVisitasExportar(objArray))
                'Call Response.End()

            Case "cmdImprimir"

                Dim objArray As System.Array = Nothing
                Dim strmRecordBrowserHTML As String = String.Empty
                Dim intEmpleadoId As Integer
                Dim strRecordBrowserImpresion As String = String.Empty

                If Not strEmpleadoNombreId = String.Empty Then
                    intEmpleadoId = CInt(strEmpleadoNombreId)
                Else
                    intEmpleadoId = 0
                End If

                'Reporte de Visitas
                objArray = Benavides.CC.Data.clsReporteDeVisitas.strObtenerReporteVisitasCentral(intDireccionOperativaId, intZonaOperativaId, intEstadoId, intCiudadId, strCentroLogisticoId, intCboTipoEmpleadoId, boolActivos, intEmpleadoId, dtmFechaInicio, dtmFechaFin, strConnectionString)

                Dim strResult As New StringBuilder
                If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then

                    'Impresion
                    strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strGeneraImpresionReporte(objArray))

                    'Se ennvia a impresion.
                    strHTML.Append("<script language='Javascript'>parent.fnImprimir( " & _
                    strComitasDobles & strRecordBrowserImpresion.ToString & strComitasDobles & _
                    "); </script>")
                    Response.Write(strHTML.ToString)
                    Response.End()

                End If

        End Select
    End Sub

    Private Function strExportar() As String

        Dim objArray As System.Array = Nothing
        Dim intEmpleadoId As Integer

        If Not strEmpleadoNombreId = String.Empty Then
            intEmpleadoId = CInt(strEmpleadoNombreId)
        Else
            intEmpleadoId = 0
        End If

        'Reporte de Visitas
        objArray = Benavides.CC.Data.clsReporteDeVisitas.strObtenerReporteVisitasCentral(intDireccionOperativaId, intZonaOperativaId, intEstadoId, intCiudadId, strCentroLogisticoId, intCboTipoEmpleadoId, boolActivos, intEmpleadoId, dtmFechaInicio, dtmFechaFin, strConnectionString)

        ' Establecemos en la respuesta los parámetros de configuración del archivo
        Response.ContentType = "application/octet-stream"
        Call Response.AddHeader("Content-Disposition", "attachment; filename=""Reporte de Visitas.csv""")
        Call Response.Write(strTablaReporteVisitasExportar(objArray))
        Call Response.End()
    End Function

    '====================================================================
    ' Name       : strGeneraImpresionReporte
    ' Description: Genera el Record Browser a desplegar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strGeneraImpresionReporte(ByVal objReporte As Array) As String

        Dim strImpresionHTML As New StringBuilder
        Dim strColorRegistro As String = String.Empty

        If IsArray(objReporte) AndAlso (objReporte.Length > 0) Then

            Dim objRegistro As String() = Nothing
            Dim intContadorRegistro As Integer = 0

            Dim intTotalRenglones As Integer = objReporte.Length
            Dim intRenglon As Integer = 0

            Dim intTotalPaginas As Integer = 0
            Dim intPagina As Integer = 0

            intTotalPaginas = intTotalRenglones \ intRenglonesxPagina

            If intTotalRenglones Mod intRenglonesxPagina > 0 Then
                intTotalPaginas += 1
            Else
                intTotalPaginas = 1
            End If

            intRenglon = 0
            intPagina = 0
            intContadorRegistro = 0

            For Each objRegistro In objReporte

                intRenglon += 1
                intContadorRegistro += 1

                If intRenglon = 1 Then
                    intPagina += 1
                    strImpresionHTML.Append(strImprimeEncabezado(intPagina, intTotalPaginas))
                    strImpresionHTML.Append("<table width='770px' border='0' cellpadding='0' cellspacing='0'> ")
                End If

                If ((intContadorRegistro Mod 2) = 0) Then
                    strColorRegistro = "'tdtxtImpresionBold'"
                Else
                    strColorRegistro = "'tdtxtImpresionNormal'"
                End If

                strImpresionHTML.Append("<tr>")

                ' 1 No. de Renglon
                strImpresionHTML.Append("<td class=" & strColorRegistro & " width='02%' align='left'>" & intContadorRegistro.ToString & "&nbsp;</td>")
                ' Fecha
                strImpresionHTML.Append("<td width='08%' align='left' class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(objRegistro(0)) & "</td>")
                ' Local SAP
                strImpresionHTML.Append("<td width='08%' align='center' class=" & strColorRegistro & ">" & objRegistro(1) & "</td>")
                ' Sucursal
                strImpresionHTML.Append("<td width='15%' align='left' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(objRegistro(2)) & "</td>")
                ' Caja
                strImpresionHTML.Append("<td  width='04%' align='center'  class=" & strColorRegistro & ">" & objRegistro(3) & "</td>")
                ' No. Empleado
                strImpresionHTML.Append("<td width='06%' align='center' class=" & strColorRegistro & ">" & objRegistro(4) & "</td>")
                'Empleado
                strImpresionHTML.Append("<td width='17%' align='left' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(objRegistro(5)) & "</td>")
                ' Tipo Empleado (Empresa)
                strImpresionHTML.Append("<td width='14%' align='left' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(objRegistro(6)) & "</td>")
                ' Activo
                strImpresionHTML.Append("<td width='06%' align='center' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(objRegistro(7)) & "</td>")
                ' Hora Entrada
                strImpresionHTML.Append("<td width='10%' align='center' class=" & strColorRegistro & ">" & objRegistro(8) & "</td>")
                ' Hora Salida 
                strImpresionHTML.Append("<td width='10%' align='center' class=" & strColorRegistro & ">" & objRegistro(9) & "</td>")
                strImpresionHTML.Append("</tr>")

                If intContadorRegistro = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next

        Else

            strImpresionHTML.Append(strImprimeEncabezado(1, 1))
            strImpresionHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")
            strImpresionHTML.Append("<tr>")
            strImpresionHTML.Append("<td width='02%'>&nbsp;</td>")
            strImpresionHTML.Append("<td class='tdblanco' colspan='7'>No hay registros</td>")
            strImpresionHTML.Append("</tr>")
            strImpresionHTML.Append("</table>")
        End If

        Return strImpresionHTML.ToString

    End Function

    Private Function strImprimeEncabezado(ByVal intPaginaActual As Integer, _
                                          ByVal intTotalPaginas As Integer) As String

        Dim strHtmlEncabezado As New StringBuilder
        Dim strSucursalDescripcion As String
        Dim strEmpleado As String

        If intPaginaActual > 1 Then
            strHtmlEncabezado.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")
        End If

        strHtmlEncabezado.Append("<table width='770px' border='0' cellpadding='0' cellspacing='0'> ")

        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td width='100%'  colspan='8'>&nbsp;</td>")
        strHtmlEncabezado.Append("</tr>")

        'Logo
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='49%' align='left'  colspan='4'><img src='../static/images/" & strCadenaImagen & "/logo.gif' width='125' height='25' border='0'></td>")
        strHtmlEncabezado.Append("<td width='49%' align='right' colspan='4'>Reporte de Visitas</td>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='49%' align='left'  colspan='4' class='tdtxtImpresionBold'>" & clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</td>")
        strHtmlEncabezado.Append("<td width='49%' align='right' colspan='4' class='tdtxtImpresionBold'>HOJA " & intPaginaActual.ToString & " / " & intTotalPaginas & "</td>")
        strHtmlEncabezado.Append("</tr>")

        'Sucursal

        strSucursalDescripcion = String.Empty
        If Request.Form("cmdBusquedaSucursal") = "1" Then
            strSucursalDescripcion = Request("hdnSucursales").Trim
        Else
            strSucursalDescripcion = Request("hdnSucursalEstado").Trim
        End If


        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='98%' align='left' colspan='10' class='tdtxtImpresionBold' nowrap>" & strSucursalDescripcion & "</td>")
        strHtmlEncabezado.Append("<tr class='trtitulos'>")

        'Reporte de Visitas      
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<td width='02%'>&nbsp;</td>")
        strHtmlEncabezado.Append("<td width='98%' colspan='10'>&nbsp;</td>")
        strHtmlEncabezado.Append("</tr>")

        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td align='left' colspan='11'>Consulta generada por: " & strUsuarioNombre & "</td>")
        strHtmlEncabezado.Append("</tr>")

        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td align='left' colspan='11'>Fecha de Inicio: " & clsCommons.strFormatearFechaPresentacion(CStr(dtmFechaInicio)) & "</td>")
        strHtmlEncabezado.Append("</tr>")

        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td align='left' colspan='11'>Fecha de Fin: " & clsCommons.strFormatearFechaPresentacion(CStr(dtmFechaFin)) & "</td>")
        strHtmlEncabezado.Append("</tr>")

        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td align='left' colspan='11'>Tipo de Empleado: " & clsCommons.strFormatearDescripcion(Request.Form("hdnTipoEmpleado").Trim()) & "</td>")
        strHtmlEncabezado.Append("</tr>")


        strEmpleado = String.Empty

        If (Request.Form("txtEmpleadoNombre").Trim() = String.Empty) Then

            strEmpleado = "Todos"

        Else
            strEmpleado = clsCommons.strFormatearDescripcion(Request.Form("txtEmpleadoNombre").Trim())

        End If

        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td align='left' colspan='11'>Empleado: " & strEmpleado & "</td>")
        strHtmlEncabezado.Append("</tr>")

        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<td align='left' colspan='11'>Activos: " & CStr(IIf(boolActivos, "Si", "Todos")) & "</td>")
        strHtmlEncabezado.Append("</tr>")


        'Titulos Detalle
        strHtmlEncabezado.Append("<table width='770px' border='0' cellpadding='0' cellspacing='0'> ")
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th width='02%'>&nbsp;</th>")
        strHtmlEncabezado.Append("<th width='08%' align='center' class='tdtxtImpresionBoldRayita'>Fecha</th>")
        strHtmlEncabezado.Append("<th width='08%' align='center' class='tdtxtImpresionBoldRayita'>Local <br> SAP</th>")
        strHtmlEncabezado.Append("<th width='15%' align='left'  class='tdtxtImpresionBoldRayita'>Sucursal</th>")
        strHtmlEncabezado.Append("<th width='04%' align='left' class='tdtxtImpresionBoldRayita'>Caja</th>")
        strHtmlEncabezado.Append("<th width='06%' align='center' class='tdtxtImpresionBoldRayita'>No. <br> Empleado</th>")
        strHtmlEncabezado.Append("<th width='17%' align='center' class='tdtxtImpresionBoldRayita'>Empleado</th>")
        strHtmlEncabezado.Append("<th width='14%' align='center' class='tdtxtImpresionBoldRayita'>Empresa</th>")
        strHtmlEncabezado.Append("<th width='06%' align='center' class='tdtxtImpresionBoldRayita'>Activo</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtImpresionBoldRayita'>Hora <br> Entrada</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtImpresionBoldRayita'>Hora <br> Salida</th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strImprimeEncabezado = strHtmlEncabezado.ToString

    End Function

    Private Function strImprimeDetalle(ByVal intContadorRegistro As Integer, ByVal objReporte As Array) As String

        Dim strColorRegistro As String = String.Empty
        Dim strHtmlDetalle As StringBuilder
        Dim strConsultaExhibiciones As String() = Nothing

        Dim intPage As Integer = 1
        Dim intTotal As Integer = 1000
        intContadorRegistro = 1

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For intContadorRegistro = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContadorRegistro >= objReporte.Length) Then
                Exit For
            End If

            If ((intContadorRegistro Mod 2) = 0) Then
                strColorRegistro = "'tdtxtImpresionBold'"
            Else
                strColorRegistro = "'tdtxtImpresionNormal'"
            End If

            strConsultaExhibiciones = CType(objReporte.GetValue(intContadorRegistro), String())

            strHtmlDetalle = New StringBuilder

            strHtmlDetalle.Append("<tr>")

            strHtmlDetalle.Append("<td width='02%'>&nbsp;</td>")
            ' 1 No. de Renglon
            strHtmlDetalle.Append("<td class=" & strColorRegistro & " width='02%' align='right'>" & intContadorRegistro.ToString & "&nbsp;</td>")
            ' Fecha
            strHtmlDetalle.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaExhibiciones(0)) & "</td>")
            ' Local SAP
            strHtmlDetalle.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaExhibiciones(1) & "</td>")
            ' Sucursal
            strHtmlDetalle.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(2)) & "</td>")
            ' Caja
            strHtmlDetalle.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaExhibiciones(3) & "</td>")
            ' No. Empleado
            strHtmlDetalle.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaExhibiciones(4) & "</td>")
            'Empleado
            strHtmlDetalle.Append("<td " & intContadorRegistro & " align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(5)) & "</td>")
            ' Tipo Empleado
            strHtmlDetalle.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(6)) & "</td>")
            ' Activo
            strHtmlDetalle.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(7)) & "</td>")
            ' Hora Entrada
            strHtmlDetalle.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaExhibiciones(8) & "</td>")
            ' Hora Salida 
            strHtmlDetalle.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaExhibiciones(9) & "</td>")

            strHtmlDetalle.Append("</tr>")

            Return strHtmlDetalle.ToString
        Next

    End Function

    Public Function strTablaReporteVisitasExportar(ByVal objConsultaReporte As Array) As String
        Dim strEncabezadosTablaReporteHTML As New StringBuilder
        Dim strTablaReporteHTML As StringBuilder
        Dim CsvFile As New StringBuilder

        Dim strConsultaExhibiciones As String() = Nothing
        Dim intContador As Integer

        Dim intPage As Integer = 1
        Dim intTotal As Integer = 1000

        strEncabezadosTablaReporteHTML.Append("Fecha" & ",")
        strEncabezadosTablaReporteHTML.Append("Local SAP" & ",")
        strEncabezadosTablaReporteHTML.Append("Sucursal" & ",")
        strEncabezadosTablaReporteHTML.Append("Caja" & ",")
        strEncabezadosTablaReporteHTML.Append("No. Empleado" & ",")
        strEncabezadosTablaReporteHTML.Append("Empleado" & ",")
        strEncabezadosTablaReporteHTML.Append("Tipo Empleado" & ",")
        strEncabezadosTablaReporteHTML.Append("Activo" & ",")
        strEncabezadosTablaReporteHTML.Append("Hora Entrada" & ",")
        strEncabezadosTablaReporteHTML.Append("Hora Salida")
        strEncabezadosTablaReporteHTML.Append(vbCrLf)
        strEncabezadosTablaReporteHTML.Append(vbCrLf)

        CsvFile.Append(strEncabezadosTablaReporteHTML.ToString)


        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaReporte.Length) Then
                Exit For
            End If

            strConsultaExhibiciones = CType(objConsultaReporte.GetValue(intContador), String())

            strTablaReporteHTML = New StringBuilder

            'Fecha               
            strTablaReporteHTML.Append(clsCommons.strFormatearFechaPresentacion(strConsultaExhibiciones(0)) & ",")
            'Local SAP
            strTablaReporteHTML.Append(clsCommons.strFormatearDescripcion(strConsultaExhibiciones(1)) & ",")
            'Sucursal                 
            strTablaReporteHTML.Append(clsCommons.strFormatearDescripcion(strConsultaExhibiciones(2)) & ",")
            'Caja
            strTablaReporteHTML.Append(strConsultaExhibiciones(3) & ",")
            'No. Empleado
            strTablaReporteHTML.Append(strConsultaExhibiciones(4) & ",")
            'Empleado
            strTablaReporteHTML.Append(clsCommons.strFormatearDescripcion(strConsultaExhibiciones(5)) & ",")
            'Tipo Empleado
            strTablaReporteHTML.Append(clsCommons.strFormatearDescripcion(strConsultaExhibiciones(6)) & ",")
            'Activo
            strTablaReporteHTML.Append(clsCommons.strFormatearDescripcion(strConsultaExhibiciones(7)) & ",")
            'Hora Entrada
            strTablaReporteHTML.Append(strConsultaExhibiciones(8).Trim() & ",")
            'Hora Salida
            strTablaReporteHTML.Append(strConsultaExhibiciones(9).Trim())
            strTablaReporteHTML.Append(vbCrLf)

            CsvFile.Append(strTablaReporteHTML.ToString)

        Next

        strTablaReporteVisitasExportar = CsvFile.ToString

    End Function


    Public Function strTablaConsultaVisita() As String

        Dim objArray As System.Array = Nothing
        Dim strmRecordBrowserHTML As String = String.Empty
        Dim intEmpleadoId As Integer

        If (strCmd = "cmdConsultar") Then

            If Not strEmpleadoNombreId = String.Empty Then
                intEmpleadoId = CInt(strEmpleadoNombreId)
            Else
                intEmpleadoId = 0
            End If

            intEmpleadoId = 11069731
            'Reporte de Visitas
            'objArray = Benavides.CC.Data.clsReporteDeVisitas.strObtenerReporteVisitasCentral(intDireccionOperativaId, intZonaOperativaId, intEstadoId, intCiudadId, strCentroLogisticoId, intCboTipoEmpleadoId, boolActivos, intEmpleadoId, dtmFechaInicio, dtmFechaFin, strConnectionString)
            objArray = Benavides.CC.Data.clsReporteDeTarjetas.strObtenerReporteTarjetas(CInt(strCentroLogisticoId), intZonaOperativaId, intEmpleadoId, intEmpleadoId, dtmFechaInicio, dtmFechaFin, strConnectionString)

            Dim strResult As New StringBuilder
            If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then

                'Reporte
                strResult.Append(strTablaConsultaReporteHTML(objArray))

                If (blnMasDeMilRegistro = True) Then
                    Response.Write("<script language='Javascript'>alert('Resultados con mas de mil registros, solo se puede exportar');</script>")
                    strExportar()
                    Return String.Empty
                End If

            Else
                'Tabla vacia sin resultados de consulta
                Call Response.Write("<script language='Javascript'>alert('Busqueda sin resultados');</script>")
            End If

            strResult.Append("<script language=""javascript"" type=""text/javascript"">")
            strResult.Append("parent.document.getElementById('tblResultados').innerHTML = document.getElementById('divConsultaVisita').innerHTML;")
            strResult.Append("</script>")

            Return strResult.ToString()
        End If

        Return String.Empty
    End Function

    Public Function strTablaConsultaReporteHTML(ByVal objConsultaReporte As Array) As String

        Dim strTablaReporteHTML As StringBuilder
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim strConsultaRegistroReporte As String()

        strTablaReporteHTML = New StringBuilder

        strTablaReporteHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Encabezados de Tabla de Reporte
        strTablaReporteHTML.Append("<tr class='trtitulos'>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Fecha</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Local SAP</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Sucursal</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Caja</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>No. Empleado</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Empleado</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Tipo <br/> Empleado</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Activo</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Hora Entrada</th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top'>Hora Salida</th>")

        strTablaReporteHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For Each strConsultaRegistroReporte In objConsultaReporte
            intContador += 1

            If intContador = 1000 Then

                blnMasDeMilRegistro = True
                Return String.Empty
            End If

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strTablaReporteHTML.Append("<tr>")
            ' Fecha
            strTablaReporteHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaRegistroReporte(0)) & "</td>")
            ' Local SAP
            strTablaReporteHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaRegistroReporte(1) & "</td>")
            ' Sucursal
            strTablaReporteHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroReporte(2)) & "</td>")
            ' Caja
            strTablaReporteHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaRegistroReporte(3) & "</td>")
            ' No. Empleado
            strTablaReporteHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaRegistroReporte(4) & "</td>")
            'Empleado
            strTablaReporteHTML.Append("<td " & intContador & " align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroReporte(5)) & "</td>")
            ' Tipo Empleado
            strTablaReporteHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroReporte(6)) & "</td>")
            ' Activo
            strTablaReporteHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroReporte(7)) & "</td>")
            ' Hora Entrada
            strTablaReporteHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaRegistroReporte(8) & "</td>")
            ' Hora Salida 
            strTablaReporteHTML.Append("<td align=center class=" & strColorRegistro & ">" & strConsultaRegistroReporte(9) & "</td>")
            strTablaReporteHTML.Append("</tr>")
        Next

        strTablaReporteHTML.Append("</tr>")
        strTablaReporteHTML.Append("</table>")
        strTablaConsultaReporteHTML = strTablaReporteHTML.ToString

    End Function

#Region "Exportar"

    Public Function strTablaConsultaResumenExportar(ByVal objConsultaResumen As Array) As String

        Dim strTablaMovimientosHTML As StringBuilder
        Dim strConsultaResumen As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer

        strTablaMovimientosHTML = New StringBuilder
        strTablaMovimientosHTML.Append("<span class='txsubtitulo'> </span> ")
        strTablaMovimientosHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strTablaMovimientosHTML.Append("<tr class='trtitulos'>")
        strTablaMovimientosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>No.</th>")
        strTablaMovimientosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Empleado</th>")
        strTablaMovimientosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Centro Logistico</th>")
        strTablaMovimientosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Sucursal</th>")
        strTablaMovimientosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Movimiento</th>")
        strTablaMovimientosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Descripcion</th>")
        strTablaMovimientosHTML.Append("<th width='8%' align=center class='rayita' align='left' valign='top'>Cantidad</th>")
        strTablaMovimientosHTML.Append("</tr>")


        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For Each strConsultaResumen In objConsultaResumen
            intContador = intContador + 1

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strTablaMovimientosHTML.Append("<tr>")

            'No.               
            strTablaMovimientosHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaResumen(0).ToString() & "</td>")
            'Empleado
            strTablaMovimientosHTML.Append("<td align=left id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaResumen(1)) & "</td>")
            'Centro Logistico                  
            strTablaMovimientosHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaResumen(2)) & "</td>")
            'Sucursal
            strTablaMovimientosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaResumen(5)) & "</td>")
            'Movimiento
            strTablaMovimientosHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaResumen(6) & "</td>")
            'Descripcion
            strTablaMovimientosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaResumen(7)) & "</td>")
            'Cantidad
            strTablaMovimientosHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaResumen(8) & "</td>")
            strTablaMovimientosHTML.Append("</tr>")

        Next
        strTablaMovimientosHTML.Append("</tr>")
        strTablaMovimientosHTML.Append("</table>")
        strTablaConsultaResumenExportar = strTablaMovimientosHTML.ToString
    End Function

    Public Function strTablaConsultaDetalleExportar(ByVal objConsultaExportaDetalle As Array) As String

        Dim strTablaReporteHTML As StringBuilder
        Dim strConsultaExportaDetalle As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim strConfirmado As String
        Dim imgDetalle As String = Nothing

        strTablaReporteHTML = New StringBuilder
        strTablaReporteHTML.Append("<span class='txsubtitulo'></span> ")
        strTablaReporteHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        strTablaReporteHTML.Append("<tr class='trtitulos'>")
        strTablaReporteHTML.Append("<th class='rayita' colspan='7'></th>")
        strTablaReporteHTML.Append("<th class='rayita' align='center' valign='top' colspan='2'>Confirmacion</th>")
        strTablaReporteHTML.Append("<th class='rayita'></th>")
        strTablaReporteHTML.Append("</tr>")

        strTablaReporteHTML.Append("<tr class='trtitulos'>")
        strTablaReporteHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>No</th>")
        strTablaReporteHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Empleado</th>")
        strTablaReporteHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Centro Logistico</th>")
        strTablaReporteHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Sucursal</th>")
        strTablaReporteHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Movimiento</th>")
        strTablaReporteHTML.Append("<th width='8%' class='rayita' align='center' valign='top'>Descripción</th>")
        strTablaReporteHTML.Append("<th width='8%' class='rayita' align='center' valign='top'>Fecha</th>")
        strTablaReporteHTML.Append("<th width='4%' class='rayita' align='center' valign='top'>Movimiento</th>")
        strTablaReporteHTML.Append("<th width='4%' class='rayita' align='center' valign='top'>Descripción</th>")
        strTablaReporteHTML.Append("<th width='4%' class='rayita' align='center' valign='top'>Confirmado</th>")

        strTablaReporteHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For Each strConsultaExportaDetalle In objConsultaExportaDetalle
            intContador = intContador + 1

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strConfirmado = "No"

            If (CBool(strConsultaExportaDetalle(12)) = True) Then
                strConfirmado = "Si"
            End If

            strTablaReporteHTML.Append("<tr>")

            'No.                
            strTablaReporteHTML.Append("<td align='left' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExportaDetalle(1)) & "</td>")
            'Empleado
            strTablaReporteHTML.Append("<td align='left' id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExportaDetalle(2)) & "</td>")
            'Centro Logistico                  
            strTablaReporteHTML.Append("<td align='center' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExportaDetalle(3)) & "</td>")
            'Sucursal
            strTablaReporteHTML.Append("<td align='left' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExportaDetalle(6)) & "</td>")
            'Movimiento
            strTablaReporteHTML.Append("<td align='center' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExportaDetalle(7)) & "</td>")
            'Descripcion
            strTablaReporteHTML.Append("<td align='left' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExportaDetalle(8)) & "</td>")
            'Fecha 
            strTablaReporteHTML.Append("<td align='center' class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaExportaDetalle(9)) & "</td>")
            'Movimiento
            strTablaReporteHTML.Append("<td align='center' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExportaDetalle(10)) & "</td>")
            'Descripcion
            strTablaReporteHTML.Append("<td align='left' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExportaDetalle(11)) & "</td>")
            'Confoirmad0
            strTablaReporteHTML.Append("<td align='center' class=" & strColorRegistro & ">" & strConfirmado & "</td>")
            strTablaReporteHTML.Append("</tr>")

        Next
        strTablaReporteHTML.Append("</tr>")
        strTablaReporteHTML.Append("</table>")
        strTablaConsultaDetalleExportar = strTablaReporteHTML.ToString
    End Function
#End Region

End Class
