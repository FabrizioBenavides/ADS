Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert

'====================================================================
' Class         : VentasProductosComplementariosCargaArchivo
' Title         : VentasProductosComplementariosCargaArchivo
' Description   : creacion de clases
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : First name Last name (account@isocraft.com)
' Last Modified : Wednesday, September 28, 2005
'====================================================================

Public Class VentasProductosComplementariosCargaArchivo
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtArchivo As System.Web.UI.HtmlControls.HtmlInputFile

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        ' Enviamos al usuario actual a la p�gina de acceso, si no tiene privilegios de acceder a esta p�gina
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String

#End Region
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
    ' Description: Genera la fecha y hora de la p�gina
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaramos las constantes locales
        Const intNumeroColumnasArchivo As Int32 = 3

        ' Execute the selected command
        Select Case strCmd

            Case "Agregar"

                ' Verificamos si el archivo ha sido enviado
                If IsNothing(txtArchivo.PostedFile) = False Then

                    Dim intCounter As Integer
                    Dim dtmInicio As DateTime = Now()

                    ' Obtenemos un arreglo con los renglones del archivo
                    Dim astrRows As Array = CreateArrayFromCSVHttpPostedFile(txtArchivo.PostedFile)

                    ' Por cada rengl�n existente
                    If IsNothing(astrRows) = False AndAlso astrRows.Length > 0 Then

                        For Each astrColumns As Array In astrRows

                            ' Si el rengl�n tiene el n�mero de columnas adecuadas
                            If astrColumns.Length = intNumeroColumnasArchivo Then

                                ' Obtenemos los valores que vienen en el archivo
                                Dim intArticuloId As Integer = CInt(ConvertObject(astrColumns.GetValue(0), TypeCode.Int32))
                                Dim intArticuloComplementarioId As Integer = CInt(ConvertObject(astrColumns.GetValue(1), TypeCode.Int32))
                                Dim intArticuloComplementarioOrden As Integer = CInt(ConvertObject(astrColumns.GetValue(2), TypeCode.Int32))

                                ' Agregamos los nuevos registros, si los valores de las columnas son v�lidos
                                If intArticuloId > 0 AndAlso intArticuloComplementarioId > 0 Then

                                    ' Buscamos el registro
                                    Dim aobjDataToSearch As Array = Benavides.CC.Data.clstblArticuloComplementario.strBuscar(intArticuloId, intArticuloComplementarioId, intArticuloComplementarioOrden, strUsuarioNombre, Now(), 0, 0, strConnectionString)

                                    ' Si el registro existe
                                    If IsArray(aobjDataToSearch) = True AndAlso aobjDataToSearch.Length > 0 Then

                                        ' Actualizamos el registro
                                        intCounter += Benavides.CC.Data.clstblArticuloComplementario.intActualizar(intArticuloId, intArticuloComplementarioId, intArticuloComplementarioOrden, strUsuarioNombre, Now(), strConnectionString)

                                    Else

                                        ' Agregamos el nuevo registro
                                        intCounter += Benavides.CC.Data.clstblArticuloComplementario.intAgregar(intArticuloId, intArticuloComplementarioId, intArticuloComplementarioOrden, strUsuarioNombre, Now(), strConnectionString)

                                    End If

                                End If

                            End If

                        Next

                        ' Notificamos los registros actualizados
                        Dim dtmFinal As DateTime = Now()
                        strJavascriptWindowOnLoadCommands &= "  alert(""Total de l�neas en el archivo: " & astrRows.Length & "\n\r\n\rTotal de registros importados: " & intCounter & "\n\r\n\rTotal de l�neas sin importar: " & CStr(astrRows.Length - intCounter) & "\n\r\n\rInicio: " & dtmInicio & "\n\r\n\rFinal: " & dtmFinal & "\n\r\n\rTiempo estimado: " & DateDiff(DateInterval.Minute, dtmInicio, dtmFinal) & " minuto(s)"");" & vbCrLf

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

                    ' Si el archivo conten�a registros
                    If IsNothing(astrRows) = False AndAlso astrRows.Length > 0 Then

                        ' Eliminamos los registros existentes en la base de datos
                        Call Benavides.CC.Data.clstblArticuloComplementario.intEliminar(0, 0, 0, strUsuarioNombre, Now(), strConnectionString)
                        aobjDataList = New System.Collections.ArrayList

                        ' Por cada registro existente
                        For Each astrColumns As Array In astrRows

                            ' Si el registro tiene el n�mero de columnas adecuadas
                            If astrColumns.Length = intNumeroColumnasArchivo Then

                                ' Obtenemos los valores que vienen en el archivo
                                Dim intArticuloId As Integer = CInt(ConvertObject(astrColumns.GetValue(0), TypeCode.Int32))
                                Dim intArticuloComplementarioId As Integer = CInt(ConvertObject(astrColumns.GetValue(1), TypeCode.Int32))
                                Dim intArticuloComplementarioOrden As Integer = CInt(ConvertObject(astrColumns.GetValue(2), TypeCode.Int32))

                                ' Agregamos los nuevos registros, si los valores de las columnas son v�lidos
                                If intArticuloId > 0 AndAlso intArticuloComplementarioId > 0 Then

                                    ' Agregamos el nuevo registros a la base de datos
                                    Dim intReturnedValue As Integer = Benavides.CC.Data.clstblArticuloComplementario.intAgregar(intArticuloId, intArticuloComplementarioId, intArticuloComplementarioOrden, strUsuarioNombre, Now(), strConnectionString)

                                    ' Si el registro logr� ser agregado
                                    If intReturnedValue > 0 Then

                                        ' Agregamos el registro actual a la lista de registros a transmitirse a las sucursales
                                        Dim objRecordField As System.Collections.SortedList = New System.Collections.SortedList
                                        Call objRecordField.Add("intArticuloId", intArticuloId)
                                        Call objRecordField.Add("intArticuloComplementarioId", intArticuloComplementarioId)
                                        Call objRecordField.Add("intArticuloComplementarioOrden", intArticuloComplementarioOrden)
                                        Call objRecordField.Add("dtmArticuloComplementarioUltimaModificacion", Now())
                                        Call objRecordField.Add("strArticuloComplementarioModificadoPor", strUsuarioNombre)
                                        Call aobjDataList.Add(objRecordField)
                                        objRecordField = Nothing

                                        ' Incrementamos el contador de registros procesados exit�samente
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

                            ' Si la direcci�n IP del concentrador es correcta y existen tiendas a quienes enviar la informaci�n
                            If IsNothing(objStoresArray) = False AndAlso objStoresArray.Length > 0 Then

                                ' Enviamos los datos hacia los servidores de los puntos de venta
                                Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeCompletoHaciaServidoresPuntoDeVenta("clstblArticuloComplementario", Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ELIMINAR_AGREGAR, "POS", aobjData, objStoresArray)

                            End If

                        End If

                        ' Notificamos los registros actualizados
                        Dim dtmFinal As DateTime = Now()
                        strJavascriptWindowOnLoadCommands &= "  alert(""Total de l�neas en el archivo: " & astrRows.Length & "\n\r\n\rTotal de registros importados: " & intCounter & "\n\r\n\rTotal de l�neas sin importar: " & CStr(astrRows.Length - intCounter) & "\n\r\n\r\n\rTotal de registros enviados a cada sucursal: " & aobjData.Length & "\n\r\n\r\n\rInicio: " & dtmInicio & "\n\r\n\rFinal: " & dtmFinal & "\n\r\n\rTiempo estimado: " & DateDiff(DateInterval.Minute, dtmInicio, dtmFinal) & " minuto(s)\n\r"");" & vbCrLf

                    End If

                End If

        End Select

    End Sub

End Class
