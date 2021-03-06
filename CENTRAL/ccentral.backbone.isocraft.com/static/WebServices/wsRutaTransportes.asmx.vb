Imports System.Web.Services
Imports System.Text
Imports System.Configuration
Imports Benavides.CC.Data.clsRutaTransportes


<System.Web.Services.WebService(Namespace:="http://localhost/com.isocraft.backbone.ccentral/wsRutaTransportes")> _
Public Class wsRutaTransportes
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

    <WebMethod()> _
    Public Function strBuscarSucursalVisitaVencida(ByVal strCentroLogisticoId As String) As String


        Dim objSucursalSinConfirmacion As Array
        Dim strSucursalVisitaVencida As String

        objSucursalSinConfirmacion = clsRutaTransportesSucursalCalendario.strBuscarSucursalVisitaVencida(strCentroLogisticoId, strCadenaConexion)

        If IsArray(objSucursalSinConfirmacion) AndAlso objSucursalSinConfirmacion.Length > 0 Then

            strSucursalVisitaVencida = "SINCONFIRMAR"

        Else
            strSucursalVisitaVencida = ""

        End If

        Return strSucursalVisitaVencida

    End Function


    Public ReadOnly Property strCadenaConexion() As String
        Get
            Return ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property


End Class
