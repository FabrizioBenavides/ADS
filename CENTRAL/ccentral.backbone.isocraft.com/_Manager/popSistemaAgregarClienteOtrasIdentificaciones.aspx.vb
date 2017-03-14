Imports System.Text
Imports System.Collections
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports Benavides.CC.Data

Public Class popSistemaAgregarClienteOtrasIdentificaciones
    Inherits PaginaBase

    Public ReadOnly Property strCmd2() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strCmd2", "")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Select Case strCmd2

        End Select

        Dim prueba As New tblOtrasIdentificacionesABF


    End Sub



End Class

'Public Class tblOtrasIdentificacionesABF

'    Private _strClienteABFId As String
'    Private _strClienteABFNombre As String
'    Private _strMensajePOS As String
'    Private _strCredencialUnica As String
'    Private _strLlaveOnline As String
'    Private _blnConsHostExterno As Boolean
'    Private _strCodigoStatus As String
'    Private _strCodigoConfirmaVenta As String
'    Private _strCodigoReversaVenta As String
'    Private _strTieneDVPHJ As String
'    Private _strAdjudicaSinStatus As String
'    Private _strMensajeSinStatus As String
'    Private _fltBonificacionSinStatus As Decimal
'    Private _fltCreditoSinStatus As Decimal
'    Private _strUsaOrdenDeCompra As String
'    Private _strValidaLimiteOC As String
'    Private _intLimiteOC As Integer
'    Private _strClavePadecimiento As String
'    Private _strClaveFamiliar As String
'    Private _strClaveUnica As String
'    Private _strClaveAutorizacion As String
'    Private _strDiasTratamiento As String
'    Private _strMensajeCredencial As String
'    Private _strSinDespliegueBeneficiarios As String
'    Private _strDuplicaIdTransaccion As String
'    Private _dtmOtrasIdentificacionesABFUltimaModificacion As String
'    Private _strOtrasIdentificacionesABFModificadoPor As String






'End Class