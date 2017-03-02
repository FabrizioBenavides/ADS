'====================================================================
' Class         : clsSucursalVerCuentaAsignada
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Ver cuentas asignadas
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Joaquín Hernández García
' Version       : 1.0
' Last Modified : Thursday, June 17, 2004
'====================================================================
Public Class clsSucursalVerCuentaAsignada
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
    Private intmSucursalId As Integer
    Private intmCompaniaId As Integer
    Private strmSucursalNombre As String
    Private intmTipoCuentaId As Integer
    Private intmCuentaId As Integer


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
    ' Name       : intDireccionId
    ' Description: Identificador de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDireccionId() As Integer
        Get
            If intmDireccionId = 0 Then
                intmDireccionId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intDireccionId", isocraft.commons.clsWeb.strGetPageParameter("txtDireccionId", "0")))
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
                intmZonaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intZonaId", isocraft.commons.clsWeb.strGetPageParameter("txtZonaId", "0")))
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
            intmCompaniaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intCompaniaId", isocraft.commons.clsWeb.strGetPageParameter("txtCompaniaId", "0")))
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
            intmSucursalId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intSucursalId", isocraft.commons.clsWeb.strGetPageParameter("txtSucursalId", "0")))
            Return intmSucursalId
        End Get
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
    ' Name       : intTipoCuentaId
    ' Description: Identificador de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intTipoCuentaId() As Integer
        Get
            intmTipoCuentaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intTipoCuentaId", isocraft.commons.clsWeb.strGetPageParameter("cboTipoCuenta", "0")))
            Return intmTipoCuentaId
        End Get
    End Property

    '====================================================================
    ' Name       : intCuentaId
    ' Description: Identificador de la Cuenta
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCuentaId() As Integer
        Get
            intmCuentaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intCuentaId", "0"))
            Return intmCuentaId
        End Get
    End Property

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
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 10
        Const strRecordBrowserName As String = "SucursalVerCuentaAsignada"

        '' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1"))

        '' Si los identificadores direccion y zona son válidos
        If intDireccionId > 0 AndAlso intZonaId > 0 AndAlso intSucursalId > 0 Then

            ' Buscamos las cuentas de la sucursal
            Dim astrDataArray As Array = Benavides.CC.Data.clsCuenta.strBuscarPorSucursal(intCompaniaId, intSucursalId, intTipoCuentaId, CInt(Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage)), intElementsPerPage, strConnectionString)

            ' Establecemos los eventos onClick actual y futuro
            Dim strCurrentJavascriptOnClickEvent As String = "onclick=""window.location='SucursalVerCuentaAsignada.aspx?intDireccionId=" & intDireccionId & "&amp;intZonaId=" & intZonaId & "&amp;strCmd=Agregar'"""
            Dim strNewJavascriptOnClickEvent As String = "onclick=""cmdNavegadorRegistrosAgregar_onclick(" & intDireccionId & ", " & intZonaId & ", " & intCompaniaId & ", " & intSucursalId & ");"""

            ' Obtenemos el HTML
            Dim strReturn As String = Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId & "&")

            ' Regresamos el resultado
            Return Replace(strReturn, strCurrentJavascriptOnClickEvent, strNewJavascriptOnClickEvent)

        End If
        Return ""

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Enviamos al usuario actual a la página origen, si los identificadores de la dirección y zona son inválidos
        If intDireccionId < 1 OrElse intZonaId < 1 Then
            Call Response.Redirect("SucursalAsignarCuentaSucursal.aspx")
        End If

        ' Almacenamos el comando ejecutado
        Dim strCmd As String = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Desasignar"

                ' Si los campos obligatorios fueron llenados
                If intTipoCuentaId > 0 AndAlso intCuentaId > 0 Then

                    ' Buscamos la cuenta a eliminar
                    Dim astrData As Array = Benavides.CC.Data.clstblCuentaSucursal.strBuscar(intCompaniaId, intSucursalId, intCuentaId, Now(), "", 0, 0, strConnectionString)

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
                                    Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeHaciaServidoresPuntoDeVenta("clstblCuentaSucursal", Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ELIMINAR, "", astrData, astrStore)

                                    ' Eliminamos el registro especificado
                                    Call Benavides.CC.Data.clstblCuentaSucursal.intEliminar(intCompaniaId, intSucursalId, intCuentaId, Now(), strUsuarioNombre, strConnectionString)

                                End If

                            Else

                                ' Notificamos al usuario de una falla de integridad en la información
                                strJavascriptWindowOnLoadCommands &= "alert(""La sucursal no tiene asignada una tienda.\n\r\n\rLa acción no pudo ser llevada a cabo."");" & vbCrLf

                            End If

                        End If

                    End If

                End If

                'Call Response.Redirect("SucursalVerCuentaAsignada.aspx?intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId & "&intCompaniaId=" & intCompaniaId & "&intSucursalId=" & intSucursalId)

        End Select

    End Sub

End Class
