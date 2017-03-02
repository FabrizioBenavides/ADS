'====================================================================
' Class         : clsAsignacionFotolabAFarmacia
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

Public Class clsAsignacionFotolabAFarmacia
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
    Protected _intSucursalIdDetalle As String
    Protected _intCompaniaIdDetalle As String
    Protected _intDireccionOperativaId As Integer

    Protected _intSucursalIdDetalleSucursal As String
    Protected _intCompaniaIdDetalleSucursal As String
    Protected _intDireccionOperativaIdSucursal As Integer
    Protected _strbotones As Integer

    '====================================================================
    ' Name       : strbotones
    ' Description: Saber cual es el boton oprimido
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strbotones() As Integer
        Get
            Return _strbotones
        End Get
        Set(ByVal strValue As Integer)
            _strbotones = strValue
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
    ' Name       : intDireccionOperativaIdSucursal
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intDireccionOperativaIdSucursal() As Integer
        Get
            Return _intDireccionOperativaIdSucursal
        End Get
        Set(ByVal strValue As Integer)
            _intDireccionOperativaIdSucursal = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : _strSucursalRazonSocial
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    'Public Property strSucursalRazonSocial() As String
    '    Get
    '        Return _strSucursalRazonSocial
    '    End Get
    '    Set(ByVal strValue As String)
    '        _strSucursalRazonSocial = strValue
    '    End Set
    'End Property

    '====================================================================
    ' Name       : strSucursalccsss
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    'Public Property strSucursalccsss() As String
    '   Get
    '       Return _strSucursalccsss
    '  End Get
    '  Set(ByVal strValue As String)
    '     _strSucursalccsss = strValue
    'End Set
    'End Property

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
    ' Name       : intSucursalIdDetalleSucursal
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intSucursalIdDetalleSucursal() As String
        Get
            Return _intSucursalIdDetalleSucursal
        End Get
        Set(ByVal strValue As String)
            _intSucursalIdDetalleSucursal = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intCompaniaIdDetalle
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intCompaniaIdDetalleSucursal() As String
        Get
            Return _intCompaniaIdDetalleSucursal
        End Get
        Set(ByVal strValue As String)
            _intCompaniaIdDetalleSucursal = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strSucursalZonaOperativaSucursal
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    'Public Property strSucursalZonaOperativaSucursal() As String
    '    Get
    '        Return _strSucursalZonaOperativa
    '    End Get
    '    Set(ByVal strValue As String)
    '        _strSucursalZonaOperativa = strValue
    '    End Set
    'End Property

    '====================================================================
    ' Name       : strSearch 
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    'Public Property strSearch() As String
    '    Get
    '        Return _strSearch
    '    End Get
    '    Set(ByVal strValue As String)
    '        _strSearch = strValue
    '    End Set
    'End Property

    '====================================================================
    ' Name       : strSucursalNombre
    ' Description: Obtiene o establece el comando para una accion
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    'Public Property strSucursalNombre() As String
    '    Get
    '        Return _strSucursalNombre
    '    End Get
    '    Set(ByVal strValue As String)
    '        _strSucursalNombre = strValue
    '    End Set
    'End Property


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
        Me.clsServicesObj = prjFotolabBusiness.Benavides.Fotolab.Business.clsAsignacionFotolabAFarmacia.SERVICIOS
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
        htmlCombo = prjFotolabBusiness.Benavides.Fotolab.Utils.clsHTMLUtils.buildCombo(dataArray, "cmbLaboratorio", 4, "comboTabla", "", True, "- Todos -")
        htmlCombo = " parent.parent.document.getElementById('divLaboratorio').innerHTML=" + Chr(34) + htmlCombo + Chr(34) + ";"
        Return htmlCombo
    End Function

    '====================================================================
    ' Name       : obtenerComboSucursal
    ' Description: construye el combo Sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : html del Combo
    '====================================================================
    Protected Function obtenerComboSucursal() As String
        Dim dataArray As Array = Nothing
        Dim htmlCombo As String
        dataArray = clsServicesObj.strConsultarListado("SUCURSALES", Request, strConnectionString, Me.strUsuarioNombre, -1, -1)
        htmlCombo = prjFotolabBusiness.Benavides.Fotolab.Utils.clsHTMLUtils.buildCombo(dataArray, "cmbSucursal", 4, "comboTabla", "", True, "- Todos -")
        htmlCombo = " parent.parent.document.getElementById('divSucursales').innerHTML=" + Chr(34) + htmlCombo + Chr(34) + ";"
        Return htmlCombo
    End Function

    '====================================================================
    ' Name       : strGenerarlistado
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function strGenerarlistado(ByVal strCmd As String) As String

        Dim htmlResult As String
        Dim intSelectedPage, totalRows As Integer
        Dim dataArray, elemArray As Array
        Const intElementsPerPage As Integer = 1
        Dim strRecordBrowserName As String = "Asignacion de Farmacias a Fotolabs"

        ' Declaramos e inicializamos las variables locales
        If strCmd = "" Then
            intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        Else
            intSelectedPage = CInt(strCmd)
        End If
        If intSelectedPage <= 0 Then
            'intSelectedPage = 1
            If IsNumeric(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request)) = True Then
                intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
                If intSelectedPage = -1 Then intSelectedPage = 1
            Else
                intSelectedPage = 1
            End If
        End If

        ' Obtenemos los listados que ya se han capturado previamente.
        If (Request("strLaboratoriosId") <> "-1") And Request("strLaboratoriosId") <> "" Then
            Dim LabsIds() As String
            Dim auxArray(0) As Array
            Dim arrayItem As Array
            Dim j As Integer
            LabsIds = Split(Request("strLaboratoriosId"), ",")
            For j = 0 To LabsIds.Length - 1
                ReDim Preserve auxArray(j)
                arrayItem = clsServicesObj.strConsultarListado("TRAERLISTADOPORIDS", Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, Me._MAX_PER_PAGE, LabsIds(j) + " ,12")
                auxArray.SetValue(arrayItem.GetValue(0), j)
            Next j
            dataArray = auxArray

            arrayItem = CType(dataArray.GetValue(0), Array)
            arrayItem.SetValue(CStr(dataArray.Length), arrayItem.Length - 1)
            dataArray.SetValue(arrayItem, 0)

        ElseIf (Request("intZonaOperativaId") <> "-1") And (Request("intZonaOperativaId") <> "") Then
            dataArray = clsServicesObj.strConsultarListado("TRAERLISTADOPORZONA", Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, Me._MAX_PER_PAGE)
        ElseIf (Request("intDireccionOperativaId") <> "-1") And (Request("intDireccionOperativaId") <> "") Then
            dataArray = clsServicesObj.strConsultarListado("TRAERLISTADOPORDIR", Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, Me._MAX_PER_PAGE)
        Else
            dataArray = clsServicesObj.strConsultarListado("TRAERLISTADOADMIN", Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, Me._MAX_PER_PAGE)
        End If

        Dim headers As ArrayList = New ArrayList()
        headers.Add("Laboratorio")
        headers.Add("Razón Social")
        'If Request("strCmd") = "Consultar" And Request("strbotones") = "3" Then
        headers.Add("Acciones")
        'End If
        'headers.Add("Acciones")

        Dim columnOrder As Integer() = {0, 1}

        Dim actions As ArrayList = New ArrayList()
        Dim pkNames As String() = {"intSucursalId"}
        Dim pkIndexes As Integer() = {0}
        'If Request("strCmd") = "Consultar" Then
        actions.Add(New clsActionLink(Me._EDITAR, pkNames, pkIndexes, "imgNRVer.gif", "Haga clic aquí para ver el Detalle de este Cliente"))
        'End If
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
        htmlResult = clsHTMLUtils.displayScroll(totalRows, intSelectedPage, Me._MAX_PER_PAGE, "AsignacionFotolabAFarmacia.aspx", Nothing, , "../static/images/")
        If (Request("strLaboratoriosId") <> "-1") Then
            htmlResult += clsHTMLUtils.displayArrayTable(headers, dataArray, columnOrder, actions, intSelectedPage, Me._MAX_PER_PAGE, -1, , "../static/images/")
        Else
            htmlResult += clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, intSelectedPage, Me._MAX_PER_PAGE, -1, , "../static/images/")
        End If
        'htmlResult += "<br>"
        'htmlResult += "<input class=boton type=button value='Buscar Clientes' name=btnBuscarClientes>"
        'htmlResult += "<input class=boton type=button value='Regresar' name=btnRegresar>"

        Return htmlResult
    End Function


    '====================================================================
    ' Name       : DesasignarFotolab
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Sub DesasignarFotolab(ByVal strCmd As String)

        Dim intSelectedPage, totalRows As Integer
        Dim dataArray, elemArray As Array

        Dim LabsIds() As String
        Dim SucsIds() As String
        Dim Resultado As Integer
        Dim strSucursalFarmaciaId As String
        Dim strCompaniaFarmaciaId As String
        Dim strSucursalLaboratorioId As String
        Dim strCompaniaLaboratorioId As String
        Dim intDireccionOperativaId As String
        Dim intZonaOperativaId As String
        Dim strLaboratoriosId As String
        Dim intDireccionOperativaIdSucursal As String
        Dim intZonaOperativaIdSucursal As String
        Dim strSucursalId As String
        Dim strFarmaciaId As String

        Dim j As Integer
        Dim i As Integer
        If (Request("strLaboratoriosId") = "-1") Or (Request("strSucursalId") = "-1") Then
            If Request("intDireccionOperativaId") = "" Then
                intDireccionOperativaId = "-1"
            Else
                intDireccionOperativaId = Request("intDireccionOperativaId")
            End If
            If Request("intZonaOperativaId") = "" Then
                intZonaOperativaId = "-1"
            Else
                intZonaOperativaId = Request("intZonaOperativaId")
            End If
            If Request("strLaboratoriosId") = "" Then
                strLaboratoriosId = "-1"
            Else
                strLaboratoriosId = Request("strLaboratoriosId")
            End If
            If Request("intDireccionOperativaIdSucursal") = "" Then
                intDireccionOperativaIdSucursal = "-1"
            Else
                intDireccionOperativaIdSucursal = Request("intDireccionOperativaIdSucursal")
            End If
            If Request("intZonaOperativaIdSucursal") = "" Then
                intZonaOperativaIdSucursal = "-1"
            Else
                intZonaOperativaIdSucursal = Request("intZonaOperativaIdSucursal")
            End If
            If Request("strFarmaciaId") = "" Then
                strFarmaciaId = "-1"
            Else
                strFarmaciaId = Request("strFarmaciaId")
            End If
            Resultado = clsServicesObj.strAfectarListado("DESASIGNACIONFOTOLABMULTIPLE", Request, strConnectionString, Me.strUsuarioNombre, intDireccionOperativaId + ", " + intZonaOperativaId + ", '" + strLaboratoriosId + "', " + intDireccionOperativaIdSucursal + ", " + intZonaOperativaIdSucursal + ", '" + strFarmaciaId + "', '" + Date.Now.ToString("MM/dd/yyyy HH:mm:ss") + "', '" + Me.strUsuarioNombre + "'")
        Else
            LabsIds = Split(Request("strLaboratoriosId"), ",")
            SucsIds = Split(Request("strFarmaciaId"), ",")
            For i = 0 To LabsIds.Length - 1
                For j = 0 To SucsIds.Length - 1
                    'arrayItem = clsServicesObj.strAfectarListado("ASIGNACIONFOTOLAB", Request, strConnectionString, Me.strUsuarioNombre, LabsIds[i] + " ," + SucsIds(j))
                    strSucursalFarmaciaId = CStr(CInt(SucsIds(j).Substring(2, 3)))
                    strCompaniaFarmaciaId = CStr(CInt(SucsIds(j).Substring(0, 2)))
                    strSucursalLaboratorioId = CStr(CInt(LabsIds(i).Substring(2, 3)))
                    strCompaniaLaboratorioId = CStr(CInt(LabsIds(i).Substring(0, 2)))
                    Resultado = clsServicesObj.strAfectarListado("DESASIGNACIONFOTOLAB", Request, strConnectionString, Me.strUsuarioNombre, strSucursalFarmaciaId + ", " + strCompaniaFarmaciaId + ", " + strSucursalLaboratorioId + ", " + strCompaniaLaboratorioId)
                Next j
            Next i
        End If
    End Sub

    '====================================================================
    ' Name       : AsignarFotolab
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Sub AsignarFotolab(ByVal strCmd As String)

        Dim intSelectedPage, totalRows As Integer
        Dim dataArray, elemArray As Array

        Dim LabsIds() As String
        Dim SucsIds() As String
        Dim Resultado As Integer
        Dim strSucursalFarmaciaId As String
        Dim strCompaniaFarmaciaId As String
        Dim strSucursalLaboratorioId As String
        Dim strCompaniaLaboratorioId As String
        Dim intDireccionOperativaId As String
        Dim intZonaOperativaId As String
        Dim strLaboratoriosId As String
        Dim intDireccionOperativaIdSucursal As String
        Dim intZonaOperativaIdSucursal As String
        Dim strSucursalId As String
        Dim strFarmaciaId As String

        Dim j As Integer
        Dim i As Integer
        strFarmaciaId = Request("strFarmaciaId")
        If (Request("strLaboratoriosId") = "-1") Or (Request("strFarmaciaId") = "-1") Then
            If Request("intDireccionOperativaId") = "" Then
                intDireccionOperativaId = "-1"
            Else
                intDireccionOperativaId = Request("intDireccionOperativaId")
            End If
            If Request("intZonaOperativaId") = "" Then
                intZonaOperativaId = "-1"
            Else
                intZonaOperativaId = Request("intZonaOperativaId")
            End If
            If Request("strLaboratoriosId") = "" Then
                strLaboratoriosId = "-1"
            Else
                strLaboratoriosId = Request("strLaboratoriosId")
            End If
            If Request("intDireccionOperativaIdSucursal") = "" Then
                intDireccionOperativaIdSucursal = "-1"
            Else
                intDireccionOperativaIdSucursal = Request("intDireccionOperativaIdSucursal")
            End If
            If Request("intZonaOperativaIdSucursal") = "" Then
                intZonaOperativaIdSucursal = "-1"
            Else
                intZonaOperativaIdSucursal = Request("intZonaOperativaIdSucursal")
            End If
            If Request("strFarmaciaId") = "" Then
                strFarmaciaId = "-1"
            Else
                strFarmaciaId = Request("strFarmaciaId")
            End If
            Resultado = clsServicesObj.strAfectarListado("ASIGNACIONFOTOLABMULTIPLE", Request, strConnectionString, Me.strUsuarioNombre, intDireccionOperativaId + ", " + intZonaOperativaId + ", '" + strLaboratoriosId + "', " + intDireccionOperativaIdSucursal + ", " + intZonaOperativaIdSucursal + ", '" + strFarmaciaId + "', '" + Date.Now.ToString("MM/dd/yyyy HH:mm:ss") + "', '" + Me.strUsuarioNombre + "'")
        Else
            LabsIds = Split(Request("strLaboratoriosId"), ",")
            SucsIds = Split(Request("strFarmaciaId"), ",")
            For i = 0 To LabsIds.Length - 1
                For j = 0 To SucsIds.Length - 1
                    'arrayItem = clsServicesObj.strAfectarListado("ASIGNACIONFOTOLAB", Request, strConnectionString, Me.strUsuarioNombre, LabsIds[i] + " ," + SucsIds(j))
                    If (CStr(SucsIds(j)) <> "-1") And (CStr(LabsIds(i)) <> "-1") Then
                        strSucursalFarmaciaId = CStr(CInt(SucsIds(j).Substring(2, 3)))
                        strCompaniaFarmaciaId = CStr(CInt(SucsIds(j).Substring(0, 2)))
                        strSucursalLaboratorioId = CStr(CInt(LabsIds(i).Substring(2, 3)))
                        strCompaniaLaboratorioId = CStr(CInt(LabsIds(i).Substring(0, 2)))
                        Resultado = clsServicesObj.strAfectarListado("ASIGNACIONFOTOLAB", Request, strConnectionString, Me.strUsuarioNombre, strSucursalFarmaciaId + ", " + strCompaniaFarmaciaId + ", " + strSucursalLaboratorioId + ", " + strCompaniaLaboratorioId + ", '" + Date.Now.ToString("MM/dd/yyyy HH:mm:ss") + "', '" + Me.strUsuarioNombre + "'")
                    End If
                Next j
            Next i
        End If
    End Sub

    '====================================================================
    ' Name       : displayScrollTable
    ' Description: Despliega una tabla que maneje el scroll para un arreglo de datos
    ' Parameters : 
    '              ByVal totalRows As Integer
    '                - número de renglones
    '              ByVal currentPage as Integer
    '                 - pagina actual
    '              ByVal goToLink As String
    '                 - 
    '              ByVal actions As Array
    '                 - 
    '              Optional ByVal linkName As String
    '                 - 
    '              Optional ByVal imagePath As String
    '                 -
    ' Throws     : nothing
    ' Output     : String
    '====================================================================
    Public Function displaySucursal(ByVal totalRows As Integer, _
            ByRef currentPage As Integer, _
            ByVal maxPerPage As Integer, _
            ByVal goToLink As String, _
            ByVal actions As Array, _
            Optional ByVal linkName As String = "intNavegadorRegistrosPagina", _
            Optional ByVal imagePath As String = "/images/") As String

        Dim lastPage As Integer = totalRows \ maxPerPage
        If totalRows Mod maxPerPage > 0 Then
            lastPage = lastPage + 1
        End If

        'corregir la pagina actual
        If lastPage > 0 AndAlso currentPage > lastPage Then
            currentPage = lastPage
        End If

        Dim startRow As Integer = (currentPage - 1) * (maxPerPage) + 1
        Dim endRow As Integer = startRow + maxPerPage - 1
        Dim previousPage As Integer = currentPage - 1
        Dim nextPage As Integer = currentPage + 1
        'Dim link = goToLink + "?" + linkName + "="
        Dim link As String = "doSubmit('BrincoPagina','" + linkName + "','"

        If endRow > totalRows Then
            endRow = totalRows
        End If

        If previousPage <= 0 Then
            previousPage = 1
        End If

        If nextPage > lastPage Then
            nextPage = lastPage
        End If

        Dim code As StringBuilder = New StringBuilder()

        code.Append(clsHTMLUtils.BEGIN_TABLE)
        code.Append(clsHTMLUtils.RAYITA)
        code.Append(clsHTMLUtils.ESPACIO)
        code.Append(" <tr>")
        code.Append("  <td width='8%' valign='middle' class='txcontenidobold'>TOTAL:</td>")
        code.Append("  <td width='9%' class='txcontazul'>")
        code.Append(totalRows)
        code.Append("</td>")
        code.Append("  <td width='15%' class='txcontenidobold'>MOSTRANDO:</td>")
        code.Append("  <td width='17%' class='txcontazul'>")
        code.Append(startRow)
        code.Append(" - ")
        code.Append(endRow)
        code.Append("</td>")
        code.Append("  <td width='7%' class='txcontenidobold'>PAGS.</td>")
        code.Append("  <td width='8%' align='right'>")
        code.Append("    <a href=javascript:")
        code.Append(link)
        code.Append("1')><img src='")
        code.Append(imagePath)
        code.Append("icono_inicio.gif' width='17' height='17' align='absmiddle' border='0'>")
        code.Append("</a>")
        code.Append("<a href=javascript:")
        code.Append(link)
        code.Append(previousPage)
        code.Append("')><img src='")
        code.Append(imagePath)
        code.Append("icono_back.gif' width='25' height='17' align='absmiddle' border='0'>")
        code.Append("</a>")
        code.Append("  </td>")
        code.Append("  <td width='14%' align='center' valign='middle'>")

        code.Append(AgregarLigapaginas(link, currentPage, lastPage))

        code.Append("  </td>")
        code.Append("  <td width='8%' align='left'>")
        code.Append("    <a href=javascript:")
        code.Append(link)
        code.Append(nextPage)
        code.Append("')><img src='")
        code.Append(imagePath)
        code.Append("icono_fwd.gif' width='25' height='17' align='absmiddle' border='0'>")
        code.Append("</a>")
        code.Append("<a href=javascript:")
        code.Append(link)
        code.Append(lastPage)
        code.Append("')><img src='")
        code.Append(imagePath)
        code.Append("icono_final.gif' width='17' height='17' align='absmiddle' border='0'>")
        code.Append("</a>")
        code.Append("  </td>")

        'actions
        'code.Append("    <td width='13%' align='right' class='tdpadleft5'>")
        'code.Append("      <input name='cmdNavegadorRegistrosAgregar' type='button' class='boton' id='cmdNavegadorRegistrosAgregar' value='Agregar tienda'")
        'onclick = "window.location='SistemaAdministrarTiendas.aspx?intDireccionId=1&amp;intZonaId=1&amp;strCmd=Agregar'" > ")"
        'code.Append("    </td>")

        code.Append(" </tr>")
        code.Append(clsHTMLUtils.ESPACIO)
        code.Append(clsHTMLUtils.RAYITA)
        code.Append(clsHTMLUtils.END_TABLE)
        code.Append("<input type=hidden name=intTotalDeRegistrosTabla value=" + totalRows.ToString + ">")
        code.Append("<input type=hidden name=intUltimaPaginaTabla value=" + lastPage.ToString + ">")

        Return code.ToString
    End Function

    '====================================================================
    ' Name       : AgregarLigapaginas
    ' Parameters : Forma un pedazo de HTML con las ligas en la numeracion
    '               del escrolleo de un listado.
    '               Desplegar a lo mas 5 links
    '              ByVal link As String
    '                 - link para moverse entre paginas
    '              ByVal currentPage As Integer
    '                 - # de pagina actual
    '              ByVal lastPage As Integer
    '                 - # de ultima pagina
    ' Throws     : nothing
    ' Output     : String
    '====================================================================
    Private Shared Function AgregarLigapaginas(ByVal link As String, ByVal currentPage As Integer, ByVal lastPage As Integer) As String
        Dim code As StringBuilder = New StringBuilder()

        If currentPage = 1 Then
            'si currentPage =1
            'desplegar currentPage, currentPage+1, currentPage+2, currentPage+3, currentPage+4
            code.Append(Ligapagina(link, currentPage, currentPage, lastPage))
            code.Append(Ligapagina(link, currentPage + 1, currentPage, lastPage))
            code.Append(Ligapagina(link, currentPage + 2, currentPage, lastPage))
            code.Append(Ligapagina(link, currentPage + 3, currentPage, lastPage))
            code.Append(Ligapagina(link, currentPage + 4, currentPage, lastPage))
        ElseIf currentPage = 2 Then
            'si currentPage =2
            'desplegar currentPage-1, currentPage, currentPage+1, currentPage+2, currentPage+3
            code.Append(Ligapagina(link, currentPage - 1, currentPage, lastPage))
            code.Append(Ligapagina(link, currentPage, currentPage, lastPage))
            code.Append(Ligapagina(link, currentPage + 1, currentPage, lastPage))
            code.Append(Ligapagina(link, currentPage + 2, currentPage, lastPage))
            code.Append(Ligapagina(link, currentPage + 3, currentPage, lastPage))
        ElseIf currentPage >= 3 AndAlso currentPage <= (lastPage - 2) Then
            'si currentPage >=3 y currentPage <= (lastPage-2)
            'desplegar currentPage-2, currentPage-1, currentPage, currentPage+1, currentPage+2
            code.Append(Ligapagina(link, currentPage - 2, currentPage, lastPage))
            code.Append(Ligapagina(link, currentPage - 1, currentPage, lastPage))
            code.Append(Ligapagina(link, currentPage, currentPage, lastPage))
            code.Append(Ligapagina(link, currentPage + 1, currentPage, lastPage))
            code.Append(Ligapagina(link, currentPage + 2, currentPage, lastPage))
        ElseIf currentPage = (lastPage - 1) Then
            'si currentPage = (lastPage-1)
            'desplegar currentPage-3, currentPage-2, currentPage-1, currentPage, currentPage+1
            code.Append(Ligapagina(link, currentPage - 3, currentPage, lastPage))
            code.Append(Ligapagina(link, currentPage - 2, currentPage, lastPage))
            code.Append(Ligapagina(link, currentPage - 1, currentPage, lastPage))
            code.Append(Ligapagina(link, currentPage, currentPage, lastPage))
            code.Append(Ligapagina(link, currentPage + 1, currentPage, lastPage))
        ElseIf currentPage = lastPage Then
            'si currentPage = (lastPage)
            'desplegar currentPage-4, currentPage-3, currentPage-2, currentPage-1, currentPage
            code.Append(Ligapagina(link, currentPage - 4, currentPage, lastPage))
            code.Append(Ligapagina(link, currentPage - 3, currentPage, lastPage))
            code.Append(Ligapagina(link, currentPage - 2, currentPage, lastPage))
            code.Append(Ligapagina(link, currentPage - 1, currentPage, lastPage))
            code.Append(Ligapagina(link, currentPage, currentPage, lastPage))
        End If

        Return code.ToString

    End Function

    '====================================================================
    ' Name       : Ligapagina
    ' Parameters : Forma un pedazo de HTML con las ligas en la numeracion
    '               del escrolleo de un listado
    '              ByVal link as Integer
    '                 - link para moverse entre paginas
    '              ByVal page As Array
    '                 - # de pagina a desplegar
    '              ByVal currentPage as integer
    '                 - pagina actual
    '              ByVal lastPage as integer
    '                 - pagina actual
    ' Throws     : nothing
    ' Output     : extracto de codigo HTML con link para paginacion
    '====================================================================
    Private Shared Function Ligapagina(ByVal link As String, ByVal page As Integer, ByVal currentPage As Integer, ByVal lastPage As Integer) As String
        Dim code As StringBuilder = New StringBuilder()

        'validar que la pagina a desplegar este dentro del rango
        If page <= 0 OrElse page > lastPage Then
            Return ""
        End If

        If page = currentPage Then
            'si es pagina actual
            code.Append("<span class='txaccionbold'>")
            code.Append(page)
            code.Append("</span>")
        Else
            'si es link
            code.Append("<a class='txaccion' href=javascript:")
            code.Append(link)
            code.Append(page)
            code.Append("')>")
            code.Append(page)
            code.Append("</a>")
        End If
        code.Append(clsHTMLUtils.ESPACIO_VACIO)
        code.Append(clsHTMLUtils.ESPACIO_VACIO)

        Return code.ToString

    End Function


    '====================================================================
    ' Name       : strGenerarlistadoSucursal
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function strGenerarlistadoSucursal(ByVal strCmd As String) As String

        Dim htmlResult As String
        Dim intSelectedPage, totalRows As Integer
        Dim dataArray, elemArray As Array
        Const intElementsPerPage As Integer = 1
        Dim strRecordBrowserName As String = "Asignacion de Farmacias a Fotolabs"

        ' Declaramos e inicializamos las variables locales
        If strCmd = "" Then
            intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))
        Else
            intSelectedPage = CInt(strCmd)
        End If
        If intSelectedPage <= 0 Then
            'intSelectedPage = 1
            If IsNumeric(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request)) = True Then
                intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
                If intSelectedPage = -1 Then intSelectedPage = 1
            Else
                intSelectedPage = 1
            End If
        End If

        ' Obtenemos los listados que ya se han capturado previamente.
        If (Request("strSucursalId") <> "-1") And Request("strSucursalId") <> "" Then
            Dim LabsIds() As String
            Dim auxArray(0) As Array
            Dim arrayItem As Array
            Dim j As Integer
            LabsIds = Split(Request("strSucursalId"), ",")
            For j = 0 To LabsIds.Length - 1
                ReDim Preserve auxArray(j)
                arrayItem = clsServicesObj.strConsultarListado("TRAERLISTADOPORIDS", Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, Me._MAX_PER_PAGE, LabsIds(j) + " ,2")
                auxArray.SetValue(arrayItem.GetValue(0), j)
            Next j
            dataArray = auxArray

            arrayItem = CType(dataArray.GetValue(0), Array)
            arrayItem.SetValue(CStr(dataArray.Length), arrayItem.Length - 1)
            dataArray.SetValue(arrayItem, 0)
        ElseIf (Request("intZonaOperativaIdSucursal") <> "-1") And (Request("intZonaOperativaIdSucursal") <> "") Then
            dataArray = clsServicesObj.strConsultarListado("TRAERLISTADOPORZONA", Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, Me._MAX_PER_PAGE, Request("intZonaOperativaIdSucursal") + " ,2")
        ElseIf (Request("intDireccionOperativaIdSucursal") <> "-1") And (Request("intDireccionOperativaIdSucursal") <> "") Then
            dataArray = clsServicesObj.strConsultarListado("TRAERLISTADOPORDIR", Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, Me._MAX_PER_PAGE, Request("intDireccionOperativaIdSucursal") + " ,2")
        Else
            dataArray = clsServicesObj.strConsultarListado("TRAERLISTADOADMIN", Request, strConnectionString, Me.strUsuarioNombre, intSelectedPage, Me._MAX_PER_PAGE, "2")
        End If

        Dim headers As ArrayList = New ArrayList()
        headers.Add("Farmacia")
        headers.Add("Razón Social")
        headers.Add("Acciones")
        'headers.Add("Acciones")

        Dim columnOrder As Integer() = {0, 1}

        Dim actions As ArrayList = New ArrayList()
        Dim pkNames As String() = {"strFarmaciaId"}
        Dim pkIndexes As Integer() = {0}
        If CInt(Request("strbotones")) = 1 Then
            actions.Add(New clsActionLink("AsignacionIndividual", pkNames, pkIndexes, Me._IMG_ASIGNAR, "Haga clic aquí para Asignar Individualmente"))
        Else
            actions.Add(New clsActionLink("DesasignacionIndividual", pkNames, pkIndexes, Me._IMG_ASIGNAR, "Haga clic aquí para Desasignar Individualmente"))
        End If
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

        htmlResult = displaySucursal(totalRows, intSelectedPage, Me._MAX_PER_PAGE, "AsignacionFotolabAFarmacia.aspx", Nothing, , "../static/images/")
        If (Request("strSucursalId") <> "-1") Then
            htmlResult += clsHTMLUtils.displayArrayTable(headers, dataArray, columnOrder, actions, intSelectedPage, Me._MAX_PER_PAGE, -1, , "../static/images/")
        Else
            htmlResult += clsHTMLUtils.displayTable(headers, dataArray, columnOrder, actions, intSelectedPage, Me._MAX_PER_PAGE, -1, , "../static/images/")
        End If
        'htmlResult += "<br>"
        'htmlResult += "<input class=boton type=button value='Buscar Clientes' name=btnBuscarClientes>"
        'htmlResult += "<input class=boton type=button value='Regresar' name=btnRegresar>"

        Return htmlResult
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
        Dim strRecordBrowserName As String = "Sucursales"

        Dim dataArray As Array = Nothing

        ' Obtenemos los listados que ya se han capturado previamente.
        dataArray = clsServicesObj.strConsultarListado("SUCURSALLISTADODETALLE", Request, strConnectionString, strUsuarioNombre, -1, -1)


        Dim headers As ArrayList = New ArrayList()
        headers.Add("Sucursal")
        headers.Add("Razón Social")

        '        headers.Add("Acciones")

        Dim columnOrder As Integer() = {0, 1}

        Dim actions As ArrayList = New ArrayList()
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
            Case "SUCURSALES"
                htmlResult = Me.obtenerComboSucursal()
        End Select

        Return htmlResult
    End Function



#End Region

#Region "metodos de la interface PrintInterface"



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
        Dim values As String() = {"Identificador", "Descripción"}
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
        Dim values1 As String() = {"Reporte de Articulos", "", "HOJA: " + currentPage.ToString + " / " + totalPages.ToString}
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
        Dim colsToShow As Integer() = {0, 2}
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

    '====================================================================
    ' Name       : getData
    ' Description: Obtiene el arreglo de datos que se requiren para el listado.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Array
    '====================================================================
    Protected Overrides Function getData() As Array
        Dim dataArray As Array = Nothing
        dataArray = clsServicesObj.strConsultarListado(Me._TRAER_LISTADO, Nothing, strConnectionString, "", -1, -1)

        Return dataArray
    End Function

#End Region



End Class


