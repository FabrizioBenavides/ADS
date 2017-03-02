Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Benavides.POSAdmin.Commons.clsCommons.clsMSMQ
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports Isocraft.Web.Javascript
Imports System.IO
Imports System.Web.Caching

Public Class SucursalConsultarPromocionesMasiva
    Inherits System.Web.UI.Page

    Private intDivisionArticulosId As Integer
    Private strCategoriaOperativaId As Integer
    Private intSubCategoriaArticulosId As Integer
    Private intGrupoArticulosId As Integer

    Dim astrRecords As Array
    Private intDireccionOperativaId As Integer
    Private intZonaOperativaId As Integer
    Private strmArchivo As String = String.Empty
    Dim strmTotalDePartidas As Integer
    Protected WithEvents txtArchivo As System.Web.UI.HtmlControls.HtmlInputFile

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

        'Categoria
        intDivisionArticulosId = GetPageParameter("cboDivisionArticulos", 0)
        strCategoriaOperativaId = GetPageParameter("cboCategoriaArticulos", 0)
        intSubCategoriaArticulosId = GetPageParameter("cboSubCategoriaArticulos", 0)
        intGrupoArticulosId = GetPageParameter("cboGrupoArticulos", 0)

        'Direccion Operativa
        intDireccionOperativaId = GetPageParameter("cboDireccionOperativa", 0)
        intZonaOperativaId = GetPageParameter("cboZonaOperativa", 0)

    End Sub

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
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", String.Empty, Request, Server)
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

