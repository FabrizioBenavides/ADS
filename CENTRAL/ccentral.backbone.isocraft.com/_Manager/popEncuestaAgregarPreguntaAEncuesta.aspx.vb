Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert

Public Class popEncuestaAgregarPreguntaAEncuesta
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

        ' Initialize class properties
        intEncuestaId = GetPageParameter("txtintEncuestaId", GetPageParameter("intEncuestaId", 0))
        strPreguntas = GetPageParameter("cboPreguntas", "")

    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private strmtxtEncuestaId As Integer
    Private strmcboPregunta As String

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
            Return GetPageParameter("strCmd", "Editar")
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
            Return strmtxtEncuestaId
        End Get
        Set(ByVal intValue As Integer)
            strmtxtEncuestaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strPregunta
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strPreguntas() As String
        Get
            Return strmcboPregunta
        End Get
        Set(ByVal strValue As String)
            strmcboPregunta = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strComboBoxPreguntas
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboPreguntas"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strComboBoxPreguntas() As String
        Const intMaxLenght As Integer = 50

        Dim aobjData As Array = Benavides.CC.Data.clstblPregunta.strBuscar(0, "", "", False, CDate("01/01/1900"), "", 0, 0, strConnectionString)

        If IsArray(aobjData) AndAlso aobjData.Length > 0 Then
            For Each aobjRow As System.Collections.SortedList In aobjData
                If CBool(aobjRow.Item("blnPreguntaActivo")) = False Then
                    aobjRow.Item("strPreguntaDescripcion") = Left(CStr(aobjRow.Item("strPreguntaDescripcion")), intMaxLenght) & "..." & "(inactivo)"
                End If

                aobjRow.Item("strPreguntaDescripcion") = Mid(aobjRow.Item("strPreguntaEncuestaAsociada").ToString & Space(45), 1, 45) & Space(4) & Mid(aobjRow.Item("strPreguntaDescripcion").ToString & Space(65), 1, 65)

            Next
            Return CreateJavascriptComboBoxOptions("cboPreguntas", "", aobjData, "intPreguntaId", "strPreguntaDescripcion", 0)
        Else
            Return ""
        End If

        
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Check if the current user can access this page
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Execute the selected command
        Select Case strCmd

            Case "Agregar"

                ' Verificamos que se hayan seleccionado atributos
                If Len(strPreguntas) > 0 AndAlso intEncuestaId > 0 Then

                    ' Obtenemos los atributos seleccionados
                    Dim astrPreguntas As Array = strPreguntas.Split(","c)

                    ' Por cada atributo existente
                    For Each strPreguntaId As String In astrPreguntas

                        ' Obtenemos el identificador numérico del atributo
                        Dim intPreguntaId As Integer = CInt(ConvertStringToObject(strPreguntaId, TypeCode.Int32))

                        ' Si su identificador es válido
                        If intPreguntaId > 0 Then

                            ' Agregamos la respuesta a la Pregunta
                            Call Benavides.CC.Data.clstblPreguntaEncuesta.intAgregar(intPreguntaId, intEncuestaId, True, CDate("01/01/1900"), strUsuarioNombre, strConnectionString)

                        End If

                    Next

                End If

                ' Cerramos la ventana
                strJavascriptWindowOnLoadCommands &= "  window.opener.location.href = ""SucursalEncuestaAgregarEncuestas.aspx?strCmd=Editar&intEncuestaId=" & intEncuestaId & """;" & vbCrLf
                strJavascriptWindowOnLoadCommands &= "  window.close();" & vbCrLf

        End Select

    End Sub


End Class
