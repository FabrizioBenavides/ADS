Imports Benavides.POSAdmin.Commons
Imports System.Text
'====================================================================
' Class         : clsSistemaTransmisionesPendientesDetalleRed
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Consultar detalle de brincos en folios contables
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Armando Calzada Mezura
' Version       : 1.0
' Last Modified : Tuesday, July 27, 2004
'====================================================================
Public Class clsSistemaTransmisionesPendientesDetalleRed
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
    Dim intmDireccionOperativaId As Integer
    Dim intmReporteId As Integer
    Dim strmCmd As String

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

    Private Function strComplete2Digit(ByVal strValue As String) As String
        If Len(strValue) = 1 Then
            Return "0" & strValue
        Else
            Return strValue
        End If
    End Function

    '====================================================================
    ' Name       : strCmd
    ' Description: Comando a ejecutar
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If strmCmd = "" Then
                strmCmd = CStr(isocraft.commons.clsWeb.strGetPageParameter("strCmd", "Detalle"))
            End If
            Return strmCmd
        End Get
    End Property

    '====================================================================
    ' Name       : intReporteId
    ' Description: Identificador del tipo de reporte
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intReporteId() As Integer
        Get
            If intmReporteId = 0 Then

                ' Si no encuentra el parámetro
                intmReporteId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboReporteId", "0"))

                ' Busco el valor del combo
                If intmReporteId = 0 Then
                    intmReporteId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intReporteId", "1"))
                End If

            End If
            Return intmReporteId
        End Get
    End Property

    '====================================================================
    ' Name       : intDireccionOperativaId
    ' Description: Identificador del tipo de reporte
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDireccionOperativaId() As Integer
        Get
            If intmDireccionOperativaId = 0 Then
                intmDireccionOperativaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intDireccionOperativaId", "0"))
            End If
            Return intmDireccionOperativaId
        End Get
    End Property

    '====================================================================
    ' Name       : strEncabezadoHTML
    ' Description: Encabezado del reporte
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strEncabezadoHTML() As String
        Get

            ' Declaramos las variables
            Dim astrTransmisionPendiente As Array
            Dim strbldEncabezadoHTML As StringBuilder

            ' Nombre del objeto pendiente de transmitir
            Dim strNombreTipoTransmision As String

            ' Total de elementos pendientes de transmitir
            Dim intTransmisionesPendientes As Integer = 0

            ' Inicializamos el texto de salida
            strbldEncabezadoHTML = New StringBuilder

            ' De acuerdo al tipo de reporte
            Select Case intReporteId
                Case 1
                    ' Si es 1, buscar las pólizas pendientes de transmitir
                    astrTransmisionPendiente = Benavides.CC.Data.clsTransmision.strEjecutarBuscarTransmisionesPolizaPendientes(0, 0, 0, 0, strConnectionString)

                Case 2
                    ' Si es 1, buscar las ventas diariras pendientes de transmitir
                    astrTransmisionPendiente = Benavides.CC.Data.clsTransmision.strEjecutarBuscarTransmisionesVentaDiariaPendientes(0, 0, 0, 0, strConnectionString)

                Case 3
                    ' Si es 1, buscar los tickets pendientes de transmitir
                    astrTransmisionPendiente = Benavides.CC.Data.clsTransmision.strEjecutarBuscarTransmisionesTicketPendientes(0, 0, 0, 0, strConnectionString)

            End Select

            ' Si encontró resultados
            If IsArray(astrTransmisionPendiente) AndAlso astrTransmisionPendiente.Length > 0 Then

                ' Obtenemos el nombre completo del reporte
                Dim strReporte As String = CStr(DirectCast(astrTransmisionPendiente.GetValue(0), Array).GetValue(0))

                ' Obtenemos la cantidad de elementos pendientes de transmitir
                intTransmisionesPendientes = CInt(DirectCast(astrTransmisionPendiente.GetValue(0), Array).GetValue(1))

                ' Separamos por espacios
                Dim astrReporteNombre As String() = strReporte.Split(" "c)

                ' Asigamos el nombre del reporte a la variable
                strNombreTipoTransmision = CStr(astrReporteNombre.GetValue(0))

                ' Creamos el encabezado del reporte
                strbldEncabezadoHTML.Append("<h2>" & strNombreTipoTransmision & " pendientes de transmitir </h2>")
                strbldEncabezadoHTML.Append("<table width=""60%""  border=""0"" cellspacing=""0"" cellpadding=""0"">")
                strbldEncabezadoHTML.Append("<tr><td width=""16%"" class=""tdtexttablebold"">Mostrando:</td>")
                strbldEncabezadoHTML.Append("<td width=""84%"" class=""tdcontentableblue"">Toda la red </td></tr>")
                strbldEncabezadoHTML.Append("<tr><td class=""tdtexttablebold"">Total:</td>")
                strbldEncabezadoHTML.Append("<td class=""tdcontentableblue"">" & intTransmisionesPendientes.ToString & " " & strNombreTipoTransmision.ToLower & "</td></tr></table>")

            End If

            ' Regresamos el resultado 
            Return clsCommons.strGenerateJavascriptString(strbldEncabezadoHTML.ToString)

        End Get
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRecordBrowserHTML() As String
        Get
            ' Declaramos e inicializamos las constantes locales
            Const intElementsPerPage As Integer = 13
            Const strRecordBrowserName As String = "SistemaTransmisionesPendientesDetalleRed"

            ' Declaración e inicialización de las variables locales
            Dim astrDataArray As Array
            Dim strbldRecordBrowserHTML As StringBuilder
            Dim strTargetURL As String = "SistemaTransmisionesPendientesDetalleRed.aspx?intReporteId=" & intReporteId.ToString & "&"

            Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1"))

            strbldRecordBrowserHTML = New StringBuilder

            ' De acuerdo al tipo de reporte
            Select Case intReporteId
                Case 1
                    ' Si es 1, buscar las pólizas pendientes de transmitir
                    astrDataArray = Benavides.CC.Data.clsTransmision.strEjecutarBuscarTransmisionesPolizaPendientesPorDireccion(0, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

                Case 2
                    ' Si es 1, buscar las ventas diariras pendientes de transmitir
                    astrDataArray = Benavides.CC.Data.clsTransmision.strEjecutarBuscarTransmisionesVentaDiariaPendientesPorDireccion(0, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

                Case 3
                    ' Si es 1, buscar los tickets pendientes de transmitir
                    astrDataArray = Benavides.CC.Data.clsTransmision.strEjecutarBuscarTransmisionesTicketPendientesPorDireccion(0, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

            End Select

            ' Almacenamos el resultado
            strbldRecordBrowserHTML.Append(Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strTargetURL))

            Return clsCommons.strGenerateJavascriptString(strbldRecordBrowserHTML.ToString)

        End Get

    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Ver"
                ' LLamamos a la página de detale de direccción operativa
                Call Response.Redirect("SistemaTransmisionesPendientesDetalleDireccion.aspx?strCmd=Detalle&intReporteId=" & intReporteId.ToString & "&intDireccionOperativaId=" & intDireccionOperativaId.ToString)

        End Select

    End Sub

End Class
