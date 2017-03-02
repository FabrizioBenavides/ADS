Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports System.Text
Imports System.Collections
Imports Benavides.POSAdmin.Commons

'====================================================================
' Class         : SucursalEmpresasServiciosHome
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Sucursal
' Copyright     : 2008 All rights reserved.
' Company       : Softtek
' Author        : Oswaldo Laguna
' Version       : 1.0
' Last Modified : 23/04/2008
' Modified by   : Cesar Ortiz - SOFTTEK
'====================================================================

Public Class SucursalEmpresasServiciosAdministrarEmpresas
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

        'Inicializa(Propiedades)
        intSelectedPage = GetPageParameter("intNavegadorRegistrosPagina", GetPageParameter("txtRecordBrowserSelectedPage", 1))

        intEmpresaServicioId = GetPageParameter("txtEmpresaServicioId", GetPageParameter("intEmpresaServicioId", 0))


    End Sub

#End Region

#Region " Class Private Attributes"

    Private intmSelectedPage As Integer

    Private strmJavascriptWindowOnLoadCommands As String
    Private intmEmpresaServicioId As Integer
    Private intmEmpresaServicioIdAnterior As Integer

    Private strmAbreDetalleEmpresa As String
    Private strmCierraDetalleEmpresa As String

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
    ' Name       : intEmpresaServicioIdAnterior
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intEmpresaServicioIdAnterior() As Integer
        Get
            Return intmEmpresaServicioIdAnterior
        End Get
        Set(ByVal intValue As Integer)
            intmEmpresaServicioIdAnterior = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCierraDetalleCuentasSucursal
    ' Description: Genera el Java Script para poder cerrar y abrir 
    '              llas Cuentas de la Sucursal Indicada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strCierraDetalleEmpresa() As String
        Get
            Return (strmCierraDetalleEmpresa)
        End Get
        Set(ByVal Value As String)
            strmCierraDetalleEmpresa = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strAbreDetalleCuentasSucursal
    ' Description: Genera el Java Script para poder cerrar y abrir 
    '              las Cuentas de la Sucursal Indicada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strAbreDetalleEmpresa() As String
        Get
            Return strmAbreDetalleEmpresa
        End Get
        Set(ByVal Value As String)
            strmAbreDetalleEmpresa = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowser
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowser(ByVal objArrayEmpresas As Array, _
                                     ByVal ArregloAutorizadoresAsignados As Array) As String

        Dim strRegistroEmpresas As String() = Nothing
        Dim strRegistroAutorizadores As String() = Nothing

        Dim intContadorRegistros As Integer = 0
        Dim intTotalRegistros As Integer = 0
        Dim intTotalRegistrosAutorizador As Integer = 0

        Dim strTablaEmpresas As New StringBuilder
        Dim intTablaEmpresasRegistros As Integer = 0

        Dim intContadorEmpresa As Integer = 0
        Dim strColorRegistroEmpresa As String

        Dim intContadorAutorizador As Integer = 0
        Dim strColorRegistroAutorizador As String

        If IsArray(objArrayEmpresas) AndAlso objArrayEmpresas.Length > 0 Then


            intTotalRegistros = objArrayEmpresas.Length 'El Total de Registros de la Consulta

            strTablaEmpresas.Append("<table width='100%' id='tablaBoton' border='0' cellspacing='0' cellpadding='0'>")
            strTablaEmpresas.Append("<tr> <td width= 90%>&nbsp;</td>")
            strTablaEmpresas.Append("<td width=10%> <class='tdtexttablebold' vAlign='top' Aling='right' colSpan='2'>")
            strTablaEmpresas.Append("<input language='javascript' class='button' id='cmdAgregar' onclick='return cmdAgregar_onclick()'")
            strTablaEmpresas.Append("type='submit' value='Agregar Empresas' name='cmdAgregar'>")
            strTablaEmpresas.Append("</td></tr>")
            strTablaEmpresas.Append("</table>")

            strTablaEmpresas.Append("<table width='100%' id='tableRegistro' border='0' cellspacing='0' cellpadding='0'>")
            strTablaEmpresas.Append("<tr><td>")
            strTablaEmpresas.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strTablaEmpresas.Append("<tr class='trtitulos'>")
            strTablaEmpresas.Append("<th width='20'  class='rayita'>&nbsp;</th>")
            strTablaEmpresas.Append("<th width='320'  class='rayita'>Empresa</th>")
            strTablaEmpresas.Append("<th width='40'  class='rayita'>Activa</th>")
            strTablaEmpresas.Append("<th width='120' class='rayita'>Acciones</th>")
            strTablaEmpresas.Append("<th width='40'  class='rayita'>&nbsp;</th>")
            strTablaEmpresas.Append("</tr>")
            strTablaEmpresas.Append("</table>")
            strTablaEmpresas.Append("</td></tr>")

            intContadorRegistros = 0
            intContadorEmpresa = 0
            intContadorAutorizador = 0
            intTablaEmpresasRegistros = 2

            For Each strRegistroEmpresas In objArrayEmpresas

                intContadorAutorizador = 0
                intContadorRegistros += 1
                Dim strActiva As String

                If (intContadorRegistros Mod 2) <> 0 Then
                    strColorRegistroEmpresa = "'tdceleste'"
                Else
                    strColorRegistroEmpresa = "'tdblanco'"
                End If

                If strRegistroEmpresas(2) = "True" Then
                    strActiva = "Si"
                Else
                    strActiva = "No"
                End If

                strTablaEmpresas.Append("<tr>")
                strTablaEmpresas.Append("<td>")
                strTablaEmpresas.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
                strTablaEmpresas.Append("<tr>")
                strTablaEmpresas.Append("<td width='20'  class=" & strColorRegistroEmpresa & ">" & intContadorRegistros.ToString & "</td>")
                strTablaEmpresas.Append("<td width='320'  class=" & strColorRegistroEmpresa & ">" & clsCommons.strFormatearDescripcion(strRegistroEmpresas(1)) & "</td>")
                strTablaEmpresas.Append("<td width='40'  class=" & strColorRegistroEmpresa & ">" & clsCommons.strFormatearDescripcion(strActiva) & "</td>")
                strTablaEmpresas.Append("<td  width='120'  class=" & strColorRegistroEmpresa & ">")
                strTablaEmpresas.Append("<table width='120' border='0' cellpadding='0' cellspacing='0'>")
                strTablaEmpresas.Append("<tr>")
                strTablaEmpresas.Append("<td width='30'><a href='SucursalEmpresasServiciosAgregarEmpresa.aspx?strCmd=Editar&intEmpresaServicioId=" & strRegistroEmpresas(0) & "';'")
                strTablaEmpresas.Append("class='txaccion'><img src='../static/images/imgNREditar.gif' width='13' height='13' align='absmiddle' alt='Editar Empresa de Servicio' border='0'></a></td>")
                strTablaEmpresas.Append("<td width='30'><a href='SucursalEmpresasServiciosAsignarAutorizador.aspx?strCmd=Asignar&intEmpresaServicioId=" & strRegistroEmpresas(0) & "';'")
                strTablaEmpresas.Append("class='txaccion'><img src='../static/images/icono_asignar.gif' width='13' height='13' align='absmiddle' alt='Asignar Autorizadores' border='0'></a></td>")
                strTablaEmpresas.Append("<td width='30'><a href='SucursalEmpresasServiciosEditarFormato.aspx?strCmd=EdiA&intEmpresaServicioId=" & strRegistroEmpresas(0) & "';'")
                strTablaEmpresas.Append("class='txaccion'><img src='../static/images/imgNREdiA.gif' width='13' height='13' align='absmiddle' alt='Editar Formato de Lectura' border='0'></a></td>")
                strTablaEmpresas.Append("<td width='30'><a href='SucursalEmpresasServiciosAsignarEmpresa.aspx?strCmd=Asignar&intEmpresaServicioId=" & strRegistroEmpresas(0) & "';'")
                strTablaEmpresas.Append("class='txaccion'><img src='../static/images/imgNRAsignar.gif' width='13' height='13' align='absmiddle' alt='Asignar Sucursales' border='0'></a></td>")
                strTablaEmpresas.Append("</tr>")
                strTablaEmpresas.Append("</table>")
                strTablaEmpresas.Append("</td>")
                strTablaEmpresas.Append("<td width='40'  class=" & strColorRegistroEmpresa & "><a href='javascript:ActivateRow(" & intTablaEmpresasRegistros.ToString & ")'><img src='../static/images/icono_mas.gif' width='9' height='9' border='0' align='absMiddle' alt = 'Haga clic aquí para ver los autorizadores de la empresa'></a></td>")
                strTablaEmpresas.Append("</tr>")
                strTablaEmpresas.Append("</table>")
                strTablaEmpresas.Append("</td>")
                strTablaEmpresas.Append("</tr>")

                strTablaEmpresas.Append("<tr>")
                strTablaEmpresas.Append("<td>")
                strTablaEmpresas.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
                strTablaEmpresas.Append("<tr>")
                strTablaEmpresas.Append("<td width='20'  class=" & strColorRegistroEmpresa & ">" & intContadorRegistros.ToString & "</td>")
                strTablaEmpresas.Append("<td width='320'  class=" & strColorRegistroEmpresa & ">" & clsCommons.strFormatearDescripcion(strRegistroEmpresas(1)) & "</td>")
                strTablaEmpresas.Append("<td width='40'  class=" & strColorRegistroEmpresa & ">" & clsCommons.strFormatearDescripcion(strActiva) & "</td>")
                strTablaEmpresas.Append("<td  width='120'  class=" & strColorRegistroEmpresa & ">")
                strTablaEmpresas.Append("<table width='120' border='0' cellpadding='0' cellspacing='0'>")
                strTablaEmpresas.Append("<tr>")
                strTablaEmpresas.Append("<td width='30'><a href='SucursalEmpresasServiciosAgregarEmpresa.aspx?strCmd=Editar&intEmpresaServicioId=" & strRegistroEmpresas(0) & "';'")
                strTablaEmpresas.Append("class='txaccion'><img src='../static/images/imgNREditar.gif' width='13' height='13' align='absmiddle' alt='Editar Empresa de Servicio' border='0'></a></td>")
                strTablaEmpresas.Append("<td width='30'><a href='SucursalEmpresasServiciosAsignarAutorizador.aspx?strCmd=Asignar&intEmpresaServicioId=" & strRegistroEmpresas(0) & "';'")
                strTablaEmpresas.Append("class='txaccion'><img src='../static/images/icono_asignar.gif' width='13' height='13' align='absmiddle' alt='Asignar Autorizadores' border='0'></a></td>")
                strTablaEmpresas.Append("<td width='30'><a href='SucursalEmpresasServiciosEditarFormato.aspx?strCmd=EdiA&intEmpresaServicioId=" & strRegistroEmpresas(0) & "';'")
                strTablaEmpresas.Append("class='txaccion'><img src='../static/images/imgNREdiA.gif' width='13' height='13' align='absmiddle' alt='Editar Formato de Lectura' border='0'></a></td>")
                strTablaEmpresas.Append("<td width='30'><a href='SucursalEmpresasServiciosAsignarEmpresa.aspx?strCmd=Asignar&intEmpresaServicioId=" & strRegistroEmpresas(0) & "';'")
                strTablaEmpresas.Append("class='txaccion'><img src='../static/images/imgNRAsignar.gif' width='13' height='13' align='absmiddle' alt='Asignar Sucursales' border='0'></a></td>")
                strTablaEmpresas.Append("</tr>")
                strTablaEmpresas.Append("</table>")
                strTablaEmpresas.Append("</td>")
                strTablaEmpresas.Append("<td width='40'  class=" & strColorRegistroEmpresa & "><a href='javascript:DeactivateRow(" & intTablaEmpresasRegistros.ToString & ")'><img src='../static/images/icono_menos.gif' width='9' height='9' border='0' align='absMiddle'></a></td>")
                strTablaEmpresas.Append("</tr>")
                strTablaEmpresas.Append("</table>")
                strTablaEmpresas.Append("</td>")
                strTablaEmpresas.Append("</tr>")

                strTablaEmpresas.Append("<tr>")
                strTablaEmpresas.Append("<td valign='top'>")
                strTablaEmpresas.Append("<br><span class='txrojobold'><br>&nbsp; " & clsCommons.strFormatearDescripcion(strRegistroEmpresas(1)) & "<br><br></span>")
                strTablaEmpresas.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0'>")
                strTablaEmpresas.Append("<tr>")
                strTablaEmpresas.Append("<td valign='top' class='tdenvolventetabla'>")
                strTablaEmpresas.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

                strTablaEmpresas.Append("<tr class='trtitulos'>")
                strTablaEmpresas.Append("<th width='4'   class='rayita'>&nbsp;</th>")
                strTablaEmpresas.Append("<th width='100' class='rayita'>Autorizador</th>")
                strTablaEmpresas.Append("<th width='100' class='rayita'>Código</th>")
                strTablaEmpresas.Append("<th width='220' class='rayita'>Comisión Compartida</th>")
                strTablaEmpresas.Append("<th width='100' class='rayita'>Activa</th>")

                strTablaEmpresas.Append("</tr>")

                intTablaEmpresasRegistros += 3

                If IsArray(ArregloAutorizadoresAsignados) AndAlso ArregloAutorizadoresAsignados.Length > 0 Then

                    For Each strRegistroAutorizadores In ArregloAutorizadoresAsignados
                        Dim i As Integer

                        If CInt(strRegistroAutorizadores(0).ToString) = CInt(strRegistroEmpresas(0).ToString) Then

                            intContadorAutorizador += 1

                            If (intContadorAutorizador Mod 2) <> 0 Then
                                strColorRegistroAutorizador = "'tdceleste'"
                            Else
                                strColorRegistroAutorizador = "'tdblanco'"
                            End If

                            If strRegistroAutorizadores(4) = "True" Then
                                strActiva = "Si"
                            Else
                                strActiva = "No"
                            End If

                            strTablaEmpresas.Append("<tr>")
                            strTablaEmpresas.Append("<td width='4'   class=" & strColorRegistroAutorizador & ">" & intContadorAutorizador.ToString & "</td>")
                            strTablaEmpresas.Append("<td width='100' class=" & strColorRegistroAutorizador & ">" & clsCommons.strFormatearDescripcion(strRegistroAutorizadores(1)) & "</td>")
                            strTablaEmpresas.Append("<td width='100' class=" & strColorRegistroAutorizador & ">" & clsCommons.strFormatearDescripcion(strRegistroAutorizadores(2)) & "</td>")
                            strTablaEmpresas.Append("<td width='220' class=" & strColorRegistroAutorizador & ">" & clsCommons.strFormatearDescripcion(strRegistroAutorizadores(3)) & "</td>")
                            strTablaEmpresas.Append("<td width='100' class=" & strColorRegistroAutorizador & ">" & clsCommons.strFormatearDescripcion(strActiva) & "</td>")
                            strTablaEmpresas.Append("</tr>")

                        End If

                    Next

                End If

                'Cerrar las tablas.

                strTablaEmpresas.Append("</table>")
                strTablaEmpresas.Append("</td>")
                strTablaEmpresas.Append("</tr>")
                strTablaEmpresas.Append("</table>")
                strTablaEmpresas.Append("<br>")
                strTablaEmpresas.Append("</td>")
                strTablaEmpresas.Append("</tr>")

            Next

            strTablaEmpresas.Append("</table>")

            Dim intInicio As Integer = 0
            Dim intRenglonInicio As Integer = 2
            Dim strDeativate As String = ""
            Dim strActivate As String = ""

            ' vcsg - Se generan mas deactivates de los necesarios
            For intInicio = 1 To intContadorRegistros
                strDeativate += "DeactivateRow(" & intRenglonInicio.ToString & ");"
                strActivate += "ActivateRow(" & intRenglonInicio.ToString & ");"
                intRenglonInicio += 3
            Next

            strCierraDetalleEmpresa = strDeativate
            strAbreDetalleEmpresa = strActivate

        End If

        strRecordBrowser = clsCommons.strGenerateJavascriptString(strTablaEmpresas.ToString)

    End Function

    '====================================================================
    ' Name       : strGetRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 10
        Const strRecordBrowserName As String = "SucursalEmpresasServiciosAdministrarEmpresas"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim ArregloEmpresas As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.strObtenerEmpresasDeServicio(strConnectionString)
        Dim ArregloAutorizadoresAsignados As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicioAutorizador.strObtenerEmpresasConAutorizadores(strConnectionString)

        ' Generamos el navegador de registros
        Dim strReturn As String = strRecordBrowser(ArregloEmpresas, ArregloAutorizadoresAsignados)

        Return strReturn

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Select Case strCmd

            Case "Agregar"

                Call Response.Redirect("SucursalEmpresasServiciosAgregarEmpresa.aspx?strCmd=" & strCmd)

                'Case "EdiA"

                '    'Editar Formato de Lectura en POS
                '    If intEmpresaServicioId > 0 Then
                '        Call Response.Redirect("SucursalEmpresasServiciosEditarFormato.aspx?strCmd=" & strCmd & "&intEmpresaServicioId=" & intEmpresaServicioId)
                '        'Call Response.Redirect("SucursalEmpresasServiciosAsignarAutorizador.aspx?strCmd=" & strCmd & "&intEmpresaServicioId=" & intEmpresaServicioId)
                '    End If

                'Case "Editar"

                '    'Editar los datos de la empresa
                '    If intEmpresaServicioId > 0 Then
                '        Call Response.Redirect("SucursalEmpresasServiciosAgregarEmpresa.aspx?strCmd=" & strCmd & "&intEmpresaServicioId=" & intEmpresaServicioId)
                '    End If

                'Case "Asignar"
                '    'Asignar sucursales
                '    If intEmpresaServicioId > 0 Then
                '        Call Response.Redirect("SucursalEmpresasServiciosAsignarEmpresa.aspx?strCmd=" & strCmd & "&intEmpresaServicioId=" & intEmpresaServicioId)
                '    End If

        End Select
    End Sub

End Class
