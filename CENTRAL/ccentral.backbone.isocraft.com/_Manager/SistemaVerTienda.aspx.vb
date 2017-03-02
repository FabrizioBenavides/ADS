'====================================================================
' Class         : clsSistemaVerTienda
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Administrar tiendas : Ver Tienda
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Javier Ramos
' Version       : 1.0
' Last Modified : Monday, May 24, 2004
'====================================================================

Imports System.Text

Public Class clsSistemaVerTienda
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
    Private intmTiendaId As Integer
    Private intmDireccionId As Integer
    Private intmZonaId As Integer

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
    ' Name       : intTiendaId 
    ' Description: Obtiene o establece el id de la tienda
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intTiendaId() As Integer
        Get
            Return intmTiendaId
        End Get
        Set(ByVal intValue As Integer)
            intmTiendaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intDireccionId 
    ' Description: Obtiene o establece el id de la Direccion Operativa
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
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
    ' Description: Obtiene o establece el id de la Zona Operativa
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
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
    ' Name       : strObtenerDetalleTienda
    ' Description: Regresa una cadena de texto con el HTML de la información de la Tienda
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strObtenerDetalleTienda() As String

        ' Arreglo que almacenará los renglones de la información 
        Dim avntRow As Array = Nothing
        Dim strData As StringBuilder

        Dim astrRecords As Array = Benavides.CC.Data.clsTienda.strBuscarDetalle(intTiendaId, strConnectionString)

        ' Creamos la instancia del String Builder que almacenará el HTML a ser Desplegado
        strData = New StringBuilder

        ' Verificamos que se trate de un arreglo
        If IsArray(astrRecords) = True AndAlso astrRecords.Length > 0 Then

            For Each avntRow In astrRecords

                strData.Append("<tr>")
                strData.Append("<td width=""40%"" class=""tdtexttablebold"">Estado:</td>")
                strData.Append("<td width=""60%"" class=""tdcontentableblue"">" & CStr(avntRow.GetValue(10)) & "</td>")
                strData.Append("</tr>")
                strData.Append("<tr>")
                strData.Append("<td class=""tdtexttablebold"">Ciudad:</td>")
                strData.Append("<td class=""tdcontentableblue"">" & CStr(avntRow.GetValue(11)) & "</td>")
                strData.Append("</tr>")
                strData.Append("<tr>")
                strData.Append("<td class=""tdtexttablebold"">Nombre de la tienda:</td>")
                strData.Append("<td class=""tdcontentableblue"">" & CStr(avntRow.GetValue(3)) & "</td>")
                strData.Append("</tr>")
                strData.Append("<tr>")
                strData.Append("<td class=""tdtexttablebold"">Direcci&oacute;n IP del concentrador: </td>")
                strData.Append("<td class=""tdcontentableblue"">" & CStr(avntRow.GetValue(4)) & "</td>")
                strData.Append("</tr>")
                strData.Append("<tr>")
                strData.Append("<td class=""tdtexttablebold"">Puerto del concentrador: </td>")
                strData.Append("<td class=""tdcontentableblue"">" & CStr(avntRow.GetValue(5)) & "</td>")
                strData.Append("</tr>")
                strData.Append("<tr>")
                strData.Append("<td class=""tdtexttablebold"">Direcci&oacute;n IP del ADS: </td>")
                strData.Append("<td class=""tdcontentableblue"">" & CStr(avntRow.GetValue(6)) & "</td>")
                strData.Append("</tr>")
                strData.Append("<tr>")
                strData.Append("<td class=""tdtexttablebold"">Puerto del ADS: </td>")
                strData.Append("<td class=""tdcontentableblue"">" & CStr(avntRow.GetValue(7)) & "</td>")
                strData.Append("</tr>")

            Next
        Else
            strData.Append("<tr>")
            strData.Append("<td width=""40%"" class=""tdtexttablebold"">No Existe información para la tienda seleccionada</td>")
            strData.Append("<td width=""60%"" class=""tdcontentableblue"">&nbsp;</td>")
            strData.Append("</tr>")
        End If
        Return strData.ToString
    End Function
    '====================================================================
    ' Name       : strObtenerSucursalesVinculadas
    ' Description: Regresa una cadena de texto con el HTML de 
    '              las Sucursales Vinculadas a la Tienda
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strObtenerSucursalesVinculadas() As String

        ' Arreglo que almacenará los renglones de la información 
        Dim avntRow As Array = Nothing
        Dim strData As StringBuilder

        Dim astrRecords As Array = Benavides.CC.Data.clstblSucursal.strBuscar(0, 0, intTiendaId, 0, "", 0, 0, 0, Now(), "", "", "", "", 0, 0, strConnectionString)
        ' Creamos la instancia del String Builder que almacenará el HTML a ser Desplegado
        strData = New StringBuilder

        ' Verificamos que se trate de un arreglo
        If IsArray(astrRecords) = True AndAlso astrRecords.Length > 0 Then

            For Each avntRow In astrRecords

                strData.Append("<tr>")
                strData.Append("<td class=""tdtexttablebold"">&nbsp;</td>")
                strData.Append("<td class=""tdcontentableblue"">" & CStr(avntRow.GetValue(0)) & " " & CStr(avntRow.GetValue(1)) & " " & CStr(avntRow.GetValue(4)) & "</td>")
                strData.Append("</tr>")
            Next
        Else
            strData.Append("<tr>")
            strData.Append("<td width=""40%"" class=""tdtexttablebold"">No Existen Sucursales Vinculadas a la Tienda</td>")
            strData.Append("<td width=""60%"" class=""tdcontentableblue"">&nbsp;</td>")
            strData.Append("</tr>")
        End If
        Return strData.ToString
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", isocraft.commons.clsWeb.strGetPageParameter("cmdConsultar", ""), Request)

        ' Almacenamos el id de la tienda
        intTiendaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intTiendaId", "0", Request))

        ' Almacenamos el id de la Direccion
        intDireccionId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intDireccionId", "0", Request))

        ' Almacenamos el id de la Zona
        intZonaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intZonaId", "0", Request))

    End Sub


End Class


