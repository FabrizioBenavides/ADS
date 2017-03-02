Imports Isocraft.Web.Http
Imports Benavides.POSAdmin.Commons.clsCommons.clsMSMQ

'====================================================================
' Class         : clsSistemaBinesEditar
' Title         : SistemaBinesEditar
' Description   : Editar BINes
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Rogelio Torres (rogelio@isocraft.com)
' Last Modified : Monday, October 17, 2005
'====================================================================

Public Class clsSistemaBinesEditar
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
        intBinTarjetaId = GetPageParameter("intBinTarjetaId", 0)
        strtxtDescripcion = GetPageParameter("txtDescripcion", "")
        strtxtEmisor = GetPageParameter("txtEmisor", "")
        strtxtFechaMod = GetPageParameter("txtFechaMod", "")
        intCredito = GetPageParameter("intCredito", 0)
        intPermiteCuotas = GetPageParameter("intPermiteCuotas", 0)
        intPagoComision = GetPageParameter("intPagoComision", 0)
        'AJAL: stkblnValidaPagoConVales inicializamos intValidaPagoConVales
        intValidaPagoConVales = GetPageParameter("intValidaPagoConVales", 0)
    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private intmBinTarjetaId As Integer
    Private strmtxtDescripcion As String
    Private strmtxtEmisor As String
    Private strmtxtFechaMod As String
    Private intmCredito As Integer
    Private intmPermiteCuotas As Integer
    Private intmPagoComision As Integer
    Private intmBancoIntegradorId As Integer
    'AJAL:stkblnValidaPagoConVales declaramos variable privada intmValidaPagoConVales
    Private intmValidaPagoConVales As Integer

