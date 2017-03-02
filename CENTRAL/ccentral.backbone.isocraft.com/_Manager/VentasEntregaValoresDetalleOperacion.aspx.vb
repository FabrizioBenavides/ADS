Imports Isocraft.Web.Http

'====================================================================
' Class         : clsVentasEntregaValoresDetalleOperacion
' Title         : VentasDetalleDeOperacionVal
' Description   : Consulta el detalle de las operaciones
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Juan Colunga (juan@isocraft.com)
' Last Modified : Friday, April 22, 2005
'====================================================================

Public Class clsVentasEntregaValoresDetalleOperacion
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

        intCompaniaId = GetPageParameter("intCompaniaId", 0)
        intSucursalId = GetPageParameter("intSucursalId", 0)
        intEmpresaValoresId = GetPageParameter("intEmpresaValoresId", 0)
        intOperacionEntregaValoresId = GetPageParameter("intOperacionEntregaValoresId", 0)
        intConceptoEntregaValoresId = GetPageParameter("intConceptoEntregaValoresId", 0)
        intEmpleadoId = GetPageParameter("intEmpleadoId", 0)
        intEntregaValoresId = GetPageParameter("intEntregaValoresId", 0)
        intcboOperacion = GetPageParameter("cboOperacion", 0)
        intcboRecolectora = GetPageParameter("cboRecolectora", 0)

        strFechaInicial = isocraft.commons.clsWeb.strGetPageParameter("txtFechaInicial", "01/01/1900")
        strFechaFinal = isocraft.commons.clsWeb.strGetPageParameter("txtFechaFinal", "01/01/1900")

        intcboDireccion = GetPageParameter("cboDireccion", 0)
        intcboZona = GetPageParameter("cboZona", 0)
        intNavegadorRegistrosPaginaDetalleSucursal = GetPageParameter("intNavegadorRegistrosPaginaDetalleSucursal", 1)
        intNavegadorRegistrosPaginaEntregaValores = GetPageParameter("intNavegadorRegistrosPaginaEntregaValores", 1)

    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private intmCompaniaId As Integer
    Private intmSucursalId As Integer
    Private intmcboOperacion As Integer
    Private intmcboRecolectora As Integer

    Private strmFechaInicial As String
    Private strmFechaFinal As String

    Private intmcboDireccion As Integer
    Private intmcboZona As Integer
    Private intmEmpresaValoresId As Integer
    Private intmOperacionEntregaValoresId As Integer
    Private intmConceptoEntregaValoresId As Integer
    Private intmEmpleadoId As Integer
    Private intmEntregaValoresId As Integer
    Private intmNavegadorRegistrosPaginaDetalleSucursal As Integer
    Private intmNavegadorRegistrosPaginaEntregaValores As Integer

    Private strmDireccionOperativaNombre As String
    Private strmZonaOperativaNombre As String
    Private strmSucursalNombre As String
    Private strmFecha As String
    Private strmHora As String
    Private strmOperacionEntregaValoresNombre As String
    Private strmConceptoEntregaValoresNombre As String
    Private strmEntregaValoresFolioRemision As String
    Private strmEmpleadoNombre As String
    Private strmEntregaValoresFolioBolsa As String
    Private strmEmpresaValoresNombre As String
    Private strmEntregaValoresImporteMonedaNacional As String
    Private strmEntregaValoresImporteDolares As String
    Private strmEntregaValoresImporteDocumentos As String

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
    ' Name       : intCompaniaId
    ' Description: Identificador de la Compañia
    ' Accessor   : Read, write
    ' Throws     : None
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
    ' Name       : intSucursalId
    ' Description: Identificador de la Sucursal
    ' Accessor   : Read, write
    ' Throws     : None
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
    ' Name       : intEmpleadoId
    ' Description: Identificador de la Entrega de valores
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intEmpleadoId() As Integer
        Get
            Return intmEmpleadoId
        End Get
        Set(ByVal intValue As Integer)
            intmEmpleadoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intConceptoEntregaValoresId
    ' Description: Identificador de la Entrega de valores
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intConceptoEntregaValoresId() As Integer
        Get
            Return intmConceptoEntregaValoresId
        End Get
        Set(ByVal intValue As Integer)
            intmConceptoEntregaValoresId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intcboZona
    ' Description: Identificador de la Entrega de valores
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intcboZona() As Integer
        Get
            Return intmcboZona
        End Get
        Set(ByVal intValue As Integer)
            intmcboZona = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intcboDireccion
    ' Description: Identificador de la Entrega de valores
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intcboDireccion() As Integer
        Get
            Return intmcboDireccion
        End Get
        Set(ByVal intValue As Integer)
            intmcboDireccion = intValue
        End Set
    End Property


    '====================================================================
    ' Name       : strFechaInicial
    ' Description: 
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strFechaInicial() As String
        Get
            Return strmFechaInicial
        End Get
        Set(ByVal intValue As String)
            strmFechaInicial = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaFinal
    ' Description: 
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strFechaFinal() As String
        Get
            Return strmFechaFinal
        End Get
        Set(ByVal intValue As String)
            strmFechaFinal = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intcboRecolectora
    ' Description: Identificador de la Entrega de valores
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intcboRecolectora() As Integer
        Get
            Return intmcboRecolectora
        End Get
        Set(ByVal intValue As Integer)
            intmcboRecolectora = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intcboOperacion
    ' Description: Identificador de la Entrega de valores
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intcboOperacion() As Integer
        Get
            Return intmcboOperacion
        End Get
        Set(ByVal intValue As Integer)
            intmcboOperacion = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intNavegadorRegistrosPaginaDetalleSucursal
    ' Description: Numero de Pagina del Record Browser
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intNavegadorRegistrosPaginaEntregaValores() As Integer
        Get
            Return intmNavegadorRegistrosPaginaEntregaValores
        End Get
        Set(ByVal intValue As Integer)
            intmNavegadorRegistrosPaginaEntregaValores = intValue
        End Set
    End Property


    '====================================================================
    ' Name       : intNavegadorRegistrosPaginaDetalleSucursal
    ' Description: Numero de Pagina del Record Browser
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intNavegadorRegistrosPaginaDetalleSucursal() As Integer
        Get
            Return intmNavegadorRegistrosPaginaDetalleSucursal
        End Get
        Set(ByVal intValue As Integer)
            intmNavegadorRegistrosPaginaDetalleSucursal = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intEntregaValoresId
    ' Description: Identificador de la Entrega de valores
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intEntregaValoresId() As Integer
        Get
            Return intmEntregaValoresId
        End Get
        Set(ByVal intValue As Integer)
            intmEntregaValoresId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intOperacionEntregaValoresId
    ' Description: Identificador de la Operacion de entrega de valores
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intOperacionEntregaValoresId() As Integer
        Get
            Return intmOperacionEntregaValoresId
        End Get
        Set(ByVal intValue As Integer)
            intmOperacionEntregaValoresId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intEmpresaValoresId
    ' Description: Identificador de la Empresa de valores
    ' Accessor   : Read, write
    ' Throws     : None
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
    ' Name       : strFecha
    ' Description: Fecha de la operacion
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strFecha() As String
        Get
            Return strmFecha
        End Get
        Set(ByVal strValue As String)
            strmFecha = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strHora
    ' Description: Hora de la operacion
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strHora() As String
        Get
            Return strmHora
        End Get
        Set(ByVal strValue As String)
            strmHora = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strOperacionEntregaValoresNombre
    ' Description: Nombre de la operacion
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property strOperacionEntregaValoresNombre() As String
        Get
            Return strmOperacionEntregaValoresNombre
        End Get
        Set(ByVal intValue As String)
            strmOperacionEntregaValoresNombre = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpleadoNombre
    ' Description: Nombre del responsable de la operacion
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property strEmpleadoNombre() As String
        Get
            Return strmEmpleadoNombre
        End Get
        Set(ByVal strValue As String)
            strmEmpleadoNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strConceptoEntregaValoresNombre
    ' Description: Nombre de la Zona
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property strConceptoEntregaValoresNombre() As String
        Get
            Return strmConceptoEntregaValoresNombre
        End Get
        Set(ByVal strValue As String)
            strmConceptoEntregaValoresNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEntregaValoresFolioRemision
    ' Description: Nombre de la Zona
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property strEntregaValoresFolioRemision() As String
        Get
            Return strmEntregaValoresFolioRemision
        End Get
        Set(ByVal strValue As String)
            strmEntregaValoresFolioRemision = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEntregaValoresFolioBolsa
    ' Description: Nombre de la Direccion
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property strEntregaValoresFolioBolsa() As String
        Get
            Return strmEntregaValoresFolioBolsa
        End Get
        Set(ByVal strValue As String)
            strmEntregaValoresFolioBolsa = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpresaValoresNombre
    ' Description: Nombre de la Zona
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property strEmpresaValoresNombre() As String
        Get
            Return strmEmpresaValoresNombre
        End Get
        Set(ByVal strValue As String)
            strmEmpresaValoresNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEntregaValoresImporteMonedaNacional
    ' Description: Nombre de la Zona
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strEntregaValoresImporteMonedaNacional() As String
        Get
            Return strmEntregaValoresImporteMonedaNacional
        End Get
        Set(ByVal strValue As String)
            strmEntregaValoresImporteMonedaNacional = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEntregaValoresImporteDolares
    ' Description: Nombre de la Zona
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strEntregaValoresImporteDolares() As String
        Get
            Return strmEntregaValoresImporteDolares
        End Get
        Set(ByVal strValue As String)
            strmEntregaValoresImporteDolares = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEntregaValoresImporteDocumentos
    ' Description: Nombre de la Zona
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strEntregaValoresImporteDocumentos() As String
        Get
            Return strmEntregaValoresImporteDocumentos
        End Get
        Set(ByVal strValue As String)
            strmEntregaValoresImporteDocumentos = strValue
        End Set
    End Property

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
        Dim astrDataArray As Array = Benavides.CC.Data.clsEntregaValores.aobjBuscarDetalleDeEntrega(intCompaniaId, intSucursalId, intEmpresaValoresId, intOperacionEntregaValoresId, intConceptoEntregaValoresId, intEmpleadoId, intEntregaValoresId, strConnectionString)
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
        If intCompaniaId = 0 OrElse intSucursalId = 0 OrElse intEmpresaValoresId = 0 OrElse intOperacionEntregaValoresId = 0 OrElse intConceptoEntregaValoresId = 0 OrElse intEmpleadoId = 0 OrElse intEntregaValoresId = 0 Then
            Call Response.Redirect("VentasEntregaValoresDetalleSucursal.aspx")
        End If

        ' Execute the selected command
        Select Case strCmd

            Case "Ver"

                ' Obtenemos los datos de la sucursal
                Dim aobjData As System.Array = Benavides.CC.Data.clsEntregaValores.aobjBuscarDetalleDeEntrega(intCompaniaId, intSucursalId, intEmpresaValoresId, intOperacionEntregaValoresId, intConceptoEntregaValoresId, intEmpleadoId, intEntregaValoresId, strConnectionString)

                ' Si existen atributos
                If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                    ' Obtenemos sus campos
                    strDireccionOperativaNombre = CStr(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("strDireccionOperativaNombre"))
                    strZonaOperativaNombre = CStr(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("strZonaOperativaNombre"))
                    strSucursalNombre = CStr(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("strSucursalNombre"))
                    strFecha = CStr(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("dtmFecha"))
                    strHora = CStr(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("dtmHora"))
                    strOperacionEntregaValoresNombre = CStr(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("strOperacionEntregaValoresNombre"))
                    strConceptoEntregaValoresNombre = CStr(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("strConceptoEntregaValoresNombre"))
                    strEntregaValoresFolioRemision = CStr(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("strEntregaValoresFolioRemision"))
                    strEmpleadoNombre = CStr(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("strEmpleadoNombre"))
                    strEntregaValoresFolioBolsa = CStr(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("strEntregaValoresFolioBolsa"))
                    strEmpresaValoresNombre = CStr(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("strEmpresaValoresNombre"))
                    strEntregaValoresImporteMonedaNacional = FormatCurrency(CStr(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("fltEntregaValoresImporteMonedaNacional")), 2, TriState.False, TriState.False, TriState.True)
                    strEntregaValoresImporteDolares = FormatCurrency(CStr(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("fltEntregaValoresImporteDolares")), 2, TriState.False, TriState.False, TriState.True)
                    strEntregaValoresImporteDocumentos = FormatCurrency(CStr(DirectCast(aobjData.GetValue(0), System.Collections.SortedList).Item("fltEntregaValoresImporteDocumentos")), 2, TriState.False, TriState.False, TriState.True)

                End If

            Case "Exportar"

                ' Establecemos en la respuesta los parámetros de configuración del archivo
                Response.ContentType = "application/octet-stream"
                Call Response.AddHeader("Content-Disposition", "attachment; filename=""EntregasValoresDetalleOperacion.csv""")
                Call Response.Write(strGetCSVData())
                Call Response.End()

        End Select

    End Sub

End Class
