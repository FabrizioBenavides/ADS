Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

Public Class SucursalEncuestaAdministrarRespuestas
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

        intSelectedPage = GetPageParameter("intNavegadorRegistrosPagina", GetPageParameter("txtRecordBrowserSelectedPage", 1))

        intRespuestaId = GetPageParameter("txtRespuestaId", GetPageParameter("intRespuestaId", 0))
        strRespuestaPreguntaAsociada = GetPageParameter("txtRespuestaPreguntaAsociada", "")
        strRespuestaDescripcion = GetPageParameter("txtRespuestaDescripcion", "")
        strRespuestaOrdenPOS = GetPageParameter("txtRespuestaOrdenPOS", "")
        blnRespuestaActivo = GetPageParameter("chkRespuestaActivo", False)



    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private intmSelectedPage As Integer

    Private intmRespuestaId As Integer
    Private strmRespuestaPreguntaAsociada As String
    Private strmRespuestaDescripcion As String
    Private strmRespuestaOrdenPOS As String
    Private blnmRespuestaActivo As Boolean

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

    Public Property intSelectedPage() As Integer
        Get
            Return intmSelectedPage
        End Get
        Set(ByVal Value As Integer)
            intmSelectedPage = Value
        End Set
    End Property


    '====================================================================
    ' Name       : intRespuestaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intRespuestaId() As Integer
        Get
            Return intmRespuestaId
        End Get
        Set(ByVal intValue As Integer)
            intmRespuestaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRespuestaPreguntaAsociada
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strRespuestaPreguntaAsociada() As String
        Get
            Return strmRespuestaPreguntaAsociada
        End Get
        Set(ByVal strValue As String)
            strmRespuestaPreguntaAsociada = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRespuestaDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strRespuestaDescripcion() As String
        Get
            Return strmRespuestaDescripcion
        End Get
        Set(ByVal strValue As String)
            strmRespuestaDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRespuestaOrdenPOS
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strRespuestaOrdenPOS() As String
        Get
            Return strmRespuestaOrdenPOS
        End Get
        Set(ByVal strValue As String)
            strmRespuestaOrdenPOS = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnRespuestaActivo
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property blnRespuestaActivo() As Boolean
        Get
            Return blnmRespuestaActivo
        End Get
        Set(ByVal blnValue As Boolean)
            blnmRespuestaActivo = blnValue
        End Set
    End Property

    Public ReadOnly Property intNavegadorRegistrosPagina() As Integer
        Get
            If IsNumeric(Request("intNavegadorRegistrosPagina")) Then
                Return CInt(Request("intNavegadorRegistrosPagina"))
            Else
                Return 1
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strGetRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 48
        Const strRecordBrowserName As String = "SucursalEncuestaAdministrarRespuestas"

        ' Declaramos e inicializamos las variables locales

        Dim astrDataArray As Array = Benavides.CC.Data.clstblRespuesta.strBuscar(0, "", "", "", True, CDate("01/01/1900"), "", Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?txtRecordBrowserSelectedPage=" & intSelectedPage & "&")

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Select Case strCmd

            Case "Editar"

                ' Si el identificador del elemento es válido
                If intRespuestaId > 0 Then

                    ' Obtenemos el elemento
                    Dim aobjData As Array = Benavides.CC.Data.clstblRespuesta.strBuscar(intRespuestaId, "", "", "", True, CDate("01/01/1900"), "", 0, 0, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        Dim aobjRow As System.Collections.SortedList = DirectCast(aobjData.GetValue(0), System.Collections.SortedList)

                        ' Recuperamos sus datos
                        intRespuestaId = CInt(aobjRow.Item("intRespuestaId"))
                        strRespuestaPreguntaAsociada = CStr(aobjRow.Item("strRespuestaPreguntaAsociada"))
                        strRespuestaDescripcion = CStr(aobjRow.Item("strRespuestaDescripcion"))
                        strRespuestaOrdenPOS = CStr(aobjRow.Item("strRespuestaOrdenPOS"))
                        blnRespuestaActivo = CBool(aobjRow.Item("blnRespuestaActivo"))

                    End If

                End If

            Case "Salvar"
                ' Si la Respuesta es nueva
                If intRespuestaId = 0 Then
                    ' Agregamos la Respuesta
                    If Benavides.CC.Data.clstblRespuesta.intAgregar(intRespuestaId, strRespuestaPreguntaAsociada, strRespuestaDescripcion, strRespuestaOrdenPOS, blnRespuestaActivo, Now(), strUsuarioNombre, strConnectionString) < 0 Then
                        strJavascriptWindowOnLoadCommands &= "  alert(""ERROR: La información no pudo ser agregada a la base de datos.\n\r\n\rPor favor informe este error a su administrador o personal a cargo."");" & vbCrLf
                    Else
                        ' Regresamos al usuario al listado de elementos
                        Call Response.Redirect("SucursalEncuestaAdministrarRespuestas.aspx?intNavegadorRegistrosPagina=" & intNavegadorRegistrosPagina)
                    End If

                Else
                    ' Actualizamos la Respuesta Existente
                    If Benavides.CC.Data.clstblRespuesta.intActualizar(intRespuestaId, strRespuestaPreguntaAsociada, strRespuestaDescripcion, strRespuestaOrdenPOS, blnRespuestaActivo, Now(), strUsuarioNombre, strConnectionString) < 0 Then
                        strJavascriptWindowOnLoadCommands &= "  alert(""ERROR: La información no pudo ser actualizada en la base de datos.\n\r\n\rPor favor informe este error a su administrador o personal a cargo."");" & vbCrLf
                    Else
                        ' Regresamos al usuario al listado de elementos
                        Call Response.Redirect("SucursalEncuestaAdministrarRespuestas.aspx?intNavegadorRegistrosPagina=" & intNavegadorRegistrosPagina)
                    End If
                End If

                ' Limpiamos los valores de los campos de la forma

                intRespuestaId = 0
                strRespuestaPreguntaAsociada = ""
                strRespuestaDescripcion = ""
                strRespuestaOrdenPOS = ""
                blnRespuestaActivo = False

        End Select

    End Sub

End Class
