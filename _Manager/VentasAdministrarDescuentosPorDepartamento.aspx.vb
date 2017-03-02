Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert

'====================================================================
' Class         : clsVentasAdministrarDescuentosPorDepartamento
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Administrar descuentos por departamento
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Joaquín Hdz. G. (joaquin@isocraft.com)
' Last Modified : Tuesday, January 18, 2005
'====================================================================
Public Class clsVentasAdministrarDescuentosPorDepartamento
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtArticuloClienteEspecialArchivo As System.Web.UI.HtmlControls.HtmlInputFile

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        ' Initialize class properties
        intClienteEspecialId = GetPageParameter("txtClienteEspecialId", 0)
        strCliente = GetPageParameter("txtCliente", "")
        strArticuloClienteEspecialArchivo = GetPageParameter("txtArticuloClienteEspecialArchivo", "")
        strClienteEspecialNombre = GetPageParameter("txtClienteEspecialNombre", GetPageParameter("strClienteEspecialNombre", ""))
    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private intmClienteEspecialId As Integer
    Private strmtxtCliente As String
    Private strmtxtArticuloClienteEspecialArchivo As String
    Private strmClienteEspecialNombre As String

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
    ' Name       : intClienteEspecialId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Decimal
    '====================================================================
    Public Property intClienteEspecialId() As Integer
        Get
            Return intmClienteEspecialId
        End Get
        Set(ByVal intValue As Integer)
            intmClienteEspecialId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCliente
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strCliente() As String
        Get
            Return strmtxtCliente
        End Get
        Set(ByVal strValue As String)
            strmtxtCliente = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strArticuloClienteEspecialArchivo
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strArticuloClienteEspecialArchivo() As String
        Get
            Return strmtxtArticuloClienteEspecialArchivo
        End Get
        Set(ByVal strValue As String)
            strmtxtArticuloClienteEspecialArchivo = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strClienteEspecialNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strClienteEspecialNombre() As String
        Get
            Return strmClienteEspecialNombre
        End Get
        Set(ByVal strValue As String)
            strmClienteEspecialNombre = strValue
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

        If intClienteEspecialId > 0 Then

            ' Declaramos e inicializamos las constantes locales
            Const intElementsPerPage As Integer = 50
            Const strRecordBrowserName As String = "VentasAdministrarDescuentosPorCategoria"

            ' Declaramos e inicializamos las variables locales
            Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
            Dim astrDataArray As Array = Benavides.CC.Data.clsClienteEspecial.strBuscarCategoriaArticulosConDescuentos(intClienteEspecialId, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

            ' Generamos el navegador de registros
            Dim strTargetURL As String = strThisPageName & "?strClienteEspecialNombre=" & Server.UrlEncode(strClienteEspecialNombre) & "&txtClienteEspecialId=" & intClienteEspecialId & "&"

            Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strTargetURL)

        End If

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Select Case strCmd

            Case "Agregar"

                ' Verificamos si el archivo ha sido enviado y el cliente especial ha sido especificado
                If IsNothing(txtArticuloClienteEspecialArchivo.PostedFile) = False AndAlso intClienteEspecialId > 0 Then

                    Dim intCounter As Integer = 0
                    Dim dtmInicio As DateTime = Now()

                    ' Obtenemos un arreglo con los renglones del archivo
                    Dim astrRows As Array = CreateArrayFromCSVHttpPostedFile(txtArticuloClienteEspecialArchivo.PostedFile)

                    ' Por cada renglón existente
                    If IsNothing(astrRows) = False AndAlso astrRows.Length > 0 Then

                        ' Eliminamos los registros existentes en la base de datos
                        Call Benavides.CC.Data.clstblDescuentoClienteEspecialCategoriaArticulos.intEliminar(0, 0, intClienteEspecialId, 0, 0, 0, #1/1/1900#, strUsuarioNombre, strConnectionString)


                        Dim strDivisionArticulosNombreId As String = ""
                        Dim strCategoriaArticulosNombreId As String = ""

                        Dim fltDescuentoClienteEspecialPorcentaje As Decimal = 0
                        Dim fltDescuentoClienteEspecialPorcentajeTope As Decimal = 0
                        Dim blnDescuentoClienteEspecialTotal As Byte = 0


                        For Each astrColumns As Array In astrRows

                            ' Si el renglón tiene el número de columnas adecuadas
                            If astrColumns.Length = 5 Then

                                ' Obtenemos los valores que vienen en el archivo
                                strDivisionArticulosNombreId = Replace(Replace(CStr(ConvertObject(astrColumns.GetValue(0), TypeCode.String)), Chr(13), ""), Chr(10), "")
                                strCategoriaArticulosNombreId = CStr(ConvertObject(astrColumns.GetValue(1), TypeCode.String))

                                fltDescuentoClienteEspecialPorcentaje = CDec(ConvertObject(astrColumns.GetValue(2), TypeCode.Decimal))
                                fltDescuentoClienteEspecialPorcentajeTope = CDec(ConvertObject(astrColumns.GetValue(3), TypeCode.Decimal))
                                blnDescuentoClienteEspecialTotal = CByte(ConvertObject(astrColumns.GetValue(4), TypeCode.Byte))

                                ' Agregamos los nuevos registros, si los valores de las columnas son válidos
                                If Len(strDivisionArticulosNombreId) > 0 And Len(strCategoriaArticulosNombreId) > 0 Then

                                    ' Actualizamos el registro
                                    intCounter += Benavides.CC.Data.clsClienteEspecial.intActualizarAgregarCategoriaArticulosConDescuentos(intClienteEspecialId, strDivisionArticulosNombreId, strCategoriaArticulosNombreId, fltDescuentoClienteEspecialPorcentaje, fltDescuentoClienteEspecialPorcentajeTope, blnDescuentoClienteEspecialTotal, strUsuarioNombre, strConnectionString)


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
                If IsNothing(txtArticuloClienteEspecialArchivo.PostedFile) = False AndAlso intClienteEspecialId > 0 Then

                    Dim intCounter As Integer = 0
                    Dim dtmInicio As DateTime = Now()

                    ' Obtenemos un arreglo con los registros del archivo
                    Dim astrRows As Array = CreateArrayFromCSVHttpPostedFile(txtArticuloClienteEspecialArchivo.PostedFile)

                    ' Si el archivo contenía registros
                    If IsNothing(astrRows) = False AndAlso astrRows.Length > 0 Then

                        ' Eliminamos los registros existentes en la base de datos
                        Call Benavides.CC.Data.clstblDescuentoClienteEspecialCategoriaArticulos.intEliminar(0, 0, intClienteEspecialId, 0, 0, 0, #1/1/1900#, strUsuarioNombre, strConnectionString)

                        Dim strDivisionArticulosNombreId As String = ""
                        Dim strCategoriaArticulosNombreId As String = ""

                        Dim fltDescuentoClienteEspecialPorcentaje As Decimal = 0
                        Dim fltDescuentoClienteEspecialPorcentajeTope As Decimal = 0
                        Dim blnDescuentoClienteEspecialTotal As Byte = 0

                        For Each astrColumns As Array In astrRows

                            ' Si el renglón tiene el número de columnas adecuadas
                            If astrColumns.Length = 5 Then

                                ' Obtenemos los valores que vienen en el archivo
                                strDivisionArticulosNombreId = Replace(Replace(CStr(ConvertObject(astrColumns.GetValue(0), TypeCode.String)), Chr(13), ""), Chr(10), "")
                                strCategoriaArticulosNombreId = CStr(ConvertObject(astrColumns.GetValue(1), TypeCode.String))

                                fltDescuentoClienteEspecialPorcentaje = CDec(ConvertObject(astrColumns.GetValue(2), TypeCode.Decimal))
                                fltDescuentoClienteEspecialPorcentajeTope = CDec(ConvertObject(astrColumns.GetValue(3), TypeCode.Decimal))
                                blnDescuentoClienteEspecialTotal = CByte(ConvertObject(astrColumns.GetValue(4), TypeCode.Byte))

                                ' Agregamos los nuevos registros, si los valores de las columnas son válidos
                                If Len(strDivisionArticulosNombreId) > 0 And Len(strCategoriaArticulosNombreId) > 0 Then

                                    ' Actualizamos el registro
                                    intCounter += Benavides.CC.Data.clsClienteEspecial.intActualizarAgregarCategoriaArticulosConDescuentos(intClienteEspecialId, strDivisionArticulosNombreId, strCategoriaArticulosNombreId, fltDescuentoClienteEspecialPorcentaje, fltDescuentoClienteEspecialPorcentajeTope, blnDescuentoClienteEspecialTotal, strUsuarioNombre, strConnectionString)

                                End If

                            End If

                        Next

                        If intCounter > 0 Then

                            ' Agregamos el registro actual a la lista de registros a transmitirse a las sucursales
                            Dim aobjData As Array = Benavides.CC.Data.clstblDescuentoClienteEspecialCategoriaArticulos.strBuscar(0, 0, intClienteEspecialId, 0, 0, 0, #1/1/1900#, "", 0, 0, strConnectionString)

                            ' Si el arreglo tiene datos
                            If IsArray(aobjData) AndAlso aobjData.Length > 0 Then

                                ' Leemos la dirección de IP asignada a este Concentrador
                                Dim strTiendaConcentradorIP As String = System.Configuration.ConfigurationSettings.AppSettings("strTiendaConcentradorIP")

                                ' Leemos las tiendas asignadas a este cliente
                                Dim objStoresArray As Array = Benavides.CC.Data.clsClienteEspecial.strBuscarTiendas(intClienteEspecialId, strConnectionString)

                                ' Si la dirección IP del concentrador es correcta y existen tiendas a quienes enviar la información
                                If Len(strTiendaConcentradorIP) > 0 AndAlso IsNothing(objStoresArray) = False AndAlso objStoresArray.Length > 0 Then

                                    ' Enviamos los datos hacia los servidores de los puntos de venta
                                    Call Benavides.CC.Business.clsConcentrador.strEnvioServidorSucursalMsgCompleto("clstblDescuentoClienteEspecialCategoriaArticulos", Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ELIMINAR_AGREGAR, "POS", aobjData, objStoresArray)
                                    strJavascriptWindowOnLoadCommands &= "  alert(""Genero el envio del msg \n\r"");" & vbCrLf


                                End If

                            End If

                            ' Notificamos los registros actualizados
                            Dim dtmFinal As DateTime = Now()
                            strJavascriptWindowOnLoadCommands &= "  alert(""Total de líneas en el archivo: " & astrRows.Length & "\n\r\n\rTotal de registros importados: " & intCounter & "\n\r\n\rTotal de líneas sin importar: " & CStr(astrRows.Length - intCounter) & "\n\r\n\r\n\rTotal de registros enviados a cada sucursal: " & aobjData.Length & "\n\r\n\r\n\rInicio: " & dtmInicio & "\n\r\n\rFinal: " & dtmFinal & "\n\r\n\rTiempo estimado: " & DateDiff(DateInterval.Minute, dtmInicio, dtmFinal) & " minuto(s)\n\r"");" & vbCrLf

                        End If




                    End If

                End If

        End Select

    End Sub

End Class
