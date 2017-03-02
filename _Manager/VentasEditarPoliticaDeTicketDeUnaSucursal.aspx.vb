'====================================================================
' Class         : clsEditarPoliticaDeTicketDeUnaSucursal
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Editar política de ticket de una sucursal
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Joaquín Hernández García
' Version       : 1.0
' Last Modified : Friday, June 25, 2004
'====================================================================
Public Class clsEditarPoliticaDeTicketDeUnaSucursal
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
    Private strmPoliticaTicketNombre As String
    Private strmPoliticaTicketValor As String

    '====================================================================
    ' Name       : intDireccionId
    ' Description: Identificador de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDireccionId() As Integer
        Get
            If intmDireccionId = 0 Then
                intmDireccionId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intDireccionId", "0"))
            End If
            Return intmDireccionId
        End Get
    End Property

    '====================================================================
    ' Name       : intZonaId
    ' Description: Identificador de la Zona
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intZonaId() As Integer
        Get
            If intmZonaId = 0 Then
                intmZonaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intZonaId", "0"))
            End If
            Return intmZonaId
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
            If intmCompaniaId = 0 Then
                intmCompaniaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intCompaniaId", "0"))
            End If
            Return intmCompaniaId
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
            If intmSucursalId = 0 Then
                intmSucursalId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intSucursalId", "0"))
            End If
            Return intmSucursalId
        End Get
    End Property

    '====================================================================
    ' Name       : strPoliticaTicketNombre
    ' Description: Nombre de la política de ticket
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strPoliticaTicketNombre() As String
        Get
            If Len(strmPoliticaTicketNombre) = 0 Then
                strmPoliticaTicketNombre = isocraft.commons.clsWeb.strGetPageParameter("txtPoliticaTicketNombre", "")
            End If
            Return strmPoliticaTicketNombre
        End Get
        Set(ByVal strValue As String)
            strmPoliticaTicketNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strPoliticaTicketValor
    ' Description: Valor de la política de ticket
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strPoliticaTicketValor() As String
        Get
            If Len(strmPoliticaTicketValor) = 0 Then
                strmPoliticaTicketValor = isocraft.commons.clsWeb.strGetPageParameter("txtPoliticaTicketValor", "")
            End If
            Return strmPoliticaTicketValor
        End Get
        Set(ByVal strValue As String)
            strmPoliticaTicketValor = strValue
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
    ' Name       : strCmd
    ' Description: Valor del comando ejecutado
    ' Accessor   : Read, Write
    ' Throws     : None
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Enviamos al usuario actual a la página origen, si los identificadores de la dirección, zona, compañía y sucursal son inválidos
        If intDireccionId < 1 OrElse intZonaId < 1 OrElse intCompaniaId < 1 OrElse intSucursalId < 1 Then
            Call Response.Redirect("VentasAdministrarPoliticasDeTickets.aspx")
        End If

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Obtenemos el identificador de la política de ticket
        Dim intPoliticaTicketId As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intPoliticaTicketId", "0"))

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Editar"

                ' Si el identificador de la política de ticket es válido
                If intPoliticaTicketId > 0 Then

                    ' Buscamos la política de ticket
                    Dim astrData As Array = Benavides.CC.Data.clstblPoliticaTicket.strBuscar(intPoliticaTicketId, intCompaniaId, intSucursalId, "", "", Now, "", 0, 0, strConnectionString)

                    ' Si la política de ticket existe
                    If astrData.Length > 0 Then

                        ' Obtenemos los valores de sus atributos
                        strPoliticaTicketNombre = CStr(DirectCast(astrData.GetValue(0), Array).GetValue(3))
                        strPoliticaTicketValor = CStr(DirectCast(astrData.GetValue(0), Array).GetValue(4))

                        ' Establecemos el siguiente estado
                        strCmd = "SalvarEditar"

                    End If

                End If

            Case "SalvarEditar"

                ' Si los campos obligatorios fueron llenados
                If intPoliticaTicketId > 0 AndAlso Len(strPoliticaTicketNombre) > 0 AndAlso Len(strPoliticaTicketValor) > 0 Then

                    ' Agregamos el nuevo registro
                    Call Benavides.CC.Data.clstblPoliticaTicket.intActualizar(intPoliticaTicketId, intCompaniaId, intSucursalId, strPoliticaTicketNombre, strPoliticaTicketValor, Now, strUsuarioNombre, strConnectionString)

                    ' Regresamos a la página origen
                    Call Response.Redirect("VentasAsignarPoliticasDeTicketAUnaSucursal.aspx?intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId & "&intCompaniaId=" & intCompaniaId & "&intSucursalId=" & intSucursalId)

                End If

            Case "Agregar"

                ' Establecemos el siguiente estado
                strCmd = "SalvarAgregar"

            Case "SalvarAgregar"

                ' Si los campos obligatorios fueron llenados
                If Len(strPoliticaTicketNombre) > 0 AndAlso Len(strPoliticaTicketValor) > 0 Then

                    ' Si el nombre del elemento no existe
                    If Benavides.CC.Data.clstblPoliticaTicket.strBuscar(0, intCompaniaId, intSucursalId, strPoliticaTicketNombre, "", Now, "", 0, 0, strConnectionString).Length = 0 Then

                        ' Agregamos el nuevo registro
                        Call Benavides.CC.Data.clstblPoliticaTicket.intAgregar(0, intCompaniaId, intSucursalId, strPoliticaTicketNombre, strPoliticaTicketValor, Now, strUsuarioNombre, strConnectionString)

                        ' Regresamos a la página origen
                        Call Response.Redirect("VentasAsignarPoliticasDeTicketAUnaSucursal.aspx?intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId & "&intCompaniaId=" & intCompaniaId & "&intSucursalId=" & intSucursalId)

                    Else

                        ' El elemento ya existe, indicamos el error
                        strJavascriptWindowOnLoadCommands &= "  alert(""La política \'" & strPoliticaTicketNombre & "'\ ya existe. Por favor especifique un nuevo nombre."");" & vbCrLf
                        strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""txtPoliticaTicketNombre""].focus();" & vbCrLf

                        ' Establecemos el siguiente estado
                        strCmd = "SalvarAgregar"

                    End If

                End If

            Case "Borrar"

                    ' Si los campos obligatorios fueron llenados
                    If intPoliticaTicketId > 0 Then

                        ' Buscamos la política de ticket
                        Dim astrData As Array = Benavides.CC.Data.clstblPoliticaTicket.strBuscar(intPoliticaTicketId, intCompaniaId, intSucursalId, "", "", Now, "", 0, 0, strConnectionString)

                        ' Si la politica existe
                        If astrData.Length > 0 Then

                            ' Buscamos la sucursal
                        Dim astrBranchOffice As Array = Benavides.CC.Data.clstblSucursal.strBuscar(intCompaniaId, intSucursalId, 0, 0, "", 0, 0, 0, Now, "", "", "", "", 0, 0, strConnectionString)

                            ' Si la sucursal existe
                            If astrBranchOffice.Length > 0 Then

                                ' Obtenemos el identificador de la tienda
                                Dim intTiendaId As Integer = CInt(DirectCast(astrBranchOffice.GetValue(0), Array).GetValue(2))

                                ' Si el identificador de la tienda es válido
                                If intTiendaId > 0 Then

                                    ' Buscamos la tienda
                                Dim astrStore As Array = Benavides.CC.Data.clstblTienda.strBuscar(intTiendaId, 0, 0, "", "", 0, "", 0, "", "", Now, "", 0, 0, strConnectionString)

                                    ' Si la tienda existe
                                    If astrStore.Length > 0 Then

                                        ' Enviamos el mensaje
                                        Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeHaciaServidoresPuntoDeVenta("clstblPoliticaTicket", Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ELIMINAR, "", astrData, astrStore)

                                        ' Eliminamos el registro especificado
                                        Call Benavides.CC.Data.clstblPoliticaTicket.intEliminar(intPoliticaTicketId, intCompaniaId, intSucursalId, "", "", Now, strUsuarioNombre, strConnectionString)

                                    End If

                                End If

                            End If

                        End If

                        ' Regresamos a la página origen
                        Call Response.Redirect("VentasAsignarPoliticasDeTicketAUnaSucursal.aspx?intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId & "&intCompaniaId=" & intCompaniaId & "&intSucursalId=" & intSucursalId)

                    End If

        End Select

        ' Salvamos en la acción de la forma los identificadores necesarios
        strJavascriptWindowOnLoadCommands &= "  document.forms[0].action += ""?intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId & "&intCompaniaId=" & intCompaniaId & "&intSucursalId=" & intSucursalId & "&intPoliticaTicketId=" & intPoliticaTicketId & """;"

    End Sub

End Class
