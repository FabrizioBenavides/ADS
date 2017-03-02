'====================================================================
' Class         : clsSucursalAsignarCuentasEnLote
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Asignar en lote cuentas 
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Javier Ramos
' Version       : 1.0
' Last Modified : Thursday, June 17, 2004
'====================================================================
Public Class clsSucursalAsignarCuentasEnLote
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
    Private intmTipoCuentaId As Integer
    Private strmCompaniaSucursalId As String
    Private strmDestinoCompaniaSucursalId As String
    Private strmCuentas As String

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
    ' Name       : intTipoCuentaId
    ' Description: Identificador de la Zona
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intTipoCuentaId() As Integer
        Get
            If intmTipoCuentaId = 0 Then
                intmTipoCuentaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboTipoCuenta", isocraft.commons.clsWeb.strGetPageParameter("intTipoCuentaId", "0")))
            End If
            Return intmTipoCuentaId
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
    ' Name       : strTodoSucursales
    ' Description: Indicador de selección de las sucursales
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTodoSucursales() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("chkTodoSucursales", "false")
        End Get
    End Property

    '====================================================================
    ' Name       : strTodoCuentas
    ' Description: Indicador de selección de las cuentas
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTodoCuentas() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("chkTodoCuentas", "false")
        End Get
    End Property

    '====================================================================
    ' Name       : strDestinoCompaniaSucursalId
    ' Description: Identificador de la Compania y la Sucursal
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strDestinoCompaniaSucursalId() As String
        Get
            If Len(strmDestinoCompaniaSucursalId) = 0 Then
                strmDestinoCompaniaSucursalId = isocraft.commons.clsWeb.strGetPageParameter("cboSucursales", "0|0")
            End If
            Return strmDestinoCompaniaSucursalId
        End Get
    End Property

    '====================================================================
    ' Name       : strCuentas
    ' Description: Cuentas seleccionadas
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCuentas() As String
        Get
            If Len(strmCuentas) = 0 Then
                strmCuentas = isocraft.commons.clsWeb.strGetPageParameter("cboCuentas", "")
            End If
            Return strmCuentas
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
    ' Name       : strLlenarSucursalesDestinoComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboSucursales"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarSucursalesDestinoComboBox() As String
        If intDestinoDireccionId > 0 AndAlso intDestinoZonaId > 0 Then
            Dim astrDestinoCompaniaSucursalId As String() = strDestinoCompaniaSucursalId.Split(","c)
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSucursales", astrDestinoCompaniaSucursalId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDestinoDireccionId, intDestinoZonaId, strConnectionString), New Integer(1) {0, 1}, 2, 0)
        End If
    End Function

    '====================================================================
    ' Name       : strLlenarCuentasComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboPoliticas"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarCuentasComboBox() As String
        If intDireccionId > 0 AndAlso intZonaId > 0 AndAlso strCompaniaSucursalId.Equals("0|0") = False AndAlso intTipoCuentaId >= 0 Then
            Dim astrCuentas As String() = strCuentas.Split(","c)
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboCuentas", astrCuentas, Benavides.CC.Data.clsCuenta.strBuscarPorSucursal(intCompaniaId, intSucursalId, intTipoCuentaId, 0, 0, strConnectionString), New Integer() {3}, 4, 0)
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
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Enviamos al usuario actual a la página origen, si los identificadores de la dirección y zona son inválidos
        If intDestinoDireccionId < 1 OrElse intDestinoZonaId < 1 Then
            Call Response.Redirect("SucursalAsignarCuentaSucursal.aspx")
        End If

        ' Almacenamos el comando ejecutado
        Dim strCmd As String = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Asignar"

                ' Obtenemos la cadena de compañías y sucursales
                Dim astrDestinoCompaniaSucursalId As Array = strDestinoCompaniaSucursalId.Split(","c)

                ' Si la cadena tiene algún contenido
                If astrDestinoCompaniaSucursalId.Length > 0 Then

                    ' Declaramos e inicializamos la lista de compañías y sucursales que obtendremos a partir de su cadena
                    Dim astrListaCompaniaSucursal As System.Collections.ArrayList = New System.Collections.ArrayList
                    Dim strParCompaniaSucursal As String = String.Empty

                    ' Para cada par de enteros en el formato "intCompañiaId|intSucursalId"
                    For Each strParCompaniaSucursal In astrDestinoCompaniaSucursalId

                        ' Separamos la compañía y la sucursal
                        Dim astrElementoCompaniaSucursal As Array = strParCompaniaSucursal.Split("|"c)

                        ' Los agregamos a una lista que nos permita acceder a los mismos de forma individual
                        If astrElementoCompaniaSucursal.Length > 0 Then
                            astrListaCompaniaSucursal.Add(astrElementoCompaniaSucursal)
                        End If

                    Next

                    ' Obtenemos el arreglo de compañías y sucursales
                    Dim astrCompaniaSucursal As Array = astrListaCompaniaSucursal.ToArray()

                    ' Si el arreglo compañías y sucursales contiene elementos
                    If astrCompaniaSucursal.Length > 0 Then

                        ' Obtenemos el arreglo de cuentas
                        Dim astrCuentas As Array = strCuentas.Split(","c)

                        ' Si el arreglo tiene elementos
                        If astrCuentas.Length > 0 Then

                            ' Por cada sucursal destino seleccionada
                            Dim astrElementoCompaniaSucursal As Array = Nothing
                            For Each astrElementoCompaniaSucursal In astrCompaniaSucursal

                                ' Obtenemos la compañía y la sucursal
                                Dim intDestinoCompaniaId As Integer = CInt(astrElementoCompaniaSucursal.GetValue(0))
                                Dim intDestinoSucursalId As Integer = CInt(astrElementoCompaniaSucursal.GetValue(1))

                                ' Si la compañía y la sucursal son válidas
                                If intDestinoCompaniaId > 0 AndAlso intDestinoSucursalId > 0 Then

                                    ' Por cada política seleccionada
                                    Dim strCuentaId As String = String.Empty
                                    For Each strCuentaId In astrCuentas

                                        ' Obtenemos el identificador de la cuenta
                                        Dim intCuentaId As Integer = CInt(strCuentaId)

                                        ' Si el identificador de la cuenta es válido
                                        If intCuentaId > 0 Then

                                            ' Buscamos la cuenta
                                            Dim astrData As Array = Benavides.CC.Data.clstblCuentaSucursal.strBuscar(intDestinoCompaniaId, intDestinoSucursalId, intCuentaId, Now(), "", 0, 0, strConnectionString)

                                            ' Si la cuenta no existe entonces
                                            If astrData.Length = 0 Then
                                                Call Benavides.CC.Data.clstblCuentaSucursal.intAgregar(intDestinoCompaniaId, intDestinoSucursalId, intCuentaId, Now(), strUsuarioNombre, strConnectionString)
                                            End If
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    End If
                End If

                ' Regresamos a la página origen
                Call Response.Redirect("SucursalAsignarCuentaSucursal.aspx?intDireccionId=" & intDestinoDireccionId & "&intZonaId=" & intDestinoZonaId)

        End Select


    End Sub

End Class
