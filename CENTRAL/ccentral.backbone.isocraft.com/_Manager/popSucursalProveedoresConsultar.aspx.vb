Imports Isocraft.Web.Http
Imports System.Text
Imports System.Configuration
Imports Benavides.CC.Data
Imports Benavides.POSAdmin.Commons


Public Class popSucursalProveedoresConsultar
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

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

    End Sub

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


#Region " Class Private Attributes"

    Const strComitasDobles As String = """"
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
    ' Name       : strAccion
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strAccion() As String
        Get
            Return Request("strAccion")
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
            Return Request("strCmd")
        End Get
    End Property

    '====================================================================
    ' Name       : intFolioActualCarga 
    ' Description: Folio para importacion desde archivo
    ' Accessor   : Read
    ' Output     : Long
    '====================================================================
    Public ReadOnly Property lngFolioActualCarga() As Long
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("lngFolioActualCarga"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CLng(strTemporal)
            End If

        End Get
    End Property


    Public ReadOnly Property intProveedorId() As Integer
        Get
            Return CInt(Request("intProveedorId"))
        End Get

    End Property

    Public ReadOnly Property strProveedorNombreId() As String
        Get
            Return Request("strProveedorNombreId")
        End Get
    End Property

    Public ReadOnly Property strProveedorRazonSocial() As String
        Get
            Return Request("strProveedorRazonSocial")
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

    '====================================================================
    ' Name       : strSucursalNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalNombre() As String
        Get
            Dim strPasoNombre As String = UCase(Request("strSucursalNombre"))

            strPasoNombre = Replace(strPasoNombre, "Á", "A")
            strPasoNombre = Replace(strPasoNombre, "É", "E")
            strPasoNombre = Replace(strPasoNombre, "Í", "I")
            strPasoNombre = Replace(strPasoNombre, "Ó", "O")
            strPasoNombre = Replace(strPasoNombre, "Ú", "U")

            Return strPasoNombre
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

    Public ReadOnly Property strTituloConsulta() As String
        Get
            Select Case strCmd
                Case "VerA", "VerS"
                    Return Benavides.POSAdmin.Commons.clsCommons.strFormatearDescripcion(strProveedorNombreId & " - " & strProveedorRazonSocial)
                Case "VerP"
                    Return Benavides.POSAdmin.Commons.clsCommons.strFormatearDescripcion(strSucursalNombre)
                Case "VistaPrevia"
                    Return "Vista Previa Archivo de articulos a cargar"
            End Select

        End Get
    End Property

    '====================================================================
    ' Name       : strConsultar
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strConsultar() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 15
        Dim strRecordBrowserName As String = ""

        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim objDataArrayConsulta As Array

        Dim strTargetURL As String = strThisPageName & "?strCmd=" & strCmd & "&lngFolioActualCarga=" & lngFolioActualCarga.ToString & "&intProveedorId=" & intProveedorId.ToString & "&strProveedorNombreId=" & strProveedorNombreId & "&strProveedorRazonSocial=" & strProveedorRazonSocial & "&strSucursalId=" & strSucursalId & "&strSucursalNombre=" & strSucursalNombre & "&intCompaniaid=" & intCompaniaid & "&intSucursalid=" & intSucursalid & "&"

        Select Case strCmd

            Case "VerA"  ' Genera la consulta de articulos de un proveedor
                strRecordBrowserName = "SucursalProveedoresConsultarArticulos"
                objDataArrayConsulta = clsProveedor.strBuscarProveedorArticulosAutorizados(intProveedorId, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

            Case "VerS" ' Genera la consulta de sucursales de un proveedor
                strRecordBrowserName = "SucursalProveedoresConsultarSucursales"
                objDataArrayConsulta = clsProveedor.strBuscarProveedorSucursalesAsignadas(intProveedorId, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

            Case "VerP" 'Genera la consulta de proveedores de una sucursal especificada
                strRecordBrowserName = "SucursalProveedoresConsultarRelacion"
                objDataArrayConsulta = clsProveedor.arrBuscarSucursalProveedor(0, 0, 0, intCompaniaid, intSucursalid, "", Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

            Case "VistaPrevia"
                strRecordBrowserName = "SucursalProveedoresConsultarArticulos"
                objDataArrayConsulta = clsProveedor.strBuscarCargaProveedorArticulo(lngFolioActualCarga, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

        End Select

        Dim strTagAcutal As String = ""
        Dim strTagNuevo As String = ""

        If strCmd = "VerA" Or strCmd = "VerS" Or strCmd = "VerP" Then
            strTagAcutal = "<td align=""right"" class=""tdpadleft5"" id=""BotonDelNavegador""></td>"
            strTagNuevo = "<td align=""right"" class=""tdpadleft5"" ><input name=""cmdExportar"" type=""button"" class=""boton"" value=""Exportar Datos"" language=""javascript"" onclick=""return cmdExportar_onclick()"">&nbsp</td>"
        End If

        If strCmd = "VistaPrevia" Then
            strTagAcutal = "<br><span class=""txsubtitulo""><img src=""../static/images/bullet_subtitulos.gif"" width=""17"" height=""11"" align=""absmiddle"">Articulos autorizados al Proveedor</span><br>"
            strTagNuevo = "&nbsp;"
        End If

        Return Replace(Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, objDataArrayConsulta, intSelectedPage, intElementsPerPage, strTargetURL), strTagAcutal, strTagNuevo)

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If strAccion = "Exportar" Then

            Dim strNombreArchivoExcel As String = ""
            Dim strArchivoExcel As New System.Text.StringBuilder

            Dim objDataArrayExportar As Array
            Dim objRegistroExportar As System.Collections.SortedList = Nothing

            If strCmd = "VerA" Then

                strNombreArchivoExcel = "ArtAutorizados_" & strProveedorNombreId & ".csv"
                objDataArrayExportar = clsProveedor.strBuscarProveedorArticulosAutorizados(intProveedorId, 0, 0, strConnectionString)

            End If

            If strCmd = "VerS" Then

                strNombreArchivoExcel = "SucAsignadas_" & strProveedorNombreId & ".csv"
                objDataArrayExportar = clsProveedor.strBuscarProveedorSucursalesAsignadas(intProveedorId, 0, 0, strConnectionString)

            End If


            If strCmd = "VerP" Then

                strNombreArchivoExcel = "ProAsignados_" & intCompaniaid.ToString & intSucursalid.ToString & ".csv"
                objDataArrayExportar = clsProveedor.arrBuscarSucursalProveedor(0, 0, 0, intCompaniaid, intSucursalid, "", 0, 0, strConnectionString)

            End If

            If IsArray(objDataArrayExportar) AndAlso objDataArrayExportar.Length > 0 Then

                strArchivoExcel = New System.Text.StringBuilder

                For Each objRegistroExportar In objDataArrayExportar

                    If strCmd = "VerA" Then

                        Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(CStr(objRegistroExportar.Item("intArticuloId"))))
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(CStr(objRegistroExportar.Item("strArticuloDescripcion"))), ",", " "))
                        Call strArchivoExcel.Append(vbCrLf)

                    End If

                    If strCmd = "VerS" Then

                        Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(CStr(objRegistroExportar.Item("strCentroLogisticoId"))))
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(CStr(objRegistroExportar.Item("strSucursalNombre"))), ",", " "))
                        Call strArchivoExcel.Append(vbCrLf)

                    End If

                    If strCmd = "VerP" Then

                        Call strArchivoExcel.Append(clsCommons.strFormatearDescripcion(CStr(objRegistroExportar.Item("strProveedorNombreId"))))
                        Call strArchivoExcel.Append(",")
                        Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(CStr(objRegistroExportar.Item("strProveedorRazonSocial"))), ",", " "))
                        Call strArchivoExcel.Append(vbCrLf)

                    End If

                Next

                Dim strArchivoDestino As String = "attachment;filename=" & strComitasDobles & strNombreArchivoExcel & strComitasDobles


                Response.ContentType = "application/octet-stream"
                Call Response.AddHeader("Content-Disposition", "attachment;filename=" & strComitasDobles & strNombreArchivoExcel & strComitasDobles)

                Call Response.Write(strArchivoExcel.ToString)
                Call Response.End()
            End If
        End If
    End Sub

End Class
