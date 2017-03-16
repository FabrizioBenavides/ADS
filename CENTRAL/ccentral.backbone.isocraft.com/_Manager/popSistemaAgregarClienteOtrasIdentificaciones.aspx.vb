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

    Public Enum AsignarValoresControles
        No = 0
        Si = 1
    End Enum

    Private _valorGuardar As EstatusGuardar
    Private _valorAsignar As AsignarValoresControles

    'Private _strClienteABFId As String
    Private _strClienteABFNombre As String
    Private _strMensajePOS As String
    Private _strCredencialUnica As String
    Private _strLlaveOnline As String
    Private _blnConsHostExterno As Boolean = False
    Private _strCodigoStatus As String
    Private _strCodigoConfirmaVenta As String
    Private _strCodigoReversaVenta As String
    Private _strTieneDVPHJ As String
    Private _strAdjudicaSinStatus As String
    Private _strMensajeSinStatus As String
    Private _fltBonificacionSinStatus As Decimal
    Private _fltCreditoSinStatus As Decimal
    Private _strUsaOrdenDeCompra As String
    Private _strValidaLimiteOC As String
    Private _intLimiteOC As Integer
    Private _strClavePadecimiento As String
    Private _strClaveFamiliar As String
    Private _strClaveUnica As String
    Private _strClaveAutorizacion As String
    Private _strDiasTratamiento As String
    Private _strMensajeCredencial As String
    Private _strSinDespliegueBeneficiarios As String
    Private _strDuplicaIdTransaccion As String

    Public ReadOnly Property strEsActualizarCliente() As String
        Get
            Return GetPageParameter("strEsActualizarCliente", "")
        End Get
    End Property

    Public ReadOnly Property ValorGuardar As EstatusGuardar
        Get
            Return _valorGuardar
        End Get
    End Property

    Public ReadOnly Property ValorAsignar As AsignarValoresControles
        Get
            Return _valorAsignar
        End Get
    End Property

    Public ReadOnly Property strClienteABFId() As String
        Get
            Return GetPageParameter("strClienteABFId", "")
        End Get
        'Set(ByVal value As String)
        '    _strClienteABFId = value
        'End Set
    End Property

    Public Property strClienteABFNombre() As String
        Get
            Return GetPageParameter("strClienteABFNombre", "")

            Dim valorRegreso As String

            If GetPageParameter("strClienteABFNombre", "") Is String.Empty Then
                valorRegreso = _strMensajePOS
            Else
                valorRegreso = GetPageParameter("strClienteABFNombre", "")
            End If

            Return valorRegreso
        End Get
        Set(ByVal value As String)
            _strClienteABFNombre = value
        End Set
    End Property

    Public Property strMensajePOS() As String
        Get
            Dim valorRegreso As String

            If GetPageParameter("strMensajePOS", "") Is String.Empty Then
                valorRegreso = _strMensajePOS
            Else
                valorRegreso = GetPageParameter("strMensajePOS", "")
            End If

            Return valorRegreso
        End Get
        Set(value As String)
            _strMensajePOS = value
        End Set
    End Property

    Public Property strCredencialUnica() As String
        Get
            Dim valorRegreso As String

            If GetPageParameter("strCredencialUnica", "") Is String.Empty Then
                valorRegreso = _strCredencialUnica
            Else
                valorRegreso = GetPageParameter("strCredencialUnica", "")
            End If

            Return valorRegreso
        End Get
        Set(value As String)
            _strCredencialUnica = value
        End Set
    End Property

    Public Property strLlaveOnline() As String
        Get
            Dim valorRegreso As String

            If GetPageParameter("strLlaveOnline", "") Is String.Empty Then
                valorRegreso = _strLlaveOnline
            Else
                valorRegreso = GetPageParameter("strLlaveOnline", "")
            End If

            Return valorRegreso
        End Get
        Set(value As String)
            _strLlaveOnline = value
        End Set
    End Property

    Public Property blnConsHostExterno() As Boolean
        Get
            Dim valorParametroPagina As String = GetPageParameter("blnConsHostExterno", "")
            Dim valorRegresar As Boolean = False

            If Not valorParametroPagina = String.Empty Then
                valorRegresar = CBool(valorParametroPagina)
            Else
                valorRegresar = _blnConsHostExterno
            End If

            Return valorRegresar
        End Get
        Set(value As Boolean)
            _blnConsHostExterno = value
        End Set
    End Property

    Public Property strCodigoStatus() As String
        Get
            Dim valorRegreso As String

            If GetPageParameter("strCodigoStatus", "") Is String.Empty Then
                valorRegreso = _strCodigoStatus
            Else
                valorRegreso = GetPageParameter("strCodigoStatus", "")
            End If

            Return valorRegreso
        End Get
        Set(value As String)
            _strCodigoStatus = value
        End Set
    End Property

    Public Property strCodigoConfirmaVenta() As String
        Get
            Dim valorRegreso As String

            If GetPageParameter("strCodigoConfirmaVenta", "") Is String.Empty Then
                valorRegreso = _strCodigoConfirmaVenta
            Else
                valorRegreso = GetPageParameter("strCodigoConfirmaVenta", "")
            End If

            Return valorRegreso
        End Get
        Set(value As String)
            _strCodigoConfirmaVenta = value
        End Set
    End Property

    Public Property strCodigoReversaVenta() As String
        Get
            Dim valorRegreso As String

            If GetPageParameter("strCodigoConfirmaVenta", "") Is String.Empty Then
                valorRegreso = _strCodigoReversaVenta
            Else
                valorRegreso = GetPageParameter("strCodigoReversaVenta", "")
            End If

            Return valorRegreso
        End Get
        Set(value As String)
            _strCodigoReversaVenta = value
        End Set
    End Property

    Public Property strTieneDVPHJ() As String
        Get
            Dim valorRegreso As String

            If GetPageParameter("strTieneDVPHJ", "") Is String.Empty Then
                valorRegreso = _strTieneDVPHJ
            Else
                valorRegreso = GetPageParameter("strTieneDVPHJ", "")
            End If

            Return valorRegreso
        End Get
        Set(value As String)
            _strTieneDVPHJ = value
        End Set
    End Property

    Public Property strAdjudicaSinStatus() As String
        Get
            Dim valorRegreso As String

            If GetPageParameter("strAdjudicaSinStatus", "") Is String.Empty Then
                valorRegreso = _strAdjudicaSinStatus
            Else
                valorRegreso = GetPageParameter("strAdjudicaSinStatus", "")
            End If

            Return valorRegreso
        End Get
        Set(value As String)
            _strAdjudicaSinStatus = value
        End Set
    End Property

    Public Property strMensajeSinStatus() As String
        Get
            Dim valorRegreso As String

            If GetPageParameter("strMensajeSinStatus", "") Is String.Empty Then
                valorRegreso = _strAdjudicaSinStatus
            Else
                valorRegreso = GetPageParameter("strMensajeSinStatus", "")
            End If

            Return valorRegreso
        End Get
        Set(value As String)
            _strAdjudicaSinStatus = value
        End Set
    End Property

    Public Property fltBonificacionSinStatus() As Decimal
        Get
            Dim valorRegreso As Decimal

            If GetPageParameter("fltBonificacionSinStatus", "") Is String.Empty Then
                valorRegreso = _fltBonificacionSinStatus
            Else
                valorRegreso = CDec(GetPageParameter("fltBonificacionSinStatus", "0"))
            End If

            Return valorRegreso
        End Get
        Set(value As Decimal)
            _fltBonificacionSinStatus = value
        End Set
    End Property

    Public Property fltCreditoSinStatus() As Decimal
        Get
            Dim valorRegreso As Decimal

            If GetPageParameter("fltCreditoSinStatus", "") Is String.Empty Then
                valorRegreso = _fltCreditoSinStatus
            Else
                valorRegreso = CDec(GetPageParameter("fltCreditoSinStatus", "0"))
            End If

            Return valorRegreso
        End Get
        Set(value As Decimal)
            _fltCreditoSinStatus = value
        End Set
    End Property

    Public Property strUsaOrdenDeCompra() As String
        Get
            Dim valorRegreso As String

            If GetPageParameter("strUsaOrdenDeCompra", "") Is String.Empty Then
                valorRegreso = _strUsaOrdenDeCompra
            Else
                valorRegreso = GetPageParameter("strUsaOrdenDeCompra", "")
            End If

            Return valorRegreso
        End Get
        Set(value As String)
            _strUsaOrdenDeCompra = value
        End Set
    End Property

    Public Property strValidaLimiteOC() As String
        Get
            Dim valorRegreso As String

            If GetPageParameter("strValidaLimiteOC", "") Is String.Empty Then
                valorRegreso = _strValidaLimiteOC
            Else
                valorRegreso = GetPageParameter("strValidaLimiteOC", "")
            End If

            Return valorRegreso
        End Get
        Set(value As String)
            _strValidaLimiteOC = value
        End Set
    End Property

    Public Property intLimiteOC() As Integer
        Get
            Dim valorRegreso As Integer

            If GetPageParameter("intLimiteOC", "") Is String.Empty Then
                valorRegreso = _intLimiteOC
            Else
                valorRegreso = CInt(GetPageParameter("intLimiteOC", ""))
            End If

            Return valorRegreso
        End Get
        Set(value As Integer)
            _intLimiteOC = value
        End Set
    End Property

    Public Property strClavePadecimiento() As String
        Get
            Dim valorRegreso As String

            If GetPageParameter("strClavePadecimiento", "") Is String.Empty Then
                valorRegreso = _strClavePadecimiento
            Else
                valorRegreso = GetPageParameter("strClavePadecimiento", "")
            End If

            Return valorRegreso
        End Get
        Set(value As String)
            _strClavePadecimiento = value
        End Set
    End Property

    Public Property strClaveFamiliar() As String
        Get
            Dim valorRegreso As String

            If GetPageParameter("strClaveFamiliar", "") Is String.Empty Then
                valorRegreso = _strClaveFamiliar
            Else
                valorRegreso = GetPageParameter("strClaveFamiliar", "")
            End If

            Return valorRegreso
        End Get
        Set(value As String)
            _strClaveFamiliar = value
        End Set
    End Property

    Public Property strClaveUnica() As String
        Get
            Dim valorRegreso As String

            If GetPageParameter("strClaveUnica", "") Is String.Empty Then
                valorRegreso = _strClaveUnica
            Else
                valorRegreso = GetPageParameter("strClaveUnica", "")
            End If

            Return valorRegreso
        End Get
        Set(value As String)
            _strClaveFamiliar = value
        End Set
    End Property

    Public Property strClaveAutorizacion() As String
        Get
            Dim valorRegreso As String

            If GetPageParameter("strClaveAutorizacion", "") Is String.Empty Then
                valorRegreso = _strClaveAutorizacion
            Else
                valorRegreso = GetPageParameter("strClaveAutorizacion", "")
            End If

            Return valorRegreso
        End Get
        Set(value As String)
            _strClaveAutorizacion = value
        End Set
    End Property

    Public Property strDiasTratamiento() As String
        Get
            Dim valorRegreso As String

            If GetPageParameter("strDiasTratamiento", "") Is String.Empty Then
                valorRegreso = _strDiasTratamiento
            Else
                valorRegreso = GetPageParameter("strDiasTratamiento", "")
            End If

            Return valorRegreso
        End Get
        Set(value As String)
            _strDiasTratamiento = value
        End Set
    End Property

    Public Property strMensajeCredencial() As String
        Get
            Dim valorRegreso As String

            If GetPageParameter("strMensajeCredencial", "") Is String.Empty Then
                valorRegreso = _strMensajeCredencial
            Else
                valorRegreso = GetPageParameter("strMensajeCredencial", "")
            End If

            Return valorRegreso
        End Get
        Set(value As String)
            _strMensajeCredencial = value
        End Set
    End Property

    Public Property strSinDespliegueBeneficiarios() As String
        Get
            Dim valorRegreso As String

            If GetPageParameter("strSinDespliegueBeneficiarios", "") Is String.Empty Then
                valorRegreso = _strSinDespliegueBeneficiarios
            Else
                valorRegreso = GetPageParameter("strSinDespliegueBeneficiarios", "")
            End If

            Return valorRegreso
        End Get
        Set(value As String)
            _strSinDespliegueBeneficiarios = value
        End Set
    End Property

    Public Property strDuplicaIdTransaccion() As String
        Get
            Dim valorRegreso As String

            If GetPageParameter("strDuplicaIdTransaccion", "") Is String.Empty Then
                valorRegreso = _strDuplicaIdTransaccion
            Else
                valorRegreso = GetPageParameter("strDuplicaIdTransaccion", "")
            End If

            Return valorRegreso
        End Get
        Set(value As String)
            _strDuplicaIdTransaccion = value
        End Set
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

            Case "Buscar"
                Call BuscarTblOtrasIdentificacionesABFPorId()
            Case "Nuevo"
                Call GuardarTblOtrasIdentificacionesABF()



        End Select




    End Sub

    Private Sub BuscarTblOtrasIdentificacionesABFPorId()
        Dim resultado As Integer = 0
        Dim resultadoCliente As Array
        Dim objCliente As SortedList

        resultadoCliente = clsClientesABF. _
                           clsOtrasIdentificacionesABF. _
                           intBuscarTblOtrasIdentificacionesABFPorId(strClienteABFId, strConnectionString)

        For Each renglon As SortedList In resultadoCliente
            _strMensajePOS = renglon.Item("strMensajePOS").ToString()




        Next

        _valorAsignar = AsignarValoresControles.Si
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
