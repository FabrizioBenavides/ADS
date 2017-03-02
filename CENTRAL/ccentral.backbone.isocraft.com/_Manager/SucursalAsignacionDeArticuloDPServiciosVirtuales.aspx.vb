Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert

'====================================================================
' Class         : SucursalAsignacionDeArticuloDPServiciosVirtuales
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Sucursal
' Copyright     : 2013 All rights reserved.
' Company       : Softtek
' Author        : Eloy Barreras
' Version       : 1.0
' Last Modified : 28/06/2013 
' Modified by   : 
'====================================================================

Public Class SucursalAsignacionDeArticuloDPServiciosVirtuales
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
        intTipoServicioVirtualId = GetPageParameter("intTipoServicioId", 0)
        intServicioVirtualId = CStr(GetPageParameter("intServicioID", 0))

        'JPMB 
        IntArticuloServicioPromocionesArticuloId = GetPageParameter("IntArticuloServicioPromocionesArticuloId", GetPageParameter("txtIntArticuloServicioPromocionesArticuloId", 0))
        txtintServicioVirtualId = CStr(GetPageParameter("txtintServicioVirtualId", GetPageParameter("txtintServicioVirtualId", 0)))
        txtintTipoServicioVirtualId = GetPageParameter("txtintTipoServicioVirtualId", GetPageParameter("intTipoServicioVirtualId", 0))

    End Sub

#End Region

