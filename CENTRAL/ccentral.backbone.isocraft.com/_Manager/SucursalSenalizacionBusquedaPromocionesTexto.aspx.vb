
Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Benavides.POSAdmin.Commons.clsCommons.clsMSMQ
Imports Benavides.CC.Data.clsPromociones
Imports System.Text
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports System.IO
Imports System.Web.Caching

Public Class SucursalSenalizacionBusquedaPromocionesTexto
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

    Dim strmRecordBrowserHTML As String

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


    Public ReadOnly Property strFirstDayOfMonth() As String
        Get
            Return New Date(Date.Today.Year, Date.Today.Month, 1).ToString("dd/MM/yyyy")
        End Get
    End Property


    Public ReadOnly Property strLastDayOfMonth() As String
        Get
            Return New Date(Date.Today.Year, Date.Today.AddMonths(1).Month, 1).AddDays(-1).ToString("dd/MM/yyyy")
        End Get
    End Property

    '====================================================================
    ' Name       : intCategoriaPromocionId
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intCategoriaPromocionId() As String
        Get
            If Not IsNothing(Request.Form("cboCategoriaPromocion")) Then
                Return Request.Form("cboCategoriaPromocion")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intPromocionId
    ' Description: Promocion a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intPromocionId() As String
        Get
            If Not IsNothing(Request.Form("txtPromocion")) And IsNumeric(Request.Form("txtPromocion")) Then
                Return Request.Form("txtPromocion")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaInicio
    ' Description: Fecha de inicio a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaInicio() As Date
        Get
            Dim f As String = Request.Form("dtmFechaIni")
            If Not IsNothing(f) Then
                Dim fp As String() = f.Split("/".ToCharArray())

                Return New Date(CInt(fp(2)), CInt(fp(1)), CInt(fp(0)))
            Else
                Return CDate("01/01/1900")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaFin
    ' Description: Fecha de fin  a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaFin() As Date
        Get
            Dim f As String = Request.Form("dtmFechaFin")
            If Not IsNothing(f) Then
                Dim fp As String() = f.Split("/".ToCharArray())

                Return New Date(CInt(fp(2)), CInt(fp(1)), CInt(fp(0)))
            Else
                Return CDate("01/01/1900")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strRecordBrowserHTML() As String
        Get
            Return strmRecordBrowserHTML
        End Get
        Set(ByVal strValue As String)
            strmRecordBrowserHTML = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intPromocionCodigo
    ' Description: Numero identificador de la promocion a mostrar.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intPromocionCodigo() As Integer
        Get
            If Not IsNothing(Request.QueryString("intPromocionCodigo")) And IsNumeric(Request.QueryString("intPromocionCodigo")) Then
                Return CInt(Request.QueryString("intPromocionCodigo"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intPromocionCodigo
    ' Description: Numero identificador de la promocion a mostrar.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strPromocionCodigo() As String
        Get
            If Not IsNothing(Request.QueryString("intPromocionCodigo")) And IsNumeric(Request.QueryString("intPromocionCodigo")) Then
                Return Request.QueryString("intPromocionCodigo")
            Else
                Return String.Empty
            End If
        End Get
    End Property


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Request.QueryString("strCmd") = "cmdImprimir" Then

            Dim intPromocionId As Integer = CInt(Request.QueryString("CodigoId"))
            Dim IdFormato As Integer = CInt(Request.QueryString("IdFormato"))
            Dim strImpresion As New StringBuilder
            Dim strRecordBrowserImpresion As String = String.Empty
            Const strComitasDobles As String = """"

            If intPromocionId > 0 Then

                'Se le da formato a la promocion para imprimirla.
                strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strGetImpresionPromocion(intPromocionId, IdFormato))

                If strRecordBrowserImpresion <> String.Empty Then
                    'Se manda a imprimir la promocion
                    strImpresion.Append("<script language='Javascript'>parent.fnImprimir( " & _
                            strComitasDobles & strRecordBrowserImpresion.ToString & strComitasDobles & _
                            "); </script>")
                Else
                    strImpresion.Append("<script language='Javascript'>alert('La promoción no tiene imagen'); </script>")
                End If
                
            Else
                strImpresion.Append("<script language='Javascript'>alert('La promocion no se puede imprimir'); </script>")
            End If

            Response.Write(strImpresion.ToString)
            Response.End()
        End If
    End Sub

    'Funcion que busca la Promocion por Codigo y muestra su descripcion para realizar una busqueda.
    Public Function strTablaConsultaCodigoPromocion() As String

        strmRecordBrowserHTML = String.Empty

        If (Request.QueryString("strCmd") = "cmdConsultarPorCodigo") Then
            Dim objArray As System.Array = Benavides.CC.Data.clsPromociones.strBuscarPromociones(intPromocionId, strConnectionString)

            If IsArray(objArray) AndAlso objArray.Length > 0 Then
                Dim strResult As New StringBuilder()

                strResult.Append("<script language=""javascript"" type=""text/javascript"">")
                strResult.AppendFormat("parent.document.getElementById('txtPromocionDescripcion').value = '{0}';", CType(objArray.GetValue(0), Array).GetValue(1))
                strResult.Append("</script>")

                Return strResult.ToString()
            End If
        End If

        Return String.Empty
    End Function

    Public Function strTablaConsultaPromociones() As String

        Dim objArray As System.Array = Nothing
        strmRecordBrowserHTML = String.Empty

        If (Request.QueryString("strCmd") = "cmdConsultar") Then
            If (Request.QueryString("pager") = "true") Then
                If Not Cache("cachePromociones") Is Nothing Then
                    objArray = CType(Cache("cachePromociones"), System.Array)
                End If
            End If

            If objArray Is Nothing Then
                Cache.Remove("cachePromociones")
                objArray = Benavides.CC.Data.clsPromociones.strBuscarPromocionAvanzada(CInt(intPromocionId), CInt(intCategoriaPromocionId), dtmFechaInicio, dtmFechaFin, strConnectionString)
            End If

            Dim strResult As New StringBuilder()
            If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then
                Cache.Add("cachePromociones", objArray, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, Nothing)

                strResult.Append(strTablaConsultaPromocionesHTML(objArray))
            End If

            strResult.Append("<script language=""javascript"" type=""text/javascript"">")
            strResult.Append("parent.document.getElementById('tblPromociones').innerHTML = document.getElementById('divConsultaPromociones').innerHTML;")
            strResult.Append("</script>")

            Return strResult.ToString()
        End If

        Return String.Empty
    End Function

    Public Function strTablaConsultaPromocion() As String
        Dim objArray As System.Array = Nothing
        Dim objArrayPromocion As Array
        Dim strRegistroPromocion As String()

        strmRecordBrowserHTML = String.Empty

        objArrayPromocion = Nothing
        If intPromocionCodigo > 0 AndAlso Request.QueryString("strCmd") <> "cmdConsultar" Then  'AndAlso Request.QueryString("strCmd") <> "Imprimir" Then
            If (Request.QueryString("pager") = "true") Then
                If Not Cache("cachePromociones") Is Nothing Then
                    objArray = CType(Cache("cachePromociones"), System.Array)
                End If
            End If

            'dudaaaaaa
            If objArray Is Nothing Then
                Cache.Remove("cachePromociones")
                objArrayPromocion = Benavides.CC.Data.clsPromociones.strBuscarDetallePromocionSenalizacion(intPromocionCodigo, 0, strConnectionString)
            End If

            If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then
                Cache.Add("cachePromociones", objArray, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Normal, Nothing)

                Dim strResult As New StringBuilder()

                strResult.Append(strTablaConsultaPromocionesHTML(objArray))
                strResult.Append("<script language=""javascript"" type=""text/javascript"">")
                strResult.Append("parent.document.getElementById('tblPromociones').innerHTML = document.getElementById('divConsultaPromociones').innerHTML;")
                strResult.Append("</script>")

                Return strResult.ToString()
            End If
        End If

        Return String.Empty
    End Function

    Public Function strTablaConsultaPromocionesHTML(ByVal objConsultaPromociones As Array) As String

        'Variables
        Dim strTablaOfertasHTML As StringBuilder
        Dim strConsultaPromociones As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer

        Dim imgDetalle1x1 As String = Nothing
        Dim imgEditar1x1 As String = Nothing
        Dim imgImprimir1x1 As String = Nothing
        Dim Imagen1x1 As String = Nothing

        Dim imgDetalle1x3 As String = Nothing
        Dim imgEditar1x3 As String = Nothing
        Dim imgImprimir1x3 As String = Nothing
        Dim Imagen1x3 As String = Nothing

        Dim imgDetalle1x4 As String = Nothing
        Dim imgEditar1x4 As String = Nothing
        Dim imgImprimir1x4 As String = Nothing
        Dim Imagen1x4 As String = Nothing

        Dim imgDetalle1x6 As String = Nothing
        Dim imgEditar1x6 As String = Nothing
        Dim imgImprimir1x6 As String = Nothing
        Dim Imagen1x6 As String = Nothing

        Dim intPage As Integer
        Dim intTotal As Integer = 50

        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If


        strTablaOfertasHTML = New StringBuilder
        'strTablaOfertasHTML.Append("<span class='txsubtitulo'> </span> ")
        strTablaOfertasHTML.Append(Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objConsultaPromociones.Length, intPage, intTotal, String.Empty, Nothing))

        strTablaOfertasHTML.Append("<table style='width:100%;' border='0' cellpadding='0' cellspacing='0'>")
        strTablaOfertasHTML.Append("<tr class='trtitulos'>")
        strTablaOfertasHTML.Append("<th width='08%' align=center class='rayita' align='left' valign='top'>Código</th>")
        strTablaOfertasHTML.Append("<th width='20%' align=center class='rayita' align='left' valign='top'>Descripción</th>")
        strTablaOfertasHTML.Append("<th width='08%' align=center class='rayita' align='left' valign='top'>Fecha<br>Inicio</th>")
        strTablaOfertasHTML.Append("<th width='08%' align=center class='rayita' align='left' valign='top'>Fecha<br>Final</th>")
        strTablaOfertasHTML.Append("<th width='14%' align=center class='rayita' align='left' valign='top'>Formato 1x1</th>")
        strTablaOfertasHTML.Append("<th width='14%' align=center class='rayita' align='left' valign='top'>Formato 1x3</th>")
        strTablaOfertasHTML.Append("<th width='14%' align=center class='rayita' align='left' valign='top'>Formato 1x4</th>")
        strTablaOfertasHTML.Append("<th width='14%' align=center class='rayita' align='left' valign='top'>Formato 1x6</th>")
        strTablaOfertasHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaPromociones.Length) Then
                Exit For
            End If

            strConsultaPromociones = CType(objConsultaPromociones.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            'Imagenes de la accion Formato 1x1
            imgDetalle1x1 = "<img id=Ver" & strConsultaPromociones(0) & " height='17' src='../static/images/icono_lupa.gif'  align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerificarAccion_onclick(this.id, 1)' alt='Ver Detalle'>"
            imgEditar1x1 = "<img id=Edi" & strConsultaPromociones(0) & " height='17' src='../static/images/icono_editar.gif'  align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerificarAccion_onclick(this.id, 1)' alt='Editar'>"
            imgImprimir1x1 = "<img id=Imp" & strConsultaPromociones(0) & " height='17' src='../static/images/icono_imprimir.gif'  align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerificarAccion_onclick(this.id, 1)' alt='Imprimir'>"
            Imagen1x1 = fnValidaImagen(strConsultaPromociones(0), strConsultaPromociones(4), 1)


            'Imagenes de la accion Formato 1x3
            imgDetalle1x3 = "<img id=Ver" & strConsultaPromociones(0) & " height='17' src='../static/images/icono_lupa.gif'  align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerificarAccion_onclick(this.id, 2)' alt='Ver Detalle'>"
            imgEditar1x3 = "<img id=Edi" & strConsultaPromociones(0) & " height='17' src='../static/images/icono_editar.gif'  align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerificarAccion_onclick(this.id, 2)' alt='Editar'>"
            imgImprimir1x3 = "<img id=Imp" & strConsultaPromociones(0) & " height='17' src='../static/images/icono_imprimir.gif'  align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerificarAccion_onclick(this.id, 2)' alt='Imprimir'>"
            Imagen1x3 = fnValidaImagen(strConsultaPromociones(0), strConsultaPromociones(5), 2)

            'Imagenes de la accion Formato 1x4
            imgDetalle1x4 = "<img id=Ver" & strConsultaPromociones(0) & " height='17' src='../static/images/icono_lupa.gif' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerificarAccion_onclick(this.id, 3)' alt='Ver Detalle'>"
            imgEditar1x4 = "<img id=Edi" & strConsultaPromociones(0) & " height='17' src='../static/images/icono_editar.gif' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerificarAccion_onclick(this.id, 3)' alt='Editar'>"
            imgImprimir1x4 = "<img id=Imp" & strConsultaPromociones(0) & " height='17' src='../static/images/icono_imprimir.gif'  align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerificarAccion_onclick(this.id, 3)' alt='Imprimir'>"
            Imagen1x4 = fnValidaImagen(strConsultaPromociones(0), strConsultaPromociones(6), 3)

            'Imagenes de la accion Formato 1x6
            imgDetalle1x6 = "<img id=Ver" & strConsultaPromociones(0) & " height='17' src='../static/images/icono_lupa.gif' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerificarAccion_onclick(this.id, 4)' alt='Ver Detalle'>"
            imgEditar1x6 = "<img id=Edi" & strConsultaPromociones(0) & " height='17' src='../static/images/icono_editar.gif' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerificarAccion_onclick(this.id, 4)' alt='Editar'>"
            imgImprimir1x6 = "<img id=Imp" & strConsultaPromociones(0) & " height='17' src='../static/images/icono_imprimir.gif'  align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerificarAccion_onclick(this.id, 4)' alt='Imprimir'>"
            Imagen1x6 = fnValidaImagen(strConsultaPromociones(0), strConsultaPromociones(7), 4)


            ''Validacion Imagen1x1
            'If Trim(strConsultaPromociones(4)) = Nothing Then
            '    Imagen1x1 = "<img height='17' src='../static/images/imgNRCancelar.gif' align='absMiddle' border='0' alt='(Sin Imagen)'>"
            'Else

            '    Imagen1x1 = "<img height='17' src='../static/images/imgNRTrasmitido.gif' align='absMiddle' border='0' alt='Con Imagen'>"
            'End If

            ''Validacion Imagen1x3
            'If Trim(strConsultaPromociones(5)) = Nothing Then
            '    Imagen1x3 = "<img height='17' src='../static/images/imgNRCancelar.gif' align='absMiddle' border='0' alt='(Sin Imagen)'>"
            'Else
            '    Imagen1x3 = "<img height='17' src='../static/images/imgNRTrasmitido.gif' align='absMiddle' border='0' alt='Con Imagen'>"
            'End If

            ''Validacion Imagen1x4
            'If Trim(strConsultaPromociones(6)) = Nothing Then
            '    Imagen1x4 = "<img height='17' src='../static/images/imgNRCancelar.gif' align='absMiddle' border='0' alt='(Sin Imagen)'>"
            'Else
            '    Imagen1x4 = "<img height='17' src='../static/images/imgNRTrasmitido.gif' align='absMiddle' border='0' alt='Con Imagen'>"
            'End If

            ''Validacion Imagen1x6
            'If Trim(strConsultaPromociones(7)) = Nothing Then
            '    Imagen1x6 = "<img height='17' src='../static/images/imgNRCancelar.gif' align='absMiddle' border='0' alt='(Sin Imagen)'>"
            'Else
            '    Imagen1x6 = "<img height='17' src='../static/images/imgNRTrasmitido.gif' align='absMiddle' border='0' alt='(Con Imagen)'>"
            'End If


            ''Validacion Imagen1x1
            'If Trim(strConsultaPromociones(4)) = Nothing Then
            '    Imagen1x1 = "(Sin Formato)"
            'Else
            '    Imagen1x1 = "<a href=""javascript:cmdVerificarAccion_onclick('Ver" & strConsultaPromociones(0) & "', 1)"">" & strConsultaPromociones(4) & "</a>"
            'End If

            ''Validacion Imagen1x3
            'If Trim(strConsultaPromociones(5)) = Nothing Then
            '    Imagen1x3 = "(Sin Formato)"
            'Else
            '    Imagen1x3 = "<a href=""javascript:cmdVerificarAccion_onclick('Ver" & strConsultaPromociones(0) & "', 2)"">" & strConsultaPromociones(5) & "</a>"
            'End If

            ''Validacion Imagen1x4
            'If Trim(strConsultaPromociones(6)) = Nothing Then
            '    Imagen1x4 = "(Sin Formato)"
            'Else
            '    Imagen1x4 = "<a href=""javascript:cmdVerificarAccion_onclick('Ver" & strConsultaPromociones(0) & "', 1)"">" & strConsultaPromociones(6) & "</a>"
            'End If

            ''Validacion Imagen1x6
            'If Trim(strConsultaPromociones(7)) = Nothing Then
            '    Imagen1x6 = "(Sin Formato)"
            'Else
            '    Imagen1x6 = "<a href=""javascript:cmdVerificarAccion_onclick('Ver" & strConsultaPromociones(0) & "', 2)"">" & strConsultaPromociones(7) & "</a>"
            'End If

            strTablaOfertasHTML.Append("<tr>")

            ' intPromocionId
            strTablaOfertasHTML.Append("<td width='08%' id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & strConsultaPromociones(0) & "</td>")
            ' strPromocionDescripcion
            strTablaOfertasHTML.Append("<td width='20%' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaPromociones(1)) & "</td>")
            ' dtmPromocionVigenciaInicio
            strTablaOfertasHTML.Append("<td width='08%' class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaPromociones(2)) & "</td>")
            ' dtmPromocionVigenciaFin
            strTablaOfertasHTML.Append("<td width='08%' class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaPromociones(3)) & "</td>")
            ' strFormato 1x1
            strTablaOfertasHTML.Append("<td width='14%' align=right class=" & strColorRegistro & ">" & Imagen1x1 & imgDetalle1x1 & imgImprimir1x1 & imgEditar1x1 & "</td>")
            ' strFormato 1x3
            strTablaOfertasHTML.Append("<td width='14%' align=right class=" & strColorRegistro & ">" & Imagen1x3 & imgDetalle1x3 & imgImprimir1x3 & imgEditar1x3 & "</td>")
            ' strFormato 1x4
            strTablaOfertasHTML.Append("<td width='14%' align=right class=" & strColorRegistro & ">" & Imagen1x4 & imgDetalle1x4 & imgImprimir1x4 & imgEditar1x4 & "</td>")
            ' strFormato 1x6
            strTablaOfertasHTML.Append("<td width='14%' align=center class=" & strColorRegistro & ">" & Imagen1x6 & imgDetalle1x6 & imgImprimir1x6 & imgEditar1x6 & "</td>")
            strTablaOfertasHTML.Append("</tr>")

        Next
        strTablaOfertasHTML.Append("</tr>")
        strTablaOfertasHTML.Append("</table>")
        strTablaOfertasHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaPromocionesHTML = strTablaOfertasHTML.ToString 'clsCommons.strGenerateJavascriptString(strTablaOfertasHTML.ToString)
    End Function

    'Valida la imagen de acuerdo al formato y forma la liga ver el detalle o se regresa una etiqueta sin liga.
    Function fnValidaImagen(strPromocionId As String, strImagenNombre As String, intFormatoId As Integer) As String

        Dim strImagenLiga As String
        strImagenLiga = String.Empty

        If Trim(strImagenNombre) = Nothing Or Trim(strImagenNombre) = String.Empty Then
            strImagenLiga = "<img height='17' src='../static/images/imgNRCancelar.gif' align='absMiddle' border='0' alt='(Sin Imagen)'>"
            'ElseIf intFormatoId = "1" Then
        Else
            'Validacion Imagen1x1
            strImagenLiga = "<a href=""javascript:cmdVerificarAccion_onclick('Ver" & strPromocionId & "', 1)"">" & strImagenNombre & "</a>"
            strImagenLiga = "<img height='17' src='../static/images/imgNRTrasmitido.gif' align='absMiddle' border='0' alt='" & strImagenNombre & "'>"

            'ElseIf intFormatoId = "2" Then

            '    'Validacion Imagen1x3
            '    strImagenLiga = "<a href=""javascript:cmdVerificarAccion_onclick('Ver" & strPromocionId & "', 2)"">" & strImagenNombre & "</a>"

            'ElseIf intFormatoId = "3" Then

            '    'Validacion Imagen1x4
            '    strImagenLiga = "<a href=""javascript:cmdVerificarAccion_onclick('Ver" & strPromocionId & "', 3)"">" & strImagenNombre & "</a>"

            'ElseIf intFormatoId = "4" Then

            '    'Validacion Imagen1x6
            '    strImagenLiga = "<a href=""javascript:cmdVerificarAccion_onclick('Ver" & strPromocionId & "', 4)"">" & strImagenNombre & "</a>"

        End If

        Return strImagenLiga
    End Function

    Private Function strGetImpresionPromocion(ByVal intPromocionId As Integer, ByVal IdFormato As Integer, Optional ByVal blnSaltoPagina As Boolean = False) As String

        ' Declaracion de Variables
        Dim objArrayPromociones As Array
        Dim strRegistroPromocion As String()
        Dim intConsecutivo As Integer

        objArrayPromociones = Nothing

        'Obtenemos el detalle de la promocion
        objArrayPromociones = Benavides.CC.Data.clsPromociones.strBuscarDetallePromocionSenalizacion(intPromocionId, IdFormato, System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral"))

        Dim imgPath As String = System.Configuration.ConfigurationSettings.AppSettings("strImagenesPromociones")
        If IsArray(objArrayPromociones) AndAlso objArrayPromociones.Length > 0 Then
            intConsecutivo += 1
            For Each strRegistroPromocion In objArrayPromociones

                If strRegistroPromocion(5).Trim = String.Empty Then
                    Return String.Empty
                Else
                    Return strCreate1x1Table(String.Format("{0}?id={1}&IdFormato={2}", imgPath, intPromocionId, IdFormato), blnSaltoPagina)
                End If

            Next
        End If

        Return String.Empty
    End Function

    Private Function strCreate1x1Table(ByVal strImage As String, ByVal blnSaltoPagina As Boolean) As String
        Dim strTabla As New StringBuilder

        If blnSaltoPagina Then
            strTabla.Append("<table style=""page-break-before:always;"">")
        Else
            strTabla.Append("<table>")
        End If
        strTabla.Append("<tr>")
        strTabla.Append("<td>")
        strTabla.AppendFormat("<img src=""{0}"" style=""border:none; width:8.4in; height:10.9in;"">", strImage)
        strTabla.Append("</td>")
        strTabla.Append("</tr>")
        strTabla.Append("</table>")

        Return strTabla.ToString()
    End Function

    Private Function strCreate1x3Table(ByVal strImage As String, ByVal blnSaltoPagina As Boolean) As String
        Dim strTabla As New StringBuilder

        If blnSaltoPagina Then
            strTabla.Append("<table style=""page-break-before:always;"">")
        Else
            strTabla.Append("<table>")
        End If
        strTabla.Append("<tr>")
        strTabla.Append("<td>")
        strTabla.AppendFormat("<img src=""{0}"" style=""border:none; width:8.5in; height:3.6in;"">", strImage)
        strTabla.Append("</td>")
        strTabla.Append("</tr>")
        strTabla.Append("<tr>")
        strTabla.Append("<td>")
        strTabla.AppendFormat("<img src=""{0}"" style=""border:none; width:8.5in; height:3.6in;"">", strImage)
        strTabla.Append("</td>")
        strTabla.Append("</tr>")
        strTabla.Append("<tr>")
        strTabla.Append("<td>")
        strTabla.AppendFormat("<img src=""{0}"" style=""border:none; width:8.5in; height:3.6in;"">", strImage)
        strTabla.Append("</td>")
        strTabla.Append("</tr>")
        strTabla.Append("</table>")

        Return strTabla.ToString()
    End Function

End Class
