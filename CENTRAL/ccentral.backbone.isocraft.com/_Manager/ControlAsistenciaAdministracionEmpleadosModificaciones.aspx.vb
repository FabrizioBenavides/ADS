Imports System.Text
Imports Benavides.POSAdmin.Commons



Public Class ControlAsistenciaAdministracionEmpleadosModificaciones
    Inherits System.Web.UI.Page

    Dim strmGrupoDescripcion As String

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

    Dim objResultArray As Array
    Dim objEmpleadoArray As Array
    Dim objVacacionesArray, objIncapacidadMedicaArray, objPermisoEspecialArray As Array
    Dim resultArray As Array
    Dim strResultArray As String
    Dim strHtmlCode As StringBuilder
    Public strmMensaje As String

    '====================================================================
    ' Name       : strRedirectPage
    ' Description: Página hacia la cual se debe redireccionar al usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRedirectPage() As String
        Get
            Return "/Default.aspx?strURL=" & Server.UrlEncode(Request.ServerVariables("SCRIPT_NAME"))
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
    ' Name       : strMensaje
    ' Description: Valor para mostrar como mensaje
    ' Accessor   : Read and Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strMensaje() As String
        Get
            If IsNothing(strmMensaje) Then
                Return ""
            Else
                Return strmMensaje
            End If
        End Get
        Set(ByVal Value As String)
            strmMensaje = Value
        End Set
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
    ' Name       : strGrupoDescripcion
    ' Description: Coomando seleccionado
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strGrupoDescripcion() As String
        Get
            Return strmGrupoDescripcion
        End Get
        Set(ByVal strValue As String)
            strmGrupoDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strDiadeDescanso
    ' Description: Regresa un entero que indica cual es el dia de descanso
    ' Creador    : Jesus M. Gil 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strDiadeDescanso() As String

        Get
            Dim strSucursalEmpleadoRol As String()
            Dim blnEsGodinez As Boolean = False
            Dim objArrayEmpleadoRol As Array = Nothing
            Dim intDia As String = Convert.ToString(DirectCast(resultArray.GetValue(1), String))

            'Obtenemos el grupo al que pertenece para saber si es de Empleado Oficina
            objArrayEmpleadoRol = Business.clsSucursal.clsEmpleado.strBuscar(intCompaniaId, intSucursalId, intEmpleadoId, False, strCadenaConexion)

            If IsArray(objArrayEmpleadoRol) AndAlso objArrayEmpleadoRol.Length > 0 Then

                strSucursalEmpleadoRol = DirectCast(objArrayEmpleadoRol.GetValue(0), String())

                If Len(strSucursalEmpleadoRol(11)) > 0 Then

                    strmGrupoDescripcion = strSucursalEmpleadoRol(11).ToString().Trim()

                    If strmGrupoDescripcion = "ADMINISTRATIVO" Then
                        blnEsGodinez = True
                    End If

                End If
            End If

            strHtmlCode = New StringBuilder
            strHtmlCode.Append("<SELECT class='campotabla' id='cmdDiaDescanso' onChange='cambioDiaDescanso()' style='width:150'>")

            If ((intDia <> "1") And (intDia <> "2") And (intDia <> "3") And (intDia <> "4") And (intDia <> "5") And (intDia <> "6") And (intDia <> "7")) Then
                strHtmlCode.Append("<OPTION value='0' selected></OPTION>")
                strHtmlCode.Append("<OPTION value='1'>Domingo</OPTION>")
                strHtmlCode.Append("<OPTION value='2'>Lunes</OPTION>")
                strHtmlCode.Append("<OPTION value='3'>Martes</OPTION>")
                strHtmlCode.Append("<OPTION value='4'>Miercoles</OPTION>")
                strHtmlCode.Append("<OPTION value='5'>Jueves</OPTION>")
                strHtmlCode.Append("<OPTION value='6'>Viernes</OPTION>")
                strHtmlCode.Append("<OPTION value='7'>Sabado</OPTION>")

            End If

            If (intDia = "1") Then
                strHtmlCode.Append("<OPTION value='1' selected>Domingo</OPTION>")
                strHtmlCode.Append("<OPTION value='2'>Lunes</OPTION>")
                strHtmlCode.Append("<OPTION value='3'>Martes</OPTION>")
                strHtmlCode.Append("<OPTION value='4'>Miercoles</OPTION>")
                strHtmlCode.Append("<OPTION value='5'>Jueves</OPTION>")
                strHtmlCode.Append("<OPTION value='6'>Viernes</OPTION>")
                strHtmlCode.Append("<OPTION value='7'>Sabado</OPTION>")
            End If

            If (intDia = "2") Then
                strHtmlCode.Append("<OPTION value='1'>Domingo</OPTION>")
                strHtmlCode.Append("<OPTION value='2' selected>Lunes</OPTION>")
                strHtmlCode.Append("<OPTION value='3'>Martes</OPTION>")
                strHtmlCode.Append("<OPTION value='4'>Miercoles</OPTION>")
                strHtmlCode.Append("<OPTION value='5'>Jueves</OPTION>")
                strHtmlCode.Append("<OPTION value='6'>Viernes</OPTION>")
                strHtmlCode.Append("<OPTION value='7'>Sabado</OPTION>")

            End If

            If (intDia = "3") Then
                strHtmlCode.Append("<OPTION value='1'>Domingo</OPTION>")
                strHtmlCode.Append("<OPTION value='2'>Lunes</OPTION>")
                strHtmlCode.Append("<OPTION value='3' selected>Martes</OPTION>")
                strHtmlCode.Append("<OPTION value='4'>Miercoles</OPTION>")
                strHtmlCode.Append("<OPTION value='5'>Jueves</OPTION>")
                strHtmlCode.Append("<OPTION value='6'>Viernes</OPTION>")
                strHtmlCode.Append("<OPTION value='7'>Sabado</OPTION>")

            End If

            If (intDia = "4") Then
                strHtmlCode.Append("<OPTION value='1'>Domingo</OPTION>")
                strHtmlCode.Append("<OPTION value='2'>Lunes</OPTION>")
                strHtmlCode.Append("<OPTION value='3'>Martes</OPTION>")
                strHtmlCode.Append("<OPTION value='4' selected>Miercoles</OPTION>")
                strHtmlCode.Append("<OPTION value='5'>Jueves</OPTION>")
                strHtmlCode.Append("<OPTION value='6'>Viernes</OPTION>")
                strHtmlCode.Append("<OPTION value='7'>Sabado</OPTION>")

            End If

            If (intDia = "5") Then
                strHtmlCode.Append("<OPTION value='1'>Domingo</OPTION>")
                strHtmlCode.Append("<OPTION value='2'>Lunes</OPTION>")
                strHtmlCode.Append("<OPTION value='3'>Martes</OPTION>")
                strHtmlCode.Append("<OPTION value='4'>Miercoles</OPTION>")
                strHtmlCode.Append("<OPTION value='5' selected>Jueves</OPTION>")
                strHtmlCode.Append("<OPTION value='6'>Viernes</OPTION>")
                strHtmlCode.Append("<OPTION value='7'>Sabado</OPTION>")

            End If

            If (intDia = "6") Then
                strHtmlCode.Append("<OPTION value='1'>Domingo</OPTION>")
                strHtmlCode.Append("<OPTION value='2'>Lunes</OPTION>")
                strHtmlCode.Append("<OPTION value='3'>Martes</OPTION>")
                strHtmlCode.Append("<OPTION value='4'>Miercoles</OPTION>")
                strHtmlCode.Append("<OPTION value='5'>Jueves</OPTION>")
                strHtmlCode.Append("<OPTION value='6' selected>Viernes</OPTION>")
                strHtmlCode.Append("<OPTION value='7'>Sabado</OPTION>")

            End If

            If (intDia = "7") Then
                strHtmlCode.Append("<OPTION value='1'>Domingo</OPTION>")
                strHtmlCode.Append("<OPTION value='2'>Lunes</OPTION>")
                strHtmlCode.Append("<OPTION value='3'>Martes</OPTION>")
                strHtmlCode.Append("<OPTION value='4'>Miercoles</OPTION>")
                strHtmlCode.Append("<OPTION value='5'>Jueves</OPTION>")
                strHtmlCode.Append("<OPTION value='6'>Viernes</OPTION>")
                strHtmlCode.Append("<OPTION value='7' selected>Sabado</OPTION>")

            End If

            Return strHtmlCode.ToString()
        End Get
    End Property









    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class