Imports Isocraft.Web.Http

'====================================================================
' Class         : clsVentasOperacionesDEXDetalleSucursal
' Title         : VentasDetalle de SucursalDex
' Description   : Consulta el detalle de los envíos, pagos y 
'                 devoluciones a nivel sucursal
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Sergio Leal Garza (sergio@isocraft.com)
' Last Modified : Thursday, May 19, 2005
'====================================================================

Public Class clsVentasOperacionesDEXDetalleSucursal
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
        intTipoOperacionDEXId = GetPageParameter("cboOperacion", 0)
        intFechaId = GetPageParameter("optFecha", 0)
        intDireccionOperativaId = GetPageParameter("cboDireccion", 0)
        intZonaOperativaId = GetPageParameter("cboZona", 0)
        intCompaniaId = GetPageParameter("intCompaniaId", 0)
        intSucursalId = GetPageParameter("intSucursalId", 0)
        intPagina = GetPageParameter("intPagina", 0)

        ' Obtenemos los datos de la sucursal
        Dim aobjData As System.Array = Benavides.CC.Data.clsOperacionDEX.aobjBuscarDetalleSucursal(intCompaniaId, intSucursalId, strConnectionString)

        ' Si existen atributos
        If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

            ' Obtenemos sus campos
            strDireccionOperativaNombre = CStr(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("strDireccionOperativaNombre"))
            strZonaOperativaNombre = CStr(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("strZonaOperativaNombre"))
            strSucursalNombre = CStr(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("strSucursalNombre"))

        End If


    End Sub

#End Region

#Region " Class Private Attributes"

    Private intmTipoOperacionDEXId As Integer
    Private intmFechaId As Integer
    Private intmDireccionOperativaId As Integer
    Private intmZonaOperativaId As Integer
    Private intmCompaniaId As Integer
    Private intmSucursalId As Integer
    Private strmDireccionOperativaNombre As String
    Private strmZonaOperativaNombre As String
    Private strmSucursalNombre As String
    Private strmJavascriptWindowOnLoadCommands As String
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
    ' Name       : intFechaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intFechaId() As Integer
        Get
            Return intmFechaId
        End Get
        Set(ByVal intValue As Integer)
            intmFechaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intDireccionOperativaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intDireccionOperativaId() As Integer
        Get
            Return intmDireccionOperativaId
        End Get
        Set(ByVal intValue As Integer)
            intmDireccionOperativaId = intValue
        End Set
    End Property
    '====================================================================
    ' Name       : intTipoOperacionDEXId
    ' Description: Identificador del tipo de Cuenta
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intTipoOperacionDEXId() As Integer
        Get
            Return intmTipoOperacionDEXId
        End Get
        Set(ByVal intValue As Integer)
            intmTipoOperacionDEXId = intValue
        End Set
    End Property
    '====================================================================
    ' Name       : intZonaOperativaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intZonaOperativaId() As Integer
        Get
            Return intmZonaOperativaId
        End Get
        Set(ByVal intValue As Integer)
            intmZonaOperativaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intmCompaniaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intCompaniaId() As Integer
        Get
            Return intmCompaniaId
        End Get
        Set(ByVal intValue As Integer)
            intmCompaniaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intmSucursalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intSucursalId() As Integer
        Get
            Return intmSucursalId
        End Get
        Set(ByVal intValue As Integer)
            intmSucursalId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strDireccionOperativaNombre
    ' Description: Nombre de la Direccion
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property strDireccionOperativaNombre() As String
        Get
            Return strmDireccionOperativaNombre
        End Get
        Set(ByVal strValue As String)
            strmDireccionOperativaNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strZonaOperativaNombre
    ' Description: Nombre de la Zona
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property strZonaOperativaNombre() As String
        Get
            Return strmZonaOperativaNombre
        End Get
        Set(ByVal strValue As String)
            strmZonaOperativaNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strSucursalNombre
    ' Description: Nombre de la Zona
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '==================================================================== 
    Public Property strSucursalNombre() As String
        Get
            Return strmSucursalNombre
        End Get
        Set(ByVal strValue As String)
            strmSucursalNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intPagina
    ' Description: Numero de Pagina del Navegador de Registros Anterior
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '==================================================================== 
    Public Property intPagina() As Integer
        Get
            Return intmPagina
        End Get
        Set(ByVal intValue As Integer)
            intmPagina = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strObtenerSucursalesPorZonaElegida
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strObtenerOperacionesPorSucursalElegida() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 50
        Const strRecordBrowserName As String = "VentasOperacionesDEXDetalleSucursal"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim astrDataArray As Array = Benavides.CC.Data.clsOperacionDEX.aobjBuscarOperacionesDeSucursal(intTipoOperacionDEXId, intFechaId, intCompaniaId, intSucursalId, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)
        Dim astrDataRow As Array

        ' Generamos el URL destino de las páginas

        Dim strTargetURL As String = strThisPageName & _
                                     "?optFechaId=" & intFechaId & _
                                     "&cboOperacion=" & intTipoOperacionDEXId & _
                                     "&cboDireccion=" & intDireccionOperativaId & _
                                     "&cboZona=" & intZonaOperativaId & _
                                     "&intCompaniaId=" & intCompaniaId & _
                                     "&intSucursalId=" & intSucursalId & _
                                     "&intPagina=" & GetPageParameter("intNavegadorRegistrosPagina", 1) & _
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
        Dim astrDataArray As Array = Benavides.CC.Data.clsOperacionDEX.aobjBuscarOperacionesDeSucursal(intTipoOperacionDEXId, intFechaId, intCompaniaId, intSucursalId, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)
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

        ' Validamos las precondiciones necesarias para acceder a esta página
        If intCompaniaId = 0 OrElse intSucursalId = 0 Then
            Call Response.Redirect("VentasOperacionesDEX.aspx")
        End If


        ' Execute the selected command

        Select Case strCmd

            Case "Exportar"

                ' Establecemos en la respuesta los parámetros de configuración del archivo
                Response.ContentType = "application/octet-stream"
                Call Response.AddHeader("Content-Disposition", "attachment; filename=""OperacionesDEXDeSucursal.csv""")
                Call Response.Write(strGetCSVData())
                Call Response.End()

        End Select

    End Sub

End Class
