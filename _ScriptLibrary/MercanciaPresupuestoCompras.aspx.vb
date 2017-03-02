'====================================================================
' Page          : MercanciaPresupuestoCompras.aspx
' Title         : Administracion POS y BackOffice
' Description   : Página Consulta asignado a la Sucursal
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Griselda Gómez Ponce
' Version       : 1.0
' Last Modified : Lunes, 17 de noviembre, 2003   
'====================================================================

Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text
Imports System.DateTime


Public Class clsMercanciaPresupuestoCompras
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    'Declaracion de variables

    Private strmMensaje As String = ""
    Private fltmCuotaGastoValor As String = ""
    Private fltmCompraPorDepartamentoImporteCompra As String = ""
    Private fltmPorcentajeGasto As String = ""
    Private strmNombreMes As String = ""

    '====================================================================
    ' Name       : strRedirectPage
    ' Description: Página hacia la cual se debe redireccionar al usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRedirectPage() As String
        Get
            If intCompaniaId > 0 AndAlso intSucursalId > 0 Then
                Return "/Default.aspx?strURL=/_ScriptLibrary/POSAdminRedirectorCC.aspx?strPageName=" & strThisPageName
            Else
                Return "/Default.aspx?strURL=" & Server.UrlEncode(Request.ServerVariables("SCRIPT_NAME"))
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strFormAction
    ' Description: Valor de la acción de la forma HTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormAction() As String
        Get
            Return Request.ServerVariables("SCRIPT_NAME")
        End Get
    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: URL de esta página
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return clsCommons.strGetPageName(Request)
        End Get
    End Property

    '====================================================================
    ' Name       : intGrupoUsuarioId
    ' Description: Identificador del Grupo de Usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intGrupoUsuarioId() As Integer
        Get
            Return CInt(clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : intCompaniaId
    ' Description: Valor de la Compañia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCompaniaId() As Integer
        Get
            Return CInt(clsCommons.strReadCookie("intCompaniaId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Valor de la Sucursal
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intSucursalId() As Integer
        Get
            Return CInt(clsCommons.strReadCookie("intSucursalId", "0", Request, Server))
        End Get
    End Property
    '====================================================================
    ' Name       : strSucursalNombre
    ' Description: Nombre de la Sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalNombre() As String
        Get
            Return clsCommons.strReadCookie("strSucursalNombre", "0", Request, Server)
        End Get
    End Property
    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del Usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return clsCommons.strReadCookie("strUsuarioNombre", "0", Request, Server)
        End Get
    End Property
    '====================================================================
    ' Name       : strCadenaConexion
    ' Description: Valor que tomara la variable strmCadenaConexion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCadenaConexion() As String
        Get
            Return ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strURLPOSAdmin
    ' Description: Valor que tomara la variable strmCadenaConexion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strURLPOSAdmin() As String
        Get
            Return clsConcentrador.strObtenerURLSucursal(intCompaniaId, intSucursalId, strCadenaConexion)
        End Get
    End Property

    '====================================================================
    ' Name       : strMensaje
    ' Description: Fecha de Emision de la Factura Electronica Consultada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '====================================================================  
    Public Property strMensaje() As String
        Get
            Return strmMensaje
        End Get
        Set(ByVal Value As String)
            strmMensaje = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Comando a ejecutar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Not IsNothing(Request.QueryString("strCmd")) Then
                Return Request.QueryString("strCmd")

            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strGeneraListaMeses
    ' Description: Lista de los meses a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================

    Public Function strGeneraListaMeses(ByVal strElementName As String) As String
        Dim objListaFormaPago As Array = Nothing
        Dim strcboMeses As StringBuilder
        Dim dtmInicio As Date = Now
        Dim intMesInicial As Double = 0
        Dim intMesFinal As Double = 5
        Dim intMes As Double = 0
        Dim intAnio As Double = 0
        Dim strMesNuevo As String = ""
        Dim strFecha As String = ""
        Dim strFechaMes As String

        strcboMeses = New StringBuilder

        strcboMeses.Append("document.forms[0]." & strElementName & ".options[")
        strcboMeses.Append("0] = new Option(""" & "Seleccione un Mes" & """,""" & "0" & """);" & vbCrLf)

        ' Creamos un ciclo para formar la lista de los meses disponibles a consultar (6 meses hacia atrás)

        For intMesInicial = 0 To intMesFinal

            intMes = DateAdd(DateInterval.Month, -intMesInicial, dtmInicio).Month
            intAnio = DateAdd(DateInterval.Month, -intMesInicial, dtmInicio).Year

            If intMes < 10 Then
                strFechaMes = "0" + intMes.ToString + "/01/" + intAnio.ToString
            Else
                strFechaMes = intMes.ToString + "/01/" + intAnio.ToString
            End If


            strMesNuevo = clsCommons.strNombreMes(CDate(strFechaMes)) + " , " + intAnio.ToString

            strcboMeses.Append("document.forms[0]." & strElementName & ".options[")
            strcboMeses.Append(intMesInicial + 1 & "] = new Option(""" & strMesNuevo & """,""" & intMes.ToString & """);" & vbCrLf)

            If intMes.ToString = strMesConsulta Then
                strcboMeses.Append("document.forms[0]." & strElementName & ".options[" & intMesInicial + 1 & "].selected = true;" & vbCrLf)
            End If



        Next

        Return strcboMeses.ToString

    End Function

    '====================================================================
    ' Name       : strMes
    ' Description: Mes de consulta
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strMesConsulta() As String
        Get
            If Not IsNothing(Request.Form("cboMesConsulta")) Then
                'Consultamos el nombre del mes
                strNombreMes = clsCommons.strNombreMes(CDate(Request.Form("cboMesConsulta") + "/01/1900"))
                'Regresamos el mes
                Return Request.Form("cboMesConsulta")

            Else
                If Not IsNothing(Request.QueryString("cboMesConsulta")) Then
                    'Consultamos el nombre del mes
                    strNombreMes = clsCommons.strNombreMes(CDate(Request.QueryString("cboMesConsulta") + "/01/1900"))
                    'Regresamos el mes
                    Return Request.QueryString("cboMesConsulta")
                Else
                    Return ""
                End If
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strNombreMes
    ' Description: Mes de Consulta
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '====================================================================  
    Public Property strNombreMes() As String
        Get
            Return strmNombreMes
        End Get
        Set(ByVal strValue As String)
            strmNombreMes = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltCuotaGastoValor
    ' Description: Presupuesto asignado para el mes
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '====================================================================  
    Public Property fltCuotaGastoValor() As String
        Get
            Return fltmCuotaGastoValor
        End Get
        Set(ByVal dblValue As String)
            fltmCuotaGastoValor = dblValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltCompraPorDepartamentoImporteCompra
    ' Description: Importe de compras aplicadas a la fecha
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '====================================================================  
    Public Property fltCompraPorDepartamentoImporteCompra() As String
        Get
            Return fltmCompraPorDepartamentoImporteCompra
        End Get
        Set(ByVal dblValue As String)
            fltmCompraPorDepartamentoImporteCompra = dblValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltCompraPorDepartamentoImporteCompra
    ' Description: Importe de compras aplicadas a la fecha
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '====================================================================  
    Public Property fltPorcentajeGasto() As String
        Get
            Return fltmPorcentajeGasto
        End Get
        Set(ByVal dblValue As String)
            fltmPorcentajeGasto = dblValue
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        Select Case strCmd
            Case "Consultar"

                'Consultamos el presupuesto del mes seleccionado

                Dim objPresupuesto As Array
                Dim strRegistroPresupuesto As String()

                objPresupuesto = Nothing

                objPresupuesto = clsConcentrador.clsSucursal.clsMercancia.strBuscarPresupuestoCompras(intCompaniaId, intSucursalId, CInt(strMesConsulta), strCadenaConexion)

                If IsArray(objPresupuesto) AndAlso objPresupuesto.Length > 0 Then
                    'obtenemos los conceptos de presupuesto

                    strRegistroPresupuesto = DirectCast(objPresupuesto.GetValue(0), String())

                    fltCuotaGastoValor = clsCommons.strFormatearNumeroPresentacion(strRegistroPresupuesto(0).ToString, True)
                    fltCompraPorDepartamentoImporteCompra = clsCommons.strFormatearNumeroPresentacion(strRegistroPresupuesto(1).ToString, True)
                    fltPorcentajeGasto = clsCommons.strFormatearNumeroPresentacion(strRegistroPresupuesto(2), False) & "%"
                Else
                    strMensaje = "No hay información para ese mes"

                End If

        End Select


    End Sub

End Class
