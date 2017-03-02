'====================================================================
' Class         : clsConsultaOrdenes
' Title         : Grupo Benavides. Catálogo de Artículos (trabajos)
' Description   : Captura de Artículos
' Copyright     : 2003-2006 All rights reserved.
' Company       : Neitek Solutions S.A. de C.V.
' Author        : Jorge Ventura Cantu Campos
' Version       : 1.0
' Last Modified : Wednesday, February 9Th, 2005
'====================================================================

#Region "Imports"
Imports System.Text
Imports System.Collections
Imports prjFotolabBusiness.Benavides.Fotolab.Utils
Imports prjFotolabBusiness.Benavides.Fotolab.Data
#End Region

Public Class clsReporteImagen
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
    Protected _strSucursalNombre As String
    Protected _strSearch As String

    Protected _inttotalreg As Integer
    Protected _intOrdenId As Integer
    Protected _intSucursalIdDetalle As String
    Protected _intCompaniaIdDetalle As String
    Protected _strSucursalccsss As String
    Protected _strSucursalRazonSocial As String
    Protected _strSucursalZonaOperativa As String
    Protected _intlistacontador As Integer

    Protected _intDireccionOperativaId As Integer

    '====================================================================
    ' Name       : intlistacontador
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intlistacontador() As Integer
        Get
            Return _intlistacontador
        End Get
        Set(ByVal strValue As Integer)
            _intlistacontador = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intOrdenId
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intOrdenId() As Integer
        Get
            Return _intOrdenId
        End Get
        Set(ByVal strValue As Integer)
            _intOrdenId = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : intDireccionOperativaId
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intDireccionOperativaId() As Integer
        Get
            Return _intDireccionOperativaId
        End Get
        Set(ByVal strValue As Integer)
            _intDireccionOperativaId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : _strSucursalRazonSocial
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strSucursalRazonSocial() As String
        Get
            Return _strSucursalRazonSocial
        End Get
        Set(ByVal strValue As String)
            _strSucursalRazonSocial = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strSucursalccsss
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strSucursalccsss() As String
        Get
            Return _strSucursalccsss
        End Get
        Set(ByVal strValue As String)
            _strSucursalccsss = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intSucursalIdDetalle
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intSucursalIdDetalle() As String
        Get
            Return _intSucursalIdDetalle
        End Get
        Set(ByVal strValue As String)
            _intSucursalIdDetalle = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intCompaniaIdDetalle
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intCompaniaIdDetalle() As String
        Get
            Return _intCompaniaIdDetalle
        End Get
        Set(ByVal strValue As String)
            _intCompaniaIdDetalle = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strSucursalZonaOperativa
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strSucursalZonaOperativa() As String
        Get
            Return _strSucursalZonaOperativa
        End Get
        Set(ByVal strValue As String)
            _strSucursalZonaOperativa = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strSearch 
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strSearch() As String
        Get
            Return _strSearch
        End Get
        Set(ByVal strValue As String)
            _strSearch = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strSucursalNombre
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strSucursalNombre() As String
        Get
            Return _strSucursalNombre
        End Get
        Set(ByVal strValue As String)
            _strSucursalNombre = strValue
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
        'Dim pkNames As String() = {"intOrdenId"}
        'Dim pkIndexes As Integer() = {2}
        ''If intEstatusId <> "7" Then
        'actions.Add(New clsActionLink(Me._EDITAR, pkNames, pkIndexes, "imgNRBorrar.gif", "Haga clic aquí para ver Cancelar la Orden"))
        'End If

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
            htmlResult.Append(clsHTMLUtils.displayScroll(totalRows, intSelectedPage, Me._MAX_PER_PAGE, "ReporteImagen.aspx", Nothing, , "../static/images/"))
            htmlResult.Append(clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, intSelectedPage, Me._MAX_PER_PAGE, -1, , "../static/images/", False, 30))
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
                        fecha1 = CType(aux1.GetValue(4), DateTime)
                        fecha2 = CType(aux2.GetValue(4), DateTime)
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
            htmlResult.Append(clsHTMLUtils.displayScroll(totalRows, intSelectedPage, Me._MAX_PER_PAGE, "ReporteImagen.aspx", Nothing, , "../static/images/"))
            htmlResult.Append(clsHTMLUtils.displayArrayTable(headers, dataArray, columnOrder, actions, intSelectedPage, Me._MAX_PER_PAGE, -1, , "../static/images/", 30))
        End If
        strDetalleImagen(dataArray)
        htmlResult.Append("<br>")
        htmlResult.Append("<input class=boton onclick=javascript:doSubmit('" + Me._IMPRIMIR + "') type=button value=Impresión name=btnImprimir>")
        htmlResult.Append("<input class=boton onclick=javascript:doSubmit('" + Me._EXPORTAR + "') type=button value=Exportar name=btnExportar>")
        Return htmlResult.ToString
    End Function

    '====================================================================
    ' Name       : strParametros
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function strParametros() As String
        Dim params As StringBuilder = New StringBuilder()
        Dim i As Integer
        Dim paramName As String
        Dim paramValue As String
        Dim aux() As String = Request.Params.AllKeys()

        For i = 0 To aux.Length - 1
            If Not aux(i).IndexOf("_") > 0 And Not aux(i).Equals("strCmd") Then
                params.Append("&")
                params.Append(aux(i))
                params.Append("=")
                params.Append(Request.Params.Item(aux(i)))
            End If
        Next
        Return params.ToString
    End Function
    '====================================================================
    ' Name       : strRecordBrowserHTMLSuc
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function strDetalleImagen(ByVal dataArray As Array) As String
        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 1
        Dim strRecordBrowserName As String = "Ordenes"
        Dim htmlResult As String
        Dim valortrabajo, i As Integer
        Dim valortiempo, valorpromedio As DateTime
        Dim aux1 As Array
        Dim tiempo As DateTime

        For i = 0 To dataArray.Length - 1
            aux1 = CType(dataArray.GetValue(i), Array)
            If Not aux1.GetValue(11) Is Nothing Then
                tiempo = CType(aux1.GetValue(11), DateTime)
            End If
        Next i
        htmlResult += "parent.parent.document.getElementById('divTrabajo').innerHTML=" + Chr(39) + CStr(valortrabajo) + Chr(39) + ";" + vbTab
        htmlResult += "parent.parent.document.getElementById('divTiempo').innerHTML=" + Chr(39) + CStr(valortiempo) + Chr(39) + ";" + vbTab
        htmlResult += "parent.parent.document.getElementById('divPromedio').innerHTML=" + Chr(39) + CStr(valorpromedio) + Chr(39) + ";" + vbTab

        Return htmlResult
    End Function

    '====================================================================
    ' Name       : obtenerCombo Laboratorio
    ' Description: construye el combo de Laboratorios
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : html del Combo
    '====================================================================
    Protected Function obtenerComboLaboratorio() As String
        Dim dataArray As Array = Nothing
        Dim htmlCombo As String
        dataArray = clsServicesObj.strConsultarListado("LABORATORIO", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
        htmlCombo = prjFotolabBusiness.Benavides.Fotolab.Utils.clsHTMLUtils.buildCombo(dataArray, "cmbSucursal", 4, "comboTabla", "", True, "- Todos -", "")
        htmlCombo = " parent.parent.document.getElementById('divSucursal').innerHTML=" + Chr(34) + htmlCombo + Chr(34) + ";"
        Return htmlCombo
    End Function

    '====================================================================
    ' Name       : strOtraAccion
    ' Description: Metodo llamado cuando  el strCmd es una accion nueva (esta libre a implementar en cada clase para metodos especiales)
    ' Parameters : 
    '              ByVal strCmd As  String
    '                 - Nombre del  comando a efectuar  
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function strOtraAccion(ByVal strCmd As String) As String
        Dim htmlResult As String
        Select Case strCmd
            Case "LABORATORIO"
                htmlResult = Me.obtenerComboLaboratorio()
        End Select

        Return htmlResult
    End Function

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
        Dim dataArray As Array = Nothing
        If (Request("strCliente") = "") Then
            If (Request("strLaboratoriosId") <> "-1") And Request("strLaboratoriosId") <> "" Then
                Dim LabsIds() As String
                Dim auxArray(0) As Array
                Dim arrayItem As Array
                Dim j As Integer
                LabsIds = Split(Request("strLaboratoriosId"), ",")
                For j = 0 To LabsIds.Length - 1
                    ReDim Preserve auxArray(j)
                    arrayItem = clsServicesObj.strConsultarListado("TRAERLISTADOPORIDS", Request, strConnectionString, Me.strUsuarioNombre, -1, -1, LabsIds(j) + " ,2")
                    auxArray.SetValue(arrayItem.GetValue(0), j)
                Next j
                dataArray = auxArray

                'arrayItem = CType(dataArray.GetValue(0), Array)
                'arrayItem.SetValue(CStr(dataArray.Length), arrayItem.Length - 1)
                'dataArray.SetValue(arrayItem, 0)

            ElseIf (Request("intZonaOperativaId") <> "-1") And (Request("intZonaOperativaId") <> "") Then
                dataArray = clsServicesObj.strConsultarListado("TRAERLISTADOPORZONA", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
            ElseIf (Request("intDireccionOperativaId") <> "-1") And (Request("intDireccionOperativaId") <> "") Then
                dataArray = clsServicesObj.strConsultarListado("TRAERLISTADOPORDIR", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
            Else
                dataArray = clsServicesObj.strConsultarListado("TRAERLISTADOADMIN", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
            End If

        Else
            dataArray = clsServicesObj.strConsultarListado("TRAERLISTADOCRITERIOADMIN", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)

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
        Dim widths As String() = {"30%", "70%"}
        Dim values As String() = {"Laboratorio", "Razón Social"}
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
        Dim values1 As String() = {" Reporte de Articulos", "", "HOJA: " + currentPage.ToString + " / " + totalPages.ToString}
        Dim values2 As String() = {"", "", "Fecha: " + Today.ToString(clsDateUtil.DATE_FORMAT)}

        code.Append(clsHTMLUtils.BEGIN_TABLE)
        code.Append(clsHTMLUtils.getTagTR("td", 3, styles, widths, values1))
        code.Append(clsHTMLUtils.getTagTR("td", 3, "txcontenidobold", widths, values2))
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
        Dim colsToShow As Integer() = {0, 1}
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


