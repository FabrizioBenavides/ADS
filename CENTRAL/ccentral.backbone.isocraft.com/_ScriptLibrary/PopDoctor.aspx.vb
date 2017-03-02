'====================================================================
' Page          : PopArticulos.aspx
' Title         : Administracion POS y BackOffice
' Description   : Popup para selecionar Articulos
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Griselda Gómez Ponce
' Version       : 1.0
' Last Modified : Tuesday, November 15, 2005
'====================================================================
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration
Imports Isocraft.Web.Http
Imports System.Xml

Public Class PopDoctor
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object


#End Region

#Region " Class Private Attributes"

    Private blnmSucursal As Boolean
    Private strmJavascriptWindowOnLoadCommands As String

#End Region

    '====================================================================
    ' Name       : strCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return GetPageParameter("strCmd", "")
        End Get
    End Property

  

    '====================================================================
    ' Name       : strRedirectPage
    ' Description: Página hacia la cual se debe redireccionar al usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRedirectPage() As String
        Get

            If intCompaniaId > 0 AndAlso intSucursalId > 0 Then

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
    ' Accessor   : Read, Write
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
    ' Name       : strURLPOSAdmin
    ' Description: URL del POS Admin
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strURLPOSAdmin() As String
        Get
            Return clsConcentrador.strObtenerURLSucursal(intCompaniaId, intSucursalId, strCadenaConexion)
        End Get
    End Property

    '====================================================================
    ' Name       : strArticuloIdNombre
    ' Description: Código de articulo o cadena de caracteres a Buscar.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strArticuloIdNombre() As String
        Get
            Return Request.QueryString("strArticuloIdNombre")
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





    Private Sub Page_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Load

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin & strRedirectPage)
        End If


        ' Ejecutamos el comando indicado
        Select Case strCmd
            Case "Cerrar"

                Call Response.Write("<html>" & vbCrLf)
                Call Response.Write("<head>" & vbCrLf)
                Call Response.Write("<script language=""javascript"">" & vbCrLf)
                Call Response.Write("window.close();" & vbCrLf)
                Call Response.Write("</script>" & vbCrLf)
                Call Response.Write("</head>" & vbCrLf)
                Call Response.Write("</html>" & vbCrLf)
                Call Response.End()

        End Select



    End Sub


    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Genera el Record Browser para mostrar los Articulos
    '              de acuerdo a su descripcion.
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String
        ' Declaracion de Variables

        Dim cedula As String
        Dim xml As New XmlDocument

        Dim strInfo As String
        Dim sb As New StringBuilder
        cedula = isocraft.commons.clsWeb.strGetPageParameter("cedula", "")

        strInfo = clsConcentrador.clsDoctores.strConsultarDoctores(cedula, strCadenaConexion)

        If Not strInfo.StartsWith("<RESPUESTA>Error") Then

            strInfo = "<root>" & strInfo & "</root>"
            xml.LoadXml(strInfo)

            Dim root As XmlNode = xml.DocumentElement

            'Pintado de la Tabla
            Call sb.Append("<table cellspacing='0' cellpadding='0' width='80%' bgcolor='#ffffff' border='0' align='center'>")
            Call sb.Append("<tr>")
            Call sb.Append("<td width='2%'>&nbsp;</td>")
            Call sb.Append("<td class='tdceleste'>")
            Call sb.Append("<span>Cedula</span>")
            Call sb.Append("</td>")
            Call sb.Append("<td class='tdceleste'>")
            Call sb.Append("<span>Nombre</span>")
            Call sb.Append("</td>")
            Call sb.Append("</tr>")
            Call sb.Append("<tr>")
            Call sb.Append("<td width='2%'>&nbsp;</td>")
            Call sb.Append("<td class='tdceleste'>")
            Call sb.Append(root.SelectSingleNode("RESPUESTA/doctor/cedula").InnerText)
            Call sb.Append("</td>")
            Call sb.Append("<td class='tdceleste'>")
            Call sb.Append(strFormatearDescripcion(root.SelectSingleNode("RESPUESTA/doctor/nombre").InnerText) & " " & strFormatearDescripcion(root.SelectSingleNode("RESPUESTA/doctor/apellidopaterno").InnerText) & " " & strFormatearDescripcion(root.SelectSingleNode("RESPUESTA/doctor/apellidomaterno").InnerText))
            Call sb.Append("</td>")
            Call sb.Append("</tr>")
            Call sb.Append("<tr align='center'>")
            Call sb.Append("<td width='2%'>&nbsp;</td>")
            Call sb.Append("<td colspan='2' class='tdceleste'>")
            Call sb.Append("<span>Dirección</span>")
            Call sb.Append("</td>")
            Call sb.Append("</tr>")
            Call sb.Append("<tr>")
            Call sb.Append("<td width='2%'>&nbsp;</td>")
            Call sb.Append("<td width='30%' class='tdceleste'>")
            Call sb.Append("<span>Calle</span>")
            Call sb.Append("</td>")
            Call sb.Append("<td class='tdceleste'>")
            Call sb.Append(strFormatearDescripcion(root.SelectSingleNode("RESPUESTA/doctor/calle").InnerText))
            Call sb.Append("</td>")
            Call sb.Append("</tr>")
            Call sb.Append("<tr>")
            Call sb.Append("<td width='2%'>&nbsp;</td>")
            Call sb.Append("<td width='30%' class='tdceleste'>")
            Call sb.Append("<span>No.Interior</span>")
            Call sb.Append("</td>")
            Call sb.Append("<td class='tdceleste'>")
            Call sb.Append(root.SelectSingleNode("RESPUESTA/doctor/interior").InnerText)
            Call sb.Append("</td>")
            Call sb.Append("</tr>")
            Call sb.Append("<tr>")
            Call sb.Append("<td width='2%'>&nbsp;</td>")
            Call sb.Append("<td width='30%' class='tdceleste'>")
            Call sb.Append("<span>No.Exterior</span>")
            Call sb.Append("</td>")
            Call sb.Append("<td class='tdceleste'>")
            Call sb.Append(root.SelectSingleNode("RESPUESTA/doctor/exterior").InnerText)
            Call sb.Append("</td>")
            Call sb.Append("</tr>")
            Call sb.Append("<tr>")
            Call sb.Append("<td width='2%'>&nbsp;</td>")
            Call sb.Append("<td width='30%' class='tdceleste'>")
            Call sb.Append("<span>Colonia</span>")
            Call sb.Append("</td>")
            Call sb.Append("<td class='tdceleste'>")
            Call sb.Append(strFormatearDescripcion(root.SelectSingleNode("RESPUESTA/doctor/colonia").InnerText))
            Call sb.Append("</td>")
            Call sb.Append("</tr>")
            Call sb.Append("<tr>")
            Call sb.Append("<td width='2%'>&nbsp;</td>")
            Call sb.Append("<td width='30%' class='tdceleste'>")
            Call sb.Append("<span>Ciudad</span>")
            Call sb.Append("</td>")
            Call sb.Append("<td class='tdceleste'>")
            Call sb.Append(root.SelectSingleNode("RESPUESTA/doctor/ciudadnombre").InnerText)
            Call sb.Append("</td>")
            Call sb.Append("</tr>")
            Call sb.Append("<tr>")
            Call sb.Append("<td width='2%'>&nbsp;</td>")
            Call sb.Append("<td width='30%' class='tdceleste'>")
            Call sb.Append("<span>Estado</span>")
            Call sb.Append("</td>")
            Call sb.Append("<td class='tdceleste'>")
            Call sb.Append(root.SelectSingleNode("RESPUESTA/doctor/estadonombre").InnerText)
            Call sb.Append("</td>")
            Call sb.Append("</tr>")
            Call sb.Append("<tr>")
            Call sb.Append("<td width='2%'>&nbsp;</td>")
            Call sb.Append("<td width='30%' class='tdceleste'>")
            Call sb.Append("<span>Codigo Postal</span>")
            Call sb.Append("</td>")
            Call sb.Append("<td class='tdceleste'>")
            Call sb.Append(root.SelectSingleNode("RESPUESTA/doctor/codigopostal").InnerText)
            Call sb.Append("</td>")
            Call sb.Append("</tr>")
            Call sb.Append("<tr align='right'>")
            Call sb.Append("<td colspan='3'>&nbsp;</td>")
            Call sb.Append("</tr>")
            Call sb.Append("</table>")
        Else
            Call sb.Append("<table cellspacing='0' cellpadding='0' width='80%' bgcolor='#ffffff' border='0' align='center'>")
            Call sb.Append("<tr>")
            Call sb.Append("<td width='2%'>&nbsp;</td>")
            Call sb.Append("<td class='tdceleste'>")
            Call sb.Append("<span>No hay información de la cédula solicitada</span>")
            Call sb.Append("</td>")
            Call sb.Append("</tr>")
            Call sb.Append("</table>")
        End If

        strRecordBrowserHTML = sb.ToString()


    End Function


    '====================================================================
    ' Name       : strConvertToJavascriptString
    ' Description: Returns a string containing a safe Javascript clause
    ' Parameters :
    '              ByVal Value As String
    '                 - The string to be converted
    '====================================================================
    Public Shared Function strConvertToJavascriptString(ByVal Value As String) As String

        ' Member identifier
