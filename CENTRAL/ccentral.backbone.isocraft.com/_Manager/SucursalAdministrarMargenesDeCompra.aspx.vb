'====================================================================
' Class         : clsSucursalAdministrarMargenesDeCompra
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Administrar márgenes de compra
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Joaquín Hernández García
' Version       : 1.0
' Last Modified : Thursday, June 10, 2004
'====================================================================
Public Class clsSucursalAdministrarMargenesDeCompra
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
    Private strmSucursales As String

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
        Const strRecordBrowserName As String = "SucursalAdministrarMargenesDeCompra"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "1"))
        Dim astrSucursalesSeleccionadas As Array = Nothing
        Dim astrCompaniaSucursal As Array = Nothing
        Dim strSucursalMargenSuperiorCompra As String = isocraft.commons.clsWeb.strGetPageParameter("txtSucursalMargenSuperiorCompra", "")
        Dim strSucursalMargenInferiorCompra As String = isocraft.commons.clsWeb.strGetPageParameter("txtSucursalMargenInferiorCompra", "")

        ' Si los identificadores de la direccion y zona son válidos
        If intDireccionId > 0 AndAlso intZonaId > 0 AndAlso Len(strSucursales) > 0 Then

            ' Buscamos las sucursales de esta dirección y zona
            Dim astrDataArray As Array = Benavides.CC.Data.clstblSucursal.strBuscar(0, 0, 0, 0, "", 0, 0, 0, Now, "", "", "", "", 0, 0, strConnectionString)

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
            Dim strReturn As String = Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, astrDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?strSucursales=" & strSucursales & "&intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId & "&")
            Return strReturn.Replace("Asignar márgenes para las sucursales elegidas", "Asignar márgenes para las sucursales elegidas <br>&nbsp;<p>Capture o edite los m&aacute;rgenes de compra que se aplicar&aacute;n a las sucursales de la lista. </p><table width=""50%""  border=""0"" cellspacing=""0"" cellpadding=""0""><tr><td width=""43%"" class=""tdtexttablebold"">Margen inferior de compra: </td><td width=""57%"" class=""tdpadleft5""><input name=""txtSucursalMargenInferiorCompra"" type=""text"" class=""field"" size=""25"" maxlength=""25"" value=""" & strSucursalMargenInferiorCompra & """></td></tr><tr><td class=""tdtexttablebold"">Margen superior de compra: </td><td class=""tdpadleft5""><input name=""txtSucursalMargenSuperiorCompra"" type=""text"" class=""field"" size=""25"" maxlength=""25"" value=""" & strSucursalMargenSuperiorCompra & """></td></tr><tr><td colspan=""2"" class=""tdpadleft5""><br><input name=""cmdAsignar"" type=""button"" class=""button"" value=""Asignar los m&aacute;rgenes"" onclick=""cmdAsignar_onclick()"">&nbsp;&nbsp;<input name=""cmdCancelar"" type=""button"" class=""button"" id=""cmdCancelar"" onclick=""return cmdCancelar_onClick()"" value=""Cancelar""></td></tr></table>")

        End If

    End Function

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

                ' Borramos la sucusal de la lista, si los identificadores son válidos
                If intDireccionId > 0 AndAlso intZonaId > 0 AndAlso intCompaniaId > 0 AndAlso intSucursalId > 0 AndAlso Len(strSucursales) > 0 Then

                    Dim strTextToReplace As String = intCompaniaId & "|" & intSucursalId
                    strSucursales = strSucursales.Replace(strTextToReplace & ",", "")
                    strSucursales = strSucursales.Replace("," & strTextToReplace, "")
                    strSucursales = strSucursales.Replace(strTextToReplace, "")

                End If

            Case "Asignar"

                Dim fltSucursalMargenSuperiorCompra As Double = CDbl(isocraft.commons.clsWeb.strGetPageParameter("txtSucursalMargenSuperiorCompra", "0"))
                Dim fltSucursalMargenInferiorCompra As Double = CDbl(isocraft.commons.clsWeb.strGetPageParameter("txtSucursalMargenInferiorCompra", "0"))

                ' Asignamos los márgenes a la sucusal, si los identificadores son válidos
                If Len(strSucursales) > 0 Then

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

                                ' Obtenemos la compañía y la sucursal
                                Dim intCompaniaId As Integer = CInt(astrCompaniaSucursal.GetValue(0))
                                Dim intSucursalId As Integer = CInt(astrCompaniaSucursal.GetValue(1))

                                ' Si la compañía y la sucursal son válidos
                                If intCompaniaId > 0 AndAlso intSucursalId > 0 Then

                                    ' Buscamos los datos de la sucursal
                                    Dim astrSucursal As Array = Benavides.CC.Data.clstblSucursal.strBuscar(intCompaniaId, intSucursalId, 0, 0, "", 0, 0, 0, Now, "", "", "", "", 0, 0, strConnectionString)

                                    ' Si la sucursal existe
                                    If astrSucursal.Length = 1 Then

                                        ' Obtenemos los datos de la sucursal
                                        intCompaniaId = CInt(DirectCast(astrSucursal.GetValue(0), Array).GetValue(0))
                                        intSucursalId = CInt(DirectCast(astrSucursal.GetValue(0), Array).GetValue(1))
                                        Dim intTiendaId As Integer = CInt(DirectCast(astrSucursal.GetValue(0), Array).GetValue(2))
                                        Dim intUbicacionSucursalId As Integer = CInt(DirectCast(astrSucursal.GetValue(0), Array).GetValue(3))
                                        Dim strSucursalNombre As String = CStr(DirectCast(astrSucursal.GetValue(0), Array).GetValue(4))
                                        Dim intSucursalAfilizacion As Integer = CInt(DirectCast(astrSucursal.GetValue(0), Array).GetValue(5))
                                        Dim strCentroLogisticoId As String = CStr(DirectCast(astrSucursal.GetValue(0), Array).GetValue(10))
                                        Dim strAlmacenId As String = CStr(DirectCast(astrSucursal.GetValue(0), Array).GetValue(11))
                                        Dim strCadenaId As String = CStr(DirectCast(astrSucursal.GetValue(0), Array).GetValue(12))

                                        ' Actualizamos la información de la sucursal
                                        Call Benavides.CC.Data.clstblSucursal.intActualizar(intCompaniaId, intSucursalId, intTiendaId, intUbicacionSucursalId, strSucursalNombre, intSucursalAfilizacion, fltSucursalMargenSuperiorCompra, fltSucursalMargenInferiorCompra, Now, strUsuarioNombre, strCentroLogisticoId, strAlmacenId, strCadenaId, strConnectionString)

                                    End If

                                End If

                            End If

                        Next

                    End If

                End If

        End Select

    End Sub

End Class
