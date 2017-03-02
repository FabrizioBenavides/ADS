Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration
Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

Public Class ControlCaducidadArticulos
    Inherits System.Web.UI.Page

    Const strComitasDobles As String = """"
    Dim strmFolioId As String
    Private intResultado As Integer = 0

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

        'Folio para agregar articulos.
        strmFolioId = GetPageParameter("txtFolioId", 0).ToString()

    End Sub

#End Region

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
    ' Name       : strCentroLogisticoId
    ' Description: Valor de la Compañia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCentroLogisticoId() As String
        Get
            Return (clsCommons.strReadCookie("strCentroLogisticoId", "", Request, Server))
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
    ' Name       : strCmd
    ' Description: Comando a ejecutar
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Not IsNothing(Request.QueryString("strCmd")) Then
                Return (Request.QueryString("strCmd"))
            Else
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strFolioId
    ' Description: Ruta de la imagen
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strFolioId() As String
        Get
            Return strmFolioId
        End Get
        Set(ByVal Value As String)
            strmFolioId = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strArticuloCapturado
    ' Description: Cadena para buscar el numero de artículo 
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strArticuloCapturado() As String
        Get
            If Not IsNothing(Request("txtArticuloId")) Then
                Return Request("txtArticuloId")
            Else
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strExistenciaArticuloCapturado
    ' Description: Cadena para buscar la cantidad en existencia del artículo 
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strExistenciaArticuloCapturado() As String
        Get
            If Not IsNothing(Request("txtExistencia")) Then
                Return Request("txtExistencia")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strArticuloPorEliminar
    ' Description: Articulo que se eliminara de la lista (Tabla de paso)
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strArticuloPorEliminar() As String
        Get
            If Not IsNothing(Request.QueryString("strArticuloPorEliminar")) Then
                Return Request.QueryString("strArticuloPorEliminar")
            Else
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmCaducidadArticuloPorEliminar
    ' Description: Regresa la fecha de caducidad del artículo  por eliminar
    '            : de la tabla de paso (el ultimo dia del mes seleccionado)
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmCaducidadArticuloPorEliminar() As Date
        Get
            If Not IsNothing(Request.QueryString("strCaducidadMesId")) Then

                Dim dtmFechaFinal As Date
                Dim dtmMes As Integer = CInt(Request.QueryString("strCaducidadMesId"))

                dtmFechaFinal = New Date(Date.Today.Year, dtmMes, 1)
                dtmFechaFinal = dtmFechaFinal.AddMonths(1)
                dtmFechaFinal = dtmFechaFinal.AddDays(-1)

                Return dtmFechaFinal
            Else
                Return CDate(DateTime.Now)
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmLastDayOfMonth
    ' Description: Regresa la fecha de caducida (el ultimo dia del mes seleccionado)
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmLastDayOfMonth() As Date
        Get
            If Not IsNothing(Request.Form("txtIdMes")) Then

                Dim dtmFechaFinal As Date
                Dim dtmMes As Integer = CInt(Request.Form("txtIdMes"))

                dtmFechaFinal = New Date(Date.Today.Year, dtmMes, 1)
                dtmFechaFinal = dtmFechaFinal.AddMonths(1)
                dtmFechaFinal = dtmFechaFinal.AddDays(-1)

                Return dtmFechaFinal
            Else
                Return CDate(DateTime.Now)
            End If
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        Dim strHTML As StringBuilder = Nothing
        Dim objArray As Array = Nothing
        Dim strRegistro As String() = Nothing
        Dim strAccion As String = String.Empty
        Dim strResultadoAccion As String = String.Empty
        Dim strListadoInventario As String = String.Empty
        Dim intArticuloBuscadoId As Integer = 0
        Dim strArticuloBuscadoDescripcion As String = String.Empty

        If strCmd.Trim() = "BuscarArticulo" Then


            strHTML = New StringBuilder
            strAccion = "0"  ' BUSCAR ARTICULO
            strResultadoAccion = String.Empty
            strListadoInventario = String.Empty

            ' Obtenemos la información del Articulo
            objArray = clsConcentrador.clsSucursal.strBuscarArticulo(intCompaniaId, intSucursalId, strArticuloCapturado, 1, 1, strCadenaConexion)

            If IsArray(objArray) AndAlso objArray.Length > 0 Then
                strRegistro = DirectCast(objArray.GetValue(0), String())

                intArticuloBuscadoId = CInt(strRegistro(0))
                strArticuloBuscadoDescripcion = clsCommons.strFormatearDescripcion(strRegistro(5))
                strResultadoAccion = "1"
            Else
                intArticuloBuscadoId = 0
                strArticuloBuscadoDescripcion = String.Empty
                strResultadoAccion = "-100"
            End If

            If Len(strCmd) > 0 Then

                strHTML.Append("<script language='Javascript'> parent.fnUpAccionInventarios( " & _
                               strComitasDobles & strAccion & strComitasDobles & "," & _
                               strComitasDobles & intArticuloBuscadoId.ToString & strComitasDobles & "," & _
                               strComitasDobles & strArticuloBuscadoDescripcion & strComitasDobles & "," & _
                               strComitasDobles & strResultadoAccion & strComitasDobles & _
                              "); </script>")

                Response.Write(strHTML.ToString)

                Response.End()

            End If
        ElseIf strCmd.Trim() = "cmdAgregar" Then
            Try

                intResultado = Benavides.CC.Data.clsCaducidadArticulos.intAgregarCaducidadArticulo(CInt(strmFolioId), intCompaniaId, intSucursalId, CInt(strArticuloCapturado), CInt(strExistenciaArticuloCapturado), dtmLastDayOfMonth, strUsuarioNombre, strCadenaConexion)

                If intResultado > 0 Then
                    strmFolioId = intResultado.ToString()
                ElseIf intResultado = 0 Then
                    Call Response.Write("<script language='Javascript'>alert('La información ya existe y no se puede duplicar');</script>")
                End If
            Catch ex As Exception
                Call Response.Write("<script language='Javascript'>alert('Ocurrió un error al intentar agregar el artículo ');</script>")
            End Try
        ElseIf strCmd.Trim() = "cmdGuardar" Then
            Try
                intResultado = Benavides.CC.Data.clsCaducidadArticulos.intGuardarCaducidadArticulo(CInt(strmFolioId), intCompaniaId, intSucursalId, strUsuarioNombre, strCadenaConexion)

                If intResultado > 0 Then
                    Call Response.Write("<script language='Javascript'>alert('La información se guardó con exito');</script>")
                End If
            Catch ex As Exception
                Call Response.Write("<script language='Javascript'>alert('Ocurrió un error al intentar guardar la información');</script>")
            End Try
        ElseIf strCmd.Trim() = "cmdEliminar" Then
            Try
                intResultado = Benavides.CC.Data.clsCaducidadArticulos.strEliminarCaducidadAgregar(CInt(strmFolioId), intCompaniaId, intSucursalId, CInt(strArticuloPorEliminar), dtmCaducidadArticuloPorEliminar, strUsuarioNombre, strCadenaConexion)
            Catch ex As Exception
                Call Response.Write("<script language='Javascript'>alert('Ocurrió un error al intentar eliminar el artículo ');</script>")
            End Try
        ElseIf strCmd.Trim() = "cmdEliminarLista" Then
            Try
                Benavides.CC.Data.clsCaducidadArticulos.strEliminarListado(CInt(strmFolioId), intCompaniaId, intSucursalId, strCadenaConexion)
            Catch ex As Exception
                Call Response.Write("<script language='Javascript'>alert('Ocurrió un error al intentar limpiar los campos');</script>")
            End Try
        End If
    End Sub

#Region "Listado de articulos"
    Public Function strTablaArticulosPorAgregar() As String
        Dim objArray As System.Array = Nothing

        If Not IsNothing(strmFolioId) AndAlso CInt(strmFolioId) > 0 Then

            objArray = Benavides.CC.Data.clsCaducidadArticulos.strBuscarCaducidadArticulosAgregados(CInt(strmFolioId), intCompaniaId, intSucursalId, strUsuarioNombre, strCadenaConexion)

            Dim strResult As New StringBuilder()
            If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then
                strResult.Append(strTablaArticulosPorAgregarHTML(objArray))
            Else
                strResult.Append(String.Empty)
            End If

            strResult.Append("<script language=""javascript"" type=""text/javascript"">")
            strResult.Append("parent.document.getElementById('tblResultados').innerHTML = document.getElementById('divListaArticulos').innerHTML;")
            strResult.Append("</script>")

            Return strResult.ToString()
        End If

        Return String.Empty
    End Function

    Public Function strTablaArticulosPorAgregarHTML(ByVal objConsultaCaducidadArticulosAgregados As Array) As String

        Dim strTablaArticulosAgregadosHTML As StringBuilder
        Dim strConsultaArticulo As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim imgEliminar As String = Nothing
        Dim intPage As Integer
        Dim intTotal As Integer = 100

        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If

        strTablaArticulosAgregadosHTML = New StringBuilder

        strTablaArticulosAgregadosHTML.Append("<table border='0' cellpadding='0' cellspacing='0' style='width:100%;'>")
        strTablaArticulosAgregadosHTML.Append("<tr class='trtitulos'>")
        strTablaArticulosAgregadosHTML.Append("<th width='15%' align=center class='rayita' align='left' valign='top'>Código</th>")
        strTablaArticulosAgregadosHTML.Append("<th width='45%' align=center class='rayita' align='left' valign='top'>Descripción</th>")
        strTablaArticulosAgregadosHTML.Append("<th width='15%' align=center class='rayita' align='left' valign='top'>Existencia</th>")
        strTablaArticulosAgregadosHTML.Append("<th width='15%' align=center class='rayita' align='left' valign='top'>Caducidad</th>")
        strTablaArticulosAgregadosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Acción</th>")
        strTablaArticulosAgregadosHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaCaducidadArticulosAgregados.Length) Then
                Exit For
            End If

            strConsultaArticulo = CType(objConsultaCaducidadArticulosAgregados.GetValue(intContador), String())

            'Clase para color de renglon.
            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            imgEliminar = "<img id='Eli' height='17' src='../static/images/imgNREliminar.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdEliminarArticulo_onclick(" & strConsultaArticulo(0) & "," & strConsultaArticulo(3) & ")' alt='Eliminar'>"

            strTablaArticulosAgregadosHTML.Append("<tr>")

            'Código
            strTablaArticulosAgregadosHTML.Append("<td width='10%' class=" & strColorRegistro & ">" & strConsultaArticulo(0) & "</td>")
            'Descripción
            strTablaArticulosAgregadosHTML.Append("<td width='10%' id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & strConsultaArticulo(1) & "</td>")
            'Existencia               
            strTablaArticulosAgregadosHTML.Append("<td width='12%' class=" & strColorRegistro & " align='center'>" & strConsultaArticulo(2) & "</td>")
            'Mes de Caducidad
            strTablaArticulosAgregadosHTML.Append("<td width='10%' class=" & strColorRegistro & " align='center'>" & strConsultaArticulo(4) & "</td>")
            'Acción                    
            strTablaArticulosAgregadosHTML.Append("<td width='10%' class=" & strColorRegistro & " align='center'>" & imgEliminar & "</td>")
            strTablaArticulosAgregadosHTML.Append("</tr>")

            strTablaArticulosAgregadosHTML.Append("<tr>")

        Next
        strTablaArticulosAgregadosHTML.Append("</tr>")
        strTablaArticulosAgregadosHTML.Append("</table>")
        strTablaArticulosAgregadosHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaArticulosPorAgregarHTML = strTablaArticulosAgregadosHTML.ToString
    End Function
#End Region
End Class