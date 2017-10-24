Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports System.Text
Imports System.Collections

Public Class clsSistemaEmpleadosCertificadosAgregar
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
        strtxtEmpleadoId = GetPageParameter("txtEmpleadoId", "")

    End Sub

    Protected WithEvents txtArchivo As System.Web.UI.HtmlControls.HtmlInputFile
#End Region


#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private strmtxtEmpleadoId As String

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
    ' Name       : strtxtEmpleadoId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtEmpleadoId() As String
        Get
            Return strmtxtEmpleadoId
        End Get
        Set(ByVal strValue As String)
            strmtxtEmpleadoId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strObtenerEmpleadosCertificados
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strObtenerEmpleadosCertificados() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 100
        Const strRecordBrowserName As String = "SistemaEmpleadosCertificadosConsultar"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim aobjDataArray As Array = Benavides.CC.Data.clstblEmpleadoCertificado.aobjObtenerEmpleadosCertificados(strtxtEmpleadoId, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

        ' Generamos el URL destino de las páginas
        'Dim strTargetURL As String = strThisPageName & "?intEmisorId=" & intEmisorId & "&txtEmpleadoId=" & strtxtEmpleadoId & "&"
        Dim strTargetURL As String = strThisPageName & "?txtEmpleadoId=" & strtxtEmpleadoId & "&"

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, aobjDataArray, intSelectedPage, intElementsPerPage, strTargetURL)

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaramos las constantes locales
        Const intNumeroColumnasArchivo As Int32 = 1
        'Dim aobjData As Array = Nothing
        Dim intBinId As Integer = 0
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
                                Dim intEmpleadoCertificadoId As Integer = CInt(ConvertObject(astrColumns.GetValue(0), TypeCode.Int32))

                                ' Agregamos los nuevos registros, si los valores de las columnas son válidos
                                If intEmpleadoCertificadoId > 0 Then

                                    ' Buscamos el registro
                                    Dim aobjDataToSearch As Array = Benavides.CC.Data.clstblEmpleadoCertificado.strBuscar(intEmpleadoCertificadoId, Now(), "", 0, 1, strConnectionString)

                                    ' Si el registro existe
                                    If IsArray(aobjDataToSearch) = True AndAlso aobjDataToSearch.Length > 0 Then
                                        ' Actualizamos el registro
                                        intCounter += Benavides.CC.Data.clstblEmpleadoCertificado.intActualizar(intEmpleadoCertificadoId, Now(), strUsuarioNombre, strConnectionString)

                                    Else
                                        ' Agregamos el nuevo registro
                                        intCounter += Benavides.CC.Data.clstblEmpleadoCertificado.intAgregar(intEmpleadoCertificadoId, Now(), strUsuarioNombre, strConnectionString)

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
                        Call Benavides.CC.Data.clstblEmpleadoCertificado.intEliminar(0, Now(), strUsuarioNombre, strConnectionString)
                        aobjDataList = New System.Collections.ArrayList

                        ' Por cada registro existente
                        For Each astrColumns As Array In astrRows

                            ' Si el registro tiene el número de columnas adecuadas
                            If astrColumns.Length = intNumeroColumnasArchivo Then

                                ' Obtenemos los valores que vienen en el archivo
                                Dim intEmpleadoCertificadoId As Integer = CInt(ConvertObject(astrColumns.GetValue(0), TypeCode.Int32))

                                ' Agregamos los nuevos registros, si los valores de las columnas son válidos
                                If intEmpleadoCertificadoId > 0 Then

                                    ' Agregamos el nuevo registros a la base de datos
                                    Dim intReturnedValue As Integer = Benavides.CC.Data.clstblEmpleadoCertificado.intAgregar(intEmpleadoCertificadoId, Now(), strUsuarioNombre, strConnectionString)

                                    ' Si el registro logró ser agregado
                                    If intReturnedValue > 0 Then

                                        ' Agregamos el registro actual a la lista de registros a transmitirse a las sucursales
                                        Dim objRecordField(3) As String
                                        objRecordField(0) = CStr(intEmpleadoCertificadoId)
                                        objRecordField(1) = CStr(Now())
                                        objRecordField(2) = strUsuarioNombre

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

                        '' Si el arreglo tiene datos
                        'If aobjData.Length > 0 Then

                        '    ' Leemos las tiendas asignadas a este cliente
                        '    Dim objStoresArray As Array = Benavides.CC.Data.clstblTienda.strBuscar(0, 0, 0, "", "", 0, "", 0, "", "", Now, "", 0, 0, strConnectionString)

                        '    ' Si la dirección IP del concentrador es correcta y existen tiendas a quienes enviar la información
                        '    If IsNothing(objStoresArray) = False AndAlso objStoresArray.Length > 0 Then

                        '        ' Enviamos los datos hacia los servidores de los puntos de venta
                        '        'Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeCompletoHaciaServidoresPuntoDeVenta("clstblBINTarjeta", Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ELIMINAR_AGREGAR, "POS", aobjData, objStoresArray)

                        '    End If

                        'End If

                        ' Notificamos los registros actualizados
                        Dim dtmFinal As DateTime = Now()
                        strJavascriptWindowOnLoadCommands &= "  alert(""Total de líneas en el archivo: " & astrRows.Length & "\n\r\n\rTotal de registros importados: " & intCounter & "\n\r\n\rTotal de líneas sin importar: " & CStr(astrRows.Length - intCounter) & "\n\r\n\r\n\rTotal de registros enviados a cada sucursal: " & aobjData.Length & "\n\r\n\r\n\rInicio: " & dtmInicio & "\n\r\n\rFinal: " & dtmFinal & "\n\r\n\rTiempo estimado: " & DateDiff(DateInterval.Minute, dtmInicio, dtmFinal) & " minuto(s)\n\r"");" & vbCrLf

                    End If

                End If

            Case "Eliminar"

                ' Eliminamos los registros existentes en la base de datos
                Call Benavides.CC.Data.clstblEmpleadoCertificado.intEliminar(0, Now, "", strConnectionString)
        End Select
    End Sub

    Public Function strExportarEmpleadosCertificados() As String
        Dim strResultadoCadena As New StringBuilder
        Dim aoEmpleadosCertificados As Array

        aoEmpleadosCertificados = Benavides.CC.Data.clstblEmpleadoCertificado.aobjExportarEmpleadosCertificados(strConnectionString)

        strResultadoCadena.Append("<table id='empleadosCertificados' border='2px'>")
        strResultadoCadena.Append("<tr bgcolor='#87AFC6'>")
        strResultadoCadena.Append("<th>Empleado</th>")
        strResultadoCadena.Append("<th>Activo</th>")
        strResultadoCadena.Append("<th>Modificado Por</th>")
        strResultadoCadena.Append("<th>Ultima Modificación</th>")
        strResultadoCadena.Append("</tr>")

        For Each renglon As SortedList In aoEmpleadosCertificados

            strResultadoCadena.Append("<tr>")
            strResultadoCadena.AppendFormat("<td>{0}</td>", renglon.Item("intEmpleadoId").ToString())
            strResultadoCadena.AppendFormat("<td align='center'>{0}</td>", renglon.Item("blnEmpleadoActivo").ToString())
            strResultadoCadena.AppendFormat("<td>{0}</td>", renglon.Item("strEmpleadoCertificadoModificadoPor").ToString())
            strResultadoCadena.AppendFormat("<td>{0}</td>", renglon.Item("dtmEmpleadoCertificadoUltimaModificacion").ToString())
            strResultadoCadena.Append("</tr>")
        Next

        strResultadoCadena.Append("</table>")

        Return strResultadoCadena.ToString()
    End Function

End Class