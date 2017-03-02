'====================================================================
' Class         : clsSistemaAdministrarMonedas
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Administrar monedas
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Joaquín Hernández García
' Version       : 1.0
' Last Modified : Monday, May 24, 2004
'====================================================================
Public Class clsSistemaAdministrarMonedas
    Inherits System.Web.UI.Page

    ' Variables locales privadas
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private strmReadOnlyId As String

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
    ' Name       : strReadOnlyId 
    ' Description: Establece el valor del atributo readOnly del campo
    '              identificador de la moneda
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strReadOnlyId() As String
        Get
            Return strmReadOnlyId
        End Get
        Set(ByVal strValue As String)
            strmReadOnlyId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strMonedaNombre
    ' Description: Obtiene el valor del campo "txtMonedaNombre"
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strMonedaNombre() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("txtMonedaNombre", "")
        End Get
    End Property

    '====================================================================
    ' Name       : strMonedaNombreId
    ' Description: Obtiene el valor del campo "txtMonedaNombreId"
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strMonedaNombreId() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("txtMonedaNombreId", "")
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)
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
            Return CInt(Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strHTMLFechaHora
    ' Description: Genera la fecha y hora de la página
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
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
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request)
        End Get
    End Property

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Obtiene la cadena de conexión hacia la base de datos
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: Establece los comandos Javascript del evento OnLoad
    ' Accessor   : Read
    ' Throws     : Ninguna
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
    ' Name       : strCmd 
    ' Description: Obtiene o establece el comando actual
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strCmd() As String
        Get
            Return strmCommand
        End Get
        Set(ByVal strValue As String)
            strmCommand = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String
        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 10
        Const strRecordBrowserName As String = "SistemaAdministrarMonedas"

        ' Declaramos e inicialziamos las variables locales
        Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1"))
        Dim astrDataArray As Array = Benavides.CC.Data.clstblMoneda.strBuscar(0, "", "", Now, "", Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

        ' Regresamos el resultado
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?")
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaramos e inicializamos el indicador de deshabilitación de los campos
        Dim blnDeshabilitarCamposForma As Boolean = False

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Agregar"

                ' Establecemos el siguiente comando
                strCmd = "SalvarAgregar"

            Case "SalvarAgregar"

                ' Si los campos han sido llenados
                If Len(strMonedaNombre) > 0 AndAlso Len(strMonedaNombreId) > 0 Then

                    ' Buscamos la moneda
                    Dim astrRecords As Array = Benavides.CC.Data.clstblMoneda.strBuscar(0, strMonedaNombreId, "", Now, "", 0, 0, strConnectionString)

                    ' Si la moneda no existe
                    If astrRecords.Length = 0 Then

                        ' Agregamos la nueva moneda
                        Call Benavides.CC.Data.clstblMoneda.intAgregar(0, strMonedaNombreId, strMonedaNombre, Now, strUsuarioNombre, strConnectionString)

                        ' Deshabilitamos los campos de la forma
                        blnDeshabilitarCamposForma = True

                        ' Establecemos el siguiente comando
                        strCmd = ""

                    Else

                        ' Recuperamos los campos
                        strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtMonedaId""].value=""0"";" & vbCrLf
                        strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtMonedaNombreId""].value=""" & strMonedaNombreId & """;" & vbCrLf
                        strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtMonedaNombre""].value=""" & strMonedaNombre & """;" & vbCrLf

                        ' La moneda existe, por lo tanto indicamos el error
                        strJavascriptWindowOnLoadCommands &= "  alert(""La moneda \""" & strMonedaNombreId & "\"" ya existe. Por favor especifique un nuevo identificador."");" & vbCrLf

                        ' Establecemos el siguiente comando
                        strCmd = "SalvarAgregar"

                    End If

                Else

                    ' Deshabilitamos los campos de la forma
                    blnDeshabilitarCamposForma = True

                    ' Establecemos el siguiente comando
                    strCmd = ""

                End If

            Case "Editar"

                ' Obtenemos el valor del identificador de la moneda
                Dim intMonedaId As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intMonedaId", "0", Request))

                ' Si el identificador es válido
                If intMonedaId > 0 Then

                    ' Buscamos la moneda
                    Dim astrRecords As Array = Benavides.CC.Data.clstblMoneda.strBuscar(intMonedaId, "", "", Now, "", 0, 0, strConnectionString)

                    ' Si encontramos la moneda
                    If IsArray(astrRecords) = True AndAlso astrRecords.Length > 0 Then

                        ' Obtenemos el elemento
                        Dim astrFields As String() = DirectCast(astrRecords.GetValue(0), String())

                        ' Recuperamos los campos
                        strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtMonedaId""].value=""" & CStr(astrFields.GetValue(0)) & """;" & vbCrLf
                        strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtMonedaNombreId""].value=""" & CStr(astrFields.GetValue(1)) & """;" & vbCrLf
                        strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtMonedaNombre""].value=""" & CStr(astrFields.GetValue(2)) & """;" & vbCrLf
                        strReadOnlyId = "readonly"

                        ' Establecemos el siguiente comando
                        strCmd = "SalvarEditar"

                    Else

                        ' No existe la moneda
                        blnDeshabilitarCamposForma = True

                        ' Establecemos el siguiente comando
                        strCmd = ""

                    End If

                Else

                    ' ERROR, mal uso del comando
                    blnDeshabilitarCamposForma = True

                    ' Establecemos el siguiente comando
                    strCmd = ""

                End If

            Case "SalvarEditar"

                ' Obtenemos el valor del identificador de la moneda
                Dim intMonedaId As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("txtMonedaId", "0", Request))

                ' Si los campos han sido llenados
                If intMonedaId > 0 AndAlso Len(strMonedaNombre) > 0 AndAlso Len(strMonedaNombreId) > 0 Then

                    ' Agregamos la nueva moneda
                    Call Benavides.CC.Data.clstblMoneda.intActualizar(intMonedaId, strMonedaNombreId, strMonedaNombre, Now, strUsuarioNombre, strConnectionString)

                End If

                ' Deshabilitamos los campos de la forma
                blnDeshabilitarCamposForma = True

            Case Else

                ' Deshabilitamos los campos de la forma
                blnDeshabilitarCamposForma = True

                ' Establecemos el siguiente comando
                strCmd = ""

        End Select

        ' Deshabilitamos los campos de la forma, si así se ha establecido
        If blnDeshabilitarCamposForma = True Then

            strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtMonedaNombre""].disabled=true;"
            strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtMonedaNombreId""].disabled=true;"
            strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""cmdSalvar""].disabled=true;"

        End If

    End Sub

End Class
