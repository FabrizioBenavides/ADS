Imports Benavides.CC.Data
Imports Benavides.POSAdmin.Commons
Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports System.Text
Imports System.Collections

Public Class popSistemaClientesElegirSucursal
    Inherits PaginaBase

    Private intmEstadoId As Integer
    Private intmCiudadId As Integer
    Private intmCadenaId As Integer
    Private strmSucursalId As String

    Private strmcboEstado As String
    Private strmcboCiudad As String
    Private strmcboCadena As String
    Private strmCboSucursal As String


    '====================================================================
    ' Name       : intEstadoId 
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intEstadoId() As Integer
        Get
            Return intmEstadoId
        End Get
        Set(ByVal intValue As Integer)
            intmEstadoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intCiudadId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intCiudadId() As Integer
        Get
            Return intmCiudadId
        End Get
        Set(ByVal intValue As Integer)
            intmCiudadId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intCadenaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intCadenaId() As Integer
        Get
            Return intmCadenaId
        End Get
        Set(ByVal intValue As Integer)
            intmCadenaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strSucursalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strSucursalId() As String
        Get
            Return strmSucursalId
        End Get
        Set(ByVal intValue As String)
            strmSucursalId = intValue
        End Set
    End Property
    '====================================================================
    ' Name       : strLlenarEstadoComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboEstado"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarEstadoComboBox() As String

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboEstado", intEstadoId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacionEdo(0, 0, 0, strConnectionString), 0, 1, 2)

    End Function

    '====================================================================
    ' Name       : strLlenarCiudadComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboCiudad"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarCiudadComboBox() As String
        If intEstadoId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboCiudad", intCiudadId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacionEdo(intEstadoId, 0, 0, strConnectionString), 0, 1, 2)
        End If
    End Function

    '====================================================================
    ' Name       : strLlenarSucursalComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboSucursal"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String

    '====================================================================
    Public Function strLlenarSucursalComboBox() As String

        If intEstadoId > 0 AndAlso intCiudadId > 0 Then

            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSucursal", strSucursalId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacionEdo(intEstadoId, intCiudadId, intCadenaId, strConnectionString), New Integer(1) {0, 1}, 2, 2)

        End If

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class