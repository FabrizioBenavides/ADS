'====================================================================
' Class         : clsListadoParaInventariosRotativos
' Title         : Grupo Benavides. Inventarios Rotativos
' Description   : Listado para inventarios rotativos
' Copyright     : 2003-2006 All rights reserved.
' Company       : Neitek Solutions S.A. de C.V.
' Author        : Carolina Caballero
' Version       : 1.0
' Last Modified : Monday, Oct 11, 2004
'====================================================================

Imports System.Text
Imports System.Collections

Imports prjCCInventarioBusiness.Benavides.InvRot.Utils
Imports prjCCInventarioBusiness.Benavides.InvRot.Data

Public Class clsListadoParaInventariosRotativos
    Inherits System.Web.UI.Page
    Implements PrintInterface

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
    End Sub

#End Region

    ' Variables locales privadas
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private _intListadoId As Integer
    'Private _strNombre As String
    Private _intOrdenamiento As Integer
    Protected WithEvents txtListadoNombre As System.Web.UI.HtmlControls.HtmlInputText


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
    ' Name       : intGrupoUsuarioId
    ' Description: Identificador del Grupo de Usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
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
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime(clsDateUtil.DATE_HOUR_FORMAT)
        End Get
    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: URL de esta página
    ' Accessor   : Read
    ' Throws     : Ninguna
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
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: Establece los comandos Javascript del evento OnLoad
    ' Accessor   : Read
    ' Throws     : Ninguna
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
    ' Description: Obtiene o establece el comando actual
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strCmd() As String
        Get
            Return strmCommand
        End Get
        Set(ByVal strValue As String)
            strmCommand = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : txtOrdenamiento
    ' Description: Nombre del listado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property txtOrdenamiento() As String
        Get
            Return CStr(com.isocraft.commons.clsWeb.strGetPageParameter("txtOrdenamiento", ""))
        End Get
    End Property

    '====================================================================
    ' Name       : intListadoId 
    ' Description: Obtiene o establece el listado id
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intListadoId() As Integer
        Get
            Return _intListadoId
        End Get
        Set(ByVal strValue As Integer)
            _intListadoId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intOrdenamiento
    ' Description: Obtiene o establece el ordenamiento del listado seleccionado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intOrdenamiento() As Integer
        Get
            Return _intOrdenamiento
        End Get
        Set(ByVal strValue As Integer)
            _intOrdenamiento = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : rbOrdenamientoChecked
    ' Description: Obtiene si el radio button esta seleccionado o no
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function rbOrdenamientoChecked(ByVal sel As Integer) As String
        If sel = Me.intOrdenamiento Then
            Return "checked"
        End If
        Return ""

    End Function


    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 1
        Dim strRecordBrowserName As String = "ListadoParaInventariosRotativos"

        ' Declaramos e inicialziamos las variables locales
        Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        If intSelectedPage <= 0 Then
            'intSelectedPage = 1
            intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
        End If
        Dim dataArray As Array = Nothing

        ' Obtenemos los listados que ya se han capturado previamente.
        dataArray = clstblListado.strBuscar(1, intElementsPerPage, strConnectionString)

        Dim headers As ArrayList = New ArrayList()
        headers.Add("Identificador")
        headers.Add("Nombre")
        headers.Add("Ordenamiento")
        headers.Add("Acciones")

        Dim columnOrder As Integer() = {0, 1, 2}

        Dim actions As ArrayList = New ArrayList()
        Dim pkNames As String() = {"intListadoId"}
        Dim pkIndexes As Integer() = {0}
        actions.Add(New clsActionLink("Editar", pkNames, pkIndexes, "imgNREditar.gif", "Haga clic aquí para editar este listado"))
        actions.Add(New clsActionLink("Borrar", pkNames, pkIndexes, "imgNRborrar.gif", "Haga clic aquí para borrar este listado"))


        Dim htmlResult As String = ""
        Dim maxPerPage As Integer = 10
        htmlResult = clsHTMLUtils.displayScroll(dataArray.Length, intSelectedPage, maxPerPage, "ListadoParaInventariosRotativos.aspx", Nothing)
        htmlResult += clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, intSelectedPage, maxPerPage, -1)

        Return htmlResult



    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        strCmd = com.isocraft.commons.clsWeb.strGetPageParameter("strCmd", com.isocraft.commons.clsWeb.strGetPageParameter("cmdConsultar", ""), Request)

        ' Almacenamos el id del listado seleccionado
        intListadoId = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intListadoId", "0", Request))

        'Consultamos los listados
        'Dim astrRecords As Array = clstblListado.strBuscar(0, 10, strConnectionString)


        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Agregar"
                Dim newValue As String = clsStringUtil.FormatValueToDB(Me.txtListadoNombre.Value)

                clstblListado.intAgregar(newValue, CInt(Me.txtOrdenamiento), Now, Me.strUsuarioNombre, Me.strConnectionString)
                Me.txtListadoNombre.Value = ""
                Me.intListadoId = 0
            Case "Editar"
                Dim values As Array
                values = clstblListado.strBuscar(intListadoId, Me.strConnectionString)
                Dim row As Array
                row = CType(values.GetValue(0), Array)
                Me.intListadoId = CInt(row.GetValue(0))               'listadoId
                Me.txtListadoNombre.Value = row.GetValue(1).ToString     'nombre
                Me.intOrdenamiento = CInt(row.GetValue(2))            'ordenamiento
                'Me.strNombre = clsStringUtil.FormatValueToScreen(Me.strNombre)

            Case "Guardar"
                Dim newValue As String = clsStringUtil.FormatValueToDB(Me.txtListadoNombre.Value)

                clstblListado.intActualizar(intListadoId, newValue, CInt(Me.txtOrdenamiento), Now, Me.strUsuarioNombre, Me.strConnectionString)

                Me.txtListadoNombre.Value = ""
                Me.intListadoId = 0
            Case "Imprimir"
                Session.Add("printDocument", Me)
                Dim script As String = "<script for=window event=onload>printDocument()</script>"
                Page.RegisterClientScriptBlock("openWindowScript", script)


            Case "Borrar"
                If intListadoId > 0 Then
                    'verificar si no hay registros relacionados
                    Dim regRelacionados As Integer = clstblListado.intContarRelacionados(intListadoId, strConnectionString)

                    ' Eliminamos el listado
                    If regRelacionados <= 0 Then
                        clstblListado.intEliminar(intListadoId, Now, Me.strUsuarioNombre, strConnectionString)
                    Else
                        Dim script As String = "<script for=window event=onload>showError('El listado seleccionado no puede borrarse, ya que tiene registros relacionados.')</script>"
                        Page.RegisterClientScriptBlock("openWindowScript", script)
                    End If
                    Me.txtListadoNombre.Value = ""
                    Me.intListadoId = 0

                End If
        End Select
    End Sub

