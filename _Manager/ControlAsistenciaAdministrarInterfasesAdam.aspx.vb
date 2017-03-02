Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports System.Web.UI.HtmlControls
Imports System.IO
Imports System.Text
Imports System.Collections

Public Class ControlAsistenciaAdministrarInterfasesAdam
    Inherits PaginaBase

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents txtArchivo As HtmlInputFile
    Private _mensajeErrorArchivo As String = String.Empty
    Private Const TIPO_USUARIO_ADMINISTRADOR As Integer = 1

    Protected Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

    Protected Overrides Sub onPreRender(ByVal e As System.EventArgs)
        ViewState("Checar_Pagina_Cargada") = Session("Checar_Pagina_Cargada")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False _
        Or Not intTipoUsuarioId = TIPO_USUARIO_ADMINISTRADOR Then
            Call Response.Redirect("../Default.aspx")
        End If

        If Not IsPostBack Then
            Session("Checar_Pagina_Cargada") = DateTime.Now.ToString()
        End If
    End Sub

    Private Sub GuardarCalendarioNomina(ByVal infoArchivoCSV As Array)
        Dim renglonCalendario As Array
        Dim fechaActual As Date = Date.Now
        Dim cantidadColumnas As Integer
        Dim mismaCantidadColumnas As Boolean
        Dim objCalendario As clsCalendarioNomina

        cantidadColumnas = DirectCast(infoArchivoCSV.GetValue(0), Array).Length

        For indice As Integer = 1 To infoArchivoCSV.Length - 1
            renglonCalendario = DirectCast(infoArchivoCSV.GetValue(indice), Array)

            mismaCantidadColumnas = (cantidadColumnas = renglonCalendario.Length)

            If mismaCantidadColumnas Then
                objCalendario = New clsCalendarioNomina(CShort(renglonCalendario.GetValue(0)), _
                                                        CShort(renglonCalendario.GetValue(1)), _
                                                        CShort(renglonCalendario.GetValue(2)), _
                                                        CDate(renglonCalendario.GetValue(3)), _
                                                        CDate(renglonCalendario.GetValue(4)), _
                                                        CDate(renglonCalendario.GetValue(5)), _
                                                        CDate(renglonCalendario.GetValue(6)), _
                                                        CShort(renglonCalendario.GetValue(7)), _
                                                        CShort(renglonCalendario.GetValue(8)), _
                                                        CShort(renglonCalendario.GetValue(9)), _
                                                        CShort(clsCalendarioNomina.EstatusCalendarioEnviado.NoEnviado), _
                                                        fechaActual, _
                                                        strUsuarioNombre)

                Benavides.CC.Data.clsControlDeAsistencia. _
                             clsCalendarioNomina. _
                             intGuardarTblCalendarioNomina(CShort(objCalendario.TipoNomina), objCalendario.intAnio, _
                                                           objCalendario.intPeriodo, objCalendario.dtmFechaInicio, _
                                                           objCalendario.dtmFechaFin, objCalendario.dtmFechaEjecucion, _
                                                           objCalendario.dtmFechaPago, objCalendario.intMesAcumulado, _
                                                           objCalendario.intAnioAcumulado, objCalendario.intCalendarioId, _
                                                           CShort(objCalendario.EstatusEnviado), objCalendario.dtmUltimaModificacion, _
                                                           objCalendario.strModificadoPor, strConnectionString)
            End If
        Next

    End Sub

    Private Function EncontrarCeldaVacia(ByVal infoArchivoCSV As Array) As Boolean
        Dim hayCeldaVacia As Boolean = False
        Dim renglonCalendario As Array
        Dim cantidadColumnas As Integer
        Dim mismaCantidadColumnas As Boolean = False

        cantidadColumnas = DirectCast(infoArchivoCSV.GetValue(0), Array).Length

        For indice As Integer = 1 To infoArchivoCSV.Length - 1

            renglonCalendario = DirectCast(infoArchivoCSV.GetValue(indice), Array)
            mismaCantidadColumnas = (cantidadColumnas = renglonCalendario.Length)

            If mismaCantidadColumnas AndAlso (renglonCalendario.GetValue(0).ToString().Trim Is String.Empty Or _
               renglonCalendario.GetValue(1) Is String.Empty Or _
               renglonCalendario.GetValue(2) Is String.Empty Or _
               renglonCalendario.GetValue(3) Is String.Empty Or _
               renglonCalendario.GetValue(4) Is String.Empty Or _
               renglonCalendario.GetValue(5) Is String.Empty Or _
               renglonCalendario.GetValue(6) Is String.Empty Or _
               renglonCalendario.GetValue(7) Is String.Empty Or _
               renglonCalendario.GetValue(8) Is String.Empty Or _
               renglonCalendario.GetValue(9) Is String.Empty) Then

                hayCeldaVacia = True
                Exit For
            End If
        Next

        Return hayCeldaVacia
    End Function

    Private Function ValidarArchivo() As Boolean
        Dim esArchivoInvalido As Boolean = False
        Dim extensionArchivoPermitida As String = ".csv"

        If txtArchivo.PostedFile.FileName.Length < 1 Then
            esArchivoInvalido = True
            _mensajeErrorArchivo = "Favor de seleccionar un archivo."
        ElseIf Not Path.HasExtension(txtArchivo.PostedFile.FileName) Then
            esArchivoInvalido = True
            _mensajeErrorArchivo = "El archivo no contiene una extensión."
        ElseIf Not String.Equals(Path.GetExtension(txtArchivo.PostedFile.FileName).ToLower(), extensionArchivoPermitida) Then
            esArchivoInvalido = True
            _mensajeErrorArchivo = "El archivo no contiene la extensión correcta. La extensión debe ser .csv"
        End If

        Return esArchivoInvalido
    End Function

    Protected Function strObtenerCalendarioNomina() As String
        Dim resultadoTablaCalendarioNomina As New StringBuilder
        Dim objCalendariosNomina As Array

        objCalendariosNomina = Benavides.CC.Data.clsControlDeAsistencia. _
                             clsCalendarioNomina.strConsultarCalendarioNomina(strConnectionString)

        If IsArray(objCalendariosNomina) AndAlso objCalendariosNomina.Length > 0 Then
            resultadoTablaCalendarioNomina.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            resultadoTablaCalendarioNomina.Append("<tr class='trtitulos'>")
            resultadoTablaCalendarioNomina.Append("<th class='rayita'>Nómina</th>")
            resultadoTablaCalendarioNomina.Append("<th class='rayita'>Año</th>")
            resultadoTablaCalendarioNomina.Append("<th class='rayita'>Periodo</th>")
            resultadoTablaCalendarioNomina.Append("<th class='rayita'>F. Inicio</th>")
            resultadoTablaCalendarioNomina.Append("<th class='rayita'>F. Fin</th>")
            resultadoTablaCalendarioNomina.Append("<th class='rayita'>F. Ejecución</th>")
            resultadoTablaCalendarioNomina.Append("<th class='rayita'>F. Pago</th>")
            resultadoTablaCalendarioNomina.Append("<th class='rayita'>Mes Acum.</th>")
            resultadoTablaCalendarioNomina.Append("<th class='rayita'>Año Acum.</th>")
            resultadoTablaCalendarioNomina.Append("<th class='rayita'>Id</th>")
            resultadoTablaCalendarioNomina.Append("<th class='rayita'>Estatus Enviado</th>")
            resultadoTablaCalendarioNomina.Append("<th class='rayita'>F. Modificación</th>")

            resultadoTablaCalendarioNomina.Append("</tr>")

            resultadoTablaCalendarioNomina.Append(CrearRegistrosCalendarioNomina(objCalendariosNomina))

            resultadoTablaCalendarioNomina.Append("</table>")
        End If

        Return resultadoTablaCalendarioNomina.ToString()
    End Function

    Private Function CrearRegistrosCalendarioNomina(ByVal registrosCalendarioNomina As Array) As String
        Dim contadorRegistros As Integer = 0
        Dim colorRegistro As String = String.Empty
        Dim resultadoCalendario As New StringBuilder
        Dim objCalendario As clsCalendarioNomina

        For Each renglon As SortedList In registrosCalendarioNomina
            contadorRegistros += 1
            objCalendario = New clsCalendarioNomina(CShort(renglon.Item("intTipoNomina")), CShort(renglon.Item("intAño")), _
                                                    CShort(renglon.Item("intPeriodo")), CDate(renglon.Item("dtmFechaInicio")), _
                                                    CDate(renglon.Item("dtmFechaFin")), CDate(renglon.Item("dtmFechaEjecucion")), _
                                                    CDate(renglon.Item("dtmFechaPago")), CShort(renglon.Item("intMesAcumulado")), _
                                                    CShort(renglon.Item("intAñoAcumulado")), CInt(renglon.Item("intCalendarioId")), _
                                                    CShort(renglon.Item("intEstatusEnviado")), CDate(renglon.Item("dtmUltimaModificacion")), _
                                                    CStr(renglon.Item("strModificadoPor")))

            If (contadorRegistros Mod 2) <> 0 Then
                colorRegistro = "tdceleste"
            Else
                colorRegistro = "tdblanco"
            End If

            resultadoCalendario.Append("<tr>")

            resultadoCalendario.AppendFormat("<td class='{0}'>{1}</td>", colorRegistro, objCalendario.TipoNomina)
            resultadoCalendario.AppendFormat("<td class='{0}'>{1}</td>", colorRegistro, objCalendario.intAnio)
            resultadoCalendario.AppendFormat("<td class='{0}' style='text-align: center;'>{1}</td>", colorRegistro, objCalendario.intPeriodo)
            resultadoCalendario.AppendFormat("<td class='{0}'>{1}</td>", colorRegistro, objCalendario.dtmFechaInicio.ToShortDateString())
            resultadoCalendario.AppendFormat("<td class='{0}'>{1}</td>", colorRegistro, objCalendario.dtmFechaFin.ToShortDateString())
            resultadoCalendario.AppendFormat("<td class='{0}'>{1}</td>", colorRegistro, objCalendario.dtmFechaEjecucion.ToShortDateString())
            resultadoCalendario.AppendFormat("<td class='{0}'>{1}</td>", colorRegistro, objCalendario.dtmFechaPago.ToShortDateString())
            resultadoCalendario.AppendFormat("<td class='{0}' style='text-align: center;'>{1}</td>", colorRegistro, objCalendario.intMesAcumulado)
            resultadoCalendario.AppendFormat("<td class='{0}'>{1}</td>", colorRegistro, objCalendario.intAnioAcumulado)
            resultadoCalendario.AppendFormat("<td class='{0}'>{1}</td>", colorRegistro, objCalendario.intCalendarioId)
            resultadoCalendario.AppendFormat("<td class='{0}' style='text-align: center;'>{1}</td>", colorRegistro, objCalendario.EstatusEnviado)
            resultadoCalendario.AppendFormat("<td class='{0}'>{1}</td>", colorRegistro, objCalendario.dtmUltimaModificacion.ToShortDateString())

            resultadoCalendario.Append("</tr>")
        Next

        Return resultadoCalendario.ToString()
    End Function

    Protected Sub btnAgregarArchivo_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim infoArchivoCSV As Array

        'Try
        If ViewState("Checar_Pagina_Cargada").ToString() = Session("Checar_Pagina_Cargada").ToString() Then
            Session("Checar_Pagina_Cargada") = DateTime.Now.ToString()
            If Not ValidarArchivo() Then
                infoArchivoCSV = CreateArrayFromCSVHttpPostedFile(txtArchivo.PostedFile)
                If Not EncontrarCeldaVacia(infoArchivoCSV) Then
                    Call GuardarCalendarioNomina(infoArchivoCSV)
                    Call Response.Write("<script language='Javascript'>alert('Registros guardados correctamente.');</script>")
                Else
                    Call Response.Write("<script language='Javascript'>alert('Faltan celdas por llenar.');</script>")
                End If
            Else
                Call Response.Write(String.Format("<script language='Javascript'>alert('{0}');</script>", _mensajeErrorArchivo))
            End If
        End If

        'Catch ex As Exception
        '    Call Response.Write("<script language='Javascript'>alert('Error');</script>")
        'End Try
    End Sub

