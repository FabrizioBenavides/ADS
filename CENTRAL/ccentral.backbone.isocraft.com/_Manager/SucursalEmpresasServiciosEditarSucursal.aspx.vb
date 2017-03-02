Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports System.Text
Imports System.Collections
Imports Benavides.POSAdmin.Commons

'====================================================================
' Class         : SucursalEmpresasServiciosEditarSucursal
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Sucursal
' Copyright     : 2008 All rights reserved.
' Company       : Softtek
' Author        : Oswaldo Laguna
' Version       : 1.0
' Last Modified : 30/04/2008
'====================================================================

Public Class SucursalEmpresasServiciosEditarSucursal
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

        intSelectedPage = GetPageParameter("intNavegadorRegistrosPagina", GetPageParameter("txtRecordBrowserSelectedPage", 1))

        intEmpresaServicioId = GetPageParameter("intEmpresaServicioId", 0)

        intEliminarEmpresaServicioId = GetPageParameter("intEliminarEmpresaServicioId", 0)

        intSucursalId = GetPageParameter("intSucursalId", GetPageParameter("txtSucursalId", 0))

        intCompaniaId = GetPageParameter("intCompaniaId", GetPageParameter("txtCompaniaId", 0))

        strSucursalNombre = GetPageParameter("txtSucursalNombre", "")

        strJavascriptWindowOnLoadCommands = ""
    End Sub

#End Region

