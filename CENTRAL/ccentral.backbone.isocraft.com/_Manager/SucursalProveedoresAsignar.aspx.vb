Imports Isocraft.Web.Convert
Imports Isocraft.Web.Http
Imports System.Text
Imports System.Configuration
Imports Benavides.CC.Data
Imports Benavides.POSAdmin.Commons


Public Class SucursalProveedoresAsignar
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtArticulosArchivo As System.Web.UI.HtmlControls.HtmlInputFile

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

    End Sub

#End Region

#Region " Class Private Attributes"

    Const strComitasDobles As String = """"
    Private strmJavascriptWindowOnLoadCommands As String



#End Region

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
            Return Request("strCmd")
        End Get
    End Property

    '====================================================================
    ' Name       : intEstadoId 
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intEstadoId() As Integer
        Get
            Return CInt(Request("intEstadoId"))
        End Get
    End Property

    '====================================================================
    ' Name       : intCiudadId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intCiudadId() As Integer
        Get
            Return CInt(Request("intCiudadId"))
        End Get
    End Property

    '====================================================================
    ' Name       : intCadenaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intCadenaId() As Integer
        Get
            Return CInt(Request("intCadenaId"))
        End Get
    End Property

    '====================================================================
    ' Name       : strSucursalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalId() As String
        Get
            Return Request("strSucursalId")
        End Get
    End Property

    Public ReadOnly Property intCompaniaid() As Integer
        Get
            Dim intmCompaniaid As Integer = 0

            If Len(strSucursalId) > 3 Then
                Dim astrCompaniaSucursal As Array = Split(strSucursalId, "|")
                If astrCompaniaSucursal.Length > 0 Then
                    intmCompaniaid = CInt(astrCompaniaSucursal.GetValue(0))
                End If
            End If

            Return intmCompaniaid

        End Get

    End Property

    Public ReadOnly Property intSucursalid() As Integer
        Get
            Dim intmSucursalid As Integer = 0

            If Len(strSucursalId) > 3 Then
                Dim astrCompaniaSucursal As Array = Split(strSucursalId, "|")
                If astrCompaniaSucursal.Length > 0 Then
                    intmSucursalid = CInt(astrCompaniaSucursal.GetValue(1))
                End If
            End If

            Return intmSucursalid

        End Get

    End Property

    Public ReadOnly Property intProveedorId() As Integer
        Get
            Return CInt(Request("hdnProveedorId"))
        End Get

    End Property

    Public ReadOnly Property strProveedorNombreId() As String
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("txtProveedorNombreId"))

            If strTemporal.Equals("") Then
                Return ""
            Else
                Return strTemporal
            End If

        End Get
    End Property

    Public ReadOnly Property strProveedorRazonSocial() As String
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("txtProveedorRazonSocial"))

            If strTemporal.Equals("") Then
                Return ""
            Else
                Return strTemporal
            End If
        End Get
    End Property


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim objArrayConsulta As Array = Nothing
        Dim strRegistroConsulta As String() = Nothing
        Dim intResultado As Integer

        Dim strHTML As New StringBuilder

        Select Case strCmd

            Case "BuscarProveedor"

                Dim objArrayProveedor As Array = Nothing
                Dim objRegistroProveedor As System.Collections.SortedList = Nothing

                Dim strBusquedaProveedorId As String = ""
                Dim strBusquedaProveedorNombreId As String = ""
                Dim strBusquedaProveedorRazonSocial As String = ""
                Dim strBusquedaProveedorRFC As String = ""
                Dim strBusquedaProveedorError As String = "-100"

                If IsNumeric(Mid(strProveedorNombreId, 1, 4)) Then

                    objArrayProveedor = clsProveedor.strBuscar("", strProveedorNombreId, 0, 0, strConnectionString)

                    If IsArray(objArrayProveedor) AndAlso objArrayProveedor.Length > 0 Then

                        objRegistroProveedor = DirectCast(objArrayProveedor.GetValue(0), System.Collections.SortedList)

                        ' Asignamos los datos del proveedor

                        strBusquedaProveedorId = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("intProveedorId")))
                        strBusquedaProveedorNombreId = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorNombreId")))
                        strBusquedaProveedorRazonSocial = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorRazonSocial")))
                        strBusquedaProveedorRFC = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorRFC")))
                        strBusquedaProveedorError = "0"

                    End If

                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpBuscarProveedor( " & _
                               strComitasDobles & strBusquedaProveedorId & strComitasDobles & "," & _
                               strComitasDobles & strBusquedaProveedorNombreId & strComitasDobles & "," & _
                               strComitasDobles & strBusquedaProveedorRazonSocial & strComitasDobles & "," & _
                               strComitasDobles & strBusquedaProveedorRFC & strComitasDobles & "," & _
                               strComitasDobles & strBusquedaProveedorError & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "AgregarProveedor"

                Dim intContadorAlta As Integer = 0
                Dim intErrorAgregar As Integer = 0

                intContadorAlta = clsProveedor.intActualizarAgregarProveedorSucursalesAsignadas(intProveedorId, intEstadoId, intCiudadId, intCadenaId, intCompaniaid, intSucursalid, strUsuarioNombre, strConnectionString)

                If intContadorAlta < 0 Then

                    intErrorAgregar = -100 'Error al aplicar el proveedor a las sucursales

                End If


                strHTML.Append("<script language='Javascript'> parent.fnUpAgregarProveedor( " & _
                           strComitasDobles & intErrorAgregar.ToString & strComitasDobles & "," & _
                           strComitasDobles & intContadorAlta.ToString & strComitasDobles & _
                           "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()


        End Select

    End Sub

End Class
