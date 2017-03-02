Imports System.Text
Imports Benavides.POSAdmin.Commons.clsCommons.clsMSMQ
Imports Benavides.CC.Business
Imports Benavides.CC.Data

Public Class SistemaActualizarSucursal
    Inherits System.Web.UI.Page
    Const strComitasDobles As String = """"


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
    End Sub

#End Region

    ' Variables privadas
    Private intmDireccionId As Integer
    Private intmZonaId As Integer
    Private strmSucursales As String


    ' Variables locales privadas
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String


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
    ' Name       : strThisPageName
    ' Description: URL de esta página
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request)
        End Get
    End Property

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Obtiene la cadena de conexión hacia la base de datos
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property
    '====================================================================
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: Establece los comandos Javascript del evento OnLoad
    ' Accessor   : Read
    ' Throws     : Ninguna
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
    ' Description: Obtiene o establece el comando actual
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strCmd() As String
        Get
            Return strmCommand
        End Get
        Set(ByVal strValue As String)
            strmCommand = strValue
        End Set
    End Property



    '====================================================================
    ' Name       : intDireccionId
    ' Description: Identificador de la dirección operativa
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
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
    ' Description: Identificador de la zona operativa
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
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
    ' Name       : strSucursales
    ' Description: Sucursales a enviar
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property strSucursales() As String
        Get
            Return strmSucursales
        End Get
        Set(ByVal Value As String)
            strmSucursales = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strDireccionOperativaNombre
    ' Description: Nombre de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strDireccionOperativaNombre() As String
        Get
            If intDireccionId > 0 Then
                Dim astrData As Array = Benavides.CC.Data.clstblDireccionOperativa.strBuscar(intDireccionId, "", "", Now, "", 0, 0, strConnectionString)
                If IsArray(astrData) = True AndAlso astrData.Length > 0 Then
                    Return CStr(DirectCast(astrData.GetValue(0), Array).GetValue(1))
                End If
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strZonaOperativaNombre
    ' Description: Nombre de la Zona
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strZonaOperativaNombre() As String
        Get
            If intDireccionId > 0 AndAlso intZonaId > 0 Then
                Dim astrData As Array = Benavides.CC.Data.clstblZonaOperativa.strBuscar(intDireccionId, intZonaId, "", "", Now, "", 0, 0, strConnectionString)
                If IsArray(astrData) = True AndAlso astrData.Length > 0 Then
                    Return CStr(DirectCast(astrData.GetValue(0), Array).GetValue(2))
                End If
            End If
        End Get
    End Property

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
                    strRegreso &= "document.forms[0].elements['" & strNombreParametro & "'].checked = true;"

                Else
                    strRegreso &= "document.forms[0].elements['" & strNombreParametro & "'].checked = false;"

                End If

            End If
        Next

        Return strRegreso

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "", Request)

        ' Almacenamos la Direccion
        intDireccionId = CInt(isocraft.commons.clsWeb.strGetPageParameter("txtDireccionId", "0", Request))

        ' Almacenamos la Zona
        intZonaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("txtZonaId", "0", Request))

        'Sucursales
        strSucursales = isocraft.commons.clsWeb.strGetPageParameter("txtSucursales", "", Request)

        Select Case strCmd
            Case "Transmitir"
                Dim strHTML As StringBuilder
                Dim strResultadoTransmision As String = ""
                Dim strTablasEnviadas As String = ""

                ' Variables locales

                Dim intSolicitudTransmisionId As Integer = 0
                Dim intTotalElementosForma As Integer = 0
                Dim strNombreParametro As String = ""
                Dim strValorParametro As String = ""

                Dim strTiendaConcentradorIP As String = ""
                Dim intDaysToRetrieve As Integer = 0

                Dim dtmUltimaModificacionInicial As Date
                Dim dtmUltimaModificacionFinal As Date

                Dim objStoresArray As Array = Nothing

                Dim strTableName As String = ""
                Dim objDataArray As Array = Nothing
                Dim strForwardTo As String = ""


                strHTML = New StringBuilder

                ' Leemos la dirección de IP asignada a este Concentrador
                strTiendaConcentradorIP = System.Configuration.ConfigurationSettings.AppSettings("strTiendaConcentradorIP")

                ' Leemos la cantidad de días hacia atrás o hacia adelante, a partir de la fecha actual, que formará el rango de fechas a leer
                intDaysToRetrieve = CInt(System.Configuration.ConfigurationSettings.AppSettings("intConcentradorDiasAConsultar"))

                ' Establecemos la fecha inicial a partir de la cual se buscarán los registros
                dtmUltimaModificacionInicial = DateAdd(DateInterval.Day, intDaysToRetrieve, Now)

                ' Establecemos la fecha final hasta la cual se buscarán los registros
                dtmUltimaModificacionFinal = Now

                strTablasEnviadas = Request.Form("txtNombreSucursales") & "  -->"


                ' Primer paso grabamos el folio de transmision

                intSolicitudTransmisionId = Benavides.CC.Data.clsTransmision.intAgregarSolicitudActualizacionSucursal(0, intDireccionId, intZonaId, strSucursales, strUsuarioNombre, strConnectionString)

                If intSolicitudTransmisionId > 0 Then

                    For intTotalElementosForma = 0 To Request.Form.Count - 1

                        strNombreParametro = Request.Form.GetKey(intTotalElementosForma)
                        strValorParametro = Request.Form(strNombreParametro)

                        If strNombreParametro.StartsWith("chk") Then

                            If Len(strValorParametro) > 0 Then

                                strTablasEnviadas &= strValorParametro

                                strTableName = "[" & strValorParametro & "][objDataArray]"
                                objDataArray = objArrayBuscarDatos(strValorParametro, intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal)

                                ' Enviamos los datos hacia los servidores de los puntos de venta
                                If IsArray(objDataArray) AndAlso objDataArray.Length > 0 Then
                                    strTableName = "[" & strValorParametro & "][strEnviarMensajeHaciaServidoresPuntoDeVenta]"

                                    If strValorParametro = "tblOferta" Or _
                                       strValorParametro = "tblMonedaSucursal" Or _
                                       strValorParametro = "tblClienteEspecialSucursal" Or _
                                       strValorParametro = "tblEmpleadoSucursal" Or _
                                       strValorParametro = "tblServicioPublicoAsignadoSucursal" Or _
                                       strValorParametro = "tblTurnoLaboralSucursal" Or _
                                       strValorParametro = "tblImpuestoSucursal" Or _
                                       strValorParametro = "tblCuotaVenta" Or _
                                       strValorParametro = "tblCuenta" Or _
                                       strValorParametro = "tblCuentaSucursal" Then
                                        strForwardTo = ""
                                    Else
                                        strForwardTo = "POS"
                                    End If

                                    Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeHaciaServidoresPuntoDeVenta("cls" & strValorParametro, enmMQCommandId.ACTUALIZAR_AGREGAR, strForwardTo, objDataArray, strTiendaConcentradorIP)

                                End If

                            End If

                        End If
                    Next

                    clstblSolicitudActualizacion.intActualizar(intSolicitudTransmisionId, strTablasEnviadas, Now, strUsuarioNombre, strConnectionString)

                    strHTML.Append("<script language='Javascript'> parent.fnUpTransmitir( " & _
                                 strComitasDobles & "1" & strComitasDobles & _
                               "); </script>")

                    Response.Write(strHTML.ToString)
                    Response.End()


                End If

        End Select

    End Sub

    '====================================================================
    ' Name       : objArrayBuscarDatos
    ' Description: Regresa los datos a enviar
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Array
    '====================================================================
    Function objArrayBuscarDatos(ByVal strNombreTabla As String, ByVal intSolicitudTransmisionId As Integer, ByVal dtmUltimaModificacionInicial As Date, ByVal dtmUltimaModificacionFinal As Date) As Array

        Dim objArrayRegreso As Array = Nothing


        Select Case strNombreTabla
            'Articulos
            '-------------------------------------------------------
        Case "tblArticulo"
                objArrayRegreso = clstblArticulo.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblArticuloSucursal"
                objArrayRegreso = clstblArticuloSucursal.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblOferta"
                objArrayRegreso = clstblOferta.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblArticuloOferta"
                objArrayRegreso = clstblArticuloOferta.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblProveedorArticuloSucursal"
                objArrayRegreso = clstblProveedorArticuloSucursal.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)


                'Tipo de Cambio
                '----------------------------------------------------
            Case "tblTipodeCambioMoneda"
                objArrayRegreso = Nothing 'clstblTipoDeCambioMoneda.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblMonedaSucursal"
                objArrayRegreso = clstblMonedaSucursal.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

                'Fondo fijo
                '----------------------------------------------------
            Case "tblFolioFondoFijo"
                objArrayRegreso = clstblFolioFondoFijo.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

                'Cupones
                '----------------------------------------------------
            Case "tblCupon"
                objArrayRegreso = clstblCupon.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblCuponSucursal"
                objArrayRegreso = clstblCuponSucursal.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblCuponFormaPago"
                objArrayRegreso = clstblCuponFormaPago.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblCategoriaCupon"
                objArrayRegreso = clstblCategoriaCupon.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblSubcategoriaCupon"
                objArrayRegreso = clstblSubcategoriaCupon.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblArticuloCupon"
                objArrayRegreso = clstblArticuloCupon.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblProveedorCupon"
                objArrayRegreso = clstblProveedorCupon.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblProveedorCategoriaCupon"
                objArrayRegreso = clstblProveedorCategoriaCupon.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblProveedorSubcategoriaCupon"
                objArrayRegreso = clstblProveedorSubcategoriaCupon.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

                'Clientes
                '----------------------------------------------------
            Case "tblClienteEspecial"
                objArrayRegreso = clstblClienteEspecial.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblClienteEspecialSucursal"
                objArrayRegreso = clstblClienteEspecialSucursal.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblClienteEspecialDatoGeneralRequerido"
                objArrayRegreso = clstblClienteEspecialDatoGeneralRequerido.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

                'Empleados
                '----------------------------------------------------
            Case "tblEmpleado"
                objArrayRegreso = clstblEmpleado.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblEmpleadoSucursal"
                objArrayRegreso = clstblEmpleadoSucursal.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

                'Datos Sucursal
                '----------------------------------------------------
            Case "tblPoliticaTicket"
                objArrayRegreso = clstblPoliticaTicket.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblPoliticaPosSucursal"
                objArrayRegreso = clstblPoliticaPosSucursal.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblServicioPublicoAsignadoSucursal"
                objArrayRegreso = clstblServicioPublicoAsignadoSucursal.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblTurnoLaboralSucursal"
                objArrayRegreso = clstblTurnoLaboralSucursal.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblImpuestoSucursal"
                objArrayRegreso = clstblImpuestoSucursal.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblCuotaVenta"
                objArrayRegreso = clstblCuotaVenta.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblCuenta"
                objArrayRegreso = clstblCuenta.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

            Case "tblCuentaSucursal"
                objArrayRegreso = clstblCuentaSucursal.strBuscar(intSolicitudTransmisionId, dtmUltimaModificacionInicial, dtmUltimaModificacionFinal, strConnectionString)

        End Select

        Return objArrayRegreso


    End Function


End Class
