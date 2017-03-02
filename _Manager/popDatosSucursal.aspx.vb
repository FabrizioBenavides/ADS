Imports Isocraft.Web.Convert
Imports Isocraft.Web.Http
Imports System.Text
Imports System.Configuration

Imports Benavides.CC.Business.clsConcentrador
Imports Benavides.POSAdmin.Commons

Public Class popDatosSucursal
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
    End Sub

#End Region

    Const strComitasDobles As String = """"

    ' Variables privadas locales
    Private strmJavascriptWindowOnLoadCommands As String

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
    ' Name       : strThisPageName
    ' Description: Nombre de esta página
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request)
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
    ' Description: Obtiene la cadena de conexión hacia la base de datos
    ' Accessor   : Read
    ' Throws     : None
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
    ' Throws     : None
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
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return Request("strCmd")
        End Get
    End Property


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Check if the current user can access this page
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        If strCmd = "Consultar" Then

            'Put user code to initialize the page here
            Dim strHTML As New StringBuilder

            Dim objArraySucursal As Array = Nothing
            Dim objRegistroSucursal As System.Collections.SortedList = Nothing

            Dim intEncontrada As Integer = 0
            Dim intCompaniaId As Integer = 0
            Dim intSucursalId As Integer = 0
            Dim strCentroLogisticoId As String = ""
            Dim strSucursalNombre As String = ""
            Dim intDireccionOperativaId As Integer = 0
            Dim strDireccionOperativaNombre As String = ""
            Dim intZonaOperativaId As Integer = 0
            Dim strZonaOperativaNombre As String = ""
            Dim intEstadoId As Integer = 0
            Dim strEstadoNombre As String = ""
            Dim intCiudadId As Integer = 0
            Dim strCiudadNombre As String = ""

            objArraySucursal = clsSucursal.strBuscar(Request("txtBuscaSucursal"), strConnectionString)

            If IsArray(objArraySucursal) AndAlso objArraySucursal.Length > 0 Then

                objRegistroSucursal = DirectCast(objArraySucursal.GetValue(0), System.Collections.SortedList)

                intCompaniaId = CInt(objRegistroSucursal.Item("intCompaniaId"))
                intSucursalId = CInt(objRegistroSucursal.Item("intSucursalId"))
                strCentroLogisticoId = clsCommons.strFormatearDescripcion(CStr(objRegistroSucursal.Item("strCentroLogisticoId")))
                strSucursalNombre = clsCommons.strFormatearDescripcion(CStr(objRegistroSucursal.Item("strSucursalNombre")))

                intDireccionOperativaId = CInt(objRegistroSucursal.Item("intDireccionOperativaId"))
                strDireccionOperativaNombre = clsCommons.strFormatearDescripcion(CStr(objRegistroSucursal.Item("strDireccionOperativaNombre")))

                intZonaOperativaId = CInt(objRegistroSucursal.Item("intZonaOperativaId"))
                strZonaOperativaNombre = clsCommons.strFormatearDescripcion(CStr(objRegistroSucursal.Item("strZonaOperativaNombre")))

                intEstadoId = CInt(objRegistroSucursal.Item("intEstadoId"))
                strEstadoNombre = clsCommons.strFormatearDescripcion(CStr(objRegistroSucursal.Item("strEstadoNombre")))

                intCiudadId = CInt(objRegistroSucursal.Item("intCiudadId"))
                strCiudadNombre = clsCommons.strFormatearDescripcion(CStr(objRegistroSucursal.Item("strCiudadNombre")))

                intEncontrada = 1

            End If

            strHTML.Append("<script language='Javascript'> parent.fnConsultar( " & _
               strComitasDobles & intCompaniaId.ToString & strComitasDobles & "," & _
               strComitasDobles & intSucursalId.ToString & strComitasDobles & "," & _
               strComitasDobles & strCentroLogisticoId & strComitasDobles & "," & _
               strComitasDobles & strSucursalNombre & strComitasDobles & "," & _
               strComitasDobles & intDireccionOperativaId.ToString & strComitasDobles & "," & _
               strComitasDobles & strDireccionOperativaNombre & strComitasDobles & "," & _
               strComitasDobles & intZonaOperativaId.ToString & strComitasDobles & "," & _
               strComitasDobles & strZonaOperativaNombre & strComitasDobles & "," & _
               strComitasDobles & intEstadoId.ToString & strComitasDobles & "," & _
               strComitasDobles & strEstadoNombre & strComitasDobles & "," & _
               strComitasDobles & intCiudadId.ToString & strComitasDobles & "," & _
               strComitasDobles & strCiudadNombre & strComitasDobles & "," & _
               strComitasDobles & intEncontrada.ToString & strComitasDobles & _
               "); </script>")

            Response.Write(strHTML.ToString)
            Response.End()

        End If


    End Sub

End Class
