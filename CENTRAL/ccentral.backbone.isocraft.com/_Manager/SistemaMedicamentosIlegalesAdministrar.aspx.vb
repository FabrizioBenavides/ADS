Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert

Public Class clsSistemaMedicamentosIlegalesAgregar
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then

            Call Response.Redirect("../Default.aspx")

        End If

        ' Initialize class properties
        strtxtArticuloId = GetPageParameter("txtArticuloId", "")
        intArticuloId = GetPageParameter("intArticuloId", 0)
        strArticuloDescripcion = GetPageParameter("strArticuloDescripcion", "")

    End Sub

    Protected WithEvents txtArchivo As System.Web.UI.HtmlControls.HtmlInputFile
#End Region


#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private strmtxtArticuloId As String
    Private intmArticuloId As Integer
    Private strmArticuloDescripcion As String

#End Region

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
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : None
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
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
        End Get
    End Property

    '====================================================================
    ' Name       : strtxtArticuloId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtArticuloId() As String
        Get
            Return strmtxtArticuloId
        End Get
        Set(ByVal strValue As String)
            strmtxtArticuloId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intArticuloId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intArticuloId() As Integer
        Get
            Return intmArticuloId
        End Get
        Set(ByVal intValue As Integer)
            intmArticuloId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strArticuloDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strArticuloDescripcion() As String
        Get
            Return strmArticuloDescripcion
        End Get
        Set(ByVal strValue As String)
            strmArticuloDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strObtenerArticulosIlegales
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strObtenerArticulosIlegales() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 10
        Const strRecordBrowserName As String = "SistemaArticulosIlegalesConsultar"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim aobjDataArray As Array = Benavides.CC.Data.clstblArticuloIlegal.aobjObtenerArticulosIlegales(strtxtArticuloId, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

        ' Generamos el URL destino de las páginas
        Dim strTargetURL As String = strThisPageName & "?"

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, aobjDataArray, intSelectedPage, intElementsPerPage, strTargetURL)

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaramos las constantes locales
        Const intNumeroColumnasArchivo As Int32 = 2
        'Dim aobjData As Array = Nothing
        ' Execute the selected command
        Select Case strCmd

            Case "Agregar"

                ' Verificamos si el archivo ha sido enviado
                If IsNothing(txtArchivo.PostedFile) = False Then

                    Dim intCounter As Integer
                    Dim dtmInicio As DateTime = Now()

                    ' Obtenemos un arreglo con los renglones del archivo
                    Dim astrRows As Array = CreateArrayFromCSVHttpPostedFile(txtArchivo.PostedFile)

                    ' Por cada renglón existente
                    If IsNothing(astrRows) = False AndAlso astrRows.Length > 0 Then

                        For Each astrColumns As Array In astrRows

                            ' Si el renglón tiene el número de columnas adecuadas
                            If astrColumns.Length = intNumeroColumnasArchivo Then

                                ' Obtenemos los valores que vienen en el archivo
                                Dim intArticuloIlegalId As Integer = CInt(ConvertObject(astrColumns.GetValue(0), TypeCode.Int32))
                                Dim strArticuloIlegalLote As String = CStr(ConvertObject(astrColumns.GetValue(1), TypeCode.String))

                                ' Agregamos los nuevos registros, si los valores de las columnas son válidos
                                If intArticuloIlegalId > 0 Then

                                    ' Buscamos el registro
                                    Dim aobjDataToSearch As Array = Benavides.CC.Data.clstblArticuloIlegal.strBuscar(intArticuloIlegalId, Now(), "", 0, 1, strConnectionString)

                                    ' Si el registro existe
                                    If IsArray(aobjDataToSearch) = True AndAlso aobjDataToSearch.Length > 0 Then
                                        ' Actualizamos el registro
                                        intCounter += Benavides.CC.Data.clstblArticuloIlegal.intActualizar(intArticuloIlegalId, strArticuloIlegalLote, True, Now(), strUsuarioNombre, strConnectionString)

                                    Else
                                        ' Agregamos el nuevo registro
                                        intCounter += Benavides.CC.Data.clstblArticuloIlegal.intAgregar(intArticuloIlegalId, strArticuloIlegalLote, True, Now(), strUsuarioNombre, strConnectionString)
                                    End If

                                End If

                            End If

                        Next

                        ' Notificamos los registros actualizados
                        Dim dtmFinal As DateTime = Now()
                        strJavascriptWindowOnLoadCommands &= "  alert(""Total de líneas en el archivo: " & astrRows.Length & "\n\r\n\rTotal de registros importados: " & intCounter & "\n\r\n\rTotal de líneas sin importar: " & CStr(astrRows.Length - intCounter) & "\n\r\n\rInicio: " & dtmInicio & "\n\r\n\rFinal: " & dtmFinal & "\n\r\n\rTiempo estimado: " & DateDiff(DateInterval.Minute, dtmInicio, dtmFinal) & " minuto(s)"");" & vbCrLf

                    End If

                End If

            Case "Reemplazar"

                ' Verificamos si el archivo ha sido enviado y el cliente especial ha sido especificado
                If IsNothing(txtArchivo.PostedFile) = False Then

                    Dim intCounter As Integer
                    Dim dtmInicio As DateTime = Now()
                    Dim aobjDataList As System.Collections.ArrayList

                    ' Obtenemos un arreglo con los registros del archivo
                    Dim astrRows As Array = CreateArrayFromCSVHttpPostedFile(txtArchivo.PostedFile)

                    ' Si el archivo contenía registros
                    If IsNothing(astrRows) = False AndAlso astrRows.Length > 0 Then

                        ' Eliminamos los registros existentes en la base de datos
                        Call Benavides.CC.Data.clstblArticuloIlegal.intEliminar(0, Now, "", strConnectionString)
                        aobjDataList = New System.Collections.ArrayList

                        ' Por cada registro existente
                        For Each astrColumns As Array In astrRows

                            ' Si el registro tiene el número de columnas adecuadas
                            If astrColumns.Length = intNumeroColumnasArchivo Then

                                ' Obtenemos los valores que vienen en el archivo
                                Dim intArticuloIlegalId As Integer = CInt(ConvertObject(astrColumns.GetValue(0), TypeCode.Int32))
                                Dim strArticuloIlegalLote As String = CStr(ConvertObject(astrColumns.GetValue(1), TypeCode.String))

                                ' Agregamos los nuevos registros, si los valores de las columnas son válidos
                                If intArticuloIlegalId > 0 And strArticuloIlegalLote.Length > 0 Then

                                    ' Agregamos el nuevo registros a la base de datos
                                    Dim intReturnedValue As Integer = Benavides.CC.Data.clstblArticuloIlegal.intAgregar(intArticuloIlegalId, strArticuloIlegalLote, True, Now(), strUsuarioNombre, strConnectionString)

                                    ' Si el registro logró ser agregado
                                    If intReturnedValue > 0 Then

                                        ' Agregamos el registro actual a la lista de registros a transmitirse a las sucursales
                                        Dim objRecordField(4) As String
                                        objRecordField(0) = CStr(intArticuloIlegalId)
                                        objRecordField(1) = CStr(strArticuloIlegalLote)
                                        objRecordField(2) = CStr(Now())
                                        objRecordField(3) = strUsuarioNombre

                                        Call aobjDataList.Add(objRecordField)
                                        objRecordField = Nothing

                                        ' Incrementamos el contador de registros procesados exitósamente
                                        intCounter += intReturnedValue

                                    End If

                                End If

                            End If

                        Next

                        ' Obtenemos de la lista los registros a enviar y los almacenamos en un arreglo de datos
                        Dim aobjData As Array = aobjDataList.ToArray()

                        ' Si el arreglo tiene datos
                        If aobjData.Length > 0 Then

                            ' Leemos las tiendas asignadas a este cliente
                            Dim objStoresArray As Array = Benavides.CC.Data.clstblTienda.strBuscar(0, 0, 0, "", "", 0, "", 0, "", "", Now, "", 0, 0, strConnectionString)

                            ' Si la dirección IP del concentrador es correcta y existen tiendas a quienes enviar la información
                            If IsNothing(objStoresArray) = False AndAlso objStoresArray.Length > 0 Then

                                ' Enviamos los datos hacia los servidores de los puntos de venta
                                'Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeCompletoHaciaServidoresPuntoDeVenta("clstblBINTarjeta", Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ELIMINAR_AGREGAR, "POS", aobjData, objStoresArray)

                            End If

                        End If

                        ' Notificamos los registros actualizados
                        Dim dtmFinal As DateTime = Now()
                        strJavascriptWindowOnLoadCommands &= "  alert(""Total de líneas en el archivo: " & astrRows.Length & "\n\r\n\rTotal de registros importados: " & intCounter & "\n\r\n\rTotal de líneas sin importar: " & CStr(astrRows.Length - intCounter) & "\n\r\n\r\n\rTotal de registros enviados a cada sucursal: " & aobjData.Length & "\n\r\n\r\n\rInicio: " & dtmInicio & "\n\r\n\rFinal: " & dtmFinal & "\n\r\n\rTiempo estimado: " & DateDiff(DateInterval.Minute, dtmInicio, dtmFinal) & " minuto(s)\n\r"");" & vbCrLf

                    End If

                End If

            Case "Eliminar"

                ' Eliminamos los registros existentes en la base de datos
                If (intArticuloId > 0) Then
                    Call Benavides.CC.Data.clstblArticuloIlegal.intEliminar(intArticuloId, Now, "", strConnectionString)
                End If

            Case "EliminarTodo"
                ' Eliminamos los registros existentes en la base de datos
                Call Benavides.CC.Data.clstblArticuloIlegal.intEliminar(0, Now, "", strConnectionString)

            Case "Editar"
                If intArticuloId > 0 Then
                    Call Response.Redirect("SistemaMedicamentosIlegalesEditar.aspx?intArticuloId=" & intArticuloId)
                End If

        End Select
    End Sub

End Class
