Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports System.Text
Imports System.Collections
Imports Benavides.POSAdmin.Commons

'====================================================================
' Class         : SucursalSucursalAvisosABF1
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Sucursal
' Copyright     : 2013 All rights reserved.
' Company       : Softtek
' Author        : Rocio Esquivel (RERA)
' Version       : 1.0 
' Last Modified : 
' Modified by   : 
'====================================================================
Public Class SucursalAvisosABF1

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

        'Inicializa(Propiedades)
        intSelectedPage = GetPageParameter("intNavegadorRegistrosPagina", GetPageParameter("txtRecordBrowserSelectedPage", 1))
        IntAvisosABFId = GetPageParameter("intAvisosABFId", 0)
        strCliente = GetPageParameter("txtCliente", "")
        strDescripcion = GetPageParameter("txtDescripcion", "")
        intDiasMensajeInformativoABF = GetPageParameter("txtdiasaviso", 0)
        strMensajeInformativoABF = GetPageParameter("txtmensaje", "")

    End Sub

#End Region

#Region " Class Private Attributes"

    Private intmSelectedPage As Integer

    Private strmJavascriptWindowOnLoadCommands As String
    Private IntmAvisosABFId As Integer
    Private intmEmpresaServicioIdAnterior As Integer
    Private strmCliente As String
    Private strmDescripcion As String
    Private intmDiasMensajeInformativoABF As Integer
    Private blnmMensajeInformativoABFActivo As Boolean
    Private strmMensajeInformativoABF As String

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
    ' Name       : strThisPageName
    ' Description: URL de esta página
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request)
        End Get
    End Property

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Obtiene la cadena de conexión hacia la base de datos
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
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
    ' Name       : strCliente
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strCliente() As String
        Get
            Return strmCliente
        End Get
        Set(ByVal strValue As String)
            strmCliente = strValue
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
    ' Name        :blnMensajeInformativoABFActivo(
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
    ' Name       : strCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return GetPageParameter("strCmd", "")
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

    '====================================================================
    ' Name       : strGetRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read  intTipoOperacionDEXId
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 10
        Const strRecordBrowserName As String = "SucursalAvisosABF1"

        ' Declaramos e inicializamos las variables locales

        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim astrDataArray As Array

        astrDataArray = Benavides.CC.Business.clsConcentrador.clsSucursal.clstblMensajeInformativoABF.strBuscarMensajeInformativoABF(IntAvisosABFId, strConnectionString)
        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?IntAvisosABF=" & IntAvisosABFId & "&")

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Select Case strCmd

            Case "Eliminar"

                Benavides.CC.Business.clsConcentrador.clsSucursal.clstblMensajeInformativoABF.intEliminar(CInt(IntAvisosABFId), strConnectionString)
                IntAvisosABFId = 0

            Case "Editar"

                ' Si el identificador del elemento es válido
                If IntAvisosABFId > 0 Then

                    'Mandamos llamar a la pagina de servicios virtuales
                    'Response.Redirect("SucursalActualizarAgregarTblMensajeInformativoABF.aspx?strCmd=Editar&IntAvisosABFId=" & CInt(IntAvisosABFId) & "&strCliente=" & CStr(strCliente))
                    Call Response.Redirect("SucursalActualizarAgregarTblMensajeInformativoABF.aspx?strCmd=" & strCmd & "&IntAvisosABFId=" & IntAvisosABFId)

                End If


            Case "Agregar"

                Dim blnRedirectToParentPage As Boolean

                'Guardamos la informacion
                Benavides.CC.Business.clsConcentrador.clsSucursal.clstblMensajeInformativoABF.IntActualizarAgregarMensajeInformativoABF(IntAvisosABFId, _
                                                                                                                                        strCliente, _
                                                                                                                                        strMensajeInformativoABF, _
                                                                                                                                        intDiasMensajeInformativoABF, _
                                                                                                                                        blnMensajeInformativoABFActivo, _
                                                                                                                                        strUsuarioNombre, _
                                                                                                                                        strConnectionString)


                'Call Response.Redirect("sucursalAvisoABF.aspx?strCmd=" & strCmd & "&IntAvisosABFId=" & IntAvisosABFId)

        End Select

        ' Call Response.Redirect("sucursalAvisoABF.aspx?strCmd=" & strCmd & "&IntAvisosABFId=" & IntAvisosABFId)

    End Sub

End Class
