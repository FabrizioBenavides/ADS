Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data

Imports System.Configuration
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.IO
Imports System.Xml
Imports System.Xml.XPath


Public Class clsSucursalConsultaBanorte
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
    End Sub

#End Region


#Region " Class Private Attributes"

    Const strComitasDobles As String = """"


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
    ' Name       : strFormActionParameters
    ' Description: Parametros utilizados
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormActionParameters() As String
        Get
            Return ""
        End Get
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Comando a ejecutar
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Not IsNothing(Request.QueryString("strCmd")) Then
                Return (Request.QueryString("strCmd"))
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strAutorizacionId
    ' Description: Autorizacion a consultar
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : string
    '====================================================================
    Public ReadOnly Property strAutorizacionId() As String
        Get
            If Len(Request("strAutorizacionId")) > 0 Then
                Return Request("strAutorizacionId")
            Else
                Return ""
            End If

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

        ' Control de Acceso de la página
        'If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
        '    Call Response.Redirect(strURLPOSAdmin & strRedirectPage)
        'End If

        Select Case strCmd

            Case "Autorizacion" ' Realizamos la consulta de la autorizacion

                Dim strHTML As New StringBuilder

                Dim objXPathDocument As XPathDocument = Nothing
                Dim objXPathNavigator As XPathNavigator = Nothing
                Dim objIterator As XPathNodeIterator = Nothing
                Dim objXPathNodeIterator As XPathNodeIterator = Nothing

                Dim strWSAutorizacion As String

                Dim blnRespuesta As Boolean = False
                Dim strRespuestaError As String = ""

                Dim strCedula As String
                Dim strNombreMedico As String
                Dim strNomina As String
                Dim strFamiliar As String
                Dim strNombreDerechohabiente As String
                Dim strFecha As String

                strWSAutorizacion = clsConcentrador.clsAutorizacionBanorte.strConsultar(strAutorizacionId, "http://189.254.22.30/WebServicesAMB/WS_HSA/datosaut.asmx")

                If strWSAutorizacion = "conexionError" Then
                    strRespuestaError = "Error de comunicacion al consultar autorizacion Banorte"
                Else
                    strRespuestaError = "Autorizacion no existe"

                    ' Creamos el objeto que almacenará el XML recibido
                    objXPathDocument = New XPathDocument(New XmlTextReader(New StringReader(strWSAutorizacion)))
                    objXPathNavigator = objXPathDocument.CreateNavigator()

                    ' Obtenemos el Identificador del Reenvío: /NewDataSet/Autorizaciones/cedula
                    objIterator = objXPathNavigator.Select("/NewDataSet/Autorizaciones")

                    While objIterator.MoveNext()

                        objXPathNodeIterator = objIterator.Current.SelectChildren(XPathNodeType.All)

                        ' Obtenemos los valores de los nodos hijos
                        While objXPathNodeIterator.MoveNext()

                            blnRespuesta = True

                            ' Almacenamos los valores en las variables locales
                            Select Case objXPathNodeIterator.Current.Name

                                Case "cedula"
                                    strCedula = objXPathNodeIterator.Current.Value

                                Case "Nombre_Medico"
                                    strNombreMedico = objXPathNodeIterator.Current.Value

                                Case "nomina"
                                    strNomina = objXPathNodeIterator.Current.Value

                                Case "familiar"
                                    strFamiliar = objXPathNodeIterator.Current.Value

                                Case "Nombre_Derechohabiente"
                                    strNombreDerechohabiente = objXPathNodeIterator.Current.Value

                                Case "Fecha"
                                    strFecha = objXPathNodeIterator.Current.Value

                            End Select

                        End While

                    End While

                    If blnRespuesta Then
                        strRespuestaError = ""
                    End If

                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpdAutorizacionPorIframe( " & _
                               strComitasDobles & strCedula & strComitasDobles & "," & _
                               strComitasDobles & strNombreMedico & strComitasDobles & "," & _
                               strComitasDobles & strNomina & strComitasDobles & "," & _
                               strComitasDobles & strFamiliar & strComitasDobles & "," & _
                               strComitasDobles & strNombreDerechohabiente & strComitasDobles & "," & _
                               strComitasDobles & strFecha & strComitasDobles & "," & _
                               strComitasDobles & strRespuestaError & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

        End Select

    End Sub

End Class
