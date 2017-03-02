Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert

Public Class SucursalTarjetaRegaloAgregarEditar
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

        IntTarjetaRegaloId = GetPageParameter("txtTarjetaRegaloId", GetPageParameter("IntTarjetaRegaloId", 0))

        strTarjetaRegaloCodigoProducto = GetPageParameter("txtTarjetaRegaloCodigoProducto", "")

        strTarjetaRegaloDescripcion = GetPageParameter("txtTarjetaRegaloDescripcion", "")
        strTarjetaRegaloTextoImprimir = GetPageParameter("txtTarjetaRegaloTextoImprimir", "")
        fltTarjetaRegaloMonto = CDbl(Val(GetPageParameter("txtTarjetaRegaloMonto", "")))
        fltTarjetaRegaloMontoaCobrar = CDbl(Val(GetPageParameter("txtTarjetaRegaloMontoaCobrar", "")))

    End Sub

#End Region


#Region " Class Private Attributes"

    Private IntmTarjetaRegaloId As Integer
    Private strmTarjetaRegaloCodigoProducto As String
    Private strmTarjetaRegaloDescripcion As String
    Private strmTarjetaRegaloTextoImprimir As String
    Private strmJavascriptWindowOnLoadCommands As String
    Private IntmTarjetaRegaloIdAnterior As Integer
    Private blnmTarjetaRegaloEliminado As Boolean
    Private fltmTarjetaRegaloMonto As Double
    Private fltmTarjetaRegaloMontoaCobrar As Double

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
    ' Name       : IntTarjetaRegaloId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property IntTarjetaRegaloId() As Integer
        Get
            Return IntmTarjetaRegaloId
        End Get
        Set(ByVal intValue As Integer)
            IntmTarjetaRegaloId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTarjetaRegaloCodigoProducto
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTarjetaRegaloCodigoProducto() As String
        Get
            Return strmTarjetaRegaloCodigoProducto
        End Get
        Set(ByVal strValue As String)
            strmTarjetaRegaloCodigoProducto = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : strTarjetaRegaloDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTarjetaRegaloDescripcion() As String
        Get
            Return strmTarjetaRegaloDescripcion
        End Get
        Set(ByVal strValue As String)
            strmTarjetaRegaloDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTarjetaRegaloDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTarjetaRegaloTextoImprimir() As String
        Get
            Return strmTarjetaRegaloTextoImprimir
        End Get
        Set(ByVal strValue As String)
            strmTarjetaRegaloTextoImprimir = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : IntmTarjetaRegaloIdAnterior
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property IntTarjetaRegaloIdAnterior() As Integer
        Get
            Return IntmTarjetaRegaloIdAnterior
        End Get
        Set(ByVal strValue As Integer)
            IntmTarjetaRegaloIdAnterior = strValue
        End Set
    End Property
    ' ==================================================================
    ' Name        : blnTarjetaRegaloEliminado
    ' Descripcion : Evalue el Valor del Check Que esta en Html
    ' Parametros  : None 
    ' Acceso      : De Lectura \ Escritura
    ' Regresa     : Boolean 
    ' Autor       : sftk (JPMB)
    ' ==================================================================
    Public Property blnTarjetaRegaloEliminado() As Boolean
        Get
            If blnmTarjetaRegaloEliminado = Nothing Then
                blnmTarjetaRegaloEliminado = CBool(isocraft.commons.clsWeb.strGetPageParameter("chkTarjetaRegaloEliminado", "0"))
            End If
            Return blnmTarjetaRegaloEliminado
        End Get
        Set(ByVal blnValue As Boolean)
            blnmTarjetaRegaloEliminado = blnValue
        End Set
    End Property
    '====================================================================
    ' Name       : strTarjetaRegaloDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property fltTarjetaRegaloMonto() As Double
        Get
            Return fltmTarjetaRegaloMonto
        End Get
        Set(ByVal strValue As Double)
            fltmTarjetaRegaloMonto = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : strTarjetaRegaloDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property fltTarjetaRegaloMontoaCobrar() As Double
        Get
            Return fltmTarjetaRegaloMontoaCobrar
        End Get
        Set(ByVal strValue As Double)
            fltmTarjetaRegaloMontoaCobrar = strValue
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Execute the selected command
        Select Case strCmd

            Case "Salvar"

                Dim blnRedirectToParentPage As Boolean

                'Guardamos la informacion
                Benavides.CC.Business.clsConcentrador.clsSucursal.clsTarjetaRegalo.IntActualizarTblTarjetaRegalo(IntTarjetaRegaloId, _
                                                                                                                        strTarjetaRegaloCodigoProducto, _
                                                                                                                        0, _
                                                                                                                        strTarjetaRegaloDescripcion, _
                                                                                                                        strTarjetaRegaloTextoImprimir, _
                                                                                                                        blnTarjetaRegaloEliminado, _
                                                                                                                        fltTarjetaRegaloMonto, _
                                                                                                                        fltTarjetaRegaloMontoaCobrar, _
                                                                                                                        strUsuarioNombre, _
                                                                                                                        strConnectionString)

                ' Regresamos al usuario al listado de elementos
                If blnRedirectToParentPage = True Then
                    strJavascriptWindowOnLoadCommands &= " window.location.href = ""SucursalAsignacionDeArticuloTarjetaRegalo.aspx"";"
                Else
                    Response.Redirect("SucursalAsignacionDeArticuloTarjetaRegalo.aspx", True)
                End If

            Case "Editar"

                ' Si el identificador del elemento es válido
                If IntTarjetaRegaloId > 0 Then

                    ' Obtenemos el elemento
                    Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsTarjetaRegalo.strBuscarTarjetaRegalo(IntTarjetaRegaloId, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        'Dim aobjRow As System.Collections.SortedList = DirectCast(aobjData.GetValue(0), System.Collections.SortedList)
                        Dim aobjRow As System.Array = DirectCast(aobjData.GetValue(0), System.Array)

                        ' Recuperamos sus datos
                        IntTarjetaRegaloId = CInt(aobjRow.GetValue(0))
                        strTarjetaRegaloDescripcion = CStr(aobjRow.GetValue(1))
                        strTarjetaRegaloCodigoProducto = CStr(aobjRow.GetValue(2))
                        strTarjetaRegaloTextoImprimir = CStr(aobjRow.GetValue(4))
                        blnTarjetaRegaloEliminado = CBool(aobjRow.GetValue(5))
                        fltTarjetaRegaloMonto = CDbl(aobjRow.GetValue(6))
                        fltTarjetaRegaloMontoaCobrar = CDbl(aobjRow.GetValue(7))

                    End If

                End If

        End Select
    End Sub

End Class
