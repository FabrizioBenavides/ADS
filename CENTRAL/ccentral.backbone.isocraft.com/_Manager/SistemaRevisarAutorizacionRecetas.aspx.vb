Imports Benavides.POSAdmin.Commons
Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

Public Class SistemaRevisarAutorizacionRecetas
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

        intDireccionId = GetPageParameter("cboDireccion", CInt(Request("intDireccionId")))
        intZonaId = GetPageParameter("cboZona", CInt(Request("intZonaId")))

        If Not IsNothing(Request("strSucursalId")) Then
            strSucursalId = Request("strSucursalId")
        Else
            strSucursalId = GetPageParameter("cboSucursal", "")
        End If

        If Not IsNothing(Request("strRecetaInicio")) Then
            strRecetaInicio = Request("strRecetaInicio")
        Else
            strRecetaInicio = GetPageParameter("txtRecetaInicio", "")
        End If

        If Not IsNothing(Request("strRecetaFin")) Then
            strRecetaFin = Request("strRecetaFin")
        Else
            strRecetaFin = GetPageParameter("txtRecetaFin", "")
        End If

    End Sub

#End Region

#Region " Class Private Attributes"

    Const strComitasDobles As String = """"

    Private strmJavascriptWindowOnLoadCommands As String

    Private intmDireccionId As Integer
    Private intmZonaId As Integer
    Private strmSucursalId As String

    Private strmCboDireccion As String
    Private strmCboZona As String
    Private strmCboSucursal As String

    Private strmtxtFechaInicial As String
    Private strmtxtFechaFinal As String

    Private strmRecordBrowserHTML As String = ""
    Private strmRecordBrowserArchivo As String = ""
    Private strmRecordBrowserImpresion As String = ""

#End Region

    Public ReadOnly Property intRenglonesxPagina() As Integer
        Get
            Return 46
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
    ' Name       : strLlenarDireccionComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboDireccion"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarDireccionComboBox() As String
        Dim aobjDirecciones As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString)
        Dim strRegistrosDirecciones As String()

        Dim aobjDirFarmacias As New System.Collections.ArrayList

        For Each strRegistrosDirecciones In aobjDirecciones

            aobjDirFarmacias.Add(strRegistrosDirecciones)

        Next

        'Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString)

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccion", intDireccionId, aobjDirFarmacias.ToArray, 0, 1, 2)


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
    ' Name       : strLlenarSucursalComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboSucursal"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarSucursalComboBox() As String
        If intDireccionId > 0 AndAlso intZonaId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSucursal", strSucursalId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, intZonaId, strConnectionString), New Integer(1) {0, 1}, 2, 2)
        End If
    End Function


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
    ' Name       : strSucursalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strSucursalId() As String
        Get
            Return strmSucursalId
        End Get
        Set(ByVal intValue As String)
            strmSucursalId = intValue
        End Set
    End Property

    Public ReadOnly Property intCompaniaid() As Integer
        Get
            Dim intmCompaniaid As Integer = 0

            If Len(strSucursalId) > 3 Then
                Dim astrCompaniaSucursal As Array = Split(strSucursalId, "|")
                If astrCompaniaSucursal.Length > 0 Then
                    intmCompaniaid = CInt(astrCompaniaSucursal.GetValue(0))
                End If
            End If

            Return intmCompaniaid

        End Get

    End Property

    Public ReadOnly Property intSucursalid() As Integer
        Get
            Dim intmSucursalid As Integer = 0

            If Len(strSucursalId) > 3 Then
                Dim astrCompaniaSucursal As Array = Split(strSucursalId, "|")
                If astrCompaniaSucursal.Length > 0 Then
                    intmSucursalid = CInt(astrCompaniaSucursal.GetValue(1))
                End If
            End If

            Return intmSucursalid

        End Get

    End Property

    '====================================================================
    ' Name       : strRecetaInicio
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strRecetaInicio() As String
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
    Public Property strRecetaFin() As String
        Get
            Return strmtxtFechaFinal
        End Get
        Set(ByVal strValue As String)
            strmtxtFechaFinal = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRecordBrowserHTML() As String
        Get
            Return strmRecordBrowserHTML
        End Get
        Set(ByVal Value As String)
            strmRecordBrowserHTML = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowserImpresion
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRecordBrowserImpresion() As String
        Get
            Return strmRecordBrowserImpresion
        End Get
        Set(ByVal Value As String)
            strmRecordBrowserImpresion = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strRecordBrowserArchivo
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRecordBrowserArchivo() As String
        Get
            Return strmRecordBrowserArchivo
        End Get
        Set(ByVal Value As String)
            strmRecordBrowserArchivo = Value
        End Set
    End Property


    Function fnReporteAutorizaciones() As Boolean

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 50
        Const strRecordBrowserName As String = "SistemaRevisarAutorizacionRecetas"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)

        ' Generamos el URL destino de las páginas
        Dim strTargetURL As String = strThisPageName & _
        "?strCmd=Consultar" & _
        "&intDireccionId=" & intDireccionId & _
        "&intZonaId=" & intZonaId & _
        "&strSucursalId=" & strSucursalId & _
        "&strRecetaInicio=" & strRecetaInicio & _
        "&strRecetaFin=" & strRecetaFin & "&"


        Dim ArrayReporteReceta As Array = Benavides.CC.Data.clsVentaClienteEspecial.arrayBuscarAutorizaciones(intDireccionId, intZonaId, intCompaniaid, intSucursalid, CDate(clsCommons.strDMYtoMDY(strRecetaInicio)), CDate(clsCommons.strDMYtoMDY(strRecetaFin)), Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

        ' Si se encontraron resultados para el reporte solicitado segun criterios de busqueda
        If IsNothing(ArrayReporteReceta) = False AndAlso ArrayReporteReceta.Length > 0 Then

            strRecordBrowserHTML = Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, ArrayReporteReceta, intSelectedPage, intElementsPerPage, strTargetURL)

            ' Declaramos e inicializamos las variables locales
            Dim ArrayImpresionReporteReceta As Array = Benavides.CC.Data.clsVentaClienteEspecial.arrayBuscarAutorizaciones(intDireccionId, intZonaId, intCompaniaid, intSucursalid, CDate(clsCommons.strDMYtoMDY(strRecetaInicio)), CDate(clsCommons.strDMYtoMDY(strRecetaFin)), 0, 0, strConnectionString)
            Dim RegistroRecetas As System.Collections.SortedList

            Dim strHTMLImpresion As New System.Text.StringBuilder
            Dim strArchivoExcel As New System.Text.StringBuilder
            Dim strColorRegistro As String

            Dim intPagina As Integer = 0
            Dim intRenglon As Integer = 0
            Dim intTotalRenglones As Integer = 0
            Dim intTotalPaginas As Integer = 0
            Dim intContadorRenglones As Integer = 0

            intTotalRenglones = ArrayImpresionReporteReceta.Length
            intTotalPaginas = intTotalRenglones \ intRenglonesxPagina

            If intTotalRenglones Mod intRenglonesxPagina > 0 Then
                intTotalPaginas += 1
            Else
                intTotalPaginas = 1
            End If

            intRenglon = 0
            intPagina = 0

            strHTMLImpresion = New System.Text.StringBuilder
            strArchivoExcel = New System.Text.StringBuilder

            Call strArchivoExcel.Append("Compania")
            Call strArchivoExcel.Append(",")
            Call strArchivoExcel.Append("Sucursal")
            Call strArchivoExcel.Append(",")
            Call strArchivoExcel.Append("Nombre")
            Call strArchivoExcel.Append(",")

            Call strArchivoExcel.Append("Fecha")
            Call strArchivoExcel.Append(",")
            Call strArchivoExcel.Append("Turno")
            Call strArchivoExcel.Append(",")
            Call strArchivoExcel.Append("Caja")
            Call strArchivoExcel.Append(",")
            Call strArchivoExcel.Append("Ticket")
            Call strArchivoExcel.Append(",")
            Call strArchivoExcel.Append("Vendedor")
            Call strArchivoExcel.Append(",")
            Call strArchivoExcel.Append("Autorizo")
            Call strArchivoExcel.Append(",")
            Call strArchivoExcel.Append("No. Cliente")
            Call strArchivoExcel.Append(",")
            Call strArchivoExcel.Append("Nom. Cliente")
            Call strArchivoExcel.Append(",")
            Call strArchivoExcel.Append("Imp. Venta")
            Call strArchivoExcel.Append(",")
            Call strArchivoExcel.Append("Imp Copago")
            Call strArchivoExcel.Append(vbCrLf)

            For Each RegistroRecetas In ArrayImpresionReporteReceta

                Call strArchivoExcel.Append(RegistroRecetas.Item("intCompaniaId"))
                Call strArchivoExcel.Append(",")

                Call strArchivoExcel.Append(RegistroRecetas.Item("intSucursalId"))
                Call strArchivoExcel.Append(",")

                Call strArchivoExcel.Append(Replace(CStr(RegistroRecetas.Item("strSucursalNombre")), ",", " "))
                Call strArchivoExcel.Append(",")

                Call strArchivoExcel.Append(clsCommons.strFormatearFechaPresentacion(CStr(RegistroRecetas.Item("dtmVentaClienteEspecial"))))
                Call strArchivoExcel.Append(",")

                Call strArchivoExcel.Append(RegistroRecetas.Item("intTurnoLaboralId"))
                Call strArchivoExcel.Append(",")

                Call strArchivoExcel.Append(RegistroRecetas.Item("intCajaId"))
                Call strArchivoExcel.Append(",")

                Call strArchivoExcel.Append(RegistroRecetas.Item("intTicketId"))
                Call strArchivoExcel.Append(",")

                Call strArchivoExcel.Append(RegistroRecetas.Item("intEmpleadoVendedorId"))
                Call strArchivoExcel.Append(",")

                Call strArchivoExcel.Append(RegistroRecetas.Item("intEmpleadoAutorizadorId"))
                Call strArchivoExcel.Append(",")

                Call strArchivoExcel.Append(RegistroRecetas.Item("strClienteEspecialNombreId"))
                Call strArchivoExcel.Append(",")

                Call strArchivoExcel.Append(Replace(clsCommons.strFormatearDescripcion(CStr(RegistroRecetas.Item("strClienteEspecialNombre"))), ",", " "))
                Call strArchivoExcel.Append(",")

                Call strArchivoExcel.Append(RegistroRecetas.Item("fltVentaClienteEspecialImporte"))
                Call strArchivoExcel.Append(",")

                Call strArchivoExcel.Append(RegistroRecetas.Item("fltVentaClienteEspecialImporteCopago"))
                Call strArchivoExcel.Append(vbCrLf)

                ' INICIA GENERACION PARA IMPRESION Y EXPORTACION A ARCHIVO EXCEL
                '----------------------------------------------------------------------------
                intContadorRenglones += 1
                intRenglon += 1

                If intRenglon = 1 Then 'IMPRIME HEDER DE PAGINA
                    intPagina += 1

                    If intPagina > 1 Then
                        strHTMLImpresion.Append("<p class='breakhere'></p>")
                    End If

                    'Inicio 
                    strHTMLImpresion.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    strHTMLImpresion.Append("<tr class='trtitulos'>")
                    strHTMLImpresion.Append("<th align='left'   colspan='5'  class='tdblancoSinRaya'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
                    strHTMLImpresion.Append("<th align='right'  colspan='3'  class='tdblancoSinRaya'>HOJA " & intPagina.ToString & " / " & intTotalPaginas.ToString & "</th>")
                    strHTMLImpresion.Append("</tr>")

                    'Titulo 
                    strHTMLImpresion.Append("<tr class='trtitulos'>")
                    strHTMLImpresion.Append("<th align='center' colspan='8'  class='tdblancoSinRaya'>Reporte de Autorizaciones de Recetas</th>")
                    strHTMLImpresion.Append("</tr>")

                    'Encabezados 
                    strHTMLImpresion.Append("<tr class='trtitulos'>")
                    strHTMLImpresion.Append("<th width='34%' class='tdblancoSinRaya' align='left' >Sucursal</th>")

                    strHTMLImpresion.Append("<th width='10%' class='tdblancoSinRaya' align='right' >Fecha Venta</th>")
                    strHTMLImpresion.Append("<th width='03%' class='tdblancoSinRaya' align='right' >Turno</th>")
                    strHTMLImpresion.Append("<th width='03%' class='tdblancoSinRaya' align='right' >Caja</th>")
                    strHTMLImpresion.Append("<th width='06%' class='tdblancoSinRaya' align='right' >Ticket</th>")

                    strHTMLImpresion.Append("<th width='08%' class='tdblancoSinRaya' align='right' >Vendedor</th>")
                    strHTMLImpresion.Append("<th width='08%' class='tdblancoSinRaya' align='right' >Autorizo</th>")

                    strHTMLImpresion.Append("<th width='28%' class='tdblancoSinRaya' align='left' >Cliente</th>")

                    strHTMLImpresion.Append("</tr>")

                    'Raya Sola
                    strHTMLImpresion.Append("<tr class='trtitulos'>")
                    strHTMLImpresion.Append("<th colspan= '8' width='100%'  class='rayita'>" & "&nbsp;" & "</th>")
                    strHTMLImpresion.Append("</tr>")

                End If 'TERMINA HEADER DE PAGINA

                If ((intRenglon Mod 2) = 0) Then
                    strColorRegistro = "tdtxtImpresionNormal"
                Else
                    strColorRegistro = "tdtxtImpresionBold"
                End If

                strHTMLImpresion.Append("<tr>")

                strHTMLImpresion.Append("<td width='34%' align='left' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(RegistroRecetas.Item("intCompaniaId")) & "-" & CStr(RegistroRecetas.Item("intSucursalId")) & " " & CStr(RegistroRecetas.Item("strSucursalNombre"))) & "</td>")

                strHTMLImpresion.Append("<td width='10%' align='right' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(RegistroRecetas.Item("dtmVentaClienteEspecial"))) & "</td>")
                strHTMLImpresion.Append("<td width='03%' align='right' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(RegistroRecetas.Item("intTurnoLaboralId"))) & "</td>")
                strHTMLImpresion.Append("<td width='03%' align='right' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(RegistroRecetas.Item("intCajaId"))) & "</td>")
                strHTMLImpresion.Append("<td width='06%' align='right' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(RegistroRecetas.Item("intTicketId"))) & "</td>")

                strHTMLImpresion.Append("<td width='08%' align='right' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(RegistroRecetas.Item("intEmpleadoVendedorId"))) & "</td>")
                strHTMLImpresion.Append("<td width='08%' align='right' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(RegistroRecetas.Item("intEmpleadoAutorizadorId"))) & "</td>")

                strHTMLImpresion.Append("<td width='28%' align='left' class='" & strColorRegistro & "'>" & clsCommons.strFormatearDescripcion(CStr(RegistroRecetas.Item("strClienteEspecialNombreId")) & "-" & Mid(CStr(RegistroRecetas.Item("strClienteEspecialNombre")), 1, 20)) & "</td>")

                strHTMLImpresion.Append("</tr>")


                If intRenglon = intRenglonesxPagina Or intContadorRenglones = intTotalRenglones Then
                    intRenglon = 0
                    strHTMLImpresion.Append("</table>")
                End If

                ' TERMINA GENERACION PARA IMPRESION Y EXPORTACION A ARCHIVO EXCEL
                '----------------------------------------------------------------------------

            Next

            strRecordBrowserImpresion = strHTMLImpresion.ToString
            strRecordBrowserArchivo = strArchivoExcel.ToString




        End If

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Check if the current user can access this page
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        strRecordBrowserHTML = ""
        strRecordBrowserArchivo = ""
        strRecordBrowserImpresion = ""

        If strCmd = "Consultar" Or strCmd = "Exportar" Then

            If intDireccionId = -1 Then
                intZonaId = -1
            End If

            If intZonaId = -1 Then
                strSucursalId = "-1|-1"
            End If

            If intDireccionId <> 0 And intZonaId <> 0 And Len(strSucursalId) > 0 Then
                fnReporteAutorizaciones()
            End If

            If Len(strRecordBrowserArchivo) > 1 And strCmd = "Exportar" Then
                ' Establecemos en la respuesta los parámetros de configuración del archivo
                Response.ContentType = "application/octet-stream"
                Call Response.AddHeader("Content-Disposition", "attachment;filename=""ReporteAutorizacionRecetas.csv""")
                Call Response.Write(strRecordBrowserArchivo)
                Call Response.End()
            End If


        End If


    End Sub

End Class
