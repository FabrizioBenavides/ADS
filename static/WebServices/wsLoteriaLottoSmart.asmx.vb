' ============================================================
' Creado      : 31 octubre 2013  
' Cosultoria  : Softtek Mty 
' Descripcion : Ws Que regresa los Datos de los Boletos lotto
' Crador      : Juan Pablo Martinez Bautista 
' ===========================================================
Imports System.Web.Services
Imports System.Text
Imports System.Configuration
Imports Benavides.CC.Business

<System.Web.Services.WebService(Namespace:="http://localhost/com.isocraft.backbone.ccentral/wsLoteriaLottoSmart")> _
Public Class wsLoteriaLottoSmart
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


    ' StkmtyVentalottoSmart JPMB 30/10/2013
    ' Inicamos con la declaracion de la funcion que regresa el resultado de la consulta
    <WebMethod()> _
    Public Function strConsultarBoletoLottoSmart(ByVal intBoletoLottoSmart As Long) As String

        ' declaracion de variables que nos regresa el resulato de la consulta
        Dim strResult As String

        ' Consultamos a la base de datos para extraer los datos del numero de boleto que se desea consultar 
        strResult = Benavides.CC.Business.clsConcentrador.clsSucursal.strXMLConsultaBoletoLottoSmart(intBoletoLottoSmart, strCadenaConexion)

        ' Regresamos el resultado al nombre de la funcion
        strConsultarBoletoLottoSmart = strResult

    End Function

    ' StkmtyVentalottoSmart JPMB 01/11/2013
    ' Creamos La funcion que recibe los parametros que se van a insertar en la base de datos
    <WebMethod()> _
        Public Function strProcesarBoletoLottoSmart(ByVal intBoletoLottoSmart As Long, _
                                                    ByVal intTicketId As Long, _
                                                    ByVal intSucursalId As Integer, _
                                                    ByVal intCajaId As Integer, _
                                                    ByVal intEmpleadoId As Integer) As String

        ' declaracion de variables que nos regresa el resulato de la consulta
        Dim strResult As String

        ' Consultamos a la base de datos para extraer los datos del numero de boleto que se desea consultar 
        strResult = Benavides.CC.Business.clsConcentrador.clsSucursal.strXMLProcesarBoletoLottoSmart(intBoletoLottoSmart, _
                                                                                                    intTicketId, _
                                                                                                    intSucursalId, _
                                                                                                    intCajaId, _
                                                                                                    intEmpleadoId, _
                                                                                                    strCadenaConexion)

        ' Regresamos el resultado al nombre de la funcion
        strProcesarBoletoLottoSmart = strResult

    End Function

    ' declaracion de la variable para obtener la cadena de conexion a la base de datos 
    Public ReadOnly Property strCadenaConexion() As String
        Get
            ' obtenemos la conexion a la base de datos 
            Return ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

End Class
