Imports System.Web.Services
Imports System.Text
Imports System.Configuration
Imports Benavides.CC.Business

<System.Web.Services.WebService(Namespace:="http://localhost/com.isocraft.backbone.ccentral/wsClienteFiscal")> _
Public Class wsClienteFiscal
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

    Private Enum ResultadoWSEdxPacRFC
        Existe = 1
        NoExiste = 0
        ErrorPac = -1
    End Enum

    <WebMethod()> _
    Public Function strBuscarClienteFiscal(ByVal strClienteFiscalRFC As String) As Benavides.CC.Business.clsDAOClienteFiscal()

        Dim objReturn() As Benavides.CC.Business.clsDAOClienteFiscal

        objReturn = Benavides.CC.Business.clsConcentrador.clsClienteFiscal.strBuscarClienteFiscal(strClienteFiscalRFC, strCadenaConexion)

        Return objReturn

    End Function

    <WebMethod()> _
    Public Function intBuscarEdxPacRFC(ByVal strClienteFiscalRFC As String) As Integer
        Dim intResultado As Integer

        intResultado = Benavides.CC.Business.clsConcentrador.clsClienteFiscal.intBuscarEdxPacRFC(strClienteFiscalRFC)

        Return intResultado
    End Function

    Public ReadOnly Property strCadenaConexion() As String
        Get
            Return ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

End Class
