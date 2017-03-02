Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert

Public Class SucursalEncuestaAgregarEncuestas
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

        intEncuestaId = GetPageParameter("txtEncuestaId", GetPageParameter("intEncuestaId", GetPageParameter("intRBintEncuestaId", 0)))

        strEncuestaNombre = GetPageParameter("txtEncuestaNombre", "")
        strEncuestaDescripcion = GetPageParameter("txtEncuestaDescripcion", "")

        dtmEncuestaInicio = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(GetPageParameter("txtEncuestaInicio", Now().ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture))))
        dtmEncuestaFin = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(GetPageParameter("txtEncuestaFin", Now().ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture))))

        blnEncuestaObligatoria = GetPageParameter("chkEncuestaObligatoria", False)

        blnEncuestaActivo = GetPageParameter("chkEncuestaActivo", False)

        If StrComp(strCmd, "Agregar") = 0 Then
            intEncuestaId = 0
        End If

    End Sub

#End Region

#Region " Class Private Attributes"

    Private intmSelectedPage As Integer
    Private strmJavascriptWindowOnLoadCommands As String

    Private intmEncuestaId As Integer
    Private strmEncuestaNombre As String
    Private strmEncuestaDescripcion As String

    Private strmEncuestaInicio As DateTime
    Private strmEncuestaFin As DateTime

    Private blnmchkEncuestaObligatoria As Boolean
    Private blnmchkEncuestaActivo As Boolean

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
    ' Name       : strEncuestaNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strEncuestaNombre() As String
        Get
            Return strmEncuestaNombre
        End Get
        Set(ByVal strValue As String)
            strmEncuestaNombre = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strEncuestaDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strEncuestaDescripcion() As String
        Get
            Return strmEncuestaDescripcion
        End Get
        Set(ByVal strValue As String)
            strmEncuestaDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : dtmEncuestaInicio
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : DateTime
    '====================================================================
    Public Property dtmEncuestaInicio() As DateTime
        Get
            Return strmEncuestaInicio
        End Get
        Set(ByVal dtmValue As DateTime)
            strmEncuestaInicio = dtmValue
        End Set
    End Property

    '====================================================================
    ' Name       : dtmEncuestaFin
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : DateTime
    '====================================================================
    Public Property dtmEncuestaFin() As DateTime
        Get
            Return strmEncuestaFin
        End Get
        Set(ByVal dtmValue As DateTime)
            strmEncuestaFin = dtmValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnEncuestaObligatoria
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnEncuestaObligatoria() As Boolean
        Get
            Return blnmchkEncuestaObligatoria
        End Get
        Set(ByVal blnValue As Boolean)
            blnmchkEncuestaObligatoria = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnEncuestaActivo
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnEncuestaActivo() As Boolean
        Get
            Return blnmchkEncuestaActivo
        End Get
        Set(ByVal blnValue As Boolean)
            blnmchkEncuestaActivo = blnValue
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
        If intEncuestaId > 0 Then

            ' Declaramos e inicializamos las constantes locales
            Const intElementsPerPage As Integer = 10
            Const strRecordBrowserName As String = "SucursalEncuestaAgregarEncuestas"

            ' Declaramos e inicializamos las variables locales
            Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
            Dim aobjDataArray As Array = Benavides.CC.Data.clsEncuesta.strBuscarPreguntaEncuesta(0, intEncuestaId, True, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

            ' Generamos el navegador de registros
            Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, aobjDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?intRBintEncuestaId=" & intEncuestaId & "&").Replace("<input name=""cmdNavegadorRegistrosAgregar"" type=""button"" class=""boton"" id=""cmdNavegadorRegistrosAgregar"" value=""Agregar Pregunta"" onclick=""window.location='SucursalEncuestaAgregarEncuestas.aspx?intRBintEncuestaId=" & intEncuestaId & "&amp;strCmd=Agregar'"">", "<input name=""cmdNavegadorRegistrosAgregar"" type=""button"" class=""boton"" id=""cmdNavegadorRegistrosAgregar"" value=""Agregar Pregunta"" onclick=""cmdNavegadorRegistrosAgregar_onclick()"">")

        End If

    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Execute the selected command
        Select Case strCmd

            Case "Eliminar"

                Dim intPreguntaId As Integer = GetPageParameter("intPreguntaId", 0)

                If intEncuestaId > 0 AndAlso intPreguntaId > 0 Then

                    ' Eliminamos la pregunta asociada a la encuesta
                    Call Benavides.CC.Data.clstblPreguntaEncuesta.intActualizar(intPreguntaId, intEncuestaId, False, CDate("01/01/1900"), strUsuarioNombre, strConnectionString)

                    ' Regresamos al usuario al listado de elementos
                    Call Response.Redirect("SucursalEncuestaAgregarEncuestas.aspx?strCmd=Editar&intEncuestaId=" & intEncuestaId)

                End If

            Case "Editar"

                ' Si el identificador del elemento es válido
                If intEncuestaId > 0 Then

                    ' Obtenemos el elemento
                    Dim aobjData As Array = Benavides.CC.Data.clstblEncuesta.strBuscar(intEncuestaId, "", "", CDate("01/01/1900"), CDate("01/01/1900"), False, False, CDate("01/01/1900"), "", 0, 0, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        Dim aobjRow As System.Collections.SortedList = DirectCast(aobjData.GetValue(0), System.Collections.SortedList)

                        ' Recuperamos sus datos
                        intEncuestaId = CInt(aobjRow.Item("intEncuestaId"))
                        strEncuestaNombre = CStr(aobjRow.Item("strEncuestaNombre"))
                        strEncuestaDescripcion = CStr(aobjRow.Item("strEncuestaDescripcion"))
                        dtmEncuestaInicio = CDate(ConvertObject(aobjRow.Item("dtmEncuestaInicio"), TypeCode.DateTime))
                        dtmEncuestaFin = CDate(ConvertObject(aobjRow.Item("dtmEncuestaFin"), TypeCode.DateTime))
                        blnEncuestaObligatoria = CBool(aobjRow.Item("blnEncuestaObligatoria"))
                        blnEncuestaActivo = CBool(aobjRow.Item("blnEncuestaActivo"))

                    End If

                End If

            Case "Salvar"

                Dim blnRedirectToParentPage As Boolean

                ' Si la Encuesta es nueva
                If intEncuestaId = 0 Then

                    ' Agregamos la nueva encuesta
                    intEncuestaId = Benavides.CC.Data.clstblEncuesta.intAgregar(intEncuestaId, strEncuestaNombre, strEncuestaDescripcion, dtmEncuestaInicio, dtmEncuestaFin, blnEncuestaObligatoria, blnEncuestaActivo, CDate("01/01/1900"), strUsuarioNombre, strConnectionString)

                    ' Si la llave del nueva encuesta no es válida
                    If intEncuestaId < 0 Then
                        strJavascriptWindowOnLoadCommands &= "  alert(""ERROR: La información no pudo ser agregada a la base de datos.\n\r\n\rPor favor informe este error a su administrador o personal a cargo."");" & vbCrLf
                        blnRedirectToParentPage = True
                    End If

                Else

                    ' Actualizamos la Encuesta Existente
                    If Benavides.CC.Data.clstblEncuesta.intActualizar(intEncuestaId, strEncuestaNombre, strEncuestaDescripcion, dtmEncuestaInicio, dtmEncuestaFin, blnEncuestaObligatoria, blnEncuestaActivo, CDate("01/01/1900"), strUsuarioNombre, strConnectionString) < 0 Then
                        strJavascriptWindowOnLoadCommands &= "  alert(""ERROR: La información no pudo ser actualizada en la base de datos.\n\r\n\rPor favor informe este error a su administrador o personal a cargo."");" & vbCrLf
                        blnRedirectToParentPage = True
                    End If

                End If

                ' Regresamos al usuario al listado de elementos
                If blnRedirectToParentPage = True Then
                    strJavascriptWindowOnLoadCommands &= " window.location.href = ""SucursalEncuestaAdministrarEncuestas.aspx"";"
                End If

        End Select


    End Sub

End Class
