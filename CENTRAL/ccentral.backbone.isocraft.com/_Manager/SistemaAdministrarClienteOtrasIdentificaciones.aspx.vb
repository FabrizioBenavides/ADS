Imports System.Text


Public Class SistemaAdministrarClienteOtrasIdentificaciones
    Inherits PaginaBase

    Public ReadOnly Property strCmd2() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd2", "")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Benavides.CC.Business.clsConcentrador.clsControlAcceso. _
        '        blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
        '    Call Response.Redirect("../Default.aspx")
        'End If

    End Sub

    Protected Function strConsultarClientes() As String
        Dim strResultadoTablaClientes As New StringBuilder
        Dim objClientes As Array


        If IsArray(objClientes) AndAlso objClientes.Length > 0 Then

        End If

        Return strResultadoTablaClientes.ToString()
    End Function

End Class