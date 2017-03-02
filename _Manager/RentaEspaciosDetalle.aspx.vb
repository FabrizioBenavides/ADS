Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Benavides.POSAdmin.Commons.clsCommons.clsMSMQ
Imports Benavides.CC.Data.clsPromociones
Imports System.Text
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports System.IO
Imports System.Web.Caching

Public Class RentaEspaciosDetalle
    Inherits System.Web.UI.Page

    Private strmDivisionDescripcion As String
    Private strmCategoriaDescripcion As String
    Private strmCatman As String
    Private strmSocioComercial As String
    Private strmProveedor As String
    Private strmTipoRenta As String
    Private strmTipoExhibicion As String
    Private strmTipoMueble As String
    Private strmEspacioPublicitario As String
    Private strmNombreExhibicion As String
    Private strmPlanSalida As String
    Private strmComentarios As String
    Private strmTipoPlanograma As String
    Private strmPlanograma As String
    Private strmIngresoTotal As String
    Private strmCostoCatMan As String
    Private strmCostoMerchandising As String
    Private strmIngresoTotalMerch As String
    Private strmIngresoTotalCatman As String
    Private strmEstatus As String
    Private strmFechaInicio As String
    Private strmFechaFin As String
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
    ' Name       : strDivision
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strDivision() As String
        Get
            Return strmDivisionDescripcion
        End Get
        Set(ByVal strValue As String)
            strmDivisionDescripcion = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : strCategoria
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strCategoria() As String
        Get
            Return strmCategoriaDescripcion
        End Get
        Set(ByVal strValue As String)
            strmCategoriaDescripcion = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : strCatman
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strCatman() As String
        Get
            Return strmCatman
        End Get
        Set(ByVal strValue As String)
            strmCatman = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strSocioComercial
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strSocioComercial() As String
        Get
            Return strmSocioComercial
        End Get
        Set(ByVal strValue As String)
            strmSocioComercial = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : strProveedor
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strProveedor() As String
        Get
            Return strmProveedor
        End Get
        Set(ByVal strValue As String)
            strmProveedor = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoRenta
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strTipoRenta() As String
        Get
            Return strmTipoRenta
        End Get
        Set(ByVal strValue As String)
            strmTipoRenta = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoExhibicion
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strTipoExhibicion() As String
        Get
            Return strmTipoExhibicion
        End Get
        Set(ByVal strValue As String)
            strmTipoExhibicion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEspacioPublicitario
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strEspacioPublicitario() As String
        Get
            Return strmEspacioPublicitario
        End Get
        Set(ByVal strValue As String)
            strmEspacioPublicitario = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strNombreExhibicion
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strNombreExhibicion() As String
        Get
            Return strmNombreExhibicion
        End Get
        Set(ByVal strValue As String)
            strmNombreExhibicion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strPlanSalida
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strPlanSalida() As String
        Get
            Return strmPlanSalida
        End Get
        Set(ByVal strValue As String)
            strmPlanSalida = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strComentarios
    ' Description: Comentarios de Plan de Salida.
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strComentarios() As String
        Get
            Return strmComentarios
        End Get
        Set(ByVal strValue As String)
            strmComentarios = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoPlanograma
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strTipoPlanograma() As String
        Get
            Return strmTipoPlanograma
        End Get
        Set(ByVal strValue As String)
            strmTipoPlanograma = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : strPlanograma
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strPlanograma() As String
        Get
            Return strmPlanograma
        End Get
        Set(ByVal strValue As String)
            strmPlanograma = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCostoCatMan
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strCostoCatMan() As String
        Get
            Return strmCostoCatMan
        End Get
        Set(ByVal strValue As String)
            strmCostoCatMan = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCostoMerch
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strCostoMerch() As String
        Get
            Return strmCostoMerchandising
        End Get
        Set(ByVal strValue As String)
            strmCostoMerchandising = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strIngresoTotMerch
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strIngresoTotMerch() As String
        Get
            Return strmIngresoTotalMerch
        End Get
        Set(ByVal strValue As String)
            strmIngresoTotalMerch = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strIngresoTotCatMan
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strIngresoTotCatMan() As String
        Get
            Return strmIngresoTotalCatman
        End Get
        Set(ByVal strValue As String)
            strmIngresoTotalCatman = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strIngresoTotal
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strIngresoTotal() As String
        Get
            Return strmIngresoTotal
        End Get
        Set(ByVal strValue As String)
            strmIngresoTotal = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEstatus
    ' Description: Nombre o descripcion del articulo.
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strEstatus() As String
        Get
            Return strmEstatus
        End Get
        Set(ByVal strValue As String)
            strmEstatus = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaInicio
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strFechaInicio() As String
        Get
            Return strmFechaInicio
        End Get
        Set(ByVal strValue As String)
            strmFechaInicio = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : strFechaFin
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strFechaFin() As String
        Get
            Return strmFechaFin
        End Get
        Set(ByVal strValue As String)
            strmFechaFin = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCodigoId
    ' Description: Codigo del articulo
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCodigoId() As String
        Get
            If Not IsNothing(Request.QueryString("intExhibicionCodigo")) Then
                'Si es parametro de la pantalla anterior
                Return Request.QueryString("intExhibicionCodigo")
            ElseIf Not IsNothing(Request.Form("hdnCodigoId")) Then
                'Parametro en campo oculto.
                Return Request.Form("hdnCodigoId")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strRutaImagen
    ' Description: Ruta de la imagen
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strRutaImagen() As String
        Get
            Return strmRutaImagen
        End Get
        Set(ByVal Value As String)
            strmRutaImagen = Value

        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Dim objArray As Array = Nothing
        Dim objArraySucursalesAsignadas As Array = Nothing

        If Not IsNothing(strCodigoId) AndAlso CInt(strCodigoId) > 0 Then

            'Detalle de la exhibicion
            objArray = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarExhibicionDetalle(CInt(strCodigoId), strConnectionString)

            'Tabla de Sucursales asignadas
            objArraySucursalesAsignadas = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarSucursalesAsignadas(CInt(strCodigoId), strConnectionString)
        End If

        'Imprimir
        If Request.QueryString("strCmd") = "cmdImprimir" Then

            Dim strHTML As New StringBuilder
            Dim strRecordBrowserImpresion As String = String.Empty
            Const strComitasDobles As String = """"

            If IsArray(objArray) AndAlso objArray.Length > 0 Then

                'Se envia la informacion a imprimir para darle formato de acuerdo a la tabla seleccionada por el usuario.  
                strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strImpresionDetalle(objArray) & strImpresionSucursalesAsignadas(objArraySucursalesAsignadas))

                'Se ennvia a impresion.
                strHTML.Append("<script language='Javascript'>parent.fnImprimir( " & _
                strComitasDobles & strRecordBrowserImpresion.ToString & strComitasDobles & _
                "); </script>")
                Response.Write(strHTML.ToString)
                Response.End()

            End If
        Else

            'Detalle en pantalla
            If IsArray(objArray) AndAlso objArray.Length > 0 Then

                'Datos Generales
                strmDivisionDescripcion = CStr(CType(objArray.GetValue(0), Array).GetValue(2))
                strmCategoriaDescripcion = CStr(CType(objArray.GetValue(0), Array).GetValue(4))
                strmCatman = CStr(CType(objArray.GetValue(0), Array).GetValue(6))
                strmSocioComercial = CStr(CType(objArray.GetValue(0), Array).GetValue(8))
                strmProveedor = CStr(CType(objArray.GetValue(0), Array).GetValue(10)) '& " " & CStr(CType(objArray.GetValue(0), Array).GetValue(6)) 'concatenar

                'Datos Exhibición
                strmTipoRenta = CStr(CType(objArray.GetValue(0), Array).GetValue(12))
                strmTipoExhibicion = CStr(CType(objArray.GetValue(0), Array).GetValue(14))
                strmEspacioPublicitario = CStr(CType(objArray.GetValue(0), Array).GetValue(16))
                strmNombreExhibicion = CStr(CType(objArray.GetValue(0), Array).GetValue(17))
                strmPlanSalida = CStr(CType(objArray.GetValue(0), Array).GetValue(19))
                strmComentarios = CStr(CType(objArray.GetValue(0), Array).GetValue(20))
                strmTipoPlanograma = CStr(CType(objArray.GetValue(0), Array).GetValue(22))
                strmPlanograma = CStr(CType(objArray.GetValue(0), Array).GetValue(24)) '& " " & CStr(CType(objArray.GetValue(0), Array).GetValue(15)) 'concatenar
                strmEstatus = CStr(CType(objArray.GetValue(0), Array).GetValue(26))

                'Costos e Ingresos
                strmCostoMerchandising = CStr(CType(objArray.GetValue(0), Array).GetValue(27))
                strmCostoCatMan = CStr(CType(objArray.GetValue(0), Array).GetValue(28))
                strmIngresoTotalMerch = CStr(CType(objArray.GetValue(0), Array).GetValue(29))
                strmIngresoTotalCatman = CStr(CType(objArray.GetValue(0), Array).GetValue(30))
                strmIngresoTotal = CStr(CType(objArray.GetValue(0), Array).GetValue(31))

                'Vigencia
                strmFechaInicio = (CDate(CType(objArray.GetValue(0), Array).GetValue(33))).ToString("dd/MM/yyyy")
                strmFechaFin = (CDate(CType(objArray.GetValue(0), Array).GetValue(34))).ToString("dd/MM/yyyy")

                strmRutaImagen = Trim(CStr(CType(objArray.GetValue(0), Array).GetValue(32)))

                If Not strmRutaImagen = String.Empty Then
                    strmRutaImagen = String.Format("{0}?id={1}", rutaImagenes, strmRutaImagen)
                End If

            End If
        End If

    End Sub

#Region "Imprimir"

    '====================================================================
    ' Name       : strImpresionDetalle
    ' Description: Generacion de tabla HTML con formato para imprimir resultados de la consulta.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImpresionDetalle(ByVal objDataArrayDetalle As Array) As String

        'Variables
        Dim strImpresionExhibicionesHTML As StringBuilder = New StringBuilder
        Dim strRegistroExhibicion As String()
        Dim strclase As String = "tdtxtImpresionNormal"
        Dim strclaseTitulos As String = "tdtxtImpresionBold"
        Dim intPagina As Integer = 1
        Dim intTotalPaginas As Integer = 1
        Dim chk As String = String.Empty
        Dim RentaAsignada As String = String.Empty
        Dim imagenAsignada As String = String.Empty

        'Rutina que solo se ejecuta al contener informacion de la consulta.
        If IsArray(objDataArrayDetalle) AndAlso (objDataArrayDetalle.Length > 0) Then

            'Inicio de ciclo que da formato a la informacion a imprimir.
            For Each strRegistroExhibicion In objDataArrayDetalle

                strImpresionExhibicionesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                'Metodo que genera y da formato al encabezado.
                strImpresionExhibicionesHTML.Append(strImprimeEncabezado(intPagina.ToString, intTotalPaginas.ToString))

                'Imagen
                strmRutaImagen = Trim(CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(32)))

                If Not strmRutaImagen = String.Empty Then
                    strmRutaImagen = String.Format("{0}?id={1}", rutaImagenes, strmRutaImagen)
                End If

                'Imagen
                strImpresionExhibicionesHTML.Append("<tr><td width='100%' colspan='4'>&nbsp;</td></tr>")
                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td >&nbsp;</td>")
                strImpresionExhibicionesHTML.Append("<td colspan='2' align='center'>")
                strImpresionExhibicionesHTML.AppendFormat("<img src=""{0}"" style=""border:none; width:5in; height:3.6in;"">", strmRutaImagen)
                strImpresionExhibicionesHTML.Append("</td>")
                strImpresionExhibicionesHTML.Append("<td >&nbsp;</td>")
                strImpresionExhibicionesHTML.Append("</tr>")
                strImpresionExhibicionesHTML.Append("<tr><td>&nbsp;</td></tr>")

                'Seccion Datos Generales
                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td colspan='4'><h3>Datos Generales:</h3></td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "' >División:</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(2)) & "</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "' >Categoría:</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(4)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")
                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "' >CATMAN:</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(6)) & "</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "' >Socio Comercial:</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(8)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "'>Proveedor:</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "'  colspan='3'>" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(10)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")
                strImpresionExhibicionesHTML.Append("<tr><td>&nbsp;</td></tr>")

                'Seccion Datos Exhibicion
                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td colspan='6'><h3>Datos Exhibición:</h3></td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "' >Tipo de Renta:</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(12)) & "</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "' >Tipo de Exhibición:</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(14)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "' >Espacio Publicitario:</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(16)) & "</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "' >Nombre de la Exhibición:</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(17)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "' >Plan de Salida:</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(19)) & "</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "' >Comentarios:</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(20)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "' >Tipo de Planograma:</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(22)) & "</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "' >Planograma:</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(24)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "' >Estatus:</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(26)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr><td>&nbsp;</td></tr>")

                'Seccion Costos e Ingresos
                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td colspan='6'><h3>Costos e Ingresos:</h3></td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "' >Costo Merch:</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & "$" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(27)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "' >Costo Catman:</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & "$" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(28)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "' >Ingreso Total Merch</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & "$" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(29)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "' >Ingreso Total Catman:</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & "$" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(30)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "' >Ingreso Total</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & "$" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(31)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")
                strImpresionExhibicionesHTML.Append("<tr><td>&nbsp;</td></tr>")

                'Vigencia
                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td colspan='6'><h3>Vigencia:</h3></td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "' >Fecha Inicio:</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(33)) & "</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclaseTitulos & "' >Fecha Fin:</td>")
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(34)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")
                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("</table>")

                Exit For
            Next

        End If

        strImpresionExhibicionesHTML.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")

        Return strImpresionExhibicionesHTML.ToString()

    End Function

    Private Function strImprimeEncabezado(ByVal strHojaActual As String, ByVal strHojaFinal As String) As String

        Dim strHtmlEncabezado As StringBuilder
        strHtmlEncabezado = New StringBuilder

        'Encabezado principal
        strHtmlEncabezado.Append("<tr>")
        strHtmlEncabezado.Append("<td colspan='4'>")
        strHtmlEncabezado.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='4' class='tdtxtBold'>Exhibiciones Adicionales - Consulta Detalle</th>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='10%' align='left'   class='tdtxtBold'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th width='90%' align='right' class='tdtxtBold' nowrap colspan='2'>ADS Central</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strHtmlEncabezado.Append("</td>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' class='rayita' colspan='4'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        strImprimeEncabezado = strHtmlEncabezado.ToString

    End Function

    '====================================================================
    ' Name       : strImpresionSucursalesAsignadas
    ' Description: Generacion de tabla HTML con formato para imprimir resultados de la consulta.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImpresionSucursalesAsignadas(ByVal objConsultaSucursales As Array) As String

        'Variables
        Dim strImpresionExhibicionesHTML As StringBuilder = New StringBuilder
        Dim strConsultaSucursales As String()
        Dim strclase As String = String.Empty
        Dim intRenglonesxPagina As Integer = 58
        Dim imgImplementado As String = Nothing
        Dim strRazon As String = Nothing

        'Rutina que solo se ejecuta al contener informacion de la consulta.
        If IsArray(objConsultaSucursales) AndAlso (objConsultaSucursales.Length > 0) Then

            Dim intTotalRenglones As Integer = objConsultaSucursales.Length
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
            For Each strConsultaSucursales In objConsultaSucursales

                intRenglon += 1
                intContadorRenglon += 1

                If intRenglon = 1 Then
                    intPagina += 1

                    'Salto de hoja
                    If intPagina > 1 Then
                        strImpresionExhibicionesHTML.Append("<div style='page-break-AFTER: always;'>&nbsp;</div>")
                    End If

                    strImpresionExhibicionesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'> ")

                    'Metodo que genera y da formato al encabezado.
                    strImpresionExhibicionesHTML.Append(strImprimeEncabezadoSucursalesAsignadas(intPagina.ToString, intTotalPaginas.ToString))
                End If

                'Clases para renglones.
                If ((intRenglon Mod 2) = 0) Then
                    strclase = "tdtxtImpresionNormal"
                Else
                    strclase = "tdtxtImpresionBold"
                End If

                'Validacion de las columnas de la tabla de "Sucursales Asignadas"
                imgImplementado = "SI"
                strRazon = clsCommons.strFormatearDescripcion(strConsultaSucursales(4))

                'Validacion de la asignacion
                If CBool(Trim(strConsultaSucursales(3))) = False Then
                    imgImplementado = "NO"
                Else
                    strRazon = "&nbsp"
                End If
                If strRazon = String.Empty Then
                    strRazon = "&nbsp"
                End If

                
                strImpresionExhibicionesHTML.Append("<tr>")
                ' Código y Nombre
                strImpresionExhibicionesHTML.Append("<td width='10%' align='left' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strConsultaSucursales(1)) & " " & clsCommons.strFormatearDescripcion(strConsultaSucursales(2)) & "</td>")
                ' Implementada
                strImpresionExhibicionesHTML.Append("<td width='20%' align='center' class='" & strclase & "' nowrap >" & imgImplementado & "</td>")
                ' Razón de No implementacion
                strImpresionExhibicionesHTML.Append("<td width='10%' align='center' class='" & strclase & "'>" & strRazon & "</td>")
                
                strImpresionExhibicionesHTML.Append("</tr>")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionExhibicionesHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next

        End If

        Return strImpresionExhibicionesHTML.ToString()

    End Function

    Private Function strImprimeEncabezadoSucursalesAsignadas(ByVal strHojaActual As String, ByVal strHojaFinal As String) As String

        Dim strHtmlEncabezado As StringBuilder
        strHtmlEncabezado = New StringBuilder

        'Encabezado principal
        strHtmlEncabezado.Append("<tr>")
        strHtmlEncabezado.Append("<td colspan='3'>")
        strHtmlEncabezado.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='3' class='tdtxtBold'>Sucursales Asignadas</th>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='50%' align='left'   class='tdtxtBold' colspan='2'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th width='50%' align='right' class='tdtxtBold' nowrap>ADS Central</th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strHtmlEncabezado.Append("</td>")
        strHtmlEncabezado.Append("</tr>")

        'Encabezado titulos
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='40%' class='tdtxtBold' align='center' nowrap>Código y Nombre</th>")
        strHtmlEncabezado.Append("<th width='20%' class='tdtxtBold' align='center' nowrap>Implementada</th>")
        strHtmlEncabezado.Append("<th width='40%' class='tdtxtBold' align='center' nowrap>Razón de No implementacion</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' class='rayita' colspan='3'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        strImprimeEncabezadoSucursalesAsignadas = strHtmlEncabezado.ToString

    End Function


#End Region

#Region "Sucursales Asignadas"
    Public Function strTablaConsultaSucursalesAsignadas() As String
        'Variables
        Dim objArraySucursalesAsignadas As System.Array = Nothing
        Dim strRegistro As String()

        'Paginacion
        If (Request.QueryString("pager") = "true") Then
            If Not Cache("cacheSucursalesAsignadas") Is Nothing Then
                objArraySucursalesAsignadas = CType(Cache("cacheSucursalesAsignadas"), System.Array)
            End If
        End If

        'Si no existen datos en memoria se realiza de nuevo la busqueda.
        If objArraySucursalesAsignadas Is Nothing Then
            Cache.Remove("cacheSucursalesAsignadas")
            objArraySucursalesAsignadas = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarSucursalesAsignadas(CInt(strCodigoId), strConnectionString)
        End If

        'Si hay resultados se muestran en pantalla
        If Not objArraySucursalesAsignadas Is Nothing AndAlso IsArray(objArraySucursalesAsignadas) AndAlso objArraySucursalesAsignadas.Length > 0 Then
            Cache.Add("cacheSucursalesAsignadas", objArraySucursalesAsignadas, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Normal, Nothing)

            Dim strResult As New StringBuilder()

            strResult.Append(strTablaConsultaSucursalesAsignadasesHTML(objArraySucursalesAsignadas))
            strResult.Append("<script language=""javascript"" type=""text/javascript"">")
            strResult.Append("parent.document.getElementById('tblSucursalesAsignadas').innerHTML = document.getElementById('divConsultaSucursalesAsignadas').innerHTML;")
            strResult.Append("</script>")

            Return strResult.ToString()
        End If

        Return String.Empty
    End Function

    Public Function strTablaConsultaSucursalesAsignadasesHTML(ByVal objConsultaSucursales As Array) As String
        Dim strTablaSucursalesHTML As StringBuilder
        Dim strConsultaSucursales As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer
        Dim imgImplementado As String = Nothing
        Dim strRazon As String = Nothing

        'Datos de la paginacion
        Dim intPage As Integer
        Dim intTotal As Integer = 5
        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If


        strTablaSucursalesHTML = New StringBuilder
        strTablaSucursalesHTML.Append("<span class='txsubtitulo'>Sucursales:</span> ")
        strTablaSucursalesHTML.Append(Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objConsultaSucursales.Length, intPage, intTotal, String.Empty, Nothing))

        strTablaSucursalesHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        'Encabezados
        strTablaSucursalesHTML.Append("<tr class='trtitulos'>")
        strTablaSucursalesHTML.Append("<th width='40%' align=center class='rayita' valign='top'>Código y Nombre</th>")
        strTablaSucursalesHTML.Append("<th width='20%' align=center class='rayita' valign='top'>Implementada</th>")
        strTablaSucursalesHTML.Append("<th width='40%' align=left class='rayita' valign='top'>Razon de No implementacion</th>")
        strTablaSucursalesHTML.Append("</tr>")

        intContador = 0

        'Inicia el ciclo para generar la tabla de sucursales asignadas.
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

            'Validacion de las columnas de la tabla de "Sucursales Asignadas"
            imgImplementado = "<img id=Asi" & strConsultaSucursales(0) & " height='17' src='../static/images/imgNRTrasmitido.gif' width='17' align='absMiddle' border='0'>"
            strRazon = clsCommons.strFormatearDescripcion(strConsultaSucursales(4))

            'Validacion de la asignacion
            If CBool(Trim(strConsultaSucursales(3))) = False Then
                imgImplementado = "&nbsp"
            Else
                strRazon = "&nbsp"
            End If
            If strRazon = String.Empty Then
                strRazon = "&nbsp"
            End If

            strTablaSucursalesHTML.Append("<tr>")

            'Código y Nombre	
            strTablaSucursalesHTML.Append("<td id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaSucursales(1)) & " " & clsCommons.strFormatearDescripcion(strConsultaSucursales(2)) & "</td>")
            'Implementada
            strTablaSucursalesHTML.Append("<td align=center class=" & strColorRegistro & ">" & imgImplementado & "</td>")
            'Acción
            strTablaSucursalesHTML.Append("<td class=" & strColorRegistro & ">" & strRazon & "</td>")
            strTablaSucursalesHTML.Append("</tr>")

        Next
        strTablaSucursalesHTML.Append("</tr>")
        strTablaSucursalesHTML.Append("</table>")
        strTablaSucursalesHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaSucursalesAsignadasesHTML = strTablaSucursalesHTML.ToString
    End Function
#End Region
End Class