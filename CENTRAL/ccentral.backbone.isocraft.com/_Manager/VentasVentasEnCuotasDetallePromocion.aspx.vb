Imports Isocraft.Web.Http

'====================================================================
' Class         : clsVentasVentasEnCuotasDetallePromocion
' Title         : clsVentasVentasEnCuotasDetallePromocion
' Description   : En esta parte usted puede consultar las promociones de pagos en cuotas existentes en el sistema.
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Rogelio Torres (rogelio@isocraft.com)
' Last Modified : Thursday, October 13, 2005
'====================================================================

Public Class clsVentasVentasEnCuotasDetallePromocion
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
        strtxtNombre = GetPageParameter("txtNombre", "")
        strtxtPlazo = GetPageParameter("txtPlazo", "")
        strtxtMonto = GetPageParameter("txtMonto", "")
        strtxtVigencia = GetPageParameter("txtVigencia", "")
        strtxtEstatus = GetPageParameter("txtEstatus", "")
        intPromocionVentaCuotasId = GetPageParameter("intPromocionVentaCuotasId", 0)
    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private strmtxtNombre As String
    Private strmtxtPlazo As String
    Private strmtxtMonto As String
    Private strmtxtVigencia As String
    Private strmtxtEstatus As String
    Private intmPromocionVentaCuotasId As Integer