#Region "Combos"

    '====================================================================
    ' Name       : LlenarControlDivision
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboDivision
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlDivision() As String
        Dim returnedData As Array
        returnedData = Benavides.CC.Data.clstblDivisionArticulos.strBuscar(0, String.Empty, String.Empty, #1/1/2000#, "", 0, 0, strConnectionString)

        If Not returnedData Is Nothing AndAlso IsArray(returnedData) AndAlso returnedData.Length > 0 Then

            Dim idDivision As String
            Dim divisionDescripcion As String
            Dim i As Integer

            For i = 0 To returnedData.Length - 1

                idDivision = DirectCast(returnedData.GetValue(i), System.Collections.SortedList).Item("strDivisionArticulosNombreId").ToString()
                divisionDescripcion = DirectCast(returnedData.GetValue(i), System.Collections.SortedList).Item("strDivisionArticulosNombre").ToString()

                DirectCast(returnedData.GetValue(i), System.Collections.SortedList).Item("strDivisionArticulosNombre") = idDivision & " " & divisionDescripcion
            Next
        End If

        Return CreateJavascriptComboBoxOptions("cboDivisionArticulos", CStr(intDivisionArticulosId), returnedData, "intDivisionArticulosId", "strDivisionArticulosNombre", 1)
    End Function

    '====================================================================
    ' Name       : LlenarControlCategoria
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboCategori
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlCategoria() As String

        Dim returnedJavascript As String = String.Empty
        Dim returnedData As Array

        If intDivisionArticulosId > 0 Then

            returnedData = Benavides.CC.Data.clstblCategoriaArticulos.strBuscar(intDivisionArticulosId, 0, String.Empty, String.Empty, #1/1/2000#, String.Empty, 0, 0, strConnectionString)

            If Not returnedData Is Nothing AndAlso IsArray(returnedData) AndAlso returnedData.Length > 0 Then


                Dim idCategoria As String
                Dim CategoriaDescripcion As String
                Dim i As Integer

                'Ciclo para agregar el id a la division
                For i = 0 To returnedData.Length - 1

                    idCategoria = DirectCast(returnedData.GetValue(i), System.Collections.SortedList).Item("strCategoriaArticulosNombreId").ToString()
                    CategoriaDescripcion = DirectCast(returnedData.GetValue(i), System.Collections.SortedList).Item("strCategoriaArticulosNombre").ToString()

                    DirectCast(returnedData.GetValue(i), System.Collections.SortedList).Item("strCategoriaArticulosNombre") = idCategoria & " " & CategoriaDescripcion
                Next

                returnedJavascript = CreateJavascriptComboBoxOptions("cboCategoriaArticulos", CStr(strCategoriaOperativaId), returnedData, "intCategoriaArticulosId", "strCategoriaArticulosNombre", 1)
            End If
        End If

        Return returnedJavascript

    End Function

    '====================================================================
    ' Name       : LlenarControlSubCategoriaArticulos
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboSubCategoriaArticulos
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlSubCategoriaArticulos() As String

        Dim returnedJavascript As String = String.Empty

        If intDivisionArticulosId > 0 AndAlso strCategoriaOperativaId > 0 Then

            returnedJavascript = CreateJavascriptComboBoxOptions("cboSubCategoriaArticulos", CStr(intSubCategoriaArticulosId), Benavides.CC.Data.clstblSubCategoriaArticulos.strBuscar(intDivisionArticulosId, strCategoriaOperativaId, 0, String.Empty, String.Empty, #1/1/2000#, String.Empty, 0, 0, strConnectionString), "intSubCategoriaArticulosId", "strSubCategoriaArticulosNombre", 1)

        End If

        Return returnedJavascript

    End Function

    '====================================================================
    ' Name       : LlenarControlGrupoArticulos
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboGrupoArticulos
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlGrupoArticulos() As String

        Dim returnedJavascript As String = String.Empty

        If intDivisionArticulosId > 0 AndAlso strCategoriaOperativaId > 0 AndAlso intSubCategoriaArticulosId > 0 Then

            returnedJavascript = CreateJavascriptComboBoxOptions("cboGrupoArticulos", CStr(intGrupoArticulosId), Benavides.CC.Data.clstblGrupoArticulos.strBuscar(intDivisionArticulosId, strCategoriaOperativaId, intSubCategoriaArticulosId, 0, "", "", #1/1/2000#, "", 0, 0, strConnectionString), "intGrupoArticulosId", "strGrupoArticulosNombre", 1)

        End If

        Return returnedJavascript

    End Function

    '====================================================================
    ' Name       : LlenarControlDireccion
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboDireccionOperativa
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlDireccion() As String

      'Consultamos las direcciones operativas
        astrRecords = Nothing

        astrRecords = Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString)

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccionOperativa", intDireccionOperativaId, astrRecords, 0, 1, 1)

    End Function

    '====================================================================
    ' Name       : LlenarControlZona
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboZona
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlZona() As String

        ' Validamos si hay una Direccion Operativa seleccionada
        If intDireccionOperativaId > 0 Then

            ' Inicializamos el arreglo
            astrRecords = Nothing

            'Consultamos las direcciones operativas
            astrRecords = Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionOperativaId, 0, strConnectionString)

            ' Formamos el string con los valores
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZonaOperativa", intZonaOperativaId, astrRecords, 0, 1, 1)
        End If
    End Function

#End Region


    '====================================================================
    ' Name       : intTipoBusquedaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTipoBusquedaId() As Integer
        Get
            If Not (Request.Form("cmdTipoBusqueda") = Nothing) Then
                Return CInt(Request.Form("cmdTipoBusqueda"))
            Else
                Return -1
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intVigenciaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intVigenciaId() As Integer
        Get
            If Not (Request.Form("cmdVigencia") = Nothing) Then
                Return CInt(Request.Form("cmdVigencia"))
            Else
                Return -1
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intTipoPromocionId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTipoPromocionId() As Integer
        Get
            If Not (Request.Form("cmdTipoPromocion") = Nothing) Then
                Return CInt(Request.Form("cmdTipoPromocion"))
            Else
                Return -1
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intDireccionId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intDireccionId() As Integer
        Get
            Return intDireccionOperativaId
            'Return 0
        End Get
    End Property

    '====================================================================
    ' Name       : intZonaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intZonaId() As Integer
        Get
            Return intZonaOperativaId
            'Return 0
        End Get
    End Property

    '====================================================================
    ' Name       : strFirstDayOfMonth
    ' Description: Regresa el primer dia del mes actual
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFirstDayOfMonth() As String
        Get
            If IsNothing(Request.Form("dtmFechaIni")) Then
                Return New Date(Date.Today.Year, Date.Today.Month, 1).ToString("dd/MM/yyyy")
            Else
                Return Request.Form("dtmFechaIni")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strFechaActual
    ' Description: Regresa la fecha actual
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFechaActual() As String
        Get
            If IsNothing(Request.Form("dtmFechaFin")) Then
                Dim dtmFechaActual As Date

                dtmFechaActual = New Date(Date.Today.Year, Date.Today.Month, Date.Today.Day)

                Return dtmFechaActual.ToString("dd/MM/yyyy")
            Else
                Return Request.Form("dtmFechaFin")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaInicio
    ' Description: Fecha de inicio a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaInicio() As Date
        Get
            Dim f As String = Request.Form("dtmFechaIni")
            If Not IsNothing(f) Then
                Dim fp As String() = f.Split("/".ToCharArray())

                Return New Date(CInt(fp(2)), CInt(fp(1)), CInt(fp(0)))
            Else
                Return CDate("01/01/1900")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaFin
    ' Description: Fecha de fin  a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaFin() As Date
        Get
            Dim f As String = Request.Form("dtmFechaFin")
            If Not IsNothing(f) Then
                Dim fp As String() = f.Split("/".ToCharArray())

                Return New Date(CInt(fp(2)), CInt(fp(1)), CInt(fp(0)))
            Else
                Return CDate("01/01/1900")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmParamFechaInicio
    ' Description: Fecha de inicio a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmParamFechaInicio() As Date
        Get
            If intVigenciaId = 1 Or intVigenciaId = 3 Then

                Dim dtmFechaActual As Date
                dtmFechaActual = New Date(Date.Today.Year, Date.Today.Month, Date.Today.Day)

                Return dtmFechaActual
                
            Else
                Return dtmFechaInicio
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmParamFechaFin
    ' Description: Fecha de fin  a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmParamFechaFin() As Date
        Get
            If intVigenciaId = 2 Then

                Dim dtmFechaActual As Date
                dtmFechaActual = New Date(Date.Today.Year, Date.Today.Month, Date.Today.Day)

                Return dtmFechaActual

            Else
                Return dtmFechaFin
            End If
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
            Return GetPageParameter("strCmd", String.Empty)
        End Get
    End Property

    '====================================================================
    ' Name       : strArchivo
    ' Description: Ruta del archivo ".csv" cargado que contiene las sucursales.
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strArchivo() As String
        Get
            Return strmArchivo
        End Get
        Set(ByVal strValue As String)
            strmArchivo = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTotalDePartidas
    ' Description: Numero de sucursales por "Asignar".
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strTotalDePartidas() As Integer
        Get
            Return strmTotalDePartidas
        End Get
        Set(ByVal strValue As Integer)
            strmTotalDePartidas = strValue
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Dim objArray As System.Array = Nothing
        strmTotalDePartidas = 0

        If (strCmd = "cmdConsultar") Then

            'Arreglo con la informacion de consulta
            objArray = strTipoPromocion()

            If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then

                'Cantidad de registros
                strmTotalDePartidas = objArray.Length

                ' Establecemos en la respuesta los parámetros de configuración del archivo
                Response.ContentType = "application/vnd.ms-excel"
                Call Response.AddHeader("Content-Disposition", "attachment; filename=""Consulta Masiva de Promociones.xls""")
                Call Response.Write(strGenerarTablaHTMLPromocionesExportar(objArray))
                Call Response.End()
            Else
                'Tabla vacia sin resultados de consulta
                Call Response.Write("<script language='Javascript'>alert('Consulta sin resultados');</script>")
            End If
        End If
    End Sub

    Private Function strTipoPromocion() As Array

        Dim objArray As System.Array = Nothing


        If intTipoBusquedaId = 1 Then

            '------------
            'Por Archivo
            '------------
            objArray = fnCargaArchivoPorArticulo()

        ElseIf intTipoBusquedaId = 2 Then

            '--------------
            'Por Categoria
            '--------------
            objArray = fnCargaMasivaPorCategoria()

        ElseIf intTipoBusquedaId = 3 Then

            '---------------------
            'Por Region Operativa
            '---------------------
            objArray = fnCargaMasivaPorRegion()
        End If

        Return objArray

    End Function

    Private Function fnCargaArchivoPorArticulo() As Array
        Dim objArray As System.Array = Nothing

        Try
            'Importar archivo CSV
            'Dim MiTabla As DataTable = New DataTable
            Dim separador As Char = ","c

            'Datos del archivo
            Dim _archivo As System.Web.HttpPostedFile
            Dim strNombreArchivo As String
            Dim strRutaFisica As String = String.Empty
            Dim strRutaRelativaArchivo As String
            Dim strExtensionArchivo As String

            _archivo = txtArchivo.PostedFile

            If _archivo Is Nothing Then
                Return Nothing
            End If

            strNombreArchivo = Path.GetFileName(_archivo.FileName)

            'Inicio de Validaciones del archivo
            If strNombreArchivo.Length = 0 Then
                If txtArchivo.Value.Trim() = String.Empty AndAlso Not Trim(Request.Form("hdnArchivo").ToString()) = String.Empty Then
                    strNombreArchivo = Request.Form("hdnArchivo").ToString()
                Else
                    Return Nothing
                End If
            End If

            If Not Trim(strNombreArchivo) = String.Empty Then

                strExtensionArchivo = Path.GetExtension(strNombreArchivo).ToUpper()

                If strExtensionArchivo = ".CSV" Then

                    strRutaRelativaArchivo = Response.ApplyAppPathModifier(ConfigurationSettings.AppSettings("strArchivoCupones") & strNombreArchivo)

                    If System.IO.File.Exists(strRutaRelativaArchivo) = True Then

                        File.Delete(strRutaRelativaArchivo)

                    End If

                    txtArchivo.PostedFile.SaveAs(strRutaRelativaArchivo)

                    'Se guarda el nombre del archivo para la paginacion
                    strmArchivo = strNombreArchivo

                    objArray = ConstruirDatatable(strRutaRelativaArchivo, separador)
                    txtArchivo.PostedFile.InputStream.Close()
                Else
                    Call Response.Write("<script language='Javascript'>alert('El formato del archivo es incorrecto, favor de cargar un archivo "".csv""');</script>")
                    Return Nothing
                End If
            End If

            Return objArray

        Catch ex As Exception
            Call Response.Write("<script language='Javascript'>alert('Ocurrio un error al cargar un archivo "".csv""');</script>")
        End Try
    End Function

    Private Function fnCargaMasivaPorCategoria() As Array

        Dim objArrayPorCategoria As System.Array = Nothing

        If (intTipoPromocionId = 0) Then

            '--------------------
            'Todos Por Categoria
            '--------------------
            objArrayPorCategoria = Benavides.CC.Data.clsConsultarPromociones.strConsultaMasivaTodosPorCategoria(intDivisionArticulosId, strCategoriaOperativaId, intSubCategoriaArticulosId, intGrupoArticulosId, intVigenciaId, dtmParamFechaInicio, dtmParamFechaFin, strUsuarioNombre, strConnectionString)

        ElseIf (intTipoPromocionId = 1) Then

            '------------------------
            'Ofertas Por Categoria
            '------------------------
            objArrayPorCategoria = Benavides.CC.Data.clsConsultarPromociones.strConsultaMasivaOfertasPorCategoria(intDivisionArticulosId, strCategoriaOperativaId, intSubCategoriaArticulosId, intGrupoArticulosId, intVigenciaId, dtmParamFechaInicio, dtmParamFechaFin, strUsuarioNombre, strConnectionString)

        ElseIf (intTipoPromocionId = 2) Then

            '--------------------------
            'Promociones Por Categoria
            '--------------------------
            objArrayPorCategoria = Benavides.CC.Data.clsConsultarPromociones.strConsultaMasivaPromocionesPorCategoria(intDivisionArticulosId, strCategoriaOperativaId, intSubCategoriaArticulosId, intGrupoArticulosId, intVigenciaId, dtmParamFechaInicio, dtmParamFechaFin, strUsuarioNombre, strConnectionString)

        ElseIf (intTipoPromocionId = 3) Then

            '------------------------
            'Cupones Por Categoria
            '------------------------

            'Ver si sirve utilizar los mismos SP's de promociones ya que solo cambia un campo = 0 o =1
            objArrayPorCategoria = Benavides.CC.Data.clsConsultarPromociones.strConsultaMasivaCuponesPorCategoria(intDivisionArticulosId, strCategoriaOperativaId, intSubCategoriaArticulosId, intGrupoArticulosId, intVigenciaId, dtmParamFechaInicio, dtmParamFechaFin, strUsuarioNombre, strConnectionString)

        Else
            'Sin seleccion
        End If

        Return objArrayPorCategoria

    End Function

    Private Function fnCargaMasivaPorRegion() As Array

        Dim objArrayPorRegion As System.Array = Nothing

        If (intTipoPromocionId = 0) Then

            '--------------------------
            'Todos Por Region Operativa
            '--------------------------
            objArrayPorRegion = Benavides.CC.Data.clsConsultarPromociones.strConsultaMasivaTodosPorRegion(intDireccionId, intZonaOperativaId, intVigenciaId, dtmParamFechaInicio, dtmParamFechaFin, strUsuarioNombre, strConnectionString)

        ElseIf (intTipoPromocionId = 1) Then

            '----------------------------
            'Ofertas Por Region Operativa
            '----------------------------
            objArrayPorRegion = Benavides.CC.Data.clsConsultarPromociones.strConsultaMasivaOfertasPorRegion(intDireccionId, intZonaOperativaId, intVigenciaId, dtmParamFechaInicio, dtmParamFechaFin, strUsuarioNombre, strConnectionString)

        ElseIf (intTipoPromocionId = 2) Then

            '---------------------------------
            'Promociones Por Region Operativa
            '---------------------------------
            objArrayPorRegion = Benavides.CC.Data.clsConsultarPromociones.strConsultaMasivaPromocionesPorRegion(intDireccionId, intZonaOperativaId, intVigenciaId, dtmParamFechaInicio, dtmParamFechaFin, strUsuarioNombre, strConnectionString)

        ElseIf (intTipoPromocionId = 3) Then

            '-----------------------------
            'Cupones Por Region Operativa
            '-----------------------------
            objArrayPorRegion = Benavides.CC.Data.clsConsultarPromociones.strConsultaMasivaCuponesPorRegion(intDireccionId, intZonaOperativaId, intVigenciaId, dtmParamFechaInicio, dtmParamFechaFin, strUsuarioNombre, strConnectionString)

        Else
            'Sin seleccion
        End If

        Return objArrayPorRegion
    End Function

    Private Function ConstruirDatatable(ByVal RutaCompletaArchivo As String, ByVal Separador As Char) As Array

        'Declaramos las variables 
        Dim fieldValues As String()
        Dim miReader As System.IO.StreamReader
        Dim strSucursal As Array = Nothing
        Dim mensaje As String = String.Empty
        Dim intContador As Integer
        Dim strFormActionParameters As String = Nothing

        Try
            'Abrimos el fichero y leemos la primera linea con el fin de determinar cuantos campos tenemos
            miReader = File.OpenText(RutaCompletaArchivo)
            fieldValues = miReader.ReadLine().Split(Separador)

            'Leemos las primers columnas 
            If fieldValues.Length() > 0 AndAlso Not fieldValues(0).ToString() Is Nothing AndAlso Not Trim(fieldValues(0).ToString()) = String.Empty Then
                strFormActionParameters = fieldValues(0).ToString()
            End If

            'Continuamos leyendo el resto de filas y añadiendolas a la tabla
            While miReader.Peek() <> -1
                fieldValues = miReader.ReadLine().Split(Separador)

                If Not fieldValues(0).ToString() Is Nothing AndAlso Not Trim(fieldValues(0).ToString()) = String.Empty AndAlso IsNumeric(fieldValues(0)) = True Then

                    'si NO es la primer promocion a imprimir se agrega el separador "," (coma)                          
                    If Not (strFormActionParameters = Nothing) Then
                        strFormActionParameters = strFormActionParameters & ","
                    End If

                    strFormActionParameters = strFormActionParameters & fieldValues(0).ToString()

                End If
            End While

            'Cerramos el reader
            miReader.Close()
            miReader = Nothing

            If strFormActionParameters.Length > 0 Then

                If intTipoPromocionId = 0 Then
                    'Todos
                    strSucursal = Benavides.CC.Data.clsConsultarPromociones.strConsultarMasivaTodosPorArchivo(strFormActionParameters, intVigenciaId, dtmParamFechaInicio, dtmParamFechaFin, strUsuarioNombre, strConnectionString)
                ElseIf intTipoPromocionId = 1 Then
                    'Ofertas
                    strSucursal = Benavides.CC.Data.clsConsultarPromociones.strConsultarMasivaOfertasPorArchivo(strFormActionParameters, intVigenciaId, dtmParamFechaInicio, dtmParamFechaFin, strUsuarioNombre, strConnectionString)

                ElseIf intTipoPromocionId = 2 Then
                    'Promociones
                    strSucursal = Benavides.CC.Data.clsConsultarPromociones.strConsultarMasivaPromocionesPorArchivo(strFormActionParameters, intVigenciaId, dtmParamFechaInicio, dtmParamFechaFin, strUsuarioNombre, strConnectionString)
                ElseIf intTipoPromocionId = 3 Then
                    'Cupones
                    strSucursal = Benavides.CC.Data.clsConsultarPromociones.strConsultarMasivaCuponesPorArchivo(strFormActionParameters, intVigenciaId, dtmParamFechaInicio, dtmParamFechaFin, strUsuarioNombre, strConnectionString)
                End If
            End If
        Catch ex As Exception
            'Gestionamos las excepciones, Aqui cada uno puede hacer lo que crea conveniente: Mostrar un error en Javascript en este caso y devolver el Datatable vacío

            mensaje = "alert ('Ha ocurrido el siguiente error al importar el archivo: " + ex.ToString + "');"
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ErrorConstruirDatabale", mensaje, True)
            'Return New DataTable("Empty")
        Finally
            'Si queremos ejecutar algo exista excepción o no
        End Try

        'Devolvemos el DataTable si todo ha ido bien
        If Not mensaje = String.Empty Then
            Return Nothing
        End If

        Return strSucursal
    End Function

    Public Function strGenerarTablaHTMLPromocionesExportar(ByVal objConsultaPromociones As Array) As String

        Dim strTablaPromocionesHTML As StringBuilder
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim strConsultaRegistroPromociones As String()

        strTablaPromocionesHTML = New StringBuilder
        strTablaPromocionesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Encabezados de Tabla de Resultados
        strTablaPromocionesHTML.Append("<tr class='trtitulos'>")
        strTablaPromocionesHTML.Append("<th width='8%' align=center class='rayita' valign='top'>No. Promo</th>")
        strTablaPromocionesHTML.Append("<th width='10%' align=center class='rayita'  valign='top'>SKU</th>")
        strTablaPromocionesHTML.Append("<th width='20%' align=center class='rayita' valign='top'>Descripción</th>")
        strTablaPromocionesHTML.Append("<th width='16%' align=center class='rayita' valign='top'>Tipo Promo</th>")
        strTablaPromocionesHTML.Append("<th width='10%' align=center class='rayita' valign='top'>Tipo Estrategia</th>")
        strTablaPromocionesHTML.Append("<th width='15%' align=center class='rayita' valign='top'>Vigencia Inicio</th>")
        strTablaPromocionesHTML.Append("<th width='15%' align=center class='rayita' valign='top'>Vigencia Fin</th>")
        strTablaPromocionesHTML.Append("<th width='8%' align=center class='rayita' valign='top'>No. Campaña</th>")
        strTablaPromocionesHTML.Append("<th width='15%' align=center class='rayita' valign='top'>Campaña</th>")
        strTablaPromocionesHTML.Append("<th width='15%' align=center class='rayita' valign='top'>Total de Sucursales</th>")
        strTablaPromocionesHTML.Append("<th width='8%' align=center class='rayita' valign='top'>Usuario</th>")

        strTablaPromocionesHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For Each strConsultaRegistroPromociones In objConsultaPromociones
            intContador += 1


            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strTablaPromocionesHTML.Append("<tr>")
            'No. Promocion               
            strTablaPromocionesHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaRegistroPromociones(0).ToString() & "</td>")
            'SKU               
            strTablaPromocionesHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaRegistroPromociones(1).ToString() & "</td>")
            'Descripción
            strTablaPromocionesHTML.Append("<td id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroPromociones(2)) & "</td>")
            'Tipo Promo
            strTablaPromocionesHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroPromociones(3)) & "</td>")
            'Tipo Estrategia
            strTablaPromocionesHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroPromociones(4)) & "</td>")
            'Vigencia Inicio
            strTablaPromocionesHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaRegistroPromociones(5)) & "</td>")
            'Vigencia Fin
            strTablaPromocionesHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaRegistroPromociones(6)) & "</td>")
            'Id Campaña
            strTablaPromocionesHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroPromociones(7)) & "</td>")
            'Campaña Descripcion
            strTablaPromocionesHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroPromociones(8)) & "</td>")
            'Total de Sucursales
            strTablaPromocionesHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaRegistroPromociones(9) & "</td>")
            'Usuario
            strTablaPromocionesHTML.Append("<td class=" & strColorRegistro & ">" & strConsultaRegistroPromociones(10) & "</td>")
            strTablaPromocionesHTML.Append("</tr>")
        Next

        strTablaPromocionesHTML.Append("</tr>")
        strTablaPromocionesHTML.Append("</table>")
        strGenerarTablaHTMLPromocionesExportar = strTablaPromocionesHTML.ToString

    End Function


End Class