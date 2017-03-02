Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert
Imports System.Text
Imports System.Collections
Imports Benavides.POSAdmin.Commons

'====================================================================
' Class         : SucursalAsignacionDeArticuloDPEmpresasServicios
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Sucursal
' Copyright     : 2013 All rights reserved.
' Company       : Softtek
' Author        : Eloy Barreras 
' Version       : 1.0
' Last Modified : 28/06/2013
' Modified by   : 
'====================================================================

Public Class SucursalAsignacionDeArticuloDPEmpresasServicios
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

        strEmpresaServicioCodigoServicio = GetPageParameter("txtEmpresaServicioCodigoServicio", "")

        'JPMB 11 Junio 2013  
        IntArticuloServicioPromocionesArticuloId = GetPageParameter("IntArticuloServicioPromocionesArticuloId", GetPageParameter("txtIntArticuloServicioPromocionesArticuloId", 0))

        strJavascriptWindowOnLoadCommands = ""

    End Sub

#End Region

#Region " Class Private Attributes"

    Private intmSelectedPage As Integer
    Private strmJavascriptWindowOnLoadCommands As String
    Private intmEmpresaServicioId As Integer
    Private strmEmpresaServicioNombre As String
    Private strmEmpresaServicioCodigoServicio As String
    'JPMB 10 junio 2013
    Private IntmArticuloServicioPromocionesArticuloId As Integer
    Private intmArticuloId As Integer
    Private strmtxtArticuloEncontrado As String
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
    ' Description: Genera la fecha y hora de la p�gina
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
    ' Name       : strEmpresaServicioCodigoServicio
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    ' Date       : 06/06/2013 EBCV
    '====================================================================
    Public Property strEmpresaServicioCodigoServicio() As String
        Get
            Return strmEmpresaServicioCodigoServicio
        End Get
        Set(ByVal intValue As String)
            strmEmpresaServicioCodigoServicio = intValue
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

        Dim strTablaSucursales As New StringBuilder
        
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

            ' Establecemos los p�rametros adicionales de los n�meros de p�gina
            Dim strQueryString As String = _
                "txtEmpresaServicioId=" & intEmpresaServicioId & _
                "&txtEmpresaServicioNombre=" & Trim(strEmpresaServicioNombre) & _
                "&txtEmpresaServicioCodigoServicio=" & Trim(strEmpresaServicioCodigoServicio) & _
                "&strRBCmd=Asignar"

            ' Agregamos los botones para asignar y borrar sucursales
            Dim strTextToBeReplaced As String = "<span class=""txsubtitulo""><img src=""../static/images/bullet_subtitulos.gif"" width=""17"" height=""11"" align=""absmiddle"">Sucursales asignadas</span>"
            Dim strNewText As String = "<span class=""txsubtitulo""><img src=""../static/images/bullet_subtitulos.gif"" width=""17"" height=""11"" align=""absmiddle"">Sucursales asignadas</span><input name=""cmdAsignarSucursales"" type=""button"" class=""button"" id=""cmdAsignarSucursales"" value=""Asignar sucursales"" language=javascript onclick=""return cmdAsignarSucursales_onclick()""/>&nbsp;&nbsp;<input name=""cmdBorrarTodasSucursales"" type=""submit"" class=""button"" id=""cmdBorrarTodasSucursales"" value=""Borrar todas"" language=javascript onclick=""return cmdBorrarTodasSucursales_onclick()""/><br />"

            ' Generamos La parte de los datos del navegador de registros          
            Dim strDatos As String = strRecordBrowser(astrDataArray, ArregloFormasDePago)

            'Juntamos los indicadores y los datos
            strGetRecordBrowserHTML = strIndicadores & " " & strDatos

            Return strGetRecordBrowserHTML

        End If

    End Function

    '====================================================================
    ' Name       : IntArticuloServicioPromocionesArticuloId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer JPMB
    '====================================================================
    Public Property IntArticuloServicioPromocionesArticuloId() As Integer
        Get
            Return IntmArticuloServicioPromocionesArticuloId
        End Get
        Set(ByVal intValue As Integer)
            IntmArticuloServicioPromocionesArticuloId = intValue
        End Set
    End Property
    '====================================================================
    ' Name       : intArticuloId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intArticuloId() As Integer
        Get
            Return intmArticuloId
        End Get
        Set(ByVal intValue As Integer)
            intmArticuloId = intValue
        End Set
    End Property
    '====================================================================
    ' Name       : strtxtArticuloEncontrado
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtArticuloEncontrado() As String
        Get
            Return strmtxtArticuloEncontrado
        End Get
        Set(ByVal strValue As String)
            strmtxtArticuloEncontrado = strValue
        End Set
    End Property

	
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Check if the current user can access this page
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        'Guardamos la comision
        Select Case strCmd

            Case "Asignar"

                ' Si el identificador del elemento es v�lido
                If intEmpresaServicioId > 0 Then

                    ' Obtenemos el elemento
                    Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.strBuscarEmpresas(intEmpresaServicioId, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        Dim aobjRow As System.Collections.SortedList = DirectCast(aobjData.GetValue(0), System.Collections.SortedList)

                        ' Recuperamos sus datos
                        intEmpresaServicioId = CInt(aobjRow.Item("intEmpresaServicioId"))
                        strEmpresaServicioNombre = CStr(aobjRow.Item("strEmpresaServicioNombre"))
                        strEmpresaServicioCodigoServicio = CStr(aobjRow.Item("strEmpresaServicioCodigoServicio"))

                        
                    End If

                    'Obtenemos Los Elementos de La Tabla de  tblArticuloServicioPromociones

                    Dim objeData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clstblArticuloServicioPromociones.strBuscarArticuloIdServicioPromociones(intEmpresaServicioId, 0, strEmpresaServicioCodigoServicio, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(objeData) = False AndAlso objeData.Length > 0 Then

                        Dim objeRow As System.Collections.SortedList = DirectCast(objeData.GetValue(0), System.Collections.SortedList)

                        ' Recuperamos sus datos
                        IntArticuloServicioPromocionesArticuloId = CInt(objeRow.Item("intArticuloId"))

                    End If

                End If

            Case "Guardar"

                'Regresa el Numero de Elementos Guardados
                Dim IntElementos As Integer
                Dim IntValidaArticuloId As Integer
                'Consultamos si existe Articulo Id en tblArticulos y tblClasificacionArticulo
                IntValidaArticuloId = 0
                'If IntArticuloServicioPromocionesArticuloId = 0 Then
                If IntArticuloServicioPromocionesArticuloId > 0 Then

                    IntValidaArticuloId = Benavides.CC.Business.clsConcentrador.clsSucursal.clstblArticuloServicioPromociones.IntValidarArticuloServicioVirtual(IntArticuloServicioPromocionesArticuloId, _
                                                                                                                        strConnectionString)
                    If IntValidaArticuloId > 0 Then
                        IntElementos = 0
                        'Mandamos Los Datos Para el Prceso de Guardado
                        IntElementos = Benavides.CC.Business.clsConcentrador.clsSucursal.clstblArticuloServicioPromociones.IntAgregarArticuloIdEmpresaServicioPromociones(0, _
                                                                                                                            intEmpresaServicioId, _
                                                                                                                            strEmpresaServicioCodigoServicio, _
                                                                                                                            IntArticuloServicioPromocionesArticuloId, _
                                                                                                                            strUsuarioNombre, _
                                                                                                                            strConnectionString)

                        Response.Write("<script language='javascript'>alert('Los Datos Se Guardaron Correctamente.');</script>")
                    Else

                        Response.Write("<script language='javascript'>alert('Articulo no existente, por favor intente de nuevo.');</script>")

                    End If
                Else
                    Response.Write("<script language='javascript'>alert('Articulo Id No Valido');</script>")
                End If
            Case Else

                    ' Comando inv�lido, direccionamos al usuario a la p�gina padre
                    Call Response.Redirect("SucursalEmpresasServiciosAdministrarEmpresas.aspx")

        End Select

    End Sub

End Class
