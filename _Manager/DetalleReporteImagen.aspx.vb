'====================================================================
' Class         :  clsCapturaConsumidorFotolab
' Title         : Grupo Benavides
' Description   : Pantalla de Captura de Nuevos consumidores Fotolab
' Copyright     : 2003-2006 All rights reserved.
' Company       : Neitek Solutions S.A. de C.V.
' Author        : Enrique Longoria
' Version       : 1.0
' Last Modified : Thu, Feb 16th, 2005
'====================================================================

#Region "Imports"
Imports System.Text
Imports System.Collections
Imports prjFotolabBusiness.Benavides.Fotolab.Utils
Imports prjFotolabBusiness.Benavides.Fotolab.Data
#End Region

Public Class clsDetalleReporteImagen
    Inherits clsTemplatePage

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

#Region "Properties"

    Protected _intConsumidorFotolabId As Integer
    Protected _strConsumidorFotolabTelefono As String
    Protected _strConsumidorFotolabNombre As String
    Protected _strConsumidorFotolabCorreo As String


    '====================================================================
    ' Name       : intConsumidorFotolabId 
    ' Description: Obtiene o establece el valor
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intConsumidorFotolabId() As Integer
        Get
            Return _intConsumidorFotolabId
        End Get
        Set(ByVal strValue As Integer)
            _intConsumidorFotolabId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : _strConsumidorFotolabTelefono 
    ' Description: Obtiene o establece el valor
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strConsumidorFotolabTelefono() As String
        Get
            Return _strConsumidorFotolabTelefono
        End Get
        Set(ByVal strValue As String)
            _strConsumidorFotolabTelefono = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strConsumidorFotolabNombre 
    ' Description: Obtiene o establece el valor
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strConsumidorFotolabNombre() As String
        Get
            Return _strConsumidorFotolabNombre
        End Get
        Set(ByVal strValue As String)
            _strConsumidorFotolabNombre = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : _strConsumidorFotolabCorreo 
    ' Description: Obtiene o establece el valor
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strConsumidorFotolabCorreo() As String
        Get
            Return _strConsumidorFotolabCorreo
        End Get
        Set(ByVal strValue As String)
            _strConsumidorFotolabCorreo = strValue
        End Set
    End Property

#End Region

