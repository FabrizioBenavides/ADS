Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Benavides.POSAdmin.Commons.clsCommons.clsMSMQ
Imports System.Text
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports System.IO
Imports System.Web.Caching
Imports Benavides.CC.Business
Imports System.Configuration
Imports Isocraft.Web.Javascript
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data


Public Class RentaEspaciosAsignar
    Inherits System.Web.UI.Page

    'Constantes
    Public Const BEGIN_TABLE As String = "<table width='100%' border='0' cellpadding='0' cellspacing='0'>"
    Public Const END_TABLE As String = "</table>"
    Public Const RAYITA As String = "<tr><td height='4' colspan='9' bgcolor='666666'><img src='../static/images/pixel.gif' width='1' height='4'></td></tr>"
    Public Const ESPACIO As String = "<tr><td height='8' colspan='9'><img src='../static/images/pixel.gif' width='1' height='8'></td></tr>"
    Public Const ESPACIO_VACIO As String = "&nbsp;"

    Private intDireccionOperativaId As Integer
    Private intZonaOperativaId As Integer
    Dim astrRecords As Array
    Dim strmRecordBrowserHTML As String
    Private intExhibicionId As Integer
    Dim strmTotalDePartidas As Integer
    Private strmArchivo As String = String.Empty
    Private strmRutaArchivo As String = String.Empty
    Private intmDireccionId As Integer
    Private intmZonaId As Integer

    Protected WithEvents txtArchivo As System.Web.UI.HtmlControls.HtmlInputFile

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

        intDireccionOperativaId = GetPageParameter("cboDireccionOperativa", 0)
        intZonaOperativaId = GetPageParameter("cboZonaOperativa", 0)

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
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)
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
    ' Name       : intDireccionId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intDireccionId() As Integer
        Get
            Return intDireccionOperativaId 'intDireccionId
        End Get
    End Property

    '====================================================================
    ' Name       : intZonaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intZonaId() As Integer
        Get
            Return intZonaOperativaId 'intmZonaId
        End Get
    End Property

    '====================================================================
    ' Name       : LlenarControlDivision
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboDireccionOperativa
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlDivision() As String

        'Consultamos las direcciones operativas
        astrRecords = Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString)

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccionOperativa", intDireccionOperativaId, astrRecords, 0, 1, 2)

    End Function

    '====================================================================
    ' Name       : LlenarControlZona
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboZona
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlZona() As String

        ' Validamos si hay una Direccion Operativa seleccionada
        If intDireccionOperativaId > 0 Then

            ' Inicializamos el arreglo
            astrRecords = Nothing

            'Consultamos las direcciones operativas
            astrRecords = Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionOperativaId, 0, strConnectionString)

            ' Formamos el string con los valores
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZonaOperativa", intZonaOperativaId, astrRecords, 0, 1, 2)
        End If
    End Function

    '====================================================================
    ' Name       : strExhibicionId
    ' Description: Codigo del filtro 0 = Nuevo, 1 = Editar
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strExhibicionId() As String
        Get
            If Not IsNothing(Request.QueryString("strExhibicionId")) Then
                'Si es parametro de la pantalla anterior
                Return Request.QueryString("strExhibicionId")
            ElseIf Not IsNothing(Request.Form("hdnExhibicionId")) Then
                'Si es parametro de la forma (misma pantalla)
                Return Request.Form("hdnExhibicionId")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strCargadoDeSucursales
    ' Description: Leer la opcion marcada de como se cargaron las sucursales.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCargadoDeSucursales() As String
        Get
            If Not IsNothing(Request.Form("hdnCargadoDeSucursales")) Then
                Return Request.Form("hdnCargadoDeSucursales")
            Else
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strArchivo
    ' Description: Ruta del archivo ".csv" cargado que contiene las sucursales.
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strArchivo() As String
        Get
            Return strmArchivo
        End Get
        Set(ByVal strValue As String)
            strmArchivo = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intOpcionCarga
    ' Description: Leer la opcion marcada para cargar las sucursales
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intOpcionCarga() As String
        Get
            If Not IsNothing(Request.Form("cmdFiltroAsignacion")) Then
                Return Request.Form("cmdFiltroAsignacion")
            Else
                Return "1"
            End If
        End Get
    End Property

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

    'Tabla de registro a "Asignar".
    Public Function strTablaConsultaExhibicion() As String
        Dim objArray As System.Array = Nothing
        Dim strResult As New StringBuilder()
        Dim strBtnAsignar As String = String.Empty


        If Not IsNothing(strExhibicionId) AndAlso CInt(strExhibicionId) > 0 Then

            objArray = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarExhibicionDetalle(CInt(strExhibicionId), strConnectionString)

            If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then
                strResult.Append(strTablaConsultaExhibicionHTML(objArray))
                strBtnAsignar = "block"
            Else
                strResult.Append(String.Empty)
                strBtnAsignar = "none"
            End If

            strResult.Append("<script language=""javascript"" type=""text/javascript"">")
            strResult.Append("parent.document.getElementById('tblResultados').innerHTML = document.getElementById('divConsultaExhibicion').innerHTML;")

            strResult.Append("</script>")

            Return strResult.ToString()
        End If

        Return String.Empty
    End Function

    Public Function strTablaConsultaExhibicionHTML(ByVal objConsultaExhibicion As Array) As String
        Dim strTablaExhibicionHTML As StringBuilder
        Dim strConsultaExhibicion As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer

        strTablaExhibicionHTML = New StringBuilder
        strTablaExhibicionHTML.Append("<span class='txsubtitulo'> </span> ")

        strTablaExhibicionHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strTablaExhibicionHTML.Append("<tr class='trtitulos'>")
        strTablaExhibicionHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Nombre de Exhibición</th>")
        strTablaExhibicionHTML.Append("<th width='15%' align=center class='rayita' align='left' valign='top'>Tipo de Renta</th>")
        strTablaExhibicionHTML.Append("<th width='15%' align=center class='rayita' align='left' valign='top'>Proveedor</th>")
        strTablaExhibicionHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>División</th>")
        strTablaExhibicionHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Categoría</th>")
        strTablaExhibicionHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Planograma</th>")
        strTablaExhibicionHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Precio</th>")
        strTablaExhibicionHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Fecha<br>Inicio</th>")
        strTablaExhibicionHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Fecha<br>Fin</th>")
        strTablaExhibicionHTML.Append("</tr>")

        intContador = 0

        strConsultaExhibicion = CType(objConsultaExhibicion.GetValue(0), String())

        strColorRegistro = "'tdceleste'"

        strTablaExhibicionHTML.Append("<tr>")

        'Nombre de la Exhibición 
        strTablaExhibicionHTML.Append("<td class=" & strColorRegistro & " align='left'>" & clsCommons.strFormatearDescripcion(strConsultaExhibicion(17)) & "</td>")
        'Tipo de Renta         
        strTablaExhibicionHTML.Append("<td id=tdCodigo" & intContador.ToString() & " align='left' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibicion(12)) & "</td>")
        'Proveedor               
        strTablaExhibicionHTML.Append("<td class=" & strColorRegistro & " align='left'>" & clsCommons.strFormatearDescripcion(strConsultaExhibicion(10)) & "</td>")
        'División                    
        strTablaExhibicionHTML.Append("<td class=" & strColorRegistro & " align='left'>" & clsCommons.strFormatearDescripcion(strConsultaExhibicion(2)) & "</td>")
        'Categoría                   
        strTablaExhibicionHTML.Append("<td class=" & strColorRegistro & " align='left'>" & clsCommons.strFormatearDescripcion(strConsultaExhibicion(4)) & "</td>")
        'Planograma
        strTablaExhibicionHTML.Append("<td class=" & strColorRegistro & " align='center'>" & clsCommons.strFormatearDescripcion(strConsultaExhibicion(22)) & "</td>")
        'Precio                
        strTablaExhibicionHTML.Append("<td class=" & strColorRegistro & " align='right'>" & "$" & CDec(strConsultaExhibicion(31)).ToString() & "</td>")
        'Fecha Ini             
        strTablaExhibicionHTML.Append("<td class=" & strColorRegistro & " align='left'>" & clsCommons.strFormatearFechaPresentacion(strConsultaExhibicion(33)) & "</td>")
        'Fecha Fin
        strTablaExhibicionHTML.Append("<td class=" & strColorRegistro & " align='left'>" & clsCommons.strFormatearFechaPresentacion(strConsultaExhibicion(34)) & "</td>")

        strTablaExhibicionHTML.Append("</tr>")
        strTablaExhibicionHTML.Append("</table>")
        strTablaConsultaExhibicionHTML = strTablaExhibicionHTML.ToString
    End Function

#Region "Sucursales"
    Public Function strTablaConsultaSucursales() As String

        Dim objArraySucursales As System.Array = Nothing
        strmTotalDePartidas = 0

        If (Request.QueryString("strCmd") = "cmdConsultarSucursales") Or (((Request.QueryString("strCmd") = "cmdAsignar") Or (Request.QueryString("strCmd") = "cmdEliminar")) AndAlso (strCargadoDeSucursales = "cmdConsultarSucursales")) Then

            If objArraySucursales Is Nothing Then

                ' Validamos si hay una Direccion Operativa y Zona Operativa seleccionadas
                If (intDireccionOperativaId = -1 AndAlso intZonaOperativaId = -1) Or (intDireccionOperativaId > 0 AndAlso Not intZonaOperativaId = 0) Then '(Not intDireccionOperativaId = 0 AndAlso Not intZonaOperativaId = 0) Then

                    objArraySucursales = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarSucursalesPorAsignar(intDireccionOperativaId, intZonaOperativaId, strConnectionString)

                    'Total de sucursales por asignar.
                    strmTotalDePartidas = objArraySucursales.Length
                End If
            End If

            Dim strResult As New StringBuilder()

            If Not objArraySucursales Is Nothing AndAlso IsArray(objArraySucursales) AndAlso objArraySucursales.Length > 0 Then

                strResult.Append(strTablaConsultaSucursalesesHTML(objArraySucursales))

            End If

            strResult.Append("<script language=""javascript"" type=""text/javascript"">")
            strResult.Append("parent.document.getElementById('tblSucursales').innerHTML = document.getElementById('divConsultaSucursales').innerHTML;")
            strResult.Append("</script>")

            Return strResult.ToString()
        End If

        Try
            'Importar archivo CSV
            If (Request.QueryString("strCmd") = "cmdImportar") Or ((Request.QueryString("strCmd") = "cmdAsignar" Or Request.QueryString("strCmd") = "cmdEliminar") AndAlso (strCargadoDeSucursales = "cmdImportar")) Then

                Dim MiTabla As DataTable = New DataTable()
                Dim separador As Char = ","c

                'Datos del archivo
                Dim _archivo As System.Web.HttpPostedFile
                Dim strNombreArchivo As String
                Dim strRutaFisica As String = String.Empty
                Dim strRutaRelativaArchivo As String
                Dim strExtensionArchivo As String


                _archivo = txtArchivo.PostedFile

                If _archivo Is Nothing Then
                    Return String.Empty
                End If

                strNombreArchivo = Path.GetFileName(_archivo.FileName)

                If strNombreArchivo.Length = 0 Then
                    If txtArchivo.Value.Trim() = String.Empty AndAlso Not Trim(Request.Form("hdnArchivo").ToString()) = String.Empty Then
                        strNombreArchivo = Request.Form("hdnArchivo").ToString()
                    Else
                        Return String.Empty
                    End If
                End If

                If Not Trim(strNombreArchivo) = String.Empty Then

                    strExtensionArchivo = Path.GetExtension(strNombreArchivo).ToUpper()

                    If strExtensionArchivo = ".CSV" Then

                        strRutaRelativaArchivo = Response.ApplyAppPathModifier(ConfigurationSettings.AppSettings("strArchivoSucursales") & strNombreArchivo)

                        If System.IO.File.Exists(strRutaRelativaArchivo) = True Then

                            File.Delete(strRutaRelativaArchivo)

                        End If

                        txtArchivo.PostedFile.SaveAs(strRutaRelativaArchivo)

                        'Se guarda el nombre del archivo para la paginacion
                        strmArchivo = strNombreArchivo

                        MiTabla = ConstruirDatatable(strRutaRelativaArchivo, separador)
                        txtArchivo.PostedFile.InputStream.Close()
                    Else
                        Call Response.Write("<script language='Javascript'>alert('El formato del archivo es incorrecto, favor de cargar un archivo "".csv""');</script>")
                    End If
                End If

                'Total de sucursales por asignar.
                strmTotalDePartidas = MiTabla.Rows.Count
                Dim strResult As New StringBuilder()

                If MiTabla.Rows.Count = 0 Then
                    Call Response.Write("<script language='Javascript'>alert('El archivo esta vacio');</script>")
                ElseIf MiTabla.Rows.Count > 0 Then
                    strResult.Append(strTablaConsultaArchivoSucursalesesHTML(MiTabla))
                Else
                    Return String.Empty
                End If

                strResult.Append("<script language=""javascript"" type=""text/javascript"">")
                strResult.Append("parent.document.getElementById('tblSucursales').innerHTML = document.getElementById('divConsultaSucursales').innerHTML;")
                strResult.Append("</script>")

                Return strResult.ToString()
            End If
        Catch ex As Exception
            Call Response.Write("<script language='Javascript'>alert('Ocurrio un error al cargar un archivo "".csv""');</script>")
        End Try

        Return String.Empty
    End Function

    Public Function strTablaConsultaSucursalesesHTML(ByVal objConsultaSucursales As Array) As String
        Dim strTablaSucursalesHTML As StringBuilder
        Dim strConsultaSucursales As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim chkbox As String = Nothing
        Dim idName As String = Nothing

        'Indices de los valores dependiendo como se obtengan (Seleccion de Combos o Importar Archivo)
        Dim intCentroLogisticoId As Integer 
        Dim intSucursalId As Integer

        intCentroLogisticoId = 2
        intSucursalId = 3

        If Request.QueryString("strCmd") = "cmdImportar" Then
            intCentroLogisticoId = 0
            intSucursalId = 1
        End If

        Dim intPage As Integer
        Dim intTotal As Integer = 10000

        intPage = 1

        strTablaSucursalesHTML = New StringBuilder

        strTablaSucursalesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strTablaSucursalesHTML.Append("<tr>")
        strTablaSucursalesHTML.Append("<td class='txsubtitulo' valign='top'>Sucursales:</td>")
        strTablaSucursalesHTML.Append("<td align='right' valign='top'>")
        strTablaSucursalesHTML.Append("<input id='cmdAsignar' class='button' value='Asignar' type='button' name='cmdAsignar' onclick='return cmdAsignar_onclick();' style='margin-top:0px; top: 50px;'> ")
        strTablaSucursalesHTML.Append("</td>")
        strTablaSucursalesHTML.Append("</tr>")

        idName = "id=chkCodigo name=chkCodigo"
        chkbox = "<input type='checkbox' " & idName & " checked onclick='javascript:fnMarcarTodos()'>"

        strTablaSucursalesHTML.Append("<tr class='trtitulos'>")
        strTablaSucursalesHTML.Append("<th width='30%' align='left' class='rayita' valign='top'>" & chkbox & "Sucursal</th>")
        strTablaSucursalesHTML.Append("<th width='70%' align=center class='rayita' valign='top'>Nombre</th>")
        strTablaSucursalesHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaSucursales.Length) Then
                Exit For
            End If

            strConsultaSucursales = CType(objConsultaSucursales.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            'Si NO es consulta se agergan los checkbox's
            idName = "id=chkCodigo" & intContador.ToString() & " " & "name=chkCodigo" & intContador.ToString()
            chkbox = "<input type='checkbox' " & idName & " value=" & strConsultaSucursales(intCentroLogisticoId) & " checked onclick='javascript:fnMarcarUno()'/>"

            strTablaSucursalesHTML.Append("<tr>")
            'Sucursal
            strTablaSucursalesHTML.Append("<td id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & chkbox & strConsultaSucursales(intCentroLogisticoId) & "</td>")
            'Nombre               
            strTablaSucursalesHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaSucursales(intSucursalId)) & "</td>")
            strTablaSucursalesHTML.Append("</tr>")

        Next
        strTablaSucursalesHTML.Append("</tr>")
        strTablaSucursalesHTML.Append("</table>")
        strTablaConsultaSucursalesesHTML = strTablaSucursalesHTML.ToString
    End Function

    Private Function ConstruirDatatable(ByVal RutaCompletaArchivo As String, ByVal Separador As Char) As DataTable

        'declaramos la Tabla donde añadiremos los datos y la fila correspondiente
        Dim MiTabla As DataTable = New DataTable("MyTable")
        Dim MiFila As DataRow

        'declaramos el resto de variables que nos harán falta
        Dim pos As Boolean = False
        Dim fieldValues As String()
        Dim miReader As System.IO.StreamReader
        Dim strSucursal As String = String.Empty
        Dim mensaje As String = String.Empty
        Try
            'Abrimos el fichero y leemos la primera linea con el fin de determinar cuantos campos tenemos
            miReader = File.OpenText(RutaCompletaArchivo)
            fieldValues = miReader.ReadLine().Split(Separador)

            'Creamos las columnas de la cabecera
            If fieldValues.Length() > 0 AndAlso Not fieldValues(0).ToString() Is Nothing AndAlso Not Trim(fieldValues(0).ToString()) = String.Empty Then
                MiTabla.Columns.Add(New DataColumn("Codigo"))
                MiTabla.Columns.Add(New DataColumn("Sucursal"))
            End If

            'Continuamos leyendo el resto de filas y añadiendolas a la tabla
            While miReader.Peek() <> -1
                fieldValues = miReader.ReadLine().Split(Separador)
                MiFila = MiTabla.NewRow

                If Not fieldValues(0).ToString() Is Nothing AndAlso Not Trim(fieldValues(0).ToString()) = String.Empty Then

                    strSucursal = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarSucursalPorCentroLogistico(fieldValues(0).ToString(), strConnectionString)

                    If Not Trim(strSucursal) = String.Empty Then
                        MiFila.Item(0) = fieldValues(0).ToString
                        MiFila.Item(1) = strSucursal
                        MiTabla.Rows.Add(MiFila)
                    End If
                End If
            End While

            'Cerramos el reader
            miReader.Close()
            miReader = Nothing
        Catch ex As Exception
            'Gestionamos las excepciones, Aqui cada uno puede hacer lo que crea conveniente: Mostrar un error en Javascript en este caso y devolver el Datatable vacío

            mensaje = "alert ('Ha ocurrido el siguiente error al importar el archivo: " + ex.ToString + "');"
            'System.Web.UI.ScriptManager.RegisterStartupScript(Page, Me.GetType(), "ErrorConstruirDatabale", mensaje, True)
            'Return New DataTable("Empty")
        Finally
            'Si queremos ejecutar algo exista excepción o no
        End Try
        'Devolvemos el DataTable si todo ha ido bien
        'miReader.Close()

        If Not mensaje = String.Empty Then
            Return New DataTable("Empty")
        End If
        Return MiTabla
    End Function

    Public Function strTablaConsultaArchivoSucursalesesHTML(ByVal tblConsultaSucursales As DataTable) As String
        Dim strTablaSucursalesHTML As StringBuilder
        Dim strConsultaSucursales As String() = Nothing
        Dim rowConsultaSucursales As DataRow
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim chkbox As String = Nothing
        Dim idName As String = Nothing

        'Indices de los valores dependiendo como se obtengan (Seleccion de Combos o Importar Archivo)
        Dim intCentroLogisticoId As Integer
        Dim intSucursalId As Integer

        intCentroLogisticoId = 0
        intSucursalId = 1

        Dim intPage As Integer
        Dim intTotal As Integer = 10000

        intPage = 1

        strTablaSucursalesHTML = New StringBuilder

        strTablaSucursalesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strTablaSucursalesHTML.Append("<tr>")
        strTablaSucursalesHTML.Append("<td class='txsubtitulo' valign='top'>Sucursales:</td>")
        strTablaSucursalesHTML.Append("<td align='right' valign='top'>")
        strTablaSucursalesHTML.Append("<input id='cmdAsignar' class='button' value='Asignar' type='button' name='cmdAsignar' onclick='return cmdAsignar_onclick();' style='margin-top:0px; top: 50px;'> ")
        strTablaSucursalesHTML.Append("</td>")
        strTablaSucursalesHTML.Append("</tr>")

        idName = "id=chkCodigo name=chkCodigo"
        chkbox = "<input type='checkbox' " & idName & " checked onclick='javascript:fnMarcarTodos()'>"

        strTablaSucursalesHTML.Append("<tr class='trtitulos'>")
        strTablaSucursalesHTML.Append("<th width='30%' align='left' class='rayita' valign='top'>" & chkbox & "Sucursal</th>")
        strTablaSucursalesHTML.Append("<th width='70%' align=center class='rayita' valign='top'>Nombre</th>")
        strTablaSucursalesHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= tblConsultaSucursales.Rows.Count) Then
                Exit For
            End If

            rowConsultaSucursales = tblConsultaSucursales.Rows(intContador)

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            'Si NO es consulta se agergan los checkbox's
            idName = "id=chkCodigo" & intContador.ToString() & " " & "name=chkCodigo" & intContador.ToString()
            chkbox = "<input type='checkbox' " & idName & " value=" & rowConsultaSucursales(intCentroLogisticoId).ToString() & " checked onclick='javascript:fnMarcarUno()'/>"

            strTablaSucursalesHTML.Append("<tr>")
            'Sucursal
            strTablaSucursalesHTML.Append("<td id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & chkbox & rowConsultaSucursales(intCentroLogisticoId).ToString() & "</td>")
            'Nombre               
            strTablaSucursalesHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(rowConsultaSucursales(intSucursalId).ToString()) & "</td>")
            strTablaSucursalesHTML.Append("</tr>")
        Next

        strTablaSucursalesHTML.Append("</tr>")
        strTablaSucursalesHTML.Append("</table>")
        strTablaConsultaArchivoSucursalesesHTML = strTablaSucursalesHTML.ToString
    End Function
