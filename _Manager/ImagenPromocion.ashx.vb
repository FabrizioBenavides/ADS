Imports System.IO
Imports System.Web
Imports System.Web.Services

Public Class ImagenPromocion
    Implements System.Web.IHttpHandler


    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        If Trim(context.Request.Form("content")) <> String.Empty Then
            SaveImagenPromocion(context.Request.Form("id"), context.Request.Form("content"))
        Else
            Dim client As New System.Net.WebClient()
            Dim imgPath As String

            imgPath = strGetImagenPromocion(CInt(context.Request.QueryString("Id")), CInt(context.Request.QueryString("IdFormato")), context)
            If Path.GetExtension(imgPath) = ".jpg" Then
                context.Response.ContentType = "image/jpeg"
            ElseIf Path.GetExtension(imgPath) = ".gif" Then
                context.Response.ContentType = "image/gif"
            ElseIf Path.GetExtension(imgPath) = ".png" Then
                context.Response.ContentType = "image/png"
            End If

            Dim objStream As New FileStream(imgPath, FileMode.Open, FileAccess.Read, FileShare.Read)
            Try
                objStream = New FileStream(imgPath, FileMode.Open, FileAccess.Read, FileShare.Read)

                Dim result(CInt(objStream.Length)) As Byte
                objStream.Read(result, 0, CInt(objStream.Length))

                context.Response.OutputStream.Write(result, 0, result.Length)

                objStream.Close()
            Catch ex As Exception
                Throw
            End Try
        End If
    End Sub

    Private Sub SaveImagenPromocion(strArchivo As String, strContenido As String)
        Dim imgPath As String = String.Format("{0}{1}", System.Configuration.ConfigurationSettings.AppSettings("strPromocionesDirectory"), strArchivo)

        Dim content() As Byte = Convert.FromBase64String(strContenido)

        Dim objArchivo As System.IO.FileStream
        Try
            objArchivo = New System.IO.FileStream(imgPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read)
            objArchivo.Write(content, 0, content.Length)
            objArchivo.Close()
        Catch ex As Exception
            Throw
        Finally
            If Not objArchivo Is Nothing Then
                'objArchivo.Dispose()
            End If
        End Try

    End Sub

    Private Function strGetImagenPromocion(intPromocionId As Integer, IdFormato As Integer, ByVal context As HttpContext) As String
        ' Declaracion de Variables
        Dim objArrayPromociones As Array
        Dim strRegistroPromocion As String()
        Dim intConsecutivo As Integer

        objArrayPromociones = Nothing

        'Obtenemos el detalle de la promocion
        objArrayPromociones = Benavides.CC.Data.clsPromociones.strBuscarDetallePromocionSenalizacion(intPromocionId, IdFormato, System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral"))

        Dim imgPath As String = System.Configuration.ConfigurationSettings.AppSettings("strPromocionesDirectory")
        If IsArray(objArrayPromociones) AndAlso objArrayPromociones.Length > 0 Then
            intConsecutivo += 1
            For Each strRegistroPromocion In objArrayPromociones
                Return String.Format("{0}{1}", imgPath, strRegistroPromocion(5))
            Next
        End If

        Return String.Empty
    End Function

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class