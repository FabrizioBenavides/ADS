'====================================================================
' Class         : clsPopSistemaBuscarSucursalUsuario
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Elegir sucursales
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Joaquín Hernández García
' Version       : 1.0
' Last Modified : Thursday, June 3, 2004
'====================================================================
Public Class clsPopSistemaBuscarEmpleado
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

    ' Variables privadas locales
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private strmEmpleadoNombre As String
    Private strmEmpleadoNombreSeleccionado As String

    '====================================================================
    ' Name       : strEmpleadoNombre
    ' Description: Texto capturado como filtro de búsqueda
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strEmpleadoNombre() As String
        Get
            If Len(strmEmpleadoNombre) = 0 Then
                strmEmpleadoNombre = CStr(isocraft.commons.clsWeb.strGetPageParameter("strEmpleado", ""))
            End If
            Return strmEmpleadoNombre
        End Get
    End Property

    '====================================================================
    ' Name       : strEmpleadoNombreSeleccionado
    ' Description: Es el nombre del empleado seleccionado
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strEmpleadoNombreSeleccionado() As String
        Get
            If Len(strmEmpleadoNombreSeleccionado) = 0 Then
                strmEmpleadoNombreSeleccionado = CStr(isocraft.commons.clsWeb.strGetPageParameter("txtEmpleadoNombre", ""))
            End If
            Return strmEmpleadoNombreSeleccionado
        End Get
    End Property

    '====================================================================
    ' Name       : strLlenarEmpleadosComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboEmpleado"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarEmpleadosComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboEmpleados", 0, Benavides.CC.Data.clsEmpleado.strBuscarSinUsuarioAsignado(strEmpleadoNombre, strConnectionString), 0, 1, 0)
    End Function

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
    ' Name       : strCmd 
    ' Description: Obtiene o establece el comando actual
    ' Accessor   : Read, Write
    ' Throws     : None
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
    ' Name       : strThisPageName
    ' Description: Nombre de esta página
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request)
        End Get
    End Property

    '====================================================================
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: Establece los comandos Javascript del evento OnLoad
    ' Accessor   : Read
    ' Throws     : None
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Cerrar"

                ' Si se han seleccionado sucursales
                If Len(Request.Form("cboEmpleados")) > 0 Then

                    ' Regresamos a la página padre con las sucursales seleccionadas
                    Call Response.Write("<html>" & vbCrLf)
                    Call Response.Write("<head>" & vbCrLf)
                    Call Response.Write("<script language=""javascript"">" & vbCrLf)
                    Call Response.Write("window.opener.document.forms[0].elements[""txtEmpleadoNombre""].value=""" & strEmpleadoNombreSeleccionado.Trim() & """;" & vbCrLf)
                    Call Response.Write("window.opener.document.forms[0].elements[""txtUsuarioNombre""].value=""" & Request.Form("cboEmpleados") & """;" & vbCrLf)
                    Call Response.Write("window.close();" & vbCrLf)
                    Call Response.Write("</script>" & vbCrLf)
                    Call Response.Write("</head>" & vbCrLf)
                    Call Response.Write("</html>" & vbCrLf)
                    Call Response.End()

                End If

        End Select

    End Sub

End Class
