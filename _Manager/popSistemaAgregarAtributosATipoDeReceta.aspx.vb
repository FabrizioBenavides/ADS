Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert

'====================================================================
' Class         : clsSistemaAgregarAtributosATipoDeReceta
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : (c) Isocraft 2004 - 2009. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Joaquín Hdz. G. (joaquin@isocraft.com)
' Last Modified : Wednesday, December 22, 2004
'====================================================================

Public Class clsPopSistemaAgregarAtributosATipoDeReceta
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
        intTipoFormaCapturaId = GetPageParameter("txtTipoFormaCapturaId", GetPageParameter("intTipoFormaCapturaId", 0))
        strAtributos = GetPageParameter("cboAtributos", "")
    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private strmtxtTipoFormaCapturaId As Integer
    Private strmcboAtributo As String

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
    ' Name       : intTipoFormaCapturaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intTipoFormaCapturaId() As Integer
        Get
            Return strmtxtTipoFormaCapturaId
        End Get
        Set(ByVal intValue As Integer)
            strmtxtTipoFormaCapturaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strAtributos
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strAtributos() As String
        Get
            Return strmcboAtributo
        End Get
        Set(ByVal strValue As String)
            strmcboAtributo = strValue
        End Set
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
    ' Name       : strLlenarTipoAtributoComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboTipoAtributo"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarGrupoComboBox() As String
        Dim aobjData As Array = Benavides.CC.Data.clstblAtributo.strBuscar(0, 0, "", "", "", 0, 0, "", "", False, "", Now(), "", True, 0, 0, strConnectionString)
        Const intMaxLenght As Integer = 50
        For Each aobjRow As System.Collections.SortedList In aobjData
            If CBool(aobjRow.Item("blnAtributoActivo")) = False Then
                aobjRow.Item("strAtributoNombre") = CStr(aobjRow.Item("strAtributoNombre")) & " (inactivo)"
            End If
            If Len(CStr(aobjRow.Item("strAtributoDescripcion"))) > intMaxLenght Then
                aobjRow.Item("strAtributoDescripcion") = Left(CStr(aobjRow.Item("strAtributoDescripcion")), intMaxLenght) & "..."
            End If
        Next
        Return CreateJavascriptComboBoxOptions("cboAtributos", "", aobjData, "intAtributoId", "strAtributoDescripcion", 0)
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Check if the current user can access this page
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Execute the selected command
        Select Case strCmd

            Case "Agregar"

                ' Verificamos que se hayan seleccionado atributos
                If Len(strAtributos) > 0 AndAlso intTipoFormaCapturaId > 0 Then

                    ' Obtenemos los atributos seleccionados
                    Dim astrAtributos As Array = strAtributos.Split(","c)

                    ' Por cada atributo existente
                    For Each strAtributoId As String In astrAtributos

                        ' Obtenemos el identificador numérico del atributo
                        Dim intAtributoId As Integer = CInt(ConvertStringToObject(strAtributoId, TypeCode.Int32))

                        ' Si su identificador es válido
                        If intAtributoId > 0 Then

                            ' Agregamos el atributo al tipo de forma de captura
                            Call Benavides.CC.Data.clstblAtributoTipoFormaCaptura.intAgregar(intAtributoId, intTipoFormaCapturaId, Now(), strUsuarioNombre, True, strConnectionString)

                        End If

                    Next

                End If

                ' Cerramos la ventana
                strJavascriptWindowOnLoadCommands &= "  window.opener.location.href = ""SistemaAgregarTipoDeReceta.aspx?strCmd=Editar&intTipoFormaCapturaId=" & intTipoFormaCapturaId & """;" & vbCrLf
                strJavascriptWindowOnLoadCommands &= "  window.close();" & vbCrLf

        End Select

    End Sub

End Class
