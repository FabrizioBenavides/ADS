Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert

Public Class SucursalEmpresasServiciosAsignarAutorizador
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

        'blnEmpresaServicioSolicitarRecaptura = GetPageParameter("chkEmpresaServicioSolicitarRecaptura", False)

        intEmpresaServicioIdAnterior = GetPageParameter("txtEmpresaServicioIdAnterior", GetPageParameter("intEmpresaServicioIdAnterior", 0))


    End Sub

#End Region

#Region " Class Private Attributes"

    Private intmEmpresaServicioId As Integer
    Private intmAutorizadorId As Integer
    Private strmEmpresaServicioCodigoServicio As String
    Private strmEmpresaServicioNombre As String
    Private fltmEmpresaServicioComision As Double
    Private fltmEmpresaServicioComisionCompartida As Double
    Private strmEmpresaServicioInformacionTicket As String
    Private blnmchkEmpresaServicioActiva As Boolean
    Private blnmchkEmpresaServicioAutorizadorActivo As Boolean
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmEmpresaServicioAutorizadorMensaje As String
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
    ' Name       : intAutorizadorId
    ' Description: Identificador de la forma de pago
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intAutorizadorId() As Integer
        Get
            If intmAutorizadorId = 0 Then
                intmAutorizadorId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboAutorizador", isocraft.commons.clsWeb.strGetPageParameter("intAutorizadorId", "0")))
            End If
            Return intmAutorizadorId
        End Get
    End Property
    '====================================================================
    ' Name       : strEmpresaServicioCodigoServicio
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strEmpresaServicioCodigoServicio() As String
        Get
            strEmpresaServicioCodigoServicio = Request.Form("txtCodigoServicio")
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
            'fltmEmpresaServicioComisionCompartida = CDbl(Request.Form("txtComisionCompartida"))
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
    Public Property blnEmpresaServicioAutorizadorActivo() As Boolean
        Get
            'If (Request.Form("chkAutorizadorActivo") <> Nothing) Then
            '    blnmchkEmpresaServicioAutorizadorActivo = CBool(Request.Form("chkAutorizadorActivo"))
            'Else
            '    blnmchkEmpresaServicioAutorizadorActivo = False
            'End If
            Return blnmchkEmpresaServicioAutorizadorActivo
        End Get
        Set(ByVal blnValue As Boolean)
            blnmchkEmpresaServicioAutorizadorActivo = blnValue
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
    ' Name       : strEmpresaServicioAutorizadorMensaje 
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strEmpresaServicioAutorizadorMensaje() As String
        Get
            Return strmEmpresaServicioAutorizadorMensaje
        End Get
        Set(ByVal strValue As String)
            strmEmpresaServicioAutorizadorMensaje = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strLlenarAutorizadorComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboAutorizador"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarAutorizadorComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboAutorizador", intAutorizadorId, Benavides.CC.Business.clsConcentrador.clsSucursal.clsAutorizador.strBuscarAutorizadores(strConnectionString), 0, 1, 1)
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
        Const intElementsPerPage As Integer = 0
        Const strRecordBrowserName As String = "SucursalEmpresasServiciosAsignarAutorizador"


        ' Declaramos e inicializamos las variables locales

        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        'Dim astrDataArray As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.strBuscarEmpresas(0, "", "", 0, 0, "", False, False, CDate("01/01/1900"), "", Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

        Dim astrDataArray As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicioAutorizador.strBuscarAutorizadoresAsignados(intEmpresaServicioId, strConnectionString)

        Dim astrDataRow As Array

        ' Generamos el navegador de registros

        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?")

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Dim intResultado As Integer
        Dim strAutorizador() As String
        Dim blnActualizar As Boolean
        Dim blnInsertar As Boolean
        Dim blnActivo As Boolean

        Dim strCodigoServicio As String
        Dim fltComisionCompartida As Double
        Dim blnAutorizadorActivo As Boolean


        'Inicializacion de variables
        blnActualizar = False
        blnInsertar = True
        blnActivo = False

        strCodigoServicio = Request.Form("txtCodigoServicio")
        fltComisionCompartida = CDbl(Request.Form("txtComisionCompartida"))
        If (Request.Form("chkAutorizadorActivo") <> Nothing) Then
            blnAutorizadorActivo = CBool(Request.Form("chkAutorizadorActivo"))
        Else
            blnAutorizadorActivo = False
        End If

        ' Execute the selected command
        Select Case strCmd

            Case "Salvar"

                ' Obtenemos el elemento
                Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicioAutorizador.strBuscarAutorizadoresAsignados(intEmpresaServicioId, strConnectionString)

                If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                    For Each strAutorizador In aobjData

                        If CInt(strAutorizador(0)) = intAutorizadorId Then

                            blnActualizar = True
                            blnInsertar = False
                            blnActivo = CBool(strAutorizador(4))

                        End If
                    Next

                    ' Si es insertar y se desea insertar activo
                    'If Not blnActualizar And blnEmpresaServicioAutorizadorActivo Then
                    If Not blnActualizar And blnAutorizadorActivo Then

                        For Each strAutorizador In aobjData

                            If CBool(strAutorizador(4)) = True Then

                                blnInsertar = False

                            End If

                        Next

                        'ElseIf blnActualizar And blnEmpresaServicioAutorizadorActivo And Not blnActivo Then
                    ElseIf blnActualizar And blnAutorizadorActivo And Not blnActivo Then

                        For Each strAutorizador In aobjData

                            If CInt(strAutorizador(0)) <> intAutorizadorId And CBool(strAutorizador(4)) = True Then

                                blnActualizar = False

                            End If

                        Next

                    End If

                End If

                If blnActualizar Then

                    ' Si el elemento fue encontrado hacemos una actualizacion
                    'intResultado = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicioAutorizador.intActualizarAutorizador(intEmpresaServicioId, intAutorizadorId, strEmpresaServicioCodigoServicio, fltEmpresaServicioComisionCompartida, strEmpresaServicioInformacionTicket, blnEmpresaServicioAutorizadorActivo, CDate("01/01/1900"), strUsuarioNombre, strConnectionString)
                    intResultado = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicioAutorizador.intActualizarAutorizador(intEmpresaServicioId, intAutorizadorId, strCodigoServicio, fltComisionCompartida, strEmpresaServicioInformacionTicket, blnAutorizadorActivo, CDate("01/01/1900"), strUsuarioNombre, strConnectionString)

                    Call Response.Redirect("SucursalEmpresasServiciosAdministrarEmpresas.aspx")

                ElseIf blnInsertar Then

                    'Agregar la relacion entre el autorizador y la empresa de serivcio
                    'intResultado = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicioAutorizador.intAsignarAutorizador(intEmpresaServicioId, intAutorizadorId, strEmpresaServicioCodigoServicio, fltEmpresaServicioComisionCompartida, strEmpresaServicioInformacionTicket, blnEmpresaServicioAutorizadorActivo, CDate("01/01/1900"), strUsuarioNombre, strConnectionString)
                    intResultado = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicioAutorizador.intAsignarAutorizador(intEmpresaServicioId, intAutorizadorId, strCodigoServicio, fltComisionCompartida, strEmpresaServicioInformacionTicket, blnAutorizadorActivo, CDate("01/01/1900"), strUsuarioNombre, strConnectionString)

                    Call Response.Redirect("SucursalEmpresasServiciosAdministrarEmpresas.aspx")

                Else
                    strEmpresaServicioCodigoServicio = strCodigoServicio
                    fltEmpresaServicioComisionCompartida = fltComisionCompartida
                    blnEmpresaServicioAutorizadorActivo = blnAutorizadorActivo
                    strEmpresaServicioAutorizadorMensaje = "Error"

                End If

            Case "Asignar"

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

                    End If

                End If

                'Si hay un autorizador seleccionado se recogen sus datos
                If intAutorizadorId > 0 Then

                    ' Obtenemos el elemento
                    Dim aobjDataAutorizador As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicioAutorizador.strBuscarEmpresaServicioAutorizador(intEmpresaServicioId, intAutorizadorId, strConnectionString)
                    ' Si el elemento fue encontrado
                    If IsNothing(aobjDataAutorizador) = False AndAlso aobjDataAutorizador.Length > 0 Then

                        Dim aobjRowAutorizador As System.Collections.SortedList = DirectCast(aobjDataAutorizador.GetValue(0), System.Collections.SortedList)

                        ' Recuperamos sus datos
                        strEmpresaServicioCodigoServicio = CStr(aobjRowAutorizador.Item("strEmpresaServicioAutorizadorCodigoServicio"))
                        fltEmpresaServicioComisionCompartida = CDbl(aobjRowAutorizador.Item("fltEmpresaServicioAutorizadorComisionCompartida"))
                        strEmpresaServicioInformacionTicket = CStr(aobjRowAutorizador.Item("strEmpresaServicioAutorizadorInformacionTicket"))
                        blnEmpresaServicioAutorizadorActivo = CBool(aobjRowAutorizador.Item("blnEmpresaServicioAutorizadorActiva"))

                    End If
                End If

        End Select
    End Sub

End Class
