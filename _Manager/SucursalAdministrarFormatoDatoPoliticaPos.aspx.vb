'====================================================================
' Class         : clsSucursalAdministrarFormatoDatoPoliticaPos
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Administrar formatos de datos de políticas de POS
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Mario C. Menchaca Salgado
' Version       : 1.0
' Last Modified : Friday, July 2, 2004
'====================================================================
Public Class clsSucursalAdministrarFormatoDatoPoliticaPos
    Inherits System.Web.UI.Page

    ' Variables locales privadas
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private intmFlagBorrado As Integer

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
    ' Name       : intTipoDatoPoliticaPosId
    ' Description: Obtiene el valor del campo "txtTipoDatoPoliticaPosNombre"
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intTipoDatoPoliticaPosId() As Integer
        Get
            Return CInt(isocraft.commons.clsWeb.strGetPageParameter("intTipoDatoPoliticaPosId", "0"))
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
    ' Name       : intFlagBorrado
    ' Description: Indica si se pudo borrar o no un formato
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intFlagBorrado() As Integer
        Get
            Return intmFlagBorrado
        End Get
        Set(ByVal intValue As Integer)
            intmFlagBorrado = intValue
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
        Const strRecordBrowserName As String = "SucursalAdministrarFormatoDatoPoliticaPos"

        ' Declaramos e inicialziamos las variables locales
        Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1"))
        Dim astrDataArray As Array = Benavides.CC.Data.clstblTipoDatoPoliticaPos.strBuscar(0, "", "", 0, 0, Now(), "", Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

        ' Regresamos el resultado
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?")
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Variable para almacenar los resultados
        Dim intResultado As Integer

        ' Ejecutamos el comando indicado
        Select Case strCmd
            Case "Agregar"
                Call Response.Redirect("SucursalAgregarFormatoDatoPoliticaPos.aspx?strCmd=Crear")

            Case "Editar"
                Call Response.Redirect("SucursalAgregarFormatoDatoPoliticaPos.aspx?strCmd=Editar&intTipoDatoPoliticaPosId=" + intTipoDatoPoliticaPosId.ToString)

            Case "Borrar"
                ' Consultamos la politica que se quiere borrar
                Dim astrDataArray As Array = Benavides.CC.Data.clstblPoliticaPosSucursal.strBuscar(intTipoDatoPoliticaPosId, 0, 0, 0, "", Now(), "", 0, 0, strConnectionString)

                ' Verificamos la existencia de valores. Si existe en la tabla tblPoliticaPosSucursal, no se puede borrar, porque está en uso.
                If IsArray(astrDataArray) AndAlso astrDataArray.Length > 0 Then

                    intFlagBorrado = 0

                Else

                    intResultado = Benavides.CC.Data.clstblTipoDatoPoliticaPos.intEliminar(intTipoDatoPoliticaPosId, "", "", 0, 0, Now(), "", strConnectionString)
                    If intResultado > 0 Then
                        intFlagBorrado = 1
                    Else
                        intFlagBorrado = 2
                    End If

                End If

        End Select

    End Sub

End Class
