Imports Isocraft.Web.Http

'====================================================================
' Class         : clsSistemaRevisarRecetas
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Operaciones de páginas ASP.Net
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Joaquín Hdz. G. (joaquin@isocraft.com)
' Last Modified : Thursday, January 27, 2005
'====================================================================

Public Class clsSistemaRevisarRecetas
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
        strtxtFechaInicial = GetPageParameter("txtFechaInicial", "")
        strtxtFechaFinal = GetPageParameter("txtFechaFinal", "")
        intDireccionId = GetPageParameter("cboDireccion", 0)
        intZonaId = GetPageParameter("cboZona", 0)
        intEstadoFormaCaptura = GetPageParameter("cboEstadoFormaCaptura", 1)
    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private strmtxtFechaInicial As String
    Private strmtxtFechaFinal As String
    Private intmDireccionId As Integer
    Private intmZonaId As Integer
    Private intmEstadoFormaCaptura As Integer

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
    ' Name       : strtxtFechaInicial
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtFechaInicial() As String
        Get
            Return strmtxtFechaInicial
        End Get
        Set(ByVal strValue As String)
            strmtxtFechaInicial = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strtxtFechaFinal
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtFechaFinal() As String
        Get
            Return strmtxtFechaFinal
        End Get
        Set(ByVal strValue As String)
            strmtxtFechaFinal = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intDireccionId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intDireccionId() As Integer
        Get
            Return intmDireccionId
        End Get
        Set(ByVal intValue As Integer)
            intmDireccionId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intZonaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intZonaId() As Integer
        Get
            Return intmZonaId
        End Get
        Set(ByVal intValue As Integer)
            intmZonaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intEstadoFormaCaptura
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intEstadoFormaCaptura() As Integer
        Get
            Return intmEstadoFormaCaptura
        End Get
        Set(ByVal intValue As Integer)
            intmEstadoFormaCaptura = intValue
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
    ' Name       : strLlenarDireccionComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboDireccion"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarDireccionComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccion", intDireccionId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString), 0, 1, 2)
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
        If intDireccionId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZona", intZonaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, 0, strConnectionString), 0, 1, 2)
        End If
    End Function

    '====================================================================
    ' Name       : strGetRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 50
        Const strRecordBrowserName As String = "SistemaRevisarRecetas"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim blnDetalleFormaCapturaValorConError As Boolean = intEstadoFormaCaptura = 1
        Dim dtmDetalleFormaCapturaUltimaModificacionInicio As DateTime = #1/1/2000#
        Dim dtmDetalleFormaCapturaUltimaModificacionFinal As DateTime = #1/1/2000#
        If Len(strtxtFechaInicial) > 0 Then
            dtmDetalleFormaCapturaUltimaModificacionInicio = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strtxtFechaInicial))
        End If
        If Len(strtxtFechaFinal) > 0 Then
            dtmDetalleFormaCapturaUltimaModificacionFinal = DateAdd(DateInterval.Second, 59, DateAdd(DateInterval.Minute, 59, DateAdd(DateInterval.Hour, 23, CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strtxtFechaFinal)))))
        End If
        Dim astrDataArray As Array = Benavides.CC.Data.clsFormaCaptura.strBuscarFormaCaptura(intDireccionId, intZonaId, blnDetalleFormaCapturaValorConError, dtmDetalleFormaCapturaUltimaModificacionInicio, dtmDetalleFormaCapturaUltimaModificacionFinal, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)
        Dim astrDataRow As Array

        ' Generamos el URL destino de las páginas
        Dim strTargetURL As String = strThisPageName & _
                                    "?txtFechaInicial=" & strtxtFechaInicial & _
                                    "&txtFechaFinal=" & strtxtFechaFinal & _
                                    "&cboDireccion=" & intDireccionId & _
                                    "&cboZona=" & intZonaId & _
                                    "&cboEstadoFormaCaptura=" & intEstadoFormaCaptura & _
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
        Dim blnDetalleFormaCapturaValorConError As Boolean = intEstadoFormaCaptura = 1
        Dim dtmDetalleFormaCapturaUltimaModificacionInicio As DateTime = #1/1/2000#
        Dim dtmDetalleFormaCapturaUltimaModificacionFinal As DateTime = #1/1/2000#

        ' Convertimos las fechas la formato mm/dd/yyyy
        If Len(strtxtFechaInicial) > 0 Then
            dtmDetalleFormaCapturaUltimaModificacionInicio = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strtxtFechaInicial))
        End If
        If Len(strtxtFechaFinal) > 0 Then
            dtmDetalleFormaCapturaUltimaModificacionFinal = DateAdd(DateInterval.Second, 59, DateAdd(DateInterval.Minute, 59, DateAdd(DateInterval.Hour, 23, CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strtxtFechaFinal)))))
        End If

        ' Ejecutamos la consulta
        Dim astrDataArray As Array = Benavides.CC.Data.clsFormaCaptura.strBuscarFormaCaptura(intDireccionId, intZonaId, blnDetalleFormaCapturaValorConError, dtmDetalleFormaCapturaUltimaModificacionInicio, dtmDetalleFormaCapturaUltimaModificacionFinal, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)
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

        ' Check if the current user can access this page
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Execute the selected command
        Select Case strCmd

            Case "Editar"

                Dim intTipoFormaCapturaId As Integer = GetPageParameter("intTipoFormaCapturaId", 0)
                Dim intCompaniaId As Integer = GetPageParameter("intCompaniaId", 0)
                Dim intSucursalId As Integer = GetPageParameter("intSucursalId", 0)
                Dim intCajaId As Integer = GetPageParameter("intCajaId", 0)
                Dim intTicketId As Integer = GetPageParameter("intTicketId", 0)
                Dim intClienteEspecialId As Integer = GetPageParameter("intClienteEspecialId", 0)

                ' Obtenemos el detalle de la forma de captura, si los identificadores requeridos son válidos
                If intTipoFormaCapturaId > 0 AndAlso intCompaniaId > 0 AndAlso intSucursalId > 0 AndAlso intCajaId > 0 AndAlso intTicketId > 0 AndAlso intClienteEspecialId > 0 Then
                    Call Response.Redirect("SistemaEditarReceta.aspx?strCmd=Editar&intTipoFormaCapturaId=" & intTipoFormaCapturaId & "&intCompaniaId=" & intCompaniaId & "&intSucursalId=" & intSucursalId & "&intCajaId=" & intCajaId & "&intTicketId=" & intTicketId & "&intClienteEspecialId=" & intClienteEspecialId)
                End If

            Case "Exportar"

                ' Establecemos en la respuesta los parámetros de configuración del archivo
                Response.ContentType = "application/octet-stream"
                Call Response.AddHeader("Content-Disposition", "attachment; filename=""CTXRevisarRecetas.csv""")
                Call Response.Write(strGetCSVData())
                Call Response.End()

        End Select

    End Sub

End Class
