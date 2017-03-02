Imports Isocraft.Web.Http
Imports System.Text
Imports System.Configuration
Imports System.Collections
Imports Benavides.CC.Data



Public Class VentasPromocionesMonederoAdministrar
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


        ' Initialize class properties
        intOpcPromocionTipo = GetPageParameter("intOpcPromocionTipo", GetPageParameter("optPromocionTipo", 0))
        intOpcPromocionVigencia = GetPageParameter("intOpcPromocionVigencia", GetPageParameter("optPromocionVigencia", 0))
        strPromocionNombre = GetPageParameter("strPromocionNombre", GetPageParameter("optPromocionNombre", ""))
        strInicio = GetPageParameter("strInicio", GetPageParameter("txtInicio", ""))
        strFin = GetPageParameter("strFin", GetPageParameter("txtFin", ""))


    End Sub

#End Region


#Region " Class Private Attributes"

    Const strComitasDobles As String = """"
    Private strmJavascriptWindowOnLoadCommands As String

    Private intmOpcPromocionTipo As Integer
    Private intmOpcPromocionVigencia As Integer
    Private strmPromocionNombre As String
    Private strmInicio As String
    Private strmFin As String

#End Region

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
    ' Throws     : None
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
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
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
    ' Name       : intOpcPromocionTipo
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intOpcPromocionTipo() As Integer
        Get
            Return intmOpcPromocionTipo
        End Get
        Set(ByVal strValue As Integer)
            intmOpcPromocionTipo = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intOpcPromocionVigencia
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intOpcPromocionVigencia() As Integer
        Get
            Return intmOpcPromocionVigencia
        End Get
        Set(ByVal strValue As Integer)
            intmOpcPromocionVigencia = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strPromocionNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : string
    '====================================================================
    Public Property strPromocionNombre() As String
        Get
            Return strmPromocionNombre
        End Get
        Set(ByVal strValue As String)
            strmPromocionNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strInicio
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : string
    '====================================================================
    Public Property strInicio() As String
        Get
            Return strmInicio
        End Get
        Set(ByVal strValue As String)
            strmInicio = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFin
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : string
    '====================================================================
    Public Property strFin() As String
        Get
            Return strmFin
        End Get
        Set(ByVal strValue As String)
            strmFin = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strConsultarPromocionesMonedero
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strConsultarPromocionesMonedero() As String

        Dim htmlResult As String = ""

        Dim strRecordBrowserName As String = "VentasPromocionesMonederoAdministrar"
        Dim maxPerPage As Integer = 25
        Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))

        If intSelectedPage <= 0 Then
            intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
        End If

        Dim dtmInicio As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY("01/01/1900"))
        Dim dtmFin As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY("01/01/1900"))

        If (Len(strInicio) > 1 AndAlso IsDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strInicio))) Then

            dtmInicio = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strInicio))

        End If

        If (Len(strFin) > 1 AndAlso IsDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFin))) Then

            dtmFin = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFin))

        End If

        Dim objDataArrayPromociones As Array = clsPromocionMonedero.strBuscar(intOpcPromocionTipo, intOpcPromocionVigencia, strPromocionNombre, dtmInicio, dtmFin, 0, 0, strConnectionString)

        Dim headers As ArrayList = New ArrayList
        headers.Add("Id.")
        headers.Add("Descripción")
        headers.Add("F.Inicio")
        headers.Add("F.Fin")
        headers.Add("Tipo")
        headers.Add("Estado")
        headers.Add("Suc Asignadas")
        headers.Add("Acciones")

        Dim pkNames As String() = {"intPromocionId", "strPromocionNombre", "dtmPromocionInicio", "dtmPromocionFin", "strTipoPromocion", "strEstadoPromocion"}
        Dim pkIndexes As Integer() = {0, 1, 2, 3, 4, 5}

        Dim columnOrder As Integer() = {0, 1, 2, 3, 4, 5, 6}

        Dim actions As ArrayList = New ArrayList
        actions.Add(New Benavides.CC.Commons.clsActionLink("ModificarEstado", pkNames, pkIndexes, "imgNReditar.gif", "Haga clic aquí para modificar la vigenica y estado de la promoción"))
        actions.Add(New Benavides.CC.Commons.clsActionLink("ModificarDetalle", pkNames, pkIndexes, "ImgNRConfirmar.gif", "Haga clic aquí para modificar el detalle de la promoción"))
        actions.Add(New Benavides.CC.Commons.clsActionLink("ModificarSucursalesFiltro", pkNames, pkIndexes, "imgNRAsignar.gif", "Haga clic aquí para modificar las sucursales asignadas a la promoción"))
        actions.Add(New Benavides.CC.Commons.clsActionLink("ModificarSucursalesArchivo", pkNames, pkIndexes, "imgNRArchivo.gif", "Haga clic aquí para asignar sucursales a la promoción desde un archivo"))

        htmlResult = Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objDataArrayPromociones.Length, intSelectedPage, maxPerPage, "VentasPromocionesMonederoAdministrar.aspx", Nothing)
        htmlResult += Benavides.CC.Commons.clsRecordBrowserNew.displayTable(headers, objDataArrayPromociones, columnOrder, actions, intSelectedPage, maxPerPage, -1)

        Return htmlResult

    End Function



    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

End Class
