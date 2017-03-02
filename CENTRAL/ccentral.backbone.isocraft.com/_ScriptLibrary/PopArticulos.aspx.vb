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

Public Class PopArticulos
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        blnSucursal = GetPageParameter("blnSucursal", True)

    End Sub

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
    ' Name       : blnSucursal
    ' Description: Bandera para buscar articulos en todas las sucursales
    ' Accessor   : Read/Write
    ' Throws     : Ninguna
    ' Output     : Boolean
    '====================================================================
    Public Property blnSucursal() As Boolean
        Get
            Return blnmSucursal
        End Get
        Set(ByVal blnValue As Boolean)
            blnmSucursal = blnValue
        End Set
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

    '====================================================================
    ' Name       : strLlenarArticulosComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboArticulos"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarArticulosComboBox() As String

        Dim DataArray As Array = clsConcentrador.clsSucursal.strBuscarArticuloAntibiotico(intCompaniaId, intSucursalId, strArticuloIdNombre, strCadenaConexion)

        Dim strData As New System.Text.StringBuilder
        Dim avntRow As Array = Nothing

        Dim intCounter As Integer = 0
        If IsArray(DataArray) = True AndAlso DataArray.Length > 0 Then
            For Each avntRow In DataArray
                strData.Append("  document.forms[0].elements[""cboArticulos""].options[" & intCounter & "] = new Option(""" & strConvertToJavascriptString(CStr(avntRow.GetValue(5))) & """,""" & strConvertToJavascriptString(CStr(avntRow.GetValue(0))) & """);" & vbCrLf)
                intCounter += 1
            Next
        Else
            strData.Append("  document.forms[0].elements[""cboArticulos""].style.display='none';")
            strData.Append("  document.forms[0].elements[""cmdAgregar""].style.display='none';")
        End If

        Return strData.ToString()



    End Function

   

    Private Sub Page_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Load

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin & strRedirectPage)
        End If


        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Agregar"

                ' Si se han seleccionado articulos
                If Len(Request.Form("cboArticulos")) > 0 Then
                    ' Regresamos a la página padre con los articulos seleccionados
                    Call Response.Write("<html>" & vbCrLf)
                    Call Response.Write("<head>" & vbCrLf)
                    Call Response.Write("<script language=""javascript"">" & vbCrLf)
                    Call Response.Write("var founded = 0;" & vbCrLf)
                    Call Response.Write("var counter = 0;" & vbCrLf)
                    Call Response.Write("// Agrega todos excepto si alguno es igual al nuevo" & vbCrLf)
                    Call Response.Write("var todos = '" & Request.Form("cboArticulos") & ",' + window.opener.document.forms[0].elements['txtSelected'].value" & vbCrLf)
                    Call Response.Write("var lista = todos.split(',')" & vbCrLf)
                    Call Response.Write("var articulos = window.opener.document.forms[0].elements['txtSelected'].value.split(',');" & vbCrLf)
                    Call Response.Write("if (window.opener.document.forms[0].elements['txtSelected'].value!='')" & vbCrLf)
                    Call Response.Write("     counter = articulos.length;" & vbCrLf)
                    Call Response.Write("for (var i in lista)" & vbCrLf)
                    Call Response.Write("{					" & vbCrLf)
                    Call Response.Write("     founded = 0;" & vbCrLf)
                    Call Response.Write("     for (var a in articulos)" & vbCrLf)
                    Call Response.Write("         {					" & vbCrLf)
                    Call Response.Write("             if (lista[i] == articulos[a])" & vbCrLf)
                    Call Response.Write("                     founded = 1;" & vbCrLf)
                    Call Response.Write("         }" & vbCrLf)
                    Call Response.Write("     if (founded == 0)" & vbCrLf)
                    Call Response.Write("         {		" & vbCrLf)
                    Call Response.Write("             if (counter < 10)" & vbCrLf)
                    Call Response.Write("               {" & vbCrLf)
                    Call Response.Write("                  if(window.opener.document.forms[0].elements['txtSelected'].value == '')" & vbCrLf)
                    Call Response.Write("                     window.opener.document.forms[0].elements['txtSelected'].value = lista[i]; " & vbCrLf)
                    Call Response.Write("                  else" & vbCrLf)
                    Call Response.Write("                     window.opener.document.forms[0].elements['txtSelected'].value = window.opener.document.forms[0].elements['txtSelected'].value + ',' + lista[i];" & vbCrLf)
                    Call Response.Write("                  counter = counter + 1;" & vbCrLf)
                    Call Response.Write("               }" & vbCrLf)
                    Call Response.Write("          }" & vbCrLf)
                    Call Response.Write("}" & vbCrLf)
                    Call Response.Write("window.opener.document.forms[0].submit();" & vbCrLf)
                    Call Response.Write("window.close();" & vbCrLf)
                    Call Response.Write("</script>" & vbCrLf)
                    Call Response.Write("</head>" & vbCrLf)
                    Call Response.Write("</html>" & vbCrLf)
                    Call Response.End()
                End If


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

End Class
