Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports System.Text
Imports System.Collections
Imports System.Configuration
Imports System.Globalization
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business

Public Class ifrVentasMovimientosAntibioticos
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

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

    End Sub

#End Region

#Region " Class Private Attributes"

    Const strComitasDobles As String = """"

#End Region

    '====================================================================
    ' Name       : intCompaniaId
    ' Description: Valor de la Compañia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCompaniaId() As Integer
        Get
            Return CInt(clsCommons.strReadCookie("intCompaniaId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Valor de la Sucursal
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intSucursalId() As Integer
        Get
            Return CInt(clsCommons.strReadCookie("intSucursalId", "0", Request, Server))
        End Get
    End Property


    '====================================================================
    ' Name       : strSucursalNombre
    ' Description: Nombre de la Sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalNombre() As String
        Get
            Return clsCommons.strReadCookie("strSucursalNombre", "0", Request, Server)
        End Get
    End Property


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
    ' Name       : strSelected
    ' Description: ARTICULO (S) A CONSULTAR
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strSelected() As String
        Get
            Return Request("strSelected")
        End Get
    End Property


    '====================================================================
    ' Name       : strTipoMovimientoAntibioticoId
    ' Description:  
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strTipoMovimientoAntibioticoId() As String
        Get
            If Len(Request("strTipoMovimientoAntibioticoId")) > 0 Then
                Return Request("strTipoMovimientoAntibioticoId")
            Else
                Return ""
            End If
        End Get
    End Property
    '
    '====================================================================
    ' Name       : strIndicadorMovimiento
    ' Description:  
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strIndicadorMovimiento() As String
        Get
            If Len(Request("strIndicadorMovimiento")) > 0 Then
                Return Request("strIndicadorMovimiento")
            Else
                Return ""
            End If
        End Get
    End Property


    '====================================================================
    ' Name       : strFechaInicial
    ' Description:  
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strFechaInicial() As String
        Get
            If Len(Request("strFechaInicial")) > 0 Then
                Return Request("strFechaInicial")
            Else
                Return ""
            End If
        End Get
    End Property


    '====================================================================
    ' Name       : strFechaFinal
    ' Description:  
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strFechaFinal() As String
        Get
            If Len(Request("strFechaFinal")) > 0 Then
                Return Request("strFechaFinal")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strOrdenId
    ' Description:  
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strOrdenId() As String
        Get
            If Len(Request("strOrdenId")) > 0 Then
                Return Request("strOrdenId")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strGetRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros de movimientos
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String

        ' Declaramos e inicializamos las variables locales
        Dim objArrayArticulosSeleccionados As Array = Nothing
        Dim strReturn As String



        If strSelected = "TODOS" Then

            ' Generamos el navegador de registros
            strReturn = strRecordBrowser(Nothing)

        ElseIf Len(strSelected) > 0 Then
            ' Si hay articulos seleccionados

            objArrayArticulosSeleccionados = strSelected.Split(","c)

            ' Generamos el navegador de registros
            strReturn = strRecordBrowser(objArrayArticulosSeleccionados)

        End If

        Return strReturn

    End Function

    '====================================================================
    ' Name       : strRecordBrowser
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowser(ByVal objArrayArticulos As Array) As String

        
        Const strRecordBrowserName As String = "VentasMovimientosAntibioticos"

        Const intElementsPerPage As Integer = 50
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)

        If (IsArray(objArrayArticulos) AndAlso objArrayArticulos.Length > 0) Or strSelected = "TODOS" Then
            Dim strTagAcutal As String = "<td align=""right"" class=""tdpadleft5"" id=""BotonDelNavegador""></td>"
            Dim strTagNuevo As String = "<td align=""left"" class=""tdpadleft5"" ><input name=""cmdImprimir"" type=""button"" class=""boton"" value=""Imprimir"" language=""javascript"" onclick=""return cmdImprimir_onclick()"">&nbsp</td>"

            Dim strFiltroArt As String
            Dim aobjDataArray As Array = Benavides.CC.Business.clsConcentrador.clsAntibioticos.strBuscar(intCompaniaId, intSucursalId, strSelected, strTipoMovimientoAntibioticoId, strIndicadorMovimiento, CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaInicial)), CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaFinal)), strOrdenId, intSelectedPage, intElementsPerPage, strConnectionString)
            Dim strTargetURL As String = strThisPageName & "?strSelected=" & strSelected & "&strTipoMovimientoAntibioticoId=" & strTipoMovimientoAntibioticoId & "&strIndicadorMovimiento=" & strIndicadorMovimiento & "&strOrdenId=" & strOrdenId & "&strFechaInicial=" & strFechaInicial & "&strFechaFinal=" & strFechaFinal & "&"

            Return Replace(Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, aobjDataArray, intSelectedPage, intElementsPerPage, strTargetURL), strTagAcutal, strTagNuevo)

        End If


    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

End Class
