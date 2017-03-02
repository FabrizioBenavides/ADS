Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

'====================================================================
' Class         : clsSistemaAdministrarAtributos
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : (c) Isocraft 2004 - 2009. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Joaquín Hdz. G. (joaquin@isocraft.com)
' Last Modified : Wednesday, December 15, 2004
'====================================================================

Public Class clsSistemaAdministrarAtributos
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
        intAtributoId = GetPageParameter("txtAtributoId", GetPageParameter("intAtributoId", 0))
        strAtributoNombreId = GetPageParameter("cboAtributoNombreId", "")
        strAtributoNombre = GetPageParameter("txtAtributoNombre", "")
        intAtributoValorLongitudMinima = GetPageParameter("txtAtributoValorLongitudMinima", 0)
        intAtributoValorLongitudMaxima = GetPageParameter("txtAtributoValorLongitudMaxima", 0)
        strAtributoValorMinimo = GetPageParameter("txtAtributoValorMinimo", "")
        strAtributoValorMaximo = GetPageParameter("txtAtributoValorMaximo", "")
        blnAtributoRecapturaObligatoria = GetPageParameter("chkAtributoRecapturaObligatoria", False)
        intTipoAtributoId = GetPageParameter("cboTipoAtributo", 0)
        strAtributoAlgoritmoValidacion = GetPageParameter("cboAtributoAlgoritmoValidacion", "")
        strAtributoDescripcion = GetPageParameter("txtAtributoDescripcion", "")
        blnAtributoActivo = GetPageParameter("chkAtributoActivo", False)
        intSelectedPage = GetPageParameter("intNavegadorRegistrosPagina", GetPageParameter("txtRecordBrowserSelectedPage", 1))

    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private intmAtributoId As Integer
    Private strmAtributoNombreId As String
    Private strmAtributoNombre As String
    Private intmAtributoValorLongitudMinima As Integer
    Private intmAtributoValorLongitudMaxima As Integer
    Private strmAtributoValorMinimo As String
    Private strmAtributoValorMaximo As String
    Private blnmAtributoRecapturaObligatoria As Boolean
    Private intmTipoAtributoId As Integer
    Private strmAtributoAlgoritmoValidacion As String
    Private strmAtributoDescripcion As String
    Private blnmchkAtributoActivo As Boolean
    Private intmSelectedPage As Integer

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
    ' Name       : intAtributoId
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
    ' Name       : intAtributoId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intAtributoId() As Integer
        Get
            Return intmAtributoId
        End Get
        Set(ByVal intValue As Integer)
            intmAtributoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strAtributoNombreId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strAtributoNombreId() As String
        Get
            Return strmAtributoNombreId
        End Get
        Set(ByVal strValue As String)
            strmAtributoNombreId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strAtributoNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strAtributoNombre() As String
        Get
            Return strmAtributoNombre
        End Get
        Set(ByVal strValue As String)
            strmAtributoNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intAtributoValorLongitudMinima
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intAtributoValorLongitudMinima() As Integer
        Get
            Return intmAtributoValorLongitudMinima
        End Get
        Set(ByVal intValue As Integer)
            intmAtributoValorLongitudMinima = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intAtributoValorLongitudMaxima
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intAtributoValorLongitudMaxima() As Integer
        Get
            Return intmAtributoValorLongitudMaxima
        End Get
        Set(ByVal intValue As Integer)
            intmAtributoValorLongitudMaxima = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strAtributoValorMinimo
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property strAtributoValorMinimo() As String
        Get
            Return strmAtributoValorMinimo
        End Get
        Set(ByVal strValue As String)
            strmAtributoValorMinimo = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strAtributoValorMaximo
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property strAtributoValorMaximo() As String
        Get
            Return strmAtributoValorMaximo
        End Get
        Set(ByVal strValue As String)
            strmAtributoValorMaximo = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnAtributoRecapturaObligatoria
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnAtributoRecapturaObligatoria() As Boolean
        Get
            Return blnmAtributoRecapturaObligatoria
        End Get
        Set(ByVal blnValue As Boolean)
            blnmAtributoRecapturaObligatoria = blnValue
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
    ' Name       : strAtributoAlgoritmoValidacion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strAtributoAlgoritmoValidacion() As String
        Get
            Return strmAtributoAlgoritmoValidacion
        End Get
        Set(ByVal strValue As String)
            strmAtributoAlgoritmoValidacion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strAtributoDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strAtributoDescripcion() As String
        Get
            Return strmAtributoDescripcion
        End Get
        Set(ByVal strValue As String)
            strmAtributoDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnAtributoActivo
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnAtributoActivo() As Boolean
        Get
            Return blnmchkAtributoActivo
        End Get
        Set(ByVal blnValue As Boolean)
            blnmchkAtributoActivo = blnValue
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
    ' Name       : strLlenarTipoAtributoComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboTipoAtributo"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarTipoAtributoComboBox() As String
        Dim aobjData As Array = Benavides.CC.Data.clstblTipoAtributo.strBuscar(0, "", "", "", "", "", Now(), "", False, 0, 0, strConnectionString)
        If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then
            For Each aobjRow As System.Collections.SortedList In aobjData
                If CBool(aobjRow.Item("blnTipoAtributoActivo")) = False Then
                    aobjRow.Item("strTipoAtributoNombre") = CStr(aobjRow.Item("strTipoAtributoNombre")) & " (inactivo)"
                End If
            Next
        End If
        Return CreateJavascriptComboBoxOptions("cboTipoAtributo", CStr(intTipoAtributoId), aobjData, "intTipoAtributoId", "strTipoAtributoNombre", 1)
    End Function

    '====================================================================
    ' Name       : strLlenarAtributoNombreIdComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboAtributoNombreId"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarAtributoNombreIdComboBox() As String
        Dim aobjRecords As System.Collections.ArrayList = New System.Collections.ArrayList

        Dim aobjRow As System.Collections.SortedList = New System.Collections.SortedList
        Call aobjRow.Add("strAtributoNombreId", "ClaveAutorizacion")
        Call aobjRow.Add("strAtributoNombre", "Clave de autorización")
        Call aobjRecords.Add(aobjRow)
        aobjRow = Nothing

        aobjRow = New System.Collections.SortedList
        Call aobjRow.Add("strAtributoNombreId", "ClavePadecimiento")
        Call aobjRow.Add("strAtributoNombre", "Clave de padecimiento")
        Call aobjRecords.Add(aobjRow)
        aobjRow = Nothing

        aobjRow = New System.Collections.SortedList
        Call aobjRow.Add("strAtributoNombreId", "Familia")
        Call aobjRow.Add("strAtributoNombre", "Clave familiar")
        Call aobjRecords.Add(aobjRow)
        aobjRow = Nothing

        aobjRow = New System.Collections.SortedList
        Call aobjRow.Add("strAtributoNombreId", "Clinica")
        Call aobjRow.Add("strAtributoNombre", "Clínica")
        Call aobjRecords.Add(aobjRow)
        aobjRow = Nothing

        aobjRow = New System.Collections.SortedList
        Call aobjRow.Add("strAtributoNombreId", "Doctor")
        Call aobjRow.Add("strAtributoNombre", "Doctor")
        Call aobjRecords.Add(aobjRow)
        aobjRow = Nothing

        aobjRow = New System.Collections.SortedList
        Call aobjRow.Add("strAtributoNombreId", "Empleado")
        Call aobjRow.Add("strAtributoNombre", "Empleado")
        Call aobjRecords.Add(aobjRow)
        aobjRow = Nothing

        aobjRow = New System.Collections.SortedList
        Call aobjRow.Add("strAtributoNombreId", "FolioReceta")
        Call aobjRow.Add("strAtributoNombre", "Receta")
        Call aobjRecords.Add(aobjRow)
        aobjRow = Nothing

        aobjRow = New System.Collections.SortedList
        Call aobjRow.Add("strAtributoNombreId", "SinCorrespondencia")
        Call aobjRow.Add("strAtributoNombre", "Sin correspondencia")
        Call aobjRecords.Add(aobjRow)
        aobjRow = Nothing

        Return CreateJavascriptComboBoxOptions("cboAtributoNombreId", strAtributoNombreId, aobjRecords.ToArray(), "strAtributoNombreId", "strAtributoNombre", 1)
    End Function

    '====================================================================
    ' Name       : strLlenarAtributoAlgoritmoValidacionComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboAtributoAlgoritmoValidacion"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarAtributoAlgoritmoValidacionComboBox() As String
        Dim aobjRow As System.Collections.SortedList = New System.Collections.SortedList
        Call aobjRow.Add("intAtributoAlgoritmoValidacionId", 1)
        Call aobjRow.Add("strAtributoAlgoritmoValidacionNombre", "Benavides AV1")
        Dim aobjRecords As System.Collections.ArrayList = New System.Collections.ArrayList
        Call aobjRecords.Add(aobjRow)
        Return CreateJavascriptComboBoxOptions("cboAtributoAlgoritmoValidacion", strAtributoAlgoritmoValidacion, aobjRecords.ToArray(), "intAtributoAlgoritmoValidacionId", "strAtributoAlgoritmoValidacionNombre", 1)
    End Function

    '====================================================================
    ' Name       : strGetRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 20
        Const strRecordBrowserName As String = "SistemaAdministrarAtributos"

        ' Declaramos e inicializamos las variables locales
        Dim astrDataArray As Array = Benavides.CC.Data.clsAtributo.strBuscar(0, 0, "", "", "", 0, 0, "", "", False, "", Now(), "", False, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)
        Dim astrDataRow As Array

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?txtRecordBrowserSelectedPage=" & intSelectedPage & "&")

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
                If intAtributoId > 0 Then

                    ' Obtenemos el elemento
                    Dim aobjData As Array = Benavides.CC.Data.clstblAtributo.strBuscar(intAtributoId, 0, "", "", "", 0, 0, "", "", False, "", Now(), strUsuarioNombre, False, 0, 0, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        Dim aobjRow As System.Collections.SortedList = DirectCast(aobjData.GetValue(0), System.Collections.SortedList)

                        ' Recuperamos sus datos
                        intAtributoId = CInt(aobjRow.Item("intAtributoId"))
                        intTipoAtributoId = CInt(aobjRow.Item("intTipoAtributoId"))
                        strAtributoNombreId = CStr(aobjRow.Item("strAtributoNombreId"))
                        strAtributoNombre = CStr(aobjRow.Item("strAtributoNombre"))
                        strAtributoDescripcion = CStr(aobjRow.Item("strAtributoDescripcion"))
                        intAtributoValorLongitudMinima = CInt(aobjRow.Item("intAtributoValorLongitudMinima"))
                        intAtributoValorLongitudMaxima = CInt(aobjRow.Item("intAtributoValorLongitudMaxima"))
                        strAtributoValorMinimo = CStr(aobjRow.Item("strAtributoValorMinimo"))
                        strAtributoValorMaximo = CStr(aobjRow.Item("strAtributoValorMaximo"))
                        blnAtributoRecapturaObligatoria = CBool(aobjRow.Item("blnAtributoRecapturaObligatoria"))
                        strAtributoAlgoritmoValidacion = CStr(aobjRow.Item("strAtributoAlgoritmoValidacion"))
                        blnAtributoActivo = CBool(aobjRow.Item("blnAtributoActivo"))

                    End If

                End If

            Case "Salvar"

                ' Si el tipo de atributo es nuevo
                If intAtributoId = 0 AndAlso intTipoAtributoId > 0 Then

                    ' Agregamos el nuevo tipo de atributo
                    If Benavides.CC.Data.clstblAtributo.intAgregar(intAtributoId, intTipoAtributoId, strAtributoNombreId, strAtributoNombre, strAtributoDescripcion, intAtributoValorLongitudMinima, intAtributoValorLongitudMaxima, strAtributoValorMinimo, strAtributoValorMaximo, blnAtributoRecapturaObligatoria, strAtributoAlgoritmoValidacion, Now(), strUsuarioNombre, blnAtributoActivo, strConnectionString) < 0 Then
                        strJavascriptWindowOnLoadCommands &= "  alert(""ERROR: La información no pudo ser agregada a la base de datos.\n\r\n\rPor favor informe este error a su administrador o personal a cargo."");" & vbCrLf
                    End If

                ElseIf intAtributoId > 0 AndAlso intTipoAtributoId > 0 Then

                    ' Actualizamos el tipo de atributo existente
                    If Benavides.CC.Data.clstblAtributo.intActualizar(intAtributoId, intTipoAtributoId, strAtributoNombreId, strAtributoNombre, strAtributoDescripcion, intAtributoValorLongitudMinima, intAtributoValorLongitudMaxima, strAtributoValorMinimo, strAtributoValorMaximo, blnAtributoRecapturaObligatoria, strAtributoAlgoritmoValidacion, Now(), strUsuarioNombre, blnAtributoActivo, strConnectionString) < 0 Then
                        strJavascriptWindowOnLoadCommands &= "  alert(""ERROR: La información no pudo ser actualizada en la base de datos.\n\r\n\rPor favor informe este error a su administrador o personal a cargo."");" & vbCrLf
                    End If

                End If

                ' Limpiamos los valores de los campos de la forma
                intAtributoId = 0
                intTipoAtributoId = 0
                strAtributoNombreId = ""
                strAtributoNombre = ""
                strAtributoDescripcion = ""
                intAtributoValorLongitudMinima = 0
                intAtributoValorLongitudMaxima = 0
                strAtributoValorMinimo = ""
                strAtributoValorMaximo = ""
                blnAtributoRecapturaObligatoria = False
                strAtributoAlgoritmoValidacion = ""
                blnAtributoActivo = False

        End Select

    End Sub

End Class
