Imports Isocraft.Web.Http

'====================================================================
' Class         : clsVentasVentasEnCuotasConsultar
' Title         : VentasVentasEnCuotasConsultar
' Description   : En esta parte usted puede consultar las promociones de pagos en cuotas existentes en el sistema.
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Rogelio Torres (rogelio@isocraft.com)
' Last Modified : Thursday, October 13, 2005
'====================================================================

Public Class clsVentasVentasEnCuotasConsultar
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

    End Sub

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
        stroptSeleccionPromocion = GetPageParameter("optSeleccionPromocion", "0")

    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private strmoptSeleccionPromocion As String
    Private strmFechaInicial As String
    Private strmFechaFinal As String

#End Region

    '====================================================================
    ' Name       : strComplete2Digit
    ' Description: Agrega un cero al principio si es un solo digito
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
    ' Name       : strFechaInicial
    ' Description: Fecha inicial
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strFechaInicial() As String
        Get
            strmFechaInicial = isocraft.commons.clsWeb.strGetPageParameter("txtFechaInicial", isocraft.commons.clsWeb.strGetPageParameter("strFechaInicial", ""))

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
    ' Name       : strFechaFinal
    ' Description: Fecha final
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strFechaFinal() As String
        Get
            strmFechaFinal = isocraft.commons.clsWeb.strGetPageParameter("txtFechaFinal", isocraft.commons.clsWeb.strGetPageParameter("strFechaFinal", ""))

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
    ' Name       : stroptSeleccionPromocion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property stroptSeleccionPromocion() As String
        Get
            Return strmoptSeleccionPromocion
        End Get
        Set(ByVal strValue As String)
            strmoptSeleccionPromocion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strObtenerPromocionesDeVentasEnCuotas
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strObtenerPromocionesDeVentasEnCuotas() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 50
        Const strRecordBrowserName As String = "VentasVentasEnCuotasConsultar"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim dtmFechaInicial As Date

        ' Obtenemos el rango de fechas
        If CInt(stroptSeleccionPromocion) = 1 Then

            dtmFechaInicial = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY("01/01/2000"))

        Else

            dtmFechaInicial = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaInicial))

        End If

        Dim dtmFechaFinal As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaFinal))

        Dim aobjDataArray As Array = Benavides.CC.Data.clsPromocionVentaCuotas.aobjObtenerPromocionesVentasCuotas(dtmFechaInicial, dtmFechaFinal, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

        ' Generamos el URL destino de las páginas
        Dim strTargetURL As String = strThisPageName & "?optSeleccionPromocion=" & stroptSeleccionPromocion & "&"

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, aobjDataArray, intSelectedPage, intElementsPerPage, strTargetURL)

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Load

        ' Declaramos las variables locales
        Dim aobjData As Array = Nothing
        Dim aobjData2 As Array = Nothing
        Dim objRow As System.Collections.SortedList = Nothing
        Dim objRow2 As System.Collections.SortedList = Nothing
        Dim intPromocionId As Integer = 0

        ' Execute the selected command
        Select Case strCmd

            Case "Agregar"

                Call Response.Redirect("VentasVentasEnCuotasAgregar.aspx?strCmd=Agregar")

            Case "Ver"

                Call Response.Redirect("VentasVentasEnCuotasDetallePromocion.aspx?strCmd=Ver&intPromocionVentaCuotasId=" & isocraft.commons.clsWeb.strGetPageParameter("intPromocionVentaCuotasId", "0"))

            Case "Editar"

                Call Response.Redirect("VentasVentasEnCuotasAgregar.aspx?strCmd=Editar&intPromocionVentaCuotasId=" & isocraft.commons.clsWeb.strGetPageParameter("intPromocionVentaCuotasId", "0"))

            Case "Eliminar"

                intPromocionId = GetPageParameter("intPromocionVentaCuotasId", 0)

                ' Si el identificador de la promocion es válido
                If intPromocionId > 0 Then

                    ' Leemos las tiendas
                    Dim objStoresArray As Array = Benavides.CC.Data.clstblTienda.strBuscar(0, 0, 0, "", "", 0, "", 0, "", "", Now, "", 0, 0, strConnectionString)

                    ' Buscamos los articulos de la promocion
                    aobjData = Benavides.CC.Data.clstblArticuloPromocionVentaCuotas.strBuscar(intPromocionId, 0, Now(), "", 0, 0, strConnectionString)

                    ' Si encontramos artículos
                    If IsArray(aobjData) = True AndAlso aobjData.Length > 0 Then

                        ' Si la dirección IP del concentrador es correcta y existen tiendas a quienes enviar la información
                        If IsArray(objStoresArray) = True AndAlso objStoresArray.Length > 0 Then

                            ' Enviamos los datos hacia los servidores de los puntos de venta
                            Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeCompletoHaciaServidoresPuntoDeVenta("clstblArticuloPromocionVentaCuotas", Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ELIMINAR, "POS", aobjData, objStoresArray)

                        End If

                    End If

                    ' Buscamos la promoción
                    aobjData2 = Benavides.CC.Data.clstblPromocionVentaCuotas.strBuscar(intPromocionId, "", 0, 0, Now(), Now(), False, Now(), "", 0, 0, strConnectionString)

                    ' Si encontramos artículos
                    If IsArray(aobjData2) = True AndAlso aobjData2.Length > 0 Then

                        ' Si la dirección IP del concentrador es correcta y existen tiendas a quienes enviar la información
                        If IsArray(objStoresArray) = True AndAlso objStoresArray.Length > 0 Then

                            ' Enviamos los datos hacia los servidores de los puntos de venta
                            Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeCompletoHaciaServidoresPuntoDeVenta("clstblPromocionVentaCuotas", Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ELIMINAR, "POS", aobjData2, objStoresArray)

                        End If

                    End If

                    ' Eliminamos los artículos de la promoción, si existen
                    If IsArray(aobjData) = True AndAlso aobjData.Length > 0 Then

                        Call Benavides.CC.Data.clstblArticuloPromocionVentaCuotas.intEliminar(intPromocionId, 0, Now(), "", strConnectionString)

                    End If

                    ' Eliminamos la promoción
                    Call Benavides.CC.Data.clstblPromocionVentaCuotas.intEliminar(intPromocionId, "", 0, 0, Now(), Now(), False, Now(), "", strConnectionString)

                End If

            Case Else

        End Select

    End Sub

End Class
