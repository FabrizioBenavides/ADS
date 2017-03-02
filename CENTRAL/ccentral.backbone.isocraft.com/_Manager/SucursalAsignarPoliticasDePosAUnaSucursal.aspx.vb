'====================================================================
' Class         : clsSucursalAsignarPoliticasDePosAUnaSucursal
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Asignar políticas de POS a una sucursal
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Joaquín Hernández García
' Version       : 1.0
' Last Modified : Monday, July 01, 2004
'====================================================================
Public Class clsSucursalAsignarPoliticasDePosAUnaSucursal
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
    Private intmDestinoDireccionId As Integer
    Private intmDestinoZonaId As Integer
    Private intmDireccionId As Integer
    Private intmZonaId As Integer
    Private intmDestinoCompaniaId As Integer
    Private intmDestinoSucursalId As Integer
    Private strmCompaniaSucursalId As String
    Private intmCajaId As Integer
    Private strmDestinoCajaId As String
    Private strmPoliticas As String

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
                intmDireccionId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboDireccion", isocraft.commons.clsWeb.strGetPageParameter("intDireccionId", "0")))
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
                intmZonaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboZona", isocraft.commons.clsWeb.strGetPageParameter("intZonaId", "0")))
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
            Dim astrCompaniaId As Array = Split(strCompaniaSucursalId, "|")
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
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intSucursalId() As Integer
        Get
            Dim astrSucursalId As Array = Split(strCompaniaSucursalId, "|")
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
            If intmCajaId = 0 Then
                intmCajaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboCaja", isocraft.commons.clsWeb.strGetPageParameter("intCajaId", "0")))
            End If
            Return intmCajaId
        End Get
    End Property

    '====================================================================
    ' Name       : intDestinoDireccionId
    ' Description: Identificador de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDestinoDireccionId() As Integer
        Get
            If intmDestinoDireccionId = 0 Then
                intmDestinoDireccionId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intDestinoDireccionId", isocraft.commons.clsWeb.strGetPageParameter("txtDestinoDireccionId", "0")))
            End If
            Return intmDestinoDireccionId
        End Get
    End Property

    '====================================================================
    ' Name       : intDestinoZonaId
    ' Description: Identificador de la Zona
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDestinoZonaId() As Integer
        Get
            If intmDestinoZonaId = 0 Then
                intmDestinoZonaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intDestinoZonaId", isocraft.commons.clsWeb.strGetPageParameter("txtDestinoZonaId", "0")))
            End If
            Return intmDestinoZonaId
        End Get
    End Property

    '====================================================================
    ' Name       : intDestinoCompaniaId
    ' Description: Identificador de la Compañía
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDestinoCompaniaId() As Integer
        Get
            If intmDestinoCompaniaId = 0 Then
                intmDestinoCompaniaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intDestinoCompaniaId", isocraft.commons.clsWeb.strGetPageParameter("txtDestinoCompaniaId", "0")))
            End If
            Return intmDestinoCompaniaId
        End Get
    End Property

    '====================================================================
    ' Name       : intDestinoSucursalId
    ' Description: Identificador de la Sucursal
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDestinoSucursalId() As Integer
        Get
            If intmDestinoSucursalId = 0 Then
                intmDestinoSucursalId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intDestinoSucursalId", isocraft.commons.clsWeb.strGetPageParameter("txtDestinoSucursalId", "0")))
            End If
            Return intmDestinoSucursalId
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
    ' Name       : strTodoCajas
    ' Description: Indicador de selección de las cajas
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTodoCajas() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("chkTodoCajas", "false")
        End Get
    End Property

    '====================================================================
    ' Name       : strTodoPoliticas
    ' Description: Indicador de selección de las políticas
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTodoPoliticas() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("chkTodoPoliticas", "false")
        End Get
    End Property

    '====================================================================
    ' Name       : strDestinoCajaId
    ' Description: Identificador de las Cajas
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strDestinoCajaId() As String
        Get
            If Len(strmDestinoCajaId) = 0 Then
                strmDestinoCajaId = isocraft.commons.clsWeb.strGetPageParameter("cboCajas", "0|0")
            End If
            Return strmDestinoCajaId
        End Get
    End Property

    '====================================================================
    ' Name       : strPoliticas
    ' Description: Politicas seleccionadas
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strPoliticas() As String
        Get
            If Len(strmPoliticas) = 0 Then
                strmPoliticas = isocraft.commons.clsWeb.strGetPageParameter("cboPoliticas", "")
            End If
            Return strmPoliticas
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
            If intDestinoDireccionId > 0 Then
                Dim astrData As Array = Benavides.CC.Data.clstblDireccionOperativa.strBuscar(intDestinoDireccionId, "", "", Now, "", 0, 0, strConnectionString)
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
            If intDestinoDireccionId > 0 AndAlso intDestinoZonaId > 0 Then
                Dim astrData As Array = Benavides.CC.Data.clstblZonaOperativa.strBuscar(intDestinoDireccionId, intDestinoZonaId, "", "", Now, "", 0, 0, strConnectionString)
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
            If intDestinoCompaniaId > 0 AndAlso intDestinoSucursalId > 0 Then
                Dim astrData As Array = Benavides.CC.Data.clstblSucursal.strBuscar(intDestinoCompaniaId, intDestinoSucursalId, 0, 0, "", 0, 0, 0, Now, "", "", "", "", 0, 0, strConnectionString)
                If IsArray(astrData) = True AndAlso astrData.Length > 0 Then
                    Return CStr(DirectCast(astrData.GetValue(0), Array).GetValue(4))
                End If
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strLlenarSucursalComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboSucursal"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarSucursalComboBox() As String
        If intDireccionId > 0 AndAlso intZonaId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSucursal", strCompaniaSucursalId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, intZonaId, strConnectionString), New Integer(1) {0, 1}, 2, 1)
        End If
    End Function

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
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboCaja", intCajaId, Benavides.CC.Data.clstblCaja.strBuscar(intCompaniaId, intSucursalId, 0, 0, 0, "", "", "", "", Now, Now, "", 0, 0, strConnectionString), 2, 6, 1)
        End If
    End Function

    '====================================================================
    ' Name       : strLlenarCajasDestinoComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboCajas"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarCajasDestinoComboBox() As String
        If intDestinoDireccionId > 0 AndAlso intDestinoZonaId > 0 AndAlso intDestinoCompaniaId > 0 AndAlso intDestinoSucursalId > 0 Then
            Dim astrDestinoCajaId As String() = strDestinoCajaId.Split(","c)
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboCajas", astrDestinoCajaId, Benavides.CC.Data.clstblCaja.strBuscar(intDestinoCompaniaId, intDestinoSucursalId, 0, 0, 0, "", "", "", "", Now, Now, "", 0, 0, strConnectionString), 2, 6, 0)
        End If
    End Function

    '====================================================================
    ' Name       : strLlenarPoliticasComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboPoliticas"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarPoliticasComboBox() As String
        If intDireccionId > 0 AndAlso intZonaId > 0 AndAlso strCompaniaSucursalId.Equals("0|0") = False AndAlso intCajaId > 0 Then
            Dim astrPoliticas As String() = strPoliticas.Split(","c)
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboPoliticas", astrPoliticas, Benavides.CC.Data.clsPoliticaPOSSucursal.strBuscar(intCompaniaId, intSucursalId, intCajaId, 0, 0, 0, strConnectionString), 3, 4, 0)
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
    ' Name       : strLlenarDireccionComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboDireccion"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarDireccionComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccion", intDireccionId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString), 0, 1, 1)
    End Function

    '====================================================================
    ' Name       : strLlenarZonaComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboZona"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarZonaComboBox() As String
        If intDireccionId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZona", intZonaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, 0, strConnectionString), 0, 1, 1)
        End If
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, "SucursalAdministrarPoliticasDePOS.aspx", strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Enviamos al usuario actual a la página origen, si los identificadores de la dirección y zona son inválidos
        If intDestinoDireccionId < 1 OrElse intDestinoZonaId < 1 OrElse intDestinoCompaniaId < 1 OrElse intDestinoSucursalId < 1 Then
            Call Response.Redirect("SucursalAdministrarPoliticasDePOS.aspx")
        End If

        ' Almacenamos el comando ejecutado
        Dim strCmd As String = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Asignar"

                ' Obtenemos las políticas seleccionadas
                Dim astrPoliticas As Array = strPoliticas.Split(","c)

                ' Si se seleccionaron políticas
                If astrPoliticas.Length > 0 Then

                    ' Obtenemos las cajas seleccionadas
                    Dim astrDestinoCajaId As Array = strDestinoCajaId.Split(","c)

                    ' Si se seleccionaron cajas
                    If strDestinoCajaId.Length > 0 Then

                        ' Por cada caja destino
                        Dim intDestinoCajaId As Integer = 0
                        For Each intDestinoCajaId In astrDestinoCajaId

                            ' Si el identificador de la caja es válido
                            If intDestinoCajaId > 0 Then

                                ' Por cada política seleccionada
                                Dim intTipoDatoPoliticaPOSId As Integer = 0
                                For Each intTipoDatoPoliticaPOSId In astrPoliticas

                                    ' Si el identificador de la política es válido
                                    If intTipoDatoPoliticaPOSId > 0 Then

                                        ' Si la política no existe para la caja destino
                                        If Benavides.CC.Data.clstblPoliticaPosSucursal.strBuscar(intTipoDatoPoliticaPOSId, intDestinoCompaniaId, intDestinoSucursalId, intDestinoCajaId, "", Now, "", 0, 0, strConnectionString).Length = 0 Then

                                            ' Buscamos la política origen
                                            Dim astrData As Array = Benavides.CC.Data.clsPoliticaPOSSucursal.strBuscar(intCompaniaId, intSucursalId, intCajaId, intTipoDatoPoliticaPOSId, 0, 0, strConnectionString)

                                            ' Si la política origen fue encontrada
                                            If astrData.Length > 0 Then

                                                ' Obtenemos el valor de la política
                                                Dim strPoliticaPOSSucursalValor As String = CStr(DirectCast(astrData.GetValue(0), Array).GetValue(5))

                                                ' Agregamos la política a la compañía y sucursal destino, si el identificador de la caja es válido
                                                Call Benavides.CC.Data.clstblPoliticaPosSucursal.intAgregar(intTipoDatoPoliticaPOSId, intDestinoCompaniaId, intDestinoSucursalId, intDestinoCajaId, strPoliticaPOSSucursalValor, Now, strUsuarioNombre, strConnectionString)

                                            End If

                                        End If

                                    End If

                                Next

                            End If

                        Next

                    End If

                End If

                ' Regresamos a la página origen
                Call Response.Redirect("SucursalAdministrarPoliticasDePOS.aspx?intDireccionId=" & intDestinoDireccionId & "&intZonaId=" & intDestinoZonaId)

        End Select

    End Sub

End Class
