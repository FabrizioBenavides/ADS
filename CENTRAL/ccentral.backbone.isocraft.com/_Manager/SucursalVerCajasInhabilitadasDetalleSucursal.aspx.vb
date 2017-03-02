'====================================================================
' Class         : clsSucursalVerCajasInhabilitadasDetalleSucursal
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Consultar cajas inhabilitadas
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Joaqu�n Hern�ndez Garc�a
' Version       : 1.0
' Last Modified : Thursday, June 24, 2004
'====================================================================
Public Class clsSucursalVerCajasInhabilitadasDetalleSucursal
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

    ' Variables privadas
    Private strmFechaInicial As String
    Private strmFechaFinal As String
    Private strmCompaniaSucursalId As String

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
            Return strmFechaFinal
        End Get
        Set(ByVal strValue As String)
            strmFechaFinal = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intDireccionId
    ' Description: Identificador de la direcci�n operativa
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDireccionId() As Integer
        Get
            Return CInt(isocraft.commons.clsWeb.strGetPageParameter("intDireccionOperativaId", isocraft.commons.clsWeb.strGetPageParameter("txtDireccionId", "0")))
        End Get
    End Property

    '====================================================================
    ' Name       : intZonaId
    ' Description: Identificador de la zona operativa
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intZonaId() As Integer
        Get
            Return CInt(isocraft.commons.clsWeb.strGetPageParameter("intZonaOperativaId", isocraft.commons.clsWeb.strGetPageParameter("txtZonaId", "0")))
        End Get
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
            Dim astrCompaniaId As Array = Split(strCompaniaSucursalId, "|")
            Dim intValue As Integer = CInt(astrCompaniaId.GetValue(0))
            If intValue = 0 Then
                intValue = CInt(isocraft.commons.clsWeb.strGetPageParameter("intCompaniaId", isocraft.commons.clsWeb.strGetPageParameter("txtCompaniaId", "0")))
            End If
            Return intValue
        End Get
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Identificador de la Sucursal
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intSucursalId() As Integer
        Get
            Dim astrSucursalId As Array = Split(strCompaniaSucursalId, "|")
            Dim intValue As Integer = CInt(astrSucursalId.GetValue(1))
            If intValue = 0 Then
                intValue = CInt(isocraft.commons.clsWeb.strGetPageParameter("intSucursalId", isocraft.commons.clsWeb.strGetPageParameter("txtSucursalId", "0")))
            End If
            Return intValue
        End Get
    End Property

    '====================================================================
    ' Name       : intTotalPorSucursal
    ' Description: Total de cajas deshabilitadas por sucursal
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intTotalPorSucursal() As Integer
        Get
            Dim intReturn As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intTotalPorSucursal", "0"))
            If intReturn = 0 Then
                Dim astrDataArray As Array = Benavides.CC.Data.clsCaja.strEjecutarBuscarCajasInhabilitadasPorZona(intDireccionId, intZonaId, CDate(strFechaInicial), CDate(strFechaFinal), 1, 100, strConnectionString)
                If astrDataArray.Length > 0 Then
                    Dim astrColumns As Array
                    For Each astrColumns In astrDataArray
                        If CInt(astrColumns.GetValue(2)) = intCompaniaId AndAlso CInt(astrColumns.GetValue(3)) = intSucursalId Then
                            intReturn = CInt(astrColumns.GetValue(5))
                            Exit For
                        End If
                    Next
                End If
            End If
            Return intReturn
        End Get
    End Property

    '====================================================================
    ' Name       : strDireccionOperativaNombre
    ' Description: Nombre de la Direcci�n
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
    ' Name       : strSucursalNombre
    ' Description: Nombre de la Sucursal
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
    ' Name       : strRangoDeFechas
    ' Description: Leyenda con el rango de fechas
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRangoDeFechas() As String
        Get
            Dim dtmFechaInicial As Date = CDate(strFechaInicial)
            Dim dtmFechaFinal As Date = CDate(strFechaFinal)
            Dim astrMonths() As String = {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"}
            Return "Del " & Day(dtmFechaInicial) & " de " & CStr(astrMonths.GetValue(Month(dtmFechaInicial) - 1)) & " de " & Year(dtmFechaInicial) & " al " & Day(dtmFechaFinal) & " de " & CStr(astrMonths.GetValue(Month(dtmFechaFinal) - 1)) & " de " & Year(dtmFechaFinal)
        End Get
    End Property

    '====================================================================
    ' Name       : strCompaniaSucursalId
    ' Description: Identificador de la Compania y la Sucursal
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCompaniaSucursalId() As String
        Get
            If Len(strmCompaniaSucursalId) = 0 Then
                strmCompaniaSucursalId = isocraft.commons.clsWeb.strGetPageParameter("cboSucursal", "0|0")
            End If
            If strmCompaniaSucursalId.Equals("0|0") = True Then
                strmCompaniaSucursalId = isocraft.commons.clsWeb.strGetPageParameter("intCompaniaId", "0") & "|" & isocraft.commons.clsWeb.strGetPageParameter("intSucursalId", "0")
            End If
            Return strmCompaniaSucursalId
        End Get
    End Property

    '====================================================================
    ' Name       : strLlenarSucursalComboBox
    ' Description: Regresa una cadena de texto con el c�digo Javascript
    '              que llena al combo box "cboSucursal"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarSucursalComboBox() As String
        If intDireccionId > 0 AndAlso intZonaId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSucursal", strCompaniaSucursalId, Benavides.CC.Data.clsCaja.strEjecutarBuscarCajasInhabilitadasPorZona(intDireccionId, intZonaId, CDate(strFechaInicial), CDate(strFechaFinal), 1, 100, strConnectionString), New Integer(1) {2, 3}, 4, 1)
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
    ' Description: Genera la fecha y hora de la p�gina
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
    ' Description: URL de esta p�gina
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
    ' Description: Obtiene la cadena de conexi�n hacia la base de datos
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
    ' Name       : strPrintPOSDetails
    ' Description: Regresa el HTML del detalle de las cajas
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strPrintPOSDetails() As String

        ' Declaramos e inicializamos las variables locales
        Dim strData As System.Text.StringBuilder = New System.Text.StringBuilder

        ' Buscamos las cajas de la sucursal actual
        Dim astrDataArray As Array = Benavides.CC.Data.clsCaja.strBuscarDetalle(intCompaniaId, intSucursalId, 0, 0, 0, strConnectionString)

        ' Obtenemos el detalle de cada caja
        Dim astrRows As Array
        For Each astrRows In astrDataArray
            If CInt(astrRows.GetValue(4)) = 2 Then
                Call strData.Append("<table width=""60%""  border=""0"" cellspacing=""0"" cellpadding=""0"">")
                Call strData.Append("<tr>")
                Call strData.Append("<td width=""33%"" class=""tdtexttablebold"">Nombre:</td>")
                Call strData.Append("<td width=""67%"" class=""tdcontentableblue"">" & CStr(astrRows.GetValue(6)) & "</td>")
                Call strData.Append("</tr>")
                Call strData.Append("<tr>")
                Call strData.Append("<td class=""tdtexttablebold"">Ubicaci&oacute;n:</td>")
                Call strData.Append("<td class=""tdcontentableblue"">" & CStr(astrRows.GetValue(12)) & "</td>")
                Call strData.Append("</tr>")
                Call strData.Append("<tr>")
                Call strData.Append("<td class=""tdtexttablebold"">Estado:</td>")
                Call strData.Append("<td class=""tdcontentableblue"">" & CStr(astrRows.GetValue(13)) & "</td>")
                Call strData.Append("</tr>")
                Call strData.Append("<tr>")
                Call strData.Append("<td class=""tdtexttablebold"">Raz&oacute;n &uacute;ltima de cambio: </td>")
                Call strData.Append("<td class=""tdcontentableblue"">" & CStr(astrRows.GetValue(7)) & "</td>")
                Call strData.Append("</tr>")
                Call strData.Append("<tr>")
                Call strData.Append("<td class=""tdtexttablebold"">Fecha &uacute;ltima de cambio: </td>")
                Call strData.Append("<td class=""tdcontentableblue"">" & CStr(astrRows.GetValue(9)) & "</td>")
                Call strData.Append("</tr>")
                Call strData.Append("<tr>")
                Call strData.Append("<td class=""tdtexttablebold"">Direcci&oacute;n de IP : </td>")
                Call strData.Append("<td class=""tdcontentableblue"">" & CStr(astrRows.GetValue(8)) & "</td>")
                Call strData.Append("</tr>")
                Call strData.Append("</table>")
                Call strData.Append("<br>")
            End If
        Next

        ' Regresamos el resultado
        Return strData.ToString()

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la p�gina de acceso, si no tiene privilegios de acceder a esta p�gina
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        Dim strCmd As String = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Validamos que tengamos los par�metros requeridos
        If intDireccionId < 1 OrElse intZonaId < 1 OrElse intCompaniaId < 1 OrElse intSucursalId < 0 OrElse Len(strFechaInicial) = 0 OrElse Len(strFechaFinal) = 0 Then
            Call Response.Redirect("SucursalConsultarCajasInhabilitadas.aspx")
        End If

    End Sub

End Class