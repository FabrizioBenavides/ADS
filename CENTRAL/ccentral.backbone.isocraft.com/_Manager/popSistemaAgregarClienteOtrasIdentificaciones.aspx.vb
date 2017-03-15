Imports System.Text
Imports System.Collections
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports Benavides.CC.Data

Public Class popSistemaAgregarClienteOtrasIdentificaciones
    Inherits PaginaBase

    Public Enum EstatusGuardar
        [Error] = -1
        Correcto = 1
    End Enum

    Private _valorGuardar As EstatusGuardar

    Public ReadOnly Property ValorGuardar As EstatusGuardar
        Get
            Return _valorGuardar
        End Get
    End Property

    Public ReadOnly Property strClienteABFId() As String
        Get
            Return GetPageParameter("strClienteABFId", "")
        End Get
    End Property

    Public ReadOnly Property strClienteABFNombre() As String
        Get
            Return GetPageParameter("strClienteABFNombre", "")
        End Get
    End Property

    Public ReadOnly Property strMensajePOS() As String
        Get
            Return GetPageParameter("strMensajePOS", "")
        End Get
    End Property

    Public ReadOnly Property strCredencialUnica() As String
        Get
            Return GetPageParameter("strCredencialUnica", "")
        End Get
    End Property

    Public ReadOnly Property strLlaveOnline() As String
        Get
            Return GetPageParameter("strLlaveOnline", "")
        End Get
    End Property

    Public ReadOnly Property blnConsHostExterno() As Boolean
        Get
            Dim valorParametroPagina As String = GetPageParameter("blnConsHostExterno", "")
            Dim valorRegresar As Boolean = False

            If Not valorParametroPagina = String.Empty Then
                valorRegresar = CBool(valorParametroPagina)
            End If

            Return valorRegresar
        End Get
    End Property

    Public ReadOnly Property strCodigoStatus() As String
        Get
            Return GetPageParameter("strCodigoStatus", "")
        End Get
    End Property

    Public ReadOnly Property strCodigoConfirmaVenta() As String
        Get
            Return GetPageParameter("strCodigoConfirmaVenta", "")
        End Get
    End Property

    Public ReadOnly Property strCodigoReversaVenta() As String
        Get
            Return GetPageParameter("strCodigoReversaVenta", "")
        End Get
    End Property

    Public ReadOnly Property strTieneDVPHJ() As String
        Get
            Return GetPageParameter("strTieneDVPHJ", "")
        End Get
    End Property

    Public ReadOnly Property strAdjudicaSinStatus() As String
        Get
            Return GetPageParameter("strAdjudicaSinStatus", "")
        End Get
    End Property

    Public ReadOnly Property strMensajeSinStatus() As String
        Get
            Return GetPageParameter("strMensajeSinStatus", "")
        End Get
    End Property

    Public ReadOnly Property fltBonificacionSinStatus() As Decimal
        Get
            Return CDec(GetPageParameter("fltBonificacionSinStatus", "0"))
        End Get
    End Property

    Public ReadOnly Property fltCreditoSinStatus() As Decimal
        Get
            Return CDec(GetPageParameter("fltCreditoSinStatus", "0"))
        End Get
    End Property

    Public ReadOnly Property strUsaOrdenDeCompra() As String
        Get
            Return GetPageParameter("strUsaOrdenDeCompra", "")
        End Get
    End Property

    Public ReadOnly Property strValidaLimiteOC() As String
        Get
            Return GetPageParameter("strValidaLimiteOC", "")
        End Get
    End Property

    Public ReadOnly Property intLimiteOC() As Integer
        Get
            Return CInt(GetPageParameter("intLimiteOC", "0"))
        End Get
    End Property

    Public ReadOnly Property strClavePadecimiento() As String
        Get
            Return GetPageParameter("strClavePadecimiento", "")
        End Get
    End Property

    Public ReadOnly Property strClaveFamiliar() As String
        Get
            Return GetPageParameter("strClaveFamiliar", "")
        End Get
    End Property

    Public ReadOnly Property strClaveUnica() As String
        Get
            Return GetPageParameter("strClaveUnica", "")
        End Get
    End Property

    Public ReadOnly Property strClaveAutorizacion() As String
        Get
            Return GetPageParameter("strClaveAutorizacion", "")
        End Get
    End Property

    Public ReadOnly Property strDiasTratamiento() As String
        Get
            Return GetPageParameter("strDiasTratamiento", "")
        End Get
    End Property

    Public ReadOnly Property strMensajeCredencial() As String
        Get
            Return GetPageParameter("strMensajeCredencial", "")
        End Get
    End Property

    Public ReadOnly Property strSinDespliegueBeneficiarios() As String
        Get
            Return GetPageParameter("strSinDespliegueBeneficiarios", "")
        End Get
    End Property

    Public ReadOnly Property strDuplicaIdTransaccion() As String
        Get
            Return GetPageParameter("strDuplicaIdTransaccion", "")
        End Get
    End Property

    Public ReadOnly Property strCmd2() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd2", "")
        End Get
    End Property

    ''' <summary>
    ''' This call is required by the Web Form Designer. 
    ''' </summary>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Select Case strCmd2

            Case "Nuevo"
                Call GuardarTblOtrasIdentificacionesABF()



        End Select




    End Sub

    Private Sub GuardarTblOtrasIdentificacionesABF()
        Dim resultado As Integer = 0
        Dim objCliente As tblOtrasIdentificacionesABF

        objCliente = New tblOtrasIdentificacionesABF(strClienteABFId, _
                                                     strClienteABFNombre, _
                                                     strMensajePOS, _
                                                     strCredencialUnica, _
                                                     strLlaveOnline, _
                                                     blnConsHostExterno, _
                                                     strCodigoStatus, _
                                                     strCodigoConfirmaVenta, _
                                                     strCodigoReversaVenta, _
                                                     strTieneDVPHJ, _
                                                     strAdjudicaSinStatus, _
                                                     strMensajeSinStatus, _
                                                     fltBonificacionSinStatus, _
                                                     fltCreditoSinStatus, _
                                                     strUsaOrdenDeCompra, _
                                                     strValidaLimiteOC, _
                                                     intLimiteOC, _
                                                     strClavePadecimiento, _
                                                     strClaveFamiliar, _
                                                     strClaveUnica, _
                                                     strClaveAutorizacion, _
                                                     strDiasTratamiento, _
                                                     strMensajeCredencial, _
                                                     strSinDespliegueBeneficiarios, _
                                                     strDuplicaIdTransaccion, _
                                                     strUsuarioNombre)

        resultado = clsClientesABF.clsOtrasIdentificacionesABF _
                    .intGuardarTblOtrasIdentificacionesABF(objCliente, strConnectionString)

        If resultado = 1 Then
            strJavascriptWindowOnLoadCommands = "alert(""Cliente guardado correctamente."");"
            _valorGuardar = EstatusGuardar.Correcto
        ElseIf resultado = -1 Then
            _valorGuardar = EstatusGuardar.Error
        ElseIf resultado = -2 Then
            strJavascriptWindowOnLoadCommands = "alert(""La clave del cliente ya existe."");"
            _valorGuardar = EstatusGuardar.Error
        ElseIf resultado = -3 Then
            strJavascriptWindowOnLoadCommands = "alert(""La clave del cliente no existe dentro del catálogo de clientes institucionales."");"
            _valorGuardar = EstatusGuardar.Error
        End If
    End Sub

End Class