#Region "Document Business"

    '====================================================================
    ' Name       : initialize
    ' Description: inicializa el valor de la clase de servicios
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Nothing
    '====================================================================
    Protected Overrides Sub initialize()
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsReporteImagen.SERVICIOS
    End Sub

    '====================================================================
    ' Name       : strNuevoRegistro
    ' Description: Acción efectuda cuando se agrega un registro (INSERT)
    ' Parameters : 
    '              ByVal strCmd As  String
    '                 - Nombre del  comando a efectuar  
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Nothing
    '====================================================================
    Protected Overrides Function strNuevoRegistro(ByVal strCmd As String) As String
        Dim values As Array
        values = clsServicesObj.strConsultarListado(strCmd, Request, Me.strConnectionString, strUsuarioNombre, -1, -1)
        Me.strDesplegarValores(values)
    End Function

    '====================================================================
    ' Name       : strGenerarlistado
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function strGenerarlistado(ByVal strCmd As String) As String
        Dim htmlResult As StringBuilder = New StringBuilder()
        Dim intSelectedPage, totalRows As Integer
        Dim dataArray, elemArray As Array
        Const intElementsPerPage As Integer = 1
        Dim intEstatusId As String = "-1"
        Dim dtmConsultaOrdenInicio As String
        Dim dtmConsultaOrdenFinal As String

        Dim intTipoReporteId As String
        Dim intTipoPagoId As String
        Dim intDireccionOperativaId As String
        Dim intZonaOperativaId As String
        Dim strLaboratoriosId As String
        Dim strFarmaciaId As String
        Dim intTipodeBusqueda As String
        Dim intColores As String

        intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        If intSelectedPage <= 0 Then
            If IsNumeric(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request)) = True Then
                intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
                If intSelectedPage = -1 Then intSelectedPage = 1
            Else
                intSelectedPage = 1
            End If
        End If
        If strCmd = "1" Then
            intSelectedPage = 1
        End If

        Dim arrFecha() As String
        dtmConsultaOrdenInicio = Request("dtmConsultaOrdenInicio")
        dtmConsultaOrdenFinal = Request("dtmConsultaOrdenFinal")
        If dtmConsultaOrdenInicio <> "" And dtmConsultaOrdenFinal <> "" Then
            If dtmConsultaOrdenInicio <> "" Then
                arrFecha = dtmConsultaOrdenInicio.Split(Chr(47))
                dtmConsultaOrdenInicio = arrFecha(1) + "/" + arrFecha(0) + "/" + arrFecha(2)
                dtmConsultaOrdenInicio = dtmConsultaOrdenInicio + " 00:00:00"
            End If


            If dtmConsultaOrdenFinal <> "" Then
                arrFecha = dtmConsultaOrdenFinal.Split(Chr(47))
                dtmConsultaOrdenFinal = arrFecha(1) + "/" + arrFecha(0) + "/" + arrFecha(2)
                dtmConsultaOrdenFinal = dtmConsultaOrdenFinal + " 23:59:59"
            End If
        Else
            dtmConsultaOrdenInicio = ""
            dtmConsultaOrdenFinal = ""
        End If
        intTipoReporteId = Request("intTipoReporteId")
        intTipoPagoId = Request("intTipoPagoId")
        intDireccionOperativaId = Request("intDireccionOperativaId")
        intZonaOperativaId = Request("intZonaOperativaId")
        strLaboratoriosId = Request("strLaboratoriosId")
        strFarmaciaId = Request("strFarmaciaId")
        intTipodeBusqueda = Request("intTipodeBusqueda")
        intColores = "1"
        ' Obtenemos los listados que ya se han capturado previamente.  
        ' Obtenemos los listados que ya se han capturado previamente.
        If (Request("intTipodeBusqueda") = "1") Then
            If (Request("strLaboratoriosId") <> "-1") And Request("strLaboratoriosId") <> "" Then
                Dim LabsIds() As String
                Dim auxArray(0) As Array
                Dim arrayItem As Array
                Dim j, i, contador As Integer
                contador = 0
                LabsIds = Split(Request("strLaboratoriosId"), ",")
                If intTipoPagoId = "-1" Then
                    For j = 0 To LabsIds.Length - 1
                        arrayItem = clsServicesObj.strConsultarListado("REPORTEIMAGENSINTIPOPAGO", Request, strConnectionString, Me.strUsuarioNombre, -1, -1, "'" + dtmConsultaOrdenInicio + "', '" + dtmConsultaOrdenFinal + "', " + intTipoReporteId + ", " + intTipoPagoId + ", " + intDireccionOperativaId + ", " + intZonaOperativaId + ", " + LabsIds(j) + ", " + strFarmaciaId + ", " + intTipodeBusqueda + ", 1")
                        If Not arrayitem Is Nothing AndAlso arrayItem.Length > 0 Then
                            contador = auxArray.Length - 1
                            ReDim Preserve auxArray(contador + arrayItem.Length)
                            For i = 0 To arrayitem.Length - 1
                                auxArray.setValue(arrayItem.GetValue(i), contador + i)
                            Next i
                        End If
                    Next j
                    ReDim Preserve auxArray(auxArray.Length - 2)
                Else
                    For j = 0 To LabsIds.Length - 1
                        arrayItem = clsServicesObj.strConsultarListado("REPORTEIMAGEN", Request, strConnectionString, Me.strUsuarioNombre, -1, -1, "'" + dtmConsultaOrdenInicio + "', '" + dtmConsultaOrdenFinal + "', " + intTipoReporteId + ", " + intTipoPagoId + ", " + intDireccionOperativaId + ", " + intZonaOperativaId + ", " + LabsIds(j) + ", " + strFarmaciaId + ", " + intTipodeBusqueda + ", 1")
                        If Not arrayitem Is Nothing AndAlso arrayItem.Length > 0 Then
                            contador = auxArray.Length - 1
                            ReDim Preserve auxArray(contador + arrayItem.Length)
                            For i = 0 To arrayitem.Length - 1
                                auxArray.setValue(arrayItem.GetValue(i), contador + i)
                            Next i
                        End If
                    Next j
                    ReDim Preserve auxArray(auxArray.Length - 2)
                End If
                dataArray = auxArray
                If Not dataArray Is Nothing AndAlso dataArray.Length > 0 Then
                    arrayItem = CType(dataArray.GetValue(0), Array)
                    arrayItem.SetValue(CStr(dataArray.Length), arrayItem.Length - 1)
                    dataArray.SetValue(arrayItem, 0)
                End If
            Else
                If intTipoPagoId = "-1" Then
                    dataArray = clsServicesObj.strConsultarListado("REPORTEIMAGENSINTIPOPAGO", Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, Me._MAX_PER_PAGE)
                Else
                    dataArray = clsServicesObj.strConsultarListado("REPORTEIMAGEN", Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, Me._MAX_PER_PAGE)
                End If
            End If
        Else
            If (Request("strFarmaciaId") <> "-1") And Request("strFarmaciaId") <> "" Then
                Dim LabsIds() As String
                Dim auxArray(0) As Array
                Dim arrayItem As Array
                Dim j, i, contador As Integer
                contador = 0
                LabsIds = Split(Request("strFarmaciaId"), ",")
                If intTipoPagoId = "-1" Then
                    For j = 0 To LabsIds.Length - 1
                        arrayItem = clsServicesObj.strConsultarListado("REPORTEIMAGENSINTIPOPAGO", Request, strConnectionString, Me.strUsuarioNombre, -1, -1, "'" + dtmConsultaOrdenInicio + "', '" + dtmConsultaOrdenFinal + "', " + intTipoReporteId + ", " + intTipoPagoId + ", " + intDireccionOperativaId + ", " + intZonaOperativaId + ", " + strLaboratoriosId + ", " + LabsIds(j) + ", " + intTipodeBusqueda + ", 1")
                        If Not arrayitem Is Nothing AndAlso arrayItem.Length > 0 Then
                            contador = auxArray.Length - 1
                            ReDim Preserve auxArray(contador + arrayItem.Length)
                            For i = 0 To arrayitem.Length - 1
                                auxArray.setValue(arrayItem.GetValue(i), contador + i)
                            Next i
                        End If
                    Next j
                    ReDim Preserve auxArray(auxArray.Length - 2)
                Else
                    For j = 0 To LabsIds.Length - 1
                        arrayItem = clsServicesObj.strConsultarListado("REPORTEIMAGEN", Request, strConnectionString, Me.strUsuarioNombre, -1, -1, "'" + dtmConsultaOrdenInicio + "', '" + dtmConsultaOrdenFinal + "', " + intTipoReporteId + ", " + intTipoPagoId + ", " + intDireccionOperativaId + ", " + intZonaOperativaId + ", " + strLaboratoriosId + ", " + LabsIds(j) + ", " + intTipodeBusqueda + ", 1")
                        If Not arrayitem Is Nothing AndAlso arrayItem.Length > 0 Then
                            contador = auxArray.Length - 1
                            ReDim Preserve auxArray(contador + arrayItem.Length)
                            For i = 0 To arrayitem.Length - 1
                                auxArray.setValue(arrayItem.GetValue(i), contador + i)
                            Next i
                        End If
                    Next j
                    ReDim Preserve auxArray(auxArray.Length - 2)
                End If
                dataArray = auxArray
                If Not dataArray Is Nothing AndAlso dataArray.Length > 0 Then
                    arrayItem = CType(dataArray.GetValue(0), Array)
                    arrayItem.SetValue(CStr(dataArray.Length), arrayItem.Length - 1)
                    dataArray.SetValue(arrayItem, 0)
                End If
            Else
                If intTipoPagoId = "-1" Then
                    dataArray = clsServicesObj.strConsultarListado("REPORTEIMAGENSINTIPOPAGO", Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, Me._MAX_PER_PAGE)
                Else
                    dataArray = clsServicesObj.strConsultarListado("REPORTEIMAGEN", Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, Me._MAX_PER_PAGE)
                End If
            End If
        End If

        Dim headers As ArrayList = New ArrayList()
        headers.Add("Laboratorio")
        headers.Add("Farmacia")
        headers.Add("Orden")
        headers.Add("Estatus")
        headers.Add("Fecha<br>Ingresada")
        headers.Add("Fecha<br>Entregada Ingresada")
        headers.Add("Fecha<br>En Proceso")
        headers.Add("Fecha<br>Terminada")
        headers.Add("Fecha<br>Entregada Terminada")
        headers.Add("Fecha<br>Recibida")
        headers.Add("Fecha<br>De Pago")
        headers.Add("Tiempo<br>Del Proceso")
        headers.Add("Tiempo<br>Del Ciclo")

        Dim columnOrder As Integer() = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}
        Dim actions As ArrayList = New ArrayList()

        'por medio de estas validaciones obtengo el numero  total de registros  que  regreso la búsqueda
        'no necesariamente es la longitud de mi Array (debido a la paginación), este dato del total por búsqueda esta contenido en la utlima columna
        'de cada uno de mis registros, cuando no tengo este dato, el numero total de registros el el total de elementos del arreglo
        If dataArray.Length > 0 Then
            elemArray = DirectCast(dataArray.GetValue(0), Array)
            If IsNumeric(elemArray.GetValue(elemArray.Length - 1)) Then '<- verifico si tiene un numero el la ultima columna
                totalRows = CInt(elemArray.GetValue(elemArray.Length - 1)) ' lo asigno este valor a mi var de total de registros
            Else
                totalRows = dataArray.Length ' si no  tengo el valor de total de reg en mi ultima columna asigno el total de elementos del arreglo como el total
            End If
        End If
        If ((Request("strFarmaciaId") = "-1") Or Request("strFarmaciaId") = "") And ((Request("strLaboratoriosId") = "-1") Or Request("strLaboratoriosId") = "") Then
            htmlResult.Append(clsHTMLUtils.displayScroll(totalRows, intSelectedPage, Me._MAX_PER_PAGE, "DetalleReporteImagen.aspx", Nothing, , "../static/images/"))
            htmlResult.Append(clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, intSelectedPage, Me._MAX_PER_PAGE, -1, , "../static/images/", False, 20))
        Else
            Dim aux1, aux2 As Array
            Dim laboratorio1, laboratorio2 As String
            Dim farmacia1, farmacia2 As String
            Dim estatus1, estatus2 As Integer
            Dim fecha1, fecha2 As DateTime
            'Prueba.Sort(dataArray, )
            Dim i, j As Integer
            If Not dataArray Is Nothing AndAlso dataArray.Length > 0 Then
                For i = 0 To dataArray.Length - 1
                    For j = i + 1 To dataArray.Length - 1
                        'If dataArray.GetValue(i, 3) > dataArray.GetValue(j, 3) Then
                        aux1 = CType(dataArray.GetValue(i), Array)
                        aux2 = CType(dataArray.GetValue(j), Array)
                        laboratorio1 = CType(aux1.GetValue(0), String)
                        laboratorio2 = CType(aux2.GetValue(0), String)
                        farmacia1 = CType(aux1.GetValue(1), String)
                        farmacia2 = CType(aux2.GetValue(1), String)
                        estatus1 = CType(aux1.GetValue(13), Integer)
                        estatus2 = CType(aux2.GetValue(13), Integer)
                        Try
                            fecha1 = CType(aux1.GetValue(4), DateTime)
                            fecha2 = CType(aux2.GetValue(4), DateTime)
                        Catch
                            Dim auxiliar1, auxiliar2 As String
                            Dim arrFecha1() As String
                            auxiliar1 = CType(aux1.GetValue(4), String)
                            auxiliar2 = CType(aux2.GetValue(4), String)
                            arrFecha1 = auxiliar1.Split(Chr(47))
                            auxiliar1 = arrFecha1(1) + "/" + arrFecha1(0) + "/" + arrFecha1(2)
                            arrFecha1 = auxiliar2.Split(Chr(47))
                            auxiliar2 = arrFecha1(1) + "/" + arrFecha1(0) + "/" + arrFecha1(2)
                            fecha1 = CType(auxiliar1, DateTime)
                            fecha2 = CType(auxiliar2, DateTime)
                        End Try


                        If laboratorio1 > laboratorio2 Then
                            dataArray.SetValue(aux2, i)
                            dataArray.SetValue(aux1, j)
                        Else
                            If laboratorio1 = laboratorio2 Then
                                If farmacia1 > farmacia2 Then
                                    dataArray.SetValue(aux2, i)
                                    dataArray.SetValue(aux1, j)
                                Else
                                    If farmacia1 = farmacia2 Then
                                        If estatus1 > estatus2 Then
                                            dataArray.SetValue(aux2, i)
                                            dataArray.SetValue(aux1, j)
                                        Else
                                            If estatus1 = estatus2 Then
                                                If fecha1 > fecha2 Then
                                                    dataArray.SetValue(aux2, i)
                                                    dataArray.SetValue(aux1, j)
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next j
                Next i
            End If
            htmlResult.Append(clsHTMLUtils.displayScroll(totalRows, intSelectedPage, Me._MAX_PER_PAGE, "DetalleReporteImagen.aspx", Nothing, , "../static/images/"))
            htmlResult.Append(clsHTMLUtils.displayArrayTable(headers, dataArray, columnOrder, actions, intSelectedPage, Me._MAX_PER_PAGE, -1, , "../static/images/", 20))
        End If
        'strDetalleImagen(dataArray)
        htmlResult.Append("<br>")
        htmlResult.Append("<input class=boton onclick=javascript:doSubmit('" + Me._IMPRIMIR + "') type=button value=Impresión name=btnImprimir>")
        htmlResult.Append("<input class=boton onclick=javascript:doSubmit('" + Me._EXPORTAR + "') type=button value=Exportar name=btnExportar>")
        Return htmlResult.ToString
    End Function

    '====================================================================
    ' Name       : strDetalleImagen
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function strDetalleImagen() As String
        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 1
        Dim strRecordBrowserName As String = "Ordenes"
        Dim htmlResult As String
        Dim valortrabajo As Integer
        Dim valortiempo, valorpromedio As String
        Dim minutos, horas, tprom, totalminutos As Integer
        Dim hrs As Double

        Dim intSelectedPage, totalRows As Integer
        Dim dataArray, elemArray, rowArray As Array
        Dim intEstatusId As String = "-1"
        Dim dtmConsultaOrdenInicio As String
        Dim dtmConsultaOrdenFinal As String
        Dim arrayItem As Array

        Dim intTipoReporteId As String
        Dim intTipoPagoId As String
        Dim intDireccionOperativaId As String
        Dim intZonaOperativaId As String
        Dim strLaboratoriosId As String
        Dim strFarmaciaId As String
        Dim intTipodeBusqueda As String
        Dim intColores As String
        Dim arrFecha() As String
        Dim j, i, contador As Integer

        dtmConsultaOrdenInicio = Request("dtmConsultaOrdenInicio")
        dtmConsultaOrdenFinal = Request("dtmConsultaOrdenFinal")
        If dtmConsultaOrdenInicio <> "" And dtmConsultaOrdenFinal <> "" Then
            If dtmConsultaOrdenInicio <> "" Then
                arrFecha = dtmConsultaOrdenInicio.Split(Chr(47))
                dtmConsultaOrdenInicio = arrFecha(1) + "/" + arrFecha(0) + "/" + arrFecha(2)
                dtmConsultaOrdenInicio = dtmConsultaOrdenInicio + " 00:00:00"
            End If
            If dtmConsultaOrdenFinal <> "" Then
                arrFecha = dtmConsultaOrdenFinal.Split(Chr(47))
                dtmConsultaOrdenFinal = arrFecha(1) + "/" + arrFecha(0) + "/" + arrFecha(2)
                dtmConsultaOrdenFinal = dtmConsultaOrdenFinal + " 23:59:59"
            End If
        Else
            dtmConsultaOrdenInicio = ""
            dtmConsultaOrdenFinal = ""
        End If
        intTipoReporteId = Request("intTipoReporteId")
        intTipoPagoId = Request("intTipoPagoId")
        intDireccionOperativaId = Request("intDireccionOperativaId")
        intZonaOperativaId = Request("intZonaOperativaId")
        strLaboratoriosId = Request("strLaboratoriosId")
        strFarmaciaId = Request("strFarmaciaId")
        intTipodeBusqueda = Request("intTipodeBusqueda")
        intColores = "1"

        If (Request("intTipodeBusqueda") = "1") Then
            If (Request("strLaboratoriosId") <> "-1") And Request("strLaboratoriosId") <> "" Then
                Dim LabsIds() As String
                Dim auxArray(0) As Array

                contador = 0
                LabsIds = Split(Request("strLaboratoriosId"), ",")
                If intTipoPagoId = "-1" Then
                    For j = 0 To LabsIds.Length - 1
                        arrayItem = clsServicesObj.strConsultarListado("REPORTEIMAGENTIEMPOSSINTIPOPAGO", Request, strConnectionString, Me.strUsuarioNombre, -1, -1, "'" + dtmConsultaOrdenInicio + "', '" + dtmConsultaOrdenFinal + "', " + intTipoReporteId + ", " + intTipoPagoId + ", " + intDireccionOperativaId + ", " + intZonaOperativaId + ", " + LabsIds(j) + ", " + strFarmaciaId + ", " + intTipodeBusqueda + ", 1")
                        If Not arrayItem Is Nothing AndAlso arrayItem.Length > 0 Then
                            contador = contador + 1
                            ReDim Preserve auxArray(contador)
                            auxArray.setValue(arrayItem.GetValue(0), contador - 1)
                        End If
                    Next j
                    ReDim Preserve auxArray(contador - 1)
                Else
                    For j = 0 To LabsIds.Length - 1
                        arrayItem = clsServicesObj.strConsultarListado("REPORTEIMAGENTIEMPOSSINTIPOPAGO", Request, strConnectionString, Me.strUsuarioNombre, -1, -1, "'" + dtmConsultaOrdenInicio + "', '" + dtmConsultaOrdenFinal + "', " + intTipoReporteId + ", " + intTipoPagoId + ", " + intDireccionOperativaId + ", " + intZonaOperativaId + ", " + LabsIds(j) + ", " + strFarmaciaId + ", " + intTipodeBusqueda + ", 1")
                        If Not arrayItem Is Nothing AndAlso arrayItem.Length > 0 Then
                            contador = contador + 1
                            ReDim Preserve auxArray(contador)
                            auxArray.setValue(arrayItem.GetValue(0), contador - 1)
                        End If
                    Next j
                    ReDim Preserve auxArray(contador - 1)
                End If
                dataArray = auxArray
                If Not dataArray Is Nothing AndAlso dataArray.Length > 0 Then
                    arrayItem = CType(dataArray.GetValue(0), Array)
                    arrayItem.SetValue(CStr(dataArray.Length), arrayItem.Length - 1)
                    dataArray.SetValue(arrayItem, 0)
                End If
            Else
                If intTipoPagoId = "-1" Then
                    dataArray = clsServicesObj.strConsultarListado("REPORTEIMAGENTIEMPOSSINTIPOPAGO", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
                Else
                    dataArray = clsServicesObj.strConsultarListado("REPORTEIMAGENTIEMPOS", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
                End If
            End If
        Else
            If (Request("strFarmaciaId") <> "-1") And Request("strFarmaciaId") <> "" Then
                Dim LabsIds() As String
                Dim auxArray(0) As Array


                contador = 0
                LabsIds = Split(Request("strFarmaciaId"), ",")
                If intTipoPagoId = "-1" Then
                    For j = 0 To LabsIds.Length - 1
                        arrayItem = clsServicesObj.strConsultarListado("REPORTEIMAGENTIEMPOSSINTIPOPAGO", Request, strConnectionString, Me.strUsuarioNombre, -1, -1, "'" + dtmConsultaOrdenInicio + "', '" + dtmConsultaOrdenFinal + "', " + intTipoReporteId + ", " + intTipoPagoId + ", " + intDireccionOperativaId + ", " + intZonaOperativaId + ", " + strLaboratoriosId + ", " + LabsIds(j) + ", " + intTipodeBusqueda + ", 1")
                        If Not arrayItem Is Nothing AndAlso arrayItem.Length > 0 Then
                            contador = contador + 1
                            ReDim Preserve auxArray(contador)
                            auxArray.setValue(arrayItem.GetValue(0), contador - 1)
                        End If
                    Next j
                    ReDim Preserve auxArray(contador - 1)
                Else
                    For j = 0 To LabsIds.Length - 1
                        arrayItem = clsServicesObj.strConsultarListado("REPORTEIMAGENTIEMPOS", Request, strConnectionString, Me.strUsuarioNombre, -1, -1, "'" + dtmConsultaOrdenInicio + "', '" + dtmConsultaOrdenFinal + "', " + intTipoReporteId + ", " + intTipoPagoId + ", " + intDireccionOperativaId + ", " + intZonaOperativaId + ", " + strLaboratoriosId + ", " + LabsIds(j) + ", " + intTipodeBusqueda + ", 1")
                        If Not arrayItem Is Nothing AndAlso arrayItem.Length > 0 Then
                            contador = contador + 1
                            ReDim Preserve auxArray(contador)
                            auxArray.setValue(arrayItem.GetValue(0), contador - 1)
                        End If
                    Next j
                    ReDim Preserve auxArray(contador - 1)
                End If
                dataArray = auxArray
                If Not dataArray Is Nothing AndAlso dataArray.Length > 0 Then
                    arrayItem = CType(dataArray.GetValue(0), Array)
                    arrayItem.SetValue(CStr(dataArray.Length), arrayItem.Length - 1)
                    dataArray.SetValue(arrayItem, 0)
                End If
            Else
                If intTipoPagoId = "-1" Then
                    dataArray = clsServicesObj.strConsultarListado("REPORTEIMAGENTIEMPOSSINTIPOPAGO", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
                Else
                    dataArray = clsServicesObj.strConsultarListado("REPORTEIMAGENTIEMPOS", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
                End If
            End If
        End If
        valortrabajo = 0
        If dataArray.Length > 1 Then
            For i = 0 To dataArray.Length - 1
                arrayItem = CType(dataArray.GetValue(i), Array)
                If CInt(arrayItem.GetValue(0)) <> 0 Then
                    valortrabajo = valortrabajo + CInt(arrayItem.GetValue(0))
                    totalminutos = totalminutos + CInt(arrayItem.GetValue(1))
                End If
            Next i
            If valortrabajo <> 0 Then
                minutos = CInt(totalminutos) Mod 60
                hrs = (CInt(totalminutos) - minutos) / 60
                horas = CInt(hrs)
                valortiempo = CStr(horas) + " Hrs. " + CStr(minutos) + " Mins."

                tprom = CInt(totalminutos / valortrabajo)
                minutos = tprom Mod 60
                hrs = (tprom - minutos) / 60
                horas = CInt(hrs)
                valorpromedio = CStr(horas) + " Hrs. " + CStr(minutos) + " Mins."
                htmlResult += "document.getElementById('divTrabajo').innerHTML=" + Chr(39) + CStr(valortrabajo) + Chr(39) + ";" + vbTab
                htmlResult += "document.getElementById('divTiempo').innerHTML=" + Chr(39) + CStr(valortiempo) + Chr(39) + ";" + vbTab
                htmlResult += "document.getElementById('divPromedio').innerHTML=" + Chr(39) + CStr(valorpromedio) + Chr(39) + ";" + vbTab
            End If
        Else
            rowArray = CType(dataArray.GetValue(0), Array)
            If CInt(rowArray.GetValue(0)) <> 0 Then
                If Not rowArray.GetValue(1) Is Nothing Then
                    minutos = CInt(rowArray.GetValue(1)) Mod 60
                    hrs = (CInt(rowArray.GetValue(1)) - minutos) / 60
                    horas = CInt(hrs)
                End If
                valortiempo = CStr(horas) + " Hrs. " + CStr(minutos) + " Mins."
                If Not rowArray.GetValue(2) Is Nothing Then
                    tprom = CInt(CDbl(rowArray.GetValue(1)) / CDbl(rowArray.GetValue(0)))
                    minutos = tprom Mod 60
                    hrs = (tprom - minutos) / 60
                    horas = CInt(hrs)
                End If
                valorpromedio = CStr(horas) + " Hrs. " + CStr(minutos) + " Mins."
            End If
            htmlResult += "document.getElementById('divTrabajo').innerHTML=" + Chr(39) + CStr(rowArray.GetValue(0)) + Chr(39) + ";" + vbTab
            htmlResult += "document.getElementById('divTiempo').innerHTML=" + Chr(39) + CStr(valortiempo) + Chr(39) + ";" + vbTab
            htmlResult += "document.getElementById('divPromedio').innerHTML=" + Chr(39) + CStr(valorpromedio) + Chr(39) + ";" + vbTab
        End If
        'htmlResult.Append("parent.parent.document.getElementById('divTrabajo').innerHTML='")
        'htmlResult.Append(rowArray.GetValue(0))
        'htmlResult.Append("';  ")
        'htmlResult.Append("parent.parent.document.getElementById('divTiempo').innerHTML='")
        'htmlResult.Append(CStr(valortiempo))
        'htmlResult.Append("';  ")
        'htmlResult.Append("parent.parent.document.getElementById('divPromedio').innerHTML='")
        'htmlResult.Append(CStr(valorpromedio))
        'htmlResult.Append("';  ")


        Return htmlResult
    End Function

    ''====================================================================
    '' Name       : strRecordBrowserHTMLSuc
    '' Description: Regresa el HTML del navegador de registros
    '' Accessor   : Read
    '' Throws     : Ninguna
    '' Output     : String
    ''====================================================================
    'Protected Function strRecordBrowserHTMLSuc() As String
    '    ' Declaramos e inicializamos las constantes locales
    '    Const intElementsPerPage As Integer = 1
    '    Dim strRecordBrowserName As String = "Ordenes"

    '    Dim dataArray As Array = Nothing

    '    ' Obtenemos los listados que ya se han capturado previamente.
    '    dataArray = clsServicesObj.strConsultarListado("SUCURSALLISTADODETALLE", Request, strConnectionString, strUsuarioNombre, -1, -1)


    '    Dim headers As ArrayList = New ArrayList()
    '    headers.Add("Laboratorio")
    '    headers.Add("Razón Social")
    '    '        headers.Add("Acciones")

    '    Dim columnOrder As Integer() = {0, 1}

    '    Dim actions As ArrayList = New ArrayList()
    '    Dim pkNames As String() = {"intSucursalId"}
    '    Dim pkIndexes As Integer() = {0}
    '    '       actions.Add(New clsActionLink(Me._EDITAR, pkNames, pkIndexes, "imgNRVer.gif", "Haga clic aquí para ver el Detalle de este Cliente"))


    '    Dim htmlResult As String = ""
    '    htmlResult += clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, -1, -1, -1, , "../static/images/")

    '    Return htmlResult
    'End Function

#End Region

#Region "metodos de la interface PrintInterface"

    '====================================================================
    ' Name       : strGenerarImpresion
    ' Description: Obtiene el html de la imrpesion.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Array
    '====================================================================
    Public Function strGenerarImpresion() As String
        Dim htmlResult As String = clsPrintUtil.printProcess(Me.getData(), Me)
        Return htmlResult
    End Function

    '====================================================================
    ' Name       : getData
    ' Description: Obtiene el arreglo de datos que se requiren para el listado.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Array
    '====================================================================
    Protected Overrides Function getData() As Array
        Dim htmlResult As StringBuilder = New StringBuilder()
        Dim intSelectedPage, totalRows As Integer
        Dim dataArray, elemArray As Array
        Const intElementsPerPage As Integer = 1
        Dim intEstatusId As String = "-1"
        Dim dtmConsultaOrdenInicio As String
        Dim dtmConsultaOrdenFinal As String

        Dim intTipoReporteId As String
        Dim intTipoPagoId As String
        Dim intDireccionOperativaId As String
        Dim intZonaOperativaId As String
        Dim strLaboratoriosId As String
        Dim strFarmaciaId As String
        Dim intTipodeBusqueda As String
        Dim intColores As String
        Dim i, j As Integer

        intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        If intSelectedPage <= 0 Then
            If IsNumeric(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request)) = True Then
                intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
                If intSelectedPage = -1 Then intSelectedPage = 1
            Else
                intSelectedPage = 1
            End If
        End If
        If strCmd = "1" Then
            intSelectedPage = 1
        End If

        Dim arrFecha() As String
        dtmConsultaOrdenInicio = Request("dtmConsultaOrdenInicio")
        dtmConsultaOrdenFinal = Request("dtmConsultaOrdenFinal")
        If dtmConsultaOrdenInicio <> "" And dtmConsultaOrdenFinal <> "" Then
            If dtmConsultaOrdenInicio <> "" Then
                arrFecha = dtmConsultaOrdenInicio.Split(Chr(47))
                dtmConsultaOrdenInicio = arrFecha(1) + "/" + arrFecha(0) + "/" + arrFecha(2)
                dtmConsultaOrdenInicio = dtmConsultaOrdenInicio + " 00:00:00"
            End If


            If dtmConsultaOrdenFinal <> "" Then
                arrFecha = dtmConsultaOrdenFinal.Split(Chr(47))
                dtmConsultaOrdenFinal = arrFecha(1) + "/" + arrFecha(0) + "/" + arrFecha(2)
                dtmConsultaOrdenFinal = dtmConsultaOrdenFinal + " 23:59:59"
            End If
        Else
            dtmConsultaOrdenInicio = ""
            dtmConsultaOrdenFinal = ""
        End If
        intTipoReporteId = Request("intTipoReporteId")
        intTipoPagoId = Request("intTipoPagoId")
        intDireccionOperativaId = Request("intDireccionOperativaId")
        intZonaOperativaId = Request("intZonaOperativaId")
        strLaboratoriosId = Request("strLaboratoriosId")
        strFarmaciaId = Request("strFarmaciaId")
        intTipodeBusqueda = Request("intTipodeBusqueda")
        intColores = "1"
        ' Obtenemos los listados que ya se han capturado previamente.  
        ' Obtenemos los listados que ya se han capturado previamente.
        If (Request("intTipodeBusqueda") = "1") Then
            If (Request("strLaboratoriosId") <> "-1") And Request("strLaboratoriosId") <> "" Then
                Dim LabsIds() As String
                Dim auxArray(0) As Array
                Dim arrayItem As Array
                Dim contador As Integer
                contador = 0
                LabsIds = Split(Request("strLaboratoriosId"), ",")
                If intTipoPagoId = "-1" Then
                    For j = 0 To LabsIds.Length - 1
                        arrayItem = clsServicesObj.strConsultarListado("REPORTEIMAGENSINTIPOPAGO", Request, strConnectionString, Me.strUsuarioNombre, -1, -1, "'" + dtmConsultaOrdenInicio + "', '" + dtmConsultaOrdenFinal + "', " + intTipoReporteId + ", " + intTipoPagoId + ", " + intDireccionOperativaId + ", " + intZonaOperativaId + ", " + LabsIds(j) + ", " + strFarmaciaId + ", " + intTipodeBusqueda + ", 1")
                        If Not arrayitem Is Nothing AndAlso arrayItem.Length > 0 Then
                            contador = auxArray.Length - 1
                            ReDim Preserve auxArray(contador + arrayItem.Length)
                            For i = 0 To arrayitem.Length - 1
                                auxArray.setValue(arrayItem.GetValue(i), contador + i)
                            Next i
                        End If
                    Next j
                    ReDim Preserve auxArray(auxArray.Length - 2)
                Else
                    For j = 0 To LabsIds.Length - 1
                        arrayItem = clsServicesObj.strConsultarListado("REPORTEIMAGEN", Request, strConnectionString, Me.strUsuarioNombre, -1, -1, "'" + dtmConsultaOrdenInicio + "', '" + dtmConsultaOrdenFinal + "', " + intTipoReporteId + ", " + intTipoPagoId + ", " + intDireccionOperativaId + ", " + intZonaOperativaId + ", " + LabsIds(j) + ", " + strFarmaciaId + ", " + intTipodeBusqueda + ", 1")
                        If Not arrayitem Is Nothing AndAlso arrayItem.Length > 0 Then
                            contador = auxArray.Length - 1
                            ReDim Preserve auxArray(contador + arrayItem.Length)
                            For i = 0 To arrayitem.Length - 1
                                auxArray.setValue(arrayItem.GetValue(i), contador + i)
                            Next i
                        End If
                    Next j
                    ReDim Preserve auxArray(auxArray.Length - 2)
                End If
                dataArray = auxArray
                If Not dataArray Is Nothing AndAlso dataArray.Length > 0 Then
                    arrayItem = CType(dataArray.GetValue(0), Array)
                    arrayItem.SetValue(CStr(dataArray.Length), arrayItem.Length - 1)
                    dataArray.SetValue(arrayItem, 0)
                End If
            Else
                If intTipoPagoId = "-1" Then
                    dataArray = clsServicesObj.strConsultarListado("REPORTEIMAGENSINTIPOPAGO", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
                Else
                    dataArray = clsServicesObj.strConsultarListado("REPORTEIMAGEN", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
                End If
            End If
        Else
            If (Request("strFarmaciaId") <> "-1") And Request("strFarmaciaId") <> "" Then
                Dim LabsIds() As String
                Dim auxArray(0) As Array
                Dim arrayItem As Array
                Dim contador As Integer
                contador = 0
                LabsIds = Split(Request("strFarmaciaId"), ",")
                If intTipoPagoId = "-1" Then
                    For j = 0 To LabsIds.Length - 1
                        arrayItem = clsServicesObj.strConsultarListado("REPORTEIMAGENSINTIPOPAGO", Request, strConnectionString, Me.strUsuarioNombre, -1, -1, "'" + dtmConsultaOrdenInicio + "', '" + dtmConsultaOrdenFinal + "', " + intTipoReporteId + ", " + intTipoPagoId + ", " + intDireccionOperativaId + ", " + intZonaOperativaId + ", " + strLaboratoriosId + ", " + LabsIds(j) + ", " + intTipodeBusqueda + ", 1")
                        If Not arrayitem Is Nothing AndAlso arrayItem.Length > 0 Then
                            contador = auxArray.Length - 1
                            ReDim Preserve auxArray(contador + arrayItem.Length)
                            For i = 0 To arrayitem.Length - 1
                                auxArray.setValue(arrayItem.GetValue(i), contador + i)
                            Next i
                        End If
                    Next j
                    ReDim Preserve auxArray(auxArray.Length - 2)
                Else
                    For j = 0 To LabsIds.Length - 1
                        arrayItem = clsServicesObj.strConsultarListado("REPORTEIMAGEN", Request, strConnectionString, Me.strUsuarioNombre, -1, -1, "'" + dtmConsultaOrdenInicio + "', '" + dtmConsultaOrdenFinal + "', " + intTipoReporteId + ", " + intTipoPagoId + ", " + intDireccionOperativaId + ", " + intZonaOperativaId + ", " + strLaboratoriosId + ", " + LabsIds(j) + ", " + intTipodeBusqueda + ", 1")
                        If Not arrayitem Is Nothing AndAlso arrayItem.Length > 0 Then
                            contador = auxArray.Length - 1
                            ReDim Preserve auxArray(contador + arrayItem.Length)
                            For i = 0 To arrayitem.Length - 1
                                auxArray.setValue(arrayItem.GetValue(i), contador + i)
                            Next i
                        End If
                    Next j
                    ReDim Preserve auxArray(auxArray.Length - 2)
                End If
                dataArray = auxArray
                If Not dataArray Is Nothing AndAlso dataArray.Length > 0 Then
                    arrayItem = CType(dataArray.GetValue(0), Array)
                    arrayItem.SetValue(CStr(dataArray.Length), arrayItem.Length - 1)
                    dataArray.SetValue(arrayItem, 0)
                End If
            Else
                If intTipoPagoId = "-1" Then
                    dataArray = clsServicesObj.strConsultarListado("REPORTEIMAGENSINTIPOPAGO", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
                Else
                    dataArray = clsServicesObj.strConsultarListado("REPORTEIMAGEN", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
                End If
            End If
        End If

        Dim aux1, aux2 As Array
        Dim laboratorio1, laboratorio2 As String
        Dim farmacia1, farmacia2 As String
        Dim estatus1, estatus2 As Integer
        Dim fecha1, fecha2 As DateTime
        'Prueba.Sort(dataArray, )

        If Not dataArray Is Nothing AndAlso dataArray.Length > 0 Then
            For i = 0 To dataArray.Length - 1
                For j = i + 1 To dataArray.Length - 1
                    'If dataArray.GetValue(i, 3) > dataArray.GetValue(j, 3) Then
                    aux1 = CType(dataArray.GetValue(i), Array)
                    aux2 = CType(dataArray.GetValue(j), Array)
                    laboratorio1 = CType(aux1.GetValue(0), String)
                    laboratorio2 = CType(aux2.GetValue(0), String)
                    farmacia1 = CType(aux1.GetValue(1), String)
                    farmacia2 = CType(aux2.GetValue(1), String)
                    estatus1 = CType(aux1.GetValue(13), Integer)
                    estatus2 = CType(aux2.GetValue(13), Integer)
                    Try
                        fecha1 = CType(aux1.GetValue(4), DateTime)
                        fecha2 = CType(aux2.GetValue(4), DateTime)
                    Catch
                        Dim auxiliar1, auxiliar2 As String
                        Dim arrFecha1() As String
                        auxiliar1 = CType(aux1.GetValue(4), String)
                        auxiliar2 = CType(aux2.GetValue(4), String)
                        arrFecha1 = auxiliar1.Split(Chr(47))
                        auxiliar1 = arrFecha1(1) + "/" + arrFecha1(0) + "/" + arrFecha1(2)
                        arrFecha1 = auxiliar2.Split(Chr(47))
                        auxiliar2 = arrFecha1(1) + "/" + arrFecha1(0) + "/" + arrFecha1(2)
                        fecha1 = CType(auxiliar1, DateTime)
                        fecha2 = CType(auxiliar2, DateTime)
                    End Try
                    If laboratorio1 > laboratorio2 Then
                        dataArray.SetValue(aux2, i)
                        dataArray.SetValue(aux1, j)
                    Else
                        If laboratorio1 = laboratorio2 Then
                            If farmacia1 > farmacia2 Then
                                dataArray.SetValue(aux2, i)
                                dataArray.SetValue(aux1, j)
                            Else
                                If farmacia1 = farmacia2 Then
                                    If estatus1 > estatus2 Then
                                        dataArray.SetValue(aux2, i)
                                        dataArray.SetValue(aux1, j)
                                    Else
                                        If estatus1 = estatus2 Then
                                            If fecha1 > fecha2 Then
                                                dataArray.SetValue(aux2, i)
                                                dataArray.SetValue(aux1, j)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next j
            Next i
        End If

        Return dataArray
    End Function


    '====================================================================
    ' Name       : getHeaders
    ' Description: Forma HTML con el header para el listado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function getHeaders() As String
        Dim code As StringBuilder = New StringBuilder()
        Dim widths As String() = {"13%", "12%", "7%", "7%", "7%", "7%", "7%", "7%", "7%", "7%", "7%", "7%", "7%"}
        Dim values As String() = {"Laboratorio", "Farmacia", "Orden", "Estatus", "Fecha Ingresada", "Fecha Entregada Ingresada", "Fecha En Proceso", "Fecha Terminada", "Fecha Entregada Terminada", "Fecha Recibida", "Fecha De Pago", "Tiempo Del Proceso", "Tiempo Del Ciclo"}
        code.Append(clsHTMLUtils.getTagTR("th", 3, "rayita", "txcont", widths, values))
        Return code.ToString
    End Function

    '====================================================================
    ' Name       : getTitle
    ' Description: Forma HTML con el titulo para el listado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function getTitle(ByVal currentPage As Integer, ByVal totalPages As Integer) As String
        Dim code As StringBuilder = New StringBuilder()
        Dim widths As String() = {"70%", "10%", "20%"}
        Dim styles As String() = {"txtitulo", "txcontenidobold", "txcontenidobold"}
        Dim values1 As String() = {"Reporte de Imagen", "", "HOJA: " + currentPage.ToString + " / " + totalPages.ToString}
        Dim values2 As String() = {"", "", "Fecha: " + Today.ToString(clsDateUtil.DATE_FORMAT)}

        code.Append(clsHTMLUtils.BEGIN_TABLE)
        code.Append(clsHTMLUtils.getTagTR("td", 13, styles, widths, values1))
        code.Append(clsHTMLUtils.getTagTR("td", 13, "txcontenidobold", widths, values2))
        code.Append(clsHTMLUtils.END_TABLE)

        Return code.ToString
    End Function

    '====================================================================
    ' Name       : getRow
    ' Description: Forma HTML para desplegar un renglon del listado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function getRow(ByVal aRow As Array, ByVal globalRowCounter As Integer) As String
        Dim colsToShow As Integer() = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}
        Return clsPrintUtil.getSimpleRow(aRow, colsToShow)
    End Function

    '====================================================================
    ' Name       : getFooter
    ' Description: Forma HTML con el pie de listado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function getFooter() As String
        Return ""
    End Function

    '====================================================================
    ' Name       : getColumnNumber
    ' Description: Regresa el numero de columnas
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Protected Overrides Function getColumnNumber() As Integer
        Return 3
    End Function



#End Region


End Class

