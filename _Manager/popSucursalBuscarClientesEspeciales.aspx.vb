Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert

'====================================================================
' Class         : clspopSucursalBuscarClientesEspeciales
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Joaquín Hdz. G. (joaquin@isocraft.com)
' Last Modified : Thursday, January 13, 2005
'====================================================================

Public Class clsPopSucursalBuscarClientesEspeciales
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

        ' Initialize class properties
        intClienteEspecialId = GetPageParameter("cboClienteEspecial", 0)
        strTargetFieldOne = GetPageParameter("strTargetFieldOne", GetPageParameter("txtTargetFieldOne", ""))
        strTargetFieldTwo = GetPageParameter("strTargetFieldTwo", GetPageParameter("txtTargetFieldTwo", ""))
        strTargetFieldThree = GetPageParameter("strTargetFieldThree", GetPageParameter("txtTargetFieldThree", ""))
        strTargetFieldFour = GetPageParameter("strTargetFieldFour", GetPageParameter("txtTargetFieldFour", ""))
        strSourceValue = GetPageParameter("strSourceValue", GetPageParameter("txtSourceValue", ""))
    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private intmClienteEspecialId As Integer
    Private strmTargetFieldOne As String
    Private strmTargetFieldTwo As String
    Private strmTargetFieldThree As String
    Private strmTargetFieldFour As String
    Private strmSourceValue As String

#End Region

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
    ' Name       : intClienteEspecialId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intClienteEspecialId() As Integer
        Get
            Return intmClienteEspecialId
        End Get
        Set(ByVal intValue As Integer)
            intmClienteEspecialId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTargetFieldOne
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTargetFieldOne() As String
        Get
            Return strmTargetFieldOne
        End Get
        Set(ByVal strValue As String)
            strmTargetFieldOne = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTargetFieldTwo
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTargetFieldTwo() As String
        Get
            Return strmTargetFieldTwo
        End Get
        Set(ByVal strValue As String)
            strmTargetFieldTwo = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTargetFieldThree
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTargetFieldThree() As String
        Get
            Return strmTargetFieldThree
        End Get
        Set(ByVal strValue As String)
            strmTargetFieldThree = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTargetFieldFour
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strTargetFieldFour() As String
        Get
            Return strmTargetFieldFour
        End Get
        Set(ByVal strValue As String)
            strmTargetFieldFour = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strSourceValue
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strSourceValue() As String
        Get
            Return strmSourceValue
        End Get
        Set(ByVal strValue As String)
            strmSourceValue = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strLlenarClienteEspecialComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboClienteEspecial"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarClienteEspecialComboBox() As String
        Dim aobjDataFirstQuery As Array = Benavides.CC.Data.clstblClienteEspecial.strBuscar(0, 0, strSourceValue, "", False, 0, Now(), 0, 0, Now(), "", 0, 0, False, False, False, 0, 0, strConnectionString)
        Dim aobjDataSecondQuery As Array = Benavides.CC.Data.clstblClienteEspecial.strBuscar(0, 0, "", strSourceValue, False, 0, Now(), 0, 0, Now(), "", 0, 0, False, False, False, 0, 0, strConnectionString)
        Dim aobjData As System.Collections.ArrayList = New System.Collections.ArrayList

        If IsNothing(aobjDataFirstQuery) = False AndAlso aobjDataFirstQuery.Length > 0 Then
            For Each aobjRecord As System.Collections.SortedList In aobjDataFirstQuery
                Call aobjData.Add(aobjRecord)
            Next
        End If
        If IsNothing(aobjDataSecondQuery) = False AndAlso aobjDataSecondQuery.Length > 0 Then
            For Each aobjRecord As System.Collections.SortedList In aobjDataSecondQuery
                Call aobjData.Add(aobjRecord)
            Next
        End If

        Dim astrColumnToDisplay As String() = {"strClienteEspecialNombreId", "strClienteEspecialNombre"}
        Return CreateJavascriptComboBoxOptions("cboClienteEspecial", CStr(intClienteEspecialId), aobjData.ToArray(), "intClienteEspecialId", astrColumnToDisplay, 0)
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Check if the current user can access this page
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Check que page prerequisites
        If Len(strTargetFieldOne) = 0 OrElse Len(strTargetFieldTwo) = 0 OrElse Len(strSourceValue) = 0 Then
            Call Response.Write("<html>" & vbCrLf)
            Call Response.Write("<head>" & vbCrLf)
            Call Response.Write("<script language=""javascript"">" & vbCrLf)
            Call Response.Write("alert(""Esta página no debe ser ejecutada de manera independiente."");" & vbCrLf)
            Call Response.Write("window.close();" & vbCrLf)
            Call Response.Write("</script>" & vbCrLf)
            Call Response.Write("</head>" & vbCrLf)
            Call Response.Write("</html>" & vbCrLf)
            Call Response.End()
        End If

        ' Execute the selected command
        Select Case strCmd

            Case "Seleccionar"

                ' Recuperamos la información de la suculsal seleccionada
                Dim strClienteEspecialNombre As String
                Dim aobjData As Array = Benavides.CC.Data.clstblClienteEspecial.strBuscar(intClienteEspecialId, 0, "", "", False, 0, Now(), 0, 0, Now(), "", 0, 0, False, False, False, 0, 0, strConnectionString)

                If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then
                    strClienteEspecialNombre = CStr(ConvertObject(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("strClienteEspecialNombreId"), TypeCode.String)) & "&nbsp;" & CStr(ConvertObject(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("strClienteEspecialNombre"), TypeCode.String))
                End If

                ' Regresamos a la página padre mostrando las nuevas sucursales
                Call Response.Write("<html>" & vbCrLf)
                Call Response.Write("<head>" & vbCrLf)
                Call Response.Write("<script language=""javascript"">" & vbCrLf)
                Call Response.Write("window.opener.document.forms[0].elements[""" & strTargetFieldOne & """].value = """ & intClienteEspecialId & """ ;" & vbCrLf)
                Call Response.Write("window.opener.document.all." & strTargetFieldTwo & ".innerHTML = """ & ConvertToJavascriptString(strClienteEspecialNombre) & """ ;" & vbCrLf)
                Call Response.Write("window.opener.document.forms[0].elements[""" & strTargetFieldThree & """].value = """" ;" & vbCrLf)
                Call Response.Write("window.opener.document.forms[0].elements[""" & strTargetFieldFour & """].value = """ & ConvertToJavascriptString(strClienteEspecialNombre) & """ ;" & vbCrLf)
                Call Response.Write("window.opener.document.forms[0].submit();" & vbCrLf)
                Call Response.Write("window.close();" & vbCrLf)
                Call Response.Write("</script>" & vbCrLf)
                Call Response.Write("</head>" & vbCrLf)
                Call Response.Write("</html>" & vbCrLf)
                Call Response.End()

        End Select

    End Sub

End Class
