Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

'====================================================================
' Class         : clsSistemaEmpresasRecolectorasAsignarRecolectoras
' Title         : SistemaEmpresasRecolectorasAsignarRecolectoras
' Description   : Realiza asignaciones de empresas recolectoras a 
'                 las sucursales
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Juan Colunga (juan@isocraft.com)
' Last Modified : Friday, April 22, 2005
'====================================================================

Public Class clsSistemaEmpresasRecolectorasAsignarRecolectoras
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
        intEmpresaValoresId = GetPageParameter("cboRecolectora", GetPageParameter("intEmpresaValoresId", 0))
        intDireccionOperativaId = GetPageParameter("cboDireccion", GetPageParameter("intDireccionOperativaId", 0))
        intZonaOperativaId = GetPageParameter("cboZona", GetPageParameter("intZonaOperativaId", 0))

    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private intmcboDireccion As Integer
    Private intmcboZona As Integer
    Private intmRecolectoraId As Integer

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
    ' Name       : intDireccionOperativaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intDireccionOperativaId() As Integer
        Get
            Return intmcboDireccion
        End Get
        Set(ByVal intValue As Integer)
            intmcboDireccion = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intZonaOperativaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intZonaOperativaId() As Integer
        Get
            Return intmcboZona
        End Get
        Set(ByVal intValue As Integer)
            intmcboZona = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intEmpresaValoersId
    ' Description: Identificador del tipo de Cuenta
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intEmpresaValoresId() As Integer
        Get
            Return intmRecolectoraId
        End Get
        Set(ByVal intValue As Integer)
            intmRecolectoraId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strLlenarDireccionComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboDireccion"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarDireccionComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccion", intDireccionOperativaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString), 0, 1, 1)
    End Function

    '====================================================================
    ' Name       : strLlenarZonaComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboZona"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarZonaComboBox() As String
        If intDireccionOperativaId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZona", intZonaOperativaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionOperativaId, 0, strConnectionString), 0, 1, 1)
        End If
    End Function

    '====================================================================
    ' Name       : strLlenarRecolectoraComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboOperacion"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarRecolectoraComboBox() As String
        Dim objData As Array = Benavides.CC.Data.clstblEmpresaValores.strBuscar(0, "", #1/1/2000#, "", "", True, #1/1/2000#, "", 0, 0, strConnectionString)
        Dim strNombreEmpresaValores As String = ""
        If IsNothing(objData) = False AndAlso objData.Length > 0 Then
            For Each objRecord As System.Collections.SortedList In objData
                strNombreEmpresaValores = CStr(objRecord.Item("strEmpresaValoresNombre")) & CStr(objRecord.Item("blnEmpresaValoresActiva")).Replace("False", " (inactiva)").Replace("True", "")
                objRecord.Item("strEmpresaValoresNombre") = strNombreEmpresaValores
            Next
        End If
        Return CreateJavascriptComboBoxOptions("cboRecolectora", CStr(intEmpresaValoresId), objData, "intEmpresaValoresId", "strEmpresaValoresNombre", 1)
    End Function

    '====================================================================
    ' Name       : strObtenerSucursalesPorZonaElegida
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strObtenerSucursalesPorZonaElegida() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 50
        Const strRecordBrowserName As String = "SistemaEmpresasRecolectorasAsignarRecolectoras"

        ' Declaramos e inicializamos las variables locales
        Dim astrDataArray As Array
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        If intEmpresaValoresId > 0 Or intDireccionOperativaId > 0 Or intZonaOperativaId > 0 Then
            astrDataArray = Benavides.CC.Data.clsEmpresaValores.aobjBuscarSucursales(intEmpresaValoresId, intDireccionOperativaId, intZonaOperativaId, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)
        End If
        Dim astrDataRow As Array

        ' Generamos el URL destino de las páginas
        Dim strTargetURL As String = strThisPageName & _
                                    "?intEmpresaValoresId=" & intEmpresaValoresId & _
                                    "&intDireccionOperativaId=" & intDireccionOperativaId & _
                                    "&intZonaOperativaId=" & intZonaOperativaId & _
                                    "&"

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strTargetURL)

    End Function

    '====================================================================
    ' Name       : strGetCSVData
    ' Description: Regresa el contenido CSV de la consulta
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetCSVData() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 50

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim astrDataArray As Array = Benavides.CC.Data.clsEmpresaValores.aobjBuscarSucursales(intEmpresaValoresId, intDireccionOperativaId, intZonaOperativaId, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)
        Dim astrCSVData As System.Text.StringBuilder = New System.Text.StringBuilder

        ' Si encontramos información
        If IsNothing(astrDataArray) = False AndAlso astrDataArray.Length > 0 Then

            Dim blnPrintedHeaders As Boolean

            ' Por cada renglón existente
            For Each objRow As System.Collections.SortedList In astrDataArray

                If blnPrintedHeaders = False Then

                    ' Por cada columna existente
                    For intCounter As Integer = 0 To objRow.Count - 1

                        ' Agregamos el encabezado
                        Call astrCSVData.Append(objRow.GetKey(intCounter))
                        Call astrCSVData.Append(",")

                    Next

                    ' Agregamos el separador de línea
                    Call astrCSVData.Append(vbCrLf)
                    blnPrintedHeaders = True

                End If

                ' Por cada columna existente
                For intCounter As Integer = 0 To objRow.Count - 1

                    ' Agregamos la columna
                    Call astrCSVData.Append(objRow.GetByIndex(intCounter))
                    Call astrCSVData.Append(",")

                Next

                ' Agregamos el separador de línea
                Call astrCSVData.Append(vbCrLf)

            Next

        End If

        Return astrCSVData.ToString()

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Execute the selected command
        Select Case strCmd

            Case "Exportar"

                ' Establecemos en la respuesta los parámetros de configuración del archivo
                Response.ContentType = "application/octet-stream"
                Call Response.AddHeader("Content-Disposition", "attachment; filename=""SucursalesAsignadasAEmpresasDeValores.csv""")
                Call Response.Write(strGetCSVData())
                Call Response.End()

        End Select

    End Sub

End Class