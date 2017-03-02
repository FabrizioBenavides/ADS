Imports System.Configuration

Imports Benavides.CC.Data
Imports Benavides.CC.Business
Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons

Public Class FotoLabEmpleadosVerFicha
    Inherits System.Web.UI.Page

    Private intmPuestoEmpleadoId As Integer
    Private strmEmpleadoPuesto As String
    Private strmEmpleadoNombre As String
    Private strmEmpleadoApellidoPaterno As String
    Private strmEmpleadoApellidoMaterno As String
    Private strmEmpleadoRFC As String
    Private strmEmpleadoGenero As String
    Private strmEmpleadoNumeroIMSS As String
    Private strmEmpleadoCalle As String
    Private strmEmpleadoNumeroExterior As String
    Private strmEmpleadoColonia As String
    Private strmEmpleadoNumeroInterior As String
    Private strmEmpleadoEstado As String
    Private strmEmpleadoCodigoPostal As String
    Private strmEmpleadoCiudad As String


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

    '====================================================================
    ' Name       : strRedirectParentPage
    ' Description: Página padre hacia la cual se debe redireccionar al
    '              usuario en caso de querer acceder directamente a esta
    '              página
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRedirectParentPage() As String
        Get
            Return "FotoLabEmpleadosAdministrar.aspx"
        End Get
    End Property

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
            Return Request.ServerVariables("SCRIPT_NAME") & "?intEmpleadoId=" & intEmpleadoId
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
    ' Accessor   : Read
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
    ' Name       : intEmpleadoId
    ' Description: Valor del Numero de Empleado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intEmpleadoId() As Integer
        Get
            Return CInt(Request.QueryString("intEmpleadoId"))
        End Get
        Set(ByVal intValue As Integer)
            intEmpleadoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intPuestoEmpleadoId
    ' Description: Numero del puesto del empleado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intPuestoEmpleadoId() As Integer
        Get
            Return intmPuestoEmpleadoId
        End Get
        Set(ByVal intValue As Integer)
            intmPuestoEmpleadoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpleadoPuesto
    ' Description: Nombre del puesto del empleado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEmpleadoPuesto() As String
        Get
            Return strmEmpleadoPuesto
        End Get
        Set(ByVal strValue As String)
            strmEmpleadoPuesto = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpleadoNombre
    ' Description: Nombre del empleado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEmpleadoNombre() As String
        Get
            Return strmEmpleadoNombre
        End Get
        Set(ByVal strValue As String)
            strmEmpleadoNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpleadoApellidoPaterno
    ' Description: Apellido paterno del empleado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEmpleadoApellidoPaterno() As String
        Get
            Return strmEmpleadoApellidoPaterno
        End Get
        Set(ByVal strValue As String)
            strmEmpleadoApellidoPaterno = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpleadoApellidoMaterno
    ' Description: Apellido materno del empleado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEmpleadoApellidoMaterno() As String
        Get
            Return strmEmpleadoApellidoMaterno
        End Get
        Set(ByVal strValue As String)
            strmEmpleadoApellidoMaterno = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpleadoGenero
    ' Description: Genero del empleado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Boolean
    '====================================================================
    Public Property strEmpleadoGenero() As String
        Get
            Return strmEmpleadoGenero
        End Get
        Set(ByVal strValue As String)
            strmEmpleadoGenero = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpleadoRFC
    ' Description: RFC del empleado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEmpleadoRFC() As String
        Get
            Return strmEmpleadoRFC
        End Get
        Set(ByVal strValue As String)
            strmEmpleadoRFC = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpleadoNumeroIMSS
    ' Description: Numero del Seguro Social del empleado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEmpleadoNumeroIMSS() As String
        Get
            Return strmEmpleadoNumeroIMSS
        End Get
        Set(ByVal strValue As String)
            strmEmpleadoNumeroIMSS = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpleadoCalle
    ' Description: Calle donde vive el empleado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEmpleadoCalle() As String
        Get
            Return strmEmpleadoCalle
        End Get
        Set(ByVal strValue As String)
            strmEmpleadoCalle = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpleadoNumeroExterior
    ' Description: Numero Exterior de la Casa del empleado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEmpleadoNumeroExterior() As String
        Get
            Return strmEmpleadoNumeroExterior
        End Get
        Set(ByVal strValue As String)
            strmEmpleadoNumeroExterior = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpleadoColonia
    ' Description: Colonia donde vive el empleado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEmpleadoColonia() As String
        Get
            Return strmEmpleadoColonia
        End Get
        Set(ByVal strValue As String)
            strmEmpleadoColonia = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpleadoNumeroInterior
    ' Description: Numero Interior de donde vive el empleado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEmpleadoNumeroInterior() As String
        Get
            Return strmEmpleadoNumeroInterior
        End Get
        Set(ByVal strValue As String)
            strmEmpleadoNumeroInterior = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpleadoCodigoPostal
    ' Description: Codigo Postal de la casa del empleado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEmpleadoCodigoPostal() As String
        Get
            Return strmEmpleadoCodigoPostal
        End Get
        Set(ByVal strValue As String)
            strmEmpleadoCodigoPostal = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpleadoEstado
    ' Description: Estado donde vive el empleado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEmpleadoEstado() As String
        Get
            Return strmEmpleadoEstado
        End Get
        Set(ByVal strValue As String)
            strmEmpleadoEstado = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpleadoCiudad
    ' Description: Ciudad donde vive el empleado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEmpleadoCiudad() As String
        Get
            Return strmEmpleadoCiudad
        End Get
        Set(ByVal strValue As String)
            strmEmpleadoCiudad = strValue
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Nos aseguramos que tengamos algún número de Empleado
        If Not intEmpleadoId > 0 Then
            Call Response.Redirect(strRedirectParentPage)
        End If

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strRedirectPage)
        End If

        Dim objArrayEmpleadoEmpleado As Array = Nothing
        Dim strDatosdeEmpleadoRegistro As String() = Nothing

        ' Obtenemos los Datos del empleado
        objArrayEmpleadoEmpleado = clsEmpleado.strBuscarFicha(intCompaniaId, intSucursalId, intEmpleadoId, strCadenaConexion)

        ' Validamos que los datos obtenidos sea un arreglo
        If IsArray(objArrayEmpleadoEmpleado) AndAlso objArrayEmpleadoEmpleado.Length > 0 Then

            ' Obtenemos los datos

            strDatosdeEmpleadoRegistro = DirectCast(objArrayEmpleadoEmpleado.GetValue(0), String())

            ' Apellido Paterno
            If Len(strDatosdeEmpleadoRegistro(0)) > 0 Then
                strEmpleadoApellidoPaterno = strDatosdeEmpleadoRegistro(0)
            Else
                strEmpleadoApellidoPaterno = ""
            End If

            ' Apellido Materno
            If Len(strDatosdeEmpleadoRegistro(1)) > 0 Then
                strEmpleadoApellidoMaterno = strDatosdeEmpleadoRegistro(1)
            Else
                strEmpleadoApellidoMaterno = ""
            End If

            ' Nombre del empleado
            If Len(strDatosdeEmpleadoRegistro(2)) > 0 Then
                strEmpleadoNombre = strDatosdeEmpleadoRegistro(2)
            Else
                strEmpleadoNombre = ""
            End If

            ' Genero del empleado
            If Not IsDBNull(strDatosdeEmpleadoRegistro(3)) Then
                If CBool(strDatosdeEmpleadoRegistro(3)) = True Then
                    strEmpleadoGenero = "Masculino"
                Else
                    strEmpleadoGenero = "Femenino"
                End If
            End If

            ' RFC del empleado
            If Len(strDatosdeEmpleadoRegistro(4)) > 0 Then
                strEmpleadoRFC = strDatosdeEmpleadoRegistro(4)
            Else
                strEmpleadoRFC = ""
            End If

            ' Numero del Seguro Social
            If Len(strDatosdeEmpleadoRegistro(5)) > 0 Then
                strEmpleadoNumeroIMSS = strDatosdeEmpleadoRegistro(5)
            Else
                strEmpleadoNumeroIMSS = ""
            End If

            ' Calle donde vive el empleado
            If Len(strDatosdeEmpleadoRegistro(6)) > 0 Then
                strEmpleadoCalle = strDatosdeEmpleadoRegistro(6)
            Else
                strEmpleadoCalle = ""
            End If

            ' Numero exterior de la casa del empleado
            If Len(strDatosdeEmpleadoRegistro(7)) > 0 Then
                strEmpleadoNumeroExterior = strDatosdeEmpleadoRegistro(7)
            Else
                strEmpleadoNumeroExterior = ""
            End If

            ' Numero interior de la casa del empleado
            If Len(strDatosdeEmpleadoRegistro(8)) > 0 Then
                strEmpleadoNumeroInterior = strDatosdeEmpleadoRegistro(8)
            Else
                strEmpleadoNumeroInterior = ""
            End If

            ' Colonia donde vive el empleado
            If Len(strDatosdeEmpleadoRegistro(9)) > 0 Then
                strEmpleadoColonia = strDatosdeEmpleadoRegistro(9)
            Else
                strEmpleadoColonia = ""
            End If

            ' Codigo Postal
            If Len(strDatosdeEmpleadoRegistro(10)) > 0 Then
                strEmpleadoCodigoPostal = strDatosdeEmpleadoRegistro(10)
            Else
                strEmpleadoCodigoPostal = ""
            End If

            ' Nombre del puesto del empleado
            If Len(strDatosdeEmpleadoRegistro(11)) > 0 Then
                intPuestoEmpleadoId = CInt(strDatosdeEmpleadoRegistro(11))
            Else
                intPuestoEmpleadoId = 0
            End If

            ' Nombre del puesto del empleado
            If Len(strDatosdeEmpleadoRegistro(12)) > 0 Then
                strEmpleadoPuesto = strDatosdeEmpleadoRegistro(12)
            Else
                strEmpleadoPuesto = ""
            End If

            ' Ciudad donde vive el empleado
            If Len(strDatosdeEmpleadoRegistro(13)) > 0 Then
                strEmpleadoCiudad = strDatosdeEmpleadoRegistro(13)
            Else
                strEmpleadoCiudad = ""
            End If

            ' Estado donde vive el empleado
            If Len(strDatosdeEmpleadoRegistro(14)) > 0 Then
                strEmpleadoEstado = strDatosdeEmpleadoRegistro(14)
            Else
                strEmpleadoEstado = ""
            End If

        End If

    End Sub

End Class
