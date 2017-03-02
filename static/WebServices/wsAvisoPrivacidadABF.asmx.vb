' ============================================================
' Creado      : 04 Febrero 2014  
' Cosultoria  : Softtek Mty 
' Descripcion : Ws que verifica y actualiza la firma del
'               aviso de privacidad para ABF
' Crador      : Carlos Javier Barberena González
' Modificado  : Sarahí Sandoval SSCA
' ============================================================
Imports System.Web.Services
Imports System.Text
Imports System.Configuration
Imports Benavides.CC.Business
Imports System.Array
Imports System.Collections

<System.Web.Services.WebService(Namespace:="http://localhost/com.isocraft.backbone.ccentral/wsAvisoPrivacidadABF")> _
Public Class wsAvisoPrivacidadABF
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

    Public Structure EstructuraAvisoPrivacidad

        Dim strTarjetaCliente As String

        Dim blnAvisoPrivacidadABFFirmado As String

        Dim strTelCelular As String

        Dim strTelCasa As String

        Dim strEmail As String

        Dim strResultado As String

        Dim strError As String

    End Structure


    <WebMethod()> _
    Public Function strConsultaFirmaAvisoPrivacidadABF(ByVal strTarjetaCliente As String) As EstructuraAvisoPrivacidad
        ' stkAvisoPrivacidad CJBG 04/02/2014
        ' Declaración de método que regresa el resultado de la consulta de firma de aviso de privacidad
        ' Declaración de variables que contendrá el resultado de la consulta
        Dim strResult As EstructuraAvisoPrivacidad
        Dim arrayResultado As Array
        ' Consultar a la base de datos para actualizar los datos de la firma de aviso de privacidad 
        arrayResultado = Benavides.CC.Business.clsConcentrador.clsSucursal.strXMLConsultaFirmaAvisoPrivacidadABF(strTarjetaCliente, strCadenaConexion)


        strResult.strTarjetaCliente = DirectCast(arrayResultado.GetValue(0), String)
        strResult.blnAvisoPrivacidadABFFirmado = CStr(DirectCast(arrayResultado.GetValue(1), String))
        strResult.strTelCelular = DirectCast(arrayResultado.GetValue(2), String)
        strResult.strTelCasa = DirectCast(arrayResultado.GetValue(3), String)
        strResult.strEmail = DirectCast(arrayResultado.GetValue(4), String)
        strResult.strResultado = DirectCast(arrayResultado.GetValue(5), String)
        strResult.strError = DirectCast(arrayResultado.GetValue(6), String)

        'strResult.strTarjetaCliente = CStr(arrayResultado)
        'strResult.blnAvisoPrivacidadABFFirmado = CBool(arrayResultado(1))
        'strResult.strTelCelular = CStr(arrayResultado(2))
        'strResult.strTelCasa = CStr(arrayResultado(3))
        'strResult.strEmail = CStr(arrayResultado(4))
        'strResult.strResultado = CStr(arrayResultado(5))
        'strResult.strError = CStr(arrayResultado(6))

        ' Regresar el resultado al nombre de la función
        strConsultaFirmaAvisoPrivacidadABF = strResult

    End Function

    
    <WebMethod()> _
    Public Function strActualizaFirmaAvisoPrivacidadABF(ByVal strTarjetaCliente As String, _
                                                        ByVal blnAvisoPrivacidadABFFirmado As Byte, _
                                                        ByVal strTelCelular As String, _
                                                        ByVal strTelCasa As String, _
                                                        ByVal strEmail As String, _
                                                        ByVal strSucSAPFirmado As String, _
                                                        ByVal intSucursalId As Integer, _
                                                        ByVal intCajaId As Integer, _
                                                        ByVal intEmpleadoId As Integer) As String
        ' stkAvisoPrivacidad CJBG 04/02/2014
        ' Funcion que recibe los parametros que se van a insertar en la base de datos la información de firma de aviso de privacidad
        ' Declaración de variables que contendrá el resultado de la consulta
        Dim strResult As String

        ' Consultar a la base de datos para actualizar los datos de la firma de aviso de privacidad 
        strResult = Benavides.CC.Business.clsConcentrador.clsSucursal.strXMLActualizaFirmaAvisoPrivacidadABF(strTarjetaCliente, _
                                                                                                             blnAvisoPrivacidadABFFirmado, _
                                                                                                             strTelCelular, _
                                                                                                             strTelCasa, _
                                                                                                             strEmail, _
                                                                                                             strSucSAPFirmado, _
                                                                                                             intSucursalId, _
                                                                                                             intCajaId, _
                                                                                                             intEmpleadoId, _
                                                                                                             strCadenaConexion)

        ' Regresar el resultado al nombre de la función
        strActualizaFirmaAvisoPrivacidadABF = strResult

    End Function

    ' Declaración de la variable para obtener la cadena de conexión hacia la base de datos 
    Public ReadOnly Property strCadenaConexion() As String
        Get
            'Return ConfigurationSettings.AppSettings("strCadenaConexionAdministradorPuntoVenta")
            Return ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")

        End Get
    End Property


End Class
