Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Benavides.POSAdmin.Commons.clsCommons.clsMSMQ
Imports Benavides.CC.Data.clsPromociones
Imports System.Text
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports System.IO
Imports System.Web.Caching
Imports Benavides.CC.Business
Imports System.Configuration
Imports Isocraft.Web.Javascript

Public Class RentaEspaciosReportes
    Inherits System.Web.UI.Page

    Private strmRutaImagen As String = String.Empty

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
    ' Name       : rutaImagenes
    ' Description: Codigo del articulo
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected ReadOnly Property rutaImagenes() As String
        Get
            'Return ConfigurationManager.AppSettings("strImagenesExhibiciones")
            Return System.Configuration.ConfigurationSettings.AppSettings("strImagenesExhibiciones")
        End Get
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Not IsNothing(Request.QueryString("strCmd")) Then
                Return Request.QueryString("strCmd")
            Else
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strDivisionArticulosId
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strDivisionArticulosId() As String
        Get
            If Not IsNothing(Request.QueryString("strDivisionArticulosId")) Then
                Return Request.QueryString("strDivisionArticulosId")
            Else
                Return "0"
            End If
        End Get
    End Property
    
    '====================================================================
    ' Name       : strCategoriaOperativaId
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCategoriaOperativaId() As String
        Get
            If Not IsNothing(Request.QueryString("strCategoriaOperativaId")) Then
                Return Request.QueryString("strCategoriaOperativaId")
            Else
                Return "0"
            End If
        End Get
    End Property
    
    '====================================================================
    ' Name       : strCatmanId
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCatmanId() As String
        Get
            If Not IsNothing(Request.QueryString("strCatmanId")) Then
                Return Request.QueryString("strCatmanId")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strProveedorId
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strProveedorId() As String
        Get
            If Not IsNothing(Request.QueryString("strProveedorId")) Then
                Return Request.QueryString("strProveedorId")
            Else
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strSocioComercial
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSocioComercial() As String
        Get
            If Not IsNothing(Request.QueryString("strSocioComercial")) Then
                Return Request.QueryString("strSocioComercial")
            Else
                Return String.Empty
            End If
        End Get
    End Property
    
    '====================================================================
    ' Name       : strTipoExhibicionId
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTipoExhibicionId() As String
        Get
            If Not IsNothing(Request.QueryString("strTipoExhibicionId")) Then
                Return Request.QueryString("strTipoExhibicionId")
            Else
                Return "0"
            End If
        End Get
    End Property
    
    '====================================================================
    ' Name       : strTipoRentaId
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTipoRentaId() As String
        Get
            If Not IsNothing(Request.QueryString("strTipoRentaId")) Then
                Return Request.QueryString("strTipoRentaId")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strTipoEspacioPublicitarioId
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTipoEspacioPublicitarioId() As String
        Get
            If Not IsNothing(Request.QueryString("strTipoEspacioPublicitarioId")) Then
                Return Request.QueryString("strTipoEspacioPublicitarioId")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strPlanogramaCapturadoId
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strPlanogramaCapturadoId() As String
        Get
            If Not IsNothing(Request.QueryString("strPlanogramaCapturadoId")) And Not (Trim(Request.QueryString("strPlanogramaCapturadoId")) = String.Empty) Then
                Return Request.QueryString("strPlanogramaCapturadoId")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strNombreExhibicion
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strNombreExhibicion() As String
        Get
            If Not IsNothing(Request.QueryString("strNombreExhibicion")) Then
                Return Request.QueryString("strNombreExhibicion")
            Else
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strPlanSalidaId
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strPlanSalidaId() As String
        Get
            If Not IsNothing(Request.QueryString("strPlanSalidaId")) Then
                Return Request.QueryString("strPlanSalidaId")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strTipoPlanogramaId
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTipoPlanogramaId() As String
        Get
            If Not IsNothing(Request.QueryString("strTipoPlanogramaId")) Then
                Return Request.QueryString("strTipoPlanogramaId")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strEstatusId
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strEstatusId() As String
        Get
            If Not IsNothing(Request.QueryString("strEstatusId")) Then
                Return Request.QueryString("strEstatusId")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaInicio
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaInicio() As Date
        Get
            Dim f As String = Request.QueryString("dtmFechaInicio")
            If Not IsNothing(f) Then
                Dim fp As String() = f.Split("/".ToCharArray())

                Return New Date(CInt(fp(2)), CInt(fp(1)), CInt(fp(0)))
            ElseIf Not IsNothing(Request.Form("hdnFechaInicio")) Then
                Return CDate(Request.Form("hdnFechaInicio"))
            Else
                Return CDate("01/01/1900")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : dtmFechaFin
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property dtmFechaFin() As Date
        Get
            Dim f As String = Request.QueryString("dtmFechaFin")
            If Not IsNothing(f) Then
                Dim fp As String() = f.Split("/".ToCharArray())

                Return New Date(CInt(fp(2)), CInt(fp(1)), CInt(fp(0)))
            ElseIf Not IsNothing(Request.Form("hdnFechaFin")) Then
                Return CDate(Request.Form("hdnFechaFin"))
            Else
                Return CDate("01/01/1900")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strNombreExhibicion
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    'Public ReadOnly Property strNombreExhibicion() As String
    '    Get
    '        If Not IsNothing(Request.Form("txtNombreExhibicion")) Then
    '            Return Request.Form("txtNombreExhibicion")
    '        Else
    '            Return String.Empty
    '        End If
    '    End Get
    'End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load 'Me.Load

        Const strComitasDobles As String = """"

        'Reporte Exhibiciones Adicionales
        If Request.QueryString("strCmdImprimir") = "cmdReporteExhibicionesAdicionales" Then


            Dim strHTMLReporte As New StringBuilder
            Dim objDataArrayReporte As Array = Nothing
            Dim strRecordBrowserReporte As String = String.Empty


            'Resultados a mostrar en pantalla para Resumen
            objDataArrayReporte = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarReporteExhibicionesAdicionales(CInt(strDivisionArticulosId), CInt(strCategoriaOperativaId), _
                                                                                                                       CInt(strCatmanId), strSocioComercial, strProveedorId, _
                                                                                                                       CInt(strTipoRentaId), CInt(strTipoExhibicionId), _
                                                                                                                       CInt(strTipoEspacioPublicitarioId), strNombreExhibicion, _
                                                                                                                       CInt(strPlanSalidaId), CInt(strTipoPlanogramaId), _
                                                                                                                       CInt(strPlanogramaCapturadoId), CInt(strEstatusId), _
                                                                                                                       dtmFechaInicio, dtmFechaFin, strConnectionString)

            If IsArray(objDataArrayReporte) AndAlso objDataArrayReporte.Length > 0 Then

                'Se envia la informacion a imprimir para darle formato de acuerdo a la tabla seleccionada por el usuario.  
                strRecordBrowserReporte = clsCommons.strGenerateJavascriptString(strReporteExhibiciones(objDataArrayReporte))

                'Se ennvia a impresion.
                strHTMLReporte.Append("<script language='Javascript'>parent.fnImprimir( " & _
                strComitasDobles & strRecordBrowserReporte.ToString & strComitasDobles & _
                "); </script>")
                Response.Write(strHTMLReporte.ToString)
                Response.End()

            End If
        End If

        'Reporte Asignaciones
        If Request.QueryString("strCmdImprimir") = "cmdReporteAsignaciones" Then

            Dim strHTMLReporteAsignaciones As New StringBuilder
            Dim objDataArrayReporteAsignaciones As Array = Nothing
            Dim strRecordBrowserReporteAsignaciones As String = ""

            'Resultados a mostrar en pantalla para Resumen
            objDataArrayReporteAsignaciones = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarReporteAsignaciones(CInt(strDivisionArticulosId), CInt(strCategoriaOperativaId), _
                                                                                                                       CInt(strCatmanId), strSocioComercial, strProveedorId, _
                                                                                                                       CInt(strTipoRentaId), CInt(strTipoExhibicionId), _
                                                                                                                       CInt(strTipoEspacioPublicitarioId), strNombreExhibicion, _
                                                                                                                       CInt(strPlanSalidaId), CInt(strTipoPlanogramaId), _
                                                                                                                       CInt(strPlanogramaCapturadoId), CInt(strEstatusId), _
                                                                                                                       dtmFechaInicio, dtmFechaFin, strConnectionString)

            If IsArray(objDataArrayReporteAsignaciones) AndAlso objDataArrayReporteAsignaciones.Length > 0 Then

                'Se envia la informacion a imprimir para darle formato de acuerdo a la tabla seleccionada por el usuario.  
                strRecordBrowserReporteAsignaciones = clsCommons.strGenerateJavascriptString(strImpresionAsignaciones(objDataArrayReporteAsignaciones))

                'Se ennvia a impresion.
                strHTMLReporteAsignaciones.Append("<script language='Javascript'>parent.fnImprimir( " & _
                strComitasDobles & strRecordBrowserReporteAsignaciones.ToString & strComitasDobles & _
                "); </script>")
                Response.Write(strHTMLReporteAsignaciones.ToString)
                Response.End()

            End If
        End If

        'Exportar
        If Request.QueryString("strCmdExportar") = "cmdReporteExhibicionesAdicionales" Then

            Dim objArrayAdicionales As System.Array = Nothing
            objArrayAdicionales = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarReporteExhibicionesAdicionales(CInt(strDivisionArticulosId), CInt(strCategoriaOperativaId), _
                                                                                                                       CInt(strCatmanId), strSocioComercial, strProveedorId, _
                                                                                                                       CInt(strTipoRentaId), CInt(strTipoExhibicionId), _
                                                                                                                       CInt(strTipoEspacioPublicitarioId), strNombreExhibicion, _
                                                                                                                       CInt(strPlanSalidaId), CInt(strTipoPlanogramaId), _
                                                                                                                       CInt(strPlanogramaCapturadoId), CInt(strEstatusId), _
                                                                                                                       dtmFechaInicio, dtmFechaFin, strConnectionString)


            ' Establecemos en la respuesta los parámetros de configuración del archivo
            Response.ContentType = "application/vnd.ms-excel"
            Call Response.AddHeader("Content-Disposition", "attachment; filename=""Reporte Exhibiciones Adicionales.xls""")
            Call Response.Write(strTablaExhibicionesAdicionalesExportar(objArrayAdicionales))
            Call Response.End()
        End If

        'Reporte Asignaciones
        If Request.QueryString("strCmdExportar") = "cmdReporteAsignaciones" Then

            Dim objArrayAsignaciones As Array = Nothing

            '    'Resultados a mostrar en pantalla para Resumen
            objArrayAsignaciones = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarReporteAsignaciones(CInt(strDivisionArticulosId), CInt(strCategoriaOperativaId), _
                                                                                                                       CInt(strCatmanId), strSocioComercial, strProveedorId, _
                                                                                                                       CInt(strTipoRentaId), CInt(strTipoExhibicionId), _
                                                                                                                       CInt(strTipoEspacioPublicitarioId), strNombreExhibicion, _
                                                                                                                       CInt(strPlanSalidaId), CInt(strTipoPlanogramaId), _
                                                                                                                       CInt(strPlanogramaCapturadoId), CInt(strEstatusId), _
                                                                                                                       dtmFechaInicio, dtmFechaFin, strConnectionString)

            ' Establecemos en la respuesta los parámetros de configuración del archivo
            Response.ContentType = "application/vnd.ms-excel"
            Call Response.AddHeader("Content-Disposition", "attachment; filename=""Reporte Exhibiciones Adicionales-Asignaciones.xls""")
            Call Response.Write(strTablExhibicionesAsignadasExportar(objArrayAsignaciones))
            Call Response.End()
            'End If
        End If

    End Sub

    Public Function strTablaConsultaReporte() As String

        'Reporte Exhibiciones AdicionalesstrBuscarReporteAsignaciones
        If strCmd = "cmdReporteExhibicionesAdicionales" Then

            Dim strHTMLReporte As New StringBuilder
            Dim objDataArrayReporte As Array = Nothing

            If (Request.QueryString("pager") = "true") Then
                If Not Cache("cacheExhibicionesAdicionales") Is Nothing Then
                    objDataArrayReporte = CType(Cache("cacheExhibicionesAdicionales"), System.Array)
                End If
            End If

            If objDataArrayReporte Is Nothing Then
                Cache.Remove("cacheExhibicionesAdicionales")
                'Resultados a mostrar en pantalla para Resumen
                objDataArrayReporte = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarReporteExhibicionesAdicionales(CInt(strDivisionArticulosId), CInt(strCategoriaOperativaId), _
                                                                                                                       CInt(strCatmanId), strSocioComercial, strProveedorId, _
                                                                                                                       CInt(strTipoRentaId), CInt(strTipoExhibicionId), _
                                                                                                                       CInt(strTipoEspacioPublicitarioId), strNombreExhibicion, _
                                                                                                                       CInt(strPlanSalidaId), CInt(strTipoPlanogramaId), _
                                                                                                                       CInt(strPlanogramaCapturadoId), CInt(strEstatusId), _
                                                                                                                       dtmFechaInicio, dtmFechaFin, strConnectionString)
            End If

            If Not objDataArrayReporte Is Nothing AndAlso IsArray(objDataArrayReporte) AndAlso objDataArrayReporte.Length > 0 Then
                Cache.Add("cacheExhibicionesAdicionales", objDataArrayReporte, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, Nothing)

                'Se envia la informacion a mostrar para darle formato de acuerdo a la tabla seleccionada por el usuario.  
                strHTMLReporte.Append(strTablaConsultaExhibicionesAdicionalesHTML(objDataArrayReporte))
            Else
                strHTMLReporte.Append(String.Empty)

            End If

            strHTMLReporte.Append("<script language=""javascript"" type=""text/javascript"">")
            strHTMLReporte.Append("parent.document.getElementById('tblResultados').innerHTML = document.getElementById('divConsultaReporte').innerHTML;")
            strHTMLReporte.Append("</script>")

            Return strHTMLReporte.ToString()
        End If

        'Reporte Asignaciones
        If strCmd = "cmdReporteAsignaciones" Then

            Dim strHTMLReporteAsignaciones As New StringBuilder
            Dim objDataArrayReporteAsignaciones As Array = Nothing
            Dim strRecordBrowserReporteAsignaciones As String = ""

            If (Request.QueryString("pager") = "true") Then
                If Not Cache("cacheExhibiciones") Is Nothing Then
                    objDataArrayReporteAsignaciones = CType(Cache("cacheExhibiciones"), System.Array)
                End If
            End If

            If objDataArrayReporteAsignaciones Is Nothing Then
                Cache.Remove("cacheExhibiciones")

                'Resultados a mostrar en pantalla para Resumen
                objDataArrayReporteAsignaciones = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarReporteAsignaciones(CInt(strDivisionArticulosId), CInt(strCategoriaOperativaId), _
                                                                                                                       CInt(strCatmanId), strSocioComercial, strProveedorId, _
                                                                                                                       CInt(strTipoRentaId), CInt(strTipoExhibicionId), _
                                                                                                                       CInt(strTipoEspacioPublicitarioId), strNombreExhibicion, _
                                                                                                                       CInt(strPlanSalidaId), CInt(strTipoPlanogramaId), _
                                                                                                                       CInt(strPlanogramaCapturadoId), CInt(strEstatusId), _
                                                                                                                       dtmFechaInicio, dtmFechaFin, strConnectionString)
            End If


            If Not objDataArrayReporteAsignaciones Is Nothing AndAlso IsArray(objDataArrayReporteAsignaciones) AndAlso objDataArrayReporteAsignaciones.Length > 0 Then
                Cache.Add("cacheExhibiciones", objDataArrayReporteAsignaciones, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, Nothing)

                'Se envia la informacion a mostrar para darle formato de acuerdo a la tabla seleccionada por el usuario.  
                strHTMLReporteAsignaciones.Append(strTablaConsultaExhibicionesAsignadasHTML(objDataArrayReporteAsignaciones))
            Else

                strHTMLReporteAsignaciones.Append(String.Empty)
            End If

            strHTMLReporteAsignaciones.Append("<script language=""javascript"" type=""text/javascript"">")
            strHTMLReporteAsignaciones.Append("parent.document.getElementById('tblResultados').innerHTML = document.getElementById('divConsultaReporte').innerHTML;")
            strHTMLReporteAsignaciones.Append("</script>")

            Return strHTMLReporteAsignaciones.ToString()
        End If

        Return String.Empty
    End Function

