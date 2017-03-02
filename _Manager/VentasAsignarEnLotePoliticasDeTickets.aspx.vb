'====================================================================
' Class         : clsVentasAsignarEnLotePoliticasDeTickets
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Asignar en lote pol�ticas de ticket
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Joaqu�n Hern�ndez Garc�a
' Version       : 1.0
' Last Modified : Thursday, June 17, 2004
'====================================================================
Public Class clsVentasAsignarEnLotePoliticasDeTickets
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
    Private strmCompaniaSucursalId As String
    Private strmDestinoCompaniaSucursalId As String
    Private strmPoliticas As String

    '====================================================================
    ' Name       : intDireccionId
    ' Description: Identificador de la Direcci�n
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
    ' Name       : intDestinoDireccionId
    ' Description: Identificador de la Direcci�n
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
    ' Description: Indicador de selecci�n de las sucursales
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
    ' Name       : strTodoPoliticas
    ' Description: Indicador de selecci�n de las pol�ticas
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
    ' Description: Nombre de la Direcci�n
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
    ' Name       : strLlenarSucursalComboBox
    ' Description: Regresa una cadena de texto con el c�digo Javascript
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
    ' Description: Regresa una cadena de texto con el c�digo Javascript
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
    ' Name       : strLlenarPoliticasComboBox
    ' Description: Regresa una cadena de texto con el c�digo Javascript
    '              que llena al combo box "cboPoliticas"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarPoliticasComboBox() As String
        If intDireccionId > 0 AndAlso intZonaId > 0 AndAlso strCompaniaSucursalId.Equals("0|0") = False Then
            Dim astrPoliticas As String() = strPoliticas.Split(","c)
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboPoliticas", astrPoliticas, Benavides.CC.Data.clstblPoliticaTicket.strBuscar(0, intCompaniaId, intSucursalId, "", "", Now, "", 0, 0, strConnectionString), 0, 3, 0)
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
    ' Description: Regresa una cadena de texto con el c�digo Javascript
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
    ' Description: Regresa una cadena de texto con el c�digo Javascript
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

        ' Enviamos al usuario actual a la p�gina de acceso, si no tiene privilegios de acceder a esta p�gina
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Enviamos al usuario actual a la p�gina origen, si los identificadores de la direcci�n y zona son inv�lidos
        If intDestinoDireccionId < 1 OrElse intDestinoZonaId < 1 Then
            Call Response.Redirect("VentasAdministrarPoliticasDeTickets.aspx")
        End If

        ' Almacenamos el comando ejecutado
        Dim strCmd As String = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Asignar"

                ' Obtenemos la cadena de compa��as y sucursales
                Dim astrDestinoCompaniaSucursalId As Array = strDestinoCompaniaSucursalId.Split(","c)

                ' Si la cadena tiene alg�n contenido
                If astrDestinoCompaniaSucursalId.Length > 0 Then

                    ' Declaramos e inicializamos la lista de compa��as y sucursales que obtendremos a partir de su cadena
                    Dim astrListaCompaniaSucursal As System.Collections.ArrayList = New System.Collections.ArrayList
                    Dim strParCompaniaSucursal As String = String.Empty

                    ' Para cada par de enteros en el formato "intCompa�iaId|intSucursalId"
                    For Each strParCompaniaSucursal In astrDestinoCompaniaSucursalId

                        ' Separamos la compa��a y la sucursal
                        Dim astrElementoCompaniaSucursal As Array = strParCompaniaSucursal.Split("|"c)

                        ' Los agregamos a una lista que nos permita acceder a los mismos de forma individual
                        If astrElementoCompaniaSucursal.Length > 0 Then
                            astrListaCompaniaSucursal.Add(astrElementoCompaniaSucursal)
                        End If

                    Next

                    ' Obtenemos el arreglo de compa��as y sucursales
                    Dim astrCompaniaSucursal As Array = astrListaCompaniaSucursal.ToArray()

                    ' Si el arreglo compa��as y sucursales contiene elementos
                    If astrCompaniaSucursal.Length > 0 Then

                        ' Obtenemos el arreglo de pol�ticas
                        Dim astrPoliticas As Array = strPoliticas.Split(","c)

                        ' Si el arreglo tiene elementos
                        If astrPoliticas.Length > 0 Then

                            ' Por cada sucursal destino seleccionada
                            Dim astrElementoCompaniaSucursal As Array = Nothing
                            For Each astrElementoCompaniaSucursal In astrCompaniaSucursal

                                ' Obtenemos la compa��a y la sucursal
                                Dim intDestinoCompaniaId As Integer = CInt(astrElementoCompaniaSucursal.GetValue(0))
                                Dim intDestinoSucursalId As Integer = CInt(astrElementoCompaniaSucursal.GetValue(1))

                                ' Si la compa��a y la sucursal son v�lidas
                                If intDestinoCompaniaId > 0 AndAlso intDestinoSucursalId > 0 Then

                                    ' Por cada pol�tica seleccionada
                                    Dim strPoliticaId As String = String.Empty
                                    For Each strPoliticaId In astrPoliticas

                                        ' Obtenemos el identificador de la pol�tica
                                        Dim intPoliticaTicketId As Integer = CInt(strPoliticaId)

                                        ' Si el identificador de la pol�tica es v�lido
                                        If intPoliticaTicketId > 0 Then

                                            ' Si la pol�tica no existe para la compan�a y sucursal destino
                                            If Benavides.CC.Data.clstblPoliticaTicket.strBuscar(intPoliticaTicketId, intDestinoCompaniaId, intDestinoSucursalId, "", "", Now, "", 0, 0, strConnectionString).Length = 0 Then

                                                ' Buscamos la pol�tica origen
                                                Dim astrData As Array = Benavides.CC.Data.clstblPoliticaTicket.strBuscar(intPoliticaTicketId, intCompaniaId, intSucursalId, "", "", Now, "", 0, 0, strConnectionString)

                                                ' Si la encontramos
                                                If astrData.Length > 0 Then

                                                    ' Agregamos la pol�tica a la compa��a y sucursal destino
                                                    Call Benavides.CC.Data.clstblPoliticaTicket.intAgregar(intPoliticaTicketId, intDestinoCompaniaId, intDestinoSucursalId, CStr(DirectCast(astrData.GetValue(0), Array).GetValue(3)), CStr(DirectCast(astrData.GetValue(0), Array).GetValue(4)), Now, strUsuarioNombre, strConnectionString)

                                                End If

                                            End If

                                        End If

                                    Next

                                End If

                            Next

                        End If

                    End If

                End If

                ' Regresamos a la p�gina origen
                Call Response.Redirect("VentasAdministrarPoliticasDeTickets.aspx?intDireccionId=" & intDestinoDireccionId & "&intZonaId=" & intDestinoZonaId)

        End Select

    End Sub

End Class
