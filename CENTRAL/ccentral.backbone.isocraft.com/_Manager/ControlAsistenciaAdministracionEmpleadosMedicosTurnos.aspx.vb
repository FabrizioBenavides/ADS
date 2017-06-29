Imports Benavides.CC.Data
Imports Benavides.POSAdmin.Commons
Imports Isocraft.Security
Imports Isocraft.Web.Http
Imports System.Collections
Imports System.Text

Public Class ControlAsistenciaAdministracionEmpleadosMedicosTurnos
    Inherits PaginaBase

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Public ReadOnly Property intEmpleadoId() As Integer
        Get
            Return CInt(Request.QueryString("intEmpleadoId"))
        End Get
    End Property

    Protected Function LLenarComboEmpleados() As String
        Dim controlEmpleados As New StringBuilder
        Dim resultadoConsulta As Array = Nothing
        Dim objMedicos As New Collections.SortedList

        resultadoConsulta = clsControlDeAsistencia.clsRolMedico. _
                            strBuscarEmpleadosMedicos(CInt(strUsuarioNombre), strConnectionString)

        If resultadoConsulta IsNot Nothing AndAlso resultadoConsulta.Length > 0 Then

            For i As Integer = 0 To resultadoConsulta.Length - 1
                objMedicos = CType(resultadoConsulta.GetValue(i), Collections.SortedList)

                controlEmpleados.AppendFormat("<option value=""{0}"">{1}</option>", _
                                                  objMedicos.Item("intEmpleadoId").ToString(), _
                                                  objMedicos.Item("NombreEmpleado").ToString())
            Next
        End If

        Return controlEmpleados.ToString()
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class