#Region "Reportes en pantalla"
    Public Function strTablaConsultaExhibicionesAdicionalesHTML(ByVal objConsultaExhibiciones As Array) As String
        Dim strTablaEspaciosHTML As StringBuilder
        Dim strConsultaExhibiciones As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer

        Dim Imagen As String = Nothing

        Dim intPage As Integer
        Dim intTotal As Integer = 1
        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If


        strTablaEspaciosHTML = New StringBuilder
        strTablaEspaciosHTML.Append("<span class='txsubtitulo'>Exhibiciones Adicionales </span> ")
        strTablaEspaciosHTML.Append(Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objConsultaExhibiciones.Length, intPage, intTotal, String.Empty, Nothing))

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaExhibiciones.Length) Then
                Exit For
            End If

            strConsultaExhibiciones = CType(objConsultaExhibiciones.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strTablaEspaciosHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

            'Encabezado titulos
            strTablaEspaciosHTML.Append("<tr class='trtitulos'>")
            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>Nombre de la Exhibición</th>")
            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>División</th>")
            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>Categoría</th>")
            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>Proveedor</th>")
            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>Socio Comercial</th>")
            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>Catman</th>")
            strTablaEspaciosHTML.Append("</tr>")

            'Valores
            strTablaEspaciosHTML.Append("<tr>")
            ' Nombre de la Exhibición
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco' >" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(1)) & "</td>")
            ' División
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco'>" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(2)) & "</td>")
            ' Categoría
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco' >" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(3)) & "</td>")
            ' Proveedor
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco'>" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(4)) & "</td>")
            ' Socio Comercial
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco' >" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(5)) & "</td>")
            ' Catman
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco' >" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(6)) & "</td>")
            strTablaEspaciosHTML.Append("</tr>")

            strmRutaImagen = Trim(strConsultaExhibiciones(22))

            If Not strmRutaImagen = String.Empty Then
                strmRutaImagen = String.Format("{0}?id={1}", rutaImagenes, strmRutaImagen)
            End If

            strTablaEspaciosHTML.Append("<tr class='trtitulos'>")
            'Foto Imagen...
            strTablaEspaciosHTML.Append("<td colspan='1' rowspan='9' width='16.6%' align='left'>")
            strTablaEspaciosHTML.AppendFormat("<img src=""{0}"" style=""border:none; width:1.3in; height:1.5in;"">", strmRutaImagen)
            strTablaEspaciosHTML.Append("</td>")

            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>Tipo Renta</th>")
            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>Tipo de Exhibición</th>")
            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>Espacio Publicitario</th>")
            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>Plan de salida</th>")
            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>Comentarios</th>")
            strTablaEspaciosHTML.Append("</tr>")

            'Tipo de Exhibición
            If strConsultaExhibiciones(8).Trim() = String.Empty Then
                strConsultaExhibiciones(8) = "&nbsp;"
            End If

            'Espacio Publicitario
            If strConsultaExhibiciones(9).Trim() = String.Empty Then
                strConsultaExhibiciones(9) = "&nbsp;"
            End If

            'Valores
            strTablaEspaciosHTML.Append("<tr>")
            ' Tipo Renta
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco' >" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(7)).ToString & "</td>")
            ' Tipo de Exhibición
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco' >" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(8)).ToString & "</td>")
            ' Espacio Publicitario
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco' >" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(9)) & "</td>")
            ' Plan de Salida
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco' >" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(10)) & "</td>")
            ' Comentarios
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco' >" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(11)) & "</td>")
            strTablaEspaciosHTML.Append("</tr>")

            strTablaEspaciosHTML.Append("<tr class='trtitulos'>")

            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>Tipo de Plano</th>")
            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>Planograma</th>")
            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>Costo Merchandising</th>")
            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>Costo Catman</th>")
            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>Ingreso Total Merch</th>")

            strTablaEspaciosHTML.Append("</tr>")

            'Valores
            strTablaEspaciosHTML.Append("<tr>")
            'Tipo de Plano
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco' >" & strConsultaExhibiciones(12) & "</td>")
            'Planograma
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco' >" & strConsultaExhibiciones(13) & "</td>")
            'Costo Merchandising
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco' >" & "$" & CDec(strConsultaExhibiciones(14)).ToString() & "</td>")
            'Costo Catman
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco' >" & "$" & CDec(strConsultaExhibiciones(15)).ToString() & "</td>")
            'Ingreso Total Merch
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco' >" & "$" & CDec(strConsultaExhibiciones(16)).ToString() & "</td>")
            strTablaEspaciosHTML.Append("</tr>")

            strTablaEspaciosHTML.Append("<tr class='trtitulos'>")
            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>Ingreso Total Catman</th>")
            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>Ingreso Total</th>")
            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>Fecha Inicio</th>")
            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>Fecha Fin</th>")
            strTablaEspaciosHTML.Append("<th width='16.6%' class='rayita' align='center' nowrap>Estatus</th>")
            strTablaEspaciosHTML.Append("</tr>")

            'Valores
            strTablaEspaciosHTML.Append("<tr>")
            'Ingreso Total Catman
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco' >" & "$" & CDec(strConsultaExhibiciones(17)).ToString() & "</td>")
            'Ingreso Total
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco' >" & "$" & CDec(strConsultaExhibiciones(18)).ToString() & "</td>")
            'Fecha Inicio
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco' >" & clsCommons.strFormatearFechaPresentacion(strConsultaExhibiciones(19)) & "</td>")
            'Fecha Fin
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco' >" & clsCommons.strFormatearFechaPresentacion(strConsultaExhibiciones(20)) & "</td>")
            'Estatus
            strTablaEspaciosHTML.Append("<td width='16.6%' align='center' class='tdblanco' >" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(21)) & "</td>")
            strTablaEspaciosHTML.Append("</tr>")

            strTablaEspaciosHTML.Append("</table>")
            strTablaEspaciosHTML.Append("<br />")

        Next
        strTablaEspaciosHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaExhibicionesAdicionalesHTML = strTablaEspaciosHTML.ToString
    End Function

    Public Function strTablaConsultaExhibicionesAsignadasHTML(ByVal objConsultaExhibiciones As Array) As String
        Dim strTablaEspaciosHTML As StringBuilder
        Dim strConsultaExhibiciones As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim strRazon As String = String.Empty
        Dim intPage As Integer
        Dim intTotal As Integer = 50
        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 30
        Else
            intPage = CInt(Request.QueryString("p"))
        End If


        strTablaEspaciosHTML = New StringBuilder
        strTablaEspaciosHTML.Append("<span class='txsubtitulo'>Reporte Exhibiciones Adicionales - Asignadas </span> ")
        strTablaEspaciosHTML.Append(Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objConsultaExhibiciones.Length, intPage, intTotal, String.Empty, Nothing))

        strTablaEspaciosHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strTablaEspaciosHTML.Append("<tr class='trtitulos'>")

        'Encabezado titulos
        strTablaEspaciosHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Nombre de la Exhibición</th>")
        strTablaEspaciosHTML.Append("<th width='20%' class='rayita' align='center' valign='top'>Proveedor</th>")
        strTablaEspaciosHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Fecha Inicio</th>")
        strTablaEspaciosHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Fecha Fin</th>")
        strTablaEspaciosHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Dirección</th>")
        strTablaEspaciosHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Zona</th>")
        strTablaEspaciosHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Sucursal</th>")
        strTablaEspaciosHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Implementada</th>")
        strTablaEspaciosHTML.Append("<th width='10%' class='rayita' align='center' valign='top'>Motivo</th>")
        strTablaEspaciosHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaExhibiciones.Length) Then
                Exit For
            End If

            strConsultaExhibiciones = CType(objConsultaExhibiciones.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strRazon = strConsultaExhibiciones(9).ToString()

            If Trim(strConsultaExhibiciones(9)) = String.Empty Then
                strRazon = "&nbsp;"
            End If

            strTablaEspaciosHTML.Append("<tr>")

            ' Nombre Exhibición
            strTablaEspaciosHTML.Append("<td width='10%' align='center' class=" & strColorRegistro & " >" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(1)).ToString & "</td>")
            ' Proveedor
            strTablaEspaciosHTML.Append("<td width='20%' align='left' class=" & strColorRegistro & " >" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(2)).ToString & "</td>")
            'Fecha Ini
            strTablaEspaciosHTML.Append("<td width='10%' align='center' class=" & strColorRegistro & " >" & clsCommons.strFormatearFechaPresentacion(strConsultaExhibiciones(3)) & "</td>")
            'Fecha Fin
            strTablaEspaciosHTML.Append("<td width='10%' align='center' class=" & strColorRegistro & " >" & clsCommons.strFormatearFechaPresentacion(strConsultaExhibiciones(4)) & "</td>")
            ' Región
            strTablaEspaciosHTML.Append("<td width='10%' align='center' class=" & strColorRegistro & " >" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(5)) & "</td>")
            ' Zona
            strTablaEspaciosHTML.Append("<td width='10%' align='center' class=" & strColorRegistro & " >" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(6)) & "</td>")
            ' Sucursal
            strTablaEspaciosHTML.Append("<td width='10%' align='center' class=" & strColorRegistro & " >" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(7)) & "</td>")
            ' Implementacion
            strTablaEspaciosHTML.Append("<td width='10%' align='center' class=" & strColorRegistro & " >" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(8)) & "</td>")
            'Motivo
            strTablaEspaciosHTML.Append("<td width='10%' align='center' class=" & strColorRegistro & " >" & clsCommons.strFormatearDescripcion(strRazon) & "</td>")
            strTablaEspaciosHTML.Append("</tr>")

        Next
        strTablaEspaciosHTML.Append("</tr>")
        strTablaEspaciosHTML.Append("</table>")
        strTablaEspaciosHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaExhibicionesAsignadasHTML = strTablaEspaciosHTML.ToString
    End Function
