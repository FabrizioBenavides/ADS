Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert

Public Class SucursalTipoServicioVirtualAgregarEditar
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

        intTipoServicioVirtualId = GetPageParameter("txtTipoServicioId", GetPageParameter("intTipoServicioId", 0))

        strTipoServicioVirtualDescripcion = GetPageParameter("txtTipoServicioVirtualDescripcion", "")

        blnTipoServicioVirtualAplicaDevolucion = GetPageParameter("chkAplicarDevolucion", False)

        'JPMB blnTipoServicioVirtualMuestraenPuntodeVenta 
        blnTipoServicioVirtualMuestraenPuntodeVenta = GetPageParameter("chkMuestaenPuntodeVenta", False)

    End Sub

#End Region

#Region " Class Private Attributes"

    Private intmTipoServicioVirtualId As Integer
    Private strmTipoServicioVirtualDescripcion As String
    Private strmJavascriptWindowOnLoadCommands As String
    Private intmTipoServicioVirtualIdAnterior As Integer
    Private blnmTipoServicioVirtualAplicaDevolucion As Boolean
    ' StkmtyPPSV JPMB ... 26 Noviembre 2013 bugs de Administracion de la Pagina 
    Private blnmTipoServicioVirtualMuestraenPuntodeVenta As Boolean

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
    ' Name       : intTipoServicioVirtualId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intTipoServicioVirtualId() As Integer
        Get
            Return intmTipoServicioVirtualId
        End Get
        Set(ByVal intValue As Integer)
            intmTipoServicioVirtualId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoServicioVirtualDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTipoServicioVirtualDescripcion() As String
        Get
            Return strmTipoServicioVirtualDescripcion
        End Get
        Set(ByVal strValue As String)
            strmTipoServicioVirtualDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnAplicaDevolucion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnTipoServicioVirtualAplicaDevolucion() As Boolean
        Get
            If blnmTipoServicioVirtualAplicaDevolucion = Nothing Then
                blnmTipoServicioVirtualAplicaDevolucion = CBool(isocraft.commons.clsWeb.strGetPageParameter("chkAplicaDevolucion", "0"))
            End If
            Return blnmTipoServicioVirtualAplicaDevolucion
        End Get
        Set(ByVal blnValue As Boolean)
            blnmTipoServicioVirtualAplicaDevolucion = blnValue
        End Set
    End Property
    '====================================================================
    ' Name       : blnTipoServicioVirtualMuestraenPuntodeVenta
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnTipoServicioVirtualMuestraenPuntodeVenta() As Boolean
        Get
            If blnmTipoServicioVirtualMuestraenPuntodeVenta = Nothing Then
                blnmTipoServicioVirtualMuestraenPuntodeVenta = CBool(isocraft.commons.clsWeb.strGetPageParameter("chkMuestaenPuntodeVenta", "0"))
            End If
            Return blnmTipoServicioVirtualMuestraenPuntodeVenta
        End Get
        Set(ByVal blnValue As Boolean)
            blnmTipoServicioVirtualMuestraenPuntodeVenta = blnValue
        End Set
    End Property


    ''====================================================================
    '' Name       : intEmpresaServicioIdAnterior
    '' Description: Value of a HTML form field
    '' Accessor   : Read / Write
    '' Output     : Integer
    ''====================================================================
    'Public Property intTipoServicioVirtualIdAnterior() As Integer
    '    Get
    '        Return intmTipoServicioVirtualIdAnterior
    '    End Get
    '    Set(ByVal intValue As Integer)
    '        intmTipoServicioVirtualIdAnterior = intValue
    '    End Set
    'End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Execute the selected command
        Select Case strCmd

            Case "Salvar"

                Dim blnRedirectToParentPage As Boolean

                'Guardamos la informacion
                Benavides.CC.Business.clsConcentrador.clsSucursal.clsTipoServicioVirtual.intGuardar(intTipoServicioVirtualId, strTipoServicioVirtualDescripcion, blnTipoServicioVirtualAplicaDevolucion, blnTipoServicioVirtualMuestraenPuntodeVenta, strUsuarioNombre, strConnectionString)

                ' Regresamos al usuario al listado de elementos
                If blnRedirectToParentPage = True Then
                    strJavascriptWindowOnLoadCommands &= " window.location.href = ""SucursalTipoServicioVirtual.aspx"";"
                Else
                    Response.Redirect("SucursalTipoServicioVirtual.aspx", True)
                End If

            Case "Editar"

                ' Si el identificador del elemento es válido
                If intTipoServicioVirtualId > 0 Then

                    'Recuperar el intEmpresaServicioIdAnterior
                    'intTipoServicioVirtualIdAnterior = GetPageParameter("intTipoServicioId", 0)

                    ' Obtenemos el elemento
                    Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsTipoServicioVirtual.strBuscar(intTipoServicioVirtualId, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        'Dim aobjRow As System.Collections.SortedList = DirectCast(aobjData.GetValue(0), System.Collections.SortedList)
                        Dim aobjRow As System.Array = DirectCast(aobjData.GetValue(0), System.Array)

                        ' Recuperamos sus datos
                        intTipoServicioVirtualId = CInt(aobjRow.GetValue(0))
                        strTipoServicioVirtualDescripcion = CStr(aobjRow.GetValue(1))
                        blnTipoServicioVirtualAplicaDevolucion = CBool(aobjRow.GetValue(2))
                        blnTipoServicioVirtualMuestraenPuntodeVenta = CBool(aobjRow.GetValue(3))

                    End If

                End If

        End Select
    End Sub

End Class
