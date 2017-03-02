Imports Isocraft.Web.Convert
Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

Imports System.Text
Imports System.Collections
Imports System.Configuration
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business


Public Class popVentasPromocionesMonederoDetalleArticulo
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
    ' Name       : intOpcAct
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intOpcAct() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intOpcAct"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : blnActualizaPromocion 
    ' Description: 
    ' Accessor   : Read
    ' Output     : byte
    '====================================================================
    Public ReadOnly Property blnActualizaPromocion() As Byte
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("blnActualizaPromocion"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CByte(strTemporal)
            End If

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

    '====================================================================
    ' Name       : intArticuloId 
    ' Description: Numero de Articulo
    ' Accessor   : Read
    ' Output     : Long
    '====================================================================
    Public ReadOnly Property intArticuloId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("txtArticuloId"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : dblPorcentaje 
    ' Description: Monto del descuento
    ' Accessor   : Read
    ' Output     : integer
    '====================================================================
    Public ReadOnly Property dblPorcentaje() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("dblPorcentaje"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
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

    Public ReadOnly Property intArticuloEliminarId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intArticuloEliminarId"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : strConsultarDetalle
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strConsultarDetalle() As String

        Dim htmlResult As String = ""


        If intPromocionId > 0 Then

            Dim strRecordBrowserName As String = "popVentasPromocionesMonederoDetalleArticulo"

            ' Declaramos e inicialziamos las variables locales
            Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))

            If intSelectedPage <= 0 Then
                intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
            End If

            Dim objDataArrayArticulos As Array = clsPromocionMonedero.strBuscarArticulos(intPromocionId.ToString, 0, 0, strConnectionString)

            Dim maxPerPage As Integer = 15

            Dim headers As ArrayList = New ArrayList
            headers.Add("Articulo")
            headers.Add("Descripción")
            headers.Add("% Monedero")
            headers.Add("Acciones")
            Dim columnOrder As Integer() = {1, 2, 3}

            Dim pkNames As String() = {"intPromocionEliminarId", "intArticuloEliminarId"}
            Dim pkIndexes As Integer() = {0, 1}

            Dim actions As ArrayList = New ArrayList
            actions.Add(New Benavides.CC.Commons.clsActionLink("EliminarArticulo", pkNames, pkIndexes, "imgNRborrar.gif", "Haga clic aquí para eliminar este articulo de la promoción"))

            htmlResult = Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objDataArrayArticulos.Length, intSelectedPage, maxPerPage, "popVentasPromocionesMonederoDetalleArticulo.aspx", Nothing)
            htmlResult += Benavides.CC.Commons.clsRecordBrowserNew.displayTable(headers, objDataArrayArticulos, columnOrder, actions, intSelectedPage, maxPerPage, -1)

        End If

        Return htmlResult

    End Function


    Function intCargarArchivoArticulos(ByVal lngFolioCargaId As Long) As Integer

        Dim intErrorCarga As Integer = 0
        Dim intContadorCarga As Integer = 0

        ' Obtenemos un arreglo con los renglones del archivo
        Dim objArchivoCarga As Array = CreateArrayFromCSVHttpPostedFile(txtArticulosArchivo.PostedFile)

        If IsNothing(objArchivoCarga) = False AndAlso objArchivoCarga.Length > 0 Then

            Dim dblArticuloArchivoId As Double = 0
            Dim dblArticuloAlta As Double = 0

            Dim dblPorcentajeAlta As Double = 0


            For Each astrColumns As Array In objArchivoCarga


                If astrColumns.Length = 2 Then ' Se lee si el renglón tiene el número de columnas adecuadas

                    ' Obtenemos el valor que vienen en el archivo
                    dblArticuloArchivoId = CDbl(ConvertObject(astrColumns.GetValue(0), TypeCode.Double))
                    dblPorcentajeAlta = CDbl(ConvertObject(astrColumns.GetValue(1), TypeCode.Double))

                    If dblArticuloArchivoId > 0 AndAlso dblPorcentajeAlta >= 0 Then 'Inicio busqueda articulo

                        ' Obtenemos la descripcion del articulo seleccionado
                        Dim objArrayDataArticulo As Array = clstblArticulo.strBuscar(CInt(dblArticuloArchivoId), 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, "", "", "", 0, "", "", "", "", 0, 0, 0, "", 0, 0, "", Now(), 0, 0, strConnectionString)

                        ' Si encontramos informacion
                        If IsArray(objArrayDataArticulo) = True AndAlso objArrayDataArticulo.Length > 0 Then
                            dblArticuloAlta = CDbl(DirectCast(objArrayDataArticulo.GetValue(0), Array).GetValue(0))
                        Else
                            dblArticuloAlta = 0
                        End If

                        If dblArticuloAlta > 0 Then ' Solo se pasa si el articulo existe en el catalogo

                            intContadorCarga += clsPromocionMonedero.intCargaAgregarArticulo(lngFolioCargaId, dblArticuloAlta, dblPorcentajeAlta, strUsuarioNombre, strConnectionString)

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

            Case "BuscarArticulo"

                strHTML = New StringBuilder

                Dim strAccion As String = "0" ' BUSCAR ARTICULO
                Dim strErrorBuscaArticulo As String = ""

                Dim objArrayArticulo As Array = Nothing
                Dim strRegistroArticulo As String()

                Dim intArticuloBuscadoId As Integer = 0
                Dim strArticuloBuscadoDescripcion As String = ""


                ' Obtenemos la información del Articulo

                objArrayArticulo = clsConcentrador.clsSucursal.strBuscarArticulo(0, 0, intArticuloId.ToString, 1, 1, strConnectionString)

                If IsArray(objArrayArticulo) AndAlso (objArrayArticulo.Length > 0) Then
                    strRegistroArticulo = DirectCast(objArrayArticulo.GetValue(0), String())

                    intArticuloBuscadoId = CInt(strRegistroArticulo(0))
                    strArticuloBuscadoDescripcion = clsCommons.strFormatearDescripcion(strRegistroArticulo(5))
                    strErrorBuscaArticulo = "0"
                Else
                    intArticuloBuscadoId = 0
                    strArticuloBuscadoDescripcion = ""
                    strErrorBuscaArticulo = "-100"
                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpBuscarArticulo( " & _
                               strComitasDobles & strErrorBuscaArticulo & strComitasDobles & "," & _
                               strComitasDobles & intArticuloBuscadoId.ToString & strComitasDobles & "," & _
                               strComitasDobles & strArticuloBuscadoDescripcion & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()


            Case "PrevioArchivoArticulo"

                Dim intCargaArchivo As Integer = intCargarArchivoArticulos(lngFolioCargaId)

                strHTML.Append("<script language='Javascript'> parent.fnVerPrevioCarga( " & _
                          strComitasDobles & intCargaArchivo.ToString & strComitasDobles & "," & _
                          strComitasDobles & lngFolioCargaId.ToString & strComitasDobles & _
                          "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "AgregarArticulo"

                Dim intActualizacion As Integer = 0
                Dim intCargaArchivo As Integer = 0

                Dim blnPedirConfirmacion As Boolean = False
                Dim lngFolioCargaEnvioId As Long = 0
                Dim intArticuloEnvioId As Integer = 0

                If intOpcAct = 1 Then ' Captura de Articulo

                    intArticuloEnvioId = intArticuloId

                    intActualizacion = clsPromocionMonedero.intActualizarAgregarArticuloPromocionMonedero(intPromocionId, intArticuloId, dblPorcentaje, blnActualizaPromocion, strUsuarioNombre, strConnectionString)

                    If intActualizacion = -99 Then    'El -99 Indica empalme de promoción por lo que hay que pedir confirmacion para afectar
                        blnPedirConfirmacion = True
                    End If

                End If '-- Final de la actualizacion por captura

                If intOpcAct = 2 Then ' Carga de archivo

                    lngFolioCargaEnvioId = lngFolioCargaId

                    intCargaArchivo = intCargarArchivoArticulos(lngFolioCargaId)

                    If intCargaArchivo >= 0 Then

                        intActualizacion = clsPromocionMonedero.intCargaImportarArticulo(intPromocionId, lngFolioCargaId, blnActualizaPromocion, strUsuarioNombre, strConnectionString)

                        If intActualizacion = -99 Then 'El -99 Indica empalme de promoción por lo que hay que pedir confirmacion para afectar
                            blnPedirConfirmacion = True
                        End If

                    Else

                        intActualizacion = intCargaArchivo ' Error desde la carga del archivo

                    End If

                End If '-- Final de actualizacion por carga

                Dim strPromociones As String = ""

                If blnPedirConfirmacion Then

                    Dim objDataArrayEmpalmes As Array = clsPromocionMonedero.strBuscarEmpalme(lngFolioCargaEnvioId, intArticuloEnvioId, 0, 0, 0, 0, strConnectionString)
                    Dim strDataRowEmpalmes As String()

                    If IsArray(objDataArrayEmpalmes) = True AndAlso objDataArrayEmpalmes.Length > 0 Then

                        For Each strDataRowEmpalmes In objDataArrayEmpalmes

                            strPromociones = strPromociones & "\n " & CStr(strDataRowEmpalmes.GetValue(0)) & " - " & CStr(strDataRowEmpalmes.GetValue(1))

                        Next

                    End If

                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpAgregarArticulo( " & _
                           strComitasDobles & intActualizacion.ToString & strComitasDobles & "," & _
                           strComitasDobles & strPromociones & strComitasDobles & _
                           "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "EliminarArticulo"

                Dim intEliminar As Integer = 0

                intEliminar = clsPromocionMonedero.intEliminarDetallePromocionMonedero(intPromocionEliminarId.ToString, intArticuloEliminarId, 0, 0, strUsuarioNombre, strConnectionString)

                strHTML.Append("<script language='Javascript'> parent.fnUpEliminarArticulo( " & _
                           strComitasDobles & intEliminar.ToString & strComitasDobles & _
                           "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

        End Select


    End Sub

End Class
