Imports System.Text
Imports Isocraft.Web.Http
'====================================================================
' Class         : clsSucursalVerDetalleDeCajas
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Ver el detalle de cajas en sucursales
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Javier Ramos
' Version       : 1.0
' Last Modified : Thursday, June 17, 2004
'====================================================================
Public Class clsSucursalVerDetalleDeCajas
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
    Private intmDireccionId As Integer
    Private intmZonaId As Integer
    Private intmCompaniaId As Integer
    Private intmSucursalId As Integer
    Private intmCajaId As Integer
    Private strmSucursalNombre As String
    Private strmEstado As String
    Private strmUbicacion As String
    Private strmCajaNombre As String
    Private strmCajaNombreId As String
    Private strmCajaRazonCambio As String
    Private strmCajaUltimaModificacion As String
    Private strmCajaDireccionIp As String
    Private strmCompaniaSucursalCaja As String

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
    ' Throws     : None
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
    ' Name       : intCompaniaId
    ' Description: Identificador de la Compania
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intCompaniaId() As Integer
        Get
            Dim astrCompaniaId As Array = Split(strCompaniaSucursalCaja, "|")
            Dim intValue As Integer = CInt(astrCompaniaId.GetValue(0))
            If intValue = 0 Then
                intValue = CInt(isocraft.commons.clsWeb.strGetPageParameter("intCompaniaId", "0"))
            End If
            Return intValue
        End Get
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Identificador de la Sucursal
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intSucursalId() As Integer
        Get
            Dim astrSucursalId As Array = Split(strCompaniaSucursalCaja, "|")
            Dim intValue As Integer = CInt(astrSucursalId.GetValue(1))
            If intValue = 0 Then
                intValue = CInt(isocraft.commons.clsWeb.strGetPageParameter("intSucursalId", "0"))
            End If
            Return intValue
        End Get
    End Property

    '====================================================================
    ' Name       : intCajaId
    ' Description: Identificador de la Caja
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCajaId() As Integer
        Get
            Dim astrToken As Array = isocraft.commons.clsWeb.strGetPageParameter("cboCaja", "").Split("|"c)
            Dim strCajaId As String = "0"
            If IsArray(astrToken) = True AndAlso astrToken.Length = 3 Then
                strCajaId = CStr(astrToken.GetValue(2))
            End If
            intmCajaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intCajaId", strCajaId))
            Return intmCajaId
        End Get
    End Property

    '====================================================================
    ' Name       : strCompaniaSucursalCaja
    ' Description: Identificador de la Compania, la Sucursal y la caja
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCompaniaSucursalCaja() As String
        Get
            If Len(strmCompaniaSucursalCaja) = 0 Then
                strmCompaniaSucursalCaja = isocraft.commons.clsWeb.strGetPageParameter("cboCaja", "0|0|0")
            End If
            Return strmCompaniaSucursalCaja
        End Get
    End Property

    '====================================================================
    ' Name       : strDireccionOperativaNombre
    ' Description: Nombre de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strSucursalNombre() As String
        Get
            If intCompaniaId > 0 AndAlso intSucursalId > 0 Then
                Dim astrData As Array = Benavides.CC.Data.clstblSucursal.strBuscar(intCompaniaId, intSucursalId, 0, 0, "", 0, 0, 0, Now, "", "", "", "", 0, 0, strConnectionString)
                If IsArray(astrData) = True AndAlso astrData.Length > 0 Then
                    Return CStr(DirectCast(astrData.GetValue(0), Array).GetValue(4))
                End If
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strEstado 
    ' Description: Establece el estado de la caja
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strEstado() As String
        Get
            Return strmEstado
        End Get
        Set(ByVal strValue As String)
            strmEstado = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strUbicacion 
    ' Description: Establece la ubicacion de la caja
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strUbicacion() As String
        Get
            Return strmUbicacion
        End Get
        Set(ByVal strValue As String)
            strmUbicacion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCajaNombre 
    ' Description: Establece la ubicacion de la caja
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strCajaNombre() As String
        Get
            Return strmCajaNombre
        End Get
        Set(ByVal strValue As String)
            strmCajaNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCajaNombreId 
    ' Description: Establece el nombre de la caja
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strCajaNombreId() As String
        Get
            Return strmCajaNombreId
        End Get
        Set(ByVal strValue As String)
            strmCajaNombreId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCajaRazonCambio 
    ' Description: Establece la razon del cambio de la caja
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strCajaRazonCambio() As String
        Get
            Return strmCajaRazonCambio
        End Get
        Set(ByVal strValue As String)
            strmCajaRazonCambio = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCajaDireccionIp 
    ' Description: Establece la direccionIP de la caja
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strCajaDireccionIp() As String
        Get
            Return strmCajaDireccionIp
        End Get
        Set(ByVal strValue As String)
            strmCajaDireccionIp = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCajaUltimaModificacion 
    ' Description: Establece la razon del cambio de la caja
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strCajaUltimaModificacion() As String
        Get
            Return strmCajaUltimaModificacion
        End Get
        Set(ByVal strValue As String)
            strmCajaUltimaModificacion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strLlenarCajaComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboCaja"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarCajaComboBox() As String
        If intCompaniaId > 0 AndAlso intSucursalId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboCaja", "", Benavides.CC.Data.clstblCaja.strBuscar(intCompaniaId, intSucursalId, 0, 0, 0, "", "", "", "", #1/1/2000#, #1/1/2000#, "", 0, 0, strConnectionString), New Integer(2) {0, 1, 2}, 6, 1)
        End If
    End Function

    '====================================================================
    ' Name       : strTipoCajaNombre
    ' Description: Regresa el tipo de caja
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strTipoCajaNombre() As String
        ' Buscamos el identificador del tipo de caja
        Dim aobjTipoCaja As Array = Benavides.CC.Data.clstblCajaTipoCaja.strBuscar(0, intCompaniaId, intSucursalId, intCajaId, #1/1/2000#, "", 1, 1, strConnectionString)

        ' Si la caja tiene asignado un tipo
        If IsArray(aobjTipoCaja) AndAlso aobjTipoCaja.Length > 0 Then
            ' Obtenemos el nombre del tipo de caja
            Dim intTipoCajaId As Integer = CInt(DirectCast(aobjTipoCaja.GetValue(0), System.Collections.SortedList).Item("intTipoCajaId"))
            Dim aobjTipoCajaNombre As Array = Benavides.CC.Data.clstblTipoCaja.strBuscar(intTipoCajaId, "", "", "", #1/1/1900#, "", 0, 0, strConnectionString)
            Dim strTipoCajaNombreId As String = CStr(DirectCast(aobjTipoCajaNombre.GetValue(0), System.Collections.SortedList).Item("strTipoCajaNombre"))

            Return strTipoCajaNombreId

        End If

    End Function

    '====================================================================
    ' Name       : intTotalCajas
    ' Description: Regresa el total de cajas de la sucursal
    ' Parameters : None
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Function intTotalCajas() As Integer
        Dim aobjTotalCajas As Array = Benavides.CC.Data.clstblCaja.strBuscar(intCompaniaId, intSucursalId, 0, 0, 0, "", "", "", "", #1/1/2000#, #1/1/2000#, "", 0, 0, strConnectionString)
        Dim TotalCajas As Integer = UBound(aobjTotalCajas) + 1

        Return TotalCajas

    End Function

    '====================================================================
    ' Name       : strHTML
    ' Description: Regresa el HTML con la información de la caja
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strHTML() As String
        Dim strtmpHTML As StringBuilder = New StringBuilder

        strtmpHTML.Append("<h2>Informaci&oacute;n de la caja </h2>")
        strtmpHTML.Append("<table width='60%'  border='0' cellspacing='0' cellpadding='0'>")
        strtmpHTML.Append("<tr>")
        strtmpHTML.Append("<td width='28%' class='tdtexttablebold'>Sucursal:</td>")
        strtmpHTML.Append("<td width='72%' class='tdcontentableblue'><script language='javascript'>strSucursalNombre()</script></td>")
        strtmpHTML.Append("</tr>")
        strtmpHTML.Append("<tr>")
        strtmpHTML.Append("<td width='28%' class='tdtexttablebold'>Tipo:</td>")
        strtmpHTML.Append("<td width='72%' class='tdcontentableblue'><script language='javascript'>strTipoCaja()</script></td>")
        strtmpHTML.Append("</tr>")
        strtmpHTML.Append("<tr>")
        strtmpHTML.Append("<td class='tdtexttablebold'>Ubicaci&oacute;n:</td>")
        strtmpHTML.Append("<td class='tdcontentableblue'><script language='javascript'>strUbicacion()</script></td>")
        strtmpHTML.Append("</tr>")
        strtmpHTML.Append("<tr>")
        strtmpHTML.Append("<td class='tdtexttablebold'>Estado:</td>")
        strtmpHTML.Append("<td class='tdcontentableblue'><script language='javascript'>strEstado()</script></td>")
        strtmpHTML.Append("</tr>")
        strtmpHTML.Append("<tr>")
        strtmpHTML.Append("<td class='tdtexttablebold'>Nombre: </td>")
        strtmpHTML.Append("<td class='tdcontentableblue'><script language='javascript'>strCajaNombre()</script></td>")
        strtmpHTML.Append("</tr>")
        strtmpHTML.Append("<tr>")
        strtmpHTML.Append("<td class='tdtexttablebold'>Identificador: </td>")
        strtmpHTML.Append("<td class='tdcontentableblue'><script language='javascript'>strCajaNombreId()</script></td>")
        strtmpHTML.Append("</tr>")
        strtmpHTML.Append("<tr>")
        strtmpHTML.Append("<td class='tdtexttablebold'>Raz&oacute;n &uacute;ltimo cambio: </td>")
        strtmpHTML.Append("<td class='tdcontentableblue'><script language='javascript'>strCajaRazonCambio()</script></td>")
        strtmpHTML.Append("</tr>")
        strtmpHTML.Append("<tr>")
        strtmpHTML.Append("<td class='tdtexttablebold'>Fecha &uacute;ltimo cambio: </td>")
        strtmpHTML.Append("<td class='tdcontentableblue'><script language='javascript'>strCajaUltimaModificacion()</script></td>")
        strtmpHTML.Append("</tr>")
        strtmpHTML.Append("<tr>")
        strtmpHTML.Append("<td class='tdtexttablebold'>Direcci&oacute;n IP : </td>")
        strtmpHTML.Append("<td class='tdcontentableblue'><script language='javascript'>strCajaDireccionIp()</script></td>")
        strtmpHTML.Append("</tr>")
        strtmpHTML.Append("</table>")
        strtmpHTML.Append("<br>")
        strtmpHTML.Append("<input name='boton23232323' type='button' class='button' value='Imprimir reporte' onclick='return boton23232323_onclick()'>")

        If intCajaId > 0 Then
            Return strtmpHTML.ToString()
        Else
            Return " "
        End If

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        Dim strCmd As String = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Ver"
                ' Si el identificador de la política de POS es válido
                If intCompaniaId > 0 AndAlso intSucursalId > 0 AndAlso intCajaId > 0 Then

                    ' Buscamos la política de POS
                    Dim astrData As Array = Benavides.CC.Data.clsCaja.strBuscarDetalle(intCompaniaId, intSucursalId, intCajaId, 0, 0, strConnectionString)

                    ' Si la política de POS existe
                    If astrData.Length > 0 Then

                        ' Obtenemos la ubicación de la caja
                        strUbicacion = CStr(DirectCast(astrData.GetValue(0), Array).GetValue(12))

                        ' Obtenemos el estado de la caja
                        strEstado = CStr(DirectCast(astrData.GetValue(0), Array).GetValue(13))

                        ' Obtenemos el nombre de la caja
                        strCajaNombre = CStr(DirectCast(astrData.GetValue(0), Array).GetValue(6))

                        ' Obtenemos el nombre id de la caja
                        strCajaNombreId = CStr(DirectCast(astrData.GetValue(0), Array).GetValue(5))

                        ' Obtenemos la última razón de cambio de la caja
                        strCajaRazonCambio = CStr(DirectCast(astrData.GetValue(0), Array).GetValue(7))

                        ' Obtenemos la fecha de última modificación de la caja
                        strCajaUltimaModificacion = Benavides.POSAdmin.Commons.clsCommons.strMDYtoDMY(CStr(DirectCast(astrData.GetValue(0), Array).GetValue(9)))

                        ' Obtenemos la direccion IP de la caja
                        strCajaDireccionIp = CStr(DirectCast(astrData.GetValue(0), Array).GetValue(8))

                    End If

                End If

        End Select

    End Sub

End Class