End Class

Public Class clsCalendarioNomina

    Public Enum Nomina
        Quincena = 1
        Semana = 2
    End Enum

    Public Enum EstatusCalendarioEnviado
        NoEnviado = 0
        Enviado = 1
        ErrorEnviado = 2
    End Enum

    Private _tipoNomina As Nomina
    Private _intAnio As Short
    Private _intPeriodo As Short
    Private _dtmFechaInicio As Date
    Private _dtmFechaFin As Date
    Private _dtmFechaEjecucion As Date
    Private _dtmFechaPago As Date
    Private _intMesAcumulado As Short
    Private _intAnioAcumulado As Short
    Private _intCalendarioId As Integer
    Private _estatusEnviado As EstatusCalendarioEnviado
    Private _dtmUltimaModificacion As Date
    Private _strModificadoPor As String

    Public Property TipoNomina() As Nomina
        Get
            Return _tipoNomina
        End Get
        Set(ByVal value As Nomina)
            _tipoNomina = value
        End Set
    End Property

    Public Property intAnio() As Short
        Get
            Return _intAnio
        End Get
        Set(ByVal value As Short)
            _intAnio = value
        End Set
    End Property

    Public Property intPeriodo() As Short
        Get
            Return _intPeriodo
        End Get
        Set(ByVal value As Short)
            _intPeriodo = value
        End Set
    End Property

    Public Property dtmFechaInicio() As Date
        Get
            Return _dtmFechaInicio
        End Get
        Set(ByVal value As Date)
            _dtmFechaInicio = value
        End Set
    End Property

    Public Property dtmFechaFin() As Date
        Get
            Return _dtmFechaFin
        End Get
        Set(ByVal value As Date)
            _dtmFechaFin = value
        End Set
    End Property

    Public Property dtmFechaEjecucion As Date
        Get
            Return _dtmFechaEjecucion
        End Get
        Set(ByVal value As Date)
            _dtmFechaEjecucion = value
        End Set
    End Property

    Public Property dtmFechaPago() As Date
        Get
            Return _dtmFechaPago
        End Get
        Set(ByVal value As Date)
            _dtmFechaPago = value
        End Set
    End Property

    Public Property intMesAcumulado() As Short
        Get
            Return _intMesAcumulado
        End Get
        Set(ByVal value As Short)
            _intMesAcumulado = value
        End Set
    End Property

    Public Property intAnioAcumulado() As Short
        Get
            Return _intAnioAcumulado
        End Get
        Set(ByVal value As Short)
            _intAnioAcumulado = value
        End Set
    End Property

    Public Property intCalendarioId() As Integer
        Get
            Return _intCalendarioId
        End Get
        Set(ByVal value As Integer)
            _intCalendarioId = value
        End Set
    End Property

    Public Property EstatusEnviado() As EstatusCalendarioEnviado
        Get
            Return _estatusEnviado
        End Get
        Set(ByVal value As EstatusCalendarioEnviado)
            _estatusEnviado = value
        End Set
    End Property

    Public Property dtmUltimaModificacion() As Date
        Get
            Return _dtmUltimaModificacion
        End Get
        Set(ByVal value As Date)
            _dtmUltimaModificacion = value
        End Set
    End Property

    Public Property strModificadoPor() As String
        Get
            Return _strModificadoPor
        End Get
        Set(ByVal value As String)
            _strModificadoPor = value
        End Set
    End Property

    Public Sub New(ByVal paramIntTipoNomina As Short, ByVal paramIntAnio As Short, _
                   ByVal paramIntPeriodo As Short, ByVal paramDtmFechaInicio As Date, _
                   ByVal paramDtmFechaFin As Date, ByVal paramDtmFechaEjecucion As Date, _
                   ByVal paramFechaPago As Date, ByVal paramIntMesAcumulado As Short, _
                   ByVal paramIntAnioAcumulado As Short, ByVal paramIntCalendarioId As Integer, _
                   ByVal paramIntEstatusEnviado As Short, ByVal paramDtmUltimaModificacion As Date, _
                   ByVal paramStrModificadoPor As String)

        _tipoNomina = CType(paramIntTipoNomina, Nomina)
        _intAnio = paramIntAnio
        _intPeriodo = paramIntPeriodo
        _dtmFechaInicio = paramDtmFechaInicio
        _dtmFechaFin = paramDtmFechaFin
        _dtmFechaEjecucion = paramDtmFechaEjecucion
        _dtmFechaPago = paramFechaPago
        _intMesAcumulado = paramIntMesAcumulado
        _intAnioAcumulado = paramIntAnioAcumulado
        _intCalendarioId = paramIntCalendarioId
        _estatusEnviado = CType(paramIntEstatusEnviado, EstatusCalendarioEnviado)
        _dtmUltimaModificacion = paramDtmUltimaModificacion
        _strModificadoPor = paramStrModificadoPor
    End Sub

End Class