'====================================================================
' Class         : clsImportarDatosParaInventariosRotativos
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Importacion de datos para la facilitacion de captura
'                 de inventarios rotativos=
' Copyright     : 2003-2006 All rights reserved.
' Company       : Neitek Solutions S.A. de C.V.
' Author        : Carolina Caballero
' Version       : 1.0
' Last Modified : Tuesday, Oct 14, 2004
'====================================================================

Imports System.Text
Imports System.Collections

Imports prjCCInventarioBusiness.Benavides.InvRot.Utils
Imports prjCCInventarioBusiness.Benavides.InvRot.Data

Public Class clsImportarDatosParaInventariosRotativos
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
        status = OK
    End Sub

#End Region

    Public Const OK As Integer = 1
    Public Const ERROR_ON_LOAD As Integer = 2

    ' Variables locales privadas
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private _intListadoId As Integer
    'Private _strNombre As String
    Protected WithEvents txtListadoNombre As System.Web.UI.HtmlControls.HtmlInputText

    Protected WithEvents Document As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents ButtonPrevio As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents ButtonImportar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents ButtonLimpiar As System.Web.UI.HtmlControls.HtmlInputButton
    'Private WithEvents intListadoId As System.Web.UI.HtmlControls.HtmlInputHidden

    Private status As Integer = OK
    Private errorMessage As String = ""

    Protected WithEvents uploadListadoId As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents uploadFecha As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents uploadUser As System.Web.UI.HtmlControls.HtmlInputHidden
    Private uploadJustDone As Boolean = False
    Private uploadTotalRecords As Integer = 0


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
    ' Name       : txtListadoNombre
    ' Description: Nombre del listado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    'Public ReadOnly Property txtListadoNombre() As String
    '    Get
    '        Return CStr(com.isocraft.commons.clsWeb.strGetPageParameter("txtListadoNombre", ""))
    '    End Get
    'End Property

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

    ''====================================================================
    '' Name       : strNombre
    '' Description: Obtiene o establece el nombre del listado
    '' Accessor   : Read, Write
    '' Throws     : Ninguna
    '' Output     : String
    ''====================================================================
    'Public Property strNombre() As String
    '    Get
    '        Return _strNombre
    '    End Get
    '    Set(ByVal strValue As String)
    '        _strNombre = strValue
    '    End Set
    'End Property


    '====================================================================
    ' Name       : strVistaPreviaHTML
    ' Description: Regresa el HTML con los registros de la vista previa
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strVistaPreviaHTML() As String
        Dim htmlResult As String = ""

        If Me.status = Me.ERROR_ON_LOAD Then
            htmlResult = "<table width='100%' border='0' cellpadding='0' cellspacing='0'>"
            htmlResult += "<tr><td width='100%' class='txredbold12' >La vista previa no pudo realizarse, debido al siguiente error:</td></tr>"
            htmlResult += "<tr><td width='100%' class='tdcontentableblue' >"
            htmlResult += Me.errorMessage
            htmlResult += "</td></tr></table>"

            '
        ElseIf (Me.uploadListadoId.Value.Length > 0 AndAlso Not Me.uploadListadoId.Value = "0") Then
            'construir la vista previa

            ' Declaramos e inicializamos las constantes locales
            Const intElementsPerPage As Integer = 1

            ' Declaramos e inicialziamos las variables locales
            Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegador2RegistrosPagina", "0", Request))
            If intSelectedPage <= 0 Then
                'intSelectedPage = 1
                intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intListado2CurrentPage", "1", Request))
            End If
            Dim dataArray As Array = Nothing

            ' Obtenemos los listados de la tabla temporal.
            dataArray = clsImportar.strBuscarAgrupados( _
                        CInt(Me.uploadListadoId.Value), _
                        clsDateUtil.StringToDate(Me.uploadFecha.Value, clsDateUtil.DATE_HOUR_FORMAT), _
                        Me.uploadUser.Value, _
                        100, _
                        strConnectionString)

            Dim headers As ArrayList = New ArrayList()
            headers.Add("Compañía")
            headers.Add("Sucursal")
            headers.Add("Fecha Toma Inventario")
            headers.Add("# Registros")
            headers.Add("Acciones")

            Dim columnOrder As Integer() = {0, 1, 3, 5}

            Dim pkNames As String() = {"intCompaniaId", "intSucursalId", "intListadoId", "dtmArticuloListadoFechaTomaInventario", "dtmArticuloListadoUltimaModificacion"}
            Dim pkIndexes As Integer() = {0, 1, 2, 3, 4}
            Dim actions As ArrayList = New ArrayList()
            actions.Add(New clsActionLink("MostrarRegistros", pkNames, pkIndexes, "icono_ver.gif", "Haga clic aquí para seleccionar este listado para realizar la carga de datos"))


            Dim maxPerPage As Integer = 10
            htmlResult = clsHTMLUtils.displayScroll(dataArray.Length, intSelectedPage, maxPerPage, "ImportarDatosParaInventariosRotativos.aspx", Nothing, "intNavegador2RegistrosPagina")
            htmlResult += clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, intSelectedPage, maxPerPage, 100, "intListado2CurrentPage")

        ElseIf uploadJustDone Then

            htmlResult = "<table width='100%' border='0' cellpadding='0' cellspacing='0'>"
            htmlResult += "<tr><td width='100%' class='txredbold12' >La importación se realizó con éxito</td></tr>"
            htmlResult += "<tr><td width='100%' class='tdcontentableblue' > Se cargaron : "
            htmlResult += uploadTotalRecords.ToString
            htmlResult += " registros."
            htmlResult += "</td></tr></table>"


        End If


        Return htmlResult
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
        Dim strRecordBrowserName As String = "ImportarDatosParaInventariosRotativos"

        ' Declaramos e inicialziamos las variables locales
        Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        If intSelectedPage <= 0 Then
            'intSelectedPage = 1
            intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
        End If
        Dim dataArray As Array = Nothing

        ' Obtenemos los listados que ya se han capturado previamente.
        dataArray = clsImportar.strBuscarListados(1, intElementsPerPage, strConnectionString)

        Dim headers As ArrayList = New ArrayList()
        headers.Add("Identificador")
        headers.Add("Nombre")
        headers.Add("Ordenamiento")
        headers.Add("# Registros Cargados")
        headers.Add("Acciones")

        Dim columnOrder As Integer() = {0, 1, 2, 3}

        Dim actions As ArrayList = New ArrayList()
        Dim pkNames As String() = {"intListadoId"}
        Dim pkIndexes As Integer() = {0}
        actions.Add(New clsActionLink("Seleccionar", pkNames, pkIndexes, "imgNREditar.gif", "Haga clic aquí para seleccionar este listado para realizar la carga de datos"))
        actions.Add(New clsActionLink("Borrar", pkNames, pkIndexes, "imgNRborrar.gif", "Haga clic aquí para borrar los registros relacionados a este listado"))


        Dim htmlResult As String = ""
        Dim maxPerPage As Integer = 10
        htmlResult = clsHTMLUtils.displayScroll(dataArray.Length, intSelectedPage, maxPerPage, "ImportarDatosParaInventariosRotativos.aspx", Nothing)
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

        intListadoId = CInt(Request("intListadoId"))


        'habilitar y deshabilitar botones
        Me.ButtonImportar.Disabled = True
        Me.ButtonPrevio.Disabled = False

        ' Ejecutamos el comando indicado
        Select Case strCmd
            Case "Seleccionar"
                Me.displaySelected(True)

            Case "Borrar"
                'Borrar registros
                Me.deleteRecords()

        End Select
    End Sub

    Private Sub displaySelected(ByVal clearVariables As Boolean)
        'seleccionar listado para importar datos
        Dim values As Array
        values = clstblListado.strBuscar(Me.intListadoId, Me.strConnectionString)
        Dim row As Array
        row = CType(values.GetValue(0), Array)
        'Me.intListadoId = row.GetValue(0)                      'listadoId
        Me.txtListadoNombre.Value = row.GetValue(1).ToString    'nombre

        If clearVariables Then
            Me.limpiar(False)
        End If

    End Sub


    Public Sub cargaPrevia(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonPrevio.ServerClick
        Me.status = OK
        Me.errorMessage = ""

        If (Me.intListadoId <= 0) Then
            'no se selecciono un listado
            Me.status = Me.ERROR_ON_LOAD
            Me.errorMessage = "Debe de seleccionar un listado para realizar la vista previa."
        ElseIf (Me.Document.PostedFile.FileName.ToString = "") Then
            'no se selecciono un archivo
            Me.status = Me.ERROR_ON_LOAD
            Me.errorMessage = "Debe de seleccionar un archivo para realizar la vista previa."
        ElseIf (Not Me.Document.PostedFile.FileName.ToString.EndsWith(".csv")) Then
            'no se selecciono un archivo
            Me.status = Me.ERROR_ON_LOAD
            Me.errorMessage = "Debe de seleccionar un archivo con formato .csv"

        Else
            'proceder con la importacion

            'habilitar y deshabilitar botones
            Me.ButtonImportar.Disabled = False
            Me.ButtonPrevio.Disabled = True

            'borrar los registros relacionados con el listado, que se hayan capturado previamente
            clsImportar.intBorrarDelTemporal(Me.intListadoId, Me.strConnectionString)

            'realizar la vista previa
            Dim istream As System.IO.Stream
            Dim allBytes As Byte()
            Dim allData As String
            Dim contentLenth As Integer = Me.Document.PostedFile.ContentLength()

            ReDim allBytes(contentLenth)
            istream = Me.Document.PostedFile.InputStream()
            istream.Read(allBytes, 0, contentLenth)
            allData = System.Text.Encoding.Default.GetString(allBytes)
            istream.Close()

            Me.loadTemporalData(allData, Me.intListadoId)

            Me.displaySelected(False)

        End If



    End Sub

    'compania, sucursal, codigoArticulo, fechaTomaInventario
    Protected Sub loadTemporalData(ByVal data As String, ByVal listadoId As Integer)
        'cargalos en la tabla temporal
        Try

            Dim allRows As String() = data.Split(CChar(vbCrLf))
            Dim index As Integer
            Dim currentTime As DateTime = Now

            Me.uploadFecha.Value = currentTime.ToString(clsDateUtil.DATE_HOUR_FORMAT)
            Me.uploadListadoId.Value = listadoId.ToString
            Me.uploadUser.Value = Me.strUsuarioNombre

            For index = 0 To allRows.Length - 1
                Dim row As String = allRows(index)

                If row Is Nothing OrElse row = String.Empty OrElse row.Equals(vbCrLf) OrElse row.IndexOf(",") = -1 Then
                    Exit For
                End If

                Dim cols As String() = row.Split(CChar(","))
                Dim companiaId As Integer
                Dim sucursalId As Integer
                Dim articuloId As Integer
                Dim fecha As Date

                Try
                    companiaId = Integer.Parse(cols(0))      'compania
                Catch ex1 As Exception
                    Throw New Exception("En el registro # " + (index + 1).ToString + ": el valor de la Companía '" + cols(0) + "' no es un número válido.")
                End Try


                Try
                    sucursalId = Integer.Parse(cols(1))      'sucursal
                Catch ex1 As Exception
                    Throw New Exception("En el registro # " + (index + 1).ToString + ": el valor de la Sucursal '" + cols(1) + "' no es un número válido.")
                End Try

                Try
                    articuloId = Integer.Parse(cols(2))      'codigoArticulo
                Catch ex1 As Exception
                    Throw New Exception("En el registro # " + (index + 1).ToString + ": el valor del Artículo '" + cols(2) + "' no es un número válido.")
                End Try

                Try
                    fecha = clsDateUtil.StringToDate(cols(3), clsDateUtil.DATE_FORMAT)  'fechaTomaInventario
                Catch ex1 As Exception
                    Throw New Exception("En el registro # " + (index + 1).ToString + ": el valor de Fecha de Toma de Inventario '" + cols(3) + "' no es una fecha válida, usar formato '" + clsDateUtil.DATE_FORMAT + "'.")
                End Try


                'buscar si ya existe primero
                'si ya existe, hacer un update.

                Try
                    clsImportar.intActualizarOAgregar(companiaId, sucursalId, listadoId, fecha, articuloId, 0, currentTime, Me.strUsuarioNombre, Me.strConnectionString)
                Catch ex1 As Exception
                    Throw New Exception("Error al cargar el registro en la base de datos. Alguno de los datos no coincide, favor de verificarlo. " _
                        + "Registro # " + (index + 1).ToString + ":" _
                        + " [Compañía:" + companiaId.ToString _
                        + ", Sucursal:" + sucursalId.ToString _
                        + ", Artículo:" + articuloId.ToString _
                        + ", Fecha:" + cols(3) + "]")
                End Try

            Next
        Catch ex As Exception
            Me.status = Me.ERROR_ON_LOAD
            Me.errorMessage = ex.Message

            Me.ButtonImportar.Disabled = True
            Me.ButtonPrevio.Disabled = False
        End Try

    End Sub

    Public Sub importar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonImportar.ServerClick

        uploadTotalRecords = clsImportar.intImportar(intListadoId, Me.strUsuarioNombre, Me.strConnectionString)

        uploadJustDone = True
    End Sub

    Public Sub limpiar(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonLimpiar.ServerClick

        'borrar los registros relacionados con el listado, que se hayan capturado previamente
        clsImportar.intBorrarDelTemporal(Me.intListadoId, Me.strConnectionString)

        Me.limpiar(True)
    End Sub

    Private Sub deleteRecords()

        clsImportar.intBorrarDelOriginal(intListadoId, Me.strConnectionString)
        Me.limpiar(True)

    End Sub

    Private Sub limpiar(ByVal resetAllValues As Boolean)
        If resetAllValues Then
            Me.intListadoId = 0
            Me.txtListadoNombre.Value = ""
        End If

        Me.uploadListadoId.Value = "0"
        Me.uploadJustDone = False
        Me.uploadTotalRecords = 0
        Me.uploadUser.Value = ""

        Me.ButtonImportar.Disabled = True
        Me.ButtonPrevio.Disabled = False

        Me.status = OK
        Me.errorMessage = ""

    End Sub

End Class

