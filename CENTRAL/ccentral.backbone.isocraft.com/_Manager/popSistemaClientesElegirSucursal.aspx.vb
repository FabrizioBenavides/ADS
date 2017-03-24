Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports Benavides.POSAdmin.Commons
Imports com.isocraft.commons
Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports System.Collections
Imports System.Text

Public Class popSistemaClientesElegirSucursal
    Inherits PaginaBase

    Private _intmCadenaId As Integer
    Private _intmEstadoId As Integer
    Private _intmCiudadId As Integer
    Private _strmSucursalId As String

    ''' <summary>
    ''' his call is required by the Web Form Designer.
    ''' </summary>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    ''' <summary>
    ''' NOTE: The following placeholder declaration is required by the Web Form Designer.
    ''' Do not delete or move it.
    ''' </summary>
    ''' <remarks></remarks>
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        'Inicializa Propiedades
        intCadenaId = GetPageParameter("cboCadena", 0)
        intEstadoId = GetPageParameter("cboEstado", 0)
        intCiudadId = GetPageParameter("cboCiudad", 0)
        strSucursalId = GetPageParameter("cboSucursal", "")
    End Sub

    Public ReadOnly Property strClienteABFId() As String
        Get
            Return GetPageParameter("strClienteABFId", "")
        End Get
    End Property

    Public ReadOnly Property strClienteABFNombre() As String
        Get
            Return GetPageParameter("strClienteABFNombre", "")
        End Get
    End Property

    '====================================================================
    ' Name       : strLlenarEstadoComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboEstado"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarEstadoComboBox() As String
        Return clsWeb. _
               strCreateJavascriptComboBoxOptions("cboEstado", _
                                                   intEstadoId,
                                                   clsConcentrador.clsSucursal.strBuscarAgrupacionEdo(0, 0, 0, strConnectionString), 0, 1, 2)
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
        If intEstadoId > 0 Then
            Return clsWeb. _
                   strCreateJavascriptComboBoxOptions("cboCiudad",
                                                      intCiudadId, _
                                                      clsConcentrador.clsSucursal.strBuscarAgrupacionEdo(intEstadoId, 0, 0, strConnectionString), 0, 1, 2)
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
        If intEstadoId > 0 AndAlso intCiudadId > 0 Then
            Return clsWeb. _
                   strCreateJavascriptComboBoxOptions("cboSucursal", strSucursalId,
                                                       clsConcentrador.clsSucursal.strBuscarAgrupacionEdo(intEstadoId, intCiudadId, intCadenaId, strConnectionString),
                                                       New Integer(1) {0, 1}, 2, 2)
        End If
    End Function

    '====================================================================
    ' Name       : intEstadoId 
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intEstadoId() As Integer
        Get
            Return _intmEstadoId
        End Get
        Set(ByVal intValue As Integer)
            _intmEstadoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intCiudadId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intCiudadId() As Integer
        Get
            Return _intmCiudadId
        End Get
        Set(ByVal intValue As Integer)
            _intmCiudadId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intCadenaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intCadenaId() As Integer
        Get
            Return _intmCadenaId
        End Get
        Set(ByVal intValue As Integer)
            _intmCadenaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strSucursalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strSucursalId() As String
        Get
            Return _strmSucursalId
        End Get
        Set(ByVal intValue As String)
            _strmSucursalId = intValue
        End Set
    End Property

    Public ReadOnly Property habilitarCboCiudad() As String
        Get
            Return GetPageParameter("habilitarCboCiudad", "")
        End Get
    End Property

    Public ReadOnly Property habilitarCboSucursal() As String
        Get
            Return GetPageParameter("habilitarCboSucursal", "")
        End Get
    End Property

    Public ReadOnly Property strCmd2() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd2", "")
        End Get
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Select Case strCmd2

            Case "Agregar"
                Call AgregarTblOtrasIdentificacionesSucursal()

        End Select
    End Sub

    Private Sub AgregarTblOtrasIdentificacionesSucursal()
        Dim intResultado As Integer = 0
        Dim intCompaniaId As Integer = 0
        Dim intSucursalId As Integer = 0

        AsignarCompaniaSucursal(intCompaniaId, intSucursalId)

        intResultado = clsClientesABF. _
                    clsOtrasIdentificacionesSucursal. _
                    intGuardarTblOtrasIdentificacionesSucursal(CStr(_intmCadenaId), _
                                                               _intmEstadoId, _
                                                               _intmCiudadId, _
                                                               intCompaniaId, _
                                                               intSucursalId, _
                                                               strClienteABFId, _
                                                               strUsuarioNombre, _
                                                               strConnectionString)

        If intResultado > 0 Then
            strJavascriptWindowOnLoadCommands = "alert(""Sucursales asignadas correctamente."");"
        ElseIf intResultado < 0 Then
            strJavascriptWindowOnLoadCommands = "alert(""Error al asignar sucursales."");"
        End If
    End Sub

    Private Sub AsignarCompaniaSucursal(ByRef intCompaniaId As Integer, ByRef intSucursalId As Integer)
        Dim intCompaniaIdIntSucursalId As String()

        If Not _strmSucursalId Is String.Empty And Not _strmSucursalId = "0" Then
            intCompaniaIdIntSucursalId = _strmSucursalId.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

            intCompaniaId = CInt(intCompaniaIdIntSucursalId(0))
            intSucursalId = CInt(intCompaniaIdIntSucursalId(1))
        End If

    End Sub

End Class