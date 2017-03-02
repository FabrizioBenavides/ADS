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

Public Class clsConsultaOrdenesAdmin
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
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsConsultaOrdenes.SERVICIOS
    End Sub

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
        htmlCombo = prjFotolabBusiness.Benavides.Fotolab.Utils.clsHTMLUtils.buildCombo(dataArray, "cmbLaboratorio", 4, "comboTabla", "", True, "- Todos -", "javascript:selectRadio()")
        htmlCombo = " parent.parent.document.all.divLaboratorio.innerHTML=" + Chr(34) + htmlCombo + Chr(34) + ";"
        Return htmlCombo
    End Function



    '====================================================================
    ' Name       : cambiarLaboratorio
    ' Description: construye el combo de Laboratorios
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : html del Combo
    '====================================================================
    Protected Sub cambiarLaboratorio()
       
        Dim dataArray As Array

        dataArray = clsServicesObj.strConsultarListado("CambiarLaboratorio", Request, strConnectionString, Me.strUsuarioNombre, 1, 1)

        clsServicesObj.strAfectarListado("CambiarLaboratorio", Request, strConnectionString, Me.strUsuarioNombre)

    End Sub
    '====================================================================
    ' Name       : strGenerarlistado
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function strGenerarlistado(ByVal strCmd As String) As String
        Dim htmlResult As StringBuilder = New StringBuilder
        Dim intSelectedPage, totalRows As Integer
        Dim dataArray, elemArray As Array
        Const intElementsPerPage As Integer = 1

        Dim intEstatusId As String = "-1"


        intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        If intSelectedPage <= 0 Then
            'intSelectedPage = 1
            If IsNumeric(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request)) = True Then
                intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
                If intSelectedPage < 0 Then intSelectedPage = 1
            Else
                intSelectedPage = 1
            End If
        End If

        ' Obtenemos los listados que ya se han capturado previamente.  

        intEstatusId = Request("intEstatusId")
        'dataArray = clsServicesObj.strConsultarListado(Me._TRAER_LISTADO, Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, Me._MAX_PER_PAGE, "'" + strOrden + "', '" + dtmConsultaOrdenInicio + "', '" + dtmConsultaOrdenFinal + "', " + CStr(intEstatusId) + ", " + CStr(intDireccionOperativaId) + ", " + CStr(intZonaOperativaId) + ", '" + strLaboratoriosId + "'")
        dataArray = clsServicesObj.strConsultarListado(Me._TRAER_LISTADO, Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, Me._MAX_PER_PAGE)
        Dim headers As ArrayList = New ArrayList
        headers.Add("&nbsp;")
        headers.Add("Estatus")
        headers.Add("Orden")
        headers.Add("Farmacia")
        headers.Add("Laboratorio")
        headers.Add("Fecha y Hora<br>Ingreso")
        headers.Add("Fecha y Hora<br>Compromiso")
        headers.Add("Acciones")

        Dim columnOrder As Integer() = {9, 0, 1, 3, 2, 4, 5}

        Dim actions As ArrayList = New ArrayList
        Dim pkNames As String() = {"IntOrdenId"}
        Dim pkIndexes As Integer() = {7}
        actions.Add(New clsActionLink(Me._EDITAR, pkNames, pkIndexes, "imgNRVer.gif", "Haga clic aquí para ver el Detalle de este Cliente"))
        If intEstatusId <> "7" Then
            actions.Add(New clsActionLink(Me._BORRAR, pkNames, pkIndexes, "imgNRBorrar.gif", "Haga clic aquí para ver Cancelar la Orden"))
        End If

        'por medio de estas validaciones obtengo el número total de registros  que  regreso la búsqueda
        'no necesariamente es la longitud de mi Array (debido a la paginación), este dato del total por búsqueda esta contenido en la utlima columna
        'de cada uno de mis registros, cuando no tengo este dato, el númerototal de registros el el total de elementos del arreglo
        If dataArray.Length > 0 Then
            elemArray = DirectCast(dataArray.GetValue(0), Array)
            If IsNumeric(elemArray.GetValue(elemArray.Length - 1)) Then '<- verifico si tiene un númeroel la ultima columna
                totalRows = CInt(elemArray.GetValue(elemArray.Length - 1)) ' lo asigno este valor a mi var de total de registros
            Else
                totalRows = dataArray.Length ' si no  tengo el valor de total de reg en mi ultima columna asigno el total de elementos del arreglo como el total
            End If
        End If
        htmlResult.Append(clsHTMLUtils.displayScroll(totalRows, intSelectedPage, Me._MAX_PER_PAGE, "ConsultaOrdenesAdmin.aspx", Nothing, , "../static/images/"))
        htmlResult.Append(clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, intSelectedPage, Me._MAX_PER_PAGE, -1, , "../static/images/", False, 16))
        htmlResult.Append("<br>")
        htmlResult.Append("<input class=boton onclick=javascript:doSubmit('" + Me._IMPRIMIR + "') type=button value=Impresión name=btnImprimir>")
        htmlResult.Append("<input class=boton onclick=javascript:doSubmit('" + Me._EXPORTAR + "') type=button value=Exportar name=btnExportar>")
        Return htmlResult.ToString
    End Function

    '====================================================================
    ' Name       : strRecordBrowserHTMLSuc
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function strRecordBrowserHTMLSuc() As String
        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 1
        Dim strRecordBrowserName As String = "Ordenes"

        Dim dataArray As Array = Nothing

        ' Obtenemos los listados que ya se han capturado previamente.
        dataArray = clsServicesObj.strConsultarListado("SUCURSALLISTADODETALLE", Request, strConnectionString, strUsuarioNombre, -1, -1)


        Dim headers As ArrayList = New ArrayList
        headers.Add("Laboratorio")
        headers.Add("Razón Social")
        '        headers.Add("Acciones")

        Dim columnOrder As Integer() = {0, 1}

        Dim actions As ArrayList = New ArrayList
        Dim pkNames As String() = {"intSucursalId"}
        Dim pkIndexes As Integer() = {0}
        '       actions.Add(New clsActionLink(Me._EDITAR, pkNames, pkIndexes, "imgNRVer.gif", "Haga clic aquí para ver el Detalle de este Cliente"))


        Dim htmlResult As String = ""
        htmlResult += clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, -1, -1, -1, , "../static/images/")

        Return htmlResult
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
            Case "CambiarLaboratorio"
                Me.cambiarLaboratorio()

        End Select

        Return htmlResult
    End Function

    '====================================================================
    ' Name       : strGenerarlistado
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function strGenerarlistadoTrabajos(ByVal strCmd As String) As String

        Dim htmlResult As StringBuilder = New StringBuilder
        Dim intSelectedPage, totalRows As Integer
        Dim dataArray, elemArray As Array
        Const intElementsPerPage As Integer = 1
        Dim intTotalRegistros1 As Integer
        Dim strRecordBrowserName As String = "Trabajos"


        ' Obtenemos los listados que ya se han capturado previamente.                                                                                           
        dataArray = clsServicesObj.strConsultarListado("TRAERLISTADOTRABAJOS", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
        Dim columnOrder As Integer() = {12, 2, 6, 7, 8, 9}
        Dim headers As ArrayList = New ArrayList
        headers.Add("Id Trabajo")
        headers.Add("Trabajo")
        headers.Add("Cantidad")
        headers.Add("Precio x Foto")
        headers.Add("Revelado")
        headers.Add("Importe")

        Dim pkNames As String() = {"IntOrdenTrabajoId"}
        Dim pkIndexes As Integer() = {0}
      
        ' por medio de estas validaciones obtengo el número total de registros  que  regreso la búsqueda
        ' no necesariamente es la longitud de mi Array (debido a la paginación), este dato del total por búsqueda esta contenido en la utlima columna
        ' de cada uno de mis registros, cuando no tengo este dato, el númerototal de registros el el total de elementos del arreglo
        If dataArray.Length > 0 Then
            elemArray = DirectCast(dataArray.GetValue(0), Array)
            If IsNumeric(elemArray.GetValue(elemArray.Length - 1)) Then '<- verifico si tiene un númeroel la ultima columna
                totalRows = CInt(elemArray.GetValue(elemArray.Length - 1)) ' lo asigno este valor a mi var de total de registros
            Else
                totalRows = dataArray.Length ' si no  tengo el valor de total de reg en mi ultima columna asigno el total de elementos del arreglo como el total
            End If
        End If
        htmlResult.Append("<p><span class='txsubtitulo'><br>")
        htmlResult.Append("<img src='../static/images/bullet_subtitulos.gif' width=17 height=11 align=absMiddle> Listado de Trabajos </span> </p>")
        htmlResult.Append(clsHTMLUtils.displayTable(headers, dataArray, columnOrder, Nothing, -1, -1, -1, , "../static/images/"))
        Return htmlResult.ToString
    End Function

    '====================================================================
    ' Name       : strDesplegarValores
    ' Description: despliega los valores de la forma
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Nothing
    '====================================================================
    Protected Overrides Function strDesplegarValores(ByVal arrValues As Array) As String
        If arrValues.Length > 0 Then
            Dim htmlResult As String
            Dim rowArray As Array
            rowArray = CType(arrValues.GetValue(0), Array)

            Dim anticipoLbl As String = CStr(rowArray.GetValue(10)) 'string de que si es anticipo o liquidacion en caso de Orden Normal
            Dim anticipoValor As Double = CDbl(rowArray.GetValue(11)) 'valor del anticipo o liquidacion
            Dim anticipoValFormat As String = Format(anticipoValor, "###,##0.00") 'formatear valor del anticipo
            ' o valor del anticipo o liquidacion (prepago) en caso de orden digital

            Dim esPrepagado As String = CStr(rowArray.GetValue(12))
            Dim esDigital As Boolean = CBool(rowArray.GetValue(13)) 'es orden digital o normal

            If esDigital Then
                'si esta prepagado y el valor de anticipo es mayor a cero, entonces es LIQUIDACION
                If esPrepagado.Equals("Prepagada") Then
                    anticipoLbl = "Pagada:"
                End If
            End If

            htmlResult += " parent.parent.document.getElementById('divDatoLaboratorio').innerHTML=" + Chr(39) + CStr(rowArray.GetValue(2)) + Chr(39) + ";" + vbTab
            htmlResult += "	parent.parent.document.getElementById('divDatoCliente').innerHTML=" + Chr(39) + CStr(rowArray.GetValue(3)) + Chr(39) + ";" + vbTab
            htmlResult += "	parent.parent.document.getElementById('divDatoOrden').innerHTML=" + Chr(39) + CStr(rowArray.GetValue(1)) + Chr(39) + ";" + vbTab
            htmlResult += "	parent.parent.document.getElementById('IntOrdenId').value=" + Chr(39) + CStr(rowArray.GetValue(1)) + Chr(39) + ";" + vbTab
            htmlResult += " parent.parent.document.getElementById('divDatoEstatus').innerHTML=" + Chr(39) + CStr(rowArray.GetValue(0)) + Chr(39) + ";" + vbTab
            htmlResult += "	parent.parent.document.getElementById('divDatoFecha').innerHTML=" + Chr(39) + CStr(rowArray.GetValue(4)) + Chr(39) + ";" + vbTab
            htmlResult += "	parent.parent.document.getElementById('divFormatoRollo').innerHTML=" + Chr(39) + CStr(rowArray.GetValue(14)) + Chr(39) + ";" + vbTab

            htmlResult += " parent.parent.document.getElementById('divDatoAnticipoLbl').innerHTML=" + Chr(39) + anticipoLbl + Chr(39) + ";" + vbTab
            htmlResult += " parent.parent.document.getElementById('divDatoAnticipo').innerHTML=" + Chr(39) + "$" + anticipoValFormat + Chr(39) + ";" + vbTab

            If esDigital Then
                'mostrar valor orden digital
                htmlResult += " parent.parent.document.getElementById('divPrepagoLbl').innerHTML='Tipo de Orden:';" + vbTab
                htmlResult += " parent.parent.document.getElementById('divDatoPrepago').innerHTML='INTERNET - " + esPrepagado + "';" + vbTab
            Else
                'mostrar valor orden normal         
                htmlResult += " parent.parent.document.getElementById('divPrepagoLbl').innerHTML='Tipo de Orden:';" + vbTab
                htmlResult += " parent.parent.document.getElementById('divDatoPrepago').innerHTML='Normal';" + vbTab
            End If

            htmlResult += "	parent.parent.document.getElementById('divFechaModificado').innerHTML=" + Chr(39) + CStr(rowArray.GetValue(8)) + Chr(39) + ";" + vbTab
            htmlResult += " parent.parent.document.getElementById('divModificadoPor').innerHTML=" + Chr(39) + CStr(rowArray.GetValue(9)) + Chr(39) + ";" + vbTab
            intOrdenId = CInt(rowArray.GetValue(7))
            'htmlResult += "	parent.parent.document.getElementById('divRecordBrowserHTMLSuc').innerHTML=" + Chr(34) + Me.strRecordBrowserHTMLSuc() + Chr(34) + ";" + vbTab
            Return htmlResult

        Else
            Return ""
        End If
    End Function

    '====================================================================
    ' Name       : strDesplegarValoresDetalle
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function strDesplegarValoresDetalle() As String
        Dim htmlResult As StringBuilder = New StringBuilder
        Dim dataArray, rowArray As Array

        dataArray = clsServicesObj.strConsultarListado("TRAERDETALLETRABAJO", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
        If dataArray.Length > 0 Then
            rowArray = CType(dataArray.GetValue(0), Array)
            htmlResult.Append("parent.parent.document.getElementById('divTrabajo').innerHTML='")
            htmlResult.Append(rowArray.GetValue(22))
            htmlResult.Append("';  ")
            htmlResult.Append("parent.parent.document.getElementById('divDescripcion').innerHTML='")
            htmlResult.Append(rowArray.GetValue(2))
            htmlResult.Append("';  ")
            htmlResult.Append("parent.parent.document.getElementById('divCantidad').innerHTML='")
            htmlResult.Append(rowArray.GetValue(16))
            htmlResult.Append("';  ")
            htmlResult.Append("parent.parent.document.getElementById('divPrecio').innerHTML='$")
            htmlResult.Append(Format(CDec(rowArray.GetValue(17)), "###,##0.00"))
            htmlResult.Append("';  ")
            htmlResult.Append("parent.parent.document.getElementById('divImporte').innerHTML='$")
            htmlResult.Append(Format(CDec(rowArray.GetValue(19)), "###,##0.00"))
            htmlResult.Append("';  ")
            htmlResult.Append("parent.parent.document.getElementById('divMarca').innerHTML='")
            htmlResult.Append(rowArray.GetValue(4))
            htmlResult.Append("';  ")
            htmlResult.Append("parent.parent.document.getElementById('divNumeroFotos').innerHTML='")
            htmlResult.Append(rowArray.GetValue(6))
            htmlResult.Append("';  ")
            htmlResult.Append("parent.parent.document.getElementById('divFormatoRollo').innerHTML='")
            htmlResult.Append(rowArray.GetValue(8))
            htmlResult.Append("';  ")
            htmlResult.Append("parent.parent.document.getElementById('divCantidadExposiciones').innerHTML='")
            htmlResult.Append(rowArray.GetValue(6))
            htmlResult.Append("';  ")
            htmlResult.Append("parent.parent.document.getElementById('divISO').innerHTML='")
            htmlResult.Append(rowArray.GetValue(10))
            htmlResult.Append("';  ")
            htmlResult.Append("parent.parent.document.getElementById('divServicio').innerHTML='")
            htmlResult.Append(rowArray.GetValue(12))
            htmlResult.Append("';  ")
            htmlResult.Append("parent.parent.document.getElementById('divTamanio').innerHTML='")
            htmlResult.Append(rowArray.GetValue(15))
            htmlResult.Append("';  ")

            '0  .-  tblTrabajoOrden.intTrabajoOrdenId,
            '1 .-  tblTrabajoOrden.intOrdenId,
            '2  .-  tblArticulo.strArticuloDescripcion,
            '3  .-  tblTrabajoOrden.intArticuloFotolabId,
            '4  .-  tblMarcaRollo.strMarcaRolloNombre,
            '5  .-  tblTrabajoOrden.intMarcaRolloId,
            '6  .-  tblExposicionesRollo.strExposicionesRolloValor,
            '7  .-  tblTrabajoOrden.intExposicionesRolloId,
            '8  .-  tblFormatoRollo.strFormatoRolloValor,
            '9  .-  tblTrabajoOrden.intFormatoRolloId,
            '10  .-  tblISO.strISOValor,
            '11  .-  tblTrabajoOrden.intISOId,
            '12  .-  tblServicio.strServicioValor,
            '13  .-  tblTrabajoOrden.intServicioId,
            '14 .-  tblTrabajoOrden.intTamanoFotoId,
            '15  .-  tblTamanoFoto.strTamanoFotoValor,
            '16  .-  tblTrabajoOrden.intTrabajoOrdenCantidad,
            '17  .-  fltTrabajoOrdenPrecioFoto,
            '18  .-  tblArticuloFotolab.fltArticuloFotolabPrecioRevelado,
            '19  .-  fltTrabajoOrdenImporte,

        End If
        Return htmlResult.ToString
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
        dataArray = clsServicesObj.strConsultarListado(Me._TRAER_LISTADO, Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
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
        Dim widths As String() = {"10%", "10%", "25%", "25%", "15%", "15%"}
        Dim values As String() = {"Estatus", "Orden", "Farmacia", "Laboratorio", "Fecha y Hora Ingreso", "Fecha y Hora Compromiso"}
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
        Dim values1 As String() = {"Reporte de Ordenes", "", "HOJA: " + currentPage.ToString + " / " + totalPages.ToString}
        Dim values2 As String() = {"", "", "Fecha: " + Today.ToString(clsDateUtil.DATE_FORMAT)}

        code.Append(clsHTMLUtils.BEGIN_TABLE)
        code.Append(clsHTMLUtils.getTagTR("td", 6, styles, widths, values1))
        code.Append(clsHTMLUtils.getTagTR("td", 6, "txcontenidobold", widths, values2))
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
        Dim colsToShow As Integer() = {0, 1, 3, 2, 4, 5}
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
    ' Description: Regresa el número de columnas
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Protected Overrides Function getColumnNumber() As Integer
        Return 3
    End Function



#End Region



End Class