#End Region

    '====================================================================
    ' Name       : intCredito
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intCredito() As Integer
        Get
            Return intmCredito
        End Get
        Set(ByVal intValue As Integer)
            intmCredito = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intPermiteCuotas
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intPermiteCuotas() As Integer
        Get
            Return intmPermiteCuotas
        End Get
        Set(ByVal intValue As Integer)
            intmPermiteCuotas = intValue
        End Set
    End Property
    'AJAL: stkblnValidaPagoConVales
    '====================================================================
    ' Name       : intValidaPagoConVales
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intValidaPagoConVales() As Integer
        Get
            Return intmValidaPagoConVales
        End Get
        Set(ByVal intValue As Integer)
            intmValidaPagoConVales = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intPagoComision
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intPagoComision() As Integer
        Get
            Return intmPagoComision
        End Get
        Set(ByVal intValue As Integer)
            intmPagoComision = intValue
        End Set
    End Property

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
    ' Name       : intBinTarjetaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intBinTarjetaId() As Integer
        Get
            Return intmBinTarjetaId
        End Get
        Set(ByVal intValue As Integer)
            intmBinTarjetaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strtxtDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtDescripcion() As String
        Get
            Return strmtxtDescripcion
        End Get
        Set(ByVal strValue As String)
            strmtxtDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strtxtEmisor
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtEmisor() As String
        Get
            Return strmtxtEmisor
        End Get
        Set(ByVal strValue As String)
            strmtxtEmisor = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strtxtFechaMod
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtFechaMod() As String
        Get
            Return strmtxtFechaMod
        End Get
        Set(ByVal strValue As String)
            strmtxtFechaMod = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intBancoIntegradorId
    ' Description: Identificador de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intBancoIntegradorId() As Integer
        Get

            If intmBancoIntegradorId = 0 Then

                intmBancoIntegradorId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboBancoIntegrador", isocraft.commons.clsWeb.strGetPageParameter("intBancoIntegradorId", "0")))

            End If

            Return intmBancoIntegradorId
        End Get
        Set(ByVal intValue As Integer)
            intmBancoIntegradorId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strLlenarBancoIntegradorComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboBancoIntegrador"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarBancoIntegradorComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboBancoIntegrador", intBancoIntegradorId, Benavides.CC.Data.clstblBancoIntegradorCorresponsalia.strObtenerBancoIntegrador(strConnectionString), 0, 1, 1)
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Load

        ' Enviamos al usuario a la página padre, si el identificador del BIN no es el adecuado
        If intBinTarjetaId < 1 Then

            Call Response.Redirect("SistemaBinesConsultar.aspx")

        End If

        ' Declaramos nuestras variables locales
        Dim aobjData As Array = Nothing
        Dim strTipo As String
        Dim strPermiteVentasCuotas As String
        Dim strDateMod As String
        Dim intEmisor As Integer
        Dim intActualiza As Integer
        Dim astrData As Array
        Dim dtmFechaMod As Date
        Dim blnPermiteCuotas As Boolean
        Dim blnPagoComision As Boolean
        Dim strBinPagoComision As String
        Dim intBancoIntegradorCorresponsaliaId As Integer
        'AJAL: stkblnValidaPagoConVales declaracion de variables
        Dim blnValidaPagoConVales As Boolean
        Dim strValidaPagoConVales As String

        ' Execute the selected command
        Select Case strCmd

            Case "Guardar"

                If intBinTarjetaId > 0 Then

                    If intPermiteCuotas = 1 Then
                        blnPermiteCuotas = True
                    Else
                        blnPermiteCuotas = False
                    End If

                    If intPagoComision = 1 Then
                        blnPagoComision = True
                    Else
                        blnPagoComision = False
                    End If
                    'AJAL: stkblnValidaPagoConVales se añade condicion
                    If intValidaPagoConVales = 1 Then
                        blnValidaPagoConVales = True
                    End If


                    dtmFechaMod = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strtxtFechaMod))
                    'AJAL: stkblnValidaPagoConVales se agrega parametro blnValidaPagoConVales
                    intActualiza = Benavides.CC.Data.clstblBINTarjeta.intActualizar(intBinTarjetaId, intEmisor, CByte(intCredito), Now(), strUsuarioNombre, strtxtDescripcion, blnPermiteCuotas, blnPagoComision, intBancoIntegradorId, blnValidaPagoConVales, strConnectionString)
                    Call Response.Redirect("SistemaBinesConsultar.aspx")

                End If

            Case "Eliminar"

                ' Si el identificador del BIN es válido
                If intBinTarjetaId > 0 Then

                    ' Buscamos los datos del BIN seleccionado
                    aobjData = Benavides.CC.Data.clstblBINTarjeta.strBuscar(intBinTarjetaId, 0, 0, #1/1/2000#, "", "", False, 0, 0, strConnectionString)

                    ' Si encontramos el BIN
                    If IsArray(aobjData) = True AndAlso aobjData.Length > 0 Then

                        ' Obtenemos el identificador de su emisor
                        Dim intEmisorFormaPagoId As Integer = CInt(DirectCast(aobjData.GetValue(0), Array).GetValue(1))

                        ' Si el emisor es válido
                        If intEmisorFormaPagoId > 0 Then

                            ' Buscamos las tiendas
                            Dim objStoresArray As Array = Benavides.CC.Data.clstblTienda.strBuscar(0, 0, 0, "", "", 0, "", 0, "", "", Now, "", 0, 0, strConnectionString)

                            ' Si las encontramos (tiendas)
                            If IsArray(objStoresArray) = True AndAlso objStoresArray.Length > 0 Then

                                ' Enviamos los datos hacia los servidores de los puntos de venta
                                Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeCompletoHaciaServidoresPuntoDeVenta("clstblBINTarjeta", enmMQCommandId.ELIMINAR, "POS", aobjData, objStoresArray)

                                ' Eliminamos su información de la base de datos
                                Call Benavides.CC.Data.clstblBINTarjeta.intEliminar(intBinTarjetaId, intEmisorFormaPagoId, 0, #1/1/2000#, strUsuarioNombre, "", False, strConnectionString)

                            End If

                        End If

                    End If

                    ' Regresamos a la página principal
                    Call Response.Redirect("SistemaBinesConsultar.aspx")

                End If

            Case Else

                If intBinTarjetaId > 0 Then

                    aobjData = Benavides.CC.Data.clsBINTarjeta.aobjObtenerBINes(CStr(intBinTarjetaId), 0, 0, 0, strConnectionString)

                    ' Si encontramos la información
                    If IsArray(aobjData) = True AndAlso aobjData.Length > 0 Then

                        ' Actualizamos los campos de la forma
                        intBinTarjetaId = CInt(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("intBINTarjetaId"))
                        strtxtDescripcion = CStr(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("strBINTarjetaDescripcion"))
                        strtxtEmisor = CStr(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("strEmisorFormaPagoNombre"))
                        strTipo = CStr(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("strBINTarjetaTipo"))
                        strPermiteVentasCuotas = CStr(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("blnBINTarjetaPermiteVentaCuotas"))
                        strDateMod = CStr(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("dtmBINTarjetaUltimaModificacion"))
                        intEmisor = CInt(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("intEmisorFormaPagoId"))
                        strBinPagoComision = CStr(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("blnBINCobraComision"))
                        intBancoIntegradorCorresponsaliaId = CInt(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("intBancoIntegradorCorresponsaliaId"))
                        'AJAL stkblnValidaPagoConVales 
                        strValidaPagoConVales = CStr(DirectCast(aobjData.GetValue(0), Collections.SortedList).Item("blnValidaPagoConVales"))

                        'Quitamos la hora a la fecha inicial
                        astrData = strDateMod.Split(" "c)
                        strDateMod = CStr(astrData.GetValue(0))

                        'Agregamos un 0 a la izquierda de los numeros de un solo digito de la fecha y acomodamos la fecha
                        astrData = strDateMod.Split("/"c)

                        If astrData.Length = 3 Then

                            strDateMod = strComplete2Digit(CStr(astrData.GetValue(1))) & "/" & strComplete2Digit(CStr(astrData.GetValue(0))) & "/" & CStr(astrData.GetValue(2))

                        End If

                        strtxtFechaMod = strDateMod

                        If StrComp(strPermiteVentasCuotas, "Sí") = 0 Then

                            intPermiteCuotas = 1

                        Else

                            intPermiteCuotas = 0

                        End If

                        If StrComp(strTipo, "Crédito") = 0 Then

                            intCredito = 1

                        Else

                            intCredito = 0

                        End If

                        If StrComp(strBinPagoComision, "Sí") = 0 Then
                            intPagoComision = 1
                        Else
                            intPagoComision = 0
                        End If
                        'AJAL: stkblnValidaPagoConVales se agrega condicion 
                        If StrComp(strValidaPagoConVales, "Sí") = 0 Then
                            intValidaPagoConVales = 1
                        Else
                            intValidaPagoConVales = 0
                        End If

                        intBancoIntegradorId = intBancoIntegradorCorresponsaliaId


                    Else

                        ' Enviamos al usuario a la página padre, si el identificador del BIN no existe
                        Call Response.Redirect("SistemaBinesConsultar.aspx")

                    End If

                End If

        End Select

    End Sub

End Class
