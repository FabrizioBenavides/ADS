Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration
Imports Benavides.CC.Data.clsPromociones
Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports System.IO
Imports System.Web.Caching

Public Class RentaEspaciosDetalle1
    Inherits System.Web.UI.Page

    Private strmDivision As String
    Private strmCategoria As String
    Private strmCatman As String
    Private strmProveedor As String
    Private strmSocioComercial As String
    Private strmTipoExhibicion As String
    Private strmTipoRenta As String
    Private strmEspacioPublicitario As String
    Private strmTipoPlanograma As String
    Private strmPlanograma As String
    Private strmNombreExhibicion As String
    Private strmPlanSalida As String
    Private strmComentariosPlanSalida As String
    Private strmEstatus As String
    Private strmFechaInicio As String
    Private strmFechaFin As String
    Private strmImplementado As String
    Private strmRazon As String
    Private strmRutaImagen As String = String.Empty

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
    ' Name       : strCentroLogisticoId
    ' Description: Valor de la Compañia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strCentroLogisticoId() As String
        Get
            Return (clsCommons.strReadCookie("strCentroLogisticoId", "", Request, Server))
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
    ' Description: Valor que tomara la variable strmCadenaConexion
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
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strDivision
    ' Description: Division.
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strDivision() As String
        Get
            Return strmDivision
        End Get
        Set(ByVal strValue As String)
            strmDivision = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCategoria
    ' Description: Categoria.
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strCategoria() As String
        Get
            Return strmCategoria
        End Get
        Set(ByVal strValue As String)
            strmCategoria = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCatman
    ' Description: Nombre o descripcion del catman.
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
    ' Name       : strProveedor
    ' Description: Nombre o descripcion del proveedor.
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
    ' Name       : strSocioComercial
    ' Description: Socio comercial.
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
    ' Name       : strTipoRenta
    ' Description: Tipo de renta.
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
    ' Description: Tipo de la exhibicion.
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
    ' Description: Espacio publicitario.
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
    ' Name       : strTipoPlanograma
    ' Description: Nombre o descripcion del tipo de planograma.
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
    ' Description: Nombre o descripcion del planograma.
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
    ' Name       : strNombreExhibicion
    ' Description: Nombre o descripcion de la renta.
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
    ' Description: Plan de salida.
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
    ' Name       : strComentariosPlanSalida
    ' Description: Comentarios del plan de salida
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strComentariosPlanSalida() As String
        Get
            Return strmComentariosPlanSalida
        End Get
        Set(ByVal strValue As String)
            strmComentariosPlanSalida = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEstatus
    ' Description: Estatus de la Renta.
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
    ' Description: Fecha de inicio de la renta.
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
    ' Description: Fecha final de la renta.
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
    ' Name       : strImplementado
    ' Description: Define si se ha implementado.
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strImplementado() As String
        Get
            If strmImplementado = "True" Then
                Return "checked"
            Else
                Return String.Empty
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : strRazon
    ' Description: Motivo de no implementacion.
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strRazon() As String
        Get
            Return strmRazon
        End Get
        Set(ByVal strValue As String)
            strmRazon = strValue
        End Set
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

        'Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        Dim objArray As Array = Nothing

        If CInt(strCodigoId) > 0 Then
            objArray = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarDetalleExhibicionSucursal(CInt(strCodigoId), intCompaniaId, intSucursalId, strCadenaConexion)
        End If

        'Imprimir
        If Request.QueryString("strCmd") = "cmdImprimir" Then

            Dim strHTML As New StringBuilder
            Dim strRecordBrowserImpresion As String = String.Empty
            Const strComitasDobles As String = """"

            If IsArray(objArray) AndAlso objArray.Length > 0 Then

                'Se envia la informacion a imprimir para darle formato de acuerdo a la tabla seleccionada por el usuario.  
                strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strImpresionDetalle(objArray))

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

                strmDivision = CStr(CType(objArray.GetValue(0), Array).GetValue(2))
                strmCategoria = CStr(CType(objArray.GetValue(0), Array).GetValue(4))
                strmCatman = CStr(CType(objArray.GetValue(0), Array).GetValue(6))
                strmProveedor = CStr(CType(objArray.GetValue(0), Array).GetValue(10))
                strmSocioComercial = CStr(CType(objArray.GetValue(0), Array).GetValue(8))
                strmTipoRenta = CStr(CType(objArray.GetValue(0), Array).GetValue(12))
                strmTipoExhibicion = CStr(CType(objArray.GetValue(0), Array).GetValue(14))
                strmEspacioPublicitario = CStr(CType(objArray.GetValue(0), Array).GetValue(16))
                strmTipoPlanograma = CStr(CType(objArray.GetValue(0), Array).GetValue(22))
                strmPlanograma = CStr(CType(objArray.GetValue(0), Array).GetValue(24))
                strmNombreExhibicion = CStr(CType(objArray.GetValue(0), Array).GetValue(17))
                strmPlanSalida = CStr(CType(objArray.GetValue(0), Array).GetValue(19))
                strmComentariosPlanSalida = CStr(CType(objArray.GetValue(0), Array).GetValue(20))
                strmEstatus = CStr(CType(objArray.GetValue(0), Array).GetValue(26))
                strmFechaInicio = CDate(CType(objArray.GetValue(0), Array).GetValue(33)).ToString("dd/MM/yyyy")
                strmFechaFin = CDate(CType(objArray.GetValue(0), Array).GetValue(34)).ToString("dd/MM/yyyy")
                strmImplementado = CStr(CType(objArray.GetValue(0), Array).GetValue(35))
                strmRazon = CStr(CType(objArray.GetValue(0), Array).GetValue(37))
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
                'End If

                strmRutaImagen = Trim(CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(32)))

                If Not strmRutaImagen = String.Empty Then
                    strmRutaImagen = String.Format("{0}?id={1}", rutaImagenes, strmRutaImagen)
                End If

                'Imagen
                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='15%'>&nbsp;</td>")
                strImpresionExhibicionesHTML.Append("<td colspan='3' align='center'>")
                strImpresionExhibicionesHTML.AppendFormat("<img src=""{0}"" style=""border:none; width:5.in; height:3.6in;"">", strmRutaImagen)
                strImpresionExhibicionesHTML.Append("</td>")
                strImpresionExhibicionesHTML.Append("<td width='30%'>&nbsp;</td></tr>")

                strImpresionExhibicionesHTML.Append("<tr><td>&nbsp;</td></tr>")

                'Seccion Datos Generales
                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td colspan='5'><h3>Datos Generales:</h3></td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='20%' align='left' class='" & strclaseTitulos & "' >División:</td>")
                strImpresionExhibicionesHTML.Append("<td width='30%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(2)) & "</td>")
                strImpresionExhibicionesHTML.Append("<td width='5%'>&nbsp;</td>")
                strImpresionExhibicionesHTML.Append("<td width='15%' align='left' class='" & strclaseTitulos & "' >Categoría:</td>")
                strImpresionExhibicionesHTML.Append("<td width='30%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(4)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='20%' align='left' class='" & strclaseTitulos & "' >CATMAN:</td>")
                strImpresionExhibicionesHTML.Append("<td width='30%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(6)) & "</td>")
                strImpresionExhibicionesHTML.Append("<td width='5%'>&nbsp;</td>")
                strImpresionExhibicionesHTML.Append("<td width='15%' align='left' class='" & strclaseTitulos & "' >Socio Comercial:</td>")
                strImpresionExhibicionesHTML.Append("<td width='30%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(8)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='20%' align='left' class='" & strclaseTitulos & "' >Proveedor:</td>")
                strImpresionExhibicionesHTML.Append("<td width='30%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(10)) & "</td>")
                strImpresionExhibicionesHTML.Append("<td width='5%' align='left' class='" & strclase & "' >" & "</td>")
                strImpresionExhibicionesHTML.Append("<td width='15%' align='left' class='" & strclase & "' >" & "</td>")
                strImpresionExhibicionesHTML.Append("<td width='30%' align='left' class='" & strclase & "' >" & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")
                strImpresionExhibicionesHTML.Append("<tr><td>&nbsp;</td></tr>")

                'Seccion Datos Exhibicion
                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td colspan='5'><h3>Datos Exhibición:</h3></td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='20%' align='left' class='" & strclaseTitulos & "' >Tipo de Renta:</td>")
                strImpresionExhibicionesHTML.Append("<td width='30%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(12)) & "</td>")
                strImpresionExhibicionesHTML.Append("<td width='5%'>&nbsp;</td>")
                strImpresionExhibicionesHTML.Append("<td width='15%' align='left' class='" & strclaseTitulos & "' >Tipo de Exhibición:</td>")
                strImpresionExhibicionesHTML.Append("<td width='30%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(14)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='20%' align='left' class='" & strclaseTitulos & "' >Espacio Publicitario:</td>")
                strImpresionExhibicionesHTML.Append("<td width='30%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(16)) & "</td>")
                strImpresionExhibicionesHTML.Append("<td width='5%'>&nbsp;</td>")
                strImpresionExhibicionesHTML.Append("<td width='15%' align='left' class='" & strclaseTitulos & "' >Nombre de la Exhibición:</td>")
                strImpresionExhibicionesHTML.Append("<td width='30%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(17)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='20%' align='left' class='" & strclaseTitulos & "' >Plan de Salida:</td>")
                strImpresionExhibicionesHTML.Append("<td width='30%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(19)) & "</td>")
                strImpresionExhibicionesHTML.Append("<td width='5%'>&nbsp;</td>")
                strImpresionExhibicionesHTML.Append("<td width='15%' align='left' class='" & strclaseTitulos & "' >Comentarios:</td>")
                strImpresionExhibicionesHTML.Append("<td width='30%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(20)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='20%' align='left' class='" & strclaseTitulos & "' >Tipo de Planograma:</td>")
                strImpresionExhibicionesHTML.Append("<td width='30%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(22)) & "</td>")
                strImpresionExhibicionesHTML.Append("<td width='5%'>&nbsp;</td>")
                strImpresionExhibicionesHTML.Append("<td width='15%' align='left' class='" & strclaseTitulos & "' >Planograma:</td>")
                strImpresionExhibicionesHTML.Append("<td width='30%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(24)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='20%' align='left' class='" & strclaseTitulos & "' >Estatus:</td>")
                strImpresionExhibicionesHTML.Append("<td width='30%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(26)) & "</td>")
                strImpresionExhibicionesHTML.Append("<td colspan='3'>&nbsp;</td>")
                strImpresionExhibicionesHTML.Append("</tr>")
                strImpresionExhibicionesHTML.Append("<tr><td>&nbsp;</td></tr>")

                'Seccion Vigencia
                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td colspan='5'><h3>Vigencia:</h3></td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")
                strImpresionExhibicionesHTML.Append("<td width='20%' align='left' class='" & strclaseTitulos & "' >Fecha Inicio:</td>")
                strImpresionExhibicionesHTML.Append("<td width='30%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(33)) & "</td>")
                strImpresionExhibicionesHTML.Append("<td width='5%'>&nbsp;</td>")
                strImpresionExhibicionesHTML.Append("<td width='15%' align='left' class='" & strclaseTitulos & "' >Fecha Fin:</td>")
                strImpresionExhibicionesHTML.Append("<td width='30%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(34)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                strImpresionExhibicionesHTML.Append("<tr>")

                'Si la Renta ha sido ASIGNADA
                If CBool(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(35)) = True Then
                    RentaAsignada = "checked"
                End If

                chk = "<input type='checkbox'" & RentaAsignada & " />"

                strImpresionExhibicionesHTML.Append("</tr>")
                strImpresionExhibicionesHTML.Append("<td width='20%' align='left' class='" & strclaseTitulos & "' >Implementado:</td>")
                strImpresionExhibicionesHTML.Append("<td width='30%' align='left' class='" & strclase & "' >" & chk & "</td>")
                strImpresionExhibicionesHTML.Append("<td width='5%'>&nbsp;</td>")
                strImpresionExhibicionesHTML.Append("<td width='15%' align='left' class='" & strclaseTitulos & "' >Motivo:</td>")
                strImpresionExhibicionesHTML.Append("<td width='30%' align='left' class='" & strclase & "' >" & CStr(CType(objDataArrayDetalle.GetValue(0), Array).GetValue(38)) & "</td>")
                strImpresionExhibicionesHTML.Append("<tr>")

                strImpresionExhibicionesHTML.Append("</tr>")
                strImpresionExhibicionesHTML.Append("</table>")

            Next

        End If

        Return strImpresionExhibicionesHTML.ToString()

    End Function

    Private Function strImprimeEncabezado(ByVal strHojaActual As String, ByVal strHojaFinal As String) As String

        Dim strHtmlEncabezado As StringBuilder
        strHtmlEncabezado = New StringBuilder

        'Encabezado principal
        strHtmlEncabezado.Append("<tr>")
        strHtmlEncabezado.Append("<td colspan='5'>")
        strHtmlEncabezado.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='5' class='tdtxtBold'>Exhibiciones Adicionales - Consulta</th>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='10%' align='left'   class='tdtxtBold'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th width='70%' align='center' class='tdtxtBold' nowrap colspan='3'>" & strCentroLogisticoId & " - " & strSucursalNombre & " (" & intCompaniaId.ToString & intSucursalId.ToString("000") & ")" & "</th>")
        strHtmlEncabezado.Append("<th width='20%' align='left'  class='tdtxtBold'>HOJA " & strHojaActual & " / " & strHojaFinal & " </th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strHtmlEncabezado.Append("</td>")
        strHtmlEncabezado.Append("</tr>")

        strImprimeEncabezado = strHtmlEncabezado.ToString

    End Function

#End Region
End Class