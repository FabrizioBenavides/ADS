Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert
Imports System.Text
Imports System.Collections
Imports Benavides.POSAdmin.Commons

Public Class SucursalEmpresasServiciosAsignarEmpresa
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

        intEmpresaServicioId = GetPageParameter("intEmpresaServicioId", GetPageParameter("txtEmpresaServicioId", 0))

        strEmpresaServicioNombre = GetPageParameter("txtEmpresaServicioNombre", "")

        blnEmpresaServicioActiva = GetPageParameter("chkEmpresaServicioActiva", False)

        intCompaniaId = GetPageParameter("intCompaniaId", 0)

        intSucursalId = GetPageParameter("intSucursalId", 0)

        strJavascriptWindowOnLoadCommands = ""

    End Sub

#End Region

#Region " Class Private Attributes"

    Private intmSelectedPage As Integer
    Private strmJavascriptWindowOnLoadCommands As String
    Private intmEmpresaServicioId As Integer
    Private strmEmpresaServicioNombre As String
    Private blnmchkEmpresaServicioActiva As Boolean
    Private intmCompaniaId As Integer
    Private intmSucursalId As Integer
    Private fltmComision As Double


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
            Return GetPageParameter("strCmd", "Asignar")
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
    ' Name       : strEmpresaServicioNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strEmpresaServicioNombre() As String
        Get
            Return strmEmpresaServicioNombre
        End Get
        Set(ByVal intValue As String)
            strmEmpresaServicioNombre = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnEmpresaServicioActiva
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnEmpresaServicioActiva() As Boolean
        Get
            Return blnmchkEmpresaServicioActiva
        End Get
        Set(ByVal blnValue As Boolean)
            blnmchkEmpresaServicioActiva = blnValue
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
    ' Name       : fltComision
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property fltComision() As Double
        Get
            'fltmComision = CDbl(Request.Form("txtEmpresaComision"))
            Return fltmComision
        End Get
        Set(ByVal Value As Double)
            fltmComision = Value
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
    Public Function strRecordBrowser(ByVal objArraySucursales As Array, _
                                     ByVal ArregloFormasDePago As Array) As String

        Dim strRegistroSucursales As String() = Nothing
        Dim strRegistroFormasDePago As String() = Nothing

        Dim intContadorRegistros As Integer = 0
        Dim intTotalRegistros As Integer = 0
        Dim intTotalRegistrosFormasDePago As Integer = 0

        Dim strTablaSucursales As New StringBuilder
        Dim intTablaSucursalesRegistros As Integer = 0

        Dim intContadorEmpresa As Integer = 0
        Dim strColorRegistroSucursal As String

        Dim intContadorFormaDePago As Integer = 0
        Dim strColorRegistroFormaDePago As String

        If IsArray(objArraySucursales) AndAlso objArraySucursales.Length > 0 Then


            intTotalRegistros = objArraySucursales.Length 'El Total de Registros de la Consulta

            strTablaSucursales.Append("<table width='100%' id='tableRegistro' border='0' cellspacing='0' cellpadding='0'>")
            strTablaSucursales.Append("<tr><td>")
            strTablaSucursales.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strTablaSucursales.Append("<tr class='trtitulos'>")
            strTablaSucursales.Append("<th width='10%' class='rayita'>Compañía</th>")
            strTablaSucursales.Append("<th width='10%' class='rayita'>Sucursal</th>")
            strTablaSucursales.Append("<th width='40%' class='rayita'>Nombre</th>")
            strTablaSucursales.Append("<th width='10%' class='rayita'>Comisión</th>")
            strTablaSucursales.Append("<th width='20%' class='rayita'>Acciones</th>")
            strTablaSucursales.Append("<th width='10%' class='rayita'>&nbsp;</th>")
            strTablaSucursales.Append("</tr>")
            strTablaSucursales.Append("</table>")
            strTablaSucursales.Append("</td></tr>")

            intContadorRegistros = 0
            intContadorEmpresa = 0
            intContadorFormaDePago = 0
            intTablaSucursalesRegistros = 2

            For Each strRegistroSucursales In objArraySucursales

                intContadorFormaDePago = 0
                intContadorRegistros += 1

                If (intContadorRegistros Mod 2) <> 0 Then
                    strColorRegistroSucursal = "'tdceleste'"
                Else
                    strColorRegistroSucursal = "'tdblanco'"
                End If

                strTablaSucursales.Append("<tr>")
                strTablaSucursales.Append("<td>")
                strTablaSucursales.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
                strTablaSucursales.Append("<tr>")
                strTablaSucursales.Append("<td width='10%'  class=" & strColorRegistroSucursal & ">" & clsCommons.strFormatearDescripcion(strRegistroSucursales(0)) & "</td>")
                strTablaSucursales.Append("<td width='10%'  class=" & strColorRegistroSucursal & ">" & clsCommons.strFormatearDescripcion(strRegistroSucursales(1)) & "</td>")
                strTablaSucursales.Append("<td width='40%'  class=" & strColorRegistroSucursal & ">" & clsCommons.strFormatearDescripcion(strRegistroSucursales(2)) & "</td>")
                strTablaSucursales.Append("<td width='10%'  class=" & strColorRegistroSucursal & ">" & clsCommons.strFormatearDescripcion(strRegistroSucursales(5)) & "</td>")
                strTablaSucursales.Append("<td width='5%'   class=" & strColorRegistroSucursal & "><a href='SucursalEmpresasServiciosEditarSucursal.aspx?strCmd=Editar&intCompaniaId=" & strRegistroSucursales(0) & "&intSucursalId=" & strRegistroSucursales(1) & "&intEmpresaServicioId=" & strRegistroSucursales(3) & "';'")
                strTablaSucursales.Append("class='txaccion'><img src='../static/images/imgNREditar.gif' width='13' height='13' align='absmiddle' alt='Editar sucursal' border='0'></a></td>")
                strTablaSucursales.Append("<td width='5%'   class=" & strColorRegistroSucursal & "><a href='SucursalEmpresasServiciosEditarSucursalEmpresa.aspx?strCmd=Asignar&intCompaniaId=" & strRegistroSucursales(0) & "&intSucursalId=" & strRegistroSucursales(1) & "&intEmpresaServicioId=" & strRegistroSucursales(3) & "';'")
                strTablaSucursales.Append("class='txaccion'><img src='../static/images/icono_detalle.gif' width='13' height='13' align='absmiddle' alt='Editar monto máximo' border='0'></a></td>")
                strTablaSucursales.Append("<td width='5%'   class=" & strColorRegistroSucursal & "><a href='SucursalEmpresasServiciosAsignarEmpresa.aspx?strCmd=Eliminar&intCompaniaId=" & strRegistroSucursales(0) & "&intSucursalId=" & strRegistroSucursales(1) & "&intEmpresaServicioId=" & strRegistroSucursales(3) & "';'")
                strTablaSucursales.Append("class='txaccion'><img src='../static/images/imgNRborrar.gif' width='13' height='13' align='absmiddle' alt='Eliminar' border='0'></a></td>")
                strTablaSucursales.Append("<td width='15%'  align='center' class=" & strColorRegistroSucursal & "><a href='javascript:ActivateRow(" & intTablaSucursalesRegistros.ToString & ")'><img src='../static/images/icono_mas.gif' width='9' height='9' border='0' align='absMiddle' alt = 'Haga clic aquí para ver las formas de pago'></a></td>")
                strTablaSucursales.Append("</tr>")
                strTablaSucursales.Append("</table>")
                strTablaSucursales.Append("</td>")
                strTablaSucursales.Append("</tr>")

                strTablaSucursales.Append("<tr>")
                strTablaSucursales.Append("<td>")
                strTablaSucursales.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
                strTablaSucursales.Append("<tr>")
                strTablaSucursales.Append("<td width='10%'  class=" & strColorRegistroSucursal & ">" & clsCommons.strFormatearDescripcion(strRegistroSucursales(0)) & "</td>")
                strTablaSucursales.Append("<td width='10%'  class=" & strColorRegistroSucursal & ">" & clsCommons.strFormatearDescripcion(strRegistroSucursales(1)) & "</td>")
                strTablaSucursales.Append("<td width='40%'  class=" & strColorRegistroSucursal & ">" & clsCommons.strFormatearDescripcion(strRegistroSucursales(2)) & "</td>")
                strTablaSucursales.Append("<td width='10%'  class=" & strColorRegistroSucursal & ">" & clsCommons.strFormatearDescripcion(strRegistroSucursales(5)) & "</td>")
                strTablaSucursales.Append("<td width='5%'   class=" & strColorRegistroSucursal & "><a href='SucursalEmpresasServiciosEditarSucursal.aspx?strCmd=Editar&intCompaniaId=" & strRegistroSucursales(0) & "&intSucursalId=" & strRegistroSucursales(1) & "&intEmpresaServicioId=" & strRegistroSucursales(3) & "';'")
                strTablaSucursales.Append("class='txaccion'><img src='../static/images/imgNREditar.gif' width='13' height='13' align='absmiddle' alt='Editar sucursal' border='0'></a></td>")
                strTablaSucursales.Append("<td width='5%'   class=" & strColorRegistroSucursal & "><a href='SucursalEmpresasServiciosEditarSucursalEmpresa.aspx?strCmd=Asignar&intCompaniaId=" & strRegistroSucursales(0) & "&intSucursalId=" & strRegistroSucursales(1) & "&intEmpresaServicioId=" & strRegistroSucursales(3) & "';'")
                strTablaSucursales.Append("class='txaccion'><img src='../static/images/icono_detalle.gif' width='13' height='13' align='absmiddle' alt='Editar monto máximo' border='0'></a></td>")
                strTablaSucursales.Append("<td width='5%'   class=" & strColorRegistroSucursal & "><a href='SucursalEmpresasServiciosAsignarEmpresa.aspx?strCmd=Eliminar&intCompaniaId=" & strRegistroSucursales(0) & "&intSucursalId=" & strRegistroSucursales(1) & "&intEmpresaServicioId=" & strRegistroSucursales(3) & "';'")
                strTablaSucursales.Append("class='txaccion'><img src='../static/images/imgNRborrar.gif' width='13' height='13' align='absmiddle' alt='Eliminar' border='0'></a></td>")
                strTablaSucursales.Append("<td width='15%'  align='center' class=" & strColorRegistroSucursal & "><a href='javascript:DeactivateRow(" & intTablaSucursalesRegistros.ToString & ")'><img src='../static/images/icono_menos.gif' width='9' height='9' border='0' align='absMiddle'></a></td>")
                strTablaSucursales.Append("</tr>")
                strTablaSucursales.Append("</table>")
                strTablaSucursales.Append("</td>")
                strTablaSucursales.Append("</tr>")

                strTablaSucursales.Append("<tr>")
                strTablaSucursales.Append("<td valign='top'>")
                strTablaSucursales.Append("<br><span class='txrojobold'><br>&nbsp; " & clsCommons.strFormatearDescripcion(strRegistroSucursales(2)) & "<br><br></span>")
                strTablaSucursales.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0'>")
                strTablaSucursales.Append("<tr>")
                strTablaSucursales.Append("<td valign='top' class='tdenvolventetabla'>")
                strTablaSucursales.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

                strTablaSucursales.Append("<tr class='trtitulos'>")
                strTablaSucursales.Append("<th width='4'   class='rayita'>&nbsp;</th>")
                strTablaSucursales.Append("<th width='100' class='rayita'>Forma de Pago</th>")
                strTablaSucursales.Append("<th width='100' class='rayita'>Monto Máximo</th>")

                strTablaSucursales.Append("</tr>")

                intTablaSucursalesRegistros += 3

                If IsArray(ArregloFormasDePago) AndAlso ArregloFormasDePago.Length > 0 Then

                    For Each strRegistroFormasDePago In ArregloFormasDePago
                        Dim i As Integer

                        If CInt(strRegistroFormasDePago(0).ToString) = CInt(strRegistroSucursales(0).ToString) And _
                           CInt(strRegistroFormasDePago(1).ToString) = CInt(strRegistroSucursales(1).ToString) Then

                            intContadorFormaDePago += 1

                            If (intContadorFormaDePago Mod 2) <> 0 Then
                                strColorRegistroFormaDePago = "'tdceleste'"
                            Else
                                strColorRegistroFormaDePago = "'tdblanco'"
                            End If

                            strTablaSucursales.Append("<tr>")
                            strTablaSucursales.Append("<td width='4'   class=" & strColorRegistroFormaDePago & ">" & intContadorFormaDePago.ToString & "</td>")
                            strTablaSucursales.Append("<td width='100' class=" & strColorRegistroFormaDePago & ">" & clsCommons.strFormatearDescripcion(strRegistroFormasDePago(2)) & "</td>")
                            strTablaSucursales.Append("<td width='100' class=" & strColorRegistroFormaDePago & ">" & clsCommons.strFormatearDescripcion(strRegistroFormasDePago(3)) & "</td>")
                            strTablaSucursales.Append("</tr>")

                        End If

                    Next

                End If

                'Cerrar las tablas.

                strTablaSucursales.Append("</table>")
                strTablaSucursales.Append("</td>")
                strTablaSucursales.Append("</tr>")
                strTablaSucursales.Append("</table>")
                strTablaSucursales.Append("<br>")
                strTablaSucursales.Append("</td>")
                strTablaSucursales.Append("</tr>")

            Next

            strTablaSucursales.Append("</table>")

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

        strRecordBrowser = clsCommons.strGenerateJavascriptString(strTablaSucursales.ToString)

    End Function

    '====================================================================
    ' Name       : strGetRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String
        Dim strIndicadores As String

        If intEmpresaServicioId > 0 Then

            ' Declaramos e inicializamos las constantes locales
            Const intElementsPerPage As Integer = 50
            Const strRecordBrowserName As String = "SucursalEmpresasServiciosAsignarEmpresa"

            ' Declaramos e inicializamos las variables locales
            Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
            Dim astrDataArrayIndicadores As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.strBuscarSucursalesAsignadas(0, 0, intEmpresaServicioId, True, 0.0, CDate("01/01/1900"), "", Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)
            Dim astrDataArray As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.strBuscarSucursalesAsignadasAEmpresa(0, 0, intEmpresaServicioId, True, 0.0, CDate("01/01/1900"), "", Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)
            Dim ArregloFormasDePago As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicioSucursalMonto.strObtenerFormaPagoMontoParaEmpresaServicioSucursal(0, 0, intEmpresaServicioId, True, 0.0, CDate("01/01/1900"), "", Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

            ' Establecemos los párametros adicionales de los números de página
            Dim strQueryString As String = _
                "txtEmpresaServicioId=" & intEmpresaServicioId & _
                "&txtEmpresaServicioNombre=" & Trim(strEmpresaServicioNombre) & _
                "&chkEmpresaServicioActiva=" & blnEmpresaServicioActiva & _
                "&strRBCmd=Asignar"

            ' Agregamos los botones para asignar y borrar sucursales
            Dim strTextToBeReplaced As String = "<span class=""txsubtitulo""><img src=""../static/images/bullet_subtitulos.gif"" width=""17"" height=""11"" align=""absmiddle"">Sucursales asignadas</span>"
            Dim strNewText As String = "<span class=""txsubtitulo""><img src=""../static/images/bullet_subtitulos.gif"" width=""17"" height=""11"" align=""absmiddle"">Sucursales asignadas</span><input name=""cmdAsignarSucursales"" type=""button"" class=""button"" id=""cmdAsignarSucursales"" value=""Asignar sucursales"" language=javascript onclick=""return cmdAsignarSucursales_onclick()""/>&nbsp;&nbsp;<input name=""cmdBorrarTodasSucursales"" type=""submit"" class=""button"" id=""cmdBorrarTodasSucursales"" value=""Borrar todas"" language=javascript onclick=""return cmdBorrarTodasSucursales_onclick()""/><br />"

            strIndicadores = RemoverCuerpo(Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArrayIndicadores, intSelectedPage, intElementsPerPage, strThisPageName & "?" & strQueryString & "&").Replace(strTextToBeReplaced, strNewText))

            ' Generamos La parte de los datos del navegador de registros
            Dim strDatos As String = strRecordBrowser(astrDataArray, ArregloFormasDePago)

            'Juntamos los indicadores y los datos
            strGetRecordBrowserHTML = strIndicadores & " " & strDatos

            Return strGetRecordBrowserHTML

        End If

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Check if the current user can access this page
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        'Guardamos la comision
        fltmComision = GetPageParameter("fltComision", GetPageParameter("fltComision", 0))
        Select Case strCmd

            Case "Agregar"


            Case "Editar"

                'Si el identificador del elemento es valido, mandamos a editar sucursales.
                If intEmpresaServicioId > 0 Then

                    ' Editar Sucursales.
                    Call Response.Redirect("SucursalEmpresasServiciosEditarSucursal.aspx?strCmd=Editar" & "&intEmpresaServicioId=" & intEmpresaServicioId & "&intCompaniaId=" & intCompaniaId & "&intSucursalId=" & intSucursalId)


                End If


            Case "Eliminar"

                ' Si el identificador del elemento es válido, eliminamos las sucursales del cliente
                If intEmpresaServicioId > 0 AndAlso intCompaniaId > 0 AndAlso intSucursalId > 0 Then

                    '' Buscamos el registro a eliminar
                    Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.strBuscarSucursalesAsignadas(intCompaniaId, intSucursalId, intEmpresaServicioId, True, 0.0, CDate("01/01/1900"), "", 0, 0, strConnectionString)

                    '' Si el registro existe
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        ' Eliminamos el registro
                        Call Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.intDesasignarSucursales(intCompaniaId, intSucursalId, intEmpresaServicioId, False, 0.0, CDate("01/01/1900"), strUsuarioNombre, strConnectionString)

                        'Recuperamos la informacion de la empresa
                        ' Obtenemos el elemento
                        Dim aobjElement As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.strBuscarEmpresas(intEmpresaServicioId, strConnectionString)
                        ' Si el elemento fue encontrado
                        If IsNothing(aobjElement) = False AndAlso aobjElement.Length > 0 Then
                            Dim aobjRow As System.Collections.SortedList = DirectCast(aobjElement.GetValue(0), System.Collections.SortedList)
                            ' Recuperamos sus datos
                            intEmpresaServicioId = CInt(aobjRow.Item("intEmpresaServicioId"))
                            strEmpresaServicioNombre = CStr(aobjRow.Item("strEmpresaServicioNombre"))
                            blnEmpresaServicioActiva = CBool(aobjRow.Item("blnEmpresaServicioActiva"))
                        End If

                    End If

                End If

            Case "EliminarSucursales"

                ' Si el identificador del elemento es válido, eliminamos las sucursales de la Encuesta
                If intEmpresaServicioId > 0 Then

                    ' Buscamos los registros a eliminar
                    Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.strBuscarSucursalesAsignadas(0, 0, intEmpresaServicioId, True, 0.0, CDate("01/01/1900"), strUsuarioNombre, 0, 0, strConnectionString)

                    ' Si los registros existen
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        ' Eliminamos los registros
                        Call Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.intDesasignarSucursales(0, 0, intEmpresaServicioId, False, 0.0, CDate("01/01/1900"), strUsuarioNombre, strConnectionString)

                    End If

                End If


            Case "Asignar"

                ' Si el identificador del elemento es válido
                If intEmpresaServicioId > 0 Then

                    ' Obtenemos el elemento
                    Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.strBuscarEmpresas(intEmpresaServicioId, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        Dim aobjRow As System.Collections.SortedList = DirectCast(aobjData.GetValue(0), System.Collections.SortedList)

                        ' Recuperamos sus datos
                        intEmpresaServicioId = CInt(aobjRow.Item("intEmpresaServicioId"))
                        strEmpresaServicioNombre = CStr(aobjRow.Item("strEmpresaServicioNombre"))
                        blnEmpresaServicioActiva = CBool(aobjRow.Item("blnEmpresaServicioActiva"))

                    End If

                End If

            Case Else

                ' Comando inválido, direccionamos al usuario a la página padre
                Call Response.Redirect("SucursalEmpresasServiciosAdministrarEmpresas.aspx")

        End Select

    End Sub

    '====================================================================
    ' Name       : RemoverCuerpo
    ' Description: Quita el cuerpo que viene en un record Browser elaborado por el sistema
    ' Throws     : Ninguna
    ' Input      : Cadena html con un encabezado
    ' Output     : Cadena html sin encabezado
    '====================================================================
    Private Function RemoverCuerpo(ByVal strCadena As String) As String

        Dim strAuxiliar As String
        Dim strIndicadores As String
        Dim intLastIndex As Integer
        Dim intIndex As Integer

        'La cadena del browser viene con un tabla en donde vienen los indicadores.
        ' Necesitamos quedarnos con esta primera tabla y eliminar lo demas.

        ' Primero extraemos los titulos que estan antes de la primera tabla y quitamos un salto de linea
        intIndex = strCadena.IndexOf("</table>")
        strIndicadores = strCadena.Substring(0, intIndex + 8)

        ' Regresamos el resultado
        RemoverCuerpo = strIndicadores

    End Function

End Class
