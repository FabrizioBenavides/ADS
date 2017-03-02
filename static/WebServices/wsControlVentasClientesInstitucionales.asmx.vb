' ============================================================
' Creado      : 17/Septiembre/2015
' Cosultoria  : Softtek Mty 
' Descripcion : WebService utilizado para el proyecto Control de Ventas
'               a Clientes Institucionales
' Creador     : Jesus Adrian Colunga Almaguer
' ===========================================================
Imports Benavides.CC.Business
Imports System.Array
Imports System.Collections
Imports System.Configuration
Imports System.Text
Imports System.Web.Services

<System.Web.Services.WebService(Namespace:="http://localhost/com.isocraft.backbone.ccentral/wsControlVentasClientesInstitucionales")> _
Public Class wsControlVentasClientesInstitucionales
    Inherits System.Web.Services.WebService

#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    ' WEB SERVICE EXAMPLE
    ' The HelloWorld() example service returns the string Hello World.
    ' To build, uncomment the following lines then save and build the project.
    ' To test this web service, ensure that the .asmx file is the start page
    ' and press F5.
    '
    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '   Return "Hello World"
    'End Function

    'Estructura que se enviará como respuesta del WebMethod strValidaClienteActivo
    Public Structure EstructuraValidaClienteActivoSalida

        Dim strIdClienteABF As String

        Dim blnClienteActivo As Boolean

        Dim blnLimiteCredito As Boolean

        Dim intErrorId As Integer

        Dim strMensajeError As String

    End Structure

    'Método encargado de validar si un cliente está activo
    <WebMethod()> _
    Public Function strValidaClienteActivo(ByVal strIdClienteABF As String, _
                                           ByVal strCompaniaCteABF As String, _
                                           ByVal strSucursalCteABF As String, _
                                           ByVal intTipoOpABF As Integer) As EstructuraValidaClienteActivoSalida

        Dim salida As EstructuraValidaClienteActivoSalida
        Dim arrayResult As ArrayList

        arrayResult = Benavides.CC.Business.clsConcentrador.clsClienteABF.arrayValidaClienteActivo(strIdClienteABF, strCompaniaCteABF, strSucursalCteABF, intTipoOpABF, strCadenaConexion())

        'Asignar valores del arreglo a la estructura de salida
        salida.strIdClienteABF = CStr(arrayResult(0))
        salida.blnClienteActivo = CBool(arrayResult(1))
        salida.blnLimiteCredito = CBool(arrayResult(2))
        salida.intErrorId = CInt(arrayResult(3))
        salida.strMensajeError = CStr(arrayResult(4))

        strValidaClienteActivo = salida

    End Function

    ' stkControlVentasClientesInstitucionales CJBG 08/10/2015 - Agregando nuevo método
    'Método encargado de validar si un de Receta en linea u Offline esta activo
    <WebMethod()> _
    Public Function strValidarClienteReceteEnLineaOfflineActivo(ByVal intCompaniaId As Integer, _
                                                                ByVal intSucursalId As Integer, _
                                                                ByVal strClienteRecetaEnLineaId As String, _
                                                                ByVal intIntegradorRecetaEnLineaId As Integer, _
                                                                ByVal strClienteSAPId As String, _
                                                                ByVal strClienteABFId As String) As String

        ' Declarar variable resultado
        Dim strResult As String

        ' Obtener variable string en formato XML
        strResult = Benavides.CC.Business.clsConcentrador.clsClienteABF.strValidaClienteActivo(intCompaniaId, intSucursalId, strClienteRecetaEnLineaId, intIntegradorRecetaEnLineaId, strClienteSAPId, strClienteABFId, strCadenaConexion())

        ' Regresar resultado
        strValidarClienteReceteEnLineaOfflineActivo = strResult

    End Function

    'Método encargado de obtener el listado de clientes de otras identificaciones
    <WebMethod()> _
    Public Function strObtieneClientesOtrasIdentificaciones(ByVal strClienteABFNombre As String, _
                                                           ByVal strCompaniaCteABF As String, _
                                                           ByVal strSucursalCteABF As String) As String

        Dim strResult As String        

        strResult = Benavides.CC.Business.clsConcentrador.clsClienteABF.strObtieneClientesOtrasIdentificaciones(strClienteABFNombre, strCompaniaCteABF, strSucursalCteABF, strCadenaConexion())

        strObtieneClientesOtrasIdentificaciones = strResult

    End Function
    ' Obtiene el string de conexión a la Base de Datos
    Public ReadOnly Property strCadenaConexion() As String

        Get

            Return ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")

        End Get

    End Property

End Class