#End Region

#Region "Sucursales Asignadas"
    Public Function strTablaConsultaSucursalesAsignadas() As String

        Dim objArraySucursalesAsignadas As System.Array = Nothing
        Dim strResult As New StringBuilder()

        If objArraySucursalesAsignadas Is Nothing Then
            objArraySucursalesAsignadas = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarSucursalesAsignadas(CInt(strExhibicionId), strConnectionString)
        End If

        If Not objArraySucursalesAsignadas Is Nothing AndAlso IsArray(objArraySucursalesAsignadas) AndAlso objArraySucursalesAsignadas.Length > 0 Then
            strResult.Append(strTablaConsultaSucursalesAsignadasesHTML(objArraySucursalesAsignadas))
        End If

        strResult.Append("<script language=""javascript"" type=""text/javascript"">")
        strResult.Append("parent.document.getElementById('tblSucursalesAsignadas').innerHTML = document.getElementById('divConsultaSucursalesAsignadas').innerHTML;")
        strResult.Append("</script>")

        Return strResult.ToString()
    End Function

    Public Function strTablaConsultaSucursalesAsignadasesHTML(ByVal objConsultaSucursales As Array) As String
        Dim strTablaSucursalesHTML As StringBuilder
        Dim strConsultaSucursales As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim imgEliminar As String = Nothing
        Dim imgImplementado As String = Nothing

        'Paginacion
        Dim intPage As Integer
        Dim intTotal As Integer = 10000
        intPage = 1

        strTablaSucursalesHTML = New StringBuilder
        strTablaSucursalesHTML.Append("<span class='txsubtitulo'>Sucursales asignadas:</span> ")
        strTablaSucursalesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        strTablaSucursalesHTML.Append("<tr class='trtitulos'>")
        strTablaSucursalesHTML.Append("<th width='55%' align=center class='rayita' valign='top'>Local</th>")
        strTablaSucursalesHTML.Append("<th width='22.5%' align=center class='rayita' valign='top'>Implementada</th>")
        strTablaSucursalesHTML.Append("<th width='22.5%' align=center class='rayita' valign='top'>Acción</th>")
        strTablaSucursalesHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaSucursales.Length) Then
                Exit For
            End If

            strConsultaSucursales = CType(objConsultaSucursales.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            imgImplementado = "<img id=Asi" & strConsultaSucursales(0) & " height='17' src='../static/images/imgNRTrasmitido.gif' width='17' align='absMiddle' border='0'>"
            imgEliminar = "<img id=" & strConsultaSucursales(1) & " height='17' src='../static/images/icono_borrar.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdEliminar_onclick(this.id)' alt='Eliminar'>"

            'Validacion de la asignacion
            If CBool(Trim(strConsultaSucursales(3))) = False Then
                imgImplementado = "&nbsp"
            End If

            strTablaSucursalesHTML.Append("<tr>")

            'Código y Nombre	
            strTablaSucursalesHTML.Append("<td align=left id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaSucursales(1)) & " " & clsCommons.strFormatearDescripcion(strConsultaSucursales(2)) & "</td>")
            'Implementada
            strTablaSucursalesHTML.Append("<td align=center class=" & strColorRegistro & ">" & imgImplementado & "</td>")
            'Acción
            strTablaSucursalesHTML.Append("<td align=center class=" & strColorRegistro & ">" & imgEliminar & "</td>")
            strTablaSucursalesHTML.Append("</tr>")

        Next
        strTablaSucursalesHTML.Append("</tr>")
        strTablaSucursalesHTML.Append("</table>")
        strTablaConsultaSucursalesAsignadasesHTML = strTablaSucursalesHTML.ToString 'clsCommons.strGenerateJavascriptString(strTablaSucursalesHTML.ToString)
    End Function
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load 'Me.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        'Si no se cueunta con Id se redirecciona a la pantalla de "Consulta" para evitar perdida de informacion.
        If CInt(strExhibicionId) < 1 Then
            Call Response.Redirect("RentaEspaciosConsulta.aspx")
        End If


        Dim intResultado As Integer = 0

        If Request.QueryString("strCmd") = "cmdAsignar" And CInt(strExhibicionId) > 0 Then
            Try
                'Codigo para asignar sucursales
                Dim intTotalDePartidas As Integer
                Dim intPartida As Integer
                Dim objArray As System.Array = Nothing
                Dim boolSeleccion As Boolean = False

                ' Agregar Cenefa Manual Articulo
                intTotalDePartidas = CInt(Request("hdnTotalDePartidas"))

                For intPartida = 0 To intTotalDePartidas - 1

                    If Len(Trim(Request("chkCodigo" & intPartida.ToString))) > 0 Then

                        boolSeleccion = True

                        'Agregar codigo para asignar sucursales...
                        intResultado = Benavides.CC.Data.clsExhibicionesAdicionales.strAsignarSucursal(CInt(strExhibicionId), Request("chkCodigo" & intPartida.ToString), strUsuarioNombre, strConnectionString)
                    End If
                Next

                If intResultado > 0 Then
                    Call Response.Write("<script language='Javascript'>alert('La asignacion se ha realizado con exito');</script>")
                End If

                If boolSeleccion = False Then
                    Call Response.Write("<script language='Javascript'>alert('Seleccione una sucursal para asignar');</script>")
                End If
            Catch ex As Exception
                Call Response.Write("<script language='Javascript'>alert('Ocurrio un error durante la asignacion');</script>")
            End Try

        ElseIf Request.QueryString("strCmd") = "cmdEliminar" Then
            Try
                Dim strCentroLogisticoId As String
                strCentroLogisticoId = Request.QueryString("strCentroLogisticoId")

                intResultado = Benavides.CC.Data.clsExhibicionesAdicionales.intEliminarSucursalAsignada(CInt(strExhibicionId), strCentroLogisticoId, strConnectionString)

                'Codigo para eliminar una sucursal
                If (intResultado = 1) Then
                    Call Response.Write("<script language='Javascript'>alert('La sucursal se elimino con exito');</script>")
                Else
                    Call Response.Write("<script language='Javascript'>alert('La sucursal NO se pudo eliminar');</script>")
                End If
            Catch ex As Exception
                Call Response.Write("<script language='Javascript'>alert('Ocurrio un error durante la eliminacion');</script>")
            End Try
        End If
    End Sub

    '====================================================================
    ' Name       : displayScrollTable
    ' Description: Despliega una tabla que maneje el scroll para un arreglo de datos
    ' Parameters : 
    '              ByVal totalRows As Integer
    '                - numero de renglones
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
    Public Shared Function displayScrollSucursales(ByVal totalRows As Integer, _
            ByRef currentPage As Integer, _
            ByVal maxPerPage As Integer, _
            ByVal goToLink As String, _
            ByVal actions As Array, _
            Optional ByVal linkName As String = "intNavegadorRegistrosPagina", _
            Optional ByVal imagePath As String = "../static/images/") As String

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
        Dim link As String = "doSubmitSucursales('skipPage','" + linkName + "','"

        If endRow > totalRows Then
            endRow = totalRows
        End If

        If previousPage <= 0 Then
            previousPage = 1
        End If

        If nextPage > lastPage Then
            nextPage = lastPage
        End If

        Dim code As StringBuilder = New StringBuilder

        code.Append(BEGIN_TABLE)
        code.Append(RAYITA)
        code.Append(ESPACIO)
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
        code.Append("    <a href=""javascript:")
        code.Append(link)
        code.Append("1')""><img src='")
        code.Append(imagePath)
        code.Append("icono_inicio.gif' width='17' height='17' align='absmiddle' border='0'>")
        code.Append("</a>")
        code.Append("<a href=""javascript:")
        code.Append(link)
        code.Append(previousPage)
        code.Append("')""><img src='")
        code.Append(imagePath)
        code.Append("icono_back.gif' width='25' height='17' align='absmiddle' border='0'>")
        code.Append("</a>")
        code.Append("  </td>")
        code.Append("  <td width='14%' align='center' valign='middle'>")

        code.Append(addPageLinks(link, currentPage, lastPage))

        code.Append("  </td>")
        code.Append("  <td width='8%' align='left'>")
        code.Append("    <a href=""javascript:")
        code.Append(link)
        code.Append(nextPage)
        code.Append("')""><img src='")
        code.Append(imagePath)
        code.Append("icono_fwd.gif' width='25' height='17' align='absmiddle' border='0'>")
        code.Append("</a>")
        code.Append("<a href=""javascript:")
        code.Append(link)
        code.Append(lastPage)
        code.Append("')""><img src='")
        code.Append(imagePath)
        code.Append("icono_final.gif' width='17' height='17' align='absmiddle' border='0'>")
        code.Append("</a>")
        code.Append("  </td>")

        code.Append(" </tr>")
        code.Append(ESPACIO)
        code.Append(RAYITA)
        code.Append(END_TABLE)

        Return code.ToString
    End Function

    '====================================================================
    ' Name       : addPageLinks
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
    Private Shared Function addPageLinks(ByVal link As String, ByVal currentPage As Integer, ByVal lastPage As Integer) As String
        Dim code As StringBuilder = New StringBuilder

        If currentPage = 1 Then
            'si currentPage =1
            'desplegar currentPage, currentPage+1, currentPage+2, currentPage+3, currentPage+4
            code.Append(pageLink(link, currentPage, currentPage, lastPage))
            code.Append(pageLink(link, currentPage + 1, currentPage, lastPage))
            code.Append(pageLink(link, currentPage + 2, currentPage, lastPage))
            code.Append(pageLink(link, currentPage + 3, currentPage, lastPage))
            code.Append(pageLink(link, currentPage + 4, currentPage, lastPage))
        ElseIf currentPage = 2 Then
            'si currentPage =2
            'desplegar currentPage-1, currentPage, currentPage+1, currentPage+2, currentPage+3
            code.Append(pageLink(link, currentPage - 1, currentPage, lastPage))
            code.Append(pageLink(link, currentPage, currentPage, lastPage))
            code.Append(pageLink(link, currentPage + 1, currentPage, lastPage))
            code.Append(pageLink(link, currentPage + 2, currentPage, lastPage))
            code.Append(pageLink(link, currentPage + 3, currentPage, lastPage))
        ElseIf currentPage >= 3 AndAlso currentPage <= (lastPage - 2) Then
            'si currentPage >=3 y currentPage <= (lastPage-2)
            'desplegar currentPage-2, currentPage-1, currentPage, currentPage+1, currentPage+2
            code.Append(pageLink(link, currentPage - 2, currentPage, lastPage))
            code.Append(pageLink(link, currentPage - 1, currentPage, lastPage))
            code.Append(pageLink(link, currentPage, currentPage, lastPage))
            code.Append(pageLink(link, currentPage + 1, currentPage, lastPage))
            code.Append(pageLink(link, currentPage + 2, currentPage, lastPage))
        ElseIf currentPage = (lastPage - 1) Then
            'si currentPage = (lastPage-1)
            'desplegar currentPage-3, currentPage-2, currentPage-1, currentPage, currentPage+1
            code.Append(pageLink(link, currentPage - 3, currentPage, lastPage))
            code.Append(pageLink(link, currentPage - 2, currentPage, lastPage))
            code.Append(pageLink(link, currentPage - 1, currentPage, lastPage))
            code.Append(pageLink(link, currentPage, currentPage, lastPage))
            code.Append(pageLink(link, currentPage + 1, currentPage, lastPage))
        ElseIf currentPage = lastPage Then
            'si currentPage = (lastPage)
            'desplegar currentPage-4, currentPage-3, currentPage-2, currentPage-1, currentPage
            code.Append(pageLink(link, currentPage - 4, currentPage, lastPage))
            code.Append(pageLink(link, currentPage - 3, currentPage, lastPage))
            code.Append(pageLink(link, currentPage - 2, currentPage, lastPage))
            code.Append(pageLink(link, currentPage - 1, currentPage, lastPage))
            code.Append(pageLink(link, currentPage, currentPage, lastPage))
        End If

        Return code.ToString
    End Function

    '====================================================================
    ' Name       : pageLink
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
    Private Shared Function pageLink(ByVal link As String, ByVal page As Integer, ByVal currentPage As Integer, ByVal lastPage As Integer) As String
        Dim code As StringBuilder = New StringBuilder

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
            code.Append("<a class='txaccion' href=""javascript:")
            code.Append(link)
            code.Append(page)
            code.Append("')"">")
            code.Append(page)
            code.Append("</a>")
        End If
        code.Append(ESPACIO_VACIO)
        code.Append(ESPACIO_VACIO)

        Return code.ToString

    End Function

End Class