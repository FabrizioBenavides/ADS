Imports System.IO
Imports System.Web
Imports System.Web.Services

Public Class ImagenExhibicionAdicional
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        'context.Response.ContentType = "text/plain"
        'context.Response.Write("Hello World!")

        If Trim(context.Request.Form("content")) <> String.Empty Then
            SaveImagenExhibicion(context.Request.Form("id"), context.Request.Form("content"))
        Else
            Dim client As New System.Net.WebClient()
            Dim imgPath As String

            imgPath = strGetImagenExhibicion(context.Request.QueryString("Id"), context)

            If System.IO.File.Exists(imgPath) Then

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
        End If

    End Sub

    Private Sub SaveImagenExhibicion(strArchivo As String, strContenido As String)
        Dim imgPath As String = String.Format("{0}{1}", System.Configuration.ConfigurationSettings.AppSettings("strExhibicionesDirectory"), strArchivo)

        Dim content() As Byte = Convert.FromBase64String(strContenido)

        Dim objArchivo As System.IO.FileStream
        Try
            If Not System.IO.File.Exists(imgPath) Then

                objArchivo = New System.IO.FileStream(imgPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read)
                objArchivo.Write(content, 0, content.Length)
                objArchivo.Close()
            End If
            
        Catch ex As Exception
            Throw
        Finally
            If Not objArchivo Is Nothing Then
                'objArchivo.Dispose()
            End If
        End Try

    End Sub

    Private Function strGetImagenExhibicion(strExhibicion As String, ByVal context As HttpContext) As String
        ' Declaracion de Variables
        Dim objArrayPromociones As Array

        objArrayPromociones = Nothing

        Dim imgPath As String = System.Configuration.ConfigurationSettings.AppSettings("strExhibicionesDirectory")
        Return String.Format("{0}{1}", imgPath, strExhibicion)

    End Function

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class