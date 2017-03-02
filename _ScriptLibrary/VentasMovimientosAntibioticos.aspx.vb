Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports System.Text
Imports System.Collections
Imports System.Configuration
Imports System.Globalization
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business




Public Class clsVentasMovimientosAntibioticos
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object


#End Region


#Region " Class Private Attributes"

    Const strComitasDobles As String = """"

    Private strmJavascriptWindowOnLoadCommands As String
    Private strmArticuloId As String
    Private strmArticuloDescripcion As String
    Private strmTipoMovimientoAntibioticoId As String
    Private strmSelected As String
    Private strmTipoSelected As String
    Private strmMovSelected As String
    Private intmOrdenId As String
    Private strmFechaInicial As String
    Private strmFechaFinal As String

#End Region


    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        strSelected = GetPageParameter("strSelected", GetPageParameter("txtSelected", ""))
        strTipoSelected = GetPageParameter("strTipoSelected", GetPageParameter("cboTiposMov", ""))
        strMovSelected = GetPageParameter("strMovSelected", GetPageParameter("cboMovs", ""))
        intOrdenId = GetPageParameter("intOrdenId", GetPageParameter("cboOrden", "0"))

    End Sub


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




    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)
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
            Return Server.UrlEncode(GetPageName())
        End Get
    End Property

    '====================================================================
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Public Property strJavascriptWindowOnLoadCommands() As String
        Get
            Return strmJavascriptWindowOnLoadCommands
        End Get
        Set(ByVal strValue As String)
            strmJavascriptWindowOnLoadCommands = strValue
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
            Return GetPageParameter("strCmd", "")
        End Get
    End Property

    '====================================================================
    ' Name       : strArticuloId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strArticuloId() As String
        Get
            Return strmArticuloId
        End Get
        Set(ByVal strValue As String)
            strmArticuloId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strArticuloMarcaPropiaDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strArticuloDescripcion() As String
        Get
            Return strmArticuloDescripcion
        End Get
        Set(ByVal strValue As String)
            strmArticuloDescripcion = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : intArticuloId 
    ' Description: Numero de Articulo
    ' Accessor   : Read
    ' Output     : Long
    '====================================================================
    Public ReadOnly Property intArticuloId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("txtArticulo"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : strSelected
    ' Description: Listado de articulos seleccionados
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strSelected() As String
        Get
            Return strmSelected
        End Get
        Set(ByVal stValue As String)
            strmSelected = stValue
        End Set
    End Property



    '====================================================================
    ' Name       : strTipoSelected
    ' Description: Tipo Mov seleccionado
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strTipoSelected() As String
        Get
            strmTipoSelected = isocraft.commons.clsWeb.strGetPageParameter("cboTiposMov", isocraft.commons.clsWeb.strGetPageParameter("strTipoSelected", "0"))
            Return strmTipoSelected
        End Get
        Set(ByVal stValue As String)
            strmTipoSelected = stValue
        End Set
    End Property


    '====================================================================
    ' Name       : strMovSelected
    ' Description: Mov seleccionado
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strMovSelected() As String
        Get
            strmMovSelected = isocraft.commons.clsWeb.strGetPageParameter("cboMovs", isocraft.commons.clsWeb.strGetPageParameter("strMovSelected", "0"))
            Return strmMovSelected
        End Get
        Set(ByVal stValue As String)
            strmMovSelected = stValue
        End Set
    End Property

    '====================================================================
    ' Name       : intOrdenId
    ' Description: Mov seleccionado
    ' Accessor   : Read
    ' Throws     : None
    ' Output     :  
    '====================================================================
    Public Property intOrdenId() As String
        Get
            intmOrdenId = isocraft.commons.clsWeb.strGetPageParameter("cboOrden", isocraft.commons.clsWeb.strGetPageParameter("intOrdenId", "0"))
            Return intmOrdenId
        End Get
        Set(ByVal stValue As String)
            intmOrdenId = stValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaInicial
    ' Description: Fecha inicial
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strFechaInicial() As String
        Get
            strmFechaInicial = isocraft.commons.clsWeb.strGetPageParameter("txtDesde", isocraft.commons.clsWeb.strGetPageParameter("strFechaInicial", ""))
            If Len(strmFechaInicial) = 0 Then
                Dim dtmYesterday As Date = DateAdd(DateInterval.Day, -1, Now)
                strmFechaInicial = strComplete2Digit(CStr(Day(dtmYesterday))) & "/" & strComplete2Digit(CStr(Month(dtmYesterday))) & "/" & Year(dtmYesterday)
            Else
                Dim astrData As Array = strmFechaInicial.Split("/"c)
                If astrData.Length = 3 Then
                    strmFechaInicial = strComplete2Digit(CStr(astrData.GetValue(0))) & "/" & strComplete2Digit(CStr(astrData.GetValue(1))) & "/" & CStr(astrData.GetValue(2))
                End If
            End If
            Return strmFechaInicial
        End Get
        Set(ByVal strValue As String)
            strmFechaInicial = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaFinal
    ' Description: Fecha final
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strFechaFinal() As String
        Get
            strmFechaFinal = isocraft.commons.clsWeb.strGetPageParameter("txtHasta", isocraft.commons.clsWeb.strGetPageParameter("strFechaFinal", ""))
            If Len(strmFechaFinal) = 0 Then
                strmFechaFinal = strComplete2Digit(CStr(Day(Now))) & "/" & strComplete2Digit(CStr(Month(Now))) & "/" & Year(Now)
            Else
                Dim astrData As Array = strmFechaFinal.Split("/"c)
                If astrData.Length = 3 Then
                    strmFechaFinal = strComplete2Digit(CStr(astrData.GetValue(0))) & "/" & strComplete2Digit(CStr(astrData.GetValue(1))) & "/" & CStr(astrData.GetValue(2))
                End If
            End If
            Return strmFechaFinal
        End Get
        Set(ByVal strValue As String)
            strmFechaFinal = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strArticulosRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros de articulos
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strArticulosRecordBrowserHTML() As String

        ' Declaramos e inicializamos las variables locales
        Dim objArrayArticulosSeleccionados As Array = Nothing

        ' Si hay articulos seleccionados
        If Len(strSelected) > 0 And strSelected <> "TODOS" Then
            objArrayArticulosSeleccionados = strSelected.Split(","c)

            ' Generamos el navegador de registros
            Dim strReturn As String = strRecordBrowserArticulos(objArrayArticulosSeleccionados)

            Return strReturn
        End If

    End Function


    '====================================================================
    ' Name       : strRecordBrowserArticulos
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserArticulos(ByVal objArrayArticulos As Array) As String
        Dim intContadorRegistros As Integer = 0
        Dim intTotalRegistros As Integer = 0
        Dim strTablaArticulos As New StringBuilder
        Dim intTablaArticulosRegistros As Integer = 0
        Dim strColorRegistroArticulo As String

        Dim intArticuloId As Integer = 0
        Dim strArticuloId As String = ""
        Dim strArticuloDescripcion As String = ""

        If IsArray(objArrayArticulos) AndAlso objArrayArticulos.Length > 0 Then
            objArrayArticulos = objEliminaDuplicados(objArrayArticulos)

            intTotalRegistros = objArrayArticulos.Length 'El Total de Registros de la Consulta

            If intTotalRegistros > 10 Then intTotalRegistros = 10

            strTablaArticulos.Append("<table cellSpacing='0' cellPadding='0' width='100%' border='0'>")
            strTablaArticulos.Append("<tr align='left'>")
            strTablaArticulos.Append("<td class='txcontenidobold' vAlign='middle'>Total: <span class='txcontazul'>" & intTotalRegistros.ToString() & "</span></td>")
            strTablaArticulos.Append("<td class='txcontenidobold'>Mostrando: <span class='txcontazul'>1 - " & intTotalRegistros.ToString() & "</span></td>")
            strTablaArticulos.Append("<td class='tdpadleft5' id='BotonDelNavegador' align='right'></td>")
            strTablaArticulos.Append("</tr>")
            strTablaArticulos.Append("</table>")
            strTablaArticulos.Append("<table width='100%' id='tableRegistro' border='0' cellspacing='0' cellpadding='0'>")
            strTablaArticulos.Append("<tr><td>")
            strTablaArticulos.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strTablaArticulos.Append("<tr class='trtitulos'>")
            strTablaArticulos.Append("<th width='20%'  class='rayita'>Código Artículo</th>")
            strTablaArticulos.Append("<th width='70%'  class='rayita'>Descripción</th>")
            strTablaArticulos.Append("<th width='10%'  class='rayita'>&nbsp;</th>")
            strTablaArticulos.Append("</tr>")
            strTablaArticulos.Append("</table>")
            strTablaArticulos.Append("</td></tr>")

            intContadorRegistros = 0
            intTablaArticulosRegistros = 2

            For Each strArticuloId In objArrayArticulos
                intArticuloId = CInt(strArticuloId)

                ' solo es posible agregar hasta 10 registros
                If intContadorRegistros < 10 Then
                    intContadorRegistros += 1

                    ' Obtenemos la información del Articulo
                    Dim objArrayArticulo As Array = Benavides.CC.Data.clstblArticulo.strBuscarAntibioticos(intArticuloId, "", strConnectionString)
                    If IsArray(objArrayArticulo) AndAlso (objArrayArticulo.Length > 0) Then
                        Dim strRegistroArticulo As String() = DirectCast(objArrayArticulo.GetValue(0), String())
                        strArticuloDescripcion = clsCommons.strFormatearDescripcion(strRegistroArticulo(8))
                    End If

                    If (intContadorRegistros Mod 2) <> 0 Then
                        strColorRegistroArticulo = "'tdceleste'"
                    Else
                        strColorRegistroArticulo = "'tdblanco'"
                    End If

                    strTablaArticulos.Append("<tr>")
                    strTablaArticulos.Append("<td>")
                    strTablaArticulos.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
                    strTablaArticulos.Append("<tr>")
                    strTablaArticulos.Append("<td width='20%'  class=" & strColorRegistroArticulo & ">" & clsCommons.strFormatearDescripcion(strArticuloId) & "</td>")
                    strTablaArticulos.Append("<td width='70%'  class=" & strColorRegistroArticulo & ">" & clsCommons.strFormatearDescripcion(strArticuloDescripcion) & "</td>")
                    strTablaArticulos.Append("<td width='10%'  class=" & strColorRegistroArticulo & "><a href='#' onclick='return fnEliminaArticulo(" & strArticuloId & ")'><img src='../static/images/imgNREliminar.gif' border='0' /></a></td>")
                    strTablaArticulos.Append("</tr>")
                    strTablaArticulos.Append("</table>")
                    strTablaArticulos.Append("</td>")
                    strTablaArticulos.Append("</tr>")

                End If

            Next

            strTablaArticulos.Append("</table>")


        End If

        strRecordBrowserArticulos = clsCommons.strGenerateJavascriptString(strTablaArticulos.ToString)

    End Function


    '====================================================================
    ' Name       : strLlenarTiposMovComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboTiposMov"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarTiposMovComboBox() As String

        Dim DataArray As Array = Benavides.CC.Data.clstblTipoMovimientoAntibiotico.strBuscar("0", "", #1/1/2000#, "", 0, 0, strConnectionString)

        Dim strData As System.Text.StringBuilder = Nothing
        Dim avntRow As Array = Nothing

        Dim intCounter As Integer = 1
        If IsArray(DataArray) = True AndAlso DataArray.Length > 0 Then

            strData = New System.Text.StringBuilder
            For Each avntRow In DataArray
                strData.Append("  document.forms[0].elements[""cboTiposMov""].options[" & intCounter & "] = new Option(""" & strConvertToJavascriptString(CStr(avntRow.GetValue(1))) & """,""" & strConvertToJavascriptString(CStr(avntRow.GetValue(0))) & """);" & vbCrLf)
                intCounter += 1
            Next

            Return strData.ToString()
        End If

    End Function


    Private Function strComplete2Digit(ByVal strValue As String) As String
        If Len(strValue) = 1 Then
            Return "0" & strValue
        Else
            Return strValue
        End If
    End Function


    '====================================================================
    ' Name       : strConvertToJavascriptString
    ' Description: Returns a string containing a safe Javascript clause
    ' Parameters :
    '              ByVal Value As String
    '                 - The string to be converted
    '====================================================================
    Public Shared Function strConvertToJavascriptString(ByVal Value As String) As String

        ' Member identifier
1:      Const strmThisMemberName As String = "strConvertToJavascriptString"

        ' Declare the returned value
2:      Dim strData As String = ""

3:      Try

            ' Sanitize the value
4:          If Len(Value) > 0 Then
5:              strData = Replace(Value, "\", "\\")
6:              strData = Replace(strData, """", "\""")
7:              strData = Replace(strData, vbCrLf, "\r\n")
8:              strData = Replace(strData, vbCr, "")
9:              strData = Replace(strData, vbLf, "")
10:         End If

            ' Return the sanitized value
11:         Return strData

12:     Catch objException As Exception


38:         Return ""

39:     End Try

    End Function

    Public Shared Function objEliminaDuplicados(ByVal array As Array) As Array
        Dim list As New ArrayList
        Dim id As String = ""

        For Each id In array
            If Not list.Contains(id) Then
                list.Add(id)
            End If
        Next

        Return list.ToArray()

    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strHTML As New StringBuilder


        ' Execute the selected command
        Select Case strCmd

            Case "BuscarArticulo"
                Dim strAccion As String = "0" ' BUSCAR ARTICULO
                Dim strErrorBuscaArticulo As String = ""

                Dim objArrayArticulo As Array = Nothing
                Dim strRegistroArticulo As String()

                Dim intArticuloBuscadoId As Integer = 0
                Dim strArticuloBuscadoDescripcion As String = ""

                ' Obtenemos la información del Articulo
                objArrayArticulo = Benavides.CC.Data.clstblArticulo.strBuscarAntibioticos(intArticuloId, "", strConnectionString)

                If IsArray(objArrayArticulo) AndAlso (objArrayArticulo.Length > 0) Then
                    strRegistroArticulo = DirectCast(objArrayArticulo.GetValue(0), String())

                    intArticuloBuscadoId = CInt(strRegistroArticulo(0))
                    strArticuloBuscadoDescripcion = clsCommons.strFormatearDescripcion(strRegistroArticulo(8))
                    strErrorBuscaArticulo = "0"
                Else
                    intArticuloBuscadoId = 0
                    strArticuloBuscadoDescripcion = ""
                    strErrorBuscaArticulo = "-100"
                End If


                strHTML.Append("<script language='Javascript'> " & _
                                "parent.fnUpBuscarArticulo( " & _
                                strComitasDobles & strErrorBuscaArticulo & strComitasDobles & "," & _
                                strComitasDobles & intArticuloBuscadoId.ToString & strComitasDobles & "," & _
                                strComitasDobles & strArticuloBuscadoDescripcion & strComitasDobles & _
                                "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "Agregar"
                strHTML.Append("<script language='Javascript'> parent.fnUpAgregar ( " & _
                               strComitasDobles & intArticuloId.ToString & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

        End Select

    End Sub


End Class