#End Region

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
    ' Name       : strtxtNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtNombre() As String
        Get
            Return strmtxtNombre
        End Get
        Set(ByVal strValue As String)
            strmtxtNombre = strValue
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
    ' Name       : strtxtMonto
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtMonto() As String
        Get
            Return strmtxtMonto
        End Get
        Set(ByVal strValue As String)
            strmtxtMonto = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strtxtVigencia
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtVigencia() As String
        Get
            Return strmtxtVigencia
        End Get
        Set(ByVal strValue As String)
            strmtxtVigencia = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strtxtEstatus
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtEstatus() As String
        Get
            Return strmtxtEstatus
        End Get
        Set(ByVal strValue As String)
            strmtxtEstatus = strValue
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
    ' Name       : strObtenerArticulosIncluidos
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strObtenerArticulosIncluidos() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 10
        Const strRecordBrowserName As String = "VentasVentasEnCuotasDetallePromocion"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim aobjDataArray As Array = Benavides.CC.Data.clsPromocionVentaCuotas.aobjObtenerArticulosPromocionVentaCuotas(intPromocionVentaCuotasId, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

        ' Generamos el URL destino de las páginas
        Dim strTargetURL As String = strThisPageName & _
                                     "?intPromocionVentaCuotasId=" & intPromocionVentaCuotasId & _
                                     "&txtNombre=" & strtxtNombre & _
                                     "&txtPlazo=" & strtxtPlazo & _
                                     "&txtMonto=" & strtxtMonto & _
                                     "&txtVigencia=" & strtxtVigencia & _
                                     "&txtEstatus=" & strtxtEstatus & _
                                     "&"


        '"&intPagina=" & GetPageParameter("intNavegadorRegistrosPagina", 1) & _

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, aobjDataArray, intSelectedPage, intElementsPerPage, strTargetURL)

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaramos las variables locales
        Dim aobjData As Array = Nothing
        Dim aobjData2 As Array = Nothing
        Dim objRow As System.Collections.SortedList = Nothing
        Dim plazo As String
        Dim monto As String
        Dim fechaIni, fechaFin As String
        Dim astrData As Array

        ' Execute the selected command
        Select Case strCmd

            Case "Ver"
                ' Si el identificador del artículo es válido
                If intPromocionVentaCuotasId > 0 Then

                    ' Buscamos la información del artículo seleccionado
                    aobjData = Benavides.CC.Data.clstblPromocionVentaCuotas.strBuscar(intPromocionVentaCuotasId, "", 0, 0, Now(), Now(), False, Now(), "", 0, 0, strConnectionString)

                    ' Si encontramos la información
                    If IsArray(aobjData) = True AndAlso aobjData.Length > 0 Then

                        ' Actualizamos los campos de la forma
                        strtxtNombre = CStr(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("strPromocionVentaCuotasNombre"))
                        plazo = CStr(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("intPromocionVentaCuotasPlazo"))
                        monto = CStr(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("fltPromocionVentaCuotasMontoMinimo"))
                        fechaIni = CStr(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("dtmPromocionVentaCuotasVigenciaInicio"))
                        fechaFin = CStr(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("dtmPromocionVentaCuotasVigenciaFin"))
                        strtxtEstatus = CStr(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("blnPromocionVentaCuotasActiva"))

                        'Agregamos la palabra mes o meses al plazo
                        If plazo = "1" Then
                            strtxtPlazo = plazo + " mes"
                        ElseIf CInt(plazo) > 1 Then
                            strtxtPlazo = plazo + " meses"
                        End If

                        'Agregamos el simbolo de $ al monto
                        If CInt(monto) > 0 Then
                            strtxtMonto = "$" + monto
                        End If

                        'Quitamos la hora a la fecha inicial
                        astrData = fechaIni.Split(" "c)
                        fechaIni = CStr(astrData.GetValue(0))

                        'Agregamos un 0 a la izquierda de los numeros de un solo digito de la fecha y acomodamos la fecha
                        astrData = fechaIni.Split("/"c)
                        If astrData.Length = 3 Then
                            fechaIni = strComplete2Digit(CStr(astrData.GetValue(1))) & "/" & strComplete2Digit(CStr(astrData.GetValue(0))) & "/" & CStr(astrData.GetValue(2))
                        End If

                        'Quitamos la hora a la fecha final
                        astrData = fechaFin.Split(" "c)
                        fechaFin = CStr(astrData.GetValue(0))

                        'Agregamos un 0 a la izquierda de los numeros de un solo digito de la fecha y acomodamos la fecha
                        astrData = fechaFin.Split("/"c)
                        If astrData.Length = 3 Then
                            fechaFin = strComplete2Digit(CStr(astrData.GetValue(1))) & "/" & strComplete2Digit(CStr(astrData.GetValue(0))) & "/" & CStr(astrData.GetValue(2))
                        End If

                        strtxtVigencia = "Desde " + CStr(fechaIni) + " hasta " + CStr(fechaFin)

                        If strtxtEstatus = "True" Then
                            strtxtEstatus = "Activa."
                        Else
                            strtxtEstatus = "Inactiva."
                        End If

                    End If

                End If

            Case "Eliminar"

                ' Si el identificador de la promocion es válido
                If intPromocionVentaCuotasId > 0 Then

                    ' Buscamos los articulos de la promocion
                    aobjData = Benavides.CC.Data.clstblArticuloPromocionVentaCuotas.strBuscar(intPromocionVentaCuotasId, 0, Now(), "", 0, 0, strConnectionString)

                    ' Si encontramos artículos
                    If IsArray(aobjData) = True AndAlso aobjData.Length > 0 Then

                        ' Leemos las tiendas
                        Dim objStoresArray As Array = Benavides.CC.Data.clstblTienda.strBuscar(0, 0, 0, "", "", 0, "", 0, "", "", Now, "", 0, 0, strConnectionString)

                        ' Si la dirección IP del concentrador es correcta y existen tiendas a quienes enviar la información
                        If IsArray(objStoresArray) = True AndAlso objStoresArray.Length > 0 Then

                            ' Enviamos los datos hacia los servidores de los puntos de venta
                            Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeCompletoHaciaServidoresPuntoDeVenta("clstblArticuloPromocionVentaCuotas", Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ELIMINAR, "POS", aobjData, objStoresArray)

                        End If

                    End If

                    'Buscamos la promocion
                    aobjData2 = Benavides.CC.Data.clstblPromocionVentaCuotas.strBuscar(intPromocionVentaCuotasId, "", 0, 0, Now(), Now(), False, Now(), "", 0, 0, strConnectionString)

                    ' Si encontramos artículos
                    If IsArray(aobjData2) = True AndAlso aobjData2.Length > 0 Then

                        ' Leemos las tiendas
                        Dim objStoresArray2 As Array = Benavides.CC.Data.clstblTienda.strBuscar(0, 0, 0, "", "", 0, "", 0, "", "", Now, "", 0, 0, strConnectionString)

                        ' Si la dirección IP del concentrador es correcta y existen tiendas a quienes enviar la información
                        If IsArray(objStoresArray2) = True AndAlso objStoresArray2.Length > 0 Then

                            ' Enviamos los datos hacia los servidores de los puntos de venta
                            Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeCompletoHaciaServidoresPuntoDeVenta("clstblPromocionVentaCuotas", Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ELIMINAR, "POS", aobjData2, objStoresArray2)

                        End If

                    End If

                    If IsArray(aobjData) = True AndAlso aobjData.Length > 0 Then

                        ' Por cada artículo existente
                        For Each objRow In aobjData

                            'Eliminamos su información de la base de datos
                            Call Benavides.CC.Data.clstblArticuloPromocionVentaCuotas.intEliminar(intPromocionVentaCuotasId, 0, Now(), "", strConnectionString)

                        Next

                    End If

                    ' Eliminamos la promocion 
                    Call Benavides.CC.Data.clstblPromocionVentaCuotas.intEliminar(intPromocionVentaCuotasId, "", 0, 0, Now(), Now(), False, Now(), "", strConnectionString)

                End If

                Call Response.Redirect("VentasVentasEnCuotasConsultar.aspx")

            Case Else

        End Select

    End Sub

End Class
