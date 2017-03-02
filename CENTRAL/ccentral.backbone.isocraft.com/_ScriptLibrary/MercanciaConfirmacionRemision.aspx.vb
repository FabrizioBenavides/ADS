'====================================================================
' Page          : MercanciaConfirmacionRemisiones.aspx
' Title         : Administracion POS y BackOffice
' Description   : Página donde confirma las remisiones
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : J.Antonio Hernández Dávila
' Version       : 1.0
' Last Modified : Miercoles, Octubre 22, 2003
'====================================================================

Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text

Public Class MercanciaConfirmacionRemision
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

    Private strmRemisionElectronicaNumero As String = ""
    Private dtmmRemisionElectronicaEmision As String = ""
    Private strmProveedorRazonSocial As String = ""

    Private strmMensaje As String = ""
    Private strmConfirmada As String = ""
    Public intConfirmacion As Integer = 0

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
            Return Request.ServerVariables("SCRIPT_NAME") & "?intProveedorId=" & intProveedorId.ToString & "&intRemisionElectronicaId=" & intRemisionElectronicaId
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
    ' Name       : intProveedorId
    ' Description: Id del Proveedor de la Remision a Confirmar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intProveedorId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intProveedorId")) Then
                Return CInt(Request.QueryString("intProveedorId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intRemisionElectronicaId
    ' Description: Id de la Remision a Confirmar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intRemisionElectronicaId() As String
        Get
            If Not IsNothing(Request.QueryString("intRemisionElectronicaId")) Then
                Return Trim(Request.QueryString("intRemisionElectronicaId"))
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmRecepcionRemision
    ' Description: Fecha de Emison de la Remision Capturada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================  
    Public ReadOnly Property dtmRecepcionRemision() As String
        Get
            Return Request.Form("dtmRecepcionRemision")
        End Get
    End Property

    '====================================================================
    ' Name       : strNumeroRemisionCapturada
    ' Description: Numero de Remision Capturada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================  
    Public ReadOnly Property strNumeroRemisionCapturada() As String
        Get
            Return Trim(Request.Form("txtNumeroRemision"))
        End Get
    End Property

    '====================================================================
    ' Name       : dtmEmisionRemisionCapturadaId
    ' Description: Fecha de Emison de la Remision Capturada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================  
    Public ReadOnly Property dtmEmisionRemisionCapturadaId() As String
        Get
            Return Request.Form("dtmEmisionRemision")
        End Get
    End Property



    '====================================================================
    ' Name       : strProveedorRazonSocial
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================  
    Public Property strProveedorRazonSocial() As String
        Get
            Return strmProveedorRazonSocial
        End Get
        Set(ByVal Value As String)
            strmProveedorRazonSocial = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strRemisionElectronicaNumero
    ' Description: Numero de Remision Electronica Consultada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================  
    Public Property strRemisionElectronicaNumero() As String
        Get
            Return strmRemisionElectronicaNumero
        End Get
        Set(ByVal Value As String)
            strmRemisionElectronicaNumero = Value
        End Set
    End Property

    '====================================================================
    ' Name       : dtmRemisionElectronicaEmision
    ' Description: Fecha de Emision de la Remision Electronica Consultada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '====================================================================  
    Public Property dtmRemisionElectronicaEmision() As String
        Get
            Return dtmmRemisionElectronicaEmision
        End Get
        Set(ByVal Value As String)
            dtmmRemisionElectronicaEmision = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strMensaje
    ' Description: Fecha de Emision de la Remision Electronica Consultada
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
    ' Name       : strConfirmada
    ' Description: Para validar en la pagina si ya se hizo confirmación
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Date
    '====================================================================  
    Public Property strConfirmada() As String
        Get
            Return strmConfirmada
        End Get
        Set(ByVal Value As String)
            strmConfirmada = Value
        End Set
    End Property


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        'Valor de entrada si no se reciben se regresa a la pagina padre
        If intProveedorId = 0 Or Len(intRemisionElectronicaId) = 0 Then
            Call Response.Redirect("MercanciaRemisionporConfirmar.aspx")
        End If

        Dim objArrayRemision As Array = Nothing
        Dim strRegistroRemison() As String = Nothing

        objArrayRemision = clsConcentrador.clsSucursal.clsMercancia.clsRemisionElectronica.strBuscarConfirmacionRemision(intCompaniaId, intSucursalId, intProveedorId, CInt(intRemisionElectronicaId), "GENERADA", strCadenaConexion)

        'Validamos la Respuesta
        If IsArray(objArrayRemision) AndAlso objArrayRemision.Length > 0 Then

            strRegistroRemison = DirectCast(objArrayRemision.GetValue(0), String())

            strRemisionElectronicaNumero = [String].Copy(clsCommons.strFormatearDescripcion(strRegistroRemison(0)))
            dtmRemisionElectronicaEmision = CDate([String].Copy(strRegistroRemison(1))).ToString("MM/dd/yyyy")
            strProveedorRazonSocial = [String].Copy(clsCommons.strFormatearDescripcion(strRegistroRemison(2)))

        End If

        If Len(Request("cmdConfirmar")) > 0 Then
            Dim blnConfirma As Boolean = True

            If CDate(clsCommons.strDMYtoMDY(dtmRecepcionRemision)) > CDate(Date.Now.ToString("MM/dd/yyyy")) Then
                strMensaje = "Fecha de Recepción no Puede ser mayor al día de Hoy"
                blnConfirma = False
            End If

            If CDate(clsCommons.strDMYtoMDY(dtmEmisionRemisionCapturadaId)) > CDate(clsCommons.strDMYtoMDY(dtmRecepcionRemision)) Then
                strMensaje = "Fecha de Remisión no puede ser mayor a la Fecha de Recepción"
                blnConfirma = False
            End If

            If blnConfirma Then

                intConfirmacion = clsConcentrador.clsSucursal.clsMercancia.clsRemisionElectronica.intConfirmarRemision(intCompaniaId, intSucursalId, CInt(intRemisionElectronicaId), CDate(clsCommons.strDMYtoMDY(CStr(dtmRecepcionRemision))), strUsuarioNombre, strCadenaConexion)

                If intConfirmacion > 0 Then
                    strMensaje = "Folio Confirmación Remisión: " & intConfirmacion.ToString
                    strConfirmada = "1"
                Else
                    strMensaje = "Confirmación no puede realizarse"
                End If
            End If

        End If


    End Sub

End Class
