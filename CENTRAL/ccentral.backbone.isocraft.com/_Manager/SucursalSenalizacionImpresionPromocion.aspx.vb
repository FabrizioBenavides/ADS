Imports System.Text

Public Class SucursalSenalizacionImpresionPromocion
    Inherits System.Web.UI.Page
    Protected WithEvents objContenedor As System.Web.UI.HtmlControls.HtmlGenericControl

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Obtiene la cadena de conexión hacia la base de datos
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim strPromocionesId() As String = Request.QueryString("intPromocionCodigo").Split("|".ToCharArray())
        Dim strImpresion As New StringBuilder

        For i As Integer = 0 To strPromocionesId.Length - 1
            If i > 0 Then
                strImpresion.Append(strGetImpresionPromocion(CInt(strPromocionesId(i)), True))
            Else
                strImpresion.Append(strGetImpresionPromocion(CInt(strPromocionesId(i))))
            End If
        Next

        objContenedor.InnerHtml = strImpresion.ToString()
    End Sub

    Private Function strCreate1x1Table(ByVal strImage As String, ByVal blnSaltoPagina As Boolean) As String
        Dim strTabla As New StringBuilder

        If blnSaltoPagina Then
            strTabla.Append("<table style=""page-break-before:always;"">")
        Else
            strTabla.Append("<table>")
        End If
        strTabla.Append("<tr>")
        strTabla.Append("<td>")
        strTabla.AppendFormat("<img src=""{0}"" style=""border:none; width:8.4in; height:10.9in;"">", strImage)
        strTabla.Append("</td>")
        strTabla.Append("</tr>")
        strTabla.Append("</table>")

        Return strTabla.ToString()
    End Function

    Private Function strCreate1x3Table(ByVal strImage As String, ByVal blnSaltoPagina As Boolean) As String
        Dim strTabla As New StringBuilder

        If blnSaltoPagina Then
            strTabla.Append("<table style=""page-break-before:always;"">")
        Else
            strTabla.Append("<table>")
        End If
        strTabla.Append("<tr>")
        strTabla.Append("<td>")
        strTabla.AppendFormat("<img src=""{0}"" style=""border:none; width:8.5in; height:3.6in;"">", strImage)
        strTabla.Append("</td>")
        strTabla.Append("</tr>")
        strTabla.Append("<tr>")
        strTabla.Append("<td>")
        strTabla.AppendFormat("<img src=""{0}"" style=""border:none; width:8.5in; height:3.6in;"">", strImage)
        strTabla.Append("</td>")
        strTabla.Append("</tr>")
        strTabla.Append("<tr>")
        strTabla.Append("<td>")
        strTabla.AppendFormat("<img src=""{0}"" style=""border:none; width:8.5in; height:3.6in;"">", strImage)
        strTabla.Append("</td>")
        strTabla.Append("</tr>")
        strTabla.Append("</table>")

        Return strTabla.ToString()
    End Function

    Private Function strCreate3x4Table(ByVal strImage As String, ByVal blnSaltoPagina As Boolean) As String
        Dim strTabla As New StringBuilder

        If blnSaltoPagina Then
            strTabla.Append("<table style=""page-break-before:always;"">")
        Else
            strTabla.Append("<table>")
        End If
        strTabla.Append("<tr>")
        strTabla.Append("<td>")
        strTabla.AppendFormat("<img src=""{0}"" style=""border:none; width:2.8in; height:2.70in;"">", strImage)
        strTabla.Append("</td>")
        strTabla.Append("<td>")
        strTabla.AppendFormat("<img src=""{0}"" style=""border:none; width:2.8in; height:2.70in;"">", strImage)
        strTabla.Append("</td>")
        strTabla.Append("<td>")
        strTabla.AppendFormat("<img src=""{0}"" style=""border:none; width:2.8in; height:2.70in;"">", strImage)
        strTabla.Append("</td>")
        strTabla.Append("</tr>")
        strTabla.Append("<tr>")
        strTabla.Append("<td>")
        strTabla.AppendFormat("<img src=""{0}"" style=""border:none; width:2.8in; height:2.70in;"">", strImage)
        strTabla.Append("</td>")
        strTabla.Append("<td>")
        strTabla.AppendFormat("<img src=""{0}"" style=""border:none; width:2.8in; height:2.70in;"">", strImage)
        strTabla.Append("</td>")
        strTabla.Append("<td>")
        strTabla.AppendFormat("<img src=""{0}"" style=""border:none; width:2.8in; height:2.70in;"">", strImage)
        strTabla.Append("</td>")
        strTabla.Append("</tr>")
        strTabla.Append("<tr>")
        strTabla.Append("<td>")
        strTabla.AppendFormat("<img src=""{0}"" style=""border:none; width:2.8in; height:2.70in;"">", strImage)
        strTabla.Append("</td>")
        strTabla.Append("<td>")
        strTabla.AppendFormat("<img src=""{0}"" style=""border:none; width:2.8in; height:2.70in;"">", strImage)
        strTabla.Append("</td>")
        strTabla.Append("<td>")
        strTabla.AppendFormat("<img src=""{0}"" style=""border:none; width:2.8in; height:2.70in;"">", strImage)
        strTabla.Append("</td>")
        strTabla.Append("</tr>")
        strTabla.Append("<tr>")
        strTabla.Append("<td>")
        strTabla.AppendFormat("<img src=""{0}"" style=""border:none; width:2.8in; height:2.70in;"">", strImage)
        strTabla.Append("</td>")
        strTabla.Append("<td>")
        strTabla.AppendFormat("<img src=""{0}"" style=""border:none; width:2.8in; height:2.70in;"">", strImage)
        strTabla.Append("</td>")
        strTabla.Append("<td>")
        strTabla.AppendFormat("<img src=""{0}"" style=""border:none; width:2.8in; height:2.70in;"">", strImage)
        strTabla.Append("</td>")
        strTabla.Append("</tr>")
        strTabla.Append("</table>")

        Return strTabla.ToString()
    End Function

    Private Function strGetImpresionPromocion(ByVal intPromocionId As Integer, Optional ByVal blnSaltoPagina As Boolean = False) As String
        ' Declaracion de Variables
        Dim objArrayPromociones As Array
        Dim strRegistroPromocion As String()
        Dim intConsecutivo As Integer

        objArrayPromociones = Nothing

        'Obtenemos el detalle de la promocion
        objArrayPromociones = Benavides.CC.Data.clsPromociones.strBuscarDetallePromocionSenalizacion(intPromocionId, 0, strConnectionString)

        Dim imgPath As String = System.Configuration.ConfigurationSettings.AppSettings("strImagenesPromociones")
        If IsArray(objArrayPromociones) AndAlso objArrayPromociones.Length > 0 Then
            intConsecutivo += 1
            For Each strRegistroPromocion In objArrayPromociones
                Return strCreate1x1Table(String.Format("{0}?id={1}", imgPath, intPromocionId), blnSaltoPagina)

                'If strRegistroPromocion(4) = "1x1" Then
                '    Return strCreate1x1Table(String.Format("{0}?id={1}", imgPath, intPromocionId), blnSaltoPagina)
                'ElseIf strRegistroPromocion(4) = "1x3" Then
                '    Return strCreate1x3Table(String.Format("{0}?id={1}", imgPath, intPromocionId), blnSaltoPagina)
                'ElseIf strRegistroPromocion(4) = "3x4" Then
                '    Return strCreate3x4Table(String.Format("{0}?id={1}", imgPath, intPromocionId), blnSaltoPagina)
                'Else
                '    Throw New ApplicationException(String.Format("Formato: {0}", strRegistroPromocion(4)))
                'End If
            Next
        End If

        Return String.Empty
    End Function

    Private Sub InitializeComponent()

    End Sub
End Class