Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert
Imports System.Text
Imports System.Collections
Imports Benavides.POSAdmin.Commons

'====================================================================
' Class         : SucursalAsignacionDeArticuloDPDineroExpress
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Sucursal
' Copyright     : 2013 All rights reserved.
' Company       : Softtek
' Author        : Juan Pablo Martinez Bautista
' Version       : 1.0
' Last Modified : 10/09/2013
' Modified by   : 
'====================================================================
Public Class SucursalAsignacionDeArticuloDPDineroExpress
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

        intTipoOperacionDEXId = GetPageParameter("intTipoOperacionDEXId", GetPageParameter("txtTipoOperacionDEXId", 0))

        strTipoOperacionDEXNombreId = GetPageParameter("txtTipoOperacionDEXNombreId", "")

        'JPMB 11 Junio 2013  
        IntArticuloServicioPromocionesArticuloId = GetPageParameter("IntArticuloServicioPromocionesArticuloId", GetPageParameter("txtIntArticuloServicioPromocionesArticuloId", 0))

        strJavascriptWindowOnLoadCommands = ""

    End Sub

#End Region

#Region " Class Private Attributes"

    Private intmSelectedPage As Integer
    Private strmJavascriptWindowOnLoadCommands As String
    Private intmTipoOperacionDEXId As Integer
    Private strmTipoOperacionDEXNombreId As String
    'JPMB 10 junio 2013
    Private IntmArticuloServicioPromocionesArticuloId As Integer
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
    Public Property intTipoOperacionDEXId() As Integer
        Get
            Return intmTipoOperacionDEXId
        End Get
        Set(ByVal intValue As Integer)
            intmTipoOperacionDEXId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpresaServicioNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTipoOperacionDEXNombreId() As String
        Get
            Return strmTipoOperacionDEXNombreId
        End Get
        Set(ByVal intValue As String)
            strmTipoOperacionDEXNombreId = intValue
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


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        ' Check if the current user can access this page
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        'Guardamos la comision
        Select Case strCmd

            Case "Asignar"

                ' Si el identificador del elemento es válido
                If intTipoOperacionDEXId > 0 Then

                    ' Obtenemos el elemento
                    Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsTipoOperacionDEX.strBuscarTipoOperacionDEX(intTipoOperacionDEXId, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        Dim objRow As System.Array = DirectCast(aobjData.GetValue(0), System.Array)
                        'Dim astrRow As SortedList = DirectCast(aobjData.GetValue(0), SortedList)
                        ' Recuperamos sus datos
                        intTipoOperacionDEXId = CInt(objRow.GetValue(0))
                        strTipoOperacionDEXNombreId = CStr(objRow.GetValue(1))
                        IntArticuloServicioPromocionesArticuloId = CInt(objRow.GetValue(2))


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
                        IntElementos = Benavides.CC.Business.clsConcentrador.clsSucursal.clsTipoOperacionDEX.IntActualizarAgregarTblTipoOperacionDEX(intTipoOperacionDEXId, "", "", "", _
                                                                                                                            IntArticuloServicioPromocionesArticuloId, _
                                                                                                                            strConnectionString)

                        Response.Write("<script language='javascript'>alert('Los Datos Se Guardaron Correctamente.');</script>")
                    Else

                        Response.Write("<script language='javascript'>alert('Articulo no existente, por favor intente de nuevo.');</script>")

                    End If
                Else
                    Response.Write("<script language='javascript'>alert('Articulo Id No Valido');</script>")
                End If
            Case Else

                ' Comando inválido, direccionamos al usuario a la página padre
                Call Response.Redirect("SucursalEmpresasServiciosAdministrarEmpresas.aspx")

        End Select

    End Sub

End Class
