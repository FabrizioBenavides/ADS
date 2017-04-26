Imports Benavides.POSAdmin.Commons
Imports Isocraft.Security
Imports Isocraft.Web.Http
Imports System.Text

Public Class ControlAsistenciaAdministracionSupervisoresMedicoAgregar
    Inherits PaginaBase

    ' Variables locales privadas
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private intmEmpleadoId As Integer
    Private intmGrupoUsuarioSeleccionadoId As Integer
    Private strmUsuarioContrasena As String
    Private dtmmUsuarioExpiracion As Date
    Private blnmUsuarioEstatus As Byte
    Private blnmUsuarioAlcance As Byte
    Private strmEmpleadoNombre As String
    Private strmSucursales As String
    Private intmCompaniaId As Integer
    Private intmSucursalId As Integer
    Private intDireccionOperativaId As Integer
    Private intmUsuarioId As Integer
    Private blnmUsuarioBloqueado As Byte
    Private intmUsuarioExistenteId As Integer

    '====================================================================
    ' Name       : intEmpleadoId
    ' Description: Obtiene o establece el empleado Id
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intEmpleadoId() As Integer
        Get
            Return intmEmpleadoId
        End Get
        Set(ByVal intValue As Integer)
            intmEmpleadoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intUsuarioId
    ' Description: Obtiene o establece el usuario Id
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intUsuarioId() As Integer
        Get
            Return intmUsuarioId
        End Get
        Set(ByVal intValue As Integer)
            intmUsuarioId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpleadoNombre
    ' Description: Obtiene o establece el nombre del empleado
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
    ' Name       : intGrupoUsuarioSeleccionadoId
    ' Description: Obtiene o establece el grupo usuario Id
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intGrupoUsuarioSeleccionadoId() As Integer
        Get
            Return intmGrupoUsuarioSeleccionadoId
        End Get
        Set(ByVal intValue As Integer)
            intmGrupoUsuarioSeleccionadoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strUsuarioContrasena
    ' Description: Obtiene o establece la contraseña del usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strUsuarioContrasena() As String
        Get
            Return strmUsuarioContrasena
        End Get
        Set(ByVal strValue As String)
            strmUsuarioContrasena = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : dtmUsuarioExpiracion
    ' Description: Obtiene o establece la fecha de expiracion del usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Date
    '====================================================================
    Public Property dtmUsuarioExpiracion() As Date
        Get

            Return dtmmUsuarioExpiracion

        End Get
        Set(ByVal dtmValue As Date)

            dtmmUsuarioExpiracion = dtmValue

        End Set
    End Property

    '====================================================================
    ' Name       : strFechaActual
    ' Description: Regresa la fecha actual
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFechaActual() As String
        Get
            Dim dtmFechaActual As Date

            dtmFechaActual = New Date(Date.Today.Year, Date.Today.Month, Date.Today.Day)

            Return dtmFechaActual.ToString("dd/MM/yyyy")
        End Get
    End Property

    '====================================================================
    ' Name       : blnUsuarioEstatus
    ' Description: Obtiene o establece el estatus del usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Byte
    '====================================================================
    Public Property blnUsuarioEstatus() As Byte

        Get

            Return blnmUsuarioEstatus

        End Get

        Set(ByVal blnValue As Byte)

            blnmUsuarioEstatus = blnValue

        End Set

    End Property

    '====================================================================
    ' Name       : blnUsuarioAlcance
    ' Description: Obtiene o establece el alcance del usuario
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Byte
    '====================================================================
    Public Property blnUsuarioAlcance() As Byte
        Get
            Return blnmUsuarioAlcance
        End Get
        Set(ByVal blnValue As Byte)
            blnmUsuarioAlcance = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : strSucursales
    ' Description: Listado de sucursales seleccionadas
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strSucursales() As String
        Get
            Return strmSucursales
        End Get
        Set(ByVal stValue As String)
            strmSucursales = stValue
        End Set
    End Property

    '====================================================================
    ' Name       : intCompaniaId 
    ' Description: Obtiene o establece el id de la Compañia
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intCompaniaId() As Integer
        Get
            Return intmCompaniaId
        End Get
        Set(ByVal intValue As Integer)
            intmCompaniaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intSucursalId 
    ' Description: Obtiene o establece el id de la Sucursal
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intSucursalId() As Integer
        Get
            Return intmSucursalId
        End Get
        Set(ByVal intValue As Integer)
            intmSucursalId = intValue
        End Set
    End Property

    ''' <summary>
    '''     Indica si el usuario está bloqueado
    ''' </summary>
    ''' <value>
    '''     <para>
    '''         0 Bloqueado, 1 No bloqueado
    '''     </para>
    ''' </value>
    ''' <remarks>
    '''     
    ''' </remarks>
    Public ReadOnly Property blnUsuarioBloqueado() As Byte
        Get
            Return blnmUsuarioBloqueado
        End Get
    End Property

    '====================================================================
    ' Name       : strLlenarGrupoComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboGrupo"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarGrupoComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboGrupoUsuario", _
                                                                          intGrupoUsuarioSeleccionadoId, _
                                                                          Benavides.CC.Data.clsControlDeAsistencia.strBuscarGrupoControlAsistencia(strConnectionString), 0, 1, 0)
    End Function

    '====================================================================
    ' Name       : intUsuarioExistenteId
    ' Description: Indica si el usuario existe
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intUsuarioExistenteId() As Integer
        Get
            Return intmUsuarioExistenteId
        End Get
        Set(ByVal intValue As Integer)
            intmUsuarioExistenteId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCmd 
    ' Description: Obtiene o establece el comando actual
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strCmd2() As String
        Get
            Return strmCommand
        End Get
        Set(ByVal strValue As String)
            strmCommand = strValue
        End Set
    End Property

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not strCmd2 = "Agregar" AndAlso intEmpleadoId = 0 Then
            'Call Response.Redirect("ControlAsistenciaAsignarSucursales.aspx")
        End If



    End Sub

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRecordBrowserHTML() As String
        Get
            Dim astrDataArray As Array = Nothing

            If (Request.QueryString("pager") = "true") Then
                If Not Cache("cacheSucursales") Is Nothing Then
                    astrDataArray = CType(Cache("cacheSucursales"), System.Array)
                End If
            End If

            If astrDataArray Is Nothing Then
                Cache.Remove("cacheSucursales")

                ' Verificar
                astrDataArray = Benavides.CC.Data.clsControlDeAsistencia.strObtenerSucursalesPorCoordinadorRH(intEmpleadoId, 0, 0, intUsuarioId, strConnectionString)
            End If

            If Not astrDataArray Is Nothing AndAlso IsArray(astrDataArray) AndAlso astrDataArray.Length > 0 Then

                Cache.Add("cacheSucursales", astrDataArray, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, Nothing)
                'Resultados en HTML
                Return strTablaConsultaSucursalesHTML(astrDataArray)
            End If

            ' Obtenemos el HTML
            Return String.Empty
        End Get
    End Property

    Public Function strTablaConsultaSucursalesHTML(ByVal objConsultaSucursales As Array) As String
        Dim strTablaSucursalesHTML As StringBuilder
        Dim strConsultaSucursalDetalle As String()
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim imgDesasignarSucursal As String = Nothing
        Dim intCompaniaId As Integer = -1
        Dim intSucursalId As Integer = -1

        Dim intPage As Integer
        Dim intTotal As Integer = 10

        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If

        strTablaSucursalesHTML = New StringBuilder
        strTablaSucursalesHTML.Append(Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objConsultaSucursales.Length, intPage, intTotal, String.Empty, Nothing))

        strTablaSucursalesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Encabezados de Tabla de Resultados
        strTablaSucursalesHTML.Append("<tr class='trtitulos'>")
        strTablaSucursalesHTML.Append("<th class='rayita' align='center' valign='top'>Compañia</th>")
        strTablaSucursalesHTML.Append("<th class='rayita' align='center' valign='top'>Sucursal</th>")
        strTablaSucursalesHTML.Append("<th class='rayita' align='center' valign='top'>Nombre</th>")
        strTablaSucursalesHTML.Append("<th class='rayita' align='center' valign='top'>Acción</th>")
        strTablaSucursalesHTML.Append("</tr>")

        intContador = 0

        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaSucursales.Length) Then
                Exit For
            End If

            strConsultaSucursalDetalle = CType(objConsultaSucursales.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            If Not strConsultaSucursalDetalle(0).ToString = "NA" Then
                intCompaniaId = CInt(strConsultaSucursalDetalle(0))
            End If

            If Not strConsultaSucursalDetalle(1).ToString = "NA" Then
                intSucursalId = CInt(strConsultaSucursalDetalle(1))
            End If

            imgDesasignarSucursal = "<img height='17' src='../static/images/imgNRDesasignar.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdDesasignarSucursal_onclick(" & intCompaniaId.ToString & "," & intSucursalId.ToString & "," & strConsultaSucursalDetalle(7) & "," & strConsultaSucursalDetalle(2) & "," & strConsultaSucursalDetalle(8) & ")' alt='Haga clic aquí para cambiar el estatus del usuario'>"

            strTablaSucursalesHTML.Append("<tr>")
            ' Compania
            strTablaSucursalesHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaSucursalDetalle(0)) & "</td>")
            ' Sucursal
            strTablaSucursalesHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaSucursalDetalle(1)) & "</td>")
            ' Nombre
            strTablaSucursalesHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaSucursalDetalle(6)) & "</td>")
            'Accion 
            strTablaSucursalesHTML.Append("<td align=center class=" & strColorRegistro & ">" & imgDesasignarSucursal & "</td>")
            strTablaSucursalesHTML.Append("</tr>")
        Next

        strTablaSucursalesHTML.Append("</tr>")
        strTablaSucursalesHTML.Append("</table>")
        strTablaConsultaSucursalesHTML = strTablaSucursalesHTML.ToString
    End Function



End Class