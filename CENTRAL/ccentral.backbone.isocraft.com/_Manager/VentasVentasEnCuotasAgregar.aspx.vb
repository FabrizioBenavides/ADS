Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert

'====================================================================
' Class         : clsVentasVentasEnCuotasAgregar
' Title         : VentasVentasEnCuotasAgregar
' Description   : En esta parte usted puede agregar promociones de pago en cuotas y posteriormente asignarles BINes y artículos 
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Rogelio Torres(rogelio@isocraft.com)
' Last Modified : Thursday, October 13, 2005
'====================================================================

Public Class clsVentasVentasEnCuotasAgregar
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

    End Sub

    Protected WithEvents txtBuscar As System.Web.UI.HtmlControls.HtmlInputFile

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

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

        ' Initialize class properties
        strCmd = GetPageParameter("strCmd", GetPageParameter("strECmd", ""))
        strtxtTipoPagoDescripcion = GetPageParameter("txtTipoPagoDescripcion", "")
        strtxtPlazo = GetPageParameter("txtPlazo", "")
        strtxtMontoMinimo = GetPageParameter("txtMontoMinimo", "")
        strtxtArticuloDescripcionripcion = GetPageParameter("txtArticuloDescripcionripcion", "")
        strtxtBuscar = GetPageParameter("txtBuscar", "")
        strtxtArticuloDescripcion = GetPageParameter("txtArticuloDescripcion", "")
        intAsignar = GetPageParameter("optAsignar", 0)
        intClick = GetPageParameter("intClick", 0)
        strtxtArticuloEncontrado = GetPageParameter("txtArticuloEncontrado", "")
        intPromocionVentaCuotasId = GetPageParameter("intPromocionVentaCuotasId", 0)
        intArticuloId = GetPageParameter("intArticuloId", 0)
        strFechaInicial = GetPageParameter("txtFechaInicial", strFechaIni)
        strFechaFinal = GetPageParameter("txtFechaFinal", strFechaFin)
        intCategoriaId = GetPageParameter("cboSeleccionarCategoria", 0)
        intActiva = GetPageParameter("intActiva", 0)

    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private strmtxtTipoPagoDescripcion As String
    Private strmtxtPlazo As String
    Private strmtxtMontoMinimo As String
    Private strmFechaInicial As String
    Private strmFechaFinal As String
    Private strmtxtArticuloDescripcionripcion As String
    Private strmtxtBuscar As String
    Private strmtxtArticuloDescripcion As String
    Private intmAsignar As Integer
    Private intmintClick As Integer
    Private strmtxtArticuloEncontrado As String
    Private intmPromocionVentaCuotasId As Integer
    Private intmCategoriaId As Integer
    Private intmArticuloId As Integer
    Private intmActiva As Integer
    Private strmCmd As String

