Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert

'====================================================================
' Class         : VentasMontoMaximoFaltanteCaja
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Administracion de Monto Máximo para Faltante Cajero
' Company       : Softtek 2013
' Author        : Karla Martinez
' Last Modified : Wednesday, Apr 10, 2013
'====================================================================

Public Class VentasMontoMaximoFaltanteCaja

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

        fltMontoMaximoFaltanteCaja = GetPageParameter("txtMontoMaximoFaltanteCaja", CDbl(GetPageParameter("fltMontoMaximoFaltanteCaja", 0)))

    End Sub

#End Region

#Region " Class Private Attributes"

    Private fltmMontoMaximoFaltanteCaja As Double
    Private strmJavascriptWindowOnLoadCommands As String

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
    ''====================================================================
    '' Name       : strCmd
    '' Description: Parameter value
    '' Accessor   : Read
    '' Output     : String
    ''====================================================================
    'Public ReadOnly Property strCmd() As String
    '    Get
    '        Return GetPageParameter("strCmd", "Agregar")
    '        ' Almacenamos el comando ejecutado

    '    End Get
    'End Property

    '====================================================================
    ' Name       : fltMontoMaximoFaltanteCaja
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property fltMontoMaximoFaltanteCaja() As Double
        Get
            Return fltmMontoMaximoFaltanteCaja
        End Get
        Set(ByVal intValue As Double)
            fltmMontoMaximoFaltanteCaja = intValue
        End Set
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
    ' Name       : fltImporteTopeMontoMaximoFaltanteCajero
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property fltImporteTopeMontoMaximoFaltanteCajero() As Double
        Get
            If fltImporteTopeMontoMaximoFaltanteCajero = Nothing Then
                fltImporteTopeMontoMaximoFaltanteCajero = CDbl(Request.Form("txtMontoMaximoFaltanteCaja"))
            End If
            Return fltImporteTopeMontoMaximoFaltanteCajero
        End Get
        Set(ByVal strValue As Double)
            fltImporteTopeMontoMaximoFaltanteCajero = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 10
        Const strRecordBrowserName As String = "VentasMontoMaximoFaltanteCaja"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1"))

        ' Buscamos el monto máximo
        Dim astrDataArray As Array = Benavides.CC.Data.clstblMontoMaximoFaltanteCajero.aobjBuscarMontoMaximoFaltanteCaja(strConnectionString)

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?")


    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        Dim strCmd As String = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Execute the selected command
        Select Case strCmd

            Case "Borrar"

                Call Benavides.CC.Data.clstblMontoMaximoFaltanteCajero.intEliminar(strConnectionString)

            Case "Guardar"

                ' Si el identificador del elemento es válido
                If fltMontoMaximoFaltanteCaja > 0 Then

                    Call Benavides.CC.Data.clstblMontoMaximoFaltanteCajero.intAgregar(fltMontoMaximoFaltanteCaja, Now(), strUsuarioNombre, strConnectionString)

                End If



        End Select

    End Sub

End Class

