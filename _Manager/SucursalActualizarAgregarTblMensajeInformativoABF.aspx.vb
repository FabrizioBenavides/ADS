Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert


Public Class SucursalActualizarAgregarTblMensajeInformativoABF
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
        IntAvisosABFId = GetPageParameter("intAvisosABFId", 0)
        strClienteABF = GetPageParameter("txtClienteABF", "")
        ' Recuperamos sus datos
        strDescripcion = GetPageParameter("txtDescripcion", "")
        intDiasMensajeInformativoABF = GetPageParameter("txtDiasAviso", 0)
        strMensajeInformativoABF = GetPageParameter("txtMensajeInformativo", "")

    End Sub

#End Region


#Region " Class Private Attributes"

    Private intmSelectedPage As Integer

    Private strmJavascriptWindowOnLoadCommands As String
    Private IntmAvisosABFId As Integer
    Private strmClienteABF As String
    Private strmDescripcion As String
    Private intmDiasMensajeInformativoABF As Integer
    Private strmMensajeInformativoABF As String
    Private blnmMensajeInformativoABFActivo As Boolean
    Private strMensajeABFModificadoPor As String

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
    ' Name       : strClienteABF 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strClienteABF() As String
        Get
            Return strmClienteABF
        End Get
        Set(ByVal strValue As String)
            strmClienteABF = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : strDescripcion
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strDescripcion() As String
        Get
            Return strmDescripcion
        End Get
        Set(ByVal strValue As String)
            strmDescripcion = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : intDiasMensajeInformativoABF
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property intDiasMensajeInformativoABF() As Integer
        Get
            Return intmDiasMensajeInformativoABF
        End Get
        Set(ByVal intValue As Integer)
            intmDiasMensajeInformativoABF = intValue
        End Set
    End Property
    ' ==================================================================
    ' Name        : blnMensajeActivo(
    ' Descripcion : Evalue el Valor del Check Que esta en Html
    ' Parametros  : None 
    ' Acceso      : De Lectura \ Escritura
    ' Regresa     : Boolean 
    ' Autor       : sftk (RERA)
    ' ==================================================================
    Public Property blnMensajeInformativoABFActivo() As Boolean
        Get
            If blnmMensajeInformativoABFActivo = Nothing Then
                blnmMensajeInformativoABFActivo = CBool(isocraft.commons.clsWeb.strGetPageParameter("chkActivo", "0"))
            End If
            Return blnmMensajeInformativoABFActivo
        End Get
        Set(ByVal blnValue As Boolean)
            blnmMensajeInformativoABFActivo = blnValue
        End Set
    End Property
    '====================================================================
    ' Name       : strMensajeInformativoABF
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strMensajeInformativoABF() As String
        Get
            Return strmMensajeInformativoABF
        End Get
        Set(ByVal strValue As String)
            strmMensajeInformativoABF = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : IntAvisosABFId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property IntAvisosABFId() As Integer

        Get

            Return IntmAvisosABFId

        End Get

        Set(ByVal intValue As Integer)

            IntmAvisosABFId = intValue

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
                Benavides.CC.Business.clsConcentrador.clsSucursal.clstblMensajeInformativoABF.IntActualizarAgregarMensajeInformativoABF(IntAvisosABFId, _
                                                                                                                                        strClienteABF, _
                                                                                                                                        strMensajeInformativoABF, _
                                                                                                                                        intDiasMensajeInformativoABF, _
                                                                                                                                        blnMensajeInformativoABFActivo, _
                                                                                                                                        strUsuarioNombre, _
                                                                                                                                        strConnectionString)

                ' Regresamos al usuario al listado de elementos
                If blnRedirectToParentPage = True Then
                    strJavascriptWindowOnLoadCommands &= " window.location.href = ""SucursalAvisosABF.aspx"";"
                Else
                    Response.Redirect("SucursalAvisosABF.aspx", True)
                End If

            Case "Editar"

                ' Si el identificador del elemento es válido
                If IntAvisosABFId > 0 Then

                    ' Obtenemos el elemento
                    Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clstblMensajeInformativoABF.strBuscarMensajeInformativoABF(IntAvisosABFId, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        'Dim aobjRow As System.Collections.SortedList = DirectCast(aobjData.GetValue(0), System.Collections.SortedList)
                        Dim aobjRow As System.Array = DirectCast(aobjData.GetValue(0), System.Array)

                        ' Recuperamos sus datos
                        IntAvisosABFId = CInt(aobjRow.GetValue(0))
                        strClienteABF = CStr(aobjRow.GetValue(1))
                        strDescripcion = CStr(aobjRow.GetValue(2))
                        intDiasMensajeInformativoABF = CInt(aobjRow.GetValue(3))
                        strMensajeInformativoABF = CStr(aobjRow.GetValue(4))
                        blnMensajeInformativoABFActivo = CBool(aobjRow.GetValue(5))


                    End If

                End If

        End Select
    End Sub

End Class
