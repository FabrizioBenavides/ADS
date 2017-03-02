Imports Isocraft.Web.Http

'====================================================================
' Class         : clsSistemaEmpresasRecolectorasEditarEmpresa
' Title         : SistemaEditarEmpresa
' Description   : Agrega una nueva empresa o edita la información 
'                 correspondiente a una empresa
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Sergio Leal Garza (sergio@isocraft.com)
' Last Modified : Friday, April 22, 2005
'====================================================================

Public Class clsSistemaEmpresasRecolectorasEditarEmpresa
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

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Initialize class properties
        strtxtEmpresa = GetPageParameter("txtEmpresa", "")
        strtxtContacto = GetPageParameter("txtContacto", "")
        strtxtTelefono = GetPageParameter("txtTelefono", "")
        blnchkEmpresaHabilitada = GetPageParameter("chkEmpresaHabilitada", False)
        intEmpresaValoresId = GetPageParameter("intEmpresaValoresId", 0)
        dtmEmpresaValoresAlta = GetPageParameter("dtmEmpresaValoresAlta", Now())
        intPagina = GetPageParameter("intPagina", 0)
    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private intmEmpresaValoresId As Integer
    Private strmtxtEmpresa As String
    Private strmtxtContacto As String
    Private strmtxtTelefono As String
    Private blnmchkEmpresaHabilitada As Boolean
    Private dtmmEmpresaValoresAlta As Date
    Private intmPagina As Integer
#End Region

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
    ' Name       : strFormAction
    ' Description: HTML form's action property value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormAction() As String
        Get
            Return strThisPageName
        End Get
    End Property

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Connection string
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Private ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: Name of this page
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return Server.UrlEncode(GetPageName())
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
    ' Name       : strtxtEmpresa
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtEmpresa() As String
        Get
            Return strmtxtEmpresa
        End Get
        Set(ByVal strValue As String)
            strmtxtEmpresa = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strtxtContacto
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtContacto() As String
        Get
            Return strmtxtContacto
        End Get
        Set(ByVal strValue As String)
            strmtxtContacto = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strtxtTelefono
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtTelefono() As String
        Get
            Return strmtxtTelefono
        End Get
        Set(ByVal strValue As String)
            strmtxtTelefono = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnchkEmpresaHabilitada
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property blnchkEmpresaHabilitada() As Boolean
        Get
            Return blnmchkEmpresaHabilitada
        End Get
        Set(ByVal blnValue As Boolean)
            blnmchkEmpresaHabilitada = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : intEmpresaValoresId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intEmpresaValoresId() As Integer
        Get
            Return intmEmpresaValoresId
        End Get
        Set(ByVal intValue As Integer)
            intmEmpresaValoresId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : dtmEmpresaValoresAlta
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property dtmEmpresaValoresAlta() As Date
        Get
            Return dtmmEmpresaValoresAlta
        End Get
        Set(ByVal dtmValue As Date)
            dtmmEmpresaValoresAlta = dtmValue
        End Set
    End Property
    Public Property intPagina() As Integer
        Get
            Return intmPagina
        End Get
        Set(ByVal intValue As Integer)
            intmPagina = intValue
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Execute the selected command
        Select Case strCmd

            Case "Editar"

                If intEmpresaValoresId > 0 Then

                    Dim objData As Array = Benavides.CC.Data.clstblEmpresaValores.strBuscar(intEmpresaValoresId, "", #1/1/2000#, "", "", False, #1/1/2000#, "", 0, 0, strConnectionString)

                    If IsNothing(objData) = False AndAlso objData.Length > 0 Then
                        strtxtEmpresa = CStr(DirectCast(objData.GetValue(0), System.Collections.SortedList).Item("strEmpresaValoresNombre"))
                        strtxtContacto = CStr(DirectCast(objData.GetValue(0), System.Collections.SortedList).Item("strEmpresaValoresContacto"))
                        strtxtTelefono = CStr(DirectCast(objData.GetValue(0), System.Collections.SortedList).Item("strEmpresaValoresTelefono"))
                        blnchkEmpresaHabilitada = CBool(DirectCast(objData.GetValue(0), System.Collections.SortedList).Item("blnEmpresaValoresActiva"))
                        dtmEmpresaValoresAlta = CDate(DirectCast(objData.GetValue(0), System.Collections.SortedList).Item("dtmEmpresaValoresAlta"))
                    End If

                End If

            Case "Agregar"

                If intEmpresaValoresId > 0 Then
                    Call Benavides.CC.Data.clstblEmpresaValores.intActualizar(intEmpresaValoresId, strtxtEmpresa, dtmEmpresaValoresAlta, strtxtContacto, strtxtTelefono, blnchkEmpresaHabilitada, Now(), strUsuarioNombre, strConnectionString)
                Else
                    Call Benavides.CC.Data.clstblEmpresaValores.intAgregar(0, strtxtEmpresa, Now(), strtxtContacto, strtxtTelefono, blnchkEmpresaHabilitada, Now(), strUsuarioNombre, strConnectionString)
                End If

                Call Response.Redirect("SistemaEmpresasRecolectorasAdministrarEmpresasRecolectoras.aspx")

        End Select

    End Sub

End Class
