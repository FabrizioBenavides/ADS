Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert

'====================================================================
' Class         : clsSistemaRevisarRecetas
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Operaciones de páginas ASP.Net
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Joaquín Hdz. G. (joaquin@isocraft.com)
' Last Modified : Thursday, January 27, 2005
'====================================================================

Public Class clsSistemaEditarReceta
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
        intTipoFormaCapturaId = GetPageParameter("intTipoFormaCapturaId", 0)
        intCompaniaId = GetPageParameter("intCompaniaId", 0)
        intSucursalId = GetPageParameter("intSucursalId", 0)
        intCajaId = GetPageParameter("intCajaId", 0)
        intTicketId = GetPageParameter("intTicketId", 0)
        intClienteEspecialId = GetPageParameter("intClienteEspecialId", 0)
        blnDetalleFormaCapturaValorConError = GetPageParameter("blnDetalleFormaCapturaValorConError", False)
    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private intmTipoFormaCapturaId As Integer
    Private intmCompaniaId As Integer
    Private intmSucursalId As Integer
    Private intmCajaId As Integer
    Private intmTicketId As Integer
    Private intmClienteEspecialId As Integer
    Private blnmDetalleFormaCapturaValorConError As Boolean
    Private strmSucursalNombre As String
    Private strmClienteEspecial As String
    Private strmDetalleFormaCapturaUltimaModificacion As String
    Private strmFormValidatorJavascript As String
    Private strmHTMLAtributosDetalleFormaCaptura As String

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
            Return GetPageParameter("strCmd", "")
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
    ' Name       : intTipoFormaCapturaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intTipoFormaCapturaId() As Integer
        Get
            Return intmTipoFormaCapturaId
        End Get
        Set(ByVal intValue As Integer)
            intmTipoFormaCapturaId = intValue
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
    ' Name       : intCajaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intCajaId() As Integer
        Get
            Return intmCajaId
        End Get
        Set(ByVal intValue As Integer)
            intmCajaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intTicketId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intTicketId() As Integer
        Get
            Return intmTicketId
        End Get
        Set(ByVal intValue As Integer)
            intmTicketId = intValue
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
    ' Name       : blnDetalleFormaCapturaValorConError
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnDetalleFormaCapturaValorConError() As Boolean
        Get
            Return blnmDetalleFormaCapturaValorConError
        End Get
        Set(ByVal blnValue As Boolean)
            blnmDetalleFormaCapturaValorConError = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : strSucursalNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strSucursalNombre() As String
        Get
            Return strmSucursalNombre
        End Get
        Set(ByVal strValue As String)
            strmSucursalNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strClienteEspecial
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strClienteEspecial() As String
        Get
            Return strmClienteEspecial
        End Get
        Set(ByVal strValue As String)
            strmClienteEspecial = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strDetalleFormaCapturaUltimaModificacion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strDetalleFormaCapturaUltimaModificacion() As String
        Get
            Return strmDetalleFormaCapturaUltimaModificacion
        End Get
        Set(ByVal strValue As String)
            strmDetalleFormaCapturaUltimaModificacion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFormValidatorJavascript
    ' Description: Contiene el HTML de los atributos de la forma
    '              de captura
    ' Output     : String
    '====================================================================
    Public Property strFormValidatorJavascript() As String
        Get
            Return strmFormValidatorJavascript
        End Get
        Set(ByVal strValue As String)
            strmFormValidatorJavascript = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strHTMLAtributosDetalleFormaCaptura
    ' Description: Contiene el HTML de los atributos de la forma
    '              de captura
    ' Output     : String
    '====================================================================
    Public Property strHTMLAtributosDetalleFormaCaptura() As String
        Get
            Return strmHTMLAtributosDetalleFormaCaptura
        End Get
        Set(ByVal strValue As String)
            strmHTMLAtributosDetalleFormaCaptura = strValue
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Check if the current user can access this page
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Check if the access prerequisites are valid
        If intTipoFormaCapturaId = 0 OrElse intCompaniaId = 0 OrElse intSucursalId = 0 OrElse intCajaId = 0 OrElse intTicketId = 0 OrElse intClienteEspecialId = 0 Then
            Call Response.Redirect("SistemaRevisarRecetas.aspx")
        End If

        ' Execute the selected command
        Select Case strCmd

            Case "Editar"

                ' Obtenemos los atributos de la forma de captura actual
                Dim aobjData As Array = Benavides.CC.Data.clsFormaCaptura.strBuscarDetalleFormaCaptura(intTicketId, intClienteEspecialId, intCompaniaId, intSucursalId, intCajaId, #1/1/2000#, #1/1/2000#, 0, 0, strConnectionString)

                ' Si existen atributos
                If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                    ' Declaramos e inicializamos las variables que formarán el contenido de la página
                    Dim strData As System.Text.StringBuilder = New System.Text.StringBuilder
                    Dim strJavascript As System.Text.StringBuilder = New System.Text.StringBuilder

                    ' Por cada atributo existente
                    For Each aobjRecord As System.Collections.SortedList In aobjData

                        ' Obtenemos sus campos
                        Dim intAtributoId As Integer = CInt(aobjRecord.Item("intAtributoId"))
                        Dim strAtributoNombre As String = CStr(aobjRecord.Item("strAtributoNombre"))
                        Dim intAtributoValorLongitudMinima As Integer = CInt(aobjRecord.Item("intAtributoValorLongitudMinima"))
                        Dim intAtributoValorLongitudMaxima As Integer = CInt(aobjRecord.Item("intAtributoValorLongitudMaxima"))
                        Dim strAtributoValorMinimo As String = CStr(aobjRecord.Item("strAtributoValorMinimo"))
                        Dim strAtributoValorMaximo As String = CStr(aobjRecord.Item("strAtributoValorMaximo"))
                        Dim strTipoAtributoNombreId As String = CStr(aobjRecord.Item("strTipoAtributoNombreId"))
                        Dim strTipoAtributoCaracteresPermitidos As String = CStr(aobjRecord.Item("strTipoAtributoCaracteresPermitidos"))
                        Dim strClienteEspecialNombreId As String = CStr(aobjRecord.Item("strClienteEspecialNombreId"))
                        Dim strClienteEspecialNombre As String = CStr(aobjRecord.Item("strClienteEspecialNombre"))
                        Dim strDetalleFormaCapturaValor As String = CStr(aobjRecord.Item("strDetalleFormaCapturaValor"))
                        Dim dtmDetalleFormaCapturaUltimaModificacion As Date = CDate(aobjRecord.Item("dtmDetalleFormaCapturaUltimaModificacion"))
                        Dim blnDetalleFormaCapturaValorConError As Boolean = CBool(aobjRecord.Item("blnDetalleFormaCapturaValorConError"))
                        Dim strNombreCampoHTML As String = "txtAtributo_" & intAtributoId

                        ' Si se encontró un campo con error
                        If blnDetalleFormaCapturaValorConError = True Then
                            Me.blnDetalleFormaCapturaValorConError = True
                        End If

                        ' Creamos el HTML del atributo para la forma de captura
                        strSucursalNombre = CStr(aobjRecord.Item("strSucursalNombre"))
                        strClienteEspecial = strClienteEspecialNombreId & "&nbsp;" & strClienteEspecialNombre
                        strDetalleFormaCapturaUltimaModificacion = dtmDetalleFormaCapturaUltimaModificacion.ToString("dd/MM/yyyy HH:mm:ss")
                        Call strData.Append("<tr>")
                        Call strData.Append("<td class=""tdtexttablebold"">" & strAtributoNombre & "</td>")
                        Call strData.Append("<td class=""tdpadleft5""><input name=""" & strNombreCampoHTML & """ type=""text"" class=""field"" value=""" & strDetalleFormaCapturaValor & """ size=""60"" maxlength=""1024"" " & blnDetalleFormaCapturaValorConError.ToString().Replace("True", "").Replace("False", "disabled") & "/>")
                        Call strData.Append("<span class=""txredregular"">&nbsp;" & blnDetalleFormaCapturaValorConError.ToString().Replace("True", "*").Replace("False", "") & "</span> </td>")
                        Call strData.Append("</tr>")

                        ' Creamos el Javascript para validar el contenido del atributo
                        Call strJavascript.Append("  if (document.forms[0].elements[""" & strNombreCampoHTML & """].disabled == false && blnFieldValidator(document.forms[0].elements[""" & strNombreCampoHTML & """], """ & strAtributoNombre & """, """ & strTipoAtributoNombreId & """, """ & ConvertToJavascriptString(strTipoAtributoCaracteresPermitidos) & """, " & intAtributoValorLongitudMinima & ", " & intAtributoValorLongitudMaxima & ", """ & strAtributoValorMinimo & """, """ & strAtributoValorMaximo & """) == false) {" & vbCrLf)
                        Call strJavascript.Append("    return(false);" & vbCrLf)
                        Call strJavascript.Append("  }" & vbCrLf)

                    Next

                    ' Almacenamos el HTML resultante
                    strFormValidatorJavascript = strJavascript.ToString()
                    strHTMLAtributosDetalleFormaCaptura = strData.ToString()
                    strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""cmdGuardar""].disabled = " & LCase(CStr(Not Me.blnDetalleFormaCapturaValorConError)) & ";" & vbCrLf

                End If

            Case "Salvar"

                ' Obtenemos los atributos de la forma de captura actual
                Dim aobjData As Array = Benavides.CC.Data.clsFormaCaptura.strBuscarDetalleFormaCaptura(intTicketId, intClienteEspecialId, intCompaniaId, intSucursalId, intCajaId, #1/1/2000#, #1/1/2000#, 0, 0, strConnectionString)

                ' Si existen atributos
                If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                    ' Por cada atributo existente
                    For Each aobjRecord As System.Collections.SortedList In aobjData

                        ' Obtenemos sus campos
                        Dim intAtributoId As Integer = CInt(aobjRecord.Item("intAtributoId"))
                        Dim strAtributoNombre As String = CStr(aobjRecord.Item("strAtributoNombre"))
                        Dim intAtributoValorLongitudMinima As Integer = CInt(aobjRecord.Item("intAtributoValorLongitudMinima"))
                        Dim intAtributoValorLongitudMaxima As Integer = CInt(aobjRecord.Item("intAtributoValorLongitudMaxima"))
                        Dim strAtributoValorMinimo As String = CStr(aobjRecord.Item("strAtributoValorMinimo"))
                        Dim strAtributoValorMaximo As String = CStr(aobjRecord.Item("strAtributoValorMaximo"))
                        Dim strTipoAtributoNombreId As String = CStr(aobjRecord.Item("strTipoAtributoNombreId"))
                        Dim strTipoAtributoCaracteresPermitidos As String = CStr(aobjRecord.Item("strTipoAtributoCaracteresPermitidos"))
                        Dim strClienteEspecialNombreId As String = CStr(aobjRecord.Item("strClienteEspecialNombreId"))
                        Dim strClienteEspecialNombre As String = CStr(aobjRecord.Item("strClienteEspecialNombre"))
                        Dim dtmDetalleFormaCapturaUltimaModificacion As Date = CDate(aobjRecord.Item("dtmDetalleFormaCapturaUltimaModificacion"))
                        Dim intTipoTicketId As Integer = CInt(aobjRecord.Item("intTipoTicketId"))
                        Dim intEmpleadoId As Integer = CInt(aobjRecord.Item("intEmpleadoId"))
                        Dim intEstadoOperativoCajaId As Integer = CInt(aobjRecord.Item("intEstadoOperativoCajaId"))
                        Dim intTurnoLaboralId As Integer = CInt(aobjRecord.Item("intTurnoLaboralId"))
                        Dim intAsignacionCajaId As Integer = CInt(aobjRecord.Item("intAsignacionCajaId"))
                        Dim blnDetalleFormaCapturaValorConError As Boolean = CBool(aobjRecord.Item("blnDetalleFormaCapturaValorConError"))
                        Dim intTipoFormaCapturaId As Integer = CInt(aobjRecord.Item("intTipoFormaCapturaId"))
                        Dim intCompaniaId As Integer = CInt(aobjRecord.Item("intCompaniaId"))
                        Dim intSucursalId As Integer = CInt(aobjRecord.Item("intSucursalId"))
                        Dim intCajaId As Integer = CInt(aobjRecord.Item("intCajaId"))
                        Dim intTicketId As Integer = CInt(aobjRecord.Item("intTicketId"))
                        Dim intClienteEspecialId As Integer = CInt(aobjRecord.Item("intClienteEspecialId"))
                        Dim strNombreCampoHTML As String = "txtAtributo_" & intAtributoId
                        Dim strDetalleFormaCapturaValor As String

                        ' Obtenemos el valor del atributo escrito en la forma
                        strDetalleFormaCapturaValor = GetPageParameter(strNombreCampoHTML, "")

                        ' Si el atributo contiene algún valor
                        If Len(strDetalleFormaCapturaValor) > 0 AndAlso blnDetalleFormaCapturaValorConError = True AndAlso intAtributoId > 0 AndAlso intEmpleadoId > 0 Then

                            ' Actualizamos el atributo
                            Call Benavides.CC.Data.clstblDetalleFormaCaptura.intActualizar(intAtributoId, intTipoFormaCapturaId, intCompaniaId, intSucursalId, intTipoTicketId, intCajaId, intEmpleadoId, intEstadoOperativoCajaId, intTurnoLaboralId, intAsignacionCajaId, intTicketId, intClienteEspecialId, strDetalleFormaCapturaValor, Now(), strUsuarioNombre, False, strConnectionString)

                            ' Regresamos al listado de formas con error
                            Call Response.Redirect("SistemaRevisarRecetas.aspx")

                        End If

                    Next

                End If

        End Select

    End Sub

End Class
