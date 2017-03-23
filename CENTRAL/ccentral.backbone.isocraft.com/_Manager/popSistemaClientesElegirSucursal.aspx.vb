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

        'Inicializa Propiedades
        intCadenaId = GetPageParameter("cboCadena", 0)
        intEstadoId = GetPageParameter("cboEstado", 0)
        intCiudadId = GetPageParameter("cboCiudad", 0)
        strSucursalId = GetPageParameter("cboSucursal", "")
    End Sub

#End Region

#Region " Class Private Attributes"

    Const strComitasDobles As String = """"

    Private strmJavascriptWindowOnLoadCommands As String

    Private intmCadenaId As Integer
    Private intmEstadoId As Integer
    Private intmCiudadId As Integer
    Private strmSucursalId As String

    Private strmcboCadena As String
    Private strmcboEstado As String
    Private strmcboCiudad As String
    Private strmCboSucursal As String

#End Region

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
               Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacionEdo(0, 0, 0, strConnectionString), 0, 1, 2)
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
            Return isocraft.commons.clsWeb. _
                   strCreateJavascriptComboBoxOptions("cboCiudad", intCiudadId, _
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
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSucursal", strSucursalId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacionEdo(intEstadoId, intCiudadId, intCadenaId, strConnectionString), New Integer(1) {0, 1}, 2, 2)
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
            Return intmEstadoId
        End Get
        Set(ByVal intValue As Integer)
            intmEstadoId = intValue
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
            Return intmCiudadId
        End Get
        Set(ByVal intValue As Integer)
            intmCiudadId = intValue
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
            Return intmCadenaId
        End Get
        Set(ByVal intValue As Integer)
            intmCadenaId = intValue
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
            Return strmSucursalId
        End Get
        Set(ByVal intValue As String)
            strmSucursalId = intValue
        End Set
    End Property

    Public ReadOnly Property strCadenaId() As String
        Get
            Return GetPageParameter("strCadenaId", "")
        End Get
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
        Dim resultado As Integer = 0

        'resultado = clsClientesABF.clsOtrasIdentificacionesSucursal.intGuardarTblOtrasIdentificacionesSucursal()

        If resultado = 1 Then
            strJavascriptWindowOnLoadCommands = "alert(""."");"
        End If

    End Sub

End Class