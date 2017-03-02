
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
Imports System.IO
Imports System.Web.Caching


Public Class SucursalControlDePagaresAlta
    Inherits System.Web.UI.Page

    'Variables para guardar datos de solicitud
    Private intmSolicitudPagareId As Integer
    Private strmAfiliacionId As Integer
    Private intmAutorizacionId As Integer
    Private fltmImporte As Decimal
    Private dtmmFechaPagare As Date

    Private astrRecords As Array
    Dim strmRecordBrowserHTML As String
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

        intmSolicitudPagareId = GetPageParameter("intSolicitudPagareId", 0)
        strmAfiliacionId = CInt(Request.Form("txtAfiliacionId"))
        intmAutorizacionId = GetPageParameter("txtAutorizacion", 0)

        If Trim(Request.Form("txtImporte")) <> String.Empty Then
            fltmImporte = CDec(Request.Form("txtImporte"))
        Else
            fltmImporte = 0
        End If

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
    ' Name       : intSolicitudPagareId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intSolicitudPagareId() As Integer
        Get
            If Not (Request.QueryString("intSolicitudPagareId") = Nothing) Then
                Return CInt(Request.QueryString("intSolicitudPagareId"))
            Else
                Return intmSolicitudPagareId
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strAfiliacionId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strAfiliacionId() As String
        Get
            Return strmAfiliacionId.ToString()
        End Get
    End Property

    '===============================s=====================================
    ' Name       : intAutorizacionId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intAutorizacionId() As Integer
        Get
            Return intmAutorizacionId
        End Get
    End Property

    '====================================================================
    ' Name       : fltImporte
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property fltImporte() As Decimal
        Get
            If fltmImporte > 0 Then
                Return fltmImporte
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strFirstDayOfMonth
    ' Description: Regresa el primer dia del mes actual
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFirstDayOfMonth() As String
        Get
            If IsNothing(Request.Form("dtmFechaPagare")) Then
                Return New Date(Date.Today.Year, Date.Today.Month, 1).ToString("dd/MM/yyyy")
            Else
                Return Request.Form("dtmFechaPagare")
            End If
        End Get
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
            If IsNothing(Request.Form("dtmFechaFin")) Then
                Dim dtmFechaActual As Date

                dtmFechaActual = New Date(Date.Today.Year, Date.Today.Month, Date.Today.Day)

                Return dtmFechaActual.ToString("dd/MM/yyyy")
            Else
                Return Request.Form("dtmFechaFin")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaPagare
    ' Description: Fecha de inicio a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaPagare() As Date
        Get
            Dim f As String = Request.Form("dtmFechaPagare")
            If Not IsNothing(f) Then
                Dim fp As String() = f.Split("/".ToCharArray())

                Return New Date(CInt(fp(2)), CInt(fp(1)), CInt(fp(0)))
            Else
                Return CDate("01/01/1900")
            End If
        End Get
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

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Dim strRecordBrowserImpresion As String = String.Empty
        Const strComitasDobles As String = """"
        Dim strHTML As New StringBuilder
        Dim objDataArrayPromociones As Array = Nothing

        If (strCmd = "cmdEliminar") Then

            'Rutina que elimina la solicitud del pagare
            subEliminarSolicitudPagare()

        ElseIf (strCmd = "cmdGuardar") Then

            'Rutina para guardar solicitud
            subGuardarSolicitudPagare()
        End If
    End Sub

    Private Sub subGuardarSolicitudPagare()
        Try

            Dim intResultadoGuardar As Integer

            intResultadoGuardar = Benavides.CC.Data.clsControlPagares.intGuardarSolicitudPagare(intSolicitudPagareId, strAfiliacionId, intAutorizacionId, fltImporte, dtmFechaPagare, strUsuarioNombre, strConnectionString)

            If intResultadoGuardar > 0 Then

                If Not intSolicitudPagareId > 0 Then
                    intmSolicitudPagareId = intResultadoGuardar
                End If

                If intResultadoGuardar > 0 Then
                    Call Response.Write("<script language='Javascript'>alert('Se guardaron correctamente los cambios.');</script>")
                Else
                    Call Response.Write("<script language='Javascript'>alert('No se pudieron guardar los cambios.');</script>")
                End If
            End If

        Catch ex As Exception
            Call Response.Write("<script language='Javascript'>alert('Ocurrio un error al intentar guardar los cambios.');</script>")
        End Try
    End Sub

    Private Sub subEliminarSolicitudPagare()
        Try

            Dim intResultadoEliminar As Integer

            intResultadoEliminar = Benavides.CC.Data.clsControlPagares.intEliminarSolicitudPagare(intSolicitudPagareId, strConnectionString)

            'Mensajes al usuario.
            If intResultadoEliminar > 0 Then

                intmSolicitudPagareId = 0
                Call Response.Write("<script language='Javascript'>alert('La solicitud se elimino correctamente.');</script>")
            Else
                Call Response.Write("<script language='Javascript'>alert('No se pudo eliminar la solicitud.');</script>")
            End If


        Catch ex As Exception
            Call Response.Write("<script language='Javascript'>alert('Ocurrio un error al intentar eliminar la solicitud.');</script>")
        End Try
    End Sub

    Public Function strTablaConsultaPagare() As String

        Dim objArray As System.Array = Nothing
        Dim strResult As New StringBuilder()
        Dim strmRecordBrowserHTML As String = String.Empty
        Dim _dtmFechaPagare As Date

        If intSolicitudPagareId > 0 AndAlso strCmd <> "cmdEliminar" Then

            'Pagare
            objArray = Benavides.CC.Data.clsControlPagares.strObtenerSolicitudPagare(intSolicitudPagareId, strConnectionString)


            If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then

                strmAfiliacionId = CInt(CType(objArray.GetValue(0), Array).GetValue(2))
                intmAutorizacionId = CInt(CType(objArray.GetValue(0), Array).GetValue(3))
                fltmImporte = CDec(CType(objArray.GetValue(0), Array).GetValue(4))
                _dtmFechaPagare = CDate(CType(objArray.GetValue(0), Array).GetValue(5))

                'Tabla de Resultados
                strResult.Append(strTablaConsultaPagareHTML(objArray))

                'Valores de cajas de texto.
                strResult.Append("<script language=""javascript"" type=""text/javascript"">")
                strResult.Append("parent.document.getElementById('tblResultados').innerHTML = document.getElementById('divConsultaPromociones').innerHTML;")
                strResult.Append("parent.document.getElementById('txtAfiliacionId').value = " & strmAfiliacionId & ";")
                strResult.AppendFormat("parent.document.getElementById('txtDescripcionSucursalPagare').value = '{0}';", CType(objArray.GetValue(0), Array).GetValue(1))
                strResult.Append("parent.document.getElementById('txtAutorizacion').value = " & intmAutorizacionId.ToString() & ";")
                strResult.Append("parent.document.getElementById('txtImporte').value = " & fltmImporte.ToString() & ";")
                strResult.Append("parent.document.getElementById('dtmFechaPagare').value = '" & clsCommons.strFormatearFechaPresentacion(_dtmFechaPagare.ToString()) & "';")

            Else

                'Valores de cajas de texto.
                strResult.Append("<script language=""javascript"" type=""text/javascript"">")
                strResult.Append("parent.document.getElementById('tblResultados').innerHTML = document.getElementById('divConsultaPromociones').innerHTML;")
                strResult.Append("parent.document.getElementById('txtAfiliacionId').value = '';")
                strResult.AppendFormat("parent.document.getElementById('txtDescripcionSucursalPagare').value = '{0}';", String.Empty)
                strResult.Append("parent.document.getElementById('txtAutorizacion').value = '';")
                strResult.Append("parent.document.getElementById('txtImporte').value = '';")
                strResult.Append("parent.document.getElementById('dtmFechaPagare').value = '';")
            End If


            strResult.Append("</script>")

            Return strResult.ToString()
        End If

        Return String.Empty

    End Function

    Public Function strTablaConsultaPagareHTML(ByVal objConsultaRegistro As Array) As String

        Dim strTablaDetalleHTML As StringBuilder
        Dim strConsultaRegistroDetalle As String()
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim imgEliminarPagare As String = Nothing
        Dim imgDetalleSucursales As String = String.Empty
        Dim strFechaConfirmacionEnvio As String = "&nbsp;"

        Dim intPage As Integer
        Dim intTotal As Integer = 500

        intPage = 1

        strTablaDetalleHTML = New StringBuilder

        strTablaDetalleHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Encabezados de Tabla de Resultados
        strTablaDetalleHTML.Append("<tr class='trtitulos'>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Sucursal</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Afiliación</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Autorización</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Importe</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Fecha <br> Pagare</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Fecha <br> Solicitud</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Fecha <br> Confirmacion <br> Envio</th>")
        strTablaDetalleHTML.Append("<th class='rayita' align='center' valign='top'>Acción</th>")
        strTablaDetalleHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaRegistro.Length) Then
                Exit For
            End If

            strConsultaRegistroDetalle = CType(objConsultaRegistro.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            If CBool(strConsultaRegistroDetalle(6)) = True Then
                strFechaConfirmacionEnvio = clsCommons.strFormatearFechaPresentacion(strConsultaRegistroDetalle(7))
            End If

            'Botones "Ver Detalle" (Articulos/Sucursal).
            imgEliminarPagare = "<img id=" & strConsultaRegistroDetalle(0) & " height='17' src='../static/images/icono_borrar.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdEliminar_onclick(this.id)' alt='Eliminar'>"

            strTablaDetalleHTML.Append("<tr>")
            ' Sucursal
            strTablaDetalleHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroDetalle(1)) & "</td>")
            ' Afiliación
            strTablaDetalleHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroDetalle(2)) & "</td>")
            ' Autorización
            strTablaDetalleHTML.Append("<td id=Division" & intContador & " align=center class=" & strColorRegistro & ">" & strConsultaRegistroDetalle(3) & "</td>")
            ' Importe
            strTablaDetalleHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaRegistroDetalle(4)) & "</td>")
            ' Fecha <br> Pagare
            strTablaDetalleHTML.Append("<td align=left class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaRegistroDetalle(5)) & "</td>")
            ' Fecha <br> Solicitud
            strTablaDetalleHTML.Append("<td align=center class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaRegistroDetalle(8)) & "</td>")
            ' Fecha <br> Confirmacion <br> Envio
            strTablaDetalleHTML.Append("<td align=center class=" & strColorRegistro & " title='" & strConsultaRegistroDetalle(8) & "'>" & strFechaConfirmacionEnvio & "</td>")
            'Accion 
            strTablaDetalleHTML.Append("<td align=center class=" & strColorRegistro & ">" & imgEliminarPagare & "</td>")
            strTablaDetalleHTML.Append("</tr>")
        Next

        strTablaDetalleHTML.Append("</tr>")
        strTablaDetalleHTML.Append("</table>")
        'strTablaDetalleHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaPagareHTML = strTablaDetalleHTML.ToString

    End Function

#Region "Pop's"

    'Funcion que busca la Promocion por Codigo y muestra su descripcion para realizar una busqueda.
    Public Function strTablaConsultaCodigoSucursal() As String

        strmRecordBrowserHTML = String.Empty

        If (Request.QueryString("strCmd") = "BuscarSucursalPagare") Then

            Dim objArray As System.Array = Benavides.CC.Data.clsControlPagares.strBuscarSucursalPagare(strAfiliacionId, strConnectionString)

            Dim strResult As StringBuilder
            strResult = New StringBuilder

            strResult.Append("<script language=""javascript"" type=""text/javascript"">")

            If IsArray(objArray) AndAlso objArray.Length > 0 Then

                strResult.AppendFormat("parent.document.getElementById('txtDescripcionSucursalPagare').value = '{0}';", CType(objArray.GetValue(0), Array).GetValue(4))
            Else

                strResult.AppendFormat("parent.document.getElementById('txtDescripcionSucursalPagare').value = '{0}';", "Consulta sin resultados")
                strResult.AppendFormat("parent.document.getElementById('txtAfiliacionId').value = '{0}';", String.Empty)

            End If

            strResult.Append("</script>")
            Return strResult.ToString()

        End If

        'Consulta sin resultados
        Return String.Empty
    End Function

#End Region

End Class