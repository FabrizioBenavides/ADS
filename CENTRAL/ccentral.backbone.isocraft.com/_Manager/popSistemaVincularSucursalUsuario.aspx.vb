'====================================================================
' Class         : clsPopSistemaVincularSucursalUsuario
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Elegir sucursales
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Javier Ramos
' Version       : 1.0
' Last Modified : Thursday, June 3, 2004
'====================================================================
Public Class clsPopSistemaVincularSucursalUsuario
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
    Private intmEmpleadoId As Integer
    Private strmEmpleadoNombre As String
    Private strmGrupoUsuarioNombre As String
    Private strmDireccionId As String
    Private strmZonaId As String

    '====================================================================
    ' Name       : intEmpleadoId
    ' Description: Identificador del empleado
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intEmpleadoId() As Integer
        Get
            If intmEmpleadoId = 0 Then
                intmEmpleadoId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intEmpleadoId", isocraft.commons.clsWeb.strGetPageParameter("txtEmpleadoId", "0")))
            End If
            Return intmEmpleadoId
        End Get
    End Property

    '====================================================================
    ' Name       : strEmpleadoNombre
    ' Description: Nombre del Empleado
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strEmpleadoNombre() As String
        Get
            strmEmpleadoNombre = isocraft.commons.clsWeb.strGetPageParameter("strEmpleadoNombre", isocraft.commons.clsWeb.strGetPageParameter("txtEmpleadoNombre", ""))
            Return strmEmpleadoNombre
        End Get
    End Property

    '====================================================================
    ' Name       : strGrupoUsuarioNombre
    ' Description: Nombre del Grupo
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strGrupoUsuarioNombre() As String
        Get
            strmGrupoUsuarioNombre = isocraft.commons.clsWeb.strGetPageParameter("strGrupoUsuarioNombre", isocraft.commons.clsWeb.strGetPageParameter("txtGrupoUsuarioNombre", ""))
            Return strmGrupoUsuarioNombre
        End Get
    End Property

    '====================================================================
    ' Name       : intDireccionId
    ' Description: Identificador de la Direcci�n
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intDireccionId() As Integer
        Get
            If Len(strmDireccionId) = 0 Then
                strmDireccionId = isocraft.commons.clsWeb.strGetPageParameter("cboDireccion", "0")
            End If
            If strmDireccionId.Equals("0") = True Then
                strmDireccionId = isocraft.commons.clsWeb.strGetPageParameter("intDireccionId", "0")
            End If
            Return CInt(strmDireccionId)
        End Get
    End Property

    '====================================================================
    ' Name       : intZonaId
    ' Description: Identificador de la Sucursal
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intZonaId() As Integer
        Get
            If Len(strmZonaId) = 0 Then
                strmZonaId = isocraft.commons.clsWeb.strGetPageParameter("cboZona", "0")
            End If
            If strmZonaId.Equals("0") = True Then
                strmZonaId = isocraft.commons.clsWeb.strGetPageParameter("intZonaId", "0")
            End If
            Return CInt(strmZonaId)
        End Get
    End Property

    
    '====================================================================
    ' Name       : strLlenarDireccionComboBox
    ' Description: Regresa una cadena de texto con el c�digo Javascript
    '              que llena al combo box "cboDireccion"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarDireccionComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccion", intDireccionId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString), 0, 1, 1)
    End Function

    '====================================================================
    ' Name       : strLlenarZonaComboBox
    ' Description: Regresa una cadena de texto con el c�digo Javascript
    '              que llena al combo box "cboZona"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarZonaComboBox() As String
        If intDireccionId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZona", intZonaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, 0, strConnectionString), 0, 1, 1)
        End If
    End Function

    '====================================================================
    ' Name       : strLlenarSucursalComboBox
    ' Description: Regresa una cadena de texto con el c�digo Javascript
    '              que llena al combo box "cboSucursal"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarSucursalComboBox() As String
        If intDireccionId > 0 AndAlso intZonaId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSucursal", "", Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, intZonaId, strConnectionString), New Integer(1) {0, 1}, 2, 0)
        End If
    End Function

    '====================================================================
    ' Name       : strHTMLFechaHora
    ' Description: Genera la fecha y hora de la p�gina
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
    ' Description: Nombre de esta p�gina
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
    ' Description: Obtiene la cadena de conexi�n hacia la base de datos
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

        ' Enviamos al usuario actual a la p�gina de acceso, si no tiene privilegios de acceder a esta p�gina
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Cerrar"

                ' Si se han seleccionado sucursales
                If Len(Request.Form("cboSucursal")) > 0 Then

                    ' Regresamos a la p�gina padre con las sucursales seleccionadas
                    Call Response.Write("<html>" & vbCrLf)
                    Call Response.Write("<head>" & vbCrLf)
                    Call Response.Write("<script language=""javascript"">" & vbCrLf)
                    Call Response.Write("window.opener.document.forms[0].elements[""txtSucursales""].value=""" & Request.Form("cboSucursal") & """;" & vbCrLf)
                    Call Response.Write("window.opener.document.forms[0].elements[""txtCmd""].value=""Vincular"";" & vbCrLf)
                    Call Response.Write("window.opener.document.forms[0].submit();" & vbCrLf)
                    Call Response.Write("window.close();" & vbCrLf)
                    Call Response.Write("</script>" & vbCrLf)
                    Call Response.Write("</head>" & vbCrLf)
                    Call Response.Write("</html>" & vbCrLf)
                    Call Response.End()

                End If

        End Select

    End Sub

End Class
