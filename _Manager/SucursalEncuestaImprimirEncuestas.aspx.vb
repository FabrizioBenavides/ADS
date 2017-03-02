Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

Public Class SucursalEncuestaImprimirEncuestas
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

        intEncuestaId = GetPageParameter("txtEncuestaId", GetPageParameter("intEncuestaId", 0))

    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private intmEncuestaId As Integer

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
    ' Name       : intEncuestaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intEncuestaId() As Integer
        Get
            Return intmEncuestaId
        End Get
        Set(ByVal intValue As Integer)
            intmEncuestaId = intValue
        End Set
    End Property


    '====================================================================
    ' Name       : strGetRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String

        ' Declaramos e inicializamos las variables locales
        Dim ArrayEncuesta As Array = Benavides.CC.Data.clsEncuesta.strBuscar(intEncuestaId, strConnectionString)
        Dim RegistroEncuesta As System.Collections.SortedList

        Dim strHTML As New System.Text.StringBuilder

        strHTML.Append("")

        ' Si el elemento fue encontrado
        If IsNothing(ArrayEncuesta) = False AndAlso ArrayEncuesta.Length > 0 Then

            Dim rptEncuestaId As Integer, antEncuestaId As Integer = 0
            Dim rptEncuestaDescripcion As String

            Dim rptPreguntaId As Integer, antPreguntaId As Integer = 0, intContadorPregunta As Integer = 0
            Dim rptPreguntaDescripcion As String

            Dim rptRespuestaId As Integer, antRespuestaId As Integer = 0
            Dim rptRespuestaDescripcion As String

            strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

            For Each RegistroEncuesta In ArrayEncuesta
                rptEncuestaId = CInt(RegistroEncuesta.Item("intEncuestaId"))
                rptEncuestaDescripcion = CStr(RegistroEncuesta.Item("strEncuestaDescripcion"))

                rptPreguntaId = CInt(RegistroEncuesta.Item("intPreguntaId"))
                rptPreguntaDescripcion = CStr(RegistroEncuesta.Item("strPreguntaDescripcion"))

                rptRespuestaId = CInt(RegistroEncuesta.Item("intRespuestaId"))
                rptRespuestaDescripcion = CStr(RegistroEncuesta.Item("strRespuestaDescripcion"))

                If rptEncuestaId <> antEncuestaId Then
                    'Pinta el Titulo de la Encuesta
                    strHTML.Append("<tr>")
                    strHTML.Append("<td class='txtitulo' align='left'> Encuesta: " & rptEncuestaDescripcion & "</td>")
                    strHTML.Append("</tr>")
                    antEncuestaId = rptEncuestaId
                End If

                If rptPreguntaId <> antPreguntaId Then
                    intContadorPregunta += 1
                    'Pinta la Pregunta
                    strHTML.Append("<tr>")
                    strHTML.Append("<td class='txsubtitulo' align='left'>" & intContadorPregunta.ToString & ".- " & rptPreguntaDescripcion & "</td>")
                    strHTML.Append("</tr>")
                    antPreguntaId = rptPreguntaId
                End If

                If rptRespuestaId <> antRespuestaId Then
                    'Pinta la Pregunta
                    strHTML.Append("<tr>")
                    strHTML.Append("<td class='txcontenido' align='left'> __ " & rptRespuestaDescripcion & "</td>")
                    strHTML.Append("</tr>")
                    antRespuestaId = rptRespuestaId
                End If

            Next

            strHTML.Append("</table>")

           
        End If

        Return strHTML.ToString

        
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If
    End Sub

End Class
