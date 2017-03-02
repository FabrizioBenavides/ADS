Imports Isocraft.Web.Convert
Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

Imports System.Text
Imports System.Collections
Imports System.Configuration
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business
'Imports Benavides.CC.Business.clsConcentrador

Public Class popVentasPromocionesMonederoRelacionSucursalArchivo
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtSucursalArchivo As System.Web.UI.HtmlControls.HtmlInputFile

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
    ' Name       : intPromocionId 
    ' Description: Id promocion
    ' Accessor   : Read
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intPromocionId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intPromocionId"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

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

            strTemporal = Trim(Request("hdnFolioActualCarga"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CLng(strTemporal)
            End If

        End Get
    End Property

    Public ReadOnly Property intPromocionEliminarId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intPromocionEliminarId"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property
    Public ReadOnly Property intCompaniaEliminarId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intCompaniaEliminarId"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property

    Public ReadOnly Property intSucursalEliminarId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intSucursalEliminarId"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : strConsultarSucursales
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strConsultarSucursales() As String

        Dim htmlResult As String = ""

        Dim strRecordBrowserName As String = "popVentasPromocionesMonederoRelacionSucursalArchivo"

        ' Declaramos e inicialziamos las variables locales
        Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))

        If intSelectedPage <= 0 Then
            intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
        End If

        'Parametro inicial en -1 para indicar que son todas las sucursales de la promocion indicada
        Dim objDataArraySucursales As Array = clsPromocionMonedero.strBuscarSucursal(-1, 0, 0, 0, CStr(intPromocionId), 0, 0, strConnectionString)

        Dim maxPerPage As Integer = 15

        Dim headers As ArrayList = New ArrayList
        headers.Add("Sucursal")
        headers.Add("Nombre")
        headers.Add("Acciones")
        Dim columnOrder As Integer() = {0, 1}

        Dim pkNames As String() = {"intPromocionEliminarId", "intCompaniaEliminarId", "intSucursalEliminarId"}
        Dim pkIndexes As Integer() = {2, 3, 4}

        Dim actions As ArrayList = New ArrayList
        actions.Add(New Benavides.CC.Commons.clsActionLink("EliminarSucursal", pkNames, pkIndexes, "imgNRborrar.gif", "Haga clic aquí para eliminar esta sucursal de la promoción"))

        htmlResult = Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objDataArraySucursales.Length, intSelectedPage, maxPerPage, "popVentasPromocionesMonederoRelacionSucursalArchivo.aspx", Nothing)
        htmlResult &= Benavides.CC.Commons.clsRecordBrowserNew.displayTable(headers, objDataArraySucursales, columnOrder, actions, intSelectedPage, maxPerPage, -1)

        Return htmlResult

    End Function

    Function intCargarArchivoSucursal(ByVal lngFolioCargaId As Long) As Integer

        Dim intErrorCarga As Integer = 0
        Dim intContadorCarga As Integer = 0

        ' Obtenemos un arreglo con los renglones del archivo
        Dim objArchivoCarga As Array = CreateArrayFromCSVHttpPostedFile(txtSucursalArchivo.PostedFile)

        If IsNothing(objArchivoCarga) = False AndAlso objArchivoCarga.Length > 0 Then

            Dim intCompaniaAlta As Double = 0
            Dim intSucursalAlta As Double = 0

            For Each astrColumns As Array In objArchivoCarga


                If astrColumns.Length = 1 Then ' Se lee si el renglón tiene el número de columnas adecuadas

                    ' Obtenemos el valor que vienen en el archivo
                    Dim strSucursalArchivoId As String = Replace(Replace(CStr(ConvertObject(astrColumns.GetValue(0), TypeCode.String)), Chr(0), ""), Chr(10), "")

                    intCompaniaAlta = 0
                    intSucursalAlta = 0

                    If Len(strSucursalArchivoId) > 0 Then  'Inicio busqueda de sucursal

                        Dim objArraySucursal As Array = clsConcentrador.clsSucursal.strBuscar(strSucursalArchivoId, strConnectionString)


                        If IsArray(objArraySucursal) AndAlso objArraySucursal.Length > 0 Then

                            Dim objRegistroSucursal As System.Collections.SortedList = DirectCast(objArraySucursal.GetValue(0), System.Collections.SortedList)

                            intCompaniaAlta = CInt(objRegistroSucursal.Item("intCompaniaId"))
                            intSucursalAlta = CInt(objRegistroSucursal.Item("intSucursalId"))

                        End If

                        If intCompaniaAlta > 0 And intSucursalAlta > 0 Then ' Solo se pasa si la sucursal existe en el catalogo

                            intContadorCarga += clsPromocionMonedero.intCargaAgregarSucursal(lngFolioCargaId, intCompaniaAlta, intSucursalAlta, strSucursalArchivoId, strUsuarioNombre, strConnectionString)

                        End If

                    End If '-- Final de busqueda de articulo

                Else

                    intErrorCarga = -120 'El registro no tiene la estructura correcta

                End If '-- Final de lectura de registro

            Next

        Else

            intErrorCarga = -110  'No se pudo abrir el archivo a cargar

        End If


        If intErrorCarga < 0 Then
            Return intErrorCarga
        Else
            Return intContadorCarga
        End If

    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim lngFolioCargaId As Long
        Dim strHTML As New StringBuilder

        If lngFolioActualCarga < 1 Then
            lngFolioCargaId = Now.Ticks
        Else
            lngFolioCargaId = lngFolioActualCarga
        End If

        Select Case strCmd

            Case "PrevioArchivoSucursal"

                Dim intCargaArchivo As Integer = intCargarArchivoSucursal(lngFolioCargaId)

                strHTML.Append("<script language='Javascript'> parent.fnVerPrevioCarga( " & _
                          strComitasDobles & intCargaArchivo.ToString & strComitasDobles & "," & _
                          strComitasDobles & lngFolioCargaId.ToString & strComitasDobles & _
                          "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "AgregarSucursal"

                Dim intActualizacion As Integer = 0
                Dim intCargaArchivo As Integer = 0

                Dim lngFolioCargaEnvioId As Long = 0

                lngFolioCargaEnvioId = lngFolioCargaId

                intCargaArchivo = intCargarArchivoSucursal(lngFolioCargaId)

                If intCargaArchivo >= 0 Then
                    intActualizacion = clsPromocionMonedero.intCargaImportarSucursal(lngFolioCargaId, intPromocionId, strUsuarioNombre, strConnectionString)
                Else
                    intActualizacion = intCargaArchivo ' Error desde la carga del archivo
                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpAgregarSucursal( " & _
                strComitasDobles & intActualizacion.ToString & strComitasDobles & _
                "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "EliminarSucursal"

                Dim intEliminar As Integer = 0

                intEliminar = clsPromocionMonedero.intEliminarSucursalPromocionMonedero(intPromocionEliminarId, 0, 0, intCompaniaEliminarId, intSucursalEliminarId, strUsuarioNombre, strConnectionString)

                strHTML.Append("<script language='Javascript'> parent.fnUpEliminarSucursal( " & _
                           strComitasDobles & intEliminar.ToString & strComitasDobles & _
                           "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

        End Select


    End Sub

End Class
