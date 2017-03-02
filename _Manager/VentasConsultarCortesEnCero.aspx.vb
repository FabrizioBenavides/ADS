'====================================================================
' Class         : clsVentasConsultarCortesEnCero
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Consultar cortes en cero
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Joaquín Hernández García
' Version       : 1.0
' Last Modified : Thursday, June 24, 2004
'====================================================================
Public Class clsVentasConsultarCortesEnCero
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

    ' Variables privadas
    Private strmFechaInicial As String
    Private strmFechaFinal As String

    '====================================================================
    ' Name       : strFechaInicial
    ' Description: Fecha inicial
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strFechaInicial() As String
        Get
            strmFechaInicial = isocraft.commons.clsWeb.strGetPageParameter("txtFechaInicial", isocraft.commons.clsWeb.strGetPageParameter("strFechaInicial", ""))
            If Len(strmFechaInicial) = 0 Then
                Dim dtmYesterday As Date = DateAdd(DateInterval.Day, -1, Now)
                strmFechaInicial = strComplete2Digit(CStr(Day(dtmYesterday))) & "/" & strComplete2Digit(CStr(Month(dtmYesterday))) & "/" & Year(dtmYesterday)
            Else
                Dim astrData As Array = strmFechaInicial.Split("/"c)
                If astrData.Length = 3 Then
                    strmFechaInicial = strComplete2Digit(CStr(astrData.GetValue(0))) & "/" & strComplete2Digit(CStr(astrData.GetValue(1))) & "/" & CStr(astrData.GetValue(2))
                End If
            End If
            Return strmFechaInicial
        End Get
        Set(ByVal strValue As String)
            strmFechaInicial = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaFinal
    ' Description: Fecha final
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strFechaFinal() As String
        Get
            strmFechaFinal = isocraft.commons.clsWeb.strGetPageParameter("txtFechaFinal", isocraft.commons.clsWeb.strGetPageParameter("strFechaFinal", ""))
            If Len(strmFechaFinal) = 0 Then
                strmFechaFinal = strComplete2Digit(CStr(Day(Now))) & "/" & strComplete2Digit(CStr(Month(Now))) & "/" & Year(Now)
            Else
                Dim astrData As Array = strmFechaFinal.Split("/"c)
                If astrData.Length = 3 Then
                    strmFechaFinal = strComplete2Digit(CStr(astrData.GetValue(0))) & "/" & strComplete2Digit(CStr(astrData.GetValue(1))) & "/" & CStr(astrData.GetValue(2))
                End If
            End If
            Return strmFechaFinal
        End Get
        Set(ByVal strValue As String)
            strmFechaFinal = strValue
        End Set
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
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request)
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

    Private Function strComplete2Digit(ByVal strValue As String) As String
        If Len(strValue) = 1 Then
            Return "0" & strValue
        Else
            Return strValue
        End If
    End Function

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
        Const strRecordBrowserName As String = "VentasConsultarCortesEnCero"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1"))
        Dim astrSucursalesSeleccionadas As Array = Nothing
        Dim astrCompaniaSucursal As Array = Nothing

        ' Almacenamos el comando ejecutado
        If StrComp(isocraft.commons.clsWeb.strGetPageParameter("strCmd", ""), "Consultar") = 0 Then

            ' Obtenemos el rango de fechas
            Dim dtmFechaInicial As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaInicial))
            Dim dtmFechaFinal As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaFinal))

            ' Buscamos las sucursales de esta dirección y zona
            Dim astrDataArray As Array = Benavides.CC.Data.clsCaja.strEjecutarBuscarCortesEnCeroDelGrupo(dtmFechaInicial, dtmFechaFinal, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

            ' Generamos el navegador de registros
            Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?strFechaInicial=" & CStr(dtmFechaInicial) & "&strFechaFinal=" & CStr(dtmFechaFinal) & "&")

        End If

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        Dim strCmd As String = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Ver"

                Call Response.Redirect("VentasCortesEnCeroDetalleDireccion.aspx?intDireccionOperativaId=" & CInt(isocraft.commons.clsWeb.strGetPageParameter("intDireccionOperativaId", "0")) & "&strFechaInicial=" & strFechaInicial & "&strFechaFinal=" & strFechaFinal)

        End Select

    End Sub

End Class
