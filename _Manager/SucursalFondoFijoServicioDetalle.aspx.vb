Imports Isocraft.Web.Http

Public Class SucursalFondoFijoServicioDetalle

    Inherits System.Web.UI.Page

#Region "Private variables"

    Private fltmFondoTotalImporte As Double
    Private intmAnio As Integer
    Private intmCompaniaId As Integer
    Private intmDireccionId As Integer
    Private intmFondoFijoPresupuestadoId As Integer
    Private intmMes As Integer
    Private intmSucursalId As Integer
    Private intmZonaId As Integer
    Private strmCommand As String = String.Empty
    Private strmHtml As String

#End Region

#Region " Web Form Designer Generated Code "

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, _
                              ByVal e As System.EventArgs) _
                Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()

            ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página 
            If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then

                Call Response.Redirect("../Default.aspx")

            End If

            ' Get the page parameters
            intmDireccionId = GetPageParameter("intDireccionId", 0)
            intmZonaId = GetPageParameter("intZonaId", 0)
            intmMes = GetPageParameter("intMes", 0)
            intmAnio = GetPageParameter("intAnio", 0)
            intmCompaniaId = GetPageParameter("intCompaniaId", 0)
            intmSucursalId = GetPageParameter("intSucursalId", 0)
            intmFondoFijoPresupuestadoId = GetPageParameter("intFondoFijoPresupuestadoId", 0)
            strmCommand = GetPageParameter("strCmd", "")
        'fltmFondoFijoPresupuestadoImporteAdicional = GetPageParameter("txtMontoExtra", 0.0#)

        End Sub

