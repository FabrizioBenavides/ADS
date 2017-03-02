Imports System.Configuration
Imports System.Collections
Imports System.Text.RegularExpressions
Imports Isocraft.Security

Public Class PopSistemaCambiarContrasena
    Inherits System.Web.UI.Page

    Public Enum ActualizacionContrasena
        Valida = 1
        Invalida = 2
    End Enum

    Private _resultadoActualizacionContrasena As ActualizacionContrasena
    Private _strMensajeContrasenaInvalida As String

    '====================================================================
    ' Name       : strCadenaConexion
    ' Description: Valor de la Cadena de Conexion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCadenaConexion() As String
        Get
            Return ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    Public ReadOnly Property ResultadoActualizacionContrasena As ActualizacionContrasena
        Get
            Return _resultadoActualizacionContrasena
        End Get
    End Property

    Public ReadOnly Property strMensajeContrasenaInvalida As String
        Get
            Return _strMensajeContrasenaInvalida
        End Get
    End Property

    Public ReadOnly Property strCmd() As String
        Get
            Return Request.QueryString("strCmd")
        End Get
    End Property

    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return Request("strUsuarioNombre")
        End Get
    End Property

    Public ReadOnly Property strUsuarioContrasena() As String
        Get
            Return Request("strUsuarioContrasena")
        End Get
    End Property

    Public ReadOnly Property strUsuarioContrasenaNueva() As String
        Get
            Return Request("strUsuarioContrasenaNueva")
        End Get
    End Property

    Public ReadOnly Property strUsuarioConfirmarContrasenaNueva() As String
        Get
            Return Request("strUsuarioConfirmarContrasenaNueva")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim politicaUsuario As SortedList
        Dim strHistoriaPassword As String
        Dim strLongitudPassword As String
        Dim strVigenciaPassword As String

        Select Case strCmd

            Case "Editar"
                politicaUsuario = ObtenerPoliticaUsuarioContrasena()
                strHistoriaPassword = politicaUsuario.Item("HISTORIAPASSWORD").ToString()
                strLongitudPassword = politicaUsuario.Item("LONGITUDPASSWORD").ToString()
                strVigenciaPassword = politicaUsuario.Item("VIGENCIAPASSWORD").ToString()

                If ValidarContrasenaNueva(CInt(strLongitudPassword)) Then
                    Call ActualizarTblUsuarioContrasenas(CInt(strVigenciaPassword), CInt(strHistoriaPassword))
                End If
        End Select
    End Sub

    Private Sub ActualizarTblUsuarioContrasenas(ByVal intVigenciaPassword As Integer, ByVal intHistoriaPassword As Integer)
        Dim strUsuarioContrasenaEncriptada As String
        Dim intResultado As Integer

        strUsuarioContrasenaEncriptada = Hash.DataProtector.HashString(strUsuarioContrasenaNueva, Hash.DataProtector.CryptoServiceProvider.SHA1)

        intResultado = Benavides.CC.Data.clsUsuario.clsUsuarioContrasenas. _
                                                    intActualizarUsuarioContrasenas(intVigenciaPassword, _
                                                                                    intHistoriaPassword, _
                                                                                    strUsuarioNombre, _
                                                                                    strUsuarioContrasenaEncriptada, _
                                                                                    strUsuarioNombre, _
                                                                                    strCadenaConexion)
        If intResultado = ActualizacionContrasena.Valida Then
            _resultadoActualizacionContrasena = ActualizacionContrasena.Valida
        Else
            _resultadoActualizacionContrasena = ActualizacionContrasena.Invalida
        End If
    End Sub

    Private Function ValidarContrasenaNueva(ByVal intLongitudPassword As Integer) As Boolean
        Dim blnContrasenaValida As Boolean = True
        Dim strMensajeContrasenaValida As String = String.Empty

        If strUsuarioContrasenaNueva.Length < intLongitudPassword Then
            blnContrasenaValida = False
            _strMensajeContrasenaInvalida = "La contraseña debe de contener al menos 5 carácteres."

        ElseIf Not String.Equals(strUsuarioContrasenaNueva, strUsuarioConfirmarContrasenaNueva) Then
            blnContrasenaValida = False
            _strMensajeContrasenaInvalida = "La contraseña nueva y la confirmación no coinciden."

        ElseIf Not TieneLetra() Then
            blnContrasenaValida = False
            _strMensajeContrasenaInvalida = "La contraseña debe de tener al menos una letra."

        ElseIf Not TieneNumero() Then
            blnContrasenaValida = False
            _strMensajeContrasenaInvalida = "La contraseña debe de tener al menos un número."

        ElseIf Not TieneCaracterEspecial() Then
            blnContrasenaValida = False
            _strMensajeContrasenaInvalida = "La contraseña debe de tener al menos un carácter especial."

        ElseIf Not ExisteUsuarioConContrasena() Then
            blnContrasenaValida = False
            _strMensajeContrasenaInvalida = "El usuario y contraseña no existen."

        ElseIf strUsuarioContrasena.Equals(strUsuarioContrasenaNueva) Then
            blnContrasenaValida = False
            _strMensajeContrasenaInvalida = "Favor de ingresar una contraseña diferente a la actual."

        ElseIf ExisteContrasenaEnHistorial() Then
            blnContrasenaValida = False
            _strMensajeContrasenaInvalida = "La nueva contraseña ingresada ya ha sido utilizado anteriormente. Favor de ingresar una nueva."
        End If

        If Not blnContrasenaValida Then
            _resultadoActualizacionContrasena = ActualizacionContrasena.Invalida
        End If

        Return blnContrasenaValida
    End Function

    Private Function ExisteContrasenaEnHistorial() As Boolean
        Dim blnExisteContrasena As Boolean = False
        Dim resultado As Array
        Dim strContrasenaEncriptada As String

        strContrasenaEncriptada = Hash.DataProtector.HashString(strUsuarioContrasenaNueva, Hash.DataProtector.CryptoServiceProvider.SHA1)

        resultado = Benavides.CC.Data.clsUsuario.clsUsuarioContrasenas.strBuscarContrasenasPorNombre(strUsuarioNombre, strCadenaConexion)

        If Not resultado Is Nothing Then
            For Each renglon As SortedList In resultado
                If String.Equals(strContrasenaEncriptada, renglon.Item("strUsuarioContrasena").ToString()) Then
                    blnExisteContrasena = True
                End If
            Next
        End If

        Return blnExisteContrasena
    End Function

    Private Function ExisteUsuarioConContrasena() As Boolean
        Dim blnExisteUsuario As Boolean = False
        Dim resultado As Array
        Dim strContrasenaEncriptada As String

        strContrasenaEncriptada = Hash.DataProtector.HashString(strUsuarioContrasena, Hash.DataProtector.CryptoServiceProvider.SHA1)

        resultado = Benavides.CC.Data.clsUsuario.strBuscarUsuarioPorNombre(strUsuarioNombre, strContrasenaEncriptada, strCadenaConexion)

        If Not resultado Is Nothing Then
            blnExisteUsuario = True
        End If

        Return blnExisteUsuario
    End Function

    Private Function TieneLetra() As Boolean
        Dim intIndice As Integer
        Dim blnTieneLetra As Boolean = False

        For intIndice = 0 To strUsuarioContrasenaNueva.Length - 1

            If Char.IsLetter(strUsuarioContrasenaNueva.Chars(intIndice)) Then
                blnTieneLetra = True
            End If
        Next

        Return blnTieneLetra
    End Function

    Private Function TieneNumero() As Boolean
        Dim intIndice As Integer
        Dim blnTieneNumero As Boolean = False

        For intIndice = 0 To strUsuarioContrasenaNueva.Length - 1

            If Char.IsNumber(strUsuarioContrasenaNueva.Chars(intIndice)) Then
                blnTieneNumero = True
            End If
        Next

        Return blnTieneNumero
    End Function

    Private Function TieneCaracterEspecial() As Boolean
        Dim blnTieneCaracterEspecial As Boolean = False
        Dim strCaracteresPermitidos As String = "!¡?¿*-+{}[],.-@#$%&/()|_<>"
        Dim indiceExterno As Integer
        Dim indiceInterno As Integer
        Dim blnCaracterEncontrado As Boolean = False

        For indiceExterno = 0 To strUsuarioContrasenaNueva.Length - 1

            For indiceInterno = 0 To strCaracteresPermitidos.Length - 1
                If strUsuarioContrasenaNueva.Chars(indiceExterno).ToString().Equals(strCaracteresPermitidos.Chars(indiceInterno).ToString()) Then
                    blnTieneCaracterEspecial = True
                    blnCaracterEncontrado = True
                End If
            Next

            If blnCaracterEncontrado Then
                Exit For
            End If
        Next

        Return blnTieneCaracterEspecial
    End Function

    Private Function ObtenerPoliticaUsuarioContrasena() As SortedList
        Dim politicasUsuario As New SortedList
        Dim consultaPoliticasUsuario As Array

        consultaPoliticasUsuario = Benavides.CC.Data.clsUsuario.clsPoliticaUsuario.strConsultarTblPoliticaUsuario(strCadenaConexion)

        For Each renglon As SortedList In consultaPoliticasUsuario
            politicasUsuario.Add(renglon.Item("strPoliticaUsuarioNombreId"), renglon.Item("strPoliticaUsuarioValor"))
        Next

        Return politicasUsuario
    End Function

End Class