1:      Const strmThisMemberName As String = "strConvertToJavascriptString"

        ' Declare the returned value
2:      Dim strData As String = ""

3:      Try

            ' Sanitize the value
4:          If Len(Value) > 0 Then
5:              strData = Replace(Value, "\", "\\")
6:              strData = Replace(strData, """", "\""")
7:              strData = Replace(strData, vbCrLf, "\r\n")
8:              strData = Replace(strData, vbCr, "")
9:              strData = Replace(strData, vbLf, "")
10:         End If

            ' Return the sanitized value
11:         Return strData

12:     Catch objException As Exception


38:         Return ""

39:     End Try

    End Function


    '====================================================================
    ' Name       : strFormatearDescripcion
    ' Description: Función que le da formato a los campos descripción que
    '              contengan comillas dobles o apóstrofes.
    ' Parameters :
    '              ByVal strTexto As String
    '                 - Texto a ser generado en Javascript
    ' Throws     : Ninguna
    ' Output     : String
    '                 - Cadena de caracteres válida en Javascript
    '====================================================================
    Public Shared Function strFormatearDescripcion(ByVal strTexto As String) As String

        ' Transformamos la cadena únicamente si no está en blanco
        If Len(strTexto) > 0 Then

            ' Declaración e inicialización de variables locales
            Dim strData As String = ""

            ' Reemplazamos los caracteres especiales

            strData = Replace(strTexto, "\", "\\")
            strData = Replace(strData, """", "&quot;")
            strData = Replace(strData, "'", " ")
            strData = strData.Trim
            Return strData
        Else

            Return ""

        End If


    End Function

End Class
