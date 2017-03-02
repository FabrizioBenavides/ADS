Imports System.Web.Services
Imports System.Text
Imports System.Configuration
Imports Benavides.CC.Business

'====================================================================
' Class         : wsSorteo95Aniversario
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Web Service no. 2 de Sorteo
' Copyright     : 2012 Todos los Derechos Reservados.
' Company       : Benavides
' Consulting C. : Softtek
' Author        : Victor Ollervides [VHOV]
' Version       : 1
' Last Modified : Monday, August 20, 2012
'====================================================================

<System.Web.Services.WebService(Namespace:="http://localhost/com.isocraft.backbone.ccentral/wsSorteo95Aniversario")> _
Public Class wsSorteo95Aniversario
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
    Public Function strInsertar(ByVal strCtdFoliosEntregados As String, _
								ByVal strCompania As String, _
								ByVal strSucursal As String, _ 
								ByVal strCaja As String, _ 
								ByVal strCajero As String, _
								ByVal strTicket As String) As String
		
        Dim objReturn As String

        objReturn = Benavides.CC.Business.clsConcentrador.clsSorteo95Aniversario.strConsultar( 	strCtdFoliosEntregados, _
																								strCompania, _ 
																								strSucursal, _  
																								strCaja, _  
																								strTicket, _  
																								strCajero, _ 
																								strCadenaConexion )

        Return objReturn

    End Function

	
	
	
    Public ReadOnly Property strCadenaConexion() As String
        Get
            Return ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

	
End Class
