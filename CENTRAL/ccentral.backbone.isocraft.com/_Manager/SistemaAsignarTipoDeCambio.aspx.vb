'====================================================================
' Class         : clsSistemaAsignarTipoDeCambio
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Asignar tipo de cambio
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Joaquín Hernández García
' Version       : 1.0
' Last Modified : Monday, May 31, 2004
'====================================================================
Public Class clsSistemaAsignarTipoDeCambio
    Inherits System.Web.UI.Page

    ' Variables locales privadas
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private intmMonedaId As Integer
    Private intmDireccionId As Integer
    Private intmZonaId As Integer
    Private strmSucursales As String
    Private strmTipoDeCambioMonedaValor As String

    '====================================================================
    ' Name       : intMonedaId
    ' Description: Identificador de la Moneda
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intMonedaId() As Integer
        Get
            If intmMonedaId = 0 Then
                intmMonedaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboMoneda", isocraft.commons.clsWeb.strGetPageParameter("intMonedaId", "0")))
            End If
            Return intmMonedaId
        End Get
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
    ' Description: Identificador de la Compañía
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCompaniaId() As Integer
        Get
            Return CInt(isocraft.commons.clsWeb.strGetPageParameter("intCompaniaId", "0"))
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
            Return CInt(isocraft.commons.clsWeb.strGetPageParameter("intSucursalId", "0"))
        End Get
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
    ' Name       : strTipoDeCambioMonedaValor
    ' Description: Tipo de cambio
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTipoDeCambioMonedaValor() As String
        Get
            If Len(strmTipoDeCambioMonedaValor) = 0 Then
                strmTipoDeCambioMonedaValor = isocraft.commons.clsWeb.strGetPageParameter("txtTipoDeCambioMonedaValor", "")
            End If
            Return strmTipoDeCambioMonedaValor
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
    ' Name       : strCmd 
    ' Description: Obtiene o establece el comando actual
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
    ' Name       : strLlenarMonedaComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboMoneda"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarMonedaComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboMoneda", intMonedaId, Benavides.CC.Data.clstblMoneda.strBuscar(0, "", "", Now, "", 0, 0, strConnectionString), 0, 2, 1)
    End Function

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
        Const strRecordBrowserName As String = "SucursalAsignarTipoDeCambio"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1"))
        Dim astrSucursalesSeleccionadas As Array = Nothing
        Dim astrCompaniaSucursal As Array = Nothing

        ' Si los identificadores de la moneda, direccion y zona son válidos
        If intMonedaId > 0 AndAlso intDireccionId > 0 AndAlso intZonaId > 0 AndAlso Len(strSucursales) > 0 Then

            ' Buscamos las sucursales de esta dirección y zona que tienen asignadas a la moneda especificada
            Dim astrDataArray As Array = Benavides.CC.Data.clsTienda.clsSucursal.strBuscarSucursalesConMonedasAsignadas(intMonedaId, intDireccionId, intZonaId, strConnectionString)

            ' Almacenamos en un arreglo la lista de compañías y sucursales
            ' La lista tiene el siguiente formato:
            '   intCompaniaId | intSucursalId , intCompaniaId | intSucursalId, ..., intCompaniaId | intSucursalId
            Dim astrIdentificadoresCompaniaSucursal As Array = strSucursales.Split(","c)

            ' Si obtuvimos pares de identificadores "intCompaniaId | intSucursalId"
            If astrIdentificadoresCompaniaSucursal.Length > 0 Then

                ' Creamos la lista que almacenará a los identificadores de la compañía y sucursal
                Dim astrListaSucursalesSeleccionadas As System.Collections.ArrayList = New System.Collections.ArrayList

                ' Recorremos los pares identificadores
                Dim strCompaniaIdentificadorSucursal As String
                For Each strCompaniaIdentificadorSucursal In astrIdentificadoresCompaniaSucursal

                    ' Separamos los pares identificadores y los almacenamos en un arreglo
                    astrCompaniaSucursal = strCompaniaIdentificadorSucursal.Split("|"c)

                    ' Agregamos al arreglo resultante a la lista de las sucursales seleccionadas
                    Call astrListaSucursalesSeleccionadas.Add(astrCompaniaSucursal)
                    astrCompaniaSucursal = Nothing

                Next

                astrSucursalesSeleccionadas = astrListaSucursalesSeleccionadas.ToArray()

            End If

            ' Si fueron seleccionadas sucursales
            If IsNothing(astrSucursalesSeleccionadas) = False AndAlso astrSucursalesSeleccionadas.Length > 0 Then

                Dim astrSucursalesResultantes As System.Collections.ArrayList = New System.Collections.ArrayList
                Dim astrRecord As Array = Nothing

                ' Recorremos las sucursales seleccionadas
                For Each astrCompaniaSucursal In astrSucursalesSeleccionadas

                    ' Recorremos las sucursales que pertenecen a la dirección y zona especificada
                    For Each astrRecord In astrDataArray

                        ' Agregamos la sucursal actual, si la compañía y la sucursal seleccionada corresponden a esta sucursal
                        If CInt(astrRecord.GetValue(0)) = CInt(astrCompaniaSucursal.GetValue(0)) AndAlso CInt(astrRecord.GetValue(1)) = CInt(astrCompaniaSucursal.GetValue(1)) Then
                            astrSucursalesResultantes.Add(astrRecord)
                            Exit For
                        End If

                    Next

                Next

                ' Redefinimos el arreglo de sucursales
                Dim strElementCounter As String = CStr(astrSucursalesResultantes.Count)
                astrDataArray = astrSucursalesResultantes.ToArray()
                For Each astrRecord In astrDataArray
                    Call astrRecord.SetValue(strElementCounter, astrRecord.Length - 1)
                Next

            End If

            ' Generamos el navegador de registros
            Dim strReturn As String = Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?strSucursales=" & strSucursales & "&intMonedaId=" & intMonedaId & "&intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId & "&")

            Return strReturn.Replace("Asignar tipo de cambio para la moneda", "Asignar tipo de cambio para la moneda<input name=""txtMonedaNombre"" type=""text"" class=""fieldred"" id=""txtMonedaNombre"" size=""50"" maxlength=""50"" readonly=""true""><p>Capture el tipo de cambio que se aplicar&aacute; para la moneda indicada en las sucursales que aparecen en la lista. </p><table width=""30%""  border=""0"" cellspacing=""0"" cellpadding=""0""><tr><td width=""43%"" class=""tdtexttablebold"">Tipo de cambio : </td><td width=""57%"" class=""tdpadleft5""><input name=""txtTipoDeCambioMonedaValor"" type=""text"" class=""field"" id=""txtTipoDeCambioMonedaValor"" size=""25"" maxlength=""25"" value=""" & strTipoDeCambioMonedaValor & """></td></tr><tr><td colspan=""2""><br><input name=""cmdAsignar"" type=""button"" class=""button"" id=""cmdAsignar"" value=""Asignar tipo de cambio"" onclick=""return cmdAsignar_onclick()""></td></tr></table><br>")


        End If

    End Function

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos la lista de sucursales seleccionadas
        strSucursales = isocraft.commons.clsWeb.strGetPageParameter("txtSucursales", isocraft.commons.clsWeb.strGetPageParameter("strSucursales", ""))

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Borrar"

                ' Desasignamos la moneda de la sucusal, si los identificadores son válidos
                If intMonedaId > 0 AndAlso intDireccionId > 0 AndAlso intZonaId > 0 AndAlso intCompaniaId > 0 AndAlso intSucursalId > 0 AndAlso Len(strSucursales) > 0 Then

                    Dim strTextToReplace As String = intCompaniaId & "|" & intSucursalId
                    strSucursales = strSucursales.Replace(strTextToReplace & ",", "")
                    strSucursales = strSucursales.Replace("," & strTextToReplace, "")
                    strSucursales = strSucursales.Replace(strTextToReplace, "")

                End If

            Case "Asignar"

                ' Asignamos la moneda de la sucusal, si los identificadores son válidos
                If intMonedaId > 0 AndAlso Len(strSucursales) > 0 Then

                    ' Almacenamos en un arreglo la lista de compañías y sucursales
                    ' La lista tiene el siguiente formato:
                    '   intCompaniaId | intSucursalId , intCompaniaId | intSucursalId, ..., intCompaniaId | intSucursalId
                    Dim astrIdentificadoresCompaniaSucursal As Array = strSucursales.Split(","c)

                    ' Si obtuvimos pares de identificadores "intCompaniaId | intSucursalId"
                    If astrIdentificadoresCompaniaSucursal.Length > 0 Then

                        ' Obtenemos el valor de la moneda base "PESOS"
                        Dim intMonedaBaseId As Integer = 0
                        Dim astrMonedaBase As Array = Benavides.CC.Data.clstblMoneda.strBuscar(0, "PESOS", "", Now, "", 0, 0, strConnectionString)
                        If astrMonedaBase.Length > 0 Then
                            intMonedaBaseId = CInt(DirectCast(astrMonedaBase.GetValue(0), Array).GetValue(0))
                        End If

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
                                Dim fltTipoDeCambioMonedaValor As Double = CDbl(isocraft.commons.clsWeb.strGetPageParameter("txtTipoDeCambioMonedaValor", "0"))

                                ' Actualizamos el tipo de cambio, si la compañía y la sucursal son válidos
                                If intCompaniaId > 0 AndAlso intSucursalId > 0 Then
                                    Call Benavides.CC.Data.clstblTipoDeCambioMoneda.intActualizar(intMonedaId, intMonedaBaseId, intCompaniaId, intSucursalId, fltTipoDeCambioMonedaValor, Now, strUsuarioNombre, strConnectionString)
                                End If

                            End If

                        Next

                    End If

                End If

        End Select

    End Sub

End Class
