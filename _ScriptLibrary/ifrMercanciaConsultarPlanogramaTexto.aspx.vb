Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class ifrMercanciaConsultarPlanogramaTexto
    Inherits System.Web.UI.Page

    
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    '====================================================================
    ' Name       : strFormAction
    ' Description: Valor de la acción de la forma HTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormAction() As String
        Get
            Return Request.ServerVariables("SCRIPT_NAME")
        End Get
    End Property

    '====================================================================
    ' Name       : intCompaniaId
    ' Description: Valor de la Compañia 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCompaniaId() As Integer
        Get
            Return CInt(clsCommons.strReadCookie("intCompaniaId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Valor de la Sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intSucursalId() As Integer
        Get
            Return CInt(clsCommons.strReadCookie("intSucursalId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strSucursalNombre
    ' Description: Nombre de la Sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalNombre() As String
        Get
            Return clsCommons.strReadCookie("strSucursalNombre", "0", Request, Server)
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
            Return CInt(clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del Usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return clsCommons.strReadCookie("strUsuarioNombre", "0", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: URL de esta página
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return clsCommons.strGetPageName(Request)
        End Get
    End Property

    '====================================================================
    ' Name       : strCadenaConexion
    ' Description: Valor que tomara la variable strmCadenaConexion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCadenaConexion() As String
        Get
            Return ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : intPlanoId
    ' Description: Identificador del planograma
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intPlanoId() As Integer
        Get
            If Request.QueryString("intPlanoId") <> "" Then
                Return CType(Request.QueryString("intPlanoId"), Integer)
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strEncabezadoPlanogramaHTML
    ' Description: Valor que tomara la información del planograma
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strEncabezadoPlanogramaHTML() As String
        Get
            Dim objPlanograma As Array = Nothing
            Dim strPlanograma As String() = Nothing
            Dim strbldEncabezadoPlanogramaHTML As StringBuilder

            strbldEncabezadoPlanogramaHTML = New StringBuilder

            objPlanograma = clstblPlano.strBuscar(CInt(intPlanoId), 0, "", CDate(Now), 0, CByte(0), CDate(Now), strUsuarioNombre, 0, 0, strCadenaConexion)

            ' Validamos si trae información para mostrarla
            If IsArray(objPlanograma) AndAlso objPlanograma.Length > 0 Then
                strPlanograma = DirectCast(objPlanograma.GetValue(0), String())

                ' Genero la información del encabezado
                strbldEncabezadoPlanogramaHTML.Append("<table width=""780"" border=""0"" cellpadding=""0"" cellspacing=""0"">")
                strbldEncabezadoPlanogramaHTML.Append("<tr><td width=""10"">&nbsp;</td>")
                strbldEncabezadoPlanogramaHTML.Append("<td width=""583"" valign=""top"">")
                strbldEncabezadoPlanogramaHTML.Append("<table width=""583"" border=""0"" cellpadding=""0"" cellspacing=""0""><tr>")
                strbldEncabezadoPlanogramaHTML.Append("<td width=""100%"" colspan=""3"" valign=""top"" class=""tdtablacont""><span class=""txtitulo"">Planograma texto</span>")
                strbldEncabezadoPlanogramaHTML.Append("<span class=""txcontenido"">Los siguientes son los productos asociados al planograma indicado.</span>")
                strbldEncabezadoPlanogramaHTML.Append("<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0""><tr>")
                strbldEncabezadoPlanogramaHTML.Append("<td width=""135"" class=""tdtittablas"">No.  planograma:</td>")
                strbldEncabezadoPlanogramaHTML.Append("<td width=""433"" height=""40"" valign=""middle"" class=""tdconttablas"">" & strPlanograma(0) & "</td></tr>")
                strbldEncabezadoPlanogramaHTML.Append("<tr><td class=""tdtittablas"">Descripci&oacute;n:</td>")
                strbldEncabezadoPlanogramaHTML.Append("<td height=""40"" valign=""middle"" class=""tdconttablas"">" & strPlanograma(2) & "</td></tr></table>")
                strbldEncabezadoPlanogramaHTML.Append("</td><tr></table></td></tr></table>")

            End If

            Return clsCommons.strGenerateJavascriptString(strbldEncabezadoPlanogramaHTML.ToString)
        End Get
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Valor que tomara la variable strmRecordBrowserHTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRecordBrowserHTML() As String
        Get
            Dim objArticuloPlanograma As Array = Nothing
            Dim strArticuloPlanograma As String() = Nothing
            Dim strbldRecordBrowser As StringBuilder

            ' Creamos el StringBuilder.
            strbldRecordBrowser = New StringBuilder

            'Hacemos la consulta de los artículos del planograma
            'Anterior objArticuloPlanograma = clstblArticuloPlano.strBuscar(CInt(intPlanoId), 0, "", 0, 0, 0, 0, 0, CDate(Now), "", "", "", CDate(Now), strUsuarioNombre, 0, 0, strCadenaConexion)

            objArticuloPlanograma = clsConcentrador.clsPlanograma.strBuscarDetalle(intCompaniaId, intSucursalId, CInt(intPlanoId), 0, 0, 0, strCadenaConexion)

            ' Validamos si trae información para mostrarla
            If IsArray(objArticuloPlanograma) AndAlso objArticuloPlanograma.Length > 0 Then

                'Construimos el encabezado
                strbldRecordBrowser.Append("<table width=""97%"" border=""0"" cellpadding=""0"" cellspacing=""0""><tr class=""trtitulos"">")
                strbldRecordBrowser.Append("<th width=""62"" height=""16"" class=""rayita""> <p>Clave</p></th>")
                strbldRecordBrowser.Append("<th width=""259"" class=""rayita"">Descripci&oacute;n</th>")
                strbldRecordBrowser.Append("<th width=""49"" class=""rayita"">Charola</th>")
                strbldRecordBrowser.Append("<th width=""51"" class=""rayita"">Secci&oacute;n</th>")
                strbldRecordBrowser.Append("<th width=""46"" class=""rayita"">Subsecci&oacute;n</th>")
                strbldRecordBrowser.Append("<th width=""48"" class=""rayita"">Frentes</th>")
                strbldRecordBrowser.Append("<th width=""36"" class=""rayita"">Stock Maximo</th>")

                ' Contruimos la tabla de información
                For Each strArticuloPlanograma In objArticuloPlanograma
                    strbldRecordBrowser.Append("<tr><td width=""97"" class=""tdceleste"">" + strArticuloPlanograma(1) + "</td>")
                    strbldRecordBrowser.Append("<td width=""461"" class=""tdceleste"">" + strArticuloPlanograma(2) + "</td>")
                    strbldRecordBrowser.Append("<td width=""94"" class=""tdceleste"">" + strArticuloPlanograma(3) + "</td>")
                    strbldRecordBrowser.Append("<td width=""87"" class=""tdceleste"">" + strArticuloPlanograma(4) + "</td>")
                    strbldRecordBrowser.Append("<td width=""81"" class=""tdceleste"">" + strArticuloPlanograma(5) + "</td>")
                    strbldRecordBrowser.Append("<td width=""79"" class=""tdceleste"">" + strArticuloPlanograma(6) + "</td>")
                    strbldRecordBrowser.Append("<td width=""64"" class=""tdceleste"">" + strArticuloPlanograma(7) + "</td></tr>")
                Next

                ' Cerramos la tabla
                strbldRecordBrowser.Append("</tr></table>")

            End If

            Return clsCommons.strGenerateJavascriptString((strbldRecordBrowser.ToString))
        End Get
    End Property

    '====================================================================
    ' Name       : Page_Load
    ' Description: Evento "Load" de la página
    ' Parameters :
    '              ByVal objSender As System.Object
    '                 - Objeto que genera el Evento
    '              ByVal objEvent As System.EventArgs
    '                 - Argumentos del Evento
    ' Throws     : Ninguna
    ' Output     : Ninguna
    '====================================================================
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

End Class
