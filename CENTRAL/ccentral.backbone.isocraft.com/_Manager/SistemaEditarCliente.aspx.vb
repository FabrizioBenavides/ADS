Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert

'====================================================================
' Class         : clsSistemaEditarCliente
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Joaquín Hdz. G. (joaquin@isocraft.com)
' Last Modified : Monday, January 10, 2005
'====================================================================

Public Class clsSistemaEditarCliente
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
        strClienteEspecialNombreId = GetPageParameter("txtClienteEspecialNombreId", "")
        strClienteEspecialNombre = GetPageParameter("txtClienteEspecialNombre", "")
        fltClienteEspecialDescuento = GetPageParameter("txtClienteEspecialDescuento", CDec(0))
        dtmClienteEspecialVigencia = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(GetPageParameter("txtClienteEspecialVigencia", Now().ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture))))
        fltClienteEspecialMinimoPorcentajeCopago = GetPageParameter("txtClienteEspecialMinimoPorcentajeCopago", CDec(0))
        fltClienteEspecialMaximoPorcentajeCopago = GetPageParameter("txtClienteEspecialMaximoPorcentajeCopago", CDec(0))
        fltClienteEspecialMinimoImporteCopago = GetPageParameter("txtClienteEspecialMinimoImporteCopago", CDec(0))
        fltClienteEspecialMaximoImporteCopago = GetPageParameter("txtClienteEspecialMaximoImporteCopago", CDec(0))
        blnClienteEspecialActivo = GetPageParameter("chkClienteEspecialActivo", False)
        blnClienteEspecialPagoDeContado = GetPageParameter("chkClienteEspecialPagoDeContado", False)
        blnClienteEspecialRespetarOfertas = GetPageParameter("chkClienteEspecialRespetarOfertas", False)
        blnClienteEspecialExcedidoEnLimiteCredito = GetPageParameter("chkClienteEspecialExcedidoEnLimiteCredito", False)
        intTipoFormaCapturaId = GetPageParameter("cboClientEspecialTipoFormaCaptura", 0)
        intClienteEspecialId = GetPageParameter("intClienteEspecialId", GetPageParameter("txtClienteEspecialId", 0))
        intGrupoClienteEspecialId = GetPageParameter("cboGrupoClienteEspecial", GetPageParameter("txtGrupoClienteEspecialId", 0))
        intCompaniaId = GetPageParameter("intCompaniaId", 0)
        intSucursalId = GetPageParameter("intSucursalId", 0)
        strJavascriptWindowOnLoadCommands = ""
    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private strmtxtClienteEspecialNombreId As String
    Private strmtxtClienteEspecialNombre As String
    Private strmtxtClienteEspecialDescuento As Decimal
    Private strmtxtClienteEspecialVigencia As DateTime
    Private strmtxtClienteEspecialMinimoPorcentajeCopago As Decimal
    Private strmtxtClienteEspecialMaximoPorcentajeCopago As Decimal
    Private strmtxtClienteEspecialMinimoImporteCopago As Decimal
    Private strmtxtClienteEspecialMaximoImporteCopago As Decimal
    Private strmchkClienteEspecialActivo As Boolean
    Private strmchkClienteEspecialPagoDeContado As Boolean
    Private strmchkClienteEspecialRespetarOfertas As Boolean
    Private blnmClienteEspecialExcedidoEnLimiteCredito As Boolean
    Private strmcboClientEspecialTipoFormaCaptura As Integer
    Private intmClienteEspecialId As Integer
    Private intmGrupoClienteEspecialId As Integer
    Private intmCompaniaId As Integer
    Private intmSucursalId As Integer

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
            Return GetPageParameter("strCmd", GetPageParameter("strRBCmd", ""))
        End Get
    End Property

    '====================================================================
    ' Name       : strClienteEspecialNombreId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strClienteEspecialNombreId() As String
        Get
            Return strmtxtClienteEspecialNombreId
        End Get
        Set(ByVal strValue As String)
            strmtxtClienteEspecialNombreId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strClienteEspecialNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strClienteEspecialNombre() As String
        Get
            Return strmtxtClienteEspecialNombre
        End Get
        Set(ByVal strValue As String)
            strmtxtClienteEspecialNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltClienteEspecialDescuento
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Decimal
    '====================================================================
    Public Property fltClienteEspecialDescuento() As Decimal
        Get
            Return strmtxtClienteEspecialDescuento
        End Get
        Set(ByVal fltValue As Decimal)
            strmtxtClienteEspecialDescuento = fltValue
        End Set
    End Property

    '====================================================================
    ' Name       : dtmClienteEspecialVigencia
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : DateTime
    '====================================================================
    Public Property dtmClienteEspecialVigencia() As DateTime
        Get
            Return strmtxtClienteEspecialVigencia
        End Get
        Set(ByVal dtmValue As DateTime)
            strmtxtClienteEspecialVigencia = dtmValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltClienteEspecialMinimoPorcentajeCopago
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Decimal
    '====================================================================
    Public Property fltClienteEspecialMinimoPorcentajeCopago() As Decimal
        Get
            Return strmtxtClienteEspecialMinimoPorcentajeCopago
        End Get
        Set(ByVal fltValue As Decimal)
            strmtxtClienteEspecialMinimoPorcentajeCopago = fltValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltClienteEspecialMaximoPorcentajeCopago
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Decimal
    '====================================================================
    Public Property fltClienteEspecialMaximoPorcentajeCopago() As Decimal
        Get
            Return strmtxtClienteEspecialMaximoPorcentajeCopago
        End Get
        Set(ByVal fltValue As Decimal)
            strmtxtClienteEspecialMaximoPorcentajeCopago = fltValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltClienteEspecialMinimoImporteCopago
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Decimal
    '====================================================================
    Public Property fltClienteEspecialMinimoImporteCopago() As Decimal
        Get
            Return strmtxtClienteEspecialMinimoImporteCopago
        End Get
        Set(ByVal fltValue As Decimal)
            strmtxtClienteEspecialMinimoImporteCopago = fltValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltClienteEspecialMaximoImporteCopago
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property fltClienteEspecialMaximoImporteCopago() As Decimal
        Get
            Return strmtxtClienteEspecialMaximoImporteCopago
        End Get
        Set(ByVal fltValue As Decimal)
            strmtxtClienteEspecialMaximoImporteCopago = fltValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnClienteEspecialActivo
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnClienteEspecialActivo() As Boolean
        Get
            Return strmchkClienteEspecialActivo
        End Get
        Set(ByVal blnValue As Boolean)
            strmchkClienteEspecialActivo = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnClienteEspecialPagoDeContado
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnClienteEspecialPagoDeContado() As Boolean
        Get
            Return strmchkClienteEspecialPagoDeContado
        End Get
        Set(ByVal blnValue As Boolean)
            strmchkClienteEspecialPagoDeContado = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnClienteEspecialRespetarOfertas
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnClienteEspecialRespetarOfertas() As Boolean
        Get
            Return strmchkClienteEspecialRespetarOfertas
        End Get
        Set(ByVal blnValue As Boolean)
            strmchkClienteEspecialRespetarOfertas = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnClienteEspecialExcedidoEnLimiteCredito
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnClienteEspecialExcedidoEnLimiteCredito() As Boolean
        Get
            Return blnmClienteEspecialExcedidoEnLimiteCredito
        End Get
        Set(ByVal blnValue As Boolean)
            blnmClienteEspecialExcedidoEnLimiteCredito = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : intClienteEspecialId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intClienteEspecialId() As Integer
        Get
            Return intmClienteEspecialId
        End Get
        Set(ByVal intValue As Integer)
            intmClienteEspecialId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intGrupoClienteEspecialId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intGrupoClienteEspecialId() As Integer
        Get
            Return intmGrupoClienteEspecialId
        End Get
        Set(ByVal intValue As Integer)
            intmGrupoClienteEspecialId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intTipoFormaCapturaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intTipoFormaCapturaId() As Integer
        Get
            Return strmcboClientEspecialTipoFormaCaptura
        End Get
        Set(ByVal intValue As Integer)
            strmcboClientEspecialTipoFormaCaptura = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intCompaniaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intCompaniaId() As Integer
        Get
            Return intmCompaniaId
        End Get
        Set(ByVal intValue As Integer)
            intmCompaniaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intSucursalId() As Integer
        Get
            Return intmSucursalId
        End Get
        Set(ByVal intValue As Integer)
            intmSucursalId = intValue
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
    ' Name       : strLlenarGrupoClienteEspecialComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboGrupoClienteEspecial"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarGrupoClienteEspecialComboBox() As String
        Dim aobjData As Array = Benavides.CC.Data.clstblGrupoClienteEspecial.strBuscar(0, "", "", Now(), "", 0, 0, strConnectionString)
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboGrupoClienteEspecial", intGrupoClienteEspecialId, aobjData, 0, 1, 1)
    End Function

    '====================================================================
    ' Name       : strLlenarClientEspecialTipoFormaCapturaComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboClientEspecialTipoFormaCaptura"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarClientEspecialTipoFormaCapturaComboBox() As String
        Dim aobjData As Array = Benavides.CC.Data.clstblTipoFormaCaptura.strBuscar(0, "", "", "", Now(), "", False, "", 0, 0, strConnectionString)
        Return CreateJavascriptComboBoxOptions("cboClientEspecialTipoFormaCaptura", CStr(intTipoFormaCapturaId), aobjData, "intTipoFormaCapturaId", "strTipoFormaCapturaNombre", 1)
    End Function

    '====================================================================
    ' Name       : strGetRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String

        If intClienteEspecialId > 0 Then

            ' Declaramos e inicializamos las constantes locales
            Const intElementsPerPage As Integer = 50
            Const strRecordBrowserName As String = "SistemaEditarCliente"

            ' Declaramos e inicializamos las variables locales
            Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
            Dim astrDataArray As Array = Benavides.CC.Data.clsClienteEspecialSucursal.strBuscarSucursales(intClienteEspecialId, 0, 0, Now(), "", Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)
            Dim astrDataRow As Array

            ' Establecemos los párametros adicionales de los números de página
            Dim strQueryString As String = _
                "txtClienteEspecialNombreId=" & strClienteEspecialNombreId & _
                "&txtClienteEspecialNombre=" & Trim(strClienteEspecialNombre) & _
                "&txtClienteEspecialDescuento=" & fltClienteEspecialDescuento & _
                "&txtClienteEspecialVigencia=" & dtmClienteEspecialVigencia.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) & _
                "&txtClienteEspecialMaximoPorcentajeCopago=" & fltClienteEspecialMaximoPorcentajeCopago & _
                "&txtClienteEspecialMaximoImporteCopago=" & fltClienteEspecialMaximoImporteCopago & _
                "&txtClienteEspecialMinimoPorcentajeCopago=" & fltClienteEspecialMinimoPorcentajeCopago & _
                "&txtClienteEspecialMinimoImporteCopago=" & fltClienteEspecialMinimoImporteCopago & _
                "&chkClienteEspecialActivo=" & blnClienteEspecialActivo & _
                "&chkClienteEspecialPagoDeContado=" & blnClienteEspecialPagoDeContado & _
                "&chkClienteEspecialRespetarOfertas=" & blnClienteEspecialRespetarOfertas & _
                "&chkClienteEspecialExcedidoEnLimiteCredito=" & blnClienteEspecialExcedidoEnLimiteCredito & _
                "&cboClientEspecialTipoFormaCaptura=" & intTipoFormaCapturaId & _
                "&txtClienteEspecialId=" & intClienteEspecialId & _
                "&cboGrupoClienteEspecial=" & intGrupoClienteEspecialId & _
                "&strRBCmd=Editar"

            ' Agregamos los botones para asignar y borrar sucursales
            Dim strTextToBeReplaced As String = "<span class=""txsubtitulo""><img src=""../static/images/bullet_subtitulos.gif"" width=""17"" height=""11"" align=""absmiddle"">Sucursales asignadas</span>"
            Dim strNewText As String = "<span class=""txsubtitulo""><img src=""../static/images/bullet_subtitulos.gif"" width=""17"" height=""11"" align=""absmiddle"">Sucursales asignadas</span><input name=""cmdAsignarSucursales"" type=""button"" class=""button"" id=""cmdAsignarSucursales"" value=""Asignar sucursales"" language=javascript onclick=""return cmdAsignarSucursales_onclick()""/>&nbsp;&nbsp;<input name=""cmdBorrarTodasSucursales"" type=""submit"" class=""button"" id=""cmdBorrarTodasSucursales"" value=""Borrar todas"" language=javascript onclick=""return cmdBorrarTodasSucursales_onclick()""/><br />"

            ' Generamos el navegador de registros
            Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?" & strQueryString & "&").Replace(strTextToBeReplaced, strNewText)

        End If

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Check if the current user can access this page
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Execute the selected command
        Select Case strCmd

            Case "Editar"

                ' Si el identificador del elemento es válido
                If intClienteEspecialId > 0 Then

                    ' Obtenemos el elemento
                    Dim aobjData As Array = Benavides.CC.Data.clstblClienteEspecial.strBuscar(intClienteEspecialId, 0, "", "", False, 0, Now(), 0, 0, Now(), "", 0, 0, False, False, False, 0, 0, strConnectionString)

                    ' Si el elemento fue encontrado
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        Dim aobjRow As System.Collections.SortedList = DirectCast(aobjData.GetValue(0), System.Collections.SortedList)

                        ' Recuperamos sus datos
                        intClienteEspecialId = CInt(aobjRow.Item("intClienteEspecialId"))
                        intGrupoClienteEspecialId = CInt(aobjRow.Item("intGrupoClienteEspecialId"))
                        strClienteEspecialNombreId = CStr(ConvertObject(aobjRow.Item("strClienteEspecialNombreId"), TypeCode.String))
                        strClienteEspecialNombre = CStr(ConvertObject(aobjRow.Item("strClienteEspecialNombre"), TypeCode.String))
                        fltClienteEspecialDescuento = CDec(aobjRow.Item("fltClienteEspecialDescuento"))
                        dtmClienteEspecialVigencia = CDate(ConvertObject(aobjRow.Item("dtmClienteEspecialVigencia"), TypeCode.DateTime))
                        fltClienteEspecialMinimoPorcentajeCopago = CDec(aobjRow.Item("fltClienteEspecialMinimoPorcentajeCopago"))
                        fltClienteEspecialMaximoPorcentajeCopago = CDec(aobjRow.Item("fltClienteEspecialMaximoPorcentajeCopago"))
                        fltClienteEspecialMinimoImporteCopago = CDec(aobjRow.Item("fltClienteEspecialMinimoImporteCopago"))
                        fltClienteEspecialMaximoImporteCopago = CDec(aobjRow.Item("fltClienteEspecialMaximoImporteCopago"))
                        blnClienteEspecialActivo = CBool(aobjRow.Item("blnClienteEspecialActivo"))
                        blnClienteEspecialPagoDeContado = CBool(aobjRow.Item("blnClienteEspecialPagoDeContado"))
                        blnClienteEspecialRespetarOfertas = CBool(aobjRow.Item("blnClienteEspecialRespetarOfertas"))
                        blnClienteEspecialExcedidoEnLimiteCredito = CBool(aobjRow.Item("blnClienteEspecialExcedidoEnLimiteCredito"))

                        ' Buscamos el tipo de forma de captura asociada, si su identificador es válido
                        If intClienteEspecialId > 0 Then

                            aobjData = Benavides.CC.Data.clstblClienteEspecialTipoFormaCaptura.strBuscar(0, intClienteEspecialId, Now(), "", 0, 0, strConnectionString)

                            If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                                aobjRow = DirectCast(aobjData.GetValue(0), System.Collections.SortedList)
                                intTipoFormaCapturaId = CInt(aobjRow.Item("intTipoFormaCapturaId"))

                            End If

                        End If

                    End If

                Else

                    ' Identificador inválido, direccionamos al usuario a la página padre
                    Call Response.Redirect("SistemaAdministrarClientes.aspx")

                End If

            Case "Salvar"

                ' Si los identificadores del elemento son válidos
                If intClienteEspecialId > 0 AndAlso intGrupoClienteEspecialId > 0 Then

                    ' Actualizamos la información del cliente especial
                    If Benavides.CC.Data.clstblClienteEspecial.intActualizar(intClienteEspecialId, intGrupoClienteEspecialId, strClienteEspecialNombreId, strClienteEspecialNombre, blnClienteEspecialPagoDeContado, fltClienteEspecialDescuento, dtmClienteEspecialVigencia, fltClienteEspecialMaximoPorcentajeCopago, fltClienteEspecialMaximoImporteCopago, Now(), strUsuarioNombre, fltClienteEspecialMinimoPorcentajeCopago, fltClienteEspecialMinimoImporteCopago, blnClienteEspecialActivo, blnClienteEspecialRespetarOfertas, blnClienteEspecialExcedidoEnLimiteCredito, strConnectionString) < 0 Then

                        strJavascriptWindowOnLoadCommands &= "  alert(""ERROR: La información del CLIENTE ESPECIAL no pudo ser actualizada en la base de datos.\n\r\n\rPor favor informe este error a su administrador o personal a cargo."");" & vbCrLf

                    Else

                        ' Si el identificador del tipo de forma de captura es válido
                        If intTipoFormaCapturaId > 0 Then

                            ' Eliminamos el registro actual
                            Call Benavides.CC.Data.clstblClienteEspecialTipoFormaCaptura.intEliminar(intTipoFormaCapturaId, intClienteEspecialId, Now(), strUsuarioNombre, strConnectionString)

                            ' Agregamos el nuevo registro
                            If Benavides.CC.Data.clstblClienteEspecialTipoFormaCaptura.intAgregar(intTipoFormaCapturaId, intClienteEspecialId, Now(), strUsuarioNombre, strConnectionString) < 0 Then
                                strJavascriptWindowOnLoadCommands &= "  alert(""ERROR: La información del TIPO DE RECETA A UTILIZAR no pudo ser actualizada en la base de datos.\n\r\n\rPor favor informe este error a su administrador o personal a cargo."");" & vbCrLf
                            End If

                        End If

                        ' Si el cliente especial pertenece al grupo "Bonos"
                        If intGrupoClienteEspecialId = 6 Then

                            ' Buscamos al cliente especial como emisor de formas de pago
                            Dim objEmisorFormaPago As Array = Benavides.CC.Data.clstblEmisorFormaPago.strBuscar(0, strClienteEspecialNombreId, "", Now(), Now(), "", 0, 0, strConnectionString)

                            ' Si el emisor (cliente) fue encontrado
                            If IsNothing(objEmisorFormaPago) = False AndAlso objEmisorFormaPago.Length > 0 Then

                                ' Obtenemos la información del emisor
                                Dim intEmisorFormaPagoId As Integer = CInt(DirectCast(objEmisorFormaPago.GetValue(0), Array).GetValue(0))
                                Dim strEmisorFormaPagoNombreId As String = CStr(DirectCast(objEmisorFormaPago.GetValue(0), Array).GetValue(1))
                                Dim strEmisorFormaPagoNombre As String = CStr(DirectCast(objEmisorFormaPago.GetValue(0), Array).GetValue(2))

                                ' Si la información del emisor está correcta
                                If intEmisorFormaPagoId > 0 AndAlso Len(strEmisorFormaPagoNombreId) > 0 Then

                                    ' Actualizamos la información del emisor
                                    Call Benavides.CC.Data.clstblEmisorFormaPago.intActualizar(intEmisorFormaPagoId, strEmisorFormaPagoNombreId, strEmisorFormaPagoNombre, dtmClienteEspecialVigencia, Now(), strUsuarioNombre, strConnectionString)

                                End If

                            End If

                        End If

                    End If

                End If

            Case "Eliminar"

                ' Si el identificador del elemento es válido, eliminamos las sucursales del cliente
                If intClienteEspecialId > 0 AndAlso intCompaniaId > 0 AndAlso intSucursalId > 0 Then

                    ' Buscamos el registro a eliminar
                    Dim aobjData As Array = Benavides.CC.Data.clstblClienteEspecialSucursal.strBuscar(intClienteEspecialId, intCompaniaId, intSucursalId, Now(), strUsuarioNombre, 0, 0, strConnectionString)

                    ' Si el registro existe
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        ' Buscamos la sucursal destino
                        Dim aobjBranchOffice As Array = Benavides.CC.Data.clstblSucursal.strBuscar(intCompaniaId, intSucursalId, 0, 0, "", 0, 0, 0, Now, "", "", "", "", 0, 0, strConnectionString)

                        ' Si la sucursal destino existe
                        If IsNothing(aobjBranchOffice) = False AndAlso aobjBranchOffice.Length > 0 Then

                            ' Obtenemos el identificador de la tienda
                            Dim intTiendaId As Integer = CInt(DirectCast(aobjBranchOffice.GetValue(0), Array).GetValue(2))

                            ' Si el identificador de la tienda es válido
                            If intTiendaId > 0 Then

                                ' Buscamos la tienda
                                Dim aobjStore As Array = Benavides.CC.Data.clstblTienda.strBuscar(intTiendaId, 0, 0, "", "", 0, "", 0, "", "", Now, "", 0, 0, strConnectionString)

                                ' Si la tienda existe
                                If IsNothing(aobjStore) = False AndAlso aobjStore.Length > 0 Then

                                    ' Enviamos el mensaje
                                    Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeHaciaServidoresPuntoDeVenta("clstblClienteEspecialSucursal", Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ELIMINAR, "POS", aobjData, aobjStore)

                                    ' Si el cliente especial pertenece al grupo "Bonos"
                                    If intGrupoClienteEspecialId = 6 Then

                                        ' Buscamos al cliente especial como emisor de formas de pago
                                        Dim objEmisorFormaPago As Array = Benavides.CC.Data.clstblEmisorFormaPago.strBuscar(0, strClienteEspecialNombreId, "", Now(), Now(), "", 0, 0, strConnectionString)

                                        ' Si el emisor (cliente) fue encontrado
                                        If IsNothing(objEmisorFormaPago) = False AndAlso objEmisorFormaPago.Length > 0 Then

                                            ' Obtenemos la información del emisor
                                            Dim intEmisorFormaPagoId As Integer = CInt(DirectCast(objEmisorFormaPago.GetValue(0), Array).GetValue(0))

                                            ' Si el identificador del emisor es correcta
                                            If intEmisorFormaPagoId > 0 Then

                                                ' Obtenemos la información del emisor en la sucursal
                                                Dim aobjEmisorFormaPagoSucursal As Array = Benavides.CC.Data.clstblEmisorFormaPagoSucursal.strBuscar(intEmisorFormaPagoId, intCompaniaId, intSucursalId, Now(), strUsuarioNombre, 0, 0, strConnectionString)

                                                ' Si el emisor existe en la sucursal
                                                If IsNothing(aobjEmisorFormaPagoSucursal) = False AndAlso aobjEmisorFormaPagoSucursal.Length > 0 Then

                                                    ' Enviamos un mensaje indicando que éste debe eliminarse como un emisor de formas de pago
                                                    Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeHaciaServidoresPuntoDeVenta("clstblEmisorFormaPagoSucursal", Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ELIMINAR, "POS", aobjEmisorFormaPagoSucursal, aobjStore)

                                                End If

                                            End If

                                        End If

                                    End If

                                End If

                            End If

                            ' Eliminamos el registro
                            Call Benavides.CC.Data.clstblClienteEspecialSucursal.intEliminar(intClienteEspecialId, intCompaniaId, intSucursalId, Now(), strUsuarioNombre, strConnectionString)

                        End If

                    End If

                End If

            Case "EliminarSucursales"

                ' Si el identificador del elemento es válido, eliminamos las sucursales del cliente
                If intClienteEspecialId > 0 Then

                    ' Buscamos los registros a eliminar
                    Dim aobjData As Array = Benavides.CC.Data.clstblClienteEspecialSucursal.strBuscar(intClienteEspecialId, 0, 0, Now(), strUsuarioNombre, 0, 0, strConnectionString)

                    ' Si los registros existen
                    If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                        ' Por cada registro encontrado
                        For Each aobjRow As Array In aobjData

                            ' Obtenemos la compañía y sucursal del registro actual
                            Dim intCompaniaDestinoId As Integer = CInt(aobjRow.GetValue(1))
                            Dim intSucursalDestinoId As Integer = CInt(aobjRow.GetValue(2))

                            ' Si los identificadores de la compañía y sucursal son válidos
                            If intCompaniaDestinoId > 0 AndAlso intSucursalDestinoId > 0 Then

                                ' Buscamos la sucursal destino
                                Dim aobjBranchOffice As Array = Benavides.CC.Data.clstblSucursal.strBuscar(intCompaniaDestinoId, intSucursalDestinoId, 0, 0, "", 0, 0, 0, Now, "", "", "", "", 0, 0, strConnectionString)

                                ' Si la sucursal destino existe
                                If IsNothing(aobjBranchOffice) = False AndAlso aobjBranchOffice.Length > 0 Then

                                    ' Obtenemos el identificador de la tienda
                                    Dim intTiendaId As Integer = CInt(DirectCast(aobjBranchOffice.GetValue(0), Array).GetValue(2))

                                    ' Si el identificador de la tienda es válido
                                    If intTiendaId > 0 Then

                                        ' Buscamos la tienda
                                        Dim aobjStore As Array = Benavides.CC.Data.clstblTienda.strBuscar(intTiendaId, 0, 0, "", "", 0, "", 0, "", "", Now, "", 0, 0, strConnectionString)

                                        ' Si la tienda existe
                                        If IsNothing(aobjStore) = False AndAlso aobjStore.Length > 0 Then

                                            ' Enviamos el mensaje
                                            Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeHaciaServidoresPuntoDeVenta("clstblClienteEspecialSucursal", Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ELIMINAR, "POS", aobjData, aobjStore)

                                            ' Si el cliente especial pertenece al grupo "Bonos"
                                            If intGrupoClienteEspecialId = 6 Then

                                                ' Buscamos al cliente especial como emisor de formas de pago
                                                Dim objEmisorFormaPago As Array = Benavides.CC.Data.clstblEmisorFormaPago.strBuscar(0, strClienteEspecialNombreId, "", Now(), Now(), "", 0, 0, strConnectionString)

                                                ' Si el emisor (cliente) fue encontrado
                                                If IsNothing(objEmisorFormaPago) = False AndAlso objEmisorFormaPago.Length > 0 Then

                                                    ' Obtenemos la información del emisor
                                                    Dim intEmisorFormaPagoId As Integer = CInt(DirectCast(objEmisorFormaPago.GetValue(0), Array).GetValue(0))

                                                    ' Si el identificador del emisor es correcta
                                                    If intEmisorFormaPagoId > 0 Then

                                                        ' Obtenemos la información del emisor en la sucursal
                                                        Dim aobjEmisorFormaPagoSucursal As Array = Benavides.CC.Data.clstblEmisorFormaPagoSucursal.strBuscar(intEmisorFormaPagoId, intCompaniaDestinoId, intSucursalDestinoId, Now(), strUsuarioNombre, 0, 0, strConnectionString)

                                                        ' Si el emisor existe en la sucursal
                                                        If IsNothing(aobjEmisorFormaPagoSucursal) = False AndAlso aobjEmisorFormaPagoSucursal.Length > 0 Then

                                                            ' Enviamos un mensaje indicando que éste debe eliminarse como un emisor de formas de pago
                                                            Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeHaciaServidoresPuntoDeVenta("clstblEmisorFormaPagoSucursal", Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ELIMINAR, "POS", aobjEmisorFormaPagoSucursal, aobjStore)

                                                        End If

                                                    End If

                                                End If

                                            End If

                                        End If

                                    End If

                                End If

                            End If

                        Next

                        ' Eliminamos los registros
                        Call Benavides.CC.Data.clstblClienteEspecialSucursal.intEliminar(intClienteEspecialId, 0, 0, Now(), strUsuarioNombre, strConnectionString)

                    End If

                End If

            Case Else

                ' Comando inválido, direccionamos al usuario a la página padre
                Call Response.Redirect("SistemaAdministrarClientes.aspx")

        End Select

    End Sub

End Class
