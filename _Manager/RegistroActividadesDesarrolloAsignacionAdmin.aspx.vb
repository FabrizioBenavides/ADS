Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Benavides.POSAdmin.Commons.clsCommons.clsMSMQ
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports Isocraft.Web.Javascript
Imports System.Web.Caching

Public Class RegistroActividadesDesarrolloAdminActividades
    Inherits System.Web.UI.Page

    Private intActividadId As Integer
    Private intClasificacionId As Integer
    Dim strmTotalDePartidas As Integer

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

        intActividadId = GetPageParameter("cboActividad", 0)
        intClasificacionId = GetPageParameter("cboClasificacion", 0)

    End Sub

#End Region

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", String.Empty, Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strHTMLFechaHora
    ' Description: Genera la fecha y hora de la página
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
        End Get
    End Property

    '====================================================================
    ' Name       : intGrupoUsuarioId
    ' Description: Identificador del Grupo de Usuario
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intGrupoUsuarioId() As Integer
        Get
            Return CInt(Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strTipoUsuarioId
    ' Description: Tipo de usuario actual
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTipoUsuarioId() As Integer
        Get
            Return Benavides.CC.Data.clsControlDeAsistencia.intObtenerTipoUsuarioId(strUsuarioNombre, strConnectionString)
        End Get
    End Property

    '====================================================================
    ' Name       : strFormAction
    ' Description: HTML form's action property value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormAction() As String
        Get
            Return strThisPageName
        End Get
    End Property

    '====================================================================
    ' Name       : strConnectionString
    ' Description: Connection string
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Private ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: Name of this page
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request)
        End Get
    End Property

    '====================================================================
    ' Name       : LlenarComboClasificacion
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboDireccionOperativa
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarComboClasificacion() As String

        'Consultamos las direcciones operativas
        Dim astrRecords As Array
        astrRecords = Nothing

        astrRecords = Benavides.CC.Data.clsRegistroActividadesSistemas.strObtenerClasificacionActividades(strConnectionString)

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboClasificacion", intClasificacionId, astrRecords, 0, 1, 1)
        'Return Nothing
    End Function

    '====================================================================
    ' Name       : LlenarComboActividad
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboDireccionOperativa
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarComboActividad() As String

        If strCmd = "cmdConsultarActividad" Or strCmd = "cmdConsultarActividadAsignada" Then

            'Consultamos las direcciones operativas
            Dim astrRecords As Array
            astrRecords = Nothing

            'astrRecords = Benavides.CC.Data.clsRegistroActividadesSistemas.strObtenerActividadesSistemas(1, 1, strUsuarioNombre, strConnectionString)
            astrRecords = Benavides.CC.Data.clsRegistroActividadesSistemas.strObtenerActividadesSistemasParaAsignacion(1, -1, intClasificacionId, strUsuarioNombre, strConnectionString)

            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboActividad", intActividadId, astrRecords, 0, 1, 1)

        Else
            Return String.Empty
        End If

    End Function

    '====================================================================
    ' Name       : strTotalDePartidas
    ' Description: Numero de sucursales por "Asignar".
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strTotalDePartidas() As Integer
        Get
            Return strmTotalDePartidas
        End Get
        Set(ByVal strValue As Integer)
            strmTotalDePartidas = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return GetPageParameter("strCmd", String.Empty)
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Const strComitasDobles As String = """"

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If


        If (strCmd = "cmdAsignar") Then

            'Metodo que guarda los cambios
            If intAsignarActividad() > 0 Then
                'Call Response.Write("<script language='Javascript'>alert('La actividad se asigno correctamente.');</script>")
            Else
                'Call Response.Write("<script language='Javascript'>alert('No se pudo asignar la actividad.');</script>")
            End If

        End If
    End Sub


    Private Function intAsignarActividad() As Integer

        Dim chkCodigo As String
        Dim hdnAsignado As String
        Dim hdnEmpleadoId As String

        Dim intActividadesAsignadas As Integer
        Dim intActividadRechazadas As Integer
        intActividadesAsignadas = 0
        intActividadRechazadas = 0

        Dim strIdsRechazadas As String
        strIdsRechazadas = String.Empty

        Dim i, total As Integer
        total = CInt(Request.Form("strTotalDePartidas"))

        For i = 1 To total

            If (Len(Trim(Request("chkCodigo" & i.ToString))) > 0) Then
                chkCodigo = "1"
            Else
                chkCodigo = "0"
            End If

            hdnAsignado = (Request.Form("hdnAsignado" & i.ToString))
            hdnEmpleadoId = (Request.Form("hdnEmpleadoId" & i.ToString))

            If chkCodigo <> hdnAsignado Then

                If chkCodigo = "1" Then

                    '--------------
                    'Asignaciones
                    '--------------
                    If (Benavides.CC.Data.clsRegistroActividadesSistemas.intAsignarActividadSistemas(intActividadId, CInt(hdnEmpleadoId), strUsuarioNombre, strConnectionString) > 0) Then
                        intActividadesAsignadas = intActividadesAsignadas + 1
                    Else
                        intActividadRechazadas = intActividadRechazadas + 1

                        If strIdsRechazadas = String.Empty Then
                            strIdsRechazadas = strIdsRechazadas & hdnEmpleadoId
                        Else
                            strIdsRechazadas = strIdsRechazadas & "," & hdnEmpleadoId
                        End If

                    End If
                Else

                    '--------------
                    'Desasignaciones
                    '--------------
                    If (Benavides.CC.Data.clsRegistroActividadesSistemas.intDesAsignarActividadSistemas(intActividadId, CInt(hdnEmpleadoId), strUsuarioNombre, strConnectionString) > 0) Then
                        intActividadesAsignadas = intActividadesAsignadas + 1
                    Else
                        intActividadRechazadas = intActividadRechazadas + 1

                        If strIdsRechazadas = String.Empty Then
                            strIdsRechazadas = strIdsRechazadas & hdnEmpleadoId
                        Else
                            strIdsRechazadas = strIdsRechazadas & "," & hdnEmpleadoId
                        End If

                    End If
                End If

            End If

        Next

        If intActividadRechazadas > 0 Then
            Call Response.Write("<script language='Javascript'>alert('Favor de revisar. Algunos cambios no se pudieron guardar corectamente a los empleados: " & strIdsRechazadas & "');</script>")

        Else
            Call Response.Write("<script language='Javascript'>alert('Los cambios se guardaron correctamente.');</script>")
        End If


        Return 1


    End Function

    Public Function strTablaConsultaRecursos() As String

        Dim objArray As System.Array = Nothing
        Dim resultadoConsulta As String = String.Empty
        Dim strmRecordBrowserHTML As String = String.Empty

        If (strCmd = "cmdConsultarActividadAsignada") Or (strCmd = "cmdAsignar") Then



            If objArray Is Nothing Then
                Cache.Remove("cacheReporte")
                'objArray = Benavides.CC.Data.clsRegistroActividadesSistemas.strObtenerRecursoSistemas(11060293, intActividadId, strConnectionString)
                objArray = Benavides.CC.Data.clsRegistroActividadesSistemas.strObtenerRecursoSistemas(CInt(strUsuarioNombre), intActividadId, strConnectionString)

                '''NOTA''''
                ''' Todavia falta agregarle el usuario correvctamente para que busque los empleados del que esta logeado
                ''' Quitar el hard code del codigo de empleado del jefe


            End If

            Dim strResult As New StringBuilder()
            If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then

                'Detalle
                strResult.Append(strTablaConsultaRecursoSistemasHTML(objArray))

            Else
                'Tabla vacia sin resultados de consulta
                Call Response.Write("<script language='Javascript'>alert('No hay recursos disponibles');</script>")
            End If

            strResult.Append("<script language=""javascript"" type=""text/javascript"">")
            strResult.Append("parent.document.getElementById('tblRecursos').innerHTML = document.getElementById('divConsultaRecursos').innerHTML;")
            strResult.Append("</script>")

            Return strResult.ToString()
        End If

    End Function

    Public Function strTablaConsultaRecursoSistemasHTML(ByVal objConsultaRecursos As Array) As String

        Dim strTablaRecursosHTML As StringBuilder
        Dim strConsultaRecursos As String()

        Dim strColorRegistro As String
        Dim intContador As Integer

        Dim chkbox As String = Nothing
        Dim idName As String = Nothing
        Dim strAsignado As String
        Dim hdnAsignado As String = Nothing
        Dim hdnEmpleadoId As String = Nothing

        'Cantidad de Recursos
        strmTotalDePartidas = objConsultaRecursos.Length

        strTablaRecursosHTML = New StringBuilder

        strTablaRecursosHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Encabezados de Tabla de Resultados
        strTablaRecursosHTML.Append("<tr class='trtitulos'>")
        'strTablaRecursosHTML.Append("<th class='rayita' align='center' valign='top'> Seleccionar <br>" & chkbox & "Todos</th>")
        'strTablaRecursosHTML.Append("<th class='rayita' align='center' valign='top'>Seleccionar</th>")
        strTablaRecursosHTML.Append("<th class='rayita' align='left' valign='top'>No. Empleado</th>")
        strTablaRecursosHTML.Append("<th class='rayita' align='left' valign='top'>Recurso Sistemas</th>")
        strTablaRecursosHTML.Append("<th class='rayita' align='left' valign='top'>Jefatura</th>")
        strTablaRecursosHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For Each strConsultaRecursos In objConsultaRecursos
            intContador += 1

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            idName = "id=chkCodigo" & intContador.ToString() & " " & "name=chkCodigo" & intContador.ToString()

            If CInt(strConsultaRecursos(3)) = 0 Then
                chkbox = "<input type='checkbox'" & idName & " />"
                strAsignado = "0"
            Else
                chkbox = "<input type='checkbox'" & idName & " checked />"
                strAsignado = "1"
            End If

            strTablaRecursosHTML.Append("<tr>")
            ' No. Empleado
            strTablaRecursosHTML.Append("<td id='" & strConsultaRecursos(1) & "' align=left class=" & strColorRegistro & ">" & chkbox & strConsultaRecursos(1) & "</td>")
            ' Empleado
            strTablaRecursosHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRecursos(2)) & "</td>")
            ' Jefatura
            strTablaRecursosHTML.Append("<td align=left class=" & strColorRegistro & ">" & strConsultaRecursos(4) & "</td>")

            strTablaRecursosHTML.Append("</tr>")

            'Campos ocultos Valor que indica si es asignado y #Empleado 
            hdnAsignado = "<input type='hidden' id='hdnAsignado" & intContador.ToString() & "' name='hdnAsignado" & intContador.ToString() & "' value='" & strAsignado & "'>"
            hdnEmpleadoId = "<input type='hidden' id='hdnEmpleadoId" & intContador.ToString() & "' name='hdnEmpleadoId" & intContador.ToString() & "' value='" & strConsultaRecursos(1) & "'>"

            strTablaRecursosHTML.Append(hdnAsignado)
            strTablaRecursosHTML.Append(hdnEmpleadoId)
        Next

        strTablaRecursosHTML.Append("</tr>")
        strTablaRecursosHTML.Append("</table>")
        strTablaConsultaRecursoSistemasHTML = strTablaRecursosHTML.ToString

    End Function

End Class