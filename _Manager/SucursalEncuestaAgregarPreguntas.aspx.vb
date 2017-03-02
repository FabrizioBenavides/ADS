Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

Public Class SucursalEncuestaAgregarPreguntas
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

        intSelectedPage = GetPageParameter("intNavegadorRegistrosPagina", GetPageParameter("txtRecordBrowserSelectedPage", 1))

        intPreguntaId = GetPageParameter("txtPreguntaId", GetPageParameter("intPreguntaId", GetPageParameter("intRBintPreguntaId", 0)))
        strPreguntaEncuestaAsociada = GetPageParameter("txtPreguntaEncuestaAsociada", "")
        strPreguntaDescripcion = GetPageParameter("txtPreguntaDescripcion", "")
        blnPreguntaActivo = GetPageParameter("chkPreguntaActivo", False)

        If StrComp(strCmd, "Agregar") = 0 Then
            intPreguntaId = 0
        End If

    End Sub

#End Region

#Region " Class Private Attributes"

    Private intmSelectedPage As Integer
    Private strmJavascriptWindowOnLoadCommands As String

    Private intmPreguntaId As Integer
    Private strmPreguntaEncuestaAsociada As String
    Private strmPreguntaDescripcion As String
    Private blnmchkPreguntaActivo As Boolean

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
    ' Name       : intPreguntaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intPreguntaId() As Integer
        Get
            Return intmPreguntaId
        End Get
        Set(ByVal intValue As Integer)
            intmPreguntaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strPreguntaEncuestaAsociada
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strPreguntaEncuestaAsociada() As String
        Get
            Return strmPreguntaEncuestaAsociada
        End Get
        Set(ByVal strValue As String)
            strmPreguntaEncuestaAsociada = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strPreguntaDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strPreguntaDescripcion() As String
        Get
            Return strmPreguntaDescripcion
        End Get
        Set(ByVal strValue As String)
            strmPreguntaDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnPreguntaActivo
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnPreguntaActivo() As Boolean
        Get
            Return blnmchkPreguntaActivo
        End Get
        Set(ByVal blnValue As Boolean)
            blnmchkPreguntaActivo = blnValue
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

        ' Verificamos que el identificador del tipo de receta sea válido
        If intPreguntaId > 0 Then

            ' Declaramos e inicializamos las constantes locales
            Const intElementsPerPage As Integer = 10
            Const strRecordBrowserName As String = "SucursalEncuestaAgregarPreguntas"

            ' Declaramos e inicializamos las variables locales
            Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
            Dim aobjDataArray As Array = Benavides.CC.Data.clsEncuesta.strBuscarRespuestaPregunta(0, intPreguntaId, True, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

            ' Generamos el navegador de registros
            Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, aobjDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?intRBintPreguntaId=" & intPreguntaId & "&").Replace("<input name=""cmdNavegadorRegistrosAgregar"" type=""button"" class=""boton"" id=""cmdNavegadorRegistrosAgregar"" value=""Agregar Respuesta"" onclick=""window.location='SucursalEncuestaAgregarPreguntas.aspx?intRBintPreguntaId=" & intPreguntaId & "&amp;strCmd=Agregar'"">", "<input name=""cmdNavegadorRegistrosAgregar"" type=""button"" class=""boton"" id=""cmdNavegadorRegistrosAgregar"" value=""Agregar Respuesta"" onclick=""cmdNavegadorRegistrosAgregar_onclick()"">")

        End If

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Check if the current user can access this page
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Execute the selected command
        Select Case strCmd

            Case "Eliminar"

                Dim intRespuestaId As Integer = GetPageParameter("intRespuestaId", 0)

                If intPreguntaId > 0 AndAlso intRespuestaId > 0 Then

                    ' Eliminamos la respuesta asociada a la pregunta
                    Call Benavides.CC.Data.clstblRespuestaPregunta.intActualizar(intRespuestaId, intPreguntaId, False, CDate("01/01/1900"), strUsuarioNombre, strConnectionString)

                    ' Regresamos al usuario al listado de elementos
                    Call Response.Redirect("SucursalEncuestaAgregarPreguntas.aspx?strCmd=Editar&intPreguntaId=" & intPreguntaId)

                End If

                ' Regresamos al usuario al listado de elementos
                Call Response.Redirect("SucursalEncuestaAdministrarPreguntas.aspx")

            Case "Editar"

                ' Si el identificador del elemento es válido
                If intPreguntaId > 0 Then

                    ' Obtenemos el elemento
                    Dim aobjData As Array = Benavides.CC.Data.clstblPregunta.strBuscar(intPreguntaId, "", "", False, CDate("01/01/1900"), "", 0, 0, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        Dim aobjRow As System.Collections.SortedList = DirectCast(aobjData.GetValue(0), System.Collections.SortedList)

                        ' Recuperamos sus datos
                        intPreguntaId = CInt(aobjRow.Item("intPreguntaId"))
                        strPreguntaEncuestaAsociada = CStr(aobjRow.Item("strPreguntaEncuestaAsociada"))
                        strPreguntaDescripcion = CStr(aobjRow.Item("strPreguntaDescripcion"))
                        blnPreguntaActivo = CBool(aobjRow.Item("blnPreguntaActivo"))

                    End If

                End If

            Case "Salvar"

                Dim blnRedirectToParentPage As Boolean

                ' Si el tipo de atributo es nuevo
                If intPreguntaId = 0 Then

                    ' Agregamos el nuevo tipo de atributo
                    intPreguntaId = Benavides.CC.Data.clstblPregunta.intAgregar(intPreguntaId, strPreguntaEncuestaAsociada, strPreguntaDescripcion, blnPreguntaActivo, CDate("01/01/1900"), strUsuarioNombre, strConnectionString)

                    ' Si la llave del nueva pregunta es válida
                    If intPreguntaId < 0 Then
                        strJavascriptWindowOnLoadCommands &= "  alert(""ERROR: La información no pudo ser agregada a la base de datos.\n\r\n\rPor favor informe este error a su administrador o personal a cargo."");" & vbCrLf
                        blnRedirectToParentPage = True
                    End If

                Else

                    ' Actualizamos el tipo de atributo existente
                    If Benavides.CC.Data.clstblPregunta.intActualizar(intPreguntaId, strPreguntaEncuestaAsociada, strPreguntaDescripcion, blnPreguntaActivo, CDate("01/01/1900"), strUsuarioNombre, strConnectionString) < 0 Then
                        strJavascriptWindowOnLoadCommands &= "  alert(""ERROR: La información no pudo ser actualizada en la base de datos.\n\r\n\rPor favor informe este error a su administrador o personal a cargo."");" & vbCrLf
                        blnRedirectToParentPage = True
                    End If

                End If

                ' Regresamos al usuario al listado de elementos
                If blnRedirectToParentPage = True Then
                    strJavascriptWindowOnLoadCommands &= " window.location.href = ""SistemaAdministrarTiposDeRecetas.aspx"";"
                End If

        End Select


    End Sub

End Class
