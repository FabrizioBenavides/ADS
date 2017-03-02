'====================================================================
' Class         : clsSucursalAdministrarDireccionFiscal
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Administrar folios de mercancías
' Copyright     : 2003-2006 All rights reserved.
' Company       : Neitek Solutions
' Author        : Enrique Longoria
' Version       : 1.0
' Last Modified : Monday, May 15, 2006
'====================================================================
Public Class clsSucursalAdministrarDireccionFiscal
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
    Private strmEstadoId As String
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
    ' Name       : intEstadoId
    ' Description: Identificador del Estado
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intEstadoId() As Integer
        Get
            If Len(strmEstadoId) = 0 Then
                strmEstadoId = isocraft.commons.clsWeb.strGetPageParameter("cboEstado", "0")
            End If
            Return CInt(strmEstadoId)
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
            Return "DeleteComboBoxElements(document.forms[0].elements[" + Chr(34) + "cboZona" + Chr(34) + "], 1);DeleteComboBoxElements(document.forms[0].elements[" + Chr(34) + "cboSucursal" + Chr(34) + "], 1);" + isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZona", intZonaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, 0, strConnectionString), 0, 1, 1).Replace(vbNewLine, "")
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
            Return "DeleteComboBoxElements(document.forms[0].elements[" + Chr(34) + "cboSucursal" + Chr(34) + "], 1);" + isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSucursal", strCompaniaSucursalId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, intZonaId, strConnectionString), New Integer(1) {0, 1}, 2, 1).Replace(vbNewLine, "")
        End If
    End Function
    '====================================================================
    ' Name       : strLlenarEstadosComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboEstado"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarEstadosComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboEstado", intEstadoId, Benavides.CC.Data.clstblEstado.strBuscar(0, 1, "", Now, "", 0, 0, strConnectionString), 0, 2, 1)
    End Function

    '====================================================================
    ' Name       : strDesplegarDireccionSucursal
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena la direccion Sucursal
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strDesplegarDireccionSucursal() As String
        Try
            Dim htmlResult As New Text.StringBuilder
            Dim companiaSucursal As String() = Request("cboSucursal").Split(Chr(124))
            If companiaSucursal.Length > 0 Then
                Dim vCompania As String = companiaSucursal(0)
                Dim vSucursal As String = companiaSucursal(1)
                Dim arrayResult As Array = Benavides.CC.Data.clstblSucursalDireccion.strBuscar(CInt(vCompania), CInt(vSucursal), "", "", "", "", "", "", 0, 0, 0, "", "", "", Now, "", 0, 0, strConnectionString)
                If Not IsNothing(arrayResult) AndAlso arrayResult.Length > 0 Then
                    arrayResult = DirectCast(arrayResult.GetValue(0), Array)
                    'calle
                    htmlResult.Append("document.getElementById(""txtSucursalDireccionCalle"").value=")
                    htmlResult.Append(Chr(34))
                    htmlResult.Append(arrayResult.GetValue(2))
                    htmlResult.Append(Chr(34))
                    htmlResult.Append(";")
                    'no ext
                    htmlResult.Append("document.getElementById(""txtSucursalDireccionNoExterior"").value=")
                    htmlResult.Append(Chr(34))
                    htmlResult.Append(arrayResult.GetValue(3))
                    htmlResult.Append(Chr(34))
                    htmlResult.Append(";")
                    'no int
                    htmlResult.Append("document.getElementById(""txtSucursalDireccionNoInterior"").value=")
                    htmlResult.Append(Chr(34))
                    htmlResult.Append(arrayResult.GetValue(4))
                    htmlResult.Append(Chr(34))
                    htmlResult.Append(";")
                    'colonia
                    htmlResult.Append("document.getElementById(""txtSucursalDireccionColonia"").value=")
                    htmlResult.Append(Chr(34))
                    htmlResult.Append(arrayResult.GetValue(5))
                    htmlResult.Append(Chr(34))
                    htmlResult.Append(";")
                    'estado
                    htmlResult.Append("document.getElementById(""cboEstado"").value=")
                    htmlResult.Append(Chr(34))
                    htmlResult.Append(arrayResult.GetValue(9))
                    htmlResult.Append(Chr(34))
                    htmlResult.Append(";")
                    'mpio
                    htmlResult.Append(strLlenarCiudadesComboBox(CInt(arrayResult.GetValue(9))))
                    htmlResult.Append("document.getElementById(""cboCiudad"").value=")
                    htmlResult.Append(Chr(34))
                    htmlResult.Append(arrayResult.GetValue(8))
                    htmlResult.Append(Chr(34))
                    htmlResult.Append(";")
                    'colonia
                    htmlResult.Append("document.getElementById(""txtSucursalDireccionCodigoPostal"").value=")
                    htmlResult.Append(Chr(34))
                    htmlResult.Append(arrayResult.GetValue(11))
                    htmlResult.Append(Chr(34))
                    htmlResult.Append(";")

                End If
                Return htmlResult.ToString
            End If
        Catch ex As Exception
            Throw New Exception("EException: " + ex.Message)
        End Try
    End Function


    '====================================================================
    ' Name       : strUpdateDireccionSucursal
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena la direccion Sucursal
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strUpdateDireccionSucursal() As String
        Dim htmlResult As New Text.StringBuilder
        Dim companiaSucursal As String() = Request("cboSucursal").Split(Chr(124))
        If companiaSucursal.Length > 0 Then
            Dim vCompania As String = companiaSucursal(0)
            Dim vSucursal As String = companiaSucursal(1)
            Dim arrayResult As Array = Benavides.CC.Data.clstblSucursalDireccion.strBuscar(CInt(vCompania), CInt(vSucursal), "", "", "", "", "", "", 0, 0, 0, "", "", "", Now, "", 0, 0, strConnectionString)
            If Not IsNothing(arrayResult) AndAlso arrayResult.Length > 0 Then
                Benavides.CC.Data.clstblSucursalDireccion.intActualizar(CInt(vCompania), CInt(vSucursal), Request("txtSucursalDireccionCalle"), Request("txtSucursalDireccionNoExterior"), Request("txtSucursalDireccionNoInterior"), Request("txtSucursalDireccionColonia"), "", "", CInt(Request("cboCiudad")), CInt(Request("cboEstado")), 1, Request("txtSucursalDireccionCodigoPostal"), "", "", Now, Me.strUsuarioNombre, strConnectionString)
                Return "alert(" + Chr(34) + "Registro Actualizado Exitosamente." + Chr(34) + ");"
            Else
                Benavides.CC.Data.clstblSucursalDireccion.intAgregar(CInt(vCompania), CInt(vSucursal), Request("txtSucursalDireccionCalle"), Request("txtSucursalDireccionNoExterior"), Request("txtSucursalDireccionNoInterior"), Request("txtSucursalDireccionColonia"), "", "", CInt(Request("cboCiudad")), CInt(Request("cboEstado")), 1, Request("txtSucursalDireccionCodigoPostal"), "", "", Now, Me.strUsuarioNombre, strConnectionString)
                Return "alert(" + Chr(34) + "Registro Insertado Exitosamente." + Chr(34) + ");"
            End If
        End If
        'Return "alert(" + Chr(34) + "No se encontro la Compania-Sucursal." + Chr(34) + ");"
    End Function

    '====================================================================
    ' Name       : strLlenarCiudadesComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboCiudad"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarCiudadesComboBox() As String
        If intEstadoId <> 0 Then
            Return "DeleteComboBoxElements(document.forms[0].elements[" + Chr(34) + "cboCiudad" + Chr(34) + "], 1);" + isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboCiudad", intEstadoId, Benavides.CC.Data.clstblCiudad.strBuscar(intEstadoId, 0, "", Now, "", 0, 0, strConnectionString), 1, 2, 1).Replace(vbNewLine, "")
        End If
    End Function

    '====================================================================
    ' Name       : strLlenarCiudadesComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboCiudad"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarCiudadesComboBox(ByVal vIntEstadoId As Integer) As String
        Return "DeleteComboBoxElements(document.forms[0].elements[" + Chr(34) + "cboCiudad" + Chr(34) + "], 1);" + isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboCiudad", vIntEstadoId, Benavides.CC.Data.clstblCiudad.strBuscar(vIntEstadoId, 0, "", Now, "", 0, 0, strConnectionString), 1, 2, 1).Replace(vbNewLine, "")
    End Function

    '====================================================================
    ' Name       : strActions
    ' Description: funcion  que realiza la accion para cada comando 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String 
    '====================================================================
    Protected Overridable Function strActions(ByVal strCmd As String, Optional ByVal strParams As String = "") As String
        Dim strHtmlResult As String

        'Ejecutamos el comando indicado
        Select Case strCmd
            Case "getComboZona"
                strHtmlResult = strLlenarZonaComboBox()
            Case "getComboSucursal"
                strHtmlResult = strLlenarSucursalComboBox()
            Case "getComboCiudad"
                strHtmlResult = strLlenarCiudadesComboBox()
            Case "getDireccionSucursal"
                strHtmlResult = strDesplegarDireccionSucursal()
            Case "updateDireccionSucursal"
                strHtmlResult = strUpdateDireccionSucursal()
        End Select

        Return strHtmlResult
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If
    End Sub


End Class
