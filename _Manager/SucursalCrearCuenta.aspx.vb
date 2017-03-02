'====================================================================
' Class         : clsSucursalCrearCuenta
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Administrar Cuenta :Agregar - Editar Cuenta
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Javier Ramos
' Version       : 1.0
' Last Modified : Monday, May 24, 2004
'====================================================================

Imports System.Text

Public Class clsSucursalCrearCuenta
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
    End Sub

#End Region

    ' Variables locales privadas
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private intmTipoCuentaId As Integer
    Private intmCuentaId As Integer
    Private intmTipoReferenciaId As Integer
    Private intmCuentaPadreId As Integer
    Private intmDetalleReferenciaId As Integer
    Private strmNombreCuenta As String
    Private strmNombreIdCuenta As String
    Private strmDescripcionCuenta As String
    Private strmNumeroBaan As String
    Private blnmEsCredito As Byte
    Private fltmCuentaComision As Double
    Private blnmComisionEsPorcentaje As Byte
    Private strmTipoCuentaSeleccionada As String
    Private intmUbicacionBancariaId As Integer


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
    ' Name       : intGrupoUsuarioId
    ' Description: Identificador del Grupo de Usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
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
    ' Throws     : Ninguna
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
    ' Throws     : Ninguna
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
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strTipoCuentaSeleccionada
    ' Description: Identificador de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTipoCuentaSeleccionada() As String
        Get
            strmTipoCuentaSeleccionada = isocraft.commons.clsWeb.strGetPageParameter("txtTipoCuentaSeleccionada", "")
            Return strmTipoCuentaSeleccionada
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
    ' Name       : intCuentaId 
    ' Description: Obtiene o establece el id del tipo de cuenta
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intCuentaId() As Integer
        Get
            Return intmCuentaId
        End Get
        Set(ByVal intValue As Integer)
            intmCuentaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intTipoCuentaId
    ' Description: Identificador de la Dirección
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intTipoCuentaId() As Integer
        Get
            Return intmTipoCuentaId
        End Get
        Set(ByVal intValue As Integer)
            intmTipoCuentaId = intValue
        End Set
    End Property
    '====================================================================
    ' Name       : intCuentaPadreId
    ' Description: Identificador de la Cuenta Padre
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intCuentaPadreId() As Integer
        Get
            Return intmCuentaPadreId
        End Get
        Set(ByVal intValue As Integer)
            intmCuentaPadreId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strNombreCuenta
    ' Description: Nombre de la cuenta
    ' Accessor   : Read. write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strNombreCuenta() As String
        Get
            Return strmNombreCuenta
        End Get
        Set(ByVal strValue As String)
            strmNombreCuenta = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strNombreIdCuenta
    ' Description: Nombre Id de la cuenta
    ' Accessor   : Read. write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strNombreIdCuenta() As String
        Get
            Return strmNombreIdCuenta
        End Get
        Set(ByVal strValue As String)
            strmNombreIdCuenta = strValue
        End Set
    End Property



    '====================================================================
    ' Name       : strDescripcionCuenta
    ' Description: Descripcion de la cuenta
    ' Accessor   : Read. write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strDescripcionCuenta() As String
        Get
            Return strmDescripcionCuenta
        End Get
        Set(ByVal strValue As String)
            strmDescripcionCuenta = strValue
        End Set
    End Property



    '====================================================================
    ' Name       : strNumeroBaan
    ' Description: Numero Baan de la cuenta
    ' Accessor   : Read. write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strNumeroBaan() As String
        Get
            Return strmNumeroBaan
        End Get
        Set(ByVal strValue As String)
            strmNumeroBaan = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnEsCredito
    ' Description: Bandera que indica si la cuenta es de credito
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Byte
    '====================================================================
    Public Property blnEsCredito() As Byte
        Get
            Return blnmEsCredito
        End Get
        Set(ByVal blnValue As Byte)
            blnmEsCredito = blnValue
        End Set
    End Property



    '====================================================================
    ' Name       : blnComisionEsPorcentaje
    ' Description: Bandera que indica si la comision es porcentaje
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Byte
    '====================================================================
    Public Property blnComisionEsPorcentaje() As Byte
        Get
            Return blnmComisionEsPorcentaje
        End Get
        Set(ByVal blnValue As Byte)
            blnmComisionEsPorcentaje = blnValue
        End Set
    End Property



    '====================================================================
    ' Name       : fltCuentaComision
    ' Description: Valor de la comision de la cuenta
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Byte
    '====================================================================
    Public Property fltCuentaComision() As Double
        Get
            Return fltmCuentaComision
        End Get
        Set(ByVal fltValue As Double)
            fltmCuentaComision = fltValue
        End Set
    End Property

    '====================================================================
    ' Name       : intTipoReferenciaId
    ' Description: Identificador del tipo de referencia
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intTipoReferenciaId() As Integer
        Get
            Return intmTipoReferenciaId
        End Get
        Set(ByVal intValue As Integer)
            intmTipoReferenciaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intDetalleReferenciaId
    ' Description: Identificador del tipo de referencia
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intDetalleReferenciaId() As Integer
        Get
            Return intmDetalleReferenciaId
        End Get
        Set(ByVal intValue As Integer)
            intmDetalleReferenciaId = intValue
        End Set
    End Property

    'intmUbicacionBancariaId
    '====================================================================
    ' Name       : intUbicacionBancariaId
    ' Description: Identificador del tipo de referencia
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intUbicacionBancariaId() As Integer
        Get
            Return intmUbicacionBancariaId
        End Get
        Set(ByVal intValue As Integer)
            intmUbicacionBancariaId = intValue
        End Set
    End Property


    '====================================================================
    ' Name       : intBuscarTipoCuentaPorNOmbre
    ' Description: Obtiene el Id del tipo de cuenta
    ' Parameters : None
    ' Throws     : None
    ' Output     : Integer
    '====================================================================

    Public Function intBuscarTipoCuentaPorNombre(ByVal strTipoCuentaNombreId As String) As Integer

        Dim astrDataArray As Array = Benavides.CC.Data.clstblTipoCuenta.strBuscar(0, strTipoCuentaNombreId, "", Now(), "", 0, 0, strConnectionString)

        If IsArray(astrDataArray) AndAlso astrDataArray.Length > 0 Then
            Return CInt(DirectCast(astrDataArray.GetValue(0), Array).GetValue(0))
        Else
            Return 0
        End If

    End Function
    '====================================================================
    ' Name       : strLlenarTipoCuentaComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboTipoCuenta"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarTipoCuentaComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboTipoCuenta", intTipoCuentaId, Benavides.CC.Data.clstblTipoCuenta.strBuscar(0, "", "", Now(), "", 0, 0, strConnectionString), 0, 2, 1)
    End Function

    '====================================================================
    ' Name       : strLlenarCuentaPadreComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboCuentaPadre"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarCuentaPadreComboBox() As String

        Dim intTipoCuentaBusquedaId As Integer = 0
        Dim strTipoCuentaNombreId As String = ""

        Select Case strTipoCuentaSeleccionada.ToUpper

            Case "CUENTA CONTABLE"
                intTipoCuentaBusquedaId = intBuscarTipoCuentaPorNombre("BANCARIA")

            Case "PSEUDOCUENTA"
                intTipoCuentaBusquedaId = intBuscarTipoCuentaPorNombre("CONTABLE")

            Case Else
                intTipoCuentaBusquedaId = 0
        End Select

        If intTipoCuentaBusquedaId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboCuentaPadre", intCuentaPadreId, Benavides.CC.Data.clsCuenta.strBuscarPorTipo(intTipoCuentaBusquedaId, 0, 0, 0, strConnectionString), 0, 3, 1)

        ElseIf intTipoCuentaId > 0 AndAlso intCuentaPadreId > 0 Then

            ' Buscamos el Nombre Id del tipo de Cuenta Recibido
            Dim astrTipoCuentaDataArray As Array = Benavides.CC.Data.clstblTipoCuenta.strBuscar(intTipoCuentaId, "", "", Now(), "", 0, 0, strConnectionString)

            ' Verificamos la existencia de resultados
            If IsArray(astrTipoCuentaDataArray) AndAlso astrTipoCuentaDataArray.Length > 0 Then

                strTipoCuentaNombreId = CStr(DirectCast(astrTipoCuentaDataArray.GetValue(0), Array).GetValue(1))

                Select Case strTipoCuentaNombreId.ToUpper

                    Case "PSEUDOCUENTA"
                        intTipoCuentaBusquedaId = intBuscarTipoCuentaPorNombre("CONTABLE")

                    Case "CONTABLE"
                        intTipoCuentaBusquedaId = intBuscarTipoCuentaPorNombre("BANCARIA")

                End Select

                Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboCuentaPadre", intCuentaPadreId, Benavides.CC.Data.clsCuenta.strBuscarPorTipo(intTipoCuentaBusquedaId, 0, 0, 0, strConnectionString), 0, 3, 1)
            End If

        Else
            Return ""
        End If

    End Function

    '====================================================================
    ' Name       : strLlenarDetalleReferenciaComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboDetalleReferencia"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarDetalleReferenciaComboBox() As String

        Select Case intTipoReferenciaId
            Case 2
                Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDetalleReferencia", intDetalleReferenciaId, Benavides.CC.Data.clstblFormaPago.strBuscar(0, "", "", "", 0, 0, 0, 0, 0, Now(), "", 0, 0, strConnectionString), 0, 2, 1)
            Case 3
                Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDetalleReferencia", intDetalleReferenciaId, Benavides.CC.Data.clstblTipoTicket.strBuscar(0, "", "", Now(), "", 0, 0, strConnectionString), 0, 2, 1)
            Case 4, 5
                Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDetalleReferencia", intDetalleReferenciaId, Benavides.CC.Data.clstblDepartamento.strBuscar(0, 0, "", Now(), "", 0, 0, strConnectionString), 0, 2, 1)
            Case Else
                Return ""
        End Select

    End Function

    '====================================================================
    ' Name       : strLlenarUbicacionBancariaComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboUbicacionBancaria"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarUbicacionBancariaComboBox() As String

        Select Case intTipoReferenciaId
            Case 2
                Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboUbicacionBancaria", intUbicacionBancariaId, Benavides.CC.Data.clstblUbicacionBanco.strBuscar(0, "", "", Now(), "", 0, 0, strConnectionString), 0, 2, 1)
            Case Else
                Return ""
        End Select

    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim intTipoCuentaBusqueda As Integer = 0
        Dim intTipoTicketId As Integer = 0

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", isocraft.commons.clsWeb.strGetPageParameter("cmdConsultar", ""), Request)

        ' Almacenamos el comando ejecutado
        intCuentaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intCuentaId", isocraft.commons.clsWeb.strGetPageParameter("txtCuentaId", "0", Request), Request))

        ' Almacenamos el tipo de cuenta
        intTipoCuentaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboTipoCuenta", "0"))

        ' Almacenamos el id de la cuenta padre
        intCuentaPadreId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboCuentaPadre", "0"))

        ' Almacenamos el id del tipo de referencia
        intTipoReferenciaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboTipoReferencia", "0"))

        ' Almacenamos el id del detalle de referencia
        intDetalleReferenciaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboDetalleReferencia", "0"))

        ' Almacenamos el id de la ubicacion bancaria
        intUbicacionBancariaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboUbicacionBancaria", "0"))

        ' Almacenamos el nombre de la cuenta
        strNombreCuenta = isocraft.commons.clsWeb.strGetPageParameter("txtCuentaNombre", "")

        ' Almacenamos el nombre id de la cuenta
        strNombreIdCuenta = isocraft.commons.clsWeb.strGetPageParameter("txtCuentaNombreId", "")

        ' Almacenamos la descripción de la cuenta
        strDescripcionCuenta = isocraft.commons.clsWeb.strGetPageParameter("txtDescripcion", "")

        ' Almacenamos el número Baan de la cuenta
        strNumeroBaan = isocraft.commons.clsWeb.strGetPageParameter("txtCuentaNumero", "")

        ' Almacenamos la bandera EsCredito
        blnEsCredito = CByte(isocraft.commons.clsWeb.strGetPageParameter("chkEsCredito", "0"))

        ' Almacenamos la bandera EsCredito
        blnComisionEsPorcentaje = CByte(isocraft.commons.clsWeb.strGetPageParameter("chkComisionEsPorcentaje", "0"))

        ' Almacenamos la comision
        fltCuentaComision = CDbl(isocraft.commons.clsWeb.strGetPageParameter("txtCuentaComision", "0"))

        Select Case strCmd

            Case "Agregar"
                strCmd = "SalvarNuevo"

            Case "Editar"

                ' Consultamos la cuenta recibida
                Dim astrDataArray As Array = Benavides.CC.Data.clstblCuenta.strBuscar(intCuentaId, 0, "", "", "", "", 0, 0, 0, Now(), "", 0, 0, strConnectionString)

                ' Verificamos la existencia de valores
                If IsArray(astrDataArray) AndAlso astrDataArray.Length > 0 Then

                    ' Obtenemos el tipo de cuenta
                    intTipoCuentaId = CInt(DirectCast(astrDataArray.GetValue(0), Array).GetValue(1))

                    ' Almacenamos el nombre id de la cuenta
                    strNombreIdCuenta = CStr(DirectCast(astrDataArray.GetValue(0), Array).GetValue(2))

                    ' Almacenamos el nombre de la cuenta
                    strNombreCuenta = CStr(DirectCast(astrDataArray.GetValue(0), Array).GetValue(3))

                    ' Almacenamos el número Baan de la cuenta
                    strNumeroBaan = CStr(DirectCast(astrDataArray.GetValue(0), Array).GetValue(4))

                    ' Almacenamos la descripción de la cuenta
                    strDescripcionCuenta = CStr(DirectCast(astrDataArray.GetValue(0), Array).GetValue(5))

                    ' Almacenamos la bandera EsCredito
                    If CStr(DirectCast(astrDataArray.GetValue(0), Array).GetValue(6)).Equals("False") Then
                        blnEsCredito = 0
                    Else
                        blnEsCredito = 1
                    End If

                    ' Almacenamos la comision
                    fltCuentaComision = CDbl(DirectCast(astrDataArray.GetValue(0), Array).GetValue(7))

                    ' Almacenamos la bandera EsPorcentaje
                    If CStr(DirectCast(astrDataArray.GetValue(0), Array).GetValue(8)).Equals("False") Then
                        blnComisionEsPorcentaje = 0
                    Else
                        blnComisionEsPorcentaje = 1
                    End If

                    ' Buscamos la cuenta relacionada
                    Dim astrCuentaRelacionadaDataArray As Array = Benavides.CC.Data.clstblCuentaRelacionada.strBuscar(intCuentaId, 0, Now(), "", 0, 0, strConnectionString)

                    ' Verificamos la existencia de valores
                    If IsArray(astrCuentaRelacionadaDataArray) AndAlso astrCuentaRelacionadaDataArray.Length > 0 Then
                        intCuentaPadreId = CInt(DirectCast(astrCuentaRelacionadaDataArray.GetValue(0), Array).GetValue(1))
                    End If

                    ' Buscamos el tipo de cuenta correspondiente a la Pseudocuenta
                    Dim astrTipoCuenta As Array = Benavides.CC.Data.clstblTipoCuenta.strBuscar(0, "Pseudocuenta", "", Now(), "", 0, 0, strConnectionString)

                    If IsArray(astrTipoCuenta) AndAlso astrTipoCuenta.Length > 0 Then
                        intTipoCuentaBusqueda = CInt(DirectCast(astrTipoCuenta.GetValue(0), Array).GetValue(0))
                    End If

                    ' Si la cuenta es una pseudocuenta entonces es necesario obtener su tipo de referencia y
                    ' el detalle de referencia
                    If intTipoCuentaId = intTipoCuentaBusqueda Then

                        Dim astrDetalleReferenciaDataArray As Array

                        ' Verificamos si la referencia es con la forma de pago
                        astrDetalleReferenciaDataArray = Benavides.CC.Data.clstblCuentaFormaPago.strBuscar(0, 0, intCuentaId, Now(), "", 0, 0, strConnectionString)

                        If IsArray(astrDetalleReferenciaDataArray) AndAlso astrDetalleReferenciaDataArray.Length > 0 Then

                            ' Asignamos el id de la forma de pago 
                            intDetalleReferenciaId = CInt(DirectCast(astrDetalleReferenciaDataArray.GetValue(0), Array).GetValue(0))

                            ' Asignamos el id de la ubicación bancaria
                            intUbicacionBancariaId = CInt(DirectCast(astrDetalleReferenciaDataArray.GetValue(0), Array).GetValue(1))

                            ' Asignamos el tipo de referencia a forma de pago
                            intTipoReferenciaId = 2

                        Else

                            ' Verificamos si la referencia es con el tipo de ticket
                            astrDetalleReferenciaDataArray = Benavides.CC.Data.clstblCuentaTipoTicket.strBuscar(0, intCuentaId, Now(), "", 0, 0, strConnectionString)

                            If IsArray(astrDetalleReferenciaDataArray) AndAlso astrDetalleReferenciaDataArray.Length > 0 Then

                                ' Asignamos el id del tipo de ticket
                                intDetalleReferenciaId = CInt(DirectCast(astrDetalleReferenciaDataArray.GetValue(0), Array).GetValue(0))

                                ' Asignamos el tipo de referencia a tipo de ticket
                                intTipoReferenciaId = 3

                            Else
                                ' Verificamos si la referencia es con Departamento
                                astrDetalleReferenciaDataArray = Benavides.CC.Data.clstblCuentaDepartamento.strBuscar(0, intCuentaId, Now(), "", 0, 0, strConnectionString)

                                If IsArray(astrDetalleReferenciaDataArray) AndAlso astrDetalleReferenciaDataArray.Length > 0 Then

                                    ' Asignamos el id del tipo de ticket
                                    intDetalleReferenciaId = CInt(DirectCast(astrDetalleReferenciaDataArray.GetValue(0), Array).GetValue(0))

                                    ' Asignamos el tipo de referencia a tipo de ticket
                                    intTipoReferenciaId = 4

                                Else
                                    ' Verificamos si la referencia es con Devolucion
                                    astrDetalleReferenciaDataArray = Benavides.CC.Data.clstblCuentaDevolucion.strBuscar(0, 0, intCuentaId, Now(), "", 0, 0, strConnectionString)

                                    If IsArray(astrDetalleReferenciaDataArray) AndAlso astrDetalleReferenciaDataArray.Length > 0 Then

                                        ' Asignamos el id del Departamento
                                        intDetalleReferenciaId = CInt(DirectCast(astrDetalleReferenciaDataArray.GetValue(0), Array).GetValue(0))

                                        ' Asignamos el id del tipo de ticket
                                        intTipoTicketId = CInt(DirectCast(astrDetalleReferenciaDataArray.GetValue(0), Array).GetValue(0))

                                        ' Asignamos el tipo de referencia a Devolucion
                                        intTipoReferenciaId = 5

                                    Else
                                        intTipoReferenciaId = 1
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

                strCmd = "Actualizar"

            Case "SalvarNuevo"

                    ' Agregamos la cuenta
                    intCuentaId = Benavides.CC.Data.clstblCuenta.intAgregar(0, intTipoCuentaId, strNombreIdCuenta, strNombreCuenta, strNumeroBaan, strDescripcionCuenta, blnEsCredito, fltCuentaComision, blnComisionEsPorcentaje, Now(), strUsuarioNombre, strConnectionString)

                    ' Verificamos que la cuenta haya sido agregada
                    If intCuentaId > 0 Then

                        ' Verificamos si se seleccionó una cuenta padre
                        If intCuentaPadreId > 0 Then

                            ' Se crea la relación de la cuenta creada con la cuenta padre
                            Call Benavides.CC.Data.clstblCuentaRelacionada.intAgregar(intCuentaId, intCuentaPadreId, Now(), strUsuarioNombre, strConnectionString)

                        End If

                        Select Case intTipoReferenciaId
                            Case 2

                                ' Creamos la referencia de la cuenta por forma de pago
                                Call Benavides.CC.Data.clstblCuentaFormaPago.intAgregar(intDetalleReferenciaId, intUbicacionBancariaId, intCuentaId, Now(), strUsuarioNombre, strConnectionString)

                            Case 3

                                ' Creamos la referencia de la cuenta por tipo de ticket
                                Call Benavides.CC.Data.clstblCuentaTipoTicket.intAgregar(intDetalleReferenciaId, intCuentaId, Now(), strUsuarioNombre, strConnectionString)

                            Case 4

                                ' Creamos la referencia de la cuenta por Departamento
                                Call Benavides.CC.Data.clstblCuentaDepartamento.intAgregar(intDetalleReferenciaId, intCuentaId, Now(), strUsuarioNombre, strConnectionString)

                            Case 5

                                ' Consultamos el id del tipo de ticket para devolución
                                Dim astrDataArray As Array = Benavides.CC.Data.clstblTipoTicket.strBuscar(0, "Devolucion", "", Now(), "", 0, 0, strConnectionString)


                                ' Verificamos la existencia de valores
                                If IsArray(astrDataArray) AndAlso astrDataArray.Length > 0 Then

                                    ' Recuperamos el id del ticket encontrado
                                    intTipoTicketId = CInt(DirectCast(astrDataArray.GetValue(0), Array).GetValue(0))

                                    ' Verificamos que el id sea válido
                                    If intTipoTicketId > 0 Then

                                        ' Creamos la referencia de la cuenta por devolucion y tipo de ticket
                                        Call Benavides.CC.Data.clstblCuentaDevolucion.intAgregar(intDetalleReferenciaId, intTipoTicketId, intCuentaId, Now(), strUsuarioNombre, strConnectionString)

                                    End If

                                End If

                        End Select

                    End If

                strCmd = "Actualizar"

            Case "Actualizar"

                Dim intRetorno As Integer = 0
                intRetorno = Benavides.CC.Data.clstblCuenta.intActualizar(intCuentaId, intTipoCuentaId, strNombreIdCuenta, strNombreCuenta, strNumeroBaan, strDescripcionCuenta, blnEsCredito, fltCuentaComision, blnComisionEsPorcentaje, Now(), strUsuarioNombre, strConnectionString)
                If intRetorno > 0 Then

                    ' En necesario eliminar todas las relaciones de la cuenta para proceder a relacionarla nuevamente
                    ' Eliminamos las cuentas relacionadas
                    Call Benavides.CC.Data.clstblCuentaRelacionada.intEliminar(intCuentaId, 0, Now(), strUsuarioNombre, strConnectionString)

                    ' Eliminamos la relacion con formas de pago
                    Call Benavides.CC.Data.clstblCuentaFormaPago.intEliminar(0, 0, intCuentaId, Now(), strUsuarioNombre, strConnectionString)

                    ' Eliminamos la relación con Tipos de Ticket
                    Call Benavides.CC.Data.clstblCuentaTipoTicket.intEliminar(0, intCuentaId, Now(), strUsuarioNombre, strConnectionString)

                    ' Eliminamos la relacion con Departamentos
                    Call Benavides.CC.Data.clstblCuentaDepartamento.intEliminar(0, intCuentaId, Now(), strUsuarioNombre, strConnectionString)

                    ' Eliminamos la relacion con departamento de devolucion
                    Call Benavides.CC.Data.clstblCuentaDevolucion.intEliminar(0, 0, intCuentaId, Now(), strUsuarioNombre, strConnectionString)

                    ' Ahora es necesario agregar las nuevas relaciones
                    ' Verificamos si se seleccionó una cuenta padre
                    If intCuentaPadreId > 0 Then

                        ' Se crea la relación de la cuenta creada con la cuenta padre
                        Call Benavides.CC.Data.clstblCuentaRelacionada.intAgregar(intCuentaId, intCuentaPadreId, Now(), strUsuarioNombre, strConnectionString)

                    End If

                    Select Case intTipoReferenciaId
                        Case 2

                            ' Creamos la referencia de la cuenta por forma de pago
                            Call Benavides.CC.Data.clstblCuentaFormaPago.intAgregar(intDetalleReferenciaId, intUbicacionBancariaId, intCuentaId, Now(), strUsuarioNombre, strConnectionString)

                        Case 3

                            ' Creamos la referencia de la cuenta por tipo de ticket
                            Call Benavides.CC.Data.clstblCuentaTipoTicket.intAgregar(intDetalleReferenciaId, intCuentaId, Now(), strUsuarioNombre, strConnectionString)

                        Case 4

                            ' Creamos la referencia de la cuenta por Departamento
                            Call Benavides.CC.Data.clstblCuentaDepartamento.intAgregar(intDetalleReferenciaId, intCuentaId, Now(), strUsuarioNombre, strConnectionString)

                        Case 5

                            ' Consultamos el id del tipo de ticket para devolución
                            Dim astrDataArray As Array = Benavides.CC.Data.clstblTipoTicket.strBuscar(0, "Devolucion", "", Now(), "", 0, 0, strConnectionString)


                            ' Verificamos la existencia de valores
                            If IsArray(astrDataArray) AndAlso astrDataArray.Length > 0 Then

                                ' Recuperamos el id del ticket encontrado
                                intTipoTicketId = CInt(DirectCast(astrDataArray.GetValue(0), Array).GetValue(0))

                                ' Verificamos que el id sea válido
                                If intTipoTicketId > 0 Then

                                    ' Creamos la referencia de la cuenta por devolucion y tipo de ticket
                                    Call Benavides.CC.Data.clstblCuentaDevolucion.intAgregar(intDetalleReferenciaId, intTipoTicketId, intCuentaId, Now(), strUsuarioNombre, strConnectionString)

                                End If

                            End If

                    End Select

                End If

                strCmd = "Actualizar"

        End Select

    End Sub

End Class