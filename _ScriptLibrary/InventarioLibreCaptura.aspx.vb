Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Configuration
Imports System.Text
Imports prjCCInventarioBusiness.Benavides.InvRot.Data

Public Class clsInventarioLibreCaptura
    Inherits System.Web.UI.Page

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

    Const strComitasDobles As String = """"

    Private intmTotalRegistrosCapturados As Integer
    Private intmTotalExistenciasCapturadas As Integer
    Private intmInventarioFolio As Integer

    Public ReadOnly Property intRenglonesxPagina() As Integer
        Get
            Return 46
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
    ' Name       : strFormActionParameters
    ' Description: Parametros utilizados
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormActionParameters() As String
        Get
            Return ""
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
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strInventarioId
    ' Description: 
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strInventarioId() As String
        Get
            If Len(Request("hdnInventarioId")) > 0 Then
                Return (Request("hdnInventarioId"))
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strArticuloCapturado
    ' Description: Cadena para buscar el numero de articulo
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strArticuloCapturado() As String
        Get
            If Not IsNothing(Request("txtArticuloId")) Then
                Return Request("txtArticuloId")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strExistenciaCapturada
    ' Description: 
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strExistenciaCapturada() As String
        Get
            If Not IsNothing(Request("txtExistencia")) Then
                Return (Request("txtExistencia"))
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strCifraControlCapturada
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCifraControlCapturada() As String
        Get
            If Not IsNothing(Request("txtCifraControl")) Then
                Return Trim(Request("txtCifraControl"))
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intllaveArticuloEliminar
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intllaveArticuloEliminar() As Integer
        Get
            If Not IsNothing(Request("intArticuloEliminarId")) Then
                Return CInt(Trim(Request("intArticuloEliminarId")))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intTotalRegistrosCapturados
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intTotalRegistrosCapturados() As Integer
        Get
            Return intmTotalRegistrosCapturados
        End Get

        Set(ByVal Value As Integer)
            intmTotalRegistrosCapturados = Value
        End Set
    End Property

    '====================================================================
    ' Name       : intTotalExistenciasCapturadas
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intTotalExistenciasCapturadas() As Integer
        Get
            Return intmTotalExistenciasCapturadas
        End Get

        Set(ByVal Value As Integer)
            intmTotalExistenciasCapturadas = Value
        End Set
    End Property

    '====================================================================
    ' Name       : intInventarioFolio
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intInventarioFolio() As Integer
        Get
            Return intmInventarioFolio
        End Get

        Set(ByVal Value As Integer)
            intmInventarioFolio = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strGeneraImpresionDiferencias
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strGeneraImpresionDiferencias(ByVal objArrayInventarioDiferencias As Array) As String

        Dim strImpresionInventarioDiferenciasHTML As StringBuilder = New StringBuilder
        Dim strRegistroInventarioDiferencias As String()
        Dim strclase As String = ""

        If IsArray(objArrayInventarioDiferencias) AndAlso (objArrayInventarioDiferencias.Length > 0) Then

            Dim intTotalRenglones As Integer = objArrayInventarioDiferencias.Length
            Dim intTotalPaginas As Integer = 0

            Dim intPagina As Integer = 0
            Dim intRenglon As Integer = 0
            Dim intContadorRenglon As Integer = 0

            intTotalPaginas = intTotalRenglones \ intRenglonesxPagina

            If intTotalRenglones Mod intRenglonesxPagina > 0 Then
                intTotalPaginas += 1
            Else
                intTotalPaginas = 1
            End If


            intRenglon = 0
            intPagina = 0
            intContadorRenglon = 0

            For Each strRegistroInventarioDiferencias In objArrayInventarioDiferencias
                intRenglon += 1
                intContadorRenglon += 1

                If intRenglon = 1 Then
                    intPagina += 1

                    If intPagina > 1 Then
                        strImpresionInventarioDiferenciasHTML.Append("<p class='breakhere'></p>")
                    End If

                    strImpresionInventarioDiferenciasHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    strImpresionInventarioDiferenciasHTML.Append(strImprimeEncabezado(intPagina.ToString, intTotalPaginas.ToString))
                End If

                If ((intRenglon Mod 2) = 0) Then
                    strclase = "tdtxtImpresionNormal"
                Else
                    strclase = "tdtxtImpresionBold"
                End If


                strImpresionInventarioDiferenciasHTML.Append("<tr>")

                'No. de Renglon
                strImpresionInventarioDiferenciasHTML.Append("<td width='20' align='right' class='" & strclase & "' nowrap>" & clsCommons.strFormatearDescripcion(intContadorRenglon.ToString) & "</td>")

                ' intArticuloId
                strImpresionInventarioDiferenciasHTML.Append("<td width='50' align='right' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroInventarioDiferencias(1)).ToString & "</td>")

                ' strArticuloDescripcion
                strImpresionInventarioDiferenciasHTML.Append("<td width='280' class='" & strclase & "' nowrap >" & Mid(clsCommons.strFormatearDescripcion(strRegistroInventarioDiferencias(2)).ToString, 1, 32) & "</td>")

                ' Existencia
                strImpresionInventarioDiferenciasHTML.Append("<td width='68' align='right' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroInventarioDiferencias(3)).ToString & "</td>")

                ' Teorico
                strImpresionInventarioDiferenciasHTML.Append("<td width='68' align='right' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroInventarioDiferencias(4)).ToString & "</td>")

                'Diferencia
                strImpresionInventarioDiferenciasHTML.Append("<td width='68' align='right' class='" & strclase & "'>" & (CInt(strRegistroInventarioDiferencias(3)) - CInt(strRegistroInventarioDiferencias(4))).ToString & "</td>")

                strImpresionInventarioDiferenciasHTML.Append("</tr>")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionInventarioDiferenciasHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next

        End If

        Return strImpresionInventarioDiferenciasHTML.ToString()

    End Function

    Private Function strImprimeEncabezado(ByVal strHojaActual As String, ByVal strHojaFinal As String) As String

        Dim strHtmlEncabezado As StringBuilder

        strHtmlEncabezado = New StringBuilder


        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th align='center' colspan='6'  class='tdblancoSinRaya'>Reporte de Diferencias entre Existencia Real y Teórica (MERMA) </th>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th align='left'   colspan='2'  class='tdblancoSinRaya'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th align='center' colspan='3'  class='tdblancoSinRaya' nowrap>" & intCompaniaId & "-" & intSucursalId & " " & strSucursalNombre & "</th>")
        strHtmlEncabezado.Append("<th align='right'  class='tdblancoSinRaya'>HOJA " & strHojaActual & " / " & strHojaFinal & "</th>")
        strHtmlEncabezado.Append("</tr>")
        'Folio Inventario
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th align='left' colspan='6'  class='tdblancoSinRaya'>Folio: " & intInventarioFolio.ToString & "</th>")
        strHtmlEncabezado.Append("</tr>")
        ' Titulos
        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th width='20'  class='tdblancoSinRaya' align='right' nowrap>No.</th>")
        strHtmlEncabezado.Append("<th width='50'  class='tdblancoSinRaya' align='right' nowrap>Código</th>")
        strHtmlEncabezado.Append("<th width='280' class='tdblancoSinRaya' nowrap>Descripción</th>")
        strHtmlEncabezado.Append("<th width='68'  class='tdblancoSinRaya' align='right' nowrap>Existencia</th>")
        strHtmlEncabezado.Append("<th width='68'  class='tdblancoSinRaya' align='right' nowrap>Inv. Teórico</th>")
        strHtmlEncabezado.Append("<th width='68'  class='tdblancoSinRaya' align='right' nowrap>Diferencia</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola

        strHtmlEncabezado.Append("<tr class='trtitulos'>")
        strHtmlEncabezado.Append("<th width='20'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='50'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='280' class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='68'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='68'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("<th width='68'  class='rayita'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")


        strImprimeEncabezado = strHtmlEncabezado.ToString

    End Function

    '====================================================================
    ' Name       : strGeneraListaInventario
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Function strGeneraListaInventario(ByVal objArrayInventario As Array) As String

        Dim strRegistro As String() = Nothing
        Dim intConsecutivo As Integer = 0
        Dim strClass As String = ""
        Dim strHTML As New StringBuilder

        intTotalExistenciasCapturadas = 0
        intTotalRegistrosCapturados = 0

        strHTML.Append("")

        If IsArray(objArrayInventario) AndAlso objArrayInventario.Length > 0 Then

            strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

            strHTML.Append("<tr class='trtitulos'>")
            strHTML.Append("<th width='25'  class='rayita'>&nbsp;</th>")
            strHTML.Append("<th width='25'  class='rayita'>Código</th>")
            strHTML.Append("<th width='120'  class='rayita'>Descripción</th>")
            strHTML.Append("<th width='80' class='rayita' align='right'>Existencia</th>")
            strHTML.Append("<th width='80'  class='rayita' align='right'>Inv. Teórico</th>")
            strHTML.Append("<th width='60'  class='rayita' align='right'>Acciones</th>")
            strHTML.Append("</tr>")

            For Each strRegistro In objArrayInventario
                intConsecutivo += 1

                If ((intConsecutivo Mod 2) = 0) Or (intConsecutivo = 0) Then
                    strClass = "tdceleste"
                Else
                    strClass = "tdblanco"
                End If

                strHTML.Append("<tr>")
                '0 intUniqueId '1 intArticuloId '2 strArticuloDescripcion '3 intInventarioLibreExistenciaReal '4 intArticuloSucursalExistenciaTeorica 

                'Consecutivo
                strHTML.Append("<td class='" & strClass & "'>" & intConsecutivo.ToString & "&nbsp;</td>")

                'intArticuloId
                strHTML.Append("<td class='" & strClass & "'>" & strRegistro(1) & "&nbsp;</td>")

                'strArticuloDescripcion
                strHTML.Append("<td class='" & strClass & "'>" & clsCommons.strFormatearDescripcion(strRegistro(2)).ToString & "&nbsp;</td>")

                'intInventarioLibreExistenciaReal
                strHTML.Append("<td align='right' class='" & strClass & "'>" & strRegistro(3) & "&nbsp;</td>")

                'intArticuloSucursalExistenciaTeorica
                strHTML.Append("<td align='right' class='" & strClass & "'>" & clsCommons.strFormatearDescripcion(strRegistro(4)).ToString & "&nbsp;</td>")

                'Accion Borrar
                strHTML.Append("<td align='right' class='" & strClass & "'><a style=" & strComitasDobles & "text-decoration: none" & strComitasDobles & " href=" & strComitasDobles & "javascript:intEliminaRegistro(" & strRegistro(0) & ")" & strComitasDobles & ">" & "<img src=../static/images/icono_borrar.gif width=11 height=13 border=0 align=absmiddle></a></td>")

                strHTML.Append("</tr>")

                intTotalExistenciasCapturadas += CInt(strRegistro(3))
            Next

            strHTML.Append("</table>")

        End If

        intTotalRegistrosCapturados = intConsecutivo

        Return clsCommons.strGenerateJavascriptString(strHTML.ToString)

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strHTML As StringBuilder = Nothing

        Dim objArray As Array = Nothing
        Dim strRegistro As String() = Nothing
        Dim intResultado As Integer

        Dim strAccion As String = ""
        Dim strResultadoAccion As String = ""
        Dim strListadoInventario As String = ""

        Dim intInventarioId As Long = 0
        Dim intArticuloBuscadoId As Integer = 0
        Dim strArticuloBuscadoDescripcion As String = ""

        intInventarioId = CLng(strInventarioId)


        Select Case strCmd

            Case "BuscarArticulo"

                strHTML = New StringBuilder
                strAccion = "0"  ' BUSCAR ARTICULO
                strResultadoAccion = ""
                strListadoInventario = ""

                ' Obtenemos la información del Articulo

                objArray = clsConcentrador.clsSucursal.strBuscarArticulo(intCompaniaId, intSucursalId, strArticuloCapturado, 1, 1, strCadenaConexion)

                If IsArray(objArray) AndAlso objArray.Length > 0 Then
                    strRegistro = DirectCast(objArray.GetValue(0), String())

                    intArticuloBuscadoId = CInt(strRegistro(0))
                    strArticuloBuscadoDescripcion = clsCommons.strFormatearDescripcion(strRegistro(5))
                    strResultadoAccion = "1"
                Else
                    intArticuloBuscadoId = 0
                    strArticuloBuscadoDescripcion = ""
                    strResultadoAccion = "-100"
                End If

            Case "AgregarArticulo"

                strHTML = New StringBuilder
                strAccion = "1"  ' AGREGAR  ARTICULO
                strResultadoAccion = ""
                strListadoInventario = ""

                If Not IsNumeric(strArticuloCapturado) Then
                    strResultadoAccion = "-120" 'El Código del Artículo no es un número válido.
                ElseIf Not IsNumeric(strExistenciaCapturada) Then
                    strResultadoAccion = "-121" 'El valor de la Existencia no es un número válido.
                Else

                    If intInventarioId = 0 Then
                        'Agregar Folio Inventario
                        intInventarioId = Now.Ticks
                    End If

                    If intInventarioId > 0 Then
                        'Agregar Articulo al  Detalle

                        intResultado = clstblInventarioLibre.intAgregar(intCompaniaId, intSucursalId, CInt(strArticuloCapturado), intInventarioId, CDate("01/01/1900"), CInt(strExistenciaCapturada).ToString, CDate("01/01/1900"), strUsuarioNombre, strCadenaConexion)

                        If intResultado < 1 Then
                            '-122 El Artículo ya se encuentra dato de alta en un Inventario Rotativo para el día de hoy.
                            '-123 El Artículo ya se encuentra dato de alta en otro Inventario Libre  para el día de hoy.
                            strResultadoAccion = intResultado.ToString
                        Else
                            'El articulo se agrego al inventario
                            strResultadoAccion = "1"
                        End If

                    Else
                        strResultadoAccion = "-100" 'Inventario no puede agregarse
                    End If

                End If

            Case "EliminarArticulo"

                strHTML = New StringBuilder
                strAccion = "2"  ' ELIMINAR  ARTICULO
                strResultadoAccion = ""
                strListadoInventario = ""

                ' Eliminar Articulo
                intResultado = clstblInventarioLibre.intEliminar(intllaveArticuloEliminar, strCadenaConexion)
                If intResultado < 1 Then
                    strResultadoAccion = "-100"
                Else
                    strResultadoAccion = "1"
                End If

            Case "RegistrarInventario"

                strHTML = New StringBuilder
                strAccion = "3"  ' Registrar Inventario
                strResultadoAccion = ""
                strListadoInventario = ""

                'Sacar el siguiente consecutivo de folio
                intInventarioFolio = clstblInventarioLibre.intSiguienteConsecutivo(intCompaniaId, intSucursalId, Now, strUsuarioNombre, strCadenaConexion)

                'Asignarle el Folio a todos los registros del Inventario Libre cuyo timestamp sea el actual
                intResultado = clstblInventarioLibre.intActualizarFolio(intInventarioId, intInventarioFolio, Now, strUsuarioNombre, strCadenaConexion)

                If intResultado < 1 Then
                    strResultadoAccion = "-100"
                Else
                    strResultadoAccion = "1"
                End If

        End Select

        'Buscar detalle del Inventario
        If intInventarioId > 0 Then

            If strCmd = "RegistrarInventario" Then
                strListadoInventario = strGeneraImpresionDiferencias(clstblInventarioLibre.strBuscarRegistros(intInventarioId, True, strCadenaConexion))
            Else
                strListadoInventario = strGeneraListaInventario(clstblInventarioLibre.strBuscarRegistros(intInventarioId, False, strCadenaConexion))
            End If


        End If

        If Len(strCmd) > 0 Then

            strHTML.Append("<script language='Javascript'> parent.fnUpAccionInventarios( " & _
                           strComitasDobles & strAccion & strComitasDobles & "," & _
                           strComitasDobles & strListadoInventario & strComitasDobles & "," & _
                           strComitasDobles & intArticuloBuscadoId.ToString & strComitasDobles & "," & _
                           strComitasDobles & strArticuloBuscadoDescripcion & strComitasDobles & "," & _
                           strComitasDobles & intInventarioId.ToString & strComitasDobles & "," & _
                           strComitasDobles & intTotalRegistrosCapturados.ToString & strComitasDobles & "," & _
                           strComitasDobles & intTotalExistenciasCapturadas.ToString & strComitasDobles & "," & _
                           strComitasDobles & intInventarioFolio.ToString & strComitasDobles & "," & _
                           strComitasDobles & strResultadoAccion & strComitasDobles & _
                           "); </script>")

            Response.Write(strHTML.ToString)

            Response.End()

        End If


    End Sub

End Class
