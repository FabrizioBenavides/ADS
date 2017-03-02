Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert

'====================================================================
' Class         : SucursalAdministrarDevolucionArticuloAutorizado
' Title         : SucursalAdministrarDevolucionArticuloAutorizado
' Description   : creacion de clases
' Copyright     : 2016 All rights reserved
' Company       : Benavides
' Author        :  
' Last Modified : Lunes, 12 de Abril de 2010
'====================================================================

Public Class SucursalAdministrarDevolucionArticuloAutorizado
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtArchivo As System.Web.UI.HtmlControls.HtmlInputFile

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, _
                              ByVal e As System.EventArgs) _
                Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        strProveedorId = GetPageParameter("strProveedorId", GetPageParameter("txtProveedorId", ""))

    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String

    Private strmProveedorId As String

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
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request)
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
    ' Name       : strProveedorId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : string
    '====================================================================
    Public Property strProveedorId() As String
        Get
            Return strmProveedorId
        End Get
        Set(ByVal strValue As String)
            strmProveedorId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : 
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 2000
        Const strRecordBrowserName As String = "SucursalAdministrarDevolucionArticuloAutorizado"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim aobjDataArray As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsMercancia.clsDevolucion.strBuscarArticuloAutorizado(strProveedorId, 0, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

        ' Generamos el URL destino de las páginas
        Dim strTargetURL As String = strThisPageName & "?strProveedorId=" & strProveedorId & "&"


        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, aobjDataArray, intSelectedPage, intElementsPerPage, strTargetURL)

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then

            Call Response.Redirect("../Default.aspx")

        End If

        ' Declaramos las constantes locales
        Const intNumeroColumnasArchivo As Int32 = 2

        Dim intReturnedValue As Integer
        Dim intCounter As Integer

        Dim dtmInicio As DateTime
        Dim dtmFinal As DateTime

        ' Execute the selected command
        Select Case strCmd

            Case "Agregar"

                ' Verificamos si el archivo ha sido enviado
                If IsNothing(txtArchivo.PostedFile) = False Then

                    dtmInicio = Now()

                    ' Obtenemos un arreglo con los renglones del archivo
                    Dim astrRows As Array = CreateArrayFromCSVHttpPostedFile(txtArchivo.PostedFile)

                    ' Por cada renglón existente
                    If IsNothing(astrRows) = False AndAlso astrRows.Length > 0 Then

                        For Each astrColumns As Array In astrRows

                            ' Si el renglón tiene el número de columnas adecuadas
                            If astrColumns.Length = intNumeroColumnasArchivo Then

                                ' Obtenemos los valores que vienen en el archivo
                                Dim strProveedorId As String = Replace(Replace(CStr(ConvertObject(astrColumns.GetValue(0), TypeCode.String)), Chr(13), ""), Chr(10), "")
                                Dim intArticuloId As Integer = CInt(ConvertObject(astrColumns.GetValue(1), TypeCode.Int32))

                                ' Agregamos los nuevos registros, si los valores de las columnas son válidos
                                If Len(strProveedorId) > 0 AndAlso intArticuloId > 0 Then

                                    ' Actualizar/Agregar el registro
                                    intReturnedValue = Benavides.CC.Business.clsConcentrador.clsSucursal.clsMercancia.clsDevolucion.intActualizarAgregarArticuloAutorizado(strProveedorId, intArticuloId, strUsuarioNombre, strConnectionString)

                                    ' Si el registro logró ser agregado
                                    If intReturnedValue > 0 Then

                                        ' Incrementamos el contador de registros procesados exitósamente
                                        intCounter += intReturnedValue

                                    End If

                                End If

                            End If

                        Next

                        ' Notificamos los registros actualizados
                        dtmFinal = Now()
                        strJavascriptWindowOnLoadCommands &= "  alert(""Total de líneas en el archivo: " & astrRows.Length & "\n\r\n\rTotal de registros importados: " & intCounter & "\n\r\n\rTotal de líneas sin importar: " & CStr(astrRows.Length - intCounter) & "\n\r\n\rInicio: " & dtmInicio & "\n\r\n\rFinal: " & dtmFinal & "\n\r\n\rTiempo estimado: " & DateDiff(DateInterval.Minute, dtmInicio, dtmFinal) & " minuto(s)"");" & vbCrLf

                    End If

                End If

            Case "Reemplazar"

                ' Verificamos si el archivo ha sido enviado y el cliente especial ha sido especificado
                If IsNothing(txtArchivo.PostedFile) = False Then

                    dtmInicio = Now()

                    ' Obtenemos un arreglo con los registros del archivo
                    Dim astrRows As Array = CreateArrayFromCSVHttpPostedFile(txtArchivo.PostedFile)

                    ' Si el archivo contenía registros
                    If IsNothing(astrRows) = False AndAlso astrRows.Length > 0 Then

                        ' Eliminamos los registros existentes en la base de datos
                        Call Benavides.CC.Business.clsConcentrador.clsSucursal.clsMercancia.clsDevolucion.intEliminarArticuloAutorizado("", 0, strUsuarioNombre, strConnectionString)

                        ' Por cada registro existente
                        For Each astrColumns As Array In astrRows

                            ' Si el registro tiene el número de columnas adecuadas
                            If astrColumns.Length = intNumeroColumnasArchivo Then

                                ' Obtenemos los valores que vienen en el archivo
                                Dim strProveedorId As String = Replace(Replace(CStr(ConvertObject(astrColumns.GetValue(0), TypeCode.String)), Chr(13), ""), Chr(10), "")
                                Dim intArticuloId As Integer = CInt(ConvertObject(astrColumns.GetValue(1), TypeCode.Int32))

                                ' Agregamos los nuevos registros, si los valores de las columnas son válidos
                                If Len(strProveedorId) > 0 AndAlso intArticuloId > 0 Then

                                    ' Actualizar/Agregar el registro
                                    intReturnedValue = Benavides.CC.Business.clsConcentrador.clsSucursal.clsMercancia.clsDevolucion.intActualizarAgregarArticuloAutorizado(strProveedorId, intArticuloId, strUsuarioNombre, strConnectionString)

                                    ' Si el registro logró ser agregado
                                    If intReturnedValue > 0 Then

                                        ' Incrementamos el contador de registros procesados exitósamente
                                        intCounter += intReturnedValue

                                    End If

                                End If

                            End If

                        Next

                        ' Notificamos los registros actualizados
                        dtmFinal = Now()
                        strJavascriptWindowOnLoadCommands &= "  alert(""Total de líneas en el archivo: " & astrRows.Length & "\n\r\n\rTotal de registros importados: " & intCounter & "\n\r\n\rTotal de líneas sin importar: " & CStr(astrRows.Length - intCounter) & "\n\r\n\r\n\rInicio: " & dtmInicio & "\n\r\n\rFinal: " & dtmFinal & "\n\r\n\rTiempo estimado: " & DateDiff(DateInterval.Minute, dtmInicio, dtmFinal) & " minuto(s)\n\r"");" & vbCrLf

                    End If

                End If

            Case "Eliminar"

                ' Eliminamos los registros existentes en la base de datos
                Call Benavides.CC.Business.clsConcentrador.clsSucursal.clsMercancia.clsDevolucion.intEliminarArticuloAutorizado(strProveedorId, 0, strUsuarioNombre, strConnectionString)


        End Select

    End Sub

End Class


