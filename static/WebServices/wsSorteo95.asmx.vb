Imports System.Web.Services
Imports System.Text
Imports System.Configuration
Imports Benavides.CC.Business
<System.Web.Services.WebService(Namespace:="http://localhost/com.isocraft.backbone.ccentral/wsSorteo95")> _
Public Class wsSorteo95
    Inherits System.Web.Services.WebService

#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

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
    Public Function strConsultarSorteo95(ByVal strFolios As String, ByVal strCompania As String, ByVal strSucursal As String, ByVal strCaja As String, ByVal strCajero As String, ByVal strTicket As String) As String
        'PATG 20120720
        Dim objReturn As String

        objReturn = Benavides.CC.Business.clsConcentrador.clsSorteo95.strConsultarSorteo95(strFolios, strCompania, strSucursal, strCaja, strTicket, strCajero, strCadenaConexion)

        Return objReturn

    End Function

    Public ReadOnly Property strCadenaConexion() As String
        Get
            Return ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

End Class
