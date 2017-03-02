Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert

Public Class SucursalEmpresasServiciosAgregarEmpresa
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

        'Inicializa Propiedades

        intEmpresaServicioId = GetPageParameter("txtEmpresaServicioId", GetPageParameter("intEmpresaServicioId", 0))

        strEmpresaServicioCodigoServicio = GetPageParameter("txtEmpresaServicioCodigoServicio", "")

        strEmpresaServicioNombre = GetPageParameter("txtEmpresaServicioNombre", "")

        fltEmpresaServicioComision = GetPageParameter("txtEmpresaServicioComision", GetPageParameter("fltEmpresaServicioComision", 0.0))

        fltEmpresaServicioComisionCompartida = GetPageParameter("txtEmpresaServicioComisionCompartida", GetPageParameter("fltEmpresaServicioComisionCompartida", 0.0))

        strEmpresaServicioInformacionTicket = GetPageParameter("txtEmpresaServicioInformacionTicket", "")

        blnEmpresaServicioActiva = GetPageParameter("chkEmpresaServicioActiva", False)

        blnEmpresaServicioSolicitarRecaptura = GetPageParameter("chkEmpresaServicioSolicitarRecaptura", False)

        intEmpresaServicioIdAnterior = GetPageParameter("txtEmpresaServicioIdAnterior", GetPageParameter("intEmpresaServicioIdAnterior", 0))


    End Sub

#End Region

#Region " Class Private Attributes"

    Private intmEmpresaServicioId As Integer
    Private strmEmpresaServicioCodigoServicio As String
    Private strmEmpresaServicioNombre As String
    Private fltmEmpresaServicioComision As Double
    Private fltmEmpresaServicioComisionCompartida As Double
    Private strmEmpresaServicioInformacionTicket As String
    Private blnmchkEmpresaServicioActiva As Boolean
    Private blnmchkEmpresaServicioSolicitarRecaptura As Boolean
    Private strmJavascriptWindowOnLoadCommands As String
    Private intmEmpresaServicioIdAnterior As Integer

#End Region

    Public Sub New()

    End Sub

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
    ' Name       : strEmpresaServicioCodigoServicio
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strEmpresaServicioCodigoServicio() As String
        Get
            Return strmEmpresaServicioCodigoServicio
        End Get
        Set(ByVal strValue As String)
            strmEmpresaServicioCodigoServicio = strValue
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
        Set(ByVal strValue As String)
            strmEmpresaServicioNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltEmpresaServicioComision
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Double
    '====================================================================
    Public Property fltEmpresaServicioComision() As Double
        Get
            Return fltmEmpresaServicioComision
        End Get
        Set(ByVal strValue As Double)
            fltmEmpresaServicioComision = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltEmpresaServicioComisionCompartida
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Double
    '====================================================================
    Public Property fltEmpresaServicioComisionCompartida() As Double
        Get
            Return fltmEmpresaServicioComisionCompartida
        End Get
        Set(ByVal strValue As Double)
            fltmEmpresaServicioComisionCompartida = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpresaServicioInformacionTicket
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strEmpresaServicioInformacionTicket() As String
        Get
            Return strmEmpresaServicioInformacionTicket
        End Get
        Set(ByVal dtmValue As String)
            strmEmpresaServicioInformacionTicket = dtmValue
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
    ' Name       : blnEmpresaServicioSolicitarRecaptura
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnEmpresaServicioSolicitarRecaptura() As Boolean
        Get
            Return blnmchkEmpresaServicioSolicitarRecaptura
        End Get
        Set(ByVal blnValue As Boolean)

            blnmchkEmpresaServicioSolicitarRecaptura = blnValue
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Execute the selected command
        Select Case strCmd

            Case "Salvar"

                Dim blnRedirectToParentPage As Boolean

                If (intEmpresaServicioIdAnterior = 0) Then

                    ' Agregamos la nueva empresa
                    intEmpresaServicioId = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.intAgregarEmpresa(strEmpresaServicioCodigoServicio, strEmpresaServicioNombre, fltEmpresaServicioComision, fltEmpresaServicioComisionCompartida, strEmpresaServicioInformacionTicket, blnEmpresaServicioActiva, blnEmpresaServicioSolicitarRecaptura, CDate("01/01/1900"), strUsuarioNombre, strConnectionString)

                Else

                    'Actualizamos la información de la empresa
                    intEmpresaServicioId = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.intActualizarEmpresa(intEmpresaServicioId, strEmpresaServicioCodigoServicio, strEmpresaServicioNombre, fltEmpresaServicioComision, fltEmpresaServicioComisionCompartida, strEmpresaServicioInformacionTicket, blnEmpresaServicioActiva, blnEmpresaServicioSolicitarRecaptura, CDate("01/01/1900"), strUsuarioNombre, intEmpresaServicioIdAnterior, strConnectionString)
                End If

                ' Regresamos al usuario al listado de elementos
                If blnRedirectToParentPage = True Then
                    strJavascriptWindowOnLoadCommands &= " window.location.href = ""SucursalEmpresasServiciosAdministrarEmpresas.aspx"";"
                Else
                    Response.Redirect("SucursalEmpresasServiciosAdministrarEmpresas.aspx", True)
                End If

            Case "Editar"

                ' Si el identificador del elemento es válido
                If intEmpresaServicioId > 0 Then

                    'Recuperar el intEmpresaServicioIdAnterior
                    intEmpresaServicioIdAnterior = GetPageParameter("intEmpresaServicioId", GetPageParameter("intEmpresaServicioId", 0))

                    ' Obtenemos el elemento
                    Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.strBuscarEmpresas(intEmpresaServicioId, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        Dim aobjRow As System.Collections.SortedList = DirectCast(aobjData.GetValue(0), System.Collections.SortedList)

                        ' Recuperamos sus datos
                        intEmpresaServicioId = CInt(aobjRow.Item("intEmpresaServicioId"))
                        strEmpresaServicioNombre = CStr(aobjRow.Item("strEmpresaServicioNombre"))
                        blnEmpresaServicioActiva = CBool(aobjRow.Item("blnEmpresaServicioActiva"))
                        blnEmpresaServicioSolicitarRecaptura = CBool(aobjRow.Item("blnEmpresaServicioSolicitarRecaptura"))

                    End If

                End If

        End Select
    End Sub

End Class