#End Region


    ''' <summary>
        '''     Regresa el año seleccionado
        ''' </summary>
        ''' <value>
        '''     <para>
        '''         
        '''     </para>
        ''' </value>
        ''' <remarks>
        '''     
        ''' </remarks>
        Protected ReadOnly Property intAnio() As Integer

            Get

                Return intmAnio

            End Get

        End Property

        ''' <summary>
        '''     Regresa el identificador de la compañía.
        ''' </summary>
        ''' <value>
        '''     <para>
        '''         
        '''     </para>
        ''' </value>
        ''' <remarks>
        '''     
        ''' </remarks>
        Protected ReadOnly Property intCompaniaId() As Integer

            Get

                Return intmCompaniaId

            End Get

        End Property

        '====================================================================
        ' Name       : intDireccionId
        ' Description: Identificador de la Dirección
        ' Accessor   : Read
        ' Throws     : None
        ' Output     : Integer
        '====================================================================
        Protected ReadOnly Property intDireccionId() As Integer

            Get

                Return intmDireccionId

            End Get

        End Property

        ''' <summary>
        '''     Regresa el identificador del fondo fijo presupuestado
        ''' </summary>
        ''' <value>
        '''     <para>
        '''         
        '''     </para>
        ''' </value>
        ''' <remarks>
        '''     
        ''' </remarks>
        Protected ReadOnly Property intFondoFijoPresupuestadoId() As Integer

            Get

                Return intmFondoFijoPresupuestadoId

            End Get

        End Property

        '====================================================================
        ' Name       : intGrupoUsuarioId
        ' Description: Identificador del Grupo de Usuario
        ' Accessor   : Read
        ' Throws     : Ninguna
        ' Output     : Integer
        '====================================================================
        Protected ReadOnly Property intGrupoUsuarioId() As Integer

            Get

                Return CInt(Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))

            End Get

        End Property

        ''' <summary>
        '''     Regresa el mes del año seleccionado
        ''' </summary>
        ''' <value>
        '''     <para>
        '''         
        '''     </para>
        ''' </value>
        ''' <remarks>
        '''     
        ''' </remarks>
        Protected ReadOnly Property intMes() As Integer

            Get

                Return intmMes

            End Get

        End Property

        ''' <summary>
        '''     Regresa el identificador de la sucursal.
        ''' </summary>
        ''' <value>
        '''     <para>
        '''         
        '''     </para>
        ''' </value>
        ''' <remarks>
        '''     
        ''' </remarks>
        Protected ReadOnly Property intSucursalid() As Integer

            Get

                Return intmSucursalId

            End Get

        End Property

        '====================================================================
        ' Name       : intZonaId
        ' Description: Identificador de la Zona
        ' Accessor   : Read
        ' Throws     : None
        ' Output     : Integer
        '====================================================================
        Protected ReadOnly Property intZonaId() As Integer

            Get

                Return intmZonaId

            End Get

        End Property

        ''' <summary>
        '''     Regresa la fecha de la asignación del fondo fijo
        ''' </summary>
        ''' <value>
        '''     <para>
        '''         
        '''     </para>
        ''' </value>
        ''' <remarks>
        '''     
        ''' </remarks>
        Protected ReadOnly Property strFechaAsignacion() As String

            Get

                Dim returnedValue As String = String.Empty

                If intmMes > 0 AndAlso intmAnio > 0 Then

                    Dim fechaAsignacion As Date = New Date(intmAnio, intmMes, 1)

                    returnedValue = fechaAsignacion.ToString("MMMM", New System.Globalization.CultureInfo("es-MX")) & " del " & intmAnio

                End If

                Return returnedValue

            End Get

        End Property

        ''' <summary>
        '''     Regresa el monto total gastado
        ''' </summary>
        ''' <value>
        '''     <para>
        '''         
        '''     </para>
        ''' </value>
        ''' <remarks>
        '''     
        ''' </remarks>
    Protected ReadOnly Property strTotalImporte() As String

        Get

            Return fltmFondoTotalImporte.ToString("$ ###,###,##0.00")

        End Get

    End Property

    '====================================================================
    ' Name       : strFormAction
    ' Description: HTML form's action property value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Protected ReadOnly Property strFormAction() As String

        Get

            Return strThisPageName

        End Get

    End Property

    ''' <summary>
    '''     Regresa el Html de la lista de gastos
    ''' </summary>
    ''' <value>
    '''     <para>
    '''         
    '''     </para>
    ''' </value>
    ''' <remarks>
    '''     
    ''' </remarks>
    Protected ReadOnly Property strHtml() As String

        Get

            Return strmHtml

        End Get

    End Property

    '====================================================================
    ' Name       : strHTMLFechaHora
    ' Description: Genera la fecha y hora de la página
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Protected ReadOnly Property strHTMLFechaHora() As String

        Get

            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")

        End Get

    End Property

    ''' <summary>
    '''     Regresa el nombre de la sucursal consultada
    ''' </summary>
    ''' <value>
    '''     <para>
    '''         
    '''     </para>
    ''' </value>
    ''' <remarks>
    '''     
    ''' </remarks>
    Protected ReadOnly Property strNombreSucursal() As String

        Get

            Dim returnedValue As String = String.Empty

            If intmCompaniaId > 0 AndAlso intmSucursalId > 0 Then

                Dim sucursales As Array = Benavides.CC.Data.clstblSucursal.strBuscar(intmCompaniaId, intmSucursalId, 0, 0, "", 0, 0, 0, #1/1/2000#, "", "", "", "", 0, 0, strConnectionString)

                If IsArray(sucursales) AndAlso sucursales.Length > 0 Then

                    returnedValue = strNumeroSucursal & " " & StrConv(DirectCast(sucursales.GetValue(0), String())(4).Trim(), VbStrConv.ProperCase)

                End If

            End If

            Return returnedValue

        End Get

    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: Name of this page
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Protected ReadOnly Property strThisPageName() As String

        Get

            Return Server.UrlEncode(GetPageName())

        End Get

    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Protected ReadOnly Property strUsuarioNombre() As String

        Get

            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)

        End Get

    End Property


    '====================================================================
    ' Name       : strGetRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 0
        Const strRecordBrowserName As String = "FondoFijoPagoServiciosSucursal"
        Dim elemento As System.Collections.SortedList
        Dim strTotal As String

        ' Declaramos e inicializamos las variables locales

        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim astrDataArray As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarFondoFijoPagoServiciosSucursal(intCompaniaId, intSucursalid, intAnio, intMes, strConnectionString)

        If IsArray(astrDataArray) And astrDataArray.Length > 0 Then

            elemento = DirectCast(astrDataArray.GetValue(0), System.Collections.SortedList)
            fltmFondoTotalImporte = CDbl(elemento.Item("Total"))

        End If

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?intCompaniaId=" & intCompaniaId & "&intSucursalId=" & intSucursalid & "&intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId & "&intMes=" & intMes & "&intAnio=" & intAnio & "&")

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Load


    End Sub


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

    ''' <summary>
    '''     Regresa el numero de sucursal que será desplegado en pantalla
    ''' </summary>
    ''' <value>
    '''     <para>
    '''         
    '''     </para>
    ''' </value>
    ''' <remarks>
    '''     
    ''' </remarks>
    Private ReadOnly Property strNumeroSucursal() As String

        Get

            Return intmCompaniaId.ToString("00") & intmSucursalId.ToString("0000")

        End Get

    End Property

End Class
