'====================================================================
' Class         : clsSucursalAgregarFormatoDatoPoliticaPos
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Agregar formato de datos de políticas de POS
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Mario C. Menchaca Salgado
' Version       : 1.0
' Last Modified : Wednesday, July 7, 2004
'====================================================================
Public Class clsSucursalAgregarFormatoDatoPoliticaPos
    Inherits System.Web.UI.Page

    ' Variables locales privadas
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private strmNombreFormato As String
    Private strmNombreIdFormato As String
    Private strmLongitudFormato As String
    Private intmTipoDato As Integer

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
    ' Description: Obtiene el valor del campo "txtTipoDatoPoliticaPosId"
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
    ' Name       : strTipoDatoPoliticaPosNombre
    ' Description: Obtiene el valor del campo "txtTipoDatoPoliticaPosNombre"
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTipoDatoPoliticaPosNombre() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("txtTipoDatoPoliticaPosNombre", "")
        End Get
    End Property

    '====================================================================
    ' Name       : strTipoDatoPoliticaPosNombreId
    ' Description: Obtiene el valor del campo "txtTipoDatoPoliticaPosNombreId"
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTipoDatoPoliticaPosNombreId() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("txtTipoDatoPoliticaPosNombreId", "")
        End Get
    End Property

    '====================================================================
    ' Name       : intTipoDatoPoliticaPosLongitud
    ' Description: Obtiene el valor del campo "txtTipoDatoPoliticaPosLongitud"
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intTipoDatoPoliticaPosLongitud() As Integer
        Get
            Return CInt(isocraft.commons.clsWeb.strGetPageParameter("txtTipoDatoPoliticaPosLongitud", "0"))
        End Get
    End Property

    '====================================================================
    ' Name       : IntTipoDatoPoliticaPosTipo
    ' Description: Obtiene el valor del campo "cboTipoDatoPoliticaPosTipo"
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intTipoDatoPoliticaPosTipo() As Integer
        Get
            Return CInt(isocraft.commons.clsWeb.strGetPageParameter("cboTipoDatoPoliticaPosTipo", "0"))
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
    ' Name       : strNombreFormato 
    ' Description: Obtiene o establece el nombre del formato
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strNombreFormato() As String
        Get
            Return strmNombreFormato
        End Get
        Set(ByVal strValue As String)
            strmNombreFormato = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strNombreIdFormato 
    ' Description: Obtiene o establece el identificador interno del formato
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strNombreIdFormato() As String
        Get
            Return strmNombreIdFormato
        End Get
        Set(ByVal strValue As String)
            strmNombreIdFormato = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strLongitudFormato 
    ' Description: Obtiene o establece la longitud del formato
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strLongitudFormato() As String
        Get
            Return strmLongitudFormato
        End Get
        Set(ByVal strValue As String)
            strmLongitudFormato = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intTipoDato 
    ' Description: Obtiene o establece el id del tipo de formato
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intTipoDato() As Integer
        Get
            Return intmTipoDato
        End Get
        Set(ByVal intValue As Integer)
            intmTipoDato = intValue
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Variable para almacenar los resultados
        Dim intResultado As Integer

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Ejecutamos el comando indicado
        Select Case strCmd
            Case "Agregar"
                ' Agregamos el formato
                intResultado = Benavides.CC.Data.clstblTipoDatoPoliticaPos.intAgregar(0, strTipoDatoPoliticaPosNombreId, strTipoDatoPoliticaPosNombre, intTipoDatoPoliticaPosLongitud, intTipoDatoPoliticaPosTipo, Now(), strUsuarioNombre, strConnectionString)
                Call Response.Redirect("SucursalAdministrarFormatoDatoPoliticaPos.aspx")

            Case "Modificar"
                ' Modificamos el formato indicado
                intResultado = Benavides.CC.Data.clstblTipoDatoPoliticaPos.intActualizar(intTipoDatoPoliticaPosId, strTipoDatoPoliticaPosNombreId, strTipoDatoPoliticaPosNombre, intTipoDatoPoliticaPosLongitud, intTipoDatoPoliticaPosTipo, Now(), strUsuarioNombre, strConnectionString)
                Call Response.Redirect("SucursalAdministrarFormatoDatoPoliticaPos.aspx")

            Case "Editar"
                ' Consultamos la politica recibida
                Dim astrDataArray As Array = Benavides.CC.Data.clstblTipoDatoPoliticaPos.strBuscar(intTipoDatoPoliticaPosId, "", "", 0, 0, Now(), "", 0, 0, strConnectionString)

                ' Verificamos la existencia de valores
                If IsArray(astrDataArray) AndAlso astrDataArray.Length > 0 Then

                    ' Obtenemos el nombre del formato
                    strNombreFormato = CStr(DirectCast(astrDataArray.GetValue(0), Array).GetValue(2))

                    ' Obtenemos el identificador del formato
                    strNombreIdFormato = CStr(DirectCast(astrDataArray.GetValue(0), Array).GetValue(1))

                    ' Obtenemos la longitud del formato
                    strLongitudFormato = CStr(DirectCast(astrDataArray.GetValue(0), Array).GetValue(3))

                    ' Obtenemos el tipo del formato
                    intTipoDato = CInt(DirectCast(astrDataArray.GetValue(0), Array).GetValue(4))

                End If

        End Select

    End Sub

End Class
