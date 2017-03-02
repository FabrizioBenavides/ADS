Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert

'====================================================================
' Class         : clsVentasAdministrarArticulosExceptosDeDescuento
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Administraci�n de art�culos exceptos de descuento.
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Joaqu�n Hdz. G. (joaquin@isocraft.com)
' Last Modified : Tuesday, January 18, 2005
'====================================================================
Public Class clsVentasAdministrarArticulosExceptosDeDescuento
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
        intGrupoClienteEspecialId = GetPageParameter("intGrupoClienteEspecialId", GetPageParameter("cboGrupoClienteEspecial", 0))
        intTipoExceptoId = GetPageParameter("intTipoExceptoId", GetPageParameter("cboTipoExcepto", 0))
    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private intmGrupoClienteEspecialId As Integer
    Private intmTipoExceptoId As Integer

#End Region

    '====================================================================
    ' Name       : intGrupoClienteEspecialId
    ' Description: Identificador del Grupo de Clientes Especiales
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intGrupoClienteEspecialId() As Integer
        Get
            Return intmGrupoClienteEspecialId
        End Get
        Set(ByVal intValue As Integer)
            intmGrupoClienteEspecialId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intTipoExceptoId
    ' Description: Identificador del Tipo de Excepto
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intTipoExceptoId() As Integer
        Get
            Return intmTipoExceptoId
        End Get
        Set(ByVal intValue As Integer)
            intmTipoExceptoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoExceptoComboBox
    ' Description: Regresa una cadena de texto con el c�digo Javascript
    '              que llena al combo box "cboTipoExcepto"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strTipoExceptoComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboTipoExcepto", intTipoExceptoId, Benavides.CC.Data.clstblTipoExcepto.strBuscar(0, "", "", Now, "", 0, 0, strConnectionString), 0, 2, 1)
    End Function

    '====================================================================
    ' Name       : strLlenarGrupoClienteEspecialComboBox
    ' Description: Regresa una cadena de texto con el c�digo Javascript
    '              que llena al combo box "cboGrupoClienteEspecial"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarGrupoClienteEspecialComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboGrupoClienteEspecial", intGrupoClienteEspecialId, Benavides.CC.Data.clstblGrupoClienteEspecial.strBuscar(0, "", "", Now(), "", 0, 0, strConnectionString), 0, 1, 1)
    End Function

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
    ' Description: Genera la fecha y hora de la p�gina
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
    ' Name       : strThisPageName
    ' Description: URL de esta p�gina
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
    ' Description: Obtiene la cadena de conexi�n hacia la base de datos
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
    ' Name       : strGetRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String

        If intGrupoClienteEspecialId > 0 AndAlso intTipoExceptoId > 0 Then

            ' Declaramos e inicializamos las constantes locales
            Const intElementsPerPage As Integer = 50
            Const strRecordBrowserName As String = "VentasAdministrarArticulosExceptosDeDescuento"

            ' Declaramos e inicializamos las variables locales
            Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
            Dim astrDataArray As Array = Benavides.CC.Data.clsExceptoDescuentoArticulo.strBuscar(intGrupoClienteEspecialId, intTipoExceptoId, 0, Now(), "", Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

            ' Generamos el navegador de registros
            Dim strTargetURL As String = strThisPageName & "?intGrupoClienteEspecialId=" & intGrupoClienteEspecialId & "&intTipoExceptoId=" & intTipoExceptoId & "&"
            Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strTargetURL)

        End If

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la p�gina de acceso, si no tiene privilegios de acceder a esta p�gina
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Select Case strCmd

            Case "Agregar"

                ' Verificamos si el archivo ha sido enviado y el cliente especial ha sido especificado
                If IsNothing(txtArticuloClienteEspecialArchivo.PostedFile) = False AndAlso intGrupoClienteEspecialId > 0 AndAlso intTipoExceptoId > 0 Then

                    Dim intCounter As Integer
                    Dim dtmInicio As DateTime = Now()

                    ' Obtenemos un arreglo con los renglones del archivo
                    Dim astrRows As Array = CreateArrayFromCSVHttpPostedFile(txtArticuloClienteEspecialArchivo.PostedFile)

                    ' Por cada rengl�n existente
                    If IsNothing(astrRows) = False AndAlso astrRows.Length > 0 Then

                        ' Eliminamos los registros existentes en la base de datos
                        Call Benavides.CC.Data.clstblExceptoDescuentoArticulo.intEliminar(intGrupoClienteEspecialId, intTipoExceptoId, 0, Now(), strUsuarioNombre, strConnectionString)

                        For Each astrColumns As Array In astrRows

                            ' Si el rengl�n tiene el n�mero de columnas adecuadas
                            If astrColumns.Length = 1 Then

                                ' Obtenemos los valores que vienen en el archivo
                                Dim intArticuloId As Integer = CInt(ConvertObject(astrColumns.GetValue(0), TypeCode.Int32))

                                ' Si los valores de las columnas son v�lidos
                                If intArticuloId > 0 Then

                                    ' Agregamos el nuevo registro
                                    intCounter += Benavides.CC.Data.clstblExceptoDescuentoArticulo.intAgregar(intGrupoClienteEspecialId, intTipoExceptoId, intArticuloId, Now(), strUsuarioNombre, strConnectionString)

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
                If IsNothing(txtArticuloClienteEspecialArchivo.PostedFile) = False AndAlso intGrupoClienteEspecialId > 0 AndAlso intTipoExceptoId > 0 Then

                    Dim intCounter As Integer
                    Dim dtmInicio As DateTime = Now()
                    Dim aobjDataList As System.Collections.ArrayList

                    ' Obtenemos un arreglo con los registros del archivo
                    Dim astrRows As Array = CreateArrayFromCSVHttpPostedFile(txtArticuloClienteEspecialArchivo.PostedFile)

                    ' Si el archivo conten�a registros
                    If IsNothing(astrRows) = False AndAlso astrRows.Length > 0 Then

                        ' Eliminamos los registros existentes en la base de datos
                        Call Benavides.CC.Data.clstblExceptoDescuentoArticulo.intEliminar(intGrupoClienteEspecialId, intTipoExceptoId, 0, Now(), strUsuarioNombre, strConnectionString)
                        aobjDataList = New System.Collections.ArrayList

                        ' Por cada registro existente
                        For Each astrColumns As Array In astrRows

                            ' Si el registro tiene el n�mero de columnas adecuadas
                            If astrColumns.Length = 1 Then

                                ' Obtenemos los valores que vienen en el archivo
                                Dim intArticuloId As Integer = CInt(ConvertObject(astrColumns.GetValue(0), TypeCode.Int32))

                                ' Agregamos los nuevos registros, si los valores de las columnas son v�lidos
                                If intArticuloId > 0 Then

                                    ' Agregamos el nuevo registros a la base de datos
                                    Dim intReturnedValue As Integer = Benavides.CC.Data.clstblExceptoDescuentoArticulo.intAgregar(intGrupoClienteEspecialId, intTipoExceptoId, intArticuloId, Now(), strUsuarioNombre, strConnectionString)

                                    ' Si el registro logr� ser agregado
                                    If intReturnedValue > 0 Then

                                        ' Agregamos el registro actual a la lista de registros a transmitirse a las sucursales
                                        Call aobjDataList.Add(New String() {CStr(intGrupoClienteEspecialId), CStr(intTipoExceptoId), CStr(intArticuloId), Now.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), strUsuarioNombre})

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

                            ' Leemos la totalidad de tiendas existentes que son atendidas por todos los Concentradores
                            Dim objStoresArray As Array = Benavides.CC.Data.clstblTienda.strBuscar(0, 0, 0, "", "", 0, "", 0, "", "", Now, "", 0, 0, strConnectionString)

                            ' Si existen tiendas a quienes enviar la informaci�n
                            If IsNothing(objStoresArray) = False AndAlso objStoresArray.Length > 0 Then

                                ' Enviamos los datos hacia los servidores de los puntos de venta
                                Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeCompletoHaciaServidoresPuntoDeVenta("clstblExceptoDescuentoArticulo", Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ELIMINAR_AGREGAR, "POS", aobjData, objStoresArray)

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