#Region "metodos de la interface PrintInterface"

    Function addPagination() As Boolean Implements PrintInterface.addPagination
        Return True
    End Function

    Function getHeaders() As String Implements PrintInterface.getHeaders
        Dim code As StringBuilder = New StringBuilder()
        Dim widths As String() = {"20%", "60%", "20%"}
        Dim values As String() = {"Identificador", "Nombre", "Ordenamiento"}

        code.Append(clsHTMLUtils.getTagTR("th", 3, "rayita", "txcont", widths, values))

        Return code.ToString
    End Function

    Function getTitle(ByVal currentPage As Integer, ByVal totalPages As Integer) As String Implements PrintInterface.getTitle
        Dim code As StringBuilder = New StringBuilder()
        Dim widths As String() = {"70%", "10%", "20%"}
        Dim styles As String() = {"txtitulo", "txcontenidobold", "txcontenidobold"}
        Dim values1 As String() = {"Reporte de Listados para Inventarios Rotativos", "", "HOJA: " + currentPage.ToString + " / " + totalPages.ToString}
        Dim values2 As String() = {"", "", "Fecha: " + Today.ToString(clsDateUtil.DATE_FORMAT)}

        code.Append(clsHTMLUtils.BEGIN_TABLE)
        code.Append(clsHTMLUtils.getTagTR("td", 3, styles, widths, values1))
        code.Append(clsHTMLUtils.getTagTR("td", 3, "txcontenidobold", widths, values2))
        code.Append(clsHTMLUtils.END_TABLE)

        Return code.ToString
    End Function

    Function getRow(ByVal aRow As Array, ByVal globalRowCounter As Integer) As String Implements PrintInterface.getRow
        Dim colsToShow As Integer() = {0, 1, 2}
        Return clsPrintUtil.getSimpleRow(aRow, colsToShow)


    End Function

    Function getFooter() As String Implements PrintInterface.getFooter
        Return ""
    End Function

    Function getData() As Array Implements PrintInterface.getData
        Dim dataArray As Array = Nothing

        ' Obtenemos los listados que ya se han capturado previamente.
        dataArray = clstblListado.strBuscar(1, 1, strConnectionString)

        Return dataArray
    End Function

    Function getColumnNumber() As Integer Implements PrintInterface.getColumnNumber
        Return 3
    End Function

#End Region

End Class

