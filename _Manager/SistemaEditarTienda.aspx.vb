'====================================================================
' Class         : clsSistemaEditarTienda
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Administrar tiendas : Ver Tienda
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Javier Ramos
' Version       : 1.0
' Last Modified : Monday, May 24, 2004
'====================================================================

Imports System.Text

Public Class clsSistemaEditarTienda
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
    Private intmEstadoId As Integer
    Private intmCiudadId As Integer
    Private strmHTMLTienda As String = ""
    Private intmDireccionId As Integer
    Private intmZonaId As Integer
    Private strmHTMLSucursalesVinculadas As String = ""
    Private strmTiendaNombre As String
    Private strmTiendaIPConcentrador As String
    Private intmTiendaPuertoIPConcentrador As Integer
    Private strmTiendaIPADS As String
    Private intmTiendaPuertoIPADS As Integer
    Private intmCompaniaId As Integer
    Private intmSucursalId As Integer
    Private strmSucursales As String = ""

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
    ' Name       : intCompaniaId 
    ' Description: Obtiene o establece el id de la Compañia
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
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
    ' Description: Obtiene o establece el id de la Sucursal
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
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
    ' Name       : intEstadoId 
    ' Description: Obtiene o establece el id de un Estado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intEstadoId() As Integer
        Get
            Return intmEstadoId
        End Get
        Set(ByVal intValue As Integer)
            intmEstadoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intCiudadId 
    ' Description: Obtiene o establece el id de una ciudad
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intCiudadId() As Integer
        Get
            Return intmCiudadId
        End Get
        Set(ByVal intValue As Integer)
            intmCiudadId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strHTMLTienda 
    ' Description: Obtiene o establece el HTML del Detalle de una Tienda
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strHTMLTienda() As String
        Get
            Return strmHTMLTienda
        End Get
        Set(ByVal strValue As String)
            strmHTMLTienda = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strHTMLSucursalesVinculadas 
    ' Description: Obtiene o establece el HTML de Sucursales
    '              vinculadas a una Tienda
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strHTMLSucursalesVinculadas() As String
        Get
            Return strmHTMLSucursalesVinculadas
        End Get
        Set(ByVal strValue As String)
            strmHTMLSucursalesVinculadas = strValue
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
    ' Name       : strTiendaNombre 
    ' Description: Obtiene o establece el nombre de una tienda
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strTiendaNombre() As String
        Get
            Return strmTiendaNombre
        End Get
        Set(ByVal strValue As String)
            strmTiendaNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTiendaIPCOncentrador
    ' Description: Obtiene o establece la IP del Concentrador de una tienda
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strTiendaIPConcentrador() As String
        Get
            Return strmTiendaIPConcentrador
        End Get
        Set(ByVal strValue As String)
            strmTiendaIPConcentrador = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intTiendaPuertoIPConcentrador
    ' Description: Obtiene o establece el puerto de la IP del Concentrador de una tienda
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intTiendaPuertoIPConcentrador() As Integer
        Get
            Return intmTiendaPuertoIPConcentrador
        End Get
        Set(ByVal intValue As Integer)
            intmTiendaPuertoIPConcentrador = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTiendaIPADS
    ' Description: Obtiene o establece la IP del ADS de una tienda
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strTiendaIPADS() As String
        Get
            Return strmTiendaIPADS
        End Get
        Set(ByVal strValue As String)
            strmTiendaIPADS = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intTiendaPuertoIPADS
    ' Description: Obtiene o establece el puerto de la IP del Concentrador de una tienda
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intTiendaPuertoIPADS() As Integer
        Get
            Return intmTiendaPuertoIPADS
        End Get
        Set(ByVal intValue As Integer)
            intmTiendaPuertoIPADS = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strSucursales
    ' Description: Listado de sucursales seleccionadas
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strSucursales() As String
        Get
            Return strmSucursales
        End Get
        Set(ByVal stValue As String)
            strmSucursales = stValue
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

                If intEstadoId = 0 Then
                    intEstadoId = CInt(avntRow.GetValue(1))
                End If

                If intCiudadId = 0 Then
                    intCiudadId = CInt(avntRow.GetValue(2))
                End If

                strData.Append("<tr>")
                strData.Append("<td class=""tdtexttablebold"">Nombre de la tienda:</td>")
                strData.Append("<td class=""tdpadleft5""><input name=""txtNombreTienda"" type=""text"" class=""field"" size=""50"" maxlength=""50"" value=""" & CStr(avntRow.GetValue(3)) & """></td>")
                strData.Append("</tr>")
                strData.Append("<tr>")
                strData.Append("<td class=""tdtexttablebold"">Direcci&oacute;n IP del concentrador: </td>")
                strData.Append("<td class=""tdpadleft5""><input name=""txtIpConcentrador"" type=""text"" class=""field"" size=""20"" maxlength=""15"" value=""" & CStr(avntRow.GetValue(4)) & """></td>")
                strData.Append("</tr>")
                strData.Append("<tr>")
                strData.Append("<td class=""tdtexttablebold"">Puerto del concentrador: </td>")
                strData.Append("<td class=""tdpadleft5""><input name=""txtPuertoConcentrador"" type=""text"" class=""field"" size=""5"" maxlength=""4"" value=""" & CStr(avntRow.GetValue(5)) & """></td>")
                strData.Append("</tr>")
                strData.Append("<tr>")
                strData.Append("<td class=""tdtexttablebold"">Direcci&oacute;n IP del ADS: </td>")
                strData.Append("<td class=""tdpadleft5""><input name=""txtIpADS"" type=""text"" class=""field"" size=""20"" maxlength=""15"" value=""" & CStr(avntRow.GetValue(6)) & """></td>")
                strData.Append("</tr>")
                strData.Append("<tr>")
                strData.Append("<td class=""tdtexttablebold"">Puerto del ADS: </td>")
                strData.Append("<td class=""tdpadleft5""><input name=""txtPuertoADS"" type=""text"" class=""field"" size=""5"" maxlength=""4"" value=""" & CStr(avntRow.GetValue(7)) & """></td>")
                strData.Append("</tr>")
                strData.Append("</table>")

            Next

            strData.Append("<br><span id=""objRegresar""></span>")
            strData.Append("<input name=""cmdActualizar"" type=""button"" class=""button"" value=""Guardar Cambios"" onclick=""cmdActualizar_onclick();"">")

        Else

            strData.Append("<tr>")
            strData.Append("<td class=""tdtexttablebold"">Nombre de la tienda:</td>")
            strData.Append("<td class=""tdpadleft5""><input name=""txtNombreTienda"" type=""text"" class=""field"" size=""50"" maxlength=""50"" value=""""></td>")
            strData.Append("</tr>")
            strData.Append("<tr>")
            strData.Append("<td class=""tdtexttablebold"">Direcci&oacute;n IP del concentrador: </td>")
            strData.Append("<td class=""tdpadleft5""><input name=""txtIpConcentrador"" type=""text"" class=""field"" size=""20"" maxlength=""15"" value=""""></td>")
            strData.Append("</tr>")
            strData.Append("<tr>")
            strData.Append("<td class=""tdtexttablebold"">Puerto del concentrador: </td>")
            strData.Append("<td class=""tdpadleft5""><input name=""txtPuertoConcentrador"" type=""text"" class=""field"" size=""5"" maxlength=""4"" value=""""></td>")
            strData.Append("</tr>")
            strData.Append("<tr>")
            strData.Append("<td class=""tdtexttablebold"">Direcci&oacute;n IP del ADS: </td>")
            strData.Append("<td class=""tdpadleft5""><input name=""txtIpADS"" type=""text"" class=""field"" size=""20"" maxlength=""15"" value=""""></td>")
            strData.Append("</tr>")
            strData.Append("<tr>")
            strData.Append("<td class=""tdtexttablebold"">Puerto del ADS: </td>")
            strData.Append("<td class=""tdpadleft5""><input name=""txtPuertoADS"" type=""text"" class=""field"" size=""5"" maxlength=""4"" value=""""></td>")
            strData.Append("</tr>")
            strData.Append("</table>")
            strData.Append("<br>")
            strData.Append("<input name=""cmdRegresar"" type=""button"" class=""button"" id=""cmdRegresar"" value=""Regresar"" language=javascript onclick=""return cmdRegresar_onclick()"">&nbsp;")
            strData.Append("<input name=""cmdAgregar"" type=""button"" class=""button"" value=""Agregar Tienda"" onclick=""cmdAgregar_onclick();"">")

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

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 25
        Const strRecordBrowserName As String = "SistemaEditarTienda"

        ' Declaramos e inicialziamos las variables locales
        Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1", Request))
        Dim astrRecords As Array = Benavides.CC.Data.clsTienda.strBuscarSucursalVinculada(intTiendaId, intDireccionId, intZonaId, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

        Dim strRegresarHTML As String = ""
        If astrRecords.Length > 0 Then
            strRegresarHTML = "<script language=""Javascript"">if (document.all.objRegresar != null) {document.all.objRegresar.innerHTML = ""<input name=\""cmdRegresar\"" type=\""button\"" class=\""button\"" id=\""cmdRegresar\"" value=\""Regresar\"" language=javascript onclick=\""return cmdRegresar_onclick()\"">&nbsp;"";}</script>"
        End If

        ' Establecemos los eventos onClick actual y futuro
        Dim strCurrentJavascriptOnClickEvent As String = "onclick=""window.location='SistemaEditarTienda.aspx?strCmd=Agregar'"""
        Dim strNewJavascriptOnClickEvent As String = "onclick=""cmdNavegadorRegistrosAgregar_onclick(" & intTiendaId & ", " & intDireccionId & ", " & intZonaId & ");"""

        ' Obtenemos el HTML
        Dim strReturn As String = Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrRecords, intSelectedPage, intElementsPerPage, strThisPageName & "?")

        ' Regresamos el resultado
        Return strRegresarHTML & Replace(strReturn, strCurrentJavascriptOnClickEvent, strNewJavascriptOnClickEvent)

    End Function

    '====================================================================
    ' Name       : strLlenarEstadoComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboEstado"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarEstadoComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboEstado", intEstadoId, Benavides.CC.Data.clstblEstado.strBuscar(0, 1, "", Now(), "", 0, 0, strConnectionString), 0, 2, 1)
    End Function

    '====================================================================
    ' Name       : strLlenarCiudadComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboCiudad"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarCiudadComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboCiudad", intCiudadId, Benavides.CC.Data.clstblCiudad.strBuscar(intEstadoId, 0, "", Now(), "", 0, 0, strConnectionString), 1, 2, 1)
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "", Request)

        ' Inicializamos las variables necesarias
        intCompaniaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intCompaniaId", "0", Request))
        intSucursalId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intSucursalId", "0", Request))

        ' Almacenamos el id de la tienda
        intTiendaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intTiendaId", "0", Request))
        intEstadoId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboEstado", "0", Request))
        intCiudadId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboCiudad", "0", Request))

        ' Almacenamos el id de la Direccion
        intDireccionId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intDireccionId", "0", Request))

        ' Almacenamos el id de la Zona
        intZonaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intZonaId", "0", Request))


        ' Almacenamos el nombre de la Tienda
        strTiendaNombre = CStr(isocraft.commons.clsWeb.strGetPageParameter("txtNombreTienda", "", Request))

        ' Almacenamos la IP del Concentrador de la Tienda
        strTiendaIPConcentrador = CStr(isocraft.commons.clsWeb.strGetPageParameter("txtIpConcentrador", "", Request))

        ' Almacenamos el Puerto de la IP del Concentrador de la Tienda
        intTiendaPuertoIPConcentrador = CInt(isocraft.commons.clsWeb.strGetPageParameter("txtPuertoConcentrador", "0", Request))

        ' Almacenamos la IP del ADS de la Tienda
        strTiendaIPADS = CStr(isocraft.commons.clsWeb.strGetPageParameter("txtIpADS", "", Request))

        ' Almacenamos el Puerto de la IP del ADS de la Tienda
        intTiendaPuertoIPADS = CInt(isocraft.commons.clsWeb.strGetPageParameter("txtPuertoADS", "0", Request))

        ' Almacenamos la lista de sucursales seleccionadas
        strSucursales = isocraft.commons.clsWeb.strGetPageParameter("txtSucursales", "")


        Select Case strCmd

            Case "SalvarAgregar"

                ' Agregamos la tienda al catalogo de tiendas de Grupo Fasa Benavides
                intTiendaId = Benavides.CC.Data.clstblTienda.intAgregar(0, intEstadoId, intCiudadId, strTiendaNombre, strTiendaIPConcentrador, intTiendaPuertoIPConcentrador, strTiendaIPADS, intTiendaPuertoIPADS, "", "", Now(), strUsuarioNombre, strConnectionString)

                ' Refrescamos la lista de Sucursales Vinculadas a la Tienda
                strHTMLSucursalesVinculadas = strObtenerSucursalesVinculadas()

            Case "Editar"

                ' Obtenemos la lista de Sucursales Vinculadas a la Tienda
                strHTMLSucursalesVinculadas = strObtenerSucursalesVinculadas()

            Case "Actualizar"

                ' Actualizamos la información de una Tienda Especifica
                Call Benavides.CC.Data.clstblTienda.intActualizar(intTiendaId, intEstadoId, intCiudadId, strTiendaNombre, strTiendaIPConcentrador, intTiendaPuertoIPConcentrador, strTiendaIPADS, intTiendaPuertoIPADS, "", "", Now(), strUsuarioNombre, strConnectionString)

                ' Refrescamos la lista de Sucursales Vinculadas a  la Tienda
                strHTMLSucursalesVinculadas = strObtenerSucursalesVinculadas()

            Case "Desasignar"

                ' Desvinculamos una Sucursal de la Tienda
                Call Benavides.CC.Data.clsTienda.clsSucursal.intDesvincularTienda(intCompaniaId, intSucursalId, 0, strUsuarioNombre, strConnectionString)

                ' REfrescamos la lista de sucursales vinculadas a la Tienda
                strHTMLSucursalesVinculadas = strObtenerSucursalesVinculadas()

            Case "Vincular"

                ' Vinculamos las sucursales a la Tienda, si los identificadores son válidos
                If intTiendaId > 0 AndAlso Len(strSucursales) > 0 Then

                    ' Almacenamos en un arreglo la lista de compañías y sucursales
                    ' La lista tiene el siguiente formato:
                    '   intCompaniaId | intSucursalId , intCompaniaId | intSucursalId, ..., intCompaniaId | intSucursalId
                    Dim astrIdentificadoresCompaniaSucursal As Array = strSucursales.Split(","c)

                    ' Si obtuvimos pares de identificadores "intCompaniaId | intSucursalId"
                    If astrIdentificadoresCompaniaSucursal.Length > 0 Then

                        ' Recorremos los pares identificadores
                        Dim strCompaniaIdentificadorSucursal As String
                        For Each strCompaniaIdentificadorSucursal In astrIdentificadoresCompaniaSucursal

                            ' Separamos los pares identificadores y los almacenamos en un arreglo
                            Dim astrCompaniaSucursal As Array = strCompaniaIdentificadorSucursal.Split("|"c)

                            ' Si existen identificadores
                            If astrCompaniaSucursal.Length > 0 Then

                                ' Obtenemos la compañía, la sucursal y el nuevo tipo de cambio
                                Dim intCompaniaId As Integer = CInt(astrCompaniaSucursal.GetValue(0))
                                Dim intSucursalId As Integer = CInt(astrCompaniaSucursal.GetValue(1))

                                ' Vinculamos a la Tienda, si la compañía y la sucursal son válidos
                                If intCompaniaId > 0 AndAlso intSucursalId > 0 Then
                                    Call Benavides.CC.Data.clsTienda.clsSucursal.intDesvincularTienda(intCompaniaId, intSucursalId, intTiendaId, strUsuarioNombre, strConnectionString)
                                End If

                            End If

                        Next

                    End If

                End If
                strHTMLSucursalesVinculadas = strObtenerSucursalesVinculadas()

        End Select

        strHTMLTienda = strObtenerDetalleTienda()


    End Sub


End Class


