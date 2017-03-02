'====================================================================
' Class         : clsSistemaEditarGrupo
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Edición de grupos
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Joaquín Hernández García
' Version       : 1.0
' Last Modified : Wednesday, June 9, 2004
'====================================================================
Public Class clsSistemaEditarGrupo
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
    Private strmCommand As String
    Private strmJavascriptWindowOnLoadCommands As String

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
    ' Name       : strThisPageName
    ' Description: URL de esta página
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request) & "?strCmd=" & strCmd
        End Get
    End Property

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Obtiene la cadena de conexión hacia la base de datos
    ' Accessor   : Read
    ' Throws     : None
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Agregar"

                ' Establecemos el siguiente comando
                strCmd = "SalvarAgregar"

            Case "SalvarAgregar"

                ' Obtenemos los valores almacenados en los campos de la forma
                Dim strGrupoUsuarioNombreId As String = isocraft.commons.clsWeb.strGetPageParameter("txtGrupoUsuarioNombreId", "")
                Dim strGrupoUsuarioNombre As String = isocraft.commons.clsWeb.strGetPageParameter("txtGrupoUsuarioNombre", "")
                Dim strGrupoUsuarioDescripcion As String = isocraft.commons.clsWeb.strGetPageParameter("txtGrupoUsuarioDescripcion", "")
                Dim blnGrupoUsuarioReplicable As Byte = CByte(isocraft.commons.clsWeb.strGetPageParameter("optGrupoUsuarioReplicable", "0"))
                Dim blnGrupoUsuarioSistema As Byte = CByte(isocraft.commons.clsWeb.strGetPageParameter("optGrupoUsuarioSistema", "0"))

                ' Agregamos el grupo de usuario, si el identificador del grupo y los campos requeridos son válidos
                If Len(strGrupoUsuarioNombreId) > 0 AndAlso Len(strGrupoUsuarioNombre) > 0 Then
                    Call Benavides.CC.Data.clstblGrupoUsuario.intAgregar(0, strGrupoUsuarioNombreId, strGrupoUsuarioNombre, strGrupoUsuarioDescripcion, blnGrupoUsuarioReplicable, blnGrupoUsuarioSistema, Now, strUsuarioNombre, strConnectionString)
                End If

                ' Regresamos a la página principal
                Call Response.Redirect("SistemaAdministrarGrupos.aspx")

            Case "Editar"

                ' Obtenemos el valore del identificador del grupo de usuario
                Dim intGrupoUsuarioId As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intGrupoUsuarioId", "0"))

                'Si el identificador es válido
                If intGrupoUsuarioId > 0 Then

                    ' Buscamos el grupo
                    Dim astrData As Array = Benavides.CC.Data.clstblGrupoUsuario.strBuscar(intGrupoUsuarioId, "", "", "", 0, 0, Now, "", 0, 0, strConnectionString)

                    ' Si el grupo fue encontrado
                    If astrData.Length > 0 Then

                        ' Obtenemos el valor de sus campos
                        Dim astrDataRow As Array = DirectCast(astrData.GetValue(0), Array)

                        ' Inicializamos los campos
                        strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtGrupoUsuarioId""].value=""" & CStr(astrDataRow.GetValue(0)) & """;" & vbCrLf
                        strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtGrupoUsuarioNombreId""].value=""" & CStr(astrDataRow.GetValue(1)) & """;" & vbCrLf
                        strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtGrupoUsuarioNombre""].value=""" & CStr(astrDataRow.GetValue(2)) & """;" & vbCrLf
                        strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtGrupoUsuarioDescripcion""].value=""" & CStr(astrDataRow.GetValue(3)) & """;" & vbCrLf

                        Dim blnIndicator As Boolean = CBool(astrDataRow.GetValue(4))
                        Dim intIndicator As Integer = 0
                        If blnIndicator = True Then
                            intIndicator = 1
                        End If
                        strJavascriptWindowOnLoadCommands &= "  CheckOptionButton(document.forms[0].elements[""optGrupoUsuarioReplicable""], " & intIndicator & ");" & vbCrLf

                        blnIndicator = CBool(astrDataRow.GetValue(5))
                        intIndicator = 0
                        If blnIndicator = True Then
                            intIndicator = 1
                        End If
                        strJavascriptWindowOnLoadCommands &= "  CheckOptionButton(document.forms[0].elements[""optGrupoUsuarioSistema""], " & intIndicator & ");" & vbCrLf

                        ' Establecemos el siguiente comando
                        strCmd = "SalvarEditar"

                    End If


                End If

            Case "SalvarEditar"

                ' Obtenemos los valores almacenados en los campos de la forma
                Dim intGrupoUsuarioId As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("txtGrupoUsuarioId", "0"))
                Dim strGrupoUsuarioNombreId As String = isocraft.commons.clsWeb.strGetPageParameter("txtGrupoUsuarioNombreId", "")
                Dim strGrupoUsuarioNombre As String = isocraft.commons.clsWeb.strGetPageParameter("txtGrupoUsuarioNombre", "")
                Dim strGrupoUsuarioDescripcion As String = isocraft.commons.clsWeb.strGetPageParameter("txtGrupoUsuarioDescripcion", "")
                Dim blnGrupoUsuarioReplicable As Byte = CByte(isocraft.commons.clsWeb.strGetPageParameter("optGrupoUsuarioReplicable", "0"))
                Dim blnGrupoUsuarioSistema As Byte = CByte(isocraft.commons.clsWeb.strGetPageParameter("optGrupoUsuarioSistema", "0"))

                ' Actualizamos el grupo de usuario, si el identificador del grupo y los campos requeridos son válidos
                If intGrupoUsuarioId > 0 AndAlso Len(strGrupoUsuarioNombreId) > 0 AndAlso Len(strGrupoUsuarioNombre) > 0 Then
                    Call Benavides.CC.Data.clstblGrupoUsuario.intActualizar(intGrupoUsuarioId, strGrupoUsuarioNombreId, strGrupoUsuarioNombre, strGrupoUsuarioDescripcion, blnGrupoUsuarioReplicable, blnGrupoUsuarioSistema, Now, strUsuarioNombre, strConnectionString)
                End If

                ' Regresamos a la página principal
                Call Response.Redirect("SistemaAdministrarGrupos.aspx")

            Case Else

                ' Regresamos a la página principal
                Call Response.Redirect("SistemaAdministrarGrupos.aspx")

        End Select

    End Sub

End Class