#End Region

#Region "Impresion de Reportes"

    '====================================================================
    ' Name       : strReporteExhibiciones
    ' Description: Generacion de tabla HTML con formato para imprimir el reporte de Exhibiciones Adicionales.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strReporteExhibiciones(ByVal objDataArrayReporte As Array) As String

        'Variables
        Dim strImpresionReporteHTML As StringBuilder = New StringBuilder
        Dim strRegistroExhibiciones As String()
        Dim strclase As String = ""
        Dim intRenglonesxPagina As Integer = 58

        'Rutina que solo se ejecuta al contener informacion de la consulta.
        If IsArray(objDataArrayReporte) AndAlso (objDataArrayReporte.Length > 0) Then

            Dim intTotalRenglones As Integer = objDataArrayReporte.Length
            Dim intTotalPaginas As Integer = 0
            Dim intPagina As Integer = 0
            Dim intRenglon As Integer = 0
            Dim intContadorRenglon As Integer = 0

            'Total de paginas a imprimir.
            intTotalPaginas = CInt(intTotalRenglones \ intRenglonesxPagina)

            'Si se necesita una pagina mas se agrega.
            If intTotalRenglones Mod intRenglonesxPagina > 0 Then
                intTotalPaginas += 1
            End If

            'Inicio de ciclo que da formato a la informacion a imprimir.
            For Each strRegistroExhibiciones In objDataArrayReporte

                intRenglon += 1
                intContadorRenglon += 1

                If intRenglon = 1 Then
                    intPagina += 1

                    'Salto de hoja
                    If intPagina > 1 Then
                        strImpresionReporteHTML.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")
                    End If

                    strImpresionReporteHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    'Metodo que genera y da formato al encabezado.
                    strImpresionReporteHTML.Append(strEncabezadoReporte(intPagina.ToString, intTotalPaginas.ToString))
                End If

                'Clases para renglones.
                If ((intRenglon Mod 2) = 0) Then
                    strclase = "tdtxtImpresionNormal"
                Else
                    strclase = "tdtxtImpresionBold"
                End If

                strImpresionReporteHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                'Raya Sola
                strImpresionReporteHTML.Append("<tr class='trtxtBold'>")
                strImpresionReporteHTML.Append("<th width='100%' class='rayita' colspan='6'>" & "&nbsp;" & "</th>")
                strImpresionReporteHTML.Append("</tr>")

                'Encabezado titulos
                strImpresionReporteHTML.Append("<tr class='trtxtBold'>")
                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>Nombre de la Exhibición</th>")
                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>División</th>")
                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>Categoría</th>")
                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>Proveedor</th>")
                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>Socio Comercial</th>")
                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>Catman</th>")
                strImpresionReporteHTML.Append("</tr>")

                'Valores
                strImpresionReporteHTML.Append("<tr>")
                ' Nombre de la Exhibición
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(1)).ToString & "</td>")
                ' División
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(2)) & "</td>")
                ' Categoría
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(3)) & "</td>")
                ' Proveedor
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(4)) & "</td>")
                ' Socio Comercial
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(5)) & "</td>")
                ' Catman
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(6)) & "</td>")
                strImpresionReporteHTML.Append("</tr>")

                strmRutaImagen = Trim(strRegistroExhibiciones(22))

                If Not strmRutaImagen = String.Empty Then
                    strmRutaImagen = String.Format("{0}?id={1}", rutaImagenes, strmRutaImagen)
                End If

                'Imagen
                strImpresionReporteHTML.Append("<tr class='trtxtBold'>")
                'Foto Imagen...
                strImpresionReporteHTML.Append("<td colspan='1' rowspan='9' width='16.6%' align='left'>")
                strImpresionReporteHTML.AppendFormat("<img src=""{0}"" style=""border:none; width:1.3in; height:1.5in;"">", strmRutaImagen)
                strImpresionReporteHTML.Append("</td>")

                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>Tipo de Renta</th>")
                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>Tipo Exhibición</th>")
                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>Espacio Publicitario</th>")
                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>Plan de salida</th>")
                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>Comentarios</th>")

                strImpresionReporteHTML.Append("</tr>")

                'Valores
                strImpresionReporteHTML.Append("<tr>")
                ' Tipo Renta
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(7)).ToString & "</td>")
                ' Tipo Exhibición
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(8)).ToString & "</td>")
                ' Espacio Publicitario
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(9)) & "</td>")
                ' Plan de Salida
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(10)) & "</td>")
                ' Comentarios
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(11)) & "</td>")
                strImpresionReporteHTML.Append("</tr>")

                strImpresionReporteHTML.Append("<tr class='trtxtBold'>")
                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>Tipo de Plano</th>")
                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>Planograma</th>")
                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>Costo Merch</th>")
                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>Costo Catman</th>")
                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>Ingreso Total Merch</th>")
                strImpresionReporteHTML.Append("</tr>")

                'Valores
                strImpresionReporteHTML.Append("<tr>")
                ' Tipo de Plano
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(12)) & "</td>")
                'Planograma
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(13)) & "</td>")
                'Costo Merchandising
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "' >" & "$" & CDec(strRegistroExhibiciones(14)).ToString() & "</td>")
                'Costo Catman
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "' >" & "$" & CDec(strRegistroExhibiciones(15)).ToString() & "</td>")
                'Ingreso Total Merch
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "' >" & "$" & CDec(strRegistroExhibiciones(16)).ToString() & "</td>")
                strImpresionReporteHTML.Append("</tr>")

                strImpresionReporteHTML.Append("<tr class='trtxtBold'>")
                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>Ingreso Total Catman</th>")
                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>Ingreso Total</th>")
                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>Fecha Inicio</th>")
                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>Fecha Fin</th>")
                strImpresionReporteHTML.Append("<th width='16.6%' class='tdtxtBold' align='center' nowrap>Estatus</th>")
                strImpresionReporteHTML.Append("</tr>")
                strImpresionReporteHTML.Append("</tr>")

                'Ingreso Total Catman
                strImpresionReporteHTML.Append("<tr>")
                'Precio
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "' >" & "$" & CDec(strRegistroExhibiciones(17)).ToString() & "</td>")
                'Ingreso Total
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "' >" & "$" & CDec(strRegistroExhibiciones(18)).ToString() & "</td>")
                'Fecha Ini
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearFechaPresentacion(strRegistroExhibiciones(19)) & "</td>")
                'Fecha Fin
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearFechaPresentacion(strRegistroExhibiciones(20)) & "</td>")
                'Estatus
                strImpresionReporteHTML.Append("<td width='16.6%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(21)) & "</td>")
                strImpresionReporteHTML.Append("</tr>")

                strImpresionReporteHTML.Append("</table>")
                strImpresionReporteHTML.Append("<br /><br />")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionReporteHTML.Append("</table>")
                    intRenglon = 0
                End If
            Next

        End If

        Return strImpresionReporteHTML.ToString()

    End Function

    Private Function strEncabezadoReporte(ByVal strHojaActual As String, ByVal strHojaFinal As String) As String

        Dim strHtmlEncabezado As StringBuilder
        strHtmlEncabezado = New StringBuilder

        'Encabezado principal
        strHtmlEncabezado.Append("<tr>")
        strHtmlEncabezado.Append("<td colspan='6'>")
        strHtmlEncabezado.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='10' class='tdtxtBold'>Exhibiciones Adicionales</th>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='10%' align='left'   class='tdtxtBold'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th width='50%' align='center' class='tdtxtBold' nowrap> ADS Central </th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='10%' align='right'  class='tdtxtBold'>HOJA " & strHojaActual & " / " & strHojaFinal & " </th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strHtmlEncabezado.Append("</td>")
        strHtmlEncabezado.Append("</tr>")

        strEncabezadoReporte = strHtmlEncabezado.ToString

    End Function

#Region "Asignaciones"
    '====================================================================
    ' Name       : strImpresionAsignaciones
    ' Description: Generacion de tabla HTML con formato para imprimir el reporte de las Sucursales Asignadas.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImpresionAsignaciones(ByVal objDataArrayAsignaciones As Array) As String

        'Variables
        Dim strImpresionAsignacionesHTML As StringBuilder = New StringBuilder
        Dim strRegistroAsignaciones As String()
        Dim strclase As String = ""
        Dim intRenglonesxPagina As Integer = 58

        'Rutina que solo se ejecuta al contener informacion de la consulta.
        If IsArray(objDataArrayAsignaciones) AndAlso (objDataArrayAsignaciones.Length > 0) Then

            Dim intTotalRenglones As Integer = objDataArrayAsignaciones.Length
            Dim intTotalPaginas As Integer = 0
            Dim intPagina As Integer = 0
            Dim intRenglon As Integer = 0
            Dim intContadorRenglon As Integer = 0

            'Total de paginas a imprimir.
            intTotalPaginas = CInt(intTotalRenglones \ intRenglonesxPagina)

            'Si se necesita una pagina mas se agrega.
            If intTotalRenglones Mod intRenglonesxPagina > 0 Then
                intTotalPaginas += 1
            End If

            'Inicio de ciclo que da formato a la informacion a imprimir.
            For Each strRegistroAsignaciones In objDataArrayAsignaciones

                intRenglon += 1
                intContadorRenglon += 1

                If intRenglon = 1 Then
                    intPagina += 1

                    'Salto de hoja
                    If intPagina > 1 Then
                        strImpresionAsignacionesHTML.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")
                    End If

                    strImpresionAsignacionesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    'Metodo que genera y da formato al encabezado.
                    strImpresionAsignacionesHTML.Append(strImprimeEncabezadoAsignaciones(intPagina.ToString, intTotalPaginas.ToString))
                End If

                'Clases para renglones.
                If ((intRenglon Mod 2) = 0) Then
                    strclase = "tdtxtImpresionNormal"
                Else
                    strclase = "tdtxtImpresionBold"
                End If


                strImpresionAsignacionesHTML.Append("<tr>")
                ' Nombre Exhibición
                strImpresionAsignacionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroAsignaciones(1)).ToString & "</td>")
                ' Proveedor
                strImpresionAsignacionesHTML.Append("<td width='20%' align='left' class='" & strclase & "' nowrap >" & clsCommons.strFormatearDescripcion(strRegistroAsignaciones(2)).ToString & "</td>")
                'Fecha Ini
                strImpresionAsignacionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearFechaPresentacion(strRegistroAsignaciones(3)) & "</td>")
                'Fecha Fin
                strImpresionAsignacionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearFechaPresentacion(strRegistroAsignaciones(4)) & "</td>")
                ' Región
                strImpresionAsignacionesHTML.Append("<td width='10%' align='center' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroAsignaciones(5)) & "</td>")
                ' Zona
                strImpresionAsignacionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroAsignaciones(6)) & "</td>")
                ' Sucursal
                strImpresionAsignacionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroAsignaciones(7)) & "</td>")
                ' Implementacion
                strImpresionAsignacionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroAsignaciones(8)) & "</td>")
                'Motivo
                strImpresionAsignacionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroAsignaciones(9)) & "</td>")
                strImpresionAsignacionesHTML.Append("</tr>")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionAsignacionesHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next

        End If

        Return strImpresionAsignacionesHTML.ToString()

    End Function

    Private Function strImprimeEncabezadoAsignaciones(ByVal strHojaActual As String, ByVal strHojaFinal As String) As String

        Dim strHtmlEncabezado As StringBuilder
        strHtmlEncabezado = New StringBuilder

        'Encabezado principal
        strHtmlEncabezado.Append("<tr>")
        strHtmlEncabezado.Append("<td colspan='9'>")
        strHtmlEncabezado.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='9' class='tdtxtBold'>Exhibiciones Adicionales - Asignaciones</th>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='10%' align='left'   class='tdtxtBold'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th width='50%' align='center' class='tdtxtBold' nowrap> ADS Central </th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='10%' align='right'  class='tdtxtBold'>HOJA " & strHojaActual & " / " & strHojaFinal & " </th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strHtmlEncabezado.Append("</td>")
        strHtmlEncabezado.Append("</tr>")

        'Encabezado titulos
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Nombre de la Exhibición</th>")
        strHtmlEncabezado.Append("<th width='20%' class='tdtxtBold' align='center' nowrap>Proveedor</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Fecha Inicio</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Fecha Fin</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Dirección</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Zona</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Sucursal</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Implementada</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Motivo</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' class='rayita' colspan='9'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        strImprimeEncabezadoAsignaciones = strHtmlEncabezado.ToString

    End Function
#End Region
#End Region

#Region "Exportar"

    Public Function strTablaExhibicionesAdicionalesExportar(ByVal objConsultaExhibiciones As Array) As String
        Dim strTablaEspaciosHTML As StringBuilder
        Dim strConsultaExhibiciones As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer

        Dim imgAsignar As String = Nothing
        Dim imgEditar As String = Nothing
        Dim imgEliminar As String = Nothing
        Dim imgDetalle As String = Nothing


        Dim Imagen As String = Nothing

        Dim intPage As Integer = 1
        Dim intTotal As Integer = 50


        strTablaEspaciosHTML = New StringBuilder
        strTablaEspaciosHTML.Append("<span class='txsubtitulo'> </span> ")
        strTablaEspaciosHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strTablaEspaciosHTML.Append("<tr class='trtitulos'>")
        'strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Imagen</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Nombre de Exhibición</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>División</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Categoría</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Proveedor</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Socio Comercial</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Catman</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Tipo de Renta</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Tipo Exhibición</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Espacio Publicitario</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Plan de salida</th>")
        strTablaEspaciosHTML.Append("<th width='4%' align=center class='rayita' align='left' valign='top'>Comentarios</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Tipo de Plano</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Planograma</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Costo Merch</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Costo Catman</th>")
        strTablaEspaciosHTML.Append("<th width='8%' align=center class='rayita' align='left' valign='top'>Ingreso Total Merch</th>")
        strTablaEspaciosHTML.Append("<th width='8%' align=center class='rayita' align='left' valign='top'>Ingreso Total Catman</th>")
        strTablaEspaciosHTML.Append("<th width='4%' align=center class='rayita' align='left' valign='top'>Ingreso Total</th>")
        strTablaEspaciosHTML.Append("<th width='4%' align=center class='rayita' align='left' valign='top'>Fecha Inicio</th>")
        strTablaEspaciosHTML.Append("<th width='4%' align=center class='rayita' align='left' valign='top'>Fecha Fin</th>")
        strTablaEspaciosHTML.Append("<th width='4%' align=center class='rayita' align='left' valign='top'>Estatus</th>")

        strTablaEspaciosHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objConsultaExhibiciones.Length) Then
                Exit For
            End If

            strConsultaExhibiciones = CType(objConsultaExhibiciones.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strTablaEspaciosHTML.Append("<tr>")

            'Nombre de exhibicion
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(1)) & "</td>")
            'División                  
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(2)) & "</td>")
            'Categoría 
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(3)) & "</td>")
            'Proveedor                
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(4)) & "</td>")
            'Socio Comercial
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(5)) & "</td>")
            'Catman
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(6)) & "</td>")
            'Tipo de Renta       
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(7)) & "</td>")
            'Tipo de Exhibición
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(8)) & "</td>")
            'Espacio Publicitario
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(9)) & "</td>")
            'Plan de salida
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(10)) & "</td>")
            'Comentarios
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(11)) & "</td>")
            'Tipo de plano
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(12)) & "</td>")
            'Planograma
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(13)) & "</td>")
            'Costo Merch
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & "$" & CDec(strConsultaExhibiciones(14)).ToString() & "</td>")
            'Costo Catman
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & "$" & CDec(strConsultaExhibiciones(15)).ToString() & "</td>")
            'Ingreso Total Merch
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & "$" & CDec(strConsultaExhibiciones(16)).ToString() & "</td>")
            'Ingreso Total Catman
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & "$" & CDec(strConsultaExhibiciones(17)).ToString() & "</td>")
            'Ingreso Total
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & "$" & CDec(strConsultaExhibiciones(18)).ToString() & "</td>")
            'Fecha Ini
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaExhibiciones(19)) & "</td>")
            'Fecha Fin
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaExhibiciones(20)) & "</td>")
            'Estatus
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(21)) & "</td>")
            strTablaEspaciosHTML.Append("</tr>")

        Next
        strTablaEspaciosHTML.Append("</tr>")
        strTablaEspaciosHTML.Append("</table>")
        strTablaExhibicionesAdicionalesExportar = strTablaEspaciosHTML.ToString
    End Function

    Public Function strTablExhibicionesAsignadasExportar(ByVal objArrayAsignaciones As Array) As String
        Dim strTablaEspaciosHTML As StringBuilder
        Dim strConsultaExhibiciones As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer

        Dim imgAsignar As String = Nothing
        Dim imgEditar As String = Nothing
        Dim imgEliminar As String = Nothing
        Dim imgDetalle As String = Nothing


        Dim Imagen As String = Nothing

        Dim intPage As Integer = 1
        Dim intTotal As Integer = 50


        strTablaEspaciosHTML = New StringBuilder
        strTablaEspaciosHTML.Append("<span class='txsubtitulo'> </span> ")
        strTablaEspaciosHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strTablaEspaciosHTML.Append("<tr class='trtitulos'>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Nombre de Exhibición</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Proveedor</th>")
        strTablaEspaciosHTML.Append("<th width='4%' align=center class='rayita' align='left' valign='top'>Fecha Inicio</th>")
        strTablaEspaciosHTML.Append("<th width='4%' align=center class='rayita' align='left' valign='top'>Fecha Fin</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Dirección</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Zona</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Sucursal</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Implementada</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Motivo</th>")
        strTablaEspaciosHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar el rsultado de la busqueda en la tabla.
        For intContador = (intPage - 1) * intTotal To (intPage * intTotal) - 1
            If (intContador >= objArrayAsignaciones.Length) Then
                Exit For
            End If

            strConsultaExhibiciones = CType(objArrayAsignaciones.GetValue(intContador), String())

            If (intContador Mod 2) <> 0 Then
                strColorRegistro = "'tdceleste'"
            Else
                strColorRegistro = "'tdblanco'"
            End If

            strTablaEspaciosHTML.Append("<tr>")

            'Nombre de exhibicion
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(1)) & "</td>")
            'Proveedor
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(2)) & "</td>")
            'Fecha Ini
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaExhibiciones(3)) & "</td>")
            'Fecha Fin
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaExhibiciones(4)) & "</td>")
            'Dirección
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(5)) & "</td>")
            'Zona
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(6)) & "</td>")
            'Sucursal
            strTablaEspaciosHTML.Append("<td id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & strConsultaExhibiciones(7) & "</td>")
            'Implementada
            strTablaEspaciosHTML.Append("<td id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & strConsultaExhibiciones(8) & "</td>")
            'Motivo
            strTablaEspaciosHTML.Append("<td id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & strConsultaExhibiciones(9) & "</td>")
            strTablaEspaciosHTML.Append("</tr>")

        Next
        strTablaEspaciosHTML.Append("</tr>")
        strTablaEspaciosHTML.Append("</table>")
        strTablExhibicionesAsignadasExportar = strTablaEspaciosHTML.ToString
    End Function
#End Region
End Class