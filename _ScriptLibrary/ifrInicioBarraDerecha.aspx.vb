Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class clsifrInicioBarraDerecha
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
    ' Name       : strRedirectPage
    ' Description: Página hacia la cual se debe redireccionar al usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRedirectPage() As String
        Get
            ' Return "/Default.aspx?strURL=" & Server.UrlEncode(Request.ServerVariables("SCRIPT_NAME"))
            If intCompaniaId > 0 Then
                Return "/Default.aspx?strURL=/_ScriptLibrary/POSAdminRedirectorCC.aspx?strPageName=" & strThisPageName
            Else
                Return "/Default.aspx?strURL=" & Server.UrlEncode(Request.ServerVariables("SCRIPT_NAME"))
            End If
        End Get
    End Property

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
    ' Name       : intFolio
    ' Description: Valor del folio.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property dtmFecha() As String
        Get
            Return Request.QueryString("dtmFecha")
        End Get
    End Property

    '====================================================================
    ' Name       : strPlanogramaHTML
    ' Description: Valor que tomara la variable strmPlanogramaHTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strPlanogramaHTML() As String
        Get
            Dim objPlanogramas As Array = Nothing
            Dim strbldPlanograma As StringBuilder
            Dim strPlanogramas As String() = Nothing
            Dim intContador As Integer = 0
            Dim strFechaHoy As String
            Dim intMod As Integer = 0
            Dim strColortd As String = "tdceleste"
            Dim strEstatus As String = "CC"

            ' Creamos los string builders.
            strbldPlanograma = New StringBuilder

            'Determinamos la fecha de hoy para la consulta
            strFechaHoy = Month(Now()) & "/" & Day(Now()) & "/" & Year(Now())

            'Hacemos la consulta de los planogramas
            objPlanogramas = clsConcentrador.clsPlanograma.strBuscar(intCompaniaId, intSucursalId, CDate(strFechaHoy), 0, 0, strCadenaConexion)

            strbldPlanograma.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strbldPlanograma.Append("  <tr class='trtitulos'>")
            strbldPlanograma.Append("    <th width='87' class='rayita'>Planograma</th>")
            strbldPlanograma.Append("    <th width='78' class='rayita'>Estatus</th>")
            strbldPlanograma.Append("  </tr>")

            ' Validamos si trae información para mostrarla
            If IsArray(objPlanogramas) AndAlso objPlanogramas.Length > 0 Then

                ' Barremos el arreglo para ir formando los campos a mostrar en la página HTML
                For intContador = 0 To objPlanogramas.Length - 1
                    strPlanogramas = Nothing
                    strPlanogramas = DirectCast(objPlanogramas.GetValue(intContador), String())

                    intMod = intContador Mod 2
                    If intMod = 0 Then
                        strColortd = "tdceleste"
                    Else
                        strColortd = "tdblanco"
                    End If

                    If CBool(strPlanogramas(1)) = True Then
                        strEstatus = "CC"
                    Else
                        strEstatus = "CI"
                    End If

                    ' Formamos el renglón con la información traida de la base de datos.
                    strbldPlanograma.Append("    <tr> ")
                    strbldPlanograma.Append("        <td class='" & strColortd & "' width='87'>" & strPlanogramas(0) & "</td>")
                    strbldPlanograma.Append("        <td class='" & strColortd & "' width='78'>" & strEstatus & "</td>")
                    strbldPlanograma.Append("    </tr>")

                Next

            End If

            'Cerramos la tabla
            strbldPlanograma.Append("</table>")

            'Convertimos a string
            strPlanogramaHTML = strbldPlanograma.ToString

            'Regresamos el reultado
            Return strPlanogramaHTML


        End Get
    End Property

    '====================================================================
    ' Name       : strFolioFondoFijo
    ' Description: Genera la lista con los Folios sin Utilizar de la Sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFolioFondoFijo() As String
        Get
            Dim strHTML As StringBuilder

            Dim objArrayFolios As Array = Nothing
            Dim strRegistroFolios As String() = Nothing

            Dim intContador As Integer = 0
            Dim strclass As String = "tdceleste"


            strHTML = New StringBuilder


            'Hacemos la consulta de los Listados
            objArrayFolios = clsConcentrador.clsSucursal.strBuscarFolioFondoFijo(intCompaniaId, intSucursalId, 0, 0, strCadenaConexion)

            ' Validamos si trae información para mostrarla
            If IsArray(objArrayFolios) AndAlso objArrayFolios.Length > 0 Then
                intContador = 0

                strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
                strHTML.Append("<tr class='trtitulos'>")
                strHTML.Append("<th width='160' class='rayita' colspan='2'>Folios Fondo Fijo</th>")
                strHTML.Append("</tr>")

                For Each strRegistroFolios In objArrayFolios

                    If (intContador Mod 2) = 0 Then
                        strclass = "tdceleste"
                    Else
                        strclass = "tdblanco"
                    End If

                    strHTML.Append("<tr> ")
                    strHTML.Append("<td class='" & strclass & "' width='85'>" & strRegistroFolios(2) & "</td>")
                    strHTML.Append("<td class='" & strclass & "' width='75'>" & clsCommons.strFormatearFechaPresentacion(strRegistroFolios(4)) & "</td>")
                    strHTML.Append("</tr>")
                    intContador += 1
                Next
                'Cerramos la tabla
                strHTML.Append("</table>")

            End If

            'Regresamos el reultado
            Return strHTML.ToString

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

        Dim strUsuarioNombre As String = Request.Form("txtUsuarioNombre")
        Dim strUsuarioContrasena As String = Request.Form("txtUsuarioContrasena")
        Dim intResultado As Integer = 0

        If Len(strUsuarioNombre) > 0 AndAlso Len(strUsuarioContrasena) > 0 Then

            ' Ejecutamos la validación de la cuenta del usuario
            intResultado = clsConcentrador.clsControlAcceso.intValidarCuentaUsuario(strUsuarioNombre, strUsuarioContrasena, Response, Server, strCadenaConexion)

        Else

            ' Control de Acceso de la página
            If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
                Call Response.Redirect(strRedirectPage)
            End If

        End If

    End Sub

End Class
