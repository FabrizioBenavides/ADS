Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert

Public Class SucursalEncuestaAsignarEncuestas
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

        intEncuestaId = GetPageParameter("intEncuestaId", GetPageParameter("txtEncuestaId", 0))
        strEncuestaNombre = GetPageParameter("txtEncuestaNombre", "")
        strEncuestaDescripcion = GetPageParameter("txtEncuestaDescripcion", "")

        dtmEncuestaInicio = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(GetPageParameter("txtEncuestaInicio", Now().ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture))))
        dtmEncuestaFin = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(GetPageParameter("txtEncuestaFin", Now().ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture))))

        blnEncuestaObligatoria = GetPageParameter("chkEncuestaObligatoria", False)
        blnEncuestaActivo = GetPageParameter("chkEncuestaActivo", False)

        intCompaniaId = GetPageParameter("intCompaniaId", 0)
        intSucursalId = GetPageParameter("intSucursalId", 0)

        strJavascriptWindowOnLoadCommands = ""

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

    Private intmCompaniaId As Integer
    Private intmSucursalId As Integer

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
    ' Name       : intCompaniaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intCompaniaId() As Integer
        Get
            Return intmCompaniaId
        End Get
        Set(ByVal intValue As Integer)
            intmCompaniaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intSucursalId() As Integer
        Get
            Return intmSucursalId
        End Get
        Set(ByVal intValue As Integer)
            intmSucursalId = intValue
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

        If intEncuestaId > 0 Then

            ' Declaramos e inicializamos las constantes locales
            Const intElementsPerPage As Integer = 50
            Const strRecordBrowserName As String = "SucursalEncuestaAsignarEncuestas"

            ' Declaramos e inicializamos las variables locales
            Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
            Dim astrDataArray As Array = Benavides.CC.Data.clsEncuesta.strBuscarSucursales(intEncuestaId, 0, 0, True, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)


            ' Establecemos los párametros adicionales de los números de página
            Dim strQueryString As String = _
                "txtEncuestaId=" & intEncuestaId & _
                "&txtEncuestaNombre=" & Trim(strEncuestaNombre) & _
                "&txtEncuestaDescripcion=" & Trim(strEncuestaDescripcion) & _
                "&txtEncuestaInicio=" & dtmEncuestaInicio.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) & _
                "&txtEncuestaFin=" & dtmEncuestaFin.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) & _
                "&chkEncuestaObligatoria=" & blnEncuestaObligatoria & _
                "&chkEncuestaActivo=" & blnEncuestaActivo & _
                "&strRBCmd=Editar"

            ' Agregamos los botones para asignar y borrar sucursales
            Dim strTextToBeReplaced As String = "<span class=""txsubtitulo""><img src=""../static/images/bullet_subtitulos.gif"" width=""17"" height=""11"" align=""absmiddle"">Sucursales asignadas</span>"
            Dim strNewText As String = "<span class=""txsubtitulo""><img src=""../static/images/bullet_subtitulos.gif"" width=""17"" height=""11"" align=""absmiddle"">Sucursales asignadas</span><input name=""cmdAsignarSucursales"" type=""button"" class=""button"" id=""cmdAsignarSucursales"" value=""Asignar sucursales"" language=javascript onclick=""return cmdAsignarSucursales_onclick()""/>&nbsp;&nbsp;<input name=""cmdBorrarTodasSucursales"" type=""submit"" class=""button"" id=""cmdBorrarTodasSucursales"" value=""Borrar todas"" language=javascript onclick=""return cmdBorrarTodasSucursales_onclick()""/><br />"

            ' Generamos el navegador de registros
            Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?" & strQueryString & "&").Replace(strTextToBeReplaced, strNewText)

        End If

    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Check if the current user can access this page
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Execute the selected command
        Select Case strCmd

            Case "Editar"

                ' Si el identificador del elemento es válido
                If intEncuestaId > 0 Then

                    ' Obtenemos el elemento
                    Dim aobjData As Array = Benavides.CC.Data.clstblEncuesta.strBuscar(intEncuestaId, "", "", CDate("01/01/1900"), CDate("01/01/1900"), False, True, CDate("01/01/1900"), "", 0, 0, strConnectionString)

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

                Else

                    ' Identificador inválido, direccionamos al usuario a la página padre
                    Call Response.Redirect("SucursalEncuestaAdministrarEncuestas.aspx")

                End If

            Case "Eliminar"

                ' Si el identificador del elemento es válido, eliminamos las sucursales del cliente
                If intEncuestaId > 0 AndAlso intCompaniaId > 0 AndAlso intSucursalId > 0 Then

                    ' Buscamos el registro a eliminar
                    Dim aobjData As Array = Benavides.CC.Data.clstblSucursalEncuesta.strBuscar(intCompaniaId, intSucursalId, intEncuestaId, False, CDate("01/01/1900"), "", 0, 0, strConnectionString)

                    ' Si el registro existe
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        ' Eliminamos el registro
                        Call Benavides.CC.Data.clstblSucursalEncuesta.intActualizar(intCompaniaId, intSucursalId, intEncuestaId, False, CDate("01/01/1900"), strUsuarioNombre, strConnectionString)

                    End If

                End If

            Case "EliminarSucursales"

                ' Si el identificador del elemento es válido, eliminamos las sucursales de la Encuesta
                If intEncuestaId > 0 Then

                    ' Buscamos los registros a eliminar
                    Dim aobjData As Array = Benavides.CC.Data.clstblSucursalEncuesta.strBuscar(0, 0, intEncuestaId, True, CDate("01/01/1900"), strUsuarioNombre, 0, 0, strConnectionString)

                    ' Si los registros existen
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        ' Eliminamos los registros
                        Call Benavides.CC.Data.clstblSucursalEncuesta.intActualizar(0, 0, intEncuestaId, False, CDate("01/01/1900"), strUsuarioNombre, strConnectionString)

                    End If

                End If

            Case Else

                ' Comando inválido, direccionamos al usuario a la página padre
                Call Response.Redirect("SucursalEncuestaAdministrarEncuestas.aspx")

        End Select

    End Sub

End Class