#End Region

    '====================================================================
    ' Name       : intActiva
    ' Description: Para saber si esta activa la promocion
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intActiva() As Integer
        Get
            Return intmActiva
        End Get
        Set(ByVal intValue As Integer)
            intmActiva = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intArticuloId
    ' Description: Identificador de Articulo
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intArticuloId() As Integer
        Get

            If intmArticuloId = 0 Then

                intmArticuloId = CInt(GetPageParameter("txtArticuloDescripcion", GetPageParameter("intArticuloId", 0)))

            End If

            Return intmArticuloId
        End Get
        Set(ByVal intValue As Integer)
            intmArticuloId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intCategoriaId
    ' Description: Identificador de la Categoria
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intCategoriaId() As Integer
        Get
            Return intmCategoriaId
        End Get
        Set(ByVal intValue As Integer)
            intmCategoriaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strLlenarCategoriaComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboDireccion"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarCategoriaComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSeleccionarCategoria", intCategoriaId, Benavides.CC.Data.clstblCategoriaArticulo.strBuscar(0, "", "", Today(), "", 0, 0, strConnectionString), 0, 1, 1)

    End Function

    '====================================================================
    ' Name       : strComplete2Digit
    ' Description: Agrega un cero a la izquierda si es numero de un digito
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Private Function strComplete2Digit(ByVal strValue As String) As String

        If Len(strValue) = 1 Then

            Return "0" & strValue

        Else

            Return strValue

        End If

    End Function

    '====================================================================
    ' Name       : strSeleccionaCombos
    ' Description: Deja marcados los combos al hacer submit a la pagina
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : string
    '====================================================================
    Function strSeleccionaCombos() As String

        Dim intTotalElementosForma As Integer
        Dim strNombreParametro As String
        Dim strValorParametro As String
        Dim strRegreso As String = ""

        For intTotalElementosForma = 0 To Request.Form.Count - 1

            strNombreParametro = Request.Form.GetKey(intTotalElementosForma)
            strValorParametro = Request.Form(strNombreParametro)

            If strNombreParametro.StartsWith("chk") Then

                If Len(strValorParametro) > 0 Then

                    strRegreso = "true"

                Else

                    strRegreso = "false"

                End If

            End If

        Next

        Return strRegreso

    End Function

    '====================================================================
    ' Name       : strFechaIni
    ' Description: Fecha inicial
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strFechaIni() As String
        Get
            strmFechaInicial = GetPageParameter("txtFechaInicial", GetPageParameter("strFechaInicial", ""))

            If Len(strmFechaInicial) = 0 Then

                Dim dtmYesterday As Date = DateAdd(DateInterval.Day, -1, Now)
                strmFechaInicial = strComplete2Digit(CStr(Day(dtmYesterday))) & "/" & strComplete2Digit(CStr(Month(dtmYesterday))) & "/" & Year(dtmYesterday)

            Else

                Dim astrData As Array = strmFechaInicial.Split("/"c)

                If astrData.Length = 3 Then

                    strmFechaInicial = strComplete2Digit(CStr(astrData.GetValue(0))) & "/" & strComplete2Digit(CStr(astrData.GetValue(1))) & "/" & CStr(astrData.GetValue(2))

                End If

            End If

            Return strmFechaInicial
        End Get
        Set(ByVal strValue As String)
            strmFechaInicial = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaInicial
    ' Description: Fecha inicial
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strFechaInicial() As String
        Get
            Return strmFechaInicial
        End Get
        Set(ByVal strValue As String)
            strmFechaInicial = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaFin
    ' Description: Fecha final
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strFechaFin() As String
        Get
            strmFechaFinal = GetPageParameter("txtFechaFinal", GetPageParameter("strFechaFinal", ""))

            If Len(strmFechaFinal) = 0 Then

                strmFechaFinal = strComplete2Digit(CStr(Day(Now))) & "/" & strComplete2Digit(CStr(Month(Now))) & "/" & Year(Now)

            Else

                Dim astrData As Array = strmFechaFinal.Split("/"c)

                If astrData.Length = 3 Then

                    strmFechaFinal = strComplete2Digit(CStr(astrData.GetValue(0))) & "/" & strComplete2Digit(CStr(astrData.GetValue(1))) & "/" & CStr(astrData.GetValue(2))

                End If

            End If

            Return strmFechaFinal
        End Get
        Set(ByVal strValue As String)
            strmFechaFinal = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaFinal
    ' Description: Fecha final
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strFechaFinal() As String
        Get
            Return strmFechaFinal
        End Get
        Set(ByVal strValue As String)
            strmFechaFinal = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strtxtArticuloEncontrado
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtArticuloEncontrado() As String
        Get
            Return strmtxtArticuloEncontrado
        End Get
        Set(ByVal strValue As String)
            strmtxtArticuloEncontrado = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intClick
    ' Description: Opcion seleccionado
    ' Accessor   : Read/Write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intClick() As Integer
        Get
            Return intmintClick
        End Get
        Set(ByVal intValue As Integer)
            intmintClick = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intAsignar
    ' Description: Opcion seleccionado
    ' Accessor   : Read/Write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intAsignar() As Integer
        Get
            Return intmAsignar
        End Get
        Set(ByVal intValue As Integer)
            intmAsignar = intValue
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
    Public Property strCmd() As String
        Get
            Return strmCmd
        End Get
        Set(ByVal strValue As String)
            strmCmd = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strtxtTipoPagoDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtTipoPagoDescripcion() As String
        Get
            Return strmtxtTipoPagoDescripcion
        End Get
        Set(ByVal strValue As String)
            strmtxtTipoPagoDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strtxtPlazo
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtPlazo() As String
        Get
            Return strmtxtPlazo
        End Get
        Set(ByVal strValue As String)
            strmtxtPlazo = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strtxtMontoMinimo
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtMontoMinimo() As String
        Get
            Return strmtxtMontoMinimo
        End Get
        Set(ByVal strValue As String)
            strmtxtMontoMinimo = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strtxtArticuloDescripcionripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtArticuloDescripcion() As String
        Get
            Return strmtxtArticuloDescripcion
        End Get
        Set(ByVal strValue As String)
            strmtxtArticuloDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strtxtBuscar
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtBuscar() As String
        Get
            Return strmtxtBuscar
        End Get
        Set(ByVal strValue As String)
            strmtxtBuscar = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strtxtArticuloDescripcionripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtArticuloDescripcionripcion() As String
        Get
            Return strmtxtArticuloDescripcionripcion
        End Get
        Set(ByVal strValue As String)
            strmtxtArticuloDescripcionripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intPromocionVentaCuotasId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intPromocionVentaCuotasId() As Integer
        Get
            Return intmPromocionVentaCuotasId
        End Get
        Set(ByVal intValue As Integer)
            intmPromocionVentaCuotasId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strObtenerArticulosIncluidos()
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strObtenerArticulosIncluidos() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 50
        Const strRecordBrowserName As String = "VentasVentasEnCuotasAgregar"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)

        ' Almacenamos el comando ejecutado
        If StrComp(strCmd, "Editar") = 0 Then

            ' Obtenemos el rango de fechas
            Dim dtmFechaInicial As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaInicial))
            Dim dtmFechaFinal As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaFinal))

            ' Buscamos las sucursales de esta dirección y zona
            Dim aobjDataArray As Array = Benavides.CC.Data.clsPromocionVentaCuotas.aobjObtenerArticulosPromocionVentaCuotas(intPromocionVentaCuotasId, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

            ' Generamos el URL destino de las páginas
            Dim strTargetURL As String = strThisPageName & "?strECmd=Editar&intPromocionVentaCuotasId=" & intPromocionVentaCuotasId & "&intCategoriaId=" & intCategoriaId & "&intClick=" & intClick & "&"

            Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, aobjDataArray, intSelectedPage, intElementsPerPage, strTargetURL)

        End If

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Load

        ' Declaramos las constantes locales
        Const intNumeroColumnasArchivo As Int32 = 1

        ' Declaramos nuestras variables locales
        Dim aobjData As Array = Nothing
        Dim intTotal As Integer = 0
        Dim strDateIni As String = ""
        Dim strDateFin As String = ""
        Dim astrData As Array = Nothing
        Dim dtmFechaInicial As Date
        Dim dtmFechaFinal As Date
        Dim blnActiva As Boolean = False
        Dim objRow As System.Collections.SortedList = Nothing
        Dim dtmInicioRegistro As Date
        Dim dtmFinalRegistro As Date
        Dim blnCorrecto As Boolean = True
        Dim intPromocionIdBD As Integer = 0

        ' Execute the selected command
        Select Case strCmd

            Case "Editar"

                intClick = 1

                'Si se tiene el Id de Promocion Venta en Cuotas
                If intPromocionVentaCuotasId > 0 Then

                    aobjData = Benavides.CC.Data.clstblPromocionVentaCuotas.strBuscar(intPromocionVentaCuotasId, "", 0, 0, Now(), Now(), False, Now(), "", 0, 0, strConnectionString)

                    ' Si encontramos la información
                    If IsArray(aobjData) = True AndAlso aobjData.Length > 0 Then

                        ' Actualizamos los campos de la forma
                        strtxtTipoPagoDescripcion = CStr(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("strPromocionVentaCuotasNombre"))
                        strtxtPlazo = CStr(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("intPromocionVentaCuotasPlazo"))
                        strtxtMontoMinimo = CStr(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("fltPromocionVentaCuotasMontoMinimo"))
                        strDateIni = CStr(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("dtmPromocionVentaCuotasVigenciaInicio"))
                        strDateFin = CStr(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("dtmPromocionVentaCuotasVigenciaFin"))
                        blnActiva = CBool(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("blnPromocionVentaCuotasActiva"))

                        'Quitamos la hora a la fecha inicial
                        astrData = strDateIni.Split(" "c)
                        strDateIni = CStr(astrData.GetValue(0))

                        'Agregamos un 0 a la izquierda de los numeros de un solo digito de la fecha y acomodamos la fecha
                        astrData = strDateIni.Split("/"c)

                        If astrData.Length = 3 Then

                            strDateIni = strComplete2Digit(CStr(astrData.GetValue(1))) & "/" & strComplete2Digit(CStr(astrData.GetValue(0))) & "/" & CStr(astrData.GetValue(2))

                        End If

                        'Fecha Inicial que se muestra en pantalla 
                        strFechaInicial = strDateIni

                        'Quitamos la hora a la fecha inicial
                        astrData = strDateFin.Split(" "c)
                        strDateFin = CStr(astrData.GetValue(0))

                        'Agregamos un 0 a la izquierda de los numeros de un solo digito de la fecha y acomodamos la fecha
                        astrData = strDateFin.Split("/"c)

                        If astrData.Length = 3 Then

                            strDateFin = strComplete2Digit(CStr(astrData.GetValue(1))) & "/" & strComplete2Digit(CStr(astrData.GetValue(0))) & "/" & CStr(astrData.GetValue(2))

                        End If

                        'Fecha Final que se muestra en pantalla
                        strFechaFinal = strDateFin

                        'Bandera para identificar si la promocion esta activa
                        If blnActiva = True Then

                            intActiva = 1

                        Else

                            intActiva = 0

                        End If

                    End If

                End If

            Case "Registrar"

                'Transformamos el formato de las fechas de la pagina
                dtmFechaInicial = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaInicial))
                dtmFechaFinal = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaFinal))

                aobjData = Benavides.CC.Data.clstblPromocionVentaCuotas.strBuscar(0, "", 0, 0, Now(), Now(), False, Now(), "", 0, 0, strConnectionString)

                ' Si encontramos información
                If IsArray(aobjData) = True AndAlso aobjData.Length > 0 Then

                    blnCorrecto = True

                    'Por cada registro en 
                    For Each objRow In aobjData

                        ' Obtenemos el artículo complementario actual
                        dtmInicioRegistro = CDate(objRow.Item("dtmPromocionVentaCuotasVigenciaInicio"))
                        dtmFinalRegistro = CDate(objRow.Item("dtmPromocionVentaCuotasVigenciaFin"))

                        If (dtmFechaInicial > dtmInicioRegistro AndAlso dtmFechaInicial < dtmFinalRegistro) OrElse (dtmFechaFinal > dtmInicioRegistro AndAlso dtmFechaFinal < dtmFinalRegistro) OrElse (dtmFechaInicial < dtmInicioRegistro AndAlso dtmFechaFinal > dtmFinalRegistro) Then

                            blnCorrecto = False

                        End If

                    Next

                End If

                If blnCorrecto = True Then

                    'Bandera para identificar si esta activa la promocion, la transformamos para agregarla a la BD
                    If intActiva = 1 Then

                        blnActiva = True

                    Else

                        blnActiva = False

                    End If

                    'Agregamos el nuevo registro a la BD
                    intPromocionVentaCuotasId = Benavides.CC.Data.clstblPromocionVentaCuotas.intAgregar(0, strtxtTipoPagoDescripcion, CInt(strtxtPlazo), CInt(strtxtMontoMinimo), dtmFechaInicial, dtmFechaFinal, blnActiva, Now(), strUsuarioNombre, strConnectionString)

                    Call Response.Redirect("VentasVentasEnCuotasAgregar.aspx?strCmd=Editar&intPromocionVentaCuotasId=" & intPromocionVentaCuotasId)

                Else

                    intClick = 0
                    strJavascriptWindowOnLoadCommands &= "  alert(""Rango de Fechas no permitido, seleccionar otro rango"");" & vbCrLf

                End If

            Case "Actualizar"

                'Primero revisamos que contemos con el Id
                If intPromocionVentaCuotasId > 0 Then

                    'Transformamos el formato de las fechas para introducirlo a la base de datos
                    dtmFechaInicial = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaInicial))
                    dtmFechaFinal = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaFinal))

                    aobjData = Benavides.CC.Data.clstblPromocionVentaCuotas.strBuscar(0, "", 0, 0, Now(), Now(), False, Now(), "", 0, 0, strConnectionString)

                    ' Si encontramos información
                    If IsArray(aobjData) = True AndAlso aobjData.Length > 0 Then

                        blnCorrecto = True

                        'Por cada registro en 
                        For Each objRow In aobjData

                            ' Obtenemos el artículo complementario actual
                            dtmInicioRegistro = CDate(objRow.Item("dtmPromocionVentaCuotasVigenciaInicio"))
                            dtmFinalRegistro = CDate(objRow.Item("dtmPromocionVentaCuotasVigenciaFin"))
                            intPromocionIdBD = CInt(objRow.Item("intPromocionVentaCuotasId"))

                            If intPromocionVentaCuotasId <> intPromocionIdBD Then

                                If (dtmFechaInicial > dtmInicioRegistro AndAlso dtmFechaInicial < dtmFinalRegistro) OrElse (dtmFechaFinal > dtmInicioRegistro AndAlso dtmFechaFinal < dtmFinalRegistro) OrElse (dtmFechaInicial < dtmInicioRegistro AndAlso dtmFechaFinal > dtmFinalRegistro) Then

                                    blnCorrecto = False

                                End If

                            End If

                        Next

                    End If

                    If blnCorrecto = True Then

                        'Bandera para identificar si esta activa la promocion, la transformamos para agregarla a la BD
                        If intActiva = 1 Then

                            blnActiva = True

                        Else

                            blnActiva = False

                        End If

                        'Actualizamos el registro
                        intTotal = Benavides.CC.Data.clstblPromocionVentaCuotas.intActualizar(intPromocionVentaCuotasId, strtxtTipoPagoDescripcion, CInt(strtxtPlazo), CDec(strtxtMontoMinimo), dtmFechaInicial, dtmFechaFinal, blnActiva, Now(), strUsuarioNombre, strConnectionString)

                        Call Response.Redirect("VentasVentasEnCuotasAgregar.aspx?strCmd=Editar&intPromocionVentaCuotasId=" & intPromocionVentaCuotasId)

                    Else

                        intClick = 0
                        strJavascriptWindowOnLoadCommands &= "  alert(""Rango de Fechas no permitido, seleccionar otro rango"");" & vbCrLf

                    End If

                End If

            Case "AgregarCategoria"

                'Revisamos que contemos contemos con el id de la promocion y de la categoria
                If intPromocionVentaCuotasId > 0 AndAlso intCategoriaId > 0 Then

                    'Agregamos los articulos a la promocion
                    intTotal = Benavides.CC.Data.clsPromocionVentaCuotas.intAgregarCategoriaArticuloPromocionVentaCuotas(intPromocionVentaCuotasId, intCategoriaId, Now(), strUsuarioNombre, strConnectionString)

                End If

                Call Response.Redirect("VentasVentasEnCuotasAgregar.aspx?strCmd=Editar&intPromocionVentaCuotasId=" & intPromocionVentaCuotasId)

            Case "AgregarArchivo"

                'Primero revisamos que contemos con el Id
                If intPromocionVentaCuotasId > 0 Then

                    ' Verificamos si el archivo ha sido enviado
                    If IsNothing(txtBuscar.PostedFile) = False Then

                        Dim intCounter As Integer
                        Dim dtmInicio As DateTime = Now()

                        ' Obtenemos un arreglo con los renglones del archivo
                        Dim astrRows As Array = CreateArrayFromCSVHttpPostedFile(txtBuscar.PostedFile)

                        ' Por cada renglón existente
                        If IsNothing(astrRows) = False AndAlso astrRows.Length > 0 Then

                            For Each astrColumns As Array In astrRows

                                ' Si el renglón tiene el número de columnas adecuadas
                                If astrColumns.Length = intNumeroColumnasArchivo Then

                                    ' Obtenemos los valores que vienen en el archivo
                                    Dim intArticuloIdArchivo As Integer = CInt(ConvertObject(astrColumns.GetValue(0), TypeCode.Int32))

                                    ' Agregamos los nuevos registros, si los valores de las columnas son válidos
                                    If intArticuloIdArchivo > 0 Then

                                        ' Buscamos el registro
                                        Dim aobjDataToSearch As Array = Benavides.CC.Data.clstblArticuloPromocionVentaCuotas.strBuscar(intPromocionVentaCuotasId, intArticuloIdArchivo, Now(), "", 0, 0, strConnectionString)

                                        ' Si el registro existe
                                        If IsArray(aobjDataToSearch) = True AndAlso aobjDataToSearch.Length > 0 Then

                                            ' Actualizamos el registro
                                            intCounter += Benavides.CC.Data.clstblArticuloPromocionVentaCuotas.intActualizar(intPromocionVentaCuotasId, intArticuloIdArchivo, Now(), strUsuarioNombre, strConnectionString)

                                        Else

                                            ' Agregamos el nuevo registro
                                            intCounter += Benavides.CC.Data.clstblArticuloPromocionVentaCuotas.intAgregar(intPromocionVentaCuotasId, intArticuloIdArchivo, Now(), strUsuarioNombre, strConnectionString)

                                        End If

                                    End If

                                End If

                            Next

                            ' Notificamos los registros actualizados
                            Dim dtmFinal As DateTime = Now()
                            strJavascriptWindowOnLoadCommands &= "  alert(""Total de líneas en el archivo: " & astrRows.Length & "\n\r\n\rTotal de registros importados: " & intCounter & "\n\r\n\rTotal de líneas sin importar: " & CStr(astrRows.Length - intCounter) & "\n\r\n\rInicio: " & dtmInicio & "\n\r\n\rFinal: " & dtmFinal & "\n\r\n\rTiempo estimado: " & DateDiff(DateInterval.Minute, dtmInicio, dtmFinal) & " minuto(s)"");" & vbCrLf
                            strJavascriptWindowOnLoadCommands &= "  window.location.href = ""VentasVentasEnCuotasAgregar.aspx?strCmd=Editar&intPromocionVentaCuotasId=" & intPromocionVentaCuotasId & """;"

                        End If

                    End If

                End If

            Case "Reemplazar"

                If intPromocionVentaCuotasId > 0 Then

                    ' Verificamos si el archivo ha sido enviado 
                    If IsNothing(txtBuscar.PostedFile) = False Then

                        Dim intCounter As Integer
                        Dim dtmInicio As DateTime = Now()
                        Dim aobjDataList As System.Collections.ArrayList

                        ' Obtenemos un arreglo con los registros del archivo
                        Dim astrRows As Array = CreateArrayFromCSVHttpPostedFile(txtBuscar.PostedFile)

                        ' Si el archivo contenía registros
                        If IsNothing(astrRows) = False AndAlso astrRows.Length > 0 Then

                            ' Eliminamos los registros existentes en la base de datos
                            Call Benavides.CC.Data.clstblArticuloPromocionVentaCuotas.intEliminar(intPromocionVentaCuotasId, 0, Now(), "", strConnectionString)
                            aobjDataList = New System.Collections.ArrayList

                            ' Por cada registro existente
                            For Each astrColumns As Array In astrRows

                                ' Si el registro tiene el número de columnas adecuadas
                                If astrColumns.Length = intNumeroColumnasArchivo Then

                                    ' Obtenemos los valores que vienen en el archivo
                                    Dim intArticuloArchivo As Integer = CInt(ConvertObject(astrColumns.GetValue(0), TypeCode.Int32))

                                    ' Agregamos los nuevos registros, si los valores de las columnas son válidos
                                    If intArticuloArchivo > 0 Then

                                        ' Agregamos el nuevo registros a la base de datos
                                        Dim intReturnedValue As Integer = Benavides.CC.Data.clstblArticuloPromocionVentaCuotas.intAgregar(intPromocionVentaCuotasId, intArticuloArchivo, Now(), strUsuarioNombre, strConnectionString)

                                        ' Si el registro logró ser agregado
                                        If intReturnedValue > 0 Then

                                            ' Agregamos el registro actual a la lista de registros a transmitirse a las sucursales
                                            Dim objRecordField As System.Collections.SortedList = New System.Collections.SortedList
                                            Call objRecordField.Add("intPromocionVentaCuotasId", intPromocionVentaCuotasId)
                                            Call objRecordField.Add("intArticuloId", intArticuloArchivo)
                                            Call objRecordField.Add("dtmArticuloPromocionVentaCuotasUltimaModificacion", Now())
                                            Call objRecordField.Add("strArticuloPromocionVentaCuotasModificadoPor", strUsuarioNombre)
                                            Call aobjDataList.Add(objRecordField)
                                            objRecordField = Nothing

                                            ' Incrementamos el contador de registros procesados exitósamente
                                            intCounter += intReturnedValue

                                        End If

                                    End If

                                End If

                            Next

                            ' Obtenemos de la lista los registros a enviar y los almacenamos en un arreglo de datos
                            aobjData = aobjDataList.ToArray()

                            ' Si el arreglo tiene datos
                            If aobjData.Length > 0 Then

                                ' Leemos las tiendas asignadas a este cliente
                                Dim objStoresArray As Array = Benavides.CC.Data.clstblTienda.strBuscar(0, 0, 0, "", "", 0, "", 0, "", "", Now, "", 0, 0, strConnectionString)

                                ' Si la dirección IP del concentrador es correcta y existen tiendas a quienes enviar la información
                                If IsNothing(objStoresArray) = False AndAlso objStoresArray.Length > 0 Then

                                    ' Enviamos los datos hacia los servidores de los puntos de venta
                                    Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeCompletoHaciaServidoresPuntoDeVenta("clstblArticuloPromocionVentaCuotas", Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ELIMINAR_AGREGAR, "POS", aobjData, objStoresArray)

                                End If

                            End If

                            ' Notificamos los registros actualizados
                            Dim dtmFinal As DateTime = Now()
                            strJavascriptWindowOnLoadCommands &= "  alert(""Total de líneas en el archivo: " & astrRows.Length & "\n\r\n\rTotal de registros importados: " & intCounter & "\n\r\n\rTotal de líneas sin importar: " & CStr(astrRows.Length - intCounter) & "\n\r\n\r\n\rTotal de registros enviados a cada sucursal: " & aobjData.Length & "\n\r\n\r\n\rInicio: " & dtmInicio & "\n\r\n\rFinal: " & dtmFinal & "\n\r\n\rTiempo estimado: " & DateDiff(DateInterval.Minute, dtmInicio, dtmFinal) & " minuto(s)\n\r"");" & vbCrLf
                            strJavascriptWindowOnLoadCommands &= "  window.location.href = ""VentasVentasEnCuotasAgregar.aspx?strCmd=Editar&intPromocionVentaCuotasId=" & intPromocionVentaCuotasId & """;"

                        End If

                    End If

                End If

            Case "AgregarArticulo"

                ' Revisamos que contemos contemos con el id de la promocion y del articulo
                If intPromocionVentaCuotasId > 0 AndAlso intArticuloId > 0 Then

                    ' Agregamos el articulo a la promocion 
                    intTotal = Benavides.CC.Data.clstblArticuloPromocionVentaCuotas.intAgregar(intPromocionVentaCuotasId, intArticuloId, Now(), strUsuarioNombre, strConnectionString)

                End If

                ' Refrescamos la página actual
                Call Response.Redirect("VentasVentasEnCuotasAgregar.aspx?strCmd=Editar&intPromocionVentaCuotasId=" & intPromocionVentaCuotasId)

            Case "Eliminar"

                ' Si los identificadores de la promoción y del artículo son válidos
                If intPromocionVentaCuotasId > 0 And intArticuloId > 0 Then

                    ' Buscamos los datos de la promoción y su artículo seleccionado
                    aobjData = Benavides.CC.Data.clstblArticuloPromocionVentaCuotas.strBuscar(intPromocionVentaCuotasId, intArticuloId, #1/1/2000#, "", 0, 0, strConnectionString)

                    ' Si encontramos datos
                    If IsArray(aobjData) = True AndAlso aobjData.Length > 0 Then

                        ' Buscamos las tiendas
                        Dim objStoresArray As Array = Benavides.CC.Data.clstblTienda.strBuscar(0, 0, 0, "", "", 0, "", 0, "", "", Now, "", 0, 0, strConnectionString)

                        ' Si las encontramos (tiendas)
                        If IsArray(objStoresArray) = True AndAlso objStoresArray.Length > 0 Then

                            ' Enviamos los datos hacia los servidores de los puntos de venta
                            Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeCompletoHaciaServidoresPuntoDeVenta("clstblArticuloPromocionVentaCuotas", Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ELIMINAR, "POS", aobjData, objStoresArray)

                            ' Eliminamos su información de la base de datos
                            Call Benavides.CC.Data.clstblArticuloPromocionVentaCuotas.intEliminar(intPromocionVentaCuotasId, intArticuloId, #1/1/2000#, strUsuarioNombre, strConnectionString)

                        End If

                    End If

                    ' Refrescamos la página actual
                    Call Response.Redirect("VentasVentasEnCuotasAgregar.aspx?strCmd=Editar&intPromocionVentaCuotasId=" & intPromocionVentaCuotasId)

                End If

        End Select

    End Sub

End Class