#Region " Class Private Attributes"

    Private intmTipoServicioVirtualId As Integer
    Private strmTipoServicioVirtualDescripcion As String
    Private intmServicioVirtualId As String
    Private intmArticuloId As Integer
    Private strmServicioVirtualCodigoProducto As String
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmServicioVirtualDescripcion As String


    'JPMB 11 junio 2013
    Private IntmArticuloServicioPromocionesArticuloId As Integer
    Private txtintmServicioVirtualId As String
    Private txtintmTipoServicioVirtualId As Integer

    'EBCV 21 Junio 2013
    'Private IntmValidaArticuloId As Integer
    Public IntValidaArticuloId As Integer
    Private txtIntmArticuloServicioPromocionesArticuloId As Integer


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
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd", "Editar")
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
            If intmTipoServicioVirtualId = 0 Then
                intmTipoServicioVirtualId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intTipoServicioVirtualId", "0"))
            End If
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
            If strmTipoServicioVirtualDescripcion = Nothing Then
                strmTipoServicioVirtualDescripcion = Request.Form("txtTipoServicioVirtualDescripcion")
            End If
            Return strmTipoServicioVirtualDescripcion
        End Get
        Set(ByVal strValue As String)
            strmTipoServicioVirtualDescripcion = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strServicioVirtualCodigoProducto
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strServicioVirtualCodigoProducto() As String
        Get
            If strmServicioVirtualCodigoProducto = Nothing Then
                strmServicioVirtualCodigoProducto = Request.Form("txtCodigoProducto")
            End If
            Return strmServicioVirtualCodigoProducto
        End Get
        Set(ByVal strValue As String)
            strmServicioVirtualCodigoProducto = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intServicioVirtualId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intServicioVirtualId() As String
        Get
            If intmServicioVirtualId = Nothing Then
                intmServicioVirtualId = Request.Form("txtintServicioVirtualId")
            End If
            Return intmServicioVirtualId
        End Get
        Set(ByVal intValue As String)
            intmServicioVirtualId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strServicioVirtualDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strServicioVirtualDescripcion() As String
        Get
            If strmServicioVirtualDescripcion = Nothing Then
                strmServicioVirtualDescripcion = Request.Form("txtDescripcion")
            End If
            Return strmServicioVirtualDescripcion
        End Get
        Set(ByVal strValue As String)
            strmServicioVirtualDescripcion = strValue
        End Set
    End Property

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
    ' Name       : txtintServicioVirtualId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer JPMB
    '====================================================================
    Public Property txtintServicioVirtualId() As String
        Get
            Return txtintmServicioVirtualId
        End Get
        Set(ByVal intValue As String)
            txtintmServicioVirtualId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : txtintTipoServicioVirtualId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer JPMB
    '====================================================================
    Public Property txtintTipoServicioVirtualId() As Integer
        Get
            Return txtintmTipoServicioVirtualId
        End Get
        Set(ByVal intValue As Integer)
            txtintmTipoServicioVirtualId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : txtIntArticuloServicioPromocionesArticuloId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer JPMB
    '====================================================================
    Public Property txtIntArticuloServicioPromocionesArticuloId() As Integer
        Get
            Return txtIntmArticuloServicioPromocionesArticuloId
        End Get
        Set(ByVal intValue As Integer)
            txtIntmArticuloServicioPromocionesArticuloId = intValue
        End Set
    End Property


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Dim intResultado As Integer

        Dim strResultado As Array

        ' Execute the selected command
        Select Case strCmd

            Case "Editar"

                ' Si el identificador del elemento es válido
                If intTipoServicioVirtualId > 0 Then

                    ' Obtenemos el Tipo de servicio
                    Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsTipoServicioVirtual.strBuscar(intTipoServicioVirtualId, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        Dim aobjRow As System.Array = DirectCast(aobjData.GetValue(0), System.Array)

                        ' Recuperamos sus datos
                        intTipoServicioVirtualId = CInt(aobjRow.GetValue(0))
                        strTipoServicioVirtualDescripcion = CStr(aobjRow.GetValue(1))

                        ' Obtenemos los datos del Servicio Virtual a editar
                        Dim objeData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtual.strBuscar(intTipoServicioVirtualId, CInt(intServicioVirtualId), strConnectionString)
                        'Si el Servicio Virtual fue encontrado
                        If IsNothing(objeData) = False AndAlso objeData.Length > 0 Then
                            Dim objRow As System.Array = DirectCast(objeData.GetValue(0), System.Array)

                            'Recuperamos sus datos
                            intTipoServicioVirtualId = CInt(objRow.GetValue(0))
                            strServicioVirtualCodigoProducto = CStr(objRow.GetValue(1))
                            strServicioVirtualDescripcion = CStr(objRow.GetValue(2))

                        End If

                        'Obtenemos Los Elementos de La Tabla de  tblArticuloServicioPromociones

                        Dim objetoData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clstblArticuloServicioPromociones.strBuscarArticuloIdServicioPromociones(0, CInt(intServicioVirtualId), strServicioVirtualCodigoProducto, strConnectionString)

                        ' Si el elemento fue encontrado
                        If IsNothing(objetoData) = False AndAlso objetoData.Length > 0 Then

                            Dim objeRow As System.Collections.SortedList = DirectCast(objetoData.GetValue(0), System.Collections.SortedList)

                            ' Recuperamos sus datos
                            IntArticuloServicioPromocionesArticuloId = CInt(objeRow.Item("intArticuloId"))

                        End If
                    End If
                End If

                'JPMB Guarda el Codigo De Asignado a Los Datos.

            Case "Guardar"

                ' Validamos que el Articulo ir por asignar no sea ceroo nulo 
                If IntArticuloServicioPromocionesArticuloId > 0 Then

                    'Regresa el Numero de Elementos Guardados
                    Dim IntElementos As Integer



                    'Consultamos si existe Articulo Id en tblArticulos y tblClasificacionArticulo
                    IntValidaArticuloId = 0

                    IntValidaArticuloId = Benavides.CC.Business.clsConcentrador.clsSucursal.clstblArticuloServicioPromociones.IntValidarArticuloServicioVirtual(IntArticuloServicioPromocionesArticuloId, _
                                                                                                                                                    strConnectionString)

                    If IntValidaArticuloId > 0 Then

                        IntElementos = 0
                        'Mandamos Los Datos Para el Prceso de Guardado
                        IntElementos = Benavides.CC.Business.clsConcentrador.clsSucursal.clstblArticuloServicioPromociones.IntAgregarArticuloIdServicioPromociones(CInt(txtintServicioVirtualId), _
                                                                                                                                    0, _
                                                                                                                            strServicioVirtualCodigoProducto, _
                                                                                                                            IntArticuloServicioPromocionesArticuloId, _
                                                                                                                            strUsuarioNombre, _
                                                                                                                            strConnectionString)
                        ' Si el identificador del elemento es válido
                        If intTipoServicioVirtualId > 0 Then

                            ' Obtenemos el Tipo de servicio
                            Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsTipoServicioVirtual.strBuscar(txtintTipoServicioVirtualId, strConnectionString)

                            ' Si el elemento fue encontrado
                            If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                                Dim aobjRow As System.Array = DirectCast(aobjData.GetValue(0), System.Array)

                                ' Recuperamos sus datos
                                intTipoServicioVirtualId = CInt(aobjRow.GetValue(0))
                                strTipoServicioVirtualDescripcion = CStr(aobjRow.GetValue(1))

                                ' Obtenemos los datos del Servicio Virtual a editar
                                Dim objData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsServicioVirtual.strBuscar(txtintTipoServicioVirtualId, CInt(txtintServicioVirtualId), strConnectionString)
                                'Si el Servicio Virtual fue encontrado
                                If IsNothing(objData) = False AndAlso objData.Length > 0 Then
                                    Dim objRow As System.Array = DirectCast(objData.GetValue(0), System.Array)

                                    'Recuperamos sus datos
                                    intTipoServicioVirtualId = CInt(objRow.GetValue(0))
                                    strServicioVirtualCodigoProducto = CStr(objRow.GetValue(1))
                                    strServicioVirtualDescripcion = CStr(objRow.GetValue(2))

                                End If
                            End If
                        End If
                        Response.Write("<script language='javascript'>alert('Los Datos Se Guardaron Correctamente.');</script>")
                    Else

                        IntValidaArticuloId = IntValidaArticuloId

                        Response.Write("<script language='javascript'>alert('Articulo no existente, por favor intente de nuevo');</script>")

                    End If
                Else
                    Response.Write("<script language='javascript'>alert('Articulo Id No Valido');</script>")
                End If
        End Select

    End Sub

End Class
