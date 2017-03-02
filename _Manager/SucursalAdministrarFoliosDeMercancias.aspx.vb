'====================================================================
' Class         : clsSucursalAdministrarFoliosDeMercancias
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Administrar folios de mercancías
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Joaquín Hernández García
' Version       : 1.0
' Last Modified : Tuesday, June 15, 2004
'====================================================================
Public Class clsSucursalAdministrarFoliosDeMercancias
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
    Private strmDireccionId As String
    Private strmCompaniaSucursalId As String
    Private strmZonaId As String
    Private intmFolioValorActual As Integer
    Private intmFolioValorMaximo As Integer
    Private Enum enmFolios
        Ninguno = 0
        FolioCompraDirecta = 1
        FolioDevolucion = 2
        FolioFacturaElectronica = 3
        FolioFacturaManual = 4
        FolioInventarioAgotado = 5
        FolioInventarioNegado = 6
        FolioInventarioSugerido = 7
        FolioMerma = 8
        FolioReclamacion = 9
        FolioRemision = 10
        FolioTransferenciaCancelada = 11
        FolioTransferenciaEnviada = 12
        FolioTransferenciaInterna = 13
        FolioTransferenciaRecibida = 14
    End Enum

    '====================================================================
    ' Name       : intDireccionId
    ' Description: Identificador de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intDireccionId() As Integer
        Get
            If Len(strmDireccionId) = 0 Then
                strmDireccionId = isocraft.commons.clsWeb.strGetPageParameter("cboDireccion", "0")
            End If
            Return CInt(strmDireccionId)
        End Get
    End Property

    '====================================================================
    ' Name       : intZonaId
    ' Description: Identificador de la Sucursal
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intZonaId() As Integer
        Get
            If Len(strmZonaId) = 0 Then
                strmZonaId = isocraft.commons.clsWeb.strGetPageParameter("cboZona", "0")
            End If
            Return CInt(strmZonaId)
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
            Return strmCompaniaSucursalId
        End Get
    End Property

    '====================================================================
    ' Name       : intFolioId
    ' Description: Identificador del folio
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intFolioId() As Integer
        Get
            Return CInt(isocraft.commons.clsWeb.strGetPageParameter("cboFolio", "0"))
        End Get
    End Property

    '====================================================================
    ' Name       : intFolioValorActual
    ' Description: Valor actual del folio
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intFolioValorActual() As Integer
        Get
            Return intmFolioValorActual
        End Get
        Set(ByVal intValue As Integer)
            intmFolioValorActual = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intFolioValorMaximo
    ' Description: Valor máximo del folio
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intFolioValorMaximo() As Integer
        Get
            Return intmFolioValorMaximo
        End Get
        Set(ByVal intValue As Integer)
            intmFolioValorMaximo = intValue
        End Set
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
    ' Description: Nombre de esta página
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
    ' Name       : astrObtenerFolio
    ' Description: Regresa un arreglo de cadenas de caracteres con los
    '              atributos del folio
    ' Parameters :
    '              ByVal intFolioId As Integer
    '                - Identificador del folio
    '              ByVal intCompaniaId As Integer
    '                - Identificador de la Compañía
    '              ByVal intSucursalId As Integer
    '                - Identificador de la Sucursal
    ' Throws     : None
    ' Output     : Array
    '====================================================================
    Private Function astrObtenerFolio(ByVal intFolioId As Integer, ByVal intCompaniaId As Integer, ByVal intSucursalId As Integer) As Array

        ' Identificamos el tipo de folio
        Dim astrResultSet As Array = Nothing
        Dim astrReturn As Array = Nothing

        ' Buscamos el folio
        Select Case intFolioId
            Case enmFolios.FolioCompraDirecta
                astrResultSet = Benavides.CC.Data.clstblFolioCompraDirecta.strBuscar(intCompaniaId, intSucursalId, 0, 0, Now, "", 0, 0, strConnectionString)
            Case enmFolios.FolioDevolucion
                astrResultSet = Benavides.CC.Data.clstblFolioDevolucion.strBuscar(intCompaniaId, intSucursalId, 0, 0, Now, "", 0, 0, strConnectionString)
            Case enmFolios.FolioFacturaElectronica
                astrResultSet = Benavides.CC.Data.clstblFolioFacturaElectronica.strBuscar(intCompaniaId, intSucursalId, 0, 0, Now, "", 0, 0, strConnectionString)
            Case enmFolios.FolioInventarioAgotado
                astrResultSet = Benavides.CC.Data.clstblFolioInventarioAgotado.strBuscar(intCompaniaId, intSucursalId, 0, 0, Now, "", 0, 0, strConnectionString)
            Case enmFolios.FolioInventarioNegado
                astrResultSet = Benavides.CC.Data.clstblFolioInventarioNegado.strBuscar(intCompaniaId, intSucursalId, 0, 0, Now, "", 0, 0, strConnectionString)
            Case enmFolios.FolioInventarioSugerido
                astrResultSet = Benavides.CC.Data.clstblFolioInventarioSugerido.strBuscar(intCompaniaId, intSucursalId, 0, 0, Now, "", 0, 0, strConnectionString)
            Case enmFolios.FolioFacturaManual
                astrResultSet = Benavides.CC.Data.clstblFolioFacturaManual.strBuscar(intCompaniaId, intSucursalId, 0, 0, Now, "", 0, 0, strConnectionString)
            Case enmFolios.FolioMerma
                astrResultSet = Benavides.CC.Data.clstblFolioMerma.strBuscar(intCompaniaId, intSucursalId, 0, 0, Now, "", 0, 0, strConnectionString)
            Case enmFolios.FolioReclamacion
                astrResultSet = Benavides.CC.Data.clstblFolioReclamacion.strBuscar(intCompaniaId, intSucursalId, 0, 0, Now, "", 0, 0, strConnectionString)
            Case enmFolios.FolioRemision
                astrResultSet = Benavides.CC.Data.clstblFolioRemision.strBuscar(intCompaniaId, intSucursalId, 0, 0, Now, "", 0, 0, strConnectionString)
            Case enmFolios.FolioTransferenciaCancelada
                astrResultSet = Benavides.CC.Data.clstblFolioTransferenciaCancelada.strBuscar(intCompaniaId, intSucursalId, 0, 0, Now, "", 0, 0, strConnectionString)
            Case enmFolios.FolioTransferenciaEnviada
                astrResultSet = Benavides.CC.Data.clstblFolioTransferenciaEnviada.strBuscar(intCompaniaId, intSucursalId, 0, 0, Now, "", 0, 0, strConnectionString)
            Case enmFolios.FolioTransferenciaInterna
                astrResultSet = Benavides.CC.Data.clstblFolioTransferenciaInterna.strBuscar(intCompaniaId, intSucursalId, 0, 0, Now, "", 0, 0, strConnectionString)
            Case enmFolios.FolioTransferenciaRecibida
                astrResultSet = Benavides.CC.Data.clstblFolioTransferenciaRecibida.strBuscar(intCompaniaId, intSucursalId, 0, 0, Now, "", 0, 0, strConnectionString)
        End Select

        ' Obtenemos el folio, si el folio existe
        If IsNothing(astrResultSet) = False AndAlso astrResultSet.Length > 0 Then
            astrReturn = DirectCast(astrResultSet.GetValue(0), Array)
        End If

        ' Regresamos el resultado
        Return astrReturn

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Recuperamos los valores actual y máximo del folio
        intFolioValorActual = CInt(isocraft.commons.clsWeb.strGetPageParameter("txtFolioValorActual", "0"))
        intFolioValorMaximo = CInt(isocraft.commons.clsWeb.strGetPageParameter("txtFolioValorMaximo", "0"))

        ' Ejecutamos el comando indicado
        Select Case isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

            Case "Salvar"

                ' Identificamos el tipo de folio
                Dim astrResultSet As Array = astrObtenerFolio(intFolioId, intCompaniaId, intSucursalId)

                ' Si el folio existe
                If IsNothing(astrResultSet) = False AndAlso astrResultSet.Length > 0 Then

                    ' Actualizamos el folio
                    Select Case intFolioId
                        Case enmFolios.FolioCompraDirecta
                            Call Benavides.CC.Data.clstblFolioCompraDirecta.intActualizar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioDevolucion
                            Call Benavides.CC.Data.clstblFolioDevolucion.intActualizar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioFacturaElectronica
                            Call Benavides.CC.Data.clstblFolioFacturaElectronica.intActualizar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioInventarioAgotado
                            Call Benavides.CC.Data.clstblFolioInventarioAgotado.intActualizar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioInventarioNegado
                            Call Benavides.CC.Data.clstblFolioInventarioNegado.intActualizar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioInventarioSugerido
                            Call Benavides.CC.Data.clstblFolioInventarioSugerido.intActualizar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioFacturaManual
                            Call Benavides.CC.Data.clstblFolioFacturaManual.intActualizar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioMerma
                            Call Benavides.CC.Data.clstblFolioMerma.intActualizar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioReclamacion
                            Call Benavides.CC.Data.clstblFolioReclamacion.intActualizar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioRemision
                            Call Benavides.CC.Data.clstblFolioRemision.intActualizar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioTransferenciaCancelada
                            Call Benavides.CC.Data.clstblFolioTransferenciaCancelada.intActualizar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioTransferenciaEnviada
                            Call Benavides.CC.Data.clstblFolioTransferenciaEnviada.intActualizar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioTransferenciaInterna
                            Call Benavides.CC.Data.clstblFolioTransferenciaInterna.intActualizar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioTransferenciaRecibida
                            Call Benavides.CC.Data.clstblFolioTransferenciaRecibida.intActualizar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                    End Select

                Else

                    ' El folio no existe, agregamos el nuevo folio
                    Select Case intFolioId
                        Case enmFolios.FolioCompraDirecta
                            Call Benavides.CC.Data.clstblFolioCompraDirecta.intAgregar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioDevolucion
                            Call Benavides.CC.Data.clstblFolioDevolucion.intAgregar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioFacturaElectronica
                            Call Benavides.CC.Data.clstblFolioFacturaElectronica.intAgregar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioInventarioAgotado
                            Call Benavides.CC.Data.clstblFolioInventarioAgotado.intAgregar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioInventarioNegado
                            Call Benavides.CC.Data.clstblFolioInventarioNegado.intAgregar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioInventarioSugerido
                            Call Benavides.CC.Data.clstblFolioInventarioSugerido.intAgregar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioFacturaManual
                            Call Benavides.CC.Data.clstblFolioFacturaManual.intAgregar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioMerma
                            Call Benavides.CC.Data.clstblFolioMerma.intAgregar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioReclamacion
                            Call Benavides.CC.Data.clstblFolioReclamacion.intAgregar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioRemision
                            Call Benavides.CC.Data.clstblFolioRemision.intAgregar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioTransferenciaCancelada
                            Call Benavides.CC.Data.clstblFolioTransferenciaCancelada.intAgregar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioTransferenciaEnviada
                            Call Benavides.CC.Data.clstblFolioTransferenciaEnviada.intAgregar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioTransferenciaInterna
                            Call Benavides.CC.Data.clstblFolioTransferenciaInterna.intAgregar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                        Case enmFolios.FolioTransferenciaRecibida
                            Call Benavides.CC.Data.clstblFolioTransferenciaRecibida.intAgregar(intCompaniaId, intSucursalId, intFolioValorActual, intFolioValorMaximo, Now, strUsuarioNombre, strConnectionString)
                    End Select

                End If

            Case "Buscar"

                ' Obtenemos el folio
                Dim astrResultSet As Array = astrObtenerFolio(intFolioId, intCompaniaId, intSucursalId)

                ' Si el folio existe
                If IsNothing(astrResultSet) = False AndAlso astrResultSet.Length > 0 Then

                    ' Obtenemos el valor actual
                    Dim strFolioValor As String = CStr(astrResultSet.GetValue(2))
                    If IsNumeric(strFolioValor) = True Then
                        intFolioValorActual = CInt(strFolioValor)
                    End If

                    ' Obtenemos el valor máximo
                    strFolioValor = CStr(astrResultSet.GetValue(3))
                    If IsNumeric(strFolioValor) = True Then
                        intFolioValorMaximo = CInt(strFolioValor)
                    End If

                End If

        End Select

    End Sub

End Class
