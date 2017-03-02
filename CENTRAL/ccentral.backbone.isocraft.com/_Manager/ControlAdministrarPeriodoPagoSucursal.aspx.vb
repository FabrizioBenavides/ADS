Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports System.Text
Imports System.Collections

Public Class ControlAdministrarPeriodoPagoSucursal
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

#End Region

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        strBuscarSucursal = GetPageParameter("strBuscarSucursal", GetPageParameter("txtBuscarSucursal", ""))

    End Sub

#Region " Class Private Attributes"

    Private _strBuscarSucursal As String
    Private strmJavascriptWindowOnLoadCommands As String

    Private Enum PeriodoNomina
        Quincena = 1
        Semana = 2
    End Enum

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
    ' Name       : strCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")
        End Get
    End Property

    Public ReadOnly Property strCentroLogisticoId() As String
        Get
            Return GetPageParameter("strCentroLogisticoId", "")
        End Get
    End Property

    Public ReadOnly Property intCompaniaId() As String
        Get
            Return GetPageParameter("intCompaniaId", "")
        End Get
    End Property

    Public ReadOnly Property intSucursalId() As String
        Get
            Return GetPageParameter("intSucursalId", "")
        End Get
    End Property

    Public ReadOnly Property strSucursalNombre() As String
        Get
            Return GetPageParameter("strSucursalNombre", "")
        End Get
    End Property

    Public ReadOnly Property strCEconomId() As String
        Get
            Return GetPageParameter("strCEconomId", "")
        End Get
    End Property

    Public ReadOnly Property strCompania() As String
        Get
            Return GetPageParameter("strCompania", "")
        End Get
    End Property

    Public ReadOnly Property intPeriodoNominaId() As String
        Get
            Return GetPageParameter("intPeriodoNominaId", "")
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
    ' Name       : strTipoUsuarioId
    ' Description: Tipo de usuario actual
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTipoUsuarioId() As Integer
        Get
            Return Benavides.CC.Data.clsControlDeAsistencia.intObtenerTipoUsuarioId(strUsuarioNombre, strConnectionString)
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

    Public Property strBuscarSucursal() As String
        Get
            Return _strBuscarSucursal
        End Get
        Set(ByVal strValue As String)
            _strBuscarSucursal = strValue
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
            If Benavides.CC.Business.clsConcentrador.clsControlAcceso. _
                blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Or _
                 Not intTipoUsuarioId = 1 Then
                Call Response.Redirect("../Default.aspx")
            End If

            AgregarSucursalConNomina()

            Select Case strCmd
                Case "Editar"
                    ActualizarRelacionSucursalNomina()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Protected Function strObtenerSucursales() As String
        Dim strResultadoTablaSucursal As New StringBuilder
        Dim objSucursales As Array
        Dim intPage As Integer
        Dim intTotal As Integer = 50

        objSucursales = Benavides.CC.Data.clstblSucursal.strBuscarSucursalesConNomina(strBuscarSucursal, strConnectionString)

        If IsArray(objSucursales) AndAlso objSucursales.Length > 0 Then
            strResultadoTablaSucursal.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strResultadoTablaSucursal.Append("<tr class='trtitulos'>")
            strResultadoTablaSucursal.Append("<th class='rayita'>Centro Logístico</th>")
            strResultadoTablaSucursal.Append("<th class='rayita'>Compañía</th>")
            strResultadoTablaSucursal.Append("<th class='rayita'>Sucursal</th>")
            strResultadoTablaSucursal.Append("<th class='rayita'>Nombre</th>")
            strResultadoTablaSucursal.Append("<th class='rayita'>Centro de Costo</th>")
            strResultadoTablaSucursal.Append("<th class='rayita'>Descripción</th>")
            strResultadoTablaSucursal.Append("<th class='rayita'>Periodo Nómina</th>")
            strResultadoTablaSucursal.Append("<th class='rayita'>Acciones</th>")

            strResultadoTablaSucursal.Append("</tr>")

            strResultadoTablaSucursal.Append(CrearRegistrosSucursales(objSucursales))

            strResultadoTablaSucursal.Append("</table>")
        End If

        Return strResultadoTablaSucursal.ToString()
    End Function

    Private Function CrearRegistrosSucursales(ByVal registros As Array) As String
        Dim intContadorRegistros As Integer = 0
        Dim strColorRegistro As String = String.Empty
        Dim resultado As New StringBuilder
        Dim strImagenEditar As String = "<img src='../static/images/icono_editar.gif' width='11' height='13' border='0' align='center' alt='Haga clic aquí para editar' >"
        Dim strCentroLogisticoId As String = ""
        Dim intCompaniaId As String = ""
        Dim intSucursalId As String = ""
        Dim strSucursalNombre As String = ""
        Dim strCEconomId As String = ""
        Dim strCompania As String = ""
        Dim intPeriodoNominaId As String = ""

        For Each renglon As SortedList In registros
            intContadorRegistros += 1
            strCEconomId = ""
            strCompania = ""
            intPeriodoNominaId = ""

            strCentroLogisticoId = CStr(renglon.Item("strCentroLogisticoId"))
            intCompaniaId = CStr(renglon.Item("intCompaniaId"))
            intSucursalId = CStr(renglon.Item("intSucursalId"))
            strSucursalNombre = CStr(renglon.Item("strSucursalNombre"))

            If Not renglon.Item("strCEconomId") Is "" Then
                strCEconomId = renglon.Item("strCEconomId").ToString()
            End If

            If Not renglon.Item("strCompania") Is "" Then
                strCompania = renglon.Item("strCompania").ToString()
            End If

            If Not renglon.Item("intPeriodoNominaId") Is "" Then
                If PeriodoNomina.Quincena = CInt(renglon.Item("intPeriodoNominaId")) Then
                    intPeriodoNominaId = "Quincena"
                ElseIf PeriodoNomina.Semana = CInt(renglon.Item("intPeriodoNominaId")) Then
                    intPeriodoNominaId = "Semana"
                End If
            End If

            If (intContadorRegistros Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            resultado.Append("<tr>")

            resultado.Append("<td class=" & strColorRegistro & ">" & strCentroLogisticoId & "</td>")
            resultado.Append("<td class=" & strColorRegistro & ">" & intCompaniaId & "</td>")
            resultado.Append("<td class=" & strColorRegistro & ">" & intSucursalId & "</td>")
            resultado.Append("<td class=" & strColorRegistro & ">" & strSucursalNombre & "</td>")
            resultado.Append("<td align=center class=" & strColorRegistro & ">" & strCEconomId & "</td>")
            resultado.Append("<td align=center class=" & strColorRegistro & ">" & strCompania & "</td>")
            resultado.Append("<td align=center class=" & strColorRegistro & ">" & intPeriodoNominaId & "</td>")
            resultado.Append("<td align=center class=" & strColorRegistro & "" & ">" & _
                                               "<a href='ControlAdministrarPeriodoPagoSucursal.aspx?strCmd=Actualizar" & _
                                               "&strCentroLogisticoId=" & strCentroLogisticoId & _
                                               "&intCompaniaId=" & intCompaniaId & _
                                               "&intSucursalId=" & intSucursalId & _
                                               "&strSucursalNombre=" & strSucursalNombre & _
                                               "&strCEconomId=" & strCEconomId & _
                                               "&strCompania=" & strCompania & _
                                               "&intPeriodoNominaId=" & intPeriodoNominaId & "'>" & _
                                                strImagenEditar & "</a></td>")

            resultado.Append("</tr>")
        Next

        Return resultado.ToString()
    End Function

    Private Sub ActualizarRelacionSucursalNomina()
        Dim intResultado As Integer

        intResultado = Benavides.CC.Data.clstblSucursal.intActualizarSucursalConNomina(strCentroLogisticoId, _
                                                                                       CInt(intCompaniaId), _
                                                                                       CInt(intSucursalId), _
                                                                                       strCEconomId, _
                                                                                       strCompania, _
                                                                                       CInt(intPeriodoNominaId), _
                                                                                       strConnectionString)


        Response.Redirect("ControlAdministrarPeriodoPagoSucursal.aspx")
    End Sub

    Private Sub AgregarSucursalConNomina()
        Dim intResultado As Integer

        intResultado = Benavides.CC.Data.clstblSucursal.intAgregarSucursalConNomina(strConnectionString)
    End Sub

End Class