#Region " Class Private Attributes"

    Private intmSelectedPage As Integer
    Private strmJavascriptWindowOnLoadCommands As String
    Private intmEmpresaServicioId As Integer
    Private intmEliminarEmpresaServicioId As Integer
    Private intmSucursalId As Integer
    Private strmSucursalNombre As String
    Private intmCompaniaId As Integer
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
            Return GetPageParameter("strCmd", "Editar")
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
    ' Name       : intEmpresaServiciolId
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
    ' Name       : intEliminarEmpresaServiciolId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intEliminarEmpresaServicioId() As Integer
        Get
            Return intmEliminarEmpresaServicioId
        End Get
        Set(ByVal intValue As Integer)
            intmEliminarEmpresaServicioId = intValue
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
    ' Name       : strSucursalNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strSucursalNombre() As String
        Get
            Return strmSucursalNombre
        End Get
        Set(ByVal intValue As String)
            strmSucursalNombre = intValue
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
                                     ByVal ArregloFormasDePago As Array) As String

        Dim strRegistroEmpresas As String() = Nothing
        Dim strRegistroFormasDePago As String() = Nothing

        Dim intContadorRegistros As Integer = 0
        Dim intTotalRegistros As Integer = 0
        Dim intTotalRegistrosFormasDePago As Integer = 0

        Dim strTablaEmpresas As New StringBuilder
        Dim intTablaEmpresasRegistros As Integer = 0

        Dim intContadorEmpresa As Integer = 0
        Dim strColorRegistroEmpresa As String

        Dim intContadorFormaDePago As Integer = 0
        Dim strColorRegistroFormaDePago As String

        If IsArray(objArrayEmpresas) AndAlso objArrayEmpresas.Length > 0 Then


            intTotalRegistros = objArrayEmpresas.Length 'El Total de Registros de la Consulta

            strTablaEmpresas.Append("<table width='100%' id='tableRegistro' border='0' cellspacing='0' cellpadding='0'>")
            strTablaEmpresas.Append("<tr><td>")
            strTablaEmpresas.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strTablaEmpresas.Append("<tr class='trtitulos'>")
            strTablaEmpresas.Append("<th width='80'  class='rayita'>&nbsp;</th>")
            strTablaEmpresas.Append("<th width='150'  class='rayita'>Empresa</th>")
            strTablaEmpresas.Append("<th width='150'  class='rayita'>Comisión</th>")
            strTablaEmpresas.Append("<th width='120' class='rayita'>Acciones</th>")
            strTablaEmpresas.Append("<th width='40'  class='rayita'>&nbsp;</th>")
            strTablaEmpresas.Append("</tr>")
            strTablaEmpresas.Append("</table>")
            strTablaEmpresas.Append("</td></tr>")

            intContadorRegistros = 0
            intContadorEmpresa = 0
            intContadorFormaDePago = 0
            intTablaEmpresasRegistros = 2

            For Each strRegistroEmpresas In objArrayEmpresas

                intContadorFormaDePago = 0
                intContadorRegistros += 1

                If (intContadorRegistros Mod 2) <> 0 Then
                    strColorRegistroEmpresa = "'tdceleste'"
                Else
                    strColorRegistroEmpresa = "'tdblanco'"
                End If

                strTablaEmpresas.Append("<tr>")
                strTablaEmpresas.Append("<td>")
                strTablaEmpresas.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
                strTablaEmpresas.Append("<tr>")
                strTablaEmpresas.Append("<td width='80'  class=" & strColorRegistroEmpresa & ">" & intContadorRegistros.ToString & "</td>")
                strTablaEmpresas.Append("<td width='150'  class=" & strColorRegistroEmpresa & ">" & clsCommons.strFormatearDescripcion(strRegistroEmpresas(1)) & "</td>")
                strTablaEmpresas.Append("<td width='150'  class=" & strColorRegistroEmpresa & ">" & clsCommons.strFormatearDescripcion(strRegistroEmpresas(2)) & "</td>")
                strTablaEmpresas.Append("<td width='120' class=" & strColorRegistroEmpresa & "><a href='SucursalEmpresasServiciosEditarSucursal.aspx?strCmd=Eliminar&intCompaniaId=" & intCompaniaId & "&intSucursalId=" & intSucursalId & "&intEliminarEmpresaServicioId=" & strRegistroEmpresas(0) & "&intEmpresaServicioId=" & intEmpresaServicioId & "';'")
                strTablaEmpresas.Append("class='txaccion'><img src='../static/images/imgNRborrar.gif' width='13' height='13' align='absmiddle' alt='Eliminar Empresa de Servicio en esta Sucursal' border='0'></a></td>")
                strTablaEmpresas.Append("<td width='40'  class=" & strColorRegistroEmpresa & "><a href='javascript:ActivateRow(" & intTablaEmpresasRegistros.ToString & ")'><img src='../static/images/icono_mas.gif' width='9' height='9' border='0' align='absMiddle' alt = 'Haga clic aquí para ver las formas de pago de la empresa'></a></td>")
                strTablaEmpresas.Append("</tr>")
                strTablaEmpresas.Append("</table>")
                strTablaEmpresas.Append("</td>")
                strTablaEmpresas.Append("</tr>")

                strTablaEmpresas.Append("<tr>")
                strTablaEmpresas.Append("<td>")
                strTablaEmpresas.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
                strTablaEmpresas.Append("<tr>")
                strTablaEmpresas.Append("<td width='80'  class=" & strColorRegistroEmpresa & ">" & intContadorRegistros.ToString & "</td>")
                strTablaEmpresas.Append("<td width='150'  class=" & strColorRegistroEmpresa & ">" & clsCommons.strFormatearDescripcion(strRegistroEmpresas(1)) & "</td>")
                strTablaEmpresas.Append("<td width='150'  class=" & strColorRegistroEmpresa & ">" & clsCommons.strFormatearDescripcion(strRegistroEmpresas(2)) & "</td>")
                strTablaEmpresas.Append("<td width='120' class=" & strColorRegistroEmpresa & "><a href='SucursalEmpresasServiciosEditarSucursal.aspx?strCmd=Eliminar&intCompaniaId=" & intCompaniaId & "&intSucursalId=" & intSucursalId & "&intEmpresaServicioId=" & strRegistroEmpresas(0) & "';'")
                strTablaEmpresas.Append("class='txaccion'><img src='../static/images/imgNRborrar.gif' width='13' height='13' align='absmiddle' alt='Eliminar Empresa de Servicio en esta Sucursal' border='0'></a></td>")
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
                strTablaEmpresas.Append("<th width='100' class='rayita'>Forma de Pago</th>")
                strTablaEmpresas.Append("<th width='100' class='rayita'>Monto Máximo</th>")

                strTablaEmpresas.Append("</tr>")

                intTablaEmpresasRegistros += 3

                For Each strRegistroFormasDePago In ArregloFormasDePago
                    Dim i As Integer

                    If CInt(strRegistroFormasDePago(0).ToString) = CInt(strRegistroEmpresas(0).ToString) Then

                        intContadorFormaDePago += 1

                        If (intContadorFormaDePago Mod 2) <> 0 Then
                            strColorRegistroFormaDePago = "'tdceleste'"
                        Else
                            strColorRegistroFormaDePago = "'tdblanco'"
                        End If

                        strTablaEmpresas.Append("<tr>")
                        strTablaEmpresas.Append("<td width='4'   class=" & strColorRegistroFormaDePago & ">" & intContadorFormaDePago.ToString & "</td>")
                        strTablaEmpresas.Append("<td width='100' class=" & strColorRegistroFormaDePago & ">" & clsCommons.strFormatearDescripcion(strRegistroFormasDePago(1)) & "</td>")
                        strTablaEmpresas.Append("<td width='100' class=" & strColorRegistroFormaDePago & ">" & clsCommons.strFormatearDescripcion(strRegistroFormasDePago(2)) & "</td>")
                        strTablaEmpresas.Append("</tr>")

                    End If

                Next

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

        ' Declaramos e inicializamos las variables locales
        Dim ArregloEmpresas As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicioSucursal.strObtenerEmpresasAsignadasASucursal(intCompaniaId, intSucursalId, strConnectionString)
        Dim ArregloFormasDePago As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicioSucursalMonto.strObtenerEmpresasConFormasDePago(intCompaniaId, intSucursalId, strConnectionString)

        ' Generamos el navegador de registros
        Dim strReturn As String = strRecordBrowser(ArregloEmpresas, ArregloFormasDePago)

        Return strReturn

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Select Case strCmd

            Case "Eliminar"

                ' Si el identificador del elemento es válido, eliminamos las sucursales del cliente
                If intEmpresaServicioId > 0 Then

                    '' Buscamos el registro a eliminar
                    Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.strBuscarSucursalesAsignadas(intCompaniaId, intSucursalId, intEliminarEmpresaServicioId, True, 0.0, CDate("01/01/1900"), "", 0, 0, strConnectionString)

                    '' Si el registro existe
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        ' Eliminamos el registro
                        Call Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicioSucursal.intEliminarEmpresaServicioSucursal(intCompaniaId, intSucursalId, intEliminarEmpresaServicioId, False, strUsuarioNombre, strConnectionString)

                        ' Obtenemos los datos de la empresa de servicio actual
                        Dim aobjElements As Array = Benavides.CC.Data.clstblSucursal.strBuscar(intCompaniaId, intSucursalId, 0, 0, "", 0, 0, 0, CDate("01/01/1900"), "", "", "", "", 0, 0, strConnectionString)
                        ' Si el elemento fue encontrado
                        If IsNothing(aobjElements) = False AndAlso aobjData.Length > 0 Then
                            ' Recuperamos sus datos
                            strSucursalNombre = CStr(DirectCast(aobjElements.GetValue(0), Array).GetValue(4))
                        End If

                    End If

                End If

            Case "Editar"

                ' Si el identificador del elemento es válido
                If intSucursalId > 0 And intCompaniaId > 0 Then

                    ' Obtenemos el elemento
                    Dim aobjData As Array = Benavides.CC.Data.clstblSucursal.strBuscar(intCompaniaId, intSucursalId, 0, 0, "", 0, 0, 0, CDate("01/01/1900"), "", "", "", "", 0, 0, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        ' Recuperamos sus datos
                        strSucursalNombre = CStr(DirectCast(aobjData.GetValue(0), Array).GetValue(4))

                    End If

                End If

            Case Else

                ' Comando inválido, direccionamos al usuario a la página padre
                Call Response.Redirect("SucursalEmpresasServiciosAsignarEmpresa.aspx")

        End Select


    End Sub

End Class
