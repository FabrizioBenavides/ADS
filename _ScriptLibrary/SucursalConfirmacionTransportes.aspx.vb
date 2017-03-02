Imports Benavides.CC.Business
Imports Benavides.POSAdmin.Commons
Imports System.Configuration
Imports System.Text
Imports System.Collections
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert

Public Class SucursalConfirmacionTransportes
    Inherits System.Web.UI.Page

    Private _strmJavascriptWindowOnLoadCommands As String
    Private _dtmFechaHoraEntregaProgramada As Date

    Public ReadOnly Property strJavascriptWindowOnLoadCommands() As String
        Get
            Return _strmJavascriptWindowOnLoadCommands
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
    ' Name       : intSucursalCTFId
    ' Description: Valor de la Sucursal CTF
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intSucursalCTFId() As Integer
        Get
            Dim objSucursalCTF As Array = Nothing
            Dim objRegistroSucursalCTF As System.Collections.SortedList = Nothing
            Dim strLocalCTF As String = ""

            objSucursalCTF = clsConcentrador.clsSucursal.strBuscarCTFId(intCompaniaId, intSucursalId, strCadenaConexion)

            If IsArray(objSucursalCTF) AndAlso objSucursalCTF.Length > 0 Then

                objRegistroSucursalCTF = DirectCast(objSucursalCTF.GetValue(0), System.Collections.SortedList)

                strLocalCTF = CStr(objRegistroSucursalCTF.Item("strLocalCTF"))

                If Len(strLocalCTF) = 4 Then
                    Return CInt(strLocalCTF)
                Else
                    Return 0
                End If

            Else
                Return 0
            End If

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
    ' Name       : strCadenaConexionCTF
    ' Description: Valor que tomara la variable strmCadenaConexion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCadenaConexionCTF() As String
        Get
            Return ConfigurationSettings.AppSettings("strConexionCTF")
        End Get
    End Property

    '====================================================================
    ' Name       : strURLPOSAdmin
    ' Description: URL del POS Admin
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
    ' Name       : strCentroLogisticoId
    ' Description: Valor de la Compañia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCentroLogisticoId() As String
        Get
            Return (clsCommons.strReadCookie("strCentroLogisticoId", String.Empty, Request, Server))
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
            If Not Request.QueryString("strCmd") Is Nothing Then
                Return (Request.QueryString("strCmd"))
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaConsulta
    ' Description: Fecha a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaConsulta() As Date
        Get
            Dim dtmFechaConsultaValor As String = Request.Form("dtmFechaConsulta")

            If Not dtmFechaConsultaValor Is Nothing And dtmFechaConsultaValor <> "" Then
                Return CDate(dtmFechaConsultaValor)
            Else
                Return CDate(dtmFechaHoyFormatoCorto)
            End If
        End Get
    End Property

    Public ReadOnly Property dtmFechaHoyFormatoCorto() As String
        Get
            Return Date.Now.ToShortDateString
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)
        End Get
    End Property

    Public ReadOnly Property intCalendarioId() As Integer
        Get
            Return CInt(GetPageParameter("intCalendarioId", "0"))
        End Get
    End Property

    Public ReadOnly Property strFechaHoraEntregaProgramada As String
        Get
            Return _dtmFechaHoraEntregaProgramada.ToString("MM/dd/yyyy HH:mm:ss")
        End Get
    End Property

    Public ReadOnly Property dtmFechaHoyConFormato() As String
        Get
            Return Date.Now.ToString("MM/dd/yyyy HH:mm:ss")
        End Get
    End Property

    Public ReadOnly Property intMotivoRetrasoId As Integer
        Get
            Return CInt(GetPageParameter("intMotivoRetrasoId", "-1"))
        End Get
    End Property

    Public ReadOnly Property strRutaTransportesClave As String
        Get
            Return CStr(GetPageParameter("strRutaTransportesClave", ""))
        End Get
    End Property

    Public ReadOnly Property strFechaHoraEntregaProgramadaParametro As String
        Get
            Dim strFechaHoraEntregaProgramada As String = GetPageParameter("strFechaHoraEntregaProgramada", "")
            Return strFechaHoraEntregaProgramada
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Codigo para probar localmente la página.
        'Call clsConcentrador.clsControlAcceso.intValidarCuentaUsuario("77714009", "dGL2uQ/YsrMyh5TSuUt7HTxIxX8=", Response, Server, strCadenaConexion)

        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        Select Case strCmd
            Case "Confirmar"
                Call ConfirmarCalendario()
        End Select

        'Try

        'Catch ex As Exception
        '    Response.Write("Error")
        'End Try
    End Sub

    Protected Function strObtenerCalendario() As String
        Dim resultadoCalendario As New StringBuilder
        Dim objCalendario As Array

        objCalendario = Benavides.CC.Data.clsRutaTransportes.clsRutaTransportesSucursalCalendario.strConsultarTblRutaTransportesSucursalCalendario(strCentroLogisticoId, dtmFechaConsulta, strCadenaConexion)

        If IsArray(objCalendario) AndAlso objCalendario.Length > 0 Then
            resultadoCalendario.Append("<table id='tablaCalendarioSucursal' width='100%' border='0' cellpadding='0' cellspacing='0'>")
            resultadoCalendario.Append("<tr class='trtitulos'>")
            resultadoCalendario.Append("<th class='rayita'>Ruta</th>")
            resultadoCalendario.Append("<th class='rayita'>Frecuencia</th>")
            resultadoCalendario.Append("<th class='rayita'>Surtido</th>")
            resultadoCalendario.Append("<th class='rayita'>Entrega</th>")
            resultadoCalendario.Append("<th class='rayita'>Fecha y Hora Entrega</th>")
            resultadoCalendario.Append("<th class='rayita'>Fecha y Hora Confirmada</th>")
            resultadoCalendario.Append("<th class='rayita'>Confirmar</th>")
            resultadoCalendario.Append("<th class='rayita'></th>")
            resultadoCalendario.Append("<th class='rayita'></th>")
            resultadoCalendario.Append("<th class='rayita'></th>")
            resultadoCalendario.Append("<th class='rayita'></th>")
            resultadoCalendario.Append("<th class='rayita'></th>")

            resultadoCalendario.Append("</tr>")

            resultadoCalendario.Append(CrearRegistrosCalendario(objCalendario))

            resultadoCalendario.Append("</table>")
        Else
            _strmJavascriptWindowOnLoadCommands = "No se encontraron registros."
        End If

        Return resultadoCalendario.ToString()
    End Function

    Private Function CrearRegistrosCalendario(ByVal registrosCalendario As Array) As String
        Dim contadorRegistros As Integer = 0
        Dim colorRegistro As String = String.Empty
        Dim resultadoCalendario As New StringBuilder
        Dim dtmFechaHoy As Date = Date.Now.Date
        Dim dtmFechaHoraEntregaProgramada As Date
        Dim intCalendarioIdRenglon As String = String.Empty
        Dim strRutaTransportesClaveRenglon As String = String.Empty
        Dim intFrecuencia As String = String.Empty
        Dim strRutaTransportesDiaSurtido As String = String.Empty
        Dim strRutaTransportesDiaEntrega As String = String.Empty
        Dim strFechaHoraEntregaProgramada As String = String.Empty
        Dim blnEntregaConfirmada As Boolean = False
        Dim strValorConfirmado As String = String.Empty
        Dim strDeshabilitado As String = String.Empty
        Dim dtmFechaHoraEntregaReal As Date
        Dim strFechaHoraEntregaReal As String = String.Empty
        Dim intTolerancia As String = String.Empty
        Dim strOpcionesMotivoRetraso As String = CrearOpcionesMotivoRetraso()

        For Each renglon As SortedList In registrosCalendario
            contadorRegistros += 1
            strValorConfirmado = String.Empty
            strDeshabilitado = String.Empty
            strFechaHoraEntregaReal = String.Empty

            intCalendarioIdRenglon = CStr(renglon.Item("intCalendarioId"))
            strRutaTransportesClaveRenglon = CStr(renglon.Item("strRutaTransportesClave"))
            intFrecuencia = CStr(renglon.Item("intFrecuencia"))
            strRutaTransportesDiaSurtido = CStr(renglon.Item("strRutaTransportesDiaSurtido"))
            strRutaTransportesDiaEntrega = CStr(renglon.Item("strRutaTransportesDiaEntrega"))
            dtmFechaHoraEntregaProgramada = CDate(renglon.Item("dtmFechaHoraEntregaProgramada"))
            blnEntregaConfirmada = CBool(renglon.Item("blnEntregaConfirmada"))
            intTolerancia = CStr(renglon.Item("intTolerancia"))

            If Not renglon.Item("dtmFechaHoraEntregaReal") Is Nothing And Not IsDBNull(renglon.Item("dtmFechaHoraEntregaReal")) Then
                dtmFechaHoraEntregaReal = CDate(renglon.Item("dtmFechaHoraEntregaReal"))
                strFechaHoraEntregaReal = dtmFechaHoraEntregaReal.ToString("dd/MM/yyyy HH:mm:ss")
            End If

            If (contadorRegistros Mod 2) <> 0 Then
                colorRegistro = "tdceleste"
            Else
                colorRegistro = "tdblanco"
            End If

            If blnEntregaConfirmada Then
                strValorConfirmado = "checked"
                strDeshabilitado = "disabled"
            End If

            If dtmFechaHoraEntregaProgramada.Date > dtmFechaHoy Then
                strDeshabilitado = "disabled"
            End If

            resultadoCalendario.Append("<tr>")
            resultadoCalendario.AppendFormat("<td class='{0}' style='text-align:center'>{1}</td>" & _
                                             "<td class='{0}' style='text-align:center'>{2}</td>" & _
                                             "<td class='{0}' style='text-align:center'>{3}</td>" & _
                                             "<td class='{0}' style='text-align:center'>{4}</td>" & _
                                             "<td class='{0}' style='text-align:center'>{5}</td>" & _
                                             "<td class='{0}' style='text-align:center'>{6}</td>", _
                                             colorRegistro, strRutaTransportesClaveRenglon, intFrecuencia, _
                                             strRutaTransportesDiaSurtido, strRutaTransportesDiaEntrega, _
                                             dtmFechaHoraEntregaProgramada.ToString("dd/MM/yyyy HH:mm:ss"), strFechaHoraEntregaReal)

            resultadoCalendario.AppendFormat("<td class='{0}' style='text-align:center'>" & _
                                             "<input type='checkbox' id='rbtConfirmar{1}' name='transportes' " & _
                                             "{2} {3} value='{4}' onclick='activarDesactivarBotonConfirmar(this);' /></td>" _
                                             , colorRegistro, contadorRegistros, strValorConfirmado, strDeshabilitado, intCalendarioIdRenglon)

            resultadoCalendario.AppendFormat("<td class='{0}' style='text-align:center'>" & _
                                             "<input type='hidden' value='{1}' id='hdnFechaHoraEntregaProgramada{2}' /></td>" _
                                             , colorRegistro, dtmFechaHoraEntregaProgramada.ToString("MM/dd/yyyy HH:mm:ss"), contadorRegistros)

            resultadoCalendario.AppendFormat("<td class='{0}' style='text-align:center'>" & _
                                            "<input type='hidden' value='{1}' id='hdnTolerancia{2}' name='hdnTolerancia{2}' /></td>" _
                                             , colorRegistro, intTolerancia, contadorRegistros)

            resultadoCalendario.AppendFormat("<td class='{0}' style='text-align:center'>" & _
                                             "<input type='hidden' value='false' id='hdnConfirmacion{1}' /></td>", colorRegistro, contadorRegistros)

            resultadoCalendario.AppendFormat("<td class='{0}' style='text-align:center'><select id='cboMotivoRetraso{1}' name='cboMotivoRetraso' " & _
                                             "class='campotabla' style='width: 110px; display: none;'>" & _
                                             "<option value='-1'>>> Elija Motivo <<</option>{2}</ select></td>" _
                                             , colorRegistro, contadorRegistros, strOpcionesMotivoRetraso)

            If blnEntregaConfirmada Then
                resultadoCalendario.AppendFormat("<td class='{0}' style='text-align:center'>" & _
                                                 "<input type='image' id='imagenImprimir{1}' src='../static/images/ImgNRImprimir.gif' " & _
                                                 "width='15' height='15' border='0' align='center' alt='Imprimir' title='Imprimir' " & _
                                                 "onclick='imprimirConfirmacion(""" & strRutaTransportesClaveRenglon & """ , """ & dtmFechaHoraEntregaProgramada.ToString("dd/MM/yyyy HH:mm:ss") & """ , """ & strFechaHoraEntregaReal & """ ); return false;' /></td>" _
                                                 , colorRegistro, contadorRegistros)
            End If

            resultadoCalendario.Append("</tr>")
        Next

        Return resultadoCalendario.ToString()
    End Function

    Private Sub ConfirmarCalendario()
        Dim resultado As Integer = 0
        Dim fechaActual As Date = Date.Now

        resultado = Benavides.CC.Data.clsRutaTransportes.clsRutaTransportesSucursalCalendario.intConfirmarTblRutaTransportesSucursalCalendario(intCalendarioId, _
                                                                                       fechaActual, _
                                                                                       intMotivoRetrasoId, _
                                                                                       fechaActual, _
                                                                                       strUsuarioNombre, _
                                                                                       strCadenaConexion)
        If resultado = 1 Then
            _strmJavascriptWindowOnLoadCommands = "Entrega confirmada correctamente."
            Call ImprimirReciboConfirmacion(fechaActual)
        ElseIf resultado = 0 Then
            _strmJavascriptWindowOnLoadCommands = "Error"
        End If
    End Sub

    Private Sub ImprimirReciboConfirmacion(ByVal fechaActual As Date)
        Dim reciboImpresion As New StringBuilder

        reciboImpresion.Append("var ventanaNueva = window.open('', '', 'height=200, width=600');")
        reciboImpresion.Append("ventanaNueva.document.write('<H2>Confirmación de Transporte</H2>');")
        reciboImpresion.Append("ventanaNueva.document.write(""<table id='reciboAutomatico' width='100%' border='1'>"");")
        reciboImpresion.Append("ventanaNueva.document.write('<tr><td>Sucursal</td><td>Nombre</td><td>Ruta</td><td>Fecha Entrega</td><td>Fecha Confirmación</td></tr>');")
        reciboImpresion.Append("ventanaNueva.document.write('<tr>');")
        reciboImpresion.AppendFormat("ventanaNueva.document.write('<td>{0}</td>');", strCentroLogisticoId)
        reciboImpresion.AppendFormat("ventanaNueva.document.write('<td>{0}</td>');", strSucursalNombre)
        reciboImpresion.AppendFormat("ventanaNueva.document.write('<td>{0}</td>');", strRutaTransportesClave)
        reciboImpresion.AppendFormat("ventanaNueva.document.write('<td>{0}</td>');", strFechaHoraEntregaProgramadaParametro)
        reciboImpresion.AppendFormat("ventanaNueva.document.write('<td>{0}</td>');", fechaActual.ToString("dd/MM/yyyy HH:mm:ss"))
        reciboImpresion.Append("ventanaNueva.document.write('</tr>');")
        reciboImpresion.Append("ventanaNueva.document.write('</table>');")

        reciboImpresion.Append("ventanaNueva.document.close();")
        reciboImpresion.Append("ventanaNueva.focus();")
        reciboImpresion.Append("ventanaNueva.print();")
        reciboImpresion.Append("ventanaNueva.close();")

        Response.Write(String.Format("<script type='text/javascript' language='javascript'>{0}</script>", reciboImpresion.ToString()))
    End Sub

    Private Function CrearOpcionesMotivoRetraso() As String
        Dim strOpcionesMotivoRetraso As New StringBuilder
        Dim resultadoConsulta As Array = Nothing
        Dim objMotivo As New System.Collections.SortedList

        resultadoConsulta = Benavides.CC.Data.clsRutaTransportes. _
                                              clsRutaTransportesMotivoRetraso. _
                                              strConsultarTblRutaTransportesMotivoRetraso(strCadenaConexion)

        For i As Integer = 0 To resultadoConsulta.Length - 1
            objMotivo = CType(resultadoConsulta.GetValue(i), Collections.SortedList)
            strOpcionesMotivoRetraso.AppendFormat("<option value='{0}'>{1}</option>", _
                                              objMotivo.Item("intMotivoRetrasoId").ToString(), _
                                              objMotivo.Item("strMotivoNombre").ToString())
        Next

        Return strOpcionesMotivoRetraso.ToString()
    End Function

End Class