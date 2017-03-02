Imports Isocraft.Web.Http

'====================================================================
' Class         : clsSistemaAgregarTipoDeReceta
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : (c) Isocraft 2004 - 2009. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Joaquín Hdz. G. (joaquin@isocraft.com)
' Last Modified : Monday, December 20, 2004
'====================================================================

Public Class clsSistemaAgregarTipoDeReceta
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
        strTipoFormaCapturaNombreId = GetPageParameter("txtTipoFormaCapturaNombreId", "")
        strTipoFormaCapturaNombre = GetPageParameter("txtTipoFormaCapturaNombre", "")
        strTipoFormaCapturaDescripcion = GetPageParameter("txtTipoFormaCapturaDescripcion", "")
        intTipoFormaCapturaId = GetPageParameter("txtTipoFormaCapturaId", GetPageParameter("intTipoFormaCapturaId", GetPageParameter("intRBTipoFormaCapturaId", 0)))
        blnTipoFormaCapturaActivo = GetPageParameter("chkTipoFormaCapturaActivo", False)
        strTipoFormaCapturaInstruccionVenta = GetPageParameter("txtTipoFormaCapturaInstruccionVenta", "")

        If StrComp(strCmd, "Agregar") = 0 Then
            intTipoFormaCapturaId = 0
        End If

    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private strmtxtTipoFormaCapturaNombreId As String
    Private strmtxtTipoFormaCapturaNombre As String
    Private strmtxtTipoFormaCapturaDescripcion As String
    Private intmtxtTipoFormaCapturaId As Integer
    Private blnmchkTipoFormaCapturaActivo As Boolean
    Private strmTipoFormaCapturaInstruccionVenta As String

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
            Return GetPageParameter("strCmd", "Editar")
        End Get
    End Property

    '====================================================================
    ' Name       : intTipoFormaCapturaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intTipoFormaCapturaId() As Integer
        Get
            Return intmtxtTipoFormaCapturaId
        End Get
        Set(ByVal intValue As Integer)
            intmtxtTipoFormaCapturaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoFormaCapturaNombreId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTipoFormaCapturaNombreId() As String
        Get
            Return strmtxtTipoFormaCapturaNombreId
        End Get
        Set(ByVal strValue As String)
            strmtxtTipoFormaCapturaNombreId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoFormaCapturaNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTipoFormaCapturaNombre() As String
        Get
            Return strmtxtTipoFormaCapturaNombre
        End Get
        Set(ByVal strValue As String)
            strmtxtTipoFormaCapturaNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoFormaCapturaDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTipoFormaCapturaDescripcion() As String
        Get
            Return strmtxtTipoFormaCapturaDescripcion
        End Get
        Set(ByVal strValue As String)
            strmtxtTipoFormaCapturaDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnTipoFormaCapturaActivo
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnTipoFormaCapturaActivo() As Boolean
        Get
            Return blnmchkTipoFormaCapturaActivo
        End Get
        Set(ByVal blnValue As Boolean)
            blnmchkTipoFormaCapturaActivo = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoFormaCapturaInstruccionVenta
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTipoFormaCapturaInstruccionVenta() As String
        Get
            Return strmTipoFormaCapturaInstruccionVenta
        End Get
        Set(ByVal strValue As String)
            strmTipoFormaCapturaInstruccionVenta = strValue
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

        ' Verificamos que el identificador del tipo de receta sea válido
        If intTipoFormaCapturaId > 0 Then

            ' Declaramos e inicializamos las constantes locales
            Const intElementsPerPage As Integer = 10
            Const strRecordBrowserName As String = "SistemaAgregarTipoDeReceta"

            ' Declaramos e inicializamos las variables locales
            Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
            Dim aobjDataArray As Array = Benavides.CC.Data.clsAtributoTipoFormaCaptura.strBuscar(0, intTipoFormaCapturaId, Now(), "", True, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)
            If IsNothing(aobjDataArray) = False AndAlso aobjDataArray.Length > 0 Then
                For Each astrDataRow As System.Collections.SortedList In aobjDataArray
                    If CBool(astrDataRow.Item("blnAtributoActivo")) = False Then
                        astrDataRow.Item("strAtributoNombre") = CStr(astrDataRow.Item("strAtributoNombre")) & " (inactivo)"
                    End If
                    If CBool(astrDataRow.Item("blnTipoAtributoActivo")) = False Then
                        astrDataRow.Item("strTipoAtributoNombre") = CStr(astrDataRow.Item("strTipoAtributoNombre")) & " (inactivo)"
                    End If
                Next
            End If

            ' Generamos el navegador de registros
            Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, aobjDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?intRBTipoFormaCapturaId=" & intTipoFormaCapturaId & "&").Replace("<input name=""cmdNavegadorRegistrosAgregar"" type=""button"" class=""boton"" id=""cmdNavegadorRegistrosAgregar"" value=""Agregar atributo"" onclick=""window.location='SistemaAgregarTipoDeReceta.aspx?intRBTipoFormaCapturaId=" & intTipoFormaCapturaId & "&amp;strCmd=Agregar'"">", "<input name=""cmdNavegadorRegistrosAgregar"" type=""button"" class=""boton"" id=""cmdNavegadorRegistrosAgregar"" value=""Agregar atributo"" onclick=""cmdNavegadorRegistrosAgregar_onclick()"">")

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

                Dim intAtributoId As Integer = GetPageParameter("intAtributoId", 0)

                If intTipoFormaCapturaId > 0 AndAlso intAtributoId > 0 Then

                    ' Eliminamos el atributo asociado con el tipo de receta
                    Call Benavides.CC.Data.clstblAtributoTipoFormaCaptura.intActualizar(intAtributoId, intTipoFormaCapturaId, Now(), strUsuarioNombre, False, strConnectionString)

                    ' Regresamos al usuario al listado de elementos
                    Call Response.Redirect("SistemaAgregarTipoDeReceta.aspx?strCmd=Editar&intTipoFormaCapturaId=" & intTipoFormaCapturaId)

                End If

                ' Regresamos al usuario al listado de elementos
                Call Response.Redirect("SistemaAdministrarTiposDeRecetas.aspx")

            Case "Editar"

                ' Si el identificador del elemento es válido
                If intTipoFormaCapturaId > 0 Then

                    ' Obtenemos el elemento
                    Dim aobjData As Array = Benavides.CC.Data.clstblTipoFormaCaptura.strBuscar(intTipoFormaCapturaId, "", "", "", Now(), "", False, "", 0, 0, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        Dim aobjRow As System.Collections.SortedList = DirectCast(aobjData.GetValue(0), System.Collections.SortedList)

                        ' Recuperamos sus datos
                        intTipoFormaCapturaId = CInt(aobjRow.Item("intTipoFormaCapturaId"))
                        strTipoFormaCapturaNombreId = CStr(aobjRow.Item("strTipoFormaCapturaNombreId"))
                        strTipoFormaCapturaNombre = CStr(aobjRow.Item("strTipoFormaCapturaNombre"))
                        strTipoFormaCapturaDescripcion = CStr(aobjRow.Item("strTipoFormaCapturaDescripcion"))
                        blnTipoFormaCapturaActivo = CBool(aobjRow.Item("blnTipoFormaCapturaActivo"))
                        strTipoFormaCapturaInstruccionVenta = CStr(aobjRow.Item("strTipoFormaCapturaInstruccionVenta"))

                    End If

                End If

            Case "Salvar"

                Dim blnRedirectToParentPage As Boolean

                ' Si el tipo de atributo es nuevo
                If intTipoFormaCapturaId = 0 Then

                    ' Buscamos los datos de la plantilla fuente usando el nuevo nombre
                    Dim aobjFormaCapturaCopia As Array = Benavides.CC.Data.clstblTipoFormaCaptura.strBuscar(0, strTipoFormaCapturaNombreId, "", "", Now(), "", False, "", 0, 0, strConnectionString)

                    ' Si la plantilla existe
                    If IsNothing(aobjFormaCapturaCopia) = False AndAlso aobjFormaCapturaCopia.Length > 0 Then

                        ' Indicando que la plantilla ya existe con el nombre especificado
                        strJavascriptWindowOnLoadCommands &= "  alert(""No fue posible crear el nuevo tipo de receta.\n\r\n\rSe especificó un \""Nombre en POS\"" existente, por favor especifique un nombre que no exista."");"

                    Else

                        ' Agregamos el nuevo tipo de atributo
                        intTipoFormaCapturaId = Benavides.CC.Data.clstblTipoFormaCaptura.intAgregar(intTipoFormaCapturaId, strTipoFormaCapturaNombreId, strTipoFormaCapturaNombre, strTipoFormaCapturaDescripcion, Now(), strUsuarioNombre, blnTipoFormaCapturaActivo, strTipoFormaCapturaInstruccionVenta, strConnectionString)

                        ' Si la llave del nuevo atributo es válida
                        If intTipoFormaCapturaId < 0 Then
                            strJavascriptWindowOnLoadCommands &= "  alert(""ERROR: La información no pudo ser agregada a la base de datos.\n\r\n\rPor favor informe este error a su administrador o personal a cargo."");" & vbCrLf
                            blnRedirectToParentPage = True
                        End If

                    End If

                Else

                    ' Actualizamos el tipo de atributo existente
                    If Benavides.CC.Data.clstblTipoFormaCaptura.intActualizar(intTipoFormaCapturaId, strTipoFormaCapturaNombreId, strTipoFormaCapturaNombre, strTipoFormaCapturaDescripcion, Now(), strUsuarioNombre, blnTipoFormaCapturaActivo, strTipoFormaCapturaInstruccionVenta, strConnectionString) < 0 Then
                        strJavascriptWindowOnLoadCommands &= "  alert(""ERROR: La información no pudo ser actualizada en la base de datos.\n\r\n\rPor favor informe este error a su administrador o personal a cargo."");" & vbCrLf
                        blnRedirectToParentPage = True
                    End If

                End If

                ' Regresamos al usuario al listado de elementos
                If blnRedirectToParentPage = True Then
                    strJavascriptWindowOnLoadCommands &= " window.location.href = ""SistemaAdministrarTiposDeRecetas.aspx"";"
                End If

            Case "Copiar"

                ' Obtenemos el nombre del nuevo tipo de receta (plantilla)
                Dim strTipoFormaCapturaNombreCopia As String = GetPageParameter("strTipoFormaCapturaNombreCopia", "")

                ' Si su nombre y el identificador del tipo de plantilla a duplicar son válidos
                If Len(strTipoFormaCapturaNombreCopia) > 0 AndAlso intTipoFormaCapturaId > 0 Then

                    ' Buscamos los datos de la plantilla fuente usando el nuevo nombre
                    Dim aobjFormaCapturaCopia As Array = Benavides.CC.Data.clstblTipoFormaCaptura.strBuscar(0, strTipoFormaCapturaNombreCopia, "", "", Now(), "", False, "", 0, 0, strConnectionString)

                    ' Si la plantilla existe
                    If IsNothing(aobjFormaCapturaCopia) = False AndAlso aobjFormaCapturaCopia.Length > 0 Then

                        ' Regresamos al usuario al listado de elementos indicando que la plantilla ya existe con el nombre especificado
                        Call Response.Redirect("SistemaAdministrarTiposDeRecetas.aspx?strCmd=CopiaExistente")

                    Else

                        ' Obtenemos el tipo de plantilla fuente
                        Dim aobjData As Array = Benavides.CC.Data.clstblTipoFormaCaptura.strBuscar(intTipoFormaCapturaId, "", "", "", Now(), "", False, "", 0, 0, strConnectionString)

                        ' Si el tipo de plantilla fuente fue encontrado
                        If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                            ' Recuperamos los datos del tipo de plantilla fuente
                            Dim aobjRow As System.Collections.SortedList = DirectCast(aobjData.GetValue(0), System.Collections.SortedList)
                            strTipoFormaCapturaDescripcion = CStr(aobjRow.Item("strTipoFormaCapturaDescripcion"))
                            blnTipoFormaCapturaActivo = CBool(aobjRow.Item("blnTipoFormaCapturaActivo"))
                            strTipoFormaCapturaNombreId = strTipoFormaCapturaNombreCopia
                            strTipoFormaCapturaNombre = strTipoFormaCapturaNombreCopia
                            strTipoFormaCapturaInstruccionVenta = CStr(aobjRow.Item("strTipoFormaCapturaInstruccionVenta"))

                            ' Agregamos la nueva plantilla
                            Dim intNuevoTipoFormaCapturaId As Integer = Benavides.CC.Data.clstblTipoFormaCaptura.intAgregar(0, strTipoFormaCapturaNombreId, strTipoFormaCapturaNombre, strTipoFormaCapturaDescripcion, Now(), strUsuarioNombre, blnTipoFormaCapturaActivo, strTipoFormaCapturaInstruccionVenta, strConnectionString)

                            ' Obtenemos los atributos que tiene asignados
                            aobjData = Benavides.CC.Data.clstblAtributoTipoFormaCaptura.strBuscar(0, intTipoFormaCapturaId, Now(), "", False, 0, 0, strConnectionString)

                            ' Si existen atributos asignados al tipo de plantilla fuente
                            If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                                ' Si la nueva plantilla logró ser agregada
                                If intNuevoTipoFormaCapturaId > 0 Then

                                    ' Agregamos sus atributos (únicamente los que están activos)
                                    For Each aobjRow In aobjData
                                        Dim intAtributoId As Integer = CInt(aobjRow.Item("intAtributoId"))
                                        If CBool(aobjRow.Item("blnAtributoTipoFormaCapturaActivo")) = True Then
                                            Call Benavides.CC.Data.clstblAtributoTipoFormaCaptura.intAgregar(intAtributoId, intNuevoTipoFormaCapturaId, Now(), strUsuarioNombre, True, strConnectionString)
                                        End If
                                    Next

                                Else

                                    ' Regresamos al usuario al listado de elementos
                                    Call Response.Redirect("SistemaAdministrarTiposDeRecetas.aspx")

                                End If

                            End If

                            ' Actualizamos el identificador del tipo de forma de captura
                            intTipoFormaCapturaId = intNuevoTipoFormaCapturaId

                        Else

                            ' Regresamos al usuario al listado de elementos
                            Call Response.Redirect("SistemaAdministrarTiposDeRecetas.aspx")

                        End If


                    End If


                Else

                    ' Regresamos al usuario al listado de elementos
                    Call Response.Redirect("SistemaAdministrarTiposDeRecetas.aspx")

                End If

        End Select

    End Sub

End Class
