Imports Isocraft.Web.Http

Public Class SucursalEditarGastosDeSucursal
    Inherits System.Web.UI.Page

#Region "Private variables"

    Private blnmFondoFijoPresupuestadoSePuedeEditar As Boolean = False
    Private fltmFondoFijoPresupuestadoImporteAdicional As Double
    Private fltmFondoFijoPresupuestadoImporteAsignado As Double
    Private fltmFondoFijoPresupuestadoImporteDiarioMaximo As Double
    Private fltmFondoFijoTotalGastadoImporte As Double
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
        fltmFondoFijoPresupuestadoImporteAdicional = GetPageParameter("txtMontoExtra", 0.0#)

    End Sub

#End Region

    ''' <summary> 
    '''     Regresa el indicador de modificación del presupuesto de fondo fijo
    ''' </summary>
    ''' <value>
    '''     <para>
    '''         
    '''     </para>
    ''' </value>
    ''' <remarks>
    '''     
    ''' </remarks>
    Public ReadOnly Property blnFondoFijoPresupuestadoSePuedeEditar() As Boolean

        Get

            Return blnmFondoFijoPresupuestadoSePuedeEditar

        End Get

    End Property

    ''' <summary>
    '''     Regresa el monto adicional al presupuestado
    ''' </summary>
    ''' <value>
    '''     <para>
    '''         
    '''     </para>
    ''' </value>
    ''' <remarks>
    '''     
    ''' </remarks>
    Protected ReadOnly Property fltFondoFijoPresupuestadoImporteAdicional() As Double

        Get

            Return fltmFondoFijoPresupuestadoImporteAdicional

        End Get

    End Property

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

    Protected ReadOnly Property strFondoFijoPresupuestadoImporteAsignado() As String

        Get

            Return fltmFondoFijoPresupuestadoImporteAsignado.ToString("$ ###,###,###.00")

        End Get

    End Property

    ''' <summary>
    '''     Regresa el importe diario máximo que puede gastar una sucursal
    ''' </summary>
    ''' <value>
    '''     <para>
    '''         
    '''     </para>
    ''' </value>
    ''' <remarks>
    '''     
    ''' </remarks>
    Protected ReadOnly Property strFondoFijoPresupuestadoImporteDiarioMaximo() As String

        Get

            Return fltmFondoFijoPresupuestadoImporteDiarioMaximo.ToString("$ ###,###,###.00")

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
    Protected ReadOnly Property strFondoFijoTotalGastadoImporte() As String

        Get

            Return fltmFondoFijoTotalGastadoImporte.ToString("$ ###,###,##0.00")

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

    ''' <summary>
    '''     Obtiene el monto asignado a una sucursal
    ''' </summary>
    Private Sub Editar()

        If intmCompaniaId > 0 AndAlso intmSucursalId > 0 AndAlso intmFondoFijoPresupuestadoId > 0 AndAlso intmDireccionId > 0 AndAlso intmZonaId > 0 AndAlso intmMes > 0 AndAlso intmAnio > 0 Then

            Dim fondoFijoPresupuestado As Array = Benavides.CC.Data.clstblFondoFijoPresupuestado.strBuscar(intmFondoFijoPresupuestadoId, intmCompaniaId, intmSucursalId, 0, 0, 0, 0, #1/1/2000#, #1/1/2000#, #1/1/2000#, "", 0, 0, strConnectionString)

            If IsArray(fondoFijoPresupuestado) AndAlso fondoFijoPresupuestado.Length > 0 Then

                fltmFondoFijoPresupuestadoImporteAsignado = CDbl(DirectCast(fondoFijoPresupuestado.GetValue(0), System.Collections.SortedList).Item("fltFondoFijoPresupuestadoImporteAsignado"))
                fltmFondoFijoPresupuestadoImporteAdicional = CDbl(DirectCast(fondoFijoPresupuestado.GetValue(0), System.Collections.SortedList).Item("fltFondoFijoPresupuestadoImporteAdicional"))
                fltmFondoFijoPresupuestadoImporteDiarioMaximo = CDbl(DirectCast(fondoFijoPresupuestado.GetValue(0), System.Collections.SortedList).Item("fltFondoFijoPresupuestadoImporteDiarioMaximo"))
                blnmFondoFijoPresupuestadoSePuedeEditar = CBool(DirectCast(fondoFijoPresupuestado.GetValue(0), System.Collections.SortedList).Item("blnFondoFijoPresupuestadoSePuedeEditar"))

                Dim fondoFijoGastado As Array = Benavides.CC.Data.clstblFondoFijoGastado.strBuscar(intmFondoFijoPresupuestadoId, intmCompaniaId, intmSucursalId, 0, 0, 0.0#, #1/1/2000#, "", 0, 0, strConnectionString)
                Dim html As System.Text.StringBuilder = New System.Text.StringBuilder

                If IsArray(fondoFijoGastado) AndAlso fondoFijoGastado.Length > 0 Then

                    For Each gasto As System.Collections.SortedList In fondoFijoGastado

                        Dim fltFondoFijoGastadoImporte As Double = CDbl(gasto.Item("fltFondoFijoGastadoImporte"))
                        fltmFondoFijoTotalGastadoImporte += fltFondoFijoGastadoImporte

                        Call html.Append("<tr>")
                        Call html.AppendFormat("<td class=""td_bluefill"">{0}</td>", CDate(gasto.Item("dtmFondoFijoGastadoUltimaModificacion")).ToString("dd/MM/yyyy"))
                        Call html.AppendFormat("<td class=""td_bluefill"">{0}</td>", fltFondoFijoGastadoImporte.ToString("$ ###,###,###.00"))
                        Call html.Append("</tr>")

                    Next

                Else

                    Call html.Append("<tr><td colspan=""2"" class=""txgreybold""><br>&nbsp;No existen datos<br>&nbsp;</td></tr>")

                End If

                strmHtml = html.ToString()

            End If

        End If

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Load

        Select Case strmCommand

            Case "Editar"

                Call Editar()

            Case "Salvar"

                Call Salvar()
                Call Editar()

            Case Else

                Call Response.Redirect("SucursalFondoFijo.aspx")

        End Select

    End Sub

    ''' <summary>
    '''     Salva el monto extra asignado a una sucursal
    ''' </summary>
    Private Sub Salvar()

        ' Si los parámetros necesarios son válidos
        If intmCompaniaId > 0 AndAlso intmSucursalId > 0 AndAlso intmFondoFijoPresupuestadoId > 0 AndAlso intmDireccionId > 0 AndAlso intmZonaId > 0 AndAlso intmMes > 0 AndAlso intmAnio > 0 AndAlso fltmFondoFijoPresupuestadoImporteAdicional > 0 Then

            ' Buscamos la información del fondo fijo presupuestado
            Dim fondoFijoPresupuestado As Array = Benavides.CC.Data.clstblFondoFijoPresupuestado.strBuscar(intmFondoFijoPresupuestadoId, intmCompaniaId, intmSucursalId, 0, 0, 0, 0, #1/1/2000#, #1/1/2000#, #1/1/2000#, "", 0, 0, strConnectionString)

            ' Si lo encontramos, obtenemos sus datos
            If IsArray(fondoFijoPresupuestado) AndAlso fondoFijoPresupuestado.Length > 0 Then

                fltmFondoFijoPresupuestadoImporteAsignado = CDbl(DirectCast(fondoFijoPresupuestado.GetValue(0), System.Collections.SortedList).Item("fltFondoFijoPresupuestadoImporteAsignado"))
                fltmFondoFijoPresupuestadoImporteDiarioMaximo = CDbl(DirectCast(fondoFijoPresupuestado.GetValue(0), System.Collections.SortedList).Item("fltFondoFijoPresupuestadoImporteDiarioMaximo"))
                blnmFondoFijoPresupuestadoSePuedeEditar = CBool(DirectCast(fondoFijoPresupuestado.GetValue(0), System.Collections.SortedList).Item("blnFondoFijoPresupuestadoSePuedeEditar"))

                Dim dtmFondoFijoPresupuestadoAsignacion As Date = CDate(DirectCast(fondoFijoPresupuestado.GetValue(0), System.Collections.SortedList).Item("dtmFondoFijoPresupuestadoAsignacion"))
                Dim dtmFondoFijoPresupuestadoCreacion As Date = CDate(DirectCast(fondoFijoPresupuestado.GetValue(0), System.Collections.SortedList).Item("dtmFondoFijoPresupuestadoCreacion"))

                ' Si al presupuesto se le puede asignar el importe adicional
                If blnmFondoFijoPresupuestadoSePuedeEditar Then

                    ' Actualizamos el importe adicional
                    Call Benavides.CC.Data.clstblFondoFijoPresupuestado.intActualizar(intmFondoFijoPresupuestadoId, intmCompaniaId, intmSucursalId, fltmFondoFijoPresupuestadoImporteAsignado, fltmFondoFijoPresupuestadoImporteAdicional, fltmFondoFijoPresupuestadoImporteDiarioMaximo, 0, dtmFondoFijoPresupuestadoAsignacion, dtmFondoFijoPresupuestadoCreacion, #1/1/2000#, strUsuarioNombre, strConnectionString)
                    blnmFondoFijoPresupuestadoSePuedeEditar = False

                End If

            End If

        End If

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
