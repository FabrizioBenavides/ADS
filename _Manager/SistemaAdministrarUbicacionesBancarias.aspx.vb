'====================================================================
' Class         : clsSistemaAdministrarUbicacionesBancarias
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Administrar ubicaciones bancarias
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Joaquín Hernández García
' Version       : 1.0
' Last Modified : Thursday, June 10, 2004
'====================================================================
Public Class clsSistemaAdministrarUbicacionesBancarias
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

    ' Variables locales privadas
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String

    '====================================================================
    ' Name       : strUbicacionBancoNombre
    ' Description: Obtiene el valor del campo "txtUbicacionBancoNombre"
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUbicacionBancoNombre() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("txtUbicacionBancoNombre", "")
        End Get
    End Property

    '====================================================================
    ' Name       : strUbicacionBancoNombreId
    ' Description: Obtiene el valor del campo "txtUbicacionBancoNombreId"
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUbicacionBancoNombreId() As String
        Get
            Return Trim(isocraft.commons.clsWeb.strGetPageParameter("txtUbicacionBancoNombreId", ""))
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
        Const strRecordBrowserName As String = "SistemaAdministrarUbicacionesBancarias"

        ' Declaramos e inicialziamos las variables locales
        Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1"))
        Dim astrDataArray As Array = Benavides.CC.Data.clstblUbicacionBanco.strBuscar(0, "", "", Now, "", Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

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
                If Len(strUbicacionBancoNombreId) > 0 AndAlso Len(strUbicacionBancoNombreId) > 0 Then

                    ' Buscamos la ubicación
                    Dim astrRecords As Array = Benavides.CC.Data.clstblUbicacionBanco.strBuscar(0, strUbicacionBancoNombreId, "", Now, "", 0, 0, strConnectionString)

                    ' Si la ubicación no existe
                    If astrRecords.Length = 0 Then

                        ' Agregamos la nueva ubicación
                        Call Benavides.CC.Data.clstblUbicacionBanco.intAgregar(0, strUbicacionBancoNombreId, strUbicacionBancoNombre, Now, strUsuarioNombre, strConnectionString)

                        ' Deshabilitamos los campos de la forma
                        blnDeshabilitarCamposForma = True

                        ' Establecemos el siguiente comando
                        strCmd = ""

                    Else

                        ' Recuperamos los campos
                        strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtUbicacionBancoId""].value=""0"";" & vbCrLf
                        strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtUbicacionBancoNombreId""].value=""" & strUbicacionBancoNombreId & """;" & vbCrLf
                        strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtUbicacionBancoNombre""].value=""" & strUbicacionBancoNombre & """;" & vbCrLf

                        ' La ubicación existe, por lo tanto indicamos el error
                        strJavascriptWindowOnLoadCommands &= "  alert(""La ubicación bancaria \""" & strUbicacionBancoNombreId & "\"" ya existe. Por favor especifique un nuevo identificador."");" & vbCrLf

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

                ' Obtenemos el valor del identificador de la ubicación
                Dim intUbicacionBancoId As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intUbicacionBancoId", "0", Request))

                ' Si el identificador es válido
                If intUbicacionBancoId > 0 Then

                    ' Buscamos la ubicación
                    Dim astrRecords As Array = Benavides.CC.Data.clstblUbicacionBanco.strBuscar(intUbicacionBancoId, "", "", Now, "", 0, 0, strConnectionString)

                    ' Si encontramos la ubicación
                    If IsArray(astrRecords) = True AndAlso astrRecords.Length > 0 Then

                        ' Obtenemos el elemento
                        Dim astrFields As String() = DirectCast(astrRecords.GetValue(0), String())

                        ' Recuperamos los campos
                        strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtUbicacionBancoId""].value=""" & CStr(astrFields.GetValue(0)) & """;" & vbCrLf
                        strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtUbicacionBancoNombreId""].value=""" & CStr(astrFields.GetValue(1)) & """;" & vbCrLf
                        strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtUbicacionBancoNombre""].value=""" & CStr(astrFields.GetValue(2)) & """;" & vbCrLf

                        ' Establecemos el siguiente comando
                        strCmd = "SalvarEditar"

                    Else

                        ' No existe la ubicación
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

                ' Obtenemos el valor del identificador de la ubicación
                Dim intUbicacionBancoId As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("txtUbicacionBancoId", "0", Request))

                ' Si los campos han sido llenados
                If intUbicacionBancoId > 0 AndAlso Len(strUbicacionBancoNombreId) > 0 AndAlso Len(strUbicacionBancoNombre) > 0 Then

                    ' Agregamos la nueva ubicación
                    Call Benavides.CC.Data.clstblUbicacionBanco.intActualizar(intUbicacionBancoId, strUbicacionBancoNombreId, strUbicacionBancoNombre, Now, strUsuarioNombre, strConnectionString)

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

            strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtUbicacionBancoNombreId""].disabled=true;"
            strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtUbicacionBancoNombre""].disabled=true;"
            strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""cmdSalvar""].disabled=true;"

        End If

    End Sub

End Class
