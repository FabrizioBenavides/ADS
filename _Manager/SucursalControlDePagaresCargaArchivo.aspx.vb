
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

Public Class SucursalControlDePagaresCargaArchivo
    Inherits System.Web.UI.Page

    Dim astrRecords As Array
    Private strmArchivo As String = String.Empty
    Private intSucursalGuardada As Integer = 0
    Private intSucursalRechazada As Integer = 0
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If


        If (strCmd = "cmdCargar") Then

            'Rutina para cargar la informacion del archivo
            fnCargaArchivoSucursalPagare()

        End If
    End Sub

    Private Sub fnCargaArchivoSucursalPagare()
        Try
            'Importar archivo CSV
            'Dim MiTabla As DataTable = New DataTable()
            Dim separador As Char = ","c

            'Datos del archivo
            Dim _archivo As System.Web.HttpPostedFile
            Dim strNombreArchivo As String
            Dim strRutaFisica As String = String.Empty
            Dim strRutaRelativaArchivo As String
            Dim strExtensionArchivo As String

            _archivo = txtArchivo.PostedFile

            If _archivo Is Nothing Then
                Return
            End If

            strNombreArchivo = Path.GetFileName(_archivo.FileName)

            'Inicio de Validaciones del archivo
            If strNombreArchivo.Length = 0 Then
                If txtArchivo.Value.Trim() = String.Empty AndAlso Not Trim(Request.Form("hdnArchivo").ToString()) = String.Empty Then
                    strNombreArchivo = Request.Form("hdnArchivo").ToString()
                Else
                    Return
                End If
            End If

            If Not Trim(strNombreArchivo) = String.Empty Then

                strExtensionArchivo = Path.GetExtension(strNombreArchivo).ToUpper()

                If strExtensionArchivo = ".CSV" Then

                    strRutaRelativaArchivo = Response.ApplyAppPathModifier(ConfigurationSettings.AppSettings("strArchivoPagares") & strNombreArchivo)

                    If System.IO.File.Exists(strRutaRelativaArchivo) = True Then

                        File.Delete(strRutaRelativaArchivo)

                    End If

                    txtArchivo.PostedFile.SaveAs(strRutaRelativaArchivo)

                    'Se guarda el nombre del archivo para la paginacion
                    strmArchivo = strNombreArchivo

                    ConstruirDatatable(strRutaRelativaArchivo, separador)
                    txtArchivo.PostedFile.InputStream.Close()

                    Call Response.Write("<script language='Javascript'>alert('Se guardaron " & intSucursalGuardada & " sucursales, " & intSucursalRechazada & " no se pudieron guardar.');</script>")
                Else
                    Call Response.Write("<script language='Javascript'>alert('El formato del archivo es incorrecto, favor de cargar un archivo "".csv""');</script>")
                End If
            End If

            Return

        Catch ex As Exception

            txtArchivo.PostedFile.InputStream.Close()
            Call Response.Write("<script language='Javascript'>alert('Ocurrio un error al cargar un archivo "".csv""');</script>")

        End Try
    End Sub

    Private Sub ConstruirDatatable(ByVal RutaCompletaArchivo As String, ByVal Separador As Char)

        'Declaramos las variables 
        Dim fieldValues As String()
        Dim miReader As System.IO.StreamReader
        Dim mensaje As String = String.Empty
        Dim intContador As Integer

        Dim strAfiliacionId As String
        Dim strCompaniaId As String
        Dim strSucursalId As String
        Dim strCentroLogisticoId As String

        Try
            'Abrimos el fichero y leemos la primera linea con el fin de determinar cuantos campos tenemos
            miReader = File.OpenText(RutaCompletaArchivo)
            fieldValues = miReader.ReadLine().Split(Separador)

            'Leemos las primeras columnas 
            If (fieldValues.Length() > 0) AndAlso Not (fieldValues(0).ToString() Is Nothing) AndAlso Not (Trim(fieldValues(0).ToString()) = String.Empty) Then

                strAfiliacionId = fieldValues(0).ToString()
                strCompaniaId = fieldValues(1).ToString()
                strSucursalId = fieldValues(2).ToString()
                strCentroLogisticoId = fieldValues(3).ToString()

                'Funcion que valida y ejecuta el SP que guarda la info
                fnGuardarSucursalPagare(strAfiliacionId, strCompaniaId, strSucursalId, strCentroLogisticoId)

                'strFormActionParameters = fieldValues(0).ToString()
            End If

            'Continuamos leyendo el resto de filas y añadiendolas a la tabla
            While miReader.Peek() <> -1
                fieldValues = miReader.ReadLine().Split(Separador)

                If Not fieldValues(0).ToString() Is Nothing AndAlso Not Trim(fieldValues(0).ToString()) = String.Empty AndAlso IsNumeric(fieldValues(0)) = True Then

                    strAfiliacionId = fieldValues(0).ToString()
                    strCompaniaId = fieldValues(1).ToString()
                    strSucursalId = fieldValues(2).ToString()
                    strCentroLogisticoId = fieldValues(3).ToString()

                    'Funcion que valida y ejecuta el SP que guarda la info
                    fnGuardarSucursalPagare(strAfiliacionId, strCompaniaId, strSucursalId, strCentroLogisticoId)

                End If
            End While

            'Cerramos el reader
            miReader.Close()
            miReader = Nothing


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
            Return
        End If

    End Sub

    Private Sub fnGuardarSucursalPagare(ByRef strAfiliacionId As String, ByRef strCompaniaId As String, ByRef strSucursalId As String, ByRef strCentroLogisticoId As String)

        'Variables
        Dim intResultado As Integer = 0

        'Valida que sean datos validos. 
        If (strAfiliacionId.Trim() <> String.Empty) AndAlso (IsNumeric(strAfiliacionId)) AndAlso _
           (strCompaniaId.Trim() <> String.Empty) AndAlso (IsNumeric(strCompaniaId)) AndAlso _
           (strSucursalId.Trim() <> String.Empty) AndAlso (IsNumeric(strSucursalId)) AndAlso _
           (strCentroLogisticoId.Trim() <> String.Empty) Then

            'Guarda la informacion de la Sucursal.
            intResultado = Benavides.CC.Data.clsControlPagares.intSucursalPagareCargaMasiva(CInt(strAfiliacionId), CInt(strCompaniaId), CInt(strSucursalId), strCentroLogisticoId, strUsuarioNombre, strConnectionString)

        End If

        'Variables sin valor
        strAfiliacionId = String.Empty
        strCompaniaId = String.Empty
        strSucursalId = String.Empty
        strCentroLogisticoId = String.Empty

        '..........................................................
        'Conteo de Sucursales rechazadas y guardadas
        '..........................................................

        If intResultado > 0 Then
            intSucursalGuardada = intSucursalGuardada + 1
        Else
            intSucursalRechazada = intSucursalRechazada + 1
        End If

    End Sub

End Class