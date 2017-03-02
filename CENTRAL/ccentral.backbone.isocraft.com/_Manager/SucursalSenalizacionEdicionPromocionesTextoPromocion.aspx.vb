Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
'Imports Benavides.POSAdmin.Data
Imports Benavides.POSAdmin.Commons.clsCommons.clsMSMQ
Imports Benavides.CC.Data.clsPromociones
Imports System.Text
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports System.IO
Imports System.Configuration
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class SucursalSenalizacionEdicionPromocionesTextoPromocion
    Inherits System.Web.UI.Page

    Private strmPromocion As String = String.Empty
    Private strmFormato As String = String.Empty
    Private strmRutaImagen As String = String.Empty
    Private strmImagen As String = String.Empty


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtArchivo As System.Web.UI.HtmlControls.HtmlInputFile

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
    ' Name       : strPromocion
    ' Description: Descripcion de la promocion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strPromocion() As String
        Get
            Return strmPromocion
        End Get
        Set(ByVal Value As String)
            strmPromocion = Value

        End Set
    End Property

    '====================================================================
    ' Name       : strFormato
    ' Description: Formato de la promocion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormato() As String
        Get
            Dim strFormatoId As String = String.Empty

            If Not IsNothing(Request.QueryString("idFormato")) Then
                strFormatoId = Request.QueryString("idFormato")
            Else
                strFormatoId = idFormato
            End If

            'Descripcion del formato
            If strFormatoId = "1" Then
                Return "1x1"
            ElseIf strFormatoId = "2" Then
                Return "1x3"
            ElseIf strFormatoId = "3" Then
                Return "1x4"
            ElseIf strFormatoId = "4" Then
                Return "1x6"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : idFormato
    ' Description: Id del Formato de la promocion.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property idFormato() As String
        Get
            If Not IsNothing(Request.QueryString("idFormato")) Then
                Return Request.QueryString("idFormato")
            Else
                Return Request.Form("idFormato")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strRutaImagen
    ' Description: Ruta de la imagen
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRutaImagen() As String
        Get
            Return strmRutaImagen
        End Get
        Set(ByVal Value As String)
            strmRutaImagen = Value

        End Set
    End Property

    '====================================================================
    ' Name       : strRutaImagen
    ' Description: Ruta de la imagen
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strImagen() As String
        Get
            Return strmImagen
        End Get
        Set(ByVal Value As String)
            strmImagen = Value

        End Set
    End Property

    '====================================================================
    ' Name       : intPromocionCodigo
    ' Description: Numero identificador de la promocion a mostrar.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intPromocionCodigo() As Integer
        Get
            If Not IsNothing(Request.QueryString("intPromocionCodigo")) And IsNumeric(Request.QueryString("intPromocionCodigo")) Then
                Return CInt(Request.QueryString("intPromocionCodigo"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intCodigo
    ' Description: Codigo de la promocion a editar
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCodigo() As Integer
        Get
            If Not IsNothing(Trim(Request.Form("hdCodigo"))) Then 'And IsNumeric(Request.QueryString("hdCodigo")) Then
                Return CInt(Request.Form("hdCodigo"))
            Else
                Return 0
            End If
        End Get
    End Property


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim codigo As Integer

        'Guardar
        If (Len(Request.Form("cmdGuardar"))) > 0 And intCodigo > 0 Then

            Dim intResultado As Integer
            Dim _archivo As System.Web.HttpPostedFile
            _archivo = txtArchivo.PostedFile

            'Nombre de archivo
            Dim strNombreArchivo As String
            Dim strArchivoPromocion As String
            Dim strRutaRelativa As String = String.Empty
            Dim strRutaFisica As String = String.Empty

            strNombreArchivo = _archivo.FileName 'intCodigo & txtArchivo.PostedFile.FileName
            If strNombreArchivo.Length = 0 Then
                If Trim(Request.Form("txtNombreArchivo")) = String.Empty Then
                    strArchivoPromocion = String.Empty
                Else
                    strArchivoPromocion = Request.Form("txtNombreArchivo").Trim()
                End If
            Else
                Dim strExtensionArchivo As String = Path.GetExtension(strNombreArchivo).ToUpper()

                If strExtensionArchivo = ".PNG" Or strExtensionArchivo = ".JPG" Or strExtensionArchivo = ".GIF" Then
                    strArchivoPromocion = String.Format("{0}{1}{2}{3}", intCodigo, "_", strFormato, Path.GetExtension(strNombreArchivo))
                End If
            End If

            intResultado = Benavides.CC.Data.clsPromociones.intEditarDetallePromocion(intCodigo, Request.Form("txtDescripcion"), CInt(idFormato), strArchivoPromocion, strUsuarioNombre, strConnectionString)

            codigo = intCodigo

            'Se redirecciona al usuario a la pantalla de la consulta.
            If intResultado > 0 Then
                If strNombreArchivo.Length > 0 Then
                    Dim result(CInt(_archivo.InputStream.Length)) As Byte
                    _archivo.InputStream.Read(result, 0, CInt(_archivo.InputStream.Length))

                    'Se envia a la pantalla de Imagen con sus parametros para la imagen.
                    Dim client As New System.Net.WebClient()
                    Dim values As New System.Collections.Specialized.NameValueCollection
                    values.Add("id", strArchivoPromocion)
                    values.Add("IdFormato", idFormato)
                    values.Add("content", System.Convert.ToBase64String(result))

                    client.Headers("Content-Type") = "application/x-www-form-urlencoded"
                    client.UploadValues(ConfigurationSettings.AppSettings("strImagenesPromociones"), values)
                End If

                'Mensaje al usuario
                Response.Write("<script language=""JavaScript"" type=""text/javascript"">opener.doSubmit(); alert('Se guardaron los cambios en la promocion'); window.close();</script>")
            End If
        End If


        ' Declaracion de Variables
        Dim objArrayCenefa As Array
        Dim strRegistroPromocion As String()
        Dim intConsecutivo As Integer

        objArrayCenefa = Nothing

        If intPromocionCodigo > 0 Then
            codigo = intPromocionCodigo
        End If

        If intCodigo > 0 Then
            codigo = intCodigo
        End If

        If codigo > 0 Then

            'Obtiene los datos de la promocion a mostrar.
            objArrayCenefa = Benavides.CC.Data.clsPromociones.strBuscarDetallePromocionSenalizacion(codigo, CInt(idFormato), strConnectionString)

            If IsArray(objArrayCenefa) AndAlso objArrayCenefa.Length > 0 Then

                intConsecutivo += 1

                Dim rutaImagenes As String = System.Configuration.ConfigurationSettings.AppSettings("strImagenesPromociones")

                'Datos de la promocion a mostrar.
                For Each strRegistroPromocion In objArrayCenefa
                    strmPromocion = Trim(CStr(strRegistroPromocion(1)))
                    strmFormato = Trim(CStr(strRegistroPromocion(4)))
                    strmImagen = strRegistroPromocion(5)
                    If Trim(strRegistroPromocion(5)) <> String.Empty Then
                        strRutaImagen = String.Format("{0}?id={1}&idFormato={2}", rutaImagenes, strRegistroPromocion(0), idFormato)
                    End If
                Next
            End If
        End If

    End Sub

End Class
