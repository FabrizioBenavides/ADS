Imports Isocraft.Web.Http

'====================================================================
' Class         : clsSistemaAdministrarTiposAtributos
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : (c) Isocraft 2004 - 2009. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Joaquín Hdz. G. (joaquin@isocraft.com)
' Last Modified : Wednesday, December 15, 2004
'====================================================================

Public Class clsSistemaAdministrarTiposAtributos
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
        strTipoAtributoNombreId = GetPageParameter("txtTipoAtributoNombreId", "")
        strTipoAtributoNombre = GetPageParameter("txtTipoAtributoNombre", "")
        strTipoAtributoCaracteresPermitidos = GetPageParameter("txtTipoAtributoCaracteresPermitidos", "")
        strTipoAtributoFormato = GetPageParameter("txtTipoAtributoFormato", "")
        strTipoAtributoDescripcion = GetPageParameter("txtTipoAtributoDescripcion", "")
        intTipoAtributoId = GetPageParameter("txtTipoAtributoId", GetPageParameter("intTipoAtributoId", 0))
        blnTipoAtributoActivo = GetPageParameter("chkTipoAtributoActivo", False)
    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private strmtxtTipoAtributoNombreId As String
    Private strmtxtTipoAtributoNombre As String
    Private strmtxtTipoAtributoCaracteresPermitidos As String
    Private strmtxtTipoAtributoFormato As String
    Private strmtxtTipoAtributoDescripcion As String
    Private blnmchkTipoAtributoActivo As Boolean
    Private intmTipoAtributoId As Integer

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
    ' Name       : strTipoAtributoNombreId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTipoAtributoNombreId() As String
        Get
            Return strmtxtTipoAtributoNombreId
        End Get
        Set(ByVal strValue As String)
            strmtxtTipoAtributoNombreId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoAtributoNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTipoAtributoNombre() As String
        Get
            Return strmtxtTipoAtributoNombre
        End Get
        Set(ByVal strValue As String)
            strmtxtTipoAtributoNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoAtributoCaracteresPermitidos
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTipoAtributoCaracteresPermitidos() As String
        Get
            Return strmtxtTipoAtributoCaracteresPermitidos
        End Get
        Set(ByVal strValue As String)
            strmtxtTipoAtributoCaracteresPermitidos = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoAtributoFormato
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTipoAtributoFormato() As String
        Get
            Return strmtxtTipoAtributoFormato
        End Get
        Set(ByVal strValue As String)
            strmtxtTipoAtributoFormato = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoAtributoDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTipoAtributoDescripcion() As String
        Get
            Return strmtxtTipoAtributoDescripcion
        End Get
        Set(ByVal strValue As String)
            strmtxtTipoAtributoDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnTipoAtributoActivo
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property blnTipoAtributoActivo() As Boolean
        Get
            Return blnmchkTipoAtributoActivo
        End Get
        Set(ByVal blnValue As Boolean)
            blnmchkTipoAtributoActivo = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : intTipoAtributoId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intTipoAtributoId() As Integer
        Get
            Return intmTipoAtributoId
        End Get
        Set(ByVal intValue As Integer)
            intmTipoAtributoId = intValue
        End Set
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
    ' Name       : strGetRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 10
        Const strRecordBrowserName As String = "SistemaAdministrarTiposAtributos"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim astrDataArray As Array = Benavides.CC.Data.clstblTipoAtributo.strBuscar(0, "", "", "", "", "", Now(), "", False, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?")

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
                If intTipoAtributoId > 0 Then

                    ' Obtenemos el elemento
                    Dim aobjData As Array = Benavides.CC.Data.clstblTipoAtributo.strBuscar(intTipoAtributoId, "", "", "", "", "", Now(), "", False, 0, 0, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        Dim aobjRow As System.Collections.SortedList = DirectCast(aobjData.GetValue(0), System.Collections.SortedList)

                        ' Recuperamos sus datos
                        intTipoAtributoId = CInt(aobjRow.Item("intTipoAtributoId"))
                        strTipoAtributoNombreId = CStr(aobjRow.Item("strTipoAtributoNombreId"))
                        strTipoAtributoNombre = CStr(aobjRow.Item("strTipoAtributoNombre"))
                        strTipoAtributoDescripcion = CStr(aobjRow.Item("strTipoAtributoDescripcion"))
                        strTipoAtributoCaracteresPermitidos = CStr(aobjRow.Item("strTipoAtributoCaracteresPermitidos"))
                        strTipoAtributoFormato = CStr(aobjRow.Item("strTipoAtributoFormato"))
                        blnTipoAtributoActivo = CBool(aobjRow.Item("blnTipoAtributoActivo"))

                    End If

                End If

            Case "Salvar"

                ' Si el tipo de atributo es nuevo
                If intTipoAtributoId = 0 Then

                    ' Agregamos el nuevo tipo de atributo
                    If Benavides.CC.Data.clstblTipoAtributo.intAgregar(intTipoAtributoId, strTipoAtributoNombreId, strTipoAtributoNombre, strTipoAtributoDescripcion, strTipoAtributoCaracteresPermitidos, strTipoAtributoFormato, Now(), strUsuarioNombre, blnTipoAtributoActivo, strConnectionString) < 0 Then
                        strJavascriptWindowOnLoadCommands &= "  alert(""ERROR: La información no pudo ser agregada a la base de datos.\n\r\n\rPor favor informe este error a su administrador o personal a cargo."");" & vbCrLf
                    End If

                Else

                    ' Actualizamos el tipo de atributo existente
                    If Benavides.CC.Data.clstblTipoAtributo.intActualizar(intTipoAtributoId, strTipoAtributoNombreId, strTipoAtributoNombre, strTipoAtributoDescripcion, strTipoAtributoCaracteresPermitidos, strTipoAtributoFormato, Now(), strUsuarioNombre, blnTipoAtributoActivo, strConnectionString) < 0 Then
                        strJavascriptWindowOnLoadCommands &= "  alert(""ERROR: La información no pudo ser actualizada en la base de datos.\n\r\n\rPor favor informe este error a su administrador o personal a cargo."");" & vbCrLf
                    End If

                End If

                ' Limpiamos los valores de los campos de la forma
                intTipoAtributoId = 0
                strTipoAtributoNombreId = ""
                strTipoAtributoNombre = ""
                strTipoAtributoDescripcion = ""
                strTipoAtributoCaracteresPermitidos = ""
                strTipoAtributoFormato = ""
                blnTipoAtributoActivo = False

        End Select

    End Sub

End Class
