'====================================================================
' Class         : clsSistemaAdministrarDiasInhabiles
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Administrar días inhábiles
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Joaquín Hernández García
' Version       : 1.0
' Last Modified : Thursday, June 10, 2004
'====================================================================
Public Class clsSistemaAdministrarDiasInhabiles
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
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 10
        Const strRecordBrowserName As String = "SistemaAdministrarDiasInhabiles"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1"))
        Dim astrDataArray As Array = Benavides.CC.Data.clstblDiaInhabilDeposito.strBuscar(0, Now, Now, "", Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

        ' Si existen datos
        If astrDataArray.Length > 0 Then

            ' Declaramos e inicializamos el nuevo arreglo de datos
            Dim astrExtendedDataArray As System.Collections.ArrayList = New System.Collections.ArrayList
            Dim astrDataRow As Array
            Dim astrMonthNames() As String = New String() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"}

            ' Por cada dato encontrado
            For Each astrDataRow In astrDataArray

                ' Obtenemos los valores existentes y agregamos el día, el mes y el año
                Dim astrExtendedDataRow(6) As String
                Call astrExtendedDataRow.SetValue(astrDataRow.GetValue(0), 0)
                Call astrExtendedDataRow.SetValue(CStr(Day(CDate(astrDataRow.GetValue(1)))), 1)
                Call astrExtendedDataRow.SetValue(astrMonthNames(Month(CDate(astrDataRow.GetValue(1))) - 1), 2)
                Call astrExtendedDataRow.SetValue(CStr(Year(CDate(astrDataRow.GetValue(1)))), 3)
                Call astrExtendedDataRow.SetValue(astrDataRow.GetValue(2), 4)
                Call astrExtendedDataRow.SetValue(astrDataRow.GetValue(3), 5)
                Call astrExtendedDataRow.SetValue(astrDataRow.GetValue(4), 6)
                Call astrExtendedDataArray.Add(astrExtendedDataRow)

            Next

            ' Redefinimos el arreglo de datos
            astrDataArray = astrExtendedDataArray.ToArray()

        End If

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?")

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "SalvarAgregar"

                Dim strDiaInhabil As String = isocraft.commons.clsWeb.strGetPageParameter("txtDiaInhabil", "")

                If Len(strDiaInhabil) > 0 AndAlso IsDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strDiaInhabil)) = True Then
                    Call Benavides.CC.Data.clstblDiaInhabilDeposito.intAgregar(0, CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strDiaInhabil)), Now, strUsuarioNombre, strConnectionString)
                End If

            Case "Borrar"

                Dim intDiaInhabilDepositoId As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intDiaInhabilDepositoId", "0"))
                If intDiaInhabilDepositoId > 0 Then
                    Call Benavides.CC.Data.clstblDiaInhabilDeposito.intEliminar(intDiaInhabilDepositoId, Now, Now, strUsuarioNombre, strConnectionString)
                End If

        End Select

    End Sub

End Class
